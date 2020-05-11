using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;

namespace spv.data
{
    public enum ETypeEvenementReseau
    {
        FinAlarme = 0,
        DebutAlarme = 1
    }

    public class CTypeEvenementReseau : CEnumALibelle<ETypeEvenementReseau>
    {
        public CTypeEvenementReseau(ETypeEvenementReseau evtType)
            : base(evtType)
        {
        }

        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case ETypeEvenementReseau.DebutAlarme:
                        return I.T("Beginning alarm|50014");
                    case ETypeEvenementReseau.FinAlarme:
                        return I.T("Ending alarm|50015");
                     default:
                        break;
                }
                return "";
            }
        }
    }
}