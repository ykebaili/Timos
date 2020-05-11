using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace timos.FinalCustomer
{
    public static class CFinalCustomerInformations
    {
        //Fichier d'informations générales (Couples clé=valeur)
        public const string c_strFichierInfosGenerales = "gnrl.gnp";
        public const string c_strFichierSplash = "splsh.gnp";
        public const string c_strFichierLogin = "lgn.gnp";
        public const string c_strFichierAbout = "bt.gnp";
        public const string c_strFichierIcon = "icn.gnp";

        //INFORMATIONS GENERALES
        public const string c_strCleNomApplication = "APPLICATIONNAME";

        private static Dictionary<string, string> m_dicValeursCustom = new Dictionary<string, string>();

        public static void Init()
        {
            string strFile = GetFinalCustomerPath() + c_strFichierInfosGenerales;
            if (File.Exists(strFile))
            {
                StreamReader reader = new StreamReader(strFile);
                string strLigne = "";
                while ((strLigne = reader.ReadLine()) != null)
                {
                    string[] strDatas = strLigne.Split('=');
                    if (strDatas.Length ==2)
                    {
                        m_dicValeursCustom[strDatas[0].Trim().ToUpper()] = strDatas[1].Trim();
                    }
                }
                reader.Close();
                reader.Dispose();
            }
        }

        public static string GetApplicationName()
        {
            string strVal = "Futurocom-Timos";
            m_dicValeursCustom.TryGetValue(c_strCleNomApplication, out strVal);
            return strVal;
        }


        private static string GetFinalCustomerPath()
        {
            string strRep = Application.ExecutablePath;
            int nLastSlash = strRep.LastIndexOf("\\");
            if (nLastSlash > 0)
            {
                strRep = strRep.Substring(0, nLastSlash+1);
                strRep += "custom\\";
                return strRep;
            }
            return "";
        }

        public static string GetSplashImageFile ( )
        {
            string strFile = GetFinalCustomerPath() + c_strFichierSplash;
            if ( File.Exists ( strFile ) )
                return strFile;
            return null;
        }

        public static string GetLoginImageFile()
        {
            string strfile = GetFinalCustomerPath() + c_strFichierLogin;
            if ( File.Exists ( strfile ) )
                return strfile;
            return null;
        }

        public static string GetAboutImageFile()
        {
            string strFile = GetFinalCustomerPath() + c_strFichierAbout;
            if (File.Exists(strFile))
                return strFile;
            return null;
        }

        public static string GetGeneralIconFile()
        {
            string strFile = GetFinalCustomerPath() + c_strFichierIcon;
            if (File.Exists(strFile))
                return strFile;
            return null;
        }
    }
}
