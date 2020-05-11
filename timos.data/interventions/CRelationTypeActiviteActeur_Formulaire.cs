using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeActiviteActeur">Type d'Activité d'Acteur</see> et un
	/// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
	/// </summary>
    [DynamicClass("Member activity type / Custom form")]
	[ObjetServeurURI("CRelationTypeActiviteActeur_FormulaireServeur")]
	[Table(CRelationTypeActiviteActeur_Formulaire.c_nomTable, CRelationTypeActiviteActeur_Formulaire.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_SuiviActivite_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeActivite_ID)]
    public class CRelationTypeActiviteActeur_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		#region Déclaration des constantes
		public const string c_nomTable = "ACTIVMBRTP_FORM";
		public const string c_champId = "ACTIVMBRTP_FORM_ID";
		#endregion
		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_Formulaire()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeActiviteActeur_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeActiviteActeur_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type d'activité d'acteur, objet de la relation
        /// </summary>
		[Relation(
            CTypeActiviteActeur.c_nomTable,
            CTypeActiviteActeur.c_champId,
            CTypeActiviteActeur.c_champId,
            true,
            true,
            true)]
        [DynamicField("Member activity type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeActiviteActeur.c_champId, typeof(CTypeActiviteActeur));
			}
			set
			{
                SetParent(CTypeActiviteActeur.c_champId, (CTypeActiviteActeur)value);
			}
		}
	}
}
