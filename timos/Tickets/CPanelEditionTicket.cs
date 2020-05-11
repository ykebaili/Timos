using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.multitiers.client;
using sc2i.win32.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.workflow;
using timos.acteurs;

using timos.data;
using timos.securite;

namespace timos
{
    public partial class CPanelEditionTicket : UserControl, IControlALockEdition
    {
        private CTicket m_ticketEdite;
        private CDonneesActeurUtilisateur m_utilisateur;
        private bool m_bNouveau = false;

        public CTicket TicketEdité
        {
            get
            {
                return m_ticketEdite;
            }
        }
        
        public CPanelEditionTicket()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        bool m_bIsInitialising = false;
        public CResultAErreur InitPanel(CTicket ticketEdité)
        {
            m_bIsInitialising = true;

            this.SuspendDrawing();

            if (ticketEdité == null)
                return CResultAErreur.False;

            CResultAErreur result = CResultAErreur.True;

            m_ticketEdite = ticketEdité;
            m_utilisateur = CUtilSession.GetUserForSession(m_ticketEdite.ContexteDonnee);

            if (m_ticketEdite.IsNew())
            {
                m_bNouveau = true;
                m_ticketEdite.CreerHistorique(null, I.T( "Ticket opening|675"));
            }
            else
                m_bNouveau = false;

            m_extLinkField.FillDialogFromObjet(m_ticketEdite);

            // Init panel Infos générales
            InitInfosGenerales();
            // Init Détail Ticket
            InitDetailTicket();
            InitOnglets();

            m_bIsInitialising = false;

            UpdateVisuEntete(m_bInfosEnteteAffiche);

			this.ResumeDrawing();

            return result;
        }

        //----------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;

            CActeur acteur = (CActeur)m_txtSelectClient.ElementSelectionne;
            if (acteur != null)
                m_ticketEdite.Client = acteur.Client;
            
            m_ticketEdite.Contrat = (CContrat)m_cmbxSelectContrat.ElementSelectionne;
            m_ticketEdite.TypeTicket = (CTypeTicket)m_cmbxSelectTypeTicket.ElementSelectionne;
            m_ticketEdite.Urgence = (CUrgenceTicket)m_cmbxSelectUrgence.ElementSelectionne;
            m_ticketEdite.OrigineTicket = (COrigineTicket)m_cmbxSelectOrigineTicket.ElementSelectionne;

            if (result)
                result = m_panelChampsCustom.MAJ_Champs();
            if (result)
                result = m_panelFormulaireSurOrigine.AffecteValeursToElement();
            if (result)
                result = m_controlEditDependances.MAJ_Champs();
            if (result)
                result = m_controlEditionEntitesLiees.MAJ_Champs();
            if (result)
                result = m_extLinkField.FillObjetFromDialog(m_ticketEdite);
            if (result)
                result = m_panelEditionPhase.MAJ_Champs();

            return result;
        }

        //----------------------------------------------------------------------------
        private void InitInfosGenerales()
        {
            m_lblDateOuverture.Text = m_ticketEdite.DateOuvertureToString;
            m_lblDateCloture.Text = m_ticketEdite.DateClotureToString;
            if(m_ticketEdite.EtatCloture != null)
                m_lblEtatCloture.Text = m_ticketEdite.EtatCloture.Libelle;
            else
                m_lblEtatCloture.Text = "";

        }

        //----------------------------------------------------------------------------
        private void InitDetailTicket()
        {
            CFiltreData filtre = new CFiltreDataAvance(
                CActeur.c_nomTable,
                "Has(" + CDonneesActeurClient.c_nomTable + "." +
                CDonneesActeurClient.c_champId + ")");

            m_txtSelectClient.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
				false);
            if(m_ticketEdite.Client != null)
                m_txtSelectClient.ElementSelectionne = m_ticketEdite.Client.Acteur;

            InitListeContrats(false);
            m_cmbxSelectContrat.ElementSelectionne = m_ticketEdite.Contrat;
            InitListeTypesTickets(false);
            m_cmbxSelectTypeTicket.ElementSelectionne = m_ticketEdite.TypeTicket;
            InitSelectUrgenceTicket(false);
            m_cmbxSelectUrgence.ElementSelectionne = m_ticketEdite.Urgence;
            InitSelectOrigineTicket(false);
            m_cmbxSelectOrigineTicket.ElementSelectionne = m_ticketEdite.OrigineTicket;

