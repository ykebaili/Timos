using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sc2i.common;
using sc2i.multitiers.client;
using System.Security.Principal;
using timos.client;
using System.Net.NetworkInformation;

using sc2i.process;

namespace TimosAdmin
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
            CResultAErreur result = timos.client.CInitialiseurClientTimos.InitClientTimos(new CTimosConsoleRegistre());
            if (result)
            {
                IIdentity id = WindowsIdentity.GetCurrent();;
                CSessionClient session = CSessionClient.CreateInstance();
                result = session.OpenSession(new CAuthentificationSessionProcess(), "Timos Admin", ETypeApplicationCliente.Windows);
                if (!result)
                    result.EmpileErreur("Erreur lors de l'authentification");
            }
            if (result)
                Application.Run(new CFormConsoleSuivi());
            else
                MessageBox.Show(result.Erreur.ToString());
        }

        public static List<string> GetIdsSupportAmovibles()
        {
            List<string> idsSupports = new List<string>();
            foreach (CDriveInfo d in CUtilDrives.GetPhysicalDrives())
                idsSupports.Add(d.ID);
            return idsSupports;
        }

        public static List<string> GetMACs()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            List<string> macAddresses = new List<string>();

            foreach (NetworkInterface adapter in nics)
                macAddresses.Add(adapter.GetPhysicalAddress().ToString());
            return macAddresses;
        }
    }
}