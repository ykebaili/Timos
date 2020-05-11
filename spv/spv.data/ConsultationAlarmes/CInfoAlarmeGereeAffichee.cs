using System;
using System.Collections.Generic;
using System.Text;
using sc2i.data;
using sc2i.common;


namespace spv.data.ConsultationAlarmes
{
    [Serializable]
    public  class CInfoAlarmeGereeAffichee
    {
        private int? m_nId;
        private string m_stName;
        private EAlarmEvent? m_AlarmEvent;
        private int? m_nTypeSonnerie;

        public CInfoAlarmeGereeAffichee()
        {
        }

        public int? Id
        {
            get
            {
                return m_nId;
            }
            set
            {
                m_nId = value;
            }
        }

        [DynamicField("Managed alarm name")]
        public string Name
        {
            get
            {
                return m_stName;
            }
            set
            {
                m_stName = value;
            }
        }

        public EAlarmEvent? CodeAlarmEvent
        {
            get
            {
                return m_AlarmEvent;
            }
            set
            {
                m_AlarmEvent = value;
            }
        }

       [DynamicField("Event type")]
        public CAlarmEvent AlarmEvent
        {
            get
            {
                if (CodeAlarmEvent == null)
                    return null;

                if (Enum.IsDefined(typeof(EAlarmEvent), CodeAlarmEvent))
                {
                    try
                    {
                        return new CAlarmEvent((EAlarmEvent) CodeAlarmEvent);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeAlarmEvent = value.Code;
            }
        }

        public int? CodeRingType
        {
            get
            {
                return m_nTypeSonnerie;
            }
            set
            {
                m_nTypeSonnerie = value;
            }
        }

        public CTypeSon RingType
        {
            get
            {
                if (CodeRingType == null)
                    return null;

                if (Enum.IsDefined(typeof(ETypeSon), CodeRingType))
                {
                    try
                    {
                        return new CTypeSon((ETypeSon)CodeRingType);
                    }
                    catch
                    {
                    }
                }
                return null;
            }
            set
            {
                CodeRingType = (int)value.Code;
            }
        }

        public CSpvAlarmGeree GetSpvAlarmGeree(CContexteDonnee contexteDonnee)
        {
            if (m_nId == null)
                return null;

            CSpvAlarmGeree alGer = new CSpvAlarmGeree(contexteDonnee);

            if (alGer.ReadIfExists((int)m_nId))
                return alGer;

            return null;
        }
    }
}
