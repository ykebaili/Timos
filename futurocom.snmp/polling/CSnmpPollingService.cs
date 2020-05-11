using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.mediation;
using System.Timers;
using sc2i.common.DonneeCumulee;
using futurocom.snmp.Proxy;
using sc2i.common.unites;
using futurocom.supervision;
using futurocom.snmp.HotelPolling;

namespace futurocom.snmp.polling
{
    public static class CSnmpPollingService
    {
        private static CConfigurationServiceMediation m_configuration = null;

        private static CPollingList m_pollingList = new CPollingList();

        private static Timer m_timerPolling = null;

        private static bool m_bDemandeInterruption = false;

        private static bool m_bIsPolling = false;

        //------------------------------------------------------------------
        /// <summary>
        /// Demande à la boucle de polling de s'interrompre
        /// </summary>
        public static void InterrompPolling()
        {
            if ( m_bIsPolling )
            {
                m_bDemandeInterruption = true;
            }
        }

        //------------------------------------------------------------------
        public static void Init ( double fDelaiPollingMinutes )
        {
            InterrompPolling();
            lock (typeof(CLockerPollingList))
            {
                if (m_timerPolling != null)
                {

                    m_timerPolling.Stop();
                    m_timerPolling.Dispose();
                    m_timerPolling = null;
                }
                if (fDelaiPollingMinutes > 0)
                {
                    m_timerPolling = new Timer((double)fDelaiPollingMinutes*60.0 * 1000.0);
                    m_timerPolling.Elapsed += new ElapsedEventHandler(m_timerPolling_Elapsed);
                    m_timerPolling.Start();
                }
                CServiceMediation.GetDefaultInstance().Trace.Write("Polling frequency set to " +
                    new CValeurUnite(fDelaiPollingMinutes, "min").ToString("h min s"),
                    ALTRACE.POLLING);
            }
        }

        //------------------------------------------------------------------
        public static CConfigurationServiceMediation Configuration
        {
            get
            {
                return m_configuration;
            }
            set
            {
                m_configuration = value;
                m_pollingList.UpdateFromServiceMediation(Configuration);
                if (value.DataBase != null)
                {
                    Init(CSnmpProxyConfiguration.GetInstance().FrequencePollingMinutes);
                }
            }
        }

        //------------------------------------------------------------------
        private static void m_timerPolling_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (m_bIsPolling)
                return;
            m_bIsPolling = true;
            if (!m_bDemandeInterruption)
            {
                lock (typeof(CLockerPollingList))
                {
                    DateTime dtPoll = DateTime.Now.AddSeconds(-2);
                    DateTime dtDebug = DateTime.Now;
                    int nNbPooled = 0;
                    List<CDonneeCumuleeTransportable> lstDonnees = new List<CDonneeCumuleeTransportable>();
                    if (m_configuration == null || m_configuration.DataBase == null)
                        return;
                    IEnumerable<CInfoPolling> lstToPoll = m_pollingList.GetElementsAPoller(DateTime.Now);
                    if (lstToPoll.Count() > 0)
                    {
                        CServiceMediation.GetDefaultInstance().Trace.Write("Poll " + lstToPoll.Count() + " elements", ALTRACE.POLLING);
                    }
                    foreach (CInfoPolling info in lstToPoll)
                    {
                        if (m_bDemandeInterruption)
                            break;
                        /*CSnmpPollingSetup setup = new CSnmpPollingSetup(m_configuration.DataBase);
                        if (setup.ReadIfExist(info.IdPollingSetup))
                        {
                            CDonneeCumuleeTransportable donnee = setup.GetDonneeTransportable();
                            if (donnee != null)
                            {
                                lstDonnees.Add(donnee);
                                info.LastPollDate = dtPoll;
                                info.NextPollDate = dtPoll.AddMinutes(setup.FrequenceMinutes);
                                nNbPooled++;
                            }
                        }
                        else*/
                        {
                            CSnmpHotelPollingSetup hotelSetup = new CSnmpHotelPollingSetup(m_configuration.DataBase);
                            if ( hotelSetup.ReadIfExist ( info.IdHotelPollingSetup ))
                            {
                                hotelSetup.DoPoll();
                                info.LastPollDate = dtPoll;
                                info.NextPollDate = dtPoll.AddMilliseconds(hotelSetup.FrequenceMinutes);
                                nNbPooled++;
                            }
                            else
                                m_pollingList.RemoveElement(info);
                        }

                    }
                    if (nNbPooled > 0)
                    {
                        TimeSpan sp = DateTime.Now - dtDebug;
                        Console.WriteLine("Pool1 " + nNbPooled + " : " + sp.TotalMilliseconds.ToString());
                    }
                    CSnmpConnexion.DefaultInstance.SendDonneesPooled(lstDonnees);
                    if (nNbPooled > 0)
                    {
                        TimeSpan sp = DateTime.Now - dtDebug;
                        Console.WriteLine("Pool2 " + nNbPooled + " : " + sp.TotalMilliseconds.ToString());
                    }
                    
                }
            }
            m_bIsPolling = false;
            m_bDemandeInterruption = false;


        }
        
    }
}
