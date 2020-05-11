using System;
using System.Collections.Generic;
using System.Reflection;

using sc2i.data;
using sc2i.multitiers.client;

using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.data;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.documents;
using sc2i.common;
using sc2i.process.Mail;
using sc2i.process.workflow;

namespace timos.serveur
{
	public static class CModuleRestrictionProvider
	{
		public static CListeRestrictionsUtilisateurSurType GetRestrictionsApp(CConfigModulesTimos configModules)
		{
			CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
            if (configModules == null)
                return liste;

			List<Type> tps = new List<Type>(CContexteDonnee.GetAllTypes());
			if (tps.Count == 0)
				throw new Exception("No type loaded for licences");
			foreach (Type tp in tps)
			{
				object[] atts = tp.GetCustomAttributes(typeof(AModulesApp), false);
				if (atts.Length == 1)
				{
					AModulesApp att = (AModulesApp)atts[0];

					List<CLicenceModuleAppPrtct> modulesDuType = new List<CLicenceModuleAppPrtct>();
					foreach (string strIdModule in att.IdsModulesApplicatif)
					{
						CLicenceModuleAppPrtct modulePresent = configModules.GetModuleApp ( strIdModule );
						if ( modulePresent != null )
							modulesDuType.Add ( modulePresent );
					}
					if (modulesDuType.Count == 0)
					{
                        CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(tp, ERestriction.Hide);
						liste.AddRestriction(restriction);
					}
					else
					{
						CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(tp);
						foreach (CLicenceModuleAppPrtct module in modulesDuType)
						{
							CRestrictionUtilisateurSurType restric = new CRestrictionUtilisateurSurType(tp);
							restric.RestrictionSysteme = module.Restriction;
							restriction.Combine(restric);
						}
						liste.AddRestriction(restriction);
					}
				}
			}
			CompleteRestrictionsApp(configModules, liste);
			return liste;
		}

		/// <summary>
		/// Ajoute aux restrictions définies par des attributs les restrictions liées
		/// aux classes qui ne sont pas dans timos (ex : les champs custom)
		/// </summary>
		/// <param name="modulesApplicatifs"></param>
		private static void CompleteRestrictionsApp(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			//Autoriser ou non les versions
			//Module journalisation ou ingénierie référentiel
			if ( configModules.GetModuleApp(CConfigModulesTimos.c_appModule_IngeReferentiel_ID) == null &&
				 configModules.GetModuleApp(CConfigModulesTimos.c_appModule_Journalisation_ID) == null)
			{
				//Pas le droit de versions
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CVersionDonnees), ERestriction.Hide);
				listeRestrictions.AddRestriction(restriction);
				//et version objet
                restriction = new CRestrictionUtilisateurSurType(typeof(CVersionDonneesObjet), ERestriction.Hide);
				listeRestrictions.AddRestriction(restriction);
				//et version objet opération
                restriction = new CRestrictionUtilisateurSurType(typeof(CVersionDonneesObjetOperation), ERestriction.Hide);
				listeRestrictions.AddRestriction(restriction);
			}

