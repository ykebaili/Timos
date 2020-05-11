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
using timos.data.supervision;
using futurocom.supervision;

namespace timos.supervision
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeAlarme))]
	public class CFormEditionTypeAlarme : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private CArbreObjetHierarchique m_ArbreHierarchique;
        private Label label2;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabSousTypes;
        private Crownwood.Magic.Controls.TabPage m_tabChamps;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private CPanelListeSpeedStandard m_panelSousTypes;
        private Panel panel1;
        private Label label3;
        private C2iComboBox m_cmbEtatDepuisFils;
        private Crownwood.Magic.Controls.TabPage m_tabSetupAlarmes;
        private Label label4;
        private Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleActions;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelle;
        private C2iComboBox m_cmbEtatInitial;
        private Label label6;
        private Panel m_panelConteneurGererChamps;
        private LinkLabel m_lnkNewChampCustom;
        private C2iNumericUpDown m_numUpDownOrdre;
        private Label label7;
        private CPanelListeRelationSelection m_panelListeChampsCustom;
        private C2iPanel m_panelChamps;
        private PictureBox pictureBox5;
        private CheckBox m_chkKey;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Label label8;
        private CComboBoxListeObjetsDonnees m_cmbxSelectSeverite;
        private Panel m_panelCouleurSeverite;
        private GroupBox groupBox1;
        private Label label9;
        private CheckBox checkBox1;
        private ListBox m_wndListeCles;
        private C2iSelectImage m_imageSelect;
        private CheckBox m_chkAAcquitter;
        private Label label11;
        private Label label10;
        private C2iComboBox m_cmbTypeSupervise;
        private Label label12;
        private Crownwood.Magic.Controls.TabPage m_tabPageFormulaire;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelValeursChamps;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeAlarme()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAlarme(CTypeAlarme TypeAlarme)
			:base(TypeAlarme)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAlarme(CTypeAlarme TypeAlarme, CListeObjetsDonnees liste)
			:base(TypeAlarme, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeAlarme));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelCouleurSeverite = new System.Windows.Forms.Panel();
            this.m_cmbxSelectSeverite = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_ArbreHierarchique = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_panelValeursChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_tabSousTypes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSousTypes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmbEtatDepuisFils = new sc2i.win32.common.C2iComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tabChamps = new Crownwood.Magic.Controls.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_wndListeCles = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_panelChamps = new sc2i.win32.common.C2iPanel(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.m_chkKey = new System.Windows.Forms.CheckBox();
            this.m_panelListeChampsCustom = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_numUpDownOrdre = new sc2i.win32.common.C2iNumericUpDown();
            this.m_lnkNewChampCustom = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_tabSetupAlarmes = new Crownwood.Magic.Controls.TabPage();
            this.m_cmbTypeSupervise = new sc2i.win32.common.C2iComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.m_chkAAcquitter = new System.Windows.Forms.CheckBox();
            this.m_imageSelect = new sc2i.win32.common.C2iSelectImage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.m_txtFormuleActions = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_cmbEtatInitial = new sc2i.win32.common.C2iComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_panelConteneurGererChamps = new System.Windows.Forms.Panel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageFormulaire.SuspendLayout();
            this.m_tabSousTypes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_tabChamps.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_panelChamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).BeginInit();
            this.m_tabSetupAlarmes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).BeginInit();
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
            this.m_txtLibelle.Location = new System.Drawing.Point(88, 9);
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
            this.c2iPanelOmbre4.Controls.Add(this.m_panelCouleurSeverite);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxSelectSeverite);
            this.c2iPanelOmbre4.Controls.Add(this.m_ArbreHierarchique);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label8);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 38);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(818, 127);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_panelCouleurSeverite
            // 
            this.m_panelCouleurSeverite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.m_panelCouleurSeverite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_extLinkField.SetLinkField(this.m_panelCouleurSeverite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCouleurSeverite, false);
            this.m_panelCouleurSeverite.Location = new System.Drawing.Point(346, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCouleurSeverite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCouleurSeverite, "");
            this.m_panelCouleurSeverite.Name = "m_panelCouleurSeverite";
            this.m_panelCouleurSeverite.Size = new System.Drawing.Size(20, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelCouleurSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCouleurSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCouleurSeverite.TabIndex = 4010;
            // 
            // m_cmbxSelectSeverite
            // 
            this.m_cmbxSelectSeverite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxSelectSeverite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectSeverite.ElementSelectionne = null;
            this.m_cmbxSelectSeverite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbxSelectSeverite.FormattingEnabled = true;
            this.m_cmbxSelectSeverite.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectSeverite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxSelectSeverite, false);
            this.m_cmbxSelectSeverite.ListDonnees = null;
            this.m_cmbxSelectSeverite.Location = new System.Drawing.Point(88, 41);
            this.m_cmbxSelectSeverite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectSeverite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectSeverite, "");
            this.m_cmbxSelectSeverite.Name = "m_cmbxSelectSeverite";
            this.m_cmbxSelectSeverite.NullAutorise = true;
            this.m_cmbxSelectSeverite.ProprieteAffichee = null;
            this.m_cmbxSelectSeverite.ProprieteParentListeObjets = null;
            this.m_cmbxSelectSeverite.SelectionneurParent = null;
            this.m_cmbxSelectSeverite.Size = new System.Drawing.Size(239, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectSeverite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectSeverite.TabIndex = 4009;
            this.m_cmbxSelectSeverite.TextNull = "(None)";
            this.m_cmbxSelectSeverite.Tri = true;
            this.m_cmbxSelectSeverite.SelectedIndexChanged += new System.EventHandler(this.m_cmbxSelectSeverite_SelectedIndexChanged);
            // 
            // m_ArbreHierarchique
            // 
            this.m_ArbreHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ArbreHierarchique.AutoriseReaffectation = true;
            this.m_ArbreHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_ArbreHierarchique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ArbreHierarchique, false);
            this.m_ArbreHierarchique.Location = new System.Drawing.Point(467, 9);
            this.m_ArbreHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ArbreHierarchique, "");
            this.m_ArbreHierarchique.Name = "m_ArbreHierarchique";
            this.m_ArbreHierarchique.Size = new System.Drawing.Size(319, 85);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreHierarchique.TabIndex = 4008;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(377, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Hierarchy|20262";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(12, 45);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4002;
            this.label8.Text = "Severity|10217";
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 171);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_tabSousTypes;
            this.m_tabControl.Size = new System.Drawing.Size(818, 356);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageFormulaire,
            this.m_tabSousTypes,
            this.m_tabChamps,
            this.m_tabSetupAlarmes});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_tabPageFormulaire
            // 
            this.m_tabPageFormulaire.Controls.Add(this.m_panelValeursChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageFormulaire, false);
            this.m_tabPageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageFormulaire, "");
            this.m_tabPageFormulaire.Name = "m_tabPageFormulaire";
            this.m_tabPageFormulaire.Selected = false;
            this.m_tabPageFormulaire.Size = new System.Drawing.Size(802, 315);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageFormulaire.TabIndex = 13;
            this.m_tabPageFormulaire.Title = "Forms|60";
            // 
            // m_panelValeursChamps
            // 
            this.m_panelValeursChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelValeursChamps.BoldSelectedPage = true;
            this.m_panelValeursChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelValeursChamps.ElementEdite = null;
            this.m_panelValeursChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelValeursChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelValeursChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelValeursChamps, false);
            this.m_panelValeursChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelValeursChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelValeursChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelValeursChamps, "");
            this.m_panelValeursChamps.Name = "m_panelValeursChamps";
            this.m_panelValeursChamps.Ombre = false;
            this.m_panelValeursChamps.PositionTop = true;
            this.m_panelValeursChamps.Size = new System.Drawing.Size(802, 315);
            this.m_extStyle.SetStyleBackColor(this.m_panelValeursChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelValeursChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelValeursChamps.TabIndex = 3;
            this.m_panelValeursChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabSousTypes
            // 
            this.m_tabSousTypes.Controls.Add(this.m_panelSousTypes);
            this.m_tabSousTypes.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_tabSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabSousTypes, false);
            this.m_tabSousTypes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabSousTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabSousTypes, "");
            this.m_tabSousTypes.Name = "m_tabSousTypes";
            this.m_tabSousTypes.Size = new System.Drawing.Size(802, 315);
            this.m_extStyle.SetStyleBackColor(this.m_tabSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabSousTypes.TabIndex = 10;
            this.m_tabSousTypes.Title = "Alarm sub-types|20263";
            // 
            // m_panelSousTypes
            // 
            this.m_panelSousTypes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelSousTypes.AffectationsPourNouveauxElements")));
            this.m_panelSousTypes.AllowArbre = true;
            this.m_panelSousTypes.AllowCustomisation = true;
            this.m_panelSousTypes.AllowSerializePreferences = true;
            glColumn2.ActiveControlItems = null;
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Libelle";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelSousTypes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelSousTypes.ContexteUtilisation = "";
            this.m_panelSousTypes.ControlFiltreStandard = null;
            this.m_panelSousTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSousTypes.ElementSelectionne = null;
            this.m_panelSousTypes.EnableCustomisation = true;
            this.m_panelSousTypes.FiltreDeBase = null;
            this.m_panelSousTypes.FiltreDeBaseEnAjout = false;
            this.m_panelSousTypes.FiltrePrefere = null;
            this.m_panelSousTypes.FiltreRapide = null;
            this.m_panelSousTypes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSousTypes, false);
            this.m_panelSousTypes.ListeObjets = null;
            this.m_panelSousTypes.Location = new System.Drawing.Point(0, 30);
            this.m_panelSousTypes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousTypes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelSousTypes.ModeQuickSearch = false;
            this.m_panelSousTypes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelSousTypes, "");
            this.m_panelSousTypes.MultiSelect = false;
            this.m_panelSousTypes.Name = "m_panelSousTypes";
            this.m_panelSousTypes.Navigateur = null;
            this.m_panelSousTypes.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelSousTypes.ProprieteObjetAEditer = null;
            this.m_panelSousTypes.QuickSearchText = "";
            this.m_panelSousTypes.ShortIcons = false;
            this.m_panelSousTypes.Size = new System.Drawing.Size(802, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousTypes.TabIndex = 2;
            this.m_panelSousTypes.TrierAuClicSurEnteteColonne = true;
            this.m_panelSousTypes.UseCheckBoxes = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmbEtatDepuisFils);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 30);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_cmbEtatDepuisFils
            // 
            this.m_cmbEtatDepuisFils.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtatDepuisFils.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbEtatDepuisFils.FormattingEnabled = true;
            this.m_cmbEtatDepuisFils.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbEtatDepuisFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbEtatDepuisFils, false);
            this.m_cmbEtatDepuisFils.Location = new System.Drawing.Point(197, 4);
            this.m_cmbEtatDepuisFils.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEtatDepuisFils, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbEtatDepuisFils, "");
            this.m_cmbEtatDepuisFils.Name = "m_cmbEtatDepuisFils";
            this.m_cmbEtatDepuisFils.Size = new System.Drawing.Size(308, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEtatDepuisFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEtatDepuisFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEtatDepuisFils.TabIndex = 1;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "State from childs|20264";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_tabChamps
            // 
            this.m_tabChamps.Controls.Add(this.groupBox1);
            this.m_tabChamps.Controls.Add(this.m_panelChamps);
            this.m_tabChamps.Controls.Add(this.m_panelEditChamps);
            this.m_extLinkField.SetLinkField(this.m_tabChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabChamps, false);
            this.m_tabChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabChamps, "");
            this.m_tabChamps.Name = "m_tabChamps";
            this.m_tabChamps.Selected = false;
            this.m_tabChamps.Size = new System.Drawing.Size(802, 315);
            this.m_extStyle.SetStyleBackColor(this.m_tabChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabChamps.TabIndex = 11;
            this.m_tabChamps.Title = "Custom fields|198";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.m_wndListeCles);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.groupBox1.Location = new System.Drawing.Point(579, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 309);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key fields|20334";
            // 
            // m_wndListeCles
            // 
            this.m_wndListeCles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeCles.FormattingEnabled = true;
            this.m_extLinkField.SetLinkField(this.m_wndListeCles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeCles, false);
            this.m_wndListeCles.Location = new System.Drawing.Point(7, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeCles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeCles, "");
            this.m_wndListeCles.Name = "m_wndListeCles";
            this.m_wndListeCles.Size = new System.Drawing.Size(207, 225);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeCles.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "RegrouperSurLaCle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(7, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(124, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Group on key|20335";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelChamps.Controls.Add(this.label9);
            this.m_panelChamps.Controls.Add(this.pictureBox5);
            this.m_panelChamps.Controls.Add(this.m_chkKey);
            this.m_panelChamps.Controls.Add(this.m_panelListeChampsCustom);
            this.m_panelChamps.Controls.Add(this.m_numUpDownOrdre);
            this.m_panelChamps.Controls.Add(this.m_lnkNewChampCustom);
            this.m_panelChamps.Controls.Add(this.label7);
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(292, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Size = new System.Drawing.Size(280, 315);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(211, 13);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 13;
            this.label9.Text = "Fields available on mediation device|20287";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = global::timos.Properties.Resources.cle;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.pictureBox5.Location = new System.Drawing.Point(229, 287);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // m_chkKey
            // 
            this.m_chkKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_chkKey, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkKey, false);
            this.m_chkKey.Location = new System.Drawing.Point(207, 288);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkKey, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkKey, "");
            this.m_chkKey.Name = "m_chkKey";
            this.m_chkKey.Size = new System.Drawing.Size(19, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkKey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkKey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkKey.TabIndex = 10;
            this.m_chkKey.Text = "checkBox1";
            this.m_chkKey.UseVisualStyleBackColor = true;
            // 
            // m_panelListeChampsCustom
            // 
            this.m_panelListeChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeChampsCustom.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelListeChampsCustom.EnableCustomisation = true;
            this.m_panelListeChampsCustom.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeChampsCustom, false);
            this.m_panelListeChampsCustom.Location = new System.Drawing.Point(17, 31);
            this.m_panelListeChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelListeChampsCustom, "");
            this.m_panelListeChampsCustom.Name = "m_panelListeChampsCustom";
            this.m_panelListeChampsCustom.Size = new System.Drawing.Size(248, 253);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeChampsCustom.TabIndex = 5;
            this.m_panelListeChampsCustom.OnValideRelation += new sc2i.win32.data.navigation.AssocieDataEventHandler(this.m_panelListeChampsCustom_OnValideRelation);
            this.m_panelListeChampsCustom.OnSelectionChanged += new sc2i.win32.data.navigation.ObjetSelecionneeChangedEventHandler(this.m_panelListeChampsCustom_OnSelectionChanged);
            this.m_panelListeChampsCustom.OnAssocieData += new sc2i.win32.data.navigation.AssocieDataEventHandler(this.m_panelListeChampsCustom_OnAssocieData);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name|64";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_numUpDownOrdre
            // 
            this.m_numUpDownOrdre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_numUpDownOrdre.DoubleValue = 0;
            this.m_numUpDownOrdre.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numUpDownOrdre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numUpDownOrdre, false);
            this.m_numUpDownOrdre.Location = new System.Drawing.Point(93, 285);
            this.m_numUpDownOrdre.LockEdition = false;
            this.m_numUpDownOrdre.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpDownOrdre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_numUpDownOrdre, "");
            this.m_numUpDownOrdre.Name = "m_numUpDownOrdre";
            this.m_numUpDownOrdre.Size = new System.Drawing.Size(82, 21);
            this.m_extStyle.SetStyleBackColor(this.m_numUpDownOrdre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numUpDownOrdre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numUpDownOrdre.TabIndex = 9;
            this.m_numUpDownOrdre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpDownOrdre.ThousandsSeparator = true;
            // 
            // m_lnkNewChampCustom
            // 
            this.m_lnkNewChampCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkNewChampCustom.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkNewChampCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkNewChampCustom, false);
            this.m_lnkNewChampCustom.Location = new System.Drawing.Point(137, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkNewChampCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkNewChampCustom, "");
            this.m_lnkNewChampCustom.Name = "m_lnkNewChampCustom";
            this.m_lnkNewChampCustom.Size = new System.Drawing.Size(128, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNewChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNewChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNewChampCustom.TabIndex = 4;
            this.m_lnkNewChampCustom.TabStop = true;
            this.m_lnkNewChampCustom.Text = "Field management|20275";
            this.m_lnkNewChampCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNewChampCustom_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(23, 287);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 8;
            this.label7.Text = "Order|20276";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(584, 315);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 1;
            // 
            // m_tabSetupAlarmes
            // 
            this.m_tabSetupAlarmes.Controls.Add(this.m_cmbTypeSupervise);
            this.m_tabSetupAlarmes.Controls.Add(this.label10);
            this.m_tabSetupAlarmes.Controls.Add(this.m_chkAAcquitter);
            this.m_tabSetupAlarmes.Controls.Add(this.m_imageSelect);
            this.m_tabSetupAlarmes.Controls.Add(this.label12);
            this.m_tabSetupAlarmes.Controls.Add(this.label11);
            this.m_tabSetupAlarmes.Controls.Add(this.m_txtFormuleActions);
            this.m_tabSetupAlarmes.Controls.Add(this.m_txtFormuleLibelle);
            this.m_tabSetupAlarmes.Controls.Add(this.m_cmbEtatInitial);
            this.m_tabSetupAlarmes.Controls.Add(this.label6);
            this.m_tabSetupAlarmes.Controls.Add(this.label5);
            this.m_tabSetupAlarmes.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_tabSetupAlarmes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabSetupAlarmes, false);
            this.m_tabSetupAlarmes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabSetupAlarmes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabSetupAlarmes, "");
            this.m_tabSetupAlarmes.Name = "m_tabSetupAlarmes";
            this.m_tabSetupAlarmes.Selected = false;
            this.m_tabSetupAlarmes.Size = new System.Drawing.Size(802, 315);
            this.m_extStyle.SetStyleBackColor(this.m_tabSetupAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabSetupAlarmes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabSetupAlarmes.TabIndex = 12;
            this.m_tabSetupAlarmes.Title = "Alarms setup|20265";
            // 
            // m_cmbTypeSupervise
            // 
            this.m_cmbTypeSupervise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSupervise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbTypeSupervise.FormattingEnabled = true;
            this.m_cmbTypeSupervise.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSupervise, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeSupervise, false);
            this.m_cmbTypeSupervise.Location = new System.Drawing.Point(210, 5);
            this.m_cmbTypeSupervise.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSupervise, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSupervise, "");
            this.m_cmbTypeSupervise.Name = "m_cmbTypeSupervise";
            this.m_cmbTypeSupervise.Size = new System.Drawing.Size(271, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSupervise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSupervise, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSupervise.TabIndex = 17;
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(25, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(182, 21);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 16;
            this.label10.Text = "Supervised element|20366";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkAAcquitter
            // 
            this.m_chkAAcquitter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAAcquitter, "AAcquitter");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAAcquitter, true);
            this.m_chkAAcquitter.Location = new System.Drawing.Point(397, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAAcquitter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAAcquitter, "");
            this.m_chkAAcquitter.Name = "m_chkAAcquitter";
            this.m_chkAAcquitter.Size = new System.Drawing.Size(138, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAAcquitter.TabIndex = 15;
            this.m_chkAAcquitter.Text = "To Acknowledge|10250";
            this.m_chkAAcquitter.UseVisualStyleBackColor = true;
            // 
            // m_imageSelect
            // 
            this.m_imageSelect.BackColor = System.Drawing.Color.White;
            this.m_imageSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_imageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_imageSelect, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageSelect, false);
            this.m_imageSelect.Location = new System.Drawing.Point(210, 113);
            this.m_imageSelect.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_imageSelect, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_imageSelect, "");
            this.m_imageSelect.Name = "m_imageSelect";
            this.m_imageSelect.Size = new System.Drawing.Size(24, 23);
            this.m_imageSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_extStyle.SetStyleBackColor(this.m_imageSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_imageSelect.TabIndex = 14;
            this.m_imageSelect.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoEllipsis = true;
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(240, 116);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(526, 20);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 13;
            this.label12.Text = "(Displayed in the Current Alarms consultation window)|10283";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoEllipsis = true;
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(25, 116);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 13;
            this.label11.Text = "Alarm icon|10282";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtFormuleActions
            // 
            this.m_txtFormuleActions.AllowGraphic = true;
            this.m_txtFormuleActions.AllowNullFormula = false;
            this.m_txtFormuleActions.AllowSaisieTexte = true;
            this.m_txtFormuleActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleActions.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleActions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleActions, false);
            this.m_txtFormuleActions.Location = new System.Drawing.Point(210, 32);
            this.m_txtFormuleActions.LockEdition = false;
            this.m_txtFormuleActions.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleActions, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleActions, "");
            this.m_txtFormuleActions.Name = "m_txtFormuleActions";
            this.m_txtFormuleActions.Size = new System.Drawing.Size(582, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleActions.TabIndex = 6;
            this.m_txtFormuleActions.Enter += new System.EventHandler(this.m_txtFormuleActions_Enter);
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.AllowGraphic = true;
            this.m_txtFormuleLibelle.AllowNullFormula = false;
            this.m_txtFormuleLibelle.AllowSaisieTexte = true;
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleLibelle, false);
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(210, 56);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleLibelle, "");
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(582, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 5;
            this.m_txtFormuleLibelle.Enter += new System.EventHandler(this.m_txtFormuleLibelle_Enter);
            // 
            // m_cmbEtatInitial
            // 
            this.m_cmbEtatInitial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEtatInitial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbEtatInitial.FormattingEnabled = true;
            this.m_cmbEtatInitial.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbEtatInitial, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbEtatInitial, false);
            this.m_cmbEtatInitial.Location = new System.Drawing.Point(210, 83);
            this.m_cmbEtatInitial.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEtatInitial, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbEtatInitial, "");
            this.m_cmbEtatInitial.Name = "m_cmbEtatInitial";
            this.m_cmbEtatInitial.Size = new System.Drawing.Size(121, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEtatInitial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEtatInitial, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEtatInitial.TabIndex = 4;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(25, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 21);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 3;
            this.label6.Text = "Initial state|20268";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(25, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 21);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Alarm label|20267";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(25, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Actions on parent alarm|20266";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelConteneurGererChamps
            // 
            this.m_extLinkField.SetLinkField(this.m_panelConteneurGererChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelConteneurGererChamps, false);
            this.m_panelConteneurGererChamps.Location = new System.Drawing.Point(322, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConteneurGererChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConteneurGererChamps, "");
            this.m_panelConteneurGererChamps.Name = "m_panelConteneurGererChamps";
            this.m_panelConteneurGererChamps.Size = new System.Drawing.Size(327, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelConteneurGererChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConteneurGererChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConteneurGererChamps.TabIndex = 11;
            // 
            // CFormEditionTypeAlarme
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeAlarme";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAlarme_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAlarme_OnMajChampsPage);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.m_tabPageFormulaire.ResumeLayout(false);
            this.m_tabSousTypes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_tabChamps.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_panelChamps.ResumeLayout(false);
            this.m_panelChamps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).EndInit();
            this.m_tabSetupAlarmes.ResumeLayout(false);
            this.m_tabSetupAlarmes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeAlarme TypeAlarme
		{
			get
			{
				return (CTypeAlarme)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            m_bPageChampInit = false;
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Alarm Type @1|10289", TypeAlarme.Libelle));

            CListeObjetsDonnees listeSeverites = new CListeObjetsDonnees(TypeAlarme.ContexteDonnee, typeof(CSeveriteAlarme));
            m_cmbxSelectSeverite.Init(listeSeverites, "Libelle", true);
            m_cmbxSelectSeverite.NullAutorise = true;
            m_cmbxSelectSeverite.TextNull = I.T("(None)|148");
            m_cmbxSelectSeverite.ElementSelectionne = TypeAlarme.Severite;

            m_cmbTypeSupervise.DataSource = CEnumALibelle<ETypeElementSupervise>.GetValeursEnumPossibleInEnumALibelle(typeof(CTypeElementSupervise));
            m_cmbTypeSupervise.SelectedItem = TypeAlarme.TypeElementSupervise;

            m_ArbreHierarchique.AfficheHierarchie(TypeAlarme);
            m_cmbEtatDepuisFils.BeginUpdate();
            m_cmbEtatDepuisFils.Items.Clear();
            foreach (CModeCalculEtatParent mode in CModeCalculEtatParent.GetValeursEnumPossibleInEnumALibelle(typeof(CModeCalculEtatParent)))
                m_cmbEtatDepuisFils.Items.Add(mode);
            m_cmbEtatDepuisFils.EndUpdate();
            m_cmbEtatDepuisFils.SelectedItem = TypeAlarme.ModeCalculEtatParent;

            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeAlarme.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_tabControl.TabPages.Contains(m_tabPageFormulaire))
                    m_tabControl.TabPages.Remove(m_tabPageFormulaire);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_tabPageFormulaire))
                    m_tabControl.TabPages.Insert(0, m_tabPageFormulaire);
            }

			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            TypeAlarme.Severite = m_cmbxSelectSeverite.ElementSelectionne as CSeveriteAlarme;
            if (m_cmbTypeSupervise.SelectedItem is CTypeElementSupervise)
                TypeAlarme.TypeElementSupervise = m_cmbTypeSupervise.SelectedItem as CTypeElementSupervise;

            return result;
        }

        private bool m_bPageChampInit = false;
        private CResultAErreur CFormEditionTypeAlarme_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_tabSousTypes)
			{
				m_panelSousTypes.InitFromListeObjets(
				TypeAlarme.TypesFils,
				typeof(CTypeAlarme),
				typeof(CFormEditionTypeAlarme),
				TypeAlarme,
				"TypeParent");
			}
            else if (page == m_tabChamps)
            {
                m_panelEditChamps.InitPanel(
                    TypeAlarme,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
                InitPanelChamps();
                m_bPageChampInit = true;
                FillListeChampsCles(TypeAlarme);
            }
            if (page == m_tabPageFormulaire)
                m_panelValeursChamps.ElementEdite = TypeAlarme;
            else if (page == m_tabSetupAlarmes)
            {
                m_txtFormuleLibelle.Formule = TypeAlarme.FormuleCalculLibelle;
                m_cmbEtatInitial.BeginUpdate();
                m_cmbEtatInitial.Items.Clear();

                foreach ( CEtatAlarme etat in CEtatAlarme.GetValeursEnumPossibleInEnumALibelle(typeof(CEtatAlarme)))
                    m_cmbEtatInitial.Items.Add ( etat );
                m_cmbEtatInitial.EndUpdate();
                m_cmbEtatInitial.SelectedItem = TypeAlarme.EtatInitial;
                m_txtFormuleActions.Formule = TypeAlarme.FormuleCalculActionsSurParent;
                m_imageSelect.Image = TypeAlarme.Image;
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeAlarme_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_tabChamps)
            {
                result = m_panelEditChamps.MAJ_Champs();
                if (result)
                    m_panelListeChampsCustom.ApplyModifs();
            }
            else if (page == m_tabSousTypes)
            {
                if (m_cmbEtatDepuisFils.SelectedItem is CModeCalculEtatParent)
                    TypeAlarme.ModeCalculEtatParent = (CModeCalculEtatParent)m_cmbEtatDepuisFils.SelectedItem;
            }
            else if (page == m_tabSetupAlarmes)
            {
                if (m_txtFormuleActions.Formule != null)
                    TypeAlarme.FormuleCalculActionsSurParent = m_txtFormuleActions.Formule;
                if (m_txtFormuleLibelle.Formule != null)
                    TypeAlarme.FormuleCalculLibelle = m_txtFormuleLibelle.Formule;
                if (m_cmbEtatInitial.SelectedItem is CEtatAlarme)
                    TypeAlarme.EtatInitial = (CEtatAlarme)m_cmbEtatInitial.SelectedItem;
                TypeAlarme.Image = m_imageSelect.Image;

            }
            else if (page == m_tabPageFormulaire)
                result = m_panelValeursChamps.MAJ_Champs();
            return result;
        }

        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------------------------------
        private void m_txtFormuleActions_Enter(object sender, EventArgs e)
        {
            if (m_bPageChampInit)
            {
                m_panelEditChamps.MAJ_Champs();
            }
            CLocalTypeAlarme typeAlarme = TypeAlarme.GetTypeForSupervision(null, false);
            m_txtFormuleActions.Init(typeAlarme, typeof(CLocalAlarme));
        }

        //-------------------------------------------------------------------------
        private void m_txtFormuleLibelle_Enter(object sender, EventArgs e)
        {
            if (m_bPageChampInit)
            {
                m_panelEditChamps.MAJ_Champs();
            }
            CLocalTypeAlarme typeAlarme = TypeAlarme.GetTypeForSupervision(null, false);
            m_txtFormuleLibelle.Init(typeAlarme, typeof(CLocalAlarme));
        }

        //-------------------------------------------------------------------------
        private void m_lnkNewChampCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormNavigateurPopupListe.Show(new CFormListeChampsCustom(CAlarme.c_roleChampCustom));
            InitPanelChamps();
        }

        //-------------------------------------------------------------------------
        private void InitPanelChamps()
        {
            m_champCustom = null;
            CListeObjetsDonnees listeChamps = new CListeObjetsDonnees(TypeAlarme.ContexteDonnee, typeof(CChampCustom));
            listeChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CAlarme.c_roleChampCustom);

            m_panelListeChampsCustom.Init(
                listeChamps,
                TypeAlarme.RelationsChampsCustomListe,
                TypeAlarme,
                "Definisseur",
                "ChampCustom"
                );
        }

        private class CDataAssocie
        {
            public bool IsKey { get; set; }
            public int Ordre { get; set; }
            public CDataAssocie(bool bIsKey, int nOrdre)
            {
                IsKey = bIsKey;
                Ordre = nOrdre;
            }
        }

        /// ////////////////////////////////////////////////////////////////////////
        private void m_panelListeChampsCustom_OnAssocieData(sc2i.data.CObjetDonnee objet, sc2i.data.CObjetDonnee relation, ref object dataAAssocier)
        {
            if (relation == null)
                dataAAssocier = new CDataAssocie ( false, 0);
            else
            {
                CRelationTypeAlarme_ChampCustom rel = relation as CRelationTypeAlarme_ChampCustom;
                if ( rel != null )
                {
                    dataAAssocier = new CDataAssocie(rel.IsKey, rel.Ordre);
                }
            }
        }

        private CChampCustom m_champCustom = null;
        /// ////////////////////////////////////////////////////////////////////////
        private void m_panelListeChampsCustom_OnSelectionChanged(sc2i.data.CObjetDonnee objet, object dataAssocie)
        {
            if (m_champCustom != null)
                m_panelListeChampsCustom.SetDataAssocie(m_champCustom,
                    new CDataAssocie ( m_chkKey.Checked, m_numUpDownOrdre.IntValue));
            m_champCustom = objet as CChampCustom;
            CDataAssocie data = m_panelListeChampsCustom.GetDataAssocie(objet) as CDataAssocie;
            if (data != null)
            {
                m_numUpDownOrdre.IntValue = data.Ordre;
                m_chkKey.Checked = data.IsKey;
            }
            else
            {
                m_numUpDownOrdre.IntValue = 0;
                m_chkKey.Checked = false;
            }
        }

        private void m_panelListeChampsCustom_OnValideRelation(sc2i.data.CObjetDonnee objet, sc2i.data.CObjetDonnee relation, ref object dataAssocie)
        {
            CChampCustom champ = objet as CChampCustom;
            CDataAssocie dataType = dataAssocie as CDataAssocie;
            if (relation != null && dataType != null)
            {
                ((CRelationTypeAlarme_ChampCustom)relation).Ordre = dataType.Ordre;
                ((CRelationTypeAlarme_ChampCustom)relation).IsKey = dataType.IsKey;
            }
        }

        private void m_cmbxSelectSeverite_SelectedIndexChanged(object sender, EventArgs e)
        {
            CSeveriteAlarme severite = m_cmbxSelectSeverite.ElementSelectionne as CSeveriteAlarme;
            if (severite == null)
                m_panelCouleurSeverite.BackColor = Color.Transparent;
            else
                m_panelCouleurSeverite.BackColor = severite.Couleur;
        }

        private void FillListeChampsCles(CTypeAlarme typeAlarme)
        {
            if ( typeAlarme.Id== TypeAlarme.Id )
                m_wndListeCles.Items.Clear();
            foreach (CRelationTypeAlarme_ChampCustom rel in typeAlarme.RelationsChampsCustomDefinis)
            {
                if (rel.IsKey)
                {
                    if (m_wndListeCles.Items.Count == 0)
                        m_wndListeCles.Items.Add(rel.ChampCustom.Nom);
                    else
                        m_wndListeCles.Items.Insert(0, rel.ChampCustom.Nom);
                }
            }
            if (typeAlarme.TypeParent != null)
                FillListeChampsCles(typeAlarme.TypeParent);
        }

        
	}
}

