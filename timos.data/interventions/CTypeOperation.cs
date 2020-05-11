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
using sc2i.process;
using timos.data.commandes;

namespace timos.data
{
	/// <summary>
    /// Fournit les types possibles d'<see cref="COperation">Op�ration</see>.<br/>
    /// Un type d'op�ration peut contenir des types d'op�ration filles;<br/>
    /// les types d'op�ration filles permettent de d�tailler en d'autres types d'op�ration<br/>
    /// plus pr�cis qui h�ritent des propri�t�s de l'op�ration m�re.
	/// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [DynamicClass("Operation Type")]
	[Table(CTypeOperation.c_nomTable, CTypeOperation.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeOperationServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_TypeInterEtOps_ID)]
    [TiagClass(CTypeOperation.c_nomTiag, "Id", true)]
    [DynamicIcon(typeof(COperation), ETypeIconeDynamique.EType)]
    public class CTypeOperation : 
                    CObjetHierarchique,
		            IDefinisseurChampCustom,
                    IDefinisseurEvenements,
                    IElementValorisable
	{

        public const string c_nomTable = "OPERATION_TYPE";
        public const string c_nomTiag = "Operation Type";
		
		public const string c_champId = "OPTYP_ID";
		public const string c_champLibelle = "OPTYP_LABEL";
		public const string c_champCode = "OPTYP_CODE";
		public const string c_champDureeStandard = "OPTYP_DURATION_HOURS";
		public const string c_champDescriptif = "OPTYP_DESC";
		public const string c_champIsRemplacementMateriel = "OPTYP_IS_RPCLT_MAT";
		public const string c_champSaisieDuree = "OPTYP_INPUT_DURATION";
        public const string c_champSaisieDureeParHeureFin = "OPTYP_INPUT_ENDDATE";
		public const string c_champSaisieHeureDebut = "OPTYP_INPUT_TIME";
        public const string c_champIdFormCR = "OPTYP_FORM_CR";
        public const string c_champIdFormPrev = "OPTYP_FORM_PREV";
        public const string c_champOptionLieeAEquipement = "OPTYP_LINK_EQPT";
        public const string c_champOptionRemplacement = "OPTYP_REPLACE";
        public const string c_champOptionGeneOpParTypeEqpt = "OPTYP_GEN_EQPTPERTYP";
        public const string c_champLockTypeAfterCreation = "OPTYP_LOCKTP_AFTCR";
        public const string c_champLockSuppressionApresCreation = "OPTYPE_LOCKDEL_AFTCR";
        public const string c_champLockAuteur = "OPTYPE_LOCKAUTHOR";
        
		public const string c_champCodeSysteme = "OPTYP_PARTIAL_SYSCO";
		public const string c_champCodeSystemComplet = "OPTYP_FULL_SYSCODE";
		public const string c_champIdOperationParente = "OPTYP_PARENT_ID";
		public const string c_champNiveau = "OPTYP_LEVEL";
        public const string c_champPropagerSurPhase = "OPTYP_TO_PHASE";


		/// /////////////////////////////////////////////
		public CTypeOperation( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTypeOperation(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Operation type @1|135",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			base.MyInitValeurDefaut();
            SaisieDureePropre = true;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		//-----------------------------------------------
        /// <summary>
        /// Libell� du type d'op�ration
        /// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		[RechercheRapide]
        [DescriptionField]
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

        ////////////////////////////////////////////////
        [DynamicField("Full label")]
        public string LibelleComplet
        {
            get
            {
                string strLib = "";
                if (TypeOperationParente != null)
                    strLib = TypeOperationParente.LibelleComplet + "/";
                strLib += Libelle;
                return strLib;
            }
        }

		////////////////////////////////////////////////
		/// <summary>
		/// code du type d'op�ration. Ce code appara�t dans les comptes-rendus<br/>
        /// des op�rations au niveau de l'intervention et peut servir pour les statistiques.
		/// </summary>
		[TableFieldProperty ( CTypeOperation.c_champCode, 64)]
		[DynamicField("Code")]
		[RechercheRapide]
        [TiagField("Code")]
		public string Code
		{
			get
			{
				return ( string )Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Dur�e habituelle du type d'op�ration. Il s'agit de la dur�e standard par d�faut<br/>
        /// pour une op�ration de ce type, effectu�e sans difficult� particuli�re<br/>
        /// dans des conditions normales par un op�rateur normalement qualifi� pour ce type d'op�ration.<br/>
        /// Selon les conditions particuli�res de l'op�ration, la dur�e r�elle d'une op�ration<br/>
        /// de ce type peut diff�rer de la dur�e habituelle, dans ce cas, la dur�e sera modifi�e<br/>
        /// lors de la cr�ation du rapport d'intervention.
        /// </summary>
		[TableFieldProperty(c_champDureeStandard)]
		[DynamicField("Standard duration")]
        [TiagField("Standard duration")]
		public double DureeStandardHeures
		{
			get
			{
				return (double)Row[c_champDureeStandard];
			}
			set
			{
				Row[c_champDureeStandard] = value;
			}
		}


		

		//-----------------------------------------------------------
        /// <summary>
        /// Description d�taill�e du type d'op�ration
        /// </summary>
		[TableFieldProperty(c_champDescriptif, 1024)]
        [DynamicField("Description")]
        [TiagField("Description")]
		public string Descriptif
		{
			get
			{
				return (string)Row[c_champDescriptif];
			}
			set
			{
				Row[c_champDescriptif] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Si VRAI, indique que l'utilisateur doit saisir une dur�e<br/>
        /// pour les op�rations de ce type.
		/// </summary>
		[TableFieldProperty(c_champSaisieDuree, NullAutorise = true)]
		[DynamicField("Duration input")]
        [TiagField("Duration input")]
		public bool? SaisieDureePropre
		{
			get
			{
				return (bool?)Row[c_champSaisieDuree,true];
			}
			set
			{
				Row[c_champSaisieDuree, true] = value;
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Si VRAI, indique que l'utilisateur doit saisir une date de fin<br/>
        /// pour les op�rations de ce type.
        /// </summary>
        [TableFieldProperty(CTypeOperation.c_champSaisieDureeParHeureFin)]
        [DynamicField("Input end date")]
        [TiagField("Input end date")]
        public bool SaisieDureeParDateFin
        {
            get
            {
                return (bool)Row[c_champSaisieDureeParHeureFin];
            }
            set
            {
                Row[c_champSaisieDureeParHeureFin] = value;
            }
        }


        //------------------------------------------------------------------
        public bool SaisieDureeAppliquee
        {
            get
            {
                if (SaisieDureePropre == null)
                    if (TypeOperationParente != null)
                        return TypeOperationParente.SaisieDureeAppliquee;
                    else
                        return false;
                return (bool)SaisieDureePropre;
            }
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Si VRAI, indique que l'utilisateur doit saisir l'heure<br/>
        /// pour les op�rations de ce type.
		/// </summary>
		[TableFieldProperty(CTypeOperation.c_champSaisieHeureDebut, NullAutorise = true)]
		[DynamicField("Time input")]
        [TiagField("Time input")]
		public bool? SaisieHeurePropre
		{
			get
			{
				return (bool?)Row[c_champSaisieHeureDebut, true];
			}
			set
			{
				Row[c_champSaisieHeureDebut, true] = value;
			}
		}


		//------------------------------------------------------------------
		public bool SaisieHeureAppliquee
		{
			get
			{
				if (SaisieHeurePropre == null)
					if (TypeOperationParente != null)
						return TypeOperationParente.SaisieHeureAppliquee;
					else
						return false;
				return (bool)SaisieHeurePropre;
			}
		}


        public void TiagSetTypeOccupationKeys(object[] lstCles)
        {
            CTypeOccupationHoraire tpOccup = new CTypeOccupationHoraire(ContexteDonnee);
            if (tpOccup.ReadIfExists(lstCles))
                TypeOccupationPropre = tpOccup;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou d�finit le type d'occupation correspondant au type d'op�ration.<br/>
        /// Facultatif, le type d'occupation appara�t dans les emplois du temps<br/>
        /// des personnels ayant effectu� l'op�ration dans le cadre d'une intervention.
		/// </summary>
		[Relation(
			CTypeOccupationHoraire.c_nomTable,
			CTypeOccupationHoraire.c_champId,	
			CTypeOccupationHoraire.c_champId,
			false,
			false,
			false)]
		[DynamicField("Occupation type")]
        [TiagRelation(typeof(CTypeOccupationHoraire), "TiagSetTypeOccupationKeys")]
		public CTypeOccupationHoraire TypeOccupationPropre
		{
			get
			{
				return (CTypeOccupationHoraire)GetParent(CTypeOccupationHoraire.c_champId, typeof(CTypeOccupationHoraire));
			}
			set
			{
				SetParent(CTypeOccupationHoraire.c_champId, value);
			}
		}


		//-------------------------------------------
		public CTypeOccupationHoraire TypeOccupationAppliquee
		{
			get
			{
				if (TypeOccupationPropre == null &&
				TypeOperationParente != null)
					return TypeOperationParente.TypeOccupationAppliquee;
				return TypeOccupationPropre;
			}
		}


		
		//-------------------------------------------------------------------
		/// <summary>
        /// Formulaire pour saisie du compte rendu d'op�ration
		/// </summary>
		[Relation(
			CFormulaire.c_nomTable,
			CFormulaire.c_champId,
			CTypeOperation.c_champIdFormCR,
			false,
			false,
			false)]
		[DynamicField("Operation Report Form")]
		public CFormulaire FormulaireCompteRendu
		{
			get
			{
                return (CFormulaire)GetParent(CTypeOperation.c_champIdFormCR, typeof(CFormulaire));
			}
			set
			{
                SetParent(CTypeOperation.c_champIdFormCR, value);
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Formulaire pour les Op�rations planifi�es dans une intervention
        /// </summary>
        [Relation(
            CFormulaire.c_nomTable,
            CFormulaire.c_champId,
            CTypeOperation.c_champIdFormPrev,
            false,
            false,
            false)]
        [DynamicField("Planed Operation Form")]
        public CFormulaire FormulaireOpPrevisionnelle
        {
            get
            {
                return (CFormulaire)GetParent(CTypeOperation.c_champIdFormPrev, typeof(CFormulaire));
            }
            set
            {
                SetParent(CTypeOperation.c_champIdFormPrev, value);
            }
        }

		//---------------------------------------------------------
		public IRelationDefinisseurChamp_ChampCustom[] RelationsChampsCustomDefinis
		{
			get { return new IRelationDefinisseurChamp_ChampCustom[0]; }
		}

		//---------------------------------------------------------
		public IRelationDefinisseurChamp_Formulaire[] RelationsFormulaires
		{
			get
			{
                ArrayList listForm = new ArrayList();
                if (FormulaireCompteRendu != null)
				{
					CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, FormulaireCompteRendu);
					listForm.Add(new IRelationDefinisseurChamp_Formulaire[] { rel });
				}

                if (FormulaireOpPrevisionnelle != null)
                {
                    CRelationDefinisseurChamp_FormulaireStatic rel = new CRelationDefinisseurChamp_FormulaireStatic(this, FormulaireOpPrevisionnelle);
                    listForm.Add(new IRelationDefinisseurChamp_Formulaire[] { rel });
                }

                return (IRelationDefinisseurChamp_Formulaire[])listForm.ToArray(typeof(IRelationDefinisseurChamp_Formulaire));
			}
		}

		//---------------------------------------------------------
		public CChampCustom[] TousLesChampsAssocies
		{
			get
			{
				List<CChampCustom> lst = new List<CChampCustom>();
				if (FormulaireCompteRendu != null)
					foreach (CRelationFormulaireChampCustom rel in FormulaireCompteRendu.RelationsChamps)
						lst.Add(rel.Champ);
				return lst.ToArray();
			}
		}
	


		//-----------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomDesElementsAChamp
		{
			get
			{
				return CRoleChampCustom.GetRole(COperation.c_roleChampCustom);
			}
		}

		
		//-----------------------------------------------------------------------
		public override int NbCarsParNiveau
		{
			get { return 2; }
		}

		//-----------------------------------------------------------------------
		public override string ChampCodeSystemePartiel
		{
			get { return c_champCodeSysteme; }
		}

		//-----------------------------------------------------------------------
		public override string ChampCodeSystemeComplet
		{
			get { return c_champCodeSystemComplet; }
		}

		//-----------------------------------------------------------------------
		public override string ChampNiveau
		{
			get { return c_champNiveau; }
		}

		//-----------------------------------------------------------------------
		public override string ChampLibelle
		{
			get { return c_champLibelle; }
		}

		//-----------------------------------------------------------------------
		public override string ChampIdParent
		{
			get { return c_champIdOperationParente; }
		}

		//-----------------------------------------------------------------------
        /// <summary>
        /// Code syst�me propre au type d'op�ration.<br/>
        /// Ce code est exprim� sur 2 caract�res alphanum�riques,<br/>
        /// il est unique dans son parent.
        /// </summary>
		[TableFieldProperty ( CTypeOperation.c_champCodeSysteme, 4 )]
		[DynamicField("Partial system code")]
		public override string CodeSystemePartiel
		{
			get
			{
				return (string)Row[c_champCodeSysteme];
			}
		}

		//-----------------------------------------------------------------------
        /// <summary>
        /// Code syst�me complet du type d'op�ration. Ce code syst�me est<br/>
        /// constitu� du code syst�me complet du type d'op�ration parente<br/>
        /// concat�n� avec le code syst�me propre du type d'op�ration.<br/>
        /// Exemple : TPOP_GRDPARENTE -> TPOP_PARENTE -> TPOP_FILLE<br/>
        /// si le code de TPOP_GRDPARENTE est 01, le code de TPOP_PARENTE est 03 et<br/>
        /// et le code propre de TPOP_FILLE est 08, le code syst�me complet<br/>
        /// de TPOP_FILLE est 010308.
        /// </summary>
		[TableFieldProperty ( CTypeOperation.c_champCodeSystemComplet, 100)]
		[DynamicField("Full system code")]
		public override string CodeSystemeComplet
		{
			get
			{
				return (string)Row[c_champCodeSystemComplet];
			}
		}

		//-----------------------------------------------------------------------
        /// <summary>
        /// Niveau du type d'op�ration dans la hi�rarchie des types (nombre de parents).<br/>
        /// Exemple : TPOP_GRDPARENTE -> TPOP_PARENTE -> TPOP_FILLE<br/>
        /// TPOP_GRDPARENTE a pour niveau 0, TPOP_PARENTE a pour niveau 1<br/>
        /// (1 parent en remontant la hi�rarchie), TPOP_FILLE a pour niveau 2<br/>
        /// (2 parents en remontant la hi�rarchie)
        /// </summary>
		[TableFieldProperty ( CTypeOperation.c_champNiveau )]
		[DynamicField("Level")]
		public override int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
		}

        public void TiagSetTypeOperationParenteKeys(object[] lstCles)
        {
            CTypeOperation tpParente = new CTypeOperation(ContexteDonnee);
            if (tpParente.ReadIfExists(lstCles))
                TypeOperationParente = tpParente;
        }
        //-----------------------------------------------------------------------
		/// <summary>
		/// Donne ou d�finit le Type d'op�ration parente
		/// </summary>
		[Relation(
			CTypeOperation.c_nomTable,
			CTypeOperation.c_champId,
			CTypeOperation.c_champIdOperationParente,
			false,
			false,
			false)]
		[DynamicField("Parent type")]
		public CTypeOperation TypeOperationParente
		{
			get
			{
				return (CTypeOperation)ObjetParent;
			}
			set
			{
				ObjetParent = value;
			}
		}

		
		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des Types d'op�ration filles
		/// </summary>
		[RelationFille(typeof(CTypeOperation), "TypeOperationParente")]
		[DynamicChilds("Child types", typeof(CTypeOperation))]
		public CListeObjetsDonnees TypesOperationsFilles
		{
			get
			{
				return GetDependancesListe(CTypeOperation.c_nomTable, c_champIdOperationParente);
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Option qui sp�cifie si les Op�rations de ce Type doivent �tre li�es � un Equipement<br/>
        /// Que ce soit en mode pr�visionnelle ou en mode compte-rendu (si VRAI)
        /// </summary>
        [TableFieldProperty(c_champOptionLieeAEquipement)]
        [DynamicField("Linked To Equipment Option")]
        [TiagField("Linked To Equipment Option")]
        public bool IsLieeAEquipement
        {
            get
            {
                return (bool)Row[c_champOptionLieeAEquipement];
            }
            set
            {
                Row[c_champOptionLieeAEquipement] = value;
            }
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Option qui indique si l'�quipement li� est li� pour remplacement (si VRAI)
        /// </summary>
        [TableFieldProperty(c_champOptionRemplacement)]
        [DynamicField("Replace Equipment Option")]
        [TiagField("Replace Equipment Option")]
        public bool IsRemplacementEquipement
        {
            get
            {
                return (bool)Row[c_champOptionRemplacement];
            }
            set
            {
                Row[c_champOptionRemplacement] = value;
            }
        }

        //-----------------------------------------------------------

        /// <summary>
        /// Option qui indique si on doit g�n�rer une Op�ration par Type d'Equipement pr�sent sur le Site<br/>
        /// Le Type d'�quipement li� est renseign� lorsque l'Op�ration est dans une liste d'Op�rations<br/>
        /// (si VRAI)
        /// </summary>
        [TableFieldProperty(c_champOptionGeneOpParTypeEqpt)]
        [DynamicField("Generate one Operation per Equipment type")]
        [TiagField("Generate one Operation per Equipment type")]
        public bool GenererUneOpParTypeEquipement
        {
            get
            {
                return (bool)Row[c_champOptionGeneOpParTypeEqpt];
            }
            set
            {
                Row[c_champOptionGeneOpParTypeEqpt] = value;
            }
        }



        //---------------------------------------------------------------------------
        /// <summary>
        /// Si True, associe l'op�ration � la phase de ticket li�e � l'intervention
        /// </summary>
        [TableFieldProperty(c_champPropagerSurPhase, NullAutorise = true)]
        [DynamicField("Propagate to Ticket Phase")]
        [TiagField("Propagate to Ticket Phase")]
        public bool? PropagerSurPhasePropre
        {
            get
            {
                return (bool?)Row[c_champPropagerSurPhase, true];
            }
            set
            {
                Row[c_champPropagerSurPhase, true] = value;
            }
        }

        //---------------------------------------------------------------------------
        public bool PropagerSurPhaseApplique
        {
            get 
            {
                if (PropagerSurPhasePropre == null)
                    if (TypeOperationParente != null)
                        return TypeOperationParente.PropagerSurPhaseApplique;
                    else
                        return false;
                return (bool)PropagerSurPhasePropre;
            }
        }

        //---------------------------------------------------------------------------
        /// <summary>
        /// Indique que le type d'une op�ration de ce type ne peut plus �tre
        /// chang� apr�s validation (si VRAI)
        /// </summary>
        [TableFieldProperty(CTypeOperation.c_champLockTypeAfterCreation)]
        [sc2i.common.DynamicField("Lock type after creation")]
        [TiagField("Lock type after creation")]
        public bool VerrouillerLeTypeApresCreation
        {
            get
            {
                return (bool)Row[c_champLockTypeAfterCreation];
            }
            set
            {
                Row[c_champLockTypeAfterCreation] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Si VRAI, indique que l'op�ration de ce type<br/>
        /// ne plus �tre supprim�e apr�s sa cr�ation.
        /// </summary>
        [TableFieldProperty(c_champLockSuppressionApresCreation)]
        [DynamicField("Disable delete after creation")]
        [TiagField("Disable delete after creation")]
        public bool InterditSuppressionApresCreation
        {
            get
            {
                return (bool)Row[c_champLockSuppressionApresCreation];
            }
            set
            {
                Row[c_champLockSuppressionApresCreation] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Si vrai, indique que l'auteur ne peut pas �tre modifi� par<br/>
        /// l'utilisateur de l'application.
        /// </summary>
        [TableFieldProperty(c_champLockAuteur)]
        [DynamicField("Lock Author")]
        [TiagField("Lock Author")]
        public bool VerrouillerAuteur
        {
            get
            {
                return (bool)Row[c_champLockAuteur];
            }
            set
            {
                Row[c_champLockAuteur] = value;
            }
        }


        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CValorisationElement), "TypeOperation")]
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
        /// Retourne la valeur d'une op�ration de ce type pour une date donn�e
        /// </summary>
        /// <remarks>
        /// La valeur retourn�e correspond � la valorisation dont la date
        /// est maximale et inf�rieure � la date demand�e. <BR></BR>
        /// S'il n'existe pas de valorisation correspondante, <BR></BR>
        /// Si la date demand�e est inf�rieure � la premi�re valorisation
        /// connue, la valeur retourn�e est la premi�re valorisation connue<BR></BR>
        /// Sinon, ce sera la date de la valorisation la plus r�cente<BR></BR>
        /// S'il n'existe pas de valorisation pour ce type d'�quipement, la
        /// valeur retourn�e sera 0
        /// </remarks>
        /// <param name="dt"></param>
        /// <returns></returns>
        [DynamicMethod("Return valuation for a specific date", "Date")]
        public double GetValuationForDate(DateTime dt)
        {
            CListeObjetsDonnees lstValOp = Valorisations;
            CListeObjetsDonnees lstLot = lstValOp.GetDependances("LotValorisation");
            if (lstValOp.Count == 0)
                return 0;
            lstLot.Tri = CLotValorisation.c_champDateLot;
            CLotValorisation lot = lstLot[0] as CLotValorisation;
            if (lot != null && lot.DateLot.Date.AddMinutes(-1) > dt)//Premier plus r�cent->premier
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




        #region IDefinisseurEvenements Membres

        public CComportementGenerique[] ComportementsInduits
        {
            get { return CUtilDefinisseurEvenement.GetComportementsInduits(this); }
        }

        public CListeObjetsDonnees Evenements
        {
            get { return CUtilDefinisseurEvenement.GetEvenementsFor(this); }
        }

        public Type[] TypesCibleEvenement
        {
            get { return new Type[] { typeof(COperation) }; }
        }

        #endregion
    }
}
