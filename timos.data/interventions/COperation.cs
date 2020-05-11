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
using timos.data.version;
using timos.acteurs;
using tiag.client;
using sc2i.process;
using timos.data.projet.besoin;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Une Opération est une action élémentaire réalisée dans le cadre d'une <see cref="CIntervention">Intervention</see>.<br/>
    /// Exemple : le remplacement, le montage ou la réparation d'un équipement.<br/>
    /// Toute opération est d'un type prédéfini. Chaque <see cref="CTypeOperation">type d'opération</see> possède une durée habituelle.<br/>
    /// Les opérations peuvent être associées à des formulaires pour la saisie du compte-rendu de l'opération.<br/>
    /// Une Opération peut être composée de sous-opérations.
    /// </summary>
	[DynamicClass("Operation")]
	[Table(COperation.c_nomTable, COperation.c_champId, true)]
	[ObjetServeurURI("COperationServeur")]
	[AutoExec("Autoexec")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(COperation.c_nomTiag, "Id", true)]
    [TypeId("OPERATION")]
    public class COperation : CObjetDonneeAIdNumeriqueAuto,  
							IObjetDonneeAChamps,
							IObjetDonneeAutoReference,
							IElementATypeStructurant<CTypeOperation>,
                            IElementAEvenementsDefinis,
                            IElementACout
	{

        public const string c_nomTable = "OPERATION";
        public const string c_nomTiag = "OPERATION";

		public const string c_champId = "OP_ID";
		public const string c_champIndex ="OP_INDEX";

		public const string c_champNiveau = "OP_LEVEL";
		public const string c_champCommentaires = "OP_COMMENT";
        
		public const string c_champIdOpParente = "OP_PARENT_ID";
		public const string c_champDuree = "OP_DURATION";
		public const string c_champHeureDebut = "OP_START_TIME";
        public const string c_champDateDebut = "OP_START_DATE";

        public const string c_champCoutPrevisionnel = "OP_ESTIMATED_COST";
        public const string c_champCoutReel = "OP_ACTUAL_COST";

        public const string c_roleChampCustom = "OPERATION";

		/// /////////////////////////////////////////////
		public COperation(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public COperation(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Operation", typeof(COperation), typeof(CTypeOperation));
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
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				string strRetour = I.T( "Operation|137") ;
                if (TypeOperation != null)
                    strRetour += " "+ TypeOperation.Libelle;
                return strRetour;
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champIndex };
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Retourne ou définit l'Index de l'Opération.<br/>
        /// Il s'agit de l'ordre d'apparition de l'opération dans la liste des Opérations.
		/// </summary>
		[TableFieldProperty(c_champIndex)]
		[DynamicField("Index")]
        [TiagField("Index")]
		public int Index
		{
			get
			{
				return (int)Row[c_champIndex];
			}
			set
			{
				Row[c_champIndex] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Commentaire (2000 caractères maximum).
		/// </summary>
		[TableFieldProperty(c_champCommentaires, 2000)]
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


		//-----------------------------------------------------------
		/// <summary>
		/// Niveau dans la hiérarchie des opérations (nombre de parents).<br/>
        /// Supposons la hiérachie suivante : installation BTS -> Montage châssis -> Montage alimentation,<br/>
        /// l'opération 'Installation BTS' a pour niveau 0, 'Montage châssis' a pour niveau 1 et<br/>
        /// 'Montage alimentation' a pour niveau 2 (2 parents en remontant la hiérarchie).
		/// </summary>
		[TableFieldProperty(c_champNiveau)]
		[DynamicField("Level")]
        [TiagField("Level")]
		public int Niveau
		{
			get
			{
				return (int)Row[c_champNiveau];
			}
			set
			{
				Row[c_champNiveau] = value;
			}
		}

        public void TiagSetOperationParenteKeys(object[] lstCles)
        {
            COperation op = new COperation(ContexteDonnee);
            if (op.ReadIfExists(lstCles))
                OperationParente = op;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Retourne ou définit l'Opération Parente. 
		/// </summary>
		[Relation(
			COperation.c_nomTable,
			COperation.c_champId,
			COperation.c_champIdOpParente,
			false,
			true,
			true,
            DeleteEnCascadeManuel=true)]
		[DynamicField("Parent operation")]
        [TiagRelation(typeof(COperation), "TiagSetOperationParenteKeys")]
		public COperation OperationParente
		{
			get
			{
				return (COperation)GetParent(COperation.c_champIdOpParente, typeof(COperation));
			}
			set
			{
				SetParent(COperation.c_champIdOpParente, value);
                if (value == null)
                    Niveau = 0;
                else
                    Niveau = value.Niveau + 1;
			}
		}



		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des Operations Filles
		/// </summary>
		[RelationFille(typeof(COperation), "OperationParente")]
		[DynamicChilds("Child operations", typeof(COperation))]
		public CListeObjetsDonnees OperationsFilles
		{
			get
			{
				return GetDependancesListe(COperation.c_nomTable, c_champIdOpParente);
			}
		}


		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne ou définit la Durée de l'opération exprimée en nombre décimal,<br/>
        /// ainsi 1h30mn s'exprime par 1,5 
		/// </summary>
		[TableFieldProperty ( c_champDuree, NullAutorise = true )]
		[DynamicField("Duration")]
        [TiagField("Duration")]
		public double? Duree
		{
			get
			{
				return (double?)Row[c_champDuree, true];
			}
			set
			{
                double? fOld = Duree;
				Row[c_champDuree, true] = value;
                if (fOld != value)
                {
                    if ( Intervention != null )
                        CUtilElementACout.OnChangeCout(this, false, false);
                    if ( FractionIntervention != null )
                        CUtilElementACout.OnChangeCout(this, true, false);
                }
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Retourne ou définit l'Heure de début de l'opération
		/// </summary>
		[TableFieldProperty(c_champHeureDebut, NullAutorise = true)]
		[DynamicField("Start time")]
        [TiagField("Start time")]
		public double? HeureDebut
		{
			get
			{
				return (double?)Row[c_champHeureDebut, true];
			}
			set
			{
				Row[c_champHeureDebut, true] = value;
			}
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Retourne ou définit l'Heure de fin de l'opération
        /// </summary>
        [TableFieldProperty(c_champDateDebut, NullAutorise = true)]
        [DynamicField("Start Date")]
        [TiagField("Start Date")]
        public DateTime? DateDebut
        {
            get
            {
                return (DateTime?)Row[c_champDateDebut, true];
            }
            set
            {
                Row[c_champDateDebut, true] = value;
                if (value != null)
                {
                    // Propage sur l'heure de début pour compatibilité
                    DateTime dt = (DateTime) value;
                    HeureDebut = (double)dt.Hour + ((double)dt.Minute / 60);
                }
            }
        }



        public void TiagSetTypeOperationKeys(object[] lstCles)
        {
            CTypeOperation tpOp = new CTypeOperation(ContexteDonnee);
            if (tpOp.ReadIfExists(lstCles))
                TypeOperation = tpOp;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Retourne ou définit le Type d'opération<br/>
		/// (obligatoire)
		/// </summary>
		[Relation(
			CTypeOperation.c_nomTable,
			CTypeOperation.c_champId,
			CTypeOperation.c_champId,
			true,
			false,
			true)]
		[DynamicField("Operation type")]
        [TiagRelation(typeof(CTypeOperation), "TiagSetTypeOperationKeys")]
		public CTypeOperation TypeOperation
		{
			get
			{
				return (CTypeOperation)GetParent(CTypeOperation.c_champId, typeof(CTypeOperation));
			}
			set
			{
                CTypeOperation oldType = TypeOperation;
				SetParent(CTypeOperation.c_champId, value);
                if (oldType != value)
                {
                    if (Intervention != null)
                    {
                        CUtilElementACout.OnChangeCout(this, false, false);
                    }
                }

			}
		}


        public void TiagSetFractionKeys(object[] lstCles)
        {
            CFractionIntervention frac = new CFractionIntervention(ContexteDonnee);
            if (frac.ReadIfExists(lstCles))
                FractionIntervention = frac;
        }
        //---------------------------------------------------------------------------------------
		/// <summary>
		/// Retourne ou définit la Fraction d'Intervention liée à l'Opération réalisée
		/// </summary>
		[Relation(
			CFractionIntervention.c_nomTable,
			CFractionIntervention.c_champId,
			CFractionIntervention.c_champId,
			false,
			true,
			false)]
		[DynamicField("Intervention part")]
		[TiagRelation(typeof(CFractionIntervention), "TiagSetFractionKeys")]
        public CFractionIntervention FractionIntervention
		{
			get
			{
				return (CFractionIntervention)GetParent(CFractionIntervention.c_champId, typeof(CFractionIntervention));
			}
			set
			{
				SetParent(CFractionIntervention.c_champId, value);
			}
		}


        public void TiagSetPhaseTicketKeys(object[] lstCles)
        {
            CPhaseTicket phase = new CPhaseTicket(ContexteDonnee);
            if (phase.ReadIfExists(lstCles))
                PhaseTicket = phase;
        }
        //------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne ou définit la phase de ticket à laquelle l'Opération peut être liée en tant qu'opération réalisée
        /// </summary>
        [Relation(
            CPhaseTicket.c_nomTable,
            CPhaseTicket.c_champId,
            CPhaseTicket.c_champId,
            false,
            false,
            false)]
        [DynamicField("Ticket Phase")]
        [TiagRelation(typeof(CPhaseTicket), "TiagSetPhaseTicketKeys")]
        public CPhaseTicket PhaseTicket
        {
            get
            {
                return (CPhaseTicket)GetParent(CPhaseTicket.c_champId, typeof(CPhaseTicket));
            }
            set
            {
                SetParent(CPhaseTicket.c_champId, value);
            }
        }

        //------------------------------------------------------------------------------------
        public IElementAOperationsRealisees ElementAOperationsRealisees
        {

            get
            {
                IElementAOperationsRealisees element = FractionIntervention;
                if (element == null)
                    element = PhaseTicket;
                return element;
            }
            set
            {
                if (value is CFractionIntervention)
                {
                    FractionIntervention = (CFractionIntervention) value;
                    PhaseTicket = null;
                }
                else
                {
                    FractionIntervention = null;
                    PhaseTicket = (CPhaseTicket) value;
                }
            }
        }

        public void TiagSetInterventionKeys(object[] lstCles)
        {
            CIntervention inter = new CIntervention(ContexteDonnee);
            if (inter.ReadIfExists(lstCles))
                Intervention = inter;
        }
        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne ou définit l'Intervention parente pour laquelle l'Opération est en prévisionnel
        /// </summary>
        [Relation(
            CIntervention.c_nomTable,
            CIntervention.c_champId,
            CIntervention.c_champId,
            false,
            true,
            false)]
        [DynamicField("Intervention")]
        [TiagRelation(typeof(CIntervention), "TiagSetInterventionKeys")]
        public CIntervention Intervention
        {
            get
            {
                return (CIntervention)GetParent(CIntervention.c_champId, typeof(CIntervention));
            }
            set
            {
                SetParent(CIntervention.c_champId, value);
            }
        }


        public void TiagSetListeOperationsKeys(object[] lstCles)
        {
            CListeOperations liste = new CListeOperations(ContexteDonnee);
            if (liste.ReadIfExists(lstCles))
                ListeOperations = liste;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Retourne ou définit la liste d'opérations à laquelle l'opération appartient
        /// </summary>
        [Relation(
            CListeOperations.c_nomTable,
            CListeOperations.c_champId,
            CListeOperations.c_champId,
            false,
            true,
            true)]
        [DynamicField("Operation List")]
        [TiagRelation(typeof(CListeOperations), "TiagSetListeOperationsKeys")]
        public CListeOperations ListeOperations
        {
            get
            {
                return (CListeOperations)GetParent(CListeOperations.c_champId, typeof(CListeOperations));
            }
            set
            {
                SetParent(CListeOperations.c_champId, value);
            }
        }



        //-------------------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit l'élement qui contient l'opération en mode prévisionnelle.<br/>
        /// Ce peut être une liste d'opérations ou une intervention.
        /// </summary>
        [DynamicField("Planified Operation Parent Element")]
        public IElementAOperationPrevisionnelle ElementAOperationPrevisionnelle
        {
            get
            {
                IElementAOperationPrevisionnelle element = ListeOperations;
                if (element == null)
                    element = Intervention;
                return element;
            }
            set
            {
                if (value is CListeOperations)
                {
                    ListeOperations = (CListeOperations) value;
                    Intervention = null;
                    FractionIntervention = null;
                }
                else
                {
                    ListeOperations = null;
                    Intervention = (CIntervention) value;
                    FractionIntervention = null;
                }

            }
        }

        //--------------------------------------------------------------------------------------------
        public CResultAErreur CreerOperationPrevisionnelleSurIntervention(CIntervention intervention)
        {
            return CreerOperationPrevisionnelleSurIntervention(intervention, null);
        }

        //--------------------------------------------------------------------------------------------
        public CResultAErreur CreerOperationPrevisionnelleSurIntervention(CIntervention intervention, CEquipement equipement)
        {
            CResultAErreur result = CResultAErreur.True;
            
            if (this.Intervention != null)
            {
                result.EmpileErreur(I.T( "The Operation is already planned in the Intervention '@1'|428", Intervention.Libelle));
                return result;
            }

            if (this.FractionIntervention!= null)
            {
                result.EmpileErreur(I.T( "The Operation is already associated to the Intervention '@1' report|429", Intervention.Libelle));
                return result;
            }

            COperation newOperation = new COperation(ListeOperations.ContexteDonnee);
            newOperation.CreateNewInCurrentContexte();
            newOperation.TypeOperation = TypeOperation;
            newOperation.Intervention = intervention;
            newOperation.Commentaires = Commentaires;
            newOperation.TypeEquipement = TypeEquipement;
            newOperation.Equipement = equipement;

            if (TypeOperation.FormulaireOpPrevisionnelle != null)
            {
                foreach (CRelationOperation_ChampCustom relChamp in this.RelationsChampsCustom)
                {
                    CRelationOperation_ChampCustom relClone = (CRelationOperation_ChampCustom) relChamp.Clone(false);
                    relClone.ElementAChamps = newOperation;

                }
            }
            result.Data = newOperation;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="interventionPart"></param>
        /// <param name="parentOperation"></param>
        /// <returns></returns>
        [DynamicMethod("Create a new operation from current operation, and associates it to the given Part",
            "Intervention Part to be associated with",
            "Optional Parent Operation (can be null)")]
        public CResultAErreur CreatePerformedOperation(CFractionIntervention interventionPart, COperation parentOperation)
        {
            return CreateRealisee(interventionPart, parentOperation);
        }

        //Crée une opération réalisée à partir d'une opération prévisionnelle
        public CResultAErreur CreateRealisee(CFractionIntervention fractionDest, COperation opParente)
        {
            COperation newOperation = new COperation(fractionDest.ContexteDonnee);
            newOperation.CreateNewInCurrentContexte();
            newOperation.TypeOperation = TypeOperation;
            newOperation.FractionIntervention = fractionDest;
            newOperation.Commentaires = Commentaires;
            newOperation.TypeEquipement = TypeEquipement;
            newOperation.Equipement = Equipement;
            newOperation.OperationParente = opParente;

            if (TypeOperation.FormulaireOpPrevisionnelle != null)
            {
                foreach (CRelationOperation_ChampCustom relChamp in this.RelationsChampsCustom)
                {
                    CRelationOperation_ChampCustom relClone = (CRelationOperation_ChampCustom)relChamp.Clone(false);
                    relClone.ElementAChamps = newOperation;
                }
            }

            foreach (COperation opFille in OperationsFilles)
            {
                opFille.CreateRealisee(fractionDest, newOperation);
            }
            CResultAErreur result = CResultAErreur.True;
            result.Data = newOperation;
            return result;
        }
            

            
            

		//public bool IsOperationSimilaire(COperation operation)
		//{
		//    return (operation.TypeOperation == TypeOperation
		//    && operation.Intervention == Intervention
		//    && operation.Commentaires == Commentaires
		//    && operation.TypeEquipement == TypeEquipement
		//    && operation.Equipement == Equipement);
		//}


        #region Remplacement
        //---------------------------------------------
        /// <summary>
        /// Objet de remplacement d'équipement lié à l'opération
        /// </summary>
        [DynamicField("Associated replacement")]
		[OptimiseReadDependance("Remplacements")]
        public CRemplacementEquipement RemplacementAssocie
        {
            get
            {
                CListeObjetsDonnees lst = Remplacements;
                if (lst.Count == 1)
                    return (CRemplacementEquipement)lst[0];
                return null;
            }
        }


        //---------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        [RelationFille(typeof(CRemplacementEquipement), "Operation")]
        //[DynamicChilds("Remplacement associé", typeof(CRemplacementEquipement))]
        public CListeObjetsDonnees Remplacements
        {
            get
            {
                return GetDependancesListe(CRemplacementEquipement.c_nomTable, c_champId);
            }
        }
        #endregion

		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationOperation_ChampCustom(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationOperation_ChampCustom.c_nomTable;
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
				return new IDefinisseurChampCustom[] { TypeOperation };
			}
		}

		//----------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			return new CChampCustom[0];
		}

		//----------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            ArrayList listForm = new ArrayList();
            CFormulaire formulaire = null;
            if (TypeOperation != null)
            {
                formulaire = TypeOperation.FormulaireCompteRendu;
                if (formulaire != null)
                    listForm.Add(formulaire);
                formulaire = TypeOperation.FormulaireOpPrevisionnelle;
                if (formulaire != null)
                    listForm.Add(formulaire);
                
            }
            return (CFormulaire[])listForm.ToArray(typeof(CFormulaire));
		}

		//----------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations de l'opération avec des champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationOperation_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationOperation_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationOperation_ChampCustom.c_nomTable, c_champId);
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

		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champId; }
		}

		public string ProprieteListeFils
		{
			get { return "OperationsFilles"; }
		}

		#endregion




        //---------------------------------------------------------------------------
        /// <summary>
        /// Le Type d'équipement lié lorsque l'Option "lié à un équipement" est cochée sur le Type d'Opération<br/>
        /// et lorsque l'Opération est dans une liste
        /// </summary>
        [Relation(
            CTypeEquipement.c_nomTable,
            CTypeEquipement.c_champId,
            CTypeEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Equipment Type")]
        public CTypeEquipement TypeEquipement
        {
            get
            {
                return (CTypeEquipement)GetParent(CTypeEquipement.c_champId, typeof(CTypeEquipement));
            }
            set
            {
                SetParent(CTypeEquipement.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// L'équipement lié lorsque l'Option "lié à un équipement" est cochée sur le Type d'Opération
        /// et lorsque l'Opération est liée à une Intervention
        /// </summary>
        [Relation(
            CEquipement.c_nomTable,
            CEquipement.c_champId,
            CEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Equipment")]
        public CEquipement Equipement
        {
            get
            {
                return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
            }
            set
            {
                SetParent(CEquipement.c_champId, value);
            }
        }

        //----------------------------------------------------------------------------------
        public CResultAErreur MonterIndex()
        {
            CResultAErreur result = CResultAErreur.True;

            ArrayList listeOp = this.ElementAOperationPrevisionnelle.Operations.ToArrayList();

            if (this.Index == 0 || (COperation)(listeOp[0]) == this)
                return CResultAErreur.False;

            int index = this.Index;
            this.Index = ((COperation)(listeOp[index - 1])).Index;
            ((COperation)(listeOp[index - 1])).Index = index;

            return result;
        }

        //-------------------------------------------------------------------------------
        public CResultAErreur DescendreIndex()
        {
            CResultAErreur result = CResultAErreur.True;

            ArrayList listeOp = this.ElementAOperationPrevisionnelle.Operations.ToArrayList();
            int count = listeOp.Count;
            if (this.Index == count - 1 || (COperation)(listeOp[count - 1]) == this)
                return CResultAErreur.False;

            int index = this.Index;
            this.Index = ((COperation)(listeOp[index + 1])).Index;
            ((COperation)(listeOp[index + 1])).Index = index;

            return result;

        }



        public void TiagSeActeurKeys(object[] lstCles)
        {
            CActeur acteur = new CActeur(ContexteDonnee);
            if (acteur.ReadIfExists(lstCles))
                Acteur = acteur;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// L'acteur lié à l'opération, peut être null
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CActeur.c_champId,
            false,
            false,
            false)]
        [DynamicField("Member")]
        [TiagRelation(typeof(CActeur), "TiagSeActeurKeys")]
        public CActeur Acteur
        {
            get
            {
                return (CActeur)GetParent(CActeur.c_champId, typeof(CActeur));
            }
            set
            {
                SetParent(CActeur.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Date de fin de l'opération
        /// </summary>
        [DynamicField("End date")]
        public DateTime? DateHeureFin
        {
            get
            {
                if (DateDebut != null && Duree != null)
                    return DateDebut.Value.AddHours(Duree.Value);
                return null;
            }
            set
            {
                if ( DateDebut != null && value != null)
                    Duree = ((TimeSpan)(value-DateDebut)).TotalHours;
            }
        }

        //-------------------------------------------------------------------
        public CResultAErreur VerifieCoherenceHierarchique()
        {
            CResultAErreur result = CResultAErreur.True;

            if (TypeOperation == null)
            {
                result.EmpileErreur(I.T("Operation @1 needs a type|20178",
                    (Index + 1).ToString()));
                return result;
            }
            if ( OperationParente != null )
            {
                if ( OperationParente.TypeOperation != null &&
                    TypeOperation.TypeOperationParente != OperationParente.TypeOperation)
                {
                    result.EmpileErreur("Error on operation @1. '@2' is not a valid subtype for '@3'|20180",
                        (Index + 1).ToString(),
                        TypeOperation != null?TypeOperation.Libelle:"?",
                        OperationParente.TypeOperation != null?OperationParente.TypeOperation.Libelle:"?");
                    return result;
                }
            }
            
            if (TypeOperation.Niveau != Niveau ||
                (OperationParente == null && Niveau != 0))
            {
                result.EmpileErreur(I.T("Operation @1 is on wrong level|20179",
                    (Index + 1).ToString()));
                return result;
            }
            return result;
        }


		#region IElementATypeStructurant<CTypeOperation> Membres

		public CTypeOperation ElementStructurant
		{
			get { return TypeOperation; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeOperation.c_champId];
			}
		}

		#endregion

        #region IElementAEvenementsDefinis Membres

        //--------------------------------------------------
        public IDefinisseurEvenements[] Definisseurs
        {
            get
            {
                if (TypeOperation != null)
                    return new IDefinisseurEvenements[] { TypeOperation };
                return new IDefinisseurEvenements[0];
            }
        }

        //--------------------------------------------------
        public bool IsDefiniPar(IDefinisseurEvenements definisseur)
        {
            return definisseur == TypeOperation;
        }

        #endregion

        #region ISatisfactionBesoin Membres

        public string LibelleSatisfactionComplet
        {
            get
            {
                if ( Intervention != null )
                    return I.T("Operation @1 from intervention @2|20177",
                        Libelle, 
                        Intervention.Libelle);
                if ( FractionIntervention != null )
                    return I.T("Operation @1 from Intervention @2|20177",
                        Libelle,
                        FractionIntervention.Libelle);
                return I.T("Operation @1 from @2|20177",Libelle, "?");
            }
        }

        public string Libelle
        {
            get { return TypeOperation != null ? TypeOperation.Libelle : "?"; }
        }

        /*public CBesoin[] BesoinsSolutionnes
        {
            get { return CRelationBesoin_Satisfaction.GetBesoinsSatisfaits(this).ToArray<CBesoin>(); }
        }

        public CListeObjetsDonnees RelationsSatisfaits
        {
            get { return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this); }
        }


        public bool CanSatisfaire(CBesoin besoin)
        {
            return besoin != null;
        }

        public CObjetDonneeAIdNumerique ObjetPourEditionSatisfaction
        {
            get
            {
                if (FractionIntervention != null)
                    return FractionIntervention.Intervention;
                if (Intervention != null)
                    return Intervention;
                return null;
            }
        }*/


        


        #endregion

        #region IElementACout Membres
        /// <summary>
        /// cout prévisionnel de l'opération, basé sur la valorisation
        /// de son type d'opération à la date prévisionnelle de l'intervention
        /// </summary>
        [TableFieldProperty(c_champCoutPrevisionnel)]
        [DynamicField("Estimated cost")]
        public double CoutPrevisionnel
        {
            get
            {
                return (double)Row[c_champCoutPrevisionnel];
            }
        }

        
        //------------------------------------------------------
        /// <summary>
        /// Cout réel de l'opération
        /// </summary>
        [TableFieldProperty(c_champCoutReel)]
        [DynamicField("Actual cost")]
        public double CoutReel
        {
            get
            {
                return (double)Row[c_champCoutReel];
            }
         }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsVersUtilisateurs, 1024)]
        public string ImputationsSurUtilisateursString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsVersUtilisateurs];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsVersUtilisateurs] = value;
            }
        }

        //---------------------------------------------
        [TableFieldProperty(CUtilElementACout.c_champImputationsParLesSources, 1024)]
        public string ImputationsDeSourcesString
        {
            get
            {
                return (string)Row[CUtilElementACout.c_champImputationsParLesSources];
            }
            set
            {
                Row[CUtilElementACout.c_champImputationsParLesSources] = value;
            }
        }

        
        //---------------------------------------------
        public double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel)
        {
            if (elementACout == null || elementACout.Row.RowState == DataRowState.Deleted)
                return 0;
            if (bCoutReel)
            {
                if (FractionIntervention != null)
                    return CoutReel;
            }
            else if (Intervention != null)
                return CoutPrevisionnel;
            return 0;
        }

        

        //---------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            return Duree == null && OperationsFilles.Count > 0;
        }

        //---------------------------------------------
        /// <summary>
        /// Indique les types de couts parents à recalculer
        /// </summary>
        [TableFieldProperty(CUtilElementACout.c_champCoutsParentsARecalculer, IsInDb = false)]
        public ETypeCout TypesCoutsParentsARecalculer
        {
            get
            {
                if (Row[CUtilElementACout.c_champCoutsParentsARecalculer] == DBNull.Value)
                    return ETypeCout.Aucun;
                return (ETypeCout)Row[CUtilElementACout.c_champCoutsParentsARecalculer];
            }
            set
            {
                Row[CUtilElementACout.c_champCoutsParentsARecalculer] = value;
            }
        }


        //------------------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            if (bCoutReel)
            {
                if (FractionIntervention != null)
                {
                    if (Duree != null)
                    {
                        if (FractionIntervention.Intervention != null)
                        {
                            return Duree.Value * FractionIntervention.Intervention.GetCoutHeureMainOeuvre();
                        }
                    }
                }
                return 0;
            }
            else
            {
                if (Intervention != null)
                {
                    if (Duree != null)
                    {
                        return Duree.Value * Intervention.GetCoutHeureMainOeuvre();
                    }
                    if (TypeOperation != null)
                        return TypeOperation.DureeStandardHeures * Intervention.GetCoutHeureMainOeuvre();
                }
            }
            return 0;
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }

         //---------------------------------------------
        public void SetCoutSansCalculDesParents(double fValeur, bool bCoutReel)
        {
            if (bCoutReel)
                Row[c_champCoutReel] = fValeur;
            else
                Row[c_champCoutPrevisionnel] = fValeur;
        }

        //---------------------------------------------
        public void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel)
        {
            SetCoutSansCalculDesParents(fValeur, bCoutReel);
            CUtilElementACout.OnChangeCout(this, bCoutReel, false); 
        }
        //------------------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            List<IElementACout> lst = new List<IElementACout>();
            if ( Duree == null )
                foreach (COperation operation in OperationsFilles)
                    lst.Add(operation);
            return lst.ToArray();
        }

        //------------------------------------------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);

            COperation operationParente = OperationParente;
            if (operationParente != null && (operationParente.Row.RowState == DataRowState.Deleted || operationParente.Row.RowState == DataRowState.Detached))
                operationParente.VersionToReturn = DataRowVersion.Original;
            
            if (operationParente != null)
                imputations.AddImputation(operationParente, imputations.PoidsTotal == 0 ? 1 : 0, null);
            
            if (FractionIntervention != null)
            {
                imputations.AddImputation(FractionIntervention, imputations.PoidsTotal == 0 ? 1 : 0, null);
            }
            else if (Intervention != null)
            {
                imputations.AddImputation(Intervention, imputations.PoidsTotal == 0 ? 1 : 0, null);
            }
            return imputations;
        }

        //---------------------------------------------
        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get
            {
                if (Intervention != null)
                    return Intervention;
                if (FractionIntervention != null && FractionIntervention.Intervention != null)
                    return FractionIntervention.Intervention;
                return null;
            }
        }

        #endregion
    }
}