            CompleteRestrictionsAppWorkflows(configModules, listeRestrictions);
		}

		public static CListeRestrictionsUtilisateurSurType GetRestrictionsClient(CConfigModulesTimos configModules)
		{
			CListeRestrictionsUtilisateurSurType liste = new CListeRestrictionsUtilisateurSurType();
			if (configModules == null)
				return liste;

			List<Type> tps = new List<Type>(CContexteDonnee.GetAllTypes());
			foreach (Type tp in tps)
			{
				object[] atts = tp.GetCustomAttributes(typeof(AModulesClient), false);
				if (atts.Length == 1)
				{
					AModulesClient att = (AModulesClient)atts[0];

					List<CLicenceModuleClientPrtct> modulesDuType = new List<CLicenceModuleClientPrtct>();
					foreach (string strIdModule in att.IdsModulesClient)
					{
						CLicenceModuleClientPrtct modulePresent = configModules.GetModuleClient(strIdModule);
						if (modulePresent != null)
							modulesDuType.Add(modulePresent);
					}

					if (modulesDuType.Count == 0)
					{
						CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(tp);
                        foreach (string strIdModule in att.IdsModulesClient)
                        {
                            CRestrictionUtilisateurSurType restric = new CRestrictionUtilisateurSurType(tp);
                            restric.RestrictionSysteme = configModules.GetRestrictionSiModuleAbsent(strIdModule);
                            restriction.Combine(restric);
                        }
						liste.AddRestriction(restriction);
					}
					else
					{
						CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(tp);
						foreach (CLicenceModuleClientPrtct module in modulesDuType)
						{
							CRestrictionUtilisateurSurType restric = new CRestrictionUtilisateurSurType(tp);
							restric.RestrictionSysteme = module.Restriction;
							restriction.Combine(restric);
						}
                        if (!restriction.HasRestrictions)
                        {
                            restriction = new CRestrictionUtilisateurSurType(restriction.TypeAssocie);
                            restriction.RestrictionUtilisateur = restriction.RestrictionGlobale;
                        }
						liste.AddRestriction(restriction);
					}
				}
			}
			CompleteRestrictionsClient(configModules, liste);
			return liste;
		}

		/// <summary>
		/// Ajoute aux restrictions définies par des attributs les restrictions liées
		/// aux classes qui ne sont pas dans timos (ex : les champs custom)
		/// </summary>
		/// <param name="modulesApplicatifs"></param>
        private static void CompleteRestrictionsClient(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
        {
            CompleteRestrictionsChampsPersonnalises(configModules, listeRestrictions);
            CompleteRestrictionsTypesCaracteristiquesEntite(configModules, listeRestrictions);
            CompleteRestrictionsFiltresEtListes(configModules, listeRestrictions);
            CompleteRestrictionsChampsCalcules(configModules, listeRestrictions);
            CompleteRestrictionsProcessEtAutres(configModules, listeRestrictions);
            CompleteRestrictionsStructuresExport(configModules, listeRestrictions);
            CompleteRestrictionsDonneesPrecalculees(configModules, listeRestrictions);
            CompleteRestrictionsFormulaires(configModules, listeRestrictions);
            CompleteRestrictionsModeletesEtats(configModules, listeRestrictions);
            CompleteRestrictionsConfigurationCompteMail(configModules, listeRestrictions);
            CompleteRestrictionsClientWorkflows(configModules, listeRestrictions);
        }

		private static void CompleteRestrictionsModeletesEtats(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_RapportsCrystal_ID);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(C2iRapportCrystal),rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(C2iCategorieRapportCrystal), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsFormulaires(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct moduleFormulaire = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_Formulaires_ID);
			ERestriction rest = ERestriction.Hide;
			if (moduleFormulaire != null)
				rest = moduleFormulaire.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CFormulaire), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

        //---------------------------------------------------------------
        private static void CompleteRestrictionsClientWorkflows(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
        {
            CLicenceModuleClientPrtct moduleClientTypeWorkflow = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_ParametrageWorkflow);
            ERestriction rest = ERestriction.Hide;
            rest = ERestriction.Hide;
            if (moduleClientTypeWorkflow != null)
                rest = moduleClientTypeWorkflow.Restriction;
            if (rest != ERestriction.Aucune)
            {
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CTypeWorkflow), rest);
                listeRestrictions.AddRestriction(restriction);
            }
        }

        //---------------------------------------------------------------
        private static void CompleteRestrictionsAppWorkflows(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
        {
            CLicenceModuleAppPrtct moduleAppWorkflow = configModules.GetModuleApp(CConfigModulesTimos.c_appModuleWorkflow);
            ERestriction rest = ERestriction.Hide;
            if (moduleAppWorkflow != null)
                rest = moduleAppWorkflow.Restriction;
            if (rest != ERestriction.Aucune)
            {
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CTypeWorkflow), rest);
                listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CWorkflow), rest);
                listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CTypeEtapeWorkflow), rest);
                listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CEtapeWorkflow), rest);
                listeRestrictions.AddRestriction(restriction);

            }

        }

		//---------------------------------------------------------------
		private static void CompleteRestrictionsDonneesPrecalculees(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct moduleDonnees = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_DonneesPrecalculees_ID);
			ERestriction rest = ERestriction.Hide;
			if (moduleDonnees != null)
				rest = moduleDonnees.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CTypeDonneeCumulee), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsStructuresExport(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_StructuresExport_ID);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(C2iStructureExportInDB), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsProcessEtAutres(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_ProcessEtAutres_ID);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CVariableSurObjet), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CEvenement), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CGroupeParametrage), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CProcessInDb), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CRelationDefinisseurComportementInduit), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CRelationElementComportement), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CComportementGenerique), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsChampsCalcules(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_ChampsCalc_Id);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CChampCalcule), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsFiltresEtListes(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_Filtres_ID);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
				CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CFiltreDynamiqueInDb), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CListeEntites), rest);
				listeRestrictions.AddRestriction(restriction);
				restriction = new CRestrictionUtilisateurSurType(typeof(CRelationListeEntites_Entite), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

		//---------------------------------------------------------------
		private static void CompleteRestrictionsChampsPersonnalises(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
		{
			CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_ChampsCustom_ID);
			ERestriction rest = ERestriction.Hide;
			if (module != null)
				rest = module.Restriction;
			if (rest != ERestriction.Aucune)
			{
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CChampCustom), rest);
				listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CValeurChampCustom), rest);
				listeRestrictions.AddRestriction(restriction);
			}
		}

        //--------------------------------------------------------------------------------
        private static void CompleteRestrictionsTypesCaracteristiquesEntite(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
        {
            CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_TypeCaracteristiques_ID);
            ERestriction rest = ERestriction.Hide;
            if (module != null)
                rest = module.Restriction;
            if (rest != ERestriction.Aucune)
            {
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CTypeCaracteristiqueEntite), rest);
                listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CRelationTypeCaracteristiqueEntite_ChampCustom), rest);
                listeRestrictions.AddRestriction(restriction);
                restriction = new CRestrictionUtilisateurSurType(typeof(CRelationTypeCaracteristiqueEntite_Formulaire), rest);
                listeRestrictions.AddRestriction(restriction);
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        private static void CompleteRestrictionsConfigurationCompteMail(CConfigModulesTimos configModules, CListeRestrictionsUtilisateurSurType listeRestrictions)
        {
            CLicenceModuleClientPrtct module = configModules.GetModuleClient(CConfigModulesTimos.c_clientModule_ConfigurationCompteMail_ID);
            ERestriction rest = ERestriction.Hide;
            if (module != null)
                rest = module.Restriction;
            if (rest != ERestriction.Aucune)
            {
                CRestrictionUtilisateurSurType restriction = new CRestrictionUtilisateurSurType(typeof(CCompteMail), rest);
                listeRestrictions.AddRestriction(restriction);

                restriction = new CRestrictionUtilisateurSurType(typeof(CDossierMail), rest);
                listeRestrictions.AddRestriction(restriction);

                restriction = new CRestrictionUtilisateurSurType(typeof(CRegleMail), rest);
                listeRestrictions.AddRestriction(restriction);

            }

        }

	}

}
