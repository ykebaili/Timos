using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using timos.data;
using sc2i.data;
using spv.data;
using sc2i.common;

namespace spv.test
{
    [TestFixture]
    public class CStefTestLiaisonsEtSchemas
    {
        private CContexteDonnee m_contexteDonnees = null;

        private const string c_nomTypeSite = "TEST_STEF";
        private const string c_nomTypEquipement = "TEST_STEF";
        private const string c_nomFamilleEquipementTest = "TEST_STEF";
        private const string c_nomPort1 = "TEST_PORT1";
        private const string c_nomPort2 = "TEST_PORT_2";
        private const string c_nomPort3 = "TEST_PORT_3";

        //-----------------------------------------
        [SetUp]
        public void Init()
        {
            CResultAErreur result = CResultAErreur.True;
            CSpvTestApp.AssureInit();
            m_contexteDonnees = new CContexteDonnee(CSpvTestApp.SessionClient.IdSession, true, false);
        }

        //-----------------------------------------
        private CTypeLienReseau GetTypeLienReseau ( string strLibelle, Type type1, Type type2, bool bSuperviser )
        {
            CTypeLienReseau typeLien = new CTypeLienReseau ( m_contexteDonnees );
            if ( !typeLien.ReadIfExists ( new CFiltreData ( CTypeLienReseau.c_champLibelle+"=@1", strLibelle ) ) )
            {
                typeLien.CreateNewInCurrentContexte();
                typeLien.Libelle = strLibelle;
            }
            typeLien.TypeElement1 = type1;
            typeLien.TypeElement2 = type2;
            CResultAErreur result = CResultAErreur.True;
            CSpvTypliai typeLiai = CSpvTypliai.GetObjetSpvFromObjetTimos ( typeLien );
            if ( !bSuperviser && typeLiai != null )
            {
                result = typeLiai.Delete ( true );
            }
            if ( bSuperviser && typeLiai == null )
            {
                typeLiai = CSpvTypliai.GetObjetSpvFromObjetTimosAvecCreation ( typeLien );
                if ( typeLiai == null )
                    result.EmpileErreur("Erreur lors de la création du type de liaison SPV");
            }
            if ( !result )
            {
                Console.WriteLine("Erreur à la création du type de lien réseau "+strLibelle);
                Assert.IsFalse ( true );
            }
            return typeLien;
                
        }

        private void DoErreur ( string strErreur )
        {
            Console.WriteLine(strErreur);
            Assert.IsFalse(true);
        }

        //-----------------------------------------
        private CPort GetPort ( CTypeEquipement typeEquipement, string strLibellePort )
        {
            CListeObjetsDonnees ports = typeEquipement.Ports;
            ports.Filtre = new CFiltreData ( CPort.c_champLibelle+"=@1", strLibellePort );
            if ( ports.Count == 0 )
            {
                CPort port = new CPort ( m_contexteDonnees );
                port.CreateNewInCurrentContexte();
                port.Libelle = strLibellePort;
                port.TypeEquipement = typeEquipement;
                return port;
            }
            return ports[0] as CPort;
        }
            

        //-----------------------------------------
        private CTypeEquipement GetTypeEquipementTest()
        {
            CTypeEquipement typeEquipement = new CTypeEquipement ( m_contexteDonnees );
            if ( !typeEquipement.ReadIfExists ( new CFiltreData ( CTypeEquipement.c_champLibelle+"=@1",
                c_nomTypEquipement ) ))
            {
                typeEquipement.CreateNewInCurrentContexte();
                typeEquipement.Libelle = c_nomTypEquipement;
            }
            CFamilleEquipement famille = new CFamilleEquipement (m_contexteDonnees );
            if ( !famille.ReadIfExists ( new CFiltreData ( CFamilleEquipement.c_champLibelle+"=@1",
                c_nomFamilleEquipementTest ) ) )
            {
                famille.CreateNewInCurrentContexte();
                famille.Libelle = c_nomFamilleEquipementTest;
            }
            typeEquipement.Famille = famille;
            GetPort ( typeEquipement, c_nomPort1 );
            GetPort ( typeEquipement, c_nomPort2 );
            GetPort ( typeEquipement, c_nomPort3 );
            return typeEquipement;


        }

        //-----------------------------------------
        private CTypeSite GetTypeSiteTest()
        {
            CTypeSite typeSite = new CTypeSite(m_contexteDonnees );
            if ( !typeSite.ReadIfExists ( new CFiltreData ( CTypeSite.c_champLibelle+"=@1",
                c_nomTypeSite) ))
            {
                typeSite.CreateNewInCurrentContexte();
                typeSite.Libelle = c_nomTypeSite;
            }
            return typeSite;
        }

        //-----------------------------------------
        private void VerifieResult(CResultAErreur result, string strMessage, bool bOkAttendu)
        {
            if (!result)
                Console.WriteLine(result.Erreur.ToString());
            if (result.Result != bOkAttendu)
            {
                Console.WriteLine(strMessage);
                Assert.IsTrue(false);
            }
        }


        //-----------------------------------------
        /// <summary>
        /// Sauve les données et gère l'erreur si nécéssaire
        /// </summary>
        /// <param name="strMessageSiErreur"></param>
        private void SaveData( string strMessageSiErreur, bool bOkAttendu)
        {
            //Sauve les données
            VerifieResult(m_contexteDonnees.SaveAll(true), strMessageSiErreur, bOkAttendu);
            System.Threading.Thread.Sleep(2000);
        }

        //-----------------------------------------
        private CSite GetSite ( string strLibelle )
        {
            CSite site = new CSite ( m_contexteDonnees );
            if ( !site.ReadIfExists ( new CFiltreData ( CSite.c_champLibelle+"=@1", strLibelle ) ))
            {
                site.CreateNewInCurrentContexte();
                site.Libelle = strLibelle;
                
            }
            site.TypeSite = GetTypeSiteTest();
            return site;
        }

        //-----------------------------------------
        private CExtremiteLienSurSite GetExtremiteSite ( CSite site, string strLibelleExt )
        {
            CExtremiteLienSurSite ext = new CExtremiteLienSurSite(m_contexteDonnees);
            if ( !ext.ReadIfExists ( new CFiltreData ( CSite.c_champId+"=@1 and "+
                CExtremiteLienSurSite.c_champLibelle+"=@2",
                site.Id,
                strLibelleExt ) ) )
            {
                ext.CreateNewInCurrentContexte();
                ext.Site = site;
                ext.Libelle = strLibelleExt;
            }
            return ext;
         }

