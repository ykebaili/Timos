using System;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.multitiers.client;
using timos.client;

namespace timos.test.metier
{
	class CTimosTestMetierApp
	{
		//---------------------------------------------
		private static CSessionClient m_sessionClient = null;
		public static void AssureInit()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_sessionClient == null)
			{
				result = CInitialiseurClientTimos.InitClientTimos(new CTimosTestMetierRegistre());
				if ( !result )
					throw new Exception(result.Erreur.ToString());
				m_sessionClient = CSessionClient.CreateInstance();
				result = m_sessionClient.OpenSession(new CAuthentificationSessionServiceClient());
				if ( !result )
					throw new Exception(result.Erreur.ToString());
			}
		}

		//---------------------------------------------
		public static CSessionClient SessionClient
		{
			get
			{
				return m_sessionClient;
			}
		}
	}
}
