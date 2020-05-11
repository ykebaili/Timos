using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;

namespace timos
{
	/// <summary>
	/// Description résumée de CTimosAppRegistre.
	/// </summary>
	public class CTimosTestMetierRegistre : C2iMultitiersClientRegistre
	{
		public CTimosTestMetierRegistre()
		{
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
