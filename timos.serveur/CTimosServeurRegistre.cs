using System;

using sc2i.common;
using sc2i.data.serveur;
using sc2i.documents;
using System.Collections.Generic;
using sc2i.multitiers.client;

namespace timos.serveur
{
	/// <summary>
	/// Description résumée de CTimosServeurRegistre.
	/// </summary>
    public class CTimosServeurRegistre : C2iMultitiersClientRegistre
	{
		public const string c_cleRegistre = "Software\\Futurocom\\Timos\\";

		public CTimosServeurRegistre()
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

		public static string DatabaseConnexionString
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("database","connexion","Data Source=127.0.0.1\\SQLEXPRESS;Initial Catalog=DBTIMOS;Integrated Security=True;Pooling=False");
			}
			set
			{
				new CTimosServeurRegistre().SetValue("database", "connexion", value);
			}
		}

		public static string NomTableSpaceIndexOracle
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("database", "NomTableSpaceIndexOracle", "");

			}
			set
			{
				new CTimosServeurRegistre().SetValue("database", "NomTableSpaceIndexOracle", value);
			}
		}


		public static string RepertoirePlugins
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("path","plugins",AppDomain.CurrentDomain.BaseDirectory+"plugins\\");
			}
		}

		public static string RepertoireGED
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("path","ged","");
			}
		}

        public static string RepertoireDataHotelInterne
        {
            get
            {
                return new CTimosServeurRegistre().GetValue("path", "Internal data hotel", "");
            }
        }

        public static string URLDataHotelPolling
        {
            get
            {
                return new CTimosServeurRegistre().GetValue("database", "Polling Data hotel", "tcp://127.0.0.1:8160");
            }
        }

        public static CTypeReferenceDocument[] TypeStockageAutorisePourLesUtilisateurs
        {
            get
            {
                string strTypes = new CTimosServeurRegistre().GetValue("general", "EDM Storage for users", "0;1");
                string[] strVals = strTypes.Split(';');
                List<CTypeReferenceDocument> lstFinale = new List<CTypeReferenceDocument>();
                foreach (string strVal in strVals)
                {
                    try
                    {
                        int nVal = Int32.Parse(strVal);
                        CTypeReferenceDocument.TypesReference tpRef = (CTypeReferenceDocument.TypesReference)nVal;
                        lstFinale.Add(new CTypeReferenceDocument(tpRef));
                    }
                    catch { }
                }
                return lstFinale.ToArray();
            }
        }

		public static string SMTPServer
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("smtp","server","");
			}
		}

		public static string SMTPUser
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("smtp","user","");
			}
		}

		public static string SMTPPassword
		{
			get
			{
				return new CTimosServeurRegistre().GetValue("smtp","password","");
			}
		}

        public static int SMTPPort
        {
            get
            {
                return System.Convert.ToInt32((new CTimosServeurRegistre().GetValue("smtp", "port", "0")));
            }
        }

        public static string[] ServeursAnnexes
        {
            get
            {
                return new CTimosServeurRegistre().GetValue("database", "Serveurs annexes", "").Split(';');
            }
        }

        public static bool IsServeurSecondaire
        {
            get
            {
                return new CTimosServeurRegistre().GetIntValue("database", "IsServeurSecondaire", 0) != 0;
            }
        }

		public static Type TypeConnection
		{
			get
			{
				string t = new CTimosServeurRegistre().GetValue("database", "TypeConnection", typeof(CSqlDatabaseConnexionSynchronisable).ToString());
				return CActivatorSurChaine.GetType(t);
			}
			set
			{
				new CTimosServeurRegistre().SetValue("database", "TypeConnection", value.ToString());
			}
		}

        //DateTime -> ToBinary -> ToString
        public static string DateLimite
        {
            get
            {
                string s = new CTimosServeurRegistre().GetValue("database", "systeme", "633359520000000000RKC");
                return s.Substring(0, s.Length - 3);
            }
            set
            {
                string t = value + "RKC";
                new CTimosServeurRegistre().SetValue("database", "systeme", t);
            }
        }

		public static bool EnableJournalisation
		{
			get
			{
				return new CTimosServeurRegistre().GetIntValue("database", "enable archiving", 0) != 0;
			}
		}

        public static string PrefixeTablesSMT
        {
            get
            {
                return new CTimosServeurRegistre().GetValue("database", "SMT tables prefix", "");
            }
        }

	}
}
