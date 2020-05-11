using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;
using sc2i.workflow.serveur;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationActeur_GroupeActeurServeur.
	/// </summary>
	public class CRelationActeur_GroupeActeurServeur : CRelationObjetDeGroupe_GroupeStructurantServeur
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationActeur_GroupeActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActeur_GroupeActeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationActeur_GroupeActeur.c_nomTable;
		}
		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationActeur_GroupeActeur relation = (CRelationActeur_GroupeActeur)objet;

				//Ajouter ici les éventuels tests de validité

			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;
		}

		//-------------------------------------------------------------------
		protected override IRelationGroupe GetNewRelationObjetToGroupe ( DataRow row )
		{
			return new CRelationActeur_GroupeActeur(row);
		}
		
		//-------------------------------------------------------------------
		public override Type GetTypeObjets()
		{
			return typeof(CRelationActeur_GroupeActeur);
		}
		//-------------------------------------------------------------------

		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = base.TraitementAvantSauvegarde( contexte );
			if ( !result )
				return result;
			//Vérifie que les acteurs ont les rôles induits par leurs groupes
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lst = new ArrayList(table.Rows);
			foreach ( DataRow row in lst )
			{
				if ( row.RowState == DataRowState.Added )
				{
					CRelationActeur_GroupeActeur rel = new CRelationActeur_GroupeActeur ( row );
					foreach ( CRoleActeur role in rel.GroupeActeur.GetRoles() )
					{
						if ( !rel.Acteur.HasRole(role,true) )
						{
							//Crée la donnée du role
#if PDA
							CDonneesActeur donnee = (CDonneesActeur)Activator.CreateInstance(role.TypeDonneeActeur);
							donnee.ContexteDonnee = contexte;
#else
							CDonneesActeur donnee = (CDonneesActeur)Activator.CreateInstance(role.TypeDonneeActeur, new object[]{contexte});
#endif
							donnee.CreateNewInCurrentContexte();
							donnee.Acteur = rel.Acteur;
							donnee.IsDonneeActeurValide = donnee.VerifieDonnees(false);
						}
					}
				}
				
				if ( row.RowState == DataRowState.Modified || row.RowState == DataRowState.Added ||
					row.RowState == DataRowState.Deleted )
				{
					CRelationActeur_GroupeActeur rel = new CRelationActeur_GroupeActeur(row);

					//Invalide les données utilisateur (pour restrictions)
					CActeur acteurOld = null;
					CActeur acteurNew = null;
					if ( row.HasVersion ( DataRowVersion.Original ) )
					{
						rel.VersionToReturn = DataRowVersion.Original;
						acteurOld = rel.Acteur;
						rel.VersionToReturn = DataRowVersion.Default;
					}
					if ( row.HasVersion ( DataRowVersion.Current ) )
						acteurNew = rel.Acteur;
					if ( acteurOld != null && acteurOld.Utilisateur!= null)
						acteurOld.Utilisateur.ForceChangementSyncSession();
					if ( acteurNew != null && acteurNew.Utilisateur != null )
						acteurNew.Utilisateur.ForceChangementSyncSession();
				}
			}
			return result;
		}
	}
}
