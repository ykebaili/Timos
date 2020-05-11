using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.multitiers.client;
using System.Drawing;

namespace timos.Controles.notifications
{
    public interface IExecuteurNotificationPopup
    {
        void GetInfosPopup(IDonneeNotification donnee, ref bool bShouldDisplay, ref string strLibelle, ref Image image);

        void ExecuteNotification ( IDonneeNotification donnee );
    }

    public static class CGestionnaireNotificationsPopup
    {
        private static Dictionary<Type, CRecepteurNotification> m_dicRecepteurs = new Dictionary<Type,CRecepteurNotification>();

        private static Dictionary<Type, IExecuteurNotificationPopup> m_dicTypeNotificationToExecuteur = new Dictionary<Type,IExecuteurNotificationPopup>();

        //--------------------------------------------------------------------------------------
        public static void RegisterExecuteur(Type typeNotification, IExecuteurNotificationPopup executeur)
        {
            if (executeur == null)
                return;

            AssureRecepteur ( typeNotification );
            m_dicTypeNotificationToExecuteur[typeNotification] = executeur;
        }

        //--------------------------------------------------------------------------------------
        private static void AssureRecepteur ( Type typeNotification )
        {
            CRecepteurNotification recepteur = null;
            m_dicRecepteurs.TryGetValue ( typeNotification, out recepteur );
            if ( recepteur != null )
                return;
            if ( CTimosApp.SessionClient == null )
            {
                m_dicRecepteurs[typeNotification] = null;
            }
            else
            {
                recepteur = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeNotification);
                recepteur.OnReceiveNotification += new NotificationEventHandler(recepteur_OnReceiveNotification);
                m_dicRecepteurs[typeNotification] = recepteur;
            }
        }

        //--------------------------------------------------------------------------------------
        public static void FinalizeInit()
        {
            foreach (Type tp in m_dicRecepteurs.Keys.ToArray())
                AssureRecepteur(tp);
        }

        //--------------------------------------------------------------------------------------
        public static void recepteur_OnReceiveNotification(IDonneeNotification donnee)
        {
            if (donnee == null)
                return;
            IExecuteurNotificationPopup executeur = null;
            if (m_dicTypeNotificationToExecuteur.TryGetValue(donnee.GetType(), out executeur))
            {
                bool bShouldDisplay = true;
                string strLibelle = "";
                Image img = null;
                executeur.GetInfosPopup(donnee, ref bShouldDisplay, ref strLibelle, ref img);
                if (bShouldDisplay)
                    CFormNotificationPopup.Instance.ShowMessage(
                        strLibelle, img, donnee);
            }
        }

        //--------------------------------------------------------------------------------------
        public static void ExecuteNotification(IDonneeNotification d)
        {
            if (d == null)
                return;
            IExecuteurNotificationPopup executeur = null;
            if (m_dicTypeNotificationToExecuteur.TryGetValue(d.GetType(), out executeur))
            {
                try
                {
                    executeur.ExecuteNotification(d);
                }
                catch { }
            }
        }
    }
}
