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

using sc2i.workflow;
using timos.data.supervision;
using futurocom.supervision.alarmes;
using futurocom.supervision;
using sc2i.expression;
using sc2i.win32.expression;
using System.Collections.Generic;
using sc2i.documents;
using System.IO;
using timos.supervision;
using sc2i.formulaire;
using timos.data;
using timos.data.snmp;
using sc2i.win32.data.dynamic;
using sc2i.common.memorydb;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CParametrageFiltrageAlarmes))]
	public class CFormEditionParametrageFiltrageAlarmes : CFormEditionStdTimos, IFormNavigable
	{
        private CParametreFiltrageAlarmes m_parametre;

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pagePeriodes;
        private Crownwood.Magic.Controls.TabPage m_pageFiltre;
        private Label label13;
        private ErrorProvider m_errorProvider;
        private Label label15;
        private CheckBox m_chkActiver;
        private CheckBox m_chkIgnorerEnBase;
        private timos.win32.composants.CPanelSelectListeElements m_panelSelectElements;
        private ListViewAutoFilled m_listViewTypesElementsDuFiltre;
        private ListViewAutoFilledColumn m_listViewColumn;
        private LinkLabel m_lnkTestFilter;
        private sc2i.win32.common.periodeactivation.CControleEditePeriodeActivation m_controleEditePeriode;
        private ListViewAutoFilledColumn m_colonneNombre;
        private Label label2;
        private CDraggeurDeControl cDraggeurDeControl1;
        private CComboBoxLinkListeObjetsDonnees m_cmbSelecCategorieMasquage;
        private Label label3;
        private Label label4;
        private C2iDateTimePicker m_dtPickerDateFinValidite;
        private C2iDateTimePicker m_dtPickerDateDebutValidite;
        private Label label5;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionParametrageFiltrageAlarmes()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageFiltrageAlarmes(CParametrageFiltrageAlarmes civilite)
			:base(civilite)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionParametrageFiltrageAlarmes(CParametrageFiltrageAlarmes civilite, CListeObjetsDonnees liste)
			:base(civilite, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionParametrageFiltrageAlarmes));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_dtPickerDateFinValidite = new sc2i.win32.common.C2iDateTimePicker();
            this.m_dtPickerDateDebutValidite = new sc2i.win32.common.C2iDateTimePicker();
            this.m_cmbSelecCategorieMasquage = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkActiver = new System.Windows.Forms.CheckBox();
            this.m_lnkTestFilter = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkIgnorerEnBase = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pagePeriodes = new Crownwood.Magic.Controls.TabPage();
            this.m_controleEditePeriode = new sc2i.win32.common.periodeactivation.CControleEditePeriodeActivation();
            this.label15 = new System.Windows.Forms.Label();
            this.m_pageFiltre = new Crownwood.Magic.Controls.TabPage();
            this.m_listViewTypesElementsDuFiltre = new sc2i.win32.common.ListViewAutoFilled();
            this.m_listViewColumn = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_colonneNombre = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panelSelectElements = new timos.win32.composants.CPanelSelectListeElements();
            this.label13 = new System.Windows.Forms.Label();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cDraggeurDeControl1 = new sc2i.win32.common.CDraggeurDeControl();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pagePeriodes.SuspendLayout();
            this.m_pageFiltre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
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
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label |50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(83, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(349, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_dtPickerDateFinValidite);
            this.c2iPanelOmbre4.Controls.Add(this.m_dtPickerDateDebutValidite);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbSelecCategorieMasquage);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkActiver);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkTestFilter);
            this.c2iPanelOmbre4.Controls.Add(this.label3);
            this.c2iPanelOmbre4.Controls.Add(this.m_chkIgnorerEnBase);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(622, 151);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_dtPickerDateFinValidite
            // 
            this.m_dtPickerDateFinValidite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtPickerDateFinValidite, "");
            this.m_dtPickerDateFinValidite.Location = new System.Drawing.Point(307, 92);
            this.m_dtPickerDateFinValidite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtPickerDateFinValidite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtPickerDateFinValidite, "");
            this.m_dtPickerDateFinValidite.Name = "m_dtPickerDateFinValidite";
            this.m_dtPickerDateFinValidite.Size = new System.Drawing.Size(90, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtPickerDateFinValidite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtPickerDateFinValidite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtPickerDateFinValidite.TabIndex = 4007;
            this.m_dtPickerDateFinValidite.Value = new System.DateTime(2011, 8, 26, 10, 57, 29, 736);
            // 
            // m_dtPickerDateDebutValidite
            // 
            this.m_dtPickerDateDebutValidite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_extLinkField.SetLinkField(this.m_dtPickerDateDebutValidite, "");
            this.m_dtPickerDateDebutValidite.Location = new System.Drawing.Point(178, 92);
            this.m_dtPickerDateDebutValidite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtPickerDateDebutValidite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtPickerDateDebutValidite, "");
            this.m_dtPickerDateDebutValidite.Name = "m_dtPickerDateDebutValidite";
            this.m_dtPickerDateDebutValidite.Size = new System.Drawing.Size(90, 20);
            this.m_extStyle.SetStyleBackColor(this.m_dtPickerDateDebutValidite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtPickerDateDebutValidite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtPickerDateDebutValidite.TabIndex = 4007;
            this.m_dtPickerDateDebutValidite.Value = new System.DateTime(2011, 8, 26, 10, 57, 29, 736);
            // 
            // m_cmbSelecCategorieMasquage
            // 
            this.m_cmbSelecCategorieMasquage.ComportementLinkStd = true;
            this.m_cmbSelecCategorieMasquage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSelecCategorieMasquage.ElementSelectionne = null;
            this.m_cmbSelecCategorieMasquage.FormattingEnabled = true;
            this.m_cmbSelecCategorieMasquage.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbSelecCategorieMasquage, "");
            this.m_cmbSelecCategorieMasquage.LinkProperty = "";
            this.m_cmbSelecCategorieMasquage.ListDonnees = null;
            this.m_cmbSelecCategorieMasquage.Location = new System.Drawing.Point(147, 38);
            this.m_cmbSelecCategorieMasquage.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelecCategorieMasquage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelecCategorieMasquage, "");
            this.m_cmbSelecCategorieMasquage.Name = "m_cmbSelecCategorieMasquage";
            this.m_cmbSelecCategorieMasquage.NullAutorise = false;
            this.m_cmbSelecCategorieMasquage.ProprieteAffichee = null;
            this.m_cmbSelecCategorieMasquage.ProprieteParentListeObjets = null;
            this.m_cmbSelecCategorieMasquage.SelectionneurParent = null;
            this.m_cmbSelecCategorieMasquage.Size = new System.Drawing.Size(285, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelecCategorieMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelecCategorieMasquage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelecCategorieMasquage.TabIndex = 4006;
            this.m_cmbSelecCategorieMasquage.TextNull = "(empty)";
            this.m_cmbSelecCategorieMasquage.Tri = true;
            this.m_cmbSelecCategorieMasquage.TypeFormEdition = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Masking Category|10308";
            // 
            // m_chkActiver
            // 
            this.m_extLinkField.SetLinkField(this.m_chkActiver, "Enabled");
            this.m_chkActiver.Location = new System.Drawing.Point(416, 90);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkActiver, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkActiver, "");
            this.m_chkActiver.Name = "m_chkActiver";
            this.m_chkActiver.Size = new System.Drawing.Size(144, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkActiver, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkActiver, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkActiver.TabIndex = 4003;
            this.m_chkActiver.Text = "Enabled|10294";
            this.m_chkActiver.UseVisualStyleBackColor = true;
            // 
            // m_lnkTestFilter
            // 
            this.m_lnkTestFilter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTestFilter, "");
            this.m_lnkTestFilter.Location = new System.Drawing.Point(457, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTestFilter, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTestFilter, "");
            this.m_lnkTestFilter.Name = "m_lnkTestFilter";
            this.m_lnkTestFilter.Size = new System.Drawing.Size(85, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTestFilter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTestFilter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTestFilter.TabIndex = 4005;
            this.m_lnkTestFilter.TabStop = true;
            this.m_lnkTestFilter.Text = "Test Filter|10302";
            this.m_lnkTestFilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTestFilter_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 14);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Dates of validity|10309";
            // 
            // m_chkIgnorerEnBase
            // 
            this.m_extLinkField.SetLinkField(this.m_chkIgnorerEnBase, "IgnorerEnBase");
            this.m_chkIgnorerEnBase.Location = new System.Drawing.Point(147, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIgnorerEnBase, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkIgnorerEnBase, "");
            this.m_chkIgnorerEnBase.Name = "m_chkIgnorerEnBase";
            this.m_chkIgnorerEnBase.Size = new System.Drawing.Size(296, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkIgnorerEnBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIgnorerEnBase, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIgnorerEnBase.TabIndex = 4004;
            this.m_chkIgnorerEnBase.Text = "Ignore Alarms (Do not save in Database)|10298";
            this.m_chkIgnorerEnBase.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(129, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "from|10310";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(272, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4002;
            this.label5.Text = "to|10311";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 209);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageFiltre;
            this.m_tabControl.Size = new System.Drawing.Size(819, 351);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiltre,
            this.m_pagePeriodes});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pagePeriodes
            // 
            this.m_pagePeriodes.Controls.Add(this.m_controleEditePeriode);
            this.m_pagePeriodes.Controls.Add(this.label15);
            this.m_extLinkField.SetLinkField(this.m_pagePeriodes, "");
            this.m_pagePeriodes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePeriodes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePeriodes, "");
            this.m_pagePeriodes.Name = "m_pagePeriodes";
            this.m_pagePeriodes.Selected = false;
            this.m_pagePeriodes.Size = new System.Drawing.Size(803, 310);
            this.m_extStyle.SetStyleBackColor(this.m_pagePeriodes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePeriodes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePeriodes.TabIndex = 11;
            this.m_pagePeriodes.Title = "Periods Setting|10296";
            // 
            // m_controleEditePeriode
            // 
            this.m_controleEditePeriode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_controleEditePeriode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_controleEditePeriode.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_controleEditePeriode, "");
            this.m_controleEditePeriode.Location = new System.Drawing.Point(12, 35);
            this.m_controleEditePeriode.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controleEditePeriode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controleEditePeriode, "");
            this.m_controleEditePeriode.Name = "m_controleEditePeriode";
            this.m_controleEditePeriode.Periode = null;
            this.m_controleEditePeriode.Size = new System.Drawing.Size(758, 261);
            this.m_extStyle.SetStyleBackColor(this.m_controleEditePeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controleEditePeriode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleEditePeriode.TabIndex = 21;
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(10, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(590, 15);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 20;
            this.label15.Text = "Define the periods during which the filter will be applied|10303";
            // 
            // m_pageFiltre
            // 
            this.m_pageFiltre.Controls.Add(this.m_listViewTypesElementsDuFiltre);
            this.m_pageFiltre.Controls.Add(this.m_panelSelectElements);
            this.m_pageFiltre.Controls.Add(this.label13);
            this.m_extLinkField.SetLinkField(this.m_pageFiltre, "");
            this.m_pageFiltre.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiltre, "");
            this.m_pageFiltre.Name = "m_pageFiltre";
            this.m_pageFiltre.Size = new System.Drawing.Size(803, 310);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiltre.TabIndex = 10;
            this.m_pageFiltre.Title = "Filter setting|10295";
            // 
            // m_listViewTypesElementsDuFiltre
            // 
            this.m_listViewTypesElementsDuFiltre.AllowDrop = true;
            this.m_listViewTypesElementsDuFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listViewTypesElementsDuFiltre.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_listViewColumn,
            this.m_colonneNombre});
            this.m_listViewTypesElementsDuFiltre.EnableCustomisation = true;
            this.m_listViewTypesElementsDuFiltre.FullRowSelect = true;
            this.m_listViewTypesElementsDuFiltre.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_listViewTypesElementsDuFiltre.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listViewTypesElementsDuFiltre, "");
            this.m_listViewTypesElementsDuFiltre.Location = new System.Drawing.Point(15, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewTypesElementsDuFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listViewTypesElementsDuFiltre, "");
            this.m_listViewTypesElementsDuFiltre.Name = "m_listViewTypesElementsDuFiltre";
            this.m_listViewTypesElementsDuFiltre.Size = new System.Drawing.Size(257, 252);
            this.m_extStyle.SetStyleBackColor(this.m_listViewTypesElementsDuFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewTypesElementsDuFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewTypesElementsDuFiltre.TabIndex = 9;
            this.m_listViewTypesElementsDuFiltre.UseCompatibleStateImageBehavior = false;
            this.m_listViewTypesElementsDuFiltre.View = System.Windows.Forms.View.Details;
            this.m_listViewTypesElementsDuFiltre.SelectedIndexChanged += new System.EventHandler(this.m_listViewTypesElementsDuFiltre_SelectedIndexChanged);
            // 
            // m_listViewColumn
            // 
            this.m_listViewColumn.Field = "TypeElement.Libelle";
            this.m_listViewColumn.PrecisionWidth = 0;
            this.m_listViewColumn.ProportionnalSize = false;
            this.m_listViewColumn.Text = "Label|50";
            this.m_listViewColumn.Visible = true;
            this.m_listViewColumn.Width = 200;
            // 
            // m_colonneNombre
            // 
            this.m_colonneNombre.Field = "NombreElements";
            this.m_colonneNombre.PrecisionWidth = 0;
            this.m_colonneNombre.ProportionnalSize = false;
            this.m_colonneNombre.Visible = true;
            this.m_colonneNombre.Width = 50;
            // 
            // m_panelSelectElements
            // 
            this.m_panelSelectElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelSelectElements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelSelectElements.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelSelectElements, "");
            this.m_panelSelectElements.Location = new System.Drawing.Point(287, 44);
            this.m_panelSelectElements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSelectElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSelectElements, "");
            this.m_panelSelectElements.Name = "m_panelSelectElements";
            this.m_panelSelectElements.Size = new System.Drawing.Size(496, 252);
            this.m_extStyle.SetStyleBackColor(this.m_panelSelectElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSelectElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectElements.TabIndex = 8;
            this.m_panelSelectElements.OnChangeSelection += new System.EventHandler(this.m_panelSelectElements_OnChangeSelection);
            // 
            // label13
            // 
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(15, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(729, 36);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 7;
            this.label13.Text = resources.GetString("label13.Text");
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // cDraggeurDeControl1
            // 
            this.cDraggeurDeControl1.Controle = null;
            // 
            // CFormEditionParametrageFiltrageAlarmes
            // 
            this.ClientSize = new System.Drawing.Size(830, 569);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionParametrageFiltrageAlarmes";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_pagePeriodes.ResumeLayout(false);
            this.m_pageFiltre.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
        //-------------------------------------------------------------------------
		private CParametrageFiltrageAlarmes ParametrageFiltrageAlarmes
		{
			get
			{
				return (CParametrageFiltrageAlarmes)ObjetEdite;
			}
		}

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Alarm Filtering @1|10293", ParametrageFiltrageAlarmes.Libelle));

            CParametreFiltrageAlarmes parametre = ParametrageFiltrageAlarmes.Parametre;
            if (parametre == null)
                parametre = new CParametreFiltrageAlarmes();
            m_parametre = parametre;

            m_cmbSelecCategorieMasquage.Init(typeof(CCategorieMasquageAlarme), "Libelle", true);
            m_cmbSelecCategorieMasquage.ElementSelectionne = ParametrageFiltrageAlarmes.CategorieMasquage;
            m_dtPickerDateDebutValidite.Value = ParametrageFiltrageAlarmes.DateDebutValidite;
            m_dtPickerDateFinValidite.Value = ParametrageFiltrageAlarmes.DateFinValidite;

            FillListeTypesElementsPourFiltre();
            m_panelSelectElements.Visible = false;

            m_controleEditePeriode.Periode = m_parametre.Periode;

            return result;
        }

        //-----------------------------------------------------------------------------
        private void FillListeTypesElementsPourFiltre()
        {
            m_listViewTypesElementsDuFiltre.Items.Clear();

            IEnumALibelle[] typesPossibles =
                CUtilSurEnum.GetEnumsALibelle(typeof(CTypeElementPourFiltreAlarme));

            if (typesPossibles != null)
            {
                foreach (IEnumALibelle typeElement in typesPossibles)
                {
                    ListViewItem item = new ListViewItem();
                    m_listViewTypesElementsDuFiltre.UpdateItemWithObject(
                        item,
                        new CLocalTypeElementPourFiltreAlarme(typeElement,
                            GetNumberElementsByType(typeElement as CTypeElementPourFiltreAlarme)));
                    m_listViewTypesElementsDuFiltre.Items.Add(item);
                }
            }
            
        }

        //----------------------------------------------------------------------
        private int GetNumberElementsByType(CTypeElementPourFiltreAlarme type)
        {
            switch (type.Code)
            {
                case ETypeElementPourFiltreAlarme.AlarmType:
                    return m_parametre.Filtre.ListeIdsTypesAlarmes.Count;
                case ETypeElementPourFiltreAlarme.Site:
                    return m_parametre.Filtre.ListeIdsSites.Count;
                case ETypeElementPourFiltreAlarme.LogicalEquipment:
                    return m_parametre.Filtre.ListeIdsEquipementsLogiques.Count;
                case ETypeElementPourFiltreAlarme.NetworkLink:
                    return m_parametre.Filtre.ListeIdsLiensReseau.Count;
                case ETypeElementPourFiltreAlarme.SnmpEntity:
                    return m_parametre.Filtre.ListeIdsEntiesSnmp.Count;
                default:
                    break;
            }
                
            return 0;
        }

        //----------------------------------------------------------------------
        private class CLocalTypeElementPourFiltreAlarme
        {
            public CLocalTypeElementPourFiltreAlarme(IEnumALibelle tpElt, int nb)
            {
                TypeElement = tpElt as CTypeElementPourFiltreAlarme;
                NombreElements = nb;
            }
            public CTypeElementPourFiltreAlarme TypeElement { get; set; }
            public int NombreElements { get; set; }
        }

        //---------------------------------------------------------------------------
        private void ValideListeElements()
        {
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;

            if (m_parametre != null && m_typeElementsEnCours != null)
            {
                switch (m_typeElementsEnCours.Code)
                {
                    case ETypeElementPourFiltreAlarme.AlarmType:
                        m_parametre.Filtre.ListeIdsTypesAlarmes = new HashSet<CDbKey>(m_panelSelectElements.ListeDbKeysElements);
                        break;
                    case ETypeElementPourFiltreAlarme.Site:
                        m_parametre.Filtre.ListeIdsSites = new HashSet<CDbKey>(m_panelSelectElements.ListeDbKeysElements);
                        break;
                    case ETypeElementPourFiltreAlarme.LogicalEquipment:
                        m_parametre.Filtre.ListeIdsEquipementsLogiques = new HashSet<CDbKey>(m_panelSelectElements.ListeDbKeysElements);
                        break;
                    case ETypeElementPourFiltreAlarme.NetworkLink:
                        m_parametre.Filtre.ListeIdsLiensReseau = new HashSet<CDbKey>(m_panelSelectElements.ListeDbKeysElements);
                        break;
                    case ETypeElementPourFiltreAlarme.SnmpEntity:
                        m_parametre.Filtre.ListeIdsEntiesSnmp = new HashSet<CDbKey>(m_panelSelectElements.ListeDbKeysElements);
                        break;
                    default:
                        break;
                }
            }
        }

        private CTypeElementPourFiltreAlarme m_typeElementsEnCours;
        //----------------------------------------------------------------------------
        private void m_listViewTypesElementsDuFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValideListeElements();

            if(m_listViewTypesElementsDuFiltre.SelectedItems.Count == 1)
            {
                CLocalTypeElementPourFiltreAlarme selection = m_listViewTypesElementsDuFiltre.SelectedItems[0].Tag as CLocalTypeElementPourFiltreAlarme;
                if (selection != null && selection.TypeElement != null)
                {
                    CTypeElementPourFiltreAlarme elementSelectionne = selection.TypeElement;
                    Type tpElements = null;
                    List<CObjetDonneeAIdNumerique> listeElements = new List<CObjetDonneeAIdNumerique>();
                    m_panelSelectElements.Visible = true;
                    m_typeElementsEnCours = elementSelectionne;
                    switch (elementSelectionne.Code)
                    {
                        case ETypeElementPourFiltreAlarme.AlarmType:
                            tpElements = typeof(CTypeAlarme);
                            foreach (CDbKey dbKey in m_parametre.Filtre.ListeIdsTypesAlarmes)
                            {
                                CTypeAlarme element = new CTypeAlarme(ParametrageFiltrageAlarmes.ContexteDonnee);
                                if (element.ReadIfExists(dbKey))
                                    listeElements.Add(element);
                            }
                            break;
                        case ETypeElementPourFiltreAlarme.Site:
                            tpElements = typeof(CSite);
                            foreach (CDbKey dbKey in m_parametre.Filtre.ListeIdsSites)
                            {
                                CSite element = new CSite(ParametrageFiltrageAlarmes.ContexteDonnee);
                                if (element.ReadIfExists(dbKey))
                                    listeElements.Add(element);
                            }
                            break;
                        case ETypeElementPourFiltreAlarme.LogicalEquipment:
                            tpElements = typeof(CEquipementLogique);
                            foreach (CDbKey dbKey in m_parametre.Filtre.ListeIdsEquipementsLogiques)
                            {
                                CEquipementLogique element = new CEquipementLogique(ParametrageFiltrageAlarmes.ContexteDonnee);
                                if (element.ReadIfExists(dbKey))
                                    listeElements.Add(element);
                            }
                            break;
                        case ETypeElementPourFiltreAlarme.NetworkLink:
                            tpElements = typeof(CLienReseau);
                            foreach (CDbKey dbKey in m_parametre.Filtre.ListeIdsLiensReseau)
                            {
                                CLienReseau element = new CLienReseau(ParametrageFiltrageAlarmes.ContexteDonnee);
                                if (element.ReadIfExists(dbKey))
                                    listeElements.Add(element);
                            }
                            break;
                        case ETypeElementPourFiltreAlarme.SnmpEntity:
                            tpElements = typeof(CEntiteSnmp);
                            foreach (CDbKey dbKey in m_parametre.Filtre.ListeIdsEntiesSnmp)
                            {
                                CEntiteSnmp element = new CEntiteSnmp(ParametrageFiltrageAlarmes.ContexteDonnee);
                                if (element.ReadIfExists(dbKey))
                                    listeElements.Add(element);
                            }
                            break;
                        default:
                            break;
                    }
                    m_panelSelectElements.Init(tpElements, listeElements.ToArray(), null);
                }
                else
                    m_panelSelectElements.Visible = false;
            }
            else
                m_panelSelectElements.Visible = false;
        }
         
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (m_parametre != null)
            {
                ValideListeElements();
                m_parametre.Periode = m_controleEditePeriode.Periode;
                ParametrageFiltrageAlarmes.Parametre = m_parametre;
                ParametrageFiltrageAlarmes.CategorieMasquage = m_cmbSelecCategorieMasquage.ElementSelectionne as CCategorieMasquageAlarme;
                ParametrageFiltrageAlarmes.DateDebutValidite = m_dtPickerDateDebutValidite.Value;
                ParametrageFiltrageAlarmes.DateFinValidite = m_dtPickerDateFinValidite.Value;
            }

            return result;
        }

        private void m_lnkTestFilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CAlarme alarmeTest = CFormSelectUnObjetDonnee.SelectObjetDonnee(I.T("Select an element for test|20735"),typeof(CAlarme)) as CAlarme;

            using (CMemoryDb mdb = new CMemoryDb())
            {
                if (alarmeTest != null && m_parametre != null)
                {
                    bool bREsultat = m_parametre.Filtre.IsInFiltre(alarmeTest.GetLocalAlarme(mdb, false));
                    CFormAlerte.Afficher(bREsultat.ToString());
                }
            }
        }

        private void m_panelSelectElements_OnChangeSelection(object sender, EventArgs e)
        {
            ValideListeElements();
            FillListeTypesElementsPourFiltre();
        }

 

	}
}

