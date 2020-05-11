using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDynamicSnmpRow
    {
        private CDynamicSnmpTable m_table = null;
        private int m_nIndex = 0;

        public CDynamicSnmpRow(CDynamicSnmpTable table, int nIndex)
        {
            m_table = table;
            m_nIndex = nIndex;
        }

        public CDynamicSnmpTable DynamicTable
        {
            get
            {
                return m_table;
            }
        }

        public string GetValue(string strColonne)
        {
            DataTable table = m_table.GetTable();
            string strVal = "";
            if (table != null && table.Rows.Count > m_nIndex && m_nIndex >= 0 && table.Columns.Contains ( strColonne ))
            {
                DataRow row = table.Rows[m_nIndex];
                object val = row[strColonne];
                strVal = val == DBNull.Value ? "" : val.ToString();
            }
            return strVal;
        }

        public void SetValue(string strColonne, object valeur)
        {
            string strIndex = GetValue("Index");
            if (strIndex.Length > 0)
            {
                string strOid = strColonne;
                if (strOid[strColonne.Length - 1] != '.')
                    strOid += ".";
                strOid += strIndex;
                m_table.DynamicMib.Connexion.Set(ObjectIdentifier.Convert(strOid), valeur);
            }
        }
            
    }
}
