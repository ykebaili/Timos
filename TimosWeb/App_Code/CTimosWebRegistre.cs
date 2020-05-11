using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;


namespace timos.web
{
	/// <summary>
	/// Description résumée de CTiagAppRegistre.
	/// </summary>
	public class CTimosWebRegistre : C2iMultitiersClientRegistre
	{
		public CTimosWebRegistre()
		{
		}


		public static string ClePrincipale
		{
			get
			{
				return "Software\\futurocom\\Timos\\";
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
