using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.expression;
using sc2i.process.workflow.blocs;
using sc2i.data;
using sc2i.formulaire;
using sc2i.data.dynamic;
using timos.data.projet;

namespace timos.data.process.workflow
{
    public static class CGestionnaireProjetsDeWorkflow
    {

        //--------------------------------------------------------------------------
        public static CResultAErreur CreateSqueletteProjetsInCurrentContext(
            CWorkflow workflow, 
            CTypeEtapeWorkflow typeEtapeDebut,
            CProjet projetParent)
        {
            CResultAErreur result = CResultAErreur.True;

            CTypeWorkflow typeWorkflow = workflow.TypeWorkflow;

            //Récupére le type d'étape de base
            CTypeEtapeWorkflow typeEtape = typeEtapeDebut;
            if (typeEtape == null)
                typeEtape = typeWorkflow.EtapeDemarrageDefaut;
            if (typeEtape == null)
                return result;

            //règle de création : on ne suit que les liens systèmatiques (sans CodeRetour et sans formule)
            result = CreateProjets(workflow, typeEtape, projetParent);
            return result;
        }

        //-------------------------------------------------------------------------------------
        private static List<CLienEtapesWorkflow> LiensSuivantsPourProjet(CTypeEtapeWorkflow typeEtape)
        {
            List<CLienEtapesWorkflow> lst = new List<CLienEtapesWorkflow>();
            foreach (CLienEtapesWorkflow lien in typeEtape.LiensSortants)
            {
                if ((lien.Formule == null || lien.Formule is C2iExpressionVrai) && (lien.ActivationCode.Trim() == "" || lien.ActivationCode==CBlocWorkflowProjet.c_constIdLienProjetForce))
                    lst.Add(lien);
            }
            return lst;
        }

        //-------------------------------------------------------------------------------------
        private static List<CLienEtapesWorkflow> LiensPrecedentsPourProjet(CTypeEtapeWorkflow typeEtape)
        {
            List<CLienEtapesWorkflow> lst = new List<CLienEtapesWorkflow>();
            foreach (CLienEtapesWorkflow lien in typeEtape.LiensEntrants)
            {
                if ((lien.Formule == null || lien.Formule is C2iExpressionVrai) && (lien.ActivationCode.Trim() == "" || lien.ActivationCode == CBlocWorkflowProjet.c_constIdLienProjetForce))
                    lst.Add(lien);
            }
            return lst;
        }

        //-------------------------------------------------------------------------------------
        private static CResultAErreur CreateProjets(CWorkflow workflow, CTypeEtapeWorkflow typeEtape, CProjet projetParent)
        {
            CResultAErreur result = CResultAErreur.True;
            if (workflow == null || typeEtape == null)
                return result;
            CBlocWorkflowProjet blocProjet = typeEtape.Bloc as CBlocWorkflowProjet;
            if (blocProjet != null)
            {
                CResultAErreurType<CEtapeWorkflow> resEtape = workflow.CreateOrGetEtapeInCurrentContexte(typeEtape);
                if (!resEtape)
                {
                    result.EmpileErreur(resEtape.Erreur);
                    return result;
                }
                if (resEtape.DataType != null)
                {
                    CResultAErreurType<CProjet> resProjet = blocProjet.GetOrCreateProjetInCurrentContexte(resEtape.DataType, projetParent, FindPredecesseurs(resEtape.DataType));
                    if (!resProjet)
                    {
                        result.EmpileErreur(resProjet.Erreur);
                        return result;
                    }
                    CWorkflow workflowDuProjet = blocProjet.GetOrCreateWorkflowInCurrentContexte(resEtape.DataType);
                    result = CreateSqueletteProjetsInCurrentContext(workflowDuProjet, null, resProjet.DataType);
                    if (!result)
                        return result;
                }
            }
            foreach (CLienEtapesWorkflow lien in LiensSuivantsPourProjet(typeEtape))
            {
                result += CreateProjets(workflow, lien.EtapeDestination, projetParent);
            }
            return result;
        }

        //----------------------------------------------------------------------------------
        public static CProjet GetProjetDirectementAssocie(CEtapeWorkflow etape)
        {
            if (etape != null && etape.TypeEtape != null)
            {
                CBlocWorkflowProjet blocProjet = etape.TypeEtape.Bloc as CBlocWorkflowProjet;
                if (blocProjet != null && blocProjet.IdChampProjet != null && etape.WorkflowLancé != null)
                {
                    return etape.WorkflowLancé.GetValeurChamp(blocProjet.IdChampProjet.Value) as CProjet;
                }
            }
            return null;
        }

