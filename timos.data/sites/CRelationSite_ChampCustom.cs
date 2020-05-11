using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CSite">Site</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Site relation with custom field")]
	[ObjetServeurURI("CRelationSite_ChampCustomServeur")]
	[Table(CRelationSite_ChampCustom.c_nomTable, CRelationSite_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationSite_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "SITE_CUSTOM_FIELD";
		public const string c_champId = "SITE_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationSite_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationSite_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationSite_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CSite);
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
        /// <see cref="CSite">Site</see> objet de la relation
        /// </summary>
		[Relation(
			CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Site")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CSite.c_champId, typeof(CSite));
			}
			set
			{
				SetParent(CSite.c_champId, (CSite)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
