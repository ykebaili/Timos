using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.supervision;
using futurocom.snmp.Messaging;
using sc2i.expression;
using futurocom.snmp.dynamic;
using futurocom.easyquery;
using futurocom.snmp.entitesnmp;
using sc2i.common.memorydb;
using sc2i.common.trace;
using futurocom.snmp.mediation;

namespace futurocom.snmp.alarme
{
    

    [Serializable]
    public class CTrapInstance
    {
        private List<CTrapFieldValueBrute> m_listeValues = new List<CTrapFieldValueBrute>();
        private Dictionary<string, string> m_listeValeursSupplementaires = new Dictionary<string, string>();
        private string m_strEntreprise = "";
        private VersionCode m_version = VersionCode.V1;
        private string m_strAgentIP = "";
        private string m_strCommunity = "";
        private GenericCode m_genericCode = GenericCode.EnterpriseSpecific;
        private string m_strSpecific = "";
        private List<CAlarmeACreer> m_listeAlarmesACreer = new List<CAlarmeACreer>();
        private CEntiteSnmpPourSupervision m_entiteAssociee = null;

        private CTrapHandler m_trapHandler = null;
        private CInterrogateurSnmp m_interrogateurSNMP = null;
        private CAgentSnmpPourSupervision m_agentSNMP = null;
        private CMemoryDb m_dbPourAlarmes = new CMemoryDb();


        //-----------------------------------------------
        public CTrapInstance(CInterrogateurSnmp snmpAgent)
        {
            m_interrogateurSNMP = snmpAgent;
            m_dbPourAlarmes.EnforceConstraints = false;
            m_dbPourAlarmes.AddFournisseurElementsManquants(CServiceMediation.GetDefaultInstance().Configuration);
        }

        //-----------------------------------------------
        public CMemoryDb DbPourAlarmes
        {
            get
            {
                return m_dbPourAlarmes;
            }
        }

        //-----------------------------------------------
        [DynamicField("Entreprise")]
        public string Entreprise
        {
            get
            {
                return m_strEntreprise;
            }
            set
            {
                m_strEntreprise = value;
            }
        }

