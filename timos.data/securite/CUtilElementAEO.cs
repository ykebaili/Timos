using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.data;
using sc2i.multitiers.client;
using timos.securite;
using sc2i.documents;


namespace timos.securite
{
    ////////////////////////////////////////////////////////////////////////////////////////
	[AutoExec("Autoexec")]
	public class CUtilElementAEO
	{
		public const string c_champEO = "OE_TIMOS";

		private class CCacheFiltre
		{
			public readonly DateTime DateCache = DateTime.Now;
			public readonly string Filtre = "";

			public CCacheFiltre(string strFiltre)
			{
				Filtre = strFiltre;
			}

			public bool IsObsolete
			{
				get
				{
					return ((TimeSpan)(DateTime.Now - DateCache)).TotalMinutes >= 2;
				}
			}
		}

		private static Hashtable m_tableIdUserEtTypeToFiltre = new Hashtable();

		private static CRecepteurNotification m_recepteurAjouts = null;
		private static CRecepteurNotification m_recepteurModifs = null;


		/// <summary>
		/// Enregistre la fonction de fourniture de filtre d'affichage
		/// </summary>
		public static void Autoexec()
		{
			CListeObjetsDonnees.RegisterDelegueFiltreAffichage(new GetFiltreAffichageDelegate(GetFiltreAffichage));
		}

		/// <summary>
		/// Retourne le filtre à appliquer aux listes qui sont filtrées pour l'affichage
		/// </summary>
		/// <param name="typeEntites"></param>
		/// <param name="contexte"></param>
		/// <returns></returns>
		public static CFiltreData GetFiltreAffichage(Type typeEntites, CContexteDonnee contexte)
		{
			AssureRecepteursNotifications( contexte.IdSession);
			if (typeof(IElementAEO).IsAssignableFrom ( typeEntites ))
			{
                //TESTDBKEYOK
				//Récupère l'id d'utilisateur lié au contexte
				CSessionClient session = CSessionClient.GetSessionForIdSession(contexte.IdSession);
				try
				{
					CDbKey keyUser = session.GetInfoUtilisateur().KeyUtilisateur;
                    string strFiltre = GetStringFiltreEOForUser(keyUser, contexte, typeEntites);
					if (strFiltre != "")
						return new CFiltreData(strFiltre);
					return new CFiltreData(strFiltre);


				}
				catch (Exception e)
				{
					System.Console.WriteLine(e.ToString());
				}
			}
			return null;
		}

		/// <summary>
		/// S'assure que les récepteurs de notification sont créés
		/// </summary>
		private static void AssureRecepteursNotifications(int nIdSession)
		{
			if (m_recepteurAjouts == null)
			{
				m_recepteurAjouts = new CRecepteurNotification(nIdSession, typeof(sc2i.data.CDonneeNotificationAjoutEnregistrement));
				m_recepteurAjouts.OnReceiveNotification += new NotificationEventHandler(m_recepteurAjouts_OnReceiveNotification);
			}
			if (m_recepteurModifs == null)
			{
				m_recepteurModifs = new CRecepteurNotification(nIdSession, typeof(sc2i.data.CDonneeNotificationModificationContexteDonnee));
				m_recepteurModifs.OnReceiveNotification += new NotificationEventHandler(m_recepteurModifs_OnReceiveNotification);

			}
		}

		
		//-----------------------------------------------------------------------------------
		static void  m_recepteurModifs_OnReceiveNotification(IDonneeNotification donnee)
		{
			if ( m_tableIdUserEtTypeToFiltre.Count > 0 )
			{
				if ( donnee is CDonneeNotificationModificationContexteDonnee )
				{
					CDonneeNotificationModificationContexteDonnee dataModif = (CDonneeNotificationModificationContexteDonnee)donnee;
					foreach ( CDonneeNotificationModificationContexteDonnee.CInfoEnregistrementModifie info in dataModif.ListeModifications )
					{
						if ( info.NomTable == CProfilUtilisateur.c_nomTable ||
							info.NomTable == CProfilUtilisateur_Restriction.c_nomTable ||
							info.NomTable == CRelationUtilisateur_Profil.c_nomTable ||
							info.NomTable == CRelationUtilisateur_Profil_EO.c_nomTable ||
							info.NomTable == CProfilUtilisateur_Inclusion.c_nomTable)
						{
							m_tableIdUserEtTypeToFiltre.Clear();
							break;
						}
					}
				}
			}
		}

