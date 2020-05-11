using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.supervision
{
    public interface IBaseTypesAlarmes
    {
        IEnumerable<CLocalTypeAlarme> TypesAlarmes { get; }
        CLocalTypeAlarme GetTypeAlarme(string strIdTypeAlarme);
    }
}
