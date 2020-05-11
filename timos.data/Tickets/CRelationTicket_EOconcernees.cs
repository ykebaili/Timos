using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using timos.securite;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTicket">Ticket</see> /
    /// et une <see cref="CEntiteOrganisationnelle">Entité organisationnelle</see> qui le concerne.
    /// </summary>
	[DynamicClass("Ticket / OE")]
	[Table(CRelationTicket_EOconcernees.c_nomTable, CRelationTicket_EOconcernees.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CRelationTicket_EOconcerneesServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationTicket_EOconcernees : CObjetDonneeAIdNumeriqueAuto
                                
	{
		public const string c_nomTable = "TICKET_OE";
        public const string c_champId = "TKT_OE_ID";

		/// /////////////////////////////////////////////
		public CRelationTicket_EOconcernees( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CRelationTicket_EOconcernees(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Relation Ticket / Concerned O.Es|30074");
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


            
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'entité organisationnelle objet de la relation.<br/>
        /// (Relation obligatoire)
        /// </summary>
        [Relation(
            CEntiteOrganisationnelle.c_nomTable,
            CEntiteOrganisationnelle.c_champId,
            CEntiteOrganisationnelle.c_champId,
            true,
            false,
            false)]
        [DynamicField("Concerned organisational entity")]
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


    }
}