		//-----------------------------------------------------------------------------------
		static void m_recepteurAjouts_OnReceiveNotification(IDonneeNotification donnee)
		{
			if (m_tableIdUserEtTypeToFiltre.Count > 0)
			{
				if (donnee is CDonneeNotificationAjoutEnregistrement)
				{
					CDonneeNotificationAjoutEnregistrement dataAjout = (CDonneeNotificationAjoutEnregistrement)donnee;
					if (dataAjout.NomTable == CProfilUtilisateur.c_nomTable ||
							dataAjout.NomTable == CProfilUtilisateur_Restriction.c_nomTable ||
							dataAjout.NomTable == CRelationUtilisateur_Profil.c_nomTable ||
							dataAjout.NomTable == CRelationUtilisateur_Profil_EO.c_nomTable ||
							dataAjout.NomTable == CProfilUtilisateur_Inclusion.c_nomTable)
					{
						m_tableIdUserEtTypeToFiltre.Clear();
					}
				}
			}
		}

		public static CResultAErreur UpdateEOs(IElementAEO elt)
		{
			IUtilElementAEOServeur util = (IUtilElementAEOServeur)C2iFactory.GetNewObjetForSession("CUtilElementAEOServeur", typeof(IUtilElementAEOServeur), elt.ContexteDonnee.IdSession);
			return util.UpdateEOs(new CReferenceObjetDonnee((CObjetDonnee)elt));
		}


		//----------------------------------------------------------------
		public static CResultAErreur UpdateEOSInCurrentContext(IElementAEO element)
		{
			CResultAErreur result = CResultAErreur.True;
			if (element == null)
				return result;
			string strLastEOS = element.CodesEntitesOrganisationnelles;
			StringBuilder bl = new StringBuilder();
			foreach (string strCode in GetEOS(element))
				bl.Append("~" + strCode);
			bl.Append("~");
			((CObjetDonneeAIdNumerique)element).Row[CUtilElementAEO.c_champEO] = bl.ToString();

			if (element.CodesEntitesOrganisationnelles != strLastEOS)
			{
				//Update les eos de tous les fils
				IElementAEO[] heritiers = element.HeritiersEO;
				if (heritiers != null)
				{
					foreach (IElementAEO elt in heritiers)
					{
						if (elt != null)
							result = UpdateEOSInCurrentContext(elt);
						if (!result)
							return result;
					}
				}
			}
			return result;
		}

		//----------------------------------------------------------------
		/// <summary>
		/// Ajoute à la liste les eos de l'élement et de ses donnateurs
		/// </summary>
		/// <param name="elt"></param>
		/// <param name="liste"></param>
		private static void AddEOS(IElementAEO elt, List<string> liste, bool bSansRequete)
		{
			if (elt == null)
				return;
			if (bSansRequete)
			{
				string[] strCodes = elt.CodesEntitesOrganisationnelles.Split('~');
				foreach (string strCode in strCodes)
				{
					if (strCode.Length > 0)
						liste.Add(strCode);
				}
				return;
			}
			CListeObjetsDonnees listeEOS = elt.EntiteOrganisationnellesDirectementLiees;
			foreach (CEntiteOrganisationnelle eo in listeEOS)
				liste.Add(eo.CodeSystemeComplet);

			IElementAEO[] donnateurs = elt.DonnateursEO;
			if (donnateurs != null)
				foreach (IElementAEO donnateur in donnateurs)
					AddEOS(donnateur, liste, true);
		}

