using System;
using System.Drawing;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using sc2i.data;
using sc2i.process;
using sc2i.common;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;

using sc2i.workflow;
using sc2i.documents;
using sc2i.multitiers.client;
using timos.acteurs;
using timos.securite;
using timos.data;
using System.IO;
using sc2i.data.Excel;


namespace sc2i.process
{
	/// <summary>
	/// Description résumée de CActionModifierPropriete.
	/// </summary>
	[AutoExec("Autoexec")]
	public class CActionImporterTable : CActionLienSortantSimple
	{
		private C2iExpression m_formuleTableAImporter = null;
		private C2iExpression m_formuleFichierSource = null;
		private EImportTableParametrableMode m_modeImport = EImportTableParametrableMode.Update_Or_Create;
		/// /////////////////////////////////////////
		public CActionImporterTable( CProcess process )
			:base(process)
		{
			Libelle = I.T("Table import|502");
		}

		/// /////////////////////////////////////////////////////////
		public static void Autoexec()
		{
			CGestionnaireActionsDisponibles.RegisterTypeAction(
				I.T( "Table import|502"),
				I.T( "Imports a text file in a table|503"),
				typeof(CActionImporterTable),
				CGestionnaireActionsDisponibles.c_categorieMetier );
		}


		/// /////////////////////////////////////////
		private int GetNumVersion()
		{
			return 0;
		}

