using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.process;
using sc2i.expression;
using sc2i.multitiers.client;
using System.Text;


namespace timos.data.version
{
    /// <summary>
    /// L'audit de version permet de comparer deux versions de la base de données<br/>
    /// afin de donner la liste des différences entre ces deux versions. L'une des versions<br/>
    /// peut être le référentiel, c'est à dire l'état courant de la base de données.<br/>
    /// Pour pouvoir réaliser un audit, il faut avoir défini au préalable au moins une version.
    /// <br/>
    /// <br/>
    /// Les audits sont des objets typés. Le <see cref="CTypeAuditVersion">type d'audit</see> détermine la nature de l'entité sur laquelle<br/>
    /// porte l'audit et les clés utilisées pour faire la comparaison entre les versions.<br/>
    /// Un audit peut porter sur une ou plusieurs entités.
    /// <br/>
    /// <br/>
    /// L'exécution d'un audit est déclenchée par l'utilisateur depuis l'interface d'édition de l'audit.<br/>
    /// Les résultats de l'audit ne peuvent être visibles qu'après cette exécution. Ces résultats montrent<br/>
    /// le détail des opérations d'ajout, de modification et de suppression effectués, champ par champ,<br/>
    /// sur les entités définies dans le type d'audit.
    /// </summary>
	[DynamicClass("Audit Version")]
	[ObjetServeurURI("CAuditVersionServeur")]
	[Table(CAuditVersion.c_nomTable, CAuditVersion.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeReferentiel_ID)]
    public partial class CAuditVersion : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		#region Déclaration des constantes
		public const string c_nomTable = "AUDITVERSION";
		public const string c_champId = "AUDTV_ID";
		public const string c_champLibelle = "AUDTV_LABEL";
		public const string c_champDescription = "AUDTV_DESC";

		public const string c_champDate = "AUDT_DATE";
		public const string c_champDetaille = "AUDT_DETAILLE";
		public const string c_champShowNullAddingOperation = "AUDT_SHOWNULLADDINGOP";
		public const string c_champShowEachDeleteObjetField = "AUDT_SHOWDELETEDFLDS";

		public const string c_champMappageFormule = "AUDT_FORMULATEMAP";



		public const string c_champVTarget = "AUDT_VTARGET";
		public const string c_champVTargetName = "AUDT_VTARGETNAME";
		
		public const string c_champVSource = "AUDT_VSOURCE";
		public const string c_champVSourceName = "AUDT_VSOURCENAME";

		#endregion

		//-------------------------------------------------------------------
		public CAuditVersion(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CAuditVersion(System.Data.DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}


        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Audit Version @1|552", Libelle); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champId };
        }

