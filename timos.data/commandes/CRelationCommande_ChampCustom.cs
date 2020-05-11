using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre une <see cref="CCommande">Commande</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Order / Custom field")]
	[ObjetServeurURI("CRelationCommande_ChampCustomServeur")]
	[Table(CRelationCommande_ChampCustom.c_nomTable, CRelationCommande_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationCommande_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "ORDER_CUSTOM_FIELD";
		public const string c_champId = "ORDER_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationFonctionEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationCommande_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationCommande_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CCommande);
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
        /// <see cref="CCommande">Commande</see> correspondante
        /// </summary>
		[Relation(CCommande.c_nomTable,CCommande.c_champId,CCommande.c_champId,true,true,true)]
		[DynamicField("Order")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CCommande.c_champId, typeof(CCommande));
			}
			set
			{
				SetParent ( CCommande.c_champId, (CCommande)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
