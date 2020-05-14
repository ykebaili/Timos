﻿using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CChampTimosWebApp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "TIMOS_FIELDS";

        public const string c_champId = "TIMOS_FIELD_ID";
        public const string c_champNom = "TIMOS_FIELD_NAME";
        public const string c_champLibelleConvivial = "TIMOS_FIELD_WEB_LABEL";
        public const string c_champOrdreAffichage = "TIMOS_FIELD_DISP_ORDER";
        public const string c_champTypeDonne = "TIMOS_FIELD_DATA_TYPE";

        DataRow m_row = null;

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        public CChampTimosWebApp(C2iWndChampCustom wndChamp, DataRow row)
        {
            int nIdChampCustom = -1;
            string strNomChamp = "";
            string strLibelleWeb = wndChamp.WebLabel;
            int nOrdreWeb = wndChamp.WebNumOrder;
            int nTypeDonneeChamp = 2; // par défaut type string

            CChampCustom champ = wndChamp.ChampCustom;
            if (champ != null)
            {
                nIdChampCustom = champ.Id;
                strNomChamp = champ.Nom;
                nTypeDonneeChamp = (int)champ.TypeDonneeChamp.TypeDonnee;
            }

            row[c_champId] = nIdChampCustom;
            row[c_champNom] = strNomChamp;
            row[c_champLibelleConvivial] = strLibelleWeb;
            row[c_champOrdreAffichage] = nOrdreWeb;
            row[c_champTypeDonne] = nTypeDonneeChamp;
        }

        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champNom, typeof(string));
            dt.Columns.Add(c_champLibelleConvivial, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champTypeDonne, typeof(int));

            return dt;
        }
    }
}
