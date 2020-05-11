using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeTableParametrable">Type de Table Parametrable</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Custom Table Type / Custom field value")]
    [ObjetServeurURI("CRelationTypeTableParametrable_ChampCustomValeurServeur")]
    [Table(CRelationTypeTableParametrable_ChampCustomValeur.c_nomTable, CRelationTypeTableParametrable_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeTableParametrable_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "CUST_TBLTP_CUSTFLD_VAL";
        public const string c_champId = "CUSTTBLTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeTableParametrable_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeTableParametrable_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeTableParametrable);
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
        /// Type de TableParametrable objet de la relation
        /// </summary>
        [Relation(
            CTypeTableParametrable.c_nomTable,
            CTypeTableParametrable.c_champId,
            CTypeTableParametrable.c_champId,
            true,
            true,
            true)]
        [DynamicField("Custom Table Type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeTableParametrable.c_champId, typeof(CTypeTableParametrable));
            }
            set
            {
                SetParent(CTypeTableParametrable.c_champId, (CTypeTableParametrable)value);
            }
        }

    }
}
