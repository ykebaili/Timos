using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.expression;

namespace futurocom.supervision
{
    [Serializable]
    public class CLocalChampTypeAlarme : CLocalChampTypeAlarme
    {
        private string m_strNomChamp = "";
        private string m_strId = "";
        private ETypeChampBasique m_typeDonnee = ETypeChampBasique.String;
        private bool m_bIsKey = false;

        //------------------------------------------
        public CLocalChampTypeAlarme()
        {
            m_strId = Guid.NewGuid().ToString();
        }

        //------------------------------------------
        public string NomChamp
        {
            get
            {
                return m_strNomChamp;
            }
            set
            {
                m_strNomChamp = value;
            }
        }

        //------------------------------------------
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

        //------------------------------------------
        public ETypeChampBasique TypeDonnee
        {
            get
            {
                return m_typeDonnee;
            }
            set
            {
                m_typeDonnee = value;
            }
        }

        //------------------------------------------
        public bool IsKey
        {
            get
            {
                return m_bIsKey;
            }
            set
            {
                m_bIsKey = value;
            }
        }



        //------------------------------------------
        private int GetNumVersion()
        {
            return 1;
        }

        //------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            serializer.TraiteString ( ref m_strId );
            serializer.TraiteString ( ref m_strNomChamp );
            int nType = (int)m_typeDonnee;
            serializer.TraiteInt ( ref nType );
            m_typeDonnee = (ETypeChampBasique)nType;
            if (nVersion >= 1)
                serializer.TraiteBool(ref m_bIsKey);
            return result;
        }

    }
}
