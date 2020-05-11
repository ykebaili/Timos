using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Windows.Forms;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.process;

using sc2i.workflow;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeDossierSuivi))]
	public class CFormEditionTypeDossierSuivi : CFormEditionStdTimos, IFormNavigable
	{		
		
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.ListViewAutoFilled m_listViewRelationsComptabilites;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn8;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private System.ComponentModel.IContainer components = null;

		private const string c_champCodeEtat = "CODE_ETAT";
		private Crownwood.Magic.Controls.TabPage m_pageElementsLies;
		private Crownwood.Magic.Controls.TabPage m_pageFormulairesEtChamps;
		private System.Windows.Forms.LinkLabel m_lnkSupprimerLienElement;
		private sc2i.win32.common.C2iComboBox m_cmbTypeElementsAAgenda;
		private System.Windows.Forms.LinkLabel m_lnkAjoutLienElement;
		private System.Windows.Forms.Panel m_panelLienElement;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iTextBox m_txtLibelleLien;
		private sc2i.win32.common.ListViewAutoFilled m_listViewRelationElement;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn5;
		private sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelationLien;
		private sc2i.win32.common.C2iTabControl m_tab;
		private Crownwood.Magic.Controls.TabPage m_tabPageToRemove;
		private Crownwood.Magic.Controls.TabPage m_pageEvenements;
		private sc2i.win32.common.C2iTextBox m_txtCode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox m_wndImageRole;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.common.C2iComboBox m_cmbTypeSuivi;
		private timos.CPanelDefinisseurEvenements m_panelEvenements;
		private System.Windows.Forms.CheckBox m_chkSuppressionAutomatique;
		private Crownwood.Magic.Controls.TabPage m_pageSousDossiers;
		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelSousDossiers;
		private System.Windows.Forms.Label m_lblDossierParent;
		private System.Windows.Forms.Panel m_panelSousDossierEtCommentaires;
		private System.Windows.Forms.Panel m_panelCommentaires;
		private System.Windows.Forms.LinkLabel m_lnkTypeDossierPrincipal;
		private System.Windows.Forms.Panel m_panelTypeDossierParent;
		private Crownwood.Magic.Controls.TabPage m_pageElementSuivi;
		private sc2i.win32.common.C2iTabControl c2iTabControl2;
		private sc2i.win32.common.C2iTabControl c2iTabControl3;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltreElementSuivi;
		private System.Windows.Forms.CheckBox m_chkLienMultiple;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.Label label6;
        private CheckBox checkBox3;
        private Label label7;
        private CComboBoxListeObjetsDonnees m_cmbFormulaire;
		private const string c_champLibelleEtat = "LIBELLE_ETAT";

		public CFormEditionTypeDossierSuivi()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeDossierSuivi(CTypeDossierSuivi TypeDossierSuivi)
			:base(TypeDossierSuivi)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeDossierSuivi(CTypeDossierSuivi TypeDossierSuivi, CListeObjetsDonnees liste)
			:base(TypeDossierSuivi, liste)
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
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeDossierSuivi));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_listViewRelationsComptabilites = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelSousDossierEtCommentaires = new System.Windows.Forms.Panel();
            this.m_panelCommentaires = new System.Windows.Forms.Panel();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelTypeDossierParent = new System.Windows.Forms.Panel();
            this.m_lnkTypeDossierPrincipal = new System.Windows.Forms.LinkLabel();
            this.m_lblDossierParent = new System.Windows.Forms.Label();
            this.m_cmbTypeSuivi = new sc2i.win32.common.C2iComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_tabPageToRemove = new Crownwood.Magic.Controls.TabPage();
            this.m_pageElementSuivi = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFiltreElementSuivi = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl2 = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl3 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageElementsLies = new Crownwood.Magic.Controls.TabPage();
            this.m_listViewRelationElement = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelLienElement = new System.Windows.Forms.Panel();
            this.m_chkLienMultiple = new System.Windows.Forms.CheckBox();
            this.m_chkSuppressionAutomatique = new System.Windows.Forms.CheckBox();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_wndImageRole = new System.Windows.Forms.PictureBox();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtLibelleLien = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkAjoutLienElement = new System.Windows.Forms.LinkLabel();
            this.m_lnkSupprimerLienElement = new System.Windows.Forms.LinkLabel();
            this.m_cmbTypeElementsAAgenda = new sc2i.win32.common.C2iComboBox();
            this.m_pageFormulairesEtChamps = new Crownwood.Magic.Controls.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_pageSousDossiers = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSousDossiers = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_gestionnaireEditionRelationLien = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbFormulaire = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelSousDossierEtCommentaires.SuspendLayout();
            this.m_panelCommentaires.SuspendLayout();
            this.m_panelTypeDossierParent.SuspendLayout();
            this.m_tab.SuspendLayout();
            this.m_pageEvenements.SuspendLayout();
            this.m_pageElementSuivi.SuspendLayout();
            this.m_panelFiltreElementSuivi.SuspendLayout();
            this.m_pageElementsLies.SuspendLayout();
            this.m_panelLienElement.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImageRole)).BeginInit();
            this.m_pageFormulairesEtChamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.m_pageSousDossiers.SuspendLayout();
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 61;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(120, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(504, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 2;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_listViewRelationsComptabilites
            // 
            this.m_listViewRelationsComptabilites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listViewRelationsComptabilites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn8});
            this.m_listViewRelationsComptabilites.EnableCustomisation = true;
            this.m_listViewRelationsComptabilites.FullRowSelect = true;
            this.m_listViewRelationsComptabilites.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listViewRelationsComptabilites, "");
            this.m_listViewRelationsComptabilites.Location = new System.Drawing.Point(8, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRelationsComptabilites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listViewRelationsComptabilites, "");
            this.m_listViewRelationsComptabilites.Name = "m_listViewRelationsComptabilites";
            this.m_listViewRelationsComptabilites.Size = new System.Drawing.Size(360, 208);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRelationsComptabilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRelationsComptabilites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRelationsComptabilites.TabIndex = 3;
            this.m_listViewRelationsComptabilites.UseCompatibleStateImageBehavior = false;
            this.m_listViewRelationsComptabilites.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "Comptabilite.Libelle";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Comptabilité.Libellé";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 300;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelSousDossierEtCommentaires);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(8, 40);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(718, 162);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_panelSousDossierEtCommentaires
            // 
            this.m_panelSousDossierEtCommentaires.Controls.Add(this.m_panelCommentaires);
            this.m_panelSousDossierEtCommentaires.Controls.Add(this.m_panelTypeDossierParent);
            this.m_extLinkField.SetLinkField(this.m_panelSousDossierEtCommentaires, "");
            this.m_panelSousDossierEtCommentaires.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousDossierEtCommentaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSousDossierEtCommentaires, "");
            this.m_panelSousDossierEtCommentaires.Name = "m_panelSousDossierEtCommentaires";
            this.m_panelSousDossierEtCommentaires.Size = new System.Drawing.Size(692, 120);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousDossierEtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousDossierEtCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousDossierEtCommentaires.TabIndex = 69;
            // 
            // m_panelCommentaires
            // 
            this.m_panelCommentaires.Controls.Add(this.c2iTextBox1);
            this.m_panelCommentaires.Controls.Add(this.label2);
            this.m_panelCommentaires.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelCommentaires, "");
            this.m_panelCommentaires.Location = new System.Drawing.Point(0, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCommentaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCommentaires, "");
            this.m_panelCommentaires.Name = "m_panelCommentaires";
            this.m_panelCommentaires.Size = new System.Drawing.Size(692, 76);
            this.m_extStyle.SetStyleBackColor(this.m_panelCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCommentaires.TabIndex = 1;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.AcceptsReturn = true;
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Description");
            this.c2iTextBox1.Location = new System.Drawing.Point(120, 0);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(564, 63);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 63;
            this.c2iTextBox1.Text = "[Description]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(10, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 62;
            this.label2.Text = "Description|41";
            // 
            // m_panelTypeDossierParent
            // 
            this.m_panelTypeDossierParent.Controls.Add(this.m_cmbFormulaire);
            this.m_panelTypeDossierParent.Controls.Add(this.label7);
            this.m_panelTypeDossierParent.Controls.Add(this.checkBox3);
            this.m_panelTypeDossierParent.Controls.Add(this.m_lnkTypeDossierPrincipal);
            this.m_panelTypeDossierParent.Controls.Add(this.m_lblDossierParent);
            this.m_panelTypeDossierParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTypeDossierParent, "");
            this.m_panelTypeDossierParent.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeDossierParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeDossierParent, "");
            this.m_panelTypeDossierParent.Name = "m_panelTypeDossierParent";
            this.m_panelTypeDossierParent.Size = new System.Drawing.Size(692, 44);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeDossierParent.TabIndex = 0;
            // 
            // m_lnkTypeDossierPrincipal
            // 
            this.m_lnkTypeDossierPrincipal.BackColor = System.Drawing.Color.White;
            this.m_lnkTypeDossierPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lnkTypeDossierPrincipal, "TypeDossierParent.Libelle");
            this.m_lnkTypeDossierPrincipal.Location = new System.Drawing.Point(120, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTypeDossierPrincipal, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTypeDossierPrincipal, "");
            this.m_lnkTypeDossierPrincipal.Name = "m_lnkTypeDossierPrincipal";
            this.m_lnkTypeDossierPrincipal.Size = new System.Drawing.Size(562, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeDossierPrincipal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeDossierPrincipal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeDossierPrincipal.TabIndex = 69;
            this.m_lnkTypeDossierPrincipal.TabStop = true;
            this.m_lnkTypeDossierPrincipal.Text = "[TypeDossierParent.Libelle]";
            this.m_lnkTypeDossierPrincipal.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTypeDossierPrincipal_LinkClicked);
            // 
            // m_lblDossierParent
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDossierParent, "");
            this.m_lblDossierParent.Location = new System.Drawing.Point(10, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDossierParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDossierParent, "");
            this.m_lblDossierParent.Name = "m_lblDossierParent";
            this.m_lblDossierParent.Size = new System.Drawing.Size(103, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDossierParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDossierParent.TabIndex = 68;
            this.m_lblDossierParent.Text = "Main Workbook|952";
            // 
            // m_cmbTypeSuivi
            // 
            this.m_cmbTypeSuivi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSuivi.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSuivi, "");
            this.m_cmbTypeSuivi.Location = new System.Drawing.Point(132, 7);
            this.m_cmbTypeSuivi.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSuivi, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSuivi, "");
            this.m_cmbTypeSuivi.Name = "m_cmbTypeSuivi";
            this.m_cmbTypeSuivi.Size = new System.Drawing.Size(348, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSuivi.TabIndex = 65;
            this.m_cmbTypeSuivi.SelectedIndexChanged += new System.EventHandler(this.m_cmbTypeSuivi_SelectedIndexChanged);
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(8, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 64;
            this.label4.Text = "Managed elements|953";
            // 
            // m_panelDefinisseurChamps
            // 
            this.m_panelDefinisseurChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDefinisseurChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelDefinisseurChamps.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(0, 32);
            this.m_panelDefinisseurChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
            this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(806, 250);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelDefinisseurChamps.TabIndex = 3;
            // 
            // m_tab
            // 
            this.m_tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.ForeColor = System.Drawing.Color.Black;
            this.m_tab.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_tab.Location = new System.Drawing.Point(8, 208);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tab, "");
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.SelectedIndex = 0;
            this.m_tab.SelectedTab = this.m_tabPageToRemove;
            this.m_tab.Size = new System.Drawing.Size(822, 322);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 4003;
            this.m_tab.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageToRemove,
            this.m_pageElementSuivi,
            this.m_pageElementsLies,
            this.m_pageFormulairesEtChamps,
            this.m_pageSousDossiers,
            this.m_pageEvenements});
            this.m_tab.TextColor = System.Drawing.Color.Black;
            this.m_tab.SelectionChanged += new System.EventHandler(this.m_tab_SelectionChanged);
            // 
            // m_pageEvenements
            // 
            this.m_pageEvenements.Controls.Add(this.m_panelEvenements);
            this.m_extLinkField.SetLinkField(this.m_pageEvenements, "");
            this.m_pageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEvenements, "");
            this.m_pageEvenements.Name = "m_pageEvenements";
            this.m_pageEvenements.Selected = false;
            this.m_pageEvenements.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEvenements.TabIndex = 10;
            this.m_pageEvenements.Title = "Events|183";
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
            this.m_panelEvenements.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEvenements.TabIndex = 0;
            // 
            // m_tabPageToRemove
            // 
            this.m_extLinkField.SetLinkField(this.m_tabPageToRemove, "");
            this.m_tabPageToRemove.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageToRemove, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageToRemove, "");
            this.m_tabPageToRemove.Name = "m_tabPageToRemove";
            this.m_tabPageToRemove.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageToRemove.TabIndex = 2;
            this.m_tabPageToRemove.Title = "Page|30040";
            // 
            // m_pageElementSuivi
            // 
            this.m_pageElementSuivi.Controls.Add(this.m_panelFiltreElementSuivi);
            this.m_pageElementSuivi.Controls.Add(this.m_cmbTypeSuivi);
            this.m_pageElementSuivi.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_pageElementSuivi, "");
            this.m_pageElementSuivi.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElementSuivi, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElementSuivi, "");
            this.m_pageElementSuivi.Name = "m_pageElementSuivi";
            this.m_pageElementSuivi.Selected = false;
            this.m_pageElementSuivi.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_pageElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElementSuivi.TabIndex = 12;
            this.m_pageElementSuivi.Title = "Managed elements|953";
            // 
            // m_panelFiltreElementSuivi
            // 
            this.m_panelFiltreElementSuivi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltreElementSuivi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFiltreElementSuivi.Controls.Add(this.c2iTabControl2);
            this.m_panelFiltreElementSuivi.Controls.Add(this.c2iTabControl3);
            this.m_panelFiltreElementSuivi.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltreElementSuivi.FiltreDynamique = null;
            this.m_panelFiltreElementSuivi.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelFiltreElementSuivi, "");
            this.m_panelFiltreElementSuivi.Location = new System.Drawing.Point(8, 32);
            this.m_panelFiltreElementSuivi.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltreElementSuivi, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltreElementSuivi.ModeFiltreExpression = false;
            this.m_panelFiltreElementSuivi.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltreElementSuivi, "");
            this.m_panelFiltreElementSuivi.Name = "m_panelFiltreElementSuivi";
            this.m_panelFiltreElementSuivi.Size = new System.Drawing.Size(790, 242);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltreElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltreElementSuivi, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFiltreElementSuivi.TabIndex = 4;
            // 
            // c2iTabControl2
            // 
            this.c2iTabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl2.BoldSelectedPage = true;
            this.c2iTabControl2.ControlBottomOffset = 16;
            this.c2iTabControl2.ControlRightOffset = 16;
            this.c2iTabControl2.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl2, "");
            this.c2iTabControl2.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl2, "");
            this.c2iTabControl2.Name = "c2iTabControl2";
            this.c2iTabControl2.Ombre = true;
            this.c2iTabControl2.PositionTop = true;
            this.c2iTabControl2.Size = new System.Drawing.Size(1166, 394);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl2.TabIndex = 2;
            // 
            // c2iTabControl3
            // 
            this.c2iTabControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl3.BoldSelectedPage = true;
            this.c2iTabControl3.ControlBottomOffset = 16;
            this.c2iTabControl3.ControlRightOffset = 16;
            this.c2iTabControl3.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl3, "");
            this.c2iTabControl3.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl3, "");
            this.c2iTabControl3.Name = "c2iTabControl3";
            this.c2iTabControl3.Ombre = true;
            this.c2iTabControl3.PositionTop = true;
            this.c2iTabControl3.Size = new System.Drawing.Size(790, 194);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl3.TabIndex = 2;
            // 
            // m_pageElementsLies
            // 
            this.m_pageElementsLies.Controls.Add(this.m_listViewRelationElement);
            this.m_pageElementsLies.Controls.Add(this.m_panelLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_lnkAjoutLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_lnkSupprimerLienElement);
            this.m_pageElementsLies.Controls.Add(this.m_cmbTypeElementsAAgenda);
            this.m_extLinkField.SetLinkField(this.m_pageElementsLies, "");
            this.m_pageElementsLies.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElementsLies, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElementsLies, "");
            this.m_pageElementsLies.Name = "m_pageElementsLies";
            this.m_pageElementsLies.Selected = false;
            this.m_pageElementsLies.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_pageElementsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElementsLies, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElementsLies.TabIndex = 0;
            this.m_pageElementsLies.Title = "Linked elements|954";
            // 
            // m_listViewRelationElement
            // 
            this.m_listViewRelationElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listViewRelationElement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn5});
            this.m_listViewRelationElement.EnableCustomisation = false;
            this.m_listViewRelationElement.FullRowSelect = true;
            this.m_listViewRelationElement.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listViewRelationElement, "");
            this.m_listViewRelationElement.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRelationElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listViewRelationElement, "");
            this.m_listViewRelationElement.MultiSelect = false;
            this.m_listViewRelationElement.Name = "m_listViewRelationElement";
            this.m_listViewRelationElement.Size = new System.Drawing.Size(376, 242);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRelationElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRelationElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRelationElement.TabIndex = 14;
            this.m_listViewRelationElement.UseCompatibleStateImageBehavior = false;
            this.m_listViewRelationElement.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 203;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeElementsConvivial";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Type|54";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 156;
            // 
            // m_panelLienElement
            // 
            this.m_panelLienElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelLienElement.Controls.Add(this.m_chkLienMultiple);
            this.m_panelLienElement.Controls.Add(this.m_chkSuppressionAutomatique);
            this.m_panelLienElement.Controls.Add(this.m_panelFiltre);
            this.m_panelLienElement.Controls.Add(this.m_wndImageRole);
            this.m_panelLienElement.Controls.Add(this.m_txtCode);
            this.m_panelLienElement.Controls.Add(this.label5);
            this.m_panelLienElement.Controls.Add(this.m_txtLibelleLien);
            this.m_panelLienElement.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.m_panelLienElement, "");
            this.m_panelLienElement.Location = new System.Drawing.Point(392, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLienElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLienElement, "");
            this.m_panelLienElement.Name = "m_panelLienElement";
            this.m_panelLienElement.Size = new System.Drawing.Size(406, 266);
            this.m_extStyle.SetStyleBackColor(this.m_panelLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelLienElement.TabIndex = 13;
            this.m_panelLienElement.Visible = false;
            // 
            // m_chkLienMultiple
            // 
            this.m_extLinkField.SetLinkField(this.m_chkLienMultiple, "");
            this.m_chkLienMultiple.Location = new System.Drawing.Point(203, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkLienMultiple, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkLienMultiple, "");
            this.m_chkLienMultiple.Name = "m_chkLienMultiple";
            this.m_chkLienMultiple.Size = new System.Drawing.Size(168, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkLienMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkLienMultiple, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkLienMultiple.TabIndex = 9;
            this.m_chkLienMultiple.Text = "Multiple link|961";
            // 
            // m_chkSuppressionAutomatique
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSuppressionAutomatique, "");
            this.m_chkSuppressionAutomatique.Location = new System.Drawing.Point(8, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSuppressionAutomatique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSuppressionAutomatique, "");
            this.m_chkSuppressionAutomatique.Name = "m_chkSuppressionAutomatique";
            this.m_chkSuppressionAutomatique.Size = new System.Drawing.Size(176, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkSuppressionAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSuppressionAutomatique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSuppressionAutomatique.TabIndex = 2;
            this.m_chkSuppressionAutomatique.Text = "Automatic remove|960";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_panelFiltre.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_panelFiltre.Location = new System.Drawing.Point(0, 94);
            this.m_panelFiltre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(406, 172);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFiltre.TabIndex = 3;
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
            this.c2iTabControl1.Size = new System.Drawing.Size(406, 124);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // m_wndImageRole
            // 
            this.m_extLinkField.SetLinkField(this.m_wndImageRole, "");
            this.m_wndImageRole.Location = new System.Drawing.Point(48, 98);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndImageRole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndImageRole, "");
            this.m_wndImageRole.Name = "m_wndImageRole";
            this.m_wndImageRole.Size = new System.Drawing.Size(16, 16);
            this.m_wndImageRole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_extStyle.SetStyleBackColor(this.m_wndImageRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndImageRole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndImageRole.TabIndex = 8;
            this.m_wndImageRole.TabStop = false;
            // 
            // m_txtCode
            // 
            this.m_txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtCode, "");
            this.m_txtCode.Location = new System.Drawing.Point(89, 48);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(309, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 1;
            this.m_txtCode.Text = "c2iTextBox2";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(8, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 19);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4;
            this.label5.Text = "Link code|959";
            // 
            // m_txtLibelleLien
            // 
            this.m_txtLibelleLien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelleLien, "");
            this.m_txtLibelleLien.Location = new System.Drawing.Point(8, 24);
            this.m_txtLibelleLien.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelleLien, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelleLien, "");
            this.m_txtLibelleLien.Name = "m_txtLibelleLien";
            this.m_txtLibelleLien.Size = new System.Drawing.Size(390, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelleLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelleLien, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelleLien.TabIndex = 0;
            this.m_txtLibelleLien.Text = "c2iTextBox2";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Link label|958";
            // 
            // m_lnkAjoutLienElement
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkAjoutLienElement, "");
            this.m_lnkAjoutLienElement.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjoutLienElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjoutLienElement, "");
            this.m_lnkAjoutLienElement.Name = "m_lnkAjoutLienElement";
            this.m_lnkAjoutLienElement.Size = new System.Drawing.Size(126, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjoutLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjoutLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjoutLienElement.TabIndex = 10;
            this.m_lnkAjoutLienElement.TabStop = true;
            this.m_lnkAjoutLienElement.Text = "Add element type|957";
            this.m_lnkAjoutLienElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAjoutLienElement_LinkClicked);
            // 
            // m_lnkSupprimerLienElement
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerLienElement, "");
            this.m_lnkSupprimerLienElement.Location = new System.Drawing.Point(336, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerLienElement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerLienElement, "");
            this.m_lnkSupprimerLienElement.Name = "m_lnkSupprimerLienElement";
            this.m_lnkSupprimerLienElement.Size = new System.Drawing.Size(56, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerLienElement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerLienElement.TabIndex = 12;
            this.m_lnkSupprimerLienElement.TabStop = true;
            this.m_lnkSupprimerLienElement.Text = "Remove|18";
            this.m_lnkSupprimerLienElement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerLienElement_LinkClicked);
            // 
            // m_cmbTypeElementsAAgenda
            // 
            this.m_cmbTypeElementsAAgenda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElementsAAgenda.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElementsAAgenda, "");
            this.m_cmbTypeElementsAAgenda.Location = new System.Drawing.Point(140, 8);
            this.m_cmbTypeElementsAAgenda.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElementsAAgenda, "");
            this.m_cmbTypeElementsAAgenda.Name = "m_cmbTypeElementsAAgenda";
            this.m_cmbTypeElementsAAgenda.Size = new System.Drawing.Size(188, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElementsAAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElementsAAgenda.TabIndex = 11;
            // 
            // m_pageFormulairesEtChamps
            // 
            this.m_pageFormulairesEtChamps.Controls.Add(this.label6);
            this.m_pageFormulairesEtChamps.Controls.Add(this.pictureBox5);
            this.m_pageFormulairesEtChamps.Controls.Add(this.checkBox2);
            this.m_pageFormulairesEtChamps.Controls.Add(this.checkBox1);
            this.m_pageFormulairesEtChamps.Controls.Add(this.m_panelDefinisseurChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulairesEtChamps, "");
            this.m_pageFormulairesEtChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulairesEtChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulairesEtChamps, "");
            this.m_pageFormulairesEtChamps.Name = "m_pageFormulairesEtChamps";
            this.m_pageFormulairesEtChamps.Selected = false;
            this.m_pageFormulairesEtChamps.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulairesEtChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulairesEtChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulairesEtChamps.TabIndex = 1;
            this.m_pageFormulairesEtChamps.Title = "Fields and Forms|955";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(5, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Options|56";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.pictureBox5.Location = new System.Drawing.Point(8, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(720, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 6;
            this.pictureBox5.TabStop = false;
            // 
            // checkBox2
            // 
            this.m_extLinkField.SetLinkField(this.checkBox2, "MasquerAgenda");
            this.checkBox2.Location = new System.Drawing.Point(344, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 24);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Hide diary|963";
            // 
            // checkBox1
            // 
            this.m_extLinkField.SetLinkField(this.checkBox1, "MasquerCartoucheSurEdition");
            this.checkBox1.Location = new System.Drawing.Point(167, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(130, 24);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Hide header|962";
            // 
            // m_pageSousDossiers
            // 
            this.m_pageSousDossiers.Controls.Add(this.m_panelSousDossiers);
            this.m_extLinkField.SetLinkField(this.m_pageSousDossiers, "");
            this.m_pageSousDossiers.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSousDossiers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSousDossiers, "");
            this.m_pageSousDossiers.Name = "m_pageSousDossiers";
            this.m_pageSousDossiers.Selected = false;
            this.m_pageSousDossiers.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_pageSousDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSousDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSousDossiers.TabIndex = 11;
            this.m_pageSousDossiers.Title = "Sub Workbooks|956";
            // 
            // m_panelSousDossiers
            // 
            this.m_panelSousDossiers.AllowArbre = true;
            this.m_panelSousDossiers.AllowCustomisation = true;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Namexx";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 400;
            this.m_panelSousDossiers.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelSousDossiers.ContexteUtilisation = "";
            this.m_panelSousDossiers.ControlFiltreStandard = null;
            this.m_panelSousDossiers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSousDossiers.ElementSelectionne = null;
            this.m_panelSousDossiers.EnableCustomisation = true;
            this.m_panelSousDossiers.FiltreDeBase = null;
            this.m_panelSousDossiers.FiltreDeBaseEnAjout = false;
            this.m_panelSousDossiers.FiltrePrefere = null;
            this.m_panelSousDossiers.FiltreRapide = null;
            this.m_panelSousDossiers.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelSousDossiers, "");
            this.m_panelSousDossiers.ListeObjets = null;
            this.m_panelSousDossiers.Location = new System.Drawing.Point(0, 0);
            this.m_panelSousDossiers.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousDossiers, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelSousDossiers.ModeQuickSearch = false;
            this.m_panelSousDossiers.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelSousDossiers, "");
            this.m_panelSousDossiers.MultiSelect = true;
            this.m_panelSousDossiers.Name = "m_panelSousDossiers";
            this.m_panelSousDossiers.Navigateur = null;
            this.m_panelSousDossiers.ProprieteObjetAEditer = null;
            this.m_panelSousDossiers.QuickSearchText = "";
            this.m_panelSousDossiers.Size = new System.Drawing.Size(806, 281);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousDossiers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousDossiers.TabIndex = 2;
            this.m_panelSousDossiers.TrierAuClicSurEnteteColonne = true;
            // 
            // m_gestionnaireEditionRelationLien
            // 
            this.m_gestionnaireEditionRelationLien.ListeAssociee = this.m_listViewRelationElement;
            this.m_gestionnaireEditionRelationLien.ObjetEdite = null;
            this.m_gestionnaireEditionRelationLien.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationLien_InitChamp);
            this.m_gestionnaireEditionRelationLien.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelationLien_MAJ_Champs);
            // 
            // checkBox3
            // 
            this.m_extLinkField.SetLinkField(this.checkBox3, "UnSeulParParent");
            this.checkBox3.Location = new System.Drawing.Point(120, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox3, "");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(200, 24);
            this.m_extStyle.SetStyleBackColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox3.TabIndex = 70;
            this.checkBox3.Text = "One child per parent|20145";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(326, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 17);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 71;
            this.label7.Text = "Summary form|20146";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_cmbFormulaire
            // 
            this.m_cmbFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaire.ElementSelectionne = null;
            this.m_cmbFormulaire.FormattingEnabled = true;
            this.m_cmbFormulaire.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFormulaire, "");
            this.m_cmbFormulaire.ListDonnees = null;
            this.m_cmbFormulaire.Location = new System.Drawing.Point(494, 22);
            this.m_cmbFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormulaire, "");
            this.m_cmbFormulaire.Name = "m_cmbFormulaire";
            this.m_cmbFormulaire.NullAutorise = true;
            this.m_cmbFormulaire.ProprieteAffichee = null;
            this.m_cmbFormulaire.ProprieteParentListeObjets = null;
            this.m_cmbFormulaire.SelectionneurParent = null;
            this.m_cmbFormulaire.Size = new System.Drawing.Size(188, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaire.TabIndex = 72;
            this.m_cmbFormulaire.TextNull = "";
            this.m_cmbFormulaire.Tri = true;
            // 
            // CFormEditionTypeDossierSuivi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tab);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeDossierSuivi";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionTypeDossierSuivi_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_tab, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelSousDossierEtCommentaires.ResumeLayout(false);
            this.m_panelCommentaires.ResumeLayout(false);
            this.m_panelCommentaires.PerformLayout();
            this.m_panelTypeDossierParent.ResumeLayout(false);
            this.m_tab.ResumeLayout(false);
            this.m_tab.PerformLayout();
            this.m_pageEvenements.ResumeLayout(false);
            this.m_pageElementSuivi.ResumeLayout(false);
            this.m_panelFiltreElementSuivi.ResumeLayout(false);
            this.m_pageElementsLies.ResumeLayout(false);
            this.m_panelLienElement.ResumeLayout(false);
            this.m_panelLienElement.PerformLayout();
            this.m_panelFiltre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImageRole)).EndInit();
            this.m_pageFormulairesEtChamps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.m_pageSousDossiers.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeDossierSuivi TypeDossierSuivi
		{
			get
			{
				return (CTypeDossierSuivi)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void InitPanelChampsCustom()
		{
			m_panelDefinisseurChamps.InitPanel
				(
				TypeDossierSuivi,
				typeof(CFormListeChampsCustom),
				typeof(CFormListeFormulaires) );
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			InitComboTypesLiensPossibles(false);

			InitComboTypesSuivis ( false );


            CResultAErreur result = base.MyInitChamps();

			m_panelTypeDossierParent.Visible = TypeDossierSuivi.TypeDossierParent != null;

            if (TypeDossierSuivi.TypeDossierParent != null)
            {
                CListeObjetsDonnees lstFormulaires = new CListeObjetsDonnees(TypeDossierSuivi.ContexteDonnee,
                    typeof(CFormulaire), 
                    CFormulaire.GetFiltreFormulairesForRole(CDossierSuivi.c_roleChampCustom));
                m_cmbFormulaire.Init(lstFormulaires, "Libelle", false);
                m_cmbFormulaire.ElementSelectionne = TypeDossierSuivi.FormulaireResume;
            }

			if ( TypeDossierSuivi.TypeSuivi != null )
				m_cmbTypeSuivi.SelectedValue = TypeDossierSuivi.TypeSuivi;
			else
				m_cmbTypeSuivi.SelectedValue = typeof(DBNull);
			
			//Regarde s'il y a des dossiers attachés
			CListeObjetsDonnees listeDossiers = new CListeObjetsDonnees ( TypeDossierSuivi.ContexteDonnee,
				typeof ( CDossierSuivi ) );
			listeDossiers.Filtre = new CFiltreData ( CTypeDossierSuivi.c_champId+"=@1",
				TypeDossierSuivi.Id );

			if ( TypeDossierSuivi.IsNew() || listeDossiers.CountNoLoad == 0 )
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeSuivi, TypeModeEdition.EnableSurEdition );
				m_cmbTypeSuivi.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeSuivi, TypeModeEdition.Autonome );
				m_cmbTypeSuivi.LockEdition = true;
			}
			
			AffecterTitre(I.T("Workbook type |30136") + TypeDossierSuivi.Libelle);


			m_panelDefinisseurChamps.InitPanel( TypeDossierSuivi, 
				typeof(CFormListeChampsCustom),
				typeof(CFormListeFormulaires) );

			m_panelSousDossiers.InitFromListeObjets (
				TypeDossierSuivi.TypesDossiersFils,
				typeof(CTypeDossierSuivi),
				typeof ( CFormEditionTypeDossierSuivi ),
				TypeDossierSuivi,
				"TypeDossierParent");

			CFiltreDynamique filtre = TypeDossierSuivi.FiltreDynamiqueElementsSuivisPossibles;
			if ( filtre != null )
				m_panelFiltreElementSuivi.InitSansVariables ( filtre );
			else
				m_panelFiltreElementSuivi.InitSansVariables ( TypeDossierSuivi.GetNewFiltreElementsSuivis() );

			m_panelFiltreElementSuivi.ModeSansType = true;
			m_panelFiltreElementSuivi.MasquerFormulaire ( true );


			m_panelEvenements.InitChamps ( TypeDossierSuivi );


			m_gestionnaireEditionRelationLien.ObjetEdite = TypeDossierSuivi.RelationsTypesElements;
			
			return result;
			
		}


				
		//-------------------------------------------------------------------------
		private void m_lnkNewChampCustom_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CChampCustom champ = new CChampCustom(CSc2iWin32DataClient.ContexteCourant);
			champ.CreateNew();
			CFormEditionChampCustom frm = new CFormEditionChampCustom(champ);
			CSc2iWin32DataNavigation.Navigateur.AffichePage( frm );
		}
		
		//------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;

			if ( m_cmbTypeSuivi.SelectedValue is Type )
			{
				Type tp = (Type)m_cmbTypeSuivi.SelectedValue;
				if ( tp != typeof(DBNull) )
					TypeDossierSuivi.TypeSuivi = (Type)m_cmbTypeSuivi.SelectedValue;
				else
					TypeDossierSuivi.TypeSuivi = null;
			}
			else
				TypeDossierSuivi.TypeSuivi = null;

			m_gestionnaireEditionRelationLien.ValideModifs();
			
			result = m_panelDefinisseurChamps.MAJ_Champs();

			if ( result )
				result = m_panelEvenements.MAJ_Champs();

			if ( m_panelFiltreElementSuivi.FiltreDynamique != null &&
				m_panelFiltreElementSuivi.FiltreDynamique.ComposantPrincipal != null )
				TypeDossierSuivi.FiltreDynamiqueElementsSuivisPossibles = m_panelFiltreElementSuivi.FiltreDynamique;
			else
				TypeDossierSuivi.FiltreDynamiqueElementsSuivisPossibles = null;

            TypeDossierSuivi.FormulaireResume = m_cmbFormulaire.ElementSelectionne as CFormulaire;

			return result;
		}

		private void CFormEditionTypeDossierSuivi_Load(object sender, System.EventArgs e)
		{
			if ( m_tab.TabPages.Count > 0 && m_tab.TabPages[0] == m_tabPageToRemove )
				m_tab.TabPages.RemoveAt(0);
		}

		/// <summary>
		/// ///////////////////////////////////////////////////
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void m_gestionnaireEditionRelationLien_InitChamp(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
		{
			CRelationTypeDossierSuivi_TypeElement relation = (CRelationTypeDossierSuivi_TypeElement)args.Objet;
			if ( relation == null )
			{
				m_panelLienElement.Visible = false;
				return;
			}
			m_chkSuppressionAutomatique.Checked = relation.SuppressionAutomatique;
			m_chkLienMultiple.Checked = relation.Multiple;
			m_panelLienElement.Visible = true;
			m_txtLibelleLien.Text = relation.Libelle;
			m_txtCode.Text = relation.Code;

			CFiltreDynamique filtre = relation.FiltreDynamiqueAssocie;
			if ( filtre == null )
				filtre = new CFiltreDynamique(relation.ContexteDonnee);
			filtre.TypeElements = relation.TypeElements;
			m_panelFiltre.InitSansVariables ( filtre );

		}


		/// ///////////////////////////////////////////////////
		private void m_gestionnaireEditionRelationLien_MAJ_Champs(object sender, sc2i.data.CObjetDonneeResultEventArgs args)
		{
			CRelationTypeDossierSuivi_TypeElement relation = (CRelationTypeDossierSuivi_TypeElement)args.Objet;
			if ( relation == null || !EtatEdition)
			{
				m_panelLienElement.Visible = false;
				return;
			}
			relation.Libelle = m_txtLibelleLien.Text;
			relation.Code = m_txtCode.Text;
			relation.SuppressionAutomatique = m_chkSuppressionAutomatique.Checked;
			relation.Multiple = m_chkLienMultiple.Checked;
			
			CFiltreDynamique filtre = m_panelFiltre.FiltreDynamique;
			if ( filtre.ComposantPrincipal != null )
				relation.FiltreDynamiqueAssocie = filtre;
			else
				relation.FiltreDynamiqueAssocie = null;

			m_panelLienElement.Visible = true;
		}
		
		//-------------------------------------------------------------------------
		private void InitComboTypesLiensPossibles ( bool bForcer )
		{
			if ( m_cmbTypeElementsAAgenda.Items.Count == 0 || bForcer )
			{
				ArrayList lst = new ArrayList();
				
				foreach ( CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass() )
					if ( typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(info.Classe) )
					{
						lst.Add ( info );
					}
                lst.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(none)|30291")));
                m_cmbTypeElementsAAgenda.DataSource = null;
				m_cmbTypeElementsAAgenda.DataSource = lst;
				m_cmbTypeElementsAAgenda.ValueMember = "Classe";
				m_cmbTypeElementsAAgenda.DisplayMember = "Nom";
			}
		}

		
		//-------------------------------------------------------------------------
		private void InitComboTypesSuivis ( bool bForcer )
		{
			if ( m_cmbTypeSuivi.Items.Count == 0 || bForcer )
			{
				ArrayList lst = new ArrayList();
                lst.Add(new CInfoClasseDynamique(typeof(DBNull), I.T("(none)|30291")));
				
				foreach ( CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass(typeof(sc2i.data.TableAttribute)) )
					if ( typeof(CObjetDonneeAIdNumerique).IsAssignableFrom(info.Classe) )
					{
						lst.Add ( info );
					}
                lst.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("(none)|30291")));
                m_cmbTypeSuivi.DataSource = null;
				m_cmbTypeSuivi.DataSource = lst;
				m_cmbTypeSuivi.ValueMember = "Classe";
				m_cmbTypeSuivi.DisplayMember = "Nom";
			}
		}

		//-------------------------------------------------------------------------
		private void m_lnkAjoutLienElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (m_cmbTypeElementsAAgenda.SelectedValue == null || m_cmbTypeElementsAAgenda.SelectedValue == typeof(DBNull))
				return;
			CRelationTypeDossierSuivi_TypeElement relation = new CRelationTypeDossierSuivi_TypeElement ( TypeDossierSuivi.ContexteDonnee );
			relation.CreateNewInCurrentContexte();
			relation.TypeDossierSuivi = TypeDossierSuivi;
			relation.TypeElements = (Type)m_cmbTypeElementsAAgenda.SelectedValue;
			
			ListViewItem item = new ListViewItem();
			m_listViewRelationElement.Items.Add ( item );
			m_listViewRelationElement.UpdateItemWithObject(item, relation);
			foreach ( ListViewItem itemSel in m_listViewRelationElement.SelectedItems )
				itemSel.Selected = false;
			item.Selected = true;
		}

		//-------------------------------------------------------------------------
		private void m_lnkSupprimerLienElement_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if (m_listViewRelationElement.SelectedItems.Count != 1)
				return;

			CRelationTypeDossierSuivi_TypeElement relation = (CRelationTypeDossierSuivi_TypeElement)m_listViewRelationElement.SelectedItems[0].Tag;
			
			m_gestionnaireEditionRelationLien.SetObjetEnCoursToNull();
			CResultAErreur result = relation.Delete();
			if(!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_listViewRelationElement.SelectedItems[0]!=null)
				m_listViewRelationElement.SelectedItems[0].Remove();
		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeSuivi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if ( m_cmbTypeSuivi.SelectedValue is Type && m_cmbTypeSuivi.SelectedValue != typeof(DBNull))
			{
				Type tp = (Type)m_cmbTypeSuivi.SelectedValue;
				if ( tp != typeof(DBNull ) )
				{
					m_panelFiltreElementSuivi.Visible = true;
					if ( m_panelFiltreElementSuivi.FiltreDynamique != null )
						m_panelFiltreElementSuivi.FiltreDynamique.TypeElements = (Type)m_cmbTypeSuivi.SelectedValue;
				}
				else
					m_panelFiltreElementSuivi.Visible = false;
			}
		}

        //----------------------------------------------------------------------------------------
        private void m_tab_SelectionChanged(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------------------------
        private void m_lnkTypeDossierPrincipal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(TypeDossierSuivi.TypeDossierParent != null)
                CTimosApp.Navigateur.AffichePage(new CFormEditionTypeDossierSuivi(TypeDossierSuivi.TypeDossierParent));
        }

	}
}

