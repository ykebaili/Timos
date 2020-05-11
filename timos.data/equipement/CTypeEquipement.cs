using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;


using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using sc2i.process;

using sc2i.workflow;
using timos.data;
using timos.securite;
using tiag.client;
using System.Data;
using timos.data.equipement;
using timos.data.composantphysique;
using timos.data.commandes;
using sc2i.expression;


namespace timos.data
{
	/// <summary>
	/// Definit le type des <see cref="CEquipement">Equipements</see>.<br/>
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEquipement)]
    [DynamicClass("Equipment type")]
	[ObjetServeurURI("CTypeEquipementServeur")]
	[Table(CTypeEquipement.c_nomTable, CTypeEquipement.c_champId,true)]
	[FullTableSync]
	[AutoExec("Autoexec")]
	[TiagClass ( CTypeEquipement.c_nomTiag, "Id", true )]
    [DynamicIcon(typeof(CEquipement), ETypeIconeDynamique.EType)]
	public class CTypeEquipement : CObjetDonneeAIdNumeriqueAuto, 
		IDefinisseurEvenements,
		IObjetDonneeAChamps,
		IElementAEO,
		IObjetASystemeDeCoordonnee,
		IObjetAOptionsDeControleDeCoordonnees,
		IObjetAOccupation,
		IElementAInterfaceTiag,
        IDefinisseurSymbole,
        IElementCommandable
	{
		#region Déclaration des constantes
		public const string c_nomTiag = "Equipment type";

		public const string c_roleChampCustom = "EQUIPMENT_TYPE";
		
		public const string c_nomTable = "EQUIPMENT_TYPE";
		public const string c_champId = "EQTTYP_ID";
		public const string c_champLibelle = "EQTTYP_LABE";
		public const string c_champCode = "EQTTYP_CODE";
		public const string c_champMnemonique = "TYPEEQT_MNEMONIC";

		public const string c_champStockAlerte = "EQTTYP_STOCK_ALERT";
		public const string c_champStockCritique = "EQTTYP_STOCK_CRITICAL";
		public const string c_champStockOptimal = "EQTTYP_STOCK_OPTIMAL";

		public const string c_champTypeAbstrait = "EQTTYP_ABSTRACT";

		public const string c_champNbUnitesOccupation = "EQTTYP_UNITS_NB";
        public const string c_champUniteOccupation = "EQPT_OCCUPATION_UNIT_ID";
		public const string c_champOptionsControleCoordonnees = "EQTTYP_OPT_CTRL_COORD";
        public const string c_champIsDotation = "EQPTTYP_DOTATION";

		public const string c_champCreationLogiqueAutomatique = "EQPTTYP_AUTO_CREATE_LGCL";

		#endregion

		//-------------------------------------------------------------------
		public CTypeEquipement( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTypeEquipement( System.Data.DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Equipment type", typeof(CTypeEquipement), typeof(CFamilleEquipement));
		}

		//-------------------------------------------------------------------
		public override CFiltreData FiltreStandard
		{
			get
			{
				CFiltreData filtre = CFiltreData.GetAndFiltre(base.FiltreStandard,
					new CFiltreData(c_champTypeAbstrait + "=@1", false));
				return filtre;
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
			StockAlerte = 0;
			StockCritique = 0;
			StockOptimal = 0;
			IsAbstrait = false;
			CreationAutomatiqueEquipementLogique = false;
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Equipment Type @1|272", Libelle);
			}
		}

		/// ///////////////////////////////////////////////////////
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

        
		//-------------------------------------------------------------------
		/// <summary>
		/// Libellé du Type d'Equipement<br/>
		/// (obligatoire)
		/// </summary>
        [DescriptionField]
		[TableFieldProperty(c_champLibelle, 255)]
        [DynamicField("Label")]
		[RechercheRapide]
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
		/// Relations aux types parents (dont celui-ci hérite)
		/// </summary>
		[RelationFille ( typeof ( CRelationTypeEquipement_Heritage ), "TypeFils" )]
		[DynamicChilds("Parent types relations", typeof ( CRelationTypeEquipement_Heritage ) )]
		public CListeObjetsDonnees RelationsTypesParents
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipement_Heritage.c_nomTable, CRelationTypeEquipement_Heritage.c_champIdTypeFils);
			}
		}

		
		//-------------------------------------------------------------------
		/// <summary>
		/// Relations aux type fils ( héritiers de celui-ci)
		/// </summary>
		[RelationFille ( typeof ( CRelationTypeEquipement_Heritage ), "TypeParent")]
		[DynamicChilds("Child types relations", typeof ( CRelationTypeEquipement_Heritage ) )]
		public CListeObjetsDonnees RelationsTypesFils
		{
			get
			{
				return GetDependancesListe (CRelationTypeEquipement_Heritage.c_nomTable, CRelationTypeEquipement_Heritage.c_champIdTypeParent );
			}
		}

		//-------------------------------------------------------------------
		public CTypeEquipement[] TousLesTypesParents
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillTypesParents ( tbl );
				CTypeEquipement [] lst = new CTypeEquipement[tbl.Count];
				int nIndex = 0;
				foreach ( CTypeEquipement eqt in tbl.Keys )
					lst[nIndex++] = eqt;
				return lst;
			}
		}

		//-------------------------------------------------------------------
		public CTypeEquipement[] TousLesTypesParentsEtThis
		{
			get
			{
				Hashtable tbl = new Hashtable();
				tbl[this] = true;
				FillTypesParents(tbl);
				CTypeEquipement[] lst = new CTypeEquipement[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipement eqt in tbl.Keys)
					lst[nIndex++] = eqt;
				return lst;
			}
		}

		//-------------------------------------------------------------------
		private void FillTypesParents(Hashtable tbl)
		{
			foreach (CRelationTypeEquipement_Heritage heri in RelationsTypesParents)
			{
				tbl[heri.TypeParent] = true;
				heri.TypeParent.FillTypesParents(tbl);
			}
		}


		//-------------------------------------------------------------------
		public CTypeEquipement[] TousLesTypesFils
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillTypesFils(tbl);
				CTypeEquipement[] lst = new CTypeEquipement[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipement eqt in tbl.Keys)
					lst[nIndex++] = eqt;
				return lst;
			}
		}

		//-------------------------------------------------------------------
		private void FillTypesFils(Hashtable tbl)
		{
			foreach (CRelationTypeEquipement_Heritage heri in RelationsTypesFils)
			{
				tbl[heri.TypeFils] = true;
				heri.TypeFils.FillTypesFils(tbl);
			}
		}
	
		#region IDefinisseurChampCustom Membres

        //-------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEquipement_ChampCustom), "Definisseur")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeEquipement_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_ChampCustom.c_nomTable, CTypeEquipement.c_champId);
            }
        }

        //-------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEquipement_Formulaire), "Definisseur")]
        [DynamicChilds("Forms relations", typeof(CRelationTypeEquipement_Formulaire))]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_Formulaire.c_nomTable, CTypeEquipement.c_champId);
            }
        }



		//-------------------------------------------------------------------
		public CChampCustom[] GetTousLesChampsAssocies ( string strCodeRole )
		{
			Hashtable tableChamps = new Hashtable();
			FillHashtableChamps(tableChamps, strCodeRole);
			CChampCustom[] liste = new CChampCustom[tableChamps.Count];
			int nChamp = 0;
			foreach (CChampCustom champ in tableChamps.Values)
				liste[nChamp++] = champ;
			return liste;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Remplit une hashtable IdChamp->Champ
		/// avec tous les champs liés.(hiérarchique
		/// </summary>
		/// <param name="tableChamps">HAshtable à remplir</param>
		private void FillHashtableChamps(Hashtable tableChamps, string strCodeRole )
		{
			foreach (IRelationDefinisseurChamp_ChampCustom relation in RelationsChampsCustomListe)
			{
				if (relation.ChampCustom.CodeRole == strCodeRole)
					tableChamps[relation.ChampCustom.Id] = relation.ChampCustom;
			}
			foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulairesListe)
			{
				if (relation.Formulaire.CodeRole == strCodeRole)
				{
					foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
						tableChamps[relFor.Champ.Id] = relFor.Champ;
				}
			}
			foreach (CRelationTypeEquipement_Heritage rel in RelationsTypesParents)
				rel.TypeParent.FillHashtableChamps(tableChamps, strCodeRole);
		}

		#endregion

		#region IDefinisseurChampCustom Membres

		//-------------------------------------------------------------------
		public IDefinisseurChampCustomRelationObjetDonnee GetDefinisseurPourEquipementPhysique()
		{
			return new CDefinisseurChampsTypeEquipement(this, CEquipement.c_roleChampCustom);
		}

		//-------------------------------------------------------------------
		public IDefinisseurChampCustomRelationObjetDonnee GetDefinisseurPourEquipementLogique()
		{
			return new CDefinisseurChampsTypeEquipement(this, CEquipementLogique.c_roleChampCustom);
		}


		//-------------------------------------------------------------------
		public CRoleChampCustom RoleChampCustomAssocie
		{
			get 
			{
				return CRoleChampCustom.GetRole(CTypeEquipement.c_roleChampCustom);	
			} 
		}

        /*public CRoleChampCustom RoleChampCustomDesElementsAChamp
        {
            get
            {
                return CRoleChampCustom.GetRole(CEquipement.c_roleChampCustom);
            }
        }*/

		#endregion

		//-------------------------------------------------------------------
		public bool HeriteDe(CTypeEquipement type)
		{
			if (type != null)
			{
				foreach (CTypeEquipement typeEqt in TousLesTypesParents)
					if (type.Equals(typeEqt))
						return true;
			}
			return false;
		}

		//-------------------------------------------------------------------
		public void TiagSetFamilyKeys(object[] cles)
		{
			CFamilleEquipement famille = new CFamilleEquipement(ContexteDonnee);
			if (famille.ReadIfExists(cles))
				Famille = famille;
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Famille d'équipement auqel appartient ce type d'équipement<br/>
		/// (obligatoire)
		/// </summary>
		[Relation ( CFamilleEquipement.c_nomTable,
			CFamilleEquipement.c_champId,
			CFamilleEquipement.c_champId,
			true,
			false,
			false)]
		[DynamicField("Family")]
		[TiagRelation(typeof(CFamilleEquipement), "TiagSetFamilyKeys")]
		public CFamilleEquipement Famille
		{
			get
			{
				return (CFamilleEquipement)GetParent(CFamilleEquipement.c_champId, typeof(CFamilleEquipement));
			}
			set
			{
				SetParent(CFamilleEquipement.c_champId, value);
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Relations vers les types pouvant être inclus dans ce type
		/// </summary>
		[RelationFille ( typeof(CRelationTypeEquipement_TypesIncluables) , "TypeIncluant" )]
		[DynamicChilds("Included types relations", typeof ( CRelationTypeEquipement_TypesIncluables ) )]
		public CListeObjetsDonnees RelationsTypesInclus
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipement_TypesIncluables.c_nomTable, CRelationTypeEquipement_TypesIncluables.c_champIdTypeIncluant);
			}
		}


		//---------------------------------------------------------
		public CTypeEquipement[] TousLesTypesIncluables
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillHashtableTypesIncluables(tbl);
				foreach (CTypeEquipement parent in TousLesTypesParents)
					parent.FillHashtableTypesIncluables(tbl);
				CTypeEquipement[] equips = new CTypeEquipement[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipement tp in tbl.Keys)
					equips[nIndex++] = tp;
				return equips;
			}
		}


		//---------------------------------------------------------
		private void FillHashtableTypesIncluables(Hashtable tbl)
		{
			foreach (CRelationTypeEquipement_TypesIncluables rel in RelationsTypesInclus)
				tbl[rel.TypeInclu] = true;
		}

		//---------------------------------------------------------
		public CTypeEquipement[] TousLesTypesIncluants
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillHashtableTypesIncluants(tbl);
				foreach (CTypeEquipement parent in TousLesTypesParents)
					parent.FillHashtableTypesIncluants(tbl);
				CTypeEquipement[] equips = new CTypeEquipement[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipement tp in tbl.Keys)
					equips[nIndex++] = tp;
				return equips;
			}
		}


		//---------------------------------------------------------
		private void FillHashtableTypesIncluants( Hashtable tbl)
		{
			foreach (CRelationTypeEquipement_TypesIncluables rel in RelationsTypesIncluant)
			{
				tbl[rel.TypeIncluant] = true;
				foreach (CTypeEquipement tp in rel.TypeIncluant.TousLesTypesFils)
				{
					tbl[tp] = true;
					tp.FillHashtableTypesIncluants(tbl);
				}
			}
		} 

		//---------------------------------------------------------
		/// <summary>
		/// Relations vers les types pouvant inclure ce type
		/// </summary>
		[RelationFille(typeof(CRelationTypeEquipement_TypesIncluables), "TypeInclu")]
		[DynamicChilds("Container types relations", typeof(CRelationTypeEquipement_TypesIncluables))]
		public CListeObjetsDonnees RelationsTypesIncluant
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipement_TypesIncluables.c_nomTable, CRelationTypeEquipement_TypesIncluables.c_champIdTypeInclu);
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Liste des relations avec les fournisseurs de ce type d'équipement
		/// </summary>
		[RelationFille ( typeof ( CRelationTypeEquipement_Fournisseurs ), "TypeEquipement") ]
		[DynamicChilds ( "Suppliers data", typeof ( CRelationTypeEquipement_Fournisseurs ))]
		public CListeObjetsDonnees RelationsFournisseurs
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipement_Fournisseurs.c_nomTable, c_champId);
			}
		}


        //---------------------------------------------------------
        /// <summary>
        /// Liste des relations avec les constructeurs de ce type d'équipement
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_Constructeurs), "TypeEquipement")]
        [DynamicChilds("Manufacturers data", typeof(CRelationTypeEquipement_Constructeurs))]
        public CListeObjetsDonnees RelationsConstructeurs
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_Constructeurs.c_nomTable, c_champId);
            }
        }


		#region IDefinisseurEvenements Membres

		//---------------------------------------------------------
		public CComportementGenerique[] ComportementsInduits
		{
			get
			{
				return CUtilDefinisseurEvenement.GetComportementsInduits ( this );
			}
		}

		//---------------------------------------------------------
		public CListeObjetsDonnees Evenements
		{
			get 
			{
				return CUtilDefinisseurEvenement.GetEvenementsFor(this);
			}
		}

		//---------------------------------------------------------
		public Type[] TypesCibleEvenement
		{
			get 
			{
				return new Type[] { typeof(CEquipement) };
			}
		}

		#endregion


		#region IObjetDonneeAChamps Membres


        //---------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationTypeEquipement_ChampCustomValeur( ContexteDonnee );
		}

        //---------------------------------------------------------
        public string GetNomTableRelationToChamps()
		{
			return CRelationTypeEquipement_ChampCustomValeur.c_nomTable;
		}

        //---------------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = GetDependancesListe(CRelationTypeEquipement_ChampCustomValeur.c_nomTable, c_champId);
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

		#endregion

		#region IElementAChamps Membres

        //---------------------------------------------------------
        public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				ArrayList lst = new ArrayList();
				CFamilleEquipement famille = Famille;
                if ( famille != null )
                    lst.Add ( famille.GetDefinisseurPourTypeEquipement() );
                /*return new (IDefinisseurChampCustom[]
				while (famille != null)
				{
					lst.Add(famille);
					famille = famille.FamilleParente;
				}*/
				return (IDefinisseurChampCustom[])lst.ToArray(typeof(IDefinisseurChampCustom));
			}
		}

		//---------------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			Hashtable tableChampsFormulaire = new Hashtable();
			Hashtable tableChampsHorsFormulaire = new Hashtable();
			foreach (IDefinisseurChampCustom def in DefinisseursDeChamps)
			{
				foreach (CRelationFamilleEquipement_ChampCustom rel in def.RelationsChampsCustomDefinis)
					tableChampsHorsFormulaire[rel.ChampCustom] = true;
				foreach (CRelationFamilleEquipement_Formulaire rel in def.RelationsFormulaires)
					foreach (CRelationFormulaireChampCustom relF in rel.Formulaire.RelationsChamps)
						tableChampsFormulaire[relF.Champ] = true;
			}
			foreach (CChampCustom champ in tableChampsFormulaire.Keys)
				tableChampsHorsFormulaire[champ] = false;
			ArrayList lst = new ArrayList();
			foreach (DictionaryEntry entry in tableChampsHorsFormulaire)
			{
				if ((bool)entry.Value)
					lst.Add(entry.Key);
			}
			return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
		}
		
		//---------------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
		}

		//---------------------------------------------------------
        /// <summary>
        /// Liste des relations du type d'équipement avec des champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeEquipement_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

		#endregion

        //---------------------------------------------------------
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

		//---------------------------------------------------------
		/// <summary>
		/// Code du type d'équipement (pour une recherche rapide)
		/// </summary>
		[TableFieldProperty ( CTypeEquipement.c_champCode, 255)]
		[DynamicField("Code")]
		[RechercheRapide]
		[TiagField("Code")]
		public string Code
		{
			get
			{
				return (string)Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Mnémonique du type d'équipement (pour une recherche rapide)
		/// </summary>
		[TableFieldProperty(CTypeEquipement.c_champMnemonique, 255)]
		[DynamicField("Mnemonic")]
		[RechercheRapide]
		[TiagField ( "Menmonic")]
		public string Mnemonique
		{
			get
			{
				return (string)Row[c_champMnemonique];
			}
			set
			{
				Row[c_champMnemonique] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'élément dans le stock) à partir
		/// duquel il serait bon de recommander des équipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur est la valeur par défaut pour le type d'équipement.
		/// Il est possible d'affecter des valeurs différentes pour chaque type de stock
		/// via l'entité <see cref="CRelationTypeEquipementStock">Relation 
		/// type équipement/Stock</see>
		/// </remarks>
		[TableFieldProperty(CTypeEquipement.c_champStockAlerte)]
		[DynamicField("Alert stock")]
		public int StockAlerte
		{
			get
			{
                return (int)Row[c_champStockAlerte];
			}
			set
			{
				Row[c_champStockAlerte] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Seuil (nombre d'élément dans le stock) à partir
		/// duquel il faut recommander en urgence des équipements de ce type
		/// </summary>
		/// <remarks>
		/// Cette valeur est la valeur par défaut pour le type d'équipement.
		/// Il est possible d'affecter des valeurs différentes pour chaque type de stock
		/// via l'entité <see cref="CRelationTypeEquipementStock">Relation 
		/// type équipement/Stock</see>
		/// </remarks>
		[TableFieldProperty(CTypeEquipement.c_champStockCritique)]
		[DynamicField("Critical stock")]
		public int StockCritique
		{
			get
			{
				return (int)Row[c_champStockCritique];
			}
			set
			{
				Row[c_champStockCritique] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// En cas de commande automatique, indique combien
		/// il faut d'équipements de ce type dans le stock
		/// après la commande
		/// </summary>
		/// <remarks>
		/// Cette valeur est la valeur par défaut pour le type d'équipement.
		/// Il est possible d'affecter des valeurs différentes pour chaque type de stock
		/// via l'entité <see cref="CRelationTypeEquipementStock">Relation 
		/// type équipement/Stock</see>
		/// </remarks>sssssss
		[TableFieldProperty(CTypeEquipement.c_champStockOptimal)]
		[DynamicField("Optimal stock")]
		public int StockOptimal
		{
			get
			{
				return (int)Row[c_champStockOptimal];
			}
			set
			{
				Row[c_champStockOptimal] = value;
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Surchage du comportement du type d'équipement pour chaque type de stock.
        /// Renvoie la liste des relations du type d'équipement avec chaque type de stock
		/// </summary>
		[RelationFille ( typeof (CRelationTypeEquipement_TypeStock ), "TypeEquipement")]
		[DynamicChilds("Stock types relations", typeof (CRelationTypeEquipement_TypeStock) )]
		public CListeObjetsDonnees RelationsTypesStocks
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipement_TypeStock.c_nomTable, c_champId);
			}
		}


		//-------------------------------------------------------------------
        /// <summary>
        /// Codes complets (Full_system_code) de toutes les <see cref="CEntiteOrganisationnelle">entités organisationnelles</see> auxquels est affecté le type d'équipement<br/>
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
		/// <summary>
		/// Indique qu'il n'existe pas d'équipements de ce type.
		/// Il s'agit uniquement d'un type permettant l'héritage de propriétés
		/// </summary>
		[TableFieldProperty ( CTypeEquipement.c_champTypeAbstrait )]
		[DynamicField("Abstract type")]
		[TiagField("Is abstract")]
		public bool IsAbstrait
		{
			get
			{
				return (bool)Row[c_champTypeAbstrait];
			}
			set
			{
				Row[c_champTypeAbstrait] = value;
			}
		}
		
		//-------------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get 
			{
				ArrayList lst = new ArrayList();
				foreach (CRelationTypeEquipement_Heritage rel in RelationsTypesParents)
					lst.Add(rel.TypeParent);
				return (IElementAEO[])lst.ToArray(typeof(IElementAEO));
			}
		}

		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				ArrayList lst = new ArrayList();
				foreach (CRelationTypeEquipement_Heritage relH in RelationsTypesFils)
					lst.Add(relH.TypeFils);
				lst.AddRange ( GetDependancesListe(CEquipement.c_nomTable, c_champId ) );
				return ( IElementAEO[] )lst.ToArray(typeof(IElementAEO) );
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
        /// Ajoute une entité organisationnelle au type d'équipement
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO à ajouter</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">Résultat à erreur</see></returns>
        [DynamicMethod(
            "Asigne a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        /// <summary>
        /// Ote une entité organisationnelles au type d'équipement
        /// </summary>
        /// <param name="nIdEO">Identifiant (Id) de l'EO à ôter</param>
        /// <returns><see cref="sc2i.common.CResultAErreur">Résultat à erreur</see></returns>
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

		//-------------------------------------------------------------------
		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CUtilElementAEO.CompleteRestriction( this, restriction );
		}

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Relations filles avec les Types Remplaçables par ce type
        /// Relations simples: Non Bijectives
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_TypeRemplacement), "TypeRemplacable")]
        [DynamicChilds("Replaceable types", typeof(CRelationTypeEquipement_TypeRemplacement))]
        public CListeObjetsDonnees RelationsTypesRemplacables
        {
            get
            {
                return GetDependancesListe(
                    CRelationTypeEquipement_TypeRemplacement.c_nomTable,
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant);
            }
        }
        // Retourne les Types Remplacables directes
        public CTypeEquipement[] ListeTypesRemplacablesDirectes
        {
            get
            {
                ArrayList lilste = new ArrayList();
                foreach (CRelationTypeEquipement_TypeRemplacement rel in RelationsTypesRemplacables)
                {
                    lilste.Add(rel.TypeRemplacable);
                }
                foreach(CRelationTypeEquipement_TypeRemplacement rel in RelationsTypesRemplacants)
                {
                    if (rel.Bijective)
                        lilste.Add(rel.TypeRemplacant);
                }
                return (CTypeEquipement[])lilste.ToArray(typeof(CTypeEquipement));
            }
		}

		#region Type Tables parametrables
		/// <summary>
		/// </summary>
		[RelationFille(typeof(CRelationTypeEquipement_TypeTableParametrable), "TypeEquipement")]
		[DynamicChilds("Custom Table Types relations", typeof(CRelationTypeEquipement_TypeTableParametrable))]
		public CListeObjetsDonnees RelationsTypesTableParametrables
		{
			get { return GetDependancesListe(CRelationTypeEquipement_TypeTableParametrable.c_nomTable, c_champId); }
		}

		#endregion

		//---------------------------------------------------------------------------
        /// <summary>
        /// Relations filles avec les Types Remplaçants potentiels de ce type
        /// Relations simples: Non Bijectives
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_TypeRemplacement), "TypeRemplacant")]
        [DynamicChilds("Remplacing types", typeof(CRelationTypeEquipement_TypeRemplacement))]
        public CListeObjetsDonnees RelationsTypesRemplacants
        {
            get
            {
                return GetDependancesListe(
                    CRelationTypeEquipement_TypeRemplacement.c_nomTable,
                    CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable);
            }
        }
        // Retourne les Types Remplacants directes
        public CTypeEquipement[] ListeTypesRemplacantsDirectes
        {
            get
            {
                ArrayList lilste = new ArrayList();
                foreach (CRelationTypeEquipement_TypeRemplacement rel in RelationsTypesRemplacants)
                {
                    lilste.Add(rel.TypeRemplacant);
                }
                foreach (CRelationTypeEquipement_TypeRemplacement rel in RelationsTypesRemplacables)
                {
                    if (rel.Bijective)
                        lilste.Add(rel.TypeRemplacable);
                }
                return (CTypeEquipement[])lilste.ToArray(typeof(CTypeEquipement));
            }
        }
        //---------------------------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste de tous les types d'équipements Remplaçants potentiels
        /// hérités de tous les Types d'Equipements Parents
        /// </summary>
        /// <returns>Tableau de Relations CTypeEquipement</returns>
        [DynamicChilds("All replacing types", typeof(CTypeEquipement))]
        public CTypeEquipement[] TousLesTypesRemplacants
        {
            get
            {
                Hashtable tableTraites = new Hashtable();
                Hashtable tableRemplacants = new Hashtable();

                FillHashtableTypesRemplacants(tableTraites, tableRemplacants);
                CTypeEquipement[] liste = new CTypeEquipement[tableRemplacants.Count + 1]; // +1 pour lui-même

                //Remplit la liste à partir de la Hashtable
                int index = 0;
                foreach (CTypeEquipement type in tableRemplacants.Values)
                    liste[index++] = type;
                // Ajoute lui-même à la liste
                liste[index] = this;

                return liste;
            }
        }

        //---------------------------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste de tous les types d'équipements Remplaçables
        /// hérités de tous les Types d'Equipements Parents
        /// </summary>
        /// <returns>Tableau de Relations CTypeEquipement</returns>
        [DynamicChilds("All replaced types", typeof(CTypeEquipement))]
        public CTypeEquipement[] TousLesTypesRemplacables
        {
            get
            {
                Hashtable tableTraites = new Hashtable();
                Hashtable tableRemplacants = new Hashtable();

                FillHashtableTypesRemplacants(tableTraites, tableRemplacants);
                CTypeEquipement[] liste = new CTypeEquipement[tableRemplacants.Count + 1]; // +1 pour lui-même

                //Remplit la liste à partir de la Hashtable
                int index = 0;
                foreach (CTypeEquipement type in tableRemplacants.Values)
                    liste[index++] = type;
                // Ajoute lui-même à la liste
                liste[index] = this;

                return liste;
            }
        }

        //----------------------------------------------------------------------------------
        // Remplit une Hashtable pour éviter les doublons
        private void FillHashtableTypesRemplacants(Hashtable tableTraites, Hashtable tableRemplacants)
        {
            // Condition de sortie
            if (tableTraites.Contains(this.Id)) 
                return;
            tableTraites[this.Id] = this;

            // Ajoute les types remplacants directes
            ArrayList liste = new ArrayList();
            foreach (CTypeEquipement type in this.ListeTypesRemplacantsDirectes)
            {
                type.FillHashtableTypesRemplacants(tableTraites, tableRemplacants);
                tableRemplacants[type.Id] = type;
                foreach (CTypeEquipement typeFils in type.TousLesTypesFils)
                {
                    tableRemplacants[typeFils.Id] = typeFils;
                    typeFils.FillHashtableTypesRemplacants(tableTraites, tableRemplacants);
                }
            }
           
            // Ajoute tous les types remplacants de tous les types parents
            foreach (CRelationTypeEquipement_Heritage relTypeParent in this.RelationsTypesParents)
            {
                relTypeParent.TypeParent.FillHashtableTypesRemplacants(tableTraites, tableRemplacants);
            }
        }

        //----------------------------------------------------------------------------------
        // Remplit une Hashtable pour éviter les doublons
        private void FillDictionnaryTypesRemplacables(
            Hashtable tableTraites, 
            Hashtable  tableRemplacants)
        {
            // Condition de sortie
            if (tableTraites.Contains(this.Id))
                return;
            tableTraites[this.Id] = this;

            // Ajoute les types remplacés directes
            ArrayList liste = new ArrayList();
            foreach (CTypeEquipement type in this.ListeTypesRemplacablesDirectes)
            {
                type.FillDictionnaryTypesRemplacables(tableTraites, tableRemplacants);
                tableRemplacants[type.Id] = type;
                foreach (CTypeEquipement typeFils in type.TousLesTypesFils)
                {
                    tableRemplacants[typeFils.Id] = typeFils;
                    typeFils.FillDictionnaryTypesRemplacables(tableTraites, tableRemplacants);
                }
            }

            // Ajoute tous les types remplacants de tous les types parents
            foreach (CRelationTypeEquipement_Heritage relTypeParent in this.RelationsTypesParents)
            {
                relTypeParent.TypeParent.FillDictionnaryTypesRemplacables(tableTraites, tableRemplacants);
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        /// Indique si les Equipements de ce Type sont en mode de gestion par "Dotation" par défaut
        /// </summary>
        [TableFieldProperty(c_champIsDotation)]
        [DynamicField("Is Dotation Management")]
        [TiagField("Dotation")]
        public bool IsDotationByDefault
        {
            get
            {
                return (bool)Row[c_champIsDotation];
            }
            set
            {
                Row[c_champIsDotation] = value;
            }
        }



        //----------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Equipements de ce Type
        /// </summary>
        [RelationFille(typeof(CEquipement), "TypeEquipement")]
        [DynamicChilds("Equipments", typeof(CEquipement))]
        public CListeObjetsDonnees Equipements
        {
            get
            {
                return GetDependancesListe(CEquipement.c_nomTable, c_champId);
            }
        }

        //----------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Equipements logiques de ce Type
        /// </summary>
        [RelationFille(typeof(CEquipementLogique), "TypeEquipement")]
        [DynamicChilds("Logical equipments", typeof(CEquipementLogique))]
        public CListeObjetsDonnees EquipementsLogiques
        {
            get
            {
                return GetDependancesListe(CEquipementLogique.c_nomTable, c_champId);
            }
        }


        //------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste de Objets de <see cref="CRelationTypeEquipement_Stock">Relation</see> entre le Type d'Equipement et des Stocks
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipement_Stock), "TypeEquipement")]
        [DynamicChilds("Stock Relations", typeof(CRelationTypeEquipement_Stock))]
        public CListeObjetsDonnees RelationsStocks
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipement_Stock.c_nomTable, c_champId);
            }
        }

		//-------------------------------------------------------------------
		/// <summary>
		/// Si vrai, indique que la création d'un équipement 
		/// implique la création automatique d'un équipement logique associé
		/// </summary>
		[TableFieldProperty(CTypeEquipement.c_champCreationLogiqueAutomatique)]
		[DynamicField("Auto create associated logical equipment")]
		public bool CreationAutomatiqueEquipementLogique
		{
			get
			{
				return (bool)Row[c_champCreationLogiqueAutomatique];
			}
			set
			{
				Row[c_champCreationLogiqueAutomatique] = value;
			}
		}


        /// <summary>
        /// Donne la liste des ports associés au type d'équipement
        /// </summary>
        [RelationFille(typeof(CPort), "TypeEquipement")]
        [DynamicChilds("Ports", typeof(CPort))]
        public CListeObjetsDonnees Ports
        {
            get
            {
                return GetDependancesListe(CPort.c_nomTable, c_champId);
            }
        }

      

        /// <summary>
        /// Donne le symbole de bibliothèque associé au type d'équipement, lorsqu'il existe
        /// </summary>
        [Relation(
            CSymboleDeBibliotheque.c_nomTable,
           CSymboleDeBibliotheque.c_champId,
          CSymboleDeBibliotheque.c_champId,
            false,
            false,
            false)]
        [DynamicField("Library symbol")]
        public CSymboleDeBibliotheque SymboleDeBibliotheque
        {
            get
            {
                return (CSymboleDeBibliotheque)GetParent(CSymboleDeBibliotheque.c_champId, typeof(CSymboleDeBibliotheque));
            }
            set
            {
                if(SymbolePropre!=null)
                {
                  //SymbolePropre.Delete();
                    SymbolePropre = null;
                }
                SetParent(CSymboleDeBibliotheque.c_champId, value);
               
            }

        }

        /// <summary>
        /// Donne le symbole propre au type d'équipement lorsqu'il existe
        /// </summary>
        [RelationFille(typeof(CSymbole), "TypeEquipement")]
        [DynamicField("Proper symbol")]
        public CSymbole SymbolePropre
        {

            get
            {
                CListeObjetsDonneesContenus liste = GetDependancesListe(CSymbole.c_nomTable, CTypeEquipement.c_champId);
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
                    value.TypeEquipement = this;
                }

            }

        }

        /// <summary>
        /// Donne le symbole associé au type d'équipement
        /// </summary>
        [DynamicField("Symbol")]
        public CSymbole Symbole
        {
            get
            {
                

                if (SymbolePropre == null)
                    if (SymboleDeBibliotheque != null)
                        return SymboleDeBibliotheque.Symbole;
                    else
                       return null;
                else
                    return SymbolePropre;

            }
        }

        //--------------------------------------
        public Type GetTypePourLequelOnSelectionneUnSymbole()
        {
            return typeof(CEquipementLogique);
        }

        //--------------------------------------
        public C2iSymbole SymboleADessinerSansPorts
        {
            get
            {
                C2iSymbole symboleADessiner = null;
                if (Symbole != null)
                    symboleADessiner = Symbole.Symbole;
                if (symboleADessiner == null)
                    symboleADessiner = CSymbole.GetSymboleParDefaut(GetTypePourLequelOnSelectionneUnSymbole(), ContexteDonnee);
                symboleADessiner.BackColor = Color.Transparent;
                return symboleADessiner;
            }
        }


        //--------------------------------------
        public C2iSymbole SymboleDefiniADessiner 
        {
            get
            {
                C2iSymbole symboleADessiner = SymboleADessinerSansPorts;
                //Ajoute le dessin des ports
                foreach (CPort port in Ports)
                {
                    C2iSymbole symbolePort = port.SymboleADessiner;
                    if (symbolePort != null)
                    {
                        symbolePort.Position = new Point(port.PosX, port.PosY);
                        foreach (C2iSymbole symbole in symbolePort.Childs)
                        {
                            symbolePort.Parent = symboleADessiner;
                            symboleADessiner.AddChild(symbolePort);
                            
                        }
                    }

                }
                return symboleADessiner;
            }
        }


		#region IObjetASystemeDeCoordonnee Membres

        //----------------------------------------------------------------------
        [RelationFille(typeof(CParametrageSystemeCoordonnees), "TypeEquipement")]
        public CListeObjetsDonnees ParametragesSystemesCoordonnees
        {
            get
            {
                return GetDependancesListe(CParametrageSystemeCoordonnees.c_nomTable, c_champId);
            }
        }

		//----------------------------------------------------------------------
        /// <summary>
        /// Système de coordonnées propre au type d'équipement (lorsqu'il existe)
        /// </summary>
		[DynamicField("Own coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesPropre
		{
			get
			{
                CListeObjetsDonnees liste = ParametragesSystemesCoordonnees;
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
				return true;
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
				IObjetASystemeDeCoordonnee donnateur = null;
				//Cherche dans les types parents
				foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
				{
					if (heritage.TypeParent.ParametrageCoordonneesPropre != null)
					{
						if (donnateur != null)
							return null;
						donnateur = heritage.TypeParent;
					}
					else
					{
						donnateur = heritage.TypeParent.DonnateurParametrageCoordonneeHerite;
					}
				}
				return donnateur;
			}
		}
		

		//----------------------------------------------------------------------
        /// <summary>
        /// Système de coordonnées appliqué au type d'équipement
        /// </summary>
		[DynamicField("Applied coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get
			{
				CParametrageSystemeCoordonnees parametrage = ParametrageCoordonneesPropre;
				if (parametrage == null)
				{
					IObjetASystemeDeCoordonnee donnateur = DonnateurParametrageCoordonneeHerite;
					if (donnateur != null)
						return donnateur.ParametrageCoordonneesPropre;					
				}
				return parametrage;
						
			}
		}

		#endregion

		#region IObjetAOptionsDeControleDeCoordonnees Membres

		//-------------------------------------------------------------------------
		[TableFieldProperty ( c_champOptionsControleCoordonnees, NullAutorise=true )]
		public int? OptionsControleCoordonneesPropreInt
		{
			get 
			{
				if (Row[c_champOptionsControleCoordonnees] == DBNull.Value)
					return null;
				return (int)Row[c_champOptionsControleCoordonnees];
			}
			set
			{
				if (value == null)
					Row[c_champOptionsControleCoordonnees] = DBNull.Value;
				else
					Row[c_champOptionsControleCoordonnees] = value;
			}
		}

		//-------------------------------------------------------------------------
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

		//-------------------------------------------------------------------------
		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get 
			{
				IObjetAOptionsDeControleDeCoordonnees donnateur = null;
				//Cherche dans les types parents
				foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
				{
					if (heritage.TypeParent.OptionsControleCoordonneesPropre != null)
					{
						if (donnateur != null)
							return null;
						donnateur = heritage.TypeParent;
					}
					else
					{
						donnateur = heritage.TypeParent.DonnateurOptionsControleCoordonneesHerite;
					}
				}
				return donnateur;
			}
		}

		//-------------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
		{
			get
			{
				EOptionControleCoordonnees? option = OptionsControleCoordonneesPropre;
				if (option == null)
				{
					IObjetAOptionsDeControleDeCoordonnees donnateur = DonnateurOptionsControleCoordonneesHerite;
					if (donnateur != null)
						return donnateur.OptionsControleCoordonneesPropre;
				}
				return option;
			}
		}

		//-------------------------------------------------------------------------
		public bool CanHeriteOptionsControleCoordonnees
		{
			get
			{
				return true;
			}
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

		#region IObjetAOccupation Membres

		//--------------------------------------------------------------------
        /// <summary>
        /// Nombre d'unités qu'occupe un tel type d'équipement dans son conteneur
        /// </summary>
		[TableFieldProperty(CTypeEquipement.c_champNbUnitesOccupation, NullAutorise=true)]
		[DynamicField("Units number")]
		[TiagField("Units number")]
		public int? NbUnitesOccupees
		{
			get
			{
				return (int?)Row[c_champNbUnitesOccupation, true];
			}
			set
			{
				Row[c_champNbUnitesOccupation, true] = value;
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Unité dans laquelle l'occupation du type d'équipement dans son conteneur
        /// est exprimée
		/// </summary>
		[Relation(
			CUniteCoordonnee.c_nomTable,
			CUniteCoordonnee.c_champId,
			c_champUniteOccupation,
			false,
			false,
			false)]
		[DynamicField("Occupation unit")]
		public CUniteCoordonnee UniteOccupee
		{
			get
			{
				return (CUniteCoordonnee)GetParent(c_champUniteOccupation, typeof(CUniteCoordonnee));
			}
			set
			{
				SetParent(c_champUniteOccupation, value);
			}
		}

		//--------------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneeAppliquee
		{
			get 
			{
				COccupationCoordonnees occupation = OccupationCoordonneesPropre;
				if (occupation == null)
				{
					IObjetAOccupation donnateur = DonnateurOccupationCoordonneeHerite;
					if (donnateur != null)
						occupation = donnateur.OccupationCoordonneesPropre;
				}
				return occupation;
			}
		}

		//--------------------------------------------------------------------
		public IObjetAOccupation DonnateurOccupationCoordonneeHerite
		{
			get 
			{
				IObjetAOccupation donnateur = null;
				//Cherche dans les types parents
				foreach (CRelationTypeEquipement_Heritage heritage in RelationsTypesParents)
				{
					if (heritage.TypeParent.OccupationCoordonneesPropre != null)
					{
						if (donnateur != null)
							return null;
						donnateur = heritage.TypeParent;
					}
					else
					{
						donnateur = heritage.TypeParent.DonnateurOccupationCoordonneeHerite;
					}
				}
				return donnateur;
			}
		}

		//--------------------------------------------------------------------
		public COccupationCoordonnees OccupationCoordonneesPropre
		{
			get 
			{
				if (NbUnitesOccupees != null)
				{
					COccupationCoordonnees occupation = new COccupationCoordonnees(
						(int)NbUnitesOccupees, UniteOccupee);
					return occupation;
				}
				return null;
			}
			set
			{
				if (value == null)
				{
					NbUnitesOccupees = null;
					UniteOccupee = null;
				}
				else
				{
					NbUnitesOccupees = value.NbUnitesOccupees;
					UniteOccupee = value.Unite;
				}
			}
		}

		//--------------------------------------------------------------------
		public bool CanHeriteOccupationCoordonnees
		{
			get 
			{
				return true;
			}
		}


		#endregion

        [Relation(
            CComposantPhysiqueInDb.c_nomTable,
            CComposantPhysiqueInDb.c_champId,
            CComposantPhysiqueInDb.c_champId,
            false,
            false,
            true)]
        [DynamicField("Physical component")]
        public CComposantPhysiqueInDb ComposantPhysiqueAssocie
        {
            get
            {
                return (CComposantPhysiqueInDb)GetParent(CComposantPhysiqueInDb.c_champId, typeof(CComposantPhysiqueInDb));
            }
            set
            {
                SetParent(CComposantPhysiqueInDb.c_champId, value);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Lignes de commande dans lesquelles figure ce type d'équipement
        /// </summary>
        [RelationFille(typeof(CLigneCommande), "TypeEquipement")]
        [DynamicChilds("Orders lines", typeof(CLigneCommande))]
        public CListeObjetsDonnees LignesDeCommande
        {
            get
            {
                return GetDependancesListe(CLigneCommande.c_nomTable, c_champId);
            }
        }


        //---------------------------------------------
        /// <summary>
        /// Liste des valorisations existantes pour ce type d'équipement
        /// </summary>
        [RelationFille(typeof(CValorisationElement), "TypeEquipement")]
        [DynamicChilds("Valuations", typeof(CValorisationElement))]
        public CListeObjetsDonnees Valorisations
        {
            get
            {
                return GetDependancesListe(CValorisationElement.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne la valeur d'un équipement de ce type pour une date donnée
        /// </summary>
        /// <remarks>
        /// La valeur retournée correspond à la valorisation dont la date
        /// est maximale et inférieure à la date demandée. <BR></BR>
        /// S'il n'existe pas de valorisation correspondante, <BR></BR>
        /// Si la date demandée est inférieure à la première valorisation
        /// connue, la valeur retournée est la première valorisation connue<BR></BR>
        /// Sinon, ce sera la date de la valorisation la plus récente<BR></BR>
        /// S'il n'existe pas de valorisation pour ce type d'équipement, la
        /// valeur retournée sera 0
        /// </remarks>
        /// <param name="dt"></param>
        /// <returns></returns>
        [DynamicMethod("Return valuation for a specific date", "Date")]
        public double GetValuationForDate(DateTime dt)
        {
            CListeObjetsDonnees lstValEqpt = Valorisations;
            CListeObjetsDonnees lstLot = lstValEqpt.GetDependances("LotValorisation");
            if (lstValEqpt.Count == 0)
                return 0;
            lstLot.Tri = CLotValorisation.c_champDateLot;
            CLotValorisation lot = lstLot[0] as CLotValorisation;
            if (lot != null && lot.DateLot.Date.AddMinutes(-1) > dt)//Premier plus récent->premier
            {
                CValorisationElement val = lot.GetValorisation(this);
                if (val != null)
                    return val.Valeur;
                return 0;
            }
            lstLot.InterditLectureInDB = true;
            lstLot.Filtre = new CFiltreData(CLotValorisation.c_champDateLot + "<@1",
                dt.Date.AddDays(1));
            lstLot.Tri = CLotValorisation.c_champDateLot;
            if (lstLot.Count > 0)
            {
                lot = lstLot[lstLot.Count - 1] as CLotValorisation;
                if (lot != null)
                {
                    CValorisationElement val = lot.GetValorisation(this);
                    if (val != null)
                        return val.Valeur;
                }
            }
            return 0;
        }



        #region IElementCommandable Membres
        //------------------------------------------------------------------------
        public IElementCommandable[] ReferencesCommandables
        {
            get { return RelationsFournisseurs.ToArray<IElementCommandable>(); }
        }

        #endregion
    }

}
