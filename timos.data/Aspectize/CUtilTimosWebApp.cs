using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.dynamic.NommageEntite;
using sc2i.documents;
using sc2i.expression;
using sc2i.formulaire;
using sc2i.multitiers.client;
using sc2i.process;
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
            ds.RemotingFormat = SerializationFormat.Binary;

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
            ds.RemotingFormat = SerializationFormat.Binary;

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
                        DataTable tableCaracteristiques = CCaracteristique.GetStructureTable();
                        DataTable tableChampsTimosWeb = CChampTimosWebApp.GetStructureTable();
                        DataTable tableTodoValeursChamps = CTodoValeurChamp.GetStructureTable();
                        DataTable tableCaracValeursChamps = CCaracValeurChamp.GetStructureTable();
                        DataTable tableValeursPossibles = CChampValeursPossibles.GetStructureTable();
                        DataTable tableDocuementsAttendus = CDocumentAttendu.GetStructureTable();
                        DataTable tableFichiersGED = CFichierAttache.GetStructureTable();
                        DataTable tableActions = CActionWeb.GetStructureTable();

                        ds.Tables.Add(tableTodos);
                        ds.Tables.Add(tableGroupesChamps);
                        ds.Tables.Add(tableCaracteristiques);
                        ds.Tables.Add(tableChampsTimosWeb);
                        ds.Tables.Add(tableTodoValeursChamps);
                        ds.Tables.Add(tableCaracValeursChamps);
                        ds.Tables.Add(tableValeursPossibles);
                        ds.Tables.Add(tableDocuementsAttendus);
                        ds.Tables.Add(tableFichiersGED);
                        ds.Tables.Add(tableActions);

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
        public static CResultAErreur SaveTodo(int nIdSession, DataSet ds, int nIdTodo, string elementPrincipalType, int elementPrincipalId)
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
                        Type tp = CActivatorSurChaine.GetType(elementPrincipalType);
                        if (tp == null)
                        {
                            result.EmpileErreur("Le type " + elementPrincipalType + " n'existe pas dans Timos");
                            return result;
                        }
                        IObjetDonneeAChamps obj = (IObjetDonneeAChamps)Activator.CreateInstance(tp, new object[] { ctx });
                        if (obj.ReadIfExists(elementPrincipalId))
                        {
                            DataTable dt = ds.Tables[CTodoValeurChamp.c_nomTable];
                            if (dt != null)
                            {
                                CResultAErreur resBoucle = CResultAErreur.True;
                                foreach (DataRow row in dt.Rows)
                                {
                                    int nIdChamp = (int)row[CTodoValeurChamp.c_champId];
                                    string strElementType = (string)row[CTodoValeurChamp.c_champElementType];
                                    int nElementId = (int)row[CTodoValeurChamp.c_champElementId];
                                    var valeur = row[CTodoValeurChamp.c_champValeur];

                                    CChampCustom champ = new CChampCustom(ctx);
                                    if (champ.ReadIfExists(nIdChamp))
                                    {
                                        Type tpElementEdite = CActivatorSurChaine.GetType(strElementType);
                                        IObjetDonneeAChamps elementEdite = (IObjetDonneeAChamps)Activator.CreateInstance(tpElementEdite, new object[] { ctx });
                                        if (elementEdite.ReadIfExists(nElementId))
                                        {
                                            if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                                            {
                                                try
                                                {
                                                    resBoucle = CUtilElementAChamps.SetValeurChamp(elementEdite, nIdChamp, Int32.Parse(valeur.ToString()));
                                                }
                                                catch (Exception ex)
                                                {
                                                    resBoucle.EmpileErreur("Erreur SetValeurChamp Id : " + nIdChamp + ". " + ex.Message);
                                                }
                                            }
                                            else
                                                resBoucle = CUtilElementAChamps.SetValeurChamp(elementEdite, nIdChamp, valeur);

                                            if (!resBoucle)
                                                result.EmpileErreur(resBoucle.MessageErreur);
                                            var newValeur = CUtilElementAChamps.GetValeurChamp(elementEdite, nIdChamp);
                                            resBoucle = champ.IsCorrectValue(newValeur);
                                            if (!resBoucle)
                                                result.EmpileErreur(resBoucle.MessageErreur);
                                        }
                                    }
                                }
                                if (!result)
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
                            result.EmpileErreur("L'objet id " + elementPrincipalId + " n'existe pas dans Timos");
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
                using (CContexteDonnee ctx = new CContexteDonnee(nIdSession, true, false))
                {
                    CEtapeWorkflow etapeATerminer = new CEtapeWorkflow(ctx);
                    if (etapeATerminer.ReadIfExists(nIdTodo))
                    {
                        //etapeATerminer = etapeATerminer.GetObjetInContexte(ctx) as CEtapeWorkflow;
                        if (etapeATerminer.EtatCode == (int)EEtatEtapeWorkflow.Démarrée)
                        {
                            result = etapeATerminer.EndEtapeAndSaveIfOk();
                            if (result)
                            {

                                DataSet ds = new DataSet(c_dataSetName);
                                ds.RemotingFormat = SerializationFormat.Binary;
                                DataTable dt = CTodoTimosWebApp.GetStructureTable();
                                ds.Tables.Add(dt);
                                CTodoTimosWebApp todoTermine = new CTodoTimosWebApp(ds, etapeATerminer);
                                result.Data = ds;

                            }
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
        public static CResultAErreur DeleteCaracteristique(int nIdSession, int nIdCarac, string strTypeElement)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    Type typeElement = CActivatorSurChaine.GetType(strTypeElement);
                    if (typeElement == null)
                    {
                        result.EmpileErreur("Le type " + strTypeElement + " n'existe pas dans Timos");
                        return result;
                    }
                    IObjetDonneeAChamps objCarac = (IObjetDonneeAChamps)Activator.CreateInstance(typeElement, new object[] { ctx });
                    if (objCarac.ReadIfExists(nIdCarac))
                    {
                        result = objCarac.Delete();
                    }
                }
            }
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur SaveCaracteristique(int nIdSession, DataSet dataSet, int nIdCarac, string strTypeElement, int nIdTodo)
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
                        Type typeElement = CActivatorSurChaine.GetType(strTypeElement);
                        if (typeElement == null)
                        {
                            result.EmpileErreur("Le type " + strTypeElement + " n'existe pas dans Timos");
                            return result;
                        }
                        IObjetDonneeAChamps objCarac = (IObjetDonneeAChamps)Activator.CreateInstance(typeElement, new object[] { ctx });
                        if (!objCarac.ReadIfExists(nIdCarac))
                        {
                            // Création d'un nouvel objet : Caractéristique, Dossier,...on ne sait pas ce que c'est ici
                            DataTable dtCaracteristique = dataSet.Tables[CCaracteristique.c_nomTable];
                            if (dtCaracteristique != null)
                            {
                                // Initialisation des champs de l'objet en fonciton de son type, et on l'associe à l'élément parent édité par le Todo en cours
                                foreach (DataRow rowCarac in dtCaracteristique.Rows)
                                {
                                    string strLibelle = (string)rowCarac[CCaracteristique.c_champTitre];
                                    int nIdMetaType = (int)rowCarac[CCaracteristique.c_champIdMetaType];
                                    string strTypeElmentParent = (string)rowCarac[CCaracteristique.c_champParentElementType];
                                    int nIdElementParent = (int)rowCarac[CCaracteristique.c_champParentElementId];

                                    Type tpParent = CActivatorSurChaine.GetType(strTypeElmentParent);
                                    if (tpParent == null)
                                    {
                                        result.EmpileErreur("Le type " + strTypeElmentParent + " n'existe pas dans Timos");
                                        return result;
                                    }
                                    IObjetDonneeAChamps objParent = (IObjetDonneeAChamps)Activator.CreateInstance(tpParent, new object[] { ctx });
                                    if (objParent.ReadIfExists(nIdElementParent)) // Element parent trouvé
                                    {

                                        if (objCarac is CCaracteristiqueEntite)
                                        {
                                            CCaracteristiqueEntite caracTimos = objCarac as CCaracteristiqueEntite;
                                            caracTimos.CreateNewInCurrentContexte();
                                            caracTimos.Libelle = strLibelle;
                                            CTypeCaracteristiqueEntite typeCarac = new CTypeCaracteristiqueEntite(ctx);
                                            if (typeCarac.ReadIfExists(nIdMetaType))
                                                caracTimos.TypeCaracteristique = typeCarac;
                                            caracTimos.ElementSuivi = objParent as CObjetDonneeAIdNumerique;
                                        }
                                        else if (objCarac is CDossierSuivi)
                                        {
                                            CDossierSuivi dossierTimos = objCarac as CDossierSuivi;
                                            dossierTimos.CreateNewInCurrentContexte();
                                            dossierTimos.Libelle = strLibelle;
                                            CTypeDossierSuivi typeDossier = new CTypeDossierSuivi(ctx);
                                            if (typeDossier.ReadIfExists(nIdMetaType))
                                                dossierTimos.TypeDossier = typeDossier;
                                            dossierTimos.ElementSuivi = objParent as CObjetDonneeAIdNumerique;
                                        }
                                        else if (objCarac is CSite)
                                        {
                                            CSite siteTimos = objCarac as CSite;
                                            siteTimos.CreateNewInCurrentContexte();
                                            siteTimos.Libelle = strLibelle;
                                            siteTimos.Code = "ND";
                                            CTypeSite typeSite = new CTypeSite(ctx);
                                            if (typeSite.ReadIfExists(nIdMetaType))
                                                siteTimos.TypeSite = typeSite;
                                        }
                                    }
                                    else
                                    {
                                        result.EmpileErreur("L'élément parent id " + nIdElementParent + " n'existe pas dans Timos");
                                        return result;
                                    }
                                }
                            }
                        }
                        DataTable dtValeurs = dataSet.Tables[CCaracValeurChamp.c_nomTable];
                        if (dtValeurs != null)
                        {
                            CResultAErreur resBoucle = CResultAErreur.True;
                            foreach (DataRow row in dtValeurs.Rows)
                            {
                                int nIdChamp = (int)row[CCaracValeurChamp.c_champId];
                                var valeur = row[CCaracValeurChamp.c_champValeur];

                                CChampCustom champ = new CChampCustom(ctx);
                                if (champ.ReadIfExists(nIdChamp))
                                {
                                    if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                                    {
                                        try
                                        {
                                            int nIdvaleur = -1;
                                            if (Int32.TryParse(valeur.ToString(), out nIdvaleur))
                                                resBoucle = CUtilElementAChamps.SetValeurChamp(objCarac, nIdChamp, nIdvaleur);
                                        }
                                        catch (Exception ex)
                                        {
                                            resBoucle.EmpileErreur("Erreur SetValeurChamp Id : " + nIdChamp + ". " + ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        resBoucle = CUtilElementAChamps.SetValeurChamp(objCarac, nIdChamp, valeur);
                                    }
                                    if (!resBoucle)
                                        result.EmpileErreur(resBoucle.MessageErreur);
                                    var newValeur = CUtilElementAChamps.GetValeurChamp(objCarac, nIdChamp);
                                    if (valeur.ToString() != "")
                                        resBoucle = champ.IsCorrectValue(newValeur);
                                    if (!resBoucle)
                                        result.EmpileErreur("Controle de valeur de champ Timos : " + resBoucle.MessageErreur);
                                }
                            }
                            if (!result)
                            {
                                result.EmpileErreur("Erreur de sauvegarde dans Timos");
                                return result;
                            }
                        }
                        result = ctx.SaveAll(true);
                        if (!result)
                            return result;

                        DataSet dsRetour = new DataSet(c_dataSetName);
                        dsRetour.RemotingFormat = SerializationFormat.Binary;

                        // On rempli le DataSet uniquement si c'est une création de Caractéristique
                        if (nIdCarac < 0)
                        {
                            DataTable tableTodos = CTodoTimosWebApp.GetStructureTable();
                            DataTable tableGroupesChamps = CGroupeChamps.GetStructureTable();
                            DataTable tableCaracteristiques = CCaracteristique.GetStructureTable();
                            DataTable tableChampsTimosWeb = CChampTimosWebApp.GetStructureTable();
                            DataTable tableTodoValeursChamps = CTodoValeurChamp.GetStructureTable();
                            DataTable tableCaracValeursChamps = CCaracValeurChamp.GetStructureTable();
                            DataTable tableValeursPossibles = CChampValeursPossibles.GetStructureTable();

                            dsRetour.Tables.Add(tableTodos);
                            dsRetour.Tables.Add(tableGroupesChamps);
                            dsRetour.Tables.Add(tableCaracteristiques);
                            dsRetour.Tables.Add(tableChampsTimosWeb);
                            dsRetour.Tables.Add(tableTodoValeursChamps);
                            dsRetour.Tables.Add(tableCaracValeursChamps);
                            dsRetour.Tables.Add(tableValeursPossibles);

                            result = FillDataSet(etapeEnCours, dsRetour);
                        }
                        result.Data = dsRetour;
                        return result;
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

            if (result)
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
                        if (doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1 OR " + CDocumentGED.c_champIdUniversel + " = @1", strCle)))
                        {
                            result = doc.Delete(true);
                        }
                        if (result)
                        {
                            result = ctx.SaveAll(true);
                            return result;
                        }
                    }
                    catch (Exception ex)
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
                    if (doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1 OR " + CDocumentGED.c_champIdUniversel + " = @1", strCle)))
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
                            catch (Exception ex)
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
                                    if (!doc.ReadIfExists(new CFiltreData(CDocumentGED.c_champCle + " = @1 OR " + CDocumentGED.c_champIdUniversel + " = @1", strCle)))
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

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur GetActionsDisponibles(int nIdSession, string strTypeCible)
        {
            CResultAErreur result = CResultAErreur.True;

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur ExecuteAction(int nIdSession, DataSet ds, int nIdAction, string strTypeCible, int nIdElementCible)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CProcessInDb process = new CProcessInDb(ctx);
                    if (process.ReadIfExists(nIdAction))
                    {
                        CProcess processToExecute = process.Process;
                        if (process != null)
                        {
                            Type tp = CActivatorSurChaine.GetType(strTypeCible);
                            if (tp == null)
                            {
                                result.EmpileErreur("Le type " + strTypeCible + " n'existe pas dans Timos");
                                return result;
                            }
                            CObjetDonnee cibleProcess = (CObjetDonnee)Activator.CreateInstance(tp, new object[] { ctx });
                            if (cibleProcess.ReadIfExists(nIdElementCible))
                            {
                                if (process.TypeCible.IsAssignableFrom(cibleProcess.GetType()) && cibleProcess is CObjetDonnee)
                                {
                                    CReferenceObjetDonnee refCible = new CReferenceObjetDonnee(cibleProcess);

                                    // Affecte les vairables du process
                                    DataTable tableActions = ds.Tables[CActionWeb.c_nomTable];
                                    if (tableActions != null && tableActions.Rows.Count > 0)
                                    {
                                        DataRow row = tableActions.Rows[0];
                                        foreach (CVariableDynamique variable in processToExecute.ListeVariables)
                                        {
                                            foreach (DataColumn col in tableActions.Columns)
                                            {
                                                try
                                                {
                                                    if (col.DataType == typeof(string) && row[col] != DBNull.Value && (string)row[col] == variable.IdVariable)
                                                    {
                                                        string nomCol = col.ColumnName; // Ex: IDT3, IDN2, IDD1
                                                        nomCol = nomCol.Replace("ID", "VAL");
                                                        object valeur = row[nomCol];
                                                        processToExecute.SetValeurChamp(variable.IdVariable, valeur);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    result.EmpileErreur(ex.Message);
                                                }
                                            }
                                        }
                                    }
                                    // Start Process
                                    return CProcessEnExecutionInDb.StartProcess(
                                        processToExecute,
                                        new CInfoDeclencheurProcess(TypeEvenement.Manuel),
                                        refCible,
                                        nIdSession,
                                        ctx.IdVersionDeTravail,
                                        null);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur GetExportsForUser(int nIdSession, string keyUtilisateur)
        {
            CResultAErreur result = CResultAErreur.True;
            DataSet ds = new DataSet(c_dataSetName);
            ds.RemotingFormat = SerializationFormat.Binary;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(ctx);
                    if (user != null && user.DbKey.StringValue == keyUtilisateur)
                    {
                        CListeObjetDonneeGenerique<C2iStructureExportInDB> listeStructures = new CListeObjetDonneeGenerique<C2iStructureExportInDB>(ctx);
                        listeStructures.Filtre = new CFiltreData(C2iStructureExportInDB.c_champWebVisible + " = @1", true);
                        try
                        {
                            DataTable dt = CExportWeb.GetStructureTable();
                            ds.Tables.Add(dt);
                            foreach (C2iStructureExportInDB structure in listeStructures)
                            {
                                try
                                {
                                    if (structure.GroupeParametrage != null)
                                    {
                                        C2iExpression formuleCondition = structure.GroupeParametrage.FormuleCondition;
                                        if (formuleCondition != null)
                                        {
                                            CContexteEvaluationExpression ctxFormule = new CContexteEvaluationExpression(structure.GroupeParametrage);
                                            CResultAErreur resCondiction = formuleCondition.Eval(ctxFormule);
                                            if (resCondiction && resCondiction.Data != null)
                                            {
                                                if (resCondiction.Data.ToString() == "0" || resCondiction.Data.ToString().ToUpper() == "FALSE")
                                                    continue;
                                            }
                                        }
                                    }
                                    CExportWeb export = new CExportWeb(ds, structure);
                                }
                                catch { }
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
                        result.EmpileErreur("Utilisateur " + keyUtilisateur + " non valide");
                    }
                }
            }
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public static CResultAErreur GetDataSetExport(int nIdSession, string keyExport)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    C2iStructureExportInDB structureExport = new C2iStructureExportInDB(ctx);
                    if(structureExport.ReadIfExists(CDbKey.CreateFromStringValue(keyExport)))
                    {
                        CMultiStructureExport structure = structureExport.MultiStructure;
                        if(structure != null)
                        {
                            result = structure.GetDataSet(false);
                        }
                    }
                    else
                    {
                        result.EmpileErreur("Structure d'Export " + keyExport + " non valide");
                    }
                }
            }
            return result;
        }
    }
}
