using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.Runtime.Remoting.Services;
using System.Runtime.Remoting;
using System.Security;

using sc2i.common;
using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using sc2i.process;
using sc2i.data.serveur;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.acteurs;
using timos.data;
using timos.client;
using timos.securite;
using timos;
using timos.client.licence;

namespace timos.serveur
{
	/// <summary>
	/// Description résumée de CGestionnaireSessionsTimos.
	/// </summary>
	public class CGestionnaireSessionsTimos : CGestionnaireSessions, IGestionnaireSessionsTimos
	{
		//Id de session pour le gestionnaire de session
		//Le gestionnaire de sessions accédant n'importe quand à la base, il 
		//doit avoir son propre numéro de session
		private static CSessionClient m_session = null;

		/// ///////////////////////////////////////////////////
		public CGestionnaireSessionsTimos()
		{
		}

		/// ///////////////////////////////////////////////////
		/// Le data du result doit être passé à la fonction GetNewSessionSurServeur
        public const string c_dateLimte = "SYSTEM";
		protected override CResultAErreur CanOpenSession ( CSessionClient sessionSurClient )
		{
            
            if ( m_session == null )
			{
				m_session = CSessionClient.CreateInstance();
				m_session.OpenSession ( new CAuthentificationSessionServer(), "Seesion manager", ETypeApplicationCliente.Service );
			}
			CResultAErreur result = CResultAErreur.False;
			System.Console.WriteLine(I.T("Waiting for openSession availiability|30001"));
			System.Console.WriteLine(I.T("Beginning Seesion opening|30002"));

            try
            {
                if (sessionSurClient.Authentification is CAuthentificationSessionTimosSupportAmovible)
                    result = CanOpenSessionSupportAmovible(sessionSurClient);
                if (sessionSurClient.Authentification is CAuthentificationSessionTimosAD)
                    result = CanOpenSessionAD(sessionSurClient);
                if (sessionSurClient.Authentification is CAuthentificationSessionTimosLoginPwd)
                    result = CanOpenSessionLogin(sessionSurClient);

                if (sessionSurClient.Authentification is CAuthentificationSessionServer)
                    result = CanOpenSessionServeur(sessionSurClient);
                if (sessionSurClient.Authentification is CAuthentificationSessionSousSession)
                    result = CanOpenSessionSousSession(sessionSurClient);
                if (sessionSurClient.Authentification is sc2i.process.CAuthentificationSessionProcess)
                    result = CanOpenSessionProcess(sessionSurClient);
                if (sessionSurClient.Authentification is CAuthentificationSessionServiceClient)
                    result = CanOpenSessionServiceClient(sessionSurClient);

                #region Old
                if (sessionSurClient.Authentification is CAuthentificationSessionLoginPasswordMAC)
                    result = CanOpenSessionLoginPasswordMAC(sessionSurClient);
                if (sessionSurClient.Authentification is CAuthentificationSessionUserADMAC)
                    result = CanOpenSessionUserADMAC(sessionSurClient);
                #endregion

            }
            catch(Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }

			System.Console.WriteLine("Ending Session opening|30003");
			return result;
		}

		/// ///////////////////////////////////////////////////
		protected override CSessionClientSurServeur GetNewSessionSurServeur ( CSessionClient session, object data )
		{
			return new CSessionClientSurServeurTimos ( session, (CInfoSessionTimos)data );
		}


