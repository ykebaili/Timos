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

using timos.data;

using timos.securite;
namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CFamilleEquipementLogique))]
	public class CFormEditionFamilleEquipementLogique : CFormEditionStdTimos, IFormNavigable
	{

		#region Designer generated code

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panelTop;
		private CArbreObjetHierarchique m_arbreHierarchie;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageEntitesFilles;
		private CPanelListeSpeedStandard m_panelFilles;
		private Label label3;
        private Label label4;
		private Crownwood.Magic.Controls.TabPage m_pageDefinissionFiches;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private System.ComponentModel.IContainer components = null;

	
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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionFamilleEquipementLogique));
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.m_panelTop = new sc2i.win32.common.C2iPanelOmbre();
			this.m_arbreHierarchie = new timos.CArbreObjetHierarchique();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pageDefinissionFiches = new Crownwood.Magic.Controls.TabPage();
			this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
			this.m_pageEntitesFilles = new Crownwood.Magic.Controls.TabPage();
			this.m_panelFilles = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.m_panelCle.SuspendLayout();
			this.m_panelMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
			this.m_panelTop.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_pageDefinissionFiches.SuspendLayout();
			this.m_pageEntitesFilles.SuspendLayout();
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
			this.m_panelNavigation.Location = new System.Drawing.Point(724, 0);
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
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(278, 11);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label1, "");
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 17);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Label|50";
			// 
			// m_txtLibelle
			// 
			this.m_txtLibelle.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(372, 8);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(317, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// m_panelTop
			// 
			this.m_panelTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelTop.Controls.Add(this.m_txtLibelle);
			this.m_panelTop.Controls.Add(this.label4);
			this.m_panelTop.Controls.Add(this.label3);
			this.m_panelTop.Controls.Add(this.label1);
			this.m_panelTop.Controls.Add(this.m_arbreHierarchie);
			this.m_panelTop.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panelTop, "");
			this.m_panelTop.Location = new System.Drawing.Point(8, 52);
			this.m_panelTop.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_panelTop, "");
			this.m_panelTop.Name = "m_panelTop";
			this.m_panelTop.Size = new System.Drawing.Size(822, 116);
			this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelTop.TabIndex = 0;
			// 
			// m_arbreHierarchie
			// 
			this.m_arbreHierarchie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_arbreHierarchie.AutoriseReaffectation = true;
			this.m_arbreHierarchie.BackColor = System.Drawing.Color.White;
			this.m_extLinkField.SetLinkField(this.m_arbreHierarchie, "");
			this.m_arbreHierarchie.Location = new System.Drawing.Point(4, 8);
			this.m_arbreHierarchie.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreHierarchie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_extModulesAssociator.SetModules(this.m_arbreHierarchie, "");
			this.m_arbreHierarchie.Name = "m_arbreHierarchie";
			this.m_arbreHierarchie.Size = new System.Drawing.Size(261, 87);
			this.m_extStyle.SetStyleBackColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_arbreHierarchie.TabIndex = 4003;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.m_extLinkField.SetLinkField(this.label4, "CodeSystemeComplet");
			this.label4.Location = new System.Drawing.Point(373, 34);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label4, "");
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(295, 15);
			this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 4007;
			this.label4.Text = "[CodeSystemeComplet]";
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(278, 33);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.label3, "");
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 15);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4006;
			this.label3.Text = "System code|121";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_tabControl
			// 
			this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_tabControl.Appearance = Crownwood.Magic.Controls.TabControl.VisualAppearance.MultiDocument;
			this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_tabControl.ControlBottomOffset = 16;
			this.m_tabControl.ControlRightOffset = 16;
			this.m_tabControl.ForeColor = System.Drawing.Color.Black;
			this.m_tabControl.IDEPixelArea = false;
			this.m_tabControl.IDEPixelBorder = false;
			this.m_extLinkField.SetLinkField(this.m_tabControl, "");
			this.m_tabControl.Location = new System.Drawing.Point(8, 174);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageEntitesFilles;
			this.m_tabControl.Size = new System.Drawing.Size(822, 344);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
			this.m_tabControl.TabIndex = 4004;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageEntitesFilles,
            this.m_pageDefinissionFiches});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_pageDefinissionFiches
			// 
			this.m_pageDefinissionFiches.Controls.Add(this.m_panelDefinisseurChamps);
			this.m_extLinkField.SetLinkField(this.m_pageDefinissionFiches, "");
			this.m_pageDefinissionFiches.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDefinissionFiches, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageDefinissionFiches, "");
			this.m_pageDefinissionFiches.Name = "m_pageDefinissionFiches";
			this.m_pageDefinissionFiches.Selected = false;
			this.m_pageDefinissionFiches.Size = new System.Drawing.Size(806, 303);
			this.m_extStyle.SetStyleBackColor(this.m_pageDefinissionFiches, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageDefinissionFiches, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageDefinissionFiches.TabIndex = 12;
			this.m_pageDefinissionFiches.Title = "Custom Forms|99";
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
			this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(806, 303);
			this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelDefinisseurChamps.TabIndex = 1;
			// 
			// m_pageEntitesFilles
			// 
			this.m_pageEntitesFilles.Controls.Add(this.m_panelFilles);
			this.m_extLinkField.SetLinkField(this.m_pageEntitesFilles, "");
			this.m_pageEntitesFilles.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEntitesFilles, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this.m_pageEntitesFilles, "");
			this.m_pageEntitesFilles.Name = "m_pageEntitesFilles";
			this.m_pageEntitesFilles.Size = new System.Drawing.Size(806, 303);
			this.m_extStyle.SetStyleBackColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageEntitesFilles.TabIndex = 11;
			this.m_pageEntitesFilles.Title = "Child Families|120";
			// 
			// m_panelFilles
			// 
			this.m_panelFilles.AllowArbre = true;
			this.m_panelFilles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
			glColumn2.BackColor = System.Drawing.Color.Transparent;
			glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn2.ForColor = System.Drawing.Color.Black;
			glColumn2.ImageIndex = -1;
			glColumn2.IsCheckColumn = false;
			glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn2.Name = "";
			glColumn2.Propriete = "Libelle";
			glColumn2.Text = "Label|50";
			glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn2.Width = 350;
			this.m_panelFilles.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
			this.m_panelFilles.ContexteUtilisation = "";
			this.m_panelFilles.ControlFiltreStandard = null;
			this.m_panelFilles.ElementSelectionne = null;
			this.m_panelFilles.EnableCustomisation = true;
			this.m_panelFilles.FiltreDeBase = null;
			this.m_panelFilles.FiltreDeBaseEnAjout = false;
			this.m_panelFilles.FiltrePrefere = null;
			this.m_panelFilles.FiltreRapide = null;
			this.m_extLinkField.SetLinkField(this.m_panelFilles, "");
			this.m_panelFilles.ListeObjets = null;
			this.m_panelFilles.Location = new System.Drawing.Point(0, 0);
			this.m_panelFilles.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFilles, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_panelFilles.ModeQuickSearch = false;
			this.m_panelFilles.ModeSelection = false;
			this.m_extModulesAssociator.SetModules(this.m_panelFilles, "");
			this.m_panelFilles.MultiSelect = false;
			this.m_panelFilles.Name = "m_panelFilles";
			this.m_panelFilles.Navigateur = null;
			this.m_panelFilles.ProprieteObjetAEditer = null;
			this.m_panelFilles.QuickSearchText = "";
			this.m_panelFilles.Size = new System.Drawing.Size(803, 316);
			this.m_extStyle.SetStyleBackColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelFilles.TabIndex = 0;
			this.m_panelFilles.TrierAuClicSurEnteteColonne = true;
			// 
			// CFormEditionFamilleEquipementLogique
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_tabControl);
			this.Controls.Add(this.m_panelTop);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_extModulesAssociator.SetModules(this, "");
			this.Name = "CFormEditionFamilleEquipementLogique";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.TabControl = this.m_tabControl;
			this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionFamilleEquipementLogique_OnInitPage);
			this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionFamilleEquipementLogique_OnMajChampsPage);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.m_panelTop, 0);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.m_panelCle.ResumeLayout(false);
			this.m_panelCle.PerformLayout();
			this.m_panelMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
			this.m_panelTop.ResumeLayout(false);
			this.m_panelTop.PerformLayout();
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pageDefinissionFiches.ResumeLayout(false);
			this.m_pageEntitesFilles.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public CFormEditionFamilleEquipementLogique()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionFamilleEquipementLogique(CFamilleEquipementLogique famille)
			: base(famille)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionFamilleEquipementLogique(CFamilleEquipementLogique famille, CListeObjetsDonnees liste)
			: base(famille, liste)
		{
			InitializeComponent();
		}


		//-------------------------------------------------------------------------
		private CFamilleEquipementLogique Famille
		{
			get
			{
				return (CFamilleEquipementLogique)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private CFamilleEquipementLogique m_lastParent = null;
		protected override CResultAErreur InitChamps()
		{
			if (Famille.IsNew() &&
				Famille.FamilleParente == null)
				Famille.FamilleParente = m_lastParent;
			m_lastParent = Famille.FamilleParente;

			m_arbreHierarchie.AfficheHierarchie(Famille);

			AffecterTitre(I.T("Logical equipment family|20045")+" " + Famille.Libelle);

			CResultAErreur result = base.InitChamps();

			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			return result;
		}

		private CResultAErreur CFormEditionFamilleEquipementLogique_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageDefinissionFiches)
				{
					m_panelDefinisseurChamps.InitPanel(
					Famille,
					typeof(CFormListeChampsCustom),
					typeof(CFormListeFormulaires));
				}
				else if (page == m_pageEntitesFilles)
				{
					m_panelFilles.InitFromListeObjets(
					Famille.FamillesFilles,
					typeof(CFamilleEquipementLogique),
					typeof(CFormEditionFamilleEquipementLogique),
					Famille,
					"FamilleParente");
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionFamilleEquipementLogique_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageEntitesFilles)
			{
			}
			else if (page == m_pageDefinissionFiches)
			{
				result = m_panelDefinisseurChamps.MAJ_Champs();
			}
			return result;
		}
	}
}

