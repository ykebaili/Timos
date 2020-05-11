using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.process.workflow;
using sc2i.drawing;
using sc2i.process.workflow;
using sc2i.process.workflow.dessin;
using sc2i.process.workflow.blocs;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using timos.securite;
using sc2i.workflow;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.common;
using sc2i.win32.common;
using timos.Controles;
using sc2i.process;

namespace timos.process.workflow
{
    public partial class CControleDessinWorkflowEnCours : CControlEditeWorkflow
    {
        private CWorkflow m_workflowRacine = null;
        private Stack<CWorkflow> m_stackWorkflows = new Stack<CWorkflow>();

        private bool m_bCanManage = false;

        public CControleDessinWorkflowEnCours()
        {
            InitializeComponent();
        }

        protected override CContextDessinObjetGraphique GetContexteDessin(Graphics g, Rectangle clipZone)
        {
            CContextDessinObjetGraphique ctx = base.GetContexteDessin(g, clipZone);
            ctx.FonctionDessinSupplementaireApresObjet = new DessinSupplementaireDelegate(DessinSupplementaireItem);
            return ctx;
        }

        //---------------------------------------------------------------------------
        protected bool DessinSupplementaireItem(CContextDessinObjetGraphique ctx, C2iObjetGraphique objet)
        {
            CWorkflowEtapeDessin dessinEtape = objet as CWorkflowEtapeDessin;
            if (dessinEtape != null)
            {
                CTypeEtapeWorkflow typeEtape = dessinEtape.TypeEtape;
                if (typeEtape != null)
                {
                    CEtapeWorkflow etape = WorkflowAffiche.GetEtapeForType(typeEtape);
                    if (etape != null)
                    {
                        Brush br = null;
                        switch ((EEtatEtapeWorkflow)etape.EtatCode)
                        {
                            case EEtatEtapeWorkflow.ADemarrer :
                                br = new SolidBrush(Color.FromArgb(64, Color.Blue));
                                break;
                            case EEtatEtapeWorkflow.Démarrée:
                                br = new SolidBrush(Color.FromArgb(64, Color.Green));
                                break;
                            case EEtatEtapeWorkflow.Erreur:
                                br = new SolidBrush(Color.FromArgb(64, Color.Red));
                                break;
                            case EEtatEtapeWorkflow.Terminée:
                                br = new SolidBrush(Color.FromArgb(64, Color.Gray));
                                break;
                            case EEtatEtapeWorkflow.Annulée:
                                br = new SolidBrush(Color.FromArgb(64, Color.Orange));
                                break;
                            default:
                                break;
                        }
                        if (br != null)
                        {
                            Point[] pts = etape.TypeEtape.Bloc.GetPolygoneDessin(dessinEtape);
                            ctx.Graphic.FillPolygon(br, pts);
                            br.Dispose();
                        }
                    }
                }
            }
            return true;
        }

        //---------------------------------------------------------------------------
        public CWorkflow WorkflowAffiche
        {
            get
            {
                if (m_stackWorkflows.Count() > 0)
                    return m_stackWorkflows.Peek();
                return null;
            }
        }

        //---------------------------------------------------------------------------
        public void Init(CWorkflow workflowRacine)
        {
            if (workflowRacine == null)
            {
                Visible = false;
                return;
            }
            Visible = true;
            m_stackWorkflows = new Stack<CWorkflow>();
            m_workflowRacine = workflowRacine;
            AfficheWorkflow(m_workflowRacine);

            //TESTDBKEYOK
            CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(workflowRacine.ContexteDonnee);
            m_bCanManage = user != null && (
                user.GetDonneeDroit ( CDroitDeBase.c_droitBaseGestionWorkflows) != null ||
                user.DbKey == workflowRacine.KeyManager);
            Refresh();
        }

        public event EventHandler WorkflowAfficheChanged;

        //---------------------------------------------------------------------------
        private void AfficheWorkflow(CWorkflow workflow)
        {
            if (workflow == null)
                return;
            m_stackWorkflows.Push(workflow);
            ObjetEdite = workflow.TypeWorkflow.Dessin;
            if (WorkflowAfficheChanged != null)
                WorkflowAfficheChanged(workflow, null);
            Refresh();
        }

