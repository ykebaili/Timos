using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeTableParametrable">Type de table paramétrable</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Custom table type / Custom field")]
	[ObjetServeurURI("CRelationTypeTableParametrable_ChampCustomServeur")]
	[Table(CRelationTypeTableParametrable_ChampCustom.c_nomTable, CRelationTypeTableParametrable_ChampCustom.c_champId, true)]
	[FullTableSync]
	[Unique(false,
		"Another association already exist for the relation Custom Table Type/Custom Field|521",
	   CTypeTableParametrable.c_champId,
		CChampCustom.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypesTables_ID)]
    public class CRelationTypeTableParametrable_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "CUSTOM_TBLTP_CUSTOM_FIELD";
		public const string c_champId = "TPTBL_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeTableParametrable_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeTableParametrable_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		[Relation(
			CTypeTableParametrable.c_nomTable,
		   CTypeTableParametrable.c_champId,
		   CTypeTableParametrable.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom)GetParent(CTypeTableParametrable.c_champId, typeof(CTypeTableParametrable));
			}
			set
			{
				SetParent(CTypeTableParametrable.c_champId, (CTypeTableParametrable)value);
			}
		}
	}
}
