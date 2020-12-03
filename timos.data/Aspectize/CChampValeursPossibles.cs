using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;

namespace timos.data.Aspectize
{
    public class CChampValeursPossibles : IEntiteTimosWebApp
    {
        public const string c_nomTable = "ValeursChamp";

        public const string c_champId = "ChampTimosId";
        public const string c_champValue = "StoredValue";
        public const string c_champDisplay = "DisplayedValue";
        public const string c_champIndex = "Index";
        public const string c_champIdCaracteristique = "TIMOS_FIELD_ID_CARAC";


        private DataRow m_row;

        public CChampValeursPossibles(DataSet ds, int nIdChamp, string strStore, string strDisplay, int nIndex, int nIdCaracAssociee)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            row[c_champId] = nIdChamp;
            row[c_champValue] = strStore;
            row[c_champDisplay] = strDisplay;
            row[c_champIndex] = nIndex;
            row[c_champIdCaracteristique] = nIdCaracAssociee;

            m_row = row;
            dt.Rows.Add(row);
        }


        //---------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }


        //---------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champValue, typeof(string));
            dt.Columns.Add(c_champDisplay, typeof(string));
            dt.Columns.Add(c_champIndex, typeof(int));
            dt.Columns.Add(c_champIdCaracteristique, typeof(int));

            return dt;
        }

        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }
    }
}
