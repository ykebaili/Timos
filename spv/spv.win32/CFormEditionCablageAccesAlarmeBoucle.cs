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
using spv.data;
using System.Collections.Generic;
using System.Globalization;


namespace spv.win32
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvLienAccesAlarme))]
	public class CFormEditionCablageAccesAlarmeBoucle: CFormEditionStandard, IFormNavigable
	{
        private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iPanelOmbre panel;
		private Label label2;
        private CComboboxAutoFilled m_cmb_IS_Carte;
        private C2iTextBoxNumerique m_txtDelay;
        private Label label3;
        private Label label5;
        private Label label4;
        private CComboboxAutoFilled m_cmbCarteAcces;
        private CComboboxAutoFilled m_cmbGravite;
        private GroupBox groupBox1;
        private CheckBox m_chkAdmin;
        private CheckBox m_chkBri;
        private CheckBox m_chkDisplay;
        private CheckBox m_chkSurv;
        private CheckBox m_chkAcquitter;
        private CheckBox m_chkSound;
        private CComboboxAutoFilled m_cmbAccesAlarm;
        private Label label6;
        private GroupBox groupBox2;
        private Label label20;
        private C2iTextBox m_txtTopLevel;
        private Label label19;
        private C2iTextBox m_txtBottomLevel;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage pageMaskAdmin;
        private Crownwood.Magic.Controls.TabPage pageMaskBri;
        private Panel m_panelBri;
        private RichTextBox m_txtMaskBriComment;
        private Label label14;
        private Label label15;
        private Label label16;
        private Panel m_panelAdmin;
        private RichTextBox m_txtMaskAdminComment;
        private Label label9;
        private Label label10;
        private Label label11;
        private C2iDateTimeExPicker m_dtMaskAdminMax;
        private C2iDateTimeExPicker m_dtMaskAdminMin;
        private C2iDateTimeExPicker m_dtMaskBriMax;
        private C2iDateTimeExPicker m_dtMaskBriMin;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionCablageAccesAlarmeBoucle()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            
		}
		//-------------------------------------------------------------------------
        public CFormEditionCablageAccesAlarmeBoucle(CSpvLienAccesAlarme accesBoucle)
            : base(accesBoucle)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionCablageAccesAlarmeBoucle(CSpvLienAccesAlarme accesBoucle, CListeObjetsDonnees liste)
            : base(accesBoucle, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
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

		#region Designer generated code
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbAccesAlarm = new sc2i.win32.common.CComboboxAutoFilled();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmbGravite = new sc2i.win32.common.CComboboxAutoFilled();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtTopLevel = new sc2i.win32.common.C2iTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtBottomLevel = new sc2i.win32.common.C2iTextBox();
            this.m_txtDelay = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_cmb_IS_Carte = new sc2i.win32.common.CComboboxAutoFilled();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbCarteAcces = new sc2i.win32.common.CComboboxAutoFilled();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkAdmin = new System.Windows.Forms.CheckBox();
            this.m_chkBri = new System.Windows.Forms.CheckBox();
            this.m_chkSurv = new System.Windows.Forms.CheckBox();
            this.m_chkAcquitter = new System.Windows.Forms.CheckBox();
            this.m_chkSound = new System.Windows.Forms.CheckBox();
            this.m_chkDisplay = new System.Windows.Forms.CheckBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageMaskAdmin = new Crownwood.Magic.Controls.TabPage();
            this.m_panelAdmin = new System.Windows.Forms.Panel();
            this.m_txtMaskAdminComment = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pageMaskBri = new Crownwood.Magic.Controls.TabPage();
            this.m_panelBri = new System.Windows.Forms.Panel();
            this.m_txtMaskBriComment = new System.Windows.Forms.RichTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_dtMaskAdminMin = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtMaskAdminMax = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtMaskBriMax = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtMaskBriMin = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.pageMaskAdmin.SuspendLayout();
            this.m_panelAdmin.SuspendLayout();
            this.pageMaskBri.SuspendLayout();
            this.m_panelBri.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(654, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(567, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(829, 28);
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|3";
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel.Controls.Add(this.m_cmbAccesAlarm);
            this.panel.Controls.Add(this.label6);
            this.panel.Controls.Add(this.m_cmbGravite);
            this.panel.Controls.Add(this.groupBox2);
            this.panel.Controls.Add(this.m_txtDelay);
            this.panel.Controls.Add(this.m_cmb_IS_Carte);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.label4);
            this.panel.Controls.Add(this.label5);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.m_cmbCarteAcces);
            this.panel.Controls.Add(this.groupBox1);
            this.panel.Controls.Add(this.m_chkSurv);
            this.panel.Controls.Add(this.m_chkAcquitter);
            this.panel.Controls.Add(this.m_chkSound);
            this.panel.Controls.Add(this.m_chkDisplay);
            this.panel.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.panel, "");
            this.panel.Location = new System.Drawing.Point(12, 37);
            this.panel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(791, 259);
            this.m_extStyle.SetStyleBackColor(this.panel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel.TabIndex = 0;
            // 
            // m_cmbAccesAlarm
            // 
            this.m_cmbAccesAlarm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbAccesAlarm.FormattingEnabled = true;
            this.m_cmbAccesAlarm.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbAccesAlarm, "");
            this.m_cmbAccesAlarm.ListDonnees = null;
            this.m_cmbAccesAlarm.Location = new System.Drawing.Point(128, 16);
            this.m_cmbAccesAlarm.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbAccesAlarm, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbAccesAlarm.Name = "m_cmbAccesAlarm";
            this.m_cmbAccesAlarm.NullAutorise = false;
            this.m_cmbAccesAlarm.ProprieteAffichee = null;
            this.m_cmbAccesAlarm.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbAccesAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbAccesAlarm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbAccesAlarm.TabIndex = 4004;
            this.m_cmbAccesAlarm.TextNull = "(vide)";
            this.m_cmbAccesAlarm.Tri = false;
            this.m_cmbAccesAlarm.SelectionChangeCommitted += new System.EventHandler(this.AlarmAccesChanged);
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 21);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4016;
            this.label6.Text = "Alarm access|100";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbGravite
            // 
            this.m_cmbGravite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbGravite.FormattingEnabled = true;
            this.m_cmbGravite.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbGravite, "");
            this.m_cmbGravite.ListDonnees = null;
            this.m_cmbGravite.Location = new System.Drawing.Point(128, 99);
            this.m_cmbGravite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbGravite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbGravite.Name = "m_cmbGravite";
            this.m_cmbGravite.NullAutorise = false;
            this.m_cmbGravite.ProprieteAffichee = "Gravite";
            this.m_cmbGravite.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbGravite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbGravite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbGravite.TabIndex = 4010;
            this.m_cmbGravite.TextNull = "(vide)";
            this.m_cmbGravite.Tri = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.m_txtTopLevel);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.m_txtBottomLevel);
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.groupBox2.Location = new System.Drawing.Point(6, 148);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 77);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 4023;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Threshold|133";
            // 
            // label20
            // 
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(6, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 4015;
            this.label20.Text = "Top level|124";
            // 
            // m_txtTopLevel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtTopLevel, "");
            this.m_txtTopLevel.Location = new System.Drawing.Point(122, 45);
            this.m_txtTopLevel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTopLevel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTopLevel.Name = "m_txtTopLevel";
            this.m_txtTopLevel.Size = new System.Drawing.Size(87, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTopLevel.TabIndex = 4014;
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(6, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 4013;
            this.label19.Text = "Bottom level|124";
            // 
            // m_txtBottomLevel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBottomLevel, "");
            this.m_txtBottomLevel.Location = new System.Drawing.Point(122, 18);
            this.m_txtBottomLevel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBottomLevel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBottomLevel.Name = "m_txtBottomLevel";
            this.m_txtBottomLevel.Size = new System.Drawing.Size(87, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBottomLevel.TabIndex = 4012;
            // 
            // m_txtDelay
            // 
            this.m_txtDelay.Arrondi = 0;
            this.m_txtDelay.DecimalAutorise = false;
            this.m_txtDelay.DoubleValue = null;
            this.m_txtDelay.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtDelay, "DureeMin");
            this.m_txtDelay.Location = new System.Drawing.Point(128, 127);
            this.m_txtDelay.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDelay, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtDelay.Name = "m_txtDelay";
            this.m_txtDelay.NullAutorise = true;
            this.m_txtDelay.SelectAllOnEnter = true;
            this.m_txtDelay.Size = new System.Drawing.Size(87, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtDelay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDelay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDelay.TabIndex = 4007;
            // 
            // m_cmb_IS_Carte
            // 
            this.m_cmb_IS_Carte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmb_IS_Carte.FormattingEnabled = true;
            this.m_cmb_IS_Carte.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmb_IS_Carte, "");
            this.m_cmb_IS_Carte.ListDonnees = null;
            this.m_cmb_IS_Carte.Location = new System.Drawing.Point(128, 44);
            this.m_cmb_IS_Carte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmb_IS_Carte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmb_IS_Carte.Name = "m_cmb_IS_Carte";
            this.m_cmb_IS_Carte.NullAutorise = false;
            this.m_cmb_IS_Carte.ProprieteAffichee = null;
            this.m_cmb_IS_Carte.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmb_IS_Carte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmb_IS_Carte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmb_IS_Carte.TabIndex = 4017;
            this.m_cmb_IS_Carte.TextNull = "(vide)";
            this.m_cmb_IS_Carte.Tri = false;
            this.m_cmb_IS_Carte.SelectionChangeCommitted += new System.EventHandler(this.m_cmb_IS_Carte_SelectedIndexChanged);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Collector access|103";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(6, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4005;
            this.label4.Text = "Severity|104";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4006;
            this.label5.Text = "Delay|105";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Alarm collector|102";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbCarteAcces
            // 
            this.m_cmbCarteAcces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCarteAcces.FormattingEnabled = true;
            this.m_cmbCarteAcces.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbCarteAcces, "");
            this.m_cmbCarteAcces.ListDonnees = null;
            this.m_cmbCarteAcces.Location = new System.Drawing.Point(128, 71);
            this.m_cmbCarteAcces.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCarteAcces, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbCarteAcces.Name = "m_cmbCarteAcces";
            this.m_cmbCarteAcces.NullAutorise = false;
            this.m_cmbCarteAcces.ProprieteAffichee = null;
            this.m_cmbCarteAcces.Size = new System.Drawing.Size(87, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCarteAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCarteAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCarteAcces.TabIndex = 4009;
            this.m_cmbCarteAcces.TextNull = "(vide)";
            this.m_cmbCarteAcces.Tri = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_chkAdmin);
            this.groupBox1.Controls.Add(this.m_chkBri);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(466, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 82);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4011;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mask|106";
            // 
            // m_chkAdmin
            // 
            this.m_chkAdmin.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAdmin, "");
            this.m_chkAdmin.Location = new System.Drawing.Point(14, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAdmin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAdmin.Name = "m_chkAdmin";
            this.m_chkAdmin.Size = new System.Drawing.Size(106, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAdmin.TabIndex = 1;
            this.m_chkAdmin.Text = "Administrator|108";
            this.m_chkAdmin.UseVisualStyleBackColor = true;
            this.m_chkAdmin.CheckedChanged += new System.EventHandler(this.ChkAdminCheckedChanged);
            // 
            // m_chkBri
            // 
            this.m_chkBri.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkBri, "");
            this.m_chkBri.Location = new System.Drawing.Point(14, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkBri, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkBri.Name = "m_chkBri";
            this.m_chkBri.Size = new System.Drawing.Size(122, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkBri.TabIndex = 0;
            this.m_chkBri.Text = "Operating agent|107";
            this.m_chkBri.UseVisualStyleBackColor = true;
            this.m_chkBri.CheckedChanged += new System.EventHandler(this.ChkBriCheckedChanged);
            // 
            // m_chkSurv
            // 
            this.m_chkSurv.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSurv, "");
            this.m_chkSurv.Location = new System.Drawing.Point(472, 120);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSurv, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSurv.Name = "m_chkSurv";
            this.m_chkSurv.Size = new System.Drawing.Size(93, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSurv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSurv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSurv.TabIndex = 4014;
            this.m_chkSurv.Text = "Supervise|111";
            this.m_chkSurv.UseVisualStyleBackColor = true;
            // 
            // m_chkAcquitter
            // 
            this.m_chkAcquitter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAcquitter, "");
            this.m_chkAcquitter.Location = new System.Drawing.Point(472, 195);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAcquitter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAcquitter.Name = "m_chkAcquitter";
            this.m_chkAcquitter.Size = new System.Drawing.Size(134, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAcquitter.TabIndex = 4013;
            this.m_chkAcquitter.Text = "Acknowledgement|110";
            this.m_chkAcquitter.UseVisualStyleBackColor = true;
            // 
            // m_chkSound
            // 
            this.m_chkSound.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSound, "");
            this.m_chkSound.Location = new System.Drawing.Point(472, 170);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSound, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSound.Name = "m_chkSound";
            this.m_chkSound.Size = new System.Drawing.Size(77, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSound, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSound, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSound.TabIndex = 4012;
            this.m_chkSound.Text = "Sound|109";
            this.m_chkSound.UseVisualStyleBackColor = true;
            // 
            // m_chkDisplay
            // 
            this.m_chkDisplay.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkDisplay, "");
            this.m_chkDisplay.Location = new System.Drawing.Point(472, 145);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDisplay, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkDisplay.Name = "m_chkDisplay";
            this.m_chkDisplay.Size = new System.Drawing.Size(80, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDisplay.TabIndex = 4015;
            this.m_chkDisplay.Text = "Display|112";
            this.m_chkDisplay.UseVisualStyleBackColor = true;
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 302);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.pageMaskBri;
            this.m_tabControl.Size = new System.Drawing.Size(791, 249);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageMaskAdmin,
            this.pageMaskBri});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageMaskAdmin
            // 
            this.pageMaskAdmin.Controls.Add(this.m_panelAdmin);
            this.m_extLinkField.SetLinkField(this.pageMaskAdmin, "");
            this.pageMaskAdmin.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageMaskAdmin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.pageMaskAdmin.Name = "pageMaskAdmin";
            this.pageMaskAdmin.Selected = false;
            this.pageMaskAdmin.Size = new System.Drawing.Size(775, 208);
            this.m_extStyle.SetStyleBackColor(this.pageMaskAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageMaskAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageMaskAdmin.TabIndex = 10;
            this.pageMaskAdmin.Title = "Administrator masking|60001";
            // 
            // m_panelAdmin
            // 
            this.m_panelAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelAdmin.Controls.Add(this.m_dtMaskAdminMax);
            this.m_panelAdmin.Controls.Add(this.m_dtMaskAdminMin);
            this.m_panelAdmin.Controls.Add(this.m_txtMaskAdminComment);
            this.m_panelAdmin.Controls.Add(this.label9);
            this.m_panelAdmin.Controls.Add(this.label10);
            this.m_panelAdmin.Controls.Add(this.label11);
            this.m_extLinkField.SetLinkField(this.m_panelAdmin, "");
            this.m_panelAdmin.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAdmin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelAdmin.Name = "m_panelAdmin";
            this.m_panelAdmin.Size = new System.Drawing.Size(769, 202);
            this.m_extStyle.SetStyleBackColor(this.m_panelAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAdmin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAdmin.TabIndex = 1;
            // 
            // m_txtMaskAdminComment
            // 
            this.m_txtMaskAdminComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtMaskAdminComment, "");
            this.m_txtMaskAdminComment.Location = new System.Drawing.Point(138, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMaskAdminComment, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtMaskAdminComment.Name = "m_txtMaskAdminComment";
            this.m_txtMaskAdminComment.Size = new System.Drawing.Size(616, 98);
            this.m_extStyle.SetStyleBackColor(this.m_txtMaskAdminComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMaskAdminComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMaskAdminComment.TabIndex = 4032;
            this.m_txtMaskAdminComment.Text = "";
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(16, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4030;
            this.label9.Text = "Masking end|60003";
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(16, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4028;
            this.label10.Text = "Masking start|60002";
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(16, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4026;
            this.label11.Text = "Comment|132";
            // 
            // pageMaskBri
            // 
            this.pageMaskBri.Controls.Add(this.m_panelBri);
            this.m_extLinkField.SetLinkField(this.pageMaskBri, "");
            this.pageMaskBri.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageMaskBri, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.pageMaskBri.Name = "pageMaskBri";
            this.pageMaskBri.Size = new System.Drawing.Size(775, 208);
            this.m_extStyle.SetStyleBackColor(this.pageMaskBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageMaskBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageMaskBri.TabIndex = 12;
            this.pageMaskBri.Title = "Operating agent masking|60000";
            // 
            // m_panelBri
            // 
            this.m_panelBri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelBri.Controls.Add(this.m_dtMaskBriMax);
            this.m_panelBri.Controls.Add(this.m_dtMaskBriMin);
            this.m_panelBri.Controls.Add(this.m_txtMaskBriComment);
            this.m_panelBri.Controls.Add(this.label14);
            this.m_panelBri.Controls.Add(this.label15);
            this.m_panelBri.Controls.Add(this.label16);
            this.m_extLinkField.SetLinkField(this.m_panelBri, "");
            this.m_panelBri.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBri, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBri.Name = "m_panelBri";
            this.m_panelBri.Size = new System.Drawing.Size(769, 202);
            this.m_extStyle.SetStyleBackColor(this.m_panelBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBri, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBri.TabIndex = 0;
            // 
            // m_txtMaskBriComment
            // 
            this.m_txtMaskBriComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtMaskBriComment, "");
            this.m_txtMaskBriComment.Location = new System.Drawing.Point(138, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMaskBriComment, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtMaskBriComment.Name = "m_txtMaskBriComment";
            this.m_txtMaskBriComment.Size = new System.Drawing.Size(616, 98);
            this.m_extStyle.SetStyleBackColor(this.m_txtMaskBriComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMaskBriComment, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMaskBriComment.TabIndex = 4032;
            this.m_txtMaskBriComment.Text = "";
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.label14.Location = new System.Drawing.Point(16, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 4030;
            this.label14.Text = "Masking end|60003";
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(16, 18);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4028;
            this.label15.Text = "Masking start|60002";
            // 
            // label16
            // 
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.label16.Location = new System.Drawing.Point(16, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 4026;
            this.label16.Text = "Comment|132";
            // 
            // m_dtMaskAdminMin
            // 
            this.m_dtMaskAdminMin.Checked = true;
            this.m_dtMaskAdminMin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtMaskAdminMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtMaskAdminMin, "");
            this.m_dtMaskAdminMin.Location = new System.Drawing.Point(138, 18);
            this.m_dtMaskAdminMin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtMaskAdminMin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dtMaskAdminMin.Name = "m_dtMaskAdminMin";
            this.m_dtMaskAdminMin.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtMaskAdminMin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtMaskAdminMin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMaskAdminMin.TabIndex = 4034;
            this.m_dtMaskAdminMin.TextNull = "None";
            this.m_dtMaskAdminMin.Value.DateTimeValue = new System.DateTime(2010, 3, 17, 15, 6, 56, 78);
            // 
            // m_dtMaskAdminMax
            // 
            this.m_dtMaskAdminMax.Checked = true;
            this.m_dtMaskAdminMax.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtMaskAdminMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtMaskAdminMax, "");
            this.m_dtMaskAdminMax.Location = new System.Drawing.Point(138, 44);
            this.m_dtMaskAdminMax.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtMaskAdminMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dtMaskAdminMax.Name = "m_dtMaskAdminMax";
            this.m_dtMaskAdminMax.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtMaskAdminMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtMaskAdminMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMaskAdminMax.TabIndex = 4034;
            this.m_dtMaskAdminMax.TextNull = "None";
            this.m_dtMaskAdminMax.Value.DateTimeValue = new System.DateTime(2010, 3, 17, 15, 8, 52, 515);
            // 
            // m_dtMaskBriMax
            // 
            this.m_dtMaskBriMax.Checked = true;
            this.m_dtMaskBriMax.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtMaskBriMax.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtMaskBriMax, "");
            this.m_dtMaskBriMax.Location = new System.Drawing.Point(138, 44);
            this.m_dtMaskBriMax.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtMaskBriMax, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dtMaskBriMax.Name = "m_dtMaskBriMax";
            this.m_dtMaskBriMax.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtMaskBriMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtMaskBriMax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMaskBriMax.TabIndex = 4036;
            this.m_dtMaskBriMax.TextNull = "None";
            this.m_dtMaskBriMax.Value.DateTimeValue = new System.DateTime(2010, 3, 17, 15, 14, 59, 406);
            // 
            // m_dtMaskBriMin
            // 
            this.m_dtMaskBriMin.Checked = true;
            this.m_dtMaskBriMin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtMaskBriMin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtMaskBriMin, "");
            this.m_dtMaskBriMin.Location = new System.Drawing.Point(138, 18);
            this.m_dtMaskBriMin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtMaskBriMin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dtMaskBriMin.Name = "m_dtMaskBriMin";
            this.m_dtMaskBriMin.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtMaskBriMin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtMaskBriMin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMaskBriMin.TabIndex = 4035;
            this.m_dtMaskBriMin.TextNull = "None";
            this.m_dtMaskBriMin.Value.DateTimeValue = new System.DateTime(2010, 3, 17, 15, 14, 59, 437);
            // 
            // CFormEditionCablageAccesAlarmeBoucle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 556);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionCablageAccesAlarmeBoucle";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormEditionCablageAccesAlarmeBoucle";
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageMaskAdmin.ResumeLayout(false);
            this.m_panelAdmin.ResumeLayout(false);
            this.pageMaskBri.ResumeLayout(false);
            this.m_panelBri.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
        private CSpvLienAccesAlarme CablageAccesBoucle
		{
			get
			{
                return (CSpvLienAccesAlarme)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur InitChamps()
		{

			CResultAErreur result = base.InitChamps();
			if (!result)
				return result;

            //int id = CablageAccesBoucle.Id;//test  

            if (CablageAccesBoucle.BindingObject != null)
            {
                CListeObjetsDonnees listeAcces = CablageAccesBoucle.BindingObject.AccesAlarmeBoucleNonCable;
                if (CablageAccesBoucle.AccesAlarmeOne != null)
                {
                    CFiltreData filtreTmp = new CFiltreData(CSpvAcces.c_champACCES_ID + "=@1", CablageAccesBoucle.AccesAlarmeOne.Id);
                    listeAcces.Filtre = CFiltreData.GetOrFiltre(listeAcces.Filtre, filtreTmp);
                }
                int cnt = listeAcces.Count;//test

                m_cmbAccesAlarm.Fill(listeAcces.ToArrayList(), "NomAcces", false);

                //CListeObjetsDonnees objLst2 = CablageAccesBoucle.BindingObject.AccesAlarmeBoucle;

                m_cmbAccesAlarm.SelectedValue = CablageAccesBoucle.AccesAlarmeOne;
            }

            // m_cmb_IS_Carte
            string stSQL;
            CFiltreData filtre;

            if(CSpvParamSysteme.GetParametreSysteme(CSpvParamSysteme.c_parametreSEEK_EDC_IN_ALL_SITE)=="1")
            {
                /* SELECT equip_id, site_equip_comment FROM equip E	WHERE EXISTS
                (SELECT acces_id FROM acces WHERE equip_id = E.equip_id AND acces_type = 7
                AND MOD (acces_etat, 2) = 0) ORDER BY site_equip_comment*/

                stSQL = "Has(" + CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_ID + ") and " +
                CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@1 and " +
                CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_ETAT + " IN (0,2,4,6,8,10,12,14)";

                filtre = new CFiltreDataAvance(CSpvEquip.c_nomTable, stSQL, (int)ECategorieAccesAlarme.EntreeBoucle);
            }
            else
            {
                string strIdsSites = "";
                foreach ( CSpvSite spvSite in CablageAccesBoucle.BindingObject.SitesPouvantContenirLeCollecteur )
                {
                    strIdsSites += spvSite.Id + ";";
                }
                if (strIdsSites.Length > 0)
                {
                    strIdsSites = strIdsSites.Substring(0, strIdsSites.Length - 1);
                    stSQL = "Has(" + CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_ID + ") and " +
                    CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@1 and " +
                    CSpvAccesAlarme.c_nomTable + "." + CSpvAccesAlarme.c_champACCES_ETAT + " IN (0;2;4;6;8;10;12;14) and (" +
                    CSpvEquip.c_champSITE_ID + " in (" + strIdsSites + "))";
                    filtre = new CFiltreDataAvance(CSpvEquip.c_nomTable, stSQL, (int)ECategorieAccesAlarme.EntreeBoucle);
                }
                else
                    filtre = new CFiltreDataImpossible();
            }
          
            CListeObjetsDonnees objISLst = new CListeObjetsDonnees(CablageAccesBoucle.ContexteDonnee,
                                            typeof(CSpvEquip), filtre);

            m_cmb_IS_Carte.Fill(objISLst, "CommentairePourSituer", false);

            if(CablageAccesBoucle.AccesAlarmeTwo !=null)
                m_cmb_IS_Carte.SelectedValue = CablageAccesBoucle.AccesAlarmeTwo.SpvEquip;

            //m_cmbCardAccess
            if (m_cmb_IS_Carte.SelectedValue != null)
            {
                FillComboCarteAcces();
                m_cmbCarteAcces.SelectedValue = CablageAccesBoucle.AccesAlarmeTwo;
            }
          
         //   List<IEnumALibelle> lst = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CGraviteAlarme)));
            List<IEnumALibelle> lst = CGraviteAlarmeAvecMasquage.GetListGrave();
            m_cmbGravite.Fill(lst,"Libelle", false);
            m_cmbGravite.SelectedValue = CablageAccesBoucle.Gravite;
            
            m_chkSound.Checked      = (bool)CablageAccesBoucle.SonActive;
            m_chkAcquitter.Checked  = (bool)CablageAccesBoucle.Acquitter;
            m_chkAdmin.Checked      = (bool)CablageAccesBoucle.MaskAdmin;
            m_chkDisplay.Checked    = CablageAccesBoucle.Afficher;
            m_chkSurv.Checked       = CablageAccesBoucle.Surveiller;
            m_chkBri.Checked        = CablageAccesBoucle.MaskBri;

            m_txtBottomLevel.Text = (CablageAccesBoucle.SeuilBas == null) ? "" : CablageAccesBoucle.SeuilBas.ToString();
            m_txtTopLevel.Text = (CablageAccesBoucle.SeuilHaut == null) ? "" : CablageAccesBoucle.SeuilHaut.ToString();

            
            if (CablageAccesBoucle.MaskAdminDateMin != null)
                m_dtMaskAdminMin.Value = CablageAccesBoucle.MaskAdminDateMin;

            if (CablageAccesBoucle.MaskAdminDateMax != null)
                m_dtMaskAdminMax.Value = CablageAccesBoucle.MaskAdminDateMax;

            m_txtMaskAdminComment.Text = CablageAccesBoucle.Masking_Comment;

            if (CablageAccesBoucle.MaskBriDateMin != null)
                m_dtMaskBriMin.Value = CablageAccesBoucle.MaskBriDateMin;

            if (CablageAccesBoucle.MaskBriDateMax != null)
                m_dtMaskBriMax.Value = CablageAccesBoucle.MaskBriDateMax;

            m_txtMaskBriComment.Text = CablageAccesBoucle.Masking_Comment;        

            m_panelAdmin.Visible = m_chkAdmin.Checked;
            m_panelBri.Visible = m_chkBri.Checked;

            AffecterTitre(I.T("Alarm access loop wiring|101") );
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;

            CablageAccesBoucle.SonActive = m_chkSound.Checked;
            CablageAccesBoucle.Acquitter = m_chkAcquitter.Checked;
            int id = CablageAccesBoucle.Id;//test

            if (m_chkAdmin.Checked)
            {
                try
                {
                    CablageAccesBoucle.MaskAdminDateMin = m_dtMaskAdminMin.Value;
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid masking start date|60064"));
                    return result;
                }
                try
                {
                    CablageAccesBoucle.MaskAdminDateMax = m_dtMaskAdminMax.Value;
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid masking end date|60065"));
                    return result;
                }
                if (m_txtMaskAdminComment.Text.Length > 0)
                    CablageAccesBoucle.Masking_Comment = m_txtMaskAdminComment.Text;
            }
            else
            {
                CablageAccesBoucle.Demasque(true);                
            }

            if (m_chkBri.Checked)
            {
                try
                {
                    CablageAccesBoucle.MaskBriDateMin = m_dtMaskBriMin.Value;
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid masking start date|60064"));
                    return result;
                }
                try
                {
                    CablageAccesBoucle.MaskBriDateMax = m_dtMaskBriMax.Value;
                }
                catch
                {
                    result.EmpileErreur(I.T("Invalid masking end date|60065"));
                    return result;
                }
                if (m_txtMaskBriComment.Text.Length > 0)
                    CablageAccesBoucle.Masking_Comment = m_txtMaskBriComment.Text;
            }
            else
            {
                CablageAccesBoucle.Demasque(false);
            }

            if (!m_chkAdmin.Checked && !m_chkBri.Checked)
                CablageAccesBoucle.Masking_Comment = null;

                        
            CablageAccesBoucle.Afficher = m_chkDisplay.Checked ;
            CablageAccesBoucle.Surveiller = m_chkSurv.Checked;

            if(m_cmbGravite.SelectedValue!=null)
                CablageAccesBoucle.Gravite = (CGraviteAlarmeAvecMasquage)m_cmbGravite.SelectedValue;
            CablageAccesBoucle.AccesAlarmeTwo = (CSpvAccesAlarme)m_cmbCarteAcces.SelectedValue;
            CablageAccesBoucle.AccesAlarmeOne = (CSpvAccesAlarme)m_cmbAccesAlarm.SelectedValue;
            if(CablageAccesBoucle.AccesAlarmeOne != null)
                CablageAccesBoucle.SpvAlarmgeree = CablageAccesBoucle.AccesAlarmeOne.AlarmeGeree();
            
            if (m_txtBottomLevel.Text.Length > 0)
                CablageAccesBoucle.SeuilBas = Convert.ToInt32(m_txtBottomLevel.Text);
            else
                CablageAccesBoucle.SeuilBas = null;

            if (m_txtTopLevel.Text.Length > 0)
                CablageAccesBoucle.SeuilHaut = Convert.ToInt32(m_txtTopLevel.Text);
            else
                CablageAccesBoucle.SeuilHaut = null;             
                             
			return result;
        }

        private void m_cmb_IS_Carte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_cmb_IS_Carte.SelectedValue != null)
                FillComboCarteAcces();
            else
                m_cmbCarteAcces.Refresh();

            m_cmbCarteAcces.SelectedValue = null;
        }

        private void FillComboCarteAcces()
        {
             /*  "SELECT acces_id, acces_nom FROM acces\
					 WHERE equip_id = #l#:lIsId AND MOD (acces_etat, 2) = 0\
					 AND acces_type = 7  ORDER BY TO_NUMBER (acces_nom)"*/

            CSpvEquip equip = ( CSpvEquip ) m_cmb_IS_Carte.SelectedValue;
            if (equip == null)
                return;

            CListeObjetsDonnees listeAcces = new CListeObjetsDonnees(CablageAccesBoucle.ContexteDonnee,
                typeof(CSpvAccesAlarme));

            listeAcces.Filtre = new CFiltreData(CSpvAccesAlarme.c_champEQUIP_ID + "=@1 and " +
                   CSpvAccesAlarme.c_champACCES_CATEGORIE + "=@2 and " +
                   CSpvAccesAlarme.c_champACCES_ETAT + " IN (0,2,4,6,8,10,12,14)",
                   equip.Id, (int)ECategorieAccesAlarme.EntreeBoucle);

            // listeAcces.Tri //to be done

           //marche pas listeAcces.Tri = "TO_NUMBER ( " + CSpvAccesAlarme.c_champACCES_NOM + ") asc";
            
            m_cmbCarteAcces.Fill(listeAcces, "NomAcces", false); 
        }

        private void ChkBriCheckedChanged(object sender, EventArgs e)
        {
            m_panelBri.Visible = m_chkBri.Checked;
            if (m_chkBri.Checked)
            {
                m_dtMaskBriMin.Value = DateTime.Now;
                m_dtMaskBriMax.Value = DateTime.Now;
            }

        }

        private void ChkAdminCheckedChanged(object sender, EventArgs e)
        {
            m_panelAdmin.Visible = m_chkAdmin.Checked;
            if (m_chkAdmin.Checked)
            {
                m_dtMaskAdminMin.Value = DateTime.Now;
                m_dtMaskAdminMax.Value = DateTime.Now;
            }

        }

        private void AlarmAccesChanged(object sender, EventArgs e)
        {
            if (m_cmbAccesAlarm.SelectedValue != null)
            {
                CSpvAlarmGeree alarmeGeree = ((CSpvAccesAlarme)m_cmbAccesAlarm.SelectedValue).TypeAccesAlarme().AlarmeGeree;
                if (alarmeGeree != null)
                {
                    m_cmbGravite.SelectedValue = alarmeGeree.AlarmgereeGravite;
                    m_chkSound.Checked = alarmeGeree.AlarmgereeSon;
                    m_chkAcquitter.Checked = alarmeGeree.Alarmgeree_Acquitter;
                    m_chkDisplay.Checked = alarmeGeree.AlarmgereeAfficher;
                    m_chkSurv.Checked = alarmeGeree.AlarmgereeSurveiller;

                    m_txtBottomLevel.Text = (alarmeGeree.SeuilBas == null) ? "" : alarmeGeree.SeuilBas.ToString();
                    m_txtTopLevel.Text = (alarmeGeree.SeuilHaut == null) ? "" : alarmeGeree.SeuilHaut.ToString();

                    m_txtDelay.Text = alarmeGeree.DureeMin.ToString();

                }
            }
        }	
	}
}

