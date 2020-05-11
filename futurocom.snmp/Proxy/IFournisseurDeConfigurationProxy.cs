using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.snmp.Proxy
{
    public interface IFournisseurDeConfigurationProxy
    {
        CSnmpProxyConfiguration GetConfigurationDeProxy(int nIdProxy);
    }
}
