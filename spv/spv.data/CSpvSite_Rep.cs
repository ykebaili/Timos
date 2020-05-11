using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvSite_Rep.c_nomTable,CSpvSite_Rep.c_nomTableInDb,new string[]{ CSpvSite_Rep.c_champSITE_ID})]
	[ObjetServeurURI("CSpvSite_RepServeur")]
	[DynamicClass("Site Operational state")]
	public class	CSpvSite_Rep : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_SITE_REP";
		public const string c_nomTableInDb = "SITE_REP";
		public const string c_champSITE_ID ="SITE_ID";
		public const string c_champSITE_OPER ="SITE_OPER";
        public const string c_champSITE_COEFF_OPER = "SITE_COEF";
		
		///////////////////////////////////////////////////////////////
		public CSpvSite_Rep( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvSite_Rep( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CoefficientOperationnel = 1.0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champSITE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Site operational state @1|30050", SpvSite.SiteNom);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_OPER, true)]
		[DynamicField("Operationnal state")]
        public Int32? CodeEtatOperationnel
		{
			get
			{
				if (Row[c_champSITE_OPER] == DBNull.Value)
					return null;
                return (Int32?)Row[c_champSITE_OPER];
			}
			set
			{
				Row[c_champSITE_OPER,true]=value;
			}
		}


        ///////////////////////////////////////////////////////////////
        [Relation(
            CSpvSite.c_nomTable, 
            new string[] { CSpvSite.c_champSITE_ID }, 
            new string[] { CSpvSite_Rep.c_champSITE_ID }, true, true, true,
            IsInDb=false)]
        [DynamicField("SpvSite")]
        public CSpvSite SpvSite
        {
            get
            {
                return (CSpvSite)GetParent(new string[] { c_champSITE_ID }, typeof(CSpvSite));
            }
            set
            {
                SetParent(new string[] { c_champSITE_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvSite_Rep.c_champSITE_COEFF_OPER)]
        [DynamicField("Site operational coefficient")]
        public double CoefficientOperationnel
        {
            get
            {
                return (double)Row[c_champSITE_COEFF_OPER];
            }
            set
            {
                Row[c_champSITE_COEFF_OPER] = value;
            }
        }
               
	}
}
