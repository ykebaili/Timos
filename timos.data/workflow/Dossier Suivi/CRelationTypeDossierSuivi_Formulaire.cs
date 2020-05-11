using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre un <see cref="CTypeDossierSuivi">Type de dossier de suivi</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
	/// </summary>
    [DynamicClass("Workbook type / Custom form")]
	[ObjetServeurURI("CRelationTypeDossierSuivi_FormulaireServeur")]
	[Table(CRelationTypeDossierSuivi_Formulaire.c_nomTable, CRelationTypeDossierSuivi_Formulaire.c_champId,true)]
	[FullTableSync]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeDossier_ID)]
    public class CRelationTypeDossierSuivi_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "WORKBOOK_TYP_FORM";
		public const string c_champId = "WKBTPFORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeDossierSuivi_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeDossierSuivi_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeDossierSuivi_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		[Relation(CTypeDossierSuivi.c_nomTable,CTypeDossierSuivi.c_champId,CTypeDossierSuivi.c_champId,true,true)]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom) GetParent(CTypeDossierSuivi.c_champId, typeof(CTypeDossierSuivi));
			}
			set
			{
				this.SetParent(CTypeDossierSuivi.c_champId,(CTypeDossierSuivi)value);
			}
		}
	}
}
