using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CTodoValeurChamp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "TodoValeurChamp";

        public const string c_champId = "ChampTimosId";
        public const string c_champLibelle = "LibelleChamp";
        public const string c_champOrdreAffichage = "OrdreChamp";
        public const string c_champValeur = "ValeurChamp";

        DataRow m_row;
        object m_valeur;

        public CTodoValeurChamp(IObjetDonneeAChamps obj, C2iWndChampCustom wndChamp, DataRow row)
        {
            CResultAErreur result = CResultAErreur.True;

            int nIdChamp = -1;
            string strLibelleWeb = wndChamp.WebLabel;
            int nOrdreWeb = wndChamp.WebNumOrder;

            CChampCustom champ = wndChamp.ChampCustom;
            if (champ != null)
            {
                nIdChamp = champ.Id;
                m_valeur = CUtilElementAChamps.GetValeurChamp(obj, nIdChamp);

                row[c_champId] = nIdChamp;
                row[c_champLibelle] = strLibelleWeb;
                row[c_champOrdreAffichage] = nOrdreWeb;
                if (m_valeur != null)
                    row[c_champValeur] = m_valeur.ToString();
                else
                    row[c_champValeur] = "";
            }
            m_row = row;
        }

        //---------------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //---------------------------------------------------------------------------------------
        public object Valeur
        {
            get
            {
                return m_valeur;
            }
        }

        //---------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champValeur, typeof(string));

            return dt;
        }

    }
}
