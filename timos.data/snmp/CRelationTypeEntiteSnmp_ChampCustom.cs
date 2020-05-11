using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.snmp
{
    /// <summary>
    /// Relation entre un <see cref="CTypeEntiteSnmp">Type d'entité SNMP</see> et un 
    /// <see cref="sc2i.data.dynamic.CChampCustom">Champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Snmp entity type / Custom field")]
	[ObjetServeurURI("CRelationTypeEntiteSnmp_ChampCustomServeur")]
	[Table(CRelationTypeEntiteSnmp_ChampCustom.c_nomTable, CRelationTypeEntiteSnmp_ChampCustom.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CRelationTypeEntiteSnmp_ChampCustom : CRelationDefinisseurChamp_ChampCustom
	{
		public const string c_nomTable = "SNMP_ETT_TP_CUST_FLD";
		public const string c_champId = "SNMPETTTP_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypeEntiteSnmp_ChampCustom(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypeEntiteSnmp_ChampCustom(System.Data.DataRow row)
			:base(row)
		{
		}

        //-------------------------------------------------------------------
		[Relation(
            CTypeEntiteSnmp.c_nomTable,
            CTypeEntiteSnmp.c_champId,
            CTypeEntiteSnmp.c_champId, 
            true, 
            false, 
            true)]
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
