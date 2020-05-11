using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using futurocom.snmp.expression;

namespace futurocom.snmp.dynamic
{
    [Serializable]
    public class CDynamicSnmpTable
    {
        private uint[] m_oid;
        private CInterrogateurSnmp m_mibDynamique = null;

        public CDynamicSnmpTable(CInterrogateurSnmp dynamicMib, uint[] oid)
        {
            m_oid = oid;
            m_mibDynamique = dynamicMib;
        }

        public uint[] OID
        {
            get
            {
                return m_oid;
            }
        }

        public CInterrogateurSnmp DynamicMib
        {
            get
            {
                return m_mibDynamique;
            }
        }

        public DataTable GetTable()
        {
            return m_mibDynamique.GetTable(OID);
        }

        public void Refresh()
        {
            m_mibDynamique.RefreshTable(OID);
        }
    }
}
