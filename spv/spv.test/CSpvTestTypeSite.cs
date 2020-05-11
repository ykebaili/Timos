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
using spv.data;





namespace spv.test
{
    [TestFixture]
    public class CSpvTestTypeSite
    {
        
        const string c_strTypeSite = "TEST_T_TYPSITE_A";
        const string c_strTypeSite2 = "TEST_T_TYPSITE_B";
 
       


        private CContexteDonnee m_contexteDonnees = null;

        //-----------------------------------------
        [SetUp]
        public void Init()
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvTestApp.AssureInit();
            m_contexteDonnees = new CContexteDonnee(CSpvTestApp.SessionClient.IdSession, true, false);



    


        }

        [Test]
        public void AssureTestTypesSites()
        {


            //Test de la création, de la duplication, de la modification 
            //et de la suppression des types de sites.
            int id;

            id = AssureCreerTypeSite("TEST_T_TYPSITE_A0");




              id=AssureLireIdTypeSite("TEST_T_TYPSITE_A0");
              AssureModifierTypeSiteSansValider(id, "TEST_T_TYPSITE_Mod00");
              AssureModifierTypeSite(id, "TEST_T_TYPSITE_AA0");
              int id2=AssureDupliquerTypeSite(id);
              AssureSupprimerTypeSite(id2);
              int id3 = AssureCreerTypeSite("TEST_T_TYPSITE_AA");
              int id4 = AssureDupliquerTypeSite(id3);
              AssureSupprimerTypeSite(id3);
              AssureSupprimerTypeSite(id4);
              int id5 = AssureCreerTypeSite("TEST_T_TYPSITE_AB");
              AssureModifierTypeSite(id5, "TEST_T_TYPSITE_AB_modifié");
              int id6 = AssureDupliquerTypeSite(id5);
              AssureModifierTypeSite(id6, "TEST_T_TYPESITE_AB modifié après copie");
              AssureSupprimerTypeSite(id6);
              AssureSupprimerTypeSite(id5);
              AssureSupprimerTypeSite(id);
              

        }

        


       


