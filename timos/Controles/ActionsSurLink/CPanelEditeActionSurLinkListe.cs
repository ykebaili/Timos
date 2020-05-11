using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.common;
using sc2i.custom;
using sc2i.expression;
using sc2i.data.dynamic;
using sc2i.formulaire;
using sc2i.data;
using sc2i.formulaire.win32;
using sc2i.win32.expression;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkListe : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkAfficherListe m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;
        private CControleEditeFormule m_txtFormule = null;
        private CFiltreDynamique m_filtreEdite = null;

        //----------------------------------------------------------------------------
        public CPanelEditeActionSurLinkListe()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Display entity list|155"),
                typeof(CActionSur2iLinkAfficherListe),
                typeof(CPanelEditeActionSurLinkListe));
        }


        //----------------------------------------------------------------------------
        public void InitChamps(CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkAfficherListe;
            if (action == null)
            {
                Visible = false;
                return;
            }
            m_objetPourSousProprietes = objetPourSousProprietes;
            Visible = true;

            if (m_filtreEdite == null)
            {
                m_filtreEdite = m_actionEditee.Filtre;
                if (m_filtreEdite == null)
                    m_filtreEdite = new CFiltreDynamique();
                m_filtreEdite = (CFiltreDynamique)m_filtreEdite.Clone();
                if (m_objetPourSousProprietes != null)
                    CActionSur2iLinkAfficherListe.AssureVariableElementCible(m_filtreEdite, m_objetPourSousProprietes);
                m_panelEditFiltre.Init(m_filtreEdite);
                m_panelEditFiltre.MasquerFormulaire(true);
                m_wndAide.FournisseurProprietes = new CFournisseurPropDynStd(true);
                m_wndAide.ObjetInterroge = m_objetPourSousProprietes;

                m_txtContexteListe.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
                m_txtTitreListe.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);
                if (m_actionEditee.FormuleContexte != null)
                    m_txtContexteListe.Text = m_actionEditee.FormuleContexte.GetString();
                else
                    m_txtContexteListe.Text = "";
                if (m_actionEditee.FormuleTitre != null)
                    m_txtTitreListe.Text = m_actionEditee.FormuleTitre.GetString();
                else
                    m_txtTitreListe.Text = "";
                m_rbtnActionDetailEditElement.Checked = m_actionEditee.ActionSurDetail == null;
                m_rbtnActionDetailSpecifique.Checked = !m_rbtnActionDetailEditElement.Checked;
                m_chkListeAvecAjouter.Checked = m_actionEditee.ShowBoutonAjouter;
                m_chkListeAvecDetail.Checked = m_actionEditee.ShowBoutonDetail;
                m_chkListeAvecRemove.Checked = m_actionEditee.ShowBoutonSupprimer;
                m_imgFiltreSpecifiqueOnList.Visible = m_actionEditee.IdFiltreDynamiqueAUtiliser >= 0;
                m_lnkOptionsFiltre.Visible = m_actionEditee.IdFiltreDynamiqueAUtiliser >= 0;
            }
        }

        //----------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_actionEditee.Filtre = m_panelEditFiltre.FiltreDynamique;
            CAnalyseurSyntaxiqueExpression analyseur = new CAnalyseurSyntaxiqueExpression(
                new CContexteAnalyse2iExpression(new CFournisseurPropDynStd(), m_objetPourSousProprietes));
            if (m_txtContexteListe.Text.Trim() != "")
            {
                result = analyseur.AnalyseChaine(m_txtContexteListe.Text);
                if (result)
                    m_actionEditee.FormuleContexte = (C2iExpression)result.Data;
                else
                {
                    result.EmpileErreur(I.T("Error in context formula|20860"));
                }
            }
            else
                m_actionEditee.FormuleContexte = null;
            if (result)
            {
                if (m_txtTitreListe.Text.Trim() != "")
                {
                    result = analyseur.AnalyseChaine(m_txtTitreListe.Text);
                    if (result)
                        m_actionEditee.FormuleTitre = (C2iExpression)result.Data;
                    else
                        result.EmpileErreur(I.T("Error in title formula|20861"));
                }
            }
            else
                m_actionEditee.FormuleTitre = null;
            if (!result)
            {
                return result;
            }
            if (m_rbtnActionDetailEditElement.Checked)
                m_actionEditee.ActionSurDetail = null;
            m_actionEditee.ShowBoutonSupprimer = m_chkListeAvecRemove.Checked;
            m_actionEditee.ShowBoutonDetail = m_chkListeAvecDetail.Checked;
            m_actionEditee.ShowBoutonAjouter = m_chkListeAvecAjouter.Checked;
            return result;
        }

        //----------------------------------------------------------------------------
        private void m_lnkAffectations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CActionSur2iLinkAfficherListe actionLst = m_actionEditee as CActionSur2iLinkAfficherListe;
            if (actionLst != null && m_panelEditFiltre.FiltreDynamique != null)
            {
                List<CAffectationsProprietes> lstAffectations = new List<CAffectationsProprietes>();
                lstAffectations.AddRange(actionLst.Affectations);
                lstAffectations = CFormEditProprieteAffectationsProprietes.EditeLesAffectations(lstAffectations,
                    m_objetPourSousProprietes != null ? m_objetPourSousProprietes.TypeAnalyse : null,
                    m_panelEditFiltre.FiltreDynamique.TypeElements,
                    new CFournisseurPropDynStd());
                actionLst.Affectations = lstAffectations;
            }
        }

        //----------------------------------------------------------------------------
        private void m_lnkFiltreSpecifique_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_actionEditee != null && m_actionEditee.Filtre != null && m_actionEditee.Filtre.TypeElements != null)
            {
                ContextMenuStrip menuFiltre = new ContextMenuStrip();
                CListeObjetDonneeGenerique<CFiltreDynamiqueInDb> lstFiltres = new CListeObjetDonneeGenerique<CFiltreDynamiqueInDb>(CContexteDonneeSysteme.GetInstance());
                lstFiltres.Filtre = new CFiltreData(CFiltreDynamiqueInDb.c_champTypeElements + "=@1",
                    m_actionEditee.Filtre.TypeElements.ToString());
                ToolStripMenuItem itemFiltreSpecifique = new ToolStripMenuItem(I.T("No specific filter|20827"));
                itemFiltreSpecifique.Tag = -1;
                itemFiltreSpecifique.Click += new EventHandler(itemFiltreSpecifique_Click);
                menuFiltre.Items.Add(itemFiltreSpecifique);
                itemFiltreSpecifique.Checked = m_actionEditee.IdFiltreDynamiqueAUtiliser == -1;
                foreach (CFiltreDynamiqueInDb filtre in lstFiltres)
                {
                    itemFiltreSpecifique = new ToolStripMenuItem(filtre.Libelle);
                    itemFiltreSpecifique.Tag = filtre.Id;
                    itemFiltreSpecifique.Checked = m_actionEditee.IdFiltreDynamiqueAUtiliser == filtre.Id;
                    itemFiltreSpecifique.Click += new EventHandler(itemFiltreSpecifique_Click);
                    menuFiltre.Items.Add(itemFiltreSpecifique);
                }
                menuFiltre.Show(m_lnkFiltreSpecifique, new Point(0, m_lnkFiltreSpecifique.Height));
            }
        }

        //------------------------------------------------------------------
        void itemFiltreSpecifique_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null && item.Tag is int)
            {
                if (m_actionEditee != null)
                {
                    m_actionEditee.IdFiltreDynamiqueAUtiliser = (int)item.Tag;
                    m_imgFiltreSpecifiqueOnList.Visible = ((int)item.Tag) >= 0;
                    m_lnkOptionsFiltre.Visible = m_imgFiltreSpecifiqueOnList.Visible;
                }
            }
        }

        //----------------------------------------------------------------------------
        private void m_lnkOptionsFiltre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_actionEditee != null)
            {
                CFiltreDynamiqueInDb filtre = new CFiltreDynamiqueInDb(CContexteDonneeSysteme.GetInstance());
                if (filtre.ReadIfExists(m_actionEditee.IdFiltreDynamiqueAUtiliser))
                {
                    CFiltreDynamique filtreDyn = filtre.Filtre;
                    if (filtreDyn != null)
                    {
                        List<CFormuleNommee> lst = new List<CFormuleNommee>();
                        foreach (IVariableDynamique variable in filtreDyn.ListeVariables)
                        {
                            CFormuleNommee formule = new CFormuleNommee(variable.Nom, null);
                            formule.Id = variable.IdVariable;
                            foreach (CFormuleNommee formuleEx in m_actionEditee.ValeursVariablesFiltre)
                            {
                                if (formuleEx.Id == variable.IdVariable)
                                    formule.Formule = formuleEx.Formule;
                            }
                            lst.Add(formule);
                        }
                        CFormuleNommee[] formules = lst.ToArray();
                        if (CFormEditeListeFormulesNommees.EditeFormules(ref formules, m_objetPourSousProprietes))
                        {
                            lst = new List<CFormuleNommee>();
                            foreach (CFormuleNommee formule in formules)
                            {
                                if (formule.Formule != null)
                                    lst.Add(formule);
                            }
                            m_actionEditee.ValeursVariablesFiltre = lst.ToArray();
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------
        private void m_rbtnActionDetailEditElement_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuelListeDetailAction();
        }

        //----------------------------------------------------------------------------
        private void m_rbtnActionDetailSpecifique_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuelListeDetailAction();
        }

        //----------------------------------------------------------------------------
        private void UpdateVisuelListeDetailAction()
        {
            m_lnkEditActionDetailSpecifique.Visible = m_rbtnActionDetailSpecifique.Checked;
        }

        //----------------------------------------------------------------------------
        private void m_lnkEditActionDetailSpecifique_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (m_actionEditee != null && m_actionEditee.Filtre != null && m_actionEditee.Filtre.TypeElements != null)
            {
                CActionSur2iLink actionSpec = m_actionEditee.ActionSurDetail;
                actionSpec = CFormEditActionSurLink.EditeAction(actionSpec, m_actionEditee.Filtre.TypeElements);
                if (actionSpec != null)
                    m_actionEditee.ActionSurDetail = actionSpec;
            }
        }

        private void m_txtTitreListe_Enter(object sender, EventArgs e)
        {
            this.SetTexteFormule((sc2i.win32.expression.CControleEditeFormule)sender);
        }

        private void m_wndAide_OnSendCommande(string strCommande, int nPosCurseur)
        {
            if (m_txtFormule != null)
                m_wndAide.InsereInTextBox(m_txtFormule, nPosCurseur, strCommande);
        }

        /// ///////////////////////////////////////////////////////
        private void SetTexteFormule(sc2i.win32.expression.CControleEditeFormule txt)
        {
            if (m_txtFormule != null)
                m_txtFormule.BackColor = Color.White;
            m_txtFormule = txt;
            m_txtFormule.BackColor = Color.LightGreen;
        }

    }
}
