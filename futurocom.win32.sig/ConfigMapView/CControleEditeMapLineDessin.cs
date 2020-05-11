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
using futurocom.sig;
using sc2i.expression;
using sc2i.common.sig;

namespace futurocom.win32.sig
{
    public partial class CControleEditeMapLineDessin : CCustomizableListControl
    {
        private IFournisseurProprietesDynamiques m_fournisseur = new CFournisseurGeneriqueProprietesDynamiques();

        public CControleEditeMapLineDessin()
        {
            InitializeComponent();
        }

        //----------------------------------------
        public void InitForLineGenerator(CMapLineGenerator lineGen)
        {
            m_txtFormuleCondition.Init(lineGen.Generator, new CObjetPourSousProprietes(lineGen));
            m_txtFormuleTooltip.Init(lineGen.Generator, new CObjetPourSousProprietes(lineGen));
        }

        //----------------------------------------
        public override bool HasChange
        {
            get
            {
                return true;
            }
        }

        //----------------------------------------
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            CResultAErreur result = CResultAErreur.True;
            CMapLineDessin dessin = item != null ? item.Tag as CMapLineDessin : null;
            if (dessin != null)
            {
                if (!IsCreatingImage)
                {
                    m_txtFormuleTooltip.Formule = dessin.FormuleToolTip;
                    m_txtFormuleCondition.Formule = dessin.FormuleCondition;
                }
                m_lblFormuleTooltip.Text = dessin.FormuleToolTip != null ?
                    dessin.FormuleToolTip.GetString() : "";
                m_lblFormuleCondition.Text = dessin.FormuleCondition != null ?
                    dessin.FormuleCondition.GetString() : "";
                m_selectLineColor.SelectedColor = dessin.LineColor;
                m_wndLineWidth.Value = (int)dessin.LineWidth;
                m_chkPermanent.Checked = dessin.PermanentToolTip;

            }
            return result;
        }
        //---------------------------------------------------
        protected override Image CreateCurrentItemImage()
        {
            m_txtFormuleTooltip.Visible = false;
            m_txtFormuleCondition.Visible = false;
            m_lblFormuleTooltip.Visible = true;
            m_lblFormuleCondition.Visible = true;
            Image img = base.CreateCurrentItemImage();
            m_txtFormuleTooltip.Visible = true;
            m_txtFormuleCondition.Visible = true;
            m_lblFormuleTooltip.Visible = false;
            m_lblFormuleCondition.Visible = false;
            return img;

        }


        //---------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            CMapLineDessin dessin = CurrentItem != null?CurrentItem.Tag as CMapLineDessin:null;
            if (dessin != null)
            {
                dessin.FormuleCondition = m_txtFormuleCondition.Formule;
                dessin.FormuleToolTip = m_txtFormuleTooltip.Formule;
                dessin.LineColor = m_selectLineColor.SelectedColor;
                dessin.LineWidth = (int)m_wndLineWidth.Value;
                dessin.PermanentToolTip = m_chkPermanent.Checked;
            }
            return result;
        }

        //---------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return true;
            }
        }

        private Point m_ptStartDrag = new Point(0, 0);
        private void m_picDragDrop_MouseDown(object sender, MouseEventArgs e)
        {
            m_ptStartDrag = new Point(e.X, e.Y);
        }

        private void m_picDragDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left && m_extModeEdition.ModeEdition)
            {
                if (Math.Abs(m_ptStartDrag.X - e.X) > 3 ||
                    Math.Abs(m_ptStartDrag.Y - e.Y) > 3)
                    StartDragDrop(m_ptStartDrag, DragDropEffects.Move);
            }
        }

        public event EventHandler OnDeleteItem;

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (OnDeleteItem != null)
                OnDeleteItem(CurrentItem, null);
        }


       
    }
}
