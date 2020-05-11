using System;

using sc2i.common;
using sc2i.data.dynamic;

namespace sc2i.custom
{
	/// <summary>
	/// Description résumée de CRoleFormulaireSurImpressionWin32.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CRoleFormulaireSurImpressionWin32
	{
		public const string c_roleChampCustom = "OVER_WIN32";
		
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(CRoleFormulaireSurImpressionWin32.c_roleChampCustom, "Overdraw", null) ;
		}
	}
}
