using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.dynamic.NommageEntite;
using sc2i.documents;
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
using System.IO;
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
                                ds.Tables.Add(dt);
                                foreach (CEtapeWorkflow etape in lstEtapesPourActeur)
                                {
                                    CTodoTimosWebApp todo = new CTodoTimosWebApp(ds, etape);
                                }
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
                        DataTable tableGroupesChamps = CGroupeChamps.GetStructureTable();
                        DataTable tableChampsTimosWeb = CChampTimosWebApp.GetStructureTable();
                        DataTable tableValeursChamps = CTodoValeurChamp.GetStructureTable();
                        DataTable tableValeursPossibles = CChampValeursPossibles.GetStructureTable();
                        DataTable tableDocuementsAttendus = CDocumentAttendu.GetStructureTable();
                        DataTable tableFichiersGED = CFichierAttache.GetStructureTable();

                        ds.Tables.Add(tableTodos);
                        ds.Tables.Add(tableGroupesChamps);
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


        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur EndTodo(int nIdSession, int nIdTodo)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CEtapeWorkflow etapeATerminer = new CEtapeWorkflow(ctx);
                    if (etapeATerminer.ReadIfExists(nIdTodo))
                    {
                        if (etapeATerminer.EtatCode == (int)EEtatEtapeWorkflow.Démarrée)
                        {
                            result = etapeATerminer.EndEtapeAndSaveIfOk();

                            DataSet ds = new DataSet(c_dataSetName);
                            DataTable dt = CTodoTimosWebApp.GetStructureTable();
                            ds.Tables.Add(dt);
                            CTodoTimosWebApp todoTermine = new CTodoTimosWebApp(ds, etapeATerminer);

                            result.Data = ds;
                        }
                        else
                        {
                            result.EmpileErreur("L'étape id : " + nIdTodo + " n'est pas démarrée");
                        }
                    }
                }
            }

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur AddFile(string strNompFichier, byte[] octets)
        {
            CResultAErreur result = CResultAErreur.True;

            string strExt = "dat";
            int nPosPoint = strNompFichier.LastIndexOf(".");
            if (nPosPoint >= 0)
                strExt = strNompFichier.Substring(nPosPoint + 1);
            CFichierLocalTemporaire fichierTemporaire = new CFichierLocalTemporaire(strExt);
            FileStream fs = new FileStream(fichierTemporaire.NomFichier, FileMode.CreateNew);
            BinaryWriter writer = new BinaryWriter(fs);
            try
            {
                writer.Write(octets);
            }
            catch (Exception ex)
            {
                result.EmpileErreur(ex.Message);
            }
            finally
            {
                writer.Close();
                fs.Close();
            }

            if(result)
                result.Data = fichierTemporaire.NomFichier;

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur DeleteFile(int nIdSession, string strCle)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    try
                    {
                        CDocumentGED doc = new CDocumentGED(ctx);
                        if (doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1", strCle)))
                        {
                            result = doc.Delete(true);
                        }
                        if (result)
                        {
                            result = ctx.SaveAll(true);
                            return result;
                        }
                    }
                    catch(Exception ex)
                    {
                        result.EmpileErreur("Erreur de suppression du document GED : " + ex.Message);
                        return result;
                    }
                }
            }

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur DownloadFile(int nIdSession, string strCle)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CDocumentGED doc = new CDocumentGED(ctx);
                    if (doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1", strCle)))
                    {
                        CProxyGED proxyDownload = new CProxyGED(nIdSession, doc.ReferenceDoc);
                        result = proxyDownload.CopieFichierEnLocal();
                        if (!result)
                        {
                            return result;
                        }
                        else
                        {
                            FileStream fs = new FileStream(proxyDownload.NomFichierLocal, FileMode.Open, FileAccess.Read);
                            BinaryReader reader = new BinaryReader(fs);
                            try
                            {
                                byte[] octets = reader.ReadBytes((int)fs.Length);
                                result.Data = octets;
                                
                            }
                            catch(Exception ex)
                            {
                                result.EmpileErreur(ex.Message);
                            }
                            finally
                            {
                                reader.Close();
                                fs.Close();
                            }
                        }
                    }
                    else
                    {
                        result.EmpileErreur("Le fichier id : " + strCle + " n'existe pas dans Timos");
                        return result;
                    }
                }
            }

            return result;
        }


        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur SaveDocument(int nIdSession, DataSet ds, int nIdDocument, int nIdCategorie)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CCaracteristiqueEntite caracDocument = new CCaracteristiqueEntite(ctx);
                    if (caracDocument.ReadIfExists(nIdDocument))
                    {
                        CCategorieGED categorie = new CCategorieGED(ctx);
                        if (categorie.ReadIfExists(nIdCategorie))
                        {
                            DataTable dtFichiers = ds.Tables[CFichierAttache.c_nomTable];

                            if (dtFichiers != null)
                            {
                                foreach (DataRow rowFichier in dtFichiers.Rows)
                                {
                                    string strCle = (string)rowFichier[CFichierAttache.c_champKey];
                                    string strNomFichier = (string)rowFichier[CFichierAttache.c_champNomFichier];
                                    string strCheminTemp = (string)rowFichier[CFichierAttache.c_champCheminTemporaire];

                                    CDocumentGED doc = new CDocumentGED(ctx);
                                    if (!doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1", strCle)))
                                    {
                                        doc.CreateNewInCurrentContexte();
                                    }
                                    doc.Libelle = Path.GetFileName(strNomFichier);
                                    doc.AssocieA(caracDocument);
                                    doc.AssocieA(caracDocument.ElementSuivi);
                                    doc.AddCategory(categorie);
                                    doc.Cle = strCle;

                                    CProxyGED proxy = new CProxyGED(nIdSession, CTypeReferenceDocument.TypesReference.Fichier);
                                    proxy.AttacheToLocal(strCheminTemp);
                                    CResultAErreur resFichier = proxy.UpdateGed();
                                    if (!resFichier)
                                        return resFichier;
                                    CReferenceDocument refDoc = resFichier.Data as CReferenceDocument;
                                    doc.ReferenceDoc = refDoc;
                                }

                                result = ctx.SaveAll(true);
                                return result;
                            }
                        }
                        else
                        {
                            result.EmpileErreur("La catégorie de document id " + nIdCategorie + " n'existe pas dans Timos");
                            return result;
                        }
                    }
                    else
                    {
                        result.EmpileErreur("Le document attendu id " + nIdDocument + " n'existe pas dans Timos");
                        return result;
                    }
                }
            }

            return result;
        }


    }

}
