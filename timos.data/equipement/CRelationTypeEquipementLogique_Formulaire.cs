using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeEquipementLogique">Type d'Equipement logique</see> et un 
	/// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
	/// </summary>
	[ObjetServeurURI("CRelationTypeEquipementLogique_FormulaireServeur")]
	[Table(CRelationTypeEquipementLogique_Formulaire.c_nomTable, CRelationTypeEquipementLogique_Formulaire.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeEquipementLogique_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "EQUIPT_LGC_TYPE_FORM";
		public const string c_champId = "EQTLFCTP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEquipementLogique_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(
			CTypeEquipementLogique.c_nomTable,
			CTypeEquipementLogique.c_champId,
			CTypeEquipementLogique.c_champId,
			true,
			true,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CTypeEquipementLogique.c_champId, typeof(CTypeEquipementLogique));
			}
			set
			{
				SetParent ( CTypeEquipementLogique.c_champId, (CTypeEquipementLogique)value );
			}
		}
	}
}
