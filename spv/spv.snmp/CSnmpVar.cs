using System;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.expression;
using spv.data;

namespace spv.snmp
{
    public class CSnmpVar
    {
        private string m_snmpIndex;
        private CSpvMibVariable m_mibVariable;

        private CSnmpVar() { }

        public CSnmpVar(CSpvMibVariable mibVariable, string snmpIndex)
        {
            string mess;

            m_mibVariable = mibVariable;
            m_snmpIndex = snmpIndex;
            if (m_mibVariable == null)
            {
                mess = I.T("Snmp variable not filled|50001");
                throw new Exception (mess);
            }
            if (m_snmpIndex == null || m_snmpIndex.Length == 0)
            {
                mess = I.T("Variable snmp index not filled|50002");
                throw new Exception (mess);
            }
        }
    }
}
