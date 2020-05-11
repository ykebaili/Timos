using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

using timos.data;
using tiag.client;
using System.Collections.Generic;
using timos.data.sites.releve;

namespace timos.data
{
	/// <summary>
	/// Relevé d'un site, permet de comparer les éléments réellement présents sur
    /// site avec les éléments contenus dans la base Timos
	/// </summary>
    [DynamicClass("Site survey")]
	[Table(CReleveSite.c_nomTable, CReleveSite.c_champId, true )]
	[ObjetServeurURI("CReleveSiteServeur")]
	[TiagClass(CReleveSite.c_nomTiag, "Id", true)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModuleReleveSite)]
	public class CReleveSite : CObjetDonneeAIdNumeriqueAuto,
		IElementAInterfaceTiag,
        IObjetSansVersion
	{
		public const string c_nomTiag = "Site survey";
		public const string c_nomTable = "SITE_SURVEY";
		public const string c_champId = "SITSUR_ID";
		public const string c_champDate = "SITSUR_DATE";
        public const string c_champEtatApplication = "SIRSUR_STATE";

		/// /////////////////////////////////////////////
		public CReleveSite( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	/// /////////////////////////////////////////////
		public CReleveSite(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Site @1 survey (@2)|20203",
                    Site != null?Site.Libelle:"?",
                    DateReleve.ToString("s") );
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
            CodeEtatExecution = (int)EEtatExecutionReleve.NonEvalué;
            DateReleve = DateTime.Now;
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDate};
		}



        /// /////////////////////////////////////////////
		/// <summary>
		/// Date du relevé
		/// </summary>
		[TableFieldProperty(c_champDate)]
		[DynamicField("Survey date")]
		[TiagField("Survey date")]
		public DateTime DateReleve
		{
			get
			{
				return (DateTime)Row[c_champDate];
			}
			set
			{
				Row[c_champDate] = value;
			}
		}

        /// /////////////////////////////////////////////
        /// <summary>
        /// Indique le code de l'état d'execution (application) de ce relevé sur 
        /// la base Timos
        /// </summary>
        /// <remarks>
        /// L'état d'execution varie en fonction de ce qui a été réalisé sur
        /// le relevé<BR>
        /// Les valeurs possibles sont  :<BR/>
        /// <LI>0 : Non évalué <I><BR/>Le système n'a pas évalué l'état d'execution de ce relevé</I></LI>
        /// <LI>10 : A valider <BR><I>Il reste des éléments non validés pour pouvoir executer ce relevé</I></LI>
        /// <LI>20 : A executer<BR><I>Tous les éléments ont été validés, le relevé est prêt pour l'execution</I></LI>
        /// <LI>30 : Executé<BR><I>Tous les éléments ont été appliqués sur la base Timos</I></LI>
        /// <LI>40 : Annulé<BR><I>Le relevé a été noté comme "Annulé" et ne sera pas appliqué</I></LI>
        /// </remarks>
        [TableFieldProperty(c_champEtatApplication)]
        [DynamicField("Execution state code")]
        public int CodeEtatExecution
        {
            get
            {
                return (int)Row[c_champEtatApplication];
            }
            set
            {
                Row[c_champEtatApplication] = value;
            }
        }


        /// /////////////////////////////////////////////
        /// <summary>
        /// Etat d'execution de ce relevé sur la base Timos
        /// </summary>
        [DynamicField("Execution state")]
        public CEtatExecutionReleve EtatExecution
        {
            get
            {
                return new CEtatExecutionReleve((EEtatExecutionReleve)CodeEtatExecution);
            }
            set
            {
                if (value != null)
                    CodeEtatExecution = value.CodeInt;
            }
        }

        /// /////////////////////////////////////////////
        //-------------------------------------------------------------------
        /// <summary>
        /// Site relevé
        /// </summary>
        [Relation(
            CSite.c_nomTable,
            CSite.c_champId,
            CSite.c_champId,
            true,
            true,
            false)]
        [DynamicField("Site")]
        public CSite Site
        {
            get
            {
                return (CSite)GetParent(CSite.c_champId, typeof(CSite));
            }
            set
            {
                SetParent(CSite.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Version de donnée dans laquelle le relevé a été appliqué.
        /// </summary>
        [Relation(
            CVersionDonnees.c_nomTable,
            CVersionDonnees.c_champId,
            CVersionDonnees.c_champId,
            false,
            false,
            false, 
            PasserLesFilsANullLorsDeLaSuppression=true)]
        [DynamicField("Applied data version")]
        public CVersionDonnees VersionDonneesPourApplication
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


        //-------------------------------------------------------------------
        /// <summary>
        /// Indique le statut des équipements créés par ce relevé
        /// </summary>
        [Relation(
            CStatutEquipement.c_nomTable,
            CStatutEquipement.c_champId,
            CStatutEquipement.c_champId,
            false,
            false,
            false)]
        [DynamicField("Default equipment status")]
        public CStatutEquipement StatutEquipementParDefaut
        {
            get
            {
                return (CStatutEquipement)GetParent(CStatutEquipement.c_champId, typeof(CStatutEquipement));
            }
            set
            {
                SetParent(CStatutEquipement.c_champId, value);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Liste des équipements relevés
        /// </summary>
        [RelationFille(typeof(CReleveEquipement), "ReleveSite")]
        [DynamicChilds("Equipments records", typeof(CReleveEquipement))]
        public CListeObjetsDonnees EquipementsReleves
        {
            get
            {
                return GetDependancesListe(CReleveEquipement.c_nomTable, c_champId);
            }
        }

		#region IElementAInterfaceTiag Membres

		public object[] TiagKeys
		{
			get { return new object[] { Id }; }
		}

		public string TiagType
		{
			get { return c_nomTiag; }
		}

		#endregion

        //--------------------------------------------------------------------------
        public IEnumerable<CTraitementReleveEquipement> GetTraitements()
        {
            List<CTraitementReleveEquipement> traitements = new List<CTraitementReleveEquipement>();
            CListeObjetsDonnees lst = EquipementsReleves;
            //Préchargement de données
            lst.ReadDependances("Equipement","RelevesEquipementsFils");
            new CListeObjetsDonnees(ContexteDonnee, typeof(CTypeEquipement)).AssureLectureFaite();
            new CListeObjetsDonnees(ContexteDonnee, typeof(CRelationTypeEquipement_Constructeurs)).AssureLectureFaite();
            lst.Filtre = new CFiltreData(CReleveEquipement.c_champParentEqpt + " is null");
            foreach (CReleveEquipement rel in lst)
            {
                CTraitementReleveEquipement traitement = rel.GetTraitement();
                if (traitement != null)
                    traitements.Add(traitement);
            }
            return traitements.AsReadOnly();
        }


        //--------------------------------------------------------------------------
        public void CalculeEtatExecutionInCurrentContext()
        {
            if ( EtatExecution.Code == EEtatExecutionReleve.Execute ||
                EtatExecution.Code == EEtatExecutionReleve.Annule)
                return;
            if (EtatExecution.Code == EEtatExecutionReleve.NonEvalué)
            {
                IEnumerable<CTraitementReleveEquipement> lst = GetTraitements();
                foreach (CTraitementReleveEquipement traitement in lst)
                {
                    traitement.StoreInContexte(ContexteDonnee);
                }
            }
            //balaie tous les éléments pour voir s'ils ont été évalués
            EEtatValidationReleveEquipement etat = EEtatValidationReleveEquipement.Appliquée;
            foreach ( CReleveEquipement releve in EquipementsReleves )
            {
                if (releve.Action != null && releve.CodeEtatValidationAction < (int)etat)
                    etat = (EEtatValidationReleveEquipement)releve.CodeEtatValidationAction;
                if (etat == EEtatValidationReleveEquipement.None)
                    break;
            }
                
            switch (etat)
            {
                case EEtatValidationReleveEquipement.None:
                    CodeEtatExecution = (int)EEtatExecutionReleve.AValider;
                    break;
                case EEtatValidationReleveEquipement.Validé:
                    CodeEtatExecution = (int)EEtatExecutionReleve.AExecuter;
                    break;
                case EEtatValidationReleveEquipement.Appliquée:
                    CodeEtatExecution = (int)EEtatExecutionReleve.Execute;
                    break;
                default:
                    break;
            }
        }
	}
}
