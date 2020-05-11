using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.formulaire;
using sc2i.custom;
using sc2i.common;
using sc2i.expression;
using sc2i.custom;
using sc2i.data.dynamic;
using sc2i.win32.common;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CPanelEditeActionSurLinkFormulairePopup : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkFormulairePopup m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;
        
        private IControlEditeurSpecifiqueMenuItem m_controlEditeurEnCours = null;

        public CPanelEditeActionSurLinkFormulairePopup()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Popup Form|10411"),
                typeof(CActionSur2iLinkFormulairePopup),
                typeof(CPanelEditeActionSurLinkFormulairePopup));
        }


        public void InitChamps(CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkFormulairePopup;
            m_objetPourSousProprietes = objetPourSousProprietes;

            if (m_actionEditee != null)
            {
                m_txtLibelle.Text = m_actionEditee.Libelle;
                Type typeAnalyse = m_objetPourSousProprietes != null ? m_objetPourSousProprietes.TypeAnalyse : null;
                m_wndFormuleElementEdite.Init(new CFournisseurGeneriqueProprietesDynamiques(), m_objetPourSousProprietes);
                m_wndFormuleElementEdite.Formule = m_actionEditee.FormuleElementEdite;
                m_panelEditionFormulaire.Init(
                    m_actionEditee.FormuleElementEdite != null ? 
                    m_actionEditee.FormuleElementEdite.TypeDonnee.TypeDotNetNatif:
                        typeAnalyse,
                    m_actionEditee.Formulaire,
                    m_actionEditee.Formulaire,
                    new CFournisseurGeneriqueProprietesDynamiques());
                
                m_panelEditionFormulaire.LockEdition = false;
            }
        }

        //------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_actionEditee != null)
            {
                m_actionEditee.Libelle = m_txtLibelle.Text;
                m_actionEditee.FormuleElementEdite = m_wndFormuleElementEdite.Formule;
                m_actionEditee.Formulaire = (sc2i.formulaire.C2iWndFenetre)m_panelEditionFormulaire.WndEditee;
            }
           
            return result;
        }

        //------------------------------------------------------------------------------
        private void m_wndFormuleElementEdite_OnChangeTexteFormule(object sender, EventArgs e)
        {
            Type typeAnalyse = m_objetPourSousProprietes != null ? m_objetPourSousProprietes.TypeAnalyse : null;
            if (m_wndFormuleElementEdite.Formule != null)
                typeAnalyse = m_wndFormuleElementEdite.Formule.TypeDonnee.TypeDotNetNatif;
            m_panelEditionFormulaire.TypeEdite = typeAnalyse;
        }



    }
}
