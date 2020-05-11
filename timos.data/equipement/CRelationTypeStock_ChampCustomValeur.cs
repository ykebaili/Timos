using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeStock">Type de Stock</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Stock type / Custom field value")]
    [ObjetServeurURI("CRelationTypeStock_ChampCustomValeurServeur")]
    [Table(CRelationTypeStock_ChampCustomValeur.c_nomTable, CRelationTypeStock_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeStock_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "STOCK_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "STOCKTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeStock_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeStock_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeStock);
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
        /// Type de Stock objet de la relation
        /// </summary>
        [Relation(
            CTypeStock.c_nomTable,
            CTypeStock.c_champId,
            CTypeStock.c_champId,
            true,
            true,
            true)]
        [DynamicField("Stock type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeStock.c_champId, typeof(CTypeStock));
            }
            set
            {
                SetParent(CTypeStock.c_champId, (CTypeStock)value);
            }
        }

    }
}
