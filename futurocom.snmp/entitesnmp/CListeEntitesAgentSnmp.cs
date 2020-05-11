using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using sc2i.common;
using System.Collections;

namespace futurocom.snmp.entitesnmp
{
    public class CListeEntitesSnmp : ArrayList
    {
        public CListeEntitesSnmp (  )
        {
        }

        //------------------------------------------
        [DynamicMethod("Search entity with specified index")]
        public CEntiteSnmpPourSupervision FindFromIndex(string strIndex)
        {
            foreach (CEntiteSnmpPourSupervision entitesnmp in this)
            {
                if (entitesnmp.Index == strIndex)
                    return entitesnmp;
            }
            return null;
        }


    }
}
