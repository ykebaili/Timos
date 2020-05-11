using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeTableParametrable">Type de table paramétrable</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Custom table type / Custom form")]
	[ObjetServeurURI("CRelationTypeTableParametrable_FormulaireServeur")]
	[Table(CRelationTypeTableParametrable_Formulaire.c_nomTable, CRelationTypeTableParametrable_Formulaire.c_champId, true)]
	[FullTableSync]
	[Unique(false,
		"Another association already exist for the relation Custom Table Type/Custom Form|522",
		CTypeTableParametrable.c_champId,
		CFormulaire.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypesTables_ID)]
    public class CRelationTypeTableParametrable_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "CUSTOM_TABLE_TYPE_FORM";
		public const string c_champId = "CUST_TBL_TP_FORM_ID";


		//-------------------------------------------------------------------
		public CRelationTypeTableParametrable_Formulaire(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeTableParametrable_Formulaire(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		[Relation(
			CTypeTableParametrable.c_nomTable,
		   CTypeTableParametrable.c_champId,
		   CTypeTableParametrable.c_champId,
			true,
			true,
			true)]
		[DynamicField("Custom table type")]
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
