using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using sc2i.data;
using timos.data;
using timos.client;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.multitiers.client;

using timos.acteurs;
using spv.data;
using spv.data.ConsultationAlarmes;


namespace spv.test
{
    [TestFixture]
    public class CSpvTestLiaison
    {
        private CContexteDonnee m_contexteDonnees = null;

        private int m_NbMaskAdm = 0;
        private int m_NbMaskBrig = 0;
        private int m_NbAlFreq = 0;

        private CRecepteurNotification m_recepteurNotifications = null;
        private bool m_bSortieAlarme = false;
        
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

        


            

        }

        [Test]
        public void AssureAlarmeLiaison()
        {

            //Teste la cr�ation d'une alarme sur un site appartenant � une liaison supervis�e 
            //(mais qui n'appartieent pas � un service) 
            //Cr�e une liaison entre 2 sites, un acc�s alamre sur la liaison et un c�blage d'alamre sur l'acc�s.
            //D�clenche l'alarme sur l'acc�s liaison 

            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur une liaison");
            Console.WriteLine("");
         
            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();

            string strnomSortie = "TEST_TL34_SORTIE_LIAISON";
            string strnomEntree = "34";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL34_TYPSITE");

            int nIdFamille = CreerFamille("TEST_TL34_Famille");



            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL34_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL34_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL34_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL34_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille,"TEST_TL34_TYPEQ1");
                       
            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL34_TYPLIAI");
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);

            //int nIdTypeAccesE = CreerTypeAccesAlarme(nIdTypeqEntree, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);
             
            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL34_EQUIP1", nIdSite,"172.16.54.59");

            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL34_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);
            int nIdTypeAccesLiaison = CreerAccesAlarmeLiaison(nIdLien, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesLiaison, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined);
           

            int nIdAlarmeSortie = RecupererAccesAlarmLien(strnomSortie, nIdLien);
            //int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);


            int nIdCablageAlarme = CablerAccesAlarmeLiaison(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdLien, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Undetermined);


            

            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL34_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {

              
                VerifierLiaiRep(nIdLien, 2);
               



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL34_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {

               
                VerifierLiaiRep(nIdLien, 0);
               
              

                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");
 

           
            
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Test termin�");



            Console.WriteLine("suppression des objets");

            SupprimerCablageAlarme(nIdCablageAlarme);
            SupprimerLiaison(nIdLien);
            SupprimerEquipement(nIdEquipE);
            SupprimerExtremiteSite(nIdExt);
            SupprimerExtremiteSite(nIdExt2);
            SupprimerSite(nIdSite);
            SupprimerSite(nIdSite2);
            SupprimerTypeliaison(nIdTypLien);
            SupprimerTypeSite(nIdTypeSite);
            SupprimerTypeEquipement(nIdTypeqEntree);
            SupprimerFamille(nIdFamille);

            



        }





        [Test]
        public void AssureAlarmeServiceLiaison()
        {

            //Teste la cr�ation d'une alarme sur une liaison appartenant � un service 
            // cr�e deux sites, une liaison entre 2 sites, un acc�s alarme sur la liaison,
            //un �quipement de collecte, ins�re les 2 sites et la liaison dans un service,
            //Cr�e une alarme sur la liaison et v�rifie que le service et la liaison passent en alarme


            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur une liaison appartenant � un service");
            Console.WriteLine("");

            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();



            string strnomSortie = "TEST_TL75_SORTIE_LIAISON";
            string strnomEntree = "75";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL75_TYPSITE");

            int nIdTypeService = CreerTypeService("TEST_TL75_TYPSERVICE");

            int nIdclient = CreerClient("TEST_Client", "TEST_service");

            int nIdSpvClient = LireIdSpvClient("TEST_Client", "TEST_service"); 
          int nIdFamille = CreerFamille("TEST_TL75_Famille");


            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL75_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL75_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL75_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL75_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille, "TEST_TL75_TYPEQ1");

            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL75_TYPLIAI");
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);

            //int nIdTypeAccesE = CreerTypeAccesAlarme(nIdTypeqEntree, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);
           
            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL75_EQUIP1", nIdSite, "172.16.54.59");


            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL75_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);


            int nIdTypeAccesLiaison = CreerAccesAlarmeLiaison(nIdLien, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesLiaison, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical);


            
            int nIdService= CreerService(nIdTypeService,"TEST_TL75_SERVICE",nIdSpvClient);

            int nSite1S = InsererSiteDansSchema(nIdSite,nIdService);
            int nSite2S = InsererSiteDansSchema(nIdSite2,nIdService);

           int nLien1S = InsererLienDansSchema(nIdService,nIdLien);

            int nIdAlarmeSortie = RecupererAccesAlarmLien(strnomSortie, nIdLien);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);


            int nIdCablageAlarme = CablerAccesAlarmeLiaison(nIdTypeAccesLiaison, nIdAlarmeEntree, nIdAlarmeGeree, nIdLien, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Critical);
            
            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL75_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 3);
               VerifierServiceRep(nIdService, 3);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL75_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 0);

              VerifierServiceRep(nIdService, 0);


                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


         

            System.Threading.Thread.Sleep(20000);
            Console.WriteLine("Test termin�");


            SupprimerLienSchema(nLien1S);


            int nIdAlarme2 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL75_ALARME3", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 3);
                

                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme4 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL75_ALARME4", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 0);

         
                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");




            System.Threading.Thread.Sleep(20000);
            Console.WriteLine("Test termin�");

            SupprimerCablageAlarme(nIdCablageAlarme);
            SupprimerLiaison(nIdLien);
         
            SupprimerService(nIdService);
            SupprimerEquipement(nIdEquipE);
            SupprimerExtremiteSite(nIdExt);
            SupprimerExtremiteSite(nIdExt2);
            SupprimerTypeEquipement(nIdTypeqEntree);
            SupprimerSite(nIdSite);
            SupprimerSite(nIdSite2);
            SupprimerTypeSchema(nIdTypeService, true);
            SupprimerTypeliaison(nIdTypLien);
            SupprimerTypeSite(nIdTypeSite);
           


            
            
        }






         [Test]
        public void AssureAlarmeServiceSite()
        {

            //Teste la cr�ation d'une alarme sur un site appartenant � un service 
            // cr�e deux sites, une liaison entre 2 sites, un acc�s alarme sur le site,
            //un �quipement de collecte, ins�re les 2 sites et la liaison dans un service,
            //Cr�e une alarme sur le site et v�rifie que le service et la liaison passent en alarme

            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur un site appartenant � un service");
            Console.WriteLine("");

            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();



            string strnomSortie = "TEST_TL87_SORTIE_LIAISON";
            string strnomEntree = "86";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL87_TYPSITE");

            int nIdTypeService = CreerTypeService("TEST_TL87_TYPSERVICE");

            int nIdclient = CreerClient("TEST_Client", "TEST_service");

            int nIdSpvClient = LireIdSpvClient("TEST_Client", "TEST_service"); 

            
            int nIdFamille = CreerFamille("TEST_TL87_Famille");


            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL87_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL87_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL87_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL87_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille, "TEST_TL87_TYPEQ1");

            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL87_TYPLIAI");
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);

           
            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL87_EQUIP1", nIdSite, "172.16.54.59");


            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL87_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);


            int nIdTypeAccesSite = CreerTypeAccesAlarmeSite(strnomSortie,nIdSite, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesSite, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical);

            
            int nIdService= CreerService(nIdTypeService,"TEST_TL87_SERVICE",nIdSpvClient);

            int nSite1S = InsererSiteDansSchema(nIdSite,nIdService);
            int nSite2S = InsererSiteDansSchema(nIdSite2,nIdService);

            int nLien1S = InsererLienDansSchema(nIdService,nIdLien);

            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);


            int nIdCablageAlarme =CablerAccesAlarmeSite(nIdTypeAccesSite, nIdAlarmeEntree, nIdAlarmeGeree, nIdSite, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Critical);




            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL87_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alarme");
                Console.WriteLine("");
             
                VerifierSiteRep(nIdSite, 3);
                VerifierServiceRep(nIdService, 3);
                


                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL87_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierSiteRep(nIdSite, 0);
                VerifierServiceRep(nIdService, 0);
                
                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


         

            System.Threading.Thread.Sleep(20000);
            Console.WriteLine("Test termin�");




            SupprimerCablageAlarme(nIdCablageAlarme);
            SupprimerLiaison(nIdLien);

            SupprimerService(nIdService);
            SupprimerEquipement(nIdEquipE);
            SupprimerExtremiteSite(nIdExt);
            SupprimerExtremiteSite(nIdExt2);
            SupprimerTypeEquipement(nIdTypeqEntree);
            SupprimerSite(nIdSite);
            SupprimerSite(nIdSite2);
            SupprimerTypeSchema(nIdTypeService, true);
            SupprimerTypeliaison(nIdTypLien);
            SupprimerTypeSite(nIdTypeSite);
             

          
            
        }

        




        [Test]
        public void AssureAlarmeServiceEquip()
        {

            //Teste la cr�ation d'une alarme sur un site appartenant � un service 
            // cr�e deux sites, une liaison entre 2 sites ,un �quipement alarme boucle er
            //un �quipement de collecte sur un des sites du lien, ins�re les 2 sites, les �quipements
            //et la liaison dans un service,
            //Cr�e une alarme sur le site et v�rifie que le service et la liaison passent en alarme
            //On effectue le test avec diff�rentes valeurs de la gravit� de l'alarme
            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur un �quipement appartenant � un service");
            Console.WriteLine("");

            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();



            string strnomSortie = "TEST_TL80_SORTIE_LIAISON";
            string strnomEntree = "80";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL80_TYPSITE");

            int nIdTypeService = CreerTypeService("TEST_TL80_TYPSERVICE");

            int nIdclient = CreerClient("TEST_Client", "TEST_service");

            int nIdSpvClient = LireIdSpvClient("TEST_Client", "TEST_service");
         
            int nIdFamille = CreerFamille("TEST_TL80_Famille");

            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL80_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL80_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL80_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL80_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille, "TEST_TL80_TYPEQ1");
            int nIdTypeqSortie = CreerTypeEquipement(nIdFamille, "TEST_TL80_TYPEQ2");
            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL80_TYPLIAI");
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);
            int nIdTypeAccesS = CreerTypeAccesAlarmeTypeq(nIdTypeqSortie, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesS, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Warning);

            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL80_EQUIP1", nIdSite, "172.16.54.59");
            int nIdEquipS = CreerEquipement(nIdTypeqSortie, "TEST_TL80_EQUIP2", nIdSite, "172.16.54.59");
            
            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL80_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);
             
            int nIdService = CreerService(nIdTypeService, "TEST_TL80_SERVICE", nIdSpvClient);

            int nSite1S = InsererSiteDansSchema(nIdSite, nIdService);
            int nSite2S = InsererSiteDansSchema(nIdSite2, nIdService);

            int nLien1S = InsererLienDansSchema(nIdService, nIdLien);
            int nEquipSch = InsererEquipementDansSchema(nIdEquipS, nIdService);
            int nEquip2Sch = InsererEquipementDansSchema(nIdEquipE, nIdService);

            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);
            int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);


            int nIdCablageAlarme = CablerAccesAlarmeEquip(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdEquipS, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Warning);



            Console.WriteLine("Warning");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Warning);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Warning);


            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Warning, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");
                
               
                VerifierEquipRep(nIdEquipS, 2);
                VerifierServiceRep(nIdService, 2);
             


                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme1 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");

            

            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Test termin�");

            Console.WriteLine("Undetermined");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Undetermined);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Undetermined);



            int nIdAlarme2 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 2);
                VerifierServiceRep(nIdService, 2);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME3", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");

            




             Console.WriteLine("Minor");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Minor);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Minor);



            int nIdAlarme4 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME4", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Minor, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 2);
                VerifierServiceRep(nIdService, 2);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme5 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME5", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");



         Console.WriteLine("Major");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Major);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Major);



            int nIdAlarme6 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME6", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Major, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 3);
                VerifierServiceRep(nIdService, 3);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme7 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME7", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");




             Console.WriteLine("Critical");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Critical);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Critical);



            int nIdAlarme8 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME8", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Critical, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 3);
                VerifierServiceRep(nIdService, 3);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme9 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME9", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");




            SupprimerCablageAlarme(nIdCablageAlarme);
            SupprimerLiaison(nIdLien);

            SupprimerService(nIdService);
            SupprimerEquipement(nIdEquipE);
            SupprimerExtremiteSite(nIdExt);
            SupprimerExtremiteSite(nIdExt2);
            SupprimerTypeEquipement(nIdTypeqEntree);
            SupprimerSite(nIdSite);
            SupprimerSite(nIdSite2);
            SupprimerTypeSchema(nIdTypeService, true);
            SupprimerTypeliaison(nIdTypLien);
            SupprimerTypeSite(nIdTypeSite);
             


        }




        [Test]
        public void AssureAlarmeEquipLiaison()
        {

            //Teste la cr�ation d'une alarme sur un equipement inclus dans un sch�ma de liaiosn
            // cr�e deux sites, une liaison entre 2 sites ,un �quipement alarme boucle er
            //un �quipement de collecte sur un des sites du lien
            //cr�e un sch�ma associ� au lien et ins�re l'�quipement sortie alarme dans le sch�ma du lien
            //Ins�re les 2 sites et la liaison dans un service
            //Cr�e une alarme sur le site et v�rifie que le service et la liaison passent en alarme
            //On effectue le test avec diff�rentes valeurs de la gravit� de l'alarme
            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur un �quipement appartenant � un sch�ma de lien");
            Console.WriteLine("");

            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();



            string strnomSortie = "TEST_TL80_SORTIE_LIAISON";
            string strnomEntree = "80";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL80_TYPSITE");

            int nIdTypeService = CreerTypeService("TEST_TL80_TYPSERVICE");

            int nIdclient = CreerClient("TEST_Client", "TEST_service");

            int nIdSpvClient = LireIdSpvClient("TEST_Client", "TEST_service");
            

            int nIdFamille = CreerFamille("TEST_TL80_Famille");

            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL80_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL80_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL80_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL80_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille, "TEST_TL80_TYPEQ1");
            int nIdTypeqSortie = CreerTypeEquipement(nIdFamille, "TEST_TL80_TYPEQ2");
            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL80_TYPLIAI");
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);
            int nIdTypeAccesS = CreerTypeAccesAlarmeTypeq(nIdTypeqSortie, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesS, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Warning);

            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL80_EQUIP1", nIdSite, "172.16.54.59");
            int nIdEquipS = CreerEquipement(nIdTypeqSortie, "TEST_TL80_EQUIP2", nIdSite, "172.16.54.59");

            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL80_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);

            int nIdSchemaAssocie = CreerSchemaAssocieAUnLien(nIdLien);

            int nIdEquipLien = InsererEquipementDansSchema(nIdEquipS, nIdSchemaAssocie);

            int nIdService = CreerService(nIdTypeService, "TEST_TL80_SERVICE", nIdSpvClient);

            int nSite1S = InsererSiteDansSchema(nIdSite, nIdService);
            int nSite2S = InsererSiteDansSchema(nIdSite2, nIdService);

            int nLien1S = InsererLienDansSchema(nIdService, nIdLien);
          
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);
            int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);
            
            int nIdCablageAlarme = CablerAccesAlarmeEquip(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdEquipS, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Warning);
            

            Console.WriteLine("Warning");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Warning);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Warning);


            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Warning, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 2);
                VerifierServiceRep(nIdService, 2);
                VerifierLiaiRep(nIdLien, 2);


                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme1 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);
                VerifierLiaiRep(nIdLien, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");



            System.Threading.Thread.Sleep(10000);
            Console.WriteLine("Test termin�");

            Console.WriteLine("Undetermined");
            ModifierGraviteAlarmeGeree(nIdAlarmeGeree, EGraviteAlarmeAvecMasquage.Undetermined);
            ModifierGraviteCablageAlarme(nIdCablageAlarme, EGraviteAlarmeAvecMasquage.Undetermined);



            int nIdAlarme2 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {
                Console.WriteLine("");
                Console.WriteLine("R�ception d'une alamre");
                Console.WriteLine("");


                VerifierEquipRep(nIdEquipS, 2);
                VerifierServiceRep(nIdService, 2);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL80_ALARME3", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierEquipRep(nIdEquipS, 0);
                VerifierServiceRep(nIdService, 0);




                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");




            Console.WriteLine("Test termin�");


            SupprimerCablageAlarme(nIdCablageAlarme);
            SupprimerEquipementSchema(nIdEquipLien);
            SupprimerLiaison(nIdLien);
            SupprimerTypeliaison(nIdTypLien);
            SupprimerService(nIdService);
            SupprimerEquipement(nIdEquipE);
            SupprimerEquipement(nIdEquipS);
            SupprimerSite(nIdSite);
            SupprimerSite(nIdSite2);
           
            SupprimerTypeEquipement(nIdTypeqEntree);
            SupprimerTypeEquipement(nIdTypeqSortie);
            SupprimerTypeSite(nIdTypeSite);
            SupprimerTypeSchema(nIdTypeService, true);
            SupprimerFamille(nIdFamille);


        }            



        









        [Test]
        public void AssureTestHierarchie()
        {



            //Teste la construction d'une hi�rarchie liaisons supports et support�s
            //Cr�e un type de liaison BQN qui supporte un type BSN qui supporte un type BSN qui supporte
            //un type BPN
            //Cr�e une liaison de chacun de cet types ett les fait supp�orter les  par les autres


            Console.WriteLine("");
            Console.WriteLine("Test de la hi�rarchie de types support�s - supportants");
            

           
          

            int nIdTypeLienBQN = CreerTypeLiaisonSites("TEST_TL4_BQN");


            int nIdTypeLienBTN = CreerTypeLiaisonSites("TEST_TL4_BTN");


            int nIdTypeLienBSN = CreerTypeLiaisonSites("TEST_TL4_BSN");


            int nIdTypeLienBPN = CreerTypeLiaisonSites("TEST_TL4_BPN");


            int nIdSupport1 = CreerTypeSupport(nIdTypeLienBQN, nIdTypeLienBTN);

            int nIdSupport2 = CreerTypeSupport(nIdTypeLienBTN, nIdTypeLienBSN);

            int nIdSupport3 = CreerTypeSupport(nIdTypeLienBSN, nIdTypeLienBPN);


            int nIdTypsite = CreerTypeSite("TEST_TL4_TYPSITE");
            int  nIdSite1 = CreerSite(nIdTypsite,"TEST_TL4_SITE1");
            int nIdSite2 = CreerSite(nIdTypsite, "TEST_TL4_SITE2");
                   

            int nIdExt1= CreerExtremite(nIdSite1,"TEST_TL4_EXT1");
            int nIdExt2= CreerExtremite(nIdSite1,"TEST_TL4_EXT2");

            int nIdLienBQN = CreerLiaison(nIdTypeLienBQN, "TEST_TL4_BQN", nIdSite1, nIdSite2, "TEST_TL4_EXT1", "TEST_TL4_EXT2", EDirectionLienReseau.UnVersDeux, true);
            int nIdSchemaBQN = CreerSchemaAssocieAUnLien(nIdLienBQN);
            int nIdLienBTN = CreerLiaison(nIdTypeLienBTN, "TEST_TL4_BTN", nIdSite1, nIdSite2, "TEST_TL4_EXT1", "TEST_TL4_EXT2", EDirectionLienReseau.UnVersDeux, true);
            int nIdBQN_BTN = InsererLienDansSchema(nIdSchemaBQN, nIdLienBTN);
            int nIdSchemaBTN = CreerSchemaAssocieAUnLien(nIdLienBTN);
            int nIdLienBSN = CreerLiaison(nIdTypeLienBSN, "TEST_TL4_BQN", nIdSite1, nIdSite2, "TEST_TL4_EXT1", "TEST_TL4_EXT2", EDirectionLienReseau.UnVersDeux, true);
            int nIdBTN_BSN = InsererLienDansSchema(nIdSchemaBTN, nIdLienBSN);
            int nIdSchemaBSN = CreerSchemaAssocieAUnLien(nIdLienBSN);
            int nIdLienBPN = CreerLiaison(nIdTypeLienBSN, "TEST_TL4_BPN", nIdSite1, nIdSite2, "TEST_TL4_EXT1", "TEST_TL4_EXT2", EDirectionLienReseau.UnVersDeux, true);
            int nIdBSN_BPN = InsererLienDansSchema(nIdSchemaBSN, nIdLienBPN);

            Console.WriteLine("insertion des objets termin�e");



            VerifierLienSupportSupporte(nIdLienBQN, nIdLienBTN);
            VerifierLienSupportSupporte(nIdLienBTN, nIdLienBSN);
            VerifierLienSupportSupporte(nIdLienBSN, nIdLienBPN);



            Console.WriteLine("suppression des objets");


            SupprimerLienSchema(nIdBSN_BPN);
            SupprimerLiaison(nIdLienBPN);
            SupprimerLienSchema(nIdBTN_BSN);
            SupprimerLiaison(nIdLienBSN);
            SupprimerLienSchema(nIdBQN_BTN);
            SupprimerLiaison(nIdLienBTN);
            SupprimerLiaison(nIdLienBQN);



            SupprimerSite(nIdSite2);
            SupprimerSite(nIdSite1);
            SupprimerTypeSite(nIdTypsite);

            SupprimerTypeliaison(nIdTypeLienBQN);
            SupprimerTypeliaison(nIdTypeLienBTN);
            SupprimerTypeliaison(nIdTypeLienBSN);
            SupprimerTypeliaison(nIdTypeLienBPN);

           


            Console.WriteLine("test termin�");


           


        }



        [Test]
        public void AssureTestTypeLiaison()
        {

            //teste la cr�ationn, la modification et la suppression des types de liaison

            //Cr�e un type de liaison, modifie son libell� puis le supprime

            Console.WriteLine("teste la cr�ation, la modification et la suppression des types de liaison");

            int nIdTypeLien1 = CreerTypeLiaisonSites("TEST_TL100_typ0");
                                      

            ModifierTypeLiaison(nIdTypeLien1, "TESTt_TL100_typlien0m");
            
            
            int nIdTypLien3 = CreerTypeLiaisonSites("TEST_TL100_typ01");
            


            SupprimerTypeliaison(nIdTypLien3);

            SupprimerTypeliaison(nIdTypeLien1);


            Console.WriteLine("test termin�");

        }


         [Test]
        public void AssureCreerModifierService()
        {

             // Cr�e un type de service, un service de ce type, modifie son libell� puis supprime les �l�ments


            int nIdTypServ = CreerTypeService("TEST_TL2_typserv");

             
            int nIdclient = CreerClient("TEST_Client", "TEST_service");

            int nIdSpvClient = LireIdSpvClient("TEST_Client", "TEST_service");

            int nIdServ = CreerService(nIdTypServ, "TEST_TL2_serv", nIdSpvClient);

            ModifierLibelleService(nIdServ, "Test_TL2_mod");

            SupprimerService(nIdServ);

            SupprimerTypeSchema(nIdTypServ, true);



        }


       
        


       


        [Test]
        public void AssureTestLiaison()
        {



            //teste la cr�ation, la modification et le suppression d'une liaison entre deux sites
            //cr�e deux sites, deux extr�mit�s sur les sites, un liaison entre les deux extr�mit�s, modifie le libell� de ces liaisons puis les supprime.


            Console.WriteLine("test de la cr�ation, la modification et le suppression d'une liaison entre dux sites");


            int nTypsiteId = CreerTypeSite("TEST_TL44_TYPSITE");

            int nSiteId1 = CreerSite(nTypsiteId,"TEST_TL44_SITE1");
            int nSiteId2 = CreerSite(nTypsiteId,"TEST_TL44_SITE2");

           

           
            int nExtId1 = CreerExtremite(nSiteId1, "TEST_TL44_EXT1");
            int nExtId2 = CreerExtremite(nSiteId2, "TEST_TL44_EXT2");
            int nIdTypeLien = CreerTypeLiaisonSites("TEST_TL44_TYPLIEN");

            int nIdLien = CreerLiaison(nIdTypeLien, "TEST_TL44_LIEN1", nSiteId1, nSiteId2, "TEST_TL44_EXT1", "TEST_TL44_EXT2", EDirectionLienReseau.UnVersDeux, true);


            ModifierLibelleLiaison(nIdLien, "TEST_TL44_LIEN01");

            int nIdLien2 = CreerLiaison(nIdTypeLien, "TEST_TL44_LIEN2", nSiteId2, nSiteId1, nExtId2, nExtId1, EDirectionLienReseau.DeuxVersUn);

            ModifierLibelleLiaison(nIdLien, "TEST_TL44_LIEN0121112333445531");
           


            SupprimerLiaison(nIdLien);

            SupprimerLiaison(nIdLien2);

            SupprimerTypeliaison(nIdTypeLien);

           

            SupprimerExtremiteSite(nExtId1);
            SupprimerExtremiteSite(nExtId2);

            SupprimerSite(nSiteId1);
            SupprimerSite(nSiteId2);

           
            

            Console.Write("test termin�");


        }






        [Test]
        public void AssureTestAlarmeLiaisonSupport()
        {

            //teste une alarme sur un lien supportant un autre lien. 
            // Cr�e un lien entre deux sites qui est support� par un autre lien entre
            // les deux m�mes sites. Cr�e un acc�s alarme sur le lien supportant et 
            //d�clenche une alarme sur ct acc�s. V�rifie que les deux liens (supportant et support�s) passent tous deux en alarme

            

            

            Console.WriteLine("");
            Console.WriteLine("Test d'une alarme sur une liaison");
            Console.WriteLine("");

            m_lstViewEnCours = new List<CInfoAlarmeAffichee>();

            string strnomSortie = "TEST_TL34_SORTIE_LIAISON";
            string strnomEntree = "34";
            Console.WriteLine("cr�ation du type de site");
            int nIdTypeSite = CreerTypeSite("TEST_TL34_TYPSITE");

            int nIdFamille = CreerFamille("TEST_TL34_Famille");



            int nIdSite = CreerSite(nIdTypeSite, "TEST_TL34_SITE1");

            int nIdSite2 = CreerSite(nIdTypeSite, "TEST_TL34_SITE2");

            int nIdExt = CreerExtremite(nIdSite, "TEST_TL34_EXT1");

            int nIdExt2 = CreerExtremite(nIdSite2, "TEST_TL34_EXT2");

            int nIdTypeqEntree = CreerTypeEquipement(nIdFamille, "TEST_TL34_TYPEQ1");

            int nIdTypLien = CreerTypeLiaisonSites("TEST_TL34_TYPLIAI");
            int nIdTypLienSupporte = CreerTypeLiaisonSites("TEST_TL34_TYPLIAI2");

            int nIdTypeSupport = CreerTypeSupport(nIdTypLien, nIdTypLienSupporte);
            int nIdTypeAccesE = CreerTypeAccesEntreeEquipement(nIdTypeqEntree, strnomEntree);
            
            //int nIdTypeAccesE = CreerTypeAccesAlarme(nIdTypeqEntree, strnomEntree, ECategorieAccesAlarme.EntreeBoucle);

            int nIdEquipE = CreerEquipement(nIdTypeqEntree, "TEST_TL34_EQUIP1", nIdSite, "172.16.54.59");

            int nIdLien = CreerLiaison(nIdTypLien, "TEST_TL34_LIAI1", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);
         
            int nIdLienSupporte = CreerLiaison(nIdTypLienSupporte, "TEST_TL34_LIAI2", nIdSite, nIdSite2, nIdExt, nIdExt2, EDirectionLienReseau.UnVersDeux);
            int nIdSchema = CreerSchemaAssocieAUnLien(nIdLienSupporte);
            int nIdSupportant = InsererLienDansSchema(nIdSchema, nIdLien);
            int nIdTypeAccesLiaison = CreerAccesAlarmeLiaison(nIdLien, strnomSortie, ECategorieAccesAlarme.SortieBoucle);
            int nIdAlarmeGeree = CreerAlarmeGeree(nIdTypeAccesLiaison, EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined);

           

            int nIdAlarmeSortie = RecupererAccesAlarmLien(strnomSortie, nIdLien);
            //int nIdAlarmeSortie = RecupererAccesAlarmEquip(strnomSortie, nIdEquipS);
            int nIdAlarmeEntree = RecupererAccesAlarmEquip(strnomEntree, nIdEquipE);


            int nIdCablageAlarme = CablerAccesAlarmeLiaison(nIdAlarmeSortie, nIdAlarmeEntree, nIdAlarmeGeree, nIdLien, nIdEquipE, "172.16.54.59", EGraviteAlarmeAvecMasquage.Undetermined);




            int nIdAlarme = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL34_ALARME1", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.Undetermined, strnomEntree, nIdCablageAlarme);

            Console.WriteLine("Attente de la notification alarme");
            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 2);
                VerifierLiaiRep(nIdLienSupporte, 2);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");


            Console.WriteLine("Retomb�e alarme");


            int nIdAlarme3 = CreerAlarme(nIdEquipE, nIdAlarmeGeree, "TEST_TL34_ALARME2", EAlarmEvent.Communication, EGraviteAlarmeAvecMasquage.EndAlarm, strnomEntree, nIdCablageAlarme);

            System.Threading.Thread.Sleep(10000);

            if (m_bSortieAlarme)
            {


                VerifierLiaiRep(nIdLien, 0);
                VerifierLiaiRep(nIdLienSupporte, 0);



                m_bSortieAlarme = false;
            }
            else
                Console.WriteLine("aucune notification alarme re�ue");




            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Test termin�");


        }


 



        

        [Test]
        public void AssureLiaisonEquip()
        {

            //Teste la cr�ation, la modification et la suppression d'une liaison entre deux �quipements 

           
           

            Console.WriteLine("Test de la cr�ation d'une liaison entre deux �quipements");

            int nIdTypsite = CreerTypeSite("TEST_TL61_TYPSITE");

            int nIdSite = CreerSite(nIdTypsite,"TEST_TL61_SITE");

            int NidFamille = CreerFamille("TEST_TL61_FAMILLE");

            int NIdTypeq = CreerTypeEquipement(NidFamille,"TEST_TL61_TYPEQ");

            int nIdEquip1 = CreerEquipement(NIdTypeq, "TEST_TL61_EQUIP1", nIdSite);

            int nIdEquip2 = CreerEquipement(NIdTypeq, "TEST_TL61_EQUIP2", nIdSite);

            int nIdtypeLien = CreerTypeLiaisonEquip("TEST_TL61_TYPLIAI", true);

            int nIdLien = CreerLiaisonEquip(nIdtypeLien, "TEST_TL61_LIAI", nIdEquip1, nIdEquip2, EDirectionLienReseau.UnVersDeux);


            ModifierLibelleLiaison(nIdLien, "TEST_TL61_LIAI01211433554134456631");

            ModifierSensLiaison(nIdLien, EDirectionLienReseau.DeuxVersUn);


            SupprimerLiaison(nIdLien);

            SupprimerEquipement(nIdEquip1);
            SupprimerEquipement(nIdEquip2);

            SupprimerSite(nIdSite);
            SupprimerTypeEquipement(NIdTypeq);
            SupprimerTypeSite(nIdTypsite);
            SupprimerFamille(NidFamille);
            
            Console.WriteLine("Fin du test");


        }


       

        private int LireIdSpvClient(string nom, string prenom)
        {

            Console.WriteLine("Lecture de l'ID du client SPV ");
            string nomCompletActeur = prenom + " " + nom;

            CSpvClient client = new CSpvClient(m_contexteDonnees);

             Console.WriteLine("Lecture du client SPV");
            Assert.IsTrue(client.ReadIfExists(new CFiltreData(CSpvClient.c_champCLIENT_NOM + "=@1", nomCompletActeur)));

            return client.Id;


        }


        public void SupprimerService(int nId)
        {
            Console.WriteLine("Suppression d'un service");
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);
             Console.WriteLine("Lecture du sch�ma r�seau");
            Assert.IsTrue(schema.ReadIfExists(nId));
             Console.WriteLine("Lecture du service");
             CSpvSchemaReseau service = new CSpvSchemaReseau(m_contexteDonnees);
             service.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champIdTimos + "=@1", nId));
            CResultAErreur result;
            result = service.Delete();
            Console.WriteLine("Supression du sh�ma");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            
            Assert.IsTrue(result.Result);

            result = schema.Delete();
            Console.WriteLine("Supression du sh�ma");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

          

        /*    result = m_contexteDonnees.SaveAll(true);
           
            Console.WriteLine("enregistrement de la suppression");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            
            Assert.IsTrue(result.Result);         */   
 
            

            CSchemaReseau schemaTest = new CSchemaReseau(m_contexteDonnees);
             Console.WriteLine("v�rification de la suppression du service");
             Assert.IsFalse(schemaTest.ReadIfExists(nId));
             CSpvSchemaReseau serviceTest = new CSpvSchemaReseau(m_contexteDonnees);
             Assert.IsFalse(serviceTest.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champIdTimos + "=@1", nId)));
                      


        }



        private void SupprimerTypeSchema(int nId, bool bSupervise)
        {
            Console.WriteLine("suppression du type de sch�ma");

            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau(m_contexteDonnees);

            Console.WriteLine("lecture  du type de sch�ma");
            Assert.IsTrue(typeSchema.ReadIfExists(nId));
            CResultAErreur result;
            /*
            if (bSupervise)
            {
                CSpvTypeService serviceSpv = new CSpvTypeService(m_contexteDonnees);


                Assert.IsTrue(serviceSpv.ReadIfExists(new CFiltreData(CSpvTypeService.c_champIdTypeSchemaTimos + "=@1", nId)));



                Console.WriteLine("suppression du type de schema");
                result = serviceSpv.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
            }*/
            result = typeSchema.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
         /*   result = m_contexteDonnees.SaveAll(true);
            Console.WriteLine("enregistrement de la suppression");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);*/


         

            CTypeSchemaReseau typeTest = new CTypeSchemaReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression du type de schema Timos");
            Assert.IsFalse(typeTest.ReadIfExists(nId));

            /*
            if (bSupervise)
            {
                CSpvTypeService typeSpvTest = new CSpvTypeService(m_contexteDonnees);

                Console.WriteLine("v�rification de la suppression du type de service SPV");
                Assert.IsFalse(typeSpvTest.ReadIfExists(new CFiltreData(CSpvTypeService.c_champIdTypeSchemaTimos + "=@1", nId)));


            }*/


        }


        


        public void ModifierEquipAsurveiller(int nId, bool bASurveiller)
        {
            //modification du champ "A surveiller" d'un �qupment

            Console.WriteLine("Chargement de l'�quipement");
            CSpvEquip equipsv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipsv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            equipsv.ASuperviser = bASurveiller;

            CResultAErreur result = CResultAErreur.True;

            result = equipsv.VerifieDonnees(false);
            Console.WriteLine("v�rification des donn�ees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);



            Console.WriteLine("sauvegarde de l'�quipemnt");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            System.Threading.Thread.Sleep(500);
            CSpvEquip equipTest = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�qupement SPV");
            Assert.IsTrue(equipTest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            Console.WriteLine("v�rification du champ A surveiller");
            Assert.IsTrue(equipTest.ASuperviser == bASurveiller);

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
            Console.WriteLine("lecture de l'alarme g�r�e");
            Assert.IsTrue(test.ReadIfExists(nId));
            Console.WriteLine("lecture de la gravit�");
            Assert.IsTrue(test.Gravite.CodeInt == grav.CodeInt);
            Console.WriteLine(test.Gravite.CodeInt);
            


        }

        public int CablerAccesAlarmeLiaison(int nIdAcces1, int nIdAcces2, int nIdAlarmeGeree, int nLiaiId, int nEquipId, string addrIP, EGraviteAlarmeAvecMasquage gravite)
        {

            //Effectue le c�blage d'un acc�s alarme entre un site et un �quipement
            Console.WriteLine("cablage e l'acces alarme");
            int nId = -1;
            Console.WriteLine("chargement de l'�quipement entr�e alarme");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));
            int nEquipSpvId = equipSpv.Id;

            Console.WriteLine("chargement du site");
            CSpvLiai liaiSpv = new CSpvLiai(m_contexteDonnees);
            
            Assert.IsTrue(liaiSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nLiaiId)));


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
            CFiltreData filtre = new CFiltreData(CSpvLienAccesAlarme.c_champACCES1_ID + "=@1", nIdAcces1.ToString());
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champACCES2_ID + "=@1", nIdAcces2));
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree));

            if (!lienAcces.ReadIfExists(filtre))
            {


                lienAcces.CreateNewInCurrentContexte();
                lienAcces.AccesAlarmeOne = acces1;
                lienAcces.AccesAlarmeTwo = acces2;
                //lienAcces.SpvAlarmgeree = alarmeGeree;
                lienAcces.SeuilBas = 0;
                lienAcces.SeuilHaut = 0;
                lienAcces.FreqNb = 0;
                lienAcces.FreqPeriod = 1;
                CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
                lienAcces.Gravite = grav;
                //lienAcces.SpvEquip = equipSpv;
                lienAcces.SpvLiai = liaiSpv;
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
       

            result = lienAcces.VerifieDonnees(false);
            Console.WriteLine("v�rification des donn�ees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

           
            nId = lienAcces.Id;


            Console.WriteLine("Lecture du c�blage d'acc�ss alarme");
            CSpvLienAccesAlarme accesTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(accesTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "=@1", nId)));
            Console.WriteLine("v�rification de l'acc�s sortie");
            Assert.IsTrue(accesTest.AccesAlarmeOne.Id == acces1.Id);
            Console.WriteLine("v�rification de l'aac�s entr�e");
            Assert.IsTrue(accesTest.AccesAlarmeTwo.Id == acces2.Id);




            return nId;

        }



        public int CablerAccesAlarmeSite(int nIdAcces1, int nIdAcces2, int nIdAlarmeGeree, int nSiteId, int nEquipId, string addrIP, EGraviteAlarmeAvecMasquage gravite)
        {

            //Effectue le c�blage d'un acc�s alarme entre un site et un �quipement
            Console.WriteLine("cablage e l'acces alarme");
            int nId = -1;
            Console.WriteLine("chargement de l'�quipement entr�e alarme");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));
            int nEquipSpvId = equipSpv.Id;

            Console.WriteLine("chargement du site");
            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));
        


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
            CFiltreData filtre = new CFiltreData(CSpvLienAccesAlarme.c_champACCES1_ID + "=@1", nIdAcces1.ToString());
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champACCES2_ID + "=@1", nIdAcces2));
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree));

            if (!lienAcces.ReadIfExists(filtre))
            {


                lienAcces.CreateNewInCurrentContexte();
                lienAcces.AccesAlarmeOne = acces1;
                lienAcces.AccesAlarmeTwo = acces2;
                //lienAcces.SpvAlarmgeree = alarmeGeree;
                lienAcces.SeuilBas = 0;
                lienAcces.SeuilHaut = 0;
                lienAcces.FreqNb = 0;
                lienAcces.FreqPeriod = 1;
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

            result = lienAcces.VerifieDonnees(false);
            Console.WriteLine("v�rification des donn�ees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            result = lienAcces.VerifieDonnees(false);
            Console.WriteLine("v�rification des donn�ees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            nId = lienAcces.Id;


            Console.WriteLine("Lecture du c�blage d'acc�ss alarme");
            CSpvLienAccesAlarme accesTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(accesTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "=@1", nId)));
            Console.WriteLine("v�rification de l'acc�s sortie");
            Assert.IsTrue(accesTest.AccesAlarmeOne.Id == acces1.Id);
            Console.WriteLine("v�rification de l'aac�s entr�e");
            Assert.IsTrue(accesTest.AccesAlarmeTwo.Id == acces2.Id);




            return nId;

        }


        public int CablerAccesAlarmeEquip(int nIdAcces1, int nIdAcces2, int nIdAlarmeGeree, int nEquipSId, int nEquipEId, string addrIP, EGraviteAlarmeAvecMasquage gravite)
        {

            //Effectue le c�blage d'un acc�s alarme entre un site et un �quipement
            Console.WriteLine("cablage e l'acces alarme");
            int nId = -1;
            Console.WriteLine("chargement de l'�quipement entr�e alarme");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipEId)));
            int nEquipSpvId = equipSpv.Id;

            Console.WriteLine("chargement du site");
            CSpvEquip equipSSpv = new CSpvEquip(m_contexteDonnees);
            Assert.IsTrue(equipSSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipSId)));
        

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
            CFiltreData filtre = new CFiltreData(CSpvLienAccesAlarme.c_champACCES1_ID + "=@1", nIdAcces1);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champACCES2_ID + "=@1", nIdAcces2));
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvLienAccesAlarme.c_champALARMGEREE_ID + "=@1", nIdAlarmeGeree));

            if (!lienAcces.ReadIfExists(filtre))
            {
                
                lienAcces.CreateNewInCurrentContexte();
                lienAcces.AccesAlarmeOne = acces1;
                lienAcces.AccesAlarmeTwo = acces2;
                //lienAcces.SpvAlarmgeree = alarmeGeree;
                lienAcces.SeuilBas = 0;
                lienAcces.SeuilHaut = 0;
                lienAcces.FreqNb = 0;
                lienAcces.FreqPeriod = 1;
                CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
                lienAcces.Gravite = grav;
                lienAcces.SpvEquip = equipSSpv;
                //lienAcces.SpvLiai = liaiSpv;
                //lienAcces.EquipAddrIP = addrIP;

                //  lienAcces.MaskAdminMax = 0;
                // lienAcces.MaskAdminMin = 0;
                // lienAcces.MaskBriMax = 0;
                // lienAcces.MaskBriMin = 0;
                lienAcces.Surveiller = true;
                lienAcces.Afficher = true;
                lienAcces.Acquitter = true;




          

            //   lienAcces.EquipAddrIP = addrIP;
            Console.WriteLine("sauvegarde du c�blage acc�s alarme");
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


          }
          else
            Console.WriteLine("le lien acc�s alarme existe d�j�");

            nId = lienAcces.Id;


            Console.WriteLine("Lecture du c�blage d'acc�ss alarme");
            CSpvLienAccesAlarme accesTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsTrue(accesTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "=@1", nId)));
            Console.WriteLine("v�rification de l'acc�s sortie");
            Assert.IsTrue(accesTest.AccesAlarmeOne.Id == acces1.Id);
            Console.WriteLine("v�rification de l'aac�s entr�e");
            Assert.IsTrue(accesTest.AccesAlarmeTwo.Id == acces2.Id);




            return nId;

        }



        /*
        public int CreerEquipement(int TypeqId, string libelle, int SiteId, string addrip)
        {
            int nId = -1;

            Console.WriteLine("cr�ation de l'�quipement " + libelle);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);

            CSite site = new CSite(m_contexteDonnees);
            Console.WriteLine("lecture du site");
            Assert.IsTrue(site.ReadIfExists(SiteId));

            CResultAErreur result = CResultAErreur.True;
            if (typeq.ReadIfExists(TypeqId))
            {

                CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
                if (!equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", libelle)))
                {
                    equip.CreateNewInCurrentContexte();
                    equip.Libelle = libelle;
                    equip.TypeEquipement = typeq;

                   
                    equip.Site = site;

                    Console.WriteLine("v�rification des donn�ees");
                    result = equip.VerifieDonnees(false);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);

                    
                    Console.WriteLine("sauvegarde de l'�quipemnt");
                    result = m_contexteDonnees.SaveAll(true);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);

                    System.Threading.Thread.Sleep(500);
                  


                }
                else
                    Console.WriteLine("l'�quipement existe d�j�");

                Console.WriteLine("lecture de l'�quipment SPV");
                CSpvEquip test = new CSpvEquip(m_contexteDonnees);
                Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equip.Id)));
                test.AdresseIP = addrip;


                test.ASuperviser = true;


                Console.WriteLine("v�rification des donn�ees");
                result = test.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("sauvegarde de l'�quipement");
                result = m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                nId = equip.Id;
            }

            return nId;
        }

        */





        public int CreerEquipement(int TypeqId, string libelle, int SiteId)
        {
            //cr�e un �quipement sur un site
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

                   

                    CSpvEquip test = new CSpvEquip(m_contexteDonnees);
                    Console.WriteLine("lecture de l'�quipement SPV");
                    Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equip.Id)));

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


        public int CreerEquipement(int TypeqId, string libelle, int SiteId, string addrip)
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
                    CSpvEquip test = new CSpvEquip(m_contexteDonnees);
                    Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equip.Id)));
                    test.AdresseIP = addrip;

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

                    Console.WriteLine("enregistrement des champs SPV");
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

        public int CreerTypeEquipement(int nIdFamille, string libelle)
        {


            Console.WriteLine("cr�ation du type d'�quipement " + libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Console.WriteLine("lecture de la famille");
            Assert.IsTrue(famille.ReadIfExists(nIdFamille));


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

            Console.WriteLine("v�rification des donn�ees");
            result = typeq.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du type d'�quipement");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);


            return typeq.Id;
        }



        private int CreerClient(string nom, string prenom)
        {
            //cr�e un client pour le service

            Console.WriteLine("Cr�ation du client " + prenom + " " + nom);
            //cr�er un client
            CActeur client = new CActeur(m_contexteDonnees);

            CDonneesActeurClient donneesClient = new CDonneesActeurClient(m_contexteDonnees);



            if (!client.ReadIfExists(new CFiltreData(CActeur.c_champNom + "=@1",
                nom)))
            {
                client.CreateNewInCurrentContexte();
                client.Nom = nom;
                client.Prenom = prenom;
                donneesClient.CreateNewInCurrentContexte();
                donneesClient.Acteur = client;

            }
            else
            {
                Console.WriteLine("le client existe d�j�");

                return client.Id;

            }


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = client.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du client");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);     

            Assert.IsTrue(result.Result);


            int nId = donneesClient.Id;


            CSpvClient spvClient = new CSpvClient(m_contexteDonnees);
            Console.WriteLine("v�rification du client SPV");
            Assert.IsTrue(spvClient.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", donneesClient.Id)));






            return nId;




        }











        private int CreerTypeSite(string libelle)
        {


            //cr�er un type de site
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("cr�ation du type de site " + libelle);
            if (!typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                libelle)))
            {
                typeSite.CreateNewInCurrentContexte();


            }
            typeSite.Libelle = libelle + "e";
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

        public int CreerSite(int nTypeSiteId, string nomSite)
        {
            //Cree un nouveau site

            Console.WriteLine("cr�ation du site "+ nomSite);
            CSite site = new CSite(m_contexteDonnees);
            if (!site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
               nomSite)))
            {

                CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
                site.CreateNewInCurrentContexte();
                typeSite.ReadIfExists(nTypeSiteId);
                site.TypeSite = typeSite;
                site.Libelle = nomSite;

            }
            else
                System.Console.WriteLine("Le site existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = site.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du site");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int nSiteId = site.Id;

            System.Threading.Thread.Sleep(500);
            CSpvSite spvSiteTest = new CSpvSite(m_contexteDonnees);
          
             Console.WriteLine("V�rification du site SPV");
            Assert.IsTrue(spvSiteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                nSiteId)));
            Console.WriteLine("V�rification du libell� du site SPV");
            Assert.AreEqual(site.Libelle, spvSiteTest.SiteNom);
            Console.WriteLine("V�rification du ClassId du site SPV");
            Assert.AreEqual(spvSiteTest.ClassId, 1008);


            return site.Id;


        }



        public int CreerTypeLiaisonSiteEquipement(string libelle)
        {
            Console.WriteLine("cr�e le type de liaison " + " entre 2 sites");
            int nId = -1;
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            if (!typeLien.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle + "=@1", libelle)))
            {
                typeLien.CreateNewInCurrentContexte();
                typeLien.Libelle = libelle;
                typeLien.TypeElement1 = typeof(CSite);
                typeLien.TypeElement2 = typeof(CEquipementLogique);


            }

            else
                Console.WriteLine("le type de lien r�seau existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeLien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du type de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            nId = typeLien.Id;



            System.Threading.Thread.Sleep(500);

/*            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);
            Console.WriteLine("Lecture du lien SPV");
            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(lienspv.Libelle == libelle);*/


            return nId;



        }


        public int CreerSite(int nTypeSiteId, string nomSite,string addrip)
        {
            //Cree un nouveau site

            Console.WriteLine("cr�ation du site " + nomSite);
            CSite site = new CSite(m_contexteDonnees);
            if (!site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
               nomSite)))
            {

                CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
                site.CreateNewInCurrentContexte();
                typeSite.ReadIfExists(nTypeSiteId);
                site.TypeSite = typeSite;
                site.Libelle = nomSite;

            }
            else
                System.Console.WriteLine("Le site existe d�j�");



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = site.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du site");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("Enregistrement du site");
            Assert.IsTrue(result.Result);

            CSpvSite spvSiteTest = new CSpvSite(m_contexteDonnees);

            Console.WriteLine("V�rification du site SPV");
            Assert.IsTrue(spvSiteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                site.Id)));
            Console.WriteLine("V�rification du libell� du site SPV");
            Assert.AreEqual(site.Libelle, spvSiteTest.SiteNom);
            Console.WriteLine("V�rification du ClassId du site SPV");
            Assert.AreEqual(spvSiteTest.ClassId, 1008);



            


            return site.Id;


        }


        

        private int DupliquerTypeLiaison(int nIdType, string libelleDuplique)
        {
     
            Console.WriteLine("Duplication d'un type de liaison"); 
            CResultAErreur result = CResultAErreur.True;


            CTypeLienReseau type = new CTypeLienReseau(m_contexteDonnees);


            CTypeLienReseau typeDuplique = new CTypeLienReseau(m_contexteDonnees);
             Console.WriteLine("Lecture du type original");
            Assert.IsTrue(type.ReadIfExists(nIdType));

            if (!typeDuplique.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle + "=@1", nIdType)))
            {

                typeDuplique.CreateNewInCurrentContexte();
                typeDuplique.Libelle = libelleDuplique;
                typeDuplique.TypeElement1 = type.TypeElement1;
                typeDuplique.TypeElement2 = type.TypeElement2;

            }

            int nId = typeDuplique.Id;

          
            Console.WriteLine("v�rification des donn�ees");
            result = typeDuplique.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du type de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
             
            CSpvTypliai typetest = new CSpvTypliai(m_contexteDonnees);
             Console.WriteLine("Lecture du type dupliqu�");
            Assert.IsTrue(typetest.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1",nId)));
             Console.WriteLine("V�rification du libell�"); 
            Assert.IsTrue(typetest.Libelle == libelleDuplique);



            return nId;

        }

        private int CreerExtremite(int nIdSite, string libelle)
        {
            Console.WriteLine("Cr�ation de l'extr�mit� de site "+libelle);
            CSite site = new CSite(m_contexteDonnees);
             Console.WriteLine("Lecture du site");
            Assert.IsTrue(site.ReadIfExists(nIdSite));

            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(m_contexteDonnees);
            if(!ext.ReadIfExists(new CFiltreData(CExtremiteLienSurSite.c_champLibelle +"=@1", libelle)))
            {
                ext.CreateNewInCurrentContexte();
                ext.Libelle = libelle;
                ext.Site = site;


            }


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = ext.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement de l'extr�mit�");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            
            int nId = ext.Id;

            CExtremiteLienSurSite extText = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("v�rification de la cr�ation de l'extr�mit�");
            Assert.IsTrue(extText.ReadIfExists(nId));
 


            return nId;

         

        }


        private int CreerLiaison(int nIdType, string libelle, int nIdSite1, int nIdSite2, string nomExt1, string nomExt2, EDirectionLienReseau sens, bool bSupervisee)
        {
            int nId = -1;

            Console.WriteLine("cr�ation de la liaison  entre extr�mit�s sites " + libelle);

            Console.WriteLine("lecture du site 1");
            CSite site1 = new CSite(m_contexteDonnees);
            Assert.IsTrue(site1.ReadIfExists(nIdSite1));
            CSite site2 = new CSite(m_contexteDonnees);
            Console.WriteLine("lecture du site 2");
            Assert.IsTrue(site2.ReadIfExists(nIdSite2));


            CExtremiteLienSurSite ext1 = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("lecture de l'extr�mit� 1");
            Assert.IsTrue(ext1.ReadIfExists(new CFiltreData(CExtremiteLienSurSite.c_champLibelle + "=@1" + " and " + CSite.c_champId + "=@2", nomExt1, nIdSite1)));

            CExtremiteLienSurSite ext2 = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("lecture de l'extr�mit� 2");
            Assert.IsTrue(ext2.ReadIfExists(new CFiltreData(CExtremiteLienSurSite.c_champLibelle + "=@1" + " and " + CSite.c_champId + "=@2", nomExt2, nIdSite2)));

            Console.WriteLine("lecture du type de lien r�seau");
            CTypeLienReseau typelien = new CTypeLienReseau(m_contexteDonnees);
            Assert.IsTrue(typelien.ReadIfExists(nIdType));

            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            if (!lien.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", libelle)))
            {
                lien.CreateNewInCurrentContexte();
                lien.Libelle = libelle;
                lien.Site1 = site1;
                lien.Site2 = site2;
                lien.TypeLienReseau = typelien;
                lien.ExtremiteSurSite1 = ext1;
                lien.ExtremiteSurSite2 = ext2;

                CDirectionLienReseau direction = new CDirectionLienReseau(sens);
                lien.Direction = direction;

            }
            else
                Console.WriteLine("le lien r�seau existe d�j�");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du lien r�seau");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            nId = lien.Id;

            System.Threading.Thread.Sleep(500);


            if (bSupervisee)
            {

                CSpvLiai lienSpv = new CSpvLiai(m_contexteDonnees);
                Console.WriteLine("v�rification de l'existence du lien SPV");
                Assert.IsTrue(lienSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId)));
                Console.WriteLine("v�rification du libell� du lien");
                Assert.IsTrue(lienSpv.NomLiaison == lien.Libelle);
                Console.WriteLine("v�rification du type de lien");
                Assert.IsTrue(lienSpv.NomTypeLiaison == lien.TypeLienReseau.Libelle);
                Console.WriteLine("v�rification du classId du lien");
                Assert.IsTrue(lienSpv.ClassId == 1004);

            }

            return nId;


        }





        private int CreerLiaison(int nIdType,string libelle, int nIdSite1, int nIdSite2, int nIdExt1, int nIdExt2, EDirectionLienReseau sens)
        {
            int nId = -1;
             //Cr�ation d'une liaison entre deux extr�mit�s d'un site
            Console.WriteLine("cr�ation du lien " + libelle + " entre deux sites");

            Console.WriteLine("lecture du site 1");
            CSite site1 = new CSite(m_contexteDonnees);
            Assert.IsTrue(site1.ReadIfExists(nIdSite1));
            Console.WriteLine("lecture du site 2");
            CSite site2 = new CSite(m_contexteDonnees);
            Assert.IsTrue(site2.ReadIfExists(nIdSite2));

            Console.WriteLine("lecture de l'extr�mit� 1");
            CExtremiteLienSurSite ext1 = new CExtremiteLienSurSite(m_contexteDonnees);
            Assert.IsTrue(ext1.ReadIfExists(nIdExt1));
            Console.WriteLine("lecture de l'extr�mit� 2");
              CExtremiteLienSurSite ext2 = new CExtremiteLienSurSite(m_contexteDonnees);
            Assert.IsTrue(ext2.ReadIfExists(nIdExt2));

            Console.WriteLine("lecture du type de lien");
            CTypeLienReseau typelien = new CTypeLienReseau(m_contexteDonnees);
            Assert.IsTrue(typelien.ReadIfExists(nIdType));

            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            if (!lien.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", libelle)))
            {
                lien.CreateNewInCurrentContexte();
                lien.Libelle = libelle;
                lien.Site1 = site1;
                lien.Site2 = site2;
                lien.TypeLienReseau = typelien;
                lien.ExtremiteSurSite1 = ext1;
                lien.ExtremiteSurSite2 = ext2;

                CDirectionLienReseau direction = new CDirectionLienReseau(sens);
                lien.Direction = direction;



                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�ees");
                result = lien.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement du lien");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

            }
            else
                Console.WriteLine("le lien r�seau existe d�j�");

            nId = lien.Id;


            Console.WriteLine("lecture du lien SPV");
            CSpvLiai lienSpv = new CSpvLiai(m_contexteDonnees);
            
            Assert.IsTrue(lienSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1",nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(lienSpv.NomLiaison == lien.Libelle);
            Console.WriteLine("v�rification du type");
            Assert.IsTrue(lienSpv.NomTypeLiaison == lien.TypeLienReseau.Libelle);
            Console.WriteLine("v�rification du ClassId");
            Assert.IsTrue(lienSpv.ClassId ==  1004);
           


            return nId;


        }





        private int CreerLiaisonSiteEquipement(int nIdType, string libelle, int nIdSite1, int nIdEquip, int nIdExt1,  EDirectionLienReseau sens)
        {
            int nId = -1;
            //Cr�ation d'une liaison entre deux extr�mit�s d'un site
            Console.WriteLine("cr�ation du lien " + libelle + " entre deux sites");

            Console.WriteLine("lecture du site 1");
            CSite site1 = new CSite(m_contexteDonnees);
            Assert.IsTrue(site1.ReadIfExists(nIdSite1));
            Console.WriteLine("lecture de l'�quipement");
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip.ReadIfExists(nIdEquip));
            Console.WriteLine("lecture de l'extr�mit� 1");
            CExtremiteLienSurSite ext1 = new CExtremiteLienSurSite(m_contexteDonnees);
            Assert.IsTrue(ext1.ReadIfExists(nIdExt1));
         

            Console.WriteLine("lecture du type de lien");
            CTypeLienReseau typelien = new CTypeLienReseau(m_contexteDonnees);
            Assert.IsTrue(typelien.ReadIfExists(nIdType));

            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            if (!lien.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", libelle)))
            {
                lien.CreateNewInCurrentContexte();
                lien.Libelle = libelle;
                lien.Site1 = site1;
                lien.Equipement2 = equip;
                lien.TypeLienReseau = typelien;
                lien.ExtremiteSurSite1 = ext1;
                

                CDirectionLienReseau direction = new CDirectionLienReseau(sens);
                lien.Direction = direction;

            }

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            nId = lien.Id;


            Console.WriteLine("lecture du lien SPV");
            CSpvLiai lienSpv = new CSpvLiai(m_contexteDonnees);

        /*    Assert.IsTrue(lienSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(lienSpv.NomLiaison == lien.Libelle);
            Console.WriteLine("v�rification du type");
            Assert.IsTrue(lienSpv.NomTypeLiaison == lien.TypeLienReseau.Libelle);
            Console.WriteLine("v�rification du ClassId");
            Assert.IsTrue(lienSpv.ClassId == 1004);*/



            return nId;


        }



        private int CreerSchemaReseau(int nidType, string libelle)
        {
            int nId;


            Console.WriteLine("cr�ation du sch�ma r�seau " + libelle);
            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau(m_contexteDonnees);
            Console.WriteLine("lecture du type de sch�ma");
            Assert.IsTrue(typeSchema.ReadIfExists(nidType));
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);

            if(!schema.ReadIfExists(new CFiltreData(CSchemaReseau.c_champLibelle + "=@1", libelle)))
            {
                schema.CreateNewInCurrentContexte();

                schema.TypeSchemaReseau= typeSchema;
                schema.Libelle = libelle;

            }


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = schema.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du schema");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            nId = schema.Id;

            return nId;
        }



        private int InsererLienDansSchema(int nIdSchema, int nIdLien)
        {

            Console.WriteLine("insertion d'un lien dans un sch�ma");
            

            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);
            Console.WriteLine("lecture du sch�ma");
            Assert.IsTrue(schema.ReadIfExists(nIdSchema));
            Console.WriteLine("lecture du lien r�seau");
            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            Assert.IsTrue(lien.ReadIfExists(nIdLien));

           
            CResultAErreur result = CResultAErreur.True;

            CElementDeSchemaReseau elementDeSchema = new CElementDeSchemaReseau(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens + "=@1", nIdSchema);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CLienReseau.c_champId + "=@1", nIdLien));
            if (!elementDeSchema.ReadIfExists(filtre))
            {

                elementDeSchema.CreateNewInCurrentContexte();
                elementDeSchema.ElementAssocie = lien;
                elementDeSchema.SchemaReseau = schema;
                //schema.Libelle = libelle;

                if (elementDeSchema.DonneeDessin == null)
                {
                   

                    CDonneeDessinLienDeSchemaReseau donneedessin = new CDonneeDessinLienDeSchemaReseau(-1);
                    donneedessin.Forward_Backward = ESensAllerRetourLienReseau.Forward;
                    

                    elementDeSchema.DonneeDessin = donneedessin;

                    
                }

            }


         
            Console.WriteLine("v�rification des donn�ees ");
           

            result = elementDeSchema.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement de l'��l�ment de sch�ma");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);




            return elementDeSchema.Id;
        }


        private int CreerLiaisonEquip(int nIdType, string libelle, int nIdEquip1, int nIdEquip2, EDirectionLienReseau sens)
        {
            int nId = -1;
            Console.WriteLine("cr�ation de la liaison " + libelle + " enre deux �quipements");


            Console.WriteLine("lecture de l'�l�ment 1");
            CEquipementLogique equip1 = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip1.ReadIfExists(nIdEquip1));
            Console.WriteLine("lecture de l'�l�ment 2");
            CEquipementLogique equip2 = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip2.ReadIfExists(nIdEquip2));



            Console.WriteLine("lecture du type de lien");


            CTypeLienReseau typelien = new CTypeLienReseau(m_contexteDonnees);
            Assert.IsTrue(typelien.ReadIfExists(nIdType));

            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            if (!lien.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", libelle)))
            {
                lien.CreateNewInCurrentContexte();
                lien.Libelle = libelle;
                lien.Equipement1 = equip1;
                lien.Equipement2 = equip2;
                lien.TypeLienReseau = typelien;

                
                CDirectionLienReseau direction = new CDirectionLienReseau(sens);
                lien.Direction = direction;

            }

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            Assert.IsTrue(result.Result);

            nId = lien.Id;




            return nId;


        }
        


        public void VerifierServiceRep(int nServiceId, int nCoeffOper)
        {

            //v�rification de la valeur de ServiceRep


            Console.WriteLine("chargement du service SPV");
            CSpvSchemaReseau serviceSpv = new CSpvSchemaReseau(m_contexteDonnees);
            Assert.IsTrue(serviceSpv.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champIdTimos + "=@1", nServiceId)));

            Console.WriteLine("chargement de NTWDIAG_REP");
            CSpvSchemaReseau_Rep serviceRep = new CSpvSchemaReseau_Rep(m_contexteDonnees);
            Assert.IsTrue(serviceRep.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champId + "=@1", serviceSpv.Id)));
            serviceRep.Refresh();
            Console.WriteLine("v�rification de la valeur de PROG_REP");

            Assert.IsTrue(serviceRep.CoefficientOperationnel == nCoeffOper);



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

        public void VerifierEquipRep(int nEquipId, int nEquipOper)
        {
            Console.WriteLine("Test de l'�tat de EQUIP_REP");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);

            Console.WriteLine("lecture de l'�quipement");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));

            Console.WriteLine("lecture de EQUIP_REP");
            CSpvEquip_Rep equipRep = new CSpvEquip_Rep(m_contexteDonnees);
          
            Assert.IsTrue(equipRep.ReadIfExists(new CFiltreData(CSpvEquip_Rep.c_champEQUIP_ID + "=@1", equipSpv.Id)));
            equipRep.Refresh();
            
            Console.WriteLine("v�rification de l'�tat de EQUIP_REP");

           Assert.IsTrue(equipRep.CodeEtatOperationnel == nEquipOper);





        }

        


        public void VerifierLiaiRep(int nLiaiId, int nLiaiOper)
        {
            Console.WriteLine("Test de l'�tat de LIAI_REP");
            CSpvLiai spvLiai = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("lecture de la liaison");
            Assert.IsTrue(spvLiai.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nLiaiId)));
            Console.WriteLine("lecture de LIAI_REP");
            CSpvLiai_Rep liaiRep = new CSpvLiai_Rep(m_contexteDonnees);

            Assert.IsTrue(liaiRep.ReadIfExists(new CFiltreData(CSpvLiai_Rep.c_champLIAI_ID + "=@1", spvLiai.Id)));
            liaiRep.Refresh();
            
            Console.WriteLine("v�rification de l'�tat de LIAI_REP");
            Assert.IsTrue(liaiRep.CodeEtatOperationnel== nLiaiOper);


        }



        public void VerifierLienSupportSupporte(int nIdSupporte, int nIdSupportant)
        {

            Console.WriteLine("v�rification de la relation lien supportant - lien supporte dans SPV");

            CSpvLiai lienSupporte = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("lecture du lien supporte");
            Assert.IsTrue(lienSupporte.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nIdSupporte)));

            CSpvLiai lienSupportant = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("lecture du lien supporte");
            Assert.IsTrue(lienSupportant.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nIdSupportant)));
            /*
            CSpvLiai_Liaic liai_liaic = new CSpvLiai_Liaic(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CSpvLiai_Liaic.c_champIdLiaisonSupport�e + "=@1" + " AND " + CSpvLiai_Liaic.c_champIdLiaisonSupportant + "@2", lienSupporte.Id, lienSupportant.Id); ;

            Console.WriteLine("V�rification de la relation support-support�");

            Assert.IsTrue(liai_liaic.ReadIfExists(filtre));
              */  

        }
       

        

        private int LireIdtypeliaison(string libelle)
        {


            Console.WriteLine("R�cup�ration de l'id du type de liaison");
            int nId = -1;
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            if (typeLien.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle + "=@1", libelle)))
            {
                nId = typeLien.Id;


            }
            return nId;




        }


        public int CreerTypeSupport(int nIdSupporte, int nIdSupportant)
        {

            int nId = -1;

            Console.WriteLine("cr�ation d'une relation 'support-support�");
            CTypeLienReseau typeSupportant = new CTypeLienReseau(m_contexteDonnees);
            CTypeLienReseau typeSupporte = new CTypeLienReseau(m_contexteDonnees);
            Console.WriteLine("lecture du type supportant");
            Assert.IsTrue(typeSupportant.ReadIfExists(nIdSupportant));
            Console.WriteLine("lecture du type support�");
            Assert.IsTrue(typeSupporte.ReadIfExists(nIdSupporte));

            CTypeLienReseauSupport support = new CTypeLienReseauSupport(m_contexteDonnees);


            CFiltreData filtre = new CFiltreData(CTypeLienReseauSupport.c_champIdTypeSupportant +"=@1",nIdSupportant);
            filtre=CFiltreData.GetAndFiltre(filtre, new CFiltreData(CTypeLienReseauSupport.c_champIdTypeSupport�+ "=@1",nIdSupporte));

            if (!support.ReadIfExists(filtre))
            {
                support.CreateNewInCurrentContexte();
                support.TypeSupportant= typeSupportant;
                support.TypeSupport� = typeSupporte;

            }




            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = support.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement de la relation support-support�");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            



            nId = support.Id;

            CSpvTypliai typeSupportantSpv = new CSpvTypliai(m_contexteDonnees);

            CSpvTypliai typeSupporteSpv = new CSpvTypliai(m_contexteDonnees);

            Console.WriteLine("lecture du type supportant SPV");

            Assert.IsTrue(typeSupportantSpv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nIdSupportant)));

            Console.WriteLine("lecture du type support� SPV");
            Assert.IsTrue(typeSupporteSpv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nIdSupporte)));

        /*     CSpvTypliai_Typliai supportSpv = new CSpvTypliai_Typliai(m_contexteDonnees);
             Console.WriteLine("v�rification de la liaison support-support� au niveau des types SPV");
            CFiltreData filtreTest = new CFiltreData(CSpvTypliai_Typliai.c_champTYPLIAI_ID + "=@1", typeSupportantSpv.Id);
            filtreTest = CFiltreData.GetAndFiltre(filtreTest, new CFiltreData(CSpvTypliai_Typliai.c_champTYPLIAI_BINDINGID + "=@1",typeSupporteSpv.Id));

            Assert.IsTrue(supportSpv.ReadIfExists(filtreTest));*/


            return nId;


        }



        public int CreerTypeLiaisonEquip(string libelle,bool bAsuperviser)
        {

            Console.WriteLine("cr�ation du type de liaison " + libelle + "entre deux �quipements");
            int nId = -1;
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            if(!typeLien.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle +"=@1",libelle)))
            {
                typeLien.CreateNewInCurrentContexte();
                typeLien.Libelle = libelle;
                typeLien.TypeElement1 = typeof(CEquipementLogique);
                typeLien.TypeElement2 = typeof(CEquipementLogique);
              

           
            }
            else
                Console.WriteLine("le type de lien r�seau existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeLien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement du type de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

         

            nId = typeLien.Id;



         
            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);
            Console.WriteLine("v�rification que le lien n'est pas supervis�");
            Assert.IsFalse(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));



            return nId;

            


        }

        public int CreerSchemaAssocieAUnLien(int nLienId)
        {
            //Cr�ation d'un sch�ma associ� � un lien

            Console.WriteLine("Cr�ation de sch�ma associ� � un lien");
            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            Console.WriteLine("chargement du lien r�seau");

            Assert.IsTrue(lien.ReadIfExists(nLienId));

            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);
            if (lien.SchemaReseau == null)
            {

                schema.CreateNewInCurrentContexte();
                schema.Libelle = lien.Libelle;
                schema.LienReseau = lien;

            }
            else
            {
                schema = lien.SchemaReseau;
                Console.WriteLine("le sch�ma associ� au lien existe d�j�");
            }
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = schema.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            Console.WriteLine("enregistrement du sch�ma de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int nId = schema.Id;

            Console.WriteLine("v�rification de l'id du lien associ� au sch�ma");
            Assert.IsTrue(schema.LienReseau.Id == lien.Id);


            return nId;



        }

        private int InsererEquipementDansSchema(int EquipId, int SchemaId)
        {

            //ins�re un �quipement dans un sch�ma

            Console.WriteLine("Insertion d'un �quipement dans  un sch�ma");

            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);

            Console.WriteLine("lecture du sch�ma");
            Assert.IsTrue(schema.ReadIfExists(SchemaId));
            Console.WriteLine("lecture de l'�quipement");
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip.ReadIfExists(EquipId));

            CSite site = new CSite(m_contexteDonnees);
            Console.WriteLine("lecture du site");
            Assert.IsTrue(site.ReadIfExists(new CFiltreData(CSite.c_champId + "=@1", equip.Site.Id)));

            string libelle = schema.Libelle;

            string nomsite = site.Libelle;


           
            CElementDeSchemaReseau elt = new CElementDeSchemaReseau(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens + "=@1", SchemaId);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CEquipementLogique.c_champId + "=@1", equip.Id));
            if (!elt.ReadIfExists(filtre))
            {

                elt.CreateNewInCurrentContexte();
                elt.ElementAssocie = equip;
                elt.SchemaReseau = schema;


               
            }


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = elt.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

         


            Console.WriteLine("enregistrement de l'�l�ment de sch�ma ");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            CElementDeSchemaReseau eltTest = new CElementDeSchemaReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de l'�l�ment de sch�ma");
            Assert.IsTrue(eltTest.ReadIfExists(elt.Id));
            Console.WriteLine("v�rification de la r�f�rence sch�ma de l'�l�ment");
            Assert.IsTrue(eltTest.SchemaReseau.Id == schema.Id);
            Console.WriteLine("v�rification de la r�f�rence �quipement de l'�l�ment");
            Assert.IsTrue(eltTest.EquipementLogique.Id == EquipId);

            CSchemaReseau schemaTest = new CSchemaReseau(m_contexteDonnees);
            Console.WriteLine("v�rification du sch�ma r�seau");
            Assert.IsTrue(schemaTest.ReadIfExists(SchemaId));
            Console.WriteLine("v�rification du libell� du sch�ma");
            Assert.IsTrue(schemaTest.Libelle == libelle);


            return elt.Id;



        }


        private void ModifierTypeElement1(int nId, Type typeElt1)
        {

            Console.WriteLine("modifier le type de l'�l�ment 1 du lien");


            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);
           
            Assert.IsTrue(typeLien.ReadIfExists(nId));

            typeLien.TypeElement1 = typeElt1;



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeLien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement du type de lien ");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);

            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));
   


        }


        private void ModifierTypeElement2(int nId, Type typeElt2)
        {


            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            Assert.IsTrue(typeLien.ReadIfExists(nId));

            typeLien.TypeElement2 = typeElt2;



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeLien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement du type de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);

            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));





        }

        public int CreerTypeLiaisonSites(string libelle)
        {


            Console.WriteLine("cr�e le type de liaison " + " entre 2 sites");
            int nId = -1;
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            if (!typeLien.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle + "=@1", libelle)))
            {
                typeLien.CreateNewInCurrentContexte();
                typeLien.Libelle = libelle;
                typeLien.TypeElement1 = typeof(CSite);
                typeLien.TypeElement2 = typeof(CSite);


            }

            else
                Console.WriteLine("le type de lien r�seau existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeLien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement du type de lien");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            nId = typeLien.Id;



        

            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);
            Console.WriteLine("Lecture du lien SPV");
            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(lienspv.Libelle == libelle);


            return nId;




        }

       
        private int InsererSiteDansSchema(int nSiteId, int nSchemaId)
        {

            //insertion d'un site dans un schema
            
            Console.WriteLine("Insertion du site dans un sch�ma");
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);
            Console.WriteLine("Lecture du sch�ma");
            Assert.IsTrue(schema.ReadIfExists(nSchemaId));
            CSite site = new CSite(m_contexteDonnees);
            Console.WriteLine("lecture du site");
            Assert.IsTrue(site.ReadIfExists(nSiteId));

           
           

            CElementDeSchemaReseau elementDeSchema = new CElementDeSchemaReseau(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champIdSchemaReseauAuquelJappartiens + "=@1", nSchemaId);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSite.c_champId + "=@1", nSiteId));
            if (!elementDeSchema.ReadIfExists(filtre))
            {
                elementDeSchema.CreateNewInCurrentContexte();
                elementDeSchema.ElementAssocie = site;
                elementDeSchema.SchemaReseau = schema;
                //on modifie le sch�ma afin que la mise � jour soit faite dans CSPVSchemaReseauServeur






                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�ees");
                result = elementDeSchema.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);




                Console.WriteLine("enregistrement des donn�ees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);



            }
            return elementDeSchema.Id;
        }

        private void ModifierLibelleLiaison(int nIdLiaison, string newLibelle)
        {


            Console.WriteLine("modification du libell� d'une liaison");
            CLienReseau lien = new CLienReseau(m_contexteDonnees);

            Assert.IsTrue(lien.ReadIfExists(nIdLiaison));


            CLienReseau lienTestLibelle = new CLienReseau(m_contexteDonnees);
            if (!lienTestLibelle.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", newLibelle)))
            {



                lien.Libelle = newLibelle;



                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�ees");
                result = lien.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);




                Console.WriteLine("enregistrement des donn�ees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);
                int nId = lien.Id;

                CSpvLiai lienspv = new CSpvLiai(m_contexteDonnees);
                Console.WriteLine("lecture du lien SPV");
                Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId)));
                Console.WriteLine("V�rification du libell�");
                Assert.IsTrue(lienspv.NomLiaison == newLibelle);

            }
            else
                Console.WriteLine("Un lien avec ce libell� existe d�j�");

        }



        private void SupprimerExtremiteSite(int nSiteId, string nomExt)
        {

            //suppression d'une extr�mit� d'un site
            Console.WriteLine("suppression de l'extr�mit� de site " + nomExt);
            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CSite.c_champId + "=@1", nSiteId);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CExtremiteLienSurSite.c_champLibelle + "=@1", nomExt));
            Console.WriteLine("lecture de l'extr�mit� site � supprimer");
            Assert.IsTrue(ext.ReadIfExists(filtre));
            /*CSpvExt spvExt = new CSpvExt(m_contexteDonnees);
            Console.WriteLine("lecture de l'extr�mit� du site SPV");
            Assert.IsTrue(spvExt.ReadIfExists(new CFiltreData(CSpvExt.c_champExtremiteLienSurSite_Id + "=@1", ext.Id)));
            */
            int nId = ext.Id;
            //int nSpvId = spvExt.Id;
            CResultAErreur result = ext.Delete();

            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("suppression de l'extr�mit� du site");
            Assert.IsTrue(result.Result);



            CExtremiteLienSurSite test = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression de l'extr�mit� du site TIMOS");
            Assert.IsFalse(test.ReadIfExists(nId));
            /*
            CSpvExt testSpv = new CSpvExt(m_contexteDonnees);

            Console.WriteLine("v�rification de la suppression de l'extr�mit� du site SPV");
            Assert.IsFalse(testSpv.ReadIfExists(new CFiltreData(CSpvExt.c_champExtremiteLienSurSite_Id + "=@1", nSpvId)));
            */

        }


        private void SupprimerExtremiteSite(int nExtId)
        {

            //suppression d'une extr�mit� d'un site
            Console.WriteLine("suppression de l'extr�mit� de site ");
            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("lecture de l'extr�mit� site � supprimer");
            Assert.IsTrue(ext.ReadIfExists(nExtId));
            /*
            CSpvExt spvExt = new CSpvExt(m_contexteDonnees);
            Console.WriteLine("lecture de l'extr�mit� du site SPV");
            Assert.IsTrue(spvExt.ReadIfExists(new CFiltreData(CSpvExt.c_champExtremiteLienSurSite_Id + "=@1", nExtId)));
            */

            //int nSpvId = spvExt.Id;
            CResultAErreur result = ext.Delete();

            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("suppression de l'extr�mit� du site");
            Assert.IsTrue(result.Result);



            CExtremiteLienSurSite test = new CExtremiteLienSurSite(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression de l'extr�mit� du site TIMOS");
            Assert.IsFalse(test.ReadIfExists(nExtId));
            /*
            CSpvExt testSpv = new CSpvExt(m_contexteDonnees);

            Console.WriteLine("v�rification de la suppression de l'extr�mit� du site SPV");
            Assert.IsFalse(testSpv.ReadIfExists(new CFiltreData(CSpvExt.c_champExtremiteLienSurSite_Id + "=@1", nSpvId)));
            */

        }




        private void ModifierLibelleService(int nIdService, string newLibelle)
        {


            Console.WriteLine("modification du libell� d'un service");
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);

            Assert.IsTrue(schema.ReadIfExists(nIdService));


            
             CSchemaReseau lienTestLibelle = new CSchemaReseau(m_contexteDonnees);
            if (!lienTestLibelle.ReadIfExists(new CFiltreData(CSchemaReseau.c_champLibelle + "=@1", newLibelle)))
            {


                schema.Libelle = newLibelle;




                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�ees");
                result = schema.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);




                Console.WriteLine("enregistrement des donn�ees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);
                int nId =schema.Id;

                CSpvSchemaReseau servicespv = new CSpvSchemaReseau(m_contexteDonnees);
                
                Console.WriteLine("lecture du service SPV");
                Assert.IsTrue(servicespv.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champIdTimos + "=@1", nId)));
                Console.WriteLine("V�rification du libell�");
                Assert.IsTrue(servicespv.Libelle == newLibelle);

            }
            else
                Console.WriteLine("Un lien avec ce libell� existe d�j�");

        }



        private void ModifierSensLiaison(int nIdLiaison, EDirectionLienReseau newDirection)
        {

            Console.WriteLine("modification du sens de la liaison");
            CLienReseau lien = new CLienReseau(m_contexteDonnees);

            Console.WriteLine("Lecture de la liaison");
            Assert.IsTrue(lien.ReadIfExists(nIdLiaison));

            CDirectionLienReseau sens = new CDirectionLienReseau(newDirection);
            lien.Direction = sens;



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            

            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


           
            int nId = lien.Id;

            CSpvLiai lienspv = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("Lecture de la liaison");
            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId)));
            Console.WriteLine("v�rification du sens de la liaison");
            if (newDirection == EDirectionLienReseau.UnVersDeux)
                Assert.IsTrue(lienspv.CodeDirectionBool == false);
            else if (newDirection == EDirectionLienReseau.DeuxVersUn)
                Assert.IsTrue(lienspv.CodeDirectionBool == true);
            
            


        }




        private void SupprimerLiaison(int nId)
        {

            Console.WriteLine("suppression d'une liaison");

            CLienReseau lien = new CLienReseau(m_contexteDonnees);


            
            Console.WriteLine("Lecture de la liaison � supprimer");
            Assert.IsTrue(lien.ReadIfExists(nId));

           
            CResultAErreur result = CResultAErreur.True;
            
            Console.WriteLine("lecture du lien SPV � supprimer");

            CSpvLiai lienSpv = new CSpvLiai(m_contexteDonnees);
            lienSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId));
            
            

            result = lien.Delete();

            Console.WriteLine("suppression de la liaison");
              if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);



            CLienReseau lienTest = new CLienReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression du lien Timos");
            Assert.IsFalse(lienTest.ReadIfExists(nId));


            CSpvLiai lienSpvTest = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression du lien spv");
            Assert.IsFalse(lienSpvTest.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nId)));





        }

        private void ModifierTypeLiaison(int nId, string newLibelle)
        {


         CTypeLienReseau typeLibelle = new CTypeLienReseau(m_contexteDonnees);
            //Modification du libell� d'un site


         if (!typeLibelle.ReadIfExists(new CFiltreData(CTypeLienReseau.c_champLibelle + "=@1", newLibelle)))
         {

             CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);
             Console.WriteLine("Modification d'un type de liasion");


             Console.WriteLine("Lecture du type de liaison");
             Assert.IsTrue(typeLien.ReadIfExists(nId));

             typeLien.Libelle = newLibelle;




             CResultAErreur result = m_contexteDonnees.SaveAll(true);
             Console.WriteLine("Enregistrement du type de liaiosn");
             if (!result)
                 System.Console.WriteLine(result.MessageErreur);

             nId = typeLien.Id;



          

             CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);

             Console.WriteLine("lecture du type de liaison");
             Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));
             Console.WriteLine("v�rification du libell�");
             Assert.IsTrue(lienspv.Libelle == newLibelle);


         }
         else
             Console.WriteLine("un type avec ce libelle existe d�j�");    

        }


        private int CreerTypeService(string libelle)
        {
            int nId = -1;

            Console.WriteLine("cr�ation du type de service " + libelle);
            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau(m_contexteDonnees);

            if (!typeSchema.ReadIfExists(new CFiltreData(CTypeSchemaReseau.c_champLibelle + "=@1", libelle)))
            {
                typeSchema.CreateNewInCurrentContexte();

                typeSchema.Libelle = libelle;

                //CSpvTypeService.GetObjetSpvFromObjetTimosAvecCreation(typeSchema);    
            }



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeSchema.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            nId = typeSchema.Id;



            /*
            Console.WriteLine("lecture du type de service");
            CSpvTypeService typeServ = new CSpvTypeService(m_contexteDonnees);
             Assert.IsTrue(typeServ.ReadIfExists(new CFiltreData(CSpvTypeService.c_champIdTypeSchemaTimos + "=@1", nId)));
             Console.WriteLine("v�rification du libell�");
             Assert.IsTrue(typeServ.Libelle == libelle);
            */


            return nId;

        }


        public int RecupererAccesAlarmeSite(string nomAcces, int nSiteId)
        {
            //r�cup�re l'id de l'acc�s alarme d'un site
            int nId = -1;

            CSpvSite siteSpv = new CSpvSite(m_contexteDonnees);
            Assert.IsTrue(siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nSiteId)));
            int nIdSiteSpv = siteSpv.Id;
            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);

            // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1" + " AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2", nIdSiteSpv.ToString(),nomAcces);

            CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champSITE_ID + "=@1", nIdSiteSpv);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nomAcces));
            Assert.IsTrue(accesAlarme.ReadIfExists(filtre));
            nId = accesAlarme.Id;
            return (nId);
        }


        public int RecupererAccesAlarmEquip(string nomAcces, int nEquipId)
        {
            int nId = -1;

            Console.WriteLine("Lecture d'un acc�s alarme sur un �quipement");

            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipemnt SPV");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nEquipId)));
            int nIdSpv = equipSpv.Id;

            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);
            // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1" + " AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2", nIdSpv.ToString(),nomAcces);

            CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + " =@1", nIdSpv);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nomAcces));
            Console.WriteLine("lecture de l'acc�s alarme");
            Assert.IsTrue(accesAlarme.ReadIfExists(filtre));
            nId = accesAlarme.Id;
            return (nId);
        }


        public int RecupererAccesAlarmLien(string nomAcces, int nLienId)
        {
            int nId = -1;

            Console.WriteLine("Lecture d'un acc�s alarme sur un �quipement");

            CSpvLiai lienSpv = new CSpvLiai(m_contexteDonnees);
            Console.WriteLine("lecture du lien SPV");
            Assert.IsTrue(lienSpv.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1",nLienId)));
         
            

            CSpvAccesAlarme accesAlarme = new CSpvAccesAlarme(m_contexteDonnees);
            // CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1" + " AND " + CSpvAccesAlarme.c_champACCES_NOM + "=@2", nIdSpv.ToString(),nomAcces);

            CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champLIAI_ID + " =@1", lienSpv.Id);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nomAcces));
            Console.WriteLine("lecture de l'acc�s alarme");
            Assert.IsTrue(accesAlarme.ReadIfExists(filtre));
            nId = accesAlarme.Id;
            return (nId);
        }


        public int CreerTypeAccesEntreeEquipement(int typeqId, string nomType)
        {
            //cr�e un type d'acc�s entr�e alarme sur un type �quipement

            Console.WriteLine("cr�ation d'une entr�e alarme");

            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);

            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("chargement du type d'�quipement");
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeqId)));
            int spvTypeqId = typeq.Id;
            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomType);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champTYPEQ_ID + "=@1", spvTypeqId));

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

        public int CreerTypeAccesAlarme(int nTypeqId, string nomAcces, ECategorieAccesAlarme categorie)
        {

            Console.WriteLine("cr�ation du type d'acc�s alarme " + nomAcces);
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);

            Console.WriteLine("lecture du type d'�quipement");
            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nTypeqId)));

            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomAcces);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1", typeq.Id ));


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
            Console.WriteLine("v�rification des donn�ees");
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            return typeAcces.Id;

        }

       


        public int CreerAccesAlarmeLiaison(int nLienId, string nomAcces, ECategorieAccesAlarme categorie)
        {

            Console.WriteLine("cr�ation du type d'acc�s alarme " + nomAcces);
            CSpvAccesAlarme typeAcces = new CSpvAccesAlarme(m_contexteDonnees);

            Console.WriteLine("lecture du type de lien r�seau");
            CSpvLiai lien = new CSpvLiai(m_contexteDonnees);
           
            Assert.IsTrue(lien.ReadIfExists(new CFiltreData(CSpvLiai.c_champSmtLienReseau_Id + "=@1", nLienId)));
            CFiltreData filtre = new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nomAcces);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvAccesAlarme.c_champLIAI_ID+ "=@1", lien.Id));


            if (!typeAcces.ReadIfExists(filtre))
            {

                typeAcces.CreateNewInCurrentContexte();
                typeAcces.NomAcces = nomAcces;
                typeAcces.SpvLiai = lien;
                typeAcces.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                typeAcces.CategorieAccesAlarme = categorieAcces;
            }
            else

                Console.WriteLine("L'acc�s alarme existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            return typeAcces.Id;

        }

        private int CreerPort(int nTypeqId, string libelle)
        {

            //cr�ation d'un port sur un type d'�quipement


            Console.WriteLine("cr�ation du port " + libelle);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);

            Console.WriteLine("lecture du type d'�quipemnt");
            Assert.IsTrue(typeq.ReadIfExists(nTypeqId));

            CPort port = new CPort(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CPort.c_champLibelle + "=@1", libelle);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CTypeEquipement.c_champId + "=@1", nTypeqId));
            if (!port.ReadIfExists(filtre))
            {
                port.CreateNewInCurrentContexte();
                port.TypeEquipement = typeq;
                port.Libelle = libelle;

            }




            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = port.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);




            CPort portTest = new CPort(m_contexteDonnees);
            Console.WriteLine("v�rification de la cr�ation du port");
            Assert.IsTrue(portTest.ReadIfExists(port.Id));

            return port.Id;
        }

        private int CreerLiaisonPorts(int nIdType, string libelle, int nIdEquip1, int nIdEquip2, int nIdPort1, int nIdPort2, EDirectionLienReseau sens)
        {
            int nId = -1;
            Console.WriteLine("cr�e la liaison  entre deux ports " + libelle);


            Console.WriteLine("lecture de l'�quipement 1");
            CEquipementLogique equip1 = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip1.ReadIfExists(nIdEquip1));


            Console.WriteLine("lecture de l'�quipement 2");
            CEquipementLogique equip2 = new CEquipementLogique(m_contexteDonnees);
            Assert.IsTrue(equip2.ReadIfExists(nIdEquip2));



            Console.WriteLine("lecture du port 1");
            CPort port1 = new CPort(m_contexteDonnees);
            Assert.IsTrue(port1.ReadIfExists(nIdPort1));
            Console.WriteLine("lecture du port 2");
            CPort port2 = new CPort(m_contexteDonnees);
            Assert.IsTrue(port2.ReadIfExists(nIdPort2));



            Console.WriteLine("lecture du type de lien r�seau");
            CTypeLienReseau typelien = new CTypeLienReseau(m_contexteDonnees);
            Assert.IsTrue(typelien.ReadIfExists(nIdType));

            CLienReseau lien = new CLienReseau(m_contexteDonnees);
            if (!lien.ReadIfExists(new CFiltreData(CLienReseau.c_champLibelle + "=@1", libelle)))
            {
                lien.CreateNewInCurrentContexte();
                lien.Libelle = libelle;
                lien.Equipement1 = equip1;
                lien.Equipement2 = equip2;
                lien.TypeLienReseau = typelien;
                lien.Port1 = port1;
                lien.Port2 = port2;

                CDirectionLienReseau direction = new CDirectionLienReseau(sens);
                lien.Direction = direction;


            }
            else

                Console.WriteLine("le type de lien r�saeu existe d�j�");



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = lien.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);




            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            nId = lien.Id;




            return nId;


        }


        public void SupprimerCablageAlarme(int nId)
        {

            //supprime le c�blage d'une alarme

            Console.WriteLine("Suppression d'un c�blage d'alarme");
            CSpvLienAccesAlarme lienAcces = new CSpvLienAccesAlarme(m_contexteDonnees);
            Console.WriteLine("chargement du len acc�s alarme");
            Assert.IsTrue(lienAcces.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "=@1", nId)));


            CResultAErreur result = CResultAErreur.True;

            result = lienAcces.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("suppression du c�blage d'alarme");
            Assert.IsTrue(result.Result);
        
            Console.WriteLine("v�rification de la suppression du c�blage d'alarme");
            CSpvLienAccesAlarme lienTest = new CSpvLienAccesAlarme(m_contexteDonnees);
            Assert.IsFalse(lienTest.ReadIfExists(new CFiltreData(CSpvLienAccesAlarme.c_champACCES_ACCESC_ID + "=@1", nId)));

            


        }

        private void ModifierTypeLiaisonSansValider(int nId, string newLibelle)
        {

            Console.WriteLine("modification d'un type de liaison sans valider");
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);
            Console.WriteLine("lecture du tpye de liaiosn");
            Assert.IsTrue(typeLien.ReadIfExists(nId));

            string oldlibelle = typeLien.Libelle;

            typeLien.Libelle = newLibelle;

          
           
            nId = typeLien.Id;



            System.Threading.Thread.Sleep(500);

            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);

            Console.WriteLine("lecture du tpye de liaiosn");
            Assert.IsTrue(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(lienspv.Libelle == oldlibelle);

                                      


        }




        private void SupprimerEquipementSchema(int nIdElement)
        {

            Console.WriteLine("suppression d'un �quipment dans un  sch�ma");
            CElementDeSchemaReseau element = new CElementDeSchemaReseau(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champId + "=@1", nIdElement);
            

            Console.WriteLine("lecture e l'�l�ment de sch�ma");
            Assert.IsTrue(element.ReadIfExists(filtre));

            int nIdElt = element.Id;
            CResultAErreur result = element.Delete();

            Console.WriteLine("suppression de l'�l�ment de sch�ma");
            Assert.IsTrue(result.Result);






            CElementDeSchemaReseau elementTest = new CElementDeSchemaReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression");
            Assert.IsFalse(elementTest.ReadIfExists(filtre));



        }




        private void SupprimerLienSchema(int nIdElement)
        {
            Console.WriteLine("suppresssion d'un ilen du sch�ma");

            CElementDeSchemaReseau element = new CElementDeSchemaReseau(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champId + "=@1", nIdElement);
            Console.WriteLine("Lecture de l'�l�ment de sch�ma");
            Assert.IsTrue(element.ReadIfExists(filtre));

            int nIdElt = element.Id;
            CResultAErreur result = element.Delete();

            Console.WriteLine("suppreesion de l'�l�ment de sch�ma");
            Assert.IsTrue(result.Result);




            CElementDeSchemaReseau elementTest = new CElementDeSchemaReseau(m_contexteDonnees);

            Console.WriteLine("v�rification de la suppression de l'�l�ment de sch�ma");
            Assert.IsFalse(elementTest.ReadIfExists(filtre));



        }



        private void SupprimerSiteSchema(int nIdElement)
        {

            Console.WriteLine("suppression d'un site du sch�ma");
            CElementDeSchemaReseau element = new CElementDeSchemaReseau(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CElementDeSchemaReseau.c_champId + "=@1", nIdElement);

            Console.WriteLine("lecture de l'�l�ment du sch�ma");
            Assert.IsTrue(element.ReadIfExists(filtre));

            int nIdElt = element.Id;
            CResultAErreur result = element.Delete();

            Console.WriteLine("suppression de l'�l�ment de sch�ma");
            Assert.IsTrue(result.Result);



            CElementDeSchemaReseau elementTest = new CElementDeSchemaReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression");
            Assert.IsFalse(elementTest.ReadIfExists(filtre));


        }


        
        private int CreerService(int nTypeId,string libelle, int clientId)
        {

            int nid;

            Console.WriteLine("cr�ation du service " + libelle);
            CSpvClient client = new CSpvClient(m_contexteDonnees);
            Assert.IsTrue(client.ReadIfExists(clientId));
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);        
            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau(m_contexteDonnees);
            Assert.IsTrue(typeSchema.ReadIfExists(nTypeId));
            if (!schema.ReadIfExists(new CFiltreData(CSchemaReseau.c_champLibelle + "=@1", libelle)))
            {
                schema.CreateNewInCurrentContexte();
                schema.Libelle = libelle;
                schema.TypeSchemaReseau = typeSchema;

                CSpvSchemaReseau serv = CSpvSchemaReseau.GetObjetSpvFromObjetTimosAvecCreation(schema);
                //serv.SpvClient= client;

            }

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = schema.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            
            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            nid = schema.Id;


            CSpvSchemaReseau service = new CSpvSchemaReseau(m_contexteDonnees);

            Console.WriteLine("v�rification de la cr�ation du service");
            Assert.IsTrue(service.ReadIfExists(new CFiltreData(CSpvSchemaReseau.c_champIdTimos + "=@1", nid)));

            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(service.Libelle == libelle);
       
           
           



            return nid;


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
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            CResultAErreur result = equip.Delete();
          

            Console.WriteLine("V�rification de la suppression de l'�quipemnt logique");
            CEquipementLogique equiptest = new CEquipementLogique(m_contexteDonnees);
            Assert.IsFalse(equiptest.ReadIfExists(nId));

            CSpvEquip equipTest = new CSpvEquip(m_contexteDonnees);
            Assert.IsFalse(equipTest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

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

            Console.WriteLine("chargement du site SPV � supprimer");

            typeSiteSpv.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1",
                    nIdSite));

            result = typeSite.Delete();

            Console.WriteLine("Suppression du type de site");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);




            CTypeSite typesiteTest = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression du site Timos");

            Assert.IsFalse(typesiteTest.ReadIfExists(nIdSite));

            CSpvTypsite spvTest = new CSpvTypsite(m_contexteDonnees);
            Assert.IsFalse(typesiteTest.ReadIfExists(nIdSite));

            Console.WriteLine("V�rification de la suppression du site SPV");
            Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", nIdSite)));




        }

        public void SupprimerSite(string libelle)
        {
            Console.WriteLine("suppression du site " + libelle);
            CSite site = new CSite(m_contexteDonnees);
            Console.WriteLine("lecture du libell� du site � supprimer");
            Assert.IsTrue(site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1", libelle)));
            SupprimerSite(site.Id);

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
                siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                    nIdSite));

                Console.WriteLine("suppression du site " + site.Libelle);
                result = site.Delete();

                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

            }

            CSite siteTest = new CSite(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression du site Timos");


            CSpvSite spvTest = new CSpvSite(m_contexteDonnees);
            Assert.IsFalse(siteTest.ReadIfExists(new CFiltreData(CSite.c_champId + "=@1",
                nIdSite.ToString())));

            Console.WriteLine("V�rification de la suppression du site SPV");
            Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", nIdSite)));


        }


        


       


        private void SupprimerTypeliaison(int nId)
        {
            Console.WriteLine("suppression du type de liaison");
            CTypeLienReseau typeLien = new CTypeLienReseau(m_contexteDonnees);

            Console.WriteLine("lecture  du type de liaison");
            Assert.IsTrue(typeLien.ReadIfExists(nId));

            CSpvTypliai lienSpv = new CSpvTypliai(m_contexteDonnees);

            Assert.IsTrue(lienSpv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id +"=@1",nId)));


            CResultAErreur result;
            Console.WriteLine("suppression du type de liaison");
            result = lienSpv.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            result= typeLien.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            

         
           
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
      /*       result = m_contexteDonnees.SaveAll(true);
             Console.WriteLine("enregistrement de la suppression");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            
        
            Assert.IsTrue(result.Result);*/

            System.Threading.Thread.Sleep(500);
            CTypeLienReseau typeTest = new CTypeLienReseau(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression du lien Timos");
            Assert.IsFalse(typeTest.ReadIfExists(nId));

            CSpvTypliai lienspv = new CSpvTypliai(m_contexteDonnees);
            Console.WriteLine("v�rification de la suppression du lien SPV");
            Assert.IsFalse(lienspv.ReadIfExists(new CFiltreData(CSpvTypliai.c_champSmtTypeLienReseau_Id + "=@1", nId)));



            
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
                typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId));


                CResultAErreur result = typeq.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Console.WriteLine("suppression du type d'�quipemnt");
                Assert.IsTrue(result.Result);




                CSpvTypeq spvTest = new CSpvTypeq(m_contexteDonnees);
                Console.WriteLine("v�rification de la suppression du type SPV");
                Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

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
            Console.WriteLine("v�rification des donn�ees");
            result = typeAcces.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            return typeAcces.Id;





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
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1", nTypeqId));



            if (!typeAccesAlarme.ReadIfExists(filtre))
            {


                typeAccesAlarme.CreateNewInCurrentContexte();
                typeAccesAlarme.NomAcces = nomAcces;
                typeAccesAlarme.SpvTypeq = typeq;
                typeAccesAlarme.ConnectionsNumber = 1;
                CCategorieAccesAlarme categorieAcces = new CCategorieAccesAlarme(categorie);
                int nCat = categorieAcces.CodeInt;
                typeAccesAlarme.CategorieAccesAlarme = categorieAcces;
            }
            else
                Console.WriteLine("le typeAcces d'acc�s alarme sur le type d'�quipemnt existe d�j�");


            Console.WriteLine("Enregistrement de l'acc�s alarme");
            CResultAErreur result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            //     Assert.IsTrue(result.Result);


      
            Console.WriteLine("v�rification des donn�ees");
            result = typeAccesAlarme.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            return typeAccesAlarme.Id;

            


        }
        private int CreerFamille(string libelle)
        {

            Console.WriteLine("Cr�ation de la  famille de types d'�quipment "+ libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (!famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1", libelle)))
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = libelle;
                

            }

            else
                Console.WriteLine("la famille existe d�j�");

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = famille.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donn�ees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            
            Console.WriteLine("v�rification de l'existence de la famille");
            CFamilleEquipement familletest = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(familletest.ReadIfExists(famille.Id));

            return famille.Id;

        }




        public int CreerAlarme(int EquipId, int AlarmeGereeId, string AlarmeNom, EAlarmEvent AlarmeEvt, EGraviteAlarmeAvecMasquage gravite, string accesNom, int cablageId)
        {


            Console.WriteLine("cr�ation d'une alarme");
            int nId = -1;

            CSpvAlarmTest alarme = new CSpvAlarmTest(m_contexteDonnees);
            CSpvEquip spvEquip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("Lecture de l'�quipement");
            Assert.IsTrue(spvEquip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + " =@1", EquipId)));


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

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = alarme.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donn�ees");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            nId = alarme.Id;
            alarme.AlarmNum = nId;

            /*    CGraviteAlarme graviteAlarme = new CGraviteAlarme(gravite);
                alarme.AlarmGrave = graviteAlarme;*/
            //           alarme.AlarmNum = nId;
            /*    result = m_contexteDonnees.SaveAll(true);
                 if (!result) 
                      System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);*/

           //   CSpvAlarmTest alarmTest = new CSpvAlarmTest(m_contexteDonnees);
             //   Assert.IsTrue(alarmTest.ReadIfExists(new CFiltreData(CSpvAlarmTest.c_champALARM_ID + "=@1", nId)));
            //Assert.IsTrue(alarmTest.AlarmgereeId == AlarmeGereeId);

            //Console.WriteLine(alarmTest.AlarmgereeId);
            return nId;



        }


        public int CreerAlarmeGeree(int nIdTypeAcces, EAlarmEvent evt, EGraviteAlarmeAvecMasquage gravite)
        {

            Console.WriteLine("cr�ation d'une alarme g�r�e");
            int nId = -1;
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

                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�ees");
                result = alarmeGeree.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donn�ees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);


                nId = alarmeGeree.Id;

                CSpvAlarmGeree test = new CSpvAlarmGeree(m_contexteDonnees);
                Console.WriteLine("lecture de l'alarme g�r�e");
                Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champALARMGEREE_ID + "=@1", nId)));


                Console.WriteLine(test.AlarmgereeGravite.Libelle);

                //  Assert.IsTrue(test.AlarmgereeGravite.Libelle = gravite.ToString());

            }

            return nId;

        }



        private void ModifierGraviteAlarmeGeree(int nIdAlamreGeree, EGraviteAlarmeAvecMasquage gravite)
        {

            Console.WriteLine("cr�ation d'une alarme g�r�e");
            int nId = -1;
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);


            Console.WriteLine("lecture de l'alarme geree");
            Assert.IsTrue(alarmeGeree.ReadIfExists(nIdAlamreGeree));


            CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
            alarmeGeree.AlarmgereeGravite = grav;

            
           
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�ees");
            result = alarmeGeree.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
             Assert.IsTrue(result.Result);

             Console.WriteLine("enregistrement des donn�ees");


             nId = alarmeGeree.Id;

             CSpvAlarmGeree test = new CSpvAlarmGeree(m_contexteDonnees);
             Console.WriteLine("lecture de l'alarme g�r�e");
             Assert.IsTrue(test.ReadIfExists(nId));

             Assert.IsTrue(test.AlarmgereeGravite.CodeInt == grav.CodeInt);
             Console.WriteLine(test.AlarmgereeGravite.Libelle);
            

            

        

        }





        private int LireIdEquipementLogique(string nom)
        {
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Console.WriteLine("lecture de l'id de l'�quipemnt logique" + nom);
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", nom)));

            return equip.Id;


        }


        private void VerifierEquipASurveiller(int nIdEquip, bool bToSurv)
        {

            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipement logique");
            Assert.IsTrue(equip.ReadIfExists(nIdEquip));
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);



        }
        
        
        void OnReceiveNotificationAlarmEnCours(IDonneeNotification donnee)
        {

            /*
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
                   
                    if (evAlarme.EventAlarmStartStop.AlarmInfo.SeverityCode == (int)EGraviteAlarmeAvecMasquage.EndAlarm
                        && evAlarme.EventAlarmStartStop.AlarmInfo.StartAlarmId > 0)
                    {
                        for (int i = 0; i < m_lstViewEnCours.Count; i++)
                        {
                            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                            if(infoAlarm.InfoEquipement!=null)
                                Console.WriteLine(infoAlarm.InfoEquipement.Name);
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
                        Console.WriteLine("r�ception d'une alarme");
                        // CInfoAlarmeAffichee infoRecue = evAlarme.EventAlarmStartStop.AlarmInfo;
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.Info);
                        //    string nomElGere = infoRecue.ElementGereeName;
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.AlarmComment);
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.AlarmDate);
                        Console.WriteLine(evAlarme.EventAlarmStartStop.AlarmInfo.ElementGereeName);
                    

                    }
                }
                if (evAlarme.CategorieMessageAlarme == ECategorieMessageAlarme.AlarmMasqueeParUneAutre)
                {
                    Console.WriteLine("Retomb�e d'une alarme");
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
                        //else
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




        }*/

            Console.WriteLine("R�ception d'une notification d'alarme");
            CDonneeNotificationAlarmes donneeAlarme = donnee as CDonneeNotificationAlarmes;
            if (donneeAlarme == null)
            {
                m_bSortieAlarme = true;
                return;
            }
            m_bSortieAlarme = true;
            CEvenementAlarm[] lstAlarmes = donneeAlarme.Alarmes;
            foreach (CEvenementAlarm evAl in lstAlarmes)
            {
                if (evAl is CEvenementAlarmStartStop)
                {
                    CEvenementAlarmStartStop evAlarme = (CEvenementAlarmStartStop)evAl;
                    if (evAlarme.Gravite == EGraviteAlarmeAvecMasquage.EndAlarm &&
                        evAlarme.IdAlarmeDebut > 0)
                    {
                        for (int i = 0; i < m_lstViewEnCours.Count; i++)
                        {
                            CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                            if (infoAlarm.InfoEquipement != null)
                                Console.WriteLine(infoAlarm.InfoEquipement.Name);

                            if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme ==
                                evAlarme.IdAlarmeDebut)
                            {
                                m_lstViewEnCours.Remove(infoAlarm);
                                infoAlarm.DateFin = evAlarme.DateEvenementAlarme;
                                //  m_lstViewRetombe.AddObject(infoAlarm);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("r�ception d'une alarme");
                        // CInfoAlarmeAffichee infoRecue = evAlarme.EventAlarmStartStop.AlarmInfo;
                        Console.WriteLine(evAlarme.InfoAdditionnelle);
                        //    string nomElGere = infoRecue.ElementGereeName;
                        Console.WriteLine(evAlarme.Commentaire);
                        Console.WriteLine(evAlarme.DateEvenementAlarme);
                        Console.WriteLine(evAlarme.NomObjet);
                    }
                }
                else if (evAl is CEvenementAlarmMasqueeParUneAutre)
                {
                    Console.WriteLine("Retomb�e d'une alarme");
                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == 
                            ((CEvenementAlarmMasqueeParUneAutre)evAl).AlarmStartId)
                        {
                            m_lstViewEnCours.Remove(infoAlarm);
                            //            infoAlarm.DateFin = evAlarme.EventAlarmRetombee.StopAlarmDate;
                            //            m_lstViewRetombe.AddObject(infoAlarm);
                            break;
                        }
                    }
                }
                else if (evAl is CEvenementAlarmMask)
                {
                    CEvenementAlarmMask evAlarme = (CEvenementAlarmMask)evAl;

                    if (evAlarme.NiveauMasquage != EMasquage.NonMasque)
                    {
                        if (evAlarme.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm++;
                        //else
                        m_NbMaskBrig++;
                    }
                    else
                    {
                        if (evAlarme.LocalName == (new CMaskedBy(EMaskedBy.Administrateur)).Libelle)
                            m_NbMaskAdm--;
                        else
                            m_NbMaskBrig--;
                    }


                    //MAJAdminButtonText();
                    //    MAJBrigButtonText();
                }
                else if (evAl is CEvenementAlarmAcknowledge)
                {
                    for (int i = 0; i < m_lstViewEnCours.Count; i++)
                    {
                        CInfoAlarmeAffichee infoAlarm = (CInfoAlarmeAffichee)m_lstViewEnCours[i];
                        if (infoAlarm != null && infoAlarm.IdSpvEvtAlarme == ((CEvenementAlarmAcknowledge)evAl).IdAlarmeAcquittee)
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

    }
}
