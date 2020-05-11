using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using sc2i.data;
using timos.data;
using timos.client;
using sc2i.common;
using sc2i.expression;
using sc2i.documents;
using sc2i.data.dynamic;
using sc2i.multitiers.client;
using sc2i.win32.data;
using timos.acteurs;
using spv.data;
using spv.data.ConsultationAlarmes;



namespace spv.test
{
    [TestFixture]
    public class CSpvTestSite
    {

        const string c_strTypeSite = "TEST_S0_TYPSITE01";
        const string c_strSite1 = "TEST_S0_SITE01";
        const string c_strSite1Mod = "TEST_S0_SITE01Mod";
        const string c_strSite1Dup = "TEST_S0_SiteO1Dup";
        const string c_strSite2 = "TEST_S0_SITE02";
        const string c_steSite3 = "TEST_S0_SITE03";




        private CContexteDonnee m_contexteDonnees = null;


        private int m_nIdTypeSite1;
        private int m_nIdSite1;
        private int m_nIdSite2;


        private int m_NbMaskAdm =0;
        private int m_NbMaskBrig = 0;
        private int m_NbAlFreq = 0;

        private CRecepteurNotification m_recepteurNotifications = null;
        private bool m_bSortieAlarme = false;
        string m_nomAlarmeLue;
        string m_DateAlarmeLue;
        string m_TypealarmeLue;
        //string m_ObjetalarmeLue;
        string m_commentAlrmeLue;
        private List<CInfoAlarmeAffichee> m_lstViewEnCours;

        //-----------------------------------------
        [SetUp]
        public void Init()
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvTestApp.AssureInit();
            m_contexteDonnees = new CContexteDonnee(CSpvTestApp.SessionClient.IdSession, true, false);

        

           m_recepteurNotifications = new CRecepteurNotification(m_contexteDonnees.IdSession, typeof(CDonneeNotificationAlarmes));
           m_recepteurNotifications.OnReceiveNotification += new NotificationEventHandler(OnReceiveNotificationAlarmEnCours);

           //ins�rer les tests ici

           


            


        }


        

        [Test]
        public void AssureTesterTypeqNonCable()
        {


            //Cr�e un �quipemnt avec un acc�s alame non c�bl� et v�rifie que l'on peut le supprimer

            Console.WriteLine("Cr�e un �quipemnt avec un acc�s alame non c�bl� et v�rifie que l'on peut le supprimer");
            int nIdTypeSite = CreerTypeSite("TEST_S2_TYPSITE");

            int nIdSite = CreerSite(nIdTypeSite, "TEST_S2_SITE");

            int nIdFamille = CreerFamille("TEST_S2_FAMILLE");

            int nIdTypeq = CreerTypeEquipement("TEST_S2_TYPEQ",nIdFamille);
                     
                   

            int nIdEquip1 = CreerEquipement(nIdTypeq, "TEST_S2_EQUIP1", nIdSite);
            int nIdEquip2 = CreerEquipement(nIdTypeq, "TEST_S2_EQUIP2", nIdSite);


            int nIdTypeAcces = CreerTypeAccesAlarmeTypeq(nIdTypeq, "TEST_S2_ACCES", ECategorieAccesAlarme.SortieBoucle);
            int NidAlarmeGeree = CreerAlarmeGeree(nIdTypeAcces, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Major);



            SupprimerAlarmeGeree(NidAlarmeGeree);
            SupprimerTypeAccesAlarme(nIdTypeAcces);



            SupprimerEquipement(nIdEquip2);
            SupprimerEquipement(nIdEquip1);


            SupprimerTypeEquipement(nIdTypeq);
            SupprimerSite(nIdSite);
            SupprimerTypeSite(nIdTypeSite);
            SupprimerFamille(nIdFamille);




            Console.WriteLine("Fin du test");
        }



      
      



        [Test]
        public void AssureEditerSites()
        {


            //Teste l'�dition des diff�rents champs du site

            Console.WriteLine("Teste l'�dition des diff�rents champs du site");

            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_S101_TYPSITE");

          
            Console.WriteLine("cr�ation du site 1");
            int nIdSite1 = CreerSite(nIdTypeSite, "TEST_S01_SITE1");


            Console.WriteLine("lecture du site 1");
            int nId1 = LireIdSite("TEST_S01_SITE1");

            Assert.IsTrue(nId1 == nIdSite1); 

            Console.WriteLine("modification du site 1 ");
           // ModifierSite(nId1, "TEST_S0_SITE1Mod");

            Console.WriteLine("modification du domaine 1 ");
            ModifierDomaine(nId1, "192.0.22.[1-20]");

            Console.WriteLine("modif de la communaut�");
            ModifierCommunaute(nId1, "public");


            Console.WriteLine("modification du domaine");
            ModifierDomaine(nId1, "172.10.2.2");

            Console.WriteLine("modif de la communaut�");
            ModifierCommunaute(nId1, "private");

            Console.WriteLine("suppression du site1 ");
            SupprimerSite(nId1);


            Console.WriteLine("suppression du type de site");
            SupprimerTypeSite(nIdTypeSite);


        }


       
       

       

        [Test]
        public void AssureCausesAlarmes()
        {

           
            //Teste la cr�ation et la suppression des causes d'alarmes
            //cr�e un site , un acc�s alarme sur ce site, affecte des 
            //causes d'alamre � l'alamre g�r�e de cet acc�s.
            //Supprime ensuite les objets




            Console.WriteLine("Teste la cr�ation et la suppression des causes d'alarmes");

            int nIdCause1 = CreerCauseAlarme("TEST_S6_CAUSE1");

            int nIdCause2 = CreerCauseAlarme("TEST_S6_CAUSE2");

            int nIdTypsite = CreerTypeSite("TEST_S6_TYPSITE");


            int nIdSite = CreerSite(nIdTypsite, "TEST_S6_SITE1");

            int nIdTypeAccesSite = CreerTypeAccesAlarmeSite("TEST_S6_ACCES1", nIdSite, ECategorieAccesAlarme.SortieBoucle);


            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined);

            AffecteCauseAlarmeGeree(nIdCause1, nIdAlarmeGeree);

            AffecteCauseAlarmeGeree(nIdCause2, nIdAlarmeGeree);


            Console.WriteLine("Test de la suppression des objets");

            RetirerCauseAlarmeGeree(nIdCause2, nIdAlarmeGeree);
            RetirerCauseAlarmeGeree(nIdCause1, nIdAlarmeGeree);
          


            SupprimerCauseAlarme(nIdCause2);


            SupprimerCauseAlarme(nIdCause1);

            SupprimerAlarmeGeree(nIdAlarmeGeree);

            SupprimerTypeAccesAlarme(nIdTypeAccesSite);

