using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace TimosWebApp
{
    public class CMemoryVariable : I2iSerializable
    {
        private int m_nId = -1;
        private string m_strName = "";
        private int m_nType = -1;

        
        public CMemoryVariable()
        {

        }

        public int Id
        {
            get
            {
                return m_nId;
            }
            set
            {
                m_nId = value;
            }
        }

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

        public int TypeVariable
        {
            get
            {
                return m_nType;
            }
            set
            {
                m_nType = value;
            }
        }



        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            CResultAErreur result = CResultAErreur.True;
            int nVersion = GetNumVersion();

            result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;

            serializer.TraiteInt(ref m_nId);
            serializer.TraiteString(ref m_strName);
            serializer.TraiteInt(ref m_nType);


            return result;
        }

    }
}
