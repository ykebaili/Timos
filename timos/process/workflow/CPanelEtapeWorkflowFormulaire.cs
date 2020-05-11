using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.process.workflow;
using sc2i.process.workflow.blocs;
using sc2i.win32.data.navigation;
using sc2i.data;
using sc2i.win32.common;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;
using timos.Properties;
using sc2i.drawing;
using timos.Controles;
using sc2i.process;

namespace timos.process.workflow
{
    public partial class CPanelEtapeWorkflowFormulaire : UserControl
    {
        private bool m_bIsCollapse = false;
        private int m_nSizeUncollapse = 0;
        private Color c_colorClignotant1 = Color.FromArgb(253, 108, 0);
        private Color c_colorClignotant2 = Color.FromArgb(240, 168, 114);

        private CProgressiveColor m_couleurClignote = null;

        private CEtapeWorkflow m_etapeEnCours = null;

        private CFormEditionStandard m_formulaire = null;

        private ObjetDonneeEventHandler m_eventAfterValideModifications = null;

        private CObjetDonnee m_objetSecondaireEnCoursEdition = null;


        public CPanelEtapeWorkflowFormulaire()
        {
            InitializeComponent();
            m_eventAfterValideModifications = new ObjetDonneeEventHandler(m_formulaire_AfterValideModification);
            ResetClignote();
        }

        //----------------------------------------------------
        private void ResetClignote()
        {
            m_couleurClignote = new CProgressiveColor(c_colorClignotant1, c_colorClignotant2, 12);
        }

        //----------------------------------------------------
        public CEtapeWorkflow EtapeEnCours
        {
            get
            {
                return m_etapeEnCours;
            }
        }

        //----------------------------------------------------
        public void SetEtapeEnCours(CEtapeWorkflow etape, CFormEditionStandard formulaire)
        {
            m_etapeEnCours = etape;
            m_formulaire = formulaire;
            if (m_formulaire != null)
            {
                m_formulaire.AfterValideModification -= m_eventAfterValideModifications;
                m_formulaire.AfterValideModification += m_eventAfterValideModifications;
            }
            Init();
        }

        //----------------------------------------------------
        void m_formulaire_AfterValideModification(object sender, sc2i.data.CObjetDonneeEventArgs args)
        {
            if (m_etapeEnCours != null)
            {
                CBlocWorkflowFormulaire bloc = m_etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire;
                if (bloc != null && bloc.PromptForEndWhenAllConditionsAreOk)
                {
                    CResultAErreur result = m_etapeEnCours.GetErreursManualEndEtape();
                    if (result)
                    {
                        if (CFormAlerte.Afficher(I.T("All prerequisite conditions to close Step \"@1\" are valid. Would you like to close this Step|20573", m_etapeEnCours.Libelle),
                            EFormAlerteBoutons.OuiNon,
                            EFormAlerteType.Question) == DialogResult.Yes)
                        {
                            EndEtape();
                        }
                    }
                }
            }
        }

        //----------------------------------------------------
        private void Init()
        {
            Visible = m_etapeEnCours != null;
            CBlocWorkflowFormulaire blocFormulaire = m_etapeEnCours != null &&
                m_etapeEnCours.TypeEtape != null ?
                m_etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
            SetSecondaireEdite(null);
            if (blocFormulaire == null)
                return;
            if (blocFormulaire.HideAfterValidation && m_etapeEnCours.EtatCode == (int)EEtatEtapeWorkflow.Terminée)
            {
                SetEtapeEnCours(null, null);
                return;
            }
            ResetClignote();
            this.SuspendDrawing();
            m_lblNomEtape.Text = m_etapeEnCours.Libelle;
            if (blocFormulaire.FormuleInstructions != null)
            {
                C2iExpression expInstructions = blocFormulaire.FormuleInstructions;
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(m_etapeEnCours);
                CResultAErreur result = expInstructions.Eval(ctxEval);
                if (result && result.Data != null)
                {
                    m_lblInstructions.Text = result.Data.ToString();
                }
                else
                {
                    m_lblInstructions.Text = m_etapeEnCours.Libelle + Environment.NewLine +
                        result.Erreur.ToString();
                }

            }
            //m_btnTerminer.Visible = m_etapeEnCours.EtatCode == (int)EEtatEtapeWorkflow.Démarrée;
            if (m_formulaire != null)
            {
                bool bConsultationOnly = m_etapeEnCours.EtatCode != (int)EEtatEtapeWorkflow.Démarrée;
                if (m_etapeEnCours.EtatCode == (int)EEtatEtapeWorkflow.Terminée &&
                    !blocFormulaire.LockerElementEditeEnFinDEtape)
                    bConsultationOnly = false;
                m_formulaire.ConsultationOnly = bConsultationOnly;

            }
            m_bIsCollapse = false;
            UpdateImagePanelBas();
            m_btnTerminer.Visible = m_etapeEnCours.DateFin == null && m_etapeEnCours.DateDebut != null;
            m_btnTerminer.Enabled = !m_etapeEnCours.EstGelee;
            m_btnAnnuler.Visible = !blocFormulaire.MasquerSurChangementDeFormulaire || m_etapeEnCours.DateFin != null;
            m_btnActions.Visible = CRecuperateurDeclencheursActions.GetActionsManuelles(m_etapeEnCours, true).Count() > 0;

            Image imgTask = m_etapeEnCours.EtatCode == (int)EEtatEtapeWorkflow.Terminée ?
            Resources._1346738948_taskok : Resources._1346738948_task;
            if (m_etapeEnCours.EstGelee)
                imgTask = Resources._1346738948_task_pending;
            SetImageTask(imgTask);

            int nHeight = m_panelTop.Height + m_panelInstructions.Height + m_panelBas.Height +
                ClientSize.Height - Size.Height;
            bool bShowFormulaireSecondaire = false;
            if (blocFormulaire.DbKeyFormulaireSecondaire != null &&
                blocFormulaire.FormuleElementEditeSecondaire != null)
            {
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(m_etapeEnCours);
                CResultAErreur result = blocFormulaire.FormuleElementEditeSecondaire.Eval(ctxEval);
                CObjetDonnee objet = result.Data as CObjetDonnee;
                if (result && objet != null)
                {
                    CFormulaire formulaire = new CFormulaire(m_etapeEnCours.ContexteDonnee);
                    if (formulaire.ReadIfExists(blocFormulaire.DbKeyFormulaireSecondaire))
                    {
                        C2iWnd wnd = formulaire.Formulaire;
                        if (wnd != null)
                        {
                            Size = new Size(Size.Width,
                                nHeight +
                                wnd.Size.Height + 2);
                            if (blocFormulaire.SecondaireEnEdition)
                                objet.BeginEdit();
                            m_panelFormulalire.InitPanel(wnd, objet);
                            SetSecondaireEdite(blocFormulaire.SecondaireEnEdition ? objet : null);
                            if (!blocFormulaire.SecondaireEnEdition)
                                m_panelFormulalire.LockEdition = true;
                            else
                                m_panelFormulalire.LockEdition = m_etapeEnCours.DateFin != null;

                            bShowFormulaireSecondaire = true;
                        }
                    }
                }
            }
            if (!bShowFormulaireSecondaire)
                Size = new Size(Size.Width, nHeight);
            m_nSizeUncollapse = Size.Height;
            this.ResumeDrawing();
        }

