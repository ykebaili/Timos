using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using futurocom.snmp.Proxy;
using sc2i.data;
using sc2i.multitiers.client;
using sc2i.common;
using timos.data.snmp.Proxy;
using sc2i.process;

namespace timos.data.serveur.snmp.Proxy
{
    public class CFournisseurDeConfigurationProxy : IFournisseurDeConfigurationProxy
    {
        public CSnmpProxyConfiguration GetConfigurationDeProxy(int nIdProxy)
        {
            using (CSessionClient session = CSessionClient.CreateInstance())
            {
                CResultAErreur result = session.OpenSession(new CAuthentificationSessionProcess());
                if (!result)
                    return null;
                using (CContexteDonnee ctx = new CContexteDonnee(session.IdSession, true, false))
                {
                    CSnmpProxyInDb proxy = new CSnmpProxyInDb(ctx);
                    if (proxy.ReadIfExists(nIdProxy))
                    {
                        return proxy.GetConfiguration();
                    }
                }
            }
            return null;
        }

    }
}
