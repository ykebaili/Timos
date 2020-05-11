using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CIntervention">Intervention</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Intervention / Custom field")]
	[ObjetServeurURI("CRelationIntervention_ChampCustomServeur")]
	[Table(CRelationIntervention_ChampCustom.c_nomTable, CRelationIntervention_ChampCustom.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationIntervention_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "INTER_CUSTOM_FIELD";
		public const string c_champId = "INTERFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationIntervention_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationIntervention_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationIntervention_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CIntervention);
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
        /// Intervention, objet de la relation
        /// </summary>
		[Relation(
			CIntervention.c_nomTable,
            CIntervention.c_champId,
            CIntervention.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Intervention")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CIntervention.c_champId, typeof(CIntervention));
			}
			set
			{
				SetParent(CIntervention.c_champId, (CIntervention)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
