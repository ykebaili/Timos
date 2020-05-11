using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre une <see cref="CFamilleEquipement">Famille d'équipement</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Equipment family / Custom form")]
	[ObjetServeurURI("CRelationFamilleEquipement_FormulaireServeur")]
	[Table(CRelationFamilleEquipement_Formulaire.c_nomTable, CRelationFamilleEquipement_Formulaire.c_champId,true)]
	[FullTableSync]
	
	public class CRelationFamilleEquipement_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "EQPT_FAM_FORM";
		public const string c_champId = "EQTFAM_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationFamilleEquipement_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationFamilleEquipement_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationFamilleEquipement_Formulaire(System.Data.DataRow row)
			:base(row)
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
                if (Formulaire != null)
                {
                    if (Formulaire.CodeRole == CTypeEquipement.c_roleChampCustom)
                        return famille.GetDefinisseurPourTypeEquipement();
                    if (Formulaire.CodeRole == timos.data.equipement.consommables.CTypeConsommable.c_roleChampCustom)
                        return famille.GetDefinisseurPourTypeConsommable();
                }
                return null;
            }
            set
            {
                if (value is timos.data.equipement.CDefinisseurChampsFamilleEquipement)
                    SetParent(CFamilleEquipement.c_champId, ((timos.data.equipement.CDefinisseurChampsFamilleEquipement)value).Famille);
            }
        }
	}
}
