﻿using System;
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
using sc2i.data.dynamic;
using sc2i.formulaire;
using System.IO;

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

            private const int c_delaiSessionEnMinutes = 60;

            //---------------------------------------------------
            protected CInfoSessionAspectize(CSessionClient session)
            {
                // On garde la session ouverte 10 minutes...ou plus
                m_dateTimeSuppression = DateTime.Now.AddMinutes(c_delaiSessionEnMinutes); // 1 minutes pour tester
                m_listeSessions[session.IdSession] = this;
                m_nIdSession = session.IdSession;
                m_sessionClient = session;
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
                    info.m_dateTimeSuppression = DateTime.Now.AddMinutes(c_delaiSessionEnMinutes);
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
            result = session.OpenSession(authParams, "Timos Web App", ETypeApplicationCliente.Web);

            if (!result)
            {
                result.EmpileErreur("Erreur lors de l'ouverture de session Aspectize pour l'utilisateur " + strLogin);
                return result;
            }
            CInfoSessionAspectize.OnCreateSession(session);

            DataTable dt = CUserTimosWebApp.GetStructureTable();
            CUserTimosWebApp user = new CUserTimosWebApp(session, dt.NewRow(), strLogin);
            dt.Rows.Add(user.Row);

            result.Data = user.Properties;

            return result;
        }

        //-----------------------------------------------------------------------------------------------------
        public void CloseSession(int nIdSession)
        {
            CInfoSessionAspectize.OnCloseSession(nIdSession);
            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session != null)
                session.CloseSession();
        }

        //------------------------------------------------------------------------------------------------------
        public CResultAErreur GetSession(int nIdSession)
        {
            CResultAErreur result = CResultAErreur.True;

            CSessionClient session = CSessionClient.GetSessionForIdSession(nIdSession);
            if (session == null)
            {
                result.EmpileErreur("La session Timos N° " + nIdSession + " a expiré");
                return result;
            }
            CInfoSessionAspectize.RenouvelleSession(nIdSession);

            try
            {
                result.Data = session.GetInfoUtilisateur().KeyUtilisateur.StringValue;
            }
            catch (Exception)
            {
                result.EmpileErreur("La session Timos N° " + nIdSession + " a expiré");
                return result;
            }      

            return result;
        }

        //------------------------------------------------------------------------------------------------------
        public CResultAErreur GetTodosForUser(int nIdsession, string keyUtilisateur)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdsession);
            CResultAErreur result = CUtilTimosWebApp.GetTodosForUser(nIdsession, keyUtilisateur);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        // Retourne le détail des champs d'un todo unique
        public CResultAErreur GetTodoDetails(int nIdSession, int nIdTodo)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.GetTodoDetails(nIdSession, nIdTodo);
            return result;
        }


        //---------------------------------------------------------------------------------------------------------
        // Enregistre les données du to do
        public CResultAErreur SaveTodo(int nIdSession, DataSet ds, int nIdTodo, string elementType, int elementId)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.SaveTodo(nIdSession, ds, nIdTodo, elementType, elementId);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        // Enregistre les données d'une Carateristique
        public CResultAErreur SaveCaracteristique(int nIdSession, DataSet dataSet, int nIdCarac, string strTypeElement, int nIdTodo)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.SaveCaracteristique(
                nIdSession,
                dataSet,
                nIdCarac,
                strTypeElement,
                nIdTodo);

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur DeleteCaracteristique(int nIdSession, int nIdCarac, string strTypeElement)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.DeleteCaracteristique(
                nIdSession,
                nIdCarac,
                strTypeElement);

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur AddFile(int nIdSession, string strNompFichier, byte[] octets)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.AddFile(strNompFichier, octets);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur DeleteFile(int nIdSession, string strKeyFile)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.DeleteFile(nIdSession, strKeyFile);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur DownloadFile(int nIdSession, string strKeyFile)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.DownloadFile(nIdSession, strKeyFile);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur SaveDocument(int nIdSession, DataSet ds, int nIdDocument, int nIdCategorie)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.SaveDocument(nIdSession, ds, nIdDocument, nIdCategorie);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur EndTodo(int nIdSession, int nIdTodo)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.EndTodo(nIdSession, nIdTodo);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur GetActionsForUser(int nIdSession, string keyUser)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.GetActionsDisponibles(nIdSession, keyUser);
            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur ExecuteAction(int nIdSession, DataSet ds, int nIdAction, string strTypeCible, int nIdElementCible)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.ExecuteAction(nIdSession, ds, nIdAction, strTypeCible, nIdElementCible);
            return result;
        }

        //------------------------------------------------------------------------------------------------------
        public CResultAErreur GetExportsForUser(int nIdsession, string keyUtilisateur)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdsession);
            CResultAErreur result = CUtilTimosWebApp.GetExportsForUser(nIdsession, keyUtilisateur);
            return result;
        }
        //------------------------------------------------------------------------------------------------------
        public CResultAErreur GetDataSetExport(int nIdSession, string keyExport)
        {
            CInfoSessionAspectize.RenouvelleSession(nIdSession);
            CResultAErreur result = CUtilTimosWebApp.GetDataSetExport(nIdSession, keyExport);
            return result;
        }
    }
}
