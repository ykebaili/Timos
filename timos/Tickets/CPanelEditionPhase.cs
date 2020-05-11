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
    public partial class CPanelEditionPhase : UserControl, IControlALockEdition
    {
        private CPhaseTicket m_phaseEdite;

        public CPanelEditionPhase()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        bool m_bIsInitialising = false;
        public CResultAErreur InitPanel(CPhaseTicket phase)
        {
            m_bIsInitialising = true;

            if(phase == null)
                return CResultAErreur.False;
            
            if(phase.TypePhase == null)
                return CResultAErreur.False;

            if(phase.Ticket == null)
                return CResultAErreur.False;


            CResultAErreur result = CResultAErreur.True;
            m_phaseEdite = phase;

            result = m_extLinkField.FillDialogFromObjet(m_phaseEdite);

            if (result)
                result = InitListeInterventions();
            if (result)
                result = InitPanelFormulaire();

            InitInfosGel();

            m_ctrlSaisiesOperations.Init(m_phaseEdite);
            m_controlSaisieInfosCloture.Init(m_phaseEdite.Ticket);

            if (!m_phaseEdite.CanEdit())
                m_lblMessageEntete.Text = I.T( "You do not have permission to edit this Phase|532");
            else
                m_lblMessageEntete.Text = "";

            UpdateVisuelBoutons();

            m_bIsInitialising = false;
            
            return result;
        }

        //-------------------------------------------------------------------------
        private void UpdateVisuelBoutons()
        {
            
            if (m_phaseEdite.TypePhase != null &&
                m_phaseEdite.TypePhase.RelationTypesIntervention.Count == 0 )
            {
                m_lnkAjouterIntervention.Enabled = false;
                return;
            }

            m_lnkAjouterIntervention.Enabled = m_gestionnaireModeEdition.ModeEdition;

        }


        //-------------------------------------------------------------------------
        public CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_phaseEdite != null)
            {
                result = m_extLinkField.FillObjetFromDialog(m_phaseEdite);
                if (result)
                    result = m_ctrlSaisiesOperations.Maj_Champs();                
                if (result)
                    result = m_controlSaisieInfosCloture.MAJ_Champs();
                if (result)
                    result = m_panelFormulaireSurTypePhase.AffecteValeursToElement();
                
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur InitPanelFormulaire()
        {
            CResultAErreur result = CResultAErreur.True;
            if(m_phaseEdite.TypePhase.Formulaire != null)
            {
                m_panelFormulaireSurTypePhase.InitPanel(
                    m_phaseEdite.TypePhase.Formulaire.Formulaire,
                    m_phaseEdite);
                m_panelFormulaireSurTypePhase.Visible = true;
            }
            else
            {
                m_panelFormulaireSurTypePhase.Visible = false;
            }

            return result;
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
        private void m_lnkTypePhase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Affiche le formulaire d'édition du Type de phase
            CTypePhase typePh = m_phaseEdite.TypePhase;
            try
            {
                CTimosApp.Navigateur.AffichePage((IFormNavigable)Activator.CreateInstance(
                    typeof(CFormEditionTypePhaseTicket),
                    new object[] { typePh }));
            }
            catch (Exception)
            {
            }
        }

        //-----------------------------------------------------------------------------------
		private void m_lnkQuiAppeler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			MAJ_Champs();
			CFormFloatContacts.AfficherContacts(m_phaseEdite);
		}

        //-----------------------------------------------------------------------------------
        public event EventHandler OnDebutPhase;
        private void SomthingChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitialising && m_phaseEdite.DateDebut == null)
            {
                m_phaseEdite.DateDebut = DateTime.Now;
                if(OnDebutPhase != null)
                    OnDebutPhase(m_phaseEdite, new EventArgs());
            }
        }

        //-----------------------------------------------------------------------------------
        private void m_lnkAjouterIntervention_LinkClicked(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            CListeObjetsDonnees listeRelSites;
            if (m_phaseEdite.Ticket != null)
            {
                listeRelSites = m_phaseEdite.Ticket.RelationsSitesListe;
                ArrayList listeSites = new ArrayList();
                foreach (CRelationTicket_Site rel in listeRelSites)
                    listeSites.Add(rel.Site);
                if (listeSites.Count == 0)
                {
                    CFormAlerte.Afficher(I.T( "There is no Site associated to the current Ticket|533"));
                    return;
                }
                foreach (CSite site in listeSites)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem(site.Libelle);
                    item.Tag = site;
                    item.DropDownOpening += new EventHandler(menuAjouterInterventionItem_DropDownOpening);
                    menu.Items.Add(item);
                }
                Point position = m_lnkAjouterIntervention.Location;
                position.X = 0;
                position.Y = m_lnkAjouterIntervention.Height;
                menu.Show(m_lnkAjouterIntervention, position);
            }
        }

        //-----------------------------------------------------------------------------------
        void menuAjouterInterventionItem_DropDownOpening(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = ((ToolStripMenuItem)sender);
                object site = item.Tag;
                if (site is CSite)
                {
                    // initialise sous menu
                    CListeObjetsDonnees listeRel = m_phaseEdite.TypePhase.RelationTypesIntervention;
                    if (listeRel.Count == 0)
                    {
                        item.GetCurrentParent().Hide();
                        CFormAlerte.Afficher(I.T( "There is non possible Intervention defined on this Phase Type|534"), EFormAlerteType.Exclamation);
                        return;
                    }
                    item.DropDownItems.Clear();
                    foreach (CRelationTypePhaseTicket_TypeIntervention rel in listeRel)
                    {
                        ToolStripMenuItem sousItem = new ToolStripMenuItem(rel.TypeIntervention.Libelle);
                        sousItem.Tag = new object[] {site, rel.TypeIntervention};
                        sousItem.Click += new EventHandler(sousItem_Click);
                        item.DropDownItems.Add(sousItem);
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------
        void sousItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = ((ToolStripMenuItem)sender);
                object[] tag = (object[]) item.Tag;

                CSite site = (CSite) tag[0];
                CTypeIntervention typeInter = (CTypeIntervention) tag[1];

                if (site != null && typeInter != null)
                    StartNewIntervention(site, typeInter);
                else
                    CFormAlerte.Afficher(I.T( "Internal Error|30"), EFormAlerteType.Erreur);
            }
         }

        //-----------------------------------------------------------------------------------
        private CResultAErreur StartNewIntervention(CSite site, CTypeIntervention typeInter)
        {
            CResultAErreur result = CResultAErreur.True;
            // Créer ici une nouvelle intervention
            CIntervention nouvelleInter = new CIntervention(m_phaseEdite.ContexteDonnee);
            nouvelleInter.CreateNew();
            nouvelleInter.PhaseTicket = m_phaseEdite;
            nouvelleInter.TypeIntervention = typeInter;
            nouvelleInter.ElementAIntervention = site;

            CFormNavigateurPopup.Show(new CFormEditionIntervention(nouvelleInter), FormWindowState.Maximized);
            if (nouvelleInter.IsValide())
            {
                m_phaseEdite.DateDebut = DateTime.Now;
                // Mettre à jour la liste des Interventions
                InitListeInterventions();
            }

            return result;
        }

        //-----------------------------------------------------------------------------------
        private CResultAErreur InitListeInterventions()
        {
            CResultAErreur result = CResultAErreur.True;

            CListeObjetsDonnees listeInterventions;
            if (!m_chkAfficherQueLesIntersDeLaPhase.Checked)
            {
                listeInterventions = new CListeObjetsDonnees(m_phaseEdite.ContexteDonnee, typeof(CIntervention));
                List<string> listeIds = new List<string>();
                foreach (CPhaseTicket phase in m_phaseEdite.Ticket.PhasesListe)
                {
                    foreach (CIntervention inter in phase.InterventionsListe)
                    {
                        listeIds.Add(inter.Id.ToString());
                    }
                }
                string strIds = string.Join(",", listeIds.ToArray());
                if (strIds.Length == 0)
                    listeInterventions.Filtre = new CFiltreDataImpossible();
                else
                {
                    listeInterventions.InterditLectureInDB = true;
                    listeInterventions.Filtre = new CFiltreData(
                        CIntervention.c_champId + " in (" + strIds + ")");
                }
            }
            else
            {
                listeInterventions = m_phaseEdite.InterventionsListe;
            }
            m_panelListeInterventions.InitFromListeObjets(
                listeInterventions,
                typeof(CIntervention),
                typeof(CFormEditionIntervention),
                m_phaseEdite,
                "PhaseTicket");

            return result;

        }

        //--------------------------------------------------------------------------------
        private CResultAErreur InitInfosGel()
        {
            CResultAErreur result = CResultAErreur.True;

            m_panelInfoGel.Init(m_phaseEdite);
            if (m_phaseEdite.Ticket != null)
            {
                if (m_phaseEdite != m_phaseEdite.Ticket.PhaseEnCours)
                    m_panelInfoGel.LockEdition = true;
                else
                    m_panelInfoGel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
            }
            return result;
        }

 


        //--------------------------------------------------------------------------------
        public event EventHandler OnChangeEtatGel = null;
        private void m_panelInfoGel_OnChangeEtatGel(object sender, EventArgs e)
        {
            if(OnChangeEtatGel != null)
                OnChangeEtatGel(this, new EventArgs());
        }

        //--------------------------------------------------------------------------------
        private void m_chkAfficherQueLesIntersDeLaPhase_CheckedChanged(object sender, EventArgs e)
        {
            InitListeInterventions();
        }


    }
}
