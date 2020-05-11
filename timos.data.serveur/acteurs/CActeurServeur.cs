using System;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;
using timos.acteurs;
using sc2i.data.dynamic;
using sc2i.multitiers.client;
using timos.securite;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CActeurServeur.
	/// </summary>
	public class CActeurServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CActeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CActeur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CActeur acteur = (CActeur)objet;

				if ( acteur.Nom == "")
					result.EmpileErreur(I.T( "The name of the Member cannot be empty|262"));
				
				CRelationActeur_ChampCustomServeur relServeur = new CRelationActeur_ChampCustomServeur(IdSession);
				foreach ( CRelationActeur_ChampCustom rel in CNettoyeurValeursChamps.RelationsChampsNormales(acteur) )
				{
					CResultAErreur resultTmp = relServeur.VerifieDonnees(rel);
					if ( !resultTmp )
					{
						result.Erreur.EmpileErreurs(resultTmp.Erreur);
						result.SetFalse();
					}
				}

				if (acteur.ActeurParent != null &&
						acteur.ActeurParent.IsChildOf(acteur))
				{
					result.EmpileErreur(I.T( "A cyclic member relationship has been detected|134"));
				}
		
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CActeur);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee ds )
		{
			CResultAErreur result = base.TraitementAvantSauvegarde ( ds );
			if (!result)
				return result;
			
			//Et envoie les notifications sur modification de données utilisateur
			DataTable table = ds.Tables[GetNomTable()];
			ArrayList lst = new ArrayList(table.Rows );
			foreach ( DataRow row in lst )
			{
				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
				{
                    CActeur acteur = new CActeur(row);

					//sc2i.data.dynamic.CNettoyeurValeursChamps.NettoieChamps(acteur);
					
					//Notification modification user
					CDonneesActeurUtilisateur donneePart = (CDonneesActeurUtilisateur)acteur.GetDonneesRole(CRoleActeur.GetRole(CDonneesActeurUtilisateur.c_codeRole));
					if ( donneePart != null )
					{
                        //TESTDBKEYOK
						CDonneeNotificationChangementDroitUtilisateur notDroit = new CDonneeNotificationChangementDroitUtilisateur(IdSession, donneePart.DbKey);
						CEnvoyeurNotification.EnvoieNotifications(new IDonneeNotification[] { notDroit });
					}
					if (acteur.ActeurParent != null &&
						acteur.ActeurParent.IsChildOf(acteur))
					{
						result.EmpileErreur(I.T( "A cyclic member relationship has been detected|134"));
					}
				}
			}
			return result;
		}
	}
}
