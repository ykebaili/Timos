using System;
using System.Data;
using System.Collections;

using sc2i.data;
using timos.acteurs;
using sc2i.common;
using timos.data;
using System.Collections.Generic;

namespace sc2i.workflow
{
	/// <summary>
    /// Le Calendrier est un �l�ment qui d�finit, pour un <see cref="CActeur">acteur</see>, un Horaire Journalier par d�faut<br/> 
    /// qui repr�sente une journ�e type de travail et des Jours Particuliers.<br/>
    /// Un jour particulier peut lui-m�me d�finir un autre Horaire journalier qui remplacera l'Horaire par d�faut.
	/// </summary>
	/// <remarks>
    /// On applique aux jours standards, l'horaire d�fini par 'Horaire par d�faut'.<br/>
    /// On applique aux jours particuliers, l'horaire d�fini par 'Jour Particuliers'.<br/>
    /// Un acteur ne peut avoir q'un seul Calendrier (ou pas), et un Calendrier ne peut appartenir qu'� un seul et unique acteur.
	/// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(CDocLabels.c_iPlanif)]
    [DynamicClass("Calendars")]
	[Table(CCalendrier.c_nomTable, CCalendrier.c_champId, true)]
	[FullTableSync]
	[ObjetServeurURI("CCalendrierServeur")]
    [Unique(true, "A Calendar already exist with this Label|168", CCalendrier.c_champLibelle)]
    //[Unique(true, "A Calendar already exist with this Code|171", CCalendrier.c_champCode)]
    public class CCalendrier : CObjetDonneeAIdNumeriqueAuto,
                               IObjetDonneeAutoReference,
                               IObjetALectureTableComplete
	{
		public const string c_nomTable = "CALENDAR";

		public const string c_champId = "CALEND_ID";
		public const string c_champLibelle = "CALEND_LABEL";

		public const string c_champCode = "CALEND_CODE";
		public const string c_champDescription = "CALEND_DESCRIPTION";
		
		public const string c_champIdCalendrierDeBase = "CALEND_BASE_ID";



        /// /////////////////////////////////////////////////////////
		public CCalendrier( CContexteDonnee ctx)
			:base ( ctx )
		{
			
		}

		/// /////////////////////////////////////////////////////////
		public CCalendrier ( DataRow row )
			:base (row)
		{
		}

		/// /////////////////////////////////////////////////////////
		protected  override void MyInitValeurDefaut()
		{
            if(Acteur != null)
                Libelle = I.T("Calendar of @1|303", Acteur.Nom);
		}

		/// /////////////////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champLibelle};
		}

		/// /////////////////////////////////////////////////////////
		public override string DescriptionElement
		{
			get
			{
                return Libelle;
			}
		}

		/// /////////////////////////////////////////////////////////
		//-------------------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit le Libell� du Calendrier
        /// </summary>
		[TableFieldProperty(c_champLibelle,255)]
		[DynamicField("Label")]
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

		////////////////////////////////////////////////////////////
        /// <summary>
        /// Donne ou d�finit le Code du Calendrier.<br/>
        /// (cha�ne de 100 caract�res maximum)
        /// </summary>
		[DynamicField("Code")]
		[TableFieldProperty(c_champCode,100)]
		public string Code
		{
			get
			{
				return (string)Row[c_champCode];
			}
			set
			{
				Row[c_champCode] = value;
			}
		}

		////////////////////////////////////////////////////////////
        /// <summary>
        /// Donne ou d�finit la description du Calendrier
        /// </summary>
		[DynamicField("Description")]
		[TableFieldProperty(c_champDescription,1024)]
		public string Description
		{
			get
			{
				return (string)Row[c_champDescription];
			}
			set
			{
				Row[c_champDescription] = value;
			}
		}

        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit l'Horaire journalier par d�faut
        /// </summary>
        [Relation(
            CHoraireJournalier.c_nomTable,
            CHoraireJournalier.c_champId,
            CHoraireJournalier.c_champId,
            false,
            false,
            true)]
        [DynamicField("Default daily schedule")]
        public CHoraireJournalier HoraireParDefaut
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



