using sc2i.common;
using sc2i.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportDocsMyanmar
{
    public class CFichier : IElementDeFS
    {
        private string m_strNom;
        private DateTime m_lastModifDate;
        private long m_nSize;
        
        private CDbKey m_keyObjetAssocie = null;
        private Type m_typeObjetAssocie = null;
        private DateTime? m_lastModifDateLorsDeImport = null;
        private string m_strInfoImport = "";

        private CRepertoire m_repertoireContenant = null;
        

        public CFichier()
        {

        }

        public CRepertoire RepertoireContenant
        {
            get
            {
                return m_repertoireContenant;
            }
            set { m_repertoireContenant = value; }
        }

        public string Nom
        {
            get
            {
                return m_strNom;
            }
            set
            {
                m_strNom = value;
            }
        }

        public DateTime LastModifDate
        {
            get
            {
                return m_lastModifDate;
            }
            set
            {
                m_lastModifDate = value;
            }
        }

        public long Size
        {
            get
            {
                return m_nSize;
            }
            set
            {
                m_nSize = value;
            }
        }

        public DateTime? LastModifDateLorsDeImport
        {
            get
            {
                return m_lastModifDateLorsDeImport;
            }
            set
            {
                m_lastModifDateLorsDeImport = value;
            }
        }

        public string InfoImport
        {
            get
            {
                return m_strInfoImport;
            }
            set
            {
                m_strInfoImport = value;
            }
        }

        public CDbKey KeyObjetAssocie
        {
            get
            {
                return m_keyObjetAssocie;
            }
            set
            {
                m_keyObjetAssocie = value;
            }
        }

        public Type TypeObjetAssocie
        {
            get
            {
                return m_typeObjetAssocie;
            }
            set
            {
                m_typeObjetAssocie = value;
            }
        }

        public void SetObjetAssocie (CObjetDonneeAIdNumerique objet)
        {
            if (objet == null)
            {
                KeyObjetAssocie = null;
                TypeObjetAssocie = null;
            }
            else
            {
                KeyObjetAssocie = objet.DbKey;
                TypeObjetAssocie = objet.GetType();
            }
        }

        public void ClearDataImport()
        {
            InfoImport = "";
            SetObjetAssocie(null);
        }

        public bool HasErreurImport()
        {
            return InfoImport.Length > 0;
        }

        private int GetNumVersion()
        {
            return 0;
        }

        public CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteString(ref m_strNom);
            serializer.TraiteDate(ref m_lastModifDate);
            serializer.TraiteLong(ref m_nSize);
            serializer.TraiteDbKey(ref m_keyObjetAssocie);
            serializer.TraiteType(ref m_typeObjetAssocie);
            serializer.TraiteDateTimeNullable(ref m_lastModifDateLorsDeImport);
            serializer.TraiteString(ref m_strInfoImport);
            return result;
        }
    }
}
