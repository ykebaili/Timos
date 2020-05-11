using sc2i.common;
using sc2i.multitiers.client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using timos;

namespace ImportDocsMyanmar
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

            CTimosAppRegistre timosRegistre = new CTimosAppRegistre();
            
            CResultAErreur result = timos.client.CInitialiseurClientTimos.InitClientTimos(timosRegistre, true, null);
            if (result)
            {
                CSessionClient session = CSessionClient.CreateInstance();
                result = session.OpenSession(
                    new CAuthentificationSessionSousSession(0),
                    "Myanmar documents import",
                    ETypeApplicationCliente.Service
                    );
                if (result)
                    CImportMyanmarConst.SessionClient = session;
            }
            if (!result)
            {
                MessageBox.Show("Error while connecting to Timos, limited functions !");
            }
            

            Application.Run(new CFormMain());
        }
    }
}
