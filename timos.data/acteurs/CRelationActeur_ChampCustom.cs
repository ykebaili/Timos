using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.acteurs
{
	/// <summary>
	/// Relation entre un <see cref="CActeur">Acteur</see> et un 
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Custom field relation")]
	[ObjetServeurURI("CRelationActeur_ChampCustomServeur")]
	[Table(CRelationActeur_ChampCustom.c_nomTable, CRelationActeur_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationActeur_ChampCustom : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "MEMBER_CUSTOM_FIELD";
        public const string c_champId = "MEMBER_CUSTOM_FIELD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationActeur_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationActeur_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationActeur_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CActeur);
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
        /// Acteur en relation avec ce champ personnalisé
        /// </summary>
		[Relation(CActeur.c_nomTable,CActeur.c_champId,CActeur.c_champId,true,true,true)]
		[DynamicField("Member")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return ( IElementAChamps )GetParent(CActeur.c_champId, typeof(CActeur));
			}
			set
			{
				SetParent ( CActeur.c_champId, (CActeur)value );
			}
		}

		//-------------------------------------------------------------------
	}
}
