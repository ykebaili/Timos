using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.data;
using sc2i.data.dynamic;
using sc2i.common;
using sc2i.win32.navigation;
using sc2i.win32.common;
using sc2i.win32.data;
using sc2i.win32.data.dynamic;
using sc2i.win32.data.navigation;

using timos.data;
using System.Threading;
using timos.data.workflow.gantt;
using timos.data.projet.gantt;
using sc2i.formulaire;
using timos.Securite;
using timos.projet.besoin;
using timos.data.projet.besoin;
using sc2i.workflow;
using sc2i.multitiers.client;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CProjet))]
	public class CFormEditionProjet : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code


		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private Label m_lblProject;
		private C2iTabControl m_TabControl;
		private ListViewAutoFilled m_wndListeEquipements;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private ListViewAutoFilled m_wndListeSite;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private CPanelChampsCustom m_PanelChamps;
		private Label m_lblTypeTable;
		private Crownwood.Magic.Controls.TabPage m_pageInfos;
		private Label m_lblDateDebut;
		private Label m_lblDateFin;
		private C2iTextBox m_txtDescrip;
		private C2iDateTimeExPicker m_dtpDateDebutReelle;
		private C2iDateTimeExPicker m_dtpDateFinReelle;
		private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private Label m_lblDescription;
        private Crownwood.Magic.Controls.TabPage m_pageContraintes;
		private CReducteurControle m_reducteurTop;
        private Crownwood.Magic.Controls.TabPage m_pageGantt;
        private timos.projet.gantt.CControlGanttProjet m_gantt;
        private Crownwood.Magic.Controls.TabPage m_pageFils;
        private CPanelListeSpeedStandard m_PanelProjetsFils;
        private CheckBox m_chkDatesAuto;
        private timos.win32.composants.CDateTimePickerForContextMenu m_dtpDatesPrevisionnelles;
        private CComboBoxLinkListeObjetsDonnees m_selectTypeProjet;
        private timos.projet.gantt.CPanelEditContraintesDeProjet m_panelContraintes;
        private Label label2;
        private Panel m_panelMarge;
        private C2iPanel m_panelPrevisionnel;
        private LinkLabel m_lnkDoModificationsPrevisionnelles;
        private Crownwood.Magic.Controls.TabPage m_pageEOS;
        private CPanelAffectationEO m_panelEOS;
        private Crownwood.Magic.Controls.TabPage m_pageDroits;
        private CPanelRestrictionsSpecifiques m_panelRestrictions;
        private LinkLabel m_lnkDroits;
        private LinkLabel m_lnkSubTypes;
        private ContextMenuStrip m_menuSousTypes;
        private Panel panel1;
        private CControleListeBesoins m_wndSpecifications;
        private Splitter splitter1;
        private Panel m_panelBesoins;
        private Panel m_panelHautBesoin;
        private Label label3;
        private CControleParenteeObjetHierarchique m_panelHierarchie;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private CheckBox m_chkAsyncUpdate;
        private PictureBox m_picNoEndDate;
        private Panel m_panelEndedWithoutDate;
        private PictureBox m_picEnded;
        private Label m_lblEndedNoDate;
        private Panel m_panelStartedWithoutDate;
        private Label m_lblStartedNoDate;
        private PictureBox m_picNoStartDate;
        private PictureBox m_picStarted;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionProjet));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelStartedWithoutDate = new System.Windows.Forms.Panel();
            this.m_lblStartedNoDate = new System.Windows.Forms.Label();
            this.m_picNoStartDate = new System.Windows.Forms.PictureBox();
            this.m_picStarted = new System.Windows.Forms.PictureBox();
            this.m_panelEndedWithoutDate = new System.Windows.Forms.Panel();
            this.m_lblEndedNoDate = new System.Windows.Forms.Label();
            this.m_picNoEndDate = new System.Windows.Forms.PictureBox();
            this.m_picEnded = new System.Windows.Forms.PictureBox();
            this.m_lblProject = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_panelHierarchie = new sc2i.win32.data.navigation.CControleParenteeObjetHierarchique();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_chkAsyncUpdate = new System.Windows.Forms.CheckBox();
            this.m_panelPrevisionnel = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkDoModificationsPrevisionnelles = new System.Windows.Forms.LinkLabel();
            this.m_lnkSubTypes = new System.Windows.Forms.LinkLabel();
            this.m_chkDatesAuto = new System.Windows.Forms.CheckBox();
            this.m_selectTypeProjet = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkDroits = new System.Windows.Forms.LinkLabel();
            this.m_lblTypeTable = new System.Windows.Forms.Label();
            this.m_dtpDateDebutReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtpDateFinReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_dtpDatesPrevisionnelles = new timos.win32.composants.CDateTimePickerForContextMenu();
            this.m_lblDateDebut = new System.Windows.Forms.Label();
            this.m_lblDateFin = new System.Windows.Forms.Label();
            this.m_txtDescrip = new sc2i.win32.common.C2iTextBox();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_wndListeEquipements = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageGantt = new Crownwood.Magic.Controls.TabPage();
            this.m_gantt = new timos.projet.gantt.CControlGanttProjet();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_pageFils = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelProjetsFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageInfos = new Crownwood.Magic.Controls.TabPage();
            this.m_panelBesoins = new System.Windows.Forms.Panel();
            this.m_wndSpecifications = new timos.projet.besoin.CControleListeBesoins();
            this.m_panelHautBesoin = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelContraintes = new timos.projet.gantt.CPanelEditContraintesDeProjet();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pageEOS = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageDroits = new Crownwood.Magic.Controls.TabPage();
            this.m_panelRestrictions = new timos.Securite.CPanelRestrictionsSpecifiques();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_wndListeSite = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.m_menuSousTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_panelStartedWithoutDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picNoStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picStarted)).BeginInit();
            this.m_panelEndedWithoutDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picNoEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picEnded)).BeginInit();
            this.panel2.SuspendLayout();
            this.m_panelPrevisionnel.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageGantt.SuspendLayout();
            this.m_pageFils.SuspendLayout();
            this.m_pageInfos.SuspendLayout();
            this.m_panelBesoins.SuspendLayout();
            this.m_panelHautBesoin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_pageContraintes.SuspendLayout();
            this.m_pageEOS.SuspendLayout();
            this.m_pageDroits.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
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
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
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
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(687, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(579, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(894, 28);
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
            this.label1.Text = "Site type label|170";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(98, 21);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(286, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_panelStartedWithoutDate);
            this.m_panTop.Controls.Add(this.m_panelEndedWithoutDate);
            this.m_panTop.Controls.Add(this.m_lblProject);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.panel2);
            this.m_panTop.Controls.Add(this.m_chkAsyncUpdate);
            this.m_panTop.Controls.Add(this.m_panelPrevisionnel);
            this.m_panTop.Controls.Add(this.m_lnkSubTypes);
            this.m_panTop.Controls.Add(this.m_chkDatesAuto);
            this.m_panTop.Controls.Add(this.m_selectTypeProjet);
            this.m_panTop.Controls.Add(this.m_lnkDroits);
            this.m_panTop.Controls.Add(this.m_lblTypeTable);
            this.m_panTop.Controls.Add(this.m_dtpDateDebutReelle);
            this.m_panTop.Controls.Add(this.m_dtpDateFinReelle);
            this.m_panTop.Controls.Add(this.m_dtpDatesPrevisionnelles);
            this.m_panTop.Controls.Add(this.m_lblDateDebut);
            this.m_panTop.Controls.Add(this.m_lblDateFin);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(12, 43);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(882, 122);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_panelStartedWithoutDate
            // 
            this.m_panelStartedWithoutDate.Controls.Add(this.m_lblStartedNoDate);
            this.m_panelStartedWithoutDate.Controls.Add(this.m_picNoStartDate);
            this.m_panelStartedWithoutDate.Controls.Add(this.m_picStarted);
            this.m_extLinkField.SetLinkField(this.m_panelStartedWithoutDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelStartedWithoutDate, false);
            this.m_panelStartedWithoutDate.Location = new System.Drawing.Point(630, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStartedWithoutDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelStartedWithoutDate, "");
            this.m_panelStartedWithoutDate.Name = "m_panelStartedWithoutDate";
            this.m_panelStartedWithoutDate.Size = new System.Drawing.Size(236, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelStartedWithoutDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelStartedWithoutDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStartedWithoutDate.TabIndex = 4026;
            // 
            // m_lblStartedNoDate
            // 
            this.m_lblStartedNoDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lblStartedNoDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblStartedNoDate, false);
            this.m_lblStartedNoDate.Location = new System.Drawing.Point(32, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblStartedNoDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblStartedNoDate, "");
            this.m_lblStartedNoDate.Name = "m_lblStartedNoDate";
            this.m_lblStartedNoDate.Size = new System.Drawing.Size(193, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblStartedNoDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblStartedNoDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStartedNoDate.TabIndex = 4026;
            this.m_lblStartedNoDate.Text = "Started but unknown date|10424";
            this.m_lblStartedNoDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_picNoStartDate
            // 
            this.m_picNoStartDate.BackgroundImage = global::timos.Properties.Resources.interrogation;
            this.m_picNoStartDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_picNoStartDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_picNoStartDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_picNoStartDate, false);
            this.m_picNoStartDate.Location = new System.Drawing.Point(16, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picNoStartDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_picNoStartDate, "");
            this.m_picNoStartDate.Name = "m_picNoStartDate";
            this.m_picNoStartDate.Size = new System.Drawing.Size(16, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picNoStartDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picNoStartDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picNoStartDate.TabIndex = 4025;
            this.m_picNoStartDate.TabStop = false;
            // 
            // m_picStarted
            // 
            this.m_picStarted.BackgroundImage = global::timos.Properties.Resources.Projet_démarré_16;
            this.m_picStarted.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_picStarted.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_picStarted, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_picStarted, false);
            this.m_picStarted.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picStarted, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_picStarted, "");
            this.m_picStarted.Name = "m_picStarted";
            this.m_picStarted.Size = new System.Drawing.Size(16, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picStarted, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picStarted, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picStarted.TabIndex = 4027;
            this.m_picStarted.TabStop = false;
            // 
            // m_panelEndedWithoutDate
            // 
            this.m_panelEndedWithoutDate.Controls.Add(this.m_lblEndedNoDate);
            this.m_panelEndedWithoutDate.Controls.Add(this.m_picNoEndDate);
            this.m_panelEndedWithoutDate.Controls.Add(this.m_picEnded);
            this.m_extLinkField.SetLinkField(this.m_panelEndedWithoutDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEndedWithoutDate, false);
            this.m_panelEndedWithoutDate.Location = new System.Drawing.Point(630, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEndedWithoutDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEndedWithoutDate, "");
            this.m_panelEndedWithoutDate.Name = "m_panelEndedWithoutDate";
            this.m_panelEndedWithoutDate.Size = new System.Drawing.Size(236, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelEndedWithoutDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEndedWithoutDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEndedWithoutDate.TabIndex = 4026;
            // 
            // m_lblEndedNoDate
            // 
            this.m_lblEndedNoDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lblEndedNoDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblEndedNoDate, false);
            this.m_lblEndedNoDate.Location = new System.Drawing.Point(32, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEndedNoDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEndedNoDate, "");
            this.m_lblEndedNoDate.Name = "m_lblEndedNoDate";
            this.m_lblEndedNoDate.Size = new System.Drawing.Size(193, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblEndedNoDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEndedNoDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEndedNoDate.TabIndex = 4026;
            this.m_lblEndedNoDate.Text = "Ended but unknown date|10423";
            this.m_lblEndedNoDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_picNoEndDate
            // 
            this.m_picNoEndDate.BackgroundImage = global::timos.Properties.Resources.interrogation;
            this.m_picNoEndDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_picNoEndDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_picNoEndDate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_picNoEndDate, false);
            this.m_picNoEndDate.Location = new System.Drawing.Point(16, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picNoEndDate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_picNoEndDate, "");
            this.m_picNoEndDate.Name = "m_picNoEndDate";
            this.m_picNoEndDate.Size = new System.Drawing.Size(16, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picNoEndDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picNoEndDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picNoEndDate.TabIndex = 4025;
            this.m_picNoEndDate.TabStop = false;
            // 
            // m_picEnded
            // 
            this.m_picEnded.BackgroundImage = global::timos.Properties.Resources.Projet_terminé_16;
            this.m_picEnded.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_picEnded.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_picEnded, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_picEnded, false);
            this.m_picEnded.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_picEnded, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_picEnded, "");
            this.m_picEnded.Name = "m_picEnded";
            this.m_picEnded.Size = new System.Drawing.Size(16, 20);
            this.m_extStyle.SetStyleBackColor(this.m_picEnded, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_picEnded, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picEnded.TabIndex = 4027;
            this.m_picEnded.TabStop = false;
            // 
            // m_lblProject
            // 
            this.m_lblProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblProject.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblProject, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblProject, false);
            this.m_lblProject.Location = new System.Drawing.Point(6, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProject, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblProject, "");
            this.m_lblProject.Name = "m_lblProject";
            this.m_lblProject.Size = new System.Drawing.Size(92, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProject.TabIndex = 4005;
            this.m_lblProject.Text = "Project label |745";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.m_panelHierarchie);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(0, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 17);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 4023;
            // 
            // m_panelHierarchie
            // 
            this.m_panelHierarchie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelHierarchie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelHierarchie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelHierarchie, false);
            this.m_panelHierarchie.Location = new System.Drawing.Point(118, 0);
            this.m_panelHierarchie.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHierarchie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelHierarchie, "");
            this.m_panelHierarchie.Name = "m_panelHierarchie";
            this.m_panelHierarchie.Size = new System.Drawing.Size(748, 17);
            this.m_extStyle.SetStyleBackColor(this.m_panelHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHierarchie.TabIndex = 4022;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(6, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4023;
            this.label4.Text = "Projet hierarchy|20753";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(6, 17);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4024;
            // 
            // m_chkAsyncUpdate
            // 
            this.m_chkAsyncUpdate.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAsyncUpdate, "ModeUpdateAsynchrone");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAsyncUpdate, true);
            this.m_chkAsyncUpdate.Location = new System.Drawing.Point(32, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAsyncUpdate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAsyncUpdate, "");
            this.m_chkAsyncUpdate.Name = "m_chkAsyncUpdate";
            this.m_chkAsyncUpdate.Size = new System.Drawing.Size(126, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAsyncUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAsyncUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAsyncUpdate.TabIndex = 4024;
            this.m_chkAsyncUpdate.Text = "Async. update|20799";
            this.m_chkAsyncUpdate.UseVisualStyleBackColor = true;
            // 
            // m_panelPrevisionnel
            // 
            this.m_panelPrevisionnel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelPrevisionnel.Controls.Add(this.m_lnkDoModificationsPrevisionnelles);
            this.m_extLinkField.SetLinkField(this.m_panelPrevisionnel, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelPrevisionnel, false);
            this.m_panelPrevisionnel.Location = new System.Drawing.Point(385, 85);
            this.m_panelPrevisionnel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPrevisionnel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelPrevisionnel, "");
            this.m_panelPrevisionnel.Name = "m_panelPrevisionnel";
            this.m_panelPrevisionnel.Size = new System.Drawing.Size(389, 16);
            this.m_extStyle.SetStyleBackColor(this.m_panelPrevisionnel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPrevisionnel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPrevisionnel.TabIndex = 4020;
            // 
            // m_lnkDoModificationsPrevisionnelles
            // 
            this.m_lnkDoModificationsPrevisionnelles.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_lnkDoModificationsPrevisionnelles.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDoModificationsPrevisionnelles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.m_lnkDoModificationsPrevisionnelles.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_lnkDoModificationsPrevisionnelles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDoModificationsPrevisionnelles, false);
            this.m_lnkDoModificationsPrevisionnelles.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDoModificationsPrevisionnelles, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDoModificationsPrevisionnelles, "");
            this.m_lnkDoModificationsPrevisionnelles.Name = "m_lnkDoModificationsPrevisionnelles";
            this.m_lnkDoModificationsPrevisionnelles.Size = new System.Drawing.Size(187, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDoModificationsPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDoModificationsPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDoModificationsPrevisionnelles.TabIndex = 0;
            this.m_lnkDoModificationsPrevisionnelles.TabStop = true;
            this.m_lnkDoModificationsPrevisionnelles.Text = "Associated modifications|20379";
            this.m_lnkDoModificationsPrevisionnelles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkDoModificationsPrevisionnelles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDoModificationsPrevisionnelles_LinkClicked);
            // 
            // m_lnkSubTypes
            // 
            this.m_lnkSubTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkSubTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSubTypes, false);
            this.m_lnkSubTypes.Location = new System.Drawing.Point(678, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSubTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkSubTypes, "");
            this.m_lnkSubTypes.Name = "m_lnkSubTypes";
            this.m_lnkSubTypes.Size = new System.Drawing.Size(79, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSubTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSubTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSubTypes.TabIndex = 4022;
            this.m_lnkSubTypes.TabStop = true;
            this.m_lnkSubTypes.Text = "SubTypes|20585";
            this.m_lnkSubTypes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSubTypes_LinkClicked);
            // 
            // m_chkDatesAuto
            // 
            this.m_extLinkField.SetLinkField(this.m_chkDatesAuto, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkDatesAuto, false);
            this.m_chkDatesAuto.Location = new System.Drawing.Point(170, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDatesAuto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkDatesAuto, "");
            this.m_chkDatesAuto.Name = "m_chkDatesAuto";
            this.m_chkDatesAuto.Size = new System.Drawing.Size(146, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkDatesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDatesAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDatesAuto.TabIndex = 4017;
            this.m_chkDatesAuto.Text = "Automatic dates|10080";
            this.m_chkDatesAuto.UseVisualStyleBackColor = true;
            // 
            // m_selectTypeProjet
            // 
            this.m_selectTypeProjet.ComportementLinkStd = true;
            this.m_selectTypeProjet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_selectTypeProjet.ElementSelectionne = null;
            this.m_selectTypeProjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeProjet.FormattingEnabled = true;
            this.m_selectTypeProjet.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeProjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeProjet, false);
            this.m_selectTypeProjet.LinkProperty = "";
            this.m_selectTypeProjet.ListDonnees = null;
            this.m_selectTypeProjet.Location = new System.Drawing.Point(489, 20);
            this.m_selectTypeProjet.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeProjet, "");
            this.m_selectTypeProjet.Name = "m_selectTypeProjet";
            this.m_selectTypeProjet.NullAutorise = false;
            this.m_selectTypeProjet.ProprieteAffichee = null;
            this.m_selectTypeProjet.ProprieteParentListeObjets = null;
            this.m_selectTypeProjet.SelectionneurParent = null;
            this.m_selectTypeProjet.Size = new System.Drawing.Size(184, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeProjet.TabIndex = 4019;
            this.m_selectTypeProjet.TextNull = "(empty)";
            this.m_selectTypeProjet.Tri = true;
            this.m_selectTypeProjet.TypeFormEdition = null;
            this.m_selectTypeProjet.SelectionChangeCommitted += new System.EventHandler(this.m_selectTypeProjet_SelectionChangeCommitted);
            // 
            // m_lnkDroits
            // 
            this.m_lnkDroits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkDroits.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkDroits, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDroits, false);
            this.m_lnkDroits.Location = new System.Drawing.Point(797, 93);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDroits, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkDroits, "");
            this.m_lnkDroits.Name = "m_lnkDroits";
            this.m_lnkDroits.Size = new System.Drawing.Size(69, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDroits.TabIndex = 4021;
            this.m_lnkDroits.TabStop = true;
            this.m_lnkDroits.Text = "Rights|20541";
            this.m_lnkDroits.Visible = false;
            // 
            // m_lblTypeTable
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeTable, false);
            this.m_lblTypeTable.Location = new System.Drawing.Point(390, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeTable, "");
            this.m_lblTypeTable.Name = "m_lblTypeTable";
            this.m_lblTypeTable.Size = new System.Drawing.Size(96, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeTable.TabIndex = 4016;
            this.m_lblTypeTable.Text = "Project Type|1215";
            // 
            // m_dtpDateDebutReelle
            // 
            this.m_dtpDateDebutReelle.Checked = true;
            this.m_dtpDateDebutReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateDebutReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateDebutReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateDebutReelle, false);
            this.m_dtpDateDebutReelle.Location = new System.Drawing.Point(494, 42);
            this.m_dtpDateDebutReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateDebutReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateDebutReelle, "");
            this.m_dtpDateDebutReelle.Name = "m_dtpDateDebutReelle";
            this.m_dtpDateDebutReelle.Size = new System.Drawing.Size(130, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateDebutReelle.TabIndex = 2;
            this.m_dtpDateDebutReelle.TextNull = "None";
            this.m_dtpDateDebutReelle.Value.DateTimeValue = new System.DateTime(2014, 9, 23, 10, 12, 11, 298);
            this.m_dtpDateDebutReelle.OnValueChange += new System.EventHandler(this.m_dtpDateDebut_OnValueChange);
            // 
            // m_dtpDateFinReelle
            // 
            this.m_dtpDateFinReelle.Checked = true;
            this.m_dtpDateFinReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateFinReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateFinReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateFinReelle, false);
            this.m_dtpDateFinReelle.Location = new System.Drawing.Point(494, 63);
            this.m_dtpDateFinReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateFinReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateFinReelle, "");
            this.m_dtpDateFinReelle.Name = "m_dtpDateFinReelle";
            this.m_dtpDateFinReelle.Size = new System.Drawing.Size(130, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateFinReelle.TabIndex = 3;
            this.m_dtpDateFinReelle.TextNull = "None";
            this.m_dtpDateFinReelle.Value.DateTimeValue = new System.DateTime(2014, 9, 23, 10, 12, 11, 305);
            this.m_dtpDateFinReelle.OnValueChange += new System.EventHandler(this.m_dtpDateFin_OnValueChange);
            // 
            // m_dtpDatesPrevisionnelles
            // 
            this.m_dtpDatesPrevisionnelles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_dtpDatesPrevisionnelles.BoutonValiderVisible = false;
            this.m_dtpDatesPrevisionnelles.EndDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_dtpDatesPrevisionnelles.Libelle1 = "Planned start date|10078";
            this.m_dtpDatesPrevisionnelles.Libelle2 = "Planned end date|10079";
            this.m_extLinkField.SetLinkField(this.m_dtpDatesPrevisionnelles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDatesPrevisionnelles, false);
            this.m_dtpDatesPrevisionnelles.Location = new System.Drawing.Point(28, 42);
            this.m_dtpDatesPrevisionnelles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDatesPrevisionnelles, "");
            this.m_dtpDatesPrevisionnelles.Name = "m_dtpDatesPrevisionnelles";
            this.m_dtpDatesPrevisionnelles.Size = new System.Drawing.Size(317, 43);
            this.m_dtpDatesPrevisionnelles.StartDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDatesPrevisionnelles.TabIndex = 4018;
            // 
            // m_lblDateDebut
            // 
            this.m_lblDateDebut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateDebut.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateDebut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateDebut, false);
            this.m_lblDateDebut.Location = new System.Drawing.Point(388, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateDebut, "");
            this.m_lblDateDebut.Name = "m_lblDateDebut";
            this.m_lblDateDebut.Size = new System.Drawing.Size(120, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateDebut.TabIndex = 4005;
            this.m_lblDateDebut.Text = "True start date|10075";
            this.m_lblDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDateFin
            // 
            this.m_lblDateFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateFin.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateFin, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateFin, false);
            this.m_lblDateFin.Location = new System.Drawing.Point(388, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateFin, "");
            this.m_lblDateFin.Name = "m_lblDateFin";
            this.m_lblDateFin.Size = new System.Drawing.Size(120, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateFin.TabIndex = 4005;
            this.m_lblDateFin.Text = "True end date|10076";
            this.m_lblDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDescrip
            // 
            this.m_txtDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescrip.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescrip, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescrip, true);
            this.m_txtDescrip.Location = new System.Drawing.Point(6, 18);
            this.m_txtDescrip.LockEdition = false;
            this.m_txtDescrip.MaxLength = 2000;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescrip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescrip, "");
            this.m_txtDescrip.Multiline = true;
            this.m_txtDescrip.Name = "m_txtDescrip";
            this.m_txtDescrip.Size = new System.Drawing.Size(857, 70);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescrip.TabIndex = 5;
            this.m_txtDescrip.Text = "[Description]";
            // 
            // m_lblDescription
            // 
            this.m_lblDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDescription.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDescription, false);
            this.m_lblDescription.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescription, "");
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(185, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 4005;
            this.m_lblDescription.Text = "Project description|1233";
            // 
            // m_wndListeEquipements
            // 
            this.m_wndListeEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEquipements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeEquipements.EnableCustomisation = true;
            this.m_wndListeEquipements.FullRowSelect = true;
            this.m_wndListeEquipements.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeEquipements, false);
            this.m_wndListeEquipements.Location = new System.Drawing.Point(13, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeEquipements, "");
            this.m_wndListeEquipements.MultiSelect = false;
            this.m_wndListeEquipements.Name = "m_wndListeEquipements";
            this.m_wndListeEquipements.Size = new System.Drawing.Size(771, 168);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEquipements.TabIndex = 4008;
            this.m_wndListeEquipements.UseCompatibleStateImageBehavior = false;
            this.m_wndListeEquipements.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
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
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageGantt;
            this.m_TabControl.Size = new System.Drawing.Size(882, 344);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageGantt,
            this.m_pageFils,
            this.m_pageInfos,
            this.m_pageContraintes,
            this.m_pageEOS,
            this.m_pageDroits,
            this.m_pageFormulaires});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            this.m_TabControl.SelectionChanged += new System.EventHandler(this.m_TabControl_SelectionChanged);
            // 
            // m_pageGantt
            // 
            this.m_pageGantt.Controls.Add(this.m_gantt);
            this.m_pageGantt.Controls.Add(this.m_panelMarge);
            this.m_extLinkField.SetLinkField(this.m_pageGantt, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageGantt, false);
            this.m_pageGantt.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageGantt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageGantt, "");
            this.m_pageGantt.Name = "m_pageGantt";
            this.m_pageGantt.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageGantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageGantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageGantt.TabIndex = 19;
            this.m_pageGantt.Title = "Gantt|20168";
            // 
            // m_gantt
            // 
            this.m_gantt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_gantt, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_gantt, false);
            this.m_gantt.Location = new System.Drawing.Point(0, 20);
            this.m_gantt.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_gantt, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_gantt, "");
            this.m_gantt.Name = "m_gantt";
            this.m_gantt.Size = new System.Drawing.Size(866, 283);
            this.m_extStyle.SetStyleBackColor(this.m_gantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_gantt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_gantt.TabIndex = 0;
            this.m_gantt.OnMoveElementDeGantt += new timos.win32.gantt.OnMoveGanttElement(this.m_gantt_OnMoveElementDeGantt);
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelMarge, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMarge, false);
            this.m_panelMarge.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelMarge, "");
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(866, 20);
            this.m_extStyle.SetStyleBackColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMarge.TabIndex = 1;
            // 
            // m_pageFils
            // 
            this.m_pageFils.Controls.Add(this.m_PanelProjetsFils);
            this.m_extLinkField.SetLinkField(this.m_pageFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFils, false);
            this.m_pageFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFils, "");
            this.m_pageFils.Name = "m_pageFils";
            this.m_pageFils.Selected = false;
            this.m_pageFils.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFils.TabIndex = 20;
            this.m_pageFils.Title = "Child projets|10077";
            // 
            // m_PanelProjetsFils
            // 
            this.m_PanelProjetsFils.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_PanelProjetsFils.AffectationsPourNouveauxElements")));
            this.m_PanelProjetsFils.AllowArbre = true;
            this.m_PanelProjetsFils.AllowCustomisation = true;
            this.m_PanelProjetsFils.AllowSerializePreferences = true;
            this.m_PanelProjetsFils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            this.m_PanelProjetsFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_PanelProjetsFils.ContexteUtilisation = "";
            this.m_PanelProjetsFils.ControlFiltreStandard = null;
            this.m_PanelProjetsFils.ElementSelectionne = null;
            this.m_PanelProjetsFils.EnableCustomisation = true;
            this.m_PanelProjetsFils.FiltreDeBase = null;
            this.m_PanelProjetsFils.FiltreDeBaseEnAjout = false;
            this.m_PanelProjetsFils.FiltrePrefere = null;
            this.m_PanelProjetsFils.FiltreRapide = null;
            this.m_PanelProjetsFils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelProjetsFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelProjetsFils, false);
            this.m_PanelProjetsFils.ListeObjets = null;
            this.m_PanelProjetsFils.Location = new System.Drawing.Point(3, 3);
            this.m_PanelProjetsFils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelProjetsFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelProjetsFils.ModeQuickSearch = false;
            this.m_PanelProjetsFils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_PanelProjetsFils, "");
            this.m_PanelProjetsFils.MultiSelect = false;
            this.m_PanelProjetsFils.Name = "m_PanelProjetsFils";
            this.m_PanelProjetsFils.Navigateur = null;
            this.m_PanelProjetsFils.ObjetReferencePourAffectationsInitiales = null;
            this.m_PanelProjetsFils.ProprieteObjetAEditer = null;
            this.m_PanelProjetsFils.QuickSearchText = "";
            this.m_PanelProjetsFils.ShortIcons = false;
            this.m_PanelProjetsFils.Size = new System.Drawing.Size(860, 297);
            this.m_extStyle.SetStyleBackColor(this.m_PanelProjetsFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelProjetsFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelProjetsFils.TabIndex = 1;
            this.m_PanelProjetsFils.TrierAuClicSurEnteteColonne = true;
            this.m_PanelProjetsFils.UseCheckBoxes = false;
            // 
            // m_pageInfos
            // 
            this.m_pageInfos.Controls.Add(this.m_panelBesoins);
            this.m_pageInfos.Controls.Add(this.splitter1);
            this.m_pageInfos.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageInfos, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageInfos, false);
            this.m_pageInfos.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInfos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInfos, "");
            this.m_pageInfos.Name = "m_pageInfos";
            this.m_pageInfos.Selected = false;
            this.m_pageInfos.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInfos.TabIndex = 17;
            this.m_pageInfos.Title = "Information|119";
            // 
            // m_panelBesoins
            // 
            this.m_panelBesoins.Controls.Add(this.m_wndSpecifications);
            this.m_panelBesoins.Controls.Add(this.m_panelHautBesoin);
            this.m_panelBesoins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelBesoins, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelBesoins, false);
            this.m_panelBesoins.Location = new System.Drawing.Point(0, 94);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelBesoins, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelBesoins, "APROJECT_NEEDS");
            this.m_panelBesoins.Name = "m_panelBesoins";
            this.m_panelBesoins.Size = new System.Drawing.Size(866, 209);
            this.m_extStyle.SetStyleBackColor(this.m_panelBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBesoins, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBesoins.TabIndex = 4009;
            // 
            // m_wndSpecifications
            // 
            this.m_wndSpecifications.CurrentItemIndex = null;
            this.m_wndSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.m_wndSpecifications.ItemControl = null;
            this.m_wndSpecifications.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_extLinkField.SetLinkField(this.m_wndSpecifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndSpecifications, false);
            this.m_wndSpecifications.Location = new System.Drawing.Point(0, 21);
            this.m_wndSpecifications.LockEdition = false;
            this.m_wndSpecifications.ModeAffichage = timos.projet.besoin.EModeAffichageBesoins.ModeSansCout;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndSpecifications, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndSpecifications, "");
            this.m_wndSpecifications.Name = "m_wndSpecifications";
            this.m_wndSpecifications.Size = new System.Drawing.Size(866, 188);
            this.m_extStyle.SetStyleBackColor(this.m_wndSpecifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndSpecifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndSpecifications.TabIndex = 4008;
            // 
            // m_panelHautBesoin
            // 
            this.m_panelHautBesoin.Controls.Add(this.label3);
            this.m_panelHautBesoin.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelHautBesoin, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelHautBesoin, false);
            this.m_panelHautBesoin.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHautBesoin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelHautBesoin, "");
            this.m_panelHautBesoin.Name = "m_panelHautBesoin";
            this.m_panelHautBesoin.Size = new System.Drawing.Size(866, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelHautBesoin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelHautBesoin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelHautBesoin.TabIndex = 4009;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(266, 21);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Project needs|20630";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(0, 91);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(866, 3);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 4007;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblDescription);
            this.panel1.Controls.Add(this.m_txtDescrip);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 91);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4006;
            // 
            // m_pageContraintes
            // 
            this.m_pageContraintes.Controls.Add(this.m_panelContraintes);
            this.m_pageContraintes.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_pageContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageContraintes, false);
            this.m_pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageContraintes, "");
            this.m_pageContraintes.Name = "m_pageContraintes";
            this.m_pageContraintes.Selected = false;
            this.m_pageContraintes.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageContraintes.TabIndex = 18;
            this.m_pageContraintes.Title = "Project Constraints|10085";
            // 
            // m_panelContraintes
            // 
            this.m_panelContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelContraintes, false);
            this.m_panelContraintes.Location = new System.Drawing.Point(3, 26);
            this.m_panelContraintes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContraintes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelContraintes, "");
            this.m_panelContraintes.Name = "m_panelContraintes";
            this.m_panelContraintes.Size = new System.Drawing.Size(739, 274);
            this.m_extStyle.SetStyleBackColor(this.m_panelContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelContraintes.TabIndex = 0;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(6, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(467, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4016;
            this.label2.Text = "Constraints list. Clic on Add to create a new constraint|10086";
            // 
            // m_pageEOS
            // 
            this.m_pageEOS.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.m_pageEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEOS, false);
            this.m_pageEOS.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOS, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEOS, "");
            this.m_pageEOS.Name = "m_pageEOS";
            this.m_pageEOS.Selected = false;
            this.m_pageEOS.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEOS.TabIndex = 21;
            this.m_pageEOS.Title = "Organizational entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEOS, false);
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 2;
            // 
            // m_pageDroits
            // 
            this.m_pageDroits.Controls.Add(this.m_panelRestrictions);
            this.m_extLinkField.SetLinkField(this.m_pageDroits, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageDroits, false);
            this.m_pageDroits.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDroits, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDroits, "");
            this.m_pageDroits.Name = "m_pageDroits";
            this.m_pageDroits.Selected = false;
            this.m_pageDroits.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDroits, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDroits.TabIndex = 22;
            this.m_pageDroits.Title = "Rights management|20543";
            // 
            // m_panelRestrictions
            // 
            this.m_panelRestrictions.AutoScroll = true;
            this.m_panelRestrictions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelRestrictions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelRestrictions.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelRestrictions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelRestrictions, false);
            this.m_panelRestrictions.Location = new System.Drawing.Point(0, 0);
            this.m_panelRestrictions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelRestrictions, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelRestrictions, "");
            this.m_panelRestrictions.Name = "m_panelRestrictions";
            this.m_panelRestrictions.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRestrictions.TabIndex = 1;
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_PanelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, false);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Selected = false;
            this.m_pageFormulaires.Size = new System.Drawing.Size(866, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 16;
            this.m_pageFormulaires.Title = "Properties|49";
            // 
            // m_PanelChamps
            // 
            this.m_PanelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChamps.BoldSelectedPage = true;
            this.m_PanelChamps.ElementEdite = null;
            this.m_PanelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelChamps, false);
            this.m_PanelChamps.Location = new System.Drawing.Point(3, 3);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(860, 297);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 1;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_wndListeSite
            // 
            this.m_wndListeSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeSite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1});
            this.m_wndListeSite.EnableCustomisation = true;
            this.m_wndListeSite.FullRowSelect = true;
            this.m_wndListeSite.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeSite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeSite, false);
            this.m_wndListeSite.Location = new System.Drawing.Point(13, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeSite, "");
            this.m_wndListeSite.MultiSelect = false;
            this.m_wndListeSite.Name = "m_wndListeSite";
            this.m_wndListeSite.Size = new System.Drawing.Size(772, 203);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSite.TabIndex = 4007;
            this.m_wndListeSite.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSite.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = null;
            this.m_ctrlSavProfilDesigner.Formulaire = null;
            // 
            // m_reducteurTop
            // 
            this.m_reducteurTop.ControleAgrandit = this.m_TabControl;
            this.m_reducteurTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurTop.ControleReduit = this.m_panTop;
            this.m_extLinkField.SetLinkField(this.m_reducteurTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_reducteurTop, false);
            this.m_reducteurTop.Location = new System.Drawing.Point(449, 39);
            this.m_reducteurTop.MargeControle = 20;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurTop, "");
            this.m_reducteurTop.Name = "m_reducteurTop";
            this.m_reducteurTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurTop.TabIndex = 4021;
            this.m_reducteurTop.TailleReduite = 32;
            // 
            // m_menuSousTypes
            // 
            this.m_extLinkField.SetLinkField(this.m_menuSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuSousTypes, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuSousTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuSousTypes, "");
            this.m_menuSousTypes.Name = "m_menuSousTypes";
            this.m_menuSousTypes.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormEditionProjet
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(894, 530);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionProjet";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionProjet_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionProjet_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_reducteurTop, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_panelStartedWithoutDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picNoStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picStarted)).EndInit();
            this.m_panelEndedWithoutDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picNoEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picEnded)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.m_panelPrevisionnel.ResumeLayout(false);
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageGantt.ResumeLayout(false);
            this.m_pageFils.ResumeLayout(false);
            this.m_pageInfos.ResumeLayout(false);
            this.m_panelBesoins.ResumeLayout(false);
            this.m_panelHautBesoin.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_pageContraintes.ResumeLayout(false);
            this.m_pageEOS.ResumeLayout(false);
            this.m_pageDroits.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public CFormEditionProjet()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionProjet(CProjet proj)
            : base(proj)
		{
			InitializeComponent();
#if DEBUG
            
#else
            m_panelBesoins.Visible = false;
#endif
		}
		//-------------------------------------------------------------------------
        public CFormEditionProjet(CProjet proj, CListeObjetsDonnees liste)
            : base(proj, liste)
		{
			InitializeComponent();
#if DEBUG

#else
            m_panelBesoins.Visible = false;
#endif

        }

		//-------------------------------------------------------------------------
		private CProjet Projet
		{
			get	{ return (CProjet)ObjetEdite;	}
		}

        private void UpdateVisuPrevisionnel()
        {
            m_panelPrevisionnel.Visible = Projet.VersionDonneesAppliquee != null ||
                Projet.TypeProjet != null && Projet.TypeProjet.OptionVersion.Code != timos.data.projet.EOptionTypeProjetVersion.NoVersion;
        }

		//-------------------------------------------------------------------------
		private bool m_bInitialise = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bInitialise = false;

            if (m_TabControl.TabPages.Contains(m_pageDroits))
                m_TabControl.TabPages.Remove(m_pageDroits);

            CResultAErreur result = base.MyInitChamps();

            
			AffecterTitre(I.T( "Project @1|1216", Projet.Libelle));

            UpdateVisuPrevisionnel();
            
		
            m_panelHierarchie.Init(Projet);

			//CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeProjet));
            if (Projet.Projet != null && Projet.Projet.TypeProjet != null)
                m_selectTypeProjet.Init(Projet.Projet.TypeProjet.TypesProjetsFilsPossibles, "Libelle", true);
            else if (Projet.Projet == null)
                    m_selectTypeProjet.Init(
                        new CListeObjetsDonnees(Projet.ContexteDonnee, typeof(CTypeProjet), new CFiltreData(CTypeProjet.c_champNeedHierarchy + "=@1", false)),
                        "Libelle",
                        true);
            else
                m_selectTypeProjet.Init(typeof(CTypeProjet), null, "Libelle", true);
            
			m_selectTypeProjet.ElementSelectionne = Projet.TypeProjet;

            // Dates prévisionnelles
            if (Projet.DateDebutPlanifiee != null)
                m_dtpDatesPrevisionnelles.StartDate = Projet.DateDebutPlanifiee.Value;
            else
                m_dtpDatesPrevisionnelles.StartDate = DateTime.Now;
            if (Projet.DateFinPlanifiee != null)
                m_dtpDatesPrevisionnelles.EndDate = Projet.DateFinPlanifiee.Value;
            else if (Projet.TypeProjet != null && Projet.TypeProjet.DureeDefautHeures > 0.0)
                m_dtpDatesPrevisionnelles.EndDate = m_dtpDatesPrevisionnelles.StartDate.AddHours(Projet.TypeProjet.DureeDefautHeures);
            else
                m_dtpDatesPrevisionnelles.EndDate = m_dtpDatesPrevisionnelles.StartDate.AddDays(7);

            m_dtpDatesPrevisionnelles.Libelle1 = I.T("Planned start date|10078");
            m_dtpDatesPrevisionnelles.Libelle2 = I.T("Planned end date|10079");

            // Dates réelles
			if(Projet.DateDebutReel != null)
				m_dtpDateDebutReelle.Value = new CDateTimeEx((DateTime)Projet.DateDebutReel);
			else
				m_dtpDateDebutReelle.Value = null;

			if (Projet.DateFinRelle != null)
				m_dtpDateFinReelle.Value = new CDateTimeEx((DateTime)Projet.DateFinRelle);
			else
				m_dtpDateFinReelle.Value = null;

            UpdateVisuIconesDates();

            m_chkDatesAuto.Checked = Projet.DateDebutAuto;

            m_extLinkField.FillDialogFromObjet(Projet);

            UpdateVisuOnglets();

            m_dtpDateDebutReelle.LockEdition = !ModeEdition || Projet.ProjetsFils.Count > 0;
            m_dtpDateFinReelle.LockEdition = m_dtpDateDebutReelle.LockEdition;
            m_dtpDatesPrevisionnelles.LockEdition = m_dtpDateFinReelle.LockEdition;
            RefreshLinkSousTypes();
			m_bInitialise = true;
			return result;
		}

        private void UpdateVisuOnglets()
        {
            if (Projet.GetFormulaires().Length > 0)
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Add(m_pageFormulaires);
            }
            else
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }

        }

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

            if (m_selectTypeProjet.ElementSelectionne != null)
                Projet.TypeProjet = (CTypeProjet)m_selectTypeProjet.ElementSelectionne;

            Projet.DateDebutPlanifiee = m_dtpDatesPrevisionnelles.StartDate;
            Projet.DateFinPlanifiee = m_dtpDatesPrevisionnelles.EndDate;

            Projet.DateDebutReel = m_dtpDateDebutReelle.Value != null ? (DateTime?)m_dtpDateDebutReelle.Value.DateTimeValue : null;
			Projet.DateFinRelle = m_dtpDateFinReelle.Value != null ? (DateTime?)m_dtpDateFinReelle.Value.DateTimeValue : null;

            

            Projet.DateDebutAuto = m_chkDatesAuto.Checked;

			m_extLinkField.FillObjetFromDialog(Projet);

			return result;
		}

		//////////////////////////////////////////////////////
		private void StartAction()
		{
			try
			{
				Projet.CalcAnomaliesInCurrentContext(CFormProgressTimos.Indicateur);
			}
			catch
			{
			}
		}

        //------------------------------------------------------------------------------
		private void m_dtpDateDebut_OnValueChange(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				if (Projet.DateDebutReel == null && m_dtpDateDebutReelle.Value != null)
				{
					m_bInitialise = false;
                    if (Projet.DateDebutPlanifiee != null)
                        m_dtpDateDebutReelle.Value = Projet.DateDebutPlanifiee;
                    else
                        m_dtpDateDebutReelle.Value = new CDateTimeEx(DateTime.Now);
					m_bInitialise = true;
				}
				Projet.DateDebutReel = m_dtpDateDebutReelle.Value != null ? (DateTime?)m_dtpDateDebutReelle.Value.DateTimeValue : null;
			}
		}

        //------------------------------------------------------------------------------
        private void m_dtpDateFin_OnValueChange(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				if (Projet.DateFinRelle == null && m_dtpDateFinReelle.Value != null)
				{
					m_bInitialise = false;
                    if(Projet.DateFinPlanifiee != null)
					    m_dtpDateFinReelle.Value = new CDateTimeEx(Projet.DateFinPlanifiee.Value);
                    else
                        m_dtpDateFinReelle.Value = new CDateTimeEx(DateTime.Now.AddDays(1));
                    m_bInitialise = true;
				}
				Projet.DateFinRelle = m_dtpDateFinReelle.Value != null ? (DateTime?)m_dtpDateFinReelle.Value.DateTimeValue : null;
			}
            UpdateVisuIconesDates();
		}


		//-----------------------------TABCONTROL-----------------------------
		private CResultAErreur CFormEditionProjet_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                if (page == m_pageContraintes)
                {
                    m_panelContraintes.Init(Projet);
                }
                else if (page == m_pageFormulaires)
                {
                    m_PanelChamps.ElementEdite = Projet;

                }
                else if (page == m_pageFils)
                {
                    m_PanelProjetsFils.InitFromListeObjets(
                                        Projet.ProjetsFils,
                                        typeof(CProjet),
                                        typeof(CFormEditionProjet),
                                        Projet,
                                        "Projet");

                }
                else if (page == m_pageGantt)
                {
                    InitGantt();
                }
                else if (page == m_pageEOS)
                    m_panelEOS.Init(Projet);
                else if (page == m_pageDroits)
                    m_panelRestrictions.Init(Projet);
                else if (page == m_pageInfos)
                {
                    IInfoUtilisateur info = CTimosApp.SessionClient.GetInfoUtilisateur();
                    if (info != null)
                    {
                        CRestrictionUtilisateurSurType rest = info.GetRestrictionsSur(typeof(CPhaseSpecifications), Projet.ContexteDonnee.IdVersionDeTravail);
                        CPhaseSpecifications phase = Projet.Specifications;
                        if (phase == null &&
                            m_gestionnaireModeEdition.ModeEdition &&
                            rest.RestrictionGlobale == ERestriction.Aucune)
                            phase = Projet.GetOrCreateSpecifications();
                        m_panelBesoins.Visible = phase != null;
                        m_wndSpecifications.Init(phase);
                    }
                }
			}
			return result;
		}

        private CResultAErreur CFormEditionProjet_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageContraintes)
            {
                m_panelContraintes.MajChamps();
            }
            else if (page == m_pageFormulaires)
            {
                result = m_PanelChamps.MAJ_Champs();
            }
            else if (page == m_pageInfos)
            {
                if (m_wndSpecifications.PhaseSpecifications != null)
                    result = m_wndSpecifications.MajChamps();
            }
            else if (page == m_pageEOS)
                result = m_panelEOS.MajChamps();
            else if (page == m_pageDroits)
                result = m_panelRestrictions.MajChamps();
			return result;

		}


        //-------------------------------------------------------------------------
        private void InitGantt()
        {
            try
            {
                m_gantt.Visible = false;
                m_gantt.Init(Projet);
                m_gantt.Visible = true;
            }
            catch ( Exception e )
            {
            }
        }

        //-------------------------------------------------------------------------
        private void m_selectTypeProjet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_selectTypeProjet.ElementSelectionne != null)
                Projet.TypeProjet = (CTypeProjet)m_selectTypeProjet.ElementSelectionne;
            UpdateVisuPrevisionnel();

            m_PanelChamps.ElementEdite = Projet;
            RefreshLinkSousTypes();
            UpdateVisuOnglets();
        }

        private void m_gantt_OnMoveElementDeGantt(IElementDeGantt element)
        {
            CElementDeGanttProjet elementProjet = element as CElementDeGanttProjet;
            if (elementProjet != null && elementProjet.ProjetAssocie != null && elementProjet.ProjetAssocie == Projet)
            { 
                CProjet projet = elementProjet.ProjetAssocie;
                // Synchronise les controles
                if (projet.DateDebutPlanifiee != null)
                    m_dtpDatesPrevisionnelles.StartDate = elementProjet.ProjetAssocie.DateDebutPlanifiee.Value;
                if (projet.DateFinPlanifiee != null)
                    m_dtpDatesPrevisionnelles.EndDate = elementProjet.ProjetAssocie.DateFinPlanifiee.Value;

                if (projet.DateDebutReel != null)
                    m_dtpDateDebutReelle.Value = projet.DateDebutReel;
                if (projet.DateFinRelle != null)
                    m_dtpDateFinReelle.Value = projet.DateFinRelle;

                m_chkDatesAuto.Checked = Projet.DatesAuto;

            
            }
        }

        public override CContexteFormNavigable GetContexte()
        {
            CContexteFormNavigable ctx = base.GetContexte();
            m_gantt.FillContexteNavigation (  ctx );
            return ctx;
        }


        public override CResultAErreur InitFromContexte(CContexteFormNavigable ctx)
        {
            CResultAErreur result = base.InitFromContexte(ctx);
            if (result)
                m_gantt.InitFromContexteNavigation(ctx);
            return result;
        }

        //--------------------------------------------------------------------
        private void m_lnkDoModificationsPrevisionnelles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            CVersionDonnees version = Projet.VersionDonneesAppliquee;
            CObjetDonneeAIdNumeriqueAuto objetAssocie = Projet.ElementAssociePrincipal as CObjetDonneeAIdNumeriqueAuto;
            if ( objetAssocie == null )
            {
                result.EmpileErreur(I.T("You can not edit modifications while no main associated element is defined (see project type configuration)|20383"));
            }
            CReferenceTypeForm refTypeForm = null;
            if (result)
            {
                refTypeForm = CFormFinder.GetRefFormToEdit(objetAssocie.GetType());
                if (refTypeForm == null)
                {
                    result.EmpileErreur(I.T("Timos can not edit modification on elements @1",
                        DynamicClassAttribute.GetNomConvivial(objetAssocie.GetType())));
                }
            }
            if ( !result )
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }


            bool bCreateVersion = false;
            if (version == null)
            {
                if (Projet.TypeProjet == null)
                    return;
                if (Projet.TypeProjet.OptionVersion.Code != timos.data.projet.EOptionTypeProjetVersion.NoVersion)
                {
                    if (MessageBox.Show(I.T("No associated data version. Create a new one ?|20380"),
                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    bCreateVersion = true;
                }
            }
            else
            {
                if (Projet.VersionDonneesDirectementAssociee == null && Projet.TypeProjet != null &&
                    Projet.TypeProjet.OptionVersion.Code != timos.data.projet.EOptionTypeProjetVersion.NoVersion)
                {
                    bCreateVersion = true;
                }
            }
            if (bCreateVersion)
            {
                CProjet prj = Projet;
                prj.BeginEdit();
                result = prj.CreateDataVersionInCurrentContext();
                if (result)
                    result = prj.CommitEdit();
                else
                {
                    prj.CancelEdit();
                    result.EmpileErreur(I.T("You can not associated modifications to this project|20382"));
                    if (version != null)
                    {
                        CProjet projetParent = Projet.Projet;
                        while (projetParent != null && projetParent.VersionDonneesDirectementAssociee != version)
                            projetParent = projetParent.Projet;
                        if (projetParent != null)
                        {
                            result.EmpileErreur(I.T("You can only associate modification to project @1|20383",
                                projetParent.Libelle));
                        }
                    }                        
                    CFormAlerte.Afficher(result.Erreur);
                    return;
                }
                version = Projet.VersionDonneesAppliquee;
            }
            if (version == null)
                return;

			//Crée un contexte dans la version
			using ( CContexteDonnee contexte = new CContexteDonnee ( Projet.ContexteDonnee.IdSession, true, true ))
			{
				result = contexte.SetVersionDeTravail ( version.Id, true );
				if (!result)
				{
					CFormAfficheErreur.Show(result.Erreur);
					return;
				}

                int nId = objetAssocie.Id;
                objetAssocie = Activator.CreateInstance(objetAssocie.GetType(), new object[] { contexte }) as CObjetDonneeAIdNumeriqueAuto;
                objetAssocie.ReadIfExists(nId);

                IFormNavigable frm = refTypeForm.GetForm(objetAssocie) as IFormNavigable;
                if ( frm == null )
                {
                    result.EmpileErreur(I.T("Timos can not edit modification on elements @1",
                    DynamicClassAttribute.GetNomConvivial(objetAssocie.GetType())));
                    CFormAfficheErreur.Show(result.Erreur);
                    return;
                }
                CFormNavigateurPopup.Show ( frm );
			}
            InitChamps();
        }

        private void m_lnkSubTypes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            m_menuSousTypes.Items.Clear();
            CTypeProjet typeProjet = m_selectTypeProjet.ElementSelectionne as CTypeProjet;
            HashSet<CTypeProjet> typeProjetsInMenu = new HashSet<CTypeProjet>();
            if (typeProjet != null)
            {
                if (m_gestionnaireModeEdition.ModeEdition)
                {
                    foreach (CRelationTypeProjet_SousTypeProjet rel in typeProjet.RelationsSousTypesProjetsPossibles)
                    {
                        ToolStripMenuItem itemSousType = new ToolStripMenuItem(rel.SousTypeProjet.Libelle);
                        itemSousType.Tag = rel.SousTypeProjet;
                        itemSousType.Click += new EventHandler(itemSousType_Click);
                        itemSousType.Checked = Projet.IsDefiniPar(rel.SousTypeProjet);
                        m_menuSousTypes.Items.Add(itemSousType);
                        typeProjetsInMenu.Add(rel.SousTypeProjet);
                    }
                }
                foreach ( CProjet_SousType st in Projet.RelationsSousTypes )
                {
                    if ( !typeProjetsInMenu.Contains ( st.SousType ) )
                    {
                        ToolStripMenuItem itemSousType = new ToolStripMenuItem(st.SousType.Libelle);
                        itemSousType.Tag = st.SousType;
                        itemSousType.Click += new EventHandler(itemSousType_Click);
                        itemSousType.Checked = Projet.IsDefiniPar ( st.SousType );
                        m_menuSousTypes.Items.Add(itemSousType);
                        typeProjetsInMenu.Add ( st.SousType);
                        if ( m_gestionnaireModeEdition.ModeEdition )
                            itemSousType.BackColor = Color.Red;
                        itemSousType.Enabled = m_gestionnaireModeEdition.ModeEdition;
                    }
                }
            }
            if (m_menuSousTypes.Items.Count > 0)
            {
                m_menuSousTypes.Show(m_lnkSubTypes, new Point(0, m_lnkSubTypes.Height));
            }
        }

        void itemSousType_Click(object sender, EventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                CTypeProjet type = item != null ? item.Tag as CTypeProjet : null;
                if (type != null)
                {
                    if (Projet.IsDefiniPar(type))
                        Projet.RemoveSubType(type);
                    else
                        Projet.AddSubType(type);
                }
                m_PanelChamps.ElementEdite = Projet;
            }
            RefreshLinkSousTypes();
        }

        private void RefreshLinkSousTypes()
        {
            if (Projet.RelationsSousTypes.Count > 0)
            {
                m_lnkSubTypes.Text = I.T("SubTypes|20585") + " (" + Projet.RelationsSousTypes.Count + ")";
            }
            else
            {
                m_lnkSubTypes.Text = I.T("SubTypes|20585");
            }
        }

        private void m_TabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void UpdateVisuIconesDates()
        {
            // Date début réelle
            m_picStarted.Visible = Projet.IsStarted;
            m_picNoStartDate.Visible = Projet.StartedWithoutDate;
            m_lblStartedNoDate.Visible = m_picNoStartDate.Visible;

            // Date fin réelle
            m_picEnded.Visible = Projet.IsEnded;
            m_picNoEndDate.Visible = Projet.EndedWithoutDate;
            m_lblEndedNoDate.Visible = m_picNoEndDate.Visible;
        }

	}
}

