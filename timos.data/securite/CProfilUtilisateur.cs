using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.data;
using timos.acteurs;
using timos.data.securite;
using System.Collections.Generic;
using System.Text;
using sc2i.process.workflow;

namespace timos.securite
{
	/// <summary>
    /// La notion de profil concerne les <see cref="CDonneesActeurUtilisateur">utilisateurs</see> de l'application.<br/>
    /// Un profil permet, en association avec les <see cref="CGroupeRestrictionsSurTypes">restrictions</see> qu'il intègre, de restreindre l'accès<br/>
    /// à des catégories d'objets de l'application ou à des ensembles d'objets, ceci fonction éventuellement<br/>
    /// des <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auquelles sont attachés les utilisateurs et les objets.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iSecurite)]
    [DynamicClass("User profile")]
	[Table(CProfilUtilisateur.c_nomTable, CProfilUtilisateur.c_champId, true )]
    [AutoExec("Autoexec")]
	[FullTableSync]
	[ObjetServeurURI("CProfilUtilisateurServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ProfilsUtilisateurs_ID)]
    public class CProfilUtilisateur : CObjetDonneeAIdNumeriqueAuto, 
        IObjetALectureTableComplete,
        IElementDonnantDesRestrictions,
        IAffectableAEtape
	{
        public const string c_racineAffectationEtape = "USPRO";
        public const string c_cleFiltrerOnAll = "ALL";
        public const string c_cleFiltrerOnNone = "NONE";

		public const string c_nomTable = "USER_PROFIL";
		
		public const string c_champId = "USRPRF_ID";
		public const string c_champLibelle = "USRPRF_LABEL";
		public const string c_champLibelleSaisieEntite = "USRPRF_INPUT_LABE";
		public const string c_champAffinable = "USRPRF_CAN_SPECIFY";
        
        public const string c_champTypesAFiltrer = "USRPRF_TYPES_TO_FILTER";
        public const string c_champMasquerHorsBranche = "USRPRF_HIDE_OUT_BRANCH";




#if PDA
		//-------------------------------------------------------------------
		public CProfilUtilisateur()
			:base()
		{
		}
#endif
		/// /////////////////////////////////////////////
		public CProfilUtilisateur( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CProfilUtilisateur(DataRow row )
			:base(row)
		{
		}

        /// /////////////////////////////////////////////
        public static void Autoexec()
        {
            CAffectationsEtapeWorkflow.RegisterAffectable(c_racineAffectationEtape, typeof(CProfilUtilisateur));
        }

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("User profile @1|101",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Affinable = true;
            StringTypesAFiltrer = c_cleFiltrerOnAll;
            MasquerLesHorsBranche = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		//------------------------------------------------------
        /// <summary>
        /// Libellé du profil
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[DescriptionField]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}

		//--------------------------------------------------
		/// <summary>
		/// Donne ou définit le libellé qui sera présenté au niveau de la saisie<br/>
        /// de l'utilisateur, pour sélectionner l'entité organisationnelle
		/// </summary>
		[TableFieldProperty(CProfilUtilisateur.c_champLibelleSaisieEntite, 50)]
		[DynamicField("Capture label")]
		public string LibelleSaisieEntite
		{
			get
			{
				return (string)Row[c_champLibelleSaisieEntite];
			}
			set
			{
				Row[c_champLibelleSaisieEntite] = value;
			}
		}

		/// <summary>
		/// Indique, qu'au niveau de la saisie de l'utilisateur, il est possible<br/>
        /// d'affiner le choix de l'entité organisationnelle, parmi les filles<br/>
        /// des entités organisationnelles sélectionnées dans le profil
		/// </summary>
		[TableFieldProperty ( c_champAffinable )]
		[DynamicField("Can be specify")]
		public bool		Affinable
		{
			get
			{
				return (bool)Row[c_champAffinable];
			}
			set
			{
				Row[c_champAffinable] = value;
			}
		}

        //---------------------------------------------------------------------
        public bool ShouldFiltrerSur(Type tp)
        {
            if (StringTypesAFiltrer == c_cleFiltrerOnAll)
                return true;
            if (StringTypesAFiltrer == c_cleFiltrerOnNone)
                return false;
            return StringTypesAFiltrer.Contains(tp.ToString().ToUpper());
        }

        //---------------------------------------------------------------------
        [TableFieldProperty(c_champMasquerHorsBranche)]
        [DynamicField("Hide out branch")]
        public bool MasquerLesHorsBranche
        {
            get{
                return Row.Get<bool>(c_champMasquerHorsBranche);
            }
            set{
                Row[c_champMasquerHorsBranche] = value;
            }
        }

        //---------------------------------------------------------------------
        [DynamicField("System types to filter")]
        [TableFieldProperty(c_champTypesAFiltrer, 6000, IsLongString = true)]
        public string StringTypesAFiltrer
        {
            get
            {
                return Row.Get<string>(c_champTypesAFiltrer);
            }
            set
            {
                Row[c_champTypesAFiltrer] = value.ToUpper() ;
            }
        }

        //---------------------------------------------------------------------
        public bool FiltrerTout
        {
            get
            {
                return StringTypesAFiltrer == c_cleFiltrerOnAll;
            }
            set
            {
                if (value)
                    StringTypesAFiltrer = c_cleFiltrerOnAll;
            }
        }

        //---------------------------------------------------------------------
        public bool FiltrerAucun
        {
            get
            {
                return StringTypesAFiltrer == c_cleFiltrerOnNone;
            }
            set
            {
                if (value)
                    StringTypesAFiltrer = c_cleFiltrerOnNone;
            }
        }

        //---------------------------------------------------------------------
        public Type[] TypesAFiltrer
        {
            get
            {
                List<Type> lst = new List<Type>();
                if (FiltrerAucun)
                    return lst.ToArray();
                if (FiltrerTout)
                {
                    foreach (Type tp in CContexteDonnee.GetAllTypes())
                    {
                        if (typeof(IElementAEO).IsAssignableFrom(tp))
                            lst.Add(tp);
                    }
                    return lst.ToArray();
                }
                string[] strTypes = StringTypesAFiltrer.Split(';');
                foreach (string strType in strTypes)
                {
                    Type tp = CActivatorSurChaine.GetType(strType);
                    if (tp != null)
                        lst.Add(tp);
                }
                return lst.ToArray();
            }
            set
            {
                if (value.Length == 0)
                    FiltrerAucun = true;
                else
                {
                    StringBuilder bl = new StringBuilder();
                    foreach (Type tp in value)
                    {
                        bl.Append(tp.ToString());
                        bl.Append(';');
                    }
                    if (bl.Length > 0)
                    {
                        bl.Remove(bl.Length - 1, 1);
                        StringTypesAFiltrer = bl.ToString();
                    }
                    else
                        FiltrerAucun = true;
                }
            }
        }




		/// /////////////////////////////////////////////
		///<summary>
		/// Indique l'entité organisationnelle auquel s'applique ce profil
		///</summary>
		[Relation ( 
			CEntiteOrganisationnelle.c_nomTable,
			CEntiteOrganisationnelle.c_champId,
			CEntiteOrganisationnelle.c_champId,
			false,
			false,
			false)]
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

		//---------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du profil avec les restrictions correspondantes
        /// </summary>
		[RelationFille ( typeof(CProfilUtilisateur_Restriction), "Profil")]
		[DynamicChilds ( "Restrictions relations", typeof ( CProfilUtilisateur_Restriction ) )]
		public CListeObjetsDonnees RelationsRestrictions
		{
			get
			{
				return GetDependancesListe(CProfilUtilisateur_Restriction.c_nomTable, c_champId);
			}
		}

		//--------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du profil avec les profils inclus
        /// </summary>
		[RelationFille ( typeof(CProfilUtilisateur_Inclusion), "ProfilParent")]
		[DynamicChilds("Profiles inclusions", typeof (CProfilUtilisateur_Inclusion ) )]
		public CListeObjetsDonnees Inclusions
		{
			get
			{
				return GetDependancesListe(CProfilUtilisateur_Inclusion.c_nomTable, CProfilUtilisateur_Inclusion.c_champIdProfilParent);
			}
		}

		////////////////////////////////////////////////
		public CRelationUtilisateur_Profil CreateNewRelationUtilisateur(CDonneesActeurUtilisateur user)
		{
			CRelationUtilisateur_Profil relation = new CRelationUtilisateur_Profil(user.ContexteDonnee);
			relation.CreateNewInCurrentContexte();
			relation.Profil = this;
			relation.Utilisateur = user;
			foreach (CProfilUtilisateur_Inclusion inclusion in Inclusions)
				inclusion.CreateNewRelationToRelation(relation);
			return relation;
		}

		////////////////////////////////////////////////
		public CRelationUtilisateur_Profil CreateNewRelationToRelation(CRelationUtilisateur_Profil relationParente)
		{
			CRelationUtilisateur_Profil relation = new CRelationUtilisateur_Profil(relationParente.ContexteDonnee);
			relation.CreateNewInCurrentContexte();
			relation.Profil = this;
			relation.RelationParente = relationParente;
			foreach (CProfilUtilisateur_Inclusion inclusion in Inclusions)
				inclusion.CreateNewRelationToRelation(relation);
			return relation;
		}

		////////////////////////////////////////////////
		public void AddTypesARestrictionsSurObjets(System.Collections.Generic.Dictionary<Type, bool> dicTypesARestrictionsSurObjets, int? nIdVersion, bool bAppliquerATouteRestriction)
		{
			if (EntiteOrganisationnelle != null || bAppliquerATouteRestriction)
			{
				bAppliquerATouteRestriction = true;
				foreach (CProfilUtilisateur_Restriction relRest in RelationsRestrictions)
				{
					CListeRestrictionsUtilisateurSurType listeRestrictions = relRest.Restrictions.ListeRestrictions;
					foreach (CRestrictionUtilisateurSurType restriction in listeRestrictions.ToutesLesRestrictionsAffectees)
						if (restriction.HasRestrictions)
							dicTypesARestrictionsSurObjets[restriction.TypeAssocie] = true;
				}
			}
			foreach (CProfilUtilisateur_Inclusion inclusion in Inclusions)
			{
				inclusion.AddTypesARestrictionsSurObjets(dicTypesARestrictionsSurObjets, nIdVersion, bAppliquerATouteRestriction);
			}
		}

		/// <summary>
		/// Retourne la restriction globale (en dehors d'éléments spécifiques à EO) 
		/// generés par ce profil
		/// </summary>
		/// <returns></returns>
		public CListeRestrictionsUtilisateurSurType GetRestrictionsGlobales(int? nIdVersion)
		{
			CListeRestrictionsUtilisateurSurType listeRestrictions = new CListeRestrictionsUtilisateurSurType();
			if (EntiteOrganisationnelle == null)
			{
				foreach (CProfilUtilisateur_Restriction relRes in RelationsRestrictions)
					listeRestrictions = CListeRestrictionsUtilisateurSurType.Combine(listeRestrictions, relRes.Restrictions.ListeRestrictions);
				foreach (CProfilUtilisateur_Inclusion inclusion in Inclusions)
				{
					listeRestrictions = CListeRestrictionsUtilisateurSurType.Combine(listeRestrictions, inclusion.GetRestrictionsGlobales(nIdVersion));
				}
			}
			
			return listeRestrictions;
		}

        #region IAffectableAEtape Membres

        public string RacineCleAffectationWorkflow
        {
            get { return c_racineAffectationEtape; }
        }

        #endregion
    }
}
