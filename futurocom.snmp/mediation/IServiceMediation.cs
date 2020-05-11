using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;
using sc2i.common.trace;

namespace futurocom.snmp.mediation
{
    public interface IServiceMediation
    {
        CConfigurationServiceMediation Configuration{get;}

        bool IsStarted { get; }

        CResultAErreur Start();
        CResultAErreur Stop();

        void AddTraceListener(IFuturocomTraceListener listener);
        void RemoveTraceListener(IFuturocomTraceListener listener);
    }
}
