using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.Messaging;
using futurocom.supervision;
using System.Net;
using futurocom.snmp.alarme;
using futurocom.snmp.entitesnmp;
using sc2i.common;
using sc2i.common.memorydb;
using sc2i.common.trace;
using futurocom.snmp.polling;
using futurocom.snmp.Proxy;
using System.Data;

namespace futurocom.snmp.mediation
{
    public class CServiceMediation : MarshalByRefObject, IServiceMediation, ITraiteurAlarmeFromMediation
    {
        private Listener m_listener = new Listener();
        private CGestionnaireAlarmesSupervision m_gestionnaireAlarmes = new CGestionnaireAlarmesSupervision();
        private CConfigurationServiceMediation m_configuration = new CConfigurationServiceMediation();

        private List<ISnmpMessage> m_listeMessagesATraiter = new List<ISnmpMessage>();

        private static CServiceMediation m_defaultInstance = null;

        private CFuturocomTrace m_trace = new CFuturocomTrace();

        //----------------------------------------------------------
        public static CServiceMediation GetDefaultInstance()
        {
            if (m_defaultInstance == null)
            {
                m_defaultInstance = new CServiceMediation();
                CSnmpPollingService.Configuration = m_defaultInstance.m_configuration;
            }
            return m_defaultInstance;
        }

        //----------------------------------------------------------
        private CServiceMediation()
        {
            m_listener.MessageReceived += new EventHandler<MessageReceivedEventArgs>(m_listener_MessageReceived);
            m_listener.AddBinding(new IPEndPoint(new IPAddress(new byte[] { 0, 0, 0, 0 }), 162));
            CCurentBaseTypesAlarmes.SetCurrentBase(m_configuration);
            m_gestionnaireAlarmes.Database.AddFournisseurElementsManquants(m_configuration);
            m_gestionnaireAlarmes.BaseFiltrage = m_configuration;
            m_gestionnaireAlarmes.TraiteurAlarmes = this;
            m_gestionnaireAlarmes.Trace = m_trace;
            
        }

        //----------------------------------------------------------
        public void OnChangementDansBaseConfiguration()
        {
            m_gestionnaireAlarmes.Database.UpdateFrom(Configuration.DataBase);
        }

        //----------------------------------------------------------
        public CFuturocomTrace Trace
        {
            get
            {
                return m_trace;
            }
        }


        //----------------------------------------------------------
        void m_listener_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            OnReceiveMessageDelegate del = new OnReceiveMessageDelegate(OnReceiveMessage);
            del.BeginInvoke(e, null, null);

        }

        //----------------------------------------------------------
        public delegate void OnReceiveMessageDelegate(MessageReceivedEventArgs e);

