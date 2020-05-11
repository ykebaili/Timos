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

namespace timos
{
	public partial class CControlEditionDependancesTicket : UserControl, IControlALockEdition
	{
		private CTicket m_ticket = null;

		//------------------------------------------------
		public CControlEditionDependancesTicket()
		{
			InitializeComponent();
		}

		//----------------------------------------------------------------------
		public void Init(CTicket ticket)
		{
			m_ticket = ticket;

			//Initialisation du filtre de base
			m_filtrebase = new CFiltreData(CTicket.c_champId + " <> @1 AND " + CTicket.c_champEtat + " = 0 ", m_ticket.Id);

			//Initialisation Maitres
			//tool tip
			m_tooltip.SetToolTip(m_chkMaitreClotureAuto, "The ticket will be automatically closed when the selected master Ticket is closed|1104");

			//Initialisation des maîtres
			m_gestionnaireMaitres.ObjetEdite = m_ticket.RelationsMaitresListe;

			//Initialisation Esclaves
			//tool tip
			m_tooltip.SetToolTip(m_chkEsclaveClotureAuto, "The selected slave Ticket will be automaticaly closed when this Tikcet is closed|1105");

			//Initialisation des esclaves
			m_gestionnaireEsclaves.ObjetEdite = m_ticket.RelationsEsclavesListe;


			MAJFiltreSelectionneurs();

            m_lnkEsclaveEditer.Visible = false;
            m_lnkMaitreEditer.Visible = false;
            m_chkMaitreClotureAuto.Visible = false;
            m_chkEsclaveClotureAuto.Visible = false;
		}

		private CFiltreData m_filtrebase;
		private CFiltreData m_filtre;

        //----------------------------------------------------------------------
        private void MAJFiltreSelectionneurs()
		{
			m_filtre = new CFiltreData();
			m_filtre = CFiltreData.GetAndFiltre(m_filtre, m_filtrebase);

			foreach (CDependanceTicket dep in m_ticket.RelationsMaitresListe)
				m_filtre = CFiltreData.GetAndFiltre(m_filtre, new CFiltreData(CTicket.c_champId + " <> @1", dep.TicketMaitre.Id));

			foreach (CDependanceTicket dep in m_ticket.RelationsEsclavesListe)
				m_filtre = CFiltreData.GetAndFiltre(m_filtre, new CFiltreData(CTicket.c_champId + " <> @1", dep.TicketEsclave.Id));

			//On (re)initialise les selectionneurs avec le nouveau filtre
			m_txtMaitreSelec.InitAvecFiltreDeBase<CTicket>("DescriptionElement", m_filtre, true);
			m_txtEsclaveSelec.InitAvecFiltreDeBase<CTicket>("DescriptionElement", m_filtre, true);
		}


