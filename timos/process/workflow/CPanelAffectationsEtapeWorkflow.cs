using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.process.workflow;
using sc2i.common;
using sc2i.data;
using sc2i.win32.data.navigation;
using sc2i.win32.common;

namespace timos.process.workflow
{
    public partial class CPanelAffectationsEtapeWorkflow : UserControl, IControlALockEdition
    {
        
        //------------------------------------------------
        public CPanelAffectationsEtapeWorkflow()
        {
            InitializeComponent();
        }

        //------------------------------------------------
        public void Init ( IEnumerable<IAffectableAEtape> lst )
        {
            FillListe(lst);
        }

        //------------------------------------------------
        private void InitMenuAdd()
        {
            if (m_menuAdd.Items.Count > 0)
                return;
            foreach (Type tp in CAffectationsEtapeWorkflow.GetTypesAffectables())
            {
                ToolStripMenuItem itemAdd = new ToolStripMenuItem();
                itemAdd.Text = DynamicClassAttribute.GetNomConvivial(tp);
                itemAdd.Tag = tp;
                itemAdd.Click += new EventHandler(itemAdd_Click);
                m_menuAdd.Items.Add(itemAdd);
            }
        }

        //------------------------------------------------
        private void AddAffectable ( IAffectableAEtape affectable )
        {
            foreach ( ListViewItem item in m_wndListeAffectations.Items )
            {
                IAffectableAEtape affectableExistant = item.Tag as IAffectableAEtape;
                if ( affectableExistant != null && 
                    affectableExistant.Equals ( affectable ) )
                    return;
            }
            ListViewItem newItem = new ListViewItem ();
            InitItem(newItem, affectable);
            m_wndListeAffectations.Items.Add ( newItem );
        }

        //------------------------------------------------
        private void  itemAdd_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Type tp = item != null ? item.Tag as Type : null;
            if (tp != null)
            {
                CReferenceTypeForm refFrm = CFormFinder.GetTypeFormToList(tp);
                if (refFrm != null)
                {
                    CFormListeStandard frm = refFrm.GetForm() as CFormListeStandard;
                    if (frm != null)
                    {
                        IAffectableAEtape affectable = CFormNavigateurPopupListe.SelectObject(frm, null, "") as IAffectableAEtape;
                        if (affectable != null)
                        {
                            AddAffectable(affectable);
                        }
                    }
                }
            }
        } 


        private void FillListe(IEnumerable<IAffectableAEtape> lst)
        {
            if ( lst == null )
                return;
            m_wndListeAffectations.BeginUpdate();
            m_wndListeAffectations.Items.Clear();
            foreach ( IAffectableAEtape affectable in lst)
            {
                ListViewItem item = new ListViewItem();
                InitItem ( item, affectable );
                m_wndListeAffectations.Items.Add ( item );
            }
            m_wndListeAffectations.EndUpdate();
        }

        //------------------------------------------------
        private void InitItem(ListViewItem item, IAffectableAEtape affectable)
        {
            item.Text = affectable.DescriptionElement;
            item.Tag = affectable;
        }

        //------------------------------------------------
        public IEnumerable<IAffectableAEtape> ListeAffectables
        {
            get
            {
                List<IAffectableAEtape> lst = new List<IAffectableAEtape>();
                foreach (ListViewItem item in m_wndListeAffectations.Items)
                {
                    IAffectableAEtape aff = item.Tag as IAffectableAEtape;
                    if (aff != null)
                        lst.Add(aff);
                }
                return lst.AsReadOnly();
            }
        }

        private void m_lnkRemove_LinkClicked(object sender, EventArgs e)
        {
            List<ListViewItem> lstSel = new List<ListViewItem>();
            foreach (ListViewItem item in m_wndListeAffectations.SelectedItems)
                lstSel.Add(item);
            foreach (ListViewItem item in lstSel)
            {
                m_wndListeAffectations.Items.Remove(item);
            }
        }


        #region IControlALockEdition Membres

        public bool LockEdition
        {
            get
            {
                return !m_extModeEdition.ModeEdition;
            }
            set
            {
                m_extModeEdition.ModeEdition = !value;
                if (OnChangeLockEdition != null)
                    OnChangeLockEdition(this, new EventArgs());
            }
        }

        public event EventHandler OnChangeLockEdition;

        #endregion

        private void m_lnkAdd_LinkClicked(object sender, EventArgs e)
        {
            InitMenuAdd();
            m_menuAdd.Show(m_lnkAdd, new Point(0, m_lnkAdd.Height));
        }
    }
}
