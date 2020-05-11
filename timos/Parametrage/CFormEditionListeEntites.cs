using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.workflow;
using sc2i.data.dynamic;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CListeEntites))]
	public class CFormEditionListeEntites : CFormEditionStdTimos, IFormNavigable
	{
		CFiltreDynamique m_filtreDynamique = null;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private sc2i.win32.common.C2iTextBox c2iTextBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private timos.win32.composants.CPanelSelectListeElements m_panelListe;
		private sc2i.win32.common.C2iComboBox m_cmbTypeElements;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage m_pageFiltre;
		private System.Windows.Forms.RadioButton m_btnStatique;
		private System.Windows.Forms.RadioButton m_btnDynamique;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private CheckBox m_chkSourceRecherche;
		private C2iComboBox m_cmbTypeSourceRecherche;
        private Label label5;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionListeEntites()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionListeEntites(CListeEntites listeEntites)
			:base(listeEntites)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionListeEntites(CListeEntites listeEntites,CListeObjetsDonnees liste)
			:base(listeEntites, liste)
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
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_btnDynamique = new System.Windows.Forms.RadioButton();
            this.m_btnStatique = new System.Windows.Forms.RadioButton();
            this.m_cmbTypeElements = new sc2i.win32.common.C2iComboBox();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelListe = new timos.win32.composants.CPanelSelectListeElements();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageFiltre = new Crownwood.Magic.Controls.TabPage();
            this.m_chkSourceRecherche = new System.Windows.Forms.CheckBox();
            this.m_cmbTypeSourceRecherche = new sc2i.win32.common.C2iComboBox();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageFiltre.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
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
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_btnDynamique);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnStatique);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbTypeElements);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.label4);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.Controls.Add(this.label5);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 52);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(572, 172);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_btnDynamique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnDynamique, "");
            this.m_btnDynamique.Location = new System.Drawing.Point(208, 128);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDynamique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnDynamique, "");
            this.m_btnDynamique.Name = "m_btnDynamique";
            this.m_btnDynamique.Size = new System.Drawing.Size(112, 26);
            this.m_extStyle.SetStyleBackColor(this.m_btnDynamique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDynamique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDynamique.TabIndex = 4012;
            this.m_btnDynamique.Text = "Dynamic list|922";
            this.m_btnDynamique.CheckedChanged += new System.EventHandler(this.m_btnDynamique_CheckedChanged);
            // 
            // m_btnStatique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnStatique, "");
            this.m_btnStatique.Location = new System.Drawing.Point(96, 128);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnStatique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnStatique, "");
            this.m_btnStatique.Name = "m_btnStatique";
            this.m_btnStatique.Size = new System.Drawing.Size(104, 26);
            this.m_extStyle.SetStyleBackColor(this.m_btnStatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnStatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStatique.TabIndex = 4011;
            this.m_btnStatique.Text = "Static list|921";
            this.m_btnStatique.CheckedChanged += new System.EventHandler(this.m_btnStatique_CheckedChanged);
            // 
            // m_cmbTypeElements
            // 
            this.m_cmbTypeElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElements.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElements, "");
            this.m_cmbTypeElements.Location = new System.Drawing.Point(96, 56);
            this.m_cmbTypeElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElements, "");
            this.m_cmbTypeElements.Name = "m_cmbTypeElements";
            this.m_cmbTypeElements.Size = new System.Drawing.Size(440, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElements.TabIndex = 4010;
            this.m_cmbTypeElements.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeElements_SelectedIndexChanged);
            // 
            // c2iTextBox2
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Commentaires");
            this.c2iTextBox2.Location = new System.Drawing.Point(96, 80);
            this.c2iTextBox2.LockEdition = false;
            this.c2iTextBox2.MaxLength = 2048;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Multiline = true;
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(440, 48);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 4008;
            this.c2iTextBox2.Text = "[Commentaires]";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Code");
            this.c2iTextBox1.Location = new System.Drawing.Point(96, 32);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(296, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4006;
            this.c2iTextBox1.Text = "[Code]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4009;
            this.label4.Text = "List of|920";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(96, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(440, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 4003;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4007;
            this.label3.Text = "Comment|51";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4005;
            this.label5.Text = "Label|50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4005;
            this.label2.Text = "Code|231";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4004;
            this.label1.Text = "Libelle : ";
            // 
            // m_panelListe
            // 
            this.m_panelListe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelListe.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelListe, "");
            this.m_panelListe.Location = new System.Drawing.Point(0, 0);
            this.m_panelListe.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelListe, "");
            this.m_panelListe.Name = "m_panelListe";
            this.m_panelListe.Size = new System.Drawing.Size(790, 256);
            this.m_extStyle.SetStyleBackColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListe.TabIndex = 3;
            this.m_panelListe.Load += new System.EventHandler(this.m_panelListe_Load);
            this.m_panelListe.OnChangeSelection += new System.EventHandler(this.m_panelListe_OnChangeSelection);
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
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(16, 230);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageFiltre;
            this.m_tabControl.Size = new System.Drawing.Size(806, 300);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.m_pageFiltre});
            // 
            // m_pageFiltre
            // 
            this.m_pageFiltre.Controls.Add(this.m_chkSourceRecherche);
            this.m_pageFiltre.Controls.Add(this.m_cmbTypeSourceRecherche);
            this.m_pageFiltre.Controls.Add(this.m_panelFiltre);
            this.m_extLinkField.SetLinkField(this.m_pageFiltre, "");
            this.m_pageFiltre.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiltre, "");
            this.m_pageFiltre.Name = "m_pageFiltre";
            this.m_pageFiltre.Size = new System.Drawing.Size(790, 259);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiltre.TabIndex = 11;
            this.m_pageFiltre.Title = "Filter|581";
            // 
            // m_chkSourceRecherche
            // 
            this.m_chkSourceRecherche.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_extLinkField.SetLinkField(this.m_chkSourceRecherche, "");
            this.m_chkSourceRecherche.Location = new System.Drawing.Point(64, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSourceRecherche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSourceRecherche, "");
            this.m_chkSourceRecherche.Name = "m_chkSourceRecherche";
            this.m_chkSourceRecherche.Size = new System.Drawing.Size(146, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSourceRecherche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSourceRecherche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSourceRecherche.TabIndex = 4013;
            this.m_chkSourceRecherche.Text = "Search in|831";
            this.m_chkSourceRecherche.UseVisualStyleBackColor = true;
            this.m_chkSourceRecherche.CheckedChanged += new System.EventHandler(this.m_chkSourceRecherche_CheckedChanged);
            // 
            // m_cmbTypeSourceRecherche
            // 
            this.m_cmbTypeSourceRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeSourceRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSourceRecherche.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSourceRecherche, "");
            this.m_cmbTypeSourceRecherche.Location = new System.Drawing.Point(216, 0);
            this.m_cmbTypeSourceRecherche.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSourceRecherche, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSourceRecherche, "");
            this.m_cmbTypeSourceRecherche.Name = "m_cmbTypeSourceRecherche";
            this.m_cmbTypeSourceRecherche.Size = new System.Drawing.Size(558, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSourceRecherche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSourceRecherche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSourceRecherche.TabIndex = 4012;
            this.m_cmbTypeSourceRecherche.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeSourceRecherche_SelectedIndexChanged);
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 24);
            this.m_panelFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(790, 233);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 4002;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(790, 185);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelListe);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(790, 259);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Elements|923";
            // 
            // CFormEditionListeEntites
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionListeEntites";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.AfterValideModification += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionListeEntites_AfterValideModification);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageFiltre.ResumeLayout(false);
            this.m_panelFiltre.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CListeEntites ListeEntites
		{
			get
			{
				return ((CListeEntites)ObjetEdite);
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Entity list |30223") + ListeEntites.Libelle);
			InitComboTypes ( false );

			m_chkSourceRecherche.Checked = ListeEntites.TypeElementsSourceRecherche == null;
			
			if ( ListeEntites.TypeElements != null )
				m_cmbTypeElements.SelectedValue = ListeEntites.TypeElements;

			if ( m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull))
			{
				m_panelListe.Init ( (Type)m_cmbTypeElements.SelectedValue, ListeEntites.ElementsLies, null );
			}
			else
				m_panelListe.Visible = false;

			if ( ListeEntites.FiltreDynamique == null )
				m_filtreDynamique = new CFiltreDynamique ( ListeEntites.ContexteDonnee );
			else
				m_filtreDynamique = ListeEntites.FiltreDynamique;

			if ( ListeEntites.TypeElements != null )
				m_filtreDynamique.TypeElements = ListeEntites.TypeElements;
			if (ListeEntites.TypeElementsSourceRecherche != null)
				m_filtreDynamique.ElementAVariablesExterne = ListeEntites.GetElementAVariableSourceFromType(ListeEntites.TypeElementsSourceRecherche);
			else
				m_filtreDynamique.ElementAVariablesExterne = null;

			m_panelFiltre.InitSansVariables ( m_filtreDynamique );

			m_btnDynamique.Checked = ListeEntites.FiltreDynamique != null;
			m_btnStatique.Checked = !m_btnDynamique.Checked;

			UpdateAspect();


			UpdateEnableComboType();
			
			return result;
		}
		//-------------------------------------------------------------------------
		private bool m_bComboRemplissageInitialized = false;
		protected void InitComboTypes ( bool bForcerRemplissage )
		{
			if (!m_bComboRemplissageInitialized || bForcerRemplissage)
			{
				ArrayList classes = new ArrayList(DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)));
                classes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeElements.DataSource = null;
				m_cmbTypeElements.DataSource = classes;
				m_cmbTypeElements.ValueMember = "Classe";
				m_cmbTypeElements.DisplayMember = "Nom";

				classes = new ArrayList(DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)));
                classes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(None)|30291")));
                m_cmbTypeSourceRecherche.DataSource = null;
				m_cmbTypeSourceRecherche.DataSource = classes;
				m_cmbTypeSourceRecherche.ValueMember = "Classe";
				m_cmbTypeSourceRecherche.DisplayMember = "Nom";

				m_bComboRemplissageInitialized = true;
			}
			if ( ListeEntites.TypeElements != null )
				m_cmbTypeElements.SelectedValue = ListeEntites.TypeElements;
			if (ListeEntites.TypeElementsSourceRecherche != null)
				m_cmbTypeSourceRecherche.SelectedValue = ListeEntites.TypeElementsSourceRecherche;
		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeElements_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_panelListe.Visible = m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull);
			if ( m_cmbTypeElements.SelectedValue is Type &&
				m_cmbTypeElements.SelectedValue != typeof(DBNull) 
				&& m_bComboRemplissageInitialized)
			{
				ReinitPanelFiltre();
			}
		}

		//-------------------------------------------------------------------------
		private void ReinitPanelFiltre()
		{
			if ( m_cmbTypeElements.SelectedValue is Type && m_bComboRemplissageInitialized && m_cmbTypeElements.SelectedValue != typeof(DBNull))
			{
				Type tp = (Type)m_cmbTypeElements.SelectedValue;
				m_panelListe.Init ( tp, new CObjetDonneeAIdNumerique[0], null );
				if ( m_filtreDynamique != null )
				{
					m_filtreDynamique.TypeElements = tp;
					if (m_chkSourceRecherche.Checked && m_cmbTypeSourceRecherche.SelectedValue is Type && m_cmbTypeSourceRecherche.SelectedValue != typeof(DBNull) )
					{
						Type tpTmp = (Type)m_cmbTypeSourceRecherche.SelectedValue;
						m_filtreDynamique.ElementAVariablesExterne = ListeEntites.GetElementAVariableSourceFromType(tpTmp);
					}
					else
						m_filtreDynamique.ElementAVariablesExterne = null;
					m_panelFiltre.InitSansVariables ( m_filtreDynamique );
				}
			}
		}

		//-------------------------------------------------------------------------
		private void UpdateEnableComboType()
		{
			if ( m_panelListe.ElementSelectionnes.Length  > 0 )
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeElements, TypeModeEdition.Autonome );
				m_cmbTypeElements.LockEdition = true;
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeElements, TypeModeEdition.EnableSurEdition );
				m_cmbTypeElements.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
		}

		//-------------------------------------------------------------------------
		private void m_panelListe_OnChangeSelection(object sender, System.EventArgs e)
		{
			UpdateEnableComboType();
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !(m_cmbTypeElements.SelectedValue is Type && m_cmbTypeElements.SelectedValue != typeof(DBNull) ))
			{
				result.EmpileErreur (I.T("Select an element type for this list|30224"));
				return result;
			}
			ListeEntites.TypeElements = (Type)m_cmbTypeElements.SelectedValue;
			if (m_btnDynamique.Checked)
			{
				ListeEntites.FiltreDynamique = m_panelFiltre.FiltreDynamique;
				if (m_chkSourceRecherche.Checked)
					ListeEntites.TypeElementsSourceRecherche = (Type)m_cmbTypeSourceRecherche.SelectedValue;
				else
					ListeEntites.TypeElementsSourceRecherche = null;
			}
			else
			{
				ListeEntites.ElementsLies = m_panelListe.ElementSelectionnes;
				ListeEntites.TypeElementsSourceRecherche = null;
			}

			return result;
		}

		//-------------------------------------------------------------------------
		private void m_panelListe_Load(object sender, System.EventArgs e)
		{
		
		}

		//-------------------------------------------------------------------------
		private void UpdateAspect()
		{
			if ( m_btnDynamique.Checked )
			{
				if ( !m_tabControl.TabPages.Contains ( m_pageFiltre ) )
					m_tabControl.TabPages.Add ( m_pageFiltre );
				m_gestionnaireModeEdition.SetModeEdition ( m_panelListe, TypeModeEdition.Autonome );
				m_panelListe.LockEdition = true;
			}
			else
			{
				if ( m_tabControl.TabPages.Contains ( m_pageFiltre ) )
					m_tabControl.TabPages.Remove ( m_pageFiltre );
				m_gestionnaireModeEdition.SetModeEdition ( m_panelListe, TypeModeEdition.EnableSurEdition );
				m_panelListe.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnStatique_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAspect();
		}

		//-------------------------------------------------------------------------
		private void m_btnDynamique_CheckedChanged(object sender, System.EventArgs e)
		{
			UpdateAspect();
		}

		//-------------------------------------------------------------------------
		private void CFormEditionListeEntites_AfterValideModification(object sender, sc2i.data.CObjetDonneeEventArgs args)
		{
		
		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeSourceRecherche_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_cmbTypeSourceRecherche.SelectedValue is Type && m_bComboRemplissageInitialized && m_cmbTypeSourceRecherche.SelectedValue != typeof(DBNull))
			{
				ReinitPanelFiltre();
			}
		}

		//-------------------------------------------------------------------------
		private void m_chkSourceRecherche_CheckedChanged(object sender, EventArgs e)
		{
			ReinitPanelFiltre();
		}

	}
}

