using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

namespace timos.data
{
	/// <summary>
    /// Objet de relation entre un <see cref="CContrat">contrat</see> de maintenance et un <see cref="CSite">site</see> couvert par ce contrat
	/// </summary>
	[DynamicClass("Contract / Site")]
	[Table(CContrat_Site.c_nomTable, CContrat_Site.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CContrat_SiteServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CContrat_Site : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete
                                
	{
		public const string c_nomTable = "CONTRACT_SITE";
        public const string c_champId = "CONT_SITE_ID";

		/// /////////////////////////////////////////////
		public CContrat_Site( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CContrat_Site(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Contract / Site Relation|425");
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



        //-------------------------------------------------------------------
        /// <summary>
        /// Le Contrat objet de la relation (relation de composition obligatoire)
        /// </summary>
        [Relation(
            CContrat.c_nomTable,
            CContrat.c_champId,
            CContrat.c_champId,
            true,
            true,
            false)]
        [DynamicField("Contrat")]
        public CContrat Contrat
        {
            get
            {
                return (CContrat)GetParent(CContrat.c_champId, typeof(CContrat));
            }
            set
            {
                SetParent(CContrat.c_champId, value);
            }
        }


            
        //-------------------------------------------------------------------
        /// <summary>
        /// Le Site objet de la relation (relation obligatoire)
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            true,
            false,
            false)]
        [DynamicField("Site")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Donne la liste des types de tickets correspondants
        /// </summary>
        [RelationFille(typeof(CTypeTicketContrat_Site), "ContratSite")]
        [DynamicChilds("Related ticket/site", typeof(CTypeTicketContrat_Site))]
        public CListeObjetsDonnees TypeTicketSites
        {
            get
            {
                return GetDependancesListe(CTypeTicketContrat_Site.c_nomTable, c_champId);
            }
        }


    }
}
