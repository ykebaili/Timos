using System;

using sc2i.common;
using sc2i.data.serveur;

namespace spv.win32
{
	/// <summary>
	/// Description résumée de CSpvServeurRegistre.
	/// </summary>
	public class CSpvWin32Registre : C2iRegistre
	{
		public const string c_cleRegistre = "Software\\Futurocom\\Timos\\Spv\\";

        public CSpvWin32Registre()
		{
		}

		protected override string GetClePrincipale()
		{
			return c_cleRegistre;
		}

		protected override bool IsLocalMachine()
		{
			return false;
		}

        public static bool TriConsultationAlarmeCroissant
        {
            get
            {
                return new CSpvWin32Registre().GetValue("general", "AlarmSortOrder", "1") == "1";
            }
            set
            {
                new CSpvWin32Registre().SetValue ("general","AlarmSortOrder",value?"1":"0");
            }
        }



    }
}
