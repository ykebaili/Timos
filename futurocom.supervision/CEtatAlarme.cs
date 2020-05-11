using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public enum EEtatAlarme
    {
        Unknown = 0,
        Open = 20,
        Close = 40
    }
    //-----------------------------------------------------
    [Serializable]
    public class CEtatAlarme : CEnumALibelle<EEtatAlarme>
    {
        public CEtatAlarme(EEtatAlarme etat)
            : base(etat)
        {
        }

        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EEtatAlarme.Unknown:
                        return I.T("Unknown|20003");
                        break;
                    case EEtatAlarme.Open:
                        return I.T("Open|20004");
                        break;
                    case EEtatAlarme.Close:
                        return I.T("Closed|20005");
                        break;
                }
                return "";
            }
        }
    }
}
