using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre un <see cref="CTypeCommande">Type de commande</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Order type / Custom field")]
	[ObjetServeurURI("CRelationTypeCommande_ChampCustomServeur")]
	[Table(CRelationTypeCommande_ChampCustom.c_nomTable, CRelationTypeCommande_ChampCustom.c_champId, true)]
	[FullTableSync]
    public class CRelationTypeCommande_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "ORDER_TYPE_CUSTOM_FIELD";
		public const string c_champId = "ORDTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeCommande_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeCommande_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
            CTypeCommande.c_nomTable,
            CTypeCommande.c_champId,
            CTypeCommande.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeCommande.c_champId, typeof(CTypeCommande));
			}
			set
			{
                SetParent(CTypeCommande.c_champId, (CTypeCommande)value);
			}
		}
	}
}
