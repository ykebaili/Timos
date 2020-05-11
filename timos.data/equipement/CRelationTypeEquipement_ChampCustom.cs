using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.equipement;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeEquipement">Type d'équipement</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Equipment type / Custom field")]
	[ObjetServeurURI("CRelationTypeEquipement_ChampCustomServeur")]
	[Table(CRelationTypeEquipement_ChampCustom.c_nomTable, CRelationTypeEquipement_ChampCustom.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeEquipement_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "EQPTTP_CUSTFIELD";
		public const string c_champId = "EQPTTP_FLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}
		
		[Relation(
			CTypeEquipement.c_nomTable,
			CTypeEquipement.c_champId,
			CTypeEquipement.c_champId,
			true,
			false,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				CTypeEquipement typeEquipement = GetParent ( CTypeEquipement.c_champId, typeof(CTypeEquipement)) as CTypeEquipement;
				if (ChampCustom != null)
				{
					if (ChampCustom.CodeRole == CEquipement.c_roleChampCustom)
						return typeEquipement.GetDefinisseurPourEquipementPhysique();
					if (ChampCustom.CodeRole == CEquipementLogique.c_roleChampCustom)
						return typeEquipement.GetDefinisseurPourEquipementLogique();
				}
				return null;
			}
			set
			{
				if ( value is CDefinisseurChampsTypeEquipement )
					SetParent ( CTypeEquipement.c_champId, ((CDefinisseurChampsTypeEquipement)value).TypeEquipement );
			}
		}
	}
}
