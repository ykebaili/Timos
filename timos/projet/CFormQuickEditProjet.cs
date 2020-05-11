using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common;
using timos.data;
using sc2i.data;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.multitiers.client;
using timos.securite;

namespace timos.projet
{
    public partial class CFormQuickEditProjet : Form, IFormEditObjetDonnee
    {
        private CProjet m_projet = null;
        private CListeRestrictionsUtilisateurSurType m_listeRestrictions = new CListeRestrictionsUtilisateurSurType();
        private CFormEditionStandard m_formAppelante = null;
        private CGestionnaireReadOnlySysteme m_gestionnaireReadOnly = new CGestionnaireReadOnlySysteme();

        //---------------------------------------------------
        public CFormQuickEditProjet()
        {
            InitializeComponent();
            CWin32Traducteur.Translate(this);
        }

        //---------------------------------------------------
        public void AddRestrictionComplementaire(string strTag, CListeRestrictionsUtilisateurSurType restrictions, bool bApplicationImmediate)
        {
            //Ne fait rien gère tout seul
        }

        //---------------------------------------------------
        public static void EditeProjet(
            CProjet projet, 
            bool bModeEdition, 
            CFormEditionStandard formAppelante)
        {
            CFormQuickEditProjet form = new CFormQuickEditProjet();
            form.m_formAppelante = formAppelante;
            form.m_gestionnaireModeEdition.ModeEdition = bModeEdition;
            form.m_projet = projet;

            IInfoUtilisateur info = CTimosApp.SessionClient.GetInfoUtilisateur();
            if ( info != null )
            {
                CRestrictionUtilisateurSurType restriction = info.GetRestrictionsSurObjet ( projet, projet.ContexteDonnee.IdVersionDeTravail );
                if ( restriction != null )
                    form.m_listeRestrictions.SetRestriction ( restriction );
            }
            CListeRestrictionsUtilisateurSurType restrictionsEnPlus = CDroitEditionType.GetDroits ( projet );
            if ( restrictionsEnPlus != null )
                form.m_listeRestrictions.Combine ( restrictionsEnPlus );

            CRestrictionUtilisateurSurType rest = form.m_listeRestrictions.GetRestriction(typeof(CProjet));

            form.m_gestionnaireModeEdition.ModeEdition = bModeEdition && (rest.RestrictionGlobale & ERestriction.ReadOnly) != ERestriction.ReadOnly;

            form.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2 - form.Width / 2,
                Screen.PrimaryScreen.WorkingArea.Height / 2 - form.Height / 2);
            form.ShowDialog();
            form.Dispose();
        }

        //---------------------------------------------------
        private void CFormQuickEditProjet_Load(object sender, EventArgs e)
        {
            CApplicateurRestrictions.AppliqueRestrictions(this, m_listeRestrictions, m_gestionnaireReadOnly);
            InitChamps();
        }

        private CProjet Projet
        {
            get{
                return m_projet;
            }
        }

