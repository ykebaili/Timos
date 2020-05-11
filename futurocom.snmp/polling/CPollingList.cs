using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.mediation;
using sc2i.common.memorydb;
using futurocom.snmp.entitesnmp;
using futurocom.snmp.Proxy;
using futurocom.snmp.HotelPolling;

namespace futurocom.snmp.polling
{

    public class CInfoPolling
    {
        private string m_strIdPollingSetup = null;
        private string m_strIdHotelPollingSetup = null;
        private DateTime? m_lastPoll = null;
        private DateTime m_nextPoll = DateTime.Now;

        public CInfoPolling()
        {
        }

        //----------------------------------------------
        public string IdPollingSetup
        {
            get
            {
                return m_strIdPollingSetup;
            }
            set
            {
                m_strIdPollingSetup = value;
            }
        }

        //----------------------------------------------
        public string IdHotelPollingSetup
        {
            get
            {
                return m_strIdHotelPollingSetup;
            }
            set
            {
                m_strIdHotelPollingSetup = value;
            }
        }


        //----------------------------------------------
        public DateTime? LastPollDate
        {
            get
            {
                return m_lastPoll;
            }
            set
            {
                m_lastPoll = value;
            }
        }

        //----------------------------------------------
        public DateTime NextPollDate
        {
            get
            {
                return m_nextPoll;
            }
            set
            {
                m_nextPoll = value;
            }
        }
    }

    /// <summary>
    /// Liste des éléments à poller
    /// </summary>
    public class CPollingList
    {
        
        //Id  du CSnmpPollingSetup->info de polling (date à laquelle il devra être executé)
        private Dictionary<string, CInfoPolling> m_dicIdToInfoPolling = new Dictionary<string, CInfoPolling>();

        //----------------------------------------------------------
        public CPollingList()
        {
        }


        //----------------------------------------------------------
        public void RemoveElement(CInfoPolling info)
        {
            if (info != null)
            {
                if (m_dicIdToInfoPolling.ContainsKey(info.IdPollingSetup))
                    m_dicIdToInfoPolling.Remove(info.IdPollingSetup);
            }
        }

        //----------------------------------------------------------
        //Prépare la liste des éléments à poller.
        public void UpdateFromServiceMediation(CConfigurationServiceMediation configuration)
        {
            
            //Permet d'éliminer les éléments qui ne font plus partie du service de médiation
            Dictionary<string, bool> dicToDelete = new Dictionary<string, bool>();

            foreach (string strId in m_dicIdToInfoPolling.Keys)
                dicToDelete[strId] = true;

            if (configuration == null || configuration.DataBase == null)
                return;

            CSnmpPollingService.InterrompPolling();
            lock (typeof(CLockerPollingList))
            {
                CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision> lstAgents = new CListeEntitesDeMemoryDb<CAgentSnmpPourSupervision>(configuration.DataBase);
                /*Filtre non nécéssaire (en plus ne marche pas) : seuls les agents de ce proxy sont dans la base
                 * lstAgents.Filtre = new CFiltreMemoryDb(CSnmpProxy.c_champId + "=@1",
                CSnmpProxyConfiguration.GetInstance().IdProxyConfiguré.ToString());*/

                foreach (CAgentSnmpPourSupervision agent in lstAgents)
                {
                    foreach (CSnmpPollingSetup setup in agent.PollingSetups)
                    {
                        if (setup.FrequenceMinutes != 0)//Sinon, on ne prend pas
                        {
                            dicToDelete[setup.Id] = false;
                            CInfoPolling info = null;
                            if (!m_dicIdToInfoPolling.TryGetValue(setup.Id, out info))
                            {
                                info = new CInfoPolling();
                                info.IdPollingSetup = setup.Id;
                                info.NextPollDate = DateTime.Now;
                                m_dicIdToInfoPolling[setup.Id] = info;
                            }
                            else
                            {
                                if (info.LastPollDate == null)
                                    info.NextPollDate = DateTime.Now;
                                else
                                {
                                    info.NextPollDate = info.LastPollDate.Value.AddMinutes(setup.FrequenceMinutes);
                                }
                            }
                        }
                    }
                    foreach (CSnmpHotelPollingSetup setup in agent.HotelPollingSetups)
                    {
                        if (setup.FrequenceMinutes != 0)//Sinon, on ne prend pas
                        {
                            dicToDelete[setup.Id] = false;
                            CInfoPolling info = null;
                            if (!m_dicIdToInfoPolling.TryGetValue(setup.Id, out info))
                            {
                                info = new CInfoPolling();
                                info.IdHotelPollingSetup = setup.Id;
                                info.NextPollDate = DateTime.Now;
                                m_dicIdToInfoPolling[setup.Id] = info;
                            }
                            else
                            {
                                if (info.LastPollDate == null)
                                    info.NextPollDate = DateTime.Now;
                                else
                                {
                                    info.NextPollDate = info.LastPollDate.Value.AddMinutes(setup.FrequenceMinutes);
                                }
                            }
                        }
                    }
                }
                foreach ( KeyValuePair<string,bool> kvToDelete in dicToDelete)
                {
                    if (kvToDelete.Value)
                        m_dicIdToInfoPolling.Remove(kvToDelete.Key);
                }
            }
        }

        //----------------------------------------------------------
        public IEnumerable<CInfoPolling> GetElementsAPoller(DateTime dt)
        {
            List<CInfoPolling> lst = new List<CInfoPolling>();
            foreach (CInfoPolling info in m_dicIdToInfoPolling.Values)
            {
                if (info.NextPollDate < dt)
                    lst.Add(info);
            }
            lst.Sort((x, y) => x.NextPollDate.CompareTo(y.NextPollDate));
            return lst.ToArray();
        }

    }
}
