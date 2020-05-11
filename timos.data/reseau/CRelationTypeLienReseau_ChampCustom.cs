using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CTypeLienReseau">Type de lien réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Network link type / Custom field")]
    [ObjetServeurURI("CRelationTypeLienReseau_ChampCustomServeur")]
    [Table(CRelationTypeLienReseau_ChampCustom.c_nomTable, CRelationTypeLienReseau_ChampCustom.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Network Link Type/Custom Field",
       CTypeLienReseau.c_champId,
        CChampCustom.c_champId)]


    public class CRelationTypeLienReseau_ChampCustom :CRelationDefinisseurChamp_ChampCustom
    {
        public const string c_nomTable = "NTW_LNK_TYP_CUST_FIELD";
        public const string c_champId = "NLINKTP_CUSTFLD_ID";


        //-------------------------------------------------------------------
		public CRelationTypeLienReseau_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeLienReseau_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

        [Relation(
            CTypeLienReseau.c_nomTable,
            CTypeLienReseau.c_champId,
            CTypeLienReseau.c_champId,
            true,
            false,
            true)]
        public override IDefinisseurChampCustom Definisseur
        {
            get
            {
                return (IDefinisseurChampCustom)GetParent(CTypeLienReseau.c_champId, typeof(CTypeLienReseau));
            }
            set
            {
                SetParent(CTypeLienReseau.c_champId, (CTypeLienReseau)value);
            }

        }
    }
}
