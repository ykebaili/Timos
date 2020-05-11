using System;
using System.Collections.Generic;
using System.Text;
using timos.data;
using System.Collections;

namespace spv.data.Graphe
{
    public class CGraphe
    {
        private List<CNoeud> m_noeuds = new List<CNoeud>();
        private List<CLien> m_liens = new List<CLien>();

        private Dictionary<CSpvSite, CNoeud> m_dicSiteToNoeud = new Dictionary<CSpvSite,CNoeud>();
        private Dictionary<CNoeud, List<CLien>> m_dicLiensSortants = new Dictionary<CNoeud, List<CLien>>();

        public CGraphe()
        {
        }

        public CNoeud GetNoeud ( CSpvSite site )
        {
            CNoeud noeud = null;
            if ( m_dicSiteToNoeud.TryGetValue ( site, out noeud ))
                return noeud;
            return null;
        }

        public void AddNoeud(CNoeud noeud)
        {
            if (!m_noeuds.Contains(noeud))
            {
                m_noeuds.Add(noeud);
                m_dicSiteToNoeud[noeud.Site] = noeud;
            }
        }

        public void AddLien(CLien lien)
        {
            if (!m_liens.Contains(lien))
            {
                m_liens.Add(lien);
                List<CLien> lst = null;
                CNoeud noeud = GetNoeud(lien.Liaison.SiteOrigine);
                if (noeud != null)
                {
                    if (!m_dicLiensSortants.TryGetValue(noeud, out lst))
                    {
                        lst = new List<CLien>();
                        m_dicLiensSortants[noeud] = lst;
                    }
                    lst.Add(lien);
                }
            }
        }

        public CLien[] GetSuccesseurs(CNoeud noeud)
        {
            List<CLien> lst = null;
            m_dicLiensSortants.TryGetValue(noeud, out lst);
            if (lst != null)
                return lst.ToArray();
            return new CLien[0];
        }

        public static Hashtable GetElementsAPrendreEnCoursPourChemins(CSchemaReseau schema,
            CSite siteOrigine, CSite siteDestination)
        {
            Hashtable tableElementsAPrendreEnCompte = new Hashtable();
            CGraphe graphe = new CGraphe();
            graphe.CreateGraphe(schema);
            CSpvSite spvOrigine = CSpvSite.GetObjetSpvFromObjetTimos(siteOrigine);
            CSpvSite spvDest = CSpvSite.GetObjetSpvFromObjetTimos(siteDestination);
            if (spvDest != null)
            {
                List<CChemin> chemins = graphe.GetChemins(spvOrigine, spvDest);
                foreach (CChemin chemin in chemins)
                {
                    foreach (CPassageChemin passage in chemin.Passages)
                    {
                        tableElementsAPrendreEnCompte[passage.SiteSource] = true;
                        if (passage.LiaisonUtilisee != null)
                            tableElementsAPrendreEnCompte[passage.LiaisonUtilisee] = true;
                    }
                }
            }
            return tableElementsAPrendreEnCompte;
        }


        public void CreateGraphe(CSchemaReseau schema)
        {
            m_liens.Clear();
            m_noeuds.Clear();
            //Création des noeuds
            foreach (CSite site in schema.GetElementsLies<CSite>())
            {
                CSpvSite spvSite = CSpvSite.GetObjetSpvFromObjetTimos(site);
                if (spvSite != null)
                {
                    if (GetNoeud(spvSite) == null)
                        m_noeuds.Add(new CNoeud(spvSite));
                }
            }
            foreach (CLienReseau lien in schema.GetElementsLies<CLienReseau>())
            {
                CSpvLiai spvLiai = CSpvLiai.GetSpvLiaiFromLienReseau(lien) as CSpvLiai;
                if (spvLiai != null)
                {
                    CNoeud noeud1 = GetNoeud(spvLiai.SiteOrigine);
                    CNoeud noeud2 = GetNoeud(spvLiai.SiteDestination);
                    if (noeud1 != null && noeud2 != null)
                        m_liens.Add(new CLien(spvLiai, noeud1, noeud2));
                }
            }
        }

        public List<CChemin> GetChemins(CSpvSite siteOrigine, CSpvSite siteDestination)
        {
            List<CChemin> lstFinale = new List<CChemin>();
            CNoeud noeudDepart = GetNoeud(siteOrigine);
            CNoeud noeudFinal = GetNoeud(siteDestination);
            CChemin chemin = new CChemin();
            FindChemins(chemin, noeudDepart, noeudFinal, lstFinale);
            return lstFinale;
        }

        private void FindChemins(CChemin chemin, CNoeud noeudDepart, CNoeud noeudObjectif, List<CChemin> cheminsTrouves)
        {
            if (noeudObjectif.Equals(noeudDepart))
            {
                chemin += new CPassageChemin(noeudObjectif.Site, null);
                cheminsTrouves.Add(chemin);
                return;
            }
            else
            {
                foreach (CLien lien in GetSuccesseurs(noeudDepart))
                {

                    CPassageChemin passage = new CPassageChemin(noeudDepart.Site, lien.Liaison);
                    if (!chemin.PasseParSite(lien.NoeudArrivee.Site))
                        FindChemins(chemin + passage, lien.NoeudArrivee, noeudObjectif, cheminsTrouves);
                }
            }
        }
    }
}
