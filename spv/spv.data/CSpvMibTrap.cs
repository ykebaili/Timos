using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [DynamicClass("Mib trap")]
    public class CSpvMibTrap : CSpvMibobj
    {
        public const string c_nomTable = "SPV_MIBTRAP";
        public const string c_nomTableInDb = "MIBOBJ";

        ///////////////////////////////////////////////////////////////
		public CSpvMibTrap( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
        public CSpvMibTrap(DataRow row)
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            base.MyInitValeurDefaut();
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champMIBOBJ_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("MIB Trap @1|30037", NomObjetUtilisateur);
			}
		}
    }
}
