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
    public partial class CControlEditSeparateurMenuItem : UserControl, IControlEditeurSpecifiqueMenuItem
    {
        CSeparateurMenuItem m_SeparateurMenuItem = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;        
        
        public CControlEditSeparateurMenuItem()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireControlEditeurSpecifiqueMenuItem.RegisterEditeurSpecifique(
                I.T("Separator|20871"),
                typeof(CSeparateurMenuItem),
                typeof(CControlEditSeparateurMenuItem));
        }

        //-------------------------------------------------------------------------------
        public IMenuItem MenuItemEdite
        {
            get
            {
                return m_SeparateurMenuItem;
            }
        }

        //-------------------------------------------------------------------------------
        public void InitChamps(IMenuItem menuItem, CObjetPourSousProprietes objetPourSousProprietes)
        {
            CSeparateurMenuItem separateurItem = menuItem as CSeparateurMenuItem;
            m_objetPourSousProprietes = objetPourSousProprietes;
            if (separateurItem == null)
            {
                Visible = false;
                m_SeparateurMenuItem = null;
                return;
            }
            m_SeparateurMenuItem = separateurItem;
            
            Visible = true;
            m_numMenuItemSort.IntValue = separateurItem.NumeroOrdre;
            m_wndFormuleCondition.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_wndFormuleCondition.Formule = separateurItem.FormuleCondition;
        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_SeparateurMenuItem != null)
            {
                m_SeparateurMenuItem.NumeroOrdre = m_numMenuItemSort.IntValue != null ? m_numMenuItemSort.IntValue.Value : 0;
                m_SeparateurMenuItem.FormuleCondition = m_wndFormuleCondition.Formule;

            }

            return result;
        }
    }
}
