using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.IO.Compression;
using System.Text;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.workflow;
using sc2i.multitiers.client;


using Lys.Licence;
using Lys.Applications.Timos.Smt;

using timos.data.version;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Une Table paramétrable permet de stocker des données sous forme<br/>
    /// d'une table définie par l'utilisateur. On y a recours, en général, lorsqu'il faut<br/>
    /// stocker un gros volume de données : exemple, la table de routage d'un routeur,<br/>
    /// la liste des fréquences et canaux d'émission d'un émetteur hertzien;<br/>
    /// dans ces cas, la table paramétrable est en général mieux adaptée qu'un formulaire.<br/>
    /// Les données peuvent être importées dans une table paramétrable à partir d'un fichier .CSV.
    /// </summary>
    /// <remarks>
    /// Une table paramétrable peut être liée à un <see cref="CSite">site</see> ou à un <see cref="CEquipement">équipement</see>, ou être autonome.<br/>
    /// Une table paramétrable est typée et la structure de données est définie par<br/>
    /// son <see cref="CTypeTableParametrable">type de table paramétrable</see>.
    /// </remarks>
	[DynamicClass("Custom Table")]
	[Table(CTableParametrable.c_nomTable, CTableParametrable.c_champId, true)]
	[FullTableSync]
	[AutoExec("Autoexec")]
	[ObjetServeurURI("CTableParametrableServeur")]
    [AModulesApp(CConfigModulesTimos.c_appModule_TablesParam_ID)]
    public class CTableParametrable : CObjetDonneeAIdNumeriqueAuto,
		IObjetDonneeAChamps,
		IElementATypeStructurant<CTypeTableParametrable>,
		IObjetABlobAVersionPartielle

	{

        private const string c_extPropTableParametrable = "CUSTOM_TABLE";

		public const string c_nomTable = "CUSTOM_TABLE";

		public const string c_champId = "TABLE_ID";
		public const string c_champLibelle = "TABLE_LABEL";
		public const string c_champTblBlob = "TABLE_TBLBLOB";
		public const string c_champTbl = "TABLE_DATATABLEOBJECT";


		public const string c_roleChampCustom = "CUSTOMTABLE";

		public const string c_strColTimeStamp = "TIMOS_TIMESTAMP";

		/// <summary>
		/// ExtProperty du datatable indiquant (si non null) que les changements
		/// sont interceptés pour mise à jour de la date de dernière modif
		/// </summary>
		private const string c_strExtPropChangeHandeled = "TIMOS_CHANGEd_HANDLED";


		/// /////////////////////////////////////////////
		public CTableParametrable(CContexteDonnee contexte)
			: base(contexte)
		{
		}

		/// /////////////////////////////////////////////
		public CTableParametrable(DataRow row)
			: base(row)
		{
		}


		public static void Autoexec()
		{
			CRoleChampCustom.RegisterRole(c_roleChampCustom, "Custom Table", typeof(CTableParametrable),typeof(CTypeTableParametrable));
		}

        //-------------------------------------------------------------------
        public CRoleChampCustom RoleChampCustomAssocie
        {
            get
            {
                return CRoleChampCustom.GetRole(c_roleChampCustom);
            }
        }



		[TableFieldProperty(c_champTblBlob, NullAutorise = true)]
		public CDonneeBinaireInRow DataTableBlob
		{
			get
			{
				if (Row[c_champTblBlob] == DBNull.Value)
				{
					CDonneeBinaireInRow donnee = new CDonneeBinaireInRow(ContexteDonnee.IdSession, Row, c_champTblBlob);
					CContexteDonnee.ChangeRowSansDetectionModification(Row, c_champTblBlob, donnee);
				}
				object obj = Row[c_champTblBlob];
				return ((CDonneeBinaireInRow)obj).GetSafeForRow(Row.Row);
			}
			set
			{
				Row[c_champTblBlob] = value;
			}
		}

		//----------------------------------------------------
		private static DataTable ReadTable ( byte[] donnees )
		{
			Stream s = new MemoryStream(donnees);
			GZipStream szip = new GZipStream(s, CompressionMode.Decompress);
			BinaryFormatter format = new BinaryFormatter();
			DataTable dt = null;
			try
			{
				dt = (DataTable)format.Deserialize(szip);
				szip.Close();
			}
			catch
			{
				dt = null;
			}
			return dt;
		}

		//----------------------------------------------------
		private static byte[] SaveTable ( DataTable table )
		{
			MemoryStream s = new MemoryStream();
			GZipStream szip = new GZipStream(s, CompressionMode.Compress);
			BinaryFormatter format = new BinaryFormatter();
			object oldValue = table.ExtendedProperties[c_strExtPropChangeHandeled];
			table.ExtendedProperties.Remove(c_strExtPropChangeHandeled);
			format.Serialize(szip, table);
			if (oldValue != null)
				table.ExtendedProperties[c_strExtPropChangeHandeled] = oldValue;
			szip.Close();
			return s.ToArray();
		}


		//----------------------------------------------------
        /// <summary>
        /// Objet DataTable correspondant
        /// </summary>
		[DynamicField("DataTableObject")]
		[TableFieldProperty(c_champTbl, IsInDb = false)]
		public DataTable DataTableObject
		{
			get
			{
				DataTable dt = new DataTable(Libelle);
				
				if (Row[c_champTbl] is DataTable)
					dt = (DataTable)Row[c_champTbl];
				else if (DataTableBlob != null && DataTableBlob.Donnees != null)
				{
					dt = ReadTable ( DataTableBlob.Donnees );
					if(dt != null)
                        dt.TableName = Libelle;
				}
				else
					dt = null;

				if(dt == null 
					|| (TypeTable == null && dt.Columns.Count != 0)
					|| (TypeTable != null && ((dt.Columns.Count != (TypeTable.Colonnes.Count + 2) &&
					dt.Columns[c_strColTimeStamp]!=null) || (TypeTable.Colonnes.Count +1 != dt.Columns.Count &&
					dt.Columns[c_strColTimeStamp] == null))))
				{
					RAZDataTable();
					dt = DataTableObject;
				}

				//SAV CACHE
                CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champTbl, dt);

				PrepareToForUse(dt, this);

                
				
				
				return dt;
			}
			set
			{
				if (value != null)
				{
					DataTableBlob.Donnees = SaveTable ( value );
				}
				else
				{
					RAZDataTable();
				}
				Row[c_champTbl] = null;
			}
		}

		internal static void PrepareToForUse(DataTable table, CTableParametrable tableParametrable)
		{
			//Ajout d'une colonne TimeStamp
			if (table.Columns[c_strColTimeStamp] == null)
			{
				DataColumn col = new DataColumn(c_strColTimeStamp, typeof(DateTime));
				col.AllowDBNull = true;
				col.DefaultValue = DBNull.Value;
				table.Columns.Add(col);
			}

			//s'assure que le changement de valeurs est bien intercepté pour
			//mettre à jour la date de dernière modif
			if (table.ExtendedProperties[c_strExtPropChangeHandeled] == null)
			{
				table.RowChanged += new DataRowChangeEventHandler(OnChangementDansUneLigne);
				table.ExtendedProperties[c_strExtPropChangeHandeled] = true;
				table.RowDeleting += new DataRowChangeEventHandler(OnChangementDansUneLigne);
			}

            table.ExtendedProperties[c_extPropTableParametrable] = tableParametrable;
		}

		static void OnChangementDansUneLigne(object sender, DataRowChangeEventArgs e)
		{
			if ( e.Row != null )
			{
				DataRow row = e.Row;

				
				
				if ( row.Table != null )
					if (row.Table.Columns[c_strColTimeStamp] != null)
					{
						DataRowVersion version = DataRowVersion.Current;
						if (row.RowState == DataRowState.Deleted)
							version = DataRowVersion.Original;
						if (row[c_strColTimeStamp, version] != DBNull.Value)
						{
							TimeSpan sp = DateTime.Now - (DateTime)row[c_strColTimeStamp];
							if (sp.TotalSeconds < 1)
								return;
						}
						try
						{
							row[c_strColTimeStamp] = DateTime.Now;
						}

						catch { }
					}
			}
		}

        /// <summary>
        /// Retourne le nombre d'enregistrements dans la table
        /// </summary>
		[DynamicField("Rows Count")]
		public int NombreLignes
		{
			get
			{
				if (DataTableObject != null)
					return DataTableObject.Rows.Count;
				return 0;
			}
		}



		public void ClearDataTableInCache()
		{
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champTbl, DBNull.Value);
		}

		/// /////////////////////////////////////////////
		public override string DescriptionElement
		{
			get { return I.T("Custom Table @1|435", Libelle); }
		}

		/// <summary>
		/// Donne ou définit le Libellé de la table paramétrable<br/>
		/// (obligatoire)
		/// </summary>
		[TableFieldProperty(c_champLibelle, 255)]
		[DynamicField("Label")]
		public string Libelle
		{
			get { return (string)Row[c_champLibelle]; }
			set { Row[c_champLibelle] = value; }
		}


        /// <summary>
        /// Donne ou définit le type de table paramétrable
        /// </summary>
		[Relation(
			CTypeTableParametrable.c_nomTable,
			CTypeTableParametrable.c_champId,
			CTypeTableParametrable.c_champId,
			true,
			false,
			true)]
		[DynamicField("Custom table type")]
		public CTypeTableParametrable TypeTable
		{
			get { return (CTypeTableParametrable)GetParent(CTypeTableParametrable.c_champId, typeof(CTypeTableParametrable)); }
			set
			{
				if (value != TypeTable)
				{
					SetParent(CTypeTableParametrable.c_champId, value);
					RAZDataTable();
				}
			}
		}

		
		//------------------------------------------------------------
		public IElementATableParametrable ElementLie
		{
			get
			{
				if (Equipement != null)
					return Equipement;
				return Site;
			}
			set
			{
				if (value is CEquipement)
				{
					Equipement = (CEquipement)value;
					Site = null;
				}
				else if (value is CSite)
				{
					Site = (CSite)value;
					Equipement = null;
				}
				else
				{
					Site = null;
					Equipement = null;
				}
			}
		}


		//------------------------------------------------------------
		/// <summary>
		/// Donne ou définit l'équipement associé (s'il existe)
		/// </summary>
		[Relation(
			CEquipement.c_nomTable,
			CEquipement.c_champId,
			CEquipement.c_champId,
			false,
			true,
			true)]
		[DynamicField("Equipment")]
		public CEquipement Equipement
		{
			get
			{
				return (CEquipement)GetParent(CEquipement.c_champId, typeof(CEquipement));
			}
			set
			{
				SetParent(CEquipement.c_champId, value);
			}
		}

		//------------------------------------------------------------
		/// <summary>
        /// Donne ou définit le site associé (s'il existe)
		/// </summary>
		[Relation(
			CSite.c_nomTable,
			CSite.c_champId,
			CSite.c_champId,
			false,
			true,
			true)]
		[DynamicField("Site")]
		public CSite Site
		{
			get
			{
				return (CSite)GetParent(CSite.c_champId, typeof(CSite));
			}
			set
			{
				SetParent(CSite.c_champId, value);
			}
		}

		/// /////////////////////////////////////////////
		private void RAZDataTable()
		{
			if (TypeTable != null)
			{
				DataTableObject = TypeTable.GetNewDataTable(Libelle);
				return;
			}
			DataTableObject = new DataTable(Libelle) ;
		}

		/// /////////////////////////////////////////////
		protected override void MyInitValeurDefaut()
		{
		}

		/// /////////////////////////////////////////////
		public override string[] GetChampsTriParDefaut()
		{
			return new string[] { c_champLibelle };
		}

		/// /////////////////////////////////////////////
		public override void AfterRead()
		{
            CContexteDonnee.ChangeRowSansDetectionModification(Row.Row, c_champTbl, DBNull.Value);
		}


		#region IMPORTATION PAR FICHIER
		/// /////////////////////////////////////////////
		public CResultAErreur ImportTable(
			DataTable tableSource, 
			Dictionary<DataColumn, CColonneTableParametrable> mapColonnes,
			CImportTableParametrableMode mode)
		{
			CResultAErreur result = CResultAErreur.True;
			if (mode == null)
			{
				result.EmpileErreur(I.T("A mapping mode is mandatory|518"));
				return result;
			}
			DataTable tableDest = null;
			if (mode.Code == EImportTableParametrableMode.RAZ_Puis_Import)
				tableDest = TypeTable.GetNewDataTable(Libelle);
			else
				tableDest = DataTableObject;
			
			//Map de colonne source sur colonne dest
			Hashtable tableColSourceToColDest = new Hashtable();
			foreach ( KeyValuePair<DataColumn, CColonneTableParametrable> map in mapColonnes )
				if (tableDest.Columns.Contains(map.Value.Libelle))
					tableColSourceToColDest[map.Key] = tableDest.Columns[map.Value.Libelle];

			//Vérification de la compatibilité des types de données source et destination
			foreach ( DataColumn colTable in tableSource.Columns )
			{
				DataColumn colDest = (DataColumn)tableColSourceToColDest[colTable];
				if (colDest != null && !colDest.DataType.IsAssignableFrom(colTable.DataType))
				{
					result.EmpileErreur(I.T("The source column @1 is not compatible with the destination column @2|513",
						colTable.ColumnName,
						colDest.ColumnName));
					return result;
				}
			}

			result = VerifMappingPk(mode, mapColonnes);
			if (!result)
				return result;

			//Import des données
			foreach ( DataRow row in tableSource.Rows )
			{
				if (mode == EImportTableParametrableMode.Delete)
					result = DeleteRows(row, tableDest, tableColSourceToColDest);
				else
					result = UpdateOrCreateRow(row, tableDest, tableColSourceToColDest);

				if (!result)
					return result;
			}
			DataTableObject = tableDest;
			return result;
		}

		private CResultAErreur VerifMappingPk(CImportTableParametrableMode mode, Dictionary<DataColumn, CColonneTableParametrable> mapColonnes)
		{
			CResultAErreur result = CResultAErreur.True;
			CListeObjetsDonnees lstCPks = TypeTable.ColonnesClePrimaires;
			bool bFind = false;
			foreach(CColonneTableParametrable cpk in lstCPks)
			{
				bFind = false;
				foreach (KeyValuePair<DataColumn, CColonneTableParametrable> map in mapColonnes)
					if (cpk.Libelle == map.Value.Libelle)
					{
						bFind = true;
						break;
					}

				if (!bFind)
					break;
			}

			if (!bFind)
				result.EmpileErreur(I.T("The primary key must be mapped|517"));

			return result;
		}
		#endregion

		private CResultAErreur DeleteRows(DataRow drToDelete, DataTable dt, Hashtable mapColSourceToColDest)
		{
			CResultAErreur result = CResultAErreur.True;
			DataRow dr = dt.Rows.Find(GetPk(drToDelete, dt, mapColSourceToColDest));
			if (dr == null)
				return result;
			dr.Delete();
			return result;
		}

		private object[] GetPk(DataRow r, DataTable dt, Hashtable mapColSourceToColDest)
		{
			List<object> valsPk = new List<object>();
			foreach (DataColumn cPk in dt.PrimaryKey)
			{
				DataColumn col = null;
				foreach (DictionaryEntry dico in mapColSourceToColDest)
					if (dico.Value == cPk)
					{
						col = (DataColumn)dico.Key;
						break;
					}
				if (col == null)
					break;
				valsPk.Add(r[col.ColumnName]);
			}

			return valsPk.ToArray();
		}
		private CResultAErreur UpdateOrCreateRow(DataRow drToAdd, DataTable dt, Hashtable mapColSourceToColDest)
		{
			CResultAErreur result = CResultAErreur.True;
			DataRow dr = dt.Rows.Find(GetPk(drToAdd, dt, mapColSourceToColDest));

			//Creation
			if (dr == null)
			{
				DataRow newRow = dt.NewRow();
				result = CopyRow(drToAdd, newRow, mapColSourceToColDest);
				if (!result)
					return result;
				try
				{
					dt.Rows.Add(newRow);
				}
				catch (Exception e)
				{
					result.EmpileErreur(new CErreurException(e));
				}
			}
			//Update
			else
			{
				result = CopyRow(drToAdd, dr, mapColSourceToColDest);
			}

			return result;
		}

		private CResultAErreur CopyRow(DataRow source, DataRow destination, Hashtable mapColSourceToColDest)
		{
			CResultAErreur result = CResultAErreur.True;
			foreach (DataColumn colSource in source.Table.Columns)
			{
				DataColumn colDest = (DataColumn)mapColSourceToColDest[colSource];
				if (colDest != null)
				{
					try
					{
						destination[colDest] = source[colSource];
					}
					catch (Exception e)
					{
						if (e is NoNullAllowedException)
						{
							string strErr = "";
							foreach (DataColumn dt in destination.Table.Columns)
								if (!dt.AllowDBNull)
									strErr += "'" + dt.ColumnName + "'";

							result.EmpileErreur(I.T("Column @1 doesn't accept null value|530", strErr));
						}
						else
						{
							result.EmpileErreur(new CErreurException(e));
							result.EmpileErreur(I.T("Error while setting field @1|514", colDest.ColumnName));
						}
						return result;
					}
				}
			}
			return result;
		}

		#region IObjetDonneeAChamps Membres

		public CRelationElementAChamp_ChampCustom GetNewRelationToChamp()
		{
			return new CRelationTableParametrable_ChampCustom(ContexteDonnee);
		}

		public string GetNomTableRelationToChamps()
		{
			return CRelationTableParametrable_ChampCustom.c_nomTable;
		}

		public CListeObjetsDonnees GetRelationsToChamps(int nIdChamp)
		{
			CListeObjetsDonnees liste = RelationsChampsCustom;
			liste.InterditLectureInDB = true;
			liste.Filtre = new CFiltreData(CChampCustom.c_champId + " = @1", nIdChamp);
			return liste;
		}

		#endregion

		#region IElementAChamps Membres

		public IDefinisseurChampCustom[] DefinisseursDeChamps
		{
			get
			{
				return new IDefinisseurChampCustom[] { TypeTable };
			}
		}

		public CChampCustom[] GetChampsHorsFormulaire()
		{
			if (TypeTable == null)
				return new CChampCustom[0];

			ArrayList lst = new ArrayList();
			foreach (CRelationTypeTableParametrable_ChampCustom rel in TypeTable.RelationsChampsCustomDefinis)
				lst.Add(rel.ChampCustom);

			foreach (CRelationTypeTableParametrable_Formulaire rel1 in TypeTable.RelationsFormulaires)
				foreach (CRelationFormulaireChampCustom rel2 in rel1.Formulaire.RelationsChamps)
					lst.Remove(rel2.Champ);

			return (CChampCustom[])lst.ToArray(typeof(CChampCustom));
		}

		public CFormulaire[] GetFormulaires()
		{
            return CUtilElementAChamps.GetFormulaires(this);
		}

		//----------------------------------------------------
        /// <summary>
        /// Retourne la liste des relations entre la table paramétrable et<br/>
        /// les champs personnalisés
        /// </summary>
		[RelationFille(typeof(CRelationTableParametrable_ChampCustom), "ElementAChamps")]
		[DynamicChilds("Custom fields relations", typeof(CRelationTableParametrable_ChampCustom))]
		public CListeObjetsDonnees RelationsChampsCustom
		{
			get
			{
				return GetDependancesListe(CRelationTableParametrable_ChampCustom.c_nomTable, c_champId);
			}
		}

		#endregion

		#region IElementAVariables Membres

        //----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(int nIdChamp, DataRowVersion version)
        {
            return CUtilElementAChamps.GetValeurChamp(this, nIdChamp, version);
        }

        public object GetValeurChamp(string strIdVariable)
        {
            return CUtilElementAChamps.GetValeurChamp(this, strIdVariable);
        }

        //-----------------------------------------------------------------------------
        public object GetValeurChamp(IVariableDynamique variable)
        {
            if (variable == null)
                return null;
            return GetValeurChamp(variable.IdVariable);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(string strIdVariable, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, strIdVariable, valeur);
        }

        //---------------------------------------------
        public CResultAErreur SetValeurChamp(IVariableDynamique variable, object valeur)
        {
            if (variable == null)
                return CResultAErreur.True;
            return SetValeurChamp(variable.IdVariable, valeur);
        }

        //-------------------------------------------------------------------
        public CResultAErreur SetValeurChamp(int nIdChamp, object valeur)
        {
            return CUtilElementAChamps.SetValeurChamp(this, nIdChamp, valeur);
        }

		#endregion

        /// <summary>
        /// Retourne le tableau des enregistrements contenus dans la table paramétrable
        /// </summary>
        /// <returns></returns>
		[DynamicMethod("Return table rows")]
		public CLigneTableParametrable[] GetRows()
		{
			List<CLigneTableParametrable> lst = new List<CLigneTableParametrable>();
			foreach (DataRow row in DataTableObject.Rows)
				lst.Add(row);
			return lst.ToArray();
		}

        /// <summary>
        /// Retourne l'enregistrement dans la table paramétrable qui correspond<br/>
        /// à la clé passée en paramètre.
        /// </summary>
        /// <param name="key">Tableau d'objets constituant la clé</param>
        /// <returns>L'enregistrement dans la table s'il existe, sinon nul</returns>
		[DynamicMethod("Return the Row with the key (if not exist return null)","Key of Row")]
		public CLigneTableParametrable FindRow(object[] key)
		{
			return DataTableObject.Rows.Find(key);
		}

        /// <summary>
        /// Retourne le tableau d'enregistrements correspondant à<br/>
        /// la requête passée en paramètre.<br/>
        /// Exemple de requête avec un entier :<br/>
        /// Compteur = 350 (où Compteur est le nom d'une colonne de la table)<br/>
        /// Exemple de requête avec un décimal :<br/>
        /// Compteur >= 3457.3 (où Compteur est le nom d'une colonne de la table)<br/>
        /// Exemple de requête avec chaîne de caractère :<br/>
        /// Resultat = OK (où Resultat est le nom d'une colonne de la table)
        /// </summary>
        /// <param name="strRequete">Requête permettant de filtrer les éléments de la table</param>
        /// <returns>Tableau des enregistrements correspondant au filtre</returns>
		[DynamicMethod("Return Rows matching request", "SQL Request")]
		public CLigneTableParametrable[] SelectRows(string strRequete)
		{
			DataRow[] rows = DataTableObject.Select(strRequete);
			List<CLigneTableParametrable> result = new List<CLigneTableParametrable>();
			foreach (DataRow r in rows)
				result.Add(r);
			return result.ToArray();
			//return null;
		}

        /// <summary>
        /// Efface l'enregistrement de la table, passé en paramètre
        /// </summary>
        /// <param name="row">L'enregistrement à effacer</param>
        /// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod("Delete the rows", "row")]
		public bool DeleteRow(CLigneTableParametrable row)
		{
			if (DataTableObject.Rows.Find(row.GetKey()) == null)
				return false;
			else
				DataTableObject.Rows.Remove(row);
			return true;
		}


        /// <summary>
        /// Vide la table
        /// </summary>
        /// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod("Delete all the rows in table")]
		public bool ClearRows()
		{
			DataTableObject.Rows.Clear();
			return true;
		}

        /// <summary>
        /// Crée un nouvel enregistrement dans la table,<br/>
        /// cet enregistrement est sans donnée.
        /// </summary>
        /// <returns></returns>
		[DynamicMethod("Create a new row (without add in table)")]
		public CLigneTableParametrable CreateRow()
		{
			return DataTableObject.NewRow();
		}

        /// <summary>
        /// Ajoute à la table, l'enregistrement passé en paramètre
        /// </summary>
        /// <param name="row">Enregistrement à ajouter</param>
        /// <returns>TRUE si succès, FALSE si échec</returns>
		[DynamicMethod("Add the row in the table", "row to add")]
		public bool AddRow(CLigneTableParametrable row)
		{
			try
			{
				DataTableObject.Rows.Add(row);
#if DEBUG
				StringBuilder bl = new StringBuilder();
				foreach ( DataColumn col in ((DataRow)row).Table.Columns )
				{
					bl.Append(((DataRow)row)[col].ToString());
					bl.Append("|");
				}
#endif 
				return true;
			}
			catch
			{
				return false;
			}
		}

        /// <summary>
        /// Applique les modifications de données à la table (commit),<br/>
        /// ceci les rend définitives.
        /// </summary>
		[DynamicMethod("Apply modification to the table")]
		public void CommitTable()
		{
			DataTableObject = DataTableObject;
		}

        /// <summary>
        /// Annule les modifications de données à la table (rollback)
        /// </summary>
		[DynamicMethod("RollBack modification in the table")]
		public void RollBackTable()
		{
			DataTableObject = (DataTable)Row[c_champTbl];
		}


        /// <summary>
        /// Retourne, pour une colonne donnée, le premier entier non utilisé,<br/>
        /// entre deux valeurs passées en paramètres
        /// </summary>
        /// <param name="strColumnName">Nom de la colonne</param>
        /// <param name="nValMin">Valeur min.</param>
        /// <param name="nValMax">Valeur max.</param>
        /// <returns>La première valeur non trouvée</returns>
		[DynamicMethod("Return the first value not used between nValMin and nValMax included", 
            "The column name to search in",
            "Minimum value",
            "Maximum value")]
		public int GetFirstNotUsedValue(string strColumnName, int nValMin, int nValMax)
		{
			if (!DataTableObject.Columns.Contains(strColumnName))
				return nValMin - 2;

			for(int n = nValMin; n <= nValMax;n++)
			{
				DataRow[] rows = DataTableObject.Select(strColumnName + "=" + n.ToString());
				if (rows.Length == 0)
					return n;
			}
			return (nValMin - 1);
		}


        //-----------------------------------------------------------------------------------
        /// <summary>
        /// Retourne le tableau d'index des enregistrements qui contiennent,<br/>
        /// dans la colonne précisée, la chaîne de caractères passée en paramètre.
        /// </summary>
        /// <param name="strColumnName">Le nom de la colonne</param>
        /// <param name="strRecherche">La chaîne de caractères recherchée</param>
        /// <returns>Le tableau d'index</returns>
        [DynamicMethod("Return an array of indexes of rows that contains a string",
           "The column name to search in",
            "String to search")]
        public int[] GetIndexOfRowsContains(string strColumnName, string strRecherche)
        {
            if (!DataTableObject.Columns.Contains(strColumnName))
                return new int[0];

            List<int> listeIndexes = new List<int>();

            DataRow[] resultRows = DataTableObject.Select(strColumnName + "= '" + strRecherche +"'");
            foreach (DataRow row in resultRows)
            {
                listeIndexes.Add(DataTableObject.Rows.IndexOf(row));
            }
            return listeIndexes.ToArray();
        }
        

		#region IElementATypeStructurant<CTypeTableParametrable> Membres

		public CTypeTableParametrable ElementStructurant
		{
			get 
			{
				return TypeTable;
			}
		}

		public int IdTypeStructurant 
		{
			get
			{
				return (int)Row[CTypeTableParametrable.c_champId];
			}
		}

		#endregion


		//--------------------------------------------------------------------------------
		public bool IsBlobParDifference(string strChamp)
		{
			return strChamp == c_champTblBlob;
		}
				
		//--------------------------------------------------------------------------------
		public IDifferencesBlob GetDifferencesBlob(string strChamp, byte[] data, byte[] dataOriginal)
		{
			if (strChamp == c_champTblBlob)
			{
				DataTable tableFinale = null;
				DataTable tableOriginale = null;
				if (data != null)
					tableFinale = ReadTable(data);
				if (dataOriginal != null)
					tableOriginale = ReadTable(dataOriginal);
				return CDifferencesTables.GetDifferences(tableFinale, tableOriginale);
			}
			return null;

		}

		//--------------------------------------------------------------------------------
		public byte[] RedoModifs(IDifferencesBlob differences, byte[] data)
		{
			if (differences is CDifferencesTables)
			{
				DataTable table = null;
				if (data != null)
					table = ReadTable(data);
				((CDifferencesTables)differences).RedoModifs(ref table);
				return SaveTable(table);
			}
			return data;
		}


        //--------------------------------------------------------------------------------
		public static CTableParametrable GetTableParametrableForTable ( DataTable table )
        {
            if ( table == null )
                return null;
            return table.ExtendedProperties[c_extPropTableParametrable] as CTableParametrable;
        }
            
		
	}
}
