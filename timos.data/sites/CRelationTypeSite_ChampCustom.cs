using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeSite">Type de Site</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Site type / Custom field")]
	[ObjetServeurURI("CRelationTypeSite_ChampCustomServeur")]
	[Table(CRelationTypeSite_ChampCustom.c_nomTable, CRelationTypeSite_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Site Type/Custom Field|147",
        CTypeSite.c_champId,
        CChampCustom.c_champId)]
    public class CRelationTypeSite_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "SITE_TYPE_CUSTOM_FIELD";
		public const string c_champId = "SITTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeSite_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeSite_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

        /// <summary>
        /// <see cref="CTypeSite">Type de Site</see> objet de la relation
        /// </summary>
        [DynamicField("Site Type")]
		[Relation(
            CTypeSite.c_nomTable,
            CTypeSite.c_champId,
            CTypeSite.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
			}
			set
			{
                SetParent(CTypeSite.c_champId, (CTypeSite)value);
			}
		}
	}
}
