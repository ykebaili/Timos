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
using timos.data;
using System.Threading;
using sc2i.data.dynamic.Macro;
using timos.macro;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CVersionDonnees))]
	public class CFormEditionVersionDonnees : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageElementsModifies;
		private Crownwood.Magic.Controls.TabPage m_pagesSousVersions;
		private Label label2;
		private Label label3;
		private LinkLabel m_lnkVersionsParente;
		private CPanelListeSpeedStandard m_panelElementsModifies;
		private CPanelListeSpeedStandard m_panelVersionsFilles;
		private Panel m_panelVersionParente;
		private LinkLabel m_lnkTravaillerDansVersion;
		private LinkLabel m_lnkAnnulerModificationsObjet;
		private Crownwood.Magic.Controls.TabPage m_pageInterventions;
		private CPanelListeSpeedStandard m_panelInterventions;
		private LinkLabel m_lnkAppliquer;
		private CWndLinkStd m_btnDetailModification;
		private LinkLabel m_lnkToutAnnuler;
		private Panel panel1;
		private Panel m_panelArchive;
		private LinkLabel m_lnkCreatePrevisionnelle;
		private Panel m_panelPrevisionnelle;
        private C2iPanelFondDegradeStd m_panelBarreMenuListeModifs;
		private Label label4;
		private CComboBoxLinkListeObjetsDonnees m_cmbCategorie;
        private LinkLabel m_lnkMacro;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionVersionDonnees()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionVersionDonnees(CVersionDonnees VersionDonnees)
			:base(VersionDonnees)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionVersionDonnees(CVersionDonnees VersionDonnees, CListeObjetsDonnees liste)
			:base(VersionDonnees, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionVersionDonnees));
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbCategorie = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelArchive = new System.Windows.Forms.Panel();
            this.m_lnkCreatePrevisionnelle = new System.Windows.Forms.LinkLabel();
            this.m_panelPrevisionnelle = new System.Windows.Forms.Panel();
            this.m_lnkAppliquer = new System.Windows.Forms.LinkLabel();
            this.m_lnkTravaillerDansVersion = new System.Windows.Forms.LinkLabel();
            this.m_panelVersionParente = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkVersionsParente = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageElementsModifies = new Crownwood.Magic.Controls.TabPage();
            this.m_panelBarreMenuListeModifs = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_lnkToutAnnuler = new System.Windows.Forms.LinkLabel();
            this.m_btnDetailModification = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAnnulerModificationsObjet = new System.Windows.Forms.LinkLabel();
            this.m_panelElementsModifies = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pagesSousVersions = new Crownwood.Magic.Controls.TabPage();
            this.m_panelVersionsFilles = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageInterventions = new Crownwood.Magic.Controls.TabPage();
            this.m_panelInterventions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_lnkMacro = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelArchive.SuspendLayout();
            this.m_panelPrevisionnelle.SuspendLayout();
            this.m_panelVersionParente.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageElementsModifies.SuspendLayout();
            this.m_panelBarreMenuListeModifs.SuspendLayout();
            this.m_pagesSousVersions.SuspendLayout();
            this.m_pageInterventions.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(801, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(693, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(976, 28);
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
            this.label1.Location = new System.Drawing.Point(9, 11);
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
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
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
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkMacro);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbCategorie);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.panel1);
            this.c2iPanelOmbre4.Controls.Add(this.m_panelVersionParente);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(968, 92);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_cmbCategorie
            // 
            this.m_cmbCategorie.ComportementLinkStd = true;
            this.m_cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCategorie.ElementSelectionne = null;
            this.m_cmbCategorie.FormattingEnabled = true;
            this.m_cmbCategorie.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbCategorie, "");
            this.m_cmbCategorie.LinkProperty = "";
            this.m_cmbCategorie.ListDonnees = null;
            this.m_cmbCategorie.Location = new System.Drawing.Point(133, 45);
            this.m_cmbCategorie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCategorie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCategorie, "");
            this.m_cmbCategorie.Name = "m_cmbCategorie";
            this.m_cmbCategorie.NullAutorise = true;
            this.m_cmbCategorie.ProprieteAffichee = null;
            this.m_cmbCategorie.ProprieteParentListeObjets = null;
            this.m_cmbCategorie.SelectionneurParent = null;
            this.m_cmbCategorie.Size = new System.Drawing.Size(278, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCategorie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCategorie.TabIndex = 4008;
            this.m_cmbCategorie.TextNull = "";
            this.m_cmbCategorie.Tri = true;
            this.m_cmbCategorie.TypeFormEdition = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(9, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4007;
            this.label4.Text = "Version category|20039";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_panelArchive);
            this.panel1.Controls.Add(this.m_panelPrevisionnelle);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(423, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 46);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4006;
            // 
            // m_panelArchive
            // 
            this.m_panelArchive.Controls.Add(this.m_lnkCreatePrevisionnelle);
            this.m_panelArchive.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelArchive, "");
            this.m_panelArchive.Location = new System.Drawing.Point(234, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelArchive, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelArchive, "");
            this.m_panelArchive.Name = "m_panelArchive";
            this.m_panelArchive.Size = new System.Drawing.Size(210, 46);
            this.m_extStyle.SetStyleBackColor(this.m_panelArchive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelArchive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelArchive.TabIndex = 7;
            // 
            // m_lnkCreatePrevisionnelle
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkCreatePrevisionnelle, "");
            this.m_lnkCreatePrevisionnelle.Location = new System.Drawing.Point(1, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreatePrevisionnelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreatePrevisionnelle, "");
            this.m_lnkCreatePrevisionnelle.Name = "m_lnkCreatePrevisionnelle";
            this.m_lnkCreatePrevisionnelle.Size = new System.Drawing.Size(201, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreatePrevisionnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreatePrevisionnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreatePrevisionnelle.TabIndex = 4007;
            this.m_lnkCreatePrevisionnelle.TabStop = true;
            this.m_lnkCreatePrevisionnelle.Text = "Create a future version|20015";
            this.m_lnkCreatePrevisionnelle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreatePrevisionnelle_LinkClicked);
            // 
            // m_panelPrevisionnelle
            // 
            this.m_panelPrevisionnelle.Controls.Add(this.m_lnkAppliquer);
            this.m_panelPrevisionnelle.Controls.Add(this.m_lnkTravaillerDansVersion);
            this.m_panelPrevisionnelle.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelPrevisionnelle, "");
            this.m_panelPrevisionnelle.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPrevisionnelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelPrevisionnelle, "");
            this.m_panelPrevisionnelle.Name = "m_panelPrevisionnelle";
            this.m_panelPrevisionnelle.Size = new System.Drawing.Size(234, 46);
            this.m_extStyle.SetStyleBackColor(this.m_panelPrevisionnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPrevisionnelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPrevisionnelle.TabIndex = 6;
            // 
            // m_lnkAppliquer
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkAppliquer, "");
            this.m_lnkAppliquer.Location = new System.Drawing.Point(-1, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAppliquer, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAppliquer, "");
            this.m_lnkAppliquer.Name = "m_lnkAppliquer";
            this.m_lnkAppliquer.Size = new System.Drawing.Size(229, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAppliquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAppliquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAppliquer.TabIndex = 4007;
            this.m_lnkAppliquer.TabStop = true;
            this.m_lnkAppliquer.Text = "Apply this version|1384";
            this.m_lnkAppliquer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAppliquer_LinkClicked);
            // 
            // m_lnkTravaillerDansVersion
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkTravaillerDansVersion, "");
            this.m_lnkTravaillerDansVersion.Location = new System.Drawing.Point(-1, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTravaillerDansVersion, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTravaillerDansVersion, "");
            this.m_lnkTravaillerDansVersion.Name = "m_lnkTravaillerDansVersion";
            this.m_lnkTravaillerDansVersion.Size = new System.Drawing.Size(229, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTravaillerDansVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTravaillerDansVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTravaillerDansVersion.TabIndex = 4006;
            this.m_lnkTravaillerDansVersion.TabStop = true;
            this.m_lnkTravaillerDansVersion.Text = "Work with this version|1335";
            this.m_lnkTravaillerDansVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTravaillerDansVersion_LinkClicked);
            // 
            // m_panelVersionParente
            // 
            this.m_panelVersionParente.Controls.Add(this.label3);
            this.m_panelVersionParente.Controls.Add(this.m_lnkVersionsParente);
            this.m_extLinkField.SetLinkField(this.m_panelVersionParente, "");
            this.m_panelVersionParente.Location = new System.Drawing.Point(4, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelVersionParente, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelVersionParente, "");
            this.m_panelVersionParente.Name = "m_panelVersionParente";
            this.m_panelVersionParente.Size = new System.Drawing.Size(412, 23);
            this.m_extStyle.SetStyleBackColor(this.m_panelVersionParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVersionParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVersionParente.TabIndex = 4005;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Based on|1332";
            // 
            // m_lnkVersionsParente
            // 
            this.m_lnkVersionsParente.BackColor = System.Drawing.Color.White;
            this.m_lnkVersionsParente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lnkVersionsParente, "");
            this.m_lnkVersionsParente.Location = new System.Drawing.Point(127, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkVersionsParente, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkVersionsParente, "");
            this.m_lnkVersionsParente.Name = "m_lnkVersionsParente";
            this.m_lnkVersionsParente.Size = new System.Drawing.Size(280, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkVersionsParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkVersionsParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkVersionsParente.TabIndex = 5;
            this.m_lnkVersionsParente.TabStop = true;
            this.m_lnkVersionsParente.Text = "linkLabel1";
            this.m_lnkVersionsParente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkVersionsParente_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 3;
            this.label2.Text = "Label|50";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageElementsModifies;
            this.m_tabControl.Size = new System.Drawing.Size(968, 382);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageElementsModifies,
            this.m_pagesSousVersions,
            this.m_pageInterventions});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageElementsModifies
            // 
            this.m_pageElementsModifies.Controls.Add(this.m_panelBarreMenuListeModifs);
            this.m_pageElementsModifies.Controls.Add(this.m_panelElementsModifies);
            this.m_extLinkField.SetLinkField(this.m_pageElementsModifies, "");
            this.m_pageElementsModifies.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElementsModifies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElementsModifies, "");
            this.m_pageElementsModifies.Name = "m_pageElementsModifies";
            this.m_pageElementsModifies.Size = new System.Drawing.Size(952, 341);
            this.m_extStyle.SetStyleBackColor(this.m_pageElementsModifies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElementsModifies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElementsModifies.TabIndex = 10;
            this.m_pageElementsModifies.Title = "Modified elements|1330";
            // 
            // m_panelBarreMenuListeModifs
            // 
            this.m_panelBarreMenuListeModifs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelBarreMenuListeModifs.BackgroundImage")));
            this.m_panelBarreMenuListeModifs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelBarreMenuListeModifs.Controls.Add(this.m_lnkToutAnnuler);
            this.m_panelBarreMenuListeModifs.Controls.Add(this.m_btnDetailModification);
            this.m_panelBarreMenuListeModifs.Controls.Add(this.m_lnkAnnulerModificationsObjet);
            this.m_extLinkField.SetLinkField(this.m_panelBarreMenuListeModifs, "");
            this.m_panelBarreMenuListeModifs.Location = new System.Drawing.Point(194, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBarreMenuListeModifs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelBarreMenuListeModifs, "");
            this.m_panelBarreMenuListeModifs.Name = "m_panelBarreMenuListeModifs";
            this.m_panelBarreMenuListeModifs.Size = new System.Drawing.Size(448, 26);
            this.m_extStyle.SetStyleBackColor(this.m_panelBarreMenuListeModifs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBarreMenuListeModifs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBarreMenuListeModifs.TabIndex = 6;
            // 
            // m_lnkToutAnnuler
            // 
            this.m_lnkToutAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.m_extLinkField.SetLinkField(this.m_lnkToutAnnuler, "");
            this.m_lnkToutAnnuler.Location = new System.Drawing.Point(319, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkToutAnnuler, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkToutAnnuler, "");
            this.m_lnkToutAnnuler.Name = "m_lnkToutAnnuler";
            this.m_lnkToutAnnuler.Size = new System.Drawing.Size(141, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkToutAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkToutAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkToutAnnuler.TabIndex = 5;
            this.m_lnkToutAnnuler.TabStop = true;
            this.m_lnkToutAnnuler.Text = "Cancel all|1403";
            this.m_lnkToutAnnuler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkToutAnnuler_LinkClicked);
            // 
            // m_btnDetailModification
            // 
            this.m_btnDetailModification.BackColor = System.Drawing.Color.Transparent;
            this.m_btnDetailModification.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDetailModification.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnDetailModification, "");
            this.m_btnDetailModification.Location = new System.Drawing.Point(15, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDetailModification, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnDetailModification, "");
            this.m_btnDetailModification.Name = "m_btnDetailModification";
            this.m_btnDetailModification.Size = new System.Drawing.Size(85, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnDetailModification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDetailModification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDetailModification.TabIndex = 4;
            this.m_btnDetailModification.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnDetailModification.LinkClicked += new System.EventHandler(this.m_btnDetailModification_LinkClicked);
            // 
            // m_lnkAnnulerModificationsObjet
            // 
            this.m_lnkAnnulerModificationsObjet.BackColor = System.Drawing.Color.Transparent;
            this.m_extLinkField.SetLinkField(this.m_lnkAnnulerModificationsObjet, "");
            this.m_lnkAnnulerModificationsObjet.Location = new System.Drawing.Point(105, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAnnulerModificationsObjet, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAnnulerModificationsObjet, "");
            this.m_lnkAnnulerModificationsObjet.Name = "m_lnkAnnulerModificationsObjet";
            this.m_lnkAnnulerModificationsObjet.Size = new System.Drawing.Size(192, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAnnulerModificationsObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAnnulerModificationsObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAnnulerModificationsObjet.TabIndex = 3;
            this.m_lnkAnnulerModificationsObjet.TabStop = true;
            this.m_lnkAnnulerModificationsObjet.Text = "Cancel selected changes|1371";
            this.m_lnkAnnulerModificationsObjet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAnnulerModificationsObjet_LinkClicked);
            // 
            // m_panelElementsModifies
            // 
            this.m_panelElementsModifies.AllowArbre = true;
            this.m_panelElementsModifies.AllowCustomisation = true;
            this.m_panelElementsModifies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelElementsModifies.BoutonAjouterVisible = false;
            this.m_panelElementsModifies.BoutonModifierVisible = false;
            this.m_panelElementsModifies.BoutonSupprimerVisible = false;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "Element.DescriptionElement";
            glColumn3.Text = "Element|1333";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 250;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Namex";
            glColumn4.Propriete = "TypeOperation.Libelle";
            glColumn4.Text = "operation type|1334";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.m_panelElementsModifies.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3,
            glColumn4});
            this.m_panelElementsModifies.ContexteUtilisation = "";
            this.m_panelElementsModifies.ControlFiltreStandard = null;
            this.m_panelElementsModifies.ElementSelectionne = null;
            this.m_panelElementsModifies.EnableCustomisation = true;
            this.m_panelElementsModifies.FiltreDeBase = null;
            this.m_panelElementsModifies.FiltreDeBaseEnAjout = false;
            this.m_panelElementsModifies.FiltrePrefere = null;
            this.m_panelElementsModifies.FiltreRapide = null;
            this.m_panelElementsModifies.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelElementsModifies, "");
            this.m_panelElementsModifies.ListeObjets = null;
            this.m_panelElementsModifies.Location = new System.Drawing.Point(1, 0);
            this.m_panelElementsModifies.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelElementsModifies, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelElementsModifies.ModeQuickSearch = false;
            this.m_panelElementsModifies.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelElementsModifies, "");
            this.m_panelElementsModifies.MultiSelect = false;
            this.m_panelElementsModifies.Name = "m_panelElementsModifies";
            this.m_panelElementsModifies.Navigateur = null;
            this.m_panelElementsModifies.ProprieteObjetAEditer = null;
            this.m_panelElementsModifies.QuickSearchText = "";
            this.m_panelElementsModifies.Size = new System.Drawing.Size(950, 341);
            this.m_extStyle.SetStyleBackColor(this.m_panelElementsModifies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelElementsModifies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelElementsModifies.TabIndex = 2;
            this.m_panelElementsModifies.TrierAuClicSurEnteteColonne = true;
            this.m_panelElementsModifies.UseCheckBoxes = false;
            this.m_panelElementsModifies.OnChangeSelection += new System.EventHandler(this.m_panelElementsModifies_OnChangeSelection);
            // 
            // m_pagesSousVersions
            // 
            this.m_pagesSousVersions.Controls.Add(this.m_panelVersionsFilles);
            this.m_extLinkField.SetLinkField(this.m_pagesSousVersions, "");
            this.m_pagesSousVersions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagesSousVersions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagesSousVersions, "");
            this.m_pagesSousVersions.Name = "m_pagesSousVersions";
            this.m_pagesSousVersions.Selected = false;
            this.m_pagesSousVersions.Size = new System.Drawing.Size(952, 341);
            this.m_extStyle.SetStyleBackColor(this.m_pagesSousVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagesSousVersions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagesSousVersions.TabIndex = 11;
            this.m_pagesSousVersions.Title = "Dependent versions|1331";
            // 
            // m_panelVersionsFilles
            // 
            this.m_panelVersionsFilles.AllowArbre = true;
            this.m_panelVersionsFilles.AllowCustomisation = true;
            this.m_panelVersionsFilles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Name";
            glColumn5.Propriete = "Libelle";
            glColumn5.Text = "Label|50";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 250;
            this.m_panelVersionsFilles.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn5});
            this.m_panelVersionsFilles.ContexteUtilisation = "";
            this.m_panelVersionsFilles.ControlFiltreStandard = null;
            this.m_panelVersionsFilles.ElementSelectionne = null;
            this.m_panelVersionsFilles.EnableCustomisation = true;
            this.m_panelVersionsFilles.FiltreDeBase = null;
            this.m_panelVersionsFilles.FiltreDeBaseEnAjout = false;
            this.m_panelVersionsFilles.FiltrePrefere = null;
            this.m_panelVersionsFilles.FiltreRapide = null;
            this.m_panelVersionsFilles.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelVersionsFilles, "");
            this.m_panelVersionsFilles.ListeObjets = null;
            this.m_panelVersionsFilles.Location = new System.Drawing.Point(1, 0);
            this.m_panelVersionsFilles.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelVersionsFilles, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelVersionsFilles.ModeQuickSearch = false;
            this.m_panelVersionsFilles.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelVersionsFilles, "");
            this.m_panelVersionsFilles.MultiSelect = false;
            this.m_panelVersionsFilles.Name = "m_panelVersionsFilles";
            this.m_panelVersionsFilles.Navigateur = null;
            this.m_panelVersionsFilles.ProprieteObjetAEditer = null;
            this.m_panelVersionsFilles.QuickSearchText = "";
            this.m_panelVersionsFilles.Size = new System.Drawing.Size(950, 341);
            this.m_extStyle.SetStyleBackColor(this.m_panelVersionsFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelVersionsFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVersionsFilles.TabIndex = 3;
            this.m_panelVersionsFilles.TrierAuClicSurEnteteColonne = true;
            this.m_panelVersionsFilles.UseCheckBoxes = false;
            // 
            // m_pageInterventions
            // 
            this.m_pageInterventions.Controls.Add(this.m_panelInterventions);
            this.m_extLinkField.SetLinkField(this.m_pageInterventions, "");
            this.m_pageInterventions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInterventions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInterventions, "");
            this.m_pageInterventions.Name = "m_pageInterventions";
            this.m_pageInterventions.Selected = false;
            this.m_pageInterventions.Size = new System.Drawing.Size(952, 341);
            this.m_extStyle.SetStyleBackColor(this.m_pageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInterventions.TabIndex = 12;
            this.m_pageInterventions.Title = "Interventions|1383";
            // 
            // m_panelInterventions
            // 
            this.m_panelInterventions.AllowArbre = true;
            this.m_panelInterventions.AllowCustomisation = true;
            this.m_panelInterventions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelInterventions.BoutonAjouterVisible = false;
            this.m_panelInterventions.BoutonSupprimerVisible = false;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 250;
            this.m_panelInterventions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelInterventions.ContexteUtilisation = "";
            this.m_panelInterventions.ControlFiltreStandard = null;
            this.m_panelInterventions.ElementSelectionne = null;
            this.m_panelInterventions.EnableCustomisation = true;
            this.m_panelInterventions.FiltreDeBase = null;
            this.m_panelInterventions.FiltreDeBaseEnAjout = false;
            this.m_panelInterventions.FiltrePrefere = null;
            this.m_panelInterventions.FiltreRapide = null;
            this.m_panelInterventions.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelInterventions, "");
            this.m_panelInterventions.ListeObjets = null;
            this.m_panelInterventions.Location = new System.Drawing.Point(1, 0);
            this.m_panelInterventions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelInterventions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelInterventions.ModeQuickSearch = false;
            this.m_panelInterventions.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelInterventions, "");
            this.m_panelInterventions.MultiSelect = false;
            this.m_panelInterventions.Name = "m_panelInterventions";
            this.m_panelInterventions.Navigateur = null;
            this.m_panelInterventions.ProprieteObjetAEditer = null;
            this.m_panelInterventions.QuickSearchText = "";
            this.m_panelInterventions.Size = new System.Drawing.Size(950, 341);
            this.m_extStyle.SetStyleBackColor(this.m_panelInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelInterventions.TabIndex = 4;
            this.m_panelInterventions.TrierAuClicSurEnteteColonne = true;
            this.m_panelInterventions.UseCheckBoxes = false;
            // 
            // m_lnkMacro
            // 
            this.m_lnkMacro.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkMacro, "");
            this.m_lnkMacro.Location = new System.Drawing.Point(425, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkMacro, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkMacro, "");
            this.m_lnkMacro.Name = "m_lnkMacro";
            this.m_lnkMacro.Size = new System.Drawing.Size(122, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMacro, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMacro, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMacro.TabIndex = 4009;
            this.m_lnkMacro.TabStop = true;
            this.m_lnkMacro.Text = "Créer une macro (TEST)";
            this.m_lnkMacro.Visible = false;
            this.m_lnkMacro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMacro_LinkClicked);
            // 
            // CFormEditionVersionDonnees
            // 
            this.ClientSize = new System.Drawing.Size(976, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionVersionDonnees";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionVersionDonnees_OnInitPage);
            this.Load += new System.EventHandler(this.CFormEditionVersionDonnees_Load);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionVersionDonnees_OnMajChampsPage);
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
            this.panel1.ResumeLayout(false);
            this.m_panelArchive.ResumeLayout(false);
            this.m_panelPrevisionnelle.ResumeLayout(false);
            this.m_panelVersionParente.ResumeLayout(false);
            this.m_panelVersionParente.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageElementsModifies.ResumeLayout(false);
            this.m_panelBarreMenuListeModifs.ResumeLayout(false);
            this.m_pagesSousVersions.ResumeLayout(false);
            this.m_pageInterventions.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CVersionDonnees VersionDonnees
		{
			get
			{
				return (CVersionDonnees)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			if (VersionDonnees.IsNew())
				VersionDonnees.CodeTypeVersion = (int)CTypeVersion.TypeVersion.Previsionnelle;
			if (VersionDonnees.VersionParente != null)
			{
				m_lnkVersionsParente.Text = VersionDonnees.VersionParente.Libelle;
				m_panelVersionParente.Visible = true;
			}
			else
				m_panelVersionParente.Visible = false;
			m_panelPrevisionnelle.Visible = VersionDonnees.CodeTypeVersion == (int)CTypeVersion.TypeVersion.Previsionnelle;
			m_panelArchive.Visible = VersionDonnees.CodeTypeVersion == (int)CTypeVersion.TypeVersion.Archive ||
				VersionDonnees.CodeTypeVersion == (int)CTypeVersion.TypeVersion.Etiquette;
			if (VersionDonnees.CodeTypeVersion == (int)CTypeVersion.TypeVersion.Previsionnelle)
			{
				if (!m_tabControl.TabPages.Contains(m_pagesSousVersions))
					m_tabControl.TabPages.Add(m_pagesSousVersions);
				if (!m_tabControl.TabPages.Contains(m_pageInterventions))
					m_tabControl.TabPages.Add(m_pageInterventions);
			}
			else
			{
				if (m_tabControl.TabPages.Contains(m_pagesSousVersions))
					m_tabControl.TabPages.Remove(m_pagesSousVersions);
				if (m_tabControl.TabPages.Contains(m_pageInterventions))
					m_tabControl.TabPages.Remove(m_pageInterventions);
			}
			m_cmbCategorie.Init(typeof(CCategorieVersionDonnees), "Libelle", true);
			m_cmbCategorie.ElementSelectionne = VersionDonnees.CategorieDeVersion;
			AffecterTitre(I.T( "Data version|1329") + VersionDonnees.Libelle);
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
			VersionDonnees.CategorieDeVersion = m_cmbCategorie.ElementSelectionne as CCategorieVersionDonnees;
            return base.MAJ_Champs();
        }

		private CResultAErreur CFormEditionVersionDonnees_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageElementsModifies)
			{
				m_panelElementsModifies.InitFromListeObjets(
					VersionDonnees.VersionsObjets,
					typeof(CVersionDonneesObjet),
					null,
					VersionDonnees,
					"VersionDonnees");
			}
			else if (page == m_pagesSousVersions)
			{
				m_panelVersionsFilles.InitFromListeObjets(
					VersionDonnees.VersionsFilles,
					typeof(CVersionDonnees),
					typeof(CFormEditionVersionDonnees),
					VersionDonnees,
					"VersionParente");
			}
			else if (page == m_pageInterventions)
			{
				CListeObjetsDonnees liste = new CListeObjetsDonnees(VersionDonnees.ContexteDonnee, typeof(CIntervention));
				liste.Filtre = new CFiltreData(CVersionDonnees.c_champId + "=@1",
					VersionDonnees.Id);
				m_panelInterventions.InitFromListeObjets(
					liste,
					typeof(CIntervention),
					typeof(CFormEditionIntervention),
					null,
					"");
			}
			return result;
		}

		private CResultAErreur CFormEditionVersionDonnees_OnMajChampsPage(object page)
		{
			return CResultAErreur.True;
		}

		private void m_lnkVersionsParente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (VersionDonnees.VersionParente != null)
			{
				CTimosApp.Navigateur.AffichePage(new CFormEditionVersionDonnees(VersionDonnees.VersionParente));
			}
		}

		private void m_lnkTravaillerDansVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CResultAErreur result =  CFormMain.GetInstance().TravaillerSurVersion(VersionDonnees.Id);
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
			}
		}

		private void m_panelElementsModifies_OnChangeSelection(object sender, EventArgs e)
		{
			if (m_panelElementsModifies.ElementSelectionne != null && !m_gestionnaireModeEdition.ModeEdition)
				m_lnkAnnulerModificationsObjet.Visible = true;
			else
				m_lnkAnnulerModificationsObjet.Visible = false;			
		}

		private void m_lnkAnnulerModificationsObjet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if ( m_panelElementsModifies.ElementSelectionne is CVersionDonneesObjet )
			{
				CVersionDonneesObjet ver = (CVersionDonneesObjet)m_panelElementsModifies.ElementSelectionne;
				if ( CFormAlerte.Afficher(I.T("Are you sure you want to cancel these modifications|1372"),
					EFormAlerteType.Question ) == DialogResult.No )
					return;
				CResultAErreur result = ver.AnnuleModificationsPrevisionnelles();
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
					return;
				}
				InitChamps();
			}
		}

        private void m_lnkAppliquer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
                return;
            if (CFormAlerte.Afficher(
                I.T("Apply modifications|1385"),
                EFormAlerteType.Question) == DialogResult.Yes)
            {
                CFormProgressTimos.StartThreadWithProgress(I.T("Apply modifications|20176"),
                    new ThreadStart(StartApplyModifs),
                    true);
                if (!m_resultApplyModifs)
                    CFormAlerte.Afficher(m_resultApplyModifs);
                else
                    CTimosApp.Navigateur.AffichePagePrecedente();
            }
        }

        private CResultAErreur m_resultApplyModifs = CResultAErreur.True;
        private void StartApplyModifs()
        {
            m_resultApplyModifs = VersionDonnees.AppliqueModifications(CFormProgressTimos.Indicateur);
        }

		private void m_btnDetailModification_LinkClicked(object sender, EventArgs e)
		{
			if (m_panelElementsModifies.ElementSelectionne is CVersionDonneesObjet)
			{
				CVersionDonneesObjet versionObjet = (CVersionDonneesObjet)m_panelElementsModifies.ElementSelectionne;
				if (versionObjet.Element != null)
					CFormDetailVersion.ShowDetail(versionObjet.Element, this.VersionDonnees);
				else
				{
					//L'élément n'existe probablement pas dans la version en cours,
					//Il faut donc changer de version
					using (CContexteDonnee contexte = new CContexteDonnee(VersionDonnees.ContexteDonnee.IdSession, true, false))
					{
						CResultAErreur result = contexte.SetVersionDeTravail(VersionDonnees.Id, true);
						if (!result)
						{
							CFormAfficheErreur.Show(result.Erreur);
							return;
						}
						versionObjet = (CVersionDonneesObjet)versionObjet.GetObjetInContexte(contexte);
						if (versionObjet.Element != null)
						{
							CFormDetailVersion.ShowDetail(versionObjet.Element, versionObjet.VersionDonnees);
						}
					}
				}
			}
		}

		/// <summary>
		/// Annule toutes les modifications
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_lnkToutAnnuler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (CFormAlerte.Afficher(I.T("Cancel all modifications|1404"),
					EFormAlerteType.Question) == DialogResult.No)
				return;
			CResultAErreur result = VersionDonnees.AnnulerModifications();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
			}
			else
				InitChamps();
		}

		private void m_lnkCreatePrevisionnelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (CFormAlerte.Afficher(I.T("Create a new version from this archive ?|20016"),
				EFormAlerteType.Question) == DialogResult.Yes)
			{
				using (CWaitCursor waiter = new CWaitCursor())
				{
					CResultAErreur result = VersionDonnees.CreatePrevisionnelleFromArchive();
					if (!result)
					{
						CFormAlerte.Afficher(result.Erreur);
					}
					
				}
			}
		}

        private void CFormEditionVersionDonnees_Load(object sender, EventArgs e)
        {
#if DEBUG
            m_lnkMacro.Visible = true;
#endif
        }

        private void m_lnkMacro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreurType<CMacro> result = CMacro.FromVersion(VersionDonnees);
            CMacro macro = result.DataType;
            CFormEditionMacro.EditeMacro(macro);
            CListeMacros.AddMacro(macro);
        }
	}
}

