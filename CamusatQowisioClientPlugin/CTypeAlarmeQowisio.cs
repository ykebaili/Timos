using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace CamusatQowisioClientPlugin
{
    public enum ETypeAlarmeQowisio
    {
        AbnormalVehicleTankFuelLevel =2,
        DropOfFuelLevel=4,
        AbnormalGensetTankFuelLevel=5,
        AbnormalLostOfFuelDuringFillOut = 7,
        ServiceDisconnected=8,
        BoxDisconnected = 9,
        FillIn=10,
        FillOut=11
    }
    public class CTypeAlarmeQowisio : CEnumALibelle<ETypeAlarmeQowisio>
    {
        public CTypeAlarmeQowisio(ETypeAlarmeQowisio code)
            : base(code)
        {
        }


        [DynamicField("Label")]
        public override string Libelle
        {
            get
            {
                switch (Code)
                {
                    case ETypeAlarmeQowisio.AbnormalVehicleTankFuelLevel:
                        return "Abnormal vehicule tank fuel level";
                    case ETypeAlarmeQowisio.DropOfFuelLevel:
                        return "Drop of fuel level";
                    case ETypeAlarmeQowisio.AbnormalGensetTankFuelLevel:
                        return "Abnormal genset tank fuel level";
                    case ETypeAlarmeQowisio.AbnormalLostOfFuelDuringFillOut:
                        return "Abnormal lost of fuel during fill out";
                    case ETypeAlarmeQowisio.ServiceDisconnected:
                        return "Service disconnected";
                    case ETypeAlarmeQowisio.BoxDisconnected:
                        return "Box disconnected";
                    case ETypeAlarmeQowisio.FillIn:
                        return "Fill in start/stop";
                    case ETypeAlarmeQowisio.FillOut:
                        return "Fill out start/stop";
                    default:
                        return "?";
                }
            }
        }
    }
}
