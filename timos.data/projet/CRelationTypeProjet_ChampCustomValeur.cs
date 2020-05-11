using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeProjet">Type de Projet</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Project type / Custom field value")]
    [ObjetServeurURI("CRelationTypeProjet_ChampCustomValeurServeur")]
    [Table(CRelationTypeProjet_ChampCustomValeur.c_nomTable, CRelationTypeProjet_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CRelationTypeProjet_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "PRJ_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "PRJTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeProjet_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeProjet_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeProjet);
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
        /// Type de projet objet de la relation
        /// </summary>
        [Relation(
            CTypeProjet.c_nomTable,
            CTypeProjet.c_champId,
            CTypeProjet.c_champId,
            true,
            true,
            true)]
        [DynamicField("Project type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
            }
            set
            {
                SetParent(CTypeProjet.c_champId, (CTypeProjet)value);
            }
        }

    }
}