        private CTypeSchemaReseau GetTypeSchema ( string strLibelle, bool bSupervise )
        {
            CTypeSchemaReseau typeSchema = new CTypeSchemaReseau ( m_contexteDonnees );
            if ( !typeSchema.ReadIfExists ( new CFiltreData ( CTypeSchemaReseau.c_champLibelle+"=@1",
                strLibelle ) ))
            {
                typeSchema.CreateNewInCurrentContexte();
                typeSchema.Libelle = strLibelle;
                //if ( bSupervise )
                //    CSpvTypeService.GetObjetSpvFromObjetTimosAvecCreation ( typeSchema );
            }
            return typeSchema;
        }

        private CSchemaReseau GetSchema(string strLibelle, CTypeSchemaReseau typeSchema)
        {
            CSchemaReseau schema = new CSchemaReseau(m_contexteDonnees);
            if (!schema.ReadIfExists(new CFiltreData(CSchemaReseau.c_champLibelle + "=@1",
                strLibelle)))
            {
                schema.CreateNewInCurrentContexte();
                schema.Libelle = strLibelle;
                schema.TypeSchemaReseau = typeSchema;
                //CSpvTypeService typeServiceAssocie = CSpvTypeService.GetObjetSpvFromObjetTimos(typeSchema);
                //if (typeServiceAssocie != null)
                //{
                    //Le schéma est supervisé, il faut donc l'associer au client système
                CSpvSchemaReseau service = CSpvSchemaReseau.GetObjetSpvFromObjetTimosAvecCreation(schema);
                    //service.SpvClient = CSpvClient.GetClientSysteme(m_contexteDonnees);
                //}
            }
            return schema;
        }


        private CEquipementLogique GetEquipement ( CSite site, string strLibelle )
        {
            CEquipementLogique eqpt = new CEquipementLogique ( m_contexteDonnees );
            if ( !eqpt.ReadIfExists ( new CFiltreData ( CSite.c_champId+"=@1 and "+
                CEquipementLogique.c_champLibelle+"=@2",
                site.Id,
                strLibelle )))
            {
                eqpt.CreateNewInCurrentContexte();
                eqpt.Site = site;
                eqpt.Libelle= strLibelle;
            }
            eqpt.TypeEquipement = GetTypeEquipementTest();
            return eqpt;
        }

        private CTypeLienReseauSupport GetSupport(CTypeLienReseau typeSupporté, CTypeLienReseau typeSupportant)
        {
            CTypeLienReseauSupport support = new CTypeLienReseauSupport(m_contexteDonnees);
            if (!support.ReadIfExists(new CFiltreData(
                CTypeLienReseauSupport.c_champIdTypeSupportant + "=@1 and " +
                CTypeLienReseauSupport.c_champIdTypeSupporté + "=@2",
                typeSupportant.Id,
                typeSupporté.Id)))
            {
                support.CreateNewInCurrentContexte();
                support.TypeSupportant = typeSupportant;
                support.TypeSupporté = typeSupporté;
            }
            return support;
        }




            
        //-----------------------------------------
        private CLienReseau GetLienReseau ( 
            string strLibelle, 
            CTypeLienReseau typeLien,
            IElementALiensReseau elt1, 
            IElementALiensReseau elt2,
            IComplementElementALiensReseau complement1,
            IComplementElementALiensReseau complement2)
        {
            CLienReseau lienReseau = new CLienReseau ( m_contexteDonnees );
            if ( !lienReseau.ReadIfExists ( new CFiltreData ( CLienReseau.c_champLibelle+"=@1",
                strLibelle )))
            {
                lienReseau.CreateNewInCurrentContexte();
                lienReseau.Libelle = strLibelle;
            }
            lienReseau.TypeLienReseau = typeLien;
            lienReseau.Element1 = elt1;
            lienReseau.Element2 = elt2;
            lienReseau.Complement1 = complement1;
            lienReseau.Complement2 = complement2;
            return lienReseau;
        }

        public CElementDeSchemaReseau GetSiteInSchema ( CSchemaReseau schema, CSite site )
        {
            CListeObjetsDonnees lstElts = schema.ElementsDeSchema;
            lstElts.Filtre = new CFiltreData ( CSite.c_champId+"=@1", site.Id );
            if ( lstElts.Count == 0 )
            {
                CElementDeSchemaReseau elt = new CElementDeSchemaReseau ( m_contexteDonnees );
                elt.SchemaReseau = schema;
                elt.Site = site;
                return elt;
            }
            return lstElts[0] as CElementDeSchemaReseau;
        }

        public CElementDeSchemaReseau GetSchemaInSchema ( CSchemaReseau schemaContenant, CSchemaReseau schemaContenu )
        {
            CListeObjetsDonnees lstElts = schemaContenant.ElementsDeSchema;
            lstElts.Filtre = new CFiltreData ( CElementDeSchemaReseau.c_champIdSchemaReseauContenu+"=@1", 
                schemaContenu.Id );
            if ( lstElts.Count == 0 )
            {
                CElementDeSchemaReseau elt = new CElementDeSchemaReseau(m_contexteDonnees);
                elt.SchemaReseau = schemaContenant;
                elt.SchemaReseauContenu = schemaContenu;
                return elt;
            }
            return lstElts[0] as CElementDeSchemaReseau;
        }

        public CElementDeSchemaReseau GetEquipementInSchema ( CSchemaReseau schema, CEquipementLogique eqpt )
        {
            CListeObjetsDonnees lstElts = schema.ElementsDeSchema;
            lstElts.Filtre = new CFiltreData ( CEquipementLogique.c_champId+"=@1", eqpt.Id );
            if ( lstElts.Count == 0)
            {
                CElementDeSchemaReseau elt = new CElementDeSchemaReseau(m_contexteDonnees );
                elt.SchemaReseau = schema;
                elt.EquipementLogique = eqpt;
                return elt;
            }
            return lstElts[0] as CElementDeSchemaReseau;
        }

