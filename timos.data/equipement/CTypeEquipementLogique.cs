using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

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


namespace timos.data
{
	/// <summary>
	/// Definit le type des <see cref="CEquipementLogique">Equipements</see>.<br/>
	/// 
	/// </summary>
    [DynamicClass("Logical Equipment type")]
	[ObjetServeurURI("CTypeEquipementLogiqueServeur")]
	[Table(CTypeEquipementLogique.c_nomTable, CTypeEquipementLogique.c_champId,true)]
	[FullTableSync]
	[AutoExec("Autoexec")]
	[TiagClass ( CTypeEquipementLogique.c_nomTiag, "Id", true )]
	public class CTypeEquipementLogique : CObjetDonneeAIdNumeriqueAuto, 
		IDefinisseurChampCustomRelationObjetDonnee,
		IDefinisseurEvenements,
		IObjetDonneeAChamps,
		IElementAEO,
		IElementAInterfaceTiag
	{

		

		#region Déclaration des constantes
		public const string c_nomTiag = "Logical Equipment type";

		public const string c_roleChampCustom = "EQUIPMENT_LGC_TYPE";
		
		public const string c_nomTable = "EQUIPMENT_LGC_TYPE";
		public const string c_champId = "EQTLGCTYP_ID";
		public const string c_champLibelle = "EQTLGCTYP_LABEL";
		public const string c_champCode = "EQTLGCTYP_CODE";
		#endregion

		//-------------------------------------------------------------------
		public CTypeEquipementLogique( CContexteDonnee ctx )
			:base(ctx)
		{
		}
		//-------------------------------------------------------------------
		public CTypeEquipementLogique( System.Data.DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, I.T("Logical Equipment Type|20017"), typeof(CTypeEquipementLogique), typeof(CFamilleEquipementLogique));
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
		}
		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
				return I.T("Logical Equipment Type @1|20018", Libelle);
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
		/// Label du Type d'Equipement<br/>
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

		


		
	
		#region IDefinisseurChampCustom Membres

