using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
using sc2i.formulaire;
using sc2i.multitiers.client;
using sc2i.process.workflow;
using sc2i.process.workflow.blocs;
using sc2i.workflow;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using timos.securite;

namespace timos.data.Aspectize
{
    /// <summary>
    /// Classe utilitaire pour Timos Web App
    /// </summary>
    public class CUtilTimosWebApp
    {
        private const string c_dataSetName = "TIMOS_DATA";

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur GetTodosForUser(int nIdsession, string keyUtilisateur)
        {
            CResultAErreur result = CResultAErreur.True;
            DataSet ds = new DataSet(c_dataSetName);
            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdsession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(ctx);
                    if (user != null && user.DbKey.StringValue == keyUtilisateur)
                    {
                        if (user.Acteur != null)
                        {
                            CListeObjetsDonnees lstEtapesPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                            // Remplir une table du DataSet contenant une liste de Todos
                            try
                            {
                                DataTable dt = CTodoTimosWebApp.GetStructureTable();
                                foreach (CEtapeWorkflow etape in lstEtapesPourActeur)
                                {
                                    CTodoTimosWebApp todo = new CTodoTimosWebApp(etape, dt.NewRow());
                                    dt.Rows.Add(todo.Row);
                                }
                                ds.Tables.Add(dt);
                                result.Data = ds;
                            }
                            catch (Exception ex)
                            {
                                result.EmpileErreur("ERREUR : " + ex.Message);
                                return result;
                            }
                        }
                        else
                        {
                            result.EmpileErreur("L'utilisateur " + user.Login + " n'a pas d'Acteur Timos associé");
                            return result;
                        }
                    }
                    else
                    {
                        result.EmpileErreur("Utilisateur non valide");
                    }
                }
            }
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur GetTodoDetails(int nIdSession, int nIdTodo)
        {
            CResultAErreur result = CResultAErreur.True;
            DataSet ds = new DataSet(c_dataSetName);
            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CEtapeWorkflow etapeEnCours = new CEtapeWorkflow(ctx);
                    if (etapeEnCours.ReadIfExists(nIdTodo))
                    {
                        DataTable tableTodos = CTodoTimosWebApp.GetStructureTable();
                        CTodoTimosWebApp todoEnCours = new CTodoTimosWebApp(etapeEnCours, tableTodos.NewRow());
                        tableTodos.Rows.Add(todoEnCours.Row);
                        ds.Tables.Add(tableTodos);

                        CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                        if (blocFormulaire == null)
                        {
                            result.EmpileErreur("Erreur GetTodoDetails : Ce To do n'a pas de formulaire associé dans Timos");
                            return result;
                        }

                        DataTable tableChampsTimosWeb = CChampTimosWebApp.GetStructureTable();
                        // Traite la liste des formulaires associés
                        foreach (CDbKey keyForm in blocFormulaire.ListeDbKeysFormulaires)
                        {
                            CFormulaire formulaire = new CFormulaire(ctx);
                            if (formulaire.ReadIfExists(keyForm))
                            {
                                string strLibelleFormulaire = formulaire.Libelle;

                                C2iWnd fenetre = formulaire.Formulaire;
                                if (fenetre != null)
                                {
                                    ArrayList lst = fenetre.AllChilds();
                                    foreach (object obj in lst)
                                    {
                                        if (obj is C2iWndChampCustom)
                                        {
                                            C2iWndChampCustom fenChamp = (C2iWndChampCustom)obj;
                                            CChampTimosWebApp champWeb = new CChampTimosWebApp(fenChamp, tableChampsTimosWeb.NewRow());
                                            tableChampsTimosWeb.Rows.Add(champWeb.Row);
                                        }
                                        /*else if (obj is C2iWndZoneMultiple)
                                        {
                                            C2iWndZoneMultiple childZone = (C2iWndZoneMultiple)obj;
                                            C2iWndSousFormulaire sousFenetre = childZone.FormulaireFils;
                                            //sousFenetre.AllChilds();

                                            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                                            CResultAErreur resEval = childZone.SourceFormula.Eval(ctxEval);
                                            if (resEval)
                                            {
                                                object datas = resEval.Data;

                                            }
                                        }*/

                                    }
                                }
                            }
                        }
                        ds.Tables.Add(tableChampsTimosWeb);
                        result.Data = ds;
                    }
                    else
                    {
                        result.EmpileErreur("Le todo N° " + nIdTodo + " nexiste pas");
                        return result;
                    }
                }
            }
            else
            {
                result.EmpileErreur("Session " + nIdSession + " invalide");
                return result;
            }

            return result;
        }

    }

}
