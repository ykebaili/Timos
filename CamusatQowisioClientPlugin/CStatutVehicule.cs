using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace CamusatQowisioClientPlugin
{
    public enum EStatutVehicule
    {
        Stopped = 0,
        Travelling = 1
    }

    //---------------------------------------------------------------------------
    public class CStatutVehicule : CEnumALibelle<EStatutVehicule>
    {
        public CStatutVehicule(EStatutVehicule statut)
            : base(statut)
        {
        }

        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case EStatutVehicule.Stopped:
                        return "Stopped";
                        break;
                    case EStatutVehicule.Travelling:
                        return "Travelling";
                        break;
                    default:
                        break;
                }
                return "?";
            }
        }
    }
        
}
