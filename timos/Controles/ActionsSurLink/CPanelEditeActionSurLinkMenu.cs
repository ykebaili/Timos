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
    public partial class CPanelEditeActionSurLinkMenu : UserControl, IEditeurUneActionSur2iLink
    {
        private CActionSur2iLinkMenuDeroulant m_actionEditee = null;
        private CObjetPourSousProprietes m_objetPourSousProprietes = null;
        
        private IControlEditeurSpecifiqueMenuItem m_controlEditeurEnCours = null;

        public CPanelEditeActionSurLinkMenu()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------------
        public static void Autoexec()
        {
            CGestionnaireEditeursActionsSur2iLink.RegisterEditeur(
                I.T("Drop down Menu|10404"),
                typeof(CActionSur2iLinkMenuDeroulant),
                typeof(CPanelEditeActionSurLinkMenu));
        }


        public void InitChamps(CActionSur2iLink action, CObjetPourSousProprietes objetPourSousProprietes)
        {
            m_actionEditee = action as CActionSur2iLinkMenuDeroulant;
            if (m_actionEditee == null)
            {
                Visible = false;
                return;
            }
            m_objetPourSousProprietes = objetPourSousProprietes;
            Visible = true;

            
            InitPanelDetailItem(null);

            m_wndListeMenuItems.Remplir(m_actionEditee.ListeMenuItems);

        }

        //------------------------------------------------------------------------------
        public CResultAErreur MajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            result = MajChampsPanelDetailItem();

            List<IMenuItem> listeActionItems = new List<IMenuItem>();
            foreach (ListViewItem item in m_wndListeMenuItems.Items)
            {
                IMenuItem actionMenuItem = item.Tag as IMenuItem;
                listeActionItems.Add(actionMenuItem);
            }
            m_actionEditee.ListeMenuItems = listeActionItems;

            return result;
        }

        //------------------------------------------------------------------------------
        private void InitPanelDetailItem(IMenuItem menuItem)
        {
            m_panelDetailsItem.SuspendDrawing();

            if (menuItem != null)
            {
                if (m_controlEditeurEnCours != null)
                {
                    m_panelDetailsItem.Controls.Remove((Control)m_controlEditeurEnCours);
                    m_controlEditeurEnCours.Dispose();
                    m_controlEditeurEnCours = null;
                }
                if (m_controlEditeurEnCours == null)
                {
                    CGestionnaireControlEditeurSpecifiqueMenuItem.CInfoTypeMenuItemEditeur info =
                        CGestionnaireControlEditeurSpecifiqueMenuItem.GetInfoEditeurForMenuItem(menuItem);
                    if (info != null)
                    {
                        m_controlEditeurEnCours = Activator.CreateInstance(info.TypeEditeurSpecifique, new object[0]) as IControlEditeurSpecifiqueMenuItem;
                        Control ctrl = m_controlEditeurEnCours as Control;
                        ctrl.Parent = m_panelDetailsItem;
                        ctrl.Dock = DockStyle.Fill;
                        CWin32Traducteur.Translate(ctrl);
                    }
                }
                if (m_controlEditeurEnCours != null)
                {
                    m_controlEditeurEnCours.InitChamps(menuItem, m_objetPourSousProprietes);
                }
            }

            m_panelDetailsItem.ResumeDrawing();
        }

        //-----------------------------------------------------------------------------------
        private CResultAErreur MajChampsPanelDetailItem()
        {
            CResultAErreur result = CResultAErreur.True;

            if (m_controlEditeurEnCours != null)
            {
                result = m_controlEditeurEnCours.MajChamps();
                if (result && m_controlEditeurEnCours.MenuItemEdite != null)
                {
                    foreach (ListViewItem item in m_wndListeMenuItems.Items)
                    {
                        if (item.Tag == m_controlEditeurEnCours.MenuItemEdite)
                        {
                            m_wndListeMenuItems.UpdateItemWithObject(item, m_controlEditeurEnCours.MenuItemEdite);
                            break;
                        }
                    }
                }
            }
            return result;
        }

        //-----------------------------------------------------------------------------------
        private void m_wndListeMenuItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            MajChampsPanelDetailItem();
            if (m_wndListeMenuItems.SelectedItems.Count > 0)
            {
                ListViewItem itemSel = m_wndListeMenuItems.SelectedItems[0];
                IMenuItem menuItem = itemSel.Tag as IMenuItem;
                if (menuItem != null)
                {
                    InitPanelDetailItem(menuItem);
                }
            }
        }

        //-----------------------------------------------------------------------------------     
        private void m_lnkAddMenuItem_LinkClicked(object sender, EventArgs e)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            foreach (CGestionnaireControlEditeurSpecifiqueMenuItem.CInfoTypeMenuItemEditeur info in CGestionnaireControlEditeurSpecifiqueMenuItem.GetTypesMenuItemsPossibles())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(info.NomMenuItem);
                item.Tag = info;
                item.Click += new EventHandler(AddMenuItem_Click);
                menu.Items.Add(item);
            }

            menu.Show(m_lnkAddMenuItem, new Point(0, m_lnkAddMenuItem.Height));
        }

        //------------------------------------------------------------------------------------
        void AddMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                CGestionnaireControlEditeurSpecifiqueMenuItem.CInfoTypeMenuItemEditeur info =
                    item.Tag as CGestionnaireControlEditeurSpecifiqueMenuItem.CInfoTypeMenuItemEditeur;
                if (info != null)
                {
                    CreateMenuItem(info);
                }
            }
        }

        //------------------------------------------------------------------------------------
        private void CreateMenuItem(CGestionnaireControlEditeurSpecifiqueMenuItem.CInfoTypeMenuItemEditeur info)
        {
            if(info == null)
                return;
            IMenuItem newMenuItem = Activator.CreateInstance(info.TypeMenuItem, new object[0]) as IMenuItem;
            newMenuItem.Libelle = I.T("New Action menu item|10408");
            ListViewItem newItem = new ListViewItem(newMenuItem.Libelle);
            m_wndListeMenuItems.Items.Add(newItem);
            m_wndListeMenuItems.UpdateItemWithObject(newItem, newMenuItem);
            newItem.Selected = true;
        }

        //-----------------------------------------------------------------------------------
        private void m_lnkRemoveMenuItem_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeMenuItems.SelectedItems.Count > 0)
            {
                ListViewItem itemSel = m_wndListeMenuItems.SelectedItems[0];
                IMenuItem menuItemASupprimer = itemSel.Tag as IMenuItem;
                if (menuItemASupprimer != null)
                {
                    InitPanelDetailItem(null);
                    m_wndListeMenuItems.Items.Remove(itemSel);
                }
            }
        }

    }
}
