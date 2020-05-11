using System;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using timos.securite;

using timos.acteurs;
using tiag.client;
using timos.data.projet.besoin;
using System.Collections.Generic;

namespace timos.data
{
    /// <summary>
    /// Fraction d'une <see cref="CIntervention">intervention</see>
    /// </summary>
	[DynamicClass("Intervention part")]
	[Table(CFractionIntervention.c_nomTable, CFractionIntervention.c_champId, true)]
	[ObjetServeurURI("CFractionInterventionServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [TiagClass(CFractionIntervention.c_nomTiag, "Id", true)]
    public class CFractionIntervention :
                                        CObjetDonneeAIdNumeriqueAuto, 
                                        ITranchePlanning,
                                        IElementAOperationsRealisees,
                                        IElementACout
	{
        public const string c_nomTable = "INTER_PART";
        public const string c_nomTiag = "Intervention Part";

		public const string c_champId = "INTPRT_ID";
		public const string c_champDateDebutPlanifie = "INTPRT_PLANIF_START";
		public const string c_champDateFinPlanifiee = "INTPRT_PLANIF_END";
		public const string c_champDateDebut = "INTPRT_START";
		public const string c_champDateFin = "INTPRT_END";
		public const string c_champEtat = "INTPRT_STATE";
		public const string c_champDureeRetenue = "INTPRT_DURATION";
        public const string c_champCoutReel = "INTPRT_ACTUAL_COST";


	/// /////////////////////////////////////////////
		public CFractionIntervention(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CFractionIntervention(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		// Propriété de la classe 
		public override string DescriptionElement
		{
			get
			{
				return I.T( "@1 Intervention Part|454", Intervention.Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
			DateDebutPlanifie = DateTime.Now;
            DateFinPlanifiee = DateTime.Now.AddHours(2);
			Row[c_champEtat] = (int)EtatFractionIntervention.AFaire;
            Row[c_champCoutReel] = 0;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champDateDebut, c_champDateDebutPlanifie };
		}


		/// /////////////////////////////////////////////
		public string Libelle
		{
			get
			{
				if (Intervention != null)
					return Intervention.Libelle;
				return "";
			}
		}


        public void TiagSetInterventionKeys(object[] lstCles)
        {
            CIntervention inter = new CIntervention(ContexteDonnee);
            if (inter.ReadIfExists(lstCles))
                Intervention = inter;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Intervention concernée par cette fraction
		/// </summary>
		[Relation(
			CIntervention.c_nomTable,
			CIntervention.c_champId,
		    CIntervention.c_champId,
			true,
			true,
			true)]
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

		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la durée théorique de cette fraction d'intervention
		/// </summary>
		[TableFieldProperty(c_champDureeRetenue, NullAutorise = true)]
		[DynamicField("Inputed duration")]
        [TiagField("Inputed duration")]
		public double? DureeSaisie
		{
			get
			{
				return (double?)Row[c_champDureeRetenue, true];
			}
			set
			{
				Row[c_champDureeRetenue, true] = value;
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Donne la durée réelle de cette fraction d'intervention
        /// </summary>
        [DynamicField("Real duration")]
		public double? DureeReelle
		{
			get
			{
				if ( DateFin != null && DateDebut != null )
				{
					TimeSpan sp = (DateTime)this.DateFin - (DateTime)DateDebut;
					return sp.TotalHours;
				}
				return null;
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Donne la durée de cette fraction d'intervention; renvoie :
        /// <ul>
        /// <li>La durée théorique, si celle-ci n'est pas nulle</li>
        /// <li>la durée réelle dans le cas contraire</li>
        /// </ul>
        /// </summary>
		[DynamicField("Work duration")]
		public double? TempsDeTravail
		{
			get
			{
				if (DureeSaisie != null)
					return DureeSaisie;
				return DureeReelle;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la date de début planifiée de la fraction d'intervention
		/// </summary>
		[TableFieldProperty(c_champDateDebutPlanifie)]
		[DynamicField("Planified start date")]
        [TiagField("Planified start date")]
		public DateTime DateDebutPlanifie
		{
			get
			{
				return (DateTime)Row[c_champDateDebutPlanifie];
			}
			set
			{
				Row[c_champDateDebutPlanifie] = value;
			}
		}

		//-----------------------------------------------------------
		public string DebutPlanifieString
		{
			get
			{
				return DateDebutPlanifie.ToString("g");
			}
		}

		//-----------------------------------------------------------
		public string FinPlanifieeString
		{
			get
			{
				return DateFinPlanifiee.ToString("g");
			}
		}


		//-----------------------------------------------------------
		/// <summary>
        /// Donne ou définit la date de fin planifiée de la fraction d'intervention
		/// </summary>
		[TableFieldProperty(c_champDateFinPlanifiee)]
		[DynamicField("Planified end date")]
        [TiagField("Planified end date")]
		public DateTime DateFinPlanifiee
		{
			get
			{
				return (DateTime)Row[c_champDateFinPlanifiee];
			}
			set
			{
					Row[c_champDateFinPlanifiee] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champDateDebut, NullAutorise = true)]
		[DynamicField("Start date")]
        [TiagField("Start date")]
		public DateTime? DateDebut
		{
			get
			{
				if (Row[c_champDateDebut] == DBNull.Value)
					return null;
				return (DateTime?)Row[c_champDateDebut];
			}
			set
			{
				if (value == null)
					Row[c_champDateDebut] = DBNull.Value;
				else
				{
					Row[c_champDateDebut] = new DateTime(
						value.Value.Year,
						value.Value.Month,
						value.Value.Day,
						value.Value.Hour,
						value.Value.Minute,
						0);
				}
			}
		}



		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champDateFin, NullAutorise=true)]
		[DynamicField("End date")]
        [TiagField("End date")]
		public DateTime? DateFin
		{
			get
			{
				if (Row[c_champDateFin] == DBNull.Value)
					return null;
				return (DateTime?)Row[c_champDateFin];
			}
			set
			{
				if (value == null)
					Row[c_champDateFin] = DBNull.Value;
				else
					Row[c_champDateFin] = new DateTime(
						value.Value.Year,
						value.Value.Month,
						value.Value.Day,
						value.Value.Hour,
						value.Value.Minute,
						0);
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit le code de l'état de la fraction d'intervention
		/// </summary>
		[TableFieldProperty(c_champEtat)]
		[DynamicField("State code")]
        [TiagField("State code")]
		public int EtatInt
		{
			get
			{
				return (int)Row[c_champEtat];
			}
			set
			{
				Row[c_champEtat] = value;
			}
		}

		//-----------------------------------------------------------
        /// <summary>
        /// Donne l'état de la fraction d'intervention
        /// </summary>
		[DynamicField("State")]
		public CEtatFractionIntervention Etat
		{
			get
			{
				return new CEtatFractionIntervention((EtatFractionIntervention)EtatInt);
			}
		}


		#region ITranchePlanning Membres

		//------------------------------------------
		DateTime IEntreeAgenda.DateDebut
		{
			get
			{
				if (DateDebut != null)
					return (DateTime)DateDebut;
				return DateDebutPlanifie;
			}
			set
			{
				DateDebutPlanifie = value;
			}
		}

		//------------------------------------------
		DateTime IEntreeAgenda.DateFin
		{
			get
			{
				if (DateFin != null)
					return (DateTime)DateFin;
				return DateFinPlanifiee; 
			}
			set
			{
				DateFinPlanifiee = value;
			}
		}

		//------------------------------------------
		public IEntreePlanning EntreePlanning
		{
			get { return Intervention; }
		}

		#endregion


		//------------------------------------------------------------------------
		/// <summary>
		/// Donne la liste des opérations réalisées pour cette fraction d'intervention
		/// </summary>
		[RelationFille(typeof(COperation), "FractionIntervention")]
		[DynamicChilds("Performed Operations", typeof(COperation))]
		public CListeObjetsDonnees Operations
		{
			get
			{
				return GetDependancesListe(COperation.c_nomTable, c_champId);
			}
		}


		//---------------------------------------------
		/// <summary>
		/// Donne la liste des relations 'Intervention / Activité d'acteur' correspondant à la fraction
		/// </summary>
		[RelationFille(typeof(CIntervention_ActiviteActeur), "FractionIntervention")]
		[DynamicChilds("Activity relations", typeof(CIntervention_ActiviteActeur))]
		public CListeObjetsDonnees RelationsActivite
		{
			get
			{
				return GetDependancesListe(CIntervention_ActiviteActeur.c_nomTable, c_champId);
			}
		}

		//---------------------------------------------
		public void UpdateEtat()
		{
			switch (this.Etat.Code)
			{
				case EtatFractionIntervention.AFaire:
					if (Operations.Count > 0)
						EtatInt = (int)EtatFractionIntervention.EnCours;
					break;
			}
		}

        //---------------------------------------------
        public void InitFromPrevisionnel()
        {
            CListeObjetsDonnees lstOps = Intervention.Operations;
            lstOps.Filtre = new CFiltreData(COperation.c_champIdOpParente + " is null");
            foreach (COperation op in lstOps.ToArrayList())
            {
                CResultAErreur result = op.CreateRealisee(this, null);
            }
        }



		#region IEntreeAgenda Membres


		public bool SansHoraire
		{
			get { return false; }
		}

		CEtatEntreeAgenda IEntreeAgenda.Etat
		{
			get {
				switch (Etat.Code)
				{
					case EtatFractionIntervention.AFaire:
						return new CEtatEntreeAgenda(EtatEntreeAgenda.AFaire);
					case EtatFractionIntervention.Annulee:
						return new CEtatEntreeAgenda(EtatEntreeAgenda.Annulee);
					case EtatFractionIntervention.EnCours:
						return new CEtatEntreeAgenda(EtatEntreeAgenda.EnCours);
					case EtatFractionIntervention.Terminee:
						return new CEtatEntreeAgenda(EtatEntreeAgenda.Terminee);
					default :
						return new CEtatEntreeAgenda(EtatEntreeAgenda.Info);
				}
			}
		}

		public string Commentaires
		{
			get { return ""; }
		}

		public string IdAppliExterne
		{
			get { return ""; }
		}

		public string IdExterne
		{
			get { return ""; }
		}

		#endregion

        #region IElementACout Membres

        public double CoutPrevisionnel
        {
            get { return 0; }//Une fraction ne génère pas de cout prévisionnel, uniquement du réel
        }

        //------------------------------------------------
        [TableFieldProperty(c_champCoutReel)]
        [DynamicField("Actual cost")]
        public double CoutReel
        {
            get
            {
                return (double)Row[c_champCoutReel];
            }
        }

        //------------------------------------------------
        public void SetCoutSansCalculDesParents(double fValeur, bool bCoutReel)
        {
            if (bCoutReel)
                Row[c_champCoutReel] = fValeur;
        }

        //------------------------------------------------
        public void SetCoutAvecCalculDesParents(double fValeur, bool bCoutReel)
        {
            SetCoutSansCalculDesParents(fValeur, bCoutReel);
            if (bCoutReel)
                CUtilElementACout.OnChangeCout(this, true, false);
        }

        //------------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            if ( bCoutReel )
                return DureeSaisie == null;
            return false;
        }

        //------------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            if (bCoutReel)
            {
                if (DureeSaisie != null)
                {
                    if (Intervention != null)
                        return Intervention.GetCoutHeureMainOeuvre() * DureeSaisie.Value;
                }
                CListeObjetsDonnees operations = Operations;
                operations.Filtre = new CFiltreData(COperation.c_champIdOpParente + " is null");
                double fCout = 0;
                foreach (COperation operation in operations)
                    fCout += operation.CoutReel;
                return fCout;
            }
            else
                return 0;
        }

        //-----------------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }

        //-----------------------------------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            List<IElementACout> lst = new List<IElementACout>();
            CListeObjetsDonnees operations = Operations;
            operations.Filtre = new CFiltreData(COperation.c_champIdOpParente + " is null");
            foreach (COperation op in operations)
                lst.Add(op);
            return lst.ToArray();
        }

        //-----------------------------------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);
            if (Intervention != null)
                imputations.AddImputation(Intervention, 1, null);
            return imputations;
        }

        //-----------------------------------------------------------------------
        public double CalcImputationAFaireSur(IElementACout elementACout, bool bCoutReel)
        {
            if (elementACout is CIntervention && elementACout.Id == Intervention.Id && bCoutReel)
                return CoutReel;
            return 0;
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

        //---------------------------------------------
        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get
            {
                if (Intervention != null)
                    return Intervention;
                return null;
            }
        }


        #endregion
    }
}
