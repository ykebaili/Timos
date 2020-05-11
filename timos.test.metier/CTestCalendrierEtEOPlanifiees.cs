using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

using sc2i.data;
using sc2i.common;
using timos.data;
using timos.client;
using timos.acteurs;
using System.Data;
using sc2i.data.dynamic;
using sc2i.workflow;
using timos.securite;

namespace timos.test.metier
{
    /////////////////////////////////////////////////////////
    /// <summary>
    /// Test de la gestions des tranches horaires d'un Acteur avec Type d'occupation en fonction
    /// de son calendrier et de ces EO planifiées
    /// 
    /// </summary>
	[TestFixture]
	public class CTestCalendrierEtEOPlanifiees	
	{
		private CContexteDonnee m_contexteDonnee;
		// L'acteur de test
        private const string c_strNomActeur = "TECHNICIEN 1";
        private int m_nIdActeur = -1;
        // Les Type d'occupation horaires
        private int m_nIdOccupationRepos = -1;
        private int m_nIdOccupationJour = -1;
        private int m_nIdOccupationAstreinte = -1;
        private const string c_strRepos = "REPOS";
        private const string c_strJour = "TRAVAIL JOUR";
        private const string c_strAstreinte = "ASTREINTE";
        // Le Calendier
        private const string c_strLabelCalendrier = "CALENDRIER DU TECHNICIEN 1";
        private int m_nIdCalendrier = -1;
        // Horaire journalier
        private const string c_strLabelHoraireJournalier = "HORAIRE JOUNALIER TEST";
        private int m_nIdHoraireJournalier = -1;
        // l'EO de test
        private int m_nIdTypeEO = -1;
        private const string c_strLabelTypeEO = "TP_EO_NUNIT";
        private int m_nIdEO = -1;
        private const string c_strLabelEO = "EO_NUNIT";

		
		[SetUp]
		public void SetUptTest()
		{
			CResultAErreur result = CResultAErreur.True;
			CTimosTestMetierApp.AssureInit();
			m_contexteDonnee = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false);
                        
            //Création de l'acteur de test
			CActeur acteur = new CActeur ( m_contexteDonnee );
			if ( !acteur.ReadIfExists ( new CFiltreData ( CActeur.c_champNom+"=@1",
				c_strNomActeur ) ))
			{
				acteur.CreateNew();
                acteur.Nom = c_strNomActeur;
			    acteur.Prenom = "Youcef";
				result = acteur.CommitEdit();
				Assert.IsTrue ( result.Result );
			}
			m_nIdActeur = acteur.Id;

            // Création des Types d'occupation horraire
            // Repos
            CTypeOccupationHoraire toRepos = new CTypeOccupationHoraire(m_contexteDonnee);
            if (!toRepos.ReadIfExists(
                new CFiltreData(CTypeOccupationHoraire.c_champLibelle + "=@1", c_strRepos)))
            {
                toRepos.CreateNew();
                toRepos.Libelle = c_strRepos;
                toRepos.Priorite = 10;
                result = toRepos.CommitEdit();
                Assert.IsTrue(result.Result);
            }
            m_nIdOccupationRepos = toRepos.Id;
            // Jour
            CTypeOccupationHoraire toJour = new CTypeOccupationHoraire(m_contexteDonnee);
            if (!toJour.ReadIfExists(
                new CFiltreData(CTypeOccupationHoraire.c_champLibelle + "=@1", c_strJour)))
            {
                toJour.CreateNew();
                toJour.Libelle = c_strJour;
                toJour.Priorite = 50;
                result = toJour.CommitEdit();
                Assert.IsTrue(result.Result);
            }
            m_nIdOccupationJour = toJour.Id;
            // Astreinte
            CTypeOccupationHoraire toAstreinte = new CTypeOccupationHoraire(m_contexteDonnee);
            if (!toAstreinte.ReadIfExists(
                new CFiltreData(CTypeOccupationHoraire.c_champLibelle + "=@1", c_strAstreinte)))
            {
                toAstreinte.CreateNew();
                toAstreinte.Libelle = c_strAstreinte;
                toAstreinte.Priorite = 100;
                result = toAstreinte.CommitEdit();
                Assert.IsTrue(result.Result);
            }
            m_nIdOccupationAstreinte = toAstreinte.Id;