            SupprimerSite(nIdSite);
            SupprimerTypeSite(nIdTypsite);


        }


     
        [Test]
        public void AssureTestAlarmeEquip()
        {
            
            //Cr�e un acc�s alarme boucle entre deux �quipemnts et 
            // teste la notification d'alarme
            //Cr�e un site, un type d'�quipment avec un acc�s alarme "sortie boucle" 
            //et un type d'�quipement avec une entr�e alarme. Cr�e un �quipement de chaque type
            //sur le site et cable l'acc�s alamre
            //Teste l'alarme avec diff�rente valeurs de la gravit�
            //D�c�ble l'alarme et supprime les objets
            Console.WriteLine("Test d'une alarme boucle sur un �quipement");


            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();

            string strnomSortie = "SORTIE_16";
            string strnomEntree = "16";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_S16_TYPSITE");

            int nIdFamille = CreerFamille("TEST_S16_FAMILLE");


            int nIdSite = CreerSite(nIdTypeSite, "TEST_S16_SITE");


            int nIdTypeqEntree = CreerTypeEquipement("TEST_S16_TYPEQ_E");

            int nIdTypeqBoucle = CreerTypeEquipement("TEST_S16_TYPEQ_S");


            int nIdTypeAccesE = CreerTypeAccesAlarme(nIdTypeqEntree, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);
            int nIdTypeAccesS = CreerTypeAccesAlarme(nIdTypeqBoucle, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesS, EAlarmEvent.Equipment, EGraviteAlarmeAvecMasquage.Major);
            //

            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_S16_EQUIP_E", nIdSite, "172.16.54.59");
            int nIdEquipS = CreerEquipement(nIdTypeqBoucle, "TEST_S16_EQUIP_S", nIdSite, "172.16.54.59");



            ModifierEquipAsurveiller(nIdEquipE, false);

            int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);


            int nIdLienAlarme = CablerAccesAlarme(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdSite, nIdEquipS, "172.16.54.59", EGraviteAlarmeAvecMasquage.Major);

         


            ModifierEquipAsurveiller(nIdEquipE, true);

            VerifierEquipAsurveiller(nIdEquipE, true);

            ModifierEquipAsurveiller(nIdEquipS, true);

            VerifierEquipAsurveiller(nIdEquipS, true);




            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_S16_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Major, strnomEntree, nIdLienAlarme);

            
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("Notification alarme re�ue");

                VerifierEquipRep(nIdEquipS, 3);



                Console.WriteLine(m_commentAlrmeLue);
                Console.WriteLine(m_nomAlarmeLue);
                Console.WriteLine(m_DateAlarmeLue);
                Console.WriteLine(m_TypealarmeLue);
                //Console.WriteLine(m_ObjetalarmeLue);
               

            }
            else
            {

                Console.WriteLine("Pas de notification alarme re�ue");

            }


            Console.WriteLine("Retomb�e alarme");

            //retomb�e alarme
            int nIdAlarmeR = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_S16_ALM2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdLienAlarme);



            System.Threading.Thread.Sleep(10000);




            if (m_bSortieAlarme)
            {



                Console.WriteLine(m_commentAlrmeLue);
                Console.WriteLine(m_nomAlarmeLue);
                Console.WriteLine(m_DateAlarmeLue);
                Console.WriteLine(m_TypealarmeLue);
                //Console.WriteLine(m_ObjetalarmeLue);

                VerifierEquipRep(nIdEquipS, 0);


               // VerifierSiteRep(nIdSite, false);


            }
            else
                Console.WriteLine("Pas de notification alarme re�ue");




            Console.WriteLine("fin de la retomb�e alarme");
            System.Threading.Thread.Sleep(10000);

            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Undetermined);
            ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Undetermined);

            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_S16_ALM3", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdLienAlarme);


            System.Threading.Thread.Sleep(10000);




           

               
                if (m_bSortieAlarme)
                {
                    VerifierEquipRep(nIdEquipS, 2);

                    
                 //   VerifierSiteRep(nIdSite, true);

                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue);
                    m_bSortieAlarme = false;
                   

                }
                else
                    Console.WriteLine("pas de notification alarme  re�ue");




                Console.WriteLine("retomb�e alarme");

                int nIdAlarme4 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_S16_ALM4", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdLienAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {

                VerifierEquipRep(nIdEquipS, 0);

                Console.WriteLine(m_commentAlrmeLue);
                Console.WriteLine(m_nomAlarmeLue);
                Console.WriteLine(m_DateAlarmeLue);
                Console.WriteLine(m_TypealarmeLue);
                //Console.WriteLine(m_ObjetalarmeLue);
                m_bSortieAlarme = false;


            }

            else

                Console.WriteLine("pas de notification alarme re�ue");
            
            
            Console.WriteLine("Suppression des objets");
            SupprimerCablageAlarme(nIdLienAlarme);
        
            SupprimerAlarmeGeree(nIdAlarmeGeree);
            SupprimerTypeAccesAlarme(nIdAlarmeSortie);
            SupprimerTypeAccesAlarme(nIdAlarmeEntree);
            
            SupprimerTypeAccesAlarme(nIdTypeAccesS);
            SupprimerTypeAccesAlarme(nIdTypeAccesE);
            SupprimerEquipement(nIdEquipE);
            SupprimerEquipement(nIdEquipS);
           SupprimerSite(nIdSite);
           SupprimerTypeEquipement(nIdTypeqEntree);
           SupprimerTypeEquipement(nIdTypeqBoucle);
            SupprimerTypeSite(nIdTypeSite);
            
           

            Console.WriteLine("fin du test alarme �quipement");

        }





        public void VerifierSiteRep(int nSiteId, int nSiteOper)
        {
            Console.WriteLine("Test de l'�tat de SITE_REP");


            Console.WriteLine("lecture du site");
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));
            Console.WriteLine("lecture de SITE_REP");
            CSpvSite_Rep siteRep = new CSpvSite_Rep(m_contexteDonnees);
            Assert.IsTrue(siteRep.ReadIfExists(new CFiltreData(CSpvSite_Rep.c_champSITE_ID + "=@1", siteSpv.Id)));
            siteRep.Refresh();
            Console.WriteLine("v�rification de l'�tat de SITE_OPER");

            Assert.IsTrue(siteRep.CodeEtatOperationnel == nSiteOper);





        }


       
        [Test]
        public void AssureTestAlarmeUnEquip()
        {

            //teste une alarme sur un �quipment o� les acc�s entr�e et sortie d'alarme sont sur le m�me �quipement
            //Cr�e un site, un type d'�quipemnt avec deux acc�s alamre(entr�e et sortie), un �quipement de ce type
            //c�ble la sortie alarme sur l'entr�e et d�clenche l'alarme


            
            Console.WriteLine("Test d'une alarme boucle sur un �quipement");
            Console.WriteLine("les acc�s entr�e et sortie sont sur le m�me �quipement");


            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();

            string strnomSortie = "SORTIE_6";
            string strnomEntree = "6";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_S6_TYPSITE");

            int nIdFamille = CreerFamille("TEST_S6_FAMILLE");
            int nIdSite = CreerSite(nIdTypeSite, "TEST_S6_SITE");

            int nIdTypeq = CreerTypeEquipement("TEST_S6_TYPEQ");


            int nIdTypeAccesE = CreerTypeAccesAlarme(nIdTypeq, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);
            int nIdTypeAccesS = CreerTypeAccesAlarme(nIdTypeq, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesS, EAlarmEvent.Equipment, EGraviteAlarmeAvecMasquage.Major);
            //

            int nIdEquip = CreerEquipement(nIdTypeq, "TEST_S6_EQUIP_1", nIdSite, "172.16.54.59");
          


            ModifierEquipAsurveiller(nIdEquip, false);

            int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquip);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquip);


            int nIdLienAlarme = CablerAccesAlarme(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdSite, nIdEquip, "172.16.54.59", EGraviteAlarmeAvecMasquage.Major);

            //VerifierEquipAsurveiller(nIdEquipE, true);


            ModifierEquipAsurveiller(nIdEquip, true);

            VerifierEquipAsurveiller(nIdEquip, true);



            int nIdAlarme = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S6_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdLienAlarme);


            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("Notification alarme re�ue");

                VerifierEquipRep(nIdEquip, 2);


            }
            else
            {

                Console.WriteLine("Pas de notification alarme re�ue");

            }


            Console.WriteLine("Retomb�e alarme");

            //retomb�e alarme
            int nIdAlarmeR = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S6_ALM2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdLienAlarme);



            System.Threading.Thread.Sleep(10000);




            if (m_bSortieAlarme)
            {



                Console.WriteLine(m_commentAlrmeLue);
                Console.WriteLine(m_nomAlarmeLue);
                Console.WriteLine(m_DateAlarmeLue);
                Console.WriteLine(m_TypealarmeLue);
                //Console.WriteLine(m_ObjetalarmeLue);

                VerifierEquipRep(nIdEquip, 0); ;


               


            }
            else
                Console.WriteLine("Pas de notification alarme re�ue");








            Console.WriteLine("Suppression des objets");
            SupprimerCablageAlarme(nIdLienAlarme);
            VerifierEquipAsurveiller(nIdEquip, false);

            SupprimerAlarmeGeree(nIdAlarmeGeree);
            SupprimerTypeAccesAlarme(nIdAlarmeSortie);
            SupprimerTypeAccesAlarme(nIdAlarmeEntree);

            SupprimerTypeAccesAlarme(nIdTypeAccesS);
            SupprimerTypeAccesAlarme(nIdTypeAccesE);
            SupprimerEquipement(nIdEquip);
          
            SupprimerSite(nIdSite);
            SupprimerTypeEquipement(nIdTypeq);
            SupprimerTypeEquipement(nIdTypeq);
            SupprimerTypeSite(nIdSite);



            Console.WriteLine("fin du test alarme �quipement");

        }





        

      

     
        public void VerifierEquipRep(int nEquipId, int  nEquipOper)
        {


            
        
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);

            Console.WriteLine("chargement de l'�quipemnt SPV");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1",nEquipId)));

            Console.WriteLine("chargement de EQUIP_REP");
            CSpvEquip_Rep equipRep = new CSpvEquip_Rep(m_contexteDonnees);
           
            Assert.IsTrue(equipRep.ReadIfExists(new CFiltreData( CSpvEquip_Rep.c_champEQUIP_ID+  "=@1",equipSpv.Id)));
            equipRep.Refresh();

            Console.WriteLine("v�rification de la valeur de EQUIP_REP");


            
            Assert.IsTrue(equipRep.CodeEtatOperationnel == nEquipOper);

            
            
            

        }

        public void ModifASurveiller(int nId, int nIdLienAlarme,bool bASurveiller)
        {

            //Modification de la valeur "A surveiller" d'un �quipement 
            Console.WriteLine("Modification de la valeur 'A surveiller ' du lien alarme d'un �quipement");
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);

            Console.WriteLine("chargement de l'�quipment logique");
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champId + "=@1", nId)));

            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("chargement de l'�quipment SPV");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            
            equipSpv.ASuperviser = bASurveiller;


             CResultAErreur result = m_contexteDonnees.SaveAll(true);

             Console.WriteLine("sauvegarde de l'�quipement");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            


          




        }


        public void ModifierEquipAsurveiller(int nId, bool bASurveiller)
        {
            //modification du champ "A surveiller" d'un �qupment

            Console.WriteLine("Chargement de l'�quipement");
            CSpvEquip equipsv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipsv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            equipsv.ASuperviser = bASurveiller;



            CResultAErreur result = m_contexteDonnees.SaveAll(true);



            Console.WriteLine("sauvegarde de l'�quipemnt");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            CSpvEquip equipTest = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�qupement SPV");
            Assert.IsTrue(equipTest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            Console.WriteLine("v�rification du champ A surveiller");
            Assert.IsTrue(equipTest.ASuperviser == bASurveiller);

        }


        public void VerifierEquipAsurveiller(int nId, bool bASurveiller)
        {
            
            CSpvEquip equipsv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("chargement de l'�quipemnt SPV");
            Assert.IsTrue(equipsv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            Console.WriteLine("v�rification du champ A surveiller");
            Assert.IsTrue(equipsv.ASuperviser == bASurveiller);



        }
        public void SupprimerEquipement(int nId)
        {

            //suppression d'un �quipement

            Console.WriteLine("Suppression d'un �quipemnt");

            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Console.WriteLine("chargement de l'�quipemnt logique � supprimer");
            Assert.IsTrue(equip.ReadIfExists(nId));
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("chargement de l'�quipemnt SPV � supprmier");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData( CSpvEquip.c_champSmtEquipementLogique_Id  + "=@1",nId)));

             CResultAErreur result = equip.Delete() ;
           /*  Console.WriteLine("enregistement de la suppression");

             result = m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Console.WriteLine("enregistement de la suppression");

              */

              Console.WriteLine("V�rification de la suppression de l'�quipemnt logique");
            CEquipementLogique equiptest = new CEquipementLogique(m_contexteDonnees);
            Assert.IsFalse(equiptest.ReadIfExists(nId));

            CSpvEquip equipTest = new CSpvEquip(m_contexteDonnees);
            Assert.IsFalse(equipTest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

        }




        /*

        [Test]
        public void AssureTestCablageEquip()
        {

            //teste la cr�ation d'un c�blage d'acc�s alarme entre deux �quipemnts d'un site et la notification 

            string strnomSortie = "BOUCLE11";
            string strnomEntree = "11";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("NUNIT_TYPE_E");

            int nIdFamille = LireIdFamille("NUNIT_FAMILLE1");


            int nIdSite = CreerSite(nIdTypeSite,"SITE_ALM_EQUIP3");

            int nIdTypeqEntree = CreerTypeEquipement("TYPEQ ENT11");
            
            int nIdTypeqBoucle = CreerTypeEquipement("TYPEQBOUCLE11");

           
            int nIdTypeAccesE = CreerTypeAccesAlarmeTypeq(nIdTypeqEntree, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);
            int nIdTypeAccesS = CreerTypeAccesAlarmeTypeq(nIdTypeqBoucle, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
          
           
  //          int nidAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesS, EAlarmEvent.Equipment, EGraviteAlarme.Major);
//
      //     int nIdCauseAlarme2 = CreerCauseAlarme("test 8");

        //    int nIdCauseAlarme = CreerCauseAlarme("test boucle 8");

          //  AffecteCauseAlarmeGeree(nIdCauseAlarme2, nidAlarmeGeree);

         //   AffecteCauseAlarmeGeree(nIdCauseAlarme, nidAlarmeGeree);


       //     RetirerCauseAlarmeGeree(nIdCauseAlarme2, nidAlarmeGeree);

       //     SupprimerCauseAlarme(nIdCauseAlarme2);


            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "EQ_ENT_11", nIdSite,"172.16.54.59");
            int nIdEquipS = CreerEquipement(nIdTypeqBoucle, "EQ_ST_11",nIdSite,"172.16.54.59");
            int nIdEquipE2 = CreerEquipement(nIdTypeqEntree ,"EQ_ENT11b",nIdSite,"172.16.54.59");

        //     ModifierAddrIpEquip(nIdEquipE, "172.16.54.59");


           
         //  ModifierAddrIpEquip(nIdEquipS, "172.16.54.59");
            int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);

           int nIdAlarmeEntree2 = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE2);
           int nidAlarmeGeree = RecupererIdAlarmeGeree(nIdAlarmeSortie, strnomSortie);
           int nIdLienAlarme1  = CablerAccesAlarme(nIdAlarmeSortie, nIdAlarmeEntree, nidAlarmeGeree, nIdSite,nIdEquipS, "172.16.54.59", EGraviteAlarme.Major);
           int nIdLienAlarme2 =  CablerAccesAlarme(nIdAlarmeSortie, nIdAlarmeEntree2, nidAlarmeGeree, nIdSite,nIdEquipE, "172.16.54.59", EGraviteAlarme.Major);


            int nIdAlarmeGeree = RecupererIdAlarmeGeree(nIdAlarmeSortie,strnomSortie);
            int nbAlarmerecues = 0;


            //int nIdLienAlarme = LireCablageAccesAlarme(nIdAccesSite, nIdAlarmeEquip, nIdAlarmeGeree);
             int nIdLienAlarme = CablerAccesAlarme(nIdAlarmeEntree,nIdAlarmeSortie,nidAlarmeGeree,nIdSite,nIdEquipE,"172.16.54.59",EGraviteAlarme.Major);


            
            

//            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, strnomSortie, EAlarmEvent.Equipment, EGraviteAlarme.Major,strnomSortie, nIdLienAlarme);
         

              Console.WriteLine("Test du c�blage effectu�");


      
        


          
        while(true)
        {

            System.Threading.Thread.Sleep(500);
                if (m_bSortieAlarme)
                {
                    nbAlarmerecues = m_lstViewEnCours.Count;


                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    Console.WriteLine(m_ObjetalarmeLue);

                    break;
                    
                }

                else
                {
                    

                    nbAlarmerecues = 0;
                }



            } 



            Console.Write ("fin du tset alrme �quipement");




        }

*/

        [Test]
        public void AssureTesterAlarme()
        {


            // Creer un acc�s alarme boucle entre un site et un �quipement et teste la notification d'alarme
            // Cr�e un site et un acc�s alarme boucle sur le site.
            //Cr�e un type d'�quipement avec une entr�e alamre, un �quipemnt de ce type et c�ble
            //la sortie alarme du site avec l'entr�e de l'�quipment
            //Teste l'alarme avec diff�rentes valeurs de la gravit� de l'alarme
            //D�c�ble l'alarme et supprime les objets



            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();

            string strAddrIp = "172.16.54.59";
            
            string strNomAccesAlarmeSite = "SORTIE_43";

            string strNomEntreealarmeEquip ="43";

            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_S43_TYPSITE");

            int nIdFamille = CreerFamille("TEST_S43_FAMILLE");
            
            Console.WriteLine("cr�ation d'un type d'�quipement");
            int nIdTypeq = CreerTypeEquipement("TEST_S43_TYPEQ", nIdFamille);
            
            int nIdSite = CreerSite(nIdTypeSite, "TEST_S43_SITE");                  
                 

            int nIdTypeAccesSite= CreerTypeAccesAlarmeSite(strNomAccesAlarmeSite,nIdSite,ECategorieAccesAlarme.SortieBoucle);


            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesSite, EAlarmEvent.Equipment, EGraviteAlarmeAvecMasquage.Undetermined);

            
           int nIdTypeAccesEquip = CreerTypeAccesEntreeEquipement(nIdTypeq,strNomEntreealarmeEquip);


           int nIdEquip=CreerEquipement(nIdTypeq, "TEST_S43_EQUIP", nIdSite);


          // ModifierEquipementAssurveiller(nIdEquip, true);

           int nIdAccesSite = RecupererAccesAlarmeSite(strNomAccesAlarmeSite, nIdSite);
       
           int nIdAlarmeEquip = RecupererAccesAlarmEquip(strNomEntreealarmeEquip,nIdEquip);

           ModifierAddrIpEquip(nIdEquip, "172.16.54.59");
           Assert.IsTrue(nIdTypeAccesSite == nIdAccesSite);





           int nIdLienAlarme = CablerAccesAlarme(nIdAccesSite, nIdAlarmeEquip, nIdAlarmeGeree, nIdSite, nIdEquip, "172.16.54.59", EGraviteAlarmeAvecMasquage.Undetermined);

          

   
           Console.WriteLine("Cr�ation de l'alarme de test");

           ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Undetermined);
           ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Undetermined);

           int nIdAlarme = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S43_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strNomEntreealarmeEquip, nIdLienAlarme);
         Console.WriteLine("cr�ation de l'alarme effectu�e");

         System.Threading.Thread.Sleep(500);
           
                if (m_bSortieAlarme)
                {
                    VerifierSiteRep(nIdSite, 2);
                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue); 
                   
                }

                else
                {
                    Console.WriteLine("pas de notification alarme");
                }

            
            
             Console.WriteLine("Fin du test des alarmes");

            m_bSortieAlarme = false;

            Console.WriteLine("retombee alarme");
            CreerAlarme(nIdEquip, nIdAlarmeGeree, strNomAccesAlarmeSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strNomEntreealarmeEquip, nIdLienAlarme);

                System.Threading.Thread.Sleep(5000);
                if (m_bSortieAlarme)
                {

                    VerifierSiteRep(nIdSite, 0);
                    Console.WriteLine("retomb�e alarme");

                }
                else
                    Console.WriteLine("pas de notification alarme re�ue");
                
            
                

                Console.WriteLine("Test termin�");


                ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Warning);
                ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Warning);


                int nIdAlarme3 = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S43_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Warning, strNomEntreealarmeEquip, nIdLienAlarme);
                Console.WriteLine("cr�ation de l'alarme effectu�e");
               
                System.Threading.Thread.Sleep(500);

                if (m_bSortieAlarme)
                {
                    VerifierSiteRep(nIdSite,2);
                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue);
                }

                else
                {
                    Console.WriteLine("pas de notification alarme");
                }



                Console.WriteLine("Fin du test des alarmes");

                m_bSortieAlarme = false;

                Console.WriteLine("retombee alarme");
                CreerAlarme(nIdEquip, nIdAlarmeGeree, strNomAccesAlarmeSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strNomEntreealarmeEquip, nIdLienAlarme);

                System.Threading.Thread.Sleep(5000);
                if (m_bSortieAlarme)
                {

                    VerifierSiteRep(nIdSite, 0);
                    Console.WriteLine("retomb�e alarme");

                }
                else
                    Console.WriteLine("pas de notification alarme re�ue");




                Console.WriteLine("Test termin�");


                ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Minor);
                ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Minor);


                int nIdAlarme4 = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S43_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Minor, strNomEntreealarmeEquip, nIdLienAlarme);
                Console.WriteLine("cr�ation de l'alarme effectu�e");
               
                System.Threading.Thread.Sleep(500);

                if (m_bSortieAlarme)
                {
                    VerifierSiteRep(nIdSite,2);
                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue);
                }

                else
                {
                    Console.WriteLine("pas de notification alarme");
                }



                Console.WriteLine("Fin du test des alarmes");

                m_bSortieAlarme = false;

                Console.WriteLine("retombee alarme");
                CreerAlarme(nIdEquip, nIdAlarmeGeree, strNomAccesAlarmeSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strNomEntreealarmeEquip, nIdLienAlarme);

                System.Threading.Thread.Sleep(5000);
                if (m_bSortieAlarme)
                {

                    VerifierSiteRep(nIdSite, 0);
                    Console.WriteLine("retomb�e alarme");

                }
                else
                    Console.WriteLine("pas de notification alarme re�ue");




                Console.WriteLine("Test termin�");


                ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Major);
                ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Major);



                int nIdAlarme5 = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S43_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Major, strNomEntreealarmeEquip, nIdLienAlarme);
                Console.WriteLine("cr�ation de l'alarme effectu�e");
               
                System.Threading.Thread.Sleep(500);

                if (m_bSortieAlarme)
                {
                    VerifierSiteRep(nIdSite, 3);
                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue);
                }

                else
                {
                    Console.WriteLine("pas de notification alarme");
                }



                Console.WriteLine("Fin du test des alarmes");

                m_bSortieAlarme = false;

                Console.WriteLine("retombee alarme");
                CreerAlarme(nIdEquip, nIdAlarmeGeree, strNomAccesAlarmeSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strNomEntreealarmeEquip, nIdLienAlarme);

                System.Threading.Thread.Sleep(5000);
                if (m_bSortieAlarme)
                {

                    VerifierSiteRep(nIdSite,0);
                    Console.WriteLine("retomb�e alarme");

                }
                else
                    Console.WriteLine("pas de notification alarme re�ue");




                Console.WriteLine("Test termin�");


                ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Critical);
                ModifierGraviteCablageAlarme(nIdLienAlarme, EGraviteAlarmeAvecMasquage.Critical);


                int nIdAlarme6 = CreerAlarme(nIdEquip, nIdAlarmeGeree, "TEST_S43_ALM1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical, strNomEntreealarmeEquip, nIdLienAlarme);
                Console.WriteLine("cr�ation de l'alarme effectu�e");
              
                System.Threading.Thread.Sleep(500);

                if (m_bSortieAlarme)
                {
                    VerifierSiteRep(nIdSite,3);
                    Console.WriteLine(m_commentAlrmeLue);
                    Console.WriteLine(m_nomAlarmeLue);
                    Console.WriteLine(m_DateAlarmeLue);
                    Console.WriteLine(m_TypealarmeLue);
                    //Console.WriteLine(m_ObjetalarmeLue);
                }

                else
                {
                    Console.WriteLine("pas de notification alarme");
                }



                Console.WriteLine("Fin du test des alarmes");

                m_bSortieAlarme = false;

                Console.WriteLine("retombee alarme");
                CreerAlarme(nIdEquip, nIdAlarmeGeree, strNomAccesAlarmeSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strNomEntreealarmeEquip, nIdLienAlarme);

                System.Threading.Thread.Sleep(5000);
                if (m_bSortieAlarme)
                {

                    VerifierSiteRep(nIdSite, 0);
                    Console.WriteLine("retomb�e alarme");

                }
                else
                    Console.WriteLine("pas de notification alarme re�ue");




                Console.WriteLine("Test termin�");
            


           System.Threading.Thread.Sleep(10000);

           Console.WriteLine("suppression des objets");
           SupprimerCablageAlarme(nIdLienAlarme);

            SupprimerTypeAccesAlarme(nIdAlarmeEquip);
            SupprimerAlarmeGeree(nIdAlarmeGeree);
            SupprimerTypeAccesAlarme(nIdAccesSite);
            SupprimerTypeAccesAlarme(nIdTypeAccesEquip);

            SupprimerEquipement(nIdEquip);
            SupprimerSite(nIdSite);
            SupprimerTypeEquipement(nIdTypeq);
            SupprimerFamille(nIdFamille);
            SupprimerTypeSite(nIdTypeSite);
        }





     

        public int CreerCauseAlarme(string libelle)
        {

            //Cr�e une cause d'alarme

            Console.WriteLine("cr�ation d'une cause d'alarme");
            CSpvCauseAlarme cause = new CSpvCauseAlarme(m_contexteDonnees);
            if (!cause.ReadIfExists(new CFiltreData(CSpvCauseAlarme.c_champCAUSEAL_LIBEL + "=@1", libelle)))
            {
                cause.CreateNewInCurrentContexte();
                cause.AlarmCause = libelle;
               
            }


            CResultAErreur result = CResultAErreur.True;
            result = cause.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            CSpvCauseAlarme causeTest = new CSpvCauseAlarme(m_contexteDonnees);

            Console.WriteLine("v�rification de la cause d'alarme");
            Assert.IsTrue(causeTest.ReadIfExists(cause.Id));


            return cause.Id;

        }


        public void ModifierCauseAlarme(int nId, string newLibelle)
        {

            //modifie le libell� d'une cause d'alarme
            CSpvCauseAlarme cause = new CSpvCauseAlarme(m_contexteDonnees);
            Console.WriteLine("chargement de la cause d'alarme � modifier");
            Assert.IsTrue(cause.ReadIfExists(new CFiltreData(CSpvCauseAlarme.c_champCAUSEAL_ID + "=@1", nId)));

            cause.AlarmCause = newLibelle;


            CResultAErreur result = CResultAErreur.True;
            result = cause.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            CSpvCauseAlarme causeTest = new CSpvCauseAlarme(m_contexteDonnees);

            Console.WriteLine("v�rification de la cause d'alarme");
            Assert.IsTrue(causeTest.ReadIfExists(nId));
            Assert.IsTrue(causeTest.AlarmCause == newLibelle);



        }


        public void SupprimerCauseAlarme(int nId)
        {
            //supprmie une cause d'alarme
            CSpvCauseAlarme cause = new CSpvCauseAlarme(m_contexteDonnees);
            Console.WriteLine("chargement de la cause d'alarme � supprimer");

            Assert.IsTrue(cause.ReadIfExists(new CFiltreData(CSpvCauseAlarme.c_champCAUSEAL_ID + "=@1", nId)));

            CResultAErreur result = CResultAErreur.True;

            result = cause.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

         /*    result = m_contexteDonnees.SaveAll(true);

             Console.WriteLine("Enregistrement de la suppression");
            
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);*/


            Console.WriteLine("v�rification de la suppression");
            CSpvCauseAlarme causeTest = new CSpvCauseAlarme(m_contexteDonnees);
            Assert.IsFalse(causeTest.ReadIfExists(new CFiltreData(CSpvCauseAlarme.c_champCAUSEAL_ID + "=@1", nId)));




        }



        public void AffecteCauseAlarmeGeree(int nIdCause, int nIdAlarmeGeree)
        {
            //affecte une cause d'alarme � une alarme g�r�e
            
            CSpvAlarmGeree alarmegeree = new CSpvAlarmGeree(m_contexteDonnees);
            Console.WriteLine("charegement de l'alarme g�r�e");
            Assert.IsTrue(alarmegeree.ReadIfExists(nIdAlarmeGeree));

            CSpvCauseAlarme cause = new CSpvCauseAlarme(m_contexteDonnees);
            Console.WriteLine("chargement de la cause alarme");
            Assert.IsTrue(cause.ReadIfExists(nIdCause));


            CSpvAlarmg_Cause causeAlGeree = new CSpvAlarmg_Cause(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CSpvAlarmg_Cause.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAlarmg_Cause.c_champCAUSEAL_ID + "=@1", nIdCause));

            if (!causeAlGeree.ReadIfExists(filtre))
            {

                causeAlGeree.CreateNewInCurrentContexte(new object[] { alarmegeree.Id, cause.Id });
                
            }
            CResultAErreur result = CResultAErreur.True;
            result = causeAlGeree.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            



            Console.WriteLine("v�rification de l'affectation de la cause � l'alarme g�r�e");
            CFiltreData filtretest = new CFiltreData(CSpvAlarmg_Cause.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree);
            filtretest = CFiltreData.GetAndFiltre(filtretest, new CFiltreData(CSpvAlarmg_Cause.c_champCAUSEAL_ID + "=@1", nIdCause));

            CSpvAlarmg_Cause causetest = new CSpvAlarmg_Cause(m_contexteDonnees);
            Assert.IsTrue(causetest.ReadIfExists(filtre));


        }


        public void RetirerCauseAlarmeGeree(int nIdCause, int nIdAlarmeGeree)
        {


            //retire une cause d'alarme de la liste des causes possibles d'une  alarme g�r�e.
            CSpvAlarmGeree alarmegeree = new CSpvAlarmGeree(m_contexteDonnees);


            Console.WriteLine("chargement de l'alarme g�r�e");
            Assert.IsTrue(alarmegeree.ReadIfExists(nIdAlarmeGeree));

            Console.WriteLine("chargement de la cause d'alarme");
            CSpvCauseAlarme cause = new CSpvCauseAlarme(m_contexteDonnees);

            Assert.IsTrue(cause.ReadIfExists(nIdCause));

            CResultAErreur result = CResultAErreur.True;

            CSpvAlarmg_Cause causeAlGeree = new CSpvAlarmg_Cause(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CSpvAlarmg_Cause.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAlarmg_Cause.c_champCAUSEAL_ID + "=@1", nIdCause));

            if (causeAlGeree.ReadIfExists(filtre))
            {

                 result = causeAlGeree.Delete();
                 Console.WriteLine("suppression de l'affectation de la cause � l'alarme g�r�e");
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

            }
      


            CFiltreData filtretest = new CFiltreData(CSpvAlarmg_Cause.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree);
            filtretest = CFiltreData.GetAndFiltre(filtretest, new CFiltreData(CSpvAlarmg_Cause.c_champCAUSEAL_ID + "=@1", nIdCause));
            Console.WriteLine("v�rification de la suppression de l'affectation d'une cause d'alarme");
            CSpvAlarmg_Cause causetest = new CSpvAlarmg_Cause(m_contexteDonnees);
            Assert.IsTrue(!causetest.ReadIfExists(filtre));


        }


        private int CreerFamille(string libelle)
        {

            Console.WriteLine("Cr�ation de la  famille de types d'�quipment @1", libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (!famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1", libelle)))
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = libelle;
            
            }

            else
                Console.WriteLine("la famille existe d�j�");


            CResultAErreur result = CResultAErreur.True;
            result = famille.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int id = famille.Id;
            Console.WriteLine("v�rification de l'existence de la famille");
            CFamilleEquipement familletest = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(familletest.ReadIfExists(id));

            return famille.Id;

        }


        
        public void SupprimerTypeEquipement(int nId)
        {
            //suppession d'un type d'�quipment
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);


            Console.WriteLine("chargement du type d'�quipemnt � supprimer");
            if (typeq.ReadIfExists(nId))
            {

                Console.WriteLine("chargement du type d'�quipemnt SPV � supprimer");
                CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
                typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id+"=@1",nId));
                

                CResultAErreur result = typeq.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Console.WriteLine("suppression du type d'�quipemnt");
                Assert.IsTrue(result.Result);


            
             
                CSpvTypeq spvTest = new CSpvTypeq(m_contexteDonnees);
                Console.WriteLine("v�rification de la suppression du type SPV");
               Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id+"=@1",nId)));

               Console.WriteLine("v�rification de la suppression du type Timos");
               CTypeEquipement typeqTest = new CTypeEquipement(m_contexteDonnees);
               Assert.IsFalse(typeqTest.ReadIfExists(nId));

               


            }

        }

        private void SupprimerFamille(int nId)
        {


            Console.WriteLine("suppression d'une famille de type d'�quipement");

            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(nId));

            if (famille.ReadIfExists(nId))
            {
                CResultAErreur result = famille.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);





                CFamilleEquipement familleTest = new CFamilleEquipement(m_contexteDonnees);
                Console.WriteLine("V�rification de la suppression de la famille");
                Assert.IsFalse(familleTest.ReadIfExists(nId, true));

            }
        }

        public void SupprimerCablageAlarme(int nId)
        {

           //supprime le c�blage d'une alarme

            Console.WriteLine("Suppression d'un c�blage d'alarme");
           CSpvLienAccesAlarme lienAcces = new CSpvLienAccesAlarme(m_contexteDonnees);
            Console.WriteLine("chargement du len acc�s alarme");
            Assert.IsTrue(lienAcces.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID+"=@1",nId)));

            
            CResultAErreur result = CResultAErreur.True;



            
            result = lienAcces.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("suppression du c�blage d'alarme");
           Assert.IsTrue(result.Result);
      


            Console.WriteLine("v�rification de la suppression du c�blage d'alarme");
            CSpvLienAccesAlarme lienTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsFalse(lienTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID+"=@1",nId)));




        }

        private void ModifierEquipementAssurveiller(int nId, bool bNewToSurv)
        {
            
            //modifie le champ "A surveiller" d'un type d'�quipement
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("chargement  de l'�quipemnt");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData( CSpvEquip.c_champSmtEquipementLogique_Id+ "=@1", nId)));

            equipSpv.ASuperviser = bNewToSurv;

            CResultAErreur result = CResultAErreur.True;
            result = equipSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            CSpvEquip typeTest = new CSpvEquip(m_contexteDonnees);

            Console.WriteLine("v�rification du champ � surveiller");
            typeTest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + " =@1", nId));
            

            Assert.IsTrue(typeTest.ASuperviser == bNewToSurv);


        }




       
        public int LireIdTypeSite(string libelle)
        {
            //lit l'ID d'un type de site d�j� existant
            int id;
            Console.WriteLine("lecture de l'id du site " + libelle);
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            if (typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                  libelle)))
            {

                id = typeSite.Id;
                return id;
            }
            Console.WriteLine("l'id du type de site n'existe pas");
            return -1;


        }

        public int LireIdFamille(string libelle)
        {
            //lit l'id d'une famille d�finie par son libell�
            int id=-1;
            Console.WriteLine("lecture de l'id d'une famille de types d'�quipemnts");
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1",
                  libelle)))
            {

                id = famille.Id;                
            }

            Console.WriteLine("v�rification du libell�");
            Assert.AreEqual(libelle, famille.Libelle);
            return id;


          

        }

     
        public int LireIdSite(string libelle)
        {

           //lit l'id d'un site
            Console.WriteLine("lecture de l'id du site "+libelle);
            CSite site = new CSite(m_contexteDonnees);
            if (site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
                  libelle)))
            {

               return site.Id;
            }
            Console.WriteLine("v�rification du libell� du site");
            Assert.AreEqual(libelle, site.Libelle);
            return -1;


        }

        private int CreerTypeSite(string libelle)
        {


            //cr�er un type de site
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("cr�ation du type de site "+ libelle);
            if (!typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                libelle)))
            {
                typeSite.CreateNewInCurrentContexte();
                
               
            }
            typeSite.Libelle = libelle+"e";
            typeSite.Libelle = libelle;



            
            CResultAErreur result = CResultAErreur.True;
            result = typeSite.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            int nId = typeSite.Id;

            CSpvTypsite test = new CSpvTypsite(m_contexteDonnees);
            Console.WriteLine("v�rification de la cr�ation du type SPV");
            Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(test.TypeSiteNom == libelle);
            Console.WriteLine("v�rification du ClassId");
            Assert.IsTrue(test.TypeSiteClassId == 1053);

            return nId;







        }




        public int CreerTypeAccesAlarmeTypeq(int nTypeqId, string nomAcces, ECategorieAccesAlarme categorie)
        {

            // cr�e un type d'acc�s alarme sur un type d'�quipement
            CSpvTypeAccesAlarme typeAccesAlarme = new CSpvTypeAccesAlarme(m_contexteDonnees);

            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("Cr�ation d'un acc�s alarme sur l type d'�quipement");
            Console.WriteLine("Chargement du type d'�quipement");
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nTypeqId)));
            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomAcces);
            filtre=CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1", nTypeqId));
             
                      
                
            if (!typeAccesAlarme.ReadIfExists(filtre))
            {

               
                typeAccesAlarme.CreateNewInCurrentContexte();
                typeAccesAlarme.NomAcces = nomAcces;
                typeAccesAlarme.SpvTypeq = typeq;
                typeAccesAlarme.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                int nCat =categorieAcces.CodeInt; 
                typeAccesAlarme.CategorieAccesAlarme = categorieAcces;
            }
            else
                Console.WriteLine("le typeAcces d'acc�s alarme sur le type d'�quipemnt existe d�j�");


            Console.WriteLine("Enregistrement de l'acc�s alarme");
            CResultAErreur result = CResultAErreur.True;
            result = typeAccesAlarme.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            int nId = typeAccesAlarme.Id;


            return nId;
           




        }

       public int DupliquerSite(int nSiteId)
        {

           //duplique un site et v�rifie que les champs sont copi�s
            int idSite2=-1;

           
            CSite site = new CSite(m_contexteDonnees);
            CSite site2 = new CSite(m_contexteDonnees);
            CSpvSite spvSite = new CSpvSite(m_contexteDonnees);
            Console.WriteLine("Duplication d'un site");
            Console.WriteLine("Chargement du site d'origine");
            Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));

            if (site.ReadIfExists(nSiteId))
            {
                site2.CreateNewInCurrentContexte();
                site2.TypeSite = site.TypeSite;
                site2.Libelle = site.Libelle + " dup";

              

                CResultAErreur result = CResultAErreur.True;
                result = site2.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);
                idSite2 = site2.Id;
                





              // Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));

                CSpvSite siteSpv2 = new CSpvSite(m_contexteDonnees);
                Console.WriteLine("v�rification de la cr�ation du site dupliqu�");
                Assert.IsTrue(siteSpv2.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", idSite2.ToString())));


                siteSpv2.SNMP_Community = spvSite.SNMP_Community;
                siteSpv2.EmName = spvSite.EmName;
                siteSpv2.DomaineIP = spvSite.DomaineIP;

                CSpvSite siteTest2 = new CSpvSite(m_contexteDonnees);
                CSpvSite siteTest = new CSpvSite(m_contexteDonnees);

                Console.WriteLine("V�rification de l'existence du site d'origine dans SPV");
                Assert.IsTrue(siteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));
                Console.WriteLine("V�rification de l'existence du site dupliqu� dans SPV");
                Assert.IsTrue(siteTest2.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", idSite2.ToString())));

                Console.WriteLine("V�rification de l'�galit� des types de site");
                Assert.AreEqual(siteTest.TypeSite, siteTest2.TypeSite);
                Console.WriteLine("V�rification de l'�galit� de la communaut� SNMP");
                Assert.AreEqual(siteTest.SNMP_Community, siteTest2.SNMP_Community);
                Console.WriteLine("V�rification de l'�galit� du nom de l'�quipement de m�diation");
                Assert.AreEqual(siteTest.EmName, siteTest2.EmName);
                Console.WriteLine("V�rification de l'�galit� du domaine IP");
                Assert.AreEqual(siteTest.DomaineIP, siteTest2.DomaineIP);

            }


            return idSite2;
        }

        
        public int CreerSite(int nTypeSiteId,string nomSite)
        {
            //Cree un nouveau site

            CSite site = new CSite(m_contexteDonnees);
            if (!site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
               nomSite)))
            {
                Console.WriteLine("cr�ation du site");
               CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
                site.CreateNewInCurrentContexte();
                typeSite.ReadIfExists(nTypeSiteId);
                site.TypeSite=typeSite;
                site.Libelle=nomSite;

            }
            else
                System.Console.WriteLine("Le site existe d�j�");

              CResultAErreur result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);


          
            result = site.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            CSpvSite spvSiteTest = new CSpvSite(m_contexteDonnees);

            Console.WriteLine("V�rification du site SPV");
            Assert.IsTrue(spvSiteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id+"=@1",
                site.Id)));
            Console.WriteLine("V�rification du libell� du site SPV");
            Assert.AreEqual(site.Libelle, spvSiteTest.SiteNom);
            Console.WriteLine("V�rification du ClassId du site SPV");
            Assert.AreEqual(spvSiteTest.ClassId, 1008);
                       

           return site.Id;


        }



    


       
         public int CreerSite(int nTypeSiteId,string nomSite,string domaine,string cmnte, string emname)
        {
             //cr�e un site en pr�cisant le domaine et la communauit� SNMP

            CSite site = new CSite(m_contexteDonnees);
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);

            CResultAErreur result = CResultAErreur.True;
            if (!site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
               nomSite)))
            {
                Console.WriteLine("cr�ation du site");
                site.CreateNewInCurrentContexte();
                typeSite.ReadIfExists(nTypeSiteId);
                site.TypeSite = typeSite;
                site.Libelle = nomSite;

                Console.WriteLine("Enregistement du site");
               
                result = site.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

            }
            else
                Console.WriteLine("le site existe d�j�");


            Console.WriteLine("Mise � jour des champs du site SPV");
           CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
           siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
               site.Id));
           siteSpv.DomaineIP = domaine;
           siteSpv.EmName = emname;
           siteSpv.SNMP_Community = cmnte;

           
           result =siteSpv.VerifieDonnees(false);
           if (!result)
               System.Console.WriteLine(result.MessageErreur);
           Assert.IsTrue(result.Result);

           Console.WriteLine("enregistrement des donnees");
           m_contexteDonnees.SaveAll(true);
           if (!result)
               System.Console.WriteLine(result.MessageErreur);

           Assert.IsTrue(result.Result);
          
           CSpvTypsite typesitetest = new CSpvTypsite(m_contexteDonnees);

          
           

           CSpvSite siteSpvTest = new CSpvSite(m_contexteDonnees);
           Console.WriteLine("test de l'existence du site SPV");
           Assert.IsTrue( siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
               site.Id)));

           Console.WriteLine("Test du ClassId du site");
           Assert.AreEqual(siteSpv.ClassId,1008);
           Console.WriteLine("Test du libell� du site");
           Assert.AreEqual(siteSpv.SiteNom, site.Libelle);
            

           return site.Id;
    
           

        }
        /*


        public int CreerTypeEquipementPourTest(string libelle, int nFamilleId)
        {


            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(nFamilleId));


            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if (!typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", libelle)))
            {
                typeq.CreateNewInCurrentContexte();
                typeq.Libelle = libelle;
                typeq.Famille = famille;


                CResultAErreur result = m_contexteDonnees.SaveAll(true);

                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
              

                result = m_contexteDonnees.SaveAll(true);

                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);
            }
            else
                Console.WriteLine("le type d'�quipement existe d�j�");



            CSpvTypeq typeqTest = new CSpvTypeq(m_contexteDonnees);

            typeqTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeq.Id));


            Console.WriteLine(typeqTest.Libelle);
            Console.WriteLine(typeq.Libelle);
            Console.WriteLine(typeqTest.TYPEQ_CLASSId);
            Assert.IsTrue(typeqTest.Libelle == typeq.Libelle);
            Assert.IsTrue(typeqTest.TYPEQ_CLASSID == 1024);




            return typeq.Id;
        }

        */

       public void ModifierSite(int nSiteId, string newLibelle)
        {


            CSite siteLibelle = new CSite(m_contexteDonnees);
            //Modification du libell� d'un site


            if (!siteLibelle.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1", newLibelle)))
            {
                CSite site = new CSite(m_contexteDonnees);

                Assert.IsTrue(site.ReadIfExists(nSiteId));

                site.Libelle = newLibelle;

                Console.WriteLine("enregistrement du site");
                CResultAErreur result = CResultAErreur.True;
                result = site.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

                CSpvSite spvSite = new CSpvSite(m_contexteDonnees);
                Console.WriteLine("chargement du site SPV");
                Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                     nSiteId)));
                Console.WriteLine("Test  du libell� du site SPV");
                Assert.AreEqual(newLibelle, spvSite.SiteNom);
            }

            else
                Console.WriteLine("un site avec le m�me libell� existe d�j� dans la base");
            
        }


        
       public void ModifierSiteSansValider(int nSiteId, string newLibelle)
        {
            Console.WriteLine("Modification d'un site sans valider");
            CSite site = new CSite(m_contexteDonnees);
            string oldLibelle;
           Console.WriteLine("chargement du site � modifier");
            Assert.IsTrue (site.ReadIfExists(new CFiltreData(CSite.c_champId + "=@1", nSiteId)));
            
                oldLibelle = site.Libelle;
                site.Libelle = newLibelle;

             
               
                
                CSpvSite spvSite = new CSpvSite(m_contexteDonnees);
                Console.WriteLine("Lecture du site SPV");
                Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nSiteId)));
                Console.WriteLine("v�rification du libell�");
                Assert.AreEqual(oldLibelle, spvSite.SiteNom);
                      
           

            
        }



        public void ModifierAddrIpEquip(int nEquipId, string newAddrIp)
        {

            Console.WriteLine("Modification de l'adresse IP d'un �quipemnt");
           
            CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));

            equip.AdresseIP = newAddrIp;

            CResultAErreur result = CResultAErreur.True;
            result =equip.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

        }


        public void ModifierDomaine(int nSiteId, string newDomaine)
        {

            //modifie le nom de domaine d'un site
            Console.WriteLine("Modification du nom de domaine d'un site");

            Console.WriteLine("lecture du site SPV");
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                nSiteId)));
            string strOldDomaine = siteSpv.DomaineIP;
            siteSpv.DomaineIP = newDomaine;

            CResultAErreur result = CResultAErreur.True;
            result = siteSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            Console.WriteLine("Chargement du site SPV");
            CSpvSite siteTest = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nSiteId)));
            Console.WriteLine("v�rification du nom du domaine");
            Assert.AreEqual(siteTest.DomaineIP, newDomaine);



        }

        public void ModifierCommunaute(int nSiteId, string newCommunaute)
        {
            //modifie la communaut� d'un site


            Console.WriteLine("modification de la communaut� d'un site");
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
             Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                  nSiteId)));
             string strOldCommunaute = siteSpv.SNMP_Community;
            siteSpv.SNMP_Community = newCommunaute;

            Console.WriteLine("Enregistrement du site");
            CResultAErreur result = CResultAErreur.True;
            result = siteSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            CSpvSite siteTest = new CSpvSite(m_contexteDonnees);
            Console.WriteLine("chargement du site SPV");
            Assert.IsTrue(siteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nSiteId)));
            Console.WriteLine("Test de la communaut� d'un site");
            Assert.AreEqual(siteTest.SNMP_Community, newCommunaute);
            
        }



        public int CreerTypeAccesAlarme(int nTypeqId, string nomAcces, ECategorieAccesAlarme categorie)
        {

            //Cr�ation d'un type d'acc�s alarme sur un type d'�quipement 

            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            
            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);

            Console.WriteLine("Cr�ation d'un type d'acc�s alarme sur un type d'�quipement ");

            Console.WriteLine("Lecture du type d'�quipement");
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nTypeqId)));

            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomAcces);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1", typeq.Id));

            if (!typeAcces.ReadIfExists(filtre))
            {

                typeAcces.CreateNewInCurrentContexte();
                typeAcces.NomAcces = nomAcces;
                typeAcces.SpvTypeq = typeq;
                typeAcces.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                typeAcces.CategorieAccesAlarme = categorieAcces;
            }
            else

                Console.WriteLine("L'acc�s alarme existe d�j�");
            CResultAErreur result = CResultAErreur.True;
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            Console.WriteLine("Enregistement du type acc�s alarme");
           
            Assert.IsTrue(result.Result);


         


            



            return typeAcces.Id;

        }

        public void ModifierEmName(int nSiteId, string newEmName)
        {

            Console.WriteLine("Modification du nom de l'�quipement de m�diation d'un site");

            Console.WriteLine("lecture du site");
                CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
                siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nSiteId));

                siteSpv.EmName = newEmName;


                Console.WriteLine("enregistrement du site");
             CResultAErreur result = CResultAErreur.True;
            result = siteSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            Console.WriteLine("Lecture du site SPV");
            CSpvSite siteTest = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nSiteId)));
            Console.WriteLine("Test du nom de l'�quipement de m�diation");
            Assert.AreEqual(siteTest.EmName, newEmName);
           

            
        }


        public void SupprimerSite(int nIdSite)
        {

            //supprime un site de la base de donn�es

            Console.WriteLine("Suppression d'un site");
            CSite site = new CSite(m_contexteDonnees);
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);

            Console.WriteLine("Lecture du site timos");
            CResultAErreur result = CResultAErreur.True;
            if (site.ReadIfExists(nIdSite))
            {

                Console.WriteLine("lecture du site SPV");
              
               

               result= site.Delete();
            
               if (!result)
                   System.Console.WriteLine(result.MessageErreur);
               Assert.IsTrue(result.Result);
              
            }


         

            CSite siteTest = new CSite(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression du site Timos");


            CSpvSite spvTest = new CSpvSite(m_contexteDonnees);
            Assert.IsFalse(siteTest.ReadIfExists(nIdSite));

            Console.WriteLine("V�rification de la suppression du site SPV");
            Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nIdSite)));


        }


        public void SupprimerTypeSite(int nIdSite)
        {
            //supprime un type de site

            Console.WriteLine("Suppression d'un type de site");
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            CSpvTypsite typeSiteSpv = new CSpvTypsite(m_contexteDonnees);
            
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("chargement du site � supprimer");
            Assert.IsTrue(typeSite.ReadIfExists(nIdSite));
           
            

         

            result = typeSite.Delete();

            Console.WriteLine("Suppression du type de site");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
                

           

            CTypeSite typesiteTest = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression du type de site Timos");

            Assert.IsFalse(typesiteTest.ReadIfExists(nIdSite));

            CSpvTypsite spvTest = new CSpvTypsite(m_contexteDonnees);
            Assert.IsFalse(typesiteTest.ReadIfExists(nIdSite));

            Console.WriteLine("V�rification de la suppression du type de site SPV");
            Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", nIdSite)));



            
        }





        public int CreerTypeAccesAlarmeSite(string nomType, int nSiteId, ECategorieAccesAlarme categorie)
        {
            //cr�ation d'un type d'acc�s alarme pour un site
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);


            Console.WriteLine("Cr�ation d'un acc�s alarme site");
            CSpvSite site = new CSpvSite(m_contexteDonnees);
            Console.WriteLine("lecture du site");
            Assert.IsTrue(site.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));

            int spvSiteId = site.Id;
            // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1" + " AND " + CSpvTypeAccesAlarme.c_champACCES_NOM + "=@2", nSiteId, nomType);

            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomType);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1", spvSiteId));
            if (!typeAcces.ReadIfExists(filtre))
            {
                typeAcces.CreateNewInCurrentContexte();
                typeAcces.NomAcces = nomType;
                typeAcces.SpvSite = site;
                typeAcces.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                typeAcces.CategorieAccesAlarme = categorieAcces;
            }
            else
                System.Console.WriteLine("Le type d'acc�s existe d�j�");

             CResultAErreur result = CResultAErreur.True;
             Console.WriteLine("v�rification des donn�es");
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            return typeAcces.Id;





        }


        public void ModifierTypeqToSurv(int nId, bool bNewToSurv)
        {
            //modifie la valeur "a surveiller" d'un type d'�quipement;

            Console.WriteLine("chargement du type d'�quipemnt");

            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData( CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            typeqSpv.ASurveiller = bNewToSurv;
            

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = typeqSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            CSpvTypeq typeTest = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipemnt spv");
            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));
            
            Console.WriteLine("v�rification de la valuer A surveiller");
            Assert.IsTrue(typeTest.ASurveiller == bNewToSurv);


        }
        

        public int CreerTypeAccesEntreeEquipement(int typeqId,string nomType)
        {
            //cr�e un type d'acc�s entr�e alarme sur un type �quipement

            Console.WriteLine("cr�ation d'une entr�e alarme");

            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            
            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("chargement du type d'�quipement");
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData( CSpvTypeq.c_champSmtTypeEquipement_Id+"=@1", typeqId)));
            int spvTypeqId = typeq.Id;
            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomType);
            filtre=CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champTYPEQ_ID+"=@1",spvTypeqId));

            if (!typeAcces.ReadIfExists(filtre))
            {

                typeAcces.CreateNewInCurrentContexte();
                typeAcces.NomAcces = nomType;
                typeAcces.SpvTypeq = typeq;
                typeAcces.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(ECategorieAccesAlarme.EntreeBoucle);
                typeAcces.CategorieAccesAlarme = categorieAcces;
            }
            else
                Console.Write("le type d'acc�s sur le type d'�quipement existe d�j�");


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            
            Console.WriteLine("sauvegarde du type acc�s alarme");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            int nid = typeAcces.Id;

            CSpvTypeAccesAlarme typeTest = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Console.WriteLine("lecture du type acc�s alarme");
            Assert.IsTrue(typeTest.ReadIfExists(new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_ID + "=@1", nid)));
            Console.WriteLine("v�rification du nom de l'acc�s");
            Assert.IsTrue(typeAcces.NomAcces == nomType);
             Console.WriteLine("v�rification du type d'�quipemnt");
            Assert.IsTrue(typeAcces.SpvTypeq.Id == spvTypeqId);

            return nid;
        }

        public int CablerAccesAlarme(int nIdAcces1,int nIdAcces2,int nIdAlarmeGeree, int nSiteId, int nEquipId, string addrIP,EGraviteAlarmeAvecMasquage gravite)
        {

            //Effectue le c�blage d'un acc�s alarme entre un site et un �quipement

            int nId = -1;
            Console.WriteLine("chargement de l'�quipement entr�e alarme");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1",nEquipId)));
            int nEquipSpvId = equipSpv.Id;

            Console.WriteLine("chargement du site");
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",nSiteId)));


            Console.WriteLine("lecture de l'acc�s alarme site");
            CSpvAccesAlarme acces1 = new CSpvAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(acces1.ReadIfExists(nIdAcces1));
            Console.WriteLine("lecture de l'acc�s alarme �quipement");
            CSpvAccesAlarme acces2 = new CSpvAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(acces2.ReadIfExists(nIdAcces2));
            Console.WriteLine("lecture de l'alarme g�r�e");
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
            Assert.IsTrue(alarmeGeree.ReadIfExists(nIdAlarmeGeree));
            CSpvLienAccesAlarme lienAcces = new CSpvLienAccesAlarme(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CSpvLienAccesAlarme.c_champACCES1_ID + "=@1",nIdAcces1.ToString());
            filtre= CFiltreData.GetAndFiltre(filtre,new CFiltreData(CSpvLienAccesAlarme.c_champACCES2_ID + "=@1",nIdAcces2.ToString()));
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree.ToString()));
           
            if (!lienAcces.ReadIfExists(filtre))
             {
              
                   
               lienAcces.CreateNewInCurrentContexte();
               lienAcces.AccesAlarmeOne = acces1;
               lienAcces.AccesAlarmeTwo = acces2;
               //lienAcces.SpvAlarmgeree = alarmeGeree;
               lienAcces.SeuilBas = 0;
               lienAcces.SeuilHaut =0;
               lienAcces.FreqNb = 0;
               lienAcces.FreqPeriod =1;
               CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
               lienAcces.Gravite = grav;
               //lienAcces.SpvEquip = equipSpv;
               lienAcces.SpvSite = siteSpv;
               
               //lienAcces.EquipAddrIP = addrIP;

             //  lienAcces.MaskAdminMax = 0;
              // lienAcces.MaskAdminMin = 0;
              // lienAcces.MaskBriMax = 0;
              // lienAcces.MaskBriMin = 0;
                lienAcces.Surveiller = true;
                lienAcces.Afficher = true;
                lienAcces.Acquitter = true;
               



                }
                else
                    Console.WriteLine("le lien acc�s alarme existe d�j�");

         //   lienAcces.EquipAddrIP = addrIP;
            Console.WriteLine("sauvegarde du c�blage acc�s alarme");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = lienAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            
            nId = lienAcces.Id;


            Console.WriteLine("Lecture du c�blage d'acc�ss alarme");
            CSpvLienAccesAlarme accesTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(accesTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID +"=@1",nId)));
            Console.WriteLine("v�rification de l'acc�s sortie");
            Assert.IsTrue(accesTest.AccesAlarmeOne.Id == acces1.Id);
            Console.WriteLine("v�rification de l'aac�s entr�e");
            Assert.IsTrue(accesTest.AccesAlarmeTwo.Id == acces2.Id);
        



            return nId;

        }






        public int CreerAlarme(int EquipId, int AlarmeGereeId, string AlarmeNom, EAlarmEvent AlarmeEvt, EGraviteAlarmeAvecMasquage gravite, string accesNom, int cablageId)
        {
            int nId = -1;

            CSpvAlarmTest alarme = new CSpvAlarmTest(m_contexteDonnees);
            CSpvEquip spvEquip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("Cr�ation d'une alarme sur un �quipement");

           Console.WriteLine("Lecture de l'�quipement");
            Assert.IsTrue(spvEquip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id +" =@1",EquipId)));

             
                alarme.CreateNewInCurrentContexte();
                alarme.EquipId = spvEquip.Id;
                alarme.AlarmNum = 1;
                CAlarmEvent almEvt = new CAlarmEvent(AlarmeEvt);
                alarme.AlarmEvent = almEvt;
               
                alarme.Name = AlarmeNom;
                alarme.AlarmgereeId = AlarmeGereeId;
                alarme.AlarmCategory = "IP2";
                alarme.AlarmNumObj = 1000;
             
                alarme.CodeAlarmNature = 1;
                alarme.AccesAccescId = cablageId;
                alarme.AlarmNumAl = spvEquip.AdresseIP;
                alarme.AlarmNum = 1;
                alarme.CodeAlarmNature = 1;
                alarme.AlarmComment = "3052";
                alarme.AlarmIANA = 3052;
                alarme.SequenceNumber = -1;
                alarme.AlarmTypMAJ = "0";
               
               
            
            DateTime dateAlarme = DateTime.Now;
            string strDate = dateAlarme.ToString();
            alarme.AlarmDateText = strDate;
            CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
            alarme.AlarmGrave = grav;
            string alarmInfo = spvEquip.Id + ";.1.3.6 = DIG" + accesNom;
            if (grav.CodeInt > 0)
                alarmInfo += "_ON";
            else
                alarmInfo += "_OFF";
            alarme.AlarmInfo = alarmInfo;

        
            
            Console.WriteLine("Enregistrement de l'alarme");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = alarme.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            nId = alarme.Id;
            alarme.AlarmNum = nId;

        /*    EGraviteAlarmeAvecMasquage graviteAlarme = new EGraviteAlarmeAvecMasquage(gravite);
            alarme.AlarmGrave = graviteAlarme;*/
