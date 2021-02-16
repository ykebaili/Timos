using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sc2i.common;
using sc2i.data.dynamic;
using sc2i.formulaire;
using System.Collections;
using sc2i.expression;
using sc2i.data;
using sc2i.workflow;
using sc2i.formulaire.web;

namespace timos.data.Aspectize
{
    public class CCaracteristique : IEntiteTimosWebApp
    {
        public const string c_nomTable = "Caracteristiques";

        public const string c_champId = "Id"; // Identifiant unique composé du Type + Id
        public const string c_champTimosId = "TimosId";
        public const string c_champElementType = "ElementType"; // Ce n'est par forcément une Caractéristique, donc il faut le type d'objet Timos
        public const string c_champTitre = "Titre";
        public const string c_champOrdreAffichage = "OrdreAffichage";
        public const string c_champExpand = "Expand";
        public const string c_champIdGroupeChamps = "IdGroupeChamps";
        public const string c_champIsTemplate = "IsTemplate";
        public const string c_champIdMetaType = "IdMetaType";
        public const string c_champParentElementType = "ParentElementType";
        public const string c_champParentElementId = "ParentElementId";

        DataRow m_row;
        IObjetDonneeAIdNumeriqueAuto m_objetEdite;
        static int s_nIdNegatif = -1; // Utile pour les carac template vides

        public CCaracteristique(DataSet ds, IObjetDonneeAIdNumeriqueAuto objetEdite, Type typeObjetEdite, string strParentElementType, int nParentElementId, int nOrdre, int nIdGroupe, bool isTemplate)
        {
            m_objetEdite = objetEdite; // Cela peut être une caractéristique, mais pas frocément
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();

            string strId = "";
            string strLibelle = "Nouvel élément";
            int nTimosId = s_nIdNegatif--;
            string strTypeElement = "";
            if (typeObjetEdite != null)
                strTypeElement = typeObjetEdite.ToString();
            int nIdMetaType = -1;

            if (objetEdite != null)
            {
                if(!isTemplate)
                    nTimosId = objetEdite.Id;
                strTypeElement = objetEdite.GetType().ToString();
                int nLastPoint = strTypeElement.LastIndexOf(".");
                strId = strTypeElement.Substring(nLastPoint + 1, strTypeElement.Length - nLastPoint - 1) + nTimosId;

                strLibelle = objetEdite.DescriptionElement;

                if (objetEdite is CCaracteristiqueEntite)
                {
                    CCaracteristiqueEntite carac = objetEdite as CCaracteristiqueEntite;
                    strLibelle = carac.Libelle;
                    if (strLibelle == "")
                        strLibelle = carac.TypeCaracteristique.Libelle;
                    if (carac.TypeCaracteristique != null)
                        nIdMetaType = carac.TypeCaracteristique.Id;
                }
                else if (objetEdite is CDossierSuivi)
                {
                    CDossierSuivi workbook = objetEdite as CDossierSuivi;
                    strLibelle = workbook.Libelle;
                    if (workbook.TypeDossier != null)
                        nIdMetaType = workbook.TypeDossier.Id;
                }
                else if (objetEdite is CSite)
                {
                    CSite site = objetEdite as CSite;
                    strLibelle = site.Libelle;
                    if (site.TypeSite != null)
                        nIdMetaType = site.TypeSite.Id;
                }

            }

            row[c_champId] = strId;
            row[c_champTimosId] = nTimosId;
            row[c_champElementType] = strTypeElement;
            row[c_champTitre] = strLibelle;
            row[c_champOrdreAffichage] = nOrdre;
            row[c_champIdGroupeChamps] = nIdGroupe;
            row[c_champIsTemplate] = isTemplate;
            row[c_champIdMetaType] = nIdMetaType;
            row[c_champParentElementType] = strParentElementType;
            row[c_champParentElementId] = nParentElementId;

            m_row = row;
            dt.Rows.Add(row);

        }

        //------------------------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //------------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            return CResultAErreur.True;
        }

