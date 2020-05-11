using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    [Flags]
    public enum ETypeElementSupervise
    {
        Aucun = 0,
        Site = 1,
        Equipement = 3,
        Lien = 4,
        EntiteSnmp = 9

    }

    
    public class CTypeElementSupervise : CEnumALibelle<ETypeElementSupervise>
    {
        public CTypeElementSupervise(ETypeElementSupervise type)
            : base(type)
        {
        }

        public override string Libelle
        {
            get {
                switch (Code)
                {
                    case ETypeElementSupervise.Aucun:
                        return I.T("None|20009");
                    case ETypeElementSupervise.Site:
                        return I.T("Site|20010");
                    case ETypeElementSupervise.Equipement:
                        return I.T("Logical equipment|20011");
                    case ETypeElementSupervise.Lien:
                        return I.T("Network link|20012");
                    case ETypeElementSupervise.EntiteSnmp :
                        return I.T("Snmp entity|20013");
                }
                return I.T("None|20009");
            }
        }
    }
}
