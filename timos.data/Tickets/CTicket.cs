using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;

using timos;
using timos.data.version;
using timos.acteurs;
using timos.securite;

using sc2i.doccode;
using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;

namespace timos.data
{
	/// <summary>
    /// Un ticket regroupe l'ensemble des actions à effectuer dans le cadre d'une opération<br/>
    /// de maintenance préventive ou corrective, en réponse à un problème donné chez un client.<br/>
    /// Cela peut tout aussi bien concerner des actions de maintenance ou de vérification périodiques<br/>
    /// prévues à l'avance, qu'une intervention urgente en réponse à un problème ponctuel ou à une panne.
	/// </summary>
    /// <remarks>
    /// Un ticket est constitué d'un enchaînement de phases qui représentent les différentes étapes<br/>
    /// de la résolution du problème, de son début et jusqu'à sa fin.<br/>
    /// Cet enchaînement est modélisé par un diagramme où l'on représente les phases et les liens entre celles-ci.<br/>
    /// Certaines phases de ce ticket peuvent générer des interventions sur les sites du client.<br/>
    /// Un ticket d'intervention concerne un unique client, mais il peut concerner plusieurs sites<br/>
    /// et générer autant d'interventions que nécessaire.
    /// </remarks>
    [DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [DocRefRessources(CDocLabels.c_eProcessResolutionTicket)]
	[DynamicClass("Ticket")]
	[Table(CTicket.c_nomTable, CTicket.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CTicketServeur")]
	[AutoExec("Autoexec")]
    [LicenceCount(CConfigTypesTimos.c_appType_Ticket_ID)]
    [NonClonableObject]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CTicket.c_nomTiag, "Id", true)]
    public class CTicket : CObjetDonneeAIdNumeriqueAuto,
								IObjetDonneeAChamps,
                                IElementAEvenementsDefinis,
								IElementATypeStructurant<CTypeTicket>
	{
        public const string c_nomTiag = "Ticket";
        public const string c_nomTable = "TICKET";

		public const string c_champId = "TICKET_ID";

		public const string c_champDescription = "TKT_DESCRIPTION";
		public const string c_champDateOuverture = "TKT_OPENING_DATE";
		public const string c_champDateCloture = "TKT_CLOSING_DATE";
		public const string c_champDateClotureTechnique = "TKT_TECH_CLOSING_DATE";
        public const string c_champInfosCloture = "TKT_CLOSING_INFOS";
        public const string c_champNumero = "TKT_NUMBER";
		public const string c_champMessageAffectation = "TKT_AFFECTATION_MESSAGE";
        public const string c_champIdAuteur = "TKT_AUTHOR_ID";
        public const string c_champIdResponsable = "TKT_USER_IN_CHARGE_ID";
        public const string c_champIdActeurClotureTech = "TKT_ACT_TECH_CLO_ID";
        
		public const string c_champEtat = "TKT_STATE";
        public const string c_champEstEnPause = "TKT_IS_IN_PAUSE";

		public const string c_roleChampCustom = "TICKET";

		/// /////////////////////////////////////////////
		public CTicket(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTicket(DataRow row)
			: base(row)
		{
		}

		//-------------------------------------------------------------------
		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Ticket", typeof(CTicket), typeof(CTypeTicket), typeof(COrigineTicket));
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
				return I.T( "Ticket @1|222", Numero);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
			DateOuverture = DateTime.Now;
			// A la création du ticket la date de cloture est initialisée à une 
			// valeur antérieur à la date d'ouverture car le ticket est Ouvert

			Auteur = CUtilSession.GetUserForSession(this.ContexteDonnee);
            Responsable = Auteur;
            Numero = GetNewTikcetNumber();
            
            // Le ticket est ouvert par défaut
            Row[c_champEtat] = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champDateOuverture };
		}

		/// <summary>
		/// Verifi si le ticket passé est esclave de ce ticket directement ou indirectement
		/// </summary>
		/// <param name="ticket"></param>
		/// <returns></returns>
		public bool IsMaitre(CTicket ticket)
		{
			foreach (CDependanceTicket dep in RelationsEsclavesListe)
			{
				if (dep.TicketEsclave.Equals(ticket))
					return true;
				else
					return dep.TicketEsclave.IsMaitre(ticket);
			}
			return false;
		}

        //--------------------------------------------------------------------------------
        /// <summary>
        /// Si plusieurs Site sont liés au Ticket, le premier de la liste est considéré comme site Principal.
        /// </summary>
		[DynamicField("Main site")]
		[OptimiseReadDependance("RelationsSitesListe.Site")]
		public CSite SitePrincipal
		{
			get
			{
				CListeObjetsDonnees lstSites = RelationsSitesListe;
				lstSites.Tri = CRelationTicket_Site.c_champOrdreSite;
				if (lstSites.Count == 0)
					return null;
				else
				{
					CRelationTicket_Site rel = (CRelationTicket_Site) lstSites[0];
					return (CSite)rel.Site;
				}
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
        /// Donne l'historique du ticket qui récapitule les étapes importantes de la vie du ticket :<br/>
        /// <ul>
        /// <li>La date d'ouverture du ticket</li>
        /// <li>La date de création de chacune des phases</li>
        /// <li>La date de démarrage de chacune des phases</li>
        /// <li>La date de fin de chacune des phases</li>
        /// <li>La date de clôture du ticket</li>
        /// </ul>
        /// Pour chacune des entrées de l'historique, le système enregistre :<br/>
        /// <ul>
        /// <li>La date</li>
        /// <li>La nature de l'événement</li>
        /// <li>Le nom de la phase concernée</li>
        /// <li>Le nom de l'utilisateur qui a effectué l'opération</li>
        /// </ul>
        /// L'historique est mis à jour automatiquement après chaque création,<br/>
        /// démarrage ou fermeture de phase ou clôture du ticket.
		/// </summary>
		[RelationFille(typeof(CHistoriqueTicket), "Ticket")]
		[DynamicChilds("History", typeof(CHistoriqueTicket))]
		public CListeObjetsDonnees HistoriquesTicket
		{
			get 
            {
                return GetDependancesListe(CHistoriqueTicket.c_nomTable, c_champId); 
            }
		}


        public void TiagSetAuteurKeys(object[] lstCles)
		{
            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(ContexteDonnee);
            if (user.ReadIfExists(lstCles))
                Auteur = user;
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// L'Auteur est l'utilisateur de l'application qui a créé le Ticket
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
            CTicket.c_champIdAuteur,
			true,
			false,
			false)]
		[DynamicField("Author")]
        [TiagRelation(typeof(CDonneesActeurUtilisateur), "TiagSetAuteurKeys")]
		public CDonneesActeurUtilisateur Auteur
		{
			get
			{
                return (CDonneesActeurUtilisateur)GetParent(CTicket.c_champIdAuteur, typeof(CDonneesActeurUtilisateur));
			}
			set
			{
                SetParent(CTicket.c_champIdAuteur, value);
			}
		}


        public void TiagSetClientKeys(object[] lstCles)
        {
            CDonneesActeurClient client = new CDonneesActeurClient(ContexteDonnee);
            if (client.ReadIfExists(lstCles))
                Client = client;
        }
        //-------------------------------------------------------------------------------------
		/// <summary>
		/// Le Client pour le compte de qui le Ticket est ouvert. Si un seul Client est enregistré 
        /// dans la base, celui-ci sera sélectionné par défaut
		/// </summary>
		[Relation(
			CDonneesActeurClient.c_nomTable,
			CDonneesActeurClient.c_champId,
			CDonneesActeurClient.c_champId,
			true,
			false,
			false)]
		[DynamicField("Customer")]
        [TiagRelation(typeof(CDonneesActeurClient), "TiagSetClientKeys")]
		public CDonneesActeurClient Client
		{
			get
			{
				return (CDonneesActeurClient)GetParent(CDonneesActeurClient.c_champId, typeof(CDonneesActeurClient));
			}
			set
			{
				SetParent(CDonneesActeurClient.c_champId, value);
			}
		}


		//---------------------------------------------------------------------------
		/// <summary>
		/// Description générale du ticket: C'est un champ texte qui sert à renseigner sur la nature de l'incident 
        /// ou la raison pour laquelle le Ticket a été ouvert, ou tout autre information.<br/>
        /// Ce champ est limité à 2000 caractères maximum.
		/// </summary>
		[TableFieldProperty(c_champDescription, 2000)]
		[DynamicField("General description")]
        [TiagField("General description")]
		public string DescriptionGenerale
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


		//-----------------------------------------------------------------------------
		/// <summary>
		/// Date et heure d'ouverture du ticket. Initialisé automatique à la date et heure actuelle 
        /// à l'ouverture du Ticket
		/// </summary>
		[TableFieldProperty(c_champDateOuverture)]
		[DynamicField("Opening date")]
        [TiagField("Opening date")]
		public DateTime DateOuverture
		{
			get
			{
				return (DateTime)Row[c_champDateOuverture];
			}
			set
			{
				Row[c_champDateOuverture] = value;
			}
		}

        //-----------------------------------------------------------
        public string DateOuvertureToString
        {
            get
            {
                return DateOuverture.ToString("g");
            }
        }

		//-----------------------------------------------------------
		/// <summary>
		/// Date et heure de fermeture (clôture) du ticket. Ce champ est rensigné automatiquement à la clôture du Ticket
		/// </summary>
		[TableFieldProperty(c_champDateCloture, NullAutorise = true)]
		[DynamicField("Closing date")]
        [TiagField("Closing date")]
		public DateTime? DateCloture
		{
			get
			{
				return (DateTime?)Row[c_champDateCloture, true];
			}
			set
			{
				Row[c_champDateCloture, true] = value;
                if (value != null)
                    Row[c_champEtat] = true;
                else
                    Row[c_champEtat] = false;
			}
		}
        
        //-----------------------------------------------------------
        /// <summary>
        /// Renseigne sur l'état clos ou non du Ticket.<br/>
        /// Champ booléen: Ouvert = False, Clos = True
        /// </summary>
        [TableFieldProperty(c_champEtat)]
        [DynamicField("Is Closed")]
        public bool EstClos
        {
            get
            {
                return (bool)Row[c_champEtat];
            }
        }

        //-----------------------------------------------------------
        public string EtatToString
        {
            get
            {
                if (EstClos)
                    return I.T("Closed|30085");
                else
                    return I.T("Open|30084");
            }
        }

        //-----------------------------------------------------------
        public string DateClotureToString
        {
            get
            {
                if (DateCloture != null)
                {
                    DateTime date = (DateTime)DateCloture;
                    return date.ToString("g");
                }
                return "";
            }
        }

		//-----------------------------------------------------------------
		/// <summary>
		/// La date de clôture technique est la date de rétablissement de service effective.<br/>
        /// A renseigner obligatoirement avant la clôture du Ticket
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



		public void TiagSetTicketTypeKeys(object[] lstCles)
		{
			CTypeTicket typeTicket = new CTypeTicket(ContexteDonnee);
			if (typeTicket.ReadIfExists(lstCles))
				TypeTicket = typeTicket;
		}
        //-------------------------------------------------------------------
		/// <summary>
        /// Le Type de Ticket permet de définir les champs custom et formulaires associés au ticket.
		/// </summary>
		[Relation(
			CTypeTicket.c_nomTable,
			CTypeTicket.c_champId,
			CTypeTicket.c_champId,
			true,
			false,
			false)]
		[DynamicField("Ticket type")]
        [TiagRelation(typeof(CTypeTicket), "TiagSetTicketTypeKeys")]
		public CTypeTicket TypeTicket
		{
			get
			{
				return (CTypeTicket)GetParent(CTypeTicket.c_champId, typeof(CTypeTicket));
			}
			set
			{
				SetParent(CTypeTicket.c_champId, value);
			}
		}


		public void TiagSetTicketQualificationKeys(object[] lstCles)
		{
			CQualificationTicket ticketQual = new CQualificationTicket(ContexteDonnee);
			if (ticketQual.ReadIfExists(lstCles))
				Qualification = ticketQual;
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// La Qualification du ticket.<br/>
        /// 
		/// </summary>
		[Relation(
			CQualificationTicket.c_nomTable,
			CQualificationTicket.c_champId,
			CQualificationTicket.c_champId,
			false,
			false,
			false)]
		[DynamicField("Qualification")]
        [TiagRelation(typeof(CQualificationTicket), "TiagSetTicketQualificationKeys")]
		public CQualificationTicket Qualification
		{
			get
			{
				return (CQualificationTicket)GetParent(CQualificationTicket.c_champId, typeof(CQualificationTicket));
			}
			set
			{
				SetParent(CQualificationTicket.c_champId, value);
			}
		}


		public void TiagSetTicketUrgencyKeys(object[] lstCles)
		{
			CUrgenceTicket ticketUrgency = new CUrgenceTicket(ContexteDonnee);
			if (ticketUrgency.ReadIfExists(lstCles))
				Urgence = ticketUrgency;
		}
		//-------------------------------------------------------------------
		/// <summary>
        /// Donne une priorité au ticket. L'urgence a un code de priorité (entier) ordonnable
		/// </summary>
		[Relation(
			CUrgenceTicket.c_nomTable,
			CUrgenceTicket.c_champId,
			CUrgenceTicket.c_champId,
			false,
			false,
			false)]
		[DynamicField("Urgency")]
        [TiagRelation(typeof(CUrgenceTicket), "TiagSetTicketUrgencyKeys")]
		public CUrgenceTicket Urgence
		{
			get
			{
				return (CUrgenceTicket)GetParent(CUrgenceTicket.c_champId, typeof(CUrgenceTicket));
			}
			set
			{
				SetParent(CUrgenceTicket.c_champId, value);
			}
		}


        //---------------------------------------------
		/// <summary>
		/// Retourne la liste des relations vers les tickets esclaves du ticket en cours
		/// </summary>
		[RelationFille(typeof(CDependanceTicket), "TicketMaitre")]
		[DynamicChilds("Slaves Relations", typeof(CDependanceTicket))]
		public CListeObjetsDonnees RelationsEsclavesListe
		{
			get
			{
				return GetDependancesListe(CDependanceTicket.c_nomTable, CDependanceTicket.c_champMaitre);
			}
		}

		//---------------------------------------------
		/// <summary>
		/// Retourne le liste des relations vers les tickets maîtres du ticket en cours
		/// </summary>
		[RelationFille(typeof(CDependanceTicket), "TicketEsclave")]
		[DynamicChilds("Masters Relations", typeof(CDependanceTicket))]
		public CListeObjetsDonnees RelationsMaitresListe
		{
			get
			{
				return GetDependancesListe(CDependanceTicket.c_nomTable, CDependanceTicket.c_champEsclave);
			}
		}


		//---------------------------------------------
		/// <summary>
		/// Retourne la liste des phases liées au ticket
		/// </summary>
		[RelationFille(typeof(CPhaseTicket), "Ticket")]
		[DynamicChilds("Phases List", typeof(CPhaseTicket))]
        public CListeObjetsDonnees PhasesListe
		{
			get
			{
				return GetDependancesListe(CPhaseTicket.c_nomTable, c_champId);
			}
		}


		//----------------------------------------------------------------
		public CTypePhase[] GetTypesPhasesSuivantesPossibles()
		{
			CPhaseTicket phaseEnCours = PhaseEnCours;
			if (phaseEnCours == null)
			{
				if (TypeTicket != null)
					return TypeTicket.TypePhasesDemarrage;
				return null;
			}
			else
			{
				if (TypeTicket != null)
					foreach (CTypeTicket_TypePhase rel in TypeTicket.RelationsTypesPhases)
						if (rel.TypePhase == phaseEnCours.TypePhase)
							return rel.GetTypesPhasesSuivantesPossibles(phaseEnCours);
				return null;
			}
		}



		public void TiagSetTicketOriginKeys(object[] lstCles)
		{
			COrigineTicket origine = new COrigineTicket(ContexteDonnee);
			if (origine.ReadIfExists(lstCles))
				OrigineTicket = origine;
		}
		//-------------------------------------------------------------------
		/// <summary>
        /// Donne ou définit l'Origine du Ticket.
		/// </summary>
		[Relation(
			COrigineTicket.c_nomTable,
			COrigineTicket.c_champId,
			COrigineTicket.c_champId,
			false,
			false,
			false)]
		[DynamicField("Ticket origin")]
        [TiagRelation(typeof(COrigineTicket), "TiagSetTicketOriginKeys")]
		public COrigineTicket OrigineTicket
		{
			get
			{
				return (COrigineTicket)GetParent(COrigineTicket.c_champId, typeof(COrigineTicket));
			}
			set
			{
				SetParent(COrigineTicket.c_champId, value);
			}
		}


		public void TiagSetClosingStateKeys(object[] lstCles)
		{
			CEtatCloture etat = new CEtatCloture(ContexteDonnee);
			if (etat.ReadIfExists(lstCles))
				EtatCloture = etat;
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'Etat de la clôture du ticket. 
		/// </summary>
		[Relation(
			CEtatCloture.c_nomTable,
			CEtatCloture.c_champId,
			CEtatCloture.c_champId,
			false,
			false,
			false)]
		[DynamicField("Closing state")]
        [TiagRelation(typeof(CEtatCloture), "TiagSetClosingStateKeys")]
		public CEtatCloture EtatCloture
		{
			get
			{
				return (CEtatCloture)GetParent(CEtatCloture.c_champId, typeof(CEtatCloture));
			}
			set
			{
				SetParent(CEtatCloture.c_champId, value);
			}
		}

        

		//------------------------------------------------------------------
        /// <summary>
        /// Numéro du Ticket.<br/>
        /// Ce numéro est attribué automatiquement; c'est un nombre entier à 6 chiffres
        /// </summary>
		[DynamicField("Number")]
		[RechercheRapide()]
		[TableFieldProperty(c_champNumero, 100)]
        [TiagField("Number")]
		public string Numero
		{
			get
			{
				return (string)Row[c_champNumero];
			}
			set
			{
				Row[c_champNumero] = value;
			}
		}

        
		public void TiagSetContractKeys(object[] lstCles)
		{
			CContrat contrat = new CContrat(ContexteDonnee);
			if (contrat.ReadIfExists(lstCles))
				Contrat = contrat;
		}
		//-------------------------------------------------------------------
		/// <summary>
		/// Donne ou définit le contrat concerné par le ticket.<br/>
        /// Ce contrat est lié au client. Le client peut avoir plusieurs contrats de définis.<br/>
        /// Si un seul contrat est enregistré celui-ci sera sélectionné automatiquement.
		/// </summary>
		[Relation(
			CContrat.c_nomTable,
			CContrat.c_champId,
			CContrat.c_champId,
			true,
			false,
			false)]
		[DynamicField("Contract")]
        [TiagRelation(typeof(CContrat), "TiagSetContractKeys")]
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


		public void TiagSetResponsableKeys(object[] lstCles)
		{
			CDonneesActeurUtilisateur responsable = new CDonneesActeurUtilisateur(ContexteDonnee);
			if (responsable.ReadIfExists(lstCles))
				Responsable = responsable;
		}
		//-------------------------------------------------------------------
		/// <summary>
        /// Donne ou définit l'Utilisateur de l'application auquel le Ticket est affecté.<br/>
        /// Un ticket est toujours affecté à un utilisateur. 
        /// Pour affecter le Ticket à un autre utilisateur que celui qui a créé le ticket,<br/>
        /// il faut faire appel à un <see cref="CProcess">processus ou action</see> dans l'Application
		/// </summary>
		[Relation(
			CDonneesActeurUtilisateur.c_nomTable,
			CDonneesActeurUtilisateur.c_champId,
            CTicket.c_champIdResponsable,
			true,
			false,
			false)]
		[DynamicField("User in charge")]
        [TiagRelation(typeof(CDonneesActeurUtilisateur), "TiagSetResponsableKeys")]
		public CDonneesActeurUtilisateur Responsable
		{
			get
			{
				return (CDonneesActeurUtilisateur)GetParent(
                    CTicket.c_champIdResponsable,
					typeof(CDonneesActeurUtilisateur));
			}
			set
			{
                SetParent(CTicket.c_champIdResponsable, value);
			}
		}


		public void TiagSetResponsableClotureKeys(object[] lstCles)
		{
			CActeur respCloture = new CActeur(ContexteDonnee);
			if (respCloture.ReadIfExists(lstCles))
				ResponsableClotureTechnique = respCloture;
		}
        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Responsable de la clôture technique du ticket.<br/>
        /// La clôture technique correspond au rétablissement du service.<br/>
        /// Ce responsable peut être n'importe quel acteur, par exemple<br/> 
        /// un technicien ou toute autre personne enregistrée dans l'application
        /// </summary>
        [Relation(
            CActeur.c_nomTable,
            CActeur.c_champId,
            CTicket.c_champIdActeurClotureTech,
            false,
            false,
            false)]
        [DynamicField("Member responsible for Technical closing")]
        [TiagRelation(typeof(CActeur), "TiagSetResponsableClotureKeys")]
        public CActeur ResponsableClotureTechnique
        {
            get
            {
                return (CActeur)GetParent(
                    CTicket.c_champIdActeurClotureTech,
                    typeof(CActeur));
            }
            set
            {
                SetParent(CTicket.c_champIdActeurClotureTech, value);
            }
        }

        
		//------------------------------------------------------------*
		/// <summary>
		/// Donne ou définit l'Information de clôture du ticket.<br/>
        /// Il s'agit d'un champ texte de 400 caractères maximum<br/>
        /// que l'utilisateur peut rensseigner au moment de la clôture du Ticket
		/// </summary>
		[TableFieldProperty ( c_champInfosCloture, 400 )]
		[DynamicField("Closing info")]
        [TiagField("Closing info")]
		public string InfosCloture
		{
			get
			{
				return (string)Row[c_champInfosCloture];
			}
			set
			{
				Row[c_champInfosCloture] = value;
			}
		}
	

		//-----------------------------------------------------------
		/// <summary>
		/// Le Message transmis d'un Acteur à l'autre lors de l'affectation de la phase 
        /// Ce champ n'est pas utilisé actuellement dans l'application
		/// </summary>
		[TableFieldProperty(c_champMessageAffectation, 128)]
		//[DynamicField("Affectation message")]
		public string MessageAffectation
		{
			get
			{
				return (string)Row[c_champMessageAffectation];
			}
			set
			{
				Row[c_champMessageAffectation] = value;
			}
		}


		//----------------------------------------------------------------------------
		/// <summary>
		/// Retourne la phase en cours du ticket.<br/>
        /// Un Ticket ne peut avoir qu'une seule phase en cours (obligatoire)
		/// </summary>
		/// <returns></returns>
		[DynamicField("Current Phase")]
		public CPhaseTicket PhaseEnCours
		{
			get
			{
				CListeObjetsDonnees listePhases = PhasesListe;
				listePhases.Tri = CPhaseTicket.c_champDateCreation + " desc";

				if (listePhases.Count != 0)
					return (CPhaseTicket)listePhases[0];

				return null;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Clos la phase en cours et créer une nouvelle phase du type spécifié
		/// </summary>
		/// <param name="typePhase"></param>
		/// <returns></returns>
		public CResultAErreur StartPhaseSuivante(CTypePhase typePhase)
		{
			CResultAErreur result = CResultAErreur.True;
             
            if (typePhase == null)
				return CResultAErreur.False;

			CPhaseTicket phaseEnCours = this.PhaseEnCours;

            if (phaseEnCours != null)
            {
                if (phaseEnCours.EstGelee)
                {
                    result.EmpileErreur(I.T("The current phase is frrozen|30076"));
                    return result;
                }
                if (!phaseEnCours.EvaluerConditionDeSortie())
                {
                    result.EmpileErreur(I.T("The phase exit condition is not valid|30077"));
                    return result;
                }

                if (phaseEnCours.DateDebut == null)
                    phaseEnCours.DateDebut = DateTime.Now;
                phaseEnCours.DateFin = DateTime.Now;
            }
			CPhaseTicket phaseSuivante = new CPhaseTicket(this.ContexteDonnee);
			phaseSuivante.CreateNewInCurrentContexte();
			phaseSuivante.Ticket = this;
			phaseSuivante.TypePhase = typePhase;

			return result;
		}

		//--------------------------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste des relations du ticket avec les <see cref="CSite">Sites</see> qui le concernent
		/// </summary>
		[RelationFille(typeof(CRelationTicket_Site), "Ticket")]
		[DynamicChilds("Related sites relations", typeof(CRelationTicket_Site))]
		public CListeObjetsDonnees RelationsSitesListe
		{
			get
			{
				return GetDependancesListe(CRelationTicket_Site.c_nomTable, c_champId);
			}
		}


		//--------------------------------------------------------------------------------------
		/// <summary>
        /// Retourne la liste des relations du ticket avec les <see cref="CEntiteOrganisationnelle">Entités Organisationnelles</see> qui le concernent
		/// </summary>
		[RelationFille(typeof(CRelationTicket_EOconcernees), "Ticket")]
		[DynamicChilds("Related OE relations", typeof(CRelationTicket_EOconcernees))]
		public CListeObjetsDonnees RelationsEOconcernees
		{
			get
			{
				return GetDependancesListe(CRelationTicket_EOconcernees.c_nomTable, c_champId);
			}
		}

		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationTicket_ChampCustomValeur(ContexteDonnee);
		}

		//----------------------------------------------------
		public string GetNomTableRelationToChamps()
		{
			return CRelationTicket_ChampCustomValeur.c_nomTable;
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

		//----------------------------------------------------------------------------------
		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				ArrayList definisseurs = new ArrayList();
				if (TypeTicket != null)
					definisseurs.Add(TypeTicket);
				if (OrigineTicket != null)
					definisseurs.Add(OrigineTicket);

				return (IDefinisseurChampCustom[])definisseurs.ToArray(typeof(IDefinisseurChampCustom));
			}
		}

		//----------------------------------------------------------------------------------
		public CChampCustom[] GetChampsHorsFormulaire()
		{
			ArrayList lst = new ArrayList();
			if (TypeTicket != null)
			{
				foreach (CRelationTypeTicket_ChampCustom rel in TypeTicket.RelationsChampsCustomDefinis)
					lst.Add(rel.ChampCustom);

				foreach (CRelationTypeTicket_Formulaire rel1 in TypeTicket.RelationsFormulaires)
					if (rel1.Formulaire != null)
						foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
							lst.Remove(rel2.Champ);
			}
			if (OrigineTicket != null)
			{
				if (OrigineTicket.Formulaire != null)
					foreach (CRelationFormulaireChampCustom rel in OrigineTicket.Formulaire.RelationsChamps)
						lst.Remove(rel.Champ);
			}

			return (CChampCustom[])lst.ToArray(typeof(CChampCustom));

		}

		//-------------------------------------------------------------------------------------
		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
			/*ArrayList lst = new ArrayList();
			if (TypeTicket != null)
			{
				foreach (CRelationTypeTicket_Formulaire rel in TypeTicket.RelationsFormulaires)
					lst.Add(rel.Formulaire);
			}
			//if (OrigineTicket != null)
			//{
			//    lst.Add(OrigineTicket.Formulaire);
			//}
			return (CFormulaire[])lst.ToArray(typeof(CFormulaire));*/
		}

		//-----------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations du ticket avec les valeurs de champs personnalisés qui le concernent
        /// </summary>
		[RelationFille(typeof(CRelationTicket_ChampCustomValeur), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationTicket_ChampCustomValeur))]
		public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationTicket_ChampCustomValeur.c_nomTable, c_champId);
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


        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne un nouveau numéro de Ticket. Cette fonction est utile lors de la création d'un Ticket par process
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns a new Ticket number")]
        public string GetNewTikcetNumber()
        {
            int num = ((ITicketServeur) GetLoader()).GetNewTicketNumber();

            return num.ToString("000000");
        }

        //------------------------------------------------------------------------------------
        /// <summary>
        /// Crée un enregistrement dans l'historique du ticket.
        /// </summary>
        /// <param name="phase">Phase courante</param>
        /// <param name="info">Informations</param>
        /// <returns>Résultat à erreur</returns>
        [DynamicMethod(
            "Creates a line in the ticket history with the date, the user and the current phase",
            "Information text to store in history")]
        public CResultAErreur CreerHistorique(CPhaseTicket phase, string info)
        {
            CResultAErreur result = CResultAErreur.True;

            CHistoriqueTicket histo = new CHistoriqueTicket(this.ContexteDonnee);
            histo.CreateNewInCurrentContexte();
            histo.Date = DateTime.Now;
            histo.Ticket = this;
            if (phase != null)
                histo.PhaseTicket = phase;
            else
                histo.PhaseTicket = PhaseEnCours;
            histo.ActeurUtilisateur = CUtilSession.GetUserForSession(this.ContexteDonnee);
            histo.Info = info;

            return result;
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Effectue la clôture administrative du ticket et de tous ses tickets esclaves<br/>
        /// pour lesquels l'option de clôture est 'Automatique'
        /// </summary>
        /// <param name="dateCloture">Date de la clôture</param>
        /// <returns>Résultat à erreur</returns>
        [DynamicMethod(
            "Set the administrative closing of the ticket and of all the slave tickets having an automatic closure option",
            "Administrative closing date")]
        public CResultAErreur Close(DateTime dateCloture)
        {
            CResultAErreur result = CResultAErreur.True;

            // CLore le Ticket
            this.DateCloture = dateCloture;

            // Clore les Tickets Esclaves
            foreach (CDependanceTicket rel in this.RelationsEsclavesListe)
            {
                if (rel.ClotureAutoEscalve)
                {
                    CTicket ticketEscalve = rel.TicketEsclave;
                    if (ticketEscalve != null)
                    {
                        ticketEscalve.DateClotureTechnique = this.DateClotureTechnique;
                        ticketEscalve.ResponsableClotureTechnique = this.ResponsableClotureTechnique;
                        ticketEscalve.EtatCloture = this.EtatCloture;
                        ticketEscalve.InfosCloture = this.InfosCloture;
                        result = ticketEscalve.Close(dateCloture);
                    }
                }
            }

            return result;
        }

        //-----------------------------------------------------------
        /// <summary>
        /// Indique si le ticket est en pause. Cette fonction permet à l’utilisateur de mettre en veille 
        /// le ticket pour faire autre chose, mais de ne pas l’oublier.<br/>
        /// Champ booléen: Le champs est à "vrai" si le ticket est en pause
        /// </summary>
        [TableFieldProperty(c_champEstEnPause)]
        [DynamicField("Is in pause")]
        [TiagField("Is in pause")]
        public bool EstEnPause
        {
            get
            {
                return (bool)Row[c_champEstEnPause];
            }
            set
            {
                Row[c_champEstEnPause] = value;
            }
        }


        


        #region IElementAEvenementsDefinis Membres

        //------------------------------------------------------------------------
        public IDefinisseurEvenements[] Definisseurs
        {
            get
            {
                if (TypeTicket == null)
                    return new IDefinisseurEvenements[0];
                return new IDefinisseurEvenements[] { TypeTicket };
            }
        }

        //------------------------------------------------------------------------
        public bool IsDefiniPar(IDefinisseurEvenements definisseur)
        {
            if (TypeTicket == null || !(definisseur is CTypeTicket))
                return false;
            if (TypeTicket.Equals(definisseur))
                return true;
            return false;
        }


        #endregion

		#region IElementATypeStructurant<CTypeTicket> Membres

		public CTypeTicket ElementStructurant
		{
			get { return TypeTicket; }
		}

		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeTicket.c_champId];
			}
		}
		#endregion

	}

    //////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 
    /// </summary>
    public interface ITicketServeur
    {
        int GetNewTicketNumber();
    }
}
