using System;
using System.Data;
using System.Collections.Generic;


using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using tiag.client;
using timos.data.tiag;
using timos.acteurs;
using timos.securite;

namespace timos.data.projet.besoin
{
	#region RelationBesoinQuantite_Element
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationBesoinQuantite_ElementAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
                return CRelationBesoinQuantite_Element.c_nomTable;
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
                return "NEED_QUANTITY_ELEMENT";
			}
		}


		public override string ChampId
		{
			get
			{
                return CRelationBesoinQuantite_Element.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
                return CRelationBesoinQuantite_Element.c_champTypeElement;
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
				return I.T("Needs quantity selections|20168");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
            bool bCondition = typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(tp);
            return bCondition;
		}
	}

	#endregion

    

	/// <summary>
	/// Relation entre un <see cref="CBesoinQuantite">Une quantité de besoin</see> et un élément
	/// sélectionné pour cette quantité
	/// </summary>
    [Table(CRelationBesoinQuantite_Element.c_nomTable,
         CRelationBesoinQuantite_Element.c_champId,
		 true)]
    [ObjetServeurURI("CRelationBesoinQuantite_ElementServeur")]
	[DynamicClass("Need quantity / Element")]
	[RelationBesoinQuantite_Element]
    public class CRelationBesoinQuantite_Element : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "NEED_QUANTITY_ELT";

		public const string c_champId = "NEEDQTEELT_ID";
        public const string c_champTypeElement = "NEEDQTEELT_ELEMENT_TYPE";
        public const string c_champIdElement = "NEEDQTEELT_ELEMENT_ID";


		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationBesoinQuantite_Element(CContexteDonnee ctx)
			: base(ctx)
		{
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationBesoinQuantite_Element(DataRow row)
			: base(row)
		{
		}


		
		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				string strInfo = I.T( "Relation between need quantity '@1' and '@2'",
                    (BesoinQuantite != null ? BesoinQuantite.Libelle : "?"),
                    (Element != null ? Element.DescriptionElement : "?"));
				return strInfo;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		/// <summary>
		/// 
		/// </summary>
		protected override void MyInitValeurDefaut()
		{
		}

		
		/// <summary>
		/// Besoin satisfait par l'élément<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CBesoinQuantite.c_nomTable,
           CBesoinQuantite.c_champId,
           CBesoinQuantite.c_champId,
			true,
			true,
			true)]
		[DynamicField("Need quantity")]
		public CBesoinQuantite BesoinQuantite
		{
			get
			{
                return (CBesoinQuantite)GetParent(CBesoin.c_champId, typeof(CBesoinQuantite));
			}
			set
			{
                SetParent(CBesoinQuantite.c_champId, value);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Type TypeElement
		{
			get
			{
				return CActivatorSurChaine.GetType(StringTypeElement);
			}
			set
			{
				StringTypeElement = value.ToString();
			}
		}

		/// <summary>
		/// Type système de l'élément TIMOS, objet de la relation
		/// </summary>
		[TableFieldProperty(c_champTypeElement, 1024)]
		[IndexField]
        [DynamicField("Element Type")]
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
		/// Identifiant (Id) de l'élément TIMOS, objet de la relation
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElement)]
		[IndexField]
        [DynamicField("Element Id")]
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
		/// Element satisfaitsant le besoin<br/>
		/// </summary>
		[DynamicFieldAttribute("Selected element")]
		public CObjetDonneeAIdNumerique Element
		{
			get
			{
				Type tp = TypeElement;
				if (tp == null)
					return null;
#if PDA
				IElementAAgenda obj = (IElementAAgenda)Activator.CreateInstance(tp);
				obj.ContexteDonnee = ContexteDonnee;
#else
				CObjetDonneeAIdNumerique obj = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[] { ContexteDonnee });
#endif
				if (obj.ReadIfExists(IdElement))
					return obj;
				return null;
			}
			set
			{
				if (value == null)
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

        //------------------------------------------------------------------
        public static CListeObjetsDonnees GetRelationsSelections(IObjetDonneeAIdNumerique objet)
        {
            CFiltreData filtre = new CFiltreData(
                    CRelationBesoinQuantite_Element.c_champTypeElement + "=@1 and " +
                    CRelationBesoinQuantite_Element.c_champIdElement + "=@2",
                    objet.GetType().ToString(),
                    objet.Id);
            CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CRelationBesoinQuantite_Element));
            liste.Filtre = filtre;
            return liste;
        }

        //------------------------------------------------------------------
        public static CListeObjetsDonnees GetQuantitesAssociees ( IObjetDonneeAIdNumerique objet )
        {
            CListeObjetsDonnees lst = GetRelationsSelections(objet);
            return lst.GetDependances("Besoin");
        }


	}
}
