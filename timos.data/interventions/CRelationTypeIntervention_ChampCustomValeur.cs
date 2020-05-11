using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeIntervention">Type de Intervention</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Intervention type / Custom field value")]
    [ObjetServeurURI("CRelationTypeIntervention_ChampCustomValeurServeur")]
    [Table(CRelationTypeIntervention_ChampCustomValeur.c_nomTable, CRelationTypeIntervention_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeIntervention_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "INTERV_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "INTERVTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeIntervention_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeIntervention_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeIntervention);
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
        /// Type de Intervention objet de la relation
        /// </summary>
        [Relation(
            CTypeIntervention.c_nomTable,
            CTypeIntervention.c_champId,
            CTypeIntervention.c_champId,
            true,
            true,
            true)]
        [DynamicField("Intervention type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
            }
            set
            {
                SetParent(CTypeIntervention.c_champId, (CTypeIntervention)value);
            }
        }

    }
}
