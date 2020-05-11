using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
	/// <summary>
	/// Relation entre une <see cref="CRessourceMaterielle">Ressource</see> et une
	/// <see cref="sc2i.data.dynamic.CValeurChampCustom">Valeur de champ personnalisé</see>.	
	/// </summary>
    [DynamicClass("Resource / Custom field value")]
    [ObjetServeurURI("CRelationRessource_ChampCustomValeurServeur")]
    [Table(CRelationRessource_ChampCustomValeur.c_nomTable, CRelationRessource_ChampCustomValeur.c_champId, true)]
	[FullTableSync]
	public class CRelationRessource_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "RESOURCE_CUSTOM_FIELD";
        public const string c_champId = "RESOURCE_CUSTFIELD_ID";


        //-------------------------------------------------------------------
		public CRelationRessource_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
        public CRelationRessource_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
            return typeof(CRessourceMaterielle);
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
        /// Ressource, objet de la relation
        /// </summary>
		[Relation(
			CRessourceMaterielle.c_nomTable,
            CRessourceMaterielle.c_champId,
            CRessourceMaterielle.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Resource")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
                return (IElementAChamps)GetParent(CRessourceMaterielle.c_champId, typeof(CRessourceMaterielle));
			}
			set
			{
                SetParent(CRessourceMaterielle.c_champId, (CRessourceMaterielle)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
