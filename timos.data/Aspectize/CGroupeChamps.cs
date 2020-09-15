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

namespace timos.data.Aspectize
{
    public class CGroupeChamps : IEntiteTimosWebApp
    {
        public const string c_nomTable = "GroupeChamps";

        public const string c_champId = "TimosId";
        public const string c_champTitre = "Titre";
        public const string c_champOrdreAffichage = "OrdreAffichage";
        public const string c_champIsInfosSecondaires = "InfosSecondaires";

        DataRow m_row;
        CFormulaire m_formulaire;
        CTodoTimosWebApp m_todo;
        bool m_bIsInfosSecondaires = false;

        public CGroupeChamps(DataSet ds, CFormulaire formulaire, CTodoTimosWebApp todo, bool bIsInfosSecondaires)
        {
            DataTable dt = ds.Tables[c_nomTable];
            if (dt == null)
                return;

            DataRow row = dt.NewRow();
            int nIdFormulaire = -1;
            string strTitreFormulaire = "";
            int nOrdreAffichage = 0;

            if (formulaire != null)
            {
                m_formulaire = formulaire;
                nIdFormulaire = formulaire.Id;
                C2iWndFenetre fenetre = formulaire.Formulaire;
                if (fenetre != null && fenetre.Text != "")
                    strTitreFormulaire = fenetre.Text;
                else
                    strTitreFormulaire = formulaire.Libelle;
                nOrdreAffichage = formulaire.NumeroOrdre;
            }
            row[c_champId] = nIdFormulaire;
            row[c_champTitre] = strTitreFormulaire;
            row[c_champOrdreAffichage] = nOrdreAffichage;
            row[c_champIsInfosSecondaires] = bIsInfosSecondaires;

            m_row = row;
            dt.Rows.Add(row);
            m_todo = todo;
            m_bIsInfosSecondaires = bIsInfosSecondaires;
        }

        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        public CResultAErreur FillDataSet(DataSet ds)
        {
            return FillDataSet(ds, m_formulaire.Formulaire, m_todo.ObjetEditePrincipal);
        }


        public CResultAErreur FillDataSet(DataSet ds, C2iWnd fenetre, IObjetDonneeAChamps objetEdite)
        {
            CResultAErreur result = CResultAErreur.True;

            if (fenetre != null)
            {
                ArrayList lst = fenetre.AllChilds();
                bool bConserverCeGroupe = false;
                foreach (object obj in lst)
                {
                    if (obj is C2iWndChampCustom)
                    {
                        C2iWndChampCustom wndChamp = (C2iWndChampCustom)obj;
                        CChampCustom cc = wndChamp.ChampCustom;
                        if (cc != null)
                        {
                            CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, wndChamp, m_formulaire.Id);
                            result = champWeb.FillDataSet(ds);
                            CTodoValeurChamp valeur;
                            valeur = new CTodoValeurChamp(ds, objetEdite, wndChamp);
                            result = valeur.FillDataSet(ds);
                            bConserverCeGroupe = true;
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
                                    CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(m_todo.ObjetEditePrincipal);
                                    CResultAErreur resEval = expression.Eval(ctx);
                                    if (!resEval)
                                    {
                                        result += resEval;
                                        return result;
                                    }
                                    IObjetDonneeAChamps objEdite = resEval.Data as IObjetDonneeAChamps;
                                    if (objEdite != null)
                                    {
                                        bConserverCeGroupe = true;
                                        FillDataSet(ds, frm, objEdite);
                                    }

                                }
                            }
                        }
                    }
                    // Traitement dans le cas d'une Child Zone
                    else if (obj is C2iWndZoneMultiple)
                    {
                        C2iWndZoneMultiple childZone = (C2iWndZoneMultiple)obj;
                        C2iWndSousFormulaire sousFenetre = childZone.FormulaireFils;
                        //sousFenetre.AllChilds();

                        CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(m_todo.ObjetEditePrincipal);
                        CResultAErreur resEval = childZone.SourceFormula.Eval(ctxEval);
                        if (!resEval)
                        {
                            result += resEval;
                            return result;
                        }
                        object datas = resEval.Data;
                        if (datas != null)
                        {
                            IEnumerable collection = datas as IEnumerable;
                            if (collection != null)
                            {
                                // La source de données est une collection, il faut traiter les Caractéristiques

                            }
                            else
                            {
                                // La source de donnée est un objet unique
                                IObjetDonneeAChamps objEdite = datas as IObjetDonneeAChamps;
                                if (objEdite != null)
                                {
                                    bConserverCeGroupe = true;
                                    FillDataSet(ds, sousFenetre, objEdite);
                                }
                            }
                        }
                    }
                }
                /*if (!bConserverCeGroupe)
                {
                    DataTable dt = ds.Tables[c_nomTable];
                    if (dt != null)
                        dt.Rows.Remove(m_row);
                }*/

            }

            return result;
        }


        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champTitre, typeof(string));
            dt.Columns.Add(c_champOrdreAffichage, typeof(int));
            dt.Columns.Add(c_champIsInfosSecondaires, typeof(bool));

            return dt;
        }
    }
}
