using System;
using System.Data;

using sc2i.common;
using sc2i.data;

namespace sc2i.workflow
{
	#region RelationDossierSuivi_ElementToElement
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationDossierSuivi_ElementToElementAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CRelationDossierSuivi_Element.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 900;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
				return "REL_DOSSIER_ELT";
			}
		}

		
		public override string ChampId
		{
			get
			{
				return CRelationDossierSuivi_Element.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
				return CRelationDossierSuivi_Element.c_champTypeElement;
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
				return I.T("Linked workbooks|20077");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return tp.IsSubclassOf ( typeof(CObjetDonneeAIdNumerique) );
		}
	}

	#endregion
	/// <summary>
    /// Relation entre un <see cref="CDossierSuivi">Dossier de suivi</see> et un 
    /// <see cref="CObjetDonneeAIdNumerique">élément lié</see>.
	/// </summary>
	[Table(CRelationDossierSuivi_Element.c_nomTable, 
		 CRelationDossierSuivi_Element.c_champId,
		 true)]
	[ObjetServeurURI("CRelationDossierSuivi_ElementServeur")]
	[DynamicClass("Workbook / Element")]
	[RelationDossierSuivi_ElementToElement]
	public class CRelationDossierSuivi_Element : CObjetDonneeAIdNumeriqueAuto, IRelationElementALien_Element
	{
		public const string c_nomTable = "WORKBOOK_ELEMENT";

		public const string c_champId = "WKBELT_ID";
		public const string c_champTypeElement = "WKBELT_ELEMENT_TYPE";
		public const string c_champIdElement = "WKBELT_ELEMENT_ID";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationDossierSuivi_Element( CContexteDonnee ctx)
			:base(ctx)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationDossierSuivi_Element ( DataRow row )
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
				string strInfo = I.T("Relation between WorkBook @1|332",DossierSuivi.Libelle);
				CObjetDonneeAIdNumerique elt = ElementLie;
				if ( elt != null )
					strInfo += I.T(" and @1|333", ElementLie.DescriptionElement);
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
		/// Dossier de suivi, objet de la relation
		/// </summary>
        [DynamicField("Workbook")]
		[Relation(CDossierSuivi.c_nomTable, CDossierSuivi.c_champId, CDossierSuivi.c_champId, true, true)]
		public CDossierSuivi DossierSuivi
		{
			get
			{
				return (CDossierSuivi)GetParent ( CDossierSuivi.c_champId, typeof(CDossierSuivi));
			}
			set
			{
				SetParent ( CDossierSuivi.c_champId, value );
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Type TypeElement
		{
			get
			{
				return CActivatorSurChaine.GetType ( StringTypeElement );
			}
			set
			{
				StringTypeElement = value.ToString();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champTypeElement, 1024)]
		public string StringTypeElement
		{
			get
			{
				return (string)Row[c_champTypeElement];
			}
			set
			{
				Row[c_champTypeElement] = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElement)]
		public int IdElement
		{
			get
			{
				return (int)Row[c_champIdElement];
			}
			set
			{
				Row[c_champIdElement] = value;
			}
		}

		/// <summary>
		/// Elément lié, objet de la relation
		/// </summary>
		[DynamicFieldAttribute("Linked element")]
		public CObjetDonneeAIdNumerique ElementLie
		{
			get
			{
				Type tp = TypeElement;
				if ( tp == null )
					return null;
#if PDA
				IElement obj = (IElement)Activator.CreateInstance(tp);
				obj.ContexteDonnee = ContexteDonnee;
#else
				CObjetDonneeAIdNumerique obj = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[]{ContexteDonnee});
#endif
				if ( obj.ReadIfExists ( IdElement) )
					return obj;
				return null;
			}
			set
			{
				if ( value == null )
				{
					TypeElement = null;
					IdElement = -1;
				}
				else
				{
					TypeElement = value.GetType();
					IdElement = value.Id;
				}
			}
		}

		/// <summary>
		/// Type du lien, correspondant à la relation
		/// </summary>
		[Relation(CRelationTypeDossierSuivi_TypeElement.c_nomTable,
			 CRelationTypeDossierSuivi_TypeElement.c_champId,
			 CRelationTypeDossierSuivi_TypeElement.c_champId,
			 true, false)]
		[DynamicField("Link type")]
		public CRelationTypeDossierSuivi_TypeElement RelationParametre_TypeElement
		{
			get
			{
				return (CRelationTypeDossierSuivi_TypeElement)GetParent(
					CRelationTypeDossierSuivi_TypeElement.c_champId,
					typeof(CRelationTypeDossierSuivi_TypeElement));
			}
			set
			{
				SetParent ( CRelationTypeDossierSuivi_TypeElement.c_champId, value );
			}
		}
		#region Membres de IRelationElementALien_Element

		public IRelationTypeElementALien_TypeElement RelationType
		{
			get
			{
				return RelationParametre_TypeElement;
			}
			set
			{
				RelationParametre_TypeElement = (CRelationTypeDossierSuivi_TypeElement)value;
			}
		}

		#endregion

	}
}