        /// <summary>
        /// Libellé de l'audit
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		public string Libelle
		{
			get
			{
				return (string)Row[c_champLibelle];
			}
			set
			{
				Row[c_champLibelle] = value;
			}
		}
		//--------------------------------------------------
        /// <summary>
        /// Description de l'audit
        /// </summary>
		[TableFieldProperty(c_champDescription, 2000)]
		[DynamicField("Audit Description")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des versions concernant l'audit
		/// </summary>
		[RelationFille(typeof(CAuditVersionObjet), "AuditVersion")]
		[DynamicChilds("Object versions", typeof(CAuditVersionObjet))]
		public CListeObjetsDonnees VersionsObjets
		{
			get
			{
				return GetDependancesListe(CAuditVersionObjet.c_nomTable, c_champId);
			}
		}




		//-------------------------------------------------------------------
		/// <summary>
		/// Obtient ou définit le Type d'audit (obligatoire.)
		/// </summary>
		[Relation(
			CTypeAuditVersion.c_nomTable, 
			CTypeAuditVersion.c_champId, 
			CTypeAuditVersion.c_champId, 
			true, 
			true)]
		[DynamicField("Audit type")]
		public CTypeAuditVersion TypeAudit
		{
			get
			{
				return (CTypeAuditVersion)GetParent(CTypeAuditVersion.c_champId, typeof(CTypeAuditVersion));
			}
			set
			{
				SetParent(CTypeAuditVersion.c_champId, value);
			}
		}

        /// <summary>
        /// Date à laquelle l'audit a été réalisé
        /// </summary>
		[TableFieldProperty(c_champDate, NullAutorise=true)]
		[DynamicField("Realisation Date of Audit")]
		public DateTime? DateRealisationAudit
		{
			get
			{
				return (DateTime?)Row[c_champDate, true];
			}
			set
			{
				Row[c_champDate, true] = value;
			}
		}

		#region Versions Attachées
        /// <summary>
        /// Version de référence de l'audit (source).<br/>
        /// Par défaut, il s'agit du référentiel et dans ce cas,<br/>
        /// cette propriété renvoie null
        /// </summary>
		[Relation(
			CVersionDonnees.c_nomTable,
			CVersionDonnees.c_champId,
		    c_champVSource,
			false,
			false,
			false,
			PasserLesFilsANullLorsDeLaSuppression=true)]
		[DynamicField("Source Version")]
		public CVersionDonnees VersionSource
		{
			get
			{
				return (CVersionDonnees)GetParent(c_champVSource, typeof(CVersionDonnees));
			}
			set
			{
				SetParent(c_champVSource, value);
			}
		}

        /// <summary>
        /// Nom de la version source ("Referentiel", si la source est le référentiel)
        /// </summary>
		[DynamicField("Source Version Name")]
		[TableFieldProperty(c_champVSourceName, 255)]
		public string NomVersionSource
		{
			get
			{
				return (string)Row[c_champVSourceName];
			}
			set
			{
				Row[c_champVSourceName] = value;
			}
		}


        /// <summary>
        /// Version cible de l'audit, c'est à dire version comparée à la source.
        /// </summary>
		[Relation(
		   CVersionDonnees.c_nomTable,
		   CVersionDonnees.c_champId,
			c_champVTarget,
			false,
			false,
			false,
			PasserLesFilsANullLorsDeLaSuppression = true)]
		[DynamicField("Target Version")]
		public CVersionDonnees VersionCible
		{
			get
			{
				return (CVersionDonnees)GetParent(c_champVTarget, typeof(CVersionDonnees));
			}
			set
			{
				SetParent(c_champVTarget, value);
			}
		}

        /// <summary>
        /// Nom de la version cible
        /// </summary>
		[DynamicField("Target Version Name")]
		[TableFieldProperty(c_champVTargetName, 255)]
		public string NomVersionCible
		{
			get
			{
				return (string)Row[c_champVTargetName];
			}
			set
			{
				Row[c_champVTargetName] = value;
			}
		}
		#endregion


        /// <summary>
        /// Indicateur booléen d'audit détaillé (VRAI si détaillé)<br/>
        /// Dans le cas d'une version cible dépendant d'une autre version,<br/>
        /// si l'option est cochée, les changements effectués dans les versions<br/>
        /// parentes de la version cible, apparaissent dans l'audit.
        /// </summary>
		[DynamicField("Details")]
		[TableFieldProperty(c_champDetaille)]
		public bool AuditDetaille
		{
			get
			{
				if (MappageParFormule)
					return false;
				return (bool)Row[c_champDetaille];
			}
			set
			{
				Row[c_champDetaille] = value;
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Indicateur booléen de prise en compte des champs personnalisés sans donnée<br/>
        /// (champs des entités ajoutées qui ne contiennent aucune donnée)<br/>
        /// (VRAI si prise en compte)
        /// </summary>
		[DynamicField("Show null add operation")]
		[TableFieldProperty(c_champShowNullAddingOperation)]
		public bool ShowNullAddingOperations
		{
			get
			{
				return (bool)Row[c_champShowNullAddingOperation];
			}
			set
			{
				Row[c_champShowNullAddingOperation] = value;
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Indicateur booléen de prise en compte de chaque champ effacé<br/>
        /// (VRAI si affichage)
        /// </summary>
		[DynamicField("Show each deleted object field")]
		[TableFieldProperty(c_champShowEachDeleteObjetField)]
		public bool ShowEachDeletedObjetFields
		{
			get
			{
				return (bool)Row[c_champShowEachDeleteObjetField];
			}
			set
			{
				Row[c_champShowEachDeleteObjetField] = value;
			}
		}

		//---------------------------------------------
        /// <summary>
        /// Indicateur booléen de mappage par formule<br/>
        /// (VRAI si mappage par formule)
        /// </summary>
		[DynamicField("Formula mapping")]
		[TableFieldProperty(c_champMappageFormule)]
		public bool MappageParFormule
		{
			get
			{
                //if (VersionCible == null)// || VersionCible.TypeVersion.Code == CTypeVersion.TypeVersion.Audit)
                //    return true;
				return (bool)Row[c_champMappageFormule];
			}
			set
			{
				Row[c_champMappageFormule] = value;
			}
		}

		#region PARCOUR DU RESULTAT
		public bool TypesConcernesChanged
		{
			get
			{
				return m_typesConcernes == null || TypeAudit == null || m_nOldIdTypeAudit != TypeAudit.Id;
			}
		}
		//Recupération des types
		private int? m_nOldIdTypeAudit;
		private void CalcTypesConcernes()
		{
			m_typesConcernes = new Dictionary<string, string>();

			if (TypeAudit == null
				|| TypeAudit.ParametrageObject == null
				|| TypeAudit.ParametrageObject.TypesParametres == null
				|| TypeAudit.ParametrageObject.TypesParametres.Count == 0)
			{
				m_nOldIdTypeAudit = null;
				return;
			}
			foreach (CAuditVersionParametrageTypeEntite paramType in TypeAudit.ParametrageObject.TypesParametres)
				m_typesConcernes.Add(paramType.NomType, paramType.NomTypeConvivial);
			m_nOldIdTypeAudit = TypeAudit.Id;
		}
		private Dictionary<string, string> m_typesConcernes;
		public Dictionary<string, string> GetTypesConcernes()
		{
			if(TypesConcernesChanged)
				CalcTypesConcernes();
			return m_typesConcernes;
		}
		//public CFiltreData GetFiltreElementsInVersion(int? nIdVersionSource, int? nIdVersionCible, string strChampIdVersionSource,
		//Récupération des entités
		//si lstType == null tous
		public List<CAuditVersionObjet> GetEntities(int? nIdVersionSource, int? nIdVersionCible, List<string> lstTypesDesires)
		{
			List<CAuditVersionObjet> entities = new List<CAuditVersionObjet>();
			if (DateRealisationAudit == null)
				return entities;

			CListeObjetsDonnees lstCAVOsConcernes = VersionsObjets;
			int n = lstCAVOsConcernes.Count;
			if (n == 0)
				return entities;
			CFiltreData filtreVersions = null;
			
			if (nIdVersionSource.HasValue)
			{
				filtreVersions = new CFiltreData(
				CAuditVersionObjet.c_champIdVDonneeEleSource + " is null OR " +
				 CAuditVersionObjet.c_champIdVDonneeEleSource + " >= @1", nIdVersionSource.Value);
				
			}
			if (nIdVersionCible.HasValue)
			{
				CFiltreData filtreVersionCible = new CFiltreData(
					CAuditVersionObjet.c_champIdVDonneeEleCible + " is null OR " +
					CAuditVersionObjet.c_champIdVDonneeEleCible + " <= @1", nIdVersionCible.Value);
				filtreVersions = filtreVersions == null ? filtreVersionCible :
					CFiltreData.GetAndFiltre(filtreVersions, filtreVersionCible);
			}

			if (lstTypesDesires != null)
				foreach (string strType in lstTypesDesires)
				{
					CFiltreData filtreType = new CFiltreData(CAuditVersionObjet.c_champTypeObj + " = @1", strType);
					CFiltreData filtreTmp = filtreVersions != null ? CFiltreData.GetAndFiltre(filtreVersions, filtreType) : filtreType;
					lstCAVOsConcernes.Filtre = filtreTmp;
					AddEntites(lstCAVOsConcernes, ref entities);
				}
			else
			{
				lstCAVOsConcernes.Filtre = filtreVersions;
				AddEntites(lstCAVOsConcernes, ref entities);
			}
			return entities;
		}

		private void AddEntites(CListeObjetsDonnees cavos, ref List<CAuditVersionObjet> lstEntites)
		{
			foreach (CAuditVersionObjet cavo in cavos)
				lstEntites.Add(cavo);
		}
		#endregion

		public bool IsArchive
		{
			get
			{
				CListeObjetsDonnees cavos = VersionsObjets;
				if (cavos.Count > 0)
				{
					CAuditVersionObjet cavo = (CAuditVersionObjet)cavos[0];
					if (cavo.IdVersionDonneeCible.HasValue)
					{
						CVersionDonnees versionCible = new CVersionDonnees(ContexteDonnee);
						if (!versionCible.ReadIfExists(cavo.IdVersionDonneeCible.Value))
							return true;
					}
					if (cavo.IdVersionDonneeSource.HasValue)
					{
						CVersionDonnees versionSource = new CVersionDonnees(ContexteDonnee);
						if (!versionSource.ReadIfExists(cavo.IdVersionDonneeSource.Value))
							return true;
					}
				}
				return false;
			}
		}

		public int? IdVersionCible
		{
			get
			{
				if (IsArchive)
				{
					CListeObjetsDonnees cavos = VersionsObjets;
					if (cavos.Count > 0)
						return ((CAuditVersionObjet)cavos[0]).IdVersionDonneeCible;
					return null;
				}
				else if (VersionCible == null)
					return null;
				else
					return VersionCible.Id;
			}
		}
		public int? IdVersionSource
		{
			get
			{
				if (IsArchive)
				{
					CListeObjetsDonnees cavos = VersionsObjets;
					if (cavos.Count > 0)
						return ((CAuditVersionObjet)cavos[0]).IdVersionDonneeSource;
					return null;
				}
				else if(VersionSource == null)
					return null;
				else
					return VersionSource.Id;
			}
		}

		#region COMMUN
		/// <summary>
		/// Lance l'audit de version
		/// </summary>
		/// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod("Audit the version")]
		public CResultAErreur Auditer()
		{
			CResultAErreur result = CResultAErreur.True;

			#region ERREURS POSSIBLES
			if (VersionSource == VersionCible)
				result.EmpileErreur(I.T("The target and source version cannot be equals|558"));
			else
			{
				if (VersionSource != null)
					NomVersionSource = VersionSource.Libelle;
				else
					NomVersionSource = I.T("Reference|30007");

				if (VersionCible != null)
					NomVersionCible = VersionCible.Libelle;
				else
					NomVersionCible = I.T("Reference|30007");
			}


			//CVersionDonnees versionPrecedante;
			//CResultAErreur resultLastVersion = GetVersionPrecedante(VersionCible, ref versionPrecedante);
			//while (resultLastVersion.Result && versionPrecedante != VersionSource)
			//{
			//    resultLastVersion = GetVersionPrecedante(VersionCible, ref versionPrecedante);
			//}
			//if (!resultLastVersion)
			//{
			//    result.EmpileErreur("La version cible ne correspond pas à une version fille de la version source");
			//    return result;
			//}

			if (TypeAudit == null)
			{
				result.EmpileErreur(I.T("You must specify the audit type|559"));
				return result;
			}
			CAuditVersionParametrage parametrage = TypeAudit.ParametrageObject;
			if (parametrage == null)
			{
				result.EmpileErreur("");
				return result;
			}
			#endregion


			//A ENLEVER APRES
			CUtilAChampID.Contexte = ContexteDonnee;

			// 2 - SUPPRESSION DES ANCIENNES OPERATIONS
			CListeObjetsDonnees lstCAVO = VersionsObjets;
			lstCAVO.ReadDependances("Datas");
			result = CObjetDonneeAIdNumerique.Delete(lstCAVO);
			if (!result)
			{
				result.EmpileErreur(I.T("Impossible to re-execute audit because one or more elements are attached|560"));
				return result;
			}

			// 3 - RAZ
			DateRealisationAudit = null;
			m_nOrdre = -1;
			m_mappeur = new CMappeurTypeElementCAVO(ContexteDonnee);
			m_mappeurParCle = new CMappeurParCle(this);
			m_cavosToDelete = new List<CAuditVersionObjet>();

			// 4 - AUDIT
			result = Auditer(VersionSource, VersionCible);

			// 5 - MENAGE
			if (result)
			{
				result = ClearCAVOsForDelete();
				//On supprime les CAVOOs qui ont la même valeur Source que Cible
				//CFiltreData filtreCAVOOsASupp = new CFiltreData(
				//    CAuditVersionObjetOperation.c_champValVersionCibleString + " is not null AND "
				//    + CAuditVersionObjetOperation.c_champValVersionSourceString + " = " + CAuditVersionObjetOperation.c_champValVersionCibleString);
				//CListeObjetsDonnees lstCAVOOsASupp = new CListeObjetsDonnees(ContexteDonnee, typeof(CAuditVersionObjetOperation), filtreCAVOOsASupp);
				//lstCAVOOsASupp.InterditLectureInDB = true;
				//result = CObjetDonneeAIdNumeriqueAuto.Delete(lstCAVOOsASupp);
			}

			if (!result)
				return result;

			// 6 - RENUMEROTATION
			CListeObjetsDonnees lstCAVOs = VersionsObjets;
			string strIds = "";
			foreach (CAuditVersionObjet cavo in lstCAVOs)
				strIds += cavo.Id + ",";
			if (strIds != "")
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				CFiltreData filtreCAVOOs = new CFiltreData(CAuditVersionObjet.c_champId + " in(" + strIds + ")");
				CListeObjetsDonnees cavoos = new CListeObjetsDonnees(ContexteDonnee, typeof(CAuditVersionObjetOperation), filtreCAVOOs);
				cavoos.InterditLectureInDB = true;
				cavoos.Tri = CAuditVersionObjetOperation.c_champNumOrdre;
				int nOrdre = 0;
				foreach (CAuditVersionObjetOperation cavoo in cavoos.ToArrayList())
				{
					cavoo.NumeroOrdre = nOrdre;
					nOrdre++;
				}
			}

			DateRealisationAudit = DateTime.Now;
			return result;
		}
		private CResultAErreur Auditer(CVersionDonnees versionSource, CVersionDonnees versionCible)
		{
			CResultAErreur result = CResultAErreur.True;
			CVersionDonnees vSource = versionSource;
			CVersionDonnees vCible = versionCible;

			//1 - RECURCIVITE & IDENTIFICATION VERSIONS TRAVAIL
			if (!MappageParFormule)
			{
				//Vérifie que la version source est bien parente de la version cible
				bool bTrouvee = versionSource == null;
				if (versionSource != null && versionCible != null)
				{
					CVersionDonnees versionParente = versionCible.VersionParente;
					while (versionParente != null)
					{
						if (versionParente.Id == versionSource.Id)
						{
							bTrouvee = true;
							break;
						}
					}
					if (!bTrouvee)
					{
						result.EmpileErreur(I.T("Can not audit two versions if the target version is not derived from source version without using formulas|20006"));
						return result;
					}
				}
				if (versionCible != null && versionCible.VersionParente != versionSource)
					result = Auditer(versionSource, versionCible.VersionParente);
				if (!result)
					return result;
			}
			else
			{
				vSource = versionSource;
			}

			CAuditVersionParametrage parametrage = TypeAudit.ParametrageObject;

			if (MappageParFormule)//Travaille type d'élément par type d'élément pour éviter de surcharger la mémoire
			{
				foreach (CAuditVersionParametrageTypeEntite paramType in parametrage.TypesParametres)
				{
					using (CContexteDonnee ctxSource = new CContexteDonnee(ContexteDonnee.IdSession, true, false))
					{
						if (vSource != null)
						{
							result = ctxSource.SetVersionDeTravail(vSource.Id, false);
							if (!result)
								return result;
						}
						using (CContexteDonnee ctxCible = new CContexteDonnee(ContexteDonnee.IdSession, true, false))
						{
							if (vCible != null)
							{
								result = ctxCible.SetVersionDeTravail(vCible.Id, false);
								if (!result)
									return result;
							}
							result = AuditWithoutCVOO(vSource, vCible, ctxSource, ctxCible, paramType);
							if (!result)
							{
								result.EmpileErreur(I.T("Error while auditing type @1|20005", DynamicClassAttribute.GetNomConvivial(paramType.TypeEntite)));
								return result;
							}
						}
					}
				}
			}
			else //On ne travaille pas par formule
			{
				using (CContexteDonnee ctxSource = new CContexteDonnee(ContexteDonnee.IdSession, true, false))
				{
					if (vSource != null)
					{
						result = ctxSource.SetVersionDeTravail(vSource.Id, false);
						if (!result)
							return result;
					}
					using (CContexteDonnee ctxCible = new CContexteDonnee(ContexteDonnee.IdSession, true, false))
					{
						if (vCible != null)
						{
							result = ctxCible.SetVersionDeTravail(vCible.Id, false);
							if (!result )
								return result;
						}

                        if (vSource == null && vCible != null)
                            result = AuditExpressSourceIsReferentiel(ctxSource, ctxCible, vCible);
                        else
                        {
                            foreach (CAuditVersionParametrageTypeEntite paramType in parametrage.TypesParametres)
                            {
                                result = GetElementsConcernes(vSource, ctxSource, paramType);
                                if (result)
                                    result = GetElementsConcernes(vCible, ctxCible, paramType);
                                if (!result)
                                    return result;
                            }
                            result = AuditWithCVOO(ctxSource, ctxCible, vCible);
                            if (!result)
                                return result;
                        }
					}
				}
			}
			
			return result;
		}

        private CResultAErreur AuditExpressSourceIsReferentiel(CContexteDonnee ctxSource, CContexteDonnee ctxCible, CVersionDonnees vCible)
        {
            CResultAErreur result = CResultAErreur.True;
            List<CVersionDonneesObjet> lstObjetsModifies = new List<CVersionDonneesObjet>();
            CVersionDonnees version = vCible;
            Dictionary<string, List<int>> dicModifsParType = new Dictionary<string, List<int>>();

            while (version != null)
            {
                CListeObjetsDonnees lst = version.VersionObjetsEnLectureNonProgressive;
                lst.ReadDependances("ToutesLesOperations");
                lstObjetsModifies.AddRange(lst.ToArray<CVersionDonneesObjet>());
                lst.Tri = CVersionDonneesObjet.c_champTypeElement;
                List<int> lstVOEnCours = null;
                string strLast = "";
                foreach (CVersionDonneesObjet vo in lst)
                {
                    if (vo.StringTypeElement != strLast)
                    {
                        strLast = vo.StringTypeElement;
                        if (!dicModifsParType.TryGetValue(vo.TypeString, out lstVOEnCours))
                        {
                            lstVOEnCours = new List<int>();
                            dicModifsParType[vo.StringTypeElement] = lstVOEnCours;
                        }
                    }
                    lstVOEnCours.Add(vo.Id);
                }
                version = version.VersionParente;
            }

            Dictionary<Type, List<int>> dicListIds = new Dictionary<Type, List<int>>();
            lstObjetsModifies.Sort((x, y) => x.StringTypeElement.CompareTo(y.StringTypeElement));
            string strLastType = "";
            List<int> lstEnCours = new List<int>();
            foreach (CVersionDonneesObjet vo in lstObjetsModifies)
            {
                if (vo.StringTypeElement != strLastType)
                {
                    lstEnCours = new List<int>();
                    dicListIds[vo.TypeElement] = lstEnCours;
                    strLastType = vo.StringTypeElement;
                }
                lstEnCours.Add(vo.IdElement);
            }

            StringBuilder bl = new StringBuilder();
            CAuditVersionParametrage parametrage = TypeAudit.ParametrageObject;
            //Charge tous les objets concernés dans les deux contexte
            foreach (CAuditVersionParametrageTypeEntite parametre in parametrage.TypesParametres)
            {
                Type tp = parametre.TypeEntite;
                string strChampId = CUtilAChampID.GetChampID(tp);

                List<int> lstIds = null;
                if (dicListIds.TryGetValue(tp, out lstIds))
                {
                    bl = new StringBuilder();
                    foreach (int nId in lstIds)
                    {
                        bl.Append(nId);
                        bl.Append(',');
                    }
                    if (bl.Length > 0)
                    {
                        bl.Remove(bl.Length - 1, 1);
                        CListeObjetsDonnees lstObjets = new CListeObjetsDonnees(ctxSource, tp);
                        lstObjets.Filtre = new CFiltreData(strChampId + " in (" + bl.ToString() + ")");
                        foreach (CObjetDonneeAIdNumerique objet in lstObjets)
                            m_mappeur.ReferencerObjet(objet);
                        lstObjets = new CListeObjetsDonnees(ctxCible, tp);
                        lstObjets.Filtre = new CFiltreData(strChampId + " in (" + bl.ToString() + ")");
                        foreach (CObjetDonneeAIdNumerique objet in lstObjets)
                            m_mappeur.ReferencerObjet(objet);

                    }
                }
            }


            int nNumeroOrdreDepart = NumeroOrdreCourant;

            foreach (CAuditVersionParametrageTypeEntite parametre in parametrage.TypesParametres)
            {
                ///REPOMAGE HONTEUX DU CODE, A REVOIR
                ///
                Dictionary<string, Dictionary<int, bool>> tableElementsAjoutes = new Dictionary<string, Dictionary<int, bool>>();

                //Charge toutes les modifs
                List<int> lstIdsVO = null;
                if (!dicModifsParType.TryGetValue(parametre.TypeEntite.ToString(), out lstIdsVO))
                    continue;//Rien pour ce type
                bl = new StringBuilder();
                foreach (int nIdVO in lstIdsVO)
                {
                    bl.Append(nIdVO);
                    bl.Append(',');
                }
                if (bl.Length == 0)
                    continue;//Rien (c'est louche)
                bl.Remove(bl.Length - 1, 1);
                CListeObjetsDonnees cvoos = new CListeObjetsDonnees(vCible.ContexteDonnee, typeof(CVersionDonneesObjetOperation));
                cvoos.Filtre = new CFiltreData(CVersionDonneesObjet.c_champId + " in (" + bl.ToString() + ")");
                cvoos.InterditLectureInDB = true;//Car lus plus haut avec un readDependances

                foreach (CVersionDonneesObjetOperation cvoo in cvoos.ToArrayList())
                {
                    Dictionary<int, bool> dicoAddedForType = null;
                    if (tableElementsAjoutes.TryGetValue(cvoo.VersionObjet.StringTypeElement, out dicoAddedForType))
                    {
                        if (dicoAddedForType.ContainsKey(cvoo.VersionObjet.IdElement))
                        {
                            //L'élément a été ajouté, donc, toutes les lignes d'audit ont été créées
                            continue;
                        }
                    }
                    if (cvoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Ajout)
                    {
                        if (dicoAddedForType == null)
                        {
                            dicoAddedForType = new Dictionary<int, bool>();
                            tableElementsAjoutes[cvoo.VersionObjet.StringTypeElement] = dicoAddedForType;
                        }
                        dicoAddedForType[cvoo.VersionObjet.IdElement] = true;
                    }
                    //CREATION CAVO 
                    CVersionDonneesObjet cvo = cvoo.VersionObjet;
                    string strTp = cvo.StringTypeElement;
                    string strChampID = CUtilAChampID.GetChampID(cvo.TypeElement);

                    //int? nIdOriginal = m_mappeur.GetOriginalID(strTp, cvo.IdElement);
                    //if (!nIdOriginal.HasValue)
                    //{
                    //    throw new Exception("Element non referencé ?");
                    //}
                    //int nIDEle = nIdOriginal.Value;
                    int nIDEle = cvo.IdElement;



                    CAuditVersionObjet cavo = m_mappeur.GetCAVO(strTp, cvo.IdElement);

                    CObjetDonneeAIdNumerique objSource = null;
                    CObjetDonneeAIdNumerique objCible = null;
                    CAuditVersionParametrageTypeEntite paramType = TypeAudit.ParametrageObject.GetParametrage(CActivatorSurChaine.GetType(strTp).Name);
                    if (cvoo.TypeOperation.Code != CTypeOperationSurObjet.TypeOperation.Ajout)
                        objSource = GetObjetWithID(strTp, nIDEle, ctxSource);
                    if (cvoo.TypeOperation.Code != CTypeOperationSurObjet.TypeOperation.Suppression)
                        objCible = GetObjetWithID(strTp, nIDEle, ctxCible);

                    if (cavo == null)
                    {
                        result = GetNewCAVO(paramType, objSource, objCible);
                        if (!result)
                            return result;
                        cavo = (CAuditVersionObjet)result.Data;
                    }
                    else
                        cavo.EmpilerVersionElement(objCible);

                    //Si le champ est geré comme un blob à version partielle,
                    //on ne le présente que si la valeur est effectivement un IDifferenceBlob
                    if (objSource is IObjetABlobAVersionPartielle &&
                        ((IObjetABlobAVersionPartielle)objSource).IsBlobParDifference(cvoo.FieldKey) ||
                        objCible is IObjetABlobAVersionPartielle &&
                        ((IObjetABlobAVersionPartielle)objCible).IsBlobParDifference(cvoo.FieldKey)
                        ||
                        typeof(IDifferencesBlob).IsAssignableFrom(cvoo.TypeValeur))
                    {
                        //BLOB A DIFFERENCE (Modification sur un champ IDifferencesBlob)
                        if (cvoo.TypeValeur == typeof(IDifferencesBlob))
                        {
                            if (AuditDetaille)
                                result = CreateCAVOOsFromIDifferenceBlob((IDifferencesBlob)cvoo.GetValeurStd(), cavo, cvoo.TimeStamp);
                            else
                            {
                                IObjetABlobAVersionPartielle objABlob = objCible != null ? (IObjetABlobAVersionPartielle)objCible : (IObjetABlobAVersionPartielle)objSource;
                                result = CreateCAVOOForModificationChamp(ref cavo, objSource, objCible, cvoo.Champ, CGestionnaireAChampPourVersion.GetJournaliseur(cvoo.TypeChamp), objABlob, paramType, cvoo.TimeStamp);
                            }
                        }
                    }
                    //AUTRE (Ajout/Suppression entité ou Modification sur un champ)
                    else
                    {
                        result = CreateCAVOOFromCVOO(cvoo, cavo, objSource, objCible, paramType, cvoo.TimeStamp);
                    }
                    if (!result)
                        return result;
                }
                int nNumeroOrdreFinal = NumeroOrdreCourant;

                //Récupère les CAVOO qui viennent d'être créés et les renumérotte en triant
                //sur TimeStampModification puis sur ordre

                //Crée la liste des CAVO de cet audit
                bl = new StringBuilder();
                foreach (CAuditVersionObjet auditObjet in VersionsObjets)
                {
                    bl.Append(auditObjet.Id);
                    bl.Append(',');
                }
                if (bl.Length > 0)
                {
                    bl.Remove(bl.Length - 1, 1);
                    CListeObjetsDonnees listeCAVOOTousFraisCrees = new CListeObjetsDonnees(ContexteDonnee, typeof(CAuditVersionObjetOperation));
                    listeCAVOOTousFraisCrees.InterditLectureInDB = true;
                    listeCAVOOTousFraisCrees.Filtre = new CFiltreData(CAuditVersionObjet.c_champId + " in (" +
                        bl.ToString() + ") and " +
                        CAuditVersionObjetOperation.c_champNumOrdre + ">=@1", nNumeroOrdreDepart);
                    listeCAVOOTousFraisCrees.Tri = CAuditVersionObjetOperation.c_champEditTime + "," + CAuditVersionObjetOperation.c_champNumOrdre;
                    int nOrdre = nNumeroOrdreDepart;
                    foreach (CAuditVersionObjetOperation cavoo in listeCAVOOTousFraisCrees.ToArrayList())
                        cavoo.NumeroOrdre = nOrdre++;
                    m_nOrdre = nOrdre;
                }
            }

            return result;

        }

		//Fourni le numéro de l'opération suivante
		private int m_nOrdre;
		private int NumeroOrdreSuivant
		{
			get
			{
				m_nOrdre++;
				return m_nOrdre;
			}
		}
		//Fournit le dernier numéro d'ordre utilisé
		private int NumeroOrdreCourant
		{
			get
			{
				return m_nOrdre;
			}
		}
		
		//RECUPERATION DES ELEMENTS CONCERNES
		private CResultAErreur GetElementsConcernes(CVersionDonnees version, CContexteDonnee ctxElements, CAuditVersionParametrageTypeEntite paramType)
		{
			CResultAErreur result = CResultAErreur.True;
		
			//Indique que seuls les éléments de la version sont à prendre en compte
			bool bElementsDeLAVersionUniquement =
				MappageParFormule &&
				!typeof(IObjetSansVersion).IsAssignableFrom(paramType.TypeEntite) &&
				version != null;

			CFiltreData filtre = null;
			if (paramType.Filtre != null)
			{
				result = paramType.Filtre.GetFiltreData();
				filtre = (CFiltreData)result.Data;
				if (!result)
					return result;
			}
			string strChampID = CUtilAChampID.GetChampID(paramType.TypeEntite);

            CListeObjetsDonnees elements = null;
            //Pour les mappages par id et les versions qui ont des CVOs on exclu ceux qui n'ont pas de CVO
            if (!MappageParFormule
                && version != null
                && ctxElements.IdVersionDeTravail != null)
            //&& version.TypeVersion.Code != CTypeVersion.TypeVersion.Audit)
            {
                CFiltreData filtreCVO = new CFiltreData(
                    CVersionDonneesObjet.c_champTypeElement + " =@1 AND " +
                    CVersionDonnees.c_champId + " =@2 ", paramType.TypeEntite.ToString(), version.Id);
                CListeObjetsDonnees lstCVO = new CListeObjetsDonnees(ContexteDonnee, typeof(CVersionDonneesObjet), filtreCVO);
                if (lstCVO.Count != 0)
                {
                    StringBuilder blTousIds = new StringBuilder();
                    StringBuilder blIds = new StringBuilder();
                    int nNbIds = 0;
                    int nNbToRead = lstCVO.Count;
                    int nNbLus = 0;
                    foreach (CVersionDonneesObjet cvo in lstCVO)
                    {
                        nNbLus++;
                        blIds.Append(cvo.IdElement);
                        blIds.Append(",");
                        nNbIds++;
                        if (nNbIds > 500 || nNbLus == nNbToRead)
                        {
                            blTousIds.Append(blIds.ToString());
                            blIds.Remove(blIds.Length - 1, 1);
                            CFiltreData filtreTmp = new CFiltreData(strChampID + " in (" + blIds.ToString() + ")");
                            filtreTmp = CFiltreData.GetAndFiltre(filtreTmp, filtre);
                            //Lit les éléments
                            CListeObjetsDonnees lstTmp = new CListeObjetsDonnees(ctxElements, paramType.TypeEntite, filtre);
                            lstTmp.AssureLectureFaite();
                            blIds = new StringBuilder();
                            nNbIds = 0;
                        }
                    }
                    if (blTousIds.Length > 0)
                        blTousIds.Remove(blTousIds.Length - 1, 1);
                    filtre = new CFiltreData(strChampID + " in (" + blTousIds.ToString() + ")");
                    elements = new CListeObjetsDonnees(ctxElements, paramType.TypeEntite, filtre);
                    elements.InterditLectureInDB = true;
                }
                else
                    elements = new CListeObjetsDonnees(ctxElements, paramType.TypeEntite, new CFiltreDataImpossible());
            }
            else
            {
                if (filtre != null)
                    elements = new CListeObjetsDonnees(ctxElements, paramType.TypeEntite, filtre);
                else
                    elements = new CListeObjetsDonnees(ctxElements, paramType.TypeEntite);
            }

			if (typeof(IObjetDonneeAChamps).IsAssignableFrom(paramType.TypeEntite))
			{
				elements.ReadDependances("RelationsChampsCustom");
			}

			ArrayList lstFinale = null;

			//Si on ne veut que les éléments de la version :
			if (version != null && bElementsDeLAVersionUniquement && !typeof(IObjetSansVersion).IsAssignableFrom(paramType.TypeEntite))
			{
				if (elements.Count > 0)
				{
					string strChampId = "";
					strChampId = ((CObjetDonneeAIdNumerique)elements[0]).GetChampId();
					//On va chercher tous les élements de ce type qui sont dans la version
					C2iRequeteAvancee requete = new C2iRequeteAvancee();
					requete.TableInterrogee = elements.NomTable;
					requete.ListeChamps.Add(new C2iChampDeRequete(
						"ID_ORG",
						new CSourceDeChampDeRequete(CSc2iDataConst.c_champOriginalId),
						typeof(int),
						OperationsAgregation.None,
						true));
					requete.ListeChamps.Add(new C2iChampDeRequete(
					"ID",
					new CSourceDeChampDeRequete(strChampId),
					typeof(int),
					OperationsAgregation.None,
					true));
					requete.FiltreAAppliquer = new CFiltreData(
						CSc2iDataConst.c_champIdVersion + "=@1",
						version.Id);
					requete.FiltreAAppliquer.IgnorerVersionDeContexte = true;
					result = requete.ExecuteRequete(ContexteDonnee.IdSession);
					if (!result)
						return result;
					Dictionary<int, bool> tableElementsAGarder = new Dictionary<int, bool>();
					foreach ( DataRow row in ((DataTable)result.Data).Rows )
					{
						if (row["ID_ORG"] is int)
							tableElementsAGarder[(int)row["ID_ORG"]] = true;
						if ( row["ID"] is int )
							tableElementsAGarder[(int)row["ID"]] = true;
					}
					//Ne prend que les éléments à garder
					lstFinale = new ArrayList();
					foreach (CObjetDonneeAIdNumerique objet in elements.ToArrayList())
						if (tableElementsAGarder.ContainsKey(objet.Id))
							lstFinale.Add(objet);
				}
			}
			if (lstFinale == null)
			{
				lstFinale = new ArrayList(elements);
			}

			string strType = paramType.TypeEntite.ToString();
			foreach (CObjetDonneeAIdNumerique obj in lstFinale)
				m_mappeur.ReferencerObjet(obj);

			result.Data = lstFinale;

			return result;
		}


		#region MAPPAGE TYPE - IDELEMENT - CAVO
		//Cet objet créé un mappage entre un type, un element et un CAVO
		//L'élément peux évoluer de version
		public class CMappeurTypeElementCAVO
		{
			public CMappeurTypeElementCAVO(CContexteDonnee ctx)
			{
				m_ctx = ctx;
				//m_mappIdInVersionToOriginalID = new Dictionary<string, Dictionary<int, int>>();
				m_mappType_ID_CAVO = new Dictionary<string, Dictionary<int, CAuditVersionObjet>>();
				//m_mappLastId = new Dictionary<string, Dictionary<int, Stack<int>>>();
			}


			private CContexteDonnee m_ctx;
			//private Dictionary<string, Dictionary<int, Stack<int>>> m_mappLastId;
			//private Dictionary<string, Dictionary<int, int>> m_mappIdInVersionToOriginalID;
			private Dictionary<string, Dictionary<int, CAuditVersionObjet>> m_mappType_ID_CAVO;


			public List<int> GetAllOriginalsIds(string strType)
			{
				return new List<int>(m_mappType_ID_CAVO[strType].Keys);
			}

			//public List<int> GetAllIdsOfTypeInAllVersion(string strType)
			//{
			//    List<int> ids = new List<int>();
			//    Dictionary<int, Stack<int>> elements = m_mappLastId[strType];
			//    foreach (int nIdOriginal in elements.Keys)
			//    {
			//        int[] allIds = elements[nIdOriginal].ToArray();
			//        foreach(int nIdInVersion in allIds)
			//            ids.Add(nIdInVersion);
			//    }

			//    return ids;
			//}

			//public List<int> GetLastIdsOfType(string strType)
			//{
			//    List<int> ids = new List<int>();
			//    Dictionary<int, Stack<int>> elements = m_mappLastId[strType];
			//    foreach(int nIdOriginal in elements.Keys)
			//        ids.Add(elements[nIdOriginal].Peek());

			//    return ids;
			//}

			//private void EmpileIdVersion(string strType, int nIdOriginal, int? nId)
			//{
			//    if (m_mappLastId[strType].ContainsKey(nIdOriginal))
			//    {
			//        if (!nId.HasValue)
			//        {
			//            return;
			//            throw new Exception("Impossible");
			//        }
			//        Stack<int> pile = m_mappLastId[strType][nIdOriginal];
			//        pile.Push(nId.Value);
			//    }
			//    else
			//    {
			//        Stack<int> pile = new Stack<int>();
			//        pile.Push(nIdOriginal);
			//        m_mappLastId[strType].Add(nIdOriginal, pile);
			//    }
			//}

			private void ReferencerTypeSiNonExistant(string strType)
			{
				if (!m_mappType_ID_CAVO.ContainsKey(strType))
				{
					Dictionary<int, CAuditVersionObjet> mapp = new Dictionary<int, CAuditVersionObjet>();
					m_mappType_ID_CAVO.Add(strType, mapp);
					//Dictionary<int, int> mappIds = new Dictionary<int, int>();
					//m_mappIdInVersionToOriginalID.Add(strType, mappIds);
					//Dictionary<int, Stack<int>> mappLastId = new Dictionary<int, Stack<int>>();
					//m_mappLastId.Add(strType, mappLastId);
				}
			}
			public void ReferencerObjet(CObjetDonneeAIdNumerique objet)
			{
				string strTypeEle = objet.GetType().ToString();
				ReferencerTypeSiNonExistant(strTypeEle);

				//int? nNewID = GetIDInVersion(objet);

				////Si l'objet à un Id différent de sa version de base
				//if (nNewID.HasValue)
				//    m_mappIdInVersionToOriginalID[strTypeEle].Add(nNewID.Value, objet.Id);
				//else if (!m_mappType_ID_CAVO[strTypeEle].ContainsKey(objet.Id))
				if (!m_mappType_ID_CAVO[strTypeEle].ContainsKey(objet.Id))
					m_mappType_ID_CAVO[strTypeEle].Add(objet.Id, null);

				//EmpileIdVersion(strTypeEle, objet.Id, nNewID);
			}
			public void ReferencerCAVO(CAuditVersionObjet cavo)
			{
				string strType = cavo.StringTypeElement;
				if (!m_mappType_ID_CAVO.ContainsKey(strType))
				{
					//IMPOSSIBLE
					throw new Exception("Le CAVO concerne des elements dont le type n'a pas été mappé");
				}

				//On reprécise que dans le cas d'un mappage d'id les valeur pour 
				//IdObjetCible & IdObjetSource seront identiques et = à l'id
				//de base de l'objet
				Dictionary<int, CAuditVersionObjet> mapp = m_mappType_ID_CAVO[strType];
				if (cavo.IdObjetCible != null)
					if (!mapp.ContainsKey(cavo.IdObjetCible.Value))
						mapp.Add(cavo.IdObjetCible.Value, cavo);
					else
						mapp[cavo.IdObjetCible.Value] = cavo;

				if (cavo.IdObjetSource != null)
					if (!mapp.ContainsKey(cavo.IdObjetSource.Value))
						mapp.Add(cavo.IdObjetSource.Value, cavo);
					else
						mapp[cavo.IdObjetSource.Value] = cavo;
			}
			
			public List<string> TypesReferences
			{
				get
				{
					List<string> strTypes = new List<string>();
					foreach (string strTp in m_mappType_ID_CAVO.Keys)
						strTypes.Add(strTp);
					return strTypes;
				}
			}

			//public int? GetOriginalID(string strType, int nId)
			//{
			//    if (!m_mappType_ID_CAVO.ContainsKey(strType))
			//    {
			//        //IMPOSSIBLE
			//        throw new Exception("Le CAVO concerne des elements dont le type n'as pas été mappé");
			//    }

			//    if (m_mappType_ID_CAVO[strType].ContainsKey(nId))
			//        return (int?)nId;
			//    else if (m_mappIdInVersionToOriginalID[strType].ContainsKey(nId))
			//        return m_mappIdInVersionToOriginalID[strType][nId];
			//    return null;
			//}
			//public int? GetLastId(string strType, int nOriginalID)
			//{
			//    if (!m_mappType_ID_CAVO.ContainsKey(strType) 
			//        || !m_mappLastId[strType].ContainsKey(nOriginalID) )
			//        return null;
			//    return (int?)m_mappLastId[strType][nOriginalID].Peek();
			//}
			//public int? GetIDInVersion(CObjetDonneeAIdNumeriqueAuto objet)
			//{
			//    int? nLastId = GetLastId(objet.GetType().ToString(), objet.Id);
			//    if (!nLastId.HasValue)
			//        return null;
			//    CFiltreData filtreTest = new CFiltreData("SC2I_ORIGINAL_ID = @1", nLastId.Value);
			//    C2iRequeteAvancee req = new C2iRequeteAvancee(objet.ContexteDonnee.IdVersionDeTravail);
			//    req.TableInterrogee = objet.GetNomTable();
			//    req.FiltreAAppliquer = filtreTest;
			//    string strChampID = CUtilAChampID.GetChampID(objet.GetType());
			//    req.ListeChamps.Add(new C2iChampDeRequete(strChampID, new CSourceDeChampDeRequete(strChampID), typeof(int), OperationsAgregation.None, false));
			//    CResultAErreur resErreur = req.ExecuteRequete(objet.ContexteDonnee.IdSession);
			//    if (resErreur)
			//    {
			//        DataTable table = (DataTable)resErreur.Data;
			//        if (table != null && table.Rows.Count == 1)
			//            return (int?)table.Rows[0][strChampID];
			//    }
			//    return null;
			//}

			
			public CAuditVersionObjet GetCAVO(string strTp, int nID)
			{
				if (m_mappType_ID_CAVO[strTp].ContainsKey(nID))
					return m_mappType_ID_CAVO[strTp][nID];

				//if (m_mappIdInVersionToOriginalID[strTp].ContainsKey(nID))
				//{
				//    return m_mappType_ID_CAVO[strTp][m_mappIdInVersionToOriginalID[strTp][nID]];
				//}
				return null;
			}
			public void DeleteReferencementCAVO(CAuditVersionObjet cavo)
			{
				CResultAErreur result = CResultAErreur.True;
				string strType = cavo.StringTypeElement;
				if (!m_mappType_ID_CAVO.ContainsKey(strType))
					return;
				Dictionary<int, CAuditVersionObjet> mappage = m_mappType_ID_CAVO[strType];
				List<int> lstIdToRAZ = new List<int>();
				foreach (int nIdEle in mappage.Keys)
					if (mappage[nIdEle] != null && mappage[nIdEle].Id == cavo.Id)
						lstIdToRAZ.Add(nIdEle);
				foreach (int nIdEleToRAZ in lstIdToRAZ)
					mappage[nIdEleToRAZ] = null;
			}
		}
		private CMappeurTypeElementCAVO m_mappeur;
		#endregion



		#region CHAMPS
		private CResultAErreur CreateCAVOOForModificationChamp(
			ref CAuditVersionObjet cavo,
			CObjetDonneeAIdNumerique objSrc,
			CObjetDonneeAIdNumerique objCible,
			IChampPourVersion champ,
			IJournaliseurDonneesChamp journaliseur,
			IObjetABlobAVersionPartielle blobAVersionPartielle,
			CAuditVersionParametrageTypeEntite paramType,
			DateTime? timeStampModification)
		{
			CResultAErreur result = CResultAErreur.True;

			/*if(paramType.TypeEntite == typeof(CTableParametrable))
			{
				if(objSrc != null)
				{
					DataTable dt = ((CTableParametrable)objSrc).DataTableObject;
				}
				if(objCible != null)
				{
					DataTable dt = ((CTableParametrable)objCible).DataTableObject;
				}
			}*/
			object objValSrc = objSrc == null ? null : journaliseur.GetValeur(objSrc, champ);
			object objValCible = objCible == null ? null : journaliseur.GetValeur(objCible, champ);

			if (!ShowNullAddingOperations && objValSrc == null && objValCible == null)
			{
				string strNomChamp = champ.FieldKey;
				return result;
			}

			//ON DETERMINE SI LE CHAMP EST UN BLOB A DIFFERENCE
			if (blobAVersionPartielle != null && blobAVersionPartielle.IsBlobParDifference(champ.FieldKey))
			{
				byte[] dataSource = null;
				if(objValSrc is sc2i.data.CDonneeBinaireInRow)
					dataSource = ((sc2i.data.CDonneeBinaireInRow)objValSrc).Donnees;
				else if(objValSrc != null)
					dataSource = (byte[])objValSrc;

				byte[] dataCible = null;
				if (objValCible is sc2i.data.CDonneeBinaireInRow)
					dataCible = ((sc2i.data.CDonneeBinaireInRow)objValCible).Donnees;
				else if (objValCible != null)
					dataCible = (byte[])objValCible;
				IDifferencesBlob diff = blobAVersionPartielle.GetDifferencesBlob(champ.FieldKey, dataCible, dataSource);
				if (diff == null)
					return result;
				if (diff.GetDetails().Count > 0)
				{
					if (cavo == null)
					{
						result = GetNewCAVO(paramType, objSrc, objCible);
						if (!result)
							return result;
						cavo = (CAuditVersionObjet)result.Data;
					}

					result = CreateCAVOOsFromIDifferenceBlob(diff, cavo, timeStampModification);
				}
			}
			//else if ((objValSrc != null && !objValSrc.Equals(objValCible))
				//|| (objValCible != null && !objValCible.Equals(objValSrc)))
			else
			{
				bool bDifferent = false;
				if (objValCible == null && objValSrc != null ||
					objValCible != null && objValSrc == null)
					bDifferent = true;
				if (objValSrc != null && objValCible != null &&
					!objValCible.Equals(objValSrc))
					bDifferent = true;
				if (bDifferent)
				{
					if (cavo == null)
					{
						result = GetNewCAVO(paramType, objSrc, objCible);
						if (!result)
							return result;
						cavo = (CAuditVersionObjet)result.Data;
					}

					CAuditVersionObjetOperation cavoo = null;
					CTypeOperationSurObjet typeOp;
					if (objCible == null && objSrc != null)
						typeOp = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Suppression);
					else if (objSrc == null && objCible != null)
						typeOp = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Ajout);
					else
						typeOp = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Modification);

					if (!AuditDetaille)
						cavoo = GetLastCAVOO(cavo, champ);

					if (cavoo == null)
					{
						cavoo = GetNewCAVOO(cavo, champ, typeOp, timeStampModification);
                        try
                        {
                            cavoo.ValeurSource = objValSrc;
                            cavoo.ValeurCible = objValCible;
                        }
                        catch
                        {
                        }
					}
					else
					{
						if (AuditDetaille)
							cavoo.ValeurSource = objValSrc;
						cavoo.TypeOperation = typeOp;
						cavoo.ValeurCible = objValCible;
						cavoo.NumeroOrdre = NumeroOrdreSuivant;
					}
				}
				
			}
			return result;
		}

		//Liste des journaliseurs connus (cache)
		private List<IJournaliseurDonneesChamp> m_journaliseurs = null;
		private void CreateCAVOOForModificationChamps(
			ref CAuditVersionObjet cavo,
			CObjetDonneeAIdNumerique objSrc,
			CObjetDonneeAIdNumerique objCible,
			CAuditVersionParametrageTypeEntite paramType,
			DateTime? timeStampModification)
		{
			CResultAErreur result = CResultAErreur.True;

			//ON RECUPERE LE BLOB A VERSION PARTIELLE SI IL EN EST UN
			IObjetABlobAVersionPartielle blobAVersionPartielle = null;
			if (objSrc != null && typeof(IObjetABlobAVersionPartielle).IsAssignableFrom(objSrc.GetType()))
				blobAVersionPartielle = (IObjetABlobAVersionPartielle)objSrc;
			if (blobAVersionPartielle == null && (objCible != null && typeof(IObjetABlobAVersionPartielle).IsAssignableFrom(objCible.GetType())))
				blobAVersionPartielle = (IObjetABlobAVersionPartielle)objCible;
			CObjetDonneeAIdNumerique obj = objSrc != null ? objSrc : objCible;
			if ( m_journaliseurs == null )
				m_journaliseurs = CGestionnaireAChampPourVersion.GetJournaliseurs();
			foreach (IJournaliseurDonneesChamp journaliseur in m_journaliseurs)
			{
				List<IChampPourVersion> champs = journaliseur.GetChampsJournalisables(obj);
				foreach (IChampPourVersion champ in champs)
				{
					CreateCAVOOForModificationChamp(ref cavo, objSrc, objCible, champ, journaliseur, blobAVersionPartielle, paramType, timeStampModification);
				}
			}
		}

		//Pour les IDifferenceBlob
		private CResultAErreur CreateCAVOOsFromIDifferenceBlob(IDifferencesBlob blobDetaille, CAuditVersionObjet cavo, DateTime? timeStampModification)
		{
			CResultAErreur result = CResultAErreur.True;
			if (blobDetaille == null || cavo == null)
			{
				result.EmpileErreur("dfsjhkfjsklfj");
				return result;
			}
            Dictionary<string, CAuditVersionObjetOperation> dicFieldToCAVOO = new Dictionary<string, CAuditVersionObjetOperation>();
            foreach (CAuditVersionObjetOperation operation in cavo.Datas)
                dicFieldToCAVOO[operation.FieldKey] = operation;
			List<CDetailOperationSurObjet> lstOps = blobDetaille.GetDetails();
			foreach (CDetailOperationSurObjet op in lstOps)
			{
				CAuditVersionObjetOperation cavoo = null;
                bool bNewCAvoo = false;
                if (!AuditDetaille)
                {
                    bNewCAvoo = !dicFieldToCAVOO.TryGetValue(op.Champ.FieldKey, out cavoo);
                }

				result = CreateCAVOOFromDetailOperationSurObjet(op, cavo, blobDetaille.GetType(), ref cavoo,
					op.TimeStampModification==null?timeStampModification:op.TimeStampModification);
                if (bNewCAvoo)
                    dicFieldToCAVOO[cavoo.FieldKey] = cavoo;
				if (!result)
					break;
			}

			return result;
		}
		private CResultAErreur CreateCAVOOFromDetailOperationSurObjet(
			CDetailOperationSurObjet cdoo, 
			CAuditVersionObjet cavo, 
			Type tpIDiffBlob,
			ref CAuditVersionObjetOperation cavoo,
			DateTime? timeStampModification)
		{
			CResultAErreur result = CResultAErreur.True;
			if (cavoo == null)
			{
				cavoo = GetNewCAVOO(cavo, cdoo.Champ, cdoo.TypeOperation, timeStampModification);
				cavoo.IDifferencesBlobType = tpIDiffBlob.ToString();

				if (cdoo.ValeurCible != null)
				{
					cavoo.ValeurCible = cdoo.ValeurCible.GetStringSerialisation();
					cavoo.ValChampCibleBlob.Donnees = cdoo.ValeurCible.GetValBlob();
				}
				else
				{
					cavoo.ValeurCible = null;
					cavoo.ValChampCibleBlob = null;
				}
				if (cdoo.ValeurSource != null)
				{
					cavoo.ValeurSource = cdoo.ValeurSource.GetStringSerialisation();
					cavoo.ValChampSourceBlob.Donnees = cdoo.ValeurSource.GetValBlob();
				}
				else
				{
					cavoo.ValeurSource = null;
					cavoo.ValChampSourceBlob = null;
				}
			}
			//SI LE CAVOO N'EST PAS = NULL C QU'ON EST EN TRAIN DE METTRE A JOUR
			else
			{
				if (cdoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Modification)
				{
					cavoo.ValeurCible = cdoo.ValeurCible.GetStringSerialisation();
					if (cavoo.ValeurSource != null)
						cavoo.NumeroOrdre = NumeroOrdreSuivant;
				}
				else if (cdoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Suppression)
					if (cavoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Ajout)
					{
						m_cavosToDelete.Add(cavoo.VersionObjet);
					}
					else
					{
						cavoo.TypeOperation = cdoo.TypeOperation;
						cavoo.ValeurCible = null;
						if(cavoo.ValeurSource != null)
							cavoo.NumeroOrdre = NumeroOrdreSuivant;
					}
				else
				{
					cavoo.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Modification);
					cavoo.ValeurCible = cdoo.ValeurCible.GetStringSerialisation();
					if (cavoo.ValeurSource != null)
						cavoo.NumeroOrdre = NumeroOrdreSuivant;
				}
			}

			return result;
		}
		#endregion
		#endregion

