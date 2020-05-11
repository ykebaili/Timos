using System;
using System.Collections;
using System.Data;
using System.Linq;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using timos.data;
using tiag.client;
using timos.data.sites.releve;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Détail d'un équipement relevé (ou non) sur un site.
	/// </summary>
    /// <remarks>
    /// Il existe une ligne par équipement présent ou censé être présent sur un site
    /// </remarks>
    [DynamicClass("Site survey/Equipment")]
	[Table(CReleveEquipement.c_nomTable, CReleveEquipement.c_champId, true )]
	[ObjetServeurURI("CReleveEquipementServeur")]
	[TiagClass(CReleveEquipement.c_nomTiag, "Id", true)]
    [NoRelationTypeId]
    [AutoExec("Autoexec")]
    public class CReleveEquipement : CElementAChamp,
		IElementAInterfaceTiag,
        IObjetDonneeAutoReference,
        IObjetSansVersion
	{
        public const string c_roleChampCustom = "EQUIPMENT_SURVEY";

		public const string c_nomTiag = "Site survey/Equipment";
		public const string c_nomTable = "SITE_SURVEY_EQPT";
		public const string c_champId = "SITEQTSUR_ID";
		public const string c_champPresence = "SITEQTSUR_PRESENCE";
        public const string c_champCommentaire = "SITEQTSUR_COMMENT";
        public const string c_champSerial = "SITEQTSUR_SERIAL";
        public const string c_champCoord = "SITEQTSUR_COORD";
        public const string c_champParentEqpt = "SITEEQTSUR_PARENT_ID";
        public const string c_champDataTraitement = "SITEEQTSUR_ACTION_DATA";
        public const string c_champActionValidée = "SITEEQTSUR_VALIDATED";
        public const string c_champInfoChoix = "SITEEQTSUR_CHOICE_INFO";

        public const string c_champDataTraitementCache = "SITEEQTSUR_ACTION_CACHE";


		/// /////////////////////////////////////////////
		public CReleveEquipement( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CReleveEquipement(DataRow row )
			:base(row)
		{
		}

        /// /////////////////////////////////////////////
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole ( c_roleChampCustom, I.T("Equipment survey|20244"), typeof(CReleveEquipement), typeof(CDefinisseurChampsCustomReleveEquipement));
        }

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Site survey, equipment @1|20204",
                    Equipement != null ? Equipement.Libelle:"?");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CodeEtatValidationAction = (int)EEtatValidationReleveEquipement.None;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champCoord};
		}


        /// <summary>
        /// Code de l'état de validation
        /// </summary>
        /// <remarks>
        /// Les valeurs possibles sont <BR/>
        /// <LI>0 : non validée</LI>
        /// <LI>10 : validée</LI>
        /// <LI>20 : appliquée</LI>
        /// </remarks>
        [TableFieldProperty(c_champActionValidée)]
        [DynamicField("Validation state code")]
        public int CodeEtatValidationAction
        {
            get
            {
                return (int)Row[c_champActionValidée];
            }
            set
            {
                Row[c_champActionValidée] = value;
            }
        }

        /// /////////////////////////////////////////////
        [DynamicField("Validation state")]
        public CEtatValidationReleveEquipement EtatValidation
        {
            get
            {
                return new CEtatValidationReleveEquipement((EEtatValidationReleveEquipement)CodeEtatValidationAction);
            }
            set
            {
                CodeEtatValidationAction = value != null?value.CodeInt:(int)EEtatValidationReleveEquipement.None;
            }
        }




        /// /////////////////////////////////////////////
        ///<summary>
        ///Informations sur l'action associée à cette ligne de relevé
        ///</summary>
        [TableFieldProperty(c_champInfoChoix, 255)]
        [DynamicField("Choice information")]
        public string InformationsChoix
        {
            get
            {
                return Row.Get<string>(c_champInfoChoix);
            }
            set
            {
                Row[c_champInfoChoix] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Equipement relevé
        /// </summary>
        [Relation(
            CEquipement.c_nomTable,
            CEquipement.c_champId,
            CEquipement.c_champId,
            false,
            false,
            false, PasserLesFilsANullLorsDeLaSuppression = true)]
        [DynamicField("Equipment")]
        public CEquipement Equipement
        {
            get
            {
                return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
            }
            set
            {
                SetParent(CEquipement.c_champId, value);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Type de l'équipement relevé
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            true,
            false,
            false)]
        [DynamicField("EquipmentType")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Reference fournisseur
        /// </summary>
        [Relation(
            CRelationTypeEquipement_Constructeurs.c_nomTable,
            CRelationTypeEquipement_Constructeurs.c_champId,
            CRelationTypeEquipement_Constructeurs.c_champId,
            false,
            true,
            false)]
        [DynamicField("Manufacturer reference")]
        public CRelationTypeEquipement_Constructeurs ReferenceConstructeur
        {
            get
            {
                return (CRelationTypeEquipement_Constructeurs)GetParent(CRelationTypeEquipement_Constructeurs.c_champId, typeof(CRelationTypeEquipement_Constructeurs));
            }
            set
            {
                SetParent(CRelationTypeEquipement_Constructeurs.c_champId, value);
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique si l'équipement est présent (true), absent (false) ou si rien n'a
        /// été indiqué pour cet équipement (null)
        /// </summary>
        [TableFieldProperty(c_champPresence, NullAutorise=true)]
        [DynamicField("Presence")]
        public bool? Presence
        {
            get
            {
                return (bool?)Row[c_champPresence, true];
            }
            set
            {
                Row[c_champPresence, true] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Commentaire saisi durant l'opération de relevé de l'équipement
        /// </summary>
        [TableFieldProperty(c_champCommentaire, 1024)]
        [DynamicField("Comment")]
        public string Commentaire
        {
            get
            {
                return (string)Row[c_champCommentaire];
            }
            set
            {
                Row[c_champCommentaire] = value==null?"":value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Numéro de série relevé
        /// </summary>
        [TableFieldProperty(c_champSerial, 255)]
        [DynamicField("Serial number")]
        public string NumSerie
        {
            get
            {
                return (string)Row[c_champSerial];
            }
            set
            {
                Row[c_champSerial] = value==null?"":value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Coordonnée relevée
        /// </summary>
        [TableFieldProperty(c_champCoord, 255)]
        [DynamicField("Coordinate")]
        public string Coordonnee
        {
            get
            {
                return (string)Row[c_champCoord];
            }
            set
            {
                Row[c_champCoord] = value == null ? "" : value; ;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Equipement relevé contenant cet équipement
        /// </summary>
        [Relation(
            CReleveEquipement.c_nomTable,
            CReleveEquipement.c_champId,
            c_champParentEqpt,
            false,
            true,
            false)]
        [DynamicField("Parent equipment survey")]
        public CReleveEquipement ReleveEquipementParent
        {
            get
            {
                return (CReleveEquipement)GetParent(c_champParentEqpt, typeof(CReleveEquipement));
            }
            set
            {
                SetParent(c_champParentEqpt, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Liste des relevés des équipements contenus
        /// </summary>
        [RelationFille(typeof(CReleveEquipement), "ReleveEquipementParent")]
        [DynamicChilds("Children equipment survey", typeof(CReleveEquipement))]
        public CListeObjetsDonnees RelevesEquipementsFils
        {
            get
            {
                return GetDependancesListe(CReleveEquipement.c_nomTable, c_champParentEqpt);
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CReleveSite.c_nomTable,
            CReleveSite.c_champId,
            CReleveSite.c_champId,
            true,
            true,
            false)]
        [DynamicField("Site survey")]
        public CReleveSite ReleveSite
        {
            get
            {
                return (CReleveSite)GetParent(CReleveSite.c_champId, typeof(CReleveSite));
            }
            set
            {
                SetParent(CReleveSite.c_champId, value);
            }
        }


        //----------------------------------------------------------------------
        [TableFieldProperty(c_champDataTraitement, 4000)]
        public string ActionDataString
        {
            get
            {
                return Row.Get<string>(c_champDataTraitement);
            }
            set
            {
                Row[c_champDataTraitement] = value == null ? "" : value; ;
            }
        }

        //----------------------------------------------------------------------
        [TableFieldProperty(c_champDataTraitementCache, IsInDb=false, NullAutorise=true)]
        public CActionTraitementReleveEquipement Action
        {
            get
            {
                CActionTraitementReleveEquipement action = Row[c_champDataTraitementCache] as CActionTraitementReleveEquipement;
                if (action != null)
                    return action;
                CStringSerializer serializer = new CStringSerializer(ActionDataString, ModeSerialisation.Lecture);
                CResultAErreur result = serializer.TraiteObject<CActionTraitementReleveEquipement>(ref action,this);
                if (result)
                {
                    CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champDataTraitementCache, action);
                }
                return action;
            }
            set
            {
                if (value == null)
                    ActionDataString = "";
                else
                {
                    CActionTraitementReleveEquipement action = value;
                    CStringSerializer ser = new CStringSerializer(ModeSerialisation.Ecriture);
                    if (ser.TraiteObject<CActionTraitementReleveEquipement>(ref action, this))
                        ActionDataString = ser.String;
                }
                Row[c_champDataTraitementCache] = DBNull.Value;
            }
        }


		#region IElementAInterfaceTiag Membres

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		#endregion



        #region IObjetDonneeAutoReference Membres

        public string ChampParent
        {
            get { throw new NotImplementedException(); }
        }

        public string ProprieteListeFils
        {
            get { throw new NotImplementedException(); }
        }

        #endregion


        //----------------------------------------------------------------------
        public CTraitementReleveEquipement GetTraitement()
        {
            CTraitementReleveEquipement traitement = new CTraitementReleveEquipement();
            traitement.ReleveEquipement = this;
            if (Action != null)
                traitement.Action = Action;
            else
                traitement.CalculeAction();
            foreach (CReleveEquipement relFils in RelevesEquipementsFils)
            {
                CTraitementReleveEquipement tFils = relFils.GetTraitement();
                if (tFils != null)
                    traitement.AddTraitementFils(tFils);
            }
            if (traitement.Action == null && traitement.TraitementsFils.Count() == 0)
                return null;
            return traitement;
        }

        //-------------------------------------------------------------------
        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsCustomReleveEquipement(ContexteDonnee) 
                    };
            }
        }

        //-------------------------------------------------------------------
        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationReleveEquipement_ChampCustom(ContexteDonnee);
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// retourne la liste des valeurs de champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationReleveEquipement_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationReleveEquipement_ChampCustom))]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationReleveEquipement_ChampCustom.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }
    }
}
