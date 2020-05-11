using System;

using sc2i.data;
using sc2i.common;
using sc2i.data.dynamic;


namespace timos.data
{
    /// <summary>
    /// Relation entre une <see cref="CPhaseTicket">Phase</see> de ticket et une 
    /// <see cref="sc2i.data.dynamic.CValeurChampCustom">Valeur de champ personnalisé</see>.
    /// </summary>
    [DynamicClass("Phase / Custom field value")]
	[ObjetServeurURI("CRelationPhase_ChampCustomValeurServeur")]
	[Table(CRelationPhase_ChampCustomValeur.c_nomTable, CRelationPhase_ChampCustomValeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CRelationPhase_ChampCustomValeur : CRelationElementAChamp_ChampCustom
	{
		public const string c_nomTable = "TICKETPHASE_CUSTOMFIELD";
		public const string c_champId = "TKTPH_CUSTFLD_ID";

		//-------------------------------------------------------------------
#if PDA
		public CRelationPhase_ChampCustom()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CRelationPhase_ChampCustomValeur(CContexteDonnee ctx)
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CRelationPhase_ChampCustomValeur(System.Data.DataRow row)
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override Type GetTypeElementAChamps()
		{
			return typeof(CPhaseTicket);
		}

		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Phase, objet de la relation
        /// </summary>
		[Relation(
			CPhaseTicket.c_nomTable,
            CPhaseTicket.c_champId,
            CPhaseTicket.c_champId, 
			true, 
			true, 
			true)]
		[DynamicField("Phase")]
		public override IElementAChamps ElementAChamps
		{
			get
			{
				return (IElementAChamps)GetParent(CPhaseTicket.c_champId, typeof(CPhaseTicket));
			}
			set
			{
				SetParent(CPhaseTicket.c_champId, (CPhaseTicket)value);
			}
		}

		//-------------------------------------------------------------------
	}
}
