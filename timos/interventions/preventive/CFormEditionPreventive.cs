using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using System.Globalization;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.acteurs;
using timos.data;
using timos.data.preventives;
using timos.Properties;

namespace timos.preventives
{
	public class CFormEditionPreventive : CFormMaxiSansMenu, IFormNavigable
	{
		#region Designer generated code
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private System.Windows.Forms.Label lbl_contrat;
		private sc2i.win32.common.C2iPanelOmbre m_panGeneral;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private C2iTextBoxSelectionne m_txtSelectContrat;
		private Label m_lblListeOpToAdd;
		private CComboBoxLinkListeObjetsDonnees m_cmbLstOp;
		private Label m_lblObjectif;
		private Label m_lblErrorDate;
		private DataGridView m_dgv;
		private LinkLabel m_lnkOpsAffichees;
		private Button m_btnEditerObjet;
		private Button m_btnValiderModifications;
		private Button m_btnAnnulerModifications;
		private LinkLabel m_lnkListeSites;
		private Button m_btnActualiser;
		private CControleDecoupage m_ctrlDecoupage;
		internal CheckBox m_chkSites;
		private ContextMenuStrip m_ctxInters;
		private LinkLabel m_lnkContrat;
		private LinkLabel m_lnkFormatDates;
		private ToolTip m_ttDessin;
		private ToolStripMenuItem ajouterUneInterventionsPourChaqueSitesToolStripMenuItem;
		private ToolStripMenuItem supprimerLesInterventionsPourChaqueSitesToolStripMenuItem;
		private Button m_btnLast;
		private Button m_btnNext;
		private CheckBox m_chkListeOp;
		private ToolStripMenuItem supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem;
		private Label m_lblSites;
		private CheckBox m_chkKeepCuting;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionPreventive));
            this.lbl_contrat = new System.Windows.Forms.Label();
            this.m_panGeneral = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectContrat = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkContrat = new System.Windows.Forms.LinkLabel();
            this.m_dgv = new System.Windows.Forms.DataGridView();
            this.m_btnLast = new System.Windows.Forms.Button();
            this.m_lblSites = new System.Windows.Forms.Label();
            this.m_btnNext = new System.Windows.Forms.Button();
            this.m_btnActualiser = new System.Windows.Forms.Button();
            this.m_lblObjectif = new System.Windows.Forms.Label();
            this.m_lnkListeSites = new System.Windows.Forms.LinkLabel();
            this.m_cmbLstOp = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_chkSites = new System.Windows.Forms.CheckBox();
            this.m_lnkFormatDates = new System.Windows.Forms.LinkLabel();
            this.m_lblErrorDate = new System.Windows.Forms.Label();
            this.m_lnkOpsAffichees = new System.Windows.Forms.LinkLabel();
            this.m_lblListeOpToAdd = new System.Windows.Forms.Label();
            this.m_chkListeOp = new System.Windows.Forms.CheckBox();
            this.m_ctrlDecoupage = new timos.preventives.CControleDecoupage();
            this.m_chkKeepCuting = new System.Windows.Forms.CheckBox();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_btnValiderModifications = new System.Windows.Forms.Button();
            this.m_btnEditerObjet = new System.Windows.Forms.Button();
            this.m_btnAnnulerModifications = new System.Windows.Forms.Button();
            this.m_ctxInters = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_ttDessin = new System.Windows.Forms.ToolTip(this.components);
            this.m_panGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv)).BeginInit();
            this.m_ctxInters.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_contrat
            // 
            this.m_extLinkField.SetLinkField(this.lbl_contrat, "");
            this.lbl_contrat.Location = new System.Drawing.Point(37, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_contrat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_contrat.Name = "lbl_contrat";
            this.lbl_contrat.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_contrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_contrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_contrat.TabIndex = 4002;
            this.lbl_contrat.Text = "Contract label|560";
            this.lbl_contrat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_panGeneral
            // 
            this.m_panGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panGeneral.Controls.Add(this.m_txtSelectContrat);
            this.m_panGeneral.Controls.Add(this.m_lnkContrat);
            this.m_panGeneral.Controls.Add(this.m_dgv);
            this.m_panGeneral.Controls.Add(this.m_btnLast);
            this.m_panGeneral.Controls.Add(this.lbl_contrat);
            this.m_panGeneral.Controls.Add(this.m_lblSites);
            this.m_panGeneral.Controls.Add(this.m_btnNext);
            this.m_panGeneral.Controls.Add(this.m_btnActualiser);
            this.m_panGeneral.Controls.Add(this.m_lblObjectif);
            this.m_panGeneral.Controls.Add(this.m_lnkListeSites);
            this.m_panGeneral.Controls.Add(this.m_cmbLstOp);
            this.m_panGeneral.Controls.Add(this.m_chkSites);
            this.m_panGeneral.Controls.Add(this.m_lnkFormatDates);
            this.m_panGeneral.Controls.Add(this.m_lblErrorDate);
            this.m_panGeneral.Controls.Add(this.m_lnkOpsAffichees);
            this.m_panGeneral.Controls.Add(this.m_lblListeOpToAdd);
            this.m_panGeneral.Controls.Add(this.m_chkListeOp);
            this.m_panGeneral.Controls.Add(this.m_ctrlDecoupage);
            this.m_panGeneral.Controls.Add(this.m_chkKeepCuting);
            this.m_panGeneral.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panGeneral, "");
            this.m_panGeneral.Location = new System.Drawing.Point(29, 44);
            this.m_panGeneral.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGeneral, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panGeneral.Name = "m_panGeneral";
            this.m_panGeneral.Size = new System.Drawing.Size(801, 486);
            this.m_extStyle.SetStyleBackColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGeneral, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneral.TabIndex = 0;
            // 
            // m_txtSelectContrat
            // 
            this.m_txtSelectContrat.ElementSelectionne = null;
            this.m_txtSelectContrat.FonctionTextNull = null;
            this.m_txtSelectContrat.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectContrat, "");
            this.m_txtSelectContrat.Location = new System.Drawing.Point(152, 7);
            this.m_txtSelectContrat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectContrat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtSelectContrat.Name = "m_txtSelectContrat";
            this.m_txtSelectContrat.SelectedObject = null;
            this.m_txtSelectContrat.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectContrat.TabIndex = 4004;
            this.m_txtSelectContrat.TextNull = "";
            this.m_txtSelectContrat.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectContrat_ElementSelectionneChanged);
            // 
            // m_lnkContrat
            // 
            this.m_lnkContrat.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkContrat, "");
            this.m_lnkContrat.Location = new System.Drawing.Point(410, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkContrat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkContrat.Name = "m_lnkContrat";
            this.m_lnkContrat.Size = new System.Drawing.Size(129, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkContrat.TabIndex = 4018;
            this.m_lnkContrat.TabStop = true;
            this.m_lnkContrat.Text = "Show the contract...|1314";
            this.m_lnkContrat.Visible = false;
            this.m_lnkContrat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkContrat_LinkClicked);
            // 
            // m_dgv
            // 
            this.m_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_extLinkField.SetLinkField(this.m_dgv, "");
            this.m_dgv.Location = new System.Drawing.Point(6, 151);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dgv, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_dgv.Name = "m_dgv";
            this.m_dgv.Size = new System.Drawing.Size(771, 308);
            this.m_extStyle.SetStyleBackColor(this.m_dgv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dgv, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dgv.TabIndex = 4017;
            this.m_ttDessin.SetToolTip(this.m_dgv, "Toto aime les bananes");
            this.m_dgv.Visible = false;
            this.m_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dgv_CellDoubleClick);
            this.m_dgv.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgv_ColumnHeaderMouseClick);
            this.m_dgv.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_dgv_CellPainting);
            this.m_dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_dgv_CellMouseClick);
            this.m_dgv.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.m_dgv_CellToolTipTextNeeded);
            // 
            // m_btnLast
            // 
            this.m_btnLast.BackColor = System.Drawing.Color.Tan;
            this.m_btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkField.SetLinkField(this.m_btnLast, "");
            this.m_btnLast.Location = new System.Drawing.Point(6, 129);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnLast, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnLast.Name = "m_btnLast";
            this.m_btnLast.Size = new System.Drawing.Size(25, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnLast, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnLast, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnLast.TabIndex = 4022;
            this.m_btnLast.Text = "<";
            this.m_btnLast.UseVisualStyleBackColor = false;
            this.m_btnLast.Visible = false;
            this.m_btnLast.Click += new System.EventHandler(this.m_btnLast_Click);
            // 
            // m_lblSites
            // 
            this.m_lblSites.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblSites, "");
            this.m_lblSites.Location = new System.Drawing.Point(410, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblSites.Name = "m_lblSites";
            this.m_lblSites.Size = new System.Drawing.Size(0, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSites.TabIndex = 4014;
            this.m_lblSites.Visible = false;
            // 
            // m_btnNext
            // 
            this.m_btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnNext.BackColor = System.Drawing.Color.Tan;
            this.m_btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkField.SetLinkField(this.m_btnNext, "");
            this.m_btnNext.Location = new System.Drawing.Point(752, 129);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNext, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnNext.Name = "m_btnNext";
            this.m_btnNext.Size = new System.Drawing.Size(25, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnNext, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNext, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNext.TabIndex = 4022;
            this.m_btnNext.Text = ">";
            this.m_btnNext.UseVisualStyleBackColor = false;
            this.m_btnNext.Visible = false;
            this.m_btnNext.Click += new System.EventHandler(this.m_btnNext_Click);
            // 
            // m_btnActualiser
            // 
            this.m_btnActualiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnActualiser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.m_btnActualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkField.SetLinkField(this.m_btnActualiser, "");
            this.m_btnActualiser.Location = new System.Drawing.Point(674, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnActualiser, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnActualiser.Name = "m_btnActualiser";
            this.m_btnActualiser.Size = new System.Drawing.Size(103, 48);
            this.m_extStyle.SetStyleBackColor(this.m_btnActualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnActualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnActualiser.TabIndex = 4019;
            this.m_btnActualiser.Text = "Refresh|38";
            this.m_btnActualiser.UseVisualStyleBackColor = false;
            this.m_btnActualiser.Visible = false;
            this.m_btnActualiser.Click += new System.EventHandler(this.m_btnActualiser_Click);
            // 
            // m_lblObjectif
            // 
            this.m_lblObjectif.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblObjectif, "");
            this.m_lblObjectif.Location = new System.Drawing.Point(410, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblObjectif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblObjectif.Name = "m_lblObjectif";
            this.m_lblObjectif.Size = new System.Drawing.Size(86, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblObjectif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblObjectif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblObjectif.TabIndex = 4014;
            this.m_lblObjectif.Text = "Targets :|1300";
            this.m_lblObjectif.Visible = false;
            // 
            // m_lnkListeSites
            // 
            this.m_lnkListeSites.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkListeSites, "");
            this.m_lnkListeSites.Location = new System.Drawing.Point(149, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkListeSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkListeSites.Name = "m_lnkListeSites";
            this.m_lnkListeSites.Size = new System.Drawing.Size(143, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkListeSites.TabIndex = 4018;
            this.m_lnkListeSites.TabStop = true;
            this.m_lnkListeSites.Text = "List of Sites to display...|1301";
            this.m_lnkListeSites.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkListeSites_LinkClicked);
            // 
            // m_cmbLstOp
            // 
            this.m_cmbLstOp.ComportementLinkStd = true;
            this.m_cmbLstOp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbLstOp.ElementSelectionne = null;
            this.m_cmbLstOp.FormattingEnabled = true;
            this.m_cmbLstOp.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbLstOp, "");
            this.m_cmbLstOp.LinkProperty = "";
            this.m_cmbLstOp.ListDonnees = null;
            this.m_cmbLstOp.Location = new System.Drawing.Point(152, 31);
            this.m_cmbLstOp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbLstOp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_cmbLstOp.Name = "m_cmbLstOp";
            this.m_cmbLstOp.NullAutorise = false;
            this.m_cmbLstOp.ProprieteAffichee = null;
            this.m_cmbLstOp.ProprieteParentListeObjets = null;
            this.m_cmbLstOp.SelectionneurParent = null;
            this.m_cmbLstOp.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbLstOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbLstOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbLstOp.TabIndex = 4013;
            this.m_cmbLstOp.TextNull = I.T("(empty)|30195");
            this.m_cmbLstOp.Tri = true;
            this.m_cmbLstOp.TypeFormEdition = null;
            this.m_cmbLstOp.SelectionChangeCommitted += new System.EventHandler(this.m_cmbLstOp_SelectionChangeCommitted);
            // 
            // m_chkSites
            // 
            this.m_chkSites.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSites, "");
            this.m_chkSites.Location = new System.Drawing.Point(316, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkSites.Name = "m_chkSites";
            this.m_chkSites.Size = new System.Drawing.Size(152, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSites.TabIndex = 4021;
            this.m_chkSites.Text = "Concerned Sites only|1303";
            this.m_chkSites.UseVisualStyleBackColor = true;
            this.m_chkSites.CheckedChanged += new System.EventHandler(this.m_chkSites_CheckedChanged);
            // 
            // m_lnkFormatDates
            // 
            this.m_lnkFormatDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkFormatDates.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkFormatDates, "");
            this.m_lnkFormatDates.Location = new System.Drawing.Point(149, 86);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFormatDates, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkFormatDates.Name = "m_lnkFormatDates";
            this.m_lnkFormatDates.Size = new System.Drawing.Size(97, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFormatDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFormatDates, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFormatDates.TabIndex = 4018;
            this.m_lnkFormatDates.TabStop = true;
            this.m_lnkFormatDates.Text = "Date format...|1323";
            this.m_lnkFormatDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_lnkFormatDates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFormatDates_LinkClicked);
            // 
            // m_lblErrorDate
            // 
            this.m_lblErrorDate.AutoSize = true;
            this.m_lblErrorDate.ForeColor = System.Drawing.Color.Brown;
            this.m_extLinkField.SetLinkField(this.m_lblErrorDate, "");
            this.m_lblErrorDate.Location = new System.Drawing.Point(3, 108);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblErrorDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblErrorDate.Name = "m_lblErrorDate";
            this.m_lblErrorDate.Size = new System.Drawing.Size(86, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblErrorDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblErrorDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblErrorDate.TabIndex = 4016;
            this.m_lblErrorDate.Text = "Date Errors|1298";
            this.m_lblErrorDate.Visible = false;
            // 
            // m_lnkOpsAffichees
            // 
            this.m_lnkOpsAffichees.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkOpsAffichees, "");
            this.m_lnkOpsAffichees.Location = new System.Drawing.Point(149, 70);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkOpsAffichees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkOpsAffichees.Name = "m_lnkOpsAffichees";
            this.m_lnkOpsAffichees.Size = new System.Drawing.Size(154, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkOpsAffichees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkOpsAffichees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkOpsAffichees.TabIndex = 4018;
            this.m_lnkOpsAffichees.TabStop = true;
            this.m_lnkOpsAffichees.Text = "Operation List to display...|1302";
            this.m_lnkOpsAffichees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkOpsAffichees_LinkClicked);
            // 
            // m_lblListeOpToAdd
            // 
            this.m_extLinkField.SetLinkField(this.m_lblListeOpToAdd, "");
            this.m_lblListeOpToAdd.Location = new System.Drawing.Point(6, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblListeOpToAdd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblListeOpToAdd.Name = "m_lblListeOpToAdd";
            this.m_lblListeOpToAdd.Size = new System.Drawing.Size(143, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblListeOpToAdd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblListeOpToAdd, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblListeOpToAdd.TabIndex = 4002;
            this.m_lblListeOpToAdd.Text = "Operation List of work|1299";
            this.m_lblListeOpToAdd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_chkListeOp
            // 
            this.m_chkListeOp.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkListeOp, "");
            this.m_chkListeOp.Location = new System.Drawing.Point(316, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkListeOp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkListeOp.Name = "m_chkListeOp";
            this.m_chkListeOp.Size = new System.Drawing.Size(172, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkListeOp.TabIndex = 4021;
            this.m_chkListeOp.Text = "Concerned Operation List|1342";
            this.m_chkListeOp.UseVisualStyleBackColor = true;
            this.m_chkListeOp.CheckedChanged += new System.EventHandler(this.m_chkListeOp_CheckedChanged);
            // 
            // m_ctrlDecoupage
            // 
            this.m_extLinkField.SetLinkField(this.m_ctrlDecoupage, "");
            this.m_ctrlDecoupage.Location = new System.Drawing.Point(68, 123);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlDecoupage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_ctrlDecoupage.Name = "m_ctrlDecoupage";
            this.m_ctrlDecoupage.Size = new System.Drawing.Size(633, 29);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlDecoupage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlDecoupage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlDecoupage.TabIndex = 4020;
            this.m_ctrlDecoupage.ChangementDecoupage += new timos.preventives.EveChangementPeriodicite(this.m_ctrlDecoupage_ChangementDecoupage);
            // 
            // m_chkKeepCuting
            // 
            this.m_chkKeepCuting.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkKeepCuting, "");
            this.m_chkKeepCuting.Location = new System.Drawing.Point(316, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkKeepCuting, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkKeepCuting.Name = "m_chkKeepCuting";
            this.m_chkKeepCuting.Size = new System.Drawing.Size(112, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkKeepCuting, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkKeepCuting, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkKeepCuting.TabIndex = 4021;
            this.m_chkKeepCuting.Text = "Keep the division|1442";
            this.m_chkKeepCuting.UseVisualStyleBackColor = true;
            // 
            // m_btnValiderModifications
            // 
            this.m_btnValiderModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValiderModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValiderModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnValiderModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValiderModifications.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_btnValiderModifications.Location = new System.Drawing.Point(97, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnValiderModifications.Name = "m_btnValiderModifications";
            this.m_btnValiderModifications.Size = new System.Drawing.Size(24, 26);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValiderModifications.TabIndex = 4020;
            this.m_btnValiderModifications.TabStop = false;
            this.m_btnValiderModifications.Visible = false;
            this.m_btnValiderModifications.Click += new System.EventHandler(this.m_btnValiderModifications_Click);
            // 
            // m_btnEditerObjet
            // 
            this.m_btnEditerObjet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditerObjet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnEditerObjet.ForeColor = System.Drawing.Color.White;
            this.m_btnEditerObjet.Image = ((System.Drawing.Image)(resources.GetObject("m_btnEditerObjet.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_btnEditerObjet.Location = new System.Drawing.Point(67, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnEditerObjet.Name = "m_btnEditerObjet";
            this.m_btnEditerObjet.Size = new System.Drawing.Size(24, 26);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnEditerObjet.TabIndex = 4019;
            this.m_btnEditerObjet.TabStop = false;
            this.m_btnEditerObjet.Visible = false;
            this.m_btnEditerObjet.Click += new System.EventHandler(this.m_btnEditerObjet_Click);
            // 
            // m_btnAnnulerModifications
            // 
            this.m_btnAnnulerModifications.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAnnulerModifications.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnulerModifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnulerModifications.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnulerModifications.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnulerModifications.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_btnAnnulerModifications.Location = new System.Drawing.Point(127, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAnnulerModifications.Name = "m_btnAnnulerModifications";
            this.m_btnAnnulerModifications.Size = new System.Drawing.Size(24, 26);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnulerModifications.TabIndex = 4021;
            this.m_btnAnnulerModifications.TabStop = false;
            this.m_btnAnnulerModifications.Visible = false;
            this.m_btnAnnulerModifications.Click += new System.EventHandler(this.m_btnAnnulerModifications_Click);
            // 
            // m_ctxInters
            // 
            this.m_ctxInters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem,
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem,
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem});
            this.m_extLinkField.SetLinkField(this.m_ctxInters, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctxInters, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_ctxInters.Name = "ctx_inters";
            this.m_ctxInters.Size = new System.Drawing.Size(359, 70);
            this.m_extStyle.SetStyleBackColor(this.m_ctxInters, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctxInters, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // ajouterUneInterventionsPourChaqueSitesToolStripMenuItem
            // 
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem.Name = "ajouterUneInterventionsPourChaqueSitesToolStripMenuItem";
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem.Text = "Add interventions|1339";
            this.ajouterUneInterventionsPourChaqueSitesToolStripMenuItem.Click += new System.EventHandler(this.ctx_ajouterInterventions_Click);
            // 
            // supprimerLesInterventionsPourChaqueSitesToolStripMenuItem
            // 
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem.Name = "supprimerLesInterventionsPourChaqueSitesToolStripMenuItem";
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem.Text = "Remove interventions corresponding to the section|1340";
            this.supprimerLesInterventionsPourChaqueSitesToolStripMenuItem.Click += new System.EventHandler(this.ctx_supprimerInterventionsExactes_Click);
            // 
            // supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem
            // 
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem.Name = "supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem";
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem.Size = new System.Drawing.Size(358, 22);
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem.Text = "Remove all interventions|1341";
            this.supprimerToutesLesInterventionsPourChaquesSitesToolStripMenuItem.Click += new System.EventHandler(this.ctx_supprimerInterventions_Click);
            // 
            // m_ttDessin
            // 
            this.m_ttDessin.AutomaticDelay = 1500;
            this.m_ttDessin.AutoPopDelay = 10000;
            this.m_ttDessin.InitialDelay = 2500;
            this.m_ttDessin.IsBalloon = true;
            this.m_ttDessin.ReshowDelay = 300;
            // 
            // CFormEditionPreventive
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_btnValiderModifications);
            this.Controls.Add(this.m_btnEditerObjet);
            this.Controls.Add(this.m_panGeneral);
            this.Controls.Add(this.m_btnAnnulerModifications);
            this.KeyPreview = true;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionPreventive";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CFormEditionPreventive_KeyDown);
            this.m_panGeneral.ResumeLayout(false);
            this.m_panGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv)).EndInit();
            this.m_ctxInters.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		

		public CFormEditionPreventive()
		{
			InitializeComponent();
			InitChamps();
		}
		public CFormEditionPreventive(CContrat contrat, CContrat_ListeOperations contratListeOp)
		{
			InitializeComponent();

			ContratInitialisation = contrat;
			ContratListeOperationsInitialisation = contratListeOp;

			InitChamps();
		}

		private int NombreMaxTranchesAffichees
		{
			get
			{
				return 32;
			}
		}
		//INITIALISATION
		public CResultAErreur InitChamps()
		{
			CTimosApp.Titre = I.T("Planning Editor|1346");
			m_bInitialise = false;
			m_mappageSitesDuContrat = new Dictionary<int, IList<CSite>>();
			m_contratListeAAfficher = new List<CContrat_ListeOperations>();
			ModeEdition = false;
			InitListeContrats();
			InitDGV();
			EtatContratAccessible = false;
			if (ContratInitialisation != null)
			{
				m_txtSelectContrat.ElementSelectionne = ContratInitialisation;
				ChangementContrat();

				if (ContratListeOperationsInitialisation != null && ContratListeOperationsInitialisation.Contrat == ContratInitialisation)
				{
					m_cmbLstOp.ElementSelectionne = ContratListeOperationsInitialisation.ListeOperations;
					ChangementListeOperationDeTravail();
				}
			}
			m_bInitialise = true;
			return CResultAErreur.True;
		}
		private void LoadCurrentContext()
		{
			//CHARGEMENT DU CONTRAT
			CContrat contrat = (CContrat)Contrat.GetObjetInContexte(ContexteDonneeEditionEnCour);
			//CHARGEMENT DES SITES
			IList<CSite> sites = GetSitesOfContrat(contrat);
			string strIdsSitesPoss = "";
			foreach (CSite s in sites)
				strIdsSitesPoss += s.Id + ",";
			if (sites.Count > 0)
				strIdsSitesPoss = strIdsSitesPoss.Substring(0, strIdsSitesPoss.Length - 1);

			//CHARGEMENT DES RELATIONS CONTRAT-LISTEOPERATION
			string strIdsListesOps = "";
			CListeObjetsDonnees lst = contrat.RelationsListesOperations;
			lst.ReadDependances("RelationsSites", "ListeOperations", "TypeIntervention");
			foreach (CContrat_ListeOperations rel in lst)
			{
				//CHARGEMENT DES RELATIONS CONTRAT-LISTEOPERATION-SITE
				//int load = rel.RelationsSites.Count;

				//CHARGEMENT DES LISTE OPERATIONS
				strIdsListesOps += rel.ListeOperations.Id + ",";

				//CHARGEMENT DES TYPES INTERVENTIONS POSSIBLES
				//CTypeIntervention tInter = rel.TypeIntervention;
			}
			if (lst.Count > 0)
				strIdsListesOps = strIdsListesOps.Substring(0, strIdsListesOps.Length - 1);


			//CHARGEMENT DES INTERVENTIONS
			if (Decoupage.Tranches.Count > 0)
			{

				CFiltreDataAvance filtreSiteEtDate = new CFiltreDataAvance(CIntervention.c_nomTable,
					"(" + CIntervention.c_champIdElementLie + " in (" + strIdsSitesPoss + ")) AND " +
					"(" + CIntervention.c_champDateDebutPreplanifiee + " <= @2 AND " +
						CIntervention.c_champDateFinPrePlanifiee + " >= @1)"
						, Decoupage.DateDebut, Decoupage.DateFinSelonTranches);
				CFiltreDataAvance filtreListeOp = new CFiltreDataAvance(CIntervention.c_nomTable, CIntervention_ListeOperations.c_nomTable + "." + CListeOperations.c_champId + " in (" + strIdsListesOps + ")");

				CListeObjetsDonnees lstInters = new CListeObjetsDonnees(ContexteDonneeEditionEnCour, typeof(CIntervention), CFiltreDataAvance.GetAndFiltre(filtreListeOp, filtreSiteEtDate));

				lstInters.ReadDependances("RelationsListesOperations");

				//CHARGEMENT DES RELATIONS INTERVENTIONS-LISTEOPERATION
				/*foreach (CIntervention i in lstInters)
				{
					CTypeIntervention typeInter = i.TypeIntervention;
					int n = i.RelationsListesOperations.Count;
				}*/
			}
		}
		private void InitContexteDonnee()
		{
			if (Contrat != null)
			{
				if (m_ctx == null)
				{
					ContexteCourrantCharge = false;
					m_ctx = Contrat.ContexteDonnee.GetContexteEdition();
				}

				if (!ContexteCourrantCharge)
				{
					DateDebutChargee = Decoupage.DateDebut;
					DateFinChargee = Decoupage.DateFinSelonTranches;
				}
				else if (DateFinChargee > Decoupage.DateFinSelonTranches && DateDebutChargee < Decoupage.DateDebut
					|| DateFinChargee == Decoupage.DateFinSelonTranches && DateDebutChargee < Decoupage.DateDebut
					|| DateFinChargee > Decoupage.DateFinSelonTranches && DateDebutChargee == Decoupage.DateDebut
					|| DateDebutChargee == Decoupage.DateDebut && DateFinChargee == Decoupage.DateFinSelonTranches)
					return;

				if (DateDebutChargee > Decoupage.DateDebut)
					DateDebutChargee = Decoupage.DateDebut;
				if (DateFinChargee < Decoupage.DateFinSelonTranches)
					DateFinChargee = Decoupage.DateFinSelonTranches;

				LoadCurrentContext();
				ContexteCourrantCharge = true;
			}
		}
		private void InitDGV()
		{
			m_dgv.VirtualMode = true;	//Necessaire pour le déclanchement de CellToolTipTextNeeded
			m_dgv.ReadOnly = true;
			m_dgv.AutoGenerateColumns = false;
			m_dgv.BackgroundColor = Color.Beige;
			m_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			m_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			m_dgv.ColumnHeadersHeight = HauteurEntete;
			m_dgv.AllowUserToAddRows = false;
			m_dgv.AllowUserToDeleteRows = false;
			m_dgv.AllowUserToOrderColumns = false;
			m_dgv.RowHeadersVisible = false;
			
		}
		private void InitListeContrats()
		{
			m_txtSelectContrat.Init<CContrat>(
				"Libelle",
				false);
			m_txtSelectContrat.ElementSelectionne = null;
		}
		#region CONTEXTE DONNEE
		private bool m_bContextInitFirst = false;
		private DateTime m_dtStartLoaded;
		private DateTime m_dtEndLoaded;
		private bool ContexteCourrantCharge
		{
			get
			{
				return m_bContextInitFirst;
			}
			set
			{
				m_bContextInitFirst = value;
			}
		}
		private DateTime DateDebutChargee
		{
			get
			{
				return m_dtStartLoaded;
			}
			set
			{
				m_dtStartLoaded = value;
			}
		}
		private DateTime DateFinChargee
		{
			get
			{
				return m_dtEndLoaded;
			}
			set
			{
				m_dtEndLoaded = value;
			}
		}
		
		#endregion

		//ACCESSIBILITE
		private bool EtatContratAccessible
		{
			set
			{
				m_lblSites.Visible = value;
				m_lblListeOpToAdd.Visible = value;
				m_cmbLstOp.Visible = value;
				m_cmbLstOp.ElementSelectionne = null;

				m_lnkContrat.Visible = value;				
				m_lnkListeSites.Visible = value;
				m_lnkOpsAffichees.Visible = value;

				m_ctrlDecoupage.Visible = value;

				m_lblObjectif.Visible = false;
				m_chkSites.Visible = false;
				m_chkListeOp.Visible = false;

				m_btnEditerObjet.Visible = value;
				m_btnActualiser.Visible = value;

				AfficherGroupeDGV = false;
			}
		}
		private bool EtatListeOperationAccessible
		{
			set
			{
				m_lblObjectif.Visible = value;
				m_chkSites.Visible = value;
				m_chkListeOp.Visible = value;

				if (value)
				{
					m_lnkListeSites.Enabled = !m_chkSites.Checked && (SitesListeOpPossibles.Count - 1) != 0;
					m_lnkOpsAffichees.Enabled = !m_chkListeOp.Checked && ContratListeOperationToAdd != null;
				}

				m_btnActualiser.Visible = true;
			}
		}
		private bool AfficherGroupeDGV
		{
			set
			{
				m_dgv.Visible = value;
				m_btnLast.Visible = value;
				m_btnNext.Visible = value;
				m_lnkFormatDates.Visible = value;
			}
		}

		//CHARGEMENTS
		private IList<CSite> GetSitesOfContrat(CContrat contrat)
		{
			if (!SitesDuContratMappes(contrat))
				LoadSitesOfContrat(contrat);
			return m_mappageSitesDuContrat[contrat.Id];
		}
		private void LoadSitesOfContrat(CContrat contrat)
		{
			m_mappageSitesDuContrat.Add(contrat.Id, contrat.GetTousLesSitesDuContrat());
		}
		private bool SitesDuContratMappes(CContrat contrat)
		{
			foreach(int nId in m_mappageSitesDuContrat.Keys)
				if(nId == contrat.Id)
					return true;
			return false;
		}
		private Dictionary<int, IList<CSite>> m_mappageSitesDuContrat;
		private void ChangementContrat()
		{
			using (CWaitCursor waiter = new CWaitCursor())
			{
				bool bOk = Contrat != null;
				Erreur = "";
				m_sitesAAfficher = new List<CSite>();
				m_contratListeAAfficher = new List<CContrat_ListeOperations>();

				if (bOk)
				{

					//AJOUT DES OPERATIONS POSSIBLES AU CMB
					CFiltreDataAvance filtre = new CFiltreDataAvance(CListeOperations.c_nomTable, CContrat_ListeOperations.c_nomTable + "." + CContrat.c_champId + " =@1", Contrat.Id);
					CListeObjetsDonnees lstListeOp = new CListeObjetsDonnees(Contrat.ContexteDonnee, typeof(CListeOperations), filtre);
					m_cmbLstOp.Init(lstListeOp, "Libelle", true);
					m_cmbLstOp.ElementSelectionne = null;

					//CREATION D'UN MAPPAGE POUR LE CMB
					m_dicListeContrats = new Dictionary<int, CContrat_ListeOperations>();
					CListeObjetsDonnees lstContratsListeOp = Contrat.RelationsListesOperations;
					foreach (CContrat_ListeOperations cOp in lstContratsListeOp)
						m_dicListeContrats.Add(cOp.ListeOperations.Id, cOp);

					//Verification Contrats Possibles
					if (m_dicListeContrats.Count == 0)
					{
						Erreur = I.T("No task list exists for this contract|1307");
						bOk = false;
					}

					m_sitesAAfficher = SitesContratPossibles;
					if (m_sitesAAfficher.Count == 0)
					{
					    Erreur = I.T("No site exists for this contract|1308");
					    bOk = false;
					}
					else
					{
						m_lblSites.Text = I.T("@1 Sites finds|1345", m_sitesAAfficher.Count.ToString());
						//Thread initCtx = new Thread(new ThreadStart(InitContexteDonnee));
						//initCtx.Start();
						
						m_ctrlDecoupage.Initialiser(Contrat.DecoupageEditeur);
						m_ctrlDecoupage.Decoupage.NombreLimiteDeTranche = NombreMaxTranchesAffichees;
						m_contratListeAAfficher = ContratListesOperationsPossibles;
					}
				}
				else
					Erreur = I.T("Please select a contract|1309");

				EtatContratAccessible = bOk;
			}
		}
		private void ChangementListeOperationDeTravail()
		{
			bool bOk = ContratListeOperationToAdd != null;

			if(bOk)
			{
				m_lblObjectif.Text = I.T("Target of @1 every @2 @3|1310", ContratListeOperationToAdd.NombreParPeriode.ToString(), ContratListeOperationToAdd.NombrePeriodes.ToString(), ContratListeOperationToAdd.PeriodiciteOperation.Libelle);
				m_lblObjectif.Text += " ";
				if (ContratListeOperationToAdd.DateLimite != null)
					m_lblObjectif.Text += I.T("between @1 and @2|1324", ContratListeOperationToAdd.DateDebut.ToString("d", DateTimeFormatInfo.CurrentInfo),
						ContratListeOperationToAdd.DateLimite.Value.ToString("d", DateTimeFormatInfo.CurrentInfo));
				else
					m_lblObjectif.Text += I.T("from @1|1325", ContratListeOperationToAdd.DateDebut.ToString("d", DateTimeFormatInfo.CurrentInfo));

				if(!m_chkKeepCuting.Checked)
					m_ctrlDecoupage.Initialiser(ContratListeOperationToAdd.DecoupageEditeur);
				m_ctrlDecoupage.Decoupage.NombreLimiteDeTranche = NombreMaxTranchesAffichees;
			}

			EtatListeOperationAccessible = bOk;
		}
		private void MAJDGV()
		{
			if (Dessin != null)
			{
				int nbCols = m_dessin.DessinsTranches.Count + 1;
				//Dimentions des colonnes a rajouter ?
				if (nbCols != m_dgv.Columns.Count)
				{
					m_dgv.Columns.Clear();
					for (int c = 0; c < nbCols; c++)
						m_dgv.Columns.Add(new DataGridViewTextBoxColumn());
				}
				
				//Dimentions des lignes a gerer ?
				int nbRows = m_dessin.DessinsSites.Count;
				if (nbRows != m_dgv.Rows.Count)
				{
					m_dgv.Rows.Clear();
					for (int r = 0; r < nbRows; r++)
					{
						m_dgv.Rows.Add();
						m_dgv.Rows[r].Height = (m_contratListeAAfficher.Count * 20);
						if (ContratListeOperationToAdd != null)
							m_dgv.Rows[r].Height += 20;

						//for (int c = 0; c < nbCols; c++)
						//	m_dgv.Rows[r].Cells[c].ToolTipText = "toto aime les bananes";
						
					}
				}
				AfficherGroupeDGV = true;
				//foreach(DataGridViewCell c in m_dgv.Rows[0].Cells)
				//    c.too
				m_dgv.Refresh();
			}

		}
		private void MAJAffichage()
		{
			using (CWaitCursor waiter = new CWaitCursor())
			{
				m_ctrlDecoupage.MAJAffichageSansNotificationModification();
				CContexteDonnee ctx = ContexteDonneeEditionEnCour;
				InitContexteDonnee();

				if (!Decoupage.Valide)
				{
					Erreur = Decoupage.Erreur;
					return;
				}
				else
				{
					m_ctrlDecoupage.MAJAffichageSansNotificationModification();
					Thread thMaj = new Thread(new ThreadStart(MAJDecoupageInDB));
					thMaj.Start();
				}
				List<CSite> sitesAAfficher = m_chkSites.Checked ? SitesListeOpPossibles : m_sitesAAfficher;
				List<CContrat_ListeOperations> listeAAfficher = new List<CContrat_ListeOperations>();
				if(!m_chkListeOp.Checked)
					foreach (CContrat_ListeOperations c in m_contratListeAAfficher)
						listeAAfficher.Add(c);

				while (!m_bContextInitFirst)
				{
				}

				//Création du dessin
				if (m_dessin == null)
				{
					m_dessin = new CDessinEditeurPreventive(
						ContexteDonneeEditionEnCour,
						Decoupage,
						ContratListeOperationToAdd,
						sitesAAfficher,
						listeAAfficher);
					m_dessin.MettreEnEvidanceLelementSurvole = false;
				}
				else
					m_dessin.MAJStructure(Decoupage, ContratListeOperationToAdd, sitesAAfficher, listeAAfficher);


				if (!m_dessin.Valide)
					Erreur = I.T("An error occurred during the display of forecasts|1311");
				else
				{
					m_dessin.FormatDate = FormatDate;
					Erreur = "";
					MAJDGV();
				}
				m_btnActualiser.Visible = false;
			}
		}

		private bool m_bInitialise = false;

		private Dictionary<int, CContrat_ListeOperations> m_dicListeContrats;
		private CDessinEditeurPreventive m_dessin;
		private CContexteDonnee m_ctx;

		private CContrat m_contratForInit;
		public CContrat ContratInitialisation
		{
			get
			{
				return m_contratForInit;
			}
			set
			{
				m_contratForInit = value;
			}
		}
		private CContrat_ListeOperations m_contratListeOperationsInitialisation;
		public CContrat_ListeOperations ContratListeOperationsInitialisation
		{
			get
			{
				return m_contratListeOperationsInitialisation;
			}
			set
			{
				m_contratListeOperationsInitialisation = value;
			}
		}
		private CContrat Contrat
		{
			get
			{
				if (m_txtSelectContrat.ElementSelectionne == null)
					return null;
				return (CContrat)m_txtSelectContrat.ElementSelectionne;
			}
		}
		private CListeOperations ListeOperationToAdd
		{
			get
			{
				if (m_cmbLstOp.ElementSelectionne == null)
					return null;
				return (CListeOperations)m_cmbLstOp.ElementSelectionne;
			}
		}
		private CContrat_ListeOperations ContratListeOperationToAdd
		{
			get
			{
				if (ListeOperationToAdd == null || m_dicListeContrats == null)
					return null;
				return m_dicListeContrats[ListeOperationToAdd.Id];
			}
		}
		
		private List<CContrat_ListeOperations> ContratListesOperationsPossibles
		{
			get
			{
				List<CContrat_ListeOperations> lstContrat = new List<CContrat_ListeOperations>();
				if (m_dicListeContrats != null)
					foreach (int nIdLst in m_dicListeContrats.Keys)
						lstContrat.Add(m_dicListeContrats[nIdLst]);
				return lstContrat;
			}
		}
		private List<CSite> SitesContratPossibles
		{
			get
			{
				List<CSite> sites = new List<CSite>();
				if (Contrat != null)
				{
					IList<CSite> stes = GetSitesOfContrat(Contrat);
					foreach (CSite s in stes)
						sites.Add(s);
				}
				return sites;
			}
		}
		private List<CSite> SitesListeOpPossibles
		{
			get
			{
				List<CSite> sitesConcernes = new List<CSite>();
				if (m_cmbLstOp.ElementSelectionne != null)
				{
					CSite[] sites = ContratListeOperationToAdd.GetTousLesSitesAssocies();
					foreach (CSite s in sites)
						sitesConcernes.Add(s);
				}
						
				return sitesConcernes;
			}
		}

		private string m_strErr;
		public string Erreur
		{
			get
			{
				return m_strErr;
			}
			set
			{
				if (!m_bInitialise)
					return;
				m_lblErrorDate.Text = value;
				m_strErr = value;
				m_lblErrorDate.Visible = value != "";
			}
		}

		public CDecoupage Decoupage
		{
			get
			{
				return m_ctrlDecoupage.Decoupage;
			}
		}

		public CDessinEditeurPreventive Dessin
		{
			get
			{
				return m_dessin;
			}
		}
		public CContexteDonnee ContexteDonneeEditionEnCour
		{
			get
			{
				return m_ctx;
			}
		}

		private List<CSite> m_sitesAAfficher = new List<CSite>();
		private List<CContrat_ListeOperations> m_contratListeAAfficher;

		//AFFICHAGE LISTE OP ET SITES
		private void m_lnkListeSites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			List<CObjetDonneeAIdNumerique> elementsSelectionnes = m_sitesAAfficher.ConvertAll<CObjetDonneeAIdNumerique>(delegate(CSite sit) { return (CObjetDonneeAIdNumerique)sit; });
			List<CObjetDonneeAIdNumerique> elementsPossibles = SitesContratPossibles.ConvertAll<CObjetDonneeAIdNumerique>(delegate(CSite sit) { return (CObjetDonneeAIdNumerique)sit; });
			string strIdsSitesPoss = "";
			foreach (CSite s in elementsPossibles)
				strIdsSitesPoss += s.Id + ",";
			if (strIdsSitesPoss != "")
			{
				strIdsSitesPoss = strIdsSitesPoss.Substring(0, strIdsSitesPoss.Length - 1);
				CListeObjetsDonnees lstPoss = new CListeObjetsDonnees(Contrat.ContexteDonnee,typeof(CSite),new CFiltreData(CSite.c_champId + " in (" + strIdsSitesPoss + ")"));
				elementsSelectionnes = CFormFloatSelectInListe.GetSelectionInListe(lstPoss, elementsSelectionnes, false);
				if (elementsSelectionnes.Count != 0)
				{
					m_sitesAAfficher = elementsSelectionnes.ConvertAll<CSite>(delegate(CObjetDonneeAIdNumerique obj) { return (CSite)obj; });
					m_btnActualiser.Visible = true;
				}
			}
		}
		private void m_lnkOpsAffichees_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			List<CObjetDonneeAIdNumerique> elementsSelectionnes = m_contratListeAAfficher.ConvertAll<CObjetDonneeAIdNumerique>(delegate(CContrat_ListeOperations ctr){return (CObjetDonneeAIdNumerique)ctr.ListeOperations;});
			List<CObjetDonneeAIdNumerique> elementsPossibles = ContratListesOperationsPossibles.ConvertAll<CObjetDonneeAIdNumerique>(delegate(CContrat_ListeOperations ctr){return (CObjetDonneeAIdNumerique) ctr;});
			if(ContratListeOperationToAdd != null && elementsPossibles.Contains(ContratListeOperationToAdd))
				elementsPossibles.Remove(ContratListeOperationToAdd);

			string strIdsCtrPoss = "";
			string strIdsLstOpPoss = "";
			foreach (CContrat_ListeOperations s in elementsPossibles)
			{
				strIdsCtrPoss += s.Id + ",";
				strIdsLstOpPoss += s.ListeOperations.Id + ",";
			}
			if (strIdsLstOpPoss != "")
			{
				strIdsLstOpPoss = strIdsLstOpPoss.Substring(0, strIdsLstOpPoss.Length - 1);
				strIdsCtrPoss = strIdsCtrPoss.Substring(0, strIdsCtrPoss.Length - 1);

				CListeObjetsDonnees lstPoss = new CListeObjetsDonnees(Contrat.ContexteDonnee, typeof(CListeOperations), new CFiltreData(CListeOperations.c_champId + " in (" + strIdsLstOpPoss + ")"));
				elementsSelectionnes = CFormFloatSelectInListe.GetSelectionInListe(lstPoss, elementsSelectionnes, ContratListeOperationToAdd != null);
				if (elementsSelectionnes.Count != 0 || ContratListeOperationToAdd != null)
				{
					CFiltreData filtre = new CFiltreDataImpossible();
					if(elementsSelectionnes.Count != 0)
					{
						string strIdsLstOpSelec = "";
						foreach (CListeOperations lstS in elementsSelectionnes)
							strIdsLstOpSelec += lstS.Id + ",";
						strIdsLstOpSelec = strIdsLstOpSelec.Substring(0, strIdsLstOpSelec.Length - 1);
						filtre = new CFiltreData(CContrat_ListeOperations.c_champId + " in(" + strIdsCtrPoss + ") AND " + CListeOperations.c_champId + " in(" + strIdsLstOpSelec + ")");
					}

					CListeObjetsDonnees lstSelec = new CListeObjetsDonnees(Contrat.ContexteDonnee,typeof(CContrat_ListeOperations), filtre);
					List<CContrat_ListeOperations> elements = new List<CContrat_ListeOperations>();
					foreach (CContrat_ListeOperations c in lstSelec)
						elements.Add(c);
					m_contratListeAAfficher = elements;
					m_btnActualiser.Visible = true;
				}
			}
		}
		private void m_chkSites_CheckedChanged(object sender, EventArgs e)
		{
			if (m_cmbLstOp.ElementSelectionne != null)
			{
				m_lnkListeSites.Enabled = !m_chkSites.Checked;
				m_btnActualiser.Visible = true;
			}
		}
		private void m_chkListeOp_CheckedChanged(object sender, EventArgs e)
		{
			if (m_cmbLstOp.ElementSelectionne != null)
			{
				m_lnkOpsAffichees.Enabled = !m_chkListeOp.Checked;
				m_btnActualiser.Visible = true;
			}
		}

		//TOOL TIP
		private void m_dgv_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
		{
			if (m_dessin != null)
				e.ToolTipText = m_dessin.GetLabelItemOnPoint(e.RowIndex, e.ColumnIndex, GetPointInCell(e.RowIndex,e.ColumnIndex));
		}

		//GENERAL
		private void m_lnkContrat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Contrat != null)
				CTimosApp.Navigateur.AffichePage(new CFormEditionContrat(Contrat));
		}
		private void m_txtSelectContrat_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if(m_bInitialise)
				ChangementContrat();
		}
		private void m_cmbLstOp_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (m_bInitialise)
				ChangementListeOperationDeTravail();
		}
		private void m_btnActualiser_Click(object sender, EventArgs e)
		{
			MAJAffichage();
		}

		//ACTIONS SUR DGV
		private void m_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right && ModeEdition && ContratListeOperationToAdd != null)
			{
				m_nColContext = e.ColumnIndex;
				m_ctxInters.Show(Cursor.Position);
			}
		}
		private int m_nColContext;
		private void ctx_ajouterInterventions_Click(object sender, EventArgs e)
		{
			if (ModeEdition && m_dessin != null)
			{
				m_dessin.AjouterSurColonne(m_nColContext);
				Refresh();
			}
		}
		private void ctx_supprimerInterventionsExactes_Click(object sender, EventArgs e)
		{
			if (ModeEdition && m_dessin != null)
			{
				m_dessin.SupprimerSurColonne(m_nColContext);
				Refresh();
			}
		}
		private void ctx_supprimerInterventions_Click(object sender, EventArgs e)
		{
			if (ModeEdition && m_dessin != null)
			{
				m_dessin.SupprimerToutSurColonne(m_nColContext);
				Refresh();
			}
		}

		void m_dgv_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (m_dessin != null )
			{
				if (e.Button == MouseButtons.Left && ModeEdition && ContratListeOperationToAdd != null)
				{
					m_dessin.OnClicLeft(e.RowIndex, e.ColumnIndex, e.Location);
					MAJDGV();
				}
				else if (e.Button == MouseButtons.Right)
				{
					if (ModeEdition)
					{
						m_dessin.OnClicRight(e.RowIndex, e.ColumnIndex, e.Location);
						MAJDGV();
					}
				}
			}
		}

		private Point GetPointInCell(int nIdxRow, int nIdxCol)
		{
			Point p = m_dgv.PointToClient(Cursor.Position);
			Rectangle rctCell = m_dgv.GetCellDisplayRectangle(nIdxCol, nIdxRow, false);
			return new Point(p.X - rctCell.X, p.Y - rctCell.Y);

		}
		void m_dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (m_dessin != null)
			{
				m_dessin.Draw(e.RowIndex, e.ColumnIndex, e.Graphics, e.CellBounds);
				e.Handled = true;
			}
		}
		void m_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (!ModeEdition && m_dessin != null)
			{
				CIntervention inter = m_dessin.GetInterInDBAtPoint(e.RowIndex,e.ColumnIndex, GetPointInCell(e.RowIndex,e.ColumnIndex));
				if(inter!= null)
					CTimosApp.Navigateur.AffichePage(new CFormEditionIntervention(inter));
			}
		}

		//MODE EDITION
		private bool m_bEnEdition = false;
		public bool ModeEdition
		{
			get
			{
				return m_bEnEdition;
			}
			set
			{
				if (Contrat == null)
					return;
				m_bEnEdition = value;
				m_lnkContrat.Enabled = !m_bEnEdition;
				m_btnEditerObjet.Visible = !m_bEnEdition;
				m_btnAnnulerModifications.Visible = m_bEnEdition;
				m_btnValiderModifications.Visible = m_bEnEdition;
				m_txtSelectContrat.Enabled = !m_bEnEdition;
			}
		}
		private void CFormEditionPreventive_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F10)
				ValiderEdition();
			else if (e.KeyCode == Keys.F8)
				ModeEdition = true;
		}
		private void m_btnEditerObjet_Click(object sender, EventArgs e)
		{
			ModeEdition = true;
		}
		private void m_btnValiderModifications_Click(object sender, EventArgs e)
		{
			ValiderEdition();
		}
		private void m_btnAnnulerModifications_Click(object sender, EventArgs e)
		{
			AnnulerEdition();
		}
		public void ValiderEdition()
		{
			if (ModeEdition)
				using (CWaitCursor waiter = new CWaitCursor())
				{
					if (m_dessin != null)
					{
						CResultAErreur result = m_dessin.MAJChamps();
						if (!result)
						{
							CFormAlerte.Afficher(result.Erreur);
							return;
						}
					}
					ModeEdition = false;
				}
		}
		public void AnnulerEdition()
		{
			if (ModeEdition)
				using (CWaitCursor waiter = new CWaitCursor())
				{
					if (m_dessin != null)
					{
						ContexteDonneeEditionEnCour.CancelEdit();
						//CStatutEditeurPreventive statut = CStatutEditeurPreventive.GetStatut(this);
						//m_ctx = CSc2iWin32DataClient.ContexteCourant.GetContexteEdition();
						m_dessin = null;
						//m_bContextInitFirst = false;
						//CStatutEditeurPreventive.SetStatut(this, statut, m_ctx);
						MAJAffichage();
					}
					ModeEdition = false;
				}
		}
		//DECOUPAGE
		private void m_ctrlDecoupage_ChangementDecoupage(CDecoupage decoupage)
		{
			m_btnActualiser.Visible = true;
		}
		private IElementADecoupagePourEditeurPreventive ElementEnCour
		{
			get
			{
				if (ContratListeOperationToAdd != null)
					return ContratListeOperationToAdd;
				else
					return Contrat;
			}
		}
		private void MAJDecoupageInDB()
		{
			if (!m_chkKeepCuting.Checked)
			{
				((CObjetDonnee)ElementEnCour).BeginEdit();
				ElementEnCour.DecoupageEditeur = Decoupage;
				((CObjetDonnee)ElementEnCour).CommitEdit();
			}
		}
	

		//NAVIGATION DECOUPAGE
		private void m_btnLast_Click(object sender, EventArgs e)
		{
			Decoupage.Reculer();
			MAJAffichage();
		}
		private void m_btnNext_Click(object sender, EventArgs e)
		{
			Decoupage.Avancer();
			MAJAffichage();
		}

		//FORMAT DATE
		private EFormatDate m_formatDate = EFormatDate.JourMoisAnnee;
		public EFormatDate FormatDate
		{
			get
			{
				return m_formatDate;
			}
			set
			{
				m_formatDate = value;
				if (m_dessin != null)
				{
					m_dgv.ColumnHeadersHeight = HauteurEntete;
					m_dessin.FormatDate = value;
				}
			}
		}
		public int HauteurEntete
		{
			get
			{
				switch (FormatDate)
				{
					case EFormatDate.JourMoisAnnee:
						return 90;
					case EFormatDate.MoisAnnee:
						return 70;
					case EFormatDate.Jour:
					case EFormatDate.Mois:
					case EFormatDate.Semaine:
						return 30;
					case EFormatDate.JourMois:
					case EFormatDate.Annee:
						return 50;

				}
				return 70;
			}
		}
		private void m_lnkFormatDates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			FormatDate = CFormFloatSelectFormatDate.GetFormatDate(FormatDate);
		}

		#region IFormNavigable Membres
        public event ContexteFormEventHandler AfterGetContexte;
        public event ContexteFormEventHandler AfterInitFromContexte;

       
		public CContexteFormNavigable GetContexte()
		{
            CContexteFormNavigable contexte = CStatutEditeurPreventive.GetStatut(this, GetType());
            if (AfterGetContexte != null)
                AfterGetContexte(this, contexte);
            return contexte;
		}

		public bool QueryClose()
		{
			return true;
		}

		public CResultAErreur InitFromContexte(CContexteFormNavigable contexte)
		{
			CResultAErreur result = CResultAErreur.True;
			CStatutEditeurPreventive.SetStatut(this, contexte, CSc2iWin32DataClient.ContexteCourant);
            if (AfterInitFromContexte != null)
                AfterInitFromContexte(this, contexte);
			return result;
		}
        //------------------------------------------------------------------
        public CResultAErreur Actualiser()
        {
            return InitFromContexte(GetContexte());
        }


		#endregion


		private class CStatutEditeurPreventive
		{
			public static CContexteFormNavigable GetStatut(CFormEditionPreventive frm, Type type)
			{
				CContexteFormNavigable contexte = new CContexteFormNavigable(type);
				if (contexte == null)
					return null;
				CStatutEditeurPreventive statut = GetStatut(frm);
				contexte["STATUT"] = statut;
				return contexte;
			}
			public static CStatutEditeurPreventive GetStatut(CFormEditionPreventive frm)
			{
				return new CStatutEditeurPreventive(
					frm.Erreur,
					frm.m_chkSites.Checked,
					frm.m_chkListeOp.Checked,
					frm.m_dessin != null,
					frm.FormatDate,
					frm.Contrat,
					frm.ListeOperationToAdd,
					frm.m_contratListeAAfficher,
					frm.m_sitesAAfficher);
			}
			public static void SetStatut(CFormEditionPreventive frm, CStatutEditeurPreventive statut, CContexteDonnee ctx)
			{
				if (statut == null)
					return;
				if (statut.IdContratSelec != -1)
				{
					//CHARGEMENT CONTRAT

					CListeObjetsDonnees lstObj = new CListeObjetsDonnees(ctx, typeof(CContrat), new CFiltreData(CContrat.c_champId + " = @1", statut.IdContratSelec));
					if (lstObj.Count == 1)
					{
						frm.m_txtSelectContrat.ElementSelectionne = (CContrat)lstObj[0];
						frm.ChangementContrat();


						if (statut.IdListeOp != -1)
						{
							lstObj = new CListeObjetsDonnees(ctx, typeof(CListeOperations), new CFiltreData(CListeOperations.c_champId + " = @1", statut.IdListeOp));
							if (lstObj.Count == 1)
							{
								frm.m_cmbLstOp.ElementSelectionne = (CListeOperations)lstObj[0];
								frm.ChangementListeOperationDeTravail();
							}

						}

						string strIdsSites = "";
						frm.m_sitesAAfficher = new List<CSite>();
						foreach (int nId in statut.IdsSitesAffiches)
							strIdsSites += nId.ToString() + ",";
						if (strIdsSites != "")
						{
							strIdsSites = strIdsSites.Substring(0, strIdsSites.Length - 1);
							lstObj = new CListeObjetsDonnees(ctx, typeof(CSite), new CFiltreData(CSite.c_champId + " in (" + strIdsSites + ")"));
							foreach (CSite site in lstObj)
								frm.m_sitesAAfficher.Add(site);
						}

						frm.m_contratListeAAfficher = new List<CContrat_ListeOperations>();
						string strIdsCtrs = "";
						foreach (int nId in statut.IdsContratsAffiches)
							strIdsCtrs += nId.ToString() + ",";
						if (strIdsCtrs != "")
						{
							strIdsCtrs = strIdsCtrs.Substring(0, strIdsCtrs.Length - 1);
							lstObj = new CListeObjetsDonnees(ctx, typeof(CContrat_ListeOperations), new CFiltreData(CContrat_ListeOperations.c_champId + " in (" + strIdsCtrs + ")"));
							foreach (CContrat_ListeOperations ctr in lstObj)
								frm.m_contratListeAAfficher.Add(ctr);
						}

						frm.m_formatDate = statut.FormatDate;

						frm.m_chkListeOp.Checked = statut.CheckBoxListeOp;
						frm.m_chkSites.Checked = statut.CheckBoxSite;
						if (statut.Erreur != "")
							frm.Erreur = statut.Erreur;
						else if (statut.DGVAffiche)
							frm.MAJAffichage();
					}
				}
			}
			public static void SetStatut(CFormEditionPreventive frm, CContexteFormNavigable contexte, CContexteDonnee ctx)
			{
				CStatutEditeurPreventive statut = (CStatutEditeurPreventive)contexte["STATUT"];
				SetStatut(frm, statut, ctx);
			}

			public CStatutEditeurPreventive(string strErr, bool bChkSite,bool bChkListeOp,
				bool bAlreadyAffiche, EFormatDate eFormatDate, CContrat ctr, CListeOperations lstOp,
				List<CContrat_ListeOperations> ctrsAffiches, List<CSite> sitesAffiches)
			{
				m_strErr = strErr;
				m_bChkListeOp = bChkListeOp;
				m_bChkSite = bChkSite;
				m_formatDate = eFormatDate;
				m_bDgvLoaded = bAlreadyAffiche;
				if (ctr == null)
					m_nIdContrat = -1;
				else
					m_nIdContrat = ctr.Id;
				if(lstOp == null)
					m_nIdListeOp = -1;
				else
					m_nIdListeOp = lstOp.Id;

				m_idsContratsAffiches = new List<int>();
				foreach (CContrat_ListeOperations c in ctrsAffiches)
					m_idsContratsAffiches.Add(c.Id);
				m_idsSitesAffiches = new List<int>();
				foreach (CSite s in sitesAffiches)
					m_idsSitesAffiches.Add(s.Id);
			}
			
			private string m_strErr;
			public string Erreur
			{
				get
				{
					return m_strErr;
				}
			}
			
			private EFormatDate m_formatDate;
			public EFormatDate FormatDate
			{
				get
				{
					return m_formatDate;
				}
			}
			
			private bool m_bDgvLoaded;
			public bool DGVAffiche
			{
				get
				{
					return m_bDgvLoaded;
				}
			}
			private bool m_bChkSite;
			public bool CheckBoxSite
			{
				get
				{
					return m_bChkSite;
				}
			}
			private bool m_bChkListeOp;
			public bool CheckBoxListeOp
			{
				get
				{
					return m_bChkListeOp;
				}
			}


			private int m_nIdContrat;
			public int IdContratSelec
			{
				get
				{
					return m_nIdContrat;
				}
			}
			private int m_nIdListeOp;
			public int IdListeOp
			{
				get
				{
					return m_nIdListeOp;
				}
			}
			private List<int> m_idsSitesAffiches;
			public List<int> IdsSitesAffiches
			{
				get
				{
					return m_idsSitesAffiches;
				}
			}
			private List<int> m_idsContratsAffiches;
			public List<int> IdsContratsAffiches
			{
				get
				{
					return m_idsContratsAffiches;
				}
			}
		}

        public string GetTitle()
        {
            return I.T("Planning Editor|1346");
        }

        public Image GetImage()
        {
            return Resources.maintenance;
        }


		
	}
}

