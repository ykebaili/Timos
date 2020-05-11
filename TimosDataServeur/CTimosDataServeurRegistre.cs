using System;

using sc2i.common;
using sc2i.data.serveur;

namespace TimosDataServeur
{
	/// <summary>
	/// Description résumée de CTimosServeurRegistre.
	/// </summary>
	public class CTimosDataServeurRegistre : C2iRegistre
	{
		public const string c_cleRegistre = "Software\\Futurocom\\Timos\\";

		public CTimosDataServeurRegistre()
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

		public static DateTime LastDateChamps
		{
			get
			{
				string strDate = new CTimosDataServeurRegistre().GetValue("DEBUG", "Last date MajBase", "");
				if ( strDate == "" )
					return DateTime.Now.AddYears (-5);
				return CUtilDate.FromUniversalString ( strDate );
			}
			set
			{
				new CTimosDataServeurRegistre().SetValue("DEBUG", "Last date MajBase", CUtilDate.GetUniversalString(value));
			}
		}

		public static string ConnexionOracle
		{
			get
			{
				return new CTimosDataServeurRegistre().GetValue("Database","ConnexionOracle", @"Data Source=DBTIMOS;PWCR=" + C2iCrypto.Crypte("MDPPRO") + ";User ID=SMTUSER;Unicode=True;Persist Security Info=True");
			}
		}

		public static string ConnexionSql
		{
			get
			{
				return new CTimosDataServeurRegistre().GetValue("Database", "ConnexionSql", @"Data Source=127.0.0.1\SQLEXPRESS;Initial Catalog=DBTIMOS;Integrated Security=True;Pooling=False");
			}
		}

	}
}
