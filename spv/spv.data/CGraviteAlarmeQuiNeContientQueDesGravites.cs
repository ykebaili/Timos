using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{

    public enum EGraviteAlarme
	{
        NoAlarm = 0,
        Warning = 3,
        Undetermined = 4,
        Minor = 5,
        Major = 6,
        Critical = 7
	}

    public class CGraviteAlarme : CEnumALibelle<EGraviteAlarme>
    {
        public CGraviteAlarme(EGraviteAlarme gravAlarme)
			: base(gravAlarme)
		{
		}


		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EGraviteAlarme.Warning:
						return I.T("Warning|100");
                    case EGraviteAlarme.Undetermined:
						return I.T("Undetermined|101");
                    case EGraviteAlarme.Minor:
						return I.T("Minor|102");
                    case EGraviteAlarme.Major:
						return I.T("Major|103");
                    case EGraviteAlarme.Critical:
						return I.T("Critical|104");
					default:
						break;
				}
				return "";
			}            
		}

        public static EGraviteAlarme ConvertFrom(EGraviteAlarmeAvecMasquage gravite)
        {
            switch (gravite)
            {
                case EGraviteAlarmeAvecMasquage.EndAlarm:
                    return EGraviteAlarme.NoAlarm;
                case EGraviteAlarmeAvecMasquage.MaskBrig:
                    return EGraviteAlarme.NoAlarm;
                case EGraviteAlarmeAvecMasquage.MaskAdmin:
                    return EGraviteAlarme.NoAlarm;
                case EGraviteAlarmeAvecMasquage.Warning:
                    return EGraviteAlarme.Warning;
                case EGraviteAlarmeAvecMasquage.Undetermined:
                    return EGraviteAlarme.Undetermined;
                case EGraviteAlarmeAvecMasquage.Minor:
                    return EGraviteAlarme.Minor;
                case EGraviteAlarmeAvecMasquage.Major:
                    return EGraviteAlarme.Major;
                case EGraviteAlarmeAvecMasquage.Critical:
                    return EGraviteAlarme.Critical;
            }
            return EGraviteAlarme.NoAlarm;
        }

        
	}
}
