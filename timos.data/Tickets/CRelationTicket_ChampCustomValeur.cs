using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTicket">Ticket</see> /
	/// et une <see cref="CChampCustomValeur">Valeur de Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Ticket / Custom field value")]
	[ObjetServeurURI("CRelationTicket_ChampCustomValeurServeur")]
	[Table(CRelationTicket_ChampCustomValeur.c_nomTable, CRelationTicket_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationTicket_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "TICKET_CUSTOMFIELD";
		public const string c_champId = "TKT_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTicket_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTicket_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTicket_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTicket);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Ticket objet de la relation
        /// </summary>
		[Relation(
			CTicket.c_nomTable,
            CTicket.c_champId,
            CTicket.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Ticket")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CTicket.c_champId, typeof(CTicket));
			}
			set
			{
				SetParent(CTicket.c_champId, (CTicket)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
