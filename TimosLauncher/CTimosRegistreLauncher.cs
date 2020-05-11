using System;

using sc2i.common;

namespace TimosLauncher
{
	/// <summary>
	/// Description résumée de CLysRegistreLauncher.
	/// </summary>
	public class CTimosRegistreLauncher : C2iRegistre
	{
		public CTimosRegistreLauncher()
		{
		}

		/// ///////////////////////////////////////////////
		protected override bool IsLocalMachine()
		{
			return true;
		}

		/// ///////////////////////////////////////////////
		protected override string GetClePrincipale()
		{
			return "SOFTWARE\\Futurocom\\Updater\\";
		}

		/// ///////////////////////////////////////////////
		public int GetLocalPort()
		{
			return GetIntValue( "Client setup", "Local port", 0 );
		}

		
	
	}
}
