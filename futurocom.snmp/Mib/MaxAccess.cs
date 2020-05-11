using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace futurocom.snmp.Mib
{
    public enum MaxAccess
    {
        notAccessible,
        accessibleForNotify,
        readOnly,
        readWrite,
        readCreate
    }

}
