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
using timos.data;
using timos.data.sites.releve;
using timos.data.sites.releve.actions;
using sc2i.data;
using sc2i.data.dynamic;
using timos.releve.CustomField;

namespace timos.sites.releve
{
    public partial class CControlActionReleve : CCustomizableListControl
    {
        public CControlActionReleve()
        {
            InitializeComponent();
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
                return m_panelOriginal.Height + m_panelReleve.Height+1;
            }
            return base.GetItemHeight(item);
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
            CTraitementReleveEquipement traitement = iv != null ? iv.TraitementReleve : null;
            CReleveEquipement relEq = traitement != null ? traitement.ReleveEquipement : null;
            CEquipement equipement = relEq != null ? relEq.Equipement : null;
            if ( relEq != null )
            {
                int nNiveau = iv.Niveau;
                if (nNiveau == 0)
                    m_panelMarge.Visible = false;
                else
                {
                    m_panelMarge.Width = nNiveau * 15;
                    m_panelMarge.Visible = true;
                }
                if (relEq.Presence == true)
                {
                    m_imageOeil.Image = global::timos.Properties.Resources.eye;
                    m_imageOeil.BackColor = Color.White;
                }
                else if (relEq.Presence == false)
                {
                    m_imageOeil.Image = global::timos.Properties.Resources.eye_no;
                    m_imageOeil.BackColor = Color.LightYellow;
                }
                else
                {
                    m_imageOeil.Image = global::timos.Properties.Resources.eye_question;
                    m_imageOeil.BackColor = Color.Cyan;
                }

                m_lblCoordReleve.Text = relEq.Coordonnee;
                m_lblSerialReleve.Text = relEq.NumSerie;
                m_lblTypeReleve.Text = relEq.TypeEquipement != null ?
                    relEq.TypeEquipement.Libelle : "";
                m_lblRefFourReleve.Text = relEq.ReferenceConstructeur != null ?
                    relEq.ReferenceConstructeur.Reference + " " + relEq.ReferenceConstructeur.Constructeur.Acteur.Nom :
                    "";

                m_lblCoordDb.Text = equipement != null ?
                    equipement.Coordonnee :
                    "";
                if (equipement != null)
                {
                    if (!equipement.Emplacement.Equals(relEq.ReleveSite.Site))
                    {
                        m_lblCoordDb.Text = I.T("Equipment is on @1|20783", equipement.Emplacement.Libelle);
                        m_lblCoordDb.BackColor = Color.LightSalmon;
                    }
                    else
                        m_lblCoordDb.BackColor = Color.LightGray;
                }
                m_lblSerialDB.Text = equipement != null ?
                    equipement.NumSerie : "";
                m_lblTypeDB.Text = equipement != null && equipement.TypeEquipement != null ?
                    equipement.TypeEquipement.Libelle : "";
                m_lblRefFourDB.Text = equipement != null && equipement.RelationConstructeur != null ?
                    equipement.RelationConstructeur.Reference + " " + equipement.RelationConstructeur.Constructeur.Acteur.Nom :
                    "";

                m_lblCoordReleve.BackColor =
                    m_lblCoordReleve.Text == m_lblCoordDb.Text ? Color.LightGreen : Color.LightSalmon;
                m_lblSerialReleve.BackColor =
                    m_lblSerialReleve.Text == m_lblSerialDB.Text ?
                    Color.LightGreen :
                    Color.LightSalmon;
                m_lblTypeReleve.BackColor =
                    m_lblTypeReleve.Text == m_lblTypeDB.Text ?
                    Color.LightGreen :
                    Color.LightSalmon;
                m_lblRefFourReleve.BackColor =
                    m_lblRefFourReleve.Text == m_lblRefFourDB.Text ?
                    Color.LightGreen :
                    Color.LightSalmon;

                bool bShowCommentaire = iv.TraitementReleve.ReleveEquipement.Commentaire.Trim().Length > 0 &&
                    !iv.InfoLigneVisible;
                iv.InfoLigneVisible = !bShowCommentaire;

                m_btnCommentaire.Visible = iv.TraitementReleve.ReleveEquipement.Commentaire.Trim().Length > 0;

                m_btnCommentaire.Checked = bShowCommentaire;
                m_btnInfo.Checked = !bShowCommentaire;

                UpdateTextCommentaire(iv);

               

                if (iv.TraitementReleve.ReleveEquipement.Presence == false)
                {
                    m_lblSerialReleve.BackColor = Color.LightYellow;
                    m_lblTypeReleve.BackColor = Color.LightYellow;
                    m_lblRefFourReleve.BackColor = Color.LightYellow;
                    m_lblCoordReleve.BackColor = Color.LightYellow;
                }

                foreach (Control ctrl in m_panelChampsReleve.Controls)
                {
                    CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                    if (c != null)
                    {
                        c.InitChamps(relEq);
                    }
                }
                if (equipement != null)
                {
                    m_panelChampsOriginaux.Visible = true;
                    foreach (Control ctrl in m_panelChampsOriginaux.Controls)
                    {
                        CControleForCustomFieldReleve c = ctrl as CControleForCustomFieldReleve;
                        if (c != null)
                            c.InitChamps(equipement);
                    }
                }
                else
                    m_panelChampsOriginaux.Visible = false;
                


                UpdateLibelleAction ( iv );

                m_imageActionsDessous.Visible = traitement.HasChildToValidate();

                UpdateBoutonExpand(iv);
                m_chkActionValidee.Checked = traitement.EtatValidation != EEtatValidationReleveEquipement.None;
                m_chkActionValidee.Enabled = traitement.EtatValidation != EEtatValidationReleveEquipement.Appliquée;
            }
            m_bIsInitializing = false;

