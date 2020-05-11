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
	/// Cette entité permet de faire le lien entre un <see cref="CTicket">Ticket</see> et ses éventuels 
    /// Tickets dépendants. Un Ticket peut être Maître ou Esclave. Un Ticket maître peut avoir plusieurs esclaves et 
    /// un Ticket esclave peut dépendre de plusieurs maîtres.
	/// </summary>
	[DynamicClass("Ticket dependancy")]
	[Table(CDependanceTicket.c_nomTable, CDependanceTicket.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CDependanceTicketServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CDependanceTicket.c_nomTiag, "Id", true)]
    public class CDependanceTicket : CObjetDonneeAIdNumeriqueAuto
    {
        #region Constantes
        public const string c_nomTiag = "Ticket Dependence";
        public const string c_nomTable = "TICKET_DEPENDENCE";
		public const string c_champId = "TKTDEP_ID";

		public const string c_champClotureAutoEscalve = "TKTDEP_AUTO_CLOSE_SLAVES";
		public const string c_champMaitre = "TKTDEP_MASTER";
		public const string c_champEsclave = "TKTDEP_SLAVE";
        #endregion
        /// /////////////////////////////////////////////
		public CDependanceTicket( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CDependanceTicket(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Ticket Dependancy|224");
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


        //-----------------------------------------------------------------
        /// <summary>
        /// Si cette option est à VRAI, le Ticket esclave sera automatiquement clos lorsque le Ticket
        ///  maître sera clos.
        /// </summary>
        [TableFieldProperty(c_champClotureAutoEscalve)]
        [DynamicField("Option auto close slave")]
        [TiagField("Option auto close slave")]
        public bool ClotureAutoEscalve
        {
            get
            {
                return (bool)Row[c_champClotureAutoEscalve];
            }
            set
            {
                Row[c_champClotureAutoEscalve] = value;
            }
        }


        public void TiagSetTicketMaitreKeys(object[] lstCles)
        {
            CTicket ticket = new CTicket(ContexteDonnee);
            if (ticket.ReadIfExists(lstCles))
                TicketMaitre = ticket;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Relation vers le Ticket maître
        /// </summary>
        [Relation(
            CTicket.c_nomTable,
            CTicket.c_champId,
            c_champMaitre,
            true,
            true,
            false)]
        [DynamicField("Master ticket")]
        [TiagRelation(typeof(CTicket), "TiagSetTicketMaitreKeys")]
        public CTicket TicketMaitre
        {
            get
            {
                return (CTicket)GetParent(c_champMaitre, typeof(CTicket));
            }
            set
            {
                SetParent(c_champMaitre, value);
            }
        }


        public void TiagSetTicketEsclaveKeys(object[] lstCles)
        {
            CTicket ticket = new CTicket(ContexteDonnee);
            if (ticket.ReadIfExists(lstCles))
                TicketEsclave = ticket;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Relation vers le Ticket esclave
        /// </summary>
        [Relation(
            CTicket.c_nomTable,
            CTicket.c_champId,
            c_champEsclave,
            true,
            true,
            false)]
        [DynamicField("Slave ticket")]
        [TiagRelation(typeof(CTicket), "TiagSetTicketEsclaveKeys")]
        public CTicket TicketEsclave
        {
            get
            {
                return (CTicket)GetParent(c_champEsclave, typeof(CTicket));
            }
            set
            {
                SetParent(c_champEsclave, value);
            }
        }


    }
}