        //-------------------------------------------------------------
        private void SetImageTask(Image img)
        {
            m_imageTask1.Image = img;
        }

        //-------------------------------------------------------------
        private void SetSecondaireEdite(CObjetDonnee objet)
        {
            if (m_objetSecondaireEnCoursEdition != null)
            {
                try
                {
                    m_objetSecondaireEnCoursEdition.CancelEdit();
                }
                catch { }
            }
            m_objetSecondaireEnCoursEdition = objet;
        }

        //-------------------------------------------------------------
        private void m_btnTerminer_Click(object sender, EventArgs e)
        {
            EndEtape();
        }

        //-------------------------------------------------------------
        private void EndEtape()
        {
            if (m_formulaire != null && m_formulaire.ModeEdition)
            {
                CFormAlerte.Afficher(I.T("Validate your modification before|20572"));
                return;
            }
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee ctx = new CContexteDonnee(m_etapeEnCours.ContexteDonnee.IdSession, true, false))
            {
                if (m_objetSecondaireEnCoursEdition != null)
                {
                    CObjetDonnee objetSecondaire = m_objetSecondaireEnCoursEdition.GetObjetInContexte(ctx);
                    result = m_panelFormulalire.AffecteValeursToElement(objetSecondaire);
                }
                if (result)
                {
                    m_etapeEnCours = m_etapeEnCours.GetObjetInContexte(ctx) as CEtapeWorkflow;
                    if (m_etapeEnCours.EtatCode == (int)EEtatEtapeWorkflow.Démarrée)
                        result = m_etapeEnCours.EndEtapeAndSaveIfOk();
                }
            }
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            else
                Init();
        }

        private void m_btnAnnuler_Click(object sender, EventArgs e)
        {
            SetEtapeEnCours(null, null);
            CFormMain.GetInstance().CancelEtapePermanente();
        }


        private void m_timerClignotant_Tick(object sender, EventArgs e)
        {
            Color c = c_colorClignotant1;
            if (m_etapeEnCours != null && !m_etapeEnCours.IsValide())
                SetEtapeEnCours(null, null);
            if (m_etapeEnCours != null && m_etapeEnCours.DateFin == null && m_etapeEnCours.DateDebut != null)
            {
                c = m_couleurClignote++;
                //c = m_panelBas.BackColor == c_colorClignotant1 ? c_colorClignotant2 : c_colorClignotant1;
            }
            m_panelBas.BackColor = c;
            m_panelTop.BackColor = c;
        }

        private void m_panelBas_Click(object sender, EventArgs e)
        {
            if (m_bIsCollapse)
            {
                Size = new Size(Width, m_nSizeUncollapse);
                m_bIsCollapse = false;
            }
            else
            {
                m_nSizeUncollapse = Size.Height;
                Size = new Size(Width, m_panelTop.Height + m_panelBas.Height);
                m_bIsCollapse = true;
            }
            UpdateImagePanelBas();
        }

        //----------------------------------------------------
        private void UpdateImagePanelBas()
        {
            if (m_bIsCollapse)
                m_imageFleche.Image = Resources.discretDown;
            else
                m_imageFleche.Image = Resources.discretUp;
        }

        //---------------------------------------------------------------------------------------
        private void m_imageInstructions_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_lblInstructions.Text);
        }

        //---------------------------------------------------------------------------------------
        internal void RefreshVisuEtape()
        {
            if (m_etapeEnCours != null)
                SetEtapeEnCours(m_etapeEnCours, m_formulaire);
        }

        //---------------------------------------------------------------------------------------
        private void m_btnActions_Click(object sender, EventArgs e)
        {
            CUtilMenuActionSurElement.InitMenuActions(EtapeEnCours, m_menuActions.Items, new MenuActionEventHandler(MenuDeclencheurClick));
            m_menuActions.Show(m_btnActions, new Point(0, m_btnActions.Height));
        }

        //---------------------------------------------------------------------------------------
        void MenuDeclencheurClick(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetAction)
        {
            CResultAErreur result = CFormExecuteProcess.RunEvent(declencheur, objetAction, false);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
        }
    }
}
