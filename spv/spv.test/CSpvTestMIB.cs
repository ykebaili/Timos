using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using sc2i.data;
using timos.data;
using timos.client;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.documents;
using sc2i.multitiers.client;
using spv.data;





namespace spv.test
{
    [TestFixture]
    public class CSpvTestMib
    {
        
        const string c_strRepertoireMibRfc = "C:\\Partage\\Mibs\\RFC\\"; 
        const string c_strRepertoireMibEkinops = "C:\\Partage\\Mibs\\ekinops\\";

         
       
      


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
        public void AssureCreerMib()
        {
            //Teste la création et la compliation d'un module MIB
            //Crée le module MIB correspondant au fichier MIB ekinops et compile la MIB
            //supprime le module MIB
            //Essaie de compiler un fichier MIB comportant des erreur et vérifie que la compilation retourne une erreur

            string nomFich = c_strRepertoireMibEkinops + "ekinops.mib";


            string nomFichErreur = c_strRepertoireMibEkinops + "erreur.mib";

            string nomFichIFMib = c_strRepertoireMibRfc + "IF-MIB.txt";

            int nIdFamilleMiB = CreerFamilleMib("TEST_MIB_FAMILLEMIB");


           
            int nMibModule = CreerMibModule(nIdFamilleMiB,"NUNIT_MODULE_049", "IF-MIB",nomFichIFMib);

           ModifierMibModule(nMibModule, "EKINOPS-MIB", "EKINOPS-MIB", nomFich);

           ModifierMibModule(nMibModule, "NUNIT_MODULE_TEST2", "ekinops", nomFich);

            InsérerMibEnGed(nMibModule);

        

           CompilerModuleMib(nMibModule);

           


            SupprimerMibModule(nMibModule);


            int nIdModuleErreur = CreerMibModule(nIdFamilleMiB,"ERREUR-MIB","ERREUR-MIB",nomFichErreur);

           CompilerModuleMibAvecErreur(nIdModuleErreur);


           SupprimerMibModule(nIdModuleErreur);


           SupprimerFamilleMib(nIdFamilleMiB);

          
        }



        [Test]
        public void AssureLireVariablesMib()
        {

            //Compile le fichier MIB IF-MIB et lit les variables qui se trouvent 
            //dans ce fichier
            //vérifie que l'on peut lire les tables, les variables et les traps


            string nomFichIFMib = c_strRepertoireMibRfc + "IF-MIB.txt";

            int nIdFamilleMiB = CreerFamilleMib("TEST_MIB_FAMILLEMIB");


            int nMibModule = CreerMibModule(nIdFamilleMiB, "IF-MIB", "IF-MIB", nomFichIFMib);
          

            InsérerMibEnGed(nMibModule);



            CompilerModuleMib(nMibModule);



            LireMibTables(nMibModule);
            LireMibVariables(nMibModule);
            LireMibTraps(nMibModule);

           


        }


        public int CreerMibModule(int familleId,string nomUtil,string nomOfficiel,string nomfichiermib)
        {

            CSpvFamilleMibmodule famille = new CSpvFamilleMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture de la famille de modules MIB");
            Assert.IsTrue(famille.ReadIfExists(familleId));

          CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);



          Console.WriteLine("création d'un module MIB");
          if (!module.ReadIfExists(new CFiltreData(CSpvMibmodule.c_champMIBMODULE_NOM + "=@1", nomUtil)))
          {
              module.CreateNewInCurrentContexte();
            /*  module.NomModuleUtilisateur = nomUtil;
              module.FichierModule = nomfichiermib;
              module.NomModuleOfficiel = nomOfficiel;
              module.FamilleMere = famille;*/

          }
          else
              Console.WriteLine("le module MIB à créer existe déjà");

          module.NomModuleUtilisateur = nomUtil;
          module.FichierModule = nomfichiermib;
          module.NomModuleOfficiel = nomOfficiel;
          module.FamilleMere = famille;

