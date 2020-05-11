using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvTypeq_Mibmodule.c_nomTable,CSpvTypeq_Mibmodule.c_nomTableInDb,new string[]{ CSpvTypeq_Mibmodule.c_champTYPEQ_ID,CSpvTypeq_Mibmodule.c_champMIBMODULE_ID})]
	[ObjetServeurURI("CSpvTypeq_MibmoduleServeur")]
	[DynamicClass("Equipment type / MIB module relationship")]
	public class	CSpvTypeq_Mibmodule : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQ_MIBMODULE";
		public const string c_nomTableInDb = "TYPEQ_MIBMODULE";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champMIBMODULE_ID ="MIBMODULE_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Mibmodule( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Mibmodule( DataRow row )
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
			return new string[] {c_champTYPEQ_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Equipment type / MIB module relationship|30045");
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
                Row[c_champTYPEQ_ID, true] = value;
            }
        }

        ///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMIBMODULE_ID)]
        [DynamicField("MIBMODULE_ID")]
        public System.Int32 MIBMODULE_ID
        {
            get
            {
                return (System.Int32)Row[c_champMIBMODULE_ID];
            }
            set
            {
                Row[c_champMIBMODULE_ID, true] = value;
            }
        }

		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeq_Mibmodule.c_champTYPEQ_ID},true,true)]
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
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvMibmodule.c_nomTable,new string[]{CSpvMibmodule.c_champMIBMODULE_ID}, new string[]{CSpvTypeq_Mibmodule.c_champMIBMODULE_ID},true,true)]
		[DynamicField("SpvMibmodule")]
		public CSpvMibmodule SpvMibmodule
		{
			get
			{
				return (CSpvMibmodule) GetParent(new string[]{c_champMIBMODULE_ID},typeof(CSpvMibmodule));
			}
			set
			{
				SetParent(new string[]{c_champMIBMODULE_ID}, value);
			}
		}
	}
}
