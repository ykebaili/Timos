using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.Messaging;
using futurocom.snmp;
using System.Net;
using System.Data;
using futurocom.snmp.Mib;

namespace futurocom.easyquery.snmp
{
    public class CSnmpTableFiller : ITableFiller
    {
        private string m_strIp = "";
        private string m_strCommunaute = "";
        private int m_nPort = 161;

        public CSnmpTableFiller ( string strIp, string strCommunaute, int nPort )
        {
            m_strIp = strIp;
            m_strCommunaute = strCommunaute;
            m_nPort = nPort;
        }

        public bool CanFill(ITableDefinition tableDefinition)
        {
            return typeof(CTableDefinitionSNMP).IsAssignableFrom ( tableDefinition.GetType() );
        }

        public System.Data.DataTable GetData(ITableDefinition tableDefinition)
        {
            DataTable result = null;
            CTableDefinitionSNMP tableSNMP = tableDefinition as CTableDefinitionSNMP;
            if (tableSNMP != null)
            {
                result = Messenger.ReadTable(VersionCode.V2,
                                new IPEndPoint(IPAddress.Parse(m_strIp), m_nPort),
                                new OctetString(m_strCommunaute),
                                new ObjectIdentifier(tableSNMP.OID),
                                1000);
                if (result != null)
                {
                    foreach (DataColumn col in result.Columns)
                    {

                        IColumnDefinition colSNMP = tableDefinition.Columns.FirstOrDefault(
                                                    c => c is CColumnDefinitionSNMP &&
                                                        ((CColumnDefinitionSNMP)c).OIDString == col.ColumnName);
                        if (colSNMP != null)
                            col.ColumnName = colSNMP.ColumnName;
                    }
                }
            }
            return result;
        }

        public object GetValue(string strOID)
        {
            object retour = null;
            try
            {
                List<Variable> lst = new List<Variable>();
                lst.Add(new Variable(ObjectIdentifier.Convert(strOID+".0")));
                IList<Variable> lstRetour = Messenger.Get(VersionCode.V2,
                                new IPEndPoint(IPAddress.Parse(m_strIp), m_nPort),
                                new OctetString(m_strCommunaute),
                                lst,
                                1000);
                if (lstRetour.Count > 0)
                {
                    Variable var = lstRetour.FirstOrDefault(v => v.Id.ToString() == strOID+".0");
                    if (var != null)
                        retour = var.Data != null ? var.Data.ToString() : "";
                }
            }
            catch ( Exception e )
            {
            }
            return retour;
        }
    }
}
