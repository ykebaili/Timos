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
using sc2i.workflow;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeOperation))]
	public class CFormEditionTypeOperation : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageDetail;
		private Label label2;
		private C2iTextBox c2iTextBox1;
		private Label label4;
		private C2iTextBoxNumerique c2iTextBoxNumerique1;
		private Label label5;
		private Panel m_panelElementaire;
		private CheckBox m_chkRemplacement;
		private Label label3;
        private CArbreObjetHierarchique m_panelParent;
		private Label lbl_typoccupation;
		private CComboBoxListeObjetsDonnees m_cmbTypeOccupation;
		private CheckBox m_chkSaisieDuree;
		private Panel m_panelTypeOccupation;
		private Label label7;
		private CComboBoxListeObjetsDonnees m_cmbFormulaireCR;
        private Crownwood.Magic.Controls.TabPage m_pageFilles;
        private CPanelListeSpeedStandard m_panelOpFilles;
        private Label label6;
        private CComboBoxListeObjetsDonnees m_cmbFormulairePrev;
        private CheckBox m_chkLieeEquipement;
        private CheckBox m_chkCreerUneOpParTypeEquipement;
		private CheckBox m_chkSaisieHeure;
        private CheckBox m_chkPropagerSurPhaseTicket;
        private CheckBox m_chkLockTypeOperation;
        private CheckBox m_chkInterditSuppression;
        private CheckBox m_chkLockAuteur;
        private CheckBox m_chkSaisieDateFin;
        private Crownwood.Magic.Controls.TabPage m_pageEvents;
        private CPanelDefinisseurEvenements m_panelEvenements;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeOperation()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeOperation(CTypeOperation TypeOperation)
			:base(TypeOperation)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeOperation(CTypeOperation TypeOperation, CListeObjetsDonnees liste)
			:base(TypeOperation, liste)
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeOperation));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelParent = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDetail = new Crownwood.Magic.Controls.TabPage();
            this.m_chkLockAuteur = new System.Windows.Forms.CheckBox();
            this.m_chkInterditSuppression = new System.Windows.Forms.CheckBox();
            this.m_chkLockTypeOperation = new System.Windows.Forms.CheckBox();
            this.m_chkPropagerSurPhaseTicket = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbFormulairePrev = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_cmbFormulaireCR = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_panelTypeOccupation = new System.Windows.Forms.Panel();
            this.m_cmbTypeOccupation = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.lbl_typoccupation = new System.Windows.Forms.Label();
            this.m_chkCreerUneOpParTypeEquipement = new System.Windows.Forms.CheckBox();
            this.m_chkLieeEquipement = new System.Windows.Forms.CheckBox();
            this.m_chkRemplacement = new System.Windows.Forms.CheckBox();
            this.m_panelElementaire = new System.Windows.Forms.Panel();
            this.m_chkSaisieDateFin = new System.Windows.Forms.CheckBox();
            this.m_chkSaisieHeure = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iTextBoxNumerique1 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_chkSaisieDuree = new System.Windows.Forms.CheckBox();
            this.m_pageFilles = new Crownwood.Magic.Controls.TabPage();
            this.m_panelOpFilles = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageEvents = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageDetail.SuspendLayout();
            this.m_panelTypeOccupation.SuspendLayout();
            this.m_panelElementaire.SuspendLayout();
            this.m_pageFilles.SuspendLayout();
            this.m_pageEvents.SuspendLayout();
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
            this.m_panelCle.Location = new System.Drawing.Point(568, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
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
            this.label1.Location = new System.Drawing.Point(298, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(358, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(422, 20);
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
            this.c2iPanelOmbre4.Controls.Add(this.m_panelParent);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 30);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(822, 122);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_panelParent
            // 
            this.m_panelParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelParent.AutoriseReaffectation = true;
            this.m_panelParent.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_panelParent, "");
            this.m_panelParent.Location = new System.Drawing.Point(11, 4);
            this.m_panelParent.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParent, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelParent, "");
            this.m_panelParent.Name = "m_panelParent";
            this.m_panelParent.Size = new System.Drawing.Size(279, 97);
            this.m_extStyle.SetStyleBackColor(this.m_panelParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParent.TabIndex = 4006;
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.c2iTextBox1.Location = new System.Drawing.Point(358, 29);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(218, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4004;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(299, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Code|335";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "CodeSystemeComplet");
            this.label3.Location = new System.Drawing.Point(602, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4005;
            this.label3.Text = "[CodeSystemeComplet]";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 2;
            this.m_tabControl.SelectedTab = this.m_pageEvents;
            this.m_tabControl.Size = new System.Drawing.Size(822, 370);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDetail,
            this.m_pageFilles,
            this.m_pageEvents});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDetail
            // 
            this.m_pageDetail.Controls.Add(this.m_chkLockAuteur);
            this.m_pageDetail.Controls.Add(this.m_chkInterditSuppression);
            this.m_pageDetail.Controls.Add(this.m_chkLockTypeOperation);
            this.m_pageDetail.Controls.Add(this.m_chkPropagerSurPhaseTicket);
            this.m_pageDetail.Controls.Add(this.label6);
            this.m_pageDetail.Controls.Add(this.label7);
            this.m_pageDetail.Controls.Add(this.m_cmbFormulairePrev);
            this.m_pageDetail.Controls.Add(this.m_cmbFormulaireCR);
            this.m_pageDetail.Controls.Add(this.m_panelTypeOccupation);
            this.m_pageDetail.Controls.Add(this.m_chkCreerUneOpParTypeEquipement);
            this.m_pageDetail.Controls.Add(this.m_chkLieeEquipement);
            this.m_pageDetail.Controls.Add(this.m_chkRemplacement);
            this.m_pageDetail.Controls.Add(this.m_panelElementaire);
            this.m_extLinkField.SetLinkField(this.m_pageDetail, "");
            this.m_pageDetail.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDetail, "");
            this.m_pageDetail.Name = "m_pageDetail";
            this.m_pageDetail.Selected = false;
            this.m_pageDetail.Size = new System.Drawing.Size(806, 329);
            this.m_extStyle.SetStyleBackColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDetail.TabIndex = 10;
            this.m_pageDetail.Title = "Details|337";
            // 
            // m_chkLockAuteur
            // 
            this.m_chkLockAuteur.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkLockAuteur, "VerrouillerAuteur");
            this.m_chkLockAuteur.Location = new System.Drawing.Point(368, 253);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLockAuteur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLockAuteur, "");
            this.m_chkLockAuteur.Name = "m_chkLockAuteur";
            this.m_chkLockAuteur.Size = new System.Drawing.Size(226, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkLockAuteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLockAuteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLockAuteur.TabIndex = 13;
            this.m_chkLockAuteur.Text = "Author cannot be modified by user|10037";
            this.m_chkLockAuteur.ThreeState = true;
            this.m_chkLockAuteur.UseVisualStyleBackColor = true;
            // 
            // m_chkInterditSuppression
            // 
            this.m_chkInterditSuppression.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkInterditSuppression, "InterditSuppressionApresCreation");
            this.m_chkInterditSuppression.Location = new System.Drawing.Point(368, 230);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkInterditSuppression, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkInterditSuppression, "");
            this.m_chkInterditSuppression.Name = "m_chkInterditSuppression";
            this.m_chkInterditSuppression.Size = new System.Drawing.Size(267, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkInterditSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkInterditSuppression, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkInterditSuppression.TabIndex = 13;
            this.m_chkInterditSuppression.Text = "Operation cannot be deleted after creation|10035";
            this.m_chkInterditSuppression.ThreeState = true;
            this.m_chkInterditSuppression.UseVisualStyleBackColor = true;
            // 
            // m_chkLockTypeOperation
            // 
            this.m_chkLockTypeOperation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkLockTypeOperation, "VerrouillerLeTypeApresCreation");
            this.m_chkLockTypeOperation.Location = new System.Drawing.Point(368, 208);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLockTypeOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLockTypeOperation, "");
            this.m_chkLockTypeOperation.Name = "m_chkLockTypeOperation";
            this.m_chkLockTypeOperation.Size = new System.Drawing.Size(310, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkLockTypeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLockTypeOperation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLockTypeOperation.TabIndex = 12;
            this.m_chkLockTypeOperation.Text = "Type of operation cannot be changed after creation|20111";
            this.m_chkLockTypeOperation.ThreeState = true;
            this.m_chkLockTypeOperation.UseVisualStyleBackColor = true;
            // 
            // m_chkPropagerSurPhaseTicket
            // 
            this.m_chkPropagerSurPhaseTicket.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkPropagerSurPhaseTicket, "");
            this.m_chkPropagerSurPhaseTicket.Location = new System.Drawing.Point(368, 187);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPropagerSurPhaseTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkPropagerSurPhaseTicket, "");
            this.m_chkPropagerSurPhaseTicket.Name = "m_chkPropagerSurPhaseTicket";
            this.m_chkPropagerSurPhaseTicket.Size = new System.Drawing.Size(402, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkPropagerSurPhaseTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPropagerSurPhaseTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPropagerSurPhaseTicket.TabIndex = 11;
            this.m_chkPropagerSurPhaseTicket.Text = "Link the Operation to the Ticket Phase when entered in an Intervention|10014";
            this.m_chkPropagerSurPhaseTicket.ThreeState = true;
            this.m_chkPropagerSurPhaseTicket.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(11, 166);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(342, 18);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 10;
            this.label6.Text = "Form for the planified Operations under an intervention|1121";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(11, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(342, 18);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 10;
            this.label7.Text = "Form for the Operations realization report|1120";
            // 
            // m_cmbFormulairePrev
            // 
            this.m_cmbFormulairePrev.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulairePrev.ElementSelectionne = null;
            this.m_cmbFormulairePrev.FormattingEnabled = true;
            this.m_cmbFormulairePrev.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFormulairePrev, "");
            this.m_cmbFormulairePrev.ListDonnees = null;
            this.m_cmbFormulairePrev.Location = new System.Drawing.Point(11, 184);
            this.m_cmbFormulairePrev.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormulairePrev, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormulairePrev, "");
            this.m_cmbFormulairePrev.Name = "m_cmbFormulairePrev";
            this.m_cmbFormulairePrev.NullAutorise = true;
            this.m_cmbFormulairePrev.ProprieteAffichee = null;
            this.m_cmbFormulairePrev.ProprieteParentListeObjets = null;
            this.m_cmbFormulairePrev.SelectionneurParent = null;
            this.m_cmbFormulairePrev.Size = new System.Drawing.Size(292, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormulairePrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormulairePrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulairePrev.TabIndex = 10;
            this.m_cmbFormulairePrev.TextNull = "(Inherited)";
            this.m_cmbFormulairePrev.Tri = true;
            // 
            // m_cmbFormulaireCR
            // 
            this.m_cmbFormulaireCR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireCR.ElementSelectionne = null;
            this.m_cmbFormulaireCR.FormattingEnabled = true;
            this.m_cmbFormulaireCR.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFormulaireCR, "");
            this.m_cmbFormulaireCR.ListDonnees = null;
            this.m_cmbFormulaireCR.Location = new System.Drawing.Point(11, 123);
            this.m_cmbFormulaireCR.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormulaireCR, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormulaireCR, "");
            this.m_cmbFormulaireCR.Name = "m_cmbFormulaireCR";
            this.m_cmbFormulaireCR.NullAutorise = true;
            this.m_cmbFormulaireCR.ProprieteAffichee = null;
            this.m_cmbFormulaireCR.ProprieteParentListeObjets = null;
            this.m_cmbFormulaireCR.SelectionneurParent = null;
            this.m_cmbFormulaireCR.Size = new System.Drawing.Size(292, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormulaireCR, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormulaireCR, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaireCR.TabIndex = 10;
            this.m_cmbFormulaireCR.TextNull = "(Inherited)";
            this.m_cmbFormulaireCR.Tri = true;
            // 
            // m_panelTypeOccupation
            // 
            this.m_panelTypeOccupation.Controls.Add(this.m_cmbTypeOccupation);
            this.m_panelTypeOccupation.Controls.Add(this.lbl_typoccupation);
            this.m_extLinkField.SetLinkField(this.m_panelTypeOccupation, "");
            this.m_panelTypeOccupation.Location = new System.Drawing.Point(7, 66);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeOccupation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeOccupation, "");
            this.m_panelTypeOccupation.Name = "m_panelTypeOccupation";
            this.m_panelTypeOccupation.Size = new System.Drawing.Size(659, 22);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeOccupation.TabIndex = 10;
            // 
            // m_cmbTypeOccupation
            // 
            this.m_cmbTypeOccupation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeOccupation.ElementSelectionne = null;
            this.m_cmbTypeOccupation.FormattingEnabled = true;
            this.m_cmbTypeOccupation.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeOccupation, "");
            this.m_cmbTypeOccupation.ListDonnees = null;
            this.m_cmbTypeOccupation.Location = new System.Drawing.Point(129, 1);
            this.m_cmbTypeOccupation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeOccupation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeOccupation, "");
            this.m_cmbTypeOccupation.Name = "m_cmbTypeOccupation";
            this.m_cmbTypeOccupation.NullAutorise = true;
            this.m_cmbTypeOccupation.ProprieteAffichee = null;
            this.m_cmbTypeOccupation.ProprieteParentListeObjets = null;
            this.m_cmbTypeOccupation.SelectionneurParent = null;
            this.m_cmbTypeOccupation.Size = new System.Drawing.Size(245, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeOccupation.TabIndex = 8;
            this.m_cmbTypeOccupation.TextNull = "(empty)";
            this.m_cmbTypeOccupation.Tri = true;
            // 
            // lbl_typoccupation
            // 
            this.m_extLinkField.SetLinkField(this.lbl_typoccupation, "");
            this.lbl_typoccupation.Location = new System.Drawing.Point(1, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_typoccupation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_typoccupation, "");
            this.lbl_typoccupation.Name = "lbl_typoccupation";
            this.lbl_typoccupation.Size = new System.Drawing.Size(129, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_typoccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_typoccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_typoccupation.TabIndex = 9;
            this.lbl_typoccupation.Text = "Occupation type|409";
            // 
            // m_chkCreerUneOpParTypeEquipement
            // 
            this.m_extLinkField.SetLinkField(this.m_chkCreerUneOpParTypeEquipement, "GenererUneOpParTypeEquipement");
            this.m_chkCreerUneOpParTypeEquipement.Location = new System.Drawing.Point(386, 140);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkCreerUneOpParTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkCreerUneOpParTypeEquipement, "");
            this.m_chkCreerUneOpParTypeEquipement.Name = "m_chkCreerUneOpParTypeEquipement";
            this.m_chkCreerUneOpParTypeEquipement.Size = new System.Drawing.Size(394, 39);
            this.m_extStyle.SetStyleBackColor(this.m_chkCreerUneOpParTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkCreerUneOpParTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkCreerUneOpParTypeEquipement.TabIndex = 5;
            this.m_chkCreerUneOpParTypeEquipement.Text = "Automatically generate one Operation per equipment of the specified type (on oper" +
                "ations list)|1161";
            this.m_chkCreerUneOpParTypeEquipement.UseVisualStyleBackColor = true;
            this.m_chkCreerUneOpParTypeEquipement.CheckedChanged += new System.EventHandler(this.m_chkLieeEquipement_CheckedChanged);
            // 
            // m_chkLieeEquipement
            // 
            this.m_extLinkField.SetLinkField(this.m_chkLieeEquipement, "IsLieeAEquipement");
            this.m_chkLieeEquipement.Location = new System.Drawing.Point(368, 102);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLieeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLieeEquipement, "");
            this.m_chkLieeEquipement.Name = "m_chkLieeEquipement";
            this.m_chkLieeEquipement.Size = new System.Drawing.Size(323, 21);
            this.m_extStyle.SetStyleBackColor(this.m_chkLieeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLieeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLieeEquipement.TabIndex = 5;
            this.m_chkLieeEquipement.Text = "Linked to an Equipment|1160";
            this.m_chkLieeEquipement.UseVisualStyleBackColor = true;
            this.m_chkLieeEquipement.CheckedChanged += new System.EventHandler(this.m_chkLieeEquipement_CheckedChanged);
            // 
            // m_chkRemplacement
            // 
            this.m_extLinkField.SetLinkField(this.m_chkRemplacement, "IsRemplacementEquipement");
            this.m_chkRemplacement.Location = new System.Drawing.Point(386, 123);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkRemplacement, "");
            this.m_chkRemplacement.Name = "m_chkRemplacement";
            this.m_chkRemplacement.Size = new System.Drawing.Size(372, 21);
            this.m_extStyle.SetStyleBackColor(this.m_chkRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkRemplacement.TabIndex = 5;
            this.m_chkRemplacement.Text = "This operation need to replace an equipment|365";
            this.m_chkRemplacement.UseVisualStyleBackColor = true;
            // 
            // m_panelElementaire
            // 
            this.m_panelElementaire.Controls.Add(this.m_chkSaisieDateFin);
            this.m_panelElementaire.Controls.Add(this.m_chkSaisieHeure);
            this.m_panelElementaire.Controls.Add(this.label4);
            this.m_panelElementaire.Controls.Add(this.label5);
            this.m_panelElementaire.Controls.Add(this.c2iTextBoxNumerique1);
            this.m_panelElementaire.Controls.Add(this.m_chkSaisieDuree);
            this.m_extLinkField.SetLinkField(this.m_panelElementaire, "");
            this.m_panelElementaire.Location = new System.Drawing.Point(7, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelElementaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelElementaire, "");
            this.m_panelElementaire.Name = "m_panelElementaire";
            this.m_panelElementaire.Size = new System.Drawing.Size(751, 58);
            this.m_extStyle.SetStyleBackColor(this.m_panelElementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelElementaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelElementaire.TabIndex = 4;
            // 
            // m_chkSaisieDateFin
            // 
            this.m_chkSaisieDateFin.Checked = true;
            this.m_chkSaisieDateFin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_extLinkField.SetLinkField(this.m_chkSaisieDateFin, "");
            this.m_chkSaisieDateFin.Location = new System.Drawing.Point(294, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSaisieDateFin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSaisieDateFin, "");
            this.m_chkSaisieDateFin.Name = "m_chkSaisieDateFin";
            this.m_chkSaisieDateFin.Size = new System.Drawing.Size(440, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSaisieDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSaisieDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSaisieDateFin.TabIndex = 9;
            this.m_chkSaisieDateFin.Text = "The user must enter an operation end date/time|20138";
            this.m_chkSaisieDateFin.UseVisualStyleBackColor = true;
            this.m_chkSaisieDateFin.CheckedChanged += new System.EventHandler(this.m_chkSaisieDateFin_CheckedChanged);
            // 
            // m_chkSaisieHeure
            // 
            this.m_chkSaisieHeure.Checked = true;
            this.m_chkSaisieHeure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_extLinkField.SetLinkField(this.m_chkSaisieHeure, "");
            this.m_chkSaisieHeure.Location = new System.Drawing.Point(276, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSaisieHeure, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSaisieHeure, "");
            this.m_chkSaisieHeure.Name = "m_chkSaisieHeure";
            this.m_chkSaisieHeure.Size = new System.Drawing.Size(458, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSaisieHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSaisieHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSaisieHeure.TabIndex = 8;
            this.m_chkSaisieHeure.Text = "The user must enter an operation start date/time|1284";
            this.m_chkSaisieHeure.ThreeState = true;
            this.m_chkSaisieHeure.UseVisualStyleBackColor = true;
            this.m_chkSaisieHeure.CheckStateChanged += new System.EventHandler(this.m_chkSaisieHeure_CheckStateChanged);
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(1, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Standard duration|340";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(204, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Hour(s)|343";
            // 
            // c2iTextBoxNumerique1
            // 
            this.c2iTextBoxNumerique1.Arrondi = 2;
            this.c2iTextBoxNumerique1.DecimalAutorise = true;
            this.c2iTextBoxNumerique1.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique1, "DureeStandardHeures");
            this.c2iTextBoxNumerique1.Location = new System.Drawing.Point(129, 2);
            this.c2iTextBoxNumerique1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Name = "c2iTextBoxNumerique1";
            this.c2iTextBoxNumerique1.NullAutorise = false;
            this.c2iTextBoxNumerique1.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique1.Size = new System.Drawing.Size(69, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique1.TabIndex = 1;
            this.c2iTextBoxNumerique1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_chkSaisieDuree
            // 
            this.m_chkSaisieDuree.Checked = true;
            this.m_chkSaisieDuree.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_extLinkField.SetLinkField(this.m_chkSaisieDuree, "");
            this.m_chkSaisieDuree.Location = new System.Drawing.Point(276, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSaisieDuree, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSaisieDuree, "");
            this.m_chkSaisieDuree.Name = "m_chkSaisieDuree";
            this.m_chkSaisieDuree.Size = new System.Drawing.Size(458, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkSaisieDuree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSaisieDuree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSaisieDuree.TabIndex = 7;
            this.m_chkSaisieDuree.Text = "The user must enter a duration for these operations|1117";
            this.m_chkSaisieDuree.ThreeState = true;
            this.m_chkSaisieDuree.UseVisualStyleBackColor = true;
            this.m_chkSaisieDuree.CheckStateChanged += new System.EventHandler(this.m_chkSaisieDuree_CheckStateChanged);
            // 
            // m_pageFilles
            // 
            this.m_pageFilles.Controls.Add(this.m_panelOpFilles);
            this.m_extLinkField.SetLinkField(this.m_pageFilles, "");
            this.m_pageFilles.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFilles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFilles, "");
            this.m_pageFilles.Name = "m_pageFilles";
            this.m_pageFilles.Selected = false;
            this.m_pageFilles.Size = new System.Drawing.Size(806, 329);
            this.m_extStyle.SetStyleBackColor(this.m_pageFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFilles.TabIndex = 11;
            this.m_pageFilles.Title = "Child Operation type|1116";
            // 
            // m_panelOpFilles
            // 
            this.m_panelOpFilles.AllowArbre = true;
            this.m_panelOpFilles.AllowCustomisation = true;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "ColumnLabel";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 500;
            this.m_panelOpFilles.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelOpFilles.ContexteUtilisation = "";
            this.m_panelOpFilles.ControlFiltreStandard = null;
            this.m_panelOpFilles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelOpFilles.ElementSelectionne = null;
            this.m_panelOpFilles.EnableCustomisation = true;
            this.m_panelOpFilles.FiltreDeBase = null;
            this.m_panelOpFilles.FiltreDeBaseEnAjout = false;
            this.m_panelOpFilles.FiltrePrefere = null;
            this.m_panelOpFilles.FiltreRapide = null;
            this.m_panelOpFilles.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelOpFilles, "");
            this.m_panelOpFilles.ListeObjets = null;
            this.m_panelOpFilles.Location = new System.Drawing.Point(0, 0);
            this.m_panelOpFilles.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOpFilles, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelOpFilles.ModeQuickSearch = false;
            this.m_panelOpFilles.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelOpFilles, "");
            this.m_panelOpFilles.MultiSelect = false;
            this.m_panelOpFilles.Name = "m_panelOpFilles";
            this.m_panelOpFilles.Navigateur = null;
            this.m_panelOpFilles.ProprieteObjetAEditer = null;
            this.m_panelOpFilles.QuickSearchText = "";
            this.m_panelOpFilles.Size = new System.Drawing.Size(806, 329);
            this.m_extStyle.SetStyleBackColor(this.m_panelOpFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOpFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOpFilles.TabIndex = 12;
            this.m_panelOpFilles.TrierAuClicSurEnteteColonne = true;
            this.m_panelOpFilles.UseCheckBoxes = false;
            // 
            // m_pageEvents
            // 
            this.m_pageEvents.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvents, "");
            this.m_pageEvents.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvents, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvents, "");
            this.m_pageEvents.Name = "m_pageEvents";
            this.m_pageEvents.Size = new System.Drawing.Size(806, 329);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvents.TabIndex = 12;
            this.m_pageEvents.Title = "Events|183";
            // 
            // m_panelEvenements
            // 
            this.m_panelEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEvenements, "");
            this.m_panelEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEvenements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEvenements, "");
            this.m_panelEvenements.Name = "m_panelEvenements";
            this.m_panelEvenements.Size = new System.Drawing.Size(806, 329);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 2;
            // 
            // CFormEditionTypeOperation
            // 
            this.ClientSize = new System.Drawing.Size(830, 540);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeOperation";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeOperation_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeOperation_OnMajChampsPage);
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
            this.m_pageDetail.ResumeLayout(false);
            this.m_pageDetail.PerformLayout();
            this.m_panelTypeOccupation.ResumeLayout(false);
            this.m_panelElementaire.ResumeLayout(false);
            this.m_panelElementaire.PerformLayout();
            this.m_pageFilles.ResumeLayout(false);
            this.m_pageEvents.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeOperation TypeOperation
		{
			get
			{
				return (CTypeOperation)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Operation Type @1|1282",TypeOperation.Libelle));

			m_panelParent.AfficheHierarchie(TypeOperation);

			m_panelOpFilles.InitFromListeObjets(TypeOperation.TypesOperationsFilles,
				typeof(CTypeOperation),
				typeof(CFormEditionTypeOperation),
				TypeOperation,
				"TypeOperationParente");

			CListeObjetsDonnees  listeOcc = new CListeObjetsDonnees ( TypeOperation.ContexteDonnee, typeof(CTypeOccupationHoraire ) );
			listeOcc.Filtre = new CFiltreData ( CTypeOccupationHoraire.c_champSurOperation+"=@1", true );
			m_cmbTypeOccupation.Init(listeOcc, "Libelle", false);

			m_cmbTypeOccupation.ElementSelectionne = TypeOperation.TypeOccupationPropre;

            m_chkSaisieDateFin.Checked = TypeOperation.SaisieDureeParDateFin;			

            if (TypeOperation.TypeOperationParente == null)
            {
                m_chkSaisieDuree.ThreeState = false;
                m_chkSaisieHeure.ThreeState = false;
                m_chkPropagerSurPhaseTicket.ThreeState = false;

                m_chkSaisieDuree.Checked = TypeOperation.SaisieDureeAppliquee;
                m_chkSaisieHeure.Checked = TypeOperation.SaisieHeureAppliquee;
                m_chkPropagerSurPhaseTicket.Checked = TypeOperation.PropagerSurPhaseApplique;

            }
            else
            {
                m_chkSaisieDuree.ThreeState = true;
                m_chkSaisieHeure.ThreeState = true;
                m_chkPropagerSurPhaseTicket.ThreeState = true;

                bool? etat = TypeOperation.SaisieDureePropre;
                m_chkSaisieDuree.CheckState = etat == null? CheckState.Indeterminate:((bool)etat==true?CheckState.Checked:CheckState.Unchecked);

                etat = TypeOperation.SaisieDureePropre;
                m_chkSaisieHeure.CheckState = etat == null ? CheckState.Indeterminate : ((bool)etat == true ? CheckState.Checked : CheckState.Unchecked);
                
                etat = TypeOperation.PropagerSurPhasePropre;
                m_chkPropagerSurPhaseTicket.CheckState = etat == null ? CheckState.Indeterminate : ((bool)etat == true ? CheckState.Checked : CheckState.Unchecked);

            }

            UpdatePanelOccupation();

			CListeObjetsDonnees liste = new CListeObjetsDonnees(TypeOperation.ContexteDonnee, typeof(CFormulaire));
            liste.Filtre = CFormulaire.GetFiltreFormulairesForRole(COperation.c_roleChampCustom);

			m_cmbFormulaireCR.Init(liste, "Libelle", false);
			m_cmbFormulaireCR.ElementSelectionne = TypeOperation.FormulaireCompteRendu;
            m_cmbFormulairePrev.Init(liste, "Libelle", false);
            m_cmbFormulairePrev.ElementSelectionne = TypeOperation.FormulaireOpPrevisionnelle;
            UpdateVisuOptions();
			
			return result;
		}

 
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			if (m_chkSaisieDuree.Checked == true)
				TypeOperation.TypeOccupationPropre = (CTypeOccupationHoraire)m_cmbTypeOccupation.ElementSelectionne;
			else
				TypeOperation.TypeOccupationPropre = null;

			if (m_chkSaisieDuree.CheckState == CheckState.Indeterminate)
				TypeOperation.SaisieDureePropre = null;
			else
				TypeOperation.SaisieDureePropre = m_chkSaisieDuree.Checked;

			if (m_chkSaisieHeure.CheckState == CheckState.Indeterminate)
				TypeOperation.SaisieHeurePropre = null;
			else
				TypeOperation.SaisieHeurePropre = m_chkSaisieHeure.Checked;

            TypeOperation.SaisieDureeParDateFin = m_chkSaisieDateFin.Checked;

            if (m_chkPropagerSurPhaseTicket.CheckState == CheckState.Indeterminate)
                TypeOperation.PropagerSurPhasePropre = null;
            else
                TypeOperation.PropagerSurPhasePropre = m_chkPropagerSurPhaseTicket.Checked;
                

            TypeOperation.FormulaireCompteRendu = (CFormulaire)m_cmbFormulaireCR.ElementSelectionne;
            TypeOperation.FormulaireOpPrevisionnelle = (CFormulaire)m_cmbFormulairePrev.ElementSelectionne;

			return result;
		}

        
        //---------------------------------------------------------------------------
        private void m_chkSaisieDuree_CheckStateChanged(object sender, EventArgs e)
        {
            if (!m_chkSaisieDuree.Checked)
                m_chkSaisieDateFin.Checked = false;
            UpdatePanelOccupation();

        }

		//---------------------------------------------------------------------------
		private void m_chkSaisieHeure_CheckStateChanged(object sender, EventArgs e)
		{
			UpdatePanelOccupation();

		}

        //---------------------------------------------------------------------------
        private void UpdatePanelOccupation()
        {
            if (m_chkSaisieDuree.CheckState == CheckState.Checked)
                m_panelTypeOccupation.Enabled = true;
            else
                m_panelTypeOccupation.Enabled = false;
        }

        //---------------------------------------------------------------------------
        private void m_chkLieeEquipement_CheckedChanged(object sender, EventArgs e)
        {
            UpdateVisuOptions();
        }
        //-----------------------------------------------------------------
        private void UpdateVisuOptions()
        {
            m_chkRemplacement.Enabled =
                !m_chkLieeEquipement.Checked ? false : m_gestionnaireModeEdition.ModeEdition;
            m_chkCreerUneOpParTypeEquipement.Enabled =
                !m_chkLieeEquipement.Checked ? false : m_gestionnaireModeEdition.ModeEdition;
        }

        private void m_chkSaisieDateFin_CheckedChanged(object sender, EventArgs e)
        {
            if (!m_chkSaisieDuree.Checked)
                m_chkSaisieDuree.Checked = true;
            if (!m_chkSaisieHeure.Checked)
                m_chkSaisieHeure.Checked = true;
        }

        private CResultAErreur CFormEditionTypeOperation_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageEvents)
            {
                m_panelEvenements.InitChamps(TypeOperation);
            }
            return result;
        }

        private CResultAErreur CFormEditionTypeOperation_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageEvents)
            {
                result = m_panelEvenements.MAJ_Champs();
            }
            return result;
        }


	

		
	}
}

