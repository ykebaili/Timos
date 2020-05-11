using System;
using System.Collections.Generic;
using System.Text;

namespace timos.data.reseau.graphe
{
    public class CCheminDeGrapheReseau
    {
        public Dictionary<CNoeudDeGrapheReseau, bool> m_dicNoeudsUtilises = new Dictionary<CNoeudDeGrapheReseau, bool>();

        public CBaseElementsDeGraphe<CLienDeGrapheReseau> m_baseLiens = new CBaseElementsDeGraphe<CLienDeGrapheReseau>();

        public bool Contains(CNoeudDeGrapheReseau noeud)
        {
            return m_dicNoeudsUtilises.ContainsKey(noeud);
        }

        public static CCheminDeGrapheReseau operator +(CCheminDeGrapheReseau chemin, CLienDeGrapheReseau lien)
        {
            List<CLienDeGrapheReseau> lst = new List<CLienDeGrapheReseau>(chemin.Liens);
            Dictionary<CNoeudDeGrapheReseau, bool> dicNoeuds = new Dictionary<CNoeudDeGrapheReseau, bool>(chemin.m_dicNoeudsUtilises);
            lst.Add(lien);
            dicNoeuds[lien.NoeudArrive] = true;
            dicNoeuds[lien.NoeudDepart] = true;
            CCheminDeGrapheReseau newChemin = new CCheminDeGrapheReseau();
            newChemin.m_baseLiens.AddRange(lst);
            newChemin.m_dicNoeudsUtilises = dicNoeuds;
            return newChemin;
        }

        public CNoeudDeGrapheReseau[] NoeudsUtilises
        {
            get
            {
                List<CNoeudDeGrapheReseau> lst = new List<CNoeudDeGrapheReseau>();
                foreach (CNoeudDeGrapheReseau noeud in m_dicNoeudsUtilises.Keys)
                    lst.Add(noeud);
                return lst.ToArray();
            }
        }

        public CLienDeGrapheReseau[] Liens
        {
            get
            {
                return m_baseLiens.ToArray();
            }
        }

    }
}