        //-------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEquipementLogique_ChampCustom), "Definisseur")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeEquipementLogique_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustomListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipementLogique_ChampCustom.c_nomTable, CTypeEquipementLogique.c_champId);
            }
        }

        //-------------------------------------------------------------------
        [RelationFille(typeof(CRelationTypeEquipementLogique_Formulaire), "Definisseur")]
        [DynamicChilds("Forms relations", typeof(CRelationTypeEquipementLogique_Formulaire))]
        public CListeObjetsDonnees RelationsFormulairesListe
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipementLogique_Formulaire.c_nomTable, CTypeEquipementLogique.c_champId);
            }
        }
        
        //---------------------------------------------------------------------------
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get
			{
		
				return (IRelationDefinisseurChamp_ChampCustom[])RelationsChampsCustomListe.ToArray(typeof ( IRelationDefinisseurChamp_ChampCustom ) );
			}
		}

		//-------------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{ 
				return ( IRelationDefinisseurChamp_Formulaire[])RelationsFormulairesListe.ToArray ( typeof ( IRelationDefinisseurChamp_Formulaire ) );
			}

		}

		//-------------------------------------------------------------------
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
		/// avec tous les champs liés.(hiérarchique
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

		#region IDefinisseurChampCustom Membres


		//-------------------------------------------------------------------
		public CRoleChampCustom RoleChampCustomAssocie
		{
			get 
			{
				return CRoleChampCustom.GetRole(CEquipementLogique.c_roleChampCustom );	
			}
		}

		#endregion

		//-------------------------------------------------------------------
		public void TiagSetFamilyKeys(object[] cles)
		{
			CFamilleEquipementLogique famille = new CFamilleEquipementLogique(ContexteDonnee);
			if (famille.ReadIfExists(cles))
				Famille = famille;
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Famille d'équipement auqel appartient ce type d'équipement<br/>
		/// (obligatoire)
		/// </summary>
		[Relation ( CFamilleEquipementLogique.c_nomTable,
			CFamilleEquipementLogique.c_champId,
			CFamilleEquipementLogique.c_champId,
			true,
			false,
			false)]
		[DynamicField("Family")]
		[TiagRelation(typeof(CFamilleEquipementLogique), "TiagSetFamilyKeys")]
		public CFamilleEquipementLogique Famille
		{
			get
			{
				return (CFamilleEquipementLogique)GetParent(CFamilleEquipementLogique.c_champId, typeof(CFamilleEquipementLogique));
			}
			set
			{
				SetParent(CFamilleEquipementLogique.c_champId, value);
			}
		}

		//---------------------------------------------------------
		/// <summary>
		/// Relations vers les types pouvant être inclus dans ce type
		/// </summary>
		[RelationFille ( typeof(CRelationTypeEquipementLogique_TypesIncluables) , "TypeIncluant" )]
		[DynamicChilds("Included types relations", typeof ( CRelationTypeEquipementLogique_TypesIncluables ) )]
		public CListeObjetsDonnees RelationsTypesInclus
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipementLogique_TypesIncluables.c_nomTable, CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeIncluant);
			}
		}


		//---------------------------------------------------------
		public CTypeEquipementLogique[] TousLesTypesIncluables
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillHashtableTypesIncluables(tbl);
				CTypeEquipementLogique[] equips = new CTypeEquipementLogique[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipementLogique tp in tbl.Keys)
					equips[nIndex++] = tp;
				return equips;
			}
		}


		//---------------------------------------------------------
		private void FillHashtableTypesIncluables(Hashtable tbl)
		{
			foreach (CRelationTypeEquipementLogique_TypesIncluables rel in RelationsTypesInclus)
				tbl[rel.TypeInclu] = true;
		}

		//---------------------------------------------------------
		public CTypeEquipementLogique[] TousLesTypesIncluants
		{
			get
			{
				Hashtable tbl = new Hashtable();
				FillHashtableTypesIncluants(tbl);
				CTypeEquipementLogique[] equips = new CTypeEquipementLogique[tbl.Count];
				int nIndex = 0;
				foreach (CTypeEquipementLogique tp in tbl.Keys)
					equips[nIndex++] = tp;
				return equips;
			}
		}


		//---------------------------------------------------------
		private void FillHashtableTypesIncluants( Hashtable tbl)
		{
			foreach (CRelationTypeEquipementLogique_TypesIncluables rel in RelationsTypesIncluant)
			{
				tbl[rel.TypeIncluant] = true;
			}
		} 

		//---------------------------------------------------------
		/// <summary>
		/// Relations vers les types pouvant inclure ce type
		/// </summary>
		[RelationFille(typeof(CRelationTypeEquipementLogique_TypesIncluables), "TypeInclu")]
		[DynamicChilds("Container types relations", typeof(CRelationTypeEquipementLogique_TypesIncluables))]
		public CListeObjetsDonnees RelationsTypesIncluant
		{
			get
			{
				return GetDependancesListe(CRelationTypeEquipementLogique_TypesIncluables.c_nomTable, CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeInclu);
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
				return new Type[] { typeof(CEquipementLogique) };
			}
		}

		#endregion


		#region IObjetDonneeAChamps Membres


        //---------------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationTypeEquipementLogique_ChampCustomValeur( ContexteDonnee );
		}

        //---------------------------------------------------------
        public string GetNomTableRelationToChamps()
		{
			return CRelationTypeEquipementLogique_ChampCustomValeur.c_nomTable;
		}

        //---------------------------------------------------------
        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = GetDependancesListe(CRelationTypeEquipementLogique_ChampCustomValeur.c_nomTable, c_champId);
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
				CFamilleEquipementLogique famille = Famille;
				while (famille != null)
				{
					lst.Add(famille);
					famille = famille.FamilleParente;
				}
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
				foreach (CRelationFamilleEquipementLogique_Formulaire rel in def.RelationsFormulaires)
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
			Hashtable tableFormulaires = new Hashtable();
			foreach (IDefinisseurChampCustom def in DefinisseursDeChamps)
				foreach (CRelationFamilleEquipementLogique_Formulaire rel in def.RelationsFormulaires)
					tableFormulaires[rel.Formulaire] = true;
			ArrayList lst = new ArrayList ( tableFormulaires.Keys );
			return ( CFormulaire[] )lst.ToArray ( typeof ( CFormulaire ) );
		}

		//---------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CRelationTypeEquipementLogique_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationTypeEquipementLogique_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationTypeEquipementLogique_ChampCustomValeur.c_nomTable, c_champId);
            }
        }

		#endregion

        //---------------------------------------------------------
        #region IElementAVariables Membres

		public object GetValeurChamp(int nIdVariable)
		{
			return CUtilElementAChamps.GetValeurChamp(this, nIdVariable);
		}

		//----------------------------------------------------
		public object GetValeurChamp(int nIdVariable, DataRowVersion version)
		{
			return CUtilElementAChamps.GetValeurChamp(this, nIdVariable, version);
		}

        //---------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
		{
			if (variable == null)
				return null;
			return GetValeurChamp(variable.Id);
		}

        //---------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdVariable, object valeur)
		{
			return CUtilElementAChamps.SetValeurChamp(this, nIdVariable, valeur);
		}

        //---------------------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
		{
			if (variable == null)
				return CResultAErreur.True;
			return SetValeurChamp(variable.Id, valeur);
		}

		#endregion

		//---------------------------------------------------------
		/// <summary>
		/// Code du type d'équipement (pour une recherche rapide)
		/// </summary>
		[TableFieldProperty ( CTypeEquipementLogique.c_champCode, 255)]
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

		//-------------------------------------------------------------------
		/// <summary>
		/// Listes des codes d'entités organisationnelles auquel est affecté cet élément
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

		
		//-------------------------------------------------------------------
		public IElementAEO[] DonnateursEO
		{
			get 
			{
				return new IElementAEO[0];
				ArrayList lst = new ArrayList();
			}
		}

		//-------------------------------------------------------------------
		public IElementAEO[] HeritiersEO
		{
			get
			{
				ArrayList lst = new ArrayList();
				lst.AddRange ( GetDependancesListe(CEquipementLogique.c_nomTable, c_champId ) );
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
        [DynamicMethod(
            "Assign a new Organisationnal Entity to the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur AjouterEO(int nIdEO)
        {
            return CUtilElementAEO.AjouterEO(this, nIdEO);
        }

        //-----------------------------------------------------------------
        [DynamicMethod(
            "Remove an Organisationnal Entity from the Element",
            "The Organisationnal Entity Identifier")]
        public CResultAErreur SupprimerEO(int nIdEO)
        {
            return CUtilElementAEO.SupprimerEO(this, nIdEO);
        }


		//-------------------------------------------------------------------
		public void CompleteRestriction(CRestrictionUtilisateurSurType restriction)
		{
			CUtilElementAEO.CompleteRestriction( this, restriction );
		}

	}

}
