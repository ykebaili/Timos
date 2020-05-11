using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

using sc2i.common;
using sc2i.data;

namespace timos.data
{
	/// <summary>
	/// Représente les différences entre deux datatables
	/// </summary>
	public class CDifferencesTables : IDifferencesBlob
	{
		
		public enum ETypeOperationSurTable
		{
			CreationTable = 10,
			SuppressionTable = 20,
			ModificationLigne = 30
		}

		public class CChampPourVersionLigneDeTable : IChampPourVersion
		{
			public const string c_typeChamp = "CUSTOM_TABLE_ROW";
			
			public CChampPourVersionLigneDeTable(DataRow row)
			{
                StringBuilder sb = new StringBuilder();
				m_strFieldKey = "";
				bool bDeleted = row.RowState == DataRowState.Deleted;

				if (bDeleted)
					row.RejectChanges();

				foreach(DataColumn dc in row.Table.PrimaryKey)
					sb.Append(CUtilTexte.ToUniversalString(row[dc]).Replace("|","\\|") + "|");
				if (sb.Length == 0)
				{
					//A VOIR SI CE CAS PEUT EXISTER ETANT DONNER
					//QUE LE CDIFFERENCETABLE NE CONSIDERE PAS
					//LES MAPPAGES SUR DES TABLES SANS CLE
					foreach (DataColumn dc in row.Table.Columns)
						sb.Append( CUtilTexte.ToUniversalString(row[dc]).Replace("|","\\|") + "|");
                    if(sb.Length > 0)
                        m_strFieldKey = sb.ToString(0, sb.Length - 1);

					m_strNomConvivial = I.TT(GetType(), "Row without identification|553");
				}
				else
				{
                    //m_strFieldKey = m_strFieldKey.Substring(0, m_strFieldKey.Length - 1);
                    if (sb.Length > 0)
                        m_strFieldKey = sb.ToString(0, sb.Length - 1);
					//Ne pas traduire, Row key doit rester fixe (test en dur chez Audilog)
					m_strNomConvivial = "Row key " + m_strFieldKey;
				}

				if (m_strFieldKey == "")
					throw new Exception(I.TT(GetType(), "CANNOT IDENTIFY ROW (empty key)|555"));
				if (bDeleted)
					row.Delete();

			}

			#region IChampPourVersion Membres
			private string m_strFieldKey;
			public string FieldKey
			{
				get 
				{
					return m_strFieldKey;
				}
			}

			private string m_strNomConvivial;
			public string NomConvivial
			{
				get 
				{
					return m_strNomConvivial;
				}
			}

			public string TypeChampString
			{
				get { return c_typeChamp; }
			}

			#endregion

            private int GetNumVersion()
            {
                return 0;
            }

            public CResultAErreur Serialize(C2iSerializer serializer)
            {
                int nVersion = GetNumVersion();
                CResultAErreur result = serializer.TraiteVersion(ref nVersion);
                if (!result)
                    return result;
                return result;
            }
		}

		public class CDataRowConvertibleEnString : IValeurChampConvertibleEnString
		{
			public CDataRowConvertibleEnString(DataRow row)
			{
				m_row = row;
			}

			#region IValeurChampSerialisableEnString Membres
			public byte[] GetValBlob()
			{
				//On sauvegarde la structure de la table
				//Les données sont déjà sauvegardées dans le string
				DataTable dt = m_row.Table.Clone();
				return CUtilADataTable.SerializeDataTable(dt);
			}

			public int? GetCodeOperation()
			{
				return (int?)ETypeOperationSurTable.ModificationLigne;
			}

			public string GetStringSerialisation()
			{
                StringBuilder sb = new StringBuilder();
				string strResult = "";
				if (m_row != null)
					foreach (DataColumn c in m_row.Table.Columns)
					{
						if (c.ColumnName == "ID" || c.ColumnName == CTableParametrable.c_strColTimeStamp)
							continue;
						object val = null;
						if (m_row.RowState == DataRowState.Deleted)
							val = m_row[c, DataRowVersion.Original];
						else
							val = m_row[c];
						
                        sb.Append(CUtilTexte.ToUniversalString(val).Replace("|", "\\|") + "|");
						//strResult += CUtilTexte.ToUniversalString(val).Replace("|", "\\|") + "|";
					}
                if(sb.Length > 0)
                    strResult = sb.ToString(0, sb.Length-1);
				else
					strResult = I.T("No Value|556");
				return strResult;
			}

			private DataRow m_row;
			public object ValeurChamp
			{
				get
				{
					return m_row;
				}
				set
				{
					if (value.GetType() == typeof(DataRow))
						m_row = (DataRow)value;
				}
			}

			#endregion
		}
		

		//Contient la table des différences (utilise l'état des dataRow (added, deleted et modified))
		private DataTable m_tableDesDifferences = null;

