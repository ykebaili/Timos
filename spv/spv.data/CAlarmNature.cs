using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum EAlarmNature
	{
		Physique =0,
        Confirmee=1,
        Frequente=2,
        Systeme  =3,
        Superviseur=4,
	}

    public class CAlarmNature : CEnumALibelle<EAlarmNature>
    {
        public CAlarmNature(EAlarmNature alNature)
            : base(alNature)
		{
		}
        
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EAlarmNature.Physique:
                        return I.T("Physical alarm|60006");
                    case EAlarmNature.Confirmee:
                        return I.T("Confirmed alarm|60007");
                    case EAlarmNature.Frequente:
                        return I.T("Frequent alarm|60008");
                    case EAlarmNature.Systeme:
                        return I.T("System alarm|60009");
                    case EAlarmNature.Superviseur:
                        return I.T("Superviser's alarm|60010");
                    default:
						break;
				}
				return "";
			}            
		}
	}
}

            		