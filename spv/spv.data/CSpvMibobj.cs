using System;
using System.Data;
using sc2i.data;
using sc2i.common;

namespace spv.data
{
	[Table(CSpvMibobj.c_nomTable,CSpvMibobj.c_nomTableInDb,new string[]{ CSpvMibobj.c_champMIBOBJ_ID})]
	[ObjetServeurURI("CSpvMibobjServeur")]
	[DynamicClass("Spv Mib object")]
	public class	CSpvMibobj : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_MIBOBJ";
		public const string c_nomTableInDb = "MIBOBJ";
		public const string c_champMIBOBJ_ID ="MIBOBJ_ID";
		public const string c_champMIBOBJ_CLASSID ="MIBOBJ_CLASSID";
		public const string c_champMIBOBJ_NOM ="MIBOBJ_NOM";
		public const string c_champMIBOBJ_NAME ="MIBOBJ_NAME";
		public const string c_champMIBMODULE_ID ="MIBMODULE_ID";
		public const string c_champMIBMODULE_NAME ="MIBMODULE_NAME";
		public const string c_champMIBOBJ_TYPE ="MIBOBJ_TYPE";
		public const string c_champMIBOBJ_LINENBR ="MIBOBJ_LINENBR";
		public const string c_champMIBOBJ_VISIBLE ="MIBOBJ_VISIBLE";
		public const string c_champMIBOBJ_FATHERNAME ="MIBOBJ_FATHERNAME";
		public const string c_champMIBOBJ_OID ="MIBOBJ_OID";
		public const string c_champMIBOBJ_IANA ="MIBOBJ_IANA";
		public const string c_champMIBOBJ_TRAPNBR ="MIBOBJ_TRAPNBR";
		public const string c_champMIBOBJ_TYPESNMP ="MIBOBJ_TYPESNMP";
		public const string c_champMIBOBJ_CONSTRAINT ="MIBOBJ_CONSTRAINT";
		public const string c_champMIBOBJ_UNIT ="MIBOBJ_UNIT";
		public const string c_champMIBOBJ_ACCESS ="MIBOBJ_ACCESS";
		public const string c_champMIBOBJ_STATUS ="MIBOBJ_STATUS";
		public const string c_champMIBOBJ_DEFVAL ="MIBOBJ_DEFVAL";
		public const string c_champMIBOBJ_INDEX ="MIBOBJ_INDEX";
		public const string c_champMIBOBJ_AUGMENTS ="MIBOBJ_AUGMENTS";
		public const string c_champMIBOBJ_INFO ="MIBOBJ_INFO";
		public const string c_champMIBOBJ_REF ="MIBOBJ_REF";
		public const string c_champMIBOBJ_HINTS ="MIBOBJ_HINTS";
		public const string c_champMIBOBJ_COMMENT ="MIBOBJ_COMMENT";

        // Types d'objets tels que contenus dans MIBOBJ_TYPE
        public const string c_typeVariableScalaire = "VS";
        public const string c_typeVariableTable = "VT";
        public const string c_typeTable = "TAB";
        public const string c_typeTrapV1 = "TRAP";
        public const string c_typeTrapV2 = "TRAP2";

        // Classe de l'objet dans la table
        const int c_classID = 13;

        // Type des objets SNMP dans MibObj
        public const string AutonomousType      = "AutonomousType";
        public const string BITS                = "BITS";
        public const string Counter             = "Counter";
        public const string Counter32           = "Counter32";
        public const string Counter64           = "Counter64";
        public const string DateAndTime         = "DateAndTime";
        public const string DisplayString       = "DisplayString";
        public const string Gauge               = "Gauge";
        public const string Gauge32             = "Gauge32";
        public const string INTEGER             = "INTEGER";
        public const string Integer32           = "Integer32";
        public const string IpAddress           = "IpAddress";
        public const string MacAddress          = "MacAddress";
        public const string NetworkAddress      = "NetworkAddress";
        public const string ObjectIdentifier    = "OBJECT IDENTIFIER";
        public const string OctetString         = "OCTET STRING";
        public const string Opaque              = "Opaque";
        public const string Opaque_double       = "Opaque_double";
        public const string Opaque_float        = "Opaque_float";
        public const string Opaque_I64          = "Opaque_I64";
        public const string Opaque_U64          = "Opaque_U64";
        public const string PhysAddress         = "PhysAddress";
        public const string RowPointer          = "RowPointer";
        public const string RowStatus           = "RowStatus";
        public const string StorageType         = "StorageType";
        public const string TAddress            = "TAddress";
        public const string TDomain             = "TDomain";
        public const string TestAndIncr         = "TestAndIncr";
        public const string TimeInterval        = "TimeInterval";
        public const string TimeStamp           = "TimeStamp";
        public const string TimeTicks           = "TimeTicks";
        public const string TruthValue          = "TruthValue";
        public const string UNKWN               = "UNKWN";
        public const string Unsigned            = "Unsigned";
        public const string Unsigned32          = "Unsigned32";
        public const string VariablePointer     = "VariablePointer";
		