		#region MAPPAGE PAR ID
		private CResultAErreur AuditWithCVOO(CContexteDonnee ctxSource, CContexteDonnee ctxCible, CVersionDonnees versionCible)
		{
			CResultAErreur result = CResultAErreur.True;

			//RECUPERATION DES CVOOs POUR CHAQUE TYPES
			CListeObjetsDonnees cvos = versionCible.VersionsObjets;
			cvos.InterditLectureInDB = true;
			CFiltreData filtreCVO = null;

			int nNumeroOrdreDepart = NumeroOrdreCourant;
            StringBuilder bl = new StringBuilder();
			foreach (string strDefType in m_mappeur.TypesReferences)
			{
				List<int> lstIdsEle = m_mappeur.GetAllOriginalsIds(strDefType);
				if(lstIdsEle.Count == 0)
					continue;
				string strIdsEle = "";
                bl = new StringBuilder();
                foreach (int n in lstIdsEle)
                {
                    bl.Append(n);
                    bl.Append(",");
                }
                if (bl.Length > 0)
                    bl.Remove(bl.Length - 1, 1);
                strIdsEle = bl.ToString(); ;

				CFiltreData filtreTmp = new CFiltreData(
						CVersionDonneesObjet.c_champTypeElement + " =@1 AND " +
						CVersionDonneesObjet.c_champIdElement + " in(" + strIdsEle + ")",
						strDefType);
				    if (filtreCVO == null)
				        filtreCVO = filtreTmp;
				    else
				        filtreCVO = CFiltreData.GetOrFiltre(filtreCVO, filtreTmp);
			}
			cvos.Filtre = filtreCVO;
			if (cvos.Count == 0)
				return result;
			cvos.ReadDependances("ToutesLesOperations");
			//Crée la liste des cvoos. On ne chargera pas la liste dans la base
			//Donc, on n'est pas limité à 1000 id
			StringBuilder idsCVOS = new StringBuilder();
			foreach ( CVersionDonneesObjet vo in cvos )
			{
				idsCVOS.Append ( vo.Id );
				idsCVOS.Append (",");
			}
			idsCVOS.Remove(idsCVOS.Length - 1,1);
			CListeObjetsDonnees cvoos = new CListeObjetsDonnees(ContexteDonnee, typeof(CVersionDonneesObjetOperation));
			cvoos.InterditLectureInDB = true; //Puisque c'est déjà fait
			cvoos.Filtre = new CFiltreData(CVersionDonneesObjet.c_champId + " in (" +
				idsCVOS.ToString() + ")");

			cvoos.Tri = CVersionDonneesObjetOperation.c_champId;

			//Stocke la table des éléments qui ont été ajoutés, donc
			//pour lesquels on a generé toutes les valeurs de champs
			//en ligne d'audit.
			//Pour ce élément, il ne faut pas traiter les lignes modifiées
			//trouvées puisque les lignes d'audit ont déjà été créées par
			//CreateCAVOOFromCVOO de la ligne d'opération Ajoutée
			//Type ->ID->True
			Dictionary<string, Dictionary<int, bool>> tableElementsAjoutes = new Dictionary<string,Dictionary<int,bool>>();

			foreach (CVersionDonneesObjetOperation cvoo in cvoos.ToArrayList())
			{
				Dictionary<int, bool> dicoAddedForType = null;
				if (tableElementsAjoutes.TryGetValue(cvoo.VersionObjet.StringTypeElement, out dicoAddedForType))
				{
					if (dicoAddedForType.ContainsKey(cvoo.VersionObjet.IdElement))
					{
						//L'élément a été ajouté, donc, toutes les lignes d'audit ont été créées
						continue;
					}
				}
				if (cvoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Ajout)
				{
					if ( dicoAddedForType == null )
					{
						dicoAddedForType = new Dictionary<int, bool>();
						tableElementsAjoutes[cvoo.VersionObjet.StringTypeElement] = dicoAddedForType;
					}
					dicoAddedForType[cvoo.VersionObjet.IdElement] = true;
				}
				//CREATION CAVO 
				CVersionDonneesObjet cvo = cvoo.VersionObjet;
				string strTp = cvo.StringTypeElement;
				string strChampID = CUtilAChampID.GetChampID(cvo.TypeElement);

				//int? nIdOriginal = m_mappeur.GetOriginalID(strTp, cvo.IdElement);
				//if (!nIdOriginal.HasValue)
				//{
				//    throw new Exception("Element non referencé ?");
				//}
				//int nIDEle = nIdOriginal.Value;
				int nIDEle = cvo.IdElement;



				CAuditVersionObjet cavo = m_mappeur.GetCAVO(strTp, cvo.IdElement);

				CObjetDonneeAIdNumerique objSource = null;
				CObjetDonneeAIdNumerique objCible = null;
				CAuditVersionParametrageTypeEntite paramType = TypeAudit.ParametrageObject.GetParametrage(CActivatorSurChaine.GetType(strTp).Name);
				if (cvoo.TypeOperation.Code != CTypeOperationSurObjet.TypeOperation.Ajout)
					objSource = GetObjetWithID(strTp, nIDEle, ctxSource);
				if (cvoo.TypeOperation.Code != CTypeOperationSurObjet.TypeOperation.Suppression)
					objCible = GetObjetWithID(strTp, nIDEle, ctxCible);

				if (cavo == null)
				{
					result = GetNewCAVO(paramType, objSource, objCible);
					if(!result)
						return result;
					cavo = (CAuditVersionObjet)result.Data;
				}
				else
					cavo.EmpilerVersionElement(objCible);

				//Si le champ est geré comme un blob à version partielle,
				//on ne le présente que si la valeur est effectivement un IDifferenceBlob
				if (objSource is IObjetABlobAVersionPartielle &&
					((IObjetABlobAVersionPartielle)objSource).IsBlobParDifference(cvoo.FieldKey) ||
					objCible is IObjetABlobAVersionPartielle &&
					((IObjetABlobAVersionPartielle)objCible).IsBlobParDifference(cvoo.FieldKey)
					||
					typeof(IDifferencesBlob).IsAssignableFrom(cvoo.TypeValeur))
				{
					//BLOB A DIFFERENCE (Modification sur un champ IDifferencesBlob)
					if (cvoo.TypeValeur == typeof(IDifferencesBlob))
					{
						if (AuditDetaille)
							result = CreateCAVOOsFromIDifferenceBlob((IDifferencesBlob)cvoo.GetValeurStd(), cavo, cvoo.TimeStamp);
						else
						{
							IObjetABlobAVersionPartielle objABlob = objCible != null ? (IObjetABlobAVersionPartielle)objCible : (IObjetABlobAVersionPartielle)objSource;
							result = CreateCAVOOForModificationChamp(ref cavo, objSource, objCible, cvoo.Champ, CGestionnaireAChampPourVersion.GetJournaliseur(cvoo.TypeChamp), objABlob, paramType, cvoo.TimeStamp);
						}
					}
				}
				//AUTRE (Ajout/Suppression entité ou Modification sur un champ)
				else
				{
					result = CreateCAVOOFromCVOO(cvoo, cavo, objSource, objCible, paramType, cvoo.TimeStamp);
				}
				if (!result)
					return result;
			}
			int nNumeroOrdreFinal = NumeroOrdreCourant;
			
			//Récupère les CAVOO qui viennent d'être créés et les renumérotte en triant
			//sur TimeStampModification puis sur ordre
			
			//Crée la liste des CAVO de cet audit
			bl = new StringBuilder();
			foreach (CAuditVersionObjet auditObjet in VersionsObjets)
			{
				bl.Append(auditObjet.Id);
				bl.Append(',');
			}
			if (bl.Length > 0)
			{
				bl.Remove(bl.Length - 1, 1);
				CListeObjetsDonnees listeCAVOOTousFraisCrees = new CListeObjetsDonnees(ContexteDonnee, typeof(CAuditVersionObjetOperation));
				listeCAVOOTousFraisCrees.InterditLectureInDB = true;
				listeCAVOOTousFraisCrees.Filtre = new CFiltreData(CAuditVersionObjet.c_champId + " in (" +
					bl.ToString() + ") and "+
					CAuditVersionObjetOperation.c_champNumOrdre+">=@1", nNumeroOrdreDepart);
				listeCAVOOTousFraisCrees.Tri = CAuditVersionObjetOperation.c_champEditTime + "," + CAuditVersionObjetOperation.c_champNumOrdre;
				int nOrdre = nNumeroOrdreDepart;
				foreach (CAuditVersionObjetOperation cavoo in listeCAVOOTousFraisCrees.ToArrayList())
					cavoo.NumeroOrdre = nOrdre++;
				m_nOrdre = nOrdre;
			}			
			return result;
		}

