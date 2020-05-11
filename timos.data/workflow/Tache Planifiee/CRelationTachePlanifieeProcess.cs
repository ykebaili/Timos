using System;
using System.IO;
using System.Data;

using sc2i.common;
using sc2i.data;
using timos.acteurs;
using sc2i.process;





namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre une <see cref="CTachePlanifiee">tâche planifiée</see> et un <see cref="CProcessInDb">process</see>.
	/// </summary>
	[Table(CRelationTachePlanifieeProcess.c_nomTable, CRelationTachePlanifieeProcess.c_champId, false )]
	[ObjetServeurURI("CRelationTachePlanifieeProcessServeur")]
	[DynamicClass("Planified task / process")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TachesPlanif_ID)]
    public class CRelationTachePlanifieeProcess : CObjetDonneeAIdNumeriqueAuto
	{
		public const string c_nomTable = "PLANIFIED_TASK_PROCESS";
		
		public const string c_champId = "PLTSKPROCESS_ID";

		//-------------------------------------------------------------------
		//Préferer la fonction AssocieDocument de CCategorieDocument
		public CRelationTachePlanifieeProcess( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//-------------------------------------------------------------------
		public CRelationTachePlanifieeProcess(DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation between planned task @1 and action @2|335",TachePlanifiee.Libelle,Process.Libelle);
			}
		}

		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
		}


		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Tâche planifiée, objet de la relation
        /// </summary>
		[Relation(CTachePlanifiee.c_nomTable,
			 CTachePlanifiee.c_champId,
			 CTachePlanifiee.c_champId,
			 true,
			 true,
			 false)]
		[DynamicField("Task")]
		public CTachePlanifiee TachePlanifiee
		{
			get
			{
				return (CTachePlanifiee)GetParent ( CTachePlanifiee.c_champId, typeof(CTachePlanifiee));
			}
			set
			{
				SetParent ( CTachePlanifiee.c_champId, value );
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Process, objet de la relation
        /// </summary>
		[Relation(CProcessInDb.c_nomTable,
			 CProcessInDb.c_champId,
			 CProcessInDb.c_champId,
			 true,
			 true,
			 false)]
		[DynamicField("Process")]
		public CProcessInDb Process
		{
			get
			{
				return (CProcessInDb)GetParent ( CProcessInDb.c_champId, typeof(CProcessInDb)); 
			}
			set
			{
				SetParent ( CProcessInDb.c_champId, value );
			}
		}

	}
}