		///////////////////////////////////////////////////////////////
		public CSpvMibobj( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvMibobj( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            Row[c_champMIBOBJ_CLASSID, true] = c_classID;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champMIBOBJ_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("MIB object @1|30035",NomObjetUtilisateur);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_CLASSID)]
		[DynamicField("Class Id")]
		public System.Int32 ClassId
		{
			get
			{
                return (System.Int32)Row[c_champMIBOBJ_CLASSID];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_NOM,128)]
        [DynamicField("User's object name")]
		public System.String NomObjetUtilisateur
		{
			get
			{
				return (System.String)Row[c_champMIBOBJ_NOM];
			}
			set
			{
				Row[c_champMIBOBJ_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_NAME,128)]
        [DynamicField("Official object name")]
		public System.String NomObjetOfficiel
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
		[TableFieldProperty(c_champMIBMODULE_NAME,128)]
        [DynamicField("Official module label")]
		public System.String NomModuleOfficiel
		{
			get
			{
				return (System.String)Row[c_champMIBMODULE_NAME];
			}
			set
			{
				Row[c_champMIBMODULE_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_TYPE,10)]
		[DynamicField("Object type")]
		public System.String TypeObjet
		{
			get
			{
				if (Row[c_champMIBOBJ_TYPE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_TYPE];
			}
			set
			{
				Row[c_champMIBOBJ_TYPE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMIBOBJ_LINENBR, NullAutorise = true)]
		[DynamicField("Definition object line number")]
		public System.Int32? NumeroLigneEnFichier
		{
			get
			{
				if (Row[c_champMIBOBJ_LINENBR] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMIBOBJ_LINENBR];
			}
			set
			{
				Row[c_champMIBOBJ_LINENBR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_VISIBLE)]
		[DynamicField("Object visibility")]
		public Int32 Visibilite
		{
			get
			{
                return (Int32)Row[c_champMIBOBJ_VISIBLE];
			}
			set
			{
				Row[c_champMIBOBJ_VISIBLE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_FATHERNAME,128)]
		[DynamicField("Official object's father label")]
		public System.String NomOfficielObjetPere
		{
			get
			{
				if (Row[c_champMIBOBJ_FATHERNAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_FATHERNAME];
			}
			set
			{
				Row[c_champMIBOBJ_FATHERNAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_OID,256)]
		[DynamicField("Object OID")]
		public System.String OidObjet
		{
			get
			{
				if (Row[c_champMIBOBJ_OID] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_OID];
			}
			set
			{
				Row[c_champMIBOBJ_OID,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_IANA,128)]
		[DynamicField("Enterprise number")]
		public System.String NumeroEntreprise
		{
			get
			{
				if (Row[c_champMIBOBJ_IANA] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_IANA];
			}
			set
			{
				Row[c_champMIBOBJ_IANA,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMIBOBJ_TRAPNBR, NullAutorise = true)]
		[DynamicField("Trap number")]
		public System.Int32? NumeroTrap
		{
			get
			{
				if (Row[c_champMIBOBJ_TRAPNBR] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMIBOBJ_TRAPNBR];
			}
			set
			{
				Row[c_champMIBOBJ_TRAPNBR,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_TYPESNMP,40)]
		[DynamicField("SNMP type")]
		public System.String TypeSnmp
		{
			get
			{
				if (Row[c_champMIBOBJ_TYPESNMP] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_TYPESNMP];
			}
			set
			{
				Row[c_champMIBOBJ_TYPESNMP,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_CONSTRAINT,256)]
		[DynamicField("Constraints")]
		public System.String Contraintes
		{
			get
			{
				if (Row[c_champMIBOBJ_CONSTRAINT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_CONSTRAINT];
			}
			set
			{
				Row[c_champMIBOBJ_CONSTRAINT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_UNIT,40)]
		[DynamicField("Units")]
		public System.String Unites
		{
			get
			{
				if (Row[c_champMIBOBJ_UNIT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_UNIT];
			}
			set
			{
				Row[c_champMIBOBJ_UNIT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_ACCESS,40)]
		[DynamicField("Access rights")]
		public System.String DroitsAcces
		{
			get
			{
				if (Row[c_champMIBOBJ_ACCESS] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_ACCESS];
			}
			set
			{
				Row[c_champMIBOBJ_ACCESS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_STATUS,40)]
		[DynamicField("Status")]
		public System.String Etat
		{
			get
			{
				if (Row[c_champMIBOBJ_STATUS] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_STATUS];
			}
			set
			{
				Row[c_champMIBOBJ_STATUS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_DEFVAL,256)]
		[DynamicField("Default value")]
		public System.String ValeurParDefaut
		{
			get
			{
				if (Row[c_champMIBOBJ_DEFVAL] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_DEFVAL];
			}
			set
			{
				Row[c_champMIBOBJ_DEFVAL,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_INDEX,256)]
		[DynamicField("Index composition")]
		public System.String CompositionIndex
		{
			get
			{
				if (Row[c_champMIBOBJ_INDEX] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_INDEX];
			}
			set
			{
				Row[c_champMIBOBJ_INDEX,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_AUGMENTS,256)]
		[DynamicField("Augments columns")]
		public System.String ColonnesAjoutees
		{
			get
			{
				if (Row[c_champMIBOBJ_AUGMENTS] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_AUGMENTS];
			}
			set
			{
				Row[c_champMIBOBJ_AUGMENTS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_INFO,2000)]
		[DynamicField("Information")]
		public System.String Information
		{
			get
			{
				if (Row[c_champMIBOBJ_INFO] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_INFO];
			}
			set
			{
				Row[c_champMIBOBJ_INFO,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_REF,2000)]
		[DynamicField("Imported mibs")]
		public System.String MibsImportees
		{
			get
			{
				if (Row[c_champMIBOBJ_REF] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_REF];
			}
			set
			{
				Row[c_champMIBOBJ_REF,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_HINTS,2000)]
		[DynamicField("Display informations")]
		public System.String InformationsAffichage
		{
			get
			{
				if (Row[c_champMIBOBJ_HINTS] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_HINTS];
			}
			set
			{
				Row[c_champMIBOBJ_HINTS,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBOBJ_COMMENT,80)]
		[DynamicField("Comment")]
		public System.String Commentaire
		{
			get
			{
				if (Row[c_champMIBOBJ_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBOBJ_COMMENT];
			}
			set
			{
				Row[c_champMIBOBJ_COMMENT,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[Relation(CSpvMibmodule.c_nomTable,new string[]{CSpvMibmodule.c_champMIBMODULE_ID}, new string[]{CSpvMibobj.c_champMIBMODULE_ID},true,true)]
		[DynamicField("Mib module")]
		public CSpvMibmodule ModuleMib
		{
			get
			{
				return (CSpvMibmodule) GetParent(new string[]{c_champMIBMODULE_ID},typeof(CSpvMibmodule));
			}
			set
			{
				SetParent(new string[]{c_champMIBMODULE_ID}, value);
			}
		}
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvMibenum),"ObjetPere")]
        [DynamicField("Enumarated")]
		public CListeObjetsDonnees SpvMibenums
		{
			get
			{
				return GetDependancesListe(CSpvMibenum.c_nomTable,c_champMIBOBJ_ID);
			}
		}

        ///////////////////////////////////////////////////////////////
        public CSpvMibobj ObjetParent
        {
            get
            {
                if (NomObjetOfficiel == NomOfficielObjetPere || NomOfficielObjetPere==null || NomOfficielObjetPere.Trim() == "")
                    return null;
                CSpvMibobj obj = new CSpvMibobj(ContexteDonnee);
                if ( obj.ReadIfExists ( new CFiltreData ( 
                    CSpvMibobj.c_champMIBMODULE_ID+"=@1 and "+
                    CSpvMibobj.c_champMIBOBJ_NAME + "=@2",
                    Row[c_champMIBMODULE_ID],
                    Row[c_champMIBOBJ_FATHERNAME] )))
                    return obj;
                return null;
            }
        }

        [DynamicField("Full name")]
        public string NomOfficielComplet
        {
            get
            {
                string strLibelle = "";
                CSpvMibobj objetParent = ObjetParent;
                if (objetParent == null)
                {
                    if (ModuleMib != null)
                        strLibelle = ModuleMib.NomModuleOfficiel;
                }
                else
                    strLibelle = objetParent.NomOfficielComplet;
                if (strLibelle.Length > 0)
                    strLibelle += "/";
                strLibelle += NomObjetOfficiel;
                return strLibelle;
            }
        }

        public string GetOID()
        {
            if(TypeObjet=="VS")
            {
                string st = OidObjet.TrimEnd('.');
                return st + ".0";
            }
            else
                return OidObjet;
        }
	}
}