		/// ///////////////////////////////////////////////////
		#region OLD
		protected CResultAErreur CanOpenSessionLoginPasswordMAC ( CSessionClient session )
		{
    		CResultAErreur result = CResultAErreur.True;
           	try
			{
				CAuthentificationSessionLoginPasswordMAC auth = (CAuthentificationSessionLoginPasswordMAC)session.Authentification;
				if ( auth.Login.Trim() == "" || auth.Password.Trim()=="" )
					result.EmpileErreur(I.T("Invalid user name or password |3"));
				else
				{
					using (CContexteDonnee contexte = new CContexteDonnee(m_session.IdSession, true, false))
					{
						string strPassCrypte = C2iCrypto.Crypte(auth.Password);
						CDonneesActeurUtilisateur donnees = new CDonneesActeurUtilisateur(contexte);
						if(donnees.ReadIfExists(new CFiltreData ( CDonneesActeurUtilisateur.c_champLogin+"=@1 and "+
							CDonneesActeurUtilisateur.c_champPassword+"=@2",
							auth.Login, strPassCrypte)) && donnees.VerifiePassword(auth.Password))
							return InitialiserSessionCliente(session, donnees);
                        else
                            result.EmpileErreur(I.T("Invalid user name or password |3"));
					}
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur(I.T("Login error |4"));
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}
		protected CResultAErreur CanOpenSessionUserADMAC ( CSessionClient session )
		{
			
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAuthentificationSessionUserADMAC auth = (CAuthentificationSessionUserADMAC)session.Authentification;
				string[]    strNoms = auth.UserId.Split('/');
                string      strNom;

                if (strNoms.Length < 1)
                    result.EmpileErreur(I.T("Unauthorised Windows user name|5"));
                else
                {
                    strNom = strNoms[strNoms.Length - 1];
                    using (CContexteDonnee contexte = new CContexteDonnee(m_session.IdSession, true, false))
                    {
						CDonneesActeurUtilisateur donnees = new CDonneesActeurUtilisateur(contexte);
						if(donnees.ReadIfExists(new CFiltreData ( CDonneesActeurUtilisateur.c_champNomWindows + "=@1", strNom)))
							return InitialiserSessionCliente(session, donnees);
                        else
                            result.EmpileErreur(I.T("Invalid user name|6"));
                    }
                }
			}
			catch ( Exception e )
			{
				result.EmpileErreur(I.T("Login error |4"));
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}
		#endregion
		protected CResultAErreur CanOpenSessionServeur ( CSessionClient session )
		{
			return CResultAErreur.True;
		}
		protected CResultAErreur CanOpenSessionServiceClient(CSessionClient session)
		{
			return CResultAErreur.True;
		}
		
		protected CResultAErreur CanOpenSessionProcess ( CSessionClient session )
		{
			CResultAErreur result = CResultAErreur.True;
			return result;
		}
		protected CResultAErreur CanOpenSessionSousSession ( CSessionClient session )
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				CAuthentificationSessionSousSession auth = (CAuthentificationSessionSousSession)session.Authentification;
				CSessionClient sessionMain = GetSessionClient(auth.IdSessionPrincipale);
				if ( sessionMain == null )
				{
					result.EmpileErreur(I.T("The master session doesn't exist|16"));
					return result;
				}
				//Effectue un appel pour provoquer une exception en cas d'erreursessionMain.IdSession;
				int nDummy = sessionMain.IdSession;
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
                result.EmpileErreur(I.T("Error while accessing the master session|17"));
			}
			return result;
		}

		protected CResultAErreur CanOpenSessionAD(CSessionClient session)
		{
			CResultAErreur result = CResultAErreur.True;
			if (session.Authentification is CAuthentificationSessionTimosAD)
			{
				CAuthentificationSessionTimosAD auth = (CAuthentificationSessionTimosAD)session.Authentification;
				result = IsUserAdValide(auth.UserId);
				if (result)
					return InitialiserSessionCliente(session, (CDonneesActeurUtilisateur)result.Data);
			}
			else
				result.EmpileErreur(I.T("Authentification type error|30004"));
			return result;
		}
		protected CResultAErreur CanOpenSessionLogin(CSessionClient session)
		{
			CResultAErreur result = CResultAErreur.True;
			if (session.Authentification is CAuthentificationSessionTimosLoginPwd)
			{
				CAuthentificationSessionTimosLoginPwd auth = (CAuthentificationSessionTimosLoginPwd)session.Authentification;
				result = IsUserValide(auth.Login, auth.MotDePasse);
				if (result)
					return InitialiserSessionCliente(session, (CDonneesActeurUtilisateur)result.Data);
			}
			else
                result.EmpileErreur(I.T("Authentification type error|30004"));
			return result;
		}
		protected CResultAErreur CanOpenSessionSupportAmovible(CSessionClient session)
		{
			CResultAErreur result = CResultAErreur.True;
			if (session.Authentification is CAuthentificationSessionTimosSupportAmovible)
			{
				CAuthentificationSessionTimosSupportAmovible auth = (CAuthentificationSessionTimosSupportAmovible)session.Authentification;
				result = IsUserValide(auth.IdSupport);
				if (result)
					return InitialiserSessionCliente(session, (CDonneesActeurUtilisateur)result.Data);
			}
			else
                result.EmpileErreur(I.T("Authentification type error|30004"));
			return result;
		}
				
