using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.alarme
{
    //Définition d'un champ apparaissant dans un trap
    [Serializable]
    public class CTrapField : I2iSerializable
    {
        private string m_strOID = "";
        private string m_strName = "";

        public CTrapField()
        {
        }

        [DynamicField("OID")]
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

        [DynamicField("Name")]
        public string Name
        {
            get
            {
                return m_strName;
            }
            set
            {
                m_strName = value;
            }
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteString(ref m_strName );
            serializer.TraiteString ( ref m_strOID );
            return result;
        }

    }
}
