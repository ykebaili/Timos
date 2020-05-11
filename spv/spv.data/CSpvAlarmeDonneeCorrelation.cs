using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvAlarmeDonneeCorrelation.c_nomTable,CSpvAlarmeDonneeCorrelation.c_nomTableInDb,new string[]{ CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID,CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_BINDINGID})]
    [ObjetServeurURI("CSpvAlarmeDonneeCorrelationServeur")]
	[DynamicClass("Masking alarm / Masked alarm relationship")]
	public class	CSpvAlarmeDonneeCorrelation : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ALARMDATA_CORRELATION";
		public const string c_nomTableInDb = "ALARMDATA_CORREL";
        public const string c_champALARMEDONNEE_ID = "ALARMDATA_ID";
        public const string c_champALARMEDONNEE_BINDINGID = "ALARMDATA_BINDINGID";
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmeDonneeCorrelation( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAlarmeDonneeCorrelation( DataRow row )
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
            return new string[] { c_champALARMEDONNEE_ID };
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Masking alarm /Masked alarm relationship|30008");
			}
		}
		

        //relation vers parent (alarme masquée)
        [Relation(CSpvAlarmeDonnee.c_nomTable, new string[] { CSpvAlarmeDonnee.c_champALARMEDONNEE_ID }, new string[] { CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_ID }, false, false)]
        [DynamicField("Masked alarm")]
        public CSpvAlarmeDonnee AlarmeMasquee
        {
            get
            {
                return (CSpvAlarmeDonnee)GetParent(new string[] { c_champALARMEDONNEE_ID }, typeof(CSpvAlarmeDonnee));
            }
            set
            {
                SetParent(new string[] { c_champALARMEDONNEE_ID }, value);
            }
        }



        //relation vers parent (alarme masquante)
        [Relation(CSpvAlarmeDonnee.c_nomTable, new string[] { CSpvAlarmeDonnee.c_champALARMEDONNEE_ID }, new string[] { CSpvAlarmeDonneeCorrelation.c_champALARMEDONNEE_BINDINGID }, false, false)]
        [DynamicField("Masking alarm")]
        public CSpvAlarmeDonnee AlarmeMasquante
        {
            get
            {
                return (CSpvAlarmeDonnee)GetParent(new string[] { c_champALARMEDONNEE_BINDINGID }, typeof(CSpvAlarmeDonnee));
            }
            set
            {
                SetParent(new string[] { c_champALARMEDONNEE_BINDINGID }, value);
            }
        }
	}
}
