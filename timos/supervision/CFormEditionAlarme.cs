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
using timos.data.supervision;
using futurocom.supervision;
using timos.supervision.Masquage;
using timos.data.snmp;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CAlarme))]
	public class CFormEditionAlarme : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code


		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
		private Label m_lblProject;
		private CArbreObjetHierarchique m_ArbreAlarmeHierarchique;
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
        private CReducteurControle m_reducteurTop;
        private Crownwood.Magic.Controls.TabPage m_pageFils;
        private CPanelListeSpeedStandard m_PanelAlarmesFils;
        private CComboBoxLinkListeObjetsDonnees m_selectTypeAlarme;
        private Label label2;
        private Label label3;
        private C2iDateTimeExPicker m_dtpDateAcquittement;
        private LinkLabel m_lnkRetomber;
        private LinkLabel m_lnkAcquitter;
        private Crownwood.Magic.Controls.TabPage m_pageElementsSupervises;
        private Label label6;
        private Label label5;
        private Label label4;
        private C2iTextBoxSelectionne m_selectLienReseau;
        private C2iTextBoxSelectionne m_selectEquipementLogique;
        private C2iTextBoxSelectionne m_selectSite;
        private C2iTextBoxSelectionne m_selectEntiteSnmp;
        private Label label7;
        private LinkLabel m_lnkMasquer;
        private GroupBox groupBox1;
        private Label m_lblInfoMasquageEnCours;
        private Panel m_panelAlarmeMasquee;
        private Panel m_panelAlarmeNonMasquee;
        private LinkLabel m_lnkMasquageEnCours;
        private Label label8;
        private C2iPanel m_panelMasquage;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionAlarme));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelMasquage = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelAlarmeMasquee = new System.Windows.Forms.Panel();
            this.m_lnkMasquageEnCours = new System.Windows.Forms.LinkLabel();
            this.m_lblInfoMasquageEnCours = new System.Windows.Forms.Label();
            this.m_panelAlarmeNonMasquee = new System.Windows.Forms.Panel();
            this.m_lnkMasquer = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.m_selectTypeAlarme = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblProject = new System.Windows.Forms.Label();
            this.m_lblTypeTable = new System.Windows.Forms.Label();
            this.m_lblDateDebut = new System.Windows.Forms.Label();
            this.m_lblDateFin = new System.Windows.Forms.Label();
            this.m_lnkRetomber = new System.Windows.Forms.LinkLabel();
            this.m_lnkAcquitter = new System.Windows.Forms.LinkLabel();
            this.m_dtpDateDebutReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtpDateAcquittement = new sc2i.win32.common.C2iDateTimeExPicker();
            this.m_ArbreAlarmeHierarchique = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.m_dtpDateFinReelle = new sc2i.win32.common.C2iDateTimeExPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDescrip = new sc2i.win32.common.C2iTextBox();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_wndListeEquipements = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageElementsSupervises = new Crownwood.Magic.Controls.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_selectEntiteSnmp = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_selectLienReseau = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_selectEquipementLogique = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageFils = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelAlarmesFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageInfos = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeSite = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_panelMasquage.SuspendLayout();
            this.m_panelAlarmeMasquee.SuspendLayout();
            this.m_panelAlarmeNonMasquee.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageElementsSupervises.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.m_pageFils.SuspendLayout();
            this.m_pageInfos.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(721, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(613, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(896, 28);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(123, 5);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(489, 20);
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
            this.m_panTop.Controls.Add(this.m_panelMasquage);
            this.m_panTop.Controls.Add(this.m_selectTypeAlarme);
            this.m_panTop.Controls.Add(this.m_lblProject);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_lblTypeTable);
            this.m_panTop.Controls.Add(this.m_lblDateDebut);
            this.m_panTop.Controls.Add(this.m_lblDateFin);
            this.m_panTop.Controls.Add(this.m_lnkRetomber);
            this.m_panTop.Controls.Add(this.m_lnkAcquitter);
            this.m_panTop.Controls.Add(this.m_dtpDateDebutReelle);
            this.m_panTop.Controls.Add(this.label2);
            this.m_panTop.Controls.Add(this.m_dtpDateAcquittement);
            this.m_panTop.Controls.Add(this.m_ArbreAlarmeHierarchique);
            this.m_panTop.Controls.Add(this.m_dtpDateFinReelle);
            this.m_panTop.Controls.Add(this.label3);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(12, 43);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(884, 149);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_panelMasquage
            // 
            this.m_panelMasquage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelMasquage.Controls.Add(this.m_panelAlarmeMasquee);
            this.m_panelMasquage.Controls.Add(this.m_panelAlarmeNonMasquee);
            this.m_extLinkField.SetLinkField(this.m_panelMasquage, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMasquage, false);
            this.m_panelMasquage.Location = new System.Drawing.Point(275, 52);
            this.m_panelMasquage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMasquage, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelMasquage, "");
            this.m_panelMasquage.Name = "m_panelMasquage";
            this.m_panelMasquage.Size = new System.Drawing.Size(337, 46);
            this.m_extStyle.SetStyleBackColor(this.m_panelMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMasquage.TabIndex = 4021;
            // 
            // m_panelAlarmeMasquee
            // 
            this.m_panelAlarmeMasquee.Controls.Add(this.m_lnkMasquageEnCours);
            this.m_panelAlarmeMasquee.Controls.Add(this.m_lblInfoMasquageEnCours);
            this.m_panelAlarmeMasquee.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelAlarmeMasquee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelAlarmeMasquee, false);
            this.m_panelAlarmeMasquee.Location = new System.Drawing.Point(0, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAlarmeMasquee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelAlarmeMasquee, "");
            this.m_panelAlarmeMasquee.Name = "m_panelAlarmeMasquee";
            this.m_panelAlarmeMasquee.Size = new System.Drawing.Size(337, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelAlarmeMasquee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAlarmeMasquee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAlarmeMasquee.TabIndex = 4023;
            // 
            // m_lnkMasquageEnCours
            // 
            this.m_lnkMasquageEnCours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_lnkMasquageEnCours, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkMasquageEnCours, false);
            this.m_lnkMasquageEnCours.Location = new System.Drawing.Point(208, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkMasquageEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkMasquageEnCours, "");
            this.m_lnkMasquageEnCours.Name = "m_lnkMasquageEnCours";
            this.m_lnkMasquageEnCours.Size = new System.Drawing.Size(129, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMasquageEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMasquageEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMasquageEnCours.TabIndex = 4021;
            this.m_lnkMasquageEnCours.TabStop = true;
            this.m_lnkMasquageEnCours.Text = "Libelle du masquage automatique";
            this.m_lnkMasquageEnCours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkMasquageEnCours.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMasquageEnCours_LinkClicked);
            // 
            // m_lblInfoMasquageEnCours
            // 
            this.m_lblInfoMasquageEnCours.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lblInfoMasquageEnCours, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblInfoMasquageEnCours, false);
            this.m_lblInfoMasquageEnCours.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblInfoMasquageEnCours, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblInfoMasquageEnCours, "");
            this.m_lblInfoMasquageEnCours.Name = "m_lblInfoMasquageEnCours";
            this.m_lblInfoMasquageEnCours.Size = new System.Drawing.Size(208, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblInfoMasquageEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblInfoMasquageEnCours, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblInfoMasquageEnCours.TabIndex = 4022;
            this.m_lblInfoMasquageEnCours.Text = "This Alarm is currenly masked by|10328";
            this.m_lblInfoMasquageEnCours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelAlarmeNonMasquee
            // 
            this.m_panelAlarmeNonMasquee.Controls.Add(this.m_lnkMasquer);
            this.m_panelAlarmeNonMasquee.Controls.Add(this.label8);
            this.m_panelAlarmeNonMasquee.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelAlarmeNonMasquee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelAlarmeNonMasquee, false);
            this.m_panelAlarmeNonMasquee.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAlarmeNonMasquee, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelAlarmeNonMasquee, "");
            this.m_panelAlarmeNonMasquee.Name = "m_panelAlarmeNonMasquee";
            this.m_panelAlarmeNonMasquee.Size = new System.Drawing.Size(337, 21);
            this.m_extStyle.SetStyleBackColor(this.m_panelAlarmeNonMasquee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAlarmeNonMasquee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAlarmeNonMasquee.TabIndex = 4024;
            // 
            // m_lnkMasquer
            // 
            this.m_lnkMasquer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_lnkMasquer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkMasquer, false);
            this.m_lnkMasquer.Location = new System.Drawing.Point(208, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkMasquer, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkMasquer, "");
            this.m_lnkMasquer.Name = "m_lnkMasquer";
            this.m_lnkMasquer.Size = new System.Drawing.Size(129, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkMasquer.TabIndex = 4021;
            this.m_lnkMasquer.TabStop = true;
            this.m_lnkMasquer.Text = "Mask Alarm now|10270";
            this.m_lnkMasquer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkMasquer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkMasquer_LinkClicked);
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(208, 21);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4022;
            this.label8.Text = "This Alarm is not currently masked|10329";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_selectTypeAlarme
            // 
            this.m_selectTypeAlarme.ComportementLinkStd = true;
            this.m_selectTypeAlarme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_selectTypeAlarme.ElementSelectionne = null;
            this.m_selectTypeAlarme.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeAlarme.FormattingEnabled = true;
            this.m_selectTypeAlarme.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeAlarme, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeAlarme, false);
            this.m_selectTypeAlarme.LinkProperty = "";
            this.m_selectTypeAlarme.ListDonnees = null;
            this.m_selectTypeAlarme.Location = new System.Drawing.Point(123, 27);
            this.m_selectTypeAlarme.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeAlarme, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeAlarme, "");
            this.m_selectTypeAlarme.Name = "m_selectTypeAlarme";
            this.m_selectTypeAlarme.NullAutorise = false;
            this.m_selectTypeAlarme.ProprieteAffichee = null;
            this.m_selectTypeAlarme.ProprieteParentListeObjets = null;
            this.m_selectTypeAlarme.SelectionneurParent = null;
            this.m_selectTypeAlarme.Size = new System.Drawing.Size(261, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeAlarme.TabIndex = 4019;
            this.m_selectTypeAlarme.TextNull = "(empty)";
            this.m_selectTypeAlarme.Tri = true;
            this.m_selectTypeAlarme.TypeFormEdition = null;
            this.m_selectTypeAlarme.SelectionChangeCommitted += new System.EventHandler(this.m_selectTypeAlarme_SelectionChangeCommitted);
            // 
            // m_lblProject
            // 
            this.m_lblProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblProject.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblProject, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblProject, false);
            this.m_lblProject.Location = new System.Drawing.Point(6, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProject, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblProject, "");
            this.m_lblProject.Name = "m_lblProject";
            this.m_lblProject.Size = new System.Drawing.Size(108, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProject.TabIndex = 4005;
            this.m_lblProject.Text = "Label|50";
            // 
            // m_lblTypeTable
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeTable, false);
            this.m_lblTypeTable.Location = new System.Drawing.Point(6, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeTable, "");
            this.m_lblTypeTable.Name = "m_lblTypeTable";
            this.m_lblTypeTable.Size = new System.Drawing.Size(117, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeTable.TabIndex = 4016;
            this.m_lblTypeTable.Text = "Alarm Type|10253";
            // 
            // m_lblDateDebut
            // 
            this.m_lblDateDebut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateDebut.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateDebut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateDebut, false);
            this.m_lblDateDebut.Location = new System.Drawing.Point(6, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateDebut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateDebut, "");
            this.m_lblDateDebut.Name = "m_lblDateDebut";
            this.m_lblDateDebut.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateDebut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateDebut.TabIndex = 4005;
            this.m_lblDateDebut.Text = "Start date|10255";
            this.m_lblDateDebut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDateFin
            // 
            this.m_lblDateFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_lblDateFin.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblDateFin, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblDateFin, false);
            this.m_lblDateFin.Location = new System.Drawing.Point(6, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDateFin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDateFin, "");
            this.m_lblDateFin.Name = "m_lblDateFin";
            this.m_lblDateFin.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateFin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateFin.TabIndex = 4005;
            this.m_lblDateFin.Text = "End date|10256";
            this.m_lblDateFin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkRetomber
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkRetomber, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRetomber, false);
            this.m_lnkRetomber.Location = new System.Drawing.Point(275, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRetomber, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkRetomber, "");
            this.m_lnkRetomber.Name = "m_lnkRetomber";
            this.m_lnkRetomber.Size = new System.Drawing.Size(167, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRetomber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRetomber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRetomber.TabIndex = 4020;
            this.m_lnkRetomber.TabStop = true;
            this.m_lnkRetomber.Text = "Clear manually|10266";
            this.m_lnkRetomber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkRetomber.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRetomber_LinkClicked);
            // 
            // m_lnkAcquitter
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkAcquitter, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAcquitter, false);
            this.m_lnkAcquitter.Location = new System.Drawing.Point(275, 114);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAcquitter, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkAcquitter, "");
            this.m_lnkAcquitter.Name = "m_lnkAcquitter";
            this.m_lnkAcquitter.Size = new System.Drawing.Size(167, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAcquitter.TabIndex = 4020;
            this.m_lnkAcquitter.TabStop = true;
            this.m_lnkAcquitter.Text = "Acknowledge|10267";
            this.m_lnkAcquitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkAcquitter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAcquitter_LinkClicked);
            // 
            // m_dtpDateDebutReelle
            // 
            this.m_dtpDateDebutReelle.Checked = true;
            this.m_dtpDateDebutReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateDebutReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateDebutReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateDebutReelle, false);
            this.m_dtpDateDebutReelle.Location = new System.Drawing.Point(125, 57);
            this.m_dtpDateDebutReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateDebutReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateDebutReelle, "");
            this.m_dtpDateDebutReelle.Name = "m_dtpDateDebutReelle";
            this.m_dtpDateDebutReelle.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateDebutReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateDebutReelle.TabIndex = 2;
            this.m_dtpDateDebutReelle.TextNull = "None";
            this.m_dtpDateDebutReelle.Value.DateTimeValue = new System.DateTime(2013, 11, 18, 10, 8, 56, 799);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(621, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4005;
            this.label2.Text = "Alarm Hierarchy|10254";
            // 
            // m_dtpDateAcquittement
            // 
            this.m_dtpDateAcquittement.Checked = true;
            this.m_dtpDateAcquittement.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateAcquittement.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateAcquittement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateAcquittement, false);
            this.m_dtpDateAcquittement.Location = new System.Drawing.Point(125, 107);
            this.m_dtpDateAcquittement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateAcquittement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateAcquittement, "");
            this.m_dtpDateAcquittement.Name = "m_dtpDateAcquittement";
            this.m_dtpDateAcquittement.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateAcquittement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateAcquittement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateAcquittement.TabIndex = 2;
            this.m_dtpDateAcquittement.TextNull = "None";
            this.m_dtpDateAcquittement.Value.DateTimeValue = new System.DateTime(2013, 11, 18, 10, 8, 56, 827);
            // 
            // m_ArbreAlarmeHierarchique
            // 
            this.m_ArbreAlarmeHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ArbreAlarmeHierarchique.AutoriseReaffectation = true;
            this.m_ArbreAlarmeHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_ArbreAlarmeHierarchique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ArbreAlarmeHierarchique, false);
            this.m_ArbreAlarmeHierarchique.Location = new System.Drawing.Point(622, 29);
            this.m_ArbreAlarmeHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreAlarmeHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ArbreAlarmeHierarchique, "");
            this.m_ArbreAlarmeHierarchique.Name = "m_ArbreAlarmeHierarchique";
            this.m_ArbreAlarmeHierarchique.Size = new System.Drawing.Size(237, 98);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreAlarmeHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreAlarmeHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreAlarmeHierarchique.TabIndex = 4;
            // 
            // m_dtpDateFinReelle
            // 
            this.m_dtpDateFinReelle.Checked = true;
            this.m_dtpDateFinReelle.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_dtpDateFinReelle.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_extLinkField.SetLinkField(this.m_dtpDateFinReelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDateFinReelle, false);
            this.m_dtpDateFinReelle.Location = new System.Drawing.Point(125, 78);
            this.m_dtpDateFinReelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDateFinReelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDateFinReelle, "");
            this.m_dtpDateFinReelle.Name = "m_dtpDateFinReelle";
            this.m_dtpDateFinReelle.Size = new System.Drawing.Size(144, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDateFinReelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDateFinReelle.TabIndex = 3;
            this.m_dtpDateFinReelle.TextNull = "None";
            this.m_dtpDateFinReelle.Value.DateTimeValue = new System.DateTime(2013, 11, 18, 10, 8, 56, 846);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4005;
            this.label3.Text = "Acknowledge date|10265";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtDescrip
            // 
            this.m_txtDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescrip.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescrip, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescrip, true);
            this.m_txtDescrip.Location = new System.Drawing.Point(8, 25);
            this.m_txtDescrip.LockEdition = false;
            this.m_txtDescrip.MaxLength = 2000;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescrip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescrip, "");
            this.m_txtDescrip.Multiline = true;
            this.m_txtDescrip.Name = "m_txtDescrip";
            this.m_txtDescrip.Size = new System.Drawing.Size(848, 244);
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
            this.m_lblDescription.Location = new System.Drawing.Point(8, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescription, "");
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(185, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 4005;
            this.m_lblDescription.Text = "Alarm description|10273";
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
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
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
            this.m_TabControl.Location = new System.Drawing.Point(12, 198);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageFormulaires;
            this.m_TabControl.Size = new System.Drawing.Size(884, 320);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageFils,
            this.m_pageInfos,
            this.m_pageElementsSupervises});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageElementsSupervises
            // 
            this.m_pageElementsSupervises.Controls.Add(this.groupBox1);
            this.m_pageElementsSupervises.Controls.Add(this.m_selectEntiteSnmp);
            this.m_pageElementsSupervises.Controls.Add(this.m_selectLienReseau);
            this.m_pageElementsSupervises.Controls.Add(this.m_selectEquipementLogique);
            this.m_pageElementsSupervises.Controls.Add(this.m_selectSite);
            this.m_pageElementsSupervises.Controls.Add(this.label7);
            this.m_pageElementsSupervises.Controls.Add(this.label6);
            this.m_pageElementsSupervises.Controls.Add(this.label5);
            this.m_pageElementsSupervises.Controls.Add(this.label4);
            this.m_extLinkField.SetLinkField(this.m_pageElementsSupervises, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageElementsSupervises, false);
            this.m_pageElementsSupervises.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageElementsSupervises, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageElementsSupervises, "");
            this.m_pageElementsSupervises.Name = "m_pageElementsSupervises";
            this.m_pageElementsSupervises.Selected = false;
            this.m_pageElementsSupervises.Size = new System.Drawing.Size(868, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageElementsSupervises, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageElementsSupervises, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageElementsSupervises.TabIndex = 22;
            this.m_pageElementsSupervises.Title = "Supervised Elements|10274";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.groupBox1.Location = new System.Drawing.Point(28, 140);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(757, 100);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4022;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Masking|10269";
            // 
            // m_selectEntiteSnmp
            // 
            this.m_selectEntiteSnmp.BackColor = System.Drawing.Color.Transparent;
            this.m_selectEntiteSnmp.ElementSelectionne = null;
            this.m_selectEntiteSnmp.FonctionTextNull = null;
            this.m_selectEntiteSnmp.HasLink = true;
            this.m_selectEntiteSnmp.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectEntiteSnmp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectEntiteSnmp, false);
            this.m_selectEntiteSnmp.Location = new System.Drawing.Point(171, 99);
            this.m_selectEntiteSnmp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectEntiteSnmp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectEntiteSnmp, "");
            this.m_selectEntiteSnmp.Name = "m_selectEntiteSnmp";
            this.m_selectEntiteSnmp.SelectedObject = null;
            this.m_selectEntiteSnmp.Size = new System.Drawing.Size(359, 22);
            this.m_selectEntiteSnmp.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectEntiteSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectEntiteSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectEntiteSnmp.TabIndex = 4017;
            this.m_selectEntiteSnmp.TextNull = "";
            // 
            // m_selectLienReseau
            // 
            this.m_selectLienReseau.BackColor = System.Drawing.Color.Transparent;
            this.m_selectLienReseau.ElementSelectionne = null;
            this.m_selectLienReseau.FonctionTextNull = null;
            this.m_selectLienReseau.HasLink = true;
            this.m_selectLienReseau.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectLienReseau, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectLienReseau, false);
            this.m_selectLienReseau.Location = new System.Drawing.Point(171, 71);
            this.m_selectLienReseau.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectLienReseau, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectLienReseau, "");
            this.m_selectLienReseau.Name = "m_selectLienReseau";
            this.m_selectLienReseau.SelectedObject = null;
            this.m_selectLienReseau.Size = new System.Drawing.Size(359, 22);
            this.m_selectLienReseau.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectLienReseau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectLienReseau.TabIndex = 4017;
            this.m_selectLienReseau.TextNull = "";
            // 
            // m_selectEquipementLogique
            // 
            this.m_selectEquipementLogique.BackColor = System.Drawing.Color.Transparent;
            this.m_selectEquipementLogique.ElementSelectionne = null;
            this.m_selectEquipementLogique.FonctionTextNull = null;
            this.m_selectEquipementLogique.HasLink = true;
            this.m_selectEquipementLogique.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectEquipementLogique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectEquipementLogique, false);
            this.m_selectEquipementLogique.Location = new System.Drawing.Point(171, 43);
            this.m_selectEquipementLogique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectEquipementLogique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectEquipementLogique, "");
            this.m_selectEquipementLogique.Name = "m_selectEquipementLogique";
            this.m_selectEquipementLogique.SelectedObject = null;
            this.m_selectEquipementLogique.Size = new System.Drawing.Size(359, 22);
            this.m_selectEquipementLogique.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectEquipementLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectEquipementLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectEquipementLogique.TabIndex = 4017;
            this.m_selectEquipementLogique.TextNull = "";
            // 
            // m_selectSite
            // 
            this.m_selectSite.BackColor = System.Drawing.Color.Transparent;
            this.m_selectSite.ElementSelectionne = null;
            this.m_selectSite.FonctionTextNull = null;
            this.m_selectSite.HasLink = true;
            this.m_selectSite.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectSite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectSite, false);
            this.m_selectSite.Location = new System.Drawing.Point(171, 15);
            this.m_selectSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectSite, "");
            this.m_selectSite.Name = "m_selectSite";
            this.m_selectSite.SelectedObject = null;
            this.m_selectSite.Size = new System.Drawing.Size(359, 22);
            this.m_selectSite.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectSite.TabIndex = 4017;
            this.m_selectSite.TextNull = "";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(25, 100);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 21);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4016;
            this.label7.Text = "SNMP Entity|10279";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(25, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 21);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4016;
            this.label6.Text = "Network Link|10277";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(25, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 21);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4016;
            this.label5.Text = "Logical Equipment|10276";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(25, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4016;
            this.label4.Text = "Site|10275";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.m_pageFormulaires.Size = new System.Drawing.Size(868, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 16;
            this.m_pageFormulaires.Title = "Form|60";
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
            this.m_PanelChamps.Size = new System.Drawing.Size(862, 273);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 1;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageFils
            // 
            this.m_pageFils.Controls.Add(this.m_PanelAlarmesFils);
            this.m_extLinkField.SetLinkField(this.m_pageFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFils, false);
            this.m_pageFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFils, "");
            this.m_pageFils.Name = "m_pageFils";
            this.m_pageFils.Selected = false;
            this.m_pageFils.Size = new System.Drawing.Size(868, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFils.TabIndex = 20;
            this.m_pageFils.Title = "Child Alarms|10252";
            // 
            // m_PanelAlarmesFils
            // 
            this.m_PanelAlarmesFils.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_PanelAlarmesFils.AffectationsPourNouveauxElements")));
            this.m_PanelAlarmesFils.AllowArbre = true;
            this.m_PanelAlarmesFils.AllowCustomisation = true;
            this.m_PanelAlarmesFils.AllowSerializePreferences = true;
            this.m_PanelAlarmesFils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Libelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            this.m_PanelAlarmesFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_PanelAlarmesFils.ContexteUtilisation = "";
            this.m_PanelAlarmesFils.ControlFiltreStandard = null;
            this.m_PanelAlarmesFils.ElementSelectionne = null;
            this.m_PanelAlarmesFils.EnableCustomisation = true;
            this.m_PanelAlarmesFils.FiltreDeBase = null;
            this.m_PanelAlarmesFils.FiltreDeBaseEnAjout = false;
            this.m_PanelAlarmesFils.FiltrePrefere = null;
            this.m_PanelAlarmesFils.FiltreRapide = null;
            this.m_PanelAlarmesFils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_PanelAlarmesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelAlarmesFils, false);
            this.m_PanelAlarmesFils.ListeObjets = null;
            this.m_PanelAlarmesFils.Location = new System.Drawing.Point(3, 3);
            this.m_PanelAlarmesFils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelAlarmesFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_PanelAlarmesFils.ModeQuickSearch = false;
            this.m_PanelAlarmesFils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_PanelAlarmesFils, "");
            this.m_PanelAlarmesFils.MultiSelect = false;
            this.m_PanelAlarmesFils.Name = "m_PanelAlarmesFils";
            this.m_PanelAlarmesFils.Navigateur = null;
            this.m_PanelAlarmesFils.ObjetReferencePourAffectationsInitiales = null;
            this.m_PanelAlarmesFils.ProprieteObjetAEditer = null;
            this.m_PanelAlarmesFils.QuickSearchText = "";
            this.m_PanelAlarmesFils.ShortIcons = false;
            this.m_PanelAlarmesFils.Size = new System.Drawing.Size(862, 273);
            this.m_extStyle.SetStyleBackColor(this.m_PanelAlarmesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelAlarmesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelAlarmesFils.TabIndex = 1;
            this.m_PanelAlarmesFils.TrierAuClicSurEnteteColonne = true;
            this.m_PanelAlarmesFils.UseCheckBoxes = false;
            // 
            // m_pageInfos
            // 
            this.m_pageInfos.Controls.Add(this.m_txtDescrip);
            this.m_pageInfos.Controls.Add(this.m_lblDescription);
            this.m_extLinkField.SetLinkField(this.m_pageInfos, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageInfos, false);
            this.m_pageInfos.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInfos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInfos, "");
            this.m_pageInfos.Name = "m_pageInfos";
            this.m_pageInfos.Selected = false;
            this.m_pageInfos.Size = new System.Drawing.Size(868, 279);
            this.m_extStyle.SetStyleBackColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInfos.TabIndex = 17;
            this.m_pageInfos.Title = "Information|119";
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
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
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
            this.m_reducteurTop.Location = new System.Drawing.Point(450, 39);
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
            // CFormEditionAlarme
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.BoutonAjouterVisible = false;
            this.BoutonSupprimerVisible = false;
            this.ClientSize = new System.Drawing.Size(896, 530);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_panTop);
            this.Controls.Add(this.m_TabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionAlarme";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionAlarme_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionAlarme_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_reducteurTop, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_panelMasquage.ResumeLayout(false);
            this.m_panelAlarmeMasquee.ResumeLayout(false);
            this.m_panelAlarmeNonMasquee.ResumeLayout(false);
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageElementsSupervises.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.m_pageFils.ResumeLayout(false);
            this.m_pageInfos.ResumeLayout(false);
            this.m_pageInfos.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionAlarme()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionAlarme(CAlarme proj)
            : base(proj)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionAlarme(CAlarme proj, CListeObjetsDonnees liste)
            : base(proj, liste)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CAlarme Alarme
		{
			get	{ return (CAlarme)ObjetEdite;	}
		}

		//-------------------------------------------------------------------------
		private bool m_bInitialise = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bInitialise = false;
            CResultAErreur result = base.MyInitChamps();

			AffecterTitre(I.T( "Alarm @1|10257", Alarme.Libelle));

		
			m_ArbreAlarmeHierarchique.AfficheHierarchie(Alarme);

            if (Alarme.AlarmeParente != null && Alarme.AlarmeParente.TypeAlarme != null)
                m_selectTypeAlarme.Init(Alarme.AlarmeParente.TypeAlarme.TypesFils, "Libelle", true);
            else if (Alarme.AlarmeParente == null)
                    m_selectTypeAlarme.Init(
                        new CListeObjetsDonnees(Alarme.ContexteDonnee, typeof(CTypeAlarme), new CFiltreData(CTypeAlarme.c_champIdTypeParent + " is null")),
                        "Libelle",
                        true);
            else
                m_selectTypeAlarme.Init(typeof(CTypeAlarme), null, "Libelle", true);
            
			m_selectTypeAlarme.ElementSelectionne = Alarme.TypeAlarme;
            m_selectTypeAlarme.LockEdition = true;

            // Dates 
			if(Alarme.DateDebut != null)
				m_dtpDateDebutReelle.Value = new CDateTimeEx(Alarme.DateDebut);
			else
				m_dtpDateDebutReelle.Value = null;

		    m_dtpDateFinReelle.Value = Alarme.DateFin;
            m_dtpDateAcquittement.Value = Alarme.DateAcquittement;

            m_extLinkField.FillDialogFromObjet(Alarme);

            if (Alarme.GetFormulaires().Length > 0)
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Add(m_pageFormulaires);
            }
            else
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }

            m_dtpDateDebutReelle.LockEdition = true;
            m_dtpDateFinReelle.LockEdition = true;
            m_dtpDateAcquittement.LockEdition = true;

            m_lnkRetomber.Enabled = Alarme.DateFin == null && !m_gestionnaireModeEdition.ModeEdition;
            m_lnkAcquitter.Enabled = Alarme.DateAcquittement == null && !m_gestionnaireModeEdition.ModeEdition;

            UpdateMasquage();
			m_bInitialise = true;
			return result;
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

            if (m_selectTypeAlarme.ElementSelectionne != null)
                Alarme.TypeAlarme = (CTypeAlarme)m_selectTypeAlarme.ElementSelectionne;


            m_extLinkField.FillObjetFromDialog(Alarme);

			return result;
		}


		//----------------------------- Init TABCONTROL -----------------------------
		private CResultAErreur CFormEditionAlarme_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageFormulaires)
				{
					m_PanelChamps.ElementEdite = Alarme;
				}
				else if (page == m_pageFils)
				{
                    m_PanelAlarmesFils.InitFromListeObjets(
                        Alarme.AlarmesFilles,
                        typeof(CAlarme),
                        typeof(CFormEditionAlarme),
                        Alarme,
                        "Alarme");

				}
                else if (page == m_pageElementsSupervises)
                {
                    m_selectSite.Init<CSite>("Libelle", false);
                    m_selectEquipementLogique.Init<CEquipementLogique>("Libelle", false);
                    m_selectLienReseau.Init<CLienReseau>("Libelle", false);
                    m_selectEntiteSnmp.Init<CEntiteSnmp>("Libelle", false);
                    m_selectSite.LockEdition = true;
                    m_selectEquipementLogique.LockEdition = true;
                    m_selectLienReseau.LockEdition = true;
                    m_selectEntiteSnmp.LockEdition = true;
                    m_selectSite.ElementSelectionne = Alarme.Site;
                    m_selectEquipementLogique.ElementSelectionne = Alarme.EquipementLogique;
                    m_selectLienReseau.ElementSelectionne = Alarme.LienReseau;
                    m_selectEntiteSnmp.ElementSelectionne = Alarme.EntiteSnmp;

                }
               
			}
			return result;
		}

        private void UpdateMasquage()
        {
            // Masqsuage
            if (Alarme.MasquageHerite != null)
            {
                m_panelAlarmeMasquee.Visible = true;
                m_panelAlarmeNonMasquee.Visible = false;
                m_lnkMasquageEnCours.Text = Alarme.MasquageHerite.Libelle;
            }
            else
            {
                m_panelAlarmeMasquee.Visible = false;
                m_panelAlarmeNonMasquee.Visible = true;
            }

        }

        private CResultAErreur CFormEditionAlarme_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

			if (page == m_pageFormulaires)
			{
				result = m_PanelChamps.MAJ_Champs();
			}
			else if (page == m_pageInfos)
			{
			}

			return result;

		}


        //-------------------------------------------------------------------------
        private void m_selectTypeAlarme_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_selectTypeAlarme.ElementSelectionne != null)
                Alarme.TypeAlarme = (CTypeAlarme)m_selectTypeAlarme.ElementSelectionne;

            m_PanelChamps.ElementEdite = Alarme;
        }

        //------------------------------------------------------------------------------
        private void m_lnkRetomber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CFormAlerte.Afficher(I.T("Please confirm Clearing Alarm Now?|10268")) == DialogResult.OK)
            {
                Alarme.Clear();
                UpdateForm(true);
            }
        }

        //------------------------------------------------------------------------------
        private void m_lnkAcquitter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Alarme.Acknowledge();
            UpdateForm(true);
        }

        //------------------------------------------------------------------------------
        private void m_lnkMasquer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_gestionnaireModeEdition.ModeEdition)
                return;

            CParametrageFiltrageAlarmes masquageEnCours = Alarme.MasquageHerite;
            if (masquageEnCours != null && CFormAlerte.Afficher(I.T("This Alarm is already masked by @1. Do you want to set a new Masking Filter?|10317", masquageEnCours.Libelle), EFormAlerteType.Question) != DialogResult.Yes)
                return;
            else
            {
                CFormMasquageAlarmeManuel.CreateMasquage(Alarme, true);
                UpdateMasquage();
            }


        }

        private void m_lnkMasquageEnCours_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Alarme.MasquageHerite != null)
            {
                CReferenceTypeForm reference = CFormFinder.GetRefFormToEdit(Alarme.MasquageHerite.GetType());
                if (reference != null)
                {
                    IFormNavigable form = reference.GetForm(Alarme.MasquageHerite) as IFormNavigable;
                    if (form != null)
                        CTimosApp.Navigateur.AffichePage(form);
                }
            }
        }
        

	}
}

