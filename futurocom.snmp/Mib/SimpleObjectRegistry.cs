using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace futurocom.snmp.Mib
{
    /// <summary>
    /// Default object registry.
    /// </summary>
    public class SimpleObjectRegistry : ObjectRegistryBase
    {
        public SimpleObjectRegistry()
        {
            Tree = new ObjectTree();
        }

        
    }
}