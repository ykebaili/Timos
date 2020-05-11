using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;
using timos.data;

namespace testGrilleSites
{
    public class CFaciliteurEditionPeriodesSiteTypeTicket
    {
        private CContrat m_contrat = null;
        /* private List<CSite> m_sites = new List<CSite>();
        private List<CTypeTicketContrat> m_typesTickets = new List<CTypeTicketContrat>();

        private Dictionary<int, CSite> m_dicSites = new Dictionary<int, CSite>();
        private Dictionary<int, CTypeTicketContrat> m_dicTypesTickets = new Dictionary<int, CTypeTicketContrat>();
        */

        //---------------------------------------------------
        public void InitFromContrat(CContrat contrat)
        {
            m_contrat = contrat;
            /*foreach (CSite site in contrat.GetTousLesSitesDuContrat())
            {
                m_sites.Add(site);
                m_dicSites[site.Id] = site;
            }
            foreach (CTypeTicketContrat tt in contrat.RelationsTypesTickets)
            {
                m_typesTickets.Add(tt);
                m_dicTypesTickets[tt.Id] = tt;
            }*/
        }


        //---------------------------------------------------
        public List<CSite> Sites
        {
            get
            {
                List<CSite> lst = new List<CSite>();
                if (m_contrat != null)
                {
                    if (m_contrat.TypeContrat.GestionSitesManuel)
                    {
                        foreach (CContrat_Site ctSite in m_contrat.RelationsSites)
                            lst.Add(ctSite.Site);
                    }
                    else
                    {
                        if (m_contrat.ProfilSite != null)
                        {
                            foreach (CSite site in m_contrat.ProfilSite.GetElementsForSource(m_contrat, null))
                            {
                                lst.Add(site);
                            }
                        }
                    }
                }


                return lst;
            }
        }

        //---------------------------------------------------
        public List<CTypeTicketContrat> TypesTickets
        {
            get
            {
                List<CTypeTicketContrat> lst = new List<CTypeTicketContrat>();
                if (m_contrat != null)
                    foreach (CTypeTicketContrat tt in m_contrat.RelationsTypesTickets)
                        lst.Add(tt);
                return lst;
            }
        }

        //---------------------------------------------------
        public CSite GetSite(int nId)
        {
            if (m_contrat == null)
                return null;
            CSite site = new CSite(m_contrat.ContexteDonnee);
            if (site.ReadIfExists(nId))
                return site;
            return null;
        }

        public CTypeTicketContrat GetTypeTicketContrat(int nId)
        {
            if (m_contrat == null)
                return null;
            CTypeTicketContrat tt = tt = new CTypeTicketContrat(m_contrat.ContexteDonnee);
            if (tt.ReadIfExists(nId))
                return tt;
            return null;
        }

    }
}
