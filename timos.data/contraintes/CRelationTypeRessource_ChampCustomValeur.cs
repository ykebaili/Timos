using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeRessource">Type de Ressource</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Resource type / Custom field value")]
    [ObjetServeurURI("CRelationTypeRessource_ChampCustomValeurServeur")]
    [Table(CRelationTypeRessource_ChampCustomValeur.c_nomTable, CRelationTypeRessource_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeRessource_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "RESRC_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "RESRCTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeRessource_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeRessource_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeRessource);
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
        /// Type de Ressource objet de la relation
        /// </summary>
        [Relation(
            CTypeRessource.c_nomTable,
            CTypeRessource.c_champId,
            CTypeRessource.c_champId,
            true,
            true,
            true)]
        [DynamicField("Resource type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeRessource.c_champId, typeof(CTypeRessource));
            }
            set
            {
                SetParent(CTypeRessource.c_champId, (CTypeRessource)value);
            }
        }

    }
}
