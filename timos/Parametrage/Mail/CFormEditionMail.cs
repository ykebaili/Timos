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
using sc2i.process.Mail;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(C2iMail))]
	public class CFormEdition2iMail : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtFrom;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private C2iTextBox m_txtTo;
        private Label label2;
        private C2iTextBox m_txtSubject;
        private Label label3;
        private Label label4;
        private C2iDateTimePicker m_dtpDateReception;
        private WebBrowser m_webMessageBody;
        private C2iTextBox m_txtMessageBody;
        private Panel panel1;
        private RadioButton m_radioHtml;
        private RadioButton m_radioText;
        private Button m_btnMessageComplet;
		private System.ComponentModel.IContainer components = null;

		public CFormEdition2iMail()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEdition2iMail(C2iMail civilite)
			:base(civilite)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEdition2iMail(C2iMail civilite, CListeObjetsDonnees liste)
			:base(civilite, liste)
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
            this.m_txtFrom = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtTo = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtSubject = new sc2i.win32.common.C2iTextBox();
            this.m_dtpDateReception = new sc2i.win32.common.C2iDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_txtMessageBody = new sc2i.win32.common.C2iTextBox();
            this.m_webMessageBody = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_radioHtml = new System.Windows.Forms.RadioButton();
            this.m_radioText = new System.Windows.Forms.RadioButton();
            this.m_btnMessageComplet = new System.Windows.Forms.Button();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(624, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(516, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "From|10357";
            // 
            // m_txtFrom
            // 
            this.m_extLinkField.SetLinkField(this.m_txtFrom, "From");
            this.m_txtFrom.Location = new System.Drawing.Point(112, 9);
            this.m_txtFrom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFrom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFrom, "");
            this.m_txtFrom.Name = "m_txtFrom";
            this.m_txtFrom.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFrom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFrom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFrom.TabIndex = 0;
            this.m_txtFrom.Text = "[From]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtFrom);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtTo);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtSubject);
            this.c2iPanelOmbre4.Controls.Add(this.m_dtpDateReception);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(779, 132);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_txtTo
            // 
            this.m_txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtTo, "To");
            this.m_txtTo.Location = new System.Drawing.Point(112, 35);
            this.m_txtTo.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTo, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTo, "");
            this.m_txtTo.Multiline = true;
            this.m_txtTo.Name = "m_txtTo";
            this.m_txtTo.Size = new System.Drawing.Size(638, 43);
            this.m_extStyle.SetStyleBackColor(this.m_txtTo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTo.TabIndex = 0;
            this.m_txtTo.Text = "[To]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "To|10358";
            // 
            // m_txtSubject
            // 
            this.m_txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtSubject, "Sujet");
            this.m_txtSubject.Location = new System.Drawing.Point(112, 84);
            this.m_txtSubject.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSubject, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSubject, "");
            this.m_txtSubject.Name = "m_txtSubject";
            this.m_txtSubject.Size = new System.Drawing.Size(638, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSubject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSubject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSubject.TabIndex = 0;
            this.m_txtSubject.Text = "[Sujet]";
            // 
            // m_dtpDateReception
            // 
            this.m_dtpDateReception.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateReception.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateReception, "");
            this.m_dtpDateReception.Location = new System.Drawing.Point(605, 9);
            this.m_dtpDateReception.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateReception, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateReception, "");
            this.m_dtpDateReception.Name = "m_dtpDateReception";
            this.m_dtpDateReception.Size = new System.Drawing.Size(145, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateReception, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateReception, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateReception.TabIndex = 4003;
            this.m_dtpDateReception.Value = new System.DateTime(2012, 5, 28, 15, 44, 8, 429);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Subject|10356";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(485, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "Delivery Date|10359";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 190);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(779, 333);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_txtMessageBody);
            this.tabPage1.Controls.Add(this.m_webMessageBody);
            this.tabPage1.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(763, 292);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Message|10363";
            // 
            // m_txtMessageBody
            // 
            this.m_txtMessageBody.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtMessageBody, "");
            this.m_txtMessageBody.Location = new System.Drawing.Point(351, 97);
            this.m_txtMessageBody.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMessageBody, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtMessageBody, "");
            this.m_txtMessageBody.Multiline = true;
            this.m_txtMessageBody.Name = "m_txtMessageBody";
            this.m_txtMessageBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_txtMessageBody.Size = new System.Drawing.Size(332, 181);
            this.m_extStyle.SetStyleBackColor(this.m_txtMessageBody, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMessageBody, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMessageBody.TabIndex = 0;
            // 
            // m_webMessageBody
            // 
            this.m_extLinkField.SetLinkField(this.m_webMessageBody, "");
            this.m_webMessageBody.Location = new System.Drawing.Point(18, 87);
            this.m_webMessageBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_webMessageBody, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_webMessageBody, "");
            this.m_webMessageBody.Name = "m_webMessageBody";
            this.m_webMessageBody.Size = new System.Drawing.Size(272, 191);
            this.m_extStyle.SetStyleBackColor(this.m_webMessageBody, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_webMessageBody, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_webMessageBody.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnMessageComplet);
            this.panel1.Controls.Add(this.m_radioHtml);
            this.panel1.Controls.Add(this.m_radioText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 44);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_radioHtml
            // 
            this.m_radioHtml.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radioHtml, "");
            this.m_radioHtml.Location = new System.Drawing.Point(431, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioHtml, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_radioHtml, "");
            this.m_radioHtml.Name = "m_radioHtml";
            this.m_radioHtml.Size = new System.Drawing.Size(86, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radioHtml, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioHtml, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioHtml.TabIndex = 0;
            this.m_radioHtml.TabStop = true;
            this.m_radioHtml.Text = "HTML View";
            this.m_radioHtml.UseVisualStyleBackColor = true;
            this.m_radioHtml.CheckedChanged += new System.EventHandler(this.m_radioText_CheckedChanged);
            // 
            // m_radioText
            // 
            this.m_radioText.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_radioText, "");
            this.m_radioText.Location = new System.Drawing.Point(313, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioText, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_radioText, "");
            this.m_radioText.Name = "m_radioText";
            this.m_radioText.Size = new System.Drawing.Size(75, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radioText, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioText, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioText.TabIndex = 0;
            this.m_radioText.TabStop = true;
            this.m_radioText.Text = "Text View";
            this.m_radioText.UseVisualStyleBackColor = true;
            this.m_radioText.CheckedChanged += new System.EventHandler(this.m_radioText_CheckedChanged);
            // 
            // m_btnMessageComplet
            // 
            this.m_btnMessageComplet.BackColor = System.Drawing.Color.Azure;
            this.m_btnMessageComplet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnMessageComplet.Image = global::timos.Properties.Resources.mail_receive_24x24;
            this.m_extLinkField.SetLinkField(this.m_btnMessageComplet, "");
            this.m_btnMessageComplet.Location = new System.Drawing.Point(21, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnMessageComplet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnMessageComplet, "");
            this.m_btnMessageComplet.Name = "m_btnMessageComplet";
            this.m_btnMessageComplet.Size = new System.Drawing.Size(205, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnMessageComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnMessageComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnMessageComplet.TabIndex = 1;
            this.m_btnMessageComplet.Text = "Retrieve full message|10371";
            this.m_btnMessageComplet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.m_btnMessageComplet.UseVisualStyleBackColor = false;
            this.m_btnMessageComplet.Click += new System.EventHandler(this.m_btnMessageComplet_Click);
            // 
            // CFormEdition2iMail
            // 
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(799, 535);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEdition2iMail";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private C2iMail Mail
		{
			get
			{
				return (C2iMail)ObjetEdite;
			}
		}
		
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Subject: @1|10362") + Mail.Sujet);

            SansEdition = true;

            m_dtpDateReception.Value = Mail.DateReception;
            m_radioHtml.Checked = Mail.FormatHTML;
            InitVisuCopsMessage();

            return result;
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        private void m_radioText_CheckedChanged(object sender, EventArgs e)
        {
            InitVisuCopsMessage();
        }

        //------------------------------------------------------------------------------
        private void InitVisuCopsMessage()
        {
            // Si la taill est supérieur à 0, c'est que le mail a déjà été récupéré
            m_btnMessageComplet.Enabled = Mail.Taille <= 0;
            if (m_radioHtml.Checked)
            {
                m_webMessageBody.Visible = true;
                m_txtMessageBody.Visible = false;
                m_webMessageBody.Dock = DockStyle.Fill;
                m_webMessageBody.DocumentText = Mail.MessageBody;
            }
            else
            {
                m_webMessageBody.Visible = false;
                m_txtMessageBody.Visible = true;
                m_txtMessageBody.Dock = DockStyle.Fill;
                m_txtMessageBody.Text = Mail.MessageBody;
            }
        }

        //------------------------------------------------------------------------------
        private void m_btnMessageComplet_Click(object sender, EventArgs e)
        {
            using (CWaitCursor cur = new CWaitCursor())
            {
                CResultAErreur result = Mail.RetriveFullMessage();
                if (!result)
                    CFormAlerte.Afficher(result.MessageErreur);
                InitVisuCopsMessage();
            }
        }
	}
}

