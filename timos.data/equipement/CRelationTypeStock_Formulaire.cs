using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeStock">Type de stock</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Stock type / Custom form")]
	[ObjetServeurURI("CRelationTypeStock_FormulaireServeur")]
	[Table(CRelationTypeStock_Formulaire.c_nomTable, CRelationTypeStock_Formulaire.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CRelationTypeStock_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "STOCK_TYPE_FORM";
		public const string c_champId = "STOCK_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeStock_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeStock_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		[Relation(
            CTypeStock.c_nomTable,
            CTypeStock.c_champId,
            CTypeStock.c_champId,
            true,
            true,
            true)]
        [DynamicField("Stock type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeStock.c_champId, typeof(CTypeStock));
			}
			set
			{
                SetParent(CTypeStock.c_champId, (CTypeStock)value);
			}
		}
	}
}
