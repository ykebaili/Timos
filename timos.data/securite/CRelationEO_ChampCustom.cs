using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.securite
{
	/// <summary>
    /// Relation entre une <see cref="CEntiteOrganisationnelle">entité organisationnelle</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Organisational entity / Custom field")]
	[ObjetServeurURI("CRelationEO_ChampCustomServeur")]
	[Table(CRelationEO_ChampCustom.c_nomTable, CRelationEO_ChampCustom.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_EO_ID)]
    public class CRelationEO_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EO_CUSTOM_FIELD";
		public const string c_champId = "EO_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEO_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationEO_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CEntiteOrganisationnelle);
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
        /// Entité organisationnelle, objet de la relation
        /// </summary>
		[Relation(
			CEntiteOrganisationnelle.c_nomTable,
		   CEntiteOrganisationnelle.c_champId,
		   CEntiteOrganisationnelle.c_champId, 
			true, 
			true, 
			true)]
		[
		DynamicField("Organisationnal entity")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CEntiteOrganisationnelle.c_champId, typeof(CEntiteOrganisationnelle));
			}
			set
			{
				SetParent(CEntiteOrganisationnelle.c_champId, (CEntiteOrganisationnelle)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
