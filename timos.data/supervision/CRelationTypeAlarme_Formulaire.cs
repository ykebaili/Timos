using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.supervision
{
    /// <summary>
    /// Relation entre un <see cref="CTypeAlarme">Type d'Alarme</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire</see>
    /// </summary>
    [DynamicClass("Alarm type / Custom form")]
	[ObjetServeurURI("CRelationTypeAlarme_FormulaireServeur")]
	[Table(CRelationTypeAlarme_Formulaire.c_nomTable, CRelationTypeAlarme_Formulaire.c_champId,true)]
    [Unique(false,
        "Another association already exist for the relation Site Type/Custom Form|148",
        CTypeAlarme.c_champId,
        CFormulaire.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSupervision)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSupervision_ID)]
    public class CRelationTypeAlarme_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "ALRM_TYPE_FORM";
		public const string c_champId = "ALRM_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeAlarme_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Type d'Alarme, objet de la relation
        /// </summary>
		[Relation(
            CTypeAlarme.c_nomTable,
            CTypeAlarme.c_champId,
            CTypeAlarme.c_champId,
            true,
            true,
            true)]
        [DynamicField("Alarm type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeAlarme.c_champId, typeof(CTypeAlarme));
			}
			set
			{
                SetParent(CTypeAlarme.c_champId, (CTypeAlarme)value);
			}
		}
	}
}
