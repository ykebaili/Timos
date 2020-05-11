using System;
using System.Collections.Generic;
using System.Text;

using Lys.Licence;

namespace timos.client
{
	[Serializable]
	public class CInfoLicenceUserProfil
	{

		public const string c_nomIdentification = "INFOPROFILUSERLICENCE";

        private string m_strId;
        private string m_strDescription;
        private string m_strNom;
        private int m_priorite;

		public CInfoLicenceUserProfil()
		{

		}

		public CInfoLicenceUserProfil(CUserProfilPrtct profil)
		{
			m_strId = profil.Id;
			m_strNom = profil.Nom;
			m_strDescription = profil.Description;
            m_priorite = profil.Priorite;
            
		}

		public CInfoLicenceUserProfil(string strId, string strNom, string strDescrip, int nPriorite)
		{
			m_strId = strId;
			m_strNom = strNom;
			m_strDescription = strDescrip;
            m_priorite = nPriorite;
		}

		public static implicit operator CInfoLicenceUserProfil(CUserProfilPrtct profilPrtct)
		{
			return new CInfoLicenceUserProfil(
				profilPrtct.Id,
				profilPrtct.Nom,
				profilPrtct.Description,
                profilPrtct.Priorite);
		}


		public string Id
		{
			get
			{
				return m_strId;
			}
			set
			{
				m_strId = value;
			}
		}

		public string Description
		{
			get
			{
				return m_strDescription;
			}
			set
			{
				m_strDescription = value;
			}
		}

		public string Nom
		{
			get
			{
				return m_strNom;
			}
			set
			{
				m_strNom = value;
			}
		}

        public int Priorite 
        {
            get { return m_priorite; }
            set { m_priorite = value; }
        }
	}
}