            return result;
        }

        //------------------------------------------------------------------------------
        private void UpdateBoutonExpand(CItemInventaire iv)
        {
            if (iv.TraitementReleve.TraitementsFils.Count() == 0)
                m_btnExpand.Image = null;
            else
            {
                if (iv.IsCollapse)
                    m_btnExpand.Image = global::timos.Properties.Resources.Plus_32;
                else
                    m_btnExpand.Image = global::timos.Properties.Resources.Moins_32;
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
                    ((CControleListePourActionReleve)AssociatedListControl).OnExpand(iv);
            }
            //AssociatedListControl.Refill();
            AssociatedListControl.Refresh();
            UpdateBoutonExpand(iv);
        }

        private void m_lnkAction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

        }

        //----------------------------------------------------------
        void itemReinit_Click(object sender, EventArgs e)
        {
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null)
            {
                iv.TraitementReleve.CalculeAction();
                HasChange = true;
                UpdateLibelleAction(iv);
            }
        }

        //----------------------------------------------------------
        private void UpdateLibelleAction(CItemInventaire iv)
        {
            bool bOldIsInitialisating = m_bIsInitializing;
            m_bIsInitializing = true;
            if (iv != null && iv.TraitementReleve.Action != null)
            {
                m_lblAction.Text = iv.TraitementReleve.Action.Libelle;
                m_panelAction.BackColor = iv.TraitementReleve.Action.GetSousActionsPossibles().Count() == 0 ?
                    Color.LightGreen :
                    Color.LightSalmon;
                m_btnChooseAction.Visible = true;
                
            }
            else
            {
                m_lblAction.Text = "";
                m_btnChooseAction.Visible = false;
                m_panelAction.BackColor = Color.LightGreen;
            }
            m_chkActionValidee.Checked = iv != null &&  iv.TraitementReleve.EtatValidation != EEtatValidationReleveEquipement.None;
            m_bIsInitializing = bOldIsInitialisating;
            

        }

        //----------------------------------------------------------
        private ToolStripMenuItem[] GetMenusAction(CActionTraitementReleveEquipement action)
        {
            IEnumerable<CActionTraitementReleveEquipement> lstActions = action.GetSousActionsPossibles();
            if (lstActions.Count() == 1)
                return GetMenusAction(lstActions.ElementAt(0));


            if (lstActions.Count() == 0)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(action.Libelle);
                item.Tag = action;
                item.Image = global::timos.Properties.Resources.Action;
                item.Click += new EventHandler(item_Click);
                return new ToolStripMenuItem[] { item };
            }
            List<ToolStripMenuItem> lst = new List<ToolStripMenuItem>();
            foreach (CActionTraitementReleveEquipement sa in lstActions)
            {
                foreach ( ToolStripMenuItem item in GetMenusAction(sa) )
                    lst.Add(item);
            }
            return lst.ToArray();
        }

        //------------------------------------------------------------
        void item_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CActionTraitementReleveEquipement t = item != null ? item.Tag as CActionTraitementReleveEquipement: null;
            if (t != null)
            {
                CItemInventaire iv = CurrentItem as CItemInventaire;
                if (iv != null)
                {
                    iv.TraitementReleve.Action = t;
                    iv.TraitementReleve.EtatValidation = EEtatValidationReleveEquipement.Validé;
                    UpdateLibelleAction(iv);
                    HasChange = true;
                }
            }
        }

        //---------------------------------------------------------------------------
        private void m_btnChooseAction_Click(object sender, EventArgs e)
        {
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null)
            {
                if (iv.TraitementReleve.EtatValidation == EEtatValidationReleveEquipement.Appliquée)
                    return;
                CActionTraitementReleveEquipement actionDef = iv.TraitementReleve.GetDefaultAction();
                if (iv != null && actionDef != null)
                {
                    ContextMenuStrip menu = new ContextMenuStrip();
                    ToolStripMenuItem[] its = GetMenusAction(actionDef);
                    bool bHasDoNothing = false;
                    foreach (ToolStripMenuItem item in its)
                    {

                        bHasDoNothing |= item.Tag is CActionNeRienFaire;
                        menu.Items.Add(item);
                    }

                    CActionNeRienFaire rien = new CActionNeRienFaire(iv.TraitementReleve.ReleveEquipement);
                    if (!bHasDoNothing)
                    {
                        ToolStripMenuItem itemTmp = new ToolStripMenuItem(rien.Libelle);
                        itemTmp.Image = global::timos.Properties.Resources.Action;
                        itemTmp.Tag = rien;
                        itemTmp.Click += item_Click;
                        menu.Items.Add(itemTmp);
                    }


                    menu.Items.Add(new ToolStripSeparator());


                    ToolStripMenuItem itemReinit = new ToolStripMenuItem(I.T("Reset choice|20782"));
                    itemReinit.Click += new EventHandler(itemReinit_Click);
                    menu.Items.Add(itemReinit);

                    if (menu.Items.Count > 0)
                    {
                        menu.Show(m_btnChooseAction, new Point(0, m_btnChooseAction.Height));
                    }
                }
            }
        }

        //-------------------------------------------------------------------------
        private void m_btnCommentaire_CheckedChanged(object sender, EventArgs e)
        {
            if ( !m_bIsInitializing )
                UpdateTextCommentaire();
        }

        //-------------------------------------------------------------------------
        private void m_btnInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                UpdateTextCommentaire();
        }


        //-------------------------------------------------------------------------
        private void UpdateTextCommentaire()
        {
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null)
                UpdateTextCommentaire(iv);
        }

        //-------------------------------------------------------------------------
        private void UpdateTextCommentaire(CItemInventaire iv)
        {
            if ( iv != null && iv.TraitementReleve != null )
            {
                if (m_btnCommentaire.Checked)
                {
                    m_lblCommentReleve.Text = iv.TraitementReleve.ReleveEquipement.Commentaire;
                    m_lblCommentReleve.BackColor = Color.White;
                }
                else
                {
                    m_lblCommentReleve.BackColor = Color.FromArgb(240, 240, 240);
                    m_lblCommentReleve.Text = iv.TraitementReleve.Info;
                }
                iv.InfoLigneVisible = m_btnInfo.Checked;
            }
        }

        private void m_chkActionValidee_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
            {
                CItemInventaire iv = CurrentItem as CItemInventaire;
                if (iv != null && iv.TraitementReleve != null)
                {
                    EEtatValidationReleveEquipement oldEtat = iv.TraitementReleve.EtatValidation;
                    iv.TraitementReleve.EtatValidation = m_chkActionValidee.Checked ? EEtatValidationReleveEquipement.Validé:EEtatValidationReleveEquipement.None;
                    m_bIsInitializing = true;
                    m_chkActionValidee.Checked = iv.TraitementReleve.EtatValidation != EEtatValidationReleveEquipement.None;
                    m_bIsInitializing = false;
                    if (iv.TraitementReleve.EtatValidation != oldEtat)
                    {
                        CCustomizableListItemANiveau item = iv.ItemParent;
                        while (item != null)
                        {
                            AssociatedListControl.RefreshItem(item);
                            item = item.ItemParent;
                        }
                        AssociatedListControl.Refresh();
                    }
                }
                HasChange = true;
            }
        }

        private void m_imageFromBase_Click(object sender, EventArgs e)
        {
            CItemInventaire iv = CurrentItem as CItemInventaire;
            if (iv != null)
            {
                CEquipement eqpt = iv.TraitementReleve.ReleveEquipement.Equipement;
                if (eqpt != null)
                    CFormMain.GetInstance().EditeElement(eqpt, false,"");
            }
        }

        private void CControlActionReleve_Load(object sender, EventArgs e)
        {
            //Cherche les champs relevé
            CListeObjetsDonnees lst = CChampCustom.GetListeChampsForRole(CContexteDonneeSysteme.GetInstance(), CReleveEquipement.c_roleChampCustom);
            if (lst.Count == 0)
            {
                m_panelReleve.Height = m_lblSerialReleve.Height;
                m_panelOriginal.Height = m_lblSerialDB.Height;
                Height = m_panelReleve.Height + m_panelOriginal.Height;
                m_panelChampsOriginaux.Visible = false;
                m_panelChampsReleve.Visible = false;
            }
            else
            {
                foreach (CChampCustom champ in lst)
                {
                    CControleForCustomFieldReleve ctrl = new CControleForCustomFieldReleve();
                    ctrl.Init(champ);
                    m_panelChampsReleve.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Left;
                    ctrl.LockEdition = true;
                    ctrl.OnValueChanged += new EventHandler(ctrlCustom_OnValueChanged);

                    ctrl = new CControleForCustomFieldReleve();
                    ctrl.Init(champ);
                    m_panelChampsOriginaux.Controls.Add(ctrl);
                    ctrl.Dock = DockStyle.Left;
                    ctrl.LockEdition = true;
                }
                m_panelChampsOriginaux.Visible = true;
                m_panelChampsReleve.Visible = true;
            }

        }

        void ctrlCustom_OnValueChanged(object sender, EventArgs e)
        {
            if (!m_bIsInitializing)
                HasChange = true;
        }

        
    }
}
