using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.equipement;

namespace timos.data.equipement.consommables
{
	/// <summary>
	/// Relation entre un <see cref="CTypeConsommable">Type de consommable</see> et un 
	/// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
	/// </summary>
    [DynamicClass("Consumable type / Custom form")]
	[ObjetServeurURI("CRelationTypeConsommable_FormulaireServeur")]
	[Table(CRelationTypeConsommable_Formulaire.c_nomTable, CRelationTypeConsommable_Formulaire.c_champId,true)]
	[FullTableSync]
	public class CRelationTypeConsommable_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "CONSUMABLE_TYPE_FORM";
		public const string c_champId = "CONSTP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeConsommable_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeConsommable_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		[Relation(
			CTypeConsommable.c_nomTable,
			CTypeConsommable.c_champId,
			CTypeConsommable.c_champId,
			true,
			true,
			true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable)) as IDefinisseurChampCustom;
			}
			set
			{
                SetParent(CTypeConsommable.c_champId, value as CObjetDonnee);
			}
		}
	}
}
