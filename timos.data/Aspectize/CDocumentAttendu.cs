using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CDocumentAttendu : IEntiteTimosWebApp
    {
        public const string c_nomTable = "DocumentsAttendus";

        public const string c_champId = "TimosId";
        public const string c_champLibelle = "Libelle";
        public const string c_champCategorieDocument = "CategorieDocument";
        public const string c_champNombreMin = "NombreMin";
        public const string c_champDateLastUpload = "DateLastUpload";

        public const string c_nomFortTypeCaracteristiqueDocument = "WEB_DOCUMENTS_ATTENDUS";

        DataRow m_row;

        public CDocumentAttendu(CCaracteristiqueEntite carac, DataRow row)
        {
            int nIdCarac = -1;
            string strLibelle = "";
            string strCategorie = "";
            int nbMin = 0;
            DateTime? dateLastUpload = null;

            if(carac != null)
            {


            }


            m_row = row;
        }


        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champCategorieDocument, typeof(string));
            dt.Columns.Add(c_champNombreMin, typeof(int));
            dt.Columns.Add(c_champDateLastUpload, typeof(DateTime));

            return dt;
        }
    }
}