        public CElementDeSchemaReseau GetElementALienInSchema ( CSchemaReseau schema, IElementALiensReseau elt )
        {
            if ( elt is CEquipementLogique )
                return GetEquipementInSchema ( schema, elt as CEquipementLogique );
            if ( elt is CSite )
                return GetSiteInSchema ( schema, elt as CSite );
            return null;
        }

        public CElementDeSchemaReseau GetLienInSchema ( CSchemaReseau schema, CLienReseau lien )
        {
            CListeObjetsDonnees lstElts = schema.ElementsDeSchema;
            lstElts.Filtre = new CFiltreData ( CLienReseau.c_champId+"=@1", lien.Id );
            CElementDeSchemaReseau elt = null;
            if ( lstElts.Count == 0 )
            {
                elt = new CElementDeSchemaReseau(m_contexteDonnees);
                elt.SchemaReseau = schema;
                elt.LienReseau = lien;
            }
            else
                elt = lstElts[0] as CElementDeSchemaReseau;
            GetElementALienInSchema ( schema, lien.Element1 );
            GetElementALienInSchema ( schema, lien.Element2 );
            return elt;
        }






        [Test]
        public void TestContraintesExtremitésLienNonSpv()
        {
            TestContraintesExtremitésLien(false);
        }
        [Test]
        public void TestContraintesExtremitésLienSpv()
        {
            TestContraintesExtremitésLien(true);
        }
        //-----------------------------------------
        /// <summary>
        /// Vérifie que les contraintes de type d'extremité définies sur le type de lien
        /// S'appliquent bien aux liens de ce type
        /// </summary>
        public void TestContraintesExtremitésLien(bool bSupervisé)
        {
            ///Création d'un lien de site à site non supervisé
            string strNomTypeLien = "TEST_SITE_SITE_NONSS";
            CTypeLienReseau typeLien = GetTypeLienReseau(strNomTypeLien,
                typeof(CSite),
                typeof(CSite),
                bSupervisé);
            CSite site1 = GetSite("Test_Site1");
            CSite site2 = GetSite("Test_Site2");
            CExtremiteLienSurSite extSite1 = GetExtremiteSite(site1, "S1EXT1");
            CExtremiteLienSurSite extSite2 = GetExtremiteSite(site2, "S2EXT1");
            CLienReseau lienReseau = GetLienReseau("TEST_LIEN1", typeLien, site1, site2, extSite1, extSite2);
            Console.WriteLine("*****Test simple création lien");
            VerifieResult( lienReseau.VerifieDonnees(true), "Echec vérification donnée lien "+lienReseau.Libelle, true);
            SaveData("Erreur création lien simple", true);
            if (bSupervisé)
            {
                CSpvLiai spvLiai = CSpvLiai.GetSpvLiaiFromLienReseau(lienReseau) as CSpvLiai;
                if (spvLiai == null)
                {
                    Console.WriteLine("Liaison SPV non créé");
                    Assert.IsTrue(false);
                }
                if (spvLiai.NomLiaison != lienReseau.Libelle)
                {
                    Console.WriteLine("Libellé de la liaison SPV incorrect");
                    Assert.IsTrue(false);
                }
                Console.WriteLine("****Modification du libellé de la liaison");
                lienReseau.Libelle = "TEST_LIEN_BIS";
                SaveData("Erreur lors de la modification du libellé du lien", true);
                spvLiai.Refresh();
                if (spvLiai.NomLiaison != "TEST_LIEN_BIS")
                {
                    Console.WriteLine("Synchro libellé de liaison raté !");
                    Assert.IsTrue(false);
                }
                Console.WriteLine("Ok");
                lienReseau.Libelle = "TEST_LIEN_1";
                SaveData("Erreur lors de la restauration du libellé du lien", true);
            }
            CResultAErreur result = lienReseau.Delete();
            if (!result)
            {
                Console.WriteLine("Erreur suppression lien" + lienReseau.Libelle);
                Assert.IsTrue(false);
            }
            Console.WriteLine("OK");
            //Tente de créer un lien du type entre un équipement et un site
            CEquipementLogique eqpt1 = GetEquipement(site1, "TEST_EQPT1");
            lienReseau = GetLienReseau("TEST_LIEN1", typeLien, site1, eqpt1, extSite1, extSite2);
            VerifieResult( lienReseau.VerifieDonnees(true), "Echec vérification donnée lien "+lienReseau.Libelle, true);
            Console.WriteLine("****Tente de créer un lien site/eqpt sur un type site/site");
            SaveData("Erreur : possible de créer un lien site/eqpt sur un type site/site", false);
            m_contexteDonnees.RejectChanges();
            Console.WriteLine("OK");

            //Même test, mais dans l'autre sens (eqpt/site)
            eqpt1 = GetEquipement(site1, "TEST_EQPT1");
            lienReseau = GetLienReseau("TEST_LIEN1", typeLien, eqpt1, site1, extSite1, extSite2);
            VerifieResult(lienReseau.VerifieDonnees(true), "Echec vérification donnée lien " + lienReseau.Libelle, true);
            Console.WriteLine("****Tente de créer un lien eqpt/site sur un type site/site");
            SaveData("Erreur : possible de créer un lien eqpt/site sur un type site/site", false);
            m_contexteDonnees.RejectChanges();
            Console.WriteLine("OK");

            Console.WriteLine("****Ménage");
            //Tente de faire le ménage
            result = typeLien.Delete(false);
            if ( result ) result = site1.Delete(false);
            if (result) result = site2.Delete(false);
            if (result) result = GetTypeEquipementTest().Delete(false);
            if (result) result = GetTypeSiteTest().Delete(false);
            if (result) result = m_contexteDonnees.SaveAll(true);
            if (!result)
            {
                Console.WriteLine("Erreur nettoyage");
                Console.WriteLine(result.Erreur.ToString());
            }
            
        }

        [Test]
        public void TestContraintesSupportNonSpv()
        {
            TestContraintesSupport(false);
        }

        [Test]
        public void TestContraintesSupportSpv()
        {
            TestContraintesSupport(true);
        }
        
