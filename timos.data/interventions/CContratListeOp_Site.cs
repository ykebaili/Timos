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
    /// Objet de relation entre un <see cref="CSite">Site</see> et un <see cref="CContrat">Contrat</see> donné et une <see cref="CListeOperation">Liste d'Opération</see> donnée
	/// </summary>
	[DynamicClass("Contract Op. List / Site")]
	[Table(CContratListeOp_Site.c_nomTable, CContratListeOp_Site.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CContratListeOp_SiteServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CContratListeOp_Site : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete
                                
	{
		public const string c_nomTable = "CONT_OPLIST_SITE";
        public const string c_champId = "CONT_OPLIST_SITE_ID";

		/// /////////////////////////////////////////////
		public CContratListeOp_Site( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CContratListeOp_Site(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Contract Op.List / Site Relation|427");
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
        /// Obtient ou définit la relation 'contrat / liste d'opérations', objet de la relation<br/>
        /// (relation de composition obligatoire)
        /// </summary>
        [Relation(
            CContrat_ListeOperations.c_nomTable,
            CContrat_ListeOperations.c_champId,
            CContrat_ListeOperations.c_champId,
            true,
            true,
            false)]
        [DynamicField("ContratListeOp")]
        public CContrat_ListeOperations ContratListeOp
        {
            get
            {
                return (CContrat_ListeOperations)GetParent(CContrat_ListeOperations.c_champId, typeof(CContrat_ListeOperations));
            }
            set
            {
                SetParent(CContrat_ListeOperations.c_champId, value);
            }
        }


            
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit Le Site, objet de la relation (relation obligatoire)
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


    }
}
