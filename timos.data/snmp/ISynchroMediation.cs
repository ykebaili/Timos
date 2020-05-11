using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.multitiers.client;

namespace timos.data.snmp
{
    public interface ISynchroMediation : I2iMarshalObjectDeSession
    {
        CResultAErreur DoSynchro();
    }
}
