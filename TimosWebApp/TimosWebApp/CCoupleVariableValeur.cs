using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace TimosWebApp
{
    public class CCoupleVariableValeur : I2iSerializable
    {
        public CMemoryVariable m_variable;
        public string m_strValeur;

        public CCoupleVariableValeur()
        {
        }

        public CCoupleVariableValeur(CMemoryVariable var, string val)
        {
            Variable = var;
            Valeur = val;
        }

        public CMemoryVariable Variable
        {
            get
            {
                return m_variable;
            }
            set
            {
                m_variable = value;
            }
        
        }
        public string Valeur
        {
            get
            {
                return m_strValeur;
            }
            set
            {
                m_strValeur = value;
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

            serializer.TraiteObject<CMemoryVariable>(ref m_variable);
            serializer.TraiteString(ref m_strValeur);
            

            return result;
        }
    }
}
