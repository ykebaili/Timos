using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.Excel;
using sc2i.data.dynamic;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;
using sc2i.process;

using timos.data;
using timos.tables;
using System.Text;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTableParametrable))]
    public class CFormEditionTableParametrable : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private Label m_lblLabel;
		private ListViewAutoFilled m_wndListeFormatNumerotation;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private Panel m_panTop;
		private C2iTextBoxSelectionne m_selectTypeTable;
		private Label m_lblTypeTable;
		private DataGridView m_dgDataTable;
		private timos.tables.CExtFilterForDataGridView m_extFilterForDataGridView;
		private timos.tables.CExtDataGridViewControlMapper m_extControlEditeurDataGrid;
		private C2iTabControl m_TabControl;
		private Crownwood.Magic.Controls.TabPage m_pageTable;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private C2iTextBoxSelectionne m_selecEleLie;
		private C2iComboBox m_cmbTypeRel;
		private Label m_lblLieA;
		private Label m_lblTypeLiaison;
		private TextBox m_txtErrs;
		private Panel m_panErr;
		private Label m_lblErr;
		private Panel m_panGauche;
		private LinkLabel m_lnkImporter;
		private Crownwood.Magic.Controls.TabPage m_pageForm;
		private CPanelChampsCustom m_PanelChamps;
		private CReducteurControle m_reducteurTop;
        private LinkLabel m_lnkFromExcel;
        private PictureBox m_btnCopy;
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
            m_extControlEditeurDataGrid.SortirSansControle = true;
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTableParametrable));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_panGauche = new System.Windows.Forms.Panel();
            this.m_cmbTypeRel = new sc2i.win32.common.C2iComboBox();
            this.m_lblLieA = new System.Windows.Forms.Label();
            this.m_lblTypeTable = new System.Windows.Forms.Label();
            this.m_selecEleLie = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_lblTypeLiaison = new System.Windows.Forms.Label();
            this.m_selectTypeTable = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panErr = new System.Windows.Forms.Panel();
            this.m_txtErrs = new System.Windows.Forms.TextBox();
            this.m_lblErr = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageTable = new Crownwood.Magic.Controls.TabPage();
            this.m_btnCopy = new System.Windows.Forms.PictureBox();
            this.m_lnkFromExcel = new System.Windows.Forms.LinkLabel();
            this.m_lnkImporter = new System.Windows.Forms.LinkLabel();
            this.m_dgDataTable = new System.Windows.Forms.DataGridView();
            this.m_pageForm = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_wndListeFormatNumerotation = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_extFilterForDataGridView = new timos.tables.CExtFilterForDataGridView();
            this.m_extControlEditeurDataGrid = new timos.tables.CExtDataGridViewControlMapper();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panOmbre.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.m_panGauche.SuspendLayout();
            this.m_panErr.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgDataTable)).BeginInit();
            this.m_pageForm.SuspendLayout();
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
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
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
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(83, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(459, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panTop);
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panOmbre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panOmbre, false);
            this.m_panOmbre.Location = new System.Drawing.Point(8, 52);
            this.m_panOmbre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panOmbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panOmbre, "");
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(810, 144);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panOmbre.TabIndex = 0;
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.Controls.Add(this.m_panGauche);
            this.m_panTop.Controls.Add(this.m_panErr);
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(795, 128);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 4011;
            // 
            // m_panGauche
            // 
            this.m_panGauche.Controls.Add(this.m_cmbTypeRel);
            this.m_panGauche.Controls.Add(this.m_lblLieA);
            this.m_panGauche.Controls.Add(this.m_lblTypeTable);
            this.m_panGauche.Controls.Add(this.m_selecEleLie);
            this.m_panGauche.Controls.Add(this.m_txtLibelle);
            this.m_panGauche.Controls.Add(this.m_lblLabel);
            this.m_panGauche.Controls.Add(this.m_lblTypeLiaison);
            this.m_panGauche.Controls.Add(this.m_selectTypeTable);
            this.m_panGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panGauche, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panGauche, false);
            this.m_panGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panGauche, "");
            this.m_panGauche.Name = "m_panGauche";
            this.m_panGauche.Size = new System.Drawing.Size(552, 128);
            this.m_extStyle.SetStyleBackColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGauche.TabIndex = 4021;
            // 
            // m_cmbTypeRel
            // 
            this.m_cmbTypeRel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeRel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeRel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeRel.FormattingEnabled = true;
            this.m_cmbTypeRel.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeRel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeRel, false);
            this.m_cmbTypeRel.Location = new System.Drawing.Point(195, 40);
            this.m_cmbTypeRel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeRel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeRel, "");
            this.m_cmbTypeRel.Name = "m_cmbTypeRel";
            this.m_cmbTypeRel.Size = new System.Drawing.Size(347, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeRel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeRel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeRel.TabIndex = 4017;
            this.m_cmbTypeRel.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeRel_SelectedIndexChanged);
            // 
            // m_lblLieA
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLieA, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLieA, false);
            this.m_lblLieA.Location = new System.Drawing.Point(4, 98);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLieA, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLieA, "");
            this.m_lblLieA.Name = "m_lblLieA";
            this.m_lblLieA.Size = new System.Drawing.Size(185, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblLieA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLieA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLieA.TabIndex = 4005;
            this.m_lblLieA.Text = "Associate with element |1205";
            // 
            // m_lblTypeTable
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeTable, false);
            this.m_lblTypeTable.Location = new System.Drawing.Point(4, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeTable, "");
            this.m_lblTypeTable.Name = "m_lblTypeTable";
            this.m_lblTypeTable.Size = new System.Drawing.Size(185, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeTable.TabIndex = 4005;
            this.m_lblTypeTable.Text = "Custom table type|1196";
            // 
            // m_selecEleLie
            // 
            this.m_selecEleLie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selecEleLie.ElementSelectionne = null;
            this.m_selecEleLie.FonctionTextNull = null;
            this.m_selecEleLie.HasLink = true;
            this.m_selecEleLie.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selecEleLie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selecEleLie, false);
            this.m_selecEleLie.Location = new System.Drawing.Point(195, 94);
            this.m_selecEleLie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selecEleLie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selecEleLie, "");
            this.m_selecEleLie.Name = "m_selecEleLie";
            this.m_selecEleLie.SelectedObject = null;
            this.m_selecEleLie.Size = new System.Drawing.Size(347, 21);
            this.m_selecEleLie.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selecEleLie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selecEleLie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selecEleLie.TabIndex = 4016;
            this.m_selecEleLie.TextNull = "";
            this.m_selecEleLie.ElementSelectionneChanged += new System.EventHandler(this.m_selecEleLie_ElementSelectionneChanged);
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLabel, false);
            this.m_lblLabel.Location = new System.Drawing.Point(4, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_lblTypeLiaison
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeLiaison, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeLiaison, false);
            this.m_lblTypeLiaison.Location = new System.Drawing.Point(4, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeLiaison, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeLiaison, "");
            this.m_lblTypeLiaison.Name = "m_lblTypeLiaison";
            this.m_lblTypeLiaison.Size = new System.Drawing.Size(185, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeLiaison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeLiaison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeLiaison.TabIndex = 4005;
            this.m_lblTypeLiaison.Text = "Associate with element type |1206";
            // 
            // m_selectTypeTable
            // 
            this.m_selectTypeTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectTypeTable.ElementSelectionne = null;
            this.m_selectTypeTable.FonctionTextNull = null;
            this.m_selectTypeTable.HasLink = true;
            this.m_selectTypeTable.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeTable, false);
            this.m_selectTypeTable.Location = new System.Drawing.Point(195, 67);
            this.m_selectTypeTable.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeTable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeTable, "");
            this.m_selectTypeTable.Name = "m_selectTypeTable";
            this.m_selectTypeTable.SelectedObject = null;
            this.m_selectTypeTable.Size = new System.Drawing.Size(347, 21);
            this.m_selectTypeTable.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeTable.TabIndex = 4015;
            this.m_selectTypeTable.TextNull = "";
            this.m_selectTypeTable.ElementSelectionneChanged += new System.EventHandler(this.m_selectTypeTable_ElementSelectionneChanged);
            // 
            // m_panErr
            // 
            this.m_panErr.Controls.Add(this.m_txtErrs);
            this.m_panErr.Controls.Add(this.m_lblErr);
            this.m_panErr.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_panErr, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panErr, false);
            this.m_panErr.Location = new System.Drawing.Point(552, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panErr, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panErr, "");
            this.m_panErr.Name = "m_panErr";
            this.m_panErr.Size = new System.Drawing.Size(243, 128);
            this.m_extStyle.SetStyleBackColor(this.m_panErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panErr.TabIndex = 4020;
            this.m_panErr.Visible = false;
            // 
            // m_txtErrs
            // 
            this.m_txtErrs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtErrs.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.m_txtErrs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtErrs.ForeColor = System.Drawing.Color.Red;
            this.m_extLinkField.SetLinkField(this.m_txtErrs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtErrs, false);
            this.m_txtErrs.Location = new System.Drawing.Point(13, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtErrs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtErrs, "");
            this.m_txtErrs.Multiline = true;
            this.m_txtErrs.Name = "m_txtErrs";
            this.m_txtErrs.ReadOnly = true;
            this.m_txtErrs.Size = new System.Drawing.Size(214, 92);
            this.m_extStyle.SetStyleBackColor(this.m_txtErrs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtErrs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtErrs.TabIndex = 4019;
            // 
            // m_lblErr
            // 
            this.m_extLinkField.SetLinkField(this.m_lblErr, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblErr, false);
            this.m_lblErr.Location = new System.Drawing.Point(10, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblErr, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblErr, "");
            this.m_lblErr.Name = "m_lblErr";
            this.m_lblErr.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblErr.TabIndex = 4005;
            this.m_lblErr.Text = "Error|30";
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
            this.m_TabControl.Location = new System.Drawing.Point(8, 202);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageTable;
            this.m_TabControl.Size = new System.Drawing.Size(818, 319);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4005;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageTable,
            this.m_pageForm});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageTable
            // 
            this.m_pageTable.Controls.Add(this.m_btnCopy);
            this.m_pageTable.Controls.Add(this.m_lnkFromExcel);
            this.m_pageTable.Controls.Add(this.m_lnkImporter);
            this.m_pageTable.Controls.Add(this.m_dgDataTable);
            this.m_extLinkField.SetLinkField(this.m_pageTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageTable, false);
            this.m_pageTable.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTable, "");
            this.m_pageTable.Name = "m_pageTable";
            this.m_pageTable.Size = new System.Drawing.Size(802, 278);
            this.m_extStyle.SetStyleBackColor(this.m_pageTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTable.TabIndex = 13;
            this.m_pageTable.Title = "Data|35";
            // 
            // m_btnCopy
            // 
            this.m_btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCopy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnCopy.Image = global::timos.Properties.Resources.copy;
            this.m_extLinkField.SetLinkField(this.m_btnCopy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnCopy, false);
            this.m_btnCopy.Location = new System.Drawing.Point(780, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnCopy, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnCopy, "");
            this.m_btnCopy.Name = "m_btnCopy";
            this.m_btnCopy.Size = new System.Drawing.Size(15, 13);
            this.m_btnCopy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCopy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCopy.TabIndex = 4015;
            this.m_btnCopy.TabStop = false;
            this.m_btnCopy.Click += new System.EventHandler(this.m_btnCopy_Click);
            // 
            // m_lnkFromExcel
            // 
            this.m_lnkFromExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkFromExcel.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkFromExcel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkFromExcel, false);
            this.m_lnkFromExcel.Location = new System.Drawing.Point(559, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFromExcel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkFromExcel, "");
            this.m_lnkFromExcel.Name = "m_lnkFromExcel";
            this.m_lnkFromExcel.Size = new System.Drawing.Size(136, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFromExcel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFromExcel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkFromExcel.TabIndex = 4014;
            this.m_lnkFromExcel.TabStop = true;
            this.m_lnkFromExcel.Text = "SpreadSheet import|20811";
            this.m_lnkFromExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFromExcel_LinkClicked);
            // 
            // m_lnkImporter
            // 
            this.m_lnkImporter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkImporter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkImporter, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkImporter, false);
            this.m_lnkImporter.Location = new System.Drawing.Point(711, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkImporter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkImporter, "");
            this.m_lnkImporter.Name = "m_lnkImporter";
            this.m_lnkImporter.Size = new System.Drawing.Size(67, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkImporter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkImporter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkImporter.TabIndex = 4013;
            this.m_lnkImporter.TabStop = true;
            this.m_lnkImporter.Text = "Import|1279";
            this.m_lnkImporter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkImporter_LinkClicked);
            // 
            // m_dgDataTable
            // 
            this.m_dgDataTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_dgDataTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dgDataTable, false);
            this.m_dgDataTable.Location = new System.Drawing.Point(7, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dgDataTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_dgDataTable, "");
            this.m_dgDataTable.Name = "m_dgDataTable";
            this.m_dgDataTable.Size = new System.Drawing.Size(788, 259);
            this.m_extStyle.SetStyleBackColor(this.m_dgDataTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dgDataTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dgDataTable.TabIndex = 4012;
            this.m_dgDataTable.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.m_dgDataTable_CellPainting);
            this.m_dgDataTable.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_dgDataTable_ColumnWidthChanged);
            this.m_dgDataTable.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_dgDataTable_ColumnAdded);
            // 
            // m_pageForm
            // 
            this.m_pageForm.Controls.Add(this.m_PanelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageForm, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageForm, false);
            this.m_pageForm.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageForm, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageForm, "");
            this.m_pageForm.Name = "m_pageForm";
            this.m_pageForm.Selected = false;
            this.m_pageForm.Size = new System.Drawing.Size(802, 278);
            this.m_extStyle.SetStyleBackColor(this.m_pageForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageForm, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageForm.TabIndex = 14;
            this.m_pageForm.Title = "Form|60";
            // 
            // m_PanelChamps
            // 
            this.m_PanelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChamps.BoldSelectedPage = true;
            this.m_PanelChamps.ElementEdite = null;
            this.m_PanelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelChamps, false);
            this.m_PanelChamps.Location = new System.Drawing.Point(3, 3);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(796, 272);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 2;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_wndListeFormatNumerotation
            // 
            this.m_wndListeFormatNumerotation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFormatNumerotation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn4});
            this.m_wndListeFormatNumerotation.EnableCustomisation = true;
            this.m_wndListeFormatNumerotation.FullRowSelect = true;
            this.m_wndListeFormatNumerotation.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeFormatNumerotation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeFormatNumerotation, false);
            this.m_wndListeFormatNumerotation.Location = new System.Drawing.Point(12, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFormatNumerotation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeFormatNumerotation, "");
            this.m_wndListeFormatNumerotation.MultiSelect = false;
            this.m_wndListeFormatNumerotation.Name = "m_wndListeFormatNumerotation";
            this.m_wndListeFormatNumerotation.Size = new System.Drawing.Size(238, 141);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeFormatNumerotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFormatNumerotation.TabIndex = 4006;
            this.m_wndListeFormatNumerotation.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFormatNumerotation.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "FormatNumerotation.Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Type|54";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 110;
            // 
            // m_extFilterForDataGridView
            // 
            this.m_extFilterForDataGridView.DataGridFiltre = this.m_dgDataTable;
            // 
            // m_extControlEditeurDataGrid
            // 
            this.m_extControlEditeurDataGrid.DataGridViewMappe = this.m_dgDataTable;
            this.m_extControlEditeurDataGrid.SortirSansControle = false;
            this.m_extControlEditeurDataGrid.OnValidationLigne += new timos.tables.EventHandlerValidationLigne(this.extDataGridViewControlMapper1_ValidationLigne);
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 120;
            // 
            // m_reducteurTop
            // 
            this.m_reducteurTop.ControleAgrandit = this.m_TabControl;
            this.m_reducteurTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurTop.ControleReduit = this.m_panOmbre;
            this.m_extLinkField.SetLinkField(this.m_reducteurTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_reducteurTop, false);
            this.m_reducteurTop.Location = new System.Drawing.Point(409, 48);
            this.m_reducteurTop.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurTop, "");
            this.m_reducteurTop.Name = "m_reducteurTop";
            this.m_reducteurTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurTop.TabIndex = 4012;
            this.m_reducteurTop.TailleReduite = 32;
            // 
            // CFormEditionTableParametrable
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_panOmbre);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTableParametrable";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTableParametrable_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTableParametrable_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panOmbre, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_reducteurTop, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panTop.ResumeLayout(false);
            this.m_panGauche.ResumeLayout(false);
            this.m_panGauche.PerformLayout();
            this.m_panErr.ResumeLayout(false);
            this.m_panErr.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageTable.ResumeLayout(false);
            this.m_pageTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnCopy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgDataTable)).EndInit();
            this.m_pageForm.ResumeLayout(false);
            this.ResumeLayout(false);

		}

	
		#endregion

        enum ETypeFichier
        {
            Excel,
            CSV
        }

		public CFormEditionTableParametrable()
            : base()
        {
            InitializeComponent();
			m_extControlEditeurDataGrid.NomsColonnesAMasquer.Add(CTableParametrable.c_strColTimeStamp);
        }
        //-------------------------------------------------------------------------
        public CFormEditionTableParametrable(CTableParametrable tableParametrable)
			: base(tableParametrable)
        {
            InitializeComponent();
			m_extControlEditeurDataGrid.NomsColonnesAMasquer.Add(CTableParametrable.c_strColTimeStamp);
        }
        //-------------------------------------------------------------------------
		public CFormEditionTableParametrable(CTableParametrable tableParametrable, CListeObjetsDonnees liste)
			: base(tableParametrable, liste)
        {
            InitializeComponent();
			m_extControlEditeurDataGrid.NomsColonnesAMasquer.Add(CTableParametrable.c_strColTimeStamp);
		}



		//private DataTable m_dt;
		private bool m_bInitialise;
		//--------------------------------------------------------------------------------------
		private CTableParametrable TableParametrable
        {
			get 
            {
                return (CTableParametrable)ObjetEdite; 
            }
		}

        //---------------------------------------------------------------------------------------
		private DataTable DataTableAffichee
		{
			get
			{
				if (m_dgDataTable.DataSource is DataView)
					return ((DataView)m_dgDataTable.DataSource).Table;
				else if (m_dgDataTable.DataSource is DataTable)
					return (DataTable)m_dgDataTable.DataSource;
				else
					return null;
			}
			set
			{
				try
				{
					if (m_selectTypeTable.ElementSelectionne == null)
						m_oldType = null;
					else
						m_oldType = (CTypeTableParametrable)m_selectTypeTable.ElementSelectionne;
					m_dgDataTable.DataSource = value;
				}
				catch
				{
				}
			}
		}

		private string Erreur
		{
			get
			{
				return m_txtErrs.Text;
			}
			set
			{
				m_panErr.Visible = (value != "");
				m_txtErrs.Text = value;
			}
		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
			m_bInitialise = false;
            m_extControlEditeurDataGrid.SortirSansControle = false;
			m_extControlEditeurDataGrid.ListeControlesAnnulantEdition.Add(this.m_btnAnnulerModifications);
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Custom Table @1|1204", TableParametrable.Libelle));
			m_dgDataTable.ShowCellErrors = true;
			InitComboTypesRelations();

			TableParametrable.ClearDataTableInCache();

			m_selectTypeTable.Init<CTypeTableParametrable>("Libelle",false);
			m_selectTypeTable.ElementSelectionne = TableParametrable.TypeTable;

			if (TableParametrable.ElementLie != null)
			{
				Type t = null;

				if (TableParametrable.ElementLie is CSite)
					t = typeof(CSite);
				else if (TableParametrable.ElementLie is CEquipement)
					t = typeof(CEquipement);

				if (t != null)
				{
					m_selecEleLie.InitForSelect(t, "Libelle", true);
					m_selecEleLie.ElementSelectionne = (CObjetDonnee)TableParametrable.ElementLie;
				}
			}

			//m_extLinkField.FillDialogFromObjet(TableParametrable);
			ActualiserStatut();
			DataTableAffichee = null;
			DataTableAffichee = TableParametrable.DataTableObject;
			m_bInitialise = true;
            return result;
		}

		#region Type Relation
		private class CTypesRelationsPossibles : CEnumALibelle<ETypesRelationsPossibles>
		{
			/// //////////////////////////////////////////////////////
			public CTypesRelationsPossibles(ETypesRelationsPossibles ope)
				: base(ope)
			{
			}

			/// //////////////////////////////////////////////////////
			public override string Libelle
			{
				get
				{
					string result = "";
					switch (Code)
					{
						case ETypesRelationsPossibles.Equipement:
							result = I.T( "Equipment|195");

							break;
						case ETypesRelationsPossibles.Site:
							result = I.T( "Site|227");
							break;
						default:
						case ETypesRelationsPossibles.Aucune:
							result = I.T( "None|148");
							break;
					}
					return result;
				}
			}

		}
		private List<CTypesRelationsPossibles> RelsPoss
		{
			get
			{
				List<CTypesRelationsPossibles> lst = new List<CTypesRelationsPossibles>();
				lst.Add(new CTypesRelationsPossibles(ETypesRelationsPossibles.Aucune));
				lst.Add(new CTypesRelationsPossibles(ETypesRelationsPossibles.Equipement));
				lst.Add(new CTypesRelationsPossibles(ETypesRelationsPossibles.Site));
				return lst;
			}
		}

		private enum ETypesRelationsPossibles
		{
			Equipement,
			Site,
			Aucune,
		}
		private Hashtable m_idxTRels;
		private int m_nLastRel;
		private bool m_bModifSelec = false;

		private void InitComboTypesRelations()
		{
			m_cmbTypeRel.Items.Clear();
			m_idxTRels = new Hashtable();
			foreach (CTypesRelationsPossibles t in RelsPoss)
			{
				m_cmbTypeRel.Items.Add(t.Libelle);
				m_idxTRels.Add(m_cmbTypeRel.Items.Count - 1, t);
			}

			if (TableParametrable.Site != null)
				m_cmbTypeRel.SelectedItem = new CTypesRelationsPossibles(ETypesRelationsPossibles.Site).Libelle;
			else if (TableParametrable.Equipement != null)
				m_cmbTypeRel.SelectedItem = new CTypesRelationsPossibles(ETypesRelationsPossibles.Equipement).Libelle;
			else
			{
				m_selecEleLie.Enabled = false;
				m_cmbTypeRel.SelectedItem = new CTypesRelationsPossibles(ETypesRelationsPossibles.Aucune).Libelle;
			}

			m_nLastRel = m_cmbTypeRel.SelectedIndex;
		}
		private ETypesRelationsPossibles GetRelationSelectionnee()
		{
			if (m_cmbTypeRel.SelectedItem == null)
				return ETypesRelationsPossibles.Aucune;
			else if (m_cmbTypeRel.SelectedItem.ToString() == (new CTypesRelationsPossibles(ETypesRelationsPossibles.Equipement)).Libelle)
				return ETypesRelationsPossibles.Equipement;
			else if (m_cmbTypeRel.SelectedItem.ToString() == (new CTypesRelationsPossibles(ETypesRelationsPossibles.Site)).Libelle)
				return ETypesRelationsPossibles.Site;
			else
				return ETypesRelationsPossibles.Aucune;
		}
		#endregion

		#region Filtres
		//Equipements
		private CFiltreData Filtre_Types_De_Table_Lies_Aux_Equipements
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				CListeObjetsDonnees lstRelEqt = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeEquipement_TypeTableParametrable));
				if (lstRelEqt.CountNoLoad == 0)
					return filtre;

				string strIdsTypesTableLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeEquipement_TypeTableParametrable reqt in lstRelEqt)
					ids[reqt.TypeTableParametrable.Id] = true;
				foreach(int k in ids.Keys)
					strIdsTypesTableLies += k.ToString() + ",";

				if (strIdsTypesTableLies != "")
				{
					strIdsTypesTableLies = strIdsTypesTableLies.Substring(0, strIdsTypesTableLies.Length - 1);
					filtre = new CFiltreData(CTypeTableParametrable.c_champId + " in(" + strIdsTypesTableLies + ")");
				}
				return filtre;
			}
		}
		private CFiltreData Filtre_Types_De_Table_Lies_A_Un_Equipement
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();
				if (m_selecEleLie.ElementSelectionne != null && m_selecEleLie.ElementSelectionne is CEquipement)
					filtre = ((CEquipement)m_selecEleLie.ElementSelectionne).TypesTableParametrablePossibles.GetFiltreForRead();
				return filtre;
			}
		}
		private CFiltreData Filtre_Equipements_Lies_Aux_Types_De_Table
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				CListeObjetsDonnees lstRelEqt = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeEquipement_TypeTableParametrable));
				if (lstRelEqt.CountNoLoad == 0)
					return filtre;

				string strIdsTypesEquipementLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeEquipement_TypeTableParametrable reqt in lstRelEqt)
					ids[reqt.TypeEquipement.Id]= true;
				foreach(int k in ids.Keys)
					strIdsTypesEquipementLies += k.ToString() + ";";

				if (strIdsTypesEquipementLies != "")
				{
					strIdsTypesEquipementLies = strIdsTypesEquipementLies.Substring(0, strIdsTypesEquipementLies.Length - 1);
					filtre = new CFiltreDataAvance(CEquipement.c_nomTable, CTypeEquipement.c_champId + " in(" + strIdsTypesEquipementLies + ")");
				}
				return filtre;
			}
		}
		private CFiltreData Filtre_Equipements_Lies_A_Un_Type_De_Table
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				if (m_selectTypeTable.ElementSelectionne == null)
					return filtre;

				CListeObjetsDonnees lstRelEqt = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeEquipement_TypeTableParametrable),
					new CFiltreData(CTypeTableParametrable.c_champId + " =@1", ((CTypeTableParametrable)m_selectTypeTable.ElementSelectionne).Id.ToString()));
				if (lstRelEqt.CountNoLoad == 0)
					return filtre;

				string strIdsTypesEquipementLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeEquipement_TypeTableParametrable reqt in lstRelEqt)
					 ids[reqt.TypeEquipement.Id] = true;
				foreach(int k in ids.Keys)
					strIdsTypesEquipementLies += k.ToString() + ";";

				if (strIdsTypesEquipementLies != "")
				{
					strIdsTypesEquipementLies = strIdsTypesEquipementLies.Substring(0, strIdsTypesEquipementLies.Length - 1);
					filtre = new CFiltreDataAvance(CEquipement.c_nomTable, CTypeEquipement.c_champId + " in(" + strIdsTypesEquipementLies + ")");
				}

				return filtre;
			}
		}

		//Sites
		private CFiltreData Filtre_Types_De_Table_Lies_Aux_Sites
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				CListeObjetsDonnees lstRelSite = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeSite_TypeTableParametrable));
				if (lstRelSite.CountNoLoad == 0)
					return filtre;

				string strIdsTypesTableLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeSite_TypeTableParametrable rsit in lstRelSite)
					ids[rsit.TypeTableParametrable.Id] = true;
				foreach(int k in ids.Keys)
					strIdsTypesTableLies += k.ToString() + ",";

				if (strIdsTypesTableLies != "")
				{
					strIdsTypesTableLies = strIdsTypesTableLies.Substring(0, strIdsTypesTableLies.Length - 1);
					filtre = new CFiltreData(CTypeTableParametrable.c_champId + " in(" + strIdsTypesTableLies + ")");
				}
				return filtre;
			}
		}
		private CFiltreData Filtre_Types_De_Table_Lies_A_Un_Site
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();
				if (m_selecEleLie.ElementSelectionne != null && m_selecEleLie.ElementSelectionne is CSite)
					filtre = ((CSite)m_selecEleLie.ElementSelectionne).TypesTableParametrablePossibles.GetFiltreForRead();
				return filtre;
			}
		}
		private CFiltreData Filtre_Sites_Lies_Aux_Type_De_Table
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				CListeObjetsDonnees lstRelSite = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeSite_TypeTableParametrable));
				if (lstRelSite.CountNoLoad == 0)
					return filtre;

				string strIdsTypesSitesLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeSite_TypeTableParametrable rsit in lstRelSite)
					ids[rsit.TypeSite.Id] = true;
				foreach(int k in ids.Keys)
					strIdsTypesSitesLies += k.ToString() + ";";

				if (strIdsTypesSitesLies != "")
				{
					strIdsTypesSitesLies = strIdsTypesSitesLies.Substring(0, strIdsTypesSitesLies.Length - 1);
					filtre = new CFiltreDataAvance(CSite.c_nomTable, CTypeSite.c_champId + " in(" + strIdsTypesSitesLies + ")");
				}
				return filtre;
			}
		}
		private CFiltreData Filtre_Sites_Lies_A_Un_Type_De_Table
		{
			get
			{
				CFiltreData filtre = new CFiltreDataImpossible();

				if (m_selectTypeTable.ElementSelectionne == null)
					return filtre;

				CListeObjetsDonnees lstRelSite = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeSite_TypeTableParametrable),
							new CFiltreData(CTypeTableParametrable.c_champId + " =@1", ((CTypeTableParametrable)m_selectTypeTable.ElementSelectionne).Id.ToString()));
				if (lstRelSite.CountNoLoad == 0)
					return filtre;

				string strIdsTypesSitesLies = "";
				Dictionary<int, bool> ids = new Dictionary<int, bool>();
				foreach (CRelationTypeSite_TypeTableParametrable rsit in lstRelSite)
					ids[rsit.TypeSite.Id] = true;
				foreach(int k in ids.Keys)
					strIdsTypesSitesLies += k.ToString() + ";";


				if (strIdsTypesSitesLies != "")
				{
					strIdsTypesSitesLies = strIdsTypesSitesLies.Substring(0, strIdsTypesSitesLies.Length - 1);
					filtre = new CFiltreDataAvance(CSite.c_nomTable, CTypeSite.c_champId + " in(" + strIdsTypesSitesLies + ")");
				}


				return filtre;
			}
		}
		
		#endregion

		//                            [ ETATS POSSIBLES ]
		//
		//				COTE OBJET						  POSSIBLES				   COTE OBJET CORRIGE
		//      __________ ____________ _________       ____________ _________       ____________ _________ 
		//     | RELATION | TYPE TABLE | ELEMENT |     | TYPE TABLE | ELEMENT |     | TYPE TABLE | ELEMENT |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 1A  |  Aucune  |    NULL    |  NULL   |  >  |    TOUS    |  NULL   |  >  |    NULL    |  NULL   |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 1B  |  Aucune  |    NULL    |   OUI   |  >  |    TOUS    |  NULL   |  >  |    NULL    | EFFACE  |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 1C  |  Aucune  |    OUI     |   OUI   |  >  |    TOUS    |  NULL   |  >  |  CONCERVE  | EFFACE  |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 1D  |  Aucune  |    OUI     |  NULL   |  >  |    TOUS    |  NULL   |  >  |  CONCERVE  |  NULL   |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		//     |||||||||||||||||||||||||||||||||||     ||||||||||||||||||||||||     ||||||||||||||||||||||||
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 2A  | Element  |    NULL    |  NULL   |  >  |    TOUS    |  TOUS   |  >  |    NULL    |  NULL   |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 2B  | Element  |    NULL    |   OUI   |  >  | TYPES ELE  |  TOUS   |  >  |    NULL    |CONCERVE |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 2C  | Element  |    OUI     |   OUI   |  >  | TYPES ELE  |  TOUS   |  >  |  CONCERVE  |CONCERVE |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		// 2D  | Element  |    OUI     |  NULL   |  >  |    TOUS    |ELES TYPE|  >  |  CONCERVE  |  NULL   |
		//     |----------|------------|---------|     |------------|---------|     |------------|---------|
		//
		//
		//
		//
		//                                    [ CHANGEMENTS POSSIBLES ]
		//
		//      __________ ____________ _________ ______        __________ ___________________ ______________ 
		//     | RELATION | TYPE TABLE | ELEMENT | VERS |      | RELATION |     TYPE TABLE    |   ELEMENT    |
		//     |----------|------------|---------|------|      |----------|-------------------|--------------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   | //////// | ///////////////// | //////////// |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   | //////// | ///////////////// | //////////// |
		//	   |  Aucune  |    OUI     |   OUI   |      |	   | //////// | ///////////////// | //////////// |
		//	   |  Aucune  |    OUI     |   NULL  |  1A  |	   |  Aucune  | CH.TOUS + SUP     |    GRISER    |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element | CH.TOUS           |    GRISER    |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element | CH.TOUS           | DEL + GRISER |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element | CH.TOUS + CONCERV |   OUI   |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element | CH.TOUS   OUI     |   NULL  |
		//     |----------|------------|---------|------|      |----------|------------|--------------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |      |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Aucune  |    OUI     |   NULL  |  1B  |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  1C  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  1D  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  2A  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  2B  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  2C  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//	   |  Aucune  |    NULL    |   NULL  |      |	   |  Aucune  |    NULL    |   NULL  |
		//	   |  Aucune  |    OUI     |   NULL  |      |	   |  Aucune  |    OUI     |   NULL  |
		//	   |  Aucune  |    NULL    |   OUI   |      |	   |  Aucune  |    NULL    |   OUI   |
		//	   |  Aucune  |    OUI     |   OUI   |  2D  |	   |  Aucune  |    OUI     |   OUI   |
		//	   |  Element |    NULL    |   NULL  |      |	   |  Element |    NULL    |   NULL  |
		//	   |  Element |    OUI     |   NULL  |      |	   |  Element |    OUI     |   NULL  |
		//	   |  Element |    NULL    |   OUI   |      |	   |  Element |    NULL    |   OUI   |
		//	   |  Element |    OUI     |   OUI   |      |      |  Element |    OUI     |   OUI   |
		//     |----------|------------|---------|------|      |----------|------------|---------|
		//
		private void ActualiserStatut()
		{
			Erreur = "";
			m_bModifSelec = true;

			ETypesRelationsPossibles rel = GetRelationSelectionnee();
			switch (rel)
			{
				case ETypesRelationsPossibles.Equipement:
					if (m_selecEleLie.ElementSelectionne is CSite)
						m_selecEleLie.ElementSelectionne = null;

					if (!VerifTypeTablePossiblePourRelationEquipement())
						Erreur = I.T("The custom table type cannot be associated with an equipment|1256");
					else if (!VerifTypeTablePossiblePourEquipement())
						Erreur = I.T("The equipment cannot be associated with a custom table type|1257");
					
					LoadForEquipements();
					break;



				case ETypesRelationsPossibles.Site:

					if (m_selecEleLie.ElementSelectionne is CEquipement)
						m_selecEleLie.ElementSelectionne = null;

					if (!VerifTypeTablePossiblePourRelationSite())
						Erreur = I.T("The custom table type isn't associable with site|1258");
					else if (!VerifTypeTablePossiblePourSite())
						Erreur = I.T("No site cannot be associated with a costum table|1259");

					LoadForSites();
					break;



				case ETypesRelationsPossibles.Aucune:
					m_selecEleLie.Enabled = false;
					TableParametrable.ElementLie = null;
					m_selecEleLie.ElementSelectionne = null;
					m_selectTypeTable.Init<CTypeTableParametrable>(
                        "Libelle", 
                        false);
					break;

				default:
					Erreur = I.T("Unknown relation type |1260");
					break;
			}

			m_bModifSelec = false;
        }


        //------------------------------------------------------------------------------------------------------
        //Verifications
		private bool VerifTypeTablePossiblePourRelationEquipement()
		{
			if (m_selectTypeTable.ElementSelectionne == null)
				return true;

			CListeObjetsDonnees lst = new CListeObjetsDonnees(TableParametrable.ContexteDonnee,typeof(CRelationTypeEquipement_TypeTableParametrable),
				new CFiltreData(CTypeTableParametrable.c_champId + "= @1",((CTypeTableParametrable)m_selectTypeTable.ElementSelectionne).Id.ToString()));
			return lst.CountNoLoad > 0;
		}
        //------------------------------------------------------------------------------------------------------
        private bool VerifTypeTablePossiblePourRelationSite()
		{
			if (m_selectTypeTable.ElementSelectionne == null)
				return true;

			CListeObjetsDonnees lst = new CListeObjetsDonnees(TableParametrable.ContexteDonnee, typeof(CRelationTypeSite_TypeTableParametrable),
				new CFiltreData(CTypeTableParametrable.c_champId + "= @1", ((CTypeTableParametrable)m_selectTypeTable.ElementSelectionne).Id.ToString()));
			return lst.CountNoLoad > 0;
		}

        //-------------------------------------------------------------------------------------------------
        private bool VerifTypeTablePossiblePourEquipement()
		{
			if (m_selecEleLie.ElementSelectionne == null)
				return true;
			return ((CEquipement)m_selecEleLie.ElementSelectionne).TypesTableParametrablePossibles.CountNoLoad > 0;
		}
        
        //------------------------------------------------------------------------------------------------
        private bool VerifTypeTablePossiblePourSite()
		{
			if (m_selecEleLie.ElementSelectionne == null)
				return true;
			return ((CSite)m_selecEleLie.ElementSelectionne).TypesTableParametrablePossibles.CountNoLoad > 0;
		}


        //------------------------------------------------------------------------------------------------------
        //Chargements
		private enum ECasChargementElement
		{
			NoType_NoEle,
			NoType_Ele,
			Type_NoEle,
			Type_Ele,
		}

        //------------------------------------------------------------------------------------------------------
        private ECasChargementElement CasChargementElement
		{
			get
			{
				if (m_selectTypeTable.ElementSelectionne == null && m_selecEleLie.ElementSelectionne == null)
					return ECasChargementElement.NoType_NoEle;
				else if (m_selectTypeTable.ElementSelectionne != null && m_selecEleLie.ElementSelectionne == null)
					return ECasChargementElement.Type_NoEle;
				else if (m_selectTypeTable.ElementSelectionne == null && m_selecEleLie.ElementSelectionne != null)
					return ECasChargementElement.NoType_Ele;
				else if (m_selectTypeTable.ElementSelectionne != null && m_selecEleLie.ElementSelectionne != null)
					return ECasChargementElement.Type_Ele;

				return ECasChargementElement.NoType_NoEle;
			}
		}


        //------------------------------------------------------------------------------------------------------
        private void LoadForEquipements()
		{
			CFiltreData filtreEquipements = null;
			CFiltreData filtreTypes = null;

			switch (CasChargementElement)
			{
				case ECasChargementElement.NoType_Ele:
					//F3 - Tout les types de table compatibles avec le type de l'équipement
					filtreTypes = Filtre_Types_De_Table_Lies_A_Un_Equipement;
					//F2 - Tout les equipements d'un type lies à un type de table
					filtreEquipements = Filtre_Equipements_Lies_Aux_Types_De_Table;

					break;

				case ECasChargementElement.Type_NoEle:
					//F1 - Tout les types de table avec un type d'equipements
					filtreTypes = Filtre_Types_De_Table_Lies_Aux_Equipements;
					//F4 - Tout les equipements liés qui ont un type d'équipement lié au type de table
					filtreEquipements = Filtre_Equipements_Lies_A_Un_Type_De_Table;

					break;


				case ECasChargementElement.NoType_NoEle:
				case ECasChargementElement.Type_Ele:
					//F1 - Tout les types de table avec un type d'equipements
					filtreTypes = Filtre_Types_De_Table_Lies_Aux_Equipements;
					//F2 - Tout les equipements d'un type lies à un type de table
					filtreEquipements = Filtre_Equipements_Lies_Aux_Types_De_Table;
					break;

				default:
					throw new Exception("");
			}
			m_selectTypeTable.InitAvecFiltreDeBase<CTypeTableParametrable>(
                "Libelle", 
                filtreTypes,
                true);
			m_selecEleLie.InitAvecFiltreDeBase<CEquipement>(
                "Libelle", 
                filtreEquipements,
                true);
			m_selecEleLie.Enabled = true;
		}
        //----------------------------------------------------------------------------------------
        private void LoadForSites()
		{
			CFiltreData filtreSites = null;
			CFiltreData filtreTypes = null;

			switch (CasChargementElement)
			{
				case ECasChargementElement.NoType_Ele:
					//F3 - Tout les types de table compatibles avec le type de l'site
					filtreTypes = Filtre_Types_De_Table_Lies_A_Un_Site;
					//F2 - Tout les sites d'un type lies à un type de table
					filtreSites = Filtre_Sites_Lies_Aux_Type_De_Table;

					break;

				case ECasChargementElement.Type_NoEle:
					//F1 - Tout les types de table avec un type d'sites
					filtreTypes = Filtre_Types_De_Table_Lies_Aux_Sites;
					//F4 - Tout les sites liés qui ont un type d'site lié au type de table
					filtreSites = Filtre_Sites_Lies_A_Un_Type_De_Table;

					break;


				case ECasChargementElement.NoType_NoEle:
				case ECasChargementElement.Type_Ele:
					//F1 - Tout les types de table avec un type d'sites
					filtreTypes = Filtre_Types_De_Table_Lies_Aux_Sites;
					//F2 - Tout les sites d'un type lies à un type de table
					filtreSites = Filtre_Sites_Lies_Aux_Type_De_Table;
					break;

				default:
					throw new Exception("");
			}

			m_selectTypeTable.InitAvecFiltreDeBase<CTypeTableParametrable>(
                "Libelle", 
                filtreTypes,
                true);
			m_selecEleLie.InitAvecFiltreDeBase<CSite>(
                "Libelle", 
                filtreSites,
                true);
			m_selecEleLie.Enabled = true;
		}

        //----------------------------------------------------------------------------------------
		private void m_cmbTypeRel_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_bInitialise && !m_bModifSelec)
				ActualiserStatut();
		}

        //----------------------------------------------------------------------------------------
		private CTypeTableParametrable m_oldType;
		private void m_selectTypeTable_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_oldType == m_selectTypeTable.ElementSelectionne)
				return;
			if (m_bInitialise && !m_bModifSelec)
			{
				if (m_selectTypeTable.ElementSelectionne != null)
				{
					CTypeTableParametrable typeSelec = (CTypeTableParametrable)m_selectTypeTable.ElementSelectionne;
					if (typeSelec.Equals(TableParametrable.TypeTable) && TableParametrable.DataTableObject.Columns.Count > 0)
						DataTableAffichee = TableParametrable.DataTableObject;
					else
					{
						if (DataTableAffichee != null && DataTableAffichee.Rows.Count > 0)
						{
							//Voulez vous concerver vos données ?
							if (CFormAlerte.Afficher(I.T("Do you want to export your datas in the new type ?|30008"),EFormAlerteType.Question) == DialogResult.Yes)
							{
								CFormMapTypeTable form = new CFormMapTypeTable();
								//CFormMappageChangementTypeTable form = new CFormMappageChangementTypeTable();
								DataTable dtFinale = typeSelec.GetNewDataTable(TableParametrable.Libelle);
								form.Initialiser(m_oldType, typeSelec, DataTableAffichee, dtFinale);
								if (form.ShowDialog() == DialogResult.OK)
								{
									DataTableAffichee = dtFinale;
									

								}
								else
								{
									m_selectTypeTable.ElementSelectionne = m_oldType;
								}
							}
						}
						else
							DataTableAffichee = typeSelec.GetNewDataTable(TableParametrable.Libelle);
					}
				}
				else
				{
					DataTableAffichee = null;
				}

				if (m_selectTypeTable.ElementSelectionne == null)
					m_oldType = null;
				else
					m_oldType = (CTypeTableParametrable)m_selectTypeTable.ElementSelectionne;

				ActualiserStatut();

			}
		}

        //----------------------------------------------------------------------------------------
        private void m_selecEleLie_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_bInitialise && !m_bModifSelec)
				ActualiserStatut();
		}

		// COLONNES
        //---------------------------------------------------------------------------------------
        private bool m_bModifTailleCol = false;
		void m_dgDataTable_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if (m_bInitialise && !m_bModifTailleCol && e.Column != null && e.Column.Index > 0 && TableParametrable.TypeTable != null)
			{
				CListeObjetsDonnees cols = TableParametrable.TypeTable.Colonnes;
				foreach(CColonneTableParametrable c in cols)
					if (c.Libelle == e.Column.Name)
					{
						c.BeginEdit();
						c.LargeurColonne = e.Column.Width;
						c.CommitEdit();
						break;
					}
			}
		}
        
        //---------------------------------------------------------------------------------------
        void m_dgDataTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
		{
			if (e.Column != null && e.Column.Index > 0 && TableParametrable.TypeTable != null)
			{
				CListeObjetsDonnees cols = TableParametrable.TypeTable.Colonnes;
				foreach (CColonneTableParametrable c in cols)
					if (c.Libelle == e.Column.Name)
					{
						m_bModifTailleCol = true;
						e.Column.Width = c.LargeurColonne > 0?c.LargeurColonne:100;
						m_bModifTailleCol = false;
						break;
					}
			}
		}


		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if (result)
			{
				TableParametrable.ElementLie = (IElementATableParametrable)m_selecEleLie.ElementSelectionne;
				TableParametrable.TypeTable = (CTypeTableParametrable)m_selectTypeTable.ElementSelectionne;
				DataTable changes = DataTableAffichee.GetChanges();
				if ( changes != null && changes.Rows.Count != 0  )
					TableParametrable.DataTableObject = DataTableAffichee;
				//result = m_extLinkField.FillObjetFromDialog(TableParametrable);
			}
			return result;
		}

        //---------------------------------------------------------------------------------------
		private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, EventArgs e)
		{
			m_dgDataTable.ReadOnly = !m_gestionnaireModeEdition.ModeEdition;
			m_dgDataTable.AllowUserToAddRows = m_gestionnaireModeEdition.ModeEdition;
			m_dgDataTable.AllowUserToDeleteRows = m_gestionnaireModeEdition.ModeEdition;
		}

        //---------------------------------------------------------------------------------------
        private void extDataGridViewControlMapper1_ValidationLigne(bool valide, string messErr)
		{
			if (m_bInitialise)
			{
				Erreur = messErr;
			}
		}

        //---------------------------------------------------------------------------------------
        private void m_lnkImporter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (!(m_selectTypeTable.ElementSelectionne is CTypeTableParametrable))
			{
				CFormAlerte.Afficher(I.T("Select a table type first|1281"), EFormAlerteType.Exclamation);
				return;
			}
			TableParametrable.TypeTable = (CTypeTableParametrable)m_selectTypeTable.ElementSelectionne;
            // Récupère le paramétrage d'import CSV
            CParametreLectureCSV parametreCSV = new CParametreLectureCSV();
            if (TableParametrable.TypeTable.ParametrageCSV != null)
				parametreCSV = TableParametrable.TypeTable.ParametrageCSV;
            // Récupère le paramétrage d'import Excel (XLS)
            CParametreLectureExcel parametreXLS = new CParametreLectureExcel();
            if (TableParametrable.TypeTable.ParametrageXLS != null)
                parametreXLS = TableParametrable.TypeTable.ParametrageXLS;

            IParametreLectureFichier parametre = null;

			int nEtape = 0;
			string strFichier = "";
			CResultAErreur result = CResultAErreur.True;
			DataTable tableToImport = null;
			CImportTableParametrableMode mode = null;
			Dictionary<DataColumn, CColonneTableParametrable> mappage = new Dictionary<DataColumn,CColonneTableParametrable>();
            ETypeFichier typeFichier = ETypeFichier.CSV;
            while (true)
			{
				switch (nEtape)
				{
					case 0://Sélection du fichier
						OpenFileDialog dlg = new OpenFileDialog();
						dlg.Filter = I.T("Excel File|*.xls;*.xlsx|CSV file|*.csv|Text file|*.txt|All files|*.*|1280");
						if (dlg.ShowDialog() == DialogResult.Cancel)
							return;
                        strFichier = dlg.FileName;
                        int nPositionduPoint = strFichier.LastIndexOf('.');
                        string strExtension = strFichier.Substring(nPositionduPoint + 1, strFichier.Length - nPositionduPoint - 1);
                        if (strExtension.ToUpper() == "XLS" || strExtension.ToUpper() == "XLSX")
                        {
                            typeFichier = ETypeFichier.Excel;
                            parametre = parametreXLS;
                        }
                        else
                        {
                            typeFichier = ETypeFichier.CSV;
                            parametre = parametreCSV;
                        }
						nEtape++;
						break;

					case 1://Paramétrage de la lecture CSV
                        if (typeFichier == ETypeFichier.Excel)
                        {
                            if (!CFormOptionsImportExcel1.FillOptions(parametreXLS, strFichier))
                                nEtape--;
                            else
                                nEtape++;
                        }
                        else
                        {
                            if (!CFormOptionsCSV1.FillOptions(parametreCSV, strFichier))
                                nEtape--;
                            else
                                nEtape++;
                        }
						break;

					case 2://Lecture du fichier
                        result = parametre.LectureFichier(strFichier);
                        if (!result)
                        {
                            CFormAlerte.Afficher(result.Erreur);
                            nEtape--;
                        }
                        else
                        {
                            tableToImport = (DataTable)result.Data;
                            nEtape++;
                        }
                        
						break;


					case 3 ://Mappage des colonnes
						ArrayList listeDataCol = new ArrayList(tableToImport.Columns);
						ArrayList listeColPar = new ArrayList(TableParametrable.TypeTable.Colonnes);
						if (!CFormMappageStringsStrings.MapperStringsAvecObjets(listeDataCol, "ColumnName",
							listeColPar, "Libelle", parametre.Mappage))
							nEtape=1;
						else
						{
							mappage.Clear();
							for ( int nLigne = 0; nLigne < Math.Min ( listeDataCol.Count, listeColPar.Count ); nLigne++ )
								mappage.Add ( (DataColumn)listeDataCol[nLigne],(CColonneTableParametrable)listeColPar[nLigne]);
							nEtape++;
						}
						break;


					case 4://Mode d'importation
						if (!CFormModeImport.ChoisirModeImport(ref mode))
							nEtape= nEtape-2;
						nEtape++;
						break;


					case 5:
						result = TableParametrable.ImportTable(tableToImport, mappage, mode);
						if (!result)
						{
                            DialogResult dlgResult = CFormAlerte.Afficher(result.Erreur, EModeAffichageErreurs.AvecIgnorer);
                            if (dlgResult == DialogResult.Cancel)
                            {
                                nEtape--;
                                continue;
                            }
						}
						m_dgDataTable.DataSource = TableParametrable.DataTableObject;
                        TableParametrable.TypeTable.ParametrageCSV = parametreCSV;
                        TableParametrable.TypeTable.ParametrageXLS = parametreXLS;
						m_dgDataTable.Refresh();
						return;
				}
			}
		}

        //---------------------------------------------------------------------------------------
        private CResultAErreur CFormEditionTableParametrable_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageForm)
				{
					m_PanelChamps.ElementEdite = TableParametrable;
				}
				else if (page == m_pageTable)
				{
					DataTableAffichee = TableParametrable.DataTableObject;
				}
			}
			return result;
		}

        //---------------------------------------------------------------------------------------
        private CResultAErreur CFormEditionTableParametrable_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageForm)
			{
				result = m_PanelChamps.MAJ_Champs();
			}
			else if (page == m_pageTable)
			{
				if (DataTableAffichee != null)
				{
					DataTableAffichee.TableName = TableParametrable.Libelle;
					TableParametrable.DataTableObject = DataTableAffichee;
				}
			}
			return result;
		}

		private void m_dgDataTable_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
			if (e.RowIndex == -1 && e.ColumnIndex != -1)
			{
				DataGridViewColumn dgvCol = m_dgDataTable.Columns[e.ColumnIndex];
				Color c = Color.Black;
				SolidBrush brush = new SolidBrush(c);
				e.Graphics.FillRectangle(brush, e.CellBounds);
				SolidBrush brushBorder = new SolidBrush(Color.White);
				Pen crayonBorder = new Pen(brushBorder, 1);
				e.Graphics.DrawRectangle(crayonBorder, e.CellBounds);

				SolidBrush brushTexte = new SolidBrush(Color.White);
				StringFormat formatTexte = new StringFormat();
				formatTexte.Alignment = StringAlignment.Center;
				formatTexte.LineAlignment = StringAlignment.Center;
				e.Graphics.DrawString(dgvCol.Name,m_dgDataTable.DefaultCellStyle.Font, brushTexte, e.CellBounds, formatTexte);

				crayonBorder.Dispose();
				brushBorder.Dispose();
				brushTexte.Dispose();
				brush.Dispose();
			
				m_extControlEditeurDataGrid.DrawIco(e);
				m_extFilterForDataGridView.DrawIco(e);
				e.Handled = true;
			}
		}

        public override bool QueryClose()
        {
            bool bResult = base.QueryClose();
            if (bResult)
            {
                m_extControlEditeurDataGrid.SortirSansControle = true;
            }
            return bResult;
        }

        //-------------------------------------------------------------------------------------------
        private void m_lnkFromExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTypeTableParametrable typeTable = m_selectTypeTable.ElementSelectionne as CTypeTableParametrable;
            if ( typeTable == null )
            {
                MessageBox.Show(I.T("Select a table type first|20812"));
                return;
            }
            DataTable table = typeTable.GetNewDataTable("IMPORT");
            table = CFormPasteTableFromExcel.PasteFromSpreadSheet ( table );
            if ( table != null )
            {
                DataTableAffichee = table;
            }
        }

        private void m_btnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder bl = new StringBuilder();
            if ( DataTableAffichee != null )
            {
                foreach ( DataColumn col in DataTableAffichee.Columns )
                {
                    bl.Append ( col.ColumnName );
                    bl.Append('\t');
                }
                bl.Append(Environment.NewLine);
                foreach ( DataRow row in DataTableAffichee.Rows )
                {
                    foreach ( DataColumn col in DataTableAffichee.Columns )
                    {
                        object val = row[col];
                        if ( val != DBNull.Value )
                        {
                            bl.Append(val.ToString().Replace("\t",""));
                        }
                        bl.Append('\t');
                    }
                    bl.Append(Environment.NewLine);
                }
                Clipboard.SetText ( bl.ToString() );
            }
                            
        }

	}
}