//           alarme.AlarmNum = nId;
       /*    result = m_contexteDonnees.SaveAll(true);
            if (!result) 
                 System.Console.WriteLine(result.MessageErreur);
           Assert.IsTrue(result.Result);*/

          //  CSpvAlarmTest alarmTest = new CSpvAlarmTest(m_contexteDonnees);
        //    Assert.IsTrue(alarmTest.ReadIfExists(new CFiltreData(CSpvAlarmTest.c_champALARM_ID + "=@1", nId)));
            //Assert.IsTrue(alarmTest.AlarmgereeId == AlarmeGereeId);

            //Console.WriteLine(alarmTest.AlarmgereeId);
            return nId;

            

        }



        public int CreerAlarmeSite(int SiteId, int EquipId, int AlarmeGereeId, string sortieNom, EAlarmEvent AlarmeEvt, EGraviteAlarmeAvecMasquage gravite, string accesNom, int cablageId)
        {
            //cr�e une alarme boucle sur un site
           
            int nId = -1;

            CSpvAlarmTest alarme = new CSpvAlarmTest(m_contexteDonnees);
            CSpvEquip spvEquip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("Cr�ation d'une alarme sur un site");

            Console.WriteLine("lecture de l'�quipemnt entr�e alarme");
            Assert.IsTrue(spvEquip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + " =@1", EquipId)));

                alarme.CreateNewInCurrentContexte();
                alarme.SiteId = SiteId;
                alarme.AlarmNum = 1;
                CAlarmEvent almEvt = new CAlarmEvent(AlarmeEvt);
                alarme.AlarmEvent = almEvt;
                alarme.Name = sortieNom;
                alarme.AlarmgereeId = AlarmeGereeId;
                alarme.AlarmCategory = "IP2";
                alarme.AlarmNumObj = 1000;
                alarme.CodeAlarmNature = 1;
                alarme.AccesAccescId = cablageId;
                alarme.AlarmNumAl = spvEquip.AdresseIP;

                alarme.CodeAlarmNature = 1;
                alarme.AlarmComment = "3052";
                alarme.AlarmIANA = 3052;
                alarme.SequenceNumber = -1;
                alarme.AlarmTypMAJ = "0";
                DateTime dateAlarme = DateTime.Now;
                string strDate = dateAlarme.ToString();
                alarme.AlarmDateText = strDate;
               
                string alarmInfo = spvEquip.Id + ";.1.3.6 = DIG" + accesNom + "_ON";
               alarme.AlarmInfo = alarmInfo;
                alarme.CodeAlarmGrave = 4;

            

            //    EGraviteAlarmeAvecMasquage grav = new EGraviteAlarmeAvecMasquage(gravite);
            //    alarme.AlarmGrave = grav;
            

            Console.WriteLine("enregistrement de l'alarme");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = alarme.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            nId = alarme.Id;

            

            //    EGraviteAlarmeAvecMasquage graviteAlarme = new EGraviteAlarmeAvecMasquage(gravite);
            //    alarme.AlarmGrave = graviteAlarme;
            alarme.AlarmNum = nId;


            Console.WriteLine("enregistrement de ALARM_NUM");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            return nId;



        }



        private void ModifierGraviteAlarmeGeree(int nIdAlarmeGeree, EGraviteAlarmeAvecMasquage gravite)
        {
            Console.WriteLine("Modification de la gravite d'une alarme g�r�e");
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
            Console.WriteLine("Modification de l'alarme g�r�e");
            Assert.IsTrue(alarmeGeree.ReadIfExists(nIdAlarmeGeree));
            CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
            int codeGrav =grav.CodeInt;
              alarmeGeree.AlarmgereeGravite = grav;
                
                
               

                Console.WriteLine("sauvegarde de l'alarme g�r�e");
                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result =alarmeGeree.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);



              

                CSpvAlarmGeree test = new CSpvAlarmGeree(m_contexteDonnees);

                Console.WriteLine("v�rification de l'alarme g�r�e");
                Assert.IsTrue(test.ReadIfExists(nIdAlarmeGeree));
                
                Console.WriteLine("v�rification de la gravit� alarme");
                Assert.IsTrue(test.CodeAlarmgereeGravite == codeGrav);



        }

        public void ModifierTypeAccesAlarme(int nId, string newLibelle, int newConnectionsNumber,ECategorieAccesAlarme categorie)
        {
            //modifie un type d'acc�s alarme


            CSpvTypeAccesAlarme typeLibelle = new CSpvTypeAccesAlarme(m_contexteDonnees);
            if (!typeLibelle.ReadIfExists(new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", newLibelle)))
            {

                Console.WriteLine("modification d'un ttype d'acc�s alarme");
                CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);

                CSpvSite site = new CSpvSite(m_contexteDonnees);
                if (typeAcces.ReadIfExists(nId))
                {
                    typeAcces.NomAcces = newLibelle;
                    typeAcces.ConnectionsNumber = newConnectionsNumber;
                    CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                    typeAcces.CategorieAccesAlarme = categorieAcces;

                }
                Console.WriteLine("enregistrement des modifications");
                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result = typeAcces.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);
                Console.WriteLine("test du nom de l'acc�s");
                Assert.AreEqual(newLibelle, typeAcces.NomAcces);
                Console.WriteLine("test du nombre de connections");
                Assert.AreEqual(newConnectionsNumber, typeAcces.ConnectionsNumber);
                Console.WriteLine("test du code de la cat�gorie d'acc�s");
                Assert.AreEqual(categorie, typeAcces.CategorieAccesAlarme.Code);
            }
            else
                Console.WriteLine("un acc�s alarme avec ce nom existe d�j�");
        }


        public void SupprimerTypeAccesAlarme(int nId)
        {
            //supprime un type d'acc�s alarme
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);

            Console.WriteLine("suppression d'un type d'acc�s alarme");
            CResultAErreur result = CResultAErreur.True;
            if (typeAcces.ReadIfExists(nId))
            {
               result =  typeAcces.Delete();

               if (!result)
                   System.Console.WriteLine(result.MessageErreur);

            
          Console.WriteLine("enregistement de la suppression");
          result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            }
                      

            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("v�rification de la suppression");
            CSpvTypeAccesAlarme typeTest = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Assert.IsFalse(typeTest.ReadIfExists(nId));

        }


        public void SupprimerAlarmeGeree(int nId)
        {
            //supprime une alarme g�r�e
            Console.WriteLine("suppression d'une alarme g�r�e");
            CResultAErreur result = CResultAErreur.True;
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
            if (alarmeGeree.ReadIfExists(nId))
            {
                Console.WriteLine("suppression de l'alarme g�r�e");
                result=alarmeGeree.Delete();
                if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            }
          

            CSpvAlarmGeree almTest = new CSpvAlarmGeree(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression");
            Assert.IsFalse(almTest.ReadIfExists(nId));

        }

        public int RecupererIdAlarmeGeree(int accesId,string nomAlarme)
        {
            //r�cup�re l'id d'une alarme g�r�e li�e � un acc�s
            CSpvAlarmGeree alarmegeree = new CSpvAlarmGeree(m_contexteDonnees);
            CFiltreData filtre =new CFiltreData(CSpvAlarmGeree.c_champALARMGEREE_NOM + "=@1",nomAlarme);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", accesId));
            Console.WriteLine("lecture de l'alarme geree");
           Assert.IsTrue(alarmegeree.ReadIfExists(filtre));



            return alarmegeree.Id;


        }





        public void ModifierGraviteCablageAlarme(int nIdCablage, EGraviteAlarmeAvecMasquage gravite)
        {
            Console.WriteLine("modification de la gravite de l'alarme");

            CSpvLienAccesAlarme lienAcces = new CSpvLienAccesAlarme(m_contexteDonnees);

            Assert.IsTrue(lienAcces.ReadIfExists(nIdCablage));

            CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
            lienAcces.Gravite = grav;


            CResultAErreur result = CResultAErreur.True;
            result = lienAcces.VerifieDonnees(false);
            Console.WriteLine("v�rification des donn�ees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int nId = lienAcces.Id;

            CSpvLienAccesAlarme test = new CSpvLienAccesAlarme(m_contexteDonnees);
            Console.WriteLine("lecture du cablage alarme");
            Assert.IsTrue(test.ReadIfExists(nId));
            Console.WriteLine("lecture de la gravit�");
            Assert.IsTrue(test.Gravite.CodeInt == grav.CodeInt);
            Console.WriteLine(test.Gravite.CodeInt);



        }




        public int CreerAlarmeGeree(int nIdTypeAcces, EAlarmEvent evt, EGraviteAlarmeAvecMasquage gravite)
        {

            //cr�e une alarme g�r�e
            int nId=-1;

            Console.WriteLine("cr�ation d'une alarme g�r�e");
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            if (typeAcces.ReadIfExists(nIdTypeAcces))
            {

                if (!alarmeGeree.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", nIdTypeAcces)))
                {

                    alarmeGeree.CreateNewInCurrentContexte();
                    alarmeGeree.Alarmgeree_Name = typeAcces.NomAcces;
                    alarmeGeree.TypeAccesAlarme = typeAcces;
                    CAlarmEvent evenement = new CAlarmEvent(evt);
                    alarmeGeree.AlarmgereeEvent = evenement;
                    CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
                    alarmeGeree.AlarmgereeGravite = grav;

                    alarmeGeree.AlarmgereeAfficher = true;
                    alarmeGeree.Alarmgeree_Acquitter = true;

                    alarmeGeree.AlarmgereeSurveiller = true;
                
                }
               

                Console.WriteLine("sauvegarde de l'alarme g�r�e");
                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result = alarmeGeree.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);


                nId = alarmeGeree.Id;

                CSpvAlarmGeree test = new CSpvAlarmGeree(m_contexteDonnees);
                Console.WriteLine("v�rification de la cr�ation de l'alarme g�r�e");
                Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champALARMGEREE_ID + "=@1", nId)));


                Console.WriteLine(test.AlarmgereeGravite.Libelle);

              //  Assert.IsTrue(test.AlarmgereeGravite.Libelle = gravite.ToString());

            }

            return nId;
            
        }




        public void ModifierAlarmeGeree(int nId, string newLibelle, EAlarmEvent evt, EGraviteAlarmeAvecMasquage gravite)
        {
           //modifie une alarme g�r�e
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);


            if (alarmeGeree.ReadIfExists(nId))
            {
                string oldLibelle = alarmeGeree.Alarmgeree_Name;
                alarmeGeree.Alarmgeree_Name = newLibelle;

                CAlarmEvent evenement = new CAlarmEvent(evt);
                alarmeGeree.AlarmgereeEvent = evenement;
                CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
                alarmeGeree.AlarmgereeGravite = grav;



                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result = alarmeGeree.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

                Assert.AreEqual(alarmeGeree.Alarmgeree_Name, oldLibelle);
                Assert.AreEqual(alarmeGeree.AlarmgereeEvent.Code, evt);
                Assert.AreEqual(alarmeGeree.AlarmgereeGravite.Code, gravite);
            }
            

        }

        public int RecupererAccesAlarmeSite(string nomAcces, int nSiteId)
        {
            //r�cup�re l'id de l'acc�s alarme d'un site
            int nId = -1;

            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id+"=@1",nSiteId)));
            int nIdSiteSpv=siteSpv.Id;
            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);

           // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1" + " AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2", nIdSiteSpv.ToString(),nomAcces);
          
           CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1",nIdSiteSpv.ToString());
           filtre=CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM+ "=@1",nomAcces));
            Assert.IsTrue(accesAlarme.ReadIfExists(filtre));
            nId = accesAlarme.Id;
            return (nId);
        }


        public int RecupererAccesAlarmEquip(string nomAcces, int nEquipId)
        {
                 //r�cup�re l'id de l'acc�s alarme d'un �quipemnt
            int nId = -1;

            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));
            int nIdSpv = equipSpv.Id;
            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);
           // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1" + " AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2", nIdSpv.ToString(),nomAcces);
           
            CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + " =@1", nIdSpv.ToString());
            filtre=CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nomAcces));
            Assert.IsTrue(accesAlarme.ReadIfExists(filtre));
            nId = accesAlarme.Id;
            return (nId);
        }



       

        
   /*     public int CreerAccesAlarme(int typeAlarmeId, int siteId, int nbConnections,string nom)
        {

            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);

            CSpvSite spvSite = new CSpvSite(m_contexteDonnees);
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id+"=@1",siteId)));
            Assert.IsTrue(typeAcces.ReadIfExists(typeAlarmeId));

            accesAlarme.CreateNewInCurrentContexte();
            accesAlarme.SpvSite = spvSite;
            accesAlarme.NomAcces = nom;
            Assert.IsTrue(m_contexteDonnees.SaveAll(true));



            return accesAlarme.Id;

          

        }*/


        public void ModifierNomAcces(int nId, string nom)
        {

            CSpvAccesAlarme accesLibelle = new CSpvAccesAlarme(m_contexteDonnees);
            if (!accesLibelle.ReadIfExists(new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nom)))
            {
                //modifie le nom d'un acc�s alarme
                CSpvAccesAlarme acces = new CSpvAccesAlarme(m_contexteDonnees);
                Console.WriteLine("lecture de l'acc�s alarme");
                Assert.IsTrue(acces.ReadIfExists(nId));
                acces.NomAcces = nom;

                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result = acces.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

                CSpvAlarmGeree alarme = new CSpvAlarmGeree(m_contexteDonnees);
                Assert.IsTrue(alarme.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", nId)));

                Assert.IsTrue(alarme.Alarmgeree_Name == nom);

            }
            else
                Console.WriteLine("un acc�s alarme portant ce nom existe d�j�");
        }


        public void ModifierTypeAcces(int nId, ECategorieAccesAlarme type)
        {
            //modifie le type (cat�gorie) d'un acc�s alarme
            CSpvAccesAlarme acces = new CSpvAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(acces.ReadIfExists(nId));


            CCategorieAccesAlarme categ = new CCategorieAccesAlarme(type);
            acces.CategorieAccesAlarme = categ;

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result =acces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

        }


        public int CreerTypeEquipement(string libelle)
        {
            //cr�e un type d'�quipement
            string c_strFam = "TEST_S1_FAMILLE1";
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if(!famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle+ "=@1", c_strFam)))
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = c_strFam;

                Assert.IsTrue(m_contexteDonnees.SaveAll(true));
            }

            int idfamille = famille.Id;

            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if (!typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", libelle)))
            {
                typeq.CreateNewInCurrentContexte();
                typeq.Libelle = libelle;
                typeq.Famille = famille;

            }
            else
                Console.WriteLine("le type d'�quipement existe d�j�");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = typeq.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            return typeq.Id;
        }

        public int LireIdEquipementLogique(string nom)
        {
            //r�cup�re l'id d'un �quipemnt existant
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle+"=@1",nom)));

            return equip.Id;


        }

        private int CreerTypeEquipement(string libelle, int nFamilleId)
        {

            Console.WriteLine("Lecture de la famille de types" + libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(nFamilleId));


            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if (!typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", libelle)))
            {
                typeq.CreateNewInCurrentContexte();
                typeq.Libelle = libelle;
                typeq.Famille = famille;


            }
            else
                Console.WriteLine("le type d'�quipement existe d�j�");



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = typeq.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            CSpvTypeq typeqTest = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("Lecture du type d'�quipement SPV");
            typeqTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeq.Id));

            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(typeqTest.Libelle == typeq.Libelle);
            Console.WriteLine("V�rification du class_id");
            Assert.IsTrue(typeqTest.TYPEQ_CLASSID == 1024);




            return typeq.Id;
        }


        public int LireIdTypeq(string nom)
        {
          //r�cup�re l'id d'un type d'�quipement existant
            CTypeEquipement equip = new CTypeEquipement(m_contexteDonnees);
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", nom)));

            return equip.Id;


        }


        public int CreerEquipement(int TypeqId, string libelle, int SiteId)
        {
            //cr�e un �quipement sur un site
            int nId = -1;

            Console.WriteLine("cr�ation de l'�quipement" + libelle);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if(typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champId+"=@1",TypeqId)))
            {

                CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
                if (!equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", libelle))) 
                {
                    equip.CreateNewInCurrentContexte();
                    equip.Libelle = libelle;
                    equip.TypeEquipement = typeq;
                    CSite site = new CSite(m_contexteDonnees);
                    Console.WriteLine("v�rification de l'existence du site");
                    Assert.IsTrue(site.ReadIfExists(SiteId));
                        equip.Site = site;

                        CResultAErreur result = CResultAErreur.True;
                        Console.WriteLine("v�rification des donn�es");
                        result = equip.VerifieDonnees(false);
                        if (!result)
                            System.Console.WriteLine(result.MessageErreur);
                        Assert.IsTrue(result.Result);

                        Console.WriteLine("enregistrement des donnees");
                        m_contexteDonnees.SaveAll(true);
                        if (!result)
                            System.Console.WriteLine(result.MessageErreur);

                        Assert.IsTrue(result.Result);
                   
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);

                    Console.WriteLine("enregistrement de l'�quipement ");
                    Assert.IsTrue(result.Result); 
                    
                                       


                     CSpvEquip test = new CSpvEquip(m_contexteDonnees);
                    Console.WriteLine("lecture de l'�quipement SPV");
                     Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id+"=@1",equip.Id)));

                     test.ASuperviser = true;
                  
                     Console.WriteLine("v�rification des donn�es");
                     result = test.VerifieDonnees(false);
                     if (!result)
                         System.Console.WriteLine(result.MessageErreur);
                     Assert.IsTrue(result.Result);

                     Console.WriteLine("enregistrement des donnees");
                     m_contexteDonnees.SaveAll(true);
                     if (!result)
                         System.Console.WriteLine(result.MessageErreur);

                     Assert.IsTrue(result.Result);

                     Console.WriteLine("enregistrement du champ 'a superviser'");
                     if (!result)
                         System.Console.WriteLine(result.MessageErreur);
                     Assert.IsTrue(result.Result); 
                    
                    
                }
                else
                    Console.WriteLine("l'�quipement existe d�j�");

                nId = equip.Id;
            }

            return nId;
        }



        public int CreerEquipement(int TypeqId, string libelle, int SiteId,string addrip)
        {
            //cr�e un �quipemnt en pr�cisant son addresse ip
            int nId = -1;

            Console.WriteLine("cr�ation de l'�quipement" + libelle);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if (typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champId + "=@1", TypeqId)))
            {

                CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
                if (!equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", libelle)))
                {
                    equip.CreateNewInCurrentContexte();
                    equip.Libelle = libelle;
                    equip.TypeEquipement = typeq;
                    Console.WriteLine("v�rification de l'existence du site");
                    CSite site = new CSite(m_contexteDonnees);
                    Assert.IsTrue(site.ReadIfExists(SiteId));
                    equip.Site = site;
                    CResultAErreur result = CResultAErreur.True;
                    Console.WriteLine("v�rification des donn�es");
                    result = equip.VerifieDonnees(false);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);

                    Console.WriteLine("enregistrement des donnees");
                    m_contexteDonnees.SaveAll(true);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);

                    Assert.IsTrue(result.Result);

                    

                    Console.WriteLine("lecture de l'�quipement SPV");
                    CSpvEquip spv = new CSpvEquip(m_contexteDonnees);
                    Assert.IsTrue(spv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equip.Id)));
                    spv.AdresseIP = addrip;

                    spv.ASuperviser = true;
                 
                    Console.WriteLine("v�rification des donn�es");
                    result = spv.VerifieDonnees(false);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);

                    Console.WriteLine("enregistrement des donnees");
                    m_contexteDonnees.SaveAll(true);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);

                    Assert.IsTrue(result.Result);

                    Console.WriteLine("enregistrement des champs SPV");
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);
                    
                }
                else
                    Console.WriteLine("l'�quipement existe d�j�");

                nId = equip.Id;


                System.Threading.Thread.Sleep(500);

                CSpvEquip test = new CSpvEquip(m_contexteDonnees);

                Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equip.Id)));

                Assert.IsTrue(test.AdresseIP == addrip);

            }

            return nId;
        }

