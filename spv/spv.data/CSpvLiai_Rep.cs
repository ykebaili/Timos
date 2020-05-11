using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvLiai_Rep.c_nomTable,CSpvLiai_Rep.c_nomTableInDb,new string[]{ CSpvLiai_Rep.c_champLIAI_ID})]
	[ObjetServeurURI("CSpvLiai_RepServeur")]
	[DynamicClass("Spv Link operational state")]
	public class	CSpvLiai_Rep : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_LIAI_REP";
		public const string c_nomTableInDb = "LIAI_REP";
		public const string c_champLIAI_ID ="LIAI_ID";
		public const string c_champLIAI_OPER ="LIAI_OPER";
        public const string c_champCoeffOper = "LIAI_COEFF_OPER";
		
		///////////////////////////////////////////////////////////////
		public CSpvLiai_Rep( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvLiai_Rep( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            CoefficientOperationnel = 1.0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champLIAI_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Network link operational state @1|30028", SpvLiai.NomLiaison);
			}
		}
		
		///////////////////////////////////////////////////////////////
	/*	[TableFieldProperty(c_champLIAI_ID)]
		[DynamicField("LIAI_ID")]
		public System.Int32 LIAI_ID
		{
			get
			{
				return (System.Int32)Row[c_champLIAI_ID];
			}
			set
			{
				Row[c_champLIAI_ID,true]=value;
			}
		}*/
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_OPER, true)]
		[DynamicField("Operationnal status")]
		public Int32? CodeEtatOperationnel
		{
			get
			{
				if (Row[c_champLIAI_OPER] == DBNull.Value)
					return null;
                return (Int32?)Row[c_champLIAI_OPER];
			}
			set
			{
				Row[c_champLIAI_OPER,true]=value;
			}
		}



        [Relation(
            CSpvLiai.c_nomTable, 
            new string[] { CSpvLiai.c_champLIAI_ID }, 
            new string[] { CSpvLiai_Rep.c_champLIAI_ID }, 
            true, 
            true,
            true)]
        [DynamicField("Spv Link")]
        public CSpvLiai SpvLiai
        {
            get
            {
                return (CSpvLiai)GetParent(new string[] { c_champLIAI_ID }, typeof(CSpvLiai));
            }
            set
            {
                SetParent(new string[] { c_champLIAI_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvLiai_Rep.c_champCoeffOper)]
        [DynamicField("Link operational coefficient")]
        public double CoefficientOperationnel
        {
            get
            {
                return (double)Row[c_champCoeffOper];
            }
            set
            {
                Row[c_champCoeffOper] = value;
            }
        }
	}
}
