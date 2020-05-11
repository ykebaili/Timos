using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.Messaging;
using futurocom.snmp;
using System.Net;
using System.Data;
using futurocom.snmp.Mib;
using sc2i.common;
using futurocom.snmp.dynamic;
using futurocom.snmp.easyquery;

namespace futurocom.easyquery.snmp
{
    [Serializable]
    [AutoExec("Autoexec")]
    public class CSnmpConnexionForEasyQuery : IEasyQueryConnexion
    {
        public const string c_IdConnexionSNMP = "SNMP";

        public const string c_parametreSnmpIp = "AGENT IP";
        public const string c_parametrePort = "AGENT PORT";
        public const string c_parametreVersion = "SNMP VERSION";
        public const string c_parametreCommunaute = "SNMP COMMUNITY";

        CInterrogateurSnmpSimplePourFiller m_interrogateur = null;
        //---------------------------------------
        public CSnmpConnexionForEasyQuery(CInterrogateurSnmpSimplePourFiller interrogateur)
        {
            m_interrogateur = interrogateur;
        }

        //---------------------------------------
        public CSnmpConnexionForEasyQuery()
        {
        }

        //---------------------------------------
        public static void Autoexec()
        {
            CAllocateurEasyQueryConnexions.RegisterTypeConnexion ( c_IdConnexionSNMP, typeof(CSnmpConnexionForEasyQuery) );
        }

        //---------------------------------------
        public CInterrogateurSnmpSimplePourFiller Agent
        {
            get
            {
                return m_interrogateur;
            }
        }

        //---------------------------------------
        public bool CanFill(ITableDefinition tableDefinition)
        {
            return typeof(CTableDefinitionSNMP).IsAssignableFrom(tableDefinition.GetType()) ||
                typeof(CTableDefinitionSnmpOfScalar).IsAssignableFrom(tableDefinition.GetType());
        }

        //---------------------------------------
        public void ClearCache(ITableDefinition table)
        {
            if (m_interrogateur != null && table is CTableDefinitionSNMP)
                m_interrogateur.ClearCache(((CTableDefinitionSNMP)table).OID);
        }

        //---------------------------------------
        public DataTable GetData(ITableDefinition tableDefinition, params string[] strIdsColonnesSource)
        {
            CTableDefinitionSNMP tableSNMP = tableDefinition as CTableDefinitionSNMP;
            if (tableSNMP != null && m_interrogateur != null)
            {
                return GetTableSnmp(tableSNMP, strIdsColonnesSource);
            }

            CTableDefinitionSnmpOfScalar tableScalars = tableDefinition as CTableDefinitionSnmpOfScalar;
            if (tableScalars != null && m_interrogateur != null)
            {
                return GetTableScalars(tableScalars, strIdsColonnesSource);
            }

            return null;
        }

        //---------------------------------------
        private DataTable GetTableSnmp(CTableDefinitionSNMP tableSNMP, params string[] strIdsColonnesSource)
        {
            List<uint[]> lstCols = new List<uint[]>();
            if (strIdsColonnesSource != null)
            {
                foreach (string strIdCol in strIdsColonnesSource)
                {
                    try
                    {
                        lstCols.Add(ObjectIdentifier.Convert(strIdCol));
                    }
                    catch { }
                }
            }
            DataTable table = m_interrogateur.GetTable(tableSNMP.OID, lstCols.ToArray());
            if (table != null)
            {
                foreach (DataColumn col in table.Columns)
                {
                    IColumnDefinition colSNMP = tableSNMP.Columns.FirstOrDefault(
                                                c => c is CColumnDefinitionSNMP &&
                                                    ((CColumnDefinitionSNMP)c).OIDString == col.ColumnName);
                    if (colSNMP != null)
                        col.ColumnName = colSNMP.ColumnName;
                }
                return table;
            }
            return null;
        }

