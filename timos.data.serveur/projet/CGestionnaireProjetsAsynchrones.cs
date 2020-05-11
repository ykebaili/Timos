using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.common;
using System.Threading;
using sc2i.data.serveur;
using sc2i.process;
using timos.data.projet;

namespace timos.data.serveur.projet
{

    public class CElementsProjetARecalculer
    {
        private HashSet<int> m_listeIdsProjets = new HashSet<int>();
        private HashSet<int> m_listeIdsMetatProjets = new HashSet<int>();
        private int m_nIdSession = -1;

        public CElementsProjetARecalculer(int nIdSession)
        {
            m_nIdSession = nIdSession;
        }

        //-------------------------------------------------
        public void AddProjet(int nIdProjet)
        {
            m_listeIdsMetatProjets.Add(nIdProjet);
        }

        //-------------------------------------------------
        public void AddMetaProjet(int nIdMetaProjet)
        {
            m_listeIdsMetatProjets.Add(nIdMetaProjet);
        }

        //-------------------------------------------------
        public int IdSession
        {
            get
            {
                return m_nIdSession;
            }
        }

        //-------------------------------------------------
        public int[] IdsProjets
        {
            get
            {
                return m_listeIdsProjets.ToArray();
            }
        }

        //-------------------------------------------------
        public int[] IdsMetaProjets
        {
            get
            {
                return m_listeIdsMetatProjets.ToArray();
            }
        }
    }


    public static class CGestionnaireProjetsAsynchrones
    {
        public const string c_ModeCalculProjetsAsynchrone = "PROJETS_ASYNC_MODE";

        private class CLockerProjets{}

        //-----------------------------------------------------------------------------------------------
        public static void ASyncCalc(int nIdSession, IEnumerable<int> lstIdsProjets, IEnumerable<int> lstIdsMetaProjets)
        {
            if (lstIdsMetaProjets.Count() == 0 && lstIdsProjets.Count() == 0)
                return;
            CElementsProjetARecalculer lstElements = new CElementsProjetARecalculer(nIdSession);
            foreach (int nIdProjet in lstIdsProjets)
                lstElements.AddProjet(nIdProjet);
            foreach (int nIdMetaProjet in lstIdsMetaProjets)
                lstElements.AddMetaProjet(nIdMetaProjet);
            
            CalcElementsInThread(lstElements);
        }
        //-----------------------------------------------------------------------------------------------
        public static bool IsModeCalculProjet(CContexteDonnee contexte)
        {
            object val = contexte.ExtendedProperties[c_ModeCalculProjetsAsynchrone];
            return val is bool && (bool)val == true;
        }

        //-----------------------------------------------------------------------------------------------
        private static void SetModeCalculProjet(CContexteDonnee contexte)
        {
            contexte.ExtendedProperties[c_ModeCalculProjetsAsynchrone] = true;
        }

        
        /// //////////////////////////////////////////////////
        ///Démarre une étape dans un thread séparé
        public static void CalcElementsInThread(CElementsProjetARecalculer lstElements)
        {
            Thread th = new Thread(DoCalcInThread);
            int nIdSession = lstElements.IdSession;
            //Lance l'étape dans la session root, car la sousSEssion peut être fermée avant que
            //L'étape ne soit lancée !
            CSousSessionClient session = CSessionClient.GetSessionForIdSession(lstElements.IdSession) as CSousSessionClient;
            if (session != null)
                nIdSession = session.RootSession.IdSession;

            th.Start(lstElements);
        }

        /// //////////////////////////////////////////////////
        private static void DoCalcInThread(object objParam)
        {
            CElementsProjetARecalculer lstElements = objParam as CElementsProjetARecalculer;
            if (lstElements != null)
                DoCalc(lstElements);
        }

        private class CLockerStartEtape { }

        /// //////////////////////////////////////////////////
        ///Lance le calcul
        public static void DoCalc(CElementsProjetARecalculer lstElements)
        {
            CResultAErreur result = CResultAErreur.True;
            CDbKey keyUser = null;
            //Attend la fin des transactions en cours pour la session principale
            IDatabaseConnexion cnx = null;
            do
            {
                CSessionClient session = CSessionClient.GetSessionForIdSession(lstElements.IdSession);
                if (session != null && session.IsConnected)
                {
                    IInfoUtilisateur info = session.GetInfoUtilisateur();
                    //TESTDBKEYOK
                    if (info != null)
                        keyUser = info.KeyUtilisateur;
                    try
                    {
                        cnx = CSc2iDataServer.GetInstance().GetDatabaseConnexion(lstElements.IdSession, typeof(CProjet));
                    }
                    catch //En cas d'erreur, c'est probablement que la session a été fermée, du coup, on peut y aller !
                    {
                        cnx = null;
                    }
                    System.Threading.Thread.Sleep(50);
                }
                else
                    cnx = null;
            }
            while (cnx != null && cnx.IsInTrans());
            lock (typeof(CLockerStartEtape))//S'assure que deux étapes ne démarrent pas en même temps !
            {
                CAuthentificationSessionProcess auth = new CAuthentificationSessionProcess();

                using (CSessionClient sousSession = CSessionClient.CreateInstance())
                {
                    try
                    {
                        sousSession.OpenSession(auth, "Projet asynchronous calc ", ETypeApplicationCliente.Process);
                        if (keyUser != null)
                            sousSession.ChangeUtilisateur(keyUser);
                        using (CContexteDonnee ctx = new CContexteDonnee(sousSession.IdSession, true, true))
                        {
                            SetModeCalculProjet(ctx);
                            foreach (int nIdProjet in lstElements.IdsProjets)
                            {
                                CProjet projet = new CProjet(ctx);
                                if (projet.ReadIfExists(nIdProjet))
                                    projet.RecalculateDates(false);
                            }
                            foreach (int nIdMetaProjet in lstElements.IdsMetaProjets)
                            {
                                CMetaProjet meta = new CMetaProjet(ctx);
                                if (meta.ReadIfExists(nIdMetaProjet))
                                {
                                    meta.UpdateDateDebutPlanifieeFromChilds(false);
                                    meta.UpdateDateFinPlanifieeFromChilds(false);
                                    meta.UpdateDateDebutReelleFromChilds(false);
                                    meta.UpdateDateFinReelleFromChilds(false);
                                    meta.CalcProgress(false);
                                }
                            }

                            result = ctx.SaveAll(false);
                        }
                    }
                    catch (Exception e)
                    {
                    }
                    finally
                    {
                        sousSession.CloseSession();
                    }
                }
            }
        }
    }
}
