using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.workflow;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;

using timos.data;
using timos.data.preventives;
using timos.client;
using timos.acteurs;
using timos.securite;
using timos.win32.composants;
using timos.preventives;
using timos.version;
using timos.interventions.preventives;
using sc2i.common.unites.standard;
using sc2i.common.unites;
using timos.data.equipement.consommables;

namespace timos.interventions
{
	public partial class CPanelEditIntervention : UserControl, IControlALockEdition
	{
		private CIntervention m_intervention = null;
		//-----------------------------------------------------
		public CIntervention Intervention
		{
			get
			{
				return m_intervention;
			}
		}


		public CPanelEditIntervention()
		{
			InitializeComponent();
			m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
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

		
		//-------------------------------------------------------------------------
		public CResultAErreur InitChamps(CIntervention intervention)
		{
			CResultAErreur result = m_exLinkField.FillDialogFromObjet(intervention);
			m_intervention = intervention;


			//Initialise le text du lien et le panel de l'onglet opération
            if (intervention.PhaseTicket != null && intervention.PhaseTicket.Ticket != null)
            {
                m_panelLienTicket.Visible = true;
                m_lnkTicket.Text = intervention.PhaseTicket.Ticket.Numero;
                m_lblDescriptionTicket.Text = intervention.PhaseTicket.Ticket.DescriptionGenerale;
				m_panelDescriptionTicket.Visible = true;
            }
            else
            {
                m_panelDescriptionTicket.Visible = false;
                m_panelLienTicket.Visible = false;
            }
			
			//Initialise le combo
			if (!Intervention.IsNew())
			{
				m_gestionnaireModeEdition.SetModeEdition(m_cmbTypeIntervention, TypeModeEdition.Autonome);
				m_cmbTypeIntervention.LockEdition = true;
				InitComboTypeIntervention(false);
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition(m_cmbTypeIntervention, TypeModeEdition.EnableSurEdition);
				m_cmbTypeIntervention.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				InitComboTypeIntervention(true);
			}
			m_cmbTypeIntervention.ElementSelectionne = intervention.TypeIntervention;


			m_selectSite.Init<CSite>("Libelle", true);
			m_selectSite.ElementSelectionne = Intervention.Site;

			InitListeVersions();

			m_gestionnaireTabControl.Reset();

			m_gestionnaireTabControl.ForceInitPageActive();

			return result;
		}

		//----------------------------------------------------------------------------
		private void InitListeVersions()
		{
			CFiltreData filtre = new CFiltreData(CVersionDonnees.c_champTypeVersion + "=@1",
					(int)CTypeVersion.TypeVersion.Previsionnelle);
			m_txtSelectVersionLiee.InitAvecFiltreDeBase<CVersionDonnees>(
				"Libelle",
				filtre,
				false);
			m_txtSelectVersionLiee.ElementSelectionne = Intervention.VersionDonneesAAppliquer;
		}


		//----------------------------------------------------------------------------
		private void InitListesPlannifieurs( bool bMajChamps )
		{
            CFiltreData filtrePlanifieurs = new CFiltreDataAvance(CActeur.c_nomTable,
                "HAS(" + CDonneesActeurUtilisateur.c_nomTable + "." +
                CDonneesActeurUtilisateur.c_champId + ")");

            CFiltreData filtrePrePlanifieurs = filtrePlanifieurs.GetClone();
			
            bool bAppliquerProfils = true;
			if (bAppliquerProfils)
			{
				CTypeIntervention typeIntervention = (CTypeIntervention)m_cmbTypeIntervention.ElementSelectionne;
				if (typeIntervention != null && typeIntervention.ProfilPlanifieur != null)
				{
					CListeObjetsDonnees lstTmp = typeIntervention.ProfilPlanifieur.GetElementsForSource(Intervention, null);
                    CFiltreDataAvance filtreTmp = CFiltreDataAvance.ConvertFiltreToFiltreAvance(CDonneesActeurUtilisateur.c_nomTable, lstTmp.FiltrePrincipal);
                    filtreTmp.ChangeTableDeBase(CActeur.c_nomTable, CDonneesActeurUtilisateur.c_nomTable);
                    filtrePlanifieurs = CFiltreData.GetAndFiltre(filtrePlanifieurs, filtreTmp);
				}
				if (typeIntervention != null && typeIntervention.ProfilPreplanifieur != null)
				{
					CListeObjetsDonnees lstTmp = typeIntervention.ProfilPreplanifieur.GetElementsForSource(Intervention, null);
                    CFiltreDataAvance filtreTmp = CFiltreDataAvance.ConvertFiltreToFiltreAvance(CDonneesActeurUtilisateur.c_nomTable, lstTmp.FiltrePrincipal);
                    filtreTmp.ChangeTableDeBase(CActeur.c_nomTable, CDonneesActeurUtilisateur.c_nomTable);
                    filtrePrePlanifieurs = CFiltreData.GetAndFiltre(filtrePrePlanifieurs, filtreTmp);
				}
			}
			
            m_txtSelectPreplanificateur.InitAvecFiltreDeBase<CActeur>(
                "IdentiteComplete", 
                filtrePrePlanifieurs, 
                true);
			m_txtSelectPlanificateur.InitAvecFiltreDeBase<CActeur>(
                "IdentiteComplete", 
                filtrePlanifieurs, 
                true);
		}

		private void InitIntervenants()
		{
            m_panelIntervenants.Init(Intervention);
		}

		private void InitRessources()
		{
			m_panelRessourcesMaterielles.SuspendDrawing();
			List<CControleAffecteRessourceMaterielle> listeDispo = new List<CControleAffecteRessourceMaterielle>();
			foreach (Control ctrl in m_panelRessourcesMaterielles.Controls)
				if (ctrl is CControleAffecteRessourceMaterielle)
				{
					ctrl.Visible = false;
					listeDispo.Add((CControleAffecteRessourceMaterielle)ctrl);
				}
			if (Intervention.TypeIntervention != null)
			{
				foreach (CContrainte contrainte in Intervention.GetRelationsRessourceAAffecter( typeof(CRessourceMaterielle)))
				{
					CControleAffecteRessourceMaterielle ctrl = null;
					if (listeDispo.Count > 0)
					{
						ctrl = listeDispo[0];
						listeDispo.RemoveAt(0);
					}
					else
					{
						ctrl = new CControleAffecteRessourceMaterielle();
						m_panelRessourcesMaterielles.Controls.Add(ctrl);

					}
					ctrl.Visible = true;
					ctrl.Init(contrainte, (CRessourceMaterielle)Intervention.GetRessourceMateriellesAssociee(contrainte), Intervention);
					//m_gestionnaireModeEdition.SetModeEdition(ctrl, TypeModeEdition.EnableSurEdition);
					ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
					ctrl.Dock = DockStyle.Top;
					ctrl.BringToFront();
				}
			}
			m_panelRessourcesMaterielles.ResumeDrawing();
		}
		private void InitComboTypeIntervention(bool bForcer)
		{
			m_cmbTypeIntervention.Init(
				typeof(CTypeIntervention),
				"Libelle",
				bForcer);
		}
        private void InitSelectListeOperations()
        {
            
            m_txtSelectListeOperation.Init<CListeOperations>(
                "Libelle",
                true);

        }

		//-----------------------------------------------------
		public CResultAErreur MajChamps()
		{
			CResultAErreur result = m_exLinkField.FillObjetFromDialog(m_intervention);
			result = m_gestionnaireTabControl.MAJPages();
			return result;
		}



		//--------------------------------------------------------------------------------
		private void m_cmbTypeIntervention_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_cmbTypeIntervention.ElementSelectionne is CTypeIntervention)
			{
				Intervention.TypeIntervention = (CTypeIntervention)m_cmbTypeIntervention.ElementSelectionne;
				m_panelChampsCustom.ElementEdite = Intervention;
				InitIntervenants();
				InitRessources();
				InitListesPlannifieurs( true );
			}
		}

