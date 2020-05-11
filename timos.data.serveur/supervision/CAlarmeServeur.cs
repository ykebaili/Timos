using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;

using timos.data;
using timos.securite;
using timos.data.supervision;
using sc2i.multitiers.client;
using timos.data.serveur.supervision;

namespace timos.data.serveur
{
    /// <summary>
    /// Description résumée de CAlarmeServeur.
    /// </summary>
    public class CAlarmeServeur : CObjetHierarchiqueServeur, IAlarmeServeur
    {
        private const string c_cleNotification = "NOTIF_ALARM";
        //-------------------------------------------------------------------
        public CAlarmeServeur(int nIdSession)
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CAlarme.c_nomTable;
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			
           
			return result;
		}

		

		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
            return typeof(CAlarme);
		}

		//-------------------------------------------------------------------
        public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
        {
            CResultAErreur result = base.TraitementAvantSauvegarde(contexte);
            if (!result)
                return result;
            DataTable table = contexte.Tables[GetNomTable()];
            if (table == null)
                return result;
            ArrayList lst = new ArrayList(table.Rows);
            CNotificationModificationsAlarme notif = contexte.ExtendedProperties[c_cleNotification] as CNotificationModificationsAlarme;
            if ( notif == null )
            {
                notif = new CNotificationModificationsAlarme(IdSession);
                contexte.ExtendedProperties[c_cleNotification] = notif;
            }

            foreach (DataRow row in lst)
            {
                if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                {
                    notif.AddModifiedAlarm(new CAlarme(row));
                }
            }
            return result;
        }

        public override CResultAErreur TraitementApresSauvegarde(CContexteDonnee contexte, bool bOperationReussie)
        {
            CResultAErreur result =  base.TraitementApresSauvegarde(contexte, bOperationReussie);
            if (result)
            {
                CNotificationModificationsAlarme notif = contexte.ExtendedProperties[c_cleNotification] as CNotificationModificationsAlarme;
                if (notif != null)
                {
                    CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notif });
                    contexte.ExtendedProperties.Remove(c_cleNotification);
                }
            }
            return result;
        }

        #region IAlarmeServeur Membres

        public CResultAErreur TraiteAlarmesManuellement(sc2i.common.memorydb.CMemoryDb dbContenantLesAlarmesATraiter)
        {
            return CTraiteurAlarmesFromMediation.DefaultInstance.Traite(dbContenantLesAlarmesATraiter);
        }

        #endregion
    }
}
