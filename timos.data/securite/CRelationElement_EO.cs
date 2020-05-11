using System;
using System.Data;
using System.Collections.Generic;


using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using tiag.client;
using timos.data.tiag;
using sc2i.expression;

namespace timos.securite
{
	#region RelationElement_EO
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationElement_EOAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CRelationElement_EO.c_nomTable;
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
				return "ELEMENT_EO";
			}
		}


		public override string ChampId
		{
			get
			{
				return CRelationElement_EO.c_champIdElement;
			}
		}

		public override string ChampType
		{
			get
			{
				return CRelationElement_EO.c_champTypeElement;
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
				return I.T("Organisationnal Entities|296");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return typeof(IElementAEO).IsAssignableFrom(tp);
		}
	}

	#endregion
	/// <summary>
	/// Relation entre une <see cref="CEntiteOrganisationnelle">Entite Organisationnelle</see> et un élément
	/// (voir la liste de la Propriété 'ElementLie' pour les entités concernées)
	/// </summary>
	[Table(CRelationElement_EO.c_nomTable,
		 CRelationElement_EO.c_champId,
		 true)]
	[ObjetServeurURI("CRelationElement_EOServeur")]
	[DynamicClass("Organisational entity / element")]
	[RelationElement_EO]
	[AutoExec("Autoexec")]
	[TiagUnique(CEntiteOrganisationnelle.c_champId + "=@1 and " +
		CRelationElement_EO.c_champTypeElement + "=@2 and " +
		CRelationElement_EO.c_champIdElement + "=@3",
		CEntiteOrganisationnelle.c_champId,
		CRelationElement_EO.c_champTypeElement,
		CRelationElement_EO.c_champIdElement)]
    public class CRelationElement_EO : CObjetDonneeAIdNumeriqueAuto, IObjetDonneeAChamps
	{
		public const string c_roleChampCustom = "ELEMENT_OE";
		public const string c_nomTable = "ELEMENT_OE";

		public const string c_champId = "ELOE_ID";
		public const string c_champTypeElement = "ELOE_ELEMENT_TYPE";
		public const string c_champIdElement = "ELOE_ELEMENT_ID";


		/// <summary>
		/// 
		/// </summary>
		/// <param name="ctx"></param>
		public CRelationElement_EO(CContexteDonnee ctx)
			: base(ctx)
		{
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		public CRelationElement_EO(DataRow row)
			: base(row)
		{
		}


		public static void Autoexec()
		{
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Organisational entity / element", typeof(CRelationElement_EO), typeof(CDefinisseurChampsCustomTypeEoPourType));
		}

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				string strInfo = I.T( "Element / Organisational Entity|100");
				strInfo += " ";
				if (ElementLie != null)
					strInfo += ElementLie.DescriptionElement;
				if (EntiteOrganisationnelle != null)
					strInfo += "/" + EntiteOrganisationnelle.Libelle;
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

		//-*-------------------------------------------------------
		public void TiagSetOEKeys(object[] keys)
		{
			CEntiteOrganisationnelle entite = new CEntiteOrganisationnelle(ContexteDonnee);
			if (entite.ReadIfExists(keys))
				EntiteOrganisationnelle = entite;
		}

		/// <summary>
		/// Entite Organisationnelle, objet de la relation<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CEntiteOrganisationnelle.c_nomTable,
		   CEntiteOrganisationnelle.c_champId,
		   CEntiteOrganisationnelle.c_champId,
			true,
			false,
			true)]
		[DynamicField("Organisational entity")]
		[TiagRelation(typeof(CEntiteOrganisationnelle), "TiagSetOEKeys")]
		public CEntiteOrganisationnelle EntiteOrganisationnelle
		{
			get
			{
				return (CEntiteOrganisationnelle)GetParent(CEntiteOrganisationnelle.c_champId, typeof(CEntiteOrganisationnelle));
			}
			set
			{
				SetParent(CEntiteOrganisationnelle.c_champId, value);
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

		//------------------------------------------------------------------
		public static CListeObjetsDonnees GetListeRelationsForElement(CObjetDonneeAIdNumerique objet)
		{
			CFiltreData filtre = new CFiltreData(
				c_champTypeElement + "=@1 and " +
				c_champIdElement + "= @2",
				objet.GetType().ToString(),
				objet.Id);
			CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CRelationElement_EO), filtre);
			return liste;
		}

		//------------------------------------------------------------------
		public static CListeObjetsDonnees GetEntitesOrganisationnellesDirectementLiees(IObjetDonneeAIdNumerique objet)
		{
			CFiltreData filtre = new CFiltreData(
				CRelationElement_EO.c_champTypeElement + "=@1 and " +
				CRelationElement_EO.c_champIdElement + "=@2",
				objet.GetType().ToString(),
				objet.Id);
			CListeObjetsDonnees liste = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CRelationElement_EO));
			liste.Filtre = filtre;
			return liste.GetDependances("EntiteOrganisationnelle");
		}


		#region IElementAChamps Membres

		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				if (EntiteOrganisationnelle != null)
					return new IDefinisseurChampCustom[] { EntiteOrganisationnelle.TypeEntite.GetDefinisseurForRelationsEoDeType(TypeElement) };
				return new IDefinisseurChampCustom[0];
			}
		}

		public CChampCustom[] GetChampsHorsFormulaire()
		{
			return new CChampCustom[0];
		}

		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);

		}

		[RelationFille(typeof(CRelationElementAEO_ChampCustom), "ElementAChamps")]
		public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationElementAEO_ChampCustom.c_nomTable, c_champId);
			}
		}

		#endregion

		#region IElementAVariables Membres

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        #endregion

		#region IObjetDonneeAChamps Membres

		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationElementAEO_ChampCustom(ContexteDonnee);
		}

		public string GetNomTableRelationToChamps()
		{
			return CRelationElementAEO_ChampCustom.c_nomTable;
		}

		public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = RelationsChampsCustom;
			liste.Filtre = new CFiltreData(CChampCustom.c_champId + "=@1", nIdChamp);
			return liste;
		}

		#endregion
	}
}