        private int AssureCreerTypeSite(string libelle)
        {


            //créer un type de site
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("création du type de site "+libelle);
            if (!typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                libelle)))
            {
                typeSite.CreateNewInCurrentContexte();
                typeSite.Libelle = libelle;
                typeSite.Commentaire = "commentaire";
            }


            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des données");
            result = typeSite.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
           int id = typeSite.Id;

           CSpvTypsite test = new CSpvTypsite(m_contexteDonnees);
           Console.WriteLine("vérification de la création du type SPV");
           Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1",id)));
           Console.WriteLine("vérification du libellé");
           Assert.IsTrue(test.TypeSiteNom==libelle);
           Console.WriteLine("vérification du ClassId");
           Assert.IsTrue(test.TypeSiteClassId == 1053);

           return id;
           
              
            

        


        }


        private int AssureLireIdTypeSite(string libelle)
        {
            
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("lecture de l'id d'un type de site");
            Assert.IsTrue(typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                  libelle)));
            

                return typeSite.Id;
               
           
            
        }



        private void AssureModifierTypeSite(int id, string newlibelle)
        {

            CTypeSite typeLibelle = new CTypeSite(m_contexteDonnees);
            if (!typeLibelle.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1", newlibelle)))
            {
                CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
                Console.WriteLine("modification d'un type de site");
                Assert.IsTrue(typeSite.ReadIfExists(id));

                typeSite.Libelle = newlibelle;
                Console.WriteLine("enregistrement du type de site");

                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("vérification des données");
                result = typeSite.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);

                Console.WriteLine("lecture du type SPV");
                CSpvTypsite spvTypeSite = new CSpvTypsite(m_contexteDonnees);
                Assert.IsTrue(spvTypeSite.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", id)));
                Console.WriteLine("vérification du libellé");
                Assert.IsTrue(spvTypeSite.TypeSiteNom == newlibelle);

            }
            else
                Console.WriteLine("Un type de site avec ce libellé existe déjà");
        }


        private void AssureModifierTypeSiteSansValider(int id, string newlibelle)
        {
            CTypeSite typeLibelle = new CTypeSite(m_contexteDonnees);
            if (!typeLibelle.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1", newlibelle)))
            {

                string oldlibelle;
                Console.WriteLine("Modification d'un type de site sans valider");
                CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
                Console.WriteLine("lecture du type de site");
                Assert.IsTrue(typeSite.ReadIfExists(id));

                oldlibelle = typeSite.Libelle;
                typeSite.Libelle = newlibelle;





                CSpvTypsite spvTypeSite = new CSpvTypsite(m_contexteDonnees);
                Console.WriteLine("lecture du type SPV");
                Assert.IsTrue(spvTypeSite.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", id)));
                Console.WriteLine("vérification du libellé");
                Assert.IsTrue(spvTypeSite.TypeSiteNom == oldlibelle);
            }
            else
                Console.WriteLine("Un type de site avec ce libellé existe déjà");
            
        }
        
        

        //dupliquer un type de site
        private int AssureDupliquerTypeSite(string libelle)
        {
           

            Console.WriteLine("duplication d'un type de suite");
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("lecture du type de site original");
            Assert.IsTrue(typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                  libelle)));
          

            string libelleDuplique = typeSite.Libelle + "dup";

            CTypeSite typeSite2 = new CTypeSite(m_contexteDonnees);
            if(!typeSite2.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1", libelleDuplique)))
            {
 
                typeSite2.CreateNewInCurrentContexte();
                typeSite2.Libelle = libelleDuplique;
                
            }

                Console.WriteLine("sauvagerde du type de site");
                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("vérification des données");
                result = typeSite2.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);


                Console.WriteLine("vérification du type de site dupliqué");
                CSpvTypsite test = new CSpvTypsite(m_contexteDonnees);
                Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvTypsite.c_champTYPSITE_NOM + "=@1",
                    libelleDuplique)));

                return typeSite2.Id;
           
                
        }

        private int AssureDupliquerTypeSite(int id)
        {
            
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("duplication d'un type de site");
            Console.WriteLine("lecture du type original");
            Assert.IsTrue(typeSite.ReadIfExists(id));
            
            string libelleDuplique = typeSite.Libelle + "dup";

            CTypeSite typeSite2 = new CTypeSite(m_contexteDonnees);
            if(!typeSite2.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1", libelleDuplique)))
            {
 
                typeSite2.CreateNewInCurrentContexte();
                typeSite2.Libelle = libelleDuplique;
                
            }

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des données");
            result = typeSite2.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            CSpvTypsite test = new CSpvTypsite(m_contexteDonnees);
            Console.WriteLine("lecture du type dupliqué");
             Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvTypsite.c_champTYPSITE_NOM + "=@1",
                    libelleDuplique)));


                return typeSite2.Id;
            
        }


       


        //supprimer un type de site
        private void AssureSupprimerTypeSite(string libelle)
        {

            Console.WriteLine("suppression d'un type de site");
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            CSpvTypsite typeSiteSpv = new CSpvTypsite(m_contexteDonnees);
            CResultAErreur result= CResultAErreur.True;


            if (typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                libelle)))
            {

                typeSiteSpv.ReadIfExists(new CFiltreData(CSpvTypsite.c_champTYPSITE_NOM+ "=@1",
                    libelle));


                Console.WriteLine("suppression du type de site");
                result = typeSite.Delete();


                Assert.IsTrue(result.Result);
            }
          /*  Console.WriteLine("Enregistrement de la suppression");
            Assert.IsTrue(m_contexteDonnees.SaveAll(true));

            System.Threading.Thread.Sleep(500);*/

            
            CSpvTypsite typespvtest = new CSpvTypsite(m_contexteDonnees);
            Console.WriteLine("vérification de la suppression");
            Assert.IsFalse(typespvtest.ReadIfExists(new CFiltreData(CSpvTypsite.c_champTYPSITE_NOM+ "=@1",
                    libelle)));

            

        }

        //supprimer un type de site
        private void AssureSupprimerTypeSite(int id)
        {
            Console.WriteLine("suppression d'un type de site");
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            CSpvTypsite typeSiteSpv = new CSpvTypsite(m_contexteDonnees);

            CResultAErreur result = CResultAErreur.True;
            if (typeSite.ReadIfExists(id))               
            {

                typeSiteSpv.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1",
                    id));

                Console.WriteLine("suppression du type de site");
                result = typeSite.Delete();
            }
        
            CSpvTypsite typespvtest = new CSpvTypsite(m_contexteDonnees);

            Console.WriteLine("vérification de la suppression");
            Assert.IsFalse(typespvtest.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1",
                  id)));
           



        }
        

     


   



    }
}
