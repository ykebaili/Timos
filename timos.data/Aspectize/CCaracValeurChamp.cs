using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.expression;
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
        public const string c_champUseAutoComplete = "UseAutoComplete";


        DataRow m_row;
        object m_valeur = null;

        public CCaracValeurChamp(DataSet ds, IObjetDonneeAChamps obj, CChampTimosWebApp champWeb, string strTypeElement, string strIdCaracAssociee, bool bIsEditable)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            int nIdChampWeb = champWeb.Id;
            int nIdChampTimos = champWeb.IdTimos;
            string strLibelleWeb = champWeb.WebLabel;
            int nOrdreWeb = champWeb.WebNumOrder;
            string strValeur = "";
            int nElementId = -1;
            string strElementType = strTypeElement;

            CChampCustom champ = champWeb.Champ;
            bool bAutoComplete = champWeb.UseAutoComplete;
            if (champ != null)
            {
                if (obj != null)
                {
                    strElementType = obj.GetType().ToString();
                    nElementId = ((IObjetDonneeAIdNumerique)obj).Id;

                    m_valeur = CUtilElementAChamps.GetValeurChamp(obj, nIdChampTimos);
                    if (m_valeur != null)
                    {
                        if (champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto)
                        {
                            IObjetDonneeAIdNumerique objetValeur = m_valeur as IObjetDonneeAIdNumerique;
                            if (objetValeur != null)
                            {
                                try
                                {
                                    if (bIsEditable && !bAutoComplete)
                                        strValeur = objetValeur.Id.ToString();
                                    else
                                        strValeur = objetValeur.DescriptionElement;
                                }
                                catch
                                {
                                    strValeur = "";
                                }
                            }
                        }
                        else if (champ.IsChoixParmis())
                        {
                            try
                            {
                                if (bIsEditable)
                                    strValeur = m_valeur.ToString();
                                else
                                    strValeur = champ.DisplayFromValue(m_valeur);
                            }
                            catch
                            {
                                strValeur = "";
                            }
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
            }
            else
            {
                C2iExpression formule = champWeb.Formule;
                if (formule != null)
                {
                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(obj);
                    CResultAErreur resFormule = formule.Eval(ctx);
                    if (resFormule && resFormule.Data != null)
                    {
                        strValeur = resFormule.Data.ToString();
                    }
                }
            }

            row[c_champId] = nIdChampWeb;
            row[c_champLibelle] = strLibelleWeb;
            row[c_champOrdreAffichage] = nOrdreWeb;
            row[c_champValeur] = strValeur;
            row[c_champElementType] = strElementType;
            row[c_champElementId] = nElementId;
            row[c_champIdCaracteristique] = strIdCaracAssociee;
            row[c_champUseAutoComplete] = champWeb.UseAutoComplete;

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
            dt.Columns.Add(c_champIdCaracteristique, typeof(string));
            dt.Columns.Add(c_champUseAutoComplete, typeof(bool));

            return dt;
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }
    }
}
