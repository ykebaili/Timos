using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Diagnostics;

using System.Windows.Forms;
using sc2i.documents;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.data.dynamic;
using sc2i.win32.data.dynamic;
using sc2i.multitiers.client;
using sc2i.workflow;
using sc2i.expression;
using sc2i.formulaire.win32.editor;
using futurocom.easyquery;
using sc2i.data.dynamic.EasyQuery;
using sc2i.win32.data.dynamic.EasyQuery;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeDonneeCumulee))]
	public class CFormEditionTypeDonneeCumulee : CFormEditionStdTimos, IFormNavigable
	{
        private CDefinitionJeuDonneesEasyQuery m_defEasyQuery = null;

		#region Designer generated code

		private DataTable m_tableTest = null;
		private CFiltreDynamique m_filtreStructure = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private sc2i.win32.common.C2iTextBox c2iTextBox2;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private System.Windows.Forms.Button m_btnTesterRequete;
		private sc2i.win32.common.C2iTabControl m_tabCleValeur;
		private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private Crownwood.Magic.Controls.TabPage tabPage5;
        private Crownwood.Magic.Controls.TabPage tabPage6;
		private System.Windows.Forms.Label m_lblTexteCle;
        private sc2i.win32.common.C2iComboBox m_cmbValeurDecimale;
        private sc2i.win32.common.C2iComboBox m_cmbValeurDate;
        private sc2i.win32.common.C2iComboBox m_cmbValeurTexte;
        private System.Windows.Forms.Label m_lblValeurDecimale;
        private System.Windows.Forms.Label m_lblValeurDate;
        private System.Windows.Forms.Label m_lblValeurTexte;
		private sc2i.win32.common.C2iDataGrid m_gridCles;
        private sc2i.win32.common.C2iDataGrid m_gridValeursDecimales;
        private sc2i.win32.common.C2iDataGrid m_gridValeursDates;
        private sc2i.win32.common.C2iDataGrid m_gridValeursTextes;
		private System.Windows.Forms.Label Description;
		private sc2i.win32.data.dynamic.CPanelEditRequete m_panelRequete;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Button m_btnVoirResultat;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private System.Windows.Forms.LinkLabel m_lnkRecalculer;
		private System.Windows.Forms.CheckBox m_chkToutSupprimer;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelTachesPlanifiees;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private sc2i.win32.common.C2iComboBox m_cmbTypeElements;
		private sc2i.win32.common.C2iPanel m_panelControlsForGrille;
		private System.Windows.Forms.CheckBox m_chkPasDeSuppression;
		private RadioButton m_radioRequete;
		private RadioButton m_radioStructure;
		private C2iPanel m_panelContientStructure;
		private LinkLabel m_lnkFiltrer;
		private CPanelEditionStructureDonnee m_panelStructure;
		private Panel m_panelRadios;
		private Panel m_panelTest;
        private RadioButton m_radioNoStructure;
        private RadioButton m_radioEasyQuery;
        private Panel m_panelEasyQuery;
        private Button m_btnEditeEasyQuery;
		private sc2i.win32.common.C2iComboBox m_cmbCle;
		
	
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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeDonneeCumulee));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.Description = new System.Windows.Forms.Label();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_panelControlsForGrille = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbValeurDecimale = new sc2i.win32.common.C2iComboBox();
            this.m_lblValeurDecimale = new System.Windows.Forms.Label();
            this.m_cmbValeurDate = new sc2i.win32.common.C2iComboBox();
            this.m_lblValeurDate = new System.Windows.Forms.Label();
            this.m_cmbValeurTexte = new sc2i.win32.common.C2iComboBox();
            this.m_lblValeurTexte = new System.Windows.Forms.Label();
            this.m_cmbCle = new sc2i.win32.common.C2iComboBox();
            this.m_lblTexteCle = new System.Windows.Forms.Label();
            this.m_cmbTypeElements = new sc2i.win32.common.C2iComboBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEasyQuery = new System.Windows.Forms.Panel();
            this.m_btnEditeEasyQuery = new System.Windows.Forms.Button();
            this.m_panelRequete = new sc2i.win32.data.dynamic.CPanelEditRequete();
            this.m_panelContientStructure = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkFiltrer = new System.Windows.Forms.LinkLabel();
            this.m_panelStructure = new sc2i.win32.data.dynamic.CPanelEditionStructureDonnee();
            this.m_panelRadios = new System.Windows.Forms.Panel();
            this.m_radioNoStructure = new System.Windows.Forms.RadioButton();
            this.m_radioEasyQuery = new System.Windows.Forms.RadioButton();
            this.m_radioRequete = new System.Windows.Forms.RadioButton();
            this.m_radioStructure = new System.Windows.Forms.RadioButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_tabCleValeur = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_gridCles = new sc2i.win32.common.C2iDataGrid(this.components);
            this.m_chkPasDeSuppression = new System.Windows.Forms.CheckBox();
            this.m_chkToutSupprimer = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_gridValeursDecimales = new sc2i.win32.common.C2iDataGrid(this.components);
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.m_gridValeursDates = new sc2i.win32.common.C2iDataGrid(this.components);
            this.tabPage6 = new Crownwood.Magic.Controls.TabPage();
            this.m_gridValeursTextes = new sc2i.win32.common.C2iDataGrid(this.components);
            this.m_panelTest = new System.Windows.Forms.Panel();
            this.m_btnVoirResultat = new System.Windows.Forms.Button();
            this.m_btnTesterRequete = new System.Windows.Forms.Button();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelTachesPlanifiees = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_lnkRecalculer = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_panelControlsForGrille.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.m_panelEasyQuery.SuspendLayout();
            this.m_panelContientStructure.SuspendLayout();
            this.m_panelRadios.SuspendLayout();
            this.m_tabCleValeur.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridCles)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursDecimales)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursDates)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursTextes)).BeginInit();
            this.m_panelTest.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(687, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(579, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(894, 28);
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(120, 5);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 128;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(378, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.Description);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_panelControlsForGrille);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 36);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(841, 110);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // Description
            // 
            this.m_extLinkField.SetLinkField(this.Description, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.Description, false);
            this.Description.Location = new System.Drawing.Point(16, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.Description, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.Description, "");
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.Description, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.Description, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Description.TabIndex = 4006;
            this.Description.Text = "Description|41";
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox2, true);
            this.c2iTextBox2.Location = new System.Drawing.Point(120, 50);
            this.c2iTextBox2.LockEdition = false;
            this.c2iTextBox2.MaxLength = 256;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Multiline = true;
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(693, 34);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 4005;
            this.c2iTextBox2.Text = "[Description]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Code|40";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(120, 27);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 64;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(208, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4003;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // m_panelControlsForGrille
            // 
            this.m_panelControlsForGrille.Controls.Add(this.m_cmbValeurDecimale);
            this.m_panelControlsForGrille.Controls.Add(this.m_lblValeurDecimale);
            this.m_panelControlsForGrille.Controls.Add(this.m_cmbValeurDate);
            this.m_panelControlsForGrille.Controls.Add(this.m_lblValeurDate);
            this.m_panelControlsForGrille.Controls.Add(this.m_cmbValeurTexte);
            this.m_panelControlsForGrille.Controls.Add(this.m_lblValeurTexte);
            this.m_panelControlsForGrille.Controls.Add(this.m_cmbCle);
            this.m_panelControlsForGrille.Controls.Add(this.m_lblTexteCle);
            this.m_panelControlsForGrille.Controls.Add(this.m_cmbTypeElements);
            this.m_extLinkField.SetLinkField(this.m_panelControlsForGrille, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelControlsForGrille, false);
            this.m_panelControlsForGrille.Location = new System.Drawing.Point(538, 7);
            this.m_panelControlsForGrille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelControlsForGrille, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelControlsForGrille, "");
            this.m_panelControlsForGrille.Name = "m_panelControlsForGrille";
            this.m_panelControlsForGrille.Size = new System.Drawing.Size(278, 80);
            this.m_extStyle.SetStyleBackColor(this.m_panelControlsForGrille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelControlsForGrille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelControlsForGrille.TabIndex = 3;
            this.m_panelControlsForGrille.Visible = false;
            // 
            // m_cmbValeurDecimale
            // 
            this.m_cmbValeurDecimale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbValeurDecimale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbValeurDecimale.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbValeurDecimale, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbValeurDecimale, false);
            this.m_cmbValeurDecimale.Location = new System.Drawing.Point(72, 24);
            this.m_cmbValeurDecimale.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbValeurDecimale, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbValeurDecimale, "");
            this.m_cmbValeurDecimale.Name = "m_cmbValeurDecimale";
            this.m_cmbValeurDecimale.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbValeurDecimale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbValeurDecimale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbValeurDecimale.TabIndex = 3;
            // 
            // m_lblValeurDecimale
            // 
            this.m_extLinkField.SetLinkField(this.m_lblValeurDecimale, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblValeurDecimale, false);
            this.m_lblValeurDecimale.Location = new System.Drawing.Point(24, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblValeurDecimale, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblValeurDecimale, "");
            this.m_lblValeurDecimale.Name = "m_lblValeurDecimale";
            this.m_lblValeurDecimale.Size = new System.Drawing.Size(48, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblValeurDecimale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblValeurDecimale, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblValeurDecimale.TabIndex = 2;
            this.m_lblValeurDecimale.Text = "Val 1|936";
            // 
            // m_cmbValeurDate
            // 
            this.m_cmbValeurDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbValeurDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbValeurDate.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbValeurDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbValeurDate, false);
            this.m_cmbValeurDate.Location = new System.Drawing.Point(72, 24);
            this.m_cmbValeurDate.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbValeurDate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbValeurDate, "");
            this.m_cmbValeurDate.Name = "m_cmbValeurDate";
            this.m_cmbValeurDate.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbValeurDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbValeurDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbValeurDate.TabIndex = 5;
            // 
            // m_lblValeurDate
            // 
            this.m_extLinkField.SetLinkField(this.m_lblValeurDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblValeurDate, false);
            this.m_lblValeurDate.Location = new System.Drawing.Point(24, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblValeurDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblValeurDate, "");
            this.m_lblValeurDate.Name = "m_lblValeurDate";
            this.m_lblValeurDate.Size = new System.Drawing.Size(48, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblValeurDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblValeurDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblValeurDate.TabIndex = 4;
            this.m_lblValeurDate.Text = "Val 1|936";
            // 
            // m_cmbValeurTexte
            // 
            this.m_cmbValeurTexte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbValeurTexte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbValeurTexte.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbValeurTexte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbValeurTexte, false);
            this.m_cmbValeurTexte.Location = new System.Drawing.Point(72, 24);
            this.m_cmbValeurTexte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbValeurTexte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbValeurTexte, "");
            this.m_cmbValeurTexte.Name = "m_cmbValeurTexte";
            this.m_cmbValeurTexte.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbValeurTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbValeurTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbValeurTexte.TabIndex = 7;
            // 
            // m_lblValeurTexte
            // 
            this.m_extLinkField.SetLinkField(this.m_lblValeurTexte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblValeurTexte, false);
            this.m_lblValeurTexte.Location = new System.Drawing.Point(24, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblValeurTexte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblValeurTexte, "");
            this.m_lblValeurTexte.Name = "m_lblValeurTexte";
            this.m_lblValeurTexte.Size = new System.Drawing.Size(48, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblValeurTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblValeurTexte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblValeurTexte.TabIndex = 6;
            this.m_lblValeurTexte.Text = "Val 1|936";
            // 
            // m_cmbCle
            // 
            this.m_cmbCle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbCle.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbCle, false);
            this.m_cmbCle.Location = new System.Drawing.Point(72, 0);
            this.m_cmbCle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCle, "");
            this.m_cmbCle.Name = "m_cmbCle";
            this.m_cmbCle.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCle.TabIndex = 1;
            // 
            // m_lblTexteCle
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTexteCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTexteCle, false);
            this.m_lblTexteCle.Location = new System.Drawing.Point(24, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTexteCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTexteCle, "");
            this.m_lblTexteCle.Name = "m_lblTexteCle";
            this.m_lblTexteCle.Size = new System.Drawing.Size(48, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblTexteCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTexteCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTexteCle.TabIndex = 0;
            this.m_lblTexteCle.Text = "Key 1|937";
            // 
            // m_cmbTypeElements
            // 
            this.m_cmbTypeElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeElements.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeElements, false);
            this.m_cmbTypeElements.Location = new System.Drawing.Point(72, 48);
            this.m_cmbTypeElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElements, "");
            this.m_cmbTypeElements.Name = "m_cmbTypeElements";
            this.m_cmbTypeElements.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElements.TabIndex = 4047;
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(882, 379);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4046;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage4});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.m_panelEasyQuery);
            this.tabPage1.Controls.Add(this.m_panelRequete);
            this.tabPage1.Controls.Add(this.m_panelContientStructure);
            this.tabPage1.Controls.Add(this.m_panelRadios);
            this.tabPage1.Controls.Add(this.splitter1);
            this.tabPage1.Controls.Add(this.m_tabCleValeur);
            this.tabPage1.Controls.Add(this.m_panelTest);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(866, 338);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Request|941";
            // 
            // m_panelEasyQuery
            // 
            this.m_panelEasyQuery.Controls.Add(this.m_btnEditeEasyQuery);
            this.m_extLinkField.SetLinkField(this.m_panelEasyQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEasyQuery, false);
            this.m_panelEasyQuery.Location = new System.Drawing.Point(394, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEasyQuery, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEasyQuery, "");
            this.m_panelEasyQuery.Name = "m_panelEasyQuery";
            this.m_panelEasyQuery.Size = new System.Drawing.Size(158, 241);
            this.m_extStyle.SetStyleBackColor(this.m_panelEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEasyQuery.TabIndex = 4049;
            // 
            // m_btnEditeEasyQuery
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditeEasyQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditeEasyQuery, false);
            this.m_btnEditeEasyQuery.Location = new System.Drawing.Point(7, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditeEasyQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnEditeEasyQuery, "");
            this.m_btnEditeEasyQuery.Name = "m_btnEditeEasyQuery";
            this.m_btnEditeEasyQuery.Size = new System.Drawing.Size(148, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditeEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditeEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditeEasyQuery.TabIndex = 0;
            this.m_btnEditeEasyQuery.Text = "Edit query|20917";
            this.m_btnEditeEasyQuery.UseVisualStyleBackColor = true;
            this.m_btnEditeEasyQuery.Click += new System.EventHandler(this.m_btnEditeEasyQuery_Click);
            // 
            // m_panelRequete
            // 
            this.m_panelRequete.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_panelRequete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelRequete, false);
            this.m_panelRequete.Location = new System.Drawing.Point(0, 25);
            this.m_panelRequete.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRequete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelRequete, "");
            this.m_panelRequete.Name = "m_panelRequete";
            this.m_panelRequete.RequeteEditee = null;
            this.m_panelRequete.Size = new System.Drawing.Size(155, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRequete.TabIndex = 4;
            // 
            // m_panelContientStructure
            // 
            this.m_panelContientStructure.Controls.Add(this.m_lnkFiltrer);
            this.m_panelContientStructure.Controls.Add(this.m_panelStructure);
            this.m_extLinkField.SetLinkField(this.m_panelContientStructure, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelContientStructure, false);
            this.m_panelContientStructure.Location = new System.Drawing.Point(151, 32);
            this.m_panelContientStructure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContientStructure, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelContientStructure, "");
            this.m_panelContientStructure.Name = "m_panelContientStructure";
            this.m_panelContientStructure.Size = new System.Drawing.Size(237, 258);
            this.m_extStyle.SetStyleBackColor(this.m_panelContientStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelContientStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelContientStructure.TabIndex = 9;
            // 
            // m_lnkFiltrer
            // 
            this.m_lnkFiltrer.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkFiltrer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkFiltrer, false);
            this.m_lnkFiltrer.Location = new System.Drawing.Point(410, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFiltrer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkFiltrer, "");
            this.m_lnkFiltrer.Name = "m_lnkFiltrer";
            this.m_lnkFiltrer.Size = new System.Drawing.Size(136, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFiltrer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFiltrer.TabIndex = 1;
            this.m_lnkFiltrer.TabStop = true;
            this.m_lnkFiltrer.Text = "Filter the main Table|942";
            this.m_lnkFiltrer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFiltrer_LinkClicked);
            // 
            // m_panelStructure
            // 
            this.m_panelStructure.ComboTypeLockEdition = false;
            this.m_panelStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelStructure.ElementAVariablesPourFiltre = null;
            this.m_extLinkField.SetLinkField(this.m_panelStructure, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelStructure, false);
            this.m_panelStructure.Location = new System.Drawing.Point(0, 0);
            this.m_panelStructure.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStructure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelStructure, "");
            this.m_panelStructure.Name = "m_panelStructure";
            this.m_panelStructure.Size = new System.Drawing.Size(237, 258);
            this.m_panelStructure.StructureExport = ((sc2i.data.dynamic.C2iStructureExport)(resources.GetObject("m_panelStructure.StructureExport")));
            this.m_extStyle.SetStyleBackColor(this.m_panelStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStructure.TabIndex = 0;
            // 
            // m_panelRadios
            // 
            this.m_panelRadios.Controls.Add(this.m_radioNoStructure);
            this.m_panelRadios.Controls.Add(this.m_radioEasyQuery);
            this.m_panelRadios.Controls.Add(this.m_radioRequete);
            this.m_panelRadios.Controls.Add(this.m_radioStructure);
            this.m_panelRadios.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelRadios, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelRadios, false);
            this.m_panelRadios.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRadios, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelRadios, "");
            this.m_panelRadios.Name = "m_panelRadios";
            this.m_panelRadios.Size = new System.Drawing.Size(562, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelRadios, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRadios, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRadios.TabIndex = 4047;
            // 
            // m_radioNoStructure
            // 
            this.m_radioNoStructure.AutoSize = true;
            this.m_radioNoStructure.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_radioNoStructure, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radioNoStructure, false);
            this.m_radioNoStructure.Location = new System.Drawing.Point(296, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioNoStructure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radioNoStructure, "");
            this.m_radioNoStructure.Name = "m_radioNoStructure";
            this.m_radioNoStructure.Size = new System.Drawing.Size(87, 21);
            this.m_extStyle.SetStyleBackColor(this.m_radioNoStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioNoStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioNoStructure.TabIndex = 9;
            this.m_radioNoStructure.TabStop = true;
            this.m_radioNoStructure.Text = "None|20858";
            this.m_radioNoStructure.UseVisualStyleBackColor = true;
            this.m_radioNoStructure.CheckedChanged += new System.EventHandler(this.m_radioNoStructure_CheckedChanged);
            // 
            // m_radioEasyQuery
            // 
            this.m_radioEasyQuery.AutoSize = true;
            this.m_radioEasyQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_radioEasyQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radioEasyQuery, false);
            this.m_radioEasyQuery.Location = new System.Drawing.Point(182, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioEasyQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radioEasyQuery, "");
            this.m_radioEasyQuery.Name = "m_radioEasyQuery";
            this.m_radioEasyQuery.Size = new System.Drawing.Size(114, 21);
            this.m_extStyle.SetStyleBackColor(this.m_radioEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioEasyQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioEasyQuery.TabIndex = 10;
            this.m_radioEasyQuery.TabStop = true;
            this.m_radioEasyQuery.Text = "Easy query|20916";
            this.m_radioEasyQuery.UseVisualStyleBackColor = true;
            this.m_radioEasyQuery.CheckedChanged += new System.EventHandler(this.m_radioEasyQuery_CheckedChanged);
            // 
            // m_radioRequete
            // 
            this.m_radioRequete.AutoSize = true;
            this.m_radioRequete.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_radioRequete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radioRequete, false);
            this.m_radioRequete.Location = new System.Drawing.Point(94, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioRequete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radioRequete, "");
            this.m_radioRequete.Name = "m_radioRequete";
            this.m_radioRequete.Size = new System.Drawing.Size(88, 21);
            this.m_extStyle.SetStyleBackColor(this.m_radioRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioRequete.TabIndex = 8;
            this.m_radioRequete.TabStop = true;
            this.m_radioRequete.Text = "Request|941";
            this.m_radioRequete.UseVisualStyleBackColor = true;
            this.m_radioRequete.CheckedChanged += new System.EventHandler(this.m_radioRequete_CheckedChanged);
            // 
            // m_radioStructure
            // 
            this.m_radioStructure.AutoSize = true;
            this.m_radioStructure.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_radioStructure, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radioStructure, false);
            this.m_radioStructure.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radioStructure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radioStructure, "");
            this.m_radioStructure.Name = "m_radioStructure";
            this.m_radioStructure.Size = new System.Drawing.Size(94, 21);
            this.m_extStyle.SetStyleBackColor(this.m_radioStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radioStructure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioStructure.TabIndex = 7;
            this.m_radioStructure.TabStop = true;
            this.m_radioStructure.Text = "Structure|943";
            this.m_radioStructure.UseVisualStyleBackColor = true;
            this.m_radioStructure.CheckedChanged += new System.EventHandler(this.m_radioStructure_CheckedChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(562, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 316);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // m_tabCleValeur
            // 
            this.m_tabCleValeur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabCleValeur.BoldSelectedPage = true;
            this.m_tabCleValeur.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_tabCleValeur.ForeColor = System.Drawing.Color.Black;
            this.m_tabCleValeur.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabCleValeur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabCleValeur, false);
            this.m_tabCleValeur.Location = new System.Drawing.Point(565, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabCleValeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabCleValeur, "");
            this.m_tabCleValeur.Name = "m_tabCleValeur";
            this.m_tabCleValeur.Ombre = false;
            this.m_tabCleValeur.PositionTop = true;
            this.m_tabCleValeur.SelectedIndex = 0;
            this.m_tabCleValeur.SelectedTab = this.tabPage2;
            this.m_tabCleValeur.Size = new System.Drawing.Size(301, 316);
            this.m_extStyle.SetStyleBackColor(this.m_tabCleValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabCleValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabCleValeur.TabIndex = 2;
            this.m_tabCleValeur.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage2,
            this.tabPage3,
            this.tabPage5,
            this.tabPage6});
            this.m_tabCleValeur.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_gridCles);
            this.tabPage2.Controls.Add(this.m_chkPasDeSuppression);
            this.tabPage2.Controls.Add(this.m_chkToutSupprimer);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage2, false);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 10;
            this.tabPage2.Title = "Keys|944";
            // 
            // m_gridCles
            // 
            this.m_gridCles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridCles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridCles.CaptionVisible = false;
            this.m_gridCles.CurrentElement = null;
            this.m_gridCles.DataMember = "";
            this.m_gridCles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gridCles.HeaderBackColor = System.Drawing.Color.Green;
            this.m_gridCles.HeaderForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_gridCles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridCles, false);
            this.m_gridCles.Location = new System.Drawing.Point(0, 49);
            this.m_gridCles.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridCles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gridCles, "");
            this.m_gridCles.Name = "m_gridCles";
            this.m_gridCles.PreferredRowHeight = 24;
            this.m_gridCles.Size = new System.Drawing.Size(301, 242);
            this.m_extStyle.SetStyleBackColor(this.m_gridCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gridCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gridCles.TabIndex = 0;
            // 
            // m_chkPasDeSuppression
            // 
            this.m_chkPasDeSuppression.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_chkPasDeSuppression, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkPasDeSuppression, false);
            this.m_chkPasDeSuppression.Location = new System.Drawing.Point(0, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPasDeSuppression, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkPasDeSuppression, "");
            this.m_chkPasDeSuppression.Name = "m_chkPasDeSuppression";
            this.m_chkPasDeSuppression.Size = new System.Drawing.Size(301, 25);
            this.m_extStyle.SetStyleBackColor(this.m_chkPasDeSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPasDeSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPasDeSuppression.TabIndex = 13;
            this.m_chkPasDeSuppression.Text = "Do not remove stored data missing in new result|945";
            // 
            // m_chkToutSupprimer
            // 
            this.m_chkToutSupprimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_chkToutSupprimer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkToutSupprimer, false);
            this.m_chkToutSupprimer.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkToutSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkToutSupprimer, "");
            this.m_chkToutSupprimer.Name = "m_chkToutSupprimer";
            this.m_chkToutSupprimer.Size = new System.Drawing.Size(301, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkToutSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkToutSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkToutSupprimer.TabIndex = 12;
            this.m_chkToutSupprimer.Text = "Remove all before each calculation|946";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_gridValeursDecimales);
            this.m_extLinkField.SetLinkField(this.tabPage3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage3, false);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage3, "");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 11;
            this.tabPage3.Title = "Decimal Values|10338";
            // 
            // m_gridValeursDecimales
            // 
            this.m_gridValeursDecimales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursDecimales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursDecimales.CaptionVisible = false;
            this.m_gridValeursDecimales.CurrentElement = null;
            this.m_gridValeursDecimales.DataMember = "";
            this.m_gridValeursDecimales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gridValeursDecimales.ForeColor = System.Drawing.Color.Black;
            this.m_gridValeursDecimales.HeaderBackColor = System.Drawing.Color.Green;
            this.m_gridValeursDecimales.HeaderForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_gridValeursDecimales, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridValeursDecimales, false);
            this.m_gridValeursDecimales.Location = new System.Drawing.Point(0, 0);
            this.m_gridValeursDecimales.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridValeursDecimales, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gridValeursDecimales, "");
            this.m_gridValeursDecimales.Name = "m_gridValeursDecimales";
            this.m_gridValeursDecimales.PreferredRowHeight = 24;
            this.m_gridValeursDecimales.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.m_gridValeursDecimales, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_gridValeursDecimales, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_gridValeursDecimales.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.m_gridValeursDates);
            this.m_extLinkField.SetLinkField(this.tabPage5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage5, false);
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage5, "");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage5.TabIndex = 12;
            this.tabPage5.Title = "Date Values|10336";
            // 
            // m_gridValeursDates
            // 
            this.m_gridValeursDates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursDates.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursDates.CaptionVisible = false;
            this.m_gridValeursDates.CurrentElement = null;
            this.m_gridValeursDates.DataMember = "";
            this.m_gridValeursDates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gridValeursDates.ForeColor = System.Drawing.Color.Black;
            this.m_gridValeursDates.HeaderBackColor = System.Drawing.Color.Green;
            this.m_gridValeursDates.HeaderForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_gridValeursDates, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridValeursDates, false);
            this.m_gridValeursDates.Location = new System.Drawing.Point(0, 0);
            this.m_gridValeursDates.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridValeursDates, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gridValeursDates, "");
            this.m_gridValeursDates.Name = "m_gridValeursDates";
            this.m_gridValeursDates.PreferredRowHeight = 24;
            this.m_gridValeursDates.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.m_gridValeursDates, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_gridValeursDates, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_gridValeursDates.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.m_gridValeursTextes);
            this.m_extLinkField.SetLinkField(this.tabPage6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage6, false);
            this.tabPage6.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage6, "");
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Selected = false;
            this.tabPage6.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage6.TabIndex = 13;
            this.tabPage6.Title = "Text Values|10337";
            // 
            // m_gridValeursTextes
            // 
            this.m_gridValeursTextes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursTextes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_gridValeursTextes.CaptionVisible = false;
            this.m_gridValeursTextes.CurrentElement = null;
            this.m_gridValeursTextes.DataMember = "";
            this.m_gridValeursTextes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_gridValeursTextes.ForeColor = System.Drawing.Color.Black;
            this.m_gridValeursTextes.HeaderBackColor = System.Drawing.Color.Green;
            this.m_gridValeursTextes.HeaderForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_gridValeursTextes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gridValeursTextes, false);
            this.m_gridValeursTextes.Location = new System.Drawing.Point(0, 0);
            this.m_gridValeursTextes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gridValeursTextes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gridValeursTextes, "");
            this.m_gridValeursTextes.Name = "m_gridValeursTextes";
            this.m_gridValeursTextes.PreferredRowHeight = 24;
            this.m_gridValeursTextes.Size = new System.Drawing.Size(301, 291);
            this.m_extStyle.SetStyleBackColor(this.m_gridValeursTextes, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_gridValeursTextes, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_gridValeursTextes.TabIndex = 1;
            // 
            // m_panelTest
            // 
            this.m_panelTest.Controls.Add(this.m_btnVoirResultat);
            this.m_panelTest.Controls.Add(this.m_btnTesterRequete);
            this.m_panelTest.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.m_panelTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTest, false);
            this.m_panelTest.Location = new System.Drawing.Point(0, 316);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTest, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTest, "");
            this.m_panelTest.Name = "m_panelTest";
            this.m_panelTest.Size = new System.Drawing.Size(866, 22);
            this.m_extStyle.SetStyleBackColor(this.m_panelTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTest.TabIndex = 4048;
            // 
            // m_btnVoirResultat
            // 
            this.m_btnVoirResultat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_btnVoirResultat, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnVoirResultat, false);
            this.m_btnVoirResultat.Location = new System.Drawing.Point(89, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnVoirResultat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnVoirResultat, "");
            this.m_btnVoirResultat.Name = "m_btnVoirResultat";
            this.m_btnVoirResultat.Size = new System.Drawing.Size(168, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnVoirResultat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnVoirResultat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnVoirResultat.TabIndex = 6;
            this.m_btnVoirResultat.Text = "Show result|948";
            this.m_btnVoirResultat.Click += new System.EventHandler(this.m_btnVoirResultat_Click);
            // 
            // m_btnTesterRequete
            // 
            this.m_btnTesterRequete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_btnTesterRequete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnTesterRequete, false);
            this.m_btnTesterRequete.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnTesterRequete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnTesterRequete, "");
            this.m_btnTesterRequete.Name = "m_btnTesterRequete";
            this.m_btnTesterRequete.Size = new System.Drawing.Size(75, 22);
            this.m_extStyle.SetStyleBackColor(this.m_btnTesterRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnTesterRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnTesterRequete.TabIndex = 1;
            this.m_btnTesterRequete.Text = "Execute|15";
            this.m_btnTesterRequete.Click += new System.EventHandler(this.m_btnTesterRequete_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.m_panelTachesPlanifiees);
            this.tabPage4.Controls.Add(this.m_lnkRecalculer);
            this.m_extLinkField.SetLinkField(this.tabPage4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage4, false);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage4, "");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(866, 338);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 11;
            this.tabPage4.Title = "Planning|563";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(495, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4020;
            this.label3.Text = "This Data will be recalculated at the execution of the following Planified Tasks|" +
    "938";
            // 
            // m_panelTachesPlanifiees
            // 
            this.m_panelTachesPlanifiees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelTachesPlanifiees.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelTachesPlanifiees.EnableCustomisation = true;
            this.m_panelTachesPlanifiees.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTachesPlanifiees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTachesPlanifiees, false);
            this.m_panelTachesPlanifiees.Location = new System.Drawing.Point(8, 40);
            this.m_panelTachesPlanifiees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTachesPlanifiees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelTachesPlanifiees, "");
            this.m_panelTachesPlanifiees.Name = "m_panelTachesPlanifiees";
            this.m_panelTachesPlanifiees.Size = new System.Drawing.Size(528, 295);
            this.m_extStyle.SetStyleBackColor(this.m_panelTachesPlanifiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTachesPlanifiees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTachesPlanifiees.TabIndex = 4019;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Task|939";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 490;
            // 
            // m_lnkRecalculer
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkRecalculer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRecalculer, false);
            this.m_lnkRecalculer.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRecalculer, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRecalculer, "");
            this.m_lnkRecalculer.Name = "m_lnkRecalculer";
            this.m_lnkRecalculer.Size = new System.Drawing.Size(128, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRecalculer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRecalculer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRecalculer.TabIndex = 0;
            this.m_lnkRecalculer.TabStop = true;
            this.m_lnkRecalculer.Text = "Recalculate now|940";
            this.m_lnkRecalculer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRecalculer_LinkClicked);
            // 
            // CFormEditionTypeDonneeCumulee
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(894, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeDonneeCumulee";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionTypeDonneeCumulee_Load);
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
            this.m_panelControlsForGrille.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.m_panelEasyQuery.ResumeLayout(false);
            this.m_panelContientStructure.ResumeLayout(false);
            this.m_panelContientStructure.PerformLayout();
            this.m_panelRadios.ResumeLayout(false);
            this.m_panelRadios.PerformLayout();
            this.m_tabCleValeur.ResumeLayout(false);
            this.m_tabCleValeur.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridCles)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursDecimales)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursDates)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_gridValeursTextes)).EndInit();
            this.m_panelTest.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeDonneeCumulee()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeDonneeCumulee(CTypeDonneeCumulee typeDonnee)
			: base(typeDonnee)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeDonneeCumulee(CTypeDonneeCumulee typeDonnee, CListeObjetsDonnees liste)
			: base(typeDonnee, liste)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CTypeDonneeCumulee TypeDonneeCumulee
		{
			get
			{
				return (CTypeDonneeCumulee)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			InitGridCles();
			InitGridValeursDecimales();
            InitGridValeursDates();
            InitGridValeursTextes();

			C2iRequete requete = new C2iRequete();
			CStructureExportAvecFiltre structure = new CStructureExportAvecFiltre();
            m_defEasyQuery = new CDefinitionJeuDonneesEasyQuery();
			IDefinitionJeuDonnees def = TypeDonneeCumulee.Parametre.DefinitionDeDonnees;
			if (def is C2iRequete)
			{
				requete = (C2iRequete)def;
			}
			if (def is CStructureExportAvecFiltre)
			{
				structure = (CStructureExportAvecFiltre)def;
			}
            if (def is CDefinitionJeuDonneesEasyQuery)
            {
                m_defEasyQuery = (CDefinitionJeuDonneesEasyQuery)def;
            }

			m_panelRequete.Init(requete);
			m_panelRequete.InitChamps();
			m_radioStructure.Checked = def is CStructureExportAvecFiltre;
			m_radioRequete.Checked = def is C2iRequete;
            m_radioEasyQuery.Checked = def is CDefinitionJeuDonneesEasyQuery;
            m_radioNoStructure.Checked = def == null;
			m_panelStructure.StructureExport = structure.Structure;
			m_filtreStructure = structure.Filtre;
			m_tableTest = null;
			m_cmbCle.Items.Clear();
            m_cmbValeurDecimale.Items.Clear();
            m_cmbValeurDate.Items.Clear();
            m_cmbValeurTexte.Items.Clear();
			m_chkToutSupprimer.Checked = TypeDonneeCumulee.Parametre.ViderAvantChaqueCalcul;
			m_chkPasDeSuppression.Checked = TypeDonneeCumulee.Parametre.PasDeSuppression;
			CListeObjetsDonnees liste = TypeDonneeCumulee.GetDependancesListe(
				CRelationTachePlanifieeTypeDonneeCumulee.c_nomTable,
				CTypeDonneeCumulee.c_champId);
			m_panelTachesPlanifiees.Init(
				new CListeObjetsDonnees(TypeDonneeCumulee.ContexteDonnee, typeof(CTachePlanifiee)),
				liste,
				TypeDonneeCumulee,
				"TypeDonneeCumulee",
				"TachePlanifiee");
			m_panelTachesPlanifiees.RemplirGrille();

			return result;
		}

		//-------------------------------------------------------------------------
		#region Classe mapChamp
		private abstract class CMapChamp
		{
			private string m_strChamp;
			private int m_nNumero;
			public CMapChamp ( int nNumero, string strChamp )
			{
				m_strChamp = strChamp;
				m_nNumero = nNumero;
			}
			public abstract string GetBaseLibelle();

			public string Libelle
			{
				get
				{
					return GetBaseLibelle()+" "+(m_nNumero).ToString();
				}
			}

			public int Numero
			{
				get
				{
					return m_nNumero;
				}
			}

			public string Champ
			{
				get
				{
					return m_strChamp;
				}
				set
				{
					m_strChamp = value;
				}
			}
		}

		private class CMapChampCle : CMapChamp
		{
			private Type m_typeLie = null;
			public CMapChampCle ( int nNumero, string strChamp, Type typeLie )
				:base ( nNumero, strChamp )
			{
				m_typeLie = typeLie;
			}

			public override string GetBaseLibelle()
			{
				return "Clé";
			}

			public Type TypeLie
			{
				get
				{
					return m_typeLie;
				}
				set
				{
					m_typeLie = value;
				}
			}

			/// /////////////////////////////////////////
			/// <summary>
			/// Retourne le type lié ou typeof(DBNull) si le type lié
			/// est null
			/// </summary>
			public Type TypeLieOuDbNull
			{
				get
				{
					if ( m_typeLie == null )
						return typeof(DBNull);
					return m_typeLie;
				}
				set
				{
					if ( value == typeof(DBNull) )
						TypeLie = null;
					else
						TypeLie = value;
				}
			}

		}

		private class CMapChampValeur : CMapChamp
		{
			public CMapChampValeur ( int nNumero, string strChamp )
				:base ( nNumero, strChamp )
			{
			}

			public override string GetBaseLibelle()
			{
				return "Val.";
			}
		}
		#endregion
		private void InitGridCles()
		{
			CResultAErreur result = CResultAErreur.True;
			ArrayList lstCles = new ArrayList();
			CParametreDonneeCumulee parametre = TypeDonneeCumulee.Parametre;
			for ( int n=0; n < CParametreDonneeCumulee.c_nbChampsCle; n++ )
				lstCles.Add ( new CMapChampCle ( n, parametre.GetChampCle(n).Champ, parametre.GetChampCle(n).TypeLie ) );

			m_gridCles.DataSource = lstCles;

			DataGridTableStyle tableStyle = m_gridCles.TableStyle;

			tableStyle.GridColumnStyles.Clear();

			tableStyle.RowHeadersVisible = false;
			tableStyle.HeaderBackColor = Color.FromArgb(62,147,0);
			tableStyle.HeaderForeColor = Color.White;
			
			C2iDataGridColumnStyleAControle col = new C2iDataGridColumnStyleAControle( m_lblTexteCle, "Text" );
			col.MappingName = "Libelle";
			col.HeaderText = "N°";
			tableStyle.GridColumnStyles.Add(col);
			
			
			col = new C2iDataGridColumnStyleAControle( m_cmbCle, "Text" );
			col.MappingName = "Champ";
			col.HeaderText = "Champ";
			tableStyle.GridColumnStyles.Add(col);

			col = new C2iDataGridColumnStyleAControle( m_cmbTypeElements, "SelectedValue" );
			col.MappingName = "TypeLieOuDbNull";
			col.HeaderText = "Lien";
			col.GetStringElement += new GetStringElementDelegate(GetStringType);
			tableStyle.GridColumnStyles.Add(col);

			m_gridCles.CaptionText = I.T( "Keys|944");
		}

		private string GetStringType ( object source, object obj )
		{
			if ( !(obj is Type ) )
				return null;
			if ( obj == typeof(DBNull))
				return "<AUCUN>";
			return DynamicClassAttribute.GetNomConvivial ((Type)obj );
		}

        private void InitGridValeursDecimales()
        {
            CResultAErreur result = CResultAErreur.True;
            ArrayList lstValeurs = new ArrayList();
            CParametreDonneeCumulee parametre = TypeDonneeCumulee.Parametre;
            for (int n = 0; n < CParametreDonneeCumulee.c_nbChampsValeur; n++)
                lstValeurs.Add(new CMapChampValeur(n, parametre.GetValueField(n)));

            m_gridValeursDecimales.DataSource = lstValeurs;

            DataGridTableStyle tableStyle = m_gridValeursDecimales.TableStyle;

            tableStyle.GridColumnStyles.Clear();

            tableStyle.RowHeadersVisible = false;
            tableStyle.HeaderBackColor = Color.FromArgb(62, 147, 0);
            tableStyle.HeaderForeColor = Color.White;

            C2iDataGridColumnStyleAControle col = new C2iDataGridColumnStyleAControle(m_lblValeurDecimale, "Text");
            col.MappingName = "Libelle";
            col.HeaderText = "N°";
            tableStyle.GridColumnStyles.Add(col);

            col = new C2iDataGridColumnStyleAControle(m_cmbValeurDecimale, "Text");
            col.MappingName = "Champ";
            col.HeaderText = "Champ";
            tableStyle.GridColumnStyles.Add(col);

            m_gridValeursDecimales.CaptionText = I.T("Decimal Values|10338");
        }

        private void InitGridValeursDates()
        {
            CResultAErreur result = CResultAErreur.True;
            ArrayList lstValeurs = new ArrayList();
            CParametreDonneeCumulee parametre = TypeDonneeCumulee.Parametre;
            for (int n = 0; n < CParametreDonneeCumulee.c_nbChampsDate; n++)
                lstValeurs.Add(new CMapChampValeur(n, parametre.GetDateField(n)));

            m_gridValeursDates.DataSource = lstValeurs;

            DataGridTableStyle tableStyle = m_gridValeursDates.TableStyle;

            tableStyle.GridColumnStyles.Clear();

            tableStyle.RowHeadersVisible = false;
            tableStyle.HeaderBackColor = Color.FromArgb(62, 147, 0);
            tableStyle.HeaderForeColor = Color.White;

            C2iDataGridColumnStyleAControle col = new C2iDataGridColumnStyleAControle(m_lblValeurDate, "Text");
            col.MappingName = "Libelle";
            col.HeaderText = "N°";
            tableStyle.GridColumnStyles.Add(col);

            col = new C2iDataGridColumnStyleAControle(m_cmbValeurDate, "Text");
            col.MappingName = "Champ";
            col.HeaderText = "Champ";
            tableStyle.GridColumnStyles.Add(col);

            m_gridValeursDates.CaptionText = I.T("Date Values|10336");
        }

        private void InitGridValeursTextes()
        {
            CResultAErreur result = CResultAErreur.True;
            ArrayList lstValeurs = new ArrayList();
            CParametreDonneeCumulee parametre = TypeDonneeCumulee.Parametre;
            for (int n = 0; n < CParametreDonneeCumulee.c_nbChampsTexte; n++)
                lstValeurs.Add(new CMapChampValeur(n, parametre.GetTextField(n)));

            m_gridValeursTextes.DataSource = lstValeurs;

            DataGridTableStyle tableStyle = m_gridValeursTextes.TableStyle;

            tableStyle.GridColumnStyles.Clear();

            tableStyle.RowHeadersVisible = false;
            tableStyle.HeaderBackColor = Color.FromArgb(62, 147, 0);
            tableStyle.HeaderForeColor = Color.White;

            C2iDataGridColumnStyleAControle col = new C2iDataGridColumnStyleAControle(m_lblValeurTexte, "Text");
            col.MappingName = "Libelle";
            col.HeaderText = "N°";
            tableStyle.GridColumnStyles.Add(col);

            col = new C2iDataGridColumnStyleAControle(m_cmbValeurTexte, "Text");
            col.MappingName = "Champ";
            col.HeaderText = "Champ";
            tableStyle.GridColumnStyles.Add(col);

            m_gridValeursTextes.CaptionText = I.T("Text Values|10337");
        }

		private CFiltreDynamique FiltreStructure
		{
			get
			{
				if (m_filtreStructure == null || m_filtreStructure.TypeElements != m_panelStructure.StructureExport.TypeSource)
				{
					m_filtreStructure = new CFiltreDynamique(TypeDonneeCumulee.ContexteDonnee);
					m_filtreStructure.TypeElements = m_panelStructure.StructureExport.TypeSource;
				}
				m_filtreStructure.ContexteDonnee = TypeDonneeCumulee.ContexteDonnee;
				return m_filtreStructure;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( result )
			{
				CParametreDonneeCumulee parametre = TypeDonneeCumulee.Parametre;
                if (m_radioRequete.Checked)
                    parametre.DefinitionDeDonnees = m_panelRequete.RequeteEditee;
                else if (m_radioStructure.Checked)
                {
                    CStructureExportAvecFiltre structure = new CStructureExportAvecFiltre();
                    structure.Structure = m_panelStructure.StructureExport;
                    structure.Filtre = FiltreStructure;
                    parametre.DefinitionDeDonnees = structure;
                }
                else if ( m_radioEasyQuery.Checked )
                {
                    parametre.DefinitionDeDonnees = m_defEasyQuery;
                }
                else
                    parametre.DefinitionDeDonnees = null;
				if ( m_gridCles.DataSource is ArrayList )
				{
					foreach(  CMapChampCle map in (ArrayList)m_gridCles.DataSource )
						parametre.SetChampCle ( map.Numero, new CCleDonneeCumulee(map.Champ, map.TypeLie) );
				}
                if (m_gridValeursDecimales.DataSource is ArrayList)
                {
                    foreach (CMapChamp map in (ArrayList)m_gridValeursDecimales.DataSource)
                        parametre.SetChampValeurDecimale(map.Numero, map.Champ);
                }
                if (m_gridValeursDates.DataSource is ArrayList)
                {
                    foreach (CMapChamp map in (ArrayList)m_gridValeursDates.DataSource)
                        parametre.SetChampValeurDate(map.Numero, map.Champ);
                }
                if (m_gridValeursTextes.DataSource is ArrayList)
                {
                    foreach (CMapChamp map in (ArrayList)m_gridValeursTextes.DataSource)
                        parametre.SetChampValeurText(map.Numero, map.Champ);
                }

				parametre.ViderAvantChaqueCalcul = m_chkToutSupprimer.Checked;
				parametre.PasDeSuppression = m_chkPasDeSuppression.Checked;
				TypeDonneeCumulee.Parametre = parametre;
				m_panelTachesPlanifiees.ApplyModifs();
				
			}
			return result;
		}

		//-------------------------------------------------------------------------
		private bool FillRequete(C2iRequete requete)
		{
			if (requete.FormulaireEdition != null &&
				requete.FormulaireEdition.Childs.Length > 0)
			{
				if (!CFormFormulairePopup.EditeElement(requete.FormulaireEdition, requete, "Données"))
					return false;
			}
			return true;
		}

		//-------------------------------------------------------------------------
		private bool FillStructure(CStructureExportAvecFiltre structure)
		{
			if (structure.Filtre != null && structure.Filtre.FormulaireEdition != null &&
				structure.Filtre.FormulaireEdition.Childs.Length > 0)
			{
				if (!CFormFormulairePopup.EditeElement(structure.Filtre.FormulaireEdition, structure.Filtre, "Données"))
					return false;
			}
			return true;
		}

		//-------------------------------------------------------------------------
		private bool CreateJeuRequete()
		{
			IDefinitionJeuDonnees def = null;
			IElementAVariablesDynamiquesAvecContexteDonnee eltAVariables = null;
			if (m_radioRequete.Checked)
			{
				C2iRequete requete = m_panelRequete.RequeteEditee;
				if (!FillRequete(requete))
					return false;
				def = requete;
				eltAVariables = requete;
			}
			if (m_radioStructure.Checked)
			{
				CStructureExportAvecFiltre structure = new CStructureExportAvecFiltre();
				structure.Structure = m_panelStructure.StructureExport;
				if (structure.Structure.TypeSource == null)
				{
                    CFormAlerte.Afficher(I.T( "Select a Source Type|949"), EFormAlerteType.Exclamation);
					return false;
				}
				
				structure.Filtre = FiltreStructure;
				if (!FillStructure(structure))
					return false;
				def = structure;
				eltAVariables = FiltreStructure;
			}
            if ( m_radioEasyQuery.Checked )
            {
                CDefinitionJeuDonneesEasyQuery defQuery = m_defEasyQuery;
                if (defQuery == null)
                    defQuery = new CDefinitionJeuDonneesEasyQuery();
                eltAVariables = null;
                def = defQuery;
            }
			CResultAErreur result = CResultAErreur.True;
            if (def != null)
            {
                result = CParametreDonneeCumulee.GetTableSource(eltAVariables, def, null);
            }
            else
                result.Data = new DataTable();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return false;
			}
			DataTable table = (DataTable)result.Data;
			m_cmbValeurDecimale.Items.Clear();
			m_cmbCle.Items.Clear();
            m_cmbCle.Items.Add("");
            if (table != null)
            {
                foreach (DataColumn col in table.Columns)
                {
                    m_cmbCle.Items.Add(col.ColumnName);
                    if (typeof(Double).IsAssignableFrom(col.DataType) || typeof(int).IsAssignableFrom(col.DataType) || typeof(Decimal).IsAssignableFrom(col.DataType))
                        m_cmbValeurDecimale.Items.Add(col.ColumnName);
                    else if (typeof(DateTime).IsAssignableFrom(col.DataType) || typeof(DateTime?).IsAssignableFrom(col.DataType))
                        m_cmbValeurDate.Items.Add(col.ColumnName);
                    else if (typeof(string).IsAssignableFrom(col.DataType))
                        m_cmbValeurTexte.Items.Add(col.ColumnName);
                }
            }
			m_tableTest = table;
			return true;
		}

		private void CFormEditionTypeDonneeCumulee_Load(object sender, System.EventArgs e)
		{
			InitComboTypes(true);
		}

		private void m_btnTesterRequete_Click(object sender, System.EventArgs e)
		{
			CreateJeuRequete();
		}

		private void m_btnVoirResultat_Click(object sender, System.EventArgs e)
		{
			if ( m_tableTest == null )
				CreateJeuRequete();
			if ( m_tableTest != null )
				CFormViewDataTable.ShowTable ( m_tableTest );
		}

		private void StartRecalcul()
		{
			CResultAErreur result = TypeDonneeCumulee.StockResultat ( CFormProgressTimos.Indicateur );
			if ( !result )
			{
				result.EmpileErreur(I.T( "Error while computing Cumulated Data|950"));
				CFormAlerte.Afficher ( result.Erreur );
			}	
		}

		private void m_lnkRecalculer_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CFormProgressTimos.StartThreadWithProgress(
                I.T( "Recalculate|951")+" " + TypeDonneeCumulee.Libelle,
                new System.Threading.ThreadStart(StartRecalcul),
				false);
		}

		private void m_tabControl_SelectionChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void InitComboTypes ( bool bForcerRemplissage )
		{
			if (bForcerRemplissage)
			{
				CInfoClasseDynamique[] classes = DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute));
				ArrayList lst = new ArrayList ( classes );
				lst.Insert ( 0, new CInfoClasseDynamique ( typeof(DBNull), "<AUCUN>" ) );
				m_cmbTypeElements.DataSource = null;
				m_cmbTypeElements.DataSource = lst;
				m_cmbTypeElements.ValueMember = "Classe";
				m_cmbTypeElements.DisplayMember = "Nom";
			}
		}

		private void m_radioStructure_CheckedChanged(object sender, EventArgs e)
		{
			UpdateVisuPanelDefinition();
		}

		private void UpdateVisuPanelDefinition()
		{
			m_panelContientStructure.Visible = m_radioStructure.Checked;
			m_panelRequete.Visible = m_radioRequete.Checked;
            m_panelEasyQuery.Visible = m_radioEasyQuery.Checked ;
			m_panelContientStructure.Dock = DockStyle.Fill;
			m_panelRequete.Dock = DockStyle.Fill;
            m_panelEasyQuery.Dock = DockStyle.Fill;
		}

		private void m_radioRequete_CheckedChanged(object sender, EventArgs e)
		{
			UpdateVisuPanelDefinition();
		}

		//--------------------------------------------
		private void m_lnkFiltrer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFiltreDynamique filtre = FiltreStructure;
			if (CFormEditFiltreDynamique.EditeFiltre(filtre, true, false, null))
				m_filtreStructure = filtre;

		}

        private void m_radioNoStructure_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuPanelDefinition();
        }

        private void m_btnEditeEasyQuery_Click(object sender, EventArgs e)
        {
            CMultiStructureExport multi = new CMultiStructureExport(CSc2iWin32DataClient.ContexteCourant);
            CElementMultiStructureExport eltM = new CElementMultiStructureExport();
            eltM.MultiStructure = multi;
            multi.AddDefinition(eltM);
            if (m_defEasyQuery == null)
                m_defEasyQuery = new CDefinitionJeuDonneesEasyQuery();
            eltM.DefinitionJeu = m_defEasyQuery;
            if ( CFormEditJeuDeDonneesEasyQuery.EditeElementQuery ( eltM ))
            {
                CDefinitionJeuDonneesEasyQuery def = eltM.DefinitionJeu as CDefinitionJeuDonneesEasyQuery;
                if (def != null)
                    m_defEasyQuery = def as CDefinitionJeuDonneesEasyQuery;
            }

        }

        private void m_radioEasyQuery_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuPanelDefinition();
        }
	}
}

