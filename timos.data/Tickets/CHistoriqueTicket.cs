using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using timos.securite;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;

namespace timos.data
{
    /// <summary>
    /// Un Historique de Ticket permet de tracer les actions suivantes sur le <see cref="CTicket">Ticket</see><br/>
    /// <list type="bullet">
    /// <item><term>Ouverture du Ticket</term></item>
    /// <item><term>Clôture du Ticket</term></item>
    /// <item><term>Création d'une Phase</term></item>
    /// <item><term>Début d'une Phase</term></item>
    /// <item><term>Fin d'une Phase</term></item>
    /// <item><term>Affectation du Ticket à un autre Utilisateur (Responsable)</term></item>
    /// </list>
    /// 
    /// </summary>
    [DynamicClass("Ticket History")]
    [Table(CHistoriqueTicket.c_nomTable, CHistoriqueTicket.c_champId, true)]
    [FullTableSync]
    [ObjetServeurURI("CHistoriqueTicketServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CHistoriqueTicket : 
		CObjetDonneeAIdNumeriqueAuto
    {
        public const string c_nomTable = "TICKET_HISTORY";

		public const string c_champId = "TKT_HISTO_ID";
		public const string c_champDate = "TKT_HISTO_DATE";

		public const string c_champInfo = "TKT_HISTO_INFO";


        /// /////////////////////////////////////////////
        public CHistoriqueTicket(CContexteDonnee contexte)
            : base(contexte)
        {
        }

        /// /////////////////////////////////////////////
        public CHistoriqueTicket(DataRow row)
            : base(row)
        {
        }

        /// /////////////////////////////////////////////
        public override string DescriptionElement
        {
            get
            {
                return I.T( "Ticket history @1 |30068",Ticket.Numero);
            }
        }

        /// /////////////////////////////////////////////
        protected override void MyInitValeurDefaut()
        {
			Date = DateTime.Now;
        }

        /// /////////////////////////////////////////////
        public override string[] GetChampsTriParDefaut()
        {
			return new string[] { c_champDate };
        }

		////////////////////////////////////////////////
        /// <summary>
        /// La date de l'Historique
        /// </summary>
		[TableFieldProperty(c_champDate)]
		[DynamicField("Date")]
		public DateTime Date
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

        //--------------------------------------------------------------------------
        public string DateToString
        {
            get
            {
                return Date.ToString("g");
            }
        }

		////////////////////////////////////////////////
        /// <summary>
        /// Une Information textuelle renseignée automatiquement à la crétion de l'Historique
        /// </summary>
		[TableFieldProperty(c_champInfo, 2000)]
		[DynamicField("Info")]
		public string Info
		{
			get
			{
				return (string)Row[c_champInfo];
			}
			set
			{
				Row[c_champInfo] = value;
			}
		}

		//////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// L'Utilisateur en cours de l'Application
        /// </summary>
		[RelationAttribute(
		    CDonneesActeurUtilisateur.c_nomTable,
		    CDonneesActeurUtilisateur.c_champId,
		    CDonneesActeurUtilisateur.c_champId,
			true,
			false,
			false)]
		[DynamicField("User member")]
		public CDonneesActeurUtilisateur ActeurUtilisateur
		{
			get 
            { 
                return (CDonneesActeurUtilisateur)GetParent(CDonneesActeurUtilisateur.c_champId, typeof(CDonneesActeurUtilisateur)); 
            }
			set 
            {
                SetParent(CDonneesActeurUtilisateur.c_champId, value); 
            }
		}

		//////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Le Ticket parent de l'Historique
        /// </summary>
		[RelationAttribute(
		    CTicket.c_nomTable,
		    CTicket.c_champId,
		    CTicket.c_champId,
			true,
			true,
			true)]
		[DynamicField("Ticket")]
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

		//////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// La Phase de Ticket en cours
        /// </summary>
		[RelationAttribute(
		    CPhaseTicket.c_nomTable,
		    CPhaseTicket.c_champId,
		    CPhaseTicket.c_champId,
			false,
			false,
			false)]
		[DynamicField("Ticket phase")]
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
		
	}
}
