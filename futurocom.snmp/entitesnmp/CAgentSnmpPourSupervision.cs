using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;
using sc2i.common;
using futurocom.snmp.dynamic;
using futurocom.easyquery;
using futurocom.easyquery.snmp;
using System.Data;
using futurocom.snmp.mediation;
using futurocom.supervision;
using sc2i.common.memorydb;
using futurocom.snmp.Proxy;
using System.Net;
using futurocom.snmp.polling;
using futurocom.snmp.HotelPolling;

namespace futurocom.snmp.entitesnmp
{
    [MemoryTable(CAgentSnmpPourSupervision.c_nomTable, CAgentSnmpPourSupervision.c_champId)]
    public class CAgentSnmpPourSupervision : CEntiteDeMemoryDbAIdAuto
    {
        public const string c_nomTable = "SNMP_AGENT";
        public const string c_champId = "SNMPAGT_ID";
        public const string c_champIp = "SNMPAGT_IP";
        public const string c_champCommunaute = "SNMPAGT_COMMUNITY";
        public const string c_champPort = "SNMPAGT_PORT";
        public const string c_champVersionSnmp = "SNMPAGT_VERSION";
        public const string c_champTimeOut = "SNMPAGT_TIMEOUT";
        public const string c_champTrapsIp = "SNMPAGT_TRAPS_IPS";


        //-------------------------------------
        public CAgentSnmpPourSupervision( CMemoryDb db)
            :base ( db )
        {
        }

        //-------------------------------------
        public CAgentSnmpPourSupervision(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
        }

        //---------------------------------------------------------------------
        [DynamicField("Agent ID")]
        public string AgentId
        {
            get{
                return Row.Get<string>(c_champId);
            }
        }

        //---------------------------------------------------------------------
        [MemoryParent(false)]
        public CTypeAgentPourSupervision TypeAgent
        {
            get
            {
                return GetParent<CTypeAgentPourSupervision>();
            }
            set
            {
                SetParent<CTypeAgentPourSupervision>(value);
            }
        }

        //---------------------------------------------------------------------
        [MemoryParent(false)]
        [DynamicField("Proxy")]
        public CSnmpProxy Proxy
        {
            get
            {
                return GetParent<CSnmpProxy>();
            }
            set
            {
                SetParent<CSnmpProxy>(value);
            }
        }

        //---------------------------------------------------------------------
        [MemoryField(c_champTimeOut)]
        [DynamicField("Timeout")]
        public int Timeout
        {
            get
            {
                return Row.Get<int>(c_champTimeOut);
            }
            set
            {
                Row[c_champTimeOut] = value;
            }
        }

        //---------------------------------------------------------------------
        [MemoryField(c_champTrapsIp)]
        [DynamicField("Traps Ips")]
        public string TrapsIpString
        {
            get
            {
                return Row.Get<string>(c_champTrapsIp);
            }
            set
            {
                Row[c_champTrapsIp] = value;
            }
        }


        //-----------------------------------------------------------------------
        [MemoryField(c_champIp)]
        [DynamicField("IP")]
        public string Ip
        {
            get
            {
                return Row.Get<string>(c_champIp);
            }
            set
            {
                Row[c_champIp] = value;
            }
        }

        //-------------------------------------------------------------------------
        [MemoryField(c_champCommunaute)]
        [DynamicField("Community")]
        public string Communaute
        {
            get
            {
                return Row.Get<string>(c_champCommunaute);
            }
            set
            {
                Row[c_champCommunaute] = value;
            }
        }
        
        //--------------------------------------------------------------------------
        [MemoryField(c_champPort)]
        [DynamicField("Port")]
        public int SnmpPort
        {
            get
            {
                return Row.Get<int>(c_champPort);
            }
            set
            {
                Row[c_champPort] = value;
            }
        }

        //---------------------------------------------------------------------------
        [MemoryField(c_champVersionSnmp)]
        public VersionCode SnmpVersion
        {
            get
            {
                return Row.Get < VersionCode > (c_champVersionSnmp);
            }
            set
            {
                Row[c_champVersionSnmp] = value;
            }
        }

        


        //-------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CEntiteSnmpPourSupervision> Entites
        {
            get{
                return GetFils<CEntiteSnmpPourSupervision>();
            }
        }

        //-------------------------------------
        [DynamicChilds("Entities", typeof(CEntiteSnmpPourSupervision))]
        public IEnumerable<CEntiteSnmpPourSupervision> EntitiesList
        {
            get
            {
                return GetFils<CEntiteSnmpPourSupervision>().ToArray();
            }
        }

        //-------------------------------------
        public IEnumerable<CEntiteSnmpPourSupervision>GetEntites ( CTypeEntiteSnmpPourSupervision typeEntite )
        {
            if (typeEntite == null)
                return new CEntiteSnmpPourSupervision[0];
            return from e in Entites where e.TypeEntite != null && e.TypeEntite.Id == typeEntite.Id select e;
        }

        //-------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CSnmpPollingSetup> PollingSetups
        {
            get
            {
                return GetFils<CSnmpPollingSetup>();
            }
        }

        //-------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CSnmpHotelPollingSetup> HotelPollingSetups
        {
            get
            {
                return GetFils<CSnmpHotelPollingSetup>();
            }
        }


