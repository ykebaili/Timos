using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Description résumée de CRelationFamillEquipementLogique_ChampCustom.
	/// </summary>
	[ObjetServeurURI("CRelationFamilleEquipementLogique_ChampCustomServeur")]
	[Table(CRelationFamillEquipementLogique_ChampCustom.c_nomTable, CRelationFamillEquipementLogique_ChampCustom.c_champId,true)]
	[FullTableSync]
	
	public class CRelationFamillEquipementLogique_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "EQPT_LGC_FAM_CUST_FLD";
		public const string c_champId = "EQTLGCFAM_FLD_ID";


		//-------------------------------------------------------------------
		public CRelationFamillEquipementLogique_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationFamillEquipementLogique_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
			CFamilleEquipementLogique.c_nomTable,
			CFamilleEquipementLogique.c_champId,
			CFamilleEquipementLogique.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CFamilleEquipementLogique.c_champId, typeof(CFamilleEquipementLogique));
			}
			set
			{
				SetParent ( CFamilleEquipementLogique.c_champId, (CFamilleEquipementLogique)value );
			}
		}
	}
}
