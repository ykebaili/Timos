using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeProjet">Type de projet</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Project type / Custom form")]
	[ObjetServeurURI("CRelationTypeProjet_FormulaireServeur")]
	[Table(CRelationTypeProjet_Formulaire.c_nomTable, CRelationTypeProjet_Formulaire.c_champId, true)]
	[FullTableSync]
	[Unique(false,
		"Another association already exist for the relation Project Type/Custom Form|463",
		CTypeProjet.c_champId,
		CFormulaire.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CRelationTypeProjet_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "PRJ_TYPE_FORM";
		public const string c_champId = "PRJ_TYPE_FORM_ID";


		//-------------------------------------------------------------------
		public CRelationTypeProjet_Formulaire(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeProjet_Formulaire(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type de projet objet de la relation
        /// </summary>
		[Relation(
			CTypeProjet.c_nomTable,
		   CTypeProjet.c_champId,
		   CTypeProjet.c_champId,
			true,
			true,
			true)]
		[DynamicField("Project type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom)GetParent(CTypeProjet.c_champId, typeof(CTypeProjet));
			}
			set
			{
				SetParent(CTypeProjet.c_champId, (CTypeProjet)value);
			}
		}
	}
}
