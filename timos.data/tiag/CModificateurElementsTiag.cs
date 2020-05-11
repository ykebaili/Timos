using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.multitiers.client;

using tiag.client;

using timos.client;
using timos.securite;
using System.Reflection;

namespace timos.data.tiag
{
	/// <summary>
	/// Permet d'indiquer un filtre de recherche pour
	/// un objet exporté dans tiag, qui identifie les éléments
	/// de manière unique
	/// </summary>
	internal class TiagUniqueAttribute : Attribute
	{
		public readonly string Filtre;
		public string[] ChampsParametres;

		public TiagUniqueAttribute(string strFiltre, params string[] champsParametres)
		{
			Filtre = strFiltre;
			ChampsParametres = champsParametres;
		}

	}

	[AutoExec("RegisterCompleteInit")]
	public class CModificateurElementsTiag : IModificateurElementsTiag, 
		IDisposable
	{
		private CContexteDonnee m_contexteDonnee = null;
		private int m_nIdSession = -1;
		private CMapTiag m_mappeur = new CMapTiag();

		public const string c_strServerKey = "TIMOS_SMT";
		public static string c_strParametreVersionTravail = "TIMOS_WORKVERSION";
		public static string c_strParametreUserId = "TIMOS_USERID";
        public static string c_strContexteModification = "TIMOS_MODIFICATION_CONTEXT";
		
		public static string[][] c_paramDesc = new string[][]
		{
		new string[]{c_strParametreVersionTravail,"Indicates the Id or the name of the version where the data will be imported"},
		new string[]{c_strParametreUserId,"Indicates the Id of the user performing the import"},
        new string[]{c_strContexteModification, "Indicates modification context for imported data"}
		};
	

		private class CMapEntitesDeTable
		{
			private Hashtable m_tableRowTiagToRow = new Hashtable();
			public CMapEntitesDeTable()
			{
			}

			public void Map(DataRow rowTiag, DataRow row)
			{
				m_tableRowTiagToRow[rowTiag] = row;
			}

			public DataRow GetRow(DataRow rowTiag)
			{
				return (DataRow)m_tableRowTiagToRow[rowTiag];
			}

			public Hashtable GetMaps()
			{
				return m_tableRowTiagToRow;
			}

		}

		//Map tiag to row élément timos
		public class CMapTiag
		{
			private Hashtable m_tableMapParTable = new Hashtable();
			public CMapTiag()
			{
			}

			public void Map(Type tp, DataRow rowTiag, DataRow row)
			{
				CMapEntitesDeTable map = (CMapEntitesDeTable)m_tableMapParTable[tp];
				if (map == null)
				{
					map = new CMapEntitesDeTable();
					m_tableMapParTable[tp] = map;
				}
				map.Map(rowTiag, row);
			}

			public DataRow GetRow(Type tp, DataRow rowTiag)
			{
				CMapEntitesDeTable map = (CMapEntitesDeTable)m_tableMapParTable[tp];
				if (map != null)
					return map.GetRow(rowTiag);
				return null;
			}

			//Return un hashtable rowTiag->rowTimos
			public Hashtable GetMaps()
			{
				Hashtable tbl = new Hashtable();
				foreach (CMapEntitesDeTable map in m_tableMapParTable.Values)
					foreach (DictionaryEntry entry in map.GetMaps())
						tbl.Add(entry.Key, entry.Value);
				return tbl;
			}
		}


		//-------------------------------------------
		public CModificateurElementsTiag(int nIdSession)
		{
			m_nIdSession = nIdSession;
			m_contexteDonnee = new CContexteDonnee(nIdSession, true, true);
			m_contexteDonnee.GestionParTablesCompletes = true;
			m_contexteDonnee.IgnoreAvertissementsALaSauvegarde = true;
		}

		//-------------------------------------------
		public CContexteDonnee ContexteDonnee
		{
			get
			{
				return m_contexteDonnee;
			}
		}

		//-------------------------------------------
		public void Dispose()
		{
			if (m_contexteDonnee != null)
				m_contexteDonnee.Dispose();
			m_contexteDonnee = null;
		}

		//-------------------------------------------
		public List<IElementAInterfaceTiag> GetElements(Type type, object[] keys)
		{
			List<IElementAInterfaceTiag> lst = new List<IElementAInterfaceTiag>();
			CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)Activator.CreateInstance(type, new object[] { m_contexteDonnee });
			if (objet.ReadIfExists(keys))
				lst.Add((IElementAInterfaceTiag)objet);
			return lst;
		}

