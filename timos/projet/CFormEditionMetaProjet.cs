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
using sc2i.formulaire;
using timos.data.projet;
using timos.data.projet.gantt;
using System.Text;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CMetaProjet))]
	public class CFormEditionMetaProjet : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code


        private CFiltreDynamique m_filtreDynamique = null;
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
        private C2iTextBox m_txtDescrip;
		private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private Label m_lblDescription;
		private CReducteurControle m_reducteurTop;
        private Crownwood.Magic.Controls.TabPage m_pageGantt;
        private timos.projet.gantt.CControlGanttProjet m_gantt;
        private Crownwood.Magic.Controls.TabPage m_pageFils;
        private timos.win32.composants.CDateTimePickerForContextMenu m_dtpDatesPrevisionnelles;
        private CComboBoxLinkListeObjetsDonnees m_selectTypeMetaProjet;
        private Panel m_panelMarge;
        private Crownwood.Magic.Controls.TabPage m_pageEOS;
        private CPanelAffectationEO m_panelEOS;
        private CPanelEditFiltreDynamique m_panelFiltre;
        private C2iTabControl m_tab;
        private C2iTabControl c2iTabControl1;
        private Splitter splitter1;
        private Panel m_panelListeElements;
        private Panel panel1;
        private ListViewAutoFilled m_wndListeProjets;
        private ListViewAutoFilledColumn listViewAutoFilledColumn3;
        private LinkLabel m_lnkRefreshListe;
        private LinkLabel m_lnkDelete;
        private CheckBox m_chkAsyncUpdate;
        private CheckBox checkBox1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionMetaProjet));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkAsyncUpdate = new System.Windows.Forms.CheckBox();
            this.m_selectTypeMetaProjet = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblProject = new System.Windows.Forms.Label();
            this.m_lblTypeTable = new System.Windows.Forms.Label();
            this.m_dtpDatesPrevisionnelles = new timos.win32.composants.CDateTimePickerForContextMenu();
            this.m_txtDescrip = new sc2i.win32.common.C2iTextBox();
            this.m_lblDescription = new System.Windows.Forms.Label();
            this.m_wndListeEquipements = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageGantt = new Crownwood.Magic.Controls.TabPage();
            this.m_gantt = new timos.projet.gantt.CControlGanttProjet();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_pageFils = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.m_tab = new sc2i.win32.common.C2iTabControl(this.components);
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelListeElements = new System.Windows.Forms.Panel();
            this.m_wndListeProjets = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkRefreshListe = new System.Windows.Forms.LinkLabel();
            this.m_lnkDelete = new System.Windows.Forms.LinkLabel();
            this.m_pageInfos = new Crownwood.Magic.Controls.TabPage();
            this.m_pageEOS = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_wndListeSite = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageGantt.SuspendLayout();
            this.m_pageFils.SuspendLayout();
            this.m_panelFiltre.SuspendLayout();
            this.m_panelListeElements.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_pageInfos.SuspendLayout();
            this.m_pageEOS.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(626, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(518, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(801, 28);
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
            this.m_txtLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(148, 5);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(322, 20);
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
            this.m_panTop.Controls.Add(this.checkBox1);
            this.m_panTop.Controls.Add(this.m_chkAsyncUpdate);
            this.m_panTop.Controls.Add(this.m_selectTypeMetaProjet);
            this.m_panTop.Controls.Add(this.m_lblProject);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_lblTypeTable);
            this.m_panTop.Controls.Add(this.m_dtpDatesPrevisionnelles);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(12, 43);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(789, 87);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_chkAsyncUpdate
            // 
            this.m_chkAsyncUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkAsyncUpdate.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAsyncUpdate, "ModeUpdateAsynchrone");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAsyncUpdate, true);
            this.m_chkAsyncUpdate.Location = new System.Drawing.Point(630, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAsyncUpdate, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAsyncUpdate, "");
            this.m_chkAsyncUpdate.Name = "m_chkAsyncUpdate";
            this.m_chkAsyncUpdate.Size = new System.Drawing.Size(126, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAsyncUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAsyncUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAsyncUpdate.TabIndex = 4025;
            this.m_chkAsyncUpdate.Text = "Async. update|20799";
            this.m_chkAsyncUpdate.UseVisualStyleBackColor = true;
            // 
            // m_selectTypeMetaProjet
            // 
            this.m_selectTypeMetaProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectTypeMetaProjet.ComportementLinkStd = true;
            this.m_selectTypeMetaProjet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_selectTypeMetaProjet.ElementSelectionne = null;
            this.m_selectTypeMetaProjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_selectTypeMetaProjet.FormattingEnabled = true;
            this.m_selectTypeMetaProjet.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeMetaProjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeMetaProjet, false);
            this.m_selectTypeMetaProjet.LinkProperty = "";
            this.m_selectTypeMetaProjet.ListDonnees = null;
            this.m_selectTypeMetaProjet.Location = new System.Drawing.Point(148, 27);
            this.m_selectTypeMetaProjet.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeMetaProjet, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeMetaProjet, "");
            this.m_selectTypeMetaProjet.Name = "m_selectTypeMetaProjet";
            this.m_selectTypeMetaProjet.NullAutorise = false;
            this.m_selectTypeMetaProjet.ProprieteAffichee = null;
            this.m_selectTypeMetaProjet.ProprieteParentListeObjets = null;
            this.m_selectTypeMetaProjet.SelectionneurParent = null;
            this.m_selectTypeMetaProjet.Size = new System.Drawing.Size(322, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeMetaProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeMetaProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeMetaProjet.TabIndex = 4019;
            this.m_selectTypeMetaProjet.TextNull = "(empty)";
            this.m_selectTypeMetaProjet.Tri = true;
            this.m_selectTypeMetaProjet.TypeFormEdition = null;
            this.m_selectTypeMetaProjet.SelectionChangeCommitted += new System.EventHandler(this.m_selectTypeMetaProjet_SelectionChangeCommitted);
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
            this.m_lblProject.Size = new System.Drawing.Size(136, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProject, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProject.TabIndex = 4005;
            this.m_lblProject.Text = "Label |50";
            // 
            // m_lblTypeTable
            // 
            this.m_extLinkField.SetLinkField(this.m_lblTypeTable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTypeTable, false);
            this.m_lblTypeTable.Location = new System.Drawing.Point(6, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeTable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeTable, "");
            this.m_lblTypeTable.Name = "m_lblTypeTable";
            this.m_lblTypeTable.Size = new System.Drawing.Size(136, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeTable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeTable.TabIndex = 4016;
            this.m_lblTypeTable.Text = "Meta-Project Type|20531";
            // 
            // m_dtpDatesPrevisionnelles
            // 
            this.m_dtpDatesPrevisionnelles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpDatesPrevisionnelles.BoutonValiderVisible = false;
            this.m_dtpDatesPrevisionnelles.EndDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_dtpDatesPrevisionnelles.Libelle1 = "Planned start date|10078";
            this.m_dtpDatesPrevisionnelles.Libelle2 = "Planned end date|10079";
            this.m_extLinkField.SetLinkField(this.m_dtpDatesPrevisionnelles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_dtpDatesPrevisionnelles, false);
            this.m_dtpDatesPrevisionnelles.Location = new System.Drawing.Point(476, 5);
            this.m_dtpDatesPrevisionnelles.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_dtpDatesPrevisionnelles, "");
            this.m_dtpDatesPrevisionnelles.Name = "m_dtpDatesPrevisionnelles";
            this.m_dtpDatesPrevisionnelles.Size = new System.Drawing.Size(328, 43);
            this.m_dtpDatesPrevisionnelles.StartDate = new System.DateTime(2010, 9, 27, 10, 28, 28, 140);
            this.m_extStyle.SetStyleBackColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_dtpDatesPrevisionnelles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtpDatesPrevisionnelles.TabIndex = 4018;
            // 
            // m_txtDescrip
            // 
            this.m_txtDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDescrip.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescrip, "Commentaires");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescrip, true);
            this.m_txtDescrip.Location = new System.Drawing.Point(8, 25);
            this.m_txtDescrip.LockEdition = false;
            this.m_txtDescrip.MaxLength = 2000;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescrip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescrip, "");
            this.m_txtDescrip.Multiline = true;
            this.m_txtDescrip.Name = "m_txtDescrip";
            this.m_txtDescrip.Size = new System.Drawing.Size(753, 323);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescrip, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescrip.TabIndex = 5;
            this.m_txtDescrip.Text = "[Commentaires]";
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
            this.m_TabControl.Location = new System.Drawing.Point(12, 119);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageGantt;
            this.m_TabControl.Size = new System.Drawing.Size(789, 399);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageGantt,
            this.m_pageFils,
            this.m_pageInfos,
            this.m_pageEOS,
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
            this.m_pageGantt.Size = new System.Drawing.Size(773, 358);
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
            this.m_gantt.Size = new System.Drawing.Size(773, 338);
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
            this.m_panelMarge.Size = new System.Drawing.Size(773, 75);
            this.m_extStyle.SetStyleBackColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMarge.TabIndex = 1;
            // 
            // m_pageFils
            // 
            this.m_pageFils.Controls.Add(this.m_panelFiltre);
            this.m_pageFils.Controls.Add(this.splitter1);
            this.m_pageFils.Controls.Add(this.m_panelListeElements);
            this.m_extLinkField.SetLinkField(this.m_pageFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFils, false);
            this.m_pageFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFils, "");
            this.m_pageFils.Name = "m_pageFils";
            this.m_pageFils.Selected = false;
            this.m_pageFils.Size = new System.Drawing.Size(773, 358);
            this.m_extStyle.SetStyleBackColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFils.TabIndex = 20;
            this.m_pageFils.Title = "Child Projects|10077";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.Controls.Add(this.m_tab);
            this.m_panelFiltre.Controls.Add(this.c2iTabControl1);
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelFiltre, false);
            this.m_panelFiltre.Location = new System.Drawing.Point(300, 0);
            this.m_panelFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(473, 358);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 4003;
            // 
            // m_tab
            // 
            this.m_tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tab.BoldSelectedPage = true;
            this.m_tab.ControlBottomOffset = 16;
            this.m_tab.ControlRightOffset = 16;
            this.m_tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tab.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tab, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tab, false);
            this.m_tab.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tab, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tab, "");
            this.m_tab.Name = "m_tab";
            this.m_tab.Ombre = true;
            this.m_tab.PositionTop = true;
            this.m_tab.Size = new System.Drawing.Size(473, 358);
            this.m_extStyle.SetStyleBackColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tab, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tab.TabIndex = 2;
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.c2iTabControl1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.Size = new System.Drawing.Size(473, 310);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTabControl1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(297, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 358);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // m_panelListeElements
            // 
            this.m_panelListeElements.Controls.Add(this.m_wndListeProjets);
            this.m_panelListeElements.Controls.Add(this.panel1);
            this.m_panelListeElements.Controls.Add(this.m_lnkDelete);
            this.m_panelListeElements.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelListeElements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeElements, false);
            this.m_panelListeElements.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeElements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelListeElements, "");
            this.m_panelListeElements.Name = "m_panelListeElements";
            this.m_panelListeElements.Size = new System.Drawing.Size(297, 358);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeElements.TabIndex = 10;
            // 
            // m_wndListeProjets
            // 
            this.m_wndListeProjets.AllowDrop = true;
            this.m_wndListeProjets.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3});
            this.m_wndListeProjets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeProjets.EnableCustomisation = true;
            this.m_wndListeProjets.FullRowSelect = true;
            this.m_extLinkField.SetLinkField(this.m_wndListeProjets, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeProjets, false);
            this.m_wndListeProjets.Location = new System.Drawing.Point(0, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeProjets, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeProjets, "");
            this.m_wndListeProjets.Name = "m_wndListeProjets";
            this.m_wndListeProjets.Size = new System.Drawing.Size(297, 322);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeProjets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeProjets, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeProjets.TabIndex = 0;
            this.m_wndListeProjets.UseCompatibleStateImageBehavior = false;
            this.m_wndListeProjets.View = System.Windows.Forms.View.Details;
            this.m_wndListeProjets.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_wndListeProjets_DragDrop);
            this.m_wndListeProjets.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_wndListeProjets_DragEnter);
            this.m_wndListeProjets.DragOver += new System.Windows.Forms.DragEventHandler(this.m_wndListeProjets_DragOver);
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "Projet.Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 272;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkRefreshListe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 23);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // m_lnkRefreshListe
            // 
            this.m_lnkRefreshListe.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lnkRefreshListe, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRefreshListe, false);
            this.m_lnkRefreshListe.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRefreshListe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkRefreshListe, "");
            this.m_lnkRefreshListe.Name = "m_lnkRefreshListe";
            this.m_lnkRefreshListe.Size = new System.Drawing.Size(217, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRefreshListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRefreshListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRefreshListe.TabIndex = 0;
            this.m_lnkRefreshListe.TabStop = true;
            this.m_lnkRefreshListe.Text = "Refresh|20526";
            this.m_lnkRefreshListe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkRefreshListe.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRefreshListe_LinkClicked);
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.m_lnkDelete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDelete, false);
            this.m_lnkDelete.Location = new System.Drawing.Point(0, 345);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDelete, "");
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(297, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDelete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDelete.TabIndex = 2;
            this.m_lnkDelete.TabStop = true;
            this.m_lnkDelete.Text = "Delete|20527";
            this.m_lnkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDelete_LinkClicked);
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
            this.m_pageInfos.Size = new System.Drawing.Size(773, 358);
            this.m_extStyle.SetStyleBackColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInfos.TabIndex = 17;
            this.m_pageInfos.Title = "Information|119";
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
            this.m_pageEOS.Size = new System.Drawing.Size(773, 358);
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
            this.m_panelEOS.Size = new System.Drawing.Size(773, 358);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 2;
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
            this.m_pageFormulaires.Size = new System.Drawing.Size(773, 358);
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
            this.m_PanelChamps.Size = new System.Drawing.Size(767, 352);
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
            this.m_reducteurTop.Location = new System.Drawing.Point(402, 39);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "HideChildProjects");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(400, 52);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 4026;
            this.checkBox1.Text = "Hide children project|20824";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CFormEditionMetaProjet
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(801, 530);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.m_reducteurTop);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionMetaProjet";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionMetaProjet_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionMetaProjet_OnMajChampsPage);
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
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageGantt.ResumeLayout(false);
            this.m_pageFils.ResumeLayout(false);
            this.m_panelFiltre.ResumeLayout(false);
            this.m_panelListeElements.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_pageInfos.ResumeLayout(false);
            this.m_pageInfos.PerformLayout();
            this.m_pageEOS.ResumeLayout(false);
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		public CFormEditionMetaProjet()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionMetaProjet(CMetaProjet proj)
            : base(proj)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionMetaProjet(CMetaProjet proj, CListeObjetsDonnees liste)
            : base(proj, liste)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CMetaProjet MetaProjet
		{
			get	{ return (CMetaProjet)ObjetEdite;	}
		}

        
		//-------------------------------------------------------------------------
		private bool m_bInitialise = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bInitialise = false;
            CResultAErreur result = base.MyInitChamps();

            
			AffecterTitre(I.T( "Meta project @1|20522", MetaProjet.Libelle));

            // Dates prévisionnelles
            m_dtpDatesPrevisionnelles.StartDate = MetaProjet.DateDebutPlanifiee;
            m_dtpDatesPrevisionnelles.EndDate = MetaProjet.DateFinPlanifiee;

            m_dtpDatesPrevisionnelles.Libelle1 = I.T("Start date|20523");
            m_dtpDatesPrevisionnelles.Libelle2 = I.T("End date|20524");

            m_selectTypeMetaProjet.Init(
                typeof(CTypeMetaProjet), "Libelle", false);
            m_selectTypeMetaProjet.ElementSelectionne = MetaProjet.TypeMetaProjet;

            m_extLinkField.FillDialogFromObjet(MetaProjet);

            if (MetaProjet.GetFormulaires().Length > 0)
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Add(m_pageFormulaires);
            }
            else
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }


			m_bInitialise = true;
			return result;
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

            MetaProjet.TypeMetaProjet = m_selectTypeMetaProjet.ElementSelectionne as CTypeMetaProjet;

			m_extLinkField.FillObjetFromDialog(MetaProjet);

			return result;
		}

		


		//-----------------------------TABCONTROL-----------------------------
		private CResultAErreur CFormEditionMetaProjet_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                
                if (page == m_pageFormulaires)
                {
                    m_PanelChamps.ElementEdite = MetaProjet;

                }
                if (page == m_pageFils)
                {
                    if (MetaProjet.FiltreDynamique == null)
                        m_filtreDynamique = new CFiltreDynamique(MetaProjet.ContexteDonnee);
                    else
                        m_filtreDynamique = MetaProjet.FiltreDynamique;

                    m_filtreDynamique.TypeElements = typeof(CProjet);

                    m_panelFiltre.InitSansVariables(m_filtreDynamique);
                    FillListeProjets();
                }
                else if (page == m_pageGantt)
                {
                    InitGantt();
                }
                else if (page == m_pageEOS)
                    m_panelEOS.Init(MetaProjet);
			}
			return result;
		}

        private CResultAErreur CFormEditionMetaProjet_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFils)
            {
                MetaProjet.FiltreDynamique = m_panelFiltre.FiltreDynamique;
            }
            else if (page == m_pageFormulaires)
            {
                result = m_PanelChamps.MAJ_Champs();
            }
            else if (page == m_pageInfos)
            {
            }
            else if (page == m_pageEOS)
                result = m_panelEOS.MajChamps();
			return result;

		}

       
        private void InitGantt()
        {
            m_gantt.Init(MetaProjet);
        }

        

        private void m_gantt_OnMoveElementDeGantt(IElementDeGantt element)
        {
            /*CElementDeGanttProjet elementProjet = element as CElementDeGanttProjet;
            if (elementProjet != null && elementProjet.ProjetAssocie != null && elementProjet.ProjetAssocie == MetaProjet)
            { 
                CMetaProjet MetaProjet = elementProjet.MetaProjetAssocie;
                // Synchronise les controles
                if (MetaProjet.DateDebutPlanifiee != null)
                    m_dtpDatesPrevisionnelles.StartDate = elementProjet.MetaProjetAssocie.DateDebutPlanifiee.Value;
                if (MetaProjet.DateFinPlanifiee != null)
                    m_dtpDatesPrevisionnelles.EndDate = elementProjet.MetaProjetAssocie.DateFinPlanifiee.Value;

                if (MetaProjet.DateDebutReel != null)
                    m_dtpDateDebutReelle.Value = MetaProjet.DateDebutReel;
                if (MetaProjet.DateFinRelle != null)
                    m_dtpDateFinReelle.Value = MetaProjet.DateFinRelle;

                m_chkDatesAuto.Checked = elementProjet.DatesAuto;

            
            }*/
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

        private void FillListeProjets()
        {
            MetaProjet.RelationsProjets.ReadDependances("Projet");
            m_wndListeProjets.Remplir(MetaProjet.RelationsProjets);
            foreach (ListViewItem item in m_wndListeProjets.Items)
            {
                CRelationMetaProjet_Projet rel = item.Tag as CRelationMetaProjet_Projet;
                if (rel != null && rel.IsAutoAdded)
                    item.BackColor = Color.Silver;
                else
                    item.BackColor = Color.White;
            }
        }

        //-----------------------------------------------------------------------
        private void m_wndListeProjets_DragEnter(object sender, DragEventArgs e)
        {
            if( m_gestionnaireModeEdition.ModeEdition &&  
                (e.Data.GetDataPresent(typeof(CReferenceObjetDonnee[]) ) ||
                e.Data.GetDataPresent(typeof(CReferenceObjetDonnee))))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
            
        }

        //-----------------------------------------------------------------------
        private void m_wndListeProjets_DragDrop(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
            if (!m_gestionnaireModeEdition.ModeEdition)
                return;
            CReferenceObjetDonnee[] refObjs = e.Data.GetData(typeof(CReferenceObjetDonnee[])) as CReferenceObjetDonnee[];
            if (refObjs == null)
            {
                CReferenceObjetDonnee r = e.Data.GetData(typeof(CReferenceObjetDonnee)) as CReferenceObjetDonnee;
                if ( r != null )
                    refObjs = new CReferenceObjetDonnee[] { r };
            }
            if (refObjs != null)
            {
                foreach (CReferenceObjetDonnee refObj in refObjs)
                {
                    CProjet prj = refObj.GetObjet(MetaProjet.ContexteDonnee) as CProjet;
                    if ( prj != null )
                        MetaProjet.AssocieProjet(prj, false);
                }
                InvalidePage(m_pageGantt);
                
                m_wndListeProjets.Remplir(MetaProjet.RelationsProjets);
                e.Effect = DragDropEffects.Link;
            }
        }

        //-----------------------------------------------------------------------
        private void m_wndListeProjets_DragOver(object sender, DragEventArgs e)
        {
            if( m_gestionnaireModeEdition.ModeEdition &&  
                (e.Data.GetDataPresent(typeof(CReferenceObjetDonnee[]) )||
                e.Data.GetDataPresent(typeof(CReferenceObjetDonnee))))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void m_lnkRefreshListe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MetaProjet.FiltreDynamique = m_panelFiltre.FiltreDynamique;
            MetaProjet.RefreshProjectsList();
            FillListeProjets();
            InvalidePage(m_pageGantt);
        }

        //-------------------------------------------------------------------------------------
        private void m_lnkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_wndListeProjets.SelectedItems.Count > 0)
            {

                StringBuilder bl = new StringBuilder();
                int nNbProjets = 0;
                foreach (ListViewItem item in m_wndListeProjets.SelectedItems)
                {
                    CRelationMetaProjet_Projet rel = item.Tag as CRelationMetaProjet_Projet;
                    if (rel != null && !rel.IsAutoAdded)
                    {
                        bl.Append(rel.Id);
                        bl.Append(',');
                        nNbProjets++;
                    }
                }
                if (MessageBox.Show(I.T("Remove @1 projects from this meta project ?|20528", nNbProjets.ToString()),
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                    return;
                if (bl.Length > 0)
                {
                    CListeObjetDonneeGenerique<CRelationMetaProjet_Projet> lst = new CListeObjetDonneeGenerique<CRelationMetaProjet_Projet>(MetaProjet.ContexteDonnee);
                    bl.Remove(bl.Length - 1, 1);
                    lst.Filtre = new CFiltreData(CRelationMetaProjet_Projet.c_champId + " in (" +
                        bl.ToString()+")");
                    CResultAErreur result = CObjetDonneeAIdNumerique.Delete(lst, true);
                    if (!result)
                        CFormAlerte.Afficher(result.Erreur);
                    else
                    {
                        FillListeProjets();
                        InvalidePage(m_pageGantt);
                    }
                }
            }
        }

        //------------------------------------------------------------------------------------
        private void m_selectTypeMetaProjet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (m_selectTypeMetaProjet.ElementSelectionne != null && m_gestionnaireModeEdition.ModeEdition)
                MetaProjet.TypeMetaProjet = (CTypeMetaProjet)m_selectTypeMetaProjet.ElementSelectionne;
            if (MetaProjet.GetFormulaires().Length > 0)
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Add(m_pageFormulaires);
            }
            else
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }
            m_PanelChamps.ElementEdite = MetaProjet;
        }

        private void m_TabControl_SelectionChanged(object sender, EventArgs e)
        {

        }


	}
}

