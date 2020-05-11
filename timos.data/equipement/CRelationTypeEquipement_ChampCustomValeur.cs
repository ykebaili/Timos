using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeEquipement">Type d'équipement</see> et une 
    /// <see cref="CValeurChampCustom">Valeur de champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Equipment type / Custom field value")]
	[ObjetServeurURI("CRelationTypeEquipement_ChampCustomValeurServeur")]
	[Table(CRelationTypeEquipement_ChampCustomValeur.c_nomTable, CRelationTypeEquipement_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeEquipement_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EQPT_TYPE_CUSTFLD_VAL";
		public const string c_champId = "EQTTP_FLD_VAL_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTypeEquipement);
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
		[Relation(CTypeEquipement.c_nomTable,CTypeEquipement.c_champId,CTypeEquipement.c_champId,true,true,true)]
		[
		DynamicField("Equipment type")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
			}
			set
			{
				SetParent ( CTypeEquipement.c_champId, (CTypeEquipement)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
