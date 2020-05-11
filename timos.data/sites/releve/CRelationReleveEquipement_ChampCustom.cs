using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CReleveEquipement">Equipement</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ Custom</see>.
	/// </summary>
    [DynamicClass("Equipment survey/ Custom field")]
	[ObjetServeurURI("CRelationReleveEquipement_ChampCustomServeur")]
	[Table(CRelationReleveEquipement_ChampCustom.c_nomTable, CRelationReleveEquipement_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationReleveEquipement_ChampCustom : CRelationElementAChamp_ChampCustom,
        IObjetSansVersion
	{
		public const string c_nomTable = "EQPT_SURV_CUSTOM_FIELD";
		public const string c_champId = "EQTSRV_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationReleveEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationReleveEquipement_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationReleveEquipement_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CReleveEquipement);
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
		[Relation(CReleveEquipement.c_nomTable,CReleveEquipement.c_champId,CReleveEquipement.c_champId,true,true,true)]
		[DynamicField("Equipment survey")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CReleveEquipement.c_champId, typeof(CReleveEquipement));
			}
			set
			{
				SetParent ( CReleveEquipement.c_champId, (CReleveEquipement)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
