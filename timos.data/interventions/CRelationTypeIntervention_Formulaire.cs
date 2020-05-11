using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeIntervention">Type d'Intervention</see> et un
	/// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
	/// </summary>
    [DynamicClass("Intervention type / Custom form")]
	[ObjetServeurURI("CRelationTypeIntervention_FormulaireServeur")]
	[Table(CRelationTypeIntervention_Formulaire.c_nomTable, CRelationTypeIntervention_Formulaire.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    public class CRelationTypeIntervention_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "INTER_TYPE_FORM";
		public const string c_champId = "INTER_TYPE_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeIntervention_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type d'intervention, objet de la relation
        /// </summary>
		[Relation(
            CTypeIntervention.c_nomTable,
            CTypeIntervention.c_champId,
            CTypeIntervention.c_champId,
            true,
            true,
            true)]
        [DynamicField("Intervention type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
                SetParent(CTypeIntervention.c_champId, (CTypeIntervention)value);
			}
		}
	}
}
