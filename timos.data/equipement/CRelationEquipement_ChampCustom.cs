using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CEquipement">Equipement</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ Custom</see>.
	/// </summary>
    [DynamicClass("Equipment / Custom field")]
	[ObjetServeurURI("CRelationEquipement_ChampCustomServeur")]
	[Table(CRelationEquipement_ChampCustom.c_nomTable, CRelationEquipement_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationEquipement_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EQUIPEMENT_CUSTOM_FIELD";
		public const string c_champId = "EQT_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEquipement_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationEquipement_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CEquipement);
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
        /// Equipement concerné par la relation
        /// </summary>
		[Relation(CEquipement.c_nomTable,CEquipement.c_champId,CEquipement.c_champId,true,true,true)]
		[DynamicField("Equipment")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CEquipement.c_champId, typeof(CEquipement));
			}
			set
			{
				SetParent ( CEquipement.c_champId, (CEquipement)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