        //-----------------------------------------------
        [DynamicField("Version")]
        public int Version_Code
        {
            get
            {
                return (int)Version;
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
        public CInterrogateurSnmp InterrogateurSNMP
        {
            get
            {
                return m_interrogateurSNMP;
            }
        }

        //-----------------------------------------------
        public IEnumerable<CTrapFieldValueBrute> ValeursVariables
        {
            get{
                return m_listeValues.AsReadOnly();
            }
        }

        //-----------------------------------------------
        public void AddValue ( CTrapFieldValueBrute value )
        {
            m_listeValues.Add ( value );
        }

        //-----------------------------------------------
        [DynamicMethod("Returns a field value as a string from trap detail","variable OID")]
        public string GetTrapFieldValueString(string strOID)
        {
            foreach (CTrapFieldValueBrute t in m_listeValues)
                if (t.OID.StartsWith(strOID))
                    return t.Value.ToString();
            return null;
        }

        //-----------------------------------------------
        public string GetValeurSupplementaire(string strIdChamp)
        {
            string strVal = "";
            m_listeValeursSupplementaires.TryGetValue(strIdChamp, out strVal);
            return strVal;
        }

        //-----------------------------------------------
        public void SetValeurSupplementaire(string strIdChamp, string strValeur)
        {
            m_listeValeursSupplementaires[strIdChamp] = strValeur;
        }

        //-----------------------------------------------
        [DynamicField("Snmp agent")]
        public CAgentSnmpPourSupervision AgentSnmp
        {
            get
            {
                return m_agentSNMP;
            }
            set
            {
                m_agentSNMP = value;
            }
        }


        //-----------------------------------------------
        [DynamicField("Agent Ip")]
        public string AgentIp
        {
            get
            {
                return m_strAgentIP;
            }
            set
            {
                m_strAgentIP = value;
            }
        }

        //-----------------------------------------------
        [DynamicField("Community")]
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
        [DynamicField("Generic code")]
        public int GenericCodeInt
        {
            get
            {
                return (int)m_genericCode;
            }
        }

        //-----------------------------------------------
        [DynamicField("Associated entity")]
        public CEntiteSnmpPourSupervision EntiteAssociee
        {
            get
            {
                return m_entiteAssociee;
            }
            set
            {
                m_entiteAssociee = value;
            }
        }

        //-----------------------------------------------
        public GenericCode GenericCode
        {
            get
            {
                return m_genericCode;
            }
            set
            {
                m_genericCode = value;
            }
        }

        //-----------------------------------------------
        [DynamicField("Specific")]
        public string SpecificValue
        {
            get
            {
                return m_strSpecific;
            }
            set
            {
                m_strSpecific = value;
            }
        }

        //-----------------------------------------------
        public static CTrapInstance FromMessage(
            ISnmpMessage message, 
            CAgentSnmpPourSupervision agentPourSupervision)
        {
            TrapV1Message trapV1 = message as TrapV1Message;
            TrapV2Message trapV2 = message as TrapV2Message;
            InformRequestMessage inform = message as InformRequestMessage;
            if (trapV1 != null)
            {
                CInterrogateurSnmp agent = new CInterrogateurSnmp();
                agent.ConnexionIp = trapV1.AgentAddress.ToString();
                agent.Connexion.Version = trapV1.Version;
                agent.ConnexionCommunity = trapV1.Community.ToString();
                agent.ConnexionPort = 161;
                if (agentPourSupervision != null && agentPourSupervision.TypeAgent != null)
                    agentPourSupervision.TypeAgent.PrepareDynamicSnmpAgent(agent);

                CTrapInstance instance = new CTrapInstance(agent);
                instance.m_strEntreprise = trapV1.Enterprise.ToString();
                instance.m_version = trapV1.Version;
                instance.m_strAgentIP = trapV1.AgentAddress.ToString();
                instance.m_strCommunity = trapV1.Community.ToString();
                instance.GenericCode = trapV1.Generic;
                instance.SpecificValue = trapV1.Specific.ToString();
                instance.AgentSnmp = agentPourSupervision;
                foreach (Variable variable in trapV1.Variables())
                {
                    CTrapFieldValueBrute valeur = new CTrapFieldValueBrute(variable.Id.ToString(), variable.Data.ToString());
                    instance.AddValue(valeur);
                }
                return instance;
            }
            else if (trapV2 != null)
            {
                CInterrogateurSnmp agent = new CInterrogateurSnmp();
                if (trapV2.SenderIP == null)
                    return null;
                agent.ConnexionIp = trapV2.SenderIP.ToString();
                agent.Connexion.Version = trapV2.Version;
                string strCommunauté = "";
                if (trapV2.Parameters != null)
                {
                    if (trapV2.Parameters.UserName != null)
                    {
                        strCommunauté = trapV2.Parameters.UserName.ToString();
                    }
                }
                agent.ConnexionCommunity = strCommunauté;
                agent.ConnexionPort = 161;
                if (agentPourSupervision != null && agentPourSupervision.TypeAgent != null)
                    agentPourSupervision.TypeAgent.PrepareDynamicSnmpAgent(agent);

                CTrapInstance instance = new CTrapInstance(agent);
                instance.m_strEntreprise = trapV2.Enterprise.ToString();
                instance.m_strAgentIP = trapV2.SenderIP.ToString();
                instance.m_version = trapV2.Version;
                instance.m_strCommunity = strCommunauté;
                if ( trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.1")
                    instance.GenericCode = GenericCode.ColdStart;
                else if ( trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.2")
                    instance.GenericCode = GenericCode.WarmStart;
                else if ( trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.3")
                    instance.GenericCode = GenericCode.LinkDown;
                else if ( trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.4")
                    instance.GenericCode = GenericCode.LinkUp;
                else if ( trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.5")
                    instance.GenericCode = GenericCode.AuthenticationFailure;
                else if (trapV2.Enterprise.ToString() == ".1.3.6.1.6.3.1.1.5.6")
                    instance.GenericCode = GenericCode.EgpNeighborLoss;
                else
                {
                    instance.GenericCode = GenericCode.EnterpriseSpecific;
                    int nPos = instance.m_strEntreprise.LastIndexOf(".");
                    if (nPos >= 0)
                    {
                        instance.m_strSpecific = instance.m_strEntreprise.Substring(nPos + 1);
                        instance.m_strEntreprise = instance.m_strEntreprise.Substring(0, nPos);
                    }
                }
                instance.AgentSnmp = agentPourSupervision;
                foreach (Variable variable in trapV2.Variables())
                {
                    CTrapFieldValueBrute valeur = new CTrapFieldValueBrute(variable.Id.ToString(), variable.Data.ToString());
                    instance.AddValue(valeur);
                }
                return instance;
            }
            return null;
        }

        //----------------------------------------------------
        public CTrapHandler CurrentTrapHandler
        {
            get{
                return m_trapHandler;
            }
            set{
                m_trapHandler = value;
            }
        }

        //----------------------------------------------------
        public IEnumerable<CAlarmeACreer> AlarmesACreer
        {
            get{
                return m_listeAlarmesACreer.ToArray();
            }
        }

        //----------------------------------------------------
        /// <summary>
        /// Launch an alarm creator with specified Code
        /// </summary>
        /// <param name="strCodeCreateur"></param>
        /// <param name="nCondition"></param>
        [DynamicMethod("Create alarm from creator with specified code", "Alarm creator code",
            "Create alarm condition\r\n0 = always\r\n1 = No active parent\r\n2 = Exists active parent")]
        public void AddAlarm(string strCodeCreateur, int nCondition)
        {
            AddAlarm ( strCodeCreateur, nCondition, null );
        }

        public void AddAlarm ( string strCodeCreateur, int nCondition, CFuturocomTrace trace )
        {
            CCreateurAlarme createur  = m_trapHandler.GetCreateur(strCodeCreateur);
            if ( createur != null )
            {
                CLocalTypeAlarme typeAl = createur.TypeAlarme;
                if (typeAl != null)
                {
                    CLocalAlarme alarme = new CLocalAlarme(m_dbPourAlarmes);
                    alarme.CreateNew();
                    alarme.TypeAlarme = typeAl;
                    alarme.EntiteDeclencheuse = EntiteAssociee;
                    alarme.EtatCode = typeAl.EtatDefaut;
                    CResultAErreur result = createur.FillAlarm(this, alarme);
                    if (!result && trace != null)
                    {
                        trace.Write("Creator fill alarm error " + result.Erreur.ToString(), ALTRACE.DEBUG);
                    }
                    if (m_listeAlarmesACreer.FirstOrDefault(ac => ac.Alarme.GetKey() == alarme.GetKey()) == null)
                    {
                        CAlarmeACreer create = new CAlarmeACreer(alarme, (EOptionCreationAlarme)nCondition);
                        m_listeAlarmesACreer.Add(create);
                    }
                }
                else if (trace != null)
                    trace.Write(createur.Libelle + " alarm type is null");
                        
            }
            else
            {
                if (trace != null)
                    trace.Write(
                        "Can not find creator " + strCodeCreateur,
                        ALTRACE.DEBUG);
            }
        }
    }
}
