using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using sc2i.common;

namespace TestSnmp
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

            AppDomain.CurrentDomain.Load("futurocom.snmp");
            AppDomain.CurrentDomain.Load("futurocom.win32.snmp");
            AppDomain.CurrentDomain.Load("futurocom.supervision");
            AppDomain.CurrentDomain.Load("sc2i.expression");
            AppDomain.CurrentDomain.Load("futurocom.easyquery");

            CAutoexecuteurClasses.RunAutoexecs();

            Application.Run(new CFormTrapReceiver());
        }
    }
}
