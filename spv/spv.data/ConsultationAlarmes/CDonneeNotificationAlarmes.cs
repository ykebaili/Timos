using System;
using System.Collections.Generic;
using System.Text;
using sc2i.multitiers.client;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public class CDonneeNotificationAlarmes : IDonneeNotification
    {
        private int m_nIdSession = -1;

        private List<CEvenementAlarm> m_listeAlarmes;

        public CDonneeNotificationAlarmes(int nIdSession, List<CEvenementAlarm> lstAlarmes)
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

        public CEvenementAlarm[] Alarmes
        {
            get
            {
                return m_listeAlarmes.ToArray();
            }
        }

    }
}
