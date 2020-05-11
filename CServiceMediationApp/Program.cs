using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.Remoting;

namespace CServiceMediationApp
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RemotingConfiguration.Configure("serviceMediation.remoting.config", false);
            RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
            Application.Run(new Form1());
        }
    }
}
