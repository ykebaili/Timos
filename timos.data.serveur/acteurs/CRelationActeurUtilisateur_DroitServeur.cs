using System;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.data.dynamic;
using timos.acteurs;
using sc2i.multitiers.client;



namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupeActeur_ChampCustomServeur.
	/// </summary>
	public class CRelationActeurUtilisateur_DroitServeur : CObjetServeur
	{
		//-------------------------------------------------------------------
		public CRelationActeurUtilisateur_DroitServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationActeurUtilisateur_Droit.c_nomTable;
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
			return typeof(CRelationActeurUtilisateur_Droit);
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee ds )
		{
			CResultAErreur result = CResultAErreur.True;
			//envoie les notifications sur modification de données utilisateur
			DataTable table = ds.Tables[GetNomTable()];
			foreach ( DataRow row in table.Rows )
			{
				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
				{
					CRelationActeurUtilisateur_Droit rel = new CRelationActeurUtilisateur_Droit(row);
                    //TESTDBKEYOK
					CDonneeNotificationChangementDroitUtilisateur notDroit = new CDonneeNotificationChangementDroitUtilisateur(IdSession, rel.DonneeActeurUtilisateur.DbKey);
					CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notDroit });
				}
			}
			return result;
		}
	}
}

