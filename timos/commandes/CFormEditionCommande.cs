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
using timos.data.commandes;
using timos.data;

namespace timos.commandes
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CCommande))]
	public class CFormEditionCommande : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private C2iDateTimePicker c2iDateTimePicker1;
        private Label label3;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageLignes;
        private CControleEditeLignesDeCommandeNew m_controlLignes;
        private Crownwood.Magic.Controls.TabPage m_pageChamps;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private Label label4;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeCommande;
        private C2iPanel c2iPanel1;
        private CheckBox m_chkFiltreFournisseur;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectFournisseur;
        private Crownwood.Magic.Controls.TabPage m_pageLivraisons;
        private CPanelListeSpeedStandard m_wndListeLivraisons;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionCommande()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCommande(CCommande Commande)
			:base(Commande)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionCommande(CCommande Commande, CListeObjetsDonnees liste)
			:base(Commande, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionCommande));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_selectFournisseur = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iDateTimePicker1 = new sc2i.win32.common.C2iDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_selectTypeCommande = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageLignes = new Crownwood.Magic.Controls.TabPage();
            this.m_controlLignes = new timos.commandes.CControleEditeLignesDeCommandeNew();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_chkFiltreFournisseur = new System.Windows.Forms.CheckBox();
            this.m_pageChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageLivraisons = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeLivraisons = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageLignes.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            this.m_pageChamps.SuspendLayout();
            this.m_pageLivraisons.SuspendLayout();
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
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Order n°|20393";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "NumeroDeCommande");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[NumeroDeCommande]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_selectFournisseur);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.c2iDateTimePicker1);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.m_selectTypeCommande);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(733, 100);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_selectFournisseur
            // 
            this.m_selectFournisseur.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_selectFournisseur, "");
            this.m_selectFournisseur.Location = new System.Drawing.Point(132, 58);
            this.m_selectFournisseur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectFournisseur, "");
            this.m_selectFournisseur.Name = "m_selectFournisseur";
            this.m_selectFournisseur.SelectedObject = null;
            this.m_selectFournisseur.SelectionLength = 0;
            this.m_selectFournisseur.SelectionStart = 0;
            this.m_selectFournisseur.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_selectFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectFournisseur.TabIndex = 4003;
            this.m_selectFournisseur.OnSelectedObjectChanged += new System.EventHandler(this.m_selectFournisseur_OnSelectedObjectChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(428, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Order date|20394";
            // 
            // c2iDateTimePicker1
            // 
            this.c2iDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.c2iDateTimePicker1, "DateCommande");
            this.c2iDateTimePicker1.Location = new System.Drawing.Point(552, 7);
            this.c2iDateTimePicker1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iDateTimePicker1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iDateTimePicker1, "");
            this.c2iDateTimePicker1.Name = "c2iDateTimePicker1";
            this.c2iDateTimePicker1.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iDateTimePicker1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iDateTimePicker1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iDateTimePicker1.TabIndex = 1;
            this.c2iDateTimePicker1.Value = new System.DateTime(2011, 9, 15, 18, 41, 39, 755);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "Supplier|20395";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Order type";
            // 
            // m_selectTypeCommande
            // 
            this.m_selectTypeCommande.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_selectTypeCommande, "");
            this.m_selectTypeCommande.Location = new System.Drawing.Point(132, 32);
            this.m_selectTypeCommande.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeCommande, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeCommande, "");
            this.m_selectTypeCommande.Name = "m_selectTypeCommande";
            this.m_selectTypeCommande.SelectedObject = null;
            this.m_selectTypeCommande.SelectionLength = 0;
            this.m_selectTypeCommande.SelectionStart = 0;
            this.m_selectTypeCommande.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeCommande.TabIndex = 2;
            this.m_selectTypeCommande.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypeCommande_OnSelectedObjectChanged);
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageLivraisons;
            this.m_tabControl.Size = new System.Drawing.Size(822, 383);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageLignes,
            this.m_pageLivraisons,
            this.m_pageChamps});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageLignes
            // 
            this.m_pageLignes.Controls.Add(this.m_controlLignes);
            this.m_pageLignes.Controls.Add(this.c2iPanel1);
            this.m_extLinkField.SetLinkField(this.m_pageLignes, "");
            this.m_pageLignes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLignes, "");
            this.m_pageLignes.Name = "m_pageLignes";
            this.m_pageLignes.Selected = false;
            this.m_pageLignes.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_pageLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLignes.TabIndex = 10;
            this.m_pageLignes.Title = "Detail|20403";
            // 
            // m_controlLignes
            // 
            this.m_controlLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controlLignes.FournisseurPourFiltre = null;
            this.m_extLinkField.SetLinkField(this.m_controlLignes, "");
            this.m_controlLignes.Location = new System.Drawing.Point(0, 27);
            this.m_controlLignes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlLignes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlLignes, "");
            this.m_controlLignes.Name = "m_controlLignes";
            this.m_controlLignes.Size = new System.Drawing.Size(806, 315);
            this.m_extStyle.SetStyleBackColor(this.m_controlLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlLignes.TabIndex = 0;
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_chkFiltreFournisseur);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel1, "");
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(806, 27);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 1;
            // 
            // m_chkFiltreFournisseur
            // 
            this.m_chkFiltreFournisseur.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_chkFiltreFournisseur, "");
            this.m_chkFiltreFournisseur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkFiltreFournisseur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkFiltreFournisseur, "");
            this.m_chkFiltreFournisseur.Name = "m_chkFiltreFournisseur";
            this.m_chkFiltreFournisseur.Size = new System.Drawing.Size(347, 27);
            this.m_extStyle.SetStyleBackColor(this.m_chkFiltreFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkFiltreFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFiltreFournisseur.TabIndex = 0;
            this.m_chkFiltreFournisseur.Text = "Show supplier equipments only|20409";
            this.m_chkFiltreFournisseur.UseVisualStyleBackColor = true;
            this.m_chkFiltreFournisseur.CheckedChanged += new System.EventHandler(this.m_chkFiltreFournisseur_CheckedChanged);
            // 
            // m_pageChamps
            // 
            this.m_pageChamps.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageChamps, "");
            this.m_pageChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChamps, "");
            this.m_pageChamps.Name = "m_pageChamps";
            this.m_pageChamps.Selected = false;
            this.m_pageChamps.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChamps.TabIndex = 11;
            this.m_pageChamps.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 3;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageLivraisons
            // 
            this.m_pageLivraisons.Controls.Add(this.m_wndListeLivraisons);
            this.m_extLinkField.SetLinkField(this.m_pageLivraisons, "");
            this.m_pageLivraisons.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLivraisons, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLivraisons, "");
            this.m_pageLivraisons.Name = "m_pageLivraisons";
            this.m_pageLivraisons.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_pageLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLivraisons.TabIndex = 12;
            this.m_pageLivraisons.Title = "Deliveries|20407";
            // 
            // m_wndListeLivraisons
            // 
            this.m_wndListeLivraisons.AllowArbre = true;
            this.m_wndListeLivraisons.AllowCustomisation = true;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Name";
            glColumn1.Propriete = "DateLivraisonEquipement";
            glColumn1.Text = "Delivery date|20418";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "NumeroDeLivraisonEquipement";
            glColumn2.Text = "Delivrery n°|20417";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 200;
            this.m_wndListeLivraisons.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_wndListeLivraisons.ContexteUtilisation = "";
            this.m_wndListeLivraisons.ControlFiltreStandard = null;
            this.m_wndListeLivraisons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeLivraisons.ElementSelectionne = null;
            this.m_wndListeLivraisons.EnableCustomisation = true;
            this.m_wndListeLivraisons.FiltreDeBase = null;
            this.m_wndListeLivraisons.FiltreDeBaseEnAjout = false;
            this.m_wndListeLivraisons.FiltrePrefere = null;
            this.m_wndListeLivraisons.FiltreRapide = null;
            this.m_wndListeLivraisons.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeLivraisons, "");
            this.m_wndListeLivraisons.ListeObjets = null;
            this.m_wndListeLivraisons.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeLivraisons.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeLivraisons, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_wndListeLivraisons.ModeQuickSearch = false;
            this.m_wndListeLivraisons.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_wndListeLivraisons, "");
            this.m_wndListeLivraisons.MultiSelect = false;
            this.m_wndListeLivraisons.Name = "m_wndListeLivraisons";
            this.m_wndListeLivraisons.Navigateur = null;
            this.m_wndListeLivraisons.ProprieteObjetAEditer = null;
            this.m_wndListeLivraisons.QuickSearchText = "";
            this.m_wndListeLivraisons.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeLivraisons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeLivraisons.TabIndex = 0;
            this.m_wndListeLivraisons.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeLivraisons.UseCheckBoxes = false;
            // 
            // CFormEditionCommande
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionCommande";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionCommande_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionCommande_OnMajChampsPage);
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
            this.m_pageLignes.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.m_pageChamps.ResumeLayout(false);
            this.m_pageLivraisons.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CCommande Commande
		{
			get
			{
				return (CCommande)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Order|20390"));

            CFiltreData filtre = null;
            filtre = CFiltreData.GetAndFiltre(filtre,
                new CFiltreDataAvance(CActeur.c_nomTable,
                    "Has (" + CDonneesActeurFournisseur.c_nomTable + "." +
                    CDonneesActeurFournisseur.c_champId + ")"));
            m_selectFournisseur.InitAvecFiltreDeBase(typeof(CActeur),
                "IdentiteComplete",
                filtre,
                false);
            m_selectFournisseur.ElementSelectionne = Commande.Fournisseur==null?null:Commande.Fournisseur.Acteur;
            m_selectTypeCommande.Init(typeof(CTypeCommande),
                "Libelle",
                false);
            m_selectTypeCommande.ElementSelectionne = Commande.TypeCommande;


			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            Commande.Fournisseur = FournisseurSelectionne;
            Commande.TypeCommande = m_selectTypeCommande.ElementSelectionne as CTypeCommande;

            return result;
        }


        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionCommande_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageLignes)
            {
                result = m_controlLignes.MajChamps();
                if (!result)
                    return result;
            }
            if (page == m_pageChamps)
            {
                result = m_panelChamps.MAJ_Champs();
                if (!result)
                    return result;
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionCommande_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageLignes)
            {
                m_controlLignes.Init(Commande);
            }
            if (page == m_pageChamps)
            {
                m_panelChamps.ElementEdite = Commande;
            }
            if (page == m_pageLivraisons)
            {
                m_wndListeLivraisons.InitFromListeObjets(
                    Commande.Livraisons,
                    typeof(CLivraisonEquipement),
                    Commande,
                    "Commande");
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private CDonneesActeurFournisseur FournisseurSelectionne
        {
            get
            {
                CActeur acteur = m_selectFournisseur.ElementSelectionne as CActeur;
                if (acteur != null)
                    return acteur.Fournisseur;
                return null;
            }
        }

        //-------------------------------------------------------------------------
        private void m_chkFiltreFournisseur_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkFiltreFournisseur.Checked)
                m_controlLignes.FournisseurPourFiltre = FournisseurSelectionne;
            else
                m_controlLignes.FournisseurPourFiltre = null;
        }

        private void m_selectFournisseur_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            if (m_chkFiltreFournisseur.Checked)
                m_controlLignes.FournisseurPourFiltre = FournisseurSelectionne;
        }

        private void m_selectTypeCommande_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                CTypeCommande type = m_selectTypeCommande.ElementSelectionne as CTypeCommande;
                if (type != null)
                {
                    Commande.TypeCommande = type;
                    m_panelChamps.ElementEdite = Commande;
                }
            }

        }
	}
}

