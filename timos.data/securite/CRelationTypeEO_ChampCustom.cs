using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.securite
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntiteOrganisationnelle">Type d'entité organisationnelle</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Organisational entity type / Custom field")]
	[ObjetServeurURI("CRelationTypeEO_ChampCustomServeur")]
	[Table(CRelationTypeEO_ChampCustom.c_nomTable, CRelationTypeEO_ChampCustom.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEO_ID)]
    public class CRelationTypeEO_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "OE_TYPE_CUSTOM_FIELD";
		public const string c_champId = "OETP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEO_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEO_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
            CTypeEntiteOrganisationnelle.c_nomTable,
           CTypeEntiteOrganisationnelle.c_champId,
           CTypeEntiteOrganisationnelle.c_champId, 
            true, 
            false, 
            true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle));
			}
			set
			{
                SetParent(CTypeEntiteOrganisationnelle.c_champId, (CTypeEntiteOrganisationnelle)value);
			}
		}
	}
}
