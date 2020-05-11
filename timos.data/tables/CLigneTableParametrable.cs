using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection.Emit;
using sc2i.common;
using sc2i.expression;

namespace timos.data
{
    /// <summary>
    /// Une ligne (un enregistrement) de <see cref="CTableParametrable">table paramétrable</see>
    /// </summary>
	[DynamicClass("Custom table row")]
	public class CLigneTableParametrable
	{
		private DataRow m_row;

		public CLigneTableParametrable(DataRow row)
		{
			m_row = row;
		}

        /// <summary>
        /// Retourne la valeur pour la colonne passée en paramètre
        /// </summary>
        /// <param name="strColumnName">Nom de la colonne</param>
        /// <returns></returns>
		[DynamicMethod("Return the value for the given column", "Column name")]
		public object GetValue(string strColumnName)
		{
			try
			{
				if (m_row[strColumnName] == DBNull.Value)
					return null;
				else
					return m_row[strColumnName];
			}
			catch
			{
				return null;
			}
		}

        /// <summary>
        /// Renseigne la valeur pour la colonne passée en paramètre
        /// </summary>
        /// <param name="strColumnName">Nom de la colonne</param>
        /// <param name="value">Valeur à renseigner</param>
		[DynamicMethod("Set the value for the given column", "Column name", "value")]
		public void SetValue(string strColumnName, object value)
		{
			m_row[strColumnName] = value==null?DBNull.Value:value;
		}

        /// <summary>
        /// Retourne la clé correspondant à la ligne, sous la forme d'un tableau d'objets
        /// </summary>
        /// <returns></returns>
		[DynamicMethod("return the key of the row")]
		public object[] GetKey()
		{
			List<object> valPk = new List<object>();
			foreach (DataColumn c in m_row.Table.PrimaryKey)
				valPk.Add(m_row[c]);

			return valPk.ToArray();
		}

        [DynamicField("Custom table")]
        public CTableParametrable CustomTable
        {
            get
            {
                return CTableParametrable.GetTableParametrableForTable(m_row.Table);
            }
        }


		public static implicit operator DataRow(CLigneTableParametrable ligne)
		{
			return ligne.m_row;
		}
		public static implicit operator CLigneTableParametrable(DataRow row)
		{
			return new CLigneTableParametrable(row);
		}
	}
}
