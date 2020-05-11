using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;


namespace sc2i.workflow
{
    public interface ISMSSender
    {
        CResultAErreur SendMessage(CMessageSMSPourEnvoi message);
    }
}
