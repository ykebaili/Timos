using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// 
	/// </summary>
	[ObjetServeurURI("CRelationFamilleEquipementLogique_FormulaireServeur")]
	[Table(CRelationFamilleEquipementLogique_Formulaire.c_nomTable, CRelationFamilleEquipementLogique_Formulaire.c_champId,true)]
	[FullTableSync]
	
	public class CRelationFamilleEquipementLogique_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "EQPT_FAM_LGC_FORM";
		public const string c_champId = "EQTLGCFAM_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
		//-------------------------------------------------------------------
		public CRelationFamilleEquipementLogique_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationFamilleEquipementLogique_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(
			CFamilleEquipementLogique.c_nomTable,
			CFamilleEquipementLogique.c_champId,
			CFamilleEquipementLogique.c_champId,
			true,
			true,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return ( IDefinisseurChampCustom )GetParent ( CFamilleEquipementLogique.c_champId, typeof(CFamilleEquipementLogique));
			}
			set
			{
				SetParent ( CFamilleEquipementLogique.c_champId, (CFamilleEquipementLogique)value );
			}
		}
	}
}
