using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.data.dynamic.NommageEntite;
using sc2i.expression;
using sc2i.formulaire;
using sc2i.process.workflow;
using sc2i.process.workflow.blocs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timos.data.Aspectize
{
    public class CTodoTimosWebApp : IEntiteTimosWebApp
    {
        public const string c_nomTable = "TIMOS_TODOS";

        public const string c_champId = "TimosId";
        public const string c_champDateDebut = "StartDate";
        public const string c_champLibelle = "Label";
        public const string c_champInstructions = "Instructions";
        public const string c_champTypeElementEdite = "ElementType";
        public const string c_champIdElementEdite = "ElementId";
        public const string c_champElementDescription = "ElementDescription";
        public const string c_champEtatTodo = "EtatTodo";
        public const string c_champDateFin = "EndDate";
        public const string c_champDureeStandard = "DureeStandard";

        DataRow m_row = null;
        IObjetDonneeAChamps m_objetEdite;
        IObjetDonneeAChamps m_objetEditeSecondaire;
        CEtapeWorkflow m_etape;

        public CTodoTimosWebApp(DataSet ds, CEtapeWorkflow etape)
        {
            m_etape = etape;
            DataTable dt = ds.Tables[c_nomTable];
            if(dt != null)
            {
                DataRow row = dt.NewRow();

                string strInstrcution = GetInstructionsForTodo(etape);
                string strTypeElementEdite = "";
                int nIdElementEdite = -1;
                string strElementDescription = "";
                int nEtatTodo = etape.EtatCode;
                CResultAErreur resObjet = GetElementEditePrincipal(etape);
                CObjetDonneeAIdNumerique objEdite = resObjet.Data as CObjetDonneeAIdNumerique;
                if (objEdite != null)
                {
                    m_objetEdite = objEdite as IObjetDonneeAChamps;
                    strTypeElementEdite = objEdite.TypeString;
                    nIdElementEdite = objEdite.Id;
                    strElementDescription = objEdite.DescriptionElement;
                }
                resObjet = GetElementEditeSecondaire(etape);
                objEdite = resObjet.Data as CObjetDonneeAIdNumerique;
                if (objEdite != null)
                {
                    m_objetEditeSecondaire = objEdite as IObjetDonneeAChamps;
                }

                    row[c_champId] = etape.Id;
                row[c_champDateDebut] = etape.DateDebut.Value;
                row[c_champLibelle] = etape.Libelle;
                row[c_champInstructions] = strInstrcution;
                row[c_champTypeElementEdite] = strTypeElementEdite;
                row[c_champIdElementEdite] = nIdElementEdite;
                row[c_champElementDescription] = strElementDescription;
                row[c_champEtatTodo] = nEtatTodo;
                row[c_champDureeStandard] = DureeStandardTodo;
                if (etape.DateFin == null)
                    row[c_champDateFin] = DBNull.Value;
                else
                    row[c_champDateFin] = etape.DateFin.Value;


                m_row = row;
                dt.Rows.Add(row);
            }
        }

        //---------------------------------------------------------------------------------------------------------
        public DataRow Row
        {
            get
            {
                return m_row;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        public IObjetDonneeAChamps ObjetEditePrincipal
        {
            get
            {
                return m_objetEdite;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        public IObjetDonneeAChamps ObjetEditeSecondaire
        {
            get
            {
                return m_objetEditeSecondaire;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        public int DureeStandardTodo
        {
            get
            {
                try
                {
                    int nIdChampDureeStandard = CTimosWebAppRegistre.IdChampDureeStandardTodo;

                    if (nIdChampDureeStandard > 0)
                    {
                        var valeurChamp = m_etape.TypeEtape.GetValeurChamp(nIdChampDureeStandard);
                        if (valeurChamp is int)
                            return (int)valeurChamp;
                    }
                }
                catch
                { }

                return 0;
            }
        }

        //---------------------------------------------------------------------------------------------------------
        private string GetInstructionsForTodo(CEtapeWorkflow etapeEnCours)
        {
            string strResult = "Pas d'instructions";

            if (etapeEnCours != null)
            {
                CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                if (blocFormulaire == null)
                {
                    strResult = "Ce To do ne peut pas être traité dans l'application web Timos";
                    return strResult;
                }
                if (blocFormulaire.FormuleInstructions != null)
                {
                    C2iExpression expInstructions = blocFormulaire.FormuleInstructions;
                    CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                    CResultAErreur resEval = expInstructions.Eval(ctxEval);
                    if (resEval && resEval.Data != null)
                    {
                        strResult = resEval.Data.ToString();
                    }
                    else
                    {
                        strResult = etapeEnCours.Libelle + Environment.NewLine + resEval.Erreur.ToString();
                    }
                }
            }

            return strResult;
        }

        //---------------------------------------------------------------------------------------------------------
        private CResultAErreur GetElementEditePrincipal(CEtapeWorkflow etapeEnCours)
        {
            CResultAErreur result = CResultAErreur.True;

            if (etapeEnCours != null)
            {
                CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                if (blocFormulaire == null)
                {
                    result.EmpileErreur("Ce To do ne peut pas être traité dans l'application web Timos");
                    return result;
                }
                if (blocFormulaire.FormuleElementEditePrincipal != null)
                {
                    C2iExpression expElementEditePrincipal = blocFormulaire.FormuleElementEditePrincipal;
                    CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                    result = expElementEditePrincipal.Eval(ctxEval);
                    if (!result)
                        result.EmpileErreur("Erreur dans l'évaluation de l'élément édité principal du to do " + etapeEnCours.Id);
                }
            }

            return result;
        }

        //---------------------------------------------------------------------------------------------------------
        private CResultAErreur GetElementEditeSecondaire(CEtapeWorkflow etapeEnCours)
        {
            CResultAErreur result = CResultAErreur.True;

            if (etapeEnCours != null)
            {
                CBlocWorkflowFormulaire blocFormulaire = etapeEnCours.TypeEtape != null ? etapeEnCours.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
                if (blocFormulaire == null)
                {
                    result.EmpileErreur("Ce To do ne peut pas être traité dans l'application web Timos");
                    return result;
                }
                if (blocFormulaire.FormuleElementEditeSecondaire != null)
                {
                    C2iExpression expElementEditePrincipal = blocFormulaire.FormuleElementEditeSecondaire;
                    CContexteEvaluationExpression ctxEval = new CContexteEvaluationExpression(etapeEnCours);
                    result = expElementEditePrincipal.Eval(ctxEval);
                    if (!result)
                        result.EmpileErreur("Erreur dans l'évaluation de l'élément édité principal du to do " + etapeEnCours.Id);
                }
            }

            return result;
        }


        //------------------------------------------------------------------------------------------------
        private CCaracteristiqueEntite[] GetDocumentsAttendus()
        {
            if (m_objetEdite == null)
                return null;

            CObjetDonneeAIdNumerique objet = m_objetEdite as CObjetDonneeAIdNumerique;
            if (objet != null)
            {
                string strIdsDocumentsAttendus = CTimosWebAppRegistre.IdsTypesCaracteristiquesDocumentsAttendus;
            
                CFiltreData filtre;
                if (strIdsDocumentsAttendus.Length == 0)
                    filtre = new CFiltreDataImpossible();
                else
                {
                    filtre = new CFiltreData(CCaracteristiqueEntite.c_champTypeElement + "=@1 and " +
                       CCaracteristiqueEntite.c_champIdElementLie + "=@2 and " + CTypeCaracteristiqueEntite.c_champId + " IN (" + strIdsDocumentsAttendus + ")",
                        objet.GetType().ToString(),
                        objet.Id);
                }
                CListeObjetsDonnees lst = new CListeObjetsDonnees(objet.ContexteDonnee, typeof(CCaracteristiqueEntite), filtre);
                int combien = lst.Count;
                return lst.ToArray<CCaracteristiqueEntite>();
            }

            return null;
        }


        //------------------------------------------------------------------------------------------------
        public CResultAErreur FillDataSet(DataSet ds)
        {
            CResultAErreur result = CResultAErreur.True;

            CBlocWorkflowFormulaire blocFormulaire = m_etape.TypeEtape != null ? m_etape.TypeEtape.Bloc as CBlocWorkflowFormulaire : null;
            if (blocFormulaire == null)
            {
                result.EmpileErreur("Erreur GetTodoDetails : Ce To do n'a pas de formulaire associé dans Timos");
                return result;
            }

            // Traite la liste des formulaires associés pour trouver les champs customs
            foreach (CDbKey keyForm in blocFormulaire.ListeDbKeysFormulaires)
            {
                CFormulaire formulaire = new CFormulaire(m_etape.ContexteDonnee);
                if (formulaire.ReadIfExists(keyForm))
                {
                    CGroupeChamps groupe = new CGroupeChamps(ds, formulaire, this, false);
                    result = groupe.FillDataSet(ds);
                }
            }
            // Formulaire d'informations secondaires
            CDbKey keyFormSecondaire = blocFormulaire.DbKeyFormulaireSecondaire;
            if(keyFormSecondaire != null)
            {
                CFormulaire formulaireSecondaire = new CFormulaire(m_etape.ContexteDonnee);
                if (formulaireSecondaire.ReadIfExists(keyFormSecondaire))
                {
                    CGroupeChamps groupe = new CGroupeChamps(ds, formulaireSecondaire, this, true);
                    result = groupe.FillDataSet(ds);
                }
            }

            // Gestion des documents attendus
            CCaracteristiqueEntite[] liste = GetDocumentsAttendus();
            foreach (CCaracteristiqueEntite caracDoc in liste)
            {
                CDocumentAttendu doc = new CDocumentAttendu(ds, caracDoc);
                result = doc.FillDataSet(ds);
            }

            return result;
        }

        //------------------------------------------------------------------------------------------------
        public static DataTable GetStructureTable()
        {
            DataTable dt = new DataTable(c_nomTable);

            dt.Columns.Add(c_champId, typeof(int));
            dt.Columns.Add(c_champDateDebut, typeof(DateTime));
            dt.Columns.Add(c_champLibelle, typeof(string));
            dt.Columns.Add(c_champInstructions, typeof(string));
            dt.Columns.Add(c_champTypeElementEdite, typeof(string));
            dt.Columns.Add(c_champIdElementEdite, typeof(int));
            dt.Columns.Add(c_champElementDescription, typeof(string));
            dt.Columns.Add(c_champEtatTodo, typeof(int));
            dt.Columns.Add(c_champDateFin, typeof(DateTime));
            dt.Columns.Add(c_champDureeStandard, typeof(int));

            return dt;
        }


    }
}