		//-------------------------------------------
		public bool ExistElement(Type tp, object[] keys)
		{
			CListeObjetsDonnees liste = new CListeObjetsDonnees(ContexteDonnee, tp, false);
			DataTable table = ContexteDonnee.GetTableSafe(CContexteDonnee.GetNomTableForType(tp));
			List<String> cols = new List<String>();
			foreach (DataColumn col in table.PrimaryKey)
				cols.Add(col.ColumnName);
			CFiltreData filtre = CFiltreData.CreateFiltreAndSurValeurs(cols.ToArray(), keys);
			liste.Filtre = filtre;
			return liste.CountNoLoad > 0;
		}

		//-------------------------------------------
		/// <summary>
		/// Le data du result contient un CFiltredata
		/// </summary>
		/// <param name="structTiag"></param>
		/// <param name="strChamps"></param>
		/// <param name="valeurs"></param>
		/// <returns></returns>
		private CResultAErreur GetFiltre(CStructureTiag structTiag, string[] strChamps, object[] valeurs)
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				Type tp = structTiag.Type;
				Type tpForContexteDonnee = tp;
				object[] attribs = null;
				do
				{
					attribs = tpForContexteDonnee.GetCustomAttributes(typeof(TableAttribute), false);
					if (attribs.Length == 0 && tpForContexteDonnee.BaseType != null)
						tpForContexteDonnee = tpForContexteDonnee.BaseType;
				}
				while (attribs == null && tpForContexteDonnee.BaseType != null);

                bool bChampOk = false;

