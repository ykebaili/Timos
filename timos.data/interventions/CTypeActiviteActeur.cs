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
using tiag.client;

namespace timos.data
{
	/// <summary>
	/// Fournit les types existant pour les 
	/// <see cref="CActiviteActeur">Activité d'Acteur</see>.
	/// </summary>
	[DynamicClass("Member activity type")]
	[Table(CTypeActiviteActeur.c_nomTable, CTypeActiviteActeur.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeActiviteActeurServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeActivite_ID)]
    [TiagClass(CTypeActiviteActeur.c_nomTiag, "Id", true)]
    public class CTypeActiviteActeur : CObjetDonneeAIdNumeriqueAuto, 
		                               IObjetALectureTableComplete,
		                               IDefinisseurChampCustom
	{
        public const string c_nomTable = "MEMBER_ACTIVITY_TYPE";
        public const string c_nomTiag = "Member Activity Type";

        public const string c_champId = "MBRACTTP_ID";
        public const string c_champLibelle = "MBRACTTP_LABEL";
        public const string c_champCode = "MBRACTTP_CODE";
		public const string c_champSiteObligatoire = "MBRACTTP_ACT_SITE";
		public const string c_champSaisieDuree = "MBRACTTP_ACT_DURATION";
		public const string c_champReadOnly = "MBRACTTP_READONLY";

		/// /////////////////////////////////////////////
		public CTypeActiviteActeur( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeActiviteActeur(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Activity type @1|30039",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champCode};
		}

		/// /////////////////////////////////////////////
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[RechercheRapide]
        [TiagField("Label")]
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

		////////////////////////////////////////////////
		/// <summary>
		/// code 
		/// </summary>
		[TableFieldProperty ( CTypeActiviteActeur.c_champCode, 64)]
		[DynamicField("Code")]
		[RechercheRapide]
        [TiagField("Code")]
		public string Code
		{
			get
			{
				return ( string )Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Indique que ce type d'activité ne peut pas être saisi, mais
		/// qu'il est uniquement utilisé en calcul automatique.
		/// </summary>
		[TableFieldProperty(c_champReadOnly)]
		[DynamicField("Read only activity")]
        [TiagField("Read only activity")]
		public bool ReadOnly
		{
			get
			{
				return (bool)Row[c_champReadOnly];
			}
			set
			{
				Row[c_champReadOnly] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [TableFieldProperty(c_champSiteObligatoire)]
		[DynamicField("Obligatory site")]
        [TiagField("Obligatory site")]
        public bool SiteObligatoire
        {
            get
            {
                return (bool)Row[c_champSiteObligatoire];
            }
            set
            {
                Row[c_champSiteObligatoire] = value;
            }
        }


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champSaisieDuree)]
		[DynamicField("Duration input")]
        [TiagField("Duration input")]
		public bool SaisieDuree
		{
			get
			{
				return (bool)Row[c_champSaisieDuree];
			}
			set
			{
				Row[c_champSaisieDuree] = value;
			}
		}



        //-------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CFormulaire.c_champId,
            false,
            false,
            false)]
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

        //-------------------------------------------------------------------------
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
        }

        //--------------------------------------------------------------------------
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                if (Formulaire != null)
                {
                    CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, Formulaire);
                    return new IRelationDefinisseurChamp_Formulaire[] { rel };
                }
                return new IRelationDefinisseurChamp_Formulaire[0];
            }
        }

        //--------------------------------------------------------------------------
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                List<CChampCustom> lst = new List<CChampCustom>();
                if (Formulaire != null)
                    foreach (CRelationFormulaireChampCustom rel in Formulaire.RelationsChamps)
                        lst.Add(rel.Champ);
                return lst.ToArray();
            }
        }

        
        //---------------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CActiviteActeur.c_roleChampCustom);
            }
        }



    }


}
