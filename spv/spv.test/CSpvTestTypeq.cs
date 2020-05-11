using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
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
    public class CSpvTestTypeq
    {


        const string c_strcom = "ceci est un commentaire";


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
        public void AssureTestEquip()
        {
            //Cr�e un type d'�quipement, un �quipement de ce type sur un site et
            //teste les modifications des champs commentaire, adresseIP, communaut�, �quipement
            //de m�diation, � surveiller et supprime les objets

            Console.WriteLine("");
            Console.WriteLine("test de l'�dition et de la modifcation d'un �quipment");


            
            int nIdFamille = CreerFamille("TEST_TE_40_FAMILLE");
            int nIdTypeq1 = CreerTypeEquipement("TEST_TE_40_TYPEQ1", nIdFamille);

            int nIdTypSite = CreerTypeSite("TEST_TE_40_TYPSITE");
            int nIdSite = CreerSite(nIdTypSite, "TEST_TE_40_SITE");

            int nIdEquip1 = CreerEquipement(nIdTypeq1, "TEST_TE_40_EQUIP1", nIdSite);

            ModifierEquipAddrip(nIdEquip1, "192.0.22.17");
            ModifierEquipCmnte(nIdEquip1, "private");
            ModifierEquipEmName(nIdEquip1, "futurocom18");


            ModifierEquipToSurv(nIdEquip1, true);


            ModifierEquipComment(nIdEquip1, "TEST_TE_40_EQUIP_MOD");

            ModifierEquipAddrip(nIdEquip1, "174.23.11.11");
            ModifierEquipCmnte(nIdEquip1, "public");
            ModifierEquipEmName(nIdEquip1, "futurocom26");

            ModifierEquipComment(nIdEquip1, "TEST_TE_40_EQUIP1");

            ModifierEquipToSurv(nIdEquip1, false);


            int nIdEquip2 = CreerEquipement(nIdTypeq1, "TEST_TE_40_EQUIP2", nIdSite);
            



            SupprimerEquipement(nIdEquip1);
            SupprimerEquipement(nIdEquip2);
           

            SupprimerTypeEquipement(nIdTypeq1);

            SupprimerFamille(nIdFamille);


            SupprimerSite(nIdSite);
            SupprimerTypeSite(nIdTypSite);



        }
        [Test]
        public void AssureTestTypeq()
        {



            //Test de la cr�ation , de la modification et de la suppression des types d'�quipements
            Console.WriteLine("");
            Console.WriteLine("Test de la cr�ation, de la modification et de la cr�ation d'un type d'�quipement");
            Console.WriteLine("");
            int nIdFamille = CreerFamille("TEST_TE0_FAMILLE");

            int nIdTypeq1 = CreerTypeEquipement("TEST_TE0_TYPEQ1",nIdFamille);
            int niIdTypeq2 = CreerTypeEquipement("TEST_TE0_012345678901234567890", nIdFamille, EGenreCommutateur.NotCommut, "public", true,
                ".1.3.6.2", "0123456789012345678901234567890123456789", "valeur6789012345678901234567890", "abcdefghijklmnopqrstuvwxyz", false);


           

            ModifierLibelle(niIdTypeq2, "TEST_TE0_TYPEQ1MOD");
        
            ModifierRefSnmp(niIdTypeq2,"ref snmp");
            ModifierToSurv(niIdTypeq2, true);



            SupprimerTypeEquipement(niIdTypeq2);
            SupprimerTypeEquipement(nIdTypeq1);


            Console.WriteLine("test termin�");
        }

            



        [Test]
        public void AssureTestCreationAccesAlarmeTypeq()
        {


            //Test de la cr�ation des types d'�quipement et des acces alarme associ�s au type d'�quipemnt.
            // Modification des champs d'un type d'�quipement
            // Cr�ation d'�quipement d'un type
            // Suppression des �quipements et des types d'�quipements


            Console.WriteLine("");
            Console.WriteLine("Test de la cr�ation d'un acc�s alarme associ� � un type d'�quipment");
            Console.WriteLine("");


            int nIdFamille = CreerFamille("TEST_TE2_FAMILLE");


            int nId = CreerTypeEquipement("TEST_TE2_TYPEQ1", nIdFamille, EGenreCommutateur.TwoToOne, "SysName", true, "1.3.6.1.2.4.2.1", "1.4.42", "futurocom18", "sysname", false);
            int nId2 = CreerTypeEquipement("TEST_TE2_TYPEQ2", nIdFamille, EGenreCommutateur.NotCommut, "", true, "", "", "", "SysDescr", false);
         
            int nidAcces1 = CreerTypeAccesAlarme(nId, "TEST_TE2_SORTIE", ECategorieAccesAlarme.SortieBoucle);
            int nidAcces2 = CreerTypeAccesAlarme(nId2, "TEST_TE2_TRAP", ECategorieAccesAlarme.TrapSnmp);
            int nidAcces3 = CreerTypeAccesAlarme(nId2, "TEST_TE2_ENTREE", ECategorieAccesAlarme.EntreeBoucle);

            ModifierToSurv(nId, true);


            ModifierLibelle(nId, "TEST_TE2_TYPEQ1M");





            SupprimerTypeAccesAlarme(nidAcces1);

            int nIdTypsite = CreerTypeSite("TEST_TE2_TYPSITE");

            int nIdSite = CreerSite(nIdTypsite,"TEST_TE2_SITE");

            int nidEquip = CreerEquipement(nId, "TEST_TE2_EQUIP1", nIdSite);

            int nidEquip2 = CreerEquipement(nId2, "TEST_TE2_EQUIP2", nIdSite);

            ModifierEquipComment(nidEquip, "TEST_TE2_EQUIP01");
            ModifierEquipToSurv(nidEquip2, true);


            ModifierEquipComment(nidEquip2, "TEST_TE2_EQUIP02");

            SupprimerEquipement(nId);

            ModifierNomAccesAlarme(nidAcces3, "ENTREE4");


            

            SupprimerEquipement(nId2);

            SupprimerTypeEquipement(nId2);
            SupprimerTypeEquipement(nId);
           
            SupprimerFamille(nIdFamille);


            Console.WriteLine("test termin�");
        }


      
        
        [Test]
        public void AssureCreerEquipementInclus()
        {
            //test de la cr�ation d'un type d'�quipement inclus dans un autre �quipement , 
            //cr�e un �quipement p�re et un �quipment fils et v�rifie que les champs 
            //3adresse IP" "communaut�" "EMName" sont transmis � l'�quipment fils


            Console.WriteLine("");
            Console.WriteLine("Test de l'inclusion d'un �quipement fils");
            Console.WriteLine("");

            int nIdTypeSite = CreerTypeSite("TEST_TE1_TYPSITE");
            int nIdSite = CreerSite(nIdTypeSite, "TEST_TE1_SITE");

            int nIdFamille = CreerFamille("TEST_TE1_FAMILLE");

            int nIdTypeqPere = CreerTypeEquipement("TEST_TE1_TYPE_PERE", nIdFamille);

            int nIdTypeFils = CreerTypeEquipementInclus(nIdTypeqPere, "TEST_TE1_TYPE_FILS", nIdFamille);

            int nIdEquipPere = CreerEquipement(nIdTypeqPere, "TEST_TE1_EQUIP_PERE", nIdSite);

            int nIdEquipFils = CreerEquipementInclus(nIdTypeFils, "TEST_TE1_EQUIP_FILS", nIdEquipPere, nIdSite);


            string addrip = "192.0.22.11";
            string cmnte = "private";
            string emname = "futurocom26";

            ModifierEquipAddrip(nIdEquipPere, addrip);
            ModifierEquipCmnte(nIdEquipPere, cmnte);
            ModifierEquipEmName(nIdEquipPere, emname);

            VerifierEquipementFils(nIdEquipFils, addrip, cmnte, emname);

            
            



            SupprimerEquipement(nIdEquipFils);
            SupprimerEquipement(nIdEquipPere);
            SupprimerTypeEquipement(nIdTypeFils);
            SupprimerTypeEquipement(nIdTypeqPere);




        }


        private void VerifierEquipementFils(int nIdFils, string addrIp, string cmnte, string emName)
        {
            Console.WriteLine("v�rification du transfert de donn�es � l'�quipement fils");
            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipemnt fils");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nIdFils)));
            Console.WriteLine("v�rification du champ 'Addresse IP' de l'�quipement fils");
            Assert.IsTrue(equipSpv.AdresseIP == addrIp);
            Console.WriteLine("v�rification du champ 'communaut�' de l'�quipement fils");
            Assert.IsTrue(equipSpv.CommunauteSnmp == cmnte);
            Console.WriteLine("v�rification du champ '�quipement de m�diation' de l'�quipement fils");
            Assert.IsTrue(equipSpv.AdresseIP == emName);



        }
        private void SupprimerEquipement(int Id)
        {

            //suppression d'un �quipement
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);


            Console.WriteLine("Chargement de l'�quipement logique");
            Assert.IsTrue(equip.ReadIfExists(Id));

            CSpvEquip equipSpv = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("Chargement de l'�quipement SPV");
            Assert.IsTrue(equipSpv.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", Id)));


            CResultAErreur result = equipSpv.Delete();

            result = equip.Delete();

            
            
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
         
            Assert.IsTrue(result.Result);


            CEquipementLogique equiptest = new CEquipementLogique(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression de l'�quipement logique");
            Assert.IsFalse(equiptest.ReadIfExists(Id));

            CSpvEquip spvtest = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression de l'�quipement SPV");
            Assert.IsFalse(spvtest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", Id)));



        }




        public int LireIdTypeSite(string libelle)
        {

            Console.WriteLine("Lecture du type de site "+ libelle);
            int id;
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            if (typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                  libelle)))
            {

                id = typeSite.Id;
                return id;
            }
            Console.WriteLine("V�rification du libell�");
            Assert.AreEqual(libelle, typeSite.Libelle);
            return -1;


        }


        public int LireIdSite(string libelle)
        {

            Console.WriteLine("Lecture du site "+libelle);
            CSite site = new CSite(m_contexteDonnees);
            if (site.ReadIfExists(new CFiltreData(CSite.c_champLibelle + "=@1",
                  libelle)))
            {

                return site.Id;
            }
            Console.WriteLine("V�rification du libell�");
            Assert.AreEqual(libelle, site.Libelle);
            return -1;


        }




        private int LireIdFamille(string libelle)
        {


            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Console.WriteLine("Lecture de la famille de types d'�quipements "+libelle);
            Assert.IsTrue((famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1", libelle))));


            return famille.Id;



        }


        private int CreerTypeEquipementInclus(int IdTypePere, string nomType, int familleId)
        {

            //Cr�ation d'un type d'�quipement inclus dans un autre
         
            Console.WriteLine("cr�ation du type d'�quipement inclus "+ nomType);

            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            Console.WriteLine("Chargement de la famille");
            Assert.IsTrue(famille.ReadIfExists(familleId));

            CTypeEquipement typePere = new CTypeEquipement(m_contexteDonnees);
            Console.WriteLine("Chargement du type parent");
            Assert.IsTrue(typePere.ReadIfExists(IdTypePere));

            CTypeEquipement typeFils = new CTypeEquipement(m_contexteDonnees);

            CResultAErreur result = CResultAErreur.True;

            if (!typeFils.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", nomType)))
            {

                typeFils.CreateNewInCurrentContexte();
                typeFils.Libelle = nomType;
                typeFils.Famille = famille;

                Console.WriteLine("Enregistrement du type fils");
              
                Console.WriteLine("v�rification des donn�es");
                result = typeFils.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);





            }
            int typefilsId = typeFils.Id;
            CRelationTypeEquipement_TypesIncluables relation = new CRelationTypeEquipement_TypesIncluables(m_contexteDonnees);
            CFiltreData filtre = new CFiltreData(CRelationTypeEquipement_TypesIncluables.c_champIdTypeIncluant + "=@1", IdTypePere);
            filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CRelationTypeEquipement_TypesIncluables.c_champIdTypeInclu + "=@1", typefilsId));


            if (!relation.ReadIfExists(filtre))
            {
                relation.CreateNewInCurrentContexte();
                relation.TypeIncluant = typePere;
                relation.TypeInclu = typeFils;


            }
            Console.WriteLine("Enregistrement de la relation d'inclusion");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            CSpvTypeq typeTest = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("Leture du type fils");
            Assert.IsTrue(typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", typefilsId)));
            Console.WriteLine("V�rification du libell�");
            Assert.IsTrue(typeTest.Libelle == nomType);



            return typefilsId;
        }


        private int CreerEquipementInclus(int typeqId, string nomEquip, int equipPereId, int siteId)
        {

            Console.WriteLine("Cr�ation d'un �quipement inclus");
            CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            CEquipementLogique equipPere = new CEquipementLogique(m_contexteDonnees);
            CSite site = new CSite(m_contexteDonnees);
            Console.WriteLine("Chargement du type d'�quipement");
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CTypeEquipement.c_champId + "=@1", typeqId)));
            Console.WriteLine("Chargement de l'�quipement p�re");
            Assert.IsTrue(equipPere.ReadIfExists(new CFiltreData(CEquipementLogique.c_champId + "=@1", equipPereId)));
            Console.WriteLine("Chargement du site");
            Assert.IsTrue(site.ReadIfExists(siteId));



            if (!equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", nomEquip))) 
            {
                equip.CreateNewInCurrentContexte();
                equip.Libelle = nomEquip;
                equip.TypeEquipement = typeq;
                equip.EquipementLogiqueContenant = equipPere;
                equip.Site = site;


            }
            Console.WriteLine("sauvegarde du site fils");
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

            int idEquip = equip.Id;



            CSpvEquip spvtest = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("Lecture du site fils");
            Assert.IsTrue(spvtest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", idEquip)));
            Console.WriteLine("V�rification du libell�");
            Assert.IsTrue(spvtest.CommentairePourSituer == nomEquip);

            Console.WriteLine("�quipement incluant");
            Console.WriteLine(spvtest.EquipementEnglobant.CommentairePourSituer);
            Console.WriteLine(spvtest.EquipementEnglobant.Id);

            return idEquip;
        }
        private int CreerFamille(string libelle)
        {

            Console.WriteLine("Cr�ation de la famille " + libelle);
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (!famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + "=@1", libelle)))
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = libelle;


            }

            else
                Console.WriteLine("la famille existe d�j�");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
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

            CFamilleEquipement familletest = new CFamilleEquipement(m_contexteDonnees);
            Console.WriteLine("V�rification de l'existence de la famille");
            Assert.IsTrue(familletest.ReadIfExists(id));

            return famille.Id;

        }




        private int CreerAlarmeGeree(int nIdTypeAcces, EAlarmEvent evt, EGraviteAlarmeAvecMasquage gravite)
        {

            Console.WriteLine("Cr�ation d'une alarme g�r�e");
            int nId = -1;
            CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            if (typeAcces.ReadIfExists(nIdTypeAcces))
            {

                if (!alarmeGeree.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", nIdTypeAcces.ToString())))
                {

                    alarmeGeree.CreateNewInCurrentContexte();
                    alarmeGeree.Alarmgeree_Name = typeAcces.NomAcces;
                    alarmeGeree.TypeAccesAlarme = typeAcces;
                    CAlarmEvent evenement = new CAlarmEvent(evt);
                    alarmeGeree.AlarmgereeEvent = evenement;
                    CGraviteAlarmeAvecMasquage grav = new CGraviteAlarmeAvecMasquage(gravite);
                    alarmeGeree.AlarmgereeGravite = grav;


                }
                else

                    Console.WriteLine("l'alarme g�r�e existe d�j�");


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

            }

            return nId;

        }


        private void ModifierNomAccesAlarme(int nIdAcces, string nouveauNomAcces)
        {

            Console.WriteLine("Modifdication du nom de l'acc�s alarme");
            CSpvAccesAlarme accesLibelle = new CSpvAccesAlarme(m_contexteDonnees);

            if (!accesLibelle.ReadIfExists(new CFiltreData(CSpvAccesAlarme.c_champACCES_NOM + "=@1", nouveauNomAcces)))
            {
                CSpvAccesAlarme acces = new CSpvAccesAlarme(m_contexteDonnees);

                CSpvAlarmGeree alarmeGeree = new CSpvAlarmGeree(m_contexteDonnees);
                Console.WriteLine("chargement de l'acc�s alarme");
                Assert.IsTrue(acces.ReadIfExists(new CFiltreData(CSpvAccesAlarme.c_champACCES_ID + "=@1", nIdAcces.ToString())));

                acces.NomAcces = nouveauNomAcces;
                Console.WriteLine("Sauvegarde de l'acc�s alarme");
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

                Console.WriteLine("Lecture de l'acc�s alarme");
                Assert.IsTrue(alarmeGeree.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", nIdAcces.ToString())));
                Console.WriteLine("V�rification du nom de l'acc�s");
                Assert.IsTrue(alarmeGeree.Alarmgeree_Name == nouveauNomAcces);
            }
            else
                Console.WriteLine("un acc�s alarme portant ce nom existe d�j�");

        }







        private void ModifierTypeAccesAlarme(int nId, ECategorieAccesAlarme categorie)
        {

            Console.WriteLine("Modification de la cat�gorie d'un acc�s alarme");

            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);

            Console.WriteLine("Lecture de l'acc�s alarme");
            Assert.IsTrue(typeAcces.ReadIfExists(new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_ID + "=@1", nId)));

            CCategorieAccesAlarme newCategorie = new CCategorieAccesAlarme(categorie);

            typeAcces.CategorieAccesAlarme = newCategorie;

            Console.WriteLine("sauvegarde de l'acc�s alarme");
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




        private void SupprimerFamille(string libelle)
        {
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("suppression d'une famille de type d'�quipement");
            CFamilleEquipement famille = new CFamilleEquipement(m_contexteDonnees);
            if (famille.ReadIfExists(new CFiltreData(CFamilleEquipement.c_champLibelle + " =@1", libelle))) 
            {
                result = famille.Delete();

                
                


            }


        }





        private int CreerTypeEquipement(string libelle, int nFamilleId)
        {

            Console.WriteLine("cr�ation du type d'�quipement "+ libelle);

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



        private int CreerTypeEquipement(string libelle, int nFamilleId, EGenreCommutateur TypeqCommut, string RefSnmp,
            bool bTosurv, string commut_oid, string typeq_identOID, string typeq_identvaleur, string typeq_identnom, bool bMibauto)
      
         {

             Console.WriteLine("Cr�ation du type d'�quipement "+ libelle);

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

            }
            else
                Console.WriteLine("le type d'�quipement existe d�j�");
             int nId = typeq.Id;
         
           
           CSpvTypeq  typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("Chargement du type SPV");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id+"=@1",typeq.Id)));
             
            Console.WriteLine("v�rification du libell�");
            Assert.IsTrue(typeqSpv.Libelle==typeq.Libelle);
            Console.WriteLine("v�rification du CLASS_ID");
            Assert.IsTrue(typeqSpv.TYPEQ_CLASSID == 1024);
           
            
             typeqSpv.TypeCommutateur = TypeqCommut;
             typeqSpv.ASurveiller = bTosurv;
             typeqSpv.ReferenceSnmp = RefSnmp;
             typeqSpv.OIDCommutateur=commut_oid;
             typeqSpv.OIDIdentifiantSnmp = typeq_identOID;
             typeqSpv.NomIdentifiantSnmp = typeq_identnom;
             typeqSpv.ChercheOIDParMIB = bMibauto;
            


             if(typeqSpv.ChercheOIDParMIB)
             {
                 Console.WriteLine(typeqSpv.OIDIdentifiantSnmp);

             }
             //typeqSpv.OIDIdentifiantSnmp=typeq_oid;

             
             
            Console.WriteLine("mise � jour des champs SPV");


       
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


            Console.WriteLine("lecture du type SPV");


            CSpvTypeq typeqTest = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeqTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            Console.WriteLine("v�rification du  champ 'type commutateur'");
            Assert.IsTrue(typeqTest.TypeCommutateur == TypeqCommut);
            Console.WriteLine("v�rification du  champ 'A surveiller'");
            Assert.IsTrue( typeqTest.ASurveiller == bTosurv);
            Console.WriteLine("v�rification du  champ 'Ref SNMP'");
            Assert.IsTrue(typeqTest.ReferenceSnmp == RefSnmp);
            Console.WriteLine("v�rification du  champ 'OID commutateur'");
            Assert.IsTrue(typeqTest.OIDCommutateur == commut_oid);
            Console.WriteLine("v�rification du  champ 'OID identifiant'");
            Assert.IsTrue(typeqTest.OIDIdentifiantSnmp == typeq_identOID);
            Console.WriteLine("v�rification du  champ 'Nom identifiant");
            Assert.IsTrue(typeqTest.NomIdentifiantSnmp == typeq_identnom);
            Console.WriteLine("v�rification du  champ 'MIB auto'");
            Assert.IsTrue(typeqTest.ChercheOIDParMIB == bMibauto);



            if (typeqSpv.ChercheOIDParMIB)
            {
                Console.WriteLine(typeqSpv.OIDIdentifiantSnmp);

            }


            return typeq.Id;
        }






        private void ModifierToSurv(int nId, bool bNewToSurv)
        {


            Console.WriteLine("Modification du champ 'A surveiller' d'un type d'�quipement");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            typeqSpv.ASurveiller = bNewToSurv;

            CResultAErreur result;
            Console.WriteLine("enregistreemnt du type d'�quipemnt");
         
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
            Console.WriteLine("lecture du type d'�quipemnt SPV");
            Assert.IsTrue(typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId)));

            Console.WriteLine("v�rification du champ 'A surveiller'");
            Assert.IsTrue(typeTest.ASurveiller == bNewToSurv);


        }


        private void ModifierLibelle(int nId, string newlibelle)
        {


            Console.WriteLine("Modification du libell� d'un type d'�quipement");
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);

            CTypeEquipement typeLibelle = new CTypeEquipement(m_contexteDonnees);
            if (!typeLibelle.ReadIfExists(new CFiltreData(CTypeEquipement.c_champLibelle + "=@1", newlibelle)))
            {

                Console.WriteLine("chargement du type d'�quipement � modifier");
                Assert.IsTrue(typeq.ReadIfExists(nId));

                typeq.Libelle = newlibelle;



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



                CSpvTypeq typeTest = new CSpvTypeq(m_contexteDonnees);
                Console.WriteLine("v�rification de l'�quipemnt SPV");
                Assert.IsTrue(typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId)));

                Console.WriteLine("modifier le nom de l'�quipement");
                Assert.IsTrue(typeTest.Libelle == newlibelle);

            }
            else
                Console.WriteLine("un type d'�quipemnt portant ce nom existe d�j�");
        }


        private void ModifierIdentNom(int nId, string newIdentNom)
        {

            Console.WriteLine("modification du champ Nom Identifiant SNMP d'un type �quipement");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);

            Console.WriteLine("lecture du type d'�quipemnt");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

            typeqSpv.NomIdentifiantSnmp = newIdentNom;



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
            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("v�rification de la valeur du champ Nom Identifiant SNMP");
            Assert.IsTrue(typeTest.NomIdentifiantSnmp == newIdentNom);


        }



        private void ModifierRefSnmp(int nId, string RefSnmp)
        {


            Console.WriteLine("Modification de la r�f�rence SNMP d'un type d'�quipement");

            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

           
            typeqSpv.ReferenceSnmp = RefSnmp;

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

            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("V�rification de la r�f�rence SNMP");
            Assert.IsTrue(typeTest.ReferenceSnmp == RefSnmp);


        }




        private void ModifierIdentOID(int nId, string identOID)
        {


            Console.WriteLine("modification de l'OID de l'identifiant d'un type d'�quipement");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));


            typeqSpv.OIDIdentifiantSnmp = identOID;


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

            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("v�rification de l'OID de l'identifiant d'un type d'�quipement");
            Assert.IsTrue(typeTest.OIDIdentifiantSnmp == identOID);


        }


        private void ModifierCommutOid(int nId, string newCommutOID)
        {


            Console.WriteLine("modification du champ 'OID commutateur' d'un type d'�quipement");
          
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));


            typeqSpv.OIDCommutateur = newCommutOID;

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

            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("v�rification du champ 'OID commutateur' ");
          
            Assert.IsTrue(typeTest.OIDCommutateur == newCommutOID);


        }

        private void ModifierMIBAuto(int nId, bool bNewMibAuto)
        {

            Console.WriteLine("modification du champ 'MIB auto");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
           
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));


            typeqSpv.ChercheOIDParMIB = bNewMibAuto;

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


           

            if (bNewMibAuto == true)
                typeqSpv.MibAuto();




            
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

            typeTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + " =@1", nId));

            Console.WriteLine("v�rification du champ 'MIB auto' ");

            Assert.IsTrue(typeTest.ChercheOIDParMIB == bNewMibAuto);


        }



        private void SupprimerTypeEquipement(int nId)
        {

            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement Timos");
            Assert.IsTrue(typeq.ReadIfExists(nId));


            Console.WriteLine("lecture du type d'�quipment SPV");
            CSpvTypeq typeqSpv = new CSpvTypeq(m_contexteDonnees);  
            Assert.IsTrue(typeqSpv.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));


                
                Console.WriteLine("suppression du type d'�quipment");

                CResultAErreur result = typeqSpv.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                result = typeq.Delete();
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);


             
                 
                Console.WriteLine("v�rification de la suppression du type Timos");
                CTypeEquipement typeqTest = new CTypeEquipement(m_contexteDonnees);
                Assert.IsFalse(typeqTest.ReadIfExists(nId));
                
                

                CSpvTypeq spvTest = new CSpvTypeq(m_contexteDonnees);
                Console.WriteLine("v�rification de la suppression du type SPV");
                Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nId)));

  

        }


        private int CreerTypeAccesAlarme(int nTypeqId, string nomAcces, ECategorieAccesAlarme categorie)
        {


            Console.WriteLine("cr�ation du type d'acc�s alarme @1 sur un type d'�quipement",nomAcces);
            CSpvTypeAccesAlarme typeAcces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Console.WriteLine("lecture du type d'�quipement");
            CSpvTypeq typeq = new CSpvTypeq(m_contexteDonnees);
            Assert.IsTrue(typeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", nTypeqId)));

            CFiltreData filtre = new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_NOM + "=@1", nomAcces);
          //  filtre = CFiltreData.GetAndFiltre(filtre, new CFiltreData(CSpvTypeAccesAlarme.c_champTYPEQ_ID + "=@1", nTypeqId));

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



        private int CreerEquipement(int TypeqId, string libelle, int SiteId)
        {
            int nId = -1;
            Console.WriteLine("cr�ation de l'�quipement " + libelle);
            CTypeEquipement typeq = new CTypeEquipement(m_contexteDonnees);

            Console.WriteLine("lecture du site ");
            CSite site = new CSite(m_contexteDonnees);
            Assert.IsTrue(site.ReadIfExists(SiteId));
                    
            if (typeq.ReadIfExists(TypeqId))
            {

                CEquipementLogique equip = new CEquipementLogique(m_contexteDonnees);
                if (!equip.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", libelle)))
                {
                    equip.CreateNewInCurrentContexte();
                    equip.Libelle = libelle;
                    equip.TypeEquipement = typeq;
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
                    int equipId = equip.Id;

                    Console.WriteLine("lecture du type d'�quipemnt SPV");
                    CSpvTypeq spvTypeq = new CSpvTypeq(m_contexteDonnees);
                    Assert.IsTrue(spvTypeq.ReadIfExists(new CFiltreData(CSpvTypeq.c_champSmtTypeEquipement_Id + "=@1", TypeqId)));


                    CSpvSite spvSite = new CSpvSite(m_contexteDonnees);
                    Console.WriteLine("lecture du site SPV");
                    Assert.IsTrue(spvSite.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1", SiteId)));



                    CSpvEquip test = new CSpvEquip(m_contexteDonnees);
                    Console.WriteLine("v�rification de la cr�ation de l'�quipemnt");
                    Assert.IsTrue(test.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", equipId)));

                    Console.WriteLine("v�rification du nom (commentaire) de l'�quipement");
                    Assert.IsTrue(test.CommentairePourSituer == libelle);
                    Console.WriteLine("v�rification du ClassId");
                    Assert.IsTrue(test.ClassId == 1018);
                    //Console.WriteLine("v�rification de l'id du site");
                    //Assert.IsTrue(test.SITE_ID == spvSite.Id);
                    //Console.WriteLine("v�rification de l'id du type");
                    //Assert.IsTrue(test.TYPEQ_ID == spvTypeq.Id);
                    Console.WriteLine("v�rification du nommage par commentaire");
                    Assert.IsTrue(test.NommageParCommentaire == true);
                    Console.WriteLine("v�rification du nommage par adresse IP");
                    Assert.IsFalse(test.NommageParAdresseIP == true);
                    Console.WriteLine("v�rification du nommage par g�ographie");
                    Assert.IsFalse(test.NommageParGeographie == true);
                    Console.WriteLine("v�rification du nommage par r�f�rence");
                    Assert.IsFalse(test.NommageParReference == true);
                    Console.WriteLine("v�rification de l'unicit� du commentaire");
                    Assert.IsTrue(test.FlagUniciteCommentaire == true);
                    Console.WriteLine("v�rification de l'unicit� de la g�ographie");
                    Assert.IsFalse(test.FlagUniciteGeographie == true);
                    Console.WriteLine("v�rification de l'unicit� de la r�f�rence");
                    Assert.IsFalse(test.FlagUniciteReference == true);
                    Console.WriteLine("v�rification de l'unicit� de l'adresse IP");
                    Assert.IsFalse(test.FlagUniciteAdresseIP == true);
                    Console.WriteLine("v�rification du choix du mode de nommage");
                    Assert.IsTrue(test.ChoixEtiquette == 2);

                }
                else
                    Console.WriteLine("l'�quipement existe d�j�");

                nId = equip.Id;
            }

            return nId;
        }



        private void ModifierEquipComment(int nId, string newEquipComment)
        {

            Console.WriteLine("modification du nom d'un �quipement");
            CEquipementLogique equipLibelle = new CEquipementLogique(m_contexteDonnees);
            if (!equipLibelle.ReadIfExists(new CFiltreData(CEquipementLogique.c_champLibelle + "=@1", newEquipComment)))
            {


                CEquipementLogique equipLog = new CEquipementLogique(m_contexteDonnees);
                Console.WriteLine("lecture de l'�quipemnt logique");
                Assert.IsTrue(equipLog.ReadIfExists(nId));
                equipLog.Libelle = newEquipComment;


                CResultAErreur result = CResultAErreur.True;
                Console.WriteLine("v�rification des donn�es");
                result = equipLog.VerifieDonnees(false);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);

                Console.WriteLine("enregistrement des donnees");
                m_contexteDonnees.SaveAll(true);
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);

                Assert.IsTrue(result.Result);


                CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
                Console.WriteLine("lecture de l'�quipmement SPV");
                Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

                Console.WriteLine("v�rification du nom de l'�quipement");
                Assert.IsTrue(equip.CommentairePourSituer == newEquipComment);


            }
            else
                Console.WriteLine("un �quipement avec ce libell� existe d�j�");

        }


        private void ModifierEquipToSurv(int nId, bool bNewToSurv)
        {

            Console.WriteLine("modification du champ 'a surveiller' d'un �quipement");

            CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipemnt logique");
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            equip.ASuperviser = bNewToSurv;

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

            Console.WriteLine("lecture de l'�quipmement SPV");

            CSpvEquip equiptest = new CSpvEquip(m_contexteDonnees);
           
            Assert.IsTrue(equiptest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            Console.WriteLine("v�rification du champ 'a surveiller'");
            Assert.IsTrue(equiptest.ASuperviser == bNewToSurv);


        }


        private void ModifierEquipAddrip(int nId, string newAddrIp)
        {

            Console.WriteLine("modification du champ 'Adresse IP' d'un �quipement");

            CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipemnt logique");
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            string strOldAddrIP = equip.AdresseIP;
            equip.AdresseIP = newAddrIp;
            Console.WriteLine("sauvegarde de l'�quipement");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = equip.VerifieDonnees(false);
            Assert.IsTrue(equip.AdresseIP == newAddrIp);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);
            Assert.IsTrue(equip.AdresseIP == newAddrIp);

            Console.WriteLine("lecture de l'�quipmement SPV");

            CSpvEquip equiptest = new CSpvEquip(m_contexteDonnees);

            Assert.IsTrue(equiptest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            //equiptest.Refresh();
            Console.WriteLine("v�rification de l'adresse IP");
            Assert.IsTrue(equiptest.AdresseIP == newAddrIp);
            

        }


        private void ModifierEquipCmnte(int nId, string newCmnte)
        {

            Console.WriteLine("modification du champ 'Communaut� SNMP' d'un �quipement");

            CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipemnt logique");
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            string strOldCom = equip.CommunauteSnmp;
            equip.CommunauteSnmp = newCmnte;
            Assert.IsTrue(equip.CommunauteSnmp == newCmnte);
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = equip.VerifieDonnees(false);
            Assert.IsTrue(equip.CommunauteSnmp == newCmnte);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            result = m_contexteDonnees.SaveAll(true);
            Assert.IsTrue(equip.CommunauteSnmp == newCmnte);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            Console.WriteLine("lecture de l'�quipmement SPV");

            CSpvEquip equiptest = new CSpvEquip(m_contexteDonnees);

            Assert.IsTrue(equiptest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            Console.WriteLine("v�rification de la communaute");
            Assert.IsTrue(equiptest.CommunauteSnmp == newCmnte);


        }



        private void ModifierEquipEmName(int nId, string newEmName)
        {

            Console.WriteLine("modification du champ 'Equipement de m�diation' d'un �quipement");

            CSpvEquip equip = new CSpvEquip(m_contexteDonnees);
            Console.WriteLine("lecture de l'�quipement logique");
            Assert.IsTrue(equip.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));
            string strOldEmName = equip.EquipementDeMediation;
            equip.EquipementDeMediation = newEmName;
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result =equip.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);

            Console.WriteLine("lecture de l'�quipmement SPV");

            CSpvEquip equiptest = new CSpvEquip(m_contexteDonnees);

            Assert.IsTrue(equiptest.ReadIfExists(new CFiltreData(CSpvEquip.c_champSmtEquipementLogique_Id + "=@1", nId)));

            Console.WriteLine("v�rification de la communaute");
            Assert.IsTrue(equiptest.EquipementDeMediation == newEmName);


        }


        

        public int CreerTypeSite(string nomTypeSite)
        {

            Console.WriteLine("Cr�ation du type de site "+nomTypeSite);
            //cr�er un type de site
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);


            if (!typeSite.ReadIfExists(new CFiltreData(CTypeSite.c_champLibelle + "=@1",
                nomTypeSite)))
            {
                typeSite.CreateNewInCurrentContexte();
                typeSite.Libelle = nomTypeSite;


            }

            else
                System.Console.WriteLine("Le type de site existe d�j�");

            Console.WriteLine("Enregisrement du type de site");
            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("v�rification des donn�es");
            result = typeSite.VerifieDonnees(false);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);

            Console.WriteLine("enregistrement des donnees");
            m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);



            return typeSite.Id;


        }


        public int CreerSite(int nTypeSiteId, string nomSite)
        {
            //Cree un nouveau site

            Console.WriteLine("cr�ation du site " +nomSite);
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
            Console.WriteLine("v�rification des donn�es");
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
            Assert.IsTrue(spvSiteTest.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                site.Id)));
            Console.WriteLine("V�rification du libell� du site SPV");
            Assert.AreEqual(site.Libelle, spvSiteTest.SiteNom);
            Console.WriteLine("V�rification du ClassId du site SPV");
            Assert.AreEqual(spvSiteTest.ClassId, 1008);


            return site.Id;


        }


        public void SupprimerTypeSite(int nIdSite)
        {
            //supprime un type de site

            Console.WriteLine("Suppression d'un type de site");
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees);
            CSpvTypsite typeSiteSpv = new CSpvTypsite(m_contexteDonnees);

            CResultAErreur result = CResultAErreur.True;
            Console.WriteLine("chargement du type de site � supprimer");
            Assert.IsTrue(typeSite.ReadIfExists(nIdSite));

            Console.WriteLine("chargement du type de site SPV � supprimer");

            typeSiteSpv.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1",
                    nIdSite));

            result = typeSite.Delete();

            Console.WriteLine("Suppression du type de site");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);

            Assert.IsTrue(result.Result);




            CTypeSite typesiteTest = new CTypeSite(m_contexteDonnees);
            Console.WriteLine("V�rification de la suppression du site Timos");


            CSpvTypsite spvTest = new CSpvTypsite(m_contexteDonnees);
            Assert.IsFalse(typesiteTest.ReadIfExists(nIdSite));

            Console.WriteLine("V�rification de la suppression du site SPV");
            Assert.IsFalse(spvTest.ReadIfExists(new CFiltreData(CSpvTypsite.c_champSmtTypeSite_Id + "=@1", nIdSite)));




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
                // siteSpv.ReadIfExists(new CFiltreData(CSpvSite.c_champSmtSite_Id + "=@1",
                //   nIdSite.ToString()));



                result = site.Delete();

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

        void SupprimerTypeAccesAlarme(int nId)
        {

            Console.WriteLine("suppression d'un type d'acc�s alarme");
            CSpvTypeAccesAlarme acces = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Console.WriteLine("chargement de l'acc�s alarme");
            Assert.IsTrue(acces.ReadIfExists(new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_ID + " = @1", nId)));
            CResultAErreur result = CResultAErreur.True;


            CSpvAlarmGeree alarmGeree = new CSpvAlarmGeree(m_contexteDonnees);
            if (alarmGeree.ReadIfExists(new CFiltreData(CSpvAlarmGeree.c_champACCES_ID + "=@1", nId)))
            {
                result = alarmGeree.Delete();
                Console.WriteLine("suppression de l'alarme g�r�e");
                if (!result)
                    System.Console.WriteLine(result.MessageErreur);
                Assert.IsTrue(result.Result);


            }

            result = acces.DeleteAccesAlarmeEquips();


            Console.WriteLine("suppression des acc�s alarmes des �quipemnts du type");
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


            
            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Console.WriteLine("suppression du type d'acc�s alarme");

            result = acces.Delete();
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);


       /*     Console.WriteLine("Enregistrement de la suppression");

            result = m_contexteDonnees.SaveAll(true);
            if (!result)
                System.Console.WriteLine(result.MessageErreur);
            Assert.IsTrue(result.Result);*/


            Console.WriteLine("v�rification de la suppression");
            CSpvTypeAccesAlarme accesTest = new CSpvTypeAccesAlarme(m_contexteDonnees);
            Assert.IsFalse(acces.ReadIfExists(new CFiltreData(CSpvTypeAccesAlarme.c_champACCES_ID + " = @1", nId)));

        }

        ///V�rifie les probl�mes de mis � jour al�atoire des �quipements
        ///Les probl�mes arrivent souvent sur l'�quipement lors de la mise � jour
        /// de la communaut� ou de l'adresse IP. Le test fait donc des modifications sur ces champs
        /// et v�rifie que ces modifs passent bien
        ///Suppression de l'�quipement
        [Test]
        public void TestMAJAl�atoireEquipement()
        {
            int nIdFamille = CreerFamille("TEST_TE4_FAMILLE");
            int nIdTypeq1 = CreerTypeEquipement("TEST_TE4_TYPEQ1", nIdFamille);

            int nIdTypSite = CreerTypeSite("TEST_TE4_TYPSITE");
            int nIdSite = CreerSite(nIdTypSite, "TEST_TE4_SITE");

            int nIdEquip1 = CreerEquipement(nIdTypeq1, "TEST_TE4_EQUIP1", nIdSite);

            for (int n = 0; n < 50; n++)
            {
                System.Console.WriteLine("Test n�" + n);
                ModifierEquipCmnte(nIdEquip1, "");
                ModifierEquipAddrip(nIdEquip1, null);
                ModifierEquipAddrip(nIdEquip1, "IP1");
                ModifierEquipCmnte(nIdEquip1, null);
                ModifierEquipCmnte(nIdEquip1, "test");
                ModifierEquipAddrip(nIdEquip1, "");
                ModifierEquipCmnte(nIdEquip1, "T2");
                ModifierEquipAddrip(nIdEquip1, "");
                ModifierEquipCmnte(nIdEquip1, null);
                ModifierEquipCmnte(nIdEquip1, "");
                ModifierEquipCmnte(nIdEquip1, "T3");
            }
            SupprimerEquipement(nIdEquip1);
        }
    }

}