            // Création de l'Horaire journalier
            CHoraireJournalier horaire = new CHoraireJournalier(m_contexteDonnee);
            if (!horaire.ReadIfExists(
                new CFiltreData(CHoraireJournalier.c_champLibelle + "=@1", c_strLabelHoraireJournalier)))
            {
                horaire.CreateNew();
                horaire.Libelle = c_strLabelHoraireJournalier;
                result = horaire.CommitEdit();
                Assert.IsTrue(result.Result);
            }
            m_nIdHoraireJournalier = horaire.Id;

            // Création du Calendier
            CCalendrier calendrier = new CCalendrier(m_contexteDonnee);
            if (!calendrier.ReadIfExists(
                new CFiltreData(CCalendrier.c_champLibelle + "=@1", c_strLabelCalendrier)))
            {
                calendrier.CreateNew();
                calendrier.Libelle = c_strLabelCalendrier;
                calendrier.Acteur = acteur;
                calendrier.HoraireParDefaut = horaire;
                result = calendrier.CommitEdit();
                Assert.IsTrue(result.Result);
            }
            m_nIdCalendrier = calendrier.Id;

            // CRéation de l'EO de test
            CTypeEntiteOrganisationnelle tpEO = new CTypeEntiteOrganisationnelle(m_contexteDonnee);
            if(!tpEO.ReadIfExists(
                new CFiltreData(CTypeEntiteOrganisationnelle.c_champLibelle + "=@1", c_strLabelTypeEO)))
            {
                tpEO.CreateNew();
                tpEO.Libelle = c_strLabelTypeEO;
                Assert.IsTrue(tpEO.CommitEdit());
            }
            m_nIdTypeEO = tpEO.Id;

            CEntiteOrganisationnelle eo = new CEntiteOrganisationnelle(m_contexteDonnee);
            if (!eo.ReadIfExists(
                new CFiltreData(CEntiteOrganisationnelle.c_champLibelle + "=@1", c_strLabelEO)))
            {
                eo.CreateNew();
                eo.Libelle = c_strLabelEO;
                eo.TypeEntite = tpEO;
                Assert.IsTrue(eo.CommitEdit());
            }
            m_nIdEO = eo.Id;

            // Affecte l'EO à l'acteur de test
            acteur.AjouterEO(m_nIdEO);
		}

        //---------------------------------------------------------------------------
        /// <summary>
        /// Methode générique qui retourne une entité du jeux de test dans un contexte donné
        /// </summary>
        /// <typeparam name="TypeEntite"></typeparam>
        /// <param name="nId"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        private CObjetDonneeAIdNumerique GetEntite(Type tp, int nId, CContexteDonnee ctx)
        {
            object obj = Activator.CreateInstance(tp, ctx);
            CObjetDonneeAIdNumerique entite = obj as CObjetDonneeAIdNumerique;
            
            if (entite != null && !entite.ReadIfExists(nId))
                throw new Exception("L'entité: " + tp.ToString()+" avec l'ID "+nId.ToString()+" n'éxiste pas !");
            return entite;
        }


        //-----------------------------     TEST PRELIMINAIRE    ---------------------------------
        [Test]
        public void AAA_TousLesObjetsSontIlsBienCrees()
        {
            using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
            {
                Assert.IsNotNull((CActeur) GetEntite(typeof(CActeur),m_nIdActeur, contexte));
                Assert.IsNotNull((CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte));
                Assert.IsNotNull((CCalendrier) GetEntite(typeof(CCalendrier), m_nIdCalendrier, contexte));
                Assert.IsNotNull((CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte));
                Assert.IsNotNull((CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte));
                Assert.IsNotNull((CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte));
            }
        }
	

        //-----------------------------     TEST 1    ---------------------------------
        [Test]
        public void TestCalendrierTroisTranchesNonContigues()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();
                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    // Création des tranches horaires
                    // Première tranche de Jour de 8h à 11 h
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 11 * 60; // 11 heures
                    Assert.IsTrue(t1.CommitEdit().Result);

                    // Deuxième tranche de Repos de 12h à 14 h
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 12 * 60; // 8 heures
                    t2.HeureFin = 14 * 60; // 11 heures
                    Assert.IsTrue(t2.CommitEdit().Result);