		//Pour les mappages par Ids
		private CResultAErreur CreateCAVOOFromCVOO(
			CVersionDonneesObjetOperation cvoo,
			CAuditVersionObjet cavo,
			CObjetDonneeAIdNumerique objSource,
			CObjetDonneeAIdNumerique objCible,
			CAuditVersionParametrageTypeEntite paramType,
			DateTime? timeStampDeModification)
		{
			CAuditVersionObjetOperation cavoo = null;
			if (!AuditDetaille)
				cavoo = GetLastCAVOO(cavo, cvoo.Champ);

			CResultAErreur result = CResultAErreur.True;
			if (cavoo == null)
			{
				cavoo = GetNewCAVOO(cavo, cvoo.Champ, cvoo.TypeOperation, timeStampDeModification);
				cavoo.TimeStampModification = timeStampDeModification;
				switch (cvoo.TypeOperation.Code)
				{
					case CTypeOperationSurObjet.TypeOperation.Modification:
						cavoo.ValeurCible = cvoo.GetValeurStd();
						IJournaliseurDonneesChamp journaliseur = CGestionnaireAChampPourVersion.GetJournaliseur(cvoo.TypeChamp);
						if(journaliseur == null || objSource == null)
						{
							if (!AuditDetaille && journaliseur != null)
								cavoo.ValeurSource = null;
							else
								throw new Exception("");
							//result.EmpileErreur("Impossible de récupérer l'objet source");
							//return result;
							
						}
						else
							cavoo.ValeurSource = journaliseur.GetValeur(objSource, cvoo.Champ);
						break;

					case CTypeOperationSurObjet.TypeOperation.Ajout:
						CreateCAVOOForModificationChamps(ref cavo, objSource, objCible, paramType, timeStampDeModification);
						//Change la date de tous les Cavoo pour qu'ils apparaissent après le cavoo de création
						foreach (CAuditVersionObjetOperation cavooDep in cavo.Datas)
							cavooDep.TimeStampModification = cavoo.TimeStampModification;
						break;

					case CTypeOperationSurObjet.TypeOperation.Suppression:
						CreateCAVOOForModificationChamps(ref cavo, objSource, objCible, paramType, timeStampDeModification);
						foreach (CAuditVersionObjetOperation cavooDep in cavo.Datas)
							cavooDep.TimeStampModification = cavoo.TimeStampModification;
						cavoo.NumeroOrdre = NumeroOrdreSuivant;
						break;

					case CTypeOperationSurObjet.TypeOperation.Aucune:
					default:
						break;
				}
				if (cavoo != null && (cavoo.ValeurCible != null && cavoo.ValeurCible.Equals(cavoo.ValeurSource) ||
                    cavoo.ValeurCible == cavoo.ValeurSource))
					cavoo.CancelCreate();

			}
				//POUR LE MODE NON DETAILLE UNIQUEMENT.... (pour le mode détaillé le cavoo est tjrs à null)
			else
			{
				if (cvoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Modification)
				{
					cavoo.ValeurCible = cvoo.GetValeurStd();
					//Si il existe une opération d'ajout anterieure on va laisser
					//cette nouvelle opération de modification sur le champ avec
					//les opérations 
					if(cavoo.ValeurSource != null)
						cavoo.NumeroOrdre = NumeroOrdreSuivant;
				}
				else if (cvoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Suppression)
					if (cavoo.TypeOperation.Code == CTypeOperationSurObjet.TypeOperation.Ajout)
					{
						m_cavosToDelete.Add(cavoo.VersionObjet);
					}
					else
					{
						//IMPOSSIBLE
					}
				else
				{
					//IMPOSSIBLE
				}
			}

			return result;
		}



