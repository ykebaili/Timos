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
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CFamilleEquipement))]
	public class CFormEditionFamilleEquipement : CFormEditionStdTimos, IFormNavigable
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
		private Crownwood.Magic.Controls.TabPage m_pageEquipements;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelChampsTypeEquipement;
        private Crownwood.Magic.Controls.TabPage m_pageConsommables;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_paneChampsTypeConsommables;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionFamilleEquipement));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panelTop = new sc2i.win32.common.C2iPanelOmbre();
            this.label3 = new System.Windows.Forms.Label();
            this.m_arbreHierarchie = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.label4 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageConsommables = new Crownwood.Magic.Controls.TabPage();
            this.m_paneChampsTypeConsommables = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageEntitesFilles = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFilles = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageEquipements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChampsTypeEquipement = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageConsommables.SuspendLayout();
            this.m_pageEntitesFilles.SuspendLayout();
            this.m_pageEquipements.SuspendLayout();
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
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
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
            // m_extLinkField
            // 
            this.m_extLinkField.SourceTypeString = "timos.data.CFamilleEquipement";
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(8, 11);
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
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(102, 7);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(314, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTop.Controls.Add(this.m_txtLibelle);
            this.m_panelTop.Controls.Add(this.label1);
            this.m_panelTop.Controls.Add(this.label3);
            this.m_panelTop.Controls.Add(this.m_arbreHierarchie);
            this.m_panelTop.Controls.Add(this.label4);
            this.m_panelTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTop, false);
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
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(8, 36);
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
            // m_arbreHierarchie
            // 
            this.m_arbreHierarchie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbreHierarchie.AutoriseReaffectation = true;
            this.m_arbreHierarchie.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_arbreHierarchie, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_arbreHierarchie, false);
            this.m_arbreHierarchie.Location = new System.Drawing.Point(424, 7);
            this.m_arbreHierarchie.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreHierarchie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreHierarchie, "");
            this.m_arbreHierarchie.Name = "m_arbreHierarchie";
            this.m_arbreHierarchie.Size = new System.Drawing.Size(375, 87);
            this.m_extStyle.SetStyleBackColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreHierarchie.TabIndex = 4003;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_extLinkField.SetLinkField(this.label4, "CodeSystemeComplet");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, true);
            this.label4.Location = new System.Drawing.Point(103, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(313, 20);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4007;
            this.label4.Text = "[CodeSystemeComplet]";
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 174);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.SelectedIndex = 2;
            this.m_tabControl.SelectedTab = this.m_pageConsommables;
            this.m_tabControl.Size = new System.Drawing.Size(822, 344);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageEntitesFilles,
            this.m_pageEquipements,
            this.m_pageConsommables});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageConsommables
            // 
            this.m_pageConsommables.Controls.Add(this.m_paneChampsTypeConsommables);
            this.m_pageConsommables.Controls.Add(this.checkBox2);
            this.m_extLinkField.SetLinkField(this.m_pageConsommables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageConsommables, false);
            this.m_pageConsommables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageConsommables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageConsommables, "");
            this.m_pageConsommables.Name = "m_pageConsommables";
            this.m_pageConsommables.Size = new System.Drawing.Size(806, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageConsommables.TabIndex = 13;
            this.m_pageConsommables.Title = "Consumables types|20645";
            // 
            // m_paneChampsTypeConsommables
            // 
            this.m_paneChampsTypeConsommables.AvecAffectationDirecteDeChamps = false;
            this.m_paneChampsTypeConsommables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_paneChampsTypeConsommables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_paneChampsTypeConsommables, false);
            this.m_paneChampsTypeConsommables.Location = new System.Drawing.Point(0, 17);
            this.m_paneChampsTypeConsommables.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_paneChampsTypeConsommables, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_paneChampsTypeConsommables, "");
            this.m_paneChampsTypeConsommables.Name = "m_paneChampsTypeConsommables";
            this.m_paneChampsTypeConsommables.Size = new System.Drawing.Size(806, 286);
            this.m_extStyle.SetStyleBackColor(this.m_paneChampsTypeConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_paneChampsTypeConsommables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_paneChampsTypeConsommables.TabIndex = 2;
            // 
            // m_pageEntitesFilles
            // 
            this.m_pageEntitesFilles.Controls.Add(this.m_panelFilles);
            this.m_extLinkField.SetLinkField(this.m_pageEntitesFilles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEntitesFilles, false);
            this.m_pageEntitesFilles.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEntitesFilles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEntitesFilles, "");
            this.m_pageEntitesFilles.Name = "m_pageEntitesFilles";
            this.m_pageEntitesFilles.Selected = false;
            this.m_pageEntitesFilles.Size = new System.Drawing.Size(806, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEntitesFilles.TabIndex = 11;
            this.m_pageEntitesFilles.Title = "Child Families|120";
            // 
            // m_panelFilles
            // 
            this.m_panelFilles.AllowArbre = true;
            this.m_panelFilles.AllowCustomisation = true;
            this.m_panelFilles.AllowSerializePreferences = true;
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
            this.m_panelFilles.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelFilles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelFilles, false);
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
            this.m_panelFilles.ShortIcons = false;
            this.m_panelFilles.Size = new System.Drawing.Size(803, 316);
            this.m_extStyle.SetStyleBackColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFilles.TabIndex = 0;
            this.m_panelFilles.TrierAuClicSurEnteteColonne = true;
            this.m_panelFilles.UseCheckBoxes = false;
            // 
            // m_pageEquipements
            // 
            this.m_pageEquipements.Controls.Add(this.m_panelChampsTypeEquipement);
            this.m_pageEquipements.Controls.Add(this.checkBox1);
            this.m_extLinkField.SetLinkField(this.m_pageEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEquipements, false);
            this.m_pageEquipements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquipements, "");
            this.m_pageEquipements.Name = "m_pageEquipements";
            this.m_pageEquipements.Selected = false;
            this.m_pageEquipements.Size = new System.Drawing.Size(806, 303);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquipements.TabIndex = 12;
            this.m_pageEquipements.Title = "Equipment type|20644";
            // 
            // m_panelChampsTypeEquipement
            // 
            this.m_panelChampsTypeEquipement.AvecAffectationDirecteDeChamps = false;
            this.m_panelChampsTypeEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelChampsTypeEquipement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChampsTypeEquipement, false);
            this.m_panelChampsTypeEquipement.Location = new System.Drawing.Point(0, 17);
            this.m_panelChampsTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChampsTypeEquipement, "");
            this.m_panelChampsTypeEquipement.Name = "m_panelChampsTypeEquipement";
            this.m_panelChampsTypeEquipement.Size = new System.Drawing.Size(806, 286);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChampsTypeEquipement.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.checkBox1, "PasDEquipement");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(806, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Dont use this familly for equipments|20677";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.checkBox2, "PasDeConsommable");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox2, true);
            this.checkBox2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(806, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Dont use this familly for consumables|20678";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // CFormEditionFamilleEquipement
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panelTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionFamilleEquipement";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionFamilleEquipement_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionFamilleEquipement_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panelTop, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageConsommables.ResumeLayout(false);
            this.m_pageConsommables.PerformLayout();
            this.m_pageEntitesFilles.ResumeLayout(false);
            this.m_pageEquipements.ResumeLayout(false);
            this.m_pageEquipements.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		public CFormEditionFamilleEquipement()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionFamilleEquipement(CFamilleEquipement famille)
			: base(famille)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionFamilleEquipement(CFamilleEquipement famille, CListeObjetsDonnees liste)
			: base(famille, liste)
		{
			InitializeComponent();
		}


		//-------------------------------------------------------------------------
		private CFamilleEquipement Famille
		{
			get
			{
				return (CFamilleEquipement)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private CFamilleEquipement m_lastParent = null;
		protected override CResultAErreur MyInitChamps()
		{
			if (Famille.IsNew() &&
				Famille.FamilleParente == null)
				Famille.FamilleParente = m_lastParent;
			m_lastParent = Famille.FamilleParente;

			m_arbreHierarchie.AfficheHierarchie(Famille);

			AffecterTitre(I.T("Equipment family|193")+" " + Famille.Libelle);

            CResultAErreur result = base.MyInitChamps();

			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();
			return result;
		}

		private CResultAErreur CFormEditionFamilleEquipement_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageEquipements)
				{
					m_panelChampsTypeEquipement.InitPanel(
					Famille.GetDefinisseurPourTypeEquipement(),
					typeof(CFormListeChampsCustom),
					typeof(CFormListeFormulaires));
				}
                else if (page == m_pageConsommables)
                {
                    m_paneChampsTypeConsommables.InitPanel(
                        Famille.GetDefinisseurPourTypeConsommable(),
                        typeof(CFormListeChampsCustom),
                        typeof(CFormListeFormulaires));
                }
                else if (page == m_pageEntitesFilles)
                {
                    m_panelFilles.InitFromListeObjets(
                    Famille.FamillesFilles,
                    typeof(CFamilleEquipement),
                    typeof(CFormEditionFamilleEquipement),
                    Famille,
                    "FamilleParente");
                }
			}
			return result;
		}

		private CResultAErreur CFormEditionFamilleEquipement_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageEntitesFilles)
			{
			}
			else if (page == m_pageEquipements)
			{
				result = m_panelChampsTypeEquipement.MAJ_Champs();
			}
            else if (page == m_pageConsommables)
            {
                result = m_paneChampsTypeConsommables.MAJ_Champs();
            }
			return result;
		}
	}
}

