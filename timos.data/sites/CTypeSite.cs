using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;
using tiag.client;
using sc2i.doccode;

using timos.data.tiag;

namespace timos.data
{

    /// <summary>
    /// Le Type de Site permet de donner un certain nombre d'attributs au Site, notamment les Fiches (ou formulaires personnalisés) 
    /// à afficher sur la page d'édition du Site. <br/>
    /// Il permet également de préciser les hiérarchies possibles entre sites
    /// </summary>
	[DocRefMenusOrMenuItems(CDocLabels.c_iSite)]
	[DocRefRessources(CDocLabels.c_dSite)]
    [DynamicClass("Site type")]
    [Table(CTypeSite.c_nomTable, CTypeSite.c_champId, true)]
    [ObjetServeurURI("CTypeSiteServeur")]
	[TiagClass(CTypeSite.c_nomTiag, "Id", true)]
	[TiagUniqueAttribute ( CTypeSite.c_champLibelle+"=@1", "Libelle" )]
    [Unique (false, "The label of this site type is already used", CTypeSite.c_champLibelle)]
    [DynamicIcon(typeof(CSite), ETypeIconeDynamique.EType)]
    [AutoExec("Autoexec")]
    public class CTypeSite : CElementAChamp,
                            IObjetALectureTableComplete,
                            IDefinisseurChampCustomRelationObjetDonnee,
							IElementAEO,
                            IPossesseurContrainte,
							IElementAInterfaceTiag,
							IObjetASystemeDeCoordonnee,
                            IDefinisseurSymbole
    {
		public const string c_nomTiag = "Site type";

        public const string c_nomTable = "SITE_TYPE";
		public const string c_champId = "SITETYPE_ID";

		public const string c_champLibelle = "SITETYPE_LABEL";
		public const string c_champCommentaire = "SITETYPE_COMMENTS";
		public const string c_champParentObligatoire = "SITETYPE_OBLIG_PARENT";

		public const string c_champIdTypeEOCoordonnee = "SITETYPE_ID_OECOORDINATE";

        public const string c_roleChampCustom = "SITE_TYPE";

		/// /////////////////////////////////////////////
		public CTypeSite( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeSite(DataRow row)
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
        // Decription du Type de Site
		public override string DescriptionElement
		{
			get { return I.T( "Site Type: @1|276", Libelle); }
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Site type", typeof(CTypeSite), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

		 /////////////////////////////////////////////
        /// <summary>
		/// Indique libellé pour ce Type de Site. Ce champ texte de 255 caractères est obligatoire et unique.
        /// </summary>
        [TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
		[TiagField("Label")]       
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

        // /////////////////////////////////////////////
        /// <summary>
        /// Le champ Ccommentaire est un texte libre de description du Type de Site. 1024 caractères maximum. Ce champ n'est pas olbigatoire.
        /// </summary>
        [TableFieldProperty(c_champCommentaire, 1024)]
        [DynamicField("Comment")]
        [TiagField("Comment")]
		public string Commentaire
        {
            get 
            {
                return (string)Row[c_champCommentaire]; 
            }
            set
            {
                Row[c_champCommentaire] = value; 
            }
		}


		#region Coordonnee
		/// <summary>
        /// Indique le Type d'<see cref="CEntiteOrganisationnelle">Entité Organisationnelle</see> 
        /// duquel le Type de Site hérite son Système de coordonnées<br/>
		/// </summary>
		[RelationAttribute(
		   CTypeEntiteOrganisationnelle.c_nomTable,
		  CTypeEntiteOrganisationnelle.c_champId,
		  CTypeSite.c_champIdTypeEOCoordonnee,
			false,
			false,
			false)]
		[DynamicField("Organisational entity of coordinate")]
		public CTypeEntiteOrganisationnelle TypeEntiteOrganisationnelleDeCoordonnee
		{
			get { return (CTypeEntiteOrganisationnelle)GetParent(CTypeSite.c_champIdTypeEOCoordonnee, typeof(CTypeEntiteOrganisationnelle)); }
			set { SetParent(CTypeSite.c_champIdTypeEOCoordonnee, value); }
		}
		#endregion



		//---------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des <see cref="CRelationTypeSite_TypeSite">relations avec les Types de Sites</see> qui peuvent être inclus dans ce Type de Site.
        /// </summary>
        [RelationFille(typeof(CRelationTypeSite_TypeSite),"TypeSiteContenant")]
        [DynamicChilds("Contained types relations", typeof(CRelationTypeSite_TypeSite))]
        public CListeObjetsDonnees RelationTypesContenus
        {
            get 
            {
                return GetDependancesListe(CRelationTypeSite_TypeSite.c_nomTable, CRelationTypeSite_TypeSite.c_champTypeContenantId); 
            }
        }


        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des <see cref="CRelationTypeSite_TypeSite">relations avec les Types de Sites</see> contenants, dans lesquelles ce Type de Site peut être inclus.
        /// </summary>
        [RelationFille(typeof(CRelationTypeSite_TypeSite), "TypeSiteContenu")]
        [DynamicChilds("Container types relations", typeof(CRelationTypeSite_TypeSite))]
        public CListeObjetsDonnees RelationTypesContenants
        {
            get 
            {
                return GetDependancesListe(CRelationTypeSite_TypeSite.c_nomTable, CRelationTypeSite_TypeSite.c_champTypeContenuId); 
            }
        }


        //----------------------------------------------------------------------------------------
        /// <summary>
        /// Option qui précise si les <see cref="CSite">sites</see> de ce Type doiventt posséder obligatoirement un Parent. 
        /// C'est à dire qu'un Site de ce Type ne peut être créé directement.
        /// Il devra être créé en tant que site fils d'un autre site.
        /// </summary>
        /// <remarks>
        /// Si cette option est à VRAI le Type de Site devra avoir des relations vers des Type de Site contenants.
        /// </remarks>
        [TableFieldProperty(c_champParentObligatoire)]
        [DynamicField("Obligatory parent")]
        public bool ParentObligatoire
        {
            get
            {
                return (bool)Row[c_champParentObligatoire];
            }
            set
            {
                Row[c_champParentObligatoire] = value;
            }
        }



        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des <see cref="CContrainte">Contraintes</see> associées à ce type de site.
        /// Les <see cref="CSite">sites</see> de ce type hériteront de ces mêmes contraintes.
        /// </summary>
        [RelationFille(typeof(CContrainte), "TypeSite")]
        [DynamicChilds("Constraints", typeof(CContrainte))]
        public CListeObjetsDonnees Contraintes
        {
            get
            {
                return GetDependancesListe(CContrainte.c_nomTable, c_champId);
            }
        }

		//------------------------------
		public List<CContrainte> ToutesLesContraintes
		{
			get
			{
				List<CContrainte> lst = new List<CContrainte>();
				foreach (CContrainte contrainte in Contraintes)
					lst.Add(contrainte);
				return lst;
			}
		}

        /// <summary>
        /// <see cref="CSymbole">Symbole</see> graphique associé au type de site.
        /// Il s'agit soit d'un symbole propre défini au niveau du type de site,
        /// soit d'un symbole de bibliothèque référencé par le type de site.
        /// Lorsqu'il existe, ce symbole peut être exploité au niveau des <see cref="CSite">sites</see> de ce type
        /// pour représenter le site dans les vues graphiques 
        /// (vues de <see cref="CLienReseau">liens réseau</see> ou vues de <see cref="CSchemaReseau">schémas réseau</see>)
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {
                if (SymbolePropre != null)
                    return SymbolePropre;
                if (SymboleDeBibliotheque != null)
                    return SymboleDeBibliotheque.Symbole;
                return null;
            }
        }


        /// <summary>
        /// Le <see cref="CSymboleDeBibliotheque">symbole de bibliotheque</see> associé au type de site (lorsqu'il existe)
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library Symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if (SymbolePropre != null)
                {
                  
                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);

            }

        }

        /// <summary>
        /// Le <see cref="CSymbole">symbole</see> graphique propre au type de site lorsqu'il est défini
        /// </summary>
        [RelationFille(typeof(CSymbole), "TypeSite")]
        [DynamicField("Proper symbol")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CTypeSite.c_champId);
                if (liste.Count > 0)
                    return (CSymbole)liste[0];
                else
                    return null;
            }

