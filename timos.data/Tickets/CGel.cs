using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;
using sc2i.data.dynamic;
using sc2i.process;
using timos.acteurs;
using tiag.client;
using sc2i.process.workflow.gels;

namespace timos.data
{
	/// <summary>
	/// Permet de stocker les informations de gel d'une <see cref="CIntervention">Intervention</see> ou 
    /// d'une <see cref="CPhaseTicket">Phase de Ticket</see>.<BR/> 
	/// </summary>
    /// <remarks>
    /// Une période de gel indique que les travaux à effectuer dans le cadre de l'intervention<br/>
    /// ou la phase de ticket en cours sont interrompus pour une raison ou pour une autre.<br/>
    /// </remarks>
	[DynamicClass("Freezing")]
	[Table(CGel.c_nomTable, CGel.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CGelServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IngeProjet_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersPreventives_ID,
        Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    [TiagClass(CGel.c_nomTiag, "Id", true)]
    public class CGel : CObjetDonneeAIdNumeriqueAuto
                                
	{
        public const string c_nomTiag = "Freezing";
        public const string c_nomTable = "FREEZING_INFO";

		public const string c_champId = "FREEZING_ID";
		public const string c_champInfosDebutGel = "FREEZING_START_INFOS";
		public const string c_champDateDebut = "FREEZING_START_DATE";
		public const string c_champDateFin = "FREEZING_END_DATE";
		public const string c_champInfosFinGel = "FREEZING_END_INFOS";

		/// /////////////////////////////////////////////
		public CGel( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CGel(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return I.T( "Freezing from @1 to @2|30067",DateDebutString,DateFinString);
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champDateDebut};
		}



        /////////////////////////////////////////////
        /// <summary>
		/// Information textuelle sur le début de la période de Gel.<br/>
        /// Indique en général le motif pour lequel il y a eu gel.
		/// </summary>
		[TableFieldProperty(c_champInfosDebutGel, 1024)]
		[DynamicField("Freezing start info")]
        [TiagField("Freezing start info")]
		public string InfosDebutGel
		{
			get
			{
				return (string)Row[c_champInfosDebutGel];
			}
			set
			{
				Row[c_champInfosDebutGel] = value;
			}
		}

		////////////////////////////////////////////////
        /// <summary>
        /// Information textuelle sur la fin de la période de Gel
        /// </summary>
		[TableFieldProperty(c_champInfosFinGel, 1024)]
		[DynamicField("Freezing end info")]
        [TiagField("Freezing end info")]
		public string InfosFinGel
		{
			get
			{
				return (string)Row[c_champInfosFinGel];
			}
			set
			{
				Row[c_champInfosFinGel] = value;
			}
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Indique la date et l'heure à laquelle La Phase de Ticket ou l'Intervention a été gelée.
        /// </summary>
        [TableFieldProperty(c_champDateDebut)]
        [DynamicField("Start date")]
        [TiagField("Start date")]
        public DateTime DateDebut
        {
            get
            {
                return (DateTime)Row[c_champDateDebut];
            }
            set
            {
                Row[c_champDateDebut] = value;
            }
        }

		//-----------------------------------------------------------
		public string DateDebutString
		{
			get
			{
				return DateDebut.ToString("g");
			}
		}


        //-----------------------------------------------------------
        /// <summary>
        /// Indique la date et l'heure à laquelle la Phase de Ticket ou l'Intervention a été dégelée.
        /// </summary>
        [TableFieldProperty(c_champDateFin, NullAutorise = true)]
        [DynamicField("End date")]
        [TiagField("End date")]
        public DateTime? DateFin
        {
            get
            {
                return (DateTime ?)Row[c_champDateFin, true];
            }
            set
            {
                Row[c_champDateFin, true] = value;
            }
        }

		//-----------------------------------------------------------
		public string DateFinString
		{
			get
			{
				if (DateFin == null)
					return "";
				return ((DateTime)DateFin).ToString("g");
			}
		}


        public void TiagSetCauseGelKeys(object[] lstCles)
        {
            CCauseGel cause = new CCauseGel(ContexteDonnee);
            if (cause.ReadIfExists(lstCles))
                CauseGel = cause;
        }
        //-------------------------------------------------------------------
        /// <summary>
        /// Obtient ou définit la <see cref="CCauseGel">cause du gel</see> <br/> (obligatoire)
        /// </summary>
        [Relation(
            CCauseGel.c_nomTable,
            CCauseGel.c_champId,
            CCauseGel.c_champId,
            true,
            false,
            false)]
        [DynamicField("Freezing cause")]
        [TiagRelation(typeof(CCauseGel), "TiagSetCauseGelKeys")]
        public CCauseGel CauseGel
        {
            get
            {
                return (CCauseGel)GetParent(CCauseGel.c_champId, typeof(CCauseGel));
            }
            set
            {
                SetParent(CCauseGel.c_champId, value);
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
        /// Obtient ou définit la Phase de Ticket concernée par le gel.
        /// </summary>
        [Relation(
            CPhaseTicket.c_nomTable,
            CPhaseTicket.c_champId,
            CPhaseTicket.c_champId,
            false,
            true,
            false)]
        [DynamicField("Ticket phase")]
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

        public void TiagSetInterventionKeys(object[] lstCles)
        {
            CIntervention inter = new CIntervention(ContexteDonnee);
            if (inter.ReadIfExists(lstCles))
                Intervention = inter;
        }
		//-------------------------------------------------------------------
		/// <summary>
		/// Obtient ou définit L'Intervention concernée par le gel
		/// </summary>
		[Relation(
			CIntervention.c_nomTable,
			CIntervention.c_champId,
			CIntervention.c_champId,
			false,
			true,
			false)]
		[DynamicField("Intervention")]
        [TiagRelation(typeof(CIntervention), "TiagSetInterventionKeys")]
		public CIntervention Intervention
		{
			get
			{
				return (CIntervention)GetParent(CIntervention.c_champId, typeof(CIntervention));
			}
			set
			{
				SetParent(CIntervention.c_champId, value);
				if ( value != null )
				{
					if ( value.PhaseTicket != null )
						PhaseTicket = value.PhaseTicket;
					else
						PhaseTicket = null;
				}
			}
		}

		/// /////////////////////////////////////////////
		public IElementGelable ElementGelable
		{
			get
			{
				if (Intervention != null)
					return Intervention;
				if (PhaseTicket != null)
					return PhaseTicket;
				return null;
			}
			set
			{
				if (value is CIntervention)
					Intervention = (CIntervention)value;
				else if (value is CPhaseTicket)
					PhaseTicket = (CPhaseTicket)value;
			}
		}
    }

	/// /////////////////////////////////////////////
	public static class SElementGelable
	{
		//------------------------------------------------------------------
		public static CResultAErreur Geler(IElementGelable elt, DateTime dateTime, CCauseGel cCauseGel, string strInfo)
		{
			CResultAErreur result = CResultAErreur.True;
			//Vérifie qu'il n'y a pas déjà un gel ouvert
			if (elt.EstGelee)
			{
				result.EmpileErreur(I.T("Freezing impossible for an element already freezed|546"));
				return result;
			}
			CGel gel = new CGel(elt.ContexteDonnee);
			gel.CreateNew();
			gel.DateDebut = dateTime;
			gel.CauseGel = cCauseGel;
			gel.InfosDebutGel = strInfo;
			gel.ElementGelable = elt;
			result = gel.CommitEdit();
			return result;
		}

		//------------------------------------------------------------------
		public static CResultAErreur Degeler(IElementGelable elt, DateTime dateTime, string strInfo)
		{
			CResultAErreur result = CResultAErreur.True;
			CGel gelADegeler = null;
			foreach (CGel gel in elt.Gels)
			{
				if (gel.DateFin == null)
				{
					gelADegeler = gel;
					break;
				}
			}
			if (gelADegeler == null)
			{
				result.EmpileErreur(I.T("Unfreezing impossible for an element not freezed|551"));
				return result;
			}

			gelADegeler.BeginEdit();
			gelADegeler.InfosFinGel = strInfo;
			gelADegeler.DateFin = dateTime;
			result = gelADegeler.CommitEdit();
			return result;
		}
		//------------------------------------------------------------------
		public static CResultAErreur ModifGeler(CGel elt, DateTime dateTime, CCauseGel cCauseGel, string strInfo)
		{
			CResultAErreur result = CResultAErreur.True;
			elt.BeginEdit();
			elt.CauseGel = cCauseGel;
			elt.InfosDebutGel = strInfo;
			elt.DateDebut = dateTime;
			return elt.CommitEdit();
		}
		//------------------------------------------------------------------
		public static CResultAErreur ModifDegeler(CGel elt, DateTime dateTime, string strInfo)
		{
			CResultAErreur result = CResultAErreur.True;

			elt.BeginEdit();
			elt.InfosFinGel = strInfo;
			elt.DateFin = dateTime;
			return elt.CommitEdit();
		}

		//------------------------------------------------------------------
		public static bool CalculeEtatGel(IElementGelable elt)
		{
			bool bGelee = false;
			foreach (CGel gel in elt.Gels)
			{
				if (gel.DateFin == null)
				{
					bGelee = true;
					break;
				}
			}
			return bGelee;
		}
		
	}



}
