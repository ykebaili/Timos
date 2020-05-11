using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.snmp.alarme
{
    //Définition d'un champ apparaissant dans un trap
    [Serializable]
    public class CTrapFieldSupplementaire : I2iSerializable
    {
        private string m_strName = "";
        private string m_strId = "";


        //----------------------------------------------
        public CTrapFieldSupplementaire()
        {
            m_strId = Guid.NewGuid().ToString();
        }

        //----------------------------------------------
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

        //----------------------------------------------
        public string Id
        {
            get
            {
                return m_strId;
            }
            set
            {
                m_strId = value;
            }
        }

        //----------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //----------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteString(ref m_strId);
            serializer.TraiteString(ref m_strName);
            return result;
        }

    }
}
