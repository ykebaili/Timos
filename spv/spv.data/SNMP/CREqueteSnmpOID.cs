using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using sc2i.data;

namespace spv.data.SNMP
{
    [Serializable]
    public class CRequeteSnmpOID : CRequeteSNMP
    {
        private string m_strOid;
        private string m_strType;

        public CRequeteSnmpOID()
            : base()
        {
        }

        public CRequeteSnmpOID(string strIpAgent,
            string strCommunity,
            string strOID,
            string strType)
            : base(strIpAgent, strCommunity)
        {
            m_strOid = strOID;
            m_strType = strType;
        }

        public CRequeteSnmpOID(string strIpAgent,
            string strCommunity,
            string strOID)
            : base(strIpAgent, strCommunity)
        {
            m_strOid = strOID;
        }

        public string OID
        {
            get
            {
                return m_strOid;
            }
            set
            {
                m_strOid = value;
            }
        }

        public string Type
        {
            get
            {
                return m_strType;
            }
            set
            {
                m_strType = value;
            }
        }

        public override string GetOID( CContexteDonnee contexte)
        {
            return OID;
        }

        public override string GetType(CContexteDonnee contexte)
        {
            return Type;
        }

        internal override string GetDescriptionVariableSNMP()
        {
            return I.T("OID @1|20002", OID);
        }

        public override CResultAErreur GetRequeteSNMPOID(CContexteDonnee contexte)
        {
            CResultAErreur result = CResultAErreur.True;
            result.Data = this;
            return result;
        }

    }
}
