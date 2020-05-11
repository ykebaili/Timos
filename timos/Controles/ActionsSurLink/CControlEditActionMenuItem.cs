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
using sc2i.formulaire;

namespace timos.Controles.ActionsSurLink
{
    [AutoExec("Autoexec")]
    public partial class CControlEditActionMenuItem : UserControl, IControlEditeurSpecifiqueMenuItem
    {
        CActionMenuItem m_actionMenuItem = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;        
        
        public CControlEditActionMenuItem()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireControlEditeurSpecifiqueMenuItem.RegisterEditeurSpecifique(
                I.T("Action Menu Item|10410"),
                typeof(CActionMenuItem),
                typeof(CControlEditActionMenuItem));
        }

        //-------------------------------------------------------------------------------
        public IMenuItem MenuItemEdite
        {
            get
            {
                return m_actionMenuItem;
            }
        }

        //-------------------------------------------------------------------------------
        public void InitChamps(IMenuItem menuItem, CObjetPourSousProprietes objetPourSousProprietes)
        {
            CActionMenuItem actionItem = menuItem as CActionMenuItem;
            m_objetPourSousProprietes = objetPourSousProprietes;
            if (actionItem == null)
            {
                Visible = false;
                m_actionMenuItem = null;
                return;
            }
            m_actionMenuItem = actionItem;
            
            Visible = true;
            m_txtMenuItemLabel.Text = actionItem.Libelle;
            m_numMenuItemSort.IntValue = actionItem.NumeroOrdre;
            m_wndFormuleCondition.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_txtFormuleLibelle.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_wndFormuleCondition.Formule = actionItem.FormuleCondition;
            m_txtFormuleLibelle.Formule = actionItem.FormuleLibelle;
            m_imageLinkOk.Visible = actionItem.Action != null;

        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_actionMenuItem != null)
            {
                m_actionMenuItem.NumeroOrdre = m_numMenuItemSort.IntValue != null ? m_numMenuItemSort.IntValue.Value : 0;
                m_actionMenuItem.Libelle = m_txtMenuItemLabel.Text;
                m_actionMenuItem.FormuleCondition = m_wndFormuleCondition.Formule;
                m_actionMenuItem.FormuleLibelle = m_txtFormuleLibelle.Formule;

            }

            return result;
        }

        private void m_lnkActionSurMenuItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_actionMenuItem != null)
            {
                CActionSur2iLink actionSpec = m_actionMenuItem.Action;
                actionSpec = CFormEditActionSurLink.EditeAction(actionSpec, m_objetPourSousProprietes);
                if (actionSpec != null)
                    m_actionMenuItem.Action = actionSpec;

            }
        }
    }
}
