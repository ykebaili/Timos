using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.data;
using timos.securite;
using sc2i.win32.data.dynamic;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeLienReseau))]
    public class CFormEditionTypeLienReseau : CFormEditionStdTimos, IFormNavigable
    {
        #region Designer generated code

        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_TabControl;
        private Label m_lblLabel;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private Crownwood.Magic.Controls.TabPage m_pageSupport;
        private SplitContainer splitContainer2;
        private Label label18;
        private CWndLinkStd m_lnkDeleteTypeSupporté;
        private C2iTextBoxSelectionne m_txtSelectTypeSupporté;
        private CWndLinkStd m_lnkAddTypeSupporté;
        private ListViewAutoFilled m_wndListeSupporté;
        private ListViewAutoFilledColumn listViewAutoFilledColumn6;
        private ListViewAutoFilled m_wndListeSupportant;
        private ListViewAutoFilledColumn listViewAutoFilledColumn8;
        private CWndLinkStd m_lnkDeleteTypeSupportant;
        private Label label5;
        private C2iTextBoxSelectionne m_txtSelectTypeSupportant;
        private CWndLinkStd m_lnkAddTypeSupportant;
        private System.ComponentModel.IContainer components = null;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireTypeSupporté;
        private Label label2;
        private C2iComboBox m_cmbxTypeElt2;
        private C2iComboBox m_cmbxTypeElt1;
        private Label label3;
        private PictureBox m_btnFiltreType1;
        private PictureBox m_btnFiltreType2;
        private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireTypeSupportant;

        //-------------------------------------------------------------------------
        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeLienReseau));
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbxTypeElt2 = new sc2i.win32.common.C2iComboBox();
            this.m_cmbxTypeElt1 = new sc2i.win32.common.C2iComboBox();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_btnFiltreType1 = new System.Windows.Forms.PictureBox();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageSupport = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_lnkDeleteTypeSupportant = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeSupportant = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.m_lnkAddTypeSupportant = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeSupportant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAddTypeSupporté = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDeleteTypeSupporté = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeSupporté = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_wndListeSupporté = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireTypeSupporté = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireTypeSupportant = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_btnFiltreType2 = new System.Windows.Forms.PictureBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType1)).BeginInit();
            this.m_TabControl.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.m_pageSupport.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType2)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(646, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(559, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(799, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(148, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(420, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_btnFiltreType2);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxTypeElt2);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxTypeElt1);
            this.c2iPanelOmbre4.Controls.Add(this.m_lblLabel);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_btnFiltreType1);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 43);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(601, 122);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(13, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4009;
            this.label3.Text = "Element type 2|30364";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4008;
            this.label2.Text = "Element type 1|30363";
            // 
            // m_cmbxTypeElt2
            // 
            this.m_cmbxTypeElt2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeElt2.FormattingEnabled = true;
            this.m_cmbxTypeElt2.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeElt2, "");
            this.m_cmbxTypeElt2.Location = new System.Drawing.Point(148, 68);
            this.m_cmbxTypeElt2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeElt2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeElt2, "");
            this.m_cmbxTypeElt2.Name = "m_cmbxTypeElt2";
            this.m_cmbxTypeElt2.Size = new System.Drawing.Size(273, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeElt2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeElt2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeElt2.TabIndex = 4007;
            // 
            // m_cmbxTypeElt1
            // 
            this.m_cmbxTypeElt1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeElt1.FormattingEnabled = true;
            this.m_cmbxTypeElt1.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeElt1, "");
            this.m_cmbxTypeElt1.Location = new System.Drawing.Point(148, 41);
            this.m_cmbxTypeElt1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeElt1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeElt1, "");
            this.m_cmbxTypeElt1.Name = "m_cmbxTypeElt1";
            this.m_cmbxTypeElt1.Size = new System.Drawing.Size(273, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeElt1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeElt1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeElt1.TabIndex = 4006;
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblLabel.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_btnFiltreType1
            // 
            this.m_btnFiltreType1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFiltreType1.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFiltreType1.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnFiltreType1, "");
            this.m_btnFiltreType1.Location = new System.Drawing.Point(427, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnFiltreType1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnFiltreType1, "");
            this.m_btnFiltreType1.Name = "m_btnFiltreType1";
            this.m_btnFiltreType1.Size = new System.Drawing.Size(16, 15);
            this.m_btnFiltreType1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnFiltreType1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFiltreType1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFiltreType1.TabIndex = 4010;
            this.m_btnFiltreType1.TabStop = false;
            this.m_btnFiltreType1.Click += new System.EventHandler(this.m_btnFiltreType1_Click);
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(12, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageChampsCustom;
            this.m_TabControl.Size = new System.Drawing.Size(787, 435);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageChampsCustom,
            this.m_pageSupport});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            this.m_TabControl.SelectionChanged += new System.EventHandler(this.m_TabControl_SelectionChanged);
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Size = new System.Drawing.Size(771, 394);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampsCustom.TabIndex = 12;
            this.m_pageChampsCustom.Title = "Custom fields|198";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Location = new System.Drawing.Point(3, 3);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(765, 391);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 0;
            // 
            // m_pageSupport
            // 
            this.m_pageSupport.Controls.Add(this.splitContainer2);
            this.m_extLinkField.SetLinkField(this.m_pageSupport, "");
            this.m_pageSupport.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSupport, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSupport, "");
            this.m_pageSupport.Name = "m_pageSupport";
            this.m_pageSupport.Selected = false;
            this.m_pageSupport.Size = new System.Drawing.Size(771, 394);
            this.m_extStyle.SetStyleBackColor(this.m_pageSupport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSupport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSupport.TabIndex = 13;
            this.m_pageSupport.Title = "Supported links|30351";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer2, "");
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2, "");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_lnkDeleteTypeSupportant);
            this.splitContainer2.Panel1.Controls.Add(this.m_wndListeSupportant);
            this.splitContainer2.Panel1.Controls.Add(this.label18);
            this.splitContainer2.Panel1.Controls.Add(this.m_lnkAddTypeSupportant);
            this.splitContainer2.Panel1.Controls.Add(this.m_txtSelectTypeSupportant);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_lnkAddTypeSupporté);
            this.splitContainer2.Panel2.Controls.Add(this.m_lnkDeleteTypeSupporté);
            this.splitContainer2.Panel2.Controls.Add(this.m_txtSelectTypeSupporté);
            this.splitContainer2.Panel2.Controls.Add(this.m_wndListeSupporté);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.Size = new System.Drawing.Size(771, 394);
            this.splitContainer2.SplitterDistance = 378;
            this.m_extStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.TabIndex = 19;
            // 
            // m_lnkDeleteTypeSupportant
            // 
            this.m_lnkDeleteTypeSupportant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDeleteTypeSupportant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDeleteTypeSupportant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeSupportant, "");
            this.m_lnkDeleteTypeSupportant.Location = new System.Drawing.Point(21, 333);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeSupportant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeSupportant, "");
            this.m_lnkDeleteTypeSupportant.Name = "m_lnkDeleteTypeSupportant";
            this.m_lnkDeleteTypeSupportant.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeleteTypeSupportant.TabIndex = 18;
            this.m_lnkDeleteTypeSupportant.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDeleteTypeSupportant.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeSupportant_LinkClicked);
            // 
            // m_wndListeSupportant
            // 
            this.m_wndListeSupportant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSupportant.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn8});
            this.m_wndListeSupportant.EnableCustomisation = true;
            this.m_wndListeSupportant.FullRowSelect = true;
            this.m_wndListeSupportant.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeSupportant, "");
            this.m_wndListeSupportant.Location = new System.Drawing.Point(21, 73);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSupportant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeSupportant, "");
            this.m_wndListeSupportant.MultiSelect = false;
            this.m_wndListeSupportant.Name = "m_wndListeSupportant";
            this.m_wndListeSupportant.Size = new System.Drawing.Size(273, 254);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSupportant.TabIndex = 16;
            this.m_wndListeSupportant.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSupportant.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "TypeSupportant.Libelle";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Label|50";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 200;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(18, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label18, "");
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(301, 13);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            this.label18.Text = "This link type can be supported by links of these types|30352";
            // 
            // m_lnkAddTypeSupportant
            // 
            this.m_lnkAddTypeSupportant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeSupportant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeSupportant, "");
            this.m_lnkAddTypeSupportant.Location = new System.Drawing.Point(21, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeSupportant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeSupportant, "");
            this.m_lnkAddTypeSupportant.Name = "m_lnkAddTypeSupportant";
            this.m_lnkAddTypeSupportant.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeSupportant.TabIndex = 17;
            this.m_lnkAddTypeSupportant.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeSupportant.LinkClicked += new System.EventHandler(this.m_lnkAddTypeSupportant_LinkClicked);
            // 
            // m_txtSelectTypeSupportant
            // 
            this.m_txtSelectTypeSupportant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeSupportant.ElementSelectionne = null;
            this.m_txtSelectTypeSupportant.FonctionTextNull = null;
            this.m_txtSelectTypeSupportant.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeSupportant, "");
            this.m_txtSelectTypeSupportant.Location = new System.Drawing.Point(21, 26);
            this.m_txtSelectTypeSupportant.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeSupportant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeSupportant, "");
            this.m_txtSelectTypeSupportant.Name = "m_txtSelectTypeSupportant";
            this.m_txtSelectTypeSupportant.SelectedObject = null;
            this.m_txtSelectTypeSupportant.Size = new System.Drawing.Size(188, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeSupportant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeSupportant.TabIndex = 15;
            this.m_txtSelectTypeSupportant.TextNull = "";
            // 
            // m_lnkAddTypeSupporté
            // 
            this.m_lnkAddTypeSupporté.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeSupporté.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeSupporté, "");
            this.m_lnkAddTypeSupporté.Location = new System.Drawing.Point(27, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeSupporté, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeSupporté, "");
            this.m_lnkAddTypeSupporté.Name = "m_lnkAddTypeSupporté";
            this.m_lnkAddTypeSupporté.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeSupporté.TabIndex = 12;
            this.m_lnkAddTypeSupporté.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeSupporté.LinkClicked += new System.EventHandler(this.m_lnkAddTypeSupporté_LinkClicked);
            // 
            // m_lnkDeleteTypeSupporté
            // 
            this.m_lnkDeleteTypeSupporté.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDeleteTypeSupporté.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDeleteTypeSupporté.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeSupporté, "");
            this.m_lnkDeleteTypeSupporté.Location = new System.Drawing.Point(28, 333);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeSupporté, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeSupporté, "");
            this.m_lnkDeleteTypeSupporté.Name = "m_lnkDeleteTypeSupporté";
            this.m_lnkDeleteTypeSupporté.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeleteTypeSupporté.TabIndex = 13;
            this.m_lnkDeleteTypeSupporté.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDeleteTypeSupporté.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeSupporté_LinkClicked);
            // 
            // m_txtSelectTypeSupporté
            // 
            this.m_txtSelectTypeSupporté.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeSupporté.ElementSelectionne = null;
            this.m_txtSelectTypeSupporté.FonctionTextNull = null;
            this.m_txtSelectTypeSupporté.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeSupporté, "");
            this.m_txtSelectTypeSupporté.Location = new System.Drawing.Point(28, 26);
            this.m_txtSelectTypeSupporté.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeSupporté, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeSupporté, "");
            this.m_txtSelectTypeSupporté.Name = "m_txtSelectTypeSupporté";
            this.m_txtSelectTypeSupporté.SelectedObject = null;
            this.m_txtSelectTypeSupporté.Size = new System.Drawing.Size(160, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeSupporté.TabIndex = 8;
            this.m_txtSelectTypeSupporté.TextNull = "";
            // 
            // m_wndListeSupporté
            // 
            this.m_wndListeSupporté.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSupporté.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn6});
            this.m_wndListeSupporté.EnableCustomisation = true;
            this.m_wndListeSupporté.FullRowSelect = true;
            this.m_wndListeSupporté.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeSupporté, "");
            this.m_wndListeSupporté.Location = new System.Drawing.Point(27, 73);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSupporté, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeSupporté, "");
            this.m_wndListeSupporté.MultiSelect = false;
            this.m_wndListeSupporté.Name = "m_wndListeSupporté";
            this.m_wndListeSupporté.Size = new System.Drawing.Size(266, 252);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSupporté, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSupporté.TabIndex = 11;
            this.m_wndListeSupporté.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSupporté.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "TypeSupporté.Libelle";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Label|50";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 193;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(25, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 14;
            this.label5.Text = "This link type can support links of these types|30353";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 175;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 172;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 7644;
            this.listViewAutoFilledColumn3.ProportionnalSize = true;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 7644;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Site type label:|170";
            // 
            // m_gestionnaireTypeSupporté
            // 
            this.m_gestionnaireTypeSupporté.ListeAssociee = this.m_wndListeSupporté;
            this.m_gestionnaireTypeSupporté.ObjetEdite = null;
            // 
            // m_gestionnaireTypeSupportant
            // 
            this.m_gestionnaireTypeSupportant.ListeAssociee = this.m_wndListeSupportant;
            this.m_gestionnaireTypeSupportant.ObjetEdite = null;
            // 
            // m_btnFiltreType2
            // 
            this.m_btnFiltreType2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFiltreType2.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFiltreType2.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnFiltreType2, "");
            this.m_btnFiltreType2.Location = new System.Drawing.Point(427, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnFiltreType2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnFiltreType2, "");
            this.m_btnFiltreType2.Name = "m_btnFiltreType2";
            this.m_btnFiltreType2.Size = new System.Drawing.Size(16, 15);
            this.m_btnFiltreType2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnFiltreType2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFiltreType2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFiltreType2.TabIndex = 4011;
            this.m_btnFiltreType2.TabStop = false;
            this.m_btnFiltreType2.Click += new System.EventHandler(this.m_btnFiltreType2_Click);
            // 
            // CFormEditionTypeLienReseau
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(799, 595);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeLienReseau";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeLienReseau_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeLienReseau_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType1)).EndInit();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageChampsCustom.ResumeLayout(false);
            this.m_pageSupport.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType2)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private CFiltreDynamique m_filtreElement1 = null;
        private CFiltreDynamique m_filtreElement2 = null;

        public CFormEditionTypeLienReseau()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeLienReseau(CTypeLienReseau type_lien)
            : base(type_lien)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeLienReseau(CTypeLienReseau type_lien, CListeObjetsDonnees liste)
            : base(type_lien, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        private CTypeLienReseau TypeLienReseau
        {
            get { return (CTypeLienReseau)ObjetEdite; }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            if (!result) return result;

            AffecterTitre(I.T("Network link type |30346") + TypeLienReseau.Libelle);

            InitComboTypes();

            m_cmbxTypeElt1.SelectedValue = TypeLienReseau.TypeElement1;
            m_cmbxTypeElt2.SelectedValue = TypeLienReseau.TypeElement2;

            m_filtreElement1 = TypeLienReseau.Filtre1;
            m_filtreElement2 = TypeLienReseau.Filtre2;
                     

            return result;
        }


        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
              CResultAErreur result=CResultAErreur.True;

            TypeLienReseau.TypeElement1 = (Type)m_cmbxTypeElt1.SelectedValue;
            TypeLienReseau.TypeElement2 = (Type)m_cmbxTypeElt2.SelectedValue;

            if (m_filtreElement1 != null && 
                m_filtreElement1.TypeElements == TypeLienReseau.TypeElement1 &&
                m_filtreElement1.ComposantPrincipal != null )
                TypeLienReseau.Filtre1 = m_filtreElement1;
            else
                TypeLienReseau.Filtre1 = null;

            if (m_filtreElement2 != null &&
                m_filtreElement2.TypeElements == TypeLienReseau.TypeElement2 &&
                m_filtreElement2.ComposantPrincipal != null)
                TypeLienReseau.Filtre2 = m_filtreElement2;
            else
                TypeLienReseau.Filtre2 = null;

           result= base.MAJ_Champs();
         
            return result;
        }



     

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeLienReseau_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

        
        if (page == m_pageChampsCustom)
            {
                m_panelEditChamps.InitPanel(
                    TypeLienReseau,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
            }


            if (page == m_pageSupport)
            {
                m_gestionnaireTypeSupportant.ObjetEdite= TypeLienReseau.TypesPouvantSupporterCeType;
                m_gestionnaireTypeSupporté.ObjetEdite= TypeLienReseau.TypesPouvantEtreSupportesParCeType;


                InitSelectTypesSupportants();
                InitSelectTypesSupportés();
              //  InitSelectTypeSupporte();
               // InitSelectTypeEstSupporte();
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeLienReseau_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

         
            if (page == m_pageChampsCustom)
            {
                result = m_panelEditChamps.MAJ_Champs();
            }


           
           

            return result;
        }




        

        

        //-------------------------------------------------------------------------------------
        private void InitSelectTypesSupportés()
        {
            CFiltreData filtre = null;

            string strIds = "";
            foreach (CTypeLienReseauSupport sup in TypeLienReseau.TypesPouvantEtreSupportesParCeType)
            {
                if (sup.TypeSupporté !=null)
                   
                    strIds += sup.TypeSupporté.Id + ",";
            }
            if (strIds.Length > 0)
            {
                strIds = strIds.Substring(0, strIds.Length - 1);
                filtre = new CFiltreData(CTypeLienReseau.c_champId + " not in (" + strIds + ")");
            }
            m_txtSelectTypeSupporté.InitAvecFiltreDeBase<CTypeLienReseau>(
                "Libelle",
                filtre,
                true);



        }


        private void InitComboTypes()
        {

            List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>();

            
                foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass())
                
                    if (typeof(IElementALiensReseau).IsAssignableFrom(info.Classe) && 
                        !info.Classe.IsAbstract)
                    {
                        lstTypes.Add(info);
                    }
                   lstTypes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("None|915")));
                  
                if (m_cmbxTypeElt1.Items.Count == 0)
                {
                    m_cmbxTypeElt1.DataSource = lstTypes;
                    m_cmbxTypeElt1.ValueMember = "Classe";
                    m_cmbxTypeElt1.DisplayMember = "Nom";

                }

                List<CInfoClasseDynamique> lstTypes2 = new List<CInfoClasseDynamique>();
            
                foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass())

                    if (typeof(IElementALiensReseau).IsAssignableFrom(info.Classe) &&
                        !info.Classe.IsAbstract)
                    {
                        lstTypes2.Add(info);
                    }
                lstTypes2.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("None|915")));
                  
                if (m_cmbxTypeElt2.Items.Count == 0)
                {
                    m_cmbxTypeElt2.DataSource = lstTypes2;
                    m_cmbxTypeElt2.ValueMember = "Classe";
                    m_cmbxTypeElt2.DisplayMember = "Nom";

                }
        }
        
    
        //-------------------------------------------------------------------------------------
        private void InitSelectTypesSupportants()
        {
            CFiltreData filtre = null;


            string strIds = "";
            foreach (CTypeLienReseauSupport sup in TypeLienReseau.TypesPouvantSupporterCeType)
            {
                if (sup.TypeSupportant != null)
                    strIds += sup.TypeSupportant.Id + ",";
            }
            if (strIds.Length > 0)
            {
                strIds = strIds.Substring(0, strIds.Length - 1);
                filtre = new CFiltreData(CTypeLienReseau.c_champId + " not in (" + strIds + ")");
            }
            m_txtSelectTypeSupportant.InitAvecFiltreDeBase<CTypeLienReseau>(
                "Libelle",
                filtre,
                true);
        }


        private void m_lnkAddTypeSupporté_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectTypeSupporté.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Select the link type to add|30354"), EFormAlerteType.Exclamation);
                return;
            }
            CTypeLienReseau tpLien = (CTypeLienReseau)m_txtSelectTypeSupporté.ElementSelectionne;
            CListeObjetsDonnees listeExistants = TypeLienReseau.TypesPouvantEtreSupportesParCeType;
            listeExistants.Filtre = new CFiltreData(CTypeLienReseauSupport.c_champIdTypeSupporté + "=@1",
                tpLien.Id);
            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T("Cannot add this link type because it is already in the list|30355"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectTypeSupporté.ElementSelectionne = null;
            CTypeLienReseauSupport sup = new CTypeLienReseauSupport(TypeLienReseau.ContexteDonnee);
            //CRelationTypeEquipement_TypesIncluables rel = new CRelationTypeEquipement_TypesIncluables(TypeEquipement.ContexteDonnee);
            sup.CreateNewInCurrentContexte();
            sup.TypeSupporté = tpLien;
            sup.TypeSupportant = TypeLienReseau;
           
            ListViewItem item = new ListViewItem();
            m_wndListeSupporté.Items.Add(item);
            m_wndListeSupporté.UpdateItemWithObject(item, sup);
            foreach (ListViewItem itemSel in m_wndListeSupporté.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectTypesSupportés();
        }

        private void m_lnkAddTypeSupportant_LinkClicked(object sender, EventArgs e)
        {


            if (m_txtSelectTypeSupportant.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T("Select the link type to add|30353"), EFormAlerteType.Exclamation);
                return;
            }
            CTypeLienReseau tpLien = (CTypeLienReseau)m_txtSelectTypeSupportant.ElementSelectionne;
            CListeObjetsDonnees listeExistants = TypeLienReseau.TypesPouvantSupporterCeType;
            listeExistants.Filtre = new CFiltreData(CTypeLienReseauSupport.c_champIdTypeSupportant + "=@1",
                tpLien.Id);
               
            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T("Cannot add this link type|30354"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectTypeSupportant.ElementSelectionne = null;
            CTypeLienReseauSupport sup = new CTypeLienReseauSupport(TypeLienReseau.ContexteDonnee);
            sup.CreateNewInCurrentContexte();
            sup.TypeSupportant = tpLien;
            sup.TypeSupporté = TypeLienReseau;
            ListViewItem item = new ListViewItem();
            m_wndListeSupportant.Items.Add(item);
            m_wndListeSupportant.UpdateItemWithObject(item, sup);
            foreach (ListViewItem itemSel in m_wndListeSupportant.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectTypesSupportants();



        }

        private void m_lnkDeleteTypeSupporté_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeSupporté.SelectedItems.Count != 1)
                return;

            CTypeLienReseauSupport sup = (CTypeLienReseauSupport)m_wndListeSupporté.SelectedItems[0].Tag;

            m_gestionnaireTypeSupportant.SetObjetEnCoursToNull();
            CResultAErreur result = sup.Delete(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_wndListeSupporté.SelectedItems.Count == 1)
            {
                if (m_wndListeSupporté.SelectedItems[0] != null)
                    m_wndListeSupporté.SelectedItems[0].Remove();
            }
            InitSelectTypesSupportés();
        }

        private void m_lnkDeleteTypeSupportant_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeSupportant.SelectedItems.Count != 1)
                return;

            CTypeLienReseauSupport sup =(CTypeLienReseauSupport)m_wndListeSupportant.SelectedItems[0].Tag;

            m_gestionnaireTypeSupporté.SetObjetEnCoursToNull();
           ;
            CResultAErreur result = sup.Delete(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_wndListeSupportant.SelectedItems.Count == 1)
            {
                if (m_wndListeSupportant.SelectedItems[0] != null)
                    m_wndListeSupportant.SelectedItems[0].Remove();
            }
            InitSelectTypesSupportants();
        }

        private void m_TabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_btnFiltreType1_Click(object sender, EventArgs e)
        {
            Type tp = (Type)m_cmbxTypeElt1.SelectedValue;
            if (tp != null)
            {
                if (m_filtreElement1 == null || tp != m_filtreElement1.TypeElements)
                {
                    m_filtreElement1 = new CFiltreDynamique();
                    m_filtreElement1.TypeElements = tp;
                }
                CFiltreDynamique filtreCopie = m_filtreElement1.Clone() as CFiltreDynamique;
                if (CFormEditFiltreDynamique.EditeFiltre(filtreCopie,
                    true, true, null))
                    m_filtreElement1 = filtreCopie;
            }

        }

        private void m_btnFiltreType2_Click(object sender, EventArgs e)
        {
            Type tp = (Type)m_cmbxTypeElt2.SelectedValue;
            if (tp != null)
            {
                if (m_filtreElement2 == null || tp != m_filtreElement2.TypeElements)
                {
                    m_filtreElement2 = new CFiltreDynamique();
                    m_filtreElement2.TypeElements = tp;
                }
                CFiltreDynamique filtreCopie = m_filtreElement2.Clone() as CFiltreDynamique;
                if (CFormEditFiltreDynamique.EditeFiltre(filtreCopie,
                    true, true, null))
                    m_filtreElement2 = filtreCopie;
            }
        }

     

     
    }
}

