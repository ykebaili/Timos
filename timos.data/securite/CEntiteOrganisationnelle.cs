using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using timos.data;
using timos.data.version;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using tiag.client;
using timos.data.composantphysique;
using sc2i.expression;

namespace timos.securite
{
	/// <summary>
	/// Les entités organisationnelles (EO) permettent d'organiser les entités de l'application,<br/>
    /// notamment pour les faire correspondre à des organisations opérationnelles et/ou de sécurité.<br/>
    /// Exemples :<br/>
    /// Organisation géographique : région/zone/secteur<br/>
    /// Organisation technologique : Transmission/Radio/GSM<br/>
    /// Organisation de services : Filiale/Département/service<br/>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEO)]
    [DynamicClass("Organisational entity")]
	[Table(CEntiteOrganisationnelle.c_nomTable, CEntiteOrganisationnelle.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CEntiteOrganisationnelleServeur")]
	[AutoExec("Autoexec")]
	[TiagClass(CEntiteOrganisationnelle.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_EO_ID)]
    public class CEntiteOrganisationnelle : 
		CObjetHierarchique, 
		IObjetALectureTableComplete,
		IObjetDonneeAChamps,
		IObjetACoordonnees,
		IObjetAFilsACoordonnees,
		IElementAInterfaceTiag,
        IElementLigneDeTableauPlanning,
		IElementATypeStructurant<CTypeEntiteOrganisationnelle>
	{
        public const string c_roleChampCustom = "ENT_ORGANISATI";
		
		public const string c_nomTiag = "Organisational entity";

		public const string c_nomTable = "ORGANISATIONAL_ENTITY";
		
		public const string c_champId = "OE_ID";
		public const string c_champLibelle = "OE_LABEL";

		public const string c_champCoordonnee = "OE_COOR";


		public const string c_champCodeSystemePartiel = "OE_PARTIAL_SYSTEME_CODE";
		public const string c_champCodeSystemeComplet = "OE_FULL_SYSTEME_CODE";
		public const string c_champNiveau = "OE_LEVEL";
		public const string c_champIdParent = "OE_PARENT_ID";


		/// /////////////////////////////////////////////
		public CEntiteOrganisationnelle( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CEntiteOrganisationnelle(DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Organisational entity", typeof(CEntiteOrganisationnelle),typeof(CTypeEntiteOrganisationnelle));
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
				return I.T("Organisational Entity @1|292",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
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

		//----------------------------------------------------
        /// <summary>
        /// Libellé complet de l'EO : concaténation du libellé propre à l'EO<br/>
        /// avec le libellé complet de son parent.<br/>
        /// Le caractère "/" sépare les deux libellés.
        /// </summary>
		[DynamicField("Full label")]
		public override string LibelleComplet
		{
			get
			{
				string strText = "";
				if (ObjetParent != null)
				{
					strText  = ((CObjetHierarchique)ObjetParent).LibelleComplet + "/";

					if (ObjetParent.ObjetParent == null)
					{
						int nPos = strText.IndexOf('/');
						if (nPos >= 0)
							strText = strText.Substring(nPos + 1);
					}
				}
				strText += Libelle;
				return strText;
			}
		}

		//---------------------------------------------------
        /// <summary>
        /// Libellé propre à l'EO
        /// </summary>
		[sc2i.common.DescriptionField]
        [TableFieldProperty(c_champLibelle, 255)]
		[sc2i.common.DynamicField("Label")]
		[TiagField("Label")]
		public override string Libelle
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
		/// Utilisé par TIAG pour affecter le type d'entité par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetEntityTypeKeys(object[] lstCles)
		{
			CTypeEntiteOrganisationnelle typeEntite = new CTypeEntiteOrganisationnelle(ContexteDonnee);
			if (typeEntite.ReadIfExists(lstCles))
				TypeEntite = typeEntite;
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Type de l'entité organisationnelle
        /// </summary>
        [DynamicField("Organisational entity type")]
		[TiagRelation ( typeof(CTypeEntiteOrganisationnelle), "TiagSetEntityTypeKeys")]
		[Relation ( CTypeEntiteOrganisationnelle.c_nomTable,
            CTypeEntiteOrganisationnelle.c_champId,
            CTypeEntiteOrganisationnelle.c_champId,
            true,
            true,
            true )]
        public CTypeEntiteOrganisationnelle TypeEntite
        {
            get
            {
                return (CTypeEntiteOrganisationnelle)GetParent(CTypeEntiteOrganisationnelle.c_champId, typeof(CTypeEntiteOrganisationnelle));
            }
			set
			{
				if (EntiteParente != null && EntiteParente.TypeEntite != null)
					SetParent(CTypeEntiteOrganisationnelle.c_champId, EntiteParente.TypeEntite.TypeFils);
				else
					SetParent(CTypeEntiteOrganisationnelle.c_champId, value);
			}
        }

		//----------------------------------------------------
		public override int NbCarsParNiveau
		{
			get
			{
				return 2;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemePartiel
		{
			get
			{
				return c_champCodeSystemePartiel;
			}
		}

		//----------------------------------------------------
		public override string ChampCodeSystemeComplet
		{
			get
			{
				return c_champCodeSystemeComplet;
			}
		}

		//----------------------------------------------------
		public override string ChampNiveau
		{
			get
			{
				return c_champNiveau;
			}
		}

		//----------------------------------------------------
		public override string ChampLibelle
		{
			get
			{
				return c_champLibelle;
			}
		}

		//----------------------------------------------------
		public override string ChampIdParent
		{
			get
			{
				return c_champIdParent;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Utilisé par TIAG pour affecter le l'entité parente par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetParentEntityKeys(object[] lstCles)
		{
			CEntiteOrganisationnelle entite = new CEntiteOrganisationnelle(ContexteDonnee);
			if (entite.ReadIfExists(lstCles))
				EntiteParente = entite;
		}

		//----------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Entité organisationnelle parente dans la hiérarchie
		/// </summary>
		[Relation ( 
			c_nomTable,
			c_champId,
			c_champIdParent,
			false,
			false )]
		[DynamicField("Parent entity")]
		[TiagRelation(typeof(CEntiteOrganisationnelle), "TiagSetParentEntityKeys")]
		public CEntiteOrganisationnelle EntiteParente
		{
			get
			{
				return (CEntiteOrganisationnelle)ObjetParent;
			}
			set
			{
				ObjetParent = value;
				if ( value != null && value.TypeEntite != null )
					TypeEntite = EntiteParente.TypeEntite.TypeFils;
			}
		}

		//----------------------------------------------------
		/// <summary>
		/// Retourne la liste des Entités organisationnelles filles dans la hiérarchie
		/// </summary>
		[RelationFille ( typeof ( CEntiteOrganisationnelle ), "EntiteParente" )]
		[DynamicChilds ( "Child entities", typeof ( CEntiteOrganisationnelle ))]
		public CListeObjetsDonnees EntiteFilles
		{
			get
			{
				return ObjetsFils;
			}
		}


		//----------------------------------------------------
        /// <summary>
        /// Code système propre à l'entité organisationnelle.<br/>
        /// Ce code est exprimé sur 2 caractères alphanumériques,<br/>
        /// il est unique dans son parent.
        /// </summary>
		[TableFieldProperty ( c_champCodeSystemePartiel, 2 )]
		[DynamicField("Partial system code")]
		[TiagField("Partial system code")]
		public override string CodeSystemePartiel
		{
			get
			{
				string strVal = "";
				if (Row[c_champCodeSystemePartiel] != DBNull.Value)
					strVal = (string)Row[c_champCodeSystemePartiel];
				strVal = strVal.Trim().PadLeft(2, '0');
				return strVal;
			}
		}

		//----------------------------------------------------
        /// <summary>
        /// Code système complet de l'entité organisationnelle. Ce code système est<br/>
        /// constitué du code système complet de l'EO parente<br/>
        /// concaténé avec le code système propre de l'EO.<br/>
        /// Exemple : Monde -> Madagascar -> Diego<br/>
        /// si le code de Monde est 01, le code de Madagascar est 03 et<br/>
        /// et le code propre de Diego est 08, le code système complet<br/>
        /// de Diego est 010308.
        /// </summary>
		[TableFieldProperty ( c_champCodeSystemeComplet, 100 )]
		[DynamicField("Full system code")]
		[TiagField ("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeSystemeComplet];
			}
		}

		//----------------------------------------------------
        /// <summary>
        /// Niveau de l'EO dans la hiérarchie des EO (nombre de parents).<br/>
        /// Exemple : Monde -> Madagascar -> Diego<br/>
        /// Monde a pour niveau 0, Madagascar a pour niveau 1<br/>
        /// (1 parent en remontant la hiérarchie), Diego a pour niveau 2<br/>
        /// (2 parents en remontant la hiérarchie)
        /// </summary>
		[TableFieldProperty ( c_champNiveau )]
		[DynamicField("Level")]
		[TiagField("Level")]
		public override int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
		}

		#region IElementAChamps Membres

		//----------------------------------------------------
		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return new IDefinisseurChampCustom[] { TypeEntite };
			}
		}

		//----------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			if ( TypeEntite == null )
				return new CChampCustom[0];

			ArrayList lst = new ArrayList();
			foreach (CRelationTypeEO_ChampCustom rel in TypeEntite.RelationsChampsCustomDefinis)
				lst.Add(rel.ChampCustom);
			return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

		}

		//----------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
		}

		//----------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations de l'EO avec les champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationEO_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationEO_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
		{
			get 
			{
				return GetDependancesListe(CRelationEO_ChampCustom.c_nomTable, c_champId);
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
        
        //----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationEO_ChampCustom.c_nomTable;
		}

		//----------------------------------------------------
		public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = RelationsChampsCustom;
			liste.InterditLectureInDB = true;
			liste.Filtre = new CFiltreData(CChampCustom.c_champId + "=@1", nIdChamp);
			return liste;
		}

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationEO_ChampCustom(ContexteDonnee);
		}


		#endregion

		//-------------------------------------------------------------
		public CEntiteOrganisationnelle GetParent(CTypeEntiteOrganisationnelle tpEO)
		{
			if (TypeEntite == tpEO)
				return this;
			if (EntiteParente != null)
				return EntiteParente.GetParent(tpEO);
			return null;
		}

		//-------------------------------------------------------------
		public CEntiteOrganisationnelle[] GetChilds(CTypeEntiteOrganisationnelle tpEO)
		{
			List<CEntiteOrganisationnelle> lst = new List<CEntiteOrganisationnelle>();
			if ( tpEO.IsChildOf ( TypeEntite ) )
				FillListeChildsType(tpEO, lst);
			return lst.ToArray();
		}

		//-------------------------------------------------------------
		private void FillListeChildsType(CTypeEntiteOrganisationnelle tpEO, List<CEntiteOrganisationnelle> lst)
		{
			if (TypeEntite.Equals(tpEO))
				lst.Add(this);
			else
			{
				foreach (CEntiteOrganisationnelle eo in EntiteFilles)
					eo.FillListeChildsType(tpEO, lst);
			}
		}


		#region Coordonnee
		//---------------------------------------------------------------
        /// <summary>
        /// Coordonnée propre à l'EO
        /// </summary>
		[TableFieldProperty(c_champCoordonnee, 255)]
		[DynamicField("Coordinate")]
		public string Coordonnee
		{
			get
			{
				return (string)Row[c_champCoordonnee];
			}
			set
			{
				Row[c_champCoordonnee] = value;
			}
		}

		//--------------------------------------------------------------
        /// <summary>
        /// Coordonnée complète de l'EO : elle est construite par la<br/>
        /// concaténation de la coordonnée complète de l'EO parente, <br/>
        /// avec la coordonnée propre de l'EO.
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

		//--------------------------------------------
        /// <summary>
        /// Coordonnée complète de l'EO parente
        /// </summary>
		[DynamicField("Parent Coordinate")]
		public string CoordonneeParente
		{
			get
			{
				if (EntiteParente != null && (EntiteParente.Coordonnee != "" && EntiteParente.Coordonnee != null))
					return EntiteParente.CoordonneeComplete;
				else
					return "";

			}
		}

		#region IObjetACoordonnees


		public bool IgnorerUnite
		{
			get { return true; }
		}

		public IObjetAFilsACoordonnees ConteneurFilsACoordonnees
		{
			get 
			{
				if (EntiteParente != null)
					return (IObjetAFilsACoordonnees)EntiteParente;
				else
					return null;
			}
		}

		public CResultAErreur VerifieCoordonnee()
		{
			IObjetAFilsACoordonnees parent = ConteneurFilsACoordonnees;
			if (parent != null)
				return parent.IsCoordonneeValide(Coordonnee, this);
			return CResultAErreur.True;
		}

		#endregion

		#region IObjetAOccupation
		

		public COccupationCoordonnees OccupationCoordonneeAppliquee
		{
			get 
			{
				return null;
			}
		}

		public IObjetAOccupation DonnateurOccupationCoordonneeHerite
		{
			get 
			{
				return this;
			}
		}

		public COccupationCoordonnees OccupationCoordonneesPropre
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool CanHeriteOccupationCoordonnees
		{
			get 
			{ return false; }
		}

		#endregion

		#region IObjetAFilsACoordonnees

		public List<IObjetACoordonnees> FilsACoordonnees
		{
			get 
			{
				//Retourne les entites organisationnelles fille ainsi que les sites
				//pointant vers l'entite organisationnelle

				List<IObjetACoordonnees> lstFils = new List<IObjetACoordonnees>();
				foreach(CObjetDonnee o in EntiteFilles)
				{
					CEntiteOrganisationnelle e = (CEntiteOrganisationnelle) o;
					lstFils.Add(e); 
				}

				CFiltreData filtresites = new CFiltreData(CSite.c_champEOCoor + " = @1", this.Id);
				CListeObjetsDonnees lstsites = new CListeObjetsDonnees(ContexteDonnee, typeof(CSite), filtresites);
				foreach (CObjetDonnee o in lstsites)
				{
					CSite s = (CSite)o;
					lstFils.Add(s);
				}

				return lstFils;
			}
		}

		public CResultAErreur IsCoordonneeValide(string strCoordonnee, IObjetACoordonnees objet)
		{
			return SObjetAvecFilsAvecCoordonnees.VerifieCoordonneeFils(this, objet, strCoordonnee);
		}

		public CResultAErreur VerifieCoordonneesFils()
		{
			CResultAErreur result = CResultAErreur.True;
			foreach(IObjetACoordonnees obj in FilsACoordonnees)
			{
				CResultAErreur r = obj.VerifieCoordonnee();
				if(!r)
				{
					result.Result = false;
					result.Erreur += r.Erreur;
				}
			}
			return result;
		}

		#endregion

		#region IObjetASystemeDeCoordonnee
        /// <summary>
        /// Renvoie le système de coordonnée associé à l'EO
        /// </summary>
		[DynamicField("Coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get 
			{ 
				return TypeEntite.ParametrageCoordonneesPropre;
			}
		}

		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get { return null; }
		}

		public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
		{
			get { return null; }
		}

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

		#region IObjetAOptionsDeControleDeCoordonnees

		//---------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsDisponibles
		{
			get
			{
				return EOptionControleCoordonnees.AutoriserPlusieursFilsSurLaMemeCoordonnee |
					EOptionControleCoordonnees.IgnorerLesFilsSansCoordonnees;
			}
		}

		public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
		{
			get 
			{
				return TypeEntite.OptionsControleCoordonneesApplique;
			}
		}

		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get { return TypeEntite; }
		}

		public EOptionControleCoordonnees? OptionsControleCoordonneesPropre
		{
			get
			{
				return OptionsControleCoordonneesApplique;
			}
			set
			{
				
			}
		}

		public bool CanHeriteOptionsControleCoordonnees
		{
			get { return false; }
		}

		#endregion

		#endregion


		#region IElementATypeStructurant<CTypeEntiteOrganisationnelle> Membres

		public CTypeEntiteOrganisationnelle ElementStructurant
		{
			get { return TypeEntite; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeEntiteOrganisationnelle.c_champId];
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
