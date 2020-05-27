using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.documents;

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

        public const string c_nomFortTypeCaracteristiqueDocument = "WEB_DOCUMENT_ATTENDU";
        public const string c_nomFortChampCategorie = "WEB_CC_DOCUMENT_CATEGORIE";

        DataRow m_row;
        CCaracteristiqueEntite m_caracteristic;

        public CDocumentAttendu(DataSet ds, CCaracteristiqueEntite carac)
        {
            m_caracteristic = carac;
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();
            int nIdCarac = -1;
            string strLibelle = "";
            string strCategorie = "";
            int nbMin = 0;
            DateTime? dateLastUpload = null;

            if (carac != null)
            {
                row[c_champId] = carac.Id;
                row[c_champLibelle] = carac.Libelle;
                row[c_champCategorieDocument] = carac.Libelle; // A modifier
                row[c_champNombreMin] = nbMin;
                if (dateLastUpload == null)
                    row[c_champDateLastUpload] = DBNull.Value;
                else
                    row[c_champDateLastUpload] = dateLastUpload.Value;
            }

            m_row = row;
            dt.Rows.Add(row);
        }

        public CDocumentAttendu(CCaracteristiqueEntite carac, DataRow row)
        {
            int nIdCarac = -1;
            string strLibelle = "";
            string strCategorie = "";
            int nbMin = 0;
            DateTime? dateLastUpload = null;

            if(carac != null)
            {
                row[c_champId] = carac.Id;
                row[c_champLibelle] = carac.Libelle;
                row[c_champCategorieDocument] = carac.Libelle; // A modifier
                row[c_champNombreMin] = nbMin;
                if (dateLastUpload == null)
                    row[c_champDateLastUpload] = DBNull.Value;
                else
                    row[c_champDateLastUpload] = dateLastUpload.Value;
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

        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;

            CDocumentGED[] listeGED = CDocumentGED.GetListeDocumentsForElement(m_caracteristic).ToArray<CDocumentGED>();
            foreach (CDocumentGED ged in listeGED)
            {
                CFichierAttache fichier = new CFichierAttache(ds, ged);
                fichier.DocumentId = m_caracteristic.Id;
            }

            return result;
        }
    }
}
