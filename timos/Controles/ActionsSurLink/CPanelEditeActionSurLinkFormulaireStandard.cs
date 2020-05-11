using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.custom;
using sc2i.expression;
using sc2i.common;
using sc2i.win32.common;
using sc2i.data.dynamic;
using System.Collections;
using System.Reflection;
using sc2i.win32.data.navigation;
using sc2i.formulaire;
using sc2i.win32.expression;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkFormulaireStandard : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkAfficherFormulaire m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        private class CWndParametreEnEdition
        {
            private CInfoParametreDynamicForm m_infoParametre;
            private C2iExpression m_expressions;

            public CWndParametreEnEdition(CInfoParametreDynamicForm info, C2iExpression exp)
            {
                m_infoParametre = info;
                m_expressions = exp;

            }

            public CInfoParametreDynamicForm InfoParametre
            {
                get { return m_infoParametre; }
                set { m_infoParametre = value; }
            }

            public C2iExpression Expression
            {
                get { return m_expressions; }
                set { m_expressions = value; }
            }


        }

        public CPanelEditeActionSurLinkFormulaireStandard()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Standard form|157"),
                typeof(CActionSur2iLinkAfficherFormulaire),
                typeof(CPanelEditeActionSurLinkFormulaireStandard));
        }

        //----------------------------------------------------------------------------------------------------------
        public void InitChamps(CActionSur2iLink action, sc2i.expression.CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkAfficherFormulaire;
            if (m_actionEditee == null)
            {
                Visible = false;
                return;
            }
            Visible = true;
            m_objetPourSousProprietes = objetPourSousProprietes;

            m_splitContainerInfosParam.Visible = false;



            Type tp = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).TypeFormulaire;
            // Init combo Type formulaire
            m_cmbFormulaireStandard.SelectedValue = new CInfoClasseDynamique(tp, "");
            // Init Contexte du formulaire
            m_txtContexteFormulaire.Text = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).ContexteForm;
            // Init la liste des Paramètres du Formulaire
            UpdateListeParametresFormulaire(tp);

            m_wndAideFormuleParametre.FournisseurProprietes = new CFournisseurPropDynStd(true);
            m_wndAideFormuleParametre.ObjetInterroge = m_objetPourSousProprietes;
              
        }

        //----------------------------------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            if (!(m_cmbFormulaireStandard.SelectedValue is CInfoClasseDynamique))
            {
                result.EmpileErreur(I.T("Please select a standard Frorm|10010"));
                return result;
            }
            // MAJ du Type du Formulaire
            m_actionEditee.TypeFormulaire = ((CInfoClasseDynamique)m_cmbFormulaireStandard.SelectedValue).Classe;
            // MAJ du Contexte du Formulaire
            ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).ContexteForm = m_txtContexteFormulaire.Text.Trim();
            // MAJ des Parametres du Formulaire
            result = OnChangeParametreEnCoursEdition();
            if (!result)
            {
                return result;
            }

            Dictionary<string, C2iExpression> nouveauDico = new Dictionary<string, C2iExpression>();
            foreach (CWndParametreEnEdition param in m_listeParametresEnEdition)
            {
                if (param.InfoParametre != null)
                    nouveauDico.Add(param.InfoParametre.Nom, param.Expression);
            }
            ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).Parametres = nouveauDico;
            return result;
        }

        //--------------------------------------------------------------------------------
        private CResultAErreur GetFormule(CControleEditeFormule textBox)
        {
            CResultAErreur result = CResultAErreur.True;
            CContexteAnalyse2iExpression contexte = new CContexteAnalyse2iExpression(
                m_wndAideFormuleParametre.FournisseurProprietes,
                m_objetPourSousProprietes);
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(contexte);
            result = analyseur.AnalyseChaine(textBox.Text);
            return result;
        }

        //--------------------------------------------------------------------------------
        private CResultAErreur OnChangeParametreEnCoursEdition()
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_paramEnCoursEdition != null)
            {
                if (m_txtFormuleParametre.Text.Trim() != "")
                {
                    result = GetFormule(m_txtFormuleParametre);
                    if (!result)
                    {
                        return result;
                    }
                    m_paramEnCoursEdition.Expression = (C2iExpression)result.Data;
                }
                else
                    m_paramEnCoursEdition.Expression = null;

            }
            if (m_wndListeParametres.SelectedItems.Count != 1)
            {
                m_paramEnCoursEdition = null;
                m_splitContainerInfosParam.Visible = false;
                return result;
            }

            m_splitContainerInfosParam.Visible = true;
            // Initialise l'édition du paramètre sélectionné
            m_paramEnCoursEdition = (CWndParametreEnEdition)m_wndListeParametres.SelectedItems[0].Tag;
            m_lblNomParametre.Text = m_paramEnCoursEdition.InfoParametre != null ? m_paramEnCoursEdition.InfoParametre.Nom : "";
            m_lblDescriptionParametre.Text = m_paramEnCoursEdition.InfoParametre != null ? m_paramEnCoursEdition.InfoParametre.Description : "";
            C2iExpression expression = (C2iExpression)m_paramEnCoursEdition.Expression;
            m_txtFormuleParametre.Text = expression == null ? "" : expression.GetString();

            return result;
        }

        //-----------------------------------------------------------------
        // Met à jour la liste des paramètres disponibles
        private List<CWndParametreEnEdition> m_listeParametresEnEdition = new List<CWndParametreEnEdition>();
        private bool m_bListeParamsRemplie = false;
        private void UpdateListeParametresFormulaire(Type typeForm)
        {
            m_bListeParamsRemplie = false;

            m_panelParametresFormulaire.SuspendDrawing();
            m_panelParametresFormulaire.Visible = false;
            if (typeForm != null)
            {
                object[] formAttribs = typeForm.GetCustomAttributes(typeof(DynamicFormAttribute), true);
                if (formAttribs.Length > 0)
                {
                    string strNomMethodeGetInfosParametres = ((DynamicFormAttribute)formAttribs[0]).NomMethodeGetInfosParametres;
                    if (strNomMethodeGetInfosParametres != "")
                    {
                        MethodInfo infoMethode = typeForm.GetMethod(strNomMethodeGetInfosParametres);
                        if (infoMethode != null && infoMethode.IsStatic)
                        {
                            // Récupère la liste des Informations sur les pramètres nécessaire du formulaire
                            CInfoParametreDynamicForm[] infos = (CInfoParametreDynamicForm[])infoMethode.Invoke(null, null);
                            if (infos.Length > 0)
                            {
                                C2iExpression exp = null;
                                Dictionary<string, C2iExpression> dicoParamsAction = ((CActionSur2iLinkAfficherFormulaire)m_actionEditee).Parametres;
                                // Remplie la liste des paramètres en édition avec les formules à partir de l'action
                                m_listeParametresEnEdition.Clear();
                                foreach (CInfoParametreDynamicForm info in infos)
                                {
                                    if (dicoParamsAction.TryGetValue(info.Nom, out exp))
                                    {
                                        m_listeParametresEnEdition.Add(new CWndParametreEnEdition(info, exp));
                                    }
                                    else
                                        m_listeParametresEnEdition.Add(new CWndParametreEnEdition(info, null));
                                }

                                m_panelParametresFormulaire.Visible = true;
                                m_wndListeParametres.Remplir(m_listeParametresEnEdition);
                                m_bListeParamsRemplie = true;
                            }
                        }
                    }

                }

            }

            m_panelParametresFormulaire.ResumeDrawing();
        }
        
        //----------------------------------------------------------------------------------------------
        private void m_cmbFormulaireStandard_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CInfoClasseDynamique infoClasse = m_cmbFormulaireStandard.SelectedValue as CInfoClasseDynamique;
            if (infoClasse != null)
            {
                Type tpFormulaire = infoClasse.Classe;
                UpdateListeParametresFormulaire(tpFormulaire);
            }
        }

        //----------------------------------------------------------------------------------------------
        CWndParametreEnEdition m_paramEnCoursEdition = null;
        private void m_wndListeParametres_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Affiche les infos du paramètre sélectionné
            if (m_bListeParamsRemplie)
            {
                CResultAErreur result = OnChangeParametreEnCoursEdition();
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
        }

        //----------------------------------------------------------------------------------------------
        private void m_wndAideFormuleParametre_OnSendCommande(string strCommande, int nPosCurseur)
        {
            m_wndAideFormuleParametre.InsereInTextBox(m_txtFormuleParametre, nPosCurseur, strCommande );
        }

        //----------------------------------------------------------------------------------------------
        private void CPanelEditeActionSurLinkFormulaireStandard_Load(object sender, EventArgs e)
        {
            ArrayList lstForms = new ArrayList();
            //Cherche tous les formulaires connus
            foreach (Assembly ass in CGestionnaireAssemblies.GetAssemblies())
            {
                foreach (Type tp in ass.GetTypes())
                {
                    if (!tp.IsAbstract && tp.IsSubclassOf(typeof(System.Windows.Forms.Form)))
                    {
                        string strLibelle = "";
                        object[] attribs = tp.GetCustomAttributes(typeof(ObjectListeur), true);
                        if (attribs.Length > 0)
                        {
                            Type tpListe = ((ObjectListeur)attribs[0]).TypeListe;
                            strLibelle = I.T("List of @1|20862",DynamicClassAttribute.GetNomConvivial(tpListe));
                        }
                        else
                        {
                            attribs = tp.GetCustomAttributes(typeof(DynamicFormAttribute), true);
                            if (attribs.Length > 0)
                            {
                                strLibelle = ((DynamicFormAttribute)attribs[0]).Libelle;
                            }
                        }
                        if (strLibelle != "")
                        {
                            CInfoClasseDynamique info = new CInfoClasseDynamique(tp, strLibelle);
                            lstForms.Add(info);
                        }
                    }
                }
            }
            m_cmbFormulaireStandard.ProprieteAffichee = "Nom";
            m_cmbFormulaireStandard.ListDonnees = lstForms;
            m_cmbFormulaireStandard.AssureRemplissage();
            
        }
    }
}
