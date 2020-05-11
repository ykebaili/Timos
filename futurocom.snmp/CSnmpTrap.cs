using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using System.Net;
using futurocom.snmp.Mib;
using sc2i.expression;

namespace futurocom.snmp
{
    [Serializable]
    [DynamicClass("Snmp Trap")]
    public class CSnmpTrap
    {
        private VersionCode m_versionCode = VersionCode.V1;
        private IPAddress m_ipAgent ;
        private string m_strCommunaute = "public";
        private ObjectIdentifier m_entreprise = null;
        private GenericCode m_genericCode = GenericCode.EnterpriseSpecific;
        private int m_nSpecificCode = 0;
        private DateTime m_DateTime = DateTime.Now;

        private Dictionary<ObjectIdentifier, object> m_dicValeursVariables = new Dictionary<ObjectIdentifier, object>();

        //------------------------------------------------------------------------------
        public CSnmpTrap()
        {
        }

        //------------------------------------------------------------------------------
        public VersionCode VersionCode
        {
            get
            {
                return m_versionCode;
            }
            set
            {
                m_versionCode = VersionCode;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Version de trap.
        /// </summary>
        /// <remarks>
        /// Les valeurs possibles sont 
        /// <LI>0 = V1</LI>
        /// <LI>1 = V2</LI>
        /// <LI>2 = V2U</LI>
        /// <LI>3 = V3</LI>
        /// </remarks>
        [DynamicField("Version code")]
        public int VersionCodeInt
        {
            get
            {
                return (int)VersionCode;
            }
            set
            {
                try
                {
                    VersionCode = (VersionCode)value;
                }
                catch { }
            }
        }

        //---------------------------------------------------------
        public IPAddress IpAgent
        {
            get{return m_ipAgent;
            }
            set{
                m_ipAgent = value;
            }
        }


        //---------------------------------------------------------
        /// <summary>
        /// IP de l'agent source du trap
        /// </summary>
        [DynamicField("Agent IP")]
        public string AgentIpString
        {
            get
            {
                if ( m_ipAgent != null )
                    return m_ipAgent.ToString();
                return "";
            }
            set
            {
                if ( value != null && value.Length > 0 )
                {
                    try{
                        m_ipAgent = IPAddress.Parse ( value );
                    }
                    catch{}
                }
                else 
                    m_ipAgent = null;
            }
        }

        //---------------------------------------------------------
        [DynamicField("Community")]
        public string Communaute
        {
            get{
                return m_strCommunaute;
            }
            set{m_strCommunaute = value;
            }
        }

        //---------------------------------------------------------
        public ObjectIdentifier EntrepriseOID
        {
            get
            {
                return m_entreprise;
            }
            set
            {
                m_entreprise = value;
            }
        }

        //---------------------------------------------------------
        [DynamicField("Entreprise OID")]
        public string EntrepriseOIDString
        {
            get
            {
                try
                {
                    return EntrepriseOID.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    EntrepriseOID = new ObjectIdentifier(value);
                }
                catch { }
            }
        }

        //-------------------------------------------------------------
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

        //-------------------------------------------------------------
        /// <summary>
        /// code généric du trap. 
        /// </summary>
        /// /// <remarks>
        /// Les valeurs possibles sont 
        /// <LI>0 = Cold start</LI>
        /// <LI>1 = Warm start</LI>
        /// <LI>2 = Link down</LI>
        /// <LI>3 = Link up</LI>
        /// <LI>4 = Authentication Failure</LI>
        /// <LI>5 = EgpNeighborLoss</LI>
        /// <LI>6 = Entreprise specific</LI>
        /// </remarks>
        [DynamicField("Generic code")]
        public int GenericCodeInt
        {
            get
            {
                return (int)GenericCode;
            }
            set
            {
                try
                {
                    GenericCode = (GenericCode)value;
                }
                catch { }
            }
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Code spécific du trap
        /// </summary>
        [DynamicField("Specific code")]
        public int SpecificCode
        {
            get
            {
                return m_nSpecificCode;
            }
            set
            {
                m_nSpecificCode = value;
            }
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Date/heure de déclenchement du trap
        /// </summary>
        [DynamicField("Trap Date Time")]
        public DateTime TrapDateTime
        {
            get
            {
                return m_DateTime;
            }
            set
            {
                m_DateTime = value;
            }
        }

        //-----------------------------------------------------------------
        public IEnumerable<KeyValuePair<ObjectIdentifier, object>> ValeursVariables
        {
            get
            {
                List<KeyValuePair<ObjectIdentifier, object>> lst = new List<KeyValuePair<ObjectIdentifier, object>>();
                foreach (KeyValuePair<ObjectIdentifier, object> kv in m_dicValeursVariables)
                    lst.Add(kv);
                return lst.ToArray();
            }
            set
            {
                Dictionary<ObjectIdentifier, object> dic = new Dictionary<ObjectIdentifier, object>();
                if (value != null)
                {
                    foreach (KeyValuePair<ObjectIdentifier, object> kv in value)
                    {
                        if (kv.Key != null)
                            dic[kv.Key] = kv.Value;
                    }
                }
                m_dicValeursVariables = dic;
            }
        }

        //-----------------------------------------------------------------
        [DynamicMethod("Returns variable value for OID", "OID")]
        public object GetVariableValue ( string strOID )
        {
            try{
                ObjectIdentifier oid = new ObjectIdentifier ( strOID);
                object valeur = null;
                m_dicValeursVariables.TryGetValue ( oid, out valeur );
                return valeur;
            }
            catch{}
            return null;
        }

        //-----------------------------------------------------------------
        [DynamicMethod("Set variable value for OID", "OID", "Value")]
        public void SetVariableValue(string strOID, object value)
        {
            try
            {
                ObjectIdentifier oid = new ObjectIdentifier(strOID);
                m_dicValeursVariables[oid] = value;
            }
            catch { }
        }

        //-----------------------------------------------------------------
        [DynamicMethod("Send trap", "Receiver IP", "Receiver port")]
        public bool SendTrap(string strReceiverIP, int nReceiverPort)
        {
            try
            {
                SendTrapUnsafe(strReceiverIP, nReceiverPort);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Envoi de trap : " + e.ToString());
            }
            return false;
        }

        //--------------------------------------------------------------------
        public void SendTrapUnsafe(string strReceiverIP, int nReceiverPort)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(strReceiverIP), nReceiverPort);
            List<Variable> lstVariables = new List<Variable>();
            foreach (KeyValuePair<ObjectIdentifier, object> kv in m_dicValeursVariables)
            {
                
                ISnmpData data = null;
                if ( kv.Value is ISnmpData )
                    data = (ISnmpData)kv.Value;
                else
                    data = AbstractTypeAssignment.GetSnmpFromDotNet(kv.Value);
                if (data != null)
                    lstVariables.Add(new Variable(kv.Key, data));
            }

            Messaging.Messenger.SendTrapV1(endPoint,
                IpAgent,
                new OctetString(m_strCommunaute),
                EntrepriseOID,
                GenericCode,
                SpecificCode,
                0,
                lstVariables);
        }

        //--------------------------------------------------------------------
        public string GetStringFormuleCreation()
        {
            StringBuilder bl = new StringBuilder();
            bl.Append("begin(");
            bl.Append(Environment.NewLine);
            bl.Append("var(trap;\"CSnmpTrap\");");
            bl.Append(Environment.NewLine);
            bl.Append("trap := CreateEntity (\"CSnmpTrap\");");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Agent_Ip := \""+AgentIpString+"\";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Community:=\"" + Communaute + "\";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Generic_code:=" + GenericCodeInt + ";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Version_code := "+VersionCodeInt+";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Entreprise_OID:=\""+EntrepriseOIDString+"\";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.Specific_code:=" + SpecificCode + ";");
            bl.Append(Environment.NewLine);
            bl.Append("trap.TrapDateTime:=DateTime(\""+TrapDateTime.ToString("yyyy/MM/dd HH:mm:ss")+"\");");
            bl.Append(Environment.NewLine);
            foreach (KeyValuePair<ObjectIdentifier, object> kv in m_dicValeursVariables)
            {
                object data = kv.Value;
                if (data != null)
                {
                    string strOID = kv.Key.ToString();
                    bl.Append("trap.SetVariableValue(\"");
                    bl.Append(strOID);
                    bl.Append("\";");
                    if (data is ISnmpData)
                    {
                        bl.Append("ConvertToSnmpValue(" + (int)((ISnmpData)data).TypeCode + ";\"");
                        bl.Append(data.ToString());
                        bl.Append("\")");
                    }
                    else
                    {
                        bl.Append("\"");
                        bl.Append(data.ToString());
                        bl.Append("\"");
                    }
                    bl.Append(");");
                    bl.Append(Environment.NewLine);
                }
            }
            while (bl[bl.Length - 1] != ';')
                bl.Remove(bl.Length - 1, 1);
            bl.Remove(bl.Length - 1, 1);
            bl.Append(Environment.NewLine);
            bl.Append(")");
            return bl.ToString();
        }

    }
}
