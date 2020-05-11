using System;
using System.Collections.Generic;
using System.Text;

using sc2i.multitiers.client;
using System.Security.Principal;

namespace timos.client
{
	public interface IAuthentificateurParSupportAmovible
	{
		List<string> GetDrivesValide(List<string> idsDrivesPossibles);

		/// <summary>
		/// Retourne la liste des logins associés au support avec en sus si il est nécessaire 
		/// de tapper le mot de passe
		/// </summary>
		/// <param name="strIdDrive"></param>
		/// <returns></returns>
		Dictionary<string, bool> GetUsersPossibles(string strIdDrive);


		

	}

    [Serializable]
	public class CParametresLicence
	{
        private List<string> m_lstIdSupports = new List<string>();
        private List<string> m_lstMACs = new List<string>();
        private int[] m_strGroupeID;
        private string m_strUserID;
		
        
        public CParametresLicence(List<string> IdsSupports, List<string> MACs)
		{
			m_lstIdSupports = IdsSupports;
			m_lstMACs = MACs;
		}

		public List<string> IDsSupports
		{
			get
			{
				return m_lstIdSupports;
			}
		}

		public List<string> MACs
		{
			get
			{
				return m_lstMACs;
			}
		}

		public int[] GroupeID
		{
			get
			{
				return m_strGroupeID;
			}
			set
			{
				m_strGroupeID = value;
			}
		}

		public string UserID
		{
			get
			{
				return m_strUserID;
			}
			set
			{
				m_strUserID = value;
			}
		}

	}


	//public class CParametresUser
	//{
	//    public CParametresUser(IIdentity id, List<string> strIdsSupports, string strLogin, string strMDP)
	//    {
	//        m_id = id;
	//        m_strIdsSupports = strIdsSupports;
	//        m_strLogin = strIdsSupports;
	//        m_strMdp = strMDP;
	//    }
	//    private IIdentity m_id;
	//    public IIdentity IdentifiantAD
	//    {
	//        get
	//        {
	//            return m_id;
	//        }
	//    }

	//    private List<string> m_strIdsSupports;
	//    public List<string> IdsSupports
	//    {
	//        get
	//        {
	//            return m_strIdsSupports;
	//        }
	//    }

	//    private string m_strLogin;
	//    public string Login
	//    {
	//        get
	//        {
	//            return m_strLogin;
	//        }
	//    }

	//    private string m_strMdp;
	//    public string MotDePass
	//    {
	//        get
	//        {
	//            return m_strMdp;
	//        }
	//    }
	//}


    //------------------------------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
	public class CAuthentificationSessionTimos : IAuthentificationSession
	{

		public CAuthentificationSessionTimos(CParametresLicence paraLicence)
		{
			m_paramLicence = paraLicence;
		}
		private CParametresLicence m_paramLicence;

		public CParametresLicence ParametresIdentificationLicence
		{
			get
			{
				return m_paramLicence;
			}
			set
			{
				m_paramLicence = value;
			}
		}
	}



    //------------------------------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CAuthentificationSessionTimosSupportAmovible : CAuthentificationSessionTimos
    {
        private string m_strIdSupport;

        public CAuthentificationSessionTimosSupportAmovible(string strIdSupport, CParametresLicence paraLicence)
            : base(paraLicence)
        {
            m_strIdSupport = strIdSupport;

        }
        public string IdSupport
        {
            get
            {
                return m_strIdSupport;
            }
            set
            {
                m_strIdSupport = value;
            }
        }

    }

    //------------------------------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
	public class CAuthentificationSessionTimosAD : CAuthentificationSessionTimos
	{
		string m_strId = "";

		/// ///////////////////////////////////////////////////////
		public CAuthentificationSessionTimosAD(CParametresLicence paraLicence)
			:base(paraLicence)
		{
			SetIdentity(WindowsIdentity.GetCurrent());
		}

		/// ///////////////////////////////////////////////////////
		public CAuthentificationSessionTimosAD(IIdentity id, CParametresLicence paraLicence)
			:base ( paraLicence )
		{
			SetIdentity ( id );
		}

		/// ///////////////////////////////////////////////////////
		private void SetIdentity(IIdentity identity)
		{
			if (identity.IsAuthenticated)
			{
				m_strId = identity.Name;
				//Supprime le domaine
				int nPos = m_strId.LastIndexOf('\\');
				if (nPos > 0)
					m_strId = m_strId.Substring(nPos + 1);
			}
		}

		/// ///////////////////////////////////////////////////////
		public string UserId
		{
			get
			{
				return m_strId;
			}
		}
	}

    //------------------------------------------------------------------------------------
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class CAuthentificationSessionTimosLoginPwd : CAuthentificationSessionTimos
	{
		private string m_strLogin;
        private string m_strMdp;

        public CAuthentificationSessionTimosLoginPwd(string strLogin, string strMdp, CParametresLicence paraLicence)
            : base(paraLicence)
        {
            m_strLogin = strLogin;
            m_strMdp = strMdp;
        }
        
        public string Login
		{
			get
			{
				return m_strLogin;
			}
			set
			{
				m_strLogin = value;
			}
		}
		public string MotDePasse
		{
			get
			{
				return m_strMdp;
			}
			set
			{
				m_strMdp = value;
			}
		}


	}
}
