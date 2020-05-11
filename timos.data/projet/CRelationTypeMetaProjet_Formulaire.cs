using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;
using timos.data.projet;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypeMetaProjet">Type de meta-projet</see> et un
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Meta Project type / Custom form")]
	[ObjetServeurURI("CRelationTypeMetaProjet_FormulaireServeur")]
	[Table(CRelationTypeMetaProjet_Formulaire.c_nomTable, CRelationTypeMetaProjet_Formulaire.c_champId, true)]
	[FullTableSync]
	[Unique(false,
		"Another association already exist for the relation Project Type/Custom Form|463",
		CTypeMetaProjet.c_champId,
		CFormulaire.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    public class CRelationTypeMetaProjet_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "METAPRJ_TYPE_FORM";
		public const string c_champId = "METAPRJTP_FORM_ID";


		//-------------------------------------------------------------------
		public CRelationTypeMetaProjet_Formulaire(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeMetaProjet_Formulaire(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type de projet objet de la relation
        /// </summary>
		[Relation(
			CTypeMetaProjet.c_nomTable,
		   CTypeMetaProjet.c_champId,
		   CTypeMetaProjet.c_champId,
			true,
			true,
			true)]
		[DynamicField("Meta Project type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
				return (IDefinisseurChampCustom)GetParent(CTypeMetaProjet.c_champId, typeof(CTypeMetaProjet));
			}
			set
			{
				SetParent(CTypeMetaProjet.c_champId, (CTypeMetaProjet)value);
			}
		}
	}
}
