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
    public class CSnmpTableFiller : ITableFiller
    {
        CInterrogateurSnmp m_agent = null;
        //---------------------------------------
        public CSnmpTableFiller ( CInterrogateurSnmp agent )
        {
            m_agent = agent;
        }

        //---------------------------------------
        public CInterrogateurSnmp Agent
        {
            get
            {
                return m_agent;
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
            if (m_agent != null && table is CTableDefinitionSNMP)
                m_agent.ClearCache(((CTableDefinitionSNMP)table).OID);
        }

        //---------------------------------------
        public DataTable GetData(ITableDefinition tableDefinition, params string[] strIdsColonnesSource)
        {
            CTableDefinitionSNMP tableSNMP = tableDefinition as CTableDefinitionSNMP;
            if (tableSNMP != null && m_agent != null)
            {
                return GetTableSnmp(tableSNMP, strIdsColonnesSource);
            }

            CTableDefinitionSnmpOfScalar tableScalars = tableDefinition as CTableDefinitionSnmpOfScalar;
            if (tableScalars != null && m_agent != null)
            {
                return GetTableScalars(tableScalars, strIdsColonnesSource);
            }

            return null;
        }

        //---------------------------------------
        private DataTable GetTableSnmp(CTableDefinitionSNMP tableSNMP, params string[] strIdsColonnesSource)
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
            DataTable table = m_agent.GetTable(tableSNMP.OID, lstCols.ToArray());
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
                TimeSpan sp = DateTime.Now - dt;
                System.Console.WriteLine("Get snmp table :" + sp.TotalMilliseconds.ToString());
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
                lstRetour = m_agent.Get(lstVariables);
            else
            {
                foreach ( Variable v in lstVariables )
                {
                    object res = m_agent.Get ( v.Id.ToString() );
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
                row[kv.Key] = kv.Value;
            table.Rows.Add(row);
            return table;

        }

        //------------------------------------------------------
        public object GetValue(string strOID)
        {
            try
            {
                if (m_agent != null)
                {
                    return m_agent.Get(strOID);
                }
            }
            catch
            {
            }
            return null;
        }
    }
}