            CListeObjetsDonnees listeClients = new CListeObjetsDonnees(m_ticketEdite.ContexteDonnee, typeof(CDonneesActeurClient));
            if (listeClients.Count == 1)
            {
                CDonneesActeurClient client = (CDonneesActeurClient)listeClients[0];
                m_txtSelectClient.ElementSelectionne = client.Acteur;
            }

            m_panelEditionPhase.Visible = false;

            InitPanelChampsCustom();
            InitPanelFormulaireSurOrigine();
            InitListePhases();
            m_controlEditDependances.Init(m_ticketEdite);
            m_controlEditionEntitesLiees.Init(m_ticketEdite);

            m_panelListeHistorique.InitFromListeObjets(
                m_ticketEdite.HistoriquesTicket,
                typeof(CHistoriqueTicket),
                null,
                m_ticketEdite,
                "Ticket");

        }


        #region IControlALockEdition Membres

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

        #endregion

        //--------------------------------------------------------------
        private void m_txtSelectActeurClient_ElementSelectionneChanged(object sender, EventArgs e)
        {
             InitListeContrats( true );
        }

        //--------------------------------------------------------------
        private void InitListeContrats(bool bForcerInit)
        {
            CActeur acteur = (CActeur)m_txtSelectClient.ElementSelectionne;
            CListeObjetsDonnees listeContrats = new CListeObjetsDonnees(m_ticketEdite.ContexteDonnee, typeof(CContrat));
            if (acteur != null)
            {
                CDonneesActeurClient client = acteur.Client;
                if (client != null)
                {
                    listeContrats.Filtre = new CFiltreData(
                        CDonneesActeurClient.c_champId + " = @1",
                        client.Id);
                }
            }
            m_cmbxSelectContrat.Init(listeContrats, "Libelle", bForcerInit);
            m_cmbxSelectContrat.AssureRemplissage();
            
            if (listeContrats.Count == 1)
                m_cmbxSelectContrat.SelectedIndex = 0;
            if(acteur == null)
                m_cmbxSelectContrat.ElementSelectionne = null;

            InitListeTypesTickets(true);

        }

        //-------------------------------------------------------------------------------------
        private void m_cmbxSelectContrat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_ticketEdite.Contrat = (CContrat)m_cmbxSelectContrat.ElementSelectionne;
            if (m_ticketEdite.Contrat != null)
            {
                m_ticketEdite.Client = m_ticketEdite.Contrat.Client;
                if (m_ticketEdite.Client != null)
                    m_txtSelectClient.ElementSelectionne = m_ticketEdite.Client.Acteur;
            }
            InitListeTypesTickets(true);
        }

        //-------------------------------------------------------------------------------------
        private void InitListeTypesTickets( bool bForceInit )
        {
            if (!(m_cmbxSelectContrat.ElementSelectionne is CContrat))
            {
                m_cmbxSelectTypeTicket.Enabled = false;
            }
            else
            {
                m_cmbxSelectTypeTicket.Enabled = true;
                CListeObjetsDonnees  listeTypesTickets = new CListeObjetsDonnees (m_ticketEdite.ContexteDonnee, typeof(CTypeTicket));
                
                listeTypesTickets.Filtre = new CFiltreDataAvance ( 
                    CTypeTicket.c_nomTable,
                    CTypeTicketContrat.c_nomTable+"."+
                    CContrat.c_champId+"=@1",
                    ((CContrat)m_cmbxSelectContrat.ElementSelectionne).Id);

                m_cmbxSelectTypeTicket.Init ( listeTypesTickets, "Libelle", bForceInit );
                if (listeTypesTickets.Count == 1 && bForceInit)
                {
                    m_cmbxSelectTypeTicket.AssureRemplissage();
                    m_cmbxSelectTypeTicket.SelectedIndex = 0;
					InitPanelChampsCustom();
                }
            }
            
        }


        //--------------------------------------------------------------
        public void InitSelectUrgenceTicket(bool bForceInit)
        {
            m_cmbxSelectUrgence.Init(
                new CListeObjetsDonnees(m_ticketEdite.ContexteDonnee, typeof(CUrgenceTicket)),
                "Libelle",
                bForceInit);

            m_cmbxSelectUrgence.ElementSelectionne = m_ticketEdite.Urgence;
        }

        //--------------------------------------------------------------
        private void InitSelectOrigineTicket(bool bForceInit)
        {
            m_cmbxSelectOrigineTicket.Init(
                new CListeObjetsDonnees(m_ticketEdite.ContexteDonnee, typeof(COrigineTicket)),
                "Libelle",
                bForceInit);

            m_cmbxSelectOrigineTicket.ElementSelectionne = m_ticketEdite.OrigineTicket;
        }

        //--------------------------------------------------------------
        private void m_cmbxSelectTypeTicket_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Mise à jour des champs custom liés au type de ticket
            InitPanelChampsCustom();
        }

        //--------------------------------------------------------------
        private void InitPanelChampsCustom()
        {
            m_ticketEdite.TypeTicket = (CTypeTicket) m_cmbxSelectTypeTicket.ElementSelectionne;
            if (m_ticketEdite.TypeTicket != null)
            {
                m_panelChampsCustom.ElementEdite = m_ticketEdite;
            }
        }

        //--------------------------------------------------------------
        public void InitPanelFormulaireSurOrigine()
        {
            m_ticketEdite.OrigineTicket = (COrigineTicket)m_cmbxSelectOrigineTicket.ElementSelectionne;
            if (m_ticketEdite.OrigineTicket != null &&
                m_ticketEdite.OrigineTicket.Formulaire != null)
            {
                m_panelFormulaireSurOrigine.Visible = true;
                m_panelFormulaireSurOrigine.InitPanel(
                    m_ticketEdite.OrigineTicket.Formulaire.Formulaire,
                    m_ticketEdite);
            }
            else
                m_panelFormulaireSurOrigine.Visible = false;
            
        }

        //------------------------------------------------------------------------------------
        private void m_cmbxSelectOrigineTicket_SelectionChangeCommitted(object sender, EventArgs e)
        {
            InitPanelFormulaireSurOrigine();
        }

        //--------------------------------------------------------------------------------------
        private void InitListePhases()
        {
            m_listePhases.Items.Clear();

            CListeObjetsDonnees listePhases = m_ticketEdite.PhasesListe;
            listePhases.Tri = CPhaseTicket.c_champDateCreation;

            foreach (CPhaseTicket phase in listePhases)
            {
                ListViewItem item = new ListViewItem(phase.TypePhase.Libelle);
                item.Tag = phase;
                m_listePhases.Items.Add(item);
            }

            UpdateLinksAndButtonsStates();

        }

        //-----------------------------------------------------------------------------
        private void UpdateLinksAndButtonsStates()
        {
            if (m_listePhases.Items.Count != 0)
            {
                m_lnkPhaseSuivante.Text = I.T( "Go on to next Phase...|673");
                m_panelCacherListePhases.Visible = true;
                m_listePhases.Items[0].Selected = true;
                m_lnkCloreTicket.Enabled = m_gestionnaireModeEdition.ModeEdition;
                int i = m_listePhases.Items.Count -1 ;
                m_listePhases_ItemClick(m_listePhases.Items[i]);

            }
            else
            {
                m_lnkPhaseSuivante.Text = I.T("Start resolution process...|676");
                m_panelCacherListePhases.Visible = false;
                m_lnkCloreTicket.Enabled = false;
            }

            if (m_ticketEdite.PhaseEnCours != null)
            {
                if (m_ticketEdite.PhaseEnCours.EstGelee || !m_ticketEdite.PhaseEnCours.CanEdit())
                {
                    m_lnkPhaseSuivante.Enabled = false;
                }
                else
                {
                    m_lnkPhaseSuivante.Enabled = m_gestionnaireModeEdition.ModeEdition;
                }

                if (!m_ticketEdite.PhaseEnCours.IsPointSortie() || m_ticketEdite.DateCloture != null)
                {
                    m_lnkCloreTicket.Enabled = false;
                }
                else
                {
                    m_lnkCloreTicket.Enabled = m_gestionnaireModeEdition.ModeEdition;
                }
            }

        }

        //-----------------------------------------------------------------------------
        private void m_listePhases_ItemClick(ListViewItem item)
        {
            if (item != null)
            {
                CPhaseTicket phase = (CPhaseTicket)item.Tag;
                if (phase != null)
                {
                    if(!m_bIsInitialising)
                        m_panelEditionPhase.MAJ_Champs();
                    InitPanelPhases(phase);
                }
            }
        }

        //-------------------------------------------------------------------------
        private void InitPanelPhases(CPhaseTicket phase)
        {
            if (phase == null)
            {
                m_panelEditionPhase.Visible = false;
            }
            else
            {
                m_panelEditionPhase.Visible = true;
                if (phase != m_ticketEdite.PhaseEnCours || !phase.CanEdit())
                {
                    m_panelEditionPhase.LockEdition = true;
                    
                }
                else
                {
                    m_panelEditionPhase.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                }
                m_panelEditionPhase.InitPanel(phase);


            }
        }
          
        //-----------------------------------------------------------------------------
        // Click sur le lien "Passer à la phase suivante..."
        private void m_lnkPhaseSuivante_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InitContextMenuPhaseSuivante(m_lnkPhaseSuivante);
        }

        //-----------------------------------------------------------------------------
        private void InitContextMenuPhaseSuivante(Control control)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            m_ticketEdite.TypeTicket = (CTypeTicket)m_cmbxSelectTypeTicket.ElementSelectionne;

            if (m_ticketEdite.PhaseEnCours != null && !m_ticketEdite.PhaseEnCours.EvaluerConditionDeSortie())
            {
                if (m_ticketEdite.PhaseEnCours.TypePhase != null &&
                    m_ticketEdite.PhaseEnCours.TypePhase.MessageErreurFormule != "")
                    CFormAlerte.Afficher(m_ticketEdite.PhaseEnCours.TypePhase.MessageErreurFormule, EFormAlerteType.Erreur);
                else
                    CFormAlerte.Afficher(I.T( "The current phase cannot be ended|678"),EFormAlerteType.Erreur);

                return;
            }

            CTypePhase[] typesPossibles = m_ticketEdite.GetTypesPhasesSuivantesPossibles();
            if (typesPossibles == null || typesPossibles.Length == 0)
            {
                CFormAlerte.Afficher(I.T( "This is the last step of the resolution process|679"));
                return;
            }
            if (typesPossibles.Length == 1)
            {
                StartPhaseSuivante(typesPossibles[0]);
            }
            else
            {
                foreach (CTypePhase tp in typesPossibles)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(tp.Libelle);
                    item.Tag = tp;
                    item.Click += new EventHandler(menuPhaseSuivante_Click);
                    menu.Items.Add(item);
                }
                Point pt = new Point(0, control.Height);
                menu.Show(control, pt);
            }
        }

        //-----------------------------------------------------------------------------
        private void menuPhaseSuivante_Click(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				object tag = ((ToolStripMenuItem)sender).Tag;
				if (tag is CTypePhase)
					StartPhaseSuivante((CTypePhase)tag);
			}
		}

        //-----------------------------------------------------------------------------
        // Démarre la phase suivante du processus de résolution
        private void StartPhaseSuivante(CTypePhase typePhase)
		{
            m_extLinkField.FillObjetFromDialog(m_ticketEdite);
            CPhaseTicket phasePrecedente = m_ticketEdite.PhaseEnCours;
            CResultAErreur result = m_ticketEdite.StartPhaseSuivante(typePhase);
            if (result)
            {
                if (phasePrecedente != null)
                    m_ticketEdite.CreerHistorique(phasePrecedente, I.T( "Ending Phase:|680")+ " " + phasePrecedente.Libelle);
                m_ticketEdite.CreerHistorique(null, I.T( "Creating Phase:|681")+" " + typePhase.Libelle);

                ShowTabPagePhasesResolution();
                InitListePhases();
                m_extLinkField.FillDialogFromObjet(m_ticketEdite);
            }
		}

        //-----------------------------------------------------------------------------
        private void InitOnglets()
        {
            if (m_bNouveau)
            {
                m_btnDetailEtapeSuivante.Visible = true;
                m_btnSitesEtapeSuivant.Visible = true;

                if (m_tabControl.TabPages.Contains(m_tabPageSites))
                    m_tabControl.TabPages.Remove(m_tabPageSites);
                if (m_tabControl.TabPages.Contains(m_tabPageResolution))
                    m_tabControl.TabPages.Remove(m_tabPageResolution);
                if (m_tabControl.TabPages.Contains(m_tabPageTicketsLies))
                    m_tabControl.TabPages.Remove(m_tabPageTicketsLies);
                if (m_tabControl.TabPages.Contains(m_tabPageHistorique))
                    m_tabControl.TabPages.Remove(m_tabPageHistorique);
            }
            else
            {
                m_btnDetailEtapeSuivante.Visible = false;
                m_btnSitesEtapeSuivant.Visible = false;

                if (!m_tabControl.TabPages.Contains(m_tabPageSites))
                    m_tabControl.TabPages.Add(m_tabPageSites);
                if (!m_tabControl.TabPages.Contains(m_tabPageResolution))
                    m_tabControl.TabPages.Add(m_tabPageResolution);
                if (!m_tabControl.TabPages.Contains(m_tabPageTicketsLies))
                    m_tabControl.TabPages.Add(m_tabPageTicketsLies);
                if (!m_tabControl.TabPages.Contains(m_tabPageHistorique))
                    m_tabControl.TabPages.Add(m_tabPageHistorique);
            }

        }

        //-----------------------------------------------------------------------------
        private CResultAErreur VerifieSaisieOngletDetail()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_txtSelectClient.ElementSelectionne == null)
                result.EmpileErreur(I.T( "The Customer field must be filled|682"));
            if(m_cmbxSelectContrat.ElementSelectionne == null)
                result.EmpileErreur(I.T("The Contract field must be filled|683 "));
            if(m_cmbxSelectTypeTicket.ElementSelectionne == null)
                result.EmpileErreur(I.T("The Ticket Type field must be filled|684"));

            return result;
        }

        //-----------------------------------------------------------------------------
        private CResultAErreur VerifieSaisieOngletSites()
        {
            CResultAErreur result = CResultAErreur.True;
            // Ajouter ici des vérifications
            m_controlEditionEntitesLiees.MAJ_Champs();
 
            return result;
        }


        //-----------------------------------------------------------------------------
        private void m_btnDetailEtapeSuivante_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            if (result = VerifieSaisieOngletDetail())
            {
                if (!m_tabControl.TabPages.Contains(m_tabPageSites))
                    m_tabControl.TabPages.Add(m_tabPageSites);

                m_tabControl.SelectedTab = m_tabPageSites;
                m_btnDetailEtapeSuivante.Visible = false;
            }
            else
                CFormAlerte.Afficher(result.Erreur);
        }

 
        //-----------------------------------------------------------------------------
        private void m_btnSitesEtapeSuivant_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;

            if(result = VerifieSaisieOngletSites())
            {
                // Démarrer les phases de résolution
                InitContextMenuPhaseSuivante(m_btnSitesEtapeSuivant);
                //ShowTabPagePhasesResolution();
            }
            else
                CFormAlerte.Afficher(result.Erreur);
        }

        //-----------------------------------------------------------------------------
        private void ShowTabPagePhasesResolution()
        {
            if (!m_tabControl.TabPages.Contains(m_tabPageResolution))
                m_tabControl.TabPages.Add(m_tabPageResolution);
            if (!m_tabControl.TabPages.Contains(m_tabPageTicketsLies))
                m_tabControl.TabPages.Add(m_tabPageTicketsLies);
            if (!m_tabControl.TabPages.Contains(m_tabPageHistorique))
                m_tabControl.TabPages.Add(m_tabPageHistorique);

            m_tabControl.SelectedTab = m_tabPageResolution;
            m_btnSitesEtapeSuivant.Visible = false;
        }

        //-----------------------------------------------------------------------------
        public event EventHandler OnCloseTicket;
        //------------------------------------------------------------------------------------
        private void m_lnkCloreTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_ticketEdite.PhaseEnCours.IsPointSortie())
            {
                if (result = VerifieSaisieAvantCloture())
                {

                    DialogResult reponse = CFormAlerte.Afficher(
                        I.T( "This action will definitely close the current Ticket. Any modification will no more be possible.|686") +"\r\n" + I.T( "Confirm closing|687"),
						EFormAlerteType.Question);

                    if (reponse == DialogResult.Yes)
                    {
                        // Ici CLore le ticket
                        //m_ticketEdite.DateCloture = DateTime.Now;
                        m_ticketEdite.Close(DateTime.Now);
                        
                        if (m_ticketEdite.PhaseEnCours != null)
                        {
                            m_ticketEdite.PhaseEnCours.DateFin = DateTime.Now;
                            m_ticketEdite.CreerHistorique(null, I.T( "Ending Phase|689")+" " + m_ticketEdite.PhaseEnCours.Libelle);
                            if (m_ticketEdite.PhaseEnCours.DateDebut == null)
                                m_ticketEdite.PhaseEnCours.DateDebut = DateTime.Now;
                        }
                        m_ticketEdite.CreerHistorique(null, I.T( "Closing Ticket|690"));


                        if (OnCloseTicket != null)
                            OnCloseTicket(this, new EventArgs());
                    }
                }
                else
                {
                    CFormAlerte.Afficher(result.Erreur);
                }
            }
        }

        //-----------------------------------------------------------------------------
        private CResultAErreur VerifieSaisieAvantCloture()
        {
            CResultAErreur result = CResultAErreur.True;
            m_panelEditionPhase.MAJ_Champs();

            if (m_ticketEdite.DateClotureTechnique == null)
                result.EmpileErreur(I.T("Technical closing date must be filled|692"));

            if (m_ticketEdite.DateClotureTechnique > DateTime.Now)
                result.EmpileErreur(I.T("Technical closing date could not be greater than current date|693"));

            if (m_ticketEdite.EtatCloture == null)
                result.EmpileErreur(I.T("Closing state must be filled|694"));
            
            if(m_ticketEdite.PhaseEnCours != null && m_ticketEdite.PhaseEnCours.EstGelee)
                result.EmpileErreur(I.T("The current Phase is freezed. Unfreeze before closing Ticket|695"));

            if (!result)
                result.EmpileErreur(I.T("Closing Ticket failure. See details...|696"));

            return result;
        }

        //------------------------------------------------------------------------------------
        private void m_panelEditionPhase_OnDebutPhase(object sender, EventArgs e)
        {
            CPhaseTicket phase = (CPhaseTicket)sender;
            m_ticketEdite.CreerHistorique(null, I.T("Starting Phase|697")+" " + phase.Libelle);
        }

        //------------------------------------------------------------------------------------
        private void m_panelEditionPhase_OnChangeEtatGel(object sender, EventArgs e)
        {
            UpdateLinksAndButtonsStates();
            m_extLinkField.FillDialogFromObjet(m_ticketEdite);
        }

        //------------------------------------------------------------------------------------
        private bool m_bInfosEnteteAffiche = true;
        private void m_btnAfficheInfosEntete_Click(object sender, EventArgs e)
        {
            UpdateVisuEntete(!m_bInfosEnteteAffiche);
        }

        //------------------------------------------------------------------------------------
        private void UpdateVisuEntete(bool bAffiche)
        {
            this.SuspendDrawing();
            int nHeightOffset = 22;
            int x = m_tabControl.Size.Width;
            int y = m_tabControl.Size.Height;
            if (!m_bInfosEnteteAffiche && bAffiche)
            {
                // J'affiche l'entête
                m_btnAfficheInfosEntete.Text = "/\\";
                m_gbInfosGenerales.Visible = true;
                m_panelEntete.Height = m_panelTitre.Height + m_gbInfosGenerales.Height + nHeightOffset;
                m_tabControl.Location = new Point(0, m_panelEntete.Height + 6);
                m_tabControl.Size = new Size(x, y - m_gbInfosGenerales.Height);
                m_bInfosEnteteAffiche = true;
            }
            if(m_bInfosEnteteAffiche && !bAffiche)
            {
                // Je cache l'entête
                m_btnAfficheInfosEntete.Text = "\\/";
                m_gbInfosGenerales.Visible = false;
                m_panelEntete.Height = m_panelTitre.Height + nHeightOffset;
                m_tabControl.Location = new Point(0, m_panelEntete.Height + 6);
                m_tabControl.Size = new Size(x, y + m_gbInfosGenerales.Height);
                m_bInfosEnteteAffiche = false;
            }
            
            this.ResumeDrawing();
        }



    }

}
