using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CChampValeursPossibles : IEntiteTimosWebApp
    {
        public const string c_nomTable = "ValeursChamp";

        public const string c_champId = "ChampTimosId";
        public const string c_champValue = "StoredValue";
        public const string c_champDisplay = "DisplayedValue";
        public const string c_champIndex = "Index";


        private DataRow m_row;

        public CChampValeursPossibles(int nIdChamp, string strStore, string strDisplay, int nIndex, DataRow row)
        {

            row[c_champId] = nIdChamp;
            row[c_champValue] = strStore;
            row[c_champDisplay] = strDisplay;
            row[c_champIndex] = nIndex;

            m_row = row;
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

            return dt;
        }
    }
}
