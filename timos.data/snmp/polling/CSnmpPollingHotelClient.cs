using data.hotel.client;
using sc2i.data;
using sc2i.multitiers.client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.snmp.polling
{
    //-----------------------------------------------------
    public interface ISnmpPollingHotelServer
    {
        IDataRoomServer GetServer();
        string HotelPollingServerIp { get; }
        int HotelPollingServerPort { get; }
    }

    //-----------------------------------------------------
    public class CSnmpPollingHotelClient
    {
        //-----------------------------------------------------
        protected static ISnmpPollingHotelServer PollingHotelServer
        {
            get
            {
                return (ISnmpPollingHotelServer)C2iFactory.GetNewObjetForSession("CSnmpPollingHotelServer", typeof(ISnmpPollingHotelServer), CContexteDonneeSysteme.GetInstance().IdSession);
            }
        }

        //-----------------------------------------------------
        public static IDataRoomServer GetServer()
        {
            ISnmpPollingHotelServer gestionnaireServeur = PollingHotelServer;
            try
            {
                return gestionnaireServeur.GetServer();
            }
            catch
            {
                return null;
            }
        }

        //-----------------------------------------------------
        public static string HotelPollingServerIp
        {
            get
            {
                try
                {
                    return PollingHotelServer.HotelPollingServerIp;
                }
                catch { }
                return "";

            }
        }

        //-----------------------------------------------------
        public static int HotelPollingServerPort
        {
            get
            {
                try
                {
                    return PollingHotelServer.HotelPollingServerPort;
                }
                catch { }
                return 8160;

            }
        }


        //-----------------------------------------------------
        public static IEnumerable<DataTable> GetDefinitionsTablesFromHotel( )
        {
            List<DataTable> lstTables = new List<DataTable>();
            try
            {
                IDataRoomServer srv = GetServer();
                DataSet ds = srv.GetDataSetModele();
                if (ds != null)
                {
                    foreach (DataTable table in ds.Tables)
                        lstTables.Add(table);
                }
            }
            catch { }
            return lstTables;
        }
    }
}
