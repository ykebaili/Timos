using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;

namespace timos
{
	/// <summary>
	/// Description résumée de CTimosAppRegistre.
	/// </summary>
	public class CTimosAppRegistre : C2iMultitiersClientRegistre
	{
		public CTimosAppRegistre()
		{
		}

		public static string GetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			return new CTimosAppRegistre().GetValue(strKey, strRubrique, strDefaut);
		}
		public static void SetValueRegistre(string strKey, string strRubrique, string strDefaut)
		{
			new CTimosAppRegistre().SetValue(strKey, strRubrique, strDefaut);
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
			return false;
		}


		        
    }
}
