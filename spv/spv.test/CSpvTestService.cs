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
using timos.acteurs;
using sc2i.multitiers.client;


using spv.data;


namespace spv.test
{
    [TestFixture]
    public class CSpvTestService
    {
        private CContexteDonnee m_contexteDonnees = null;

        //-----------------------------------------
        [SetUp]
        public void Init()
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvTestApp.AssureInit();
            m_contexteDonnees = new CContexteDonnee(CSpvTestApp.SessionClient.IdSession, true, true);


            AssureTestService();


        }


        [Test]
        public void AssureTestService()
        {
            int nIdclient=CreerClient("CLIENT_TEST" ,"TEST SERVICE");

            int nIdSpvClient = LireIdSpvClient("CLIENT_TEST","TEST SERVICE");

           

        }


        private int LireIdSpvClient(string nom, string prenom)
        {
            string nomCompletActeur = prenom + " " + nom;

            CSpvClient client = new CSpvClient(m_contexteDonnees);

            Assert.IsTrue(client.ReadIfExists(new CFiltreData(CSpvClient.c_champCLIENT_NOM + "=@1", nomCompletActeur)));

            return client.Id;


        }


        private int CreerClient(string nom, string prenom)
        {

            //créer un client
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
                Console.WriteLine("le client existe déjà");

                return client.Id;

            }

            
            CResultAErreur result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            //Assert.IsTrue(result.Result);

            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            int nId = donneesClient.Id;


            CSpvClient spvClient = new CSpvClient(m_contexteDonnees);

            Assert.IsTrue(spvClient.ReadIfExists(new CFiltreData(CSpvClient.c_champSmtClient_Id + "=@1", nId)));



            Console.WriteLine(spvClient.CLIENT_NOM);


            return nId;






        }

    }

}

