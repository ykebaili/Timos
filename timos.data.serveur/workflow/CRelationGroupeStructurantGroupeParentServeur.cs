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
	/// Description résumée de CRelationGroupeStructurantGroupeParentServeur.
	/// </summary>
	public abstract class CRelationGroupeStructurantGroupeParentServeur : CObjetDonneeServeurAvecCache
	{
#if PDA
		public CRelationGroupeStructurantGroupeParentServeur()
			:base ()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeStructurantGroupeParentServeur( int nIdSession )
			:base ( nIdSession )
		{
		}
		//-------------------------------------------------------------------
		public override CResultAErreur TraitementAvantSauvegarde ( CContexteDonnee contexte )
		{
			CResultAErreur result = CResultAErreur.True;
			//Crée les relations induites par la relation
			DataTable table = contexte.Tables[GetNomTable()];
			ArrayList listeRelationsNew = new ArrayList();
			foreach( DataRow row in table.Rows )
			{
				if ( row.RowState == DataRowState.Added )
				{
#if PDA
					CObjetDonnee obj = (CObjetDonnee)Activator.CreateInstance(GetTypeObjets());
					obj.SetRow(row);
					listeRelationsNew.Add (obj);
#else
					listeRelationsNew.Add ( Activator.CreateInstance( GetTypeObjets(), new object[] {row} ));
#endif
				}
			}
			foreach ( IRelationGroupeStructurantGroupeParent relation in listeRelationsNew )
			{
				if ( relation.IsRelationDirecte() )
				{
					GereRelationsInduites ( (CGroupeStructurant)relation.GroupeContenu, relation, true );
				}
			}
			return result;
		}
		//-------------------------------------------------------------------
		/// ////////////////////////////////////////////////////////////
		/// Cette fonction récursive a nécéssité une heure de boulot papier. Elle a été testée et
		/// fonctionne parfaitement.
		/// Il ne fait absolument rien toucher dedans, j'ai eu assez de mal à la faire
		public void GereRelationsInduites ( CGroupeStructurant groupeContenu, IRelationGroupeStructurantGroupeParent relation, bool bAvecFils )
		{
			//Va chercher toutes les relations parentes du groupe parent
			foreach ( IRelationGroupeStructurantGroupeParent relParente in relation.GroupeContenant.RelationsGroupesContenantsDirects )
			{
				//Crée la relation induite
#if PDA
				IRelationGroupeStructurantGroupeParent relNew = (IRelationGroupeStructurantGroupeParent)Activator.CreateInstance(GetTypeObjets());
				relNew.ContexteDonnee = relation.ContexteDonnee;
#else
				IRelationGroupeStructurantGroupeParent relNew = (IRelationGroupeStructurantGroupeParent) Activator.CreateInstance( GetTypeObjets(), new object[] {relation.ContexteDonnee} );
#endif
				relNew.CreateNewInCurrentContexte();
				relNew.GroupeContenu = groupeContenu;
				relNew.GroupeContenant = relParente.GroupeContenant;
				relNew.RelationSourceFille = relation;
				relNew.RelationSourceParent = relParente;
				GereRelationsInduites ( groupeContenu, relNew, false );
			}
			//Va chercher toutes les relations filles du groupe fils
			if ( bAvecFils )
			{
				foreach ( IRelationGroupeStructurantGroupeParent relFille in groupeContenu.RelationsGroupesContenusDirects )
				{
					//Crée la relation induite
#if PDA
					IRelationGroupeStructurantGroupeParent relNew = (IRelationGroupeStructurantGroupeParent)Activator.CreateInstance(GetTypeObjets());
					relNew.ContexteDonnee = relation.ContexteDonnee;
#else
					IRelationGroupeStructurantGroupeParent relNew = (IRelationGroupeStructurantGroupeParent) Activator.CreateInstance( GetTypeObjets(), new object[] {relation.ContexteDonnee} );
#endif
					relNew.CreateNewInCurrentContexte();
					relNew.GroupeContenu = relFille.GroupeContenu;
					relNew.GroupeContenant = relation.GroupeContenant;
					relNew.RelationSourceFille = relFille;
					relNew.RelationSourceParent = relation;
					GereRelationsInduites ( (CGroupeStructurant)relFille.GroupeContenu, relNew, true );
				}
			}
		}
		//-------------------------------------------------------------------
	}
}
