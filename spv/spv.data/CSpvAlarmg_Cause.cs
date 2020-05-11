using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvAlarmg_Cause.c_nomTable,CSpvAlarmg_Cause.c_nomTableInDb,new string[]{ CSpvAlarmg_Cause.c_champALARMGEREE_ID,CSpvAlarmg_Cause.c_champCAUSEAL_ID})]
	[ObjetServeurURI("CSpvAlarmg_CauseServeur")]
	[DynamicClass("Alarm access extension cause")]
	public class CSpvAlarmg_Cause : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARMG_CAUSE";
		public const string c_nomTableInDb = "ALARMG_CAUSE";
        public const string c_champId = "ALARMG_CAUSE_ID";

		public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champCAUSEAL_ID ="CAUSEAL_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmg_Cause( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmg_Cause( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champALARMGEREE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm access extension cause @1|30011", SpvAlarmgeree.Alarmgeree_Name);
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvAlarmGeree.c_nomTable,
            new string[]{CSpvAlarmGeree.c_champALARMGEREE_ID},
            new string[]{CSpvAlarmg_Cause.c_champALARMGEREE_ID},
            true,
            true)]
        [DynamicField("Alarm access type extension")]
		public CSpvAlarmGeree SpvAlarmgeree
		{
			get
			{
				return (CSpvAlarmGeree) GetParent(new string[]{c_champALARMGEREE_ID},typeof(CSpvAlarmGeree));
			}
			set
			{
				SetParent(new string[]{c_champALARMGEREE_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(
            CSpvCauseAlarme.c_nomTable,
            new string[]{CSpvCauseAlarme.c_champCAUSEAL_ID}, 
            new string[]{CSpvAlarmg_Cause.c_champCAUSEAL_ID},
            true,
            false)]
        [DynamicField("Alarm access type extension cause")]
		public CSpvCauseAlarme Cause
		{
			get
			{
				return (CSpvCauseAlarme) GetParent(new string[]{c_champCAUSEAL_ID},typeof(CSpvCauseAlarme));
			}
			set
			{
				SetParent(new string[]{c_champCAUSEAL_ID}, value);
			}
		}
	}
}
