using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.multitiers.client;

using sc2i.data.dynamic;
using sc2i.common.planification;

using timos.securite;
using timos.acteurs;
using sc2i.expression;
using System.Drawing;
using sc2i.drawing;
using System.Drawing.Imaging;
using timos.data.projet;
using tiag.client;
using timos.data.projet.besoin;
using timos.data.projet.gantt;


namespace timos.data
{
    /// <summary>
    /// Définit le type des <see cref="CProjet">projets</see>.
    /// Le Type de Projet permet de donner un certain nombre d'attributs au Projet, notamment les Fiches (ou formulaires personnalisés) 
    /// à afficher sur la page d'édition du Projet. <br/>
    /// Il permet également de préciser les hiérarchies possibles entre projets, ainsi que les méthodes
    /// de calcul de l'avancement des projets de ce type.
    /// </summary>
    [AutoExec("Autoexec")]
    [DynamicClass("Project Type")]
	[ObjetServeurURI("CTypeProjetServeur")]
	[Table(CTypeProjet.c_nomTable, CTypeProjet.c_champId, true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeProjet_ID)]
    [TiagClass(CTypeProjet.c_nomTiag, "Id", true)]
    [DynamicIcon(typeof(CProjet), ETypeIconeDynamique.EType)]
    public partial class CTypeProjet : CElementAChamp,
		IDefinisseurChampCustomRelationObjetDonnee,
        IDefinisseurEvenements,
        IElementAEO
	{
        public const string c_roleChampCustom = "PRJ_TYPE";

		#region Déclaration des constantes
        public const string c_nomTiag = "Project Type";
        public const string c_nomTable = "PROJECTTYPE";
		public const string c_champId = "PRJTYPE_ID";
		public const string c_champLibelle = "PRJTYPE_LABEL";
        public const string c_champFormulePoids = "PRJTYPE_WGHT_FORMULA";
        public const string c_champFormuleAvancement = "PRJTYPE_PRSS_FORMULA";
        public const string c_champGestionParHeure = "PRJTYPE_USE_HOURS";
        public const string c_champImage = "PRJTYPE_IMAGE";
        public const string c_champDureeDefault = "PRJTYPE_DEFAULT_DURATION";
        public const string c_champNeedHierarchy = "PRJTYPE_NEED_HIERARCHY";
        public const string c_champOptionVersion = "PRJTYPE_VERSION_OPTION";
        public const string c_champElementPrincipalAssocie = "PRJTYPE_ASSELT_FORMULA";
        public const string c_champVersionSurReferentiel = "PRJTYPE_VERSION_ONASSET";
        public const string c_champFormuleFormulaireVersion = "PRJTYPE_VERSION_FORM";

        public const string c_champDefaultTimeUnit = "PRJTYPE_DEFAULT_UNIT";
        public const string c_champDefaultTimePrecision = "PRJTYPE_DEFAULT_PRECISION";
        public const string c_champDefaultExpand = "PRJTYPE_EXPAND_DEFAULT";

        public const string c_champDefaultNeedType = "PRJTYPE_DEFAULT_ND_TP";

        public const string c_champCacheFormuleAvancement = "CACHE_AVANCEMENT";
        public const string c_champCacheFormulePoids = "CACHE_POIDS";
        public const string c_champCacheImage = "CACHE_IMAGE";
		#endregion

		//-------------------------------------------------------------------
		public CTypeProjet(CContexteDonnee ctx)
			: base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTypeProjet(System.Data.DataRow row)
			: base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Project type", typeof(CTypeProjet), typeof(CDefinisseurChampsPourTypeSansDefinisseur));
        }

		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}

        //-------------------------------------------------------------------
        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        public string TiagType
        {
            get { return c_nomTiag; }
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
			get { return I.T( "Project Type @1|447",Libelle); }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
            TravaillerAvecLesHeures = false;
            DureeDefautHeures = 48;
            NecessiteParent = false;
            DefaultTimeUnit = EGanttTimeUnit.Semaine;
            DefaultExpand = false;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
            return new string[] { c_champLibelle };
        }
		//-------------------------------------------------------------------
        /// <summary>
        /// Libellé du type de projet
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

		
		//---------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[RelationFille ( typeof( CProjet ), "TypeProjet")]
		[DynamicChilds("Projects",typeof(CProjet))]
		public CListeObjetsDonnees Projets
		{
			get
			{
				return GetDependancesListe(CProjet.c_nomTable, c_champId);
			}
		}

        
        /// /////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champElementPrincipalAssocie, 2000)]
        public string FormuleElementAssocieString
        {
            get{
                return (string)Row[c_champElementPrincipalAssocie];
            }
            set{
                Row[c_champElementPrincipalAssocie] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Indique que la version prévisionnelle doit être basée sur le référentiel
        /// et non sur la version du projet parent (la première version trouvée
        /// dans l'arborescence des projets parents)
        /// </summary>
        [TableFieldProperty(c_champVersionSurReferentiel)]
        [DynamicField("Data Version On Asset")]
        [TiagField("Data Version On Asset")]
        public bool VersionSurReferentiel
        {
            get
            {
                return (bool)Row[c_champVersionSurReferentiel];
            }
            set
            {
                Row[c_champVersionSurReferentiel] = value;
            }
        }


        /// /////////////////////////////////////////////
        public C2iExpression FormuleElementAssocie
        {
            get
            {
                C2iExpression formule = C2iExpression.FromPseudoCode(FormuleElementAssocieString);
                
                return formule;
            }
            set
            {
                FormuleElementAssocieString = C2iExpression.GetPseudoCode(value);
                
            }
        }


        /// /////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champFormuleAvancement, 2000)]
        public string FormuleAvancementString
        {
            get{
                return (string)Row[c_champFormuleAvancement];
            }
            set{
                Row[c_champFormuleAvancement] = value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty ( CTypeProjet.c_champCacheFormuleAvancement, NullAutorise = true, IsInDb=false)]
        public C2iExpression FormuleAvancement
        {
            get
            {
                if (Row[c_champCacheFormuleAvancement] != DBNull.Value)
                    return (C2iExpression)Row[c_champCacheFormuleAvancement];

                C2iExpression formule = C2iExpression.FromPseudoCode(FormuleAvancementString);
                if (formule != null)
                    CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormuleAvancement, formule);
                return formule;
            }
            set
            {
                FormuleAvancementString = C2iExpression.GetPseudoCode(value);
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormuleAvancement, DBNull.Value);
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champFormuleFormulaireVersion, 2000)]
        public string FormuleFormulaireVersionString
        {
            get
            {
                return (string)Row[c_champFormuleFormulaireVersion];
            }
            set
            {
                Row[c_champFormuleFormulaireVersion] = value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champDefaultTimeUnit)]
        [DynamicField("Default time unit")]
        public int DefaultTimeUnitInt
        {
            get
            {
                return (int)Row[c_champDefaultTimeUnit];
            }
            set
            {
                Row[c_champDefaultTimeUnit] = value;
            }
        }

        /// /////////////////////////////////////////////
        public EGanttTimeUnit DefaultTimeUnit
        {
            get
            {
                try
                {
                    return (EGanttTimeUnit)DefaultTimeUnitInt;
                }
                catch{
                    return EGanttTimeUnit.Semaine;
                }
            }
            set
            {
                DefaultTimeUnitInt = (int)value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(c_champDefaultTimePrecision)]
        [DynamicField("Default time precision")]
        public int DefaultTimePrecision
        {
            get
            {
                return (int)Row[c_champDefaultTimePrecision];
            }
            set
            {
                Row[c_champDefaultTimePrecision] = value;
            }
        }

        /// <summary>
        /// Indique si les projets de ce type s'ouvrent par défaut dans la fenêtre projet
        /// </summary>
        [TableFieldProperty(c_champDefaultExpand)]
        [DynamicField("Default expand")]
        public bool DefaultExpand
        {
            get
            {
                return (bool)Row[c_champDefaultExpand];
            }
            set
            {
                Row[c_champDefaultExpand] = value;
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Code du type de besoin par défaut pour ce type de projet
        /// </summary>
        /// <remarks>
        /// Les valeurs possibles sont :<BR></BR>
        /// <LI>0 : Quantité et Coût unitaire</LI>
        /// <LI>1 : Equipement</LI>
        /// <LI>3 : Besoin parent</LI>
        /// <LI>4 : Consommable</LI>
        /// <LI>5 : Temps</LI>
        /// <LI>6 : Opération</LI>
        /// <LI>7 : Projet</LI>
        /// </remarks>
        [TableFieldProperty(c_champDefaultNeedType)]
        [DynamicField("Default need type code")]
        public int CodeTypeBesoinParDefaut
        {
            get
            {
                return (int)Row[c_champDefaultNeedType];
            }
            set
            {
                Row[c_champDefaultNeedType] = value;
            }
        }

        //---------------------------------------------------------------
        [DynamicField("Default need type")]
        public CTypeDonneeBesoin TypeBesoinParDefaut
        {
            get
            {
                return new CTypeDonneeBesoin((ETypeDonneeBesoin)CodeTypeBesoinParDefaut);
            }
            set
            {
                if (value != null)
                    CodeTypeBesoinParDefaut = value.CodeInt;
            }
        }

        

        /// /////////////////////////////////////////////
        public C2iExpression FormuleFormulaireVersion
        {
            get
            {

                C2iExpression formule = C2iExpression.FromPseudoCode(FormuleFormulaireVersionString);
                return formule;
            }
            set
            {
                FormuleFormulaireVersionString = C2iExpression.GetPseudoCode(value);
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champFormulePoids, 2000)]
        public string FormulePoidsString
        {
            get
            {
                return (string)Row[c_champFormulePoids];
            }
            set
            {
                Row[c_champFormulePoids] = value;
            }
        }

        /// /////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champCacheFormulePoids, NullAutorise = true, IsInDb=false)]
        public C2iExpression FormulePoids
        {
            get
            {
                if (Row[c_champCacheFormulePoids] != DBNull.Value)
                    return (C2iExpression)Row[c_champCacheFormulePoids];
                C2iExpression formule = C2iExpression.FromPseudoCode(FormulePoidsString);
                if (formule == null)
                    formule = new C2iExpressionConstante(1);
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormulePoids, formule);
                return formule;
            }
            set
            {
                FormulePoidsString = C2iExpression.GetPseudoCode(value);
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheFormulePoids, DBNull.Value);
            }
        }

        //---------------------------------------------------------------
        /// <summary>
        /// Indique si VRAI, que le détail des projets de ce type est par défaut à l'heure,<br/>
        /// dans le diagramme de Gantt; c'est à dire que les dates conservent l'heure<br/>
        /// alors qu'autrement l'heure des dates est mise à 0.
        /// </summary>
        [TableFieldProperty(CTypeProjet.c_champGestionParHeure)]
        [DynamicField("Use hours")]
        [TiagField("Use hours")]
        public bool TravaillerAvecLesHeures
        {
            get
            {
                return (bool)Row[c_champGestionParHeure];
            }
            set
            {
                Row[c_champGestionParHeure] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Durée par défaut (en heures) d'un projet de ce type
        /// </summary>
        [TableFieldProperty(c_champDureeDefault)]
        [DynamicField("Default duration hours")]
        [TiagField("Default duration hours")]
        public double DureeDefautHeures
        {
            get
            {
                return (double)Row[c_champDureeDefault];
            }
            set
            {
                Row[c_champDureeDefault] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique, si VRAI, qu'un projet de ce type ne peut être créé sans faire référence à un projet parent
        /// </summary>
        [TableFieldProperty(c_champNeedHierarchy)]
        [DynamicField("Need parent")]
        [TiagField("Need parent")]
        public bool NecessiteParent
        {
            get
            {
                return (bool)Row[c_champNeedHierarchy];
            }
            set
            {
                Row[c_champNeedHierarchy] = value;
            }
        }


        // /////////////////////////////////////////////////////////
        [TableFieldProperty(CTypeProjet.c_champImage, NullAutorise = true)]
        public CDonneeBinaireInRow DataImage
        {
            get
            {
                if (Row[c_champImage] == DBNull.Value)
                {
                    CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champImage);
                    CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champImage, donnee);
                }
                object obj = Row[c_champImage];
                return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
            }
            set
            {
                Row[c_champImage] = value;
            }
        }


        // /////////////////////////////////////////////////////////
        [TableFieldProperty (CTypeProjet.c_champCacheImage, IsInDb = false, NullAutorise = true)]
        [BlobDecoder]
        public Image Image
        {
            get
            {
                if (Row[c_champCacheImage] != DBNull.Value)
                    return (Image)Row[c_champCacheImage];
                CDonneeBinaireInRow data = DataImage;
                if (data != null && data.Donnees != null)
                {
                    MemoryStream stream = new MemoryStream(data.Donnees);
                    {
                        try
                        {
                            Image img = Image.FromStream(stream);
                            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champCacheImage, img);
                            return img;
                        }
                        catch { }
                    }
                }
                return null;
            }
            set
            {
                Row[c_champCacheImage] = DBNull.Value;
                if (value == null)
                {
                    CDonneeBinaireInRow data = DataImage;
                    data.Donnees = null;
                    DataImage = data;
                    
                }
                else
                {
                    Image img = CUtilImage.CreateImageImageResizeAvecRatio(value, new Size(16, 16), Color.White);
                    MemoryStream stream = new MemoryStream();
                    img.Save(stream, ImageFormat.Png);
                    CDonneeBinaireInRow donnee = DataImage;
                    donnee.Donnees = stream.ToArray();
                    DataImage = donnee;
                }
            }
        }

		#region IDefinisseurChampCustomRelationObjetDonnee Membres
		[RelationFille(typeof(CRelationTypeProjet_ChampCustom), "Definisseur")]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get { return GetDependancesListe(CRelationTypeProjet_ChampCustom.c_nomTable, c_champId); }
		}

		[RelationFille(typeof(CRelationTypeProjet_Formulaire), "Definisseur")]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get { return GetDependancesListe(CRelationTypeProjet_Formulaire.c_nomTable, c_champId); }
		}

		#endregion

		#region IDefinisseurChampCustom Membres


		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof(IRelationDefinisseurChamp_ChampCustom));
			}
		}

		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
				return (IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(CProjet.c_roleChampCustom);
			}
		}

        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(CTypeProjet.c_roleChampCustom);
            }
        }

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

        #region IDefinisseurEvenements Membres

        public CComportementGenerique[] ComportementsInduits
        {
            get
            {
                return CUtilDefinisseurEvenement.GetComportementsInduits(this);
            }
        }

        public CListeObjetsDonnees Evenements
        {
            get { return CUtilDefinisseurEvenement.GetEvenementsFor(this); }
        }

        public Type[] TypesCibleEvenement
        {
            get { return new Type[] { typeof(CProjet) }; }
        }

        #endregion


        public override IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get {
                return new IDefinisseurChampCustom[]{
                    new CDefinisseurChampsPourTypeSansDefinisseur(
                        ContexteDonnee, 
                        CRoleChampCustom.GetRole(CTypeProjet.c_roleChampCustom) )};
            }
        }

        public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationTypeProjet_ChampCustomValeur(ContexteDonnee);
        }

        [RelationFille(typeof(CRelationTypeProjet_ChampCustomValeur), "ElementAChamps")]
        public override CListeObjetsDonnees RelationsChampsCustom
        {
            get {
                return GetDependancesListe(CRelationTypeProjet_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        public bool AccepteProjetsFilsDuType ( CTypeProjet typeProjet )
        {
            if ( typeProjet == null )
                return true;
            CListeObjetsDonnees lst = RelationsTypesProjetsFilsPossibles;
            if ( lst.Count == 0 )
                return true;
            lst.Filtre = new CFiltreData ( CRelationTypeProjet_TypeProjet.c_champTypeFils+"=@1",
                typeProjet.Id);
            lst.InterditLectureInDB = true;
            return lst.Count > 0;
        }

        //---------------------------------------------
        public bool AccepteProjetsParentsDuType(CTypeProjet typeProjet)
        {
            if (typeProjet != null)
                return typeProjet.AccepteProjetsFilsDuType(this);
            return true;
        }

        //---------------------------------------------
        public CListeObjetsDonnees TypesProjetsParentsPossibles
        {
            get
            {
                CListeObjetsDonnees lstTypesProjets = new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeProjet));
                if (RelationsTypesProjetsParentsPossibles.Count != 0)
                {
                    lstTypesProjets.FiltrePrincipal = new CFiltreDataAvance(
                        CTypeProjet.c_nomTable,
                        "RelationsTypesProjetsFilsPossibles." +
                        CRelationTypeProjet_TypeProjet.c_champTypeFils + "=@1",
                        Id);
                }
                return lstTypesProjets;
            }
        }

        //---------------------------------------------
        public CListeObjetsDonnees TypesProjetsFilsPossibles
        {
            get
            {
                CListeObjetsDonnees lstTypesProjets = new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeProjet));
                if (RelationsTypesProjetsFilsPossibles.Count != 0)
                {
                    lstTypesProjets.FiltrePrincipal = new CFiltreDataAvance(
                        CTypeProjet.c_nomTable,
                        "RelationsTypesProjetsParentsPossibles." +
                        CRelationTypeProjet_TypeProjet.c_champTypeParent + "=@1",
                        Id);
                }
                return lstTypesProjets;
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Donne la liste des types de projets enfants possibles
        /// </summary>
        [RelationFille(typeof(CRelationTypeProjet_TypeProjet), "TypeProjetParent")]
        [DynamicChilds("Allowed child types", typeof(CRelationTypeProjet_TypeProjet))]
        public CListeObjetsDonnees RelationsTypesProjetsFilsPossibles
        {
            get
            {
                return GetDependancesListe(CRelationTypeProjet_TypeProjet.c_nomTable, CRelationTypeProjet_TypeProjet.c_champTypeParent);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Donne la liste des types de projets parents possibles
        /// </summary>
        [RelationFille(typeof(CRelationTypeProjet_TypeProjet), "TypeProjetFils")]
        [DynamicChilds("Allowed parent types", typeof(CRelationTypeProjet_TypeProjet))]
        public CListeObjetsDonnees RelationsTypesProjetsParentsPossibles
        {
            get
            {
                return GetDependancesListe(CRelationTypeProjet_TypeProjet.c_nomTable, CRelationTypeProjet_TypeProjet.c_champTypeFils);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Donne la liste des sous types de projets possibles
        /// </summary>
        [RelationFille(typeof(CRelationTypeProjet_SousTypeProjet), "TypeProjetParent")]
        [DynamicChilds("Allowed sub types", typeof(CRelationTypeProjet_SousTypeProjet))]
        public CListeObjetsDonnees RelationsSousTypesProjetsPossibles
        {
            get
            {
                return GetDependancesListe(CRelationTypeProjet_SousTypeProjet.c_nomTable, CRelationTypeProjet_SousTypeProjet.c_champTypeParent);
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le code correspondant aux options de version :
        /// <ul>
        /// <li>0 : Sans version</li>
        /// <li>1 : Création manuelle de la version (action volontaire sur un projet de ce type, par le lien prévu à cet effet)</li>
        /// <li>2 : Création automatique de la version à la création du projet</li>
        /// </ul>
        /// </summary>
        [TableFieldProperty(c_champOptionVersion)]
        [DynamicField("Version option code")]
        [TiagField("Version option code")]
        public int OptionVersionCode
        {
            get
            {
                return (int)Row[c_champOptionVersion];
            }
            set
            {
                Row[c_champOptionVersion] = value;
            }
        }

        //-----------------------------------------------------------
        public COptionTypeProjetVersion OptionVersion
        {
            get
            {
                return new COptionTypeProjetVersion((EOptionTypeProjetVersion)OptionVersionCode);
            }
            set
            {
                if (value != null)
                    OptionVersionCode = value.CodeInt;
            }
        }


        //-----------------------------------------------------------
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO ( this, nIdEO );
        }

        //-------------------------------------------------------------------
		/// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquels est affecté l'équipement<br/>
		/// </summary>
        /// <remarks>
        /// Ces codes sont présentés sous la forme d'une chaîne de caractères<br/>
        /// Chaque code est encadré par deux caractères ~ (exemple : ~01051B~0201~061A0304~)
        /// </remarks>
		[TableFieldProperty(CUtilElementAEO.c_champEO, 500)]
		[DynamicField("Organisational entities codes")]
		public string CodesEntitesOrganisationnelles
		{
			get { return (string)Row[CUtilElementAEO.c_champEO]; }
			set { Row[CUtilElementAEO.c_champEO] = value; }
		}

        //-------------------------------------------------------------------
        public IElementAEO[] DonnateursEO
        {
            get { return new IElementAEO[0]; }
        }

        //-------------------------------------------------------------------
        public CListeObjetsDonnees EntiteOrganisationnellesDirectementLiees
        {
            get { return CRelationElement_EO.GetEntitesOrganisationnellesDirectementLiees(this); }
        }

        //-------------------------------------------------------------------
        public IElementAEO[] HeritiersEO
        {
            get { return (IElementAEO[])Projets.ToArray(typeof(IElementAEO)); }
        }

        //-------------------------------------------------------------------
        [DynamicMethod(
            "Set all Organizational Entities to the Element",
            "An array of Organizational Entity IDs")]
        public CResultAErreur SetAllOrganizationalEntities(int[] nIdsOE)
        {
            return CUtilElementAEO.SetAllOrganizationalEntities(this, nIdsOE);
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Remet à jour les codes des <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> de cet équipement
        /// </summary>
        [DynamicMethod("Refresh Organisational entities codes for this element")]
        public void RefreshCodesEOS()
        {
            CUtilElementAEO.UpdateEOs(this);
        }

        //-------------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO ( this, nIdEO );
        }

        //-------------------------------------------------------------------
        public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
        {
            CUtilElementAEO.CompleteRestriction ( this, restriction );
        }
    }






}
