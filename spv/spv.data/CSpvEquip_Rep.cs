using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvEquip_Rep.c_nomTable,CSpvEquip_Rep.c_nomTableInDb,new string[]{ CSpvEquip_Rep.c_champEQUIP_ID})]
	[ObjetServeurURI("CSpvEquip_RepServeur")]
	[DynamicClass("Equipment operational state")]
    public class CSpvEquip_Rep : CObjetDonneeAIdNumerique, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_EQUIP_REP";
		public const string c_nomTableInDb = "EQUIP_REP";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		public const string c_champEQUIP_OPER ="EQUIP_OPER";
		public const string c_champEQUIP_POLLINDEX ="EQUIP_POLLINDEX";
		public const string c_champEQUIP_TRAPINDEX ="EQUIP_TRAPINDEX";
		public const string c_champEQUIP_COMMUT = "EQUIP_COMMUT";
        public const string c_champCoefOperationnel = "EQUIP_COEFF_OP";
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip_Rep( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEquip_Rep( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
			CodeEtatOperationnel = (Int32?)EEtatOperationnel.OK;
            CoefficientOperationnel = 1.0;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champEQUIP_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Equipment operational state @1|30019", SpvEquip.CommentairePourSituer);
			}
		}

 
	
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_OPER, true)]
		[DynamicField("Equipment operational state")]
        public Int32? CodeEtatOperationnel
		{
			get
			{
				if (Row[c_champEQUIP_OPER] == DBNull.Value)
					return null;
                return (Int32?)Row[c_champEQUIP_OPER];
			}
			set
			{
				Row[c_champEQUIP_OPER,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_POLLINDEX, true)]
		[DynamicField("Equipment poll index")]
		public Int32 ? EQUIP_POLLINDEX
		{
			get
			{
				if (Row[c_champEQUIP_POLLINDEX] == DBNull.Value)
					return null;
				return (Int32 ?)Row[c_champEQUIP_POLLINDEX];
			}
			set
			{
				Row[c_champEQUIP_POLLINDEX,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_TRAPINDEX, true)]
		[DynamicField("Equimpent trap index")]
		public Int32 ? EQUIP_TRAPINDEX
		{
			get
			{
				if (Row[c_champEQUIP_TRAPINDEX] == DBNull.Value)
					return null;
				return (Int32 ?)Row[c_champEQUIP_TRAPINDEX];
			}
			set
			{
				Row[c_champEQUIP_TRAPINDEX,true]=value;
			}
		}


		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_COMMUT)]
		[DynamicField("Switch position")]
		public int PositionCommutateur
		{
			get
			{
				return (int)Row[c_champEQUIP_COMMUT];
			}
			set
			{
				Row[c_champEQUIP_COMMUT, true] = value;
			}
		}

        ///////////////////////////////////////////////////////////////
        [Relation(
            CSpvEquip.c_nomTable, 
            new string[] { CSpvEquip.c_champEQUIP_ID }, 
            new string[] { CSpvEquip_Rep.c_champEQUIP_ID }, 
            true, true,
            true)]
        [DynamicField("Spv Equipment")]
        public CSpvEquip SpvEquip
        {
            get
            {
                return (CSpvEquip)GetParent(new string[] { c_champEQUIP_ID }, typeof(CSpvEquip));
            }
            set
            {
                SetParent(new string[] { c_champEQUIP_ID }, value);
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(CSpvEquip_Rep.c_champCoefOperationnel)]
        [DynamicField("Equipment Link operational coefficient")]
        public double CoefficientOperationnel
        {
            get
            {
                return (double)Row[c_champCoefOperationnel];
            }
            set
            {
                Row[c_champCoefOperationnel] = value;
            }
        }

	}
}
