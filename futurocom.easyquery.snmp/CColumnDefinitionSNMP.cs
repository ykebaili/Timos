using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using futurocom.snmp;
using sc2i.common;

namespace futurocom.easyquery.snmp
{
    public class CColumnDefinitionSNMP : CColumnDefinitionSimple
    {
        private uint[] m_nOid;

        //---------------------------------------------------
        public CColumnDefinitionSNMP()
            :base()
        {
        }

        //---------------------------------------------------
        public uint[] OID
        {
            get
            {
                return m_nOid;
            }
            set
            {
                m_nOid = value;
            }
        }

        //---------------------------------------------------
        public string OIDString
        {
            get
            {
                try
                {
                    return ObjectIdentifier.Convert(OID);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    OID = ObjectIdentifier.Convert(value);
                }
                catch
                {
                }
            }
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //---------------------------------------------------
        public override CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (result)
                result = base.Serialize(serializer);
            if (!result)
                return result;
            string strOID = OIDString;
            serializer.TraiteString(ref strOID);
            OIDString = strOID;

            return result;
        }


        //---------------------------------------------------
        public static CColumnDefinitionSNMP FromDefinition(IDefinition definition)
        {
            CColumnDefinitionSNMP col = new CColumnDefinitionSNMP();
            col.ColumnName = definition.Name;
            col.OID = definition.GetNumericalForm();
            col.DataType = typeof(string);
            return col;
        }
    }
}
