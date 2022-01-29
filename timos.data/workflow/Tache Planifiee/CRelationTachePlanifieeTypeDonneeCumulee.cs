using System;
using System.IO;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;




namespace sc2i.workflow
{
	/// <summary>
    /// Relation entre une <see cref="CTachePlanifiee">tâche planifiée</see> et un <see cref="CTypeDonneeCumulee">type de données cumulées</see>.
	/// </summary>
	[Table(CRelationTachePlanifieeTypeDonneeCumulee.c_nomTable, CRelationTachePlanifieeTypeDonneeCumulee.c_champId, false )]
	[ObjetServeurURI("CRelationTachePlanifieeTypeDonneeCumuleeServeur")]
	[DynamicClass("Planified task / cumulated data")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TachesPlanif_ID)]
    public class CRelationTachePlanifieeTypeDonneeCumulee : CObjetDonneeAIdNumeriqueAuto
    {
		public const string c_nomTable = "PLANIFIED_TASK_PRECDAT";
		
		public const string c_champId = "PLTSKPRECDAT_ID";

		//-------------------------------------------------------------------
		//Préferer la fonction AssocieDocument de CCategorieDocument
		public CRelationTachePlanifieeTypeDonneeCumulee( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//-------------------------------------------------------------------
		public CRelationTachePlanifieeTypeDonneeCumulee(DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Relation between Planned task @1 and Data type @2|336",TachePlanifiee.Libelle,TypeDonneeCumulee.Libelle);
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
        /// Type de données cumulées, objet de la relation
        /// </summary>
		[Relation(CTypeDonneeCumulee.c_nomTable,
			 CTypeDonneeCumulee.c_champId,
			 CTypeDonneeCumulee.c_champId,
			 true,
			 true,
			 false)]
		[DynamicField("Cumulated data type")]
		public CTypeDonneeCumulee TypeDonneeCumulee
		{
			get
			{
				return (CTypeDonneeCumulee)GetParent ( CTypeDonneeCumulee.c_champId, typeof(CTypeDonneeCumulee)); 
			}
			set
			{
				SetParent ( CTypeDonneeCumulee.c_champId, value );
			}
		}

	}
}
