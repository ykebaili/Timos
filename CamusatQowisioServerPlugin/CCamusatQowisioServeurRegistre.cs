using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sc2i.common;

namespace CamusatQowisioServerPlugin
{
    public class CCamusatQowisioServeurRegistre : C2iRegistre
    {
        public const string c_cleRegistre = "Software\\Futurocom\\Timos\\";

        public CCamusatQowisioServeurRegistre()
        {
        }

        protected override string GetClePrincipale()
        {
            return c_cleRegistre;
        }

        protected override bool IsLocalMachine()
        {
            return true;
        }

        public static string FTPServer
        {
            get
            {
                return new CCamusatQowisioServeurRegistre().GetValue("CAQOWFTP", "server", "");
            }
        }

        public static string FTPUser
        {
            get
            {
                return new CCamusatQowisioServeurRegistre().GetValue("CAQOWFTP", "user", "");
            }
        }

        public static string FTPPassword
        {
            get
            {
                return new CCamusatQowisioServeurRegistre().GetValue("CAQOWFTP", "password", "");
            }
        }

        public static int FTPPort
        {
            get
            {
                return System.Convert.ToInt32((new CCamusatQowisioServeurRegistre().GetValue("CAQOWFTP", "port", "21")));
            }
        }

        public static string FTPIncomingDirectory
        {
            get
            {
                return new CCamusatQowisioServeurRegistre().GetValue("CAQOWFTP", "IncomingDirectory", "");
            }
        }


    }
}
