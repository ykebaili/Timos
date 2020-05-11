using System;
using System.Collections.Generic;
using System.Text;
using sc2i.common;
using System.Threading;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using spv.data;
using spv.data.ConsultationAlarmes;
using sc2i.data.serveur;
using spv.data.serveur;
using System.Data.OracleClient;


namespace spv.serveur
{
    /// <summary>
    /// Effectue le démasquage automatique des alarmes, en retrouvant les dates de fin de masquage
    /// expirées. Déclenche également les traitements de démasquage alarme fille par alarme mère.
    /// </summary>
    [AutoExec("Autoexec")]
    public static class CDemasquageAlarmes
    {

        private static bool m_bAutoexecFait = false;
        private static Object thisLock = new Object();

        public static void Autoexec()
        {
            lock (thisLock)
            {
                if (m_bAutoexecFait)
                    return;
                m_bAutoexecFait = true;
            }
            Thread th = new Thread(new ThreadStart(Demasque));
            th.Start();
        }

        public static void Demasque()
        {
            int c_nAttente = 500;                       // 500 ms d'attente dans la boucle
            int nNbToursBoucle = 1800000 / c_nAttente;  // Nb de tours de boucle pour 1/2h d'attente
            Thread.Sleep(50000);

            CSessionClient session = CSessionClient.CreateInstance();
            session.OpenSession(new CAuthentificationSessionServer(), "Unmask alarms", ETypeApplicationCliente.Service);

            
            IDatabaseConnexion connexion = CSc2iDataServer.GetInstance().GetDatabaseConnexion ( session.IdSession, CSpvServeur.c_spvConnection );
            string stSQL = "Begin MaskModified; end;";
            CResultAErreur result;
            int nErreur1 = 0, nErreur2 = 0;

            while (true)
            {

                // Démasquage
                result = CResultAErreur.True;
                try
                {
                    // Démasquage
                    result += connexion.BeginTrans();
                    if (result)
                        result += connexion.ExecuteScalar(stSQL);

                    if (result)
                        result += connexion.CommitTrans();
                    else
                        connexion.RollbackTrans();
                }
                catch (Exception e)
                {
                    result.EmpileErreur (e.Message);
                }

                if (!result)
                {
                    if (nErreur1 == 0)
                    {
                        C2iEventLog.WriteErreur(I.T("Problem with unmasking alarms automatically|50000"));
                         nErreur1++;
                     }
                 }

                // Pour ne pas trop encombrer les événements windows
                if (nErreur1 > 0)
                    nErreur1++;
                else if (nErreur1 > nNbToursBoucle) // Equipvaut à 1/2 heure
                    nErreur1 = 0;

                // Démasquage alarmes filles (traitement déconnecté du précédent)
                try
                {
                    result = connexion.BeginTrans();
                    if (result)
                        result += connexion.ExecuteScalar("DELETE " + CSpvFinalarm.c_nomTableInDb);

                    if (result)
                        result += connexion.CommitTrans();
                    else
                        connexion.RollbackTrans();

                }
                catch (Exception e)
                {
                    result.EmpileErreur(e.Message);
                }

                if (!result)
                {
                    if (nErreur2 == 0)
                    {
                        C2iEventLog.WriteErreur(I.T("Problem with unmasking child alarms automatically|50001"));
                        nErreur2++;
                    }
                }

                // Pour ne pas trop encombrer les événements windows
                if (nErreur2 > 0)
                    nErreur2++;
                else if (nErreur2 > nNbToursBoucle) // Equipvaut à 1/2 heure
                    nErreur2 = 0;

                if (C2iStopApp.AppStopper.WaitOne(c_nAttente, false))
                    break;
            }
        }

        
    }
}
