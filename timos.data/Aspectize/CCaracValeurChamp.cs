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
    public class CCaracValeurChamp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "CaracValeurChamp";

        public const string c_champId = "ChampTimosId";
        public const string c_champLibelle = "LibelleChamp";
        public const string c_champOrdreAffichage = "OrdreChamp";
        public const string c_champValeur = "ValeurChamp";
        public const string c_champElementType = "ElementType";
        public const string c_champElementId = "ElementId";
        public const string c_champIdCaracteristique = "TIMOS_FIELD_ID_CARAC";


        DataRow m_row;
        object m_valeur = null;

        public CCaracValeurChamp(DataSet ds, IObjetDonneeAChamps obj, string strTypeElement, C2iWndChampCustom wndChamp, int nIdCaracAssociee)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            int nIdChamp = -1;
            string strLibelleWeb = wndChamp.WebLabel;
            int nOrdreWeb = wndChamp.WebNumOrder;
            string strValeur = "";
            int nElementId = -1;
            string strElementType = strTypeElement;

            CChampCustom champ = wndChamp.ChampCustom;
            if (champ != null)
            {
                nIdChamp = champ.Id;

                if (obj != null)
                {
                    m_valeur = CUtilElementAChamps.GetValeurChamp(obj, nIdChamp);
                    strElementType = obj.GetType().ToString();
                    nElementId = ((IObjetDonneeAIdNumerique)obj).Id;
                }
                if (m_valeur != null)
                {
                    if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                    {
                        IObjetDonneeAIdNumerique objetValeur = m_valeur as IObjetDonneeAIdNumerique;
                        if (objetValeur != null)
                            strValeur = objetValeur.Id.ToString();
                    }
                    else
                    {
                        try
                        {
                            strValeur = m_valeur.ToString();
                        }
                        catch
                        {
                            strValeur = "";
                        }
                    }
                }
            }

            row[c_champId] = nIdChamp;
            row[c_champLibelle] = strLibelleWeb;
            row[c_champOrdreAffichage] = nOrdreWeb;
            row[c_champValeur] = strValeur;
            row[c_champElementType] = strElementType;
            row[c_champElementId] = nElementId;
            row[c_champIdCaracteristique] = nIdCaracAssociee;

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
            dt.Columns.Add(c_champIdCaracteristique, typeof(int));

            return dt;
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }
    }
}
