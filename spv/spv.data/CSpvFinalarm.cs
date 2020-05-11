using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvFinalarm.c_nomTable,CSpvFinalarm.c_nomTableInDb,new string[]{ CSpvFinalarm.c_champFINALARM_ID})]
	[ObjetServeurURI("CSpvFinalarmServeur")]
	[DynamicClass("Alarm end")]
	public class	CSpvFinalarm : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_FINALARM";
		public const string c_nomTableInDb = "FINALARM";
		public const string c_champFINALARM_ID ="FINALARM_ID";
		public const string c_champALARM_ID ="ALARM_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvFinalarm( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvFinalarm( DataRow row )
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
			return new string[] {c_champFINALARM_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Alarm end @1|30024",EvenementReseau.AlarmCategory);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		/*[TableFieldProperty(c_champALARM_ID)]
		[DynamicField("ALARM ID")]
		public System.Double ALARM_ID
		{
			get
			{
				return (System.Double)Row[c_champALARM_ID];
			}
			set
			{
				Row[c_champALARM_ID,true]=value;
			}
		}*/


        ///////////////////////////////////////////////////////////////
           [Relation(CSpvEvenementReseau.c_nomTable, new string[] { CSpvEvenementReseau.c_champALARM_ID }, new string[] { CSpvFinalarm.c_champALARM_ID }, false, false)]
           [DynamicField("Network event")]
           public CSpvEvenementReseau EvenementReseau
           {
               get
               {
                   return (CSpvEvenementReseau)GetParent(new string[] { c_champALARM_ID }, typeof(CSpvEvenementReseau));
               }
               set
               {
                   SetParent(new string[] { c_champALARM_ID }, value);
               }
           }
         
	}
}