        //----------------------------------------------------------------------------------
        /// <summary>
        /// Trouve le projet associé à l'étape, en remontant les niveaux de hierarchie
        /// </summary>
        /// <param name="etape"></param>
        /// <returns></returns>
        public static CProjet FindProjetAssocie(CEtapeWorkflow etape)
        {
            if (etape != null && etape.TypeEtape != null)
            {
                CBlocWorkflowProjet blocProjet = etape.TypeEtape.Bloc as CBlocWorkflowProjet;
                if (blocProjet != null && blocProjet.IdChampProjet != null && etape.WorkflowLancé != null)
                {
                    return etape.WorkflowLancé.GetValeurChamp(blocProjet.IdChampProjet.Value) as CProjet;
                }
                return FindProjetParent(etape);
            }
            return null;
        }

        /// <summary>
        /// Trouve le projet parent d'une étape , c'est à dire qu'on demande à l'étape parente de trouver le projet associé
        /// </summary>
        /// <param name="etape"></param>
        /// <returns></returns>
        public static CProjet FindProjetParent(CEtapeWorkflow etape)
        {
            if (etape != null)
            {
                CWorkflow workflowParent = etape.Workflow;
                if (workflowParent.EtapeAppelante != null)
                    return FindProjetAssocie(workflowParent.EtapeAppelante);
            }
            return null;
        }

        //--------------------------------------------------------------------------
        public static IEnumerable<CProjet> FindPredecesseurs(CEtapeWorkflow etape)
        {
            if (etape == null)
                return new List<CProjet>();
            return FindPredecesseurs(etape.TypeEtape, etape.Workflow);
        }

        //--------------------------------------------------------------------------
        public static IEnumerable<CTypeEtapeWorkflow> FindTypesPredecesseurs(CTypeEtapeWorkflow typeEtape)
        {
            HashSet<CTypeEtapeWorkflow> retour = new HashSet<CTypeEtapeWorkflow>();
            foreach (CLienEtapesWorkflow lien in LiensPrecedentsPourProjet(typeEtape))
            {
                if (lien.EtapeSource.Bloc is CBlocWorkflowProjet)
                {
                    retour.Add(lien.EtapeSource);
                }
                else
                {
                    IEnumerable<CTypeEtapeWorkflow> parents = FindTypesPredecesseurs(lien.EtapeSource);
                    foreach (CTypeEtapeWorkflow tp in parents)
                        retour.Add(tp);
                }
            }
            return retour.ToArray();
        }


        //--------------------------------------------------------------------------
        public static IEnumerable<CProjet> FindPredecesseurs(CTypeEtapeWorkflow typeEtape, CWorkflow workflow)
        {
            List<CProjet> lstProjets = new List<CProjet>();
            foreach (CTypeEtapeWorkflow tp in FindTypesPredecesseurs(typeEtape))
            {
                CEtapeWorkflow etape = workflow.GetEtapeForType(tp);
                if (etape != null)
                {
                    CProjet projet = GetProjetDirectementAssocie(etape);
                    if (projet != null)
                        lstProjets.Add(projet);
                }
            }
            return lstProjets.AsReadOnly();
        }



        //--------------------------------------------------------------------------
        public static IEnumerable<CProjet> FindSuccesseurs(CEtapeWorkflow etape)
        {
            if (etape == null)
                return new List<CProjet>();
            return FindSuccesseurs(etape.TypeEtape, etape.Workflow);
        }

        //--------------------------------------------------------------------------
        public static IEnumerable<CTypeEtapeWorkflow> FindTypesSuccesseurs(CTypeEtapeWorkflow typeEtape)
        {
            HashSet<CTypeEtapeWorkflow> retour = new HashSet<CTypeEtapeWorkflow>();
            foreach (CLienEtapesWorkflow lien in LiensSuivantsPourProjet(typeEtape))
            {
                if (lien.EtapeDestination.Bloc is CBlocWorkflowProjet)
                {
                    retour.Add(lien.EtapeDestination);
                }
                else
                {
                    IEnumerable<CTypeEtapeWorkflow> parents = FindTypesSuccesseurs(lien.EtapeDestination);
                    foreach (CTypeEtapeWorkflow tp in parents)
                        retour.Add(tp);
                }
            }
            return retour.ToArray();
        }


