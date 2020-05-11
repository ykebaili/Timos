using System;
using System.Drawing;
using System.Data;
using System.Collections;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;

namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionExporterDonnees : CActionFonction
	{
        public const string c_idServiceClientExporterDonnees = "ACTION_EXPORTER_DONNEES";
        
        // Variables membres
        private CMultiStructureExport m_structureExport = new CMultiStructureExport();
		private ArrayList m_listeIdsCategorieStockage = new ArrayList();
		private C2iExpression m_expressionCleGED = new C2iExpressionConstante("");
		private C2iExpression m_expressionLibelleDocument = null;
		private C2iExpression m_expressionDescriptifDocument = null;
		private IExporteurDataset m_exporteur = new CExporteurDatasetText("\t")	;

        private bool m_bUtiliserFormule = false;
		private C2iExpression m_expressionSelectedStructure = null;

        

		/// /////////////////////////////////////////
		public CActionExporterDonnees( CProcess process )
			:base(process)
		{
			Libelle = I.T("Export data|403");
			VariableRetourCanBeNull = true;
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Export data|403"),
				I.T( "Allows data to be exported and save the result in the EDM|404"),
				typeof(CActionExporterDonnees),
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
            //return 0;
            return 1; // Ajout de la Formule de sélection d'une structure existante
		}


		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );
			if ( !result )
				return result;

			I2iSerializable objet = m_structureExport;
			result = serializer.TraiteObject ( ref objet );
			if ( !result )
				return result;
			m_structureExport = (CMultiStructureExport)objet;

			objet = m_expressionCleGED;
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

			objet =  (I2iSerializable)m_exporteur;
			result =  serializer.TraiteObject ( ref objet, new object[0] );
			if ( !result )
				return result;
			m_exporteur = (IExporteurDataset)objet;

            if (nVersion >= 1)
            {
                serializer.TraiteBool(ref m_bUtiliserFormule);
                result = serializer.TraiteObject<C2iExpression>(ref m_expressionSelectedStructure);
                if (!result)
                    return result;
            }

			AssureVariableProcessDansStructure();
			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();



			return result;
		}

		/// ////////////////////////////////////////////////////////
		public const string c_champProcess = "RunningAction";
		private IVariableDynamique AssureVariableProcessDansStructure()
		{
			if ( m_structureExport == null )
				return null;
			foreach ( IVariableDynamique variable in m_structureExport.ListeVariables )
				if (variable.Nom == c_champProcess)
				{
					m_structureExport.SetValeurChamp(variable, Process);
					return variable;
				}
			CVariableDynamiqueSysteme newVariable = new CVariableDynamiqueSysteme(m_structureExport);
			newVariable.Nom = c_champProcess;
			newVariable.SetTypeDonnee ( new sc2i.expression.CTypeResultatExpression(typeof(CProcess),false) );
			m_structureExport.AddVariable ( newVariable );
			m_structureExport.SetValeurChamp ( newVariable.IdVariable, Process );
			return newVariable;
		}

		/// ////////////////////////////////////////////////////////

        public bool UtiliserFormule 
        {
            get
            {
                return m_bUtiliserFormule;
            }
            set
            {
                m_bUtiliserFormule = value;
            }
        
        }

        public C2iExpression ExpressionStructure
        {
            get
            {
                return m_expressionSelectedStructure;
            }
            set
            {
                m_expressionSelectedStructure = value;
            }
        }


		public CMultiStructureExport StructureExport
		{
			get
			{
                if (UtiliserFormule)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(Process);
                    CResultAErreur result = ExpressionStructure.Eval(ctx);
                    C2iStructureExportInDB structure = result.Data as C2iStructureExportInDB;

                    if (structure != null)
                        return structure.MultiStructure;
                    return null;
                }


                if (m_structureExport == null)
                {
                    m_structureExport = new CMultiStructureExport(Process.ContexteExecution.ContexteDonnee);
                }
                AssureVariableProcessDansStructure();
                return m_structureExport;
                
			}
			set
			{
				m_structureExport = value;
				AssureVariableProcessDansStructure();
			}
		}

		/// ////////////////////////////////////////////////////////
		public IExporteurDataset Exporteur
		{
			get
			{
				if ( m_exporteur == null )
					m_exporteur = new CExporteurDatasetText("\t");
				return m_exporteur;
			}
			set
			{
				m_exporteur = value;
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

        

        public byte[] GetDataSerialisationFormulairePourClient()
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
            CSerializerSaveBinaire serializer = new CSerializerSaveBinaire(writer);
            I2iSerializable ser = StructureExport.Formulaire;
            serializer.TraiteObject(ref ser);
            byte[] buffer = stream.GetBuffer();
            writer.Close();
            stream.Close();
            return buffer;
        }


        protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
        {
            return CResultAErreur.True;
        }

        private CMultiStructureExport m_structureUtiliseeAExecution = null;
        /// ////////////////////////////////////////////////////////
        public CMultiStructureExport StructureEnExecution
        {
            get
            {
                return m_structureUtiliseeAExecution;
            }
        }

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur ExecuteAction(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			
			try
			{
                // Récupère la structure par formule ou structure propore
                m_structureUtiliseeAExecution = StructureExport;

                IVariableDynamique variableProcess = AssureVariableProcessDansStructure();
                m_structureUtiliseeAExecution.SetValeurChamp(variableProcess.IdVariable, Process);
                m_structureUtiliseeAExecution.ContexteDonnee = contexte.ContexteDonnee;

                // Si la structure possede un formulaire il faut lancer le service sur le poste client
                if (m_structureUtiliseeAExecution != null && m_structureUtiliseeAExecution.Formulaire != null && m_structureUtiliseeAExecution.Formulaire.Childs.Length > 0)
                {
                    CSessionClient sessionClient = CSessionClient.GetSessionForIdSession(contexte.IdSession);
                    if (sessionClient != null)
                    {
                        //TESTDBKEYOK
                        if (sessionClient.GetInfoUtilisateur().KeyUtilisateur == contexte.Branche.KeyUtilisateur)
                        {
                            using (C2iSponsor sponsor = new C2iSponsor())
                            {
                                CServiceSurClient service = sessionClient.GetServiceSurClient(c_idServiceClientExporterDonnees);
                                if (service != null)
                                {
                                    sponsor.Register(service);

                                    result = service.RunService(this);

                                    E2iDialogResult dResult = (E2iDialogResult)result.Data;
                                    if (dResult == E2iDialogResult.Cancel)
                                    {
                                        foreach (CLienAction lien in GetLiensSortantHorsErreur())
                                        {
                                            if (lien is CLienFromDialog &&
                                                ((CLienFromDialog)lien).ResultAssocie == dResult)
                                            {
                                                result.Data = lien;
                                                return result;
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    //Utilisateur pas accessible
                                    foreach (CLienAction lien in GetLiensSortantHorsErreur())
                                    {
                                        if (lien is CLienUtilisateurAbsent)
                                        {
                                            result.Data = lien;
                                            return result;
                                        }
                                    }
                                }

                            }
                        }
                    }

                    else
                    {
                        //Utilisateur pas accessible
                        foreach (CLienAction lien in GetLiensSortantHorsErreur())
                        {
                            if (lien is CLienUtilisateurAbsent)
                            {
                                result.Data = lien;
                                return result;
                            }
                        }
                    }
                }


                result = m_structureUtiliseeAExecution.GetDataSet(Exporteur.ExporteStructureOnly);
                if (!result)
                {
                    result.EmpileErreur(I.T("Error while exporting data|405"));
                    return result;
                }

                DataSet ds = (DataSet)result.Data;

                // Fichier d'export retourné
                CFichierLocalTemporaire fichierExport = new CFichierLocalTemporaire(Exporteur.ExtensionParDefaut);
                fichierExport.CreateNewFichier();
                CDestinationExportFile dest = new CDestinationExportFile(fichierExport.NomFichier);
                result = Exporteur.Export(ds, dest);
                if (!result)
                {
                    result.EmpileErreur(I.T("Error while creating export file|406"));
                    return result;
                }

                #region Stockage dans la ged

                CContexteEvaluationExpression contexteEvaluation = new CContexteEvaluationExpression(Process);
                //On a notre fichier export, création du document
                string strCle = "";
                string strDescriptif = "";
                string strLibelle = "";
                result = ExpressionCle.Eval(contexteEvaluation);
                if (result)
                    strCle = result.Data.ToString();
                else
                {
                    result.EmpileErreur(I.T("The document key could not be calculated|407"));
                    return result;
                }


                result = ExpressionLibelle.Eval(contexteEvaluation);
                if (result)
                    strLibelle = result.Data.ToString();
                else
                {
                    result.EmpileErreur(I.T("The document label could not be calculated|408"));
                    return result;
                }

                result = ExpressionDescriptif.Eval(contexteEvaluation);
                if (result)
                    strDescriptif = result.Data.ToString();
                else
                {
                    result.EmpileErreur(I.T("The document description could not be calculated|409"));
                    return result;
                }

                CDocumentGED doc = new CDocumentGED(contexte.ContexteDonnee);
                //Si la clé n'est pas nulle, cherche un document avec cette clé
                if (strCle.Trim() != "")
                {
                    CFiltreData filtre = new CFiltreData(CDocumentGED.c_champCle + "=@1", strCle);
                    if (!doc.ReadIfExists(filtre))
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
                CListeObjetsDonnees listeCategoriesExistantes = CRelationDocumentGED_Categorie.GetRelationsCategoriesForDocument(doc);
                foreach (CRelationDocumentGED_Categorie rel in listeCategoriesExistantes)
                {
                    if (!lstToCreate.Contains(rel.Categorie.Id))
                        lstToDelete.Add(rel);
                    lstToCreate.Remove(rel.Categorie.Id);
                }
                foreach (CRelationDocumentGED_Categorie rel in lstToDelete)
                    rel.Delete();
                foreach (int nId in lstToCreate)
                {
                    CCategorieGED cat = new CCategorieGED(doc.ContexteDonnee);
                    if (cat.ReadIfExists(nId))
                    {
                        CRelationDocumentGED_Categorie rel = new CRelationDocumentGED_Categorie(doc.ContexteDonnee);
                        rel.CreateNewInCurrentContexte();
                        rel.Categorie = cat;
                        rel.Document = doc;
                    }
                }
                CProxyGED proxy = new CProxyGED(Process.IdSession, doc.IsNew() ? null : doc.ReferenceDoc);
                proxy.AttacheToLocal(fichierExport.NomFichier);
                result = proxy.UpdateGed();
                if (!result)
                    return result;
                doc.ReferenceDoc = (CReferenceDocument)result.Data;
                result = doc.CommitEdit();
                fichierExport.Dispose();
                if (VariableResultat != null)
                    Process.SetValeurChamp(VariableResultat, doc);

                #endregion

                foreach (CLienAction lien in GetLiensSortantHorsErreur())
                {
                    if (lien is CLienFromDialog &&
                        ((CLienFromDialog)lien).ResultAssocie != E2iDialogResult.Cancel)
                    {
                        result.Data = lien;
                        return result;
                    }
                }

                result.Data = null;
                return result;


			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			finally
			{
				
			}

			return result;
		}

        protected override CLienAction[] GetMyLiensSortantsPossibles()
        {
            CLienAction[] listeLiens = GetLiensSortantHorsErreur();
            bool bHasOk = false;
            bool bHasCancel = false;
            bool bHasLienUtilisateurAbsent = false;
            foreach (CLienAction lien in listeLiens)
            {
                if (lien is CLienFromDialog)
                {
                    CLienFromDialog lienDialog = (CLienFromDialog)lien;
                    bHasOk |= lienDialog.ResultAssocie == E2iDialogResult.OK;
                    bHasCancel |= lienDialog.ResultAssocie == E2iDialogResult.Cancel;
                }
                if (lien is CLienUtilisateurAbsent)
                    bHasLienUtilisateurAbsent = true;
            }

            ArrayList lst = new ArrayList();
            if (!bHasOk)
                lst.Add(new CLienFromDialog(Process, E2iDialogResult.OK));
            if (!bHasCancel)
                lst.Add(new CLienFromDialog(Process, E2iDialogResult.Cancel));
            if (!bHasLienUtilisateurAbsent)
                lst.Add(new CLienUtilisateurAbsent(Process));

            return (CLienAction[])lst.ToArray(typeof(CLienAction));
        }
	}
}