		private CObjetDonneeAIdNumerique GetObjetWithID(string strType, int nId, CContexteDonnee ctx)
		{
			Type tp = CActivatorSurChaine.GetType(strType);
			string strChampID = ctx.GetTableSafe(CContexteDonnee.GetNomTableForType(tp)).PrimaryKey[0].ColumnName;
			CFiltreData filtre = new CFiltreData(strChampID + " =@1", nId);
			CListeObjetsDonnees lstObjSource = new CListeObjetsDonnees(ctx, tp, filtre);
			if (lstObjSource.Count == 1)
				return (CObjetDonneeAIdNumerique)lstObjSource[0];
			return null;
		}

		#endregion

		#region MAPPAGE PAR FORMULE

		private CResultAErreur AuditWithoutCVOO(
			CVersionDonnees vSource,
			CVersionDonnees vCible,
			CContexteDonnee ctxSource, 
			CContexteDonnee ctxCible, 
			CAuditVersionParametrageTypeEntite paramType)
		{
			CResultAErreur result = CResultAErreur.True;
			m_cavosReady = new Dictionary<int, CAuditVersionObjet>();

			result = GetElementsConcernes(vSource, ctxSource, paramType);
			ArrayList elementsOriginaux = null;
			ArrayList elementsFinaux = null;
			if (result)
			{
				elementsOriginaux = result.Data as ArrayList;
				result = GetElementsConcernes(vCible, ctxCible, paramType);
				if (result)
					elementsFinaux = result.Data as ArrayList;
			}
			if (!result || elementsFinaux == null || elementsOriginaux == null)
			{
				result.EmpileErreur(I.T("Error while auditing type @1|20005", DynamicClassAttribute.GetNomConvivial(paramType.TypeEntite)));
				return result;
			}
			/*elementsFinaux.InterditLectureInDB = true;
			elementsOriginaux.InterditLectureInDB = true;*/

			result = m_mappeurParCle.CalcKeys(elementsOriginaux, paramType, EOrigineVersion.Source);
			if (!result)
				result.EmpileErreur(I.T("Error while calculating keys in original version|30031"));
			else
				result = m_mappeurParCle.CalcKeys(elementsFinaux, paramType, EOrigineVersion.Cible);
			if (!result)
				result.EmpileErreur(I.T("Error while calculating keys in destination version|30032"));
			else
				result = CreateCAVOByFormule(elementsOriginaux, elementsFinaux, paramType, ESensCalcDifference.DeSourceVersCible, false);
			if (result)
				result = CreateCAVOByFormule(elementsFinaux, elementsOriginaux, paramType, ESensCalcDifference.DeCibleVersSource, true);
			if (!result)
				return result;
			return result;
		}


