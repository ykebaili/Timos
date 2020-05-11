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
using futurocom.snmp.dynamic;
using futurocom.easyquery.snmp;
using sc2i.data.dynamic;
using System.Net;
using timos.data.snmp.Proxy;
using sc2i.common.memorydb;
using timos.data.supervision;
using futurocom.snmp.polling;
using futurocom.snmp.HotelPolling;
using timos.data.snmp.polling;

namespace timos.data.snmp
{
	/// <summary>
    /// Un objet 'agent SNMP' est le pendant, côté TIMOS, d'un agent SNMP présent sur un équipement<br/>
    /// (désigné sous l'appellation de 'agent physique' dans TIMOS).<br/>
    /// L'objet 'agent SNMP' porte les propriétés permettant de dialoguer, suivant le protocole SNMP,<br/>
    /// avec l'agent SNMP physique.<br/>
    /// L'objet 'agent SNMP' permet de stocker tout ou partie d'une MIB présentée par l'agent SNMP physique,<br/>
    /// en fonction du paramétrage effectué au niveau du <see cref="CTypeAgentSnmp">type d'agent SNMP</see>.<br/>
    /// Les éléments de ce stockage sont les <see cref="CEntiteSnmp">entités SNMP</see>.
	/// </summary>
    [DynamicClass("Snmp Agent")]
    [Table(CAgentSnmp.c_nomTable, CAgentSnmp.c_champId, true)]
    [ObjetServeurURI("CAgentSnmpServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleSNMP)]
    [AutoExec("Autoexec")]
    public class CAgentSnmp : CObjetDonneeAIdNumeriqueAuto, IConteneurEntitesSnmp, IElementADonneePourMediationSNMP
    {

        public const string c_nomTable = "SNMP_AGENT";
        public const string c_champId = "SNMPAGTTID";
        public const string c_champLibelle = "SNMPAGT_LABEL";
        public const string c_champSnmpIp = "SNMPAGT_IP";
        public const string c_champSnmpCommunaute = "SNMPAGT_COMMUNITY";
        public const string c_champSnmpVersion = "SNMPAGT_VERSION";
        public const string c_champSnmpPort = "SNMPAGT_PORT";
        public const string c_champTimeout = "SNMPAGT_TIMEOUT";
        public const string c_champAutoUpdateToSnmp = "SNMPAGT_AUTO_UPDATE";
        public const string c_champLastUpdateToSnmp = "SNMPAGT_DT_TO_PHYS";
        public const string c_champLastUpdateFromSnmp = "SNMPAGT_DT_FR_PHYS";
        public const string c_champTrapsIp = "SNMPAGT_TRAPS_IPS";
        public const string c_champParametresPolling = "SNMPAGT_POLL_SETUPS";
        public const string c_champParametresHotelPolling = "SNMPAGT_HOT_POLL_SETUPS";

        public const string c_roleChampCustom = "SNMPAGT";

        public const string c_champCacheParametresPolling = "SNMPAGT_CACHE_POLL";
        public const string c_champCacheParametresHotelPolling = "SNMPAGT_CACHE_HOT_POLL";

        /// /////////////////////////////////////////////
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Snmp agent", typeof(CAgentSnmp));
        }

        /// /////////////////////////////////////////////
        public CAgentSnmp(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CAgentSnmp(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T("Snmp Agent : @1|20094", Libelle);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            SnmpVersion = VersionCode.V1;
            SnmpCommunaute = "public";
            SnmpPort = 161;
            AutoUpdate = false;
            Timeout = 300;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }




        /// /////////////////////////////////////////////
        /// <summary>
        /// Nom de l'agent SNMP
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

        //-------------------------------------------------
        /// <summary>
        /// Indique, si VRAI, que la mise à jour de l'agent SNMP physique<br/>
        /// est automatique à la validation de l'objet 'agent SNMP';<br/>
        /// Dans ce cas, les requêtes Snmp SET, sont envoyés vers l'agent<br/>
        /// SNMP physique pour mise à jour de sa MIB.
        /// </summary>
        [TableFieldProperty(c_champAutoUpdateToSnmp)]
        [DynamicField("AutoUpdate Snmp agent")]
        public bool AutoUpdate
        {
            get
            {
                return (bool)Row[c_champAutoUpdateToSnmp];
            }
            set
            {
                Row[c_champAutoUpdateToSnmp] = value;
            }
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Date de dernière mise à jour de l'objet 'agent SNMP'<br/>
        /// depuis l'agent SNMP physique.
        /// </summary>
        [TableFieldProperty(c_champLastUpdateFromSnmp, NullAutorise = true)]
        [DynamicField("Last update from physical date")]
        public CDateTimeEx LastUpdateDateFromSNMP
        {
            get
            {
                if (Row[c_champLastUpdateFromSnmp] == DBNull.Value)
                    return null;
                return new CDateTimeEx((DateTime)Row[c_champLastUpdateFromSnmp]);
            }
            set
            {
                if (value == null)
                    Row[c_champLastUpdateFromSnmp] = DBNull.Value;
                else
                    Row[c_champLastUpdateFromSnmp] = value.DateTimeValue;
            }
        }


        //----------------------------------------------------------------
        /// <summary>
        /// Date de dernière mise à jour de l'agent SNMP physique<br/>
        /// depuis l'objet 'agent SNMP'.
        /// </summary>
        [TableFieldProperty(c_champLastUpdateToSnmp, NullAutorise = true)]
        [DynamicField("Last update to physical date")]
        public CDateTimeEx LastUpdateDateToSNMP
        {
            get
            {
                if (Row[c_champLastUpdateToSnmp] == DBNull.Value)
                    return null;
                return new CDateTimeEx((DateTime)Row[c_champLastUpdateToSnmp]);
            }
            set
            {
                if (value == null)
                    Row[c_champLastUpdateToSnmp] = DBNull.Value;
                else
                    Row[c_champLastUpdateToSnmp] = value.DateTimeValue;
            }
        }

        /// /////////////////////////////////////////////

        //-------------------------------------------------------------------
        /// <summary>
        /// Type de l'agent SNMP
        /// </summary>
        [Relation(
            CTypeAgentSnmp.c_nomTable,
            CTypeAgentSnmp.c_champId,
            CTypeAgentSnmp.c_champId,
            true,
            false,
            true)]
        [DynamicField("Agent Type")]
        public CTypeAgentSnmp TypeAgent
        {
            get
            {
                return (CTypeAgentSnmp)GetParent(CTypeAgentSnmp.c_champId, typeof(CTypeAgentSnmp));
            }
            set
            {
                SetParent(CTypeAgentSnmp.c_champId, value);
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Adresse IP principale de l'agent SNMP physique
        /// </summary>
        [TableFieldProperty(c_champSnmpIp, 64)]
        [DynamicField("IP Address")]
        public string SnmpIp
        {
            get
            {
                return (string)Row[c_champSnmpIp];
            }
            set
            {
                Row[c_champSnmpIp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Adresses IP secondaires (pour les traps) de l'agent SNMP physique.<br/>
        /// Un agent SNMP physique peut avoir plusieurs interfaces réseau<br/>
        /// afin de communiquer; ainsi, si l'une tombe en panne, le dialogue<br/>
        /// peut se poursuivre sur une autre.<br/>
        /// Il est possible de définir plusieurs adresses IP secondaires,<br/>
        /// elles sont séparées les unes des autres par le caractère ",".<br/>
        /// Ces adresses IP secondaires ne sont prises en compte par TIMOS<br/>
        /// que pour la réception des traps.
        /// </summary>
        [TableFieldProperty(c_champTrapsIp, 1024)]
        [DynamicField("Traps ips string")]
        public string TrapsIpsString
        {
            get
            {
                return (string)Row[c_champTrapsIp];
            }
            set
            {
                Row[c_champTrapsIp] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Tableau des adresses IP secondaires de l'agent SNMP physique<br/>
        /// (pour la réception des traps)<br/>
        /// (cf. Traps ips string).
        /// </summary>
        [DynamicField("Traps ips")]
        public String[] TrapsIps
        {
            get
            {
                List<string> lst = new List<string>();
                foreach (string strIp in TrapsIpsString.Split(','))
                    if (strIp.Length > 0)
                        lst.Add(strIp);
                return lst.ToArray();
            }
            set
            {
                StringBuilder bl = new StringBuilder();
                foreach (string strIp in value)
                {
                    bl.Append(',');
                    bl.Append(strIp);
                }
                bl.Append(',');
                TrapsIpsString = bl.ToString();
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Communauté SNMP à utiliser pour le dialogue avec l'agent SNMP physique
        /// </summary>
        [TableFieldProperty(c_champSnmpCommunaute, 64)]
        [DynamicField("Snmp Community")]
        public string SnmpCommunaute
        {
            get
            {
                return (string)Row[c_champSnmpCommunaute];
            }
            set
            {
                Row[c_champSnmpCommunaute] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Version SNMP à utiliser pour le dialogue avec l'agent SNMP physique :<br/>
        /// <ul>
        /// <li>0 : V1</li>
        /// <li>1 : V2C (V2 classic</li>
        /// <li>2 : V2U (version obsolète remplacée par V3</li>
        /// <li>3 : V3</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champSnmpVersion)]
        [DynamicField("Snmp Version")]
        public int SnmpVersionInt
        {
            get
            {
                return (int)Row[c_champSnmpVersion];
            }
            set
            {
                Row[c_champSnmpVersion] = value;
            }
        }

        //-----------------------------------------------------------
        public VersionCode SnmpVersion
        {
            get
            {
                return (VersionCode)SnmpVersionInt;
            }
            set
            {
                SnmpVersionInt = (int)value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Port SNMP pour l'interrogation (classiquement 161)
        /// </summary>
        [TableFieldProperty(c_champSnmpPort)]
        [DynamicField("Snmp Port")]
        public int SnmpPort
        {
            get
            {
                return (int)Row[c_champSnmpPort];
            }
            set
            {
                Row[c_champSnmpPort] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Timeout (en ms) avant de déclarer qu'il y a absence de réponse<br/>
        /// à une commande SNMP
        /// </summary>
        [TableFieldProperty(c_champTimeout)]
        [DynamicField("Timeout")]
        public int Timeout
        {
            get
            {
                return (int)Row[c_champTimeout];
            }
            set
            {
                Row[c_champTimeout] = value;
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des entités SNMP présentes sur l'objet 'agent SNMP'
        /// </summary>
        [RelationFille(typeof(CEntiteSnmp), "AgentSnmp")]
        [DynamicChilds("Snmp Entities", typeof(CEntiteSnmp))]
        public CListeObjetsDonnees EntitesSnmp
        {
            get
            {
                return GetDependancesListe(CEntiteSnmp.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        [DynamicMethod("Returns entities with specified type", "entities to return type")]
        public CEntiteSnmp[] GetSnmpEntitiesWithType(CTypeEntiteSnmp type)
        {
            CListeObjetsDonnees lst = EntitesSnmp;
            if (type != null)
                lst.FiltrePrincipal = CFiltreData.GetAndFiltre(lst.FiltrePrincipal,
                    new CFiltreData(CTypeEntiteSnmp.c_champId + "=@1",
                        type.Id));
            return lst.ToArray<CEntiteSnmp>();
        }

        //---------------------------------------------
        public CListeObjetsDonnees EntitesRacines
        {
            get
            {
                CListeObjetsDonnees lst = EntitesSnmp;
                lst.FiltrePrincipal = CFiltreData.GetAndFiltre(lst.FiltrePrincipal,
                    new CFiltreData(CEntiteSnmp.c_champIdParent + " is null"));
                return lst;
            }
        }

        //---------------------------------------------

        /// /////////////////////////////////////////////
        public CAgentSnmpPourSupervision GetAgentPourSupervision(CMemoryDb database, bool bAvecEntites)
        {
            if (database == null)
                database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CAgentSnmpPourSupervision agent = new CAgentSnmpPourSupervision(database);
            if (!agent.ReadIfExist(Id.ToString(), false))
                agent.CreateNew(Id.ToString());
            else
                if (!agent.IsToRead())
                    return agent;
            agent.Row[CMemoryDb.c_champIsToRead] = false;
            CTypeAgentPourSupervision typeAgent = TypeAgent.GetTypeAgentPourSupervision(database);
            agent.TypeAgent = typeAgent;
            agent.Ip = SnmpIp;
            agent.Timeout = Timeout;
            agent.SnmpPort = SnmpPort;
            agent.SnmpVersion = SnmpVersion;
            agent.Communaute = SnmpCommunaute;
            agent.TrapsIpString = TrapsIpsString;
            foreach (CSnmpPollingSetup setup in ParametresPolling)
            {
                CSnmpPollingSetup newSetup = database.ImporteObjet(setup, true, false) as CSnmpPollingSetup;
                newSetup.Agent = agent;
            }
            foreach (CSnmpHotelPollingSetup setup in ParametresHotelPolling)
            {
                CSnmpHotelPollingSetup newSetup = database.ImporteObjet(setup, true, false) as CSnmpHotelPollingSetup;
                newSetup.Agent = agent;
            }
            if (bAvecEntites)
            {
                foreach (CEntiteSnmp entite in EntitesSnmp)
                {
                    if (entite.EntiteSnmpParente == null)
                    {
                        CTypeEntiteSnmpPourSupervision typeEntite = typeAgent.TypesEntites.FirstOrDefault(te => te.Id == entite.TypeEntiteSnmp.Id.ToString());
                        if (typeEntite != null)
                        {
                            CEntiteSnmpPourSupervision ett = entite.GetEntitePourSupervision(typeEntite);
                            if (ett != null)
                                ett.AgentSnmp = agent;
                        }
                    }
                }
            }
            return agent;
        }

        //-------------------------------------------------------------
        /// <summary>
        /// Fonction permettant de mettre à jour l'objet 'agent SNMP'<br/>
        /// à partir de l'agent SNMP physique, en interrogeant ce dernier.
        /// </summary>
        /// <param name="bDeleteUnexistingEntities">TRUE, si les entités SNMP disparues sur l'agent physique<br/>
        /// doivent être effacées de l'objet 'agent SNMP'</param>
        /// <returns></returns>
        [DynamicMethod("Update datas from physical agent", "true if missing SNMP entites should be deleted")]
        public bool UpdateFromPhysicalAgent(bool bDeleteUnexistingEntities)
        {
            BeginEdit();
            CResultAErreur result = InitEntitesFromSnmpInContexteCourant();
            if (!result)
            {
                CancelEdit();
                return false;
            }
            if (bDeleteUnexistingEntities)
            {
                CListeObjetsDonnees lstEntites = EntitesSnmp;
                lstEntites.Filtre = new CFiltreData(CEntiteSnmp.c_champFromSnmp + "=@1", false);
                result = CObjetDonneeAIdNumerique.Delete(lstEntites, true);
                if (!result)
                {
                    CancelEdit();
                    return false;
                }
            }
            result = CommitEdit();
            if (!result)
                CancelEdit();
            return result.Result;
        }


        /// /////////////////////////////////////////////
        public CResultAErreur InitEntitesFromSnmpInContexteCourant()
        {
            CResultAErreur result = CResultAErreur.True;
            CMemoryDb database = CMemoryDbPourSupervision.GetMemoryDb(ContexteDonnee);
            CAgentSnmpPourSupervision agent = GetAgentPourSupervision(database, false);
            if (agent != null)
            {
                result = agent.FillFromSNMP(new CInterrogateurSnmp());
                if (result)
                    result = MapEntitesFromSNMP(agent);
            }
            if (result)
                LastUpdateDateFromSNMP = DateTime.Now;
            return result;
        }

        /// /////////////////////////////////////////////
        private CResultAErreur MapEntitesFromSNMP(CAgentSnmpPourSupervision agent)
        {
            CResultAErreur result = CResultAErreur.True;
            HashSet<int> entitesVues = new HashSet<int>();
            CListeObjetsDonnees lstEntites = EntitesSnmp;

            foreach (CEntiteSnmpPourSupervision entiteFromSnmp in agent.Entites)
            {
                CEntiteSnmp entite = new CEntiteSnmp(ContexteDonnee);
                lstEntites.Filtre = new CFiltreData(CEntiteSnmp.c_champIndex + "=@1 and " +
                    CTypeEntiteSnmp.c_champId + "=@2",
                    entiteFromSnmp.Index,
                    entiteFromSnmp.TypeEntite.Id);
                if (lstEntites.Count == 0)
                {
                    entite = new CEntiteSnmp(ContexteDonnee);
                    entite.CreateNewInCurrentContexte();
                    entite.AgentSnmp = this;
                }
                else
                    entite = lstEntites[0] as CEntiteSnmp;
                result = entite.FillFromSnmp(entiteFromSnmp);
                if (!result)
                    return result;
                entitesVues.Add(entite.Id);
            }
            foreach (CEntiteSnmp entite in EntitesSnmp)
            {
                entite.IsFromSnmp = entitesVues.Contains(entite.Id);
            }
            return result;
        }

        //--------------------------------------------------
        /// <summary>
        /// Fonction de mise à jour de l'agent SNMP physique<br/>
        /// à partir de l'objet 'agent SNMP'
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Update physical SNMP agent")]
        public bool UpdatePhysicalAgent()
        {
            CAgentSnmp agent = this;
            agent.BeginEdit();
            CResultAErreur result = UpdateToSnmpInCurrentContext(false);
            if (!result && !result.IsAvertissement)
            {
                agent.CancelEdit();
                return false;
            }
            return agent.CommitEdit().Result;

        }

        /// /////////////////////////////////////////////
        public CResultAErreur UpdateToSnmpInCurrentContext(bool bModifsOnly)
        {
            CResultAErreur result = CResultAErreur.True;
            List<CEntiteSnmp> lstEntites = new List<CEntiteSnmp>();
            foreach (CEntiteSnmp entite in EntitesSnmp)
                lstEntites.Add(entite);
            lstEntites.Sort((x, y) => x.TypeEntiteSnmp.UpdateIndex.CompareTo(y.TypeEntiteSnmp.UpdateIndex));
            foreach (CEntiteSnmp entite in lstEntites)
            {
                if (entite.TypeEntiteSnmp != null && !entite.TypeEntiteSnmp.ReadOnly)
                {
                    result += entite.SendToSnmp(bModifsOnly);
                    if (!result && !result.IsAvertissement)
                        return result;
                }
            }
            if (result || result.IsAvertissement)
                LastUpdateDateToSNMP = DateTime.Now;
            return result;
        }


        /// /////////////////////////////////////////////
        public CSnmpConnexion GetNewSnmpConnexion()
        {
            CSnmpConnexion connexion = new CSnmpConnexion();
            IPAddress ip = null;
            IPAddress.TryParse(SnmpIp, out ip);
            connexion.EndPoint = new IPEndPoint(ip, SnmpPort);
            connexion.Version = SnmpVersion;
            connexion.Community = SnmpCommunaute;
            return connexion;
        }

        //-----------------------------------------
        public CResultAErreur LireValeursSnmp()
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (CEntiteSnmp entite in EntitesRacines)
            {
                result += entite.LireValeursSnmp();
            }
            return result;
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Indique le Proxy SNMP qui joue le rôle d'Agent de médiation<br/>
        /// (traitement des alarmes et relais d'interrogation) pour cet Agent SNMP
        /// </summary>
        [Relation(
            CSnmpProxyInDb.c_nomTable,
            CSnmpProxyInDb.c_champId,
            CSnmpProxyInDb.c_champId,
            false,
            false,
            false)]
        [DynamicField("Snmp Mediation Proxy")]
        public CSnmpProxyInDb ProxyDeMediationSnmp
        {
            get
            {
                return (CSnmpProxyInDb)GetParent(CSnmpProxyInDb.c_champId, typeof(CSnmpProxyInDb));
            }
            set
            {
                SetParent(CSnmpProxyInDb.c_champId, value);

            }
        }

        //--------------------------------------------
        public int[] IdsProxysConcernesParDonneesMediation
        {
            get
            {
                if (ProxyDeMediationSnmp != null)
                    return new int[] { ProxyDeMediationSnmp.Id };
                return new int[0];
            }
        }

        //--------------------------------------------
        public int[] IdsProxysConcernesParConfigurationProxy
        {
            get
            {
                List<int> lst = new List<int>();
                if (Row.HasVersion(DataRowVersion.Current))
                    if (ProxyDeMediationSnmp != null && ProxyDeMediationSnmp.IsValide())
                        lst.Add(ProxyDeMediationSnmp.Id);
                if (Row.HasVersion(DataRowVersion.Original))
                {
                    DataRowVersion oldVers = VersionToReturn;
                    VersionToReturn = DataRowVersion.Original;
                    if (ProxyDeMediationSnmp != null && ProxyDeMediationSnmp.IsValide())
                        lst.Add(ProxyDeMediationSnmp.Id);
                    VersionToReturn = oldVers;
                }
                return lst.ToArray();
            }
        }

        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champParametresPolling, NullAutorise = true)]
        public CDonneeBinaireInRow DataParametresPolling
        {
            get
            {
                if (Row[c_champParametresPolling] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champParametresPolling);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametresPolling, donnee);
                }
                object obj = Row[c_champParametresPolling];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champParametresPolling] = value;
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheParametresPolling, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CSnmpPollingSetup> ParametresPollingList
        {
            get
            {
                if (Row[c_champCacheParametresPolling] != DBNull.Value)
                    return (List<CSnmpPollingSetup>)Row[c_champCacheParametresPolling];
                CDonneeBinaireInRow data = DataParametresPolling;
                List<CSnmpPollingSetup> lstParametres = new List<CSnmpPollingSetup>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        CMemoryDb db = new CMemoryDb();
                        CResultAErreur result = ser.TraiteListe<CSnmpPollingSetup>(lstParametres, new object[] { db });
                        if (!result)
                            lstParametres.Clear();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresPolling, lstParametres);
                return lstParametres;
            }
        }

        //-----------------------------------------------------------
        public IEnumerable<CSnmpPollingSetup> ParametresPolling
        {
            get
            {
                return ParametresPollingList.AsReadOnly();
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddParametrePolling(CSnmpPollingSetup parametre)
        {
            ParametresPollingList.Add(parametre);
            CommitParametresPolling();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveParametrePolling(CSnmpPollingSetup parametre)
        {
            ParametresPollingList.Remove(parametre);
            CommitParametresPolling();
        }

        /// /////////////////////////////////////////////////////////
        public void RollbackParametrePolling()
        {
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresPolling, DBNull.Value);
        }

        /// /////////////////////////////////////////////////////////
        public void CommitParametresPolling()
        {
            List<CSnmpPollingSetup> lstParametres = ParametresPollingList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresPolling, DBNull.Value);
            CDonneeBinaireInRow data = DataParametresPolling;
            if (lstParametres == null)
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
                    CResultAErreur result = ser.TraiteListe<CSnmpPollingSetup>(lstParametres);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataParametresPolling = data;
        }



        /// /////////////////////////////////////////////////////////
        [TableFieldProperty(c_champParametresHotelPolling, NullAutorise = true)]
        public CDonneeBinaireInRow DataParametresHotelPolling
        {
            get
            {
                if (Row[c_champParametresHotelPolling] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champParametresHotelPolling);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champParametresHotelPolling, donnee);
                }
                object obj = Row[c_champParametresHotelPolling];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champParametresHotelPolling] = value;
            }
        }

        //-----------------------------------------------------------
        [TableFieldProperty(c_champCacheParametresHotelPolling, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public List<CSnmpHotelPollingSetup> ParametresHotelPollingList
        {
            get
            {
                if (Row[c_champCacheParametresHotelPolling] != DBNull.Value)
                    return (List<CSnmpHotelPollingSetup>)Row[c_champCacheParametresHotelPolling];
                CDonneeBinaireInRow data = DataParametresHotelPolling;
                List<CSnmpHotelPollingSetup> lstParametres = new List<CSnmpHotelPollingSetup>();
                if (data != null && data.Donnees != null)
                {
                    Stream stream = new MemoryStream(data.Donnees);
                    try
                    {
                        BinaryReader reader = new BinaryReader(stream);
                        CSerializerReadBinaire ser = new CSerializerReadBinaire(reader);
                        CMemoryDb db = new CMemoryDb();
                        CResultAErreur result = ser.TraiteListe<CSnmpHotelPollingSetup>(lstParametres, new object[] { db });
                        if (!result)
                            lstParametres.Clear();
                        reader.Close();
                        stream.Close();
                    }
                    catch
                    {
                    }
                }
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresHotelPolling, lstParametres);
                return lstParametres;
            }
        }

        //-----------------------------------------------------------
        public IEnumerable<CSnmpHotelPollingSetup> ParametresHotelPolling
        {
            get
            {
                return ParametresHotelPollingList.AsReadOnly();
            }
        }

        /// /////////////////////////////////////////////////////////
        public void AddParametreHotelPolling(CSnmpHotelPollingSetup parametre)
        {
            ParametresHotelPollingList.Add(parametre);
            CommitParametresHotelPolling();
        }

        /// /////////////////////////////////////////////////////////
        public void RemoveParametreHotelPolling(CSnmpHotelPollingSetup parametre)
        {
            ParametresHotelPollingList.Remove(parametre);
            CommitParametresHotelPolling();
        }

        /// /////////////////////////////////////////////////////////
        public void RollbackParametreHotelPolling()
        {
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresHotelPolling, DBNull.Value);
        }

        /// /////////////////////////////////////////////////////////
        public void CommitParametresHotelPolling()
        {
            List<CSnmpHotelPollingSetup> lstParametres = ParametresHotelPollingList;

            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheParametresHotelPolling, DBNull.Value);
            CDonneeBinaireInRow data = DataParametresHotelPolling;
            if (lstParametres == null)
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
                    CResultAErreur result = ser.TraiteListe<CSnmpHotelPollingSetup>(lstParametres);
                    data.Donnees = stream.GetBuffer();
                    writer.Close();
                }
                catch
                {
                    data.Donnees = null;
                }
                stream.Close();
            }
            DataParametresHotelPolling = data;
        }

        public CResultAErreur RecalculeParametresHotelPolling()
        {
            //Trouve le setup system
            List<CSnmpHotelPollingSetup> lstSetups = ParametresHotelPollingList;
            CSnmpHotelPollingSetup setup = null;
            foreach ( CSnmpHotelPollingSetup s in lstSetups )
            {
                if (s.Id.StartsWith(CSnmpHotelPollingSetup.c_IdPollingSystem))
                {
                    setup = s;
                    break;
                }
            }
            if ( setup == null )
            {
                CMemoryDb db = new CMemoryDb();
                setup = new CSnmpHotelPollingSetup(db);
                setup.CreateNew();
                setup.Id = CSnmpHotelPollingSetup.c_IdPollingSystem+sc2i.common.CUniqueIdentifier.GetNew();
                setup.Libelle = "System";
                setup.HotelPort = CSnmpPollingHotelClient.HotelPollingServerPort;
                lstSetups.Add(setup);
            }
            if (setup.HotelPort == 0)
                setup.HotelPort = CSnmpPollingHotelClient.HotelPollingServerPort;
            if (setup.HotelIp == null || setup.HotelIp.Length == 0)
                setup.HotelIp = CSnmpPollingHotelClient.HotelPollingServerIp;

            CListeSnmpHotelPolledData lstPolled = setup.PolledDatas;
            lstPolled.Clear();
            CResultAErreur result = CResultAErreur.True;
            foreach ( CEntiteSnmp entite in EntitesSnmp )
            {
                CResultAErreurType<IEnumerable<CSnmpHotelPolledData>> res = entite.GetSnmpHotelPolledData();
                if (!res)
                {
                    result.EmpileErreur(res.Erreur);
                    result.EmpileErreur(I.T("Error in entity @1|20259", entite.Libelle));
                }
                else if (res.DataType is IEnumerable<CSnmpHotelPolledData> )
                    foreach ( CSnmpHotelPolledData data in res.DataType )
                        lstPolled.Add(data);
            }
            setup.PolledDatas = lstPolled;
            CommitParametresHotelPolling();
            return result;
        }

        /// <summary>
        /// Recalcul du setup de polling système.
        /// </summary>
        [DynamicMethod("Setup Hotel polling", "Prepare Agent for polling according to Entities setup")]
        public void SetupHotelPolling()
        {
            RecalculeParametresHotelPolling();
        }
    }

}