        //----------------------------------------------------------------
        public static void CopyAndReplaceEOS(IElementAEO eltAModifier, IElementAEO eltSource, string strCodeRacine)
        {
            string[] strCodesAModifier = eltAModifier.CodesEntitesOrganisationnelles.Split('~');
            string[] strCodesAAffecter = eltSource.CodesEntitesOrganisationnelles.Split('~');
            HashSet<string> setCodesAModifier = new HashSet<string>();
            HashSet<string> setcodesAAffecter = new HashSet<string>();

            foreach (string strCode in strCodesAAffecter)
                if (strCode.StartsWith(strCodeRacine))
                    setcodesAAffecter.Add(strCode);

            foreach (string strCode in strCodesAModifier)
            {
                if (strCode.StartsWith(strCodeRacine)&& strCode.Length > 0)
                {
                    if (!setcodesAAffecter.Contains(strCodeRacine))
                    {
                        CEntiteOrganisationnelle ett = new CEntiteOrganisationnelle(eltAModifier.ContexteDonnee);
                        if (ett.ReadIfExists(new CFiltreData(CEntiteOrganisationnelle.c_champCodeSystemeComplet + "=@1",
                            strCode)))
                            eltAModifier.SupprimerEO(ett.Id);
                    }
                    else
                        setCodesAModifier.Add(strCode);
                }
            }
            foreach (string strCode in strCodesAAffecter)
            {
                if (strCode.StartsWith(strCodeRacine) && !setCodesAModifier.Contains(strCode) && strCode.Length > 0 )
                {
                    CEntiteOrganisationnelle ett = new CEntiteOrganisationnelle(eltAModifier.ContexteDonnee);
                    if (ett.ReadIfExists(new CFiltreData(CEntiteOrganisationnelle.c_champCodeSystemeComplet + "=@1",
                        strCode)))
                        eltAModifier.AjouterEO(ett.Id);
                }
            }
        }
                



		//----------------------------------------------------------------
		/// <summary>
		/// Retourne une liste des EOS de l'élément épurée
		/// SI un élément appartient à 
		/// 01 et à 0102, seul 0102 sera retourné.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		private static List<string> GetEOS(IElementAEO element)
		{
			List<string> lstEos = new List<string>();
			AddEOS(element, lstEos, false);
			lstEos.Sort();
			List<string> lstEpuree = new List<string>();
			for (int nElt = 0; nElt < lstEos.Count - 1; nElt++)
			{
				string strCode = lstEos[nElt];
				string strCodeSup = lstEos[nElt + 1];
				if (strCode.Length <= strCodeSup.Length &&
					strCodeSup.Substring(0, strCode.Length) != strCode ||
					strCodeSup.Length < strCode.Length)
					lstEpuree.Add(strCode);
			}
			if (lstEos.Count > 0)
				lstEpuree.Add(lstEos[lstEos.Count - 1]);

			return lstEpuree;
		}

		/// <summary>
		/// Calcule le filtre pour un utilisateur
		/// </summary>
		/// <param name="nIdUser"></param>
		/// <param name="contexte"></param>
		/// <returns></returns>
		private static string GetStringFiltreEOForUser(CDbKey keyUser, CContexteDonnee contexte, Type typeElements)
		{
            //TESTDBKEYOK
            if (keyUser == null)
                return "";
			string strVersion = contexte.IdVersionDeTravail == null ? "" : contexte.IdVersionDeTravail.ToString();
            string strCleCache = keyUser.StringValue + "_" + strVersion + "_" + typeElements.ToString();
            CCacheFiltre cache = (CCacheFiltre)m_tableIdUserEtTypeToFiltre[strCleCache];
			string strFiltre = "";
			if (cache == null || cache.IsObsolete)
			{
				strFiltre = "";
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(contexte);
				if (user.ReadIfExists(keyUser))
				{
					//Calcule le filtre
					foreach (CRelationUtilisateur_Profil relUser in user.RelationsProfils)
					{
						string strTmp = relUser.GetFiltreEO(contexte.IdVersionDeTravail, typeElements);
						if (strTmp != "")
						{
							strTmp = "(" + strTmp + ")";

							if (strFiltre != "")
								strFiltre += " or ";
							strFiltre += strTmp;
						}
					}
				}
				m_tableIdUserEtTypeToFiltre[strCleCache] = new CCacheFiltre(strFiltre);
			}
			else
			{
				strFiltre = cache.Filtre;
			}
			return strFiltre;
		}