		/// ///////////////////////////////////////////////////
		public override string GetNomUtilisateurFromKeyUtilisateur(CDbKey keyUtilisateur)
		{
            //TESTDBKEYOK
			using ( CContexteDonnee contexte = new CContexteDonnee ( m_session.IdSession, true, false ) )
			{
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( contexte );
				if ( user.ReadIfExists ( keyUtilisateur ) )
					return user.Acteur.Nom;
			}
			return I.T("Unknown|18");
		}

        //-------------------------------------------------------------------
        public CLicenceLogicielPrtct GetLicenceServeur()
        {
            try
            {
                return TimosServeur.LicenceLogiciel;
            }
            catch { }
            return null;
        }

        //-------------------------------------------------------------------
        public void RefreshNombreUtiliseParTypes()
        {
            try
            {
                CLicenceCheckElementNb.GetInstance().RefreshNombreUtilises();
            }
            catch { }
        }

        //-------------------------------------------------------------------
        public IEnumerable<CNombreUtilisePourTypeLicence> GetNombreRestantParType()
        {
            try
            {
                return CLicenceCheckElementNb.GetInstance().GetNombreRestantParType();
            }
            catch { }
            return new List<CNombreUtilisePourTypeLicence>();
        }

        //-------------------------------------------------------------------
        public IList<CAlerteLicence> GetAlertesLicences()
        {
            List<CAlerteLicence> lst = new List<CAlerteLicence>();
            lst.AddRange(TimosServeur.LicenceLogiciel.GetAlertes());
            lst.AddRange(CLicenceCheckElementNb.GetInstance().GetAlertes());

            lst.Sort(delegate(CAlerteLicence a1, CAlerteLicence a2)
                {
                    if (a2 == null || a1 == null)
                        return 0;
                    return (int)a2.Gravite.CompareTo(a1.Gravite);
                }
            );

            return lst.AsReadOnly();
        }

        //-------------------------------------------------------------------
		private CResultAErreur InitialiserSessionCliente(CSessionClient session, CDonneesActeurUtilisateur donneesUser)
		{
			CResultAErreur result = VerifInitialisationsTimosServeur();
			if (!result)
				return result;

			//Recupération de la licence
			result = GetUserLicence(session, donneesUser);
			if(!result)
				return result;
			CUserLicencePrtct licence = (CUserLicencePrtct)result.Data;

			//Recuperation d'un profil
			result = GetUserProfil(donneesUser);
			if (!result)
				return result;
			CUserProfilPrtct profil = (CUserProfilPrtct)result.Data;

			//Enregistrement des infos de session
			CInfoSessionTimos info = new CInfoSessionTimos(donneesUser, licence, profil);
			result.Data = info;

			return result;
		}

		private CTimosServeur m_timosServeur;
        //-------------------------------------------------------------------------------------------------
        private CTimosServeur TimosServeur
		{
			get
			{
				if (m_timosServeur == null)
				{
					m_timosServeur = CTimosServeur.GetInstance();
				}
				return m_timosServeur;
			}
		}


        //-------------------------------------------------------------------------------------------------
        public CResultAErreur VerifInitialisationsTimosServeur()
		{
			CResultAErreur result = CResultAErreur.True;
			if (TimosServeur == null)
				result.EmpileErreur(I.T("Error while licence recovery : cannot find the server|10"));
			else if (TimosServeur.LicenceLogiciel == null)
				result.EmpileErreur(I.T("Error while licence recovery : cannot find the licence file|11"));
			return result;
		}

