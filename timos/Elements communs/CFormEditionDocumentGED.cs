using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.documents;
using sc2i.workflow;
using System.Collections.Generic;


namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CDocumentGED))]
	public class CFormEditionDocumentGED : CFormEditionStdTimos, IFormNavigable
	{

		


		//Table PRocess->ProxyGed
		private Hashtable m_tableProcessToFichierOuvert = new Hashtable();

		private CObjetDonneeAIdNumerique m_objetAuquelAttacher = null;
        private CProxyGED m_proxyGed = null;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label m_labelDateCreation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label8;
        private sc2i.win32.common.C2iTextBox c2iTextBox2;
        private System.Windows.Forms.LinkLabel m_lnkVisualiser;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private Crownwood.Magic.Controls.TabPage m_pageVisualisation;
		private Crownwood.Magic.Controls.TabPage m_pageInformations;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private System.Windows.Forms.LinkLabel m_lnkAssocier;
		private timos.CVisualiseurGed m_visualiseur;
		private System.Windows.Forms.LinkLabel m_lnkModifier;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChampsCustom;
        private LinkLabel m_lnkSaveAs;
        private Label label11;
        private CComboboxAutoFilled m_cmbModeStockage;
        private C2iPanel m_panelStorage;
        private Label label1;
        private C2iPanelOmbre c2iPanelOmbre4;
        private SplitContainer splitContainer1;
        private Label label9;
        private CArbreObjetsDonneesHierarchiques m_arbreCategories;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionDocumentGED()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionDocumentGED(CDocumentGED origine)
			:base(origine)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionDocumentGED(CDocumentGED origine,CListeObjetsDonnees liste)
			:base(origine, liste)
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
				if ( m_proxyGed != null )
					m_proxyGed.Dispose();
				m_proxyGed = null;
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
            this.m_lnkVisualiser = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_labelDateCreation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageInformations = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_arbreCategories = new sc2i.win32.data.CArbreObjetsDonneesHierarchiques();
            this.label9 = new System.Windows.Forms.Label();
            this.m_panelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageVisualisation = new Crownwood.Magic.Controls.TabPage();
            this.m_visualiseur = new timos.CVisualiseurGed();
            this.m_panelStorage = new sc2i.win32.common.C2iPanel(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.m_cmbModeStockage = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_lnkModifier = new System.Windows.Forms.LinkLabel();
            this.m_lnkAssocier = new System.Windows.Forms.LinkLabel();
            this.m_lnkSaveAs = new System.Windows.Forms.LinkLabel();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.m_pageInformations.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_pageVisualisation.SuspendLayout();
            this.m_panelStorage.SuspendLayout();
            this.c2iPanelOmbre4.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(768, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(681, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(943, 28);
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
            // m_lnkVisualiser
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkVisualiser, "");
            this.m_lnkVisualiser.Location = new System.Drawing.Point(768, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkVisualiser, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkVisualiser, "");
            this.m_lnkVisualiser.Name = "m_lnkVisualiser";
            this.m_lnkVisualiser.Size = new System.Drawing.Size(143, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkVisualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkVisualiser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkVisualiser.TabIndex = 4017;
            this.m_lnkVisualiser.TabStop = true;
            this.m_lnkVisualiser.Text = "View|849";
            this.m_lnkVisualiser.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkVisualiser_LinkClicked);
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(5, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4014;
            this.label8.Text = "Key word|847";
            // 
            // c2iTextBox2
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Cle");
            this.c2iTextBox2.Location = new System.Drawing.Point(106, 90);
            this.c2iTextBox2.LockEdition = false;
            this.c2iTextBox2.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(400, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 4013;
            this.c2iTextBox2.Text = "[Cle]";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(5, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4012;
            this.label7.Text = "Description|833";
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Descriptif");
            this.c2iTextBox1.Location = new System.Drawing.Point(106, 33);
            this.c2iTextBox1.LockEdition = false;
            this.c2iTextBox1.MaxLength = 1024;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(400, 51);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 4011;
            this.c2iTextBox1.Text = "[Descriptif]";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.label5, "NumVersion");
            this.label5.Location = new System.Drawing.Point(616, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4010;
            this.label5.Text = "[NumVersion]";
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(511, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4009;
            this.label6.Text = "Version|846";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.label3, "DateMAJ");
            this.label3.Location = new System.Drawing.Point(616, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4008;
            this.label3.Text = "[DateMAJ]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(511, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4007;
            this.label4.Text = "Modification|845";
            // 
            // m_labelDateCreation
            // 
            this.m_labelDateCreation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_labelDateCreation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_labelDateCreation, "DateCreation");
            this.m_labelDateCreation.Location = new System.Drawing.Point(616, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelDateCreation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelDateCreation, "");
            this.m_labelDateCreation.Name = "m_labelDateCreation";
            this.m_labelDateCreation.Size = new System.Drawing.Size(136, 20);
            this.m_extStyle.SetStyleBackColor(this.m_labelDateCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelDateCreation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelDateCreation.TabIndex = 4006;
            this.m_labelDateCreation.Text = "[DateCreation]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(511, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4005;
            this.label2.Text = "Creation date|10032";
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4004;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(106, 7);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.MaxLength = 255;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(400, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 4003;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Category|852";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 250;
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 185);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageInformations;
            this.m_tabControl.Size = new System.Drawing.Size(931, 400);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageVisualisation,
            this.m_pageInformations});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_pageInformations
            // 
            this.m_pageInformations.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_pageInformations, "");
            this.m_pageInformations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInformations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInformations, "");
            this.m_pageInformations.Name = "m_pageInformations";
            this.m_pageInformations.Size = new System.Drawing.Size(915, 359);
            this.m_extStyle.SetStyleBackColor(this.m_pageInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInformations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInformations.TabIndex = 11;
            this.m_pageInformations.Title = "Information|58";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_arbreCategories);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelChampsCustom);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(909, 353);
            this.splitContainer1.SplitterDistance = 303;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 4022;
            // 
            // m_arbreCategories
            // 
            this.m_arbreCategories.AddRootForAll = false;
            this.m_arbreCategories.AutoriserFilsDesAutorises = true;
            this.m_arbreCategories.CheckBoxes = true;
            this.m_arbreCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreCategories.ElementSelectionne = null;
            this.m_arbreCategories.ElementsSelectionnes = new sc2i.data.CObjetDonnee[0];
            this.m_arbreCategories.ForeColorNonSelectionnable = System.Drawing.Color.DarkGray;
            this.m_extLinkField.SetLinkField(this.m_arbreCategories, "");
            this.m_arbreCategories.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreCategories, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreCategories, "");
            this.m_arbreCategories.Name = "m_arbreCategories";
            this.m_arbreCategories.RootLabel = "Root";
            this.m_arbreCategories.Size = new System.Drawing.Size(301, 326);
            this.m_extStyle.SetStyleBackColor(this.m_arbreCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreCategories, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreCategories.TabIndex = 4015;
            this.m_arbreCategories.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreCategories_AfterCheck);
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(301, 25);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4014;
            this.label9.Text = "EDM Categories|848";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChampsCustom.BoldSelectedPage = true;
            this.m_panelChampsCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChampsCustom.ElementEdite = null;
            this.m_panelChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelChampsCustom.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Location = new System.Drawing.Point(0, 0);
            this.m_panelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChampsCustom, "");
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Ombre = false;
            this.m_panelChampsCustom.PositionTop = true;
            this.m_panelChampsCustom.Size = new System.Drawing.Size(600, 351);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChampsCustom.TabIndex = 4021;
            this.m_panelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageVisualisation
            // 
            this.m_pageVisualisation.Controls.Add(this.m_visualiseur);
            this.m_extLinkField.SetLinkField(this.m_pageVisualisation, "");
            this.m_pageVisualisation.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageVisualisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageVisualisation, "");
            this.m_pageVisualisation.Name = "m_pageVisualisation";
            this.m_pageVisualisation.Selected = false;
            this.m_pageVisualisation.Size = new System.Drawing.Size(915, 359);
            this.m_extStyle.SetStyleBackColor(this.m_pageVisualisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageVisualisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageVisualisation.TabIndex = 10;
            this.m_pageVisualisation.Title = "Document|10099";
            // 
            // m_visualiseur
            // 
            this.m_visualiseur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_visualiseur, "");
            this.m_visualiseur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_visualiseur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_visualiseur, "");
            this.m_visualiseur.Name = "m_visualiseur";
            this.m_visualiseur.Size = new System.Drawing.Size(915, 359);
            this.m_extStyle.SetStyleBackColor(this.m_visualiseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_visualiseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_visualiseur.TabIndex = 0;
            // 
            // m_panelStorage
            // 
            this.m_panelStorage.Controls.Add(this.label11);
            this.m_panelStorage.Controls.Add(this.m_cmbModeStockage);
            this.m_extLinkField.SetLinkField(this.m_panelStorage, "");
            this.m_panelStorage.Location = new System.Drawing.Point(512, 5);
            this.m_panelStorage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStorage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelStorage, "");
            this.m_panelStorage.Name = "m_panelStorage";
            this.m_panelStorage.Size = new System.Drawing.Size(232, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelStorage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelStorage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStorage.TabIndex = 4025;
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4023;
            this.label11.Text = "Storage|20112";
            // 
            // m_cmbModeStockage
            // 
            this.m_cmbModeStockage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeStockage.FormattingEnabled = true;
            this.m_cmbModeStockage.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbModeStockage, "");
            this.m_cmbModeStockage.ListDonnees = null;
            this.m_cmbModeStockage.Location = new System.Drawing.Point(95, 2);
            this.m_cmbModeStockage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeStockage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbModeStockage, "");
            this.m_cmbModeStockage.Name = "m_cmbModeStockage";
            this.m_cmbModeStockage.NullAutorise = false;
            this.m_cmbModeStockage.ProprieteAffichee = null;
            this.m_cmbModeStockage.Size = new System.Drawing.Size(134, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeStockage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeStockage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeStockage.TabIndex = 4024;
            this.m_cmbModeStockage.TextNull = "(empty)";
            this.m_cmbModeStockage.Tri = true;
            // 
            // m_lnkModifier
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkModifier, "");
            this.m_lnkModifier.Location = new System.Drawing.Point(768, 78);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkModifier, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkModifier, "");
            this.m_lnkModifier.Name = "m_lnkModifier";
            this.m_lnkModifier.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lnkModifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkModifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkModifier.TabIndex = 4020;
            this.m_lnkModifier.TabStop = true;
            this.m_lnkModifier.Text = "Edit|850";
            this.m_lnkModifier.Visible = false;
            this.m_lnkModifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkModifier_LinkClicked);
            // 
            // m_lnkAssocier
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkAssocier, "");
            this.m_lnkAssocier.Location = new System.Drawing.Point(768, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAssocier, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAssocier, "");
            this.m_lnkAssocier.Name = "m_lnkAssocier";
            this.m_lnkAssocier.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAssocier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAssocier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAssocier.TabIndex = 4019;
            this.m_lnkAssocier.TabStop = true;
            this.m_lnkAssocier.Text = "Attach file|851";
            this.m_lnkAssocier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAssocier_LinkClicked);
            // 
            // m_lnkSaveAs
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkSaveAs, "");
            this.m_lnkSaveAs.Location = new System.Drawing.Point(768, 56);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSaveAs, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSaveAs, "");
            this.m_lnkSaveAs.Name = "m_lnkSaveAs";
            this.m_lnkSaveAs.Size = new System.Drawing.Size(143, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSaveAs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSaveAs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSaveAs.TabIndex = 4017;
            this.m_lnkSaveAs.TabStop = true;
            this.m_lnkSaveAs.Text = "Save as...|10029";
            this.m_lnkSaveAs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSaveAs_LinkClicked);
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_panelStorage);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkModifier);
            this.c2iPanelOmbre4.Controls.Add(this.m_labelDateCreation);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkAssocier);
            this.c2iPanelOmbre4.Controls.Add(this.label7);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.c2iTextBox2);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkSaveAs);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkVisualiser);
            this.c2iPanelOmbre4.Controls.Add(this.label8);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label6);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 39);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(931, 140);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 4005;
            // 
            // CFormEditionDocumentGED
            // 
            this.ClientSize = new System.Drawing.Size(943, 590);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionDocumentGED";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.BeforeValideModification += new sc2i.data.ObjetDonneeCancelEventHandler(this.CFormEditionDocumentGED_BeforeValideModification);
            this.AfterValideModification += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionDocumentGED_AfterValideModification);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageInformations.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_pageVisualisation.ResumeLayout(false);
            this.m_panelStorage.ResumeLayout(false);
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CDocumentGED DocumentGED
		{
			get
			{
				return ((CDocumentGED)ObjetEdite);
			}
		}
		//-------------------------------------------------------------------------
        bool m_bInitialisingArbre = false;
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre("Document " + DocumentGED.Libelle);

            m_cmbModeStockage.NullAutorise = false;
            m_cmbModeStockage.ProprieteAffichee = "Libelle";
            m_cmbModeStockage.ListDonnees = DocumentGED.TypesAutorisesPourLesUtilisateurs;
            m_cmbModeStockage.SelectedValue = DocumentGED.TypesAutorisesPourLesUtilisateurs[0];
            m_panelStorage.Visible = DocumentGED.TypesAutorisesPourLesUtilisateurs.Length > 1;

            if (DocumentGED.IsNew())
                m_cmbModeStockage.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
            else
                m_cmbModeStockage.LockEdition = true;

            //m_panelCategories.Init ( 
            //    new CListeObjetsDonnees ( DocumentGED.ContexteDonnee, typeof(CCategorieGED) ),
            //    CRelationDocumentGED_Categorie.GetRelationsCategoriesForDocument ( DocumentGED ),
            //    DocumentGED,
            //    "Document",
            //    "Categorie");
            //m_panelCategories.RemplirGrille();

            // Nouvelle initialisation des catégories de GED Hiérarchiques (arbre)
            m_arbreCategories.BeginUpdate();
            m_bInitialisingArbre = true;

            CListeObjetsDonnees lstRelationsCategories = DocumentGED.RelationsCategories;
            CFiltreData filtre = null;
            if (!m_gestionnaireModeEdition.ModeEdition)
            {
                List<string> lstIDsAAfficher = new List<string>();
                foreach (CRelationDocumentGED_Categorie rel in lstRelationsCategories)
                {
                    lstIDsAAfficher.Add(rel.Categorie.Id.ToString());
                }
                if (lstIDsAAfficher.Count > 0)
                {
                    filtre = new CFiltreData(CCategorieGED.c_champId + " in (" +
                        string.Join(",", lstIDsAAfficher.ToArray()) + ")");
                }
                else
                {
                    filtre = new CFiltreDataImpossible();
                }
            }


            m_arbreCategories.Init(
                typeof(CCategorieGED),
                "CategoriesFilles",
                CCategorieGED.c_champIdParent,
                "Libelle",
                filtre,
                null);


            foreach (CRelationDocumentGED_Categorie rel in lstRelationsCategories)
            {
                m_arbreCategories.SetChecked(rel.Categorie, true);
                TreeNode node = m_arbreCategories.GetNodeFor(rel.Categorie);
                while (node != null)
                {
                    node = node.Parent;
                    if (node != null)
                        node.Expand();
                }
            }

            m_bInitialisingArbre = false;

            m_arbreCategories.EndUpdate();

            m_panelChampsCustom.ElementEdite = DocumentGED;


			if (!m_tabControl.TabPages.Contains(m_pageVisualisation) && !DocumentGED.IsNew())
				m_tabControl.TabPages.Insert(0, m_pageVisualisation);
            if (m_tabControl.TabPages.Contains(m_pageVisualisation) && DocumentGED.IsNew())
                m_tabControl.TabPages.Remove(m_pageVisualisation);

            if (m_tabControl.SelectedTab == m_pageVisualisation)
                ViewFichier();

			CHistoriqueDocumentGencod.StockeHistorique ( DocumentGED );

            CReferenceDocument refDoc = DocumentGED.ReferenceDoc;
            if (refDoc != null)
                m_cmbModeStockage.SelectedValue = refDoc.TypeReference;

			return result;
		}

		/// <summary>
		/// /////////////////////////////////////////////////////////
		/// </summary>
		private void ViewFichier()
		{
			CResultAErreur result = CResultAErreur.True;
			try
			{
				if (m_proxyGed == null || m_proxyGed.ReferenceAttachee == null || !m_proxyGed.ReferenceAttachee.Equals(DocumentGED.ReferenceDoc))
				{
					CProxyGED newProxy = new CProxyGED(DocumentGED.ContexteDonnee.IdSession, DocumentGED.ReferenceDoc);
					result = newProxy.CopieFichierEnLocal();
					if (m_proxyGed != null)
						m_proxyGed.Dispose();
					m_proxyGed = newProxy;
				}
				if ( result )
				{
					if (m_visualiseur.ShowDocument(m_proxyGed.NomFichierLocal))
					{
						m_visualiseur.Visible = true;
						if ( !m_tabControl.TabPages.Contains(m_pageVisualisation) )
							m_tabControl.TabPages.Insert (0, m_pageVisualisation );
						return;
					}
				}
			}
			catch ( Exception e )
			{
				result.EmpileErreur ( new CErreurException ( e ) );
			}
			if ( !result )
				m_visualiseur.Visible = false;
			if ( m_tabControl.TabPages.Contains(m_pageVisualisation) )
				m_tabControl.TabPages.Remove ( m_pageVisualisation );
		}


		/// /////////////////////////////////////////////////////////
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			if ( !result )
				return result;
			
			//m_panelCategories.ApplyModifs();
            // Sauve les rRelations avec les Catégories 
            Hashtable tableRelationsToDelete = new Hashtable();
            Hashtable tableCategorieToRelation = new Hashtable();
            foreach (CRelationDocumentGED_Categorie rel in DocumentGED.RelationsCategories)
            {
                tableRelationsToDelete[rel.Categorie] = true;
                tableCategorieToRelation[rel.Categorie] = rel;
            }

            ArrayList lstSelected = new ArrayList();
            foreach (CCategorieGED categorie in m_arbreCategories.ElementsSelectionnes)
            {
                bool bShouldAdd = true;
                foreach (CCategorieGED entiteTest in lstSelected.ToArray())
                {
                    if (entiteTest.IsChildOf(categorie))
                        lstSelected.Remove(entiteTest);
                    if (entiteTest.IsParentOf(categorie))
                    {
                        bShouldAdd = false;
                        break;
                    }
                }
                if (bShouldAdd)
                {
                    lstSelected.Add(categorie);
                }
            }

            foreach (CCategorieGED categorie in lstSelected)
            {
                tableRelationsToDelete[categorie] = false;
                if (tableCategorieToRelation[categorie] == null)
                {
                    CRelationDocumentGED_Categorie rel = new CRelationDocumentGED_Categorie(DocumentGED.ContexteDonnee);
                    rel.CreateNewInCurrentContexte();
                    rel.Categorie = categorie;
                    rel.Document = DocumentGED;
                }
            }

            foreach (DictionaryEntry entry in tableRelationsToDelete)
            {
                if ((bool)entry.Value)
                {
                    CRelationDocumentGED_Categorie rel = (CRelationDocumentGED_Categorie)tableCategorieToRelation[entry.Key];
                    result = rel.Delete();
                    if (!result)
                        return result;
                }
            }

            // Champs custom
            result = m_panelChampsCustom.MAJ_Champs();
			
            if ( result && m_proxyGed != null && m_proxyGed.IsFichierRappatrie() && m_proxyGed.HasChange() )
			{
				result = m_proxyGed.UpdateGed();
				DocumentGED.ReferenceDoc = (CReferenceDocument)result.Data;
			}
			
			return result;
		}

		//Nom de fichier -> document ged associé
		private class CSurveilleurFichier : IDisposable
		{
			public readonly int IdGed = -1;
			public readonly string NomFichier = "";
			private int m_nVersionGed = 0;
			private FileSystemWatcher m_watcher = null;

			public CSurveilleurFichier ( 
				int nIdGed,
				string strNomFichier,
				int nVersionGed )
			{
				IdGed = nIdGed;
				NomFichier = strNomFichier.ToUpper();
				m_nVersionGed = nVersionGed;
				m_watcher = new FileSystemWatcher ( Path.GetDirectoryName ( strNomFichier ),
					Path.GetFileName ( strNomFichier ) );
				m_watcher.Deleted += new FileSystemEventHandler(m_watcher_Deleted);
				m_watcher.Changed += new FileSystemEventHandler(m_watcher_Modified);
				m_watcher.EnableRaisingEvents = true;
				m_tableFichierToSurveilleur[NomFichier] = this;
				
				m_tableIdGedToSurveilleur[nIdGed] = this;
			}

			public int VersionGed
			{
				get
				{
					return m_nVersionGed;
				}
				set
				{
					m_nVersionGed = value;
				}
			}
			#region Membres de IDisposable

			public void Dispose()
			{
				m_tableFichierToSurveilleur.Remove ( NomFichier );
				m_tableIdGedToSurveilleur.Remove ( IdGed );
				if ( m_watcher != null )
					m_watcher.Dispose();
				m_watcher = null;
			}

			#endregion
		}

		//Id documentGed -> CSurveilleurFichier
		private static Hashtable m_tableIdGedToSurveilleur = new Hashtable();
		private static Hashtable m_tableFichierToSurveilleur = new Hashtable();
		//-----------------------------------------------------------------------------------------------
        private void m_lnkVisualiser_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			EditDocument ( false );
		}


        //-----------------------------------------------------------------------------------------------
        private void m_lnkSaveAs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveDocument();
        }

        //-----------------------------------------------------------------------------------------------
        private void EditDocument(bool bEnModif)
		{
			if ( m_gestionnaireModeEdition.ModeEdition )
				return;
			if ( m_tableIdGedToSurveilleur[DocumentGED.Id] != null )
			{
				CSurveilleurFichier surveilleur = (CSurveilleurFichier)m_tableIdGedToSurveilleur[DocumentGED.Id];
				try
				{
					FileStream stream = new FileStream ( surveilleur.NomFichier, FileMode.Append, FileAccess.Write, FileShare.None );
					stream.Close();
					File.Delete ( surveilleur.NomFichier );
					
				}
				catch
				{
					if ( CFormAlerte.Afficher(I.T("The file is already open, alla previous modification will be lost. Do you want to continue anyway?|1294"),
						EFormAlerteType.Question) == DialogResult.No )
						return;
				}
				surveilleur.Dispose();
				
			}
			if ( DocumentGED.ReferenceDoc == null )
			{
				CFormAlerte.Afficher(I.T("Nothing to visualize|1295"), EFormAlerteType.Exclamation);
				return;
			}
			CProxyGED proxy = new CProxyGED ( DocumentGED.ContexteDonnee.IdSession, DocumentGED.ReferenceDoc );
			CResultAErreur result = proxy.CopieFichierEnLocal();
			if ( result )
			{
				System.Diagnostics.Process process = new System.Diagnostics.Process();
				//process.StartInfo.FileName = proxy.NomFichierLocal;
                process.StartInfo.FileName = "\"" + proxy.NomFichierLocal + "\"";// @"rundll32.exe"; 
                //process.StartInfo.Arguments = "\""+proxy.NomFichierLocal+"\"";
				process.StartInfo.UseShellExecute = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
				process.EnableRaisingEvents = true;
				try
				{
					process.Start();
					if ( bEnModif )
						new CSurveilleurFichier ( 
							DocumentGED.Id,
							proxy.NomFichierLocal,
							DocumentGED.NumVersion );

                    try//sur certains postes, process.Id genere une erreur
                    {
                        if (process.Id != null)
                        {
                            m_tableProcessToFichierOuvert[process.Id] = proxy;
                            process.Exited += new EventHandler(process_Exited);
                        }
                    }
                    catch { }

					
				}
				catch (Exception ex )
				{
					result.EmpileErreur ( new CErreurException ( ex ) );
					result.EmpileErreur (I.T("Error while loading viewer|1296"));
				}
			}
			if ( !result )
				CFormAlerte.Afficher ( result.Erreur );							
		}

        //-----------------------------------------------------------------------------------------------
        private void SaveDocument()
        {
            if (m_gestionnaireModeEdition.ModeEdition)
                return;

            if (DocumentGED.ReferenceDoc == null)
            {
                CFormAlerte.Afficher(I.T("Nothing to save|10030"), EFormAlerteType.Exclamation);
                return;
            }
            CProxyGED proxy = new CProxyGED(DocumentGED.ContexteDonnee.IdSession, DocumentGED.ReferenceDoc);
            CResultAErreur result = proxy.CopieFichierEnLocal();
            if (result)
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = proxy.NomFichierLocal;
                string strDir = Path.GetDirectoryName(proxy.NomFichierLocal);
                string strTitle = DocumentGED.Libelle;
                strTitle = CUtilRepertoire.GetValidFileName(strTitle, '_');
                string strExt = Path.GetExtension(proxy.NomFichierLocal);
                if ( strExt.Length > 0 && strExt[0] != '.')
                    strExt = "."+strExt;
                if (strDir[strDir.Length - 1] != '\\')
                    strDir += "\\";
                dlg.FileName = strDir + strTitle +  strExt;
                string strNomFichierSave = "";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        strNomFichierSave = dlg.FileName;
                        File.Copy(proxy.NomFichierLocal, strNomFichierSave);

                    }
                    catch (Exception ex)
                    {
                        result.EmpileErreur(new CErreurException(ex));
                        result.EmpileErreur(I.T("Error while saving file|10031"));
                    }
                }
            }
            if (!result)
                CFormAlerte.Afficher(result.Erreur);
        }

        //-----------------------------------------------------------------------------------------------
        private void m_tabControl_SelectionChanged(object sender, System.EventArgs e)
		{
			if ( m_tabControl.SelectedTab == m_pageVisualisation )
				ViewFichier();
		}

        //-----------------------------------------------------------------------------------------------
        private void m_lnkAssocier_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			OpenFileDialog	 dlg = new OpenFileDialog ();
			if ( dlg.ShowDialog() == DialogResult.OK )
			{
				if ( m_proxyGed != null )
					m_proxyGed.Dispose();
                CTypeReferenceDocument typeRef = m_cmbModeStockage.SelectedValue as CTypeReferenceDocument;
                if (DocumentGED.ReferenceDoc != null)
                    typeRef = DocumentGED.ReferenceDoc.TypeReference;
                if ( typeRef == null )
                    typeRef = new CTypeReferenceDocument ( CTypeReferenceDocument.TypesReference.Fichier );
				m_proxyGed = new CProxyGED ( DocumentGED.ContexteDonnee.IdSession, typeRef.Code );
				m_proxyGed.AttacheToLocal ( dlg.FileName );
                m_cmbModeStockage.LockEdition = true;
			}

		}

		private void CFormEditionDocumentGED_BeforeValideModification(object sender, sc2i.data.CObjetDonneeCancelEventArgs args)
		{
		
		}

		private void CFormEditionDocumentGED_AfterValideModification(object sender, sc2i.data.CObjetDonneeEventArgs args)
		{
			if ( m_objetAuquelAttacher != null )
			{
				DocumentGED.BeginEdit();
				DocumentGED.LinkTo( m_objetAuquelAttacher );
				DocumentGED.CommitEdit();
			}
		}
		//-------------------------------------------------------------------------
		/// <summary>
		/// Objet auquel attacher tout nouveau document
		/// </summary>
		public CObjetDonneeAIdNumerique ObjetAuquelAttacher
		{
			get
			{
				return m_objetAuquelAttacher;
			}
			set
			{
				m_objetAuquelAttacher = value;
			}
		}

		private void process_Exited(object sender, EventArgs e)
		{
			if ( sender is System.Diagnostics.Process )
			{
				int nId = ((System.Diagnostics.Process)sender).Id;
				CProxyGED proxy = (CProxyGED)m_tableProcessToFichierOuvert[nId];
				if ( proxy != null )
				{
					while (!proxy.DeleteFichierLocal() )
					{
						System.Threading.Thread.Sleep ( 1000*30 );
					}
					proxy.Dispose();
				}
				m_tableProcessToFichierOuvert.Remove ( nId );
			}

		}

		//------------------------------------------------------------------------
		private static void m_watcher_Deleted(object sender, FileSystemEventArgs e)
		{
			CSurveilleurFichier surveilleur = (CSurveilleurFichier)m_tableFichierToSurveilleur[e.FullPath.ToUpper()] ;
			if ( surveilleur != null )
			{
				m_tableIdGedToSurveilleur.Remove ( surveilleur.IdGed );
				surveilleur.Dispose();
			}
		}

		private class CLockerWatcher{}
		//------------------------------------------------------------------------
		//Pour éviter de sauver deux fois le même fichier. Stocke les timestamp des fichiers
		private static Hashtable m_tableKeysSurv =  new Hashtable();
		private static void m_watcher_Modified(object sender, FileSystemEventArgs e)
		{
			if ( e.ChangeType != WatcherChangeTypes.Changed )
				return;
			lock ( typeof(CLockerWatcher) )
			{
				string strKey = e.FullPath+"_"+File.GetLastWriteTime(e.FullPath).ToString("HH:mm:ss");
				if ( m_tableKeysSurv[strKey] != null )
					return;
				m_tableKeysSurv[strKey] = true;
				CSurveilleurFichier surveilleur = (CSurveilleurFichier)m_tableFichierToSurveilleur[e.FullPath.ToUpper()];
				if ( surveilleur == null )
					return;

				CDocumentGED doc = new CDocumentGED ( CSc2iWin32DataClient.ContexteCourant );
				if ( !doc.ReadIfExists ( surveilleur.IdGed ) )
					return;

				string strMesVersion ="";
				if ( doc.NumVersion != surveilleur.VersionGed )
				{
                    strMesVersion = I.T("THIS DOCUMENT SEEMS TO HAVE BEEN MODIFIED ELSEWHERE, iNFORMATION MAY BE LOST WHEN APPLYING MODIFICATIONS.\r\n|30127"); 
					if ( CFormAlerte.Afficher("The document |30128"+
						doc.Libelle+I.T(" has been modified.\r\n |30129")+strMesVersion+I.T("Do you want to apply and store the modifications ?|30130"),
						EFormAlerteType.Question ) == DialogResult.No )
						return;
				}
				CProxyGED proxy = new CProxyGED ( CTimosApp.SessionClient.IdSession, doc.ReferenceDoc );
				proxy.AttacheToLocal ( surveilleur.NomFichier );
				CResultAErreur result = proxy.UpdateGed();
				if ( result )
				{
					doc.BeginEdit();
					doc.ReferenceDoc = (CReferenceDocument)result.Data;
					doc.NumVersion++;
					result = doc.CommitEdit();
					if ( result )
						surveilleur.VersionGed = doc.NumVersion;
				}
				if ( !result )
				{
					CFormAlerte.Afficher ( result.Erreur );
				}
				else
				{
				

				}
			}
		}

        //--------------------------------------------------------------------------------
        private void m_lnkModifier_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			EditDocument ( true );
		}

        //--------------------------------------------------------------------------------
        private void m_arbreCategories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (m_bInitialisingArbre)
                return;

            CObjetDonnee checkedElement = m_arbreCategories.GetObjetInNode(e.Node);
            if (checkedElement != null)
            {
                CCategorieGED categorie = checkedElement as CCategorieGED;
                if (categorie != null && m_gestionnaireModeEdition.ModeEdition)
                {
                    CResultAErreur result = MAJ_Champs();
                    if (!result)
                        CFormAlerte.Afficher(result.MessageErreur);
                    else
                        m_panelChampsCustom.ElementEdite = DocumentGED;
                }
            }
        }

		
	}

	public class CHistoriqueDocumentGencod
	{
		private static ArrayList m_listeDerniersDocuments = new ArrayList();
		public int IdDocumentGed;
		public string LibelleDocument;

		public CHistoriqueDocumentGencod ( CDocumentGED document )
		{
			IdDocumentGed = document.Id;
			LibelleDocument = document.Libelle;
		}

		public override int GetHashCode()
		{
			return IdDocumentGed;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is CHistoriqueDocumentGencod ) )
				return false;
			return GetHashCode() == obj.GetHashCode();
		}

		public static void StockeHistorique ( CDocumentGED document )
		{
			if ( document.Id < 0 )
				return;
			CHistoriqueDocumentGencod histo = new CHistoriqueDocumentGencod ( document );
			m_listeDerniersDocuments.Remove ( histo );
			m_listeDerniersDocuments.Insert(0, histo );
			while ( m_listeDerniersDocuments.Count > 20 )
				m_listeDerniersDocuments.RemoveAt ( m_listeDerniersDocuments.Count-1 );
		}

		public static CHistoriqueDocumentGencod[] GetHistoriqueDocuments()
		{
			return (CHistoriqueDocumentGencod[]) m_listeDerniersDocuments.ToArray(typeof(CHistoriqueDocumentGencod) );
		}


	}
}

