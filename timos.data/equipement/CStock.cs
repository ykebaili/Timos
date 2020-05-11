using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.data.version;
using timos.securite;

using tiag.client;
using timos.data.composantphysique;
using sc2i.expression;

namespace timos.data
{

	/// <summary>
	/// Le stock est un emplacement pour <see cref="CEquipement">Equipement</see>.<br/>
	/// Un stock est lui même placé dans un site et peu disposer d'un 
	/// <see cref="CSystemeCoordonnees">système de coordonnées</see>.<br/>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iStock)]
    [DynamicClass("Stock")]
	[Table(CStock.c_nomTable, CStock.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CStockServeur")]
	[TiagClass(CStock.c_nomTiag, "Id", true)]
    [AutoExec("Autoexec")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_Stock_ID)]
    public partial class CStock : 
		                CObjetDonneeAIdNumeriqueAuto, 
		                IObjetALectureTableComplete,
		                IElementAEO,
		                IEmplacementEquipement,
		                IObjetAFilsACoordonnees,
		                IObjetACoordonnees,
		                IElementAInterfaceTiag,
		                IObjetDonneeAChamps,
						IElementATypeStructurant<CTypeStock>
	{
		public const string c_nomTiag = "Stock";
		public const string c_nomTable = "STOCK";
		
		public const string c_champId = "STOCK_ID";
		public const string c_champLibelle = "STOCK_LABEL";
		public const string c_champEO = "STOCK_OES";
		public const string c_champCoordonnee = "STOCK_COORDINATE";
		public const string c_champOptionsControleCoordonnees = "STOCK_OPTION_CTRL_COORD";

        public const string c_roleChampCustom = "STOCK";

		/// /////////////////////////////////////////////
		public CStock( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CStock(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Stock", typeof(CStock),typeof(CTypeStock));
        }

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }



		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Stock @1|105", Libelle);
			}
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

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		 /////////////////////////////////////////////
		/// <summary>
		/// Libellé du Stock<br/>
		/// (obligatoire)
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[TiagField("Label")]
        [DescriptionField]
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

		//-------------------------------------------------------------------
		/// <summary>
		/// UtilisÃ© par TIAG pour affecter le type de stock par ses clÃ©s
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetStockKeys(object[] lstCles)
		{
			CTypeStock typeStock = new CTypeStock(ContexteDonnee);
			if (typeStock.ReadIfExists(lstCles))
				TypeStock = typeStock;
		}
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Type de stock correspondant à ce stock<br/>
		/// (obligatoire)
		/// </summary>
		[Relation  (
			CTypeStock.c_nomTable,
			CTypeStock.c_champId,
		   CTypeStock.c_champId,
			true, false, true)]
		[DynamicField("Stock type")]
		[TiagRelation(typeof(CStock), "TiagSetStockKeys")]

		public CTypeStock TypeStock
		{
			get
			{
				return (CTypeStock)GetParent(CTypeStock.c_champId, typeof(CTypeStock));
			}
			set
			{
				SetParent(CTypeStock.c_champId, value);
			}
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquels est affecté le stock<br/>
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
		public IElementAEO[] DonnateursEO
		{
			get
			{
				return new IElementAEO[] { Site };
			}
		}

		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				return (IElementAEO[])Equipements.ToArray(typeof(IElementAEO));
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Complete des restrictions en fonction des EOS
		/// </summary>
		/// <param name="restriction"></param>
		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CUtilElementAEO.CompleteRestriction ( this, restriction );
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
        /// Affecte une nouvelle entité organisationnelle au stock
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO à ajouter</param>
        /// <returns><see cref="CResultAErreur">Résultat à erreur</see></returns>
        [DynamicMethod(
            "Asigne a new Organizational Entity to the Element",
            "The Organizational Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Ote du stock une entité organisationnelle
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO à ôter</param>
        /// <returns><see cref="CResultAErreur">Résultat à erreur</see></returns>
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


		//---------------------------------------------
		/// <summary>
		/// Site sur lequel se trouve le stock<br/>
		/// (obligatoire)
		/// </summary>
		[Relation (
			CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			true,
			false,
			true )]
		[DynamicField("Site")]
		public CSite Site
		{
			get
			{
				return (CSite)GetParent(CSite.c_champId, typeof(CSite));
			}
			set
			{
				SetParent(CSite.c_champId, value);
			}
		}

		//---------------------------------------------
		/// <summary>
		/// Liste des Equipements contenus dans ce stock
		/// </summary>
		[RelationFille ( typeof( CEquipement ), "EmplacementStock")]
		[DynamicChilds("Equipments",typeof(CEquipement))]
		public CListeObjetsDonnees Equipements
		{
			get
			{
				return GetDependancesListeProgressive(CEquipement.c_nomTable, c_champId);
			}
		}

        //-----------------------------------------------------------------------------
        /// <summary>
        /// Lister des relations de ce stock avec les types d'équipements
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_Stock), "Stock")]
        [DynamicChilds("Equipment Type Relations", typeof(CRelationTypeEquipement_Stock))]
        public CListeObjetsDonnees RelationsTypesEquipements
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_Stock.c_nomTable, c_champId);
            }
        }

        //-------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un objet de relation entre ce stock et un type d'équipement
        /// </summary>
        /// <param name="Type Equipement">Le type d'équipement pour lequel la relation est recherchée</param>
        /// <returns><see cref="CResultAErreur">Résultat à erreur</see></returns>
        [DynamicMethod("Retourne un objet Relation Type_Equipement/Stock pour un Type d'equipement donne", "Le Type d'Equipement concerne")]
        public CRelationTypeEquipement_Stock GetRelationTypeEquipemetStock(CTypeEquipement typeEquipement)
        {
            if (typeEquipement == null)
                return null;

            CRelationTypeEquipement_Stock rel = new CRelationTypeEquipement_Stock(this.ContexteDonnee);
            if (rel.ReadIfExists(
                    new CFiltreData(
                        CStock.c_champId + " = @1 and " + CTypeEquipement.c_champId + " = @2 ",
                        this.Id,
                        typeEquipement.Id)))
            {
                return rel;
            }
            else
            {
                rel.CreateNewInCurrentContexte();
                rel.Stock = this;
                rel.TypeEquipement = typeEquipement;

                return rel;
            }
        }


		#region IObjetASystemeDeCoordonnee Membres

		//---------------------------------------------
        /// <summary>
        /// Système de coordonnées appliqué au stock
        /// </summary>
		[DynamicField("Applied coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get { return ParametrageCoordonneesPropre; }
		}

		//---------------------------------------------
		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get { return null; }
		}

		//---------------------------------------------
        /// <summary>
        /// Système de coordonnées propre au stock
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

		//---------------------------------------------
		public bool CanHeriteParametrageCoordonnees
		{
			get { return false; }
		}

		//----------------------------------------------------------------------
		public string ProprieteVersObjetsAFilsACoordonneesUtilisantLeParametrage
		{
			get
			{
				return "";
			}
		}

		#endregion

		#region IObjetACoordonnees


		//---------------------------------------------
        /// <summary>
        /// Coordonnée du stock
        /// </summary>
		[TableFieldProperty ( CStock.c_champCoordonnee, 255)]
		[DynamicField("Coordinate")]
		public string Coordonnee
		{
			get
			{
				return ( string )Row[c_champCoordonnee];
			}
			set
			{
				Row[c_champCoordonnee] = value;
			}
		}

        /// <summary>
        /// Coordonnée complète du stock (intègre les coordonnées des parents)
        /// </summary>
		[DynamicField("Full Coordinate")]
		public string CoordonneeComplete
		{
			get
			{
				if (CoordonneeParente == "" || CoordonneeParente == null)
					return Coordonnee;
				else
				{
					if (Coordonnee == "" || Coordonnee == null)
						return CoordonneeParente;
					else
						return CoordonneeParente + CSystemeCoordonnees.c_separateurNumerotations + Coordonnee;
				}
			}
		}

        /// <summary>
        /// Coordonnée complète du parent direct
        /// </summary>
		[DynamicField("Parent Coordinate")]
		public string CoordonneeParente
		{
			get
			{
				if (Site != null && (Site.Coordonnee != "" && Site.Coordonnee != null))
					return Site.CoordonneeComplete;
				else
					return "";

			}
		}



		//---------------------------------------------
		public bool IgnorerUnite
		{
			get { return true; }
		}

		//---------------------------------------------
		public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
		{
			get 
			{ 
				return null; 
			}
		}

		//---------------------------------------------
		public CResultAErreur VerifieCoordonnee()
		{
			IObjetAFilsACoordonnees parent = ConteneurFilsACoordonnees;
			if ( parent != null )
				return parent.IsCoordonneeValide ( Coordonnee, this );
			return CResultAErreur.True;
		}

		#endregion

		#region IObjetAOccupation Membres

		//---------------------------------------------
		public COccupationCoordonnees OccupationCoordonneeAppliquee
		{
			get { return OccupationCoordonneesPropre; }
		}

		//---------------------------------------------
		public IObjetAOccupation DonnateurOccupationCoordonneeHerite
		{
			get { return null; }
		}

		//---------------------------------------------
		public COccupationCoordonnees OccupationCoordonneesPropre
		{
			get
			{
				return new COccupationCoordonnees(1, null);
			}
			set
			{
			}
		}

		//---------------------------------------------
		public bool CanHeriteOccupationCoordonnees
		{
			get { return false; }
		}

		#endregion

		#region IObjetAFilsACoordonnees Membres

		public List<IObjetACoordonnees> FilsACoordonnees
		{
			get 
			{
				List<IObjetACoordonnees> lst = new List<IObjetACoordonnees>();
				CListeObjetsDonnees equipements = Equipements;
				equipements.Filtre = new CFiltreData(CEquipement.c_champIdEquipementContenant + " is null");
				equipements.InterditLectureInDB = true;
				foreach (CEquipement equipement in equipements)
					lst.Add(equipement);
				return lst;
			}
		}

		public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
		}

		public CResultAErreur VerifieCoordonneesFils()
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneesFils(this);
		}

		#endregion

		#region IObjetAOptionsDeControleDeCoordonnees Membres

		
		public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
		{
			get
			{
				return OptionsControleCoordonneesPropre;
			}
		}

		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get
			{
				return null;
			}
		}

		//------------------------------------------------------------------
		[TableFieldProperty(c_champOptionsControleCoordonnees, NullAutorise = true)]
		public int? OptionsControleCoordonneesPropreInt
		{
			get
			{
				if (Row[c_champOptionsControleCoordonnees] == DBNull.Value)
					return null;
				return (int?)Row[c_champOptionsControleCoordonnees];
			}
			set
			{
				if (value == null)
					Row[c_champOptionsControleCoordonnees] = DBNull.Value;
				else
					Row[c_champOptionsControleCoordonnees] = (int)value;
			}
		}

		//------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsControleCoordonneesPropre
		{
			get
			{
				return (EOptionControleCoordonnees?)OptionsControleCoordonneesPropreInt;
			}
			set
			{
				OptionsControleCoordonneesPropreInt = (int?)value;
			}
		}

		public bool CanHeriteOptionsControleCoordonnees
		{
			get { return false; }
		}


		public EOptionControleCoordonnees? OptionsDisponibles
		{
			get
			{
				return EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee |
					EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees |
					EOptionControleCoordonnees.IgnorerLesUnites |
					EOptionControleCoordonnees.IgnorerLoccupation |
                    EOptionControleCoordonnees.IgnorerLesEquipements | 
					EOptionControleCoordonnees.TousControles;
			}
		}

		#endregion

        #region IObjetDonneeAChamps Membres

        //----------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationStock_ChampCustomValeur(ContexteDonnee);
        }

        //----------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationStock_ChampCustomValeur.c_nomTable;
        }

        //----------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }


        #endregion

        #region IElementAChamps Membres

        //----------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                return new IDefinisseurChampCustom[] { TypeStock };
            }
        }

        //----------------------------------------------------
        public CChampCustom[] GetChampsHorsFormulaire()
        {
            if (TypeStock == null)
                return new CChampCustom[0];

            ArrayList lst = new ArrayList();
            foreach (CRelationTypeStock_ChampCustom rel in TypeStock.RelationsChampsCustomDefinis)
                lst.Add(rel.ChampCustom);

            foreach (CRelationTypeStock_Formulaire rel1 in TypeStock.RelationsFormulaires)
                foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
                    lst.Remove(rel2.Champ);

            return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

        }

        //----------------------------------------------------
        public CFormulaire[] GetFormulaires()
        {
            return CUtilElementAChamps.GetFormulaires(this);
        }

        //----------------------------------------------------
        /// <summary>
        /// liste des relations du stock avec des champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationStock_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationStock_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationStock_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

        #endregion

        #region IElementAVariables Membres

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

        #endregion




		#region IElementATypeStructurant<CTypeStock> Membres

		public CTypeStock ElementStructurant
		{
			get { return TypeStock; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeStock.c_champId];
			}
		}
		#endregion

        //-------------------------------------------------------------
        public C2iComposant3D GetComposantPhysique()
        {
            return null;
        }
	}
}