				CStructureTable structure = CStructureTable.GetStructure(tpForContexteDonnee);
				CFiltreDataAvance filtre = new CFiltreDataAvance(structure.NomTable,"");
				for (int nChampDeFiltre = 0; nChampDeFiltre < strChamps.Length; nChampDeFiltre++)
				{
					string strChamp = strChamps[nChampDeFiltre];
					IChampTiag champTiag = structTiag.GetChamp(strChamp);
					if (champTiag is CChampTiag)
					{
						string strNomchamp = "";
						CInfoChampTable info = structure.GetChampFromPropriete(((CChampTiag)champTiag).NomPropriete);
						if (info == null)
						{
							PropertyInfo propInfo = tp.GetProperty ( ((CChampTiag)champTiag).NomPropriete);
							if ( propInfo != null )
							{
								attribs = propInfo.GetCustomAttributes ( typeof(TiagFakeFieldAttribute), true);
								if ( attribs.Length != 0 )
									strNomchamp = ((TiagFakeFieldAttribute)attribs[0]).Field;
							}
							if ( strNomchamp == "" )
							{
								result.EmpileErreur ( I.T("Timos cannot find an element on the field @1|30053",champTiag.NomTiag) );
								return result;
							}
						}
						else
							strNomchamp = info.NomChamp;
						if (valeurs[nChampDeFiltre] == null || valeurs[nChampDeFiltre] == DBNull.Value)
							filtre.Filtre += "HasNo(" + strNomchamp+ ") and ";
						else
						{
							filtre.Filtre += strNomchamp + "=@" + (filtre.Parametres.Count + 1) + " and ";
							filtre.Parametres.Add(valeurs[nChampDeFiltre]);
						}
                        bChampOk = true;
					}
					else if (champTiag is CChampTiagForCustom)
					{
						CChampCustom champ = new CChampCustom(ContexteDonnee);
						if (!champ.ReadIfExists(((CChampTiagForCustom)champTiag).IdChampCustom))
						{
							result.EmpileErreur(I.T("Cannot find the custom field @1|30054", strChamp));
							return result;
						}
						IObjetDonneeAChamps objet = (IObjetDonneeAChamps)Activator.CreateInstance(tpForContexteDonnee, new object[] { ContexteDonnee });
						filtre.Filtre += objet.GetNomTableRelationToChamps() + "." +
							CChampCustom.c_champId + "=@" + (filtre.Parametres.Count + 1) + " and ";
						if (valeurs[nChampDeFiltre] == null || valeurs[nChampDeFiltre] == DBNull.Value)
						{
							filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurNull + "=@" + (filtre.Parametres.Count + 2) + " and ";
						}
						else
						{
							filtre.Filtre += objet.GetNomTableRelationToChamps() + ".";
							switch (champ.TypeDonneeChamp.TypeDonnee)
							{
								case TypeDonnee.tBool:
									filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurBool;
									break;
								case TypeDonnee.tEntier:
									filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurInt;
									break;
								case TypeDonnee.tDate:
									filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurDate;
									break;
								case TypeDonnee.tDouble:
									filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurDouble;
									break;
								case TypeDonnee.tString:
									filtre.Filtre += CRelationElementAChamp_ChampCustom.c_champValeurString;
									break;
								default:
									result.EmpileErreur(I.T("Timos cannot filter the custom field  @1|30055", strChamp));
									return result;
							}
							filtre.Filtre += "=@" + (filtre.Parametres.Count + 2) + " and ";
						}
						filtre.Parametres.Add(champ.Id);
						if (valeurs[nChampDeFiltre] == null || valeurs[nChampDeFiltre] == DBNull.Value)
							filtre.Parametres.Add(true);
						else
							filtre.Parametres.Add(valeurs[nChampDeFiltre]);
                        bChampOk = true;
					}
                    else if (champTiag is CChampTiagLienToParent)
                    {
                        CChampTiagLienToParent champLien = champTiag as CChampTiagLienToParent;
                        foreach (CAssociationTiag assoc in structTiag.Associations)
                        {
                            //Il faut trouver le champ correspondant
                            foreach ( IChampTiag champ in assoc.Champs )
                                if (champ.Equals(champTiag))
                                {
                                    PropertyInfo info = tp.GetProperty ( assoc.Propriete );
                                    if (info != null)
                                    {
                                        attribs = info.GetCustomAttributes(typeof(RelationAttribute), true);
                                        if (attribs.Length > 0)
                                        {
                                            RelationAttribute attrRel = attribs[0] as RelationAttribute;
                                            if (attrRel.ChampsFils.Length == 1)//Seul cas geré pour le moment, reste plusieurs clés à faire
                                            {
                                                string strNomChamp = attrRel.ChampsFils[0];
                                                if (valeurs[nChampDeFiltre] == null || valeurs[nChampDeFiltre] == DBNull.Value)
                                                    filtre.Filtre += "HasNo(" + strNomChamp + ") and ";
                                                else
                                                {
                                                    filtre.Filtre += strNomChamp + "=@" + (filtre.Parametres.Count + 1) + " and ";
                                                    filtre.Parametres.Add(valeurs[nChampDeFiltre]);
                                                }
                                                bChampOk = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                            if (bChampOk)
                                break;
                        }
                    }
                    if ( !bChampOk )
                    {
                        result.EmpileErreur(I.T("Can not filter on @1|30056", strChamp));
                        return result;
                    }
				}
				if (filtre.Filtre.Length > 0)
					filtre.Filtre = filtre.Filtre.Substring(0, filtre.Filtre.Length - 5);
				result.Data = filtre;
				return result;
			}
			catch (Exception e)
			{
				result.EmpileErreur(e.ToString());
			}
			return result;
		}

		/// <summary>
		/// Retourne une liste de liste de clés pour les élements correspondants à la recherche
		/// </summary>
		/// <param name="strType"></param>
		/// <param name="strChamps"></param>
		/// <param name="valeurs"></param>
		/// <returns></returns>
		public CResultDataSet GetKeysEntityFromSearch ( string strType, string[] strChamps, object[] valeurs )
		{
			CResultDataSet result = new CResultDataSet();
			CResultAErreur resErreur = CResultAErreur.True;
			CStructureTiag structTiag = CUtilClientTiag.GetStructure ( strType );
			if ( structTiag == null )
			{
				result.EmpileErreur(CodeErreur.AppliErreur,
						c_strServerKey,
						I.T("@1 doesn't exist|30057", strType),
						null,
						null,
						(int)Gravite.Majeure);
				return result;
			}
			resErreur = GetFiltre ( structTiag, strChamps, valeurs );
			if (resErreur)
			{
				Type tpForContexteDonnee = structTiag.Type;
				object[] attribs;
				do
				{
					attribs = tpForContexteDonnee.GetCustomAttributes(typeof(TableAttribute), false);
					if ( attribs.Length ==0 && tpForContexteDonnee.BaseType != null )
						tpForContexteDonnee = tpForContexteDonnee.BaseType;
				}
				while ( attribs.Length ==0 && tpForContexteDonnee.BaseType != null);


				CStructureTable structure = CStructureTable.GetStructure(tpForContexteDonnee);
				if (structTiag == null)
				{
					resErreur.EmpileErreur(I.T("Can not fill structure for type @1|30058", structTiag.Type.ToString()));
					result.EmpileErreur(CodeErreur.AppliErreur,
						c_strServerKey,
						resErreur.Erreur.ToString(),
						null,
						null,
						(int)Gravite.Majeure);
					return result;
				}
				C2iRequeteAvancee req = new C2iRequeteAvancee(ContexteDonnee.IdVersionDeTravail);
				req.TableInterrogee = structure.NomTable;
				req.FiltreAAppliquer = (CFiltreData)resErreur.Data;
				foreach (CInfoChampTable champ in structure.ChampsId)
				{
					req.ListeChamps.Add(new C2iChampDeRequete(champ.NomChamp,
						new CSourceDeChampDeRequete(champ.NomChamp),
						champ.TypeDonnee,
						OperationsAgregation.None, false));
				}
				CFiltreDataAvance filtre = (CFiltreDataAvance)req.FiltreAAppliquer;
				if (ContexteDonnee.IdVersionDeTravail == null)
				{
					
					//IL faut que la version soit nulle
					req.FiltreAAppliquer = CFiltreData.GetAndFiltre ( req.FiltreAAppliquer,
						new CFiltreDataAvance ( filtre.TablePrincipale, "HasNo("+CSc2iDataConst.c_champIdVersion+")" ));
				}
				else
				{
					//Ajoute le champ IdOriginal
					req.ListeChamps.Add ( new C2iChampDeRequete(CSc2iDataConst.c_champOriginalId,
						new CSourceDeChampDeRequete ( CSc2iDataConst.c_champOriginalId ),
						typeof(int),
						OperationsAgregation.None,
						false ));
					CVersionDonnees version = new CVersionDonnees (ContexteDonnee);
					version.ReadIfExists ( (int)ContexteDonnee.IdVersionDeTravail );
					int[] idsVersion = CVersionDonnees.GetVersionsToRead ( ContexteDonnee.IdSession, (int)ContexteDonnee.IdVersionDeTravail);
					StringBuilder blIds = new StringBuilder();
					foreach ( int nId in idsVersion )
					{
						blIds.Append ( nId );
						blIds.Append(";");
					}
					CFiltreData filtreVersion = new CFiltreDataAvance ( filtre.TablePrincipale,"" );
					filtreVersion.Filtre = "HasNo("+CSc2iDataConst.c_champIdVersion+")";
					if ( blIds.Length > 0 )
					{
						blIds.Remove ( blIds.Length-1, 1 );
						filtreVersion.Filtre += " or "+CSc2iDataConst.c_champIdVersion+" in ("+
							blIds.ToString()+")";
					}
					req.FiltreAAppliquer = CFiltreData.GetAndFiltre ( filtre, filtreVersion );
				}

				resErreur = req.ExecuteRequete(ContexteDonnee.IdSession);
				if (resErreur)
				{
					DataTable table = (DataTable)resErreur.Data;
					int nNbIds = structure.ChampsId.Length;
					ArrayList lstResult = new ArrayList();

					foreach (DataRow row in table.Rows)
					{
						bool bConserver = true;
						if ( ContexteDonnee.IdVersionDeTravail != null )
						{
							//si on travaille dans une version, on ne conserve que les ids
							//originaux
							if ( row[CSc2iDataConst.c_champOriginalId] != DBNull.Value )
								bConserver = false;
						}
						if ( bConserver )
						{
							object[] vals = new object[nNbIds];
							for (int nCol = 0; nCol < nNbIds; nCol++)
								vals[nCol] = row[nCol];
							lstResult.Add(vals);
						}
					}
					result.Data = lstResult.ToArray();
				}
			}
			if (!resErreur)
			{
				result.EmpileErreur(CodeErreur.AppliErreur,
						c_strServerKey,
						resErreur.Erreur.ToString(),
						null,
						null,
						(int)Gravite.Majeure);
			}

			return result;
		}
			

		//-------------------------------------------
		public CResultDataSet GetElements(CStructureTiag structTiag, string[] strChamps, object[] valeurs)
		{
			CResultDataSet  result = new CResultDataSet();
			try
			{
				CResultAErreur  resErreur = GetFiltre ( structTiag, strChamps, valeurs );
				if ( !resErreur )
				{
					result.EmpileErreur ( CodeErreur.AppliErreur,
						c_strServerKey,
						resErreur.Erreur.ToString(),
						null,
						null,
						(int)Gravite.Majeure );
					return result;
				}
				CFiltreData filtre = (CFiltreData)resErreur.Data;
				CListeObjetsDonnees  liste = new CListeObjetsDonnees ( ContexteDonnee, structTiag.Type, false );
				liste.Filtre = filtre;
				result = CUtilClientTiag.GetDataSetStructure();
				foreach ( IElementAInterfaceTiag elt in liste )
					CUtilClientTiag.FillDataSet ( elt, result );
				return result;
			}
			catch (Exception e)
			{
				result.EmpileErreur(CodeErreur.AppliErreur, c_strServerKey,
					e.ToString(),
					"",
					null,
					(int)Gravite.Majeure);
			}
			return result;
		}

		//-------------------------------------------
		//Crée le map du data row sur une row de la base dest
		//il faut mapper les row avant de les mettre à jour
		//a cause de tables autoreferencees
		public CResultDataSet MappeRow(DataRow row)
		{
			CResultDataSet result = new CResultDataSet();
			CStructureTiag structure = CUtilClientTiag.GetStructure(row.Table.TableName);
			Type typeElements = structure.Type;

			//Cherche la ligne
            CObjetDonneeAIdNumeriqueAuto objet = (CObjetDonneeAIdNumeriqueAuto)Activator.CreateInstance(typeElements, new object[] { m_contexteDonnee });
            int nIdObjet = -1;
            try
            {
                nIdObjet = Convert.ToInt32(row[structure.Cles[0].NomTiag]);
            }
            catch (Exception e)
            {
                result.EmpileErreur(
                    CodeErreur.Indeterminee,
                    this.GetType().ToString(),
                    e.Message,
                    structure.Cles[0].NomTiag,
                    row,
                    (int)Gravite.Indeterminee);
                return result;
            }
            if (nIdObjet < 0 || !objet.ReadIfExists(nIdObjet))
			{
				bool bObjetValide = false;
				//N'arrive pas à lire l'objet, regarde s'il y a un filtre d'unicité sur cet objet
				object[] attribs = structure.Type.GetCustomAttributes(typeof(TiagUniqueAttribute), true);
				if (attribs.Length > 0)
				{
					foreach (TiagUniqueAttribute unique in attribs)
					{
						bool bFiltreApplicable = true;
						foreach (string strParam in unique.ChampsParametres)
						{
							if (row.Table.Columns[strParam] == null)
							{
								bFiltreApplicable = false;
								break;
							}
						}
						if (bFiltreApplicable)
						{
							CFiltreData filtre = new CFiltreData(unique.Filtre);
							foreach (string strChamp in unique.ChampsParametres)
								filtre.Parametres.Add(row[strChamp]);
							if (objet.ReadIfExists(filtre))
							{
								bObjetValide = true;
								break;
							}
						}
					}
				}
				if (!bObjetValide)
				{
					objet.CreateNewInCurrentContexte();
				}
			}

			m_mappeur.Map(objet.GetType(), row, objet.Row);
			return result;
		}

		public CResultDataSet ModifieRow ( DataRow row )
		{
			CResultDataSet result = new CResultDataSet();
			CStructureTiag structure = CUtilClientTiag.GetStructure(row.Table.TableName);
			Type typeElements = structure.Type;
			DataRow rowMappee = m_mappeur.GetRow(typeElements, row);
			CObjetDonneeAIdNumerique objet = (CObjetDonneeAIdNumerique)Activator.CreateInstance(typeElements, rowMappee);
			string strChampsModifies = null;
			if (row.Table.Columns.Contains(CUtilClientTiag.c_strNomColonneValeursDefinies))
				strChampsModifies = (string)row[CUtilClientTiag.c_strNomColonneValeursDefinies];


			//Met à jour l'objet avec le datarow
			foreach (IChampTiag champ in structure.Champs)
			{
				if (champ is CChampTiag || champ is CChampTiagForCustom)
				{
					DataColumn col = row.Table.Columns[champ.NomTiag];
					if (col != null && !col.AutoIncrement)
					{
						if ( strChampsModifies == null || strChampsModifies.Contains("~"+col.ColumnName+"~") )
							champ.SetValeur(objet, row[col]);
					}
				}
			}
			foreach (IAssociationTiag association in structure.Associations)
			{
				bool bSetParRelation = false;
				bool bIsNull = false;
				bool bIsToSet = true;
				foreach (IChampTiag champ in association.Champs)
					if (row.Table.Columns.Contains(champ.NomTiag))
					{
						if (row[champ.NomTiag] == DBNull.Value)
						{
							bIsNull = true;
							break;
						}
						if ( strChampsModifies != null && !strChampsModifies.Contains("~"+champ.NomTiag+"~" ))
							bIsToSet = false;
					}
					else
					{
						bIsToSet = false;
						break;
					}
				if (bIsToSet)
				{
					if (bIsNull)
						bIsNull = true;//bidouille pour pouvoir import SPV
					//association.SetValeur(objet, null);
					else
					{
						DataRelation rel = row.Table.DataSet.Relations[association.Nom];
						if (rel != null)
						{
							DataRow rowParente = row.GetParentRow(rel);
							if (rowParente != null)
							{
								//Récupère l'élément mappé
								DataRow rowParenteType = m_mappeur.GetRow(association.TypeParent, rowParente);
								if (rowParenteType != null)
								{
									CObjetDonnee parent = (CObjetDonnee)Activator.CreateInstance(association.TypeParent, new object[] { rowParenteType });
									association.SetValeur(objet, parent);
									bSetParRelation = true;
								}
							}
						}
						//On n'y arrive pas par la relation, 
						//Il se peut que l'élément parent n'ai pas été mis dans le dataset
						//donc, on tente par les clés. Ca ne marche pas, si l'élément est nouveau !
						if (!bSetParRelation)
						{
							ArrayList lstCles = new ArrayList();
							bool bSetAssoc = true;
							foreach (IChampTiag champ in association.Champs)
							{
								if (row.Table.Columns.Contains(champ.NomTiag))
									lstCles.Add(row[champ.NomTiag]);
								else
								{
									bSetAssoc = false;
									break;
								}
							}
							if (bSetAssoc)
								association.SetValeursCles(objet, lstCles.ToArray());
						}
					}
				}
				//La relation n'existe pas. Si les champs fils sont dans la base,
				//Affecte les valeurs de champs fils
			}

			//La vérification des données sera fait au moment de la sauvegarde
			//(en ignorant les avertissements car CContexteDonnee.IgnorerAvertissements)
			CResultAErreur resVerifie = CResultAErreur.True;
			if ( objet.Row.RowState == DataRowState.Added || 
				objet.Row.RowState == DataRowState.Modified )
				resVerifie = objet.VerifieDonnees(true);
			if (!resVerifie)
			{
				bool bGrave = false;
				foreach (IErreur erreur in resVerifie.Erreur)
				{
					if (!(erreur is CErreurValidation) || !((CErreurValidation)erreur).IsAvertissement)
					{
						bGrave = true;
						break;
					}
				}
				if (bGrave)
				{
					foreach (IErreur erreur in resVerifie.Erreur)
						result.EmpileErreur(CodeErreur.ChampInvalide, c_strServerKey,
							erreur.Message, null, null, (int)Gravite.Majeure);
				}
			}
			return result;
		}

		/*//-------------------------------------------
		public CResultDataSet OnModification(DataRow row)
		{
			CResultDataSet result = new CResultDataSet();
			CStructureTiag structure = CUtilClientTiag.GetStructure(row.Table.TableName);
			Type typeElements = structure.Type;

			//Cherche la ligne
			CObjetDonneeAIdNumeriqueAuto objet = (CObjetDonneeAIdNumeriqueAuto)Activator.CreateInstance(typeElements, new object[] { m_contexteDonnee });
			if (!objet.ReadIfExists((int)row[structure.Cles[0].NomTiag]))
			{
				bool bObjetValide = false;
				//N'arrive pas à lire l'objet, regarde s'il y a un filtre d'unicité sur cet objet
				object[] attribs = structure.Type.GetCustomAttributes(typeof(TiagUniqueAttribute), true);
				if (attribs.Length > 0)
				{
					foreach (TiagUniqueAttribute unique in attribs)
					{
						bool bFiltreApplicable = true;
						foreach (string strParam in unique.ChampsParametres)
						{
							if (row.Table.Columns[strParam] == null)
							{
								bFiltreApplicable = false;
								break;
							}
						}
						if (bFiltreApplicable)
						{
							CFiltreData filtre = new CFiltreData(unique.Filtre);
							foreach (string strChamp in unique.ChampsParametres)
								filtre.Parametres.Add(row[strChamp]);
							if (objet.ReadIfExists(filtre))
							{
								bObjetValide = true;
								break;
							}
						}
					}
				}
				if (!bObjetValide)
				{
					objet.CreateNewInCurrentContexte();
				}
			}

			m_mappeur.Map(objet.GetType(), row, objet.Row);

			//Met à jour l'objet avec le datarow
			foreach (IChampTiag champ in structure.Champs)
			{
				if ( champ is CChampTiag || champ is CChampTiagForCustom )
				{
					DataColumn col = row.Table.Columns[champ.NomTiag];
					if (col != null && !col.AutoIncrement)
					{
						champ.SetValeur(objet, row[col]);
					}
				}
			}
			foreach (CAssociationTiag association in structure.Associations)
			{
				bool bSetParRelation = false;
				bool bIsNull = false;
				bool bIsToSet = true;
				foreach (IChampTiag champ in association.Champs)
					if (row.Table.Columns.Contains(champ.NomTiag))
					{
						if (row[champ.NomTiag] == DBNull.Value)
						{
							bIsNull = true;
							break;
						}
					}
					else
					{
						bIsToSet = false;
						break;
					}
				if (bIsToSet)
				{
					if (bIsNull)
						association.SetValeur(objet, null);
					else
					{
						DataRelation rel = row.Table.DataSet.Relations[association.Nom];
						if (rel != null)
						{
							DataRow rowParente = row.GetParentRow(rel);
							if (rowParente != null)
							{
								//Récupère l'élément mappé
								DataRow rowParenteType = m_mappeur.GetRow(association.TypeParent, rowParente);
								CObjetDonnee parent = (CObjetDonnee)Activator.CreateInstance(association.TypeParent, new object[] { rowParenteType });
								association.SetValeur(objet, parent);
								bSetParRelation = true;
							}
						}
						//On n'y arrive pas par la relation, 
						//Il se peut que l'élément parent n'ai pas été mis dans le dataset
						//donc, on tente par les clés. Ca ne marche pas, si l'élément est nouveau !
						if (!bSetParRelation)
						{
							ArrayList lstCles = new ArrayList();
							bool bSetAssoc = true;
							foreach (IChampTiag champ in association.Champs)
							{
								if (row.Table.Columns.Contains(champ.NomTiag))
									lstCles.Add(row[champ.NomTiag]);
								else
								{
									bSetAssoc = false;
									break;
								}
							}
							if (bSetAssoc)
								association.SetValeursCles(objet, lstCles.ToArray());
						}
					}
				}
				//La relation n'existe pas. Si les champs fils sont dans la base,
				//Affecte les valeurs de champs fils
			}
			CResultAErreur resVerifie = objet.VerifieDonnees();
			if (!resVerifie)
			{
				bool bGrave = false;
				foreach ( IErreur erreur in resVerifie.Erreur )
				{
					if ( !(erreur is CErreurValidation) || !((CErreurValidation)erreur).IsAvertissement) 
					{
						bGrave = true;
						break;
					}
				}
				if ( bGrave )
				{
					foreach ( IErreur	erreur in resVerifie.Erreur )
						result.EmpileErreur ( CodeErreur.ChampInvalide, c_strServerKey,
							erreur.Message, null, null, (int)Gravite.Majeure );
				}
			}
			return result;
		}*/

		//-------------------------------------------
		public CResultDataSet SaveAll()
		{
			CResultDataSet result = new CResultDataSet();
			CResultAErreur resErreur = ContexteDonnee.SaveAll( true );
			if (!result)
				foreach (IErreur erreur in resErreur.Erreur)
					result.EmpileErreur(CodeErreur.AppliErreur,
						c_strServerKey,
						erreur.Message,
						null,
						null,
						(int)Gravite.Majeure);
			return result;
		}


		//------------------------------------------------------------
		public CResultAErreur DefinitNouvellesCles(DataSet donnees)
		{
			foreach ( DictionaryEntry entry in m_mappeur.GetMaps() )
			{
				DataRow rowTiag = (DataRow)entry.Key;
				DataRow rowTims = (DataRow)entry.Value;
				if ( rowTiag[rowTiag.Table.PrimaryKey[0]] != rowTims[rowTims.Table.PrimaryKey[0]] )
					CUtilClientTiag.SetCleAfterModifs(rowTiag, new object[] { rowTims[rowTims.Table.PrimaryKey[0]] });
			}
			return CResultAErreur.True;
		}

		//------------------------------------------------------------
		public static void RegisterCompleteInit()
		{
			CUtilClientTiag.CompleteInit += new CUtilClientTiag.CompleteInitDelegate(AddChampsCustomsToStructureTiag);
		}



		//------------------------------------------------------------
		public static void AddChampsCustomsToStructureTiag()
		{ 
			CResultAErreur result = CResultAErreur.True;
			using (CSessionClient session = CSessionClient.CreateInstance())
			{
				result = session.OpenSession(new CAuthentificationSessionServiceClient(), "TIAG_update_structure", ETypeApplicationCliente.Service);
				if (result)
				{
					using (CContexteDonnee contexte = new CContexteDonnee(session.IdSession, true, false))
					{
						List<Type> lstTypes = CUtilClientTiag.TypesTiag;
						foreach (Type tpBoucle in lstTypes)
						{
							Type tp = tpBoucle;
							CRoleChampCustom role = null;
							while (role == null && tp != null)
							{
								role = CRoleChampCustom.GetRoleForType(tp);
								if (role == null)
									tp = tp.BaseType;
							}
							if (role != null)
							{
                                CListeObjetsDonnees listeChamps = CChampCustom.GetListeChampsForRole(contexte, role.CodeRole);
								foreach (CChampCustom champCustom in listeChamps)
								{
									if (champCustom.TypeObjetDonnee == null && champCustom.TypeDonneeChamp.TypeDonnee != TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
									{
										CUtilClientTiag.AddChamp(tpBoucle, new CChampTiagForCustom(champCustom));
									}
									else
									{
										if (champCustom.TypeObjetDonnee != null)
										{
											Type tpObjet = champCustom.TypeObjetDonnee;
											object[] attribs = tpObjet.GetCustomAttributes(typeof(TiagClassAttribute), true);
											if (attribs.Length > 0)
											{
												CChampTiagForCustomEntite champ = new CChampTiagForCustomEntite(champCustom);
												CAssociationTiagForCustom assoc = new CAssociationTiagForCustom(
													tpObjet,
													new IChampTiag[]{champ},
													"Relation_" + champCustom.Nom,
													champCustom.Id);
												CUtilClientTiag.AddChamp(tpBoucle, champ);
												CUtilClientTiag.AddRelation(tpBoucle, assoc);
											}
										}
									}
								}
							}
						}
					}
				}
				session.CloseSession();
			}
		}

		//---------------------------------------------------------------------------------
		public DataSet SetParametre(string strNomParametre, string strValeurParametre)
		{
			CResultDataSet result = new CResultDataSet();

            if (strNomParametre.ToUpper() == CModificateurElementsTiag.c_strContexteModification)
            {
                ContexteDonnee.IdModificationContextuelle = strValeurParametre;
            }
			if (strNomParametre.ToUpper() == CModificateurElementsTiag.c_strParametreVersionTravail)
			{
				CVersionDonnees version = null;
				try
				{
					int nIdVersion = Int32.Parse(strValeurParametre);
					version = new CVersionDonnees(ContexteDonnee);
					if (!version.ReadIfExists(nIdVersion))
						version = null;
				}
				catch { }
				if (version == null)
				{
					version = new CVersionDonnees(ContexteDonnee);
					//On ne trouve pas par l'id, tente sur le libellé de la version
					if (!version.ReadIfExists(new CFiltreData(CVersionDonnees.c_champLibelle + "=@1",
						strValeurParametre)))
					{
						version = null;
						result.EmpileErreur(CodeErreur.AppliErreur, c_strServerKey, I.T("Data version @1 doesn't exist|30059"), strValeurParametre, "", null, (int)Gravite.Majeure);
						return result;
					}
				}
				if (version != null)
				{
					if (version.TypeVersion.Code != CTypeVersion.TypeVersion.Previsionnelle)
					{
						result.EmpileErreur(CodeErreur.AppliErreur,c_strServerKey,I.T("Data version @1 is not a future version|30060"), strValeurParametre, "", null, (int)Gravite.Majeure);
						return result;
					}
					CResultAErreur resErreur = ContexteDonnee.SetVersionDeTravail(version.Id, true);
					if (!resErreur)
					{
						result.EmpileErreur(CodeErreur.AppliErreur,
							c_strServerKey,
							resErreur.Erreur.ToString(),
							"",
							null,
							(int)Gravite.Majeure);
						return result;
					}

					if (!result)
						return result;
				}
			}
			if ( strNomParametre.ToUpper() == c_strParametreUserId.ToUpper() )
			{
                //TESTDBKEYOK
				int nIdUser = -1;
                CDbKey keyUser = null;
				try
				{
					nIdUser = Int32.Parse ( strValeurParametre );
				}
				catch
				{
					result.EmpileErreur(CodeErreur.AppliErreur,
						c_strServerKey,
						I.T("Incorrect parameter value for @1 (integer expected)|20013", strNomParametre),
						null, null, (int)Gravite.Mineure);
					return result;
				}
				CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( ContexteDonnee );
                if (!user.ReadIfExists(nIdUser))
                {
                    result.EmpileErreur(
                        CodeErreur.AppliErreur,
                        c_strServerKey,
                        I.T("User @1 doesn't exist|20014", nIdUser.ToString()),
                        null, null, (int)Gravite.Mineure);
                    return result;
                }
                else
                    keyUser = user.DbKey;
				CSessionClient session = CSessionClient.GetSessionForIdSession ( ContexteDonnee.IdSession );
				if ( session == null )
				{
					result.EmpileErreur(
						CodeErreur.AppliErreur,
						c_strServerKey,
						I.T("Cannot find client session @1|20015", ContexteDonnee.IdSession.ToString()),
						null, null, (int)Gravite.Mineure);
					return result;
				}
                if (keyUser != null )
				    session.ChangeUtilisateur ( keyUser );
			}			


			return result;
		}

	}
}
