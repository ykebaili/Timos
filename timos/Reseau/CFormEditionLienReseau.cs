using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;

using timos.data;
using timos.securite;
using System.Text;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CLienReseau))]
    public class CFormEditionLienReseau : CFormEditionStdTimos, IFormNavigable
    {
        //Si true, indique que le schéma a potientiellement changé depuis
        //Qu'on l'a calculé. (changement des extremités par exemple)
        private bool m_bSchemaAsChange = false;

        private CLienReseau m_lienSupporte = null;



        #region Designer generated code

        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panelEntete;
        private Label m_label2;
        private CComboBoxLinkListeObjetsDonnees m_cmbxTypeLienReseau;
        private C2iTabControl m_TabControl;
        private Label m_label3;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private CReducteurControle m_reducteurEntete;
        private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private Crownwood.Magic.Controls.TabPage m_pageSupporte;
        private SplitContainer splitContainer1;
        private CPanelListeSpeedStandard m_panelLienEstSupporte;
        private Label label2;
        private Label label3;
        private Crownwood.Magic.Controls.TabPage m_pageElements;
        private Label label7;
        private Label label6;
        private C2iTextBoxSelectionne m_cmbElt2;
        private C2iTextBoxSelectionne m_cmbElt1;
        private Label label5;
        private CComboboxAutoFilled m_cmbxDirection;
        private Label label4;
        private Crownwood.Magic.Controls.TabPage m_pageSchema;
        private timos.Reseau.CEditeurSchemaReseau m_editeurSchemaReseau;
        private CPanelListeSpeedStandard m_panelLienSupporte;
        private Panel m_panelComplement2;
        private Label label10;
        private Panel m_panelComplement1;
        private CComboboxAutoFilled m_cmbComplement2;
        private CComboboxAutoFilled m_cmbComplement1;
        private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private System.ComponentModel.IContainer components = null;


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionLienReseau));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelEntete = new sc2i.win32.common.C2iPanelOmbre();
            this.m_label3 = new System.Windows.Forms.Label();
            this.m_cmbxTypeLienReseau = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_label2 = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSchema = new Crownwood.Magic.Controls.TabPage();
            this.m_editeurSchemaReseau = new timos.Reseau.CEditeurSchemaReseau();
            this.m_pageElements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelComplement2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cmbComplement2 = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_panelComplement1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbComplement1 = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_cmbxDirection = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_cmbElt1 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_cmbElt2 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_pageSupporte = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelLienSupporte = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelLienEstSupporte = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_reducteurEntete = new sc2i.win32.common.CReducteurControle();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelEntete.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageSchema.SuspendLayout();
            this.m_pageElements.SuspendLayout();
            this.m_panelComplement2.SuspendLayout();
            this.m_panelComplement1.SuspendLayout();
            this.m_pageSupporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(571, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(484, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(756, 28);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
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
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(146, 10);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(330, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEntete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEntete.Controls.Add(this.m_label3);
            this.m_panelEntete.Controls.Add(this.m_cmbxTypeLienReseau);
            this.m_panelEntete.Controls.Add(this.m_txtLibelle);
            this.m_panelEntete.Controls.Add(this.m_label2);
            this.m_panelEntete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEntete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEntete, false);
            this.m_panelEntete.Location = new System.Drawing.Point(12, 43);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEntete, "");
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(744, 87);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntete.TabIndex = 0;
            // 
            // m_label3
            // 
            this.m_extLinkField.SetLinkField(this.m_label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_label3, false);
            this.m_label3.Location = new System.Drawing.Point(10, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_label3, "");
            this.m_label3.Name = "m_label3";
            this.m_label3.Size = new System.Drawing.Size(130, 13);
            this.m_extStyle.SetStyleBackColor(this.m_label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_label3.TabIndex = 10;
            this.m_label3.Text = "Network link type|30346";
            // 
            // m_cmbxTypeLienReseau
            // 
            this.m_cmbxTypeLienReseau.ComportementLinkStd = true;
            this.m_cmbxTypeLienReseau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeLienReseau.ElementSelectionne = null;
            this.m_cmbxTypeLienReseau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbxTypeLienReseau.FormattingEnabled = true;
            this.m_cmbxTypeLienReseau.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeLienReseau, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxTypeLienReseau, false);
            this.m_cmbxTypeLienReseau.LinkProperty = "";
            this.m_cmbxTypeLienReseau.ListDonnees = null;
            this.m_cmbxTypeLienReseau.Location = new System.Drawing.Point(146, 43);
            this.m_cmbxTypeLienReseau.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeLienReseau, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeLienReseau, "");
            this.m_cmbxTypeLienReseau.Name = "m_cmbxTypeLienReseau";
            this.m_cmbxTypeLienReseau.NullAutorise = false;
            this.m_cmbxTypeLienReseau.ProprieteAffichee = null;
            this.m_cmbxTypeLienReseau.ProprieteParentListeObjets = null;
            this.m_cmbxTypeLienReseau.SelectionneurParent = null;
            this.m_cmbxTypeLienReseau.Size = new System.Drawing.Size(330, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeLienReseau.TabIndex = 1;
            this.m_cmbxTypeLienReseau.TextNull = "(empty)";
            this.m_cmbxTypeLienReseau.Tri = true;
            this.m_cmbxTypeLienReseau.TypeFormEdition = null;
            this.m_cmbxTypeLienReseau.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxTypeLienReseau_SelectedValueChanged);
            // 
            // m_label2
            // 
            this.m_label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_label2, false);
            this.m_label2.Location = new System.Drawing.Point(10, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_label2, "");
            this.m_label2.Name = "m_label2";
            this.m_label2.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.m_label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_label2.TabIndex = 4005;
            this.m_label2.Text = "Label|50";
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(12, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageElements;
            this.m_TabControl.Size = new System.Drawing.Size(744, 369);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageElements,
            this.m_pageSupporte,
            this.m_pageChampsCustom,
            this.m_pageSchema});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            this.m_TabControl.SelectionChanged += new System.EventHandler(this.m_TabControl_SelectionChanged);
            // 
            // m_pageSchema
            // 
            this.m_pageSchema.Controls.Add(this.m_editeurSchemaReseau);
            this.m_extLinkField.SetLinkField(this.m_pageSchema, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSchema, false);
            this.m_pageSchema.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSchema, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSchema, "");
            this.m_pageSchema.Name = "m_pageSchema";
            this.m_pageSchema.Selected = false;
            this.m_pageSchema.Size = new System.Drawing.Size(728, 328);
            this.m_extStyle.SetStyleBackColor(this.m_pageSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSchema, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSchema.TabIndex = 13;
            this.m_pageSchema.Title = "Link diagram|30382";
            // 
            // m_editeurSchemaReseau
            // 
            this.m_editeurSchemaReseau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_editeurSchemaReseau, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_editeurSchemaReseau, false);
            this.m_editeurSchemaReseau.Location = new System.Drawing.Point(3, 3);
            this.m_editeurSchemaReseau.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurSchemaReseau, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editeurSchemaReseau, "");
            this.m_editeurSchemaReseau.Name = "m_editeurSchemaReseau";
            this.m_editeurSchemaReseau.Size = new System.Drawing.Size(722, 322);
            this.m_extStyle.SetStyleBackColor(this.m_editeurSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurSchemaReseau.TabIndex = 0;
            // 
            // m_pageElements
            // 
            this.m_pageElements.Controls.Add(this.m_panelComplement2);
            this.m_pageElements.Controls.Add(this.m_panelComplement1);
            this.m_pageElements.Controls.Add(this.m_cmbxDirection);
            this.m_pageElements.Controls.Add(this.m_cmbElt1);
            this.m_pageElements.Controls.Add(this.m_cmbElt2);
            this.m_pageElements.Controls.Add(this.label4);
            this.m_pageElements.Controls.Add(this.label5);
            this.m_pageElements.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_pageElements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageElements, false);
            this.m_pageElements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElements, "");
            this.m_pageElements.Name = "m_pageElements";
            this.m_pageElements.Size = new System.Drawing.Size(728, 328);
            this.m_extStyle.SetStyleBackColor(this.m_pageElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElements.TabIndex = 12;
            this.m_pageElements.Title = "Linked Elements|30365";
            // 
            // m_panelComplement2
            // 
            this.m_panelComplement2.Controls.Add(this.label10);
            this.m_panelComplement2.Controls.Add(this.m_cmbComplement2);
            this.m_extLinkField.SetLinkField(this.m_panelComplement2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelComplement2, false);
            this.m_panelComplement2.Location = new System.Drawing.Point(372, 90);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelComplement2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelComplement2, "");
            this.m_panelComplement2.Name = "m_panelComplement2";
            this.m_panelComplement2.Size = new System.Drawing.Size(221, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelComplement2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelComplement2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelComplement2.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 15);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 29;
            this.label10.Text = "/";
            // 
            // m_cmbComplement2
            // 
            this.m_cmbComplement2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbComplement2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbComplement2.FormattingEnabled = true;
            this.m_cmbComplement2.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbComplement2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbComplement2, false);
            this.m_cmbComplement2.ListDonnees = null;
            this.m_cmbComplement2.Location = new System.Drawing.Point(15, 0);
            this.m_cmbComplement2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbComplement2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbComplement2, "");
            this.m_cmbComplement2.Name = "m_cmbComplement2";
            this.m_cmbComplement2.NullAutorise = false;
            this.m_cmbComplement2.ProprieteAffichee = null;
            this.m_cmbComplement2.Size = new System.Drawing.Size(203, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbComplement2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbComplement2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbComplement2.TabIndex = 37;
            this.m_cmbComplement2.TextNull = "(empty)";
            this.m_cmbComplement2.Tri = false;
            this.m_cmbComplement2.SelectedIndexChanged += new System.EventHandler(this.m_cmbComplement2_SelectedIndexChanged);
            // 
            // m_panelComplement1
            // 
            this.m_panelComplement1.Controls.Add(this.label7);
            this.m_panelComplement1.Controls.Add(this.m_cmbComplement1);
            this.m_extLinkField.SetLinkField(this.m_panelComplement1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelComplement1, false);
            this.m_panelComplement1.Location = new System.Drawing.Point(372, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelComplement1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelComplement1, "");
            this.m_panelComplement1.Name = "m_panelComplement1";
            this.m_panelComplement1.Size = new System.Drawing.Size(221, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelComplement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelComplement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelComplement1.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 15);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 29;
            this.label7.Text = "/";
            // 
            // m_cmbComplement1
            // 
            this.m_cmbComplement1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbComplement1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbComplement1.FormattingEnabled = true;
            this.m_cmbComplement1.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbComplement1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbComplement1, false);
            this.m_cmbComplement1.ListDonnees = null;
            this.m_cmbComplement1.Location = new System.Drawing.Point(15, 0);
            this.m_cmbComplement1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbComplement1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbComplement1, "");
            this.m_cmbComplement1.Name = "m_cmbComplement1";
            this.m_cmbComplement1.NullAutorise = false;
            this.m_cmbComplement1.ProprieteAffichee = null;
            this.m_cmbComplement1.Size = new System.Drawing.Size(203, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbComplement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbComplement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbComplement1.TabIndex = 36;
            this.m_cmbComplement1.TextNull = "(empty)";
            this.m_cmbComplement1.Tri = false;
            this.m_cmbComplement1.SelectedIndexChanged += new System.EventHandler(this.m_cmbComplement1_SelectedIndexChanged);
            // 
            // m_cmbxDirection
            // 
            this.m_cmbxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbxDirection.FormattingEnabled = true;
            this.m_cmbxDirection.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxDirection, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxDirection, false);
            this.m_cmbxDirection.ListDonnees = null;
            this.m_cmbxDirection.Location = new System.Drawing.Point(146, 16);
            this.m_cmbxDirection.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxDirection, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxDirection, "");
            this.m_cmbxDirection.Name = "m_cmbxDirection";
            this.m_cmbxDirection.NullAutorise = false;
            this.m_cmbxDirection.ProprieteAffichee = null;
            this.m_cmbxDirection.Size = new System.Drawing.Size(180, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxDirection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxDirection, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxDirection.TabIndex = 23;
            this.m_cmbxDirection.TextNull = "(empty)";
            this.m_cmbxDirection.Tri = false;
            // 
            // m_cmbElt1
            // 
            this.m_cmbElt1.ElementSelectionne = null;
            this.m_cmbElt1.FonctionTextNull = null;
            this.m_cmbElt1.HasLink = true;
            this.m_cmbElt1.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_cmbElt1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbElt1, false);
            this.m_cmbElt1.Location = new System.Drawing.Point(154, 53);
            this.m_cmbElt1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbElt1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbElt1, "");
            this.m_cmbElt1.Name = "m_cmbElt1";
            this.m_cmbElt1.SelectedObject = null;
            this.m_cmbElt1.Size = new System.Drawing.Size(212, 21);
            this.m_cmbElt1.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_cmbElt1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbElt1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbElt1.TabIndex = 25;
            this.m_cmbElt1.TextNull = "";
            this.m_cmbElt1.OnSelectedObjectChanged += new System.EventHandler(this.m_cmbElt1_OnSelectedObjectChanged);
            // 
            // m_cmbElt2
            // 
            this.m_cmbElt2.ElementSelectionne = null;
            this.m_cmbElt2.FonctionTextNull = null;
            this.m_cmbElt2.HasLink = true;
            this.m_cmbElt2.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_cmbElt2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbElt2, false);
            this.m_cmbElt2.Location = new System.Drawing.Point(154, 90);
            this.m_cmbElt2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbElt2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbElt2, "");
            this.m_cmbElt2.Name = "m_cmbElt2";
            this.m_cmbElt2.SelectedObject = null;
            this.m_cmbElt2.Size = new System.Drawing.Size(212, 21);
            this.m_cmbElt2.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_cmbElt2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbElt2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbElt2.TabIndex = 26;
            this.m_cmbElt2.TextNull = "";
            this.m_cmbElt2.OnSelectedObjectChanged += new System.EventHandler(this.m_cmbElt2_OnSelectedObjectChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(25, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 22;
            this.label4.Text = "Link Direction|30366";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(25, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 24;
            this.label5.Text = "Element 1|30367";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(25, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 27;
            this.label6.Text = "Element 2|30368";
            // 
            // m_pageSupporte
            // 
            this.m_pageSupporte.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_pageSupporte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSupporte, false);
            this.m_pageSupporte.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSupporte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSupporte, "");
            this.m_pageSupporte.Name = "m_pageSupporte";
            this.m_pageSupporte.Selected = false;
            this.m_pageSupporte.Size = new System.Drawing.Size(728, 328);
            this.m_extStyle.SetStyleBackColor(this.m_pageSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSupporte.TabIndex = 11;
            this.m_pageSupporte.Title = "Supported links|30351";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.splitContainer1.Location = new System.Drawing.Point(4, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.m_panelLienSupporte);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.m_panelLienEstSupporte);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(724, 322);
            this.splitContainer1.SplitterDistance = 161;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Supported links|30356";
            // 
            // m_panelLienSupporte
            // 
            this.m_panelLienSupporte.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelLienSupporte.AffectationsPourNouveauxElements")));
            this.m_panelLienSupporte.AllowArbre = true;
            this.m_panelLienSupporte.AllowCustomisation = true;
            this.m_panelLienSupporte.AllowSerializePreferences = true;
            this.m_panelLienSupporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLienSupporte.BoutonAjouterVisible = false;
            this.m_panelLienSupporte.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Libelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelLienSupporte.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelLienSupporte.ContexteUtilisation = "";
            this.m_panelLienSupporte.ControlFiltreStandard = null;
            this.m_panelLienSupporte.ElementSelectionne = null;
            this.m_panelLienSupporte.EnableCustomisation = true;
            this.m_panelLienSupporte.FiltreDeBase = null;
            this.m_panelLienSupporte.FiltreDeBaseEnAjout = false;
            this.m_panelLienSupporte.FiltrePrefere = null;
            this.m_panelLienSupporte.FiltreRapide = null;
            this.m_panelLienSupporte.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelLienSupporte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLienSupporte, false);
            this.m_panelLienSupporte.ListeObjets = null;
            this.m_panelLienSupporte.Location = new System.Drawing.Point(0, 16);
            this.m_panelLienSupporte.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLienSupporte, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelLienSupporte.ModeQuickSearch = false;
            this.m_panelLienSupporte.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelLienSupporte, "");
            this.m_panelLienSupporte.MultiSelect = false;
            this.m_panelLienSupporte.Name = "m_panelLienSupporte";
            this.m_panelLienSupporte.Navigateur = null;
            this.m_panelLienSupporte.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelLienSupporte.ProprieteObjetAEditer = null;
            this.m_panelLienSupporte.QuickSearchText = "";
            this.m_panelLienSupporte.ShortIcons = false;
            this.m_panelLienSupporte.Size = new System.Drawing.Size(721, 142);
            this.m_extStyle.SetStyleBackColor(this.m_panelLienSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLienSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLienSupporte.TabIndex = 1;
            this.m_panelLienSupporte.TrierAuClicSurEnteteColonne = true;
            this.m_panelLienSupporte.UseCheckBoxes = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 3;
            this.label3.Text = "Supporting links|30357";
            // 
            // m_panelLienEstSupporte
            // 
            this.m_panelLienEstSupporte.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelLienEstSupporte.AffectationsPourNouveauxElements")));
            this.m_panelLienEstSupporte.AllowArbre = true;
            this.m_panelLienEstSupporte.AllowCustomisation = true;
            this.m_panelLienEstSupporte.AllowSerializePreferences = true;
            this.m_panelLienEstSupporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLienEstSupporte.BoutonAjouterVisible = false;
            this.m_panelLienEstSupporte.BoutonSupprimerVisible = false;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Libelle";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelLienEstSupporte.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelLienEstSupporte.ContexteUtilisation = "";
            this.m_panelLienEstSupporte.ControlFiltreStandard = null;
            this.m_panelLienEstSupporte.ElementSelectionne = null;
            this.m_panelLienEstSupporte.EnableCustomisation = true;
            this.m_panelLienEstSupporte.FiltreDeBase = null;
            this.m_panelLienEstSupporte.FiltreDeBaseEnAjout = false;
            this.m_panelLienEstSupporte.FiltrePrefere = null;
            this.m_panelLienEstSupporte.FiltreRapide = null;
            this.m_panelLienEstSupporte.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelLienEstSupporte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelLienEstSupporte, false);
            this.m_panelLienEstSupporte.ListeObjets = null;
            this.m_panelLienEstSupporte.Location = new System.Drawing.Point(0, 16);
            this.m_panelLienEstSupporte.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLienEstSupporte, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelLienEstSupporte.ModeQuickSearch = false;
            this.m_panelLienEstSupporte.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelLienEstSupporte, "");
            this.m_panelLienEstSupporte.MultiSelect = false;
            this.m_panelLienEstSupporte.Name = "m_panelLienEstSupporte";
            this.m_panelLienEstSupporte.Navigateur = null;
            this.m_panelLienEstSupporte.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelLienEstSupporte.ProprieteObjetAEditer = null;
            this.m_panelLienEstSupporte.QuickSearchText = "";
            this.m_panelLienEstSupporte.ShortIcons = false;
            this.m_panelLienEstSupporte.Size = new System.Drawing.Size(721, 138);
            this.m_extStyle.SetStyleBackColor(this.m_panelLienEstSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLienEstSupporte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLienEstSupporte.TabIndex = 2;
            this.m_panelLienEstSupporte.TrierAuClicSurEnteteColonne = true;
            this.m_panelLienEstSupporte.UseCheckBoxes = false;
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Selected = false;
            this.m_pageChampsCustom.Size = new System.Drawing.Size(728, 328);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampsCustom.TabIndex = 10;
            this.m_pageChampsCustom.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(728, 328);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 0;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 144D;
            this.listViewAutoFilledColumn1.ProportionnalSize = true;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 144;
            // 
            // m_reducteurEntete
            // 
            this.m_reducteurEntete.ControleAgrandit = this.m_TabControl;
            this.m_reducteurEntete.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurEntete.ControleReduit = this.m_panelEntete;
            this.m_extLinkField.SetLinkField(this.m_reducteurEntete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_reducteurEntete, false);
            this.m_reducteurEntete.Location = new System.Drawing.Point(380, 39);
            this.m_reducteurEntete.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurEntete.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurEntete, "");
            this.m_reducteurEntete.Name = "m_reducteurEntete";
            this.m_reducteurEntete.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurEntete.TabIndex = 4014;
            this.m_reducteurEntete.TailleReduite = 32;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_editeurSchemaReseau.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // CFormEditionLienReseau
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(756, 500);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.m_reducteurEntete);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionLienReseau";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLienReseau_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLienReseau_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_reducteurEntete, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelEntete, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelEntete.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageSchema.ResumeLayout(false);
            this.m_pageElements.ResumeLayout(false);
            this.m_pageElements.PerformLayout();
            this.m_panelComplement2.ResumeLayout(false);
            this.m_panelComplement2.PerformLayout();
            this.m_panelComplement1.ResumeLayout(false);
            this.m_panelComplement1.PerformLayout();
            this.m_pageSupporte.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_pageChampsCustom.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        private CFiltreData m_filtreTypeLien = null;

        public CFormEditionLienReseau()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionLienReseau(CLienReseau lienreseau)
            : base(lienreseau)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionLienReseau(CLienReseau lienreseau, CLienReseau lienSupporte)
            : base(lienreseau)
        {
            m_lienSupporte = lienSupporte;
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionLienReseau(CLienReseau lienreseau, CListeObjetsDonnees liste)
            : base(lienreseau, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }

        //-------------------------------------------------------------------------
        private CLienReseau LienReseau
        {
            get { return (CLienReseau)ObjetEdite; }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = CResultAErreur.True;

            result = base.MyInitChamps();

            if (!result)
                return result;

            AffecterTitre(I.T("Network link |30344") + " " + LienReseau.Libelle);



            result = InitSelectTypeLienReseau();
            if (LienReseau.TypeLienReseau != null)
                m_cmbxTypeLienReseau.ElementSelectionne = LienReseau.TypeLienReseau;
            else
                if ( m_cmbxTypeLienReseau.ElementSelectionne != null )
                    LienReseau.TypeLienReseau = m_cmbxTypeLienReseau.ElementSelectionne as CTypeLienReseau;
         
            DisplayOrHidePanelChamps();
            return result;
        }

        
        //------------------------------------------------------------------------------------
        private void DisplayOrHidePanelChamps()
        {
            if (LienReseau.GetFormulaires().Length == 0)
            {
                if (m_TabControl.TabPages.Contains(m_pageChampsCustom))
                    m_TabControl.TabPages.Remove(m_pageChampsCustom);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(m_pageChampsCustom))
                    m_TabControl.TabPages.Insert(0, m_pageChampsCustom);
            }
        }



        //------------------------------------------------------------------------------------
        private void InitPanelChamps()
        {
            // Initialise le panel des champs personalisés (custom)
            DisplayOrHidePanelChamps();
            if (LienReseau.TypeLienReseau != null)
                m_panelChamps.ElementEdite = LienReseau;
        }


        //---------------------------------------------------------------------------------------
        private CResultAErreur InitSelectTypeLienReseau()
        {
            CResultAErreur result = CResultAErreur.True;

            m_filtreTypeLien = GetFiltreTypes();
            //Initialise la liste des types de liens possibles
            CListeObjetsDonnees liste_type = new CListeObjetsDonnees(LienReseau.ContexteDonnee, typeof(CTypeLienReseau));

            if (m_filtreTypeLien == null )

                m_cmbxTypeLienReseau.Init(
                    liste_type,
                    "Libelle",
                    typeof(CFormEditionTypeLienReseau),
                    true);

            else

                m_cmbxTypeLienReseau.Init(
                    typeof(CTypeLienReseau),
                    m_filtreTypeLien,
                    "Libelle",
                       true);


            return result;
        }



        private CFiltreData GetFiltreTypes()
        {

            CFiltreData filtre = null;
            if (m_lienSupporte != null && m_lienSupporte.TypeLienReseau != null)
            {
                StringBuilder bl = new StringBuilder();
                foreach (CTypeLienReseauSupport typeSupport in m_lienSupporte.TypeLienReseau.TypesPouvantSupporterCeType)
                {
                    bl.Append(typeSupport.TypeSupportant.Id);
                    bl.Append(',');
                }
                if (bl.Length > 0)
                {
                    bl.Remove(bl.Length - 1, 1);
                    filtre = new CFiltreData(CTypeLienReseau.c_champId + " in (" + bl.ToString() + ")");
                }
            }

            if (LienReseau != null)
            {
                if (LienReseau.Element1 != null)
                {
                    filtre = CFiltreData.GetAndFiltre ( filtre, new CFiltreData(CTypeLienReseau.c_champTypeElement1 + "=@1 ", LienReseau.Element1.GetType().ToString()));
                }
                else if (LienReseau.Element2 !=null)
                {
                    filtre = new CFiltreData(CTypeLienReseau.c_champTypeElement2 + "=@2 ", LienReseau.Element2.GetType().ToString());
                   
                }
            }
            return filtre;
        }


        //------------------------------ TAB CONTROL ----------------------------------
        private CResultAErreur CFormEditionLienReseau_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pageChampsCustom)
            {
                InitPanelChamps();
            }

            else if (page == m_pageSupporte)
            {
                /*   m_panelLienSupporte.ListeObjets = LienReseau.LiensSupportes;
               
                   m_panelLienSupporte.RemplirGrille();*/

                m_panelLienSupporte.InitFromListeObjets(LienReseau.LiensSupportes,
                    typeof(CLienReseau),
                    typeof(CFormEditionLienReseau),
                    LienReseau,
                    "LienReseau");


                m_panelLienEstSupporte.InitFromListeObjets(LienReseau.LiensSupportants,
                    typeof(CLienReseau),
                    typeof(CFormEditionLienReseau),
                    LienReseau,
                    "LienReseau");

              
            }

            else if (page == m_pageElements)
            {
                InitPageElements();
               
            }


            else if (page == m_pageSchema)
            {
                InitSchema();

            }

            return result;
        }

        //initialise les combos "Elements" et "compléments" avec la liste des types possibles
        //suivant le type du lien
        private void InitPageElements()
        {


            m_cmbxDirection.Fill(
                  CUtilSurEnum.GetEnumsALibelle(typeof(CDirectionLienReseau)),
                  "Libelle",
                  false);
            m_cmbxDirection.SelectedValue = LienReseau.Direction;

            if (LienReseau.TypeLienReseau != null)
            {
                if (LienReseau.TypeLienReseau.TypeElement1 != null)
                {
                    Type typeElt1 = LienReseau.TypeLienReseau.TypeElement1;
                   
                    CFiltreData filtreMain = null;
                    if (LienReseau.TypeLienReseau.Filtre1 != null)
                    {
                        CResultAErreur result = LienReseau.TypeLienReseau.Filtre1.GetFiltreData();
                        if (result)
                            filtreMain = result.Data as CFiltreData;
                    }
                    CFiltreData filtre1 = null;
                    if (filtreMain != null)
                        filtre1 = filtreMain;

                    m_cmbElt1.InitForSelectAvecFiltreDeBase(typeElt1, "Libelle", filtre1, true);

                    //   m_cmbElt1.ElementSelectionne = (CObjetDonnee)LienReseau.Element1;

                }



                if (LienReseau.TypeLienReseau.TypeElement2 != null)
                {

                    Type typeElt2 = LienReseau.TypeLienReseau.TypeElement2;
                    CFiltreData filtreMain = null;
                    if (LienReseau.TypeLienReseau.Filtre2 != null)
                    {
                        CResultAErreur result = LienReseau.TypeLienReseau.Filtre2.GetFiltreData();
                        if (result)
                            filtreMain = result.Data as CFiltreData;
                    }
                    CFiltreData filtre2 = null;
                    if (filtreMain != null)
                        filtre2 = filtreMain;

                    m_cmbElt2.InitForSelectAvecFiltreDeBase(typeElt2, "Libelle", filtre2, true);

                    //    m_cmbElt2.ElementSelectionne = (CObjetDonnee)LienReseau.Element2;

                }
                m_cmbElt1.ElementSelectionne = (CObjetDonnee)LienReseau.Element1;
                m_cmbElt2.ElementSelectionne = (CObjetDonnee)LienReseau.Element2;

                InitComplements1();
                if (LienReseau.Complement1 != null)
                    m_cmbComplement1.SelectedValue = (CObjetDonnee)LienReseau.Complement1;
                InitComplements2();
                if (LienReseau.Complement2 != null)
                    m_cmbComplement2.SelectedValue = (CObjetDonnee)LienReseau.Complement2;
            }


        }




        //initialise le schéma du lien
        private void InitSchema()
        {
            if (m_TabControl.SelectedTab != null && m_TabControl.SelectedTab == m_pageSchema)
            {
                m_editeurSchemaReseau.Init(null, null);
                if (LienReseau != null)
                {
                    if (LienReseau.Element1 != null && LienReseau.Element2 != null)
                    {

                        C2iSchemaReseau schemaADessiner = LienReseau.GetSchemaReseauADessiner(m_gestionnaireModeEdition.ModeEdition);
                        CSchemaReseau schema = LienReseau.SchemaReseau;

                        if (schemaADessiner != null && schema != null)
                            m_editeurSchemaReseau.Init(schemaADessiner, schema);
                        m_bSchemaAsChange = false;

                    }
                }
            }
            else
                m_bSchemaAsChange = true;
        }

        //------------------------------------------------
        //initialise la combo des compléments du lien 1 avec les compléments possibles
        //correspondant à l'élément 1 sélectionné 
        private void InitComplements1()
        {
            if (LienReseau != null && LienReseau.Element1 != null)
            {
                IComplementElementALiensReseau[] complements = LienReseau.Element1.ComplementsPossibles;
                if (complements != null && complements.Length != 0)
                {
                    m_cmbComplement1.Fill(complements, "Libelle", true);
                    m_cmbComplement1.SelectedValue = null;
                    m_panelComplement1.Visible = true;
                    foreach (IComplementElementALiensReseau complement in complements)
                        if (complements.Equals(LienReseau.Complement2))
                            m_cmbComplement1.SelectedValue = complement;
                    return;
                }
            }
            m_cmbComplement1.SelectedValue = null;
            m_panelComplement1.Visible = false;
        }


        //------------------------------------------------
        private void InitComplements2()
        {
            if (LienReseau != null && LienReseau.Element2 != null)
            {
                IComplementElementALiensReseau[] complements = LienReseau.Element2.ComplementsPossibles;
                if ( complements != null && complements.Length != 0 )
                {
                    m_cmbComplement2.Fill ( complements, "Libelle", true );
                    m_cmbComplement2.SelectedValue = null;
                    m_panelComplement2.Visible = true;
                    foreach (IComplementElementALiensReseau complement in complements)
                        if (complements.Equals(LienReseau.Complement1))
                            m_cmbComplement2.SelectedValue = complement;
                    return;
                }
            }
            m_cmbComplement2.SelectedValue = null;
            m_panelComplement2.Visible = false;
        }

        private CResultAErreur CFormEditionLienReseau_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageChampsCustom)
                result = m_panelChamps.MAJ_Champs();

            if (page == m_pageElements)
            {
                if (LienReseau != null)
                {
                    LienReseau.Direction = (CDirectionLienReseau)m_cmbxDirection.SelectedValue;
                    LienReseau.Element1 = (IElementALiensReseau)m_cmbElt1.ElementSelectionne;
                    LienReseau.Element2 = (IElementALiensReseau)m_cmbElt2.ElementSelectionne;

                    LienReseau.Complement1 = m_cmbComplement1.SelectedValue as IComplementElementALiensReseau;

                    LienReseau.Complement2 = m_cmbComplement2.SelectedValue as IComplementElementALiensReseau;

                }

            }

            if (page == m_pageSchema)
            {
                MAJPageSchema();
            }

            return result;
        }

        //mise à jour du schéma
        private void MAJPageSchema()
        {

            if (LienReseau != null)
            {
                if (LienReseau.SchemaReseau != null)
                {
                    C2iSchemaReseau schemaLien = m_editeurSchemaReseau.ObjetDeSchema as C2iSchemaReseau;
                    
                    LienReseau.SchemaReseau.SetSchema(schemaLien);
                    LienReseau.SchemaReseau.VerifieDonnees(true);
                }

            }

        }


        //met un filtre sur la combo des types de liens
        //utilisé avec l'éditeur de schéma pour filtrer uniquement les types de lien
        //qui correspondent aux éléments sélectionnées dans l'éditeur
        public void SetFiltreTypeLien(CFiltreData filtre)
        {

            m_filtreTypeLien = filtre;


        }

        //bloque les combos des éléments
        //utilisé avec l'éditeur de schémas pour ne pas que l'utilisateur
        //sélectionne d'autres éléments que ceux sélectionnés dans le schéma
        public void LockComboElements()
        {
            m_gestionnaireModeEdition.SetModeEdition(m_cmbElt1, TypeModeEdition.Autonome);
            m_gestionnaireModeEdition.SetModeEdition(m_cmbElt2, TypeModeEdition.Autonome);


        }

        //changement de l'élément 1
        // réinitilalisation des compléments de l'élément 1
        // et redessin du schéma pour y ajouté le nouvel élément sélectionné
        private void m_cmbElt1_OnSelectedObjectChanged(object sender, EventArgs e)
        {
           
            if (m_cmbElt1.ElementSelectionne != null)
            {
                if (LienReseau.Element1 == null || LienReseau.Element1.Id != ((IElementALiensReseau)m_cmbElt1.ElementSelectionne).Id)
                {
                    CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CElementDeSchemaReseau));
                    lst.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", LienReseau.Id);
                    bool bOk = true;
                    foreach ( CElementDeSchemaReseau elt in lst )
                        if (elt.RacineChemin1 != null)
                        {
                            bOk = false;
                            break;
                        }
                    if ( !bOk )
                    {
                        CFormAlerte.Afficher(I.T("Impossible to change Element1 because it is associated with a path|30398"));
                        m_cmbElt1.ElementSelectionne =(CObjetDonnee) LienReseau.Element1;
                        return;
                     }
                

                    LienReseau.Element1 = (IElementALiensReseau)m_cmbElt1.ElementSelectionne;
                    InitSchema();
                }
            }
            InitComplements1();
        }

        private void m_cmbElt2_OnSelectedObjectChanged(object sender, EventArgs e)
        {
           
            if (m_cmbElt2.ElementSelectionne != null)
            {
              
                if (LienReseau.Element2 == null || LienReseau.Element2.Id != ((IElementALiensReseau)m_cmbElt2.ElementSelectionne).Id)
                {
                    CListeObjetsDonnees lst = new CListeObjetsDonnees(ContexteDonnee, typeof(CElementDeSchemaReseau));
                    lst.Filtre = new CFiltreData(CLienReseau.c_champId + "=@1", LienReseau.Id);
                    bool bOk = true;
                    foreach (CElementDeSchemaReseau elt in lst)
                        if (elt.RacineChemin1 != null)
                        {
                            bOk = false;
                            break;
                        }
                    if (!bOk)
                    {
                        CFormAlerte.Afficher(I.T("Impossible to change Element2 because it is associated with a path|30398"));
                        m_cmbElt2.ElementSelectionne =(CObjetDonnee) LienReseau.Element2;
                        return;
                    }
                    LienReseau.Element2 = (IElementALiensReseau)m_cmbElt2.ElementSelectionne;
                    InitSchema();
                }
            }
            InitComplements2();
        }


        //changement du type de lien
        //on réinitialise les éléments s'il ne correspondent plus au type de lien
        //et on réinitialise le formulair
        private void m_cmbxTypeLienReseau_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_cmbxTypeLienReseau.ElementSelectionne != null)
            {

                if (LienReseau.TypeLienReseau != null)
                {
                    if (LienReseau.TypeLienReseau.TypeElement1 != ((CTypeLienReseau)m_cmbxTypeLienReseau.ElementSelectionne).TypeElement1)
                    {
                        LienReseau.Element1 = null;
                        LienReseau.Complement1 = null;
                    }

                    if (LienReseau.TypeLienReseau.TypeElement2 != ((CTypeLienReseau)m_cmbxTypeLienReseau.ElementSelectionne).TypeElement2)
                    {
                        LienReseau.Element2 = null;
                        LienReseau.Complement2 = null;
                    }
                }
                LienReseau.TypeLienReseau = (CTypeLienReseau)m_cmbxTypeLienReseau.ElementSelectionne;
                InitPageElements();
                InitPanelChamps();


            }
        }


        //-------------------------------------------------------------------------
        private void m_TabControl_SelectionChanged(object sender, EventArgs e)
        {
            if (m_TabControl.SelectedTab == m_pageSchema)
            {
                if (m_bSchemaAsChange)
                    InitSchema();
            }
        }

        private void m_cmbComplement1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_cmbComplement2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

