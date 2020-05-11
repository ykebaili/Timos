using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CTypeEntreeAgenda">Type d'entrée à agenda</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Diary entry type / Custom form")]
	[ObjetServeurURI("CRelationTypeEntreeAgenda_FormulaireServeur")]
	[Table(CRelationTypeEntreeAgenda_Formulaire.c_nomTable, CRelationTypeEntreeAgenda_Formulaire.c_champId,true)]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEntreeAgenda_ID)]
    public class CRelationTypeEntreeAgenda_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "DIARY_TYPE_FORM";
		public const string c_champId = "DRYTPFRM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEntreeAgenda_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEntreeAgenda_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEntreeAgenda_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		[Relation(CTypeEntreeAgenda.c_nomTable,CTypeEntreeAgenda.c_champId,CTypeEntreeAgenda.c_champId,true,true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom) GetParent(CTypeEntreeAgenda.c_champId, typeof(CTypeEntreeAgenda));
			}
			set
			{
				this.SetParent(CTypeEntreeAgenda.c_champId,(CTypeEntreeAgenda)value);
			}
		}
	}
}
