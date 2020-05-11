using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.data.navigation;
using sc2i.process.workflow;
using sc2i.common;
using sc2i.process.workflow.blocs;
using sc2i.expression;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.workflow;
using sc2i.win32.common;

namespace timos.process.workflow
{
    public class CGestionnaireWorkflowsEnCours
    {
        private const string c_cleContexteEtape = "SYSTEM_WKF_STEP_ID";
        private static CGestionnaireWorkflowsEnCours m_instance = null;

        private Dictionary<CFormEditionStandard, CEtapeWorkflow> m_dicFormToEtape = new Dictionary<CFormEditionStandard, CEtapeWorkflow>();

        private ContexteFormEventHandler m_eventAfterGetContexte = null;
        private ContexteFormEventHandler m_eventAfterInitFromContexte = null;

        //-----------------------------------------------------------------------------
        private CGestionnaireWorkflowsEnCours()
        {
            m_eventAfterGetContexte = new ContexteFormEventHandler(AfterGetContexteOnForm);
            m_eventAfterInitFromContexte = new ContexteFormEventHandler(AfterInitFromContexteOnForm);
        }


        //-----------------------------------------------------------------------------
        public static CGestionnaireWorkflowsEnCours Instance
        {
            get
            {
                if (m_instance == null)
                {
                    m_instance = new CGestionnaireWorkflowsEnCours();
                    CFormMain.GetInstance().ActivePageChanged += new EventHandler(OnChangePageActive);
                    CContexteFormNavigable.AfterInitPageFromContexte += m_instance.m_eventAfterInitFromContexte;
                }
                return m_instance;
            }
        }

        //-----------------------------------------------------------------------------
        private static void OnChangePageActive(object sender, EventArgs args)
        {
            CFormEditionStandard frm = sender as CFormEditionStandard;
            if (frm != null)
            {
                CEtapeWorkflow etape = null;
                if (Instance.m_dicFormToEtape.TryGetValue(frm, out etape))
                {
                    CFormMain.GetInstance().SetEtapeActive(etape, frm);
                    return;
                }
            }
            CFormMain.GetInstance().SetEtapeActive(null, sender as CFormEditionStandard);
        }

        //-----------------------------------------------------------------------------
        private void AfterGetContexteOnForm(IFormNavigable form, CContexteFormNavigable contexte)
        {
            CFormEditionStandard frmStd = form as CFormEditionStandard;
            if ( frmStd != null )
            {
                CEtapeWorkflow etape = null;
                if ( m_dicFormToEtape.TryGetValue ( frmStd, out etape ) )
                    contexte[c_cleContexteEtape] = etape.Id;
            }

        }

        //-----------------------------------------------------------------------------
        private void AfterInitFromContexteOnForm(IFormNavigable form, CContexteFormNavigable contexte)
        {
            CFormEditionStandard frmStd = form as CFormEditionStandard;
            if (frmStd != null)
            {
                int? nIdEtape = contexte[c_cleContexteEtape] as int?;
                if (nIdEtape != null)
                {
                    CEtapeWorkflow etape = new CEtapeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                    if (etape.ReadIfExists(nIdEtape.Value))
                    {
                        m_dicFormToEtape[frmStd] = etape;
                        CFormMain.GetInstance().SetEtapeActive(etape, form as CFormEditionStandard);
                        AppliqueEtape(etape, frmStd);
                    }
                }
            }
        }

        //-----------------------------------------------------------------------------
        public CResultAErreur AfficheEtape(CEtapeWorkflow etape)
        {
            return AfficheEtape(etape, false);
        }

        //-----------------------------------------------------------------------------
        public CResultAErreur AfficheEtape(CEtapeWorkflow etape, bool bDansNouvelOnglet)
        {
            CResultAErreur result = CResultAErreur.True;


            if (etape == null || etape.TypeEtape == null)
                return result;
            //Vérifie que l'étape est bien affectée à l'utilisateur
            string[] strCodes = CUtilSession.GetCodesAffectationsEtapeConcernant(etape.ContexteDonnee.ContexteDonnee);
            CAffectationsEtapeWorkflow affs = etape.Affectations;
            bool bIsAffectée = false;
            foreach ( string strCode in strCodes )
                if ( affs.Contains ( strCode ) )
                {
                    bIsAffectée = true;
                    break;
                }
            if (bIsAffectée)
            {
                CBlocWorkflow bloc = etape.TypeEtape.Bloc;
                if (bloc is CBlocWorkflowFormulaire)
                {
                    result = AfficheEtapeFormulaire(etape, bDansNouvelOnglet);
                }
                else if (bloc is CBlocWorkflowProcess)
                {
                    using (CContexteDonnee ctxt = new CContexteDonnee(etape.ContexteDonnee.IdSession, true, false))
                    {
                        etape = etape.GetObjetInContexte(ctxt) as CEtapeWorkflow;
                        result = ((CBlocWorkflowProcess)bloc).StartProcess(etape);
                    }
                }
                if (!result)
                {
                    EModeGestionErreurEtapeWorkflow mode = CFormErreurOnWorkflowStep.OnError(result,
                        bloc.ModeGestionErreur);
                    if (mode != EModeGestionErreurEtapeWorkflow.DoNothing)
                    {
                        using (CContexteDonnee ctx = new CContexteDonnee(etape.ContexteDonnee.IdSession, true, false))
                        {
                            CEtapeWorkflow etapeInContexte = etape.GetObjetInContexte(ctx) as CEtapeWorkflow;
                            switch (mode)
                            {
                                case EModeGestionErreurEtapeWorkflow.CancelStep:
                                    etapeInContexte.CancelStep();
                                    break;
                                case EModeGestionErreurEtapeWorkflow.EndStep:
                                    result = etapeInContexte.EndEtapeNoSave();
                                    if (!result)
                                    {
                                        result.EmpileErreur(I.T("Can not end step|20766"));
                                        CFormAlerte.Afficher(result.Erreur);
                                        return result;
                                    }
                                    break;
                                case EModeGestionErreurEtapeWorkflow.SetError:
                                    etapeInContexte.EtatCode = (int)EEtatEtapeWorkflow.Erreur;
                                    etapeInContexte.LastError = result.Erreur.ToString();
                                    etapeInContexte.DateFin = null;
                                    break;
                            }
                            result = ctx.SaveAll(true);
                        }
                        
                    }
                }
            }
            else
            {
                CFormAlerte.Afficher(I.T("You are not allowed to display this step|20620"));
            }
            return result;
        }

