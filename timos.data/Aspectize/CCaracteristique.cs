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

namespace timos.data.Aspectize
{
    public class CCaracteristique : IEntiteTimosWebApp
    {
        public const string c_nomTable = "Caracteristiques";

        public const string c_champTimosId = "TimosId";
        public const string c_champElementType = "ElementType"; // Ce n'est par forcément une Caractéristique, donc il faut le type d'objet Timos
        public const string c_champTitre = "Titre";
        public const string c_champOrdreAffichage = "OrdreAffichage";
        public const string c_champExpand = "Expand";
        public const string c_champIdGroupeChamps = "IdGroupeChamps";
        public const string c_champIsTemplate = "IsTemplate";

        DataRow m_row;
        IObjetDonneeAIdNumeriqueAuto m_objetEdite;
        static int s_nIdNegatif = -1; // Utile pour les carac template vides

        public CCaracteristique(DataSet ds, IObjetDonneeAIdNumeriqueAuto objetEdite, Type typeObjetEdite, int nOrdre, int nIdGroupe, bool isTemplate)
        {
            m_objetEdite = objetEdite; // Cela peut être une caractéristique, mais pas frocément
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();
            string strLibelle = "Nouvel élément";
            int nId = s_nIdNegatif--;
            string strTypeElement = "";
            if (typeObjetEdite != null)
                strTypeElement = typeObjetEdite.ToString();

            if (objetEdite != null)
            {
                nId = objetEdite.Id;
                strTypeElement = objetEdite.GetType().ToString();

                strLibelle = objetEdite.DescriptionElement;

                if (objetEdite is CCaracteristiqueEntite)
                {
                    CCaracteristiqueEntite carac = objetEdite as CCaracteristiqueEntite;
                    strLibelle = carac.Libelle;
                    if (strLibelle == "")
                        strLibelle = carac.TypeCaracteristique.Libelle;
                }
                else if (objetEdite is CDossierSuivi)
                {
                    CDossierSuivi workbook = objetEdite as CDossierSuivi;
                    strLibelle = workbook.Libelle;
                }
                else if (objetEdite is CSite)
                {
                    CSite site = objetEdite as CSite;
                    strLibelle = site.Libelle;
                }

            }
            row[c_champTimosId] = nId;
            row[c_champElementType] = strTypeElement;
            row[c_champTitre] = strLibelle;
            row[c_champOrdreAffichage] = nOrdre;
            row[c_champIdGroupeChamps] = nIdGroupe;
            row[c_champIsTemplate] = isTemplate;

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
        public CResultAErreur FillDataSet(DataSet ds, C2iWnd fenetre, IObjetDonneeAChamps objetEdite)
        {
            CResultAErreur result = CResultAErreur.True;

            int nIdCarac = (int)m_row[c_champTimosId];
            string strTypeElement = (string)m_row[c_champElementType];
            if (m_objetEdite != null)
                nIdCarac = m_objetEdite.Id;

            if (fenetre != null)
            {
                ArrayList lst = fenetre.AllChilds();
                foreach (object obj in lst)
                {
                    if (obj is C2iWndChampCustom)
                    {
                        C2iWndChampCustom wndChamp = (C2iWndChampCustom)obj;
                        CChampCustom cc = wndChamp.ChampCustom;
                        if (cc != null)
                        {
                            CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, wndChamp, -1, nIdCarac);
                            result = champWeb.FillDataSet(ds);
                            CCaracValeurChamp valeur = new CCaracValeurChamp(ds, objetEdite, strTypeElement, wndChamp, nIdCarac);
                            result = valeur.FillDataSet(ds);
                        }

                    }
                    /*/ Traitement dans le cas d'un sous-formulaire
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
                                    IObjetDonneeAChamps objEdite = resEval.Data as IObjetDonneeAChamps;
                                    if (objEdite != null)
                                    {
                                        FillDataSet(ds, frm, objEdite);
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

            dt.Columns.Add(c_champTimosId, typeof(int));
            dt.Columns.Add(c_champElementType, typeof(string));
            dt.Columns.Add(c_champTitre, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champIdGroupeChamps, typeof(int));
            dt.Columns.Add(c_champIsTemplate, typeof(bool));

            return dt;
        }

    }
}