		//CAVO (pour les mappages par formules)
		

		//Sens de calcule
		private enum ESensCalcDifference
		{
			DeSourceVersCible,
			DeCibleVersSource
		}

		

		#region MAPPAGE OBJET - CLE
		private CMappeurParCle m_mappeurParCle;
		//Cet objet s'occupe de calculer les cles des objets d'une liste
		//en concervant un mappage avec leur ID. L'opération n'est disponible
		//que pour un type d'objet 
		private class CMappeurParCle
		{
			public CMappeurParCle(CAuditVersion audit)
			{
				m_audit = audit;
			}

			private CAuditVersion m_audit;


			/// <summary>
			/// Calcule les clés des objets concernés pour un sens donné
			/// </summary>
			/// <param name="liste"></param>
			/// <param name="paramType"></param>
			/// <param name="sens"></param>
			/// <returns></returns>
			public CResultAErreur CalcKeys(
				ArrayList liste,
				CAuditVersionParametrageTypeEntite paramType,
				EOrigineVersion sens)
			{

				CResultAErreur result = CResultAErreur.True;
				if (m_audit.AuditDetaille && sens == EOrigineVersion.Source && m_mappCleObjetsVCible != null)
				{
					m_mappCleObjetsVSource = m_mappCleObjetsVCible;
					m_mappObjetVSourceCle = m_mappObjetVCibleCle;
					return result;
				}

				Dictionary<int, string> mappageObjetCle = new Dictionary<int, string>();
				Dictionary<string, List<CObjetDonneeAIdNumerique>> mappageCleObjets = new Dictionary<string, List<CObjetDonneeAIdNumerique>>();

				foreach (CObjetDonneeAIdNumerique o in liste)
				{
					try
					{
						result = m_audit.GetKey(o, paramType);
						if (!result)
						{
							result.EmpileErreur(I.T("Error in Key formula : Element @1 (@2)|561",
							o.GetType().ToString(),
							o.Id.ToString()));
							return result;
						}
						string strKey = result.Data.ToString();
						if (mappageCleObjets.ContainsKey(strKey))
							mappageCleObjets[strKey].Add(o);
						else
						{
							List<CObjetDonneeAIdNumerique> lst = new List<CObjetDonneeAIdNumerique>();
							lst.Add(o);
							mappageCleObjets.Add(strKey, lst);
						}
						mappageObjetCle.Add(o.Id, strKey);
					}
					catch (Exception e)
					{
						result.EmpileErreur(new CErreurException(e));
						result.EmpileErreur(I.T("Error in Key formula : Element @1 (@2)|561",
							o.GetType().ToString(),
							o.Id.ToString()));
						return result;
					}
				}
				SetMappageCleObjets(sens, mappageCleObjets);
				SetMappageObjetCle(sens, mappageObjetCle);
				return result;
			}


