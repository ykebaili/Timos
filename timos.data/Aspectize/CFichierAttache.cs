using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        DataRow m_row;

        public CFichierAttache()
        {

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

            dt.Columns.Add(c_champKey, typeof(string));
            dt.Columns.Add(c_champNomFichier, typeof(string));
            dt.Columns.Add(c_champDateUpload, typeof(DateTime));
            dt.Columns.Add(c_champDateDocument, typeof(DateTime));
            dt.Columns.Add(c_champCommentaire, typeof(string));

            return dt;
        }
    }
}
