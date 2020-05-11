using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeRessource">Type de Ressource</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.	
	/// </summary>
    [DynamicClass("Resource type / Custom field")]
	[ObjetServeurURI("CRelationTypeRessource_ChampCustomServeur")]
	[Table(CRelationTypeRessource_ChampCustom.c_nomTable, CRelationTypeRessource_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Resource Type/Custom Field|145",
        CTypeRessource.c_champId,
        CChampCustom.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeRessource_ID)]
    public class CRelationTypeRessource_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "RES_TYPE_CUST_FIELD";
        public const string c_champId = "RES_TYPE_CUST_FIELD_ID";

		//-------------------------------------------------------------------
		public CRelationTypeRessource_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeRessource_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
            CTypeRessource.c_nomTable,
            CTypeRessource.c_champId,
            CTypeRessource.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeRessource.c_champId, typeof(CTypeRessource));
			}
			set
			{
                SetParent(CTypeRessource.c_champId, (CTypeRessource)value);
			}
		}
	}
}
