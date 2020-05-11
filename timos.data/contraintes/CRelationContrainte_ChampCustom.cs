using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre une <see cref="CContrainte">Contrainte</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Constraint / Custom field")]
    [ObjetServeurURI("CRelationContrainte_ChampCustomServeur")]
    [Table(CRelationContrainte_ChampCustom.c_nomTable, CRelationContrainte_ChampCustom.c_champId, true)]
	[FullTableSync]
	public class CRelationContrainte_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "CONSTRAINT_CUSTOM_FIELD";
        public const string c_champId = "CONSTRAINTE_CUSTFIELD_ID";


        //-------------------------------------------------------------------
		public CRelationContrainte_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
        public CRelationContrainte_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
            return typeof(CContrainte);
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
        /// La contrainte objet de la relation
        /// </summary>
		[Relation(
			CContrainte.c_nomTable,
            CContrainte.c_champId,
            CContrainte.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Constraint")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
                return (IElementAChamps)GetParent(CContrainte.c_champId, typeof(CContrainte));
			}
			set
			{
                SetParent(CContrainte.c_champId, (CContrainte)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
