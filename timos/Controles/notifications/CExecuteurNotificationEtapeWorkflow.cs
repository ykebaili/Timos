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

namespace timos.Controles.notifications
{
    [AutoExec("Autoexec")]
    public class CExecuteurNotificationEtapeWorkflow : IExecuteurNotificationPopup
    {
        public static void Autoexec()
        {
            CGestionnaireNotificationsPopup.RegisterExecuteur(
                typeof(CDonneeNotificationWorkflow),
                new CExecuteurNotificationEtapeWorkflow());
        }

        //------------------------------------------------------------------------------------
        public void GetInfosPopup(IDonneeNotification donnee, ref bool bShouldDisplay, ref string strLibelle, ref Image image)
        {
            bShouldDisplay = false;
            CDonneeNotificationWorkflow dw = donnee as CDonneeNotificationWorkflow;
            if (dw == null)
            {
                
                return;
            }
            string[] strCodesInteressants = CUtilSession.GetCodesAffectationsEtapeConcernant(CSc2iWin32DataClient.ContexteCourant);
            bool bPourMoi = false;
            foreach (string strCode in strCodesInteressants)
            {
                if (dw.CodesAffectations.Contains("~" + strCode + "~"))
                {
                    bPourMoi = true;
                    break;
                }
            }
            if (bPourMoi)
            {
                strLibelle = dw.Libelle;
                image = Resources._1346738948_task;
                bShouldDisplay = true;
            }
        }

        //------------------------------------------------------------------------------------
        public void ExecuteNotification(IDonneeNotification donnee)
        {
            CDonneeNotificationWorkflow dw = donnee as CDonneeNotificationWorkflow;
            if (dw != null)
            {
                int nId = dw.IdEtapeSource;
                CEtapeWorkflow etape = new CEtapeWorkflow(CSc2iWin32DataClient.ContexteCourant);
                if (etape.ReadIfExists(nId))
                {
                    CGestionnaireWorkflowsEnCours.Instance.AfficheEtape(etape);
                }
            }
        }

        
    }
}
