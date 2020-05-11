using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.easyquery;
using futurocom.snmp;
using sc2i.common;
using futurocom.snmp.Mib;

namespace futurocom.easyquery.snmp
{
    [Serializable]
    public class CColumnDefinitionSNMP : CColumnDefinitionSimple
    {
        private uint[] m_nOid;
        private AbstractTypeAssignment m_snmpType = null;
        private bool m_bReadOnly = false;
        private string m_strDescription = "";

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
        public string Description
        {
            get
            {
                return m_strDescription;
            }
            set
            {
                m_strDescription = value;
            }
        }

        //---------------------------------------------------
        public AbstractTypeAssignment SnmpType
        {
            get
            {
                return m_snmpType;
            }
            set
            {
                m_snmpType = value;
            }
        }

        //---------------------------------------------------
        public override Type DataType
        {
            get
            {
                if (SnmpType != null)
                {
                    return SnmpType.GetTypeDotNet();
                }
                return base.DataType;
            }
            set
            {
                base.DataType = value;
            }
        }

        //---------------------------------------------------
        public override bool IsReadOnly
        {
            get
            {
                return m_bReadOnly;
            }
            set
            {
                m_bReadOnly = value;
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
            string strOID = serializer.Mode == ModeSerialisation.Ecriture ? OIDString : "";
            serializer.TraiteString(ref strOID);
            OIDString = strOID;
            
            serializer.TraiteString(ref m_strDescription);
            serializer.TraiteBool(ref  m_bReadOnly);
            
            result = serializer.TraiteObject<AbstractTypeAssignment>(ref m_snmpType);


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
