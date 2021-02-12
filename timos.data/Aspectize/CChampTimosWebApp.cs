using sc2i.data.dynamic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using System.Collections;
using sc2i.data;
using sc2i.expression;

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
        public const string c_champIsChoixParmis = "TIMOS_FIELD_IS_SELECT";
        public const string c_champIsMultiline = "TIMOS_FIELD_IS_MULTILINE";
        public const string c_champIsEditable = "TIMOS_FIELD_IS_EDITABLE";
        public const string c_champIdGroupeChamps = "TIMOS_FIELD_ID_GROUPE";
        public const string c_champIdCaracteristique = "TIMOS_FIELD_ID_CARAC";

        public const string c_champElementSource = "Source element";

        DataRow m_row = null;
        CChampCustom m_champ;
        IElementAVariables m_elementAVariables = null;

        public CChampTimosWebApp(DataSet ds, C2iWndChampCustom wndChamp, IElementAVariables elementEdite, int nIdGroupe, string strIdCarac, bool bIsEditable)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;
            m_elementAVariables = elementEdite;

            DataRow row = dt.NewRow();

            int nIdChampCustom = -1;
            string strNomChamp = "";
            string strLibelleWeb = wndChamp.WebLabel;
            int nOrdreWeb = wndChamp.WebNumOrder;
            int nTypeDonneeChamp = 2; // par défaut type string
            bool bIsChoixParmis = false;
            bool bIsMultiline = wndChamp.MultiLine;

            CChampCustom champ = wndChamp.ChampCustom;
            if (champ != null)
            {
                m_champ = champ;
                nIdChampCustom = champ.Id;
                strNomChamp = champ.Nom;
                nTypeDonneeChamp = (int)champ.TypeDonneeChamp.TypeDonnee;
                bIsChoixParmis = champ.IsChoixParmis();
                // bIsEditable = à implémenter
            }

            row[c_champId] = bIsEditable ? nIdChampCustom : 0 - nIdChampCustom;
            row[c_champNom] = strNomChamp;
            row[c_champLibelleConvivial] = strLibelleWeb == "" ? strNomChamp : strLibelleWeb;
            row[c_champOrdreAffichage] = nOrdreWeb;
            row[c_champTypeDonne] = nTypeDonneeChamp;
            row[c_champIsChoixParmis] = bIsChoixParmis && bIsEditable;
            row[c_champIsMultiline] = bIsMultiline;
            row[c_champIsEditable] = bIsEditable;
            row[c_champIdGroupeChamps] = nIdGroupe;
            row[c_champIdCaracteristique] = strIdCarac;

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
        public CChampCustom Champ
        {
            get
            {
                return m_champ;
            }
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;

            if ((bool)m_row[c_champIsChoixParmis])
            {
                string strStore = "";
                string strDisplay = "";
                int nIndex = 0;
                IList listeValeurs = null;
                listeValeurs = m_champ.Valeurs;
                int nIdGroupeAssocie = (int)m_row[c_champIdGroupeChamps];
                string strIdCaracAssociee = (string)m_row[c_champIdCaracteristique];

                if (m_champ.TypeDonneeChamp.TypeDonnee == TypeDonnee.tObjetDonneeAIdNumeriqueAuto && listeValeurs is CListeObjetsDonnees)
                {
                    CListeObjetsDonnees listeObjets = (CListeObjetsDonnees)listeValeurs;
                    CFiltreData filtre = listeObjets.Filtre;
                    CFiltreDynamique filtreDyn = m_champ.FiltreObjetDonnee;
                    if (filtreDyn != null)
                    {
                        filtre = GetFiltre(filtreDyn);
                    }
                    if (filtre != null)
                        listeObjets.Filtre = filtre;
                    CChampValeursPossibles valeurPossible = new CChampValeursPossibles(ds, m_champ.Id, "-1", "(à définir)", nIndex++, nIdGroupeAssocie, strIdCaracAssociee);
                    foreach (IObjetDonneeAIdNumerique objetTimos in listeObjets)
                    {
                        strStore = objetTimos.Id.ToString();
                        strDisplay = objetTimos.DescriptionElement;
                        valeurPossible = new CChampValeursPossibles(ds, m_champ.Id, strStore, strDisplay, nIndex++, nIdGroupeAssocie, strIdCaracAssociee);
                    }
                }
                else
                {
                    foreach (CValeurChampCustom valPossible in m_champ.Valeurs)
                    {
                        strStore = valPossible.ValueString;
                        strDisplay = valPossible.Display;
                        CChampValeursPossibles valeurPossible = new CChampValeursPossibles(ds, m_champ.Id, strStore, strDisplay, nIndex++, nIdGroupeAssocie, strIdCaracAssociee);
                    }
                }
            }

            return result;
        }

        //---------------------------------------------------------------------------------------
        private CFiltreData GetFiltre(CFiltreDynamique filtre)
        {
            if (filtre == null)
                return null;
            if (m_elementAVariables != null)
            {
                IVariableDynamique variable = AssureVariableElementCible(filtre, m_elementAVariables.GetType());
                filtre.SetValeurChamp(variable.IdVariable, m_elementAVariables);
            }
            CResultAErreur result = filtre.GetFiltreData();
            if (result)
                return (CFiltreData)result.Data;
            return null;
        }

        //---------------------------------------------------------------------------------------
        private IVariableDynamique AssureVariableElementCible(CFiltreDynamique filtre, Type typeElement)
        {
            IVariableDynamique variableASupprimer = null;
            foreach (IVariableDynamique variable in filtre.ListeVariables)
            {
                if (variable.Nom == c_champElementSource)
                {
                    if (variable.TypeDonnee.TypeDotNetNatif != typeElement)
                        variableASupprimer = variable;
                    else
                        return variable;
                }
            }
            if (variableASupprimer != null)
                filtre.RemoveVariable(variableASupprimer);
            CVariableDynamiqueSysteme newVariable = new CVariableDynamiqueSysteme(filtre);
            newVariable.Nom = c_champElementSource;
            newVariable.SetTypeDonnee(new sc2i.expression.CTypeResultatExpression(typeElement, false));
            filtre.AddVariablePropreAuFiltre(newVariable);
            return newVariable;
        }

        //---------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champNom, typeof(string));
            dt.Columns.Add(c_champLibelleConvivial, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champTypeDonne, typeof(int));
            dt.Columns.Add(c_champIsChoixParmis, typeof(bool));
            dt.Columns.Add(c_champIsMultiline, typeof(bool));
            dt.Columns.Add(c_champIsEditable, typeof(bool));
            dt.Columns.Add(c_champIdGroupeChamps, typeof(int));
            dt.Columns.Add(c_champIdCaracteristique, typeof(string));

            return dt;
        }
    }
}
