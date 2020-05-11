using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre un <see cref="CTypeLivraisonEquipement">Type de livraison équipement</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Equipment delivery type / Custom field")]
	[ObjetServeurURI("CRelationTypeLivraisonEquipement_ChampCustomServeur")]
	[Table(CRelationTypeLivraisonEquipement_ChampCustom.c_nomTable, CRelationTypeLivraisonEquipement_ChampCustom.c_champId, true)]
	[FullTableSync]
    public class CRelationTypeLivraisonEquipement_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "DELIV_TYPE_CUSTOM_FIELD";
		public const string c_champId = "DELIVTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeLivraisonEquipement_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeLivraisonEquipement_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
            CTypeLivraisonEquipement.c_nomTable,
            CTypeLivraisonEquipement.c_champId,
            CTypeLivraisonEquipement.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeLivraisonEquipement.c_champId, typeof(CTypeLivraisonEquipement));
			}
			set
			{
                SetParent(CTypeLivraisonEquipement.c_champId, (CTypeLivraisonEquipement)value);
			}
		}
	}
}
