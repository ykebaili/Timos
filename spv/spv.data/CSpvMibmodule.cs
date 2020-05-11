using System;
using System.Data;
using sc2i.data;
using sc2i.common;
using sc2i.documents;
using System.Text;

namespace spv.data
{
	[Table(CSpvMibmodule.c_nomTable,CSpvMibmodule.c_nomTableInDb,new string[]{ CSpvMibmodule.c_champMIBMODULE_ID})]
	[ObjetServeurURI("CSpvMibmoduleServeur")]
	[DynamicClass("Spv Mib Module")]
	public class	CSpvMibmodule : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "SPV_MIBMODULE";
		public const string c_nomTableInDb = "MIBMODULE";
		public const string c_champMIBMODULE_ID ="MIBMODULE_ID";
        public const string c_champFAMILLE_ID = "FAMILLE_ID";
		public const string c_champMIBMODULE_CLASSID ="MIBMODULE_CLASSID";
		public const string c_champMIBMODULE_NOM ="MIBMODULE_NOM";
		public const string c_champMIBMODULE_NAME ="MIBMODULE_NAME";
		public const string c_champMIBMODULE_FIC ="MIBMODULE_FIC";
		public const string c_champMIBMODULE_VERSION ="MIBMODULE_VERSION";
		public const string c_champMIBMODULE_DATE ="MIBMODULE_DATE";
		public const string c_champMIBMODULE_SMI ="MIBMODULE_SMI";
		public const string c_champMIBMODULE_COMPILDATE ="MIBMODULE_COMPILDATE";
		public const string c_champMIBMODULE_COMMENT ="MIBMODULE_COMMENT";
        public const int c_classID = 12;		// Module MIB
		
		///////////////////////////////////////////////////////////////
		public CSpvMibmodule( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		
		///////////////////////////////////////////////////////////////
		public CSpvMibmodule( DataRow row )
			:base(row)
		{
		}
		
		///////////////////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			//TODO : Insérer ici le code d'initalisation
            Row[c_champMIBMODULE_CLASSID] = c_classID;
		}
		
