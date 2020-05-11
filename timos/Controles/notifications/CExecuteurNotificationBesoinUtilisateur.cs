using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.process.workflow;
using sc2i.multitiers.client;
using System.Drawing;
using sc2i.workflow;
using timos.Properties;
using sc2i.win32.data;
using timos.process.workflow;
using sc2i.process;

namespace timos.Controles.notifications
{
    [AutoExec("Autoexec")]
    public class CExecuteurNotificationBesoinUtilisateur : IExecuteurNotificationPopup
    {
        public static void Autoexec()
        {
            CGestionnaireNotificationsPopup.RegisterExecuteur(
                typeof(CDonneeNotificationBesoinIntervention),
                new CExecuteurNotificationBesoinUtilisateur());
        }

        //------------------------------------------------------------------------------------
        public void GetInfosPopup(IDonneeNotification donnee, ref bool bShouldDisplay, ref string strLibelle, ref Image image)
        {
            bShouldDisplay = false;
            CDonneeNotificationBesoinIntervention db = donnee as CDonneeNotificationBesoinIntervention;
            if (db == null)
            {
                return;
            }
            if (!db.IsDelete)
            {
                //TESTDBKEYOK
                IInfoUtilisateur info = CTimosApp.SessionClient.GetInfoUtilisateur();
                if (info != null && info.KeyUtilisateur == db.KeyUtilisateurConcerne)
                {
                    strLibelle = db.Libelle;
                    image = Resources.alerte;
                    bShouldDisplay = true;
                }
            }
        }

        //------------------------------------------------------------------------------------
        public void ExecuteNotification(IDonneeNotification donnee)
        {
            CDonneeNotificationBesoinIntervention db = donnee as CDonneeNotificationBesoinIntervention;
            if (db != null)
            {
                int nId = db.IdBesoinUtilisateur;
                ExecuteBesoinInterventionProcess ( nId );
            }
        }

        //------------------------------------------------------------------------------------
        public static CResultAErreur ExecuteBesoinInterventionProcess ( int nIdBesoin )
        {
            CResultAErreur result = CResultAErreur.True;
            CBesoinInterventionProcess besoin = new CBesoinInterventionProcess ( CSc2iWin32DataClient.ContexteCourant );
            if ( !besoin.ReadIfExists ( nIdBesoin ) )
                return result;
            result = CResultAErreur.True;
            //result = besoin.ProcessEnExecution.RepriseProcess ( besoin.IdAction );
            if (besoin.IdAction >= 0)
            {
                result = CFormExecuteProcess.RepriseAction(besoin.ProcessEnExecution, besoin.IdAction);
                if (result)
                    besoin.Delete();
            }

            return result;
            
        }

        
    }
}
