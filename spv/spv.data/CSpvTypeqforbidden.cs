using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvTypeqforbidden.c_nomTable,CSpvTypeqforbidden.c_nomTableInDb,new string[]{ CSpvTypeqforbidden.c_champTYPEQFORBIDDEN_ID})]
	[ObjetServeurURI("CSpvTypeqforbiddenServeur")]
	[DynamicClass("Forbidden equipment type")]
	public class	CSpvTypeqforbidden : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQFORBIDDEN";
		public const string c_nomTableInDb = "TYPEQFORBIDDEN";
		public const string c_champTYPEQFORBIDDEN_ID ="TYPEQFORBIDDEN_ID";
		public const string c_champTYPEQFORBIDDEN_REFSNMP ="TYPEQFORBIDDEN_REFSNMP";
		public const string c_champTYPEQFORBIDDEN_COMMENT ="TYPEQFORBIDDEN_COMMENT";
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeqforbidden( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeqforbidden( DataRow row )
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
			return new string[] {c_champTYPEQFORBIDDEN_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Forbidden equipment type @1|30049",Id.ToString());
			}
		}
		
    /*
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQFORBIDDEN_ID)]
		[DynamicField("TYPEQFORBIDDEN_ID")]
		public System.Int32 TYPEQFORBIDDEN_ID
		{
			get
			{
				return (System.Int32)Row[c_champTYPEQFORBIDDEN_ID];
			}
			set
			{
				Row[c_champTYPEQFORBIDDEN_ID,true]=value;
			}
		}
	*/	
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQFORBIDDEN_REFSNMP,256)]
		[DynamicField("SNMP reference")]
		public System.String ReferenceSNMP
		{
			get
			{
				return (System.String)Row[c_champTYPEQFORBIDDEN_REFSNMP];
			}
			set
			{
				Row[c_champTYPEQFORBIDDEN_REFSNMP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQFORBIDDEN_COMMENT,256)]
		[DynamicField("Comment")]
		public System.String Commentaire
		{
			get
			{
				if (Row[c_champTYPEQFORBIDDEN_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQFORBIDDEN_COMMENT];
			}
			set
			{
				Row[c_champTYPEQFORBIDDEN_COMMENT,true]=value;
			}
		}
	}
}
