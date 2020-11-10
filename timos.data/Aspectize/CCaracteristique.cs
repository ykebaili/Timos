using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.formulaire;

namespace timos.data.Aspectize
{
    public class CCaracteristique : IEntiteTimosWebApp
    {
        public const string c_nomTable = "DocumentsAttendus";

        public const string c_champTimosId = "TimosId";
        public const string c_champTitre = "Titre";
        public const string c_champOrdreAffichage = "OrdreAffichage";
        public const string c_champExpand = "Expand";


        DataRow m_row;
        CCaracteristiqueEntite m_caracteristic;

        public CCaracteristique(DataSet ds, CCaracteristiqueEntite carac)
        {
            m_caracteristic = carac;
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            if(carac != null)
            {
                row[c_champTimosId] = carac.Id;
                row[c_champTitre] = carac.Libelle;
                //row[c_champOrdreAffichage] = carac.

            }
            
        }

        //------------------------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //------------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds, C2iWnd fenetre)
        {
            CResultAErreur result = CResultAErreur.True;



            return result;
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champTimosId, typeof(int));
            dt.Columns.Add(c_champTitre, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));

            return dt;
        }

    }
}
