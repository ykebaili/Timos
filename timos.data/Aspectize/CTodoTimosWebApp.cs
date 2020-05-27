﻿using sc2i.common;
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

        public const string c_champId = "TODO_ID";
        public const string c_champDateDebut = "TODO_START_DATE";
        public const string c_champLibelle = "TODO_LABEL";
        public const string c_champInstructions = "TODO_INSTRUCTIONS";
        public const string c_champTypeElementEdite = "TODO_ELEMENT_TYPE";
        public const string c_champIdElementEdite = "TODO_ELEMENT_ID";
        public const string c_champElementDescription = "TODO_ELEMENT_DESCRIPTION";

        DataRow m_row = null;
        IObjetDonneeAChamps m_objetEdite;
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
                CResultAErreur resObjet = GetElementEditePrincipal(etape);
                CObjetDonneeAIdNumerique objEdite = resObjet.Data as CObjetDonneeAIdNumerique;
                if (objEdite != null)
                {
                    m_objetEdite = objEdite as IObjetDonneeAChamps;
                    strTypeElementEdite = objEdite.TypeString;
                    nIdElementEdite = objEdite.Id;
                    strElementDescription = objEdite.DescriptionElement;
                }

                row[c_champId] = etape.Id;
                row[c_champDateDebut] = etape.DateDebut.Value;
                row[c_champLibelle] = etape.Libelle;
                row[c_champInstructions] = strInstrcution;
                row[c_champTypeElementEdite] = strTypeElementEdite;
                row[c_champIdElementEdite] = nIdElementEdite;
                row[c_champElementDescription] = strElementDescription;

                m_row = row;
                dt.Rows.Add(row);
            }
        }

        public CTodoTimosWebApp(CEtapeWorkflow etape, DataRow row)
        {
            string strInstrcution = GetInstructionsForTodo(etape);
            string strTypeElementEdite = "";
            int nIdElementEdite = -1;
            string strElementDescription = "";
            CResultAErreur resObjet = GetElementEditePrincipal(etape);
            CObjetDonneeAIdNumerique objEdite = resObjet.Data as CObjetDonneeAIdNumerique;
            if (objEdite != null)
            {
                m_objetEdite = objEdite as IObjetDonneeAChamps;
                strTypeElementEdite = objEdite.TypeString;
                nIdElementEdite = objEdite.Id;
                strElementDescription = objEdite.DescriptionElement;
            }

            row[c_champId] = etape.Id;
            row[c_champDateDebut] = etape.DateDebut.Value;
            row[c_champLibelle] = etape.Libelle;
            row[c_champInstructions] = strInstrcution;
            row[c_champTypeElementEdite] = strTypeElementEdite;
            row[c_champIdElementEdite] = nIdElementEdite;
            row[c_champElementDescription]=strElementDescription;

            m_row = row;
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

        //------------------------------------------------------------------------------------------------
        public CCaracteristiqueEntite[] GetDocumentsAttendus()
        {
            DataTable dtDocumentsAttendus = CDocumentAttendu.GetStructureTable();

            if (m_objetEdite == null)
                return null;

            CObjetDonneeAIdNumerique objet = m_objetEdite as CObjetDonneeAIdNumerique;
            if (objet != null)
            {

                CListeObjetDonneeGenerique<CNommageEntite> listeNomsForts = new CListeObjetDonneeGenerique<CNommageEntite>(objet.ContexteDonnee);
                listeNomsForts.Filtre = new CFiltreData(
                    CNommageEntite.c_champTypeEntite + " = @1 AND " + CNommageEntite.c_champNomFort + " LIKE @2",
                    typeof(CTypeCaracteristiqueEntite).ToString(),
                    CDocumentAttendu.c_nomFortTypeCaracteristiqueDocument+"%");

                string strIDs = "";
                foreach (CNommageEntite nom in listeNomsForts)
                {
                    if (strIDs != "")
                        strIDs += ",";
                    strIDs += nom.GetObjetNomme().Id.ToString();
                }

                CFiltreData filtre;
                if (strIDs.Length == 0)
                    filtre = new CFiltreDataImpossible();
                else
                {
                    filtre = new CFiltreData(CCaracteristiqueEntite.c_champTypeElement + "=@1 and " +
                       CCaracteristiqueEntite.c_champIdElementLie + "=@2 and " + CTypeCaracteristiqueEntite.c_champId + " IN (" + strIDs + ")",
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
                    string strLibelleFormulaire = formulaire.Libelle;

                    C2iWnd fenetre = formulaire.Formulaire;
                    if (fenetre != null)
                    {
                        ArrayList lst = fenetre.AllChilds();
                        foreach (object obj in lst)
                        {
                            if (obj is C2iWndChampCustom)
                            {
                                C2iWndChampCustom fenChamp = (C2iWndChampCustom)obj;
                                CChampCustom cc = fenChamp.ChampCustom;
                                if (cc != null)
                                {
                                    CChampTimosWebApp champWeb = new CChampTimosWebApp(ds, fenChamp);
                                    result = champWeb.FillDataSet(ds);

                                    CTodoValeurChamp valeur = new CTodoValeurChamp(ds, ObjetEditePrincipal, fenChamp);
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
                    }
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

            return dt;
        }


    }
}
