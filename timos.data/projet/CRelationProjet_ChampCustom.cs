using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CProjet">Projet</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Project / Custom field")]
	[ObjetServeurURI("CRelationProjet_ChampCustomServeur")]
	[Table(CRelationProjet_ChampCustom.c_nomTable, CRelationProjet_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    public class CRelationProjet_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "PRJ_CUSTOM_FIELD";
		public const string c_champId = "PRJ_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationProjet_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationProjet_ChampCustom(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationProjet_ChampCustom(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CProjet);
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
			CProjet.c_nomTable,
		   CProjet.c_champId,
		   CProjet.c_champId,
			true,
			true,
			true)]
		[DynamicField("Project")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CProjet.c_champId, typeof(CProjet));
			}
			set
			{
				SetParent(CProjet.c_champId, (CProjet)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
