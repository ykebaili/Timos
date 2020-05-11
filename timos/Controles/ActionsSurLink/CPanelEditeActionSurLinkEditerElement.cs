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
using sc2i.data.dynamic;
using sc2i.win32.expression;
using sc2i.data;
using sc2i.expression;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkEditerElement : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkAfficherEntite m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;

        //---------------------------------------------------------
        public CPanelEditeActionSurLinkEditerElement()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Display one entity|156"),
                typeof(CActionSur2iLinkAfficherEntite),
                typeof(CPanelEditeActionSurLinkEditerElement));
        }

        //---------------------------------------------------------
        public void InitChamps(sc2i.formulaire.CActionSur2iLink action, sc2i.expression.CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkAfficherEntite;
            if (m_actionEditee == null)
            {
                Visible = false;
                return;
            }
            Visible = true;
            m_objetPourSousProprietes = objetPourSousProprietes;


            m_txtFormuleEntite.Formule = m_actionEditee.FormuleElement;
            m_txtFormuleContexteEntite.Formule = m_actionEditee.FormuleContexte;
            m_txtFormuleTitreAfficheEntite.Formule = m_actionEditee.FormuleTitre;
            m_txtFormuleCodeFormulaire.Formule = m_actionEditee.FormuleCodeFormulaire;
            m_wndAideFormuleAfficherEntite.FournisseurProprietes = new CFournisseurPropDynStd(true);
            m_wndAideFormuleAfficherEntite.ObjetInterroge = m_objetPourSousProprietes;

            m_txtFormuleEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
            m_txtFormuleContexteEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
            m_txtFormuleTitreAfficheEntite.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);
            m_txtFormuleCodeFormulaire.Init(m_wndAideFormuleAfficherEntite.FournisseurProprietes, m_wndAideFormuleAfficherEntite.ObjetInterroge);

        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;
            m_actionEditee.FormuleElement = m_txtFormuleEntite.Formule;
            if (m_actionEditee.FormuleElement == null)
            {
                if (m_txtFormuleEntite.Text.Trim() == "")
                {
                    result.EmpileErreur(I.T("Entity formula must return an entity|208663"));
                }
                else
                {
                    result.Erreur += m_txtFormuleEntite.ResultAnalyse.Erreur;
                    result.EmpileErreur(I.T("Entity formula must return an entity|208663"));
                }
            }
            else if (!typeof(CObjetDonnee).IsAssignableFrom(m_actionEditee.FormuleElement.TypeDonnee.TypeDotNetNatif))
            {
                result.EmpileErreur(I.T("Entity formula must return an entity|208663"));
            }
            m_actionEditee.FormuleTitre = m_txtFormuleTitreAfficheEntite.Formule;
            m_actionEditee.FormuleContexte = m_txtFormuleContexteEntite.Formule;
            m_actionEditee.FormuleCodeFormulaire = m_txtFormuleCodeFormulaire.Formule;
            if (m_actionEditee.FormuleTitre == null && m_txtFormuleTitreAfficheEntite.Text.Trim() != "")
            {
                result.Erreur += m_txtFormuleTitreAfficheEntite.ResultAnalyse.Erreur;
                result.EmpileErreur(I.T("Error in text formula|20861"));
            }
            if (m_actionEditee.FormuleContexte == null && m_txtFormuleContexteEntite.Text.Trim() != "")
            {
                result.Erreur += m_txtFormuleContexteEntite.ResultAnalyse.Erreur;
                result.EmpileErreur(I.T("Error in context formula|20860"));
            }
            if (m_actionEditee.FormuleCodeFormulaire == null && m_txtFormuleCodeFormulaire.Text.Trim() != "")
            {
                result.Erreur += m_txtFormuleCodeFormulaire.ResultAnalyse.Erreur;
                result.EmpileErreur(I.T("Error in form code formula|20873"));
            }
            return result;
        }

        /// ///////////////////////////////////////////////////////
        private void m_txtFormule_Enter(object sender, EventArgs e)
        {
            SetTexteFormule((CControleEditeFormule)sender);
        }

        /// ///////////////////////////////////////////////////////
        private void m_wndAideFormuleAfficherEntite_OnSendCommande(string strCommande, int nPosCurseur)
        {
            m_wndAideFormuleAfficherEntite.InsereInTextBox(m_txtFormule.TextBox, nPosCurseur, strCommande);
        }

        /// ///////////////////////////////////////////////////////
        private CControleEditeFormule m_txtFormule = null;
        private void SetTexteFormule(sc2i.win32.expression.CControleEditeFormule txt)
        {
            if (m_txtFormule != null)
                m_txtFormule.BackColor = Color.White;
            m_txtFormule = txt;
            m_txtFormule.BackColor = Color.LightGreen;
        }


    }
}
