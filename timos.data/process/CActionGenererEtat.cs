using System;
using System.Drawing;

using System.Collections;

			
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.documents;
using sc2i.multitiers.client;

namespace timos.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionGenererEtat : CActionFonction
	{
		private int m_nIdEtatCrystal = -1;
		private ArrayList m_listeIdsCategorieStockage = new ArrayList();
		private C2iExpression m_expressionCleGED = new C2iExpressionConstante("");
		private C2iExpression m_expressionLibelleDocument = null;
		private C2iExpression m_expressionDescriptifDocument = null;
		private TypeFormatExportCrystal m_formatExport = TypeFormatExportCrystal.PDF;

		//Id variable filtre->Formule
		private Hashtable m_mapVariablesFiltreEtatToFormule = new Hashtable();

		private bool m_bImprimerEtat = false;
		private bool m_bStockerGed = true;


		/// /////////////////////////////////////////
		public CActionGenererEtat( CProcess process )
			:base(process)
		{
			Libelle = I.T("Generate a report|30040");
			VariableRetourCanBeNull = true;
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				 I.T("Generate a report|30040"),
				"Generates a report and stores it in the EDM",
				typeof(CActionGenererEtat),
				CGestionnaireActionsDisponibles.c_categorieDonnees );
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return false; }
		}

		/// /////////////////////////////////////////
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
			base.AddIdVariablesNecessairesInHashtable ( table );
			AddIdVariablesExpressionToHashtable ( ExpressionCle, table );
			AddIdVariablesExpressionToHashtable ( ExpressionLibelle, table );
			AddIdVariablesExpressionToHashtable ( ExpressionDescriptif, table );

			foreach ( C2iExpression expression in m_mapVariablesFiltreEtatToFormule.Values )
				AddIdVariablesExpressionToHashtable ( expression, table );
		}

		/// /////////////////////////////////////////
		public override CTypeResultatExpression TypeResultat
		{
			get
			{
				return new CTypeResultatExpression ( typeof(CDocumentGED), false );
			}
		}


		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			//1 : Ajout du format d'export
			//2 : Herite de CActionFonction
			//3 : Ajout de l'option d'impression
            //4 : Passage de Isd varaiables en string
            return 4;
		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			if ( nVersion >= 2 )
				result = base.MySerialize( serializer );
			else
				result = base.MySerializeClasseParente ( serializer );
			if ( !result )
				return result;

			serializer.TraiteInt ( ref m_nIdEtatCrystal );

			I2iSerializable objet = m_expressionCleGED;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_expressionCleGED = (C2iExpression ) objet;

			objet = m_expressionDescriptifDocument;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_expressionDescriptifDocument = (C2iExpression ) objet;

			objet = m_expressionLibelleDocument;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_expressionLibelleDocument = (C2iExpression ) objet;

			int nNbVariables = m_mapVariablesFiltreEtatToFormule.Count;
			serializer.TraiteInt ( ref nNbVariables );
            switch (serializer.Mode)
            {
                case ModeSerialisation.Ecriture:
                    foreach (string strId in m_mapVariablesFiltreEtatToFormule.Keys)
                    {
                        string strTemp = strId;
                        serializer.TraiteString(ref strTemp);
                        objet = GetExpressionForVariableFiltre(strId);
                        result = serializer.TraiteObject(ref objet);
                        if (!result)
                            return result;
                    }
                    break;
                case ModeSerialisation.Lecture:
                    m_mapVariablesFiltreEtatToFormule.Clear();
                    for (int nVar = 0; nVar < nNbVariables; nVar++)
                    {
                        /* TESTDBKEYOK
                          * Test fait le .......... par ...
                          * Résultat : test à faire */
                        string strIdVariable = "";
                        if (nVersion < 4)
                        {
                            int nIdTemp = 0;
                            serializer.TraiteInt(ref nIdTemp);
                            strIdVariable = nIdTemp.ToString();
                        }
                        else
                            serializer.TraiteString(ref strIdVariable);

                        objet = null;
                        result = serializer.TraiteObject(ref objet);
                        if (!result)
                            return result;
                        SetExpressionForVariableFiltre(strIdVariable, (C2iExpression)objet);
                    }
                    break;
            }

			int nNbCategories = m_listeIdsCategorieStockage.Count;
			serializer.TraiteInt ( ref nNbCategories );
			switch ( serializer.Mode )
			{
				case ModeSerialisation.Ecriture:
					foreach ( int nIdCat in m_listeIdsCategorieStockage )
					{
						int nTmp = nIdCat;
						serializer.TraiteInt ( ref nTmp );
					}
					break;
				case ModeSerialisation.Lecture :
					m_listeIdsCategorieStockage.Clear();
					for ( int nVal = 0; nVal < nNbCategories; nVal++ )
					{
						int nTmp = 0;
						serializer.TraiteInt ( ref nTmp );
						m_listeIdsCategorieStockage.Add ( nTmp );
					}
					break;
			}

			if ( nVersion >= 1 )
			{
				int nTmp = (int)m_formatExport;
				serializer.TraiteInt ( ref nTmp );
				m_formatExport = (TypeFormatExportCrystal)nTmp;
			}
			else
				m_formatExport = TypeFormatExportCrystal.PDF;

			if ( nVersion >= 3 )
			{
				serializer.TraiteBool ( ref m_bImprimerEtat );
				serializer.TraiteBool ( ref m_bStockerGed );
			}
			else
			{
				m_bImprimerEtat = false;
				m_bStockerGed = true;
			}

			return result;
		}

		/// ////////////////////////////////////////////////////////
		public bool StockerDansLaGed
		{
			get
			{
				return m_bStockerGed;
			}
			set
			{
				m_bStockerGed = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public bool ImprimerSurClient
		{
			get
			{
				return m_bImprimerEtat;
			}
			set
			{
				m_bImprimerEtat = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();

			using ( CContexteDonnee contexte = new CContexteDonnee ( Process.IdSession, true, false) )
			{
				C2iRapportCrystal etat = new C2iRapportCrystal(contexte);
				if ( !etat.ReadIfExists ( m_nIdEtatCrystal ) )
				{
					result.EmpileErreur("Incorrect report model|30042");
					return result;
				}

				if ( m_listeIdsCategorieStockage.Count < 1 && m_bStockerGed)
				{
					result.EmpileErreur("The report must be stored at least in one EDM category|30043");
				}

				CMultiStructureExport multiStruct = etat.MultiStructure;
				if ( multiStruct == null )
				{
					result.EmpileErreur("The report does not have a data structure|30044");
					return result;
				}
				foreach ( IVariableDynamique variable in multiStruct.ListeVariables )
				{
                    C2iExpression exp = GetExpressionForVariableFiltre(variable.IdVariable);
					if ( exp != null && !exp.TypeDonnee.Equals(variable.TypeDonnee) )
					{
						result.EmpileErreur("The value of the variable @1 is not compatible with the variable type|30045",variable.Nom);
					}
				}
				
			}

			return result;
		}

		/// ////////////////////////////////////////////////////////
		public int IdEtatCrystal
		{
			get
			{
				return m_nIdEtatCrystal;
			}
			set
			{
				m_nIdEtatCrystal = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public ArrayList ListeIdsCategoriesStockage
		{
			get
			{
				return m_listeIdsCategorieStockage;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression ExpressionCle
		{
			get
			{
				if ( m_expressionCleGED == null )
					m_expressionCleGED = new C2iExpressionConstante("");
				return m_expressionCleGED;
			}
			set
			{
				m_expressionCleGED = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public TypeFormatExportCrystal FormatExport
		{
			get
			{
				return m_formatExport;
			}
			set
			{
				m_formatExport = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression ExpressionLibelle
		{
			get
			{
				if ( m_expressionLibelleDocument == null )
					m_expressionLibelleDocument = new C2iExpressionConstante("");
				return m_expressionLibelleDocument;
			}
			set
			{
				m_expressionLibelleDocument = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression ExpressionDescriptif
		{
			get
			{
				if ( m_expressionDescriptifDocument == null )
					m_expressionDescriptifDocument = new C2iExpressionConstante("");
				return m_expressionDescriptifDocument;
			}
			set
			{
				m_expressionDescriptifDocument = value;
			}
		}

		/// ////////////////////////////////////////////////////////
        public C2iExpression GetExpressionForVariableFiltre(string strIdVariable)
        {
            return (C2iExpression)m_mapVariablesFiltreEtatToFormule[strIdVariable];
        }

		/// ////////////////////////////////////////////////////////
        public void SetExpressionForVariableFiltre(string strIdVariable, C2iExpression expression)
        {
            m_mapVariablesFiltreEtatToFormule[strIdVariable] = expression;
        }

		/// ////////////////////////////////////////////////////////
		public void ClearExpressionsVariables()
		{
			m_mapVariablesFiltreEtatToFormule.Clear();
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			
			//Préparation du filtre
			C2iRapportCrystal rapport = new C2iRapportCrystal ( contexte.ContexteDonnee );
			if ( !rapport.ReadIfExists ( IdEtatCrystal ) )
			{
				result.EmpileErreur(I.T("The report @1 does not exist|30046",IdEtatCrystal.ToString()));
				return result;
			}
			CContexteEvaluationExpression contexteEvaluation = new CContexteEvaluationExpression ( Process );
			CMultiStructureExport multiStructure = rapport.MultiStructure;
			if ( multiStructure == null )
			{
				result.EmpileErreur(I.T("The report does not have a data structure|30044"));
				return result;
			}
			foreach ( IVariableDynamique variable in multiStructure.ListeVariables )
			{
				if ( variable.IsChoixUtilisateur() )
				{
                    C2iExpression expressionVariable = GetExpressionForVariableFiltre(variable.IdVariable);
					if ( expressionVariable != null )
					{
						result = expressionVariable.Eval ( contexteEvaluation );
						if ( !result )
						{
							result.EmpileErreur(I.T("Error in variable '@1' assignment|30047",variable.Nom));
							return result;
						}
						multiStructure.SetValeurChamp ( variable, result.Data );
					}
				}
			}
			ReportDocument report = null;
			try
			{
				result =rapport.CreateFichierExport ( multiStructure, m_formatExport, ref report );
				if ( !result )
				{
					result.EmpileErreur(I.T("Error while creating the report|30048"));
					return result;
				}
				CFichierLocalTemporaire fichierPDF = (CFichierLocalTemporaire)result.Data;

				#region Impression de l'état
				if ( m_bImprimerEtat )
				{
					CSessionClient sessionClient = CSessionClient.GetSessionForIdSession ( contexte.IdSession );
					CConfigurationsImpression configuration = sessionClient.ConfigurationsImpression;
					if ( configuration.NomImprimanteSurServeur != "" )
						report.PrintOptions.PrinterName = configuration.NomImprimanteSurServeur;
					try
					{
						report.PrintToPrinter(1, false, 0, 0);
					}
					catch ( Exception e )
					{
						result.EmpileErreur ( new CErreurException(e));
						result.EmpileErreur(I.T("Printing error|30049"));
						return result;
					}
					/*if ( sessionClient != null )
					{
						if ( sessionClient.GetInfoUtilisateur().IdUtilisateur == contexte.Branche.IdUtilisateur )
						{
							if ( sessionClient.ConfigurationsImpression.NomImprimanteSurClient != "" )
								report.PrintOptions.PrinterName = sessionClient.ConfigurationsImpression.NomImprimanteSurClient;
							CServiceSurClient service = sessionClient.GetServiceSurClient ( CActionImprimerEtat.c_idServiceClientImprimerEtat );
							if ( service != null )
							{
								result = service.RunService ( report );
							}
						}
					}*/
					/*
								using ( CFichierLocalTemporaire fichierRpt = new CFichierLocalTemporaire("rpt") )
								{
									fichierRpt.CreateNewFichier();
									try
									{
										report.Refresh();
										report.SaveAs (fichierRpt.NomFichier, ReportFileFormat.VSNetFileFormat );
									}
									catch ( Exception e )
									{
										result.EmpileErreur ( new CErreurException ( e ) );
									}
									if ( result )
									{
										//Stocke le fichier dans la ged pour pouvoir l'envoyer sur le client
										using ( CProxyGED proxy = new CProxyGED ( Process.IdSession, null ) )
										{
											proxy.CreateNewFichier();
											proxy.AttacheToLocal ( fichierRpt.NomFichier );

											proxy.UpdateGed();

											CReferenceDocument refDoc = proxy.ReferenceAttachee;
											result = service.RunService ( refDoc );
											if ( !result )
											{
												result.EmpileErreur("Erreur à l'impression du document");
												return result;
											}
										}
									}
								}
							}
						}
					}*/
				}
				#endregion
			


				#region Stockage dans la ged
			
				if ( m_bStockerGed )
				{
					//On a notre fichier PDF, création du document
					string strCle = "";
					string strDescriptif = "";
					string strLibelle = "";
					result = ExpressionCle.Eval ( contexteEvaluation );
					if ( result )
						strCle = result.Data.ToString();
					else
					{
						result.EmpileErreur(I.T("Document key could not be evaluated|30050"));
						return result;
					}


					result = ExpressionLibelle.Eval ( contexteEvaluation );
					if ( result )
						strLibelle = result.Data.ToString();
					else
					{
                        result.EmpileErreur(I.T("Document label could not be evaluated|30051"));
						return result;
					}

					result = ExpressionDescriptif.Eval ( contexteEvaluation );
					if ( result )
						strDescriptif = result.Data.ToString();
					else
					{
                        result.EmpileErreur(I.T("Document description could not be evaluated|30052"));
						return result;
					}

					CDocumentGED doc = new CDocumentGED ( contexte.ContexteDonnee );
					//Si la clé n'est pas nulle, cherche un document avec cette clé
					if ( strCle.Trim() != "" )
					{
						CFiltreData filtre = new CFiltreData ( CDocumentGED.c_champCle+"=@1", strCle );
						if ( !doc.ReadIfExists ( filtre ) )
							doc.CreateNew();
						else
							doc.BeginEdit();
					}
					else
					{
						doc.CreateNew();
					}
					doc.Libelle = strLibelle;
					doc.Descriptif = strDescriptif;
					doc.Cle = strCle;
			
					ArrayList lstToCreate = (ArrayList)ListeIdsCategoriesStockage.Clone();
					ArrayList lstToDelete = new ArrayList();
					//Affecte les catégories
					CListeObjetsDonnees listeCategoriesExistantes = CRelationDocumentGED_Categorie.GetRelationsCategoriesForDocument ( doc );
					foreach ( CRelationDocumentGED_Categorie rel in listeCategoriesExistantes )
					{
						if ( !lstToCreate.Contains ( rel.Categorie.Id ) )
							lstToDelete.Add ( rel );
						lstToCreate.Remove ( rel.Categorie.Id );
					}
					foreach ( CRelationDocumentGED_Categorie rel in lstToDelete )
						rel.Delete();
					foreach ( int nId in lstToCreate )
					{
						CCategorieGED cat = new CCategorieGED( doc.ContexteDonnee );
						if ( cat.ReadIfExists ( nId ) )
						{
							CRelationDocumentGED_Categorie rel = new CRelationDocumentGED_Categorie ( doc.ContexteDonnee );
							rel.CreateNewInCurrentContexte();
							rel.Categorie = cat;
							rel.Document = doc;
						}
					}
					CProxyGED proxy = new CProxyGED ( Process.IdSession, doc.IsNew()?null:doc.ReferenceDoc );
					proxy.AttacheToLocal ( fichierPDF.NomFichier );
					result = proxy.UpdateGed();
					if ( !result )
						return result;
					doc.ReferenceDoc = (CReferenceDocument)result.Data;
					result = doc.CommitEdit();
					fichierPDF.Dispose();
					if ( VariableResultat != null )
						Process.SetValeurChamp ( VariableResultat, doc );
				}
				#endregion
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			finally
			{
				if ( report != null )
					report.Close();
			}

			return result;
		}
	}
}
