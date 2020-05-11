using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.securite
{
	/// <summary>
	/// Relation entre un profil utilisateur et une restriction
	/// </summary>
	[DynamicClass("User profile / restriction")]
	[Table(CProfilUtilisateur_Restriction.c_nomTable, CProfilUtilisateur_Restriction.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CProfilUtilisateur_RestrictionServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilsUtilisateurs_ID)]
    public class CProfilUtilisateur_Restriction : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_nomTable = "USER_PROFILE_RESTR";
		
		public const string c_champId = "USRP_REST_ID";

		/// /////////////////////////////////////////////
		public CProfilUtilisateur_Restriction( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilUtilisateur_Restriction(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("User Profile / Restriction @1|295",Id.ToString());
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		//------------------------------------------------
        /// <summary>
        /// Profil, objet de la relation
        /// </summary>
		[Relation ( 
			CProfilUtilisateur.c_nomTable,
			CProfilUtilisateur.c_champId,
			CProfilUtilisateur.c_champId,
			true,
			true,
			true )]
		[DynamicField("Profile")]
		public CProfilUtilisateur Profil
		{
			get
			{
				return (CProfilUtilisateur)GetParent(CProfilUtilisateur.c_champId, typeof(CProfilUtilisateur));
			}
			set
			{
				SetParent(CProfilUtilisateur.c_champId, value);
			}
		}

		//-----------------------------------------------------------------
        /// <summary>
        /// Rstriction, objet de la relation
        /// </summary>
		[Relation(
		   CGroupeRestrictionSurType.c_nomTable,
		   CGroupeRestrictionSurType.c_champId,
		   CGroupeRestrictionSurType.c_champId,
			true,
			false,
			true)]
		[DynamicField("Restrictions")]
		public CGroupeRestrictionSurType Restrictions
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

		
	}
}
