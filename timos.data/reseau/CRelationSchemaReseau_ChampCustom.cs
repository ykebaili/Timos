using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{

    /// <summary>
    /// Relation entre un <see cref="CSchemaReseau">Schéma réseau</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Network diagram / Custom field")]
    [ObjetServeurURI("CRelationSchemaReseau_ChampCustomServeur")]
    [Table(CRelationSchemaReseau_ChampCustom.c_nomTable, CRelationSchemaReseau_ChampCustom.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Liaisons_ID)]
    [FullTableSync]
    public class CRelationSchemaReseau_ChampCustom : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "NTW_DIAG_CUSTOM_FIELD";
        public const string c_champId = "NTWDIAG_CUSTFLD_ID";

        //-------------------------------------------------------------------
        public CRelationSchemaReseau_ChampCustom(CContexteDonnee ctx)
            : base(ctx)
        {
        }
        //-------------------------------------------------------------------
        public CRelationSchemaReseau_ChampCustom(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CSchemaReseau);
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
        /// <see cref="CSchemaReseau">Schéma réseau</see> objet de la relation
        /// </summary>
        [Relation(
            CSchemaReseau.c_nomTable,
            CSchemaReseau.c_champId,
            CSchemaReseau.c_champId,
            true,
            true,
            true)]
        [DynamicField("Network diagram")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CSchemaReseau.c_champId, typeof(CSchemaReseau));
            }
            set
            {
                SetParent(CSchemaReseau.c_champId, (CSchemaReseau)value);
            }
        }

        //-------------------------------------------------------------------
    }


}
