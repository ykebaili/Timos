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
using timos.acteurs;
using sc2i.expression;

using timos.securite;
using timos.data.version;
using tiag.client;
using sc2i.process.workflow.gels;

namespace timos.data
{
	/// <summary>
    /// La r�solution d�un <see cref="CTicket">Ticket</see> est d�compos�e en phases. Les phases repr�sentent 
    /// le processus (ou workflow) du client pour arriver � la solution du probl�me. 
    /// Ce processus est d�fini par le <see cref="CTypeTicket">Type de Ticket</see>.<br/>
    /// Une phase poss�de un <see cref="CTypePhase">type de phase</see> qui lui affecte un <see cref="sc2i.data.dynamic.CFormulaire">formulaire</see> personnalis�. Elle poss�de aussi:
    /// <list type="bullet">
    /// <item><term>Un champ description (texte)</term></item>
    /// <item><term>Des interventions</term> <description> � partir de la phase on peut d�clencher une nouvelle <see cref="CIntervention">intervention</see> sur un des <see cref="CSite">sites</see> associ�s au ticket et d'un des <see cref="CTypeIntervention">types d'interventions</see> autoris�s par le type de phase.</description></item>
    /// <item><term>Des p�riodes de Gel </term> <description>La phase peut �tre gel�e avec une date de d�but et de fin de gel. Un <see cref="CGel">gel</see> doit avoir une <see cref="CCauseGel">Cause de Gel</see>.</description></item>
    /// </list><br/>
    ///Les phases sont s�quentielles. Une phase est consid�r�e comme termin�e sit�t qu�une nouvelle phase est cr��e pour le ticket.
    /// </summary>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [sc2i.doccode.DocRefRessources(CDocLabels.c_eProcessResolutionTicket)]
    [DynamicClass("Ticket phase")]
	[Table(CPhaseTicket.c_nomTable, CPhaseTicket.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CPhaseTicketServeur")]
    [AutoExec("Autoexec")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CPhaseTicket.c_nomTiag, "Id", true)]
    public class CPhaseTicket : CObjetDonneeAIdNumeriqueAuto,
								IObjetDonneeAChamps,
								IElementAContacts,
								IElementGelable,
                                IElementAEvenementsDefinis,
								IElementATypeStructurant<CTypePhase>,
                                IElementAOperationsRealisees,
                                IObjetSansVersion
	{
        public const string c_nomTiag = "Ticket Phase";
        public const string c_nomTable = "TICKET_PHASE";

		public const string c_champId = "TKT_PHASE_ID";
		public const string c_champInfosPhase = "TKT_PHASE_INFOS";
        public const string c_champDateCreation = "PHASE_CREATION_DATE";
        public const string c_champDateDebut = "PHASE_START_DATE";
        public const string c_champDateFin = "PHASE_END_DATE";
		public const string c_champEstGele = "PHASE_FROZEN";

		public const string c_roleChampCustom = "TICKET_PHASE";

		/// /////////////////////////////////////////////
		public CPhaseTicket( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CPhaseTicket(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Ticket phase", typeof(CPhaseTicket),typeof(CTypePhase));
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
                return I.T("Phase @1 of Ticket No. @2|450", Libelle, (Ticket != null ? Ticket.Numero : ""));
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            DateCreation = DateTime.Now;
            DateDebut = null;
            DateFin = null;
            Row[c_champEstGele] = false;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateCreation };
		}
		

        //-----------------------------------------------------------
        /// <summary>
        /// Date de cr�ation de la phase : date et heure � laquelle la phase a �t� cr��e.
        /// </summary>
        [TableFieldProperty(c_champDateCreation)]
        [DynamicField("Creation date")]
        [TiagField("Creation date")]
        public DateTime DateCreation
        {
            get
            {
                return (DateTime)Row[c_champDateCreation];
            }
            set
            {
                Row[c_champDateCreation] = value;
            }
        }

        //-----------------------------------------------------------
        public string DateCreationToString
        {
            get
            {
                return DateCreation.ToString("g");
            }
        }



        //-----------------------------------------------------------
        /// <summary>
        ///	Date d�ouverture : Date et heure � laquelle la phase a commenc� � �tre trait�e. 
        /// En pratique d�s qu'un champ de la phase est modifi�.
        /// </summary>
        [TableFieldProperty(c_champDateDebut, NullAutorise = true)]
        [DynamicField("Start date")]
        [TiagField("Start date")]
        public DateTime? DateDebut
        {
            get
            {
                return (DateTime?)Row[c_champDateDebut, true];
            }
            set
            {
                Row[c_champDateDebut, true] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Date de fermeture : date et heure � laquelle la phase s�est termin�e
        /// </summary>
        [TableFieldProperty(c_champDateFin, NullAutorise = true)]
        [DynamicField("End date")]
        [TiagField("End date")]
        public DateTime? DateFin
        {
            get
            {
                return (DateTime?)Row[c_champDateFin, true];
            }
            set
            {
                Row[c_champDateFin, true] = value;
            }
        }


        public void TiagSetTicketKeys(object[] lstCles)
        {
            CTicket ticket = new CTicket(ContexteDonnee);
            if (ticket.ReadIfExists(lstCles))
                Ticket = ticket;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Ticket auquel la Phase est attach�e
        /// </summary>
        [Relation(
            CTicket.c_nomTable,
            CTicket.c_champId,
            CTicket.c_champId,
            true,
            true,
            false)]
        [DynamicField("Ticket")]
        [TiagRelation(typeof(CTicket), "TiagSetTicketKeys")]
        public CTicket Ticket
        {
            get
            {
                return (CTicket)GetParent(CTicket.c_champId, typeof(CTicket));
            }
            set
            {
                SetParent(CTicket.c_champId, value);
            }
        }


        //---------------------------------------------------------------------
        /// <summary>
        /// Liste des Interventions attach�es � la Phase
        /// </summary>
        [RelationFille(typeof(CIntervention), "PhaseTicket")]
        [DynamicChilds("Interventions", typeof(CIntervention))]
        public CListeObjetsDonnees InterventionsListe
        {
            get
            {
                return GetDependancesListe(CIntervention.c_nomTable, c_champId);
            }
        }



        public void TiagSetTypePhaseKeys(object[] lstCles)
        {
            CTypePhase typePhase = new CTypePhase(ContexteDonnee);
            if (typePhase.ReadIfExists(lstCles))
                TypePhase = typePhase;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Type de la phase : une phase poss�de un type de phase qui lui donne un formulaire personnalis�
        /// </summary>
        [Relation(
            CTypePhase.c_nomTable,
            CTypePhase.c_champId,
            CTypePhase.c_champId,
            true,
            false,
            false)]
        [DynamicField("Phase type")]
        [TiagRelation(typeof(CTypePhase), "TiagSetTypePhaseKeys")]
        public CTypePhase TypePhase
        {
            get
            {
                return (CTypePhase)GetParent(CTypePhase.c_champId, typeof(CTypePhase));
            }
            set
            {
                SetParent(CTypePhase.c_champId, value);
            }
        }

        //-------------------------------------------------------------------------------------
        public string DateDebutToString
        {
            get 
            {
                if (DateDebut != null)
                    return ((DateTime)DateDebut).ToString("g");
               return I.T("Phase not started|30072");
            }
        }

        //-------------------------------------------------------------------------------------
        public string DateFinToString
        {
            get
            {
                if (DateFin != null)
                {
                    DateTime date = (DateTime)DateFin;
                    return date.ToString("g");
                }
                else
                {
                    return I.T("Phase in progress|30073");
                }
            }
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne VRAI si la phase est un point de sortie du processus de r�solution (C'est une phase Finale)
        /// </summary>
        /// <returns>True si phase finale, False dans le cas contraire</returns>
        /// 
        [DynamicMethod(" Returns true if the phase is an exit point of the resulution process (if it is an end phase)")]
        public bool IsPointSortie()
        {
            if (this.TypePhase != null && this.Ticket != null && this.Ticket.TypeTicket != null)
            {
                foreach (CTypePhase tp in this.Ticket.TypeTicket.TypePhasesFin)
                {
                    if (tp == this.TypePhase)
                        return true;
                }
            }
            return false;
        }

        //-------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne VRAI si la phase est un point d'entr�e du processus de r�solution (C'est une phase de D�marrage)
        /// </summary>
        /// <returns>True si phase de d�marrage, False dans le cas contraire</returns>
        [DynamicMethod("Returns true if the phase is an entry point of the resulution process (if it is a start phase)")]
        public bool IsPointEntree()
        {
            if (this.TypePhase != null && this.Ticket != null && this.Ticket.TypeTicket != null)
            {
                foreach (CTypePhase tp in this.Ticket.TypeTicket.TypePhasesDemarrage)
                {
                    if (tp == this.TypePhase)
                        return true;
                }
            }
            return false;
        }


        //--------------------------------------------------------------------------
        /// <summary>
        /// Le libell� de la Phase
        /// </summary>
        [DynamicField("Label")]
        [DescriptionField]
        public string Libelle
        {
            get
            {
                if (TypePhase != null)
                {
                    string libelle = TypePhase.Libelle;
                    if (this.EstGelee)
                        libelle += " (Gel�e)";
                    return libelle;
                }
                else
                    return "";
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des Notes saisies sur la Phase
        /// </summary>
        [RelationFille(typeof(CNotePhase), "PhaseTicket")]
        [DynamicChilds("Phase notes", typeof(CNotePhase))]
        public CListeObjetsDonnees NotesPhase
        {
            get
            {
                return GetDependancesListe(CNotePhase.c_nomTable, c_champId);
            }
        }

        #region IObjetDonneeAChamps Membres

        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationPhase_ChampCustomValeur(ContexteDonnee);
        }

        public string GetNomTableRelationToChamps()
        {
            return CRelationPhase_ChampCustomValeur.c_nomTable;
        }

        public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
        {
            CListeObjetsDonnees liste = RelationsChampsCustom;
            liste.InterditLectureInDB = true;
            liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
            return liste;
        }

        #endregion

        #region IElementAChamps Membres

        public IDefinisseurChampCustom[] DefinisseursDeChamps
        {
            get
            {
                ArrayList definisseurs = new ArrayList();
                if (TypePhase != null)
                    definisseurs.Add(TypePhase);

                return (IDefinisseurChampCustom[])definisseurs.ToArray();
            }
        }

        public CChampCustom[] GetChampsHorsFormulaire()
        {
            // Il n'y a pas de champs hors formulaire sur la Phase
            return new CChampCustom[0];
        }

        public CFormulaire[] GetFormulaires()
        {
            ArrayList lst = new ArrayList();

            if (TypePhase != null)
            {
                lst.Add(TypePhase.Formulaire);
            }
            return (CFormulaire[])lst.ToArray(typeof(CFormulaire));
        }

        /// <summary>
        /// Donne la liste des relations entre la phase et les valeurs de champs personnalis�s
        /// </summary>
        [RelationFille(typeof(CRelationPhase_ChampCustomValeur), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationPhase_ChampCustomValeur))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationPhase_ChampCustomValeur.c_nomTable, c_champId);
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
        
		#region IElementGelable Membres

		//---------------------------------------------
        /// <summary>
        /// Donne la liste des gels de la phase
        /// </summary>
        [RelationFille(typeof(CGel), "PhaseTicket")]
        [DynamicChilds("Freeze list", typeof(CGel))]
        public CListeObjetsDonnees Gels
        {
            get
            {
                return GetDependancesListe(CGel.c_nomTable, c_champId);
            }
        }

		//---------------------------------------------
        /// <summary>
        /// Bool�en indiquant si la phase est en cours de gel ou non
        /// </summary>
        [TableFieldProperty ( CPhaseTicket.c_champEstGele )]
		[DynamicField("Is frozen")]
		public bool EstGelee
		{
			get
			{
				return (bool)Row[c_champEstGele];
			}
		}

		/// <summary>
		/// Permet de Geler la phase
		/// </summary>
		/// <param name="dateTime">Date de d�but du gel</param>
		/// <param name="cCauseGel">Cause du gel</param>
		/// <param name="p">Informations sur le gel</param>
		/// <param name="cDonneesActeurUtilisateur">Utilisateur ayant effectu� le gel</param>
		/// <returns>R�sultat � erreur</returns>
		[DynamicMethod("Freezes the phase",
			"Freezing start date",
			"Freezing cause",
			"Freezing informations")]
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
        /// Permet de d�geler la phase
        /// </summary>
        /// <param name="dateFin">Date de fin du gel</param>
        /// <param name="strInfoFin">Informations concernant la fin du gel</param>
        /// <returns>R�sultat � erreur</returns>
		[DynamicMethod("Unfrezzes the phase",
			"Freezing end date",
			"Freezing informations")]
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


		//----------------------------------------------------------
        /// <summary>
        /// Recalcul automatique de l'�tat de gel
        /// </summary>
		[DynamicMethod("Automatically recalculates freezing state")]
		public void RecalculeEtatGel()
		{
			Row[c_champEstGele] = SElementGelable.CalculeEtatGel(this);
		}

		#endregion

        //------------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne VRAI si la condition de sortie (ou de cl�ture) de la phase est respect�e
        /// </summary>
        /// <returns>True si la condition de sortie est respect�e, False dans le cas contraire</returns>
        [DynamicMethod("Returns true if the Phase information matches the closing condition")]
        public bool EvaluerConditionDeSortie()
        {
            CContexteEvaluationExpression contexte = new CContexteEvaluationExpression(this);

            if (this.TypePhase != null)
            {
                C2iExpression formule = this.TypePhase.FormuleConditionSortie;
                if (formule != null)
                {
                    CResultAErreur result = formule.Eval(contexte);
                    if (result)
                    {
                        if (result.Data is bool && (bool)result.Data ||
                             result.Data is int && (int)result.Data != 0)
                            return true;
                    }
                }
            }
            return false;
        }

        //------------------------------------------------------------------------------------------
        /// <summary>
        /// Indique si la phase peut �tre �dit�e par le Responsable du Ticket en cours: 
        /// C'est � dire si le Responsable (utilisateur de l'application) correspond au profil d�fini par le Type de Phase
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns true if the Phase can be edited")]
        public bool CanEdit()
        {
            if (TypePhase == null)
                return false;
            if (TypePhase.ProfilResponsableTicket == null)
                return true;

            if (this.Ticket != null)
            {
                CDonneesActeurUtilisateur userEnCours = CUtilSession.GetUserForSession(this.ContexteDonnee);
                if (TypePhase.ProfilResponsableTicket.IsInProfil(userEnCours, this))
                        return true;
            }

            return false;
        }

        //------------------------------------------------------------------------
        /// <summary>
        /// Donne la liste des op�rations effectu�es sur la phase
        /// </summary>
        [RelationFille(typeof(COperation), "PhaseTicket")]
        [DynamicChilds("Performed Operations", typeof(COperation))]
        public CListeObjetsDonnees Operations
        {
            get
            {
                return GetDependancesListe(COperation.c_nomTable, c_champId);
            }
        }


		#region IElementAActeursPossibles

		public ITypeElementAContacts TypeElementAContactPossible
		{
			get { return TypePhase; }
		}

		#endregion

        #region IElementAEvenementsDefinis Membres

        //------------------------------------------------------------------------
        public IDefinisseurEvenements[] Definisseurs
        {
            get
            {
                if (TypePhase == null)
                    return new IDefinisseurEvenements[0];
                return new IDefinisseurEvenements[]{TypePhase};
            }
        }

        //------------------------------------------------------------------------
        public bool IsDefiniPar(IDefinisseurEvenements definisseur)
        {
            if (TypePhase == null || !(definisseur is CTypePhase))
                return false;
            if (TypePhase.Equals(definisseur))
                return true;
            return false;
        }


        #endregion

		#region IElementATypeStructurant<CTypePhase> Membres

		public CTypePhase ElementStructurant
		{
			get { return TypePhase; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypePhase.c_champId];
			}
		}
		#endregion
	}
}
