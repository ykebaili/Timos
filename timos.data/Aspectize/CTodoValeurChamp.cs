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
        public const string c_champElementType = "ElementType";
        public const string c_champElementId = "ElementId";


        DataRow m_row;
        object m_valeur;

        public CTodoValeurChamp(DataSet ds, IObjetDonneeAChamps obj, C2iWndChampCustom wndChamp)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

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
                row[c_champValeur] = "";
                row[c_champElementType] = obj.GetType().ToString();
                row[c_champElementId] = ((IObjetDonneeAIdNumerique)obj).Id;

                if (m_valeur != null)
                {
                    if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                    {
                        IObjetDonneeAIdNumerique objetValeur = m_valeur as IObjetDonneeAIdNumerique;
                        if (objetValeur != null)
                            row[c_champValeur] = objetValeur.Id.ToString();
                    }
                    else
                    {
                        try
                        {
                            row[c_champValeur] = m_valeur.ToString();
                        }
                        catch
                        {
                            row[c_champValeur] = "";
                        }
                    }
                }
            }
            m_row = row;
            dt.Rows.Add(row);

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
            dt.Columns.Add(c_champElementType, typeof(string));
            dt.Columns.Add(c_champElementId, typeof(int));

            return dt;
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }
    }
}
