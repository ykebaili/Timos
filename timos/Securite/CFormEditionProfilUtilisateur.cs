using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
using sc2i.win32.data;
using sc2i.common;
using sc2i.win32.common;

using timos.securite;
using System.Data;
using System.Collections.Generic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CProfilUtilisateur))]
	public class CFormEditionProfilUtilisateur : CFormEditionStdTimos, IFormNavigable
	{
		private Hashtable m_tableEOToNode = new Hashtable();
		private TreeNode m_lastNodeAffiche = null;

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private C2iTabControl c2iTabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private Label label3;
		private TreeView m_arbreEO;
		private C2iPanel m_panelEO;
		private Label label2;
		private CPanelListeRelationSelection m_wndRelationsGroupes;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private Label label4;
		private TreeView m_arbreSousProfils;
		private ContextMenuStrip m_menuSousProfil;
		private ToolStripMenuItem m_menuAjouter;
		private ToolStripMenuItem m_menuSupprimer;
		private Panel m_panelProfil_inclusion;
		private Label label5;
		private C2iTextBox m_txtLibelleSousProfil;
		private Label label6;
		private LinkLabel m_lnkProfilFils;
		private CheckBox m_chkAffinable;
		private Label label7;
		private C2iTextBox c2iTextBox1;
		private Panel m_panelModeApplication;
		private Label label8;
        private CComboboxAutoFilled m_cmbModeApplication;
        private Label label9;
        private Panel panel1;
        private ListView m_wndListeTypesForFiltre;
        private ColumnHeader columnHeader1;
        private Splitter splitter1;
        private Panel panel2;
        private Panel panel3;
        private CheckBox checkBox1;
        private Label m_lblEntiteRacine;
        private Label m_lblEntiteSelectionnee;
        private Panel m_panelRestrictions;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionProfilUtilisateur()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            FillListeTypes();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProfilUtilisateur(CProfilUtilisateur ProfilUtilisateur)
			:base(ProfilUtilisateur)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            FillListeTypes();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProfilUtilisateur(CProfilUtilisateur ProfilUtilisateur, CListeObjetsDonnees liste)
			:base(ProfilUtilisateur, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
            FillListeTypes();
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
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.m_arbreEO = new System.Windows.Forms.TreeView();
            this.m_panelEO = new sc2i.win32.common.C2iPanel(this.components);
            this.m_wndRelationsGroupes = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.label2 = new System.Windows.Forms.Label();
            this.m_wndListeTypesForFiltre = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblEntiteRacine = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lblEntiteSelectionnee = new System.Windows.Forms.Label();
            this.m_chkAffinable = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelProfil_inclusion = new System.Windows.Forms.Panel();
            this.m_panelModeApplication = new System.Windows.Forms.Panel();
            this.m_cmbModeApplication = new sc2i.win32.common.CComboboxAutoFilled();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtLibelleSousProfil = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lnkProfilFils = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_arbreSousProfils = new System.Windows.Forms.TreeView();
            this.m_menuSousProfil = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAjouter = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimer = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelRestrictions = new System.Windows.Forms.Panel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelEO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.m_panelProfil_inclusion.SuspendLayout();
            this.m_panelModeApplication.SuspendLayout();
            this.m_menuSousProfil.SuspendLayout();
            this.m_panelRestrictions.SuspendLayout();
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
            this.m_txtLibelle.Location = new System.Drawing.Point(98, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(314, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 108);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(822, 421);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.m_arbreEO);
            this.tabPage1.Controls.Add(this.m_panelEO);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(806, 380);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Entity restrictions|135";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Organisationnal entity|139";
            // 
            // m_arbreEO
            // 
            this.m_arbreEO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_arbreEO.CheckBoxes = true;
            this.m_extLinkField.SetLinkField(this.m_arbreEO, "");
            this.m_arbreEO.Location = new System.Drawing.Point(4, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbreEO, "");
            this.m_arbreEO.Name = "m_arbreEO";
            this.m_arbreEO.Size = new System.Drawing.Size(299, 352);
            this.m_extStyle.SetStyleBackColor(this.m_arbreEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreEO.TabIndex = 2;
            this.m_arbreEO.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreEO_AfterCheck);
            this.m_arbreEO.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreEO_BeforeCheck);
            // 
            // m_panelEO
            // 
            this.m_panelEO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEO.Controls.Add(this.m_panelRestrictions);
            this.m_panelEO.Controls.Add(this.splitter1);
            this.m_panelEO.Controls.Add(this.m_wndListeTypesForFiltre);
            this.m_panelEO.Controls.Add(this.label9);
            this.m_panelEO.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_panelEO, "");
            this.m_panelEO.Location = new System.Drawing.Point(306, 3);
            this.m_panelEO.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEO, "");
            this.m_panelEO.Name = "m_panelEO";
            this.m_panelEO.Size = new System.Drawing.Size(497, 374);
            this.m_extStyle.SetStyleBackColor(this.m_panelEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEO.TabIndex = 9;
            // 
            // m_wndRelationsGroupes
            // 
            this.m_wndRelationsGroupes.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_wndRelationsGroupes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndRelationsGroupes.EnableCustomisation = true;
            this.m_wndRelationsGroupes.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_wndRelationsGroupes, "");
            this.m_wndRelationsGroupes.Location = new System.Drawing.Point(0, 13);
            this.m_wndRelationsGroupes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndRelationsGroupes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndRelationsGroupes, "");
            this.m_wndRelationsGroupes.Name = "m_wndRelationsGroupes";
            this.m_wndRelationsGroupes.Size = new System.Drawing.Size(497, 152);
            this.m_extStyle.SetStyleBackColor(this.m_wndRelationsGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndRelationsGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndRelationsGroupes.TabIndex = 1;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 320;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.splitter1.Location = new System.Drawing.Point(0, 206);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(497, 3);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Restrictions|137";
            // 
            // m_wndListeTypesForFiltre
            // 
            this.m_wndListeTypesForFiltre.CheckBoxes = true;
            this.m_wndListeTypesForFiltre.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeTypesForFiltre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_wndListeTypesForFiltre, "");
            this.m_wndListeTypesForFiltre.Location = new System.Drawing.Point(0, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypesForFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeTypesForFiltre, "");
            this.m_wndListeTypesForFiltre.Name = "m_wndListeTypesForFiltre";
            this.m_wndListeTypesForFiltre.Size = new System.Drawing.Size(497, 122);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesForFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesForFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypesForFiltre.TabIndex = 7;
            this.m_wndListeTypesForFiltre.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypesForFiltre.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 150;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(0, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(497, 13);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 6;
            this.label9.Text = "Apply filter on|20547";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.c2iTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 71);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lblEntiteRacine);
            this.panel3.Controls.Add(this.checkBox1);
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(3, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 19);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 10;
            // 
            // m_lblEntiteRacine
            // 
            this.m_lblEntiteRacine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblEntiteRacine.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblEntiteRacine, "");
            this.m_lblEntiteRacine.Location = new System.Drawing.Point(235, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEntiteRacine, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEntiteRacine, "");
            this.m_lblEntiteRacine.Name = "m_lblEntiteRacine";
            this.m_lblEntiteRacine.Size = new System.Drawing.Size(256, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblEntiteRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEntiteRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEntiteRacine.TabIndex = 4;
            this.m_lblEntiteRacine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.checkBox1, "MasquerLesHorsBranche");
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(235, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Hide elements that are not in branch|20548";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lblEntiteSelectionnee);
            this.panel2.Controls.Add(this.m_chkAffinable);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 19);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 9;
            // 
            // m_lblEntiteSelectionnee
            // 
            this.m_lblEntiteSelectionnee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblEntiteSelectionnee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblEntiteSelectionnee, "");
            this.m_lblEntiteSelectionnee.Location = new System.Drawing.Point(268, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEntiteSelectionnee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEntiteSelectionnee, "");
            this.m_lblEntiteSelectionnee.Name = "m_lblEntiteSelectionnee";
            this.m_lblEntiteSelectionnee.Size = new System.Drawing.Size(223, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblEntiteSelectionnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEntiteSelectionnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEntiteSelectionnee.TabIndex = 3;
            this.m_lblEntiteSelectionnee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkAffinable
            // 
            this.m_chkAffinable.AutoSize = true;
            this.m_chkAffinable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_chkAffinable, "Affinable");
            this.m_chkAffinable.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAffinable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAffinable, "");
            this.m_chkAffinable.Name = "m_chkAffinable";
            this.m_chkAffinable.Size = new System.Drawing.Size(268, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkAffinable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAffinable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAffinable.TabIndex = 2;
            this.m_chkAffinable.Text = "User can select a child of Organizational entity|143";
            this.m_chkAffinable.UseVisualStyleBackColor = true;
            this.m_chkAffinable.CheckedChanged += new System.EventHandler(this.m_chkAffinable_CheckedChanged);
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 3;
            this.label7.Text = "User label|144";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "LibelleSaisieEntite");
            this.c2iTextBox1.Location = new System.Drawing.Point(110, 7);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(387, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4;
            this.c2iTextBox1.Text = "[LibelleSaisieEntite]";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelProfil_inclusion);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.m_arbreSousProfils);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(806, 380);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Dependant profiles|136";
            // 
            // m_panelProfil_inclusion
            // 
            this.m_panelProfil_inclusion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelProfil_inclusion.Controls.Add(this.m_panelModeApplication);
            this.m_panelProfil_inclusion.Controls.Add(this.m_txtLibelleSousProfil);
            this.m_panelProfil_inclusion.Controls.Add(this.label6);
            this.m_panelProfil_inclusion.Controls.Add(this.m_lnkProfilFils);
            this.m_panelProfil_inclusion.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.m_panelProfil_inclusion, "");
            this.m_panelProfil_inclusion.Location = new System.Drawing.Point(357, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelProfil_inclusion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelProfil_inclusion, "");
            this.m_panelProfil_inclusion.Name = "m_panelProfil_inclusion";
            this.m_panelProfil_inclusion.Size = new System.Drawing.Size(438, 333);
            this.m_extStyle.SetStyleBackColor(this.m_panelProfil_inclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelProfil_inclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelProfil_inclusion.TabIndex = 5;
            // 
            // m_panelModeApplication
            // 
            this.m_panelModeApplication.Controls.Add(this.m_cmbModeApplication);
            this.m_panelModeApplication.Controls.Add(this.label8);
            this.m_extLinkField.SetLinkField(this.m_panelModeApplication, "");
            this.m_panelModeApplication.Location = new System.Drawing.Point(0, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelModeApplication, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelModeApplication, "");
            this.m_panelModeApplication.Name = "m_panelModeApplication";
            this.m_panelModeApplication.Size = new System.Drawing.Size(438, 46);
            this.m_extStyle.SetStyleBackColor(this.m_panelModeApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelModeApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelModeApplication.TabIndex = 5;
            // 
            // m_cmbModeApplication
            // 
            this.m_cmbModeApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeApplication.FormattingEnabled = true;
            this.m_cmbModeApplication.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbModeApplication, "");
            this.m_cmbModeApplication.ListDonnees = null;
            this.m_cmbModeApplication.Location = new System.Drawing.Point(111, 10);
            this.m_cmbModeApplication.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeApplication, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbModeApplication, "");
            this.m_cmbModeApplication.Name = "m_cmbModeApplication";
            this.m_cmbModeApplication.NullAutorise = false;
            this.m_cmbModeApplication.ProprieteAffichee = null;
            this.m_cmbModeApplication.Size = new System.Drawing.Size(324, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeApplication.TabIndex = 5;
            this.m_cmbModeApplication.TextNull = "(empty)";
            this.m_cmbModeApplication.Tri = true;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(8, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 22);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4;
            this.label8.Text = "Apply mode|20030";
            // 
            // m_txtLibelleSousProfil
            // 
            this.m_txtLibelleSousProfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelleSousProfil, "");
            this.m_txtLibelleSousProfil.Location = new System.Drawing.Point(111, 29);
            this.m_txtLibelleSousProfil.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelleSousProfil, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelleSousProfil, "");
            this.m_txtLibelleSousProfil.Name = "m_txtLibelleSousProfil";
            this.m_txtLibelleSousProfil.Size = new System.Drawing.Size(324, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelleSousProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelleSousProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelleSousProfil.TabIndex = 3;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(8, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 22);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 2;
            this.label6.Text = "Label|50";
            // 
            // m_lnkProfilFils
            // 
            this.m_lnkProfilFils.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkProfilFils.BackColor = System.Drawing.Color.White;
            this.m_lnkProfilFils.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lnkProfilFils, "");
            this.m_lnkProfilFils.Location = new System.Drawing.Point(111, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkProfilFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkProfilFils, "");
            this.m_lnkProfilFils.Name = "m_lnkProfilFils";
            this.m_lnkProfilFils.Size = new System.Drawing.Size(324, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProfilFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProfilFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProfilFils.TabIndex = 1;
            this.m_lnkProfilFils.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProfilFils_LinkClicked);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 22);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "User profile |141";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(4, 353);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Use right click to edit dependent profiles|140";
            // 
            // m_arbreSousProfils
            // 
            this.m_arbreSousProfils.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_arbreSousProfils.CheckBoxes = true;
            this.m_extLinkField.SetLinkField(this.m_arbreSousProfils, "");
            this.m_arbreSousProfils.Location = new System.Drawing.Point(4, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreSousProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbreSousProfils, "");
            this.m_arbreSousProfils.Name = "m_arbreSousProfils";
            this.m_arbreSousProfils.Size = new System.Drawing.Size(340, 336);
            this.m_extStyle.SetStyleBackColor(this.m_arbreSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreSousProfils.TabIndex = 3;
            this.m_arbreSousProfils.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_arbreSousProfils_MouseUp);
            this.m_arbreSousProfils.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreSousProfils_AfterSelect);
            // 
            // m_menuSousProfil
            // 
            this.m_menuSousProfil.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAjouter,
            this.m_menuSupprimer});
            this.m_extLinkField.SetLinkField(this.m_menuSousProfil, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuSousProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuSousProfil, "");
            this.m_menuSousProfil.Name = "m_menuSousProfil";
            this.m_menuSousProfil.Size = new System.Drawing.Size(133, 48);
            this.m_extStyle.SetStyleBackColor(this.m_menuSousProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuSousProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_menuSousProfil.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuSousProfil_Opening);
            // 
            // m_menuAjouter
            // 
            this.m_menuAjouter.Name = "m_menuAjouter";
            this.m_menuAjouter.Size = new System.Drawing.Size(132, 22);
            this.m_menuAjouter.Text = "&Add|22";
            this.m_menuAjouter.Click += new System.EventHandler(this.m_menuAjouter_Click);
            // 
            // m_menuSupprimer
            // 
            this.m_menuSupprimer.Name = "m_menuSupprimer";
            this.m_menuSupprimer.Size = new System.Drawing.Size(132, 22);
            this.m_menuSupprimer.Text = "&Delete|18";
            this.m_menuSupprimer.Click += new System.EventHandler(this.m_menuSupprimer_Click);
            // 
            // m_panelRestrictions
            // 
            this.m_panelRestrictions.Controls.Add(this.m_wndRelationsGroupes);
            this.m_panelRestrictions.Controls.Add(this.label2);
            this.m_panelRestrictions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelRestrictions, "");
            this.m_panelRestrictions.Location = new System.Drawing.Point(0, 209);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRestrictions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelRestrictions, "");
            this.m_panelRestrictions.Name = "m_panelRestrictions";
            this.m_panelRestrictions.Size = new System.Drawing.Size(497, 165);
            this.m_extStyle.SetStyleBackColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRestrictions.TabIndex = 10;
            // 
            // CFormEditionProfilUtilisateur
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.c2iTabControl1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionProfilUtilisateur";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionProfilUtilisateur_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.m_panelEO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.m_panelProfil_inclusion.ResumeLayout(false);
            this.m_panelProfil_inclusion.PerformLayout();
            this.m_panelModeApplication.ResumeLayout(false);
            this.m_menuSousProfil.ResumeLayout(false);
            this.m_panelRestrictions.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CProfilUtilisateur ProfilUtilisateur
		{
			get
			{
				return (CProfilUtilisateur)ObjetEdite;
			}
		}

		

		//-------------------------------------------------------------------------
		private bool m_bIsInit = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bIsInit = false;
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(
				I.T("User profile|136")+" " + ProfilUtilisateur.Libelle);

			if (m_gestionnaireModeEdition.ModeEdition)
			{
				FillArbreEntites();
				if (ProfilUtilisateur.EntiteOrganisationnelle != null)
				{
					TreeNode nodeTmp = (TreeNode)m_tableEOToNode[ProfilUtilisateur.EntiteOrganisationnelle];
					if (nodeTmp != null)
					{
						nodeTmp.Checked = true;
						TreeNode nodeParent = nodeTmp.Parent;
						while (nodeParent != null)
						{
							nodeParent.Expand();
							nodeParent = nodeParent.Parent;
						}
					}
				}
			}
			else
			{
				m_arbreEO.Nodes.Clear();
				m_tableEOToNode.Clear();
				//N'affiche que l'entité sélectionnée
				TreeNode node = CreateNode(ProfilUtilisateur.EntiteOrganisationnelle);
				if (node != null)
					node.Checked = true;
			}

			CListeObjetsDonnees  listeGroupes = new CListeObjetsDonnees ( ProfilUtilisateur.ContexteDonnee, typeof ( CGroupeRestrictionSurType ) );
			m_wndRelationsGroupes.Init(listeGroupes,
				ProfilUtilisateur.RelationsRestrictions,
				ProfilUtilisateur,
				"Profil",
				"Restrictions");
			m_wndRelationsGroupes.RemplirGrille();

			m_arbreSousProfils.Nodes.Clear();
			foreach (CProfilUtilisateur_Inclusion inc in ProfilUtilisateur.Inclusions)
			{
				CreateNodeInc(inc, m_arbreSousProfils.Nodes);
			}

			m_cmbModeApplication.Fill(
				CUtilSurEnum.GetEnumsALibelle(typeof(CModeApplicationSousProfil)),
				"Libelle",
				false);
			m_panelProfil_inclusion.Visible = false;

            m_wndListeTypesForFiltre.BeginUpdate();
            foreach (ListViewItem item in m_wndListeTypesForFiltre.Items)
            {
                item.Checked = ProfilUtilisateur.ShouldFiltrerSur(((CInfoClasseDynamique)item.Tag).Classe);
            }
            m_wndListeTypesForFiltre.EndUpdate();

			m_bIsInit = true;
			return result;
		}

		//-------------------------------------------------------
		/// <summary>
		/// Remplit l'arbre d'entités avec toutes les entités existantes (pour édition)
		/// </summary>
		private void FillArbreEntites()
		{
			m_tableEOToNode.Clear();
			m_arbreEO.Nodes.Clear();
			CListeObjetsDonnees liste = new CListeObjetsDonnees(ProfilUtilisateur.ContexteDonnee, typeof(CEntiteOrganisationnelle));
			liste.Filtre = new CFiltreData(CEntiteOrganisationnelle.c_champNiveau + "=@1", 0);
			foreach (CEntiteOrganisationnelle entite in liste)
			{
				CreateNode(entite, m_arbreEO.Nodes);
			}
		}

		//-------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur  result = base.MAJ_Champs();
			if (!result)
				return result;

			ValideModifsSousProfil();

			m_wndRelationsGroupes.ApplyModifs();

			ProfilUtilisateur.EntiteOrganisationnelle = GetCheckedEntity( m_arbreEO.Nodes);

            List<Type> lstTypesChecked = new List<Type>();
            foreach (ListViewItem item in m_wndListeTypesForFiltre.CheckedItems)
            {
                lstTypesChecked.Add(((CInfoClasseDynamique)item.Tag).Classe);
            }
            if (lstTypesChecked.Count == 0)
                ProfilUtilisateur.FiltrerAucun = true;
            else if (lstTypesChecked.Count == m_wndListeTypesForFiltre.Items.Count)
                ProfilUtilisateur.FiltrerTout = true;
            else
                ProfilUtilisateur.TypesAFiltrer = lstTypesChecked.ToArray();

			
			return result;
		}

		//----------------------------------------------------
		private CEntiteOrganisationnelle GetCheckedEntity( TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
					return (CEntiteOrganisationnelle)node.Tag;
				CEntiteOrganisationnelle entite = GetCheckedEntity(node.Nodes);
				if (entite != null)
					return entite;
			}
			return null;
		}

		
		
		

		//-------------------------------------------------------
		private TreeNode CreateNode(CEntiteOrganisationnelle entite)
		{
			if (entite == null)
				return null;
			TreeNode nodeEntite = (TreeNode)m_tableEOToNode[entite];
			if (nodeEntite != null)
				return nodeEntite;
			if (entite.EntiteParente == null)
			{
				nodeEntite = new TreeNode(entite.Libelle);
				nodeEntite.Tag = entite;
				m_arbreEO.Nodes.Add(nodeEntite);
			}
			else
			{
				TreeNode nodeParent = CreateNode(entite.EntiteParente);
				nodeEntite = new TreeNode(entite.Libelle);
				nodeEntite.Tag = entite;
				nodeParent.Nodes.Add(nodeEntite);
				nodeParent.Expand();
			}
			m_tableEOToNode[entite] = nodeEntite;
			return nodeEntite;
		}

		
		//-------------------------------------------------------
		private TreeNode CreateNode(CEntiteOrganisationnelle entite, TreeNodeCollection lstNodes)
		{
			TreeNode node = new TreeNode(entite.Libelle);
			node.Tag = entite;
			m_tableEOToNode[entite] = node;
			if (entite.Equals(ProfilUtilisateur.EntiteOrganisationnelle))
			{
				node.Checked = true;
				TreeNode parent = node.Parent;
				while (parent != null)
				{
					parent.Expand();
					parent = parent.Parent;
				}
			}
			lstNodes.Add(node);
			
			foreach (CEntiteOrganisationnelle entiteFille in entite.EntiteFilles)
			{
				TreeNode nodeFils = CreateNode(entiteFille, node.Nodes);
				if (nodeFils.IsExpanded)
					node.Expand();
			}
			return node;
		}
	
		//-------------------------------------------------------------------------
		private void m_arbreEO_AfterCheck(object sender, TreeViewEventArgs e)
		{
            UpdateLibellesEO(null);
			if (e.Node != null && e.Node.Checked)
			{
				UnCheckAll(m_arbreEO.Nodes, e.Node);
                UpdateLibellesEO(e.Node);
			}
            
		}

        //-------------------------------------------------------------------------
        private void UpdateLibellesEO(TreeNode node)
        {
            CEntiteOrganisationnelle entite = node!=null?node.Tag as CEntiteOrganisationnelle:null;
            if (entite == null)
            {
                m_lblEntiteRacine.Text = "";
                m_lblEntiteSelectionnee.Text = "";
            }
            else
            {
                m_lblEntiteSelectionnee.Text = entite.Libelle;
                while (entite.EntiteParente != null)
                    entite = entite.EntiteParente;
                if (entite != null)
                    m_lblEntiteRacine.Text = entite.Libelle;
            }
        }
            

		//-------------------------------------------------------------------------
		private void UnCheckAll(TreeNodeCollection nodes, TreeNode nodeToCheck)
		{
			foreach (TreeNode node in nodes)
			{
				if (node != nodeToCheck)
					node.Checked = false;
				UnCheckAll(node.Nodes, nodeToCheck);
			}
		}

		//--------------------------------------------------------------------
		private void m_arbreEO_BeforeCheck(object sender, TreeViewCancelEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition && m_bIsInit)
				e.Cancel = true;
		}

		//--------------------------------------------------------------------
		private TreeNode m_nodeEdit = null;
		private void m_arbreSousProfils_MouseUp(object sender, MouseEventArgs e)
		{
			
			if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
			{
				TreeViewHitTestInfo hit = m_arbreSousProfils.HitTest(e.X, e.Y);
				m_nodeEdit = hit.Node;
				ShowMenu(new Point(e.X, e.Y));
			}
		}

		//--------------------------------------------------------------------
		private void ShowMenu( Point pt)
		{
			if ( m_gestionnaireModeEdition.ModeEdition )
				m_menuSousProfil.Show(m_arbreSousProfils, pt);
		}

		//--------------------------------------------------------------------
		private void m_menuSousProfil_Opening(object sender, CancelEventArgs e)
		{
			m_menuSupprimer.Visible = m_nodeEdit != null;
		}


		//--------------------------------------------------------------------
		private void m_menuAjouter_Click(object sender, EventArgs e)
		{
			CListeObjetsDonnees listeProfils = new CListeObjetsDonnees(ProfilUtilisateur.ContexteDonnee, typeof(CProfilUtilisateur));
			listeProfils.Filtre = new CFiltreData(CProfilUtilisateur.c_champId + "<>@1", ProfilUtilisateur.Id);
			CProfilUtilisateur profil = (CProfilUtilisateur)CFormSelectUnObjetDonnee.SelectObjetDonnee(I.T("Select user profil|20734"),
                listeProfils, "Libelle");
			if (profil != null)
			{
				CProfilUtilisateur_Inclusion inc = new CProfilUtilisateur_Inclusion(ProfilUtilisateur.ContexteDonnee);
				inc.CreateNewInCurrentContexte();
				if ( m_nodeEdit != null )
					inc.InclusionParente = (CProfilUtilisateur_Inclusion)m_nodeEdit.Tag;
				else
					inc.ProfilParent = ProfilUtilisateur;
				inc.ProfilFils = profil;
				inc.Libelle = profil.Libelle;
				if ( m_nodeEdit == null )
					CreateNodeInc(inc, m_arbreSousProfils.Nodes);
				else
					CreateNodeInc(inc, m_nodeEdit.Nodes);
			}
		}

		//--------------------------------------------------------------------
		private void CreateNodeInc(CProfilUtilisateur_Inclusion inc, TreeNodeCollection nodes)
		{
			TreeNode node = new TreeNode();
			node.Tag = inc;
			UpdateLibelleInc ( node );
			nodes.Add(node);
			foreach (CProfilUtilisateur_Inclusion incFille in inc.InclusionsFilles)
			{
				CreateNodeInc(incFille, node.Nodes);
			}
			node.Expand();
		}

		//--------------------------------------------------------------------
		private void UpdateLibelleInc(TreeNode node)
		{
			if (node == null)
				return;
			CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)node.Tag;
			node.Text = inc.Libelle;
			if (inc.Libelle.ToUpper().Trim() != inc.ProfilFils.Libelle.ToUpper().Trim())
				node.Text += " (" + inc.ProfilFils.Libelle + ")";
		}

		
		//--------------------------------------------------------------------
		private void m_menuSupprimer_Click(object sender, EventArgs e)
		{
			if (m_nodeEdit != null)
			{
				if (CFormAlerte.Afficher(
					I.T("Delete this profile ?|142") + " (" + m_nodeEdit.Text,
					EFormAlerteType.Question) == DialogResult.Yes)
				{
					CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)m_nodeEdit.Tag;
					//Recherche tous les liens à des profils utilisateurs qui utilisent cette inclusion
					CListeObjetsDonnees listeProfUser = inc.GetDependancesListe(CRelationUtilisateur_Profil.c_nomTable, CProfilUtilisateur_Inclusion.c_champId);

					CResultAErreur result = CResultAErreur.True;
					if ( listeProfUser.Count != 0 )
					{
						if (CFormAlerte.Afficher ( I.T("This profile is used by some users (@1). If you continue, thie profiles of these users will be changed |20032",
							listeProfUser.Count.ToString()),
							EFormAlerteType.Question) == DialogResult.No )
							return;
						result = CObjetDonneeAIdNumerique.Delete ( listeProfUser );
					}
					if ( result )
						result = inc.Delete();
					if (!result)
						CFormAlerte.Afficher(result.Erreur);
					else
						m_nodeEdit.Remove();
					m_lastNodeAffiche = null;
				}
			}
		}

		//--------------------------------------------------------------------
		private void m_arbreSousProfils_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
				ValideModifsSousProfil();
			if (e.Node == null)
			{
				m_panelProfil_inclusion.Visible = false;
				m_lastNodeAffiche = null;
				return;
			}
			m_panelProfil_inclusion.Visible = true;
			CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)e.Node.Tag;
			m_lnkProfilFils.Text = inc.ProfilFils.Libelle;
			m_txtLibelleSousProfil.Text = inc.Libelle;
			m_cmbModeApplication.SelectedValue = inc.ModeApplication;
			m_lastNodeAffiche = e.Node;
		}

		//--------------------------------------------------------------------
		private void ValideModifsSousProfil()
		{
			if (m_lastNodeAffiche == null)
				return;
			CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)m_lastNodeAffiche.Tag;
			if (inc.Row.RowState != DataRowState.Deleted)
			{
				inc.Libelle = m_txtLibelleSousProfil.Text;
				inc.ModeApplication = m_cmbModeApplication.SelectedValue as CModeApplicationSousProfil;
				UpdateLibelleInc(m_lastNodeAffiche);
			}
		}

		//--------------------------------------------------------------------
		private void m_lnkProfilFils_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_lastNodeAffiche != null)
			{
				CProfilUtilisateur_Inclusion inc = (CProfilUtilisateur_Inclusion)m_lastNodeAffiche.Tag;
				if (inc != null && inc.ProfilFils != null)
					CTimosApp.Navigateur.AffichePage(new CFormEditionProfilUtilisateur(inc.ProfilFils));
			}
		}

        //--------------------------------------------------------------------
        private void CFormEditionProfilUtilisateur_Load(object sender, EventArgs e)
        {
            
        }

        //--------------------------------------------------------------------
        private void FillListeTypes()
        {
            m_wndListeTypesForFiltre.BeginUpdate();
            m_wndListeTypesForFiltre.Items.Clear();
            List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>();
            foreach (Type tp in CContexteDonnee.GetAllTypes())
            {
                if (typeof(IElementAEO).IsAssignableFrom(tp))
                    lstTypes.Add(new CInfoClasseDynamique(tp, DynamicClassAttribute.GetNomConvivial(tp)));
            }
            lstTypes.Sort((x,y)=>x.Nom.CompareTo(y.Nom));
            foreach ( CInfoClasseDynamique info in lstTypes )
            {
                ListViewItem item = new ListViewItem(info.Nom);
                item.Tag = info;
                m_wndListeTypesForFiltre.Items.Add ( item );
            }
            m_wndListeTypesForFiltre.EndUpdate();
        }

        private void m_chkAffinable_CheckedChanged(object sender, EventArgs e)
        {

        }

		
	}
}