        private void InitChamps()
        {
            m_extLinkField.FillDialogFromObjet(m_projet);

            //CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeProjet));
            if (Projet.Projet != null && Projet.Projet.TypeProjet != null)
                m_selectTypeProjet.Init(Projet.Projet.TypeProjet.TypesProjetsFilsPossibles, "Libelle", true);
            else if (Projet.Projet == null)
                m_selectTypeProjet.Init(
                    new CListeObjetsDonnees(Projet.ContexteDonnee, typeof(CTypeProjet), new CFiltreData(CTypeProjet.c_champNeedHierarchy + "=@1", false)),
                    "Libelle",
                    true);
            else
                m_selectTypeProjet.Init(typeof(CTypeProjet), null, "Libelle", true);

            m_selectTypeProjet.ElementSelectionne = Projet.TypeProjet;

            // Dates prévisionnelles
            if (Projet.DateDebutPlanifiee != null)
                m_dtpDatesPrevisionnelles.StartDate = Projet.DateDebutPlanifiee.Value;
            else
                m_dtpDatesPrevisionnelles.StartDate = DateTime.Now;
            if (Projet.DateFinPlanifiee != null)
                m_dtpDatesPrevisionnelles.EndDate = Projet.DateFinPlanifiee.Value;
            else if (Projet.TypeProjet != null && Projet.TypeProjet.DureeDefautHeures > 0.0)
                m_dtpDatesPrevisionnelles.EndDate = m_dtpDatesPrevisionnelles.StartDate.AddHours(Projet.TypeProjet.DureeDefautHeures);
            else
                m_dtpDatesPrevisionnelles.EndDate = m_dtpDatesPrevisionnelles.StartDate.AddDays(7);

            m_dtpDatesPrevisionnelles.Libelle1 = I.T("Planned start date|10078");
            m_dtpDatesPrevisionnelles.Libelle2 = I.T("Planned end date|10079");

            // Dates réelles
            if (Projet.DateDebutReel != null)
                m_dtpDateDebutReelle.Value = new CDateTimeEx((DateTime)Projet.DateDebutReel);
            else
                m_dtpDateDebutReelle.Value = null;

            if (Projet.DateFinRelle != null)
                m_dtpDateFinReelle.Value = new CDateTimeEx((DateTime)Projet.DateFinRelle);
            else
                m_dtpDateFinReelle.Value = null;

            m_chkDatesAuto.Checked = Projet.DateDebutAuto;

            m_extLinkField.FillDialogFromObjet(Projet);

            m_dtpDateDebutReelle.LockEdition = !m_gestionnaireModeEdition.ModeEdition || Projet.ProjetsFils.Count > 0;
            m_dtpDateFinReelle.LockEdition = m_dtpDateDebutReelle.LockEdition;
            m_dtpDatesPrevisionnelles.LockEdition = m_dtpDateFinReelle.LockEdition;
            RefreshLinkSousTypes();
            m_PanelChamps.ElementEdite = Projet;
            m_PanelChamps.AppliqueRestrictions(m_listeRestrictions, m_gestionnaireReadOnly);
        }

        //----------------------------------------------------------------------------------------
        private void RefreshLinkSousTypes()
        {
            if (Projet.RelationsSousTypes.Count > 0)
            {
                m_lnkSubTypes.Text = I.T("SubTypes|20585") + " (" + Projet.RelationsSousTypes.Count + ")";
            }
            else
            {
                m_lnkSubTypes.Text = I.T("SubTypes|20585");
            }
        }