		//----------------------------------------------------------
		public static CDifferencesTables GetDifferences(DataTable tableFinale, DataTable tableOriginale)
		{
			//if (tableFinale == null && tableOriginale == null)
			//    return null;
			CDifferencesTables differences = new CDifferencesTables();
			differences.CalculeModifications(tableFinale, tableOriginale);
			if (differences.HasDifferences())
				return differences;
			return null;
		}

		//----------------------------------------------------------
		public bool HasDifferences()
		{
			if (m_tableDesDifferences != null)
				return m_tableDesDifferences.Rows.Count > 0;
			return false;
		}

		//----------------------------------------------------------
		public DataTable TableDesDifferences
		{
			get
			{
				return m_tableDesDifferences;
			}
		}

		private bool m_bChangementClePrimaire;
		public bool ChangementClePrimaire
		{
			get
			{
				return m_bChangementClePrimaire;
			}
		}
		private bool m_bChangementTypeTable;
		public bool ChangementStructureTable
		{
			get
			{
				return m_bChangementTypeTable;
			}
		}
		private bool m_bCreationTable;
		public bool CreationTable
		{
			get
			{
				return m_bCreationTable;
			}
		}
		private bool m_bSuppressionTable;
		public bool SuppressionTable
		{
			get
			{
				return m_bSuppressionTable;
			}
		}

		//----------------------------------------------------------
		private void CalculeModifications(DataTable tableFinale, DataTable tableOriginale)
		{
			m_tableDesDifferences = null;
			m_bChangementTypeTable = false;
			m_bChangementClePrimaire = false;
			m_bSuppressionTable = false;
			m_bCreationTable = false;
			if (tableFinale == null && tableOriginale == null)
				return;

			//SUPPRESSION TABLE
			m_bSuppressionTable = tableFinale == null && tableOriginale != null;
			if (m_bSuppressionTable)
			{
				DataTable tableSupp = tableOriginale.Clone();
				foreach (DataRow dr in tableOriginale.Rows)
				{
					tableSupp.ImportRow(dr);
					tableSupp.Rows[tableSupp.Rows.Count - 1].Delete();
				}
				m_tableDesDifferences = tableSupp;
				return;
			}

			//CREATION TABLE
			m_bCreationTable = tableFinale != null && tableOriginale == null;

			if (!m_bCreationTable)
			{
				//CHANGEMENT TYPE TABLE
				foreach (DataColumn c in tableFinale.Columns)
					if (c.ColumnName != CTableParametrable.c_strColTimeStamp && !tableOriginale.Columns.Contains(c.ColumnName))
					{
						m_bChangementTypeTable = true;
						break;
					}

				//CHANGEMENT CLE PRIMAIRE
				m_bChangementClePrimaire = tableFinale.PrimaryKey.Length != tableOriginale.PrimaryKey.Length;
			}


			if (m_bCreationTable
				|| m_bChangementTypeTable 
				|| m_bChangementClePrimaire
				|| tableFinale.PrimaryKey.Length == 0)//Pas de clés->Table complete
			{
				m_tableDesDifferences = tableFinale;
				return;
			}

			//CHEZ PAS A KOI CA SERT CA!
			if (tableFinale == null)
				tableFinale = (DataTable)tableOriginale.Clone();
			if (tableOriginale == null)
				tableOriginale = (DataTable)tableFinale.Clone();

			m_tableDesDifferences = (DataTable)tableFinale.Clone();

			//Recherche les ajouts de lignes
			
			
			//Mappage de la table originale vers la table finale
			Dictionary<DataRow, DataRow> mapOriginalToFinal = new Dictionary<DataRow,DataRow>();
			//Mappage de la table finale vers la table originale
			Dictionary<DataRow, DataRow> mapFinalToOriginal = new Dictionary<DataRow, DataRow>();

			//Mappe les deux cotés
			foreach (DataRow rowOriginale in tableOriginale.Rows)
			{
				DataRow rowFinale = tableFinale.Rows.Find(GetKeys(rowOriginale));
				mapOriginalToFinal[rowOriginale] = rowFinale;
				if (rowFinale != null)
					mapFinalToOriginal[rowFinale] = rowOriginale;
			}
			foreach (DataRow rowFinale in tableFinale.Rows)
			{
				if (!mapFinalToOriginal.ContainsKey(rowFinale))
				{
					DataRow rowOriginale = tableOriginale.Rows.Find(GetKeys(rowFinale));
					mapFinalToOriginal[rowFinale] = rowOriginale;
					if (rowOriginale != null)//Ca ne devrait pas arriver !
						mapOriginalToFinal[rowOriginale] = rowFinale;
				}
			}

			//Traite les lignes supprimées et modifiées
			foreach (KeyValuePair<DataRow, DataRow> keyValue in mapOriginalToFinal)
			{
				DataRow rowOriginale = keyValue.Key;
				DataRow rowFinale = keyValue.Value;
				if (rowFinale == null || rowFinale.RowState == DataRowState.Deleted)
				{
					//C'est une suppression
					m_tableDesDifferences.ImportRow(rowOriginale);
					DataRow rowDiff = m_tableDesDifferences.Rows.Find(GetKeys(rowOriginale));
					if (rowDiff == null) //? comment serait-ce possible ?
						throw new Exception(I.T("SYSTEM ERROR, ROW IMPORT FAILED|557"));
					rowDiff.AcceptChanges();
					rowDiff.Delete();
				}
				else
				{
					m_tableDesDifferences.ImportRow(rowOriginale);
					DataRow rowDiff = m_tableDesDifferences.Rows.Find(GetKeys(rowOriginale));
					if (rowDiff == null) //? comment serait-ce possible ?
						throw new Exception(I.T("SYSTEM ERROR, ROW IMPORT FAILED|557"));
					rowDiff.AcceptChanges();
					foreach (DataColumn col in tableOriginale.Columns)
					{
						if (col.ColumnName == "ID" || col.ColumnName == CTableParametrable.c_strColTimeStamp)
							//On ne gère pas les différences sur les ids,
							//ni sur les dates
							continue;
						object valOriginale = rowOriginale[col];
						object valFinale = rowFinale[col.ColumnName];
						if (!valOriginale.Equals(valFinale))
							rowDiff[col.ColumnName] = valFinale;
					}
					if (rowDiff.RowState != DataRowState.Modified)
					{
						//Pas de modif
						m_tableDesDifferences.Rows.Remove(rowDiff);
					}
						//si modifiée, met la date de modification dans la ligne !
					else if ( rowDiff.Table.Columns[CTableParametrable.c_strColTimeStamp] != null &&
						rowFinale.Table.Columns[CTableParametrable.c_strColTimeStamp] != null )
						rowDiff[CTableParametrable.c_strColTimeStamp] = rowFinale[CTableParametrable.c_strColTimeStamp];
				}
			}

			//Traite les lignes ajoutées, les modifiées ont été traitées avant
			foreach (KeyValuePair<DataRow, DataRow> keyValue in mapFinalToOriginal)
			{
				DataRow rowFinale = keyValue.Key;
				DataRow rowOriginale = keyValue.Value;
				if (rowOriginale == null && rowFinale.RowState != DataRowState.Deleted)
				{
					m_tableDesDifferences.ImportRow(rowFinale);
					DataRow rowDiff = m_tableDesDifferences.Rows.Find(GetKeys(rowFinale));
					if (rowDiff == null) //? comment serait-ce possible ?
						throw new Exception(I.T("SYSTEM ERROR, ROW IMPORT FAILED|557"));
					rowDiff.AcceptChanges();
					rowDiff.SetAdded();
				}
			}
		}

