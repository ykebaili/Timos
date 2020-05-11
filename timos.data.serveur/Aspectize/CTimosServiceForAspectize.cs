using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using timos.data.Aspectize;
using System.Data;
using sc2i.multitiers.client;
using timos.client;
using sc2i.data;
using timos.securite;
using sc2i.workflow;
using sc2i.process.workflow;
using System.Threading;
using System.Collections;
using sc2i.process.workflow.blocs;
using sc2i.expression;

namespace timos.data.serveur.Aspectize
{
    public class CTimosServiceForAspectize : MarshalByRefObject, ITimosServiceForAspectize
    {

        //**************************************** Classe de gestion des sessions ************************************
        private class CInfoSessionAspectize
        {
            private CSessionClient m_sessionClient = null;
            private int m_nIdSession = -1;
            private DateTime m_dateTimeSuppression;

            private static Dictionary<int, CInfoSessionAspectize> m_listeSessions = new Dictionary<int, CInfoSessionAspectize>();

            private static Timer m_timer = null;


            //---------------------------------------------------
            protected CInfoSessionAspectize(CSessionClient session)
            {
                m_dateTimeSuppression = DateTime.Now.AddMinutes(10);
                m_listeSessions[session.IdSession] = this;
                m_nIdSession = session.IdSession;
                if (m_timer == null)
                {
                    m_timer = new Timer(new TimerCallback(OnNettoieSessions), null, 60000, 60000);
                }
            }

            //---------------------------------------------------
            public static void OnCreateSession(CSessionClient session)
            {
                CInfoSessionAspectize info = new CInfoSessionAspectize(session);
            }

            //---------------------------------------------------
            public DateTime DateSuppression
            {
                get
                {
                    return m_dateTimeSuppression;
                }
            }

            //---------------------------------------------------
            public CSessionClient SessionClient
            {
                get
                {
                    return m_sessionClient;
                }
            }

            //---------------------------------------------------
            public static void RenouvelleSession(int nIdSession)
            {
                CInfoSessionAspectize info = null;
                if (m_listeSessions.TryGetValue(nIdSession, out info))
                {
                    info.m_dateTimeSuppression = DateTime.Now.AddMinutes(10);
                }
            }

            //---------------------------------------------------
            private static void OnNettoieSessions(object state)
            {
                List<CInfoSessionAspectize> listeToDelete = new List<CInfoSessionAspectize>();
                ArrayList lst = new ArrayList(m_listeSessions.Values);
                foreach (CInfoSessionAspectize info in lst)
                    if (info.DateSuppression < DateTime.Now)
                        listeToDelete.Add(info);
                foreach (CInfoSessionAspectize info in listeToDelete)
                    StaticCloseSession(info);
            }

            //---------------------------------------------------
            private static void StaticCloseSession(CInfoSessionAspectize info)
            {
                try
                {
                    info.SessionClient.CloseSession();
                }
                catch
                {
                }
                if (m_listeSessions.ContainsValue(info))
                    m_listeSessions.Remove(info.m_nIdSession);
            }

            //---------------------------------------------------
            public static void OnCloseSession(int nIdSession)
            {
                if (m_listeSessions.ContainsKey(nIdSession))
                    m_listeSessions.Remove(nIdSession);
            }
        }

        //------------------------------------------------------------------------------------------------------
        public CResultAErreur OpenSession(string strLogin, string strPassword)
        {

            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.CreateInstance();
            // DEBUG result = session.OpenSession(new CAuthentificationSessionSousSession(0), "Aspectize", ETypeApplicationCliente.Service);
            
            CAuthentificationSessionTimosLoginPwd authParams = new CAuthentificationSessionTimosLoginPwd(
                        strLogin,
                        strPassword,
                        new CParametresLicence(new List<string>(), new List<string>()));
            result = session.OpenSession(authParams, "Aspectize", ETypeApplicationCliente.Service);

            if (!result)
            {
                result.EmpileErreur("Erreur lors de l'ouverture de session Aspectize pour l'utilisateur " + strLogin);
                return result;
            }

            CInfoSessionAspectize.OnCreateSession(session);

            IInfoUtilisateur infosUser = session.GetInfoUtilisateur();
            if (infosUser != null)
            {
                Dictionary<string, object> dicoProperties = new Dictionary<string, object>();
                dicoProperties[CUtilTimosUser.c_champUserName] = infosUser.NomUtilisateur;
                dicoProperties[CUtilTimosUser.c_champUserLogin] = strLogin;
                dicoProperties[CUtilTimosUser.c_champUserKey] = infosUser.KeyUtilisateur.StringValue;
                dicoProperties[CUtilTimosUser.c_champSessionId] = session.IdSession;

                result.Data = dicoProperties;
            }
            return result;
        }

