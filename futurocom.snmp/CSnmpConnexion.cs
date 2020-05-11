using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Net;
using futurocom.snmp.Messaging;
using System.Data;
using futurocom.snmp.Proxy;
using futurocom.supervision;
using futurocom.snmp.mediation;
using futurocom.snmp.entitesnmp;
using sc2i.common.memorydb;
using sc2i.common.trace;
using sc2i.common.DonneeCumulee;


namespace futurocom.snmp
{
    public class CSnmpConnexion : MarshalByRefObject, ISnmpConnexion
    {
        public const string c_parametreIp = "AGENT IP";
        public const string c_parametrePort = "AGENT PORT";
        public const string c_parametreCommunaute = "COMMUNITY";
        public const string c_parametreVersion = "VERSION";
        public const string c_parametreTimeout = "TIMEOUT";

        private IPEndPoint m_endPoint;
        private string m_strCommunity = "public";
        private VersionCode m_version = VersionCode.V1;
        private int m_nTimeOut = 3000;
        private static C2iSponsor m_sponsor = new C2iSponsor();

        private static ISynchroniseurServiceMediation m_synchroniseurServiceMediation = null;
        private static IFournisseurDeConfigurationProxy m_fournisseurDeConfiguration = null;
        private static ITraiteurAlarmeFromMediation m_traiteurAlarme = null;
        
        /// <summary>
        /// Indique que tout passe par un proxy, cette fonction est utile
        /// pour la connexion sur le client TIMOS qui renvoie forcement
        /// tout sur le serveur TIMOS
        /// </summary>
        private static bool m_bOnlyUseProxy = false;

        private static CSnmpConnexion m_defaultInstance = null;

        //-----------------------------------------------
        public static CSnmpConnexion DefaultInstance
        {
            get
            {
                if (m_defaultInstance == null)
                    m_defaultInstance = new CSnmpConnexion();
                return m_defaultInstance;
            }
        }

        //-----------------------------------------------
        public static ISynchroniseurServiceMediation SynchroniseurDeServiceMediation
        {
            get
            {
                return m_synchroniseurServiceMediation;
            }
            set
            {
                m_synchroniseurServiceMediation = value;
            }
        }

        //-----------------------------------------------
        public static IFournisseurDeConfigurationProxy FournisseurDeConfigurationProxy
        {
            get
            {
                return m_fournisseurDeConfiguration;
            }
            set
            {
                m_fournisseurDeConfiguration = value;
            }
        }

        //-----------------------------------------------
        public static ITraiteurAlarmeFromMediation TraiteurAlarme
        {
            get
            {
                return m_traiteurAlarme;
            }
            set
            {
                m_traiteurAlarme = value;
            }
        }


        //-----------------------------------------------
        public CSnmpConnexion()
        {
            m_endPoint = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 161);
        }

        //-----------------------------------------------
        public CSnmpConnexion(VersionCode version,
                                string strCommunity,
                                IPEndPoint endPoint,
                                int nTimeout)
        {
            m_version = version;
            m_strCommunity = strCommunity;
            m_endPoint = endPoint;
            m_nTimeOut = nTimeout;
        }

        //-----------------------------------------------
        public static bool ToutPasserParDesProxies
        {
            get
            {
                return m_bOnlyUseProxy;
            }
            set
            {
                m_bOnlyUseProxy = value;
            }
        }
                

       
        //-----------------------------------------------
        public IPEndPoint EndPoint
        {
            get
            {
                return m_endPoint;
            }
            set
            {
                m_endPoint = value;
            }
        }

        //-----------------------------------------------
        public string Community
        {
            get
            {
                return m_strCommunity;
            }
            set
            {
                m_strCommunity = value;
            }
        }

        //-----------------------------------------------
        public int TimeOut
        {
            get
            {
                return m_nTimeOut;
            }
            set
            {
                m_nTimeOut = value;
            }
        }

        //-----------------------------------------------
        public VersionCode Version
        {
            get
            {
                return m_version;
            }
            set
            {
                m_version = value;
            }
        }

