using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CStock">Stock</see> et une 
    /// <see cref="CValeurChampCustom">Valeur de champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Stock / Custom field value")]
	[ObjetServeurURI("CRelationStock_ChampCustomValeurServeur")]
	[Table(CRelationStock_ChampCustomValeur.c_nomTable, CRelationStock_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
	public class CRelationStock_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "STOCK_CUSTOM_FIELD";
		public const string c_champId = "STOCK_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationStock_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationStock_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationStock_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CStock);
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
		[Relation(
			CStock.c_nomTable,
            CStock.c_champId,
            CStock.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Stock")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CStock.c_champId, typeof(CStock));
			}
			set
			{
				SetParent(CStock.c_champId, (CStock)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
