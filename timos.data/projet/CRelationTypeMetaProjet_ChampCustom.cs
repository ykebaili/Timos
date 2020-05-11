using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.projet;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeMetaProjet">Type de meta-projet</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Meta Project type / Custom field")]
	[ObjetServeurURI("CRelationTypeMetaProjet_ChampCustomServeur")]
	[Table(CRelationTypeMetaProjet_ChampCustom.c_nomTable, CRelationTypeMetaProjet_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CRelationTypeMetaProjet_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "METAPRJ_TYPE_CUSTOM_FIELD";
		public const string c_champId = "METAPRJTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeMetaProjet_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeMetaProjet_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		[Relation(
			CTypeMetaProjet.c_nomTable,
		   CTypeMetaProjet.c_champId,
		   CTypeMetaProjet.c_champId,
			true,
			false,
			true)]
        [DynamicField("Meta Project type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom)GetParent(CTypeMetaProjet.c_champId, typeof(CTypeMetaProjet));
			}
			set
			{
				SetParent(CTypeMetaProjet.c_champId, (CTypeMetaProjet)value);
			}
		}
	}
}
