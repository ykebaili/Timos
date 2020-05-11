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
    /// Exprime une relation entre un <see cref="CTypeTicketContrat">Type Ticket Contrat</see> et un <see cref="CSite">Site</see>.
    /// </summary>
	[DynamicClass("Ticket type / Contract / Site")]
	[Table(CTypeTicketContrat_Site.c_nomTable, CTypeTicketContrat_Site.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CTypeTicketContrat_SiteServeur")]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    public class CTypeTicketContrat_Site : CObjetDonneeAIdNumeriqueAuto,
                                      IObjetALectureTableComplete
	{
		public const string c_nomTable = "TICKET_TYPE_CONTRACT_SITE";
        public const string c_champId = "TKTTYP_CNT_ST_ID";

		/// /////////////////////////////////////////////
		public CTypeTicketContrat_Site( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CTypeTicketContrat_Site(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Contrat(@1)/Ticket type(@2)/Site(@3)|20080",
                    Contrat == null?"?":Contrat.Libelle,
                    TypeTicket == null?"?":TypeTicket.Libelle,
                    ContratSite == null ? "?" : ContratSite.Site == null?"?":ContratSite.Site.Libelle);
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
        /// Contrat objet de la relation
        /// </summary>
        [DynamicField("Contract")]
        public CContrat Contrat
        {
            get
            {
                CTypeTicketContrat tt = TypeTicket_Contrat;
                if (tt != null)
                    return tt.Contrat;
                return null;
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Type de ticket objet de la relation
        /// </summary>
        [DynamicField("Ticket type")]
        public CTypeTicket TypeTicket
        {
            get
            {
                CTypeTicketContrat tt = TypeTicket_Contrat;
                if (tt != null)
                    return tt.TypeTicket;
                return null;
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Type Ticket Contrat objet de la relation
        /// </summary>
        [Relation(
            CTypeTicketContrat.c_nomTable,
            CTypeTicketContrat.c_champId,
            CTypeTicketContrat.c_champId,
            true,
            true,
            false)]
        [DynamicField("Ticket type/Contract")]
        public CTypeTicketContrat TypeTicket_Contrat
        {
            get
            {
                return (CTypeTicketContrat)GetParent(CTypeTicketContrat.c_champId, typeof(CTypeTicketContrat));
            }
            set
            {
                SetParent(CTypeTicketContrat.c_champId, value);
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Relation Contrat Site, objet de la relation
        /// </summary>
        [Relation(
            CContrat_Site.c_nomTable,
            CContrat_Site.c_champId,
            CContrat_Site.c_champId,
            true,
            true,
            true)]
        [DynamicField("site contract link")]
        public CContrat_Site ContratSite
        {
            get
            {
                return (CContrat_Site)GetParent(CContrat_Site.c_champId, typeof(CContrat_Site));
            }
            set
            {
                SetParent(CContrat_Site.c_champId, value);
            }
        }

        //---------------------------------------------
        /// <summary>
        /// Retourne la liste des périodes de validité du contrat pour chaque type de ticket et chaque site
        /// </summary>
        [RelationFille(typeof(CTypeTicketContrat_Site_Periode), "TypeTicketContrat_Site")]
        [DynamicChilds("Periods relations", typeof(CTypeTicketContrat_Site_Periode))]
        public CListeObjetsDonnees Periodes
        {
            get
            {
                return GetDependancesListe(CTypeTicketContrat_Site_Periode.c_nomTable, c_champId);
            }
        }

        //---------------------------------------------
        public CTypeTicketContrat_Site_Periode GetPeriodeFor(DateTime dt)
        {
            CListeObjetsDonnees lst = Periodes;
            lst.Filtre = new CFiltreData(CTypeTicketContrat_Site_Periode.c_champDateDebut + "<=@1 and " +
                CTypeTicketContrat_Site_Periode.c_champDateFin + ">=@1", dt);
            lst.InterditLectureInDB = true;
            if (lst.Count > 0)
                return lst[0] as CTypeTicketContrat_Site_Periode;
            return null;
        }

        //---------------------------------------------
        public CTypeTicketContrat_Site_Periode SetPeriode(int? nIdPeriode, DateTime dateDebut, DateTime dateFin)
        {
            CTypeTicketContrat_Site_Periode ts = new CTypeTicketContrat_Site_Periode(ContexteDonnee);
            if (nIdPeriode == null || !ts.ReadIfExists(nIdPeriode.Value))
            {
                ts.CreateNewInCurrentContexte();
                ts.TypeTicketContrat_Site = this;
            }
            ts.DateDebut = dateDebut;
            ts.DateFin = dateFin;
            return ts;
        }

        //---------------------------------------------
        public void RemovePeriode(int nIdPeriode)
        {
            CTypeTicketContrat_Site_Periode tp = new CTypeTicketContrat_Site_Periode(ContexteDonnee);
            if (tp.ReadIfExists(nIdPeriode))
                tp.Delete(true);
        }

        //---------------------------------------------
        public CResultAErreur VerifieCoherencesPeriodes()
        {
            CResultAErreur result = CResultAErreur.True;
            CListeObjetsDonnees lst = Periodes;
            lst.Tri = CTypeTicketContrat_Site_Periode.c_champDateDebut;
            DateTime? dt = null;
            foreach (CTypeTicketContrat_Site_Periode periode in lst)
            {
                if (dt == null)
                    dt = periode.DateFin;
                else if (dt.Value > periode.DateDebut)
                {
                    result.EmpileErreur(I.T("Periode @1-@2 for site @3 is in conflict with another periode|20082",
                        periode.DateDebut.ToShortDateString(),
                        periode.DateFin.ToShortDateString(),
                        this.ContratSite != null && this.ContratSite.Site != null ? this.ContratSite.Site.Libelle : "?"));
                }
            }
            return result;
        }
                    


	


	

	

   


	}
}
