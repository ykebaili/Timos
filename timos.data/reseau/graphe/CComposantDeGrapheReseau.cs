using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace timos.data.reseau.graphe
{
    public abstract class CComposantDeGrapheReseau : IComposantDeGrapheReseau
    {
        private object m_externalData = null;

        private int m_nIdSchemaReseau;
        private int m_nIdObjet;

        public CComposantDeGrapheReseau(int nIdObjet, int nIdSchemaReseau)
        {
            m_nIdObjet = nIdObjet;
            m_nIdSchemaReseau = nIdSchemaReseau;
        }

        public int IdSchemaReseau
        {
            get
            {
                return m_nIdSchemaReseau;
            }
        }

        public int IdObjet
        {
            get
            {
                return m_nIdObjet;
            }
        }

        public object ExtrenalData
        {
            get
            {
                return m_externalData;
            }
            set
            {
                m_externalData = value;
            }
        }

        internal static int CalcHashCode(Type typeNoeud, int nIdObjet, int nIdSchemaReseau)
        {
            return (typeNoeud.ToString() + (nIdSchemaReseau * 1000000 + nIdObjet).ToString()).GetHashCode();
        }

        public override int GetHashCode()
        {
            return CalcHashCode(GetType(), IdObjet, IdSchemaReseau);
        }

        public abstract IElementDeSchemaReseau GetElementAssocie(CContexteDonnee contexte);

    }
}
