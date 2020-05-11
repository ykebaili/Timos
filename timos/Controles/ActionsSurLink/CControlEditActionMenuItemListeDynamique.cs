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
    public partial class CControlEditActionMenuItemListeDynamique : UserControl, IControlEditeurSpecifiqueMenuItem
    {
        CActionMenuItemListeDynamique m_actionMenuItemListeDynamique = null;

        private CObjetPourSousProprietes m_objetPourSousProprietes = null;
        private Type m_typeForItem = null;
        
        public CControlEditActionMenuItemListeDynamique()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireControlEditeurSpecifiqueMenuItem.RegisterEditeurSpecifique(
                I.T("Actions List Items|20865"),
                typeof(CActionMenuItemListeDynamique),
                typeof(CControlEditActionMenuItemListeDynamique));
        }

        //-------------------------------------------------------------------------------
        public IMenuItem MenuItemEdite
        {
            get
            {
                return m_actionMenuItemListeDynamique;
            }
        }

        //-------------------------------------------------------------------------------
        public void InitChamps(IMenuItem menuItem, CObjetPourSousProprietes objetPourSousProprietes)
        {
            CActionMenuItemListeDynamique actionItem = menuItem as CActionMenuItemListeDynamique;

            if (actionItem == null)
            {
                Visible = false;
                m_actionMenuItemListeDynamique = null;
                return;
            }
            m_actionMenuItemListeDynamique = actionItem;
            
            Visible = true;
            m_objetPourSousProprietes = objetPourSousProprietes;
            m_txtMenuItemLabel.Text = actionItem.Libelle;
            m_numMenuItemSort.IntValue = actionItem.NumeroOrdre;
            m_wndFormuleCondition.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_wndFormuleCondition.Formule = actionItem.FormuleCondition;
            m_txtFormuleListeSource.Init(new CFournisseurGeneriqueProprietesDynamiques(), objetPourSousProprietes);
            m_txtFormuleListeSource.Formule = actionItem.FormuleListeSource;
            InitFormuleLibelleItem();
            m_txtFormuleItemLibelle.Formule = actionItem.FormuleItemLibelle;
            m_imageLinkOk.Visible = actionItem.Action != null;

        }

        //-------------------------------------------------------------------------------
        private Type TypeForItem
        {
            get
            {
                C2iExpression formule = m_txtFormuleListeSource.Formule;
                if (formule != null)
                {
                    CTypeResultatExpression tp = formule.TypeDonnee;
                    return tp.TypeDotNetNatif;
                }
                return null;
            }
        }

        //--------------------------------------------------------
        private void InitFormuleLibelleItem()
        {
            if (TypeForItem == null)
            {
                m_panelItem.Visible = false;
            }
            else
            {
                m_panelItem.Visible = true;
                m_txtFormuleItemLibelle.Init(
                    new CFournisseurGeneriqueProprietesDynamiques(),
                    TypeForItem);
            }
        }

        //-----------------------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_actionMenuItemListeDynamique != null)
            {
                m_actionMenuItemListeDynamique.NumeroOrdre = m_numMenuItemSort.IntValue != null ? m_numMenuItemSort.IntValue.Value : 0;
                m_actionMenuItemListeDynamique.Libelle = m_txtMenuItemLabel.Text;
                m_actionMenuItemListeDynamique.FormuleCondition = m_wndFormuleCondition.Formule;
                m_actionMenuItemListeDynamique.FormuleListeSource = m_txtFormuleListeSource.Formule;
                m_actionMenuItemListeDynamique.FormuleItemLibelle = m_txtFormuleItemLibelle.Formule;

            }

            return result;
        }

        //-----------------------------------------------------------------------------------------------
        private void m_lnkActionSurMenuItem_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_actionMenuItemListeDynamique != null)
            {
                if (TypeForItem != null)
                {
                    CObjetPourSousProprietes objForItem = TypeForItem;
                    if (m_objetPourSousProprietes != null)
                    {
                        CDefinitionMultiSourceForExpression multi = m_objetPourSousProprietes.ElementAVariableInstance as CDefinitionMultiSourceForExpression;
                        if (multi != null)
                        {
                            CDefinitionMultiSourceForExpression copie = new CDefinitionMultiSourceForExpression(TypeForItem);
                            foreach (string strSource in multi.GetNomSources())
                                copie.AddSource(strSource, multi.GetSource(strSource));
                            objForItem = new CObjetPourSousProprietes(copie);
                        }
                    }
                    CActionSur2iLink actionSpec = m_actionMenuItemListeDynamique.Action;
                    actionSpec = CFormEditActionSurLink.EditeAction(actionSpec, objForItem);
                    if (actionSpec != null)
                        m_actionMenuItemListeDynamique.Action = actionSpec;
                }
            }
        }

        private void m_txtFormuleItemLibelle_Enter(object sender, EventArgs e)
        {
            InitFormuleLibelleItem();
        }

        private void m_txtFormuleListeSource_Leave(object sender, EventArgs e)
        {
            InitFormuleLibelleItem();
        }
    }
}
