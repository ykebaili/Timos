using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sc2i.multitiers.client;
using sc2i.common.memorydb;

namespace timos.data.supervision
{
    [Serializable]
    public class CNotificationModificationsAlarme : IDonneeNotification
    {
        private int m_nIdSession;
        private CMemoryDb m_memoryDb = new CMemoryDb();
        private int m_nNumNotification = 0;

        private static int m_globalNumNotification = 0;

        //-------------------------------------------
        public CNotificationModificationsAlarme ( int nIdSession )
        {
            m_nIdSession = nIdSession;
            m_nNumNotification = m_globalNumNotification++;
        }

        //-------------------------------------------
        public CMemoryDb MemoryDb
        {
            get{
                return m_memoryDb;
            }
        }

        //-------------------------------------------
        public int IdSessionEnvoyeur
        {
            get
            {
                return m_nIdSession;
            }
            set
            {
                m_nIdSession = value;
            }
        }

        //-------------------------------------------
        public int PrioriteNotification
        {
            get { return 0; }
        }

        //-------------------------------------------
        public int NumeroNotification
        {
            get
            {
                return m_nNumNotification;
            }
        }

        //-------------------------------------------
        public void AddModifiedAlarm(CAlarme alarme)
        {
            alarme.GetLocalAlarme(m_memoryDb, false);
        }

        
    }
}
