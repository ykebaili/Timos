using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.equipement.consommables
{
    /// <summary>
    /// Relation entre un <see cref="CTypeConsommable">Type d'équipement</see> et une 
    /// <see cref="CValeurChampCustom">Valeur de champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Consumable type / Custom field value")]
	[ObjetServeurURI("CRelationTypeConsommable_ChampCustomValeurServeur")]
	[Table(CRelationTypeConsommable_ChampCustomValeur.c_nomTable, CRelationTypeConsommable_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeConsommable_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "CONS_TYPE_CUSTFLD_VAL";
		public const string c_champId = "CONSTP_FLD_VAL_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeConsommable_ChampCustomValeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTypeConsommable);
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
		[Relation(CTypeConsommable.c_nomTable,CTypeConsommable.c_champId,CTypeConsommable.c_champId,true,true,true)]
		[
		DynamicField("Consumable type")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable));
			}
			set
			{
				SetParent ( CTypeConsommable.c_champId, (CTypeConsommable)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
