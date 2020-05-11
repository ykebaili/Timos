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

using timos.acteurs;
using sc2i.workflow;
using sc2i.process.Mail;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CCompteMail))]
	public class CFormEditionCompteMail : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private ToolTip m_tooltip;
        private GroupBox groupBox1;
        private CheckBox m_chkSSL;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageParametres;
        private Crownwood.Magic.Controls.TabPage m_tabPageMessages;
        private GroupBox groupBox2;
        private C2iTextBoxNumerique m_numPeriodeReleve;
        private C2iTextBox m_txtPassword;
        private C2iTextBox m_txtUser;
        private C2iTextBox m_txtServeur;
        private C2iTextBoxNumerique m_numPort;
        private CheckBox m_chkSupprimerDuServeur;
        private C2iTextBoxNumerique m_numNbJoursDelaiSuppression;
        private Label label9;
        private Label label8;
        private CheckBox checkBox1;
        private Panel m_panelActions;
        private Crownwood.Magic.Controls.TabPage m_tabPageEvenements;
        private Button m_btnRelever;
        private CPanelListeSpeedStandard m_panelListMessages;
        private Label label10;
        private C2iTextBox m_txtLastError;
        private Label label11;
        private C2iTextBox m_txtDateDernierRelevé;
        private CPanelDefinisseurEvenements m_panelEvenements;
        private CheckBox m_chkHeaderOnly;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionCompteMail()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCompteMail(CCompteMail CompteMail)
			:base(CompteMail)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCompteMail(CCompteMail CompteMail, CListeObjetsDonnees liste)
			:base(CompteMail, liste)
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionCompteMail));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_numPeriodeReleve = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_numPort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtPassword = new sc2i.win32.common.C2iTextBox();
            this.m_txtUser = new sc2i.win32.common.C2iTextBox();
            this.m_txtServeur = new sc2i.win32.common.C2iTextBox();
            this.m_chkHeaderOnly = new System.Windows.Forms.CheckBox();
            this.m_chkSSL = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageParametres = new Crownwood.Magic.Controls.TabPage();
            this.m_txtLastError = new sc2i.win32.common.C2iTextBox();
            this.m_txtDateDernierRelevé = new sc2i.win32.common.C2iTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_numNbJoursDelaiSuppression = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_chkSupprimerDuServeur = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_tabPageMessages = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListMessages = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelActions = new System.Windows.Forms.Panel();
            this.m_btnRelever = new System.Windows.Forms.Button();
            this.m_tabPageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageParametres.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_tabPageMessages.SuspendLayout();
            this.m_panelActions.SuspendLayout();
            this.m_tabPageEvenements.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(645, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(537, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(820, 28);
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
            this.label1.Location = new System.Drawing.Point(15, 11);
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
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(138, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(483, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_numPeriodeReleve);
            this.c2iPanelOmbre4.Controls.Add(this.label7);
            this.c2iPanelOmbre4.Controls.Add(this.label6);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.checkBox1);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(647, 100);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_numPeriodeReleve
            // 
            this.m_numPeriodeReleve.Arrondi = 0;
            this.m_numPeriodeReleve.DecimalAutorise = false;
            this.m_numPeriodeReleve.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numPeriodeReleve, "PeriodeReleve");
            this.m_numPeriodeReleve.Location = new System.Drawing.Point(138, 40);
            this.m_numPeriodeReleve.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numPeriodeReleve, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numPeriodeReleve, "");
            this.m_numPeriodeReleve.Name = "m_numPeriodeReleve";
            this.m_numPeriodeReleve.NullAutorise = false;
            this.m_numPeriodeReleve.SelectAllOnEnter = true;
            this.m_numPeriodeReleve.SeparateurMilliers = "";
            this.m_numPeriodeReleve.Size = new System.Drawing.Size(85, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numPeriodeReleve, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numPeriodeReleve, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numPeriodeReleve.TabIndex = 4003;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(229, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4002;
            this.label7.Text = "minutes";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(17, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4002;
            this.label6.Text = "Retrieve period|10340";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "IsActive");
            this.checkBox1.Location = new System.Drawing.Point(422, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Activate this account|10354";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_numPort);
            this.groupBox1.Controls.Add(this.m_txtPassword);
            this.groupBox1.Controls.Add(this.m_txtUser);
            this.groupBox1.Controls.Add(this.m_txtServeur);
            this.groupBox1.Controls.Add(this.m_chkSSL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(758, 119);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4003;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "POP Server|10343";
            // 
            // m_numPort
            // 
            this.m_numPort.Arrondi = 0;
            this.m_numPort.DecimalAutorise = false;
            this.m_numPort.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numPort, "");
            this.m_numPort.Location = new System.Drawing.Point(534, 26);
            this.m_numPort.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numPort, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numPort, "");
            this.m_numPort.Name = "m_numPort";
            this.m_numPort.NullAutorise = false;
            this.m_numPort.SelectAllOnEnter = true;
            this.m_numPort.SeparateurMilliers = "";
            this.m_numPort.Size = new System.Drawing.Size(85, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numPort.TabIndex = 3;
            this.m_numPort.Text = "0";
            // 
            // m_txtPassword
            // 
            this.m_extLinkField.SetLinkField(this.m_txtPassword, "");
            this.m_txtPassword.Location = new System.Drawing.Point(169, 80);
            this.m_txtPassword.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtPassword, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtPassword, "");
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.Size = new System.Drawing.Size(219, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtPassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPassword, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPassword.TabIndex = 2;
            this.m_txtPassword.UseSystemPasswordChar = true;
            // 
            // m_txtUser
            // 
            this.m_extLinkField.SetLinkField(this.m_txtUser, "");
            this.m_txtUser.Location = new System.Drawing.Point(169, 53);
            this.m_txtUser.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtUser, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtUser, "");
            this.m_txtUser.Name = "m_txtUser";
            this.m_txtUser.Size = new System.Drawing.Size(219, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtUser.TabIndex = 1;
            // 
            // m_txtServeur
            // 
            this.m_extLinkField.SetLinkField(this.m_txtServeur, "");
            this.m_txtServeur.Location = new System.Drawing.Point(169, 26);
            this.m_txtServeur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtServeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtServeur, "");
            this.m_txtServeur.Name = "m_txtServeur";
            this.m_txtServeur.Size = new System.Drawing.Size(291, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtServeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtServeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtServeur.TabIndex = 0;
            // 
            // m_chkHeaderOnly
            // 
            this.m_chkHeaderOnly.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkHeaderOnly, "");
            this.m_chkHeaderOnly.Location = new System.Drawing.Point(19, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkHeaderOnly, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkHeaderOnly, "");
            this.m_chkHeaderOnly.Name = "m_chkHeaderOnly";
            this.m_chkHeaderOnly.Size = new System.Drawing.Size(185, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkHeaderOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkHeaderOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkHeaderOnly.TabIndex = 4;
            this.m_chkHeaderOnly.Text = "Download Headers only|10370";
            this.m_chkHeaderOnly.UseVisualStyleBackColor = true;
            // 
            // m_chkSSL
            // 
            this.m_chkSSL.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSSL, "");
            this.m_chkSSL.Location = new System.Drawing.Point(534, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSSL, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSSL, "");
            this.m_chkSSL.Name = "m_chkSSL";
            this.m_chkSSL.Size = new System.Drawing.Size(162, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSSL, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSSL, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSSL.TabIndex = 4;
            this.m_chkSSL.Text = "Use SSL connection|10349";
            this.m_chkSSL.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(15, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password|10347";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "User name|10346";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(466, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port|10348";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(15, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 15);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Incoming Mail Server|10345";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_tabPageParametres;
            this.m_tabControl.Size = new System.Drawing.Size(800, 360);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageMessages,
            this.m_tabPageParametres,
            this.m_tabPageEvenements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageParametres
            // 
            this.m_tabPageParametres.Controls.Add(this.m_txtLastError);
            this.m_tabPageParametres.Controls.Add(this.m_txtDateDernierRelevé);
            this.m_tabPageParametres.Controls.Add(this.groupBox2);
            this.m_tabPageParametres.Controls.Add(this.groupBox1);
            this.m_tabPageParametres.Controls.Add(this.label11);
            this.m_tabPageParametres.Controls.Add(this.label10);
            this.m_extLinkField.SetLinkField(this.m_tabPageParametres, "");
            this.m_tabPageParametres.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageParametres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageParametres, "");
            this.m_tabPageParametres.Name = "m_tabPageParametres";
            this.m_tabPageParametres.Size = new System.Drawing.Size(784, 319);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageParametres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageParametres.TabIndex = 10;
            this.m_tabPageParametres.Title = "Account Settings|10341";
            // 
            // m_txtLastError
            // 
            this.m_txtLastError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLastError, "LastErreur");
            this.m_txtLastError.Location = new System.Drawing.Point(372, 201);
            this.m_txtLastError.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLastError, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtLastError, "");
            this.m_txtLastError.Multiline = true;
            this.m_txtLastError.Name = "m_txtLastError";
            this.m_txtLastError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.m_txtLastError.Size = new System.Drawing.Size(388, 89);
            this.m_extStyle.SetStyleBackColor(this.m_txtLastError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLastError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLastError.TabIndex = 0;
            this.m_txtLastError.Text = "[LastErreur]";
            // 
            // m_txtDateDernierRelevé
            // 
            this.m_extLinkField.SetLinkField(this.m_txtDateDernierRelevé, "");
            this.m_txtDateDernierRelevé.Location = new System.Drawing.Point(502, 151);
            this.m_txtDateDernierRelevé.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateDernierRelevé, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtDateDernierRelevé, "");
            this.m_txtDateDernierRelevé.Name = "m_txtDateDernierRelevé";
            this.m_txtDateDernierRelevé.Size = new System.Drawing.Size(158, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtDateDernierRelevé, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDateDernierRelevé, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateDernierRelevé.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_numNbJoursDelaiSuppression);
            this.groupBox2.Controls.Add(this.m_chkSupprimerDuServeur);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.m_chkHeaderOnly);
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox2, "");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 143);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 4004;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options|10344";
            // 
            // m_numNbJoursDelaiSuppression
            // 
            this.m_numNbJoursDelaiSuppression.Arrondi = 0;
            this.m_numNbJoursDelaiSuppression.DecimalAutorise = false;
            this.m_numNbJoursDelaiSuppression.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numNbJoursDelaiSuppression, "");
            this.m_numNbJoursDelaiSuppression.Location = new System.Drawing.Point(141, 79);
            this.m_numNbJoursDelaiSuppression.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numNbJoursDelaiSuppression, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numNbJoursDelaiSuppression, "");
            this.m_numNbJoursDelaiSuppression.Name = "m_numNbJoursDelaiSuppression";
            this.m_numNbJoursDelaiSuppression.NullAutorise = false;
            this.m_numNbJoursDelaiSuppression.SelectAllOnEnter = true;
            this.m_numNbJoursDelaiSuppression.SeparateurMilliers = "";
            this.m_numNbJoursDelaiSuppression.Size = new System.Drawing.Size(63, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numNbJoursDelaiSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numNbJoursDelaiSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numNbJoursDelaiSuppression.TabIndex = 1;
            this.m_numNbJoursDelaiSuppression.Text = "0";
            // 
            // m_chkSupprimerDuServeur
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSupprimerDuServeur, "");
            this.m_chkSupprimerDuServeur.Location = new System.Drawing.Point(19, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSupprimerDuServeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSupprimerDuServeur, "");
            this.m_chkSupprimerDuServeur.Name = "m_chkSupprimerDuServeur";
            this.m_chkSupprimerDuServeur.Size = new System.Drawing.Size(232, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSupprimerDuServeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSupprimerDuServeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSupprimerDuServeur.TabIndex = 0;
            this.m_chkSupprimerDuServeur.Text = "Delete Messages from Server|10350";
            this.m_chkSupprimerDuServeur.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(205, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 15);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 0;
            this.label9.Text = "days|10352";
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(49, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 15);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Delete after|10351";
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(369, 180);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 16);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 0;
            this.label11.Text = "Last error|10364";
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(369, 156);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 16);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "Last retrieve date|10365";
            // 
            // m_tabPageMessages
            // 
            this.m_tabPageMessages.Controls.Add(this.m_panelListMessages);
            this.m_tabPageMessages.Controls.Add(this.m_panelActions);
            this.m_extLinkField.SetLinkField(this.m_tabPageMessages, "");
            this.m_tabPageMessages.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageMessages, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageMessages, "");
            this.m_tabPageMessages.Name = "m_tabPageMessages";
            this.m_tabPageMessages.Selected = false;
            this.m_tabPageMessages.Size = new System.Drawing.Size(784, 319);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageMessages.TabIndex = 11;
            this.m_tabPageMessages.Title = "Messages|10342";
            // 
            // m_panelListMessages
            // 
            this.m_panelListMessages.AllowArbre = true;
            this.m_panelListMessages.AllowCustomisation = true;
            this.m_panelListMessages.BoutonAjouterVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Subject";
            glColumn1.Propriete = "Sujet";
            glColumn1.Text = "Subject|10356";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 200;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "From";
            glColumn2.Propriete = "From";
            glColumn2.Text = "From|10357";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 150;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Date";
            glColumn3.Propriete = "DateReception";
            glColumn3.Text = "Date|10359";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Size";
            glColumn4.Propriete = "Taille";
            glColumn4.Text = "Size|10360";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 50;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Attachements";
            glColumn5.Propriete = "NombrePiecesJointes";
            glColumn5.Text = "Attachements|10361";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 50;
            this.m_panelListMessages.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4,
            glColumn5});
            this.m_panelListMessages.ContexteUtilisation = "";
            this.m_panelListMessages.ControlFiltreStandard = null;
            this.m_panelListMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListMessages.ElementSelectionne = null;
            this.m_panelListMessages.EnableCustomisation = true;
            this.m_panelListMessages.FiltreDeBase = null;
            this.m_panelListMessages.FiltreDeBaseEnAjout = false;
            this.m_panelListMessages.FiltrePrefere = null;
            this.m_panelListMessages.FiltreRapide = null;
            this.m_panelListMessages.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListMessages, "");
            this.m_panelListMessages.ListeObjets = null;
            this.m_panelListMessages.Location = new System.Drawing.Point(0, 40);
            this.m_panelListMessages.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListMessages, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListMessages.ModeQuickSearch = false;
            this.m_panelListMessages.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListMessages, "");
            this.m_panelListMessages.MultiSelect = true;
            this.m_panelListMessages.Name = "m_panelListMessages";
            this.m_panelListMessages.Navigateur = null;
            this.m_panelListMessages.ProprieteObjetAEditer = null;
            this.m_panelListMessages.QuickSearchText = "";
            this.m_panelListMessages.Size = new System.Drawing.Size(784, 279);
            this.m_extStyle.SetStyleBackColor(this.m_panelListMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListMessages, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListMessages.TabIndex = 1;
            this.m_panelListMessages.TrierAuClicSurEnteteColonne = true;
            this.m_panelListMessages.UseCheckBoxes = false;
            // 
            // m_panelActions
            // 
            this.m_panelActions.Controls.Add(this.m_btnRelever);
            this.m_panelActions.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelActions, "");
            this.m_panelActions.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelActions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelActions, "");
            this.m_panelActions.Name = "m_panelActions";
            this.m_panelActions.Size = new System.Drawing.Size(784, 40);
            this.m_extStyle.SetStyleBackColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelActions.TabIndex = 0;
            // 
            // m_btnRelever
            // 
            this.m_btnRelever.BackColor = System.Drawing.Color.Azure;
            this.m_btnRelever.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnRelever.Image = global::timos.Properties.Resources.mail_receive_24x24;
            this.m_extLinkField.SetLinkField(this.m_btnRelever, "");
            this.m_btnRelever.Location = new System.Drawing.Point(18, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRelever, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRelever, "");
            this.m_btnRelever.Name = "m_btnRelever";
            this.m_btnRelever.Size = new System.Drawing.Size(205, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnRelever, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRelever, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRelever.TabIndex = 0;
            this.m_btnRelever.Text = "Retrieve all Messages|10355";
            this.m_btnRelever.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_btnRelever.UseVisualStyleBackColor = false;
            this.m_btnRelever.Click += new System.EventHandler(this.m_btnRelever_Click);
            // 
            // m_tabPageEvenements
            // 
            this.m_tabPageEvenements.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Name = "m_tabPageEvenements";
            this.m_tabPageEvenements.Selected = false;
            this.m_tabPageEvenements.Size = new System.Drawing.Size(784, 319);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageEvenements.TabIndex = 12;
            this.m_tabPageEvenements.Title = "Events management|10369";
            // 
            // m_panelEvenements
            // 
            this.m_panelEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEvenements, "");
            this.m_panelEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEvenements, "");
            this.m_panelEvenements.Name = "m_panelEvenements";
            this.m_panelEvenements.Size = new System.Drawing.Size(784, 319);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 2;
            // 
            // CFormEditionCompteMail
            // 
            this.ClientSize = new System.Drawing.Size(820, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionCompteMail";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionCompteMail_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionCompteMail_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageParametres.ResumeLayout(false);
            this.m_tabPageParametres.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_tabPageMessages.ResumeLayout(false);
            this.m_panelActions.ResumeLayout(false);
            this.m_tabPageEvenements.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CCompteMail CompteMail
		{
			get
			{
				return (CCompteMail)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "SMS message|20363"));

            InitParametresCompte();
            if (CompteMail.DateDernierReleve != null)
                m_txtDateDernierRelevé.Text = CompteMail.DateDernierReleve.Value.ToString("dd/MM/yyyy HH:mm:ss");
            else
                m_txtDateDernierRelevé.Text = "";


            return result;
		}

        //-------------------------------------------------------------------------
        private void InitParametresCompte()
        {
            CParametreCompteMail parametre = CompteMail.ParametreCompteMail;
            if (parametre == null)
                parametre = new CParametreCompteMail();

            m_txtServeur.Text = parametre.PopServer;
            m_numPort.IntValue = parametre.PopPort;
            m_chkSSL.Checked = parametre.UseSsl;
            m_chkHeaderOnly.Checked = parametre.HeaderOnly;
            m_txtUser.Text = parametre.User;
            m_txtPassword.Text = parametre.Password;
            // Otions de remise
            m_chkSupprimerDuServeur.Checked = parametre.SupprimerDuServeur;
            m_numNbJoursDelaiSuppression.IntValue = parametre.DelaiSuppression;

        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result)
                return result;

            CompteMail.PeriodeReleve = m_numPeriodeReleve.IntValue.Value;

            return result;
        }

        private void m_btnRelever_Click(object sender, EventArgs e)
        {
            using (CWaitCursor cursor = new CWaitCursor())
            {
                CResultAErreur result = CompteMail.RetrieveMails();
                if (!result)
                    CFormAlerte.Afficher(result.MessageErreur);
                m_panelListMessages.Refresh();
            }
        }

        private CResultAErreur CFormEditionCompteMail_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_tabPageMessages)
            {
                m_panelListMessages.InitFromListeObjets(
                    CompteMail.Mails,
                    typeof(C2iMail),
                    null,
                    "");
            }
            if (page == m_tabPageParametres)
            {
                InitParametresCompte();
            }
            if (page == m_tabPageEvenements)
            {
                result = m_panelEvenements.InitChamps(CompteMail);
            }

            return result;
        }

        private CResultAErreur CFormEditionCompteMail_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_tabPageMessages)
            {

            }
            if (page == m_tabPageParametres)
            {
                CParametreCompteMail parametre = new CParametreCompteMail();

                parametre.PopServer = m_txtServeur.Text;
                parametre.PopPort = m_numPort.IntValue.Value;
                parametre.UseSsl = m_chkSSL.Checked;
                parametre.HeaderOnly = m_chkHeaderOnly.Checked;
                parametre.User = m_txtUser.Text;
                parametre.Password = m_txtPassword.Text;
                // Otions de remise
                parametre.SupprimerDuServeur = m_chkSupprimerDuServeur.Checked;
                parametre.DelaiSuppression = m_numNbJoursDelaiSuppression.IntValue.Value;

                CompteMail.ParametreCompteMail = parametre;
            }
            if (page == m_tabPageEvenements)
            {
                result = m_panelEvenements.MAJ_Champs();
            }

            return result;
        }

        
	}
}

