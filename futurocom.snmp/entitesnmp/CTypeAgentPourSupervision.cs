using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using futurocom.snmp.Messaging;
using futurocom.snmp.Mib;
using futurocom.easyquery;
using sc2i.expression;
using futurocom.easyquery.snmp;
using futurocom.snmp.dynamic;
using futurocom.snmp.alarme;
using futurocom.supervision;
using sc2i.common.memorydb;
using System.Data;
using sc2i.expression.FonctionsDynamiques;

namespace futurocom.snmp.entitesnmp
{
    [MemoryTable(CTypeAgentPourSupervision.c_nomTable, CTypeAgentPourSupervision.c_champId)]
    public class CTypeAgentPourSupervision : CEntiteDeMemoryDb,
        IElementAFonctionsDynamiques
    {
        public const string c_nomTable = "SNMP_AGENT_TYPE";
        public const string c_champId = "SNAGTP_ID";
        public const string c_champQueries = "SNAGTP_QUERIES";
        public const string c_champFonctions = "SNAGTP_FUNCTIONS";

        public const string c_champInterrogateurSnmp = "SNAGTP_DYNAMIC_SNMP_QUERYER";

        private CInterrogateurSnmp m_agentAssocie = null;

        //---------------------------------------------------
        public CTypeAgentPourSupervision(CMemoryDb db)
            : base(db)
        {
        }

        //---------------------------------------------------
        public CTypeAgentPourSupervision(DataRow row)
            : base(row)
        {
        }

        //---------------------------------------------------

        //---------------------------------------------------
        public override void MyInitValeursParDefaut()
        {
            
        }

       
        //---------------------------------------------------
        /// <summary>
        /// Utilisé lors du paramétrage, pour avoir à dispo la Mib
        /// et un agent pour tester la MIB
        /// Ne pas utilier à l'execution car chaque CTrapInstance
        /// doit être associé à un agent différent
        /// </summary>
        [MemoryField(c_champInterrogateurSnmp)]
        public CInterrogateurSnmp InterrogateurSNMP
        {
            get{
                return Row.Get<CInterrogateurSnmp>(c_champInterrogateurSnmp);
            }
            set{
                Row[c_champInterrogateurSnmp] = value;
                m_agentAssocie = value;
                if (value != null)
                {
                    CListeQuerySource lst = new CListeQuerySource();
                    CEasyQuerySource source = new CEasyQuerySource();
                    source.Connexion =new CSnmpConnexionForEasyQuery(value);
                    lst.AddSource(source);
                    foreach (CEasyQuery query in Queries)
                    {
                        query.Sources = lst.Sources;
                    }
                    PrepareDynamicSnmpAgent(m_agentAssocie);
                }

            }
        }

        //---------------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CTrapHandler> Handlers
        {
            get
            {
                return GetFils<CTrapHandler>();
            }
        }

        //---------------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CAgentFinderFromKey> AgentFinders
        {
            get
            {
                return GetFils<CAgentFinderFromKey>();
            }
        }

        //---------------------------------------------------
        [MemoryChild]
        public CListeEntitesDeMemoryDb<CTypeEntiteSnmpPourSupervision> TypesEntites
        {
            get
            {
                return GetFils<CTypeEntiteSnmpPourSupervision>();
            }
        }

        //---------------------------------------
        [MemoryField(c_champFonctions)]
        public IEnumerable<CFonctionDynamique> Fonctions
        {
            get
            {
                IEnumerable<CFonctionDynamique> lst = Row.Get<IEnumerable<CFonctionDynamique>>(c_champFonctions);
                if (lst == null)
                {
                    lst = new List<CFonctionDynamique>();
                    Row[c_champFonctions] = lst;
                }
                return lst;
            }
            set
            {
                List<CFonctionDynamique> lst = new List<CFonctionDynamique>();
                if (value != null)
                    lst.AddRange ( value );
                Row[c_champFonctions] = lst;
            }
        }

        

        //---------------------------------------
        [MemoryField(c_champQueries)]
        public IEnumerable<CEasyQuery> Queries
        {
            get
            {
                IEnumerable<CEasyQuery> queries = Row.Get<IEnumerable<CEasyQuery>>(c_champQueries);
                if (queries == null)
                {
                    queries = new List<CEasyQuery>();
                    Row[c_champQueries] = queries;
                }
                return queries;
            }
        }

        //---------------------------------------
        private List<CEasyQuery> QueriesList
        {
            get
            {
                return (List<CEasyQuery>)Queries;
            }
        }

        //---------------------------------------
        public void AddQuery(CEasyQuery query)
        {
            QueriesList.Add(query);
        }

        //---------------------------------------
        public void RemoveQuery(CEasyQuery requete)
        {
            QueriesList.Remove(requete);
        }

        //---------------------------------------
        public void ClearQueries()
        {
            QueriesList.Clear();
        }

        
        //---------------------------------------------------
        public IEnumerable<CTrapHandler> GetTrapsHandlersAAppliquer(CTrapInstance trap)
        {
            List<CTrapHandler> lstTraps = new List<CTrapHandler>();
            if (trap != null)
            {
                foreach (CTrapHandler handler in Handlers)
                    if (handler.ShouldDeclenche(trap))
                    {
                        //handler = handler.PrepareForAlarmCreation(this);
                        lstTraps.Add(handler);
                    }
            }
            return lstTraps.ToArray();
        }

        //---------------------------------------------------
        public IEnumerable<CAgentFinderFromKey> GetAgentFindersAAppliquer(CTrapInstance trap)
        {
            List<CAgentFinderFromKey> lstFinders = new List<CAgentFinderFromKey>();
            if (trap != null)
            {
                foreach (CAgentFinderFromKey finder in AgentFinders)
                    if (finder.ShouldApply(trap))
                    {
                        //handler = handler.PrepareForAlarmCreation(this);
                        lstFinders.Add(finder);
                    }
            }
            return lstFinders.ToArray();
        }


        //---------------------------------------------------
        public void PrepareDynamicSnmpAgent( CInterrogateurSnmp agent )
        {
            if ( agent != null )
                foreach ( CEasyQuery query in Queries )
                    agent.AddQuery ( query );
        }

        //---------------------------------------------------
        private int GetNumVersion()
        {
            return 1;
        }

        protected override CResultAErreur MySerialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            result = SerializeChamps(serializer,
                c_champQueries);
            if (result)
                result = SerializeChilds<CTrapHandler>(serializer);
            if (result)
                result = SerializeChilds<CTypeEntiteSnmpPourSupervision>(serializer);
            if (result && nVersion >= 1)
                result = SerializeChilds<CAgentFinderFromKey>(serializer);
            return result;
        }

        //---------------------------------------------------
        public IEnumerable<IChampEntiteSNMP> TousLesChampsSNMPDefinis
        {
            get
            {
                List<IChampEntiteSNMP> lstChamps = new List<IChampEntiteSNMP>();
                foreach (CTypeEntiteSnmpPourSupervision typeEntite in TypesEntites)
                {
                    foreach (IChampEntiteSNMP champ in typeEntite.Champs)
                        lstChamps.Add(champ);
                }
                return lstChamps.ToArray();
            }
        }


        //------------------------------------------------------    
        public IEnumerable<CFonctionDynamique> FonctionsDynamiques
        {
            get { return Fonctions; }
        }

        //------------------------------------------------------    
        public CFonctionDynamique GetFonctionDynamique(string strIdFonction)
        {
            return Fonctions.FirstOrDefault(f=>f.IdFonction == strIdFonction );
        }

    }
}
