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
    /// Relation entre un <see cref="CDonneesActeurUtilisateur">Utilisateur</see>, un <see cref="CProfilUtilisateur">Profil</see> et une 
    /// <see cref="CEntiteOrganisationnelle">Entité Organisationnelle</see>
	/// </summary>
	[DynamicClass("User / Profile / OE")]
	[Table(CRelationUtilisateur_Profil_EO.c_nomTable, CRelationUtilisateur_Profil_EO.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CRelationUtilisateur_Profil_EOServeur")]
    public class CRelationUtilisateur_Profil_EO : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "USER_PROFILE_USE_EO";

		public const string c_champId = "OSRPROFUSEO_ID";

		/// /////////////////////////////////////////////
		public CRelationUtilisateur_Profil_EO(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CRelationUtilisateur_Profil_EO(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation User / Profile / Organisationnal Entity @1|299", ToString());
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
		/// Profil utilisateur associé à la relation
		/// </summary>
		[Relation(
			CRelationUtilisateur_Profil.c_nomTable,
		   CRelationUtilisateur_Profil.c_champId,
		   CRelationUtilisateur_Profil.c_champId,
			true,
			true,
			true)]
		[DynamicField("User / Profile")]
		public CRelationUtilisateur_Profil UtilisateurProfil
		{
			get
			{
				return (CRelationUtilisateur_Profil)GetParent(CRelationUtilisateur_Profil.c_champId, typeof(CRelationUtilisateur_Profil));
			}
			set
			{
				SetParent(CRelationUtilisateur_Profil.c_champId, value);
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Entité organisationnelle, objet de la relation
		/// </summary>
		[Relation(
			CEntiteOrganisationnelle.c_nomTable,
			CEntiteOrganisationnelle.c_champId,
			CEntiteOrganisationnelle.c_champId,
			true,
			false,
			true)]
		
		[DynamicField("Organisational entity")]
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
	}
	
}
