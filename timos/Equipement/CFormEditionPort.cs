using System;
using System.Collections;
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

using timos.data;
using timos.Equipement;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CPort))]
    public class CFormEditionPort : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private C2iTabControl m_tabControl;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private Crownwood.Magic.Controls.TabPage m_pagePrporietes;
        private C2iTextBox m_txtCode;
        private Label m_labelCode;
        private CPanelSymboleElement m_panelSymbole;
        private LinkLabel m_linkTypeq;
        private LinkLabel linkLabel1;
        private Label label2;
        private Label label3;
        private CComboBoxLinkListeObjetsDonnees m_cmbTypePort;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionPort()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionPort(CPort Port)
            : base(Port)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionPort(CPort Port, CListeObjetsDonnees liste)
            : base(Port, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
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

        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_labelCode = new System.Windows.Forms.Label();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_linkTypeq = new System.Windows.Forms.LinkLabel();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pagePrporietes = new Crownwood.Magic.Controls.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbTypePort = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pagePrporietes.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(677, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(590, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
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
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(104, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(262, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_cmbTypePort);
            this.m_panTop.Controls.Add(this.m_labelCode);
            this.m_panTop.Controls.Add(this.m_txtCode);
            this.m_panTop.Controls.Add(this.label2);
            this.m_panTop.Controls.Add(this.label3);
            this.m_panTop.Controls.Add(this.label1);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_linkTypeq);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(704, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_labelCode
            // 
            this.m_labelCode.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelCode, "");
            this.m_labelCode.Location = new System.Drawing.Point(16, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelCode, "");
            this.m_labelCode.Name = "m_labelCode";
            this.m_labelCode.Size = new System.Drawing.Size(46, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelCode.TabIndex = 4004;
            this.m_labelCode.Text = "Code|40";
            // 
            // m_txtCode
            // 
            this.m_extLinkField.SetLinkField(this.m_txtCode, "Code");
            this.m_txtCode.Location = new System.Drawing.Point(104, 34);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(262, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 1;
            this.m_txtCode.Text = "[Code]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(413, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 7;
            this.label2.Text = "Equipment type|194";
            // 
            // m_linkTypeq
            // 
            this.m_linkTypeq.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_linkTypeq, "");
            this.m_linkTypeq.Location = new System.Drawing.Point(540, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkTypeq, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_linkTypeq, "");
            this.m_linkTypeq.Name = "m_linkTypeq";
            this.m_linkTypeq.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkTypeq, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkTypeq, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkTypeq.TabIndex = 3;
            this.m_linkTypeq.TabStop = true;
            this.m_linkTypeq.Text = "linkLabel1";
            this.m_linkTypeq.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkTypeq_LinkClicked);
            // 
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pagePrporietes;
            this.m_tabControl.Size = new System.Drawing.Size(822, 372);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pagePrporietes});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pagePrporietes
            // 
            this.m_pagePrporietes.Controls.Add(this.linkLabel1);
            this.m_pagePrporietes.Controls.Add(this.m_panelSymbole);
            this.m_extLinkField.SetLinkField(this.m_pagePrporietes, "");
            this.m_pagePrporietes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePrporietes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePrporietes, "");
            this.m_pagePrporietes.Name = "m_pagePrporietes";
            this.m_pagePrporietes.Size = new System.Drawing.Size(806, 331);
            this.m_extStyle.SetStyleBackColor(this.m_pagePrporietes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePrporietes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePrporietes.TabIndex = 10;
            this.m_pagePrporietes.Title = "Properties|1234";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.linkLabel1, "");
            this.linkLabel1.Location = new System.Drawing.Point(198, 173);
            this.m_gestionnaireModeEdition.SetModeEdition(this.linkLabel1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.linkLabel1, "");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 13);
            this.m_extStyle.SetStyleBackColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.linkLabel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Edit Port Position|30341";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // m_panelSymbole
            // 
            this.m_panelSymbole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_panelSymbole.Location = new System.Drawing.Point(0, 0);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(736, 208);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 2;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeEquipement.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 200;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Port type|50004";
            // 
            // m_cmbTypePort
            // 
            this.m_cmbTypePort.ComportementLinkStd = true;
            this.m_cmbTypePort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypePort.ElementSelectionne = null;
            this.m_cmbTypePort.FormattingEnabled = true;
            this.m_cmbTypePort.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypePort, "");
            this.m_cmbTypePort.LinkProperty = "";
            this.m_cmbTypePort.ListDonnees = null;
            this.m_cmbTypePort.Location = new System.Drawing.Point(103, 62);
            this.m_cmbTypePort.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypePort, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypePort, "");
            this.m_cmbTypePort.Name = "m_cmbTypePort";
            this.m_cmbTypePort.NullAutorise = true;
            this.m_cmbTypePort.ProprieteAffichee = null;
            this.m_cmbTypePort.ProprieteParentListeObjets = null;
            this.m_cmbTypePort.SelectionneurParent = null;
            this.m_cmbTypePort.Size = new System.Drawing.Size(263, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypePort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypePort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypePort.TabIndex = 2;
            this.m_cmbTypePort.TextNull = "(empty)";
            this.m_cmbTypePort.Tri = true;
            this.m_cmbTypePort.TypeFormEdition = null;
            // 
            // CFormEditionPort
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionPort";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pagePrporietes.ResumeLayout(false);
            this.m_pagePrporietes.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CPort Port
        {
            get
            {
                return (CPort)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Port|30337") + " " + Port.Libelle);

            result = m_panelSymbole.InitChamps(Port, null);
           
            if (Port!= null)
            {
                if (Port.TypeEquipement != null)
                   m_linkTypeq.Text = Port.TypeEquipement.Libelle;
            }

            m_cmbTypePort.Init(typeof(CTypePort), "Libelle", false);
            m_cmbTypePort.ElementSelectionne = Port.TypePort;

            return result;
        }


     
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            Port.TypePort = m_cmbTypePort.ElementSelectionne as CTypePort;


            result = m_panelSymbole.MAJ_Champs();

            return result;
        }

        private void m_linkTypeq_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CReferenceTypeForm reference;


            if (Port.TypeEquipement != null)
            {
                CObjetDonneeAIdNumeriqueAuto objetAEditer = (CObjetDonneeAIdNumeriqueAuto)Port.TypeEquipement;


                reference = CFormFinder.GetRefFormToEdit(typeof(CTypeEquipement));
                if (reference != null)
                {
                    CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;

                    if (frm != null)
                        Navigateur.AffichePage(frm);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            C2iSymbole symbolePorts = new C2iSymbole();

            if(Port!=null)
            
                if(Port.TypeEquipement!=null)
                {
                    CPositionneurPorts.PositionnePorts(Port.TypeEquipement);
                     /*symbolePorts = CFormEditeurSymbolePopup.EditeSymbole(Port.SymboleTypeqADessiner, typeof(CTypeEquipement), true);*/
                     m_panelSymbole.RefreshSymbole();
                     

                  }

        }

    
    }
}

