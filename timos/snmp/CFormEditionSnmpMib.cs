using System;
using System.Collections;
using System.Linq;
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
using timos.data.snmp;
using System.IO;
using futurocom.snmp;
using System.Collections.Generic;
using futurocom.snmp.Mib;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSnmpMibModule))]
	public class CFormEditionSnmpMib : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private C2iTextBox m_txtModuleId;
        private Label label3;
        private C2iTextBox c2iTextBox2;
        private LinkLabel m_lnkLoadModule;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageDetailMib;
        private Panel panel1;
        private ListView m_wndListeDependances;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Label label4;
        private Splitter splitter1;
        private CReducteurControle cReducteurControle1;
        private futurocom.win32.snmp.CWndMibBrowser m_browser;
        private Panel m_panelMibIncomplete;
        private Label label5;
        private Label m_lblMissingDependancies;
        private PictureBox pictureBox5;
        private CheckBox checkBox1;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionSnmpMib()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSnmpMib(CSnmpMibModule SnmpMib)
			:base(SnmpMib)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionSnmpMib(CSnmpMibModule SnmpMib, CListeObjetsDonnees liste)
			:base(SnmpMib, liste)
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
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkLoadModule = new System.Windows.Forms.LinkLabel();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_txtModuleId = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDetailMib = new Crownwood.Magic.Controls.TabPage();
            this.m_browser = new futurocom.win32.snmp.CWndMibBrowser();
            this.m_panelMibIncomplete = new System.Windows.Forms.Panel();
            this.m_lblMissingDependancies = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_wndListeDependances = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.cReducteurControle1 = new sc2i.win32.common.CReducteurControle();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageDetailMib.SuspendLayout();
            this.m_panelMibIncomplete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 32);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkLoadModule);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtModuleId);
            this.c2iPanelOmbre4.Controls.Add(this.checkBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(692, 146);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lnkLoadModule
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkLoadModule, "");
            this.m_lnkLoadModule.Location = new System.Drawing.Point(439, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkLoadModule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkLoadModule, "");
            this.m_lnkLoadModule.Name = "m_lnkLoadModule";
            this.m_lnkLoadModule.Size = new System.Drawing.Size(227, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLoadModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLoadModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLoadModule.TabIndex = 4005;
            this.m_lnkLoadModule.TabStop = true;
            this.m_lnkLoadModule.Text = "Load MIB file|20258";
            this.m_lnkLoadModule.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLoadModule_LinkClicked);
            // 
            // c2iTextBox2
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Description");
            this.c2iTextBox2.Location = new System.Drawing.Point(132, 57);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Multiline = true;
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(534, 71);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 4004;
            this.c2iTextBox2.Text = "[Description]";
            // 
            // m_txtModuleId
            // 
            this.m_extLinkField.SetLinkField(this.m_txtModuleId, "ModuleId");
            this.m_txtModuleId.Location = new System.Drawing.Point(132, 9);
            this.m_txtModuleId.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtModuleId, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtModuleId, "");
            this.m_txtModuleId.Name = "m_txtModuleId";
            this.m_txtModuleId.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtModuleId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtModuleId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtModuleId.TabIndex = 4003;
            this.m_txtModuleId.Text = "[ModuleId]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Description|20257";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Module Id|20256";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 195);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageDetailMib;
            this.m_tabControl.Size = new System.Drawing.Size(822, 336);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDetailMib});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDetailMib
            // 
            this.m_pageDetailMib.Controls.Add(this.m_browser);
            this.m_pageDetailMib.Controls.Add(this.m_panelMibIncomplete);
            this.m_pageDetailMib.Controls.Add(this.splitter1);
            this.m_pageDetailMib.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageDetailMib, "");
            this.m_pageDetailMib.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDetailMib, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDetailMib, "");
            this.m_pageDetailMib.Name = "m_pageDetailMib";
            this.m_pageDetailMib.Size = new System.Drawing.Size(806, 295);
            this.m_extStyle.SetStyleBackColor(this.m_pageDetailMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDetailMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDetailMib.TabIndex = 10;
            this.m_pageDetailMib.Title = "Mib detail|20261";
            // 
            // m_browser
            // 
            this.m_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_browser, "");
            this.m_browser.Location = new System.Drawing.Point(235, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_browser, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_browser, "");
            this.m_browser.Name = "m_browser";
            this.m_browser.Size = new System.Drawing.Size(571, 224);
            this.m_extStyle.SetStyleBackColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_browser.TabIndex = 3;
            // 
            // m_panelMibIncomplete
            // 
            this.m_panelMibIncomplete.Controls.Add(this.m_lblMissingDependancies);
            this.m_panelMibIncomplete.Controls.Add(this.label5);
            this.m_panelMibIncomplete.Controls.Add(this.pictureBox5);
            this.m_panelMibIncomplete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelMibIncomplete, "");
            this.m_panelMibIncomplete.Location = new System.Drawing.Point(235, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMibIncomplete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelMibIncomplete, "");
            this.m_panelMibIncomplete.Name = "m_panelMibIncomplete";
            this.m_panelMibIncomplete.Size = new System.Drawing.Size(571, 71);
            this.m_extStyle.SetStyleBackColor(this.m_panelMibIncomplete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMibIncomplete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMibIncomplete.TabIndex = 5;
            this.m_panelMibIncomplete.Visible = false;
            // 
            // m_lblMissingDependancies
            // 
            this.m_lblMissingDependancies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_lblMissingDependancies, "");
            this.m_lblMissingDependancies.Location = new System.Drawing.Point(16, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMissingDependancies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblMissingDependancies, "");
            this.m_lblMissingDependancies.Name = "m_lblMissingDependancies";
            this.m_lblMissingDependancies.Size = new System.Drawing.Size(555, 35);
            this.m_extStyle.SetStyleBackColor(this.m_lblMissingDependancies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMissingDependancies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMissingDependancies.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(16, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(555, 36);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Warning, MIB can not be compiled because of dependant MIBs missing in TIMOS|10281" +
                "";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox5.Image = global::timos.Properties.Resources.alerte;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 71);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // splitter1
            // 
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.splitter1.Location = new System.Drawing.Point(232, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 295);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_wndListeDependances);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 295);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_wndListeDependances
            // 
            this.m_wndListeDependances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_wndListeDependances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_wndListeDependances, "");
            this.m_wndListeDependances.Location = new System.Drawing.Point(0, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeDependances, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeDependances, "");
            this.m_wndListeDependances.Name = "m_wndListeDependances";
            this.m_wndListeDependances.Size = new System.Drawing.Size(232, 279);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeDependances, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeDependances, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeDependances.TabIndex = 1;
            this.m_wndListeDependances.UseCompatibleStateImageBehavior = false;
            this.m_wndListeDependances.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name|10290";
            this.columnHeader1.Width = 147;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status|10291";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Dependancies|10280";
            // 
            // cReducteurControle1
            // 
            this.cReducteurControle1.ControleAgrandit = this.m_tabControl;
            this.cReducteurControle1.ControleAVoir = this.m_txtModuleId;
            this.cReducteurControle1.ControleReduit = this.c2iPanelOmbre4;
            this.m_extLinkField.SetLinkField(this.cReducteurControle1, "");
            this.cReducteurControle1.Location = new System.Drawing.Point(350, 48);
            this.cReducteurControle1.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.cReducteurControle1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.cReducteurControle1.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.cReducteurControle1, "");
            this.cReducteurControle1.Name = "cReducteurControle1";
            this.cReducteurControle1.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.cReducteurControle1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.cReducteurControle1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cReducteurControle1.TabIndex = 4005;
            this.cReducteurControle1.TailleReduite = 32;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "IsStandard");
            this.checkBox1.Location = new System.Drawing.Point(438, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 4006;
            this.checkBox1.Text = "Standard MIB|10284";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CFormEditionSnmpMib
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.cReducteurControle1);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSnmpMib";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSnmpMib_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSnmpMib_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.cReducteurControle1, 0);
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
            this.m_pageDetailMib.ResumeLayout(false);
            this.m_panelMibIncomplete.ResumeLayout(false);
            this.m_panelMibIncomplete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CSnmpMibModule SnmpMib
		{
			get
			{
				return (CSnmpMibModule)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Mib @1|20251", SnmpMib.Libelle));
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        //-------------------------------------------------------------------------
        private void m_lnkLoadModule_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("Mib files (*.mib)|*.mib|All files (*.*)|*.*|20255");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader reader = new StreamReader(dlg.FileName, System.Text.Encoding.Default);
                    CResultAErreurType<IList<IModule>> resultModules = CSnmpMibModule.CompileFile(reader);
                    reader.Close();
                    if (resultModules)
                    {
                        IModule module = null;
                        if (m_txtModuleId.Text == "" && resultModules.DataType.Count > 0)
                            module = resultModules.DataType[0];
                        else
                        {
                            module = resultModules.DataType.FirstOrDefault(m => m.Name.ToUpper() == m_txtModuleId.Text.ToUpper());
                        }
                        if (module == null)
                        {
                            MessageBox.Show(I.T("Module '@1' can not be found in file @2|20259",
                                m_txtModuleId.Text, dlg.FileName));
                            return;
                        }
                        if (SnmpMib.ModuleMib == null ||
                            MessageBox.Show(
                            I.T("Current module will be replaced with the mib module from @1. Are you sure ?|20260", dlg.FileName),
                            "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SnmpMib.ModuleMib = module;
                            UpdateVueMib();
                        }
                    }
                }
                catch (Exception ex)
                {
                    CResultAErreur result = CResultAErreur.True;
                    result.EmpileErreur(new CErreurException(ex));
                    CFormAfficheErreur.Show(result.Erreur);
                }
            }
        }

        //-------------------------------------------------------------------------
        private void UpdateVueMib()
        {
            CResultAErreurType<ObjectRegistryBase> result = SnmpMib.GetMibComplete();
            try
            {
                if (result)
                {
                    m_panelMibIncomplete.Visible = false;
                    m_browser.Init(result.DataType.Tree.Root, CTimosApp.DefaultSnmpConnexion);
                }
                else
                {
                    m_panelMibIncomplete.Visible = true;
                    if (SnmpMib.DependancesManquantes.Length > 0)
                    {
                        m_lblMissingDependancies.Text = SnmpMib.DependancesManquantesString;
                    }
                    IModule module = SnmpMib.ModuleMib;
                    if (module != null)
                    {
                        IObjectTree tree = module.GetNewPartialObjectTree();
                        if (tree != null)
                            m_browser.Init(tree.Root, CTimosApp.DefaultSnmpConnexion);
                    }
                }
            }
            catch (Exception e)
            {
                m_browser.Visible = false;
                m_panelMibIncomplete.Visible = true;
                m_lblMissingDependancies.Text = e.ToString();
            }

        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionSnmpMib_OnMajChampsPage(object page)
        {
            return CResultAErreur.True;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionSnmpMib_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if ( page == m_pageDetailMib )
            {
                UpdateVueMib();
            }
            return result;
        }
	}
}

