using System;
using System.Collections;

using sc2i.data;
using sc2i.common;
using sc2i.process;
using sc2i.data.dynamic;

using timos.data.version;
using tiag.client;
using sc2i.expression;

namespace sc2i.workflow
{
	#region RelationElementToDossier
	[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationElementToDossierAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CDossierSuivi.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 1400;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
				return "DOSSIER";
			}
		}

		
		public override string ChampId
		{
			get
			{
				return CDossierSuivi.c_champIdElementLie;
			}
		}

		public override string ChampType
		{
			get
			{
				return CDossierSuivi.c_champTypeElementLie;
			}
		}
		
		public override bool Composition
		{
			get
			{
				return true;
			}
		}
		public override bool CanDeleteToujours
		{
			get
			{
				//A besoin de vérifier les champs customs
				return false;
			}
		}

		public override string NomConvivialPourParent
		{
			get
			{
				return I.T("Dossiers|20078");
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return tp.IsSubclassOf ( typeof(CObjetDonneeAIdNumerique) );
		}
	}
	#endregion

	/// <summary>
	/// Un dossier est une entité qui permet d'associer des informations supplémentaires à une entité<br/>
    /// quelconque du système que l'on désigne par l'expression 'Objet suivi par le dossier',<br/>
    /// et de décrire une relation entre cet objet suivi et un ou plusieurs autres objets de l'application,<br/>
    /// appelés 'Objets liés'. Les dossiers peuvent être associés à n'importe quelle entité de TIMOS.
    /// <br/>
    /// <br/>
    /// Des formulaires personnalisés peuvent être associés au dossier.<br/>
    /// Un dossier peut inclure un ou plusieurs sous-dossiers. Ces sous-dossiers peuvent eux-mêmes inclure<br/>
    /// des liens et des sous-dossiers; la décomposition est hiérarchique.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iDossier)]
    [DynamicClass("Workbook")]
	[ObjetServeurURI("CDossierSuiviServeur")]
	[Table(CDossierSuivi.c_nomTable, CDossierSuivi.c_champId,true)]
	[AutoExec("Autoexec")]
	[RelationElementToDossier]
    [TiagClass(CDossierSuivi.c_nomTiag, "Id", true)]
	public class CDossierSuivi : 
		CElementAChamp,
		IElementAEvenementsDefinis, 
		IObjetDonneeAutoReference, 
		IElementALien,
		IElementATypeStructurant<CTypeDossierSuivi>,
        IElementAInterfaceTiag
	{
		public const string c_roleChampCustom = "WORKBOOK";

        public const string c_nomTiag = "WorkBook";

		#region Déclaration des constantes
		public const string c_nomTable = "WORKBOOK";
		public const string c_champId = "WRKBK_ID";
		public const string c_champLibelle = "WRKBK_LABEL";
		public const string c_champDateOuverture = "WRKBK_OPEN_DATE";
		public const string c_champCommentaire = "WRKBK_COMMENT";
		public const string c_champEstOuvert = "WRKBK_IS_OPEN";
		public const string c_champTypeElementLie = "WRKBK_ELEMENT_TYPE";
		public const string c_champIdElementLie = "WRKBK_ELEMENT_ID";
		public const string c_champCle = "WRKBK_KEY";
		public const string c_champIdDossierParent = "WRKBK_PARENT_WKB_ID";

		#endregion
		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "WorkBook", typeof(CDossierSuivi),typeof(CTypeDossierSuivi));
		}

        //-------------------------------------------------------------------
        public override CRoleChampCustom RoleChampCustomAssocie
        {
            get { return CRoleChampCustom.GetRole(c_roleChampCustom); }
        }

		//-------------------------------------------------------------------
#if PDA
		public CDossierSuivi()
			:base()
		{
		}
