using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace futurocom.supervision
{
    public interface ITraiteurAcquittementAlarme
    {
        CResultAErreur AcquitteAlarme(string strIdAlarme, DateTime dateAcquittement, int nIdSession);
    }
}