        private class CCacheRestrictions
        {
            private static Hashtable m_tableElementToRestriction = new Hashtable();
            private const int c_nDureeVieSeconde = 4;

            private class CCacheRestriction
            {
                public DateTime DateValeur = DateTime.Now;
                public CRestrictionUtilisateurSurType Restriction;
                public string CodesEO = "";

                public CCacheRestriction(CRestrictionUtilisateurSurType rest, string strCodesEO)
                {
                    DateValeur = DateTime.Now;
                    Restriction = rest;
                    CodesEO = strCodesEO;
                }
            }

            public static CRestrictionUtilisateurSurType GetRestriction(IElementAEO element)
            {
                
                CCacheRestriction cache = m_tableElementToRestriction[element] as CCacheRestriction;
                if (cache != null && ((TimeSpan)(DateTime.Now - cache.DateValeur)).TotalSeconds <= c_nDureeVieSeconde &&
                    cache.CodesEO == element.CodesEntitesOrganisationnelles )
                    return cache.Restriction;
                return null;
            }

            public static void SetRestriction(IElementAEO element, CRestrictionUtilisateurSurType rest)
            {
                if (m_tableElementToRestriction.Count > 100)
                    m_tableElementToRestriction.Clear();
                CCacheRestriction cache = new CCacheRestriction(rest, element.CodesEntitesOrganisationnelles);
                m_tableElementToRestriction[element] = cache;
            }
        }


		//--------------------------------------------------------------------------------
		/// <summary>
		/// Complete les restrictions pour un objet donné
		/// </summary>
		/// <param name="restriction"></param>
		public static void CompleteRestriction(IElementAEO element, CRestrictionUtilisateurSurType restriction)
		{
            CRestrictionUtilisateurSurType restCache = CCacheRestrictions.GetRestriction(element);
            if (restCache != null)
            {
                restriction.Combine(restCache);
                return;
            }
			CContexteDonnee contexte = ((CObjetDonneeAIdNumerique)element).ContexteDonnee;
			CSessionClient session = CSessionClient.GetSessionForIdSession(contexte.IdSession);
			if (session != null)
			{
                //TESTDBKEYOK
				CDbKey keyUtilisateur = session.GetInfoUtilisateur().KeyUtilisateur;
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(contexte);
				if (user.ReadIfExists(keyUtilisateur))
				{
					foreach (CRelationUtilisateur_Profil rel in user.RelationsProfils)
					{
						rel.CompleteRestriction(element, restriction);
					}
				}
			}
            //Vérifie qu'on a le droit de voir l'élément
            try
            {
                if (!(element is CObjetDonneeAIdNumerique) ||
                    !((CObjetDonneeAIdNumerique)element).IsDeleted)
                {
                    if (!((CObjetDonnee)element).IsNew())//On ne peut pas appliquer la restriction sur un élément nouveau !
                    {
                        CListeObjetsDonnees lst = new CListeObjetsDonnees(element.ContexteDonnee, element.GetType());
                        lst.Filtre = new CFiltreData(element.GetChampId() + "=@1", element.Id);
                        lst.AppliquerFiltreAffichage = true;
                        lst.PreserveChanges = true;
                        if (lst.Count == 0)
                            restriction.RestrictionUtilisateur = ERestriction.Hide;
                    }
                }
            }
            catch { }
            CCacheRestrictions.SetRestriction(element, restriction);
		}

