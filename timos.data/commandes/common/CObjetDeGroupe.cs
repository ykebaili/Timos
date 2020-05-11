using System;
using System.Collections;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;

namespace sc2i.data
{
	public abstract class CObjetDeGroupe : CElementAChamp
	{
		//-------------------------------------------------------------------
#if PDA
		public CObjetDeGroupe()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CObjetDeGroupe( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CObjetDeGroupe( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		public abstract CListeObjetsDonnees RelationsGroupes {get;}
		public abstract IRelationGroupe GetNewRelation();
		public abstract Type TypeGroupe {get;}
		public abstract string Nom {get; set;}
		public abstract string GetChampIdGroupe();
		
		//-------------------------------------------------------------------
		public virtual int[] TousLesIdsDeGroupes
		{
			get
			{
				string strChampId = "";
				Hashtable tableIdsGroupe = new Hashtable();
			
				foreach(IRelationGroupe rel in RelationsGroupes)
				{
					rel.Groupe.StockeIdGroupesContenantsInArray ( tableIdsGroupe );
					strChampId = rel.Groupe.GetChampId();
				}
				ArrayList lstIds = new ArrayList();
				foreach(int n in tableIdsGroupe.Keys)
				{
					lstIds.Add ( n );
				}
				return ( int[]) lstIds.ToArray(typeof(int));
			}
		}

		//-------------------------------------------------------------------
		//Retourne un table type des groupes
		protected Array TousLesGroupesTypes ( )
		{
			int[] idsGroupes = TousLesIdsDeGroupes;
			Array array = Array.CreateInstance ( TypeGroupe, idsGroupes.Length );
			int nIndex = 0;
			foreach ( int nId in idsGroupes )
			{
				CGroupeStructurant groupe = (CGroupeStructurant)Activator.CreateInstance ( TypeGroupe, new object[]{ContexteDonnee} );
				if ( groupe.ReadIfExists ( nId ) )
				{
					array.SetValue ( groupe, nIndex );
					nIndex++;
				}
			}
			return array;
		}



		//-------------------------------------------------------------------
		//Ne pas surcharger, surcharge TousLesIdsDeGroupes
		public CListeObjetsDonnees TousLesGroupes()
		{
			string strIds = "";
			foreach(int n in TousLesIdsDeGroupes)
			{
				if (strIds!="")
					strIds+=",";
				strIds += n;
			}

			CListeObjetsDonnees listeGroupes = new CListeObjetsDonnees(ContexteDonnee, TypeGroupe );
			if (strIds=="")
				listeGroupes.Filtre = new CFiltreDataImpossible();
			else
				listeGroupes.Filtre = new CFiltreData( GetChampIdGroupe() + " IN (" + strIds + ")"  );
			return listeGroupes;
		}
		//-------------------------------------------------------------------
		public CListeObjetsDonnees GetGroupesDirects()
		{
			string strIds = "";
			string strChampId = "";
			foreach(IRelationGroupe rel in RelationsGroupes)
			{
				if (strIds!="")
					strIds+=",";
				strIds+=rel.Groupe.Id;
				strChampId = rel.Groupe.GetChampId();
			}
			CListeObjetsDonnees listeGroupes = new CListeObjetsDonnees(ContexteDonnee, TypeGroupe );
			if (strIds=="")
				listeGroupes.Filtre = new CFiltreDataImpossible();
			else
				listeGroupes.Filtre = new CFiltreData( strChampId + " IN (" + strIds + ")");
			return listeGroupes;
		}
		


	}
}
