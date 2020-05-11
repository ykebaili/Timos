using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

using timos.securite;
using timos.acteurs;
using timos.data.version;
using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using timos.data.projet.besoin;
using timos.data.equipement.consommables;
using sc2i.common.unites;
using sc2i.common.unites.standard;
using sc2i.expression;
using sc2i.process.workflow.gels;

namespace timos.data
{

    #region RelationElementToIntervention
	/*[AttributeUsage(AttributeTargets.Class)]
	[Serializable]
	public class RelationElementToInterventionAttribute : RelationTypeIdAttribute
	{
		public override string TableFille
		{
			get
			{
				return CIntervention.c_nomTable;
			}
		}

		//////////////////////////////////////
		public override int Priorite
		{
			get
			{
				return 1300;
			}
		}

		protected override string MyIdRelation
		{
			get
			{
				return "Intervention";
			}
		}


		public override string ChampId
		{
			get
			{
				return CIntervention.c_champIdElementLie;
			}
		}

		public override string ChampType
		{
			get
			{
				return CIntervention.c_champTypeElementLie;
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
				return "Interventions";
			}
		}

		protected override bool MyIsAppliqueToType(Type tp)
		{
			return tp.IsSubclassOf(typeof(CObjetDonneeAIdNumeriqueAuto));
		}
	}*/
	#endregion


