using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using sc2i.common;
using sc2i.data;

namespace timos.data
{
	public class CMappeurTypeTableParametrableTypeTableParametrable
	{

		private CTypeTableParametrable m_tpTableSrc;
		public CTypeTableParametrable TypeTableSource
		{
			get
			{
				return m_tpTableSrc;
			}
		}

		private CTypeTableParametrable m_tpTableCible;
		public CTypeTableParametrable TypeTableCible
		{
			get
			{
				return m_tpTableCible;
			}
		}


		public CMappeurTypeTableParametrableTypeTableParametrable(CTypeTableParametrable tpSource, CTypeTableParametrable tpCible)
		{
			m_tpTableCible = tpCible;
			m_tpTableSrc = tpSource;
			m_mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
		}
		public CMappeurTypeTableParametrableTypeTableParametrable(CTypeTableParametrable tpSource, CTypeTableParametrable tpCible, bool bInitialiserMappage)
		{
			m_tpTableCible = tpCible;
			m_tpTableSrc = tpSource;
			m_mappages = new List<CMappageColonneTableParametrableColonneTableParametrable>();
			if (bInitialiserMappage)
			{
				List<CColonneTableParametrable> colsCible = tpCible.Colonnes.ToList<CColonneTableParametrable>();
				colsCible.Sort (new CColonneTableParametrable_ProrityComparer());
				List<CColonneTableParametrable> colsSrc = tpSource.Colonnes.ToList<CColonneTableParametrable>();
				colsSrc.Sort ( new CColonneTableParametrable_ProrityComparer());

				foreach (CColonneTableParametrable colCible in colsCible)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = new CMappageColonneTableParametrableColonneTableParametrable();
					map.ColonneB = colCible;
					foreach (CColonneTableParametrable colSrc in colsSrc)
						if (colSrc.Libelle == colCible.Libelle
							&& colSrc.TypeDonneeChamp.TypeDotNetAssocie == colCible.TypeDonneeChamp.TypeDotNetAssocie)
						{
							map.ColonneA = colSrc;
							break;
						}

					m_mappages.Add(map);
				}
			}
		}

		public CResultAErreur VerifMappage()
		{
			return VerifMappage(m_mappages);
		}
		public CResultAErreur Mapper(DataTable dtSource)
		{
			DataTable dtFinale = TypeTableCible.GetNewDataTable(dtSource.TableName);
			CResultAErreur result = Mapper(dtSource, dtFinale);
			result.Data = dtFinale;
			return result;
		}
		public CResultAErreur Mapper(DataTable dtSource, DataTable dtFinale)
		{
			return Mapper(m_mappages, dtSource, dtFinale);
		}

		private List<CMappageColonneTableParametrableColonneTableParametrable> m_mappages;
		public List<CMappageColonneTableParametrableColonneTableParametrable> Mappages
		{
			get
			{
				return m_mappages;
			}
		}

		public static CResultAErreur VerifMappage(List<CMappageColonneTableParametrableColonneTableParametrable> mappages)
		{
			CResultAErreur result = CResultAErreur.True;
			if (mappages == null || mappages.Count == 0)
			{
				result.EmpileErreur(I.T("No mapping available|30003"));
				return result;
			}
			CTypeTableParametrable tpDestination = null;
			foreach (CMappageColonneTableParametrableColonneTableParametrable map in mappages)
			{
				CResultAErreur resultMap = map.VerifMappage();
				if (!resultMap)
				{
					foreach (IErreur err in resultMap.Erreur.Erreurs)
						result.EmpileErreur(err);
					resultMap.EmpileErreur(new CErreurValidation(I.T("Mapping errors (@1)|30025", map.Description), true));
				}

				if (map.TypeTableColonneB == null)
					break;
				if (tpDestination == null)
					tpDestination = map.TypeTableColonneB;

				else if (map.TypeTableColonneB != tpDestination)
				{
					result.EmpileErreur(I.T("Error : several targeted table types destination are present|30024"));
					break;
				}
			}
			if (!result) return result;

			foreach (CColonneTableParametrable col in tpDestination.Colonnes)
			{
				if (!col.AllowNull && !ColonneDestinationMappee(col, mappages))
					if (col.IsPrimaryKey)
						result.EmpileErreur(I.T("The @1 column is in the primary key : it must be mapped|30009", col.Libelle));
					else
						result.EmpileErreur(I.T("The @1 column doesn't accept the NULL value : it must be mapped|30010", col.Libelle));
				if (NombreMappageColonneDestination(col, mappages) > 1)
					result.EmpileErreur(I.T("The @1 targeted column cannot be map several times|30023", col.Libelle));
			}
			return result;
		}
		private static int NombreMappageColonneDestination(CColonneTableParametrable col, List<CMappageColonneTableParametrableColonneTableParametrable> mappages)
		{
			int nb = 0;
			foreach (CMappageColonneTableParametrableColonneTableParametrable map in mappages)
				if (map.ColonneB == col)
					nb++;
			return nb;
		}
		private static bool ColonneDestinationMappee(CColonneTableParametrable col, List<CMappageColonneTableParametrableColonneTableParametrable> mappages)
		{
			return NombreMappageColonneDestination(col, mappages) > 0;
		}


