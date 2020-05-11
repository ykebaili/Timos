using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.acteurs
{
	/// <summary>
	/// Relation entre un <see cref="CGroupeActeur">Groupe d'Acteur</see> et un
	/// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
	/// </summary>
    [DynamicClass("Member Group Custom field relation")]
	[ObjetServeurURI("CRelationGroupeActeur_ChampCustomServeur")]
	[Table(CRelationGroupeActeur_ChampCustom.c_nomTable, CRelationGroupeActeur_ChampCustom.c_champId,true)]
	[FullTableSync]
    public class CRelationGroupeActeur_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "MBER_GRP_CUST_FIELD";
		public const string c_champId = "MBER_GRP_CUSTFIELD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationGroupeActeur_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationGroupeActeur_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(CGroupeActeur.c_nomTable,CGroupeActeur.c_champId,CGroupeActeur.c_champId,true,false,true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CGroupeActeur.c_champId, typeof(CGroupeActeur));
			}
			set
			{
				SetParent ( CGroupeActeur.c_champId, (CGroupeActeur)value );
			}
		}
	}
}
