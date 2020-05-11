using System;

using Lys.Licence;

using timos.securite;

namespace timos.serveur
{

	/// <summary>
	/// Sert principalement à la méthode CanOpenSession dans le CGestionnaireSessionTimos pour véhiculer
	/// les infos importantes à affecter définitivement au CSessionClientSurServeurTimos relatives à
	/// la session ouverte (véhiculé au travers du Data du CResultAErreur de CanOpenSession)
	/// </summary>
    public class CInfoSessionTimos
    {
		public CInfoSessionTimos(
			CDonneesActeurUtilisateur donneesUtilisateur,
			CUserLicencePrtct userLicence,
			CUserProfilPrtct userProfil)
		{
			m_donneesUtilisateur = donneesUtilisateur;
			m_userLicence = userLicence;
			m_userProfil = userProfil;
		}


		private CUserLicencePrtct m_userLicence;
		public CUserLicencePrtct UserLicence
		{
			get
			{
				return m_userLicence;
			}
		}
		private CUserProfilPrtct m_userProfil;
		public CUserProfilPrtct UserProfil
		{
			get
			{
				return m_userProfil;
			}
		}
		private CDonneesActeurUtilisateur m_donneesUtilisateur;
		public CDonneesActeurUtilisateur DonneesUtilisateur
		{
			get
			{
				return m_donneesUtilisateur;
			}
		}
    }
}
