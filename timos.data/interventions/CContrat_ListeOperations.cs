using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using timos.data.preventives;

namespace timos.data
{
 
	/// <summary>
    /// Relation entre un <see cref="CContrat">contrat</see> et une <see cref="CListeOperations">liste d'opérations</see>
	/// </summary>
    [DynamicClass("Contract / Operations List")]
	[Table(CContrat_ListeOperations.c_nomTable, CContrat_ListeOperations.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CContrat_ListeOperationsServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CContrat_ListeOperations : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete,
								IElementADecoupagePourEditeurPreventive
                                
	{
		public const string c_nomTable = "CONTRACT_OPLIST";
        public const string c_champId = "CONT_OPLIST_ID";
        public const string c_champRecurrence = "CONT_OPLIST_REC";



		//public const string c_champEndDate = "CONT_OPLIST_ENDDATE";

		//Periodicite Annoncée
		public const string c_champStartDate = "CONT_OPLIST_STARTDATE";
		public const string c_champDateLimite = "CONT_OPLIST_LDATE";

		public const string c_champPeriodeCode = "CONT_OPLIST_PERIOD";
		public const string c_champNbPeriodes = "CONT_OPLIST_NBPERIOD";
		public const string c_champNbParPeriode = "CONT_OPLIST_NBFORPERIOD";

		//Periodicite pour designer
		public const string c_champEditeurStartDate = "CONT_OPLIST_D_STARTDATE";
		public const string c_champEditeurDateLimite = "CONT_OPLIST_D_LDATE";

		public const string c_champEditeurPeriodeCode = "CONT_OPLIST_D_PERIOD";
		public const string c_champEditeurNbPeriodes = "CONT_OPLIST_D_NBPERIOD";

		public const string c_champCouleur = "CONT_OPLIST_COLOR";



		/// /////////////////////////////////////////////
		public CContrat_ListeOperations( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CContrat_ListeOperations(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Contract / Operation List Relation|427");
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            DateDebut = DateTime.Now.Date;

		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champId };
		}



        //-------------------------------------------------------------------
        /// <summary>
        /// Le Contrat objet de la relation (relation de composition obligatoire)
        /// </summary>
        [Relation(
            CContrat.c_nomTable,
            CContrat.c_champId,
            CContrat.c_champId,
            true,
            true,
            false)]
        [DynamicField("Contrat")]
        public CContrat Contrat
        {
            get
            {
                return (CContrat)GetParent(CContrat.c_champId, typeof(CContrat));
            }
            set
            {
                SetParent(CContrat.c_champId, value);
            }
        }


		//-------------------------------------------------------------------
		/// <summary>
		/// Le type d'intervention correspondant
		/// </summary>
		[Relation(
			CTypeIntervention.c_nomTable,
		   CTypeIntervention.c_champId,
		   CTypeIntervention.c_champId,
			true,
			false,
			false)]
		[DynamicField("Type Intervention")]
		public CTypeIntervention TypeIntervention
		{
			get
			{
				return (CTypeIntervention)GetParent(CTypeIntervention.c_champId, typeof(CTypeIntervention));
			}
			set
			{
				SetParent(CTypeIntervention.c_champId, value);
			}
		}


            
        //-------------------------------------------------------------------
        /// <summary>
        /// La Liste d'Opérations objet de la relation (relation obligatoire)
        /// </summary>
        [Relation(
            CListeOperations.c_nomTable,
            CListeOperations.c_champId,
            CListeOperations.c_champId,
            true,
            false,
            false)]
        [DynamicField("Operations List")]
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


		#region Periodicite prévue

		//-----------------------------------------------------------
        /// <summary>
        /// Date Limite de réalisation des opérations de la liste pour le Contrat donné
        /// </summary>
        [TableFieldProperty(c_champDateLimite,NullAutorise=true)]
        [DynamicField("End Date")]
        public DateTime? DateLimite
        {
            get
            {
                return (DateTime ?)Row[c_champDateLimite, true];
            }
            set
            {
                Row[c_champDateLimite, true] = value;
            }
		}

        //----------------------------------------------------------
        /// <summary>
        /// Date de début de réalisation des opérations de la liste pour le contrat donné
        /// </summary>
		[TableFieldProperty(c_champStartDate)]
		[DynamicField("Start Date")]
		public DateTime DateDebut
		{
			get
			{
				return (DateTime)Row[c_champStartDate];
			}
			set
			{
				Row[c_champStartDate] = value;
			}
		}


        /// <summary>
        /// Code correspondant à l'échelle de temps choisie pour la périodicité de la planification de cette liste d'opérations :
        /// <ul>
        /// <li>0  : Heure</li>
        /// <li>10 : Jour</li>
        /// <li>20 : Mois</li>
        /// <li>30 : Semaine</li>
        /// <li>40 : Année</li>
        /// </ul>
        /// </summary>
		[DynamicField("Periodic Code")]
		[TableFieldProperty(c_champPeriodeCode)]
		public int PeriodiciteOperationCode
		{
			get
			{
				return (int)Row[c_champPeriodeCode];
			}
			set
			{
				Row[c_champPeriodeCode] = value;
			}
		}

        /// <summary>
        /// Unité de temps choisie pour la périodicité de la planification de cette liste d'opérations :
        /// <ul>
        /// <li>Heure</li>
        /// <li>Jour</li>
        /// <li>Mois</li>
        /// <li>Semaine</li>
        /// <li>Année</li>
        /// </ul>
        /// </summary>
		public CEchelleTemps PeriodiciteOperation
		{
			get
			{
				return new CEchelleTemps((EEchelleTemps)PeriodiciteOperationCode);
			}
			set
			{
				if (value != null)
					PeriodiciteOperationCode = value.CodeInt;
			}
		}

        /// <summary>
        /// Nombre de fois où la liste d'opérations doit être réalisée par période de temps
        /// </summary>
		[DynamicField("Number by period")]
		[TableFieldProperty(c_champNbParPeriode)]
		public int NombreParPeriode
		{
			get
			{
				return (int)Row[c_champNbParPeriode];
			}
			set
			{
				Row[c_champNbParPeriode] = value;
			}
		}

        /// <summary>
        /// Nombre d'unités de temps choisie pour la planification de la liste d'opérations<br/>
        /// Exemple : tous les 3 mois (mois étant l'unité de temps)
        /// </summary>
		[DynamicField("Number of period")]
		[TableFieldProperty(c_champNbPeriodes)]
		public int NombrePeriodes
		{
			get
			{
				return (int)Row[c_champNbPeriodes];
			}
			set
			{
				Row[c_champNbPeriodes] = value;
			}
		}

		#endregion

		#region Editeur Preventive
		public CDecoupage DecoupageEditeur
		{
			get
			{
				int periodiciteCode = PeriodiciteOperationCodePourEditeur != null?PeriodiciteOperationCodePourEditeur.Value:(int)EEchelleTemps.Mois;
				int nbPeriode = NombreParPeriodePourEditeur != null?NombreParPeriodePourEditeur.Value:3;
				DateTime dtStart = DateDebutEditeur != null?DateDebutEditeur.Value:DateTime.Now.Date;
				DateTime dtEnd = DateLimiteEditeur!= null?DateLimiteEditeur.Value: dtStart.AddYears(1);
				return new CDecoupage(dtStart,dtEnd,nbPeriode,(EEchelleTemps)periodiciteCode,true, EEchelleTemps.Jour);
			}
			set
			{
				PeriodiciteOperationCodePourEditeur = (int)value.Periodicite;
				DateDebutEditeur = value.DateDebut;
				DateLimiteEditeur = value.DateFin;
				NombreParPeriodePourEditeur = value.NombrePeriode;
			}
		}



		//-----------------------------------------------------------
		/// <summary>
		/// Date Limite de réalisation des opérations de la liste pour le Contrat donné
		/// </summary>
		[TableFieldProperty(c_champEditeurDateLimite, NullAutorise = true)]
		public DateTime? DateLimiteEditeur
		{
			get
			{
				DateTime? valInDB =(DateTime?)Row[c_champEditeurDateLimite, true];
				if(valInDB != null)
					return valInDB;
				else if(DateLimite != null)
					DateDebutEditeur = DateDebut;
				return DateLimite;
			}
			set
			{
				Row[c_champEditeurDateLimite, true] = value;
			}
		}

		[TableFieldProperty(c_champEditeurStartDate, NullAutorise = true)]
		public DateTime? DateDebutEditeur
		{
			get
			{
				DateTime? valInDB = (DateTime?)Row[c_champEditeurStartDate, true];
				if (valInDB != null)
					return valInDB;
				else if (DateDebut != null)
					DateDebutEditeur = DateDebut;
				return DateDebut;
			}
			set
			{
				Row[c_champEditeurStartDate, true] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Code couleur correspondant au type d'occupation,<br/>
        /// dans l'écran de planification
		/// </summary>
		[TableFieldProperty(c_champCouleur)]
		[DynamicField("Color")]
		public int Couleur
		{
			get
			{
				return (int)Row[c_champCouleur];
			}
			set
			{
				Row[c_champCouleur] = value;
			}
		}


		[TableFieldProperty(c_champEditeurPeriodeCode, NullAutorise = true)]
		public int? PeriodiciteOperationCodePourEditeur
		{
			get
			{
				return (int?)Row[c_champEditeurPeriodeCode, true];
			}
			set
			{
				Row[c_champEditeurPeriodeCode, true] = value;
			}
		}
		public CEchelleTemps PeriodiciteOperationPourEditeur
		{
			get
			{
				if(PeriodiciteOperationCodePourEditeur != null)
					return new CEchelleTemps((EEchelleTemps)PeriodiciteOperationCodePourEditeur);
				return null;
			}
			set
			{
				if (value != null)
					PeriodiciteOperationCodePourEditeur = value.CodeInt;
			}
		}

		[TableFieldProperty(c_champEditeurNbPeriodes, NullAutorise=true)]
		public int? NombreParPeriodePourEditeur
		{
			get
			{
				return (int?)Row[c_champEditeurNbPeriodes, true];
			}
			set
			{
				Row[c_champEditeurNbPeriodes, true] = value;
			}
		}

		#endregion



        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des sites pour le contrat et la liste d'opérations donnée.<br/>
        /// Concerne les contrats de catégorie maintenance préventive.
        /// </summary>
        [RelationFille(typeof(CContratListeOp_Site), "ContratListeOp")]
        [DynamicChilds("Sites Relations", typeof(CContratListeOp_Site))]
        public CListeObjetsDonnees RelationsSites
        {
            get
            {
                return GetDependancesListe(CContratListeOp_Site.c_nomTable, c_champId);
            }
        }


        //----------------------------------------------------------------
        /// <summary>
        /// Retourne le tableau des Sites pour un Contrat donné et une liste d'opérations donnée
        /// qu'ils soient définis par Profil ou par une liste de relations "manuelle"
        /// </summary>
        /// <returns></returns>
        public CSite[] GetTousLesSitesAssocies()
        {
			return GetTousLesSitesAssocies(false);
        }

        //----------------------------------------------------------------
		private CSite[] GetTousLesSitesAssocies(bool bSetCache)
		{
			if (bSetCache)
				m_cacheIdsSitesAssocies = new List<string>();
			ArrayList listeSites = new ArrayList();

            RelationsSites.ReadDependances("Site");

			// Ajout des Sites par relation
			foreach (CContratListeOp_Site rel in RelationsSites)
			{
				listeSites.Add(rel.Site);
				if (bSetCache)
					m_cacheIdsSitesAssocies.Add(rel.Site.Id.ToString());
			}

            //Si aucun site ajouté, prend tous les sites du contrat
            if (listeSites.Count == 0)
            {
                foreach (CSite site in Contrat.GetTousLesSitesDuContrat())
                    listeSites.Add(site);
            }
		
			return (CSite[])listeSites.ToArray(typeof(CSite));
		}

        //----------------------------------------------------------------
		private List<string> m_cacheIdsSitesAssocies;
		public bool AssocieAuSite(CSite site)
		{
			if (m_cacheIdsSitesAssocies == null)
				GetTousLesSitesAssocies(true);

			return m_cacheIdsSitesAssocies.Contains(site.Id.ToString());
		}
    }
}
