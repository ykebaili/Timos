using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvError.c_nomTable,CSpvError.c_nomTableInDb,new string[]{ CSpvError.c_champERROR_ID})]
	[ObjetServeurURI("CSpvErrorServeur")]
	[DynamicClass("Spv Error")]
	public class	CSpvError : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ERROR";
		public const string c_nomTableInDb = "ERROR";
		public const string c_champERROR_ID ="ERROR_ID";
		public const string c_champERROR_TYP ="ERROR_TYP";
		public const string c_champERROR_LIBELLE ="ERROR_LIBELLE";
		
		///////////////////////////////////////////////////////////////
		public CSpvError( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvError( DataRow row )
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
			return new string[] {c_champERROR_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Spv error @1|30020",ERROR_LIBELLE);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champERROR_TYP)]
		[DynamicField("Error type")]
		public System.Double ERROR_TYP
		{
			get
			{
				return (System.Double)Row[c_champERROR_TYP];
			}
			set
			{
				Row[c_champERROR_TYP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champERROR_LIBELLE,256)]
		[DynamicField("Label")]
		public System.String ERROR_LIBELLE
		{
			get
			{
				if (Row[c_champERROR_LIBELLE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champERROR_LIBELLE];
			}
			set
			{
				Row[c_champERROR_LIBELLE,true]=value;
			}
		}
	}
}