/*
        void OnReceiveNotificationAlarmEnCours(IDonneeNotification donnee)
        {

            //Gestionnaire d'�v�nement pour la r�ception d'une alarme en cours

            Console.WriteLine("R�ception d'une notification d'alarme");
            CDonneeNotificationAlarmes donneeAlarme = donnee as CDonneeNotificationAlarmes;
            if (donneeAlarme == null)
            {
                m_bSortieAlarme = true;
                return;
            }
            m_bSortieAlarme = true;
            CEvenementAlarm[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarm evAlarme in lstAlarmes)
            {
                if (evAlarme.CategorieMessageAlarme == ECategorieMessageAlarme.AlarmStartStop)
                {
                    if (IsFrequentAlarm(evAlarme.EventAlarmStartStop.AlarmInfo))
                    {
                      //  MAJFrequentButtonText();
                        continue;
                    }

                    if (evAlarme.EventAlarmStartStop.AlarmInfo.SeverityCode == (int)EGraviteAlarmeAvecMasquage.EndAlarm
                        && evAlarme.EventAlarmStartStop.AlarmInfo.StartAlarmId > 0)
                    {
                        for (int i = 0; i < m_lstViewEnCours.Count; i++)
                        {
                            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                            if (infoAlarm != null && infoAlarm.IdSpvAlarme ==
                                evAlarme.EventAlarmStartStop.AlarmInfo.StartAlarmId)
                            {
                                m_lstViewEnCours.Remove(infoAlarm);
                                infoAlarm.DateFin = evAlarme.EventAlarmStartStop.AlarmInfo.AlarmDate;
                              //  m_lstViewRetombe.AddObject(infoAlarm);
                                break;
                            }
                        }
                    }
                    else
                    {
                      // CInfoAlarmeAffichee infoRecue = evAlarme.EventAlarmStartStop.AlarmInfo;
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.Info);
                    //    string nomElGere = infoRecue.ElementGereeName;
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.AlarmComment);
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.AlarmDate);
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.ElementGereeName);
                        m_commentAlrmeLue = evAlarme.EventAlarmStartStop.AlarmInfo.AlarmComment;
                        m_DateAlarmeLue = evAlarme.EventAlarmStartStop.AlarmInfo.AlarmDate.ToString();
                        m_TypealarmeLue = evAlarme.EventAlarmStartStop.AlarmInfo.ElementGereeType;
                        m_nomAlarmeLue = evAlarme.EventAlarmStartStop.AlarmInfo.ElementGereeName;
                        m_lstViewEnCours.Add(evAlarme.EventAlarmStartStop.AlarmInfo);
                 
                    }
                }
                if (evAlarme.CategorieMessageAlarme == ECategorieMessageAlarme.AlarmMasqueeParUneAutre)
                {
                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvAlarme == evAlarme.EventAlarmRetombee.AlarmStartId)
                        {
                            m_lstViewEnCours.Remove(infoAlarm);
                            //            infoAlarm.DateFin = evAlarme.EventAlarmRetombee.StopAlarmDate;
                            //            m_lstViewRetombe.AddObject(infoAlarm);
                            break;
                        }
                    }
                }
                if (evAlarme.CategorieMessageAlarme == ECategorieMessageAlarme.Mask)
                {

                    if (evAlarme.EventAlarmMask.Severity > 0)
                    {
                        if (evAlarme.EventAlarmMask.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm++;
                        else
                            m_NbMaskBrig++;
                    }
                    else
                    {
                        if (evAlarme.EventAlarmMask.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm--;
                        else
                            m_NbMaskBrig--;
                    }


                    //MAJAdminButtonText();
                //    MAJBrigButtonText();
                }
                if (evAlarme.CategorieMessageAlarme == ECategorieMessageAlarme.AlarmAcknowledgement)
                {
                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvAlarme == evAlarme.EventAlarmAcknowledge.AlarmId)
                        {
                            infoAlarm.EstAcquittee = true;
                            break;
                        }
                    }
                }
            }
            m_bSortieAlarme = true;



            Console.WriteLine("Fin de la notification d'alarme");

          
           
        
        }
 * */

        void OnReceiveNotificationAlarmEnCours(IDonneeNotification donnee)
        {

            //Gestionnaire d'�v�nement pour la r�ception d'une alarme en cours

            Console.WriteLine("R�ception d'une notification d'alarme");
            CDonneeNotificationAlarmes donneeAlarme = donnee as CDonneeNotificationAlarmes;
            if (donneeAlarme == null)
            {
                m_bSortieAlarme = true;
                return;
            }
            m_bSortieAlarme = true;
            CEvenementAlarm[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarm evAlarme in lstAlarmes)
            {
                if (evAlarme is CEvenementAlarmStartStop)
                {
                    CEvenementAlarmStartStop evenementStartStop = (CEvenementAlarmStartStop) evAlarme;
                    if (IsFrequentAlarm(evenementStartStop))
                    {
                        //  MAJFrequentButtonText();
                        continue;
                    }

                    if (evenementStartStop.Gravite == EGraviteAlarmeAvecMasquage.EndAlarm &&
                        evenementStartStop.IdAlarmeDebut > 0)
                    {
                        for (int i = 0; i < m_lstViewEnCours.Count; i++)
                        {
                            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                            if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme ==
                                evenementStartStop.IdAlarmeDebut)
                            {
                                m_lstViewEnCours.Remove(infoAlarm);
                                infoAlarm.DateFin = evenementStartStop.DateEvenementAlarme;
                                //  m_lstViewRetombe.AddObject(infoAlarm);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(evenementStartStop.InfoAdditionnelle);
                        Console.WriteLine(evenementStartStop.Commentaire);
                        Console.WriteLine(evenementStartStop.DateEvenementAlarme);
                        Console.WriteLine(evenementStartStop.NomObjet);
                        m_commentAlrmeLue = evenementStartStop.Commentaire;
                        m_DateAlarmeLue = evenementStartStop.DateEvenementAlarme.ToString();
                        m_TypealarmeLue = evenementStartStop.NomTypeObjet;
                        m_nomAlarmeLue = evenementStartStop.NomObjet;

                        //m_lstViewEnCours.Add(evAlarme.EventAlarmStartStop.AlarmInfo);
                        m_lstViewEnCours.Add(new CInfoAlarmeAffichee(evenementStartStop));
                    }
                }
                else if (evAlarme is CEvenementAlarmMasqueeParUneAutre)
                {
                    CEvenementAlarmMasqueeParUneAutre evenementAlarmMasqueeParUneAutre =
                        (CEvenementAlarmMasqueeParUneAutre)evAlarme;

                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == evenementAlarmMasqueeParUneAutre.AlarmStartId)
                        {
                            m_lstViewEnCours.Remove(infoAlarm);
                            //            infoAlarm.DateFin = evAlarme.EventAlarmRetombee.StopAlarmDate;
                            //            m_lstViewRetombe.AddObject(infoAlarm);
                            break;
                        }
                    }
                }
                else if (evAlarme is CEvenementAlarmMask)
                {
                    CEvenementAlarmMask evAlarmMask = (CEvenementAlarmMask) evAlarme;

                    if (evAlarmMask.NiveauMasquage != EMasquage.NonMasque)
                    {
                        if (evAlarmMask.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm++;
                        else
                            m_NbMaskBrig++;
                    }
                    else
                    {
                        if (evAlarmMask.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm--;
                        else
                            m_NbMaskBrig--;
                    }


                    //MAJAdminButtonText();
                    //    MAJBrigButtonText();
                }
                else if (evAlarme is CEvenementAlarmAcknowledge)
                {
                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == 
                            ((CEvenementAlarmAcknowledge)evAlarme).IdListeAlarmeAcquittee)
                        {
                            infoAlarm.EstAcquittee = true;
                            break;
                        }
                    }
                }
            }
            m_bSortieAlarme = true;



            Console.WriteLine("Fin de la notification d'alarme");

        }


        bool IsFrequentAlarm(CEvenementAlarmStartStop evAlarm)
        {
            if (evAlarm.NatureAlarme == EAlarmNature.Frequente)
            {
                m_NbAlFreq++;
                return true;
            }
            else
                return false;
        }
    }
}
