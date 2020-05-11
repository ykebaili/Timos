using System;
using System.Collections.Generic;
using System.Text;

using timos.client;

using Lys.Licence;

using sc2i.multitiers.server;

namespace timos.serveur
{
	public class CGestionnaireProfilLicence : C2iObjetServeur, IGestionnaireProfilLicence
	{
		public CGestionnaireProfilLicence(int nIdSession)
			:base(nIdSession)
		{

		}

		private List<CInfoLicenceUserProfil> m_profils;
		public List<CInfoLicenceUserProfil> GetProfilsPossibles()
		{
			if (m_profils == null)
			{
				CTimosServeur srv = CTimosServeur.GetInstance();
				if (srv != null && srv.LicenceLogiciel != null)
				{
					List<CUserProfilPrtct> profils = srv.LicenceLogiciel.ProfilsUtilisateurs;
					m_profils = new List<CInfoLicenceUserProfil>();
					foreach (CUserProfilPrtct prof in profils)
						m_profils.Add(prof);
				}
			}
			return m_profils;
		}

		public CInfoLicenceUserProfil GetProfil(string strId)
		{
			foreach (CInfoLicenceUserProfil prof in m_profils)
				if (prof.Id == strId)
					return prof;
			return null;
		}
	}
}
