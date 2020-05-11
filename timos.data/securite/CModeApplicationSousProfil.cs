using System;
using System.Collections;

using sc2i.common;

namespace timos.securite
{
	/// <summary>
	/// Description résumée de CModeApplicationSousProfil.
	/// </summary>
	public enum EModeApplicationSousProfil
	{
		Toujours = 0,
		EnReferentiel = 10,
		EnVersion = 20
	}
	public class CModeApplicationSousProfil : CEnumALibelle<EModeApplicationSousProfil>
	{
		/// //////////////////////////////////////////////////////
		public CModeApplicationSousProfil(EModeApplicationSousProfil statut)
			:base(statut)
		{
		}

		/// //////////////////////////////////////////////////////
		public override string Libelle
		{
			get
			{
				switch (Code)
				{
					case EModeApplicationSousProfil.Toujours :
						return I.T("Always|20010");
					case EModeApplicationSousProfil.EnReferentiel :
						return I.T("Reference version|20011");
					case EModeApplicationSousProfil.EnVersion :
						return I.T("Future version|20012");
				}
				return "";
			}
		}
	}
}
