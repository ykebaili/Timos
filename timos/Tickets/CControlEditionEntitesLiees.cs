using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using timos.data;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

using timos.securite;

namespace timos
{
	public partial class CControlEditionEntitesLiees: UserControl, IControlALockEdition
	{
		private CTicket m_ticketEdite = null;

 
		//------------------------------------------------------------------
        public CControlEditionEntitesLiees()
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------
		public void Init(CTicket ticket)
		{
			m_ticketEdite = ticket;

            InitSelectSite();
            InitSelectEO();
            InitListeSites();
            InitListeEOs();
		}
        //--------------------------------------------------------------------------------------------
        private void InitSelectSite()
        {
            m_txtSelectSite.Init<CSite>(
                "Libelle",
                false);
        }

        //--------------------------------------------------------------------------------------------
        private void InitSelectEO()
        {
            CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CEntiteOrganisationnelle));

            m_txtSelectEO.Init<CEntiteOrganisationnelle>(
                "Libelle",
                false);

        }

        //--------------------------------------------------------------------------------------------
        private void InitListeSites()
        {
            m_listeSites.Items.Clear();
            int rang = 0;
            foreach (CRelationTicket_Site rel in m_ticketEdite.RelationsSitesListe)
            {
                ListViewItem item = new ListViewItem();
                if (rang == 0)
                    item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
                m_listeSites.Items.Add(item);
                m_listeSites.UpdateItemWithObject(item, rel);
                rang++;
            }
        }

        //--------------------------------------------------------------------------------------------
        private void InitListeEOs()
        {
            m_listeEOs.Items.Clear();
            int rang = 0;
            foreach (CRelationTicket_EOconcernees rel in m_ticketEdite.RelationsEOconcernees)
            {
                ListViewItem item = new ListViewItem();
                if (rang == 0)
                    item.Font = new Font(item.Font, item.Font.Style | FontStyle.Bold);
                m_listeEOs.Items.Add(item);
                m_listeEOs.UpdateItemWithObject(item, rel);
            }
        }

        //--------------------------------------------------------------------------------------------
        //Sauvegarde
		public CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;


			return result;
		}

        //--------------------------------------------------------------------------------------------
        //LockEdition
		public bool LockEdition
		{
			get
			{
				return !m_gestionnaireModeEdition.ModeEdition;
			}
			set
			{
				m_gestionnaireModeEdition.ModeEdition = !value;
				if (OnChangeLockEdition != null)
					OnChangeLockEdition(this, new EventArgs());
			}
		}
		public event EventHandler OnChangeLockEdition;



        //--------------------------------------------------------------------------------------------
        private void m_lnkAjouterSite_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectSite.ElementSelectionne == null)
                return;

            CSite site = (CSite) m_txtSelectSite.ElementSelectionne;
            CListeObjetsDonnees listeRelSites = m_ticketEdite.RelationsSitesListe;

            listeRelSites.Filtre = new CFiltreData(CSite.c_champId + " = @1 ", site.Id);
            if (listeRelSites.Count != 0)
            {
                CFormAlerte.Afficher(I.T( "This Site is already in the list|1110"), EFormAlerteType.Exclamation);
                return;
            }

            m_txtSelectSite.ElementSelectionne = null;

            CRelationTicket_Site newRel = new CRelationTicket_Site(m_ticketEdite.ContexteDonnee);
            newRel.CreateNewInCurrentContexte();
            newRel.Ticket = m_ticketEdite;
            newRel.Site = site;

            InitListeSites();
        }


        //--------------------------------------------------------------------------------------------
        private void m_lnkAjouterEO_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectEO.ElementSelectionne == null)
                return;

            CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)m_txtSelectEO.ElementSelectionne;
            CListeObjetsDonnees listeRelEO = m_ticketEdite.RelationsEOconcernees;

            listeRelEO.Filtre = new CFiltreData(CEntiteOrganisationnelle.c_champId + " = @1 ", eo.Id);
            if (listeRelEO.Count != 0)
            {
                CFormAlerte.Afficher(I.T("This Organizational Entity is already in the list|1111"), EFormAlerteType.Exclamation);
                return;
            }

            m_txtSelectEO.ElementSelectionne = null;

            CRelationTicket_EOconcernees newRel = new CRelationTicket_EOconcernees(m_ticketEdite.ContexteDonnee);
            newRel.CreateNewInCurrentContexte();
            newRel.Ticket = m_ticketEdite;
            newRel.EntiteOrganisationnelle = eo;

            InitListeEOs();
        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkSupprimerSite_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeSites.SelectedItems.Count != 1)
                return;

            CRelationTicket_Site rel = (CRelationTicket_Site)m_listeSites.SelectedItems[0].Tag;
            if(rel != null)
            {
                CResultAErreur result = rel.Delete();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
            }

            InitListeSites();
        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkSupprimerEO_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeEOs.SelectedItems.Count != 1)
                return;

            CRelationTicket_EOconcernees rel = (CRelationTicket_EOconcernees)m_listeEOs.SelectedItems[0].Tag;
            if (rel != null)
            {
                CResultAErreur result = rel.Delete();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
            }

            InitListeEOs();
        }

        //--------------------------------------------------------------------------------------------
        private void CControlEditionEntitesLiees_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);

        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkEditerSite_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeSites.SelectedItems.Count != 1)
                return;

            CRelationTicket_Site rel = (CRelationTicket_Site)m_listeSites.SelectedItems[0].Tag;
            if (rel != null)
            {
                CSite site = rel.Site;
                CFormEditionSite form = new CFormEditionSite(site);
                CTimosApp.Navigateur.AffichePageDansNouvelOnglet(form);
            }

        }

        //--------------------------------------------------------------------------------------------
        private void l_lnkEditerEO_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeEOs.SelectedItems.Count != 1)
                return;

            CRelationTicket_EOconcernees rel = (CRelationTicket_EOconcernees)m_listeEOs.SelectedItems[0].Tag;
            if (rel != null)
            {
                CEntiteOrganisationnelle eo = rel.EntiteOrganisationnelle;
                CFormEditionEntiteOrganisationnelle form = new CFormEditionEntiteOrganisationnelle(eo);
                CTimosApp.Navigateur.AffichePageDansNouvelOnglet(form);
            }

        }
         
	}
}