		/// <summary>
		/// Execute le mappage de la dtSource vers la dtFinale en fonction des objets mappage
		/// </summary>
		/// <param name="mappages"></param>
		/// <param name="dtSource"></param>
		/// <param name="dtFinale"></param>
		/// <returns></returns>
		public static CResultAErreur Mapper(List<CMappageColonneTableParametrableColonneTableParametrable> mappages, DataTable dtSource, DataTable dtFinale)
		{
			CResultAErreur result = CResultAErreur.True;

			if (mappages == null || mappages.Count == 0)
			{
				result.EmpileErreur(I.T("No mapping available|30003"));
				return result;
			}

			if (dtSource != null && dtSource.Rows.Count == 0)
			{
				return result;
			}
			
			
			result = VerifMappage(mappages);
			foreach(IErreur err in result.Erreur.Erreurs)
				if (err.GetType() == typeof(CErreurValidation) && !((CErreurValidation)err).IsAvertissement
					|| err.GetType() != typeof(CErreurValidation))
				{
					return result;
				}

			result = CResultAErreur.True;
			
			if (dtSource == null)
			{
				result.EmpileErreur(I.T("Source data Table needed|30019"));
			}
			else if (dtFinale == null)
			{
				result.EmpileErreur(I.T("Target data Table needed|30020"));
			}
			else
			{
				//Verification que le type Source correspond à la table source
				CTypeTableParametrable tpSrc = null;
				foreach (CMappageColonneTableParametrableColonneTableParametrable m in mappages)
					if (m.ColonneA != null)
					{
						tpSrc = m.ColonneA.TypeTable;
						break;
					}
				if (tpSrc != null)
				{
					foreach (CColonneTableParametrable c in tpSrc.Colonnes)
						if (!dtSource.Columns.Contains(c.Libelle))
						{
							result.EmpileErreur(I.T("Provided source table doesn't match the target type|30004"));
							break;
						}

					//Verification que tout les types source sont identiques
					foreach (CMappageColonneTableParametrableColonneTableParametrable m in mappages)
						if (m.ColonneA != null && m.ColonneA.TypeTable != tpSrc)
						{
							result.EmpileErreur(I.T("Error: Origin columns do not all belong to the @1 type|30026", tpSrc.Libelle));
							break;
						}
				}

				//Verification que le type Cible correspond à la table finale
				CTypeTableParametrable tpCible = mappages[0].TypeTableColonneB;
				foreach (CColonneTableParametrable c in tpCible.Colonnes)
					if (!dtFinale.Columns.Contains(c.Libelle))
					{
						result.EmpileErreur(I.T("The provided target table doesn't match the source type|30021"));
						break;
					}
				//Verification que tout les types source sont identiques
				foreach (CMappageColonneTableParametrableColonneTableParametrable m in mappages)
					if (m.ColonneB != null && m.ColonneB.TypeTable != tpCible)
					{
						result.EmpileErreur(I.T("Error: Target columns do not all belong to the @1 type|30027", tpCible.Libelle));
						break;
					}
			}

			if (!result)
				return result;


			//On groupe les mappages en 2 listes (mappage col col et mappage constante col)
			CTypeTableParametrable tpDest = mappages[0].ColonneB.TypeTable;
			Dictionary<CColonneTableParametrable, CMappageColonneTableParametrableColonneTableParametrable> mappColAtoB = new Dictionary<CColonneTableParametrable, CMappageColonneTableParametrableColonneTableParametrable>();
			Dictionary<CColonneTableParametrable, object> mappDefault = new Dictionary<CColonneTableParametrable, object>();
			foreach (CMappageColonneTableParametrableColonneTableParametrable map in mappages)
			{
				if (map.ColonneA != null)
					mappColAtoB.Add(map.ColonneA, map);
				else
					mappDefault.Add(map.ColonneB, map.DefaultValueAtoB);
			}


			//Mappage
			foreach (DataRow rowSrc in dtSource.Rows)
			{
				DataRow rowDest = dtFinale.NewRow();
				foreach (CColonneTableParametrable col in mappColAtoB.Keys)
				{
					CMappageColonneTableParametrableColonneTableParametrable map = mappColAtoB[col];
					object val = DBNull.Value;
					if (!map.NeedDefaultValueAtoB || (rowSrc[col.Libelle] != DBNull.Value && rowSrc[col.Libelle] != null))
						val = rowSrc[col.Libelle];
					else
						val = map.DefaultValueAtoB;

					try
					{
						rowDest[map.ColonneB.Libelle] = val;
					}
					catch
					{
						result.EmpileErreur(new CErreurValidation(I.T("Error in assignment of the '@1' value to the @2 column|30022", val.ToString(), col.Libelle), true));
					}
				}
				foreach (CColonneTableParametrable col in mappDefault.Keys)
				{
					object val = mappDefault[col];
					try
					{
						rowDest[col.Libelle] = val;
					}
					catch
					{
						result.EmpileErreur(new CErreurValidation(I.T("Error in assignment of the '@1' value to the @2 column|30022", val.ToString(), col.Libelle), true));
					}
				}
				try
				{
					dtFinale.Rows.Add(rowDest);
				}
				catch (Exception e)
				{
					string strRow = "";
					foreach (DataColumn dc in dtFinale.Columns)
					{
						if (dc.ColumnName == "ID")
							continue;
						object val = rowDest[dc.ColumnName];
						string strVal = val == DBNull.Value? "NULL":val.ToString();
						strRow += strVal + " | ";
					}
					if (strRow.Length > 0)
						strRow = strRow.Substring(0, strRow.Length - 3);

					result.EmpileErreur(new CErreurValidation(I.T("The line ' @1 ' could not be imported because @2|30006",strRow, e.Message), true));
				}
			}
			result.Data = dtFinale;
			if (!result)
				result.EmpileErreur(new CErreurValidation(I.T("One or more lines could not be imported |30005"), true));
			return result;
		}
	}
}