		//--------------------------------------------------------------------------------
		public static List<CEntiteOrganisationnelle> GetToutesEOs(IElementAEO elt)
		{

			Hashtable tbl = new Hashtable();
			FillTableEos(elt, tbl);
			List<CEntiteOrganisationnelle> lst = new List<CEntiteOrganisationnelle>();
			foreach (CEntiteOrganisationnelle entite in tbl.Keys)
				lst.Add(entite);
			return lst;

		}

		//--------------------------------------------------------------------------------
		private static void FillTableEos(IElementAEO elt, Hashtable tbl)
		{
			if (elt == null)
				return;
			foreach (CEntiteOrganisationnelle eo in elt.EntiteOrganisationnellesDirectementLiees)
				tbl[eo] = true;
			IElementAEO[] donnateurs = elt.DonnateursEO;
			if ( donnateurs != null )
				foreach (IElementAEO donnateur in donnateurs)
					FillTableEos(donnateur, tbl);
		}



		//---------------------------------------------
		/// <summary>
		/// Retourne le filtre à appliquer à un élément pour obtenir tous les éléments
		/// ayant en commun les types d'EO demandés
		/// </summary>
		/// <param name="element"></param>
		/// <param name="typesCommuns"></param>
		/// <param name="bFillesSeulement">Indique que seules le EOS = ou filles sont prises en compte (true),
		/// ou seules les EOs parentes (false)</param>
		/// <returns></returns>
		public static CFiltreData GetFiltrePourTypeEosCommuns(IElementAEO element, List<COptionCorrespondanceEO>typesCommuns)
		{
			CFiltreData filtre = null;
			
			Dictionary<COptionCorrespondanceEO, Dictionary<string, EModeComparaisonEO>> tableEOS = new Dictionary<COptionCorrespondanceEO,Dictionary<string,EModeComparaisonEO>>();
			foreach (CEntiteOrganisationnelle eo in CUtilElementAEO.GetToutesEOs(element))
			{
				foreach (COptionCorrespondanceEO option in typesCommuns)
				{
					Dictionary<string, EModeComparaisonEO> dicoOption = null;
					if (tableEOS.ContainsKey(option))
						dicoOption = tableEOS[option];
					else
					{
						dicoOption = new Dictionary<string, EModeComparaisonEO>();
						tableEOS[option] = dicoOption;
					}

					switch ( option.ModeComparaison )
					{
						case EModeComparaisonEO.FillesUniquement :
							if (eo.TypeEntite == option.TypeEO)
								dicoOption[eo.CodeSystemeComplet] = option.ModeComparaison;
							else if (eo.TypeEntite.IsChildOf(option.TypeEO))
								dicoOption[eo.GetParent(option.TypeEO).CodeSystemeComplet] = option.ModeComparaison;
							else if (option.TypeEO.IsChildOf(eo.TypeEntite))
								foreach (CEntiteOrganisationnelle eoFille in eo.GetChilds(option.TypeEO))
									dicoOption[eoFille.CodeSystemeComplet] = option.ModeComparaison;
								break;
						case EModeComparaisonEO.ParentsUniquement :
						case EModeComparaisonEO.BrancheComplete :
							CEntiteOrganisationnelle eoTmp = eo;
							string strLib = option.TypeEO.Libelle;
							while (eoTmp.TypeEntite.IsChildOf(option.TypeEO) && !eoTmp.TypeEntite.Equals ( option.TypeEO ))
								eoTmp = eoTmp.EntiteParente;
							strLib = eoTmp.Libelle;
							if ( eoTmp != null && eoTmp.TypeEntite.Equals ( option.TypeEO ) )
								while (eoTmp != null)
								{
									dicoOption[eoTmp.CodeSystemeComplet] = option.ModeComparaison;
									eoTmp = eoTmp.EntiteParente;
								}
							break;
						case EModeComparaisonEO.Egalite :
							if (eo.TypeEntite == option.TypeEO)
								dicoOption[eo.CodeSystemeComplet] = option.ModeComparaison;
							break;
					}
				}
			}
			if (tableEOS.Count > 0)
			{
				string strFiltreEO = "";
				int nIndex = 1;
				filtre = new CFiltreData("");
				foreach (Dictionary<string, EModeComparaisonEO> dico in tableEOS.Values)
				{
					if (dico.Count != 0)
					{
						strFiltreEO += "(";
						foreach (KeyValuePair<string, EModeComparaisonEO> entry in dico)
						{
							string strCodeEO = entry.Key;
							EModeComparaisonEO mode = entry.Value;
							strFiltreEO += CUtilElementAEO.c_champEO + " like @" + (nIndex++) + " or ";
							switch (mode)
							{
								case EModeComparaisonEO.FillesUniquement:
									filtre.Parametres.Add("%~" + strCodeEO + "%");
									break;
								case EModeComparaisonEO.ParentsUniquement:
								case EModeComparaisonEO.Egalite:
									filtre.Parametres.Add("%~" + strCodeEO + "~%");
									break;
								case EModeComparaisonEO.BrancheComplete:
									filtre.Parametres.Add("%~" + strCodeEO + "%");
									break;
							}
						}
						strFiltreEO = strFiltreEO.Substring(0, strFiltreEO.Length - 4) + ") and ";
					}
				}
				if (strFiltreEO.Length > 0)
				{
					strFiltreEO = strFiltreEO.Substring(0, strFiltreEO.Length - 5);
					filtre.Filtre = strFiltreEO;
				}
			}
			return filtre;
		}

