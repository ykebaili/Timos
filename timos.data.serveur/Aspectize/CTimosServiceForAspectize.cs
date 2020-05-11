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

namespace timos.data.serveur.Aspectize
{
    public class CTimosServiceForAspectize : MarshalByRefObject, ITimosServiceForAspectize
    {

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

            //CInfoSessionTiag.OnCreateSession(session);
            IInfoUtilisateur infosUser = session.GetInfoUtilisateur();
            if (infosUser != null)
            {
                Dictionary<string, object> dicoProperties = new Dictionary<string, object>();
                dicoProperties[CUtilTimosWebApp.c_champUserName] = infosUser.NomUtilisateur;
                dicoProperties[CUtilTimosWebApp.c_champUserLogin] = strLogin;
                dicoProperties[CUtilTimosWebApp.c_champUserKey] = infosUser.KeyUtilisateur.StringValue;
                dicoProperties[CUtilTimosWebApp.c_champSessionId] = session.IdSession;

                result.Data = dicoProperties;
            }
            return result;
        }

        public CResultAErreur GetTodosForUser(int nIdsession, string keyUtilisateur)
        {
            CResultAErreur result = CResultAErreur.True;
            DataSet ds = new DataSet("TIMOS");

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdsession);
            if (session != null)
            {
                CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false);
                CDonneesActeurUtilisateur user = CUtilSession.GetUserForSession(ctx);
                if (user != null && user.DbKey.StringValue == keyUtilisateur)
                {
                    if (user.Acteur != null)
                    {
                        CListeObjetsDonnees lstEtapesPourActeur = user.Acteur.GetEtapeWorkflowsEnCours();
                        // Remplir une table du DataSet contenant une liste de To do
                        try
                        {
                            DataTable dt = new DataTable(CEtapeWorkflow.c_nomTable);
                            dt.Columns.Add(CEtapeWorkflow.c_champId, typeof(int));
                            dt.Columns.Add(CEtapeWorkflow.c_champDateDebut, typeof(DateTime));
                            dt.Columns.Add(CEtapeWorkflow.c_champLibelle, typeof(string));

                            foreach (CEtapeWorkflow todo in lstEtapesPourActeur)
                            {
                                dt.Rows.Add(todo.Id, todo.DateDebut.Value, todo.Libelle);
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
            return result;
        }

        public CResultAErreur SaveToDo(int nIdsession, DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;

            return result;
        }
    }
}
