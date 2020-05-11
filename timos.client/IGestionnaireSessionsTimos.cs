using System;
using System.Collections.Generic;
using System.Security.Principal;

using sc2i.multitiers.client;
using sc2i.common;

using Lys.Licence;
using timos.client.licence;

namespace timos.client
{
	/// <summary>
	/// Description résumée de IGestionnaireSessionsTimos.
	/// </summary>
	public interface IGestionnaireSessionsTimos : IGestionnaireSessions
	{
		CResultAErreur IsUserAdValide(string strIdAd);
		CResultAErreur IsUserValide(string strLogin, string strMdp);
		CResultAErreur IsUserValide(string strIdSupport);
        CLicenceLogicielPrtct GetLicenceServeur();
        IEnumerable<CNombreUtilisePourTypeLicence> GetNombreRestantParType();
        void RefreshNombreUtiliseParTypes();
        IList<CAlerteLicence> GetAlertesLicences();
        void RecalculeAffectationLicencesEtProfils();
    }


}