        //-------------------------------------
        public CResultAErreur FillFromSNMP(CInterrogateurSnmp agent)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                agent.Connexion.Version = SnmpVersion;
                agent.ConnexionIp = Ip;
                agent.ConnexionPort = SnmpPort;
                agent.ConnexionCommunity = Communaute;
                CEasyQuerySource source = new CEasyQuerySource();
                source.Connexion =new CSnmpConnexionForEasyQuery(agent);
                if (TypeAgent != null)
                {
                    foreach (CTypeEntiteSnmpPourSupervision typeEntite in TypeAgent.TypesEntites)
                    {
                        //Repere tous les existants
                        Dictionary<string, CEntiteSnmpPourSupervision> dicEntites = new Dictionary<string, CEntiteSnmpPourSupervision>();
                        foreach (CEntiteSnmpPourSupervision entite in GetEntites(typeEntite))
                        {
                            string strIndex = entite.Index;
                            if (strIndex != null)
                                dicEntites[strIndex] = entite;
                        }
                        //récupère les données de la table
                        CODEQBase objetDeQuery = typeEntite.GetObjetDeQuery(TypeAgent);
                        if (objetDeQuery != null)
                        {
                            CEasyQueryFromEasyQueryASourcesSpecifique query = new CEasyQueryFromEasyQueryASourcesSpecifique(objetDeQuery.Query, source);
                            DataTable table = query.GetTable(objetDeQuery.NomFinal);
                            if (table != null)
                            {
                                foreach (DataRow row in table.Rows)
                                {
                                    CEntiteSnmpPourSupervision entite = new CEntiteSnmpPourSupervision(Database);
                                    entite.CreateNew();
                                    entite.AgentSnmp = this;
                                    entite.TypeEntite = typeEntite;
                                    entite.FillFromSource(row);
                                    entite.UpdateIndexEtLibelle();
                                    string strIndex = entite.Index;
                                    //Si l'entité existe déjà
                                    CEntiteSnmpPourSupervision oldEntite = Entites.FirstOrDefault(
                                            e => e.Index == strIndex && 
                                            e.TypeEntite.Id == typeEntite.Id &&  
                                            e.Id != entite.Id);
                                    if (oldEntite != null)
                                    {
                                        oldEntite.FillFromSource(row);
                                        entite.Delete();
                                    }
                                }
                            }
                        }
                    }


                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        //----------------------------------------------
        private int GetNumVersion()
        {
            //return 2;
            return 3;//HotelPollingSetup
        }

        //----------------------------------------------
        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champIp,
                c_champCommunaute,
                c_champPort,
                c_champVersionSnmp);
            if (result)
                result = SerializeParent<CTypeAgentPourSupervision>(serializer);
            if (result)
                result = SerializeChilds<CEntiteSnmpPourSupervision>(serializer);
            if (nVersion >= 1 && result)
                result = SerializeChamp(serializer, c_champTrapsIp);
            if (nVersion >= 2 && result)
                result = SerializeChilds<CSnmpPollingSetup>(serializer);
            if (nVersion >= 3 && result)
                result = SerializeChilds<CSnmpHotelPollingSetup>(serializer);
            return result;
        }

        /// <summary>
        /// UTILISATION DU CACHE OID
        /// Avant une lecture de plein d'OID, on peut prélire toutes les 
        /// valeurs en une seule passe et les stocker en cache.
        /// Les formules qui utilisent un CDefinitionProprieteDynamiqueOID
        /// utiliseront le cache s'il existe, sinon, les données seront lues une par une.
        /// </summary>
        private Dictionary<string, object> m_cacheValeursOID = null;
        public void SetCacheOID(Dictionary<string, object> cache )
        {
            m_cacheValeursOID = cache;
        }

        //----------------------------------------------
        public bool HasCacheOID
        {
            get
            {
                return m_cacheValeursOID != null;
            }
        }
        //----------------------------------------------
        /// <summary>
        /// Lit une valeur SNMP à partir du cache temporaire
        /// </summary>
        /// <param name="strOID"></param>
        /// <returns></returns>
        public object GetValeurSNMPEnCache ( string strOID )
        {
            object val = null;
            if (m_cacheValeursOID.TryGetValue(strOID, out val))
                return val;
            return null;
        }

        //----------------------------------------------
        public object ReadSnmp ( string strOID )
        {
            try
            {
                 CSnmpConnexion cnx = new CSnmpConnexion(
                    SnmpVersion,
                    Communaute,
                    new IPEndPoint(IPAddress.Parse(Ip), SnmpPort),
                    Timeout);
                CInterrogateurSnmp it = new CInterrogateurSnmp();
                it.Connexion = cnx;
                return it.Get(strOID);
            }
            catch 
            {
                return null;
            }
        }

        //----------------------------------------------
        public IList<Variable> ReadSnmp(string[] strOids)
        {
            List<Variable> lst = new List<Variable>();
            foreach (string strOid in strOids)
            {
                if (strOids != null)
                {
                    uint[] oidsInt = ObjectIdentifier.Convert(strOid);
                    lst.Add(new Variable(oidsInt));
                }
            }
            try
            {
                CSnmpConnexion cnx = new CSnmpConnexion(
                    SnmpVersion,
                    Communaute,
                    new IPEndPoint(IPAddress.Parse(Ip), SnmpPort),
                    Timeout);
                CInterrogateurSnmp it = new CInterrogateurSnmp();
                it.Connexion = cnx;
                return it.Get(lst);
            }
            catch { }
            return new List<Variable>();
        }
    

        //----------------------------------------------
        [DynamicMethod("Reads an SNMP string from physical agent","OID to read")]
        public string ReadSnmpString(string strOID)
        {
            object val = ReadSnmp(strOID);
            if (val != null)
                return val.ToString();
            return null;
        }
    }
}
