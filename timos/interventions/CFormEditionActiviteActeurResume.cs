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

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CActiviteActeurResume))]
	public class CFormEditionActiviteActeurResume : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private Label label4;
		private Label m_lblDate;
		private Label label2;
		private Label label3;
		private Label label7;
		private CWndSaisieHeure m_wndSaisieHeure;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageActivite;
		private Crownwood.Magic.Controls.TabPage m_pageFiche;
		private CPanelListeSpeedStandard m_panelActivites;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private LinkLabel m_lnkDetail;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionActiviteActeurResume()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionActiviteActeurResume(CActiviteActeurResume ActiviteActeurResume)
			:base(ActiviteActeurResume)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionActiviteActeurResume(CActiviteActeurResume ActiviteActeurResume, CListeObjetsDonnees liste)
			:base(ActiviteActeurResume, liste)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionActiviteActeurResume));
			sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
			this.label1 = new System.Windows.Forms.Label();
			this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_lnkDetail = new System.Windows.Forms.LinkLabel();
			this.label4 = new System.Windows.Forms.Label();
			this.m_lblDate = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_wndSaisieHeure = new sc2i.win32.common.CWndSaisieHeure();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pageActivite = new Crownwood.Magic.Controls.TabPage();
			this.m_panelActivites = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
			this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
			this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
			this.m_panelMenu.SuspendLayout();
			this.c2iPanelOmbre4.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_pageActivite.SuspendLayout();
			this.m_pageFiche.SuspendLayout();
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
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			// 
			// label1
			// 
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(9, 12);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 13);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4002;
			this.label1.Text = "Member|20002";
			// 
			// c2iPanelOmbre4
			// 
			this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre4.Controls.Add(this.m_lnkDetail);
			this.c2iPanelOmbre4.Controls.Add(this.label1);
			this.c2iPanelOmbre4.Controls.Add(this.label4);
			this.c2iPanelOmbre4.Controls.Add(this.m_lblDate);
			this.c2iPanelOmbre4.Controls.Add(this.label2);
			this.c2iPanelOmbre4.Controls.Add(this.m_wndSaisieHeure);
			this.c2iPanelOmbre4.Controls.Add(this.label7);
			this.c2iPanelOmbre4.Controls.Add(this.label3);
			this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
			this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
			this.c2iPanelOmbre4.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
			this.c2iPanelOmbre4.Size = new System.Drawing.Size(643, 92);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre4.TabIndex = 0;
			// 
			// m_lnkDetail
			// 
			this.m_extLinkField.SetLinkField(this.m_lnkDetail, "");
			this.m_lnkDetail.Location = new System.Drawing.Point(218, 30);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetail, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_lnkDetail.Name = "m_lnkDetail";
			this.m_lnkDetail.Size = new System.Drawing.Size(222, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lnkDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lnkDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lnkDetail.TabIndex = 4005;
			this.m_lnkDetail.TabStop = true;
			this.m_lnkDetail.Text = "Edit detail|20008";
			this.m_lnkDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDetail_LinkClicked);
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_extLinkField.SetLinkField(this.label4, "Acteur.IdentiteComplete");
			this.label4.Location = new System.Drawing.Point(112, 8);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(497, 16);
			this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 4003;
			this.label4.Text = "[Acteur.IdentiteComplete]";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_lblDate
			// 
			this.m_lblDate.BackColor = System.Drawing.Color.White;
			this.m_lblDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_extLinkField.SetLinkField(this.m_lblDate, "");
			this.m_lblDate.Location = new System.Drawing.Point(112, 30);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblDate, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_lblDate.Name = "m_lblDate";
			this.m_lblDate.Size = new System.Drawing.Size(130, 16);
			this.m_extStyle.SetStyleBackColor(this.m_lblDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_lblDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblDate.TabIndex = 4003;
			this.m_lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(9, 32);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 13);
			this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 4002;
			this.label2.Text = "Date|20003";
			// 
			// m_wndSaisieHeure
			// 
			this.m_extLinkField.SetLinkField(this.m_wndSaisieHeure, "");
			this.m_wndSaisieHeure.Location = new System.Drawing.Point(112, 49);
			this.m_wndSaisieHeure.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndSaisieHeure, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_wndSaisieHeure.Name = "m_wndSaisieHeure";
			this.m_wndSaisieHeure.NullAutorise = true;
			this.m_wndSaisieHeure.SaisieDuree = true;
			this.m_wndSaisieHeure.Size = new System.Drawing.Size(40, 16);
			this.m_extStyle.SetStyleBackColor(this.m_wndSaisieHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_wndSaisieHeure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_wndSaisieHeure.TabIndex = 4004;
			this.m_wndSaisieHeure.ValeurHeure = 1.2;
			// 
			// label7
			// 
			this.m_extLinkField.SetLinkField(this.label7, "");
			this.label7.Location = new System.Drawing.Point(158, 52);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(97, 13);
			this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label7.TabIndex = 4002;
			this.label7.Text = "Hours|20005";
			// 
			// label3
			// 
			this.m_extLinkField.SetLinkField(this.label3, "");
			this.label3.Location = new System.Drawing.Point(9, 52);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 13);
			this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label3.TabIndex = 4002;
			this.label3.Text = "Duration|20004";
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
			this.m_tabControl.Location = new System.Drawing.Point(8, 147);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.PositionTop = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageActivite;
			this.m_tabControl.Size = new System.Drawing.Size(822, 382);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_tabControl.TabIndex = 4004;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageActivite,
            this.m_pageFiche});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_pageActivite
			// 
			this.m_pageActivite.Controls.Add(this.m_panelActivites);
			this.m_extLinkField.SetLinkField(this.m_pageActivite, "");
			this.m_pageActivite.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageActivite, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageActivite.Name = "m_pageActivite";
			this.m_pageActivite.Size = new System.Drawing.Size(806, 341);
			this.m_extStyle.SetStyleBackColor(this.m_pageActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageActivite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageActivite.TabIndex = 10;
			this.m_pageActivite.Title = "Activities|20006";
			// 
			// m_panelActivites
			// 
			this.m_panelActivites.AllowArbre = true;
			this.m_panelActivites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelActivites.BoutonAjouterVisible = false;
			this.m_panelActivites.BoutonModifierVisible = false;
			this.m_panelActivites.BoutonSupprimerVisible = false;
			glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
			glColumn1.BackColor = System.Drawing.Color.Transparent;
			glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn1.ForColor = System.Drawing.Color.Black;
			glColumn1.ImageIndex = -1;
			glColumn1.IsCheckColumn = false;
			glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn1.Name = "Name";
			glColumn1.Propriete = "TypeActiviteActeur.Libelle";
			glColumn1.Text = "Activity|20007";
			glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn1.Width = 250;
			glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
			glColumn2.BackColor = System.Drawing.Color.Transparent;
			glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
			glColumn2.ForColor = System.Drawing.Color.Black;
			glColumn2.ImageIndex = -1;
			glColumn2.IsCheckColumn = false;
			glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
			glColumn2.Name = "Namex";
			glColumn2.Propriete = "Duree";
			glColumn2.Text = "Duration|20004";
			glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
			glColumn2.Width = 100;
			this.m_panelActivites.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
			this.m_panelActivites.ContexteUtilisation = "";
			this.m_panelActivites.ControlFiltreStandard = null;
			this.m_panelActivites.ElementSelectionne = null;
			this.m_panelActivites.EnableCustomisation = true;
			this.m_panelActivites.FiltreDeBase = null;
			this.m_panelActivites.FiltreDeBaseEnAjout = false;
			this.m_panelActivites.FiltrePrefere = null;
			this.m_panelActivites.FiltreRapide = null;
			this.m_extLinkField.SetLinkField(this.m_panelActivites, "");
			this.m_panelActivites.ListeObjets = null;
			this.m_panelActivites.Location = new System.Drawing.Point(1, 2);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelActivites, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
			this.m_panelActivites.ModeQuickSearch = false;
			this.m_panelActivites.ModeSelection = false;
			this.m_panelActivites.MultiSelect = false;
			this.m_panelActivites.Name = "m_panelActivites";
			this.m_panelActivites.Navigateur = null;
			this.m_panelActivites.ProprieteObjetAEditer = null;
			this.m_panelActivites.QuickSearchText = "";
			this.m_panelActivites.Size = new System.Drawing.Size(804, 336);
			this.m_extStyle.SetStyleBackColor(this.m_panelActivites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelActivites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelActivites.TabIndex = 2;
			// 
			// m_pageFiche
			// 
			this.m_pageFiche.Controls.Add(this.m_panelChamps);
			this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
			this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageFiche.Name = "m_pageFiche";
			this.m_pageFiche.Selected = false;
			this.m_pageFiche.Size = new System.Drawing.Size(806, 341);
			this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageFiche.TabIndex = 11;
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
			this.m_panelChamps.Name = "m_panelChamps";
			this.m_panelChamps.Ombre = false;
			this.m_panelChamps.PositionTop = true;
			this.m_panelChamps.Size = new System.Drawing.Size(806, 341);
			this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelChamps.TabIndex = 1;
			// 
			// CFormEditionActiviteActeurResume
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BoutonAjouterVisible = false;
			this.BoutonSupprimerVisible = false;
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_tabControl);
			this.Controls.Add(this.c2iPanelOmbre4);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionActiviteActeurResume";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.TabControl = this.m_tabControl;
			this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionActiviteActeurResume_OnInitPage);
			this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionActiviteActeurResume_OnMajChampsPage);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.m_panelMenu.ResumeLayout(false);
			this.c2iPanelOmbre4.ResumeLayout(false);
			this.c2iPanelOmbre4.PerformLayout();
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pageActivite.ResumeLayout(false);
			this.m_pageFiche.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CActiviteActeurResume ActiviteActeurResume
		{
			get
			{
				return (CActiviteActeurResume)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			m_lblDate.Text = ActiviteActeurResume.Date.Date.ToShortDateString();
			AffecterTitre(I.T( "Member activity (summary)|20001") + ActiviteActeurResume.Acteur.IdentiteComplete);
			m_wndSaisieHeure.ValeurHeure = ActiviteActeurResume.Duree;
			return result;
		}
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

		//-------------------------------------------------------------------------
		private CResultAErreur CFormEditionActiviteActeurResume_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageActivite)
			{
				m_panelActivites.InitFromListeObjets(
					ActiviteActeurResume.Activites,
					typeof(CActiviteActeur),
					null,
					ActiviteActeurResume,
					"ResumeActivite");
			}
			else if (page == m_pageFiche)
				m_panelChamps.ElementEdite = ActiviteActeurResume;
			return result;

		}

		private CResultAErreur CFormEditionActiviteActeurResume_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_panelChamps)
				result = m_panelChamps.MAJ_Champs();
			return result;
		}

		private void m_lnkDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormEditionActiviteActeur form = new CFormEditionActiviteActeur(ActiviteActeurResume.Acteur);
			form.DateDebut = ActiviteActeurResume.Date;
			form.DateFin = ActiviteActeurResume.Date.AddDays(1).AddMinutes(-1);
			CTimosApp.Navigateur.AffichePage(form);
		}
	}
}

