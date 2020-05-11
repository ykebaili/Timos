using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvAcquittement.c_nomTable,CSpvAcquittement.c_nomTableInDb,new string[]{ CSpvAcquittement.c_champACQUITTEMENT_ID})]
	[ObjetServeurURI("CSpvAcquittementServeur")]
	[DynamicClass("SpvAcquittement")]
	public class	CSpvAcquittement : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_ACQUITTEMENT";
		public const string c_nomTableInDb = "ACQUITTEMENT";
		public const string c_champACQUITTEMENT_ID ="ACQUITTEMENT_ID";
		public const string c_champACK ="ACK";
		public const string c_champLISTALRM_ID ="LISTALRM_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvAcquittement( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvAcquittement( DataRow row )
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
			return new string[] {c_champACQUITTEMENT_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Acknowledgement @1|30007", Id.ToString());
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACK)]
		[DynamicField("ACK")]
		public System.Boolean ACK
		{
			get
			{
				return (System.Boolean)Row[c_champACK];
			}
			set
			{
				Row[c_champACK,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLISTALRM_ID)]
		[DynamicField("LISTALRM_ID")]
		public System.Double? LISTALRM_ID
		{
			get
			{
				if (Row[c_champLISTALRM_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champLISTALRM_ID];
			}
			set
			{
				Row[c_champLISTALRM_ID,true]=value;
			}
		}
	}
}