        //--------------------------------------------------------------------------
        public static IEnumerable<CProjet> FindSuccesseurs(CTypeEtapeWorkflow typeEtape, CWorkflow workflow)
        {
            List<CProjet> lstProjets = new List<CProjet>();
            foreach (CTypeEtapeWorkflow tp in FindTypesSuccesseurs(typeEtape))
            {
                CEtapeWorkflow etape = workflow.GetEtapeForType(tp);
                if (etape != null)
                {
                    CProjet projet = GetProjetDirectementAssocie(etape);
                    if (projet != null)
                        lstProjets.Add(projet);
                }
            }
            return lstProjets.AsReadOnly();
        }


        //--------------------------------------------------------------------------
        /// <summary>
        /// Retourne un projet pouvant être executé pour l'étape demandée<BR>
        /// </BR>
        /// Cette fonction se charge de la mise à jour de toutes la structure du projet
        /// </summary>
        /// <param name="etape"></param>
        /// <returns></returns>
        public  static CResultAErreurType<CProjet> AssureProjetRunnable(CEtapeWorkflow etape, CBlocWorkflowProjet blocProjet)
        {
            CResultAErreurType<CProjet> resProjet = new CResultAErreurType<CProjet>();
            CProjet projet = GetProjetDirectementAssocie(etape);

            int nNumLastIteration = 0;
            if (projet != null)
            {
                nNumLastIteration = projet.NumeroIteration;
                if (projet.GanttId == "")
                {
                    projet.GanttId = blocProjet.GetGanttId(etape);
                }
            }

            CProjet projetParent = FindProjetParent(etape);
            if (projetParent != null && projet != null &&
                projetParent != projet.Projet)
                projet = null;

            if (projet == null)
            {
                resProjet = blocProjet.GetOrCreateProjetInCurrentContexte(etape,
                    FindProjetParent(etape),
                    FindPredecesseurs(etape));
                return resProjet;
            }

            if (
                projet.DateFinRelle == null || 
                !blocProjet.GererIteration || 
                projet.HasOptionLienEtape(EOptionLienProjetEtape.NoIteration))
            {
                if ((!blocProjet.GererIteration || projet.HasOptionLienEtape(EOptionLienProjetEtape.NoIteration)) &&
                    !projet.HasOptionLienEtape(EOptionLienProjetEtape.StepKeepDates) )
                    projet.DateFinRelle = null;
                resProjet.DataType = projet;
                return resProjet;
            }

            //Il faut créer une ittération pour ce projet
            IEnumerable<CProjet> predecesseurs = FindPredecesseurs(etape);

            CProjet newProjet = projet.Clone(false) as CProjet;
            
            //Remet les dates à null
            newProjet.DateDebutReel = null;
            newProjet.DateFinRelle = null;

            //Met les deux projets sur la même barre de gantt
            if ( projet.GanttId.Length  == 0 )
                projet.GanttId = blocProjet.GetGanttId(etape);
            newProjet.GanttId = projet.GanttId;

            DateTime? dateDebut = null;
            foreach (CProjet pred in predecesseurs)
            {
                if (dateDebut == null || pred.DateFinGantt > dateDebut.Value)
                    dateDebut = pred.DateFinGantt;
            }
            if (dateDebut == null)
                dateDebut = DateTime.Now;
            if ( dateDebut != null )
            {
                newProjet.DateDebutPlanifiee = dateDebut.Value;
                newProjet.DateFinPlanifiee = dateDebut.Value.AddHours(projet.DureeEnHeure.Value);
            }
            newProjet.DateDebutAuto = true;
            newProjet.NumeroIteration = nNumLastIteration + 1;

            //Supprime toutes les dépendances du nouveau projet
            CObjetDonneeAIdNumerique.Delete(newProjet.LiensDeProjetAttaches, true);

            //Change le workflow lancé
            etape.WorkflowLancé.SetValeurChamp(blocProjet.IdChampProjet.Value, newProjet);

            //Crée les liens vers les prédécesseurs
            foreach (CProjet pred in predecesseurs)
                newProjet.AddPredecessor(pred);

            //Met à jour les successeurs
            foreach (CTypeEtapeWorkflow typeSucc in FindTypesSuccesseurs(etape.TypeEtape))
            {
                CEtapeWorkflow succ = etape.Workflow.GetEtapeForType(typeSucc);
                if (succ != null)
                {
                    resProjet = AssureProjetRunnable(succ, succ.TypeEtape.Bloc as CBlocWorkflowProjet);
                    CProjet prjSucc = resProjet.DataType;
                    if (prjSucc != null)
                    {
                        //Si le projet est lié à l'ancien, on déplace le lien
                        CLienDeProjet lien = prjSucc.GetLienToPredecesseur(projet);
                        if (lien != null)
                            lien.ProjetA = newProjet;
                    }
                }
            }
            newProjet.AutoMoveDependancies();

            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etape);
            foreach (CAffectationsProprietes affectation in blocProjet.AffectationsCreationEtDemarrage)
            {
                bool bAppliquer = affectation.FormuleCondition == null || affectation.FormuleCondition is C2iExpressionVrai;
                if (affectation.FormuleCondition != null)
                {
                    CResultAErreur res = affectation.FormuleCondition.Eval(ctxEval);
                    if (res && res.Data != null && CUtilBool.BoolFromString(res.Data.ToString()) == true)
                        bAppliquer = true;
                }
                if (bAppliquer)
                    affectation.AffecteProprietes(newProjet, etape, new CFournisseurPropDynStd());
            }

