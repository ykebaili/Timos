using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using tiag.client;

namespace timos.data
{
	/// <summary>
    /// Definit l'urgence d'un <see cref="CTicket">Ticket</see>, donc sa priorité.<br/>
    /// L'urgence des tickets permet d'ordonner les tickets suivant leur priorité.<br/>
    /// Le ticket dont l'urgence a la priorité la plus élevée devra être démarré en premier.<br/>
    /// L'urgence pour un ticket est facultative.
	/// </summary>
	[DynamicClass("Ticket urgency")]
	[Table(CUrgenceTicket.c_nomTable, CUrgenceTicket.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CUrgenceTicketServeur")]
    [Unique(false, "This Urgency Label is already used|233", CUrgenceTicket.c_champLibelle)]
    [Unique(false, "This Urgency Priority Level is already used|234", CUrgenceTicket.c_champPriorite)]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_ParamTickets_ID)]
    [TiagClass(CUrgenceTicket.c_nomTiag, "Id", true)]
    public class CUrgenceTicket : CObjetDonneeAIdNumeriqueAuto,
                                IObjetALectureTableComplete
                                
	{
        public const string c_nomTable = "TICKET_URGENCY";
        public const string c_nomTiag = "Ticket Urgency";

        public const string c_champId = "TKTURG_ID";

		public const string c_champLibelle = "TKTURG_LABEL";
		public const string c_champPriorite = "TKTURG_PRIORITY";
        
        /// /////////////////////////////////////////////
		public CUrgenceTicket( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CUrgenceTicket(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T("Ticket Urgency @1|30080",Libelle);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
            return new string[] { c_champId };
		}


        
        //--------------------------------------------------------------------------
		/// <summary>
		/// Libellé de l'Urgence
		/// </summary>
		[TableFieldProperty ( c_champLibelle, 128 )]
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


        //---------------------------------------------------------------------------
        /// <summary>
        /// Priorité: Entier croissant en fonction du degré d'urgence
        /// 0 = urgence la plus basse
        /// Valeur max de (Priorite) = urgence la plus haute
        /// </summary>
        [TableFieldProperty(c_champPriorite)]
        [DynamicField("Priority")]
        [TiagField("Priority")]
        public int Priorite
        {
            get
            {
                return (int)Row[c_champPriorite];
            }
            set
            {
                Row[c_champPriorite] = value;
            }
        }
        

    }
}