        //-------------------------------------------------------------------------------------------------
        public CResultAErreur GetUserLicence(CSessionClient session, CDonneesActeurUtilisateur donnees)
		{
			CResultAErreur result = CResultAErreur.True;
			if (session != null && session.Authentification is CAuthentificationSessionTimos)
			{
				CParametresLicence param = ((CAuthentificationSessionTimos)session.Authentification).ParametresIdentificationLicence;
				param.UserID = donnees.Id.ToString();
				param.GroupeID = donnees.Acteur.TousLesIdsDeGroupes;
				
				return GetUserLicence(param);
			}
			
			result.EmpileErreur(I.T("Error while licence recovery : the user session cannot be identified|13"));
			return result;
		}

        //-------------------------------------------------------------------------------------------------
        public CResultAErreur GetUserLicence(CParametresLicence parametre)
        {
			CResultAErreur result = CResultAErreur.True;
			if (TimosServeur.LicenceLogiciel.UserLicences.Count == 0)
			{
				result.EmpileErreur(I.T("No license for user|2"));
				return result;
			}

            int i = 0;
			string[] gr = new string[parametre.GroupeID.Length];
            foreach (int id in parametre.GroupeID)
            {
                gr.SetValue(id.ToString(), i);
                i++;
            }
			CUserLicencePrtct licence = TimosServeur.LicenceLogiciel.GetLicence(parametre.MACs.ToArray(), parametre.UserID, gr, parametre.IDsSupports.ToArray());
            if (licence == null)
            {
                //Tente de récuperer des licences perdues
                RecalculeAffectationLicencesEtProfils();
                licence = TimosServeur.LicenceLogiciel.GetLicence(parametre.MACs.ToArray(), parametre.UserID, gr, parametre.IDsSupports.ToArray());
            }
            if ( licence == null )
                result.EmpileErreur(I.T("No license for user|2"));
            else
                result.Data = licence;

			return result;
        }

        //-------------------------------------------------------------------------------------------------
        public CResultAErreur GetUserProfil(CDonneesActeurUtilisateur donnees)
		{
			CResultAErreur result = CResultAErreur.True;
			if (TimosServeur.LicenceLogiciel.ProfilsUtilisateurs.Count == 0)
			{
				result.EmpileErreur(I.T("Error : there is no profile in the license|14"));
				return result;
			}

			CUserProfilPrtct prof = TimosServeur.LicenceLogiciel.GetProfil(donnees.IdProfilLicence);
            if (prof == null)
            {
                //Tente de récuperer des licences perdues
                RecalculeAffectationLicencesEtProfils();
                prof = TimosServeur.LicenceLogiciel.GetProfil(donnees.IdProfilLicence);
            }
            if ( prof == null )
                result.EmpileErreur(I.T("Error : no more free profile for the license|15"));
			result.Data = prof;
			
			return result;
		}


		#region IGestionnaireSessionsTimos Membres

		public CResultAErreur IsUserAdValide(string strIdAd)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				string strNom;

				if (strIdAd.Length > 0)
				{
					strNom = strIdAd;
					//Supprime le domaine
					int nPos = strNom.LastIndexOf('\\');
					if (nPos > 0)
						strNom = strNom.Substring(nPos + 1);
				}
				else
				{
					result.EmpileErreur(I.T("Invalid user name|6"));
					return result;
				}

				string[] strNoms = strNom.Split('/');

				if (strNoms.Length < 1)
					result.EmpileErreur(I.T("Unauthorized Windows user name|5"));
				else
				{
					strNom = strNoms[strNoms.Length - 1];
					using (CContexteDonnee contexte = new CContexteDonnee(m_session.IdSession, true, false))
					{
						CDonneesActeurUtilisateur donnees = new CDonneesActeurUtilisateur(contexte);
						if (donnees.ReadIfExists(new CFiltreData(CDonneesActeurUtilisateur.c_champNomWindows + "=@1", strNom)))
						{
							result.Data = donnees;
							return result;
						}
						else
							result.EmpileErreur(I.T("Invalid user name|6"));
					}
				}
			}
			catch (Exception e)
			{
				result.EmpileErreur(I.T("Login error |4"));
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}

