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
	/// Exprime la relation entre un profil et un profil inclus
	/// </summary>
	[DynamicClass("User profile / inclusion")]
	[Table(CProfilUtilisateur_Inclusion.c_nomTable, CProfilUtilisateur_Inclusion.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CProfilUtilisateur_InclusionServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilsUtilisateurs_ID)]
    public class CProfilUtilisateur_Inclusion : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete, IObjetDonneeAutoReference
	{
		public const string c_nomTable = "USER_PROF_INCLUSION";
		
		public const string c_champId = "USRPRFINC_ID";
		public const string c_champLibelle = "USRPRFINC_LABEL";

		public const string c_champIdProfilParent = "USRPRFINC_PARENT_PROF_ID";
		public const string c_champIdInclusionParente = "USRPRFINC_PARENT_INC_ID";

		public const string c_champIdProfilFils = "USRPRFINC_CHILD_PROF_ID";

		public const string c_champModeApplication = "USRPRFINC_APPLY_MODE";

		/// /////////////////////////////////////////////
		public CProfilUtilisateur_Inclusion( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilUtilisateur_Inclusion(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "User Profile/Inclusion|102");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			CodeModeApplication = (int)EModeApplicationSousProfil.Toujours;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		//---------------------------------------------------------------
        /// <summary>
        /// Libellé pour cette relation
        /// </summary>
		[TableFieldProperty ( c_champLibelle, 50)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				string strVal = ( string )Row[c_champLibelle];
				if ( strVal == "" && ProfilFils != null )
					strVal = ProfilFils.Libelle;
				return strVal;					
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		/// <summary>
		/// Code du mode d'application du sous profil<BR/>
		/// 0 : Toujours<BR/>
        /// 1 : Uniquement lorsqu'on travaille sur le Référentiel<br/>
		/// 2 : Uniquement lorsqu'on travaille sur une version
		/// </summary>
		[TableFieldProperty(CProfilUtilisateur_Inclusion.c_champModeApplication)]
		[DynamicField("Application mode code")]
		public int CodeModeApplication
		{
			get
			{
				return ( int )Row[c_champModeApplication];
			}
			set
			{
				Row[c_champModeApplication] = value;
			}
		}

		//------------------------------------------------------
        /// <summary>
        /// Mode d'application du sous profil (cf. Application mode code)
        /// </summary>
		[DynamicField("Application mode")]
		public CModeApplicationSousProfil ModeApplication
		{
			get
			{
				return new CModeApplicationSousProfil ( (EModeApplicationSousProfil)CodeModeApplication );
			}
			set
			{
				if ( value != null )
					CodeModeApplication = value.CodeInt;
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Indique le profil auquel appartient cette inclusion
		/// </summary>
		[Relation (
			CProfilUtilisateur.c_nomTable,
			CProfilUtilisateur.c_champId,
			c_champIdProfilParent,
			false,
			true,
			false )]
		[DynamicField("Paent profile")]
		public CProfilUtilisateur ProfilParent
		{
			get
			{
				return (CProfilUtilisateur)GetParent(c_champIdProfilParent, typeof(CProfilUtilisateur));
			}
			set
			{
				SetParent(c_champIdProfilParent, value);
				if (value != null)
					InclusionParente = null;
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Indique la relation d'inclusion qui inclut cette relation d'inclusion
		/// </summary>
		[Relation ( 
			CProfilUtilisateur_Inclusion.c_nomTable,
			CProfilUtilisateur_Inclusion.c_champId,
			CProfilUtilisateur_Inclusion.c_champIdInclusionParente,
			false,
			true,
			false )]
		[DynamicField("Parent inclusion")]		public CProfilUtilisateur_Inclusion InclusionParente
		{
			get
			{
				return (CProfilUtilisateur_Inclusion)GetParent ( c_champIdInclusionParente, typeof ( CProfilUtilisateur_Inclusion ) );
			}
			set
			{
				SetParent(c_champIdInclusionParente, value);
				if (value != null)
					ProfilParent = null;
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Liste des relations d'inclusion filles
		/// </summary>
		[RelationFille ( typeof ( CProfilUtilisateur_Inclusion ), "InclusionParente")]
		[DynamicChilds("Childs inclusions", typeof ( CProfilUtilisateur_Inclusion ))]
		public CListeObjetsDonnees InclusionsFilles
		{
			get
			{
				return GetDependancesListe(c_nomTable, c_champIdInclusionParente);
			}
		}

		////////////////////////////////////////////////
		/// <summary>
		/// Indique le profil fils correspondant à cette relation d'inclusion
		/// </summary>
		[Relation (
			CProfilUtilisateur.c_nomTable,
			CProfilUtilisateur.c_champId,
			CProfilUtilisateur_Inclusion.c_champIdProfilFils,
			true,
			false,
			false)]
		[DynamicField("Child profile")]
		public CProfilUtilisateur ProfilFils
		{
			get
			{
				return (CProfilUtilisateur)GetParent(c_champIdProfilFils, typeof(CProfilUtilisateur));
			}
			set
			{
				SetParent(c_champIdProfilFils, value);
			}
		}

		//-------------------------------------------------------------------------
		public CRelationUtilisateur_Profil CreateNewRelationToRelation(CRelationUtilisateur_Profil relation)
		{
			CRelationUtilisateur_Profil newRel = new CRelationUtilisateur_Profil(relation.ContexteDonnee);
			newRel.CreateNewInCurrentContexte();
			newRel.Profil_Inclusion = this;
			newRel.RelationParente = relation;
			foreach (CProfilUtilisateur_Inclusion inc in InclusionsFilles)
				inc.CreateNewRelationToRelation(newRel);
			return newRel;
		}


		//----------------------------------------------------
		/// <summary>
		/// Indique si ce sous profil doit être appliqué
		/// </summary>
		/// <param name="nIdVersion"></param>
		/// <returns></returns>
		public bool ShouldApply(int? nIdVersion)
		{
			return
				ModeApplication == EModeApplicationSousProfil.Toujours ||
				(ModeApplication == EModeApplicationSousProfil.EnReferentiel && nIdVersion == null) ||
				(ModeApplication == EModeApplicationSousProfil.EnVersion && nIdVersion != null);
		}




		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdInclusionParente; }
		}

		public string ProprieteListeFils
		{
			get { return "InclusionsFilles"; }
		}	

		#endregion
		//----------------------------------------------------------------------------------
		public CListeRestrictionsUtilisateurSurType GetRestrictionsGlobales(int? nIdVersion)
		{
			if (ShouldApply(nIdVersion))
			{
				CListeRestrictionsUtilisateurSurType listeRestrictions = ProfilFils.GetRestrictionsGlobales(nIdVersion);
				if (ProfilFils.EntiteOrganisationnelle == null)//Ce n'est que dans ce cas qu'on applique les restrictions globales des
					//profils inclus
				{
					foreach (CProfilUtilisateur_Inclusion inclusion in InclusionsFilles)
					{
						listeRestrictions = CListeRestrictionsUtilisateurSurType.Combine(listeRestrictions, inclusion.GetRestrictionsGlobales(nIdVersion));
					}
				}
				return listeRestrictions;
			}
			return new CListeRestrictionsUtilisateurSurType();
		}

		//----------------------------------------------------------------------------------
		public void AddTypesARestrictionsSurObjets(
			System.Collections.Generic.Dictionary<Type, bool> dicTypesARestrictionsSurObjets, 
			int? nIdVersion,
			bool bAppliquerATouteRestriction )
		{
			if (ShouldApply ( nIdVersion ))
			{
				ProfilFils.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion, bAppliquerATouteRestriction);
				//Si le profil est lié à une EO, tous les profils fils sont donc liés à une EO,
				//Donc, tous les types qu'ils restreignent ont des restriction sur objet.
				bAppliquerATouteRestriction |= ProfilFils.EntiteOrganisationnelle != null;
				foreach (CProfilUtilisateur_Inclusion inclusion in InclusionsFilles)
					inclusion.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion, bAppliquerATouteRestriction);
			}
		}
	}
}
