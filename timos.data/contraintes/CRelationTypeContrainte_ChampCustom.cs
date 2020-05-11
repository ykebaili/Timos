using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeContrainte">Type de Contrainte</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.	
	/// </summary>
    [DynamicClass("Constraint type / Custom field")]
	[ObjetServeurURI("CRelationTypeContrainte_ChampCustomServeur")]
	[Table(CRelationTypeContrainte_ChampCustom.c_nomTable, CRelationTypeContrainte_ChampCustom.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Constraint Type/Custom Field|143",
        CTypeContrainte.c_champId,
        CChampCustom.c_champId)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeContrainte_ID)]
    public class CRelationTypeContrainte_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "CONST_TYPE_CUST_FIELD";
        public const string c_champId = "CONST_TYPE_CUST_FIELD_ID";

		//-------------------------------------------------------------------
		public CRelationTypeContrainte_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeContrainte_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
            CTypeContrainte.c_nomTable,
            CTypeContrainte.c_champId,
            CTypeContrainte.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
			}
			set
			{
                SetParent(CTypeContrainte.c_champId, (CTypeContrainte)value);
			}
		}
	}
}