		private object[] GetKeys(DataRow row)
		{
			DataRowVersion rowVersion = DataRowVersion.Current;
			if (row.RowState == DataRowState.Deleted)
				rowVersion = DataRowVersion.Original;
			ArrayList lst = new ArrayList();
			foreach (DataColumn col in row.Table.PrimaryKey)
				lst.Add(row[col, rowVersion]);
			return lst.ToArray();
		}

		//------------------------------------------------------
		private int GetNumVersion()
		{
			return 2;
		}

		//------------------------------------------------------
		public sc2i.common.CResultAErreur Serialize(C2iSerializer serializer)
		{
			int nVersion = GetNumVersion();
			CResultAErreur result = serializer.TraiteVersion(ref nVersion);
			if (!result)
				return result;

			//Serialisation de la table
			bool bHasTable = m_tableDesDifferences != null;
			serializer.TraiteBool(ref bHasTable);
		
			if (bHasTable)
			{
				if (serializer.Mode == ModeSerialisation.Ecriture)
				{
					//Il faut sérialiser un dataset pour que 
					//Les rowState soient sauvegardés
					DataSet ds = new DataSet();
					ds.Tables.Add(m_tableDesDifferences);
					//Serialise la table des différences
					MemoryStream s = new MemoryStream();
					GZipStream szip = new GZipStream(s, CompressionMode.Compress);
					BinaryFormatter format = new BinaryFormatter();
					format.Serialize(szip, ds);
					szip.Close();
					ds.Tables.Remove(m_tableDesDifferences);
					byte[] data = s.GetBuffer();
					serializer.TraiteByteArray(ref data);
				}
				if (serializer.Mode == ModeSerialisation.Lecture)
				{
					byte[] data = null;
					serializer.TraiteByteArray(ref data);
					DataSet ds = new DataSet();
					Stream s = new MemoryStream(data);
					GZipStream szip = new GZipStream(s, CompressionMode.Decompress);
					BinaryFormatter format = new BinaryFormatter();
					try
					{
						ds = (DataSet)format.Deserialize(szip);
						szip.Close();
						m_tableDesDifferences = ds.Tables[0];
						ds.Tables.Remove(m_tableDesDifferences);
					}
					catch
					{
						result.EmpileErreur(I.T("Error while reading datatable|545"));
					}
				}
			}
			if (nVersion > 0)
			{
				serializer.TraiteBool(ref m_bChangementClePrimaire);
				serializer.TraiteBool(ref m_bChangementTypeTable);
			}
			if (nVersion > 1)
			{
				serializer.TraiteBool(ref m_bCreationTable);
				serializer.TraiteBool(ref m_bSuppressionTable);
			}
			return result;
		}

