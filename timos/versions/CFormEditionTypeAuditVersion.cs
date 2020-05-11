using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.common;
using sc2i.data;
using sc2i.data.dynamic;
using sc2i.process;
using sc2i.expression;
using sc2i.win32.common;
using sc2i.win32.navigation;
using sc2i.win32.data;
using sc2i.win32.data.navigation;
using sc2i.win32.data.dynamic;

using timos.data.version;

namespace timos.version
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeAuditVersion))]
    public class CFormEditionTypeAuditVersion : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private Label m_lblLabel;
		private Panel m_panTop;
		private C2iTabControl m_TabControl;
		private Crownwood.Magic.Controls.TabPage m_pageFiltre;
		private Panel m_panGauche;
		private Crownwood.Magic.Controls.TabPage m_pageClesParticulieres;
		private CReducteurControle m_reducteurTop;
		private C2iTextBox m_txtDescription;
		private Label m_lblDescription;
		private C2iPanelOmbre m_panTypes;
		private Panel m_panContenuGauche;
		private GlacialList m_glsLstTypes;
		private Panel m_panFiltre;
		private CPanelEditFiltreDynamique m_panEditFiltre;
		private Panel m_panDown;
		private Panel m_panEditCleParticuliere;
		private sc2i.win32.expression.CTextBoxZoomFormule m_ctrlFormuleCleParticuliere;
		private GlacialList m_glsCles;
		private CWndLinkStd m_lnkAjouterCle;
		private CWndLinkStd m_lnkSupprimerTypeCle;
		private CWndLinkStd m_lnkSupprimerCle;
		private CWndLinkStd m_lnkAjouterTypeCle;
		private C2iTextBoxSelectionne m_selectType;
		private Label m_lblTypesConcernes;
		private ListViewAutoFilled m_lvTypeCle;
		private ListViewAutoFilledColumn colNomCleType;
		private C2iTextBox m_txtNomCle;
		private Label m_lblNomCle;
		private ComboBox m_cmbTypesSelectionnes;
		private ComboBox m_cmbTypesAvecStructurant;
		private Label m_lblTypesSelecs;
		private Label m_lblTypesStructurant;
		private Label m_lblClePart;
		private Crownwood.Magic.Controls.TabPage m_pageFormules;
		private sc2i.win32.expression.CTextBoxZoomFormule m_ctrlFormuleDescription;
		private Label m_lblFormuleDescription;
		private sc2i.win32.expression.CTextBoxZoomFormule m_ctrlFormuleCle;
		private Label m_lblFormule;
		private C2iPanelOmbre m_panEleSelec;
		private Label m_lblEleSelec;
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
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeAuditVersion));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_panGauche = new System.Windows.Forms.Panel();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageFormules = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlFormuleDescription = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormuleDescription = new System.Windows.Forms.Label();
            this.m_ctrlFormuleCle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormule = new System.Windows.Forms.Label();
            this.m_pageFiltre = new Crownwood.Magic.Controls.TabPage();
            this.m_panFiltre = new System.Windows.Forms.Panel();
            this.m_panEditFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_pageClesParticulieres = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimerCle = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterCle = new sc2i.win32.common.CWndLinkStd();
            this.m_glsCles = new sc2i.win32.common.GlacialList();
            this.m_panEditCleParticuliere = new System.Windows.Forms.Panel();
            this.m_lblClePart = new System.Windows.Forms.Label();
            this.m_lvTypeCle = new sc2i.win32.common.ListViewAutoFilled();
            this.colNomCleType = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtNomCle = new sc2i.win32.common.C2iTextBox();
            this.m_lnkAjouterTypeCle = new sc2i.win32.common.CWndLinkStd();
            this.m_selectType = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkSupprimerTypeCle = new sc2i.win32.common.CWndLinkStd();
            this.m_lblNomCle = new System.Windows.Forms.Label();
            this.m_ctrlFormuleCleParticuliere = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblTypesConcernes = new System.Windows.Forms.Label();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.m_panDown = new System.Windows.Forms.Panel();
            this.m_panEleSelec = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lblEleSelec = new System.Windows.Forms.Label();
            this.m_panTypes = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panContenuGauche = new System.Windows.Forms.Panel();
            this.m_glsLstTypes = new sc2i.win32.common.GlacialList();
            this.m_cmbTypesSelectionnes = new System.Windows.Forms.ComboBox();
            this.m_cmbTypesAvecStructurant = new System.Windows.Forms.ComboBox();
            this.m_lblTypesSelecs = new System.Windows.Forms.Label();
            this.m_lblTypesStructurant = new System.Windows.Forms.Label();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panOmbre.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.m_panGauche.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageFormules.SuspendLayout();
            this.m_pageFiltre.SuspendLayout();
            this.m_panFiltre.SuspendLayout();
            this.m_pageClesParticulieres.SuspendLayout();
            this.m_panEditCleParticuliere.SuspendLayout();
            this.m_panDown.SuspendLayout();
            this.m_panEleSelec.SuspendLayout();
            this.m_panTypes.SuspendLayout();
            this.m_panContenuGauche.SuspendLayout();
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
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(83, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(702, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panTop);
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panOmbre, "");
            this.m_panOmbre.Location = new System.Drawing.Point(8, 52);
            this.m_panOmbre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panOmbre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panOmbre, "");
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(810, 144);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panOmbre.TabIndex = 0;
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.Controls.Add(this.m_panGauche);
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(795, 128);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 4011;
            // 
            // m_panGauche
            // 
            this.m_panGauche.Controls.Add(this.m_txtDescription);
            this.m_panGauche.Controls.Add(this.m_txtLibelle);
            this.m_panGauche.Controls.Add(this.m_lblDescription);
            this.m_panGauche.Controls.Add(this.m_lblLabel);
            this.m_panGauche.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panGauche, "");
            this.m_panGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panGauche, "");
            this.m_panGauche.Name = "m_panGauche";
            this.m_panGauche.Size = new System.Drawing.Size(795, 128);
            this.m_extStyle.SetStyleBackColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGauche.TabIndex = 4021;
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_txtDescription.Location = new System.Drawing.Point(83, 34);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(702, 82);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 0;
            this.m_txtDescription.Text = "[Description]";
            // 
            // m_lblDescription
            // 
            this.m_extLinkField.SetLinkField(this.m_lblDescription, "");
            this.m_lblDescription.Location = new System.Drawing.Point(4, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblDescription, "");
            this.m_lblDescription.Name = "m_lblDescription";
            this.m_lblDescription.Size = new System.Drawing.Size(86, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDescription.TabIndex = 4005;
            this.m_lblDescription.Text = "Description|41";
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(4, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4005;
            this.m_lblLabel.Text = "Label|50";
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
            this.m_TabControl.Enabled = false;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(262, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 1;
            this.m_TabControl.SelectedTab = this.m_pageFiltre;
            this.m_TabControl.Size = new System.Drawing.Size(556, 276);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4005;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormules,
            this.m_pageFiltre,
            this.m_pageClesParticulieres});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageFormules
            // 
            this.m_pageFormules.Controls.Add(this.m_ctrlFormuleDescription);
            this.m_pageFormules.Controls.Add(this.m_lblFormuleDescription);
            this.m_pageFormules.Controls.Add(this.m_ctrlFormuleCle);
            this.m_pageFormules.Controls.Add(this.m_lblFormule);
            this.m_extLinkField.SetLinkField(this.m_pageFormules, "");
            this.m_pageFormules.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormules, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormules, "");
            this.m_pageFormules.Name = "m_pageFormules";
            this.m_pageFormules.Selected = false;
            this.m_pageFormules.Size = new System.Drawing.Size(540, 235);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormules.TabIndex = 15;
            this.m_pageFormules.Title = "Formulas|1426";
            // 
            // m_ctrlFormuleDescription
            // 
            this.m_ctrlFormuleDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlFormuleDescription.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_ctrlFormuleDescription, "");
            this.m_ctrlFormuleDescription.Location = new System.Drawing.Point(81, 40);
            this.m_ctrlFormuleDescription.LockEdition = false;
            this.m_ctrlFormuleDescription.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlFormuleDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlFormuleDescription, "");
            this.m_ctrlFormuleDescription.Name = "m_ctrlFormuleDescription";
            this.m_ctrlFormuleDescription.Size = new System.Drawing.Size(217, 19);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlFormuleDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlFormuleDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlFormuleDescription.TabIndex = 4006;
            // 
            // m_lblFormuleDescription
            // 
            this.m_extLinkField.SetLinkField(this.m_lblFormuleDescription, "");
            this.m_lblFormuleDescription.Location = new System.Drawing.Point(9, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblFormuleDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblFormuleDescription, "");
            this.m_lblFormuleDescription.Name = "m_lblFormuleDescription";
            this.m_lblFormuleDescription.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblFormuleDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFormuleDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFormuleDescription.TabIndex = 4007;
            this.m_lblFormuleDescription.Text = "Description|41";
            // 
            // m_ctrlFormuleCle
            // 
            this.m_ctrlFormuleCle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlFormuleCle.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_ctrlFormuleCle, "");
            this.m_ctrlFormuleCle.Location = new System.Drawing.Point(81, 15);
            this.m_ctrlFormuleCle.LockEdition = false;
            this.m_ctrlFormuleCle.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlFormuleCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlFormuleCle, "");
            this.m_ctrlFormuleCle.Name = "m_ctrlFormuleCle";
            this.m_ctrlFormuleCle.Size = new System.Drawing.Size(217, 19);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlFormuleCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlFormuleCle.TabIndex = 4006;
            // 
            // m_lblFormule
            // 
            this.m_extLinkField.SetLinkField(this.m_lblFormule, "");
            this.m_lblFormule.Location = new System.Drawing.Point(9, 17);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblFormule, "");
            this.m_lblFormule.Name = "m_lblFormule";
            this.m_lblFormule.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFormule.TabIndex = 4007;
            this.m_lblFormule.Text = "Key|43";
            // 
            // m_pageFiltre
            // 
            this.m_pageFiltre.Controls.Add(this.m_panFiltre);
            this.m_extLinkField.SetLinkField(this.m_pageFiltre, "");
            this.m_pageFiltre.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiltre, "");
            this.m_pageFiltre.Name = "m_pageFiltre";
            this.m_pageFiltre.Selected = false;
            this.m_pageFiltre.Size = new System.Drawing.Size(540, 235);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiltre.TabIndex = 13;
            this.m_pageFiltre.Title = "Filter|47";
            // 
            // m_panFiltre
            // 
            this.m_panFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panFiltre.Controls.Add(this.m_panEditFiltre);
            this.m_extLinkField.SetLinkField(this.m_panFiltre, "");
            this.m_panFiltre.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panFiltre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panFiltre, "");
            this.m_panFiltre.Name = "m_panFiltre";
            this.m_panFiltre.Size = new System.Drawing.Size(534, 232);
            this.m_extStyle.SetStyleBackColor(this.m_panFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panFiltre.TabIndex = 0;
            // 
            // m_panEditFiltre
            // 
            this.m_panEditFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panEditFiltre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panEditFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panEditFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panEditFiltre, "");
            this.m_panEditFiltre.Location = new System.Drawing.Point(3, 0);
            this.m_panEditFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panEditFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panEditFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panEditFiltre, "");
            this.m_panEditFiltre.Name = "m_panEditFiltre";
            this.m_panEditFiltre.Size = new System.Drawing.Size(525, 226);
            this.m_extStyle.SetStyleBackColor(this.m_panEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panEditFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panEditFiltre.TabIndex = 4006;
            // 
            // m_pageClesParticulieres
            // 
            this.m_pageClesParticulieres.Controls.Add(this.m_lnkSupprimerCle);
            this.m_pageClesParticulieres.Controls.Add(this.m_lnkAjouterCle);
            this.m_pageClesParticulieres.Controls.Add(this.m_glsCles);
            this.m_pageClesParticulieres.Controls.Add(this.m_panEditCleParticuliere);
            this.m_extLinkField.SetLinkField(this.m_pageClesParticulieres, "");
            this.m_pageClesParticulieres.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageClesParticulieres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageClesParticulieres, "");
            this.m_pageClesParticulieres.Name = "m_pageClesParticulieres";
            this.m_pageClesParticulieres.Selected = false;
            this.m_pageClesParticulieres.Size = new System.Drawing.Size(540, 235);
            this.m_extStyle.SetStyleBackColor(this.m_pageClesParticulieres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageClesParticulieres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageClesParticulieres.TabIndex = 14;
            this.m_pageClesParticulieres.Title = "Keys by Type|1394";
            // 
            // m_lnkSupprimerCle
            // 
            this.m_lnkSupprimerCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerCle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerCle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerCle, "");
            this.m_lnkSupprimerCle.Location = new System.Drawing.Point(90, 209);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerCle, "");
            this.m_lnkSupprimerCle.Name = "m_lnkSupprimerCle";
            this.m_lnkSupprimerCle.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerCle.TabIndex = 4010;
            this.m_lnkSupprimerCle.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerCle.LinkClicked += new System.EventHandler(this.m_lnkSupprimerCle_LinkClicked);
            // 
            // m_lnkAjouterCle
            // 
            this.m_lnkAjouterCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkAjouterCle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterCle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterCle, "");
            this.m_lnkAjouterCle.Location = new System.Drawing.Point(3, 211);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterCle, "");
            this.m_lnkAjouterCle.Name = "m_lnkAjouterCle";
            this.m_lnkAjouterCle.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterCle.TabIndex = 4008;
            this.m_lnkAjouterCle.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterCle.LinkClicked += new System.EventHandler(this.m_lnkAjouterCle_LinkClicked);
            // 
            // m_glsCles
            // 
            this.m_glsCles.AllowColumnResize = true;
            this.m_glsCles.AllowMultiselect = false;
            this.m_glsCles.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_glsCles.AlternatingColors = false;
            this.m_glsCles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_glsCles.AutoHeight = true;
            this.m_glsCles.AutoSort = true;
            this.m_glsCles.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_glsCles.CanChangeActivationCheckBoxes = false;
            this.m_glsCles.CheckBoxes = false;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "colCles";
            glColumn3.Propriete = "Nom";
            glColumn3.Text = "Keys|45";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 150;
            this.m_glsCles.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_glsCles.ContexteUtilisation = "";
            this.m_glsCles.EnableCustomisation = true;
            this.m_glsCles.FocusedItem = null;
            this.m_glsCles.FullRowSelect = true;
            this.m_glsCles.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_glsCles.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_glsCles.HeaderHeight = 22;
            this.m_glsCles.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_glsCles.HeaderTextColor = System.Drawing.Color.Black;
            this.m_glsCles.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_glsCles.HeaderVisible = true;
            this.m_glsCles.HeaderWordWrap = false;
            this.m_glsCles.HotColumnIndex = -1;
            this.m_glsCles.HotItemIndex = -1;
            this.m_glsCles.HotTracking = false;
            this.m_glsCles.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_glsCles.ImageList = null;
            this.m_glsCles.ItemHeight = 18;
            this.m_glsCles.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_glsCles, "");
            this.m_glsCles.ListeSource = null;
            this.m_glsCles.Location = new System.Drawing.Point(3, 6);
            this.m_glsCles.MaxHeight = 18;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_glsCles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_glsCles, "");
            this.m_glsCles.Name = "m_glsCles";
            this.m_glsCles.SelectedTextColor = System.Drawing.Color.White;
            this.m_glsCles.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_glsCles.ShowBorder = true;
            this.m_glsCles.ShowFocusRect = true;
            this.m_glsCles.Size = new System.Drawing.Size(175, 199);
            this.m_glsCles.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_glsCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_glsCles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_glsCles.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_glsCles.TabIndex = 0;
            this.m_glsCles.Text = "Keys by type|1419";
            this.m_glsCles.TrierAuClicSurEnteteColonne = true;
            this.m_glsCles.OnChangeSelection += new System.EventHandler(this.m_glsCles_OnChangeSelection);
            // 
            // m_panEditCleParticuliere
            // 
            this.m_panEditCleParticuliere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panEditCleParticuliere.Controls.Add(this.m_lblClePart);
            this.m_panEditCleParticuliere.Controls.Add(this.m_lvTypeCle);
            this.m_panEditCleParticuliere.Controls.Add(this.m_txtNomCle);
            this.m_panEditCleParticuliere.Controls.Add(this.m_lnkAjouterTypeCle);
            this.m_panEditCleParticuliere.Controls.Add(this.m_selectType);
            this.m_panEditCleParticuliere.Controls.Add(this.m_lnkSupprimerTypeCle);
            this.m_panEditCleParticuliere.Controls.Add(this.m_lblNomCle);
            this.m_panEditCleParticuliere.Controls.Add(this.m_ctrlFormuleCleParticuliere);
            this.m_panEditCleParticuliere.Controls.Add(this.m_lblTypesConcernes);
            this.m_extLinkField.SetLinkField(this.m_panEditCleParticuliere, "");
            this.m_panEditCleParticuliere.Location = new System.Drawing.Point(194, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panEditCleParticuliere, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panEditCleParticuliere, "");
            this.m_panEditCleParticuliere.Name = "m_panEditCleParticuliere";
            this.m_panEditCleParticuliere.Size = new System.Drawing.Size(343, 229);
            this.m_extStyle.SetStyleBackColor(this.m_panEditCleParticuliere, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panEditCleParticuliere, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panEditCleParticuliere.TabIndex = 0;
            // 
            // m_lblClePart
            // 
            this.m_extLinkField.SetLinkField(this.m_lblClePart, "");
            this.m_lblClePart.Location = new System.Drawing.Point(10, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblClePart, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblClePart, "");
            this.m_lblClePart.Name = "m_lblClePart";
            this.m_lblClePart.Size = new System.Drawing.Size(66, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblClePart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblClePart, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblClePart.TabIndex = 4018;
            this.m_lblClePart.Text = "Key|43";
            // 
            // m_lvTypeCle
            // 
            this.m_lvTypeCle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lvTypeCle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNomCleType});
            this.m_lvTypeCle.EnableCustomisation = true;
            this.m_lvTypeCle.FullRowSelect = true;
            this.m_lvTypeCle.GridLines = true;
            this.m_lvTypeCle.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_lvTypeCle, "");
            this.m_lvTypeCle.Location = new System.Drawing.Point(13, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lvTypeCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lvTypeCle, "");
            this.m_lvTypeCle.MultiSelect = false;
            this.m_lvTypeCle.Name = "m_lvTypeCle";
            this.m_lvTypeCle.Size = new System.Drawing.Size(311, 97);
            this.m_extStyle.SetStyleBackColor(this.m_lvTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lvTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lvTypeCle.TabIndex = 4017;
            this.m_lvTypeCle.UseCompatibleStateImageBehavior = false;
            this.m_lvTypeCle.View = System.Windows.Forms.View.Details;
            this.m_lvTypeCle.SelectedIndexChanged += new System.EventHandler(this.m_lvTypeCle_SelectedIndexChanged);
            // 
            // colNomCleType
            // 
            this.colNomCleType.Field = "Libelle";
            this.colNomCleType.PrecisionWidth = 0;
            this.colNomCleType.ProportionnalSize = false;
            this.colNomCleType.Text = "Label|50";
            this.colNomCleType.Visible = true;
            this.colNomCleType.Width = 156;
            // 
            // m_txtNomCle
            // 
            this.m_txtNomCle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_txtNomCle, "");
            this.m_txtNomCle.Location = new System.Drawing.Point(80, 3);
            this.m_txtNomCle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNomCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNomCle, "");
            this.m_txtNomCle.Name = "m_txtNomCle";
            this.m_txtNomCle.Size = new System.Drawing.Size(244, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomCle.TabIndex = 0;
            // 
            // m_lnkAjouterTypeCle
            // 
            this.m_lnkAjouterTypeCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkAjouterTypeCle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterTypeCle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterTypeCle, "");
            this.m_lnkAjouterTypeCle.Location = new System.Drawing.Point(220, 83);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterTypeCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterTypeCle, "");
            this.m_lnkAjouterTypeCle.Name = "m_lnkAjouterTypeCle";
            this.m_lnkAjouterTypeCle.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterTypeCle.TabIndex = 4008;
            this.m_lnkAjouterTypeCle.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterTypeCle.LinkClicked += new System.EventHandler(this.m_lnkAjouterTypeCle_LinkClicked);
            // 
            // m_selectType
            // 
            this.m_selectType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectType.ElementSelectionne = null;
            this.m_selectType.FonctionTextNull = null;
            this.m_selectType.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectType, "");
            this.m_selectType.Location = new System.Drawing.Point(13, 81);
            this.m_selectType.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectType, "");
            this.m_selectType.Name = "m_selectType";
            this.m_selectType.SelectedObject = null;
            this.m_selectType.Size = new System.Drawing.Size(201, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectType.TabIndex = 4016;
            this.m_selectType.TextNull = "";
            this.m_selectType.ElementSelectionneChanged += new System.EventHandler(this.m_selectType_ElementSelectionneChanged);
            // 
            // m_lnkSupprimerTypeCle
            // 
            this.m_lnkSupprimerTypeCle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkSupprimerTypeCle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerTypeCle.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerTypeCle, "");
            this.m_lnkSupprimerTypeCle.Location = new System.Drawing.Point(236, 204);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerTypeCle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerTypeCle, "");
            this.m_lnkSupprimerTypeCle.Name = "m_lnkSupprimerTypeCle";
            this.m_lnkSupprimerTypeCle.Size = new System.Drawing.Size(88, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerTypeCle.TabIndex = 4010;
            this.m_lnkSupprimerTypeCle.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerTypeCle.LinkClicked += new System.EventHandler(this.m_lnkSupprimerTypeCle_LinkClicked);
            // 
            // m_lblNomCle
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNomCle, "");
            this.m_lblNomCle.Location = new System.Drawing.Point(10, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNomCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblNomCle, "");
            this.m_lblNomCle.Name = "m_lblNomCle";
            this.m_lblNomCle.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblNomCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNomCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomCle.TabIndex = 4005;
            this.m_lblNomCle.Text = "Key name|1392";
            // 
            // m_ctrlFormuleCleParticuliere
            // 
            this.m_ctrlFormuleCleParticuliere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctrlFormuleCleParticuliere.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_ctrlFormuleCleParticuliere, "");
            this.m_ctrlFormuleCleParticuliere.Location = new System.Drawing.Point(80, 31);
            this.m_ctrlFormuleCleParticuliere.LockEdition = false;
            this.m_ctrlFormuleCleParticuliere.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlFormuleCleParticuliere, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlFormuleCleParticuliere, "");
            this.m_ctrlFormuleCleParticuliere.Name = "m_ctrlFormuleCleParticuliere";
            this.m_ctrlFormuleCleParticuliere.Size = new System.Drawing.Size(244, 19);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlFormuleCleParticuliere, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlFormuleCleParticuliere, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlFormuleCleParticuliere.TabIndex = 15;
            // 
            // m_lblTypesConcernes
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypesConcernes, "");
            this.m_lblTypesConcernes.Location = new System.Drawing.Point(10, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypesConcernes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypesConcernes, "");
            this.m_lblTypesConcernes.Name = "m_lblTypesConcernes";
            this.m_lblTypesConcernes.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypesConcernes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypesConcernes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypesConcernes.TabIndex = 4005;
            this.m_lblTypesConcernes.Text = "Concerned Types...|1393";
            // 
            // m_reducteurTop
            // 
            this.m_reducteurTop.ControleAgrandit = this.m_panDown;
            this.m_reducteurTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducteurTop.ControleReduit = this.m_panOmbre;
            this.m_extLinkField.SetLinkField(this.m_reducteurTop, "");
            this.m_reducteurTop.Location = new System.Drawing.Point(409, 48);
            this.m_reducteurTop.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteurTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteurTop, "");
            this.m_reducteurTop.Name = "m_reducteurTop";
            this.m_reducteurTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteurTop.TabIndex = 4012;
            this.m_reducteurTop.TailleReduite = 32;
            // 
            // m_panDown
            // 
            this.m_panDown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panDown.Controls.Add(this.m_TabControl);
            this.m_panDown.Controls.Add(this.m_panEleSelec);
            this.m_panDown.Controls.Add(this.m_panTypes);
            this.m_extLinkField.SetLinkField(this.m_panDown, "");
            this.m_panDown.Location = new System.Drawing.Point(0, 202);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panDown, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panDown, "");
            this.m_panDown.Name = "m_panDown";
            this.m_panDown.Size = new System.Drawing.Size(830, 323);
            this.m_extStyle.SetStyleBackColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDown.TabIndex = 4013;
            // 
            // m_panEleSelec
            // 
            this.m_panEleSelec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panEleSelec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panEleSelec.Controls.Add(this.m_lblEleSelec);
            this.m_extLinkField.SetLinkField(this.m_panEleSelec, "");
            this.m_panEleSelec.Location = new System.Drawing.Point(262, 6);
            this.m_panEleSelec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panEleSelec, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panEleSelec, "");
            this.m_panEleSelec.Name = "m_panEleSelec";
            this.m_panEleSelec.Size = new System.Drawing.Size(556, 38);
            this.m_extStyle.SetStyleBackColor(this.m_panEleSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panEleSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panEleSelec.TabIndex = 4006;
            // 
            // m_lblEleSelec
            // 
            this.m_lblEleSelec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lblEleSelec, "");
            this.m_lblEleSelec.Location = new System.Drawing.Point(2, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEleSelec, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblEleSelec, "");
            this.m_lblEleSelec.Name = "m_lblEleSelec";
            this.m_lblEleSelec.Size = new System.Drawing.Size(539, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblEleSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEleSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEleSelec.TabIndex = 4005;
            this.m_lblEleSelec.Text = "No selected type|30001";
            // 
            // m_panTypes
            // 
            this.m_panTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panTypes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTypes.Controls.Add(this.m_panContenuGauche);
            this.m_panTypes.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTypes, "");
            this.m_panTypes.Location = new System.Drawing.Point(8, 3);
            this.m_panTypes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTypes, "");
            this.m_panTypes.Name = "m_panTypes";
            this.m_panTypes.Size = new System.Drawing.Size(244, 317);
            this.m_extStyle.SetStyleBackColor(this.m_panTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTypes.TabIndex = 0;
            // 
            // m_panContenuGauche
            // 
            this.m_panContenuGauche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panContenuGauche.Controls.Add(this.m_glsLstTypes);
            this.m_panContenuGauche.Controls.Add(this.m_cmbTypesSelectionnes);
            this.m_panContenuGauche.Controls.Add(this.m_cmbTypesAvecStructurant);
            this.m_panContenuGauche.Controls.Add(this.m_lblTypesSelecs);
            this.m_panContenuGauche.Controls.Add(this.m_lblTypesStructurant);
            this.m_extLinkField.SetLinkField(this.m_panContenuGauche, "");
            this.m_panContenuGauche.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panContenuGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panContenuGauche, "");
            this.m_panContenuGauche.Name = "m_panContenuGauche";
            this.m_panContenuGauche.Size = new System.Drawing.Size(229, 301);
            this.m_extStyle.SetStyleBackColor(this.m_panContenuGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panContenuGauche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panContenuGauche.TabIndex = 4021;
            // 
            // m_glsLstTypes
            // 
            this.m_glsLstTypes.AllowColumnResize = true;
            this.m_glsLstTypes.AllowMultiselect = false;
            this.m_glsLstTypes.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_glsLstTypes.AlternatingColors = false;
            this.m_glsLstTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_glsLstTypes.AutoHeight = true;
            this.m_glsLstTypes.AutoSort = true;
            this.m_glsLstTypes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_glsLstTypes.CanChangeActivationCheckBoxes = false;
            this.m_glsLstTypes.CheckBoxes = false;
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "colTypes";
            glColumn1.Propriete = "Nom";
            glColumn1.Text = "Types|44";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 180;
            this.m_glsLstTypes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_glsLstTypes.ContexteUtilisation = "";
            this.m_glsLstTypes.EnableCustomisation = true;
            this.m_glsLstTypes.FocusedItem = null;
            this.m_glsLstTypes.FullRowSelect = true;
            this.m_glsLstTypes.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_glsLstTypes.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_glsLstTypes.HeaderHeight = 22;
            this.m_glsLstTypes.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_glsLstTypes.HeaderTextColor = System.Drawing.Color.Black;
            this.m_glsLstTypes.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_glsLstTypes.HeaderVisible = true;
            this.m_glsLstTypes.HeaderWordWrap = false;
            this.m_glsLstTypes.HotColumnIndex = -1;
            this.m_glsLstTypes.HotItemIndex = -1;
            this.m_glsLstTypes.HotTracking = false;
            this.m_glsLstTypes.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_glsLstTypes.ImageList = null;
            this.m_glsLstTypes.ItemHeight = 17;
            this.m_glsLstTypes.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_glsLstTypes, "");
            this.m_glsLstTypes.ListeSource = null;
            this.m_glsLstTypes.Location = new System.Drawing.Point(3, 3);
            this.m_glsLstTypes.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_glsLstTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_glsLstTypes, "");
            this.m_glsLstTypes.Name = "m_glsLstTypes";
            this.m_glsLstTypes.SelectedTextColor = System.Drawing.Color.White;
            this.m_glsLstTypes.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_glsLstTypes.ShowBorder = true;
            this.m_glsLstTypes.ShowFocusRect = true;
            this.m_glsLstTypes.Size = new System.Drawing.Size(223, 292);
            this.m_glsLstTypes.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_glsLstTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_glsLstTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_glsLstTypes.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_glsLstTypes.TabIndex = 0;
            this.m_glsLstTypes.Text = "Types list|1418";
            this.m_glsLstTypes.TrierAuClicSurEnteteColonne = true;
            this.m_glsLstTypes.CheckedChange += new sc2i.win32.common.GlacialListCheckedChangeEventHandler(this.m_glsLstTypes_CheckedChange);
            this.m_glsLstTypes.OnChangeSelection += new System.EventHandler(this.m_glsLstTypes_OnChangeSelection);
            // 
            // m_cmbTypesSelectionnes
            // 
            this.m_cmbTypesSelectionnes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypesSelectionnes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypesSelectionnes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmbTypesSelectionnes.FormattingEnabled = true;
            this.m_extLinkField.SetLinkField(this.m_cmbTypesSelectionnes, "");
            this.m_cmbTypesSelectionnes.Location = new System.Drawing.Point(140, 274);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypesSelectionnes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypesSelectionnes, "");
            this.m_cmbTypesSelectionnes.Name = "m_cmbTypesSelectionnes";
            this.m_cmbTypesSelectionnes.Size = new System.Drawing.Size(85, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypesSelectionnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypesSelectionnes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypesSelectionnes.TabIndex = 4006;
            // 
            // m_cmbTypesAvecStructurant
            // 
            this.m_cmbTypesAvecStructurant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypesAvecStructurant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypesAvecStructurant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmbTypesAvecStructurant.FormattingEnabled = true;
            this.m_extLinkField.SetLinkField(this.m_cmbTypesAvecStructurant, "");
            this.m_cmbTypesAvecStructurant.Location = new System.Drawing.Point(140, 251);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypesAvecStructurant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypesAvecStructurant, "");
            this.m_cmbTypesAvecStructurant.Name = "m_cmbTypesAvecStructurant";
            this.m_cmbTypesAvecStructurant.Size = new System.Drawing.Size(85, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypesAvecStructurant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypesAvecStructurant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypesAvecStructurant.TabIndex = 4006;
            // 
            // m_lblTypesSelecs
            // 
            this.m_lblTypesSelecs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_lblTypesSelecs, "");
            this.m_lblTypesSelecs.Location = new System.Drawing.Point(4, 277);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypesSelecs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypesSelecs, "");
            this.m_lblTypesSelecs.Name = "m_lblTypesSelecs";
            this.m_lblTypesSelecs.Size = new System.Drawing.Size(130, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypesSelecs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypesSelecs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypesSelecs.TabIndex = 4005;
            this.m_lblTypesSelecs.Text = "Selected Types|1416";
            // 
            // m_lblTypesStructurant
            // 
            this.m_lblTypesStructurant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_lblTypesStructurant, "");
            this.m_lblTypesStructurant.Location = new System.Drawing.Point(4, 254);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypesStructurant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypesStructurant, "");
            this.m_lblTypesStructurant.Name = "m_lblTypesStructurant";
            this.m_lblTypesStructurant.Size = new System.Drawing.Size(160, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypesStructurant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypesStructurant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypesStructurant.TabIndex = 4005;
            this.m_lblTypesStructurant.Text = "Structured types|1417";
            // 
            // CFormEditionTypeAuditVersion
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_panDown);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_panOmbre);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeAuditVersion";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.Controls.SetChildIndex(this.m_panOmbre, 0);
            this.Controls.SetChildIndex(this.m_reducteurTop, 0);
            this.Controls.SetChildIndex(this.m_panDown, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panTop.ResumeLayout(false);
            this.m_panGauche.ResumeLayout(false);
            this.m_panGauche.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageFormules.ResumeLayout(false);
            this.m_pageFiltre.ResumeLayout(false);
            this.m_panFiltre.ResumeLayout(false);
            this.m_pageClesParticulieres.ResumeLayout(false);
            this.m_panEditCleParticuliere.ResumeLayout(false);
            this.m_panEditCleParticuliere.PerformLayout();
            this.m_panDown.ResumeLayout(false);
            this.m_panEleSelec.ResumeLayout(false);
            this.m_panEleSelec.PerformLayout();
            this.m_panTypes.ResumeLayout(false);
            this.m_panTypes.PerformLayout();
            this.m_panContenuGauche.ResumeLayout(false);
            this.ResumeLayout(false);

		}

	
		#endregion

		public CFormEditionTypeAuditVersion()
            : base()
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
		public CFormEditionTypeAuditVersion(CTypeAuditVersion typeAudit)
			: base(typeAudit)
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
		public CFormEditionTypeAuditVersion(CTypeAuditVersion typeAudit, CListeObjetsDonnees liste)
			: base(typeAudit, liste)
        {
            InitializeComponent();
		}


		private string m_strNomTypeSelectionne;
		private bool m_bInitialise;
		//--------------------------------------------------------------------------------------
		private CTypeAuditVersion TypeAudit
        {
			get 
            {
				return (CTypeAuditVersion)ObjetEdite; 
            }
		}
		private CAuditVersionParametrage m_parametrage;
		private CAuditVersionParametrage Parametrage
		{
			get
			{
				return m_parametrage;
			}
		}
		private bool EnEdition
		{
			get
			{
				return m_gestionnaireModeEdition.ModeEdition;
			}
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
			m_bInitialise = false;
            CResultAErreur result = base.MyInitChamps();
			
			AffecterTitre(I.T( "Audit type @1 for version|1390", TypeAudit.Libelle));

			m_parametrage = TypeAudit.ParametrageObject;
			if (m_parametrage == null)
			{
				result.EmpileErreur(I.T("Loading error|1391"));
				return result;
			}

			InitTypes();
			if(ParametrageTypeSelectionne == null)
				AffichageTypeSelectionne = false;

			m_bInitialise = true;
            return result;
		}
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			ValiderType();
			ValiderCle();
			TypeAudit.ParametrageObject = m_parametrage;

			return result;
		}


		

		private	Type m_tTypeStructurant = typeof(IElementATypeStructurantBase);
		private bool IsTypeElementATypeStructurant(Type t)
		{
			return m_tTypeStructurant.IsAssignableFrom(t);
		}

		//CHARGEMENTS
		

		//AFFICHAGE
		private bool AffichageTypeSelectionne
		{
			set
			{
				m_panFiltre.Visible = value;
				if (!value)
				{
					AffichagePageClesParticuliereVisible = false;
					AffichageCleSelectionnee = false;
				}
			}
		}
		private bool AffichagePageClesParticuliereVisible
		{
			get
			{
				return m_TabControl.Contains(m_pageClesParticulieres);
			}
			set
			{
				if (m_TabControl.Contains(m_pageClesParticulieres) && value == false)
					m_TabControl.TabPages.Remove(m_pageClesParticulieres);
				else if (!m_TabControl.Contains(m_pageClesParticulieres) && value == true)
					m_TabControl.TabPages.Add(m_pageClesParticulieres);
			}
		}
		private bool AffichageCleSelectionnee
		{
			set
			{
				m_panEditCleParticuliere.Visible = value;
				m_lnkSupprimerCle.Visible = value;
				if (!value)
				{
					AffichageTypeStructurantSelectionne = false;
				}
			}
		}
		private bool AffichageTypeStructurantSelectionne
		{
			set
			{
				m_lnkSupprimerTypeCle.Visible = value;
			}
		}


		#region TYPES
		private void InitTypes()
		{
			m_glsLstTypes.CheckBoxes = EnEdition;

			CInfoClasseDynamique[] classes = DynamicClassAttribute.GetAllDynamicClass();
			m_glsLstTypes.ListeSource = null;

			ArrayList lst = new ArrayList();
			List<int> idsEleSelec = new List<int>();
			int nIdSelec = -1;
			int nCptSelc = 0;
			int nCptId = 0;
			

			foreach (CInfoClasseDynamique c in classes)
			{
				bool bTypeParametre = m_parametrage.IsTypeParametre(c.Classe.Name);

				bool bAdd = false;
				if (bTypeParametre)
					idsEleSelec.Add(nCptId);
				if (!EnEdition)
				{
					if (m_parametrage == null)
						break;
					bAdd = bTypeParametre;
				}
				else
					bAdd = true;

				if (bAdd)
				{

					lst.Add(c);
					if (m_strNomTypeSelectionne != null && m_strNomTypeSelectionne == c.Classe.Name)
						nIdSelec = nCptSelc;
					nCptSelc++;
				}

				nCptId++;
			}
			m_glsLstTypes.ListeSource = lst;

			//SELECTION DES ELEMENTS
			if (EnEdition)
				for (int n = 0; n <= nCptId; n++)
					if (idsEleSelec.Contains(n))
						m_glsLstTypes.CheckItem(n);
					else
						m_glsLstTypes.UnCheckItem(n);

			m_glsLstTypes.Refresh();

			//ON SELECTIONNE LE DERNIER ELEMENT
			if (nIdSelec != -1)
			{
				m_glsLstTypes.SelectItem(nIdSelec);
				FillTypeSelec();
			}
		}

		private CInfoClasseDynamique TypeSelectionne
		{
			get
			{
				if (m_glsLstTypes.SelectedItems.Count == 1 )
					return (CInfoClasseDynamique)m_glsLstTypes.SelectedItems[0];
				return null;
			}
		}
		private CAuditVersionParametrageTypeEntite m_parametrageTypeEnEdition;
		private CAuditVersionParametrageTypeEntite ParametrageTypeSelectionne
		{
			get
			{
				if(TypeSelectionne != null)
					return m_parametrage.GetParametrage(TypeSelectionne.Classe.Name);
				return null;
			}
		}
		private void FillTypeSelec()
		{
			ValiderType();
			m_strNomTypeSelectionne = null;
			AffichageTypeSelectionne = (ParametrageTypeSelectionne != null);
			if (ParametrageTypeSelectionne == null)
			{
				m_TabControl.Enabled = false;
				m_parametrageTypeEnEdition = null;
				m_ctrlFormuleCle.Formule = null;
				m_ctrlFormuleCleParticuliere.Formule = null;
				m_ctrlFormuleDescription.Formule = null;
				m_panFiltre.Visible = false;
				m_lblEleSelec.Text = I.T("No selected type|30001");
				return;
			}

			m_TabControl.Enabled = true;
			m_parametrageTypeEnEdition = ParametrageTypeSelectionne;
			m_strNomTypeSelectionne = TypeSelectionne.Classe.Name;
			m_panFiltre.Visible = true;
			if(ParametrageTypeSelectionne.Filtre == null)
			{
				ParametrageTypeSelectionne.Filtre = new CFiltreDynamique();
				ParametrageTypeSelectionne.Filtre.TypeElements = TypeSelectionne.Classe;
			}
			m_panEditFiltre.InitSansVariables(ParametrageTypeSelectionne.Filtre);

			//Formules
			m_ctrlFormuleCle.Init(new CFournisseurPropDynStd(), ParametrageTypeSelectionne.TypeEntite);
			m_ctrlFormuleCle.Formule = ParametrageTypeSelectionne.FormuleCle;
			m_ctrlFormuleDescription.Init(new CFournisseurPropDynStd(), ParametrageTypeSelectionne.TypeEntite);
			m_ctrlFormuleDescription.Formule = ParametrageTypeSelectionne.FormuleDescription;

			AffichagePageClesParticuliereVisible = IsTypeElementATypeStructurant(TypeSelectionne.Classe);
			if (AffichagePageClesParticuliereVisible)
				InitCles();

			m_lblEleSelec.Text = I.T("Selected Type : @1|30000", TypeSelectionne.Nom);
		}

		private void CreateOrDeleteType(int nNumItem)
		{
			m_glsLstTypes.SelectItem(nNumItem);
			
			bool bChecked = m_glsLstTypes.IsChecked(nNumItem);
			CInfoClasseDynamique infCls = (CInfoClasseDynamique)m_glsLstTypes.ListeSource[nNumItem];

			//AJOUT
			if (bChecked)
				m_parametrage.TypesParametres.Add(new CAuditVersionParametrageTypeEntite(infCls.Classe));
			//SUPPRESSION
			else
				m_parametrage.TypesParametres.Remove(m_parametrage.GetParametrage(infCls.Classe.Name));

			FillTypeSelec();
		}


		private void m_glsLstTypes_CheckedChange(object sender, int nNumItem)
		{
			if (m_bInitialise && EnEdition)
				CreateOrDeleteType(nNumItem);
		}
		private void m_glsLstTypes_OnChangeSelection(object sender, EventArgs e)
		{
			if (m_bInitialise)
				FillTypeSelec();
		}

		private void ValiderType()
		{
			if (m_parametrageTypeEnEdition != null && EnEdition)
			{
				m_parametrageTypeEnEdition.FormuleDescription = m_ctrlFormuleDescription.Formule;
				m_parametrageTypeEnEdition.FormuleCle = m_ctrlFormuleCle.Formule;
				m_parametrageTypeEnEdition.Filtre = m_panEditFiltre.FiltreDynamique;
			}
		}

		#endregion

		#region CLE
		private void InitCles()
		{
			if (ParametrageTypeSelectionne != null)
			{
				List<CAuditVersionCleParticuliere> cles = ParametrageTypeSelectionne.ClesParticulieres;
				m_glsCles.ListeSource = cles;
				m_glsCles.Refresh();
				if (cles != null && m_cleEnEdition != null && cles.Contains(m_cleEnEdition))
				{
					m_glsCles.SelectItem(cles.IndexOf(m_cleEnEdition));
					FillCleSelec();
				}
			}
		}

		private CAuditVersionCleParticuliere m_cleEnEdition;
		private CAuditVersionCleParticuliere CleSelectionnee
		{
			get
			{
				if (m_bInitialise && m_glsCles.SelectedItems.Count == 1)
				{
					return (CAuditVersionCleParticuliere)m_glsCles.SelectedItems[0];
				}
				return null;
			}
		}

		private Type m_typeDuTypeStructurant;
		private Type TypeDuTypeStructurant
		{
			get
			{
				if(m_typeDuTypeStructurant == null)
					m_typeDuTypeStructurant = ParametrageTypeSelectionne.TypeEntite.GetProperty("ElementStructurant").PropertyType;
				return m_typeDuTypeStructurant;
			}
		}
		private string m_strChampIDDuTypeStructurant;
		private string ChampIDDuTypeStructurant
		{
			get
			{
				if(m_strChampIDDuTypeStructurant == null)
					m_strChampIDDuTypeStructurant = TypeAudit.ContexteDonnee.GetTableSafe(CContexteDonnee.GetNomTableForType(TypeDuTypeStructurant)).PrimaryKey[0].ColumnName;
				return m_strChampIDDuTypeStructurant;
			}
		}



		private void ValiderCle()
		{
			if (m_cleEnEdition != null && EnEdition)
			{
				m_cleEnEdition.Nom = m_txtNomCle.Text;
				m_cleEnEdition.FormuleCle = m_ctrlFormuleCleParticuliere.Formule;
			}
		}

		private void FillCleSelec()
		{
			ValiderCle();
			AffichageCleSelectionnee = CleSelectionnee != null;
			
			m_typeDuTypeStructurant = null;
			m_strChampIDDuTypeStructurant = null;

			if(CleSelectionnee == null)
				return;
			m_cleEnEdition = CleSelectionnee;
			InitSelectTypesStructurantsPossibles();
			InitLVCleTypesStructurantSelec();
			m_txtNomCle.Text = CleSelectionnee.Nom;

			m_ctrlFormuleCleParticuliere.Init(new CFournisseurPropDynStd(), ParametrageTypeSelectionne.TypeEntite);
			m_ctrlFormuleCleParticuliere.Formule = CleSelectionnee.FormuleCle;
		}

		private void m_lnkSupprimerCle_LinkClicked(object sender, EventArgs e)
		{
			if (ParametrageTypeSelectionne != null && CleSelectionnee != null)
			{
				ParametrageTypeSelectionne.ClesParticulieres.Remove(CleSelectionnee);
				m_glsCles.Refresh();
				AffichageCleSelectionnee = false;
			}
		}
		private void m_lnkAjouterCle_LinkClicked(object sender, EventArgs e)
		{
			if (ParametrageTypeSelectionne != null)
			{
				ParametrageTypeSelectionne.ClesParticulieres.Add(new CAuditVersionCleParticuliere());
				m_glsCles.Refresh();
				m_glsCles.SelectItem(ParametrageTypeSelectionne.ClesParticulieres.Count - 1);
				FillCleSelec();
			}
		}

		private void m_glsCles_OnChangeSelection(object sender, EventArgs e)
		{
			FillCleSelec();
		}
		#endregion

		#region CLE / TYPE

		private void InitSelectTypesStructurantsPossibles()
		{
			if (ParametrageTypeSelectionne == null)
				return;
			m_selectType.ElementSelectionne = null;
			m_lnkAjouterTypeCle.Visible = false;


			CFiltreData filtreFinal = null;

			string strIDs = ParametrageTypeSelectionne.GetChaineIdsFiltresPourFiltreSimple();
			if (strIDs != "")
			{
				CFiltreData filtreIDs = new CFiltreData(ChampIDDuTypeStructurant + " not in(" + strIDs + ")");
				filtreFinal = filtreIDs;
			}
				

			m_selectType.InitForSelectAvecFiltreDeBase(TypeDuTypeStructurant, "Libelle", filtreFinal, true);
			
		}
		private void InitLVCleTypesStructurantSelec()
		{
			m_lnkSupprimerTypeCle.Visible = false;
			m_lvTypeCle.Items.Clear();
			if (CleSelectionnee == null)
				return;

			string strIdsSelec = CleSelectionnee.ChaineIDsPourFiltreSimple;
			if (strIdsSelec != "")
			{
				CFiltreData filtre = new CFiltreData(ChampIDDuTypeStructurant + " in(" + strIdsSelec + ")");
				CListeObjetsDonnees typesSelec = new CListeObjetsDonnees(TypeAudit.ContexteDonnee, TypeDuTypeStructurant, filtre);
				m_lvTypeCle.Remplir(typesSelec);
			}
		}
		private void m_lnkAjouterTypeCle_LinkClicked(object sender, EventArgs e)
		{
			//Ajout
			if (m_selectType.ElementSelectionne == null)
				return;
			int nId = ((CObjetDonneeAIdNumerique)m_selectType.ElementSelectionne).Id;
			CleSelectionnee.IDsElementsDuType.Add(nId);

			FillCleSelec();
		}
		private void m_lnkSupprimerTypeCle_LinkClicked(object sender, EventArgs e)
		{
			if (CleSelectionnee == null || m_lvTypeCle.SelectedItems.Count != 1)
				return;

			int nId = ((CObjetDonneeAIdNumerique)m_lvTypeCle.SelectedItems[0].Tag).Id;
			m_lvTypeCle.Items.RemoveAt(m_lvTypeCle.SelectedItems[0].Index);
			CleSelectionnee.IDsElementsDuType.Remove(nId);
			FillCleSelec();
		}
		private void m_lvTypeCle_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
			{
				AffichageTypeStructurantSelectionne = m_lvTypeCle.SelectedItems.Count == 1;
			}
		}
		private void m_selectType_ElementSelectionneChanged(object sender, EventArgs e)
		{
			if (m_bInitialise)
				m_lnkAjouterTypeCle.Visible = m_selectType.ElementSelectionne != null;
		}

		#endregion
	}
}