		/// /////////////////////////////////////////////////////////
		public override bool PeutEtreExecuteSurLePosteClient
		{
			get { return true; }
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleTableAImporter
		{
			get
			{
				return m_formuleTableAImporter;
			}
			set
			{
				m_formuleTableAImporter = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public C2iExpression FormuleFichierSource
		{
			get
			{
				return m_formuleFichierSource;
			}
			set
			{
				m_formuleFichierSource = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		public EImportTableParametrableMode ModeImport
		{
			get
			{
				return m_modeImport;
			}
			set
			{
				m_modeImport = value;
			}
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MySerialize ( C2iSerializer serializer )
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion ( ref nVersion );
			if ( !result )
				return result;
			result = base.MySerialize( serializer );
			if (result)
			{
				I2iSerializable tmp = m_formuleTableAImporter;
				result = serializer.TraiteObject(ref tmp);
				m_formuleTableAImporter = (C2iExpression)tmp;
			}
			if (result)
			{
				I2iSerializable tmp = m_formuleFichierSource;
				result = serializer.TraiteObject(ref tmp);
				m_formuleFichierSource = (C2iExpression)tmp;
			}

			int nTmp = (int)m_modeImport;
			serializer.TraiteInt(ref nTmp);
			m_modeImport = (EImportTableParametrableMode)nTmp;

			return result;
		}

		
		/// ////////////////////////////////////////////////////////
		public override CResultAErreur VerifieDonnees()
		{
			CResultAErreur result = base.VerifieDonnees();
			if ( m_formuleTableAImporter == null || 
				!(m_formuleTableAImporter.TypeDonnee.TypeDotNetNatif == typeof(CTableParametrable)) ||
				m_formuleTableAImporter.TypeDonnee.IsArrayOfTypeNatif)
				result.EmpileErreur(I.T("Incorrect destination table formula|505"));
			if (m_formuleFichierSource== null ||
				(!(m_formuleFichierSource.TypeDonnee.TypeDotNetNatif == typeof(string)) && 
                !(m_formuleFichierSource.TypeDonnee.TypeDotNetNatif == typeof(CDocumentGED)))||
				m_formuleTableAImporter.TypeDonnee.IsArrayOfTypeNatif)
				result.EmpileErreur(I.T("Incorrect source file formula|506"));
			return result;
		}

		/// ////////////////////////////////////////////////////////
		protected override CResultAErreur MyExecute(CContexteExecutionAction contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			CProxyGED proxy = null;
            try
            {
                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(Process);
                if (FormuleFichierSource == null)
                {
                    result.EmpileErreur(I.T("Incorrect source file formula|506"));
                    return result;
                }
                result = FormuleFichierSource.Eval(ctxEval);
                if (!result)
                    return result;


                string strFichier = "";

                if (result.Data is CDocumentGED)
                {
                    CDocumentGED doc = result.Data as CDocumentGED;
                    proxy = new CProxyGED(contexte.IdSession, doc.ReferenceDoc);
                    result = proxy.CopieFichierEnLocal();
                    if (!result)
                        return result;
                    strFichier = proxy.NomFichierLocal;
                }
                else
                    strFichier = result.Data.ToString();
                if (!File.Exists(strFichier))
                {
                    result.EmpileErreur(I.T("Source file @1 doesn't exist |508", result.Data.ToString()));
                    return result;
                }

                if (FormuleTableAImporter == null)
                {
                    result.EmpileErreur(I.T("Incorrect destination table formula|505"));
                    return result;
                }
                result = FormuleTableAImporter.Eval(ctxEval);
                if (!result)
                {
                    result.EmpileErreur(I.T("Error while evaluating destination table formula|510"));
                    return result;
                }
                if (!(result.Data is CTableParametrable))
                {
                    result.EmpileErreur(I.T("Destination table formula doesn't return a table|511"));
                    return result;
                }
                CTableParametrable tableParametrable = (CTableParametrable)result.Data;

                if (tableParametrable.TypeTable.ParametrageCSV == null)
                {
                    result.EmpileErreur(I.T("Table type @1 doesn't contains import setup|20002", tableParametrable.TypeTable.Libelle));
                    return result;
                }
                
                // Sélectionne le type de fichier Excel ou CSV (texte)
                IParametreLectureFichier parametre;
                int nPositionduPoint = strFichier.LastIndexOf('.');
                string strExtension = strFichier.Substring(nPositionduPoint + 1, strFichier.Length - nPositionduPoint - 1);
                if (strExtension.ToUpper() == "XLS" || strExtension.ToUpper() == "XLSX")
                    parametre = tableParametrable.TypeTable.ParametrageXLS;
                else
                    parametre = tableParametrable.TypeTable.ParametrageCSV;
                
                result = parametre.LectureFichier(strFichier);

                if (!result || !(result.Data is DataTable))
                {
                    result.EmpileErreur(I.T("Error while reading text file|509"));
                    return result;
                }
                DataTable tableSource = (DataTable)result.Data;

                Dictionary<DataColumn, CColonneTableParametrable> mappage = new Dictionary<DataColumn, CColonneTableParametrable>();
                int nNbChamps = Math.Min(parametre.Mappage.StringsA.Count, parametre.Mappage.StringsB.Count);
                for (int nChamp = 0; nChamp < nNbChamps; nChamp++)
                {
                    DataColumn col = tableSource.Columns[parametre.Mappage.StringsA[nChamp]];
                    if (col != null)
                    {
                        CColonneTableParametrable colRetenue = null;
                        foreach (CColonneTableParametrable colonne in tableParametrable.TypeTable.Colonnes)
                            if (colonne.Libelle == parametre.Mappage.StringsB[nChamp])
                            {
                                colRetenue = colonne;
                                break;
                            }
                        if (colRetenue != null)
                            mappage[col] = colRetenue;
                    }
                }


                // Réalise l'import
                result = tableParametrable.ImportTable(tableSource, mappage, m_modeImport);
                if (!result)
                    return result;
            }
            catch (Exception e)
            {
                result.EmpileErreur(new CErreurException(e));
            }
            finally
            {
                if (proxy != null)
                    proxy.Dispose();
            }

			return result;
		}

		//-----------------------------------------------
		public override void AddIdVariablesNecessairesInHashtable(Hashtable table)
		{
            AddIdVariablesExpressionToHashtable(FormuleFichierSource, table);
            AddIdVariablesExpressionToHashtable(FormuleTableAImporter, table);			
			
		}
	}
}