			//MAPPAGE ENTRE UN OBJET ET SA CLE
			public Dictionary<int, string> GetMappageObjetCle(ESensCalcDifference sens)
			{
				Dictionary<int, string> m_mappage = null;
				switch (sens)
				{
					case ESensCalcDifference.DeSourceVersCible: m_mappage = m_mappObjetVSourceCle; break;
					case ESensCalcDifference.DeCibleVersSource: m_mappage = m_mappObjetVCibleCle; break;
				}
				return m_mappage;
			}
			private void SetMappageObjetCle(EOrigineVersion sens, Dictionary<int, string> dico)
			{
				switch (sens)
				{
					case EOrigineVersion.Cible: m_mappObjetVCibleCle = dico; break;
					case EOrigineVersion.Source: m_mappObjetVSourceCle = dico; break;
				}
			}
			private Dictionary<int, string> m_mappObjetVSourceCle;
			private Dictionary<int, string> m_mappObjetVCibleCle;

			//MAPPAGE ENTRE UNE CLE ET LES OBJETS CORRESPONDANT
			public Dictionary<string, List<CObjetDonneeAIdNumerique>> GetMappageCleObjets(ESensCalcDifference sens)
			{
				Dictionary<string, List<CObjetDonneeAIdNumerique>> m_mappage = null;
				switch (sens)
				{
					case ESensCalcDifference.DeSourceVersCible: m_mappage = m_mappCleObjetsVCible; break;
					case ESensCalcDifference.DeCibleVersSource: m_mappage = m_mappCleObjetsVSource; break;
				}
				return m_mappage;
			}
			private void SetMappageCleObjets(EOrigineVersion sens, Dictionary<string, List<CObjetDonneeAIdNumerique>> dico)
			{
				switch (sens)
				{
					case EOrigineVersion.Cible: m_mappCleObjetsVCible = dico; break;
					case EOrigineVersion.Source: m_mappCleObjetsVSource = dico; break;
				}
			}
			private Dictionary<string, List<CObjetDonneeAIdNumerique>> m_mappCleObjetsVSource;
			private Dictionary<string, List<CObjetDonneeAIdNumerique>> m_mappCleObjetsVCible;

		}
		#endregion

		//Liste des CAVOs déjà evalués
		private Dictionary<int, CAuditVersionObjet> m_cavosReady;
		

