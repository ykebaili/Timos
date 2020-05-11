using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{

	public enum ECategorieAccesAlarme
	{
		SortieBoucle = 1,
		CommandeCommut = 4,
		EntreeBoucle = 7,
		AlarmeGSite = 8,
		TrapSnmp = 9
	}

    public class CCategorieAccesAlarme : CEnumALibelle<ECategorieAccesAlarme>
	{
        public CCategorieAccesAlarme(ECategorieAccesAlarme typeAcces)
			: base(typeAcces)
		{
		}

        [DynamicField("Label")]
		public override string Libelle
		{
			get 
			{
				switch (Code)
				{
                    case ECategorieAccesAlarme.CommandeCommut:
						return I.T("Order commutation|1");
                    case ECategorieAccesAlarme.EntreeBoucle:
						return I.T("Alarm input|2");
                    case ECategorieAccesAlarme.SortieBoucle:
						return I.T("Alarm output|3");
                    case ECategorieAccesAlarme.TrapSnmp:
						return I.T("Snmp trap|5");
                    case ECategorieAccesAlarme.AlarmeGSite:
						return I.T("GSite alarm|7");
					default:
						break;
				}
				return "";
			}
			
		}
	}
}
