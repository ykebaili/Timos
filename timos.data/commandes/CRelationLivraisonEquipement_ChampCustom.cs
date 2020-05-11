using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre une <see cref="CLivraisonEquipement">Livraison équipement</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Equipment delivery / Custom field")]
	[ObjetServeurURI("CRelationLivraisonEquipement_ChampCustomServeur")]
	[Table(CRelationLivraisonEquipement_ChampCustom.c_nomTable, CRelationLivraisonEquipement_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationLivraisonEquipement_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "DELIV_CUSTOM_FIELD";
		public const string c_champId = "DELIV_FLT_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationFonctionEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationLivraisonEquipement_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationLivraisonEquipement_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CLivraisonEquipement);
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
        /// <see cref="CLivraisonEquipement">Livraison équipement</see> correspondante
        /// </summary>
		[Relation(CLivraisonEquipement.c_nomTable,CLivraisonEquipement.c_champId,CLivraisonEquipement.c_champId,true,true,true)]
		[DynamicField("Delivery")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CLivraisonEquipement.c_champId, typeof(CLivraisonEquipement));
			}
			set
			{
				SetParent ( CLivraisonEquipement.c_champId, (CLivraisonEquipement)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