        //----------------------------------------------------------------------
        //Suppression
		private void m_lnkMaitreSupp_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeMaitres.SelectedItems.Count == 1)
			{
				CDependanceTicket dep = (CDependanceTicket)m_listeMaitres.SelectedItems[0].Tag;
				m_gestionnaireMaitres.SetObjetEnCoursToNull();
				m_listeMaitres.SelectedItems[0].Remove();
				dep.Delete();

				MAJFiltreSelectionneurs();
			}
		}
        //----------------------------------------------------------------------
        private void m_lnkEsclaveSupp_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeEsclaves.SelectedItems.Count == 1)
			{
				CDependanceTicket dep = (CDependanceTicket)m_listeEsclaves.SelectedItems[0].Tag;
				m_gestionnaireEsclaves.SetObjetEnCoursToNull();
				m_listeEsclaves.SelectedItems[0].Remove();
				dep.Delete();

				MAJFiltreSelectionneurs();
			}
		}


        //----------------------------------------------------------------------
        private void m_MaitreAjout_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtMaitreSelec.ElementSelectionne != null)
			{
				CTicket tkt = (CTicket)m_txtMaitreSelec.ElementSelectionne;

				if (tkt.Equals(m_ticket))
					CFormAlerte.Afficher(I.T( "A Ticket cannot be master of itself|1106"), EFormAlerteType.Exclamation);
				else if (m_ticket.IsMaitre(tkt))
					CFormAlerte.Afficher(I.T( "This Ticket cannot be a master Ticket, it is already slave of the current Ticket|1107"), EFormAlerteType.Exclamation);
				else
				{
					CDependanceTicket dependancetkt = new CDependanceTicket(m_ticket.ContexteDonnee);
					dependancetkt.TicketMaitre = tkt;
					dependancetkt.TicketEsclave = m_ticket;
					dependancetkt.ClotureAutoEscalve = false;
					dependancetkt.CreateNewInCurrentContexte();


					ListViewItem item = new ListViewItem();
					m_listeMaitres.Items.Add(item);
					m_listeMaitres.UpdateItemWithObject(item, dependancetkt);
					foreach (ListViewItem itemSel in m_listeMaitres.SelectedItems)
						itemSel.Selected = false;
					item.Selected = true;

					m_txtMaitreSelec.ElementSelectionne = null;

					MAJFiltreSelectionneurs();
				}
			}
		}
        //----------------------------------------------------------------------
        private void m_EsclaveAjout_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtEsclaveSelec.ElementSelectionne != null)
			{
				CTicket tkt = (CTicket)m_txtEsclaveSelec.ElementSelectionne;

				if (tkt.IsMaitre(m_ticket))
					CFormAlerte.Afficher(I.T( "This Ticket cannot be a slave Ticket, it is already master of the current Ticket|1108"), EFormAlerteType.Exclamation);
				else if(tkt.Equals(m_ticket))
					CFormAlerte.Afficher(I.T( "A Ticket cannot be a slave of itself|1109"), EFormAlerteType.Exclamation);
				else
				{
					CDependanceTicket dependancetkt = new CDependanceTicket(m_ticket.ContexteDonnee);
					dependancetkt.TicketMaitre = m_ticket;
					dependancetkt.TicketEsclave = tkt;
					dependancetkt.ClotureAutoEscalve = false;
					dependancetkt.CreateNewInCurrentContexte();

					ListViewItem item = new ListViewItem();
					m_listeEsclaves.Items.Add(item);
					m_listeEsclaves.UpdateItemWithObject(item, dependancetkt);
					foreach (ListViewItem itemSel in m_listeEsclaves.SelectedItems)
						itemSel.Selected = false;
					item.Selected = true;

					m_txtEsclaveSelec.ElementSelectionne = null;

					MAJFiltreSelectionneurs();
				}
			}
		}



        //----------------------------------------------------------------------
        //Editer un element
		private void m_lnkMaitreEditer_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeMaitres.SelectedItems.Count != 1)
				return;

			CDependanceTicket dep = (CDependanceTicket)m_listeMaitres.SelectedItems[0].Tag;
			AfficherTicket(dep.TicketMaitre);
		}
        //----------------------------------------------------------------------
        private void m_lnkEsclaveEditer_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeEsclaves.SelectedItems.Count != 1)
				return;

			CDependanceTicket dep = (CDependanceTicket)m_listeEsclaves.SelectedItems[0].Tag;
			AfficherTicket(dep.TicketEsclave);
		}
        //----------------------------------------------------------------------
        private void AfficherTicket(CTicket tkt)
		{
            //Type t = CFormFinder.GetTypeFormToEdit(tkt.GetType());
            //if (typeof(IFormNavigable).IsAssignableFrom(t))
            //{
            //    IFormNavigable iformnav = (IFormNavigable)Activator.CreateInstance(t, new object[] { tkt });
            //    CTimosApp.Navigateur.AffichePage(iformnav);
            //}
            CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(tkt.GetType());
            if (refTypeForm != null)
            {
                IFormNavigable iformnav = refTypeForm.GetForm(tkt) as IFormNavigable;
                if (iformnav != null)
                    CTimosApp.Navigateur.AffichePage(iformnav);
            }

		}


        //----------------------------------------------------------------------
        //Sauvegarde
		public CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;

			if (result)
				result = m_gestionnaireMaitres.ValideModifs();
			if (result)
				result = m_gestionnaireEsclaves.ValideModifs();

			return result;
		}


        //----------------------------------------------------------------------
		//LockEdition
		public event EventHandler OnChangeLockEdition;
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


        //----------------------------------------------------------------------
        private void m_gestionnaireMaitres_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_lnkMaitreEditer.Visible = false;
                m_chkMaitreClotureAuto.Visible = false;
                return;
            }
            m_lnkMaitreEditer.Visible = true;
            m_chkMaitreClotureAuto.Visible = true;
            CDependanceTicket dep = (CDependanceTicket) args.Objet;
            m_chkMaitreClotureAuto.Checked = dep.ClotureAutoEscalve;
        }

        //----------------------------------------------------------------------
        private void m_gestionnaireMaitres_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CDependanceTicket dep = (CDependanceTicket)args.Objet;
                dep.ClotureAutoEscalve = m_chkMaitreClotureAuto.Checked;
                return;
            }
        }

        //----------------------------------------------------------------------
        private void m_gestionnaireEsclaves_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_lnkEsclaveEditer.Visible = false;
                m_chkEsclaveClotureAuto.Visible = false;
                return;
            }
            m_lnkEsclaveEditer.Visible = true;
            m_chkEsclaveClotureAuto.Visible = true;
            CDependanceTicket dep = (CDependanceTicket)args.Objet;
            m_chkEsclaveClotureAuto.Checked = dep.ClotureAutoEscalve;

        }

        //----------------------------------------------------------------------
        private void m_gestionnaireEsclaves_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CDependanceTicket dep = (CDependanceTicket)args.Objet;
                dep.ClotureAutoEscalve = m_chkEsclaveClotureAuto.Checked;
                return;
            }
        }

        private void CControlEditionDependancesTicket_Load(object sender, EventArgs e)
        {
            sc2i.win32.common.CWin32Traducteur.Translate(this);

        }


	}
}
