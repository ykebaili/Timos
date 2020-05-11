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
using sc2i.process.workflow;
using sc2i.process.workflow.blocs;
using timos.process.workflow;

namespace timos.process.workflow
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeWorkflow))]
	public class CFormEditionTypeWorkflow : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageWorkflow;
        private Crownwood.Magic.Controls.TabPage m_pageDescription;
        private Crownwood.Magic.Controls.TabPage m_pageChamps;
        private sc2i.win32.process.workflow.CPanelEditionWorkflow m_panelWorkflow;
        private C2iTextBox c2iTextBox1;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private LinkLabel m_lnkTest;
        private Crownwood.Magic.Controls.TabPage m_pageEvenements;
        private CPanelDefinisseurEvenements m_panelEvenements;
        private Crownwood.Magic.Controls.TabPage m_pageTypesEtapes;
        private CPanelListeSpeedStandard m_wndListeTypesEtapes;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeWorkflow()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeWorkflow(CTypeWorkflow TypeWorkflow)
			:base(TypeWorkflow)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeWorkflow(CTypeWorkflow TypeWorkflow, CListeObjetsDonnees liste)
			:base(TypeWorkflow, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeWorkflow));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDescription = new Crownwood.Magic.Controls.TabPage();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_pageWorkflow = new Crownwood.Magic.Controls.TabPage();
            this.m_panelWorkflow = new sc2i.win32.process.workflow.CPanelEditionWorkflow();
            this.m_pageChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_lnkTest = new System.Windows.Forms.LinkLabel();
            this.m_pageTypesEtapes = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeTypesEtapes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageDescription.SuspendLayout();
            this.m_pageWorkflow.SuspendLayout();
            this.m_pageChamps.SuspendLayout();
            this.m_pageEvenements.SuspendLayout();
            this.m_pageTypesEtapes.SuspendLayout();
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
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
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
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
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 53);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageTypesEtapes;
            this.m_tabControl.Size = new System.Drawing.Size(822, 417);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageWorkflow,
            this.m_pageTypesEtapes,
            this.m_pageDescription,
            this.m_pageChamps,
            this.m_pageEvenements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDescription
            // 
            this.m_pageDescription.Controls.Add(this.c2iTextBox1);
            this.m_extLinkField.SetLinkField(this.m_pageDescription, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageDescription, false);
            this.m_pageDescription.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDescription, "");
            this.m_pageDescription.Name = "m_pageDescription";
            this.m_pageDescription.Selected = false;
            this.m_pageDescription.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_pageDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDescription.TabIndex = 11;
            this.m_pageDescription.Title = "Description|20553";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(10, 7);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(782, 348);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Description]";
            // 
            // m_pageWorkflow
            // 
            this.m_pageWorkflow.Controls.Add(this.m_panelWorkflow);
            this.m_extLinkField.SetLinkField(this.m_pageWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageWorkflow, false);
            this.m_pageWorkflow.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageWorkflow, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageWorkflow, "");
            this.m_pageWorkflow.Name = "m_pageWorkflow";
            this.m_pageWorkflow.Selected = false;
            this.m_pageWorkflow.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_pageWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageWorkflow.TabIndex = 10;
            this.m_pageWorkflow.Title = "Workflow|20552";
            // 
            // m_panelWorkflow
            // 
            this.m_panelWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelWorkflow, false);
            this.m_panelWorkflow.Location = new System.Drawing.Point(0, 0);
            this.m_panelWorkflow.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelWorkflow, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelWorkflow, "");
            this.m_panelWorkflow.Name = "m_panelWorkflow";
            this.m_panelWorkflow.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelWorkflow.TabIndex = 0;
            this.m_panelWorkflow.WorkflowEdite = null;
            // 
            // m_pageChamps
            // 
            this.m_pageChamps.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChamps, false);
            this.m_pageChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChamps, "");
            this.m_pageChamps.Name = "m_pageChamps";
            this.m_pageChamps.Selected = false;
            this.m_pageChamps.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChamps.TabIndex = 12;
            this.m_pageChamps.Title = "Custom fields|198";
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
            this.m_panelEditChamps.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 2;
            // 
            // m_pageEvenements
            // 
            this.m_pageEvenements.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEvenements, false);
            this.m_pageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvenements, "");
            this.m_pageEvenements.Name = "m_pageEvenements";
            this.m_pageEvenements.Selected = false;
            this.m_pageEvenements.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvenements.TabIndex = 13;
            this.m_pageEvenements.Title = "Events|183";
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
            this.m_panelEvenements.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 2;
            // 
            // m_lnkTest
            // 
            this.m_lnkTest.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTest, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkTest, false);
            this.m_lnkTest.Location = new System.Drawing.Point(479, 66);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTest, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTest, "");
            this.m_lnkTest.Name = "m_lnkTest";
            this.m_lnkTest.Size = new System.Drawing.Size(28, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTest.TabIndex = 4005;
            this.m_lnkTest.TabStop = true;
            this.m_lnkTest.Text = "Test";
            this.m_lnkTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTest_LinkClicked);
            // 
            // m_pageTypesEtapes
            // 
            this.m_pageTypesEtapes.Controls.Add(this.m_wndListeTypesEtapes);
            this.m_extLinkField.SetLinkField(this.m_pageTypesEtapes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageTypesEtapes, true);
            this.m_pageTypesEtapes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTypesEtapes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTypesEtapes, "");
            this.m_pageTypesEtapes.Name = "m_pageTypesEtapes";
            this.m_pageTypesEtapes.Size = new System.Drawing.Size(806, 376);
            this.m_extStyle.SetStyleBackColor(this.m_pageTypesEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTypesEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTypesEtapes.TabIndex = 14;
            this.m_pageTypesEtapes.Title = "Steps Types|10413";
            // 
            // m_wndListeTypesEtapes
            // 
            this.m_wndListeTypesEtapes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_wndListeTypesEtapes.AffectationsPourNouveauxElements")));
            this.m_wndListeTypesEtapes.AllowArbre = true;
            this.m_wndListeTypesEtapes.AllowCustomisation = true;
            this.m_wndListeTypesEtapes.AllowSerializePreferences = true;
            this.m_wndListeTypesEtapes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Libelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_wndListeTypesEtapes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeTypesEtapes.ContexteUtilisation = "";
            this.m_wndListeTypesEtapes.ControlFiltreStandard = null;
            this.m_wndListeTypesEtapes.ElementSelectionne = null;
            this.m_wndListeTypesEtapes.EnableCustomisation = true;
            this.m_wndListeTypesEtapes.FiltreDeBase = null;
            this.m_wndListeTypesEtapes.FiltreDeBaseEnAjout = false;
            this.m_wndListeTypesEtapes.FiltrePrefere = null;
            this.m_wndListeTypesEtapes.FiltreRapide = null;
            this.m_wndListeTypesEtapes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeTypesEtapes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeTypesEtapes, false);
            this.m_wndListeTypesEtapes.ListeObjets = null;
            this.m_wndListeTypesEtapes.Location = new System.Drawing.Point(3, 0);
            this.m_wndListeTypesEtapes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypesEtapes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_wndListeTypesEtapes.ModeQuickSearch = false;
            this.m_wndListeTypesEtapes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_wndListeTypesEtapes, "");
            this.m_wndListeTypesEtapes.MultiSelect = false;
            this.m_wndListeTypesEtapes.Name = "m_wndListeTypesEtapes";
            this.m_wndListeTypesEtapes.Navigateur = null;
            this.m_wndListeTypesEtapes.ObjetReferencePourAffectationsInitiales = null;
            this.m_wndListeTypesEtapes.ProprieteObjetAEditer = null;
            this.m_wndListeTypesEtapes.QuickSearchText = "";
            this.m_wndListeTypesEtapes.ShortIcons = false;
            this.m_wndListeTypesEtapes.Size = new System.Drawing.Size(800, 373);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypesEtapes.TabIndex = 2;
            this.m_wndListeTypesEtapes.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeTypesEtapes.UseCheckBoxes = false;
            // 
            // CFormEditionTypeWorkflow
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_lnkTest);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeWorkflow";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeWorkflow_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeWorkflow_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_lnkTest, 0);
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
            this.m_pageDescription.ResumeLayout(false);
            this.m_pageDescription.PerformLayout();
            this.m_pageWorkflow.ResumeLayout(false);
            this.m_pageChamps.ResumeLayout(false);
            this.m_pageEvenements.ResumeLayout(false);
            this.m_pageTypesEtapes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeWorkflow TypeWorkflow
		{
			get
			{
				return (CTypeWorkflow)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Workflow type @1|20551", TypeWorkflow.Libelle));
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        private CResultAErreur CFormEditionTypeWorkflow_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageWorkflow)
            {
                m_panelWorkflow.WorkflowEdite = TypeWorkflow.Dessin;
            }
            if (page == m_pageChamps)
            {
                m_panelEditChamps.InitPanel(
                    TypeWorkflow,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
            }
            if (page == m_pageEvenements)
                m_panelEvenements.InitChamps(TypeWorkflow);
            if (page == m_pageTypesEtapes)
            {
                m_wndListeTypesEtapes.BoutonAjouterVisible = false;
                m_wndListeTypesEtapes.BoutonSupprimerVisible = false;
                
                m_wndListeTypesEtapes.InitFromListeObjets(
                    TypeWorkflow.Etapes,
                    typeof(CTypeEtapeWorkflow),
                    TypeWorkflow,
                    "Workflow");
            }

            return result;
        }

        private CResultAErreur CFormEditionTypeWorkflow_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageWorkflow)
            {
                TypeWorkflow.Dessin = m_panelWorkflow.WorkflowEdite;
            }
            if (page == m_pageChamps)
            {
                result = m_panelEditChamps.MAJ_Champs();
            }
            if (page == m_pageEvenements)
                result = m_panelEvenements.MAJ_Champs();
            return result;
        }

        private void m_lnkTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Cherche le workflow de test
            CWorkflow wkf = new CWorkflow(TypeWorkflow.ContexteDonnee);
            if (!wkf.ReadIfExists(new CFiltreData(
                CTypeWorkflow.c_champId + "=@1",
                TypeWorkflow.Id)))
            {
                wkf.CreateNew();
                wkf.TypeWorkflow = TypeWorkflow;
                foreach (CTypeEtapeWorkflow typeEtape in TypeWorkflow.Etapes)
                {
                    CEtapeWorkflow etape = new CEtapeWorkflow(wkf.ContexteDonnee);
                    etape.CreateNewInCurrentContexte();
                    etape.Workflow = wkf;
                    etape.TypeEtape = typeEtape;
                }
                CResultAErreur result = wkf.CommitEdit();
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
            }
            foreach (CEtapeWorkflow etape in wkf.Etapes)
            {
                if (etape.TypeEtape.Bloc is CBlocWorkflowFormulaire)
                {
                    CGestionnaireWorkflowsEnCours.Instance.AfficheEtape(etape);
                }
            }

        }

	}
}

