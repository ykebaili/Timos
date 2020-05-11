using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeStock">Type de stock</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Stock type / Custom field")]
	[ObjetServeurURI("CRelationTypeStock_ChampCustomServeur")]
	[Table(CRelationTypeStock_ChampCustom.c_nomTable, CRelationTypeStock_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public class CRelationTypeStock_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "STOCK_TYPE_CUSTOM_FIELD";
		public const string c_champId = "STOCKTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeStock_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeStock_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		

        //--------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
		[Relation(
            CTypeStock.c_nomTable,
            CTypeStock.c_champId,
            CTypeStock.c_champId, 
            true, 
            false, 
            true)]
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
