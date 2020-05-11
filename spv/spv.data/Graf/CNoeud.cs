using System;
using System.Collections.Generic;
using System.Text;

namespace spv.data.Graphe
{
    public class CNoeud
    {
        private CSpvSite m_site = null;

        public CNoeud(CSpvSite site)
        {
            m_site = site;
        }

        public CSpvSite Site
        {
            get
            {
                return m_site;
            }
        }

        public override int GetHashCode()
        {
            return m_site.Id;
        }

        public override bool Equals(object obj)
        {
            CNoeud noeud = obj as CNoeud;
            if (noeud != null)
                return noeud.m_site.Id == m_site.Id;
            return false;
        }

    }
}
