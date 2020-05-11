using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;
using futurocom.snmp.Mib;
using System.Net;
using System.Data;
using futurocom.snmp.dynamic;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using futurocom.snmp.entitesnmp;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CInterrogateurSnmpSimplePourFiller : I2iSerializable
    {
        private Dictionary<string, DataTable> m_dicTables = new Dictionary<string, DataTable>();

        [NonSerialized]
        private CSnmpConnexion m_connexion = new CSnmpConnexion();
        protected IDefinition m_rootDefinition = null;

        //------------------------------------------------------------------
        public CInterrogateurSnmpSimplePourFiller()
        {
        }

        //------------------------------------------------------------------
        public CInterrogateurSnmpSimplePourFiller(IDefinition root)
        {
            SetRootDefinition(root);
        }

        //---------------------------------------------------------------
        public void ClearCache(uint[] oid)
        {
            RefreshTable(oid);
        }

        //-------------------------------------------
        public static string CalcRubriqueChamp(IDefinition definition)
        {
            string strRubrique = "";
            IDefinition parent = definition.ParentDefinition;
            while (parent != null)
            {
                strRubrique = parent.Name + "/" + strRubrique;
                parent = parent.ParentDefinition;
            }
            return strRubrique;
        }

        

        //------------------------------------------------------------------
        public void SetRootDefinition(IDefinition root)
        {
            m_rootDefinition = root;
        }

        

        //------------------------------------------------------------------
        public CSnmpConnexion Connexion
        {
            get
            {
                return m_connexion;
            }
            set
            {
                m_connexion = value;
            }
        }

        //------------------------------------------------------------------
        [DynamicMethod("Initialize SNMP connexion","Agent IP","Agent port", "Community","SNMP version (1, 2 or 3)")]
        public void Init(string strIp, int nPort, string strCommunity, int nVersion)
        {
            ConnexionIp = strIp;
            ConnexionPort = nPort;
            ConnexionCommunity = strCommunity;
            SnmpVersion = nVersion;
        }

        //------------------------------------------------------------------
        [DynamicField("Connexion IPAddress")]
        public string ConnexionIp
        {
            get{return m_connexion.EndPoint.Address.ToString();
            }
            set{
                string[] strVals = value.Split('.');
                if ( strVals.Length == 4 )
                {
                    byte[] bts = new Byte[4];
                    try
                    {
                        bts[0] = byte.Parse(strVals[0]);
                        bts[1] = byte.Parse(strVals[1]);
                        bts[2] = byte.Parse(strVals[2]);
                        bts[3] = byte.Parse(strVals[3]);
                        m_connexion.EndPoint = new IPEndPoint(new IPAddress(bts), ConnexionPort);
                    }
                    catch { }
                }
                }
        }

        //------------------------------------------------------------------
        [DynamicField("Connexion port")]
        public int ConnexionPort
        {
            get
            {
                return m_connexion.EndPoint.Port;
            }
            set
            {
                m_connexion.EndPoint.Port = value;
            }
        }

        //------------------------------------------------------------------
        [DynamicField("Connexion community")]
        public string ConnexionCommunity
        {
            get
            {
                return m_connexion.Community;
            }
            set
            {
                m_connexion.Community = value;
            }
        }

        //------------------------------------------------------------------
        [DynamicField("Connexion Snmp version")]
        public int SnmpVersion
        {
            get
            {
                switch (m_connexion.Version)
                {
                    case VersionCode.V1:
                        return 1;
                        break;
                    case VersionCode.V2:
                        return 2;
                        break;
                    case VersionCode.V3: return 3;
                        break;
                    default:
                        return 1;
                        break;
                }
            }
            set
            {
                if (value == 1)
                    m_connexion.Version = VersionCode.V1;
                if (value == 2)
                    m_connexion.Version = VersionCode.V2;
                if (value == 3)
                    m_connexion.Version = VersionCode.V3;
            }
        }

        //---------------------------------------------------------------
        private string GetTableKey(uint[] oid, uint[][] colonnesAPrendre )
        {
            string strKey = "";
            strKey = ConnexionIp+"_"+ConnexionPort+"_"+ObjectIdentifier.Convert ( oid );
            if (colonnesAPrendre != null)
            {
                foreach (uint[] col in colonnesAPrendre)
                    strKey += ObjectIdentifier.Convert(col);
            }
            return strKey;
        }

        //------------------------------------------------------------------
        public DataTable GetTable(uint[] oid, params uint[][] colonnesAPrendre)
        {
            string strKey = GetTableKey(oid, colonnesAPrendre);
            DataTable table = null;
            m_dicTables.TryGetValue(strKey, out table);
            if (table == null)
            {
                try
                {
                    CResultAErreurType<DataTable> resTable = Connexion.GetTable(oid, colonnesAPrendre);
                    if (resTable)
                    {
                        table = resTable.DataType;
                        DataTable copy = table.Clone();
                        foreach (DataRow row in table.Rows)
                            copy.ImportRow(row);

                        m_dicTables[strKey] = copy;
                    }
                }
                catch { }
            }
            else
            {
                DataTable copy = table.Clone();
                foreach (DataRow row in table.Rows)
                    copy.ImportRow(row);
                table = copy;
            }
            return table;
        }

        //---------------------------------------------------------------
        public void RefreshTable(uint[] oid)
        {
            string strKey = GetTableKey(oid, null);
            List<string> lstASupprimer = new List<string>();
            foreach (KeyValuePair<string, DataTable> kv in m_dicTables)
                if (kv.Key.StartsWith(strKey))
                    lstASupprimer.Add(kv.Key);
            foreach ( string strASupprimer in lstASupprimer )
                if (m_dicTables.ContainsKey(strASupprimer))
                    m_dicTables.Remove(strASupprimer);
        }

        //---------------------------------------------------------------
        [DynamicMethod("Get", "OID")]
        public object Get(string strOID)
        {
            try
            {
                uint[] oid = ObjectIdentifier.Convert(strOID);
                CResultAErreurType<Variable> resVar = Connexion.Get(oid);
                if (resVar)
                    return resVar.DataType.Data;
            }
            catch
            {
                
            }
            return null;
        }

        //---------------------------------------------------------------
        public IList<Variable> Get(IList<Variable> lstVariables)
        {
            try
            {
                CResultAErreurType<IList<Variable>> result = Connexion.Get(lstVariables);
                if ( result )
                    return result.DataType;
            }
            catch
            {
            }
            return new List<Variable>();
        }

        //---------------------------------------------------------------
        [DynamicMethod("Set", "OID", "Value")]
        public CResultAErreur Set(string strOID, object value)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                uint[] oid = ObjectIdentifier.Convert(strOID);
                return Connexion.Set(oid, value);
            }
            catch (Exception e )
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }


        //---------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            string strIp = ConnexionIp;
            int nPort = ConnexionPort;
            string strCommunaute = ConnexionCommunity;
            int nVersionSnmp = SnmpVersion;

            serializer.TraiteString(ref strIp);
            serializer.TraiteInt(ref nPort);
            serializer.TraiteString(ref strCommunaute);
            serializer.TraiteInt(ref nVersionSnmp);

            if (serializer.Mode == ModeSerialisation.Lecture)
            {
                ConnexionIp = strIp;
                ConnexionPort = nPort;
                ConnexionCommunity = strCommunaute;
                SnmpVersion = nVersion;
            }
            return result;
        }
    }
}