        //-----------------------------------------
        /// <summary>
        /// Vérifie que les contraintes support/supportant sont bien appliquées
        /// </summary>
        public void TestContraintesSupport( bool bSupervisé)
        {
            Console.WriteLine("****Création du jeu de test");
            ///Création d'un lien de site à site non supervisé
            CTypeLienReseau typeLienSupportant = GetTypeLienReseau("TEST_SUPPORTANT",
                typeof(CSite),
                typeof(CSite),
                bSupervisé);
            CTypeLienReseau typeLienSupporté = GetTypeLienReseau("TEST_SUPPORTE",
                typeof(CSite),
                typeof(CSite),
                bSupervisé);
            VerifieResult(
                CObjetDonneeAIdNumerique.Delete(typeLienSupportant.TypesPouvantEtreSupportesParCeType, true), "Erreur lors de la suppression des Supports", true);
            VerifieResult(
                CObjetDonneeAIdNumerique.Delete(typeLienSupportant.TypesPouvantSupporterCeType, true), "Erreur lors de la suppression des Supports", true);
            VerifieResult(
                CObjetDonneeAIdNumerique.Delete(typeLienSupporté.TypesPouvantEtreSupportesParCeType, true), "Erreur lors de la suppression des Supports", true);
            VerifieResult(
                CObjetDonneeAIdNumerique.Delete(typeLienSupporté.TypesPouvantSupporterCeType, true), "Erreur lors de la suppression des Supports", true);

            GetSupport(typeLienSupporté, typeLienSupportant);
            CSite site1 = GetSite("Test_Site1");
            CSite site2 = GetSite("Test_Site2");
            CExtremiteLienSurSite extSite1 = GetExtremiteSite(site1, "S1EXT1");
            CExtremiteLienSurSite extSite2 = GetExtremiteSite(site2, "S2EXT1");
            CLienReseau lienSupportant = GetLienReseau("TEST_LIEN_1", typeLienSupportant, site1, site2, extSite1, extSite2);
            CLienReseau lienSupporté = GetLienReseau("TEST_LIEN_2", typeLienSupporté, site1, site2, extSite1, extSite2);
            CSchemaReseau schemaSupportant = lienSupportant.SchemaReseau;
            if (schemaSupportant == null)
            {
                schemaSupportant = new CSchemaReseau(m_contexteDonnees);
                schemaSupportant.CreateNewInCurrentContexte();
                schemaSupportant.Libelle = lienSupportant.Libelle;
                schemaSupportant.LienReseau = lienSupportant;
            }
            CObjetDonneeAIdNumerique.Delete(schemaSupportant.ElementsDeSchema, true);
            CSchemaReseau schemaSupporté = lienSupporté.SchemaReseau;
            if (schemaSupporté == null)
            {
                schemaSupporté = new CSchemaReseau(m_contexteDonnees);
                schemaSupporté.CreateNewInCurrentContexte();
                schemaSupporté.Libelle = lienSupporté.Libelle;
                schemaSupporté.LienReseau = lienSupporté;
            }
            CObjetDonneeAIdNumerique.Delete(schemaSupporté.ElementsDeSchema, true);
            
            SaveData("Erreur création du jeu de test", true);
            Console.WriteLine("OK");

            CElementDeSchemaReseau eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.SchemaReseau = schemaSupporté;
            eltDependance.LienReseau = lienSupportant;
            Console.WriteLine("****Création d'un lien supportant");
            VerifieResult(eltDependance.VerifieDonnees(false), "Erreur lien supportant non validé", true);
            SaveData("Erreur lien supportant non validé", true);
            if (bSupervisé)
            {
                //Vérifie que la dépendance est bien répercutée sur SPV
                CSpvLiai liai1 = CSpvLiai.GetSpvLiaiFromLienReseau(lienSupportant)  as CSpvLiai;
                CSpvLiai liai2 = CSpvLiai.GetSpvLiaiFromLienReseau(lienSupporté) as CSpvLiai;
                if (liai1 == null || liai2 == null)
                {
                    Console.WriteLine("Création des liens non répercutée sur SPV");
                    Assert.IsTrue(false);
                }
                /*CListeObjetsDonnees listeSupportés = liai1.LiaisonsSupportées;
                
                listeSupportés.Filtre = new CFiltreData(CSpvLiai_Liaic.c_champIdLiaisonSupportée + "=@1",
                    liai2.Id);
                if (listeSupportés.Count == 0)
                {
                    Console.WriteLine("Répercution dépendance liaison SPV ratée");
                    Assert.IsTrue(false);
                }*/
            }
            Console.WriteLine("OK");
            
            VerifieResult ( eltDependance.Delete(), "Erreur suppression de la dépendance", true);

            eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.SchemaReseau = schemaSupportant;
            eltDependance.LienReseau = lienSupporté;
            Console.WriteLine("****Création d'un lien supportant non autorisé");
            VerifieResult(eltDependance.VerifieDonnees(false), "Erreur possible de passer outre le contrainte supportant/supporté", false);
            Console.WriteLine("OK");
            m_contexteDonnees.RejectChanges();

            //Création d'une dépendance cyclique à un niveau : lien 1 dépend de lien 2 et lien 2 dépend de lien 1
            GetSupport(typeLienSupportant, typeLienSupportant);
            SaveData("Erreur création Support", true);
            CLienReseau lienSupportant2 = lienSupporté;//Réutilise le lien en changeant son type
            lienSupportant2.TypeLienReseau = typeLienSupportant;
            CSchemaReseau schema2 = lienSupportant2.SchemaReseau;
            eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.SchemaReseau = schema2;
            eltDependance.LienReseau = lienSupportant;
            Console.WriteLine("****Création d'un lien supportant cyclique à 1 niveau");
            VerifieResult(eltDependance.VerifieDonnees(false), "Erreur lors de la création de la première dépendance", true);
            SaveData ( "Erreur lors de la création de la première dépendance", true );
                //2 supporte1, maintenant, on 1 va supporter 2->pb
            eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.SchemaReseau = schemaSupportant;
            eltDependance.LienReseau = lienSupportant2;
            VerifieResult(schemaSupportant.VerifieDonnees(false), "Erreur : dépendance cyclique de liens possibles", false);
            Console.WriteLine("Ok");
            m_contexteDonnees.RejectChanges();

            Console.WriteLine("****Création d'un lien supportant cyclique niveau 2");
            //1 supporte déjà 2
            CLienReseau lienSupportant3 = GetLienReseau("TEST_SUPPORTANT_3", typeLienSupportant, site1, site2, extSite1, extSite2);
            CSchemaReseau schema3 = lienSupportant3.SchemaReseau;
            if ( schema3 == null )
            {
                schema3 = new CSchemaReseau(m_contexteDonnees);
                schema3.CreateNewInCurrentContexte();
                schema3.Libelle = lienSupportant3.Libelle;
                schema3.LienReseau = lienSupportant3;
            }
            //2 supporte 3
            eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.LienReseau = lienSupportant2;
            eltDependance.SchemaReseau = schema3;
            VerifieResult(eltDependance.VerifieDonnees(false), "Erreur lors de la création de la première dépendance", true);
            SaveData("Erreur lors de la création de la première dépendance", true);
            //3 supporte 1
            eltDependance = new CElementDeSchemaReseau(m_contexteDonnees);
            eltDependance.CreateNewInCurrentContexte();
            eltDependance.LienReseau = lienSupportant3;
            eltDependance.SchemaReseau = schemaSupportant;
            VerifieResult(eltDependance.VerifieDonnees(false), "Erreur : dépendance cyclique de liens possibles", false);
            Console.WriteLine("Ok");
            m_contexteDonnees.RejectChanges();

            Console.WriteLine("****Nettoyage");
            CResultAErreur result = CResultAErreur.True;
            result = lienSupportant3.Delete();
            if ( result ) result = lienSupportant2.Delete();
            if (result) result = lienSupportant.Delete();
            if (result) result = typeLienSupportant.Delete();
            if (result) result = typeLienSupporté.Delete();
            if (result) result = site1.Delete();
            if (result) result = site2.Delete();
            if ( result ) result = m_contexteDonnees.SaveAll(true);
            if (!result)
            {
                result.EmpileErreur("Erreur nettoyage");
                Console.WriteLine(result.Erreur.ToString());
            }
        }

