using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.win32.data;
using sc2i.win32.common;

using timos.preventives;
using timos.acteurs;
using timos.data;
using timos.data.preventives;
using System.Collections.Generic;

namespace timos
{
	[ObjectEditeur(typeof(CContrat))]
	public class CFormEditionContrat : CFormEditionStdTimos, IFormNavigable
	{

		#region Designer generated code

		private System.Windows.Forms.Label lbl_label;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private Label label2;
        private CComboBoxLinkListeObjetsDonnees m_cmbxSelectClient;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageTickets;
        private Label label3;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Crownwood.Magic.Controls.TabPage m_pageFiche;
        private Crownwood.Magic.Controls.TabPage m_pagePlanPrev;
        private sc2i.formulaire.win32.editor.CPanelFormulaireSurElement m_panelFormulaire;
        private CComboBoxLinkListeObjetsDonnees m_cmbxSelectTypeContrat;
        private Label label4;
        private Crownwood.Magic.Controls.TabPage m_pageSites;
        private Label label6;
        private C2iTextBoxSelectionne m_txtSelectSites;
        private CWndLinkStd m_lnkSupprimerSite;
        private CWndLinkStd m_lnkAjouterSite;
        private ListViewAutoFilled m_listeSites;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireListeSites;
        private ListViewAutoFilled m_listRelContrat_ListeOp;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private CWndLinkStd m_lnkSupprimerListeOp;
        private CWndLinkStd m_lnkAjouterListeOp;
        private C2iTextBoxSelectionne m_txtSelectListeOp;
        private Label label7;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireListeOperations;
        private Panel m_panelListeOperations;
        private Label label8;
        private CExtLinkField m_linkFieldListeOp;
        private Label m_lblRecurrence;
        private Label m_lblDateLimite;
        private ListViewAutoFilled m_listeSitesListeOperations;
        private ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private CWndLinkStd m_lnkSupprimerSite2;
        private CWndLinkStd m_lnkAjouterSite2;
        private C2iTextBoxSelectionne m_txtSelectSites2;
        private Label label12;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireListeSites2;
        private C2iDateTimeExPicker m_ctrlDateLimite;
		private C2iComboBox m_cmbPeriodicite;
		private C2iTextBoxNumerique m_tbnNbPeriode;
		private C2iTextBoxNumerique m_nbNbParPeriode;
		private Label m_lblPeriode;
		private Label m_lblTypeIntervention;
		private C2iTextBoxSelectionne m_txtSelectTypeIntervention;
		private Label m_lblCouleur;
		private C2iPanel m_panelCouleur;
		private C2iDateTimePicker m_ctrlDateDebut;
		private Label m_lblDateStart;
        private LinkLabel m_lnkPlanifier;
        private CGestionnaireEditionSousObjetDonnee m_gestionTypesTickets;
        private CWndLinkStd m_wndAddTypeTicket;
        private C2iTextBoxSelectionne m_selectTypeTicket;
        private ListViewAutoFilled m_wndListeTypesTickets;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private CExtLinkField m_linkFieldTypeTicket;
        private ListViewAutoFilledColumn listViewAutoFilledColumn6;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireListeSitesTypeTicket;
        private Label label10;
        private Panel m_panelSitesManuels;
        private Panel m_panelModeGestion;
        private Panel m_panelSitesAuto;
        private Label label13;
        private CComboBoxLinkListeObjetsDonnees m_cmbSelectProfilContrat;
        private Panel panel2;
        private timos.interventions.CControleEditePeriodes m_editeurPeriodesTicket;
        private Panel panel3;
        private LinkLabel m_lnkUpdateTablePeriodesTicket;
        private Splitter splitter1;
        private Panel panel1;
        private CWndLinkStd m_wndRemoveTypeTicket;
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
			base.Dispose(disposing);
		}

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lbl_label = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbxSelectTypeContrat = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_cmbxSelectClient = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageTickets = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_editeurPeriodesTicket = new timos.interventions.CControleEditePeriodes();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkUpdateTablePeriodesTicket = new System.Windows.Forms.LinkLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_wndRemoveTypeTicket = new sc2i.win32.common.CWndLinkStd();
            this.label3 = new System.Windows.Forms.Label();
            this.m_wndListeTypesTickets = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_wndAddTypeTicket = new sc2i.win32.common.CWndLinkStd();
            this.m_selectTypeTicket = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_pageSites = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSitesManuels = new System.Windows.Forms.Panel();
            this.m_lnkSupprimerSite = new sc2i.win32.common.CWndLinkStd();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtSelectSites = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAjouterSite = new sc2i.win32.common.CWndLinkStd();
            this.m_listeSites = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelSitesAuto = new System.Windows.Forms.Panel();
            this.m_cmbSelectProfilContrat = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label13 = new System.Windows.Forms.Label();
            this.m_panelModeGestion = new System.Windows.Forms.Panel();
            this.m_pagePlanPrev = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeOperations = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lnkPlanifier = new System.Windows.Forms.LinkLabel();
            this.m_panelCouleur = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbPeriodicite = new sc2i.win32.common.C2iComboBox();
            this.m_tbnNbPeriode = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_nbNbParPeriode = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_ctrlDateDebut = new sc2i.win32.common.C2iDateTimePicker();
            this.m_ctrlDateLimite = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_listeSitesListeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkSupprimerSite2 = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterSite2 = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeIntervention = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_txtSelectSites2 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblTypeIntervention = new System.Windows.Forms.Label();
            this.m_lblDateStart = new System.Windows.Forms.Label();
            this.m_lblDateLimite = new System.Windows.Forms.Label();
            this.m_lblRecurrence = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblPeriode = new System.Windows.Forms.Label();
            this.m_lblCouleur = new System.Windows.Forms.Label();
            this.m_listRelContrat_ListeOp = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkSupprimerListeOp = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterListeOp = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectListeOp = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label7 = new System.Windows.Forms.Label();
            this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFormulaire = new sc2i.formulaire.win32.editor.CPanelFormulaireSurElement();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireListeSites = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireListeOperations = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkFieldListeOp = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireListeSites2 = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionTypesTickets = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkFieldTypeTicket = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireListeSitesTypeTicket = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageTickets.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_pageSites.SuspendLayout();
            this.m_panelSitesManuels.SuspendLayout();
            this.m_panelSitesAuto.SuspendLayout();
            this.m_pagePlanPrev.SuspendLayout();
            this.m_panelListeOperations.SuspendLayout();
            this.m_pageFiche.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblNbListes, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnPrecedent, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnSuivant, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_btnAjout, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extLinkField.SetLinkField(this.m_lblId, "");
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblId, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_imageCle, "");
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_linkFieldListeOp.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // lbl_label
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.lbl_label, "");
            this.m_extLinkField.SetLinkField(this.lbl_label, "");
            this.m_linkFieldListeOp.SetLinkField(this.lbl_label, "");
            this.lbl_label.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_label, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_label, "");
            this.lbl_label.Name = "lbl_label";
            this.lbl_label.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_label, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_label.TabIndex = 4002;
            this.lbl_label.Text = "Contract label|560";
            // 
            // m_txtLibelle
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_txtLibelle, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_txtLibelle, "");
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
            this.c2iPanelOmbre4.Controls.Add(this.lbl_label);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxSelectTypeContrat);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbxSelectClient);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_linkFieldListeOp.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(592, 100);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label2
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_linkFieldListeOp.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Customer|558";
            // 
            // m_cmbxSelectTypeContrat
            // 
            this.m_cmbxSelectTypeContrat.ComportementLinkStd = true;
            this.m_cmbxSelectTypeContrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectTypeContrat.ElementSelectionne = null;
            this.m_cmbxSelectTypeContrat.FormattingEnabled = true;
            this.m_cmbxSelectTypeContrat.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectTypeContrat, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_cmbxSelectTypeContrat, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_cmbxSelectTypeContrat, "");
            this.m_cmbxSelectTypeContrat.LinkProperty = "";
            this.m_cmbxSelectTypeContrat.ListDonnees = null;
            this.m_cmbxSelectTypeContrat.Location = new System.Drawing.Point(132, 31);
            this.m_cmbxSelectTypeContrat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectTypeContrat, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectTypeContrat, "");
            this.m_cmbxSelectTypeContrat.Name = "m_cmbxSelectTypeContrat";
            this.m_cmbxSelectTypeContrat.NullAutorise = false;
            this.m_cmbxSelectTypeContrat.ProprieteAffichee = null;
            this.m_cmbxSelectTypeContrat.ProprieteParentListeObjets = null;
            this.m_cmbxSelectTypeContrat.SelectionneurParent = null;
            this.m_cmbxSelectTypeContrat.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectTypeContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectTypeContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectTypeContrat.TabIndex = 4004;
            this.m_cmbxSelectTypeContrat.TextNull = "(empty)";
            this.m_cmbxSelectTypeContrat.Tri = true;
            this.m_cmbxSelectTypeContrat.TypeFormEdition = null;
            this.m_cmbxSelectTypeContrat.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxSelectTypeContrat_SelectionChangeCommitted);
            // 
            // m_cmbxSelectClient
            // 
            this.m_cmbxSelectClient.ComportementLinkStd = true;
            this.m_cmbxSelectClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectClient.ElementSelectionne = null;
            this.m_cmbxSelectClient.FormattingEnabled = true;
            this.m_cmbxSelectClient.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectClient, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_cmbxSelectClient, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_cmbxSelectClient, "");
            this.m_cmbxSelectClient.LinkProperty = "";
            this.m_cmbxSelectClient.ListDonnees = null;
            this.m_cmbxSelectClient.Location = new System.Drawing.Point(132, 55);
            this.m_cmbxSelectClient.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectClient, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectClient, "");
            this.m_cmbxSelectClient.Name = "m_cmbxSelectClient";
            this.m_cmbxSelectClient.NullAutorise = false;
            this.m_cmbxSelectClient.ProprieteAffichee = null;
            this.m_cmbxSelectClient.ProprieteParentListeObjets = null;
            this.m_cmbxSelectClient.SelectionneurParent = null;
            this.m_cmbxSelectClient.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectClient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectClient.TabIndex = 4003;
            this.m_cmbxSelectClient.TextNull = "(empty)";
            this.m_cmbxSelectClient.Tri = true;
            this.m_cmbxSelectClient.TypeFormEdition = null;
            // 
            // label4
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_linkFieldListeOp.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(16, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "Contract Type|1128";
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
            this.m_linkFieldTypeTicket.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSites;
            this.m_tabControl.Size = new System.Drawing.Size(810, 360);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSites,
            this.m_pageTickets,
            this.m_pagePlanPrev,
            this.m_pageFiche});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_pageTickets
            // 
            this.m_pageTickets.Controls.Add(this.panel2);
            this.m_pageTickets.Controls.Add(this.splitter1);
            this.m_pageTickets.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageTickets, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_pageTickets, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_pageTickets, "");
            this.m_pageTickets.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTickets, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTickets, "");
            this.m_pageTickets.Name = "m_pageTickets";
            this.m_pageTickets.Selected = false;
            this.m_pageTickets.Size = new System.Drawing.Size(794, 319);
            this.m_extStyle.SetStyleBackColor(this.m_pageTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTickets.TabIndex = 10;
            this.m_pageTickets.Title = "Tickets management|1133";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_editeurPeriodesTicket);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkFieldTypeTicket.SetLinkField(this.panel2, "");
            this.m_linkFieldListeOp.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(203, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(591, 319);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4009;
            // 
            // m_editeurPeriodesTicket
            // 
            this.m_editeurPeriodesTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_editeurPeriodesTicket, "");
            this.m_extLinkField.SetLinkField(this.m_editeurPeriodesTicket, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_editeurPeriodesTicket, "");
            this.m_editeurPeriodesTicket.Location = new System.Drawing.Point(0, 31);
            this.m_editeurPeriodesTicket.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editeurPeriodesTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editeurPeriodesTicket, "");
            this.m_editeurPeriodesTicket.Name = "m_editeurPeriodesTicket";
            this.m_editeurPeriodesTicket.Size = new System.Drawing.Size(591, 288);
            this.m_extStyle.SetStyleBackColor(this.m_editeurPeriodesTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurPeriodesTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurPeriodesTicket.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lnkUpdateTablePeriodesTicket);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkFieldTypeTicket.SetLinkField(this.panel3, "");
            this.m_linkFieldListeOp.SetLinkField(this.panel3, "");
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(591, 31);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 0;
            // 
            // m_lnkUpdateTablePeriodesTicket
            // 
            this.m_lnkUpdateTablePeriodesTicket.AutoSize = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkUpdateTablePeriodesTicket, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkUpdateTablePeriodesTicket, "");
            this.m_extLinkField.SetLinkField(this.m_lnkUpdateTablePeriodesTicket, "");
            this.m_lnkUpdateTablePeriodesTicket.Location = new System.Drawing.Point(7, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkUpdateTablePeriodesTicket, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkUpdateTablePeriodesTicket, "");
            this.m_lnkUpdateTablePeriodesTicket.Name = "m_lnkUpdateTablePeriodesTicket";
            this.m_lnkUpdateTablePeriodesTicket.Size = new System.Drawing.Size(102, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUpdateTablePeriodesTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUpdateTablePeriodesTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUpdateTablePeriodesTicket.TabIndex = 0;
            this.m_lnkUpdateTablePeriodesTicket.TabStop = true;
            this.m_lnkUpdateTablePeriodesTicket.Text = "Edit periods|20231";
            this.m_lnkUpdateTablePeriodesTicket.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUpdateTablePeriodesTicket_LinkClicked);
            // 
            // splitter1
            // 
            this.m_linkFieldListeOp.SetLinkField(this.splitter1, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 319);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 4010;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_wndRemoveTypeTicket);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_wndListeTypesTickets);
            this.panel1.Controls.Add(this.m_wndAddTypeTicket);
            this.panel1.Controls.Add(this.m_selectTypeTicket);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_linkFieldTypeTicket.SetLinkField(this.panel1, "");
            this.m_linkFieldListeOp.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 319);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4008;
            // 
            // m_wndRemoveTypeTicket
            // 
            this.m_wndRemoveTypeTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndRemoveTypeTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndRemoveTypeTicket.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_wndRemoveTypeTicket, "");
            this.m_extLinkField.SetLinkField(this.m_wndRemoveTypeTicket, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_wndRemoveTypeTicket, "");
            this.m_wndRemoveTypeTicket.Location = new System.Drawing.Point(8, 301);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndRemoveTypeTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndRemoveTypeTicket, "");
            this.m_wndRemoveTypeTicket.Name = "m_wndRemoveTypeTicket";
            this.m_wndRemoveTypeTicket.Size = new System.Drawing.Size(143, 18);
            this.m_extStyle.SetStyleBackColor(this.m_wndRemoveTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndRemoveTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndRemoveTypeTicket.TabIndex = 4008;
            this.m_wndRemoveTypeTicket.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_wndRemoveTypeTicket.LinkClicked += new System.EventHandler(this.m_wndRemoveTypeTicket_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_linkFieldListeOp.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(2, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4003;
            this.label3.Text = "Associated Tickets Types|559";
            // 
            // m_wndListeTypesTickets
            // 
            this.m_wndListeTypesTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeTypesTickets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5});
            this.m_wndListeTypesTickets.EnableCustomisation = true;
            this.m_wndListeTypesTickets.FullRowSelect = true;
            this.m_wndListeTypesTickets.HideSelection = false;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_wndListeTypesTickets, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeTypesTickets, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_wndListeTypesTickets, "");
            this.m_wndListeTypesTickets.Location = new System.Drawing.Point(5, 61);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypesTickets, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeTypesTickets, "");
            this.m_wndListeTypesTickets.MultiSelect = false;
            this.m_wndListeTypesTickets.Name = "m_wndListeTypesTickets";
            this.m_wndListeTypesTickets.Size = new System.Drawing.Size(192, 234);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesTickets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypesTickets.TabIndex = 4004;
            this.m_wndListeTypesTickets.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypesTickets.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeTicket.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 278;
            // 
            // m_wndAddTypeTicket
            // 
            this.m_wndAddTypeTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_wndAddTypeTicket.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_wndAddTypeTicket, "");
            this.m_extLinkField.SetLinkField(this.m_wndAddTypeTicket, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_wndAddTypeTicket, "");
            this.m_wndAddTypeTicket.Location = new System.Drawing.Point(5, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAddTypeTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndAddTypeTicket, "");
            this.m_wndAddTypeTicket.Name = "m_wndAddTypeTicket";
            this.m_wndAddTypeTicket.Size = new System.Drawing.Size(56, 18);
            this.m_extStyle.SetStyleBackColor(this.m_wndAddTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAddTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAddTypeTicket.TabIndex = 4007;
            this.m_wndAddTypeTicket.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_wndAddTypeTicket.LinkClicked += new System.EventHandler(this.m_wndAddTypeTicket_LinkClicked);
            // 
            // m_selectTypeTicket
            // 
            this.m_selectTypeTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectTypeTicket.ElementSelectionne = null;
            this.m_selectTypeTicket.FonctionTextNull = null;
            this.m_selectTypeTicket.HasLink = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_selectTypeTicket, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_selectTypeTicket, "");
            this.m_extLinkField.SetLinkField(this.m_selectTypeTicket, "");
            this.m_selectTypeTicket.Location = new System.Drawing.Point(5, 16);
            this.m_selectTypeTicket.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeTicket, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeTicket, "");
            this.m_selectTypeTicket.Name = "m_selectTypeTicket";
            this.m_selectTypeTicket.SelectedObject = null;
            this.m_selectTypeTicket.Size = new System.Drawing.Size(192, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeTicket, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeTicket.TabIndex = 4006;
            this.m_selectTypeTicket.TextNull = "";
            // 
            // m_pageSites
            // 
            this.m_pageSites.Controls.Add(this.m_panelSitesManuels);
            this.m_pageSites.Controls.Add(this.m_panelSitesAuto);
            this.m_pageSites.Controls.Add(this.m_panelModeGestion);
            this.m_extLinkField.SetLinkField(this.m_pageSites, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_pageSites, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_pageSites, "");
            this.m_pageSites.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSites, "");
            this.m_pageSites.Name = "m_pageSites";
            this.m_pageSites.Size = new System.Drawing.Size(794, 319);
            this.m_extStyle.SetStyleBackColor(this.m_pageSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSites.TabIndex = 13;
            this.m_pageSites.Title = "Sites management|1134";
            // 
            // m_panelSitesManuels
            // 
            this.m_panelSitesManuels.Controls.Add(this.m_lnkSupprimerSite);
            this.m_panelSitesManuels.Controls.Add(this.label6);
            this.m_panelSitesManuels.Controls.Add(this.m_txtSelectSites);
            this.m_panelSitesManuels.Controls.Add(this.m_lnkAjouterSite);
            this.m_panelSitesManuels.Controls.Add(this.m_listeSites);
            this.m_panelSitesManuels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelSitesManuels, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_panelSitesManuels, "");
            this.m_extLinkField.SetLinkField(this.m_panelSitesManuels, "");
            this.m_panelSitesManuels.Location = new System.Drawing.Point(0, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSitesManuels, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSitesManuels, "");
            this.m_panelSitesManuels.Name = "m_panelSitesManuels";
            this.m_panelSitesManuels.Size = new System.Drawing.Size(794, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelSitesManuels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSitesManuels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSitesManuels.TabIndex = 5;
            // 
            // m_lnkSupprimerSite
            // 
            this.m_lnkSupprimerSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkSupprimerSite, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerSite, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkSupprimerSite, "");
            this.m_lnkSupprimerSite.Location = new System.Drawing.Point(3, 241);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerSite, "");
            this.m_lnkSupprimerSite.Name = "m_lnkSupprimerSite";
            this.m_lnkSupprimerSite.Size = new System.Drawing.Size(86, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerSite.TabIndex = 3;
            this.m_lnkSupprimerSite.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerSite.LinkClicked += new System.EventHandler(this.m_lnkSupprimerSite_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_linkFieldListeOp.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(3, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(242, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 1;
            this.label6.Text = "Select Sites to associate to this Contract|1136";
            // 
            // m_txtSelectSites
            // 
            this.m_txtSelectSites.ElementSelectionne = null;
            this.m_txtSelectSites.FonctionTextNull = null;
            this.m_txtSelectSites.HasLink = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_txtSelectSites, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_txtSelectSites, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectSites, "");
            this.m_txtSelectSites.Location = new System.Drawing.Point(3, 17);
            this.m_txtSelectSites.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectSites, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectSites, "");
            this.m_txtSelectSites.Name = "m_txtSelectSites";
            this.m_txtSelectSites.SelectedObject = null;
            this.m_txtSelectSites.Size = new System.Drawing.Size(333, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectSites.TabIndex = 2;
            this.m_txtSelectSites.TextNull = "";
            // 
            // m_lnkAjouterSite
            // 
            this.m_lnkAjouterSite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterSite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkAjouterSite, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterSite, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkAjouterSite, "");
            this.m_lnkAjouterSite.Location = new System.Drawing.Point(3, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterSite, "");
            this.m_lnkAjouterSite.Name = "m_lnkAjouterSite";
            this.m_lnkAjouterSite.Size = new System.Drawing.Size(56, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterSite.TabIndex = 3;
            this.m_lnkAjouterSite.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterSite.LinkClicked += new System.EventHandler(this.m_lnkAjouterSite_LinkClicked);
            // 
            // m_listeSites
            // 
            this.m_listeSites.AllowDrop = true;
            this.m_listeSites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_listeSites.EnableCustomisation = true;
            this.m_listeSites.FullRowSelect = true;
            this.m_listeSites.HideSelection = false;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_listeSites, "");
            this.m_extLinkField.SetLinkField(this.m_listeSites, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_listeSites, "");
            this.m_listeSites.Location = new System.Drawing.Point(3, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeSites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeSites, "");
            this.m_listeSites.MultiSelect = false;
            this.m_listeSites.Name = "m_listeSites";
            this.m_listeSites.Size = new System.Drawing.Size(317, 167);
            this.m_extStyle.SetStyleBackColor(this.m_listeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeSites.TabIndex = 4;
            this.m_listeSites.UseCompatibleStateImageBehavior = false;
            this.m_listeSites.View = System.Windows.Forms.View.Details;
            this.m_listeSites.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_listeSites_DragDrop);
            this.m_listeSites.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListeSites_DragEnter);
            this.m_listeSites.DragOver += new System.Windows.Forms.DragEventHandler(this.ListeSites_DragOver);
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Site.Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 278;
            // 
            // m_panelSitesAuto
            // 
            this.m_panelSitesAuto.Controls.Add(this.m_cmbSelectProfilContrat);
            this.m_panelSitesAuto.Controls.Add(this.label13);
            this.m_panelSitesAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelSitesAuto, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_panelSitesAuto, "");
            this.m_extLinkField.SetLinkField(this.m_panelSitesAuto, "");
            this.m_panelSitesAuto.Location = new System.Drawing.Point(0, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSitesAuto, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSitesAuto, "");
            this.m_panelSitesAuto.Name = "m_panelSitesAuto";
            this.m_panelSitesAuto.Size = new System.Drawing.Size(794, 30);
            this.m_extStyle.SetStyleBackColor(this.m_panelSitesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSitesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSitesAuto.TabIndex = 7;
            // 
            // m_cmbSelectProfilContrat
            // 
            this.m_cmbSelectProfilContrat.ComportementLinkStd = true;
            this.m_cmbSelectProfilContrat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSelectProfilContrat.ElementSelectionne = null;
            this.m_cmbSelectProfilContrat.FormattingEnabled = true;
            this.m_cmbSelectProfilContrat.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbSelectProfilContrat, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_cmbSelectProfilContrat, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_cmbSelectProfilContrat, "");
            this.m_cmbSelectProfilContrat.LinkProperty = "";
            this.m_cmbSelectProfilContrat.ListDonnees = null;
            this.m_cmbSelectProfilContrat.Location = new System.Drawing.Point(166, 5);
            this.m_cmbSelectProfilContrat.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectProfilContrat, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelectProfilContrat, "");
            this.m_cmbSelectProfilContrat.Name = "m_cmbSelectProfilContrat";
            this.m_cmbSelectProfilContrat.NullAutorise = false;
            this.m_cmbSelectProfilContrat.ProprieteAffichee = null;
            this.m_cmbSelectProfilContrat.ProprieteParentListeObjets = null;
            this.m_cmbSelectProfilContrat.SelectionneurParent = null;
            this.m_cmbSelectProfilContrat.Size = new System.Drawing.Size(280, 23);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelectProfilContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelectProfilContrat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelectProfilContrat.TabIndex = 4005;
            this.m_cmbSelectProfilContrat.TextNull = "(empty)";
            this.m_cmbSelectProfilContrat.Tri = true;
            this.m_cmbSelectProfilContrat.TypeFormEdition = null;
            // 
            // label13
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_linkFieldListeOp.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(4, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(156, 23);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 0;
            this.label13.Text = "Profil to use||1139";
            // 
            // m_panelModeGestion
            // 
            this.m_panelModeGestion.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelModeGestion, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_panelModeGestion, "");
            this.m_extLinkField.SetLinkField(this.m_panelModeGestion, "");
            this.m_panelModeGestion.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelModeGestion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelModeGestion, "");
            this.m_panelModeGestion.Name = "m_panelModeGestion";
            this.m_panelModeGestion.Size = new System.Drawing.Size(794, 27);
            this.m_extStyle.SetStyleBackColor(this.m_panelModeGestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelModeGestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelModeGestion.TabIndex = 6;
            // 
            // m_pagePlanPrev
            // 
            this.m_pagePlanPrev.Controls.Add(this.m_panelListeOperations);
            this.m_pagePlanPrev.Controls.Add(this.m_listRelContrat_ListeOp);
            this.m_pagePlanPrev.Controls.Add(this.m_lnkSupprimerListeOp);
            this.m_pagePlanPrev.Controls.Add(this.m_lnkAjouterListeOp);
            this.m_pagePlanPrev.Controls.Add(this.m_txtSelectListeOp);
            this.m_pagePlanPrev.Controls.Add(this.label7);
            this.m_extLinkField.SetLinkField(this.m_pagePlanPrev, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_pagePlanPrev, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_pagePlanPrev, "");
            this.m_pagePlanPrev.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePlanPrev, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePlanPrev, "");
            this.m_pagePlanPrev.Name = "m_pagePlanPrev";
            this.m_pagePlanPrev.Selected = false;
            this.m_pagePlanPrev.Size = new System.Drawing.Size(794, 319);
            this.m_extStyle.SetStyleBackColor(this.m_pagePlanPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePlanPrev, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePlanPrev.TabIndex = 12;
            this.m_pagePlanPrev.Title = "Prevention Plan|1132";
            // 
            // m_panelListeOperations
            // 
            this.m_panelListeOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeOperations.Controls.Add(this.label10);
            this.m_panelListeOperations.Controls.Add(this.m_lnkPlanifier);
            this.m_panelListeOperations.Controls.Add(this.m_panelCouleur);
            this.m_panelListeOperations.Controls.Add(this.m_cmbPeriodicite);
            this.m_panelListeOperations.Controls.Add(this.m_tbnNbPeriode);
            this.m_panelListeOperations.Controls.Add(this.m_nbNbParPeriode);
            this.m_panelListeOperations.Controls.Add(this.m_ctrlDateDebut);
            this.m_panelListeOperations.Controls.Add(this.m_ctrlDateLimite);
            this.m_panelListeOperations.Controls.Add(this.m_listeSitesListeOperations);
            this.m_panelListeOperations.Controls.Add(this.m_lnkSupprimerSite2);
            this.m_panelListeOperations.Controls.Add(this.m_lnkAjouterSite2);
            this.m_panelListeOperations.Controls.Add(this.m_txtSelectTypeIntervention);
            this.m_panelListeOperations.Controls.Add(this.m_txtSelectSites2);
            this.m_panelListeOperations.Controls.Add(this.label12);
            this.m_panelListeOperations.Controls.Add(this.m_lblTypeIntervention);
            this.m_panelListeOperations.Controls.Add(this.m_lblDateStart);
            this.m_panelListeOperations.Controls.Add(this.m_lblDateLimite);
            this.m_panelListeOperations.Controls.Add(this.m_lblRecurrence);
            this.m_panelListeOperations.Controls.Add(this.label8);
            this.m_panelListeOperations.Controls.Add(this.m_lblPeriode);
            this.m_panelListeOperations.Controls.Add(this.m_lblCouleur);
            this.m_linkFieldListeOp.SetLinkField(this.m_panelListeOperations, "");
            this.m_extLinkField.SetLinkField(this.m_panelListeOperations, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelListeOperations, "");
            this.m_panelListeOperations.Location = new System.Drawing.Point(320, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelListeOperations, "");
            this.m_panelListeOperations.Name = "m_panelListeOperations";
            this.m_panelListeOperations.Size = new System.Drawing.Size(461, 299);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeOperations.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFieldTypeTicket.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_linkFieldListeOp.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(2, 117);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(459, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4015;
            this.label10.Text = "Leave the following list empty for all contract\'s site to be affected to the Oper" +
                "ation list|20228";
            // 
            // m_lnkPlanifier
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkPlanifier, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkPlanifier, "");
            this.m_extLinkField.SetLinkField(this.m_lnkPlanifier, "");
            this.m_lnkPlanifier.Location = new System.Drawing.Point(356, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPlanifier, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkPlanifier, "");
            this.m_lnkPlanifier.Name = "m_lnkPlanifier";
            this.m_lnkPlanifier.Size = new System.Drawing.Size(101, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPlanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPlanifier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPlanifier.TabIndex = 4005;
            this.m_lnkPlanifier.TabStop = true;
            this.m_lnkPlanifier.Text = "Planning...|1322";
            this.m_lnkPlanifier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPlanifier_LinkClicked);
            // 
            // m_panelCouleur
            // 
            this.m_panelCouleur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelCouleur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_panelCouleur, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelCouleur, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_panelCouleur, "");
            this.m_panelCouleur.Location = new System.Drawing.Point(356, 70);
            this.m_panelCouleur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCouleur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelCouleur, "");
            this.m_panelCouleur.Name = "m_panelCouleur";
            this.m_panelCouleur.Size = new System.Drawing.Size(32, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCouleur.TabIndex = 4004;
            this.m_panelCouleur.Click += new System.EventHandler(this.m_panelCouleur_Click);
            // 
            // m_cmbPeriodicite
            // 
            this.m_cmbPeriodicite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbPeriodicite.FormattingEnabled = true;
            this.m_cmbPeriodicite.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbPeriodicite, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_cmbPeriodicite, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_cmbPeriodicite, "");
            this.m_cmbPeriodicite.Location = new System.Drawing.Point(322, 24);
            this.m_cmbPeriodicite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbPeriodicite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbPeriodicite, "");
            this.m_cmbPeriodicite.Name = "m_cmbPeriodicite";
            this.m_cmbPeriodicite.Size = new System.Drawing.Size(111, 23);
            this.m_extStyle.SetStyleBackColor(this.m_cmbPeriodicite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbPeriodicite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbPeriodicite.TabIndex = 22;
            // 
            // m_tbnNbPeriode
            // 
            this.m_tbnNbPeriode.Arrondi = 0;
            this.m_tbnNbPeriode.DecimalAutorise = true;
            this.m_tbnNbPeriode.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_tbnNbPeriode, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_tbnNbPeriode, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_tbnNbPeriode, "");
            this.m_tbnNbPeriode.Location = new System.Drawing.Point(273, 24);
            this.m_tbnNbPeriode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tbnNbPeriode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_tbnNbPeriode, "");
            this.m_tbnNbPeriode.Name = "m_tbnNbPeriode";
            this.m_tbnNbPeriode.NullAutorise = false;
            this.m_tbnNbPeriode.SelectAllOnEnter = true;
            this.m_tbnNbPeriode.Size = new System.Drawing.Size(43, 23);
            this.m_extStyle.SetStyleBackColor(this.m_tbnNbPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tbnNbPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tbnNbPeriode.TabIndex = 21;
            this.m_tbnNbPeriode.Text = "0";
            this.m_tbnNbPeriode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_nbNbParPeriode
            // 
            this.m_nbNbParPeriode.Arrondi = 0;
            this.m_nbNbParPeriode.DecimalAutorise = true;
            this.m_nbNbParPeriode.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_nbNbParPeriode, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_nbNbParPeriode, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_nbNbParPeriode, "");
            this.m_nbNbParPeriode.Location = new System.Drawing.Point(142, 24);
            this.m_nbNbParPeriode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_nbNbParPeriode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_nbNbParPeriode, "");
            this.m_nbNbParPeriode.Name = "m_nbNbParPeriode";
            this.m_nbNbParPeriode.NullAutorise = false;
            this.m_nbNbParPeriode.SelectAllOnEnter = true;
            this.m_nbNbParPeriode.Size = new System.Drawing.Size(43, 23);
            this.m_extStyle.SetStyleBackColor(this.m_nbNbParPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_nbNbParPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_nbNbParPeriode.TabIndex = 21;
            this.m_nbNbParPeriode.Text = "0";
            this.m_nbNbParPeriode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // m_ctrlDateDebut
            // 
            this.m_ctrlDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_ctrlDateDebut, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_ctrlDateDebut, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_ctrlDateDebut, "");
            this.m_ctrlDateDebut.Location = new System.Drawing.Point(158, 48);
            this.m_ctrlDateDebut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlDateDebut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlDateDebut, "");
            this.m_ctrlDateDebut.Name = "m_ctrlDateDebut";
            this.m_ctrlDateDebut.Size = new System.Drawing.Size(98, 23);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlDateDebut.TabIndex = 20;
            this.m_ctrlDateDebut.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // m_ctrlDateLimite
            // 
            this.m_ctrlDateLimite.Checked = true;
            this.m_ctrlDateLimite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_ctrlDateLimite, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_ctrlDateLimite, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_ctrlDateLimite, "");
            this.m_ctrlDateLimite.Location = new System.Drawing.Point(142, 70);
            this.m_ctrlDateLimite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlDateLimite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlDateLimite, "");
            this.m_ctrlDateLimite.Name = "m_ctrlDateLimite";
            this.m_ctrlDateLimite.Size = new System.Drawing.Size(114, 20);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlDateLimite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlDateLimite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlDateLimite.TabIndex = 20;
            this.m_ctrlDateLimite.TextNull = "None";
            this.m_ctrlDateLimite.Value.DateTimeValue = new System.DateTime(2011, 3, 3, 11, 11, 20, 0);
            // 
            // m_listeSitesListeOperations
            // 
            this.m_listeSitesListeOperations.AllowDrop = true;
            this.m_listeSitesListeOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeSitesListeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn4});
            this.m_listeSitesListeOperations.EnableCustomisation = true;
            this.m_listeSitesListeOperations.FullRowSelect = true;
            this.m_listeSitesListeOperations.HideSelection = false;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_listeSitesListeOperations, "");
            this.m_extLinkField.SetLinkField(this.m_listeSitesListeOperations, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_listeSitesListeOperations, "");
            this.m_listeSitesListeOperations.Location = new System.Drawing.Point(7, 161);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeSitesListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeSitesListeOperations, "");
            this.m_listeSitesListeOperations.MultiSelect = false;
            this.m_listeSitesListeOperations.Name = "m_listeSitesListeOperations";
            this.m_listeSitesListeOperations.Size = new System.Drawing.Size(446, 114);
            this.m_extStyle.SetStyleBackColor(this.m_listeSitesListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeSitesListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeSitesListeOperations.TabIndex = 18;
            this.m_listeSitesListeOperations.UseCompatibleStateImageBehavior = false;
            this.m_listeSitesListeOperations.View = System.Windows.Forms.View.Details;
            this.m_listeSitesListeOperations.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_listeSitesListeOperations_DragDrop);
            this.m_listeSitesListeOperations.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListeSites_DragEnter);
            this.m_listeSitesListeOperations.DragOver += new System.Windows.Forms.DragEventHandler(this.ListeSites_DragOver);
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "Site.Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Label|50";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 278;
            // 
            // m_lnkSupprimerSite2
            // 
            this.m_lnkSupprimerSite2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerSite2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerSite2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkSupprimerSite2, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerSite2, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkSupprimerSite2, "");
            this.m_lnkSupprimerSite2.Location = new System.Drawing.Point(7, 276);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerSite2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerSite2, "");
            this.m_lnkSupprimerSite2.Name = "m_lnkSupprimerSite2";
            this.m_lnkSupprimerSite2.Size = new System.Drawing.Size(86, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerSite2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerSite2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerSite2.TabIndex = 17;
            this.m_lnkSupprimerSite2.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerSite2.LinkClicked += new System.EventHandler(this.m_lnkSupprimerSite2_LinkClicked);
            // 
            // m_lnkAjouterSite2
            // 
            this.m_lnkAjouterSite2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterSite2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkAjouterSite2, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterSite2, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkAjouterSite2, "");
            this.m_lnkAjouterSite2.Location = new System.Drawing.Point(397, 139);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterSite2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterSite2, "");
            this.m_lnkAjouterSite2.Name = "m_lnkAjouterSite2";
            this.m_lnkAjouterSite2.Size = new System.Drawing.Size(56, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterSite2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterSite2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterSite2.TabIndex = 16;
            this.m_lnkAjouterSite2.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterSite2.LinkClicked += new System.EventHandler(this.m_lnkAjouterSite2_LinkClicked);
            // 
            // m_txtSelectTypeIntervention
            // 
            this.m_txtSelectTypeIntervention.ElementSelectionne = null;
            this.m_txtSelectTypeIntervention.FonctionTextNull = null;
            this.m_txtSelectTypeIntervention.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeIntervention, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_txtSelectTypeIntervention, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_txtSelectTypeIntervention, "");
            this.m_txtSelectTypeIntervention.Location = new System.Drawing.Point(142, 93);
            this.m_txtSelectTypeIntervention.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeIntervention, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeIntervention, "");
            this.m_txtSelectTypeIntervention.Name = "m_txtSelectTypeIntervention";
            this.m_txtSelectTypeIntervention.SelectedObject = null;
            this.m_txtSelectTypeIntervention.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeIntervention.TabIndex = 15;
            this.m_txtSelectTypeIntervention.TextNull = "";
            // 
            // m_txtSelectSites2
            // 
            this.m_txtSelectSites2.ElementSelectionne = null;
            this.m_txtSelectSites2.FonctionTextNull = null;
            this.m_txtSelectSites2.HasLink = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_txtSelectSites2, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_txtSelectSites2, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectSites2, "");
            this.m_txtSelectSites2.Location = new System.Drawing.Point(142, 139);
            this.m_txtSelectSites2.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectSites2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectSites2, "");
            this.m_txtSelectSites2.Name = "m_txtSelectSites2";
            this.m_txtSelectSites2.SelectedObject = null;
            this.m_txtSelectSites2.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectSites2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectSites2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectSites2.TabIndex = 15;
            this.m_txtSelectSites2.TextNull = "";
            // 
            // label12
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_linkFieldListeOp.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(6, 142);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 18);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 14;
            this.label12.Text = "Select Site to add|1152";
            // 
            // m_lblTypeIntervention
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblTypeIntervention, "");
            this.m_extLinkField.SetLinkField(this.m_lblTypeIntervention, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblTypeIntervention, "");
            this.m_lblTypeIntervention.Location = new System.Drawing.Point(6, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeIntervention, "");
            this.m_lblTypeIntervention.Name = "m_lblTypeIntervention";
            this.m_lblTypeIntervention.Size = new System.Drawing.Size(138, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeIntervention.TabIndex = 3;
            this.m_lblTypeIntervention.Text = "Intervention Type|333";
            this.m_lblTypeIntervention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDateStart
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblDateStart, "");
            this.m_extLinkField.SetLinkField(this.m_lblDateStart, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblDateStart, "");
            this.m_lblDateStart.Location = new System.Drawing.Point(6, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateStart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateStart, "");
            this.m_lblDateStart.Name = "m_lblDateStart";
            this.m_lblDateStart.Size = new System.Drawing.Size(99, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateStart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateStart.TabIndex = 3;
            this.m_lblDateStart.Text = "Start Date|610";
            this.m_lblDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDateLimite
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblDateLimite, "");
            this.m_extLinkField.SetLinkField(this.m_lblDateLimite, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblDateLimite, "");
            this.m_lblDateLimite.Location = new System.Drawing.Point(6, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateLimite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateLimite, "");
            this.m_lblDateLimite.Name = "m_lblDateLimite";
            this.m_lblDateLimite.Size = new System.Drawing.Size(99, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateLimite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateLimite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateLimite.TabIndex = 3;
            this.m_lblDateLimite.Text = "Deadline|1149";
            this.m_lblDateLimite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblRecurrence
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblRecurrence, "");
            this.m_extLinkField.SetLinkField(this.m_lblRecurrence, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblRecurrence, "");
            this.m_lblRecurrence.Location = new System.Drawing.Point(6, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblRecurrence, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblRecurrence, "");
            this.m_lblRecurrence.Name = "m_lblRecurrence";
            this.m_lblRecurrence.Size = new System.Drawing.Size(99, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblRecurrence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblRecurrence, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRecurrence.TabIndex = 3;
            this.m_lblRecurrence.Text = "Recurrence|1148";
            this.m_lblRecurrence.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFieldTypeTicket.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_linkFieldListeOp.SetLinkField(this.label8, "ListeOperations.Libelle");
            this.label8.Location = new System.Drawing.Point(4, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(429, 16);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "[ListeOperations.Libelle]";
            // 
            // m_lblPeriode
            // 
            this.m_lblPeriode.AutoSize = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblPeriode, "");
            this.m_extLinkField.SetLinkField(this.m_lblPeriode, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblPeriode, "");
            this.m_lblPeriode.Location = new System.Drawing.Point(190, 27);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPeriode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPeriode, "");
            this.m_lblPeriode.Name = "m_lblPeriode";
            this.m_lblPeriode.Size = new System.Drawing.Size(62, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPeriode.TabIndex = 23;
            this.m_lblPeriode.Text = "every|1321";
            // 
            // m_lblCouleur
            // 
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lblCouleur, "");
            this.m_extLinkField.SetLinkField(this.m_lblCouleur, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_lblCouleur, "");
            this.m_lblCouleur.Location = new System.Drawing.Point(270, 69);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCouleur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblCouleur, "");
            this.m_lblCouleur.Name = "m_lblCouleur";
            this.m_lblCouleur.Size = new System.Drawing.Size(99, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCouleur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCouleur.TabIndex = 3;
            this.m_lblCouleur.Text = "Color|457";
            this.m_lblCouleur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_listRelContrat_ListeOp
            // 
            this.m_listRelContrat_ListeOp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listRelContrat_ListeOp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3});
            this.m_listRelContrat_ListeOp.EnableCustomisation = true;
            this.m_listRelContrat_ListeOp.FullRowSelect = true;
            this.m_listRelContrat_ListeOp.HideSelection = false;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_listRelContrat_ListeOp, "");
            this.m_extLinkField.SetLinkField(this.m_listRelContrat_ListeOp, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_listRelContrat_ListeOp, "");
            this.m_listRelContrat_ListeOp.Location = new System.Drawing.Point(14, 67);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listRelContrat_ListeOp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listRelContrat_ListeOp, "");
            this.m_listRelContrat_ListeOp.MultiSelect = false;
            this.m_listRelContrat_ListeOp.Name = "m_listRelContrat_ListeOp";
            this.m_listRelContrat_ListeOp.Size = new System.Drawing.Size(294, 214);
            this.m_extStyle.SetStyleBackColor(this.m_listRelContrat_ListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listRelContrat_ListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listRelContrat_ListeOp.TabIndex = 9;
            this.m_listRelContrat_ListeOp.UseCompatibleStateImageBehavior = false;
            this.m_listRelContrat_ListeOp.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "ListeOperations.Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 278;
            // 
            // m_lnkSupprimerListeOp
            // 
            this.m_lnkSupprimerListeOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerListeOp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerListeOp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkSupprimerListeOp, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerListeOp, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkSupprimerListeOp, "");
            this.m_lnkSupprimerListeOp.Location = new System.Drawing.Point(14, 287);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerListeOp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerListeOp, "");
            this.m_lnkSupprimerListeOp.Name = "m_lnkSupprimerListeOp";
            this.m_lnkSupprimerListeOp.Size = new System.Drawing.Size(86, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerListeOp.TabIndex = 8;
            this.m_lnkSupprimerListeOp.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerListeOp.LinkClicked += new System.EventHandler(this.m_lnkSupprimerListeOp_LinkClicked);
            // 
            // m_lnkAjouterListeOp
            // 
            this.m_lnkAjouterListeOp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterListeOp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkFieldListeOp.SetLinkField(this.m_lnkAjouterListeOp, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterListeOp, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_lnkAjouterListeOp, "");
            this.m_lnkAjouterListeOp.Location = new System.Drawing.Point(40, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterListeOp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterListeOp, "");
            this.m_lnkAjouterListeOp.Name = "m_lnkAjouterListeOp";
            this.m_lnkAjouterListeOp.Size = new System.Drawing.Size(56, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterListeOp.TabIndex = 7;
            this.m_lnkAjouterListeOp.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterListeOp.LinkClicked += new System.EventHandler(this.m_lnkAjouterListeOp_LinkClicked);
            // 
            // m_txtSelectListeOp
            // 
            this.m_txtSelectListeOp.ElementSelectionne = null;
            this.m_txtSelectListeOp.FonctionTextNull = null;
            this.m_txtSelectListeOp.HasLink = true;
            this.m_linkFieldTypeTicket.SetLinkField(this.m_txtSelectListeOp, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_txtSelectListeOp, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectListeOp, "");
            this.m_txtSelectListeOp.Location = new System.Drawing.Point(40, 23);
            this.m_txtSelectListeOp.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectListeOp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectListeOp, "");
            this.m_txtSelectListeOp.Name = "m_txtSelectListeOp";
            this.m_txtSelectListeOp.SelectedObject = null;
            this.m_txtSelectListeOp.Size = new System.Drawing.Size(268, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectListeOp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectListeOp.TabIndex = 6;
            this.m_txtSelectListeOp.TextNull = "";
            this.m_txtSelectListeOp.Load += new System.EventHandler(this.m_txtSelectListeOp_Load);
            // 
            // label7
            // 
            this.m_linkFieldListeOp.SetLinkField(this.label7, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(11, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 5;
            this.label7.Text = "Select Operations List to associate to  this Contract|1150";
            // 
            // m_pageFiche
            // 
            this.m_pageFiche.Controls.Add(this.m_panelFormulaire);
            this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_pageFiche, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_pageFiche, "");
            this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiche, "");
            this.m_pageFiche.Name = "m_pageFiche";
            this.m_pageFiche.Selected = false;
            this.m_pageFiche.Size = new System.Drawing.Size(794, 319);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiche.TabIndex = 11;
            this.m_pageFiche.Title = "Form|60";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaire, "");
            this.m_linkFieldListeOp.SetLinkField(this.m_panelFormulaire, "");
            this.m_linkFieldTypeTicket.SetLinkField(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(794, 319);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 0;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "ContratSite.Site.Libelle";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Label|50";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 430;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 428;
            // 
            // m_gestionnaireListeSites
            // 
            this.m_gestionnaireListeSites.ListeAssociee = this.m_listeSites;
            this.m_gestionnaireListeSites.ObjetEdite = null;
            // 
            // m_gestionnaireListeOperations
            // 
            this.m_gestionnaireListeOperations.ListeAssociee = this.m_listRelContrat_ListeOp;
            this.m_gestionnaireListeOperations.ObjetEdite = null;
            this.m_gestionnaireListeOperations.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireListeOperations_InitChamp);
            this.m_gestionnaireListeOperations.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireListeOperations_MAJ_Champs);
            // 
            // m_gestionnaireListeSites2
            // 
            this.m_gestionnaireListeSites2.ListeAssociee = this.m_listeSitesListeOperations;
            this.m_gestionnaireListeSites2.ObjetEdite = null;
            // 
            // m_gestionTypesTickets
            // 
            this.m_gestionTypesTickets.ListeAssociee = this.m_wndListeTypesTickets;
            this.m_gestionTypesTickets.ObjetEdite = null;
            this.m_gestionTypesTickets.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionTypesTickets_InitChamp);
            this.m_gestionTypesTickets.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionTypesTickets_MAJ_Champs);
            // 
            // m_gestionnaireListeSitesTypeTicket
            // 
            this.m_gestionnaireListeSitesTypeTicket.ObjetEdite = null;
            // 
            // CFormEditionContrat
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_linkFieldTypeTicket.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_linkFieldListeOp.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionContrat";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionContrat_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionContrat_OnMajChampsPage);
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
            this.m_pageTickets.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_pageSites.ResumeLayout(false);
            this.m_panelSitesManuels.ResumeLayout(false);
            this.m_panelSitesManuels.PerformLayout();
            this.m_panelSitesAuto.ResumeLayout(false);
            this.m_pagePlanPrev.ResumeLayout(false);
            this.m_panelListeOperations.ResumeLayout(false);
            this.m_panelListeOperations.PerformLayout();
            this.m_pageFiche.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		public CFormEditionContrat()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionContrat(CContrat contrat)
            : base(contrat)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionContrat(CContrat contrat, CListeObjetsDonnees liste)
            : base(contrat, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CContrat Contrat
		{
			get
			{
				return (CContrat)ObjetEdite;
			}
		}


		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Contract @1|1343", Contrat.Libelle));

            InitSelectClient();
            InitSelectTypeContrat();

            GestionDesOnglets();

			return result;
		}

        //-------------------------------------------------------------------------
        private void GestionDesOnglets()
        {
            if (Contrat.TypeContrat != null)
            {
                // Onglet maintenance Corrective
                if (Contrat.TypeContrat.GestionMaintenanceCorrective)
                {
                    if (!m_tabControl.TabPages.Contains(m_pageTickets))
                        m_tabControl.TabPages.Insert(1, m_pageTickets);
                }
                else
                {
                    if (m_tabControl.TabPages.Contains(m_pageTickets))
                        m_tabControl.TabPages.Remove(m_pageTickets);
                }
                // Onglet Maintenance Préventive
                if (Contrat.TypeContrat.GestionMaintenancePreventive)
                {
                    if (!m_tabControl.TabPages.Contains(m_pagePlanPrev))
                        m_tabControl.TabPages.Insert(2, m_pagePlanPrev);
                }
                else
                {
                    if (m_tabControl.TabPages.Contains(m_pagePlanPrev))
                        m_tabControl.TabPages.Remove(m_pagePlanPrev);
                }
                // Formulaire custom
                if (Contrat.TypeContrat.Formulaire != null)
                {
                    if (!m_tabControl.TabPages.Contains(m_pageFiche))
                        m_tabControl.TabPages.Add(m_pageFiche);
                }
                else
                {
                    if (m_tabControl.TabPages.Contains(m_pageFiche))
                        m_tabControl.TabPages.Remove(m_pageFiche);
                }
            }
        }
        

        //-------------------------------------------------------------------------
        private void InitPanelListeOperations()
        {
            m_panelListeOperations.Visible = false;

        }


		//-------------------------------------------------------------------------
		private void InitComboPeriodicite()
		{

			m_cmbPeriodicite.FillWithEnumALibelle(typeof(CEchelleTemps));
			m_cmbPeriodicite.SelectedValue = new CEchelleTemps(EEchelleTemps.Annee).CodeInt;
			CEchelleTemps obj = new CEchelleTemps((EEchelleTemps)m_cmbPeriodicite.SelectedValue);
		}
        
        //-------------------------------------------------------------------------
        private void InitPanelFormulaire()
        {
            if (Contrat.TypeContrat != null && Contrat.TypeContrat.Formulaire != null)
                m_panelFormulaire.InitPanel(Contrat.TypeContrat.Formulaire.Formulaire, Contrat);
            else
                m_panelFormulaire.InitPanel(null, null);
        }
        //-------------------------------------------------------------------------
        private void InitSelectTypeContrat()
        {
            m_cmbxSelectTypeContrat.Init(
                typeof(CTypeContrat),
                "Libelle",
                true);
            m_cmbxSelectTypeContrat.ElementSelectionne = Contrat.TypeContrat;
        }
        //-------------------------------------------------------------------------
        private void InitSelectClient()
        {
            CListeObjetsDonnees listeClients = new CListeObjetsDonnees(Contrat.ContexteDonnee, typeof(CDonneesActeurClient));

            m_cmbxSelectClient.Init(listeClients,"Acteur.Nom",true);

            m_cmbxSelectClient.ElementSelectionne = Contrat.Client;
        }
		//-------------------------------------------------------------------------
		private void InitSelectSites()
		{
			string strIds = "";
			foreach (CContrat_Site rel in Contrat.RelationsSites)
			{
				strIds += rel.Site.Id + ",";
			}
            CFiltreData filtre = null;
			if (strIds.Length != 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData(CSite.c_champId + " not in (" +
					strIds + ")");
			}
			m_txtSelectSites.InitAvecFiltreDeBase<CSite>(
				"Libelle",
				filtre,
				true);

		}
		private void InitSelectSites2(CContrat_ListeOperations contListeOp)
		{
			//On va laisser la possibilité de choisir dans les sites du contrats
			string strIds = "";
			string strIdsContrat = "";
			CFiltreData filtre = null;
			IList<CSite> siteDuContrat = Contrat.GetTousLesSitesDuContrat();
			m_txtSelectSites2.Enabled = (siteDuContrat.Count > 0);
			if (!m_txtSelectSites2.Enabled)
				return;
			else
			{
				foreach (CSite s in siteDuContrat)
					strIdsContrat += s.Id + ",";
				strIdsContrat = strIdsContrat.Substring(0, strIdsContrat.Length - 1);
				string strFiltre = "(" + CSite.c_champId + " in (" + strIdsContrat + "))";

				if (contListeOp.RelationsSites.Count > 0)
				{
					foreach (CContratListeOp_Site rel in contListeOp.RelationsSites)
						strIds += rel.Site.Id + ",";
					strIds = strIds.Substring(0, strIds.Length - 1);
					strFiltre += " and (" + CSite.c_champId + " not in (" + strIds + "))";
				}

				filtre = new CFiltreData(strFiltre);
			}

			m_txtSelectSites2.InitAvecFiltreDeBase<CSite>(
				"Libelle",
				filtre,
				true);

		}
		//-------------------------------------------------------------------------
		private void InitSelectListeOperations()
		{
			string strIds = "";
			foreach (CContrat_ListeOperations rel in Contrat.RelationsListesOperations)
			{
				strIds += rel.ListeOperations.Id + ",";
			}
			CFiltreData filtre = null;
			if (strIds.Length != 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData(CListeOperations.c_champId + " not in (" +
					strIds + ")");
			}
			m_txtSelectListeOp.InitAvecFiltreDeBase<CListeOperations>(
				"Libelle",
				filtre,
				true);

		}

        //-------------------------------------------------------------------------
        private void InitSelectListeTypeTickets()
        {
            string strIds = "";
            foreach (CTypeTicketContrat rel in Contrat.RelationsTypesTickets)
            {
                strIds += rel.TypeTicket.Id + ",";
            }
            CFiltreData filtre = null;
            if (strIds.Length != 0)
            {
                strIds = strIds.Substring(0, strIds.Length - 1);
                filtre = new CFiltreData(CTypeTicket.c_champId + " not in (" +
                    strIds + ")");
            }
            m_selectTypeTicket.InitAvecFiltreDeBase<CTypeTicket>(
                "Libelle",
                filtre,
                true);

        }


        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            Contrat.Client = (CDonneesActeurClient)m_cmbxSelectClient.ElementSelectionne;
            Contrat.TypeContrat = (CTypeContrat)m_cmbxSelectTypeContrat.ElementSelectionne;

			CResultAErreur result = base.MAJ_Champs();
            return result;
        }

        //-------------------------------------------------------------------------------
        private void m_cmbxSelectTypeContrat_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Contrat.TypeContrat = (CTypeContrat)m_cmbxSelectTypeContrat.ElementSelectionne;
            InitPageSitesContrat();
            InitPanelFormulaire();
            GestionDesOnglets();
        }



        //-------------------------------------------------------------------------
        private void m_lnkAjouterListeOp_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectListeOp.ElementSelectionne == null)
            {
                return;
            }

            CListeOperations listeOp = (CListeOperations)m_txtSelectListeOp.ElementSelectionne;

            CListeObjetsDonnees listeExistants = Contrat.RelationsListesOperations;
            listeExistants.Filtre = new CFiltreData(CListeOperations.c_champId + "=@1", listeOp.Id);
            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T( "Cannot add this Operations List|1151"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectListeOp.ElementSelectionne = null;
            CContrat_ListeOperations rel = new CContrat_ListeOperations(Contrat.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.Contrat = Contrat;
            rel.ListeOperations = listeOp;

            ListViewItem item = new ListViewItem();
            m_listRelContrat_ListeOp.Items.Add(item);
            m_listRelContrat_ListeOp.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_listRelContrat_ListeOp.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectListeOperations();

        }
        private void m_lnkSupprimerListeOp_LinkClicked(object sender, EventArgs e)
        {
            if (m_listRelContrat_ListeOp.SelectedItems.Count != 1)
                return;

            CContrat_ListeOperations rel = (CContrat_ListeOperations)m_listRelContrat_ListeOp.SelectedItems[0].Tag;

            m_gestionnaireListeOperations.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listRelContrat_ListeOp.SelectedItems.Count == 1)
            {
                if (m_listRelContrat_ListeOp.SelectedItems[0] != null)
                    m_listRelContrat_ListeOp.SelectedItems[0].Remove();
            }
            InitSelectListeOperations();

        }

		
		//-------------------------------------------------------------------------
		private void m_lnkAjouterSite_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectSites.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T("Select the Site to add|1137"), EFormAlerteType.Exclamation);
				return;
			}

			CSite site = (CSite)m_txtSelectSites.ElementSelectionne;
            AjouterSiteAuContrat ( site, false );
        }

        private void AjouterSiteAuContrat ( CSite site, bool bModeSilencieux )
        {
			CListeObjetsDonnees listeExistants = Contrat.RelationsSites;
			listeExistants.Filtre = new CFiltreData(CSite.c_champId + "=@1", site.Id);
			if (listeExistants.Count != 0)
			{
                if ( !bModeSilencieux )
				    CFormAlerte.Afficher(I.T("Cannot add this Site|1138"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectSites.ElementSelectionne = null;
			CContrat_Site rel = new CContrat_Site(Contrat.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.Contrat = Contrat;
			rel.Site = site;

			ListViewItem item = new ListViewItem();
			m_listeSites.Items.Add(item);
			m_listeSites.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_listeSites.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectSites();
		}

		private void m_lnkSupprimerSite_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeSites.SelectedItems.Count != 1)
				return;

			CContrat_Site rel = (CContrat_Site)m_listeSites.SelectedItems[0].Tag;

			m_gestionnaireListeSites.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_listeSites.SelectedItems.Count == 1)
			{
				if (m_listeSites.SelectedItems[0] != null)
					m_listeSites.SelectedItems[0].Remove();
			}
			InitSelectSites();
            m_editeurPeriodesTicket.Init(null);
		}



        //-------------------------------------------------------------------------
		private void m_lnkAjouterSite2_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectSites2.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T("Select the Site to add|1137"), EFormAlerteType.Exclamation);
				return;
			}

			CSite site = (CSite)m_txtSelectSites2.ElementSelectionne;

            AjouterSiteAListeOp ( site, false );
        }

        private void AjouterSiteAListeOp ( CSite site, bool bModeSilencieux )
        {
			CContrat_ListeOperations cont_ListOp = (CContrat_ListeOperations)m_gestionnaireListeOperations.ObjetEnCours;
			if (cont_ListOp == null)
				return;

			CListeObjetsDonnees listeExistants = cont_ListOp.RelationsSites;
			listeExistants.Filtre = new CFiltreData(CSite.c_champId + "=@1", site.Id);
            bool bImpossible = listeExistants.Count != 0;
            if (!bImpossible)
            {
                CListeObjetsDonnees lst = Contrat.RelationsSites;
                lst.Filtre = new CFiltreData(CSite.c_champId + "=@1", site.Id);
                if (lst.Count != 0)
                    bImpossible = true;
            }
			if (bImpossible)
			{
                if ( !bModeSilencieux )
                {
    				CFormAlerte.Afficher(I.T("Cannot add this Site|1138"), EFormAlerteType.Erreur);
                }
				return;
			}
			m_txtSelectSites2.ElementSelectionne = null;
			CContratListeOp_Site rel = new CContratListeOp_Site(cont_ListOp.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.ContratListeOp = cont_ListOp;
			rel.Site = site;

			ListViewItem item = new ListViewItem();
			m_listeSitesListeOperations.Items.Add(item);
			m_listeSitesListeOperations.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_listeSitesListeOperations.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectSites2(cont_ListOp);

		}
		private void m_lnkSupprimerSite2_LinkClicked(object sender, EventArgs e)
		{
			if (m_listeSitesListeOperations.SelectedItems.Count != 1)
				return;

			CContrat_ListeOperations cont_ListOp = (CContrat_ListeOperations)m_gestionnaireListeOperations.ObjetEnCours;
			if (cont_ListOp == null)
				return;

			CContratListeOp_Site rel = (CContratListeOp_Site)m_listeSitesListeOperations.SelectedItems[0].Tag;

			m_gestionnaireListeSites2.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_listeSitesListeOperations.SelectedItems.Count == 1)
			{
				if (m_listeSitesListeOperations.SelectedItems[0] != null)
					m_listeSitesListeOperations.SelectedItems[0].Remove();
			}
			InitSelectSites2(cont_ListOp);

		}




		//-------------------------------------------------------------------------
		private void m_gestionnaireListeOperations_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
				m_panelListeOperations.Visible = false;
			else
			{
				m_panelListeOperations.Visible = true;
				CContrat_ListeOperations rel = (CContrat_ListeOperations)args.Objet;
				m_ctrlDateLimite.Value = rel.DateLimite;
				m_ctrlDateDebut.Value = rel.DateDebut;
				m_cmbPeriodicite.SelectedValue = rel.PeriodiciteOperationCode;
				m_nbNbParPeriode.IntValue = rel.NombreParPeriode;
				m_tbnNbPeriode.IntValue = rel.NombrePeriodes;
				m_panelCouleur.BackColor = Color.FromArgb(rel.Couleur);
				m_txtSelectTypeIntervention.ElementSelectionne = rel.TypeIntervention;
				args.Result = m_linkFieldListeOp.FillDialogFromObjet(args.Objet);
				InitSelectSites2(rel);
				m_gestionnaireListeSites2.ObjetEdite = rel.RelationsSites;
			}

		}
		private void m_gestionnaireListeOperations_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
				return;
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				CContrat_ListeOperations rel = (CContrat_ListeOperations)args.Objet;
				rel.TypeIntervention = (CTypeIntervention)m_txtSelectTypeIntervention.ElementSelectionne;
				rel.DateDebut = m_ctrlDateDebut.Value;
				rel.DateLimite = m_ctrlDateLimite.Value;
				rel.NombrePeriodes = (int)m_tbnNbPeriode.IntValue;
				rel.NombreParPeriode = (int)m_nbNbParPeriode.IntValue;
				rel.Couleur = m_panelCouleur.BackColor.ToArgb();
				rel.PeriodiciteOperation = (EEchelleTemps)m_cmbPeriodicite.SelectedValue;
				args.Result = m_linkFieldListeOp.FillObjetFromDialog(args.Objet);

				args.Result = m_gestionnaireListeSites2.ValideModifs();
			}

		}


		//----------------------------- TAB CONTROL -------------------------------
		private CResultAErreur CFormEditionContrat_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageFiche)
				{
					InitPanelFormulaire();

				}
				else if (page == m_pagePlanPrev)
				{
					InitComboPeriodicite();
				
					InitSelectListeOperations();

					InitPanelListeOperations();


				m_txtSelectTypeIntervention.Init<CTypeIntervention>(
						"Libelle",
						false);

					m_gestionnaireListeOperations.ObjetEdite = Contrat.RelationsListesOperations;
         

				}
				else if (page == m_pageSites)
				{
                    InitPageSitesContrat();
					
				}

				else if (page == m_pageTickets)
				{
                    InitSelectListeTypeTickets();
                    m_gestionTypesTickets.ObjetEdite = Contrat.RelationsTypesTickets;
                    m_editeurPeriodesTicket.Init(null);
				}
			}
			return result;
		}
		private CResultAErreur CFormEditionContrat_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

			if (page == m_pageFiche)
			{
				result = m_panelFormulaire.AffecteValeursToElement();
			}
			else if (page == m_pagePlanPrev)
			{
				result = m_gestionnaireListeOperations.ValideModifs();
				//m_tbnNbPeriode.IntValue;
			}
			else if (page == m_pageSites)
			{
				result = m_gestionnaireListeSites.ValideModifs();
                Contrat.ProfilSite = m_cmbSelectProfilContrat.ElementSelectionne as CProfilElement;
			}
			else if (page == m_pageTickets)
			{
                m_gestionTypesTickets.ValideModifs();
                if (!m_editeurPeriodesTicket.MajChamps())
                {
                    result.EmpileErreur(I.T("Errors in ticket/site periods|20238"));
                }

			}
			return result;
		}

        //--------------------------------------------------------------------------------
        private void InitPageSitesContrat()
        {
            m_gestionnaireListeSites.ObjetEdite = Contrat.RelationsSites;
            InitSelectSites();
            
            CListeObjetsDonnees lst = new CListeObjetsDonnees ( Contrat.ContexteDonnee,
                typeof(CProfilElement),
                new CFiltreData ( CProfilElement.c_champTypeSource+"=@1 and "+
                    CProfilElement.c_champTypeElements+"=@2",
                    typeof(CContrat).ToString(),
                    typeof(CSite).ToString()) );

            m_cmbSelectProfilContrat.Init(lst, "Libelle", false);
            m_cmbSelectProfilContrat.ElementSelectionne = Contrat.ProfilSite;
            // Visibilité des panels
            m_panelSitesManuels.Visible = Contrat.TypeContrat == null? false: Contrat.TypeContrat.GestionSitesManuel;
            m_panelSitesAuto.Visible = Contrat.TypeContrat == null ? true : !Contrat.TypeContrat.GestionSitesManuel;
        }

        //--------------------------------------------------------------------------------
        private void m_panelCouleur_Click(object sender, EventArgs e)
		{
			// Ouvre le control de selection des couleur Windows
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				ColorDialog colDlg = new ColorDialog();

				colDlg.Color = m_panelCouleur.BackColor;
				colDlg.ShowDialog();
				m_panelCouleur.BackColor = colDlg.Color;
			}
		}

        //--------------------------------------------------------------------------------
        private void m_lnkPlanifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormEditionPreventive frm = new CFormEditionPreventive(Contrat, (CContrat_ListeOperations)m_gestionnaireListeOperations.ObjetEnCours);
			CTimosApp.Navigateur.AffichePage(frm);
		}


        //--------------------------------------------------------------------------------
        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------
        private void m_txtSelectListeOp_Load(object sender, EventArgs e)
        {

        }

        //--------------------------------------------------------------------------------
        private void m_wndAddTypeTicket_LinkClicked(object sender, EventArgs e)
        {
            if (m_selectTypeTicket.ElementSelectionne == null)
            {
                return;
            }

            CTypeTicket typeTicket = (CTypeTicket)m_selectTypeTicket.ElementSelectionne;

            CListeObjetsDonnees listeExistants = Contrat.RelationsTypesTickets;
            listeExistants.Filtre = new CFiltreData(CTypeTicket.c_champId + "=@1", typeTicket.Id);
            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T("Cannot add this Ticket type|20216"), EFormAlerteType.Erreur);
                return;
            }
            m_selectTypeTicket.ElementSelectionne = null;
            CTypeTicketContrat rel = new CTypeTicketContrat(Contrat.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.Contrat = Contrat;
            rel.TypeTicket= typeTicket;

            ListViewItem item = new ListViewItem();
            m_wndListeTypesTickets.Items.Add(item);
            m_wndListeTypesTickets.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_wndListeTypesTickets.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectListeTypeTickets();
        }

        private void m_gestionTypesTickets_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            
        }

        private void m_gestionTypesTickets_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            
        }

        

        private bool HasSitesInDragDropData(IDataObject data)
        {
            if (data == null)
                return false;
            CReferenceObjetDonnee[] references = data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (references != null && references.FirstOrDefault(r => r.TypeObjet == typeof(CSite)) != null)
                return true;
            else
                return false;
        }


        //--------------------------------------------------------------------------------
        private void ListeSites_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = HasSitesInDragDropData(e.Data) ? DragDropEffects.Link : DragDropEffects.None;
        }

        //--------------------------------------------------------------------------------
        private void ListeSites_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = HasSitesInDragDropData(e.Data) ? DragDropEffects.Link : DragDropEffects.None;
        }

        

        //--------------------------------------------------------------------------------
        private void m_listeSites_DragDrop(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] references = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            bool bAdded = false;
            if ( references != null )
            {
                foreach ( CReferenceObjetDonnee reference in 
                    from r in references where 
                        r.TypeObjet == typeof(CSite) 
                        select r )
                {
                    CSite site = reference.GetObjet(Contrat.ContexteDonnee) as CSite;
                    if (site != null)
                    {
                        AjouterSiteAuContrat(site, true);
                        bAdded = true;
                    }
                }
            }
            e.Effect = bAdded ? DragDropEffects.Link : DragDropEffects.None;
        }

        //--------------------------------------------------------------------------------
        private void m_listeSitesListeOperations_DragDrop(object sender, DragEventArgs e)
        {
            CReferenceObjetDonnee[] references = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            bool bAdded = false;
            if ( references != null )
            {
                foreach ( CReferenceObjetDonnee reference in 
                    from r in references where 
                        r.TypeObjet == typeof(CSite) 
                        select r )
                {
                    CSite site = reference.GetObjet(Contrat.ContexteDonnee) as CSite;
                    if (site != null)
                    {
                        AjouterSiteAListeOp(site, true);
                        bAdded = true;
                    }
                }
            }
            e.Effect = bAdded ? DragDropEffects.Link : DragDropEffects.None;
        }


        //------------------------------------------------------------------------
        private void m_lnkUpdateTablePeriodesTicket_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ( m_editeurPeriodesTicket.MajChamps() )
                m_editeurPeriodesTicket.Init(Contrat);
        }

        //------------------------------------------------------------------------
        private void m_wndRemoveTypeTicket_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeTypesTickets.SelectedItems.Count != 1)
                return;

            CTypeTicketContrat rel = (CTypeTicketContrat)m_wndListeTypesTickets.SelectedItems[0].Tag;

            m_gestionnaireListeSites.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_wndListeTypesTickets.SelectedItems.Count == 1)
            {
                if (m_wndListeTypesTickets.SelectedItems[0] != null)
                    m_wndListeTypesTickets.SelectedItems[0].Remove();
            }
            InitSelectListeTypeTickets();
            m_editeurPeriodesTicket.Init(null);

        }

    }
}

