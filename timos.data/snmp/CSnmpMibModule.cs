using System;
using System.Collections;

using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using tiag.client;

using timos.data;
using System.IO;
using System.Text;
using futurocom.snmp.Mib;
using timos.data.snmp;
using futurocom.snmp;

namespace timos.data.snmp
{
	/// <summary>
	/// Stocke les informations concernant une MIB (Management Information Base).<br/>
    /// Une MIB est un ensemble d'informations structurées concernant une entité réseau,<br/>
    /// par exemple un routeur, un commutateur, un serveur, etc.<br/>
    /// Les informations d'une MIB peuvent être récupérées et parfois modifiées<br/>
    /// par l'intermédaire d'un protocole de communication tel que SNMP.
	/// </summary>
    [DynamicClass("Snmp Mib")]
    [Table(CSnmpMibModule.c_nomTable, CSnmpMibModule.c_champId, true)]
	[ObjetServeurURI("CSnmpMibModuleServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
    public class CSnmpMibModule : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete
	{
		public const string c_nomTable = "SNMP_MIB";
		public const string c_champId = "SNMPMIB_ID";
		public const string c_champLibelle = "SNMPMIB_LABEL";
        public const string c_champDescription = "SNMPMIB_DESC";
        public const string c_champModuleId = "SNMPMIB_MODULE_ID";
        public const string c_champDataContenu = "SNMP_MIB_DATA";
        public const string c_champIsStandard = "SNMP_MIB_SYSTEM";

        public const string c_champCacheModule = "SNMP_MODULE_CACHE";

        

		/// /////////////////////////////////////////////
		public CSnmpMibModule( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CSnmpMibModule(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("SNMP MIB : @1|20084",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            IsStandard = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


		

		/// <summary>
		/// Libellé de la MIB
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Description de la mib
        /// </summary>
        [TableFieldProperty(c_champDescription, 1024)]
        [DynamicField("Description")]
        public string Description
        {
            get
            {
                return (string)Row[c_champDescription];
            }
            set
            {
                Row[c_champDescription] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Indicateur comme quoi la MIB fait partie des MIB standards,<br/>
        /// par opposition aux MIB propriétaires des fabricants d'équipements.
        /// </summary>
        [TableFieldProperty ( c_champIsStandard )]
        [DynamicField("IsStandard")]
        public bool IsStandard
        {
            get
            {
                return (bool)Row[c_champIsStandard];
            }
            set
            {
                Row[c_champIsStandard] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// ID du module (doit être unique).
        /// L'identifiant du module MIB est le nom de ce module<br/>
        /// tel qu'il est exprimé dans le fichier texte de la MIB<br/>
        /// elle-même, devant les mots clés : DEFINITIONS ::= BEGIN
        /// </summary>
        [TableFieldProperty(c_champModuleId, 1024)]
        [DynamicField("Module ID")]
        public string ModuleId
        {
            get
            {
                return (string)Row[c_champModuleId];
            }
            set
            {
                Row[c_champModuleId] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// MibModule en binaire
        /// </summary>
        [TableFieldProperty(c_champDataContenu, NullAutorise=true)]
        public CDonneeBinaireInRow DataContenu
        {
            get
            {
                if (Row[c_champDataContenu] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataContenu);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataContenu, donnee);
                }
                object obj = Row[c_champDataContenu];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataContenu] = value;
            }
        }

        //-----------------------------------------------------------
        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champCacheModule, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public IModule ModuleMib
        {
            get
            {
                if (Row[c_champCacheModule] != DBNull.Value)
                    return (IModule)Row[c_champCacheModule];
                IModule module = null;
                CDonneeBinaireInRow data = DataContenu;
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader ( stream );
                        CSerializerReadBinaire serializer = new CSerializerReadBinaire(reader);
                        CResultAErreur result = serializer.TraiteObject<IModule>(ref module);
                        if (!result)
                            module = null;
                        reader.Close();
                        if ( module != null )
                            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheModule, module);
                    }
                    catch ( Exception e )
                    {
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
                return module;
            }
            set
            {
                Row[c_champCacheModule] = DBNull.Value;
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataContenu;
                    data.Donnees = null;
                    DataContenu = data;
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    try
                    {
                        BinaryWriter writer = new BinaryWriter(stream);
                        CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
                        IModule module = value;
                        serializer.TraiteObject<IModule>(ref module);
                        writer.Close();
                        CDonneeBinaireInRow data = DataContenu;
                        data.Donnees = stream.GetBuffer();
                        DataContenu = data;
                    }
                    catch ( Exception e )
                    {
                        CDonneeBinaireInRow data = DataContenu;
                        data.Donnees = null;
                        DataContenu = data;
                    }
                    finally
                    {
                        stream.Close();
                    }
                }
            }
        }

        //-----------------------------------------------------------
        public string[] ToutesDependances
        {
            get
            {
                HashSet<string> set = new HashSet<string>();
                FillDicDependances(set);
                string[] lst = new string[set.Count];
                int n = 0;
                foreach ( string strVal in set )
                    lst[n++] = strVal;
                return lst;
            }
        }

        //-----------------------------------------------------------
        protected void FillDicDependances(HashSet<string> set)
        {
            IModule module = ModuleMib;
            if (module != null)
            {
                foreach (string strDep in module.Dependents)
                {
                    set.Add(strDep);
                    CSnmpMibModule moduleDep = new CSnmpMibModule(ContexteDonnee);
                    if (moduleDep.ReadIfExists(new CFiltreData(c_champModuleId + "=@1", strDep)))
                        moduleDep.FillDicDependances(set);
                }
            }
        }

        /// /////////////////////////////////////////////////////////
        public string[] DependancesManquantes
        {
            get
            {
                List<string> strMiss = new List<string>();
                
                foreach (string strDep in ToutesDependances)
                {
                    CSnmpMibModule mib = new CSnmpMibModule(ContexteDonnee);
                    if (!mib.ReadIfExists(new CFiltreData(CSnmpMibModule.c_champModuleId + "=@1", strDep)))
                    {
                        strMiss.Add(strDep);
                    }
                }
                return strMiss.ToArray();
            }
        }

        //------------------------------------------------------
        /// <summary>
        /// Dépendances manquantes, c'est à dire MIB référencées dans le module MIB courant<br/>
        /// et qui ne figurent pas dans la liste des modules MIB.<br/>
        /// Ces dépendances maquantes sont fournies sous la forme d'une chaîne de caractères.<br/>
        /// Lorsqu'il manque des dépendances, TIMOS ne peut interpréter la MIB courante.
        /// </summary>
        [DynamicField("Missing dependancies")]
        public string DependancesManquantesString
        {
            get
            {
                StringBuilder bl = new StringBuilder();
                foreach (string strDep in DependancesManquantes)
                {
                    bl.Append(strDep);
                    bl.Append(", ");
                }
                if (bl.Length > 0)
                    bl.Remove(bl.Length - 2, 2);
                return bl.ToString();
            }
        }


        /// /////////////////////////////////////////////////////////
        public static CResultAErreurType<IList<IModule>> CompileFile(TextReader textReader)
        {
            CResultAErreurType<IList<IModule>> result = new CResultAErreurType<IList<IModule>>();
            try
            {
                IList<IModule> lst = Parser.Compile(textReader);
                result.Data = lst;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        /// /////////////////////////////////////////////////////////
        public CResultAErreurType<ObjectRegistryBase> GetMibComplete()
        {
            CResultAErreurType<ObjectRegistryBase> resultBase = new CResultAErreurType<ObjectRegistryBase>();
            try
            {
                SimpleObjectRegistry registre = new SimpleObjectRegistry();
                if (!LoadInRegistre(registre))
                {
                    //Regarde s'il y a des modules manquants
                    string[] strDeps = DependancesManquantes;
                    if (strDeps.Length > 0)
                    {
                        resultBase.EmpileErreur(I.T("Can not compile this module because of missing dependancies|20254"));
                    }
                    else
                        resultBase.EmpileErreur(I.T("Can not compile this module|20255"));
                }
                else
                    resultBase.DataType = registre;
            }
            catch (Exception e)
            {
                resultBase.EmpileErreur(new CErreurException(e));
            }
            return resultBase;
        }

        /// /////////////////////////////////////////////////////////
        public bool LoadInRegistre ( ObjectRegistryBase registre )
        {
            IModule module = ModuleMib;
            List<IModule> lstModules = new List<IModule>();
            if ( module != null )
            {
                HashSet<string> lstDeps = new HashSet<string>();
                lstDeps.Add(ModuleId);
                lstModules.Add ( module );
                CListeObjetDonneeGenerique<CSnmpMibModule> lstStd = new CListeObjetDonneeGenerique<CSnmpMibModule>(ContexteDonnee);
                lstStd.Filtre = new CFiltreData(c_champIsStandard + "=@1", true);
                foreach (CSnmpMibModule std in lstStd)
                {
                    lstDeps.Add(std.ModuleId);
                    foreach (string strId in std.ToutesDependances)
                        lstDeps.Add(strId);
                }
                foreach (string strDep in ToutesDependances)
                    lstDeps.Add(strDep);
                foreach ( string strModule in lstDeps )
                {
                    CSnmpMibModule depend = new CSnmpMibModule ( ContexteDonnee );
                    if ( depend.ReadIfExists ( new CFiltreData ( CSnmpMibModule.c_champModuleId+"=@1", strModule ) ))
                        lstModules.Add ( depend.ModuleMib );
                }
            }
            registre.Import ( lstModules );
            registre.Refresh();
            return registre.Tree.LoadedModules.Contains ( ModuleId );
        }
	}
}
