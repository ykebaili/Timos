using System;

using sc2i.common;
using sc2i.data.serveur;

namespace spv.serveur
{
	/// <summary>
	/// Description résumée de CSpvServeurRegistre.
	/// </summary>
	public class CSpvServeurRegistre : C2iRegistre
	{
		public const string c_cleRegistre = "Software\\Futurocom\\Timos\\Spv\\";

		public CSpvServeurRegistre()
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
				return new CSpvServeurRegistre().GetValue("database", "connexion", "Data Source=DBTIMOS;Password=SPVMDP;User ID=SPVUSER;Unicode=True;Persist Security Info=True");
			}
			set
			{
				new CSpvServeurRegistre().SetValue("database", "connexion", value);
			}
		}

		public static string NomTableSpaceIndexOracle
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("database", "NomTableSpaceIndexOracle", "");

			}
			set
			{
				new CSpvServeurRegistre().SetValue("database", "NomTableSpaceIndexOracle", value);
			}
		}


		public static string RepertoirePlugins
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("path","plugins",AppDomain.CurrentDomain.BaseDirectory+"\\plugins\\");
			}
		}

		public static string RepertoireGED
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("path","ged","");
			}
		}

		public static string SMTPServer
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("smtp","server","");
			}
		}

		public static string SMTPUser
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("smtp","user","");
			}
		}

		public static string SMTPPassword
		{
			get
			{
				return new CSpvServeurRegistre().GetValue("smtp","password","");
			}
		}

        public static string[] ServeursAnnexes
        {
            get
            {
                return new CSpvServeurRegistre().GetValue("database", "Serveurs annexes", "").Split(';');
            }
        }

        public static bool IsServeurSecondaire
        {
            get
            {
                return new CSpvServeurRegistre().GetIntValue("database", "IsServeurSecondaire", 0) != 0;
            }
        }

		public static Type TypeConnection
		{
			get
			{
				string t = new CSpvServeurRegistre().GetValue("database", "TypeConnection", typeof(CSqlDatabaseConnexionSynchronisable).ToString());
				return CActivatorSurChaine.GetType(t);
			}
			set
			{
				new CSpvServeurRegistre().SetValue("database", "TypeConnection", value.ToString());
			}
		}

        //DateTime -> ToBinary -> ToString
        public static string DateLimite
        {
            get
            {
                string s = new CSpvServeurRegistre().GetValue("database", "systeme", "633359520000000000RKC");
                return s.Substring(0, s.Length - 3);
            }
            set
            {
                string t = value + "RKC";
                new CSpvServeurRegistre().SetValue("database", "systeme", t);
            }
        }

		public static bool EnableJournalisation
		{
			get
			{
				return new CSpvServeurRegistre().GetIntValue("database", "enable archiving", 0) != 0;
			}
		}

        public static string PrefixeTablesSPV
        {
            get
            {
                return new CSpvServeurRegistre().GetValue("database", "SPV tables prefix", "");
            }
        }

	}
}