        //-----------------------------------------------------------------------------
        private CResultAErreur AfficheEtapeFormulaire ( CEtapeWorkflow etape, bool bDansNouvelOnglet )
        {
            CResultAErreur result = CResultAErreur.True;
            CBlocWorkflowFormulaire blocFormulaire = etape.TypeEtape != null ? etape.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
            
            if (blocFormulaire == null)
            {
                result.EmpileErreur(I.T("Error while initializing workflow step|20557"));
                return result;
            }

            //trouve l'élément à éditer
            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etape);
            if (blocFormulaire.FormuleElementEditePrincipal == null)
            {
                result.EmpileErreur(I.T("Step @1 doesn't define element to edit|20558",
                    etape.TypeEtape.Libelle));
                return result;
            }
            result = blocFormulaire.FormuleElementEditePrincipal.Eval(ctxEval);
            if (!result)
            {
                return result;
            }
            CObjetDonneeAIdNumeriqueAuto objet = result.Data as CObjetDonneeAIdNumeriqueAuto;
            if (objet == null)
            {
                result.EmpileErreur(I.T("Element to edit for step @1 is invalid|20559"),
                    etape.TypeEtape.Libelle);
                return result;
            }

            CFormEditionStandard formStandard;

            if (blocFormulaire.IsStandardForm)
            {
                
                CReferenceTypeForm refType = CFormFinder.GetRefFormToEdit(objet.GetType());
                formStandard = null;
                try
                {
                    if (refType != null)
                        formStandard = refType.GetForm(objet) as CFormEditionStandard;
                }
                catch (Exception e)
                { }
                if (formStandard == null)
                {
                    result.EmpileErreur(I.T("System can not edit @1|20560",
                        DynamicClassAttribute.GetNomConvivial(objet.GetType())));
                    return result;
                }
            }
            else
            {
                //CFormulaire formulaire = new CFormulaire(etape.ContexteDonnee);
                //if (!formulaire.ReadIfExists(
                //    blocFormulaire.IdFormulairePrincipal == null ? -1 : blocFormulaire.IdFormulairePrincipal.Value))
                //{
                //    result.EmpileErreur(I.T("Form for step @1 is invalid|20561",
                //        etape.TypeEtape.Libelle));
                //    return result;
                //}
                CFormEditionStdPourFormulaire frm = new CFormEditionStdPourFormulaire(objet);
                //frm.IdFormulaireAffiche = formulaire.Id;
                frm.IdsFormulairesAffiches = blocFormulaire.ListeDbKeysFormulaires;
                formStandard = frm;
            }
            CFormMain.GetInstance().SetEtapeActive(null, null);

            if (formStandard != null && blocFormulaire.RestrictionExceptionContext.Length > 0)
                formStandard.ContexteModification = blocFormulaire.RestrictionExceptionContext;
            

            if (bDansNouvelOnglet)
                CFormMain.GetInstance().AffichePageDansNouvelOnglet(formStandard);
            else
                CFormMain.GetInstance().AffichePage(formStandard);

            AppliqueEtape(etape, formStandard);
            return result;
        }

        private void AppliqueEtape(CEtapeWorkflow etape, CFormEditionStandard formStandard)
        {
            formStandard.BoutonAjouterVisible = false;
            formStandard.BoutonSupprimerVisible = false;
            CBlocWorkflowFormulaire bloc = etape.TypeEtape.Bloc as CBlocWorkflowFormulaire;
            if (bloc != null)
                formStandard.AddRestrictionComplementaire("WORKFLOW_FORMULAIRE", bloc.Restrictions, false);
            m_dicFormToEtape[formStandard] = etape;
            formStandard.AfterGetContexte += m_eventAfterGetContexte;
            formStandard.Disposed += new EventHandler(formStandard_Disposed);
            CFormMain.GetInstance().SetEtapeActive(etape, formStandard);
        }

        //------------------------------------------------------------------
        void formStandard_Disposed(object sender, EventArgs e)
        {
            CFormEditionStandard frm = sender as CFormEditionStandard;
            if (frm != null && m_dicFormToEtape.ContainsKey(frm))
                m_dicFormToEtape.Remove(frm);
        }


    }
}
