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

using timos.acteurs;
using timos.data;

using timos.securite;
namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEntiteOrganisationnelle))]
	public class CFormEditionEntiteOrganisationnelle : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panelTop;
		private CArbreObjetHierarchique m_arbreHierarchie;
		private Label label2;
		private CComboBoxLinkListeObjetsDonnees m_cmbTypeEntite;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageFiche;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private Crownwood.Magic.Controls.TabPage m_pageEntitesFilles;
		private CPanelListeSpeedStandard m_panelFilles;
		private Label label3;
		private Label label4;
		private ToolTip m_ttCoor;
		private Panel m_panelCoordonnee;
		private timos.coordonnees.CControlEditeCoordonnee m_editCoordonnee;
		private Label label5;
		private CReducteurControle m_reducteurTop;
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
			sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionEntiteOrganisationnelle));
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
			this.m_panelTop = new sc2i.win32.common.C2iPanelOmbre();
			this.m_arbreHierarchie = new CArbreObjetHierarchique();
			this.m_panelCoordonnee = new System.Windows.Forms.Panel();
			this.m_editCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
			this.label5 = new System.Windows.Forms.Label();
			this.m_cmbTypeEntite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
			this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
			this.m_pageEntitesFilles = new Crownwood.Magic.Controls.TabPage();
			this.m_panelFilles = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.m_ttCoor = new System.Windows.Forms.ToolTip(this.components);
			this.m_reducteurTop = new sc2i.win32.common.CReducteurControle();
			this.m_panelTop.SuspendLayout();
			this.m_panelCoordonnee.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_pageFiche.SuspendLayout();
			this.m_pageEntitesFilles.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// label1
			// 
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(3, 101);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 15);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Label|50";
			// 
			// m_txtLibelle
			// 
			this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
			this.m_txtLibelle.Location = new System.Drawing.Point(96, 98);
			this.m_txtLibelle.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtLibelle.Name = "m_txtLibelle";
			this.m_txtLibelle.Size = new System.Drawing.Size(392, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtLibelle.TabIndex = 0;
			this.m_txtLibelle.Text = "[Label]|30324";
			// 
			// m_panelTop
			// 
			this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelTop.Controls.Add(this.m_arbreHierarchie);
			this.m_panelTop.Controls.Add(this.m_txtLibelle);
			this.m_panelTop.Controls.Add(this.label1);
			this.m_panelTop.Controls.Add(this.m_panelCoordonnee);
			this.m_panelTop.Controls.Add(this.m_cmbTypeEntite);
			this.m_panelTop.Controls.Add(this.label2);
			this.m_panelTop.Controls.Add(this.label4);
			this.m_panelTop.Controls.Add(this.label3);
			this.m_panelTop.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.m_panelTop, "");
			this.m_panelTop.Location = new System.Drawing.Point(8, 52);
			this.m_panelTop.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelTop.Name = "m_panelTop";
			this.m_panelTop.Size = new System.Drawing.Size(656, 187);
			this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelTop.TabIndex = 0;
			// 
			// m_arbreHierarchie
			// 
			this.m_arbreHierarchie.AutoriseReaffectation = true;
			this.m_arbreHierarchie.BackColor = System.Drawing.Color.White;
			this.m_extLinkField.SetLinkField(this.m_arbreHierarchie, "");
			this.m_arbreHierarchie.Location = new System.Drawing.Point(4, 5);
			this.m_arbreHierarchie.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreHierarchie, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_arbreHierarchie.Name = "m_arbreHierarchie";
			this.m_arbreHierarchie.Size = new System.Drawing.Size(628, 87);
			this.m_extStyle.SetStyleBackColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_arbreHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_arbreHierarchie.TabIndex = 4003;
			// 
			// m_panelCoordonnee
			// 
			this.m_panelCoordonnee.Controls.Add(this.m_editCoordonnee);
			this.m_panelCoordonnee.Controls.Add(this.label5);
			this.m_extLinkField.SetLinkField(this.m_panelCoordonnee, "");
			this.m_panelCoordonnee.Location = new System.Drawing.Point(6, 143);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCoordonnee, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_panelCoordonnee.Name = "m_panelCoordonnee";
			this.m_panelCoordonnee.Size = new System.Drawing.Size(493, 24);
			this.m_extStyle.SetStyleBackColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelCoordonnee.TabIndex = 4014;
			// 
			// m_editCoordonnee
			// 
			this.m_editCoordonnee.Coordonnee = "";
			this.m_extLinkField.SetLinkField(this.m_editCoordonnee, "");
			this.m_editCoordonnee.Location = new System.Drawing.Point(90, 2);
			this.m_editCoordonnee.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_editCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_editCoordonnee.Name = "m_editCoordonnee";
			this.m_editCoordonnee.Size = new System.Drawing.Size(392, 21);
			this.m_extStyle.SetStyleBackColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_editCoordonnee.TabIndex = 0;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.label5, "");
			this.label5.Location = new System.Drawing.Point(2, 4);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(82, 18);
			this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
			this.label5.TabIndex = 4006;
			this.label5.Text = "Coordinate|446";
			// 
			// m_cmbTypeEntite
			// 
			this.m_cmbTypeEntite.ComportementLinkStd = true;
			this.m_cmbTypeEntite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbTypeEntite.ElementSelectionne = null;
			this.m_cmbTypeEntite.FormattingEnabled = true;
			this.m_cmbTypeEntite.IsLink = true;
			this.m_extLinkField.SetLinkField(this.m_cmbTypeEntite, "");
			this.m_cmbTypeEntite.LinkProperty = "";
			this.m_cmbTypeEntite.ListDonnees = null;
			this.m_cmbTypeEntite.Location = new System.Drawing.Point(96, 120);
			this.m_cmbTypeEntite.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeEntite, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_cmbTypeEntite.Name = "m_cmbTypeEntite";
			this.m_cmbTypeEntite.NullAutorise = false;
			this.m_cmbTypeEntite.ProprieteAffichee = null;
			this.m_cmbTypeEntite.ProprieteParentListeObjets = null;
			this.m_cmbTypeEntite.SelectionneurParent = null;
			this.m_cmbTypeEntite.Size = new System.Drawing.Size(392, 21);
			this.m_extStyle.SetStyleBackColor(this.m_cmbTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_cmbTypeEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbTypeEntite.TabIndex = 1;
			this.m_cmbTypeEntite.TextNull = I.T("(empty)|30195");
			this.m_cmbTypeEntite.Tri = true;
			this.m_cmbTypeEntite.TypeFormEdition = null;
			this.m_cmbTypeEntite.SelectedValueChanged += new System.EventHandler(this.m_cmbTypeEntite_SelectedValueChanged);
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(3, 123);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 13);
			this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 4004;
			this.label2.Text = "Entity type|118";
			// 
			// label4
			// 
			this.m_extLinkField.SetLinkField(this.label4, "CodeSystemeComplet");
			this.label4.Location = new System.Drawing.Point(568, 103);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 13);
			this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 4007;
			this.label4.Text = "[CodeSystemeComplet]";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(496, 103);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 15);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4006;
			this.label3.Text = "Code|121";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			this.m_tabControl.IDEPixelArea = true;
			this.m_tabControl.IDEPixelBorder = false;
			this.m_extLinkField.SetLinkField(this.m_tabControl, "");
			this.m_tabControl.Location = new System.Drawing.Point(8, 245);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageFiche;
			this.m_tabControl.Size = new System.Drawing.Size(822, 266);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
			this.m_tabControl.TabIndex = 4004;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiche,
            this.m_pageEntitesFilles});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_pageFiche
			// 
			this.m_pageFiche.Controls.Add(this.m_panelChamps);
			this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
			this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageFiche.Name = "m_pageFiche";
			this.m_pageFiche.Size = new System.Drawing.Size(806, 225);
			this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageFiche.TabIndex = 10;
			this.m_pageFiche.Title = "Form|60";
			// 
			// m_panelChamps
			// 
			this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panelChamps.BoldSelectedPage = true;
			this.m_panelChamps.ElementEdite = null;
			this.m_panelChamps.IDEPixelArea = false;
			this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
			this.m_panelChamps.Location = new System.Drawing.Point(2, 1);
			this.m_panelChamps.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelChamps.Name = "m_panelChamps";
			this.m_panelChamps.Ombre = false;
			this.m_panelChamps.PositionTop = true;
			this.m_panelChamps.Size = new System.Drawing.Size(804, 224);
			this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelChamps.TabIndex = 5;
			// 
			// m_pageEntitesFilles
			// 
			this.m_pageEntitesFilles.Controls.Add(this.m_panelFilles);
			this.m_extLinkField.SetLinkField(this.m_pageEntitesFilles, "");
			this.m_pageEntitesFilles.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEntitesFilles, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageEntitesFilles.Name = "m_pageEntitesFilles";
			this.m_pageEntitesFilles.Selected = false;
			this.m_pageEntitesFilles.Size = new System.Drawing.Size(806, 225);
			this.m_extStyle.SetStyleBackColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageEntitesFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageEntitesFilles.TabIndex = 11;
			this.m_pageEntitesFilles.Title = "Child entities|1168";
			// 
			// m_panelFilles
			// 
			this.m_panelFilles.AllowArbre = true;
			this.m_panelFilles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "";
			glColumn1.Propriete = "Libelle";
			glColumn1.Text = "Label|50";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 350;
			this.m_panelFilles.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
			this.m_panelFilles.ContexteUtilisation = "";
			this.m_panelFilles.ControlFiltreStandard = null;
			this.m_panelFilles.EnableCustomisation = true;
			this.m_panelFilles.FiltreDeBase = null;
			this.m_panelFilles.FiltreDeBaseEnAjout = false;
			this.m_panelFilles.FiltrePrefere = null;
			this.m_panelFilles.FiltreRapide = null;
			this.m_extLinkField.SetLinkField(this.m_panelFilles, "");
			this.m_panelFilles.ListeObjets = null;
			this.m_panelFilles.Location = new System.Drawing.Point(0, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFilles, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_panelFilles.ModeQuickSearch = false;
			this.m_panelFilles.ModeSelection = false;
			this.m_panelFilles.MultiSelect = false;
			this.m_panelFilles.Name = "m_panelFilles";
			this.m_panelFilles.Navigateur = null;
			this.m_panelFilles.ProprieteObjetAEditer = null;
			this.m_panelFilles.QuickSearchText = "";
			this.m_panelFilles.Size = new System.Drawing.Size(803, 238);
			this.m_extStyle.SetStyleBackColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelFilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelFilles.TabIndex = 0;
			// 
			// m_ttCoor
			// 
			this.m_ttCoor.IsBalloon = true;
			// 
			// m_reducteurTop
			// 
			this.m_reducteurTop.ControleAgrandit = this.m_tabControl;
			this.m_reducteurTop.ControleAVoir = this.m_txtLibelle;
			this.m_reducteurTop.ControleReduit = this.m_panelTop;
			this.m_extLinkField.SetLinkField(this.m_reducteurTop, "");
			this.m_reducteurTop.Location = new System.Drawing.Point(332, 48);
			this.m_reducteurTop.MargeControle = 16;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteurTop, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_reducteurTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
			this.m_reducteurTop.Name = "m_reducteurTop";
			this.m_reducteurTop.Size = new System.Drawing.Size(9, 8);
			this.m_extStyle.SetStyleBackColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_reducteurTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_reducteurTop.TabIndex = 4005;
			this.m_reducteurTop.TailleReduite = 32;
			// 
			// CFormEditionEntiteOrganisationnelle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_reducteurTop);
			this.Controls.Add(this.m_panelTop);
			this.Controls.Add(this.m_tabControl);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionEntiteOrganisationnelle";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.TabControl = this.m_tabControl;
			this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEntiteOrganisationnelle_OnInitPage);
			this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEntiteOrganisationnelle_OnMajChampsPage);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.m_panelTop, 0);
			this.Controls.SetChildIndex(this.m_reducteurTop, 0);
			this.m_panelTop.ResumeLayout(false);
			this.m_panelTop.PerformLayout();
			this.m_panelCoordonnee.ResumeLayout(false);
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pageFiche.ResumeLayout(false);
			this.m_pageEntitesFilles.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionEntiteOrganisationnelle()
			: base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEntiteOrganisationnelle(CEntiteOrganisationnelle EntiteOrganisationnelle)
			: base(EntiteOrganisationnelle)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEntiteOrganisationnelle(CEntiteOrganisationnelle EntiteOrganisationnelle, CListeObjetsDonnees liste)
			: base(EntiteOrganisationnelle, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		//---------------------------------------------------------------------------------------
		private CResultAErreur InitPanelsCoordonnees()
		{
			CResultAErreur result = CResultAErreur.True;

			if (EntiteOrganisationnelle.EntiteParente != null &&
				EntiteOrganisationnelle.EntiteParente.ParametrageCoordonneesApplique != null)
				m_panelCoordonnee.Visible = true;
			else
				m_panelCoordonnee.Visible = false;

			m_editCoordonnee.Init(EntiteOrganisationnelle.EntiteParente, EntiteOrganisationnelle);
			m_editCoordonnee.Coordonnee = EntiteOrganisationnelle.Coordonnee;

			return result;
		}


		//-------------------------------------------------------------------------
		private CEntiteOrganisationnelle EntiteOrganisationnelle
		{
			get
			{
				return (CEntiteOrganisationnelle)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private CEntiteOrganisationnelle m_lastParent = null;
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();

			if (EntiteOrganisationnelle.IsNew() &&
				EntiteOrganisationnelle.EntiteParente == null)
				EntiteOrganisationnelle.EntiteParente = m_lastParent;
			m_lastParent = EntiteOrganisationnelle.EntiteParente;

			m_arbreHierarchie.AfficheHierarchie(EntiteOrganisationnelle);

			InitComboTypeEntites( false );
			if (EntiteOrganisationnelle.EntiteParente == null &&
				EntiteOrganisationnelle.EntiteFilles.Count == 0)
			{
				m_cmbTypeEntite.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
			}
			else
				m_cmbTypeEntite.LockEdition = true;

			m_cmbTypeEntite.ElementSelectionne = EntiteOrganisationnelle.TypeEntite;

            if (EntiteOrganisationnelle.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Remove(m_pageFiche);
            }
            else    
            {
                if (!m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Insert(0,m_pageFiche);
            }

			AffecterTitre(I.T("Organizational Entity @1|117", EntiteOrganisationnelle.Libelle));

			result = InitPanelsCoordonnees();

			return result;
		}

		private string ExtraireCoorEntite(string coorComplete)
		{
			if (EntiteOrganisationnelle.CoordonneeParente != "")
				return coorComplete.Substring(EntiteOrganisationnelle.CoordonneeParente.Length + 1);
			else
				return coorComplete;
		}
		
		//-------------------------------------------------------------------------
		private void InitComboTypeEntites( bool bForcer )
		{
			CListeObjetsDonnees listeTypeEO = new CListeObjetsDonnees(EntiteOrganisationnelle.ContexteDonnee, typeof(CTypeEntiteOrganisationnelle));
			listeTypeEO.Filtre = new CFiltreData(CTypeEntiteOrganisationnelle.c_champNiveau + "=@1", 0);
			m_cmbTypeEntite.Init(
				listeTypeEO,
				"Libelle",
				typeof(CFormEditionTypeEntiteOrganisationnelle),
				bForcer);
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result =  base.MAJ_Champs();
			EntiteOrganisationnelle.Coordonnee = m_editCoordonnee.Coordonnee;
			if (!m_cmbTypeEntite.LockEdition)
				EntiteOrganisationnelle.TypeEntite = (CTypeEntiteOrganisationnelle)m_cmbTypeEntite.SelectedValue;

			return result;
		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeEntite_SelectedValueChanged(object sender, EventArgs e)
		{
			m_panelChamps.ElementEdite = EntiteOrganisationnelle;
		}

		private CResultAErreur CFormEditionEntiteOrganisationnelle_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageEntitesFilles)
				{
					m_panelFilles.InitFromListeObjets(
						EntiteOrganisationnelle.EntiteFilles,
						typeof(CEntiteOrganisationnelle),
						typeof(CFormEditionEntiteOrganisationnelle),
						EntiteOrganisationnelle,
						"EntiteParente");
				}
				else if (page == m_pageFiche)
				{
					m_panelChamps.ElementEdite = EntiteOrganisationnelle;

				}
			}
			return result;
		}

		private CResultAErreur CFormEditionEntiteOrganisationnelle_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageEntitesFilles)
			{
				
			}
			else if (page == m_pageFiche)
			{
				result = m_panelChamps.MAJ_Champs();
			}
			return result;
		}


	}
}

