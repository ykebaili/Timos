using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.commandes
{
	/// <summary>
    /// Relation entre un <see cref="CTypeCommande">Type de commande</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Order type / Custom form")]
	[ObjetServeurURI("CRelationTypeCommande_FormulaireServeur")]
	[Table(CRelationTypeCommande_Formulaire.c_nomTable, CRelationTypeCommande_Formulaire.c_champId,true)]
	[FullTableSync]
   
    public class CRelationTypeCommande_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "ORDER_TYPE_FORM";
		public const string c_champId = "ORDER_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeCommande_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeCommande_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// <see cref="CTypeCommande">Type de commande</see>
        /// </summary>
		[Relation(
            CTypeCommande.c_nomTable,
            CTypeCommande.c_champId,
            CTypeCommande.c_champId,
            true,
            true,
            true)]
        [DynamicField("Order type")]
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
