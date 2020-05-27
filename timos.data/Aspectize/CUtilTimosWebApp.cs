using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.dynamic.NommageEntite;
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

        private const string c_listeIdsTypesCaracsDocuements = "101, 281";

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
                        DataTable tableChampsTimosWeb = CChampTimosWebApp.GetStructureTable();
                        DataTable tableValeursChamps = CTodoValeurChamp.GetStructureTable();
                        DataTable tableValeursPossibles = CChampValeursPossibles.GetStructureTable();
                        DataTable tableDocuementsAttendus = CDocumentAttendu.GetStructureTable();
                        DataTable tableFichiersGED = CFichierAttache.GetStructureTable();

                        ds.Tables.Add(tableTodos);
                        ds.Tables.Add(tableChampsTimosWeb);
                        ds.Tables.Add(tableValeursChamps);
                        ds.Tables.Add(tableValeursPossibles);
                        ds.Tables.Add(tableDocuementsAttendus);
                        ds.Tables.Add(tableFichiersGED);

                        result = FillDataSet(etapeEnCours, ds);

                        if (result)
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

        //------------------------------------------------------------------------------------------------------
        private static CResultAErreur FillDataSet(CEtapeWorkflow etape, DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;

            CTodoTimosWebApp todo = new CTodoTimosWebApp(ds, etape);
            result = todo.FillDataSet(ds);

            return result;
        }
            
            
        //------------------------------------------------------------------------------------------------------
        public static CResultAErreur SaveTodo(int nIdSession, DataSet ds, int nIdTodo, string elementType, int elementId)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {

                    CEtapeWorkflow etapeEnCours = new CEtapeWorkflow(ctx);
                    if (etapeEnCours.ReadIfExists(nIdTodo))
                    {
                        Type tp = CActivatorSurChaine.GetType(elementType);
                        if (tp == null)
                        {
                            result.EmpileErreur("Le type " + elementType + " n'existe pas dans Timos");
                            return result;
                        }
                        IObjetDonneeAChamps obj = (IObjetDonneeAChamps)Activator.CreateInstance(tp, new object[] { ctx });
                        if (obj.ReadIfExists(elementId))
                        {
                            DataTable dt = ds.Tables["TodoValeurChamp"];
                            if(dt != null)
                            {
                                CResultAErreur resBoucle = CResultAErreur.True;
                                foreach (DataRow row in dt.Rows)
                                {
                                    int nIdChamp = (int)row[CTodoValeurChamp.c_champId];
                                    var valeur = row[CTodoValeurChamp.c_champValeur];
                                    CChampCustom champ = new CChampCustom(ctx);
                                    if (champ.ReadIfExists(nIdChamp))
                                    {
                                        if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                                        {
                                            try
                                            {
                                                resBoucle = CUtilElementAChamps.SetValeurChamp(obj, nIdChamp, Int32.Parse(valeur.ToString()));
                                            }
                                            catch(Exception ex)
                                            {
                                                resBoucle.EmpileErreur("Erreur SetValeurChamp Id : " + nIdChamp + ". " + ex.Message);
                                            }
                                        }
                                        else
                                            resBoucle = CUtilElementAChamps.SetValeurChamp(obj, nIdChamp, valeur);

                                        if (!resBoucle)
                                            result.EmpileErreur(resBoucle.MessageErreur);
                                        var newValeur = CUtilElementAChamps.GetValeurChamp(obj, nIdChamp);
                                        resBoucle = champ.IsCorrectValue(newValeur);
                                        if (!resBoucle)
                                            result.EmpileErreur(resBoucle.MessageErreur);
                                    }
                                    
                                }
                                if(!result)
                                {
                                    result.EmpileErreur("Erreur de sauvegarde dans Timos");
                                    return result;
                                }
                                result = ctx.SaveAll(true);
                                return result;
                            }
                        }
                        else
                        {
                            result.EmpileErreur("L'objet id " + elementId + " n'existe pas dans Timos");
                            return result;
                        }
                    }
                    else
                    {
                        result.EmpileErreur("Le todo id " + nIdTodo + " n'existe pas dans Timos");
                        return result;
                    }
                }
            }

            return result;
        }


    }

}
