using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;

namespace timos.data.vuephysique
{
	/// <summary>
	/// Permet de définir la vue physique d'un objet
	/// </summary>
    [DynamicClass("Physical view")]
	[Table(CVuePhysique.c_nomTable, CVuePhysique.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CVuePhysiqueServeur")]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Vue_Physique_Eqpt_ID)]
	public class CVuePhysique : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "PHYSICAL_VIEW";
		public const string c_champId = "PHVW_ID";
        public const string c_champFacePrincipale = "PHVW_MAIN_FACE";
        public const string c_champLargeurTotale = "PHVW_TOTAL_WIDTH";
        public const string c_champHauteurTotale = "PHVW_TOTAL_HEIGTH";
        public const string c_champProfondeurTotale = "PHVW_TOTAL_DEPTH";

		/// /////////////////////////////////////////////
		public CVuePhysique( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CVuePhysique(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Physical view of : @1|20061",ElementLie != null?ElementLie.DescriptionElement:"");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CodeFacePrincipale = (int)EFaceVueDynamique.Front;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

        /// /////////////////////////////////////////////
        public IElementAVuePhysique ElementLie
        {
            get
            {
                IElementAVuePhysique element = SiteAssocie;
                if (element == null)
                    element = EquipementAssocie;
                return element;
            }
            set
            {
                if (value is CSite)
                    SiteAssocie = (CSite)value;
                if (value is CEquipement)
                    EquipementAssocie = (CEquipement)value;
            }
        }

        //------------------------------------------------------------
        /// <summary>
        /// Site associé, s'il existe
        /// </summary>
        [Relation ( 
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            false,
            true,
            true )]
        [DynamicField("Associated site")]
        public CSite SiteAssocie
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
                if (value != null)
                    EquipementAssocie = null;
            }
        }

        //-----------------------------------------------
        /// <summary>
        /// Equipement associé, s'il existe
        /// </summary>
        [Relation(
            CEquipement.c_nomTable,
            CEquipement.c_champId,
            CEquipement.c_champId,
            false,
            true,
            true)]
        [DynamicField("Associated equipment")]
        public CEquipement EquipementAssocie
        {
            get
            {
                return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
            }
            set
            {
                SetParent(CEquipement.c_champId, value);
                if (value != null)
                    SiteAssocie = null;
            }
        }

        //-------------------------------------------------------
        /// <summary>
        /// Code de la face principale représentée :
        /// <ul>
        /// <li>0 : avant</li>
        /// <li>1 : gauche</li>
        /// <li>2 : haut</li>
        /// <li>3 : arrière</li>
        /// <li>4 : droite</li>
        /// <li>5 : bas</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champFacePrincipale)]
        [DynamicField("Main face code")]
        public int CodeFacePrincipale
        {
            get
            {
                return (int)Row[c_champFacePrincipale];
            }
            set
            {
                Row[c_champFacePrincipale] = value;
            }
        }

        //-------------------------------------------------------
        /// <summary>
        /// Face principale représentée (cf. Main face code)
        /// </summary>
        [DynamicField("Main face")]
        public CFaceVueDynamique FacePrincipale
        {
            get
            {
                return new CFaceVueDynamique((EFaceVueDynamique)CodeFacePrincipale);
            }
            set
            {
                if (value != null)
                    CodeFacePrincipale = value.CodeInt;
            }
        }

        /// <summary>
        /// Largeur totale de la vue physique ( en mm )
        /// </summary>
        [TableFieldProperty(CVuePhysique.c_champLargeurTotale)]
        [DynamicField("TotalWidth")]
        public int LargeurTotale
        {
            get
            {
                return (int)Row[c_champLargeurTotale];
            }
            set
            {
                Row[c_champLargeurTotale] = value;
            }
        }

        /// /////////////////////////////////////////////
        /// <summary>
        /// Hauteur totale de la vue physique (en mm )
        /// </summary>
        [TableFieldProperty(CVuePhysique.c_champHauteurTotale)]
        [DynamicField("TotalHeight")]
        public int HauteurTotale
        {
            get
            {
                return (int)Row[c_champHauteurTotale];
            }
            set
            {
                Row[c_champHauteurTotale] = value;
            }
        }

        /// /////////////////////////////////////////////
        ///<summary>
        ///Profondeur totale de la vue physique (en mm)
        ///</summary>
        [TableFieldProperty(CVuePhysique.c_champProfondeurTotale)]
        [DynamicField("Total depth")]
        public int ProfondeurTotale
        {
            get
            {
                return (int)Row[c_champProfondeurTotale];
            }
            set
            {
                Row[c_champProfondeurTotale] = value;
            }
        }

	}
}
