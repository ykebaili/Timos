using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public interface ITraiteurRetombeeManuelleAlarme
    {
        CResultAErreur RetombageManuel(string strIdAlarme, int nIdSession);
    }
}
