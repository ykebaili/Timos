using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.data.dynamic;
using sc2i.common;

namespace timos.interventions
{
    [Serializable]
    public class CConfigFenetrePlanification : I2iSerializable
    {
        private string m_strNomFichier = "";

        private List<int> m_listeIdSitesVisibles = new List<int>();
        private List<int> m_listeIdActeursVisibles = new List<int>();
        private List<int> m_listeIdRessourcesVisibles = new List<int>();
        private DateTime m_dateDebut = DateTime.Now;
        private DateTime m_dateFin = DateTime.Now;
        private bool m_bNonPlanifiesOnly = false;
        private bool m_bNonAffectesOnly = false;
        private int? m_nIdListeFiltreInters = null;
        private CFiltreDynamique m_filtreDynamiqueInters = null;
        private string m_strLibelleFiltreInters = "";

        //-------------------------------------------------
        public CConfigFenetrePlanification()
        {
        }

        //-------------------------------------------------
        public string NomFichier
        {
            get
            {
                return m_strNomFichier;
            }
            set
            {
                m_strNomFichier = value;
            }
        }

        //-------------------------------------------------
        public CResultAErreur ReadFile(string strNomFichier)
        {
            CResultAErreur result = CResultAErreur.True;
            result = CSerializerObjetInFile.ReadFromFile(this, "CONFIG_PLANNING", strNomFichier);
            if ( result )
                m_strNomFichier = strNomFichier;
            return result;
        }

        //-------------------------------------------------
        public CResultAErreur SaveFile(string strNomFichier)
        {
            CResultAErreur result = CResultAErreur.True;
            result = CSerializerObjetInFile.SaveToFile(this, "CONFIG_PLANNING", strNomFichier);
            if (result)
                m_strNomFichier = strNomFichier;
            return result;
        }

        //-------------------------------------------------
        public int[] IdsSitesVisibles
        {
            get
            {
                return m_listeIdSitesVisibles.ToArray();
            }
            set
            {
                m_listeIdSitesVisibles.Clear();
                if (value != null)
                {
                    m_listeIdSitesVisibles.AddRange(value);
                }
            }
        }

        //-------------------------------------------------
        public int[] IdsActeursVisibles
        {
            get
            {
                return m_listeIdActeursVisibles.ToArray();
            }
            set
            {
                m_listeIdActeursVisibles.Clear();
                if (value != null)
                    m_listeIdActeursVisibles.AddRange(value);
            }
        }

        //-------------------------------------------------
        public int[] IdsRessourcesVisibles
        {
            get
            {
                return m_listeIdRessourcesVisibles.ToArray();
            }
            set
            {
                m_listeIdRessourcesVisibles.Clear();
                if (value != null)
                    m_listeIdRessourcesVisibles.AddRange(value);
            }
        }

        //-------------------------------------------------
        public DateTime DateDebut
        {
            get
            {
                return m_dateDebut;
            }
            set
            {
                m_dateDebut = value;
            }
        }

        //-------------------------------------------------
        public DateTime DateFin
        {
            get
            {
                return m_dateFin;
            }
            set
            {
                m_dateFin = value;
            }
        }

        //-------------------------------------------------
        public bool NonPlanifiesOnly
        {
            get
            {
                return m_bNonPlanifiesOnly;
            }
            set
            {
                m_bNonPlanifiesOnly = value;
            }
        }

        //-------------------------------------------------
        public bool NonAffectesOnly
        {
            get
            {
                return m_bNonAffectesOnly;
            }
            set
            {
                m_bNonAffectesOnly = value;
            }
        }

        //-------------------------------------------------
        public int? IdListeFiltreInters
        {
            get
            {
                return m_nIdListeFiltreInters;
            }
            set
            {
                m_nIdListeFiltreInters = value;
            }
        }

        //-------------------------------------------------
        public CFiltreDynamique FiltreDynamiqueInters
        {
            get
            {
                return m_filtreDynamiqueInters;
            }
            set
            {
                m_filtreDynamiqueInters = value;
            }
        }

        //-------------------------------------------------
        public string LibelleFiltreInters
        {
            get
            {
                return m_strLibelleFiltreInters;
            }
            set
            {
                m_strLibelleFiltreInters = value;
            }
        }

        //-------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------
        public CResultAErreur Serialize ( C2iSerializer serializer )
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
            if ( !result )
                return result;
            
            serializer.TraiteListeInt(m_listeIdSitesVisibles);
            serializer.TraiteListeInt(m_listeIdActeursVisibles);
            serializer.TraiteListeInt(m_listeIdRessourcesVisibles);
            serializer.TraiteDate ( ref m_dateDebut);
            serializer.TraiteDate(ref m_dateFin);
            serializer.TraiteBool ( ref m_bNonPlanifiesOnly);
            serializer.TraiteBool ( ref m_bNonAffectesOnly);
            serializer.TraiteIntNullable(ref m_nIdListeFiltreInters);
            result = serializer.TraiteObject<CFiltreDynamique>(ref m_filtreDynamiqueInters );
            if ( !result )
                return result;
            serializer.TraiteString(ref m_strLibelleFiltreInters);

            return result;
        }

            






    }
}
