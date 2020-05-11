using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvSys_Champ_Auto.c_nomTable,CSpvSys_Champ_Auto.c_nomTableInDb,new string[]{ CSpvSys_Champ_Auto.c_champTABLE_NAME,CSpvSys_Champ_Auto.c_champCHAMP_NAME,CSpvSys_Champ_Auto.c_champTG_NAME,CSpvSys_Champ_Auto.c_champSQ_NAME})]
	[ObjetServeurURI("CSpvSys_Champ_AutoServeur")]
	[DynamicClass("Index name and primary key storage")]
	public class	CSpvSys_Champ_Auto : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_SYS_CHAMP_AUTO";
		public const string c_nomTableInDb = "SYS_CHAMP_AUTO";
		public const string c_champTABLE_NAME ="TABLE_NAME";
		public const string c_champCHAMP_NAME ="CHAMP_NAME";
		public const string c_champTG_NAME ="TG_NAME";
		public const string c_champSQ_NAME ="SQ_NAME";
		
		///////////////////////////////////////////////////////////////
		public CSpvSys_Champ_Auto( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvSys_Champ_Auto( DataRow row )
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
			return new string[] {c_champTABLE_NAME};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return ("Index name and primary key storage @1|30052");
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTABLE_NAME,50)]
		[DynamicField("Table Name")]
		public System.String TABLE_NAME
		{
			get
			{
				return (System.String)Row[c_champTABLE_NAME];
			}
			set
			{
				Row[c_champTABLE_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCHAMP_NAME,50)]
		[DynamicField("Field Name")]
		public System.String CHAMP_NAME
		{
			get
			{
				return (System.String)Row[c_champCHAMP_NAME];
			}
			set
			{
				Row[c_champCHAMP_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTG_NAME,60)]
		[DynamicField("TG Name")]
		public System.String TG_NAME
		{
			get
			{
				return (System.String)Row[c_champTG_NAME];
			}
			set
			{
				Row[c_champTG_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSQ_NAME,60)]
		[DynamicField("SQ Name")]
		public System.String SQ_NAME
		{
			get
			{
				return (System.String)Row[c_champSQ_NAME];
			}
			set
			{
				Row[c_champSQ_NAME,true]=value;
			}
		}
	}
}