    /// <summary>
    /// Une intervention est un ensemble d'opérations réalisées sur un site par un ou plusieurs intervenants.<br/>
    /// Cela peut être, par exemple, une opération de maintenance préventive ou corrective<br/>
    /// ou le contrôle du fonctionnement des équipements sur un site.<br/>
    /// Les intervenants peuvent être par exemple des techniciens de maintenance.<br/>
    /// L'intervention modélise donc le déplacement de l'intervenant sur un site.
    /// </summary>
    /// <remarks>
    /// Toute intervention est associée à un site et à un seul. Si l'on doit intervenir sur plusieurs sites,<br/>
    /// il faudra créer une intervention différente pour chaque site.<br/><br/>
    /// Une intervention est un objet typé.<br/><br/>
    /// Une intervention est constituée d'une ou plusieurs opérations qui sont les actions élémentaires<br/>
    /// à réaliser par les intervenants sur le site. Cela peut être, par exemple, le remplacement d'un équipement,<br/>
    /// le changement d'une carte, la vérification du fonctionnement d'un équipement, etc.<br/><br/>
    /// Les opérations sont définies de manière hiérarchique, c'est à dire qu'il est possible de décomposer<br/>
    /// une opération en plusieurs sous-opérations. Par exemple, le changement d'une carte pourra être décomposé<br/>
    /// entre le démontage de l'ancienne carte et la pose de la nouvelle carte.<br/><br/>
    /// Toute intervention peut être planifiée, c'est à dire qu'on lui spécifie une date de début et une date<br/>
    /// de fin prévues. Il y a deux étapes dans la planification d'une intervention :
    /// <ul>
    /// <li>la pré-planification : la date approximative de l'intervention est spécifiée dans une fourchette assez large</li>
    /// <li>la planification : la date de l'intervention est connue, on lui attribue une date précise de début et de fin prévue.</li>
    /// </ul>
    /// <br/><br/>
    /// Une intervention peut être planifiée plusieurs fois, c'est à dire que l'on peut effectuer la même intervention<br/>
    /// à plusieurs dates différentes. C'est par exemple le cas pour une intervention nécessitant une réalisation<br/>
    /// en deux étapes à deux moments différents.
    /// </remarks>
	[DynamicClass("Intervention")]
	[Table(CIntervention.c_nomTable, CIntervention.c_champId, true)]
	[ObjetServeurURI("CInterventionServeur")]
	[AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_Intervention_ID)]
	[RelationElementToDossier]
	[sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iIntervention)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CIntervention.c_nomTiag, "Id", true)]
    [TypeId("INTERVENTION")]
    public class CIntervention : 
                        CObjetDonneeAIdNumeriqueAuto,
						IObjetDonneeAChamps,      // Permet d'ajouter des champs custom (et formulaires a l'Intervention)
						IEntreePlanning,
						IElementAContacts,
						IElementGelable,
						IElementAEvenementsDefinis,
						IElementAOperationPrevisionnelle,
						IElementDeProjetPlanifiable,
						IElementATypeStructurant<CTypeIntervention>,
                        ISatisfactionBesoin
	{

		#region [ Constantes ]
		public const string c_roleChampCustom = "INTERVENTION";

        public const string c_nomTable = "INTERVENTION";
        public const string c_nomTiag = "Intervention";

		public const string c_champId = "INTER_ID";
		public const string c_champDateDebutPreplanifiee = "INTER_PREPLAN_START";
		public const string c_champDateFinPrePlanifiee = "INTER_PREPLAN_END";
		public const string c_champLibelle = "INTER_LABEL";
		public const string c_champDescription = "INTER_DESC";
		public const string c_champEtat = "INTER_STATE";
		public const string c_champDureePrevisionnelle = "INTER_PREV_DURATION";
        public const string c_champNbOperateursPrevus = "INTER_PREV_NB_OP";
		//public const string c_champTypeElementLie = "INTER_ELEMENT_TYPE";
		public const string c_champIdElementLie = "INTER_ELEMENT_ID";

		public const string c_champIdUserPreplanification = "INTER_PREPLANIF_USER";
		public const string c_champIdUserPlanification = "INTER_PLANIF_USER";
		public const string c_champIdUserSuivi = "INTER_MANAGER_USER";

        public const string c_champCoutPrevisionnel = "INTER_ESTIMATED_COST";
        public const string c_champCoutReel = "INTER_ACTUAL_COST";

		public const string c_champEstGelee = "INTER_FREEZE";

		public const string c_champDateClotureTechnique = "INTER_TECHNICAL_CLOS_DT";
		public const string c_champDateClotureAdministrative = "INTER_ADMIN_CLOSE_DT";

		public const string c_champPrjX = "INTER_PRJ_X";
		public const string c_champPrjY = "INTER_PRJ_Y";
		public const string c_champPrjWidth = "INTER_PRJ_WIDTH";
		public const string c_champPrjHeight = "INTER_PRJ_HEIGHT";



		#endregion

		/// /////////////////////////////////////////////
		public CIntervention(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CIntervention(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Intervention", typeof(CIntervention), typeof(CTypeIntervention));
		}

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }

		////////////////////////////////////////////////
		/// <summary>
		/// Propriété
		/// </summary>
		public override string DescriptionElement
		{
			get
			{
				return I.T("Intervention @1|138", Libelle);
			}
		}

		/// //////////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			Row[c_champEstGelee] = false;
            EtatInt = 0;
            TypesCoutsParentsARecalculer = ETypeCout.Aucun;
            Row[c_champCoutReel] = 0;
            Row[c_champCoutPrevisionnel] = 0;
            DureePrevisionnelle = 1;
		}

		/// //////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            //return new string[] { c_champId + " desc" };
            // YK 06/08/09 : Tri croissant au lieu de décroissant pour affichage correcte dans les formulaires de Ticket
            return new string[] { c_champDateDebutPreplanifiee, c_champId };
		}


		//////////////////////////////////////////////////////
		/// <summary>
		/// Donne ou définit le Libellé de l'Intervention. Champ texte de 255 caractères maximum.
		/// </summary>
		[TableFieldProperty(CIntervention.c_champLibelle, 255)]
		[DynamicField("Label")]
        [DescriptionField]
        [TiagField("Label")]
        public string Libelle
		{
			get
			{
				string strLibelle = (string)Row[c_champLibelle];
				if (TypeIntervention != null && strLibelle == "")
					return TypeIntervention.Libelle;
				return strLibelle;
			}
			set
			{
				if (TypeIntervention != null && value == TypeIntervention.Libelle)
					Row[c_champLibelle] = "";
				else
					Row[c_champLibelle] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la description de l'intervention<br/>
        /// (champ texte de 500 caractères maximum)
		/// </summary>
		[TableFieldProperty(c_champDescription, 500)]
		[DynamicField("Description")]
        [TiagField("Description")]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Date de clôture Technique.
        /// La clôture technique signifie que l'intervention est terminée techniquement parlant.
		/// </summary>
		[TableFieldProperty(c_champDateClotureTechnique, NullAutorise = true)]
		[DynamicField("Technical closing date")]
        [TiagField("Technical closing date")]
		public DateTime? DateClotureTechnique
		{
			get
			{
				return (DateTime?)Row[c_champDateClotureTechnique, true];
			}
			set
			{
				Row[c_champDateClotureTechnique, true] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Date de clôture Administrative.<br/>
        /// La clôture administrative est en générale décidée par<br/>
        /// un responsable (après vérifications), une fois que la clôture technique est effective.
		/// </summary>
		[TableFieldProperty(CIntervention.c_champDateClotureAdministrative, NullAutorise = true)]
		[DynamicField("Administrative closing date")]
        [TiagField("Administrative closing date")]
		public DateTime? DateClotureAdministrative
		{
			get
			{
				return (DateTime?)Row[c_champDateClotureAdministrative, true];
			}
			set
			{
				Row[c_champDateClotureAdministrative, true] = value;
			}
		}


        public void TiagSetTypeInterventionKeys(object[] lstCles)
        {
            CTypeIntervention tpInter = new CTypeIntervention(ContexteDonnee);
            if (tpInter.ReadIfExists(lstCles))
                TypeIntervention = tpInter;
        }
        //----------------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Type d'Intervention. Champ obligatoire.
		/// </summary>
		[Relation(
			CTypeIntervention.c_nomTable,
			CTypeIntervention.c_champId,
			CTypeIntervention.c_champId,
			true,
			false,
			true)]
		[DynamicField("Intervention type")]
        [TiagRelation(typeof(CTypeIntervention), "TiagSetTypeInterventionKeys")]
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


		//---------------------------------------------
		public Color GetCouleurIntervention
		{
			get
			{
				return CSerieDeCouleurs.GetCouleur(Id);
			}
		}

        public void TiagSetUserPreplanerKeys(object[] lstCles)
        {
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(ContexteDonnee);
            if (user.ReadIfExists(lstCles))
                UserPreplanifieur = user;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Utilisateur de l'Application responsable de la pré-planification
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
			CIntervention.c_champIdUserPreplanification,
			false,
			false,
			true)]
		[DynamicField("PrePlanner")]
        [TiagRelation(typeof(CDonneesActeurUtilisateur), "TiagSetUserPreplanerKeys")]
		public CDonneesActeurUtilisateur UserPreplanifieur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(CIntervention.c_champIdUserPreplanification, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent(CIntervention.c_champIdUserPreplanification, value);
			}
		}

        public void TiagSetUserSuiviKeys(object[] lstCles)
        {
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(ContexteDonnee);
            if (user.ReadIfExists(lstCles))
                UserSuivi = user;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Utilisateur de l'Application responsable du suivi de l'Intervention
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
			CIntervention.c_champIdUserSuivi,
			false,
			false,
			true)]
		[DynamicField("Manager")]
        [TiagRelation(typeof(CDonneesActeurUtilisateur), "TiagSetUserSuiviKeys")]
        public CDonneesActeurUtilisateur UserSuivi
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(CIntervention.c_champIdUserSuivi, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent(CIntervention.c_champIdUserSuivi, value);
			}
		}

        public void TiagSetUserPlanerKeys(object[] lstCles)
        {
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(ContexteDonnee);
            if (user.ReadIfExists(lstCles))
                UserPlanifieur = user;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Utilisateur de l'Application responsable de la planification
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
			CIntervention.c_champIdUserPlanification,
			false,
			false,
			true)]
		[DynamicField("Planner")]
        [TiagRelation(typeof(CDonneesActeurUtilisateur), "TiagSetUserPlanerKeys")]
        public CDonneesActeurUtilisateur UserPlanifieur
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(CIntervention.c_champIdUserPlanification, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
				SetParent(CIntervention.c_champIdUserPlanification, value);
			}
		}



		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Code de l'Etat de l'intervention<br/>
		/// Les codes d'Etat sont les suivants:
        /// <ul>
		/// <li> 0 : Non planifiée,</li>
        /// <li>10 : Pré-planifiée,</li>
        /// <li>20 : Planifiée,</li>
        /// <li>30 : En Cours,</li>
        /// <li>50 : Terminee,</li>
        /// <li>60 : Annulee</li>
        /// </ul>
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

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Etat de l'Intervention<br/>
		/// Les Etats posssibles sont:
		/// <list type="bullets">
		/// <item><term>0  : Non planifiée</term></item>
		/// <item><term>10 : Préplanifiée</term></item>
		/// <item><term>20 : Planifiée</term></item>
		/// <item><term>30 : En cours</term></item>
		/// <item><term>50 : Terminée</term></item>
		/// <item><term>60 : Annulée</term></item>
		/// </list>
        /// </summary>
		[DynamicField("State")]
		public CEtatIntervention Etat
		{
			get
			{
				return new CEtatIntervention((EtatIntervention)EtatInt);
			}
			set
			{
				if (value != null)
					EtatInt = value.EtatInt;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Durée prévisionnelle en nombre décimal. ex: pour 1H30min saisir 1,5.
		/// </summary>
		[TableFieldProperty(c_champDureePrevisionnelle)]
		[DynamicField("Estimated duration")]
        [TiagField("Estimated duration")]
		public double DureePrevisionnelle
		{
			get
			{
				double fValeur = (double)Row[c_champDureePrevisionnelle];
				if (fValeur == 0 && TypeIntervention != null)
					return TypeIntervention.DureeStandardHeures;
				return fValeur;
			}
			set
			{
                double fOld = 0;
                if ( Row[c_champDureePrevisionnelle] != DBNull.Value )
                    fOld = DureePrevisionnelle;
				Row[c_champDureePrevisionnelle] = value;
                if (fOld != value && Operations.Count == 0 )
                {
                    InvalideLeCoutDesSourcesDeCout(true, false);
                }
			}
		}

        //-----------------------------------------------------------
        /// <summary>
        /// Nombre d'opérateurs prévus pour cette intervention
        /// </summary>
        [TableFieldProperty(c_champNbOperateursPrevus)]
        [DynamicField("Forecast operators count")]
        [TiagField("Forecast operators count")]
        public int NbOperateurSPrevus
        {
            get
            {
                return (int)Row[c_champNbOperateursPrevus];
            }
            set
            {
                int nOld = 0;
                if ( Row[c_champNbOperateursPrevus] != DBNull.Value )
                    nOld = NbOperateurSPrevus;
                Row[c_champNbOperateursPrevus] = value;
                if (nOld != value && RelationsIntervenants.Count == 0)
                    InvalideLeCoutDesSourcesDeCout(true, true);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Indique le taux horaire prévu pour les agents
        /// </summary>
        [Relation(
            CTypeConsommable.c_nomTable,
            CTypeConsommable.c_champId,
            CTypeConsommable.c_champId,
            false,
            false,
            false)]
        [DynamicField("Hourly rate")]
        public CTypeConsommable TauxHorairePrevu
        {
            get
            {
                return (CTypeConsommable)GetParent(CTypeConsommable.c_champId, typeof(CTypeConsommable));
            }
            set
            {
                CTypeConsommable tp = TauxHorairePrevu;
                SetParent(CTypeConsommable.c_champId, value);
                if (tp != value)
                    InvalideLeCoutDesSourcesDeCout(true, true);
            }
        }

	




		//---------------------------------------------
		/// <summary>
		/// Donne la liste des Fractions d'Intervention correspondantes
		/// </summary>
		[RelationFille(typeof(CFractionIntervention), "Intervention")]
		[DynamicChilds("Parts", typeof(CFractionIntervention))]
		public CListeObjetsDonnees Fractions
		{
			get
			{
				return GetDependancesListe(CFractionIntervention.c_nomTable, c_champId);
			}
		}


		#region Projet


        public void TiagSetProjectKeys(object[] lstCles)
        {
            CProjet projet = new CProjet(ContexteDonnee);
            if (projet.ReadIfExists(lstCles))
                Projet = projet;
        }

		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le projet associé à l'Intervention
		/// </summary>
		[Relation(
			CProjet.c_nomTable,
		   CProjet.c_champId,
		   CProjet.c_champId,
			false,
			false,
			false)]
		[DynamicField("Associated project")]
        [TiagRelation(typeof(CProjet), "TiagSetProjectKeys")]
		public CProjet Projet
		{
			get
			{
				return (CProjet)GetParent(CProjet.c_champId, typeof(CProjet));
			}
			set
			{
				SetParent(CProjet.c_champId, value);
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champPrjX)]
		public int DesignerProjetX
		{
			get
			{
				return (int)Row[c_champPrjX];
			}
			set
			{
				Row[c_champPrjX] = value;
			}
		}

		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champPrjY)]
		public int DesignerProjetY
		{
			get
			{
				return (int)Row[c_champPrjY];
			}
			set
			{
				Row[c_champPrjY] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champPrjWidth)]
		public int DesignerProjetWidth
		{
			get
			{
				return (int)Row[c_champPrjWidth];
			}
			set
			{
				Row[c_champPrjWidth] = value;
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// 
		/// </summary>
		[TableFieldProperty(c_champPrjHeight)]
		public int DesignerProjetHeight
		{
			get
			{
				return (int)Row[c_champPrjHeight];
			}
			set
			{
				Row[c_champPrjHeight] = value;
			}
		}


		public CTypeElementDeProjet TypeElementDeProjet
		{
			get
			{
				return new CTypeElementDeProjet(ETypeElementDeProjet.Intervention);
			}
		}

		#endregion


		
        //----------------------------------------------------------
        //[DynamicChilds("Project Link related", typeof(CLienDeProjet))]
		public CListeObjetsDonnees LiensDeProjetAttaches
		{
			get
			{
				CFiltreData filtre = new CFiltreData(CLienDeProjet.c_champInterA + "=@1 or "
                    +CLienDeProjet.c_champInterB+"@1", Id);
				return new CListeObjetsDonnees(ContexteDonnee, typeof(CLienDeProjet), filtre);
			}
		}

        //----------------------------------------------------------
        /// <summary>
        /// Donne la liste des liens de projet pour lesquels l'intervention est initiale
        /// </summary>
        [DynamicChilds("Links as Intervention A", typeof(CLienDeProjet))]
        [RelationFille(typeof ( CLienDeProjet),"InterventionA")]
        public CListeObjetsDonnees LiensEnTantQueInterventionA
        {
            get
            {
                return GetDependancesListe(CLienDeProjet.c_nomTable, CLienDeProjet.c_champInterA);
            }
        }

        //----------------------------------------------------------
        /// <summary>
        /// Donne la liste des liens de projet pour lesquels l'intervention est terminale
        /// </summary>
        [DynamicChilds("Links as Intervention B", typeof(CLienDeProjet))]
        [RelationFille(typeof(CLienDeProjet), "InterventionB")]
        public CListeObjetsDonnees LiensEnTantQueInterventionB
        {
            get
            {
                return GetDependancesListe(CLienDeProjet.c_nomTable, CLienDeProjet.c_champInterB);
            }
        }

		public CEtatPlanification EtatPlanification
		{
			get
			{
				if (EstGelee)
					return new CEtatPlanification(EEtatPlanification.EnStandBy);

				switch (Etat.Etat)
				{
					case EtatIntervention.NonPlanifiee:
						return new CEtatPlanification(EEtatPlanification.APrePlanifier);
					case EtatIntervention.Preplanifiee:
						return new CEtatPlanification(EEtatPlanification.PrePlanifie);
					case EtatIntervention.Planifiee:
						if (DateFinPlanifiee != null && DateTime.Now > (DateTime)DateFinPlanifiee)
							return new CEtatPlanification(EEtatPlanification.EnRetard);
						else
							return new CEtatPlanification(EEtatPlanification.Planifie);
					case EtatIntervention.EnCours:
						return new CEtatPlanification(EEtatPlanification.EnCours);
					case EtatIntervention.Terminee:
						return new CEtatPlanification(EEtatPlanification.Termine);
					case EtatIntervention.Annulee:
						return new CEtatPlanification(EEtatPlanification.Annule);
					default:
						break;
				}

				// Par défaut, si pas d'Etat connu
				return new CEtatPlanification(EEtatPlanification.APrePlanifier);
			}
		}

		//---------------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Date de début pré-planifiée
		/// </summary>
		[TableFieldProperty(c_champDateDebutPreplanifiee, NullAutorise = true)]
		[DynamicField("Preplanified start date")]
        [TiagField("Preplanified start date")]
		public DateTime? DateDebutPrePlanifiee
		{
			get
			{
				if (Row[c_champDateDebutPreplanifiee] == DBNull.Value)
					return null;
				return ((DateTime?)Row[c_champDateDebutPreplanifiee]).Value.Date;
			}
			set
			{
				if (value == null)
					Row[c_champDateDebutPreplanifiee] = DBNull.Value;
				else
					Row[c_champDateDebutPreplanifiee] = value.Value.Date;
			}
		}
		public string DateDebutPrePlanifieeToString
		{
			get
			{
				if (DateDebutPrePlanifiee != null)
					return ((DateTime)DateDebutPrePlanifiee).ToString("g");
				return "";
			}
		}


		//-----------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Date de fin pré-planifiée
		/// </summary>
		[TableFieldProperty(c_champDateFinPrePlanifiee, NullAutorise = true)]
		[DynamicField("Preplanified end date")]
        [TiagField("Preplanified end date")]
		public DateTime? DateFinPrePlanifiee
		{
			get
			{
				if (Row[c_champDateFinPrePlanifiee] == DBNull.Value)
					return null;
				return ((DateTime?)Row[c_champDateFinPrePlanifiee]).Value.Date;
			}
			set
			{
				if (value == null)
					Row[c_champDateFinPrePlanifiee] = DBNull.Value;
				else
					Row[c_champDateFinPrePlanifiee] = value.Value.Date;
			}
		}
		public string DateFinPrePlanifieeToString
		{
			get
			{
				if (DateFinPrePlanifiee != null)
					return ((DateTime)DateFinPrePlanifiee).ToString("g");
				return "";
			}
		}


		//---------------------------------------------
		public DateTime? DateDebutPlanifiee
		{
			get
			{
				DateTime? retour = null;
				foreach (CFractionIntervention fraction in Fractions)
				{
					if (retour == null || retour > fraction.DateDebutPlanifie)
						retour = fraction.DateDebutPlanifie;
				}
				return retour;
			}
			set
			{
			}
		}
		public string DateDebutPlanifieeToString
		{
			get
			{
				if (DateDebutPlanifiee != null)
					return ((DateTime)DateDebutPlanifiee).ToString("g");
				return "";
			}
		}

		//---------------------------------------------
		public DateTime? DateFinPlanifiee
		{
			get
			{
				DateTime? retour = null;
				foreach (CFractionIntervention fraction in Fractions)
				{
					if (retour == null || retour < fraction.DateFinPlanifiee)
						retour = fraction.DateFinPlanifiee;
				}
				return retour;
			}
			set
			{
			}
		}
		public string DateFinPlanifieToString
		{
			get
			{
				if (DateFinPlanifiee != null)
					return ((DateTime)DateFinPlanifiee).ToString("g");
				return "";
			}
		}

		


        public void TiagSetPhaseTicketKeys(object[] lstCles)
        {
            CPhaseTicket phase = new CPhaseTicket(ContexteDonnee);
            if (phase.ReadIfExists(lstCles))
                PhaseTicket = phase;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit la Phase de Ticket associée à l'Intervention
		/// </summary>
		[Relation(
			CPhaseTicket.c_nomTable,
			CPhaseTicket.c_champId,
			CPhaseTicket.c_champId,
			false,
			true,
			false)]
		[DynamicField("Associated ticket phase")]
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



		//---------------------------------------------
		/// <summary>
		/// Donne la liste des périodes de Gel de l'Intervention
		/// </summary>
		[RelationFille(typeof(CGel), "Intervention")]
		[DynamicChilds("Freeze list", typeof(CGel))]
		public CListeObjetsDonnees Gels
		{
			get
			{
				return GetDependancesListe(CGel.c_nomTable, c_champId);
			}
		}




		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationIntervention_ChampCustom(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationIntervention_ChampCustom.c_nomTable;
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
				return new IDefinisseurChampCustom[] { TypeIntervention };
			}
		}

		//----------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			if (TypeIntervention == null)
				return new CChampCustom[0];

			ArrayList lst = new ArrayList();
			foreach (CRelationTypeIntervention_ChampCustom rel in TypeIntervention.RelationsChampsCustomDefinis)
				lst.Add(rel.ChampCustom);

			foreach (CRelationTypeIntervention_Formulaire rel1 in TypeIntervention.RelationsFormulaires)
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
        /// Donne la liste des relations entre l'intervention et les champs personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationIntervention_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom field relations", typeof(CRelationIntervention_ChampCustom))]
		public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationIntervention_ChampCustom.c_nomTable, c_champId);
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

		#region element lié à la Intervention

		/*/// <summary>
		/// Interne : Type de l'élément suivi
		/// </summary>
		[TableFieldProperty(c_champTypeElementLie, 1024)]
		[IndexField]
		[DynamicField("Linked element type")]
		public string StringTypeElementAIntervention
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
		public Type TypeElementAIntervention
		{
			get
			{
				return CActivatorSurChaine.GetType(StringTypeElementAIntervention);
			}
			set
			{
				if (value != null)
					StringTypeElementAIntervention = value.ToString();
				else
					StringTypeElementAIntervention = "";
			}
		}

		/// <summary>
		/// Interne : Id de l'élément suivi
		/// </summary>
		[TableFieldPropertyAttribute(c_champIdElementLie)]
		[IndexField]
		[DynamicField ("Linked element ID")]
		public int IdElementAIntervention
		{
			get
			{
				return (int)Row[c_champIdElementLie];
			}
			set
			{
				Row[c_champIdElementLie] = value;
			}
		}*/

        public void TiagSetSiteKeys(object[] lstCles)
        {
            CSite site = new CSite(ContexteDonnee);
            if (site.ReadIfExists(lstCles))
                Site = site;
        }
        //-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le Site associé à l'intervention
		/// </summary>
		/// Note SC : Le champ de lien n'est pas CSite.c_champId pour des raisons
		/// historiques : en effet, l'intervention, à sa conception utilisait une 
		/// relation type/id, mais pour des raisons d'optim, elle a été remplacée
		/// par un lien direct sur le site.
		[Relation(
			CSite.c_nomTable,
			CSite.c_champId,
			CIntervention.c_champIdElementLie,
			true,
			false,
			true)]
		[DynamicField("Site")]
		[TiagRelation(typeof(CSite), "TiagSetSiteKeys")]
        public CSite Site
		{
			get
			{
				return (CSite)GetParent(CIntervention.c_champIdElementLie, typeof(CSite));
			}
			set
			{
				SetParent(CIntervention.c_champIdElementLie, value);
			}
		}


		//-------------------------------------------------------
		/// <summary>
		/// Element lié à l'intervention (site)
		/// </summary>

		public IElementAIntervention ElementLiePrincipal
		{
			get
			{
				return Site;
			}
		}

		/// <summary>
		/// Donne ou définit l'Elément sur lequel a lieu l'intervention ( site )
		/// </summary>
		///  Note SC : cette fonction est également là pour
		/// raisons historiques : ne pas l'enlever surtout !
		[DynamicFieldAttribute("Linked element")]
		public CObjetDonneeAIdNumerique ElementAIntervention
		{
			get
			{
				return Site;
			}
			set
			{
				if (value is CSite)
					Site = (CSite)value;
				else
					Site = null;
			}
		}

		#endregion

		#region Gestion des ressources
		//-----------------------------------------------------------------------------------------------------
		public IRessourceEntreePlanning[] GetRessourcesAssociees(ITypeRelationEntreePlanning_Ressource typeRelation)
		{
			if (typeRelation is CTypeIntervention_ProfilIntervenant)
				return GetIntervenantsAssocies((CTypeIntervention_ProfilIntervenant)typeRelation);
            if (typeRelation is CContrainte)
            {
                IRessourceEntreePlanning res = GetRessourceMateriellesAssociee((CContrainte)typeRelation);
                if (res != null)
                    return new IRessourceEntreePlanning[] { res };
            }
            return new IRessourceEntreePlanning[0];
			return null;
		}

		//-----------------------------------------------------------------------------------------------------
		/// <summary>
		/// Retourne vrai si la contrainte est cochée dans la checkList
		/// </summary>
		/// <param name="contrainte">contrainte</param>
		/// <returns>booléen</returns>
		public bool IsChecked(CContrainte contrainte)
		{
			foreach (CIntervention_Ressource relRes in RelationsRessourcesMaterielles)
			{
				if (relRes.Contrainte.Equals(contrainte))
					return relRes.IsChecked;
			}
			return false;
		}

        //-----------------------------------------------------------------------------------------------------
        public CResultAErreur DissocieRessource(ITypeRelationEntreePlanning_Ressource typeRelation, IRessourceEntreePlanning ressource)
        {
            if (typeRelation is CTypeIntervention_ProfilIntervenant && ressource is CActeur)
                return DissocieActeur((CTypeIntervention_ProfilIntervenant)typeRelation, (CActeur)ressource);
            if (typeRelation is CContrainte && ressource is CRessourceMaterielle)
                return DissocieRessourceMatérielle((CContrainte)typeRelation, (CRessourceMaterielle)ressource);
            return CResultAErreur.True;
        }

		//-----------------------------------------------------------------------------------------------------
		public CResultAErreur AssocieRessource(ITypeRelationEntreePlanning_Ressource typeRelation, IRessourceEntreePlanning ressource)
		{
			if (typeRelation is CTypeIntervention_ProfilIntervenant && (ressource == null || ressource is CActeur))
				return AssocieActeur((CTypeIntervention_ProfilIntervenant)typeRelation, (CActeur)ressource);
			if (typeRelation is CContrainte && (ressource == null || ressource is CRessourceMaterielle))
				return AssocieRessourceMatérielle((CContrainte)typeRelation, (CRessourceMaterielle)ressource);
			CResultAErreur result = CResultAErreur.True;
			result.EmpileErreur(I.T("Cannot affect this ressource|198"));
			return result;
		}

		//-----------------------------------------------------------------------------------------------------
		public ITypeRelationEntreePlanning_Ressource[] GetTypesRelationsAssociees(IRessourceEntreePlanning ressource)
		{
			if (ressource is CActeur)
				return GetTypesRelationsAssociees((CActeur)ressource);
			if (ressource is CRessourceMaterielle)
				return GetContraintesAssociees((CRessourceMaterielle)ressource);
			return null;
		}

		//-----------------------------------------------------------------------------------------------------
		public ITypeRelationEntreePlanning_Ressource[] GetRelationsRessourceAAffecter(Type tp)
		{
			List<ITypeRelationEntreePlanning_Ressource> lst = new List<ITypeRelationEntreePlanning_Ressource>();
			if (tp == null || tp == typeof(CActeur))
			{
				foreach (ITypeRelationEntreePlanning_Ressource rel in TypeIntervention.RelationsProfilsIntervenants)
					lst.Add(rel);
			}
			if (tp == null || tp == typeof(CRessourceMaterielle))
			{
				foreach (ITypeRelationEntreePlanning_Ressource rel in TypeIntervention.Contraintes)
					lst.Add(rel);
				if (ElementAIntervention is CSite)
					foreach (CContrainte contrainte in ((CSite)ElementAIntervention).ToutesLesContraintes)
						if (!contrainte.IsInCheckListApplique && !contrainte.TypeContrainte.IsContrainteNecessaireActeur)
							lst.Add(contrainte);
			}
			return lst.ToArray();
		}

		//-----------------------------------------------------------------------------------------------------
		public CContrainte[] ToutesLesContraintesCheckList
		{
			get
			{
				List<CContrainte> lst = new List<CContrainte>();
				if (TypeIntervention == null)
					return lst.ToArray();
				foreach (CContrainte contrainte in TypeIntervention.Contraintes)
					if (contrainte.IsInCheckListApplique)
						lst.Add(contrainte);
				if (ElementAIntervention is CSite)
				{
					foreach (CContrainte contrainte in ((CSite)ElementAIntervention).ToutesLesContraintes)
						if (contrainte.IsInCheckListApplique)
							lst.Add(contrainte);
				}
				return lst.ToArray();
			}
		}

		//-----------------------------------------------------------------------------------------------------
		public CContrainte[] ToutesLesContraintesALeverParLesActeurs
		{
			get
			{
				List<CContrainte> lst = new List<CContrainte>();
				if (TypeIntervention == null)
					return lst.ToArray();
				foreach (CContrainte contrainte in TypeIntervention.Contraintes)
					if (contrainte.TypeContrainte.IsContrainteNecessaireActeur)
						lst.Add(contrainte);
				if (ElementAIntervention is CSite)
				{
					foreach (CContrainte contrainte in ((CSite)ElementAIntervention).ToutesLesContraintes)
						if (contrainte.TypeContrainte.IsContrainteNecessaireActeur)
							lst.Add(contrainte);
				}
				return lst.ToArray();
			}
		}

		//-----------------------------------------------------------------------------------------------------
		public IRessourceEntreePlanning[] GetRessourcesAffectees(Type typeRessource)
		{
			List<IRessourceEntreePlanning> lst = new List<IRessourceEntreePlanning>();
			if (typeRessource == null || typeRessource == typeof(CActeur))
			{
				foreach (CIntervention_Intervenant rel in RelationsIntervenants)
					lst.Add(rel.Intervenant);
			}
			if (typeRessource == null || typeRessource == typeof(CRessourceMaterielle))
			{
				foreach (CIntervention_Ressource rel in RelationsRessourcesMaterielles)
					lst.Add(rel.RessourceMaterielle);
			}
			return lst.ToArray();
		}

		//-----------------------------------------------------------------------------------------------------
		public IRessourceEntreePlanning[] GetRessourcesPossibles(
			IProfilElement profil,
			CFiltreData filtreDeBase)
		{
			CContrainte contrainte = null;
			if (profil is CContrainte)
			{
				contrainte = (CContrainte)profil;
				profil = TypeIntervention.ProfilRessourceDefaut;
			}
			CListeObjetsDonnees listeFinale = CProfilElement.GetElementsForSource(profil, this, contrainte, filtreDeBase);

			if (listeFinale != null)
				return (IRessourceEntreePlanning[])listeFinale.ToArray(typeof(IRessourceEntreePlanning));
			return new IRessourceEntreePlanning[0];
		}



		//-----------------------------------------------------------------------------------------------------
		public Type[] GetTypesRessourceAAffecter()
		{
			return new Type[] { typeof(CActeur), typeof(CRessourceMaterielle) };
		}

		//-----------------------------------------------------------------------------------------------------
		public bool Occupe(IRessourceEntreePlanning ressource)
		{
			return GetTypesRelationsAssociees(ressource).Length > 0;
		}

		//---------------------------------------------
		/// <summary>
		/// Donne la liste des relations entre l'intervention et les intervenants associés
		/// </summary>
		[RelationFille(typeof(CIntervention_Intervenant), "Intervention")]
		[DynamicChilds("Operators relations", typeof(CIntervention_Intervenant))]
		public CListeObjetsDonnees RelationsIntervenants
		{
			get
			{
				return GetDependancesListe(CIntervention_Intervenant.c_nomTable, c_champId);
			}
		}

		//---------------------------------------------
		/// <summary>
		/// Donne la liste des relations entre l'intervention et les Ressources Materielles associées
		/// </summary>
		[RelationFille(typeof(CIntervention_Ressource), "Intervention")]
		[DynamicChilds("Resource relations", typeof(CIntervention_Ressource))]
		public CListeObjetsDonnees RelationsRessourcesMaterielles
		{
			get
			{
				return GetDependancesListe(CIntervention_Ressource.c_nomTable, c_champId);
			}
		}


        //---------------------------------------------
        public CListeObjetsDonnees GetRelationsIntervenants(CTypeIntervention_ProfilIntervenant relProfil)
        {
            CListeObjetsDonnees listeInter = RelationsIntervenants;
            listeInter.InterditLectureInDB = true;
            listeInter.FiltrePrincipal = CFiltreData.GetAndFiltre(
                listeInter.FiltrePrincipal,
                new CFiltreData(CTypeIntervention_ProfilIntervenant.c_champId + "=@1", relProfil.Id));
            return listeInter;
        }

        //---------------------------------------------
		public CActeur[] GetIntervenantsAssocies(CTypeIntervention_ProfilIntervenant relProfil)
		{
            CListeObjetsDonnees listeInter = GetRelationsIntervenants(relProfil);
            List<CActeur> lst = new List<CActeur>();
            foreach (CIntervention_Intervenant re in listeInter)
            {
                if (re.Intervenant != null)
                    lst.Add(re.Intervenant);
            }
            return lst.ToArray();
		}

		//---------------------------------------------
		public CRessourceMaterielle GetRessourceMateriellesAssociee(CContrainte contrainte)
		{
			CListeObjetsDonnees listeRes = RelationsRessourcesMaterielles;
			listeRes.InterditLectureInDB = true;
			listeRes.Filtre = new CFiltreData(CContrainte.c_champId + "=@1", contrainte.Id);
			if (listeRes.Count > 0)
				return ((CIntervention_Ressource)listeRes[0]).RessourceMaterielle;
			return null;
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne le type de relation associé au acteur demandé
		/// </summary>
		/// <param name="part"></param>
		/// <returns></returns>
		public ITypeRelationEntreePlanning_Ressource[] GetTypesRelationsAssociees(CActeur part)
		{
			if (part == null)
				return null;
			CListeObjetsDonnees lst = RelationsIntervenants;
			lst.InterditLectureInDB = true;
			lst.Filtre = new CFiltreData(CActeur.c_champId + "=@1", part.Id);
			List<ITypeRelationEntreePlanning_Ressource> lstRetour = new List<ITypeRelationEntreePlanning_Ressource>();
			foreach (CIntervention_Intervenant rel in lst)
				lstRetour.Add(rel.RelationProfil);
			return lstRetour.ToArray();
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne le type de relation associé à la ressource demandée
		/// </summary>
		/// <param name="part"></param>
		/// <returns></returns>
		public ITypeRelationEntreePlanning_Ressource[] GetContraintesAssociees(CRessourceMaterielle res)
		{
			if (res == null)
				return null;
			CListeObjetsDonnees lst = RelationsRessourcesMaterielles;
			lst.InterditLectureInDB = true;
			lst.Filtre = new CFiltreData(CRessourceMaterielle.c_champId + "=@1", res.Id);
			List<ITypeRelationEntreePlanning_Ressource> lstRetour = new List<ITypeRelationEntreePlanning_Ressource>();
			foreach (CIntervention_Ressource rel in lst)
				lstRetour.Add(rel.Contrainte);
			return lstRetour.ToArray();
		}


        [DynamicMethod("Assigne a Member to the current intevention", "Profile relation ID", "Member to assigne")]
        public CResultAErreur AssigneMember(int nIdRelProfil, CActeur acteur)
        {
            CTypeIntervention_ProfilIntervenant relProfil = new CTypeIntervention_ProfilIntervenant(ContexteDonnee);
            if (relProfil.ReadIfExists(nIdRelProfil))
            {
                return AssocieActeur(relProfil, acteur);
            }
            return CResultAErreur.True;
        }

        
		//---------------------------------------------
		public CResultAErreur AssocieActeur(CTypeIntervention_ProfilIntervenant relProfil, CActeur acteur)
		{
			CResultAErreur result = CResultAErreur.True;
            if (acteur == null)
                return result;
			
            //Un acteur ne peut être associé qu'à un seul profil
            ITypeRelationEntreePlanning_Ressource[] oldRelsProfils = (ITypeRelationEntreePlanning_Ressource[])GetTypesRelationsAssociees(acteur);
			CTypeIntervention_ProfilIntervenant oldRelProfil = (oldRelsProfils != null && oldRelsProfils.Length > 0) ? (CTypeIntervention_ProfilIntervenant)oldRelsProfils[0] : null;
			if (acteur != null &&
				oldRelProfil != null && !oldRelProfil.Equals(relProfil))
			{
				result = DissocieActeur(oldRelProfil, acteur);
				if (!result)
					return result;
			}
			//Vérifie que l'acteur n'est pas déjà associé à ce profil
			CListeObjetsDonnees listeInter = RelationsIntervenants;
			listeInter.InterditLectureInDB = true;
			listeInter.Filtre = new CFiltreData(CTypeIntervention_ProfilIntervenant.c_champId + "=@1 and "+
                CActeur.c_champId+"=@2",
				relProfil.Id, acteur.Id);
            if ( listeInter.Count == 0 )
            {
                CIntervention_Intervenant rel = new CIntervention_Intervenant(ContexteDonnee);
				rel.CreateNewInCurrentContexte();
				rel.Intervention = this;
				rel.RelationProfil = relProfil;
				rel.Intervenant = acteur;
			}
			return result;
		}

        //---------------------------------------------
        public CResultAErreur DissocieActeur ( CTypeIntervention_ProfilIntervenant relProfil, CActeur acteur )
        {
            CResultAErreur result = CResultAErreur.True;
            if ( acteur == null )
                return result;
            CListeObjetsDonnees lst = GetRelationsIntervenants ( relProfil );
            lst.Filtre = new CFiltreData ( CActeur.c_champId+"=@1",
                acteur.Id );
            if (lst.Count > 0)
            {
                result = CObjetDonneeAIdNumerique.Delete(lst);
            }
            return result;
        }

		//---------------------------------------------
		public CResultAErreur AssocieRessourceMatérielle(CContrainte contrainte, CRessourceMaterielle ressource)
		{
			CResultAErreur result = CResultAErreur.True;
			//Trouve la contrainte associée à la ressource
			CListeObjetsDonnees listeRessources = RelationsRessourcesMaterielles;
			listeRessources.InterditLectureInDB = true;
			listeRessources.Filtre = new CFiltreData(CContrainte.c_champId + "=@1",
				contrainte.Id);
			CIntervention_Ressource rel = null;
			if (listeRessources.Count > 0)
			{
				//Change la ressource associee
				rel = (CIntervention_Ressource)listeRessources[0];
				rel.RessourceMaterielle = ressource;
				if (ressource == null)
					rel.Delete();
			}
			else if (ressource != null)
			{
				rel = new CIntervention_Ressource(ContexteDonnee);
				rel.CreateNewInCurrentContexte();
				rel.Intervention = this;
				rel.Contrainte = contrainte;
				rel.RessourceMaterielle = ressource;
			}
			return result;
		}

        //---------------------------------------------------------------------------------------------------------
        public CResultAErreur DissocieRessourceMatérielle(CContrainte contrainte, CRessourceMaterielle ressource)
        {
            CResultAErreur result = CResultAErreur.True;
            if (contrainte == null || ressource == null)
                return result;

            //Trouve la relations à la contrainte
            CListeObjetsDonnees lstRessources = RelationsRessourcesMaterielles;
            lstRessources.Filtre = new CFiltreData(
                CContrainte.c_champId + "=@1 and " +
                CRessourceMaterielle.c_champId + "=@2",
                contrainte,
                ressource);
            if (lstRessources.Count > 0)
            {
                result = CObjetDonneeAIdNumerique.Delete(lstRessources);
            }
            return result;
        }

		//---------------------------------------------
		public ITypeRelationEntreePlanning_Ressource[] GetTypesRelationsIntervenantsPossible()
		{
			List<ITypeRelationEntreePlanning_Ressource> lst = new List<ITypeRelationEntreePlanning_Ressource>();
			if (TypeIntervention != null)
				foreach (CTypeIntervention_ProfilIntervenant rel in TypeIntervention.RelationsProfilsIntervenants)
					lst.Add(rel);
			return lst.ToArray();
		}
		#endregion


		#region IEntreePlanning Membres

		public System.Drawing.Color Couleur
		{
			get
			{
				return CSerieDeCouleurs.GetCouleur(Id);
			}
			set
			{

			}
		}

		string IEntreePlanning.Libelle
		{
			get
			{
				return Libelle;
			}
			set
			{
			}
		}

		public ITranchePlanning[] Tranches
		{
			get
			{
				return (ITranchePlanning[])Fractions.ToArray(typeof(ITranchePlanning));
			}
			set
			{
			}
		}

		#endregion


        #region Traitement des gels
        /// <summary>
		/// Permet de Geler l'Intervention
		/// </summary>
		/// <param name="dateTime">Date du Gel</param>
		/// <param name="CCauseGel">La Cause du Gel</param>
		/// <param name="strInfos">Information sur le Gel</param>
		/// <returns>VRAI si l'opération s'est bien passée, sinon FAUX</returns>
		[DynamicMethod("Freeze the intervention",
			"Freezing start date",
			"Freezing cause",
			"Information")]
		public CResultAErreur Geler(DateTime dateTime, CCauseGel causeGel, string strInfo)
		{
			CResultAErreur result = SElementGelable.Geler(this, dateTime, causeGel, strInfo);
			RecalculeEtatGel();
			return result;
		}

        //-----------------------------------------------------------
        public CResultAErreur Geler(DateTime dateTime, CCauseGel causeGel, string strInfo, CDbKey keyResponsableDebutGel)
        {
            return Geler(dateTime, causeGel, strInfo);
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Permet de Dégeler l'Intervention
		/// </summary>
		/// <param name="dateFin">Date de fin de gel</param>
		/// <param name="strInfoFin">Informations sur la fin de gel</param>
		/// <returns>VRAI si l'opération s'est bien passée, sinon FAUX</returns>
		[DynamicMethod("Defreeze the intervention",
			"Freezing end date",
			"Information")]
		public CResultAErreur Degeler(DateTime dateFin, string strInfoFin)
		{
			CResultAErreur result = SElementGelable.Degeler(this, dateFin, strInfoFin);
			RecalculeEtatGel();
			return result;
		}

        //-----------------------------------------------------------
        public CResultAErreur Degeler(DateTime dateFin, string strInfoFin, CDbKey KeyResponsabelFinGel)
        {
            return Degeler(dateFin, strInfoFin);
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Valeur booléenne qui indique si l'Intervention est gelée ou non
		/// </summary>
		[TableFieldProperty(c_champEstGelee)]
		[DynamicField("Is frozen")]
		public bool EstGelee
		{
			get
			{
				return (bool)Row[c_champEstGelee];
			}
		}

		//----------------------------------------------------------
		/// <summary>
		/// Recalcule automatiquement l'état de gel.
		/// </summary>
		[DynamicMethod("Recalculate the freezing state automatically")]
		public void RecalculeEtatGel()
		{
			Row[c_champEstGelee] = SElementGelable.CalculeEtatGel(this);
        }
        #endregion

        #region IElementAActeursPossibles

        public ITypeElementAContacts TypeElementAContactPossible
		{
			get { return TypeIntervention; }
		}

		#endregion

		//----------------------------------------------------------
		public bool CanPreplanifier(CDonneesActeurUtilisateur user)
		{
			if (TypeIntervention != null && TypeIntervention.ProfilPreplanifieur != null)
				return TypeIntervention.ProfilPreplanifieur.IsInProfil(user, this);
			return true; // Si pas de profil tout le monde peut le faire
		}

		//----------------------------------------------------------
		public bool CanPlanifier(CDonneesActeurUtilisateur user)
		{
			if (TypeIntervention != null && TypeIntervention.ProfilPlanifieur != null)
				return TypeIntervention.ProfilPlanifieur.IsInProfil(user, this);
			return true;
		}


		#region IElementAEvenementsDefinis Membres

		//------------------------------------------------------------------------
		public IDefinisseurEvenements[] Definisseurs
		{
			get
			{
				if (TypeIntervention == null)
					return new IDefinisseurEvenements[0];
				return new IDefinisseurEvenements[] { TypeIntervention };
			}
		}

		//------------------------------------------------------------------------
		public bool IsDefiniPar(IDefinisseurEvenements definisseur)
		{
			if (TypeIntervention == null || !(definisseur is CTypeIntervention))
				return false;
			if (TypeIntervention.Equals(definisseur))
				return true;
			return false;
		}


		#endregion

		public void CheckContrainte(CContrainte contrainte, bool bIsChecked)
		{
			CResultAErreur result = CResultAErreur.True;
			//Trouve la contrainte associée à la ressource
			CListeObjetsDonnees listeRessources = RelationsRessourcesMaterielles;
			listeRessources.InterditLectureInDB = true;
			listeRessources.Filtre = new CFiltreData(CContrainte.c_champId + "=@1",
				contrainte.Id);
			CIntervention_Ressource rel = null;
			if (listeRessources.Count > 0)
			{
				//Change la ressource associee
				rel = (CIntervention_Ressource)listeRessources[0];
				if (!bIsChecked)
					rel.Delete();
				else
					rel.IsChecked = true;
			}
			else if (bIsChecked)
			{
				rel = new CIntervention_Ressource(ContexteDonnee);
				rel.CreateNewInCurrentContexte();
				rel.Intervention = this;
				rel.Contrainte = contrainte;
				rel.IsChecked = bIsChecked;
			}
		}



		//--------------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des relations entre l'intervention et les listes d'Opérations associées
		/// </summary>
		[RelationFille(typeof(CIntervention_ListeOperations), "Intervention")]
		[DynamicChilds("Operations List Relations", typeof(CIntervention_ListeOperations))]
		public CListeObjetsDonnees RelationsListesOperations
		{
			get
			{
				return GetDependancesListe(CIntervention_ListeOperations.c_nomTable, c_champId);
			}
		}




		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des Opérations prévisionnelles sur cette Intervention
		/// </summary>
		[RelationFille(typeof(COperation), "Intervention")]
		[DynamicChilds("Planified Operations", typeof(COperation))]
		public CListeObjetsDonnees Operations
		{
			get
			{
				return GetDependancesListe(COperation.c_nomTable, c_champId);
			}
		}



		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit la version de données qui sera appliquées<br/>
		/// par cette intervention
		/// </summary>
		[Relation(
			CVersionDonnees.c_nomTable,
			CVersionDonnees.c_champId,
			CVersionDonnees.c_champId,
			false,
			false,
			false,
			PasserLesFilsANullLorsDeLaSuppression=true)]
		[DynamicField("Associated data version")]
		public CVersionDonnees VersionDonneesAAppliquer
		{
			get
			{
				return (CVersionDonnees)GetParent(CVersionDonnees.c_champId, typeof(CVersionDonnees));
			}
			set
			{
				SetParent(CVersionDonnees.c_champId, value);
			}
		}







		#region IElementAOperationPrevisionnelle Membres


		public IFournisseurListeTypeOperation FournisseurListeTypeOperation
		{
			get
			{
				return CFournisseurListeTousTypesOperations.InstanceUnique;
			}
		}

		#endregion


		///Pour compiler !!
		///
		public List<CAnomalieProjet> GetAnomaliesProjet()
		{
			return new List<CAnomalieProjet>();
		}

        /// <summary>
        /// Applique les modifications pour cette itervention.
        /// </summary>
        /// <returns>VRAI si succès, FAUX si échec</returns>
		[DynamicMethod("Apply modifications for that interventions. If an error occurs, the result is FALSE")]
		public bool ApplyModifications()
		{
			CResultAErreur result = CResultAErreur.True;
			if (VersionDonneesAAppliquer != null)
			{
				CVersionDonnees version = VersionDonneesAAppliquer;
				CSessionClient session = CSessionClient.GetSessionForIdSession(ContexteDonnee.IdSession);
				if (session == null)
					return false;
				try
				{
					session.BeginTrans();
					version.BeginEdit();
					CListeObjetsDonnees listeInters = new CListeObjetsDonnees(version.ContexteDonnee, typeof(CIntervention));
					listeInters.Filtre = new CFiltreData(CVersionDonnees.c_champId + "=@1",
						version.Id);
					foreach (CIntervention inter in listeInters)
					{
						inter.VersionDonneesAAppliquer = null;
					}
					result = version.CommitEdit();
					if (result)
						result = version.AppliqueModifications();
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
				}
				finally
				{
					if (result)
						result = session.CommitTrans();
					else
						result = session.RollbackTrans();
				}
			}
			return result.Result;
		}


        /// <summary>
        /// Crée une fraction pour cette intervention
        /// </summary>
        /// <param name="dateDebut">Date de début de la fraction</param>
        /// <param name="dateFin">Date de fin de la fraction</param>
        [DynamicMethod("Create a part for this intervention","Start date", "End date")]
        public void AddInterventionPart(DateTime dateDebut, DateTime dateFin)
        {
            CFractionIntervention fraction = new CFractionIntervention(this.ContexteDonnee);
            fraction.CreateNewInCurrentContexte();
            fraction.DateDebutPlanifie = dateDebut;
            fraction.DateDebut = dateDebut;
            fraction.DateFinPlanifiee = dateFin;
            fraction.DateFin = dateFin;
            fraction.Intervention = this;



        }


        /// <summary>
        /// Utilisation future
        /// </summary>
        [DynamicChilds("Concerning anomalies", typeof(CAnomalieProjet))]
        [RelationFille(typeof(CAnomalieProjet), "InterventionConcernee")]
        public CListeObjetsDonnees AnomaliesConcernant
        {
            get{
                return GetDependancesListe ( CAnomalieProjet.c_nomTable, c_champId);
            }
        }


		#region IElementATypeStructurant<CTypeIntervention> Membres

		public CTypeIntervention ElementStructurant
		{
			get { return TypeIntervention; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeIntervention.c_champId];
			}
		}
		#endregion

        //---------------------------------------------------------------------
        public void FillDicSuccesseurs(HashSet<IElementDeProjetPlanifiable> dic)
        {
            //Remplit la liste des successeurs
            foreach (CLienDeProjet lien in LiensEnTantQueInterventionA)
            {
                if (!dic.Contains(lien.ElementB))
                {
                    dic.Add(lien.ElementB);
                    lien.ElementB.FillDicSuccesseurs(dic);
                }
            }
        }

        //---------------------------------------------------------------------
        public void FillDicPredecesseurs(HashSet<IElementDeProjetPlanifiable> dic)
        {
            //Remplit la liste des prédecesseurs
            foreach (CLienDeProjet lien in LiensEnTantQueInterventionB)
            {
                if (!dic.Contains(lien.ElementA))
                {
                    dic.Add(lien.ElementA);
                    lien.ElementA.FillDicSuccesseurs(dic);
                }
            }
        }

        //---------------------------------------------------------------------
        public DateTime DateDebutGantt
        {
            get
            {
                if (DateDebutPlanifiee != null)
                    return DateDebutPlanifiee.Value;
                if (DateDebutPrePlanifiee != null)
                    return DateDebutPrePlanifiee.Value;
                return DateTime.Now;
            }
            set
            {
                if (DateDebutPlanifiee != null)
                    DateDebutPlanifiee = value;
                DateDebutPrePlanifiee = value;
            }
        }

        //---------------------------------------------------------------------
        public DateTime DateFinGantt
        {
            get
            {
                if (DateFinPlanifiee != null)
                    return DateFinPlanifiee.Value;
                if (DateFinPrePlanifiee != null)
                    return DateFinPrePlanifiee.Value;
                return DateTime.Now;
            }
            set
            {
                if (DateFinPlanifiee != null)
                    DateFinPlanifiee = value;
                DateFinPrePlanifiee = value;
            }
        }

        //---------------------------------------------------------------------
        public bool DatesAuto
        {
            get
            {
                return false;
            }
        }

        //---------------------------------------------------------------------
        //Reprend les intervenants définis et les affecte au bon type de profil
        public void RecalcProfilsIntervenantsInCurrentContext( bool bSupprimeSurplus)
        {
            HashSet<CTypeIntervention_ProfilIntervenant> setAffectes = new HashSet<CTypeIntervention_ProfilIntervenant>();
            List<CIntervention_Intervenant> lstOrphelins = new List<CIntervention_Intervenant>();
            List<CIntervention_Intervenant> lstSansInterets = new List<CIntervention_Intervenant>();
            foreach (CIntervention_Intervenant itv in RelationsIntervenants)
            {
                if (itv.RelationProfil != null)
                {
                    if (itv.Intervenant != null && itv.RelationProfil != null)
                    {
                        if (itv.RelationProfil.TypeIntervention == TypeIntervention)
                            setAffectes.Add(itv.RelationProfil);
                        else
                            lstOrphelins.Add(itv);
                    }
                    else if (itv.RelationProfil.TypeIntervention == TypeIntervention)
                        lstSansInterets.Add(itv);
                }
            }
            if (TypeIntervention != null)
            {
                foreach (CIntervention_Intervenant itv in lstOrphelins.ToArray())
                {
                    //trouve une place où le ranger
                    foreach (CTypeIntervention_ProfilIntervenant itp in TypeIntervention.RelationsProfilsIntervenants)
                    {
                        if (!setAffectes.Contains(itp))
                        {
                            if (lstSansInterets.Count > 0)
                            {
                                lstSansInterets[0].RelationProfil = itv.RelationProfil;
                                lstSansInterets.RemoveAt(0);
                            }
                            itv.RelationProfil = itp;
                            setAffectes.Add(itp);
                            //Enleve un des sans interets

                            break; ;
                        }
                    }
                }
            }
            if (bSupprimeSurplus )
            {
                foreach (CIntervention_Intervenant itv in RelationsIntervenants.ToArrayList())
                {
                    if (itv.Intervenant == null || itv.RelationProfil == null || itv.RelationProfil.TypeIntervention != TypeIntervention)
                        itv.Delete(true);
                }
            }
        }

        //---------------------------------------------------------------------
        public void Move(TimeSpan sp, TimeSpan? duree, EModeDeplacementProjet mode, bool bForcerForThisElement)
        {
            return;
        }
        /*
            CResultAErreur result = CResultAErreur.True;
            DateDebutGantt = DateDebutGantt.Add(sp);
            DateFinGantt = DateFinGantt.Add(sp);
            if (DateDebutPlanifiee != null)
            {
                DateDebutPlanifiee = DateDebutPlanifiee.Value.Add(sp);
            }
            if (DateFinPlanifiee != null)
            {
                DateFinPlanifiee = DateFinPlanifiee.Value.Add(sp);
            }
            if (sp.TotalHours > 0 && DateFinPlanifiee != null)//Déplacement vers la droite
            {
                foreach (CLienDeProjet lien in LiensEnTantQueInterventionA)
                {
                    if (lien.ElementB != null && lien.ElementB.GetDateDebut() != null)
                    {
                        if (lien.ElementB.GetDateDebut() > DateFinPlanifiee)
                            result = lien.ElementB.Move(DateFinPlanifiee.Value - lien.ElementB.GetDateDebut().Value);
                        if (!result)
                            break;
                    }
                }
            }
            else
                if (sp.TotalHours < 0 && DateDebutPlanifiee != null)//déplacement vers la gauche
                {
                    foreach (CLienDeProjet lien in LiensEnTantQueInterventionB)
                    {
                        if (lien.ElementA != null && lien.ElementA.GetDateFin() != null)
                        {
                            if (lien.ElementA.GetDateFin() > DateDebutPlanifiee)
                                result = lien.ElementA.Move(DateDebutPlanifiee.Value - lien.ElementA.GetDateFin().Value);
                            if (!result)
                                break;
                        }
                    }
                }
            return result;
        }*/

        //---------------------------------------------------------------------
        [DynamicMethod("Add an operation to the intervention", "Operation type")]
        public COperation AddOperation(CTypeOperation typeOperation)
        {
            if (typeOperation == null)
                return null;
            COperation operationParente = null;
            if (typeOperation.TypeOperationParente != null)
            {
                operationParente = AssureAsOperationDuType(typeOperation.TypeOperationParente, null);
            }
            if (typeOperation.TypesOperationsFilles.Count > 0)
                return AssureAsOperationDuType(typeOperation, operationParente);
            COperation operation = new COperation(ContexteDonnee);
            operation.CreateNewInCurrentContexte();
            operation.Intervention = this;
            operation.TypeOperation = typeOperation;
            operation.OperationParente = operationParente;
            return operation;

        }

        //---------------------------------------------------------------------
        private COperation AssureAsOperationDuType(CTypeOperation typeOperation, COperation operationParente)
        {
            if (operationParente == null)
            {
                if (typeOperation.TypeOperationParente != null)
                    operationParente = AssureAsOperationDuType(typeOperation.TypeOperationParente, null);
            }
            CListeObjetsDonnees lstOperations;
            if (operationParente == null)
            {
                lstOperations = Operations;
                lstOperations.Filtre = new CFiltreData(COperation.c_champIdOpParente + " is null");
            }
            else
            {
                lstOperations = operationParente.OperationsFilles;
            }
            foreach (COperation operation in lstOperations)
            {
                if (operation.TypeOperation != null && operation.TypeOperation.Id == typeOperation.Id)
                    return operation;
            }
            COperation newOperation = new COperation(ContexteDonnee);
            newOperation.CreateNewInCurrentContexte();
            newOperation.Intervention = this;
            newOperation.TypeOperation = typeOperation;
            newOperation.OperationParente = operationParente;
            return newOperation;
        }

        
        #region ISatisfactionBesoin Membres
        /// <summary>
        /// Libellé de l'intervention en tant que satisfaction de besoin
        /// </summary>
        [DynamicField("Satisfaction label")]
        public string LibelleSatisfactionComplet
        {
            get { return I.T("Interventions @1|20171", Libelle); }
        }


        /// <summary>
        /// Liste des besoins satisfaits par l'intervention
        /// </summary>
        [DynamicChilds("Satisfied needs", typeof(CBesoin))]
        public CBesoin[] BesoinsSolutionnes
        {
            get { return CRelationBesoin_Satisfaction.GetBesoinsSatisfaits(this).ToList<CBesoin>().ToArray(); }
        }

        /// <summary>
        /// Liste des relations aux besoins satisfaits par l'intervention
        /// </summary>
        [DynamicChilds("Satisfied needs relations", typeof(CRelationBesoin_Satisfaction))]
        public CListeObjetsDonnees RelationsSatisfaits
        {
            get { return CRelationBesoin_Satisfaction.GetRelationsBesoinsSatisfaits(this); }
        }


        public bool CanSatisfaire(CBesoin besoin)
        {
            return true;
        }

        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct satisfaction to the need")]
        public bool IsDirectSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsDirectSatisfactionFor(this, besoin);
        }


        //-------------------------------------------------------------------------------------
        [DynamicMethod("Returns true if satisfaction is a direct or indirect satisfaction to the need")]
        public bool IsRecursiveSatisfactionFor(CBesoin besoin)
        {
            return CUtilSatisfaction.IsRecursiveSatisfactionFor(this, besoin);
        }

        public CObjetDonneeAIdNumerique ObjetPourEditionElementACout
        {
            get { return this; }
        }

        #endregion

        #region IElementACout Membres

        //--------------------------------------------------------------
        /// <summary>
        /// Coût prévisionnel de l'intervention.
        /// </summary>
        /// <remarks>
        /// Le cout prévisionnel d'une intervention est la somme des couts de ses opérations qui ne satisfont aucun
        /// besoin
        /// </remarks>
        [TableFieldProperty(c_champCoutPrevisionnel)]
        [DynamicField("Estimated cost")]
        public double CoutPrevisionnel
        {
            get
            {
                return (double)Row[c_champCoutPrevisionnel];
            }
        }

        //--------------------------------------------------------------
        /// <summary>
        /// Cout réel d'un intervention
        /// </summary>
        /// <remarks>
        /// Le cout réel d'une intervention est la somme des couts de ses opérations qui ne satisfont aucun
        /// besoin
        /// </remarks>
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
            CBesoin besoin = elementACout as CBesoin;
            if (besoin != null)
                return CUtilElementACout.CalcImputationAFaireSur(this, besoin, bCoutReel);
            return 0;
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


        //---------------------------------------------
        public bool IsCoutFromSources(bool bCoutReel)
        {
            if (bCoutReel)
                return true;
            else
            {
                foreach (COperation operation in Operations)
                    if (operation.Duree != null && operation.Duree > 0)
                        return true;
            }
            return false;
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

        //--------------------------------------------------------------
        /// <summary>
        /// Retourne le cout d'une heure de main d'oeuvre sur cette intervention.
        /// S'il n'y a aucun technicien, utilise le taux horaire prévu,
        /// s'il y en a, utilise le taux horaire des techs s'il est défini,
        /// sinon, le taux horaire prévu
        /// </summary>
        /// <returns></returns>
        public double GetCoutHeureMainOeuvre()
        {
            DateTime dtValorisation = GetDateAUtiliserPourLesValorisations();
            if (RelationsIntervenants.Count > 0)
            {
                double fCoutUnitaire = 0;
                foreach (CIntervention_Intervenant rel in RelationsIntervenants)
                {
                    CTypeConsommable tpCons = TauxHorairePrevu;
                    CActeur acteur = rel.Intervenant;
                    if (acteur != null && acteur.TauxHoraire != null)
                        tpCons = acteur.TauxHoraire;
                    if (tpCons != null)
                        fCoutUnitaire += tpCons.GetValuationForDate(dtValorisation, new CValeurUnite(1, CClasseUniteTemps.c_idH)); 
                }
                return fCoutUnitaire;
            }
            else
            {
                if ( TauxHorairePrevu != null )
                    return TauxHorairePrevu.GetValuationForDate(dtValorisation, new CValeurUnite(1, CClasseUniteTemps.c_idH))*NbOperateurSPrevus;
            }
            return 0;
        }

        //---------------------------------------------
        private DateTime GetDateAUtiliserPourLesValorisations()
        {
            DateTime dt = DateTime.Now;
            if (DateDebutPlanifiee != null)
                dt = DateDebutPlanifiee.Value;
            if (dt == null && DateDebutPrePlanifiee != null)
                dt = DateDebutPrePlanifiee.Value;
            return dt;
        }

        //---------------------------------------------
        public double CalculeTonCoutPuisqueTuNeCalculePasAPartirDesSourcesDeCout(bool bCoutReel)
        {
            if (bCoutReel)
            {
                return 0;//Le cout réel est calculé à partir des fractions
            }
            else
            {
                double fCout = 0;
                CListeObjetsDonnees operations = Operations;
                operations.Filtre = new CFiltreData(COperation.c_champIdOpParente + " is null");
                foreach (COperation operation in operations)
                {
                    fCout += operation.CoutPrevisionnel;
                }
                if (Operations.Count == 0 || fCout == 0)
                {
                    if ( TauxHorairePrevu != null )
                        return GetCoutHeureMainOeuvre() * DureePrevisionnelle;
                }
                
                return fCout;
            }
        }

        //--------------------------------------------------------------
        public bool ShouldAjouterCoutPropreAuCoutDesSource(bool bCoutReel)
        {
            return false;
        }

        

        //--------------------------------------------------------------
        public IElementACout[] GetSourcesDeCout(bool bCoutReel)
        {
            HashSet<IElementACout> setElements = new HashSet<IElementACout>();

            if (bCoutReel)
            {
                //Opérations des fractions
                foreach (CFractionIntervention fraction in Fractions)
                {
                    if (fraction.DateDebut != null)
                    {
                        setElements.Add(fraction);
                    }
                }
            }
            else
            {
                //Opérations planifiées
                foreach (COperation operation in Operations)
                {
                    if (operation.OperationParente == null)
                        setElements.Add(operation);
                }
            }
            return setElements.ToArray();
        }

        //--------------------------------------------------------------
        public CImputationsCouts GetImputationsAFaireSurUtilisateursDeCout()
        {
            CImputationsCouts imputations = new CImputationsCouts(this);
            foreach (CRelationBesoin_Satisfaction relSat in RelationsSatisfaits)
                imputations.AddImputation(relSat.Besoin, relSat.RatioCoutReelApplique, relSat);
            return imputations;
        }

        //--------------------------------------------------------------
        public void InvalideLeCoutDesSourcesDeCout(bool bInvalideLesPrevisionnel, bool bInvalideLesReels)
        {
            if ( bInvalideLesPrevisionnel )
                CUtilElementACout.InvalideLeCoutDesSources(this, false, typeof(CIntervention), typeof(CFractionIntervention), typeof(COperation));
            if ( bInvalideLesReels )
                CUtilElementACout.InvalideLeCoutDesSources(this, true, typeof(CIntervention), typeof(CFractionIntervention), typeof(COperation));
        }


        

        #endregion
    }
}