		private void m_editeurFraction_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			m_panelFraction.Visible = args.Objet is CFractionIntervention;
			if (args.Objet is CFractionIntervention)
			{
				CFractionIntervention fraction = (CFractionIntervention)args.Objet;
				m_dtDebut.Value = fraction.DateDebutPlanifie;
				m_dtFin.Value = fraction.DateFinPlanifiee;
			}
		}

		private void m_editeurFraction_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet is CFractionIntervention)
			{
				CFractionIntervention fraction = (CFractionIntervention)args.Objet;
				fraction.DateDebutPlanifie = m_dtDebut.Value;
				fraction.DateFinPlanifiee = m_dtFin.Value;
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnAddPlanification_LinkClicked(object sender, EventArgs e)
		{
			AjouterFraction();
		}

		private void UpdateFractions()
		{
			m_wndListeFractions.Remplir(Intervention.Fractions);
		}

		//-------------------------------------------------------------------------
		private void m_lnkAjouterCR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ContextMenuStrip menu = new ContextMenuStrip();

			CListeObjetsDonnees liste = Intervention.Fractions;
			liste.Tri = CFractionIntervention.c_champDateDebutPlanifie+" desc";
			foreach (CFractionIntervention fraction in Intervention.Fractions)
			{
				bool bAdd = true;
				foreach (Control ctrl in m_panelCRs.Controls)
					if (ctrl is CControleSaisiesOperations && ((CControleSaisiesOperations)ctrl).FractionIntervention.IsValide() &&
						fraction.Equals(((CControleSaisiesOperations)ctrl).FractionIntervention))
					{
						bAdd = false;
						break;
					}
				if (bAdd)
				{
					ToolStripMenuItem item = new ToolStripMenuItem(fraction.DateDebutPlanifie.ToString("dd/MM/yyyy HH:mm")
								+ "->" + fraction.DateFinPlanifiee.ToString("dd/MM/yyyy HH:mm"));
					item.Tag = fraction;
					item.Click += new EventHandler(OnClickFractionToAdd);
					menu.Items.Add(item);
				}
			}
			ToolStripMenuItem newItem = new ToolStripMenuItem(I.T("Add a date|30202"));
			newItem.Click += new EventHandler(OnAjouterFraction);
			menu.Items.Add(newItem);
			Point pt = new Point(0, m_lnkAjouterCR.Height);
			menu.Show(m_lnkAjouterCR, pt);
		}

		//--------------------------------------------------------------
		void OnAjouterFraction(object sender, EventArgs e)
		{
			CFractionIntervention fraction = AjouterFraction();
			AjouterCR(fraction);
		}
		//--------------------------------------------------------------
		private CFractionIntervention AjouterFraction()
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				DateTime dateDebut = new DateTime(1900, 1, 1);
				foreach (CFractionIntervention fraction in Intervention.Fractions)
					if (fraction.DateFinPlanifiee > dateDebut)
						dateDebut = fraction.DateFinPlanifiee;
				if (Intervention.Fractions.Count == 0)
					dateDebut = DateTime.Now;
				CFractionIntervention fractionNew = new CFractionIntervention(Intervention.ContexteDonnee);
				fractionNew.CreateNewInCurrentContexte();
				fractionNew.Intervention = Intervention;
				fractionNew.DateDebutPlanifie = dateDebut;
                if (m_wndDureePrevue.UnitValue != null)
                    fractionNew.DateFinPlanifiee = dateDebut.AddHours((double)m_wndDureePrevue.UnitValue.ConvertTo(CClasseUniteTemps.c_idH).Valeur);
                else if (Intervention.TypeIntervention != null && Intervention.TypeIntervention.DureeStandardHeures > 0)
                    fractionNew.DateFinPlanifiee = dateDebut.AddHours(Intervention.TypeIntervention.DureeStandardHeures);
                else
                    fractionNew.DateFinPlanifiee = dateDebut.AddHours(1);
				UpdateFractions();
				return fractionNew;
			}
			return null;
		}
		//--------------------------------------------------------------
		void  OnClickFractionToAdd(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem && ((ToolStripMenuItem)sender).Tag is CFractionIntervention)
				AjouterCR((CFractionIntervention)((ToolStripMenuItem)sender).Tag);
		}

		//--------------------------------------------------------------
		private List<CControleSaisiesOperations> m_listeControles = new List<CControleSaisiesOperations>();
		private void InitCRs()
		{

			m_listeFractions = Intervention.Fractions;
			//m_listeFractions.Tri = CFractionIntervention.c_champDateDebut + " desc";

            // Initialise le nombre de pages
            m_nbParPage = 5;
            int nbElements = m_listeFractions.Count;
            if (nbElements == 0)
            {
                m_nbPages = 0;
                m_nPageEnCours = 0;
            }
            else
            {
                m_nbPages = ((int)((nbElements - 1) / m_nbParPage)) + 1;
                m_nPageEnCours = 0;
            }
            m_panelNavigation.Visible = m_nbPages > 1;
            AffichePage(0, false);
			
		}

        private int m_nPageEnCours = 0;
        private int m_nbPages = 0;
        private int m_nbParPage = 0;
        CListeObjetsDonnees m_listeFractions;
        //-------------------------------------------------------------------------
        private bool AffichePage(int nNumPage, bool bMajChampsAvantAffichage)
        {
            if (m_gestionnaireModeEdition.ModeEdition && bMajChampsAvantAffichage)
            {
                CResultAErreur result = MajChamps();
                if (!result)
                {
                    CFormAlerte.Afficher(result.Erreur);
                    return false;
                }
            }
            m_nPageEnCours = nNumPage;
            m_panelCRs.SuspendDrawing();
            foreach (Control ctrl in new ArrayList(m_panelCRs.Controls))
            {
                if (ctrl is CControleSaisiesOperations)
                {
                    m_listeControles.Add((CControleSaisiesOperations)ctrl);
                    ctrl.Visible = false;
                }
            }

            m_lblPageSurNbPages.Text = (m_nPageEnCours+1).ToString() + "/" + m_nbPages.ToString();
            for (int i = m_nPageEnCours * m_nbParPage; i < (m_nPageEnCours * m_nbParPage) + m_nbParPage; i++)
            {
                if (i < m_listeFractions.Count)
                {
                    CFractionIntervention fraction = (CFractionIntervention) m_listeFractions[i];
                    if (fraction.DateDebut != null)
                    {
                        CControleSaisiesOperations ctrlSaisie = null;
                        if (m_listeControles.Count > 0)
                        {
                            ctrlSaisie = m_listeControles[0];
                            m_listeControles.RemoveAt(0);
                            ctrlSaisie.Visible = true;
                        }
                        else
                        {
                            ctrlSaisie = new CControleSaisiesOperations();
                            m_panelCRs.Controls.Add(ctrlSaisie);
                        }
                        ctrlSaisie.Dock = DockStyle.Top;
                        ctrlSaisie.Visible = true;
                        ctrlSaisie.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                        ctrlSaisie.Init(fraction);

                    }
                }
            }
            m_panelCRs.ResumeDrawing();
            return true;

        }

		//--------------------------------------------------------------
		private void AjouterCR(CFractionIntervention fraction)
		{
            if (Intervention.Operations.Count > 0)
            {
                if (CFormAlerte.Afficher(I.T("Fill operations from previsions ?|20137"), EFormAlerteType.Question) == DialogResult.Yes)
                {
                    fraction.InitFromPrevisionnel();
                }
            }
			CControleSaisiesOperations ctrlSaisie = new CControleSaisiesOperations();
			m_panelCRs.Controls.Add(ctrlSaisie);
			ctrlSaisie.Dock = DockStyle.Top;
			ctrlSaisie.BringToFront();
			ctrlSaisie.Visible = true;
			//m_gestionnaireModeEdition.SetModeEdition(ctrlSaisie, TypeModeEdition.EnableSurEdition);
			ctrlSaisie.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			ctrlSaisie.Init(fraction);
			ctrlSaisie.Focus();
		}

        //--------------------------------------------------------------------------------
        private void m_btnDeletePlanification_LinkClicked(object sender, EventArgs e)
		{
			if ( m_wndListeFractions.SelectedItems.Count == 1 )
			{
				CFractionIntervention fraction = (CFractionIntervention)m_wndListeFractions.SelectedItems[0].Tag;
				if ( CFormAlerte.Afficher(I.T("Delete this planification ?|30203"),EFormAlerteType.Question)
					== DialogResult.Yes )
				{
					CResultAErreur  result = fraction.Delete();
					if ( !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
						return;
					}
					UpdateFractions();
					m_editeurFraction.SetObjetEnCoursToNull();
				}
			}
		}

        //--------------------------------------------------------------------------------
        public event EventHandler OnChangeEtatGel = null;
        private void m_panelInfoGel_OnChangeEtatGel(object sender, EventArgs e)
        {
            if (OnChangeEtatGel != null)
                OnChangeEtatGel(this, new EventArgs());
        }

        //--------------------------------------------------------------------------------
        private void m_lnkQuiAppeler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormFloatContacts.AfficherContacts(m_intervention);
		}

		//--------------------------------------------------------------------------------
		private void UpdateVisuForUser()
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(Intervention.ContexteDonnee);
				if (user != null)
				{
					if (!user.Acteur.Equals(m_txtSelectPreplanificateur.ElementSelectionne))
						m_panelPreplanification.LockEdition = true;
					else
						m_panelPreplanification.LockEdition = false;

					if (!user.Acteur.Equals(m_txtSelectPlanificateur.ElementSelectionne))
						m_panelPlanification.LockEdition = true;
					else
						m_panelPlanification.LockEdition = false;
				}
			}
		}

		private void m_txtSelectPreplanificateur_ElementSelectionneChanged(object sender, EventArgs e)
		{
			UpdateVisuForUser();
		}
		private void m_txtSelectPlanificateur_ElementSelectionneChanged(object sender, EventArgs e)
		{
			UpdateVisuForUser();
		}

		private void m_lnkTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if ( m_intervention.PhaseTicket != null )
			{
                CReferenceTypeForm rTypeForm = CFormFinder.GetRefFormToEdit(typeof(CTicket));
                if (rTypeForm != null)
                {
                    IFormNavigable form = rTypeForm.GetForm(m_intervention.PhaseTicket.Ticket) as IFormNavigable;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }
			}
		}

        //---------------------------------------------------------------------------------------
        private void m_lnkAddOperation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AjouterOperationsPrev();

        }

        //--------------------------------------------------------------
        private void AjouterOperationsPrev()
        {
            CResultAErreur result = CResultAErreur.True;

            if (Intervention.ElementAIntervention != null)
            {
                CEditeurOperationsPreventives ctrl = new CEditeurOperationsPreventives();
                m_panelOperationsPrev.Controls.Add(ctrl);
                ctrl.Dock = DockStyle.Fill;
                ctrl.BringToFront();
                ctrl.Visible = true;
                ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                ctrl.Init(Intervention);
                ctrl.Focus();
                m_lnkAddOperation.Enabled = false;
            }
            else
            {
                result.EmpileErreur(I.T( "There is no Site associated to this Intervention|1167"));
                CFormAlerte.Afficher(result.Erreur);
            }
        }

        //--------------------------------------------------------------
        CEditeurOperationsPreventives m_ctrlPrevOperation = null;
        private void InitOperationsPrev()
        {
            m_panelOperationsPrev.SuspendDrawing();

            if (m_panelOperationsPrev.Controls.Count > 0)
            {
                m_ctrlPrevOperation = (CEditeurOperationsPreventives)m_panelOperationsPrev.Controls[0];
                m_ctrlPrevOperation.Visible = false;
            }

            if (Intervention.Operations.Count > 0)
            {
                CEditeurOperationsPreventives ctrl = null;
                if (m_ctrlPrevOperation != null)
                {
                    ctrl = m_ctrlPrevOperation;
                    m_ctrlPrevOperation = null;
                }
                else
                {
                    ctrl = new CEditeurOperationsPreventives();
                    m_panelOperationsPrev.Controls.Add(ctrl);
                }
                ctrl.Dock = DockStyle.Fill;
                ctrl.BringToFront();
                ctrl.Visible = true;
                ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                ctrl.Init(Intervention);
                ctrl.Focus();
                m_lnkAddOperation.Enabled = false;
            }
            else
            {
                m_ctrlPrevOperation = null;
                foreach (Control control in m_panelOperationsPrev.Controls)
                {
                    if (control is CEditeurOperationsPreventives)
                        m_panelOperationsPrev.Controls.Remove(control);
                }
            }

            m_panelOperationsPrev.ResumeDrawing();

        }

        //----------------------------------------------------------------------
        private void m_lnkAjouterListeOp_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectListeOperation.ElementSelectionne == null)
            {
                return;
            }

            CListeOperations listeOperation = (CListeOperations)m_txtSelectListeOperation.ElementSelectionne;

            //CListeObjetsDonnees listeExistants = Intervention.RelationsListesOperations;
            //int index = listeExistants.Count;
            //listeExistants.Filtre = new CFiltreData(CListeOperations.c_champId + "=@1",
            //    listeOperation.Id);
            //if (listeExistants.Count != 0)
            //{
            //    MessageBox.Show(I.T( "Can not add this operation list|1160"));
            //    return;
            //}
            m_txtSelectListeOperation.ElementSelectionne = null;
            CIntervention_ListeOperations rel = new CIntervention_ListeOperations(Intervention.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.ListeOperations= listeOperation;
            rel.Intervention = Intervention;
            rel.Libelle = listeOperation.Libelle;
            rel.IsBasculeEnOperationsPrev = false;

            ListViewItem item = new ListViewItem();
            m_lstListeOperations.Items.Add(item);
            m_lstListeOperations.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_lstListeOperations.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;

            InitSelectListeOperations();

        }
        private void m_lnkSupprimerListeOp_LinkClicked(object sender, EventArgs e)
        {
            if (m_lstListeOperations.SelectedItems.Count != 1)
                return;

            CIntervention_ListeOperations rel = (CIntervention_ListeOperations)m_lstListeOperations.SelectedItems[0].Tag;

            m_gestionnaireEditionListeOp.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_lstListeOperations.SelectedItems.Count == 1)
            {
                if (m_lstListeOperations.SelectedItems[0] != null)
                    m_lstListeOperations.SelectedItems[0].Remove();
            }
            InitSelectListeOperations();

        }    
   
        //--------------------------------------------------------------------------------------------------
        CIntervention_ListeOperations m_interListeOp = null;
        private void m_lnkCreerOperationsDeListe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;

            result = MajChamps();
            if(result)
                result = m_interListeOp.BasculerListeEnOperationsPrevisionnelles();

            if (!result)
                CFormAlerte.Afficher(result.Erreur);
			else
				InitOperationsPrev();
        }

        //--------------------------------------------------------------------------------------------------
        private void m_gestionnaireEditionListeOp_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            m_panelInfosListeOp.Visible = args.Objet is CIntervention_ListeOperations;
            if (args.Objet is CIntervention_ListeOperations)
            {
                m_interListeOp = (CIntervention_ListeOperations)args.Objet;
                m_extLinkListeOperations.FillDialogFromObjet((CIntervention_ListeOperations)args.Objet);
            }
            else
                m_interListeOp = null;
        }
        private void m_gestionnaireEditionListeOp_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CIntervention_ListeOperations interListeOp = (CIntervention_ListeOperations)args.Objet;
                m_extLinkListeOperations.FillObjetFromDialog(interListeOp);
            }
        }

		//---------------------------- TAB CONTROL --------------------------
		private CResultAErreur m_gestionnaireTabControl_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

			using (CWaitCursor waiter = new CWaitCursor())
			{

				if (page == tb_checklist)
				{
					m_panelCheckList.InitChamps(m_intervention);
				}
				else if (page == tb_fiche)
				{
					m_panelChampsCustom.ElementEdite = Intervention;
				}
				else if (page == tb_operations)
				{
					int nb = Intervention.RelationsListesOperations.CountNoLoad;
					int nb2 = Intervention.RelationsListesOperations.Count;
					m_gestionnaireEditionListeOp.ObjetEdite = Intervention.RelationsListesOperations;
					InitSelectListeOperations();
					InitOperationsPrev();

					m_panelInfosListeOp.Visible = m_gestionnaireEditionListeOp.ObjetEnCours is CIntervention_ListeOperations;					
				}
				else if (page == tb_planification)
				{
					m_dtDebutPreplanifier.Value = Intervention.DateDebutPrePlanifiee;
					m_dtFinPreplanification.Value = Intervention.DateFinPrePlanifiee;
					UpdateFractions();

					CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(Intervention.ContexteDonnee);
					if (Intervention.IsNew())
					{
						if (Intervention.UserPreplanifieur == null)
							Intervention.UserPreplanifieur = user;
						if (Intervention.UserPlanifieur == null)
							Intervention.UserPlanifieur = user;
					}

					InitListesPlannifieurs(false);

					if (Intervention.UserPreplanifieur != null)
						m_txtSelectPreplanificateur.ElementSelectionne = Intervention.UserPreplanifieur.Acteur;
					if (Intervention.UserPlanifieur != null)
						m_txtSelectPlanificateur.ElementSelectionne = Intervention.UserPlanifieur.Acteur;

					UpdateVisuForUser();

                    m_wndDureePrevue.UseValueFormat = false;
                    m_wndDureePrevue.DefaultFormat = CGestionnaireUnites.GetUnite(CClasseUniteTemps.c_idH).LibelleCourt;
                    if (Intervention.DureePrevisionnelle != null)
                        m_wndDureePrevue.UnitValue = new CValeurUnite(Intervention.DureePrevisionnelle, CClasseUniteTemps.c_idH);

                    m_txtNbOperateursPrévus.IntValue = Intervention.NbOperateurSPrevus;

                    m_txtTauxHorairePrévu.InitAvecFiltreDeBase<CTypeConsommable>(
                        "Libelle",
                        new CFiltreData(CTypeConsommable.c_champClasseUniteString + "=@1",
                            CClasseUniteTemps.c_idClasse),
                            false);
                    m_txtTauxHorairePrévu.ElementSelectionne = Intervention.TauxHorairePrevu;

					m_panelFraction.Visible = m_editeurFraction.ObjetEnCours is CFractionIntervention;
				}
				else if (page == tb_realisation)
				{
					InitCRs();
					m_panelInfoGel.Init(Intervention);
				}
				else if (page == tb_ressources)
				{
					InitIntervenants();
					InitRessources();
				}

			}
			return result;
		}
		private CResultAErreur m_gestionnaireTabControl_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

			if (page == tb_checklist)
			{
				result = m_panelCheckList.MajChamps();
			}
			else if (page == tb_fiche)
			{
				result = m_panelChampsCustom.MAJ_Champs();
			}
			else if (page == tb_operations)
			{
				result = m_gestionnaireEditionListeOp.ValideModifs();

				// Traite tous les controls d'opérations prévisionnelles
				foreach (Control ctrl in m_panelOperationsPrev.Controls)
				{
                    if (ctrl is CEditeurOperationsPreventives)
					{
                        result = ((CEditeurOperationsPreventives)ctrl).MajChamps();
						if (!result)
							return result;
					}
				}
				Intervention.VersionDonneesAAppliquer = (CVersionDonnees)m_txtSelectVersionLiee.ElementSelectionne;
			}
			else if (page == tb_planification)
			{
				Intervention.DateDebutPrePlanifiee = m_dtDebutPreplanifier.Value;
				Intervention.DateFinPrePlanifiee = m_dtFinPreplanification.Value;

                if (m_wndDureePrevue.UnitValue != null)
                    Intervention.DureePrevisionnelle = m_wndDureePrevue.UnitValue.ConvertTo(CClasseUniteTemps.c_idH).Valeur;
                else
                    Intervention.DureePrevisionnelle = 0;

                Intervention.NbOperateurSPrevus = m_txtNbOperateursPrévus.IntValue;
                Intervention.TauxHorairePrevu = m_txtTauxHorairePrévu.ElementSelectionne as CTypeConsommable;

				CActeur acteur = (CActeur)m_txtSelectPreplanificateur.ElementSelectionne;
				if (acteur != null)
					Intervention.UserPreplanifieur = acteur.Utilisateur;
				else
					Intervention.UserPreplanifieur = null;

				acteur = (CActeur)m_txtSelectPlanificateur.ElementSelectionne;
				if (acteur != null)
					Intervention.UserPlanifieur = acteur.Utilisateur;
				else
					Intervention.UserPlanifieur = null;

				result = m_editeurFraction.ValideModifs();
			}
			else if (page == tb_realisation)
			{
				// Traite tous les controles de Saisie de compte rendu de Fraction d'intervention
				foreach (Control ctrl in m_panelCRs.Controls)
				{
					if (ctrl is CControleSaisiesOperations)
					{
						result = ((CControleSaisiesOperations)ctrl).Maj_Champs();
						if (!result)
							return result;
					}
				}
			}
			else if (page == tb_ressources)
			{
                result = m_panelIntervenants.MajChamps();
			}
			return result;
		}

		#region Selection site
		private void m_selectSite_ElementSelectionneChanged(object sender, EventArgs e)
		{
			Intervention.Site = (CSite)m_selectSite.ElementSelectionne;


		}

		//------------------------- OLD ----------------------------
		private void m_lnkElementAIntervention_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Intervention.ElementAIntervention != null)
			{
                //Type tpForm = CFormFinder.GetTypeFormToEdit(Intervention.ElementAIntervention.GetType());
                //if (tpForm != null && typeof(CFormEditionStandard).IsAssignableFrom(tpForm))
                //{
                //    CFormEditionStandard form = (CFormEditionStandard)Activator.CreateInstance(tpForm, new object[] { Intervention.ElementAIntervention });
                //    CTimosApp.Navigateur.AffichePage(form);
                //    return;
                //}
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(Intervention.ElementAIntervention.GetType());
                if (refTypeForm != null)
                {
                    CFormEditionStandard form = refTypeForm.GetForm(Intervention.ElementAIntervention as CObjetDonneeAIdNumeriqueAuto) as CFormEditionStandard;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }

			}
			else
			{
				ChangerElement();
			}
		}
		private void m_lnkChangeElement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			ChangerElement();
		}
		private void ChangerElement()
		{
			//Sélection du type 
			CInfoClasseDynamique[] lesTypes = DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(IElementAIntervention), typeof(CObjetDonneeAIdNumerique));
			if (lesTypes.Length != 0)
			{
				Type tp = lesTypes[0].Classe;
				if (lesTypes.Length > 1)
				{
					Point pt = m_lnkElementAIntervention.Location;
					pt.Offset(0, m_lnkElementAIntervention.Height);
					pt = PointToScreen(pt);
					List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>(lesTypes);
					tp = CFormSelectType.SelectType(pt, lstTypes, "Intervention sur ");
				}
				if (tp != null)
				{
					Type tpForm = CFormFinder.GetTypeFormToList(tp);
					if (tpForm != null && typeof(sc2i.win32.data.navigation.CFormListeStandard).IsAssignableFrom(tpForm))
					{
						IFormNavigable form = (IFormNavigable)Activator.CreateInstance(tpForm, new object[0]);
						CObjetDonnee obj = CFormNavigateurPopupListe.SelectObject((CFormListeStandard)form, null, "TASK_ELT");
						if (obj != null)
						{
							Intervention.ElementAIntervention = (CObjetDonneeAIdNumerique)obj;
							UpdateLibelleElement((IElementAIntervention)obj);
						}
					}
					else
						CFormAlerte.Afficher("Le système ne sait pas Editer les éléments de type " + DynamicClassAttribute.GetNomConvivial(tp), EFormAlerteType.Erreur);
				}
			}
		}
		private void UpdateLibelleElement(IElementAIntervention element)
		{
			string strVal = DescriptionFieldAttribute.GetDescription(element);
			if (strVal == null || strVal == "")
				strVal = element.DescriptionElement;
			m_lnkElementAIntervention.Text = strVal;
		}
		#endregion

		//--------------------------------------------------------------------
		private void m_lnkVersionAssocied_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Intervention.VersionDonneesAAppliquer != null)
			{
				CTimosApp.Navigateur.AffichePage(new CFormEditionVersionDonnees(Intervention.VersionDonneesAAppliquer));
			}
		}

		//Se déclenche quand le panel a besoin de sauvegarder les modifications
		public event CancelEventHandler SaveRequired;

		//--------------------------------------------------------------------
		private void m_lnkEditerModificationsPrevisionnelles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
				Intervention.VersionDonneesAAppliquer = (CVersionDonnees)m_txtSelectVersionLiee.ElementSelectionne;
			if (Intervention.VersionDonneesAAppliquer == null)
			{
				if (!m_gestionnaireModeEdition.ModeEdition)
				{
					CFormAlerte.Afficher(I.T("No planified modification for that intervention|1359"), EFormAlerteType.Erreur);
					return;
				}
				//Si nouvelle inter, il faut la valider
				if (CFormAlerte.Afficher(I.T("You have to save your intervention before associate it to planified modification. Would you like to save now ?|1356"),
					EFormAlerteType.Question) == DialogResult.No)
					return;
				if (SaveRequired != null)
				{
					CancelEventArgs args = new CancelEventArgs();
					args.Cancel = false;
					SaveRequired(this, args);
					if (args.Cancel)
						return;
				}
				else
				{
					CFormAlerte.Afficher("Error", EFormAlerteType.Erreur);
					return;
				}

				CResultAErreur result = CResultAErreur.True;

				//Création de la version
				CVersionDonnees version = CFormCreateVersionPourIntervention.GetVersionForInter(Intervention);
				if (version != null)
				{
					if (version.IsNew())
					{
						result = version.CommitEdit();
						if (!result)
						{
							CFormAlerte.Afficher(I.T("Error while creating data version|1357"), EFormAlerteType.Erreur);
							return;
						}
					}
					
					//Affectation de la version à l'intervention
					CIntervention intervention = Intervention;
					bool bStartEdit = intervention.ContexteDonnee.IsEnEdition;
					if ( !bStartEdit )
						intervention.BeginEdit();
					intervention.VersionDonneesAAppliquer = version;
					if ( !bStartEdit )
						result = intervention.CommitEdit();
					if ( !result )
					{
						intervention.CancelEdit();
						CFormAlerte.Afficher(I.T("Error while affecting version do intervention|1358"), EFormAlerteType.Erreur);
					}
					InitChamps(intervention);	
				}
			}

			//La version de données est maintenant normallement associée à l'intervention
			CSite site = Intervention.Site;
			if ( site == null )
			{
				return;
			}
			if ( Intervention.VersionDonneesAAppliquer == null )
				return;
			//Crée un contexte dans la version
			using ( CContexteDonnee contexte = new CContexteDonnee ( Intervention.ContexteDonnee.IdSession, true, false ))
			{
				CResultAErreur result = contexte.SetVersionDeTravail ( Intervention.VersionDonneesAAppliquer.Id, true );
				if (!result)
				{
					CFormAfficheErreur.Show(result.Erreur);
					return;
				}

				site = (CSite)site.GetObjetInContexte ( contexte );
				CFormNavigateurPopup.Show ( new CFormEditionSite ( site ) );
			}

		}

		private void m_tabControl_SelectionChanged(object sender, EventArgs e)
		{

		}

		private void m_txtSelectVersionLiee_OnSelectedObjectChanged(object sender, EventArgs e)
		{
		}


        private void m_lnkPremierePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_nPageEnCours < 1)
                return;
            AffichePage(0, true);

        }

        private void m_lnkPrecedent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_nPageEnCours < 1)
                return;
            AffichePage(m_nPageEnCours - 1, true);

        }

        private void m_lnkSuivant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_nPageEnCours >= m_nbPages - 1)
                return;
            AffichePage(m_nPageEnCours + 1, true);
        }

        private void m_lnkDernierePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_nPageEnCours >= m_nbPages - 1)
                return;
            AffichePage(m_nbPages - 1, true);

        }

        private void m_lnkPlanningGrid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.AffichePage(new CFormPlanifierInterventions(Intervention));
        }
	}
}


