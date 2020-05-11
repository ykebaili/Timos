using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CTrapFieldValueBrute
    {
        private string m_strOID = "";
        private string m_strValue = "";

        public CTrapFieldValueBrute()
        {
        }

        public CTrapFieldValueBrute(string strOid, string strValue)
        {
            m_strOID = strOid;
            m_strValue = strValue;
        }

        public string OID
        {
            get
            {
                return m_strOID;
            }
            set
            {
                m_strOID = value;
            }
        }

        public string Value
        {
            get
            {
                return m_strValue;
            }
            set
            {
                m_strValue = value;
            }
        }

    
    }
}
