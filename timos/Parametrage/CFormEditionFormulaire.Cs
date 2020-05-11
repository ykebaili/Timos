using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;
using sc2i.formulaire;
using sc2i.formulaire.win32.editor;

using timos.acteurs;


namespace timos
{
	public class CFormEditionFormulaire : CFormEditionStdTimos, IFormNavigable
	{

		private CFournisseurPropDynStd m_fournisseurProprietes = new CFournisseurPropDynStd(true);
	

		#region Designer generated code


		private System.Windows.Forms.Label m_lblLabel;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.CComboboxAutoFilled m_cmbRoleFormulaire;
		private sc2i.win32.common.C2iPanel m_panelFondEdition;
		private sc2i.formulaire.win32.editor.CPanelListe2iWnd m_listeControles;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel m_panDesigner;
		private sc2i.formulaire.win32.editor.CPanelEditionFormulaire m_panelEditionFormulaire;
		private System.Windows.Forms.PropertyGrid m_propertyGrid;
		private sc2i.win32.common.C2iPanelOmbre m_panelLibelle;
		private System.Windows.Forms.CheckBox m_chkPartout;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.common.C2iNumericUpDown c2iNumericUpDown1;
        private Crownwood.Magic.Controls.TabPage pageFormulaire;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeMasquer;
        private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private CCtrlSauvegardeProfilDesigner m_ctrlSavProfilDesigner;
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
            sc2i.win32.common.CGrilleEditeurObjetGraphique cGrilleEditeurObjetGraphique1 = new sc2i.win32.common.CGrilleEditeurObjetGraphique();
            sc2i.win32.common.CProfilEditeurObjetGraphique cProfilEditeurObjetGraphique1 = new sc2i.win32.common.CProfilEditeurObjetGraphique();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbRoleFormulaire = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_panelFondEdition = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panDesigner = new System.Windows.Forms.Panel();
            this.m_panelEditionFormulaire = new sc2i.formulaire.win32.editor.CPanelEditionFormulaire();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.m_propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_listeControles = new sc2i.formulaire.win32.editor.CPanelListe2iWnd();
            this.m_panelLibelle = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iNumericUpDown1 = new sc2i.win32.common.C2iNumericUpDown();
            this.m_chkPartout = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageFormulaire = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeMasquer = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_ctrlSavProfilDesigner = new timos.CCtrlSauvegardeProfilDesigner();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panelFondEdition.SuspendLayout();
            this.m_panDesigner.SuspendLayout();
            this.m_panelLibelle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.pageFormulaire.SuspendLayout();
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
            // m_lblLabel
            // 
            this.m_lblLabel.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(12, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 67;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(64, 6);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(168, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(248, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4001;
            this.label2.Text = "Purpose|898";
            // 
            // m_cmbRoleFormulaire
            // 
            this.m_cmbRoleFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbRoleFormulaire.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbRoleFormulaire, "");
            this.m_cmbRoleFormulaire.ListDonnees = null;
            this.m_cmbRoleFormulaire.Location = new System.Drawing.Point(312, 6);
            this.m_cmbRoleFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbRoleFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbRoleFormulaire, "");
            this.m_cmbRoleFormulaire.Name = "m_cmbRoleFormulaire";
            this.m_cmbRoleFormulaire.NullAutorise = true;
            this.m_cmbRoleFormulaire.ProprieteAffichee = "Libelle";
            this.m_cmbRoleFormulaire.Size = new System.Drawing.Size(204, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbRoleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbRoleFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbRoleFormulaire.TabIndex = 4002;
            this.m_cmbRoleFormulaire.TextNull = "Formulaire général";
            this.m_cmbRoleFormulaire.Tri = true;
            this.m_cmbRoleFormulaire.SelectionChangeCommitted += new System.EventHandler(this.m_cmbRoleFormulaire_SelectionChangeCommitted);
            this.m_cmbRoleFormulaire.SelectedValueChanged += new System.EventHandler(this.m_cmbRoleFormulaire_SelectedValueChanged);
            // 
            // m_panelFondEdition
            // 
            this.m_panelFondEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFondEdition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFondEdition.Controls.Add(this.m_panDesigner);
            this.m_panelFondEdition.Controls.Add(this.splitter2);
            this.m_panelFondEdition.Controls.Add(this.m_propertyGrid);
            this.m_panelFondEdition.Controls.Add(this.splitter1);
            this.m_panelFondEdition.Controls.Add(this.m_listeControles);
            this.m_panelFondEdition.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelFondEdition, "");
            this.m_panelFondEdition.Location = new System.Drawing.Point(0, 0);
            this.m_panelFondEdition.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFondEdition, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelFondEdition, "");
            this.m_panelFondEdition.Name = "m_panelFondEdition";
            this.m_panelFondEdition.Size = new System.Drawing.Size(790, 371);
            this.m_extStyle.SetStyleBackColor(this.m_panelFondEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelFondEdition, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelFondEdition.TabIndex = 3;
            // 
            // m_panDesigner
            // 
            this.m_panDesigner.Controls.Add(this.m_panelEditionFormulaire);
            this.m_panDesigner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panDesigner, "");
            this.m_panDesigner.Location = new System.Drawing.Point(149, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panDesigner, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panDesigner, "");
            this.m_panDesigner.Name = "m_panDesigner";
            this.m_panDesigner.Size = new System.Drawing.Size(452, 371);
            this.m_extStyle.SetStyleBackColor(this.m_panDesigner, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panDesigner, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panDesigner.TabIndex = 4;
            // 
            // m_panelEditionFormulaire
            // 
            this.m_panelEditionFormulaire.AllowDrop = true;
            this.m_panelEditionFormulaire.AutoScroll = true;
            this.m_panelEditionFormulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEditionFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEditionFormulaire.Echelle = 1F;
            this.m_panelEditionFormulaire.EffetAjoutSuppression = false;
            this.m_panelEditionFormulaire.EffetFonduMenu = true;
            this.m_panelEditionFormulaire.EnDeplacement = false;
            this.m_panelEditionFormulaire.EntiteEditee = null;
            this.m_panelEditionFormulaire.ForeColor = System.Drawing.Color.Black;
            this.m_panelEditionFormulaire.FormesDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            this.m_panelEditionFormulaire.FournisseurProprietes = null;
            cGrilleEditeurObjetGraphique1.Couleur = System.Drawing.Color.Blue;
            cGrilleEditeurObjetGraphique1.HauteurCarreau = 20;
            cGrilleEditeurObjetGraphique1.LargeurCarreau = 25;
            cGrilleEditeurObjetGraphique1.Representation = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            cGrilleEditeurObjetGraphique1.TailleCarreau = new System.Drawing.Size(25, 20);
            this.m_panelEditionFormulaire.GrilleAlignement = cGrilleEditeurObjetGraphique1;
            this.m_panelEditionFormulaire.HauteurMinimaleDesObjets = 10;
            this.m_panelEditionFormulaire.HistorisationActive = true;
            this.m_panelEditionFormulaire.LargeurMinimaleDesObjets = 10;
            this.m_extLinkField.SetLinkField(this.m_panelEditionFormulaire, "");
            this.m_panelEditionFormulaire.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditionFormulaire.LockEdition = false;
            this.m_panelEditionFormulaire.Marge = 10;
            this.m_panelEditionFormulaire.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEditionFormulaire.ModeRepresentationGrille = sc2i.win32.common.ERepresentationGrille.LignesContinues;
            this.m_panelEditionFormulaire.ModeSourisStandard = true;
            this.m_extModulesAssociator.SetModules(this.m_panelEditionFormulaire, "");
            this.m_panelEditionFormulaire.Name = "m_panelEditionFormulaire";
            this.m_panelEditionFormulaire.NombreHistorisation = 10;
            this.m_panelEditionFormulaire.ObjetEdite = null;
            cProfilEditeurObjetGraphique1.FormeDesPoignees = sc2i.win32.common.EFormePoignee.Carre;
            cProfilEditeurObjetGraphique1.Grille = cGrilleEditeurObjetGraphique1;
            cProfilEditeurObjetGraphique1.HistorisationActive = true;
            cProfilEditeurObjetGraphique1.Marge = 10;
            cProfilEditeurObjetGraphique1.ModeAffichageGrille = sc2i.win32.common.EModeAffichageGrille.AuDeplacement;
            cProfilEditeurObjetGraphique1.NombreHistorisation = 10;
            cProfilEditeurObjetGraphique1.ToujoursAlignerSurLaGrille = false;
            this.m_panelEditionFormulaire.Profil = cProfilEditeurObjetGraphique1;
            this.m_panelEditionFormulaire.RefreshSelectionChanged = true;
            this.m_panelEditionFormulaire.Size = new System.Drawing.Size(452, 371);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelEditionFormulaire.TabIndex = 0;
            this.m_panelEditionFormulaire.ToujoursAlignerSelonLesControles = true;
            this.m_panelEditionFormulaire.ToujoursAlignerSurLaGrille = false;
            this.m_panelEditionFormulaire.TypeEdite = null;
            this.m_panelEditionFormulaire.SelectionChanged += new System.EventHandler(this.m_panelEditionFormulaire_SelectionChanged);
            this.m_panelEditionFormulaire.ElementMovedOrResized += new System.EventHandler(this.m_panelEditionFormulaire_ElementMovedOrResized);
            // 
            // splitter2
            // 
            this.splitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.splitter2, "");
            this.splitter2.Location = new System.Drawing.Point(601, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter2, "");
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(5, 371);
            this.m_extStyle.SetStyleBackColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter2.TabIndex = 3;
            this.splitter2.TabStop = false;
            // 
            // m_propertyGrid
            // 
            this.m_propertyGrid.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.m_propertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_propertyGrid.HelpVisible = false;
            this.m_propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.m_extLinkField.SetLinkField(this.m_propertyGrid, "");
            this.m_propertyGrid.Location = new System.Drawing.Point(606, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_propertyGrid, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_propertyGrid, "");
            this.m_propertyGrid.Name = "m_propertyGrid";
            this.m_propertyGrid.Size = new System.Drawing.Size(184, 371);
            this.m_extStyle.SetStyleBackColor(this.m_propertyGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_propertyGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_propertyGrid.TabIndex = 2;
            this.m_propertyGrid.ToolbarVisible = false;
            this.m_propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.m_propertyGrid_PropertyValueChanged);
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.splitter1.Location = new System.Drawing.Point(144, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 371);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // m_listeControles
            // 
            this.m_listeControles.AutoScroll = true;
            this.m_listeControles.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_listeControles, "");
            this.m_listeControles.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeControles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeControles, "");
            this.m_listeControles.Name = "m_listeControles";
            this.m_listeControles.Size = new System.Drawing.Size(144, 371);
            this.m_extStyle.SetStyleBackColor(this.m_listeControles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeControles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeControles.TabIndex = 0;
            // 
            // m_panelLibelle
            // 
            this.m_panelLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelLibelle.Controls.Add(this.m_cmbRoleFormulaire);
            this.m_panelLibelle.Controls.Add(this.m_txtLibelle);
            this.m_panelLibelle.Controls.Add(this.c2iNumericUpDown1);
            this.m_panelLibelle.Controls.Add(this.m_chkPartout);
            this.m_panelLibelle.Controls.Add(this.m_lblLabel);
            this.m_panelLibelle.Controls.Add(this.label2);
            this.m_panelLibelle.Controls.Add(this.label3);
            this.m_panelLibelle.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelLibelle, "");
            this.m_panelLibelle.Location = new System.Drawing.Point(16, 44);
            this.m_panelLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelLibelle, "");
            this.m_panelLibelle.Name = "m_panelLibelle";
            this.m_panelLibelle.Size = new System.Drawing.Size(688, 72);
            this.m_extStyle.SetStyleBackColor(this.m_panelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelLibelle.TabIndex = 0;
            this.m_panelLibelle.Text = "[NumeroOrdre]";
            // 
            // c2iNumericUpDown1
            // 
            this.c2iNumericUpDown1.DoubleValue = 0;
            this.c2iNumericUpDown1.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iNumericUpDown1, "NumeroOrdre");
            this.c2iNumericUpDown1.Location = new System.Drawing.Point(64, 28);
            this.c2iNumericUpDown1.LockEdition = false;
            this.c2iNumericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iNumericUpDown1, "");
            this.c2iNumericUpDown1.Name = "c2iNumericUpDown1";
            this.c2iNumericUpDown1.Size = new System.Drawing.Size(64, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iNumericUpDown1.TabIndex = 4005;
            this.c2iNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c2iNumericUpDown1.ThousandsSeparator = true;
            // 
            // m_chkPartout
            // 
            this.m_extLinkField.SetLinkField(this.m_chkPartout, "AfficherPartout");
            this.m_chkPartout.Location = new System.Drawing.Point(522, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPartout, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkPartout, "");
            this.m_chkPartout.Name = "m_chkPartout";
            this.m_chkPartout.Size = new System.Drawing.Size(147, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkPartout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPartout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPartout.TabIndex = 4003;
            this.m_chkPartout.Text = "For all elements|919";
            this.m_chkPartout.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Order|782";
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
            this.m_tabControl.SelectedTab = this.pageFormulaire;
            this.m_tabControl.Size = new System.Drawing.Size(806, 411);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFormulaire});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageFormulaire
            // 
            this.pageFormulaire.Controls.Add(this.m_panelFondEdition);
            this.m_extLinkField.SetLinkField(this.pageFormulaire, "");
            this.pageFormulaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFormulaire, "");
            this.pageFormulaire.Name = "pageFormulaire";
            this.pageFormulaire.Size = new System.Drawing.Size(790, 370);
            this.m_extStyle.SetStyleBackColor(this.pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageFormulaire.TabIndex = 10;
            this.pageFormulaire.Title = "Form|555";
            // 
            // m_wndListeMasquer
            // 
            this.m_wndListeMasquer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeMasquer.CheckBoxes = true;
            this.m_wndListeMasquer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn2});
            this.m_wndListeMasquer.EnableCustomisation = true;
            this.m_wndListeMasquer.FullRowSelect = true;
            this.m_wndListeMasquer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_extLinkField.SetLinkField(this.m_wndListeMasquer, "");
            this.m_wndListeMasquer.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeMasquer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeMasquer, "");
            this.m_wndListeMasquer.MultiSelect = false;
            this.m_wndListeMasquer.Name = "m_wndListeMasquer";
            this.m_wndListeMasquer.Size = new System.Drawing.Size(216, 360);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeMasquer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeMasquer.TabIndex = 13;
            this.m_wndListeMasquer.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMasquer.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Libellé";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 200;
            // 
            // m_ctrlSavProfilDesigner
            // 
            this.m_ctrlSavProfilDesigner.Designer = this.m_panelEditionFormulaire;
            this.m_ctrlSavProfilDesigner.Formulaire = this;
            // 
            // CFormEditionFormulaire
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelLibelle);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionFormulaire";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CFormEditionFormulaire_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelLibelle, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panelFondEdition.ResumeLayout(false);
            this.m_panDesigner.ResumeLayout(false);
            this.m_panelLibelle.ResumeLayout(false);
            this.m_panelLibelle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageFormulaire.ResumeLayout(false);
            this.ResumeLayout(false);

		}


		#endregion


		private Type m_typeAssocie = null;
		private Image m_imageFond = null;


		//-------------------------------------------------------------------------
		public CFormEditionFormulaire()
			: base()
		{
			InitializeComponent();
			MyInit();

		}
		public CFormEditionFormulaire(CFormulaire formulaire)
			: base(formulaire)
		{
			InitializeComponent();
			MyInit();
		}

		//-------------------------------------------------------------------------
		public CFormEditionFormulaire(CFormulaire formulaire, Image imageFond, Type typeAssocie)
			: base(formulaire)
		{
			InitializeComponent();
			MyInit();
			m_imageFond = imageFond;
			m_typeAssocie = typeAssocie;
		}

		//-------------------------------------------------------------------------
		public CFormEditionFormulaire(CFormulaire formulaire, CListeObjetsDonnees liste)
			: base(formulaire, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
			MyInit();
		}

		//-------------------------------------------------------------------------
		public void MyInit()
		{
			m_listeControles.SetTypeEdite(m_typeAssocie);
			m_listeControles.AddAllLoadedAssemblies();
			/*m_listeControles.AddTypeControl(typeof(C2iWndChampCustom));
			//m_listeControles.AddTypeControl ( typeof(C2iWndProprieteDynamique) );
			m_listeControles.AddTypeControl(typeof(C2iWndFormule));
			m_listeControles.AddAssembly(typeof(sc2i.formulaire.C2iWnd).Assembly);
			m_listeControles.AddAssembly(typeof(sc2i.formulaire.C2iWndLink).Assembly);*/
			m_listeControles.RefreshControls();
		}

		//-------------------------------------------------------------------------
		private CFormulaire Formulaire
		{
			get
			{
				return (CFormulaire)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
			AffecterTitre(I.T("Form @1|10000", Formulaire.Libelle));
			if (result)
			{
				//CUtilASauvegardeProfilDesigner.InitialiserProfil( new CContexteSauvegardeProfilDesigner(m_panelEditionFormulaire));

				ArrayList lst = new ArrayList ( CRoleChampCustom.Roles );
				foreach ( CRoleChampCustom role in lst.ToArray(typeof(CRoleChampCustom)) )
					if ( role.CodeRole == sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom )
						lst.Remove ( role );
				if ( Formulaire.Role != null && Formulaire.Role.CodeRole == 
					sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom )
					m_panelLibelle.Visible = false;
				else
					m_panelLibelle.Visible = true;
				m_cmbRoleFormulaire.ListDonnees = lst;
				m_cmbRoleFormulaire.SelectedValue = Formulaire.Role;

				C2iWndFenetre fenetre = Formulaire.Formulaire;
				fenetre.ImageFond = m_imageFond;
				m_panelEditionFormulaire.ObjetEdite = fenetre;
				m_panelEditionFormulaire.FournisseurProprietes = m_fournisseurProprietes;
				
                				
				RedefinitRoleAssocie();
				m_panelEditionFormulaire.TypeEdite = m_typeAssocie;
				if ( m_imageFond != null )
					Formulaire.Formulaire.ImageFond = m_imageFond;

				CListeObjetsDonnees listeRestrictions = new CListeObjetsDonnees ( Formulaire.ContexteDonnee, typeof ( CRestrictionChampCustom ) );
				m_wndListeMasquer.Remplir ( listeRestrictions );
				foreach ( ListViewItem item in m_wndListeMasquer.Items )
				{
					CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
					if ( (Formulaire.RestrictionsMasquer & (int)Math.Pow(2,rest.ValeurFlag)) != 0 )
						item.Checked = true;
					else
						item.Checked = false;
				}
			}
			return result;
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			//CUtilASauvegardeProfilDesigner.SauvegarderDansRegistre(new CContexteSauvegardeProfilDesigner(m_panelEditionFormulaire));

			if (!result)
				return result;
			
			if ( m_cmbRoleFormulaire.SelectedValue is CRoleChampCustom )
				Formulaire.Role = (CRoleChampCustom)m_cmbRoleFormulaire.SelectedValue;
			else
				Formulaire.Role = null;
			Formulaire.Formulaire = (sc2i.formulaire.C2iWndFenetre)m_panelEditionFormulaire.ObjetEdite;

			int nRest = 0;
			foreach ( ListViewItem item in m_wndListeMasquer.Items )
			{
				if ( item.Checked )
				{
					CRestrictionChampCustom rest = (CRestrictionChampCustom)item.Tag;
					nRest |= (int)Math.Pow(2,rest.ValeurFlag);
				}
			}
			Formulaire.RestrictionsMasquer = nRest;
			return result;
		}
		//-------------------------------------------------------------------------
		private void CFormEditionFormulaire_Load(object sender, System.EventArgs e)
		{
			//CProprieteChampCustomEditor.SetEditeur ( new CSelectionneurChampCustomTimos() );
		}
		//-------------------------------------------------------------------------
		private void m_propertyGrid_PropertyValueChanged(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			m_panelEditionFormulaire.Refresh();
		}

		private void m_cmbRoleFormulaire_SelectedValueChanged(object sender, System.EventArgs e)
		{
			
		}

		private void RedefinitRoleAssocie()
		{
			CRoleChampCustom role = m_cmbRoleFormulaire.SelectedValue as CRoleChampCustom;
			if (role != null && role.CodeRole !=
					sc2i.custom.CRoleFormulaireSurImpressionWin32.c_roleChampCustom)
			{
				m_panelEditionFormulaire.TypeEdite = role.TypeAssocie;
				m_typeAssocie = role.TypeAssocie;
			}
			Actual();
		}

		private void m_cmbRoleFormulaire_SelectionChangeCommitted(object sender, EventArgs e)
		{
			
			RedefinitRoleAssocie();
			MyInit();
		}
		//-------------------------------------------------------------------------		

		private void m_panelEditionFormulaire_ElementMovedOrResized(object sender, EventArgs e)
		{
			Actual();
		}
		//private int m_lastWidthProperty;
		private void Actual()
		{

			if (m_panelEditionFormulaire.Selection.Count == 0)
			{
				m_propertyGrid.SelectedObject = null;
			}
			else
			{
				if (m_panelEditionFormulaire.Selection.Count == 1)
				{
					m_propertyGrid.SelectedObject = m_panelEditionFormulaire.Selection[0];
				}
				else
				{
					List<object> objs = new List<object>();
					foreach (C2iWnd ele in m_panelEditionFormulaire.Selection)
						objs.Add(ele);
					m_propertyGrid.SelectedObjects = objs.ToArray();
				}
			}
		}


		private void m_panelEditionFormulaire_SelectionChanged(object sender, EventArgs e)
		{
			Actual();
		}


	}



}

