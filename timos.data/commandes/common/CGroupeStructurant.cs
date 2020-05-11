using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;

namespace sc2i.data
{
	/// <summary>
	/// Description résumée de CGroupeStructurant.
	/// </summary>
	public abstract class CGroupeStructurant : 
		CObjetDonneeAIdNumeriqueAuto, 
		IDefinisseurChampCustomRelationObjetDonnee,
		IObjetALectureTableComplete
	{
		//-------------------------------------------------------------------
#if PDA
		public CGroupeStructurant()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CGroupeStructurant( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CGroupeStructurant( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		// Implémentations de IDefinisseurChampCustom
        public abstract CRoleChampCustom RoleChampCustomDesElementsAChamp { get; }
		public abstract CListeObjetsDonnees RelationsChampsCustomListe{get;}
		public abstract CListeObjetsDonnees RelationsFormulairesListe{get;}
		
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}
		//-------------------------------------------------------------------
		public abstract string Libelle {get; set;}
		public abstract CListeObjetsDonnees RelationsTousGroupesContenants {get;}
		public abstract CListeObjetsDonnees RelationsGroupesContenantsDirects {get;}
		public abstract CListeObjetsDonnees RelationsTousGroupesContenus {get;}
		public abstract CListeObjetsDonnees RelationsGroupesContenusDirects {get;}
		public abstract CListeObjetsDonnees RelationsGroupesNecessaires {get;}
		public abstract CListeObjetsDonnees RelationsGroupesNecessitants {get;}

		public abstract Type TypeRelationNecessaire {get;}

		public int[] GetHierarchieGroupesContenants()
		{
			Hashtable tableGroupes = new Hashtable();
			StockeIdGroupesContenantsInArray(tableGroupes);
			ArrayList arrayIds = new ArrayList();
			foreach(object key in tableGroupes.Keys)
				arrayIds.Add(key);
			return (int[]) arrayIds.ToArray( typeof(int) );
		}
		//-------------------------------------------------------------------
		public void StockeIdGroupesContenantsInArray ( Hashtable tableParents )
		{
			if ( tableParents[Id] != null )
				return;
			tableParents[Id] = true;//Le groupe est contenant de lui même
			foreach ( IRelationGroupeStructurantGroupeParent rel in RelationsGroupesContenantsDirects )
				((CGroupeStructurant)rel.GroupeContenant).StockeIdGroupesContenantsInArray(tableParents);
		}
		//-------------------------------------------------------------------
		public int[] GetHierarchieGroupesContenus()
		{
			Hashtable tableGroupes = new Hashtable();
			StockeIdGroupesContenusInArray(tableGroupes);
			ArrayList arrayIds = new ArrayList();
			foreach(object key in tableGroupes.Keys)
				arrayIds.Add(key);
			return (int[]) arrayIds.ToArray( typeof(int) );
		}
		//-------------------------------------------------------------------
		public void StockeIdGroupesContenusInArray ( Hashtable tableParents )
		{
			if ( tableParents[Id] != null )
				return;
			tableParents[Id] = true;//Le groupe se contient lui même
			foreach ( IRelationGroupeStructurantGroupeParent rel in RelationsGroupesContenusDirects )
				((CGroupeStructurant)rel.GroupeContenu).StockeIdGroupesContenusInArray(tableParents);
		}
		//-------------------------------------------------------------------
		public int[] GetHierarchieGroupesNecessaires()
		{
			Hashtable tableGroupes = new Hashtable();
			StockeIdGroupesNecessairesInArray(tableGroupes);
			ArrayList arrayIds = new ArrayList();
			foreach(object key in tableGroupes.Keys)
				arrayIds.Add(key);
			return (int[]) arrayIds.ToArray( typeof(int) );
		}
		//-------------------------------------------------------------------
		public void StockeIdGroupesNecessairesInArray ( Hashtable tableParents )
		{
			if ( tableParents[Id] != null )
				return;
			tableParents[Id] = true;//Le groupe est nécessaire de lui même
			foreach ( IRelationGroupeGroupeNecessaire rel in RelationsGroupesNecessaires )
				((CGroupeStructurant)rel.GroupeNecessaire).StockeIdGroupesNecessairesInArray(tableParents);
		}
		//-------------------------------------------------------------------
		public int[] GetHierarchieGroupesNecessitants()
		{
			Hashtable tableGroupes = new Hashtable();
			StockeIdGroupesNecessitantsInArray(tableGroupes);
			ArrayList arrayIds = new ArrayList();
			foreach(object key in tableGroupes.Keys)
				arrayIds.Add(key);
			return (int[]) arrayIds.ToArray( typeof(int) );
		}
		//-------------------------------------------------------------------
		public void StockeIdGroupesNecessitantsInArray ( Hashtable tableParents )
		{
			if ( tableParents[Id] != null )
				return;
			tableParents[Id] = true;//Le groupe est nécessaire de lui même
			foreach ( IRelationGroupeGroupeNecessaire rel in RelationsGroupesNecessitants )
				((CGroupeStructurant)rel.GroupeNecessitant).StockeIdGroupesNecessitantsInArray(tableParents);
		}

		//-------------------------------------------------------------------
		public override CResultAErreur DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison()
		{
			/*Il y a pb de double compositions sur les Relations a des groupes : 
			 * soient les groupes C € B € A   (€ pour appartient).
			 * Le fait que C € B, implique une relation induite C € A.
			 * or la relation C € A est une composition de B, mais aussi une composition
			 * de la relation C € B, lorsqu'on supprime B, ça supprime les relations :
			 * donc ça supprimer C € B et ses compositions donc C € A, mais
			 * la suppression des compositions de B supprime aussi C € A, ce qui
			 * fait que cette ligne est supprimée deux fois.
			 * Pour éviter le pb, on supprime manuellement toutes les relations à des 
			 * groupes (directs)
			 * */
			CResultAErreur result = CResultAErreur.True;
			try
			{
				foreach ( CObjetDonnee objet in RelationsGroupesContenantsDirects )
				{
					result = objet.DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison();
					if ( !result )
						return result;
				}
				foreach ( CObjetDonnee objet in RelationsGroupesContenusDirects )
				{
					result = objet.DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison();
					if ( !result )
						return result;
				}
				result = base.DoDeleteInterneACObjetDonneeNePasUtiliserSansBonneRaison();
			}
			catch ( Exception e )
			{
				result.EmpileErreur( new CErreurException ( e ) );
			}
			return result;

		}
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Remplit une hashtable IdChamp->Champ
		/// avec tous les champs liés.(hiérarchique
		/// </summary>
		/// <param name="tableChamps">HAshtable à remplir</param>
		private void FillHashtableChamps ( Hashtable tableChamps )
		{
			foreach ( IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis )
				tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
			foreach ( IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires )
			{
				foreach ( CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps )
					tableChamps[relFor.Champ.Id] = relFor.Champ;
			}
			foreach ( IRelationGroupeStructurantGroupeParent relGroupe in RelationsGroupesContenantsDirects )
				relGroupe.GroupeContenant.FillHashtableChamps ( tableChamps );
		}
		
		//-------------------------------------------------------------------
		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				Hashtable tableChamps = new Hashtable();
				FillHashtableChamps ( tableChamps );
				CChampCustom[] liste = new CChampCustom[tableChamps.Count];
				int nChamp = 0;
				foreach ( CChampCustom champ in tableChamps.Values )
					liste[nChamp++] = champ;
				return liste;
			}
		}
	}
}
		