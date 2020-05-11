using System;
using System.Collections.Generic;
using System.Text;

using sc2i.multitiers.client;

using Lys.Licence;

namespace timos.client
{
	public static class CGestionnaireProfilLicenceSurClient
	{
		private static List<CInfoLicenceUserProfil> m_profils;

		public static List<CInfoLicenceUserProfil> GetProfilsPossibles(int nIdSession)
		{
			if (m_profils == null)
			{
				IGestionnaireProfilLicence gestionnaire = (IGestionnaireProfilLicence)C2iFactory.GetNewObjetForSession("CGestionnaireProfilLicence",typeof(IGestionnaireProfilLicence),nIdSession);
				m_profils = gestionnaire.GetProfilsPossibles();
			}
			return new List<CInfoLicenceUserProfil>(m_profils);
		}

		public static CInfoLicenceUserProfil GetProfil(string strId)
		{
			foreach (CInfoLicenceUserProfil prof in GetProfilsPossibles ( 0 ))
				if (prof.Id == strId)
					return new CInfoLicenceUserProfil(prof.Id, prof.Nom, prof.Description, prof.Priorite);
			return null;
		}
	}
}
