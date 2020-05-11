using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre un <see cref="CTypeLivraisonEquipement">Type de livraison équipement</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Equipment delivery type / Custom form")]
	[ObjetServeurURI("CRelationTypeLivraisonEquipement_FormulaireServeur")]
	[Table(CRelationTypeLivraisonEquipement_Formulaire.c_nomTable, CRelationTypeLivraisonEquipement_Formulaire.c_champId,true)]
	[FullTableSync]
   
    public class CRelationTypeLivraisonEquipement_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "DELIV_TYPE_FORM";
		public const string c_champId = "DELIV_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeLivraisonEquipement_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeLivraisonEquipement_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// <see cref="Dynamic">Type de livraison équipement</see>
        /// </summary>
		[Relation(
            CTypeLivraisonEquipement.c_nomTable,
            CTypeLivraisonEquipement.c_champId,
            CTypeLivraisonEquipement.c_champId,
            true,
            true,
            true)]
        [DynamicField("Delivery type")]
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
