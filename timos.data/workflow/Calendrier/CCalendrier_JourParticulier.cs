using System;
using System.IO;
using System.Data;
using System.Collections.Generic;

using sc2i.common;
using sc2i.data;
using sc2i.documents;
using System.Text;


namespace sc2i.workflow
{
	/// <summary>
    /// Un jour particulier est un jour du calendrier auquel ne s'applique pas <br/>
    /// l'horaire journalier par défaut. Il doit donc définir un autre horaire pour ce jour là
	/// </summary>
	/// <remarks>
	/// Il est possible d'indiquer qu'un jour particulier s'applique tous les mois, tous les ans, 
    /// tous les jour de semaine ou un jour précis.<br/>
    /// Exemples de jours particuliers:<br/>
    /// <list type="bullet">
    /// <item><term>Cas 1: </term><description>Tous les 28 du mois</description></item>
    /// <item><term>Cas 2: </term><description>Tous les 15 mars </description></item>
    /// <item><term>Cas 3: </term><description>Tous les dimanches</description></item>
    /// <item><term>Cas 4: </term><description>Le 29 avril 2000</description></item>
    /// </list>
	/// </remarks>
    [sc2i.doccode.DocRefMenusOrMenuItems(timos.data.CDocLabels.c_iPlanif)]
    [Table(CCalendrier_JourParticulier.c_nomTable, CCalendrier_JourParticulier.c_champId, true)]
	[ObjetServeurURI("CCalendrier_JourParticulierServeur")]
	[DynamicClass("Calendar Particular day")]
	[FullTableSync]
	public class CCalendrier_JourParticulier : CObjetDonneeAIdNumeriqueAuto, 
                                                IObjetALectureTableComplete,
                                                IElementATrancheHoraire
	{
		public const string c_nomTable = "CALENDAR_DAY";
		
		public const string c_champId = "CALENDDAY_ID";
		public const string c_champHoraireJournalier = "CALENDDAY_DAY_SCHEDULE";

        public const string c_champJourSemaine = "CALENDDAY_WEEKDAY";
		public const string c_champJour = "CALENDDAY_DAY";
		public const string c_champMois = "CALENDDAY_MONTH";
		public const string c_champAnnee = "CALENDDAY_YEAR";

		//-------------------------------------------------------------------
		//Préferer la fonction AssocieDocument de CCategorieDocument
		public CCalendrier_JourParticulier( CContexteDonnee contexte)
			:base(contexte)
		{
		}

		//-------------------------------------------------------------------
		public CCalendrier_JourParticulier(DataRow row )
			:base(row)
		{
		}

		//-------------------------------------------------------------------
		public override string DescriptionElement
		{
			get
			{
                return I.T( "The Day of Calendar|405");
			}
		}

		//-------------------------------------------------------------------
		protected override void MyInitValeurDefaut()
		{
            //Jour = 1;
            //Mois = 1;
            //Annee = 2007;
            JourSemaine = 0;
		}


		public override string[] GetChampsTriParDefaut()
		{
			return new string[]{c_champAnnee+","+ c_champMois+","+c_champJour};
		}

		/// <summary>
		/// Le libellé du jour particulier
		/// </summary>
        [DynamicField("Label")]
		public string Libelle
		{
			get
			{
				string strRetour = "";
				bool bTousLes = true;
				if (JourSemaine != JoursBinaires.Aucun)
					strRetour = CUtilDate.GetNomJour(CUtilDate.GetDayOfWeekFor ( JourSemaine ),false);
				if (Jour != null)
				{
					strRetour = ((int)Jour).ToString("00");
				}
				if (Mois != null)
				{
					strRetour += "/"+((int)Mois).ToString("00");
				}
				if (Annee != null)
				{
					strRetour += "/" + ((int)Annee).ToString("0000");
					bTousLes = false;
				}
				strRetour = " "+strRetour;
				if (bTousLes)
					strRetour = I.T( "Every @1|214", strRetour);
				else
					strRetour = I.T( "The @1|215", strRetour);
				return strRetour;
			}
		}


        //-------------------------------------------------------------------
        public static string GetKeyJoursDeSemaine(JoursBinaires jour)
        {
            return "JS" + jour.ToString() ;
        }

        //-------------------------------------------------------------------
        public static string GetKeyForJourDuMois(int nJour)
        {
            return "D" + nJour.ToString();
        }

        //-------------------------------------------------------------------
        public static string GetKeyForMois(int nMois)
        {
            return "M" + nMois.ToString();
        }

        //-------------------------------------------------------------------
        public static string GetKeyForAnnee(int nYear)
        {
            return "Y" + nYear.ToString();
        }

        //-------------------------------------------------------------------
        public static string GetKeyForJourMoisAnnee(int nJour, int nMois, int nAnnee)
        {
            return GetKeyForJourMois(nJour, nMois) + GetKeyForAnnee(nAnnee);
        }

        //-------------------------------------------------------------------
        public static string GetKeyForJourMois(int nJour, int nMois)
        {
            return GetKeyForJourDuMois(nJour) + GetKeyForMois(nMois);
        }
        

        /// <summary>
        /// Retourne une chaine qui reflete à quel jour correspond ce jour particulier.
        /// Si deux jours particuliers concernent le même moment  (par exemple tous les X du mois), 
        /// Ils ont la même clé
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            StringBuilder bl = new StringBuilder();
            if (JourSemaine != JoursBinaires.Aucun)
                bl.Append(GetKeyJoursDeSemaine (JourSemaine));
            else
            {
                if (Jour != null)
                    bl.Append(GetKeyForJourDuMois(Jour.Value));
                if (Mois != null)
                    bl.Append(GetKeyForMois(Mois.Value));
                if (Annee != null)
                    bl.Append(GetKeyForAnnee(Annee.Value));
            }
            return bl.ToString();
        }
                   

