using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CTypeSchemaReseau">Type de schéma réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Network diagram type/ Custom field")]
    [ObjetServeurURI("CRelationTypeSchemaReseau_ChampCustomServeur")]
    [Table(CRelationTypeSchemaReseau_ChampCustom.c_nomTable, CRelationTypeSchemaReseau_ChampCustom.c_champId, true)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_Liaisons_ID)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Network Diagram Type/Custom Field",
       CTypeSchemaReseau.c_champId,
        CChampCustom.c_champId)]


    public class CRelationTypeSchemaReseau_ChampCustom : CRelationDefinisseurChamp_ChampCustom
    {
        public const string c_nomTable = "NTW_DIAG_TYP_CUST_FIELD";
        public const string c_champId = "NDIAGTP_CUSTFLD_ID";


        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_ChampCustom(CContexteDonnee ctx)
            : base(ctx)
        {
        }
        //-------------------------------------------------------------------
        public CRelationTypeSchemaReseau_ChampCustom(System.Data.DataRow row)
            : base(row)
        {
        }

        [Relation(
            CTypeSchemaReseau.c_nomTable,
            CTypeSchemaReseau.c_champId,
            CTypeSchemaReseau.c_champId,
            true,
            false,
            true)]
        public override IDefinisseurChampCustom Definisseur
        {
            get
            {
                return (IDefinisseurChampCustom)GetParent(CTypeSchemaReseau.c_champId, typeof(CTypeSchemaReseau));
            }
            set
            {
                SetParent(CTypeSchemaReseau.c_champId, (CTypeSchemaReseau)value);
            }

        }
    }
}
