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
using sc2i.win32.data.dynamic;

using timos.data;
using timos.securite;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSite), "BASE")]
	public class CFormEditionSite : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panelEntete;
        private Label m_label2;
        private CComboBoxLinkListeObjetsDonnees m_cmbxTypeSite;
        private C2iTabControl m_TabControl;
        private Label m_label3;
        private CArbreObjetHierarchique m_ArbreSitesHierarchique;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_PanelChamps;
        private Crownwood.Magic.Controls.TabPage m_pageSitesFille;
        private CPanelListeSpeedStandard m_PanelSitesFils;
        private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
        private Label m_label6;
        private C2iTextBox m_txtCode;
		private Crownwood.Magic.Controls.TabPage m_pageEO;
		private CPanelAffectationEO m_panelEOS;
		private Crownwood.Magic.Controls.TabPage m_pageEquipements;
		private CPanelListeSpeedStandard m_panelEquipements;
        private Crownwood.Magic.Controls.TabPage m_pageContraintes;
        private CPanelListeSpeedStandard m_panelListeContraintes;
        private Crownwood.Magic.Controls.TabPage m_pageRessources;
        private CPanelListeSpeedStandard m_panelListeRessourcesDetenues;
		private Crownwood.Magic.Controls.TabPage m_pageSystemeCoor;
		private Panel m_panelCoordonnee;
		private timos.coordonnees.CControlEditeCoordonnee m_editCoordonnee;
		private Label label2;
		private CControleEditeObjetASystemeCoordonnee m_panelEditSystemeCoordonnee;
		private CControleEditionOptionsControleCoordonnees m_panelOptionsCoordonnees;
		private LinkLabel m_lnkPlanifierUneIntervention;
		private sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique m_cmbEOsCoor;
		private Label label3;
		private Panel m_panEOCoor;
		private Crownwood.Magic.Controls.TabPage m_pageInterventions;
		private CPanelListeSpeedStandard m_wndListeInterventions;
		private Crownwood.Magic.Controls.TabPage m_pageTablesParametrables;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private CPanelListeSpeedStandard m_panListeTableParametrables;
		private CReducteurControle m_reducteurEntete;
        private C2iPanelFondDegradeStd c2iPanelFondDegradeStd1;
		private Crownwood.Magic.Controls.TabPage m_pageFunctions;
		private CPanelListeSpeedStandard m_panelListeFonctions;
        private Crownwood.Magic.Controls.TabPage m_pageSymbole;
        private CPanelSymboleElement m_panelSymbole;
        private Crownwood.Magic.Controls.TabPage m_pageLiens;
        private CPanelListeSpeedStandard m_panelListeLiens;
        private Splitter splitter1;
        private Panel m_panelExtremites;
        private Label label4;
        private C2iTextBox m_txtBoxExtremite;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionExtremites;
        private CWndLinkStd m_lnkAjouterExtremite;
        private ListViewAutoFilled m_wndListeExtremites;
        private ListViewAutoFilledColumn listViewAutoFilledColumn4;
        private C2iPanel m_panelEditExtremite;
        private Label label5;
        private C2iTextBox m_txtEditeNomExtremite;
        private CWndLinkStd m_lnkSupprimerExtremite;
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
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionSite));
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn10 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn11 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn12 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelEntete = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.m_label2 = new System.Windows.Forms.Label();
            this.m_label6 = new System.Windows.Forms.Label();
            this.m_cmbxTypeSite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_panelCoordonnee = new System.Windows.Forms.Panel();
            this.m_editCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.label2 = new System.Windows.Forms.Label();
            this.m_ArbreSitesHierarchique = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.m_label3 = new System.Windows.Forms.Label();
            this.m_lnkPlanifierUneIntervention = new System.Windows.Forms.LinkLabel();
            this.m_cmbEOsCoor = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageSitesFille = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelSitesFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageEO = new Crownwood.Magic.Controls.TabPage();
            this.m_panEOCoor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageEquipements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageFunctions = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeFonctions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeContraintes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageRessources = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeRessourcesDetenues = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageInterventions = new Crownwood.Magic.Controls.TabPage();
            this.c2iPanelFondDegradeStd1 = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_wndListeInterventions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageSystemeCoor = new Crownwood.Magic.Controls.TabPage();
            this.m_panelOptionsCoordonnees = new timos.CControleEditionOptionsControleCoordonnees();
            this.m_panelEditSystemeCoordonnee = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_pageTablesParametrables = new Crownwood.Magic.Controls.TabPage();
            this.m_panListeTableParametrables = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageSymbole = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.m_pageLiens = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeLiens = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelExtremites = new System.Windows.Forms.Panel();
            this.m_panelEditExtremite = new sc2i.win32.common.C2iPanel(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtEditeNomExtremite = new sc2i.win32.common.C2iTextBox();
            this.m_lnkSupprimerExtremite = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeExtremites = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkAjouterExtremite = new sc2i.win32.common.CWndLinkStd();
            this.m_txtBoxExtremite = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_reducteurEntete = new sc2i.win32.common.CReducteurControle();
            this.m_gestionnaireEditionExtremites = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelEntete.SuspendLayout();
            this.m_panelCoordonnee.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageChampsCustom.SuspendLayout();
            this.m_pageSitesFille.SuspendLayout();
            this.m_pageEO.SuspendLayout();
            this.m_panEOCoor.SuspendLayout();
            this.m_pageEquipements.SuspendLayout();
            this.m_pageFunctions.SuspendLayout();
            this.m_pageContraintes.SuspendLayout();
            this.m_pageRessources.SuspendLayout();
            this.m_pageInterventions.SuspendLayout();
            this.c2iPanelFondDegradeStd1.SuspendLayout();
            this.m_pageSystemeCoor.SuspendLayout();
            this.m_pageTablesParametrables.SuspendLayout();
            this.m_pageSymbole.SuspendLayout();
            this.m_pageLiens.SuspendLayout();
            this.m_panelExtremites.SuspendLayout();
            this.m_panelEditExtremite.SuspendLayout();
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
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "timos.data.CSite";
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(603, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(516, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(756, 28);
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
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Site type label:|170";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(98, 5);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(330, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panelEntete
            // 
            this.m_panelEntete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEntete.Controls.Add(this.m_txtCode);
            this.m_panelEntete.Controls.Add(this.m_label2);
            this.m_panelEntete.Controls.Add(this.m_label6);
            this.m_panelEntete.Controls.Add(this.m_cmbxTypeSite);
            this.m_panelEntete.Controls.Add(this.m_panelCoordonnee);
            this.m_panelEntete.Controls.Add(this.m_ArbreSitesHierarchique);
            this.m_panelEntete.Controls.Add(this.m_label3);
            this.m_panelEntete.Controls.Add(this.m_txtLibelle);
            this.m_panelEntete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEntete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEntete, false);
            this.m_panelEntete.Location = new System.Drawing.Point(12, 43);
            this.m_panelEntete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEntete, "");
            this.m_panelEntete.Name = "m_panelEntete";
            this.m_panelEntete.Size = new System.Drawing.Size(744, 125);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntete.TabIndex = 0;
            // 
            // m_txtCode
            // 
            this.m_extLinkField.SetLinkField(this.m_txtCode, "Code");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtCode, true);
            this.m_txtCode.Location = new System.Drawing.Point(98, 50);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(330, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 2;
            this.m_txtCode.Text = "[Code]";
            // 
            // m_label2
            // 
            this.m_label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_label2, false);
            this.m_label2.Location = new System.Drawing.Point(10, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_label2, "");
            this.m_label2.Name = "m_label2";
            this.m_label2.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.m_label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_label2.TabIndex = 4005;
            this.m_label2.Text = "Site  label : |174";
            // 
            // m_label6
            // 
            this.m_extLinkField.SetLinkField(this.m_label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_label6, false);
            this.m_label6.Location = new System.Drawing.Point(10, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_label6, "");
            this.m_label6.Name = "m_label6";
            this.m_label6.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.m_label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_label6.TabIndex = 4011;
            this.m_label6.Text = "Site code|239";
            // 
            // m_cmbxTypeSite
            // 
            this.m_cmbxTypeSite.ComportementLinkStd = true;
            this.m_cmbxTypeSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeSite.ElementSelectionne = null;
            this.m_cmbxTypeSite.FormattingEnabled = true;
            this.m_cmbxTypeSite.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeSite, "TypeSite");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxTypeSite, false);
            this.m_cmbxTypeSite.LinkProperty = "";
            this.m_cmbxTypeSite.ListDonnees = null;
            this.m_cmbxTypeSite.Location = new System.Drawing.Point(98, 26);
            this.m_cmbxTypeSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeSite, "");
            this.m_cmbxTypeSite.Name = "m_cmbxTypeSite";
            this.m_cmbxTypeSite.NullAutorise = false;
            this.m_cmbxTypeSite.ProprieteAffichee = null;
            this.m_cmbxTypeSite.ProprieteParentListeObjets = null;
            this.m_cmbxTypeSite.SelectionneurParent = null;
            this.m_cmbxTypeSite.Size = new System.Drawing.Size(330, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeSite.TabIndex = 1;
            this.m_cmbxTypeSite.TextNull = "(empty)";
            this.m_cmbxTypeSite.Tri = true;
            this.m_cmbxTypeSite.TypeFormEdition = null;
            this.m_cmbxTypeSite.SelectionChangeCommitted += new System.EventHandler(this.m_cmbxTypeSite_SelectionChangeCommitted);
            // 
            // m_panelCoordonnee
            // 
            this.m_panelCoordonnee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelCoordonnee.Controls.Add(this.m_editCoordonnee);
            this.m_panelCoordonnee.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_panelCoordonnee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCoordonnee, false);
            this.m_panelCoordonnee.Location = new System.Drawing.Point(13, 76);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCoordonnee, "ASYS_COOR");
            this.m_panelCoordonnee.Name = "m_panelCoordonnee";
            this.m_panelCoordonnee.Size = new System.Drawing.Size(415, 33);
            this.m_extStyle.SetStyleBackColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCoordonnee.TabIndex = 4013;
            // 
            // m_editCoordonnee
            // 
            this.m_editCoordonnee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_editCoordonnee.Coordonnee = "";
            this.m_extLinkField.SetLinkField(this.m_editCoordonnee, "Coordonnee");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_editCoordonnee, false);
            this.m_editCoordonnee.Location = new System.Drawing.Point(85, 2);
            this.m_editCoordonnee.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editCoordonnee, "");
            this.m_editCoordonnee.Name = "m_editCoordonnee";
            this.m_editCoordonnee.Size = new System.Drawing.Size(321, 24);
            this.m_extStyle.SetStyleBackColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editCoordonnee.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(-2, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.label2.TabIndex = 4006;
            this.label2.Text = "Coordinate|446";
            // 
            // m_ArbreSitesHierarchique
            // 
            this.m_ArbreSitesHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ArbreSitesHierarchique.AutoriseReaffectation = true;
            this.m_ArbreSitesHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_ArbreSitesHierarchique, "SiteParent");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ArbreSitesHierarchique, false);
            this.m_ArbreSitesHierarchique.Location = new System.Drawing.Point(434, 5);
            this.m_ArbreSitesHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreSitesHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ArbreSitesHierarchique, "");
            this.m_ArbreSitesHierarchique.Name = "m_ArbreSitesHierarchique";
            this.m_ArbreSitesHierarchique.Size = new System.Drawing.Size(283, 96);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreSitesHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreSitesHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreSitesHierarchique.TabIndex = 4007;
            this.m_ArbreSitesHierarchique.OnChangeObjetParent += new System.EventHandler(this.m_ArbreSitesHierarchique_OnChangeObjetParent);
            // 
            // m_label3
            // 
            this.m_extLinkField.SetLinkField(this.m_label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_label3, false);
            this.m_label3.Location = new System.Drawing.Point(10, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_label3, "");
            this.m_label3.Name = "m_label3";
            this.m_label3.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.m_label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_label3.TabIndex = 10;
            this.m_label3.Text = "Site type :|172";
            // 
            // m_lnkPlanifierUneIntervention
            // 
            this.m_lnkPlanifierUneIntervention.AutoSize = true;
            this.m_lnkPlanifierUneIntervention.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkPlanifierUneIntervention.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_extLinkField.SetLinkField(this.m_lnkPlanifierUneIntervention, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkPlanifierUneIntervention, false);
            this.m_lnkPlanifierUneIntervention.Location = new System.Drawing.Point(5, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPlanifierUneIntervention, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPlanifierUneIntervention, "");
            this.m_lnkPlanifierUneIntervention.Name = "m_lnkPlanifierUneIntervention";
            this.m_lnkPlanifierUneIntervention.Size = new System.Drawing.Size(90, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPlanifierUneIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPlanifierUneIntervention, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPlanifierUneIntervention.TabIndex = 4014;
            this.m_lnkPlanifierUneIntervention.TabStop = true;
            this.m_lnkPlanifierUneIntervention.Text = "Planning grid|744";
            this.m_lnkPlanifierUneIntervention.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPlanifierUneIntervention_LinkClicked);
            // 
            // m_cmbEOsCoor
            // 
            this.m_cmbEOsCoor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbEOsCoor.AutoriserFilsDeAutorises = true;
            this.m_cmbEOsCoor.BackColor = System.Drawing.Color.White;
            this.m_cmbEOsCoor.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_cmbEOsCoor, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbEOsCoor, false);
            this.m_cmbEOsCoor.Location = new System.Drawing.Point(188, 3);
            this.m_cmbEOsCoor.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEOsCoor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbEOsCoor, "");
            this.m_cmbEOsCoor.Name = "m_cmbEOsCoor";
            this.m_cmbEOsCoor.NullAutorise = false;
            this.m_cmbEOsCoor.Size = new System.Drawing.Size(254, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEOsCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEOsCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEOsCoor.TabIndex = 4016;
            this.m_cmbEOsCoor.TextNull = "[None]";
            this.m_cmbEOsCoor.ElementSelectionneChanged += new System.EventHandler(this.m_cmbEOsCoor_ElementSelectionneChanged);
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(12, 174);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 9;
            this.m_TabControl.SelectedTab = this.m_pageTablesParametrables;
            this.m_TabControl.Size = new System.Drawing.Size(744, 324);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageChampsCustom,
            this.m_pageSitesFille,
            this.m_pageEO,
            this.m_pageEquipements,
            this.m_pageFunctions,
            this.m_pageContraintes,
            this.m_pageRessources,
            this.m_pageInterventions,
            this.m_pageSystemeCoor,
            this.m_pageTablesParametrables,
            this.m_pageSymbole,
            this.m_pageLiens});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageChampsCustom
            // 
            this.m_pageChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_pageChampsCustom.Controls.Add(this.m_PanelChamps);
            this.m_pageChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChampsCustom, false);
            this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChampsCustom, "");
            this.m_pageChampsCustom.Name = "m_pageChampsCustom";
            this.m_pageChampsCustom.Selected = false;
            this.m_pageChampsCustom.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChampsCustom.TabIndex = 11;
            this.m_pageChampsCustom.Title = "Form|60";
            // 
            // m_PanelChamps
            // 
            this.m_PanelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChamps.BoldSelectedPage = true;
            this.m_PanelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelChamps.ElementEdite = null;
            this.m_PanelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelChamps, false);
            this.m_PanelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 0;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSitesFille
            // 
            this.m_pageSitesFille.Controls.Add(this.m_PanelSitesFils);
            this.m_extLinkField.SetLinkField(this.m_pageSitesFille, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSitesFille, false);
            this.m_pageSitesFille.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSitesFille, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSitesFille, "");
            this.m_pageSitesFille.Name = "m_pageSitesFille";
            this.m_pageSitesFille.Selected = false;
            this.m_pageSitesFille.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageSitesFille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSitesFille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSitesFille.TabIndex = 10;
            this.m_pageSitesFille.Title = "Child sites|180";
            // 
            // m_PanelSitesFils
            // 
            this.m_PanelSitesFils.AllowArbre = true;
            this.m_PanelSitesFils.AllowCustomisation = true;
            this.m_PanelSitesFils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
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
            glColumn2.Width = 300;
            this.m_PanelSitesFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_PanelSitesFils.ContexteUtilisation = "";
            this.m_PanelSitesFils.ControlFiltreStandard = null;
            this.m_PanelSitesFils.ElementSelectionne = null;
            this.m_PanelSitesFils.EnableCustomisation = true;
            this.m_PanelSitesFils.FiltreDeBase = null;
            this.m_PanelSitesFils.FiltreDeBaseEnAjout = false;
            this.m_PanelSitesFils.FiltrePrefere = null;
            this.m_PanelSitesFils.FiltreRapide = null;
            this.m_PanelSitesFils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelSitesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelSitesFils, false);
            this.m_PanelSitesFils.ListeObjets = null;
            this.m_PanelSitesFils.Location = new System.Drawing.Point(3, 3);
            this.m_PanelSitesFils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelSitesFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelSitesFils.ModeQuickSearch = false;
            this.m_PanelSitesFils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_PanelSitesFils, "");
            this.m_PanelSitesFils.MultiSelect = false;
            this.m_PanelSitesFils.Name = "m_PanelSitesFils";
            this.m_PanelSitesFils.Navigateur = null;
            this.m_PanelSitesFils.ProprieteObjetAEditer = null;
            this.m_PanelSitesFils.QuickSearchText = "";
            this.m_PanelSitesFils.Size = new System.Drawing.Size(722, 277);
            this.m_extStyle.SetStyleBackColor(this.m_PanelSitesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelSitesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelSitesFils.TabIndex = 0;
            this.m_PanelSitesFils.TrierAuClicSurEnteteColonne = true;
            this.m_PanelSitesFils.UseCheckBoxes = false;
            // 
            // m_pageEO
            // 
            this.m_pageEO.Controls.Add(this.m_panEOCoor);
            this.m_pageEO.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.m_pageEO, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEO, false);
            this.m_pageEO.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEO, "CEO");
            this.m_pageEO.Name = "m_pageEO";
            this.m_pageEO.Selected = false;
            this.m_pageEO.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEO.TabIndex = 12;
            this.m_pageEO.Title = "Organizational entities|53";
            // 
            // m_panEOCoor
            // 
            this.m_panEOCoor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panEOCoor.Controls.Add(this.label3);
            this.m_panEOCoor.Controls.Add(this.m_cmbEOsCoor);
            this.m_extLinkField.SetLinkField(this.m_panEOCoor, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panEOCoor, false);
            this.m_panEOCoor.Location = new System.Drawing.Point(3, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panEOCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panEOCoor, "");
            this.m_panEOCoor.Name = "m_panEOCoor";
            this.m_panEOCoor.Size = new System.Drawing.Size(445, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panEOCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panEOCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panEOCoor.TabIndex = 4018;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(5, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 19);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.label3.TabIndex = 4017;
            this.label3.Text = "Define coordinate according to|742";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEOS, false);
            this.m_panelEOS.Location = new System.Drawing.Point(6, 35);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(714, 239);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 0;
            // 
            // m_pageEquipements
            // 
            this.m_pageEquipements.Controls.Add(this.m_panelEquipements);
            this.m_extLinkField.SetLinkField(this.m_pageEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEquipements, false);
            this.m_pageEquipements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquipements, "");
            this.m_pageEquipements.Name = "m_pageEquipements";
            this.m_pageEquipements.Selected = false;
            this.m_pageEquipements.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquipements.TabIndex = 13;
            this.m_pageEquipements.Title = "Equipments|247";
            // 
            // m_panelEquipements
            // 
            this.m_panelEquipements.AllowArbre = true;
            this.m_panelEquipements.AllowCustomisation = true;
            this.m_panelEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn3.ActiveControlItems = null;
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Libelle";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            this.m_panelEquipements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelEquipements.ContexteUtilisation = "";
            this.m_panelEquipements.ControlFiltreStandard = null;
            this.m_panelEquipements.ElementSelectionne = null;
            this.m_panelEquipements.EnableCustomisation = true;
            this.m_panelEquipements.FiltreDeBase = null;
            this.m_panelEquipements.FiltreDeBaseEnAjout = false;
            this.m_panelEquipements.FiltrePrefere = null;
            this.m_panelEquipements.FiltreRapide = null;
            this.m_panelEquipements.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEquipements, false);
            this.m_panelEquipements.ListeObjets = null;
            this.m_panelEquipements.Location = new System.Drawing.Point(2, 3);
            this.m_panelEquipements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelEquipements.ModeQuickSearch = false;
            this.m_panelEquipements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelEquipements, "");
            this.m_panelEquipements.MultiSelect = false;
            this.m_panelEquipements.Name = "m_panelEquipements";
            this.m_panelEquipements.Navigateur = null;
            this.m_panelEquipements.ProprieteObjetAEditer = null;
            this.m_panelEquipements.QuickSearchText = "";
            this.m_panelEquipements.Size = new System.Drawing.Size(723, 278);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipements.TabIndex = 1;
            this.m_panelEquipements.TrierAuClicSurEnteteColonne = true;
            this.m_panelEquipements.UseCheckBoxes = false;
            // 
            // m_pageFunctions
            // 
            this.m_pageFunctions.Controls.Add(this.m_panelListeFonctions);
            this.m_extLinkField.SetLinkField(this.m_pageFunctions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFunctions, false);
            this.m_pageFunctions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFunctions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFunctions, "");
            this.m_pageFunctions.Name = "m_pageFunctions";
            this.m_pageFunctions.Selected = false;
            this.m_pageFunctions.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageFunctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFunctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFunctions.TabIndex = 19;
            this.m_pageFunctions.Title = "Log. Eqpts|20062";
            // 
            // m_panelListeFonctions
            // 
            this.m_panelListeFonctions.AllowArbre = true;
            this.m_panelListeFonctions.AllowCustomisation = true;
            this.m_panelListeFonctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn4.ActiveControlItems = null;
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Libelle";
            glColumn4.Propriete = "Libelle";
            glColumn4.Text = "Label|50";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.m_panelListeFonctions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4});
            this.m_panelListeFonctions.ContexteUtilisation = "";
            this.m_panelListeFonctions.ControlFiltreStandard = null;
            this.m_panelListeFonctions.ElementSelectionne = null;
            this.m_panelListeFonctions.EnableCustomisation = true;
            this.m_panelListeFonctions.FiltreDeBase = null;
            this.m_panelListeFonctions.FiltreDeBaseEnAjout = false;
            this.m_panelListeFonctions.FiltrePrefere = null;
            this.m_panelListeFonctions.FiltreRapide = null;
            this.m_panelListeFonctions.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeFonctions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeFonctions, false);
            this.m_panelListeFonctions.ListeObjets = null;
            this.m_panelListeFonctions.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeFonctions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeFonctions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeFonctions.ModeQuickSearch = false;
            this.m_panelListeFonctions.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeFonctions, "");
            this.m_panelListeFonctions.MultiSelect = false;
            this.m_panelListeFonctions.Name = "m_panelListeFonctions";
            this.m_panelListeFonctions.Navigateur = null;
            this.m_panelListeFonctions.ProprieteObjetAEditer = null;
            this.m_panelListeFonctions.QuickSearchText = "";
            this.m_panelListeFonctions.Size = new System.Drawing.Size(723, 278);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeFonctions.TabIndex = 2;
            this.m_panelListeFonctions.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeFonctions.UseCheckBoxes = false;
            // 
            // m_pageContraintes
            // 
            this.m_pageContraintes.Controls.Add(this.m_panelListeContraintes);
            this.m_extLinkField.SetLinkField(this.m_pageContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageContraintes, false);
            this.m_pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageContraintes, "");
            this.m_pageContraintes.Name = "m_pageContraintes";
            this.m_pageContraintes.Selected = false;
            this.m_pageContraintes.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageContraintes.TabIndex = 14;
            this.m_pageContraintes.Title = "Constraints|255";
            // 
            // m_panelListeContraintes
            // 
            this.m_panelListeContraintes.AllowArbre = true;
            this.m_panelListeContraintes.AllowCustomisation = true;
            this.m_panelListeContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "ColumnLabel";
            glColumn5.Propriete = "Libelle";
            glColumn5.Text = "Label|50";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 300;
            this.m_panelListeContraintes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn5});
            this.m_panelListeContraintes.ContexteUtilisation = "";
            this.m_panelListeContraintes.ControlFiltreStandard = null;
            this.m_panelListeContraintes.ElementSelectionne = null;
            this.m_panelListeContraintes.EnableCustomisation = true;
            this.m_panelListeContraintes.FiltreDeBase = null;
            this.m_panelListeContraintes.FiltreDeBaseEnAjout = false;
            this.m_panelListeContraintes.FiltrePrefere = null;
            this.m_panelListeContraintes.FiltreRapide = null;
            this.m_panelListeContraintes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_panelListeContraintes.ListeObjets = null;
            this.m_panelListeContraintes.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeContraintes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeContraintes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeContraintes.ModeQuickSearch = false;
            this.m_panelListeContraintes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeContraintes, "");
            this.m_panelListeContraintes.MultiSelect = false;
            this.m_panelListeContraintes.Name = "m_panelListeContraintes";
            this.m_panelListeContraintes.Navigateur = null;
            this.m_panelListeContraintes.ProprieteObjetAEditer = null;
            this.m_panelListeContraintes.QuickSearchText = "";
            this.m_panelListeContraintes.Size = new System.Drawing.Size(722, 269);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeContraintes.TabIndex = 0;
            this.m_panelListeContraintes.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeContraintes.UseCheckBoxes = false;
            // 
            // m_pageRessources
            // 
            this.m_pageRessources.Controls.Add(this.m_panelListeRessourcesDetenues);
            this.m_extLinkField.SetLinkField(this.m_pageRessources, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageRessources, false);
            this.m_pageRessources.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageRessources, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageRessources, "");
            this.m_pageRessources.Name = "m_pageRessources";
            this.m_pageRessources.Selected = false;
            this.m_pageRessources.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageRessources, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageRessources.TabIndex = 15;
            this.m_pageRessources.Title = "Held Resources|376";
            // 
            // m_panelListeRessourcesDetenues
            // 
            this.m_panelListeRessourcesDetenues.AllowArbre = false;
            this.m_panelListeRessourcesDetenues.AllowCustomisation = true;
            this.m_panelListeRessourcesDetenues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "colRessourceLibelle";
            glColumn6.Propriete = "Libelle";
            glColumn6.Text = "Label|50";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 100;
            this.m_panelListeRessourcesDetenues.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn6});
            this.m_panelListeRessourcesDetenues.ContexteUtilisation = "";
            this.m_panelListeRessourcesDetenues.ControlFiltreStandard = null;
            this.m_panelListeRessourcesDetenues.ElementSelectionne = null;
            this.m_panelListeRessourcesDetenues.EnableCustomisation = true;
            this.m_panelListeRessourcesDetenues.FiltreDeBase = null;
            this.m_panelListeRessourcesDetenues.FiltreDeBaseEnAjout = false;
            this.m_panelListeRessourcesDetenues.FiltrePrefere = null;
            this.m_panelListeRessourcesDetenues.FiltreRapide = null;
            this.m_panelListeRessourcesDetenues.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeRessourcesDetenues, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeRessourcesDetenues, false);
            this.m_panelListeRessourcesDetenues.ListeObjets = null;
            this.m_panelListeRessourcesDetenues.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeRessourcesDetenues.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeRessourcesDetenues, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeRessourcesDetenues.ModeQuickSearch = false;
            this.m_panelListeRessourcesDetenues.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeRessourcesDetenues, "");
            this.m_panelListeRessourcesDetenues.MultiSelect = false;
            this.m_panelListeRessourcesDetenues.Name = "m_panelListeRessourcesDetenues";
            this.m_panelListeRessourcesDetenues.Navigateur = null;
            this.m_panelListeRessourcesDetenues.ProprieteObjetAEditer = null;
            this.m_panelListeRessourcesDetenues.QuickSearchText = "";
            this.m_panelListeRessourcesDetenues.Size = new System.Drawing.Size(722, 277);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeRessourcesDetenues.TabIndex = 0;
            this.m_panelListeRessourcesDetenues.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeRessourcesDetenues.UseCheckBoxes = false;
            // 
            // m_pageInterventions
            // 
            this.m_pageInterventions.Controls.Add(this.c2iPanelFondDegradeStd1);
            this.m_pageInterventions.Controls.Add(this.m_wndListeInterventions);
            this.m_extLinkField.SetLinkField(this.m_pageInterventions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageInterventions, false);
            this.m_pageInterventions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInterventions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInterventions, "AINTER_CORR;AINTER_PREV;AINGE_PROJET");
            this.m_pageInterventions.Name = "m_pageInterventions";
            this.m_pageInterventions.Selected = false;
            this.m_pageInterventions.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInterventions.TabIndex = 17;
            this.m_pageInterventions.Title = "Interventions|344";
            // 
            // c2iPanelFondDegradeStd1
            // 
            this.c2iPanelFondDegradeStd1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("c2iPanelFondDegradeStd1.BackgroundImage")));
            this.c2iPanelFondDegradeStd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lnkPlanifierUneIntervention);
            this.m_extLinkField.SetLinkField(this.c2iPanelFondDegradeStd1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelFondDegradeStd1, false);
            this.c2iPanelFondDegradeStd1.Location = new System.Drawing.Point(463, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelFondDegradeStd1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelFondDegradeStd1, "");
            this.c2iPanelFondDegradeStd1.Name = "c2iPanelFondDegradeStd1";
            this.c2iPanelFondDegradeStd1.Size = new System.Drawing.Size(100, 24);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelFondDegradeStd1.TabIndex = 4015;
            // 
            // m_wndListeInterventions
            // 
            this.m_wndListeInterventions.AllowArbre = false;
            this.m_wndListeInterventions.AllowCustomisation = true;
            this.m_wndListeInterventions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "colRessourceLibelle";
            glColumn7.Propriete = "Libelle";
            glColumn7.Text = "Label|50";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 250;
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Name";
            glColumn8.Propriete = "TypeIntervention.Libelle";
            glColumn8.Text = "Type";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 250;
            glColumn9.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn9.ActiveControlItems")));
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "Namex";
            glColumn9.Propriete = "DateDebutPlanifieToString";
            glColumn9.Text = "Debut";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 100;
            this.m_wndListeInterventions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn7,
            glColumn8,
            glColumn9});
            this.m_wndListeInterventions.ContexteUtilisation = "";
            this.m_wndListeInterventions.ControlFiltreStandard = null;
            this.m_wndListeInterventions.ElementSelectionne = null;
            this.m_wndListeInterventions.EnableCustomisation = true;
            this.m_wndListeInterventions.FiltreDeBase = null;
            this.m_wndListeInterventions.FiltreDeBaseEnAjout = false;
            this.m_wndListeInterventions.FiltrePrefere = null;
            this.m_wndListeInterventions.FiltreRapide = null;
            this.m_wndListeInterventions.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeInterventions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeInterventions, false);
            this.m_wndListeInterventions.ListeObjets = null;
            this.m_wndListeInterventions.Location = new System.Drawing.Point(3, 3);
            this.m_wndListeInterventions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeInterventions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_wndListeInterventions.ModeQuickSearch = false;
            this.m_wndListeInterventions.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_wndListeInterventions, "");
            this.m_wndListeInterventions.MultiSelect = false;
            this.m_wndListeInterventions.Name = "m_wndListeInterventions";
            this.m_wndListeInterventions.Navigateur = null;
            this.m_wndListeInterventions.ProprieteObjetAEditer = null;
            this.m_wndListeInterventions.QuickSearchText = "";
            this.m_wndListeInterventions.Size = new System.Drawing.Size(722, 277);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeInterventions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeInterventions.TabIndex = 1;
            this.m_wndListeInterventions.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeInterventions.UseCheckBoxes = false;
            // 
            // m_pageSystemeCoor
            // 
            this.m_pageSystemeCoor.Controls.Add(this.m_panelOptionsCoordonnees);
            this.m_pageSystemeCoor.Controls.Add(this.m_panelEditSystemeCoordonnee);
            this.m_extLinkField.SetLinkField(this.m_pageSystemeCoor, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSystemeCoor, false);
            this.m_pageSystemeCoor.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSystemeCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSystemeCoor, "ASYS_COOR");
            this.m_pageSystemeCoor.Name = "m_pageSystemeCoor";
            this.m_pageSystemeCoor.Selected = false;
            this.m_pageSystemeCoor.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageSystemeCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSystemeCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSystemeCoor.TabIndex = 16;
            this.m_pageSystemeCoor.Title = "Coordinate System|430";
            // 
            // m_panelOptionsCoordonnees
            // 
            this.m_panelOptionsCoordonnees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOptionsCoordonnees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelOptionsCoordonnees.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelOptionsCoordonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelOptionsCoordonnees, false);
            this.m_panelOptionsCoordonnees.Location = new System.Drawing.Point(4, 3);
            this.m_panelOptionsCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOptionsCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelOptionsCoordonnees, "");
            this.m_panelOptionsCoordonnees.Name = "m_panelOptionsCoordonnees";
            this.m_panelOptionsCoordonnees.Size = new System.Drawing.Size(516, 93);
            this.m_extStyle.SetStyleBackColor(this.m_panelOptionsCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOptionsCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOptionsCoordonnees.TabIndex = 1;
            // 
            // m_panelEditSystemeCoordonnee
            // 
            this.m_panelEditSystemeCoordonnee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditSystemeCoordonnee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelEditSystemeCoordonnee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_extLinkField.SetLinkField(this.m_panelEditSystemeCoordonnee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditSystemeCoordonnee, false);
            this.m_panelEditSystemeCoordonnee.Location = new System.Drawing.Point(4, 102);
            this.m_panelEditSystemeCoordonnee.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditSystemeCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditSystemeCoordonnee, "");
            this.m_panelEditSystemeCoordonnee.Name = "m_panelEditSystemeCoordonnee";
            this.m_panelEditSystemeCoordonnee.Size = new System.Drawing.Size(442, 178);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditSystemeCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditSystemeCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditSystemeCoordonnee.TabIndex = 0;
            // 
            // m_pageTablesParametrables
            // 
            this.m_pageTablesParametrables.Controls.Add(this.m_panListeTableParametrables);
            this.m_extLinkField.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageTablesParametrables, false);
            this.m_pageTablesParametrables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTablesParametrables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTablesParametrables, "ATABLES_PARAM");
            this.m_pageTablesParametrables.Name = "m_pageTablesParametrables";
            this.m_pageTablesParametrables.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTablesParametrables.TabIndex = 18;
            this.m_pageTablesParametrables.Title = "Custom Tables|1195";
            // 
            // m_panListeTableParametrables
            // 
            this.m_panListeTableParametrables.AllowArbre = true;
            this.m_panListeTableParametrables.AllowCustomisation = true;
            glColumn1.ActiveControlItems = null;
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
            glColumn1.Width = 100;
            this.m_panListeTableParametrables.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panListeTableParametrables.ContexteUtilisation = "";
            this.m_panListeTableParametrables.ControlFiltreStandard = null;
            this.m_panListeTableParametrables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panListeTableParametrables.ElementSelectionne = null;
            this.m_panListeTableParametrables.EnableCustomisation = true;
            this.m_panListeTableParametrables.FiltreDeBase = null;
            this.m_panListeTableParametrables.FiltreDeBaseEnAjout = false;
            this.m_panListeTableParametrables.FiltrePrefere = null;
            this.m_panListeTableParametrables.FiltreRapide = null;
            this.m_panListeTableParametrables.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panListeTableParametrables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panListeTableParametrables, false);
            this.m_panListeTableParametrables.ListeObjets = null;
            this.m_panListeTableParametrables.Location = new System.Drawing.Point(0, 0);
            this.m_panListeTableParametrables.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panListeTableParametrables, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panListeTableParametrables.ModeQuickSearch = false;
            this.m_panListeTableParametrables.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panListeTableParametrables, "");
            this.m_panListeTableParametrables.MultiSelect = false;
            this.m_panListeTableParametrables.Name = "m_panListeTableParametrables";
            this.m_panListeTableParametrables.Navigateur = null;
            this.m_panListeTableParametrables.ProprieteObjetAEditer = null;
            this.m_panListeTableParametrables.QuickSearchText = "";
            this.m_panListeTableParametrables.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_panListeTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panListeTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panListeTableParametrables.TabIndex = 1;
            this.m_panListeTableParametrables.TrierAuClicSurEnteteColonne = true;
            this.m_panListeTableParametrables.UseCheckBoxes = false;
            // 
            // m_pageSymbole
            // 
            this.m_pageSymbole.Controls.Add(this.m_panelSymbole);
            this.m_extLinkField.SetLinkField(this.m_pageSymbole, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSymbole, false);
            this.m_pageSymbole.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSymbole, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSymbole, "");
            this.m_pageSymbole.Name = "m_pageSymbole";
            this.m_pageSymbole.Selected = false;
            this.m_pageSymbole.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSymbole.TabIndex = 20;
            this.m_pageSymbole.Title = "Symbol|30029";
            // 
            // m_panelSymbole
            // 
            this.m_panelSymbole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSymbole, false);
            this.m_panelSymbole.Location = new System.Drawing.Point(0, 0);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 0;
            // 
            // m_pageLiens
            // 
            this.m_pageLiens.Controls.Add(this.m_panelListeLiens);
            this.m_pageLiens.Controls.Add(this.splitter1);
            this.m_pageLiens.Controls.Add(this.m_panelExtremites);
            this.m_extLinkField.SetLinkField(this.m_pageLiens, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageLiens, false);
            this.m_pageLiens.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLiens, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLiens, "ALIAISONS");
            this.m_pageLiens.Name = "m_pageLiens";
            this.m_pageLiens.Selected = false;
            this.m_pageLiens.Size = new System.Drawing.Size(728, 283);
            this.m_extStyle.SetStyleBackColor(this.m_pageLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLiens.TabIndex = 21;
            this.m_pageLiens.Title = "Links|30380";
            // 
            // m_panelListeLiens
            // 
            this.m_panelListeLiens.AllowArbre = true;
            this.m_panelListeLiens.AllowCustomisation = true;
            glColumn10.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn10.ActiveControlItems")));
            glColumn10.BackColor = System.Drawing.Color.Transparent;
            glColumn10.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn10.ForColor = System.Drawing.Color.Black;
            glColumn10.ImageIndex = -1;
            glColumn10.IsCheckColumn = false;
            glColumn10.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn10.Name = "m_colLienLibelle";
            glColumn10.Propriete = "Libelle";
            glColumn10.Text = "Label|50";
            glColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn10.Width = 200;
            glColumn11.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn11.ActiveControlItems")));
            glColumn11.BackColor = System.Drawing.Color.Transparent;
            glColumn11.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn11.ForColor = System.Drawing.Color.Black;
            glColumn11.ImageIndex = -1;
            glColumn11.IsCheckColumn = false;
            glColumn11.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn11.Name = "m_colLienSite1";
            glColumn11.Propriete = "Site1.Label";
            glColumn11.Text = "Site 1";
            glColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn11.Width = 200;
            glColumn12.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn12.ActiveControlItems")));
            glColumn12.BackColor = System.Drawing.Color.Transparent;
            glColumn12.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn12.ForColor = System.Drawing.Color.Black;
            glColumn12.ImageIndex = -1;
            glColumn12.IsCheckColumn = false;
            glColumn12.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn12.Name = "m_colLienSite2";
            glColumn12.Propriete = "Site2.Label";
            glColumn12.Text = "Site 2";
            glColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn12.Width = 200;
            this.m_panelListeLiens.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn10,
            glColumn11,
            glColumn12});
            this.m_panelListeLiens.ContexteUtilisation = "";
            this.m_panelListeLiens.ControlFiltreStandard = null;
            this.m_panelListeLiens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeLiens.ElementSelectionne = null;
            this.m_panelListeLiens.EnableCustomisation = true;
            this.m_panelListeLiens.FiltreDeBase = null;
            this.m_panelListeLiens.FiltreDeBaseEnAjout = false;
            this.m_panelListeLiens.FiltrePrefere = null;
            this.m_panelListeLiens.FiltreRapide = null;
            this.m_panelListeLiens.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeLiens, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeLiens, false);
            this.m_panelListeLiens.ListeObjets = null;
            this.m_panelListeLiens.Location = new System.Drawing.Point(319, 0);
            this.m_panelListeLiens.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeLiens, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeLiens.ModeQuickSearch = false;
            this.m_panelListeLiens.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeLiens, "");
            this.m_panelListeLiens.MultiSelect = false;
            this.m_panelListeLiens.Name = "m_panelListeLiens";
            this.m_panelListeLiens.Navigateur = null;
            this.m_panelListeLiens.ProprieteObjetAEditer = null;
            this.m_panelListeLiens.QuickSearchText = "";
            this.m_panelListeLiens.Size = new System.Drawing.Size(409, 283);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeLiens.TabIndex = 0;
            this.m_panelListeLiens.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeLiens.UseCheckBoxes = false;
            this.m_panelListeLiens.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListeLiens_OnNewObjetDonnee);
            // 
            // splitter1
            // 
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(316, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 283);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // m_panelExtremites
            // 
            this.m_panelExtremites.Controls.Add(this.m_panelEditExtremite);
            this.m_panelExtremites.Controls.Add(this.m_lnkSupprimerExtremite);
            this.m_panelExtremites.Controls.Add(this.m_wndListeExtremites);
            this.m_panelExtremites.Controls.Add(this.m_lnkAjouterExtremite);
            this.m_panelExtremites.Controls.Add(this.m_txtBoxExtremite);
            this.m_panelExtremites.Controls.Add(this.label4);
            this.m_panelExtremites.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelExtremites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelExtremites, false);
            this.m_panelExtremites.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelExtremites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelExtremites, "");
            this.m_panelExtremites.Name = "m_panelExtremites";
            this.m_panelExtremites.Size = new System.Drawing.Size(316, 283);
            this.m_extStyle.SetStyleBackColor(this.m_panelExtremites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelExtremites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelExtremites.TabIndex = 1;
            // 
            // m_panelEditExtremite
            // 
            this.m_panelEditExtremite.Controls.Add(this.label5);
            this.m_panelEditExtremite.Controls.Add(this.m_txtEditeNomExtremite);
            this.m_extLinkField.SetLinkField(this.m_panelEditExtremite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditExtremite, false);
            this.m_panelEditExtremite.Location = new System.Drawing.Point(186, 43);
            this.m_panelEditExtremite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditExtremite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditExtremite, "");
            this.m_panelEditExtremite.Name = "m_panelEditExtremite";
            this.m_panelEditExtremite.Size = new System.Drawing.Size(122, 163);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditExtremite.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(3, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 8;
            this.label5.Text = "Label|50";
            // 
            // m_txtEditeNomExtremite
            // 
            this.m_extLinkField.SetLinkField(this.m_txtEditeNomExtremite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtEditeNomExtremite, false);
            this.m_txtEditeNomExtremite.Location = new System.Drawing.Point(3, 24);
            this.m_txtEditeNomExtremite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtEditeNomExtremite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtEditeNomExtremite, "");
            this.m_txtEditeNomExtremite.Name = "m_txtEditeNomExtremite";
            this.m_txtEditeNomExtremite.Size = new System.Drawing.Size(116, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtEditeNomExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtEditeNomExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtEditeNomExtremite.TabIndex = 0;
            // 
            // m_lnkSupprimerExtremite
            // 
            this.m_lnkSupprimerExtremite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerExtremite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerExtremite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerExtremite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimerExtremite, false);
            this.m_lnkSupprimerExtremite.Location = new System.Drawing.Point(8, 263);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerExtremite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerExtremite, "");
            this.m_lnkSupprimerExtremite.Name = "m_lnkSupprimerExtremite";
            this.m_lnkSupprimerExtremite.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerExtremite.TabIndex = 6;
            this.m_lnkSupprimerExtremite.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerExtremite.LinkClicked += new System.EventHandler(this.m_lnkSupprimerExtremite_LinkClicked);
            // 
            // m_wndListeExtremites
            // 
            this.m_wndListeExtremites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeExtremites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn4});
            this.m_wndListeExtremites.EnableCustomisation = true;
            this.m_wndListeExtremites.FullRowSelect = true;
            this.m_wndListeExtremites.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeExtremites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeExtremites, false);
            this.m_wndListeExtremites.Location = new System.Drawing.Point(3, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeExtremites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeExtremites, "");
            this.m_wndListeExtremites.MultiSelect = false;
            this.m_wndListeExtremites.Name = "m_wndListeExtremites";
            this.m_wndListeExtremites.Size = new System.Drawing.Size(177, 214);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeExtremites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeExtremites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeExtremites.TabIndex = 5;
            this.m_wndListeExtremites.UseCompatibleStateImageBehavior = false;
            this.m_wndListeExtremites.View = System.Windows.Forms.View.Details;
            this.m_wndListeExtremites.SelectedIndexChanged += new System.EventHandler(this.m_wndListeExtremites_SelectedIndexChanged);
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "Libelle";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Label|50";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 200;
            // 
            // m_lnkAjouterExtremite
            // 
            this.m_lnkAjouterExtremite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkAjouterExtremite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterExtremite.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterExtremite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterExtremite, false);
            this.m_lnkAjouterExtremite.Location = new System.Drawing.Point(223, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterExtremite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterExtremite, "");
            this.m_lnkAjouterExtremite.Name = "m_lnkAjouterExtremite";
            this.m_lnkAjouterExtremite.Size = new System.Drawing.Size(90, 25);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterExtremite.TabIndex = 4;
            this.m_lnkAjouterExtremite.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterExtremite.LinkClicked += new System.EventHandler(this.m_lnkAjouterExtremite_LinkClicked);
            // 
            // m_txtBoxExtremite
            // 
            this.m_txtBoxExtremite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtBoxExtremite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtBoxExtremite, false);
            this.m_txtBoxExtremite.Location = new System.Drawing.Point(3, 16);
            this.m_txtBoxExtremite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxExtremite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtBoxExtremite, "");
            this.m_txtBoxExtremite.Name = "m_txtBoxExtremite";
            this.m_txtBoxExtremite.Size = new System.Drawing.Size(214, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxExtremite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxExtremite.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Links ends|20104";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 144;
            this.listViewAutoFilledColumn1.ProportionnalSize = true;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 144;
            // 
            // m_reducteurEntete
            // 
            this.m_reducteurEntete.ControleAgrandit = this.m_TabControl;
            this.m_reducteurEntete.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurEntete.ControleReduit = this.m_panelEntete;
            this.m_extLinkField.SetLinkField(this.m_reducteurEntete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_reducteurEntete, false);
            this.m_reducteurEntete.Location = new System.Drawing.Point(380, 39);
            this.m_reducteurEntete.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurEntete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurEntete.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurEntete, "");
            this.m_reducteurEntete.Name = "m_reducteurEntete";
            this.m_reducteurEntete.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurEntete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurEntete.TabIndex = 4014;
            this.m_reducteurEntete.TailleReduite = 32;
            // 
            // m_gestionnaireEditionExtremites
            // 
            this.m_gestionnaireEditionExtremites.ListeAssociee = this.m_wndListeExtremites;
            this.m_gestionnaireEditionExtremites.ObjetEdite = null;
            this.m_gestionnaireEditionExtremites.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionExtremites_InitChamp);
            this.m_gestionnaireEditionExtremites.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionExtremites_MAJ_Champs);
            // 
            // CFormEditionSite
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(756, 500);
            this.Controls.Add(this.m_reducteurEntete);
            this.Controls.Add(this.m_panelEntete);
            this.Controls.Add(this.m_TabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionSite";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSite_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionSite_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelEntete, 0);
            this.Controls.SetChildIndex(this.m_reducteurEntete, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelEntete.ResumeLayout(false);
            this.m_panelEntete.PerformLayout();
            this.m_panelCoordonnee.ResumeLayout(false);
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageChampsCustom.ResumeLayout(false);
            this.m_pageSitesFille.ResumeLayout(false);
            this.m_pageEO.ResumeLayout(false);
            this.m_panEOCoor.ResumeLayout(false);
            this.m_pageEquipements.ResumeLayout(false);
            this.m_pageFunctions.ResumeLayout(false);
            this.m_pageContraintes.ResumeLayout(false);
            this.m_pageRessources.ResumeLayout(false);
            this.m_pageInterventions.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.PerformLayout();
            this.m_pageSystemeCoor.ResumeLayout(false);
            this.m_pageTablesParametrables.ResumeLayout(false);
            this.m_pageSymbole.ResumeLayout(false);
            this.m_pageLiens.ResumeLayout(false);
            this.m_panelExtremites.ResumeLayout(false);
            this.m_panelExtremites.PerformLayout();
            this.m_panelEditExtremite.ResumeLayout(false);
            this.m_panelEditExtremite.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionSite()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionSite(CSite site)
            : base(site)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionSite(CSite site, CListeObjetsDonnees liste)
            : base(site, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CSite LeSite
		{
			get	{ return (CSite)ObjetEdite;	}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

            if (!result)
                return result;

			AffecterTitre(I.T("Site|175") +" "+ LeSite.Libelle);
            
            // Initialise l'affichage de l'arbre hiérarchique
            m_ArbreSitesHierarchique.AfficheHierarchie(LeSite);
            
            result = InitSelectTypeSite();
            m_cmbxTypeSite.ElementSelectionne = LeSite.TypeSite;

			InitPanelCoordonnees();

			DisplayOrHidePanelChamps();

          	return result;
		}

		//------------------------------------------------------------------------------------
		private void DisplayOrHidePanelChamps()
		{
			if (LeSite.GetFormulaires().Length == 0)
			{
				if (m_TabControl.TabPages.Contains(m_pageChampsCustom))
					m_TabControl.TabPages.Remove(m_pageChampsCustom);
			}
			else
			{
				if (!m_TabControl.TabPages.Contains(m_pageChampsCustom))
					m_TabControl.TabPages.Insert(0, m_pageChampsCustom);
			}
		}

        //------------------------------------------------------------------------------------
        private void InitPanelChamps()
        {
            // Initialise le panel des champs personalisés (custom)
			DisplayOrHidePanelChamps();
            m_PanelChamps.ElementEdite = LeSite;
        }

        //------------------------------------------------------------------------------------
        void m_panelEOS_OnChangeEOS(object sender, EventArgs e)
		{
			ActualiserListeEOPourCoor();
		}

        //------------------------------------------------------------------------------------
        private void InitTablesParametrables()
		{
			m_panListeTableParametrables.InitFromListeObjets(
			LeSite.TablesParametrables,
			typeof(CTableParametrable),
			LeSite,
			"Site");
		}

        //------------------------------------------------------------------------------------
        private void ActualiserListeEOPourCoor()
		{
			List<CEntiteOrganisationnelle> lstEOsLiees = m_panelEOS.GetCheckedEO();

			if (LeSite.TypeSite == null 
				|| LeSite.TypeSite.TypeEntiteOrganisationnelleDeCoordonnee == null
				|| lstEOsLiees.Count < 1)
			{
				m_panEOCoor.Visible = false;
				m_cmbEOsCoor.ElementSelectionne = null;
				return;
			}

			//Les EOs du type de LeSite.TypeSite.TypeEntiteOrganisationnelleDeCoordonnee
			//Et qui sont liées au site actuel ?
			CFiltreData filtreEODuBonType = new CFiltreData(CTypeEntiteOrganisationnelle.c_champId + " =@1", LeSite.TypeSite.TypeEntiteOrganisationnelleDeCoordonnee.CodeSystemeComplet);

			List<CEntiteOrganisationnelle> lstEOsFinales = new List<CEntiteOrganisationnelle>();
			foreach (CEntiteOrganisationnelle e in lstEOsLiees)
				lstEOsFinales.Add(e);

			string strIDs = "";
			foreach (CEntiteOrganisationnelle e in lstEOsLiees)
				foreach (CEntiteOrganisationnelle e2 in lstEOsLiees)
				{
					if (e2.Equals(e))
						continue;
					if (e.IsChildOf(e2))
					{
						lstEOsFinales.Remove(e);
						break;
					}
				}




			foreach (CEntiteOrganisationnelle e in lstEOsFinales)
				strIDs += e.Id.ToString() + ",";

			strIDs = strIDs.Substring(0, strIDs.Length - 1);

			CFiltreData filtreEOLieesAuSite = new CFiltreDataAvance(
                CEntiteOrganisationnelle.c_nomTable,
                CEntiteOrganisationnelle.c_champId + " in (" + strIDs + ") AND " + 
				CTypeEntiteOrganisationnelle.c_nomTable+"."+
                CTypeEntiteOrganisationnelle.c_champCodeSystemeComplet + " Like @1",
				LeSite.TypeSite.TypeEntiteOrganisationnelleDeCoordonnee.CodeSystemeComplet + "%");

			CResultAErreur result =	m_cmbEOsCoor.Init(typeof(CEntiteOrganisationnelle),
				"EntiteFilles",
				CEntiteOrganisationnelle.c_champIdParent,
				"Libelle",
				filtreEOLieesAuSite,
				null);

			if (lstEOsFinales.Count == 1)
				m_cmbEOsCoor.ElementSelectionne = lstEOsFinales[0];


			m_panEOCoor.Visible = true;
		}

		//---------------------------------------------------------------------------------------
		private CResultAErreur InitPanelCoordonnees()
		{
			CResultAErreur result = CResultAErreur.True;
			IObjetAFilsACoordonnees parent = LeSite.ConteneurFilsACoordonnees;

			if (parent != null && parent.ParametrageCoordonneesApplique != null)
			{
				m_editCoordonnee.Init(parent, LeSite);
				m_editCoordonnee.Coordonnee = LeSite.Coordonnee;
				m_panelCoordonnee.Visible = true;
			}
			else
				m_panelCoordonnee.Visible = false;
			return result;
		}

        //---------------------------------------------------------------------------------------
        private CResultAErreur InitPanelsSystemeCoordonnees()
        {

			CResultAErreur result = CResultAErreur.True;
			result = m_panelEditSystemeCoordonnee.Init(LeSite);
			if (result)
				result = m_panelOptionsCoordonnees.Init(LeSite);

            return result;
        }

        //---------------------------------------------------------------------------------------
        private CResultAErreur InitSelectTypeSite()
        {
            CResultAErreur result = CResultAErreur.True;

            //Initialise la liste des types de site possibles
            CListeObjetsDonnees liste_type = new CListeObjetsDonnees(LeSite.ContexteDonnee, typeof(CTypeSite));

            // Filtrer liste_type
            if (LeSite.SiteParent != null)
            {
                string strListeFiltre = "";

                CListeObjetsDonnees liste_relations = LeSite.SiteParent.TypeSite.RelationTypesContenus;
                if (liste_relations.Count == 0)
                {
                    result.EmpileErreur(I.T( "There is no child site type available|189"));
                    return result;
                }
                foreach (CRelationTypeSite_TypeSite rel in liste_relations)
                    strListeFiltre += rel.TypeSiteContenu.Id + ",";
                
                if (strListeFiltre.Length > 0)
                {
                    strListeFiltre = strListeFiltre.Substring(0, strListeFiltre.Length - 1);
                    liste_type.Filtre = new CFiltreData(CTypeSite.c_champId + " in (" + strListeFiltre + ")");
                }
            }
            else
            {
                // Filtre les Types de Site dont l'option ParentObligatoire = false
                string strIdTypesPermis = "";
                foreach (CTypeSite tp in liste_type)
                {
                    if (!tp.ParentObligatoire)
                        strIdTypesPermis += tp.Id + ",";
                }
                if (strIdTypesPermis.Length > 0)
                {
                    strIdTypesPermis = strIdTypesPermis.Substring(0, strIdTypesPermis.Length - 1);
                    liste_type.Filtre = new CFiltreData(CTypeSite.c_champId + " in (" + strIdTypesPermis + ")");
                }

            }

            if (liste_type.Count == 1 && LeSite.TypeSite == null && m_gestionnaireModeEdition.ModeEdition)
                LeSite.TypeSite = (CTypeSite)liste_type[0];
            
            m_cmbxTypeSite.Init(
                liste_type,
                "Libelle",
                typeof(CFormEditionTypeSite),
                true);

            return result;
        }
        
		//---------------------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = CResultAErreur.True;

            if(m_cmbxTypeSite.ElementSelectionne !=null)
                LeSite.TypeSite = (CTypeSite) m_cmbxTypeSite.ElementSelectionne;

			result = base.MAJ_Champs();
			if ( result )
				LeSite.Coordonnee = m_editCoordonnee.Coordonnee;

            return result;
        }

        //---------------------------------------------------------------------------------------
        private CResultAErreur CFormEditionSite_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageChampsCustom)
                result = m_PanelChamps.MAJ_Champs();
            else if (page == m_pageEO)
                result = m_panelEOS.MajChamps();
            else if (page == m_pageSystemeCoor)
            {
                if (result)
                    result = m_panelEditSystemeCoordonnee.MajChamps();
                if (result)
                    result = m_panelOptionsCoordonnees.MajChamps();
            }
            else if (page == m_pageSymbole)
            {
                result = m_panelSymbole.MAJ_Champs();
            }
            else if (page == m_pageLiens)
            {
                result = m_gestionnaireEditionExtremites.ValideModifs();
            }

            return result;
        }


		//-----------------------------------------------------------------------------------------
        private void m_cmbxTypeSite_SelectionChangeCommitted(object sender, EventArgs e)
        {
			if (m_cmbxTypeSite.ElementSelectionne != null)
			{
				LeSite.TypeSite = (CTypeSite)m_cmbxTypeSite.ElementSelectionne;
				InitTablesParametrables();
                InitPanelChamps();
            }
        }

		//-----------------------------------------------------------------------------------
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormPlanification form = new CFormPlanification();
			form.Show();
		}

		//-----------------------------------------------------------------------------------
		private void m_ArbreSitesHierarchique_OnChangeObjetParent(object sender, EventArgs e)
		{
			m_editCoordonnee.Init(LeSite.SiteParent, LeSite);
		}

        //------------------------------------------------------------------------------------
        private void m_lnkPlanifierUneIntervention_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
			CTimosApp.Navigateur.AffichePage(new CFormPlanifierInterventions(LeSite));
        }

        //------------------------------------------------------------------------------------
        private void m_cmbEOsCoor_ElementSelectionneChanged(object sender, EventArgs e)
		{
			LeSite.EOdeCoordonnee = (CEntiteOrganisationnelle) m_cmbEOsCoor.ElementSelectionne;
			InitPanelCoordonnees();
		}

		//------------------------------ TAB CONTROL ----------------------------------
		private CResultAErreur CFormEditionSite_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageSitesFille)
			{
				m_PanelSitesFils.InitFromListeObjets(
				LeSite.SitesFils,
				typeof(CSite),
				typeof(CFormEditionSite),
				LeSite,
				"SiteParent");
			}
			else if (page == m_pageEquipements)
			{
				m_panelEquipements.InitFromListeObjets(
				LeSite.Equipements,
				typeof(CEquipement),
				typeof(CFormEditionEquipement),
				LeSite,
				"EmplacementInitial");
			}
			else if (page == m_pageFunctions)
			{
				m_panelListeFonctions.InitFromListeObjets(
					LeSite.EquipementsLogiques,
					typeof(CEquipementLogique),
					typeof(CFormEditionEquipementLogique),
					LeSite,
					"Site");
			}
			else if (page == m_pageContraintes)
			{
				m_panelListeContraintes.InitFromListeObjets(
				LeSite.Contraintes,
				typeof(CContrainte),
				typeof(CFormEditionContrainte),
				LeSite,
				"Site");
			}
			else if (page == m_pageRessources)
			{
				m_panelListeRessourcesDetenues.InitFromListeObjets(
				LeSite.RessourcesDetenues,
				typeof(CRessourceMaterielle),
				typeof(CFormEditionRessource),
				LeSite,
				"EmplacementInitial");
			}
			else if (page == m_pageTablesParametrables)
			{
				InitTablesParametrables();
			}
			else if (page == m_pageEO)
			{
				m_panelEOS.Init(LeSite);
				//Initialisation des EOs pouvant définir une coordonnée
				ActualiserListeEOPourCoor();
				m_panelEOS.OnChangeEOS += new EventHandler(m_panelEOS_OnChangeEOS);
				m_cmbEOsCoor.ElementSelectionne = LeSite.EOdeCoordonnee;
			}
			else if (page == m_pageChampsCustom)
			{
				InitPanelChamps();
			}
			else if (page == m_pageInterventions)
			{
				m_wndListeInterventions.InitFromListeObjets(
				LeSite.Interventions,
				typeof(CIntervention),
				typeof(CFormEditionIntervention),
				LeSite,
				"ElementAIntervention");
			}
			else if (page == m_pageSystemeCoor)
			{
				result = InitPanelsSystemeCoordonnees();
			}
            else if (page == m_pageSymbole)
            {
                result = m_panelSymbole.InitChamps(LeSite, LeSite.TypeSite);
            }

            else if (page == m_pageLiens)
            {
                m_panelListeLiens.InitFromListeObjets(
                    LeSite.ListeLiens,
                    typeof(CLienReseau),
                    LeSite,
                    "Site1");
                m_gestionnaireEditionExtremites.ObjetEdite = LeSite.ExtremitesDeLiens;
                m_panelEditExtremite.Visible = m_gestionnaireEditionExtremites.ObjetEnCours is CExtremiteLienSurSite;
                m_txtBoxExtremite.Text = "";
            }
			return result;

		}



        private void m_panelListeLiens_OnNewObjetDonnee(object sender, CObjetDonnee nouvelObjet, ref bool bCancel)
        {
            if (bCancel)
                return;
            
            CLienReseau lien = nouvelObjet as CLienReseau;
           

            if (lien != null)
            {
                lien.Element1 = LeSite;
                CFiltreData filtreLien = new CFiltreData(CTypeLienReseau.c_champTypeElement1 + "=@1 ", typeof(CSite).ToString());
                CListeObjetsDonnees liste_type = new CListeObjetsDonnees(lien.ContexteDonnee, typeof(CTypeLienReseau));
                liste_type.Filtre = filtreLien;
                lien.TypeLienReseau = (CTypeLienReseau)liste_type[0];

            }

        }

        private void m_wndListeExtremites_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void m_gestionnaireEditionExtremites_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            CExtremiteLienSurSite extremite = args.Objet as CExtremiteLienSurSite;
            if (extremite == null)
            {
                m_panelEditExtremite.Visible = false;
                return;
            }
            m_panelEditExtremite.Visible = true;
            m_txtEditeNomExtremite.Text = extremite.Libelle;


        }

        private void m_gestionnaireEditionExtremites_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            CExtremiteLienSurSite extremite = args.Objet as CExtremiteLienSurSite;
            extremite.Libelle = m_txtEditeNomExtremite.Text;
        }

        private void m_lnkAjouterExtremite_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtBoxExtremite.Text.Trim().Length == 0)
                return;

            CExtremiteLienSurSite extremite = new CExtremiteLienSurSite(ContexteDonnee);
            extremite.Site = LeSite;
            extremite.Libelle = m_txtBoxExtremite.Text;

            ListViewItem item = new ListViewItem();
            m_wndListeExtremites.Items.Add(item);
            m_wndListeExtremites.UpdateItemWithObject(item, extremite);
            foreach (ListViewItem itemSel in m_wndListeExtremites.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            m_txtBoxExtremite.Text = "";
        }

        private void m_lnkSupprimerExtremite_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeExtremites.SelectedItems.Count != 1)
                return;

            CExtremiteLienSurSite extremite = m_wndListeExtremites.SelectedItems[0].Tag as CExtremiteLienSurSite;
            if ( extremite == null )
                return;

            m_gestionnaireEditionExtremites.SetObjetEnCoursToNull();
            CResultAErreur result = extremite.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_wndListeExtremites.SelectedItems.Count == 1)
            {
                if (m_wndListeExtremites.SelectedItems[0] != null)
                    m_wndListeExtremites.SelectedItems[0].Remove();
            }
        }




	}
}

