using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using sc2i.data.dynamic;
using sc2i.common;

namespace spv.data
{
    public class CDivers
    {
        public const string strMaxDateMasquage = "31/12/2035 00:00:00";
        public System.DateTime time0 = new DateTime(1998, 1, 1, 0, 0, 0);
        public const string c_cleRowCrees = "cleRowCrees";
        public const string c_cleRowModifiees = "cleRowModifiees";

        public DateTime? FromSecToDate(double? secondes)
        {
            if (secondes == null)
                return null;
            else
            {
                System.DateTime date = new DateTime();

                TimeSpan interval = TimeSpan.FromSeconds((double)secondes);
                date = time0 + interval;

                return date;
            }
        }

        public double? FromDateToSec(DateTime? date)
        {
            if (date == null)
                return null;
            else
            {
                TimeSpan span = new TimeSpan();
                span = (TimeSpan)(date - time0);
                return span.TotalSeconds;
            }
        }

        public string FromDateToString(DateTime date)
        {
            string stDate;
             
            stDate = string.Format("{0} {1} {2} {3}:{4}:{5}", date.Year, date.Month,
                    date.Day, date.Hour, date.Minute, date.Second);

            return stDate;
        }

        public string Extract (string Mess, ref int IndDeb, string st)
        {
            string stRes="";
            int index = Mess.IndexOf(st, IndDeb);

            if (index > 0)
            {
                stRes = Mess.Substring(IndDeb, index - IndDeb);
                IndDeb = index + 1;
            }
            else
            {
                IndDeb = -1;
            }
            
            return stRes;
        }

        public Int32 ConvertToInt32(string st, int nDefault)
        {
            if (st.Length == 0)
                st = string.Format("{0}", nDefault);
            
            return System.Convert.ToInt32(st);
        }

        public static int ConvertToint(string st, int nDefault)
        {
            if (st.Length == 0)
                st = string.Format("{0}", nDefault);
            
            return System.Convert.ToInt32(st);
        }


        public static DateTime? GetSysdateFromBdd()
        {
            C2iRequete requete = new C2iRequete();
            requete.TypeReferencePourConnexion = typeof(CSpvSite);
            requete.TexteRequete = "SELECT sysdate from dual";
            CResultAErreur result = requete.ExecuteRequete(0); 

            if (result)
            {
                DateTime dateServeur = (DateTime)(((System.Data.DataTable)result.Data).Rows[0][0]);
                return dateServeur;
            }
            else
                return null;
        }

        public static string GetSysdateFromBdd_String()
        {
            DateTime? dateNow = GetSysdateFromBdd();
            return (dateNow == null) ? "" : ((DateTime)dateNow).ToString("G");
        }

        public static DateTime GetSysdateNotNull()
        {
            DateTime? dateNow = GetSysdateFromBdd();
            return (dateNow == null) ? DateTime.Now : (DateTime)dateNow;
        }

        public static string DbNullValue (object theData, string defaultValue)
        {
            if (theData == DBNull.Value)
                return defaultValue;
            return (string)theData;
        }
    }
}
