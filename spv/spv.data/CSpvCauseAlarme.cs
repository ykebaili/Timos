using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvCauseAlarme.c_nomTable,CSpvCauseAlarme.c_nomTableInDb,new string[]{ CSpvCauseAlarme.c_champCAUSEAL_ID})]
	[ObjetServeurURI("CSpvCausealServeur")]
	[DynamicClass("Alarm cause")]
	public class	CSpvCauseAlarme : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_CAUSEAL";
		public const string c_nomTableInDb = "CAUSEAL";
		public const string c_champCAUSEAL_ID ="CAUSEAL_ID";
		public const string c_champCAUSEAL_LIBEL ="CAUSEAL_LIBEL";
		
		///////////////////////////////////////////////////////////////
		public CSpvCauseAlarme( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvCauseAlarme( DataRow row )
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
			return new string[] {c_champCAUSEAL_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm cause @1|30014", AlarmCause);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCAUSEAL_LIBEL,80)]
		[DynamicField("Alarm cause")]
		public System.String AlarmCause
		{
			get
			{
				return (System.String)Row[c_champCAUSEAL_LIBEL];
			}
			set
			{
				Row[c_champCAUSEAL_LIBEL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [RelationFille(typeof(CSpvAlarmg_Cause), "Cause")]
        [DynamicChilds("Alarm access type extensions having the cause", typeof(CSpvAlarmg_Cause))]
		public CListeObjetsDonnees SpvAlarmG_Causes
		{
			get
			{
				return GetDependancesListe(CSpvAlarmg_Cause.c_nomTable,c_champCAUSEAL_ID);
			}
		}
	}
}
