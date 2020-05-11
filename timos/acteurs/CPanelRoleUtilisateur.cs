using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using sc2i.data;
using sc2i.common;
using sc2i.multitiers.client;
using sc2i.workflow;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
using sc2i.win32.common;

using timos.securite;
using timos.acteurs;
using timos.client;

namespace timos
{
	public class CPanelRoleUtilisateur : CPanelRole
	{

		#region Designer generated code

		private timos.win32.composants.CPanelGestionDroits m_panelDroits;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTextBox m_txtLogin;
		private System.Windows.Forms.PictureBox m_imageCle;
		private System.Windows.Forms.Label m_lblId;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private System.Windows.Forms.Panel m_panelId;
		private System.Windows.Forms.Label label6;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelAgendasGeres;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage m_pageProfils;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private System.Windows.Forms.CheckBox m_chkAgendaPerso;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.common.C2iTextBox c2iTextBox2;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private sc2i.win32.common.C2iPanel m_panelProfils;
        private LinkLabel m_lnkAddProfile;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private sc2i.win32.common.C2iPanel c2iPanel2;
		private Button m_btnChangePassword;
		private sc2i.win32.common.C2iPanel m_panProfilLicence;
		private Label m_lblProfilLicence;
		private sc2i.win32.common.C2iComboBox m_cmbProfilLicence;
		private TextBox m_txtInfoProfilLicence;
        private CheckBox m_chkProfilLicence;
		private PictureBox pictureBox2;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CPanelRoleUtilisateur));
            this.m_panelDroits = new timos.win32.composants.CPanelGestionDroits();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_txtLogin = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblId = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.c2iPanel2 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnChangePassword = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_panProfilLicence = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtInfoProfilLicence = new System.Windows.Forms.TextBox();
            this.m_cmbProfilLicence = new sc2i.win32.common.C2iComboBox();
            this.m_chkProfilLicence = new System.Windows.Forms.CheckBox();
            this.m_lblProfilLicence = new System.Windows.Forms.Label();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_chkAgendaPerso = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_pageProfils = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkAddProfile = new System.Windows.Forms.LinkLabel();
            this.m_panelProfils = new sc2i.win32.common.C2iPanel(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.m_panelAgendasGeres = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelId = new System.Windows.Forms.Panel();
            this.m_imageCle = new System.Windows.Forms.PictureBox();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.c2iPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.m_panProfilLicence.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_pageProfils.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_panelId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
            // 
            // m_panelDroits
            // 
            this.m_panelDroits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDroits.ElementDefinissantLesDroits = null;
            this.m_extLinkField.SetLinkField(this.m_panelDroits, "");
            this.m_panelDroits.Location = new System.Drawing.Point(3, 0);
            this.m_panelDroits.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDroits, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelDroits.Name = "m_panelDroits";
            this.m_panelDroits.Size = new System.Drawing.Size(693, 416);
            this.m_extStyle.SetStyleBackColor(this.m_panelDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDroits.TabIndex = 0;
            // 
            // c2iTextBox2
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "IdUserAd");
            this.c2iTextBox2.Location = new System.Drawing.Point(240, 11);
            this.c2iTextBox2.LockEdition = false;
            this.c2iTextBox2.MaxLength = 32;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(278, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 0;
            this.c2iTextBox2.Text = "[IdUserAd]";
            // 
            // m_txtLogin
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLogin, "Login");
            this.m_txtLogin.Location = new System.Drawing.Point(240, 47);
            this.m_txtLogin.LockEdition = false;
            this.m_txtLogin.MaxLength = 32;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLogin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLogin.Name = "m_txtLogin";
            this.m_txtLogin.Size = new System.Drawing.Size(112, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLogin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLogin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLogin.TabIndex = 1;
            this.m_txtLogin.Text = "[Login]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(181, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 6;
            this.label3.Text = "Login|774";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 5;
            this.label2.Text = "Integrated security|773";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 18);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Associated Windows Active Directory user|772";
            // 
            // m_lblId
            // 
            this.m_lblId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_lblId.Location = new System.Drawing.Point(-2, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblId, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblId.Name = "m_lblId";
            this.m_lblId.Size = new System.Drawing.Size(48, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblId.TabIndex = 4003;
            this.m_lblId.Text = "[Id]";
            this.m_lblId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.m_lblId.Visible = false;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(712, 456);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage3,
            this.m_pageProfils,
            this.tabPage2});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.c2iPanel2);
            this.tabPage1.Controls.Add(this.m_panProfilLicence);
            this.tabPage1.Controls.Add(this.c2iPanel1);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(696, 415);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Connection|768";
            this.tabPage1.PropertyChanged += new Crownwood.Magic.Controls.TabPage.PropChangeHandler(this.tabPage1_PropertyChanged);
            // 
            // c2iPanel2
            // 
            this.c2iPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c2iPanel2.Controls.Add(this.m_btnChangePassword);
            this.c2iPanel2.Controls.Add(this.c2iTextBox2);
            this.c2iPanel2.Controls.Add(this.label1);
            this.c2iPanel2.Controls.Add(this.pictureBox2);
            this.c2iPanel2.Controls.Add(this.pictureBox1);
            this.c2iPanel2.Controls.Add(this.label2);
            this.c2iPanel2.Controls.Add(this.label3);
            this.c2iPanel2.Controls.Add(this.m_txtLogin);
            this.m_extLinkField.SetLinkField(this.c2iPanel2, "");
            this.c2iPanel2.Location = new System.Drawing.Point(8, 14);
            this.c2iPanel2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel2.Name = "c2iPanel2";
            this.c2iPanel2.Size = new System.Drawing.Size(534, 92);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel2.TabIndex = 5;
            // 
            // m_btnChangePassword
            // 
            this.m_btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_extLinkField.SetLinkField(this.m_btnChangePassword, "");
            this.m_btnChangePassword.Location = new System.Drawing.Point(358, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnChangePassword, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnChangePassword.Name = "m_btnChangePassword";
            this.m_btnChangePassword.Size = new System.Drawing.Size(160, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnChangePassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChangePassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnChangePassword.TabIndex = 12;
            this.m_btnChangePassword.Text = "Define the password...|30015";
            this.m_btnChangePassword.UseVisualStyleBackColor = false;
            this.m_btnChangePassword.Click += new System.EventHandler(this.m_btnChangePassword_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(0)))));
            this.m_extLinkField.SetLinkField(this.pictureBox2, "");
            this.pictureBox2.Location = new System.Drawing.Point(18, 76);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(500, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(147)))), ((int)(((byte)(0)))));
            this.m_extLinkField.SetLinkField(this.pictureBox1, "");
            this.pictureBox1.Location = new System.Drawing.Point(18, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // m_panProfilLicence
            // 
            this.m_panProfilLicence.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panProfilLicence.Controls.Add(this.m_txtInfoProfilLicence);
            this.m_panProfilLicence.Controls.Add(this.m_cmbProfilLicence);
            this.m_panProfilLicence.Controls.Add(this.m_chkProfilLicence);
            this.m_panProfilLicence.Controls.Add(this.m_lblProfilLicence);
            this.m_extLinkField.SetLinkField(this.m_panProfilLicence, "");
            this.m_panProfilLicence.Location = new System.Drawing.Point(8, 112);
            this.m_panProfilLicence.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panProfilLicence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panProfilLicence.Name = "m_panProfilLicence";
            this.m_panProfilLicence.Size = new System.Drawing.Size(243, 159);
            this.m_extStyle.SetStyleBackColor(this.m_panProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panProfilLicence.TabIndex = 4;
            // 
            // m_txtInfoProfilLicence
            // 
            this.m_txtInfoProfilLicence.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.m_txtInfoProfilLicence.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_extLinkField.SetLinkField(this.m_txtInfoProfilLicence, "");
            this.m_txtInfoProfilLicence.Location = new System.Drawing.Point(6, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtInfoProfilLicence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtInfoProfilLicence.Multiline = true;
            this.m_txtInfoProfilLicence.Name = "m_txtInfoProfilLicence";
            this.m_txtInfoProfilLicence.ReadOnly = true;
            this.m_txtInfoProfilLicence.Size = new System.Drawing.Size(228, 65);
            this.m_extStyle.SetStyleBackColor(this.m_txtInfoProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtInfoProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInfoProfilLicence.TabIndex = 5;
            // 
            // m_cmbProfilLicence
            // 
            this.m_cmbProfilLicence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProfilLicence.FormattingEnabled = true;
            this.m_cmbProfilLicence.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbProfilLicence, "");
            this.m_cmbProfilLicence.Location = new System.Drawing.Point(6, 60);
            this.m_cmbProfilLicence.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProfilLicence, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbProfilLicence.Name = "m_cmbProfilLicence";
            this.m_cmbProfilLicence.Size = new System.Drawing.Size(228, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProfilLicence.TabIndex = 4;
            this.m_cmbProfilLicence.SelectionChangeCommitted += new System.EventHandler(this.m_cmbProfilLicence_SelectionChangeCommitted);
            // 
            // m_chkProfilLicence
            // 
            this.m_extLinkField.SetLinkField(this.m_chkProfilLicence, "");
            this.m_chkProfilLicence.Location = new System.Drawing.Point(6, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkProfilLicence, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkProfilLicence.Name = "m_chkProfilLicence";
            this.m_chkProfilLicence.Size = new System.Drawing.Size(211, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkProfilLicence.TabIndex = 5;
            this.m_chkProfilLicence.Text = "Specify a profile|30044";
            this.m_chkProfilLicence.CheckedChanged += new System.EventHandler(this.m_chkProfilLicence_CheckedChanged);
            // 
            // m_lblProfilLicence
            // 
            this.m_lblProfilLicence.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblProfilLicence, "");
            this.m_lblProfilLicence.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProfilLicence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblProfilLicence.Name = "m_lblProfilLicence";
            this.m_lblProfilLicence.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProfilLicence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProfilLicence.TabIndex = 3;
            this.m_lblProfilLicence.Text = "License Profile|30043";
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c2iPanel1.Controls.Add(this.label8);
            this.c2iPanel1.Controls.Add(this.label7);
            this.c2iPanel1.Controls.Add(this.c2iTextBox1);
            this.c2iPanel1.Controls.Add(this.m_chkAgendaPerso);
            this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
            this.c2iPanel1.Location = new System.Drawing.Point(257, 112);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(285, 62);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(4, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 3;
            this.label8.Text = "Diary|80";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(8, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 3;
            this.label7.Text = "Initials|81";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Initiales");
            this.c2iTextBox1.Location = new System.Drawing.Point(70, 30);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 6;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(56, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Initiales]";
            // 
            // m_chkAgendaPerso
            // 
            this.m_extLinkField.SetLinkField(this.m_chkAgendaPerso, "AgendaPersonnel");
            this.m_chkAgendaPerso.Location = new System.Drawing.Point(134, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAgendaPerso, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAgendaPerso.Name = "m_chkAgendaPerso";
            this.m_chkAgendaPerso.Size = new System.Drawing.Size(144, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkAgendaPerso, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAgendaPerso, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAgendaPerso.TabIndex = 5;
            this.m_chkAgendaPerso.Text = "Personnal Diary|777";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_panelDroits);
            this.m_extLinkField.SetLinkField(this.tabPage3, "");
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(696, 415);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 12;
            this.tabPage3.Title = "Rights|769";
            // 
            // m_pageProfils
            // 
            this.m_pageProfils.Controls.Add(this.m_lnkAddProfile);
            this.m_pageProfils.Controls.Add(this.m_panelProfils);
            this.m_extLinkField.SetLinkField(this.m_pageProfils, "");
            this.m_pageProfils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageProfils.Name = "m_pageProfils";
            this.m_pageProfils.Selected = false;
            this.m_pageProfils.Size = new System.Drawing.Size(696, 415);
            this.m_extStyle.SetStyleBackColor(this.m_pageProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageProfils.TabIndex = 13;
            this.m_pageProfils.Title = "Profiles|770";
            // 
            // m_lnkAddProfile
            // 
            this.m_lnkAddProfile.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkAddProfile, "");
            this.m_lnkAddProfile.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddProfile, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddProfile.Name = "m_lnkAddProfile";
            this.m_lnkAddProfile.Size = new System.Drawing.Size(81, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddProfile, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddProfile, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddProfile.TabIndex = 1;
            this.m_lnkAddProfile.TabStop = true;
            this.m_lnkAddProfile.Text = "Add profile|147";
            this.m_lnkAddProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAddProfile_LinkClicked);
            // 
            // m_panelProfils
            // 
            this.m_panelProfils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelProfils.AutoScroll = true;
            this.m_extLinkField.SetLinkField(this.m_panelProfils, "");
            this.m_panelProfils.Location = new System.Drawing.Point(3, 20);
            this.m_panelProfils.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelProfils.Name = "m_panelProfils";
            this.m_panelProfils.Size = new System.Drawing.Size(692, 392);
            this.m_extStyle.SetStyleBackColor(this.m_panelProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelProfils.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.m_panelAgendasGeres);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(696, 415);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Managed Diaries|771";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(13, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 16);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 8;
            this.label6.Text = "Manage the following Members Diary|801";
            // 
            // m_panelAgendasGeres
            // 
            this.m_panelAgendasGeres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelAgendasGeres.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelAgendasGeres.EnableCustomisation = true;
            this.m_panelAgendasGeres.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelAgendasGeres, "");
            this.m_panelAgendasGeres.Location = new System.Drawing.Point(3, 15);
            this.m_panelAgendasGeres.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAgendasGeres, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelAgendasGeres.Name = "m_panelAgendasGeres";
            this.m_panelAgendasGeres.Size = new System.Drawing.Size(392, 400);
            this.m_extStyle.SetStyleBackColor(this.m_panelAgendasGeres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAgendasGeres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAgendasGeres.TabIndex = 7;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Acteur.Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Member name|802";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 360;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 300;
            // 
            // m_panelId
            // 
            this.m_panelId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelId.Controls.Add(this.m_lblId);
            this.m_panelId.Controls.Add(this.m_imageCle);
            this.m_panelId.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelId, "");
            this.m_panelId.Location = new System.Drawing.Point(640, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelId, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelId.Name = "m_panelId";
            this.m_panelId.Size = new System.Drawing.Size(64, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelId, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelId, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelId.TabIndex = 4005;
            // 
            // m_imageCle
            // 
            this.m_imageCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_imageCle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageCle.Image = ((System.Drawing.Image)(resources.GetObject("m_imageCle.Image")));
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_imageCle.Location = new System.Drawing.Point(46, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageCle.Name = "m_imageCle";
            this.m_imageCle.Size = new System.Drawing.Size(16, 15);
            this.m_imageCle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageCle.TabIndex = 4002;
            this.m_imageCle.TabStop = false;
            this.m_imageCle.Click += new System.EventHandler(this.m_imageCle_Click);
            // 
            // CPanelRoleUtilisateur
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_panelId);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelRoleUtilisateur";
            this.Size = new System.Drawing.Size(720, 456);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CPanelRoleUtilisateur_Load);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.c2iPanel2.ResumeLayout(false);
            this.c2iPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.m_panProfilLicence.ResumeLayout(false);
            this.m_panProfilLicence.PerformLayout();
            this.c2iPanel1.ResumeLayout(false);
            this.c2iPanel1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.m_pageProfils.ResumeLayout(false);
            this.m_pageProfils.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.m_panelId.ResumeLayout(false);
            this.m_panelId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private bool m_bIsProfilInit = false;


		public CPanelRoleUtilisateur(CDonneesActeurUtilisateur utilisateur)
			: base(utilisateur)
		{
			InitializeComponent();
		}


		public override void InitChamps ()
		{
            base.InitChamps();
			m_panelDroits.ElementDefinissantLesDroits = (IElementDefinissantDesDroits)ObjetEdite;
			
			CListeObjetsDonnees listeUsers = new CListeObjetsDonnees ( 
				DonneeUtilisateur.ContexteDonnee,
				typeof(CDonneesActeurUtilisateur) );

			listeUsers.Filtre = new CFiltreData ( 
				CDonneesActeurUtilisateur.c_champAgendaPersonnel+"=@1",
				true );

			m_bIsProfilInit = false;
			InitProfilsLicence();
			UpdateOnglets();
		}

		private void InitProfilsLicence()
		{
			m_infProfils = new List<CInfoLicenceUserProfil>();
            m_infProfils.AddRange(CGestionnaireProfilLicenceSurClient.GetProfilsPossibles(CTimosApp.SessionClient.IdSession));
			m_cmbProfilLicence.DisplayMember = "Nom";
			m_cmbProfilLicence.ValueMember = "Id";
			m_cmbProfilLicence.DataSource = m_infProfils;


			m_panelProfils.Visible = m_infProfils.Count > 0;
			m_chkProfilLicence.Visible = m_infProfils.Count > 0;

			if (m_infProfils.Count == 0)
			{
				m_txtInfoProfilLicence.Text = I.T("Error : no user profil loaded!|30018");
				return;
			}


			bool bFind = false;

			if (DonneeUtilisateur.IdProfilLicence != "" && DonneeUtilisateur.IdProfilLicence != null)
				foreach (CInfoLicenceUserProfil inf in m_infProfils)
					if (inf.Id == DonneeUtilisateur.IdProfilLicence)
					{
						m_cmbProfilLicence.SelectedValue = inf.Id;
						bFind = true;
						break;
					}

			if (!bFind)
			{
				DonneeUtilisateur.IdProfilLicence = "";
				m_chkProfilLicence.Checked = false;
			}
			else
				m_chkProfilLicence.Checked = true;



			UpdateProfilLicenceSelect();
		}
		//-------------------------------------------------------------------------
		private void InitProfils()
		{
			m_bIsProfilInit = true;
			m_panelProfils.SuspendDrawing();
			ArrayList lstToRemove = new ArrayList(m_panelProfils.Controls);
			foreach (Control ctrl in lstToRemove)
				if (ctrl is CPanelUtilisateur_Profil)
				{
					ctrl.Visible = false;
					ctrl.Parent = null;
					m_panelProfils.Controls.Remove(ctrl);
					ctrl.Dispose();
				}

			ArrayList lstPanels = new ArrayList();
			foreach (CRelationUtilisateur_Profil rel in DonneeUtilisateur.RelationsProfils)
				lstPanels.Add(CreatePanel(rel));

			m_panelProfils.Controls.AddRange((Control[])lstPanels.ToArray(typeof(Control)));
			m_panelProfils.ResumeDrawing();
		}
		/// /////////// /////////// /////////// /////////// /////////// ////////
		public override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = CResultAErreur.True;
			if (ObjetEdite == null)
				return result;
			//if ( m_txtPassword1.Text != m_txtPassword2.Text )
			//    result.EmpileErreur("Le mot de passe n'est pas le même dans les deux zones d'édition");
			if (result)
				result = base.MAJ_Champs();
			if (result)
				m_panelDroits.ValideModifs();
			if (result)
				m_panelAgendasGeres.ApplyModifs();
            if (result)
            {
                if (!m_chkProfilLicence.Checked)
                    DonneeUtilisateur.IdProfilLicence = "";
                else
                {
                    CInfoLicenceUserProfil profil = (CInfoLicenceUserProfil)CTimosApp.SessionClient.GetPropriete(CInfoLicenceUserProfil.c_nomIdentification);
                    if (profil.Priorite < ProfilLicenceSelec.Priorite)
                    {
                        // Il est interdit d'affecter un Profil Supérieur à son propre Profil
                        result.EmpileErreur(I.T("You can not affect a Licence Profile greater than your Profile : @1|10103", profil.Nom));
                        return result;
                    }
                    else
                        DonneeUtilisateur.IdProfilLicence = ProfilLicenceSelec.Id;
                }
            }
			return result;
		}


		/// /////////// /////////// /////////// /////////// /////////// ////////
		private CDonneesActeurUtilisateur DonneeUtilisateur
		{
			get
			{
				return (CDonneesActeurUtilisateur)ObjetEdite;
			}
		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private void CPanelRoleUtilisateur_Load(object sender, System.EventArgs e)
		{
			InitChamps();
			
		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, System.EventArgs e)
		{
			m_panelDroits.ElementDefinissantLesDroits = (IElementDefinissantDesDroits)ObjetEdite;
			m_panelDroits.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
		}		


		private void m_imageCle_Click(object sender, System.EventArgs e)
		{
			m_lblId.Visible = !m_lblId.Visible;
		}


		private void m_btnAnnuler_Click(object sender, System.EventArgs e)
		{
			DonneeUtilisateur.AdUser = null;
		}

		private void tabPage1_PropertyChanged(Crownwood.Magic.Controls.TabPage page, Crownwood.Magic.Controls.TabPage.Property prop, object oldValue)
		{
		
		}

		
		//-------------------------------------------------------------------------
		public override CRoleActeur RoleAssocie
		{
			get
			{
				return CRoleActeur.GetRole(CDonneesActeurUtilisateur.c_codeRole);
			}
		}




		//-------------------------------------------------------------------------------------
		private void m_lnkAddProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CProfilUtilisateur profil = (CProfilUtilisateur)CFormSelectUnObjetDonnee.SelectObjetDonnee(
                I.T("Select user profile|20734"),
                typeof(CProfilUtilisateur),
                null,
                "Libelle");
			if (profil != null)
			{
				//Crée la relation du profil
				CRelationUtilisateur_Profil relation = profil.CreateNewRelationUtilisateur(DonneeUtilisateur);
				m_panelProfils.Controls.Add ( CreatePanel(relation) );
			}
		}

		//-------------------------------------------------------------------------------------
		private CPanelUtilisateur_Profil CreatePanel(CRelationUtilisateur_Profil relation)
		{
			CPanelUtilisateur_Profil panel = new CPanelUtilisateur_Profil();
			panel.Dock = DockStyle.Top;
			m_gestionnaireModeEdition.SetModeEdition(panel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			panel.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			panel.Init(relation);
			return panel;
		}

		//-------------------------------------------------------------------------------------
		private void m_tabControl_SelectionChanged(object sender, EventArgs e)
		{
			UpdateOnglets();
		}

		/// /////////// /////////// /////////// /////////// /////////// ////////
		private void UpdateOnglets()
		{
			if (m_tabControl.SelectedTab == null)
				return;
			if (m_tabControl.SelectedTab == m_pageProfils && !m_bIsProfilInit)
				InitProfils();
		}

		private void m_btnChangePassword_Click(object sender, EventArgs e)
		{
			CFormDefinirMDP.Show(DonneeUtilisateur);
		}


		private List<CInfoLicenceUserProfil> m_infProfils;
		//Ne doit pas être null
		private CInfoLicenceUserProfil ProfilLicenceSelec
		{
			get
			{

				foreach (CInfoLicenceUserProfil inf in m_infProfils)
					if (inf.Id == (string)m_cmbProfilLicence.SelectedValue)
						return inf;
				return null;
			}
			set
			{
				if(value != null)
					m_cmbProfilLicence.SelectedValue = value.Id;
			}
		}
		private void UpdateProfilLicenceSelect()
		{
			if(m_infProfils.Count == 0)
				return;
			m_cmbProfilLicence.Enabled = m_chkProfilLicence.Checked && m_gestionnaireModeEdition.ModeEdition;

			if (!m_chkProfilLicence.Checked)
			{
				m_bSpecifProfilIntern = true;
				m_cmbProfilLicence.SelectedValue = m_infProfils[0].Id;
				m_bSpecifProfilIntern = false;
			}
			m_txtInfoProfilLicence.Text = ProfilLicenceSelec.Description;
		}

		private bool m_bSpecifProfilIntern = false;
		private void m_cmbProfilLicence_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if(!m_bSpecifProfilIntern)
				UpdateProfilLicenceSelect();
		}
		private void m_chkProfilLicence_CheckedChanged(object sender, EventArgs e)
		{
			UpdateProfilLicenceSelect();
		}
	}
}

