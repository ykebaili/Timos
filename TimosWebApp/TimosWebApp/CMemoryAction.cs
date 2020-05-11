using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace TimosWebApp
{
    public class CMemoryAction : I2iSerializable
    {
        private int m_nId = -1;
        private string m_strLabel = "";
        private string m_strType = "";
        private string m_strDescription = "";
        private List<CCoupleVariableValeur> m_listeVariables = new List<CCoupleVariableValeur>();

        public CMemoryAction()
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

        public string Label
        {
            get
            {
                return m_strLabel;
            }
            set
            {
                m_strLabel = value;
            }
        }

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

        public IEnumerable<CCoupleVariableValeur> LiseVariables
        {
            get
            {
                return m_listeVariables;
            }
            set
            {
                m_listeVariables = new List<CCoupleVariableValeur>(value);
            }
        }

        public string TypeAction
        {
            get { return m_strType; }
            set { m_strType = value; }
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
            serializer.TraiteString(ref m_strLabel);
            serializer.TraiteString(ref m_strType);
            serializer.TraiteString(ref m_strDescription);
            result = serializer.TraiteListe<CCoupleVariableValeur>(m_listeVariables);

            return result;
        }

    }
}
