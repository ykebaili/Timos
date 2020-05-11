using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvMibenum.c_nomTable,CSpvMibenum.c_nomTableInDb,new string[]{ CSpvMibenum.c_champMIBENUM_ID})]
	[ObjetServeurURI("CSpvMibenumServeur")]
	[DynamicClass("Spv Mib Enumeration")]
	public class	CSpvMibenum : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_MIBENUM";
		public const string c_nomTableInDb = "MIBENUM";
		public const string c_champMIBENUM_ID ="MIBENUM_ID";
		public const string c_champMIBENUM_NAME ="MIBENUM_NAME";
		public const string c_champMIBENUM_CODE ="MIBENUM_CODE";
		public const string c_champMIBENUM_TYPE ="MIBENUM_TYPE";
		public const string c_champMIBOBJ_ID ="MIBOBJ_ID";
		public const string c_champMIBOBJ_NAME ="MIBOBJ_NAME";
		public const string c_champMIBENUM_NOM ="MIBENUM_NOM";
		public const string c_champMIBENUM_VISIBLE ="MIBENUM_VISIBLE";
		
		///////////////////////////////////////////////////////////////
		public CSpvMibenum( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvMibenum( DataRow row )
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
			return new string[] {c_champMIBENUM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("MIB enumeration @1|30033", NomOfficiel);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBENUM_NAME,128)]
		[DynamicField("Official label")]
		public System.String NomOfficiel
		{
			get
			{
				return (System.String)Row[c_champMIBENUM_NAME];
			}
			set
			{
				Row[c_champMIBENUM_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBENUM_CODE)]
		[DynamicField("Code")]
		public System.Int32 Code
		{
			get
			{
				return (System.Int32)Row[c_champMIBENUM_CODE];
			}
			set
			{
				Row[c_champMIBENUM_CODE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBENUM_TYPE,10)]
		[DynamicField("Data type")]
		public System.String TypeDonnee
		{
			get
			{
				return (System.String)Row[c_champMIBENUM_TYPE];
			}
			set
			{
				Row[c_champMIBENUM_TYPE,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_NAME,128)]
		[DynamicField("Official object label")]
		public System.String NomOfficielObjet
		{
			get
			{
				return (System.String)Row[c_champMIBOBJ_NAME];
			}
			set
			{
				Row[c_champMIBOBJ_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBENUM_NOM,128)]
		[DynamicField("User's enum label")]
		public System.String NomEnumUtilisateur
		{
			get
			{
				if (Row[c_champMIBENUM_NOM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBENUM_NOM];
			}
			set
			{
				Row[c_champMIBENUM_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBENUM_VISIBLE)]
		[DynamicField("Visibility")]
		public System.Int32 Visibilite
		{
			get
			{
				return (System.Int32)Row[c_champMIBENUM_VISIBLE];
			}
			set
			{
				Row[c_champMIBENUM_VISIBLE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvMibobj.c_nomTable,new string[]{CSpvMibobj.c_champMIBOBJ_ID}, new string[]{CSpvMibenum.c_champMIBOBJ_ID},true,true)]
		[DynamicField("Father object")]
		public CSpvMibobj ObjetPere
		{
			get
			{
				return (CSpvMibobj) GetParent(new string[]{c_champMIBOBJ_ID},typeof(CSpvMibobj));
			}
			set
			{
				SetParent(new string[]{c_champMIBOBJ_ID}, value);
			}
		}
	}
}