                    // Troisième tranche dont l'occupation est indéfinie de 15h à 19h
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t3.TypeOccupationHoraire = null;
                    t3.HeureDebut = 15 * 60; // 8 heures
                    t3.HeureFin = 19 * 60; // 11 heures
                    Assert.IsTrue(t3.CommitEdit().Result);

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CActeur acteur = (CActeur) GetEntite(typeof(CActeur),m_nIdActeur, contexte);
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));

                    Assert.AreEqual(3, listeTranches.Length);
                    Assert.AreEqual(50, listeTranches[0].Priorite);
                    Assert.AreEqual(10, listeTranches[1].Priorite);
                    Assert.AreEqual(0, listeTranches[2].Priorite);

                }

            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }


        //-----------------------------     TEST 2     ---------------------------------
        [Test]
        public void TestCalendrierTroisTranchesContigues()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();
                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {

                    // Création des tranches horaires
                    // Première tranche de Jour de 8h à 11 h
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 12 * 60; // 12 heures
                    Assert.IsTrue(t1.CommitEdit().Result);

                    // Deuxième tranche de Repos de 12h à 14 h
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 12 * 60; // 12 heures
                    t2.HeureFin = 14 * 60; // 14 heures
                    Assert.IsTrue(t2.CommitEdit().Result);

                    // Troisième tranche dont l'occupation est indéfinie de 15h à 19h
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t3.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t3.HeureDebut = 14 * 60; // 8 heures
                    t3.HeureFin = 19 * 60; // 11 heures
                    Assert.IsTrue(t3.CommitEdit().Result);

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));

                    Assert.AreEqual(3, listeTranches.Length);
                    Assert.AreEqual(100, listeTranches[0].Priorite);
                    Assert.AreEqual(50, listeTranches[1].Priorite);
                    Assert.AreEqual(10, listeTranches[2].Priorite);

                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }


        //-----------------------------     TEST 3    ---------------------------------
        [Test]
        public void TestCalendrierTroisTranchesAvecRecouvrement()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();
                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    // Création des tranches horaires
                    // Première tranche de Jour de 8h à 11 h
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 12 * 60; // 11 heures
                    Assert.IsTrue(t1.CommitEdit().Result);

                    // Deuxième tranche de Repos de 12h à 14 h
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 11 * 60; // 8 heures
                    t2.HeureFin = 15 * 60; // 11 heures
                    Assert.IsTrue(t2.CommitEdit().Result);

                    // Troisième tranche dont l'occupation est indéfinie de 15h à 19h
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t3.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t3.HeureDebut = 14 * 60; // 8 heures
                    t3.HeureFin = 19 * 60; // 11 heures
                    Assert.IsTrue(t3.CommitEdit().Result);

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));

                    Assert.AreEqual(3, listeTranches.Length);
                    Assert.AreEqual(100, listeTranches[0].Priorite);
                    Assert.AreEqual(5, listeTranches[0].Duree);
                    Assert.AreEqual(50, listeTranches[1].Priorite);
                    Assert.AreEqual(4, listeTranches[1].Duree);
                    Assert.AreEqual(10, listeTranches[2].Priorite);
                    Assert.AreEqual(2, listeTranches[2].Duree);

                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }


        //-----------------------------     TEST 4    ---------------------------------
        [Test]
        public void TestCalendrierQuatresTranchesAChevalSurDeuxJours()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();

                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    // Création des tranches horaires
                    // Première tranche de Jour de 8h à 11 h
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 12 * 60; // 11 heures
                    Assert.IsTrue(t1.CommitEdit().Result);

                    // Deuxième tranche de Repos de 12h à 14 h
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 12 * 60; 
                    t2.HeureFin = 14 * 60; 
                    Assert.IsTrue(t2.CommitEdit().Result);

                    // Troisième tranche de travail
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t3.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t3.HeureDebut = 14 * 60; 
                    t3.HeureFin = 19 * 60; 
                    Assert.IsTrue(t3.CommitEdit().Result);

                    // Troisième tranche : astreinte
                    CHoraireJournalier_Tranche t4 = new CHoraireJournalier_Tranche(contexte);
                    t4.CreateNew();
                    t4.HoraireJournalier = (CHoraireJournalier) GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t4.TypeOccupationHoraire = (CTypeOccupationHoraire) GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t4.HeureDebut = 19 * 60; // de 19 heures
                    t4.HeureFin = 8 * 60; // à 8 heures le lendemain
                    Assert.IsTrue(t4.CommitEdit().Result);

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));

                    Assert.AreEqual(5, listeTranches.Length);
                    Assert.AreEqual(100, listeTranches[0].Priorite);
                    Assert.AreEqual(13, listeTranches[0].Duree);
                    Assert.AreEqual(100, listeTranches[1].Priorite);
                    Assert.AreEqual(13, listeTranches[1].Duree);
                    Assert.AreEqual(50, listeTranches[2].Priorite);
                    Assert.AreEqual(5, listeTranches[2].Duree);
                    Assert.AreEqual(50, listeTranches[3].Priorite);
                    Assert.AreEqual(4, listeTranches[3].Duree);
                    Assert.AreEqual(10, listeTranches[4].Priorite);
                    Assert.AreEqual(2, listeTranches[4].Duree);

                    // On demande les Horaires à l'acteur de 12H au landemain 12H 
                    // -> attendu 6 tranches, car à 12H00 pile on comptabilise la tranche qui se termine à 12H et celle qui commence à 12H00
                    listeTranches = acteur.GetHoraires(DateTime.Today.AddHours(12), DateTime.Today.AddDays(1).AddHours(12));
                    Assert.AreEqual(6, listeTranches.Length);

                    // On demande les horaires aujourd'hui entre 13H et 16H -> attendu 2 tranches
                    listeTranches = acteur.GetHoraires(DateTime.Today.AddHours(13), DateTime.Today.AddHours(16));
                    Assert.AreEqual(2, listeTranches.Length);

                    // On demande les horaires aujourd'hui entre 13H et 23H -> attendu 3 tranches
                    listeTranches = acteur.GetHoraires(DateTime.Today.AddHours(13), DateTime.Today.AddHours(23));
                    Assert.AreEqual(3, listeTranches.Length);
                    // On demande les horaires entre aujourd'hui 13H et demain matin 01H00 -> attendu 3 tranches
                    listeTranches = acteur.GetHoraires(DateTime.Today.AddHours(13), DateTime.Today.AddDays(1).AddHours(1));
                    Assert.AreEqual(3, listeTranches.Length);
                    
                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }

        
        //-----------------------------     TEST 5   ---------------------------------
        [Test]
        public void TestUneEOPlanifieeSimple()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();

                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    // Jour
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 12 * 60; // 11 heures
                    Assert.IsTrue(t1.CommitEdit());


                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)GetEntite(typeof(CEntiteOrganisationnelle), m_nIdEO, contexte);
                    // Création des EO planifiées
                    CEOplanifiee_Acteur eoPlan = new CEOplanifiee_Acteur(contexte);
                    eoPlan.CreateNew();
                    eoPlan.Date = DateTime.Today;
                    eoPlan.Acteur = acteur;
                    eoPlan.EntiteOrganisationnelle = eo;
                    eoPlan.TrancheHoraire = t1;
                    Assert.IsTrue(eoPlan.CommitEdit());

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
                    Assert.AreEqual(1, listeTranches.Length);
                    Assert.AreEqual(50, listeTranches[0].Priorite);
                    Assert.AreEqual(4, listeTranches[0].Duree);

                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }

        //-----------------------------     TEST 6   ---------------------------------
        [Test]
        public void TestTroisEOsPlanifieesLeMemeJour()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();

                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    // Repos
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 8 * 60; // 8 heures
                    t2.HeureFin = 12 * 60; // 12 heures
                    Assert.IsTrue(t2.CommitEdit());

                    // Jour
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t3.HeureDebut = 14 * 60;
                    t3.HeureFin = 19 * 60;
                    Assert.IsTrue(t3.CommitEdit());

                    // Astreinte
                    CHoraireJournalier_Tranche t4 = new CHoraireJournalier_Tranche(contexte);
                    t4.CreateNew();
                    t4.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t4.HeureDebut = 19 * 60; // de 19 heures
                    t4.HeureFin = 8 * 60; // à 8 heures le lendemain
                    Assert.IsTrue(t4.CommitEdit());

                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)GetEntite(typeof(CEntiteOrganisationnelle), m_nIdEO, contexte);

                    // Création des EO planifiées
                    CEOplanifiee_Acteur eoPlan1 = new CEOplanifiee_Acteur(contexte);
                    eoPlan1.CreateNew();
                    eoPlan1.Date = DateTime.Today.AddDays(-1);
                    eoPlan1.Acteur = acteur;
                    eoPlan1.EntiteOrganisationnelle = eo;
                    eoPlan1.TrancheHoraire = t4; // Astreinte de la veille
                    Assert.IsTrue(eoPlan1.CommitEdit());

                    // Création des EO planifiées
                    CEOplanifiee_Acteur eoPlan2 = new CEOplanifiee_Acteur(contexte);
                    eoPlan2.CreateNew();
                    eoPlan2.Date = DateTime.Today;
                    eoPlan2.Acteur = acteur;
                    eoPlan2.EntiteOrganisationnelle = eo;
                    eoPlan2.TrancheHoraire = t2;
                    Assert.IsTrue(eoPlan2.CommitEdit());

                    // Création des EO planifiées
                    CEOplanifiee_Acteur eoPlan3 = new CEOplanifiee_Acteur(contexte);
                    eoPlan3.CreateNew();
                    eoPlan3.Date = DateTime.Today;
                    eoPlan3.Acteur = acteur;
                    eoPlan3.EntiteOrganisationnelle = eo;
                    eoPlan3.TrancheHoraire = t3;
                    Assert.IsTrue(eoPlan3.CommitEdit());

                    // Création des EO planifiées
                    CEOplanifiee_Acteur eoPlan4 = new CEOplanifiee_Acteur(contexte);
                    eoPlan4.CreateNew();
                    eoPlan4.Date = DateTime.Today;
                    eoPlan4.Acteur = acteur;
                    eoPlan4.EntiteOrganisationnelle = eo;
                    eoPlan4.TrancheHoraire = t4;
                    Assert.IsTrue(eoPlan4.CommitEdit());

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Today, DateTime.Today.AddDays(1));

                    Assert.AreEqual(4, listeTranches.Length);
                    Assert.AreEqual(100, listeTranches[0].Priorite);
                    Assert.AreEqual(13, listeTranches[0].Duree);
                    Assert.AreEqual(100, listeTranches[1].Priorite);
                    Assert.AreEqual(13, listeTranches[1].Duree);
                    Assert.AreEqual(50, listeTranches[2].Priorite);
                    Assert.AreEqual(5, listeTranches[2].Duree);
                    Assert.AreEqual(10, listeTranches[3].Priorite);
                    Assert.AreEqual(4, listeTranches[3].Duree);

                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }

        //-----------------------------     TEST 7   ---------------------------------
        [Test]
        public void TestCombineEOsPlanifieesEtCalendrier()
        {
            try
            {
                CTimosTestMetierApp.SessionClient.BeginTrans();

                using (CContexteDonnee contexte = new CContexteDonnee(CTimosTestMetierApp.SessionClient.IdSession, true, false))
                {
                    //******** Calendrier **************
                    // Jour
                    CHoraireJournalier_Tranche t1 = new CHoraireJournalier_Tranche(contexte);
                    t1.CreateNew();
                    t1.HoraireJournalier = (CHoraireJournalier)GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t1.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t1.HeureDebut = 8 * 60; // 8 heures
                    t1.HeureFin = 12 * 60; // 12 heures
                    Assert.IsTrue(t1.CommitEdit());
                    
                    // Repos
                    CHoraireJournalier_Tranche t2 = new CHoraireJournalier_Tranche(contexte);
                    t2.CreateNew();
                    t2.HoraireJournalier = (CHoraireJournalier)GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t2.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t2.HeureDebut = 12 * 60; 
                    t2.HeureFin = 13 * 60;
                    Assert.IsTrue(t2.CommitEdit());

                    // Jour
                    CHoraireJournalier_Tranche t3 = new CHoraireJournalier_Tranche(contexte);
                    t3.CreateNew();
                    t3.HoraireJournalier = (CHoraireJournalier)GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t3.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationJour, contexte);
                    t3.HeureDebut = 13 * 60;
                    t3.HeureFin = 17 * 60;
                    Assert.IsTrue(t3.CommitEdit());

                    // Repos de nuit
                    CHoraireJournalier_Tranche t4 = new CHoraireJournalier_Tranche(contexte);
                    t4.CreateNew();
                    t4.HoraireJournalier = (CHoraireJournalier)GetEntite(typeof(CHoraireJournalier), m_nIdHoraireJournalier, contexte);
                    t4.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t4.HeureDebut = 17 * 60;
                    t4.HeureFin = 8 * 60; 
                    Assert.IsTrue(t4.CommitEdit());

                    // ***********  EO Planifiées *****************

                    // Repos
                    CHoraireJournalier_Tranche t5 = new CHoraireJournalier_Tranche(contexte);
                    t5.CreateNew();
                    t5.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t5.HeureDebut = 6 * 60;
                    t5.HeureFin = (int) (12.5 * 60); // 12H30
                    Assert.IsTrue(t5.CommitEdit());

                    // Astreinte
                    CHoraireJournalier_Tranche t6 = new CHoraireJournalier_Tranche(contexte);
                    t6.CreateNew();
                    t6.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t6.HeureDebut = (int) (12.5 * 60); // 12h30
                    t6.HeureFin = (int) (20.5 * 60); // 20H30
                    Assert.IsTrue(t6.CommitEdit());

                    // Repos
                    CHoraireJournalier_Tranche t7 = new CHoraireJournalier_Tranche(contexte);
                    t7.CreateNew();
                    t7.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationRepos, contexte);
                    t7.HeureDebut = (int) (20.5 * 60);
                    t7.HeureFin = (int) (22.5 * 60); // 22H30
                    Assert.IsTrue(t7.CommitEdit());

                    // Astreinte
                    CHoraireJournalier_Tranche t8 = new CHoraireJournalier_Tranche(contexte);
                    t8.CreateNew();
                    t8.TypeOccupationHoraire = (CTypeOccupationHoraire)GetEntite(typeof(CTypeOccupationHoraire), m_nIdOccupationAstreinte, contexte);
                    t8.HeureDebut = (int) (22.5 * 60); // 12h30
                    t8.HeureFin = 6 * 60; // 6 H le landemain
                    Assert.IsTrue(t8.CommitEdit());

                    CActeur acteur = (CActeur)GetEntite(typeof(CActeur), m_nIdActeur, contexte);
                    CEntiteOrganisationnelle eo = (CEntiteOrganisationnelle)GetEntite(typeof(CEntiteOrganisationnelle), m_nIdEO, contexte);

                    // Création EO planifiée repos
                    CEOplanifiee_Acteur eoPlan1 = new CEOplanifiee_Acteur(contexte);
                    eoPlan1.CreateNew();
                    eoPlan1.Date = DateTime.Today;
                    eoPlan1.Acteur = acteur;
                    eoPlan1.EntiteOrganisationnelle = eo;
                    eoPlan1.TrancheHoraire = t5; 
                    Assert.IsTrue(eoPlan1.CommitEdit());

                    // Création EO planifiée Astreinte
                    CEOplanifiee_Acteur eoPlan2 = new CEOplanifiee_Acteur(contexte);
                    eoPlan2.CreateNew();
                    eoPlan2.Date = DateTime.Today;
                    eoPlan2.Acteur = acteur;
                    eoPlan2.EntiteOrganisationnelle = eo;
                    eoPlan2.TrancheHoraire = t6;
                    Assert.IsTrue(eoPlan2.CommitEdit());

                    // Création EO repos
                    CEOplanifiee_Acteur eoPlan3 = new CEOplanifiee_Acteur(contexte);
                    eoPlan3.CreateNew();
                    eoPlan3.Date = DateTime.Today;
                    eoPlan3.Acteur = acteur;
                    eoPlan3.EntiteOrganisationnelle = eo;
                    eoPlan3.TrancheHoraire = t7;
                    Assert.IsTrue(eoPlan3.CommitEdit());

                    // Création EO astreinte
                    CEOplanifiee_Acteur eoPlan4 = new CEOplanifiee_Acteur(contexte);
                    eoPlan4.CreateNew();
                    eoPlan4.Date = DateTime.Today;
                    eoPlan4.Acteur = acteur;
                    eoPlan4.EntiteOrganisationnelle = eo;
                    eoPlan4.TrancheHoraire = t8;
                    Assert.IsTrue(eoPlan4.CommitEdit());

                    // On demande les Horaires à l'acteur de maintenant à demain même heure (24 heures)
                    CTrancheHoraire[] listeTranches = acteur.GetHoraires(DateTime.Today, DateTime.Today.AddDays(1));

                    Assert.AreEqual(7, listeTranches.Length);
                    Assert.AreEqual(100, listeTranches[0].Priorite);
                    Assert.AreEqual(7.5, listeTranches[0].Duree);

                }
            }
            finally
            {
                CTimosTestMetierApp.SessionClient.RollbackTrans();
            }

        }
	}
}
