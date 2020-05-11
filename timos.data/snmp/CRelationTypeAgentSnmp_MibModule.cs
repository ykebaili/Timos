using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos.data.snmp
{
	/// <summary>
	/// Relation entre un <see cref="CTypeAgentSnmp">Type d'agent SNMP</see> et un 
    /// <see cref="CSnmpMibModule">Module MIB</see>.
	/// </summary>
    [DynamicClass("Snmp Agent type / Snmp Mib")]
	[Table(CRelationTypeAgentSnmp_MibModule.c_nomTable, CRelationTypeAgentSnmp_MibModule.c_champId, true)]
	[ObjetServeurURI("CRelationTypeAgentSnmp_MibModuleServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CRelationTypeAgentSnmp_MibModule : CObjetDonneeAIdNumeriqueAuto
	{

		public const string c_nomTable = "SNMPTPAGT_MIB_MOD";
		public const string c_champId = "TPAGT_MIB_ID";

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeAgentSnmp_MibModule(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public CRelationTypeAgentSnmp_MibModule(DataRow row)
			: base(row)
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		//////////////////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Relation between agent type @1 and mib module @2", 
                    TypeAgent == null?"":TypeAgent.Libelle,
                    MibModule == null?"":MibModule.Libelle);
			}
		}

		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// Agent SNMP, objet de la relation
        /// </summary>
		[RelationAttribute(
		   CTypeAgentSnmp.c_nomTable,
           CTypeAgentSnmp.c_champId,
		   CTypeAgentSnmp.c_champId,
			true,
			true,
			false)]
		[DynamicField("Snmp agent type")]
		public CTypeAgentSnmp TypeAgent
		{
			get
			{
                return (CTypeAgentSnmp)GetParent(CTypeAgentSnmp.c_champId, typeof(CTypeAgentSnmp));
			}
			set
			{
                SetParent(CTypeAgentSnmp.c_champId, value);
			}
		}

		//----------------------------------------------------------
        /// <summary>
        /// Module MIB, objet de la relation
        /// </summary>
		[RelationAttribute(
		  CSnmpMibModule.c_nomTable,
         CSnmpMibModule.c_champId,
         CSnmpMibModule.c_champId,
			true,
			true)]
		[DynamicField("Mib module")]
		public CSnmpMibModule MibModule
		{
			get
			{
                return (CSnmpMibModule)GetParent(CSnmpMibModule.c_champId, typeof(CSnmpMibModule));
			}
			set
			{
                SetParent(CSnmpMibModule.c_champId, value);
			}
		}

	}
}