		///////////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] {c_champMIBMODULE_ID};
		}
		
		///////////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T("MIB Module @1|30034", NomModuleUtilisateur);
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_CLASSID)]
		[DynamicField("Class ID")]
		public System.Double ClassId
		{
			get
			{
				return (System.Double)Row[c_champMIBMODULE_CLASSID];
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_NOM,128)]
		[DynamicField("User's module label")]
		public System.String NomModuleUtilisateur
		{
			get
			{
				return (System.String)Row[c_champMIBMODULE_NOM];
			}
			set
			{
				Row[c_champMIBMODULE_NOM,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_NAME,128)]
		[DynamicField("Official module label")]
		public System.String NomModuleOfficiel
		{
			get
			{
				if (Row[c_champMIBMODULE_NAME] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBMODULE_NAME];
			}
			set
			{
				Row[c_champMIBMODULE_NAME,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_FIC,128)]
		[DynamicField("MIB file")]
		public System.String FichierModule
		{
			get
			{
				return (System.String)Row[c_champMIBMODULE_FIC];
			}
			set
			{
				Row[c_champMIBMODULE_FIC,true]=value;
			}
		}

        //-------------------------------------------------------------------
        [Relation(CDocumentGED.c_nomTable, CDocumentGED.c_champId, CDocumentGED.c_champId, false, true)]
        [DynamicField("Mib document file")]
        [NonCloneable]
        public CDocumentGED DocumentGEDModuleMib
        {
            get
            {
                return (CDocumentGED)GetParent(CDocumentGED.c_champId, typeof(CDocumentGED));
            }
            set
            {
                if (value != null)
                    value.IsFichierSysteme = true;
                SetParent(CDocumentGED.c_champId, value);
            }
        }
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_VERSION,40)]
		[DynamicField("MIB version")]
		public System.String Version
		{
			get
			{
				if (Row[c_champMIBMODULE_VERSION] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBMODULE_VERSION];
			}
			set
			{
				Row[c_champMIBMODULE_VERSION,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_DATE,40)]
		[DynamicField("Version date")]
		public System.String DateVersion
		{
			get
			{
				if (Row[c_champMIBMODULE_DATE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBMODULE_DATE];
			}
			set
			{
				Row[c_champMIBMODULE_DATE,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
        [TableFieldProperty(c_champMIBMODULE_SMI, NullAutorise = true)]
		[DynamicField("SMI version")]
		public System.Int32? VersionSmi
		{
			get
			{
				if (Row[c_champMIBMODULE_SMI] == DBNull.Value)
					return null;
				return (System.Int32?)Row[c_champMIBMODULE_SMI];
			}
			set
			{
				Row[c_champMIBMODULE_SMI,true]=value;
			}
		}
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_COMPILDATE,40)]
		[DynamicField("Compilation date")]
		public System.String DateCompilation
		{
			get
			{
				if (Row[c_champMIBMODULE_COMPILDATE] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBMODULE_COMPILDATE];
			}
			set
			{
				Row[c_champMIBMODULE_COMPILDATE,true]=value;
			}
		}
		
		
		///////////////////////////////////////////////////////////////
		[TableFieldProperty(c_champMIBMODULE_COMMENT,128)]
		[DynamicField("Comment")]
		public System.String Commentaire
		{
			get
			{
				if (Row[c_champMIBMODULE_COMMENT] == DBNull.Value)
					return null;
				return (System.String)Row[c_champMIBMODULE_COMMENT];
			}
			set
			{
				Row[c_champMIBMODULE_COMMENT,true]=value;
			}
		}
		
		
		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvMibobj),"ModuleMib")]
        [DynamicField("MIB objects")]
		public CListeObjetsDonnees TousObjets
		{
			get
			{
				return GetDependancesListe(CSpvMibobj.c_nomTable,c_champMIBMODULE_ID);
			}
		}


        [DynamicField("MIB tables")]
        public CListeObjetsDonnees Tables
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees (ContexteDonnee, typeof(CSpvMibTable));
                liste.Filtre = new CFiltreData (CSpvMibTable.c_champMIBMODULE_ID + "=@1 AND " +
                                                CSpvMibTable.c_champMIBOBJ_TYPE + "=@2", this.Id, CSpvMibTable.c_typeTable);
                return liste;
            }
        }


        [DynamicField("MIB scalar variables")]
        public CListeObjetsDonnees VariablesScalaires
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvMibVariable));
                liste.Filtre = new CFiltreData(CSpvMibVariable.c_champMIBMODULE_ID + "=@1 AND " +
                                               CSpvMibVariable.c_champMIBOBJ_TYPE + "=@2", this.Id, CSpvMibVariable.c_typeVariableScalaire);
                return liste;
            }
        }


        [DynamicField("MIB tables variables")]
        public CListeObjetsDonnees VariablesTables
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvMibVariable));
                liste.Filtre = new CFiltreData(CSpvMibVariable.c_champMIBMODULE_ID + "=@1 AND " +
                                               CSpvMibVariable.c_champMIBOBJ_TYPE + "=@2", this.Id, CSpvMibVariable.c_typeVariableTable);
                return liste;
            }
        }


        [DynamicField("MIB traps")]
        public CListeObjetsDonnees Traps
        {
            get
            {
                CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CSpvMibTrap));
                liste.Filtre = new CFiltreData(CSpvMibTrap.c_champMIBMODULE_ID + "=@1 AND (" +
                                               CSpvMibTrap.c_champMIBOBJ_TYPE + "=@2 OR " +
                                               CSpvMibTrap.c_champMIBOBJ_TYPE + "=@3)", 
                                               this.Id, CSpvMibTrap.c_typeTrapV1, CSpvMibTrap.c_typeTrapV2);
                return liste;
            }
        }

		
		///////////////////////////////////////////////////////////////
		[RelationFille(typeof(CSpvTypeq_Mibmodule),"SpvMibmodule")]
        [DynamicField("Equipment type relations")]
		public CListeObjetsDonnees SpvTypeq_Mibmodules
		{
			get
			{
				return GetDependancesListe(CSpvTypeq_Mibmodule.c_nomTable,c_champMIBMODULE_ID);
			}
		}

        ///////////////////////////////////////////////////////////////
        [Relation(CSpvFamilleMibmodule.c_nomTable, new string[] { CSpvFamilleMibmodule.c_champFAMILLE_ID }, new string[] { CSpvMibmodule.c_champFAMILLE_ID }, false, false)]
        [DynamicField("Mother family")]
        public CSpvFamilleMibmodule FamilleMere
        {
            get
            {
                return (CSpvFamilleMibmodule)GetParent(new string[] { c_champFAMILLE_ID }, typeof(CSpvFamilleMibmodule));
            }
            set
            {
                SetParent(new string[] { c_champFAMILLE_ID }, value);
            }
        }

        public static CSpvMibobj GetVariable(CContexteDonnee ctx, string nomVariable, CSpvMibmodule[] modules)
        {
            StringBuilder bl = new StringBuilder();
            foreach (CSpvMibmodule module in modules)
            {
                bl.Append(module.Id);
                bl.Append(",");
            }
            if (bl.Length > 0)
            {
                bl.Remove(bl.Length - 1, 1);
                CFiltreData filtre = new CFiltreData(CSpvMibmodule.c_champMIBMODULE_ID + " in (" +
                    bl.ToString() + ") and " + CSpvMibobj.c_champMIBOBJ_NOM + "=@1",
                    nomVariable);
                CSpvMibobj mibObj = new CSpvMibobj(ctx);
                if (mibObj.ReadIfExists(filtre))
                    return mibObj;
            }
            return null;
        }
            /*CListeObjetsDonnees liste = new CListeObjetsDonnees(ctx, typeof (CSpvMibVariable));
            liste.Filtre = new CFiltreData(CSpvMibobj.c_champMIBOBJ_NAME + "=@1", nomVariable);
            foreach (CSpvMibVariable mibVariable in liste)
            {
                for (int i = 0; i < nomModules.Length; i++ )
                {
                    if (nomModules[i] == mibVariable.NomModuleOfficiel)
                        return mibVariable;
                }
            }
            return null;
        }*/


        public static CSpvMibobj GetVariable(CContexteDonnee ctx, string nomVariable, string[] nomModules)
        {
            StringBuilder bl = new StringBuilder();
            foreach (string nomModule in nomModules)
            {
                bl.Append("'");
                bl.Append(nomModule);
                bl.Append("',");
            }
            if (bl.Length > 0)
            {
                bl.Remove(bl.Length - 1, 1);
                CFiltreData filtre = new CFiltreData(CSpvMibmodule.c_champMIBMODULE_NAME + " in (" +
                    bl.ToString() + ") and " + CSpvMibobj.c_champMIBOBJ_NOM + "=@1",
                    nomVariable);
                CSpvMibobj mibObj = new CSpvMibobj(ctx);
                if (mibObj.ReadIfExists(filtre))
                    return mibObj;
            }
            return null;
        }


        ///////////////////////////////////////////////////////////////
        public CResultAErreur Compile()
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                ISpvMibModuleServeur objServeur = GetLoader() as ISpvMibModuleServeur;
                if (objServeur != null)
                    result = objServeur.Compile(Id);
                return result;      
            }
            catch (Exception ex)
            {
                result.EmpileErreur(ex.Message);
                return result;
            }
        }
        
	}

    public interface ISpvMibModuleServeur
    {
        CResultAErreur Compile(int nIdMibModule);
    }

    
}
