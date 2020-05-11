using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;
using sc2i.workflow.serveur;


namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CRelationGroupe_GroupeNecessaireServeur.
	/// </summary>
	public abstract class CRelationGroupe_GroupeNecessaireServeur : CObjetDonneeServeurAvecCache
	{
		/// //////////////////////////////////////////////////////////////////
#if PDA
		public CRelationGroupe_GroupeNecessaireServeur()
			:base ()
		{
		}
#endif
		/// //////////////////////////////////////////////////////////////////
		public CRelationGroupe_GroupeNecessaireServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		/// //////////////////////////////////////////////////////////////////
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = CResultAErreur.True;
			/* Lors de la création d'une nouvelle relation de nécéssité vers un groupe,
			 * vérifie que tous les elements de groupe appartiennent à au moins à un groupe
			 * nécéssaire
			 */
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lst = new ArrayList();
			foreach ( DataRow row in table.Rows )//Copie pour éviter un cht de la liste dans Foreach
				lst.Add ( row );
			foreach ( DataRow row in lst )
			{
				//On  ne vérifie que les groupes ayant un nouveau groupe nécéssaire
				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Deleted )
				{
					int nIdGroupeNecessite = -1;
					if ( row.RowState == DataRowState.Deleted )
						nIdGroupeNecessite = (int)row[GetNomChampIdGroupeNecessite(), DataRowVersion.Original];
					else
						nIdGroupeNecessite = (int)row[GetNomChampIdGroupeNecessite()];
					result = AssureElementsOk ( contexte, nIdGroupeNecessite );
					if ( !result )
						return result;
				}
			}
			return result;
		}

		/// //////////////////////////////////////////////////////////////////
		/// Retourne le type des relations d'objet de groupe à groupe
		protected abstract Type GetTypeRelationsObjetDeGroupeGroupe();

		/// //////////////////////////////////////////////////////////////////
		//Retourne le nom de champ correspondant à l'id d'un groupe
		protected abstract string GetNomChampIdGroupe();

		/// //////////////////////////////////////////////////////////////////
		protected abstract string GetNomChampIdGroupeNecessite(); 

		/// //////////////////////////////////////////////////////////////////
		protected abstract CRelationObjetDeGroupe_GroupeStructurantServeur GetNewRelationObjetToGroupeServeur();


		/// //////////////////////////////////////////////////////////////////
		/// Vérifie que les appartenances de groupe des elements du groupe nIdGroupe
		/// Sont correctes
		protected virtual CResultAErreur AssureElementsOk ( CContexteDonnee contexte, int nIdGroupe )
		{
			CResultAErreur result = CResultAErreur.True;
			/*S'assure que tous les éléments appartenant au groupe nécessité par la relation appartiennent
			 * au moins à un des groupes nécéssaires du groupe necessité par la relation
			 * */
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( contexte, GetTypeRelationsObjetDeGroupeGroupe() );
			//Cherche tous les objets de groupe qui appartiennent au groupe nécessité
			liste.Filtre = new CFiltreData ( GetNomChampIdGroupe()+"=@1", nIdGroupe );
			CRelationObjetDeGroupe_GroupeStructurantServeur relServeur = GetNewRelationObjetToGroupeServeur();
			foreach ( IRelationGroupe relationObjetGroupe in liste )
			{
				result = relServeur.AssureRelationsGroupesNecessaires ( relationObjetGroupe );
				if ( !result )
					return result;
			}
			return result;
		}
	}
}
