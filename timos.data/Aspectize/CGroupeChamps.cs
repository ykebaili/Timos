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
            CResultAErreur result = CResultAErreur.True;

            C2iWndFenetre fenetre = m_formulaire.Formulaire;
            if (fenetre != null)
            {
                ArrayList lst = fenetre.AllChilds();
                bool bConserverCeGroupe = false;
                foreach (object obj in lst)
                {
                    if (obj is C2iWndChampCustom)
                    {
                        C2iWndChampCustom fenChamp = (C2iWndChampCustom)obj;
                        CChampCustom cc = fenChamp.ChampCustom;
                        if (cc != null)
                        {
                            CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, fenChamp, m_formulaire.Id);
                            result = champWeb.FillDataSet(ds);
                            CTodoValeurChamp valeur;
                            if (m_bIsInfosSecondaires)
                                valeur = new CTodoValeurChamp(ds, m_todo.ObjetEditeSecondaire, fenChamp);
                            else
                                valeur = new CTodoValeurChamp(ds, m_todo.ObjetEditePrincipal, fenChamp);
                            result = valeur.FillDataSet(ds);
                            bConserverCeGroupe = true;
                        }
                        /*else if (obj is C2iWndZoneMultiple)
                        {
                            C2iWndZoneMultiple childZone = (C2iWndZoneMultiple)obj;
                            C2iWndSousFormulaire sousFenetre = childZone.FormulaireFils;
                            //sousFenetre.AllChilds();

                            CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                            CResultAErreur resEval = childZone.SourceFormula.Eval(ctxEval);
                            if (resEval)
                            {
                                object datas = resEval.Data;

                            }
                        }*/
                    }
                }
                if(!bConserverCeGroupe)
                {
                    DataTable dt = ds.Tables[c_nomTable];
                    if (dt != null)
                        dt.Rows.Remove(m_row);
                }

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
