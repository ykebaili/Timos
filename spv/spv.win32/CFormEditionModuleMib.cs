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
using sc2i.multitiers.client;
using System.Collections.Generic;
using timos.data;
using SpvNativeWrapper;
using System.IO;
using sc2i.documents;


namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvMibmodule))]
	public class CFormEditionModuleMib: CFormEditionStandard, IFormNavigable
	{
        private string m_strNomFichierLocal = "";
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtNomUtilisateur;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private Label label9;
        private System.ComponentModel.IContainer components = null;
        private C2iTextBox m_txtVersion;
        private Label label7;
        private C2iTextBox m_txtCommentaire;
        private GroupBox m_grpBoxRechercheModule;
        private Button m_buttonParcourir;
        private C2iTextBox m_txtFichierModule;
        private C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage m_pageGeneral;
        private C2iTextBox m_txtDateCompilation;
        private Label label6;
        private C2iTextBox m_txtVersionSMI;
        private Label label5;
        private C2iTextBox m_txtDateVersion;
        private Label label4;
        private C2iTextBox m_txtNomOfficiel;
        private Label label3;
        private Crownwood.Magic.Controls.TabPage m_pageVariablesScalaires;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;

        private const string c_noeudVar = "Variables";
        private const string c_noeudTab = "Tables";
        private Crownwood.Magic.Controls.TabPage m_pageTables;
        private Crownwood.Magic.Controls.TabPage m_pageTraps;
        private CPanelListeSpeedStandard m_panelVariables;
        private CPanelListeSpeedStandard m_panelTables;
        private CPanelListeSpeedStandard m_panelVariablesTable;
        private CPanelListeSpeedStandard m_panelTraps;
        private Button m_buttonCompiler;
        private Label label8;
        private Button m_buttonCopy;
        private LinkLabel m_linkLabel;
        private CComboBoxArbreObjetDonneesHierarchique m_comboBoxFamille;
        private SplitContainer splitContainer1;
        private const string c_noeudTrap = "Traps";

        public CFormEditionModuleMib()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionModuleMib(CSpvMibmodule modulemib)
            : base(modulemib)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionModuleMib(CSpvMibmodule modulemib, CListeObjetsDonnees liste)
            : base(modulemib, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionModuleMib));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNomUtilisateur = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label9 = new System.Windows.Forms.Label();
            this.m_buttonCompiler = new System.Windows.Forms.Button();
            this.m_comboBoxFamille = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_linkLabel = new System.Windows.Forms.LinkLabel();
            this.m_txtVersion = new sc2i.win32.common.C2iTextBox();
            this.m_grpBoxRechercheModule = new System.Windows.Forms.GroupBox();
            this.m_buttonCopy = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtFichierModule = new sc2i.win32.common.C2iTextBox();
            this.m_buttonParcourir = new System.Windows.Forms.Button();
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageTraps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelTraps = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageGeneral = new Crownwood.Magic.Controls.TabPage();
            this.m_txtDateCompilation = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtVersionSMI = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtDateVersion = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtNomOfficiel = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_pageVariablesScalaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelVariables = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageTables = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_panelTables = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelVariablesTable = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_grpBoxRechercheModule.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageTraps.SuspendLayout();
            this.m_pageGeneral.SuspendLayout();
            this.m_pageVariablesScalaires.SuspendLayout();
            this.m_pageTables.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(758, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 34);
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
            this.m_panelCle.Location = new System.Drawing.Point(671, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.m_panelMenu.Size = new System.Drawing.Size(911, 34);
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
            // m_txtNomUtilisateur
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNomUtilisateur, "NomModuleUtilisateur");
            this.m_txtNomUtilisateur.Location = new System.Drawing.Point(115, 5);
            this.m_txtNomUtilisateur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomUtilisateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNomUtilisateur.Name = "m_txtNomUtilisateur";
            this.m_txtNomUtilisateur.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomUtilisateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomUtilisateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomUtilisateur.TabIndex = 0;
            this.m_txtNomUtilisateur.Text = "[NomModuleUtilisateur]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_txtNomUtilisateur);
            this.c2iPanelOmbre4.Controls.Add(this.label9);
            this.c2iPanelOmbre4.Controls.Add(this.m_buttonCompiler);
            this.c2iPanelOmbre4.Controls.Add(this.m_comboBoxFamille);
            this.c2iPanelOmbre4.Controls.Add(this.m_linkLabel);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtVersion);
            this.c2iPanelOmbre4.Controls.Add(this.m_grpBoxRechercheModule);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtCommentaire);
            this.c2iPanelOmbre4.Controls.Add(this.label7);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 56);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(919, 267);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(22, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4006;
            this.label9.Text = "Label|3";
            // 
            // m_buttonCompiler
            // 
            this.m_extLinkField.SetLinkField(this.m_buttonCompiler, "");
            this.m_buttonCompiler.Location = new System.Drawing.Point(568, 174);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_buttonCompiler, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_buttonCompiler.Name = "m_buttonCompiler";
            this.m_buttonCompiler.Size = new System.Drawing.Size(93, 66);
            this.m_extStyle.SetStyleBackColor(this.m_buttonCompiler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_buttonCompiler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_buttonCompiler.TabIndex = 4019;
            this.m_buttonCompiler.Text = "Compile|50052";
            this.m_buttonCompiler.UseVisualStyleBackColor = true;
            this.m_buttonCompiler.Click += new System.EventHandler(this.m_buttonCompiler_Click);
            // 
            // m_comboBoxFamille
            // 
            this.m_comboBoxFamille.BackColor = System.Drawing.Color.White;
            this.m_comboBoxFamille.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_comboBoxFamille, "");
            this.m_comboBoxFamille.Location = new System.Drawing.Point(115, 36);
            this.m_comboBoxFamille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboBoxFamille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_comboBoxFamille.Name = "m_comboBoxFamille";
            this.m_comboBoxFamille.NullAutorise = false;
            this.m_comboBoxFamille.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_comboBoxFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_comboBoxFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_comboBoxFamille.TabIndex = 4021;
            this.m_comboBoxFamille.TextNull = "None";
            this.m_comboBoxFamille.ElementSelectionneChanged += new System.EventHandler(this.m_comboBoxFamille_ElementSelectionneChanged);
            // 
            // m_linkLabel
            // 
            this.m_linkLabel.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_linkLabel, "");
            this.m_linkLabel.Location = new System.Drawing.Point(22, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_linkLabel.Name = "m_linkLabel";
            this.m_linkLabel.Size = new System.Drawing.Size(68, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkLabel.TabIndex = 4020;
            this.m_linkLabel.TabStop = true;
            this.m_linkLabel.Text = "Family|50053";
            // 
            // m_txtVersion
            // 
            this.m_extLinkField.SetLinkField(this.m_txtVersion, "Version");
            this.m_txtVersion.Location = new System.Drawing.Point(537, 5);
            this.m_txtVersion.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtVersion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtVersion.Name = "m_txtVersion";
            this.m_txtVersion.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtVersion.TabIndex = 4007;
            this.m_txtVersion.Text = "[Version]";
            // 
            // m_grpBoxRechercheModule
            // 
            this.m_grpBoxRechercheModule.Controls.Add(this.m_buttonCopy);
            this.m_grpBoxRechercheModule.Controls.Add(this.label8);
            this.m_grpBoxRechercheModule.Controls.Add(this.m_txtFichierModule);
            this.m_grpBoxRechercheModule.Controls.Add(this.m_buttonParcourir);
            this.m_extLinkField.SetLinkField(this.m_grpBoxRechercheModule, "");
            this.m_grpBoxRechercheModule.Location = new System.Drawing.Point(13, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_grpBoxRechercheModule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_grpBoxRechercheModule.Name = "m_grpBoxRechercheModule";
            this.m_grpBoxRechercheModule.Size = new System.Drawing.Size(668, 89);
            this.m_extStyle.SetStyleBackColor(this.m_grpBoxRechercheModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_grpBoxRechercheModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_grpBoxRechercheModule.TabIndex = 4018;
            this.m_grpBoxRechercheModule.TabStop = false;
            this.m_grpBoxRechercheModule.Text = "MIB File|50023";
            // 
            // m_buttonCopy
            // 
            this.m_extLinkField.SetLinkField(this.m_buttonCopy, "");
            this.m_buttonCopy.Location = new System.Drawing.Point(12, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_buttonCopy, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_buttonCopy.Name = "m_buttonCopy";
            this.m_buttonCopy.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_buttonCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_buttonCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_buttonCopy.TabIndex = 4021;
            this.m_buttonCopy.Text = "Copy|50056";
            this.m_buttonCopy.UseVisualStyleBackColor = true;
            this.m_buttonCopy.Click += new System.EventHandler(this.m_buttonCopy_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(106, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4020;
            this.label8.Text = "Path when including file in GED|50055";
            // 
            // m_txtFichierModule
            // 
            this.m_extLinkField.SetLinkField(this.m_txtFichierModule, "FichierModule");
            this.m_txtFichierModule.Location = new System.Drawing.Point(105, 54);
            this.m_txtFichierModule.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFichierModule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFichierModule.Name = "m_txtFichierModule";
            this.m_txtFichierModule.Size = new System.Drawing.Size(543, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFichierModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFichierModule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFichierModule.TabIndex = 4019;
            this.m_txtFichierModule.Text = "[FichierModule]";
            // 
            // m_buttonParcourir
            // 
            this.m_extLinkField.SetLinkField(this.m_buttonParcourir, "");
            this.m_buttonParcourir.Location = new System.Drawing.Point(12, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_buttonParcourir, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_buttonParcourir.Name = "m_buttonParcourir";
            this.m_buttonParcourir.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_buttonParcourir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_buttonParcourir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_buttonParcourir.TabIndex = 0;
            this.m_buttonParcourir.Text = "Search|50024";
            this.m_buttonParcourir.UseVisualStyleBackColor = true;
            this.m_buttonParcourir.Click += new System.EventHandler(this.m_buttonParcourir_Click);
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.AcceptsReturn = true;
            this.m_extLinkField.SetLinkField(this.m_txtCommentaire, "Commentaire");
            this.m_txtCommentaire.Location = new System.Drawing.Point(13, 175);
            this.m_txtCommentaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCommentaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(549, 66);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommentaire.TabIndex = 4017;
            this.m_txtCommentaire.Text = "[Commentaire]";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(16, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4016;
            this.label7.Text = "Comment|132";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(410, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Version number|50018";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "AlarmCause";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Alarme cause(s)|135";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 250;
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
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(12, 329);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 3;
            this.m_TabControl.SelectedTab = this.m_pageTraps;
            this.m_TabControl.Size = new System.Drawing.Size(919, 483);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TabControl.TabIndex = 4003;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageGeneral,
            this.m_pageVariablesScalaires,
            this.m_pageTables,
            this.m_pageTraps});
            // 
            // m_pageTraps
            // 
            this.m_pageTraps.Controls.Add(this.m_panelTraps);
            this.m_extLinkField.SetLinkField(this.m_pageTraps, "");
            this.m_pageTraps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTraps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageTraps.Name = "m_pageTraps";
            this.m_pageTraps.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_pageTraps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTraps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTraps.TabIndex = 13;
            this.m_pageTraps.Title = "Traps|50028";
            // 
            // m_panelTraps
            // 
            this.m_panelTraps.AllowArbre = true;
            this.m_panelTraps.AllowCustomisation = true;
            this.m_panelTraps.BoutonAjouterVisible = false;
            this.m_panelTraps.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "NomObjetUtilisateur";
            glColumn1.Text = "Name|134";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelTraps.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelTraps.ContexteUtilisation = "";
            this.m_panelTraps.ControlFiltreStandard = null;
            this.m_panelTraps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTraps.ElementSelectionne = null;
            this.m_panelTraps.EnableCustomisation = true;
            this.m_panelTraps.FiltreDeBase = null;
            this.m_panelTraps.FiltreDeBaseEnAjout = false;
            this.m_panelTraps.FiltrePrefere = null;
            this.m_panelTraps.FiltreRapide = null;
            this.m_panelTraps.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelTraps, "");
            this.m_panelTraps.ListeObjets = null;
            this.m_panelTraps.Location = new System.Drawing.Point(0, 0);
            this.m_panelTraps.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTraps, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelTraps.ModeQuickSearch = false;
            this.m_panelTraps.ModeSelection = false;
            this.m_panelTraps.MultiSelect = false;
            this.m_panelTraps.Name = "m_panelTraps";
            this.m_panelTraps.Navigateur = null;
            this.m_panelTraps.ProprieteObjetAEditer = null;
            this.m_panelTraps.QuickSearchText = "";
            this.m_panelTraps.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelTraps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTraps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTraps.TabIndex = 14;
            this.m_panelTraps.TrierAuClicSurEnteteColonne = true;
            this.m_panelTraps.UseCheckBoxes = false;
            // 
            // m_pageGeneral
            // 
            this.m_pageGeneral.Controls.Add(this.m_txtDateCompilation);
            this.m_pageGeneral.Controls.Add(this.label6);
            this.m_pageGeneral.Controls.Add(this.m_txtVersionSMI);
            this.m_pageGeneral.Controls.Add(this.label5);
            this.m_pageGeneral.Controls.Add(this.m_txtDateVersion);
            this.m_pageGeneral.Controls.Add(this.label4);
            this.m_pageGeneral.Controls.Add(this.m_txtNomOfficiel);
            this.m_pageGeneral.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.m_pageGeneral, "");
            this.m_pageGeneral.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageGeneral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageGeneral.Name = "m_pageGeneral";
            this.m_pageGeneral.Selected = false;
            this.m_pageGeneral.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_pageGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageGeneral.TabIndex = 10;
            this.m_pageGeneral.Title = "General|50025";
            // 
            // m_txtDateCompilation
            // 
            this.m_extLinkField.SetLinkField(this.m_txtDateCompilation, "DateCompilation");
            this.m_txtDateCompilation.Location = new System.Drawing.Point(282, 103);
            this.m_txtDateCompilation.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateCompilation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtDateCompilation.Name = "m_txtDateCompilation";
            this.m_txtDateCompilation.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtDateCompilation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDateCompilation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateCompilation.TabIndex = 4023;
            this.m_txtDateCompilation.Text = "[DateCompilation]";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(10, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(239, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4022;
            this.label6.Text = "Last good compilation date|50022";
            // 
            // m_txtVersionSMI
            // 
            this.m_extLinkField.SetLinkField(this.m_txtVersionSMI, "");
            this.m_txtVersionSMI.Location = new System.Drawing.Point(282, 74);
            this.m_txtVersionSMI.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtVersionSMI, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtVersionSMI.Name = "m_txtVersionSMI";
            this.m_txtVersionSMI.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtVersionSMI, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtVersionSMI, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtVersionSMI.TabIndex = 4021;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(10, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4020;
            this.label5.Text = "SMI version|50021";
            // 
            // m_txtDateVersion
            // 
            this.m_extLinkField.SetLinkField(this.m_txtDateVersion, "DateVersion");
            this.m_txtDateVersion.Location = new System.Drawing.Point(282, 45);
            this.m_txtDateVersion.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDateVersion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtDateVersion.Name = "m_txtDateVersion";
            this.m_txtDateVersion.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtDateVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDateVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDateVersion.TabIndex = 4019;
            this.m_txtDateVersion.Text = "[DateVersion]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(10, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4018;
            this.label4.Text = "Module date|50020";
            // 
            // m_txtNomOfficiel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNomOfficiel, "NomModuleOfficiel");
            this.m_txtNomOfficiel.Location = new System.Drawing.Point(282, 16);
            this.m_txtNomOfficiel.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomOfficiel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtNomOfficiel.Name = "m_txtNomOfficiel";
            this.m_txtNomOfficiel.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomOfficiel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomOfficiel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomOfficiel.TabIndex = 4017;
            this.m_txtNomOfficiel.Text = "[NomModuleOfficiel]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4016;
            this.label3.Text = "SNMP Module name|50019";
            // 
            // m_pageVariablesScalaires
            // 
            this.m_pageVariablesScalaires.Controls.Add(this.m_panelVariables);
            this.m_extLinkField.SetLinkField(this.m_pageVariablesScalaires, "");
            this.m_pageVariablesScalaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageVariablesScalaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageVariablesScalaires.Name = "m_pageVariablesScalaires";
            this.m_pageVariablesScalaires.Selected = false;
            this.m_pageVariablesScalaires.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_pageVariablesScalaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageVariablesScalaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageVariablesScalaires.TabIndex = 11;
            this.m_pageVariablesScalaires.Title = "Scalar variables|50046";
            // 
            // m_panelVariables
            // 
            this.m_panelVariables.AllowArbre = true;
            this.m_panelVariables.AllowCustomisation = true;
            this.m_panelVariables.BoutonAjouterVisible = false;
            this.m_panelVariables.BoutonSupprimerVisible = false;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "NomObjetUtilisateur";
            glColumn2.Text = "Name|134";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelVariables.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelVariables.ContexteUtilisation = "";
            this.m_panelVariables.ControlFiltreStandard = null;
            this.m_panelVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelVariables.ElementSelectionne = null;
            this.m_panelVariables.EnableCustomisation = true;
            this.m_panelVariables.FiltreDeBase = null;
            this.m_panelVariables.FiltreDeBaseEnAjout = false;
            this.m_panelVariables.FiltrePrefere = null;
            this.m_panelVariables.FiltreRapide = null;
            this.m_panelVariables.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelVariables, "");
            this.m_panelVariables.ListeObjets = null;
            this.m_panelVariables.Location = new System.Drawing.Point(0, 0);
            this.m_panelVariables.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelVariables, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelVariables.ModeQuickSearch = false;
            this.m_panelVariables.ModeSelection = false;
            this.m_panelVariables.MultiSelect = false;
            this.m_panelVariables.Name = "m_panelVariables";
            this.m_panelVariables.Navigateur = null;
            this.m_panelVariables.ProprieteObjetAEditer = null;
            this.m_panelVariables.QuickSearchText = "";
            this.m_panelVariables.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVariables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVariables.TabIndex = 0;
            this.m_panelVariables.TrierAuClicSurEnteteColonne = true;
            this.m_panelVariables.UseCheckBoxes = false;
            // 
            // m_pageTables
            // 
            this.m_pageTables.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_pageTables, "");
            this.m_pageTables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageTables.Name = "m_pageTables";
            this.m_pageTables.Selected = false;
            this.m_pageTables.Size = new System.Drawing.Size(903, 442);
            this.m_extStyle.SetStyleBackColor(this.m_pageTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTables.TabIndex = 12;
            this.m_pageTables.Title = "Tables|50027";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_panelTables);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelVariablesTable);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(903, 442);
            this.splitContainer1.SplitterDistance = 452;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 2;
            // 
            // m_panelTables
            // 
            this.m_panelTables.AllowArbre = true;
            this.m_panelTables.AllowCustomisation = true;
            this.m_panelTables.BoutonAjouterVisible = false;
            this.m_panelTables.BoutonSupprimerVisible = false;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "NomObjetUtilisateur";
            glColumn3.Text = "Name|134";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            this.m_panelTables.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelTables.ContexteUtilisation = "";
            this.m_panelTables.ControlFiltreStandard = null;
            this.m_panelTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTables.ElementSelectionne = null;
            this.m_panelTables.EnableCustomisation = true;
            this.m_panelTables.FiltreDeBase = null;
            this.m_panelTables.FiltreDeBaseEnAjout = false;
            this.m_panelTables.FiltrePrefere = null;
            this.m_panelTables.FiltreRapide = null;
            this.m_panelTables.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelTables, "");
            this.m_panelTables.ListeObjets = null;
            this.m_panelTables.Location = new System.Drawing.Point(0, 0);
            this.m_panelTables.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTables, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelTables.ModeQuickSearch = false;
            this.m_panelTables.ModeSelection = false;
            this.m_panelTables.MultiSelect = false;
            this.m_panelTables.Name = "m_panelTables";
            this.m_panelTables.Navigateur = null;
            this.m_panelTables.ProprieteObjetAEditer = null;
            this.m_panelTables.QuickSearchText = "";
            this.m_panelTables.Size = new System.Drawing.Size(452, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTables.TabIndex = 0;
            this.m_panelTables.TrierAuClicSurEnteteColonne = true;
            this.m_panelTables.UseCheckBoxes = false;
            this.m_panelTables.OnObjetDoubleClick += new System.EventHandler(this.m_panelTables_OnObjetDoubleClick);
            // 
            // m_panelVariablesTable
            // 
            this.m_panelVariablesTable.AllowArbre = true;
            this.m_panelVariablesTable.AllowCustomisation = true;
            this.m_panelVariablesTable.BoutonAjouterVisible = false;
            this.m_panelVariablesTable.BoutonSupprimerVisible = false;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "NomTable";
            glColumn4.Propriete = "NomOfficielObjetPere";
            glColumn4.Text = "Table name|50002";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "NomVariable";
            glColumn5.Propriete = "NomObjetUtilisateur";
            glColumn5.Text = "Variable name|50047";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            this.m_panelVariablesTable.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4,
            glColumn5});
            this.m_panelVariablesTable.ContexteUtilisation = "";
            this.m_panelVariablesTable.ControlFiltreStandard = null;
            this.m_panelVariablesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelVariablesTable.ElementSelectionne = null;
            this.m_panelVariablesTable.EnableCustomisation = true;
            this.m_panelVariablesTable.FiltreDeBase = null;
            this.m_panelVariablesTable.FiltreDeBaseEnAjout = false;
            this.m_panelVariablesTable.FiltrePrefere = null;
            this.m_panelVariablesTable.FiltreRapide = null;
            this.m_panelVariablesTable.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelVariablesTable, "");
            this.m_panelVariablesTable.ListeObjets = null;
            this.m_panelVariablesTable.Location = new System.Drawing.Point(0, 0);
            this.m_panelVariablesTable.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelVariablesTable, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelVariablesTable.ModeQuickSearch = false;
            this.m_panelVariablesTable.ModeSelection = false;
            this.m_panelVariablesTable.MultiSelect = false;
            this.m_panelVariablesTable.Name = "m_panelVariablesTable";
            this.m_panelVariablesTable.Navigateur = null;
            this.m_panelVariablesTable.ProprieteObjetAEditer = null;
            this.m_panelVariablesTable.QuickSearchText = "";
            this.m_panelVariablesTable.Size = new System.Drawing.Size(447, 442);
            this.m_extStyle.SetStyleBackColor(this.m_panelVariablesTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVariablesTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVariablesTable.TabIndex = 1;
            this.m_panelVariablesTable.TrierAuClicSurEnteteColonne = true;
            this.m_panelVariablesTable.UseCheckBoxes = false;
            // 
            // CFormEditionModuleMib
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(943, 811);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionModuleMib";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionModuleMib_OnInitPage);
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
            this.m_grpBoxRechercheModule.ResumeLayout(false);
            this.m_grpBoxRechercheModule.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageTraps.ResumeLayout(false);
            this.m_pageGeneral.ResumeLayout(false);
            this.m_pageGeneral.PerformLayout();
            this.m_pageVariablesScalaires.ResumeLayout(false);
            this.m_pageTables.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
        protected CSpvMibmodule ModuleMib
		{
			get
			{
				return (CSpvMibmodule)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
			if (!result)
				return result;

            AffecterTitre(I.T("MIB Module|10012"));

            if (ModuleMib.VersionSmi != null)
                this.m_txtVersionSMI.Text = ModuleMib.VersionSmi.ToString();
            else
                this.m_txtVersionSMI.Text = "";

            InitComboFamille();
            m_comboBoxFamille.ElementSelectionne = ModuleMib.FamilleMere;

			return result;
		}

        private void InitComboFamille()
        {
            //throw new Exception("The method or operation is not implemented.");
            CSpvFamilleMibmodule lastFamille = (CSpvFamilleMibmodule)m_comboBoxFamille.ElementSelectionne;
            m_comboBoxFamille.Init(
                typeof(CSpvFamilleMibmodule),
                "FamillesFilles",
                CSpvFamilleMibmodule.c_champFAMILLE_BINDINGID,
                "Libelle",
                typeof(CFormEditionFamilleModulesMib),
                null,
                null);
            m_comboBoxFamille.ElementSelectionne = lastFamille;			
        }


        private CResultAErreur CFormEditionModuleMib_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageVariablesScalaires)
            {
                m_panelVariables.InitFromListeObjets(
                ModuleMib.VariablesScalaires,
                typeof(CSpvMibVariable),
                typeof(CFormEditionObjetMib),
                ModuleMib,
                "");
            }
            else if (page == m_pageTables)
            {
                m_panelTables.InitFromListeObjets(
                ModuleMib.Tables,
                typeof(CSpvMibTable),
                typeof(CFormEditionObjetMib),
                ModuleMib,
                "");

                m_panelVariablesTable.InitFromListeObjets(
                ModuleMib.VariablesTables,
                typeof(CSpvMibVariable),
                typeof(CFormEditionObjetMib),
                ModuleMib,
                "");
            }
            else if (page == m_pageTraps)
                m_panelTraps.InitFromListeObjets(
                ModuleMib.Traps,
                typeof(CSpvMibTrap),
                typeof(CFormEditionObjetMib),
                ModuleMib,
                "");

            return result;
        }


        private void MajListeVariablesTable()
        {
            CSpvMibTable table = (CSpvMibTable)m_panelTables.ElementSelectionne;
            
            if (table != null)
            {
                m_panelVariablesTable.InitFromListeObjets(
                table.Variables,
                typeof(CSpvMibVariable),
                typeof(CFormEditionObjetMib),
                ModuleMib,
                "");
            }
        }


        private void OuvrirTable()
        {
            if (m_panelTables.GestionnaireAjoutModifSuppression != null && m_panelTables.BoutonModifierVisible)
            {
                CSpvMibTable table = (CSpvMibTable)m_panelTables.ElementSelectionne;
                CResultAErreur result = m_panelTables.GestionnaireAjoutModifSuppression.Modifier(table, m_panelTables.ListeObjets);
                if (!result)
                    CFormAlerte.Afficher(result);
            }
        }

        private void m_panelTables_OnObjetDoubleClick(object sender, EventArgs e)
        {
            OuvrirTable();
        }



		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;


            ModuleMib.VersionSmi = (m_txtVersionSMI.TextLength == 0) ? null :
                ModuleMib.VersionSmi = Convert.ToInt32(m_txtVersionSMI.Text);

            if (File.Exists(m_strNomFichierLocal))
            {
                ModuleMib.FichierModule = m_strNomFichierLocal;
                CDocumentGED doc = ModuleMib.DocumentGEDModuleMib;
                CProxyGED proxy = new CProxyGED(ModuleMib.ContexteDonnee.IdSession,
                    doc == null ? null : doc.ReferenceDoc);
                proxy.AttacheToLocal(m_strNomFichierLocal);
                result = proxy.UpdateGed();
                if (result)
                {
                    if (doc == null)
                    {
                        doc = new CDocumentGED(ModuleMib.ContexteDonnee);
                        doc.CreateNewInCurrentContexte();
                        doc.Descriptif = "";
                        doc.DateCreation = DateTime.Now;
                        ModuleMib.DocumentGEDModuleMib = doc;
                    }
                    doc.Libelle = I.T("Mib file|20002");
                    doc.ReferenceDoc = (CReferenceDocument)result.Data;
                    doc.DateMAJ = DateTime.Now;
                    doc.NumVersion++;
                    doc.IsFichierSysteme = true;
                    ModuleMib.DocumentGEDModuleMib = doc;


                }
                
            }


           
           	return result;
        }

        private void m_buttonParcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                m_strNomFichierLocal = dlg.FileName;
                m_txtFichierModule.Text = dlg.FileName;
            }
        }

        private void m_buttonCompiler_Click(object sender, EventArgs e)
        {
            CResultAErreur result = ModuleMib.Compile();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
            }
            else
            {
                CFormAlerte.Afficher(I.T("Compile success|50058"));
                Refresh();
            }
        }

        private void m_buttonCopy_Click(object sender, EventArgs e)
        {
            CDocumentGED doc = ModuleMib.DocumentGEDModuleMib;
            string strFile;

            if (doc == null)
            {
                CFormAlerte.Afficher(I.T("Mib module @1 should be associated to a mib file|20001", ModuleMib.NomModuleOfficiel), 
                                     EFormAlerteType.Erreur);
                return;
            }

            using (CProxyGED proxy = new CProxyGED(ModuleMib.ContexteDonnee.IdSession, doc.ReferenceDoc))
            {
                CResultAErreur result = proxy.CopieFichierEnLocal();
                if (!result)
                {
                    CFormAlerte.Afficher(result);
                    return;
                }
                strFile = proxy.NomFichierLocal;
            }

            if (strFile != "")
            {
                SaveFileDialog dlg = new SaveFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK && dlg.FileName != "")
                    File.Copy(strFile, dlg.FileName);
            }
        }

        private void m_comboBoxFamille_ElementSelectionneChanged(object sender, EventArgs e)
        {
            ModuleMib.FamilleMere = (CSpvFamilleMibmodule)m_comboBoxFamille.ElementSelectionne;
        }

	}
}

