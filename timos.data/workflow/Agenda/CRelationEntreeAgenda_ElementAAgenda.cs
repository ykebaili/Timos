using System;
using System.Data;

using sc2i.common;
using sc2i.data;

namespace sc2i.workflow
{
	#region RelationEntreeAgenda_ElementAAgenda
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationEntreeAgenda_ElementAAgendaAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CRelationEntreeAgenda_ElementAAgenda.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 800;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
				return "ENTREE_AGENDA_ELT";
			}
		}

		
		public override string ChampId
		{
			get
			{
				return CRelationEntreeAgenda_ElementAAgenda.c_champIdElementAAgenda;
			}
		}

		public override string ChampType
		{
			get
			{
				return CRelationEntreeAgenda_ElementAAgenda.c_champTypeElementAAgenda;
			}
		}
		
		public override bool Composition
		{
			get
			{
				return true;
			}
		}
		public override bool CanDeleteToujours
		{
			get
			{
				return true;
			}
		}


		public override string NomConvivialPourParent
		{
			get
			{
				return I.T("Diary entries|20079");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return tp.IsSubclassOf ( typeof(CObjetDonneeAIdNumerique) );
		}
	}

	#endregion
	/// <summary>
    /// Relation entre une <see cref="CEntreeAgenda">Entrée d'agenda</see> et un 
    /// élément à agenda.
	/// </summary>
	[Table(CRelationEntreeAgenda_ElementAAgenda.c_nomTable, 
		 CRelationEntreeAgenda_ElementAAgenda.c_champId,
		 true)]
	[ObjetServeurURI("CRelationEntreeAgenda_ElementAAgendaServeur")]
	[DynamicClass("Diary entry / element")]
	[RelationEntreeAgenda_ElementAAgenda]
	public class CRelationEntreeAgenda_ElementAAgenda : CObjetDonneeAIdNumeriqueAuto, IRelationElementALien_Element
	{
		public const string c_nomTable = "DIARY_ENTRY_ELEMENT";

		public const string c_champId = "DRYENTELT_ID";
		public const string c_champTypeElementAAgenda = "DRYENTELT_ELEMENT_TYPE";
		public const string c_champIdElementAAgenda = "DRYENTELT_ELEMENT_ID";

#if PDA
		public CRelationEntreeAgenda_ElementAAgenda()
			:base()
		{
		}
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationEntreeAgenda_ElementAAgenda( CContexteDonnee ctx)
			:base(ctx)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationEntreeAgenda_ElementAAgenda ( DataRow row )
			:base(row)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				string strInfo = I.T("Relation between diary entry @1|30082",EntreeAgenda.Id.ToString());
				CObjetDonneeAIdNumerique elt = ElementLie;
				if ( elt != null )
					strInfo += I.T(" and @1|333",ElementLie.DescriptionElement);
				return strInfo;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void MyInitValeurDefaut()
		{
		}

		/// <summary>
		/// Entrée d'agenda, objet de la relation
		/// </summary>
		[Relation(CEntreeAgenda.c_nomTable, CEntreeAgenda.c_champId, CEntreeAgenda.c_champId, true, true)]
		[DynamicField("Diary entry")]
		public CEntreeAgenda EntreeAgenda
		{
			get
			{
				return (CEntreeAgenda)GetParent ( CEntreeAgenda.c_champId, typeof(CEntreeAgenda));
			}
			set
			{
				SetParent ( CEntreeAgenda.c_champId, value );
			}
		}

		/// <summary>
		/// Type système de l'élément à agenda, objet de la relation
		/// </summary>
		public Type TypeElementAAgenda
		{
			get
			{
				return CActivatorSurChaine.GetType ( StringTypeElementAAgenda );
			}
			set
			{
				StringTypeElementAAgenda = value.ToString();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champTypeElementAAgenda, 1024)]
		[IndexField]
		public string StringTypeElementAAgenda
		{
			get
			{
				return (string)Row[c_champTypeElementAAgenda];
			}
			set
			{
				Row[c_champTypeElementAAgenda] = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElementAAgenda)]
		[IndexField]
		public int IdElementAAgenda
		{
			get
			{
				return (int)Row[c_champIdElementAAgenda];
			}
			set
			{
				Row[c_champIdElementAAgenda] = value;
			}
		}

		/// <summary>
		/// Elément, objet de la relation
		/// </summary>
		[DynamicFieldAttribute("Linked element")]
		public CObjetDonneeAIdNumerique ElementLie
		{
			get
			{
				Type tp = TypeElementAAgenda;
				if ( tp == null )
					return null;
#if PDA
				IElementAAgenda obj = (IElementAAgenda)Activator.CreateInstance(tp);
				obj.ContexteDonnee = ContexteDonnee;
#else
				CObjetDonneeAIdNumerique obj = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[]{ContexteDonnee});
#endif
				if ( obj.ReadIfExists ( IdElementAAgenda) )
					return obj;
				return null;
			}
			set
			{
				if ( value == null )
				{
					TypeElementAAgenda = null;
					IdElementAAgenda = -1;
				}
				else
				{
					TypeElementAAgenda = value.GetType();
					IdElementAAgenda = value.Id;
				}
			}
		}

		/// <summary>
		/// Type de l'élément, correspondant à l'élément à agenda,<br/>
        /// objet de la relation
		/// </summary>
		[Relation(CRelationTypeEntreeAgenda_TypeElementAAgenda.c_nomTable,
			 CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId,
			 CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId,
			 true, false)]
		[DynamicField("Link type")]
		public CRelationTypeEntreeAgenda_TypeElementAAgenda RelationTypeEntree_TypeElement
		{
			get
			{
				return (CRelationTypeEntreeAgenda_TypeElementAAgenda)GetParent(
					CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId,
					typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda));
			}
			set
			{
				SetParent ( CRelationTypeEntreeAgenda_TypeElementAAgenda.c_champId, value );
			}
		}
		#region Membres de IRelationElementALien_Element

		public IRelationTypeElementALien_TypeElement RelationType
		{
			get
			{
				return RelationTypeEntree_TypeElement;
			}
			set
			{
				RelationTypeEntree_TypeElement = (CRelationTypeEntreeAgenda_TypeElementAAgenda)value;
			}
		}

		#endregion
				


		//---------------------------------
		/// <summary>
		/// Retourne la liste des synchronisations externes,<br/>
        /// Liées à cette relation
		/// </summary>
		[RelationFille ( typeof ( CEntreeAgenda_SynchroExt ), "RelationEntreeAgenda")]
		[DynamicChilds("External synchronizations", typeof (CEntreeAgenda_SynchroExt))]
		public CListeObjetsDonnees SynchrosExternes
		{
			get
			{
				return GetDependancesListe ( CEntreeAgenda_SynchroExt.c_nomTable, c_champId );
			}
		}
		



	}
}
