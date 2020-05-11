using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

using sc2i.common;
using sc2i.workflow;
using sc2i.process;
using sc2i.custom;
using sc2i.documents;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.serveur;

using timos.data;
using timos.data.version;
using timos.acteurs;
using timos.securite;
using timos.data.workflow.ConsultationHierarchique;
using timos.data.projet.gantt;
using timos.data.vuephysique;
using timos.data.composantphysique;
using timos.data.projet.Contraintes;
using sc2i.data.dynamic.NommageEntite;
using timos.data.snmp;
using timos.data.supervision;
using timos.data.snmp.Proxy;
using timos.data.commandes;
using sc2i.process.Mail;
using sc2i.data.dynamic.unite;
using timos.data.projet;
using timos.data.securite;
using timos.data.equipement.consommables;
using sc2i.process.workflow;
using timos.data.projet.besoin;
using futurocom.sig;
using timos.snmp.polling;
using sc2i.process.workflow.gels;
using futurocom.sig.cartography;

namespace timos.serveur
{
	/// <summary>
	/// Description résumée de CMAJ_StructureBase.
	/// </summary>
	public class CTimosStructureBase : IStructureDataBase
	{

		//---------------------------------------------------------------------------
		public int GetLastVersion()
		{
			return 27;
		}
		//---------------------------------------------------------------------------
		public C2iDataBaseUpdateOperationList GetListeTypeOfVersion(int nVersion)
		{
			C2iDataBaseUpdateOperationList lstRtr = new C2iDataBaseUpdateOperationList();
			switch (nVersion)
			{
				case 1: lstRtr = UpdateVersion1(); break;
				case 2: lstRtr = UpdateVersion2(); break;
				case 3: lstRtr = UpdateVersion3(); break;
				case 4: lstRtr = UpdateVersion4(); break;
				case 5: lstRtr = UpdateVersion5(); break;
				case 6: lstRtr = UpdateVersion6(); break;
				case 7: lstRtr = UpdateVersion7(); break;
				case 8: lstRtr = UpdateVersion8(); break;
				case 9: lstRtr = UpdateVersion9(); break;
				case 10: lstRtr = UpdateVersion10(); break;
                case 11: lstRtr = UpdateVersion11(); break;
                case 12: lstRtr = UpdateVersion12(); break;
                case 13: lstRtr = UpdateVersion13(); break;
                case 14: lstRtr = UpdateVersion14(); break;
                case 15: lstRtr = UpdateVersion15(); break;
                case 16: lstRtr = UpdateVersion16(); break;
                case 17: lstRtr = UpdateVersion17(); break;
                case 18: lstRtr = UpdateVersion18(); break;
                case 19: lstRtr = UpdateVersion19(); break;
                case 20: lstRtr = UpdateVersion20(); break;
                case 21: lstRtr = UpdateVersion21(); break;
                case 22: lstRtr = UpdateVersion22(); break;
                case 23: lstRtr = UpdateVersion23(); break;
                case 24: lstRtr = UpdateVersion24(); break;
                case 25: lstRtr = UpdateVersion25(); break;
                case 26: lstRtr = UpdateVersion26(); break;
                case 27: lstRtr = UpdateVersion27(); break;
				default:
					break;
			}

			return lstRtr;
		}

		//------------------------------- V 1 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion1()
		{
		    C2iDataBaseUpdateOperationList lstV1 = new C2iDataBaseUpdateOperationList();

			#region sc2i.data et sc2i.data.dynamic
			lstV1.Add(typeof(CVariableSurObjet));

			lstV1.Add(typeof(CFormulaire));

			lstV1.Add(typeof(CFiltreDynamiqueInDb));

			lstV1.Add(typeof(CGroupeUtilisateursSynchronisation));

			lstV1.Add(typeof(C2iStructureExportInDB));

			lstV1.Add(typeof(CTypeDonneeCumulee));

			lstV1.Add(typeof(CParametreSynchronisationInDb));

			lstV1.Add(typeof(CDonneeCumulee));

			lstV1.Add(typeof(CChampCalcule));

			lstV1.Add(typeof(CChampCustom));

			lstV1.Add(typeof(CValeurChampCustom));

			lstV1.Add(typeof(CValeurVariableSurObjet));

			lstV1.Add(typeof(CRelationGroupeUtilisateursSynchro_Utilisateurs));

			lstV1.Add(typeof(CRelationRoleActeur_GroupeActeur));

			lstV1.Add(typeof(CRelationFormulaireChampCustom));

			lstV1.Add(typeof(CGroupeUtilisateursSynchronisation));
			#endregion

			#region sc2i.document
			lstV1.Add(typeof(CCategorieGED));

			lstV1.Add(typeof(CRelationDocumentGED_Categorie));

			lstV1.Add(typeof(CDocumentGED));

			lstV1.Add(typeof(CRelationCategorieGED_ChampCustom));

			lstV1.Add(typeof(CRelationCategorieGED_Formulaire));

			lstV1.Add(typeof(CRelationDocumentGED_ChampCustomValeur));

			lstV1.Add(typeof(CRelationElementToDocument));

			lstV1.Add(typeof(C2iCategorieRapportCrystal));

			lstV1.Add(typeof(C2iRapportCrystal));
			#endregion

			#region sc2i.process
			lstV1.Add(typeof(CGroupeParametrage));

			lstV1.Add(typeof(CProcessInDb));

			lstV1.Add(typeof(CSynchronismeDonnees));

			lstV1.Add(typeof(CEvenement));

			lstV1.Add(typeof(CProcessEnExecutionInDb));

			lstV1.Add(typeof(CComportementGenerique));

			lstV1.Add(typeof(CRelationDefinisseurComportementInduit));

			lstV1.Add(typeof(CRelationElementComportement));

			lstV1.Add(typeof(CHandlerEvenement));

			lstV1.Add(typeof(CBesoinInterventionProcess));
			#endregion

			#region sc2i.workflow
			lstV1.Add(typeof(CGrilleGenerique));

			lstV1.Add(typeof(CListeEntites));

			lstV1.Add(typeof(CRelationListeEntites_Entite));

			lstV1.Add(typeof(CPostIt));

			lstV1.Add(typeof(CTachePlanifiee));

			lstV1.Add(typeof(CRelationTachePlanifieeProcess));

			lstV1.Add(typeof(CRelationTachePlanifieeTypeDonneeCumulee));
			#endregion

			#region	Calendrier
			lstV1.Add(typeof(CCalendrier));

			lstV1.Add(typeof(CCalendrier_JourParticulier));

			lstV1.Add(typeof(CHoraireJournalier));

			lstV1.Add(typeof(CHoraireJournalier_Tranche));

			lstV1.Add(typeof(CTypeOccupationHoraire));
			#endregion

			#region Agenda
			lstV1.Add(typeof(CTypeEntreeAgenda));

			lstV1.Add(typeof(CRoleSurEntreeAgenda));

			lstV1.Add(typeof(CRelationTypeEntreeAgenda_ChampCustom));

			lstV1.Add(typeof(CRelationTypeEntreeAgenda_Formulaire));

            lstV1.Add(typeof(CRelationTypeEntreeAgenda_TypeElementAAgenda));

			lstV1.Add(typeof(CEntreeAgenda));

			lstV1.Add(typeof(CRelationEntreeAgenda_ElementAAgenda));

			lstV1.Add(typeof(CDesctivationEntreeAgendaCyclique));

			lstV1.Add(typeof(CEntreeAgenda_SynchroExt));

			lstV1.Add(typeof(CRelationEntreeAgenda_ChampCustom));
			#endregion

			#region Dossier
			lstV1.Add(typeof(CTypeDossierSuivi));

			lstV1.Add(typeof(CRelationTypeDossierSuivi_ChampCustom));

			lstV1.Add(typeof(CRelationTypeDossierSuivi_Formulaire));

			lstV1.Add(typeof(CRelationTypeDossierSuivi_TypeElement));

			lstV1.Add(typeof(CDossierSuivi));

			lstV1.Add(typeof(CRelationDossierSuivi_ChampCustom));

			lstV1.Add(typeof(CRelationDossierSuivi_Element));
			#endregion

			#region Sécurité
			lstV1.Add(typeof(CGroupeRestrictionSurType));

			lstV1.Add(typeof(CRestrictionChampCustom));

			lstV1.Add(typeof(CTypeEntiteOrganisationnelle));

			lstV1.Add(typeof(CRelationTypeEO_ChampCustom));

			lstV1.Add(typeof(CRelationTypeEO_Formulaire));

			lstV1.Add(typeof(CEntiteOrganisationnelle));

			lstV1.Add(typeof(CRelationEO_ChampCustom));

			lstV1.Add(typeof(CProfilUtilisateur));

			lstV1.Add(typeof(CProfilUtilisateur_Restriction));

			lstV1.Add(typeof(CRelationUtilisateur_Profil));

			lstV1.Add(typeof(CRelationElement_EO));

			lstV1.Add(typeof(CRelationUtilisateur_Profil_EO));

			lstV1.Add(typeof(CProfilUtilisateur_Inclusion));
			#endregion

			//custom
			lstV1.Add(typeof(CMenuCustom));

			#region Acteurs
			lstV1.Add(typeof(CCivilite));

			lstV1.Add(typeof(CActeur));

			lstV1.Add(typeof(CRelationActeurUtilisateur_Droit));

			lstV1.Add(typeof(CGroupeActeur));

			lstV1.Add(typeof(CRelationGroupeActeur_ChampCustom));

			lstV1.Add(typeof(CRelationGroupeActeur_Formulaire));

			lstV1.Add(typeof(CRelationGroupeActeurNecessite));

			lstV1.Add(typeof(CRelationGroupeActeur_GroupeActeur));

			lstV1.Add(typeof(CRelationActeur_ChampCustom));

			lstV1.Add(typeof(CRelationActeur_GroupeActeur));

			lstV1.Add(typeof(CDonneesActeurUtilisateur));

			lstV1.Add(typeof(CDonneesActeurClient));
			#endregion

			//m_cacheLstV1.Add(typeof(CTestSecurite));

			#region Sites
			lstV1.Add(typeof(CTypeSite));

			lstV1.Add(typeof(CSite));

			lstV1.Add(typeof(CRelationTypeSite_TypeSite));

			lstV1.Add(typeof(CRelationSite_ChampCustom));

			lstV1.Add(typeof(CRelationTypeSite_ChampCustom));

			lstV1.Add(typeof(CRelationTypeSite_Formulaire));
			#endregion

			#region Equipement
			lstV1.Add(typeof(CFamilleEquipement));

			lstV1.Add(typeof(CTypeEquipement));

			lstV1.Add(typeof(CRelationTypeEquipement_Heritage));

			lstV1.Add(typeof(CRelationTypeEquipement_ChampCustom));

			lstV1.Add(typeof(CRelationTypeEquipement_Formulaire));

			lstV1.Add(typeof(CEquipement));

			lstV1.Add(typeof(CRelationEquipement_ChampCustom));

			lstV1.Add(typeof(CRelationFamilleEquipement_ChampCustom));

			lstV1.Add(typeof(CRelationFamilleEquipement_Formulaire));

			lstV1.Add(typeof(CRelationTypeEquipement_ChampCustomValeur));

			lstV1.Add(typeof(CRelationTypeEquipement_TypesIncluables));

			lstV1.Add(typeof(CDonneesActeurFournisseur));

			lstV1.Add(typeof(CDonneesActeurConstructeur));

			lstV1.Add(typeof(CRelationTypeEquipement_Fournisseurs));

			lstV1.Add(typeof(CRelationTypeEquipement_Constructeurs));

			lstV1.Add(typeof(CTypeStock));

			lstV1.Add(typeof(CStock));

			lstV1.Add(typeof(CRelationTypeEquipement_TypeStock));

			lstV1.Add(typeof(CStatutEquipement));

			lstV1.Add(typeof(CMouvementEquipement));

			lstV1.Add(typeof(CRelationTypeEquipement_TypeRemplacement));
			#endregion

			#region Ressources et contraintes
			lstV1.Add(typeof(CTypeRessource));

			lstV1.Add(typeof(CRessourceMaterielle));

			lstV1.Add(typeof(CTypeContrainte));

			lstV1.Add(typeof(CContrainte));

			lstV1.Add(typeof(CRelationContrainte_Ressource));

			lstV1.Add(typeof(CRelationTypeContrainte_TypeRessource));

			lstV1.Add(typeof(CRelationTypeRessource_Formulaire));

			lstV1.Add(typeof(CRelationTypeContrainte_Formulaire));

			lstV1.Add(typeof(CRelationRessource_ChampCustomValeur));

			lstV1.Add(typeof(CRelationTypeRessource_ChampCustom));

			lstV1.Add(typeof(CRelationContrainte_ChampCustom));

			lstV1.Add(typeof(CRelationTypeContrainte_ChampCustom));

			lstV1.Add(typeof(CAttributRessource));

			lstV1.Add(typeof(CAttributContrainte));

			lstV1.Add(typeof(CAttributTypeContrainte));

			lstV1.Add(typeof(CMouvementRessource));
			#endregion

			#region Système de Coordonnées
			lstV1.Add(typeof(CRelationSystemeCoordonnees_FormatNumerotation));

			lstV1.Add(typeof(CSystemeCoordonnees));

			lstV1.Add(typeof(CFormatNumerotation));

			lstV1.Add(typeof(CUniteCoordonnee));

			lstV1.Add(typeof(CParametrageSystemeCoordonnees));

			lstV1.Add(typeof(CParametrageNiveau));
			#endregion

			#region Tickets
			lstV1.Add(typeof(CQualificationTicket));

			lstV1.Add(typeof(CTypeTicket));

			lstV1.Add(typeof(CTicket));

			lstV1.Add(typeof(CPhaseTicket));

			lstV1.Add(typeof(CRelationTicket_Site));

			lstV1.Add(typeof(CRelationTicket_EOconcernees));

			lstV1.Add(typeof(CUrgenceTicket));

			lstV1.Add(typeof(CDependanceTicket));

			lstV1.Add(typeof(CRelationTicket_ChampCustomValeur));

			lstV1.Add(typeof(CRelationTypeTicket_ChampCustom));

			lstV1.Add(typeof(CRelationTypeTicket_Formulaire));

			lstV1.Add(typeof(COrigineTicket));

			lstV1.Add(typeof(CTypeTicketContrat));

			lstV1.Add(typeof(CEtatCloture));

			lstV1.Add(typeof(CCauseGel));

			lstV1.Add(typeof(CGel));

			lstV1.Add(typeof(CRelationTypePhaseTicket_TypeIntervention));

			lstV1.Add(typeof(CLienTypePhase));

			lstV1.Add(typeof(CRelationPhase_ChampCustomValeur));

			lstV1.Add(typeof(CHistoriqueTicket));

			lstV1.Add(typeof(CActeursSelonProfil));

			lstV1.Add(typeof(CTypePhase));

			lstV1.Add(typeof(CTypeTicket_TypePhase));

			lstV1.Add(typeof(CNotePhase));
			#endregion

			#region Interventions

            lstV1.Add(typeof(CTypeContrat));
			lstV1.Add(typeof(CContrat), CTypeContrat.c_champId);
			lstV1.Add(new DelegueMethodeMAJ(CreateTypeContrat));
			lstV1.Add(typeof(CContrat));

			lstV1.Add(typeof(CTypeIntervention));


			lstV1.Add(typeof(CTypeOperation));

			lstV1.Add(typeof(CRelationTypeIntervention_ChampCustom));

			lstV1.Add(typeof(CRelationTypeIntervention_Formulaire));

			lstV1.Add(typeof(CTypeIntervention_TypeOperation));

			lstV1.Add(typeof(CIntervention));

			lstV1.Add(typeof(CRelationIntervention_ChampCustom));

			lstV1.Add(typeof(COperation));

			lstV1.Add(typeof(CRelationOperation_ChampCustom));

			lstV1.Add(typeof(CTypeIntervention_ProfilIntervenant));

			lstV1.Add(typeof(CIntervention_Intervenant));

			lstV1.Add(typeof(CFractionIntervention));

			lstV1.Add(typeof(CIntervention_Ressource));

			#endregion

			lstV1.Add(typeof(CModeleTexte));

			lstV1.Add(typeof(CRemplacementEquipement));


			return lstV1;
		}

