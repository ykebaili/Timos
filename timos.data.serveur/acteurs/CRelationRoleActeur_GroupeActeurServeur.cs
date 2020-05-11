using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using timos.acteurs;

namespace timos.acteurs.serveur
{
	/// <summary>
	/// Description résumée de CRelationRoleActeur_GroupeActeurServeur.
	/// </summary>
	public class CRelationRoleActeur_GroupeActeurServeur : CObjetDonneeServeurAvecCache
	{
		//-------------------------------------------------------------------
#if PDA
		public CRelationRoleActeur_GroupeActeurServeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationRoleActeur_GroupeActeurServeur ( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override string GetNomTable ()
		{
			return CRelationRoleActeur_GroupeActeur.c_nomTable;
		}

		public override CResultAErreur TraitementAvantSauvegarde(CContexteDonnee contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			//Si ajout d'un role, ajoute le rôle à tous les acteurs de ce groupe
			DataTable table = contexte.Tables[GetNomTable()];
			foreach ( DataRow row in table.Rows )
			{
				if ( row.RowState == DataRowState.Added )
				{
					CRelationRoleActeur_GroupeActeur relation = new CRelationRoleActeur_GroupeActeur(row);
					result = AddRoleToActeurs ( relation.RoleActeur, relation.GroupeActeur );
					if ( !result )
						return result;
				}
			}
			return result;
		}

		//-------------------------------------------------------------------
		public CResultAErreur AddRoleToActeurs ( CRoleActeur role, CGroupeActeur groupe )
		{
			CResultAErreur result = CResultAErreur.True;
			CListeObjetsDonnees listeActeurs = new CListeObjetsDonnees ( groupe.ContexteDonnee, typeof(CActeur) );
			//Sélectionne tous les acteurs du groupe qui n'ont pas le rôle
			CFiltreDataAvance filtre = new CFiltreDataAvance ( CActeur.c_nomTable,
				"(RelationsGroupes.GroupeActeur.Id = @1 or "+
				"RelationsGroupes.GroupeActeur.RelationsTousGroupesContenants.GroupeActeurContenant.Id = @1) and "+
				"hasno ( "+role.NomTableDonneesActeur+".Id)",
				groupe.Id );
			listeActeurs.Filtre = filtre;
			foreach ( CActeur acteur in listeActeurs )
			{
#if PDA
				CDonneesActeur donnee = (CDonneesActeur)Activator.CreateInstance ( role.TypeDonneeActeur );
				donnee.ContexteDonnee = groupe.ContexteDonnee;
#else
				CDonneesActeur donnee = (CDonneesActeur)Activator.CreateInstance ( role.TypeDonneeActeur, new object[]{groupe.ContexteDonnee} );
#endif
				donnee.CreateNewInCurrentContexte ();
				donnee.Acteur = acteur;

				donnee.IsDonneeActeurValide = donnee.VerifieDonnees ( false );
			}
			return result;
		}


		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees( CObjetDonnee objet )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CRelationRoleActeur_GroupeActeur relation = (CRelationRoleActeur_GroupeActeur)objet;

				//Ajouter ici les éventuels tests de validité

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
			return typeof(CRelationRoleActeur_GroupeActeur);
		}
		//-------------------------------------------------------------------
	}
}