		/////////////////////////////////////////////////////////
		/// <summary>
		/// Retourne la liste des jours particuliers du calendrier,<br/>
        /// c'est � dire la liste des jours auxquels l'horaire journalier par<br/>
        /// d�faut ne s'applique pas.
		/// </summary>
        [RelationFille(typeof(CCalendrier_JourParticulier), "Calendrier")]
		[DynamicChilds("Particular days", typeof(CCalendrier_JourParticulier))]
		public CListeObjetsDonnees JoursParticuliersListe
		{
			get
			{
				return GetDependancesListe ( CCalendrier_JourParticulier.c_nomTable, c_champId );
			}
		}

        /// <summary>
        /// Fonction qui renvoie le tableau des jours particuliers du calendrier en cours et
        /// de tous ses calendriers de base (fonction r�cursive)
        /// </summary>
        /// <returns>Un tableau de jours particuliers</returns>
        [DynamicMethod("Returns all the particular days of the calendar and its parent calendars")]
        public CCalendrier_JourParticulier[] GetTousLesJoursParticuliers()
        {
            ArrayList exceptions = new ArrayList(this.JoursParticuliersListe);
            if (this.CalendrierDeBase != null)
            {
                exceptions.AddRange(CalendrierDeBase.GetTousLesJoursParticuliers());
            }

            return (CCalendrier_JourParticulier[]) exceptions.ToArray(typeof(CCalendrier_JourParticulier));
        }

		/// /////////////////////////////////////////////////////////
		/// <summary>
		/// Calendrier de base (Parent), sur lequel s'appuie<br/>
        /// ce calendrier
		/// </summary>
		[Relation(CCalendrier.c_nomTable,
			 CCalendrier.c_champId,
			 CCalendrier.c_champIdCalendrierDeBase,
			 false,
			 false,
			 false)]
		[DynamicField("Base calendar")]
		public CCalendrier CalendrierDeBase
		{
			get
			{
				return (CCalendrier)GetParent ( c_champIdCalendrierDeBase, typeof(CCalendrier));
			}
			set
			{
				SetParent ( c_champIdCalendrierDeBase, value );
			}
		}

		///////////////////////////////////////////////////////////
        /// <summary>
        /// Retourne la liste des calendriers d�pendants directs (Fils)
        /// </summary>
		[RelationFille ( typeof ( CCalendrier), "CalendrierDeBase")]
        [DynamicChilds("Child Calendars", typeof(CCalendrier))]
		public CListeObjetsDonnees ListeCalendriersDependantsDirects
		{
			get
			{
				return GetDependancesListe(c_nomTable, c_champIdCalendrierDeBase);
			}
		}


        //----------------------------------------------------------------------------
		/// <summary>
		/// Retourne la liste de tous les calendriers d�pendant (fonction r�cursive),<br/>
        /// en parcourant toute le hi�rarchie
		/// </summary>
        [DynamicMethod("Returns the list of all dependent calendars of the hierarchy")]
		public CCalendrier[] GetListeCalendriersDependants()
		{
			Hashtable tableDependants = new Hashtable();
			FillHashtableDependants( tableDependants );
			CCalendrier[] calendriers = new CCalendrier[tableDependants.Keys.Count+1];
			calendriers[0] = this;
			int nIndex = 1;
			foreach ( CCalendrier calendrier in tableDependants.Keys )
				calendriers[nIndex++] = calendrier;
			return calendriers;
		}

		//--------------------------------------------------------------------------------
        /// <summary>
		/// Remplit une Hashtable avec la liste (key) de tous les calendriers
		/// d�pendants
		/// </summary>
		/// <param name="table"></param>
		private void FillHashtableDependants ( Hashtable table )
		{
			CListeObjetsDonnees liste = new CListeObjetsDonnees ( ContexteDonnee, typeof(CCalendrier));
			liste.Filtre = new CFiltreData ( c_champIdCalendrierDeBase+"=@1",
				Id );
			foreach ( CCalendrier calendrier in liste )
			{
				table[calendrier] = true;
				calendrier.FillHashtableDependants ( table );
			}
		}



