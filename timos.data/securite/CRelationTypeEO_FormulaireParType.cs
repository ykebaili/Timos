using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.securite
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntiteOrganisationnelle">Type d'entité organisationnelle</see><br/>
    /// et un Formulaire par rapport au Type
	/// </summary>
	[DynamicClass("Organisationnal Entity Type / Form for type")]
	[Table(CRelationTypeEO_FormulaireParType.c_nomTable, CRelationTypeEO_FormulaireParType.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationTypeEO_FormulaireParTypeServeur")]
	[Unique(true, "Another relation exists between EO type and type", CEntiteOrganisationnelle.c_champId, CRelationTypeEO_FormulaireParType.c_champType)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEO_ID)]
    public class CRelationTypeEO_FormulaireParType : CObjetDonneeAIdNumeriqueAuto, IRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "OETYPE_FORM_FOR_TYPE";

		public const string c_champId = "OETFFT_ID";
        public const string c_champType = "OETFFT_TYPE";

		/// /////////////////////////////////////////////
		public CRelationTypeEO_FormulaireParType(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CRelationTypeEO_FormulaireParType(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Organisational Entity Type / Form for type @1|297", Id.ToString());
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}


		////////////////////////////////////////////////
		/// <summary>
		/// Type d'entité organisationnelle, objet de la relation
		/// </summary>
		[Relation(
			CTypeEntiteOrganisationnelle.c_nomTable,
		  CTypeEntiteOrganisationnelle.c_champId,
		  CTypeEntiteOrganisationnelle.c_champId,
			true,
			true,
			false)]
		[DynamicField("Organisational entity type")]
		public CTypeEntiteOrganisationnelle TypeEntiteOrganisationnelle
		{
			get
			{
				return (CTypeEntiteOrganisationnelle)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle));
			}
			set
			{
				SetParent(CTypeEntiteOrganisationnelle.c_champId, value);
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Formulaire, objet de la relation
		/// </summary>
		[Relation(
			CFormulaire.c_nomTable,
		   CFormulaire.c_champId,
		   CFormulaire.c_champId,
			true,
			false,
			true)]
		
		[DynamicField("Form")]
		public CFormulaire Formulaire
		{
			get
			{
				return (CFormulaire)GetParent(CFormulaire.c_champId, typeof(CFormulaire));
			}
			set
			{
				SetParent(CFormulaire.c_champId, value);
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Type système de l'élément TIMOS associé
		/// </summary>
		[TableFieldProperty(c_champType, 1024)]
		[DynamicField("Associated type")]
		public string TypeAssocieString
		{
			get
			{
				return (string)Row[c_champType];
			}
			set
			{
				Row[c_champType] = value;
			}
		}

		//-----------------------------------------------------------
		public Type TypeAssocie
		{
			get
			{
				try
				{
					return CActivatorSurChaine.GetType(TypeAssocieString);
				}
				catch
				{
					return null;
				}
			}
			set
			{
				if (value == null)
					TypeAssocieString = "";
				else
					TypeAssocieString = value.ToString();
			}
		}




		#region IRelationDefinisseurChamp_Formulaire Membres

		public IDefinisseurChampCustom Definisseur
		{
			get
			{
				return null;
			}
			set
			{
				
			}
		}

		#endregion
	}
	
}