		public void RedoModifs(ref DataTable table)
		{
			if (m_tableDesDifferences != null)
			{
				if (table == null)
					table = (DataTable)m_tableDesDifferences.Clone();
				if (m_tableDesDifferences.PrimaryKey.Length == 0)
				{
					//C'est donc toute la table
					table.Rows.Clear();
					table.Merge(m_tableDesDifferences);
					table.AcceptChanges();
				}
				else
				{
					DataSet ds = new DataSet();
					//Vérifie les types des colonnes
					foreach (DataColumn col in table.Columns)
					{
						DataColumn colModif = m_tableDesDifferences.Columns[col.ColumnName];
						if (colModif != null && colModif.DataType != col.DataType)
						{
							CUtilDataSet.ChangeTypeColonne(ref colModif, col.DataType);
						}
					}
					table.AcceptChanges();
					ds.Tables.Add(table);
					table.BeginLoadData();
					table.Merge(m_tableDesDifferences, false);
					//CUtilDataSet.Merge(m_tableDesDifferences, ds, false);
					ds.Tables.Remove(table);

					table.EndLoadData();
					table.AcceptChanges();
				}
			}
						
		}

		public List<CDetailOperationSurObjet> GetDetails()
		{
			List<CDetailOperationSurObjet> lstOpe = new List<CDetailOperationSurObjet>();
			if (TableDesDifferences.Columns.Contains(CTableParametrable.c_strColTimeStamp))
				TableDesDifferences.DefaultView.Sort = CTableParametrable.c_strColTimeStamp;
			TableDesDifferences.DefaultView.RowStateFilter = TableDesDifferences.DefaultView.RowStateFilter | DataViewRowState.Deleted;
			if (!m_bChangementClePrimaire && !m_bChangementTypeTable)
				
				foreach (DataRowView rowView in TableDesDifferences.DefaultView)
				{
					DataRow row = rowView.Row;
					DataRowVersion versionForRow = DataRowVersion.Current;
					if (row.RowState == DataRowState.Deleted)
						versionForRow = DataRowVersion.Original;
					CDetailOperationSurObjet op = new CDetailOperationSurObjet();
					CChampPourVersionLigneDeTable champ = new CChampPourVersionLigneDeTable(row);
					op.Champ = champ;
					if (row[CTableParametrable.c_strColTimeStamp, versionForRow] != DBNull.Value)
						op.TimeStampModification = (DateTime)row[CTableParametrable.c_strColTimeStamp, versionForRow];
					else
						op.TimeStampModification = null;
					CDataRowConvertibleEnString ligneOrigine = new CDataRowConvertibleEnString(row);
					if (row.RowState == DataRowState.Added)
					{
						op.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Ajout);
						op.ValeurSource = null;
						op.ValeurCible = new CDataRowConvertibleEnString(row);
					}
					else if (row.RowState == DataRowState.Deleted)
					{
						op.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Suppression);
						op.ValeurSource = new CDataRowConvertibleEnString(row);
						op.ValeurCible = null;
					}
					else
					{
						op.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Modification);
						DataRow drSource = row.Table.NewRow();
						foreach (DataColumn dc in row.Table.Columns)
						{
							if (row.HasVersion(DataRowVersion.Original))
								drSource[dc] = row[dc, DataRowVersion.Original];
							else
							{
								//POSSIBLE ?
							}
						}
						op.ValeurCible = new CDataRowConvertibleEnString(row);
						op.ValeurSource = new CDataRowConvertibleEnString(drSource);
					}
					if (m_bCreationTable)
					{
						op.TypeOperation = new CTypeOperationSurObjet(CTypeOperationSurObjet.TypeOperation.Ajout);
						op.ValeurSource = null;
					}
					lstOpe.Add(op);
				}
			else if(m_bChangementClePrimaire)
			{

			}
			else if (m_bChangementTypeTable)
			{
				//revient au même que changement de clé ?
			}
			else if (m_bCreationTable)
			{
			}
			else if (m_bSuppressionTable)
			{
			}
			return lstOpe;
		}

        
	}
}
