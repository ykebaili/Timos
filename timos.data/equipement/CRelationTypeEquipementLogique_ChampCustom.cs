using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationTypeEquipementLogique_ChampCustom.
	/// </summary>
	[ObjetServeurURI("CRelationTypeEquipementLogique_ChampCustomServeur")]
	[Table(CRelationTypeEquipementLogique_ChampCustom.c_nomTable, CRelationTypeEquipementLogique_ChampCustom.c_champId,true)]
	[FullTableSync]
	
	public class CRelationTypeEquipementLogique_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "EQPLGCTTP_CUSTFIELD";
		public const string c_champId = "EQPLGCTTP_FLD_ID";

		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
			CTypeEquipementLogique.c_nomTable,
			CTypeEquipementLogique.c_champId,
			CTypeEquipementLogique.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CTypeEquipementLogique.c_champId, typeof(CTypeEquipementLogique));
			}
			set
			{
				SetParent ( CTypeEquipementLogique.c_champId, (CTypeEquipementLogique)value );
			}
		}
	}
}
