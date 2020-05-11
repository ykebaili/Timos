using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using timos.acteurs;

namespace timos.data
{
    /// <summary>
    /// Exprime une relation entre un <see cref="CTypeTicket">Type de Ticket</see> et un <see cref="CContrat">Contrat client</see>.
    /// </summary>
	[DynamicClass("Ticket type / Contract")]
	[Table(CTypeTicketContrat.c_nomTable, CTypeTicketContrat.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeTicketContratServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CTypeTicketContrat : CObjetDonneeAIdNumeriqueAuto,
                                      IObjetALectureTableComplete
	{
		public const string c_nomTable = "TICKET_TYPE_CONTRACT";
        public const string c_champId = "TKTTYP_CONTRACT_ID";

		/// /////////////////////////////////////////////
		public CTypeTicketContrat( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CTypeTicketContrat(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Contract(@1)/Ticket type(@2)|30079",Contrat.Libelle, TypeTicket.Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champId};
		}


		

        //-------------------------------------------------------------------
        /// <summary>
        /// Le Type de ticket objet de la relation
        /// </summary>
        [Relation(
            CTypeTicket.c_nomTable,
            CTypeTicket.c_champId,
            CTypeTicket.c_champId,
            true,
            true,
            false)]
        [DynamicField("Ticket type")]
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




        //-------------------------------------------------------------------
        /// <summary>
        /// Le Contrat objet de la relation
        /// </summary>
        [Relation(
            CContrat.c_nomTable,
            CContrat.c_champId,
            CContrat.c_champId,
            true,
            false,
            false)]
        [DynamicField("Contract")]
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

        //---------------------------------------------
        public CTypeTicketContrat_Site GetRelationSite(int nIdSite)
        {
            CContrat_Site cs = Contrat.GetRelationSite(nIdSite);
            if (cs != null)
            {
                CListeObjetsDonnees lst = RelationsSites;
                lst.Filtre = new CFiltreData(CContrat_Site.c_champId + "=@1", cs.Id);
                lst.InterditLectureInDB = true;
                if (lst.Count > 0)
                    return (CTypeTicketContrat_Site)lst[0];
            }
            return null;
        }


        //---------------------------------------------
        /// <summary>
        /// Liste des relations avec les sites liées à cette relation Contrat/Type ticket
        /// </summary>
        [RelationFille(typeof(CTypeTicketContrat_Site), "TypeTicket_Contrat")]
        [DynamicChilds("Sites relations", typeof(CTypeTicketContrat_Site))]
        public CListeObjetsDonnees RelationsSites
        {
            get
            {
                return GetDependancesListe(CTypeTicketContrat_Site.c_nomTable, c_champId);
            }
        }


        //----------------------------------------------------------------
        public CSite[] GetTousLesSitesAssocies()
        {
            ArrayList listeSites = new ArrayList();

            RelationsSites.ReadDependances("Site");

            // Ajout des Sites par relation
            foreach (CContratListeOp_Site rel in RelationsSites)
            {
                listeSites.Add(rel.Site);
            }

            //Si aucun site ajouté, prend tous les sites du contrat
            if (listeSites.Count == 0)
            {
                foreach (CSite site in Contrat.GetTousLesSitesDuContrat())
                    listeSites.Add(site);
            }

            return (CSite[])listeSites.ToArray(typeof(CSite));
        }









        public void RemovePeriode(int nIdSite, int nIdPeriode)
        {
            CTypeTicketContrat_Site ts = GetRelationSite(nIdSite);
            if (ts != null)
            {
                ts.RemovePeriode(nIdPeriode);
                if (ts.Periodes.Count == 0)
                    ts.Delete(true);
            }
        }

        //--------------------------------------------------------
        public CTypeTicketContrat_Site_Periode SetPeriode(int nIdSite, int? nIdPeriode, DateTime dateDebut, DateTime dateFin)
        {
            CTypeTicketContrat_Site ts = GetRelationSite(nIdSite);

            CContrat_Site cs = Contrat.GetRelationSite(nIdSite, true);
            if (cs != null)
            {
                if (ts == null)
                {
                    ts = new CTypeTicketContrat_Site(ContexteDonnee);
                    ts.CreateNewInCurrentContexte();
                    ts.TypeTicket_Contrat = this;
                    ts.ContratSite = cs;                    
                }
                return ts.SetPeriode(nIdPeriode, dateDebut, dateFin);
            }
            return null;
        }

        //--------------------------------------------------------
        /// <summary>
        /// Retourne le tableau des sites concernés par ce type de ticket et ce contrat
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        [DynamicMethod("Returns all sites concerned by this ticket type for the contrat", "Date to test")]
        public CSite[] GetConcernedSites(DateTime dt)
        {
            CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CSite));
            lst.Filtre = new CFiltreDataAvance(CSite.c_nomTable,
                CContrat_Site.c_nomTable+"."+
                CTypeTicketContrat_Site.c_nomTable+"."+
                CTypeTicketContrat.c_champId+"=@1 and "+
                CContrat_Site.c_nomTable + "." +
                CTypeTicketContrat_Site.c_nomTable + "." +
                CTypeTicketContrat_Site_Periode.c_nomTable + "." +
                CTypeTicketContrat_Site_Periode.c_champDateDebut + "<=@2 and " +
                CContrat_Site.c_nomTable + "." +
                CTypeTicketContrat_Site.c_nomTable + "." +
                CTypeTicketContrat_Site_Periode.c_nomTable + "." +
                CTypeTicketContrat_Site_Periode.c_champDateFin + ">=@2",
                Id,
                dt);
            return (CSite[])lst.ToArray(typeof(CSite));
        }


    }
}
