using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.drawing;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using timos.acteurs;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeTicket))]
	public class CFormEditionTypeTicket : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_tabPageChampsCustomDef;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
        private ListViewAutoFilled m_listeDelegations;
        private ListViewAutoFilledColumn listViewAutoFilledColumn10;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Crownwood.Magic.Controls.TabPage m_tabPageContrats;
        private Label lbl_instruccontrats;
        private CPanelListeRelationSelection m_panelEditRelationsContrats;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private Crownwood.Magic.Controls.TabPage m_tabPagePhases;
		private timos.win32.composants.CPanelEditPhasesTicket m_panelPhases;
        private Crownwood.Magic.Controls.TabPage m_tabPageEvenements;
        private CPanelDefinisseurEvenements m_panelDefinisseurEvenements;
		private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
        private Crownwood.Magic.Controls.TabPage m_tabPageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_PanelChamps;
        private C2iTextBox m_txtCode;
        private Label label2;
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtCode = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_tabPagePhases = new Crownwood.Magic.Controls.TabPage();
            this.m_panelPhases = new timos.win32.composants.CPanelEditPhasesTicket();
            this.m_tabPageChampsCustomDef = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_tabPageContrats = new Crownwood.Magic.Controls.TabPage();
            this.lbl_instruccontrats = new System.Windows.Forms.Label();
            this.m_panelEditRelationsContrats = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_tabPageEvenements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurEvenements = new timos.CPanelDefinisseurEvenements();
            this.m_listeDelegations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn10 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageFormulaires.SuspendLayout();
            this.m_tabPagePhases.SuspendLayout();
            this.m_tabPageChampsCustomDef.SuspendLayout();
            this.m_tabPageContrats.SuspendLayout();
            this.m_tabPageEvenements.SuspendLayout();
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
            this.m_panelCle.Location = new System.Drawing.Point(568, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
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
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Ticket Type label|484";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(157, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(395, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtCode);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(592, 78);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_txtCode
            // 
            this.m_extLinkField.SetLinkField(this.m_txtCode, "Code");
            this.m_txtCode.Location = new System.Drawing.Point(157, 32);
            this.m_txtCode.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCode, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCode, "");
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(395, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 0;
            this.m_txtCode.Text = "[Code]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(4, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Code|40";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_tabPageFormulaires;
            this.m_tabControl.Size = new System.Drawing.Size(822, 396);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageFormulaires,
            this.m_tabPagePhases,
            this.m_tabPageChampsCustomDef,
            this.m_tabPageContrats,
            this.m_tabPageEvenements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPageFormulaires
            // 
            this.m_tabPageFormulaires.Controls.Add(this.m_PanelChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageFormulaires, "");
            this.m_tabPageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageFormulaires, "");
            this.m_tabPageFormulaires.Name = "m_tabPageFormulaires";
            this.m_tabPageFormulaires.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageFormulaires.TabIndex = 17;
            this.m_tabPageFormulaires.Title = "Form|60";
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
            this.m_PanelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_PanelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChamps, "");
            this.m_PanelChamps.Name = "m_PanelChamps";
            this.m_PanelChamps.Ombre = false;
            this.m_PanelChamps.PositionTop = true;
            this.m_PanelChamps.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChamps.TabIndex = 1;
            this.m_PanelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // m_tabPagePhases
            // 
            this.m_tabPagePhases.Controls.Add(this.m_panelPhases);
            this.m_extLinkField.SetLinkField(this.m_tabPagePhases, "");
            this.m_tabPagePhases.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPagePhases, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPagePhases, "");
            this.m_tabPagePhases.Name = "m_tabPagePhases";
            this.m_tabPagePhases.Selected = false;
            this.m_tabPagePhases.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_tabPagePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPagePhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPagePhases.TabIndex = 15;
            this.m_tabPagePhases.Title = "Phases|639";
            // 
            // m_panelPhases
            // 
            this.m_panelPhases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelPhases, "");
            this.m_panelPhases.Location = new System.Drawing.Point(0, 0);
            this.m_panelPhases.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPhases, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelPhases, "");
            this.m_panelPhases.Name = "m_panelPhases";
            this.m_panelPhases.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_panelPhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPhases, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPhases.TabIndex = 0;
            // 
            // m_tabPageChampsCustomDef
            // 
            this.m_tabPageChampsCustomDef.Controls.Add(this.m_panelDefinisseurChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageChampsCustomDef, "");
            this.m_tabPageChampsCustomDef.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageChampsCustomDef, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageChampsCustomDef, "");
            this.m_tabPageChampsCustomDef.Name = "m_tabPageChampsCustomDef";
            this.m_tabPageChampsCustomDef.Selected = false;
            this.m_tabPageChampsCustomDef.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageChampsCustomDef, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageChampsCustomDef, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageChampsCustomDef.TabIndex = 12;
            this.m_tabPageChampsCustomDef.Title = "Custom Fields|158";
            // 
            // m_panelDefinisseurChamps
            // 
            this.m_panelDefinisseurChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(4, 3);
            this.m_panelDefinisseurChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChamps, "");
            this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
            this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(799, 349);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurChamps.TabIndex = 1;
            // 
            // m_tabPageContrats
            // 
            this.m_tabPageContrats.Controls.Add(this.lbl_instruccontrats);
            this.m_tabPageContrats.Controls.Add(this.m_panelEditRelationsContrats);
            this.m_extLinkField.SetLinkField(this.m_tabPageContrats, "");
            this.m_tabPageContrats.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageContrats, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageContrats, "");
            this.m_tabPageContrats.Name = "m_tabPageContrats";
            this.m_tabPageContrats.Selected = false;
            this.m_tabPageContrats.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageContrats.TabIndex = 14;
            this.m_tabPageContrats.Title = "Contracts|640";
            // 
            // lbl_instruccontrats
            // 
            this.m_extLinkField.SetLinkField(this.lbl_instruccontrats, "");
            this.lbl_instruccontrats.Location = new System.Drawing.Point(29, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_instruccontrats, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_instruccontrats, "");
            this.lbl_instruccontrats.Name = "lbl_instruccontrats";
            this.lbl_instruccontrats.Size = new System.Drawing.Size(452, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_instruccontrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_instruccontrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_instruccontrats.TabIndex = 1;
            this.lbl_instruccontrats.Text = "Select contracts associated with this Ticket Type|641";
            // 
            // m_panelEditRelationsContrats
            // 
            this.m_panelEditRelationsContrats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditRelationsContrats.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_panelEditRelationsContrats.EnableCustomisation = true;
            this.m_panelEditRelationsContrats.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelEditRelationsContrats, "");
            this.m_panelEditRelationsContrats.Location = new System.Drawing.Point(19, 51);
            this.m_panelEditRelationsContrats.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditRelationsContrats, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditRelationsContrats, "");
            this.m_panelEditRelationsContrats.Name = "m_panelEditRelationsContrats";
            this.m_panelEditRelationsContrats.Size = new System.Drawing.Size(784, 292);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditRelationsContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditRelationsContrats, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditRelationsContrats.TabIndex = 0;
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
            // m_tabPageEvenements
            // 
            this.m_tabPageEvenements.Controls.Add(this.m_panelDefinisseurEvenements);
            this.m_extLinkField.SetLinkField(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageEvenements, "");
            this.m_tabPageEvenements.Name = "m_tabPageEvenements";
            this.m_tabPageEvenements.Selected = false;
            this.m_tabPageEvenements.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageEvenements.TabIndex = 16;
            this.m_tabPageEvenements.Title = "Events|183";
            // 
            // m_panelDefinisseurEvenements
            // 
            this.m_panelDefinisseurEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurEvenements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurEvenements, "");
            this.m_panelDefinisseurEvenements.Name = "m_panelDefinisseurEvenements";
            this.m_panelDefinisseurEvenements.Size = new System.Drawing.Size(806, 355);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurEvenements.TabIndex = 0;
            // 
            // m_listeDelegations
            // 
            this.m_listeDelegations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeDelegations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn10});
            this.m_listeDelegations.EnableCustomisation = true;
            this.m_listeDelegations.FullRowSelect = true;
            this.m_listeDelegations.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listeDelegations, "");
            this.m_listeDelegations.Location = new System.Drawing.Point(9, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeDelegations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeDelegations, "");
            this.m_listeDelegations.MultiSelect = false;
            this.m_listeDelegations.Name = "m_listeDelegations";
            this.m_listeDelegations.Size = new System.Drawing.Size(306, 264);
            this.m_extStyle.SetStyleBackColor(this.m_listeDelegations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeDelegations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeDelegations.TabIndex = 8;
            this.m_listeDelegations.UseCompatibleStateImageBehavior = false;
            this.m_listeDelegations.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn10
            // 
            this.listViewAutoFilledColumn10.Field = "GroupeActeur.Libelle";
            this.listViewAutoFilledColumn10.PrecisionWidth = 0;
            this.listViewAutoFilledColumn10.ProportionnalSize = false;
            this.listViewAutoFilledColumn10.Text = "Label|50";
            this.listViewAutoFilledColumn10.Visible = true;
            this.listViewAutoFilledColumn10.Width = 200;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 120;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_panelPhases.Editeur;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // CFormEditionTypeTicket
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeTicket";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
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
            this.m_tabPageFormulaires.ResumeLayout(false);
            this.m_tabPagePhases.ResumeLayout(false);
            this.m_tabPageChampsCustomDef.ResumeLayout(false);
            this.m_tabPageContrats.ResumeLayout(false);
            this.m_tabPageEvenements.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeTicket()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeTicket(CTypeTicket typeTicket)
            : base(typeTicket)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionTypeTicket(CTypeTicket typeTicket, CListeObjetsDonnees liste)
            : base(typeTicket, liste)
		{
			InitializeComponent();
		}
		
		//-------------------------------------------------------------------------
		private CTypeTicket TypeTicket
		{
			get
			{
				return (CTypeTicket)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Ticket Type|481")+" : "+ TypeTicket.Libelle);

            m_PanelChamps.ElementEdite = TypeTicket;

            // Page champs custom
            m_panelDefinisseurChamps.InitPanel(
                TypeTicket,
                typeof(CFormEditionChampCustom),
                typeof(CFormEditionFormulaireAvance));

            // Contrats
            CListeObjetsDonnees listeContrats = new CListeObjetsDonnees(TypeTicket.ContexteDonnee, typeof(CContrat));

            m_panelEditRelationsContrats.Init(
                listeContrats,
                TypeTicket.RelationsContratsListe,
                TypeTicket,
                "TypeTicket",
                "Contrat");
            m_panelEditRelationsContrats.RemplirGrille();

			m_panelPhases.InitChamps(TypeTicket);
            m_panelDefinisseurEvenements.InitChamps(TypeTicket);
		
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			//CUtilASauvegardeProfilDesigner.SauvegarderDansRegistre(new CContexteSauvegardeProfilDesigner(m_panelPhases.Editeur));

            if (result)
                result = m_PanelChamps.MAJ_Champs();
            if (result)
                m_panelDefinisseurChamps.MAJ_Champs();
            if (result)
                m_panelEditRelationsContrats.ApplyModifs();
			if (result)
				result = m_panelPhases.MajChamps();
            if (result)
                result = m_panelDefinisseurEvenements.MAJ_Champs();

            return result;
        }
	}
}

