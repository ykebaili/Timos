using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
    /// <summary>
    /// Cette classe décrit les sous familles SNMP, c'est à dire les tables
    /// trouvées dans les MIBs
    /// </summary>
	[Table(CSpvTypeqinc.c_nomTable,CSpvTypeqinc.c_nomTableInDb,new string[]{ CSpvTypeqinc.c_champTYPEQINC_ID})]
	[ObjetServeurURI("CSpvTypeqincServeur")]
	[DynamicClass("Snmp Tables Parameters")]
	public class	CSpvTypeqinc : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_TYPEQINC";
		public const string c_nomTableInDb = "TYPEQINC";
		public const string c_champTYPEQINC_ID ="TYPEQINC_ID";
		public const string c_champTYPEQINC_CLASSID ="TYPEQINC_CLASSID";
		public const string c_champTYPEQINC_NOM ="TYPEQINC_NOM";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champTYPEQINC_NAMEOID ="TYPEQINC_NAMEOID";
		public const string c_champTYPEQINC_SIGNOID ="TYPEQINC_SIGNOID";
		public const string c_champTYPEQINC_OTHEROID ="TYPEQINC_OTHEROID";
		public const string c_champTYPEQ2_ID ="TYPEQ2_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeqinc( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvTypeqinc( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champTYPEQINC_CLASSID] = 1043;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champTYPEQINC_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return "l'élement de type "+GetType().ToString();
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQINC_CLASSID)]
        [DynamicField("Class ID")]
		public System.Double TYPEQINC_CLASSID
		{
			get
			{
				return (System.Double)Row[c_champTYPEQINC_CLASSID];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQINC_NOM,40)]
		[DynamicField("Label")]
		public System.String Libelle
		{
			get
			{
				return (System.String)Row[c_champTYPEQINC_NOM];
			}
			set
			{
				Row[c_champTYPEQINC_NOM,true]=value;
			}
		}
		

		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQINC_NAMEOID,256)]
		[DynamicField("Name OID")]
		public System.String OIDNom
		{
			get
			{
				if (Row[c_champTYPEQINC_NAMEOID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQINC_NAMEOID];
			}
			set
			{
				Row[c_champTYPEQINC_NAMEOID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQINC_SIGNOID,256)]
		[DynamicField("Signature OID")]
		public System.String OIDSignature
		{
			get
			{
				if (Row[c_champTYPEQINC_SIGNOID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQINC_SIGNOID];
			}
			set
			{
				Row[c_champTYPEQINC_SIGNOID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQINC_OTHEROID,256)]
		[DynamicField("Other OID")]
		public System.String OIDAutre
		{
			get
			{
				if (Row[c_champTYPEQINC_OTHEROID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champTYPEQINC_OTHEROID];
			}
			set
			{
				Row[c_champTYPEQINC_OTHEROID,true]=value;
			}
		}

		/*
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ2_ID)]
		[DynamicField("Attached Equipment type ID")]
        public System.Int32? IDTypeEquipementAttache //Old public System.Int32? TYPEQ2_ID
		{
			get
			{
				if (Row[c_champTYPEQ2_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPEQ2_ID];
			}
			set
			{
				Row[c_champTYPEQ2_ID,true]=value;
			}
		}*/
		
		///////////////////////////////////////////////////////////////
 		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeqinc.c_champTYPEQ2_ID},false,false)]
		[DynamicField("SpvTypeq")]
        public CSpvTypeq TypeEquipementAttache
		{
			get
			{
				return (CSpvTypeq) GetParent(new string[]{c_champTYPEQ2_ID},typeof(CSpvTypeq));
			}
			set
			{
				SetParent(new string[]{c_champTYPEQ2_ID}, value);
			}
		}
		
        
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvTypeqinc.c_champTYPEQ_ID},false,true)]
		[DynamicField("SpvTypeq")]
		public CSpvTypeq TypeEquipementEnglobant
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
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvEquip),"SpvTypeqinc")]
        [DynamicChilds("Equipments", typeof(CSpvEquip))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListe(CSpvEquip.c_nomTable,c_champTYPEQINC_ID);
			}
		}
	}
}
