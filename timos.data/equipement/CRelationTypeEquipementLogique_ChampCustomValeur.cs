using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipementLogique_ChampCustomValeur.
	/// </summary>
	[ObjetServeurURI("CRelationTypeEquipementLogique_ChampCustomValeurServeur")]
	[Table(CRelationTypeEquipementLogique_ChampCustomValeur.c_nomTable, CRelationTypeEquipementLogique_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeEquipementLogique_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EQP_TYPLGC_CUSTFLD_VAL";
		public const string c_champId = "EQTLGCTP_FLD_VAL_ID";

		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTypeEquipementLogique);
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
		[Relation(CTypeEquipementLogique.c_nomTable,CTypeEquipementLogique.c_champId,CTypeEquipementLogique.c_champId,true,true,true)]
		[
		DynamicField("Equipment type")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CTypeEquipementLogique.c_champId, typeof(CTypeEquipementLogique));
			}
			set
			{
				SetParent ( CTypeEquipementLogique.c_champId, (CTypeEquipementLogique)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