		//---------------------------------------------------------
		/// <summary>
		/// Acteur auquel appartient ce calendrier
		/// </summary>
		[Relation ( CActeur.c_nomTable,
			 CActeur.c_champId,
			 CActeur.c_champId,
			 false,
			 true,
			 true)]
		[DynamicField("Member")]
		public CActeur Acteur
		{
			get
			{
				return (CActeur)GetParent ( CActeur.c_champId, typeof ( CActeur ) );
			}
			set
			{
				SetParent ( CActeur.c_champId, value );
				if ( Libelle == "" && value != null)
					Libelle = I.T("Calendar of @1|303",value.IdentiteComplete);
			}
		}


        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou d�finit le Type d'occupation horaire par d�faut<br/>
        /// de ce calendrier
        /// </summary>
        [Relation(
            CTypeOccupationHoraire.c_nomTable,
            CTypeOccupationHoraire.c_champId,
            CTypeOccupationHoraire.c_champId,
            false,
            false,
            true)]
		[DynamicField("Diary occupation type")]
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

		//----------------------------------------------------------------------------
		public CTypeOccupationHoraire TypeOccupationHoraireAppliquee
		{
			get
			{
				CTypeOccupationHoraire occ = TypeOccupationHoraire;
				if (occ == null && HoraireParDefaut != null)
					occ = HoraireParDefaut.TypeOccupationHoraire;
				return occ;
			}
		}

		//----------------------------------------------------------------------------
		/// <summary>
		/// Retourne le nombre d'heures param�tr�es dans le calendrier entre deux dates,<br/>
        /// en fonction des horaires journaliers d�finis.
		/// </summary>
		/// <param name="dateDebut">Date de d�but</param>
		/// <param name="dateFin">Date de fin</param>
		/// <returns>Le nombre d'heures</returns>
		//[DynamicMethod("GetTotalHoursBetween", "Start date/time", "End date/time")]
        //public double GetTotalHoursBetween(DateTime dateDebut, DateTime dateFin)
        //{
        //    return GetTotalHoursBetween(dateDebut, dateFin, string.Empty);
        //}

        [DynamicMethod("GetTotalHoursBetween", "Start date/time", "End date/time", "Occupation code")]
        public double GetTotalHoursBetween(DateTime dateDebut, DateTime dateFin, string strCodeTypeOccupation)
        {
            CTrancheHoraire[] tranches = GetHoraires(dateDebut, dateFin);
            double fHeures = 0;
            foreach (CTrancheHoraire tranche in tranches)
            {
                if (tranche.DateHeureFin > dateDebut && tranche.DateHeureDebut < dateFin)
                {
                    if (strCodeTypeOccupation == string.Empty ||
                        tranche.TypeOccupationHoraire.Code.ToUpper() == strCodeTypeOccupation.ToUpper())
                    {
                        DateTime debut = tranche.DateHeureDebut;
                        DateTime fin = tranche.DateHeureFin;
                        if (debut < dateDebut)
                            debut = dateDebut;
                        if (fin > dateFin)
                            fin = dateFin;
                        fHeures += ((TimeSpan)(fin - debut)).TotalHours;
                    }
                }

            }
            return fHeures;
        }


        //------------------------------------------------------------------------------------
        /// <summary>
        /// Ajoute � la date de d�but le nombre d'heures, en ne prenant en compte que les
        /// occupations ayant pour code le code de type d'occupation sp�cifi�.
        /// Le traitement s'arr�te si DateMax est atteinte
        /// </summary>
        /// <param name="strCodeTypeOccupation"></param>
        /// <param name="dateDebut"></param>
        /// <param name="fHeures"></param>
        /// <param name="dateFinMax"></param>
        /// <returns></returns>
        [DynamicMethod("Add hours for specified occupation to the start date",
            "Occupation code",
            "Start date",
            "Hours to add",
            "Max date")]
        public DateTime AddHours ( string strCodeTypeOccupation, DateTime dateDebut, double fHeures, DateTime dateFinMax )
        {
            DateTime debut = dateDebut;
            strCodeTypeOccupation = strCodeTypeOccupation.ToUpper();
            while (true)
            {
                CTrancheHoraire[] tranches = GetHoraires(debut, debut.Date.AddDays(1));
                foreach (CTrancheHoraire tranche in tranches)
                {
                    if (tranche.TypeOccupationHoraire.Code.ToUpper() == strCodeTypeOccupation.ToUpper())
                    {
                        double fTmp = fHeures - tranche.Duree;
                        if (tranche.DateHeureDebut < dateDebut)
                        {
                            fTmp = fHeures - (tranche.DateHeureFin - dateDebut).TotalHours;
                            if (fTmp <= 0)
                                return dateDebut.AddHours(fHeures);
                        }
                        if (fTmp <= 0)
                            return tranche.DateHeureDebut.AddHours(fHeures);
                        fHeures = fTmp;
                    }
                }
                debut = debut.Date.AddDays(1);
                if (debut > dateFinMax)
                    return dateFinMax;
            }
        }

