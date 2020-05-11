using System;
using System.Collections;
using sc2i.common;
using sc2i.multitiers.client;

namespace TimosProcess
{
	/// <summary>
	/// Description résumée de CTimosAppRegistre.
	/// </summary>
	public class CTimosProcessRegistre : C2iMultitiersClientRegistre
	{
		private static bool m_bLocalMachine = false;
		public CTimosProcessRegistre()
		{
		}

		public static void SetIsLocalMachine(bool bLocal)
		{
			m_bLocalMachine = bLocal;
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
			return m_bLocalMachine;
		}



	}
}