		public CResultAErreur IsUserValide(string strLogin, string strMdp)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				if (strLogin.Trim() == "" || strMdp.Trim() == "")
					result.EmpileErreur(I.T("Invalid user name or password |3"));
				else
				{
					using (CContexteDonnee contexte = new CContexteDonnee(m_session.IdSession, true, false))
					{
						string strPassCrypte = C2iCrypto.Crypte(strMdp);
						CDonneesActeurUtilisateur donnees = new CDonneesActeurUtilisateur(contexte);
						if (donnees.ReadIfExists(new CFiltreData(CDonneesActeurUtilisateur.c_champLogin + "=@1 and " +
							CDonneesActeurUtilisateur.c_champPassword + "=@2",
							strLogin, strPassCrypte)) && donnees.VerifiePassword(strMdp))
						{
							result.Data = donnees;
							return result;
						}
						else
							result.EmpileErreur(I.T("Login error |4"));
					}
				}
			}
			catch (Exception e)
			{
				result.EmpileErreur(I.T("Login error |4"));
				result.EmpileErreur(new CErreurException(e));
			}
			return result;

		}

		public CResultAErreur IsUserValide(string strIdSupport)
		{
			CResultAErreur result = CResultAErreur.True;

			try
			{
				if (strIdSupport.Trim() != "")
				{
					using (CContexteDonnee contexte = new CContexteDonnee(m_session.IdSession, true, false))
					{
						CDonneesActeurUtilisateur donnees = new CDonneesActeurUtilisateur(contexte);
						if (donnees.ReadIfExists(new CFiltreData(CDonneesActeurUtilisateur.c_champIdSupportAmovible + "=@1",
							strIdSupport)))
						{
							result.Data = donnees;
							return result;
						}
						else
							result.EmpileErreur(I.T("Impossible to identify the storage device|30027"));
					}
				}
				else
					result.EmpileErreur("Invalid removable storage device|30028");
			}
			catch (Exception e)
			{
				result.EmpileErreur(I.T("Removable storage device identification error|30029"));
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}

		#endregion


        //-------------------------------------------------------------------------------------------------
        public void RecalculeAffectationLicencesEtProfils()
        {
            //Identifie les sessions déconnectées
            foreach ( int nId in GetListeIdSessionsConnectees() )
            {
                CSessionClientSurServeurTimos sessionSurServeur = GetSessionClientSurServeur ( nId ) as CSessionClientSurServeurTimos;
                if ( sessionSurServeur != null && sessionSurServeur.UserLicence != null)
                {
                    try
                    {
                        bool bConnected = sessionSurServeur.SessionClient.IsConnected;
                    }
                    catch{
                        try{
                            sessionSurServeur.CloseSession();
                        }
                        catch{
                        }
                    }
                }
            }
            //Remet les compteurs à 0
            foreach ( CUserLicencePrtct licence in TimosServeur.LicenceLogiciel.UserLicences )
            {
                while ( licence.GetNbUsed() > 0 )
                    licence.FreeLicence();
            }
            foreach ( CUserProfilPrtct profil in TimosServeur.LicenceLogiciel.ProfilsUtilisateurs )
            {
                while (profil.GetNbUsed()> 0 )
                    profil.FreeProfil();
            }

            //Réaffecte les licences utilisées
            foreach ( int nId in GetListeIdSessionsConnectees() )
            {
                CSessionClientSurServeurTimos sessionSurServeur = GetSessionClientSurServeur ( nId ) as CSessionClientSurServeurTimos;
                if ( sessionSurServeur != null )
                {
                    try
                    {
                        if ( sessionSurServeur.SessionClient.IsConnected )
                        {
                            if ( sessionSurServeur.UserLicence != null )
                                sessionSurServeur.UserLicence.GetLicence();
                            if ( sessionSurServeur.UserProfil != null )
                                sessionSurServeur.UserProfil.GetProfil();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
            
	}
}