            resProjet.DataType = newProjet;
            return resProjet;
        }

        //-------------------------------------------------------------------
        public static CProjet FindProjetPourRattrapage ( CProjet projetParent,
            CEtapeWorkflow etape,
            CBlocWorkflowProjet blocProjet )
        {
            CProjet projet = GetProjetDirectementAssocie(etape);
            if (projet == null)
            {
                //Cherche dans le projet parent, un projet qui aurait le bon GanttId ou le bon type
                if (projetParent != null)
                {
                    CListeObjetsDonnees lst = projetParent.ProjetsFils;
                    //si formule de gantt, cheche le projet qui a le bon IdGantt
                    if ( blocProjet.FormuleGanttId != null )
                        lst.Filtre = new CFiltreData(CProjet.c_champGanttId + "=@1",
                            blocProjet.GetGanttId(etape));
                    //Si pas de formule de gantt, cherche le projet en fonction de son type
                    else if ( blocProjet.DbKeyTypeProjet != null )
                        lst.Filtre = new CFiltreDataAvance ( CProjet.c_nomTable, CTypeProjet.c_nomTable+"."+CObjetDonnee.c_champIdUniversel+"=@1",
                            blocProjet.DbKeyTypeProjet.GetValeurInDb());
                    else
                    //sinon, impossible de trouver le projet
                        lst.Filtre = new CFiltreDataImpossible();
                    if (lst.Count > 0)
                    {
                        //Cherche le plus récent, ou celui qui n'est pas terminé
                        foreach (CProjet fils in lst)
                        {
                            if (projet == null)
                                projet = fils;
                            else if (projet.DateFinRelle != null && fils.DateFinRelle == null)
                                projet = fils;
                            else if (projet.DateFinGantt < fils.DateFinGantt)
                                projet = fils;
                        }
                    }
                }
            }
            return projet;
        }

        //--------------------------------------------------------------------------
        public static CResultAErreur LinkProjetToWorkflowStep(CProjet projet,
            CWorkflow workflow,
            string strTypeEtape,
            bool bSynchronizeStarts)
        {
            CResultAErreur result = CResultAErreur.True;
            CTypeEtapeWorkflow typeEtape = new CTypeEtapeWorkflow ( projet.ContexteDonnee );
            if ( !typeEtape.ReadIfExists(new CFiltreData ( CObjetDonnee.c_champIdUniversel+"=@1",
                strTypeEtape) ) )
            {
                result.EmpileErreur(I.T("Workflow step type @1 doesn't exists|20196", strTypeEtape ));
                return result;
            }
            if ( typeEtape.Workflow.Id != workflow.TypeWorkflow.Id )
            {
                result.EmpileErreur(I.T("Workflow step type @1 doesn't belong to workflow type @2|20197"),
                    strTypeEtape, workflow.TypeWorkflow.Libelle );
                return result;
            }
            CBlocWorkflowProjet blocProjet = typeEtape.Bloc as CBlocWorkflowProjet;
            if(  blocProjet == null )
            {
                result.EmpileErreur(I.T("Step type @1 is not a valid project step|20198",
                    typeEtape.Libelle ));
                return result;
            }
            CResultAErreurType<CEtapeWorkflow> resEtape = workflow.CreateOrGetEtapeInCurrentContexte(typeEtape);
            if ( !resEtape )
            {
                result.EmpileErreur(resEtape.Erreur);
                return result;
            }
            if ( resEtape.DataType == null )
            {
                result.EmpileErreur(I.T("Erreur while creating step for type '@1'|20199",
                    typeEtape.Libelle));
                return result;
            }
            CWorkflow sousWkf = blocProjet.GetOrCreateWorkflowInCurrentContexte(resEtape.DataType);
            if ( sousWkf == null )
            {
                result.EmpileErreur(I.T("Erreur while creating workflow for stef @1|20200",
                    resEtape.DataType.Libelle ) );
                return result;
            }
            sousWkf.SetValeurChamp(blocProjet.IdChampProjet.Value, projet);
            projet.GanttId = blocProjet.GetGanttId(resEtape.DataType);
            return SynchroniseWorkflow ( 
                sousWkf, 
                projet, 
                projet.DateDebutReel != null && projet.DateFinRelle == null,
                bSynchronizeStarts);
            
        }