        /*
        /// <summary>
        /// Vérifie que les cablages se créent bien sur les liaisons,
        /// et que tout est ok sur ces cablages
        /// CspvLiai_Cablequ
        /// CSpvCablequ
        /// CSpvCablequ_equip
        /// CSpvLienAccesTransmission
        /// </summary>
        [Test]
        public void TestCréationCablagesLiaisons()
        {
            Console.WriteLine("Création du jeu de test");
            CTypeLienReseau typeLien = GetTypeLienReseau("TEST_1", typeof(CSite), typeof(CSite), true );
            CSite site1 = GetSite("TEST_SITE1");
            CExtremiteLienSurSite extSite1 = GetExtremiteSite ( site1, "S1EXT1");
            CSite site2 = GetSite("TEST_SITE2");
            CExtremiteLienSurSite extSite2 = GetExtremiteSite(site2, "S2EXT1");
            CLienReseau lien = GetLienReseau("TEST_LIEN1", typeLien, site1, site2, extSite1, extSite2 );
            CSchemaReseau schema = lien.GetSchemaReseauCreateIfNull();
            VerifieResult(CObjetDonneeAIdNumerique.Delete ( schema.ElementsDeSchema, true ),
                "Erreur lors du vidage du schéma",
                 true);
            GetSiteInSchema ( schema, site1 );
            SaveData("Erreur création jeu de test", true);


            CEquipementLogique eqpt1 = GetEquipement ( site1, "TESt_EQPT1");
            GetEquipementInSchema ( schema, eqpt1 );
            Console.WriteLine("****Ajout d'un équipement au schéma du lien");
            SaveData("Erreur à la sauvegarde du schéma de lien", true);
            //Vérifie que le cable est créé
            
            CSpvCablequ cablage = new CSpvCablequ(m_contexteDonnees);
            if ( !cablage.ReadIfExists ( new CFiltreData ( CSchemaReseau.c_champId+"=@1",
                schema.Id ) ))
                DoErreur("Cablage non créé");

            //Vérifie que la liaison est créée
            CSpvLiai liaiSpv = CSpvLiai.GetObjetSpvFromObjetTimos(lien);
            if (liaiSpv == null)
                DoErreur("Liaison SPV non créé");
            //Vérifie que la liaison est liée au cablage
            
            CListeObjetsDonnees lstCablages = liaiSpv.RelationsCablages;
            if (lstCablages.Count == 0)
                DoErreur("Liaison SPV non liée au cablage");
            if (lstCablages.Count != 1)
                DoErreur("Liaison SPV liée à trop de cablages");
            CSpvLiai_Cablequ liaiCableq = lstCablages[0] as CSpvLiai_Cablequ;
            if (!cablage.Equals(liaiCableq.Cablage))
                DoErreur("Liaison SPV non liée au cablage");

            //Vérifie que le cablage ne contient qu'un équipement et que c'est le bon
            
            CSpvEquip spvEquip1 = CSpvEquip.GetObjetSpvFromObjetTimos ( eqpt1 );
            if ( spvEquip1 == null )
                DoErreur("Equipement SPV non créé");
            CListeObjetsDonnees equipementsDuCablage = cablage.RelationsEquipements;
            if ( equipementsDuCablage.Count == 0 )
                DoErreur("Pas d'équipements dans le cablage");
            if ( equipementsDuCablage.Count != 1 )
                DoErreur("Trop d'équipements dans le cablage");
            if ( !spvEquip1.Equals ( (equipementsDuCablage[0] as CSpvCablequ_Equip).SpvEquip ))
                DoErreur("L'équipement dans le cablage n'est pas correct");
            Console.WriteLine("OK");

            //Ajout d'un deuxième équipement au cablage
            
            Console.WriteLine("****Ajout d'un deuxième équipement au cablage");
            CEquipementLogique eqpt2 = GetEquipement(site1 , "Test_EQPT2");
            GetEquipementInSchema(schema, eqpt2);
            SaveData("Erreur lors de l'ajout du second équipement", true);
            equipementsDuCablage = cablage.RelationsEquipements;
            //Vérifie qu'on a bien les deux équipements dans le cablage
            if (equipementsDuCablage.Count != 2)
                DoErreur("Le nombre d'équipement du cablage est incorrect");
            equipementsDuCablage.Filtre = new CFiltreData(CSpvCablequ_Equip.c_champEQUIP_ID + "=@1",
                spvEquip1.Id);
            if (equipementsDuCablage.Count == 0)
                DoErreur("L'équipement 1 n'est pas dans le cablage");
            CSpvEquip spvEquip2 = CSpvEquip.GetObjetSpvFromObjetTimos(eqpt2);
            if (spvEquip2 == null)
                DoErreur("L'équipement 2 n'a pas été créé dans SPV");
            equipementsDuCablage.Filtre = new CFiltreData(CSpvCablequ_Equip.c_champEQUIP_ID + "=@1",
                spvEquip2.Id);
            if (equipementsDuCablage.Count == 0)
                DoErreur("L'équipement 2 n'est pas dans le cablage");
            Console.WriteLine("OK");

            Console.WriteLine("Ajout d'un lien entre les deux équipements");
            CTypeLienReseau typeLienCablage = GetTypeLienReseau("TESt_CABLAGE",
                typeof(CEquipementLogique),
                typeof(CEquipementLogique),
                false);
            CPort portUtilise = GetTypeEquipementTest().Ports[0] as CPort;
            CLienReseau lienCablage = GetLienReseau("Test_lien 1-2",
                typeLienCablage,
                eqpt1, eqpt2,
                portUtilise,
                portUtilise);
            GetLienInSchema(schema, lienCablage);
            SaveData("Erreur lors de la sauvegarde du lien entre les équipements", true);
            //Vérifie que le cablage contient bien le lien
            CListeObjetsDonnees lstLiensCablage = cablage.LiensAccesTransmissions;
            if (lstLiensCablage.Count == 0)
                DoErreur("Pas de lien dans le cablage");
            if (lstLiensCablage.Count > 1)
                DoErreur("Trop de lien dans le cablage");
            CSpvLienAccesTransmission accesTrans = lstLiensCablage[0] as CSpvLienAccesTransmission;
            if (accesTrans.AccesTransOne.NomAcces != portUtilise.Libelle)
                DoErreur("Mauvais lien de transmission (pas sur le port de l'équipement 1)");
            if (accesTrans.AccesTransTwo.NomAcces != portUtilise.Libelle)
                DoErreur("Mauvais lien de transmission ( pas sur le port de l'équipement 2)");

 

            Console.WriteLine("Nettoyage");

            CResultAErreur result = CResultAErreur.True;
            if (result)
                result = lienCablage.Delete();
            if (result)
                result = typeLienCablage.Delete();
            if ( result )
                result = lien.Delete();
            if ( result )
                result = eqpt1.Delete();
            if (result)
                result = eqpt2.Delete();
            if ( result )
                result = site1.Delete();
            if ( result )
                result = site2.Delete();
            if ( result )
                result = typeLien.Delete();
            if ( result )
                SaveData("Erreur nettoyage", true );
            if ( !result )
                DoErreur(result.Erreur.ToString() );
        }*/

