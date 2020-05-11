using System;
using System.Data;
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
using timos.data.projet;
using timos.data.projet.besoin;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeProjet))]
	public class CFormEditionTypeProjet : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code


		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private Label m_lblProject;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private ListViewAutoFilled m_wndListeSite;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelSite;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelEquipement;
		private C2iTabControl m_TabControl;
		private Crownwood.Magic.Controls.TabPage m_pageChampCustom;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private Crownwood.Magic.Controls.TabPage m_pageSettings;
        private CheckBox m_chkDetailHeures;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormulePoids;
        private Label label3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleProgress;
        private Label label2;
        private Label label4;
        private C2iSelectImage m_imageSelect;
        private Crownwood.Magic.Controls.TabPage m_pageEvents;
        private CPanelDefinisseurEvenements m_panelEvenements;
        private NumericUpDown m_numDureeHeureDefaut;
        private Crownwood.Magic.Controls.TabPage m_tabPageFormulaire;
        private CPanelChampsCustom m_panelChamps;
        private Crownwood.Magic.Controls.TabPage m_pageHierarchie;
        private SplitContainer m_splitContainer;
        private Label m_labelGauche;
        private CPanelListeRelationSelection m_panelTypeContenu;
        private Label m_labelDroite;
        private CPanelListeRelationSelection m_panelTypeContenant;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private Label label6;
        private Label label7;
        private CheckBox checkBox1;
        private Label label8;
        private C2iComboBox m_cmbOptionVersion;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label9;
        private GroupBox groupBox3;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleElementAssocie;
        private C2iComboBox m_cmbParenteeVersion;
        private Crownwood.Magic.Controls.TabPage m_pageEOS;
        private CPanelAffectationEO m_panelEOS;
        private Panel m_panelSousTypesPossibles;
        private ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private Splitter splitter1;
        private CPanelListeRelationSelection m_panelSousTypes;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private Panel panel2;
        private Label label10;
        private Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleFormulaire;
        private Label label11;
        private CComboboxAutoFilled m_cmbTypeBesoinDefaut;
        private CheckBox checkBox2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeProjet));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lblProject = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn2 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_wndListeSite = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_gestionnaireEditionRelSite = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireEditionRelEquipement = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSettings = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_txtFormuleProgress = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtFormulePoids = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_cmbTypeBesoinDefaut = new sc2i.win32.common.CComboboxAutoFilled();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_numDureeHeureDefaut = new System.Windows.Forms.NumericUpDown();
            this.m_imageSelect = new sc2i.win32.common.C2iSelectImage();
            this.m_chkDetailHeures = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtFormuleFormulaire = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmbParenteeVersion = new sc2i.win32.common.C2iComboBox();
            this.m_txtFormuleElementAssocie = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cmbOptionVersion = new sc2i.win32.common.C2iComboBox();
            this.m_tabPageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageChampCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageHierarchie = new Crownwood.Magic.Controls.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_panelTypeContenu = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn3 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.label6 = new System.Windows.Forms.Label();
            this.m_labelGauche = new System.Windows.Forms.Label();
            this.m_panelTypeContenant = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.label7 = new System.Windows.Forms.Label();
            this.m_labelDroite = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_panelSousTypesPossibles = new System.Windows.Forms.Panel();
            this.m_panelSousTypes = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn5 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.m_pageEOS = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageEvents = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.listViewAutoFilledColumn4 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageSettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDureeHeureDefaut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.m_tabPageFormulaire.SuspendLayout();
            this.m_pageChampCustom.SuspendLayout();
            this.m_pageHierarchie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).BeginInit();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.m_panelSousTypesPossibles.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_pageEOS.SuspendLayout();
            this.m_pageEvents.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(515, 0);
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
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(128, 13);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(291, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lblProject);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 43);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(460, 60);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lblProject
            // 
            this.m_lblProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblProject.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblProject, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblProject, false);
            this.m_lblProject.Location = new System.Drawing.Point(4, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProject, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblProject, "");
            this.m_lblProject.Name = "m_lblProject";
            this.m_lblProject.Size = new System.Drawing.Size(120, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProject.TabIndex = 4005;
            this.m_lblProject.Text = "Project type label |1214";
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 300;
            // 
            // m_wndListeSite
            // 
            this.m_wndListeSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_wndListeSite.EnableCustomisation = true;
            this.m_wndListeSite.FullRowSelect = true;
            this.m_wndListeSite.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeSite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeSite, false);
            this.m_wndListeSite.Location = new System.Drawing.Point(13, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeSite, "");
            this.m_wndListeSite.MultiSelect = false;
            this.m_wndListeSite.Name = "m_wndListeSite";
            this.m_wndListeSite.Size = new System.Drawing.Size(772, 203);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSite.TabIndex = 4007;
            this.m_wndListeSite.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSite.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // m_gestionnaireEditionRelSite
            // 
            this.m_gestionnaireEditionRelSite.ListeAssociee = this.m_wndListeSite;
            this.m_gestionnaireEditionRelSite.ObjetEdite = null;
            // 
            // m_gestionnaireEditionRelEquipement
            // 
            this.m_gestionnaireEditionRelEquipement.ObjetEdite = null;
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
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(12, 109);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_tabPageFormulaire;
            this.m_TabControl.Size = new System.Drawing.Size(818, 409);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageFormulaire,
            this.m_pageChampCustom,
            this.m_pageHierarchie,
            this.m_pageSettings,
            this.m_pageEOS,
            this.m_pageEvents});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSettings
            // 
            this.m_pageSettings.Controls.Add(this.groupBox3);
            this.m_pageSettings.Controls.Add(this.groupBox2);
            this.m_pageSettings.Controls.Add(this.groupBox1);
            this.m_extLinkField.SetLinkField(this.m_pageSettings, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSettings, false);
            this.m_pageSettings.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSettings, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSettings, "");
            this.m_pageSettings.Name = "m_pageSettings";
            this.m_pageSettings.Selected = false;
            this.m_pageSettings.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_pageSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSettings.TabIndex = 15;
            this.m_pageSettings.Title = "Project settings|20170";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_txtFormuleProgress);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.m_txtFormulePoids);
            this.m_extLinkField.SetLinkField(this.groupBox3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox3, false);
            this.groupBox3.Location = new System.Drawing.Point(17, 207);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox3, "");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 128);
            this.m_extStyle.SetStyleBackColor(this.groupBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progress|20377";
            // 
            // m_txtFormuleProgress
            // 
            this.m_txtFormuleProgress.AllowGraphic = true;
            this.m_txtFormuleProgress.AllowNullFormula = false;
            this.m_txtFormuleProgress.AllowSaisieTexte = true;
            this.m_txtFormuleProgress.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleProgress, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleProgress, false);
            this.m_txtFormuleProgress.Location = new System.Drawing.Point(175, 17);
            this.m_txtFormuleProgress.LockEdition = false;
            this.m_txtFormuleProgress.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleProgress, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleProgress, "");
            this.m_txtFormuleProgress.Name = "m_txtFormuleProgress";
            this.m_txtFormuleProgress.Size = new System.Drawing.Size(595, 45);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleProgress, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleProgress.TabIndex = 0;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(12, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 3;
            this.label3.Text = "Weight formula|20173";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormulePoids
            // 
            this.m_txtFormulePoids.AllowGraphic = true;
            this.m_txtFormulePoids.AllowNullFormula = false;
            this.m_txtFormulePoids.AllowSaisieTexte = true;
            this.m_txtFormulePoids.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormulePoids, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormulePoids, false);
            this.m_txtFormulePoids.Location = new System.Drawing.Point(175, 68);
            this.m_txtFormulePoids.LockEdition = false;
            this.m_txtFormulePoids.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormulePoids, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormulePoids, "");
            this.m_txtFormulePoids.Name = "m_txtFormulePoids";
            this.m_txtFormulePoids.Size = new System.Drawing.Size(595, 45);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormulePoids, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormulePoids, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormulePoids.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.m_cmbTypeBesoinDefaut);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.m_numDureeHeureDefaut);
            this.groupBox2.Controls.Add(this.m_imageSelect);
            this.groupBox2.Controls.Add(this.m_chkDetailHeures);
            this.groupBox2.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox2, false);
            this.groupBox2.Location = new System.Drawing.Point(17, 133);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox2, "");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 73);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options|20376";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox2, "DefaultExpand");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox2, true);
            this.checkBox2.Location = new System.Drawing.Point(315, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(173, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 4008;
            this.checkBox2.Text = "Auto expand in gannt|20915";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // m_cmbTypeBesoinDefaut
            // 
            this.m_cmbTypeBesoinDefaut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeBesoinDefaut.FormattingEnabled = true;
            this.m_cmbTypeBesoinDefaut.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeBesoinDefaut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeBesoinDefaut, false);
            this.m_cmbTypeBesoinDefaut.ListDonnees = null;
            this.m_cmbTypeBesoinDefaut.Location = new System.Drawing.Point(629, 21);
            this.m_cmbTypeBesoinDefaut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeBesoinDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeBesoinDefaut, "");
            this.m_cmbTypeBesoinDefaut.Name = "m_cmbTypeBesoinDefaut";
            this.m_cmbTypeBesoinDefaut.NullAutorise = false;
            this.m_cmbTypeBesoinDefaut.ProprieteAffichee = "Libelle";
            this.m_cmbTypeBesoinDefaut.Size = new System.Drawing.Size(141, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeBesoinDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeBesoinDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeBesoinDefaut.TabIndex = 4007;
            this.m_cmbTypeBesoinDefaut.Text = "(empty)";
            this.m_cmbTypeBesoinDefaut.TextNull = "(empty)";
            this.m_cmbTypeBesoinDefaut.Tri = true;
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(467, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(153, 16);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4006;
            this.label11.Text = "Default need type|20801";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 20);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4005;
            this.label9.Text = "Default hours duration|10087";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_numDureeHeureDefaut
            // 
            this.m_numDureeHeureDefaut.DecimalPlaces = 2;
            this.m_extLinkField.SetLinkField(this.m_numDureeHeureDefaut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numDureeHeureDefaut, false);
            this.m_numDureeHeureDefaut.Location = new System.Drawing.Point(175, 16);
            this.m_numDureeHeureDefaut.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numDureeHeureDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numDureeHeureDefaut, "");
            this.m_numDureeHeureDefaut.Name = "m_numDureeHeureDefaut";
            this.m_numDureeHeureDefaut.Size = new System.Drawing.Size(120, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numDureeHeureDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numDureeHeureDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numDureeHeureDefaut.TabIndex = 0;
            // 
            // m_imageSelect
            // 
            this.m_imageSelect.BackColor = System.Drawing.Color.White;
            this.m_imageSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_imageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_imageSelect, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageSelect, false);
            this.m_imageSelect.Location = new System.Drawing.Point(175, 43);
            this.m_imageSelect.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageSelect, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_imageSelect, "");
            this.m_imageSelect.Name = "m_imageSelect";
            this.m_imageSelect.Size = new System.Drawing.Size(24, 23);
            this.m_imageSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageSelect.TabIndex = 12;
            this.m_imageSelect.TabStop = false;
            // 
            // m_chkDetailHeures
            // 
            this.m_chkDetailHeures.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkDetailHeures, "TravaillerAvecLesHeures");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkDetailHeures, true);
            this.m_chkDetailHeures.Location = new System.Drawing.Point(315, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDetailHeures, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkDetailHeures, "");
            this.m_chkDetailHeures.Name = "m_chkDetailHeures";
            this.m_chkDetailHeures.Size = new System.Drawing.Size(123, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkDetailHeures, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDetailHeures, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDetailHeures.TabIndex = 1;
            this.m_chkDetailHeures.Text = "Hours detail|20171";
            this.m_chkDetailHeures.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(12, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 5;
            this.label4.Text = "Project icon|20174";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtFormuleFormulaire);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.m_cmbParenteeVersion);
            this.groupBox1.Controls.Add(this.m_txtFormuleElementAssocie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.m_cmbOptionVersion);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.groupBox1.Location = new System.Drawing.Point(17, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 121);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asset links|20375";
            // 
            // m_txtFormuleFormulaire
            // 
            this.m_txtFormuleFormulaire.AllowGraphic = true;
            this.m_txtFormuleFormulaire.AllowNullFormula = true;
            this.m_txtFormuleFormulaire.AllowSaisieTexte = true;
            this.m_txtFormuleFormulaire.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleFormulaire, false);
            this.m_txtFormuleFormulaire.Location = new System.Drawing.Point(181, 85);
            this.m_txtFormuleFormulaire.LockEdition = false;
            this.m_txtFormuleFormulaire.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleFormulaire, "");
            this.m_txtFormuleFormulaire.Name = "m_txtFormuleFormulaire";
            this.m_txtFormuleFormulaire.Size = new System.Drawing.Size(595, 30);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleFormulaire.TabIndex = 4010;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(18, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 33);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4009;
            this.label5.Text = "Use specific form (form id)|20690";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbParenteeVersion
            // 
            this.m_cmbParenteeVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbParenteeVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbParenteeVersion.FormattingEnabled = true;
            this.m_cmbParenteeVersion.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbParenteeVersion, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbParenteeVersion, false);
            this.m_cmbParenteeVersion.Location = new System.Drawing.Point(489, 15);
            this.m_cmbParenteeVersion.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbParenteeVersion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbParenteeVersion, "");
            this.m_cmbParenteeVersion.Name = "m_cmbParenteeVersion";
            this.m_cmbParenteeVersion.Size = new System.Drawing.Size(250, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbParenteeVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbParenteeVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbParenteeVersion.TabIndex = 4008;
            // 
            // m_txtFormuleElementAssocie
            // 
            this.m_txtFormuleElementAssocie.AllowGraphic = true;
            this.m_txtFormuleElementAssocie.AllowNullFormula = true;
            this.m_txtFormuleElementAssocie.AllowSaisieTexte = true;
            this.m_txtFormuleElementAssocie.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleElementAssocie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleElementAssocie, false);
            this.m_txtFormuleElementAssocie.Location = new System.Drawing.Point(181, 37);
            this.m_txtFormuleElementAssocie.LockEdition = false;
            this.m_txtFormuleElementAssocie.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleElementAssocie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleElementAssocie, "");
            this.m_txtFormuleElementAssocie.Name = "m_txtFormuleElementAssocie";
            this.m_txtFormuleElementAssocie.Size = new System.Drawing.Size(595, 45);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleElementAssocie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleElementAssocie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleElementAssocie.TabIndex = 1;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(18, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 20);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 1;
            this.label2.Text = "Main associated element|20378";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(18, 17);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(160, 20);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4007;
            this.label8.Text = "Data version options|20374";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbOptionVersion
            // 
            this.m_cmbOptionVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbOptionVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbOptionVersion.FormattingEnabled = true;
            this.m_cmbOptionVersion.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbOptionVersion, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbOptionVersion, false);
            this.m_cmbOptionVersion.Location = new System.Drawing.Point(181, 15);
            this.m_cmbOptionVersion.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbOptionVersion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbOptionVersion, "");
            this.m_cmbOptionVersion.Name = "m_cmbOptionVersion";
            this.m_cmbOptionVersion.Size = new System.Drawing.Size(302, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbOptionVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbOptionVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbOptionVersion.TabIndex = 0;
            // 
            // m_tabPageFormulaire
            // 
            this.m_tabPageFormulaire.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageFormulaire, false);
            this.m_tabPageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageFormulaire, "");
            this.m_tabPageFormulaire.Name = "m_tabPageFormulaire";
            this.m_tabPageFormulaire.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageFormulaire.TabIndex = 17;
            this.m_tabPageFormulaire.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
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
            this.m_panelChamps.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 2;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageChampCustom
            // 
            this.m_pageChampCustom.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChampCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChampCustom, false);
            this.m_pageChampCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChampCustom, "");
            this.m_pageChampCustom.Name = "m_pageChampCustom";
            this.m_pageChampCustom.Selected = false;
            this.m_pageChampCustom.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampCustom.TabIndex = 14;
            this.m_pageChampCustom.Title = "Custom fields|198";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_panelEditChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 1;
            // 
            // m_pageHierarchie
            // 
            this.m_pageHierarchie.Controls.Add(this.splitter1);
            this.m_pageHierarchie.Controls.Add(this.m_splitContainer);
            this.m_pageHierarchie.Controls.Add(this.checkBox1);
            this.m_pageHierarchie.Controls.Add(this.m_panelSousTypesPossibles);
            this.m_extLinkField.SetLinkField(this.m_pageHierarchie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageHierarchie, false);
            this.m_pageHierarchie.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageHierarchie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageHierarchie, "");
            this.m_pageHierarchie.Name = "m_pageHierarchie";
            this.m_pageHierarchie.Selected = false;
            this.m_pageHierarchie.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_pageHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageHierarchie.TabIndex = 18;
            this.m_pageHierarchie.Title = "Project hierarchy|20244";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(596, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 349);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 5;
            this.splitter1.TabStop = false;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_splitContainer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer, false);
            this.m_splitContainer.Location = new System.Drawing.Point(0, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer, "");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_panelTypeContenu);
            this.m_splitContainer.Panel1.Controls.Add(this.label6);
            this.m_splitContainer.Panel1.Controls.Add(this.m_labelGauche);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_panelTypeContenant);
            this.m_splitContainer.Panel2.Controls.Add(this.label7);
            this.m_splitContainer.Panel2.Controls.Add(this.m_labelDroite);
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(599, 349);
            this.m_splitContainer.SplitterDistance = 295;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 4;
            // 
            // m_panelTypeContenu
            // 
            this.m_panelTypeContenu.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn3});
            this.m_panelTypeContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTypeContenu.EnableCustomisation = true;
            this.m_panelTypeContenu.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypeContenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypeContenu, false);
            this.m_panelTypeContenu.Location = new System.Drawing.Point(0, 36);
            this.m_panelTypeContenu.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeContenu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeContenu, "");
            this.m_panelTypeContenu.Name = "m_panelTypeContenu";
            this.m_panelTypeContenu.Size = new System.Drawing.Size(295, 313);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeContenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeContenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeContenu.TabIndex = 0;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 300;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(0, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(295, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 3;
            this.label6.Text = "Leave list empty for no restriction|20243";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_labelGauche
            // 
            this.m_labelGauche.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_labelGauche, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelGauche, false);
            this.m_labelGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelGauche, "");
            this.m_labelGauche.Name = "m_labelGauche";
            this.m_labelGauche.Size = new System.Drawing.Size(295, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelGauche.TabIndex = 2;
            this.m_labelGauche.Text = "Can include|237";
            // 
            // m_panelTypeContenant
            // 
            this.m_panelTypeContenant.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_panelTypeContenant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTypeContenant.EnableCustomisation = true;
            this.m_panelTypeContenant.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypeContenant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypeContenant, false);
            this.m_panelTypeContenant.Location = new System.Drawing.Point(0, 36);
            this.m_panelTypeContenant.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeContenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeContenant, "");
            this.m_panelTypeContenant.Name = "m_panelTypeContenant";
            this.m_panelTypeContenant.Size = new System.Drawing.Size(300, 313);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeContenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeContenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeContenant.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(0, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(300, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4;
            this.label7.Text = "Leave list empty for no restriction|20243";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_labelDroite
            // 
            this.m_labelDroite.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_labelDroite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelDroite, false);
            this.m_labelDroite.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelDroite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelDroite, "");
            this.m_labelDroite.Name = "m_labelDroite";
            this.m_labelDroite.Size = new System.Drawing.Size(300, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelDroite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelDroite.TabIndex = 2;
            this.m_labelDroite.Text = "Can be incuded|238";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.checkBox1, "NecessiteParent");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(599, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Projects of this type need parent project|20245";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_panelSousTypesPossibles
            // 
            this.m_panelSousTypesPossibles.Controls.Add(this.m_panelSousTypes);
            this.m_panelSousTypesPossibles.Controls.Add(this.panel2);
            this.m_panelSousTypesPossibles.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_panelSousTypesPossibles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSousTypesPossibles, false);
            this.m_panelSousTypesPossibles.Location = new System.Drawing.Point(599, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousTypesPossibles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSousTypesPossibles, "");
            this.m_panelSousTypesPossibles.Name = "m_panelSousTypesPossibles";
            this.m_panelSousTypesPossibles.Size = new System.Drawing.Size(203, 368);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousTypesPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousTypesPossibles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousTypesPossibles.TabIndex = 5;
            // 
            // m_panelSousTypes
            // 
            this.m_panelSousTypes.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn5});
            this.m_panelSousTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSousTypes.EnableCustomisation = true;
            this.m_panelSousTypes.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSousTypes, false);
            this.m_panelSousTypes.Location = new System.Drawing.Point(0, 47);
            this.m_panelSousTypes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousTypes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSousTypes, "");
            this.m_panelSousTypes.Name = "m_panelSousTypes";
            this.m_panelSousTypes.Size = new System.Drawing.Size(203, 321);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousTypes.TabIndex = 4;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 170;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(203, 47);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 47);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "Project of this type can have following sub types|20584";
            // 
            // m_pageEOS
            // 
            this.m_pageEOS.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.m_pageEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEOS, false);
            this.m_pageEOS.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOS, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEOS, "");
            this.m_pageEOS.Name = "m_pageEOS";
            this.m_pageEOS.Selected = false;
            this.m_pageEOS.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_pageEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEOS.TabIndex = 19;
            this.m_pageEOS.Title = "Organizational entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEOS, false);
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 1;
            // 
            // m_pageEvents
            // 
            this.m_pageEvents.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvents, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEvents, false);
            this.m_pageEvents.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvents, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvents, "");
            this.m_pageEvents.Name = "m_pageEvents";
            this.m_pageEvents.Selected = false;
            this.m_pageEvents.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvents.TabIndex = 16;
            this.m_pageEvents.Title = "Events|183";
            // 
            // m_panelEvenements
            // 
            this.m_panelEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEvenements, false);
            this.m_panelEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEvenements, "");
            this.m_panelEvenements.Name = "m_panelEvenements";
            this.m_panelEvenements.Size = new System.Drawing.Size(802, 368);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 1;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Label|50";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 300;
            // 
            // CFormEditionTypeProjet
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_TabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeProjet";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeProjet_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeProjet_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageSettings.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numDureeHeureDefaut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.m_tabPageFormulaire.ResumeLayout(false);
            this.m_pageChampCustom.ResumeLayout(false);
            this.m_pageHierarchie.ResumeLayout(false);
            this.m_pageHierarchie.PerformLayout();
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer)).EndInit();
            this.m_splitContainer.ResumeLayout(false);
            this.m_panelSousTypesPossibles.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_pageEOS.ResumeLayout(false);
            this.m_pageEvents.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeProjet()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeProjet(CTypeProjet proj)
            : base(proj)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeProjet(CTypeProjet proj, CListeObjetsDonnees liste)
            : base(proj, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}


		//-------------------------------------------------------------------------
		private CTypeProjet TypeProjet
		{
			get	{ return (CTypeProjet)ObjetEdite;	}
		}


		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			m_extLinkField.FillDialogFromObjet(TypeProjet);
			AffecterTitre(I.T("Project Type @1|1292", TypeProjet.Libelle));
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeProjet.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_TabControl.TabPages.Contains(m_tabPageFormulaire))
                    m_TabControl.TabPages.Remove(m_tabPageFormulaire);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(m_tabPageFormulaire))
                    m_TabControl.TabPages.Insert(0, m_tabPageFormulaire);
            }
            
			return result;
		}  
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
			CResultAErreur result = base.MAJ_Champs();
			result = m_extLinkField.FillObjetFromDialog(TypeProjet);
            
            return result;
		}

		private CResultAErreur CFormEditionTypeProjet_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageChampCustom)
				{
					m_panelEditChamps.InitPanel(
					 TypeProjet,
					 typeof(CFormListeChampsCustom),
					 typeof(CFormListeFormulaires));
				}
                if (page == m_pageSettings)
                {
                    m_numDureeHeureDefaut.Value = (decimal) TypeProjet.DureeDefautHeures;
                    m_imageSelect.Image = TypeProjet.Image;
                    CFournisseurPropDynStd fournisseur = new CFournisseurPropDynStd();
                    m_txtFormulePoids.Init(fournisseur, typeof(CProjet));
                    m_txtFormuleProgress.Init(fournisseur, typeof(CProjet));
                    m_txtFormuleProgress.Formule = TypeProjet.FormuleAvancement;
                    m_txtFormulePoids.Formule = TypeProjet.FormulePoids;
                    m_txtFormuleElementAssocie.Init(fournisseur, typeof(CProjet));
                    m_txtFormuleElementAssocie.Formule = TypeProjet.FormuleElementAssocie;
                    m_txtFormuleFormulaire.Init(fournisseur, typeof(CProjet));
                    m_txtFormuleFormulaire.Formule = TypeProjet.FormuleFormulaireVersion;
                    m_cmbOptionVersion.DisplayMember = "Libelle";
                    m_cmbOptionVersion.ValueMember = "Code";
                    m_cmbOptionVersion.DataSource = COptionTypeProjetVersion.GetValeursEnumPossibleInEnumALibelle(typeof(COptionTypeProjetVersion));
                    m_cmbOptionVersion.SelectedValue = TypeProjet.OptionVersion.Code;

                    DataTable table = new DataTable();
                    table.Columns.Add("VALUE", typeof(bool));
                    table.Columns.Add("DISPLAY", typeof(string));
                    DataRow row = table.NewRow();
                    row["VALUE"] = false;
                    row["DISPLAY"] = I.T("Based on parent project version|20385");
                    table.Rows.Add ( row );
                    row = table.NewRow();
                    row["VALUE"] = true;
                    row["DISPLAY"] = I.T("Independant version|20386");
                    table.Rows.Add ( row );
                    m_cmbParenteeVersion.DataSource = table;
                    m_cmbParenteeVersion.DisplayMember = "DISPLAY";
                    m_cmbParenteeVersion.ValueMember = "VALUE";
                    m_cmbParenteeVersion.SelectedValue = TypeProjet.VersionSurReferentiel;

                    m_cmbTypeBesoinDefaut.ListDonnees = CTypeDonneeBesoin.GetValeursEnumPossibleInEnumALibelle(typeof(CTypeDonneeBesoin));
                    m_cmbTypeBesoinDefaut.SelectedValue = TypeProjet.TypeBesoinParDefaut;
                }
                if ( page == m_pageEvents )
                    m_panelEvenements.InitChamps(TypeProjet);
                if (page == m_tabPageFormulaire)
                    m_panelChamps.ElementEdite = TypeProjet;
                if (page == m_pageHierarchie)
                {
                    // Filtre la liste des Types possibles pour ne pas afficher le Type en cours de création
                    CListeObjetsDonnees liste_type = new CListeObjetsDonnees(TypeProjet.ContexteDonnee, typeof(CTypeProjet));
                    liste_type.Filtre = new CFiltreData(CTypeProjet.c_champId + " >= 0");

                    m_panelTypeContenu.Init(
                        liste_type,
                        TypeProjet.RelationsTypesProjetsFilsPossibles,
                        TypeProjet,
                        "TypeProjetParent",
                        "TypeProjetFils");
                    m_panelTypeContenu.RemplirGrille();

                    m_panelTypeContenant.Init(
                        liste_type,
                        TypeProjet.RelationsTypesProjetsParentsPossibles,
                        TypeProjet,
                        "TypeProjetFils",
                        "TypeProjetParent");
                    m_panelTypeContenant.RemplirGrille();

                    m_panelSousTypes.Init(
                        liste_type,
                        TypeProjet.RelationsSousTypesProjetsPossibles,
                        TypeProjet,
                        "TypeProjetParent",
                        "SousTypeProjet");
                    m_panelSousTypes.RemplirGrille();
                }
                if (page == m_pageEOS)
                {
                    m_panelEOS.Init(TypeProjet);
                }
			}

			
			return result;
		}

		private CResultAErreur CFormEditionTypeProjet_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageChampCustom)
			{
				result = m_panelEditChamps.MAJ_Champs();
			}
            if (page == m_pageSettings)
            {
                TypeProjet.DureeDefautHeures = (double) m_numDureeHeureDefaut.Value;
                TypeProjet.FormulePoids = m_txtFormulePoids.Formule;
                TypeProjet.FormuleAvancement = m_txtFormuleProgress.Formule;
                TypeProjet.Image = m_imageSelect.Image;
                TypeProjet.OptionVersionCode = (int)m_cmbOptionVersion.SelectedValue;
                TypeProjet.VersionSurReferentiel = (bool)m_cmbParenteeVersion.SelectedValue;
                TypeProjet.FormuleElementAssocie = m_txtFormuleElementAssocie.Formule;
                TypeProjet.FormuleFormulaireVersion = m_txtFormuleFormulaire.Formule;
                TypeProjet.TypeBesoinParDefaut = m_cmbTypeBesoinDefaut.SelectedValue as CTypeDonneeBesoin;
            }
            if ( page == m_pageEvents )
				result = m_panelEvenements.MAJ_Champs();
            if (page == m_tabPageFormulaire)
                result = m_panelChamps.MAJ_Champs();
            if (page == m_pageHierarchie)
            {
                m_panelTypeContenu.ApplyModifs();
                m_panelTypeContenant.ApplyModifs();
                m_panelSousTypes.ApplyModifs();
            }
            if (page == m_pageEOS)
            {
                result = m_panelEOS.MajChamps();
            }
			return result;
		}
	}
}

