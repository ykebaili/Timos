using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.acteurs;
using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Indique les EOs que l'élément doit avoir en commun avec la source pour<br/>
	/// qu'il fasse partie du profil.<br/>
    /// Ceci se définit par un objet de relation entre <see cref="CProfilElement">ProfilElement</see> et <see cref="CTypeEntiteOrganisationnelle">type d'entité organisationnelle</see>.
	/// </summary>
	[DynamicClass("Element profile / OE")]
	[Table(CProfilElement_TypeEO.c_nomTable, CProfilElement_TypeEO.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CProfilElement_TypeEOServeur")]
	[Unique(true,
		"Another association already exists for this operator profil/Organisationnal entity type|163",
		CProfilElement.c_champId,
		CTypeEntiteOrganisationnelle.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilElement_ID)]
    public class CProfilElement_TypeEO : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "ELEMENT_PROFILE_OE_TYPE";		

		public const string c_champId = "ELTPR_OETP_ID";

		public const string c_champModeComparaison = "ELTPR_OETP_COMP_MODE";

		/// /////////////////////////////////////////////
		public CProfilElement_TypeEO( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilElement_TypeEO(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Operator profile/Organisationnal entity type|162");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			ModeComparaison = EModeComparaisonEO.FillesUniquement;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// ProfilElement objet de la relation
		/// </summary>
		[Relation(
			CProfilElement.c_nomTable,
			CProfilElement.c_champId,
			CProfilElement.c_champId,
			true,
			true,
			false)]
		[DynamicField("Profile")]
		public CProfilElement ProfilElement
		{
			get
			{
				return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement));
			}
			set
			{
				SetParent(CProfilElement.c_champId, value);
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champModeComparaison)]
		public EModeComparaisonEO ModeComparaison
		{
			get
			{
				return (EModeComparaisonEO)Row[c_champModeComparaison];
			}
			set
			{
				Row[c_champModeComparaison] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Type d'entité organisationnelle, objet de la relation
		/// </summary>
		[Relation(
			CTypeEntiteOrganisationnelle.c_nomTable,
			CTypeEntiteOrganisationnelle.c_champId,
			CTypeEntiteOrganisationnelle.c_champId,
			false,
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

	}
}