          Console.WriteLine("enregistremnt du module MIB");
          CResultAErreur result = CResultAErreur.True;
          Console.WriteLine("vérification des donnéees");
          result = module.VerifieDonnees(false);
          if (!result)
              System.Console.WriteLine(result.MessageErreur);
          Assert.IsTrue(result.Result);

          Console.WriteLine("enregistrement des donnéées");
          m_contexteDonnees.SaveAll(true);
          if (!result)
              System.Console.WriteLine(result.MessageErreur);

          Assert.IsTrue(result.Result);


           CSpvMibmodule mibtest = new CSpvMibmodule(m_contexteDonnees);

           Console.WriteLine("vérification de la création du module MIB");
           Assert.IsTrue(mibtest.ReadIfExists(new CFiltreData(CSpvMibmodule.c_champMIBMODULE_ID + "=@1", module.Id)));
            Console.WriteLine("vérification du nom utilisateur");
            Assert.IsTrue(mibtest.NomModuleUtilisateur == nomUtil);
             
             Console.WriteLine("vérification du nom du fichier");
             Assert.IsTrue(mibtest.FichierModule == nomfichiermib);
                      


           return module.Id;
        }

        public int CreerFamilleMib(string libelle)
        {

            Console.WriteLine("créationn d'une famille de module MIB");

            CSpvFamilleMibmodule famille = new CSpvFamilleMibmodule(m_contexteDonnees);
            if(!famille.ReadIfExists(new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_NOM +"=@1",libelle)))
            {

                famille.CreateNewInCurrentContexte();
                famille.Libelle = libelle;
            }
            Console.WriteLine("enregistremnt de la famille MIB");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
            result = famille.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnéées");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);


            Console.WriteLine("vérification de la création de la famille");
            CSpvFamilleMibmodule familleTest = new CSpvFamilleMibmodule(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(new CFiltreData(CSpvFamilleMibmodule.c_champFAMILLE_NOM + "=@1", libelle)));

