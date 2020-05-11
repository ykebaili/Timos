using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.securite
{
	/// <summary>
    /// Relation entre une <see cref="CRelationElement_EO">'relation avec un élément TIMOS et une EO'</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Organisational entity / element / Custom field")]
	[ObjetServeurURI("CRelationElementAEO_ChampCustomServeur")]
	[Table(CRelationElementAEO_ChampCustom.c_nomTable, CRelationElementAEO_ChampCustom.c_champId,true)]
	[FullTableSync]
    public class CRelationElementAEO_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "EO_ELT_CUSTOM_FIELD";
		public const string c_champId = "EO_ELT_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationElementAEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationElementAEO_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationElementAEO_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CRelationElement_EO);
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
        /// Relation 'élément TIMOS et une EO', objet de la relation
        /// </summary>
		[Relation(
			CRelationElement_EO.c_nomTable,
		    CRelationElement_EO.c_champId,
		    CRelationElement_EO.c_champId, 
			true, 
			true, 
			true)]
		[
		DynamicField("Organisationnal entity link")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CRelationElement_EO.c_champId, typeof(CRelationElement_EO));
			}
			set
			{
				SetParent(CRelationElement_EO.c_champId, (CRelationElement_EO)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
