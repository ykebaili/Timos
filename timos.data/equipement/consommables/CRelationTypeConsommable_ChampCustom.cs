using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.equipement;

namespace timos.data.equipement.consommables
{
    /// <summary>
    /// Relation entre un <see cref="CTypeConsommable">Type de consommable</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Consumable type / Custom field")]
	[ObjetServeurURI("CRelationTypeConsommable_ChampCustomServeur")]
	[Table(CRelationTypeConsommable_ChampCustom.c_nomTable, CRelationTypeConsommable_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeConsommable_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "CONSTP_CUSTFIELD";
		public const string c_champId = "CONSTP_FLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeConsommable_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
			CTypeConsommable.c_nomTable,
			CTypeConsommable.c_champId,
			CTypeConsommable.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable)) as IDefinisseurChampCustom;
			}
			set
			{
					SetParent ( CTypeConsommable.c_champId, value as CObjetDonneeAIdNumerique);
			}
		}
	}
}
