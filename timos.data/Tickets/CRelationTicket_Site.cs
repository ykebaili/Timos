using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using tiag.client;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTicket">Ticket</see> /
    /// et un <see cref="CSite">Site</see> qui le concerne.
    /// </summary>
	[DynamicClass("Ticket / Site")]
	[Table(CRelationTicket_Site.c_nomTable, CRelationTicket_Site.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRelationTicket_SiteServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CRelationTicket_Site.c_nomTiag, "Id", true)]
    public class CRelationTicket_Site : CObjetDonneeAIdNumeriqueAuto
                                
	{
        public const string c_nomTiag = "Ticket/Site relation";
        public const string c_nomTable = "TICKET_SITE";
        
        public const string c_champId = "TKT_SITE_ID";
        public const string c_champOrdreSite = "TKT_SITE_ORDER";

		/// /////////////////////////////////////////////
		public CRelationTicket_Site( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CRelationTicket_Site(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Ticket/Site Relation|30075");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champOrdreSite };
		}



        public void TiagSetTicketKeys(object[] lstCles)
        {
            CTicket ticket = new CTicket(ContexteDonnee);
            if (ticket.ReadIfExists(lstCles))
                Ticket = ticket;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Ticket objet de la relation.<br/>
        /// (Relation de composition obligatoire)
        /// </summary>
        [Relation(
            CTicket.c_nomTable,
            CTicket.c_champId,
            CTicket.c_champId,
            true,
            true,
            false)]
        [DynamicField("Ticket")]
        [TiagRelation(typeof(CTicket), "TiagSetTicketKeys")]
        public CTicket Ticket
        {
            get
            {
                return (CTicket)GetParent(CTicket.c_champId, typeof(CTicket));
            }
            set
            {
                SetParent(CTicket.c_champId, value);
            }
        }



        public void TiagSetSiteKeys(object[] lstCles)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstCles))
                Site = site;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le Site, objet de la relation.<br/>
        /// (Relation obligatoire)
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            true,
            false,
            false)]
        [DynamicField("Site")]
        [TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
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


        //-----------------------------------------------------------
        /// <summary>
        /// Le classement du site parmi les relations de ce type avec le ticket
        /// </summary>
        [TableFieldProperty(c_champOrdreSite)]
        [DynamicField("Site order")]
        [TiagField("Site order")]
        public int OrdreSite
        {
            get
            {
                return (int)Row[c_champOrdreSite];
            }
            set
            {
                Row[c_champOrdreSite] = value;
            }
        }


    }
}