		//Créé les CAVOs
		/// <summary>
		/// BAdded only est vrai lors de la deuxième passe, on 
		/// ne compare que les éléments du deuxième qui n'ont pas
		/// déjà été controllés lors du passage sur la première liste
		/// </summary>
		/// <param name="listeA"></param>
		/// <param name="listeB"></param>
		/// <param name="paramType"></param>
		/// <param name="sens"></param>
		/// <param name="bAddedOnly"></param>
		/// <returns></returns>
		private CResultAErreur CreateCAVOByFormule(
			ArrayList listeA,
			ArrayList listeB, 
			CAuditVersionParametrageTypeEntite paramType, 
			ESensCalcDifference sens,
			bool bAddedOnly)
		{
			CResultAErreur result = CResultAErreur.True;
			//On croise les mappages..
			//On prend le mappage l'id de l'objet vers les cles
			//dans la version actuelle et le mappage
			//des clé vers liste d'objets dans la version cible
			Dictionary<int, string> m_mappageObjetCle = m_mappeurParCle.GetMappageObjetCle(sens);
			Dictionary<string, List<CObjetDonneeAIdNumerique>> m_mappageCleObjetsCorrespondant = m_mappeurParCle.GetMappageCleObjets(sens);

			foreach(CObjetDonneeAIdNumerique o in listeA)
			{
				CAuditVersionObjet cavo = null;
				/*SC : Ancien code : ne refaisait pas les objets déjà faits. Or c'est pas bon
				 * puisqu'on est en mode Formule, je ne vois pas comment on referais un truc déjà fait 
				 * Je pense que ce test était fait pour ne pas traiter deux fois le même
				 * objet puisqu'on lance deux fois cette fonction, mais j'ai ajouté le 
				 * flag "bAddedOnnly" pour palier à ce problème
				 * 
				 * m_mappeur.GetCAVO(o.GetType().ToString(),o.Id);
				if (cavo != null && m_cavosReady.ContainsKey(cavo.Id))
					continue;*/

				CObjetDonneeAIdNumerique oCorrespondant = null;

				string strKey = m_mappageObjetCle[o.Id];
				if (m_mappageCleObjetsCorrespondant.ContainsKey(strKey))
				{
					List<CObjetDonneeAIdNumerique> objsPoss = m_mappageCleObjetsCorrespondant[strKey];
					if (objsPoss.Count > 1)
					{
						result.EmpileErreur(I.T("Several elements of the @1 type correspond to the key @2 with the mapping formulate|562", paramType.TypeEntite.ToString(), strKey));
						return result;
					}
					else if (objsPoss.Count == 1)
						oCorrespondant = objsPoss[0];
				}
				if (bAddedOnly && o != null && oCorrespondant != null)
					continue;//Si deuxième passe et que ce n'est pas un ajout, passe au suivant

				if (sens == ESensCalcDifference.DeSourceVersCible)
					result = CreateCAVOOByComparaison(ref cavo, o, oCorrespondant, paramType);
				else
					result = CreateCAVOOByComparaison(ref cavo, oCorrespondant, o, paramType);
					
				if (cavo != null)
					m_cavosReady.Add(cavo.Id, cavo);
			}
			return result;
		}


		//Pour les mappages par Formules
		private CResultAErreur CreateCAVOOByComparaison(
			ref CAuditVersionObjet cavo,
			CObjetDonneeAIdNumerique objSrc,
			CObjetDonneeAIdNumerique objCible,
			CAuditVersionParametrageTypeEntite paramType)
		{
			CResultAErreur result = CResultAErreur.True;

			CObjetDonneeAIdNumerique obj = objSrc == null ? objCible : objSrc;
			if (obj == null)
			{
				result.EmpileErreur("Impossible d'identifier l'objet");
				return result;
			}

			//MODIFICATION CHAMP
			if (objCible != null && objSrc != null)
			{
				CreateCAVOOForModificationChamps(ref cavo, objSrc, objCible, paramType, null);
			}
			//SUPPRESSION OBJET
			else if (objCible == null && objSrc != null)
			{
				if (cavo == null)
				{
					result = GetNewCAVO(paramType, objSrc, objCible);
					if(!result)
						return result;
					cavo = (CAuditVersionObjet)result.Data;
				}

				if ( ShowEachDeletedObjetFields )
					CreateCAVOOForModificationChamps(ref cavo, objSrc, objCible, paramType, null);

				CAuditVersionObjetOperation cavoo = null;
				if (!AuditDetaille)
					cavoo = GetLastCAVOO(cavo, null);
				if (cavoo == null)
				{
					cavoo = GetNewCAVOO(cavo, null, new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Suppression), null);
				}
				else
				{
					cavoo.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Suppression);
					cavoo.NumeroOrdre = NumeroOrdreSuivant;
				}

			}
			//CREATION OBJET
			else if (objCible != null && objSrc == null)
			{
				if (cavo == null)
				{
					result = GetNewCAVO(paramType, objSrc, objCible);
					if(!result)
						return result;
					cavo = (CAuditVersionObjet)result.Data;
				}

				CAuditVersionObjetOperation cavoo = null;
				if (!AuditDetaille)
					cavoo = GetLastCAVOO(cavo, null);
				if (cavoo == null)
					cavoo = GetNewCAVOO(cavo, null, new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Ajout), null);
				else
				{
					cavoo.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Ajout);
					cavoo.NumeroOrdre = NumeroOrdreSuivant;
				}
				CreateCAVOOForModificationChamps(ref cavo, objSrc, objCible, paramType, null);
			}

			return result;
		}

		#endregion



		private CResultAErreur GetKey(CObjetDonneeAIdNumerique o, CAuditVersionParametrageTypeEntite paramType)
		{
			CResultAErreur result = CResultAErreur.True;

			CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(o);
			C2iExpression formule = null;
			string strInfoSup = "";
			if (paramType.ClesParticulieres.Count > 0)
				foreach (CAuditVersionCleParticuliere key in paramType.ClesParticulieres)
					if (key.IDsElementsDuType.Contains(((IElementATypeStructurantBase)o).IdTypeStructurant))
					{
						formule = key.FormuleCle;
						strInfoSup = I.T("Key type : @1|20007", key.Nom);
						break;
					}
			if (formule == null && paramType.FormuleCle != null)
				formule = paramType.FormuleCle;

			if (formule != null)
				result = formule.Eval(ctxEval);
			else if (!MappageParFormule)
				result.Data = o.Id.ToString();
			else
				//LA formule est null et on est en mappage par formule
				result.EmpileErreur(I.T("No formula for type @1 : @2|20009", DynamicClassAttribute.GetNomConvivial(paramType.TypeEntite), strInfoSup));

			if (!result)
				result.EmpileErreur(I.T("Error while evaluating key for entity @1 (type @2) @3|20008", o.DescriptionElement, o.TypeString, strInfoSup));

			return result;
		}



		private CResultAErreur GetNewCAVO(
			CAuditVersionParametrageTypeEntite paramType, 
			CObjetDonneeAIdNumerique objSource, 
			CObjetDonneeAIdNumerique objCible)
		{
			CResultAErreur result = CResultAErreur.True;
			CObjetDonneeAIdNumerique o = objCible != null ? objCible : objSource;
			if (o == null)
			{
				result.EmpileErreur("Impossible d'identifier l'objet");
				return result;
			}
			CAuditVersionObjet cavo = new CAuditVersionObjet(ContexteDonnee);
			cavo.CreateNewInCurrentContexte();
			cavo.AuditVersion = this;
			cavo.EmpilerVersionElement(objSource);
			cavo.EmpilerVersionElement(objCible);
			result = GetKey(o, paramType);
			if (!result)
				return result;
			cavo.Cle = result.Data.ToString();
			cavo.Description = o.DescriptionElement;
			if (paramType.FormuleDescription != null)
			{
				CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(o);
				CResultAErreur resultFormule = paramType.FormuleDescription.Eval(ctxEval);
				cavo.Description = resultFormule.Data.ToString();
			}
			m_mappeur.ReferencerCAVO(cavo);
			result.Data = cavo;
			return result;
		}
		private CAuditVersionObjetOperation GetNewCAVOO(
			CAuditVersionObjet cavo, 
			IChampPourVersion champ, 
			CTypeOperationSurObjet typeOp,
			DateTime? timeStampModification)
		{
			CAuditVersionObjetOperation cavoo = new CAuditVersionObjetOperation(ContexteDonnee);
			cavoo.CreateNewInCurrentContexte();
			cavoo.VersionObjet = cavo;
			cavoo.NumeroOrdre = NumeroOrdreSuivant;
			cavoo.TypeOperation = typeOp;
			cavoo.Champ = champ;
			cavoo.TimeStampModification = timeStampModification;
			return cavoo;
		}
		private CAuditVersionObjetOperation GetLastCAVOO(
			CAuditVersionObjet cavo, 
			IChampPourVersion champ)
		{
            //CAuditVersionObjetOperation cavoo = null;
            //foreach (CAuditVersionObjetOperation cavooTmp in cavo.Datas)
            //{
            //    if ((cavoo == null || cavoo.NumeroOrdre < cavooTmp.NumeroOrdre)
            //        && ((cavooTmp.Champ == null && champ == null) ||
            //        (cavooTmp.Champ != null && champ != null && cavooTmp.Champ.FieldKey == champ.FieldKey)))
            //    {
            //        cavoo = cavooTmp;
            //    }
            //}
            if (champ != null)
            {
                CListeObjetsDonnees listeCAVOO = cavo.Datas;
                CFiltreData filtre = new CFiltreData(CAuditVersionObjetOperation.c_champChamp + " =@1", champ.FieldKey);
                filtre.SortOrder = CAuditVersionObjetOperation.c_champNumOrdre + " desc";
                listeCAVOO.Filtre = filtre;
                int cpt = listeCAVOO.Count;
                if (listeCAVOO.Count > 0)
					return (CAuditVersionObjetOperation)listeCAVOO[0];
            }

			return null;
		}




		#region CAVOs OBSELETES (ajout puis suppression en mode non détaillé)
		//Utile dans le cas ou un objet est supprimé puis recréé dans le cas
		//d'un mappage par formule sans détail > dans ce cas l'opération de suppression
		//doit être supprimée
		private List<CAuditVersionObjet> m_cavosToDelete = new List<CAuditVersionObjet>();
		private CResultAErreur ClearCAVOsForDelete()
		{
			CResultAErreur result = CResultAErreur.True;
			if (m_cavosToDelete.Count == 0)
				return result;
			string strIds = "";
			foreach (CAuditVersionObjet cavoToDelete in m_cavosToDelete)
			{
				m_mappeur.DeleteReferencementCAVO(cavoToDelete);
				strIds += cavoToDelete.Id + ",";
			}
			strIds = strIds.Substring(0, strIds.Length - 1);
			CFiltreData filtre = new CFiltreData(CAuditVersionObjet.c_champId + " in (" + strIds + ")");
			CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CAuditVersionObjet), true);
			lst.InterditLectureInDB = true;
			lst.Filtre = filtre;
			return CObjetDonneeAIdNumerique.Delete(lst);
		}

		#endregion

		

	}


	//Stocke le champ ID d'un Type
	public static class CUtilAChampID
	{
		private static CContexteDonnee m_ctx;
		public static CContexteDonnee Contexte
		{
			get
			{
				return m_ctx;
			}
			set
			{
				m_ctx = value;
			}
		}
		private static Dictionary<string, string> m_mappTypeChampID;

		public static string GetChampID(string strType)
		{
			string strChampID;
			if (m_mappTypeChampID != null && m_mappTypeChampID.TryGetValue(strType, out strChampID))
				return strChampID;
			return GetChampID(CActivatorSurChaine.GetType(strType));
		}
		public static string GetChampID(Type type)
		{
			string strType = type.ToString();
			if (m_mappTypeChampID == null)
				m_mappTypeChampID = new Dictionary<string, string>();
			string strChampID = null;
			if (!m_mappTypeChampID.TryGetValue(strType, out strChampID))
			{
				//CContexteDonnee ctx = new CContexteDonnee(0, CSessionClient.GetSessionForIdSession(0)
				strChampID = m_ctx.GetTableSafe(CContexteDonnee.GetNomTableForType(type)).PrimaryKey[0].ColumnName;
				m_mappTypeChampID.Add(strType, strChampID);
			}
			return strChampID;
			
		}
	}
}
