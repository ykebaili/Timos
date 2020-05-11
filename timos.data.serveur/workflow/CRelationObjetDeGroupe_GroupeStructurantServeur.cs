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
	/// Description r�sum�e de CRelationObjetDeGroupe_GroupeStructurantServeur.
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
		//REtourne la relation de objet � groupe correspondant � la row pass�e
		//en param�tre
		protected abstract IRelationGroupe GetNewRelationObjetToGroupe( DataRow row);

		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = CResultAErreur.True;
			//Si le groupe n�c�ssite un groupe ou plus, v�rifie que le acteur
			//appartient bien � ce groupe. Si non, la relation est cr��e.
			//Si le groupe n�c�ssite plusieurs groupes (plusieurs possibilit�s),
			//C'est le premier groupe n�c�ssaire qui est utilis�.
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList lstRows = new ArrayList();
			//Copie pour �viter de modifier la collection dans foreach
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
				//Aucune relation n'existe sur un groupe n�c�ssaire, on en cr�e une sur le premier
				IRelationGroupe newRelation = relationToGroupe.ObjetDeGroupe.GetNewRelation();
				newRelation.ObjetDeGroupe = relationToGroupe.ObjetDeGroupe;
				newRelation.Groupe = ((IRelationGroupeGroupeNecessaire)relationToGroupe.Groupe.RelationsGroupesNecessaires[0]).GroupeNecessaire;
				
				//il faut �galement s'assurer que les relations aux groupes n�c�ssaires de la
				//Nouvelle relation existent.
				AssureRelationsGroupesNecessaires ( newRelation );
			}
			return result;
		}
	}
}
