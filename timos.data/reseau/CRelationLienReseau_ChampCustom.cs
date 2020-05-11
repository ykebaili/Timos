using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CLienReseau">Lien réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Network link / Custom field")]
    [ObjetServeurURI("CRelationLienReseau_ChampCustomServeur")]
    [Table(CRelationLienReseau_ChampCustom.c_nomTable, CRelationLienReseau_ChampCustom.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    public class CRelationLienReseau_ChampCustom : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "NETW_LNK_CUSTOM_FIELD";
        public const string c_champId = "NETWLNK_CUSTFLD_ID";

        //-------------------------------------------------------------------
		public CRelationLienReseau_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationLienReseau_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CLienReseau);
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
        /// <see cref="CLienReseau">Lien réseau</see> objet de la relation
        /// </summary>
		[Relation(
			CLienReseau.c_nomTable,
            CLienReseau.c_champId,
            CLienReseau.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Network link")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CLienReseau.c_champId, typeof(CLienReseau));
			}
			set
			{
				SetParent(CLienReseau.c_champId, (CLienReseau)value);
			}
		}

		//-------------------------------------------------------------------
	}

    
}
