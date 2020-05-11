using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeIntervention">Type d'Intervention</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Intervention type / Custom field")]
	[ObjetServeurURI("CRelationTypeIntervention_ChampCustomServeur")]
	[Table(CRelationTypeIntervention_ChampCustom.c_nomTable, CRelationTypeIntervention_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    public class CRelationTypeIntervention_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "INTERTYPE_CUSTOM_FIELD";
		public const string c_champId = "INTERTYPE_FLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
        //---------------------------------------------------------------------
        /// <summary>
        /// Type d'intervention, objet de la relation
        /// </summary>
		[Relation(
            CTypeIntervention.c_nomTable,
            CTypeIntervention.c_champId,
            CTypeIntervention.c_champId, 
            true, 
            false, 
            true)]
        [DynamicField("Intervention type")]
        public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
                SetParent(CTypeIntervention.c_champId, (CTypeIntervention)value);
			}
		}
	}
}