        /*
        /// <summary>
        /// Test de base sur les services :
        /// Création d'un schéma supervisé, vérifie que le service est bien créé
        /// Modification du libellé du service
        /// Tests des dépendances aux sites
        /// Tests des dépendances aux liaisons
        /// Tests des dépendances aux cablages
        /// </summary>
        [Test]
        public void TestSchemaEtService()
        {
            string strLibSchemaTest = "TEST_SCHEMA1";
            Console.WriteLine("****Création du jeu de test");
            CTypeSchemaReseau typeSchema = GetTypeSchema("TEST_SERVICE_1", true);
            CSchemaReseau schema = GetSchema(strLibSchemaTest, typeSchema);
            CObjetDonneeAIdNumerique.Delete ( schema.ElementsDeSchema, true );
            SaveData("Erreur lors de la sauvegarde du schéma", true);
            Console.WriteLine("OK");

            //vérifie la modification du libelle
            Console.WriteLine("****Modification du libellé du service");
            schema.Libelle = "TEST_SCHEMA1B";
            SaveData("Erreur sauvegarde modif libellé", true);
            CSpvSchemaReseau service = CSpvSchemaReseau.GetObjetSpvFromObjetTimos(schema);
            if (service == null) DoErreur("Pas de service SPV");
            if (service.Libelle != "TEST_SCHEMA1B") DoErreur("Erreur synchro libellé du service");
            schema.Libelle = strLibSchemaTest;
            SaveData("Erreur restauration libellé", true);
            service.Refresh();
            if (service.Libelle != strLibSchemaTest) DoErreur("Erreur synchro libellé du service (2)");
            Console.WriteLine("Ok");

            //Vérifie les dépendances aux sites
            Console.WriteLine("****Vérifie la dépendance aux site");
            CSite site1 = GetSite("TEST_SITE1");
            CSite site2 = GetSite("TEST_SITE2");
            SaveData("Erreur lors de la sauvegarde des sites", true);
            CElementDeSchemaReseau eltSite1 = GetSiteInSchema(schema, site1);
            CElementDeSchemaReseau eltSite2 = GetSiteInSchema(schema, site2);
            SaveData("Erreur sauvegarde Dépendance au site", true);
            CListeObjetsDonnees depsSites = service.DependancesSites;
            if (depsSites.Count != 2)
                DoErreur("Mauvaise dépendance au site " + depsSites.Count.ToString() + " attendu 2");
            //vérifie qu'on a la dépendance à chaque site
            CSpvSite spvSite = CSpvSite.GetObjetSpvFromObjetTimos(site1);
            if (spvSite == null) DoErreur("Pas de Site 1 SPV");
            depsSites.Filtre = new CFiltreData(CSpvService_DependanceSite.c_champSITE_ID + "=@1",
                spvSite.Id);
            if (depsSites.Count == 0)
                DoErreur("Pas de dépendance au site 1");
            CSpvService_DependanceSite depSite = depsSites[0] as CSpvService_DependanceSite;
            //vérifie les sources
            if (depSite.Sources.Count == 0)
                DoErreur("Aucune source pour la dépendance au site 1");
            if (depSite.Sources.Count > 1)
                DoErreur("Trop de sources pour la dépendance au site 1");
            CSpvService_DependanceSite_Source source = depSite.Sources[0] as CSpvService_DependanceSite_Source;
            if (!source.ElementDeSchemaSource.Equals(eltSite1))
                DoErreur("Mauvaise source pour la dépendance au site 1");
            spvSite = CSpvSite.GetObjetSpvFromObjetTimos ( site2 ) ;
            if ( spvSite == null ) DoErreur("Pas de Site 2 SPV");
            depsSites.Filtre = new CFiltreData(CSpvService_DependanceSite.c_champSITE_ID + "=@1",
                spvSite.Id);
            if (depsSites.Count == 0)
                DoErreur("Pas de dépendance au site 2");
            depSite = depsSites[0] as CSpvService_DependanceSite;
            //vérifie les sources
            if (depSite.Sources.Count == 0)
                DoErreur("Aucune source pour la dépendance au site 2");
            if (depSite.Sources.Count > 1)
                DoErreur("Trop de sources pour la dépendance au site 2");
            source = depSite.Sources[0] as CSpvService_DependanceSite_Source;
            if (!source.ElementDeSchemaSource.Equals(eltSite2))
                DoErreur("Mauvaise source pour la dépendance au site 2");
            Console.WriteLine("OK");

            //Vérifie que la suppression du site du schéma supprime la source
            //Le schéma ne contient plus que le site 2
            Console.WriteLine("****Suppression du site du schéma");
            VerifieResult(eltSite1.Delete(), "Erreur suppression site1 du schéma", true);
            if ( depsSites.Count != 1 )
                DoErreur("Nombre de dépendances incorrectes pour le schéma");
            depSite = depsSites[0] as CSpvService_DependanceSite;
            spvSite = CSpvSite.GetObjetSpvFromObjetTimos ( site2 );
            if ( depSite.SpvSite != spvSite )
                DoErreur("Mauvaise dépendance dans le schéma");
            Console.WriteLine("OK");

            //Vérifie que l'ajout d'un lien dans un schéma implique une dépendance du
            //schéma au lien
            Console.WriteLine("****Ajout d'un lien dans le schéma");
            CTypeLienReseau typeLien = GetTypeLienReseau("TEST_LIEN", typeof(CSite), typeof(CSite), true );
            eltSite1 = GetSiteInSchema ( schema, site1 );
            CExtremiteLienSurSite ext1 = GetExtremiteSite ( site1, "S1EXT1");
            CExtremiteLienSurSite ext2 = GetExtremiteSite ( site2, "S2EXT1");
            CLienReseau lien = GetLienReseau("LIEN_TEST", typeLien, site1, site2, ext1, ext2);
            if (lien.SchemaReseau != null)
                VerifieResult(lien.SchemaReseau.Delete(), "Erreur lors de la suppression du schéma de lien", true);
            CElementDeSchemaReseau eltLien = GetLienInSchema ( schema, lien );
            SaveData ( "Erreur ajout de lien dans le schéma", true );
            //Vérifie que la dépendance au lien existe
            CListeObjetsDonnees depsLiens = service.DependancesLiaisons;
            if ( depsLiens.Count != 1 )
                DoErreur("Nombre de dépendances aux liens incorrecte");
            CSpvService_DependanceLiaison depLiaison = depsLiens[0] as CSpvService_DependanceLiaison;
            CSpvLiai spvLiai = CSpvLiai.GetObjetSpvFromObjetTimos ( lien );
            if ( spvLiai == null ) DoErreur("Pas de lien SPV");
            if ( depLiaison.SpvLiai != spvLiai )
                DoErreur("Mauvaise dépendance au lien");
            Console.WriteLine("Ok");

            //Ajout d'une référence au site 3 dans la liaison
            ///Le service ne devient pas dépendant du site 3 car il s'agit d'un site supportant
            Console.WriteLine("***Vérifie que les sites du lien ne sont pas dans les dépendances du service");
            CSchemaReseau schemaDeLien = lien.GetSchemaReseauCreateIfNull();
            //Vide le schéma du lien
            VerifieResult ( 
                CObjetDonneeAIdNumerique.Delete ( schemaDeLien.ElementsDeSchema ),
                "Erreur vidage du schéma du lien", true );
            GetSiteInSchema(schemaDeLien, site1);
            GetSiteInSchema(schemaDeLien, site2);
            CSite site3 = GetSite("TESt_SITE_3");
            CElementDeSchemaReseau eltSite3 = GetSiteInSchema ( schemaDeLien , site3);
            SaveData("Erreur ajout du site3 dans le lien", true );
            depsSites = service.DependancesSites;
            if ( depsSites.Count != 2 )
                DoErreur("Mauvais nombre de dépendance du service aux sites ("+depsSites.Count+" au lieu de 3");
            Console.WriteLine("OK");

            //Ajout d'un cablage dans le schéma du lien.
            Console.WriteLine("****test dépendance du service au cablage de lien");
            CEquipementLogique eqptSite1 = GetEquipement(site1, "TEST_EQPT1");
            CElementDeSchemaReseau eltEqptSite1 = GetEquipementInSchema(schemaDeLien, eqptSite1);
            SaveData("Erreur ajout de l'équipement dans le schéma du lien", true);
            spvSite = CSpvSite.GetObjetSpvFromObjetTimos(site1);
            //Vérifie que le cablage est créé
            CSpvCablequ cablage = new CSpvCablequ(m_contexteDonnees);
            if (!cablage.ReadIfExists(new CFiltreData(CSchemaReseau.c_champId + "=@1 and " +
                CSpvCablequ.c_champSITE_ID + "=@2",
                schemaDeLien.Id,
                spvSite.Id)))
                DoErreur("Cablage non créé");
            //Vérifie que le service est bien dépendant du cablage
            CListeObjetsDonnees depsCablage = service.DependancesCablages;
            if (depsCablage.Count != 1)
                DoErreur("Mauvais nombre de dépendances de cablage dans le service");
            CSpvService_DependanceCablage depCablage = depsCablage[0] as CSpvService_DependanceCablage;
            if (depCablage.Cablage != cablage)
                DoErreur("Mauvaise dépendance au cablage");
            Console.WriteLine("Ok");

            ///Vérification de la dépendance avec un lien supportant
            //Création d'un lien supportant
            Console.WriteLine("****test dépendance de lien supportant");
            GetSupport(typeLien, typeLien);
            CExtremiteLienSurSite ext3 = GetExtremiteSite ( site3, "S3EXT1");
            CLienReseau lienSupportant = GetLienReseau("TESt_LIEN_SUPPORT",typeLien,
                site1,
                site3,
                ext1, ext3);
            CSchemaReseau schemaSupportant = lienSupportant.SchemaReseau;
            if (schemaSupportant != null)
                VerifieResult(schemaSupportant.Delete(), "Erreur purge du schéma du lien supportant", true);
            //Le lien 1-3 devient supportant du lien 1/2
            GetLienInSchema(schemaDeLien, lienSupportant);
            SaveData("Erreur sauvegarde du lien supportant", true);
            depsLiens = service.DependancesLiaisons;
            if (depsLiens.Count != 2)
                DoErreur("Mauvaises dépendance du service avec les lien");
            spvLiai = CSpvLiai.GetObjetSpvFromObjetTimos(lienSupportant);
            if (spvLiai == null) DoErreur("Pas de lien supportant");
            depsLiens.Filtre = new CFiltreData(CSpvService_DependanceLiaison.c_champLIAI_ID + "=@1",
                spvLiai.Id);
            if (depsLiens.Count == 0)
                DoErreur("Pas de dépendance avec le lien supportant");
            Console.WriteLine("OK");

            //Test dépendance avec un cablage de supportant
            Console.WriteLine("******Test dépendance cablage supportant");
            schemaSupportant = lienSupportant.GetSchemaReseauCreateIfNull();
            GetSiteInSchema(schemaSupportant, site1);
            GetSiteInSchema(schemaSupportant, site3);
            GetEquipementInSchema(schemaSupportant, eqptSite1 );
            SaveData("Erreur sauvegarde eqpt dans supportant", true);
            depsCablage = service.DependancesCablages;
            spvSite = CSpvSite.GetObjetSpvFromObjetTimos(site1);
            if (!cablage.ReadIfExists(new CFiltreData(CSchemaReseau.c_champId + "=@1 and " +
                CSpvCablequ.c_champSITE_ID + "=@2",
                schemaSupportant.Id,
                spvSite.Id)))
                DoErreur("Pas de cablage pour le supportant");
            depsCablage.Filtre = new CFiltreData(CSpvService_DependanceCablage.c_champCABLEQU_ID + "=@1",
                cablage.Id);
            if (depsCablage.Count == 0)
                DoErreur("Pas de dépendance du service au cablage du supportant");
            Console.WriteLine("Ok");
            


            ///Suppression du lien dans le service. Le service n'est alors dépendant que du site 1 et 2 
            ///et plus du 3 ni de la liaison
            Console.WriteLine("****Suppression de la liaison dans le service, plus de dépendance !");
            VerifieResult ( eltLien.Delete(), "Erreur suppression du lien dans le service", true );
            depsCablage = service.DependancesCablages;
            if (depsCablage.Count != 0)
                DoErreur("Le service reste dépendant d'un cablage");
            depsLiens = service.DependancesLiaisons;
            if (depsLiens.Count != 0)
                DoErreur("Le service reste dépendant de liaisons");
            Console.WriteLine("Ok");
            
            



            Console.WriteLine("****Nettoyage");
            CResultAErreur result = CResultAErreur.True;
            if(  result )
                result = schema.Delete();
            if ( result )
                result = lien.Delete();
            if (result)
                result = lienSupportant.Delete();
            if (result)
                result = eqptSite1.Delete();
            if (result)
                result = site1.Delete();
            if (result)
                result = site2.Delete();
            if ( result )
                result = site3.Delete();
            if (result)
                result = typeSchema.Delete();
            if (result)
                SaveData("Erreur lors du nettoyage", true);
            if (!result)
                DoErreur(result.Erreur.ToString());
        }*/

