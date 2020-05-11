using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.equipement.consommables;
using timos.data.equipement;

namespace timos.data
{
    /// <summary>
    /// Relation entre une <see cref="CFamilleEquipement">Famille d'équipement</see> et un
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Equipment family / Custom field")]
    [ObjetServeurURI("CRelationFamilleEquipement_ChampCustomServeur")]
    [Table(CRelationFamilleEquipement_ChampCustom.c_nomTable, CRelationFamilleEquipement_ChampCustom.c_champId, true)]
    [FullTableSync]

    public class CRelationFamilleEquipement_ChampCustom : CRelationDefinisseurChamp_ChampCustom
    {
        public const string c_nomTable = "EQPT_FAM_CUSTOM_FIELD";
        public const string c_champId = "EQTFAM_FLD_ID";

        //-------------------------------------------------------------------
#if PDA
		public CRelationFamilleEquipement_ChampCustom()
			:base()
		{
		}
#endif
        //-------------------------------------------------------------------
        public CRelationFamilleEquipement_ChampCustom(CContexteDonnee ctx)
            : base(ctx)
        {
        }
        //-------------------------------------------------------------------
        public CRelationFamilleEquipement_ChampCustom(System.Data.DataRow row)
            : base(row)
        {
        }

        [Relation(
            CFamilleEquipement.c_nomTable,
            CFamilleEquipement.c_champId,
            CFamilleEquipement.c_champId,
            true,
            false,
            true)]
        public override IDefinisseurChampCustom Definisseur
        {
            get
            {
                CFamilleEquipement famille = GetParent(CFamilleEquipement.c_champId, typeof(CFamilleEquipement)) as CFamilleEquipement;
                if (ChampCustom != null)
                {
                    if (ChampCustom.CodeRole == CTypeEquipement.c_roleChampCustom)
                        return famille.GetDefinisseurPourTypeEquipement();
                    if (ChampCustom.CodeRole == CTypeConsommable.c_roleChampCustom)
                        return famille.GetDefinisseurPourTypeConsommable();
                }
                return null;
            }
            set
            {
                if (value is CDefinisseurChampsFamilleEquipement)
                    SetParent(CFamilleEquipement.c_champId, ((CDefinisseurChampsFamilleEquipement)value).Famille);
            }
        }
    }
}