		//---------------------------------------------------------------------------		
		private void UpdateAllTables(C2iDataBaseUpdateOperationList lst, params Type[] typesANePasMettreAJour)
		{
			List<Type> lstTypesANePasMettreAJour = new List<Type>(typesANePasMettreAJour);
			using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
			{
				foreach (Type tp in CContexteDonnee.GetAllTypes())
					if (!lstTypesANePasMettreAJour.Contains(tp))
					lst.Add(tp);
			}
		}

		//------------------------------- V 2 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion2()
		{
		    C2iDataBaseUpdateOperationList lstV2 = new C2iDataBaseUpdateOperationList();


			// Procédure de mise à jour du type de contrat obligatoire
			lstV2.Add(typeof(CTypeContrat));
			lstV2.Add(typeof(CContrat), CTypeContrat.c_champId);
			UpdateAllTables(lstV2, typeof(CContrat));
			lstV2.Add(new DelegueMethodeMAJ(CreateTypeContrat));
			lstV2.Add(typeof(CContrat));

            return lstV2;
		}

		//------------------------------- V 3 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion3()
		{
		    C2iDataBaseUpdateOperationList lstV3 = new C2iDataBaseUpdateOperationList();
			
			lstV3.Add(typeof(CTypeOperation));
			lstV3.Add(typeof(COperation));
			lstV3.Add(typeof(CRemplacementEquipement));

			lstV3.Add(typeof(CColonneTableParametrable));
			lstV3.Add(typeof(CRelationTypeTableParametrable_ChampCustom));
			lstV3.Add(typeof(CRelationTypeTableParametrable_Formulaire));
			lstV3.Add(typeof(CRelationTableParametrable_ChampCustom));

			lstV3.Add(typeof(CVersionDonnees));
			lstV3.Add(typeof(CVersionDonneesObjet));
			lstV3.Add(typeof(CVersionDonneesObjetOperation));

			return lstV3;
		}

		//------------------------------- V 4 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion4()
		{
		    C2iDataBaseUpdateOperationList lstV4 = new C2iDataBaseUpdateOperationList();

			UpdateAllTables(lstV4);
			
			return lstV4;
		}

		//------------------------------- V 5 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion5()
		{
		    C2iDataBaseUpdateOperationList lstV5 = new C2iDataBaseUpdateOperationList();

			//Versions
			lstV5.Add(typeof(CVersionDonnees));
			lstV5.Add(typeof(CVersionDonneesObjet));
			lstV5.Add(typeof(CVersionDonneesObjetOperation));

			//Preventives
			lstV5.Add(typeof(CContrat_ListeOperations),CTypeIntervention.c_champId);
			lstV5.Add(CreationTypeInter);
			lstV5.Add(typeof(CContrat_ListeOperations));
			lstV5.Add(typeof(CContrat));

			//Version
			lstV5.Add(typeof(CIntervention));
			lstV5.Add(typeof(CIntervention_ListeOperations));

            // Autres
            lstV5.Add(typeof(CTypeTableParametrable));

			//Gestion des suppressions pour le versionning
			lstV5.Add(CreateChampDeleted);

			//Fin de zone pour l'ajout
			return lstV5;
		}

		//------------------------------- V 6 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion6()
		{
		    C2iDataBaseUpdateOperationList lstV6 = new C2iDataBaseUpdateOperationList();

			lstV6.Add(typeof(CAnomalieProjet));
			lstV6.Add(typeof(CTypeSite));
			lstV6.Add(typeof(CTypeEquipement));

			// AUDIT
            lstV6.Add(typeof(CTypeAuditVersion));
			lstV6.Add(typeof(CAuditVersion));
			lstV6.Add(typeof(CAuditVersionObjet));
			lstV6.Add(typeof(CAuditVersionObjetOperation));

            // Autres
            lstV6.Add(typeof(CEquipement));
            lstV6.Add(typeof(CRelationEquipement_ChampCustom));

			//Process (gestion de versions
			lstV6.Add(typeof(CProcessEnExecutionInDb));
			lstV6.Add(typeof(CVersionDonneesObjetOperation));

			lstV6.Add(typeof(CActiviteActeurResume));
			lstV6.Add(typeof(CRelationActiviteActeurResume_ChampCustomValeur));
			lstV6.Add(typeof(CActiviteActeur));

			lstV6.Add(typeof(CEvenement));

			//Fin de zone pour l'ajout
		
			
			return lstV6;
		}

		//------------------------------- V 7 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion7()
		{
		    C2iDataBaseUpdateOperationList lstV7 = new C2iDataBaseUpdateOperationList();

			UpdateAllTables(lstV7);

			return lstV7;
		}

		//------------------------------- V 8 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion8()
		{
		    C2iDataBaseUpdateOperationList lstV8 = new C2iDataBaseUpdateOperationList();
			


			lstV8.Add(CorrectionBugVersionChampsCustom);


			
			return lstV8;
		}

		//------------------------------- V 9 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion9()
		{
		    C2iDataBaseUpdateOperationList lstV9 = new C2iDataBaseUpdateOperationList();

			lstV9.Add(typeof(CVersionDonnees));

			return lstV9;
		}

		//------------------------------- V 10 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion10()
		{
		    C2iDataBaseUpdateOperationList lstV10 = new C2iDataBaseUpdateOperationList();
			
            lstV10.Add(typeof(CVersionDonnees));

			lstV10.Add(typeof(CActeur));
			lstV10.Add(typeof(CDonneesActeurUtilisateur));
			//CRYPTAGE DES MOTS DE PASSES
	    	lstV10.Add(CryptePasswords);


			return lstV10;
		}