        //---------------------------------------------------------------------------
        public void CloseSession(int nIdSession)
        {
            CInfoSessionAspectize.OnCloseSession(nIdSession);
            CSessionClient session = GetSession(nIdSession);
            if (session != null)
                session.CloseSession();
        }

        //------------------------------------------------------------------------------------------------------
        private CSessionClient GetSession(int nIdSession)
        {
            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);

            return session;
        }

        //------------------------------------------------------------------------------------------------------
        public CResultAErreur GetTodosForUser(int nIdsession, string keyUtilisateur)
        {
            CResultAErreur result = CResultAErreur.True;
            DataSet ds = new DataSet("TIMOS");

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
                                DataTable dt = new DataTable(CUtilTimosTodos.c_nomTable);
                                dt.Columns.Add(CUtilTimosTodos.c_champId, typeof(int));
                                dt.Columns.Add(CUtilTimosTodos.c_champDateDebut, typeof(DateTime));
                                dt.Columns.Add(CUtilTimosTodos.c_champLibelle, typeof(string));
                                dt.Columns.Add(CUtilTimosTodos.c_champInstructions, typeof(string));
                                dt.Columns.Add(CUtilTimosTodos.c_champTypeElementEdite, typeof(string));
                                dt.Columns.Add(CUtilTimosTodos.c_champIdElementEdite, typeof(int));
                                dt.Columns.Add(CUtilTimosTodos.c_champElementDescription, typeof(string));

                                foreach (CEtapeWorkflow todo in lstEtapesPourActeur)
                                {
                                    string strInstrcution = GetInstructionsForTodo(todo);
                                    string strTypeElementEdite = "";
                                    int nIdElementEdite = -1;
                                    string strElementDescription = "";
                                    CResultAErreur resObjet = GetElementEditePrincipal(todo);
                                    CObjetDonneeAIdNumerique objEdite = result.Data as CObjetDonneeAIdNumerique;
                                    if(objEdite != null)
                                    {
                                        strTypeElementEdite = objEdite.TypeString;
                                        nIdElementEdite = objEdite.Id;
                                        strElementDescription = objEdite.DescriptionElement;
                                    }

                                    dt.Rows.Add(todo.Id, 
                                                todo.DateDebut.Value,
                                                todo.Libelle, 
                                                strInstrcution);
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
        private string GetInstructionsForTodo(CEtapeWorkflow etapeEnCours)
        {
            string strResult = "Pas d'instructions";

            if (etapeEnCours != null)
            {
                CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                if (blocFormulaire == null)
                {
                    strResult = "Ce To do ne peut pas être traité dans l'application web Timos";
                    return strResult;
                }
                if (blocFormulaire.FormuleInstructions != null)
                {
                    C2iExpression expInstructions = blocFormulaire.FormuleInstructions;
                    CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                    CResultAErreur resEval = expInstructions.Eval(ctxEval);
                    if (resEval && resEval.Data != null)
                    {
                        strResult = resEval.Data.ToString();
                    }
                    else
                    {
                        strResult = etapeEnCours.Libelle + Environment.NewLine + resEval.Erreur.ToString();
                    }
                }
            }

            return strResult;
        }


        //---------------------------------------------------------------------------------------------------------
        private CResultAErreur GetElementEditePrincipal(CEtapeWorkflow etapeEnCours)
        {
            CResultAErreur result = CResultAErreur.True;

            if (etapeEnCours != null)
            {
                CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                if (blocFormulaire == null)
                {
                    result.EmpileErreur("Ce To do ne peut pas être traité dans l'application web Timos");
                    return result;
                }
                if (blocFormulaire.FormuleElementEditePrincipal != null)
                {
                    C2iExpression expElementEditePrincipal = blocFormulaire.FormuleElementEditePrincipal;
                    CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                    result = expElementEditePrincipal.Eval(ctxEval);
                    if (!result)
                        result.EmpileErreur("Erreur dans l'évaluation de l'élément édité principal du to do " + etapeEnCours.Id);
                }
            }

            return result;
        }


        //---------------------------------------------------------------------------------------------------------
        // Retourne le détail des champs d'un to do unique
        public CResultAErreur GetTodoDetails(int nIdSession, int nIdTodo)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CResultAErreur.True;

            
            
            return result;
        }


        // Enregistre les données du to do
        public CResultAErreur SaveTodo(int nIdSession, DataSet ds)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CResultAErreur.True;

            return result;
        }


    }
}
