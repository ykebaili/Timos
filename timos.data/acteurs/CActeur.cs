using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using tiag.client;

using timos.data;
using timos.securite;
using timos.data.securite;
using sc2i.process.workflow;
using timos.data.equipement.consommables;

namespace timos.acteurs
{
	/// <summary>
	/// L'Acteur modélise toute personne physique ou morale ayant un rôle dans l'application<br/>
    /// Les Acteurs peuvent être organisés par <see cref="CGroupeActeur">Groupe</see>. On peut aussi 
    /// leur attribuer un ou plusieurs rôles prédéfinis. Le rôle d'un Acteur représente une spécialisation 
    /// et lui donne des attributs et des comportements supplémentaires.
	/// <br/>
    /// Les Rôles prédéfinis sont les suivants: <br/>
	/// <list type="bullet">
	///		<item><term><see cref="CDonneesActeurUtilisateur">Utilisateur</see></term></item>
	///		<item><term><see cref="CDonneesActeurClient">Client</see></term></item>
	///		<item><term><see cref="CDonneesActeurConstructeur">Fournisseur</see></term></item>
	///		<item><term><see cref="CDonneesActeurFournisseur">Constructeur</see></term></item>
	/// </list>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [ObjetServeurURI("CActeurServeur")]
	[Table(CActeur.c_nomTable, CActeur.c_champId,true)]
	[AutoExec("Autoexec")]
	[FullTableSync]
	[DynamicClass("Members")]
	[TiagClass(CActeur.c_nomTiag,"Id", true)]
	[Evenement( CActeur.c_evenementValidationFicheActivite,
		"Validation fiche activité", 
		"Se déclenche lorsqu'une fiche d'activité est validée pour l'acteur")]
	public class CActeur : CObjetDeGroupe, 
		                        IElementAAgenda, 
                                IElementAIdentificationCourteAgenda,
		                        IObjetALectureTableComplete,
		                        IElementAEO,
		                        IEmplacementEquipement,
                                IPossesseurRessource,
								IObjetDonneeAutoReference,
								IRessourceEntreePlanning,
								IElementAInterfaceTiag,
                                IElementLigneDeTableauPlanning,
                                IElementDataDeTableauPlanning,
                                IElementDonnantDesRestrictions,
                                IAffectableAEtape
	{
		public const string c_roleChampCustom = "MEMBER";

		public const string c_evenementValidationFicheActivite = "VALID_ACTIVITY";

		public const string c_nomTiag = "Members";

        public const string c_racineAffectationEtape = "MEM";

		#region Déclaration des constantes
		public const string c_nomTable = "MEMBER";
		public const string c_champId = "MEMBER_ID";
		public const string c_champNom = "MEMBER_NAME";
        public const string c_champPrenom = "MEMBER_FIRSTNAME";
        public const string c_champAdresse = "MEMBER_ADRESS";
        public const string c_champCodePostal = "MEMBER_POSTCODE";
        public const string c_champVille = "MEMBER_COUNTRY";
        public const string c_champTelephone1 = "MEMBER_TEL1";
        public const string c_champTelephone2 = "MEMBER_TEL2";
        public const string c_champTelephone3 = "MEMBER_TEL3";
        public const string c_champPortable = "MEMBER_MOB_PHONE";
        public const string c_champFax = "MEMBER_FAX";
        public const string c_champSiteWeb = "MEMBER_WEBSITE";
        public const string c_champEMail = "MEMBER_EMAIL";
        public const string c_champCommentaires = "MEMBER_COMMENTS";
        public const string c_champInactif = "MEMBER_DISABLE";
        public const string c_champIdActeurParent = "MEMBER_PARENT_ID";
		public const string c_champDatas = "MEMBER_DATA";
		#endregion

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Members", typeof(CActeur), typeof(CGroupeActeur));
            CAffectationsEtapeWorkflow.RegisterAffectable(c_racineAffectationEtape, typeof(CActeur));

		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }


		//-------------------------------------------------------------------
#if PDA
		public CActeur()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CActeur( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CActeur( System.Data.DataRow row )
			:base(row)
		{
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
			Row[c_champDatas] = 0;
		}
		//-------------------------------------------------------------------
        /// <summary>
        /// Decription de l'Acteur
        /// </summary>
		public override string DescriptionElement
		{
			get
			{
                return IdentiteComplete;
			}
		}

        /// <summary>
		/// Utilisé par TIAG pour affecter l'acteur parent par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetParentMemberKeys(object[] lstCles)
		{
			CActeur acteur = new CActeur(ContexteDonnee);
			if (acteur.ReadIfExists(lstCles))
				ActeurParent = acteur;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne l'acteur parent s'il y en a un.
		/// </summary>
		[Relation ( 
			CActeur.c_nomTable,
			CActeur.c_champId,
			CActeur.c_champIdActeurParent,
			false,
			false,
			true)]
		[DynamicField("Parent member")]
		[TiagRelation(typeof(CActeur), "TiagSetParentMemberKeys")]
		public CActeur ActeurParent
		{
			get
			{
				return ( CActeur)GetParent ( CActeur.c_champIdActeurParent, typeof(CActeur) );
			}
			set
			{
				SetParent(CActeur.c_champIdActeurParent, value);
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Taux horaire de l'agent (utilisé pour les calculs de cout des interventions)
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            false,
            false,
            false)]
        [DynamicField("Hourly rate")]
        public CTypeConsommable TauxHoraire
        {
            get
            {
                return (CTypeConsommable)GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable));
            }
            set
            {
                SetParent(CTypeConsommable.c_champId, value);
            }
        }

