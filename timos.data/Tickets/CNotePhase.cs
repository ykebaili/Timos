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

using timos.securite;

namespace timos.data
{
	/// <summary>
	/// Permet la saisie d'une note sous forme d'un champ texte libre relatif à une <br/>
    /// <see cref="CPhaseTicket">Phase de Ticket</see>. La Note comporte:<br/>
    /// <list type="bullet">
    /// <item>Une date</item>
    /// <item>Un <see cref="CDonneesACteurUtilisateur">utilisateur</see></item>
    /// <item>Un champ texte</item>
    /// </list>
	/// </summary>
	[DynamicClass("Phase notes")]
	[Table(CNotePhase.c_nomTable, CNotePhase.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CNotePhaseServeur")]
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iTicket)]
    [Lys.Licence.AModulesApp(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_appModule_IntersCorrectives_ID)]
    public class CNotePhase : CObjetDonneeAIdNumeriqueAuto, IObjetSansVersion
	{
		public const string c_nomTable = "TICKET_PHASE_NOTE";

		public const string c_champId = "TKTPHASENOT_ID";
		public const string c_champTexte = "TKTPHASENOT_TEXT";
		public const string c_champDate = "TKTPHASENOT_DATE";

		/// /////////////////////////////////////////////
		public CNotePhase(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CNotePhase(DataRow row)
			: base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Phase note for Ticket @1|30071",CUtilTexte.TronqueLeMilieu(Texte, 25));
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champDate };
		}



		//-----------------------------------------------
        /// <summary>
        /// Texte de la note
        /// </summary>
		[TableFieldProperty(c_champTexte, 2000)]
		[DynamicField("Text")]
        [DescriptionField]
        public string Texte
		{
			get
			{
                return (string)Row[c_champTexte];
			}
			set
			{
                Row[c_champTexte] = value;
			}
		}

		//----------------------------------------------------------
        /// <summary>
        /// Date de la note
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
        //-------------------------------------------------------------------
        public string DateToString
        {
            get
            {
                return Date.ToString("g");
            }
        }



        //-------------------------------------------------------------------
        /// <summary>
        /// Phase de ticket à laquelle est attachée la note
        /// </summary>
        [Relation(
            CPhaseTicket.c_nomTable,
            CPhaseTicket.c_champId,
            CPhaseTicket.c_champId,
            true,
            true,
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



        //-------------------------------------------------------------------
        /// <summary>
        /// Utilisateur de l'application ayant créé la note
        /// </summary>
        [Relation(
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

	}
}
