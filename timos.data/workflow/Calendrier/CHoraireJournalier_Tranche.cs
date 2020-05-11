using System;
using System.Collections;
using System.Data;

using sc2i.data;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace sc2i.workflow
{
	/// <summary>
    /// Tranche horaire exploitée dans les <see cref="CHoraireJournalier">horaires journaliers</see>.<br/>
    /// Une tranche horaire possède obligatoirement une heure de début et une heure de fin. 
    /// L'heure de fin ne peut être égale à l'heure de début.<br/> 
    /// Si l'heure de fin est inférieure à l'heure de début, cela indique que la tranche<br/> 
    /// horaire se termine le jour suivant (la tranche est à cheval sur deux jours).
	/// </summary>
    /// <remarks>
    /// Les temps sont exprimés en minutes codées sous forme d'entier. (0 = 00H00, 1439 = 23H59).
    /// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [DynamicClass("Daily schedule part")]
	[Table(CHoraireJournalier_Tranche.c_nomTable, CHoraireJournalier_Tranche.c_champId, true )]
	[FullTableSync]
	[ObjetServeurURI("CHoraireJournalier_TrancheServeur")]
    //[Lys.Licence.AModulesClient(Lys.Applications.Timos.Smt.CConfigModulesTimos.c_clientModule_HoraireJournalier_ID)]
    public class CHoraireJournalier_Tranche : CObjetDonneeAIdNumeriqueAuto, IObjetALectureTableComplete
	{
		public const string c_nomTable = "DAILY_SCHEDULE_PART";

        public const string c_champId = "DLYSCHPRT_ID";
		public const string c_champHeureDebut = "DLYSCHPRT_START";
		public const string c_champHeureFin = "DLYSCHPRT_END";

		/// /////////////////////////////////////////////
		public CHoraireJournalier_Tranche( CContexteDonnee contexte)
			:base(contexte)
		{
		}
		
	    /// /////////////////////////////////////////////
		public CHoraireJournalier_Tranche(DataRow row )
			:base(row)
		{
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
				return I.T( "Daily schedule part : @1 - @2|314",
					HeureDebut.ToString("00"),
					HeureFin.ToString("00"));
			}
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champHeureDebut};
		}



        //-----------------------------------------------------------
        /// <summary>
        /// Heure de début de la tranche, exprimée en minutes (0 = 0H, 1439 = 23h59)
        /// </summary>
        [TableFieldProperty(c_champHeureDebut)]
        [DynamicField("Starting hour")]
        public int HeureDebut
        {
            get
            {
                return (int)Row[c_champHeureDebut];
            }
            set
            {
                Row[c_champHeureDebut] = value;
            }
        }


        //-----------------------------------------------------------
        /// <summary>
        /// Heure de fin de la tranche, exprimée en minutes (0 = 0H, 1439 = 23h59)
        /// </summary>
        [TableFieldProperty(c_champHeureFin)]
        [DynamicField("Ending hour")]
        public int HeureFin
        {
            get
            {
                return (int)Row[c_champHeureFin];
            }
            set
            {
                Row[c_champHeureFin] = value;
            }
        }

        //------------------------------------------------------------------------------
        /// <summary>
        /// Retourne la durée de la tranche horaire, exprimée en minutes.
        /// </summary>
        [DynamicField("Duration")]
        public int Durée
        {
            get
            {
                int durée = HeureFin - HeureDebut;
                if (durée < 0) // 24H = 1440 min
                    durée = (1440 - HeureDebut) + HeureFin;
                return durée;
            }
        }

        //----------------------------------------------------------------------------
        public string HeureDebutString
        {
            get 
            {
                int heure = (int)HeureDebut / 60;
                int minute = HeureDebut % 60;

                return (heure.ToString("00") + ":" + minute.ToString("00"));
            }
        }

        //----------------------------------------------------------------------------
        public string HeureFinString
        {
            get
            {
                int heure = (int)HeureFin / 60;
                int minute = HeureFin % 60;

                return (heure.ToString("00") + ":" + minute.ToString("00"));
            }
        }


        //--------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le type d'occupation horaire, lorsque celui-ci<br/>
        /// est défini pour la tranche
        /// </summary>
        [Relation(
            CTypeOccupationHoraire.c_nomTable,
            CTypeOccupationHoraire.c_champId,
            CTypeOccupationHoraire.c_champId,
            false,
            false,
            false)]
        [DynamicField("Occupation Type")]
        public CTypeOccupationHoraire TypeOccupationHoraire
        {
            get
            {
                return (CTypeOccupationHoraire)GetParent(CTypeOccupationHoraire.c_champId, typeof(CTypeOccupationHoraire));
            }
            set
            {
                SetParent(CTypeOccupationHoraire.c_champId, value);
            }
        }

		//-------------------------------------------------------------------
        /// <summary>
        /// Retourne le type d'occupation horaire qui s'applique à la tranche.<br/>
        /// Il peut être, par ordre de priorité :<br/>
        /// <ul>
        /// <li>Celui spécifiquement défini au niveau de la tranche, lorsqu'il existe ou</li>
        /// <li>Celui défini au niveau du jour particulier associé à la tranche, lorsque ce jour existe ou</li>
        /// <li>Celui défini au niveau de l'horaire journalier, lorsque cet horaire existe</li>
        /// </ul>
        /// </summary>
        [DynamicField("Applied Occupation Type")]
        public CTypeOccupationHoraire TypeOccupationHoraireAppliquee
		{
			get
			{
				CTypeOccupationHoraire occ = TypeOccupationHoraire;
				if (occ == null && JourParticulier != null)
					occ = JourParticulier.TypeOccupationHoraireAppliquee;
				if (occ == null && HoraireJournalier != null)
					occ = HoraireJournalier.TypeOccupationHoraireAppliquee;
				return occ;
			}
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Jour Particulier correspondant à la tranche,<br/>
        /// s'il existe (relation de composition)
        /// </summary>
        [Relation(
            CCalendrier_JourParticulier.c_nomTable,
            CCalendrier_JourParticulier.c_champId,
            CCalendrier_JourParticulier.c_champId,
            false,
            true,
            false)]
        [DynamicField("Particular day")]
        public CCalendrier_JourParticulier JourParticulier
        {
            get
            {
                return (CCalendrier_JourParticulier)GetParent(CCalendrier_JourParticulier.c_champId, typeof(CCalendrier_JourParticulier));
            }
            set
            {
                SetParent(CCalendrier_JourParticulier.c_champId, value);
            }
        }

        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit l'Horaire journalier correspondant à la tranche,<br/>
        /// s'il existe.
        /// </summary>
        [Relation(
            CHoraireJournalier.c_nomTable,
            CHoraireJournalier.c_champId,
            CHoraireJournalier.c_champId,
            false,
            true,
            false)]
        [DynamicField("Daily schedule")]
        public CHoraireJournalier HoraireJournalier
        {
            get
            {
                return (CHoraireJournalier)GetParent(CHoraireJournalier.c_champId, typeof(CHoraireJournalier));
            }
            set
            {
                SetParent(CHoraireJournalier.c_champId, value);
            }
        }

        /// <summary>
        /// Donne ou définit l'élément correspondant à la tranche horaire qui peut être :<br/>
        /// <ul>
        /// <li>Soit Un Horaire Journalier</li>
        /// <li>Soit Un Jour particulier</li>
        /// </ul>
        /// </summary>
        [DynamicField("Parent element")]
        public IElementATrancheHoraire ElementAtrancheHoraireParent
        {
            get 
            {
                IElementATrancheHoraire elementParent = HoraireJournalier;
                if (elementParent == null)
                    elementParent = JourParticulier;
                return elementParent; 
            }
            set 
            {
                if (value is CHoraireJournalier && value != null)
                    HoraireJournalier = (CHoraireJournalier)value;
                else
                    HoraireJournalier = null;

                if (value is CCalendrier_JourParticulier && value != null)
                    JourParticulier = (CCalendrier_JourParticulier)value;
                else
                    JourParticulier = null;
            }
        }

        /// <summary>
        /// Compare les propriétés d'une tranche horaire avec une autre
        /// </summary>
        /// <param name="trancheAComparer"></param>
        /// <returns>true si les propriétés sont identiques</returns>
        public bool HasSameProperties(CHoraireJournalier_Tranche trancheAComparer)
        {
            if (trancheAComparer != null &&
                trancheAComparer.HeureDebut == this.HeureDebut &&
                trancheAComparer.HeureFin == this.HeureFin &&
                trancheAComparer.TypeOccupationHoraire == this.TypeOccupationHoraire)
            {
                return true;
            }
            else
                return false;
        }
	}
}
