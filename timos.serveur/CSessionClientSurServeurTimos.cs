using System;
using System.Reflection;
using System.Collections.Generic;

using sc2i.multitiers.client;
using sc2i.multitiers.server;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.data;
using timos.client;
using timos.acteurs;
using timos.securite;


using System.Collections.ObjectModel;

namespace timos.serveur
{
    public class CSessionClientSurServeurTimos : CSessionClientSurServeur, IInfoUtilisateur
    {
		///////////////////////////////////////////////////////
		public CSessionClientSurServeurTimos(
            CSessionClient sessionSurClient, 
            CInfoSessionTimos info)
			: base(sessionSurClient)
		{
            //TESTDBKEYOK
			//CDonneesActeurUtilisateur part = info.ActeurUtilisateur;
			m_keyUtilisateur = info == null ? null : info.DonneesUtilisateur.DbKey;
			m_userLicence = info == null ? null : info.UserLicence;
			UserProfil = info == null ? null : info.UserProfil;
			ConfigModules = info == null ? null : CConfigModulesTimos.GetNewConfig(
				CTimosServeur.GetInstance().LicenceLogiciel.ModulesApp,
				info.UserProfil.ModulesClient);

		}

		/// ////////////////////////////////////////////////////
		~CSessionClientSurServeurTimos()
		{
			/*if ( m_contexteDonnees != null )
			{
				m_contexteDonnees.Dispose();
				m_contexteDonnees = null;
			}*/
		}


        private static CContexteDonnee m_contexteDonnees = null;
        private CDbKey m_keyUtilisateur = null;
		private CUserProfilPrtct m_userProfil;
        private CUserLicencePrtct m_userLicence;
		private CConfigModulesTimos m_configModules;


#if DEBUG
		public void SetNewConfigModules(CConfigModulesTimos conf)
		{
			m_listeRestricitionsFromProfil = null;
			ConfigModules = conf;
		}
#endif

