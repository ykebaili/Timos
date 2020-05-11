using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum EAlarmEvent
	{
		Communication,
        Service_quality,
        Processing_error,
        Equipment,
        Environment,
	}

    [DynamicClass("Alarm event type")]
    public class CAlarmEvent : CEnumALibelle<EAlarmEvent>
    {
        public CAlarmEvent(EAlarmEvent alEvent)
            : base(alEvent)
		{
		}
        [DynamicField("Label")]
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EAlarmEvent.Communication:
						return I.T("Communication|107");
                    case EAlarmEvent.Service_quality:
						return I.T("Quality of service|108");
                    case EAlarmEvent.Processing_error:
						return I.T("Processing error|109");
                    case EAlarmEvent.Equipment:
						return I.T("Equipment|110");
                    case EAlarmEvent.Environment:
						return I.T("Environment|111");
                    default:
						break;
				}
				return "";
			}            
		}
	}
}

            		