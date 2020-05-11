using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Net.NetworkInformation;

using sc2i.common;
using sc2i.multitiers.client;

using timos.client;

namespace timos
{

	public enum EMotifEchecAuthentification
	{ 
		UserIncorrect,
		OuvertureSession,
	}

	public static class CAuthentificateurTimos
	{

		public static CResultAErreur TryAuthentificationSupportAmovible()
		{
			CResultAErreur result = CResultAErreur.True;
			//Identification par Support Amovible
			List<string> idsSupports = GetIdsSupportAmovibles();
			bool bFind = false;
			foreach(string strIdSupport in idsSupports)
			{
				bFind = true;
				CSessionClient session = CSessionClient.CreateInstance();
				result = session.OpenSession(new CAuthentificationSessionTimosSupportAmovible(strIdSupport,new CParametresLicence(idsSupports, GetMACs())));
                if (result)
                {
                    CTimosApp.SessionClient = session;
                    break;
                }
			}
			if (!bFind)
			{
				result.EmpileErreur(I.T("There is no recognized removable device|30019"));
			}

			return result;
		}
		public static CResultAErreur TryAuthentificationAD()
		{
			CResultAErreur result = CResultAErreur.True;
			IIdentity id = GetIdentiteAD();
		    CSessionClient session = CSessionClient.CreateInstance();
			result = session.OpenSession(new CAuthentificationSessionTimosAD(id, new CParametresLicence(GetIdsSupportAmovibles(), GetMACs())));
			if (result)
				CTimosApp.SessionClient = session;
			else
				result.EmpileErreur(I.T("Incorrect AD user|30020"));

            return result;
		}

		public static CResultAErreur TryAuthentification(string strLogin, string strMdp)
		{
			CResultAErreur result = CResultAErreur.True;
			CSessionClient session = CSessionClient.CreateInstance();
			result = session.OpenSession(new CAuthentificationSessionTimosLoginPwd(strLogin, strMdp, new CParametresLicence(GetIdsSupportAmovibles(), GetMACs())));

            if (result)
                CTimosApp.SessionClient = session;
            else
                result.EmpileErreur(I.T("Login or password identification error|10092"));
			
            return result;
		}

		private static IGestionnaireSessionsTimos m_gestionnaire;
		private static IGestionnaireSessionsTimos GestionnaireSessionTimos
		{
			get
			{
				if (m_gestionnaire == null)
					m_gestionnaire = (IGestionnaireSessionsTimos)C2iFactory.GetNewObject(typeof(IGestionnaireSessionsTimos));

				return m_gestionnaire;
			}
		}
		

		public static List<string> GetIdsSupportAmovibles()
		{
			List<string> idsSupports = new List<string>();
            try
            {
                foreach (CDriveInfo d in CUtilDrives.GetPhysicalDrives())
                    idsSupports.Add(d.ID);
            }
            catch { }
			return idsSupports;
		}

		public static List<string> GetMACs()
		{
			
			List<string> macAddresses = new List<string>();
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                    macAddresses.Add(adapter.GetPhysicalAddress().ToString());
            }
            catch { }
			return macAddresses;
		}
		private static IIdentity GetIdentiteAD()
		{
			return WindowsIdentity.GetCurrent();
		}
	}
}
