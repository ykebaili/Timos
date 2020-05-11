using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre une <see cref="CEntreeAgenda">Entrée d'agenda</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Diary entry / Custom field")]
	[ObjetServeurURI("CRelationEntreeAgenda_ChampCustomServeur")]
	[Table(CRelationEntreeAgenda_ChampCustom.c_nomTable, CRelationEntreeAgenda_ChampCustom.c_champId,true)]
	
	public class CRelationEntreeAgenda_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		#region Déclaration des constantes
		public const string c_nomTable = "DIARY_ENTRY_CUST_FIELD";
		public const string c_champId = "DRYENTFLD_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationEntreeAgenda_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationEntreeAgenda_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}

		//-------------------------------------------------------------------
		public CRelationEntreeAgenda_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CEntreeAgenda);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Entrée d'agenda, objet de la relation
        /// </summary>
		[Relation(CEntreeAgenda.c_nomTable,CEntreeAgenda.c_champId,CEntreeAgenda.c_champId,true,true)]
		[
		DynamicField("Diary entry")
		]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps) GetParent(CEntreeAgenda.c_champId, typeof(CEntreeAgenda));
			}
			set
			{
				this.SetParent(CEntreeAgenda.c_champId, (CEntreeAgenda)value);
			}
		}
	}
}
