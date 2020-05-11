using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="COperation">Operation</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Operation / Custom field")]
	[ObjetServeurURI("CRelationOperation_ChampCustomServeur")]
	[Table(CRelationOperation_ChampCustom.c_nomTable, CRelationOperation_ChampCustom.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationOperation_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "OPERATION_CUSTOM_FIELD";
		public const string c_champId = "OPCUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationOperation_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationOperation_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationOperation_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(COperation);
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
        /// Opération objet de la relation
        /// </summary>
		[Relation(
			COperation.c_nomTable,
            COperation.c_champId,
            COperation.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Operation")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(COperation.c_champId, typeof(COperation));
			}
			set
			{
				SetParent(COperation.c_champId, (COperation)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
