using data.hotel.client;
using data.hotel.server;
using sc2i.common;
using sc2i.common.memorydb;
using sc2i.multitiers.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using timos.client;

namespace timos.serveur.Licence
{
    public static class CLicenceUsagePolling
    {
        private static Timer m_timer = null;

        public static string c_LicenceUsagePollingTableId = "T_qilrmskophs";
        public static string c_LicenceUsagePollingTable = "LICENCE_USAGE";
        public static string c_LicenceUsagePollingNbUsedFieldId = "Nghbsol_fchishc";
        public static string c_LicenceUsagePollingNbUsedField = "LICENCE_COUNT";

        private static string m_strHotelURL = "";

        //-------------------------------------------------------------
        public static CResultAErreur InitUsagePolling(string strHotelURL)
        {
            CResultAErreur result = CResultAErreur.True;

            try
            {
                m_strHotelURL = strHotelURL;
                CDataHotelClient hotelClient = new CDataHotelClient();
                hotelClient.Init(strHotelURL);
                CMemoryDb db = hotelClient.GetRoomServer().GetConfig();
                if (db == null)
                    return result;
                CDataHotel hotel = new CDataHotel(db);
                if ( !hotel.ReadIfExist(new CFiltreMemoryDb("1=1")))
                {
                    hotel.CreateNew();
                    hotel.Label = "Timos hotel";
                }
                CDataHotelTable table = new CDataHotelTable(db);
                if (!table.ReadIfExist(new CFiltreMemoryDb(CDataHotelTable.c_champId + "=@1", c_LicenceUsagePollingTableId)))
                {
                    table.CreateNew(c_LicenceUsagePollingTableId);
                    table.TableName = c_LicenceUsagePollingTable;
                    table.Hotel = hotel;
                }
                bool bFieldExists = false;
                foreach (CDataHotelField field in table.Fields)
                {
                    if (field.Id == c_LicenceUsagePollingNbUsedFieldId)
                    {
                        bFieldExists = true;
                        break;
                    }
                }
                if (!bFieldExists)
                {
                    CDataHotelField field = new CDataHotelField(db);
                    field.CreateNew(c_LicenceUsagePollingNbUsedFieldId);
                    field.FieldName = c_LicenceUsagePollingNbUsedField;
                    field.HotelTable = table;
                }
                hotelClient.GetRoomServer().UpdateConfig(db);

                if (m_timer == null)
                {
                    m_timer = new Timer(5 *60 * 1000);
                    m_timer.Elapsed += m_timer_Elapsed;
                    m_timer.Start();
                }
            }
            catch ( Exception e )
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;            
        }

        //-------------------------------------------------------------
        private static bool m_bIsPolling = false;
        static void m_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (m_bIsPolling)
                return;
            try
            {
                m_bIsPolling = true;

                IGestionnaireSessionsTimos gestionnaire = (IGestionnaireSessionsTimos)C2iFactory.GetNewObject(typeof(IGestionnaireSessionsTimos));
                Dictionary<string, int?> dicNbParProfil = new Dictionary<string, int?>();
                Dictionary<string, int?> dicNbParUser = new Dictionary<string,int?>();
                foreach (int nId in gestionnaire.GetListeIdSessionsConnectees())
                {
                    CSessionClientSurServeurTimos sessionSurServeur = gestionnaire.GetSessionClientSurServeur(nId) as CSessionClientSurServeurTimos;
                    if (sessionSurServeur != null && sessionSurServeur.UserLicence != null)
                    {
                        string strKeyUserLicence = sessionSurServeur.UserLicence.IdLys + " " + sessionSurServeur.UserLicence.ToString();
                        string strIdUtilisateur = sessionSurServeur.KeyUtilisateur != null ? sessionSurServeur.KeyUtilisateur.StringValue : "";
                        int? nVal = null;
                        try
                        {
                            if (sessionSurServeur.SessionClient.IsConnected)
                            {
                                if (!dicNbParProfil.TryGetValue(strKeyUserLicence, out nVal))
                                {
                                    nVal = 0;
                                }
                                nVal++;
                                dicNbParProfil[strKeyUserLicence] = nVal;
                                if ( strIdUtilisateur.Length > 0 )
                                {
                                    if ( !dicNbParUser.TryGetValue(strIdUtilisateur, out nVal ))
                                    {
                                        nVal = 0;
                                    }
                                    nVal++;
                                    dicNbParUser[strIdUtilisateur] = nVal;
                                }
                            }
                        }
                        catch { }
                    }
                }
                CDataHotelClient hotelClient = new CDataHotelClient();
                hotelClient.Init(m_strHotelURL);
                foreach (KeyValuePair<string, int?> kv in dicNbParProfil)
                {
                    string strIdEtt = kv.Key;
                    if (strIdEtt.Length == 0)
                        strIdEtt = "Empty";
                    hotelClient.StoreDataToSend(c_LicenceUsagePollingTableId, c_LicenceUsagePollingNbUsedFieldId,
                        kv.Key, DateTime.Now, kv.Value.Value);
                }
                foreach (KeyValuePair<string, int?> kv in dicNbParUser)
                {
                    string strIdEtt = kv.Key;
                    if (strIdEtt.Length == 0)
                        strIdEtt = "Empty";
                    hotelClient.StoreDataToSend(c_LicenceUsagePollingTableId, c_LicenceUsagePollingNbUsedFieldId,
                        kv.Key, DateTime.Now, kv.Value.Value);
                }
                hotelClient.FlushData();
            }
            catch { }
            finally{
                m_bIsPolling = false;
            }
        }
    }
}