using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.data.dynamic;

namespace timos.data.Aspectize
{
    public class CExportWeb : IEntiteTimosWebApp
    {
        public const string c_nomTable = "Export";

        public const string c_champId = "Id";
        public const string c_champLibelle = "Libelle";
        public const string c_champDescription = "Description";
        public const string c_champDateDonnees = "DataDate";

        DataRow m_row;

        public CExportWeb(DataSet ds, C2iStructureExportInDB structureExport)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            if(structureExport != null)
            {
                DataRow row = dt.NewRow();

                row[c_champId] = structureExport.Id;
                row[c_champLibelle] = structureExport.Libelle;
                row[c_champDescription] = structureExport.Description;
                row[c_champDateDonnees] = DateTime.Now;

                m_row = row;
                dt.Rows.Add(row);
            }

        }

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }

        //---------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champDescription, typeof(string));
            dt.Columns.Add(c_champDateDonnees, typeof(DateTime));

            return dt;
        }
    }
}
