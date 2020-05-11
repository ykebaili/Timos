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

using sc2i.process;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CGroupeParametrage))]
	public class CFormEditionGroupeParametrage : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private sc2i.win32.common.C2iTabControl c2iTabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeActions;
		private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeEvenements;
		private System.Windows.Forms.LinkLabel m_btnExecuter;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionGroupeParametrage()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeParametrage(CGroupeParametrage GroupeParametrage)
			:base(GroupeParametrage)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeParametrage(CGroupeParametrage GroupeParametrage, CListeObjetsDonnees liste)
			:base(GroupeParametrage, liste)
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
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionGroupeParametrage));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeEvenements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_btnExecuter = new System.Windows.Forms.LinkLabel();
            this.m_panelListeActions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
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
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(73, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(352, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(456, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 104);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 1;
            this.c2iTabControl1.SelectedTab = this.tabPage2;
            this.c2iTabControl1.Size = new System.Drawing.Size(814, 430);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelListeEvenements);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(798, 389);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Events|183";
            // 
            // m_panelListeEvenements
            // 
            this.m_panelListeEvenements.AllowArbre = true;
            this.m_panelListeEvenements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
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
            glColumn1.Width = 350;
            this.m_panelListeEvenements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeEvenements.ContexteUtilisation = "";
            this.m_panelListeEvenements.ControlFiltreStandard = null;
            this.m_panelListeEvenements.ElementSelectionne = null;
            this.m_panelListeEvenements.EnableCustomisation = true;
            this.m_panelListeEvenements.FiltreDeBase = null;
            this.m_panelListeEvenements.FiltreDeBaseEnAjout = false;
            this.m_panelListeEvenements.FiltrePrefere = null;
            this.m_panelListeEvenements.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_panelListeEvenements, "");
            this.m_panelListeEvenements.ListeObjets = null;
            this.m_panelListeEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeEvenements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeEvenements.ModeQuickSearch = false;
            this.m_panelListeEvenements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeEvenements, "");
            this.m_panelListeEvenements.MultiSelect = false;
            this.m_panelListeEvenements.Name = "m_panelListeEvenements";
            this.m_panelListeEvenements.Navigateur = null;
            this.m_panelListeEvenements.ProprieteObjetAEditer = null;
            this.m_panelListeEvenements.QuickSearchText = "";
            this.m_panelListeEvenements.Size = new System.Drawing.Size(798, 401);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeEvenements.TabIndex = 1;
            this.m_panelListeEvenements.TrierAuClicSurEnteteColonne = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_btnExecuter);
            this.tabPage1.Controls.Add(this.m_panelListeActions);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(798, 389);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Actions|169";
            // 
            // m_btnExecuter
            // 
            this.m_extLinkField.SetLinkField(this.m_btnExecuter, "");
            this.m_btnExecuter.Location = new System.Drawing.Point(288, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnExecuter, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnExecuter, "");
            this.m_btnExecuter.Name = "m_btnExecuter";
            this.m_btnExecuter.Size = new System.Drawing.Size(168, 16);
            this.m_extStyle.SetStyleBackColor(this.m_btnExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnExecuter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnExecuter.TabIndex = 3;
            this.m_btnExecuter.TabStop = true;
            this.m_btnExecuter.Text = "Execute selected action|30219";
            this.m_btnExecuter.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.m_btnExecuter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_btnExecuter_LinkClicked);
            // 
            // m_panelListeActions
            // 
            this.m_panelListeActions.AllowArbre = true;
            this.m_panelListeActions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text  = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 350;
            this.m_panelListeActions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelListeActions.ContexteUtilisation = "";
            this.m_panelListeActions.ControlFiltreStandard = null;
            this.m_panelListeActions.ElementSelectionne = null;
            this.m_panelListeActions.EnableCustomisation = true;
            this.m_panelListeActions.FiltreDeBase = null;
            this.m_panelListeActions.FiltreDeBaseEnAjout = false;
            this.m_panelListeActions.FiltrePrefere = null;
            this.m_panelListeActions.FiltreRapide = null;
            this.m_extLinkField.SetLinkField(this.m_panelListeActions, "");
            this.m_panelListeActions.ListeObjets = null;
            this.m_panelListeActions.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeActions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeActions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelListeActions.ModeQuickSearch = false;
            this.m_panelListeActions.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeActions, "");
            this.m_panelListeActions.MultiSelect = false;
            this.m_panelListeActions.Name = "m_panelListeActions";
            this.m_panelListeActions.Navigateur = null;
            this.m_panelListeActions.ProprieteObjetAEditer = null;
            this.m_panelListeActions.QuickSearchText = "";
            this.m_panelListeActions.Size = new System.Drawing.Size(798, 390);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeActions.TabIndex = 0;
            this.m_panelListeActions.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeActions.Load += new System.EventHandler(this.m_panelListeActions_Load);
            // 
            // CFormEditionGroupeParametrage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionGroupeParametrage";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CGroupeParametrage GroupeParametrage
		{
			get
			{
				return (CGroupeParametrage)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Settings group|30219") + GroupeParametrage.Libelle);

			m_panelListeActions.InitFromListeObjets (
				GroupeParametrage.Actions,
				typeof ( CProcessInDb ),
				typeof ( CFormEditionProcess ),
				GroupeParametrage,
				"GroupeParametrage");

			m_panelListeEvenements.InitFromListeObjets ( 
				GroupeParametrage.Evenements,
				typeof ( CEvenement ),
				typeof ( CFormEditionEvenement ),
				GroupeParametrage,
				"GroupeParametrage");
			return result;
		}

		private void m_panelListeActions_Load(object sender, System.EventArgs e)
		{
		
		}

		private void m_btnExecuter_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			if ( m_panelListeActions.ElementSelectionne != null )
			{
				CProcessInDb process = (CProcessInDb)m_panelListeActions.ElementSelectionne;
				if ( CFormAlerte.Afficher(I.T("Execute the action '@1'?|990",process.Libelle),EFormAlerteType.Question)
					== DialogResult.Yes )
				{
					CResultAErreur result = CFormExecuteProcess.StartProcess ( 
						process.Process,
						null,
						process.ContexteDonnee.IdSession,
						process.ContexteDonnee.IdVersionDeTravail,
						false);
					if ( !result )
					{
						CFormAlerte.Afficher ( result.Erreur );
					}
					else
						CFormAlerte.Afficher(I.T("Execution finished|991"));
				}
			}
		}
		//-------------------------------------------------------------------------
	}
}