#endif
		//-------------------------------------------------------------------
		public CDossierSuivi( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CDossierSuivi( System.Data.DataRow row )
			:base(row)
		{
		}
		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
			DateOuverture = DateTime.Now;
			EstOuvert = true;
			ElementSuivi = null;
		}
		//-------------------------------------------------------------------
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateOuverture+ " desc"};
		}
		//-------------------------------------------------------------------
		public override string ToString()
		{
			return Libelle;
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("WorkBook @1|305", Libelle);
			}
		}
		
		
		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Libellé du dossier
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
        [DescriptionField]
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

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit un Commentaire sur le dossier
		/// </summary>
		[
		TableFieldProperty(c_champCommentaire, 2048),
        TiagField("Comment"),
		DynamicField("Comment")
		]
		public string Commentaires
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

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Date d'ouverture du dossier
		/// </summary>
		[TableFieldProperty(c_champDateOuverture)]
		[DynamicField("Opening date")]
		[DefaultFormat("d")]
        [TiagField("Opening date")]
		public DateTime DateOuverture
		{
			get
			{
				return ((DateTime)Row[c_champDateOuverture]);
			}
			set
			{
				Row[c_champDateOuverture] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Booléen indiquant que le dossier est ouvert (ou en cours).
        /// VRAI si en cours, FALSE dans le cas contraire.
		/// </summary>
		[TableFieldProperty(c_champEstOuvert)]
		[DynamicField("Is open")]
        [TiagField("Is open")]
		public bool EstOuvert
		{
			get
			{
				return ( bool )Row[c_champEstOuvert];
			}
			set
			{
				Row[c_champEstOuvert] = value;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Type de dossier correspondant
		/// </summary>
		[Relation(CTypeDossierSuivi.c_nomTable, CTypeDossierSuivi.c_champId, CTypeDossierSuivi.c_champId, true, false, true)]
		[DynamicField("Workbook type")]
        [TiagRelation(typeof(CTypeDossierSuivi), CAssociationTiag.c_methodeUseDelegate)]
		public CTypeDossierSuivi TypeDossier
		{
			get
			{
				return (CTypeDossierSuivi)GetParent ( CTypeDossierSuivi.c_champId, typeof(CTypeDossierSuivi));
			}
			set
			{
				SetParent ( CTypeDossierSuivi.c_champId, value );
				if ( Libelle.Trim() == "" && value != null)
					Libelle = value.Libelle;
			}
		}
		
		//-------------------------------------------------------------------
		public override IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return new IDefinisseurChampCustom[]{TypeDossier};
			}
		}

		//-------------------------------------------------------------------
		public override CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationDossierSuivi_ChampCustom(ContexteDonnee);
		}

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du dossier avec des chjamps personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationDossierSuivi_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationDossierSuivi_ChampCustom))]
		public override CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe ( CRelationDossierSuivi_ChampCustom.c_nomTable, GetChampId() );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des relation du dossier avec les éléments liés
		/// </summary>
		[RelationFille(typeof(CRelationDossierSuivi_Element), "DossierSuivi")]
		[DynamicChilds("Elements relations", typeof(CRelationDossierSuivi_Element))]
		public CListeObjetsDonnees RelationsElements
		{
			get
			{
				return GetDependancesListe ( CRelationDossierSuivi_Element.c_nomTable, GetChampId() );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne le premier élément lié au dossier à partir de son code de lien
        /// (le code du lien permettant de codifier la relation)
		/// </summary>
		/// <param name="strCode">Code du lien</param>
		/// <returns>Le premier élément s'il existe, sinon null</returns>
		[DynamicMethod("Return an element related to the WorkBook with his link code")]
		public CObjetDonneeAIdNumerique GetElementLie ( string strCode )
		{
			strCode = strCode.ToUpper();
			foreach (CRelationDossierSuivi_Element rel in RelationsElements )
				if ( rel.RelationParametre_TypeElement.Code.ToUpper() == strCode )
					return rel.ElementLie;
			return null;
		}

		
		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne le tableau des éléments liés au dossier à partir du code de lien
        /// (le code de lien permettant de codifier la relation)
        /// </summary>
        /// <param name="strCode">Code de lien</param>
        /// <returns>Tableau des éléments liés (peut être vide)</returns>
		[DynamicMethod("Return elements related to the WorkBook with his link code")]
		public CObjetDonneeAIdNumerique[] GetElementsLies ( string strCode )
		{
			ArrayList lst = new ArrayList();
			strCode = strCode.ToUpper();
            if (Row.RowState == System.Data.DataRowState.Deleted)
                VersionToReturn = System.Data.DataRowVersion.Original;
            CListeObjetsDonnees lstElts = RelationsElements;
            if (Row.RowState == System.Data.DataRowState.Deleted)
                lstElts.RowStateFilter = System.Data.DataViewRowState.Deleted;
            foreach (CRelationDossierSuivi_Element rel in lstElts)
            {
                if (rel.Row.RowState == System.Data.DataRowState.Deleted)
                    rel.VersionToReturn = System.Data.DataRowVersion.Original;
                if (rel.RelationParametre_TypeElement.Code.ToUpper() == strCode)
                    lst.Add(rel.ElementLie);
            }
			return (CObjetDonneeAIdNumerique[])lst.ToArray(typeof(CObjetDonneeAIdNumeriqueAuto));
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Ajoute au dossier un lien vers un élément.
        /// Si le lien vers élément est multiple (défini au niveau du type de lien),
        /// un lien vers cet élément est ajouté, dans le cas contraire (lien simple), l'élément lié
        /// éventuellement existant est remplacé par l'élément ajouté.
		/// </summary>
		/// <param name="element">L'élément</param>
		/// <param name="strCode">Le code du lien entre le dossier et l'élément</param>
		/// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod(typeof(bool),"Bind an element to the WorkBook with his link code. If there is a multiple link the element is added else it replaces the preceding element",
			 "Element to link",
			 "Link Type Code" )]
		public bool AddElementLie ( CObjetDonneeAIdNumerique element, string strCode )
		{
			if ( element == null )
				return false;
			ArrayList lst = new ArrayList();
			CListeObjetsDonnees liste = TypeDossier.RelationsTypesElements;
			liste.Filtre = new CFiltreData ( CRelationTypeDossierSuivi_TypeElement.c_champCode+"=@1",strCode );
			if ( liste.Count == 0 )
				return false;
			CRelationTypeDossierSuivi_TypeElement relType = (CRelationTypeDossierSuivi_TypeElement)liste[0];
			return AddElementLieSurType ( element, relType );
		}

		public bool AddElementLieSurType(CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relType)
		{
			if ( element == null )
				return false;
			Hashtable tableRelationsExistantes = new Hashtable();
			
			CRelationDossierSuivi_Element laRelation = null;
			foreach (CRelationDossierSuivi_Element rel in RelationsElements )
				if ( rel.RelationParametre_TypeElement.Id == relType.Id )
				{
					laRelation = rel;
					tableRelationsExistantes[rel.ElementLie] = rel;
				}

			bool bCreate = false;
			if ( relType.Multiple && element != null)
			{
				if ( tableRelationsExistantes[element] == null )
					bCreate = true;
			}
			else
			{
				if ( tableRelationsExistantes.Count != 0 )
				{
					laRelation.ElementLie = element;
				}
				else
					bCreate = true;
			}
			if ( bCreate )
			{
				CRelationDossierSuivi_Element rel = new CRelationDossierSuivi_Element(ContexteDonnee);
				rel.CreateNewInCurrentContexte();
				rel.DossierSuivi = this;
				rel.ElementLie = element;
				rel.RelationParametre_TypeElement = (CRelationTypeDossierSuivi_TypeElement)relType;
			}
			return true;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Supprime du dossier le lien vers un élément, à partir de l'élément et du code du lien
		/// </summary>
		/// <param name="element">L'élément</param>
		/// <param name="strCode">Le code du lien</param>
		/// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod(typeof(bool),"Cancel the link of element to WorkBook with the Link Type Code",
			 "Element to link",
			"Link Type Code")]
		public bool DelieElement ( CObjetDonneeAIdNumerique element, string strCode )
		{
			if ( element == null )
				return false;
			foreach ( CRelationDossierSuivi_Element relation in this.RelationsElements )
			{
				if ( relation.ElementLie.Equals ( element ) && relation.RelationParametre_TypeElement.Code == strCode )
				{
					relation.Delete();
					return true;
				}
			}
			return false;
		}

		

		public bool DelieElementSurType(CObjetDonneeAIdNumerique element, IRelationTypeElementALien_TypeElement relationType)
		{
			if ( element == null )
				return false;
			foreach ( CRelationDossierSuivi_Element relation in this.RelationsElements )
			{
				if ( relation.ElementLie.Equals ( element ) && relation.RelationParametre_TypeElement.Id == relationType.Id)
				{
					relation.Delete();
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Interne : Type de l'élément suivi
		/// </summary>
		[TableFieldProperty(c_champTypeElementLie, 1024)]
		[IndexField]
        [TiagField("Associated element type")]
		public string StringTypeElementSuivi
		{
			get
			{
				return (string)Row[c_champTypeElementLie];
			}
			set
			{
				Row[c_champTypeElementLie] = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Type TypeElementSuivi
		{
			get
			{
				return CActivatorSurChaine.GetType ( StringTypeElementSuivi );
			}
			set
			{
				if ( value != null )
					StringTypeElementSuivi = value.ToString();
				else
					StringTypeElementSuivi = "";
			}
		}

		/// <summary>
		/// Interne : Id de l'élément suivi
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElementLie)]
		[IndexField]
        [TiagField("Associated element id")]
		public int IdElementSuivi
		{
			get
			{
				return (int)Row[c_champIdElementLie];
			}
			set
			{
				Row[c_champIdElementLie] = value;
			}
		}

		/// <summary>
		/// Donne ou définit l'élément suivi par le dossier
		/// </summary>
		[DynamicFieldAttribute("Element")]
		public CObjetDonneeAIdNumerique ElementSuivi
		{
			get
			{
				Type tp = TypeElementSuivi;
				if ( tp == null )
					return null;
				CObjetDonneeAIdNumerique obj = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tp, new object[]{ContexteDonnee});
				if ( obj.ReadIfExists ( IdElementSuivi) )
					return obj;
				return null;
			}
			set
			{
				if ( value == null )
				{
					TypeElementSuivi = null;
					IdElementSuivi = -1;
				}
				else
				{
					TypeElementSuivi = value.GetType();
					IdElementSuivi = value.Id;
				}
			}
		}


		/// ///////////////////////////////////////////////////////////////////////
		public static CListeObjetsDonnees GetListeDossiersForElement ( CObjetDonneeAIdNumerique objet )
		{
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( objet.ContexteDonnee, typeof( CDossierSuivi ) );
			if ( objet == null )
			{
				liste.Filtre = new CFiltreDataImpossible();
				return liste;
			}
			liste.Filtre = new CFiltreData ( c_champTypeElementLie +"=@1 and "+
				c_champIdElementLie+"=@2",
				objet.GetType().ToString(),
				objet.Id );
			return liste;
		}

		/// ///////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Identifiant du dossier. Ce champ peut être utilisé par les process
		/// pour éviter de créer plusieurs fois le même dossier.
		/// </summary>
		[TableFieldProperty(c_champCle, 256)]
		[DynamicField("Key")]
        [TiagField("Key")]
		public string Cle
		{
			get
			{
				return (string)Row[c_champCle];
			}
			set
			{
				Row[c_champCle] = value;
			}
		}

		/// ///////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Donne ou définit le Dossier parent auquel appartient ce dossier de suivi
		/// </summary>
		[Relation ( CDossierSuivi.c_nomTable,
			 CDossierSuivi.c_champId,
			 c_champIdDossierParent,
			 false,
			 true,
			 true)]
		[DynamicField("Parent workbook")]
        [TiagRelation(typeof(CDossierSuivi), CAssociationTiag.c_methodeUseDelegate)]
		public CDossierSuivi DossierParent
		{
			get
			{
				return( CDossierSuivi)GetParent ( c_champIdDossierParent, typeof(CDossierSuivi) );
			}
			set
			{
				SetParent ( c_champIdDossierParent, value );
			}
		}

		/// ///////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Retourne la liste des sous-dossiers de ce dossier de suivi
		/// </summary>
		[RelationFille(typeof(CDossierSuivi), "DossierParent")]
		[DynamicChilds("Childs workbooks", typeof ( CDossierSuivi ) )]
		public CListeObjetsDonnees DossiersFils
		{
			get
			{
				return GetDependancesListe ( CDossierSuivi.c_nomTable, c_champIdDossierParent );
			}
		}

		/// ///////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Retourne le filtre qui indique les éléments autorisés comme étant éléments suivis
		/// </summary>
		public CFiltreData GetFiltreDataElementSuivi()
		{
			CFiltreDynamique filtreDynamique = TypeDossier.FiltreDynamiqueElementsSuivisPossibles;
			if ( filtreDynamique == null )
				return null;
			try
			{
				foreach ( IVariableDynamique variable in filtreDynamique.ListeVariables )
					if ( variable.Nom == CTypeDossierSuivi.c_nomChampDossier )
					{
						filtreDynamique.SetValeurChamp ( variable , this );
						break;
					}
				CResultAErreur result = filtreDynamique.GetFiltreData();
				if ( result )
					return (CFiltreData)result.Data;
			}
			catch
			{
			}
			return null;
		}
		
		#region Membres de IElementAEvenementsDefinis

			public IDefinisseurEvenements[] Definisseurs
		{
			get
			{
				return new IDefinisseurEvenements[]{TypeDossier};
			}
		}

		public bool IsDefiniPar(IDefinisseurEvenements definisseur)
		{
			if ( definisseur == null )
				return false;
			return definisseur.Equals(TypeDossier);
		}

		#endregion

		#region Membres de IElementALien

		public ITypeElementALien TypeElementALien
		{
			get
			{
				return TypeDossier;
			}
			set
			{
				TypeDossier = (CTypeDossierSuivi)value;
			}
		}

		#endregion



		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdDossierParent; }
		}

		public string ProprieteListeFils
		{
			get { return "DossiersFils"; }
		}

		#endregion

		#region IElementATypeStructurant<CTypeDossierSuivi> Membres

		public CTypeDossierSuivi ElementStructurant
		{
			get { return TypeDossier; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeDossierSuivi.c_champId];
			}
		}

		#endregion

        #region IElementAInterfaceTiag Membres
        //-------------------------------------------------------
        public object[] TiagKeys
        {
            get { return new object[] { Id }; }
        }

        //-------------------------------------------------------
        public string TiagType
        {
            get { return c_nomTiag; }
        }

        #endregion
    }
}
