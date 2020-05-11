using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre une <see cref="CTableParametrable">Table paramétrable</see> et un 
    /// <see cref="CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Custom table / Custom field")]
	[ObjetServeurURI("CRelationTableParametrable_ChampCustomServeur")]
	[Table(CRelationTableParametrable_ChampCustom.c_nomTable, CRelationTableParametrable_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CRelationTableParametrable_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "CUSTOM_TABLE_CUSTOM_FIELD";
		public const string c_champId = "CUSTOM_TABLE_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTableParametrable_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTableParametrable_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTableParametrable_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CTableParametrable);
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
		[Relation(
			CTableParametrable.c_nomTable,
		   CTableParametrable.c_champId,
		   CTableParametrable.c_champId,
			true,
			true,
			true)]
		[DynamicField("Custom Table")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CTableParametrable.c_champId, typeof(CTableParametrable));
			}
			set
			{
				SetParent(CTableParametrable.c_champId, (CTableParametrable)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
