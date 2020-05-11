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
	public enum EModeInclusionProfilElement
	{
		Profil = 0,
		Et = 1,
		Ou = 2
	}
	/// <summary>
    /// Objet de relation entre un <see cref="CProfilElement">ProfilElement</see> et un ProfilElement inclus
	/// </summary>
	[DynamicClass("Element profil / included profile")]
	[Table(CProfilElement_ProfilInclu.c_nomTable, CProfilElement_ProfilInclu.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CProfilElement_ProfilIncluServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilElement_ID)]
    public class CProfilElement_ProfilInclu : CObjetDonneeAIdNumeriqueAuto, IObjetDonneeAutoReference
	{

		public const string c_nomTable = "ELEMENT_PROFILE_INCLUSION";		

		public const string c_champId = "ELTPRFINC_ID";


		public const string c_champModeInclusion = "ELTPRFINC_MODE_INCL";

		public const string c_champIdProfilIncluant = "ELTPRFINC_ID_PROF_CONT";
		public const string c_champIdProfilInclu = "ELTPRFINC_ID_PROF_INCLU";
		public const string c_champIdProfilInclusionParent = "ELTPRFINC_ID_INCPROF";

		/// /////////////////////////////////////////////
		public CProfilElement_ProfilInclu( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilElement_ProfilInclu(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Element profile / Included profile|242");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			ModeInclusion = EModeInclusionProfilElement.Profil;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Profil élément inclus, objet de la relation
		/// </summary>
		[Relation(
			CProfilElement.c_nomTable,
			CProfilElement.c_champId,
			CProfilElement_ProfilInclu.c_champIdProfilInclu,
			false,
			true,
			false)]
		[DynamicField("Included profile")]
		public CProfilElement ProfilInclu
		{
			get
			{
				return (CProfilElement)GetParent(c_champIdProfilInclu, typeof(CProfilElement));
			}
			set
			{
				SetParent(c_champIdProfilInclu, value);
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(CProfilElement_ProfilInclu.c_champModeInclusion)]
		public EModeInclusionProfilElement ModeInclusion
		{
			get
			{
				return (EModeInclusionProfilElement)Row[c_champModeInclusion];
			}
			set
			{
				Row[c_champModeInclusion] = value;
			}
		}



		//-------------------------------------------------------------------
		/// <summary>
        /// 
		/// </summary>
		[Relation(
			CProfilElement_ProfilInclu.c_nomTable,
			CProfilElement_ProfilInclu.c_champId,
			CProfilElement_ProfilInclu.c_champIdProfilInclusionParent,
			false,
			true,
			false)]
		[DynamicField("Parent inclusion")]
		public CProfilElement_ProfilInclu ProfilInclusionParent
		{
			get
			{
				return (CProfilElement_ProfilInclu)GetParent(CProfilElement_ProfilInclu.c_champIdProfilInclusionParent, typeof(CProfilElement_ProfilInclu));
			}
			set
			{
				SetParent(CProfilElement_ProfilInclu.c_champIdProfilInclusionParent, value);
			}
		}


		//---------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[RelationFille(typeof(CProfilElement_ProfilInclu), "ProfilInclusionParent")]
		[DynamicChilds("Child inclusions", typeof(CProfilElement_ProfilInclu))]
		public CListeObjetsDonnees InclusionsFilles
		{
			get
			{
				return GetDependancesListe(CProfilElement_ProfilInclu.c_nomTable, c_champIdProfilInclusionParent);
			}
		}

		
		//-------------------------------------------------------------------
		/// <summary>
        /// Profil élément parent, objet de la relation
		/// </summary>
		[Relation(
			CProfilElement.c_nomTable,
			CProfilElement.c_champId,
			CProfilElement_ProfilInclu.c_champIdProfilIncluant,
			false,
			false,
			false)]
		[DynamicField("Including profile")]
		public CProfilElement ProfilIncluant
		{
			get
			{
				return (CProfilElement)GetParent(CProfilElement_ProfilInclu.c_champIdProfilIncluant, typeof(CProfilElement));
			}
			set
			{
				SetParent(CProfilElement_ProfilInclu.c_champIdProfilIncluant, value);
			}


		}

	

		//------------------------------------------------------------
		public bool UtiliseLeProfil(CProfilElement profil)
		{
			if (ModeInclusion == EModeInclusionProfilElement.Profil)
			{
				if (ProfilInclu != null)
				{
					if (profil.Equals(ProfilInclu))
						return true;
					if (ProfilInclu.UtiliseLeProfil(profil))
						return true;
				}
				
			}
			else
			{
				foreach (CProfilElement_ProfilInclu inclusion in InclusionsFilles)
				{
					if (inclusion.UtiliseLeProfil(profil))
						return true;
				}
			}
			return false;
		}

		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdProfilInclusionParent; }
		}

		public string ProprieteListeFils
		{
			get { return "InclusionsFilles"; }
		}

		#endregion
	}
}
