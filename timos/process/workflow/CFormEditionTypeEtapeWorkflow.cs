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

namespace timos.process.workflow
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeEtapeWorkflow))]
	public class CFormEditionTypeEtapeWorkflow : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private C2iTextBox m_txtUniversalId;
        private Label label2;
        private CheckBox m_chkAutoexec;
        private Crownwood.Magic.Controls.TabPage m_pageSettings;
        private Crownwood.Magic.Controls.TabPage m_pageProperties;
        private C2iTextBox m_txtDescription;
        private Label label3;
        private sc2i.win32.process.workflow.CPanelEditeParametresInitialisationEtape m_panelEditeParametresInitialisation;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChampsCustom;
        private C2iLink m_linkTypeWorkflow;
        private Crownwood.Magic.Controls.TabPage m_pageEvenements;
        private sc2i.win32.process.CPanelDefinisseurEvenements m_panelDefinisseurEvenements;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeEtapeWorkflow()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CFormEditionTypeEtapeWorkflow(CTypeEtapeWorkflow typeEtape)
            : base(typeEtape)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
        public CFormEditionTypeEtapeWorkflow(CTypeEtapeWorkflow typeEtape, CListeObjetsDonnees liste)
            : base(typeEtape, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeEtapeWorkflow));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_linkTypeWorkflow = new sc2i.win32.common.C2iLink(this.components);
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtUniversalId = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkAutoexec = new System.Windows.Forms.CheckBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurEvenements = new sc2i.win32.process.CPanelDefinisseurEvenements();
            this.m_pageSettings = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditeParametresInitialisation = new sc2i.win32.process.workflow.CPanelEditeParametresInitialisationEtape();
            this.m_pageProperties = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageEvenements.SuspendLayout();
            this.m_pageSettings.SuspendLayout();
            this.m_pageProperties.SuspendLayout();
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 4);
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
            this.c2iPanelOmbre4.Controls.Add(this.m_linkTypeWorkflow);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtDescription);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtUniversalId);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkAutoexec);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(641, 131);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_linkTypeWorkflow
            // 
            this.m_linkTypeWorkflow.ClickEnabled = true;
            this.m_linkTypeWorkflow.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkTypeWorkflow.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkTypeWorkflow.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkTypeWorkflow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkTypeWorkflow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkTypeWorkflow.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_linkTypeWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_linkTypeWorkflow, false);
            this.m_linkTypeWorkflow.Location = new System.Drawing.Point(448, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkTypeWorkflow, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_linkTypeWorkflow, "");
            this.m_linkTypeWorkflow.Name = "m_linkTypeWorkflow";
            this.m_linkTypeWorkflow.Size = new System.Drawing.Size(161, 19);
            this.m_extStyle.SetStyleBackColor(this.m_linkTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkTypeWorkflow.TabIndex = 4004;
            this.m_linkTypeWorkflow.Text = "Parent Workflow Type";
            this.m_linkTypeWorkflow.LinkClicked += new System.EventHandler(this.m_linkTypeWorkflow_LinkClicked);
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescription.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescription, true);
            this.m_txtDescription.Location = new System.Drawing.Point(132, 56);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(477, 44);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 0;
            this.m_txtDescription.Text = "[Description]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Description";
            // 
            // m_txtUniversalId
            // 
            this.m_txtUniversalId.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtUniversalId, "UniversalId");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtUniversalId, true);
            this.m_txtUniversalId.Location = new System.Drawing.Point(132, 30);
            this.m_txtUniversalId.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtUniversalId, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtUniversalId, "");
            this.m_txtUniversalId.Name = "m_txtUniversalId";
            this.m_txtUniversalId.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtUniversalId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtUniversalId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtUniversalId.TabIndex = 0;
            this.m_txtUniversalId.Text = "[UniversalId]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Universal Id|10415";
            // 
            // m_chkAutoexec
            // 
            this.m_extLinkField.SetLinkField(this.m_chkAutoexec, "ExecutionAutomatique");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAutoexec, true);
            this.m_chkAutoexec.Location = new System.Drawing.Point(448, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAutoexec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAutoexec, "");
            this.m_chkAutoexec.Name = "m_chkAutoexec";
            this.m_chkAutoexec.Size = new System.Drawing.Size(161, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkAutoexec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAutoexec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAutoexec.TabIndex = 4003;
            this.m_chkAutoexec.Text = "Autoexecution|10416";
            this.m_chkAutoexec.UseVisualStyleBackColor = true;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 189);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSettings;
            this.m_tabControl.Size = new System.Drawing.Size(810, 329);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSettings,
            this.m_pageEvenements,
            this.m_pageProperties});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageEvenements
            // 
            this.m_pageEvenements.Controls.Add(this.m_panelDefinisseurEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEvenements, false);
            this.m_pageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvenements, "");
            this.m_pageEvenements.Name = "m_pageEvenements";
            this.m_pageEvenements.Selected = false;
            this.m_pageEvenements.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvenements.TabIndex = 12;
            this.m_pageEvenements.Title = "Events Setup|183";
            // 
            // m_panelDefinisseurEvenements
            // 
            this.m_panelDefinisseurEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDefinisseurEvenements, false);
            this.m_panelDefinisseurEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Name = "m_panelDefinisseurEvenements";
            this.m_panelDefinisseurEvenements.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurEvenements.TabIndex = 0;
            // 
            // m_pageSettings
            // 
            this.m_pageSettings.Controls.Add(this.m_panelEditeParametresInitialisation);
            this.m_extLinkField.SetLinkField(this.m_pageSettings, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSettings, false);
            this.m_pageSettings.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSettings, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSettings, "");
            this.m_pageSettings.Name = "m_pageSettings";
            this.m_pageSettings.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_pageSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSettings.TabIndex = 10;
            this.m_pageSettings.Title = "Initialization Settings|10417";
            // 
            // m_panelEditeParametresInitialisation
            // 
            this.m_panelEditeParametresInitialisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEditeParametresInitialisation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditeParametresInitialisation, false);
            this.m_panelEditeParametresInitialisation.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditeParametresInitialisation.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditeParametresInitialisation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditeParametresInitialisation, "");
            this.m_panelEditeParametresInitialisation.Name = "m_panelEditeParametresInitialisation";
            this.m_panelEditeParametresInitialisation.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditeParametresInitialisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditeParametresInitialisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditeParametresInitialisation.TabIndex = 0;
            // 
            // m_pageProperties
            // 
            this.m_pageProperties.Controls.Add(this.m_panelChampsCustom);
            this.m_extLinkField.SetLinkField(this.m_pageProperties, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageProperties, false);
            this.m_pageProperties.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageProperties, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageProperties, "");
            this.m_pageProperties.Name = "m_pageProperties";
            this.m_pageProperties.Selected = false;
            this.m_pageProperties.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_pageProperties, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageProperties, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageProperties.TabIndex = 11;
            this.m_pageProperties.Title = "Properties|10418";
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChampsCustom.BoldSelectedPage = true;
            this.m_panelChampsCustom.ControlBottomOffset = 16;
            this.m_panelChampsCustom.ControlRightOffset = 16;
            this.m_panelChampsCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChampsCustom.ElementEdite = null;
            this.m_panelChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelChampsCustom.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChampsCustom, false);
            this.m_panelChampsCustom.Location = new System.Drawing.Point(0, 0);
            this.m_panelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Ombre = true;
            this.m_panelChampsCustom.PositionTop = true;
            this.m_panelChampsCustom.Size = new System.Drawing.Size(794, 288);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChampsCustom.TabIndex = 0;
            this.m_panelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeEtapeWorkflow
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeEtapeWorkflow";
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
            this.m_pageEvenements.ResumeLayout(false);
            this.m_pageSettings.ResumeLayout(false);
            this.m_pageProperties.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		
        //-------------------------------------------------------------------------
		private CTypeEtapeWorkflow TypeEtape
		{
			get
			{
                return (CTypeEtapeWorkflow)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Step Type @1|10414", TypeEtape.Libelle));

            if (TypeEtape.Workflow != null)
                m_linkTypeWorkflow.Text = TypeEtape.Workflow.Libelle;
            m_txtUniversalId.LockEdition = true;
            m_panelEditeParametresInitialisation.Init(TypeEtape.ParametresInitialisation);
            m_panelDefinisseurEvenements.InitChamps(TypeEtape);
            if (TypeEtape.GetFormulaires().Length > 0)
            {
                if (!m_tabControl.TabPages.Contains(m_pageProperties))
                    m_tabControl.TabPages.Add(m_pageProperties);
                m_panelChampsCustom.ElementEdite = TypeEtape;
            }
            else
            {
                if (m_tabControl.TabPages.Contains(m_pageProperties))
                    m_tabControl.TabPages.Remove(m_pageProperties);
            }

			return result;

		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (!result)
                return result;

            CResultAErreurType<CParametresInitialisationEtape> resultParams = m_panelEditeParametresInitialisation.MajChamps();
            if (!resultParams)
            {
                return resultParams;
            }
            TypeEtape.ParametresInitialisation = resultParams.DataType;
            result = m_panelChampsCustom.MAJ_Champs();
            if (result)
                result = m_panelDefinisseurEvenements.MAJ_Champs();

            return result;
        }

        //-------------------------------------------------------------------------
        private void m_linkTypeWorkflow_LinkClicked(object sender, EventArgs e)
        {
            CTypeWorkflow typeWorkflowParent = TypeEtape.Workflow;

            if (typeWorkflowParent != null)
            {
                CTimosApp.Navigateur.AffichePage(new CFormEditionTypeWorkflow(typeWorkflowParent));
            }
        }
	}
}

