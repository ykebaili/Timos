using System;
using System.Collections.Generic;
using System.Text;
using sc2i.multitiers.client;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CDonneeNotificationAlarmesStart : IDonneeNotification
    {
        private int m_nIdSession = -1;

        private List<CEvenementAlarmStart> m_listeAlarmes;

        public CDonneeNotificationAlarmesStart(int nIdSession, List<CEvenementAlarmStart> lstAlarmes)
        {
            m_listeAlarmes = lstAlarmes;
            m_nIdSession = nIdSession;
        }

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

        public int PrioriteNotification
        {
            get { return 0; }
        }

        public CEvenementAlarmStart[] Alarmes
        {
            get
            {
                return m_listeAlarmes.ToArray();
            }
        }

    }
}
