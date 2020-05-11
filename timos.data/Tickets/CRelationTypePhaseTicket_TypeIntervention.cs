using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data
{
    /// <summary>
    /// Relation entre un <see cref="CTypePhase">Type de Phase</see>  de Ticket<br/>
    /// et un <see cref="CTypeIntervention">Type d'Intervention</see> qui le concerne.
    /// </summary>
    [DynamicClass("Ticket phase type / Intervention type")]
	[ObjetServeurURI("CRelationTypePhaseTicket_TypeInterventionServeur")]
	[Table(CRelationTypePhaseTicket_TypeIntervention.c_nomTable, CRelationTypePhaseTicket_TypeIntervention.c_champId, true)]
	[FullTableSync]
    [Unique(false,
        "Another association already exist for the relation Type Phase Ticket/Type Intervention Field",
        CTypePhase.c_champId,
        CTypeIntervention.c_champId)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CRelationTypePhaseTicket_TypeIntervention : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "PHASETICKETTYP_INTERTYPE";
		public const string c_champId = "PHATKTTP_INTTP_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationTypeEO_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationTypePhaseTicket_TypeIntervention(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationTypePhaseTicket_TypeIntervention(System.Data.DataRow row)
			:base(row)
		{
		}
		//////////////////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		//////////////////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champId };
		}

		public override string DescriptionElement
		{
			get
			{
				return "";
			}
		}

		//---------------------------------------------------------------------------
        /// <summary>
        /// Type de phase, objet de la relation
        /// </summary>
		[RelationAttribute(
		   CTypePhase.c_nomTable,
		   CTypePhase.c_champId,
		   CTypePhase.c_champId,
			true,
			false,
			false)]
		[DynamicField("Phase type")]
		public CTypePhase TypePhase
		{
			get { return (CTypePhase)GetParent(CTypePhase.c_champId, typeof(CTypePhase)); }
			set { SetParent(CTypePhase.c_champId, value); }
		}


		//-------------------------------------------------------
        /// <summary>
        /// Type d'intervention objet de la relation
        /// </summary>
		[RelationAttribute(
		   CTypeIntervention.c_nomTable,
		   CTypeIntervention.c_champId,
		  CTypeIntervention.c_champId,
			true,
			false,
			false)]
		[DynamicField("Intervention type")]
		public CTypeIntervention TypeIntervention
		{
			get { return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention)); }
			set { SetParent(CTypeIntervention.c_champId, value); }
		}
	}
}