            return famille.Id;

        }

        public void SupprimerFamilleMib(int nIdFamilleMib)
        {
            Console.WriteLine("suppression d'une famille MIB");
            CSpvFamilleMibmodule famille = new CSpvFamilleMibmodule(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(nIdFamilleMib));


            CResultAErreur result = CResultAErreur.True;

            result = famille.Delete();

            Console.WriteLine("Suppression de la famille de MIB");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            CSpvFamilleMibmodule test = new CSpvFamilleMibmodule(m_contexteDonnees);
            Console.WriteLine("vérification de la suppression");

            Assert.IsFalse(famille.ReadIfExists(nIdFamilleMib));



        }
        public void InsérerMibEnGed(int nModuleId)
        {


            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("Lecture du module MIB");
            Assert.IsTrue(module.ReadIfExists(nModuleId));
            CResultAErreur result = CResultAErreur.True;

            if (File.Exists(module.FichierModule))
            {

                Console.WriteLine("le fichier existe");
               
                CDocumentGED doc = module.DocumentGEDModuleMib;
                CProxyGED proxy = new CProxyGED(m_contexteDonnees.IdSession,
                    doc == null ? null : doc.ReferenceDoc);
                proxy.AttacheToLocal(module.FichierModule);
                result = proxy.UpdateGed();
                if (result)
                {
                    if (doc == null)
                    {
                        Console.WriteLine("doc null :création d'un nouveau document GED");
                        doc = new CDocumentGED(m_contexteDonnees);
                        doc.CreateNewInCurrentContexte();
                        doc.Descriptif = "";
                        doc.DateCreation = DateTime.Now;
                      

                        doc.Libelle = "MIB file " + module.NomModuleUtilisateur;
                        doc.ReferenceDoc = (CReferenceDocument)result.Data;
                        doc.DateMAJ = DateTime.Now;
                        doc.NumVersion++;
                        doc.IsFichierSysteme = true;
                        module.DocumentGEDModuleMib = doc;

                      
                      
                    }
                }


           
                Console.WriteLine("vérification des donnéees");
                result = module.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnéées");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);
                                         

                int nDocId = doc.Id;
                
                CDocumentGED doctest = new CDocumentGED(m_contexteDonnees);
               Console.WriteLine("lecture du document GED");
                Assert.IsTrue(doctest.ReadIfExists(nDocId));
                
               Console.WriteLine(doctest.Id);
                Console.WriteLine(doctest.Libelle);
                


            }


        }
    


        public void CompilerModuleMib(int nModuleId)
        {

            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);

            Console.WriteLine("lecture du module MIB");
                       
            Assert.IsTrue(module.ReadIfExists(nModuleId));

            System.Console.WriteLine(module.FichierModule);
            System.Console.WriteLine(module.NomModuleOfficiel);
            System.Console.WriteLine(module.NomModuleUtilisateur);


            Console.WriteLine("compliation du module MIB");

            CResultAErreur result = module.Compile();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            if (result == CResultAErreur.True)
                System.Console.WriteLine("compilation du module MIB réussie");
            Assert.IsTrue(result.Result);

            




        }



        public void CompilerModuleMibAvecErreur(int nModuleId)
        {

            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(module.ReadIfExists(nModuleId));
            Console.WriteLine("compliation du module MIB avec erreur");

            CResultAErreur result = module.Compile();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsFalse(result.Result);




        }

        [Test]
        public void AssureTestTypeEquipementMIB()
        {

            //Teste la recherche automatique de l'OID d'une vaiable 

            // affecte la MIB "RFC-1213" à un type d'équipemnt 
            //et recherche l'OID de la variable "sysName" dans la MIB.


            Console.WriteLine("teste la recherche automatique de l'OID dans une MIB");
            
            string nomMIB = "RFC1213MIB.txt";

            string nomFichIFMib = c_strRepertoireMibRfc + nomMIB;

            int nIdFamilleMib = CreerFamilleMib("TEST_MIB_FAMILLE1");

            int nMibModule = CreerMibModule(nIdFamilleMib,"RFC1213-MIB", "RFC1213-MIB", nomFichIFMib);

            InsérerMibEnGed(nMibModule);

            CompilerModuleMib(nMibModule);


            int nFamilleId = CreerFamille("TEST_MIB_FAMILLE");
            int nTypeqId = CreerTypeEquipement("TEST_MIB_TYPEQ", nFamilleId);


            int nModuleMibId = LireIdMibModule("RFC1213-MIB");

            AffecterMibmodule(nTypeqId, nModuleMibId);

            ModifierIdentNom(nTypeqId, "sysName");
            ModifierMIBAuto(nTypeqId, true);

            AfficherIdentMibAuto(nTypeqId);

            

            Console.WriteLine("Fin du test de  MIB");
        }





        public void ModifierMibModule(int nId,string nomUtil, string nomOfficiel, string nomfichiermib)
        {
            //Modifie les champs d'un objet "Module MIB"

            CSpvMibmodule moduleLibelle = new CSpvMibmodule(m_contexteDonnees);
            if (!moduleLibelle.ReadIfExists(new CFiltreData(CSpvMibmodule.c_champMIBMODULE_NOM + "=@1", nomUtil)))
            {
                Console.WriteLine("modification d'un module MIB");
                CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);

                if (module.ReadIfExists(nId))
                {

                    module.NomModuleUtilisateur = nomUtil;
                    module.FichierModule = nomfichiermib;
                    module.NomModuleOfficiel = nomOfficiel;


                    Console.WriteLine("enregistrement du module MIB");
                    CResultAErreur result = CResultAErreur.True;
                    Console.WriteLine("vérification des donnéees");
                    result = module.VerifieDonnees(false);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);
                    Assert.IsTrue(result.Result);

                    Console.WriteLine("enregistrement des donnéées");
                    m_contexteDonnees.SaveAll(true);
                    if (!result)
                        System.Console.WriteLine(result.MessageErreur);

                    Assert.IsTrue(result.Result);


                    CSpvMibmodule moduletest = new CSpvMibmodule(m_contexteDonnees);
                    Console.WriteLine("lecture du module MIB");
                    Assert.IsTrue(moduletest.ReadIfExists(nId));


                    Console.WriteLine("vérification du nom officiel");
                    Assert.IsTrue(moduletest.NomModuleOfficiel == nomOfficiel);
                    Console.WriteLine("vérification du nom utilisateur");
                    Assert.IsTrue(moduletest.NomModuleUtilisateur == nomUtil);
                    Console.WriteLine("vérification du nom du fichier MIB");
                    Assert.IsTrue(moduletest.FichierModule == nomfichiermib);




                }
                else

                    System.Console.WriteLine("le module n'existe pas");
            }
            else
                Console.WriteLine("un module avec ce nom existe déjà");
        }



        public void SupprimerMibModule(int nId)
        {
            Console.WriteLine("Suppression d'un module MIB");
            CResultAErreur result = CResultAErreur.True;
            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);

            if (module.ReadIfExists(nId))
            {

               result =  module.Delete();
               Console.WriteLine("suppression du module");
               if (!result)
                   System.Console.WriteLine(result.MessageErreur);
               Assert.IsTrue(result.Result);

           /*    Console.WriteLine("enregistrement de la suppression");
                result = m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);
                */

                Console.WriteLine("vérification de la suppression");
                CSpvMibmodule moduletest = new CSpvMibmodule(m_contexteDonnees);
                Assert.IsFalse(moduletest.ReadIfExists(nId));




            }
            else

                System.Console.WriteLine("le module n'existe pas");
        }

        private int CreerFamille(string libelle)
        {

            Console.WriteLine("Création de la famille " + libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (!famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1", libelle)))
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = libelle;


            }

            else
                Console.WriteLine("la famille existe déjà");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
            result = famille.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnéées");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int id = famille.Id;

            CFamilleEquipement familletest = new CFamilleEquipement(m_contexteDonnees);
            Console.WriteLine("Vérification de l'existence de la famille");
            Assert.IsTrue(familletest.ReadIfExists(id));

            return famille.Id;

        }


      

        private void ModifierIdentNom(int nId, string newIdentNom)
        {

            Console.WriteLine("modification du champ Nom Identifiant SNMP d'un type équipement");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);

            Console.WriteLine("lecture du type d'équipemnt");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            typeqSpv.NomIdentifiantSnmp = newIdentNom;



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
            result = typeqSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnéées");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            CSpvTypeq typeTest = new CSpvTypeq(m_contexteDonnees);
            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("vérification de la valeur du champ Nom Identifiant SNMP");
            Assert.IsTrue(typeTest.NomIdentifiantSnmp == newIdentNom);


        }
        private void ModifierMIBAuto(int nId, bool bNewMibAuto)
        {

            Console.WriteLine("modification du champ 'MIB auto");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'équipement");

            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));


            typeqSpv.ChercheOIDParMIB = bNewMibAuto;

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
            result = typeqSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnéées");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            if (bNewMibAuto == true)
                typeqSpv.MibAuto();




     
            Console.WriteLine("vérification des donnéees");
            result = typeqSpv.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnéées");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
    


            CSpvTypeq typeTest = new CSpvTypeq(m_contexteDonnees);

            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("vérification du champ 'MIB auto' ");

            Assert.IsTrue(typeTest.ChercheOIDParMIB == bNewMibAuto);


        }

        private int LireIdMibModule(string libelle)
        {
            //lit l'id d'un module MIB
            CSpvMibmodule mib = new CSpvMibmodule(m_contexteDonnees);

            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(mib.ReadIfExists(new CFiltreData(CSpvMibmodule.c_champMIBMODULE_NOM + "=@1", libelle)));


            return mib.Id;

        }
        private void AfficherIdentMibAuto(int nIdTypeq)
        {

            //affichage de l'identifient automatique en MIB
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);



            Console.WriteLine("Chargement du type d'équipement logique");
            Assert.IsTrue(typeq.ReadIfExists(nIdTypeq));


            Console.WriteLine("Chargement du type d'équipement SPV");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nIdTypeq)));





            Console.WriteLine(typeqSpv.NomIdentifiantSnmp);
            Console.WriteLine(typeqSpv.OIDIdentifiantSnmp);
            Console.WriteLine(typeqSpv.ValeurIdentifiantSnmp);


            Console.WriteLine("test effectué");
        }

        private void VerifierValeurOID(int nIdTypeq, string strOID)
        {
            Console.WriteLine("Chargement du type d'équipement SPV");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nIdTypeq)));


            Assert.IsTrue(typeqSpv.OIDIdentifiantSnmp == strOID);

        }
       


        private void AffecterMibmodule(int typeqId, int moduleId)
        {


            Console.WriteLine("Affectation d'un module MIB à un type d'équipemnt");
            CSpvMibmodule mib = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(mib.ReadIfExists(new CFiltreData(CSpvMibmodule.c_champMIBMODULE_ID + "=@1", moduleId)));



            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeqId)));

            int nSpvTypeqId = typeq.Id;

            CSpvTypeq_Mibmodule typeqMib = new CSpvTypeq_Mibmodule(m_contexteDonnees);

            CFiltreData filtre = new CFiltreData(CSpvTypeq_Mibmodule.c_champMIBMODULE_ID + "=@1", moduleId);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeq_Mibmodule.c_champTYPEQ_ID + "=@1", nSpvTypeqId));

            if (!typeqMib.ReadIfExists(filtre))
            {
                typeqMib.CreateNewInCurrentContexte(new object[] { nSpvTypeqId, moduleId });





            }

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
            result =typeqMib.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("des donneest");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



           



            CSpvTypeq typeq_test = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeq_test.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id+"=@1",typeqId)));
            bool bFind = false;
            foreach (CSpvTypeq_Mibmodule module in typeq_test.TypeqModulesMIB)
            {
                if (module.SpvMibmodule.Id == moduleId)
                    bFind = true;



            }

            Assert.IsTrue(bFind);




        }
        private int CreerTypeEquipement(string libelle, int nFamilleId)
        {

            Console.WriteLine("création du type d'équipement " + libelle);

            Console.WriteLine("Lecture de la famille de types");
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
                Console.WriteLine("le type d'équipement existe déjà");



            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("vérification des donnéees");
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
            Console.WriteLine("Lecture du type d'équipement SPV");
            typeqTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeq.Id));

            Console.WriteLine("vérification du libellé");
            Assert.IsTrue(typeqTest.Libelle == typeq.Libelle);
            Console.WriteLine("Vérification du class_id");
            Assert.IsTrue(typeqTest.TYPEQ_CLASSID == 1024);




            return typeq.Id;
        }



        private int CreerTypeEquipement(string libelle, int nFamilleId, EGenreCommutateur TypeqCommut, string RefSnmp,
            bool bTosurv, string commut_oid, string typeq_identOID, string typeq_identvaleur, string typeq_identnom, bool bMibauto)
        {

            Console.WriteLine("Création du type d'équipement " + libelle);

            Console.WriteLine("Lecture de la famille de types");
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Assert.IsTrue(famille.ReadIfExists(nFamilleId));

            CResultAErreur result = CResultAErreur.True;
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            if (!typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", libelle)))
            {
                typeq.CreateNewInCurrentContexte();
                typeq.Libelle = libelle;
                typeq.Famille = famille;



               

            }
            else
                Console.WriteLine("le type d'équipement existe déjà");


   
            Console.WriteLine("vérification des donnéees");
            result = typeq.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("des donneest");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            int nId = typeq.Id;


            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("Chargement du type SPV");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typeq.Id)));

            Console.WriteLine("vérification du libellé");
            Assert.IsTrue(typeqSpv.Libelle == typeq.Libelle);
            Console.WriteLine("vérification du CLASS_ID");
            Assert.IsTrue(typeqSpv.TYPEQ_CLASSID == 1024);


            typeqSpv.TypeCommutateur = TypeqCommut;
            typeqSpv.ASurveiller = bTosurv;
            typeqSpv.ReferenceSnmp = RefSnmp;
            typeqSpv.OIDCommutateur = commut_oid;
            typeqSpv.OIDIdentifiantSnmp = typeq_identOID;
            typeqSpv.NomIdentifiantSnmp = typeq_identnom;
            typeqSpv.ChercheOIDParMIB = bMibauto;



            if (typeqSpv.ChercheOIDParMIB)
            {
                Console.WriteLine(typeqSpv.OIDIdentifiantSnmp);

            }
            //typeqSpv.OIDIdentifiantSnmp=typeq_oid;



            Console.WriteLine("mise à jour des champs SPV");


          
            Console.WriteLine("vérification des donnéees");
            result = typeq.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("des donneest");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            Console.WriteLine("lecture du type SPV");


            CSpvTypeq typeqTest = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeqTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            Console.WriteLine("vérification du  champ 'type commutateur'");
            Assert.IsTrue(typeqTest.TypeCommutateur == TypeqCommut);
            Console.WriteLine("vérification du  champ 'A surveiller'");
            Assert.IsTrue(typeqTest.ASurveiller == bTosurv);
            Console.WriteLine("vérification du  champ 'Ref SNMP'");
            Assert.IsTrue(typeqTest.ReferenceSnmp == RefSnmp);
            Console.WriteLine("vérification du  champ 'OID commutateur'");
            Assert.IsTrue(typeqTest.OIDCommutateur == commut_oid);
            Console.WriteLine("vérification du  champ 'OID identifiant'");
            Assert.IsTrue(typeqTest.OIDIdentifiantSnmp == typeq_identOID);
            Console.WriteLine("vérification du  champ 'Nom identifiant");
            Assert.IsTrue(typeqTest.NomIdentifiantSnmp == typeq_identnom);
            Console.WriteLine("vérification du  champ 'MIB auto'");
            Assert.IsTrue(typeqTest.ChercheOIDParMIB == bMibauto);



            if (typeqSpv.ChercheOIDParMIB)
            {
                Console.WriteLine(typeqSpv.OIDIdentifiantSnmp);

            }


            return typeq.Id;
        }


        private void LireMibTables(int nIdModule)
        {
            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(module.ReadIfExists(nIdModule));
            foreach (CSpvMibTable table in module.Tables)
            {
                Console.WriteLine(table.NomObjetUtilisateur);
                foreach (CSpvMibVariable variable in table.Variables)
                    Console.WriteLine(variable.NomObjetUtilisateur);

            }



        }

        private void LireMibVariables(int nIdModule)
        {
            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(module.ReadIfExists(nIdModule));
            foreach (CSpvMibVariable variable in module.VariablesScalaires)
            {
                Console.WriteLine(variable.NomObjetUtilisateur);


            }



        }


        private void LireMibTraps(int nIdModule)
        {
            CSpvMibmodule module = new CSpvMibmodule(m_contexteDonnees);
            Console.WriteLine("lecture du module MIB");
            Assert.IsTrue(module.ReadIfExists(nIdModule));
            foreach (CSpvMibTrap trap in module.Traps)
            {
                Console.WriteLine(trap.NomObjetUtilisateur);


            }

        }





    }

}