		//-------------------------------------------------------------------
        /// <summary>
        /// Le Calendrier Parent concerné par ce jour particulier
        /// </summary>
		[Relation(
            CCalendrier.c_nomTable,
			CCalendrier.c_champId,
			CCalendrier.c_champId,
			true,
			true,
			true)]
		[DynamicField("Calendar")]
		public CCalendrier Calendrier
		{
			get
			{
				return (CCalendrier)GetParent ( CCalendrier.c_champId, typeof(CCalendrier));
			}
			set
			{
				SetParent ( CCalendrier.c_champId, value );
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Année de la date.<br/>
        /// Si null, indique que l'état de la date se répète chaque année.<br/>
        /// Par exemple :
        /// <ul>
        /// <li>Si le jour particulier est 'tous les 15 août',<br/>
        /// cette propriété renvoie null</li>
        /// <li>Si le jour particulier est le 02/01/2012,<br/>
        /// cette propriété renvoie 2012</li>
        /// </ul>
		/// </summary>
		[TableFieldProperty ( c_champAnnee, NullAutorise = true )]
		[DynamicField("Particular year")]
		public int? Annee
		{
			get
			{
                if (Row[c_champAnnee] == DBNull.Value)
                    return null;
                else
				    return ( int )Row[c_champAnnee];
			}
			set
			{
                if (value == null)
                    Row[c_champAnnee] = DBNull.Value;
                else
				    Row[c_champAnnee] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Mois de la date.<br/>
        /// Si null, indique que l'état de la date se répète chaque mois.<br/>
        /// Par exemple :
        /// <ul>
        /// <li>Si le jour particulier est 'tous les 8 du mois',<br/>
        /// cette propriété renvoie null</li>
        /// <li>Si le jour particulier est 'tous les 8 mai',<br/>
        /// cette propriété renvoie 5</li>
        /// </ul> 
		/// </summary>
        [TableFieldProperty(c_champMois, NullAutorise = true)]
		[DynamicField("Particular month")]
		public int? Mois
		{
			get
			{   
                if(Row[c_champMois] == DBNull.Value)
                    return null;
                else             
				    return ( int )Row[c_champMois];
			}
			set
			{
                if (value == null)
                    Row[c_champMois] = DBNull.Value;
                else
                    Row[c_champMois] = value;
			}
		}

		//-------------------------------------------------------------------
		/// <summary>
		/// Jour de la date.<br/>
        /// Si null, indique que l'état de la date se répète chaque même jour de chaque semaine.<br/>
        /// Par exemple :
        /// <ul>
        /// <li>Si le jour particulier est 'tous les mardi',<br/>
        /// cette propriété renvoie null</li>
        /// <li>Si le jour particulier est 'tous les 8 mai',<br/>
        /// cette propriété renvoie 8</li>
        /// </ul> 
		/// </summary>
        [TableFieldProperty(c_champJour, NullAutorise = true)]
		[DynamicField("Particular day")]
		public int? Jour
		{
			get
			{
                if (Row[c_champJour] == DBNull.Value)
                    return null;
                else
                    return (int)Row[c_champJour];
			}
			set
			{
                if (value == null)
                    Row[c_champJour] = DBNull.Value;
                else
                    Row[c_champJour] = value;
			}
		}



        /// /////////////////////////////////////////////////////////
        /// <summary>
        /// Définit ou renvoie le jour de la semaine
        /// </summary>
        /// <remarks>
        /// Ce champ est une combinaison binaire des valeurs de jours.
        /// <LI>Aucun = 0</LI>
        /// <LI>Lundi = 1</LI>
        /// <LI>Mardi = 2</LI>
        /// <LI>Mercredi = 4</LI>
        /// <LI>Jeudi = 8</LI>
        /// <LI>Vendredi = 16</LI>
        /// <LI>Samedi = 32</LI>
        /// <LI>Dimanche = 64</LI>
        /// Une valeur de 96 (64+32) indique que samedi et dimanche sont inversés.
        /// </remarks>
        [TableFieldProperty(c_champJourSemaine)]
        public JoursBinaires JourSemaine
        {
            get
            {
                return (JoursBinaires)Row[c_champJourSemaine];
            }
            set
            {
                Row[c_champJourSemaine] = value;
            }
        }


        //-------------------------------------------------------------------
        /// <summary>
        /// Jour de la semaine.<br/>
        /// Si null, indique que l'état de la date ne se répète pas chaque même jour de chaque semaine.<br/>
        /// Par exemple :
        /// <ul>
        /// <li>Si le jour particulier est 'tous les mardi',<br/>
        /// cette propriété renvoie 2</li>
        /// <li>Si le jour particulier est 'tous les 8 mai',<br/>
        /// cette propriété renvoie null</li>
        /// </ul> 
        /// </summary>
        [DynamicField("Particular Week day value")]
        public int JourSemaineInt
        {
            get { return (int) JourSemaine; }
            set { JourSemaine =  (JoursBinaires) value; }
        }

        /// <summary>
        /// Lorsque le jour particulier se répète chaque même jour de chaque semaine,<br/>
        /// revoie ce jour en toutes lettres (par exemple 'mardi')
        /// </summary>
        [DynamicField("Week day text")]
        public string JourSemaineNom
        {
            get
            {
                if (JourSemaine == JoursBinaires.Aucun)
                    return "";
                return CUtilDate.GetNomJour(CUtilDate.GetDayOfWeekFor(JourSemaine), false);
            }
        }


        //--------------------------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit l'horaire journalier par défaut de ce jour particulier
        /// </summary>
        [Relation(
            CHoraireJournalier.c_nomTable,
            CHoraireJournalier.c_champId,
            CHoraireJournalier.c_champId,
            false,
            false,
            true)]
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

        //-------------------------------------------------------------------
        /// <summary>
        /// Donne ou définit le Type d'occupation horaire par défaut<br/>
        /// de ce jour particulier
        /// </summary>
        [Relation(
            CTypeOccupationHoraire.c_nomTable,
            CTypeOccupationHoraire.c_champId,
            CTypeOccupationHoraire.c_champId,
            false,
            false,
            true)]
        [DynamicField("Occupation type")]
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

		//---------------------------------------------
		public CTypeOccupationHoraire TypeOccupationHoraireAppliquee
		{
			get
			{
				if (HoraireJournalier != null && HoraireJournalier.TypeOccupationHoraireAppliquee != null)
					return HoraireJournalier.TypeOccupationHoraireAppliquee;
					
				CTypeOccupationHoraire occ = TypeOccupationHoraire;
				if (occ == null && Calendrier != null)
					occ = Calendrier.TypeOccupationHoraireAppliquee;
				return occ;
			}
		}

		//---------------------------------------------
		public IElementATrancheHoraire ElementATrancheHoraireApplique
		{
			get
			{
				if (HoraireJournalier != null)
					return HoraireJournalier;
				return this;
			}
		}


        //------------------------------------------------------------------------
        /// <summary>
        /// Retourne la liste des tranches horaires de ce jour particulier
        /// </summary>
        [RelationFille(typeof(CHoraireJournalier_Tranche), "JourParticulier")]
        [DynamicChilds("Parts", typeof(CHoraireJournalier_Tranche))]
        public CListeObjetsDonnees TranchesHorairesListe
        {
            get
            {
                return GetDependancesListeProgressive(CHoraireJournalier_Tranche.c_nomTable, c_champId);
            }
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Compare les propriétés d'un jour particlier avec un autre
        /// </summary>
        /// <param name="jpAComparer"></param>
        /// <returns>true si les propriétés sont identiques (définissent une même règle)</returns>
        public bool HasSameProperties(CCalendrier_JourParticulier jpAComparer)
        {
            if (jpAComparer == null)
                return false;
            
            if (jpAComparer.Calendrier != this.Calendrier)
                return false;

            if (jpAComparer.HoraireJournalier != this.HoraireJournalier)
                return false;

            if (jpAComparer.TypeOccupationHoraire != this.TypeOccupationHoraire)
                return false;

            // Compare les tranches horaires
            CListeObjetsDonnees listeThis = this.TranchesHorairesListe;
            CListeObjetsDonnees listeAComparer = jpAComparer.TranchesHorairesListe;

            if (listeThis.Count != listeAComparer.Count)
                return false;

            // Trier 
            listeThis.Tri = CHoraireJournalier_Tranche.c_champHeureDebut;
            listeAComparer.Tri = CHoraireJournalier_Tranche.c_champHeureDebut;

            for (int i = 0; i < listeThis.Count; i++)
            {
                CHoraireJournalier_Tranche t1 = (CHoraireJournalier_Tranche) listeThis[i];
                CHoraireJournalier_Tranche t2 = (CHoraireJournalier_Tranche) listeAComparer[i];
                if (!t2.HasSameProperties(t1))
                {
                    return false;
                }
            }
            
            // Toutes les comparaisons sont OK
            return true;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Copie toutes les propriétés d'un jour particulier et les applique
        /// au jour particulier en cours d'édition
        /// </summary>
        /// <param name="jpACopier">Jour particulier à copier</param>
        /// <returns>TRUE si l'opération s'est bien passée, FALSE dans le cas contraire</returns>
        [DynamicMethod(
            "Copy the one particular day properties to the particular day in progress",
            "The particular day to copy")]
        public bool ApplySameProperties(CCalendrier_JourParticulier jpACopier)
        {
            if (jpACopier == null)
                return false;
            if (jpACopier == this)
                return true;

            Calendrier = jpACopier.Calendrier;
            HoraireJournalier = jpACopier.HoraireJournalier;
            TypeOccupationHoraire = jpACopier.TypeOccupationHoraire;

			//Recopie les tranches sur les existantes
			int nIndex = 0;
			CListeObjetsDonnees listeMesTranches = TranchesHorairesListe;
			foreach (CHoraireJournalier_Tranche tranche in jpACopier.TranchesHorairesListe)
			{

				CHoraireJournalier_Tranche laTrancheQuiMeVa;
				if (nIndex >= listeMesTranches.Count)
				{
					laTrancheQuiMeVa = new CHoraireJournalier_Tranche(this.ContexteDonnee);
					laTrancheQuiMeVa.CreateNewInCurrentContexte();
				}
				else
					laTrancheQuiMeVa = (CHoraireJournalier_Tranche)listeMesTranches[nIndex];
				laTrancheQuiMeVa.JourParticulier = this;
				laTrancheQuiMeVa.HeureDebut = tranche.HeureDebut;
				laTrancheQuiMeVa.HeureFin = tranche.HeureFin;
				laTrancheQuiMeVa.TypeOccupationHoraire = tranche.TypeOccupationHoraire;
				nIndex++;
			}

			for (nIndex = jpACopier.TranchesHorairesListe.Count; nIndex < listeMesTranches.Count; nIndex++)
				if (!((CObjetDonnee)listeMesTranches[nIndex]).Delete())
					return false;
			return true;
		}

    }
}