            set
            {


                Row[CSymboleDeBibliotheque.c_champId] = null;
                if (value == null)
                {
                    if (SymbolePropre != null)
                        SymbolePropre.Delete();
                }
                else
                {
                    value.TypeSite = this;
                }

               
                    
            }

        }

        //--------------------------------------

        public C2iSymbole SymboleDefiniADessiner
        {
            get
            {
                C2iSymbole symbole = null;
                if (Symbole != null)
                    symbole = Symbole.Symbole;
                if (symbole == null)
                    symbole = CSymbole.GetSymboleParDefaut(typeof(CSite), ContexteDonnee);
                return symbole;
            }
        }

        //--------------------------------------
        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CSite);
        }

		#region Type Tables parametrables
		/// <summary>
        /// Liste des relations du type de site avec les <see cref="CRelationTypeSite_TypeTableParametrable">types de tables paramétrables</see>.
        /// Si de telles relations sont définies au niveau du type de site, les sites de ce type ne
        /// pourront être associés qu'à des tables paramétrables faisant partie de ces relations
		/// </summary>
		[RelationFille(typeof(CRelationTypeSite_TypeTableParametrable), "TypeSite")]
		[DynamicChilds("Custom Table Types", typeof(CRelationTypeSite_TypeTableParametrable))]
		public CListeObjetsDonnees RelationsTypesTableParametrables
		{
			get { return GetDependancesListe(CRelationTypeSite_TypeTableParametrable.c_nomTable, c_champId); }
		}
		#endregion


		#region IDefinisseurChampCustomRelationObjetDonnee Membres

		[RelationFille(typeof(CRelationTypeSite_ChampCustom), "Definisseur")]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get { return GetDependancesListe(CRelationTypeSite_ChampCustom.c_nomTable, c_champId); }
        }

        [RelationFille(typeof(CRelationTypeSite_Formulaire), "Definisseur")]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get { return GetDependancesListe(CRelationTypeSite_Formulaire.c_nomTable, c_champId); }
        }

 
        #endregion

        #region IDefinisseurChampCustom Membres

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
        {
            get
            {
                return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
            }
        }

        /// /////////////////////////////////////////////
        public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
        {
            get
            {
                return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
            }
        }

        /// /////////////////////////////////////////////
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CSite.c_roleChampCustom);
            }
        }

        /// /////////////////////////////////////////////
        public CChampCustom[] TousLesChampsAssocies
        {
            get
            {
                Hashtable tableChamps = new Hashtable();
                FillHashtableChamps(tableChamps);
                CChampCustom[] liste = new CChampCustom[tableChamps.Count];
                int nChamp = 0;
                foreach (CChampCustom champ in tableChamps.Values)
                    liste[nChamp++] = champ;
                return liste;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remplit une hashtable IdChamp->Champ
        /// avec tous les champs liés.(hiérarchique)
        /// </summary>
        /// <param name="tableChamps">HAshtable à remplir</param>
        private void FillHashtableChamps(Hashtable tableChamps)
        {
            foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomDefinis)
                tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
            foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
            {
                foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
                    tableChamps[relFor.Champ.Id] = relFor.Champ;
            }
        }

        #endregion

		#region IElementAEO Membres

		//-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquelles est affecté le type de site<br/>
        /// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
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

		//-------------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get
			{
				return null;
			}
		}


		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				return (IElementAEO[])GetDependancesListe(CSite.c_nomTable, c_champId).ToArray(typeof(IElementAEO));
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
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
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
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
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


		#region IObjetASystemeDeCoordonnee Membres
		//----------------------------------------------------------------------
        /// <summary>
        /// Retourne le <see cref="CParametrageSystemeCoordonnees">Système de coordonnées</see> propre défini par le Type de Site (lorsqu'il existe).
        /// </summary>
        [DynamicField("Own coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
		{
			get
			{
				CListeObjetsDonnees liste = GetDependancesListe(CParametrageSystemeCoordonnees.c_nomTable, c_champId);
				if (liste.Count == 1)
					return (CParametrageSystemeCoordonnees)liste[0];
				return null;
			}
		}

		//----------------------------------------------------------------------
		public bool CanHeriteParametrageCoordonnees
		{
			get
			{
				return false;
			}
		}

		//----------------------------------------------------------------------
		public string ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage
		{
			get
			{
				return "";
			}
		}

		//----------------------------------------------------------------------
		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get
			{
				return null;
			}
		}


		//----------------------------------------------------------------------
        /// <summary>
        /// <see cref="CParametrageSystemeCoordonnees">Système de coordonnées</see> appliqué. Le Système de coordonnées peut être hérité ou défini par le Type de Site lui-même (Système propre). 
        /// Cette propriété indique quel est le Système appliqué aux Sites de ce Type: Le Système hérité ou le Système propre.
        /// </summary>
        [DynamicField("Applied coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get
			{
				return ParametrageCoordonneesPropre;
			}
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


        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeSite.c_roleChampCustom) )};
            }
        }

        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeSite_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeSite_ChampCustomValeur), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeSite_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeSite.c_roleChampCustom);
            }
        }
		


    }
}
