using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace sc2i.common.synchronisation
{
    public interface IAgentSynchronisation
    {
        string GetCle();
        string ParametresAgent { get; }
        void Init(string strParametresAgent );
        CResultAErreur DoOperation(IOperationSynchronisation operation, int nIdSession);
    }
}
