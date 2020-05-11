using System;
using System.Collections;
using System.Collections.Generic;
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
using System.Text;

namespace timos.commandes
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CLivraisonEquipement))]
	public class CFormEditionLivraisonEquipement : CFormEditionStdTimos, IFormNavigable
	{
        private CLotValorisation m_lotEdite = null;

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private C2iDateTimePicker m_dtLivraison;
        private Label label3;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageLignes;
        private CControleEditeLignesDeLivraisonEquipement m_controlLignes;
        private Crownwood.Magic.Controls.TabPage m_pageChamps;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private Label label4;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_selectTypeLivraisonEquipement;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectCommande;
        private Crownwood.Magic.Controls.TabPage m_pageValorisations;
        private LinkLabel m_lnkAssocierLotValorisation;
        private ContextMenuStrip m_menuValorisation;
        private ToolStripMenuItem m_menuNouveauLot;
        private ToolStripMenuItem m_menuAutreLot;
        private Label label5;
        private CControleEditeLotValorisation m_editeurLot;
        private C2iTabControl m_tabPages;
        private ListView m_wndListeValorisations;
        private ColumnHeader columnHeader1;
        private Panel panel1;
        private Panel panel2;
        private LinkLabel m_lnkAjouterValoFromLivraison;
        private LinkLabel m_lnkAjouterValoFromCommande;
        private Panel panel3;
        private CWndLinkStd m_lnkDeleteValorisation;
        private PictureBox m_btnValoGoDown;
        private PictureBox m_btnValoUp;
        private C2iPanel m_panelDetailValorisation;
        private C2iPanel m_panelEstimation;
        private Label m_lblEstimation;
        private Label label6;
        private PictureBox m_btnRecalculValorisation;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionLivraisonEquipement()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionLivraisonEquipement(CLivraisonEquipement LivraisonEquipement)
			:base(LivraisonEquipement)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionLivraisonEquipement(CLivraisonEquipement LivraisonEquipement, CListeObjetsDonnees liste)
			:base(LivraisonEquipement, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionLivraisonEquipement));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_selectCommande = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtLivraison = new sc2i.win32.common.C2iDateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_selectTypeLivraisonEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageLignes = new Crownwood.Magic.Controls.TabPage();
            this.m_controlLignes = new timos.commandes.CControleEditeLignesDeLivraisonEquipement();
            this.m_pageValorisations = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDetailValorisation = new sc2i.win32.common.C2iPanel(this.components);
            this.m_editeurLot = new timos.commandes.CControleEditeLotValorisation();
            this.m_tabPages = new sc2i.win32.common.C2iTabControl(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkAjouterValoFromCommande = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkAjouterValoFromLivraison = new System.Windows.Forms.LinkLabel();
            this.m_panelEstimation = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnRecalculValorisation = new System.Windows.Forms.PictureBox();
            this.m_lblEstimation = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnValoGoDown = new System.Windows.Forms.PictureBox();
            this.m_btnValoUp = new System.Windows.Forms.PictureBox();
            this.m_lnkDeleteValorisation = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAssocierLotValorisation = new System.Windows.Forms.LinkLabel();
            this.m_wndListeValorisations = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.m_pageChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_menuValorisation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuNouveauLot = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAutreLot = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageLignes.SuspendLayout();
            this.m_pageValorisations.SuspendLayout();
            this.m_panelDetailValorisation.SuspendLayout();
            this.m_editeurLot.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_panelEstimation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnRecalculValorisation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValoGoDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValoUp)).BeginInit();
            this.m_pageChamps.SuspendLayout();
            this.m_menuValorisation.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Delivrey n°|20417";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "NumeroDeLivraisonEquipement");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[NumeroDeLivraisonEquipement]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_selectCommande);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_dtLivraison);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.m_selectTypeLivraisonEquipement);
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
            // m_selectCommande
            // 
            this.m_selectCommande.ElementSelectionne = null;
            this.m_selectCommande.FonctionTextNull = null;
            this.m_selectCommande.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectCommande, "");
            this.m_selectCommande.Location = new System.Drawing.Point(132, 58);
            this.m_selectCommande.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectCommande, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectCommande, "");
            this.m_selectCommande.Name = "m_selectCommande";
            this.m_selectCommande.SelectedObject = null;
            this.m_selectCommande.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_selectCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectCommande.TabIndex = 4003;
            this.m_selectCommande.TextNull = "";
            this.m_selectCommande.OnSelectedObjectChanged += new System.EventHandler(this.m_selectCommande_OnSelectedObjectChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(428, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Delivrey date|20418";
            // 
            // m_dtLivraison
            // 
            this.m_dtLivraison.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtLivraison, "DateLivraisonEquipement");
            this.m_dtLivraison.Location = new System.Drawing.Point(552, 7);
            this.m_dtLivraison.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtLivraison, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtLivraison, "");
            this.m_dtLivraison.Name = "m_dtLivraison";
            this.m_dtLivraison.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtLivraison.TabIndex = 1;
            this.m_dtLivraison.Value = new System.DateTime(2011, 9, 15, 18, 41, 39, 755);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "Order|20420";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(16, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Delivery type|20419";
            // 
            // m_selectTypeLivraisonEquipement
            // 
            this.m_selectTypeLivraisonEquipement.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_selectTypeLivraisonEquipement, "");
            this.m_selectTypeLivraisonEquipement.Location = new System.Drawing.Point(132, 32);
            this.m_selectTypeLivraisonEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeLivraisonEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeLivraisonEquipement, "");
            this.m_selectTypeLivraisonEquipement.Name = "m_selectTypeLivraisonEquipement";
            this.m_selectTypeLivraisonEquipement.SelectedObject = null;
            this.m_selectTypeLivraisonEquipement.SelectionLength = 0;
            this.m_selectTypeLivraisonEquipement.SelectionStart = 0;
            this.m_selectTypeLivraisonEquipement.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeLivraisonEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeLivraisonEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeLivraisonEquipement.TabIndex = 2;
            this.m_selectTypeLivraisonEquipement.OnSelectedObjectChanged += new System.EventHandler(this.m_selectTypeLivraisonEquipement_OnSelectedObjectChanged);
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
            this.m_tabControl.SelectedTab = this.m_pageValorisations;
            this.m_tabControl.Size = new System.Drawing.Size(822, 383);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageLignes,
            this.m_pageValorisations,
            this.m_pageChamps});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_pageLignes
            // 
            this.m_pageLignes.Controls.Add(this.m_controlLignes);
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
            this.m_extLinkField.SetLinkField(this.m_controlLignes, "");
            this.m_controlLignes.Location = new System.Drawing.Point(0, 0);
            this.m_controlLignes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlLignes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlLignes, "");
            this.m_controlLignes.Name = "m_controlLignes";
            this.m_controlLignes.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_controlLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlLignes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlLignes.TabIndex = 0;
            // 
            // m_pageValorisations
            // 
            this.m_pageValorisations.Controls.Add(this.m_panelDetailValorisation);
            this.m_pageValorisations.Controls.Add(this.m_panelEstimation);
            this.m_pageValorisations.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageValorisations, "");
            this.m_pageValorisations.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageValorisations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageValorisations, "");
            this.m_pageValorisations.Name = "m_pageValorisations";
            this.m_pageValorisations.Size = new System.Drawing.Size(806, 342);
            this.m_extStyle.SetStyleBackColor(this.m_pageValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageValorisations.TabIndex = 12;
            this.m_pageValorisations.Title = "Valuations|20428";
            // 
            // m_panelDetailValorisation
            // 
            this.m_panelDetailValorisation.Controls.Add(this.m_editeurLot);
            this.m_panelDetailValorisation.Controls.Add(this.panel2);
            this.m_panelDetailValorisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDetailValorisation, "");
            this.m_panelDetailValorisation.Location = new System.Drawing.Point(224, 22);
            this.m_panelDetailValorisation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDetailValorisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDetailValorisation, "");
            this.m_panelDetailValorisation.Name = "m_panelDetailValorisation";
            this.m_panelDetailValorisation.Size = new System.Drawing.Size(582, 320);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDetailValorisation.TabIndex = 4011;
            // 
            // m_editeurLot
            // 
            this.m_editeurLot.BackColor = System.Drawing.Color.White;
            this.m_editeurLot.Controls.Add(this.m_tabPages);
            this.m_editeurLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeurLot.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_editeurLot, "");
            this.m_editeurLot.Location = new System.Drawing.Point(0, 19);
            this.m_editeurLot.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurLot, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editeurLot, "");
            this.m_editeurLot.Name = "m_editeurLot";
            this.m_editeurLot.Size = new System.Drawing.Size(582, 301);
            this.m_extStyle.SetStyleBackColor(this.m_editeurLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurLot.TabIndex = 4005;
            // 
            // m_tabPages
            // 
            this.m_tabPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabPages.BoldSelectedPage = true;
            this.m_tabPages.ControlBottomOffset = 16;
            this.m_tabPages.ControlRightOffset = 16;
            this.m_tabPages.ForeColor = System.Drawing.Color.Black;
            this.m_tabPages.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabPages, "");
            this.m_tabPages.Location = new System.Drawing.Point(3, 75);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPages, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPages, "");
            this.m_tabPages.Name = "m_tabPages";
            this.m_tabPages.Ombre = true;
            this.m_tabPages.PositionTop = true;
            this.m_tabPages.Size = new System.Drawing.Size(698, 238);
            this.m_extStyle.SetStyleBackColor(this.m_tabPages, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabPages, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabPages.TabIndex = 4005;
            this.m_tabPages.TextColor = System.Drawing.Color.Black;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkAjouterValoFromCommande);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.m_lnkAjouterValoFromLivraison);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 19);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4008;
            // 
            // m_lnkAjouterValoFromCommande
            // 
            this.m_lnkAjouterValoFromCommande.AutoSize = true;
            this.m_lnkAjouterValoFromCommande.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterValoFromCommande, "");
            this.m_lnkAjouterValoFromCommande.Location = new System.Drawing.Point(188, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterValoFromCommande, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterValoFromCommande, "");
            this.m_lnkAjouterValoFromCommande.Name = "m_lnkAjouterValoFromCommande";
            this.m_lnkAjouterValoFromCommande.Size = new System.Drawing.Size(147, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterValoFromCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterValoFromCommande, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterValoFromCommande.TabIndex = 2;
            this.m_lnkAjouterValoFromCommande.TabStop = true;
            this.m_lnkAjouterValoFromCommande.Text = "Add order equipments|20459";
            this.m_lnkAjouterValoFromCommande.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterValoFromCommande_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(159, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(29, 19);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 1;
            // 
            // m_lnkAjouterValoFromLivraison
            // 
            this.m_lnkAjouterValoFromLivraison.AutoSize = true;
            this.m_lnkAjouterValoFromLivraison.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterValoFromLivraison, "");
            this.m_lnkAjouterValoFromLivraison.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterValoFromLivraison, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterValoFromLivraison, "");
            this.m_lnkAjouterValoFromLivraison.Name = "m_lnkAjouterValoFromLivraison";
            this.m_lnkAjouterValoFromLivraison.Size = new System.Drawing.Size(159, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterValoFromLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterValoFromLivraison, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterValoFromLivraison.TabIndex = 0;
            this.m_lnkAjouterValoFromLivraison.TabStop = true;
            this.m_lnkAjouterValoFromLivraison.Text = "Add delivery equipments|20458";
            this.m_lnkAjouterValoFromLivraison.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjouterValoFromLivraison_LinkClicked);
            // 
            // m_panelEstimation
            // 
            this.m_panelEstimation.Controls.Add(this.m_btnRecalculValorisation);
            this.m_panelEstimation.Controls.Add(this.m_lblEstimation);
            this.m_panelEstimation.Controls.Add(this.label6);
            this.m_panelEstimation.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelEstimation, "");
            this.m_panelEstimation.Location = new System.Drawing.Point(224, 0);
            this.m_panelEstimation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEstimation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEstimation, "");
            this.m_panelEstimation.Name = "m_panelEstimation";
            this.m_panelEstimation.Size = new System.Drawing.Size(582, 22);
            this.m_extStyle.SetStyleBackColor(this.m_panelEstimation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEstimation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEstimation.TabIndex = 4005;
            // 
            // m_btnRecalculValorisation
            // 
            this.m_btnRecalculValorisation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnRecalculValorisation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnRecalculValorisation.Image = global::timos.Properties.Resources.Reload;
            this.m_extLinkField.SetLinkField(this.m_btnRecalculValorisation, "");
            this.m_btnRecalculValorisation.Location = new System.Drawing.Point(227, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRecalculValorisation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRecalculValorisation, "");
            this.m_btnRecalculValorisation.Name = "m_btnRecalculValorisation";
            this.m_btnRecalculValorisation.Size = new System.Drawing.Size(24, 22);
            this.m_btnRecalculValorisation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_extStyle.SetStyleBackColor(this.m_btnRecalculValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRecalculValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRecalculValorisation.TabIndex = 4003;
            this.m_btnRecalculValorisation.TabStop = false;
            this.m_btnRecalculValorisation.Click += new System.EventHandler(this.m_btnRecalculValorisation_Click);
            // 
            // m_lblEstimation
            // 
            this.m_lblEstimation.BackColor = System.Drawing.Color.White;
            this.m_lblEstimation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblEstimation.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lblEstimation, "");
            this.m_lblEstimation.Location = new System.Drawing.Point(127, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEstimation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEstimation, "");
            this.m_lblEstimation.Name = "m_lblEstimation";
            this.m_lblEstimation.Size = new System.Drawing.Size(100, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblEstimation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEstimation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEstimation.TabIndex = 0;
            this.m_lblEstimation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4002;
            this.label6.Text = "Delivery valuation|20460";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnValoGoDown);
            this.panel1.Controls.Add(this.m_btnValoUp);
            this.panel1.Controls.Add(this.m_lnkDeleteValorisation);
            this.panel1.Controls.Add(this.m_lnkAssocierLotValorisation);
            this.panel1.Controls.Add(this.m_wndListeValorisations);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 342);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4007;
            // 
            // m_btnValoGoDown
            // 
            this.m_btnValoGoDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnValoGoDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValoGoDown.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValoGoDown.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnValoGoDown, "");
            this.m_btnValoGoDown.Location = new System.Drawing.Point(202, 316);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValoGoDown, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnValoGoDown, "");
            this.m_btnValoGoDown.Name = "m_btnValoGoDown";
            this.m_btnValoGoDown.Size = new System.Drawing.Size(15, 15);
            this.m_btnValoGoDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnValoGoDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValoGoDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValoGoDown.TabIndex = 4010;
            this.m_btnValoGoDown.TabStop = false;
            this.m_btnValoGoDown.Click += new System.EventHandler(this.m_btnValoGoDown_Click);
            // 
            // m_btnValoUp
            // 
            this.m_btnValoUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnValoUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnValoUp.Image = ((System.Drawing.Image)(resources.GetObject("m_btnValoUp.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnValoUp, "");
            this.m_btnValoUp.Location = new System.Drawing.Point(181, 316);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValoUp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnValoUp, "");
            this.m_btnValoUp.Name = "m_btnValoUp";
            this.m_btnValoUp.Size = new System.Drawing.Size(15, 15);
            this.m_btnValoUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnValoUp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValoUp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValoUp.TabIndex = 4009;
            this.m_btnValoUp.TabStop = false;
            this.m_btnValoUp.Click += new System.EventHandler(this.m_btnValoUp_Click);
            // 
            // m_lnkDeleteValorisation
            // 
            this.m_lnkDeleteValorisation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDeleteValorisation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDeleteValorisation.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDeleteValorisation, "");
            this.m_lnkDeleteValorisation.Location = new System.Drawing.Point(9, 317);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteValorisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeleteValorisation, "");
            this.m_lnkDeleteValorisation.Name = "m_lnkDeleteValorisation";
            this.m_lnkDeleteValorisation.Size = new System.Drawing.Size(117, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeleteValorisation.TabIndex = 4007;
            this.m_lnkDeleteValorisation.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDeleteValorisation.LinkClicked += new System.EventHandler(this.m_lnkDeleteValorisation_LinkClicked);
            // 
            // m_lnkAssocierLotValorisation
            // 
            this.m_lnkAssocierLotValorisation.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkAssocierLotValorisation, "");
            this.m_lnkAssocierLotValorisation.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAssocierLotValorisation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAssocierLotValorisation, "");
            this.m_lnkAssocierLotValorisation.Name = "m_lnkAssocierLotValorisation";
            this.m_lnkAssocierLotValorisation.Size = new System.Drawing.Size(160, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAssocierLotValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAssocierLotValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAssocierLotValorisation.TabIndex = 0;
            this.m_lnkAssocierLotValorisation.TabStop = true;
            this.m_lnkAssocierLotValorisation.Text = "Associate valorisation lot|20453";
            this.m_lnkAssocierLotValorisation.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAssocierLotValorisation_LinkClicked);
            // 
            // m_wndListeValorisations
            // 
            this.m_wndListeValorisations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeValorisations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeValorisations.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeValorisations.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeValorisations, "");
            this.m_wndListeValorisations.Location = new System.Drawing.Point(9, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeValorisations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeValorisations, "");
            this.m_wndListeValorisations.Name = "m_wndListeValorisations";
            this.m_wndListeValorisations.Size = new System.Drawing.Size(209, 278);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeValorisations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeValorisations.TabIndex = 4006;
            this.m_wndListeValorisations.UseCompatibleStateImageBehavior = false;
            this.m_wndListeValorisations.View = System.Windows.Forms.View.Details;
            this.m_wndListeValorisations.SelectedIndexChanged += new System.EventHandler(this.m_wndListeValorisations_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 196;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(3, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Linked valuations|20457";
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
            // m_menuValorisation
            // 
            this.m_menuValorisation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuNouveauLot,
            this.m_menuAutreLot});
            this.m_extLinkField.SetLinkField(this.m_menuValorisation, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuValorisation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuValorisation, "");
            this.m_menuValorisation.Name = "m_menuValorisation";
            this.m_menuValorisation.Size = new System.Drawing.Size(258, 48);
            this.m_extStyle.SetStyleBackColor(this.m_menuValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuValorisation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_menuValorisation.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuValorisation_Opening);
            // 
            // m_menuNouveauLot
            // 
            this.m_menuNouveauLot.Name = "m_menuNouveauLot";
            this.m_menuNouveauLot.Size = new System.Drawing.Size(257, 22);
            this.m_menuNouveauLot.Text = "Create a new valorisation lot|20454";
            this.m_menuNouveauLot.Click += new System.EventHandler(this.m_menuNouveauLot_Click);
            // 
            // m_menuAutreLot
            // 
            this.m_menuAutreLot.Name = "m_menuAutreLot";
            this.m_menuAutreLot.Size = new System.Drawing.Size(257, 22);
            this.m_menuAutreLot.Text = "Other lot|20455";
            this.m_menuAutreLot.Click += new System.EventHandler(this.m_menuAutreLot_Click);
            // 
            // CFormEditionLivraisonEquipement
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionLivraisonEquipement";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLivraisonEquipement_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionLivraisonEquipement_OnMajChampsPage);
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
            this.m_pageValorisations.ResumeLayout(false);
            this.m_panelDetailValorisation.ResumeLayout(false);
            this.m_editeurLot.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.m_panelEstimation.ResumeLayout(false);
            this.m_panelEstimation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnRecalculValorisation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValoGoDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnValoUp)).EndInit();
            this.m_pageChamps.ResumeLayout(false);
            this.m_menuValorisation.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CLivraisonEquipement LivraisonEquipement
		{
			get
			{
				return (CLivraisonEquipement)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Delivery|20415"));

            m_lotEdite = null;
            m_panelDetailValorisation.Visible = false;

            m_selectCommande.Init<CCommande>(
                "Libelle",
                false);
            m_selectCommande.ElementSelectionne = LivraisonEquipement.Commande;
            m_selectTypeLivraisonEquipement.Init(typeof(CTypeLivraisonEquipement),
                "Libelle",
                false);
            m_selectTypeLivraisonEquipement.ElementSelectionne = LivraisonEquipement.TypeLivraisonEquipement;

            m_selectCommande.LockEdition = LivraisonEquipement.Lignes.Count != 0 || !m_gestionnaireModeEdition.ModeEdition;

			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            LivraisonEquipement.Commande = m_selectCommande.ElementSelectionne as CCommande;
            LivraisonEquipement.TypeLivraisonEquipement = m_selectTypeLivraisonEquipement.ElementSelectionne as CTypeLivraisonEquipement;
            

            return result;
        }


        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionLivraisonEquipement_OnMajChampsPage(object page)
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
            if (page == m_pageValorisations)
            {
                result = ValideLotEnCours(false);
                if (!result)
                    return result;
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionLivraisonEquipement_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageLignes)
            {
                m_controlLignes.Init(LivraisonEquipement);
            }
            if (page == m_pageChamps)
            {
                m_panelChamps.ElementEdite = LivraisonEquipement;
            }
            if (page == m_pageValorisations)
            {
                FillListeLots();
                m_lblEstimation.Text = "";
            }
            return result;
        }

        public void m_selectCommande_OnSelectedObjectChanged(object sender, EventArgs args)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                CCommande commande = m_selectCommande.ElementSelectionne as CCommande;
                if (commande != null && commande != LivraisonEquipement.Commande)
                {
                    if (!m_controlLignes.MajChamps() || LivraisonEquipement.Lignes.Count > 0)
                    {
                        m_selectCommande.ElementSelectionne = LivraisonEquipement.Commande;
                        CFormAlerte.Afficher(I.T("You can not change associated order while existing delivrey lines exists|20416"));
                        return;
                    }
                    LivraisonEquipement.Commande = commande;
                    m_controlLignes.Init(LivraisonEquipement);
                }
            }
        }

        private void m_selectTypeLivraisonEquipement_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                CTypeLivraisonEquipement type = m_selectTypeLivraisonEquipement.ElementSelectionne as CTypeLivraisonEquipement;
                if (type != null)
                {
                    LivraisonEquipement.TypeLivraisonEquipement = type;
                    m_panelChamps.ElementEdite = LivraisonEquipement;
                }
            }
        }

        //-------------------------------------------------------
        private class CMenuLotValorisation : ToolStripMenuItem
        {
            public CLotValorisation Lot;
            public CMenuLotValorisation(CLotValorisation lot)
                : base(lot.Libelle)
            {
                Lot = lot;
            }
        }

        //-------------------------------------------------------
        private void m_menuValorisation_Opening(object sender, CancelEventArgs e)
        {
            ArrayList lst = new ArrayList ( m_menuValorisation.Items );
            foreach (ToolStripItem item in lst)
            {
                if (item is CMenuLotValorisation)
                {
                    m_menuValorisation.Items.Remove(item);
                    item.Dispose();
                }
            }
            HashSet<int> valorisationsDejaAssociees = new HashSet<int>();
            foreach ( CLivraisonLotValorisation rel in LivraisonEquipement.RelationsLotsValorisation )
            {
                if ( rel.LotDeValorisation != null )
                    valorisationsDejaAssociees.Add ( rel.LotDeValorisation.Id );
            }
            //Trouve les valorisation liées
            List<CLotValorisation> lstValos = new List<CLotValorisation>();
            if (LivraisonEquipement.Commande != null)
            {
                foreach (CLivraisonEquipement liv in LivraisonEquipement.Commande.Livraisons)
                {
                    foreach (CLivraisonLotValorisation rel in liv.RelationsLotsValorisation)
                    {
                        if (rel.LotDeValorisation != null)
                            if (!valorisationsDejaAssociees.Contains(rel.LotDeValorisation.Id))
                            {
                                lstValos.Add(rel.LotDeValorisation);
                                valorisationsDejaAssociees.Add ( rel.LotDeValorisation.Id );
                            }
                    }
                }
            }
            foreach (CLotValorisation lot in lstValos)
            {
                CMenuLotValorisation menu = new CMenuLotValorisation(lot);
                m_menuValorisation.Items.Insert(0, menu);
                menu.Click += new EventHandler(associerValorisation_click);
            }
                
        }

        //-------------------------------------------------------
        private void  associerValorisation_click(object sender, EventArgs e)
        {
            CMenuLotValorisation item = sender as CMenuLotValorisation;
            if (item != null)
            {
                CLotValorisation lot = item.Lot;
                CLivraisonLotValorisation livLot = new CLivraisonLotValorisation(LivraisonEquipement.ContexteDonnee);
                livLot.CreateNewInCurrentContexte();
                livLot.Numero = LivraisonEquipement.RelationsLotsValorisation.Count;
                livLot.LotDeValorisation = lot;
                livLot.Livraison = LivraisonEquipement;
                FillListeLots();
                SelectLot(lot);                
            }
        }

        //-------------------------------------------------------
        private void m_menuNouveauLot_Click(object sender, EventArgs e)
        {
            if ( !ValideLotEnCours(true) )
                return;
            CLotValorisation lot = new CLotValorisation(LivraisonEquipement.ContexteDonnee);
            lot.CreateNewInCurrentContexte();
            lot.Libelle = I.T("Valuation of delivery @1 of @2|20456", m_txtLibelle.Text, m_dtLivraison.Value.ToShortDateString());
            lot.DateLot = m_dtLivraison.Value;

            CLivraisonLotValorisation livLot = new CLivraisonLotValorisation(LivraisonEquipement.ContexteDonnee);
            livLot.CreateNewInCurrentContexte();
            livLot.LotDeValorisation = lot;
            livLot.Numero = LivraisonEquipement.RelationsLotsValorisation.Count;
            livLot.Livraison = LivraisonEquipement;
            lot.AjouterEquipementsDepuisLivraisonInCurrentContext(LivraisonEquipement);
            FillListeLots();
            SelectLot(lot);
        }

        //-------------------------------------------------------
        private void m_menuAutreLot_Click(object sender, EventArgs e)
        {
            if ( !ValideLotEnCours(true) )
                return;
            CFormListeLotValorisations form = new CFormListeLotValorisations();
            //Exlue les lots déjà associés
            StringBuilder bl = new StringBuilder();
            foreach ( CLivraisonLotValorisation livLot in LivraisonEquipement.RelationsLotsValorisation)
            {
                if ( livLot.Livraison != null )
                {
                    bl.Append ( livLot.Livraison.Id );
                    bl.Append(',');
                }
            }
            if ( bl.Length > 0 )
            {
                bl.Remove ( bl.Length-1, 1 );
                form.FiltreDeBase = new CFiltreData ( CLotValorisation.c_champId+" not in ("+
                    bl.ToString()+")");
            }
            
            CLotValorisation lot = CFormNavigateurPopupListe.SelectObject(form, null, "") as CLotValorisation;
            form.Dispose();
            if (lot != null)
            {
                CLivraisonLotValorisation livLot = new CLivraisonLotValorisation(LivraisonEquipement.ContexteDonnee);
                livLot.CreateNewInCurrentContexte();
                livLot.Livraison = LivraisonEquipement;
                livLot.Numero = LivraisonEquipement.RelationsLotsValorisation.Count;
                livLot.LotDeValorisation = lot;
                FillListeLots();
                SelectLot(lot);
            }
        }

        //-------------------------------------------------------
        private void m_lnkAssocierLotValorisation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_menuValorisation.Show ( m_lnkAssocierLotValorisation, new Point ( 0, m_lnkAssocierLotValorisation.Height ));
        }

        //-------------------------------------------------------
        private void FillListeLots()
        {
            CLotValorisation lot = m_lotEdite;

            m_wndListeValorisations.SuspendDrawing();
            m_wndListeValorisations.Items.Clear();
            if ( !ValideLotEnCours(true) )
                return;
            m_lotEdite = null;
            m_panelDetailValorisation.Visible = false;
            foreach (CLivraisonLotValorisation rel in LivraisonEquipement.RelationsLotsValorisation)
            {
                ListViewItem item = new ListViewItem(rel.LotDeValorisation.Libelle);
                item.Tag = rel.LotDeValorisation;
                m_wndListeValorisations.Items.Add(item);
            }
            m_wndListeValorisations.ResumeDrawing();
            SelectLot(lot);
        }

        //-------------------------------------------------------
        private void SelectLot(CLotValorisation lot)
        {
            ListViewItem item = GetItemLot(lot);
            if (item != null)
                item.Selected = true;
        }

        //-------------------------------------------------------
        public CResultAErreur ValideLotEnCours(bool bAvecAffichageErreur)
        {
            CResultAErreur result = CResultAErreur.True;
            if (m_lotEdite == null || !m_lotEdite.IsValide())
                return result;
            result = m_editeurLot.MajChamps();
            if (!result && bAvecAffichageErreur)
            {
                CFormAlerte.Afficher(result.Erreur);
                return result;
            }
            m_lotEdite.VerifieDonnees(true);
            ListViewItem item = GetItemLot(m_lotEdite);
            if (item != null)
                item.Text = m_lotEdite.Libelle;

            return result;
        }

        //----------------------------------------------------------------------------------------
        private ListViewItem GetItemLot ( CLotValorisation lot )
        {
            foreach ( ListViewItem item in m_wndListeValorisations.Items )
            {
                if ( item.Tag.Equals( lot ) )
                    return item;
            }
            return null;
        }

        //----------------------------------------------------------------------------------------
        private void m_wndListeValorisations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ValideLotEnCours(true))
            {
                ListViewItem reselectItem = GetItemLot(m_lotEdite);
                if (reselectItem != null)
                    reselectItem.Selected = true;
                return;
            }
            if (m_wndListeValorisations.SelectedItems.Count == 0)
            {
                m_lotEdite = null;
                m_panelDetailValorisation.Visible = false;
                return;
            }
            ListViewItem item = m_wndListeValorisations.SelectedItems[0];
            if (item.Tag == m_lotEdite)
                return;

            m_lotEdite = item.Tag as CLotValorisation;
            m_editeurLot.InitChamps(m_lotEdite);
            m_panelDetailValorisation.Visible = true;
        }

        private void m_lnkAjouterValoFromLivraison_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ( !ValideLotEnCours(true) )
                return;
            CLotValorisation lot = m_lotEdite;
            if (m_lotEdite != null && m_gestionnaireModeEdition.ModeEdition)
            {
                m_lotEdite.AjouterEquipementsDepuisLivraisonInCurrentContext(LivraisonEquipement);
                FillListeLots();
                SelectLot(lot);
            }
        }

        private void m_lnkAjouterValoFromCommande_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ValideLotEnCours(true))
                return;
            CLotValorisation lot = m_lotEdite;
            if (m_lotEdite != null && LivraisonEquipement.Commande != null && m_gestionnaireModeEdition.ModeEdition)
            {
                m_lotEdite.AjouterEquipementsDepuisCommandeInCurrentContext(LivraisonEquipement.Commande);
                FillListeLots();
                SelectLot(lot);
            }
        }

        //----------------------------------------------------------
        private void m_btnValoUp_Click(object sender, EventArgs e)
        {
            if (m_wndListeValorisations.SelectedItems.Count != 1)
                return;
            ListViewItem item = m_wndListeValorisations.SelectedItems[0];
            int nIndex = m_wndListeValorisations.SelectedIndices[0];
            if (nIndex > 0)
            {
                m_wndListeValorisations.Items.RemoveAt(nIndex);
                m_wndListeValorisations.Items.Insert(nIndex - 1, item);
                RenumerotteValorisations();
                item.Selected = true;
            }
        }

        //----------------------------------------------------------
        private void RenumerotteValorisations()
        {
            int nIndex = 0;
            foreach (ListViewItem item in m_wndListeValorisations.Items)
            {
                CLotValorisation lot = item.Tag as CLotValorisation;
                foreach (CLivraisonLotValorisation livLot in LivraisonEquipement.RelationsLotsValorisation)
                {
                    if (livLot.LotDeValorisation == lot)
                    {
                        livLot.Numero = nIndex++;
                        break;
                    }
                }
            }
        }

        private void m_btnValoGoDown_Click(object sender, EventArgs e)
        {
            if (m_wndListeValorisations.SelectedItems.Count != 1)
                return;
            ListViewItem item = m_wndListeValorisations.SelectedItems[0];
            int nIndex = m_wndListeValorisations.SelectedIndices[0];
            if (nIndex < m_wndListeValorisations.Items.Count - 1)
            {
                m_wndListeValorisations.Items.RemoveAt(nIndex);
                if (nIndex + 1 < m_wndListeValorisations.Items.Count)
                    m_wndListeValorisations.Items.Insert(nIndex + 1, item);
                else
                    m_wndListeValorisations.Items.Add(item);
                RenumerotteValorisations();
                item.Selected = true;
            }
        }

        private void m_btnRecalculValorisation_Click(object sender, EventArgs e)
        {
            ValideLotEnCours(false);
            LivraisonEquipement.AppliqueValorisation();
            double fValeur = 0;
            foreach (CLigneLivraisonEquipement ligne in LivraisonEquipement.Lignes)
            {
                if (ligne.IsValide() && ligne.Equipement != null && ligne.Equipement.ValorisationEquipement != null)
                    fValeur += ligne.Equipement.ValorisationEquipement.Valeur;
            }
            m_lblEstimation.Text = fValeur.ToString();
        }

        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void m_lnkDeleteValorisation_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeValorisations.SelectedItems.Count != 1)
                return;
            ListViewItem item = m_wndListeValorisations.SelectedItems[0];
            CLotValorisation lot = item.Tag as CLotValorisation;
            foreach (CLivraisonLotValorisation livLot in LivraisonEquipement.RelationsLotsValorisation)
            {
                if (livLot.LotDeValorisation == lot)
                {
                    CResultAErreur result = livLot.Delete(true);
                    if (!result)
                    {
                        CFormAlerte.Afficher(result.Erreur);
                        return;
                    }
                    FillListeLots();
                    return;
                }
            }

        }



        

       
        
	}
}

