using System;
using System.Collections.Generic;
using System.Text;

using sc2i.multitiers.server;
using sc2i.multitiers.client;

using Lys.Applications.Timos.Smt;

using timos.client;
using sc2i.common;

namespace timos.serveur
{
#if DEBUG
	public partial class CParametreurLicence : C2iObjetServeur, IParametreurLicence
	{
		public CParametreurLicence(int nIdSession)
			:base(nIdSession)
		{

		}

		public void ReinitialiserRestrictions(CConfigModulesTimos config)
		{
			//CConfigurationRestrictions.ClearRestrictions();

			CListeRestrictionsUtilisateurSurType restrictionsModules = CModuleRestrictionProvider.GetRestrictionsApp(config);
            CConfigurationRestrictions.AjouteRestrictions(CTimosServeur.c_keyRestrictionAllUsers, restrictionsModules);

			foreach (CSessionClientSurServeur session in CGestionnaireSessionsTimos.ListeSessionsServeur)
				if (session is CSessionClientSurServeurTimos)
				{
					CSessionClientSurServeurTimos sessionTimos = (CSessionClientSurServeurTimos)session;
					sessionTimos.SetNewConfigModules(config);
				}
		}
	}
#endif
}