        /// <summary>
        /// Vérifie que les dépéndances sont correctes avec l'inclusion de schéma, jusqu'à quatre niveaux
        /// </summary>
        [Test]
        public void TestDependancesSchemas()
        {
            Console.WriteLine("****Création du jeu de test");
            ///Crée quatre schémas, chacun contenant un site (1, 2, 3 et 4)
            CTypeSchemaReseau typeSchemaNonSPV = GetTypeSchema("TEST_NON_SPV", false);
            CTypeSchemaReseau typeSchemaSPV = GetTypeSchema("TEST_SPV", false);
            CSite site1 = GetSite("TEST_SITE1");
            CSite site2 = GetSite("TEST_SITE2");
            CSite site3 = GetSite("TEST_SITE_3");
            CSite site4 = GetSite("TEST_SITE_4");
            CExtremiteLienSurSite ext1 = GetExtremiteSite(site1, "S1E1");
            CExtremiteLienSurSite ext2 = GetExtremiteSite(site2, "S2E1");
            CExtremiteLienSurSite ext3 = GetExtremiteSite(site3, "S3E1");
            CExtremiteLienSurSite ext4 = GetExtremiteSite(site4, "S4E1");
            CSchemaReseau schema1 = GetSchema("TEST_SPV1", typeSchemaSPV);
            CSchemaReseau schema2 = GetSchema("TEST_SPV2", typeSchemaSPV);
            CSchemaReseau schema3 = GetSchema("TEST_SPV3", typeSchemaSPV);
            CSchemaReseau schema4 = GetSchema("TEST_SPV4", typeSchemaSPV);
            GetSiteInSchema(schema1, site1);
            GetSiteInSchema(schema2, site2);
            GetSiteInSchema(schema3, site3);
            GetSiteInSchema(schema4, site4);

            SaveData("Erreur création jeu de test", true);
            Console.WriteLine("OK");


            Console.WriteLine("****Ménage");
            CResultAErreur result = CResultAErreur.True;
            if (result)
                result = schema1.Delete();
            if (result)
                result = schema2.Delete();
            if (result)
                result = schema3.Delete();
            if (result)
                result = site1.Delete();
            if (result)
                result = site2.Delete();
            if (result)
                result = site3.Delete();
            if (result)
                result = typeSchemaNonSPV.Delete();
            if (result)
                result = typeSchemaSPV.Delete();
            if (result)
                SaveData("Erreur ménage", true);
            if (!result)
                DoErreur(result.Erreur.ToString());
            Console.WriteLine("OK");
        }

    }
}
