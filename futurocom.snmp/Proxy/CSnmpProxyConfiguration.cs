using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using sc2i.common;
using sc2i.common.memorydb;
using System.Timers;
using futurocom.snmp.polling;
using futurocom.snmp.mediation;
using futurocom.supervision;

namespace futurocom.snmp.Proxy
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CSnmpProxyConfiguration : I2iSerializable
    {
        private int m_nIdDuProxyQueJeSuisMoiMeme = -1;
        private double m_fFrequencePollingMinutes = 0;
        private CMemoryDb m_memoryDb = new CMemoryDb();

        private Timer m_timerMiseAJour = null;
        private bool m_bMiseAJourDemandee = false;


        [NonSerialized]
        private static CSnmpProxyConfiguration m_instance = null;

        public CSnmpProxyConfiguration()
        {
        }

        //-------------------------------------------------------------------------
        public CMemoryDb Database
        {
            get
            {
                return m_memoryDb;
            }
        }

        //-------------------------------------------------------------------------
        public static CSnmpProxyConfiguration GetInstance()
        {
            if(m_instance == null)
                m_instance = new CSnmpProxyConfiguration();
            return m_instance;
        }

        public static void SetDefaultInstance(CSnmpProxyConfiguration snmpConfig)
        {
            m_instance = snmpConfig;
        }

        //-------------------------------------------------------------------------
        private bool m_bMiseAJourEnCours = false;
        public void MiseAJour(bool bDiffere)
        {
            if (!bDiffere)
            {
                if (m_bMiseAJourEnCours)
                    return;
                m_bMiseAJourEnCours = true;

                try
                {
                    ISnmpConnexion cnx = new CSnmpConnexion();
                    CSnmpProxyConfiguration config = cnx.GetConfigurationDeSnmpProxy(GetInstance().IdProxyConfiguré);
                    if (config != null)
                    {
                        m_instance = config;
                        CSnmpPollingService.Init(m_instance.FrequencePollingMinutes);
                    }
                }
                catch
                {
                }
                m_bMiseAJourEnCours = false;
                m_bMiseAJourDemandee = false;
                CServiceMediation.GetDefaultInstance().Trace.Write("Proxy setup updated", ALTRACE.TRACE, ALTRACE.DEBUG);
            }
            else
            {
                m_bMiseAJourDemandee = true;
                if ( m_timerMiseAJour == null )
                {
                    m_timerMiseAJour = new Timer(5000);
                    m_timerMiseAJour.Elapsed += new ElapsedEventHandler(m_timerMiseAJour_Elapsed);
                }
                m_timerMiseAJour.Start();
            }
        }

        //-------------------------------------------------------------------------
        void m_timerMiseAJour_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!m_bMiseAJourDemandee)
                return;
            try
            {
                m_timerMiseAJour.Stop();
                MiseAJour(false);
            }
            catch { }
            finally
            {
                m_timerMiseAJour.Start();
            }
        }

        //-------------------------------------------------------------------------
        public int IdProxyConfiguré
        {
            get
            {
                return m_nIdDuProxyQueJeSuisMoiMeme;
            }
            set
            {
                m_nIdDuProxyQueJeSuisMoiMeme = value;
            }
        }

        //-------------------------------------------------------------------------
        public double FrequencePollingMinutes
        {
            get
            {
                return m_fFrequencePollingMinutes;
            }
            set
            {
                m_fFrequencePollingMinutes = value;
            }
        }

        //-------------------------------------------------------------------------
        public IEnumerable<CSnmpProxy> ListeProxy
        {
            get
            {
                return new CListeEntitesDeMemoryDb<CSnmpProxy>(Database);
            }
        }

        //-------------------------------------------------------------------------
        public IEnumerable<CSnmpProxy> ListeProxySuivants
        {
            get
            {
                CListeEntitesDeMemoryDb<CSnmpProxy> lst = new CListeEntitesDeMemoryDb<CSnmpProxy>(Database,
                    new CFiltreMemoryDb ( CSnmpProxy.c_champProxyPrev+"=@1", false ));
                return lst;
            }
        }

        //-------------------------------------------------------------------------
        public IEnumerable<CSnmpProxy> ListeProxyPrecedents
        {
            get
            {
                CListeEntitesDeMemoryDb<CSnmpProxy> lst = new CListeEntitesDeMemoryDb<CSnmpProxy>(Database,
                    new CFiltreMemoryDb(CSnmpProxy.c_champProxyPrev + "=@1", true));
                return lst;
            }
        }

        //-------------------------------------------------------------------------
        public CSnmpProxy[] GetProxiesSuivants(string strAdresseIp)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(strAdresseIp);
                return GetProxies(ip, ListeProxySuivants);
            }
            catch { }

            return new CSnmpProxy[] { };
        }


        //-------------------------------------------------------------------------
        public CSnmpProxy[] GetProxiesPrecedents()
        {
            try
            {
                List<CSnmpProxy> lst = new List<CSnmpProxy>(ListeProxyPrecedents);
                if ( lst.Count > 0 )
                {
                    lst.Sort();
                    return lst.ToArray();
                }
                return new CSnmpProxy[] { };
            }
            catch { }

            return new CSnmpProxy[] { };
        }

        //-------------------------------------------------------------------------
        public CSnmpProxy[] GetProxiesSuivants(IPAddress ip)
        {
            return GetProxies(ip, ListeProxySuivants);
        }
    
        //-------------------------------------------------------------------------
        private CSnmpProxy[] GetProxies(IPAddress ip, IEnumerable<CSnmpProxy> lstDeRecherche)
        {
            List<CSnmpProxy> listeProxyQuiGerent = new List<CSnmpProxy>();

            foreach (CSnmpProxy proxySNMP in lstDeRecherche)
            {
                // On cherche les proxy qui gèrent cette adresse IP, par priorité
                if (proxySNMP.GereIP(ip))
                    listeProxyQuiGerent.Add(proxySNMP);
            }
            if (listeProxyQuiGerent.Count > 0)
            {
                listeProxyQuiGerent.Sort();
                return listeProxyQuiGerent.ToArray();
            }

            return new CSnmpProxy[] { };
        }

        //-------------------------------------------------------------------------
        private int GetNumVersion()
        {
            return 0;
        }

        //-------------------------------------------------------------------------
        public CResultAErreur Serialize(C2iSerializer serializer)
        {
            int nVersion = GetNumVersion();
            CResultAErreur result = serializer.TraiteVersion(ref nVersion);
            if (!result)
                return result;
            serializer.TraiteInt(ref m_nIdDuProxyQueJeSuisMoiMeme);
            if (result)
                result = serializer.TraiteObject<CMemoryDb>(ref m_memoryDb);
            return result;
        }

    }
}
