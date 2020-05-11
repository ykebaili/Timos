using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;

using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.data.dynamic;
using sc2i.win32.common;

using timos.win32.composants;
using timos.data;
using timos.securite;
using timos.acteurs;
using timos.tables;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeTableauPlanning))]
	public class CFormEditionInstanceTableauPlanning : CFormEditionStdTimos, IFormNavigable
	{
        // Variables membres privées
        private DateTime m_lastDateDebut = DateTime.Now.Date;
        private DateTime m_lastDateFin = DateTime.Now.Date.AddDays(6);
        private CFournisseurPropDynStd m_fournisseurPropDyn = new CFournisseurPropDynStd(true);
        private CInstanceTableauPlanning m_instanceTableauPlanning;

        // Le presse-papiers pour copier / coller des cellules du tableau
        private List<CPressePapierCellule> m_pressePapiers = new List<CPressePapierCellule>();
        private bool m_bSomethingToPast = false;
        int m_nPlusPetitRowIndex = 999999;
        int m_nPlusPetitColumnIndex = 999999;
        DataGridViewCell m_cellulePivot = null;

        // The class that will do the printing process.
        DataGridViewPrinter m_dataGridViewPrinter;

		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private ListViewAutoFilledColumn m_colJoursSemaine;
        private CToolTipTraductible m_toolTipTraductible;
        private Crownwood.Magic.Controls.TabPage m_tabPageTableau;
        private DataGridView m_tableauPlanningView;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private C2iTextBox c2iTextBox1;
        private Label label3;
        private Label label5;
        private C2iDateTimePicker m_wndDateFin;
        private C2iDateTimePicker m_wndDateDebut;
        private Label label6;
        private LinkLabel m_lnkApplyDates;
        private C2iPanel c2iPanel1;
        private LinkLabel m_lnkPrint;
        private LinkLabel m_lnkPrintPreview;
        private PrintDocument m_printDocument;
        private Panel m_panelPeriode;
        private Label label4;
        private LinkLabel m_lnkDisplayNextPeriod;
        private Panel m_panelNavigate;
        private LinkLabel m_lnkDisplayPreviousPeriod;
        private Panel m_panelImpression;
        private ContextMenuStrip m_contextMenuDGV;
        private ToolStripMenuItem m_copyToolStripMenuItem;
        private ToolStripMenuItem m_pastToolStripMenuItem;
        private LinkLabel m_lnkDisplayPreviousDay;
        private LinkLabel m_lnkDisplayNextDay;
        private ToolStripMenuItem m_deleteToolStripMenuItem;
        private LinkLabel m_lnkExport;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionInstanceTableauPlanning()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionInstanceTableauPlanning(CTypeTableauPlanning typeTableau)
            : base(typeTableau)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionInstanceTableauPlanning(CTypeTableauPlanning typeTableau, CListeObjetsDonnees liste)
            : base(typeTableau, liste)
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionInstanceTableauPlanning));
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageTableau = new Crownwood.Magic.Controls.TabPage();
            this.m_tableauPlanningView = new System.Windows.Forms.DataGridView();
            this.m_contextMenuDGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_pastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelPeriode = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_wndDateDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.m_lnkApplyDates = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_wndDateFin = new sc2i.win32.common.C2iDateTimePicker();
            this.m_panelImpression = new System.Windows.Forms.Panel();
            this.m_lnkExport = new System.Windows.Forms.LinkLabel();
            this.m_lnkPrintPreview = new System.Windows.Forms.LinkLabel();
            this.m_lnkPrint = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigate = new System.Windows.Forms.Panel();
            this.m_lnkDisplayNextDay = new System.Windows.Forms.LinkLabel();
            this.m_lnkDisplayPreviousDay = new System.Windows.Forms.LinkLabel();
            this.m_lnkDisplayPreviousPeriod = new System.Windows.Forms.LinkLabel();
            this.m_lnkDisplayNextPeriod = new System.Windows.Forms.LinkLabel();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_colJoursSemaine = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_toolTipTraductible = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_printDocument = new System.Drawing.Printing.PrintDocument();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre2.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageTableau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_tableauPlanningView)).BeginInit();
            this.m_contextMenuDGV.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.m_panelPeriode.SuspendLayout();
            this.m_panelImpression.SuspendLayout();
            this.m_panelNavigate.SuspendLayout();
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
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(807, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Schedule Table|1170";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.BackColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(159, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.ReadOnly = true;
            this.m_txtLibelle.Size = new System.Drawing.Size(320, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 1;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.label2);
            this.c2iPanelOmbre2.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(8, 31);
            this.c2iPanelOmbre2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre2, "");
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(537, 50);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 0;
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
            this.m_tabControl.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 87);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_tabPageTableau;
            this.m_tabControl.Size = new System.Drawing.Size(799, 449);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageTableau});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageTableau
            // 
            this.m_tabPageTableau.Controls.Add(this.m_tableauPlanningView);
            this.m_tabPageTableau.Controls.Add(this.c2iPanel1);
            this.m_tabPageTableau.Controls.Add(this.c2iTextBox1);
            this.m_tabPageTableau.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.m_tabPageTableau, "");
            this.m_tabPageTableau.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageTableau, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageTableau, "");
            this.m_tabPageTableau.Name = "m_tabPageTableau";
            this.m_tabPageTableau.Size = new System.Drawing.Size(783, 433);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageTableau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageTableau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageTableau.TabIndex = 10;
            this.m_tabPageTableau.Title = "Table|1171";
            // 
            // m_tableauPlanningView
            // 
            this.m_tableauPlanningView.AllowUserToAddRows = false;
            this.m_tableauPlanningView.AllowUserToDeleteRows = false;
            this.m_tableauPlanningView.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_tableauPlanningView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_tableauPlanningView.ColumnHeadersHeight = 40;
            this.m_tableauPlanningView.ContextMenuStrip = this.m_contextMenuDGV;
            this.m_tableauPlanningView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableauPlanningView.GridColor = System.Drawing.SystemColors.Control;
            this.m_extLinkField.SetLinkField(this.m_tableauPlanningView, "");
            this.m_tableauPlanningView.Location = new System.Drawing.Point(0, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tableauPlanningView, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tableauPlanningView, "");
            this.m_tableauPlanningView.Name = "m_tableauPlanningView";
            this.m_tableauPlanningView.RowHeadersVisible = false;
            this.m_tableauPlanningView.RowHeadersWidth = 4;
            this.m_tableauPlanningView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
            this.m_tableauPlanningView.Size = new System.Drawing.Size(783, 358);
            this.m_extStyle.SetStyleBackColor(this.m_tableauPlanningView, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tableauPlanningView, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tableauPlanningView.TabIndex = 0;
            this.m_tableauPlanningView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_tableauPlanningView_KeyDown);
            // 
            // m_contextMenuDGV
            // 
            this.m_contextMenuDGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_copyToolStripMenuItem,
            this.m_pastToolStripMenuItem,
            this.m_deleteToolStripMenuItem});
            this.m_extLinkField.SetLinkField(this.m_contextMenuDGV, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_contextMenuDGV, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_contextMenuDGV, "");
            this.m_contextMenuDGV.Name = "m_contextMenuDGV";
            this.m_contextMenuDGV.Size = new System.Drawing.Size(134, 70);
            this.m_extStyle.SetStyleBackColor(this.m_contextMenuDGV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_contextMenuDGV, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_copyToolStripMenuItem
            // 
            this.m_copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_copyToolStripMenuItem.Image")));
            this.m_copyToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.m_copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.m_copyToolStripMenuItem.Name = "m_copyToolStripMenuItem";
            this.m_copyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.m_copyToolStripMenuItem.Text = "Copier";
            this.m_copyToolStripMenuItem.Click += new System.EventHandler(this.m_copyToolStripMenuItem_Click);
            // 
            // m_pastToolStripMenuItem
            // 
            this.m_pastToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_pastToolStripMenuItem.Image")));
            this.m_pastToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.m_pastToolStripMenuItem.Name = "m_pastToolStripMenuItem";
            this.m_pastToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.m_pastToolStripMenuItem.Text = "Coller";
            this.m_pastToolStripMenuItem.Click += new System.EventHandler(this.m_pastToolStripMenuItem_Click);
            // 
            // m_deleteToolStripMenuItem
            // 
            this.m_deleteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("m_deleteToolStripMenuItem.Image")));
            this.m_deleteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.White;
            this.m_deleteToolStripMenuItem.Name = "m_deleteToolStripMenuItem";
            this.m_deleteToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.m_deleteToolStripMenuItem.Text = "Supprimer";
            this.m_deleteToolStripMenuItem.Click += new System.EventHandler(this.m_deleteToolStripMenuItem_Click);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_panelPeriode);
            this.c2iPanel1.Controls.Add(this.m_panelImpression);
            this.c2iPanel1.Controls.Add(this.m_panelNavigate);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel1, "");
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(783, 75);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 4008;
            // 
            // m_panelPeriode
            // 
            this.m_panelPeriode.Controls.Add(this.label4);
            this.m_panelPeriode.Controls.Add(this.label5);
            this.m_panelPeriode.Controls.Add(this.m_wndDateDebut);
            this.m_panelPeriode.Controls.Add(this.m_lnkApplyDates);
            this.m_panelPeriode.Controls.Add(this.label6);
            this.m_panelPeriode.Controls.Add(this.m_wndDateFin);
            this.m_panelPeriode.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelPeriode, "");
            this.m_panelPeriode.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPeriode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelPeriode, "");
            this.m_panelPeriode.Name = "m_panelPeriode";
            this.m_panelPeriode.Size = new System.Drawing.Size(535, 53);
            this.m_extStyle.SetStyleBackColor(this.m_panelPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPeriode.TabIndex = 4008;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(3, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4005;
            this.label4.Text = "Display period|1444";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(3, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 18);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4005;
            this.label5.Text = "From|2";
            // 
            // m_wndDateDebut
            // 
            this.m_wndDateDebut.CustomFormat = "d";
            this.m_wndDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_wndDateDebut, "");
            this.m_wndDateDebut.Location = new System.Drawing.Point(54, 19);
            this.m_wndDateDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndDateDebut, "");
            this.m_wndDateDebut.Name = "m_wndDateDebut";
            this.m_wndDateDebut.Size = new System.Drawing.Size(96, 21);
            this.m_extStyle.SetStyleBackColor(this.m_wndDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndDateDebut.TabIndex = 4006;
            this.m_wndDateDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            this.m_wndDateDebut.ValueChanged += new System.EventHandler(this.m_wndDate_ValueChanged);
            // 
            // m_lnkApplyDates
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkApplyDates, "");
            this.m_lnkApplyDates.Location = new System.Drawing.Point(292, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkApplyDates, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkApplyDates, "");
            this.m_lnkApplyDates.Name = "m_lnkApplyDates";
            this.m_lnkApplyDates.Size = new System.Drawing.Size(108, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkApplyDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkApplyDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkApplyDates.TabIndex = 4007;
            this.m_lnkApplyDates.TabStop = true;
            this.m_lnkApplyDates.Text = "Apply Dates|545";
            this.m_lnkApplyDates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkApplyDates_LinkClicked);
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(154, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 18);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4005;
            this.label6.Text = "To|3";
            // 
            // m_wndDateFin
            // 
            this.m_wndDateFin.CustomFormat = "d";
            this.m_wndDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_wndDateFin, "");
            this.m_wndDateFin.Location = new System.Drawing.Point(191, 19);
            this.m_wndDateFin.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndDateFin, "");
            this.m_wndDateFin.Name = "m_wndDateFin";
            this.m_wndDateFin.Size = new System.Drawing.Size(96, 21);
            this.m_extStyle.SetStyleBackColor(this.m_wndDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndDateFin.TabIndex = 4006;
            this.m_wndDateFin.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            this.m_wndDateFin.ValueChanged += new System.EventHandler(this.m_wndDate_ValueChanged);
            // 
            // m_panelImpression
            // 
            this.m_panelImpression.Controls.Add(this.m_lnkExport);
            this.m_panelImpression.Controls.Add(this.m_lnkPrintPreview);
            this.m_panelImpression.Controls.Add(this.m_lnkPrint);
            this.m_panelImpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelImpression, "");
            this.m_panelImpression.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelImpression, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelImpression, "");
            this.m_panelImpression.Name = "m_panelImpression";
            this.m_panelImpression.Size = new System.Drawing.Size(783, 53);
            this.m_extStyle.SetStyleBackColor(this.m_panelImpression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelImpression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelImpression.TabIndex = 4009;
            // 
            // m_lnkExport
            // 
            this.m_lnkExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkExport, "");
            this.m_lnkExport.Location = new System.Drawing.Point(710, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkExport, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkExport, "");
            this.m_lnkExport.Name = "m_lnkExport";
            this.m_lnkExport.Size = new System.Drawing.Size(68, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkExport, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkExport.TabIndex = 4008;
            this.m_lnkExport.TabStop = true;
            this.m_lnkExport.Text = "Export|30220";
            this.m_lnkExport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkExport_LinkClicked);
            // 
            // m_lnkPrintPreview
            // 
            this.m_lnkPrintPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkPrintPreview, "");
            this.m_lnkPrintPreview.Location = new System.Drawing.Point(541, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPrintPreview, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPrintPreview, "");
            this.m_lnkPrintPreview.Name = "m_lnkPrintPreview";
            this.m_lnkPrintPreview.Size = new System.Drawing.Size(136, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPrintPreview, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPrintPreview, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPrintPreview.TabIndex = 4007;
            this.m_lnkPrintPreview.TabStop = true;
            this.m_lnkPrintPreview.Text = "Print Preview...|10001";
            this.m_lnkPrintPreview.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPrintPreview_LinkClicked);
            // 
            // m_lnkPrint
            // 
            this.m_lnkPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkPrint, "");
            this.m_lnkPrint.Location = new System.Drawing.Point(541, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPrint, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPrint, "");
            this.m_lnkPrint.Name = "m_lnkPrint";
            this.m_lnkPrint.Size = new System.Drawing.Size(116, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPrint, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPrint, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPrint.TabIndex = 4007;
            this.m_lnkPrint.TabStop = true;
            this.m_lnkPrint.Text = "Print...|10002";
            this.m_lnkPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPrint_LinkClicked);
            // 
            // m_panelNavigate
            // 
            this.m_panelNavigate.Controls.Add(this.m_lnkDisplayNextDay);
            this.m_panelNavigate.Controls.Add(this.m_lnkDisplayPreviousDay);
            this.m_panelNavigate.Controls.Add(this.m_lnkDisplayPreviousPeriod);
            this.m_panelNavigate.Controls.Add(this.m_lnkDisplayNextPeriod);
            this.m_panelNavigate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.m_panelNavigate, "");
            this.m_panelNavigate.Location = new System.Drawing.Point(0, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelNavigate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelNavigate, "");
            this.m_panelNavigate.Name = "m_panelNavigate";
            this.m_panelNavigate.Size = new System.Drawing.Size(783, 22);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelNavigate.TabIndex = 4010;
            // 
            // m_lnkDisplayNextDay
            // 
            this.m_lnkDisplayNextDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkDisplayNextDay, "");
            this.m_lnkDisplayNextDay.Location = new System.Drawing.Point(729, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDisplayNextDay, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDisplayNextDay, "");
            this.m_lnkDisplayNextDay.Name = "m_lnkDisplayNextDay";
            this.m_lnkDisplayNextDay.Size = new System.Drawing.Size(16, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDisplayNextDay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDisplayNextDay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDisplayNextDay.TabIndex = 4008;
            this.m_lnkDisplayNextDay.TabStop = true;
            this.m_lnkDisplayNextDay.Text = ">";
            this.m_toolTipTraductible.SetToolTip(this.m_lnkDisplayNextDay, "Display next day|1448");
            this.m_lnkDisplayNextDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDisplayNextDay_LinkClicked);
            // 
            // m_lnkDisplayPreviousDay
            // 
            this.m_lnkDisplayPreviousDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_lnkDisplayPreviousDay, "");
            this.m_lnkDisplayPreviousDay.Location = new System.Drawing.Point(32, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDisplayPreviousDay, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDisplayPreviousDay, "");
            this.m_lnkDisplayPreviousDay.Name = "m_lnkDisplayPreviousDay";
            this.m_lnkDisplayPreviousDay.Size = new System.Drawing.Size(26, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDisplayPreviousDay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDisplayPreviousDay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDisplayPreviousDay.TabIndex = 4008;
            this.m_lnkDisplayPreviousDay.TabStop = true;
            this.m_lnkDisplayPreviousDay.Text = "<";
            this.m_toolTipTraductible.SetToolTip(this.m_lnkDisplayPreviousDay, "Display previous day|1447");
            this.m_lnkDisplayPreviousDay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDisplayPreviousDay_LinkClicked);
            // 
            // m_lnkDisplayPreviousPeriod
            // 
            this.m_lnkDisplayPreviousPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_lnkDisplayPreviousPeriod, "");
            this.m_lnkDisplayPreviousPeriod.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDisplayPreviousPeriod, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDisplayPreviousPeriod, "");
            this.m_lnkDisplayPreviousPeriod.Name = "m_lnkDisplayPreviousPeriod";
            this.m_lnkDisplayPreviousPeriod.Size = new System.Drawing.Size(26, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDisplayPreviousPeriod, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDisplayPreviousPeriod, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDisplayPreviousPeriod.TabIndex = 4008;
            this.m_lnkDisplayPreviousPeriod.TabStop = true;
            this.m_lnkDisplayPreviousPeriod.Text = "<<";
            this.m_toolTipTraductible.SetToolTip(this.m_lnkDisplayPreviousPeriod, "Display prvious period|1446");
            this.m_lnkDisplayPreviousPeriod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDisplayPreviousPeriod_LinkClicked);
            // 
            // m_lnkDisplayNextPeriod
            // 
            this.m_lnkDisplayNextPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkDisplayNextPeriod, "");
            this.m_lnkDisplayNextPeriod.Location = new System.Drawing.Point(752, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDisplayNextPeriod, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDisplayNextPeriod, "");
            this.m_lnkDisplayNextPeriod.Name = "m_lnkDisplayNextPeriod";
            this.m_lnkDisplayNextPeriod.Size = new System.Drawing.Size(26, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDisplayNextPeriod, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDisplayNextPeriod, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDisplayNextPeriod.TabIndex = 4007;
            this.m_lnkDisplayNextPeriod.TabStop = true;
            this.m_lnkDisplayNextPeriod.Text = ">>";
            this.m_toolTipTraductible.SetToolTip(this.m_lnkDisplayNextPeriod, "Display next period|1445");
            this.m_lnkDisplayNextPeriod.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDisplayNextPeriod_LinkClicked);
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "");
            this.c2iTextBox1.Location = new System.Drawing.Point(93, -58);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(240, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 1;
            this.c2iTextBox1.Text = "[Label]|30324";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, -55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Label|50";
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 114;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TrancheHoraire.HeureDebutString";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Start time|401";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "TrancheHoraire.HeureFinString";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "End time|402";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // m_colJoursSemaine
            // 
            this.m_colJoursSemaine.Field = "";
            this.m_colJoursSemaine.PrecisionWidth = 0;
            this.m_colJoursSemaine.ProportionnalSize = false;
            this.m_colJoursSemaine.Visible = true;
            this.m_colJoursSemaine.Width = 120;
            // 
            // m_printDocument
            // 
            this.m_printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_printDocument_PrintPage);
            // 
            // CFormEditionInstanceTableauPlanning
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(807, 535);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionInstanceTableauPlanning";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre2, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageTableau.ResumeLayout(false);
            this.m_tabPageTableau.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_tableauPlanningView)).EndInit();
            this.m_contextMenuDGV.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.m_panelPeriode.ResumeLayout(false);
            this.m_panelImpression.ResumeLayout(false);
            this.m_panelNavigate.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		//-------------------------------------------------------------------------
		private CTypeTableauPlanning TypeTableauPlanning
		{
			get
			{ 
				return (CTypeTableauPlanning)ObjetEdite;
			}
		}
		
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

            m_wndDateDebut.Value = m_lastDateDebut;
            m_wndDateFin.Value = m_lastDateFin;
                        
            m_tableauPlanningView.AutoGenerateColumns = false;
            m_tableauPlanningView.ReadOnly = !m_gestionnaireModeEdition.ModeEdition;
            
            
            if(TypeTableauPlanning.FiltreDynamiqueElementsData != null)
            {
                CFiltreData filtre = (CFiltreData)TypeTableauPlanning.FiltreDynamiqueElementsData.GetFiltreData().Data;
                if (filtre != null)
                    m_tableauPlanningView.Tag = filtre;
                else
                    m_tableauPlanningView.Tag = null;
            }

            m_instanceTableauPlanning = new CInstanceTableauPlanning(TypeTableauPlanning);
            result = RemplirGrille();

            m_copyToolStripMenuItem.Enabled = m_gestionnaireModeEdition.ModeEdition;
            m_pastToolStripMenuItem.Enabled = m_bSomethingToPast && m_gestionnaireModeEdition.ModeEdition;
            m_deleteToolStripMenuItem.Enabled = m_gestionnaireModeEdition.ModeEdition;
            
           
			return result;
		}

 
        //-------------------------------------------------------------------------
        private CResultAErreur RemplirGrille()
        {
            CResultAErreur result = CResultAErreur.True;
            result = m_instanceTableauPlanning.InitializeData(m_wndDateDebut.Value.Date, m_wndDateFin.Value.Date);

            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return result;
            }

            DataTable dataTable = m_instanceTableauPlanning.GetDataTable();

            m_tableauPlanningView.Columns.Clear();

            foreach (DataColumn colonne in dataTable.Columns)
            {
                if (colonne.DataType == typeof(string))
                {
                    DataGridViewColumn colEO = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    colEO.DataPropertyName = colonne.ColumnName;
                    colEO.Name = colonne.ColumnName;
                    colEO.HeaderText = colonne.ColumnName;
                    colEO.ReadOnly = true;
                    m_tableauPlanningView.Columns.Add(colEO);
                }
                else
                {
                    DataGridViewColumn colActeur = new DataGridViewColumn(new CTableauPlanningCell());
                    colActeur.DataPropertyName = colonne.ColumnName;
                    colActeur.Name = colonne.ColumnName;
                    colActeur.HeaderText = colonne.ColumnName;
                    colActeur.SortMode = DataGridViewColumnSortMode.NotSortable;
                    colActeur.DefaultCellStyle.BackColor = (Color) colonne.ExtendedProperties[CInstanceTableauPlanning.c_strCouleurPourColonne];

                    m_tableauPlanningView.Columns.Add(colActeur);
                }
            }

            m_tableauPlanningView.DataSource = dataTable;

            return result;

        }


		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;

            result = m_instanceTableauPlanning.SetDataTable((DataTable) m_tableauPlanningView.DataSource);
 
			return result;
		}




        //----------------------------------------------------------------------------
        private void m_lnkApplyDates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppliquerDates();
        }

        //----------------------------------------------------------------------------
        private void AppliquerDates()
        {
            MAJ_Champs();
            m_lnkApplyDates.Enabled = false;
            m_lastDateDebut = m_wndDateDebut.Value.Date;
            m_lastDateFin = m_wndDateFin.Value.Date;
            RemplirGrille();
        }

        //----------------------------------------------------------------------------
        private void m_lnkPrintPreview_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog dlgPrintPreview = new PrintPreviewDialog();
                dlgPrintPreview.Document = m_printDocument;
                dlgPrintPreview.ShowDialog();
            }
        }

        //----------------------------------------------------------------------------
        private void m_lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SetupThePrinting())
                m_printDocument.Print();
        }

        //--------------------------------------------------------------------------- 
        void m_printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            bool more = m_dataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }


        //--------------------------------------------------------------------------- 
        /// <summary>
        /// The printing setup function        
        /// </summary>
        /// <returns></returns>
        private bool SetupThePrinting()
        {
            PrintDialog dlgPrint = new PrintDialog();
            dlgPrint.AllowCurrentPage = false;
            dlgPrint.AllowPrintToFile = false;
            dlgPrint.AllowSelection = false;
            dlgPrint.AllowSomePages = false;
            dlgPrint.PrintToFile = false;
            dlgPrint.ShowHelp = false;
            dlgPrint.ShowNetwork = false;

            if (dlgPrint.ShowDialog() != DialogResult.OK)
                return false;

            m_printDocument.DocumentName = TypeTableauPlanning.Libelle;
            m_printDocument.PrinterSettings =
                                dlgPrint.PrinterSettings;
            m_printDocument.DefaultPageSettings =
            dlgPrint.PrinterSettings.DefaultPageSettings;
            m_printDocument.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);

            if (CFormAlerte.Afficher(I.T("Do you want the report to be centered on the page|30221"),
                EFormAlerteType.Question) == DialogResult.Yes)
            {
                m_dataGridViewPrinter = new DataGridViewPrinter(
                    m_tableauPlanningView,
                    m_printDocument, 
                    true, 
                    true,
                    TypeTableauPlanning.Libelle,
                    new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point),
                    Color.Black, 
                    true);
            }
            else
            {
                m_dataGridViewPrinter = new DataGridViewPrinter(
                    m_tableauPlanningView,
                    m_printDocument,
                    false,
                    true,
                    TypeTableauPlanning.Libelle, new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), 
                    Color.Black, 
                    true);
            }
            return true;
        }

        //-------------------------------------------------------------------------------
        private void m_wndDate_ValueChanged(object sender, EventArgs e)
        {
            m_lnkApplyDates.Enabled = true;
        }

        //-------------------------------------------------------------------------------
        private void m_lnkDisplayPreviousPeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TimeSpan ts = m_wndDateFin.Value.Date - m_wndDateDebut.Value.Date;
            m_wndDateDebut.Value = m_lastDateDebut.AddDays(-ts.Days);
            m_wndDateFin.Value = m_lastDateFin.AddDays(-ts.Days);
            AppliquerDates();
        }

        //-------------------------------------------------------------------------------
        private void m_lnkDisplayNextPeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TimeSpan ts = m_wndDateFin.Value.Date - m_wndDateDebut.Value.Date;
            m_wndDateDebut.Value = m_lastDateDebut.AddDays(ts.Days);
            m_wndDateFin.Value = m_lastDateFin.AddDays(ts.Days);
            AppliquerDates();
        }
        
        //-------------------------------------------------------------------------------
        private void m_lnkDisplayPreviousDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_wndDateDebut.Value = m_lastDateDebut.AddDays(-1);
            m_wndDateFin.Value = m_lastDateFin.AddDays(-1);
            AppliquerDates();
        }

        //-------------------------------------------------------------------------------
        private void m_lnkDisplayNextDay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_wndDateDebut.Value = m_lastDateDebut.AddDays(1);
            m_wndDateFin.Value = m_lastDateFin.AddDays(1);
            AppliquerDates();
        }

        //-------------------------------------------------------------------------------
        private void m_copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FonctionCopier();
        }

        //---------------------------------------------------------------------------------
        private void FonctionCopier()
        {
            if (CanCopy())
            {
                // Copier ici
                CDataPlanning donnee = null;
                m_pressePapiers.Clear();
                foreach (DataGridViewCell cellule in m_tableauPlanningView.SelectedCells)
                {
                    CPressePapierCellule pressePapierCellule = null;
                    donnee = null;
                    if (cellule is CTableauPlanningCell)
                    {
                        if (cellule.Value != DBNull.Value)
                        {
                            donnee = (CDataPlanning)((CTableauPlanningCell)cellule).Value;

                            if (donnee != null)
                            {
                                pressePapierCellule = new CPressePapierCellule(
                                    donnee.TypeElement,
                                    donnee.Element != null ? donnee.Element.Id : -1,
                                    cellule.RowIndex - m_nPlusPetitRowIndex,
                                    cellule.ColumnIndex - m_nPlusPetitColumnIndex);
                            }
                        }
                        else
                        {
                            pressePapierCellule = new CPressePapierCellule(
                                null,
                                -1,
                                cellule.RowIndex - m_nPlusPetitRowIndex,
                                cellule.ColumnIndex - m_nPlusPetitColumnIndex);
                        }
                        if (pressePapierCellule != null)
                            m_pressePapiers.Add(pressePapierCellule);

                    }
                }

                if (m_pressePapiers.Count > 0)
                {
                    m_bSomethingToPast = true;
                    m_pastToolStripMenuItem.Enabled = true;
                }
            }
        }

        //-------------------------------------------------------------------------------
        private void m_pastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FonctionColler();
        }

        //-------------------------------------------------------------------------------
        private void FonctionColler()
        {
            if (CanPast() && m_bSomethingToPast)
            {
                // Coller ici
                if (m_cellulePivot != null)
                {
                    int n = m_cellulePivot.RowIndex;
                    int m = m_cellulePivot.ColumnIndex;
                    foreach (CPressePapierCellule pressePapierCellule in m_pressePapiers)
                    {
                        DataGridViewCell cellule = m_tableauPlanningView.Rows[n + pressePapierCellule.IndexRelatifLigne].Cells[m + pressePapierCellule.IndexRelatifColonne];
                        if (cellule is CTableauPlanningCell)
                        {
                            ((CTableauPlanningCell)cellule).Value =
                                new CDataPlanning(
                                pressePapierCellule.TypeElement,
                                pressePapierCellule.IdElement,
                                TypeTableauPlanning.ContexteDonnee);
                        }
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------
        private bool CanCopy()
        {
            if (!VerifieLaSelection(true))
            {
                CFormAlerte.Afficher(I.T("Invalid selection|10003"), EFormAlerteType.Erreur);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------------
        private bool CanPast()
        {
            if (VerifieLaSelection(false) && m_cellulePivot != null)
            {
                if (m_nHauteurDuBlocAColler > 0 && m_nLargeurDuBlocAColler > 0)
                {
                    // Est-ce qu'on a la place de tout coller
                    if (m_tableauPlanningView.Rows.Count - m_cellulePivot.RowIndex >= m_nHauteurDuBlocAColler &&
                        m_tableauPlanningView.Columns.Count - m_cellulePivot.ColumnIndex >= m_nLargeurDuBlocAColler)
                        return true;
                    else
                    {
                        CFormAlerte.Afficher(I.T("Cannot paste data because the copy area is bigger than the past area|10005"), EFormAlerteType.Exclamation);
                    }
                }
            }
            else
            {
                // Impossible de coller à cet endroit
                CFormAlerte.Afficher(I.T("Cannot paste data because the past arera is not valid|10004"), EFormAlerteType.Exclamation);
            }
            return false;
        }

        //-------------------------------------------------------------------------------
        private bool VerifieLaSelection(bool bModeCopier)
        {
            m_nPlusPetitRowIndex = 999999;
            m_nPlusPetitColumnIndex = 999999;

            int nbCell = m_tableauPlanningView.SelectedCells.Count;
            int nbCol = m_tableauPlanningView.SelectedColumns.Count;
            if (nbCell == 0)
                return false;

            foreach (DataGridViewCell cellule in m_tableauPlanningView.SelectedCells)
            {
                if (cellule.ColumnIndex == 0)
                    return false; // On ne peut pas copier dans la première colonne EO
            }
            
            if (nbCol > 0 && nbCell > m_tableauPlanningView.Rows.Count * nbCol)
            {
                // On ne peut pas sélectionner à la fois des collones et des cellules isolées
                return false;
            }

            // Vérife que le bloc sélectionné a une cellule pivot (en haut à gauche)
            // Il faut que la cell qui a le plus petit index de ligne, ai aussi le plus petit index de colonne
            for(int i=0; i< m_tableauPlanningView.SelectedCells.Count; i++)
            {
                if (m_tableauPlanningView.SelectedCells[i].RowIndex < m_nPlusPetitRowIndex)
                    m_nPlusPetitRowIndex = m_tableauPlanningView.SelectedCells[i].RowIndex;

            }
            for (int j = 0; j < m_tableauPlanningView.SelectedCells.Count; j++)
            {
                if (m_tableauPlanningView.SelectedCells[j].ColumnIndex < m_nPlusPetitColumnIndex)
                    m_nPlusPetitColumnIndex = m_tableauPlanningView.SelectedCells[j].ColumnIndex;

            }
            // Recherche de la cellule pivot de la sélection (en mode copier et en mode coller)
            foreach (DataGridViewCell cellule in m_tableauPlanningView.SelectedCells)
            {
                if (cellule.RowIndex == m_nPlusPetitRowIndex && cellule.ColumnIndex == m_nPlusPetitColumnIndex)
                {
                    // Cellule pivot trouvée
                    m_cellulePivot = cellule;
                    if (bModeCopier)
                        CalculLaTailleDuBlocAColler();
                    return true;
                }
            }
            
            return false;
        }

        //---------------------------------------------------------------
        private int m_nHauteurDuBlocAColler = 0;
        private int m_nLargeurDuBlocAColler = 0;
        private void CalculLaTailleDuBlocAColler()
        {
            int nPlusGrandRowIndex = 0;
            int nPlusGrandColumnIndex = 0;

            for (int i = 0; i < m_tableauPlanningView.SelectedCells.Count; i++)
            {
                if (m_tableauPlanningView.SelectedCells[i].RowIndex > nPlusGrandRowIndex)
                    nPlusGrandRowIndex = m_tableauPlanningView.SelectedCells[i].RowIndex;
            }
            for (int j = 0; j < m_tableauPlanningView.SelectedCells.Count; j++)
            {
                if (m_tableauPlanningView.SelectedCells[j].ColumnIndex > nPlusGrandColumnIndex)
                    nPlusGrandColumnIndex = m_tableauPlanningView.SelectedCells[j].ColumnIndex;
            }
            m_nHauteurDuBlocAColler = nPlusGrandRowIndex - m_nPlusPetitRowIndex + 1;
            m_nLargeurDuBlocAColler = nPlusGrandColumnIndex - m_nPlusPetitColumnIndex + 1;
            
        }


        //-----------------------------------------------------------------------------------------
        private void m_tableauPlanningView_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    FonctionSupprimer();
                }

                if((e.Modifiers & Keys.Control) == Keys.Control)
                {
                    if (e.KeyCode == Keys.C || e.KeyCode == Keys.Insert)
                        FonctionCopier();
                    
                    if (e.KeyCode == Keys.V)
                        FonctionColler();
                }

                if ((e.Modifiers & Keys.Shift) == Keys.Shift)
                {
                    if (e.KeyCode == Keys.Insert)
                        FonctionColler();
                }

            }
        }
        
        //------------------------------------------------------------------------
        private void m_deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FonctionSupprimer();
        }

        //--------------------------------------------------------------------------
        private void FonctionSupprimer()
        {
            // Vide les cellules sélectionnées
            foreach (DataGridViewCell cellule in m_tableauPlanningView.SelectedCells)
            {
                if (cellule is CTableauPlanningCell)
                {
                    cellule.Value = new CDataPlanning(typeof(CActeur), null);
                }
            }
        }



        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Contient les information utiles pour copier /coller une cellue
        /// </summary>
        private class CPressePapierCellule
        {
            private Type m_typeElement;
            private int m_nIdElement;
            private int m_nIndexRelatifLigne;
            private int m_nIndexRelatifColonne;
      

            public CPressePapierCellule(Type typeElement, int nIdElement, int nIndexRelatifLigne, int nIndexRelatifColonne)
            {
                m_typeElement = typeElement;
                m_nIdElement = nIdElement;
                m_nIndexRelatifLigne = nIndexRelatifLigne;
                m_nIndexRelatifColonne = nIndexRelatifColonne;
            }

            //---------------------------------------------
            public Type TypeElement
            {
                get
                {
                    return m_typeElement;
                }
            }

            //---------------------------------------------
            public int IdElement
            {
                get
                {
                    return m_nIdElement;
                }
            }

            //---------------------------------------------
            public int IndexRelatifLigne
            {
                get
                {
                    return m_nIndexRelatifLigne;
                }
            }

            //---------------------------------------------
            public int IndexRelatifColonne
            {
                get
                {
                    return m_nIndexRelatifColonne;
                }
            }

        }

        //-------------------------------------------------------
        private void m_lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            DataSet ds = null;
            DataTable dtExport = new DataTable();
            DataTable dtSource = (DataTable)m_tableauPlanningView.DataSource;

            for (int j = 0; j < dtSource.Columns.Count; j++)
            {
                dtExport.Columns.Add(dtSource.Columns[j].ColumnName);
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                dtExport.Rows.Add( dtExport.NewRow());
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    if (dtSource.Rows[i][j] is CDataPlanning)
                    {
                        CDataPlanning data = (CDataPlanning)dtSource.Rows[i][j];
                        if(data.Element != null)
                            dtExport.Rows[i][j] = data.Element.Libelle;
                    }
                    else
                    {
                        if (dtSource.Rows[i][j] is string)
                            dtExport.Rows[i][j] = (string)dtSource.Rows[i][j];
                    }
                }
            }
                

            if(dtExport.DataSet == null)
            {
                ds = new DataSet();
                ds.Tables.Add(dtExport);
            }
            IExporteurDataset exporteur = null;
            IDestinationExport destination = null;
            if (CFormOptionsExport.EditeOptions(ref destination, ref exporteur))
            {
                if (exporteur != null)
                {
                    CResultAErreur result = exporteur.Export(dtExport.DataSet, destination);
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                        return;
                    }
                    else
                    {
                        CFormAlerte.Afficher(I.T("Export finished|30222"));
                    }
                }
            }
        }
	}
}

