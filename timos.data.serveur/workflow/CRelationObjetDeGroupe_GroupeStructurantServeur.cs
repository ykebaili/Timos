using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.data.serveur;
using sc2i.common;
using sc2i.workflow;


namespace sc2i.workflow.serveur
{
	/// <summary>
	/// Description résumée de CRelationObjetDeGroupe_GroupeStructurantServeur.
	/// </summary>
	public abstract class CRelationObjetDeGroupe_GroupeStructurantServeur : CObjetServeur
	{
#if PDA
		public CRelationObjetDeGroupe_GroupeStructurantServeur()
			:base ()
		{
		}
#endif

		//-------------------------------------------------------------------
		public CRelationObjetDeGroupe_GroupeStructurantServeur( int nIdSession )
			:base ( nIdSession )
		{
		}

		//-------------------------------------------------------------------
		//REtourne la relation de objet à groupe correspondant à la row passée
		//en paramètre
		protected abstract IRelationGroupe GetNewRelationObjetToGroupe( DataRow row);

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = CResultAErreur.True;
			//Si le groupe nécéssite un groupe ou plus, vérifie que le acteur
			//appartient bien à ce groupe. Si non, la relation est créée.
			//Si le groupe nécéssite plusieurs groupes (plusieurs possibilités),
			//C'est le premier groupe nécéssaire qui est utilisé.
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lstRows = new ArrayList();
			//Copie pour éviter de modifier la collection dans foreach
			foreach( DataRow row in table.Rows )
				lstRows.Add ( row );
			
			foreach ( DataRow row in lstRows )
			{
				if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
				{
					IRelationGroupe relation =  GetNewRelationObjetToGroupe ( row );
					if ( relation.Groupe.RelationsGroupesNecessaires.Count > 0 )
					{
						result= AssureRelationsGroupesNecessaires ( relation );
						if ( !result )
							return result;
					}
				}
			}
			return result;
		}

		//-------------------------------------------------------------------
		public CResultAErreur AssureRelationsGroupesNecessaires ( IRelationGroupe relationToGroupe )
		{
			CResultAErreur result = CResultAErreur.True;
			Hashtable tableGroupesNecessaires = new Hashtable();
			foreach ( IRelationGroupeGroupeNecessaire relationNecessaire in relationToGroupe.Groupe.RelationsGroupesNecessaires)
				tableGroupesNecessaires[relationNecessaire.GroupeNecessaire.Id] = true;
			if ( tableGroupesNecessaires.Count == 0 )
				return result;
			bool bExist = false;
			foreach ( IRelationGroupe relationGroupe in relationToGroupe.ObjetDeGroupe.RelationsGroupes )
				if ( tableGroupesNecessaires[relationGroupe.Groupe.Id] != null )
					bExist = true;
			if ( !bExist )
			{
				//Aucune relation n'existe sur un groupe nécéssaire, on en crée une sur le premier
				IRelationGroupe newRelation = relationToGroupe.ObjetDeGroupe.GetNewRelation();
				newRelation.ObjetDeGroupe = relationToGroupe.ObjetDeGroupe;
				newRelation.Groupe = ((IRelationGroupeGroupeNecessaire)relationToGroupe.Groupe.RelationsGroupesNecessaires[0]).GroupeNecessaire;
				
				//il faut également s'assurer que les relations aux groupes nécéssaires de la
				//Nouvelle relation existent.
				AssureRelationsGroupesNecessaires ( newRelation );
			}
			return result;
		}
	}
}
