using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
	/// <summary>
    /// Période de validité d'un <see cref="CContrat">contrat</see> pour un <see cref="CTypeTicket">type de ticket</see> et un <see cref="CSite">site</see>.
	/// </summary>
	[DynamicClass("Ticket type / Contract / Site / Period")]
	[Table(CTypeTicketContrat_Site_Periode.c_nomTable, CTypeTicketContrat_Site_Periode.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeTicketContrat_Site_PeriodeServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CTypeTicketContrat_Site_Periode : CObjetDonneeAIdNumeriqueAuto,
                                      IObjetALectureTableComplete
	{
		public const string c_nomTable = "TICKET_CNTRT_SITE_PERIOD";
        public const string c_champId = "TCSP_ID";
        public const string c_champDateDebut = "TCSP_START_DATE";
        public const string c_champDateFin = "TCSP_END_DATE";

		/// /////////////////////////////////////////////
		public CTypeTicketContrat_Site_Periode( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CTypeTicketContrat_Site_Periode(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Contrat(@1)/Ticket type(@2)/Site(@3)/Period(@4-@5)|20081",
                    Contrat == null?"?":Contrat.Libelle,
                    TypeTicket == null?"?":TypeTicket.Libelle,
                    Site == null?"?":Site.Libelle
                    );
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateDebut};
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Date de début de la période
        /// </summary>
        [TableFieldProperty(c_champDateDebut)]
        [DynamicField("Start date")]
        public DateTime DateDebut
        {
            get
            {
                return (DateTime)Row[c_champDateDebut];
            }
            set
            {
                Row[c_champDateDebut] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Date de fin de la période
        /// </summary>
        [TableFieldProperty(c_champDateFin)]
        [DynamicField("End date")]
        public DateTime DateFin
        {
            get
            {
                return (DateTime)Row[c_champDateFin];
            }
            set
            {
                Row[c_champDateFin] = value;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Objet 'Type Ticket Contrat Site' concerné par cette période
        /// </summary>
        [Relation(
            CTypeTicketContrat_Site.c_nomTable,
            CTypeTicketContrat_Site.c_champId,
            CTypeTicketContrat_Site.c_champId,
            true,
            true,
            false)]
        [DynamicField("Site association")]
        public CTypeTicketContrat_Site TypeTicketContrat_Site
        {
            get
            {
                return (CTypeTicketContrat_Site)GetParent(CTypeTicketContrat_Site.c_champId, typeof(CTypeTicketContrat_Site));
            }
            set
            {
                SetParent(CTypeTicketContrat_Site.c_champId, value);
            }
        }

	


        //-------------------------------------------------------------------
        /// <summary>
        /// Contrat concerné par cette période
        /// </summary>
        [DynamicField("Contract")]
        public CContrat Contrat
        {
            get
            {
                CTypeTicketContrat_Site tt = TypeTicketContrat_Site;
                if (tt != null)
                    return tt.Contrat;
                return null;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Type de ticket concerné par cette période
        /// </summary>
        [DynamicField("Ticket type")]
        public CTypeTicket TypeTicket
        {
            get
            {
                CTypeTicketContrat_Site tt = TypeTicketContrat_Site;
                if (tt != null)
                    return tt.TypeTicket;
                return null;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Site concerné par cette période
        /// </summary>
        [DynamicField("Site")]
        public CSite Site
        {
            get
            {
                CTypeTicketContrat_Site tt = TypeTicketContrat_Site;
                if (tt != null)
                    return tt.ContratSite.Site;
                return null;
            }
        }

        //-------------------------------------------------------------------


        

	

	

   


	}
}
