using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvTypeq_Alarm.c_nomTable,CSpvTypeq_Alarm.c_nomTableInDb,new string[]{ CSpvTypeq_Alarm.c_champTYPEQ_ALARM_ID})]
	[ObjetServeurURI("CSpvTypeq_AlarmServeur")]
	[DynamicClass("SpvTypeq_Alarm")]
	public class	CSpvTypeq_Alarm : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQ_ALARM";
		public const string c_nomTableInDb = "TYPEQ_ALARM";
		public const string c_champTYPEQ_ALARM_ID ="TYPEQ_ALARM_ID";
		public const string c_champTYPEQ_ALARM_CIAL ="TYPEQ_ALARM_CIAL";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champTYPEQ_ALARM_TABLENAME ="TYPEQ_ALARM_TABLENAME";
		public const string c_champTYPEQ_ALARM_GRAVENAME ="TYPEQ_ALARM_GRAVENAME";
		public const string c_champTYPEQ_ALARM_GRAVETYPE ="TYPEQ_ALARM_GRAVETYPE";
		public const string c_champTYPEQ_ALARM_IDENTNAME ="TYPEQ_ALARM_IDENTNAME";
		public const string c_champTYPEQ_ALARM_IDENTTYPE ="TYPEQ_ALARM_IDENTTYPE";
		public const string c_champTYPEQ_ALARM_P1 ="TYPEQ_ALARM_P1";
		public const string c_champTYPEQ_ALARM_P2 ="TYPEQ_ALARM_P2";
		public const string c_champTYPEQ_ALARM_P3 ="TYPEQ_ALARM_P3";
		public const string c_champTYPEQ_ALARM_P4 ="TYPEQ_ALARM_P4";
		public const string c_champTYPEQ_ALARM_P5 ="TYPEQ_ALARM_P5";
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Alarm( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Alarm( DataRow row )
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
			return new string[] {c_champTYPEQ_ALARM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return "l'élement de type "+GetType().ToString();
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_ID)]
		[DynamicField("TYPEQ_ALARM_ID")]
		public System.Int32 TYPEQ_ALARM_ID
		{
			get
			{
				return (System.Int32)Row[c_champTYPEQ_ALARM_ID];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_CIAL,80)]
		[DynamicField("TYPEQ_ALARM_CIAL")]
		public System.String TYPEQ_ALARM_CIAL
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_CIAL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_CIAL];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_CIAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ID)]
		[DynamicField("TYPEQ_ID")]
		public System.Int32 TYPEQ_ID
		{
			get
			{
				return (System.Int32)Row[c_champTYPEQ_ID];
			}
			set
			{
				Row[c_champTYPEQ_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_TABLENAME,128)]
		[DynamicField("TYPEQ_ALARM_TABLENAME")]
		public System.String TYPEQ_ALARM_TABLENAME
		{
			get
			{
				return (System.String)Row[c_champTYPEQ_ALARM_TABLENAME];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_TABLENAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_GRAVENAME,128)]
		[DynamicField("TYPEQ_ALARM_GRAVENAME")]
		public System.String TYPEQ_ALARM_GRAVENAME
		{
			get
			{
				return (System.String)Row[c_champTYPEQ_ALARM_GRAVENAME];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_GRAVENAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_GRAVETYPE)]
		[DynamicField("TYPEQ_ALARM_GRAVETYPE")]
		public System.Int32? TYPEQ_ALARM_GRAVETYPE
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_GRAVETYPE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPEQ_ALARM_GRAVETYPE];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_GRAVETYPE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_IDENTNAME,128)]
		[DynamicField("TYPEQ_ALARM_IDENTNAME")]
		public System.String TYPEQ_ALARM_IDENTNAME
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_IDENTNAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_IDENTNAME];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_IDENTNAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_IDENTTYPE)]
		[DynamicField("TYPEQ_ALARM_IDENTTYPE")]
		public System.Int32? TYPEQ_ALARM_IDENTTYPE
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_IDENTTYPE] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPEQ_ALARM_IDENTTYPE];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_IDENTTYPE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_P1,128)]
		[DynamicField("TYPEQ_ALARM_P1")]
		public System.String TYPEQ_ALARM_P1
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_P1] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_P1];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_P1,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_P2,128)]
		[DynamicField("TYPEQ_ALARM_P2")]
		public System.String TYPEQ_ALARM_P2
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_P2] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_P2];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_P2,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_P3,128)]
		[DynamicField("TYPEQ_ALARM_P3")]
		public System.String TYPEQ_ALARM_P3
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_P3] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_P3];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_P3,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_P4,128)]
		[DynamicField("TYPEQ_ALARM_P4")]
		public System.String TYPEQ_ALARM_P4
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_P4] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_P4];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_P4,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ALARM_P5,128)]
		[DynamicField("TYPEQ_ALARM_P5")]
		public System.String TYPEQ_ALARM_P5
		{
			get
			{
				if (Row[c_champTYPEQ_ALARM_P5] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQ_ALARM_P5];
			}
			set
			{
				Row[c_champTYPEQ_ALARM_P5,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeq_Alarm.c_champTYPEQ_ID},true,true)]
		[DynamicField("SpvTypeq")]
		public CSpvTypeq SpvTypeq
		{
			get
			{
				return (CSpvTypeq) GetParent(new string[]{c_champTYPEQ_ID},typeof(CSpvTypeq));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQ_ID}, value);
			}
		}
	}
}