        /// <summary>
        /// Charge tous les jours particuliers de ce calendrier et de ses parents
        /// </summary>
        private void ReadAllJoursParts( )
        {
            object dummy = JoursParticuliersListe;
            if (CalendrierDeBase != null)
                dummy = CalendrierDeBase.JoursParticuliersListe;
        }
                
        //----------------------------------------------------------------------------
        public Dictionary<string, CCalendrier_JourParticulier> GetDicJoursParticuliers()
        {
            //S'assure de la lecture de tous les jours particuliers
            ReadAllJoursParts();
            Dictionary<string, CCalendrier_JourParticulier> dic = null;
            if ( CalendrierDeBase != null )
                dic = CalendrierDeBase.GetDicJoursParticuliers();
            else
                dic = new Dictionary<string,CCalendrier_JourParticulier>();
            foreach ( CCalendrier_JourParticulier jp in JoursParticuliersListe )
                dic[jp.GetKey()] = jp;
            return dic;
        }

        //Retourne toutes les cl�s concernant une date donn�e dans l'ordre de priorit�
        public static string[] GetAllKeysConcernant(DateTime dt)
        {
            return new string[]
            {
                CCalendrier_JourParticulier.GetKeyForJourMoisAnnee(dt.Day, dt.Month, dt.Year),
                CCalendrier_JourParticulier.GetKeyForJourMois(dt.Day, dt.Month),
                CCalendrier_JourParticulier.GetKeyForJourDuMois(dt.Day),
                CCalendrier_JourParticulier.GetKeyJoursDeSemaine(CUtilDate.GetJourBinaireFor(dt.DayOfWeek))
            };
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Retourne une liste des tranches horaires entre une date de d�but et une date de fin
        /// </summary>
        /// <param name="debut"> Date de d�but</param>
        /// <param name="fin"> Date de fin</param>
        /// <returns>La liste des tranches horaires</returns>
        [DynamicMethod(
            "Return a list of time slots between a start and end date ", 
            "Start Date", 
            "End Date")]
        public CTrancheHoraire[] GetHoraires(DateTime debut, DateTime fin)
        {
            Dictionary<string, CCalendrier_JourParticulier> dicJours = GetDicJoursParticuliers();

            if ((debut == null) || (fin == null) || (fin < debut) || this.HoraireParDefaut == null)
                return new CTrancheHoraire[0];

            List<CTrancheHoraire> listeTranches = new List<CTrancheHoraire>();

            // Recherche les EO planifi�es de l'Acteur du calendrier s'il y en a un
            if (Acteur != null)
            {
                listeTranches.AddRange(Acteur.GetHorairesSansCalendrier(debut, fin));
            }


            // Traitement du jour pr�cedent la date de d�but
            IElementATrancheHoraire jourPrecedentDebut = 
                (IElementATrancheHoraire)GetJourParticulierAvecHeritageOptim(debut.Date.AddDays(-1), dicJours);
            if (jourPrecedentDebut == null)
                jourPrecedentDebut = (IElementATrancheHoraire)this.HoraireParDefaut;

            foreach (CHoraireJournalier_Tranche tranche in jourPrecedentDebut.TranchesHorairesListe)
            {
                if (tranche.HeureFin < tranche.HeureDebut)
                {
                    // La tranche est � cheval sur deux jours
                    CTrancheHoraire newTranche = new CTrancheHoraire();
                    // Heure de d�but tronqu�e � 00:00:00
                    newTranche.DateHeureDebut = debut.Date.AddDays(-1); // La veille
                    newTranche.DateHeureDebut = newTranche.DateHeureDebut.AddMinutes(tranche.HeureDebut);
                    // Heure de fin le jour de d�but
                    newTranche.DateHeureFin = debut.Date;
                    newTranche.DateHeureFin = newTranche.DateHeureFin.AddMinutes(tranche.HeureFin);
					newTranche.TypeOccupationHoraire = tranche.TypeOccupationHoraireAppliquee;
                    if (newTranche.TypeOccupationHoraire == null)
                        newTranche.TypeOccupationHoraire = this.TypeOccupationHoraireAppliquee;

                    //Ajout la tranche � la liste
                    if (newTranche.DateHeureFin >= debut && newTranche.DateHeureDebut <= fin)
                        listeTranches.Add(newTranche);
                }
            }


            // Pour chaque jour entre la date de d�but et de fin inclus
            for (DateTime date = debut.Date; date <= fin.Date; date = date.AddDays(1))
            {
                
                // Traite les tranches horaires du Calendrier de l'Acteur
                IElementATrancheHoraire jour = (IElementATrancheHoraire)GetJourParticulierAvecHeritageOptim(date, dicJours);
                
                if (jour == null)
                    jour = (IElementATrancheHoraire)this.HoraireParDefaut;

                if (jour != null)
                    jour = jour.ElementATrancheHoraireApplique;

                if (jour != null)
                {
                    if (jour.TranchesHorairesListe.Count == 0)
                    {
                        //Regle : si un jour particulier n'a pas d'horaires, alors,
                        //il prend l'horaire de ce jour dans le calendrier de base
                        List<CTrancheHoraire> tranches = new List<CTrancheHoraire>();
                        if (CalendrierDeBase != null)
                            tranches.AddRange(CalendrierDeBase.GetHoraires(date, date.AddDays(1)));
                        else
                        {
                            foreach (CHoraireJournalier_Tranche ht in HoraireParDefaut.TranchesHorairesListe)
                            {
                                CTrancheHoraire newTranche = new CTrancheHoraire();
                                newTranche.TypeOccupationHoraire = jour.TypeOccupationHoraire;
                                newTranche.DateHeureDebut = date.Date;
                                newTranche.DateHeureDebut = newTranche.DateHeureDebut.AddMinutes(ht.HeureDebut);
                                // On ne prend que celles qui commencent ce jour l�
                                newTranche.DateHeureFin = (ht.HeureFin > ht.HeureDebut) ?
                                                           date.Date : date.AddDays(1).Date;
                                newTranche.DateHeureFin = newTranche.DateHeureFin.AddMinutes(ht.HeureFin);
                                tranches.Add(newTranche);
                            }
                        }
                        foreach (CTrancheHoraire tr in tranches)
                        {
                            if (tr.DateHeureDebut < fin && tr.DateHeureFin > debut)
                            {
                                CTrancheHoraire newTranche = new CTrancheHoraire();
                                newTranche.DateHeureDebut = tr.DateHeureDebut;
                                newTranche.DateHeureFin = tr.DateHeureFin;
                                newTranche.TypeOccupationHoraire = jour.TypeOccupationHoraire;
                                if (newTranche.TypeOccupationHoraire == null)
                                    newTranche.TypeOccupationHoraire = this.TypeOccupationHoraireAppliquee;

                                listeTranches.Add(newTranche);
                            }
                        }

                    }
                    else
                    {
                        foreach (CHoraireJournalier_Tranche tranche in jour.TranchesHorairesListe)
                        {
                            CTrancheHoraire newTranche = new CTrancheHoraire();
                            newTranche.DateHeureDebut = date.Date;
                            newTranche.DateHeureDebut = newTranche.DateHeureDebut.AddMinutes(tranche.HeureDebut);
                            // On ne prend que celles qui commencent ce jour l�
                            newTranche.DateHeureFin = (tranche.HeureFin > tranche.HeureDebut) ?
                                                       date.Date : date.AddDays(1).Date;
                            newTranche.DateHeureFin = newTranche.DateHeureFin.AddMinutes(tranche.HeureFin);

                            newTranche.TypeOccupationHoraire = tranche.TypeOccupationHoraireAppliquee;
                            if (newTranche.TypeOccupationHoraire == null)
                                newTranche.TypeOccupationHoraire = this.TypeOccupationHoraireAppliquee;

                            if (newTranche.DateHeureFin >= debut && newTranche.DateHeureDebut <= fin)
                                listeTranches.Add(newTranche);
                        }
                    }
                }
            
            }

            // Traitement des priorit�s
            List<CTrancheHoraire> listeTraitee = TraitePrioritesTranches(listeTranches);

            listeTraitee.Sort(new CTrancheHoraire.PrioriteComparer());
            return (CTrancheHoraire[])listeTraitee.ToArray();
        }


        //----------------------------------------------------------------------------------------
        private List<CTrancheHoraire> TraitePrioritesTranches(List<CTrancheHoraire> listeATraiter)
        {
            List<CTrancheHoraire> listeTraitee = new List<CTrancheHoraire>();
            
            // Parcoure les �venements temporels de d�but et de fin de tranche

            List<CChangementTranche> lstChangementTranches = new List<CChangementTranche>();
            foreach (CTrancheHoraire tranche in listeATraiter)
            {
                lstChangementTranches.Add(new CChangementTranche(tranche.DateHeureDebut, tranche, CChangementTranche.EChangement.Debut));
                lstChangementTranches.Add(new CChangementTranche(tranche.DateHeureFin, tranche, CChangementTranche.EChangement.Fin));
            }
            lstChangementTranches.Sort(new CChangementTranche.ComparateurSurDateHeure());

            // On construit les nouvelles tranches horaires en foncion des priorit�s
            CListeTranchesHoraires listeTempon = new CListeTranchesHoraires();
            // Priorit� en cours initialis�e � -1 pour forcer le d�marrage du processus
            int nPrioriteEnCours = -1;
            CTrancheHoraire trancheEnCours = null;
            foreach (CChangementTranche evenement in lstChangementTranches)
            {
                int nNouvellePriorite = -2;
                bool bCreateNext = false;
                if(evenement.changement == CChangementTranche.EChangement.Debut)
                {
                    if(!listeTempon.Contains(evenement.Tranche))
                        listeTempon.AddAndSort(evenement.Tranche);
                    nNouvellePriorite = listeTempon[0].Priorite;
                    //nNouvellePriorite = tpOccup != null ? tpOccup.Priorite : 0;
                    bCreateNext = true;
                }
                else
                {
                    if (listeTempon.Contains(evenement.Tranche))
                        listeTempon.Remove(evenement.Tranche);
                    if (listeTempon.Count > 0)
                    {
                        nNouvellePriorite = listeTempon[0].Priorite;
                        //nNouvellePriorite = tpOccup != null ? tpOccup.Priorite : 0;
                        bCreateNext = true;
                    }
                    else
                    {
						nPrioriteEnCours = -1;
                        nNouvellePriorite = -2;
                        bCreateNext = false;
                    }

                }
                // La priorit� la plus haute est toujours au d�but de la liste
                if (nNouvellePriorite != nPrioriteEnCours)
                {
                    // On change de tranche
                    if (trancheEnCours != null)
                    {
                        // "Ferme" la tranche en cours et l'ajoute � la liste finale
                        trancheEnCours.DateHeureFin = evenement.DateHeure;
                        listeTraitee.Add(trancheEnCours);
                        trancheEnCours = null;
                    }
                    if (bCreateNext)
                    {
                        // "Ouvre" une nouvelle tranche
                        trancheEnCours = new CTrancheHoraire();
                        trancheEnCours.DateHeureDebut = evenement.DateHeure;
                        trancheEnCours.TypeOccupationHoraire = listeTempon[0].TypeOccupationHoraire;
                        nPrioriteEnCours = nNouvellePriorite;
                    }
                }
                

            }

            return listeTraitee;

        }

        //-------------------------------------------------------
        private class CChangementTranche
        {
            public enum EChangement
            {
                Debut = 0,
                Fin = 1,
            }

            public readonly DateTime DateHeure;
            public readonly CTrancheHoraire Tranche = null;
            public readonly EChangement changement;

            public CChangementTranche(DateTime dt, CTrancheHoraire tr, EChangement ch)
            {
                DateHeure = dt;
                Tranche = tr;
                changement = ch;
            }

            // Compare sur Date Heure puis sur Fin/D�but
            public class ComparateurSurDateHeure : IComparer<CChangementTranche>
            {
                public int Compare(CChangementTranche x, CChangementTranche y)
                {
                    int nResCompare = 0;
                    nResCompare = DateTime.Compare(x.DateHeure, y.DateHeure);
                    // Si les deux dates sont identiques, la Fin d'une tranche doit �tre avant le d�but de l'autre tranche
                    if (nResCompare == 0)
                    {
                        if ((int)x.changement > (int)y.changement)
                            nResCompare = -1;
                        if ((int)x.changement < (int)y.changement)
                            nResCompare = 1;
                    }

                    return nResCompare;
                }
            }

            //public class ComparateurSurTypeChangement : IComparer<CChangementTranche>
            //{
            //    public int Compare(CChangementTranche x, CChangementTranche y)
            //    {
            //        if ((int)y.changement > (int)x.changement)
            //            return 1;
            //        if ((int)y.changement < (int)x.changement)
            //            return -1;

            //    }
            //}

        }

        //----------------------------------------------------------------------------------------
        private class CListeTranchesHoraires : List<CTrancheHoraire> 
        {
            private CTrancheHoraire.PrioriteComparer comparateurTranches = new CTrancheHoraire.PrioriteComparer();
            public CListeTranchesHoraires()
            {
                
            }

            public void AddAndSort(CTrancheHoraire tranche)
            {
                this.Add(tranche);
                this.Sort(comparateurTranches);
            }

        }
        
        //----------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne tous les jours particuliers
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private CCalendrier_JourParticulier GetJourParticulierAvecHeritage(DateTime date, bool bAutoriseLectureEnBase)
        {
            CCalendrier_JourParticulier jourParticulier = new CCalendrier_JourParticulier(this.ContexteDonnee);
            CCalendrier_JourParticulier jourParticulierHerite = new CCalendrier_JourParticulier(this.ContexteDonnee);

            if (this.CalendrierDeBase != null)
            {
                jourParticulierHerite = this.CalendrierDeBase.GetJourParticulierAvecHeritage(date, bAutoriseLectureEnBase);
            }
            else
                jourParticulierHerite = null;

            // V�rifie s'il existe une exception "jour/mois/ann�e" sur le jour du calendrier s�lectionn�
            if (jourParticulier.ReadIfExists(new CFiltreData(
                CCalendrier_JourParticulier.c_champAnnee + "=@1 and " +
                CCalendrier_JourParticulier.c_champMois + "=@2 and " +
                CCalendrier_JourParticulier.c_champJour + "=@3 and " +
                CCalendrier.c_champId + "=@4",
                date.Year,
                date.Month,
                date.Day,
                this.Id), bAutoriseLectureEnBase))
            {
                return jourParticulier;
            }
            // V�rifie s'il existe une exception "jour/mois/ann�e" sur le jour du calendrier de base
            if (jourParticulierHerite != null && jourParticulierHerite.Annee != null)
                return jourParticulierHerite;

            // V�rifie s'il existe une exception "jour/mois" sur le jour du calendrier s�lectionn�
            if (jourParticulier.ReadIfExists(new CFiltreData(
                CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                CCalendrier_JourParticulier.c_champMois + "=@1 and " +
                CCalendrier_JourParticulier.c_champJour + "=@2 and " +
                CCalendrier.c_champId + "=@3",
                date.Month,
                date.Day,
                this.Id), bAutoriseLectureEnBase))
            {
                return jourParticulier;
            }
            // V�rifie s'il existe une exception "jour/mois" sur le jour du calendrier de base
            if (jourParticulierHerite != null && jourParticulierHerite.Mois != null)
                return jourParticulierHerite;

            // V�rifie s'il existe une exception "jour du mois" sur le jour du calendrier s�lectionn�
            if (jourParticulier.ReadIfExists(new CFiltreData(
                CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                CCalendrier_JourParticulier.c_champMois + " is null and " +
                CCalendrier_JourParticulier.c_champJour + "=@1 and " +
                CCalendrier.c_champId + "=@2",
                date.Day,
                this.Id), bAutoriseLectureEnBase))
            {
                return jourParticulier;
            }
            // V�rifie s'il existe une exception "jour" sur le jour du calendrier de base
            if (jourParticulierHerite != null && jourParticulierHerite.Jour != null)
                return jourParticulierHerite;

            // V�rifie s'il existe une exception "jour de semaine" sur le jour du calendrier s�lectionn�
            if (jourParticulier.ReadIfExists(new CFiltreData(
                CCalendrier_JourParticulier.c_champAnnee + " is null and " +
                CCalendrier_JourParticulier.c_champMois + " is null and " +
                CCalendrier_JourParticulier.c_champJour + " is null and " +
                CCalendrier_JourParticulier.c_champJourSemaine + "=@1 and " +
                CCalendrier.c_champId + "=@2",
                (int)CUtilDate.GetJourBinaireFor(date.DayOfWeek),
                this.Id), bAutoriseLectureEnBase))
            {
                return jourParticulier;
            }
            // V�rifie s'il existe une exception "jour de semaine" sur le jour du calendrier de base
            if (jourParticulierHerite != null && jourParticulierHerite.JourSemaine != 0)
                return jourParticulierHerite;

            return null;
        }

        //----------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne tous les jours particuliers
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private CCalendrier_JourParticulier GetJourParticulierAvecHeritageOptim(DateTime date, Dictionary<string, CCalendrier_JourParticulier> dicJoursParticuliers )
        {
            CCalendrier_JourParticulier jourParticulier = new CCalendrier_JourParticulier(this.ContexteDonnee);
            

            foreach (string strKey in GetAllKeysConcernant(date))
            {
                if (dicJoursParticuliers.TryGetValue(strKey, out jourParticulier))
                    return jourParticulier;
            }

            return null;
        }



		#region IObjetDonneeAutoReference Membres

		public string ChampParent
		{
			get { return c_champIdCalendrierDeBase;  }
		}

		public string ProprieteListeFils
		{
			get { return "ListeCalendriersDependantsDirects"; }
		}

		#endregion
	}