        //----------------------------------------------------------------------------------------
        private void m_lnkSubTypes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_menuSousTypes.Items.Clear();
            CTypeProjet typeProjet = m_selectTypeProjet.ElementSelectionne as CTypeProjet;
            HashSet<CTypeProjet> typeProjetsInMenu = new HashSet<CTypeProjet>();
            if (typeProjet != null)
            {
                if (m_gestionnaireModeEdition.ModeEdition)
                {
                    foreach (CRelationTypeProjet_SousTypeProjet rel in typeProjet.RelationsSousTypesProjetsPossibles)
                    {
                        ToolStripMenuItem itemSousType = new ToolStripMenuItem(rel.SousTypeProjet.Libelle);
                        itemSousType.Tag = rel.SousTypeProjet;
                        itemSousType.Click += new EventHandler(itemSousType_Click);
                        itemSousType.Checked = Projet.IsDefiniPar(rel.SousTypeProjet);
                        m_menuSousTypes.Items.Add(itemSousType);
                        typeProjetsInMenu.Add(rel.SousTypeProjet);
                    }
                }
                foreach (CProjet_SousType st in Projet.RelationsSousTypes)
                {
                    if (!typeProjetsInMenu.Contains(st.SousType))
                    {
                        ToolStripMenuItem itemSousType = new ToolStripMenuItem(st.SousType.Libelle);
                        itemSousType.Tag = st.SousType;
                        itemSousType.Click += new EventHandler(itemSousType_Click);
                        itemSousType.Checked = Projet.IsDefiniPar(st.SousType);
                        m_menuSousTypes.Items.Add(itemSousType);
                        typeProjetsInMenu.Add(st.SousType);
                        if (m_gestionnaireModeEdition.ModeEdition)
                            itemSousType.BackColor = Color.Red;
                        itemSousType.Enabled = m_gestionnaireModeEdition.ModeEdition;
                    }
                }
            }
            if (m_menuSousTypes.Items.Count > 0)
            {
                m_menuSousTypes.Show(m_lnkSubTypes, new Point(0, m_lnkSubTypes.Height));
            }
        }

        //----------------------------------------------------------------------------------------
        void itemSousType_Click(object sender, EventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                CTypeProjet type = item != null ? item.Tag as CTypeProjet : null;
                if (type != null)
                {
                    if (Projet.IsDefiniPar(type))
                        Projet.RemoveSubType(type);
                    else
                        Projet.AddSubType(type);
                }
                m_PanelChamps.ElementEdite = Projet;
            }
            RefreshLinkSousTypes();
        }

        //-------------------------------------------------------------------------
        private void m_selectTypeProjet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_selectTypeProjet.ElementSelectionne != null)
                Projet.TypeProjet = (CTypeProjet)m_selectTypeProjet.ElementSelectionne;
            m_PanelChamps.ElementEdite = Projet;
            RefreshLinkSousTypes();
        }


        //----------------------------------------------------------------------------------------
        private CResultAErreur MajChamps()
        {
            CResultAErreur result = m_extLinkField.FillObjetFromDialog(Projet);
            result &= m_PanelChamps.MAJ_Champs();
            
            if (m_selectTypeProjet.ElementSelectionne != null)
                Projet.TypeProjet = (CTypeProjet)m_selectTypeProjet.ElementSelectionne;

            Projet.DateDebutPlanifiee = m_dtpDatesPrevisionnelles.StartDate;
            Projet.DateFinPlanifiee = m_dtpDatesPrevisionnelles.EndDate;

            Projet.DateDebutReel = m_dtpDateDebutReelle.Value != null ? (DateTime?)m_dtpDateDebutReelle.Value.DateTimeValue : null;
            Projet.DateFinRelle = m_dtpDateFinReelle.Value != null ? (DateTime?)m_dtpDateFinReelle.Value.DateTimeValue : null;

            Projet.DateDebutAuto = m_chkDatesAuto.Checked;
            result &= Projet.VerifieDonnees(false);

            return result;
        }




        #region IFormEditObjetDonnee Membres

        //------------------------------------------------------------------------------
        public void AnnulerModifications()
        {
            if (m_formAppelante != null)
                m_formAppelante.AnnulerModifications();
        }

        //------------------------------------------------------------------------------
        public bool EtatEdition
        {
            get { return m_gestionnaireModeEdition.ModeEdition; }
        }

        //------------------------------------------------------------------------------
        public CObjetDonnee GetObjetEdite()
        {
            return Projet;
        }

        //------------------------------------------------------------------------------
        public event EventHandler ObjetEditeChanged;

        //------------------------------------------------------------------------------
        public bool ValiderModifications()
        {
            if (!ValideMyModifications())
                return false;
            if (m_formAppelante != null)
            {
                bool bResult = m_formAppelante.ValiderModifications();
                if (bResult)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                return true;
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------
        private bool ValideMyModifications()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                CResultAErreur result = MajChamps();
                if (!result)
                {
                    if (CFormAlerte.Afficher(result.Erreur, EModeAffichageErreurs.AvecIgnorer) != DialogResult.Ignore)
                    {
                        return false;
                    }
                    else
                        Projet.VerifieDonnees(true);
                }
                m_gestionnaireModeEdition.ModeEdition = false;
            }
            return true;
        }
        //------------------------------------------------------------------------------
        private void m_btnOk_Click(object sender, EventArgs e)
        {
            if (ValideMyModifications())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool m_bPageBesoinsInit = false;
        private void m_TabControl_SelectionChanged(object sender, EventArgs e)
        {
            if (m_bPageBesoinsInit)
                return;
            m_bPageBesoinsInit = true;
            if (m_projet.Specifications != null)
            {
                m_panelBesoins.Visible = true;
                m_wndSpecifications.Init(m_projet.Specifications);
            }
            else
                m_panelBesoins.Visible = false;
        }

        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