		//------------------------------- V 11 ---------------------------------------
		public C2iDataBaseUpdateOperationList UpdateVersion11()
		{
		    C2iDataBaseUpdateOperationList lstV11 = new C2iDataBaseUpdateOperationList();

			lstV11.Add(typeof(CHandlerEvenement));

			lstV11.Add(typeof(CVersionDonneesObjetOperation));
			lstV11.Add(typeof(CAuditVersionObjetOperation));
			lstV11.Add(typeof(CAuditVersion));

			lstV11.Add(typeof(CProfilUtilisateur_Inclusion));
			lstV11.Add(typeof(CProfilUtilisateur));

			lstV11.Add(typeof(CEvenement));
			lstV11.Add(typeof(CHandlerEvenement));

			lstV11.Add(typeof(CCategorieVersionDonnees));
			lstV11.Add(typeof(CVersionDonnees));

            // Changements dans le module Ticket/Intervention/Opération
            lstV11.Add(typeof(CTypePhase_TypeOperation));
            lstV11.Add(typeof(COperation));
            lstV11.Add(typeof(CTypeOperation));
            lstV11.Add(ConvertitOperationsHeureEnDate);
            
            //Fin de zone pour l'ajout
           
			return lstV11;
		}


        //------------------------------- V 12 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion12()
        {
            C2iDataBaseUpdateOperationList lstV12 = new C2iDataBaseUpdateOperationList();

            // Début de la zone pour l'ajout
            // Caratéristiques
            lstV12.Add(typeof(CTypeCaracteristiqueEntite));
            lstV12.Add(typeof(CCaracteristiqueEntite));
            lstV12.Add(typeof(CRelationCaracteristiqueEntite_ChampCustom));
            lstV12.Add(typeof(CRelationTypeCaracteristiqueEntite_ChampCustom));
            lstV12.Add(typeof(CRelationTypeCaracteristiqueEntite_Formulaire));
			lstV12.Add(typeof(CChampCustom));
            lstV12.Add(typeof(CFormulaire));
            lstV12.Add(typeof(CFamilleSymbole));
            lstV12.Add(typeof(CSymboleDeBibliotheque));
            lstV12.Add(typeof(CSymbole));
            lstV12.Add(typeof(CDonneesActeurUtilisateur));

			lstV12.Add(typeof(CEquipementLogique));
			lstV12.Add(typeof(CRelationEquipementLogique_ChampCustom));
			lstV12.Add(typeof(CTypeEquipement));
			lstV12.Add(typeof(CEquipement));
            lstV12.Add(typeof(COperation));
			lstV12.Add(typeof(CTypeOperation));
            lstV12.Add(ConvertirToutesLesNotesDePhaseEnOperations);

            //Fin de zone pour l'ajout

            //A supprimer pour passer en version 12
            //lstV12.Add(new C2iDataBaseUpdateOperationNoSetVersionBase());

            return lstV12;
        }

        //------------------------------- V 13 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion13()
        {
            C2iDataBaseUpdateOperationList lstV13 = new C2iDataBaseUpdateOperationList();

            //Début de la zone pour l'ajout
            lstV13.Add(typeof(CTicket));
			lstV13.Add(typeof(CSymbole));
            lstV13.Add(typeof(CSymboleDeBibliotheque));
            lstV13.Add(typeof(CTypeSite));
            lstV13.Add(typeof(CSite));
            lstV13.Add(typeof(CTypeEquipement));
            lstV13.Add(typeof(CEquipement));
            lstV13.Add(typeof(CEquipementLogique));
            lstV13.Add(typeof(CConsultationHierarchique));
            lstV13.Add(typeof(CPort));
            lstV13.Add(typeof(CTypeLienReseau));
            lstV13.Add(typeof(CRelationTypeLienReseau_ChampCustom));
            lstV13.Add(typeof(CRelationTypeLienReseau_Formulaire));
            lstV13.Add(typeof(CLienReseau));
            lstV13.Add(typeof(CRelationLienReseau_ChampCustom));
            lstV13.Add(typeof(CTypeLienReseauSupport));
           
            //Supprimer les tables équipement logique
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPMENT_LGC_TYPE_INCL"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPT_LGC_TYPE_FORM"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQP_TYPLGC_CUSTFLD_VAL"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPLGCTTP_CUSTFIELD"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPMENT_LGC_TYPE"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_FAM_LGC_FORM"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_LGC_FAM_CUST_FLD"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPT_FNC_TYPE_FORM"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPMENT_FNCT_TYPE_INCL"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQP_TYPFNC_CUSTFLD_VAL"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPFNCTTP_CUSTFIELD"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_FAM_FUNC_FORM"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_FUNC_FAM_CUST_FLD"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_FUNC_CUSTOM_FIELD"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPMENTS_FUNC"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQUIPMENT_FUNC_TYPE"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("EQPT_FAM_FUNC_FORM"));
            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable( "EQUIPMENT_FUNC_FAMILY" ) );

            lstV13.Add(typeof(CSchemaReseau));
            lstV13.Add(typeof(CElementDeSchemaReseau));

            lstV13.Add(new C2iDataBaseUpdateOperationDeleteTable("NTWLNK_SUPPORT"));

            lstV13.Add(typeof(CTypeSchemaReseau));
            lstV13.Add(typeof(CRelationTypeSchemaReseau_ChampCustom));
            lstV13.Add(typeof(CRelationTypeSchemaReseau_Formulaire));
            lstV13.Add(typeof(CRelationSchemaReseau_ChampCustom));

