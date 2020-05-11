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
    public partial class CControleEditeMapItemDessin : CCustomizableListControl
    {
        private IFournisseurProprietesDynamiques m_fournisseur = new CFournisseurGeneriqueProprietesDynamiques();

        public CControleEditeMapItemDessin()
        {
            InitializeComponent();
        }

        //----------------------------------------
        public void InitForMapPointGenerator(CMapPointGenerator pointGen)
        {
            m_txtFormuleCondition.Init(pointGen.Generator, new CObjetPourSousProprietes(pointGen));
            m_txtFormuleTooltip.Init(pointGen.Generator, new CObjetPourSousProprietes(pointGen));
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
            CMapItemDessin dessin = item != null ? item.Tag as CMapItemDessin : null;
            if ( m_cmbMarkerType.ListDonnees == null  && item != null)
            {
                CEnumALibelle<EMapMarkerType>[] valeurs = CEnumALibelle<EMapMarkerType>.GetValeursEnumPossibleInEnumALibelle(typeof(CMapMarkerType));
                m_cmbMarkerType.ListDonnees = valeurs;
                m_cmbMarkerType.ProprieteAffichee = "Libelle";
            }
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
                /*m_txtFormuleCondition.Visible = !IsCreatingImage;
                m_txtFormuleTooltip.Visible = !IsCreatingImage;
                m_lblFormuleCondition.Visible = IsCreatingImage;
                m_lblFormuleTooltip.Visible = IsCreatingImage;*/
                m_cmbMarkerType.SelectedValue = new CMapMarkerType(dessin.MarkerType);
                if (m_selectImage.Image != null)
                    m_selectImage.Image.Dispose();
                m_selectImage.Image = dessin.Image != null ? new Bitmap(dessin.Image) : null ;
                m_chkPermanent.Checked = dessin.PermanentToolTip;
                UpdateVisuImage();
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

            CMapItemDessin dessin = CurrentItem != null?CurrentItem.Tag as CMapItemDessin:null;
            if (dessin != null)
            {
                dessin.FormuleCondition = m_txtFormuleCondition.Formule;
                dessin.FormuleToolTip = m_txtFormuleTooltip.Formule;
                CMapMarkerType type = m_cmbMarkerType.SelectedValue as CMapMarkerType;
                if (type != null)
                    dessin.MarkerType = type.Code;
                if (dessin.MarkerType == EMapMarkerType.none)
                {
                    dessin.Image = m_selectImage.Image as Bitmap;
                }
                else
                    dessin.Image = null;
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

        private void m_cmbMarkerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateVisuImage();
        }

        private void UpdateVisuImage()
        {
            CMapMarkerType type = m_cmbMarkerType.SelectedValue as CMapMarkerType;
            m_selectImage.Visible = type != null && type.Code == EMapMarkerType.none;
        }
    }
}
