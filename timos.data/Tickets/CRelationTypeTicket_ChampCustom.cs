using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeTicket">Type de Ticket</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Ticket type / Custom field")]
	[ObjetServeurURI("CRelationTypeTicket_ChampCustomServeur")]
	[Table(CRelationTypeTicket_ChampCustom.c_nomTable, CRelationTypeTicket_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Ticket Type/Custom Field|225",
        CTypeTicket.c_champId,
        CChampCustom.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CRelationTypeTicket_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "TICKET_TYPE_CUSTOM_FIELD";
		public const string c_champId = "TKTTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeTicket_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeTicket_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
        /// <summary>
        /// Type de ticket objet de la relation
        /// </summary>
		[Relation(
            CTypeTicket.c_nomTable,
            CTypeTicket.c_champId,
            CTypeTicket.c_champId, 
            true, 
            false, 
            true)]
        [DynamicField("Ticket type")]
        public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeTicket.c_champId, typeof(CTypeTicket));
			}
			set
			{
                SetParent(CTypeTicket.c_champId, (CTypeTicket)value);
			}
		}
	}
}
