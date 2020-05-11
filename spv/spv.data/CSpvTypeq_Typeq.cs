using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvTypeq_Typeq.c_nomTable,CSpvTypeq_Typeq.c_nomTableInDb,new string[]{ CSpvTypeq_Typeq.c_champTYPEQ_ID,CSpvTypeq_Typeq.c_champTYPEQ_BINDINGID})]
	[ObjetServeurURI("CSpvTypeq_TypeqServeur")]
	[DynamicClass("SpvTypeq_Typeq")]
	public class	CSpvTypeq_Typeq : CObjetDonnee, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQ_TYPEQ";
		public const string c_nomTableInDb = "TYPEQ_TYPEQ";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champTYPEQ_BINDINGID ="TYPEQ_BINDINGID";
		public const string c_champTYPEQ_TYPEQ_NB ="TYPEQ_TYPEQ_NB";
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Typeq( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeq_Typeq( DataRow row )
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
                return ("Equipment type inclusion relationship|30046");
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_TYPEQ_NB)]
		[DynamicField("Number of included equipments")]
		public System.Double? TYPEQ_TYPEQ_NB
		{
			get
			{
				if (Row[c_champTYPEQ_TYPEQ_NB] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champTYPEQ_TYPEQ_NB];
			}
			set
			{
				Row[c_champTYPEQ_TYPEQ_NB,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        // Englobant
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeq_Typeq.c_champTYPEQ_BINDINGID},true,true)]
		[DynamicField("Including equipment type")]
		public CSpvTypeq SpvTypeq
		{
			get
			{
				return (CSpvTypeq) GetParent(new string[]{c_champTYPEQ_BINDINGID},typeof(CSpvTypeq));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQ_BINDINGID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
        // Englobé
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeq_Typeq.c_champTYPEQ_ID},true,true)]
		[DynamicField("Included Equipment type")]
		public CSpvTypeq SpvTypeq1
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
	}
}
