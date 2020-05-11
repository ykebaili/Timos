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
using TimosInventory.data;
using sc2i.common.memorydb;
using TimosInventory.data.releve;
using TimosInventory.CustomField;

namespace TimosInventory.ControleInventaire
{
   

    //---------------------------------------------------------------------------
    public partial class CControlePourInventaire : CCustomizableListControl
    {
        public const int WM_KEYDOWN = 0x100;

        private CMemoryDbIndex<CTypeEquipement> m_indexTypeEq = null;
        public CControlePourInventaire()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------
        public CMemoryDbIndex<CTypeEquipement> IndexTypeEq
        {
            get
            {
                return m_indexTypeEq;
            }
            set
            {
                m_indexTypeEq = value;
            }
        }

        //------------------------------------------------------------------------------
        private bool m_bIsInitializing = false;
        protected override CResultAErreur MyInitChamps(CCustomizableListItem item)
        {
            m_bIsInitializing = true;
            CResultAErreur result = base.MyInitChamps(item);
            if (!result)
                return result;
            CItemInventaire iv = item as CItemInventaire;
            CReleveEquipement relEq = iv != null ? iv.ReleveEquipement : null;
            if (relEq != null)
            {
                System.Console.Write(relEq.NumeroSerie);
                CMemoryDbIndex<CTypeEquipement> index = IndexTypeEq;
                if (index == null)
                {
                    index = new CMemoryDbIndex<CTypeEquipement>(((CReleveDb)relEq.Database).TimosDb);
                    IndexTypeEq = index;
                }
                int nNiveau = iv.Niveau;
                if (nNiveau == 0)
                    m_panelMarge.Visible = false;
                else
                {
                    m_panelMarge.Width = nNiveau * 15;
                    m_panelMarge.Visible = true;
                }

                m_selectPresence.Value = relEq.IsPresent;
                UpdateColors();
                
                UpdateBoutonExpand(iv);
                m_txtCoord.Init(relEq, !IsCreatingImage);
                m_selectTypeEquipement.Init(relEq, !this.IsCreatingImage);
                m_txtSerial.Text = relEq.NumeroSerie;
                m_txtComment.Text = relEq.Commentaire;
                foreach (Control ctrl in m_panelChampsCustom.Controls)
                {
                    CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                    if (c != null)
                        c.InitChamps(relEq);
                }
            }
            if (!IsCreatingImage)
                CalcSerialError();
            m_bIsInitializing = false;
            
            return result;
        }

        private void UpdateColors()
        {
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null)
            {

                if (iv.ReleveEquipement.IsPresent == null)
                {
                    BackColor = Color.Red;
                    ColorInactive = Color.LightPink;
                }
                else
                {
                    ColorInactive = Color.White;
                    BackColor = Color.LightBlue;
                }
                if (iv.Index % 2 == 0)
                {
                    BackColor = sc2i.drawing.CUtilCouleur.Assombrir(BackColor, 10);
                    ColorInactive = sc2i.drawing.CUtilCouleur.Assombrir(ColorInactive, 10);
                }

            }
        }

        //------------------------------------------------------------------------------
        public override bool IsFixedSize
        {
            get
            {
                return false;
            }
        }


        //------------------------------------------------------------------------------
        public override int GetItemHeight(CCustomizableListItem item)
        {
            CItemInventaire iv = item as CItemInventaire;
            if (iv != null)
            {
                if (iv.IsMasque)
                    return 0;
                return m_panelTop.Height+ m_lblLigneBas.Height+
                    (m_panelChampsCustom.Controls.Count > 0?m_panelChampsCustom.Height:0);
            }
            return base.GetItemHeight(item);
        }

        //------------------------------------------------------------------------------
        protected override CResultAErreur MyMajChamps()
        {
            CResultAErreur result = base.MyMajChamps();
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv == null || iv.ReleveEquipement == null || iv.ReleveEquipement.Row.Row.RowState == DataRowState.Detached)
                return result;
            if (iv != null)
            {
                iv.ReleveEquipement.IsPresent = m_selectPresence.Value;
                m_selectPresence.Value = iv.ReleveEquipement.IsPresent;
                iv.ReleveEquipement.NumeroSerie = m_txtSerial.Text;
            }
            result = m_selectTypeEquipement.MajChamps();
            if (result)
                result = m_txtCoord.MajChamps();
            iv.ReleveEquipement.Commentaire = m_txtComment.Text;
            foreach (Control ctrl in m_panelChampsCustom.Controls)
            {
                CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                if (c != null)
                    result = c.MajChamp();
                if (!result)
                    return result;
            }
            
