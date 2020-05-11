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

    //Code de gravité utilisés pour gérer les couleurs des alarmes
    //Contient les gravités + pas d'alarme, 
    public enum ECouleurAlarme
	{
        NoAlarm = 0,
        MaskBrig = 1,
        MaskAdmin = 2,
		Warning = 3,
		Undetermined = 4,
		Minor = 5,
		Major = 6,
		Critical = 7,
        NoAlarmAcces = 8,
        MinorOrMajorButOk = 9,
        NOk = 10
	}


    public class CCouleurAlarme : CEnumALibelle<ECouleurAlarme>
    {
        public CCouleurAlarme(ECouleurAlarme gravAlarme)
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
                    case ECouleurAlarme.NoAlarm:
                        return I.T("No alarm|60059");
                    case ECouleurAlarme.Warning:
						return I.T("Warning|100");
                    case ECouleurAlarme.MaskBrig:
                        return I.T("Operating agent masking|60000");
                    case ECouleurAlarme.MaskAdmin:
                        return I.T("Administrator masking|60001");                        
                    case ECouleurAlarme.Undetermined:
						return I.T("Undetermined|101");
                    case ECouleurAlarme.Minor:
						return I.T("Minor|102");
                    case ECouleurAlarme.Major:
						return I.T("Major|103");
                    case ECouleurAlarme.Critical:
						return I.T("Critical|104");
                    case ECouleurAlarme.NoAlarmAcces :
                        return I.T("No alarm acces|20025");
                    case ECouleurAlarme.MinorOrMajorButOk :
                        return I.T("Minor or major but Ok|2002");
                    case ECouleurAlarme.NOk :
                        return I.T("Not fonctionnal|20024");
					default:
						break;
				}
				return "";
			}            
		}
	}
}
