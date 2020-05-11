using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TimosInventory.data;
using sc2i.common;

namespace TimosInventory
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

            AppDomain.CurrentDomain.Load("TimosInventory.data");

            CTraducteur.ReadFichier("TimosInventory.mes");


            CAutoexecuteurClasses.RunAutoexecs();


            Application.Run(new CFormMain());
        }
    }
}
