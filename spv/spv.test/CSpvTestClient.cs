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



namespace spv.test
{
    [TestFixture]
    public class CSpvTestClient
    {

        const string c_strClientNom = "NUNIT_CLIENT";
        const string c_strClientNom2 = "NUNIT_CLIENT2";
        const string c_strClientPrenom = "NUNINt_PRENOM";

      
        const string c_strcom = "ceci est un commentaire";


        private CContexteDonnee m_contexteDonnees = null;

        //-----------------------------------------
        [SetUp]
        public void Init()
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvTestApp.AssureInit();
            m_contexteDonnees = new CContexteDonnee(CSpvTestApp.SessionClient.IdSession, true, false);


          
            //insérer les tests ici

        }
        [Test]
        public void AssureTesterClient()
        {
            //Teste la création, la modification et la suppression des clients

            int nId = CreerClient("TEST_CLIENT_0", "PrpgglmmOMF");


            ModifierClient(nId, "TEST_CLIENT_00", "RRPrenom_E_MOD");


            SupprimerClient(nId);


            int nId1 = CreerClient("TEST_CLIENT_1", "prénom client 1");
            ModifierClientSansValider(nId1, "TEST_CLIENT_N_1", "NOUVCLIENT_1");
            int nId2 = DupliquerClient(nId1, "TEST_CLIENT_N_1_DUP");
            SupprimerClient(nId1);
            SupprimerClient(nId2);
            int nId3 = CreerClient("TEST_CLIENT_N2", "NUNIT_PRENOM1");
            int nId4 = DupliquerClient(nId3, "TEST_CLIENT_N2_DUP");
            SupprimerClient(nId3);
            SupprimerClient(nId4);


            int nID5 = CreerClient("TEST_CLIENT_N3", "NUPRENOM");
            ModifierClient(nID5, "TEST_CLIENT_ND", "NUPRENOM2");
            int nId6 = DupliquerClient(nID5, "TEST_CLIENT_N3D");
            ModifierClient(nId6,"NUNIT_CLIENT3C","NUNITCLIENT3C");
            SupprimerClient(nID5);
            SupprimerClient(nId6);

        }


        


        private int LireIdClient(string nom)
        {
            int id;
            Console.WriteLine("Lecture de l'id du client "+nom);
            CActeur client = new CActeur(m_contexteDonnees);
            CDonneesActeurClient donnees = new CDonneesActeurClient(m_contexteDonnees);
            if(client.ReadIfExists(new CFiltreData(CActeur.c_champNom+"=@1",
                nom)))
            {

             

                id = client.Id;
                return id;
            }

            Console.WriteLine("vérification du nom du client");
            Assert.IsTrue(client.Nom == nom);
            return -1;


        }


        


