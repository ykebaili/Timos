using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sc2i.data.dynamic;
using timos.data;
using sc2i.common;
using System.Diagnostics;
using System.Threading;

namespace TimosDataServeur
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

            Application.Run(new CFormServeurTimos());
            Process current = Process.GetCurrentProcess();
            C2iStopApp.AppStopper.Set();
        }
    }
}