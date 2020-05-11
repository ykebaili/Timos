using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using sc2i.win32.common.customizableList;
using sc2i.common;
using timos.data.projet.besoin;
using System.Collections;
using sc2i.data;
using timos.Properties;
using timos.General;

namespace timos.projet.besoin
{
    public partial class CControleQuantite : CCustomizableListControl
    {
        public const int WM_SYSKEYUP = 0x105;

        public CControleQuantite()
        {
            InitializeComponent();
        }

        public CBesoinQuantite Quantite
        {
            get
            {
                if (CurrentItem != null)
                    return CurrentItem.Tag as CBesoinQuantite;
                return null;
            }
        }

        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            CResultAErreur result = base.MyInitChamps(item);
            if (result && item != null)
            {
                CBesoinQuantite qt = item.Tag as CBesoinQuantite;
                if (qt != null && qt.IsValide())
                {
                    m_txtQuantite.LockEdition = LockEdition || qt.QuantitesFilles.Count != 0;
                    m_txtLibelle.Text = qt.Libelle;
                    m_txtQuantite.DoubleValue = qt.Quantite;
                    m_btnEdit.Visible = qt.Niveau == 0;
                    UpdateMarge();
                }
            }
            else
            {
                m_txtLibelle.Text = "";
                m_txtQuantite.DoubleValue = 1;
                UpdateMarge();
            }
            m_bIsInitializing = false;
            return result;
        }

        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            if (result && CurrentItem != null)
            {
                CBesoinQuantite qt = CurrentItem.Tag as CBesoinQuantite;
                if (qt != null)
                {
                    qt.Index = CurrentItem.Index;
                    qt.Libelle = m_txtLibelle.Text;
                    qt.Quantite = m_txtQuantite.DoubleValue == null ? 0 : m_txtQuantite.DoubleValue.Value;
                }
            }
            return result;
        }

        public event EventHandler OnDeleteQuantite;

        //-------------------------------------------------------------
        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (OnDeleteQuantite != null)
            {
                CBesoinQuantite qte = CurrentItem != null ? CurrentItem.Tag as CBesoinQuantite : null;

                if (qte != null && MessageBox.Show(I.T("Delete quantity '@1'|20596", qte.Libelle),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OnDeleteQuantite(this, null);
                }
            }
        }

        //-------------------------------------------------------------
        public event EventHandler QuantiteChanged;

        //-------------------------------------------------------------
        private void textChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing && CurrentItem != null)
                HasChange = true;
        }

        //-----------------------------------------------------------------------
        private Point? m_ptMouseDownTache = null;
        private void m_imageQte_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                m_ptMouseDownTache = new Point(e.X, e.Y);
            }
        }

        //-----------------------------------------------------------------------
        private bool m_bHasDrag = false;
        private void m_imageQte_MouseMove(object sender, MouseEventArgs e)
        {
            m_bHasDrag = false;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && m_ptMouseDownTache != null)
            {
                Point pt = new Point(Math.Abs(e.X - m_ptMouseDownTache.Value.X),
                    Math.Abs(e.Y - m_ptMouseDownTache.Value.Y));
                if (pt.X > 4 || pt.Y > 4)
                {
                    CItemQuantite item = CurrentItem as CItemQuantite;
                    if (item != null)
                    {
                        StartDragDrop(new Point(e.X, e.Y), DragDropEffects.Move | DragDropEffects.Link);
                        m_bHasDrag = true;
                        AssociatedListControl.RefreshItem(item);
                        if (item.Quantite != null)
                            item.Quantite.Index = item.Index;
                        item = ((CCustomizableListAvecNiveau)AssociatedListControl).GetParent(item) as CItemQuantite;
                        while (item != null)
                        {
                            AssociatedListControl.RefreshItem(item);
                            item = ((CCustomizableListAvecNiveau)AssociatedListControl).GetParent(item) as CItemQuantite;
                        }
                    }
                    AssociatedListControl.Refresh();
                }
            }
        }

        private void UpdateMarge()
        {
            CItemQuantite item = CurrentItem as CItemQuantite;
            if (item != null && item.Quantite != null)
                m_picMarge.Width = item.Niveau * 10;
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_SYSKEYUP)
            {
                Keys key = (Keys)m.WParam;
                if (key == Keys.Left)
                {
                    CCustomizableListAvecNiveau ctrl = AssociatedListControl as CCustomizableListAvecNiveau;
                    if (ctrl != null)
                    {
                        ctrl.DecrementeNiveau(CurrentItem as CItemQuantite);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }
                if (key == Keys.Right)
                {
                    CCustomizableListAvecNiveau ctrl = AssociatedListControl as CCustomizableListAvecNiveau;
                    if (ctrl != null)
                    {
                        ctrl.IncrementeNiveau(CurrentItem as CItemQuantite);
                        UpdateMarge();
                        ctrl.Refresh();
                        return true;
                    }
                }

            }
            return base.ProcessKeyPreview(ref m);
        }


        private void m_txtQuantite_Validated(object sender, EventArgs e)
        {
            if (QuantiteChanged != null)
                QuantiteChanged(this, null);
        }

        //-------------------------------------------------------------
        private void m_btnEdit_MouseUp(object sender, MouseEventArgs e)
        {
            ShowMenuDetail(e.Button == MouseButtons.Right);
        }

        //-------------------------------------------------------------
        private bool m_bIsMenuSupprimer = false;
        private void ShowMenuDetail(bool bSupprimer)
        {
            m_bIsMenuSupprimer = bSupprimer && m_extModeEdition.ModeEdition;
            if (Quantite != null)
            {
                foreach (ToolStripItem dis in new ArrayList(m_menuDetail.Items))
                {
                        m_menuDetail.Items.Remove(dis);
                        dis.Dispose();
                }
                int nIndex = 0;
                foreach (CRelationBesoinQuantite_Element rel in Quantite.RelationsElementsSelectionnes)
                {
                    CObjetDonneeAIdNumerique objet = rel.Element;
                    if (objet != null)
                    {
                        CObjetDonneeMenuItem item = new CObjetDonneeMenuItem(
                            objet,
                            rel,
                            objet.DescriptionElement,
                            false);
                        if (bSupprimer && m_extModeEdition.ModeEdition)
                            item.Image = Resources.delete;
                        item.Click += new EventHandler(itemElement_Click);
                        m_menuDetail.Items.Insert(nIndex++,item);
                    }
                }
                m_menuDetail.Show(m_btnEdit, new Point(0, m_btnEdit.Height));
            }

        }

        void itemElement_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        //-------------------------------------------------------------
        void itemElement_Click(object sender, EventArgs e)
        {
            CObjetDonneeMenuItem item = sender as CObjetDonneeMenuItem;
            if (item != null)
            {
                CRelationBesoinQuantite_Element rel = item.ObjetToEdit as CRelationBesoinQuantite_Element;
                if (rel != null && rel.Element != null)
                {
                    if (m_bIsMenuSupprimer)
                    {
                        if (MessageBox.Show(I.T("Remove @1 from selection|20641", rel.Element.DescriptionElement),
                            "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            rel.Delete(true);
                            InitChamps(CurrentItem);
                        }
                    }
                    else
                    {
                        CObjetDonneeAIdNumerique objet = rel.Element.GetObjetInContexte(sc2i.win32.data.CSc2iWin32DataClient.ContexteCourant) as CObjetDonneeAIdNumerique;
                        CTimosApp.Navigateur.EditeElement(objet, false, "");
                    }
                }
            }
        }

        //-------------------------------------------------------------
        private void m_btnEdit_Paint(object sender, PaintEventArgs e)
        {
            if (Quantite != null && Quantite.TypeEntiteAssocie != null)
            {
                int nNb = Quantite.RelationsElementsSelectionnes.Count;
                Font ft = new Font(Font.FontFamily, 6);
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Far;
                Brush br = Brushes.Green;
                if (nNb != Quantite.Quantite)
                    br = Brushes.Red;
                e.Graphics.DrawString(nNb.ToString(), ft, br, m_btnEdit.ClientRectangle, sf);
                sf.Dispose();
                ft.Dispose();
            }

        }

        private void m_menuDetail_Opening(object sender, CancelEventArgs e)
        {

        }



    }
}