        private int CreerClient(string nom, string prenom)
        {

            //créer un client
            CActeur client = new CActeur(m_contexteDonnees);
            Console.WriteLine("Création du client "+nom+" "+prenom);
            CDonneesActeurClient donneesClient = new CDonneesActeurClient(m_contexteDonnees);



            if (!client.ReadIfExists(new CFiltreData(CActeur.c_champNom + "=@1 AND "+CActeur.c_champPrenom + "=@2",nom,prenom)))                
            {
                client.CreateNewInCurrentContexte();
                client.Nom = nom;
                client.Prenom = prenom;
                donneesClient.CreateNewInCurrentContexte();
                donneesClient.Acteur = client;

            }
            else
            {
                Console.WriteLine("le client existe déjà");

                donneesClient = (CDonneesActeurClient)client.DonneesClient[0];
                client.Nom = "";
                client.Nom = nom;

            }


            CResultAErreur result = CResultAErreur.True;

            result = client.VerifieDonnees(false);
            Console.WriteLine("vérification des donnéees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            result= m_contexteDonnees.SaveAll(true);
            
            Console.WriteLine("enregistrement du client");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            System.Threading.Thread.Sleep(500);
            int nId = donneesClient.Id;


            CSpvClient spvClient = new CSpvClient(m_contexteDonnees);
            Console.WriteLine("vérification de la création du client");
            Assert.IsTrue(spvClient.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", nId)));

            


            string nomclient = prenom + " " + nom;
            Console.WriteLine ("Vérification du nom du client");            
            Assert.IsTrue(spvClient.CLIENT_NOM == nomclient);


            return client.Id;






        }


        private void ModifierClient(int id, string newNom, string newPrenom)
        {


           
            CActeur client = new CActeur(m_contexteDonnees);
            Console.WriteLine("Modification du client");
            CDonneesActeurClient donnees = new CDonneesActeurClient(m_contexteDonnees);
            if (client.ReadIfExists(id))
            {
                bool bDonnees= donnees.ReadIfExists(new CFiltreDataAvance(CDonneesActeurClient.c_nomTable, CActeur.c_nomTable + "." + CActeur.c_champId + "=@1", id));

                donnees.Acteur = client;             
                client.Nom = newNom;
                client.Prenom = newPrenom;


              
            }
             CResultAErreur result = CResultAErreur.True;
            

            result = client.VerifieDonnees(false);
            Console.WriteLine("vérification des donnéees");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);
            
            Console.WriteLine("enregistrement du client");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);



        
           
            CSpvClient clientSpv   = new CSpvClient(m_contexteDonnees);
             
            
            Console.WriteLine ("Lecture du client SPV");            
            
            Assert.IsTrue(clientSpv.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", donnees.Id)));
 
            string nomclient = newPrenom + " " + newNom;
            Console.WriteLine ("Vérification du nom du client");            
            Assert.IsTrue(clientSpv.CLIENT_NOM == nomclient);
            

           
        }

        private void ModifierClientSansValider(int id, string newNom, string newPrenom)
        {
            CActeur client = new CActeur(m_contexteDonnees);

            Console.WriteLine("Modification du nom du client sans valider");
            CDonneesActeurClient donnees = new CDonneesActeurClient(m_contexteDonnees);
            string oldnom;
            string oldprenom;
            Assert.IsTrue(client.ReadIfExists(id));
            
                oldnom = client.Nom;
                oldprenom = client.Prenom;


                client.Nom = newNom;
                client.Prenom = newPrenom;

                donnees = (CDonneesActeurClient)client.DonneesClient[0];
            

            CSpvClient clientSpv = new CSpvClient(m_contexteDonnees);
            
            Assert.IsTrue(clientSpv.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", donnees.Id)));

               string nomclient = oldprenom + " " + oldnom;
            Console.WriteLine ("Vérification du nom du client");            
            Assert.IsTrue(clientSpv.CLIENT_NOM == nomclient);
        }


        private void SupprimerClient(int id)
        {

            Console.WriteLine("suppression d'un client");
            CActeur client = new CActeur(m_contexteDonnees);
            CDonneesActeurClient donnees = new CDonneesActeurClient(m_contexteDonnees);
            CSpvClient clientSpv = new CSpvClient(m_contexteDonnees);
            CResultAErreur result;
            Console.WriteLine("Lecture du client");
            Assert.IsTrue(client.ReadIfExists(id));
            donnees = client.Client;
            int nIdClient = donnees.Id;
            
           Console.WriteLine("lecture du client SPV");
           Assert.IsTrue(clientSpv.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1",
                    nIdClient)));
            result = client.Delete();
             Console.WriteLine("suppression du client");
            Assert.IsTrue(result.Result);
        

     
           
            CSpvClient clientSpvTest   = new CSpvClient(m_contexteDonnees);
             
            
            Console.WriteLine ("vérification de la suppression");   
            
            Assert.IsFalse(clientSpvTest.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", nIdClient)));
         


                
         }


        private int DupliquerClient(int id, string nomDup)
        {
            CActeur client = new CActeur(m_contexteDonnees);

            Console.WriteLine("duplication d'un client");
            Console.WriteLine("lecture du client original");
            CActeur clientLibelle = new CActeur(m_contexteDonnees);
            if (!clientLibelle.ReadIfExists(new CFiltreData(CActeur.c_champNom + "=@1", nomDup)))
            {

                Assert.IsTrue(client.ReadIfExists(id));

                CActeur client2 = new CActeur(m_contexteDonnees);
                CDonneesActeurClient donnees2 = new CDonneesActeurClient(m_contexteDonnees);
                client2.CreateNewInCurrentContexte();

                donnees2.CreateNewInCurrentContexte();
                client2.Nom = nomDup;
                client2.Prenom = client.Prenom;
                donnees2.Acteur = client2;


                Console.WriteLine("enregistrement du client");
                CResultAErreur result = m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);


                int nid2 = client2.Id;

                CSpvClient spvClient = new CSpvClient(m_contexteDonnees);
                Console.WriteLine("vérification de la création du client");
                Assert.IsTrue(spvClient.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", donnees2.Id)));


                string nomclient = client.Prenom + " " + nomDup;
                Console.WriteLine("Vérification du nom du client");
                Assert.IsTrue(spvClient.CLIENT_NOM == nomclient);

                return nid2;
            }
            else
            {
                Console.WriteLine("un client avec ce nom existe déjà");
                return id;

            }


        }


       



    }
}