            lstV13.Add(typeof(CMouvementEquipement));
            //Fin de zone pour l'ajout

            
            return lstV13;
        }

        //------------------------------- V 14 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion14()
        {
            C2iDataBaseUpdateOperationList lstV14 = new C2iDataBaseUpdateOperationList();


            lstV14.Add(typeof(CTypeSchemaReseau));
            lstV14.Add(typeof(CSchemaReseau));
            lstV14.Add(typeof(CRelationTypeSchemaReseau_ChampCustom));
            lstV14.Add(typeof(CRelationTypeSchemaReseau_Formulaire));
            lstV14.Add(typeof(CRelationSchemaReseau_ChampCustom));
            lstV14.Add(typeof(CFiltreDynamiqueInDb));
            lstV14.Add(typeof(CCheminLienReseau));
            lstV14.Add(typeof(CElementDeSchemaReseau));
            lstV14.Add(typeof(CLienReseau));
            lstV14.Add(typeof(CModeleEtiquetteSchema));
            lstV14.Add(typeof(CConsultationHierarchique));
            lstV14.Add(typeof(CPreferenceFiltreRapide));
            lstV14.Add(typeof(CTypeOperation));
            // Tickets, ajout YK du 08/06/2009
            lstV14.Add(typeof(CRelationTypeTicket_ChampCustomValeur));

            //Chainage des mouvements d'équipement
            lstV14.Add(typeof(CMouvementEquipement));
            lstV14.Add(CreeChainageMouvementsEquipements); 

            
            return lstV14;
        }

        //------------------------------- V 15 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion15()
        {
            C2iDataBaseUpdateOperationList lstV15 = new C2iDataBaseUpdateOperationList();

            lstV15.Add(typeof(CTypeOperation));
            lstV15.Add(typeof(CTypeIntervention));

            lstV15.Add(typeof(CSchemaReseau));
            lstV15.Add(typeof(CLienReseau));
            lstV15.Add(InverseDependanceSchemaLien);
            lstV15.Add(new C2iDataBaseUpdateOperationDeleteChamp ( CLienReseau.c_nomTable, "NWD_ID"));
            lstV15.Add(typeof(CElementDeSchemaReseau));
            lstV15.Add(typeof(CTypeTicket)); // Ajout du champ "Code" sur le Type de ticket

            //Indexs sur les sites
            lstV15.Add(typeof(CSite));

            lstV15.Add(typeof(CRelationSite_ChampCustom));
            lstV15.Add(typeof(CCaracteristiqueEntite));
            lstV15.Add(typeof(CRelationCaracteristiqueEntite_ChampCustom));
            
            //Mise à jour globale pour index SC2I_VERSION et SC2I_DELETED
            UpdateAllTables(lstV15);

            return lstV15;
        }

        //------------------------------- V 16 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion16()
        {
            C2iDataBaseUpdateOperationList lstV16 = new C2iDataBaseUpdateOperationList();

            lstV16.Add(typeof(CTypeOperation));
            lstV16.Add(typeof(CMouvementEquipement));
            lstV16.Add(NumeroteMouvementsEquipements);

            return lstV16;
        }

        //------------------------------- V 17 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion17()
        {
            C2iDataBaseUpdateOperationList lstV17 = new C2iDataBaseUpdateOperationList();

            lstV17.Add(typeof(CModuleParametrage));
            lstV17.Add(typeof(CRelationElement_ModuleParametrage));
            lstV17.Add(typeof(CTypeDossierSuivi));
            // YK 11/12/2009 : Type Table ajout du paramétrage pour l'import XLS (champ blob)
            lstV17.Add(typeof(CTypeTableParametrable));

            lstV17.Add(typeof(CEvenement));
            lstV17.Add(typeof(CHandlerEvenement));

            lstV17.Add(typeof(CSchemaReseau));

            lstV17.Add(typeof(CTypeEntreeAgenda));
            lstV17.Add(typeof(CEntreeAgenda));

            lstV17.Add(typeof(CModeleTexte));

            lstV17.Add(typeof(CParametreVueSchemaDynamique));

            lstV17.Add(typeof(CParametrageGantt));
            lstV17.Add(typeof(CTypeProjet));
            lstV17.Add(typeof(CProjet));



            lstV17.Add ( new C2iDataBaseUpdateOperationDeleteTable("PROJECT_ANOMALY_PRJ_ELE"));
            lstV17.Add(typeof(CAnomalieProjet));

            lstV17.Add(typeof(CVuePhysique));
            lstV17.Add(typeof(CComposantPhysiqueInDb));
            lstV17.Add(typeof(CTypeEquipement));

            lstV17.Add(typeof(CTypePort));
            lstV17.Add(typeof(CPort));

            lstV17.Add(typeof(CActiviteActeurResume));


            return lstV17;
        }

        //------------------------------- V 18 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion18()
        {
            C2iDataBaseUpdateOperationList lstV18 = new C2iDataBaseUpdateOperationList();

            //Ajoute le lien au CElementDeSchemaReseau en l'autorisant à null
            // Cryptage des Id de Profil de Licence
            lstV18.Add(CrypteIdProfilLicence);
            lstV18.Add(typeof(CCheminLienReseau), CElementDeSchemaReseau.c_champId, CCheminLienReseau.c_champExtremiteConcernee);
            lstV18.Add(new C2iDataBaseUpdateOperationFonction(PasssageCheminSurElementDeSchemaAuLieuDeLienReseau));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp ( CCheminLienReseau.c_nomTable, "NTLNKPTH_LINK_AS_1"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp (CCheminLienReseau.c_nomTable, "NTLNKPTH_LINK_AS_2"));
            lstV18.Add(typeof(CCheminLienReseau));
            lstV18.Add(typeof(CParametrageDessinGantt));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CLienDeProjet.c_nomTable, "PRJ_ID"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CLienDeProjet.c_nomTable, "PRJ_LNK_TOLERANCE"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CLienDeProjet.c_nomTable, "PRJ_LNK_A"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CLienDeProjet.c_nomTable, "PRJ_LNK_B"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CLienDeProjet.c_nomTable, "PRJ_LNK_DB_FORMULA"));
            lstV18.Add(typeof(CLienDeProjet));
            lstV18.Add(typeof(CContrainteDeProjet));
            lstV18.Add(typeof(CProjet));
            //lstV18.Add(typeof(CTypeProjet)); // Enlevé car présent aussi dans V20: la MAJ plante sur les bases en version < 18
            lstV18.Add(typeof(CTypeLienReseau));
            lstV18.Add(typeof(CPostIt));
            lstV18.Add(typeof(CDocumentGED));
            lstV18.Add(typeof(CExceptionTypePourTypeEO));
            lstV18.Add(typeof(CCategorieGED));
            lstV18.Add(typeof(CRelationTypeProjet_ChampCustomValeur));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CEvenement.c_nomTable, "EVT_ASYNCHRON"));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CEvenement.c_nomTable, "EVT_TRANSACTION"));
            lstV18.Add(typeof(CTypeTicketContrat));
            lstV18.Add(typeof(CTypeTicketContrat_Site));
            lstV18.Add(typeof(CContrat));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CTypeTicketContrat.c_nomTable, CProfilElement.c_champId));
            lstV18.Add(new C2iDataBaseUpdateOperationDeleteChamp(CContrat_ListeOperations.c_nomTable, CProfilElement.c_champId));
            lstV18.Add(typeof(CTypeTicketContrat_Site_Periode));
            

            return lstV18;
        }

        //------------------------------- V 19 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion19()
        {
            C2iDataBaseUpdateOperationList lstV19 = new C2iDataBaseUpdateOperationList();

            // Remonte l'option "Gestion Manuelle des SItes" sur le Type de contrat
            lstV19.Add(new C2iDataBaseUpdateOperationDeleteChamp(CContrat.c_nomTable, "CONTRACT_MANUAL_SITES"));
            lstV19.Add(typeof(CTypeContrat));
            lstV19.Add(SetTypesContratsAvecPrevEtCorrective);

            return lstV19;
        }

        //------------------------------- V 20 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion20()
        {
            C2iDataBaseUpdateOperationList lstV20 = new C2iDataBaseUpdateOperationList();

            lstV20.Add(typeof(CRelationTypeProjet_TypeProjet));
            lstV20.Add(typeof(CTypeProjet));
            lstV20.Add(typeof(CConsultationHierarchique));
            lstV20.Add(typeof(CNommageEntite));
            lstV20.Add(typeof(CSnmpMibModule));

            lstV20.Add(typeof(CTypeAlarme));
            lstV20.Add(typeof(CRelationTypeAlarme_ChampCustom));
            lstV20.Add(typeof(CRelationTypeAlarme_Formulaire));
            lstV20.Add(typeof(CAlarme));
            lstV20.Add(typeof(CRelationAlarme_ChampCustom));
            lstV20.Add(typeof(CTypeAgentSnmp));
            lstV20.Add(typeof(CRelationTypeAgentSnmp_MibModule));
            lstV20.Add(typeof(CTypeEntiteSnmp));
            lstV20.Add(typeof(CRelationTypeEntiteSnmp_ChampCustom));
            lstV20.Add(typeof(CRelationTypeEntiteSnmp_Formulaire));
            lstV20.Add(typeof(CAgentSnmp));
            lstV20.Add(typeof(CEntiteSnmp));
            lstV20.Add(typeof(CRelationEntiteSnmp_ChampCustom));
            // Proxy SNMP
            lstV20.Add(typeof(CSnmpProxyInDb));
            lstV20.Add(typeof(CLienDeProxy));
            lstV20.Add(typeof(CSeveriteAlarme));
            lstV20.Add(typeof(CParametrageAffichageListeAlarmes));

            lstV20.Add( new C2iDataBaseUpdateOperationDeleteChamp(CHandlerEvenement.c_nomTable, CEvenement.c_champContexteModification));
            lstV20.Add ( typeof(CHandlerEvenement) );
            lstV20.Add(typeof(CMessageSMS));

            lstV20.Add(typeof(CSymbole));
            lstV20.Add(typeof(CElementDeSchemaReseau));
            lstV20.Add(typeof(CParametrageFiltrageAlarmes));
            lstV20.Add(typeof(CCategorieMasquageAlarme));

            lstV20.Add(typeof(CProjet));

            //Commandes
            lstV20.Add(typeof(CTypeCommande));
            lstV20.Add(typeof(CRelationTypeCommande_ChampCustom));
            lstV20.Add(typeof(CRelationTypeCommande_Formulaire));
            lstV20.Add(typeof(CCommande));
            lstV20.Add(typeof(CRelationCommande_ChampCustom));
            lstV20.Add(typeof(CLigneCommande));

            lstV20.Add(typeof(CTypeLivraisonEquipement));
            lstV20.Add(typeof(CRelationTypeLivraisonEquipement_ChampCustom));
            lstV20.Add(typeof(CRelationTypeLivraisonEquipement_Formulaire));
            lstV20.Add(typeof(CLivraisonEquipement));
            lstV20.Add(typeof(CRelationLivraisonEquipement_ChampCustom));
            lstV20.Add(typeof(CLigneLivraisonEquipement));

            lstV20.Add(typeof(CLotValorisation));
            lstV20.Add(typeof(CValorisationElement));
            lstV20.Add(typeof(CLivraisonLotValorisation));
            lstV20.Add(typeof(CEquipement));
            lstV20.Add(typeof(CLivraisonLotValorisation));

            return lstV20;
        }

        //------------------------------- V 21 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion21()
        {
            C2iDataBaseUpdateOperationList lstV21 = new C2iDataBaseUpdateOperationList();

            lstV21.Add(typeof(CFormulaire));
            lstV21.Add(typeof(CProjet));
            lstV21.Add(typeof(CTypeEntiteSnmp));

            lstV21.Add(typeof(CAgentSnmp));
            lstV21.Add(typeof(CSchemaReseau));

            lstV21.Add(typeof(CSequenceNumerotation));
            lstV21.Add(typeof(CValeurSequenceNumerotation));
            lstV21.Add(typeof(CMenuCustom));

            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur60));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur61));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur62));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur63));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur64));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur65));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur66));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur67));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur68));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur69));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur70));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur71));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur72));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur73));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur74));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur75));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur76));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur77));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur78));
            lstV21.Add(new C2iDataBaseUpdateOperationDeleteChamp(CDonneeCumulee.c_nomTable, CDonneeCumulee.c_champValeur79));
            lstV21.Add(typeof(CDonneeCumulee));
            lstV21.Add(typeof(CValeurChampCustom));

            
            return lstV21;
        }

        //------------------------------- V 22 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion22()
        {
            C2iDataBaseUpdateOperationList lstV22 = new C2iDataBaseUpdateOperationList();

            lstV22.Add(typeof(CDossierMail));
            lstV22.Add(typeof(CCompteMail));
            lstV22.Add(typeof(CRegleMail));
            lstV22.Add(typeof(C2iMail));
            lstV22.Add(typeof(CTypeProjet));
            lstV22.Add(typeof(CProjet));
            lstV22.Add(typeof(CTracabiliteMail));
            lstV22.Add(typeof(CClasseUniteInDb));
            lstV22.Add(typeof(CUniteInDb));
            lstV22.Add(typeof(CTypeMetaProjet));
            lstV22.Add(typeof(CRelationTypeMetaProjet_ChampCustom));
            lstV22.Add(typeof(CRelationTypeMetaProjet_Formulaire));
            lstV22.Add(typeof(CMetaProjet));
            lstV22.Add(typeof(CRelationMetaProjet_Projet));
            lstV22.Add(typeof(CRelationMetaProjet_ChampCustom));
            //Gestion des droits
            lstV22.Add(typeof(CRelationElement_RestrictionSpecifique));
            lstV22.Add(typeof(CRelationElement_RestrictionSpecifique_Application));
            lstV22.Add(typeof(CProfilUtilisateur));
            lstV22.Add(new C2iDataBaseUpdateOperationFonction(RemplacePasDeFiltreParTypesFiltresSurProfilUtilisateur));
            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(CProfilUtilisateur.c_nomTable, "USRPRF_NO_VIEW_FILTER"));
            //Gestion des Consommables
            lstV22.Add(typeof(CTypeConsommable));
            lstV22.Add(typeof(CConditionnementConsommable));
            lstV22.Add(typeof(CLotConsommable));

            lstV22.Add(typeof(CTypeWorkflow));
            lstV22.Add(typeof(CTypeEtapeWorkflow));
            lstV22.Add(typeof(CLienEtapesWorkflow));
            lstV22.Add(typeof(CWorkflow));
            lstV22.Add(typeof(CEtapeWorkflow));
            lstV22.Add(typeof(CRelationTypeWorkflow_ChampCustom));
            lstV22.Add(typeof(CRelationTypeWorkflow_Formulaire));
            lstV22.Add(typeof(CRelationWorkflow_ChampCustom));
            lstV22.Add(typeof(CRelationTypeEtapeWorkflow_ChampCustom));
            lstV22.Add(typeof(CRelationTypeEtapeWorkflow_Formulaire));
            lstV22.Add(typeof(CRelationEtapeWorkflow_ChampCustom));
            lstV22.Add(typeof(CEtapeWorkflowHistorique));
            lstV22.Add(typeof(CModeleAffectationUtilisateurs));

            lstV22.Add(typeof(CSmartField));
            lstV22.Add(typeof(CProjet_SousType));
            lstV22.Add(typeof(CRelationTypeProjet_SousTypeProjet));
            lstV22.Add(typeof(CChampCustom));

            lstV22.Add(typeof(CPhaseSpecifications));
            lstV22.Add(typeof(CBesoin));
            lstV22.Add(typeof(CBesoinDependance));
            lstV22.Add(typeof(CBesoinQuantite));

            lstV22.Add(typeof(CFamilleEquipement));
            lstV22.Add(typeof(CRelationBesoinQuantite_Element));

            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CBesoin.c_nomTable,
                "NEED_COST_CALC"));

            lstV22.Add(typeof(CRelationBesoin_Satisfaction));

            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CPhaseSpecifications.c_nomTable,
                "SPECPH_PARENT_ID"));

            lstV22.Add(typeof(CRelationTypeConsommable_ChampCustomValeur));
            lstV22.Add(typeof(CRelationTypeConsommable_ChampCustom));
            lstV22.Add(typeof(CRelationTypeConsommable_Formulaire));
            lstV22.Add(typeof(CRelationLotConsommable_ChampCustom));

            lstV22.Add(typeof(CLigneCommande));

            lstV22.Add(typeof(CTypeIntervention_ProfilIntervenant));

            lstV22.Add(typeof(CHandlerEvenement));

            lstV22.Add(typeof(CValorisationElement));
            lstV22.Add(typeof(CIntervention));

            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CBesoin.c_nomTable,
                "NEED_SATISFACTIONS_COST"));

            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CRelationBesoin_Satisfaction.c_nomTable,
                "NEEDSAT_IMPUTED_COST"));


            lstV22.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CRelationBesoin_Satisfaction.c_nomTable,
                "NEEDSAT_ACTUAL_IMPT_COST"));



            lstV22.Add(typeof(COperation));
            lstV22.Add(typeof(CLigneCommande));
            lstV22.Add(typeof(CActeur));
            lstV22.Add(typeof(CFractionIntervention));


            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CBesoin)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(COperation)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CLigneCommande)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CProjet)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CIntervention)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CPhaseSpecifications)));
            lstV22.Add(new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(typeof(CFractionIntervention)));



            return lstV22;
        }

        //------------------------------- V 23 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion23()
        {
            C2iDataBaseUpdateOperationList lstV23 = new C2iDataBaseUpdateOperationList();



            lstV23.Add(typeof(CBesoin));
            lstV23.Add(typeof(CDroitEditionType));
            lstV23.Add(typeof(CProjet));

            lstV23.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CProjet.c_nomTable,
                "PRJ_PLAN_END_AUTO"));

            lstV23.Add(new C2iDataBaseUpdateOperationDeleteChamp(
                CProjet.c_nomTable,
                "PRJ_MANUAL_PLAN"));

            lstV23.Add(GereDatesPropresAProjetsParents);

            return lstV23;
        }

        //------------------------------- V 24 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion24()
        {
            C2iDataBaseUpdateOperationList lstV24 = new C2iDataBaseUpdateOperationList();

            lstV24.Add(typeof(CProcessInDb));
            lstV24.Add(typeof(CEasyQueryInDb));

            lstV24.Add(typeof(CReleveSite));
            lstV24.Add(typeof(CReleveEquipement));

            lstV24.Add(typeof(CProjet));
            lstV24.Add(typeof(CMetaProjet));

            lstV24.Add(typeof(CBesoin));
            lstV24.Add(typeof(CTypeProjet));

            lstV24.Add(typeof(CTypeEtapeWorkflow));
            lstV24.Add(AffecteChammpHasUserInterfaceSurTypesEtapes);

            lstV24.Add(typeof(CHandlerEvenement));
            lstV24.Add(typeof(CFormulaire));

            lstV24.Add(StockeBlocTypeSurTypeEtapes);


            return lstV24;
        }

        //------------------------------- V 25 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion25()
        {
            C2iDataBaseUpdateOperationList lstV25 = new C2iDataBaseUpdateOperationList();

            lstV25.Add(typeof(CRelationReleveEquipement_ChampCustom));
            lstV25.Add(typeof(CConfigMapDatabase));
            lstV25.Add(new C2iDataBaseUpdateOperationDeleteTable("MAP_DYNAMIC"));
            lstV25.Add(typeof(CFormulaire));
            lstV25.Add(typeof(CRelationTypeAlarme_ChampCustomValeur));
            lstV25.Add(typeof(CFonctionDynamiqueInDb));
            lstV25.Add(typeof(CChampCalcule));
            lstV25.Add(typeof(CTypeAgentSnmp));
            lstV25.Add(typeof(CTypeEntiteSnmp));
            lstV25.Add(typeof(CAgentSnmp));
            lstV25.Add(typeof(CSnmpProxyInDb));
            //lstV25.Add(new C2iDataBaseUpdateOperationDeleteChamp(CWorkflow.c_nomTable, "WKF_PARENT_ID"));
            lstV25.Add(typeof(CWorkflow));
            lstV25.Add(typeof(CEtapeWorkflow));
            lstV25.Add(typeof(CEtapeWorkflowHistorique));
            lstV25.Add(typeof(CRelationTypeEtapeWorkflow_ChampCustomValeur));
            lstV25.Add(typeof(CBesoin));
            lstV25.Add(new C2iDataBaseUpdateOperationFonction(MettreUniversalIdSurTousLesCObjetDonnee));

            return lstV25;
        }

        //------------------------------- V 26 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion26()
        {
            C2iDataBaseUpdateOperationList lstV26 = new C2iDataBaseUpdateOperationList();

            lstV26.Add(new C2iDataBaseUpdateOperationDeleteChamp(CWorkflow.c_nomTable, "WKF_PARENT_ID"));

            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CNommageEntite),
                "#SQL#ENTNAM_ID_ENTITY",
                CNommageEntite.c_champTypeEntite,
                CNommageEntite.c_champCleEntite
                ));

            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CProcessEnExecutionInDb),
                "#SQL#PROCEX_LAUNCHER_EVT_ID",
                typeof(CEvenement),
                CProcessEnExecutionInDb.c_champUniversalIdEvenementDeclencheur));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CVersionDonnees),
                "#SQL#DV_USER_ID",
                typeof(CDonneesActeurUtilisateur),
                CVersionDonnees.c_champDbKeyUtilisateur));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CWorkflow),
                "#SQL#WKF_MANAGER_ID",
                typeof(CDonneesActeurUtilisateur),
                CWorkflow.c_champKeyGestionnaire));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CEtapeWorkflow),
                "#SQL#WKFSTP_STARTUSR_ID",
                typeof(CDonneesActeurUtilisateur),
                CEtapeWorkflow.c_champKeyDemarréePar));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CEtapeWorkflow),
                "#SQL#WKFSTP_ENDUSR_ID",
                typeof(CDonneesActeurUtilisateur),
                CEtapeWorkflow.c_champKeyTerminéePar));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CBesoinInterventionProcess),
                "#SQL#PROCINT_USER_ID",
                typeof(CDonneesActeurUtilisateur),
                CBesoinInterventionProcess.c_champKeyUtilisateur));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CEtapeWorkflowHistorique),
                "#SQL#WKFSTP_STARTUSR_ID",
                typeof(CDonneesActeurUtilisateur),
                CEtapeWorkflowHistorique.c_champKeyDemarréePar));

            //TESTDBKEYOK
            lstV26.Add(new C2iDatabaseUpdateOperationRemplaceIdParDbKey(
                typeof(CEtapeWorkflowHistorique),
                "#SQL#WKFSTP_ENDUSR_ID",
                typeof(CDonneesActeurUtilisateur),
                CEtapeWorkflowHistorique.c_champKeyTerminéePar));

            lstV26.Add(typeof(CEtapeWorkflow));
            lstV26.Add(typeof(CTypeAgentSnmp));
            lstV26.Add(typeof(CProjet));
            lstV26.Add(typeof(CAgentSnmp));
            lstV26.Add(typeof(CSnmpPollingField));
            lstV26.Add(typeof(CTypeEntiteSnmp));
            lstV26.Add(typeof(CGelEtapeWorkflow));
            lstV26.Add(typeof(CTypeProjet));
            lstV26.Add(typeof(CTypeMetaProjet));
            lstV26.Add(typeof(CGPSCarte));
            lstV26.Add(typeof(CGPSTypePoint));
            lstV26.Add(typeof(CGPSPoint));
            lstV26.Add(typeof(CGPSTypeLigne));
            lstV26.Add(typeof(CGPSLine));

            //YK 15/06/2016 déplacé en V27 pour prendre en compte les nouvelles relation champs
            //lstV26.Add(new C2iDataBaseUpdateOperationFonction(CopieValeurChampToValeurString));


            return lstV26;
        }

        //------------------------------- V 27 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion27()
        {
            C2iDataBaseUpdateOperationList lstV27 = new C2iDataBaseUpdateOperationList();

            // Ajout de 6 nouvelles tables de relation Champs Custom
            lstV27.Add(typeof(CRelationTypeSite_ChampCustomValeur));
            lstV27.Add(typeof(CRelationTypeStock_ChampCustomValeur));
            lstV27.Add(typeof(CRelationTypeIntervention_ChampCustomValeur));
            lstV27.Add(typeof(CRelationTypeContrainte_ChampCustomValeur));
            lstV27.Add(typeof(CRelationTypeRessource_ChampCustomValeur));
            lstV27.Add(typeof(CRelationTypeTableParametrable_ChampCustomValeur));

            lstV27.Add(new C2iDataBaseUpdateOperationFonction(CopieValeurChampToValeurString));

            // Pas de passage en V 27
            //lstV27.Add(new C2iDataBaseUpdateOperationNoSetVersionBase());


            return lstV27;
        }

                //------------------------------- V 28 ---------------------------------------
        public C2iDataBaseUpdateOperationList UpdateVersion28()
        {
            C2iDataBaseUpdateOperationList lstV28 = new C2iDataBaseUpdateOperationList();

            // Pas de passage en V 28
            lstV28.Add(new C2iDataBaseUpdateOperationNoSetVersionBase());

            return lstV28;
        }

		#region Fonctions de mise à jour

		public CResultAErreur CreationTypeInter(IDataBaseCreator creator)
		{
			IDatabaseConnexion cnx = creator.Connection;
			return CreationElementStandardPourNouveauChampObligatoire(typeof(CContrat_ListeOperations), CTypeIntervention.c_champId, GetObjetStandard_TypeIntervention, true, cnx);
		}


        //--------------------------------------------------------------------------------
        public CObjetDonneeAIdNumerique GetObjetStandard_TypeIntervention(CContexteDonnee ctx)
		{
			CTypeIntervention typeInter = new CTypeIntervention(ctx);
			typeInter.Libelle = I.T("Standard Task Type|7");
			return typeInter;
		}

        //--------------------------------------------------------------------------------
        public CResultAErreur CreationElementStandardPourNouveauChampObligatoire(Type typeTableAMettreAJour, string champConcerne, ElementStandardDe elementStandard, bool prendrePremierExistantEnPriorite, IDatabaseConnexion cnx)
		{ 
			CResultAErreur result = CResultAErreur.True;
			using (CContexteDonnee ctx = new CContexteDonnee(cnx.IdSession, true, false))
			{
				string nomTableMAJ = CContexteDonnee.GetNomTableForType(typeTableAMettreAJour);
				CObjetDonneeAIdNumerique eleStandard = elementStandard.Invoke(ctx);
				string nomTableEle = eleStandard.GetNomTable();

				bool bTableMAJExiste = false;
				bool bTableEleExiste = false;

				string[] strTables = cnx.TablesNames;
				foreach (string nomTable in strTables)
				{
					if (nomTable == nomTableMAJ)
						bTableMAJExiste = true;
					else if (nomTable == nomTableEle)
						bTableEleExiste = true;
				}

				if (!bTableMAJExiste || !bTableEleExiste)
					return CResultAErreur.True;


				string[] champsId = eleStandard.GetChampsId();
				if (champsId.Length == 0)
				{
                    result.EmpileErreur(I.T("Impossible to update the table '@1' because the added field '@2' is mandatory and a standard element @3 cannot be created|30024",nomTableMAJ,champConcerne,nomTableEle));
				    return result;
				}
				string strFiltre = "";
				foreach (string c in champsId)
					strFiltre += c + " is null AND";
				if (strFiltre != "")
					strFiltre = strFiltre.Substring(0, strFiltre.Length - 4);

				CFiltreData filtre = new CFiltreData(strFiltre);
				int nNbElementPourMAJ = cnx.CountRecords(nomTableMAJ, filtre);

				CListeObjetsDonnees listeElesNecessaires = new CListeObjetsDonnees(ctx, typeTableAMettreAJour);
				DataTable tableTmp = ctx.GetTableSafe(nomTableEle);

				if (nNbElementPourMAJ > 0)
				{
					if (listeElesNecessaires.Count > 0 && prendrePremierExistantEnPriorite)
						eleStandard = (CObjetDonneeAIdNumerique)listeElesNecessaires[0];
					else
					{
						eleStandard.CreateNew();
						result = eleStandard.CommitEdit();
					}
					if (result)
						cnx.SetValeurChamp(
							nomTableMAJ,
							new string[] { eleStandard.GetChampId() },
							new object[] { eleStandard.Id }, filtre);
				}
			}
			return result;
		}

		
		//---------------------------------------------------------------------------		
		public CResultAErreur CreateTypeContrat(IDataBaseCreator creator)
		{
			IDatabaseConnexion cnx = creator.Connection;
			CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee ctx = new CContexteDonnee(cnx.IdSession, true, false))
            {
				
                bool bTableContratExiste = false;
                bool bTableTypeContratExiste = false;

                string[] strTables = cnx.TablesNames;
                foreach (string nomTable in strTables)
                {
                    if (nomTable == CContrat.c_nomTable)
                        bTableContratExiste = true;
                    if (nomTable == CTypeContrat.c_nomTable)
                        bTableTypeContratExiste = true;
                }

                if (!bTableContratExiste || !bTableTypeContratExiste)
                    return CResultAErreur.True;


                CListeObjetsDonnees listeTypeContrats = new CListeObjetsDonnees(ctx, typeof(CTypeContrat));
				CFiltreData filtre = new CFiltreData(CTypeContrat.c_champId + " is null");
				int nNbContrats = cnx.CountRecords(CContrat.c_nomTable, filtre);

				DataTable tableTmp = ctx.GetTableSafe(CTypeContrat.c_nomTable);

                if ( nNbContrats > 0 )
                {
                    CTypeContrat tp;
					if (listeTypeContrats.Count > 0)
					{
						tp = (CTypeContrat)listeTypeContrats[0];
					}
					else
					{
						tp = new CTypeContrat(ctx);
						tp.CreateNew();
						tp.Libelle = I.T("Standard Contract Type|1");
						result = tp.CommitEdit();
					}
					if (!result)
						return result;

					//Maintenant, passe tous les contrats qui sont à null, en pas null
					
					cnx.SetValeurChamp(
						CContrat.c_nomTable,
						new string[] { CTypeContrat.c_champId },
						new object[] { tp.Id }, filtre);
                }
            }
			return result;
		}

		//---------------------------------------------------------------------------		
		public CResultAErreur CreateChampDeleted(IDataBaseCreator creator)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
			{
				
				foreach (Type tp in CContexteDonnee.GetAllTypes())
				{
					
					DataTable table = null;
					try
					{
						table = contexte.GetTableSafe(CContexteDonnee.GetNomTableForType(tp));
					}
					catch
					{
					}
					if(table != null && !(typeof(IObjetSansVersion).IsAssignableFrom(tp)) &&
						!table.Columns.Contains(CSc2iDataConst.c_champIsDeleted))
					{
						result = creator.CreationOuUpdateTableFromType(tp);
						if (!result)
							return result;
						try
						{
							using (CContexteDonnee ctxTmp = new CContexteDonnee(creator.Connection.IdSession, true, false))
							{
								CListeObjetsDonnees liste = new CListeObjetsDonnees(ctxTmp, tp);
								liste.Filtre = new CFiltreData(CSc2iDataConst.c_champIdVersion + " is not null");
								foreach (CObjetDonneeAIdNumerique objet in liste.ToArrayList())
								{
									CVersionDonnees version = objet.VersionDatabase;
									if (version != null && version.CodeTypeVersion == (int)CTypeVersion.TypeVersion.Archive)
										objet.IsDeleted = true;
								}
								result = ctxTmp.SaveAll(true);
							}
						}
						catch (Exception e)
						{
							result.EmpileErreur(new CErreurException(e));
                            result.EmpileErreur(I.T("Error while updating @1|30025", table.TableName));
							return result;
						}
					}
				}
			}
			return result;
		}

        //--------------------------------------------------------------------------------
        public CResultAErreur CorrectionBugVersionChampsCustom(IDataBaseCreator creator)
		{

			/*Explication du bug :
			 * Lors de la création d'une valeur de champ custom dans une version,
			 * il faut s'assurer que la valeur par défaut existe bien dans le référentiel
			 * !Sauf, si l'objet lié à la version n'est pas dans le référentiel. Or, avant
			 * correction, chaque création de champ custom dans une version, créait la valeur
			 * par défaut dans le référentiel si cette valeur n'existait pas.
			 * On se retrouve donc avec deux valeur, une dans le référentiel et une dans
			 * la version pour des objets qui n'appartiennent pas au référentiel
			 * */

			CResultAErreur result = CResultAErreur.True;
			CInfoClasseDynamique[] typesRelations = DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(CRelationElementAChamp_ChampCustom));
			creator.Connection.BeginTrans();
			try
			{
				using (CContexteDonnee contexte = new CContexteDonnee(0, true, false))
				{
					foreach (CInfoClasseDynamique classe in typesRelations)
					{
						Type type = classe.Classe;
						if (!type.IsAbstract && !typeof(IObjetSansVersion).IsAssignableFrom(type))
						{
							CRelationElementAChamp_ChampCustom objet = (CRelationElementAChamp_ChampCustom)Activator.CreateInstance(type, new object[] { contexte });
							string strNomTableRelation = objet.GetNomTable();
							Type tpObjetsAChamps = objet.GetTypeElementAChamps();
							CObjetDonneeAIdNumerique parent = (CObjetDonneeAIdNumerique)Activator.CreateInstance(tpObjetsAChamps, new object[] { contexte });
							string strTableObjetAChamp = parent.GetNomTable();
							string strRequete = "select " + objet.GetChampId() + " from " + strNomTableRelation + " A " +
								"inner join " + strTableObjetAChamp + " B on A." +
								parent.GetChampId() + "=B." + parent.GetChampId() + " where B.SC2I_VERSION is not null " +
								"and A.SC2I_VERSION is null";
							IDataAdapter adapter = creator.Connection.GetAdapterForRequete(strRequete);
							DataSet ds = new DataSet();
							adapter.Fill(ds);
							DataTable tableIdsASupprimer = ds.Tables[0];
							if (tableIdsASupprimer.Rows.Count > 0)
							{
								//Mise à null de tous les éléments qui se réfèrent (Original_Id) à ces éléments
								//fantomes
								string strRequeteUpdate = "Update " + strNomTableRelation + " set " +
									CSc2iDataConst.c_champOriginalId + "=null where " +
									objet.GetChampId() + " in (" + strRequete + ")";
								result = creator.Connection.RunStatement(strRequeteUpdate);
								if (!result)
									return result;
								string strRequeteDelete = "Delete from " + strNomTableRelation + " where " +
									objet.GetChampId() + " in (" + strRequete + ")";
								result = creator.Connection.RunStatement(strRequeteDelete);
								if (!result)
									return result;
							}
						}
					}
				}
				/*Autre bug : des éléments ont été supprimés alors qu'ils étaient utilisés dans des version
				 * il faut donc restaurer ces éléments
				 * ça n'est arrivé que sur les sites et les équipements (suppression par process violent)
				 */
				using ( CContexteDonnee contexte = new CContexteDonnee ( 0, true, false ) )
				{
					contexte.SetVersionDeTravail(-1, false);
					foreach ( CInfoRelation relation in CContexteDonnee.GetListeRelationsTable ( CSite.c_nomTable ))
					{
						if ( relation.TableParente == CSite.c_nomTable )
						{
							DataTable table = contexte.GetTableSafe(relation.TableFille);
							if (table.Columns[CSc2iDataConst.c_champIsDeleted] != null && table.TableName != CTableParametrable.c_nomTable)
							{
								Type typeObjets = CContexteDonnee.GetTypeForTable ( relation.TableFille );
								CListeObjetsDonnees listeSupprimes = new CListeObjetsDonnees(contexte, typeObjets);
								listeSupprimes.Filtre = new CFiltreData(CSc2iDataConst.c_champIsDeleted + "=@1", true);
								listeSupprimes.Filtre.IntegrerLesElementsSupprimes = true;
								listeSupprimes.Filtre.IgnorerVersionDeContexte = true;
								//Vérifier que les éléments supprimés ne sont pas utilisés dans des version
								foreach (CObjetDonneeAIdNumerique objet in listeSupprimes.ToArrayList())
								{
									CListeObjetsDonnees listeDependants = new CListeObjetsDonnees(contexte, typeObjets);
									listeDependants.Filtre = new CFiltreData(CSc2iDataConst.c_champOriginalId + "=@1",
										objet.Id);
									listeDependants.Filtre.IgnorerVersionDeContexte = true;
									if (listeDependants.Count > 0)
									{
										objet.Row[CSc2iDataConst.c_champIdVersion] = DBNull.Value;
										objet.Row[CSc2iDataConst.c_champIsDeleted] = false;
									}
								}
							}
						}
					}
					result = contexte.SaveAll(false);
					if (!result)
						return result;	
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException (e));
			}
			finally
			{
				if ( result )
					result = creator.Connection.CommitTrans();
				else
					creator.Connection.RollbackTrans();
			}
			return result;
				
		}

		

        //--------------------------------------------------------------------------------
		public CResultAErreur CryptePasswords(IDataBaseCreator creator)
		{
			CResultAErreur result = CResultAErreur.True;

			using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
			{
				//contexte.SetVersionDeTravail(-1);
				
				CListeObjetsDonnees lstDonneesUtilisateur = new CListeObjetsDonnees(contexte, typeof(CDonneesActeurUtilisateur));
				//int n = lstDonneesUtilisateur.Count;
				foreach(CDonneesActeurUtilisateur donnee in lstDonneesUtilisateur)
					if(donnee.Acteur.Datas == 0 
						&& donnee.Password != null 
						&& donnee.Password.Trim() != "")
						donnee.Password = C2iCrypto.Crypte(donnee.Password);

				result = contexte.SaveAll(true);
			}

			return result;
		}

        //--------------------------------------------------------------------------------
        public CResultAErreur CrypteIdProfilLicence(IDataBaseCreator creator)
        {
            CResultAErreur result = CResultAErreur.True;

            using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
            {
                CListeObjetsDonnees lstDonneesUtilisateur = new CListeObjetsDonnees(contexte, typeof(CDonneesActeurUtilisateur));
                foreach (CDonneesActeurUtilisateur donnee in lstDonneesUtilisateur)
                {
                    string strIdProfilEnClair = (string) donnee.Row[CDonneesActeurUtilisateur.c_champIdProfLicence];
                    donnee.IdProfilLicence = strIdProfilEnClair;
                }

                result = contexte.SaveAll(true);
            }

            return result;
        }

        //--------------------------------------------------------------------------------
        public CResultAErreur SetTypesContratsAvecPrevEtCorrective(IDataBaseCreator creator)
        {
            CResultAErreur result = CResultAErreur.True;

            using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
            {
                CListeObjetsDonnees lst = new CListeObjetsDonnees(contexte, typeof(CTypeContrat));
                foreach (CTypeContrat typeContrat in lst)
                {
                    typeContrat.GestionMaintenanceCorrective = true;
                    typeContrat.GestionMaintenancePreventive = true;
                }

                result = contexte.SaveAll(true);
            }

            return result;
        }



        //--------------------------------------------------------------------------------
        public CResultAErreur ConvertitOperationsHeureEnDate(IDataBaseCreator creator)
        {
            CResultAErreur result = CResultAErreur.True;

            using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
            {

                CListeObjetsDonnees lstOperations = new CListeObjetsDonnees(contexte, typeof(COperation));
                lstOperations.ReadDependances("FractionIntervention.Intervention.RelationsIntervenants");
                foreach (COperation operation in lstOperations)
                {
                    CFractionIntervention fraction = operation.FractionIntervention;
                    if (fraction != null )
                    {
                        // Met à jour l'acteur associé
                        CIntervention inter = fraction.Intervention;
                        if (operation.Acteur == null && inter != null)
                        {
                            CActeur acteur = null;
                            foreach (CIntervention_Intervenant rel in inter.RelationsIntervenants)
                            {
                                acteur = rel.Intervenant;
                                break;
                            }
                            if (acteur != null)
                            {
                                operation.Acteur = acteur;
                            }
                        }
                        
                        // Met à jour la date de l'opération
                        if (operation.DateDebut == null && fraction.DateDebut != null)
                        {
                            DateTime dateFraction = ((DateTime)fraction.DateDebut).Date;
                            if(operation.HeureDebut != null)
                                operation.DateDebut = dateFraction.AddHours((double)operation.HeureDebut);
                            else
                                operation.DateDebut = dateFraction;

                        }
                    }

                }
                result = contexte.SaveAll(true);
            }

            return result;
        }

        //--------------------------------------------------------------------------------
        public CResultAErreur ConvertirToutesLesNotesDePhaseEnOperations(IDataBaseCreator creator)
        {
            CResultAErreur result = CResultAErreur.True;

            using (CContexteDonnee contexte = new CContexteDonnee(creator.Connection.IdSession, true, false))
            {
                CListeObjetsDonnees listeNotes = new CListeObjetsDonnees(contexte, typeof(CNotePhase));
                string strLibelleTpOp = "NOTE";
                // Création du type d'opération par défaut, s'il n'existe pas
                CTypeOperation tpOperation = new CTypeOperation(contexte);
                if (!tpOperation.ReadIfExists(new CFiltreData(
                    CTypeOperation.c_champLibelle + " = @1", strLibelleTpOp)))
                {
                    tpOperation.CreateNewInCurrentContexte();
                    tpOperation.Libelle = strLibelleTpOp;
                    tpOperation.SaisieDureePropre = false;
                    tpOperation.SaisieHeurePropre = true;

                }

                CListeObjetsDonnees lstOperations = new CListeObjetsDonnees(contexte, typeof(COperation));
                lstOperations.AssureLectureFaite();

                // Création de toutes les notes
                foreach (CNotePhase note in listeNotes)
                {
                    COperation operation = new COperation(contexte);
                    if (!operation.ReadIfExists(new CFiltreData(
                        CPhaseTicket.c_champId + " = @1 AND " +
                        COperation.c_champCommentaires + " = @2 ",
                        note.PhaseTicket.Id,
                        note.Texte),
                        false))
                    {
                        operation.CreateNewInCurrentContexte();
                        operation.Acteur = note.ActeurUtilisateur.Acteur;
                        operation.DateDebut = note.Date;
                        operation.Commentaires = note.Texte;
                        operation.TypeOperation = tpOperation;
                        operation.PhaseTicket = note.PhaseTicket;
                    }
                }

                result = contexte.SaveAll(true);

            }
            return result;
        }

        public CResultAErreur CreeChainageMouvementsEquipements ( IDataBaseCreator createur )
        {
            CResultAErreur result = CResultAErreur.True;
            using ( CContexteDonnee contexte = new CContexteDonnee ( createur.Connection.IdSession, true, false ))
            {
                CListeObjetsDonnees listeEquipements = new CListeObjetsDonnees(contexte, typeof(CEquipement));
                listeEquipements.ReadDependances("Mouvements");
                foreach (CEquipement equipement in listeEquipements)
                {
                    CListeObjetsDonnees mouvements = equipement.Mouvements;
                    mouvements.Tri = CMouvementEquipement.c_champDateMouvement;
                    for (int nMouvement = 0; nMouvement < mouvements.Count - 2; nMouvement++)
                    {
                        CMouvementEquipement mouvement = mouvements[nMouvement] as CMouvementEquipement;
                        if ( mouvement.MouvementSuivant == null )
                            mouvement.MouvementSuivant = mouvements[nMouvement + 1] as CMouvementEquipement;
                    }
                }
                result = contexte.SaveAll(true);
            }
            return result;
        }

        /// <summary>
        /// Le schéma d'un lien était (avant cette modif) une relation parente
        /// du lien, or ça posait des tas de problèmes (suppression, VerifieDonnees, ...),
        /// donc j'ai inversé le lien en indiquant que le schéma est une composition
        /// du lien. Cette fonction inverse la relation
        /// </summary>
        /// <param name="createur"></param>
        /// <returns></returns>
        public CResultAErreur InverseDependanceSchemaLien(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            try
            {
                if (!createur.ChampExists(CLienReseau.c_nomTable, "NWD_ID"))
                    return result;

                string strRequete = "select " + CLienReseau.c_champId + ",NWD_ID from " +
                    CLienReseau.c_nomTable + " where NWD_ID is not null";
                IDataAdapter adapter = createur.Connection.GetSimpleReadAdapter(strRequete);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    strRequete = "Update " + CSchemaReseau.c_nomTable + " set " +
                        CSchemaReseau.c_champIdLienReseauAuquelJappartient + "=" + row[0].ToString() +
                        " where " + CSchemaReseau.c_champId + "=" + row[1].ToString();
                    createur.Connection.RunStatement(strRequete);
                }
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            return result;
        }

        /// <summary>
        /// Numérotation des mouvements d'équipements
        /// </summary>
        /// <param name="createur"></param>
        /// <returns></returns>
        public CResultAErreur NumeroteMouvementsEquipements(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee contexte = new CContexteDonnee(createur.Connection.IdSession, true, false))
            {
                CListeObjetDonneeGenerique<CEquipement> lstEquips = new CListeObjetDonneeGenerique<CEquipement>(contexte);
                lstEquips.Filtre = new CFiltreDataAvance(CEquipement.c_nomTable,
                    "Has(" + CMouvementEquipement.c_nomTable + "." + CMouvementEquipement.c_champId + ")");
                lstEquips.ReadDependances("Mouvements");
                foreach (CEquipement eqpt in lstEquips.ToArrayList())
                {
                    eqpt.RenumerotteMouvements();
                }
                result = contexte.SaveAll(true);
            }
            return result;
        }

        public CResultAErreur PasssageCheminSurElementDeSchemaAuLieuDeLienReseau(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            if ( createur.ChampExists ( CCheminLienReseau.c_nomTable, "NTLNKPTH_LINK_AS_1" ) )
            {
                using ( CContexteDonnee contexte = new CContexteDonnee ( createur.Connection.IdSession, true, false ) )
                {
                    CListeObjetsDonnees lstChemins = new CListeObjetsDonnees ( contexte, typeof(CCheminLienReseau) );
                    lstChemins.Filtre = new CFiltreData ( CCheminLienReseau.c_champIdCheminParent+" is null");
                    ArrayList lst = new ArrayList ( lstChemins );
                    foreach ( CCheminLienReseau chemin in lst )
                    {
                        bool bFirst = true;

                        for (int nTmp = 1; nTmp <= 2; nTmp++)
                        {
                            CListeObjetsDonnees lstElements = new CListeObjetsDonnees(contexte, typeof(CElementDeSchemaReseau));
                            result = createur.Connection.ExecuteScalar("select NTLNKPTH_LINK_AS_" + nTmp + " from " +
                                CCheminLienReseau.c_nomTable + " where " + CCheminLienReseau.c_champId + "=" + chemin.Id);
                            if (!result)
                                return result;
                            int nIdLien = -1;
                            try
                            {
                                nIdLien = Convert.ToInt32(result.Data);
                            }
                            catch { }
                            if ( nIdLien > 0 )
                            {
                                lstElements.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", nIdLien);
                                foreach (CElementDeSchemaReseau elt in lstElements)
                                {
                                    CCheminLienReseau cheminBis = chemin;
                                    if (!bFirst)
                                        cheminBis = (CCheminLienReseau)chemin.Clone(false);
                                    cheminBis.ElementDeSchemaConcerne = elt;
                                    switch (nTmp)
                                    {
                                        case 1:
                                            cheminBis.NumeroExtremiteConcernee = (int)EExtremiteLienReseau.Un;
                                            break;
                                        case 2:
                                            cheminBis.NumeroExtremiteConcernee = (int)EExtremiteLienReseau.Deux;
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    result = contexte.SaveAll(true);
                }
            }
            return result;
        }

        public CResultAErreur RemplacePasDeFiltreParTypesFiltresSurProfilUtilisateur(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            string strChampNoViewFilter = "USRPRF_NO_VIEW_FILTER";
            if (createur.ChampExists(CProfilUtilisateur.c_nomTable, strChampNoViewFilter))
            {
                using (CContexteDonnee contexte = new CContexteDonnee(createur.Connection.IdSession, true, false))
                {
                    CListeObjetDonneeGenerique<CProfilUtilisateur> lstProfils = new CListeObjetDonneeGenerique<CProfilUtilisateur>(contexte);
                    foreach (CProfilUtilisateur profil in lstProfils.ToArrayList())
                    {
                        //va chercher la valeur du champ
                        result = createur.Connection.ExecuteScalar("select " + strChampNoViewFilter + " from "+
                            CProfilUtilisateur.c_nomTable+" where " +
                            CProfilUtilisateur.c_champId + "=" + profil.Id);
                        bool bVal = true;
                        if (result.Data is bool)
                            bVal = (bool)result.Data;
                        else if (result.Data is int)
                            bVal = (int)(result.Data) != 0;
                        else if (result.Data is Decimal)
                            bVal = (Decimal)(result.Data) != 0;
                        if (bVal)
                            profil.FiltrerAucun = true;
                        else
                            profil.FiltrerTout = true;
                    }
                    result = contexte.SaveAll(false);
                }
            }
            return result;
        }

        /// <summary>
        /// Met tous les projets parents en mode automatique. Avant cette modif ( version 23, 
        /// les projets parents avaient toujours les dates planifiées de leurs fils
        /// </summary>
        /// <param name="createur"></param>
        /// <returns></returns>
        public CResultAErreur GereDatesPropresAProjetsParents(IDataBaseCreator createur)
        {
            using ( CContexteDonnee ctx = new CContexteDonnee(createur.Connection.IdSession, true, false) )
            {
                CObjetServeur.ClearCacheSchemas();
                C2iOracleDataAdapter.ClearCacheSchemas();

                CListeObjetsDonnees lst = new CListeObjetsDonnees ( ctx, typeof(CProjet));
                lst.Filtre = new CFiltreDataAvance ( CProjet.c_nomTable,
                    "Has("+"ProjetsFils"+"."+CProjet.c_champId+")");
                foreach ( CProjet prj in lst.ToArrayList() )
                {
                    prj.Row[CProjet.c_champDebutAuto] = true;
                }

                lst.Filtre = new CFiltreData(CProjet.c_champIdParent + " is null");
                CListeObjetsDonnees lstChilds = lst.GetDependances("ProjetsFils");
                while (lstChilds.Count != 0)
                    lstChilds = lstChilds.GetDependances("ProjetsFils");
                foreach (CProjet prj in lst.ToArrayList())
                {
                    prj.RecalculateDates(true);
                    prj.CalcProgress(true);
                }
                ctx.EnableTraitementsAvantSauvegarde = false;
                ctx.EnableTraitementsExternes = false;
                return ctx.SaveAll(true);
            }
        }

        /// <summary>
        /// Le champ "HasUserInterface" des types étapes a été créé en version 24. Avant, il n'existait pas, donc cette
        /// fonction est chargée de les mettre à jour
        /// </summary>
        /// <param name="createur"></param>
        /// <returns></returns>
        public CResultAErreur AffecteChammpHasUserInterfaceSurTypesEtapes(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee ctx = new CContexteDonnee(createur.Connection.IdSession, true, false))
            {
                CObjetServeur.ClearCacheSchemas();
                C2iOracleDataAdapter.ClearCacheSchemas();

                CListeObjetsDonnees lst = new CListeObjetsDonnees(ctx, typeof(CTypeEtapeWorkflow));
                foreach ( CTypeEtapeWorkflow typeEtape in lst )
                {
                    if (typeEtape.Bloc != null)
                        typeEtape.HasUserInterface = typeEtape.Bloc.IsBlocAInterfaceUtilisateur;
                }
                return ctx.SaveAll(true);
            }
        }


        /// <summary>
        /// Le champ "HasUserInterface" des types étapes a été créé en version 24. Avant, il n'existait pas, donc cette
        /// fonction est chargée de les mettre à jour
        /// </summary>
        /// <param name="createur"></param>
        /// <returns></returns>
        public CResultAErreur StockeBlocTypeSurTypeEtapes(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CContexteDonnee ctx = new CContexteDonnee(createur.Connection.IdSession, true, false))
            {
                CObjetServeur.ClearCacheSchemas();
                C2iOracleDataAdapter.ClearCacheSchemas();

                CListeObjetsDonnees lst = new CListeObjetsDonnees(ctx, typeof(CTypeEtapeWorkflow));
                foreach ( CTypeEtapeWorkflow typeEtape in lst )
                {
                    if (typeEtape.Bloc != null)
                        typeEtape.Row[CTypeEtapeWorkflow.c_champStepType] = typeEtape.Bloc.BlocTypeCode;
                }
                return ctx.SaveAll(true);
            }
        }


        public CResultAErreur MettreUniversalIdSurTousLesCObjetDonnee(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            int nNbTotal = CContexteDonnee.GetAllTypes().Length;
            int nNbFait = 0;
            createur.Connection.CommitTrans();
            List<string> lstTables = new List<string>();
            int nIndex = 0;

            using (CContexteDonnee ctxDonnee = new CContexteDonnee(createur.Connection.IdSession, true, false))
            {
                ctxDonnee.GestionParTablesCompletes = false;
                foreach (Type tp in CContexteDonnee.GetAllTypes())
                {
                    DateTime dt = DateTime.Now;
                    string strNomInDb = CContexteDonnee.GetNomTableInDbForNomTable(CContexteDonnee.GetNomTableForType(tp));
                    if (!createur.TableExists(strNomInDb))
                        continue;
                    ctxDonnee.GetTableSafe(CContexteDonnee.GetNomTableForType(tp));
                    TimeSpan sp = DateTime.Now - dt;
                    Console.WriteLine("Table " + (nIndex++) + " " + CContexteDonnee.GetNomTableForType(tp) + " : " + sp.TotalMilliseconds.ToString());
                }
                foreach (DataTable table in ctxDonnee.GetTablesOrderInsert())
                    lstTables.Add(table.TableName);

            }
            foreach (string strTableContexte in lstTables)
            {
                if (!createur.TableExists(CContexteDonnee.GetNomTableInDbForNomTable(strTableContexte)))
                    continue;
                Type tp = CContexteDonnee.GetTypeForTable(strTableContexte);

                if (typeof(CObjetDonnee).IsAssignableFrom(tp) &&
                    tp.GetCustomAttributes(typeof(NoIdUniverselAttribute), true).Length == 0)
                {
                    string strNomTable = CContexteDonnee.GetNomTableInDbForNomTable(CContexteDonnee.GetNomTableForType(tp));
                    Console.WriteLine(strNomTable + " (" + nNbFait + "/" + nNbTotal + ")");
                    if (!createur.ChampExists(strNomTable, CObjetDonnee.c_champIdUniversel))
                        result = createur.CreationOuUpdateTableFromType(tp);
                    if (tp == typeof(CEtapeWorkflow) && result)
                    {
                        if (createur.ChampExists(strNomTable, "WKFSTP_UNIVERSAL_ID"))
                        {
                            result = createur.Connection.RunStatement("Update " +
                                CEtapeWorkflow.c_nomTable + " set " +
                                CObjetDonnee.c_champIdUniversel + "=WKFSTP_UNIVERSAL_ID");
                            if (result)
                                result = createur.DeleteChamp(CEtapeWorkflow.c_nomTable, "WKFSTP_UNIVERSAL_ID");
                        }
                    }
                    if (tp == typeof(CLienEtapesWorkflow) && result)
                    {
                        if (createur.ChampExists(strNomTable, "WKFSTP_UNI_ID"))
                        {
                            result = createur.Connection.RunStatement("Update " +
                                CLienEtapesWorkflow.c_nomTable + " set " +
                                CObjetDonnee.c_champIdUniversel + "=WKFSTP_UNI_ID");
                            if (result)
                                result = createur.DeleteChamp(CLienEtapesWorkflow.c_nomTable, "WKFSTP_UNI_ID");
                        }
                    }
                    if (tp == typeof(CTypeEtapeWorkflow) && result)
                    {
                        if (createur.ChampExists(strNomTable, "WKFSTP_UNI_ID"))
                        {
                            result = createur.Connection.RunStatement("Update " +
                                CTypeEtapeWorkflow.c_nomTable + " set " +
                                CObjetDonnee.c_champIdUniversel + "=WKFSTP_UNI_ID");
                            if (result)
                                result = createur.DeleteChamp(CTypeEtapeWorkflow.c_nomTable, "WKFSTP_UNI_ID");
                        }
                    }

                    CObjetServeur.ClearCacheSchemas();
                    CStructureTable.ClearCache(tp);
                    if (result)
                        result = new C2iDatabaseUpdateOperationCalculeIdUniverselsManquants(tp).ExecuterOperation(createur.Connection, null);
                    if (result)
                    {
                        createur.Connection.CommitTrans();
                        createur.Connection.BeginTrans();
                    }

                    if (!result)
                    {
                        createur.Connection.RollbackTrans();
                        return result;
                    }
                }
                nNbFait++;
            }
            return result;
        }


        //pour toutes les valeurs de champ, recopie la valeur du champ (int, double, string) dans la valeur string
        //Ca permet de faire un lien sur la table ValeurChampsCustom pour retrouver la valeurDisplay dans les requêtes.
        public CResultAErreur CopieValeurChampToValeurString(IDataBaseCreator createur)
        {
            CResultAErreur result = CResultAErreur.True;
            foreach (Type tp in CContexteDonnee.GetAllTypes())
            {
                if (typeof(CRelationElementAChamp_ChampCustom).IsAssignableFrom(tp))
                {
                    using (CContexteDonnee contexte = new CContexteDonnee(createur.Connection.IdSession, true, false))
                    {
                        contexte.EnableTraitementsAvantSauvegarde = false;
                        contexte.EnableTraitementsExternes = false;
                        contexte.DisableHistorisation = true;
                        CListeObjetsDonnees lst = new CListeObjetsDonnees(contexte, tp);
                        lst.Filtre = new CFiltreDataAvance(CContexteDonnee.GetNomTableForType(tp), CChampCustom.c_nomTable + "." + CChampCustom.c_champType + "=@1 or " + CChampCustom.c_nomTable + "." + CChampCustom.c_champType + "=@2 and "+
                            "has("+CChampCustom.c_nomTable+"."+CValeurChampCustom.c_nomTable+"."+CValeurChampCustom.c_champId+")",
                            (int)TypeDonnee.tBool, (int)TypeDonnee.tEntier);
                        Console.WriteLine(tp.ToString() + " : " + lst.Count);
                        int nPas = 100;
                        for (int n = 0; n < lst.Count; n += nPas)
                        {
                            int nCount = 0;
                            for (int p = n; p < n + nPas && p < lst.Count; p++)
                            {
                                CRelationElementAChamp_ChampCustom rel = lst[p] as CRelationElementAChamp_ChampCustom;
                                rel.Valeur = rel.Valeur;
                                nCount = p;
                            }
                            Console.WriteLine(tp.ToString() + "->" + n+" to "+nCount);
                            result = contexte.SaveAll(true);
                            if (!result)
                                return result;
                        }
                    }
                }

            }
            return result;
        }
        


		#endregion


		public delegate CObjetDonneeAIdNumerique ElementStandardDe(CContexteDonnee ctx);

	}


}