        //----------------------------------------------------------------------------
        public static CResultAErreur SetAllOrganizationalEntities(IElementAEO element, int[] nIdsOE)
        {
            CResultAErreur result = CResultAErreur.True;
            List<int> lstNewIds = new List<int>(nIdsOE);
            List<int> lstIdsExistants = new List<int>();
            foreach (CEntiteOrganisationnelle eo in element.EntiteOrganisationnellesDirectementLiees)
                lstIdsExistants.Add(eo.Id);
            HashSet<int> setIdsAAjouter = new HashSet<int>();
            HashSet<int> setIdsASupprimer = new HashSet<int>();

            foreach (int nId in lstIdsExistants)
                if (!lstNewIds.Contains(nId))
                    setIdsASupprimer.Add(nId);
            foreach (int nId in lstNewIds)
                if (!lstIdsExistants.Contains(nId))
                    setIdsAAjouter.Add(nId);

            foreach (int nId in setIdsAAjouter)
                AjouterEO(element, nId);
            foreach (int nId in setIdsASupprimer)
                SupprimerEO(element, nId);

            return result;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nIdEO"></param>
        /// <returns></returns>
        public static CResultAErreur AjouterEO(IElementAEO element, int nIdEO)
        {
            CResultAErreur result = CResultAErreur.True;

            CListeObjetsDonnees listeEOExistantes = CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)element);
            listeEOExistantes.Filtre = 
                new CFiltreData(CEntiteOrganisationnelle.c_champId + " = @1", nIdEO);

            if (listeEOExistantes.Count > 0)
            {
                result.EmpileErreur(I.T("This Organisationnal Entity is already assigned to the element: @1|565", element.DescriptionElement));
                return result;
            }
            // Affecte l'EO à l'élement
            CEntiteOrganisationnelle entite = new CEntiteOrganisationnelle(element.ContexteDonnee);
            if (entite.ReadIfExists(nIdEO))
            {
                CRelationElement_EO relation = new CRelationElement_EO(element.ContexteDonnee);
                relation.CreateNewInCurrentContexte();
                relation.EntiteOrganisationnelle = entite;
                relation.ElementLie = (CObjetDonneeAIdNumerique) element;
            }

