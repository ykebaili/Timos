using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    //Valeurs de EGraviteAlarme prend en compte le DECAL_GRAVE defini dans Spv:
    // const int DECAL_GRAVE = 3;	// décalage entre la valeur de la gravité dans les combo et dans la base.
	// Combo 0="Avertissement" .. codé 3 dans la base
	// 0 = pas d'alarme, 1 = msk. brigadier, 2 = msk. adm.

    public enum EGraviteAlarmeAvecMasquage
	{
        EndAlarm = 0,
        MaskBrig = 1,
        MaskAdmin = 2,
		Warning = 3,
		Undetermined = 4,
		Minor = 5,
		Major = 6,
		Critical = 7
	}

    [DynamicClass("Alarm severity")]
    public class CGraviteAlarmeAvecMasquage : CEnumALibelle<EGraviteAlarmeAvecMasquage>
    {
        public CGraviteAlarmeAvecMasquage(EGraviteAlarmeAvecMasquage gravAlarme)
			: base(gravAlarme)
		{
		}

        [DynamicField("Label")]
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case EGraviteAlarmeAvecMasquage.EndAlarm:
                        return I.T("No alarm|60059");
                    case EGraviteAlarmeAvecMasquage.Warning:
						return I.T("Warning|100");
                    case EGraviteAlarmeAvecMasquage.MaskBrig:
                        return I.T("Operating agent masking|60000");
                    case EGraviteAlarmeAvecMasquage.MaskAdmin:
                        return I.T("Administrator masking|60001");
                    case EGraviteAlarmeAvecMasquage.Undetermined:
						return I.T("Undetermined|101");
                    case EGraviteAlarmeAvecMasquage.Minor:
						return I.T("Minor|102");
                    case EGraviteAlarmeAvecMasquage.Major:
						return I.T("Major|103");
                    case EGraviteAlarmeAvecMasquage.Critical:
						return I.T("Critical|104");
					default:
						break;
				}
				return "";
			}            
		}

        public static List<IEnumALibelle> GetListGrave()
        {
            List<IEnumALibelle> lstGrave = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CGraviteAlarmeAvecMasquage)));

            IEnumALibelle nonGrave = new CGraviteAlarmeAvecMasquage(EGraviteAlarmeAvecMasquage.EndAlarm);
            lstGrave.Remove(nonGrave);
            IEnumALibelle maskBrig = new CGraviteAlarmeAvecMasquage(EGraviteAlarmeAvecMasquage.MaskBrig);
            lstGrave.Remove(maskBrig);
            IEnumALibelle maskAdmin = new CGraviteAlarmeAvecMasquage(EGraviteAlarmeAvecMasquage.MaskAdmin);
            lstGrave.Remove(maskAdmin);

            return lstGrave;
        }
        
	}
}
