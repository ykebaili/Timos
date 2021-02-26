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
using sc2i.formulaire.web;
using sc2i.formulaire;

namespace timos.data.Aspectize
{
    public class CChampTimosWebApp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "TIMOS_FIELDS";

        public const string c_champId = "FIELD_ID"; // Id unique pour l'appli web
        public const string c_champIdTimos = "TIMOS_FIELD_ID"; // Id Timos réel
        public const string c_champNom = "TIMOS_FIELD_NAME";
        public const string c_champLibelleConvivial = "TIMOS_FIELD_WEB_LABEL";
        public const string c_champOrdreAffichage = "TIMOS_FIELD_DISP_ORDER";
        public const string c_champTypeDonne = "TIMOS_FIELD_DATA_TYPE";
        public const string c_champIsChoixParmis = "TIMOS_FIELD_IS_SELECT";
        public const string c_champIsMultiline = "TIMOS_FIELD_IS_MULTILINE";
        public const string c_champIsEditable = "TIMOS_FIELD_IS_EDITABLE";
        public const string c_champCustomClass = "TIMOS_FIELD_CLASS";
        public const string c_champIdGroupeChamps = "TIMOS_FIELD_ID_GROUPE";
        public const string c_champIdCaracteristique = "TIMOS_FIELD_ID_CARAC";
        public const string c_champUseAutoComplete = "UseAutoComplete";

        public const string c_champElementSource = "Source element";
        public static int s_nIdChampFictif = 900000; // Id fictif pour tous les champs en lecture seule
        private static Dictionary<string, int> s_dicWebControl = new Dictionary<string, int>();

        DataRow m_row = null;
        CChampCustom m_champ;
        C2iExpression m_formule;
        IElementAVariables m_elementAVariables = null;


        public CChampTimosWebApp(DataSet ds, I2iWebControl wndControl, IElementAVariables elementEdite, int nIdGroupe, string strIdCarac, bool bIsEditable)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;
            m_elementAVariables = elementEdite;

            DataRow row = dt.NewRow();

            string strNomChamp = wndControl.WebLabel;
            string strLibelleWeb = wndControl.WebLabel;
            int nIdChampFictif;
            if (!s_dicWebControl.TryGetValue(strLibelleWeb, out nIdChampFictif))
            {
                nIdChampFictif = s_nIdChampFictif++;
                s_dicWebControl.Add(strLibelleWeb, nIdChampFictif);
            }
            int nIdChampCustom = -1;
            int nOrdreWeb = wndControl.WebNumOrder;
            int nTypeDonneeChamp = 2; // par défaut type string
            bool bIsChoixParmis = false;
            bool bIsMultiline = false;
            string strCustomClass = "";
            
            if (wndControl is C2iWndChampCustom)
            {
                C2iWndChampCustom wndChamp = (C2iWndChampCustom)wndControl;
                bIsMultiline = wndChamp.MultiLine;
                CChampCustom champ = wndChamp.ChampCustom;
                if (champ != null)
                {
                    m_champ = champ;
                    nIdChampCustom = champ.Id;
                    strNomChamp = champ.Nom;
                    nTypeDonneeChamp = (int)champ.TypeDonneeChamp.TypeDonnee;
                    bIsChoixParmis = champ.IsChoixParmis();
                }
            }
            else if(wndControl is C2iWndFormule)
            {
                C2iWndFormule wndFormule = (C2iWndFormule)wndControl;
                C2iExpression formule = wndFormule.Formule;
                if(formule != null)
                {
                    m_formule = formule;
                    bIsEditable = false;
                }
            }
            else if(wndControl is C2iWndPanel || wndControl is C2iWndSlidingPanel)
            {
                bIsEditable = false;
                strCustomClass = "sous-titre-champ";
            }

            row[c_champId] = bIsEditable ? nIdChampCustom : nIdChampFictif;
            row[c_champIdTimos] = nIdChampCustom;
            row[c_champNom] = strNomChamp;
            row[c_champLibelleConvivial] = strLibelleWeb == "" ? strNomChamp : strLibelleWeb;
            row[c_champOrdreAffichage] = nOrdreWeb;
            row[c_champTypeDonne] = nTypeDonneeChamp;
            row[c_champIsChoixParmis] = bIsChoixParmis && bIsEditable;
            row[c_champIsMultiline] = bIsMultiline;
            row[c_champIsEditable] = bIsEditable;
            row[c_champCustomClass] = strCustomClass;
            row[c_champIdGroupeChamps] = nIdGroupe;
            row[c_champIdCaracteristique] = strIdCarac;
            row[c_champUseAutoComplete] = false;

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
        public C2iExpression Formule
        {
            get
            {
                return m_formule;
            }
        }

        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Id unique pour l'application web
        /// Il est possible qu'il soit le même que l'Id Timos si le champ est éditable
        /// </summary>
        public int Id
        {
            get
            {
                return (int)m_row[c_champId];
            }
        }

        //---------------------------------------------------------------------------------------
        /// <summary>
        /// Id réel dans la base Timos
        /// </summary>
        public int IdTimos
        {
            get
            {
                return (int)m_row[c_champIdTimos];
            }
        }

        //---------------------------------------------------------------------------------------
        public string WebLabel
        {
            get
            {
                return (string)m_row[c_champLibelleConvivial];
            }
        }

        //---------------------------------------------------------------------------------------
        public int WebNumOrder
        {
            get
            {
                return (int)m_row[c_champOrdreAffichage];
            }
        }

        //---------------------------------------------------------------------------------------
        public bool UseAutoComplete
        {
            get
            {
                return (bool)m_row[c_champUseAutoComplete];
            }
        }

        //---------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_champ == null)
                return result;

            if (!ds.Tables.Contains(CChampValeursPossibles.c_nomTable))
                return result;

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
                    if (listeObjets.CountNoLoad > 200)
                        m_row[c_champUseAutoComplete] = true;

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
            dt.Columns.Add(c_champIdTimos, typeof(int));
            dt.Columns.Add(c_champNom, typeof(string));
            dt.Columns.Add(c_champLibelleConvivial, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champTypeDonne, typeof(int));
            dt.Columns.Add(c_champIsChoixParmis, typeof(bool));
            dt.Columns.Add(c_champIsMultiline, typeof(bool));
            dt.Columns.Add(c_champIsEditable, typeof(bool));
            dt.Columns.Add(c_champCustomClass, typeof(string));
            dt.Columns.Add(c_champIdGroupeChamps, typeof(int));
            dt.Columns.Add(c_champIdCaracteristique, typeof(string));
            dt.Columns.Add(c_champUseAutoComplete, typeof(bool));

            return dt;
        }
    }
}
