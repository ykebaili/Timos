using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CContrat">Contrat</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Constract / Custom field")]
	[ObjetServeurURI("CRelationContrat_ChampCustomServeur")]
	[Table(CRelationContrat_ChampCustom.c_nomTable, CRelationContrat_ChampCustom.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationContrat_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "CONTRACT_CUSTOM_FIELD";
		public const string c_champId = "CONT_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationContrat_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationContrat_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationContrat_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CContrat);
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
        /// Contrat, objet de la relation
        /// </summary>
		[Relation(
			CContrat.c_nomTable,
            CContrat.c_champId,
            CContrat.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Contrat")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CContrat.c_champId, typeof(CContrat));
			}
			set
			{
				SetParent(CContrat.c_champId, (CContrat)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
