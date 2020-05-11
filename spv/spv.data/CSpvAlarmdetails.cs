using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvAlarmdetails.c_nomTable,CSpvAlarmdetails.c_nomTableInDb,new string[]{ CSpvAlarmdetails.c_champALARMDETAILS_ENTERPRISE,CSpvAlarmdetails.c_champALARMDETAILS_ID1,CSpvAlarmdetails.c_champALARMDETAILS_ID2})]
	[ObjetServeurURI("CSpvAlarmdetailsServeur")]
	[DynamicClass("Alarm details")]
	public class	CSpvAlarmdetails : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARMDETAILS";
		public const string c_nomTableInDb = "ALARMDETAILS";
		public const string c_champALARMDETAILS_ENTERPRISE ="ALARMDETAILS_ENTERPRISE";
		public const string c_champALARMDETAILS_ID1 ="ALARMDETAILS_ID1";
		public const string c_champALARMDETAILS_ID2 ="ALARMDETAILS_ID2";
		public const string c_champALARMDETAILS_MESSAGE ="ALARMDETAILS_MESSAGE";
		public const string c_champALARMDETAILS_CAUSE ="ALARMDETAILS_CAUSE";
		public const string c_champALARMDETAILS_ACTION ="ALARMDETAILS_ACTION";
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmdetails( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmdetails( DataRow row )
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
			return new string[] {c_champALARMDETAILS_ENTERPRISE};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm details |30010");
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_ENTERPRISE)]
		[DynamicField("Enterprise")]
		public System.Double ALARMDETAILS_ENTERPRISE
		{
			get
			{
				return (System.Double)Row[c_champALARMDETAILS_ENTERPRISE];
			}
			set
			{
				Row[c_champALARMDETAILS_ENTERPRISE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_ID1)]
		[DynamicField("Alarm details ID 1")]
		public System.Double ALARMDETAILS_ID1
		{
			get
			{
				return (System.Double)Row[c_champALARMDETAILS_ID1];
			}
			set
			{
				Row[c_champALARMDETAILS_ID1,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_ID2)]
		[DynamicField("Alarme details ID 2")]
		public System.Double ALARMDETAILS_ID2
		{
			get
			{
				return (System.Double)Row[c_champALARMDETAILS_ID2];
			}
			set
			{
				Row[c_champALARMDETAILS_ID2,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_MESSAGE,256)]
		[DynamicField("Message")]
		public System.String ALARMDETAILS_MESSAGE
		{
			get
			{
				return (System.String)Row[c_champALARMDETAILS_MESSAGE];
			}
			set
			{
				Row[c_champALARMDETAILS_MESSAGE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_CAUSE,4000)]
		[DynamicField("Cause")]
		public System.String ALARMDETAILS_CAUSE
		{
			get
			{
				if (Row[c_champALARMDETAILS_CAUSE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMDETAILS_CAUSE];
			}
			set
			{
				Row[c_champALARMDETAILS_CAUSE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMDETAILS_ACTION,4000)]
		[DynamicField("Action")]
		public System.String ALARMDETAILS_ACTION
		{
			get
			{
				if (Row[c_champALARMDETAILS_ACTION] == DBNull.Value)
					return null;
				return (System.String)Row[c_champALARMDETAILS_ACTION];
			}
			set
			{
				Row[c_champALARMDETAILS_ACTION,true]=value;
			}
		}
	}
}
