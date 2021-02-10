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
        public const string c_champCanAddCaracteristiques = "CanAddCaracteristiques";

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
            row[c_champCanAddCaracteristiques] = false;

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
            return FillDataSet(ds, m_formulaire.Formulaire, m_todo.ObjetEditePrincipal, null);
        }


        public CResultAErreur FillDataSet(DataSet ds, C2iWnd fenetre, IObjetDonneeAChamps objetEdite, CListeRestrictionsUtilisateurSurType lstRestrictions)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_formulaire == null)
            {
                result.EmpileErreur("m_formulaire is null");
                return result;
            }
            if (fenetre != null)
            {
                try
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
                                // Traite la visibilité du champ
                                CContexteEvaluationExpression ctx = new CContexteEvaluationExpression(objetEdite);
                                C2iExpression expVisible = wndChamp.Visiblity;
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
                                CRestrictionUtilisateurSurType restrictionSurObjetEdite = lstRestrictions.GetRestriction(objetEdite.GetType());
                                if (restrictionSurObjetEdite != null)
                                {
                                    ERestriction rest = restrictionSurObjetEdite.GetRestriction(cc.CleRestriction);
                                    if ((rest & ERestriction.ReadOnly) == ERestriction.ReadOnly)
                                        bIsEditable = false;
                                }
                                CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, wndChamp, objetEdite, m_formulaire.Id, "-1", bIsEditable);
                                result = champWeb.FillDataSet(ds);
                                CTodoValeurChamp valeur = new CTodoValeurChamp(ds, objetEdite, wndChamp, m_formulaire.Id);
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
                                            bConserverCeGroupe = true;
                                            FillDataSet(ds, frm, sousObjetEdite, lstRestrictions);
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
                            m_row[c_champCanAddCaracteristiques] = childZone.HasAddButton;

                            if (childZone.SourceFormula != null)
                            {
                                CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(objetEdite);
                                C2iExpression source = childZone.SourceFormula;
                                Type tp = source.TypeDonnee.TypeDotNetNatif;
                                CResultAErreur resEval = source.Eval(ctxEval);
                                if (!resEval)
                                {
                                    result += resEval;
                                    return result;
                                }
                                object datas = resEval.Data;
                                if (datas != null)
                                {
                                    bConserverCeGroupe = true;

                                    IEnumerable collection = datas as IEnumerable;
                                    if (collection != null)
                                    {
                                        // La source de données est une collection, il s'agit certainement de caractéristiques
                                        // Mais c'est peut-être aussi un Workbook, un Site, un Projet... on ne sait pas car ça dépend du paramétrage
                                        int nOrdre = 0;
                                        foreach (var data in collection)
                                        {
                                            IObjetDonneeAChamps objEdite = data as IObjetDonneeAChamps;
                                            if (objEdite != null)
                                            {
                                                CCaracteristique caracWeb = new CCaracteristique(
                                                    ds,
                                                    objEdite as IObjetDonneeAIdNumeriqueAuto,
                                                    tp,
                                                    objetEdite.GetType().ToString(),
                                                    ((IObjetDonneeAIdNumeriqueAuto)objetEdite).Id,
                                                    nOrdre++,
                                                    m_formulaire.Id,
                                                    false);
                                                caracWeb.FillDataSet(ds, sousFenetre, objEdite, lstRestrictions);
                                            }
                                        }
                                        // Création d'un template
                                        if (childZone.Affectations.Count > 0)
                                        {
                                            CAffectationsProprietes affectation = childZone.Affectations[0];
                                            if (tp != null && affectation != null)
                                            {
                                                IAllocateurSupprimeurElements allocateur = objetEdite as IAllocateurSupprimeurElements;
                                                object newObj = null;
                                                try
                                                {
                                                    if (allocateur != null)
                                                    {
                                                        result = allocateur.AlloueElement(tp);
                                                        if (result)
                                                            newObj = result.Data;
                                                    }
                                                    else
                                                        newObj = Activator.CreateInstance(tp);
                                                }
                                                catch (Exception ex)
                                                {
                                                    result.EmpileErreur(new CErreurException(ex));
                                                }
                                                if (newObj == null | !result)
                                                {
                                                    result.EmpileErreur(I.T("Error while allocating element|20003"));
                                                }
                                                result = affectation.AffecteProprietes(newObj, objetEdite, new CFournisseurPropDynStd(true));
                                                if (!result)
                                                {
                                                    result.EmpileErreur(I.T("Some values cannot be assigned|20004"));
                                                }
                                                CCaracteristique caracTemplate = new CCaracteristique(
                                                    ds,
                                                    newObj as IObjetDonneeAIdNumeriqueAuto,
                                                    tp,
                                                    objetEdite.GetType().ToString(),
                                                    ((IObjetDonneeAIdNumeriqueAuto)objetEdite).Id,
                                                    nOrdre++,
                                                    m_formulaire.Id,
                                                    true);
                                                caracTemplate.FillDataSet(ds, sousFenetre, newObj as IObjetDonneeAChamps, lstRestrictions);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        // La source de donnée est un objet unique
                                        IObjetDonneeAChamps objEdite = datas as IObjetDonneeAChamps;
                                        if (objEdite != null)
                                        {
                                            FillDataSet(ds, sousFenetre, objEdite, lstRestrictions);
                                        }
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
                catch (Exception ex)
                {
                    result.EmpileErreur(ex.Message);
                    return result;
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
            dt.Columns.Add(c_champCanAddCaracteristiques, typeof(bool));

            return dt;
        }
    }
}
