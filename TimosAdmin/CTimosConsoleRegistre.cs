using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;

namespace TimosAdmin
{
	/// <summary>
	/// Description résumée de CTimosConsoleRegistre.
	/// </summary>
	public class CTimosConsoleRegistre : C2iMultitiersClientRegistre
	{
		public CTimosConsoleRegistre()
		{
		}

		public static string GetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			return new CTimosConsoleRegistre().GetValue(strKey, strRubrique, strDefaut);
		}
		public static void SetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			new CTimosConsoleRegistre().SetValue(strKey, strRubrique, strDefaut);
		}

		public static string ClePrincipale
		{
			get
			{
				return "Software\\Futurocom\\timos\\";
			}
		}

		protected override string GetClePrincipale()
		{
			return ClePrincipale;
		}

		protected override bool IsLocalMachine()
		{
			return true;
		}


		
	}
}
