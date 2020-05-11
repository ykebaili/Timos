using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvAccesgroupe.c_nomTable,CSpvAccesgroupe.c_nomTableInDb,new string[]{ CSpvAccesgroupe.c_champACCESGROUPE_ID})]
	[ObjetServeurURI("CSpvAccesgroupeServeur")]
	[DynamicClass("Group access")]
	public class	CSpvAccesgroupe : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ACCESGROUPE";
		public const string c_nomTableInDb = "ACCESGROUPE";
		public const string c_champACCESGROUPE_ID ="ACCESGROUPE_ID";
		public const string c_champACCESGROUPE_NOM ="ACCESGROUPE_NOM";
		public const string c_champACCESGROUPE_CLASSID ="ACCESGROUPE_CLASSID";
		
		///////////////////////////////////////////////////////////////
		public CSpvAccesgroupe( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAccesgroupe( DataRow row )
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
			return new string[] {c_champACCESGROUPE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Group access @1|30049", ACCESGROUPE_NOM);
			}
		}
		

		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCESGROUPE_NOM,40)]
		[DynamicField("Name")]
		public System.String ACCESGROUPE_NOM
		{
			get
			{
				if (Row[c_champACCESGROUPE_NOM] == DBNull.Value)
					return null;
				return (System.String)Row[c_champACCESGROUPE_NOM];
			}
			set
			{
				Row[c_champACCESGROUPE_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCESGROUPE_CLASSID)]
		[DynamicField("Class Id")]
		public System.Double? ACCESGROUPE_CLASSID
		{
			get
			{
				if (Row[c_champACCESGROUPE_CLASSID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champACCESGROUPE_CLASSID];
			}
			set
			{
				Row[c_champACCESGROUPE_CLASSID,true]=value;
			}
		}
		
	}
}
