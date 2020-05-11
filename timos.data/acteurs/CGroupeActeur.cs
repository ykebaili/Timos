using System;
using System.Collections;
using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using sc2i.process;

using sc2i.workflow;
using timos.data;
using timos.securite;
using tiag.client;
using timos.data.securite;
using sc2i.process.workflow;


namespace timos.acteurs
{
	/// <summary>
	/// Les Groupes d'Acteurs permettent de gérer plus efficacement les <see cref="CActeur">Acteurs</see> ayant des attributs en commun.
	/// On pourra par exemple en fonction d'un ou plusieurs Groupes: <br/>
    /// <ul>
    /// <li>Filtrer une liste d'Acteurs</li>
    /// <li>Paramétrer un Profil d'Intervenants</li>
    /// <li>Paramétrer un Profil Planificateur d'Interventions</li>
    /// <li>Définir une Action personnalisée</li>
    /// </ul><br/>
    /// Les Groupes sont hiérarchiques. Un Groupe racine peut contenir un ou plusieurs sous-Groupes. 
    /// De même qu'un Groupe peut être contenu dans plusieurs autres Groupes.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [DynamicClass("Member group")]
	[ObjetServeurURI("CGroupeActeurServeur")]
	[Table(CGroupeActeur.c_nomTable, CGroupeActeur.c_champId,true)]
	[FullTableSync]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_GroupesActeurs_ID)]
    [TiagClass(CGroupeActeur.c_nomTiag, "Id", true)]
    [AutoExec("Autoexec")]
    public class CGroupeActeur : 
		CGroupeStructurant, 
		IDefinisseurChampCustom,
        IElementAEO,
        IElementAInterfaceTiag,
        IElementDonnantDesRestrictions,
        IAffectableAEtape
        
	{
        public const string c_racineAffectationEtape = "MEMGR";

        #region Déclaration des constantes
		public const string c_nomTable = "MEMBER_GROUP";
		public const string c_champId = "MEMBER_GROUP_ID";
        public const string c_champNom = "MEMBER_GROUP_NAME";
		public const string c_champGroupeWindowsCorrespondant = "GRP_WINDOWS_MAP";
		public const string c_champGroupeMasque = "GRP_HIDE";
		public const string c_champRolesFournisseur = "GRP_SUPPLIERS_ROLE";
		public const string c_champVisibleWeb = "GRP_WEB";
		public const string c_champGroupeMessage = "GRP_MESSAGE";
		public const string c_champAdministrateur = "GRP_ADMINISTRATOR";
		public const string c_champListeDestinatairesUser = "GRP_LIST_USER_MESSAGE_ID";
		public const string c_champListeDestinatairesGroupes = "GRP_LIST_GROUP_MESSAGE_ID";
		public const string c_champRestrictionsChampsCustom = "GRP_REST_CUSTOM_FIELD";

        public const string c_nomTiag = "Member group";
		#endregion

		//-------------------------------------------------------------------
		public CGroupeActeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CGroupeActeur( System.Data.DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CAffectationsEtapeWorkflow.RegisterAffectable(c_racineAffectationEtape, typeof(CGroupeActeur));
        }

		//-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(CActeur.c_roleChampCustom);
			}
		}
		//-------------------------------------------------------------------
		public override string GetNomTable()
		{
			return c_nomTable;
		}
		//-------------------------------------------------------------------
		public override string GetChampId()
		{
			return c_champId;
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			Masquer = false;
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Description du Groupe
        /// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Members Group : @1|282",Nom);
			}
		}

		public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
		{
			CResultAErreur result = CResultAErreur.True;
			foreach (CRelationRoleActeur_GroupeActeur relRole in RelationsRoles)
			{
				if (relRole.IsNew())
				{
					CRoleActeur role = (CRoleActeur)relRole.RoleActeur;
					CStructureTable structure = CStructureTable.GetStructure(role.TypeDonneeActeur);
					CFiltreData filtre1 = new CFiltreData(
						CGroupeActeur.c_champId + " = " + Id);
					CFiltreDataAvance filtre2 = new CFiltreDataAvance(
						structure.NomTable,
						"Acteur.RelationsGroupes." + CGroupeActeur.c_champId + "=" + Id);
					CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, typeof(CRelationActeur_GroupeActeur));
					liste.Filtre = filtre1;
					int nb1 = liste.CountNoLoad;
					liste = new CListeObjetsDonnees(ContexteDonnee, relRole.RoleActeur.TypeDonneeActeur);
					liste.Filtre = filtre2;
					int nb2 = liste.CountNoLoad;
					if (nb1 != nb2)
						result.EmpileErreur(new CErreurValidation(I.T("This Group is related to '@1' Member(s) who does not have this Role. The Role will be applied to all these Members|283",(nb1 - nb2).ToString()), true));
				}
			}
			if (!result)
				return result;
			return base.VerifieDonnees(bAuMomentDeLaSauvegarde);
		}

		//-------------------------------------------------------------------
		public override CFiltreData FiltreStandard
		{
			get
			{
				return new CFiltreData ( c_champGroupeMasque+"=0", null );
			}
		}
        
		/// ///////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNom};
		}

		//-------------------------------------------------------------------
		public static CGroupeActeur FromAd ( CContexteDonnee contexte, string strIdGroupeAd )
		{
			CListeObjetsDonnees liste = new CListeObjetsDonnees(contexte, typeof(CGroupeActeur), true);
			liste.Filtre = new CFiltreData ( c_champGroupeWindowsCorrespondant+"=@1", strIdGroupeAd);
			if ( liste.Count == 1 )
			{
				return (CGroupeActeur)liste[0];
			}
			return null;
		}

		//-------------------------------------------------------------------
		public override string Libelle
		{
			get 
			{
				return Nom;
			}
			set
			{
				Nom = value;
			}
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Nom du Groupe d'Acteurs
		/// </summary>
        [TableFieldProperty(c_champNom, 255)]
		[DynamicField("Name")]
        [TiagField("Name")]
		public string Nom
		{
			get
			{
				return (string)Row[c_champNom];
			}
			set
			{
				Row[c_champNom] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Identifiant de Groupe Active Directory de Windows associé au Groupe d'Acteurs. 
        /// C'est un champ texte de 255 caractères maximum.
		/// </summary>
        /// <remarks>Se référer à l'aide de Windows pour plus d'information sur Active Directory</remarks>
        [TableFieldProperty(c_champGroupeWindowsCorrespondant, 255)]
		[DynamicField("Windows group")]
		public string IdGroupeAd
		{
			get
			{
				return ( string)Row[c_champGroupeWindowsCorrespondant];
			}
			set
			{
				Row[c_champGroupeWindowsCorrespondant] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique si ce Groupe est masqué ou non. Si un Groupe est masqué tous les Acteurs membres du Groupe seront masqués.
		/// </summary>
        [TableFieldProperty(c_champGroupeMasque)]
		[DynamicField("Hide")]
        [TiagField("Hide")]
		public bool Masquer
		{
			get
			{
				return (bool)Row[c_champGroupeMasque];
			}
			set
			{
				Row[c_champGroupeMasque] = value;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationGroupeActeur_ChampCustom">relations vers les Champs personnalisés</see>
        /// </summary>
		[RelationFille(typeof(CRelationGroupeActeur_ChampCustom), "Definisseur")]
		[DynamicChilds("Custom fields relations", typeof(CRelationGroupeActeur_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe(CRelationGroupeActeur_ChampCustom.c_nomTable, CGroupeActeur.c_champId);
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationGroupeActeur_Formulaire">relations vers les formulaires personnalisés</see>
        /// </summary>
		[RelationFille(typeof(CRelationGroupeActeur_Formulaire), "Definisseur")]
		[DynamicChilds("Forms relations", typeof(CRelationGroupeActeur_Formulaire))]
		public override CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return  GetDependancesListe(CRelationGroupeActeur_Formulaire.c_nomTable, CGroupeActeur.c_champId);
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationRoleActeur_GroupeActeur">relations vers les Rôles associés au Groupe d'Acteurs</see>
        /// </summary>
		[RelationFille(typeof(CRelationRoleActeur_GroupeActeur), "GroupeActeur")]
		[DynamicChilds("Relations roles", typeof(CRelationRoleActeur_GroupeActeur))]
		public CListeObjetsDonneesContenus RelationsRoles
		{
			get
			{
				return  GetDependancesListe(CRelationRoleActeur_GroupeActeur.c_nomTable, CGroupeActeur.c_champId);
			}
		}
		
        //-------------------------------------------------------------------
        public bool HasRole( CRoleActeur role )
		{
			CFiltreData filtre = new CFiltreData(
				"CodeRole = @1",
				role.CodeRole);
			CListeObjetsDonnees liste = RelationsRoles;
			liste.Filtre = filtre;
			return (liste.Count> 0);
		}
		
        //-------------------------------------------------------------------
		public CRoleActeur[] GetRoles()
		{
			ArrayList tableRoles = new ArrayList();
			foreach(CRelationRoleActeur_GroupeActeur rel in RelationsRoles)
				if (! tableRoles.Contains(rel.RoleActeur))
					tableRoles.Add(rel.RoleActeur);

			return (CRoleActeur[]) tableRoles.ToArray( typeof(CRoleActeur) );
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationActeur_GroupeActeur">Relations vers les Acteurs membres du Groupe</see>
        /// </summary>
		[RelationFille(typeof(CRelationActeur_GroupeActeur), "GroupeActeur")]
		[DynamicChilds("Member Relations", typeof(CRelationActeur_GroupeActeur))]
		public CListeObjetsDonnees RelationsActeur
		{
			get
			{
				return GetDependancesListe ( CRelationActeur_GroupeActeur.c_nomTable,
					CGroupeActeur.c_champId );
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Indique si un acteur fait partie du groupe
        /// </summary>
        /// <param name="acteur"></param>
        /// <returns>VRAI si l'Acteur est fait partie du groupe</returns>
        public bool HasMembreActeur(CActeur acteur)
        {
            foreach (CRelationActeur_GroupeActeur rel in RelationsActeur)
            {
                if (rel.Acteur == acteur)
                    return true;
            }
            return false;
        }

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationGroupeActeur_GroupeActeur">relations vers tous les Groupes contenants</see>
        /// </summary>
		[RelationFille(typeof(CRelationGroupeActeur_GroupeActeur), "GroupeActeurContenant")]
		[DynamicChilds("All container groups relations", typeof(CRelationGroupeActeur_GroupeActeur))]
		public override CListeObjetsDonnees RelationsTousGroupesContenants
		{
			get
			{
				return GetDependancesListe ( CRelationGroupeActeur_GroupeActeur.c_nomTable,
					CRelationGroupeActeur_GroupeActeur.c_champIdGroupeContenu );
			}
		}

		//-------------------------------------------------------------------
		public override CListeObjetsDonnees RelationsGroupesContenantsDirects
		{
			get
			{
				CListeObjetsDonnees liste = RelationsTousGroupesContenants;
				liste.Filtre = new CFiltreData(CRelationGroupeActeur_GroupeActeur.c_champIdRelationSourceFille+" is null");
				return liste;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationGroupeActeur_GroupeActeur">relations vers tous les Groupes contenus</see>
        /// </summary>
		[RelationFille(typeof(CRelationGroupeActeur_GroupeActeur), "GroupeActeurContenu")]
		[DynamicChilds("All included groups relations", typeof(CRelationGroupeActeur_GroupeActeur))]
		public override CListeObjetsDonnees RelationsTousGroupesContenus
		{
			get
			{
				return GetDependancesListe ( CRelationGroupeActeur_GroupeActeur.c_nomTable, 
					CRelationGroupeActeur_GroupeActeur.c_champIdGroupeContenant );
			}
		}

		//-------------------------------------------------------------------
		public override CListeObjetsDonnees RelationsGroupesContenusDirects
		{
			get
			{
				CListeObjetsDonnees liste = RelationsTousGroupesContenus;
				liste.Filtre = new CFiltreData(CRelationGroupeActeur_GroupeActeur.c_champIdRelationSourceFille+" is null");
				return liste;
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Liste des <see cref="CRelationGroupeActeurNecessite">relations vers les Groupes Nécessaires à ce groupe</see>
        /// Un groupe nécessaire est un groupe auquel le groupe courant est rattaché hiérarchiquement
        /// </summary>
		[RelationFille(typeof(CRelationGroupeActeurNecessite), "GroupeActeurNecessaire")]
		[DynamicChilds("Necessary groups relations", typeof(CRelationGroupeActeurNecessite))]
		public override CListeObjetsDonnees RelationsGroupesNecessaires
		{
			get
			{
				return  GetDependancesListe(CRelationGroupeActeurNecessite.c_nomTable, CRelationGroupeActeurNecessite.c_champIdGroupeNecessitant );
			}
		}
		//-------------------------------------------------------------------
		/// <summary>
        /// Liste des <see cref="CRelationGroupeActeurNecessite">relations vers les Groupes Requérant ce groupe</see>
		/// </summary>
		[RelationFille(typeof(CRelationGroupeActeurNecessite), "GroupeActeurNecessitant")]
		[DynamicChilds("Requiring groups relations", typeof(CRelationGroupeActeurNecessite))]
		public override CListeObjetsDonnees RelationsGroupesNecessitants
		{
			get
			{
				return  GetDependancesListe(CRelationGroupeActeurNecessite.c_nomTable, CRelationGroupeActeurNecessite.c_champIdGroupeNecessaire);
			}
		}
		//-------------------------------------------------------------------
		public override Type TypeRelationNecessaire
		{
			get
			{
				return typeof (CRelationGroupeActeurNecessite);
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Indique si le groupe permet le paramétrage de pages sur le WEB
		/// </summary>
		[TableFieldProperty(c_champVisibleWeb)]
		[DynamicField("Web visible")]
        [TiagField("Web visible")]
		public bool VisibleSurWeb
		{
			get
			{
				return (bool)Row[c_champVisibleWeb];
			}
			set
			{
				Row[c_champVisibleWeb] = value;
			}
		}

		

		/// //////////////////////////////////////////
		public string NomDestinataireMessage
		{
			get
			{
				return "*"+Libelle;
			}
		}

		
        //------------------------------------------------------------------------------------
		/// <summary>
		/// Indique si les Acteurs de ce groupe sont des administrateurs de l'application
		/// </summary>
		[TableFieldProperty(c_champAdministrateur)]
		[DynamicField("Is administrator")]
        [TiagField("Is administrator")]
		public bool IsAdministrateur
		{
			get
			{
				return ( bool )Row[c_champAdministrateur];
			}
			set
			{
				Row[c_champAdministrateur] = value;
			}
		}

		
        #region IElementAEO Membres

        //-------------------------------------------------------------------
        /// <summary>
        /// Listes des codes d'entités opérationnelles auquel est affecté cet élément
        /// </summary>
        [TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
        [DynamicField("Organisational entities codes")]
        public string CodesEntitesOrganisationnelles
        {
            get
            {
                return (string)Row[CUtilElementAEO.c_champEO];
            }
            set
            {
                Row[CUtilElementAEO.c_champEO] = value;
            }
        }

        public IElementAEO[] DonnateursEO
        {
            get 
            {
                return null;
            }
        }

        public IElementAEO[] HeritiersEO
        {
            get
            {
                ArrayList liste = new ArrayList();
                foreach (CRelationActeur_GroupeActeur rel in RelationsActeur)
                {
                    liste.Add(rel.Acteur);
                }
                return (IElementAEO[])liste.ToArray(typeof(CActeur));
            }
        }

		//-----------------------------------------------------------------
		public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
		{
			get
			{
				return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this);
			}
		}

        //-----------------------------------------------------------------
        [DynamicMethod(
            "Assign a new Organizational Entity to the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organizational Entity from the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //----------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

        #endregion

        #region IObjetARestrictionSurEntite Membres

        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction(this, restriction);
        }

        #endregion

        #region IElementAInterfaceTiag Membres

        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }


        #endregion

        #region IAffectableAEtape Membres

        public string RacineCleAffectationWorkflow
        {
            get { return c_racineAffectationEtape; }
        }

        #endregion

        /// <summary>
        /// Retourne la liste des étapes de workflow en cours affectées à cet utilisateur
        /// </summary>
        /// <returns></returns>
        [DynamicChilds("Current affected workflow steps", typeof(CEtapeWorkflow))]
        public CListeObjetsDonnees EtapesWorkflowEnCours
        {
            get
            {
                return GetEtapeWorkflowsEnCours();
            }
        }

        //-----------------------------------------------------------------
        public CListeObjetsDonnees GetEtapeWorkflowsEnCours()
        {
            CFiltreData filtre = new CFiltreData(CEtapeWorkflow.c_champEtat + "=@1",
                (int)EEtatEtapeWorkflow.Démarrée);

            string strCode = CAffectationsEtapeWorkflow.GetCleAffectation(this);
            CFiltreData filtreAss = new CFiltreData(
                CEtapeWorkflow.c_champAffectations + " like @1",
                "%~" + strCode + "~%");
            
            filtre = CFiltreData.GetAndFiltre(filtre, filtreAss);

            CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CEtapeWorkflow), filtre);
            return lst;
        }

    }
}
