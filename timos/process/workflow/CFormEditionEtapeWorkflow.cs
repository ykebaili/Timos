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
using System.Text;
using timos.securite;
using timos.process.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEtapeWorkflow))]
	public class CFormEditionEtapeWorkflow : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tab;
        private Crownwood.Magic.Controls.TabPage m_pageDetails;
        private LinkLabel m_lnkTerminéePar;
        private LinkLabel m_lnkDemarreePar;
        private Label label5;
        private Label label4;
        private Label m_lblEndDate;
        private Label m_lblStartDate;
        private Label label3;
        private Label label2;
        private Label label8;
        private Label m_lblReturnCode;
        private Label label7;
        private Label m_lblEtat;
        private Label label6;
        private TextBox m_txtLastError;
        private Crownwood.Magic.Controls.TabPage m_pageHistorique;
        private ListView m_wndListeHistorique;
        private ColumnHeader m_colStartDate;
        private ColumnHeader m_colEndDate;
        private ColumnHeader m_colStartedBy;
        private ColumnHeader m_colEndedBy;
        private ColumnHeader m_colCodesRetour;
        private LinkLabel m_lnkWorkflow;
        private Label label9;
        private Crownwood.Magic.Controls.TabPage m_pageAffectations;
        private CPanelAffectationsEtapeWorkflow m_panelAffectations;
        private ColumnHeader m_colEtat;
        private ColumnHeader m_colEtapeAppelante;
        private ColumnHeader m_colRunGeneration;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionEtapeWorkflow()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEtapeWorkflow(CEtapeWorkflow EtapeWorkflow)
			:base(EtapeWorkflow)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEtapeWorkflow(CEtapeWorkflow EtapeWorkflow, CListeObjetsDonnees liste)
			:base(EtapeWorkflow, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionEtapeWorkflow));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkWorkflow = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageHistorique = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeHistorique = new System.Windows.Forms.ListView();
            this.m_colStartDate = new System.Windows.Forms.ColumnHeader();
            this.m_colEndDate = new System.Windows.Forms.ColumnHeader();
            this.m_colStartedBy = new System.Windows.Forms.ColumnHeader();
            this.m_colEndedBy = new System.Windows.Forms.ColumnHeader();
            this.m_colCodesRetour = new System.Windows.Forms.ColumnHeader();
            this.m_colEtat = new System.Windows.Forms.ColumnHeader();
            this.m_colEtapeAppelante = new System.Windows.Forms.ColumnHeader();
            this.m_pageDetails = new Crownwood.Magic.Controls.TabPage();
            this.m_txtLastError = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblReturnCode = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lblEtat = new System.Windows.Forms.Label();
            this.m_lnkTerminéePar = new System.Windows.Forms.LinkLabel();
            this.m_lnkDemarreePar = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblEndDate = new System.Windows.Forms.Label();
            this.m_lblStartDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pageAffectations = new Crownwood.Magic.Controls.TabPage();
            this.m_panelAffectations = new timos.process.workflow.CPanelAffectationsEtapeWorkflow();
            this.m_colRunGeneration = new System.Windows.Forms.ColumnHeader();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tab.SuspendLayout();
            this.m_pageHistorique.SuspendLayout();
            this.m_pageDetails.SuspendLayout();
            this.m_pageAffectations.SuspendLayout();
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
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkWorkflow);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label9);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 78);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lnkWorkflow
            // 
            this.m_lnkWorkflow.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkWorkflow, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkWorkflow, false);
            this.m_lnkWorkflow.Location = new System.Drawing.Point(132, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkWorkflow, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkWorkflow, "");
            this.m_lnkWorkflow.Name = "m_lnkWorkflow";
            this.m_lnkWorkflow.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkWorkflow, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkWorkflow.TabIndex = 4003;
            this.m_lnkWorkflow.TabStop = true;
            this.m_lnkWorkflow.Text = "linkLabel1";
            this.m_lnkWorkflow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkWorkflow_LinkClicked);
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(16, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 16);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 0;
            this.label9.Text = "Workflow|20606";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_tab
            // 
            this.m_tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tab, false);
            this.m_tab.Location = new System.Drawing.Point(8, 119);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tab, "");
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.SelectedIndex = 2;
            this.m_tab.SelectedTab = this.m_pageHistorique;
            this.m_tab.Size = new System.Drawing.Size(822, 412);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 4004;
            this.m_tab.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDetails,
            this.m_pageAffectations,
            this.m_pageHistorique});
            this.m_tab.SelectionChanged += new System.EventHandler(this.m_tab_SelectionChanged);
            // 
            // m_pageHistorique
            // 
            this.m_pageHistorique.Controls.Add(this.m_wndListeHistorique);
            this.m_extLinkField.SetLinkField(this.m_pageHistorique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageHistorique, false);
            this.m_pageHistorique.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageHistorique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageHistorique, "");
            this.m_pageHistorique.Name = "m_pageHistorique";
            this.m_pageHistorique.Size = new System.Drawing.Size(806, 371);
            this.m_extStyle.SetStyleBackColor(this.m_pageHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageHistorique.TabIndex = 11;
            this.m_pageHistorique.Title = "History|20683";
            // 
            // m_wndListeHistorique
            // 
            this.m_wndListeHistorique.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colStartDate,
            this.m_colEndDate,
            this.m_colStartedBy,
            this.m_colEndedBy,
            this.m_colCodesRetour,
            this.m_colEtat,
            this.m_colEtapeAppelante,
            this.m_colRunGeneration});
            this.m_wndListeHistorique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_wndListeHistorique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeHistorique, false);
            this.m_wndListeHistorique.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeHistorique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeHistorique, "");
            this.m_wndListeHistorique.Name = "m_wndListeHistorique";
            this.m_wndListeHistorique.Size = new System.Drawing.Size(806, 371);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeHistorique.TabIndex = 0;
            this.m_wndListeHistorique.UseCompatibleStateImageBehavior = false;
            this.m_wndListeHistorique.View = System.Windows.Forms.View.Details;
            // 
            // m_colStartDate
            // 
            this.m_colStartDate.Text = "Start date|20600";
            this.m_colStartDate.Width = 120;
            // 
            // m_colEndDate
            // 
            this.m_colEndDate.Text = "End date|20601";
            this.m_colEndDate.Width = 120;
            // 
            // m_colStartedBy
            // 
            this.m_colStartedBy.Text = "Started by|20602";
            this.m_colStartedBy.Width = 250;
            // 
            // m_colEndedBy
            // 
            this.m_colEndedBy.Text = "Ended by|20603";
            this.m_colEndedBy.Width = 250;
            // 
            // m_colCodesRetour
            // 
            this.m_colCodesRetour.Text = "Return code|20605";
            this.m_colCodesRetour.Width = 150;
            // 
            // m_colEtat
            // 
            this.m_colEtat.Text = "State|20604";
            this.m_colEtat.Width = 150;
            // 
            // m_colEtapeAppelante
            // 
            this.m_colEtapeAppelante.Text = "Calling step|20681";
            this.m_colEtapeAppelante.Width = 250;
            // 
            // m_pageDetails
            // 
            this.m_pageDetails.Controls.Add(this.m_txtLastError);
            this.m_pageDetails.Controls.Add(this.label8);
            this.m_pageDetails.Controls.Add(this.m_lblReturnCode);
            this.m_pageDetails.Controls.Add(this.label7);
            this.m_pageDetails.Controls.Add(this.m_lblEtat);
            this.m_pageDetails.Controls.Add(this.m_lnkTerminéePar);
            this.m_pageDetails.Controls.Add(this.m_lnkDemarreePar);
            this.m_pageDetails.Controls.Add(this.label5);
            this.m_pageDetails.Controls.Add(this.label4);
            this.m_pageDetails.Controls.Add(this.m_lblEndDate);
            this.m_pageDetails.Controls.Add(this.m_lblStartDate);
            this.m_pageDetails.Controls.Add(this.label3);
            this.m_pageDetails.Controls.Add(this.label6);
            this.m_pageDetails.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_pageDetails, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageDetails, false);
            this.m_pageDetails.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDetails, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDetails, "");
            this.m_pageDetails.Name = "m_pageDetails";
            this.m_pageDetails.Selected = false;
            this.m_pageDetails.Size = new System.Drawing.Size(806, 371);
            this.m_extStyle.SetStyleBackColor(this.m_pageDetails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDetails, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDetails.TabIndex = 10;
            this.m_pageDetails.Title = "Details|20599";
            // 
            // m_txtLastError
            // 
            this.m_txtLastError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLastError, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLastError, false);
            this.m_txtLastError.Location = new System.Drawing.Point(132, 108);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLastError, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtLastError, "");
            this.m_txtLastError.Multiline = true;
            this.m_txtLastError.Name = "m_txtLastError";
            this.m_txtLastError.Size = new System.Drawing.Size(671, 78);
            this.m_extStyle.SetStyleBackColor(this.m_txtLastError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLastError, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLastError.TabIndex = 10;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(4, 109);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 9;
            this.label8.Text = "Last error|20682";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblReturnCode
            // 
            this.m_lblReturnCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblReturnCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblReturnCode, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblReturnCode, false);
            this.m_lblReturnCode.Location = new System.Drawing.Point(401, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblReturnCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblReturnCode, "");
            this.m_lblReturnCode.Name = "m_lblReturnCode";
            this.m_lblReturnCode.Size = new System.Drawing.Size(281, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblReturnCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblReturnCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblReturnCode.TabIndex = 8;
            this.m_lblReturnCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(271, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 7;
            this.label7.Text = "Return code|20605";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblEtat
            // 
            this.m_lblEtat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblEtat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblEtat, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblEtat, false);
            this.m_lblEtat.Location = new System.Drawing.Point(132, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEtat, "");
            this.m_lblEtat.Name = "m_lblEtat";
            this.m_lblEtat.Size = new System.Drawing.Size(130, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtat.TabIndex = 6;
            this.m_lblEtat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkTerminéePar
            // 
            this.m_lnkTerminéePar.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTerminéePar, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkTerminéePar, false);
            this.m_lnkTerminéePar.Location = new System.Drawing.Point(402, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTerminéePar, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkTerminéePar, "");
            this.m_lnkTerminéePar.Name = "m_lnkTerminéePar";
            this.m_lnkTerminéePar.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTerminéePar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTerminéePar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTerminéePar.TabIndex = 5;
            this.m_lnkTerminéePar.TabStop = true;
            this.m_lnkTerminéePar.Text = "linkLabel1";
            this.m_lnkTerminéePar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTerminéePar_LinkClicked);
            // 
            // m_lnkDemarreePar
            // 
            this.m_lnkDemarreePar.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkDemarreePar, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDemarreePar, false);
            this.m_lnkDemarreePar.Location = new System.Drawing.Point(402, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDemarreePar, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDemarreePar, "");
            this.m_lnkDemarreePar.Name = "m_lnkDemarreePar";
            this.m_lnkDemarreePar.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDemarreePar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDemarreePar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDemarreePar.TabIndex = 4;
            this.m_lnkDemarreePar.TabStop = true;
            this.m_lnkDemarreePar.Text = "linkLabel1";
            this.m_lnkDemarreePar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDemarreePar_LinkClicked);
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(271, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ended by|20603";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(271, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 2;
            this.label4.Text = "Started by|20602";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblEndDate
            // 
            this.m_lblEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblEndDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblEndDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblEndDate, false);
            this.m_lblEndDate.Location = new System.Drawing.Point(132, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEndDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEndDate, "");
            this.m_lblEndDate.Name = "m_lblEndDate";
            this.m_lblEndDate.Size = new System.Drawing.Size(130, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblEndDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEndDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEndDate.TabIndex = 1;
            this.m_lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblStartDate
            // 
            this.m_lblStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblStartDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblStartDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblStartDate, false);
            this.m_lblStartDate.Location = new System.Drawing.Point(132, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblStartDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblStartDate, "");
            this.m_lblStartDate.Name = "m_lblStartDate";
            this.m_lblStartDate.Size = new System.Drawing.Size(130, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblStartDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblStartDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStartDate.TabIndex = 1;
            this.m_lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(4, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "End Date|20601";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(4, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "State|20604";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Start Date|20600";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_pageAffectations
            // 
            this.m_pageAffectations.Controls.Add(this.m_panelAffectations);
            this.m_extLinkField.SetLinkField(this.m_pageAffectations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageAffectations, false);
            this.m_pageAffectations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAffectations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageAffectations, "");
            this.m_pageAffectations.Name = "m_pageAffectations";
            this.m_pageAffectations.Selected = false;
            this.m_pageAffectations.Size = new System.Drawing.Size(806, 371);
            this.m_extStyle.SetStyleBackColor(this.m_pageAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAffectations.TabIndex = 12;
            this.m_pageAffectations.Title = "Assignments|20607";
            // 
            // m_panelAffectations
            // 
            this.m_panelAffectations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelAffectations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelAffectations, false);
            this.m_panelAffectations.Location = new System.Drawing.Point(0, 0);
            this.m_panelAffectations.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAffectations, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelAffectations, "");
            this.m_panelAffectations.Name = "m_panelAffectations";
            this.m_panelAffectations.Size = new System.Drawing.Size(806, 371);
            this.m_extStyle.SetStyleBackColor(this.m_panelAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAffectations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAffectations.TabIndex = 12;
            // 
            // m_colRunGeneration
            // 
            this.m_colRunGeneration.Text = "Generation|20869";
            // 
            // CFormEditionEtapeWorkflow
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tab);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionEtapeWorkflow";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tab;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEtapeWorkflow_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEtapeWorkflow_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tab, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.m_tab.ResumeLayout(false);
            this.m_tab.PerformLayout();
            this.m_pageHistorique.ResumeLayout(false);
            this.m_pageDetails.ResumeLayout(false);
            this.m_pageDetails.PerformLayout();
            this.m_pageAffectations.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CEtapeWorkflow EtapeWorkflow
		{
			get
			{
				return (CEtapeWorkflow)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
            m_lnkWorkflow.Text = EtapeWorkflow.Workflow.Libelle;
			AffecterTitre(I.T( "Workflow step @1|20598", EtapeWorkflow.Libelle));
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        //-------------------------------------------------------------------------
        private CActeur GetActeur(CDbKey keyUser)
        {
            if (keyUser != null)
            {
                //TESTDBKEYOK
                CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur(EtapeWorkflow.ContexteDonnee);
                if (user.ReadIfExists(keyUser))
                    return user.Acteur;
            }
            return null;
        }
            

        //-------------------------------------------------------------------------
        private void InitPageDetails()
        {
            m_lblStartDate.Text = EtapeWorkflow.DateDebut != null ?
                    EtapeWorkflow.DateDebut.Value.ToString("G") : "";
            m_lblEndDate.Text = EtapeWorkflow.DateFin != null ?
                EtapeWorkflow.DateFin.Value.ToString("G") : "";
            m_lblEtat.Text = EtapeWorkflow.Etat != null ? EtapeWorkflow.Etat.Libelle : "";
            StringBuilder bl = new StringBuilder();
            foreach (string strCode in EtapeWorkflow.CodesRetour)
            {
                bl.Append(strCode);
                bl.Append(',');
            }
            if (bl.Length > 0)
                bl.Remove(bl.Length - 1, 1);
            m_lblReturnCode.Text = bl.ToString();

            //TESTDBKEYOK
            CActeur acteur = GetActeur(EtapeWorkflow.KeyDémarreur);
            m_lnkDemarreePar.Text = acteur != null ? acteur.IdentiteComplete : "";

            //TESTDBKEYOK
            acteur = GetActeur ( EtapeWorkflow.KeyTermineur );
            m_lnkTerminéePar.Text = acteur != null ? acteur.IdentiteComplete : "";

            m_txtLastError.Text = EtapeWorkflow.LastError;
        }

        //-------------------------------------------------------------------
        private void InitPageHistorique()
        {
            m_wndListeHistorique.BeginUpdate();
            m_wndListeHistorique.Items.Clear();
            foreach (CEtapeWorkflowHistorique h in EtapeWorkflow.Historiques)
            {
                ListViewItem item = new ListViewItem();
                SetItemText(item, m_colStartDate, h.DateDebut.ToString("G"));
                SetItemText(item, m_colEndDate, h.DateFin.ToString("G"));
                //TESTDBKEYOK
                CActeur acteur = GetActeur(h.KeyDémarreur);
                SetItemText(item, m_colStartedBy, acteur != null ? acteur.IdentiteComplete: "");
                //TESTDBKEYOK
                acteur = GetActeur(h.KeyTermineur);
                SetItemText(item, m_colEndedBy, acteur != null ? acteur.IdentiteComplete : "");
                
                StringBuilder bl = new StringBuilder();
                foreach ( string strCode in h.CodesRetour )
                {
                    bl.Append(strCode);
                    bl.Append(',');
                }
                if ( bl.Length > 0 )
                    bl.Remove ( bl.Length-1, 1);
                SetItemText(item, m_colCodesRetour, bl.ToString());
                if ( h.EtapeAppelante != null )
                    SetItemText(item, m_colEtapeAppelante, h.EtapeAppelante.Libelle);
                if ( h.Etat != null )
                    SetItemText(item, m_colEtat, h.Etat.Libelle );
                else
                    SetItemText (item, m_colEtat, "?");
                SetItemText(item, m_colRunGeneration, h.RunGeneration.ToString());
                m_wndListeHistorique.Items.Add ( item );
            }
            m_wndListeHistorique.EndUpdate();
        }

        //-------------------------------------------------------------------
        private void SetItemText(ListViewItem item, ColumnHeader h, string strText)
        {
            while (item.SubItems.Count <= h.Index)
                item.SubItems.Add(new ListViewItem.ListViewSubItem());
            item.SubItems[h.Index].Text = strText;
        }
        

        //-------------------------------------------------------------------
        private CResultAErreur CFormEditionEtapeWorkflow_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if ( page == m_pageDetails )
            {
                InitPageDetails();
            }
            if (page == m_pageHistorique)
            {
                InitPageHistorique();
            }
            if (page == m_pageAffectations)
            {
                CAffectationsEtapeWorkflow aff = EtapeWorkflow.Affectations;
                m_panelAffectations.Init(aff.GetAffectables());
            }
            return result;
        }



        //-------------------------------------------------------------------
        private CResultAErreur CFormEditionEtapeWorkflow_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if ( page == m_pageAffectations )
            {
                CAffectationsEtapeWorkflow aff = new CAffectationsEtapeWorkflow();
                foreach ( IAffectableAEtape affectable in m_panelAffectations.ListeAffectables )
                    aff.AddAffectable ( affectable );
                EtapeWorkflow.Affectations = aff;
            }
            return result;
        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkDemarreePar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TESTDBKEYOK
            ShowUser ( EtapeWorkflow.KeyDémarreur );
        }

        //--------------------------------------------------------------------------------------------
        private void ShowUser ( CDbKey keyUser )
        {
            //TESTDBKEYOK
            CActeur acteur = GetActeur(keyUser);
            if (acteur != null)
            {
                CTimosApp.Navigateur.EditeElement(acteur, false, "");
                /*
                CReferenceTypeForm refEdit = CFormFinder.GetRefFormToEdit(typeof(CActeur));
                if (refEdit != null)
                {
                    Form frm = refEdit.GetForm(acteur);
                    CTimosApp.Navigateur.AffichePage((IFormNavigable)frm);
                }*/
            }
        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkTerminéePar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //TESTDBKEYOK
            ShowUser(EtapeWorkflow.KeyTermineur);
        }

        //--------------------------------------------------------------------------------------------
        private void m_lnkWorkflow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTimosApp.Navigateur.EditeElement(EtapeWorkflow.Workflow, false, "");
        }

        //--------------------------------------------------------------------------------------------
        private void m_tab_SelectionChanged(object sender, EventArgs e)
        {

        }
	}
}