            UpdateColors();
            return result;

        }



        //------------------------------------------------------------------------------
        private void UpdateBoutonExpand(CItemInventaire iv)
        {
            if (!iv.HasChildren)
                m_btnExpand.Image = null;
            else
            {
                if (iv.IsCollapse)
                    m_btnExpand.Image = global::TimosInventory.Properties.Resources.plus_32;
                else
                    m_btnExpand.Image = global::TimosInventory.Properties.Resources.moins_32;
            }
        }

        //------------------------------------------------------------------------------
        private void m_btnExpand_Click(object sender, EventArgs e)
        {
            CItemInventaire iv = this.CurrentItem as CItemInventaire;
            if (iv != null)
            {
                iv.SetCollapse(!iv.IsCollapse);
                if (!iv.IsCollapse)
                    ((CControleListePourInventaire)AssociatedListControl).OnExpand(iv);
            }
            //AssociatedListControl.Refill();
            AssociatedListControl.Refresh();
            UpdateBoutonExpand(iv);
        }

        private void m_selectPresence_ValueChanged(object sender, EventArgs e)
        {
            HasChange = true;
        }

        protected override bool ProcessKeyPreview(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys key = (Keys)m.WParam;
                if (key == Keys.F5)
                {
                    if (m_selectPresence.Value == true)
                        m_selectPresence.Value = null;
                    else
                    {
                        m_selectPresence.Value = true;
                        OnPresenceChanged();
                    }
                    HasChange = true;
                    return true;
                }
                if (key == Keys.F6)
                {
                    if (m_selectPresence.Value == false)
                        m_selectPresence.Value = null;
                    else
                        m_selectPresence.Value = false;
                    HasChange = true;
                    return true;
                }
            }
            return base.ProcessKeyPreview(ref m);
        }

        private void m_selectPresence_ValueChanged_1(object sender, EventArgs e)
        {
            OnPresenceChanged();
        }

        private void OnPresenceChanged()
        {
            HasChange = true;
            CItemInventaire iv = this.CurrentItem as CItemInventaire;
            if (m_selectPresence.Value == true && iv != null && iv.IsCollapse)
            {
                m_btnExpand_Click(this, null);
            }
        }

        private void m_txtCoord_ValueChanged(object sender, EventArgs e)
        {
            if ( !m_bIsInitializing )
                HasChange = true;
        }

        private void m_txtSerial_TextChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            CItemInventaire item = CurrentItem as CItemInventaire;
            if (item != null)
            {
                ((CControleListePourInventaire)AssociatedListControl).OnExpand(item);
                CReleveEquipement relEq = CFormCreerEquipement.CreateEquipement(
                    item.ReleveEquipement.ReleveSite,
                    item.ReleveEquipement);
                if (relEq != null)
                {
                    CControleListePourInventaire ctrl = this.AssociatedListControl as CControleListePourInventaire;
                    if (ctrl != null)
                        ctrl.AddChildren(relEq, item);
                }
            }

        }

        //------------------------------------------------------------------
        private void m_txtSerial_Validated(object sender, EventArgs e)
        {
            CalcSerialError();
        }

        private void CalcSerialError()
        {
            //Vérifie s'il n'y a pas de relevé avec le même numéro de série
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null && m_txtSerial.Text.Trim() != "")
            {
                CListeEntitesDeMemoryDb<CReleveEquipement> lstRels = new CListeEntitesDeMemoryDb<CReleveEquipement>(iv.ReleveEquipement.Database);
                lstRels.Filtre = new CFiltreMemoryDb(
                    CEquipement.c_champSerial + "=@1 and " +
                    CReleveSite.c_champId + "=@2 and " +
                    CTypeEquipement.c_champId + "=@3",
                    m_txtSerial.Text.Trim(),
                    iv.ReleveEquipement.ReleveSite.Id,
                    iv.ReleveEquipement.IdTypeEquipement);
                if (lstRels.Count() > 1)
                {
                    StringBuilder bl = new StringBuilder();
                    bl.Append(I.T("Multiple use of serial|20035"));
                    bl.Append("( ");
                    foreach (CReleveEquipement rel in lstRels)
                    {
                        bl.Append(rel.CoordonneeComplete);
                        bl.Append(',');
                    }
                    bl.Remove(bl.Length - 1, 1);
                    bl.Append(")");
                    m_error.SetError(m_txtSerial, bl.ToString());
                }
                else
                    m_error.SetError(m_txtSerial, "");
            }
            else
                m_error.SetError(m_txtSerial, "");
        }

        private void m_txtComment_TextChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }

        private void CControlePourInventaire_Load(object sender, EventArgs e)
        {
            CListeEntitesDeMemoryDb<CChampCustom> lstChamps = new CListeEntitesDeMemoryDb<CChampCustom>(CTimosInventoryDb.GetTimosDatas());
            lstChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CReleveEquipement.c_roleChampCustom);
            if (lstChamps.Count() == 0)
            {
                m_panelChampsCustom.Visible = false;
            }
            else
            {
                m_panelChampsCustom.Visible = true;
                foreach ( CChampCustom champOrg in lstChamps )
                {
                    CChampCustom champ = new CChampCustom(CTimosInventoryDb.GetInventaireDatas());
                    if (!champ.ReadIfExist(champOrg.Id))
                    {
                        champ = champOrg.GetChampInMemoryDb(CTimosInventoryDb.GetInventaireDatas());
                    }

                    if (champ != null)
                    {
                        CControleForCustomFieldReleve ctrl = new CControleForCustomFieldReleve();
                        m_panelChampsCustom.Controls.Add(ctrl);
                        ctrl.Dock = DockStyle.Left;
                        ctrl.Init(champ);
                        ctrl.OnValueChanged += new EventHandler(ctrlCustom_OnValueChanged);
                    }
                }
            }
            Height = m_panelTop.Height + m_lblLigneBas.Height +
                    (m_panelChampsCustom.Controls.Count > 0 ? m_panelChampsCustom.Height : 0);
        }

        void ctrlCustom_OnValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }

      
        
    }
}
                