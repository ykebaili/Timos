using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using tiag.client;

using timos.data;

namespace timos.securite
{
	/// <summary>
	/// Description résumée de CTypeEntiteOrganisationnelle.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iEO)]
    [DynamicClass("Organisational entity type")]
	[Table(CTypeEntiteOrganisationnelle.c_nomTable, CTypeEntiteOrganisationnelle.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CTypeEntiteOrganisationnelleServeur")]
	[TiagClass(CTypeEntiteOrganisationnelle.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeEO_ID)]
    public class CTypeEntiteOrganisationnelle :
		CObjetHierarchique,
		IObjetALectureTableComplete,
		IDefinisseurChampCustomRelationObjetDonnee,
		IObjetASystemeDeCoordonnee,
		IObjetAOptionsDeControleDeCoordonnees,
		IElementAInterfaceTiag
	{
		public const string c_nomTiag = "Organisational entity type";

		public const string c_nomTable = "OE_TYPE";

		public const string c_champId = "OETYP_ID";
		public const string c_champLibelle = "OETYP_LABEL";
		public const string c_champCodeSystemePartiel = "OE_TYPE_PARTIAL_SYSCODE";
		public const string c_champCodeSystemeComplet = "OE_TYPE_FULL_SYSCODE";
		public const string c_champNiveau = "OE_TYPE_LEVEL";
		public const string c_champIdParent = "OE_TYPE_PARENT_ID";

		public const string c_champCoordonneeObligatoire = "OE_OBLIGATORY_COORD";
		public const string c_champOptionsControleCoordonnees = "OE_COORD_CTRL_OPTION";


#if PDA
		//-------------------------------------------------------------------
		public CTypeEntiteOrganisationnelle()
			:base()
		{
		}
#endif
		/// /////////////////////////////////////////////
		public CTypeEntiteOrganisationnelle(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeEntiteOrganisationnelle(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Organisationnal Entity Type @1|300", Libelle);
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
			return new string[] { c_champLibelle };
		}

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		/// /////////////////////////////////////////////
		public bool HasEntitesOrganisationnelles()
		{
			CFiltreData filtre = new CFiltreData(CTypeEntiteOrganisationnelle.c_champId + " = @1",Id);
			int nbentites = new CListeObjetsDonnees(ContexteDonnee,typeof(CEntiteOrganisationnelle),filtre).CountNoLoad;
			if(nbentites > 0)
				return true;
			else
				return false;
		}


		/// /////////////////////////////////////////////
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
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
		/// Utilisé par TIAG pour affecter le type d'entité parente par ses clés
		/// </summary>
		/// <param name="lstCles"></param>
		public void TiagSetParentTypeKeys(object[] lstCles)
		{
			CTypeEntiteOrganisationnelle typeEntite = new CTypeEntiteOrganisationnelle(ContexteDonnee);
			if (typeEntite.ReadIfExists(lstCles))
				TypeParent = typeEntite;
		}

		// /////////////////////////////////////////////
		/// <summary>
		/// Type d'entité parent
		/// </summary>
		[DynamicField("Parent type")]
		[TiagRelation(typeof(CTypeEntiteOrganisationnelle), "TiagSetParentTypeKeys")]
		[Relation ( 
			c_nomTable,
			c_champId,
			c_champIdParent,
			false,
			false )]
		public CTypeEntiteOrganisationnelle TypeParent
		{
			get
			{
				return (CTypeEntiteOrganisationnelle)ObjetParent;
			}
			set
			{
				ObjetParent = value;
			}
		}

		/// /////////////////////////////////////////////
		[DynamicField("Child type")]
		public CTypeEntiteOrganisationnelle TypeFils
		{
			get
			{
				CListeObjetsDonnees listeFils = TypesFils;
				if (listeFils.Count > 0)
					return (CTypeEntiteOrganisationnelle)listeFils[0];
				return null;
			}
		}
		

		/// /////////////////////////////////////////////
		[RelationFille ( typeof ( CTypeEntiteOrganisationnelle ), "TypeParent" )]
		[DynamicChilds("Child types", typeof(CTypeEntiteOrganisationnelle) )]
		public CListeObjetsDonnees TypesFils
		{
			get
			{
				return ObjetsFils;
			}
		}

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
				return CRoleChampCustom.GetRole(CEntiteOrganisationnelle.c_roleChampCustom);
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

		/// /////////////////////////////////////////////
		public override int NbCarsParNiveau
		{
			get
			{
				return 2;
			}
		}

		/// /////////////////////////////////////////////
		public override string ChampCodeSystemePartiel
		{
			get
			{
				return c_champCodeSystemePartiel;
			}
		}

		/// /////////////////////////////////////////////
		public override string ChampCodeSystemeComplet
		{
			get
			{
				return c_champCodeSystemeComplet;
			}
		}

		/// /////////////////////////////////////////////
		public override string ChampNiveau
		{
			get
			{
				return c_champNiveau;
			}
		}

		/// /////////////////////////////////////////////
		public override string ChampLibelle
		{
			get
			{
				return c_champLibelle;
			}
		}

		/// /////////////////////////////////////////////
		public override string ChampIdParent
		{
			get
			{
				return c_champIdParent;
			}
		}

		/// /////////////////////////////////////////////
		[TableFieldProperty ( c_champCodeSystemePartiel, 2 )]
		[DynamicField ("Partial system code")]
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

		/// /////////////////////////////////////////////
		[TableFieldProperty ( c_champCodeSystemeComplet, 100)]
		[DynamicField("Full system code")]
		[TiagField("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeSystemeComplet];
			}
		}

		/// /////////////////////////////////////////////
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


		
		//---------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[RelationFille(typeof(CEntiteOrganisationnelle), "TypeEntite")]
		[DynamicChilds("Organisational entities", typeof(CEntiteOrganisationnelle))]
		public CListeObjetsDonnees EntitesOrganisationnelles
		{
			get
			{
				return GetDependancesListe(CEntiteOrganisationnelle.c_nomTable, c_champId);
			}
		}

		#region IDefinisseurChampCustomRelationObjetDonnee

		//---------------------------------------------------------------------
		[RelationFille(typeof(CRelationTypeEO_ChampCustom), "Definisseur")]
		public CListeObjetsDonnees RelationsChampsCustomListe
		{
			get
			{
				return GetDependancesListe(CRelationTypeEO_ChampCustom.c_nomTable, c_champId);
			}
		}

		//---------------------------------------------------------------------
		[RelationFille(typeof(CRelationTypeEO_Formulaire), "Definisseur")]
		public CListeObjetsDonnees RelationsFormulairesListe
		{
			get
			{
				return GetDependancesListe(CRelationTypeEO_Formulaire.c_nomTable, c_champId);
			}
		}

		#endregion


		#region IObjetASystemeDeCoordonnee

		//---------------------------------------------------------------------
		[DynamicField("Coordinate system")]
		public CParametrageSystemeCoordonnees ParametrageCoordonneesApplique
		{
			get 
			{
				return ParametrageCoordonneesPropre;
			}
		}

		//---------------------------------------------------------------------
		public IObjetASystemeDeCoordonnee DonnateurParametrageCoordonneeHerite
		{
			get 
			{
				return null;
			}
		}

		//---------------------------------------------------------------------
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

		//---------------------------------------------------------------------
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
				return "EntitesOrganisationnelles";
			}
		}

		#endregion


		//--------------------------------------------------------------------------------
		public IDefinisseurChampCustom GetDefinisseurForRelationsEoDeType(Type tp)
		{
			return new CDefinisseurChampsCustomTypeEoPourType(this, tp);
		}
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

		//---------------------------------------------------------------------
		public EOptionControleCoordonnees? OptionsControleCoordonneesApplique
		{
			get 
			{
				EOptionControleCoordonnees? option = OptionsControleCoordonneesPropre;

				//On met systématiquement les option IgnorerLoccupation et IgnorerLesUnites
				option |= EOptionControleCoordonnees.IgnorerLoccupation | EOptionControleCoordonnees.IgnorerLesUnites;

				//Inverse (on retire les options systematiquement :
				//option &= ~EOptionControleCoordonnees.IgnorerLoccupation;
				//option &= ~EOptionControleCoordonnees.IgnorerLesUnites;
				return option;
			}
		}

		//---------------------------------------------------------------------
		public IObjetAOptionsDeControleDeCoordonnees DonnateurOptionsControleCoordonneesHerite
		{
			get 
			{
				return null;
			}
		}

		//---------------------------------------------------------------------
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

		//---------------------------------------------------------------------
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

		//---------------------------------------------------------------------
		public bool CanHeriteOptionsControleCoordonnees
		{
			get 
			{
				return false;
			}
		}

		#endregion


        //----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CRelationTypeEO_FormulaireParType), "TypeEntiteOrganisationnelle")]
        [DynamicChilds("Relations formulaires par type", typeof(CRelationTypeEO_FormulaireParType))]
        public CListeObjetsDonnees RelationsFormulairesParType
        {
            get
            {
                return GetDependancesListe(CRelationTypeEO_FormulaireParType.c_nomTable, c_champId);
            }
        }

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Exceptions de Types, pour lesquels on interdit de voir les EO de ce Type dans l'interface utilisateur
        /// </summary>
        [RelationFille(typeof(CExceptionTypePourTypeEO), "TypeEntiteOrganisationnelle")]
        [DynamicChilds("Exceptions for Type", typeof(CExceptionTypePourTypeEO))]
        public CListeObjetsDonnees ExceptionsPourTypes
        {
            get
            {
                return GetDependancesListe(CExceptionTypePourTypeEO.c_nomTable, CTypeEntiteOrganisationnelle.c_champId);
            }
        }

        public bool HasExceptionForType(Type tp)
        {
            if (tp == null)
                return false;

            foreach (CExceptionTypePourTypeEO exception in ExceptionsPourTypes)
            {
                if (exception.TypeElement == tp)
                    return true;
            }

            return false;
        }

        public void AddExceptionForType(Type tp)
        {
            if (tp == null)
                return;

            if (!HasExceptionForType(tp))
            {
                CExceptionTypePourTypeEO nouvelleException = new CExceptionTypePourTypeEO(this.ContexteDonnee);
                nouvelleException.CreateNewInCurrentContexte();
                nouvelleException.TypeEntiteOrganisationnelle = this;
                nouvelleException.TypeElement = tp;
            }
        }

        public CResultAErreur RemoveExceptionForType(Type tp)
        {
            CResultAErreur result = CResultAErreur.True;
            if (tp == null)
                return result;

            foreach (CExceptionTypePourTypeEO exception in ExceptionsPourTypes)
            {
                if (exception.TypeElement == tp)
                {
                    return exception.Delete();
                }
            }

            return result;

        }


	}

	public class CDefinisseurChampsCustomTypeEoPourType : IDefinisseurChampCustom
	{
		private CTypeEntiteOrganisationnelle m_typeEntite = null;
		private Type m_type = null;

		//-------------------------------------------------------------------
		public CDefinisseurChampsCustomTypeEoPourType(CTypeEntiteOrganisationnelle typeEntite, Type tp)
		{
			m_typeEntite = typeEntite;
			m_type = tp;
		}

		#region IDefinisseurChampCustom Membres

		//-------------------------------------------------------------------
		public CContexteDonnee ContexteDonnee
		{
			get { return m_typeEntite.ContexteDonnee; }
		}

		//-------------------------------------------------------------------
		public string DescriptionElement
		{
			get { return I.T("Form for type|301"); }
		}

		//-------------------------------------------------------------------
		public int Id
		{
			get { return -1; }
		}

		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
		}

		//-------------------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get 
			{
				CListeObjetsDonnees liste = m_typeEntite.RelationsFormulairesParType;
				if ( m_type != null )
					liste.Filtre = new CFiltreData ( CRelationTypeEO_FormulaireParType.c_champType+"=@1",
						m_type.ToString());
				List<IRelationDefinisseurChamp_Formulaire> lstRel = new List<IRelationDefinisseurChamp_Formulaire>();
				foreach ( IRelationDefinisseurChamp_Formulaire rel in liste )
					lstRel.Add ( rel );
				return lstRel.ToArray();
			}
		}

			//-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get { return CRoleChampCustom.GetRole ( CRelationElement_EO.c_roleChampCustom ); }
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Remplit une hashtable IdChamp->Champ
		/// avec tous les champs liés.(hiérarchique
		/// </summary>
		/// <param name="tableChamps">HAshtable à remplir</param>
		private void FillHashtableChamps(Hashtable tableChamps)
		{
			foreach (IRelationDefinisseurChamp_Formulaire relation in RelationsFormulaires)
			{
				foreach (CRelationFormulaireChampCustom relFor in relation.Formulaire.RelationsChamps)
					tableChamps[relFor.Champ.Id] = relFor.Champ;
			}
		}

		//-------------------------------------------------------------------
		public CChampCustom[] TousLesChampsAssocies
		{
			get 
			{
				Hashtable tbl = new Hashtable();
				FillHashtableChamps( tbl );
				List<CChampCustom> lst = new List<CChampCustom>();
				foreach (CChampCustom champ in tbl.Values)
					lst.Add(champ);
				return lst.ToArray();
			}
		}

		#endregion
	}
}