        //---------------------------------------
        private DataTable GetTableScalars(CTableDefinitionSnmpOfScalar tableScalar, params string[] strIdsColonnesSource)
        {
            DateTime dt = DateTime.Now;
            List<uint[]> lstCols = new List<uint[]>();
            if (strIdsColonnesSource != null)
            {
                foreach (string strIdCol in strIdsColonnesSource)
                {
                    try
                    {
                        lstCols.Add(ObjectIdentifier.Convert(strIdCol));
                    }
                    catch { }
                }
            }

            List<Variable> lstVariables = new List<Variable>();
            if (lstCols.Count == 0)
            {
                foreach (IColumnDefinition col in tableScalar.Columns)
                {
                    CColumnDefinitionSNMP colSnmp = col as CColumnDefinitionSNMP;
                    if (colSnmp != null)
                    {
                        lstVariables.Add(new Variable(ObjectIdentifier.Convert(colSnmp.OIDString+".0")));
                    }
                }
            }
            else foreach (uint[] oid in lstCols)
            {
                lstVariables.Add(new Variable(new ObjectIdentifier(ObjectIdentifier.Convert(oid)+".0")));
            }
            IList<Variable> lstRetour = new List<Variable>();
            if ( tableScalar.RemplissageOptimise )
                lstRetour = m_interrogateur.Get(lstVariables);
            else
            {
                foreach ( Variable v in lstVariables )
                {
                    object res = m_interrogateur.Get ( v.Id.ToString() );
                    if (res is ISnmpData)
                    {
                        Variable vTmp = new Variable(v.Id, res as ISnmpData);
                        lstRetour.Add(vTmp);
                    }
                }
            }


            DataTable table = new DataTable(tableScalar.TableName);
            Dictionary<DataColumn, string> valeurs = new Dictionary<DataColumn, string>();
            foreach (Variable var in lstRetour)
            {
                DataColumn col = new DataColumn();
                IColumnDefinition colSNMP = tableScalar.Columns.FirstOrDefault(
                                                c => c is CColumnDefinitionSNMP &&
                                                    ((CColumnDefinitionSNMP)c).OIDString+".0" == var.Id.ToString());
                if (colSNMP != null)
                    col.ColumnName = colSNMP.ColumnName;
                else
                    col.ColumnName = var.Id.ToString();
                col.DataType = colSNMP.DataType;
                if (!table.Columns.Contains(col.ColumnName))
                    table.Columns.Add(col);
                valeurs[col] = var.Data == null ? "":var.Data.ToString();
            }
            DataRow row = table.NewRow();
            foreach ( KeyValuePair<DataColumn, string> kv in valeurs )
                try
                {
                    row[kv.Key] = kv.Value;
                }
                catch { }
            table.Rows.Add(row);
            return table;

        }

        //------------------------------------------------------
        public object GetValue(string strOID)
        {
            try
            {
                if (m_interrogateur != null)
                {
                    return m_interrogateur.Get(strOID);
                }
            }
            catch
            {
            }
            return null;
        }

        //------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = serializer.TraiteObject<CInterrogateurSnmpSimplePourFiller>(ref m_interrogateur);
            return result;
        }





        #region IEasyQueryConnexion Membres
        //-----------------------------------------------------
        public void ClearStructure()
        {
            //throw new NotImplementedException();
        }
        
        
        //-----------------------------------------------------
        public IEnumerable<CEasyQueryConnexionProperty> ConnexionProperties
        {
            get
            {
                List<CEasyQueryConnexionProperty> lst = new List<CEasyQueryConnexionProperty>();
                if ( m_interrogateur == null )
                    m_interrogateur = new CInterrogateurSnmpSimplePourFiller();
                lst.Add(new CEasyQueryConnexionProperty(c_parametreSnmpIp, m_interrogateur.ConnexionIp));
                lst.Add(new CEasyQueryConnexionProperty(c_parametrePort, m_interrogateur.ConnexionPort.ToString()));
                lst.Add(new CEasyQueryConnexionProperty(c_parametreCommunaute, m_interrogateur.ConnexionCommunity));
                lst.Add(new CEasyQueryConnexionProperty(c_parametreVersion, m_interrogateur.SnmpVersion.ToString()));
                return lst.AsReadOnly();
            }
            set
            {
                foreach ( CEasyQueryConnexionProperty propriete in value )
                    SetConnexionProperty ( propriete.Property, propriete.Value );
            }
        }
        
        //-----------------------------------------------------
        public string ConnexionTypeId
        {
            get { return c_IdConnexionSNMP; }
        }

        //-----------------------------------------------------
        public string ConnexionTypeName
        {
            get { return "SNMP"; }
        }

        //-----------------------------------------------------
        public void FillStructureQuerySource(CEasyQuerySource source)
        {
        }

        //-----------------------------------------------------
        public string GetConnexionProperty(string strProperty)
        {
            string strUpper = strProperty.ToUpper();
            if (m_interrogateur == null)
                m_interrogateur = new CInterrogateurSnmpSimplePourFiller();
            if (strUpper == c_parametreSnmpIp.ToUpper())
                return m_interrogateur.ConnexionIp;
            else if (strUpper == c_parametrePort.ToUpper())
                return m_interrogateur.ConnexionPort.ToString();
            else if (strUpper == c_parametreCommunaute.ToUpper())
                return m_interrogateur.ConnexionCommunity;
            else if (strUpper == c_parametreVersion.ToUpper())
                return m_interrogateur.SnmpVersion.ToString();
            return "";
        }

        //-----------------------------------------------------
        public void SetConnexionProperty(string strProperty, string strValeur)
        {
            string strUpper = strProperty.ToUpper();
            if ( m_interrogateur == null )
                m_interrogateur = new CInterrogateurSnmpSimplePourFiller();
            if (strUpper == c_parametreSnmpIp.ToUpper())
                m_interrogateur.ConnexionIp = strValeur;
            else if (strUpper == c_parametrePort.ToUpper())
            {
                try
                {
                    int nVal = Int32.Parse(strValeur);
                    m_interrogateur.ConnexionPort = nVal;
                }
                catch { }
            }
            else if (strUpper == c_parametreCommunaute.ToUpper())
                m_interrogateur.ConnexionCommunity = strValeur;
            else if (strUpper == c_parametreVersion.ToUpper())
            {
                try
                {
                    int nVal = Int32.Parse(strValeur);
                    m_interrogateur.SnmpVersion = nVal;
                }
                catch { }
            }
        }

        #endregion
    }
}
