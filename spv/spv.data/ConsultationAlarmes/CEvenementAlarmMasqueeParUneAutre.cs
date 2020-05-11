using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;

namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    /*
    public class CEvenementAlarmRetombee
    {
        private int m_nAlarmStartId;
        private DateTime m_dateStopAlarm;

        private const int m_nPositionAlarmStartId = 3;

        public CEvenementAlarmRetombee(string stMessalrmMessage, string stSeparator)
        {
            int index = 0;
            CDivers div = new CDivers();
            string st;

            for (int i = 0; i < m_nPositionAlarmStartId - 1; i++)
                st = div.Extract(stMessalrmMessage, ref index, stSeparator);

            m_nAlarmStartId = div.ConvertToInt32(div.Extract(stMessalrmMessage, ref index, stSeparator), 0);

            //m_dateStopAlarm = DateTime.Now;
            m_dateStopAlarm = CDivers.GetSysdateNotNull();
        }

        public int AlarmStartId
        {
            get
            {
                return m_nAlarmStartId;
            }
            set
            {
                m_nAlarmStartId = value;
            }
        }

        public DateTime StopAlarmDate
        {
            get
            {
                return m_dateStopAlarm;
            }
            set
            {
                m_dateStopAlarm = value;
            }
        }
    }
     */

    public class CEvenementAlarmMasqueeParUneAutre : CEvenementAlarm
    {
        public CEvenementAlarmMasqueeParUneAutre(CMessageAlarmeNotification message)
            : base(message)
        {
        }




        public int AlarmStartId
        {
            get
            {
                return Message.IdEvtAlarme;
            }
        }

        public DateTime StopAlarmDate
        {
            get
            {
                return Message.DateRetombeeFille;
            }
        }

        public int IdAlarmeGeree
        {
            get
            {
                return Message.IdAlarmeGeree;
            }
        }

        public int IdAlarmeData
        {
            get
            {
                return Message.IdAlarmData;
            }
        }


        public int? IdSite
        {
            get
            {
                return Message.IdSite;
            }
        }

        public int? IdEquipement
        {
            get
            {
                return Message.IdEquipement;
            }
        }

        public int? IdLiaison
        {
            get
            {
                return Message.IdLiaison;
            }
        }

        public ETypeObjetEnAlarme TypeObjetEnAlarme
        {
            get
            {
                return Message.TypeObjetEnAlarme;
            }
        }

        public string ClasseAlarme
        {
            get
            {
                return Message.ClasseAlarme;
            }
        }

        public int NumeroObjetDeCollecteOuTrap
        {
            get
            {
                return Message.NumeroObjetDeCollecteOuTrap;
            }
        }

        public string NumeroSortieAlarmeOuIP
        {
            get
            {
                return Message.NumeroSortieAlarmeOuIP;
            }
        }

        public string EtatServices
        {
            get
            {
                return Message.EtatsServices;
            }
        }
    }
}
