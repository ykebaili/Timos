using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Runtime.Remoting;
using sc2i.common;
using futurocom.snmp.Proxy;
using futurocom.snmp.mediation;

namespace ServiceMediation
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new TimosMediationService() 
			};
            
            ServiceBase.Run(ServicesToRun);
        }
    }
}
