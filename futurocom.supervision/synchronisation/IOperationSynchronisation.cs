using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace sc2i.common.synchronisation
{
    public interface IOperationSynchronisation
    {
        IAgentSynchronisation GetAgent();
        string IdElementASynchroniser { get; }
        EOperationSynchronisationSurAgentSynchronisation Operation { get; }
    }
}