        //-----------------------------------------------
        private static int m_nNbRecus = 0;
        public void OnReceiveMessage(MessageReceivedEventArgs e)
        {
            int nIdMes = m_nNbRecus++;
            lock (m_listeMessagesATraiter)
            {
                m_listeMessagesATraiter.Add(e.Message);
                if ( e.Message is InformRequestMessage )
                {
                    InformRequestMessage mes = e.Message as InformRequestMessage;
                    if (mes.SourceEndPoint != null)
                    {
                        ResponseMessage response = new ResponseMessage(
                            mes.RequestId(),
                            mes.Version,
                            mes.Community(),
                            ErrorCode.NoError,
                            0,
                            mes.Variables());
                        try
                        {
                            response.Send(mes.SourceEndPoint);
                        }
                        catch (Exception ex )
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                }
            }
            TraiteMessagesATraiter();
        }

        public class CLockerTraiteMessage{}
        private int m_nNbMessages = 0;
        private int m_nWaitingCounter = 0;
        //-----------------------------------------------
        private void TraiteMessagesATraiter()
        {
            if (m_nWaitingCounter > 5)
                return;
            m_nWaitingCounter++;
            lock (typeof(CLockerTraiteMessage))
            {
                m_nWaitingCounter--;
                List<ISnmpMessage> lstMessages = new List<ISnmpMessage>();
                lock (m_listeMessagesATraiter)
                {
                    lstMessages.AddRange(m_listeMessagesATraiter);
                    m_listeMessagesATraiter.Clear();
                }



                foreach (ISnmpMessage message in lstMessages)
                {
                    m_nNbMessages++;
                    DateTime dtChrono = DateTime.Now;
                    string strIpAgent = "";
                    TrapV1Message trapV1 = message as TrapV1Message;
                    TrapV2Message trapV2 = message as TrapV2Message;
                    if (trapV1 != null)
                    {
                        m_gestionnaireAlarmes.Trace.Write(
                            "Trap received : " + trapV1.GetTraceInfo(),
                            ALTRACE.TRACE, ALTRACE.DEBUG);
                        strIpAgent = trapV1.AgentAddress.ToString();
                        StringBuilder bl = new StringBuilder();
                        foreach (Variable valeur in trapV1.Variables())
                        {
                            bl.Append(valeur.Id.ToString());
                            bl.Append("=");
                            bl.Append(valeur.Data.ToString());
                            bl.Append("\r\n");
                        }
                        m_gestionnaireAlarmes.Trace.Write(
                           "Trap fields : \r\n" + bl.ToString(),
                           ALTRACE.TRACE, ALTRACE.DEBUG);
                    }
                    else if (trapV2 != null)
                    {
                        m_gestionnaireAlarmes.Trace.Write(
                            "Trap received : " + trapV2.GetTraceInfo(),
                            ALTRACE.TRACE, ALTRACE.DEBUG);
                        if (trapV2.SenderIP != null)
                            strIpAgent = trapV2.SenderIP.ToString();
                        StringBuilder bl = new StringBuilder();
                        foreach (Variable valeur in trapV2.Variables())
                        {
                            bl.Append(valeur.Id.ToString());
                            bl.Append("=");
                            bl.Append(valeur.Data.ToString());
                            bl.Append("\r\n");
                        }
                        m_gestionnaireAlarmes.Trace.Write(
                           "Trap fields : \r\n" + bl.ToString(),
                           ALTRACE.TRACE, ALTRACE.DEBUG);
                    }
                    try
                    {
                        CTrapInstance trapTmp = CTrapInstance.FromMessage(message, null);
                        if ( trapTmp == null )
                        {
                            m_gestionnaireAlarmes.Trace.Write(
                                "Can not interpret message " + message.ToString(), ALTRACE.TRACE, ALTRACE.DEBUG);
                            continue;
                        }
                        IEnumerable<CAgentSnmpPourSupervision> lstAgents = GetAgentsForTrap(trapTmp, strIpAgent);
                        

                        bool bHasAgent = false;

                        foreach (CAgentSnmpPourSupervision agent in lstAgents)
                        {
                            m_gestionnaireAlarmes.Trace.Write(
                                "Trap managed by agent " + agent.Id,
                                ALTRACE.DEBUG);
                            CTypeAgentPourSupervision typeAgent = agent.TypeAgent;
                            if (typeAgent != null)
                            {
                                CTrapInstance trap = CTrapInstance.FromMessage(
                                    message,
                                    agent);
                                if (trap != null)
                                {
                                    IEnumerable<CTrapHandler> lstTrapsHandlers = typeAgent.GetTrapsHandlersAAppliquer(trap);
                                    foreach (CTrapHandler handler in lstTrapsHandlers)
                                    {
                                        m_gestionnaireAlarmes.Trace.Write("Apply trap handler " + handler.Libelle,
                                            ALTRACE.DEBUG);
                                        handler.CreateAlarmesOnTrap(trap, m_gestionnaireAlarmes.Trace);
                                    }
                                    if (lstTrapsHandlers.Count() == 0)
                                        m_gestionnaireAlarmes.Trace.Write(
                                            "No trap handler for this trap",
                                            ALTRACE.DEBUG);

                                    foreach (CAlarmeACreer creation in trap.AlarmesACreer)
                                        m_gestionnaireAlarmes.CreateAlarme(creation, EModeRemonteeAlarmes.InscrireARemonterMaisNePasLeFaire);
                                    
                                    if (trap.AlarmesACreer.Count() == 0)
                                        m_gestionnaireAlarmes.Trace.Write("No alarm creator for this trap",
                                            ALTRACE.DEBUG);
                                }
                            }
                        }
                        if (!bHasAgent)
                            m_gestionnaireAlarmes.Trace.Write(
                                "No agent for this trap",
                                ALTRACE.DEBUG);
                    }

                    catch (Exception ex)
                    {
                        m_gestionnaireAlarmes.Trace.Write(
                            "Exception : " + ex.Message,
                            ALTRACE.DEBUG);
                        lock (m_listeMessagesATraiter)
                        {
                            m_listeMessagesATraiter.InsertRange(0, lstMessages);
                        }
                        break;
                    }
                    TimeSpan sp = DateTime.Now - dtChrono;
                    if ( m_nNbMessages%100 == 0)
                        Console.WriteLine("Traite alrm ("+m_nNbMessages+"): " + sp.TotalMilliseconds);

                }
            }
            m_gestionnaireAlarmes.SendAlarmes();
        }

        //-----------------------------------------------
        private IEnumerable<CAgentSnmpPourSupervision> GetAgentsForTrap ( CTrapInstance trap, string strTrapOriginIP )
        {
            /*Principe de fonctionnement :
             * On tente tout d'abord de trouver les agents qui ont l'ip transmise par le trap.
             * Si on en trouve
             *      On vérifie s'il  y a des finders pour ce trap et cet agent, et si oui,
             *      on vérifie que la clé correspond.
             *      Si elle correspond, on garde l'agent
             *      Sinon, on le supprime de la liste des agents valides
             *  Sinon (on n'a pas trouvé d'agent par l'IP ou bien la liste est vide suite à la passe 1)
             *      Chercher via TOUS les finders de la base des agents qui correspondraient
            */
            List<CAgentSnmpPourSupervision> listeAgentsFromIp = new List<CAgentSnmpPourSupervision>(
                                m_configuration.GetAgentsForIp(strTrapOriginIP));
            
            if ( listeAgentsFromIp.Count > 0 )
            {
                foreach ( CAgentSnmpPourSupervision agent in listeAgentsFromIp.ToArray() )
                {
                    IEnumerable<CAgentFinderFromKey> lstFinders = agent.TypeAgent.GetAgentFindersAAppliquer(trap);
                    if (lstFinders.Count() == 0)
                        continue;//Pas de finder à appliquer, on conserve donc l'agent
                    bool bOneMatch = false;
                    foreach ( CAgentFinderFromKey finder in lstFinders )
                    {
                        if (finder.MatchAgent(trap, agent))
                        {
                            bOneMatch = true;
                            break;
                        }
                    }
                    if (!bOneMatch)//Aucun finder ne colle avec l'agent, il n'est donc pas valide
                        listeAgentsFromIp.Remove(agent);
                }
                if (listeAgentsFromIp.Count() > 0)
                    return listeAgentsFromIp.AsReadOnly();
            }

            HashSet<CAgentSnmpPourSupervision> lstAgents = new HashSet<CAgentSnmpPourSupervision>();
            //On n'a pas trouvé d'agent via l'IP
            CListeEntitesDeMemoryDb<CAgentFinderFromKey> lstFindersFromDb = new CListeEntitesDeMemoryDb<CAgentFinderFromKey>(m_configuration.DataBase);
            foreach (CAgentFinderFromKey finder in lstFindersFromDb)
            {
                if (finder.ShouldApply(trap))
                {
                    foreach (CAgentSnmpPourSupervision agent in finder.GetAgentsFromKey(trap))
                    {
                        if (strTrapOriginIP != null && strTrapOriginIP.Length > 0)
                        {
                            if (finder.AutoUpdateIpOnMediationServices)
                                agent.Ip = strTrapOriginIP;
                            if (finder.AutoUpdateIpOnMediationServices || finder.AutoUpdateIpOnTimosDatabase)
                                UpdateAgentIpFromMediation(agent.Id, strTrapOriginIP,finder.AutoUpdateIpOnTimosDatabase);
                        }
                        lstAgents.Add(agent);
                    }
                }
            }
            return lstAgents;
        }

        //-----------------------------------------------
        public CConfigurationServiceMediation Configuration
        {
            get
            {
                return m_configuration;
            }
        }

        //----------------------------------------------------------
        public bool IsStarted
        {
            get
            {
                return m_listener.Active;
            }
        }

        //----------------------------------------------------------
        public CResultAErreur Start()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                if ( !m_listener.Active )
                    m_listener.Start();
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //----------------------------------------------------------
        public CResultAErreur Stop()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                if (m_listener.Active)
                    m_listener.Stop();
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //----------------------------------------------------------
        public CResultAErreurType<CMappageIdsAlarmes> Traite(CMemoryDb dbContenantLesAlarmesATraiter)
        {
            return CSnmpConnexion.DefaultInstance.RemonteAlarmes(dbContenantLesAlarmesATraiter);
        }

        //----------------------------------------------------------
        public void UpdateAgentIpFromMediation ( string strIdAgent, string strNewIp, bool bUpdateTimosDb )
        {
            CSnmpConnexion.DefaultInstance.UpdateAgentIpFromMediation(strIdAgent, strNewIp, bUpdateTimosDb);
        }

        //----------------------------------------------------------
        public void RedescendAlarmes(CMemoryDb dbContenantLesAlarmesARedescendre)
        {
            m_gestionnaireAlarmes.RedescendAlarmes(dbContenantLesAlarmesARedescendre);
        }

        //----------------------------------------------------------
        public void AddTraceListener(IFuturocomTraceListener listener)
        {
            Trace.RegisterListener(listener);
        }

        //----------------------------------------------------------
        public void RemoveTraceListener(IFuturocomTraceListener listener)
        {
            m_gestionnaireAlarmes.Trace.UnregistrerListener(listener);
        }
    }
}
