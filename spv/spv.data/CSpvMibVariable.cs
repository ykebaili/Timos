using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [DynamicClass("Mib variable")]
    public class CSpvMibVariable : CSpvMibobj
    {
        public const string c_nomTable = "SPV_MIBVARIABLE";
        public const string c_nomTableInDb = "MIBOBJ";

        ///////////////////////////////////////////////////////////////
		public CSpvMibVariable( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
        public CSpvMibVariable(DataRow row)
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
                return I.T("MIB variable @1|30038",NomObjetUtilisateur);
			}
		}
    }
}
