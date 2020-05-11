using System;
using System.Collections.Generic;

using sc2i.multitiers.client;

using Lys.Licence;

namespace timos.client
{
	public interface IGestionnaireProfilLicence
	{
		List<CInfoLicenceUserProfil> GetProfilsPossibles();
		CInfoLicenceUserProfil GetProfil(string strId);

	}
}