		public override string GetVersionServeur()
		{
			return Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

        /// ///////////////////////////////////////////////////
        public override IInfoUtilisateur GetInfoUtilisateur()
        {
            return this;
        }

		/// ////////////////////////////////////////////////////
		public override void ChangeUtilisateur(CDbKey keyUtilisateur)
		{
            //TESTDBKEYOK
			m_keyUtilisateur = keyUtilisateur;
		}

        /// ///////////////////////////////////////////////////
        public override void MyCloseSession()
        {
            //Détruit le contexte de données
            /*if ( m_contexteDonnees != null )
            {
                m_contexteDonnees.Dispose();
                m_contexteDonnees = null;
            }*/
            CTimosServeur timosServeur = CTimosServeur.GetInstance();
			if (timosServeur.LicenceLogiciel != null)
			{
				if ( UserProfil != null )
					timosServeur.LicenceLogiciel.FreeProfil(UserProfil);
				UserProfil = null;
				if ( UserLicence != null )
					timosServeur.LicenceLogiciel.FreeLicence(UserLicence);
				m_userLicence = null;
			}
        }

		/// ///////////////////////////////////////////////////
		public CDbKey KeyUtilisateur
		{
			get
			{
                //TESTDBKEYOK
				return m_keyUtilisateur;
			}
		}

		/// ///////////////////////////////////////////////////
		public CUserLicencePrtct UserLicence
		{
			get
			{
				return m_userLicence;
			}
		}

		/// ///////////////////////////////////////////////////
		public CUserProfilPrtct UserProfil
		{
			get
			{
				return m_userProfil;
			}
			set
			{
				m_userProfil = value;
				if (SessionClient != null && m_userProfil != null)
				{
					SessionClient.SetPropriete(CInfoLicenceUserProfil.c_nomIdentification, 
						m_userProfil == null ? null : new CInfoLicenceUserProfil(UserProfil));
				}
			}
		}

		/// ///////////////////////////////////////////////////
		public CConfigModulesTimos ConfigModules
		{
			get
			{
				return m_configModules;
			}
			set
			{
				m_configModules = value;
				if ( SessionClient != null )
					SessionClient.SetPropriete(CConfigModulesTimos.c_nomIdentification, m_configModules);
			}
		}
				

        private CDonneesActeurUtilisateur Utilisateur
        {
            get
            {
                try
                {
                    CDonneesActeurUtilisateur donnee = new CDonneesActeurUtilisateur(ContexteDonnee);
                    //TESTDBKEYOK
                    if (!donnee.ReadIfExists(m_keyUtilisateur))
                        donnee = null;
                    return donnee;
                }
                catch { }
                return null;
            }
        }
        //Implémentation de IInfoUtilisateur
        /// ///////////////////////////////////////////////////
        public string NomUtilisateur
        {
            get
            {
                CDonneesActeurUtilisateur user = Utilisateur;
                if (user == null)
                    return "SYSTEME OU INCONNU";
                return (user.Acteur.Prenom + " " + user.Acteur.Nom).Trim();
            }
        }
        public CDbKey[] ListeKeysGroupes
        {
            get
            {
                if (Utilisateur == null)
                    return new CDbKey[0];
                CListeObjetsDonnees liste = Utilisateur.Acteur.TousLesGroupes();
                //TESTDBKEYOK
                List<CDbKey> lstRetour = new List<CDbKey>();
                foreach (CGroupeActeur groupe in liste)
                    lstRetour.Add(groupe.DbKey);
                return lstRetour.ToArray();
            }
        }
		private CContexteDonnee ContexteDonnee
		{
			get
			{
				if (m_contexteDonnees == null)
					m_contexteDonnees = new CContexteDonnee(0, true, true);
				return m_contexteDonnees;
			}
		}




        /// ///////////////////////////////////////////////////
        public CListeRestrictionsUtilisateurSurType GetListeRestrictions( int? nIdVersion )
        {
			CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
			CConfigurationRestrictions.AppliqueRestrictions(CTimosServeur.c_keyRestrictionAllUsers, liste);

			CDonneesActeurUtilisateur user = Utilisateur;
			//C'est pas une session système
			if (user != null)
                liste.Combine(user.GetRestrictions(nIdVersion));

            liste.Combine(GetListeRestrictionsModulesClient());
			CConfigurationRestrictions.AppliqueRestrictions(CTimosServeur.c_keyRestrictionAllUsers, liste);
            if (UserLicence != null && UserLicence.IsReadOnly)
            {
                foreach (Type tp in CContexteDonnee.GetAllTypes()) 
                {
                    CRestrictionUtilisateurSurType rest = liste.GetRestriction(tp);
                    CRestrictionUtilisateurSurType restRO = new CRestrictionUtilisateurSurType(tp);
                    restRO.RestrictionSysteme = ERestriction.ReadOnly;
                    rest.Combine(restRO);
                    liste.AddRestriction(rest);
                }
            }
            return liste;
        }

		/// ///////////////////////////////////////////////////
		CListeRestrictionsUtilisateurSurType m_listeRestricitionsFromProfil = null;
		private CListeRestrictionsUtilisateurSurType GetListeRestrictionsModulesClient()
		{
			if (m_listeRestricitionsFromProfil == null)
			{
				m_listeRestricitionsFromProfil = new CListeRestrictionsUtilisateurSurType();

				if (ConfigModules  != null)
				{
					m_listeRestricitionsFromProfil.Combine(CModuleRestrictionProvider.GetRestrictionsClient(ConfigModules));
				}
			} 
			return m_listeRestricitionsFromProfil;
		}

        public CRestrictionUtilisateurSurType GetRestrictionsSur(Type tp, int? nIdVersion)
        {
            CDonneesActeurUtilisateur user = Utilisateur;
            CRestrictionUtilisateurSurType rest = null;
            if (user == null)//C'est une session système
                rest = new CRestrictionUtilisateurSurType(tp);
            else
                rest = user.GetRestrictionsSurType(tp, nIdVersion);
			CConfigurationRestrictions.AppliqueRestriction(CTimosServeur.c_keyRestrictionAllUsers, rest);
            if (m_userLicence != null && m_userLicence.IsReadOnly)
                rest.RestrictionUtilisateur |= ERestriction.ReadOnly;
            return rest;
        }
        public CRestrictionUtilisateurSurType GetRestrictionsSurObjet(object obj, int? nIdVersion)
        {
            if (obj == null)
                return GetRestrictionsSur(typeof(int), nIdVersion);//Aucune restriction !!
            return GetRestrictionsSur(obj.GetType(), nIdVersion);
        }

		/// ///////////////////////////////////////////////////
		public ReadOnlyCollection<Type> GetTypesARestrictionsSurObjets( int? nIdVersion)
		{
			if (Utilisateur != null)
				return Utilisateur.GetTypesARestrictionsSurObjets( nIdVersion ).AsReadOnly();
			return new ReadOnlyCollection<Type>(new List<Type>());
		}

        /// ///////////////////////////////////////////////////
        public IDonneeDroitUtilisateur GetDonneeDroit(string strCode)
        {
            CDonneesActeurUtilisateur user = Utilisateur;
            if (user == null)//C'est une session système
                return new CDonneeDroitSysteme(strCode);
            return user.GetDonneeDroit(strCode);
        }



    }
}
