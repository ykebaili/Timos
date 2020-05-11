using System;

using sc2i.common;

namespace TimosInventoryLauncher
{
	/// <summary>
	/// Description résumée de CLysRegistreLauncher.
	/// </summary>
	public class CTimosInventoryRegistreLauncher : C2iRegistre
	{
		public CTimosInventoryRegistreLauncher()
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
