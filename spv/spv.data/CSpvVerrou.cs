using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvVerrou.c_nomTable,CSpvVerrou.c_nomTableInDb,new string[]{ CSpvVerrou.c_champVERROU_ID})]
	[ObjetServeurURI("CSpvVerrouServeur")]
	[DynamicClass("SpvVerrou")]
	public class	CSpvVerrou : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_VERROU";
		public const string c_nomTableInDb = "VERROU";
		public const string c_champVERROU_ID ="VERROU_ID";
		public const string c_champLIAI_ID ="LIAI_ID";
		public const string c_champEQUIP_ID ="EQUIP_ID";
		public const string c_champSITE_ID ="SITE_ID";
		public const string c_champACCES_ID ="ACCES_ID";
		public const string c_champROLE_ID ="ROLE_ID";
		public const string c_champTYPEQ_ID ="TYPEQ_ID";
		public const string c_champPROG_ID ="PROG_ID";
		public const string c_champAFFBOUTON_ID ="AFFBOUTON_ID";
		public const string c_champCABLEQU_ID ="CABLEQU_ID";
		public const string c_champLIBSYMB_ID ="LIBSYMB_ID";
		public const string c_champALARMGEREE_ID ="ALARMGEREE_ID";
		public const string c_champTYPLIAI_ID ="TYPLIAI_ID";
		public const string c_champPERIF_ID ="PERIF_ID";
		public const string c_champSESSION_ID ="SESSION_ID";
		public const string c_champVERROU_USERNAME ="VERROU_USERNAME";
		public const string c_champVERROU_USERSITE ="VERROU_USERSITE";
		public const string c_champVERROU_TYPE ="VERROU_TYPE";
		public const string c_champVERROU_OP ="VERROU_OP";
		public const string c_champSCRIPT_ID ="SCRIPT_ID";
		public const string c_champTYPPROG_ID ="TYPPROG_ID";
		public const string c_champTOP_ID ="TOP_ID";
		public const string c_champMODELCABL_ID ="MODELCABL_ID";
		public const string c_champMIBMODULE_ID ="MIBMODULE_ID";
		public const string c_champORDRE_ID ="ORDRE_ID";
		public const string c_champFAMILLE_ID ="FAMILLE_ID";
		public const string c_champACCESGROUPE_ID ="ACCESGROUPE_ID";
		public const string c_champACCES_ACCESC_ID ="ACCES_ACCESC_ID";
		public const string c_champBOUTON_ID ="BOUTON_ID";
		
		///////////////////////////////////////////////////////////////
		public CSpvVerrou( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvVerrou( DataRow row )
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
			return new string[] {c_champVERROU_ID};
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
		[TableFieldProperty(c_champVERROU_ID)]
		[DynamicField("VERROU_ID")]
		public System.Int32 VERROU_ID
		{
			get
			{
				return (System.Int32)Row[c_champVERROU_ID];
			}
			set
			{
				Row[c_champVERROU_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIAI_ID)]
		[DynamicField("LIAI_ID")]
		public System.Int32? LIAI_ID
		{
			get
			{
				if (Row[c_champLIAI_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champLIAI_ID];
			}
			set
			{
				Row[c_champLIAI_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champEQUIP_ID)]
		[DynamicField("EQUIP_ID")]
		public System.Int32? EQUIP_ID
		{
			get
			{
				if (Row[c_champEQUIP_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champEQUIP_ID];
			}
			set
			{
				Row[c_champEQUIP_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSITE_ID)]
		[DynamicField("SITE_ID")]
		public System.Int32? SITE_ID
		{
			get
			{
				if (Row[c_champSITE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champSITE_ID];
			}
			set
			{
				Row[c_champSITE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCES_ID)]
		[DynamicField("ACCES_ID")]
		public System.Int32? ACCES_ID
		{
			get
			{
				if (Row[c_champACCES_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champACCES_ID];
			}
			set
			{
				Row[c_champACCES_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champROLE_ID)]
		[DynamicField("ROLE_ID")]
		public System.Int32? ROLE_ID
		{
			get
			{
				if (Row[c_champROLE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champROLE_ID];
			}
			set
			{
				Row[c_champROLE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPEQ_ID)]
		[DynamicField("TYPEQ_ID")]
		public System.Int32? TYPEQ_ID
		{
			get
			{
				if (Row[c_champTYPEQ_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPEQ_ID];
			}
			set
			{
				Row[c_champTYPEQ_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champPROG_ID)]
		[DynamicField("PROG_ID")]
		public System.Int32? PROG_ID
		{
			get
			{
				if (Row[c_champPROG_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champPROG_ID];
			}
			set
			{
				Row[c_champPROG_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champAFFBOUTON_ID)]
		[DynamicField("AFFBOUTON_ID")]
		public System.Int32? AFFBOUTON_ID
		{
			get
			{
				if (Row[c_champAFFBOUTON_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champAFFBOUTON_ID];
			}
			set
			{
				Row[c_champAFFBOUTON_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champCABLEQU_ID)]
		[DynamicField("CABLEQU_ID")]
		public System.Int32? CABLEQU_ID
		{
			get
			{
				if (Row[c_champCABLEQU_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champCABLEQU_ID];
			}
			set
			{
				Row[c_champCABLEQU_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champLIBSYMB_ID)]
		[DynamicField("LIBSYMB_ID")]
		public System.Int32? LIBSYMB_ID
		{
			get
			{
				if (Row[c_champLIBSYMB_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champLIBSYMB_ID];
			}
			set
			{
				Row[c_champLIBSYMB_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champALARMGEREE_ID)]
		[DynamicField("ALARMGEREE_ID")]
		public System.Int32? ALARMGEREE_ID
		{
			get
			{
				if (Row[c_champALARMGEREE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champALARMGEREE_ID];
			}
			set
			{
				Row[c_champALARMGEREE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPLIAI_ID)]
		[DynamicField("TYPLIAI_ID")]
		public System.Int32? TYPLIAI_ID
		{
			get
			{
				if (Row[c_champTYPLIAI_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPLIAI_ID];
			}
			set
			{
				Row[c_champTYPLIAI_ID,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champPERIF_ID)]
		[DynamicField("PERIF_ID")]
		public System.Int32? PERIF_ID
		{
			get
			{
				if (Row[c_champPERIF_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champPERIF_ID];
			}
			set
			{
				Row[c_champPERIF_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSESSION_ID)]
		[DynamicField("SESSION_ID")]
		public System.Double SESSION_ID
		{
			get
			{
				return (System.Double)Row[c_champSESSION_ID];
			}
			set
			{
				Row[c_champSESSION_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champVERROU_USERNAME,40)]
		[DynamicField("VERROU_USERNAME")]
		public System.String VERROU_USERNAME
		{
			get
			{
				if (Row[c_champVERROU_USERNAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champVERROU_USERNAME];
			}
			set
			{
				Row[c_champVERROU_USERNAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champVERROU_USERSITE,40)]
		[DynamicField("VERROU_USERSITE")]
		public System.String VERROU_USERSITE
		{
			get
			{
				if (Row[c_champVERROU_USERSITE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champVERROU_USERSITE];
			}
			set
			{
				Row[c_champVERROU_USERSITE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champVERROU_TYPE,1)]
		[DynamicField("VERROU_TYPE")]
		public System.String VERROU_TYPE
		{
			get
			{
				if (Row[c_champVERROU_TYPE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champVERROU_TYPE];
			}
			set
			{
				Row[c_champVERROU_TYPE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champVERROU_OP,1)]
		[DynamicField("VERROU_OP")]
		public System.String VERROU_OP
		{
			get
			{
				if (Row[c_champVERROU_OP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champVERROU_OP];
			}
			set
			{
				Row[c_champVERROU_OP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champSCRIPT_ID)]
		[DynamicField("SCRIPT_ID")]
		public System.Int32? SCRIPT_ID
		{
			get
			{
				if (Row[c_champSCRIPT_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champSCRIPT_ID];
			}
			set
			{
				Row[c_champSCRIPT_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTYPPROG_ID)]
		[DynamicField("TYPPROG_ID")]
		public System.Int32? TYPPROG_ID
		{
			get
			{
				if (Row[c_champTYPPROG_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTYPPROG_ID];
			}
			set
			{
				Row[c_champTYPPROG_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champTOP_ID)]
		[DynamicField("TOP_ID")]
		public System.Int32? TOP_ID
		{
			get
			{
				if (Row[c_champTOP_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champTOP_ID];
			}
			set
			{
				Row[c_champTOP_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMODELCABL_ID)]
		[DynamicField("MODELCABL_ID")]
		public System.Int32? MODELCABL_ID
		{
			get
			{
				if (Row[c_champMODELCABL_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMODELCABL_ID];
			}
			set
			{
				Row[c_champMODELCABL_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_ID)]
		[DynamicField("MIBMODULE_ID")]
		public System.Double? MIBMODULE_ID
		{
			get
			{
				if (Row[c_champMIBMODULE_ID] == DBNull.Value)
					return null;
				return (System.Double?)Row[c_champMIBMODULE_ID];
			}
			set
			{
				Row[c_champMIBMODULE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champORDRE_ID)]
		[DynamicField("ORDRE_ID")]
		public System.Int32? ORDRE_ID
		{
			get
			{
				if (Row[c_champORDRE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champORDRE_ID];
			}
			set
			{
				Row[c_champORDRE_ID,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champFAMILLE_ID)]
		[DynamicField("FAMILLE_ID")]
		public System.Int32? FAMILLE_ID
		{
			get
			{
				if (Row[c_champFAMILLE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champFAMILLE_ID];
			}
			set
			{
				Row[c_champFAMILLE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCESGROUPE_ID)]
		[DynamicField("ACCESGROUPE_ID")]
		public System.Int32? ACCESGROUPE_ID
		{
			get
			{
				if (Row[c_champACCESGROUPE_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champACCESGROUPE_ID];
			}
			set
			{
				Row[c_champACCESGROUPE_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champACCES_ACCESC_ID)]
		[DynamicField("ACCES_ACCESC_ID")]
		public System.Int32? ACCES_ACCESC_ID
		{
			get
			{
				if (Row[c_champACCES_ACCESC_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champACCES_ACCESC_ID];
			}
			set
			{
				Row[c_champACCES_ACCESC_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champBOUTON_ID)]
		[DynamicField("BOUTON_ID")]
		public System.Int32? BOUTON_ID
		{
			get
			{
				if (Row[c_champBOUTON_ID] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champBOUTON_ID];
			}
			set
			{
				Row[c_champBOUTON_ID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeq.c_nomTable,new string[]{CSpvTypeq.c_champTYPEQ_ID}, new string[]{CSpvVerrou.c_champTYPEQ_ID},false,false)]
		[DynamicField("SpvTypeq")]
		public CSpvTypeq SpvTypeq
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
		[Relation(CSpvCablequ.c_nomTable,new string[]{CSpvCablequ.c_champCABLEQU_ID}, new string[]{CSpvVerrou.c_champCABLEQU_ID},false,false)]
		[DynamicField("SpvCablequ")]
		public CSpvCablequ SpvCablequ
		{
			get
			{
				return (CSpvCablequ) GetParent(new string[]{c_champCABLEQU_ID},typeof(CSpvCablequ));
			}
			set
			{
				SetParent(new string[]{c_champCABLEQU_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvScript.c_nomTable,new string[]{CSpvScript.c_champSCRIPT_ID}, new string[]{CSpvVerrou.c_champSCRIPT_ID},false,false)]
		[DynamicField("SpvScript")]
		public CSpvScript SpvScript
		{
			get
			{
				return (CSpvScript) GetParent(new string[]{c_champSCRIPT_ID},typeof(CSpvScript));
			}
			set
			{
				SetParent(new string[]{c_champSCRIPT_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTop.c_nomTable,new string[]{CSpvTop.c_champTOP_ID}, new string[]{CSpvVerrou.c_champTOP_ID},false,false)]
		[DynamicField("SpvTop")]
		public CSpvTop SpvTop
		{
			get
			{
				return (CSpvTop) GetParent(new string[]{c_champTOP_ID},typeof(CSpvTop));
			}
			set
			{
				SetParent(new string[]{c_champTOP_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvLiai.c_nomTable,new string[]{CSpvLiai.c_champLIAI_ID}, new string[]{CSpvVerrou.c_champLIAI_ID},false,false)]
		[DynamicField("SpvLiai")]
		public CSpvLiai SpvLiai
		{
			get
			{
				return (CSpvLiai) GetParent(new string[]{c_champLIAI_ID},typeof(CSpvLiai));
			}
			set
			{
				SetParent(new string[]{c_champLIAI_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvAffbouton.c_nomTable,new string[]{CSpvAffbouton.c_champAFFBOUTON_ID}, new string[]{CSpvVerrou.c_champAFFBOUTON_ID},false,false)]
		[DynamicField("SpvAffbouton")]
		public CSpvAffbouton SpvAffbouton
		{
			get
			{
				return (CSpvAffbouton) GetParent(new string[]{c_champAFFBOUTON_ID},typeof(CSpvAffbouton));
			}
			set
			{
				SetParent(new string[]{c_champAFFBOUTON_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvRole.c_nomTable,new string[]{CSpvRole.c_champROLE_ID}, new string[]{CSpvVerrou.c_champROLE_ID},false,false)]
		[DynamicField("SpvRole")]
		public CSpvRole SpvRole
		{
			get
			{
				return (CSpvRole) GetParent(new string[]{c_champROLE_ID},typeof(CSpvRole));
			}
			set
			{
				SetParent(new string[]{c_champROLE_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvBouton.c_nomTable,new string[]{CSpvBouton.c_champBOUTON_ID}, new string[]{CSpvVerrou.c_champBOUTON_ID},false,false)]
		[DynamicField("SpvBouton")]
		public CSpvBouton SpvBouton
		{
			get
			{
				return (CSpvBouton) GetParent(new string[]{c_champBOUTON_ID},typeof(CSpvBouton));
			}
			set
			{
				SetParent(new string[]{c_champBOUTON_ID}, value);
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[Relation(CSpvLienAccesAlarmes.c_nomTable,new string[]{CSpvLienAccesAlarmes.c_champACCES_ACCESC_ID}, new string[]{CSpvVerrou.c_champACCES_ACCESC_ID},false,false)]
		[DynamicField("SpvAcces_Accesc")]
		public CSpvLienAccesAlarmes SpvAcces_Accesc
		{
			get
			{
				return (CSpvLienAccesAlarmes) GetParent(new string[]{c_champACCES_ACCESC_ID},typeof(CSpvLienAccesAlarmes));
			}
			set
			{
				SetParent(new string[]{c_champACCES_ACCESC_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvAccesgroupe.c_nomTable,new string[]{CSpvAccesgroupe.c_champACCESGROUPE_ID}, new string[]{CSpvVerrou.c_champACCESGROUPE_ID},false,false)]
		[DynamicField("SpvAccesgroupe")]
		public CSpvAccesgroupe SpvAccesgroupe
		{
			get
			{
				return (CSpvAccesgroupe) GetParent(new string[]{c_champACCESGROUPE_ID},typeof(CSpvAccesgroupe));
			}
			set
			{
				SetParent(new string[]{c_champACCESGROUPE_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvSite.c_nomTable,new string[]{CSpvSite.c_champSITE_ID}, new string[]{CSpvVerrou.c_champSITE_ID},false,false)]
		[DynamicField("SpvSite")]
		public CSpvSite SpvSite
		{
			get
			{
				return (CSpvSite) GetParent(new string[]{c_champSITE_ID},typeof(CSpvSite));
			}
			set
			{
				SetParent(new string[]{c_champSITE_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypliai.c_nomTable,new string[]{CSpvTypliai.c_champTYPLIAI_ID}, new string[]{CSpvVerrou.c_champTYPLIAI_ID},false,false)]
		[DynamicField("SpvTypliai")]
		public CSpvTypliai SpvTypliai
		{
			get
			{
				return (CSpvTypliai) GetParent(new string[]{c_champTYPLIAI_ID},typeof(CSpvTypliai));
			}
			set
			{
				SetParent(new string[]{c_champTYPLIAI_ID}, value);
			}
		}
		
				
		///////////////////////////////////////////////////////////////
		[Relation(CSpvEquip.c_nomTable,new string[]{CSpvEquip.c_champEQUIP_ID}, new string[]{CSpvVerrou.c_champEQUIP_ID},false,false)]
		[DynamicField("SpvEquip")]
		public CSpvEquip SpvEquip
		{
			get
			{
				return (CSpvEquip) GetParent(new string[]{c_champEQUIP_ID},typeof(CSpvEquip));
			}
			set
			{
				SetParent(new string[]{c_champEQUIP_ID}, value);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
        [Relation(CSpvAccesTrans.c_nomTable, new string[] { CSpvAccesTrans.c_champACCES_ID }, new string[] { CSpvVerrou.c_champACCES_ID }, false, false)]
        [DynamicField("SpvAccesTrans")]
		public CSpvAcces SpvAccesTrans
		{
			get
			{
                return (CSpvAccesTrans)GetParent(new string[] { c_champACCES_ID }, typeof(CSpvAccesTrans));
			}
			set
			{
				SetParent(new string[]{c_champACCES_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvTypeService.c_nomTable,new string[]{CSpvTypeService.c_champTYPPROG_ID}, new string[]{CSpvVerrou.c_champTYPPROG_ID},false,false)]
		[DynamicField("SpvTypprog")]
		public CSpvTypeService SpvTypprog
		{
			get
			{
				return (CSpvTypeService) GetParent(new string[]{c_champTYPPROG_ID},typeof(CSpvTypeService));
			}
			set
			{
				SetParent(new string[]{c_champTYPPROG_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvModelcabl.c_nomTable,new string[]{CSpvModelcabl.c_champMODELCABL_ID}, new string[]{CSpvVerrou.c_champMODELCABL_ID},false,false)]
		[DynamicField("SpvModelcabl")]
		public CSpvModelcabl SpvModelcabl
		{
			get
			{
				return (CSpvModelcabl) GetParent(new string[]{c_champMODELCABL_ID},typeof(CSpvModelcabl));
			}
			set
			{
				SetParent(new string[]{c_champMODELCABL_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvLibsymb.c_nomTable,new string[]{CSpvLibsymb.c_champLIBSYMB_ID}, new string[]{CSpvVerrou.c_champLIBSYMB_ID},false,false)]
		[DynamicField("SpvLibsymb")]
		public CSpvLibsymb SpvLibsymb
		{
			get
			{
				return (CSpvLibsymb) GetParent(new string[]{c_champLIBSYMB_ID},typeof(CSpvLibsymb));
			}
			set
			{
				SetParent(new string[]{c_champLIBSYMB_ID}, value);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvService.c_nomTable,new string[]{CSpvService.c_champPROG_ID}, new string[]{CSpvVerrou.c_champPROG_ID},false,false)]
		[DynamicField("SpvProg")]
		public CSpvService SpvProg
		{
			get
			{
				return (CSpvService) GetParent(new string[]{c_champPROG_ID},typeof(CSpvService));
			}
			set
			{
				SetParent(new string[]{c_champPROG_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvAlarmGeree.c_nomTable,new string[]{CSpvAlarmGeree.c_champALARMGEREE_ID}, new string[]{CSpvVerrou.c_champALARMGEREE_ID},false,false)]
		[DynamicField("SpvAlarmgeree")]
		public CSpvAlarmGeree SpvAlarmgeree
		{
			get
			{
				return (CSpvAlarmGeree) GetParent(new string[]{c_champALARMGEREE_ID},typeof(CSpvAlarmGeree));
			}
			set
			{
				SetParent(new string[]{c_champALARMGEREE_ID}, value);
			}
		}
	}
}
