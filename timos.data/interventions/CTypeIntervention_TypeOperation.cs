using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

namespace timos.data
{
	/// <summary>
	/// Relation entre un <see cref="CTypeIntervention">Type d'Intervention</see> et un
	/// <see cref="CTypeOperation">Type d'Opération</see>
	/// </summary>
	[DynamicClass("Intervention type / operation type")]
	[Table(CTypeIntervention_TypeOperation.c_nomTable, CTypeIntervention_TypeOperation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeIntervention_TypeOperationServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    public class CTypeIntervention_TypeOperation : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "INTER_TYPE_OP_TYPE";
		

		public const string c_champId = "INTTP_OPTP_ID";
		public const string c_champOptionnel = "INTTP_OPTP_OPTIONAL";
		public const string c_champIndex = "INTTP_OPTP_INDEX";

		/// /////////////////////////////////////////////
		public CTypeIntervention_TypeOperation( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeIntervention_TypeOperation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Task type/Operation type|136");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Optionnel = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champIndex};
		}

		/// /////////////////////////////////////////////
		/// <summary>
		/// Si VRAI, indique que la relation est optionnelle
		/// </summary>
		[TableFieldProperty(c_champOptionnel)]
		[DynamicField("Optionnal")]
		public bool Optionnel
		{
			get
			{
				return (bool)Row[c_champOptionnel];
			}
			set
			{
				Row[c_champOptionnel] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Numéro du type d'opération dans toute la liste liée au type d'intervention
		/// </summary>
		[TableFieldProperty(c_champIndex)]
		[DynamicField("Index")]
		public int Index
		{
			get
			{
				return (int)Row[c_champIndex];
			}
			set
			{
				Row[c_champIndex] = value;
			}
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
			false)]
		[DynamicField("Intervention type")]
		public CTypeIntervention TypeIntervention
		{
			get
			{
				return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
				SetParent(CTypeIntervention.c_champId, value);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Type d'opération, objet de la relation
		/// </summary>
		[Relation(
			CTypeOperation.c_nomTable,
			CTypeOperation.c_champId,
			CTypeOperation.c_champId,
			true,
			false,
			false)]
		[DynamicField("Operation type")]
		public CTypeOperation TypeOperation
		{
			get
			{
				return (CTypeOperation)GetParent(CTypeOperation.c_champId, typeof(CTypeOperation));
			}
			set
			{
				SetParent(CTypeOperation.c_champId, value);
			}
		}


	}
}
