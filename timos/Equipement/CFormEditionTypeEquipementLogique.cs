using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.CodeDom;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.multitiers.client;
using sc2i.process;
using sc2i.workflow;

using timos.acteurs;
using timos.securite;
using timos.data;

namespace timos
{

	[ObjectEditeur(typeof(CTypeEquipementLogique))]
	public class CFormEditionTypeEquipementLogique : CFormEditionStdTimos, 
		IFormNavigable
	{
		#region Designer generated code

        private sc2i.win32.common.ListViewAutoFilled m_listViewRoles;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn5;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private System.Windows.Forms.Timer m_timerMAJOnglets;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageInstallation;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn6;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private sc2i.win32.common.C2iPanelOmbre m_panTop;
		private sc2i.win32.common.C2iTextBox m_txtNom;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeRestrictionsSurChamp;
		private Label m_lblLabel;
		private CComboBoxArbreObjetDonneesHierarchique m_comboFamille;
		private LinkLabel m_lnkFamilles;
		private Crownwood.Magic.Controls.TabPage m_pageFiche;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private ListViewAutoFilledColumn listViewColumn2;
		private ListViewAutoFilled m_wndListeFournisseurs;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private ListViewAutoFilled m_wndListeTypesStocks;
		private ListViewAutoFilledColumn listViewAutoFilledColumn5;
		private Crownwood.Magic.Controls.TabPage m_pagePeutInclure;
		private Label label18;
		private C2iTextBoxSelectionne m_txtSelectTypeInclu;
		private CWndLinkStd m_lnkDeleteTypeInclu;
		private ListViewAutoFilled m_wndListeEquipementsInclus;
		private ListViewAutoFilledColumn listViewAutoFilledColumn6;
		private CWndLinkStd m_lnkAddTypeInclu;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireTypesInclus;
		private Crownwood.Magic.Controls.TabPage m_pageEOs;
		private CPanelAffectationEO m_panelEOS;
		private ListViewAutoFilled m_wndListeTypeDonnateurs;
		private ListViewAutoFilledColumn listViewAutoFilledColumn7;
		private CWndLinkStd m_lnkDeleteTypeIncluant;
		private ListViewAutoFilled m_wndListeEquipementsIncluants;
		private ListViewAutoFilledColumn listViewAutoFilledColumn8;
		private CWndLinkStd m_lnkAddTypeIncluant;
		private C2iTextBoxSelectionne m_txtSelectTypeIncluant;
		private Label label5;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireTypesIncluant;
        private ColumnHeader columnHeader1;
        private ListViewAutoFilled m_listeRelationsRemplacement;
		private ListViewAutoFilledColumn colRelRemplacement;
        private ListViewAutoFilled m_wndListeConstructeurs;
		private ListViewAutoFilledColumn listViewAutoFilledColumn10;
        private ListViewAutoFilled listViewAutoFilled1;
		private ListViewAutoFilledColumn listViewAutoFilledColumn9;
		private SplitContainer splitContainer2;
        private Label m_lblCodeInterne;
		private C2iTextBox c2iTextBox2;
		private ListViewAutoFilledColumn m_colTableCustom;
		private System.ComponentModel.IContainer components = null;

		
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
		//-------------------------------------------------------------------------
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_listViewRoles = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pagePeutInclure = new Crownwood.Magic.Controls.TabPage();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.label18 = new System.Windows.Forms.Label();
			this.m_lnkDeleteTypeInclu = new sc2i.win32.common.CWndLinkStd();
			this.m_txtSelectTypeInclu = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_lnkAddTypeInclu = new sc2i.win32.common.CWndLinkStd();
			this.m_wndListeEquipementsInclus = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeEquipementsIncluants = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_lnkDeleteTypeIncluant = new sc2i.win32.common.CWndLinkStd();
			this.label5 = new System.Windows.Forms.Label();
			this.m_txtSelectTypeIncluant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
			this.m_lnkAddTypeIncluant = new sc2i.win32.common.CWndLinkStd();
			this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
			this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
			this.m_pageEOs = new Crownwood.Magic.Controls.TabPage();
			this.m_panelEOS = new timos.CPanelAffectationEO();
			this.m_pageInstallation = new Crownwood.Magic.Controls.TabPage();
			this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
			this.m_colTableCustom = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeConstructeurs = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn10 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeFournisseurs = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeTypesStocks = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeTypeDonnateurs = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn7 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_listeRelationsRemplacement = new sc2i.win32.common.ListViewAutoFilled();
			this.colRelRemplacement = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_wndListeRestrictionsSurChamp = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
			this.m_comboFamille = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
			this.m_txtNom = new sc2i.win32.common.C2iTextBox();
			this.m_lblLabel = new System.Windows.Forms.Label();
			this.m_lnkFamilles = new System.Windows.Forms.LinkLabel();
			this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
			this.m_lblCodeInterne = new System.Windows.Forms.Label();
			this.listViewAutoFilled1 = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewAutoFilledColumn9 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_timerMAJOnglets = new System.Windows.Forms.Timer(this.components);
			this.listViewColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.m_gestionnaireTypesInclus = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
			this.m_gestionnaireTypesIncluant = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_panelCle.SuspendLayout();
			this.m_panelMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
			this.m_tabControl.SuspendLayout();
			this.m_pagePeutInclure.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.m_pageFiche.SuspendLayout();
			this.m_pageEOs.SuspendLayout();
			this.m_pageInstallation.SuspendLayout();
			this.m_panTop.SuspendLayout();
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
			// m_listViewRoles
			// 
			this.m_listViewRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewColumn5});
			this.m_listViewRoles.EnableCustomisation = true;
			this.m_listViewRoles.FullRowSelect = true;
			this.m_extLinkField.SetLinkField(this.m_listViewRoles, "");
			this.m_listViewRoles.Location = new System.Drawing.Point(8, 8);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRoles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_listViewRoles, "");
			this.m_listViewRoles.Name = "m_listViewRoles";
			this.m_listViewRoles.Size = new System.Drawing.Size(652, 304);
			this.m_extStyle.SetStyleBackColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_listViewRoles.TabIndex = 0;
			this.m_listViewRoles.UseCompatibleStateImageBehavior = false;
			this.m_listViewRoles.View = System.Windows.Forms.View.Details;
			// 
			// listViewColumn5
			// 
			this.listViewColumn5.Field = "Libelle";
			this.listViewColumn5.PrecisionWidth = 0;
			this.listViewColumn5.ProportionnalSize = false;
			this.listViewColumn5.Text  = "Label|50";
			this.listViewColumn5.Visible = true;
			this.listViewColumn5.Width = 450;
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
			this.m_tabControl.Location = new System.Drawing.Point(16, 119);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.PositionTop = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageFiche;
			this.m_tabControl.Size = new System.Drawing.Size(814, 423);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_tabControl.TabIndex = 1;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiche,
            this.m_pagePeutInclure,
            this.m_pageEOs,
            this.m_pageInstallation});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_pagePeutInclure
			// 
			this.m_pagePeutInclure.Controls.Add(this.splitContainer2);
			this.m_extLinkField.SetLinkField(this.m_pagePeutInclure, "");
			this.m_pagePeutInclure.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePeutInclure, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pagePeutInclure, "");
			this.m_pagePeutInclure.Name = "m_pagePeutInclure";
			this.m_pagePeutInclure.Selected = false;
			this.m_pagePeutInclure.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_pagePeutInclure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pagePeutInclure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pagePeutInclure.TabIndex = 13;
			this.m_pagePeutInclure.Title = "Can include|217";
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.splitContainer2, "");
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.splitContainer2, "");
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label18);
			this.splitContainer2.Panel1.Controls.Add(this.m_lnkDeleteTypeInclu);
			this.splitContainer2.Panel1.Controls.Add(this.m_txtSelectTypeInclu);
			this.splitContainer2.Panel1.Controls.Add(this.m_lnkAddTypeInclu);
			this.splitContainer2.Panel1.Controls.Add(this.m_wndListeEquipementsInclus);
			this.m_extLinkField.SetLinkField(this.splitContainer2.Panel1, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel1, "");
			this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.m_wndListeEquipementsIncluants);
			this.splitContainer2.Panel2.Controls.Add(this.m_lnkDeleteTypeIncluant);
			this.splitContainer2.Panel2.Controls.Add(this.label5);
			this.splitContainer2.Panel2.Controls.Add(this.m_txtSelectTypeIncluant);
			this.splitContainer2.Panel2.Controls.Add(this.m_lnkAddTypeIncluant);
			this.m_extLinkField.SetLinkField(this.splitContainer2.Panel2, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel2, "");
			this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.splitContainer2.Size = new System.Drawing.Size(798, 382);
			this.splitContainer2.SplitterDistance = 393;
			this.m_extStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.splitContainer2.TabIndex = 19;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label18, "");
			this.label18.Location = new System.Drawing.Point(18, 10);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label18, "");
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(158, 13);
			this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label18.TabIndex = 0;
			this.label18.Text = "This equipment can include|20050";
			// 
			// m_lnkDeleteTypeInclu
			// 
			this.m_lnkDeleteTypeInclu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lnkDeleteTypeInclu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lnkDeleteTypeInclu.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeInclu, "");
			this.m_lnkDeleteTypeInclu.Location = new System.Drawing.Point(21, 319);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeInclu, "");
			this.m_lnkDeleteTypeInclu.Name = "m_lnkDeleteTypeInclu";
			this.m_lnkDeleteTypeInclu.Size = new System.Drawing.Size(104, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkDeleteTypeInclu.TabIndex = 13;
			this.m_lnkDeleteTypeInclu.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
			this.m_lnkDeleteTypeInclu.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeInclu_LinkClicked);
			// 
			// m_txtSelectTypeInclu
			// 
			this.m_txtSelectTypeInclu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtSelectTypeInclu.ElementSelectionne = null;
			this.m_txtSelectTypeInclu.FonctionTextNull = null;
			this.m_txtSelectTypeInclu.HasLink = true;
			this.m_extLinkField.SetLinkField(this.m_txtSelectTypeInclu, "");
			this.m_txtSelectTypeInclu.Location = new System.Drawing.Point(21, 26);
			this.m_txtSelectTypeInclu.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeInclu, "");
			this.m_txtSelectTypeInclu.Name = "m_txtSelectTypeInclu";
			this.m_txtSelectTypeInclu.SelectedObject = null;
			this.m_txtSelectTypeInclu.Size = new System.Drawing.Size(174, 21);
			this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtSelectTypeInclu.TabIndex = 8;
			this.m_txtSelectTypeInclu.TextNull = "";
			// 
			// m_lnkAddTypeInclu
			// 
			this.m_lnkAddTypeInclu.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lnkAddTypeInclu.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.m_extLinkField.SetLinkField(this.m_lnkAddTypeInclu, "");
			this.m_lnkAddTypeInclu.Location = new System.Drawing.Point(21, 51);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeInclu, "");
			this.m_lnkAddTypeInclu.Name = "m_lnkAddTypeInclu";
			this.m_lnkAddTypeInclu.Size = new System.Drawing.Size(104, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkAddTypeInclu.TabIndex = 12;
			this.m_lnkAddTypeInclu.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
			this.m_lnkAddTypeInclu.LinkClicked += new System.EventHandler(this.m_lnkAddTypeInclu_LinkClicked);
			// 
			// m_wndListeEquipementsInclus
			// 
			this.m_wndListeEquipementsInclus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndListeEquipementsInclus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn6});
			this.m_wndListeEquipementsInclus.EnableCustomisation = true;
			this.m_wndListeEquipementsInclus.FullRowSelect = true;
			this.m_wndListeEquipementsInclus.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeEquipementsInclus, "");
			this.m_wndListeEquipementsInclus.Location = new System.Drawing.Point(21, 71);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipementsInclus, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeEquipementsInclus, "");
			this.m_wndListeEquipementsInclus.MultiSelect = false;
			this.m_wndListeEquipementsInclus.Name = "m_wndListeEquipementsInclus";
			this.m_wndListeEquipementsInclus.Size = new System.Drawing.Size(274, 242);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeEquipementsInclus.TabIndex = 11;
			this.m_wndListeEquipementsInclus.UseCompatibleStateImageBehavior = false;
			this.m_wndListeEquipementsInclus.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn6
			// 
			this.listViewAutoFilledColumn6.Field = "TypeInclu.Libelle";
			this.listViewAutoFilledColumn6.PrecisionWidth = 0;
			this.listViewAutoFilledColumn6.ProportionnalSize = false;
			this.listViewAutoFilledColumn6.Text = "Label|50";
			this.listViewAutoFilledColumn6.Visible = true;
			this.listViewAutoFilledColumn6.Width = 200;
			// 
			// m_wndListeEquipementsIncluants
			// 
			this.m_wndListeEquipementsIncluants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndListeEquipementsIncluants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn8});
			this.m_wndListeEquipementsIncluants.EnableCustomisation = true;
			this.m_wndListeEquipementsIncluants.FullRowSelect = true;
			this.m_wndListeEquipementsIncluants.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeEquipementsIncluants, "");
			this.m_wndListeEquipementsIncluants.Location = new System.Drawing.Point(28, 71);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipementsIncluants, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeEquipementsIncluants, "");
			this.m_wndListeEquipementsIncluants.MultiSelect = false;
			this.m_wndListeEquipementsIncluants.Name = "m_wndListeEquipementsIncluants";
			this.m_wndListeEquipementsIncluants.Size = new System.Drawing.Size(286, 242);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipementsIncluants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipementsIncluants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeEquipementsIncluants.TabIndex = 16;
			this.m_wndListeEquipementsIncluants.UseCompatibleStateImageBehavior = false;
			this.m_wndListeEquipementsIncluants.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn8
			// 
			this.listViewAutoFilledColumn8.Field = "TypeIncluant.Libelle";
			this.listViewAutoFilledColumn8.PrecisionWidth = 0;
			this.listViewAutoFilledColumn8.ProportionnalSize = false;
			this.listViewAutoFilledColumn8.Text = "Label|50";
			this.listViewAutoFilledColumn8.Visible = true;
			this.listViewAutoFilledColumn8.Width = 200;
			// 
			// m_lnkDeleteTypeIncluant
			// 
			this.m_lnkDeleteTypeIncluant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_lnkDeleteTypeIncluant.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lnkDeleteTypeIncluant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
			this.m_lnkDeleteTypeIncluant.Location = new System.Drawing.Point(28, 319);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeIncluant, "");
			this.m_lnkDeleteTypeIncluant.Name = "m_lnkDeleteTypeIncluant";
			this.m_lnkDeleteTypeIncluant.Size = new System.Drawing.Size(104, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkDeleteTypeIncluant.TabIndex = 18;
			this.m_lnkDeleteTypeIncluant.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
			this.m_lnkDeleteTypeIncluant.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeIncluant_LinkClicked);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label5, "");
			this.label5.Location = new System.Drawing.Point(25, 10);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label5, "");
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(190, 13);
			this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label5.TabIndex = 14;
			this.label5.Text = "This equipment can be included in|20051";
			// 
			// m_txtSelectTypeIncluant
			// 
			this.m_txtSelectTypeIncluant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtSelectTypeIncluant.ElementSelectionne = null;
			this.m_txtSelectTypeIncluant.FonctionTextNull = null;
			this.m_txtSelectTypeIncluant.HasLink = true;
			this.m_extLinkField.SetLinkField(this.m_txtSelectTypeIncluant, "");
			this.m_txtSelectTypeIncluant.Location = new System.Drawing.Point(28, 26);
			this.m_txtSelectTypeIncluant.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeIncluant, "");
			this.m_txtSelectTypeIncluant.Name = "m_txtSelectTypeIncluant";
			this.m_txtSelectTypeIncluant.SelectedObject = null;
			this.m_txtSelectTypeIncluant.Size = new System.Drawing.Size(201, 21);
			this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtSelectTypeIncluant.TabIndex = 15;
			this.m_txtSelectTypeIncluant.TextNull = "";
			// 
			// m_lnkAddTypeIncluant
			// 
			this.m_lnkAddTypeIncluant.Cursor = System.Windows.Forms.Cursors.Hand;
			this.m_lnkAddTypeIncluant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.m_extLinkField.SetLinkField(this.m_lnkAddTypeIncluant, "");
			this.m_lnkAddTypeIncluant.Location = new System.Drawing.Point(28, 51);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeIncluant, "");
			this.m_lnkAddTypeIncluant.Name = "m_lnkAddTypeIncluant";
			this.m_lnkAddTypeIncluant.Size = new System.Drawing.Size(104, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkAddTypeIncluant.TabIndex = 17;
			this.m_lnkAddTypeIncluant.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
			this.m_lnkAddTypeIncluant.LinkClicked += new System.EventHandler(this.m_lnkAddTypeIncluant_LinkClicked);
			// 
			// m_pageFiche
			// 
			this.m_pageFiche.Controls.Add(this.m_panelChamps);
			this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
			this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageFiche, "");
			this.m_pageFiche.Name = "m_pageFiche";
			this.m_pageFiche.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageFiche.TabIndex = 10;
			this.m_pageFiche.Title = "Form|60";
			// 
			// m_panelChamps
			// 
			this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelChamps.BoldSelectedPage = true;
			this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panelChamps.ElementEdite = null;
			this.m_panelChamps.IDEPixelArea = false;
			this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
			this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
			this.m_panelChamps.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
			this.m_panelChamps.Name = "m_panelChamps";
			this.m_panelChamps.Ombre = false;
			this.m_panelChamps.PositionTop = true;
			this.m_panelChamps.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelChamps.TabIndex = 6;
			// 
			// m_pageEOs
			// 
			this.m_pageEOs.Controls.Add(this.m_panelEOS);
			this.m_extLinkField.SetLinkField(this.m_pageEOs, "");
			this.m_pageEOs.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOs, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageEOs, "CEO");
			this.m_pageEOs.Name = "m_pageEOs";
			this.m_pageEOs.Selected = false;
			this.m_pageEOs.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageEOs.TabIndex = 14;
			this.m_pageEOs.Title = "Organisational entities|53";
			// 
			// m_panelEOS
			// 
			this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
			this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
			this.m_panelEOS.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
			this.m_panelEOS.Name = "m_panelEOS";
			this.m_panelEOS.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelEOS.TabIndex = 0;
			// 
			// m_pageInstallation
			// 
			this.m_pageInstallation.Controls.Add(this.m_panelDefinisseurChamps);
			this.m_extLinkField.SetLinkField(this.m_pageInstallation, "");
			this.m_pageInstallation.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInstallation, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageInstallation, "");
			this.m_pageInstallation.Name = "m_pageInstallation";
			this.m_pageInstallation.Selected = false;
			this.m_pageInstallation.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_pageInstallation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageInstallation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageInstallation.TabIndex = 2;
			this.m_pageInstallation.Title = "Custom Forms|99";
			// 
			// m_panelDefinisseurChamps
			// 
			this.m_panelDefinisseurChamps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
			this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(0, 0);
			this.m_panelDefinisseurChamps.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChamps, "");
			this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
			this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(798, 382);
			this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelDefinisseurChamps.TabIndex = 0;
			// 
			// m_colTableCustom
			// 
			this.m_colTableCustom.Field = "Libelle";
			this.m_colTableCustom.PrecisionWidth = 4674;
			this.m_colTableCustom.ProportionnalSize = true;
			this.m_colTableCustom.Text = "Label|50";
			this.m_colTableCustom.Visible = true;
			this.m_colTableCustom.Width = 4674;
			// 
			// m_wndListeConstructeurs
			// 
			this.m_wndListeConstructeurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndListeConstructeurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn10});
			this.m_wndListeConstructeurs.EnableCustomisation = true;
			this.m_wndListeConstructeurs.FullRowSelect = true;
			this.m_wndListeConstructeurs.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeConstructeurs, "");
			this.m_wndListeConstructeurs.Location = new System.Drawing.Point(10, 49);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeConstructeurs, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeConstructeurs, "");
			this.m_wndListeConstructeurs.MultiSelect = false;
			this.m_wndListeConstructeurs.Name = "m_wndListeConstructeurs";
			this.m_wndListeConstructeurs.Size = new System.Drawing.Size(362, 287);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeConstructeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeConstructeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeConstructeurs.TabIndex = 7;
			this.m_wndListeConstructeurs.UseCompatibleStateImageBehavior = false;
			this.m_wndListeConstructeurs.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn10
			// 
			this.listViewAutoFilledColumn10.Field = "Constructeur.Acteur.Libelle";
			this.listViewAutoFilledColumn10.PrecisionWidth = 0;
			this.listViewAutoFilledColumn10.ProportionnalSize = false;
			this.listViewAutoFilledColumn10.Text = "Label|50";
			this.listViewAutoFilledColumn10.Visible = true;
			this.listViewAutoFilledColumn10.Width = 200;
			// 
			// m_wndListeFournisseurs
			// 
			this.m_wndListeFournisseurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.m_wndListeFournisseurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn4});
			this.m_wndListeFournisseurs.EnableCustomisation = true;
			this.m_wndListeFournisseurs.FullRowSelect = true;
			this.m_wndListeFournisseurs.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeFournisseurs, "");
			this.m_wndListeFournisseurs.Location = new System.Drawing.Point(11, 57);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFournisseurs, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeFournisseurs, "");
			this.m_wndListeFournisseurs.MultiSelect = false;
			this.m_wndListeFournisseurs.Name = "m_wndListeFournisseurs";
			this.m_wndListeFournisseurs.Size = new System.Drawing.Size(325, 281);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeFournisseurs.TabIndex = 2;
			this.m_wndListeFournisseurs.UseCompatibleStateImageBehavior = false;
			this.m_wndListeFournisseurs.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn4
			// 
			this.listViewAutoFilledColumn4.Field = "Fournisseur.Acteur.Libelle";
			this.listViewAutoFilledColumn4.PrecisionWidth = 0;
			this.listViewAutoFilledColumn4.ProportionnalSize = false;
			this.listViewAutoFilledColumn4.Text = "Label|50";
			this.listViewAutoFilledColumn4.Visible = true;
			this.listViewAutoFilledColumn4.Width = 200;
			// 
			// m_wndListeTypesStocks
			// 
			this.m_wndListeTypesStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndListeTypesStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5});
			this.m_wndListeTypesStocks.EnableCustomisation = true;
			this.m_wndListeTypesStocks.FullRowSelect = true;
			this.m_wndListeTypesStocks.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeTypesStocks, "");
			this.m_wndListeTypesStocks.Location = new System.Drawing.Point(184, 58);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypesStocks, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeTypesStocks, "");
			this.m_wndListeTypesStocks.MultiSelect = false;
			this.m_wndListeTypesStocks.Name = "m_wndListeTypesStocks";
			this.m_wndListeTypesStocks.Size = new System.Drawing.Size(411, 276);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeTypesStocks.TabIndex = 7;
			this.m_wndListeTypesStocks.UseCompatibleStateImageBehavior = false;
			this.m_wndListeTypesStocks.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn5
			// 
			this.listViewAutoFilledColumn5.Field = "TypeStock.Libelle";
			this.listViewAutoFilledColumn5.PrecisionWidth = 0;
			this.listViewAutoFilledColumn5.ProportionnalSize = false;
			this.listViewAutoFilledColumn5.Text = "Label|50";
			this.listViewAutoFilledColumn5.Visible = true;
			this.listViewAutoFilledColumn5.Width = 200;
			// 
			// m_wndListeTypeDonnateurs
			// 
			this.m_wndListeTypeDonnateurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.m_wndListeTypeDonnateurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn7});
			this.m_wndListeTypeDonnateurs.EnableCustomisation = true;
			this.m_wndListeTypeDonnateurs.FullRowSelect = true;
			this.m_wndListeTypeDonnateurs.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_wndListeTypeDonnateurs, "");
			this.m_wndListeTypeDonnateurs.Location = new System.Drawing.Point(11, 53);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypeDonnateurs, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_wndListeTypeDonnateurs, "");
			this.m_wndListeTypeDonnateurs.MultiSelect = false;
			this.m_wndListeTypeDonnateurs.Name = "m_wndListeTypeDonnateurs";
			this.m_wndListeTypeDonnateurs.Size = new System.Drawing.Size(490, 116);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeTypeDonnateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeTypeDonnateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeTypeDonnateurs.TabIndex = 14;
			this.m_wndListeTypeDonnateurs.UseCompatibleStateImageBehavior = false;
			this.m_wndListeTypeDonnateurs.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn7
			// 
			this.listViewAutoFilledColumn7.Field = "TypeParent.Libelle";
			this.listViewAutoFilledColumn7.PrecisionWidth = 0;
			this.listViewAutoFilledColumn7.ProportionnalSize = false;
			this.listViewAutoFilledColumn7.Text = "Label|50";
			this.listViewAutoFilledColumn7.Visible = true;
			this.listViewAutoFilledColumn7.Width = 200;
			// 
			// m_listeRelationsRemplacement
			// 
			this.m_listeRelationsRemplacement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.m_listeRelationsRemplacement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRelRemplacement});
			this.m_listeRelationsRemplacement.EnableCustomisation = true;
			this.m_listeRelationsRemplacement.FullRowSelect = true;
			this.m_listeRelationsRemplacement.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.m_listeRelationsRemplacement, "");
			this.m_listeRelationsRemplacement.Location = new System.Drawing.Point(10, 90);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeRelationsRemplacement, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_listeRelationsRemplacement, "");
			this.m_listeRelationsRemplacement.MultiSelect = false;
			this.m_listeRelationsRemplacement.Name = "m_listeRelationsRemplacement";
			this.m_listeRelationsRemplacement.Size = new System.Drawing.Size(398, 251);
			this.m_extStyle.SetStyleBackColor(this.m_listeRelationsRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_listeRelationsRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_listeRelationsRemplacement.TabIndex = 4;
			this.m_listeRelationsRemplacement.UseCompatibleStateImageBehavior = false;
			this.m_listeRelationsRemplacement.View = System.Windows.Forms.View.Details;
			// 
			// colRelRemplacement
			// 
			this.colRelRemplacement.Field = "Libelle";
			this.colRelRemplacement.PrecisionWidth = 0;
			this.colRelRemplacement.ProportionnalSize = false;
			this.colRelRemplacement.Text = "Label|50";
			this.colRelRemplacement.Visible = true;
			this.colRelRemplacement.Width = 308;
			// 
			// m_wndListeRestrictionsSurChamp
			// 
			this.m_wndListeRestrictionsSurChamp.CheckBoxes = true;
			this.m_wndListeRestrictionsSurChamp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3});
			this.m_wndListeRestrictionsSurChamp.EnableCustomisation = true;
			this.m_wndListeRestrictionsSurChamp.FullRowSelect = true;
			this.m_wndListeRestrictionsSurChamp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_extLinkField.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
			this.m_wndListeRestrictionsSurChamp.Location = new System.Drawing.Point(8, 24);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_wndListeRestrictionsSurChamp, "");
			this.m_wndListeRestrictionsSurChamp.MultiSelect = false;
			this.m_wndListeRestrictionsSurChamp.Name = "m_wndListeRestrictionsSurChamp";
			this.m_wndListeRestrictionsSurChamp.Size = new System.Drawing.Size(216, 232);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndListeRestrictionsSurChamp.TabIndex = 3;
			this.m_wndListeRestrictionsSurChamp.UseCompatibleStateImageBehavior = false;
			this.m_wndListeRestrictionsSurChamp.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn3
			// 
			this.listViewAutoFilledColumn3.Field = "Libelle";
			this.listViewAutoFilledColumn3.PrecisionWidth = 0;
			this.listViewAutoFilledColumn3.ProportionnalSize = false;
			this.listViewAutoFilledColumn3.Text  = "Label|50";
			this.listViewAutoFilledColumn3.Visible = true;
			this.listViewAutoFilledColumn3.Width = 200;
			// 
			// m_panTop
			// 
			this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panTop.Controls.Add(this.m_comboFamille);
			this.m_panTop.Controls.Add(this.m_txtNom);
			this.m_panTop.Controls.Add(this.m_lblLabel);
			this.m_panTop.Controls.Add(this.m_lnkFamilles);
			this.m_panTop.Controls.Add(this.c2iTextBox2);
			this.m_panTop.Controls.Add(this.m_lblCodeInterne);
			this.m_panTop.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panTop, "");
			this.m_panTop.Location = new System.Drawing.Point(16, 32);
			this.m_panTop.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_panTop, "");
			this.m_panTop.Name = "m_panTop";
			this.m_panTop.Size = new System.Drawing.Size(814, 88);
			this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panTop.TabIndex = 0;
			// 
			// m_comboFamille
			// 
			this.m_comboFamille.BackColor = System.Drawing.Color.White;
			this.m_comboFamille.ElementSelectionne = null;
			this.m_extLinkField.SetLinkField(this.m_comboFamille, "");
			this.m_comboFamille.Location = new System.Drawing.Point(80, 38);
			this.m_comboFamille.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboFamille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_comboFamille, "");
			this.m_comboFamille.Name = "m_comboFamille";
			this.m_comboFamille.NullAutorise = false;
			this.m_comboFamille.Size = new System.Drawing.Size(328, 21);
			this.m_extStyle.SetStyleBackColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_comboFamille.TabIndex = 3;
			this.m_comboFamille.TextNull = I.T("[None]|30290");
			this.m_comboFamille.ElementSelectionneChanged += new System.EventHandler(this.m_comboFamille_ElementSelectionneChanged);
			// 
			// m_txtNom
			// 
			this.m_extLinkField.SetLinkField(this.m_txtNom, "Libelle");
			this.m_txtNom.Location = new System.Drawing.Point(80, 12);
			this.m_txtNom.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_txtNom, "");
			this.m_txtNom.Name = "m_txtNom";
			this.m_txtNom.Size = new System.Drawing.Size(328, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtNom.TabIndex = 0;
			this.m_txtNom.Text = "[Label]|30324";
			// 
			// m_lblLabel
			// 
			this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
			this.m_lblLabel.Location = new System.Drawing.Point(7, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
			this.m_lblLabel.Name = "m_lblLabel";
			this.m_lblLabel.Size = new System.Drawing.Size(67, 12);
			this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblLabel.TabIndex = 4009;
			this.m_lblLabel.Text = "Label|50";
			// 
			// m_lnkFamilles
			// 
			this.m_lnkFamilles.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_lnkFamilles, "");
			this.m_lnkFamilles.Location = new System.Drawing.Point(7, 42);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFamilles, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_lnkFamilles, "");
			this.m_lnkFamilles.Name = "m_lnkFamilles";
			this.m_lnkFamilles.Size = new System.Drawing.Size(67, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_lnkFamilles.TabIndex = 4012;
			this.m_lnkFamilles.TabStop = true;
			this.m_lnkFamilles.Text = "Family|197";
			this.m_lnkFamilles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamilles_LinkClicked);
			// 
			// c2iTextBox2
			// 
			this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Code");
			this.c2iTextBox2.Location = new System.Drawing.Point(525, 12);
			this.c2iTextBox2.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
			this.c2iTextBox2.Name = "c2iTextBox2";
			this.c2iTextBox2.Size = new System.Drawing.Size(257, 20);
			this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.c2iTextBox2.TabIndex = 1;
			this.c2iTextBox2.Text = "[Code]";
			// 
			// m_lblCodeInterne
			// 
			this.m_extLinkField.SetLinkField(this.m_lblCodeInterne, "");
			this.m_lblCodeInterne.Location = new System.Drawing.Point(430, 15);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCodeInterne, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_lblCodeInterne, "");
			this.m_lblCodeInterne.Name = "m_lblCodeInterne";
			this.m_lblCodeInterne.Size = new System.Drawing.Size(89, 13);
			this.m_extStyle.SetStyleBackColor(this.m_lblCodeInterne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lblCodeInterne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblCodeInterne.TabIndex = 7;
			this.m_lblCodeInterne.Text = "Internal code|221";
			// 
			// listViewAutoFilled1
			// 
			this.listViewAutoFilled1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.listViewAutoFilled1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn9});
			this.listViewAutoFilled1.EnableCustomisation = true;
			this.listViewAutoFilled1.FullRowSelect = true;
			this.listViewAutoFilled1.HideSelection = false;
			this.m_extLinkField.SetLinkField(this.listViewAutoFilled1, "");
			this.listViewAutoFilled1.Location = new System.Drawing.Point(11, 51);
			this.m_gestionnaireModeEdition.SetModeEdition(this.listViewAutoFilled1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.listViewAutoFilled1, "");
			this.listViewAutoFilled1.MultiSelect = false;
			this.listViewAutoFilled1.Name = "listViewAutoFilled1";
			this.listViewAutoFilled1.Size = new System.Drawing.Size(297, 406);
			this.m_extStyle.SetStyleBackColor(this.listViewAutoFilled1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.listViewAutoFilled1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.listViewAutoFilled1.TabIndex = 2;
			this.listViewAutoFilled1.UseCompatibleStateImageBehavior = false;
			this.listViewAutoFilled1.View = System.Windows.Forms.View.Details;
			// 
			// listViewAutoFilledColumn9
			// 
			this.listViewAutoFilledColumn9.Field = "Fournisseur.Acteur.Libelle";
			this.listViewAutoFilledColumn9.PrecisionWidth = 0;
			this.listViewAutoFilledColumn9.ProportionnalSize = false;
			this.listViewAutoFilledColumn9.Text = "Label|50";
			this.listViewAutoFilledColumn9.Visible = true;
			this.listViewAutoFilledColumn9.Width = 200;
			// 
			// m_timerMAJOnglets
			// 
			this.m_timerMAJOnglets.Interval = 300;
			// 
			// listViewColumn2
			// 
			this.listViewColumn2.Field = "GroupeContenu.Libelle";
			this.listViewColumn2.PrecisionWidth = 0;
			this.listViewColumn2.ProportionnalSize = false;
            this.listViewColumn2.Text = "Label|50";
			this.listViewColumn2.Visible = true;
			this.listViewColumn2.Width = 193;
			// 
			// listViewColumn6
			// 
			this.listViewColumn6.Field = "Nom";
			this.listViewColumn6.PrecisionWidth = 0;
			this.listViewColumn6.ProportionnalSize = false;
			this.listViewColumn6.Text = "Name|164";
			this.listViewColumn6.Visible = true;
			this.listViewColumn6.Width = 156;
			// 
			// listViewAutoFilledColumn1
			// 
			this.listViewAutoFilledColumn1.Field = "Libelle";
			this.listViewAutoFilledColumn1.PrecisionWidth = 0;
			this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
			this.listViewAutoFilledColumn1.Visible = true;
			this.listViewAutoFilledColumn1.Width = 175;
			// 
			// listViewAutoFilledColumn2
			// 
			this.listViewAutoFilledColumn2.Field = "Libelle";
			this.listViewAutoFilledColumn2.PrecisionWidth = 0;
			this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
			this.listViewAutoFilledColumn2.Visible = true;
			this.listViewAutoFilledColumn2.Width = 312;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(20, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label1, "");
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 16);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4004;
			this.label1.Text = "Name|164";
			// 
			// m_gestionnaireTypesInclus
			// 
			this.m_gestionnaireTypesInclus.ListeAssociee = this.m_wndListeEquipementsInclus;
			this.m_gestionnaireTypesInclus.ObjetEdite = null;
			this.m_gestionnaireTypesInclus.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTypesInclus_InitChamp);
			this.m_gestionnaireTypesInclus.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTypesInclus_MAJ_Champs);
			// 
			// m_gestionnaireTypesIncluant
			// 
			this.m_gestionnaireTypesIncluant.ListeAssociee = this.m_wndListeEquipementsIncluants;
			this.m_gestionnaireTypesIncluant.ObjetEdite = null;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Label|50";
			// 
			// CFormEditionTypeEquipementLogique
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 540);
			this.Controls.Add(this.m_panTop);
			this.Controls.Add(this.m_tabControl);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this, "");
			this.Name = "CFormEditionTypeEquipementLogique";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.TabControl = this.m_tabControl;
			this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEquipementLogique_OnInitPage);
			this.Load += new System.EventHandler(this.CFormEditionTypeEquipementLogique_Load);
			this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEquipementLogique_OnMajChampsPage);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormEditionTypeEquipementLogique_Closing);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.Controls.SetChildIndex(this.m_panTop, 0);
			this.m_panelCle.ResumeLayout(false);
			this.m_panelCle.PerformLayout();
			this.m_panelMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pagePeutInclure.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			this.splitContainer2.ResumeLayout(false);
			this.m_pageFiche.ResumeLayout(false);
			this.m_pageEOs.ResumeLayout(false);
			this.m_pageInstallation.ResumeLayout(false);
			this.m_panTop.ResumeLayout(false);
			this.m_panTop.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipementLogique()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipementLogique(CTypeEquipementLogique typeEquipementLogique)
			: base(typeEquipementLogique)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipementLogique(CTypeEquipementLogique typeEqptLogique, CListeObjetsDonnees liste)
			: base(typeEqptLogique, liste)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------

		private CTypeEquipementLogique TypeEquipementLogique
		{
			get
			{
				return (CTypeEquipementLogique)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionTypeEquipementLogique_Load(object sender, System.EventArgs e)
		{
            m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);    
		}
		//-------------------------------------------------------------------------
		private void CFormEditionTypeEquipementLogique_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		
		
		//-------------------------------------------------------------------------
		protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
			AffecterTitre(I.T("Logical equipment type @1|20052",TypeEquipementLogique.Libelle));

			InitComboFamille();
			m_comboFamille.ElementSelectionne = TypeEquipementLogique.Famille;

            ManageOnglets();

			// Par défaut le panel Remplacment n'est pas affiché

			return result;
		}

        //-------------------------------------------------------------------------
        private void ManageOnglets()
        {

            if (TypeEquipementLogique.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Remove(m_pageFiche);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Insert(0, m_pageFiche);
            }

        }


        //-------------------------------------------------------------------------
        private void InitPanelChampsCustom()
        {
            m_panelDefinisseurChamps.InitPanel(
                TypeEquipementLogique,
                typeof(CFormListeChampsCustom),
                typeof(CFormListeFormulaires));

        }
		

		//-------------------------------------------------------------------------
		private void InitComboFamille()
		{
			CFamilleEquipementLogique lastFamille = (CFamilleEquipementLogique)m_comboFamille.ElementSelectionne; ;
			m_comboFamille.Init(
				typeof(CFamilleEquipementLogique),
				"FamillesFilles",
				CFamilleEquipementLogique.c_champIdParent,
				"Libelle",
				typeof(CFormEditionFamilleEquipementLogique),
				null,
				null);
			m_comboFamille.ElementSelectionne = lastFamille;			
		}
				
		

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
		

			return result;
		}
		
		//-------------------------------------------------------------------------
		private void m_lnkFamilles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormNavigateurPopup.Show(new CFormListeFamillesEquipement());
			InitComboFamille();
		}


		//-------------------------------------------------------------------------
		private void m_comboFamille_ElementSelectionneChanged(object sender, EventArgs e)
		{
			TypeEquipementLogique.Famille = (CFamilleEquipementLogique)m_comboFamille.ElementSelectionne;
            ManageOnglets();
		}


		

		
		#region Types incluables

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesInclus_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesInclus_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_lnkAddTypeInclu_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeInclu.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the logical equipment type to add|20053"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeEquipementLogique tpEquipement = (CTypeEquipementLogique)m_txtSelectTypeInclu.ElementSelectionne;
			CListeObjetsDonnees listeExistants = TypeEquipementLogique.RelationsTypesInclus;
			listeExistants.Filtre = new CFiltreData(CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeInclu + "=@1",
				tpEquipement.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this logical equipment type|20054"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectTypeInclu.ElementSelectionne = null;
			
			CRelationTypeEquipementLogique_TypesIncluables rel = new CRelationTypeEquipementLogique_TypesIncluables(TypeEquipementLogique.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeInclu = tpEquipement;
			rel.TypeIncluant = TypeEquipementLogique;

			ListViewItem item = new ListViewItem();
			m_wndListeEquipementsInclus.Items.Add(item);
			m_wndListeEquipementsInclus.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeEquipementsInclus.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeInclu();
		}

		//-------------------------------------------------------------------------
		private void m_lnkDeleteTypeInclu_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeEquipementsInclus.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipementLogique_TypesIncluables rel = (CRelationTypeEquipementLogique_TypesIncluables)m_wndListeEquipementsInclus.SelectedItems[0].Tag;

			m_gestionnaireTypesInclus.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeEquipementsInclus.SelectedItems.Count == 1)
			{
				if (m_wndListeEquipementsInclus.SelectedItems[0] != null)
					m_wndListeEquipementsInclus.SelectedItems[0].Remove();
			}
			InitSelectTypeInclu();
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeInclu()
		{
			CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeEquipementLogique));

			string strIds = "";
			foreach (CRelationTypeEquipementLogique_TypesIncluables rel in TypeEquipementLogique.RelationsTypesInclus)
			{
				if (rel.TypeInclu != null)
					strIds += rel.TypeInclu.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = CFiltreData.GetAndFiltre(
					filtre, new CFiltreData(CTypeEquipementLogique.c_champId + " not in (" + strIds + ")"));
			}
			m_txtSelectTypeInclu.Init(
				typeof(CFormListeTypesEquipementsLogiques),
				"Libelle",
				filtre,
				true);
		}

		#endregion

		

		#region Types incluants

		///////////////////////////////////////////////////////
		///TYPES INCLUANTS
		//////////////////////////////////////////////////////
		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesIncluAnt_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesIncluant_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_lnkAddTypeIncluant_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeIncluant.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the logical equipment type to add|20053"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeEquipementLogique typeEquipementLogique = (CTypeEquipementLogique)m_txtSelectTypeIncluant.ElementSelectionne;
			CListeObjetsDonnees listeExistants = TypeEquipementLogique.RelationsTypesIncluant;
			listeExistants.Filtre = new CFiltreData(CRelationTypeEquipementLogique_TypesIncluables.c_champIdTypeIncluant + "=@1",
				typeEquipementLogique.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this logical equipment type|20054"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectTypeIncluant.ElementSelectionne = null;

			CRelationTypeEquipementLogique_TypesIncluables rel = new CRelationTypeEquipementLogique_TypesIncluables(TypeEquipementLogique.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeIncluant = typeEquipementLogique;
			rel.TypeInclu = TypeEquipementLogique;

			ListViewItem item = new ListViewItem();
			m_wndListeEquipementsIncluants.Items.Add(item);
			m_wndListeEquipementsIncluants.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeEquipementsIncluants.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeIncluant();
		}

		//-------------------------------------------------------------------------
		private void m_lnkDeleteTypeIncluant_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeEquipementsIncluants.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipementLogique_TypesIncluables rel = (CRelationTypeEquipementLogique_TypesIncluables)m_wndListeEquipementsIncluants.SelectedItems[0].Tag;

			m_gestionnaireTypesIncluant.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeEquipementsIncluants.SelectedItems.Count == 1)
			{
				if (m_wndListeEquipementsIncluants.SelectedItems[0] != null)
					m_wndListeEquipementsIncluants.SelectedItems[0].Remove();
			}
			InitSelectTypeIncluant();
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeIncluant()
		{
			CFiltreData filtre = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeEquipementLogique));


			string strIds = "";
			foreach (CRelationTypeEquipementLogique_TypesIncluables rel in TypeEquipementLogique.RelationsTypesIncluant)
			{
				if (rel.TypeIncluant != null)
					strIds += rel.TypeIncluant.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = CFiltreData.GetAndFiltre(
					filtre, new CFiltreData(CTypeEquipementLogique.c_champId + " not in (" + strIds + ")"));
			}
			m_txtSelectTypeIncluant.Init(
				typeof(CFormListeTypesEquipementsLogiques),
				"Libelle",
				filtre,
				true);
		}

		#endregion

     


		private CResultAErreur CFormEditionTypeEquipementLogique_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageEOs)
				{
					m_panelEOS.Init(TypeEquipementLogique);

				}
				
				else if (page == m_pageFiche)
				{
					m_panelChamps.ElementEdite = TypeEquipementLogique;

				}
				else if (page == m_pageInstallation)
				{
					InitPanelChampsCustom();
				}
				else if (page == m_pagePeutInclure)
				{
					m_gestionnaireTypesInclus.ObjetEdite = TypeEquipementLogique.RelationsTypesInclus;
					m_gestionnaireTypesIncluant.ObjetEdite = TypeEquipementLogique.RelationsTypesIncluant;

					InitSelectTypeInclu();
					InitSelectTypeIncluant();
				}

			}
			return result;
		}

		private CResultAErreur CFormEditionTypeEquipementLogique_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageEOs)
			{
				result = m_panelEOS.MajChamps();
			}else if (page == m_pageFiche)
			{
				result = m_panelChamps.MAJ_Champs();
			}
			else if (page == m_pageInstallation)
			{
				result = m_panelDefinisseurChamps.MAJ_Champs();
			}
			else if (page == m_pagePeutInclure)
			{
			}
			return result;
		}
	}
}

