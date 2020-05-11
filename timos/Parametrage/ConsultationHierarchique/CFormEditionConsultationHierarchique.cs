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
using timos.data.workflow.ConsultationHierarchique;
using sc2i.win32.data.dynamic;



namespace timos.Parametrage.ConsultationHierarchique
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CConsultationHierarchique))]
	public class CFormEditionConsultationHierarchique : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private C2iPanelOmbre c2iPanelOmbre1;
		private CPanelEditConsultationHierarchique m_panelEditionConsultation;
        private LinkLabel m_lnkTester;
        private Label label2;
        private C2iComboSelectDynamicClass m_comboTypeRacine;
        private GroupBox groupBox1;
        private CheckBox m_chkGED;
        private CheckBox m_chkSchemaReseau;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionConsultationHierarchique()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionConsultationHierarchique(CConsultationHierarchique ConsultationHierarchique)
			:base(ConsultationHierarchique)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionConsultationHierarchique(CConsultationHierarchique ConsultationHierarchique, CListeObjetsDonnees liste)
			:base(ConsultationHierarchique, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_comboTypeRacine = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkTester = new System.Windows.Forms.LinkLabel();
            this.m_panelEditionConsultation = new timos.Parametrage.ConsultationHierarchique.CPanelEditConsultationHierarchique();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_chkSchemaReseau = new System.Windows.Forms.CheckBox();
            this.m_chkGED = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(615, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(528, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(790, 28);
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
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
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
            this.c2iPanelOmbre4.Controls.Add(this.m_comboTypeRacine);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
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
            // m_comboTypeRacine
            // 
            this.m_comboTypeRacine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_comboTypeRacine.FormattingEnabled = true;
            this.m_comboTypeRacine.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_comboTypeRacine, "");
            this.m_comboTypeRacine.Location = new System.Drawing.Point(132, 34);
            this.m_comboTypeRacine.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboTypeRacine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_comboTypeRacine, "");
            this.m_comboTypeRacine.Name = "m_comboTypeRacine";
            this.m_comboTypeRacine.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_comboTypeRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_comboTypeRacine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_comboTypeRacine.TabIndex = 4003;
            this.m_comboTypeRacine.TypeSelectionne = null;
            this.m_comboTypeRacine.SelectionChangeCommitted += new System.EventHandler(this.m_comboTypeRacine_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Root element|20105";
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkTester);
            this.c2iPanelOmbre1.Controls.Add(this.m_panelEditionConsultation);
            this.c2iPanelOmbre1.Controls.Add(this.groupBox1);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 136);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(766, 382);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4004;
            // 
            // m_lnkTester
            // 
            this.m_lnkTester.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTester, "");
            this.m_lnkTester.Location = new System.Drawing.Point(8, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTester, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkTester, "");
            this.m_lnkTester.Name = "m_lnkTester";
            this.m_lnkTester.Size = new System.Drawing.Size(60, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTester.TabIndex = 4;
            this.m_lnkTester.TabStop = true;
            this.m_lnkTester.Text = "Test|20095";
            this.m_lnkTester.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTester_LinkClicked);
            // 
            // m_panelEditionConsultation
            // 
            this.m_panelEditionConsultation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelEditionConsultation, "");
            this.m_panelEditionConsultation.Location = new System.Drawing.Point(11, 22);
            this.m_panelEditionConsultation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionConsultation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditionConsultation, "");
            this.m_panelEditionConsultation.Name = "m_panelEditionConsultation";
            this.m_panelEditionConsultation.Size = new System.Drawing.Size(715, 244);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionConsultation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionConsultation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionConsultation.TabIndex = 3;
            this.m_panelEditionConsultation.TypesFolders = new System.Type[] {
        ((System.Type)(typeof(timos.data.workflow.ConsultationHierarchique.CFolderConsultationFolder))),
        ((System.Type)(typeof(timos.data.workflow.ConsultationHierarchique.CFolderConsultationFromFiltre))),
        ((System.Type)(typeof(timos.data.workflow.ConsultationHierarchique.CFolderConsultationFromFormula)))};
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.m_chkSchemaReseau);
            this.groupBox1.Controls.Add(this.m_chkGED);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(14, 273);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 84);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Use Cases|10107";
            // 
            // m_chkSchemaReseau
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSchemaReseau, "");
            this.m_chkSchemaReseau.Location = new System.Drawing.Point(12, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSchemaReseau, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSchemaReseau, "");
            this.m_chkSchemaReseau.Name = "m_chkSchemaReseau";
            this.m_chkSchemaReseau.Size = new System.Drawing.Size(259, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSchemaReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSchemaReseau.TabIndex = 1;
            this.m_chkSchemaReseau.Text = "Network Diagrams|10109";
            this.m_chkSchemaReseau.UseVisualStyleBackColor = true;
            // 
            // m_chkGED
            // 
            this.m_extLinkField.SetLinkField(this.m_chkGED, "");
            this.m_chkGED.Location = new System.Drawing.Point(12, 17);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkGED, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkGED, "");
            this.m_chkGED.Name = "m_chkGED";
            this.m_chkGED.Size = new System.Drawing.Size(259, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkGED, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkGED.TabIndex = 0;
            this.m_chkGED.Text = "Electronic Document Management|10108";
            this.m_chkGED.UseVisualStyleBackColor = true;
            // 
            // CFormEditionConsultationHierarchique
            // 
            this.ClientSize = new System.Drawing.Size(790, 530);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionConsultationHierarchique";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CConsultationHierarchique ConsultationHierarchique
		{
			get
			{
				return (CConsultationHierarchique)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
        private bool m_bIsInit = false;
        protected override CResultAErreur MyInitChamps()
		{
            m_bIsInit = false;
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Hierarchical consultation @1|20091", ConsultationHierarchique.Libelle));

			m_panelEditionConsultation.InitChamps(ConsultationHierarchique.FolderRacine,
                CConsultationHierarchique.TypesFoldersParametrables);

            CInfoClasseDynamique[] infos = DynamicClassAttribute.GetAllDynamicClassHeritant ( typeof(CObjetDonnee) );
            m_comboTypeRacine.Init(infos);
            m_comboTypeRacine.TypeSelectionne = ConsultationHierarchique.TypeSource;
            if (!ConsultationHierarchique.IsNew())
                m_comboTypeRacine.LockEdition = true;

            // Initialisation des cas d'utilisation possibles
            m_chkGED.Checked = ((ConsultationHierarchique.CasUtilisation & CConsultationHierarchique.ECasUtilisation.GED) == CConsultationHierarchique.ECasUtilisation.GED);
            m_chkSchemaReseau.Checked = ((ConsultationHierarchique.CasUtilisation & CConsultationHierarchique.ECasUtilisation.Schema) == CConsultationHierarchique.ECasUtilisation.Schema);

            m_bIsInit = true;
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (result)
			{
                // Enregistre les cas d'utilisation
                CConsultationHierarchique.ECasUtilisation cas = CConsultationHierarchique.ECasUtilisation.Rien;
                if (m_chkGED.Checked)
                    cas = cas | CConsultationHierarchique.ECasUtilisation.GED;
                if (m_chkSchemaReseau.Checked)
                    cas = cas | CConsultationHierarchique.ECasUtilisation.Schema;
                ConsultationHierarchique.CasUtilisation = cas;

				result = m_panelEditionConsultation.MajChamps();
				if (result)
					ConsultationHierarchique.FolderRacine = m_panelEditionConsultation.Folder;


			}
			return result;
        }

        private void m_lnkTester_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_panelEditionConsultation.Folder != null)
            {
                m_panelEditionConsultation.MajChamps();
                CFolderConsultationRacineFromElement racine = m_panelEditionConsultation.Folder as CFolderConsultationRacineFromElement;
                if (racine != null)
                {
                    CObjetDonnee objet = CFormSelectUnObjetDonnee.SelectionRechercheRapide(
                        I.T("Select an element for test|20735"),
                        racine.TypeRacine,
                        null,
                        "",
                        DescriptionFieldAttribute.GetDescriptionField(racine.TypeRacine, "Description"),
                        "FORTESTCONSULT");
                    if (objet == null)
                        return;
                    racine.InitConsultation(objet);
                }
                CFormTestConsultationHierarchique.TestFolder(m_panelEditionConsultation.Folder);
            }
        }

        private void m_comboTypeRacine_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_bIsInit)
            {
                Type tp = m_comboTypeRacine.TypeSelectionne;
                CFolderConsultationHierarchique racine = m_panelEditionConsultation.Folder;
                CFolderConsultationRacineFromElement folderRacineType = racine as CFolderConsultationRacineFromElement;
                if (folderRacineType == null && tp != null ||
                    folderRacineType != null && folderRacineType.TypeRacine != tp)
                {
                    folderRacineType = new CFolderConsultationRacineFromElement();
                    folderRacineType.Libelle = DynamicClassAttribute.GetNomConvivial(tp);
                    folderRacineType.TypeRacine = tp;
                    m_panelEditionConsultation.InitChamps(folderRacineType, CConsultationHierarchique.TypesFoldersParametrables);
                }
                if (tp == null && folderRacineType != null)
                    m_panelEditionConsultation.InitChamps(null, CConsultationHierarchique.TypesFoldersParametrables);
            }
        }
	}
}