        //--------------------------------------------------------------------------
        /// <summary>
        /// Resynchronise un workflow avec un projet
        /// </summary>
        /// <param name="wkf"></param>
        /// <param name="projetRacine"></param>
        public static CResultAErreur SynchroniseWorkflow(
            CWorkflow wkf, 
            CProjet projetParent,
            bool bShouldStartWorkflow,
            bool bSynchroniserStarts)
        {
            CResultAErreur result = CResultAErreur.True;
            //Identifie toutes les étapes BlocWorkflowWorkflow
            List<CTypeEtapeWorkflow> lstTypeWkfWkf = new List<CTypeEtapeWorkflow>();
            foreach (CTypeEtapeWorkflow typeEtape in wkf.TypeWorkflow.Etapes)
            {
                if (typeEtape.Bloc is CBlocWorkflowWorkflow)
                    lstTypeWkfWkf.Add(typeEtape);
            }
            foreach (CTypeEtapeWorkflow typeEtape in lstTypeWkfWkf)
            {
                CResultAErreurType<CEtapeWorkflow> resEtape = wkf.CreateOrGetEtapeInCurrentContexte(typeEtape);
                if (!resEtape || resEtape.DataType == null)
                {
                    result.EmpileErreur(I.T("Error while creating step '@1'", typeEtape.Libelle));
                    result.EmpileErreur(resEtape.Erreur);
                    return result;
                }

                CBlocWorkflowWorkflow blocWkfWkf = typeEtape.Bloc as CBlocWorkflowWorkflow;

                CEtapeWorkflow etape = resEtape.DataType;

                CWorkflow sousWorkflow = blocWkfWkf.GetOrCreateWorkflowInCurrentContexte(etape);


                //Trouve le projet associé à l'étape
                CBlocWorkflowProjet blocProjet = blocWkfWkf as CBlocWorkflowProjet;
                if (blocProjet != null)
                {
                    CProjet projetEtape = FindProjetPourRattrapage(
                        projetParent, etape, blocProjet);

                    if (projetEtape != null)
                    {
                        if (blocProjet.IdChampProjet == null)
                        {
                            result.EmpileErreur(I.T("Workflow step @1 doesn't define a field to store associated project|20142", etape.Libelle));
                            return result;
                        }
                        sousWorkflow.SetValeurChamp(blocProjet.IdChampProjet.Value, projetEtape);
                        bool bShouldStartSousWorkflow = projetEtape.DateDebutReel != null &&
                            projetEtape.DateFinRelle == null;
                        DateTime? oldDateDebut = projetEtape.DateDebutReel;
                        result = SynchroniseWorkflow(sousWorkflow, projetEtape, bShouldStartSousWorkflow, bSynchroniserStarts);
                        if (!result)
                            return result;
                        if (bShouldStartSousWorkflow && oldDateDebut != null)//Remet les dates
                        {
                            etape.DateDebut = oldDateDebut;
                            projetEtape.DateDebutReel = oldDateDebut;
                        }
                    }
                }
                else
                {
                    result = SynchroniseWorkflow(sousWorkflow, projetParent, false, bSynchroniserStarts);
                }
            }
            if (bShouldStartWorkflow && !wkf.IsRunning && bSynchroniserStarts)
            {
                wkf.StartWorkflow(null);
            }
            return result;
        }
    }
}
