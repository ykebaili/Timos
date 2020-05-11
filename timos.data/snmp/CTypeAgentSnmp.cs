using System;
using System.Collections;
using System.Linq;
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
using futurocom.easyquery;
using futurocom.snmp.alarme;
using futurocom.snmp.entitesnmp;
using sc2i.common.memorydb;
using timos.data.supervision;
using sc2i.expression.FonctionsDynamiques;

namespace timos.data.snmp
{
	/// <summary>
	/// Le type d'agent SNMP permet de préparer tout le paramétrage nécessaire<br/>
    /// au bon fonctionnement des <see cref="CAgentSnmp">agents SNMP</see> de ce type :
    /// <ul>
    /// <li>Les <see cref="CSnmpMibModule">modules MIB</see> gérés,</li>
    /// <li>Les <see cref="CTypeEntiteSnmp">types d'entités SNMP</see></li>
    /// <li>Les handlers de traps</li>
    /// </ul>
	/// </summary>
    [DynamicClass("Snmp Agent Type")]
    [Table(CTypeAgentSnmp.c_nomTable, CTypeAgentSnmp.c_champId, true)]
	[ObjetServeurURI("CTypeAgentSnmpServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParametrageSnmp_ID)]
	public class CTypeAgentSnmp : CObjetDonneeAIdNumeriqueAuto,
		IObjetALectureTableComplete,
        IElementADonneePourMediationSNMP
	{
		public const string c_nomTable = "SNMP_AGENT_TYPE";
		public const string c_champId = "SNMPAGTTP_ID";
        public const string c_champLibelle = "SNMPAGTTP_LABEL";
        public const string c_champDescription = "SNMPAGTTP_DESC";

        public const string c_champDataQueries = "SNMPAGTTP_QUERIES";
        public const string c_champCacheQueries = "SNMPAGTTP_CACHE_QUERIES";

        public const string c_champDataHandlers = "SNMPAGTTP_HANDLERS";
        public const string c_champCacheHandlers = "SNMPAGTTP_CACHE_HANDLERS";

        public const string c_champDataFonctions = "SNMPAGTTP_FUNCTIONS";
        public const string c_champCacheFonctions = "SNMPAGTTP_CACHE_FUNCTIONS";

        public const string c_champLastModif = "SNMPAGTTP_LAST_UPDATED";

        public const string c_champDataAgentFinders = "SNMPAGTTP_FINDERS";
        public const string c_champCacheAgentFinders = "SNMPAGTTP_CACHE_FINDERS";

       
		/// /////////////////////////////////////////////
		public CTypeAgentSnmp( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CTypeAgentSnmp(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Snmp agent type : @1|20084",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{

		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


        /// /////////////////////////////////////////////
        [TableFieldProperty ( c_champLastModif, NullAutorise=true)]
        public CDateTimeEx LastUpdated
        {
            get
            {
                if (Row[c_champLastModif] == DBNull.Value)
                    return null;
                return new CDateTimeEx ((DateTime)Row[c_champLastModif]);
            }
            set
            {
                if ( value == null )
                    Row[c_champLastModif] = DBNull.Value;
                else
                    Row[c_champLastModif] = value.DateTimeValue;
            }
        }

		/// <summary>
		/// Nom du type d'agent
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
        /// Description du type d'agent
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
        /// Retourne la liste des relations entre ce type d'agent<br/>
        /// et les modules MIB nécessaires à son paramétrage.
        /// </summary>
        [RelationFille(typeof(CRelationTypeAgentSnmp_MibModule), "TypeAgent")]
        [DynamicChilds("Mibs modules relations", typeof(CRelationTypeAgentSnmp_MibModule))]
        public CListeObjetsDonnees RelationsModulesMib
        {
            get
            {
                return GetDependancesListe(CRelationTypeAgentSnmp_MibModule.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------------
        public IDefinition GetRootDefinitionFromMibs()
        {
            SimpleObjectRegistry reg = new SimpleObjectRegistry();
            foreach (CRelationTypeAgentSnmp_MibModule rel in RelationsModulesMib)
            {
                rel.MibModule.LoadInRegistre(reg);
            }
            return reg.Tree.Root;
        }

        //-----------------------------------------------------------
        public override void BeginEdit()
        {
            base.BeginEdit();
            Row[c_champCacheHandlers] = DBNull.Value;
        }

        //-----------------------------------------------------------
        public override CResultAErreur CommitEdit()
        {
            CResultAErreur result = base.CommitEdit();
            if (result)
                Row[c_champCacheHandlers] = DBNull.Value;
            return result;
        }

        #region Queries
        //-----------------------------------------------------------
        public IEnumerable<CEasyQuery> Queries
        {
            get
            {
                return QueriesList.AsReadOnly();
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheQueries, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public  List<CEasyQuery> QueriesList
        {
            get
            {
                if (Row[c_champCacheQueries] != DBNull.Value)
                    return (List<CEasyQuery>)Row[c_champCacheQueries];
                CDonneeBinaireInRow data = DataQueries;
                List<CEasyQuery> lstQueries = new List<CEasyQuery>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        
                        CResultAErreur result = ser.TraiteListe<CEasyQuery>(lstQueries);
                        if (!result)
                            lstQueries.Clear();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheQueries, lstQueries);
                return lstQueries;
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddQuery ( CEasyQuery query )
        {
            QueriesList.Add(query);
            CommitQueries();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveQuery(CEasyQuery query)
        {
            QueriesList.Remove(query);
            CommitQueries();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitQueries()
        {
            List<CEasyQuery> lstQueries = QueriesList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheQueries, DBNull.Value);
            CDonneeBinaireInRow data = DataQueries;
            if (lstQueries == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CEasyQuery>(lstQueries);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataQueries = data;
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataQueries, NullAutorise = true)]
        public CDonneeBinaireInRow DataQueries
        {
            get
            {
                if (Row[c_champDataQueries] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataQueries);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataQueries, donnee);
                }
                object obj = Row[c_champDataQueries];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataQueries] = value;
            }
        }
        #endregion

        #region Trap Handlers
        //-----------------------------------------------------------
        public IEnumerable<CTrapHandler> TrapHandlers
        {
            get
            {
                return TrapHandlerList.AsReadOnly();
            }
        }


        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheHandlers, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CTrapHandler> TrapHandlerList
        {
            get
            {
                if (Row[c_champCacheHandlers] != DBNull.Value)
                    return (List<CTrapHandler>)Row[c_champCacheHandlers];
                CDonneeBinaireInRow data = DataHandlers;
                List<CTrapHandler> lstHandlers = new List<CTrapHandler>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
                        CResultAErreur result = ser.TraiteListe<CTrapHandler>(lstHandlers, db);
                        if (!result)
                            lstHandlers.Clear();
                        db.AcceptChanges();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheHandlers, lstHandlers);
                return lstHandlers;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataHandlers, NullAutorise = true)]
        public CDonneeBinaireInRow DataHandlers
        {
            get
            {
                if (Row[c_champDataHandlers] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataHandlers);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataHandlers, donnee);
                }
                object obj = Row[c_champDataHandlers];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataHandlers] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddTrapHandler(CTrapHandler handler)
        {
            TrapHandlerList.Add(handler);
            CommitHandlers();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveTrapHandler(CTrapHandler handler)
        {
            TrapHandlerList.Remove(handler);
            CommitHandlers();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitHandlers()
        {
            List<CTrapHandler> lstHandlers = TrapHandlerList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheHandlers, DBNull.Value);
            CDonneeBinaireInRow data = DataHandlers;
            if (lstHandlers == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CTrapHandler>(lstHandlers);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataHandlers = data;
        }

        #endregion

        #region Fonctions Dynamiques
        //-----------------------------------------------------------
        public IEnumerable<CFonctionDynamique> FonctionsDynamiques
        {
            get
            {
                return FonctionsDynamiquesList.AsReadOnly();
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheFonctions, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CFonctionDynamique> FonctionsDynamiquesList
        {
            get
            {
                if (Row[c_champCacheFonctions] != DBNull.Value)
                    return (List<CFonctionDynamique>)Row[c_champCacheFonctions];
                CDonneeBinaireInRow data = DataFonctionsDynamiques;
                List<CFonctionDynamique> lstFonctions = new List<CFonctionDynamique>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
                        CResultAErreur result = ser.TraiteListe<CFonctionDynamique>(lstFonctions);
                        if (!result)
                            lstFonctions.Clear();
                        db.AcceptChanges();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFonctions, lstFonctions);
                return lstFonctions;
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddFonctionDynamique(CFonctionDynamique fonction)
        {
            CFonctionDynamique existante = FonctionsDynamiquesList.FirstOrDefault ( f=>f.IdFonction == fonction.IdFonction );
            if (existante != null)
                FonctionsDynamiquesList.Remove(existante);
            FonctionsDynamiquesList.Add(fonction);
            CommitFonctionsDynamiques();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveFonctionDynamique(CFonctionDynamique fonction)
        {
            FonctionsDynamiquesList.Remove(fonction);
            CommitFonctionsDynamiques();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitFonctionsDynamiques()
        {
            List<CFonctionDynamique> lstFonctions = FonctionsDynamiquesList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFonctions, DBNull.Value);
            CDonneeBinaireInRow data = DataFonctionsDynamiques;
            if (lstFonctions == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CFonctionDynamique>(lstFonctions);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataFonctionsDynamiques = data;
        }


        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataFonctions, NullAutorise = true)]
        public CDonneeBinaireInRow DataFonctionsDynamiques
        {
            get
            {
                if (Row[c_champDataFonctions] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataFonctions);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataFonctions, donnee);
                }
                object obj = Row[c_champDataFonctions];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataFonctions] = value;
            }
        }

        #endregion

        #region Agent Finders
        //-----------------------------------------------------------
        public IEnumerable<CAgentFinderFromKey> AgentFinders
        {
            get
            {
                return AgentFinderList.AsReadOnly();
            }
        }


        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheAgentFinders, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CAgentFinderFromKey> AgentFinderList
        {
            get
            {
                if (Row[c_champCacheAgentFinders] != DBNull.Value)
                    return (List<CAgentFinderFromKey>)Row[c_champCacheAgentFinders];
                CDonneeBinaireInRow data = DataAgentFinders;
                List<CAgentFinderFromKey> lstFinders = new List<CAgentFinderFromKey>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        CMemoryDb db = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
                        CResultAErreur result = ser.TraiteListe<CAgentFinderFromKey>(lstFinders, db);
                        if (!result)
                            lstFinders.Clear();
                        db.AcceptChanges();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheAgentFinders, lstFinders);
                return lstFinders;
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champDataAgentFinders, NullAutorise = true)]
        public CDonneeBinaireInRow DataAgentFinders
        {
            get
            {
                if (Row[c_champDataAgentFinders] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champDataAgentFinders);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champDataAgentFinders, donnee);
                }
                object obj = Row[c_champDataAgentFinders];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champDataAgentFinders] = value;
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddAgentFinder(CAgentFinderFromKey agentFinder)
        {
            AgentFinderList.Add(agentFinder);
            CommitFinders();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveAgentFinder(CAgentFinderFromKey agentFinder)
        {
            AgentFinderList.Remove(agentFinder);
            CommitFinders();
        }

        /// /////////////////////////////////////////////////////////
        public void CommitFinders()
        {
            List<CAgentFinderFromKey> lstFinders = AgentFinderList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheAgentFinders, DBNull.Value);
            CDonneeBinaireInRow data = DataAgentFinders;
            if (lstFinders == null)
            {
                data.Donnees = null;
            }
            else
            {
                MemoryStream stream = new MemoryStream();
                try
                {
                    BinaryWriter writer = new BinaryWriter(stream);
                    CSerializerSaveBinaire ser = new CSerializerSaveBinaire(writer);
                    CResultAErreur result = ser.TraiteListe<CAgentFinderFromKey>(lstFinders);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataAgentFinders = data;
        }

        #endregion


        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des types d'entités SNMP<br/>
        /// contenus dans ce type d'agent.
        /// </summary>
        [RelationFille(typeof(CTypeEntiteSnmp), "TypeAgentSnmp")]
        [DynamicChilds("Entities types", typeof(CTypeEntiteSnmp))]
        public CListeObjetsDonnees TypesEntites
        {
            get
            {
                return GetDependancesListe(CTypeEntiteSnmp.c_nomTable, c_champId);
            }
        }

        /// /////////////////////////////////////////////////////////
        public CListeObjetsDonnees TypesEntitesRacine
        {
            get{
                CListeObjetsDonnees lst = TypesEntites;
                lst.FiltrePrincipal = CFiltreData.GetAndFiltre ( 
                    lst.FiltrePrincipal,
                    new CFiltreData ( CTypeEntiteSnmp.c_champIdTypeParent+" is null"));
                return lst;
            }
        }

        /// /////////////////////////////////////////////////////////
        public CTypeAgentPourSupervision GetTypeAgentPourSupervision(CMemoryDb database)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CTypeAgentPourSupervision typeAgent = new CTypeAgentPourSupervision(database);
            if (!typeAgent.ReadIfExist(Id.ToString(), false))
                typeAgent.CreateNew(Id.ToString());
            else
                if (!typeAgent.IsToRead())
                    return typeAgent;
            typeAgent.Row[CMemoryDb.c_champIsToRead] = false;
            foreach (CEasyQuery query in Queries)
                typeAgent.AddQuery(query);
            typeAgent.Fonctions = FonctionsDynamiques;
            foreach (CTrapHandler handler in TrapHandlers)
            {
                database.ImporteObjet(handler, true, false);
            }
            foreach (CTypeEntiteSnmp typeEntite in TypesEntites)
            {
                if (typeEntite.TypeParent == null)
                {
                    typeEntite.GetTypeEntitePourSupervision(database, true);
                }
            }
            foreach ( CAgentFinderFromKey finder in AgentFinders )
            {
                database.ImporteObjet(finder, true, false);
            }
            return typeAgent;
        }



        //------------------------------------------------------
        /// <summary>
        /// Mise à jour de tous les agents
        /// </summary>
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get { return null; }
        }

        //------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                return new int[0];
            }
        }

        //------------------------------------------
        /// <summary>
        /// Indicateur de lecture seule. Est à VRAI si un type d'entité SNMP<br/>
        /// est en lecture seule.
        /// </summary>
        [DynamicField("Read only")]
        public bool ReadOnly
        {
            get
            {
                foreach (CTypeEntiteSnmp typeEntite in TypesEntites)
                    if (!typeEntite.ReadOnly)
                        return false;
                return true;
            }
        }


    }
}
