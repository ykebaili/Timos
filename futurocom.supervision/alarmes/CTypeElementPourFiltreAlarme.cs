using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision.alarmes
{
    [Flags]
    public enum ETypeElementPourFiltreAlarme
    {
        AlarmType = 10,
        Site = 20,
        LogicalEquipment = 30,
        NetworkLink = 40,
        SnmpEntity = 50
    }

    /// <summary>
    /// 
    /// </summary>
    public class CTypeElementPourFiltreAlarme : CEnumALibelle<ETypeElementPourFiltreAlarme>
    {
        public CTypeElementPourFiltreAlarme(ETypeElementPourFiltreAlarme tp)
            :base(tp)
        {
        }

        public override string Libelle
        {
            get 
            {
                switch (Code)
                {
                    case ETypeElementPourFiltreAlarme.AlarmType:
                        return I.T("Alarm Type|10003");
                    case ETypeElementPourFiltreAlarme.Site:
                        return I.T("Site|10004");
                    case ETypeElementPourFiltreAlarme.LogicalEquipment:
                        return I.T("Logical Equipment|10005");
                    case ETypeElementPourFiltreAlarme.NetworkLink:
                        return I.T("Network Link|10006");
                    case ETypeElementPourFiltreAlarme.SnmpEntity:
                        return I.T("SNMP Entity|10007");
                    default:
                        break;
                }
                return "";
            
            }
        }
    }
}
