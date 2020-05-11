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
    public partial class CPanelInfosGenerales : UserControl, IControlALockEdition
    {
        private CTicket m_ticketEdite;
        private CDonneesActeurUtilisateur m_utilisateur;

        public CTicket TicketEdité
        {
            get
            {
                return m_ticketEdite;
            }
        }
        
        public CPanelInfosGenerales()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        
        public CResultAErreur InitPanel(CTicket ticketEdité)
        {

			this.SuspendDrawing();

            if (ticketEdité == null)
                return CResultAErreur.False;

            CResultAErreur result = CResultAErreur.True;

            m_ticketEdite = ticketEdité;
            m_utilisateur = CUtilSession.GetUserForSession(m_ticketEdite.ContexteDonnee);

            m_extLinkField.FillDialogFromObjet(m_ticketEdite);

            // Init panel Infos générales
            InitInfosGenerales();
            // Init Détail Ticket



			this.ResumeDrawing();

            return result;
        }

        //----------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;



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
            //m_ticketEdite.TypeTicket = (CTypeTicket)m_cmbxSelectTypeTicket.ElementSelectionne;

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

                m_extLinkField.FillDialogFromObjet(m_ticketEdite);
            }
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
                        I.T( "This action will definitely close the current Ticket. No more changes will be possible.|686") +"\r\n" + I.T( "Confirm closing|687"),
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

            if (m_ticketEdite.DateClotureTechnique == null)
                result.EmpileErreur(I.T("Technical closing date must be filled|692"));

            if (m_ticketEdite.DateClotureTechnique > DateTime.Now)
                result.EmpileErreur(I.T("Technical closing date could not be later than current date|693"));

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
            m_extLinkField.FillDialogFromObjet(m_ticketEdite);
        }





    }

}
