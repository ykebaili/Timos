using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvEquipredecouv.c_nomTable,CSpvEquipredecouv.c_nomTableInDb,new string[]{ CSpvEquipredecouv.c_champEQUIPREDECOUV_ID})]
	[ObjetServeurURI("CSpvEquipredecouvServeur")]
	[DynamicClass("Equipment rediscover")]
	public class	CSpvEquipredecouv : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_EQUIPREDECOUV";
		public const string c_nomTableInDb = "EQUIPREDECOUV";
		public const string c_champEQUIPREDECOUV_ID ="EQUIPREDECOUV_ID";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvEquipredecouv( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvEquipredecouv( DataRow row )
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
			return new string[] {c_champEQUIPREDECOUV_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("Equipment rediscover @1|30019", Id.ToString());
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		/*[TableFieldProperty(c_champEQUIP_ID)]
		[DynamicField("EQUIP_ID")]
		public System.Double? EQUIP_ID
		{
			get
			{
				if (Row[c_champEQUIP_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champEQUIP_ID];
			}
			set
			{
				Row[c_champEQUIP_ID,true]=value;
			}
		}
        */


        [Relation(CSpvEquip.c_nomTable, new string[] { CSpvEquip.c_champEQUIP_ID }, new string[] { CSpvEquipredecouv.c_champEQUIP_ID }, true, true)]
        [DynamicField("Spv Equipment")]
        public CSpvEquip SpvEquip
        {
            get
            {
                return (CSpvEquip)GetParent(new string[] { c_champEQUIP_ID }, typeof(CSpvEquip));
            }
            set
            {
                SetParent(new string[] { c_champEQUIP_ID }, value);
            }
        }

	}
}
