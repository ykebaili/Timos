using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.equipement;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipement">Type d'Equipement</see> et un 
	/// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
	/// </summary>
    [DynamicClass("Equipment type / Custom form")]
	[ObjetServeurURI("CRelationTypeEquipement_FormulaireServeur")]
	[Table(CRelationTypeEquipement_Formulaire.c_nomTable, CRelationTypeEquipement_Formulaire.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeEquipement_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "EQUIPMENT_TYPE_FORM";
		public const string c_champId = "EQTTP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEquipement_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipement_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(
			CTypeEquipement.c_nomTable,
			CTypeEquipement.c_champId,
			CTypeEquipement.c_champId,
			true,
			true,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				CTypeEquipement typeEquipement = GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement)) as CTypeEquipement;
				if (this.Formulaire != null)
				{
					if (Formulaire.CodeRole == CEquipement.c_roleChampCustom)
						return typeEquipement.GetDefinisseurPourEquipementPhysique();
					if (Formulaire.CodeRole == CEquipementLogique.c_roleChampCustom)
						return typeEquipement.GetDefinisseurPourEquipementLogique();
				}
				return null;
			}
			set
			{
				if (value is CDefinisseurChampsTypeEquipement)
					SetParent(CTypeEquipement.c_champId, ((CDefinisseurChampsTypeEquipement)value).TypeEquipement);
			}
		}

        //----------------------------------------------------------------------
        [DynamicField("Equipment type")]
        public CTypeEquipement EquipmentType
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }
        }
	}
}
