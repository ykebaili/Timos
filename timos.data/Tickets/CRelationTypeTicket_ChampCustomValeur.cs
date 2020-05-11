using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeTicket">Type de Ticket</see><br/>
	/// et une <see cref="CChampCustomValeur"> Valeur de Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Ticket type / Custom field value")]
	[ObjetServeurURI("CRelationTypeTicket_ChampCustomValeurServeur")]
	[Table(CRelationTypeTicket_ChampCustomValeur.c_nomTable, CRelationTypeTicket_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationTypeTicket_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "TICKET_TYPE_CUSTFIELD_VAL";
		public const string c_champId = "TKTTP_CUSTFLD_VAL_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeTicket_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeTicket_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeTicket_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTypeTicket);
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
        /// Type de ticket objet de la relation
        /// </summary>
		[Relation(
			CTypeTicket.c_nomTable,
            CTypeTicket.c_champId,
            CTypeTicket.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("TypeTicket")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CTypeTicket.c_champId, typeof(CTypeTicket));
			}
			set
			{
				SetParent(CTypeTicket.c_champId, (CTypeTicket)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
