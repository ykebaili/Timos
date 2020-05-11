using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    [DynamicClass("Mib table")]
    public class CSpvMibTable : CSpvMibobj
    {
        public const string c_nomTable = "SPV_MIBTABLE";
        public const string c_nomTableInDb = "MIBOBJ";

        ///////////////////////////////////////////////////////////////
		public CSpvMibTable( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
        public CSpvMibTable(DataRow row)
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
				return I.T("Table MIB @1|30036",NomObjetUtilisateur);
			}
		}

        [DynamicField("Variables")]
        public CListeObjetsDonnees Variables
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvMibVariable));
                liste.Filtre = new CFiltreData(CSpvMibTable.c_champMIBMODULE_ID + "=@1 AND " +
                                               CSpvMibTable.c_champMIBOBJ_TYPE + "=@2 AND " +
                                               CSpvMibTable.c_champMIBOBJ_FATHERNAME + "=@3", 
                                               this.ModuleMib.Id, CSpvMibTable.c_typeVariableTable,
                                               this.NomObjetOfficiel);
                return liste;
            }
        }
    }
}
