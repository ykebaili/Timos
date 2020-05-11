using System;

using sc2i.common;


namespace timos.data
{
	public enum EModeDeplacementProjet
	{
		MoveAutoOnly = 0,
        MoveNonAuto = 1,
        MoveNonAutoEtTermines = 2

	}

	public class CModeDeplacementProjet : CEnumALibelle<EModeDeplacementProjet>
	{
		/// //////////////////////////////////////////////////////
		public CModeDeplacementProjet(EModeDeplacementProjet ope)
			: base(ope)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				string strResult = "";
                switch (Code)
                {
                    case EModeDeplacementProjet.MoveAutoOnly:
                        strResult = I.T("Only auto|20074");
                        break;
                    case EModeDeplacementProjet.MoveNonAuto:
                        strResult = I.T("Move Non Auto|20075");
                        break;
                    case EModeDeplacementProjet.MoveNonAutoEtTermines:
                        strResult = I.T("Move non auto and ended|20076");
                        break;
                    default:
                        break;
                }

                return strResult;
            }
        }
	}
}
