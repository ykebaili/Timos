using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

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
using timos.securite;
using sc2i.workflow;
using timos.process.workflow;
using System.Collections.Generic;
using sc2i.win32.process.workflow;

namespace timos.process.Workflow
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CWorkflow))]
	public class CFormEditionWorkflow : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_PanelChamps;
        private Crownwood.Magic.Controls.TabPage m_pageWorkflow;
        private Label label2;
        private C2iTextBoxSelectionne m_txtSelectManager;
        private C2iTextBoxSelectionne m_txtSelectTypeWorkflow;
        private Label label3;
        private Panel m_panelStart;
        private Button m_btnStartWorkflow;
        private ContextMenuStrip m_menuStart;
        private CPanelDessineWorkflowEnCours m_panelDessinWorkflow;
        private Crownwood.Magic.Controls.TabPage m_pageSteps;
        private CPanelListeSpeedStandard m_panelEtapes;
        private LinkLabel m_lnkWorkflowAppelant;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionWorkflow()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionWorkflow(CWorkflow Workflow)
			:base(Workflow)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionWorkflow(CWorkflow Workflow, CListeObjetsDonnees liste)
			:base(Workflow, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionWorkflow));
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectTypeWorkflow = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtSelectManager = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageWorkflow = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDessinWorkflow = new timos.process.workflow.CPanelDessineWorkflowEnCours();
            this.m_panelStart = new System.Windows.Forms.Panel();
            this.m_btnStartWorkflow = new System.Windows.Forms.Button();
            this.m_pageSteps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEtapes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_menuStart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_lnkWorkflowAppelant = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageWorkflow.SuspendLayout();
            this.m_panelStart.SuspendLayout();
            this.m_pageSteps.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
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
            this.c2iPanelOmbre4.Controls.Add(this.m_txtSelectTypeWorkflow);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtSelectManager);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(782, 92);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_txtSelectTypeWorkflow
            // 
            this.m_txtSelectTypeWorkflow.ElementSelectionne = null;
            this.m_txtSelectTypeWorkflow.FonctionTextNull = null;
            this.m_txtSelectTypeWorkflow.HasLink = true;
            this.m_txtSelectTypeWorkflow.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectTypeWorkflow, false);
            this.m_txtSelectTypeWorkflow.Location = new System.Drawing.Point(133, 30);
            this.m_txtSelectTypeWorkflow.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeWorkflow, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeWorkflow, "");
            this.m_txtSelectTypeWorkflow.Name = "m_txtSelectTypeWorkflow";
            this.m_txtSelectTypeWorkflow.SelectedObject = null;
            this.m_txtSelectTypeWorkflow.Size = new System.Drawing.Size(515, 21);
            this.m_txtSelectTypeWorkflow.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeWorkflow.TabIndex = 4004;
            this.m_txtSelectTypeWorkflow.TextNull = "";
            this.m_txtSelectTypeWorkflow.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectTypeWorkflow_ElementSelectionneChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Manager|20626";
            // 
            // m_txtSelectManager
            // 
            this.m_txtSelectManager.ElementSelectionne = null;
            this.m_txtSelectManager.FonctionTextNull = null;
            this.m_txtSelectManager.HasLink = true;
            this.m_txtSelectManager.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectManager, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectManager, false);
            this.m_txtSelectManager.Location = new System.Drawing.Point(132, 52);
            this.m_txtSelectManager.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectManager, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectManager, "");
            this.m_txtSelectManager.Name = "m_txtSelectManager";
            this.m_txtSelectManager.SelectedObject = null;
            this.m_txtSelectManager.Size = new System.Drawing.Size(515, 21);
            this.m_txtSelectManager.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectManager, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectManager, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectManager.TabIndex = 4003;
            this.m_txtSelectManager.TextNull = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(15, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Workflow type|20628";
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
            this.m_tabControl.Location = new System.Drawing.Point(11, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageWorkflow;
            this.m_tabControl.Size = new System.Drawing.Size(819, 388);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageWorkflow,
            this.m_pageSteps,
            this.m_pageFormulaires});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageWorkflow
            // 
            this.m_pageWorkflow.Controls.Add(this.m_panelDessinWorkflow);
            this.m_pageWorkflow.Controls.Add(this.m_lnkWorkflowAppelant);
            this.m_pageWorkflow.Controls.Add(this.m_panelStart);
            this.m_extLinkField.SetLinkField(this.m_pageWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageWorkflow, false);
            this.m_pageWorkflow.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageWorkflow, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageWorkflow, "");
            this.m_pageWorkflow.Name = "m_pageWorkflow";
            this.m_pageWorkflow.Size = new System.Drawing.Size(803, 347);
            this.m_extStyle.SetStyleBackColor(this.m_pageWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageWorkflow.TabIndex = 11;
            this.m_pageWorkflow.Title = "Workflow|20768";
            // 
            // m_panelDessinWorkflow
            // 
            this.m_panelDessinWorkflow.AllowDrop = true;
            this.m_panelDessinWorkflow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDessinWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDessinWorkflow, false);
            this.m_panelDessinWorkflow.Location = new System.Drawing.Point(61, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDessinWorkflow, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDessinWorkflow, "");
            this.m_panelDessinWorkflow.Name = "m_panelDessinWorkflow";
            this.m_panelDessinWorkflow.Size = new System.Drawing.Size(742, 334);
            this.m_extStyle.SetStyleBackColor(this.m_panelDessinWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDessinWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDessinWorkflow.TabIndex = 0;
            // 
            // m_panelStart
            // 
            this.m_panelStart.Controls.Add(this.m_btnStartWorkflow);
            this.m_panelStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelStart, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelStart, false);
            this.m_panelStart.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelStart, "");
            this.m_panelStart.Name = "m_panelStart";
            this.m_panelStart.Size = new System.Drawing.Size(61, 347);
            this.m_extStyle.SetStyleBackColor(this.m_panelStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStart.TabIndex = 1;
            this.m_panelStart.Visible = false;
            // 
            // m_btnStartWorkflow
            // 
            this.m_btnStartWorkflow.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnStartWorkflow.Image = global::timos.Properties.Resources._1345618093_start;
            this.m_extLinkField.SetLinkField(this.m_btnStartWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnStartWorkflow, false);
            this.m_btnStartWorkflow.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnStartWorkflow, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnStartWorkflow, "");
            this.m_btnStartWorkflow.Name = "m_btnStartWorkflow";
            this.m_btnStartWorkflow.Size = new System.Drawing.Size(61, 72);
            this.m_extStyle.SetStyleBackColor(this.m_btnStartWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnStartWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStartWorkflow.TabIndex = 0;
            this.m_btnStartWorkflow.UseVisualStyleBackColor = true;
            this.m_btnStartWorkflow.Click += new System.EventHandler(this.m_btnStartWorkflow_Click);
            // 
            // m_pageSteps
            // 
            this.m_pageSteps.Controls.Add(this.m_panelEtapes);
            this.m_extLinkField.SetLinkField(this.m_pageSteps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSteps, false);
            this.m_pageSteps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSteps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSteps, "");
            this.m_pageSteps.Name = "m_pageSteps";
            this.m_pageSteps.Selected = false;
            this.m_pageSteps.Size = new System.Drawing.Size(803, 347);
            this.m_extStyle.SetStyleBackColor(this.m_pageSteps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSteps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSteps.TabIndex = 12;
            this.m_pageSteps.Title = "Steps|20623";
            // 
            // m_panelEtapes
            // 
            this.m_panelEtapes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelEtapes.AffectationsPourNouveauxElements")));
            this.m_panelEtapes.AllowArbre = true;
            this.m_panelEtapes.AllowCustomisation = true;
            this.m_panelEtapes.AllowSerializePreferences = true;
            this.m_panelEtapes.BoutonAjouterVisible = false;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Name";
            glColumn4.Propriete = "Libelle";
            glColumn4.Text = "Label|50";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 300;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Namex";
            glColumn5.Propriete = "DateDebut";
            glColumn5.Text = "Start Date|20624";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Namexx";
            glColumn6.Propriete = "DateFin";
            glColumn6.Text = "End date|20625";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 100;
            this.m_panelEtapes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4,
            glColumn5,
            glColumn6});
            this.m_panelEtapes.ContexteUtilisation = "";
            this.m_panelEtapes.ControlFiltreStandard = null;
            this.m_panelEtapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEtapes.ElementSelectionne = null;
            this.m_panelEtapes.EnableCustomisation = true;
            this.m_panelEtapes.FiltreDeBase = null;
            this.m_panelEtapes.FiltreDeBaseEnAjout = false;
            this.m_panelEtapes.FiltrePrefere = null;
            this.m_panelEtapes.FiltreRapide = null;
            this.m_panelEtapes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelEtapes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEtapes, false);
            this.m_panelEtapes.ListeObjets = null;
            this.m_panelEtapes.Location = new System.Drawing.Point(0, 0);
            this.m_panelEtapes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEtapes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelEtapes.ModeQuickSearch = false;
            this.m_panelEtapes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelEtapes, "");
            this.m_panelEtapes.MultiSelect = false;
            this.m_panelEtapes.Name = "m_panelEtapes";
            this.m_panelEtapes.Navigateur = null;
            this.m_panelEtapes.ProprieteObjetAEditer = null;
            this.m_panelEtapes.QuickSearchText = "";
            this.m_panelEtapes.ShortIcons = false;
            this.m_panelEtapes.Size = new System.Drawing.Size(803, 347);
            this.m_extStyle.SetStyleBackColor(this.m_panelEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEtapes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEtapes.TabIndex = 1;
            this.m_panelEtapes.TrierAuClicSurEnteteColonne = true;
            this.m_panelEtapes.UseCheckBoxes = false;
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_PanelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, false);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Selected = false;
            this.m_pageFormulaires.Size = new System.Drawing.Size(803, 347);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 10;
            this.m_pageFormulaires.Title = "Properties|49";
            // 
            // m_PanelChamps
            // 
            this.m_PanelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChamps.BoldSelectedPage = true;
            this.m_PanelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelChamps.ElementEdite = null;
            this.m_PanelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelChamps, false);
            this.m_PanelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(803, 347);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 2;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_menuStart
            // 
            this.m_extLinkField.SetLinkField(this.m_menuStart, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuStart, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuStart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuStart, "");
            this.m_menuStart.Name = "m_menuStart";
            this.m_menuStart.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkWorkflowAppelant
            // 
            this.m_lnkWorkflowAppelant.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_lnkWorkflowAppelant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkWorkflowAppelant, true);
            this.m_lnkWorkflowAppelant.Location = new System.Drawing.Point(61, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkWorkflowAppelant, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkWorkflowAppelant, "");
            this.m_lnkWorkflowAppelant.Name = "m_lnkWorkflowAppelant";
            this.m_lnkWorkflowAppelant.Size = new System.Drawing.Size(742, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkWorkflowAppelant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkWorkflowAppelant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkWorkflowAppelant.TabIndex = 2;
            this.m_lnkWorkflowAppelant.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkWorkflowAppelant_LinkClicked);
            // 
            // CFormEditionWorkflow
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionWorkflow";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionWorkflow_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionWorkflow_OnMajChampsPage);
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
            this.m_pageWorkflow.ResumeLayout(false);
            this.m_panelStart.ResumeLayout(false);
            this.m_pageSteps.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CWorkflow Workflow
		{
			get
			{
				return (CWorkflow)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Workflow @1|20622", Workflow.Libelle));

            


            m_panelStart.Visible = !Workflow.IsRunning || Workflow.Etapes.Count == 0;

            CFiltreData filtre = 
                new CFiltreDataAvance(
                CActeur.c_nomTable,
                "HAs(" + CDonneesActeurUtilisateur.c_nomTable + "." + CDonneesActeurUtilisateur.c_champId + ")");
            m_txtSelectManager.InitAvecFiltreDeBase<CActeur> ( 
                "IdentiteComplete", 
                filtre,
                false);

            m_txtSelectTypeWorkflow.Init<CTypeWorkflow>(
                "Libelle",
                false);
            m_txtSelectTypeWorkflow.ElementSelectionne = Workflow.TypeWorkflow;

            CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(Workflow.ContexteDonnee);
            CActeur acteur = null;
            //TESTDBKEYOK
            if (user.ReadIfExists(Workflow.KeyManager))
            {
                acteur = user.Acteur;
            }
             
            user = CUtilSession.GetUserForSession(Workflow.ContexteDonnee);
            if (acteur == null && user != null)
                acteur = user.Acteur;
            m_txtSelectManager.ElementSelectionne = acteur;

            if (Workflow.Etapes.Count > 0)
            {
                m_txtSelectTypeWorkflow.LockEdition = true;
                m_gestionnaireModeEdition.SetModeEdition(m_txtSelectTypeWorkflow, TypeModeEdition.Autonome);
            }
            else
            {
                m_txtSelectTypeWorkflow.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                m_gestionnaireModeEdition.SetModeEdition(m_txtSelectTypeWorkflow, TypeModeEdition.EnableSurEdition);
            }
            m_panelDessinWorkflow.Enabled = !ModeEdition;

			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            Workflow.TypeWorkflow = m_txtSelectTypeWorkflow.ElementSelectionne as CTypeWorkflow;
            CActeur acteur = m_txtSelectManager.ElementSelectionne as CActeur;
            if (acteur == null || acteur.Utilisateur == null)
            {
                result.EmpileErreur(I.T("Select a manager for this workflow|20627"));
            }
            else
                //TESTDBKEYOK
                Workflow.KeyManager = acteur.Utilisateur.DbKey;
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionWorkflow_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageFormulaires)
            {
                RefreshChampsCustom();
            }
            if (page == m_pageWorkflow)
            {
                if (Workflow.WorkflowParent != null)
                    m_lnkWorkflowAppelant.Text = Workflow.WorkflowParent.Libelle;
                else
                    m_lnkWorkflowAppelant.Text = "";
                m_panelDessinWorkflow.Init ( Workflow );
            }
            if (page == m_pageSteps)
            {
                m_panelEtapes.InitFromListeObjets(
                    Workflow.Etapes,
                    typeof(CEtapeWorkflow),
                    Workflow,
                    "Workflow");
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionWorkflow_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageFormulaires)
            {
                result = m_PanelChamps.MAJ_Champs();
            }
            return result;
        }

        private void m_txtSelectTypeWorkflow_ElementSelectionneChanged(object sender, EventArgs e)
        {
            CTypeWorkflow tp = m_txtSelectTypeWorkflow.ElementSelectionne as CTypeWorkflow;
            if (tp != null && m_gestionnaireModeEdition.ModeEdition)
            {
                Workflow.TypeWorkflow = tp;
                RefreshChampsCustom();
                InvalidePage(m_pageWorkflow);
                if (m_tabControl.SelectedTab == m_pageWorkflow)
                {
                    InitPage(m_pageWorkflow);
                }
                
            }
        }

        private void RefreshChampsCustom()
        {
            m_PanelChamps.ElementEdite = Workflow;
            //Cette fonction est appellée lorsqu'on clique sur le tab,
            //or, si la fonction supprime le TAB, ça fait tout planter !
            /*if (Workflow.GetFormulaires().Length > 0)
            {
                if (!m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Insert(0, m_pageFormulaires);
            }
            else
            {
                if (m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Remove(m_pageFormulaires);
            }*/
        }

        private void m_btnStartWorkflow_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            if (Workflow.TypeWorkflow == null)
            {
                result.EmpileErreur(I.T("Workflow type should be set before starting|20629"));
            }
            else
            {
                StartWorkflow(null);
            }
        }

        void m_menuStart_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CTypeEtapeWorkflow typeEtape = item != null ? item.Tag as CTypeEtapeWorkflow : null;
            if (typeEtape != null)
            {
                StartWorkflow(typeEtape);
            }
        }

        private void StartWorkflow ( CTypeEtapeWorkflow typeEtape )
        {
            if (MessageBox.Show(I.T("Start workflow \"@1\"|20571", Workflow.Libelle), "",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (CContexteDonnee ctx = new CContexteDonnee(Workflow.ContexteDonnee.IdSession, true, false))
                {
                    CWorkflow workflow = Workflow.GetObjetInContexte(ctx) as CWorkflow;
                    if (typeEtape != null)
                        typeEtape = typeEtape.GetObjetInContexte(ctx) as CTypeEtapeWorkflow;
                    CResultAErreur result = workflow.DémarreWorkflow(typeEtape, true);
                    if (!result)
                        CFormAlerte.Afficher(result.Erreur);
                    else
                    {
                        InitChamps();
                    }
                }
            }
        }

        //-------------------------------------------------------------------------
        private void m_lnkWorkflowAppelant_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Workflow.WorkflowParent != null && !m_gestionnaireModeEdition.ModeEdition)
                CTimosApp.Navigateur.EditeElement(Workflow.WorkflowParent, false,"");
        }
        

	}

}

