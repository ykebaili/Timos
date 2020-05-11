using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeContrainte">Type de Contrainte</see> /
    /// et une <see cref="CChampCustom"> Valeur de Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Constraint type / Custom field value")]
    [ObjetServeurURI("CRelationTypeContrainte_ChampCustomValeurServeur")]
    [Table(CRelationTypeContrainte_ChampCustomValeur.c_nomTable, CRelationTypeContrainte_ChampCustomValeur.c_champId, true)]
    [FullTableSync]
    public class CRelationTypeContrainte_ChampCustomValeur : CRelationElementAChamp_ChampCustom
    {
        public const string c_nomTable = "CONST_TYPE_CUSTFIELD_VAL";
        public const string c_champId = "CONSTTP_CUSTFLD_VAL_ID";

        //-------------------------------------------------------------------
        public CRelationTypeContrainte_ChampCustomValeur(CContexteDonnee ctx)
            : base(ctx)
        {
        }

        //-------------------------------------------------------------------
        public CRelationTypeContrainte_ChampCustomValeur(System.Data.DataRow row)
            : base(row)
        {
        }

        //-------------------------------------------------------------------
        public override Type GetTypeElementAChamps()
        {
            return typeof(CTypeContrainte);
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
        /// Type de Contrainte objet de la relation
        /// </summary>
        [Relation(
            CTypeContrainte.c_nomTable,
            CTypeContrainte.c_champId,
            CTypeContrainte.c_champId,
            true,
            true,
            true)]
        [DynamicField("Constraint type")]
        public override IElementAChamps ElementAChamps
        {
            get
            {
                return (IElementAChamps)GetParent(CTypeContrainte.c_champId, typeof(CTypeContrainte));
            }
            set
            {
                SetParent(CTypeContrainte.c_champId, (CTypeContrainte)value);
            }
        }

    }
}