        //------------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds, C2iWnd fenetre, IObjetDonneeAChamps objetEdite, CListeRestrictionsUtilisateurSurType lstRestrictions)
        {
            CResultAErreur result = CResultAErreur.True;

            string strIdCarac = (string)m_row[c_champId];
            string strTypeElement = (string)m_row[c_champElementType];

            if (fenetre != null)
            {
                ArrayList lst = fenetre.AllChilds();
                foreach (object obj in lst)
                {
                    if (obj is I2iWebControl)
                    {
                        I2iWebControl webControl = (I2iWebControl)obj;
                        if (webControl.WebLabel == "")
                            continue;

                        C2iWnd wndControl = webControl as C2iWnd;
                        if (wndControl != null)
                        {
                            // Traite la visibilité du champ
                            CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetEdite);
                            C2iExpression expVisible = wndControl.Visiblity;
                            if (expVisible != null)
                            {
                                CResultAErreur resVisible = expVisible.Eval(ctx);
                                if (resVisible && resVisible.Data != null)
                                {
                                    if (resVisible.Data.ToString() == "0" || resVisible.Data.ToString().ToUpper() == "FALSE")
                                        continue;
                                }
                            }
                            // Applique les restrictions
                            bool bIsEditable = true;
                            if (wndControl is C2iWndFormule || wndControl is C2iWndPanel || wndControl is C2iWndSlidingPanel)
                            {
                                bIsEditable = false;
                            }
                            else if (wndControl is C2iWndChampCustom)
                            {
                                // Sinon on regarde les restrictions du champ
                                C2iWndChampCustom wndChamp = (C2iWndChampCustom)wndControl;
                                CChampCustom cc = wndChamp.ChampCustom;
                                CRestrictionUtilisateurSurType restrictionSurObjetEdite = lstRestrictions.GetRestriction(objetEdite.GetType());
                                if (restrictionSurObjetEdite != null)
                                {
                                    ERestriction rest = restrictionSurObjetEdite.GetRestriction(cc.CleRestriction);
                                    if ((rest & ERestriction.ReadOnly) == ERestriction.ReadOnly)
                                        bIsEditable = false;
                                }
                            }
                            CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, webControl, objetEdite, -1, strIdCarac, bIsEditable);
                            result = champWeb.FillDataSet(ds);

                            CCaracValeurChamp valeur = new CCaracValeurChamp(ds, objetEdite, champWeb, strTypeElement, strIdCarac, bIsEditable);
                            result = valeur.FillDataSet(ds);
                        }

                    }
                    // Traitement dans le cas d'un sous-formulaire
                    else if (obj is C2iWndConteneurSousFormulaire)
                    {
                        C2iWndConteneurSousFormulaire subForm = (C2iWndConteneurSousFormulaire)obj;
                        if (subForm != null && subForm.SubFormReference != null)
                        {
                            C2iWnd frm = sc2i.formulaire.subform.C2iWndProvider.GetForm(subForm.SubFormReference);
                            if (frm != null)
                            {
                                if (subForm.EditedElement != null)
                                {
                                    C2iExpression expression = subForm.EditedElement;
                                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetEdite);
                                    CResultAErreur resEval = expression.Eval(ctx);
                                    if (!resEval)
                                    {
                                        result += resEval;
                                        return result;
                                    }
                                    IObjetDonneeAChamps sousObjetEdite = resEval.Data as IObjetDonneeAChamps;
                                    if (sousObjetEdite != null)
                                    {
                                        // Traite la visibilité du champ
                                        ctx = new CContexteEvaluationExpression(sousObjetEdite);
                                        C2iExpression expVisible = subForm.Visiblity;
                                        if (expVisible != null)
                                        {
                                            CResultAErreur resVisible = expVisible.Eval(ctx);
                                            if (resVisible && resVisible.Data != null)
                                            {
                                                if (resVisible.Data.ToString() == "0" || resVisible.Data.ToString().ToUpper() == "FALSE")
                                                    continue;
                                            }
                                        }
                                        FillDataSet(ds, frm, sousObjetEdite, lstRestrictions);
                                    }
                                }
                            }
                        }
                    }//*/
                }
            }
            return result;
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(string));
            dt.Columns.Add(c_champTimosId, typeof(int));
            dt.Columns.Add(c_champElementType, typeof(string));
            dt.Columns.Add(c_champTitre, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champIdGroupeChamps, typeof(int));
            dt.Columns.Add(c_champIsTemplate, typeof(bool));
            dt.Columns.Add(c_champIdMetaType, typeof(int));
            dt.Columns.Add(c_champParentElementType, typeof(string));
            dt.Columns.Add(c_champParentElementId, typeof(int));

            return dt;
        }

    }
}
