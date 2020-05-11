using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.alarme
{
    [Serializable]
    public class CTrapFieldValueAvecIndex
    {
        private string m_strValue = "";
        private string m_strIndex = "";

        //-------------------------------------
        public CTrapFieldValueAvecIndex()
        {
        }

        //-------------------------------------
        public CTrapFieldValueAvecIndex(string strIndex, string strValue)
        {
            m_strIndex = strIndex;
            m_strValue = strValue;
        }

        //-------------------------------------
        [DynamicField("Index")]
        public string Index
        {
            get
            {
                return m_strIndex;
            }
            set
            {
                m_strIndex = value;
            }
        }

        //-------------------------------------
        [DynamicField("Value")]
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
