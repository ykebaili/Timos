using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    //public class CEvenementAlarm
    public abstract class CEvenementAlarm
    {
        private CMessageAlarmeNotification m_Message;
        public CEvenementAlarm(CMessageAlarmeNotification message)
        {
            m_Message = message;
        }

        protected CMessageAlarmeNotification Message
        {
            get
            {
                return m_Message;
            }
        }

        /*
        protected string m_stMessalrmMessage;
        protected string m_stSeparator;
        private CEvenementAlarmAcknowledge m_evntAlarmAcknowledge = null;
        private CEvenementAlarmMask m_evntAlarmMask = null;
        private CEvenementAlarmRetombee m_evntAlarmRetombee = null;
        private CEvenementAlarmStartStop m_evntAlarmStartStop = null;
        private ECategorieMessageAlarme m_categorieMessageAlarme = ECategorieMessageAlarme.Unknown;
                
        public CEvenementAlarm(string MessalrmMessage, string separator)
        {
            m_stMessalrmMessage = MessalrmMessage;
            m_stSeparator = separator; 
           
            m_categorieMessageAlarme = GetCategorieMessageAlarme();
            if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmStartStop)
                m_evntAlarmStartStop = CreateEventAlarmStartStop();
            else if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmMasqueeParUneAutre)
                m_evntAlarmRetombee = CreateEventAlarmRetombee();
            else if (m_categorieMessageAlarme == ECategorieMessageAlarme.Mask)
                m_evntAlarmMask = CreateEventAlarmMask();
            else if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmAcknowledgement)
                m_evntAlarmAcknowledge = CreateEventAlarmAcknowledge();
        }

        private ECategorieMessageAlarme GetCategorieMessageAlarme()
        {
            int index = 0;
            CDivers div = new CDivers();
            int nCategory;

            nCategory = div.ConvertToInt32(div.Extract(m_stMessalrmMessage, ref index, m_stSeparator), (int)(ECategorieMessageAlarme.Unknown));
            if (Enum.IsDefined(typeof(ECategorieMessageAlarme), nCategory))
                return (ECategorieMessageAlarme)nCategory;
            else
                return ECategorieMessageAlarme.Unknown;
        }

        public ECategorieMessageAlarme CategorieMessageAlarme
        {
            get
            {
                return m_categorieMessageAlarme;
            }
        }

        private CEvenementAlarmStartStop CreateEventAlarmStartStop()
        {
            if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmStartStop)
                return new CEvenementAlarmStartStop(m_stMessalrmMessage, m_stSeparator);
            else
                return null;
        }

        private CEvenementAlarmRetombee CreateEventAlarmRetombee()
        {
            if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmMasqueeParUneAutre)
                return new CEvenementAlarmRetombee(m_stMessalrmMessage, m_stSeparator);
            else
                return null;
        }

        private CEvenementAlarmMask CreateEventAlarmMask()
        {
            if (m_categorieMessageAlarme == ECategorieMessageAlarme.Mask)
                return new CEvenementAlarmMask(m_stMessalrmMessage, m_stSeparator);
            else
                return null;
        }

        private CEvenementAlarmAcknowledge CreateEventAlarmAcknowledge()
        {
            if (m_categorieMessageAlarme == ECategorieMessageAlarme.AlarmAcknowledgement)
                return new CEvenementAlarmAcknowledge(m_stMessalrmMessage, m_stSeparator);
            else
                return null;
        }

        public CEvenementAlarmStartStop EventAlarmStartStop
        {
            get
            {
                return m_evntAlarmStartStop;
            }
        }

        public CEvenementAlarmRetombee EventAlarmRetombee
        {
            get
            {
                return m_evntAlarmRetombee;
            }
        }

        public CEvenementAlarmMask EventAlarmMask
        {
            get
            {
                return m_evntAlarmMask;
            }
        }

        public CEvenementAlarmAcknowledge EventAlarmAcknowledge
        {
            get
            {
                return m_evntAlarmAcknowledge;
            }
        }        
       */
    }
}
