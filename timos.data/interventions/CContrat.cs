using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;

using timos.data.preventives;
using timos.data.version;
using System.Text;
using tiag.client;
using Lys.Licence.Types;
using Lys.Applications.Timos.Smt;
using sc2i.expression;

namespace timos.data
{
	/// <summary>
    /// L'objet contrat permet de gérer un contrat de maintenance passé avec un <see cref="CDonneesActeurClient">Client</see> donné.<br/>
    /// Ce contrat peut concerner un ou plusieurs sites.<br/>
    /// Les tâches à effectuer dans le cadre de ce contrat pour ce client, sont définies par les <see cref="CTypeTicket">Types de Tickets</see><br/>.
	/// </summary>
    /// <remarks>
    /// Les contrats sont des objets typés. Le <see cref="CTypeContrat">type de contrat</see> permet de définir des informations spécifiques aux contrats de ce type sous la forme d'un formulaire personnalisé.<br/>
    /// Des listes d'<see cref="COperation">opérations</see> périodiques pouvant être effectuées dans le cadre d'un plan de maintenance préventive,<br/>
    /// peuvent être associées à un contrat.<br/>
    /// Ces listes d'opérations permettront de créer des listes d'opérations en utilisant l'objets 'Préventives'.
    /// </remarks>
	[DynamicClass("Contract")]
	[Table(CContrat.c_nomTable, CContrat.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CContratServeur")]
    [Unique(false, "This contact label already used", CContrat.c_champLibelle)]
    [AutoExec("Autoexec")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iActeur)]
    [LicenceCount(CConfigTypesTimos.c_appType_Contrat_ID)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CContrat.c_nomTiag, "Id", true)]
    public class CContrat : CObjetDonneeAIdNumeriqueAuto, 
                            IObjetALectureTableComplete,
                            IObjetDonneeAChamps,
							IElementADecoupagePourEditeurPreventive,
							IElementATypeStructurant<CTypeContrat>
	{
        public const string c_nomTable = "CONTRACT";
        public const string c_nomTiag = "Contract";
		
		public const string c_champId = "CONTRACT_ID";
		public const string c_champLibelle = "CONTRACT_LABEL";
        
        public const string c_roleChampCustom = "CONTRACT";

		//Pour designer Preventive
		public const string c_champEditeurStartDate = "CONT_PREV_STARTDATE";
		public const string c_champEditeurDateLimite = "CONT_PREV_LDATE";

		public const string c_champEditeurPeriodeCode = "CONT_PREV_PERIOD";
		public const string c_champEditeurNbPeriodes = "CONT_PREV_NBPERIOD";

		/// /////////////////////////////////////////////
		public CContrat( CContexteDonnee contexte)
			:base(contexte)
		{ 
		}
		
	    /// /////////////////////////////////////////////
		public CContrat(DataRow row )
			:base(row)
		{
		}

        //-------------------------------------------------------------------
        public static void Autoexec()
        {
            CRoleChampCustom.RegisterRole(c_roleChampCustom, "Contract", typeof(CContrat), typeof(CTypeContrat));
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
				return I.T("Contract @1|544",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}


        		

		/// <summary>
		/// Libellé du contrat (30 caractères maximum).
		/// </summary>
		[TableFieldProperty(c_champLibelle, 30)]
		[DynamicField("Label")]
        [DescriptionField]
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


        public void TiagSetTypeContratKeys(object[] lstCles)
        {
            CTypeContrat tpContrat = new CTypeContrat(ContexteDonnee);
            if (tpContrat.ReadIfExists(lstCles))
                TypeContrat = tpContrat;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Type du contrat
        /// </summary>
        [Relation(
            CTypeContrat.c_nomTable,
            CTypeContrat.c_champId,
            CTypeContrat.c_champId,
            true,
            false,
            true)]
        [DynamicField("Contract Type")]
        [TiagRelation(typeof(CTypeContrat), "TiagSetTypeContratKeys")]
        public CTypeContrat TypeContrat
        {
            get
            {
                return (CTypeContrat)GetParent(CTypeContrat.c_champId, typeof(CTypeContrat));
			}
            set
            {
                SetParent(CTypeContrat.c_champId, value);
            }
        }

        public void TiagSetClientKeys(object[] lstCles)
        {
            CDonneesActeurClient client = new CDonneesActeurClient(ContexteDonnee);
            if (client.ReadIfExists(lstCles))
                Client = client;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Acteur Client avec lequel le contrat est conclu
        /// </summary>
        [Relation(
            CDonneesActeurClient.c_nomTable,
            CDonneesActeurClient.c_champId,
            CDonneesActeurClient.c_champId,
            true,
            false,
            false)]
        [DynamicField("Client")]
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


        //-----------------------------------------------------------------------------
        /// <summary>
		/// Donne la liste des relations avec les Types de Ticket prévus dans ce Contrat
        /// </summary>
        [RelationFille(typeof(CTypeTicketContrat), "Contrat")]
        [DynamicChilds("Tickets types", typeof(CTypeTicketContrat))]
        public CListeObjetsDonnees RelationsTypesTickets
        {
            get
            {
                return GetDependancesListe(CTypeTicketContrat.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne la liste de relations vers les Sites du Contrat définis de façon manuelle (et non par Profil)
        /// </summary>
        [RelationFille(typeof(CContrat_Site), "Contrat")]
        [DynamicChilds("Sites Relations", typeof(CContrat_Site))]
        public CListeObjetsDonnees RelationsSites
        {
            get
            {
                return GetDependancesListe(CContrat_Site.c_nomTable, c_champId);
            }
        }
        
        //----------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des Sites du Contrat, qu'ils soient définis par Profil ou par une liste de relations "manuelle"
        /// </summary>
        /// <returns></returns>
        public IList<CSite> GetTousLesSitesDuContrat()
        {
            IList<CSite> listeSites = new List<CSite>();
            StringBuilder bl = new StringBuilder();
            if (this.TypeContrat != null && this.TypeContrat.GestionSitesManuel)
            {
                // Ajout des Sites par relation
                RelationsSites.ReadDependances("Site");
                foreach (CContrat_Site rel in RelationsSites)
                {
                    listeSites.Add(rel.Site);
                    bl.Append(rel.Site.Id);
                    bl.Append(",");
                }
                if (bl.Length > 0)
                    bl.Remove(bl.Length - 1, 1);
                CFiltreData filtre;
                if (bl.Length > 0)
                {
                    filtre = new CFiltreData(CSite.c_champId + " in (" + bl.ToString() + ")");
                    CListeObjetDonneeGenerique<CSite> lst = new CListeObjetDonneeGenerique<CSite>(ContexteDonnee, filtre);
                    return lst;
                }
                else
                    return new List<CSite>();
            }
            else
            {
                CProfilElement profil = ProfilSite;
                if (profil != null)
                {
                    CListeObjetsDonnees liste = profil.GetElementListForSource(this);
                    foreach (CSite site in liste)
                    {
                        listeSites.Add(site);
                    }
                }
                return listeSites;
            }
        }

        /// <summary>
        /// Retourne la liste de tous les sites couverts par le contrat,<br/>
        /// que l'association entre sites et contrat ait été faite manuellement ou par profil.
        /// </summary>
        /// <returns></returns>
        [DynamicMethod("Returns the list of related Sites of the Contract")]
        public IList<CSite> GetAllSites()
        {
            return GetTousLesSitesDuContrat();
        }

        /// <summary>
        /// Vérifie que le site est dans le contrat ou non
        /// </summary>
        /// <param name="site">Entité site</param>
        /// <returns>True si le site appartient au contrat, False dans le cas contraire</returns>
        [DynamicMethod("Checks if the specified Site is in the contract or not", "The Site")]
        public bool IsInContract(CSite site)
        {
            if (site == null)
                return false;
            foreach (CContrat_Site rel in RelationsSites)
            {
                if (rel.Site.Id == site.Id)
                    return true;
            }
            return false;

        }


        //---------------------------------------------
        /// <summary>
        /// Donne la liste des relations avec les listes d'opérations pouvant être effectuées<br/>
        /// dans le cadre d'un plan de maintenance préventive.
        /// </summary>
        [RelationFille(typeof(CContrat_ListeOperations), "Contrat")]
        [DynamicChilds("Operations Lists Relations", typeof(CContrat_ListeOperations))]
        public CListeObjetsDonnees RelationsListesOperations
        {
            get
            {
                return GetDependancesListe(CContrat_ListeOperations.c_nomTable, c_champId);
            }
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit le profil fournissant la liste des sites associés au contrat
        /// </summary>
        [Relation(
            CProfilElement.c_nomTable,
            CProfilElement.c_champId,
            CProfilElement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Site profile")]
        public CProfilElement ProfilSite
        {
            get
            {
                return (CProfilElement)GetParent(CProfilElement.c_champId, typeof(CProfilElement));
            }
            set
            {
                SetParent(CProfilElement.c_champId, value);
            }
        }

	



		#region Editeur Preventive
		public CDecoupage DecoupageEditeur
		{
			get
			{
				int periodiciteCode = PeriodiciteOperationCodePourEditeur != null ? PeriodiciteOperationCodePourEditeur.Value : (int)EEchelleTemps.Mois;
				int nbPeriode = NombreParPeriodePourEditeur != null ? NombreParPeriodePourEditeur.Value : 3;
				DateTime dtStart = DateDebutEditeur != null ? DateDebutEditeur.Value : DateTime.Now.Date;
				DateTime dtEnd = DateLimiteEditeur != null ? DateLimiteEditeur.Value : dtStart.AddYears(1);
				return new CDecoupage(dtStart, dtEnd, nbPeriode, (EEchelleTemps)periodiciteCode, true, EEchelleTemps.Jour);
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
				return (DateTime?)Row[c_champEditeurDateLimite, true];
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
				return (DateTime?)Row[c_champEditeurStartDate, true];
			}
			set
			{
				Row[c_champEditeurStartDate, true] = value;
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
				if (PeriodiciteOperationCodePourEditeur != null)
					return new CEchelleTemps((EEchelleTemps)PeriodiciteOperationCodePourEditeur);
				return null;
			}
			set
			{
				if (value != null)
					PeriodiciteOperationCodePourEditeur = value.CodeInt;
			}
		}

		[TableFieldProperty(c_champEditeurNbPeriodes, NullAutorise = true)]
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


		#region IObjetDonneeAChamps Membres

		//----------------------------------------------------
        public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
        {
            return new CRelationContrat_ChampCustom(ContexteDonnee);
        }

        //----------------------------------------------------
        public string GetNomTableRelationToChamps()
        {
            return CRelationContrat_ChampCustom.c_nomTable;
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
                return new IDefinisseurChampCustom[] { TypeContrat};
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
            CFormulaire formulaire = null;
            if (TypeContrat!= null)
                formulaire = TypeContrat.Formulaire;
            if (formulaire != null)
                return new CFormulaire[] { formulaire };
            return new CFormulaire[0];
        }

        //----------------------------------------------------
        /// <summary>
        /// Donne la liste des relations entre le contrat et les champs personnalisés
        /// </summary>
        [RelationFille(typeof(CRelationContrat_ChampCustom), "ElementAChamps")]
        [DynamicChilds("Custom fields relations", typeof(CRelationContrat_ChampCustom))]
        public CListeObjetsDonnees RelationsChampsCustom
        {
            get
            {
                return GetDependancesListe(CRelationContrat_ChampCustom.c_nomTable, c_champId);
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

		#region IElementATypeStructurant<CTypeContrat> Membres

		public CTypeContrat ElementStructurant
		{
			get { return TypeContrat; }
		}
		public int IdTypeStructurant
		{
			get
			{
				return (int)Row[CTypeContrat.c_champId];
			}
		}

		#endregion

        public CContrat_Site GetRelationSite(int nIdSite, bool bAvecCreation)
        {
            CContrat_Site ct = GetRelationSite(nIdSite);
            if (ct == null && bAvecCreation)
            {
                CSite site = new CSite(ContexteDonnee);
                if (site.ReadIfExists(nIdSite))
                {

                    ct = new CContrat_Site(ContexteDonnee);
                    ct.CreateNewInCurrentContexte();
                    ct.Site = site;
                    ct.Contrat = this;
                }
            }
            return ct;
        }



        public CContrat_Site GetRelationSite(int nIdSite)
        {
            CListeObjetsDonnees lst = RelationsSites;
            lst.Filtre = new CFiltreData(CSite.c_champId + "=@1", nIdSite);
            if (lst.Count > 0)
                return (CContrat_Site)lst[0];
            return null;
        }
    }
}
