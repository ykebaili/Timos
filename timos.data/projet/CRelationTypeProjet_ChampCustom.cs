using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeProjet">Type de Projet</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Project type / Custom field")]
	[ObjetServeurURI("CRelationTypeProjet_ChampCustomServeur")]
	[Table(CRelationTypeProjet_ChampCustom.c_nomTable, CRelationTypeProjet_ChampCustom.c_champId, true)]
	[FullTableSync]
	[Unique(false,
		"Another association already exist for the relation Project Type/Custom Field|463",
	    CTypeProjet.c_champId,
		CChampCustom.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CRelationTypeProjet_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "PRJ_TYPE_CUSTOM_FIELD";
		public const string c_champId = "PRJTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeProjet_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeProjet_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		[Relation(
			CTypeProjet.c_nomTable,
		   CTypeProjet.c_champId,
		   CTypeProjet.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
			}
			set
			{
				SetParent(CTypeProjet.c_champId, (CTypeProjet)value);
			}
		}
	}
}
