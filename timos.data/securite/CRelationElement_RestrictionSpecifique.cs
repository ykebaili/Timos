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

namespace timos.data.securite
{
	#region RelationElement_RestrictionSpecifique
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationElement_RestrictionSpecifiqueAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
                return CRelationElement_RestrictionSpecifique.c_nomTable;
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
                return "ELEMENT_SPEC_RIGHT";
			}
		}


		public override string ChampId
		{
			get
			{
                return CRelationElement_RestrictionSpecifique.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
                return CRelationElement_RestrictionSpecifique.c_champTypeElement;
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
				return I.T("Specific rights|20138");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return typeof(IElementARestrictionsSpecifiques).IsAssignableFrom(tp);
		}
	}

	#endregion

    

	/// <summary>
	/// Relation entre un <see cref="CGroupeRestriction">Groupe de restrictions</see> et un élément
	/// (voir la liste de la Propriété 'ElementLie' pour les entités concernées)<BR></BR>
    /// Cette entité permet de gérer des restrictions spécifiques et uniques pour un élément donné.
	/// </summary>
    [Table(CRelationElement_RestrictionSpecifique.c_nomTable,
         CRelationElement_RestrictionSpecifique.c_champId,
		 true)]
    [ObjetServeurURI("CRelationElement_RestrictionSpecifiqueServeur")]
	[DynamicClass("Specific right / element")]
	[RelationElement_RestrictionSpecifique]
    public class CRelationElement_RestrictionSpecifique : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "ELEMENT_RESTRICT";

		public const string c_champId = "ELRSCT_ID";
		public const string c_champTypeElement = "ELRSCT_ELEMENT_TYPE";
		public const string c_champIdElement = "ELRSCT_ELEMENT_ID";


		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationElement_RestrictionSpecifique(CContexteDonnee ctx)
			: base(ctx)
		{
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationElement_RestrictionSpecifique(DataRow row)
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
				string strInfo = I.T( "Element / Right|100");
				strInfo += " ";
				if (ElementLie != null)
					strInfo += ElementLie.DescriptionElement;
				if (GroupeRestriction != null)
					strInfo += "/" + GroupeRestriction.Libelle;
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
		/// Groupe de restrictions appliqué à l'élément<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CGroupeRestrictionSurType.c_nomTable,
           CGroupeRestrictionSurType.c_champId,
           CGroupeRestrictionSurType.c_champId,
			true,
			false,
			true)]
		[DynamicField("Restriction group")]
		public CGroupeRestrictionSurType GroupeRestriction
		{
			get
			{
				return (CGroupeRestrictionSurType)GetParent(CGroupeRestrictionSurType.c_champId, typeof(CGroupeRestrictionSurType));
			}
			set
			{
				SetParent(CGroupeRestrictionSurType.c_champId, value);
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
		/// Element lié à l'entité Organisationnelle.<br/><br/>
		/// Voici la liste des éléments pouvant y être liés :<br/>
		/// <list type="bullet">
		///		<item><term><see cref="CActeur">		Acteur			</see></term></item>
		///		<item><term><see cref="CActivite">		Activite			</see></term></item>
		///		<item><term><see cref="COperation">		Operation			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CTypeSite">		Types Site			</see></term></item>
		///		<item><term><see cref="CSite">			Sites				</see></term></item>
		///		<item><term><see cref="CStock">			Stocks				</see></term></item>
		///		<item><term><see cref="CTypeEquipement">Types Equipements	</see></term></item>
		///		<item><term><see cref="CEquipement">	Equipements			</see></term></item>
		/// </list><br/>
		/// (obligatoire)
		/// </summary>
		[DynamicFieldAttribute("Linked element")]
		public CObjetDonneeAIdNumerique ElementLie
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

        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CRelationElement_RestrictionSpecifique_Application), "RelationElement_Restriction")]
        [DynamicChilds("Applications", typeof(CRelationElement_RestrictionSpecifique_Application))]
        public CListeObjetsDonnees Applications
        {
            get
            {
                return GetDependancesListe(CRelationElement_RestrictionSpecifique_Application.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        public CRelationElement_RestrictionSpecifique_Application GetRelationFor ( 
            IElementDonnantDesRestrictions elementDonnantDesRestrictions )
        {
            CListeObjetsDonnees lst = Applications;
            lst.InterditLectureInDB = true;
            
            if ( elementDonnantDesRestrictions is CActeur )
                lst.Filtre = new CFiltreData ( CActeur.c_champId+"=@1",
                    elementDonnantDesRestrictions.Id );
            if ( elementDonnantDesRestrictions is CProfilUtilisateur )
                lst.Filtre = new CFiltreData ( CProfilUtilisateur.c_champId+"=@1",
                    elementDonnantDesRestrictions.Id );
            if ( elementDonnantDesRestrictions is CGroupeActeur )
                lst.Filtre = new CFiltreData ( CGroupeActeur.c_champId+"=@1",
                    elementDonnantDesRestrictions.Id );
            if ( lst.Count > 0 )
                return lst[0] as CRelationElement_RestrictionSpecifique_Application;
            return null;
        }


	}
}