        //-------------------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des acteurs enfants
		/// </summary>
		[RelationFille ( typeof(CActeur), "ActeurParent")]
		[DynamicChilds ("Members", typeof( CActeur ))]
		public CListeObjetsDonnees Acteurs
		{
			get
			{
				return GetDependancesListe ( CActeur.c_nomTable, c_champIdActeurParent );
			}
		}

		//-------------------------------------------------------------------
		public bool IsChildOf(CActeur parent)
		{
			if (this.Equals(parent))
				return true;
			if (ActeurParent != null)
			{
				if (ActeurParent.Equals(parent))
					return true;
				return ActeurParent.IsChildOf(parent);
			}
			return false;
		}

		//-------------------------------------------------------------------
		public bool IsParentOf(CActeur acteur)
		{
			if (acteur != null)
				return acteur.IsChildOf(this);
			return false;
		}

				

		//-------------------------------------------------------------------
		/// <summary>
		/// Identité complete : Nom + Prénom
		/// </summary>
		[DynamicField("Identity")]
        [DescriptionField]
        public string IdentiteComplete
        {
            get
            {
                if (Row[c_champNom] == DBNull.Value || Row[c_champPrenom] == DBNull.Value)
                    return "";
                string strVal = Nom;
                if (Prenom != "")
                    strVal = Prenom + " " + Nom;
                return strVal;
            }
        }
		//-------------------------------------------------------------------
		/// <summary>
		/// Identite complete ameliorée : Civilité + Nom + Prénom
		/// </summary>
		[DynamicField("Identity and civilty")]
		public string IdentiteCompleteAmelioree
		{
			get
			{
				if (Civilite==null)
					return IdentiteComplete;
				else
					return Civilite.Libelle+" "+IdentiteComplete;
			}
		}
		//-------------------------------------------------------------------
		public override string ToString()
		{
			return this.IdentiteComplete;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champNom};
		}

		//-------------------------------------------------------------------
		public override CResultAErreur VerifieDonnees(bool bAuMomentDeLaSauvegarde)
		{
			CResultAErreur result = CResultAErreur.True;
			if (!IsUnique(this, CActeur.c_champNom, Nom))
				result.EmpileErreur(new CErreurValidation(I.T("Member @1 already exists|278",Nom), true));
			if (Utilisateur != null)
				result = Utilisateur.VerifieDonnees(bAuMomentDeLaSauvegarde);
			if (!result)
				return result;
			
			return base.VerifieDonnees(bAuMomentDeLaSauvegarde);
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la donnée du role demandée (si elle existe) avec possibilité de rôle
		/// Invalide
		/// </summary>
		/// <param name="role"></param>
		/// <param name="bMemeInvalide"></param>
		/// <returns></returns>
		public CDonneesActeur GetDonneesRole(CRoleActeur role, bool bMemeInvalide)
		{
			if (role == null)
				return null;
			CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee);

			string strNomTable = CContexteDonnee.GetNomTableForType(role.TypeDonneeActeur);
			liste = GetDependancesListe(strNomTable,!bMemeInvalide,CActeur.c_champId);
			if (liste.Count > 0)
				return (CDonneesActeur)liste[0];
			else
				return null;
		}

		//-------------------------------------------------------------------
		public CDonneesActeur GetDonneesRole ( string strCodeRole, bool bMemeInvalide )
		{
			return GetDonneesRole ( CRoleActeur.GetRole ( strCodeRole ), bMemeInvalide );
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la donnée valide associée au rôle (non retourné si la donnée n'est pas valide)
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public CDonneesActeur GetDonneesRole ( CRoleActeur role )
		{
			return GetDonneesRole ( role, false );
		}

		//-------------------------------------------------------------------
		/// <summary>
		///Retourne vrai si l'acteur a le role demandé, avec possibilité de rôle invalide
		/// </summary>
		/// <param name="role"></param>
		/// <param name="bMemeInvalide"></param>
		/// <returns></returns>
		public bool HasRole(CRoleActeur role, bool bMemeInvalide)
		{
			string strNomTable = CContexteDonnee.GetNomTableForType(role.TypeDonneeActeur);
			CListeObjetsDonnees liste = GetDependancesListe(strNomTable,!bMemeInvalide, CActeur.c_champId);
			return (liste.Count> 0);
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne true si le acteur est dans le rôle demandé (avec données valides)
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		public bool HasRole ( CRoleActeur role )
		{
			return HasRole ( role, false );
		}


		/// <summary>
		/// Le Nom de l'Acteur. Ce champ est le seul champ obligatoire de l'Acteur. Le nom de l'Acteur est unique.
		/// </summary>
		[TableFieldProperty(c_champNom, 255),DynamicField("Name")]
		[RechercheRapide]
		[TiagField("Name")]
		public override string Nom
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

		/// <summary>
		/// Le Prenom de l'Acteur
		/// </summary>
		[TableFieldProperty(c_champPrenom, 255),DynamicField("First name")]
		[RechercheRapide]
		[TiagField("First name")]
		public string Prenom
		{
			get
			{
				return (string)Row[c_champPrenom];
			}
			set
			{
				Row[c_champPrenom] = value;
			}
		}

		/// <summary>
		/// L'Adresse de l'Acteur
		/// </summary>
		[TableFieldProperty(c_champAdresse, 255),DynamicField("Adress")]
		[TiagField("Adress")]
		public string Adresse
		{
			get
			{
				return (string)Row[c_champAdresse];
			}
			set
			{
				Row[c_champAdresse] = value;
			}
		}

		/// <summary>
		/// Le Code Postal
		/// </summary>
		[TableFieldProperty(c_champCodePostal, 255),DynamicField("Postal code")]
		[TiagField("Postal code")]
		public string CodePostal
		{
			get
			{
				return (string)Row[c_champCodePostal];
			}
			set
			{
				Row[c_champCodePostal] = value;
			}
		}

		/// <summary>
		/// La Ville
		/// </summary>
		[TableFieldProperty(c_champVille, 255), DynamicField("Town")]
		[TiagField("Town")]
		public string Ville
		{
			get
			{
				return (string)Row[c_champVille];
			}
			set
			{
				Row[c_champVille] = value;
			}
		}

		/// <summary>
		/// Telephone 1
		/// </summary>
		[TableFieldProperty(c_champTelephone1, 255), DynamicField("Phone 1")]
		[AccesDirectInterdit]
		[TiagField("Phone 1")]
		public string Telephone1
		{
			get
			{
				return CUtilTelephone.GetValeurAffichage( (string)Row[c_champTelephone1] );
			}
			set
			{
				Row[c_champTelephone1] = CUtilTelephone.GetValeurStockage(value);
			}
		}
		/// <summary>
		/// Telephone 2
		/// </summary>
		[TableFieldProperty(c_champTelephone2, 255), DynamicField("Phone 2")]
		[AccesDirectInterdit]
		[TiagField("Phone 2")]
		public string Telephone2
		{
			get
			{
				return CUtilTelephone.GetValeurAffichage( (string)Row[c_champTelephone2]);
			}
			set
			{
				Row[c_champTelephone2] = CUtilTelephone.GetValeurStockage(value);
			}
		}
		/// <summary>
		/// Telephone 3
		/// </summary>
		[TableFieldProperty(c_champTelephone3, 255), DynamicField("Phone 3")]
		[AccesDirectInterdit]
		[TiagField("Phone 3")]
		public string Telephone3
		{
			get
			{
				return CUtilTelephone.GetValeurAffichage( (string)Row[c_champTelephone3]);
			}
			set
			{
				Row[c_champTelephone3] = CUtilTelephone.GetValeurStockage(value);
			}
		}
		/// <summary>
		/// Telephone Mobile
		/// </summary>
		[TableFieldProperty(c_champPortable, 255),DynamicField("Mobile")]
		[AccesDirectInterdit]
		[TiagField("Mobile")]
		public string Portable
		{
			get
			{
				return CUtilTelephone.GetValeurAffichage( (string)Row[c_champPortable]);
			}
			set
			{
				Row[c_champPortable] = CUtilTelephone.GetValeurStockage(value);
			}
		}
		/// <summary>
		/// Numero de fax
		/// </summary>
		[TableFieldProperty(c_champFax, 255), DynamicField("Fax")]
		[AccesDirectInterdit]
		[TiagField("Fax")]
		public string Fax
		{
			get
			{
				return CUtilTelephone.GetValeurAffichage( (string)Row[c_champFax]);
			}
			set
			{
				Row[c_champFax] = CUtilTelephone.GetValeurStockage(value);
			}
		}
		/// <summary>
		/// Adresse du Site Internet
		/// </summary>
		[TableFieldProperty(c_champSiteWeb, 255), DynamicField("Web site")]
		[TiagField("Web site")]
		public string SiteWeb
		{
			get
			{
				return (string)Row[c_champSiteWeb];
			}
			set
			{
				Row[c_champSiteWeb] = value;
			}
		}

		/// <summary>
		/// Adresse Mail. Champ texte de 255 carcatères maximum
		/// </summary>
		[TableFieldProperty(c_champEMail, 255),	DynamicField("Mail")]
		[TiagField("Mail")]
		public string EMail
		{
			get
			{
				return (string)Row[c_champEMail];
			}
			set
			{
				Row[c_champEMail] = value;
			}
		}

		/// <summary>
		/// Champ de commentaires de 1000 caractères maximum
		/// </summary>
		[TableFieldProperty(c_champCommentaires, 1000)]
		[DynamicField("Comment")]
		[TiagField("Comment")]
		public string Commentaires
		{
			get
			{
				return (string)Row[c_champCommentaires];
			}
			set
			{
				Row[c_champCommentaires] = value;
			}
		}


        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquelles est affecté l'acteur<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
		[TableFieldProperty ( CUtilElementAEO.c_champEO, 500 )]
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

        //-------------------------------------------------------------------
        /// <summary>
        /// Rafraîchit les codes des entités organisationnelles de cet élément
        /// </summary>
        [DynamicMethod("Refresh Organizational entities codes for this element")]
        public void RefreshOECodes()
        {
            CUtilElementAEO.UpdateEOs(this);
        }

		//-------------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get
			{
				List<IElementAEO> lst = new List<IElementAEO>();
				if (ActeurParent != null)
					lst.Add(ActeurParent);
				foreach (CGroupeActeur groupe in TousLesGroupesActeur)
					lst.Add(groupe);

				//Ajoute les eos planifiées
				CListeObjetsDonnees lstPlanif = new CListeObjetsDonnees(ContexteDonnee, typeof(CEOplanifiee_Acteur));
				lstPlanif.Filtre = new CFiltreDataAvance(CEOplanifiee_Acteur.c_nomTable,
					CActeur.c_champId + "=@1 and " +
					CEOplanifiee_Acteur.c_champDate + ">=@2 and " +
					CEOplanifiee_Acteur.c_champDate + "<@3 and " +
					CHoraireJournalier_Tranche.c_nomTable + "." +
					CHoraireJournalier_Tranche.c_champHeureDebut + "<=@4 and (" +
					CHoraireJournalier_Tranche.c_nomTable + "." +
					CHoraireJournalier_Tranche.c_champHeureFin + ">=@4 OR " +
                    CHoraireJournalier_Tranche.c_nomTable + "." +
                    CHoraireJournalier_Tranche.c_champHeureFin + " < " + 
                    CHoraireJournalier_Tranche.c_nomTable + "." +
                    CHoraireJournalier_Tranche.c_champHeureDebut + ")",
                    Id,
					DateTime.Now.Date,
					DateTime.Now.AddDays(1).Date,
					DateTime.Now.Hour*60 + DateTime.Now.Minute);
				lstPlanif.PreserveChanges = true;
				lstPlanif.AssureLectureFaite();
				//Filtre maintenant avec un RowFilter pour prendre tout ce qui est dans
				//le contexte courant, y compris les éléments qui viennent d'être créés
			
				//Trouve la relation
				DataRelation relToHoraires = null;
				foreach (DataRelation relation in Table.ChildRelations)
				{
					if (relation.ChildTable.TableName == CHoraireJournalier_Tranche.c_nomTable)
					{
						relToHoraires = relation;
						break;
					}
				}
				if (relToHoraires != null)
				{
					CFiltreData filtre = new CFiltreData(
						CEOplanifiee_Acteur.c_champDate + ">=@2 and " +
						CEOplanifiee_Acteur.c_champDate + "<@3 and " +
						"childs(" + relToHoraires.RelationName + ")."+
						CHoraireJournalier_Tranche.c_champHeureDebut + "<=@4 and (" +
						"childs(" + relToHoraires.RelationName + ")." +
						CHoraireJournalier_Tranche.c_champHeureFin + ">=@4 OR ",
                        "childs(" + relToHoraires.RelationName + ")." +
                        CHoraireJournalier_Tranche.c_champHeureFin + " < " +
                        "childs(" + relToHoraires.RelationName + ")." +
                        CHoraireJournalier_Tranche.c_champHeureDebut + ")",
                        Id,
						DateTime.Now.Date,
						DateTime.Now.AddDays(1).Date,
						DateTime.Now.Hour * 60 + DateTime.Now.Minute);
					lstPlanif.Filtre = filtre;
					lstPlanif.InterditLectureInDB = true;
				}
				foreach (IElementAEO elt in lstPlanif)
					lst.Add(elt);

					
				return lst.ToArray();
			}
		}

		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				List<IElementAEO> lst = new List<IElementAEO>();
				foreach (CRessourceMaterielle ressource in RessourcesDetenues)
					lst.Add(ressource);
				return lst.ToArray();
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
        /// <summary>
        /// Attribue une nouvelle entité organisationnelle à l'élément
        /// </summary>
        /// <param name="nIdEO">Id de l'entité organisationnelle</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Asigne a new Organizational Entity to the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Ote de l'élément une entité organisationnelle
        /// </summary>
        /// <param name="nIdEO">Id de l'entité à enlever</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Remove an Organizational Entity from the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }

        //----------------------------------------------------------------
        /// <summary>
        /// Positionne toutes les entités organisationnelles de l'élément
        /// </summary>
        /// <param name="nIdsOE">Tableau d'Id des entités organisationnelles à associer</param>
        /// <returns>retourne le <see cref="CResultAErreur">résultat</see></returns>
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

		//-------------------------------------------------------------------
		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CUtilElementAEO.CompleteRestriction(this, restriction);
		}

        /// <summary>
		/// Utilisé par TIAG pour affecter l'acteur parent par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetCivilityKey(object[] lstCles)
		{
			CCivilite civ = new CCivilite(ContexteDonnee);
			if (civ.ReadIfExists(lstCles))
				Civilite = civ;
		}
			
		/// <summary>
		/// Civilité (M., Mme, Ste ...)
		/// </summary>
		[Relation(CCivilite.c_nomTable, CCivilite.c_champId, CCivilite.c_champId, false, false )]
		[DynamicField("Civility")]
		[TiagRelation(typeof(CCivilite), "TiagSetCivilityKey")]
		public CCivilite Civilite
		{
			get
			{
				return (CCivilite)GetParent ( CCivilite.c_champId, typeof(CCivilite));
			}
			set
			{
				SetParent ( CCivilite.c_champId, value );
			}
		}
		
		/// <summary>
		/// Liste des relations vers les Groupes dont l'Acteur fait partie.
		/// </summary>
		[RelationFille(typeof(CRelationActeur_GroupeActeur), "Acteur")]
		[DynamicChilds("Groups relations", typeof(CRelationActeur_GroupeActeur))]
		public override CListeObjetsDonnees RelationsGroupes
		{
			get
			{
				return  GetDependancesListe(CRelationActeur_GroupeActeur.c_nomTable, CActeur.c_champId);
			}
		}

		/// <summary>
		/// Type de Groupe
		/// </summary>
		public override Type TypeGroupe
		{
			get
			{
				return  typeof(CGroupeActeur);
			}
		}

		//-------------------------------------------------------------------
		public override string GetChampIdGroupe()
		{
			return CGroupeActeur.c_champId;
		}
		//-------------------------------------------------------------------
		public override IRelationGroupe GetNewRelation()
		{
			return new CRelationActeur_GroupeActeur(this.ContexteDonnee);
		}
		//-------------------------------------------------------------------
		/*
		public CGroupeActeur[] HierarchieGroupes
		{
			get
			{
				Hashtable table = new Hashtable();
				foreach ( CRelationActeur_GroupeActeur rel in RelationsGroupes )
				{
					rel.GroupeActeur.StockeIdGroupesContenantsInArray ( table );
				}
				CGroupeActeur[] listeGroupes = new CGroupeActeur[table.Count];
				int n = 0;
				foreach ( int nId in table.Keys )
				{
					CGroupeActeur groupe = new CGroupeActeur(ContexteDonnee);
					groupe.Id = nId;
					listeGroupes[n] = groupe;
					n++;
				}
				return listeGroupes;
			}
		}
		*/
		//-------------------------------------------------------------------
		public override IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return (IDefinisseurChampCustom[])TousLesGroupes().ToArray(typeof(IDefinisseurChampCustom));
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationActeur_ChampCustom(ContexteDonnee);
		}

		/// <summary>
        ///Liste des <see cref="CRelationActeur_ChampCustom">relations vers les Champs personnalisés</see>
		/// </summary>
		[RelationFille(typeof(CRelationActeur_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom field relations", typeof(CRelationActeur_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe ( CRelationActeur_ChampCustom.c_nomTable, GetChampId() );
			}
		}
		
		

		//-------------------------------------------------------------------
		public CListeRelationsEntreeAgenda RelationsEntreeAgenda
		{
			get
			{
				return new CListeRelationsEntreeAgenda(this);
			}
		}

		//-------------------------------------------------------------------
		public string Libelle
		{
			get
			{
				return IdentiteComplete;
			}
		}


		/// <summary>
		/// Liste des <see cref="CDonneesActeurUtilisateur">Utilisateurs de l'application</see>
		/// </summary>
		[RelationFille(typeof(CDonneesActeurUtilisateur), "Acteur")]
		[DynamicChilds("User data", typeof(CDonneesActeurUtilisateur),"Système")]
		public CListeObjetsDonnees DonneesUtilisateur
		{
			get
			{
				return GetDependancesListe(CDonneesActeurUtilisateur.c_nomTable, c_champId);
			}
		}

		
		/// <summary>
		/// Liste des <see cref="CDonneesActeurClient">Clients</see>
		/// </summary>
		[RelationFille(typeof(CDonneesActeurClient), "Acteur")]
		[DynamicChilds("Client data", typeof(CDonneesActeurClient),"Système")]
		public CListeObjetsDonnees DonneesClient
		{
			get
			{
				return GetDependancesListe(CDonneesActeurClient.c_nomTable, c_champId);
			}
		}
		
        /// <summary>
        /// Liste des <see cref="CDonneesActeurFournisseur">Fournisseurs</see>
        /// </summary>
		[RelationFille(typeof(CDonneesActeurFournisseur), "Acteur")]
		[DynamicChilds("Supplier data", typeof(CDonneesActeurFournisseur), "Système")]
		public CListeObjetsDonnees DonneesFournisseur
		{
			get
			{
				return GetDependancesListe(CDonneesActeurFournisseur.c_nomTable, c_champId);
			}
		}

        /// <summary>
        /// Liste des <see cref="CDonneesActeurConstructeur">Constructeurs</see>
        /// </summary>
        [RelationFille(typeof(CDonneesActeurConstructeur), "Acteur")]
        [DynamicChilds("Manufacturer data", typeof(CDonneesActeurConstructeur), "Système")]
        public CListeObjetsDonnees DonneesConstructeur
        {
            get
            {
                return GetDependancesListe(CDonneesActeurConstructeur.c_nomTable, c_champId);
            }
        }

        /// <summary>
        /// Retourne l'<see cref="CDonneesActeurUtilisateur">Utilisateur de l'application</see> si l'Acteur a ce rôle.
        /// </summary>
		[DynamicField("User", "Member specialization")]
		public CDonneesActeurUtilisateur Utilisateur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetDonneesRole(CDonneesActeurUtilisateur.c_codeRole, false);
			}
		}

		/// <summary>
        /// Retourne le <see cref="CDonneesActeurClient">Client</see> si l'Acteur a ce rôle.
        /// </summary>
		[DynamicField("Client", "Member specialization")]
		public CDonneesActeurClient Client
		{
			get
			{
				return (CDonneesActeurClient)GetDonneesRole(CDonneesActeurClient.c_codeRole, false);
			}
		}

		/// <summary>
        /// Retourne le <see cref="CDonneesActeurFournisseur">Fournisseur</see> si l'Acteur a ce rôle.
        /// </summary>
		[DynamicField("Supplier", "Member specialization")]
		public CDonneesActeurFournisseur Fournisseur
		{
			get
			{
				return (CDonneesActeurFournisseur)GetDonneesRole(CDonneesActeurFournisseur.c_codeRole, false);
			}
		}

        /// <summary>
        /// Retourne le <see cref="CDonneesActeurConstructeur">Constructeur</see> si l'Acteur a ce rôle.
        /// </summary>
		[DynamicField("Manufacturer", "Member specialization")]
        public CDonneesActeurConstructeur Constructeur
        {
            get
            {
                return (CDonneesActeurConstructeur)GetDonneesRole(CDonneesActeurConstructeur.c_codeRole, false);
            }
        }

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne les <see cref="CGroupeActeur">groupes d'acteurs</see> auxquels l'acteur appartient
        /// </summary>
		[DynamicField("Member group")]
		public CGroupeActeur[] TousLesGroupesActeur
		{
			get
			{
				return (CGroupeActeur[])TousLesGroupesTypes();
			}
		}
		
		//-------------------------------------------------------------------

		#region Membres de IElementAIdentificationCourteAgenda

		public string IdentificationCourte
		{
			get
			{
				CDonneesActeurUtilisateur user = (CDonneesActeurUtilisateur)GetDonneesRole(CDonneesActeurUtilisateur.c_codeRole, false);
				if(  user != null )
					return user.Initiales;
				else 
					return CUtilTexte.GetInitiales ( IdentiteComplete, true );
			}
		}

		#endregion



		//-------------------------------------------------------------------
		/// <summary>
		/// Indique que cet acteur est inactif<br/>
		/// </summary>
		/// <remarks>
		/// Les acteurs inactifs n'apparaissent dans l'application que
		/// dans les fenêtres de gestion des acteurs. Ils sont désactivés
		/// et ne peuvent plus être sélectionnés.
		/// </remarks>
		[TableFieldProperty(c_champInactif)]
		[DynamicField("Inactive")]
		[TiagField("Inactive")]
		public bool Inactif
		{
			get
			{
				return ( bool )Row[c_champInactif];
			}
			set
			{
				Row[c_champInactif] = value;
			}
		}

		

		//-------------------------------------------------------------------
		public string[] GetProprietesAccessSousElementsAgenda()
		{
			return new string[]{"InscriptionsSessionsFormation","InterventionsJourneesFormation"};
		}


        /// <summary>
		/// Liste des <see cref="CRessourceMaterielle">Ressources Détenues</see> par l'Acteur
        /// </summary>
        /// <remarks>Les ressoureces détenues sont celles en sa possession à un moment donné</remarks>
        [RelationFille(typeof(CRessourceMaterielle), "EmplacementActeur")]
        [DynamicChilds("Held resources", typeof(CRessourceMaterielle))]
        public CListeObjetsDonnees RessourcesDetenues
        {
            get
            {
                return GetDependancesListe(CRessourceMaterielle.c_nomTable, c_champId);
            }
        }


        /// <summary>
        /// Identifie le Calendrier de l'Acteur
        /// </summary>
        [RelationFille(typeof(CCalendrier), "Acteur")]
        [DynamicField("Calendar")]
        public CCalendrier Calendrier
        {
            get
            {
                foreach (CCalendrier calendrier in GetDependancesListe(CCalendrier.c_nomTable, c_champId))
                {
                    if (calendrier != null)
                        return calendrier;
                }
                return null;
            }
        }

        
        


        /// <summary>
		/// Liste des <see cref="CActiviteActeur">Activités</see> pour le suivi d'activité (Feuille de temsp)
        /// </summary>
        [RelationFille(typeof(CActiviteActeur), "Acteur")]
        [DynamicChilds("Member activity", typeof(CActiviteActeur))]
        public CListeObjetsDonnees Activites
        {
            get
            {
                return GetDependancesListe(CActiviteActeur.c_nomTable, c_champId);
            }
        }

		//-------------------------------------------------------------------------------
		public bool IsInGroupe(CGroupeActeur groupe)
		{
			if ( groupe!= null )
				return IsInActorGroup ( groupe.Id );
			return false;
		}

		/// <summary>
		/// Cette fonction permet de savoir si l'Acteur fait partie d'un Groupe donné.
		/// </summary>
		/// <param name="nIdGroup">id du Groupe d'Acteurs</param>
		/// <returns>Retourne VRAI si l'utilisateur fait partie du Groupe</returns>
		[DynamicMethod("Returns true if the member belong to the actor group identified by ID",
			"Group id")]
		public bool IsInActorGroup(int nIdGroup)
		{

			CListeObjetsDonnees liste = RelationsGroupes;
			liste.Filtre = new CFiltreData(CGroupeActeur.c_champId + "=@1",
				nIdGroup );
			return liste.Count >= 1;
		}

		//-------------------------------------------------------------------------------
		public bool CanBeUseFor(IProfilElement profil, IEntreePlanning entree)
		{
			CProfilElement[] profils = profil.TousLesProfilsARemplir;
			if (profils.Length == 0)
				return true;
			if (profils[0].TypeElements != typeof(CActeur))
				return false;
			CListeObjetsDonnees liste = CProfilElement.GetElementsForSource(profil, (IObjetDonneeAIdNumerique)entree, null, null);
			if (liste != null)
			{
				foreach (CObjetDonneeAIdNumerique objet in liste)
					if (objet.Id == Id)
						return true;
			}
			return false;
		}


         

		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdActeurParent; }
		}

		public string ProprieteListeFils
		{
			get { return "Acteurs"; }
		}

		#endregion


        

		//---------------------------------------------
		/// <summary>
		/// La liste des <see cref="CEquipement">Equipements</see> détenus par l'Acteur
		/// </summary>
        /// <remarks>Il s'agit de la liste des Equipements en sa possession à un moment donné</remarks>
		[RelationFille(typeof(CEquipement), "EmplacementActeur")]
		[DynamicChilds("Equipments", typeof(CEquipement))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListe(CEquipement.c_nomTable, c_champId);
			}
		}

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

		[TableFieldProperty(c_champDatas)]
		public int Datas
		{
			get
			{
				return (int)Row[c_champDatas];
			}
		}


        //--------------------------------------------------------------------------
        /// <summary>
        /// Retourne toutes les tranches horaires de l'acteurs ayant une intersection entre
        /// une date de début et une date de fin. En fonction de son calendrier et de ses EO planifiées
        /// </summary>
        /// <param name="dtDebut"></param>
        /// <param name="dtfin"></param>
        /// <returns></returns>
        public CTrancheHoraire[] GetHoraires(DateTime dtDebut, DateTime dtfin)
        {
            if (this.Calendrier == null)
                return GetHorairesSansCalendrier(dtDebut, dtfin);

            return this.Calendrier.GetHoraires(dtDebut, dtfin);

        }


        //--------------------------------------------------------------------------
        /// <summary>
        /// Retourne toutes les tranches horaires de l'acteurs ayant une intersection entre
        /// une date de début et une date de fin. En fonction de ses EO planifiées uniquement
        /// </summary>
        /// <param name="dtDebut"></param>
        /// <param name="dtfin"></param>
        /// <returns></returns>
        public CTrancheHoraire[] GetHorairesSansCalendrier(DateTime dtDebut, DateTime dtfin)
        {
            if ((dtDebut == null) || (dtfin == null) || (dtfin < dtDebut))
                return new CTrancheHoraire[0];

            List<CTrancheHoraire> listeTranches = new List<CTrancheHoraire>();

            // Pour chaque jour entre la la veille de la date de début et la date de fin incluse
            for (DateTime date = dtDebut.Date.AddDays(-1); date <= dtfin.Date; date = date.AddDays(1))
            {
                // Liste des EO planifiées de ce jour
                CListeObjetsDonnees listeEoPlan = new CListeObjetsDonnees(ContexteDonnee, typeof(CEOplanifiee_Acteur));
                listeEoPlan.Filtre = new CFiltreData(
                                CActeur.c_champId + " =@1 and " +
                                CEOplanifiee_Acteur.c_champDate + " =@2",
                                this.Id,
                                date);
                foreach (CEOplanifiee_Acteur EOplan in listeEoPlan)
                {
                    CTrancheHoraire newTranche = new CTrancheHoraire();
                    newTranche.DateHeureDebut = date.Date;
                    newTranche.DateHeureDebut = newTranche.DateHeureDebut.AddMinutes(EOplan.TrancheHoraire.HeureDebut);
                    newTranche.DateHeureFin = (EOplan.TrancheHoraire.HeureFin > EOplan.TrancheHoraire.HeureDebut) ?
                                               date.Date : date.AddDays(1).Date;
                    newTranche.DateHeureFin = newTranche.DateHeureFin.AddMinutes(EOplan.TrancheHoraire.HeureFin);

                    newTranche.TypeOccupationHoraire = EOplan.TrancheHoraire.TypeOccupationHoraireAppliquee;

                    if (newTranche.DateHeureFin >= dtDebut && newTranche.DateHeureDebut <= dtfin)
                        listeTranches.Add(newTranche);
                }
            }

            listeTranches.Sort(new CTrancheHoraire.PrioriteComparer());
            return (CTrancheHoraire[])listeTranches.ToArray();

        }


        //-----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public override CFiltreData FiltreStandard
        {
            get
            {
                return new CFiltreData(c_champInactif + " = @1 ", false);
            }
        }

        #region IAffectableAEtape Membres

        public string RacineCleAffectationWorkflow
        {
            get { return c_racineAffectationEtape; }
        }

        #endregion

        /// <summary>
        /// retourne les codes d'affectation pour les étapes
        /// concernant cet acteur
        /// </summary>
        /// <returns></returns>
        public string[] GetListeCodesAffectationEtape()
        {
            List<string> strCodes = new List<string>();
            strCodes.Add(CAffectationsEtapeWorkflow.GetCleAffectation(this));
            foreach (CGroupeActeur groupe in TousLesGroupes())
                strCodes.Add(CAffectationsEtapeWorkflow.GetCleAffectation(groupe));
            CDonneesActeurUtilisateur user = Utilisateur;
            if (user != null)
            {
                foreach (CRelationUtilisateur_Profil rel in user.RelationsProfils)
                {
                    if (rel.Profil != null)
                        strCodes.Add(CAffectationsEtapeWorkflow.GetCleAffectation(rel.Profil));
                }
            }
            return strCodes.ToArray();
        }

        //-----------------------------------------------------------------
        public CListeObjetsDonnees GetEtapeWorkflowsEnCours()
        {
            CFiltreData filtre = new CFiltreData(CEtapeWorkflow.c_champEtat + "=@1",
                (int)EEtatEtapeWorkflow.Démarrée);

            string[] strCodes = GetListeCodesAffectationEtape();
            CFiltreData filtreAss = new CFiltreData();
            foreach (string strCode in strCodes)
            {
                filtreAss.Filtre += CEtapeWorkflow.c_champAffectations + " like @" +
                    (filtreAss.Parametres.Count + 1) + " or ";
                filtreAss.Parametres.Add("%~" + strCode + "~%");
            }
            if (filtreAss.Filtre.Length > 0)
            {
                filtreAss.Filtre = filtreAss.Filtre.Remove(filtreAss.Filtre.Length - 4, 4);
                filtre = CFiltreData.GetAndFiltre(filtre, filtreAss);
            }
            CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CEtapeWorkflow), filtre);
            return lst;
        }


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

    }

	/// <summary>
	/// Tri les acteurs du plus occupé au moins occupé ATTENTION > TRES LENT SUR GROSSE COLLECTION
	/// </summary>
	public class CActeur_OccupationActuelleComparer : System.Collections.Generic.IComparer<CActeur>
	{
		public int Compare(CActeur x, CActeur y)
		{

            CTrancheHoraire[] tranchesx = x.GetHoraires(DateTime.Now, DateTime.Now);
            CTrancheHoraire[] tranchesy = y.GetHoraires(DateTime.Now, DateTime.Now);

            if (tranchesx.Length == 0 && tranchesy.Length == 0)
				return 0;

			if(tranchesx.Length == 0)
			    return -1;

            if (tranchesy.Length == 0)
                return 1;

            // La première tranche est toujours la plus prioritaire retournée par GetHoraires
			int prioritex = tranchesx[0].Priorite;
			int prioritey = tranchesy[0].Priorite;
			if(prioritex > prioritey)
				return 1;
			else if(prioritex < prioritey)
				return -1;
			else
				return 0;
		}



        

	


        

	}



}
