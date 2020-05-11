using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeSite">Type de Site</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Site type / Custom field value")]
    [ObjetServeurURI("CRelationTypeSite_ChampCustomValeurServeur")]
    [Table(CRelationTypeSite_ChampCustomValeur.c_nomTable, CRelationTypeSite_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeSite_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "SITE_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "SITETP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeSite_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeSite_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeSite);
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
        /// Type de Site objet de la relation
        /// </summary>
        [Relation(
            CTypeSite.c_nomTable,
            CTypeSite.c_champId,
            CTypeSite.c_champId,
            true,
            true,
            true)]
        [DynamicField("Site type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeSite.c_champId, typeof(CTypeSite));
            }
            set
            {
                SetParent(CTypeSite.c_champId, (CTypeSite)value);
            }
        }

    }
}
