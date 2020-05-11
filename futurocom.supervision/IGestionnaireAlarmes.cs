using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.expression;

namespace futurocom.supervision
{
    public interface IGestionnaireAlarmes
    {
        IEnumerable<CLocalAlarme> CurrentAlarms { get; }

        IEnumerable<CLocalAlarme> EndedAlarms { get; }

        CLocalAlarme GetCurrentAlarmFromKey(string strKey);

        CLocalAlarme GetAlarmFromId(string strId);
    }
}
