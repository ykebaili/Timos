using data.hotel.client;
using sc2i.multitiers.server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace timos.data.snmp.polling
{
    public class CSnmpPollingHotelServer : C2iObjetServeur, ISnmpPollingHotelServer
    {
        private static string m_strPollingHotelURL = "";
        //-----------------------------------------------------------
        public CSnmpPollingHotelServer(int nIdSession)
            : base(nIdSession)
        {
        }

        //-----------------------------------------------------------
        public CSnmpPollingHotelServer()
            : base()
        {
        }

        //-----------------------------------------------------------
        public static void InitPollingUrl ( string strPollingHotelURL )
        {
            m_strPollingHotelURL = strPollingHotelURL;
        }

        //-----------------------------------------------------------
        public IDataRoomServer GetServer()
        {
            CDataHotelClient client = new CDataHotelClient();
            client.Init(m_strPollingHotelURL);
            return client.GetRoomServer();
        }


        public string HotelPollingServerIp
        {
            get
            {
                if (m_strPollingHotelURL.Length > 0)
                {
                    Regex ex = new Regex("^tcp://(.*):[0-9]*$", RegexOptions.IgnoreCase);
                    Match mtch = ex.Match(m_strPollingHotelURL);
                    if (mtch.Groups.Count > 1)
                        return mtch.Groups[1].Value;
                }
                return "";
            }
        }
    

        public int HotelPollingServerPort
        {
            get
            {
                if (m_strPollingHotelURL.Length > 0)
                {
                    Regex ex = new Regex("^tcp://.*:([0-9]*)$", RegexOptions.IgnoreCase);
                    Match mtch = ex.Match(m_strPollingHotelURL);
                    if (mtch.Groups.Count > 1)
                    {
                        try
                        {
                            return Int32.Parse(mtch.Groups[1].Value);
                        }
                        catch { }
                    }
                }
                return 0;
            }
        }
    }
}