            return result;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nIdEO"></param>
        /// <returns></returns>
        public static CResultAErreur SupprimerEO(IElementAEO element, int nIdEO)
        {
            CResultAErreur result = CResultAErreur.True;
            
            CListeObjetsDonnees listeEOExistantes = CRelationElement_EO.GetListeRelationsForElement((CObjetDonneeAIdNumerique)element);
            listeEOExistantes.Filtre =
                new CFiltreData(CEntiteOrganisationnelle.c_champId + " = @1", nIdEO);

            if (listeEOExistantes.Count == 0)
            {
                result.EmpileErreur(I.T("This Organisationnal Entity is not assigned to the element: @1|566", element.DescriptionElement));
                return result;
            }
            // Supprime l'affectation de l'EO à l'élément
            CRelationElement_EO relation = (CRelationElement_EO) listeEOExistantes[0];
            if (relation != null)
            {
                result = relation.Delete(true);
                if (!result)
                    return result;
            }
            
            return result;
        }


	}


    ////////////////////////////////////////////////////////////////////////////////////////
    [AutoExec("Autoexec")]
    public class CProviderRelationsEO : IRelationsEOProvider
    {
        //---------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CDocumentGED.SetRelationsEOProvider(new CProviderRelationsEO());
            CCategorieGED.SetRelationsEOProvider(new CProviderRelationsEO());
        }

        //---------------------------------------------------------------------------------
        public CResultAErreur AjouterEO(IElementAEO elt, int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(elt, nIdEO);
        }

        //---------------------------------------------------------------------------------
        public void CompleteRestriction(IElementAEO elt, CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction ( elt, restriction );
        }

        //---------------------------------------------------------------------------------
        public CListeObjetsDonnees GetEntiteOrganisationnellesDirectementLiees(IElementAEO elt)
        {
            return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(elt);
        }

        //---------------------------------------------------------------------------------
        public CResultAErreur SupprimerEO(IElementAEO elt, int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO ( elt, nIdEO );
        }

        //----------------------------------------------------------------
        public CResultAErreur SetAllOrganizationalEntities(IElementAEO elt, int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(elt, nIdsOE);
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
	public enum EModeComparaisonEO
	{
		FillesUniquement = 0,
		ParentsUniquement,
		Egalite,
		BrancheComplete
	}

    ////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
	public class COptionCorrespondanceEO
	{
		public readonly CTypeEntiteOrganisationnelle TypeEO;
		private EModeComparaisonEO m_modeComparaison;

		//------------------------------------------
		public COptionCorrespondanceEO ( CTypeEntiteOrganisationnelle typeEO, EModeComparaisonEO mode)
		{
			TypeEO = typeEO;
			m_modeComparaison = mode;
		}

		//------------------------------------------
		public EModeComparaisonEO ModeComparaison
		{
			get
			{
				return m_modeComparaison;
			}
			set
			{
				m_modeComparaison = value;
			}
		}

		//------------------------------------------
		public override bool Equals(object obj)
		{
			if (!(obj is COptionCorrespondanceEO) )
				return false;
			COptionCorrespondanceEO opt = (COptionCorrespondanceEO)obj;
			return opt.TypeEO.Equals(TypeEO) && opt.ModeComparaison == ModeComparaison;
		}

		//------------------------------------------
		public override int GetHashCode()
		{
			return TypeEO.GetHashCode() * (int)(Math.Pow(((int)ModeComparaison), 10));
		}

		
	}

	public interface IElementAFiltreEO : IObjetDonneeAIdNumeriqueAuto
	{
		COptionCorrespondanceEO[] OptionsPropres { get;set;}
	}

	public interface IUtilElementAEOServeur
	{
		CResultAErreur UpdateEOs ( CReferenceObjetDonnee referenceObjet);
	}
}
