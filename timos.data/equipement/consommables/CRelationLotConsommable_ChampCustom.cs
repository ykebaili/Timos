using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.equipement.consommables
{
	/// <summary>
	/// Relation entre un <see cref="CLotConsommable">Lot de consommable</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ Custom</see>.
	/// </summary>
    [DynamicClass("Consumable lot / Custom field")]
	[ObjetServeurURI("CRelationLotConsommable_ChampCustomServeur")]
	[Table(CRelationLotConsommable_ChampCustom.c_nomTable, CRelationLotConsommable_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationLotConsommable_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "CONS_LOT_CUSTOM_FIELD";
		public const string c_champId = "CONSLOT_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationLotConsommable_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationLotConsommable_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationLotConsommable_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CLotConsommable);
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
        /// Lot de consommable concerné par la relation
        /// </summary>
		[Relation(CLotConsommable.c_nomTable,CLotConsommable.c_champId,CLotConsommable.c_champId,true,true,true)]
		[DynamicField("Consumable lot")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CLotConsommable.c_champId, typeof(CLotConsommable));
			}
			set
			{
				SetParent ( CLotConsommable.c_champId, (CLotConsommable)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
