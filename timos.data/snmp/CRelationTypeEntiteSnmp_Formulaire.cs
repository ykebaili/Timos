using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.snmp
{
    /// <summary>
    /// Relation entre un <see cref="CTypeEntiteSnmp">Type d'entité SNMP</see> et un 
    /// <see cref="sc2i.data.dynamic.CFormulaire">Formulaire personnalisé</see>.
    /// </summary>
    [DynamicClass("Snmp entity type / Custom form")]
	[ObjetServeurURI("CRelationTypeEntiteSnmp_FormulaireServeur")]
	[Table(CRelationTypeEntiteSnmp_Formulaire.c_nomTable, CRelationTypeEntiteSnmp_Formulaire.c_champId,true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CRelationTypeEntiteSnmp_Formulaire : CRelationDefinisseurChamp_Formulaire
	{
		public const string c_nomTable = "SNMPETT_TYPE_FORM";
		public const string c_champId = "SNMPETT_TYPE_FORM_ID";
		
        
		//-------------------------------------------------------------------
		public CRelationTypeEntiteSnmp_Formulaire(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEntiteSnmp_Formulaire(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Entité SNMP, objet de la relation
        /// </summary>
		[Relation(
            CTypeEntiteSnmp.c_nomTable,
            CTypeEntiteSnmp.c_champId,
            CTypeEntiteSnmp.c_champId,
            true,
            true,
            true)]
        [DynamicField("Entity type")]
		public override IDefinisseurChampCustom Definisseur
		{
			get
			{
                return (IDefinisseurChampCustom)GetParent(CTypeEntiteSnmp.c_champId, typeof(CTypeEntiteSnmp));
			}
			set
			{
                SetParent(CTypeEntiteSnmp.c_champId, (CTypeEntiteSnmp)value);
			}
		}
	}
}