        //---------------------------------------------------------------------------
        public bool CanUpLevel()
        {
            return m_stackWorkflows.Count > 1;
        }

        //---------------------------------------------------------------------------
        public void UpLevel()
        {
            if (m_stackWorkflows.Count > 1)
            {
                m_stackWorkflows.Pop();
                CWorkflow workflow = m_stackWorkflows.Peek();
                ObjetEdite = workflow.TypeWorkflow.Dessin;
                if (WorkflowAfficheChanged != null)
                    WorkflowAfficheChanged(workflow, null);
            }
        }

        //---------------------------------------------------------------------------
        public CWorkflowEtapeDessin DessinEtapeSelectionnee
        {
            get
            {
                if (Selection.Count == 1)
                {
                    return Selection[0] as CWorkflowEtapeDessin;
                }
                return null;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public CTypeEtapeWorkflow TypeEtapeSelectionnee
        {
            get
            {
                CWorkflowEtapeDessin dessin = DessinEtapeSelectionnee;
                return dessin != null ? dessin.TypeEtape : null;
            }
        }

        //-----------------------------------------------------------------------------------------------------
        public CEtapeWorkflow EtapeSelectionnee
        {
            get
            {
                CTypeEtapeWorkflow typeEtape = TypeEtapeSelectionnee;
                return typeEtape != null ? WorkflowAffiche.GetEtapeForType(typeEtape) : null;
            }
        }




        //---------------------------------------------------------------------------
        private void CControleDessinWorkflowEnCours_DoubleClicSurElement(object sender, EventArgs e)
        {
            if (Selection.Count == 1)
            {
                CEtapeWorkflow etape = EtapeSelectionnee;
                if (etape != null && etape.WorkflowLancé != null)
                    AfficheWorkflow(etape.WorkflowLancé);
            }
        }

        protected override void AfficherMenuContextuel(Point p, bool bSkipTestClicOnSelection)
        {
            m_menuEtapeDessin.Show(this, p);
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuEtapeDessin_Opening(object sender, CancelEventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            m_menuAfficheDetailEtape.Visible = etape != null;
            m_menuAfficheDetailWorkflow.Visible = etape != null && etape.WorkflowLancé != null;
            m_menuStartStep.Visible = m_bCanManage && etape == null || etape.EtatCode != (int)EEtatEtapeWorkflow.Démarrée;
            m_menuSendNotifications.Visible = m_bCanManage && etape != null && etape.EtatCode == (int)EEtatEtapeWorkflow.Démarrée &&  etape.Affectations.GetAffectables().Count() > 0;
            m_menuAnnulerEtape.Visible = m_bCanManage && etape != null && etape.EtatCode == (int)EEtatEtapeWorkflow.Démarrée;
            m_menuEndStep.Visible = m_bCanManage && etape != null && etape.EtatCode == (int)EEtatEtapeWorkflow.Démarrée;
            m_menuEditAffectations.Visible = m_bCanManage && etape != null;
            if (etape != null)
            {
                CUtilMenuActionSurElement.InitMenuActions(
                    etape,
                    m_menuActionEtape.DropDownItems,
                    new MenuActionEventHandler(onClickMenuActionEventHandler));
                m_menuActionEtape.Visible = m_menuActionEtape.DropDownItems.Count > 0;
            }
            else
                m_menuActionEtape.Visible = false;
            m_menuCreateStep.Visible = etape == null;
        }

        //-----------------------------------------------------------------------------------------------------
        public void onClickMenuActionEventHandler(IDeclencheurAction declencheur, CObjetDonneeAIdNumerique objetAction)
        {
            CResultAErreur result = CFormExecuteProcess.RunEvent(declencheur, objetAction, false);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuAfficheDetailEtape_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            if ( etape != null )
            {
                CFormNavigateur navigateur = CFormNavigateur.FindNavigateur(this);
                if ( navigateur != null )
                {
                    CReferenceTypeForm refForm  = CFormFinder.GetRefFormToEdit ( typeof(CEtapeWorkflow));
                    if ( refForm != null )
                    {
                        CFormEditionStandard frm = refForm.GetForm ( etape ) as CFormEditionStandard;
                        if ( frm != null )
                            navigateur.AffichePage ( frm );
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuAfficheDetailWorkflow_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            CWorkflow wkf = etape != null ? etape.WorkflowLancé : null;
            if ( wkf != null )
            {
                CFormNavigateur navigateur = CFormNavigateur.FindNavigateur(this);
                if ( navigateur != null )
                {
                    CReferenceTypeForm refForm  = CFormFinder.GetRefFormToEdit ( typeof(CWorkflow));
                    if ( refForm != null )
                    {
                        CFormEditionStandard frm = refForm.GetForm ( wkf ) as CFormEditionStandard;
                        if ( frm != null )
                            navigateur.AffichePage ( frm );
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuStartStep_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            CWorkflow wkf = m_stackWorkflows.Peek();
            using (CContexteDonnee ctx = new CContexteDonnee(wkf.ContexteDonnee.IdSession, true, false))
            {
                wkf = wkf.GetObjetInContexte(ctx) as CWorkflow;
                CTypeEtapeWorkflow typeEtape = TypeEtapeSelectionnee;
                if (etape != null)
                    typeEtape = etape.TypeEtape;

                CResultAErreurType<CEtapeWorkflow> resEtape = wkf.CreateOrGetEtapeInCurrentContexte(typeEtape);
                if (!resEtape)
                {
                    CFormAlerte.Afficher(resEtape.Erreur);
                    return;
                }
                etape = resEtape.DataType;



                etape = etape.GetObjetInContexte(ctx) as CEtapeWorkflow;
                etape.InternalSetInfosDemarrageInCurrentContext();
                CResultAErreur result = ctx.SaveAll(true);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
                Refresh();
            }

        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuEditAffectations_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            if (etape != null)
            {
                CFormEditeAffectationsEtape.EditeAffectations(etape);
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuSendNotifications_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            if (etape != null)
            {
                CDonneeNotificationWorkflow notification = new CDonneeNotificationWorkflow(
                    etape.ContexteDonnee.IdSession,
                    etape.Id,
                    etape.Libelle,
                    etape.CodeAffectations,
                    etape.TypeEtape.ExecutionAutomatique);
                CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notification });
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuAnnulerEtape_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            using (CContexteDonnee ctx = new CContexteDonnee(etape.ContexteDonnee.IdSession, true, false))
            {
                etape = etape.GetObjetInContexte(ctx) as CEtapeWorkflow;
                etape.CancelStep();
                CResultAErreur result = ctx.SaveAll(true);
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
                Refresh();
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuEndStep_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            if (etape != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(etape.ContexteDonnee.IdSession, true, false)) 
                {
                    etape = etape.GetObjetInContexte(ctx) as CEtapeWorkflow;
                    CResultAErreur result = etape.EndEtapeNoSave();
                    if (result)
                        result = ctx.SaveAll(true);
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                        return;
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------
        private void m_menuCreateStep_Click(object sender, EventArgs e)
        {
            CEtapeWorkflow etape = EtapeSelectionnee;
            if (etape == null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(m_workflowRacine.ContexteDonnee.IdSession, true, false))
                {
                    CWorkflow wkf = m_stackWorkflows.Peek();
                    if (wkf != null)
                    {
                        wkf = wkf.GetObjetInContexte(ctx) as CWorkflow;
                        CResultAErreurType<CEtapeWorkflow> res = wkf.CreateOrGetEtapeInCurrentContexte(TypeEtapeSelectionnee);
                        if (!res)
                        {
                            CFormAlerte.Afficher(res.Erreur);
                            return;
                        }
                        CResultAErreur result = ctx.SaveAll(true);
                        if (!result)
                        {
                            CFormAlerte.Afficher(result.Erreur);
                            return;
                        }
                    }
                }
            }

        }

        //-----------------------------------------------------------------------------------------------------


    }
}