	public interface IElementACalendrier
	{
		CCalendrier CalendrierOuverture { get;}
	}

    //------------------------------------------------------------------------------
    /// <summary>
    /// Tranche horaire pour <see cref="CCalendrier">calendrier</see>
    /// </summary>
    [DynamicClass("Time Slot")]
	public class CTrancheHoraire
    {
        public CTrancheHoraire()
        {
        }

        private DateTime m_dateHeureDebut;
        private DateTime m_dateHeureFin;
        private CTypeOccupationHoraire m_typeOccupationHoraire;

        /// <summary>
        /// Donne ou d�finit la date de d�but de la tranche
        /// </summary>
		[DynamicField("Start date")]
        public DateTime DateHeureDebut
        {
            get { return m_dateHeureDebut; }
            set { m_dateHeureDebut = value; }
        }

        /// <summary>
        /// Donne ou d�finit la date de fin de la tranche
        /// </summary>
		[DynamicField("End date")]
        public DateTime DateHeureFin
        {
            get { return m_dateHeureFin; }
            set { m_dateHeureFin = value; }
        }

        /// <summary>
        /// Donne ou d�finit le type d'occupation pour cette tranche
        /// </summary>
		[DynamicField("Occupation")]
        public CTypeOccupationHoraire TypeOccupationHoraire
        {
            get
            {
                return m_typeOccupationHoraire; 
            }

            set
            {
                m_typeOccupationHoraire = value; 
            }
        }

        public int Priorite
        {
            get
            {
                if (TypeOccupationHoraire == null)
                    return 0;
                return TypeOccupationHoraire.Priorite;
            }
        }


        /// <summary>
        /// Donne le dur�e en heures de la tranche
        /// </summary>
		[DynamicField("Duration")]
		public double Duree
		{
			get
			{
				TimeSpan sp = DateHeureFin - DateHeureDebut;
				return sp.TotalHours;
			}
		}

        ///////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        public class PrioriteComparer : IComparer<CTrancheHoraire>
        {

            public int Compare(CTrancheHoraire x, CTrancheHoraire y)
            {
                int nResult = 0;
                CTypeOccupationHoraire_PrioriteComparer comparer = new CTypeOccupationHoraire_PrioriteComparer();
                nResult = comparer.Compare(x.TypeOccupationHoraire, y.TypeOccupationHoraire);
                // Inverse le sens de la comparaison pour obtenir un tri d�croissant
                nResult = -nResult;
                return nResult;
            }


        }
    }


}

