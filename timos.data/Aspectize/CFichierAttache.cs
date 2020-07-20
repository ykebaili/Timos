using sc2i.documents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;

namespace timos.data.Aspectize
{
    public class CFichierAttache : IEntiteTimosWebApp
    {
        public const string c_nomTable = "FichiersAttaches";

        public const string c_champKey = "TimosKey";
        public const string c_champNomFichier = "NomFichier";
        public const string c_champDateUpload = "DateUpload";
        public const string c_champDateDocument = "DateDocument";
        public const string c_champCommentaire = "Commentaire";
        public const string c_champIdDocumentAttendu = "DocumentId";
        public const string c_champCheminTemporaire = "CheminTemporaire";

        DataRow m_row;
        CDocumentGED m_doc_GED;

        public CFichierAttache(DataSet ds, CDocumentGED docGED)
        {
            m_doc_GED = docGED;
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            row[c_champKey] = docGED.Cle != "" ? docGED.Cle : docGED.IdUniversel;
            row[c_champNomFichier] = docGED.Libelle;
            row[c_champDateUpload] = docGED.DateCreation;
            row[c_champDateDocument] = docGED.DateMAJ;
            row[c_champCommentaire] = docGED.Descriptif;
            row[c_champCheminTemporaire] = "";

            m_row = row;
            dt.Rows.Add(row);
        }

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        public int DocumentId
        {
            get
            {
                return (int)m_row[c_champIdDocumentAttendu];
            }
            set
            {
                m_row[c_champIdDocumentAttendu] = value;
            }
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champKey, typeof(string));
            dt.Columns.Add(c_champNomFichier, typeof(string));
            dt.Columns.Add(c_champDateUpload, typeof(DateTime));
            dt.Columns.Add(c_champDateDocument, typeof(DateTime));
            dt.Columns.Add(c_champCommentaire, typeof(string));
            dt.Columns.Add(c_champIdDocumentAttendu, typeof(int));
            dt.Columns.Add(c_champCheminTemporaire, typeof(string));

            return dt;
        }

        public CResultAErreur FillDataSet(DataSet ds)
        {
            throw new NotImplementedException();
        }
    }
}
