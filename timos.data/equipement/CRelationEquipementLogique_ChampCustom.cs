using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CEquipementLogique">Equipement logique</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Logical equipment / Custom field")]
	[ObjetServeurURI("CRelationEquipementLogique_ChampCustomServeur")]
	[Table(CRelationEquipementLogique_ChampCustom.c_nomTable, CRelationEquipementLogique_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationEquipementLogique_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EQUIPT_LGC_CUSTOM_FIELD";
		public const string c_champId = "EQTLGC_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationFonctionEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEquipementLogique_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationEquipementLogique_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CEquipementLogique);
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
        /// Equipement logique concerné par la relation
        /// </summary>
		[Relation(CEquipementLogique.c_nomTable,CEquipementLogique.c_champId,CEquipementLogique.c_champId,true,true,true)]
		[DynamicField("Equipment")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CEquipementLogique.c_champId, typeof(CEquipementLogique));
			}
			set
			{
				SetParent ( CEquipementLogique.c_champId, (CEquipementLogique)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