        //-----------------------------------------------
        public CSnmpProxyConfiguration ConfigurationSNMP
        {
            get
            {
                return CSnmpProxyConfiguration.GetInstance();
            }
        }

        //------------------------------------------------------------------------
        private CSnmpProxy[] GetProxies()
        {
            if(ConfigurationSNMP != null)
                return ConfigurationSNMP.GetProxiesSuivants(m_endPoint.Address);
            return new CSnmpProxy[] { };
        }

        //-------------------------------------------------------------------------
        private ISnmpConnexion GetConnexionDistante()
        {
            foreach(CSnmpProxy proxy in GetProxies())
            {
                ISnmpConnexion cnx = proxy.GetConnexion();
                if(cnx != null)
                {
                    cnx.EndPoint = this.EndPoint;
                    cnx.Community = this.Community;
                    cnx.TimeOut = this.TimeOut;
                    cnx.Version = this.Version;
                    cnx.CalcTimeoutFromIp();
                    return cnx;
                }
            }

            return null;
        }

        //-------------------------------------------------------------------------
        public void CalcTimeoutFromIp()
        {
            IEnumerable<CAgentSnmpPourSupervision> agents = CServiceMediation.GetDefaultInstance().Configuration.GetAgentsForIp(EndPoint.Address.ToString());
            if (agents.Count() > 0)
            {
                IEnumerable<int> timeouts = from a in agents select a.Timeout;
                TimeOut = Math.Max(timeouts.Max(),TimeOut);
            }
        }


        
        //-----------------------------------------------
        public CResultAErreurType<IList<Variable>> Get(IList<Variable> variables)
        {
            ISnmpConnexion cnxDisttante = GetConnexionDistante();
            if(cnxDisttante != null)
                return cnxDisttante.Get(variables);

            CResultAErreurType<IList<Variable>> result = new CResultAErreurType<IList<Variable>>();
            try
            {
                IList<Variable> lst = Messenger.Get(
                    m_version,
                    m_endPoint,
                    new OctetString(m_strCommunity),
                    variables,
                    m_nTimeOut);
                result.Data = lst;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //-----------------------------------------------
        public CResultAErreurType<Variable> Get(uint[] oid)
        {
            CResultAErreurType<Variable> resultVar = new CResultAErreurType<Variable>();
            ISnmpConnexion cnxDisttante = GetConnexionDistante();
            if (cnxDisttante != null)
            {
                try
                {
                    resultVar = cnxDisttante.Get(oid);
                }
                catch (Exception e)
                {
                    resultVar.EmpileErreur(new CErreurException(e));
                }
                return resultVar;
            }

            
            Variable variable = new Variable(oid);
            List<Variable> lstSource = new List<Variable>();
            lstSource.Add(variable);

            CResultAErreurType<IList<Variable>> resultList = Get(lstSource);
            if (resultList)
            {
                if (resultList.DataType.Count > 0)
                    resultVar.Data = resultList.DataType[0];
            }
            else
            {
                resultVar.EmpileErreur(resultList.Erreur);
            }
            return resultVar;
        }

        //-----------------------------------------------
        public CResultAErreur Set(uint[] oid, object valeur)
        {
            ISnmpConnexion cnxDisttante = GetConnexionDistante();
            if (cnxDisttante != null)
                return cnxDisttante.Set(oid, valeur);

            CResultAErreur result = CResultAErreur.True;
            if (!(valeur is string) && !(valeur is ISnmpData))
            {
                result.EmpileErreur("Can not set non string values");
                return result;
            }
            List<Variable> variables = new List<Variable>();
            variables.Add(new Variable(oid, valeur is ISnmpData ?(ISnmpData)valeur:new OctetString(valeur.ToString())));
            try
            {
                Messenger.Set(
                       m_version,
                       m_endPoint,
                       new OctetString(m_strCommunity),
                       variables,
                       m_nTimeOut);
            }
            catch (ErrorException errEx)
            {
                result.EmpileErreur(new CErreurValidation(errEx.Message, true));
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //-----------------------------------------------
        public CResultAErreurType<IList<Variable>> Walk(uint[] oid)
        {
            ISnmpConnexion cnxDisttante = GetConnexionDistante();
            if (cnxDisttante != null)
                return cnxDisttante.Walk(oid);

            CResultAErreurType<IList<Variable>> resultList = new CResultAErreurType<IList<Variable>>();
            List<Variable> lstVars = new List<Variable>();
            try
            {
                int nResult = Messenger.Walk(m_version,
                    m_endPoint,
                    new OctetString(m_strCommunity),
                    new ObjectIdentifier(oid),
                    lstVars,
                    m_nTimeOut,
                    WalkMode.WithinSubtree);
                resultList.DataType = lstVars;
            }
            catch (Exception e)
            {
                resultList.EmpileErreur(new CErreurException(e));
            }
            return resultList;
        }



        //-------------------------------------------------------------
        public CResultAErreurType<DataTable> GetTable(uint[] oid, params uint[][] colonnesAPrendre)
        {
            ISnmpConnexion cnxDisttante = GetConnexionDistante();
            if (cnxDisttante != null)
                return cnxDisttante.GetTable(oid, colonnesAPrendre);

            CResultAErreurType<DataTable> resultTable = new CResultAErreurType<DataTable>();
            List<Variable> lstVars = new List<Variable>();
            try
            {
                resultTable.DataType = Messenger.ReadTable(m_version,
                    m_endPoint,
                    new OctetString(m_strCommunity),
                    new ObjectIdentifier(oid),
                    m_nTimeOut,
                    colonnesAPrendre);
            }
            catch (Exception e)
            {
                resultTable.EmpileErreur(new CErreurException(e));
            }
            return resultTable;
        }

        //---------------------------------------------------
        private bool IsMySelf()
        {
            if (m_bOnlyUseProxy)
                return false;
            System.Net.IPHostEntry moiMeme = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach ( IPAddress adresse in moiMeme.AddressList )
                if ( adresse.Equals ( EndPoint.Address ) )
                    return true;
            return false;
        }

        //--------------------------------------------------------------------
        public CResultAErreurType<CMappageIdsAlarmes> RemonteAlarmes(CMemoryDb dbContenantLesAlarmesARemonter)
        {
            CResultAErreurType<CMappageIdsAlarmes> result = new CResultAErreurType<CMappageIdsAlarmes>();

            if (m_traiteurAlarme != null)
                return m_traiteurAlarme.Traite(dbContenantLesAlarmesARemonter);
            else
            {
                foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().GetProxiesPrecedents())
                {
                    ISnmpConnexion connexion = proxy.GetConnexion();
                    return connexion.RemonteAlarmes(dbContenantLesAlarmesARemonter);
                }
            }
            result.EmpileErreur(I.T("Can not manage alarms"));

            return result;
        }

        //--------------------------------------------------------------------
        public void UpdateAgentIpFromMediation(string strAgentId, string strNewIp, bool bUpdateTimosDb)
        {
            if (m_traiteurAlarme != null)
            {
                m_traiteurAlarme.UpdateAgentIpFromMediation(strAgentId, strNewIp, bUpdateTimosDb);
            }
            else
            {
                CServiceMediation service = CServiceMediation.GetDefaultInstance();
                if ( service != null && service.Configuration != null && service.Configuration.DataBase != null)
                {
                    CAgentSnmpPourSupervision agent = service.Configuration.DataBase.GetEntite<CAgentSnmpPourSupervision>(strAgentId);
                    if (agent != null)
                        agent.Ip = strNewIp;
                }
                foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().GetProxiesPrecedents())
                {
                    ISnmpConnexion cnx = proxy.GetConnexion();
                    cnx.UpdateAgentIpFromMediation(strAgentId, strNewIp, bUpdateTimosDb);
                }
            }
        }

        //--------------------------------------------------------------------
        public void RedescendAlarmes(CMemoryDb dbContenantLesAlarmesARedescendre)
        {
            CServiceMediation.GetDefaultInstance().RedescendAlarmes(dbContenantLesAlarmesARedescendre);
            foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().ListeProxySuivants)
            {
                try
                {
                    ISnmpConnexion connexion = proxy.GetConnexion();
                    RedescendAlarmesDelegate del = new RedescendAlarmesDelegate(RedescendAlarmeAsync);
                    del.BeginInvoke(connexion, dbContenantLesAlarmesARedescendre, null, null);
                }
                catch
                {
                }
            }
        }

        private delegate void RedescendAlarmesDelegate(ISnmpConnexion connexion, CMemoryDb dbContenantLesAlarmesARedescendre);

        private void RedescendAlarmeAsync(ISnmpConnexion connexion, CMemoryDb dbContenantLesAlarmes)
        {
            connexion.RedescendAlarmes(dbContenantLesAlarmes);
        }




        //-----------------------------------------------------------------------
        public IDonneeSynchronisationMediation GetDonneesPourSynchro(int nIdProxy, int nIdLastSyncSessionConnue)
        {
            if (m_synchroniseurServiceMediation != null)
            {
                try
                {
                    return m_synchroniseurServiceMediation.GetUpdatesForProxy(nIdProxy, nIdLastSyncSessionConnue);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            //Demande au proxy précédent d'aller chercher les données
            foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().GetProxiesPrecedents())
            {
                try
                {
                    ISnmpConnexion connexion = proxy.GetConnexion();
                    return connexion.GetDonneesPourSynchro(nIdProxy, nIdLastSyncSessionConnue);
                }
                catch { }
            }
            return null;
        }


        //-----------------------------------------------------------------------
        public CResultAErreur SendDonneesPooled(List<CDonneeCumuleeTransportable> lstDonnees)
        {
            if (m_synchroniseurServiceMediation != null)
            {
                try
                {
                    return m_synchroniseurServiceMediation.SendDonneesPooled(lstDonnees);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            //Demande au proxy précédent d'aller chercher les données
            foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().GetProxiesPrecedents())
            {
                try
                {
                    ISnmpConnexion connexion = proxy.GetConnexion();
                    return connexion.SendDonneesPooled(lstDonnees);
                }
                catch { }
            }
            return null;
        }

        //---------------------------------------------------
        public CSnmpProxyConfiguration GetConfigurationDeSnmpProxy(int nIdProxy)
        {
            if (m_fournisseurDeConfiguration != null)
                return m_fournisseurDeConfiguration.GetConfigurationDeProxy(nIdProxy);
            foreach (CSnmpProxy proxy in CSnmpProxyConfiguration.GetInstance().GetProxiesPrecedents())
            {
                try
                {
                    ISnmpConnexion connexion = proxy.GetConnexion();
                    return connexion.GetConfigurationDeSnmpProxy(nIdProxy);
                }
                catch { }
            }

            return null;
        }

        //---------------------------------------------------
        public void SetConfigurationDeSnmpProxy(CSnmpProxyConfiguration config)
        {
            if (IsMySelf())
            {
                if (config != null)
                    CSnmpProxyConfiguration.SetDefaultInstance(config);
            }
            else
            {
                ISnmpConnexion cnx = GetConnexionDistante();
                if (cnx != null)
                    cnx.SetConfigurationDeSnmpProxy(config);
            }
        }

        //---------------------------------------------------
        public void NotifyProxyNecessiteMAJ(
            int nIdProxy, 
            bool bConfigProxy, 
            bool bServiceMediation,
            bool bFullSync)
        {
            if (IsMySelf())
            {
                StringBuilder bl = new StringBuilder();
                bl.Append("Proxy setup update requiered ");
                bl.Append("proxy setup=");
                bl.Append(bConfigProxy);
                bl.Append(", mediation setup=");
                bl.Append(bServiceMediation);
                bl.Append(", Full update=");
                bl.Append(bFullSync);
                CServiceMediation.GetDefaultInstance().Trace.Write(bl.ToString(), ALTRACE.DEBUG, ALTRACE.POLLING, ALTRACE.TRACE);
                CSnmpProxyConfiguration.GetInstance().IdProxyConfiguré = nIdProxy;
                if (bConfigProxy)
                    CSnmpProxyConfiguration.GetInstance().MiseAJour(false);
                if (bServiceMediation)
                    CServiceMediation.GetDefaultInstance().Configuration.MettreAJour(bFullSync, true);
            }
            else
            {
                ISnmpConnexion cnxDisttante = GetConnexionDistante();
                if (cnxDisttante != null)
                    cnxDisttante.NotifyProxyNecessiteMAJ(nIdProxy, bConfigProxy, bServiceMediation, bFullSync);
            }
        }

        //--------------------------------------------------------------------------
        public CResultAErreur CreateUpdateObjet(object objet)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!IsMySelf())
            {
                ISnmpConnexion cnxDisttante = GetConnexionDistante();
                if (cnxDisttante != null)
                    return cnxDisttante.CreateUpdateObjet(objet);
                result.EmpileErreur(I.T("Can not reach host @1|20009", EndPoint.Address.ToString()));
                return result;
            }
            if (objet is CSnmpProxyConfiguration)
            {
                CSnmpProxyConfiguration.SetDefaultInstance((CSnmpProxyConfiguration)objet);
            }
            if (objet is CValiseEntiteDeMemoryDb)
                objet = ((CValiseEntiteDeMemoryDb)objet).Entite;
            if (objet is CEntiteDeMemoryDb)
            {
                result = CServiceMediation.GetDefaultInstance().Configuration.UpdateEntite(objet as sc2i.common.memorydb.CEntiteDeMemoryDb);
            }
           
            return result;

        }

        //---------------------------------------------------
        public CResultAErreur DeleteObjet(Type typeObjet, string strIdObjet)
        {
            CResultAErreur result = CResultAErreur.True;
            if (!IsMySelf())
            {
                ISnmpConnexion cnxDisttante = GetConnexionDistante();
                if (cnxDisttante != null)
                    return cnxDisttante.DeleteObjet(typeObjet, strIdObjet);
                result.EmpileErreur(I.T("Can not reach host @1|20009"));
                return result;
            }
            
            if (typeof(CEntiteSnmpPourSupervision).IsAssignableFrom(typeObjet))
            {
                result = CServiceMediation.GetDefaultInstance().Configuration.RemoveEntite(typeObjet,strIdObjet);
            }
            
            return result;
        }

        //------------------------------------------------
        public IServiceMediation ServiceMediation
        {
            get
            {
                if (!IsMySelf())
                {
                    ISnmpConnexion cnxDisttante = GetConnexionDistante();
                    if (cnxDisttante != null)
                    {
                        IServiceMediation serviceDistant = cnxDisttante.ServiceMediation;
                        if (serviceDistant != null)
                            return new CProxyServiceMediation(serviceDistant);
                    }
                    return null;
                }
                return CServiceMediation.GetDefaultInstance();
            }
        }

        //------------------------------------------------
        public void AddTraceListener(IFuturocomTraceListener listener)
        {
            if (!IsMySelf())
            {
                ISnmpConnexion cnxDistante = GetConnexionDistante();
                if (cnxDistante != null)
                {
                    CProxyListener proxy = new CProxyListener(listener);
                    m_sponsor.Register(listener);
                    cnxDistante.AddTraceListener(proxy);
                }
            }
            else
                CServiceMediation.GetDefaultInstance().AddTraceListener(listener);
        }

        //------------------------------------------------
        public void RemoveTraceListener(IFuturocomTraceListener listener)
        {
            if (!IsMySelf())
            {
                ISnmpConnexion cnxDistante = GetConnexionDistante();
                if (cnxDistante != null)
                {
                    CProxyListener proxy = new CProxyListener(listener);
                    m_sponsor.Unregister(listener);
                    cnxDistante.RemoveTraceListener(proxy);
                }
            }
            else
                CServiceMediation.GetDefaultInstance().RemoveTraceListener(listener);
        }






    
    }
}
