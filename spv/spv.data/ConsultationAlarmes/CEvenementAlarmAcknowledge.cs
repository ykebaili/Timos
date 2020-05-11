using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    /*
    public class CEvenementAlarmAcknowledge
    {
        private int m_nAlarmListId;
        private int m_nAlarmId;

        public CEvenementAlarmAcknowledge(string stMessalrmMessage, string stSeparator)
        {
            int index = 0;
            CDivers div = new CDivers();
            
            string stcode   = div.Extract(stMessalrmMessage, ref index, stSeparator);
            string stNb     = div.Extract(stMessalrmMessage, ref index, stSeparator);
            m_nAlarmId      = div.ConvertToInt32(div.Extract(stMessalrmMessage, ref index, stSeparator), 0);
            string messId   = div.Extract(stMessalrmMessage, ref index, stSeparator);
            string st       = div.Extract(stMessalrmMessage, ref index, stSeparator);
            m_nAlarmListId = div.ConvertToInt32(div.Extract(stMessalrmMessage, ref index, stSeparator), 0);
        }

        public int AlarmListId
        {
            get
            {
                return m_nAlarmListId;
            }            
        }

        public int AlarmId
        {
            get
            {
                return m_nAlarmId;
            }
            set
            {
                m_nAlarmId = value;
            }
        }

    }*/

    public class CEvenementAlarmAcknowledge : CEvenementAlarm
    {
        public CEvenementAlarmAcknowledge(CMessageAlarmeNotification message)
            : base(message)
        {
        }

        public int IdAlarmeAcquittee
        {
            get
            {
                return Message.IdEvtAlarme;
            }
        }

        public int IdListeAlarmeAcquittee
        {
            get
            {
                return Message.IdListeAlarmeAcquittee;
            }
        }
    }
}
