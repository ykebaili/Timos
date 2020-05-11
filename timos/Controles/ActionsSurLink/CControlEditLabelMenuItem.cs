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
    public partial class CControlEditLabelMenuItem : UserControl, IControlEditeurSpecifiqueMenuItem
    {
        CLabelMenuItem m_LabelMenuItem = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;        
        
        public CControlEditLabelMenuItem()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireControlEditeurSpecifiqueMenuItem.RegisterEditeurSpecifique(
                I.T("Label|20872"),
                typeof(CLabelMenuItem),
                typeof(CControlEditLabelMenuItem));
        }

        //-------------------------------------------------------------------------------
        public IMenuItem MenuItemEdite
        {
            get
            {
                return m_LabelMenuItem;
            }
        }

        //-------------------------------------------------------------------------------
        public void InitChamps(IMenuItem menuItem, CObjetPourSousProprietes objetPourSousProprietes)
        {
            CLabelMenuItem labelItem = menuItem as CLabelMenuItem;
            m_objetPourSousProprietes = objetPourSousProprietes;
            if (labelItem == null)
            {
                Visible = false;
                m_LabelMenuItem = null;
                return;
            }
            m_LabelMenuItem = labelItem;
            
            Visible = true;
            m_formuleLabel.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_formuleLabel.Formule = labelItem.FormuleLibelle;
            m_numMenuItemSort.IntValue = labelItem.NumeroOrdre;
            m_wndFormuleCondition.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_wndFormuleCondition.Formule = labelItem.FormuleCondition;

        }

        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_LabelMenuItem != null)
            {
                m_LabelMenuItem.NumeroOrdre = m_numMenuItemSort.IntValue != null ? m_numMenuItemSort.IntValue.Value : 0;
                m_LabelMenuItem.FormuleLibelle = m_formuleLabel.Formule;
                m_LabelMenuItem.FormuleCondition = m_wndFormuleCondition.Formule;

            }

            return result;
        }
    }
}
