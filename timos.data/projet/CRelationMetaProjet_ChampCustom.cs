using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.projet;


namespace timos.data.projet
{
    /// <summary>
    /// Relation entre un <see cref="CMetaProjet">Projet</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Meta Project / Custom field")]
	[ObjetServeurURI("CRelationMetaProjet_ChampCustomServeur")]
	[Table(CRelationMetaProjet_ChampCustom.c_nomTable, CRelationMetaProjet_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    public class CRelationMetaProjet_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "METAPRJ_CUSTOM_FIELD";
		public const string c_champId = "METAPRJ_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationMetaProjet_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationMetaProjet_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationMetaProjet_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CMetaProjet);
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
        /// Projet objet de la relation
        /// </summary>
		[Relation(
			CMetaProjet.c_nomTable,
		   CMetaProjet.c_champId,
		   CMetaProjet.c_champId,
			true,
			true,
			true)]
		[DynamicField("Project")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CMetaProjet.c_champId, typeof(CMetaProjet));
			}
			set
			{
				SetParent(CMetaProjet.c_champId, (CMetaProjet)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
