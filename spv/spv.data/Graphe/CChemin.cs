using System;
using System.Collections.Generic;
using System.Text;

namespace spv.data.Graphe
{
    public class CPassageChemin
    {
        private CSpvSite m_siteSource = null;
        private CSpvLiai m_liaiUtilisee = null;
        public CPassageChemin(CSpvSite siteSource, CSpvLiai liaiUtilisee)
        {
            m_siteSource = siteSource;
            m_liaiUtilisee = liaiUtilisee;
        }
        public CSpvSite SiteSource
        {
            get
            {
                return m_siteSource;
            }
        }

        public CSpvLiai LiaisonUtilisee
        {
            get
            {
                return m_liaiUtilisee;
            }
        }
    }

    public class CChemin
    {
        private List<CPassageChemin> m_listePassages = new List<CPassageChemin>();

        public CChemin()
        {
        }

        public CPassageChemin[] Passages
        {
            get
            {
                return m_listePassages.ToArray();
            }
        }

        public static CChemin operator +(CChemin chemin, CPassageChemin passage)
        {
            List<CPassageChemin> lst = new List<CPassageChemin>(chemin.m_listePassages);
            lst.Add(passage);
            CChemin newChemin = new CChemin();
            newChemin.m_listePassages = lst;
            return newChemin;
        }

        public bool PasseParSite(CSpvSite site)
        {
            foreach (CPassageChemin passage in m_listePassages)
            {
                if (site.Id == passage.SiteSource.Id)
                    return true;
            }
            return false;
        }
    }
}
