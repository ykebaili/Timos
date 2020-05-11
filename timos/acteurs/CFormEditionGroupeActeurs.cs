using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using timos.acteurs;
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
using timos.securite;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CGroupeActeur))]
	public class CFormEditionGroupeActeurs : CFormEditionStdTimos, 
		IFormNavigable
	{
		#region Designer generated code

		private sc2i.win32.common.ListViewAutoFilled m_listViewRoles;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn5;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private System.Windows.Forms.Timer m_timerMAJOnglets;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageGroupes;
		private Crownwood.Magic.Controls.TabPage m_pageRoles;
		private Crownwood.Magic.Controls.TabPage m_pageChampsCustom;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelGroupesContenants;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn6;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private sc2i.win32.common.C2iTextBox m_txtNom;
		private System.Windows.Forms.CheckBox m_chkMasque;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private sc2i.win32.data.navigation.CPanelListeRelationSelection m_panelNecessitesGroupes;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn2;
		private System.Windows.Forms.Label label5;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeMembres;
		private System.Windows.Forms.LinkLabel m_btnApercuHierarchie;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private Label label9;
        private Crownwood.Magic.Controls.TabPage m_pageEOs;
        private CPanelAffectationEO m_panelEOS;
		private System.ComponentModel.IContainer components = null;


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
			this.m_timerMAJOnglets = new System.Windows.Forms.Timer(this.components);
			this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
			this.m_pageEOs = new Crownwood.Magic.Controls.TabPage();
			this.m_panelEOS = new timos.CPanelAffectationEO();
			this.m_pageGroupes = new Crownwood.Magic.Controls.TabPage();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_btnApercuHierarchie = new System.Windows.Forms.LinkLabel();
			this.label5 = new System.Windows.Forms.Label();
			this.m_wndListeMembres = new sc2i.win32.common.ListViewAutoFilled();
			this.listViewColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.label4 = new System.Windows.Forms.Label();
			this.m_panelNecessitesGroupes = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
			this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.m_panelGroupesContenants = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
			this.listViewColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.m_pageRoles = new Crownwood.Magic.Controls.TabPage();
			this.m_pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
			this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
			this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
			this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
			this.m_txtNom = new sc2i.win32.common.C2iTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.m_chkMasque = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_tabControl.SuspendLayout();
			this.m_pageEOs.SuspendLayout();
			this.m_pageGroupes.SuspendLayout();
			this.m_pageRoles.SuspendLayout();
			this.m_pageChampsCustom.SuspendLayout();
			this.c2iPanelOmbre1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_panelMenu
			// 
			this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
			this.m_listViewRoles.Name = "m_listViewRoles";
			this.m_listViewRoles.Size = new System.Drawing.Size(778, 362);
			this.m_extStyle.SetStyleBackColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_listViewRoles.TabIndex = 0;
			this.m_listViewRoles.UseCompatibleStateImageBehavior = false;
			this.m_listViewRoles.View = System.Windows.Forms.View.Details;
			this.m_listViewRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_listViewRoles_ItemCheck);
			// 
			// listViewColumn5
			// 
			this.listViewColumn5.Field = "Libelle";
			this.listViewColumn5.PrecisionWidth = 0;
			this.listViewColumn5.ProportionnalSize = false;
			this.listViewColumn5.Text = "Label|50";
			this.listViewColumn5.Visible = true;
			this.listViewColumn5.Width = 450;
			// 
			// m_timerMAJOnglets
			// 
			this.m_timerMAJOnglets.Interval = 300;
			this.m_timerMAJOnglets.Tick += new System.EventHandler(this.m_timerMAJOnglets_Tick);
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
			this.m_tabControl.Location = new System.Drawing.Point(16, 104);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.Ombre = true;
			this.m_tabControl.PositionTop = true;
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.SelectedTab = this.m_pageGroupes;
			this.m_tabControl.Size = new System.Drawing.Size(810, 418);
			this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_tabControl.TabIndex = 1;
			this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageGroupes,
            this.m_pageRoles,
            this.m_pageChampsCustom,
            this.m_pageEOs});
			this.m_tabControl.TextColor = System.Drawing.Color.Black;
			// 
			// m_pageEOs
			// 
			this.m_pageEOs.Controls.Add(this.m_panelEOS);
			this.m_extLinkField.SetLinkField(this.m_pageEOs, "");
			this.m_pageEOs.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOs, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageEOs.Name = "m_pageEOs";
			this.m_pageEOs.Selected = false;
			this.m_pageEOs.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageEOs.TabIndex = 10;
			this.m_pageEOs.Title = "Organizational Entities|53";
			// 
			// m_panelEOS
			// 
			this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
			this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
			this.m_panelEOS.LockEdition = true;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelEOS.Name = "m_panelEOS";
			this.m_panelEOS.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelEOS.TabIndex = 1;
			// 
			// m_pageGroupes
			// 
			this.m_pageGroupes.Controls.Add(this.label8);
			this.m_pageGroupes.Controls.Add(this.label7);
			this.m_pageGroupes.Controls.Add(this.label6);
			this.m_pageGroupes.Controls.Add(this.m_btnApercuHierarchie);
			this.m_pageGroupes.Controls.Add(this.label5);
			this.m_pageGroupes.Controls.Add(this.m_wndListeMembres);
			this.m_pageGroupes.Controls.Add(this.label4);
			this.m_pageGroupes.Controls.Add(this.m_panelNecessitesGroupes);
			this.m_pageGroupes.Controls.Add(this.label2);
			this.m_pageGroupes.Controls.Add(this.m_panelGroupesContenants);
			this.m_extLinkField.SetLinkField(this.m_pageGroupes, "");
			this.m_pageGroupes.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageGroupes, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageGroupes.Name = "m_pageGroupes";
			this.m_pageGroupes.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_pageGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageGroupes.TabIndex = 0;
			this.m_pageGroupes.Title = "Group membership|789";
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label8.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label8, "");
			this.label8.Location = new System.Drawing.Point(574, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(217, 16);
			this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label8.TabIndex = 13;
			this.label8.Text = "(Groups that inherit properties from this Group)|797";
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label7, "");
			this.label7.Location = new System.Drawing.Point(358, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(168, 16);
			this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label7.TabIndex = 12;
			this.label7.Text = "(Parents in visual hierarchy)|796";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label6, "");
			this.label6.Location = new System.Drawing.Point(8, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(183, 16);
			this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label6.TabIndex = 11;
			this.label6.Text = "(Inherit from following Groups)|795";
			// 
			// m_btnApercuHierarchie
			// 
			this.m_btnApercuHierarchie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_extLinkField.SetLinkField(this.m_btnApercuHierarchie, "");
			this.m_btnApercuHierarchie.Location = new System.Drawing.Point(383, 362);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnApercuHierarchie, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_btnApercuHierarchie.Name = "m_btnApercuHierarchie";
			this.m_btnApercuHierarchie.Size = new System.Drawing.Size(167, 16);
			this.m_extStyle.SetStyleBackColor(this.m_btnApercuHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnApercuHierarchie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnApercuHierarchie.TabIndex = 10;
			this.m_btnApercuHierarchie.TabStop = true;
			this.m_btnApercuHierarchie.Text = "Groups hierarchy|798";
			this.m_btnApercuHierarchie.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.m_btnApercuHierarchie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_btnApercuHierarchie_LinkClicked);
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label5, "");
			this.label5.Location = new System.Drawing.Point(574, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 16);
			this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label5.TabIndex = 9;
			this.label5.Text = "Members :|794";
			// 
			// m_wndListeMembres
			// 
			this.m_wndListeMembres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_wndListeMembres.BackColor = System.Drawing.Color.White;
			this.m_wndListeMembres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewColumn2});
			this.m_wndListeMembres.EnableCustomisation = true;
			this.m_wndListeMembres.ForeColor = System.Drawing.Color.Black;
			this.m_wndListeMembres.FullRowSelect = true;
			this.m_extLinkField.SetLinkField(this.m_wndListeMembres, "");
			this.m_wndListeMembres.Location = new System.Drawing.Point(574, 32);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeMembres, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_wndListeMembres.Name = "m_wndListeMembres";
			this.m_wndListeMembres.Size = new System.Drawing.Size(208, 330);
			this.m_extStyle.SetStyleBackColor(this.m_wndListeMembres, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
			this.m_extStyle.SetStyleForeColor(this.m_wndListeMembres, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
			this.m_wndListeMembres.TabIndex = 8;
			this.m_wndListeMembres.UseCompatibleStateImageBehavior = false;
			this.m_wndListeMembres.View = System.Windows.Forms.View.Details;
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
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label4, "");
			this.label4.Location = new System.Drawing.Point(358, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 16);
			this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label4.TabIndex = 7;
			this.label4.Text = "Parent Groups :|793";
			// 
			// m_panelNecessitesGroupes
			// 
			this.m_panelNecessitesGroupes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelNecessitesGroupes.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
			this.m_panelNecessitesGroupes.EnableCustomisation = true;
			this.m_panelNecessitesGroupes.ExclusionParException = false;
			this.m_extLinkField.SetLinkField(this.m_panelNecessitesGroupes, "");
			this.m_panelNecessitesGroupes.Location = new System.Drawing.Point(350, 24);
			this.m_panelNecessitesGroupes.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelNecessitesGroupes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelNecessitesGroupes.Name = "m_panelNecessitesGroupes";
			this.m_panelNecessitesGroupes.Size = new System.Drawing.Size(208, 346);
			this.m_extStyle.SetStyleBackColor(this.m_panelNecessitesGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelNecessitesGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelNecessitesGroupes.TabIndex = 6;
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
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_extLinkField.SetLinkField(this.label2, "");
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 16);
			this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 1;
			this.label2.Text = "Member of :|792";
			// 
			// m_panelGroupesContenants
			// 
			this.m_panelGroupesContenants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panelGroupesContenants.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewColumn6});
			this.m_panelGroupesContenants.EnableCustomisation = true;
			this.m_panelGroupesContenants.ExclusionParException = false;
			this.m_extLinkField.SetLinkField(this.m_panelGroupesContenants, "");
			this.m_panelGroupesContenants.Location = new System.Drawing.Point(0, 24);
			this.m_panelGroupesContenants.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelGroupesContenants, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelGroupesContenants.Name = "m_panelGroupesContenants";
			this.m_panelGroupesContenants.Size = new System.Drawing.Size(334, 346);
			this.m_extStyle.SetStyleBackColor(this.m_panelGroupesContenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelGroupesContenants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelGroupesContenants.TabIndex = 0;
			// 
			// listViewColumn6
			// 
			this.listViewColumn6.Field = "Nom";
			this.listViewColumn6.PrecisionWidth = 0;
			this.listViewColumn6.ProportionnalSize = false;
			this.listViewColumn6.Text = "Label|50";
			this.listViewColumn6.Visible = true;
			this.listViewColumn6.Width = 156;
			// 
			// m_pageRoles
			// 
			this.m_pageRoles.Controls.Add(this.m_listViewRoles);
			this.m_extLinkField.SetLinkField(this.m_pageRoles, "");
			this.m_pageRoles.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageRoles, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageRoles.Name = "m_pageRoles";
			this.m_pageRoles.Selected = false;
			this.m_pageRoles.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_pageRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageRoles.TabIndex = 1;
			this.m_pageRoles.Title = "Associated Roles|790";
			// 
			// m_pageChampsCustom
			// 
			this.m_pageChampsCustom.Controls.Add(this.m_panelDefinisseurChamps);
			this.m_extLinkField.SetLinkField(this.m_pageChampsCustom, "");
			this.m_pageChampsCustom.Location = new System.Drawing.Point(0, 25);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
			this.m_pageChampsCustom.Name = "m_pageChampsCustom";
			this.m_pageChampsCustom.Selected = false;
			this.m_pageChampsCustom.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_pageChampsCustom.TabIndex = 2;
			this.m_pageChampsCustom.Title = "Custom fields|791";
			// 
			// m_panelDefinisseurChamps
			// 
			this.m_panelDefinisseurChamps.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChamps, "");
			this.m_panelDefinisseurChamps.Location = new System.Drawing.Point(0, 0);
			this.m_panelDefinisseurChamps.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_panelDefinisseurChamps.Name = "m_panelDefinisseurChamps";
			this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(794, 377);
			this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelDefinisseurChamps.TabIndex = 0;
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
			// listViewAutoFilledColumn3
			// 
			this.listViewAutoFilledColumn3.Field = "Libelle";
			this.listViewAutoFilledColumn3.PrecisionWidth = 0;
			this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Label|50";
			this.listViewAutoFilledColumn3.Visible = true;
			this.listViewAutoFilledColumn3.Width = 200;
			// 
			// c2iPanelOmbre1
			// 
			this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.c2iPanelOmbre1.Controls.Add(this.m_txtNom);
			this.c2iPanelOmbre1.Controls.Add(this.label9);
			this.c2iPanelOmbre1.Controls.Add(this.m_chkMasque);
			this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
			this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
			this.c2iPanelOmbre1.Location = new System.Drawing.Point(16, 32);
			this.c2iPanelOmbre1.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
			this.c2iPanelOmbre1.Size = new System.Drawing.Size(600, 66);
			this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.c2iPanelOmbre1.TabIndex = 0;
			// 
			// m_txtNom
			// 
			this.m_extLinkField.SetLinkField(this.m_txtNom, "Nom");
			this.m_txtNom.Location = new System.Drawing.Point(80, 12);
			this.m_txtNom.LockEdition = false;
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_txtNom.Name = "m_txtNom";
			this.m_txtNom.Size = new System.Drawing.Size(328, 20);
			this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtNom.TabIndex = 4003;
			this.m_txtNom.Text = "[Name]|30301";
			// 
			// label9
			// 
			this.m_extLinkField.SetLinkField(this.label9, "");
			this.label9.Location = new System.Drawing.Point(7, 17);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(67, 15);
			this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label9.TabIndex = 4009;
			this.label9.Text = "Label|50";
			// 
			// m_chkMasque
			// 
			this.m_extLinkField.SetLinkField(this.m_chkMasque, "Masquer");
			this.m_chkMasque.Location = new System.Drawing.Point(424, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMasque, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
			this.m_chkMasque.Name = "m_chkMasque";
			this.m_chkMasque.Size = new System.Drawing.Size(126, 16);
			this.m_extStyle.SetStyleBackColor(this.m_chkMasque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_chkMasque, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_chkMasque.TabIndex = 4006;
			this.m_chkMasque.Text = "Hiden Group|788";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.m_extLinkField.SetLinkField(this.label1, "");
			this.label1.Location = new System.Drawing.Point(20, 16);
			this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(37, 16);
			this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label1.TabIndex = 4004;
			this.label1.Text = "Nom : ";
			// 
			// CFormEditionGroupeActeurs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(830, 530);
			this.Controls.Add(this.m_tabControl);
			this.Controls.Add(this.c2iPanelOmbre1);
			this.m_extLinkField.SetLinkField(this, "");
			this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
			this.Name = "CFormEditionGroupeActeurs";
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.TabControl = this.m_tabControl;
			this.Load += new System.EventHandler(this.CFormEditionGroupeActeurs_Load);
			this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionGroupeActeurs_OnInitPage);
			this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionGroupeActeurs_OnMajChampsPage);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormEditionGroupeActeurs_Closing);
			this.AfterPassageEnEdition += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionGroupeActeurs_AfterPassageEnEdition);
			this.Controls.SetChildIndex(this.m_panelMenu, 0);
			this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
			this.Controls.SetChildIndex(this.m_tabControl, 0);
			this.m_tabControl.ResumeLayout(false);
			this.m_tabControl.PerformLayout();
			this.m_pageEOs.ResumeLayout(false);
			this.m_pageGroupes.ResumeLayout(false);
			this.m_pageRoles.ResumeLayout(false);
			this.m_pageChampsCustom.ResumeLayout(false);
			this.c2iPanelOmbre1.ResumeLayout(false);
			this.c2iPanelOmbre1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion


		public CFormEditionGroupeActeurs()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeActeurs(CGroupeActeur groupe)
			:base(groupe)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionGroupeActeurs(CGroupeActeur groupe, CListeObjetsDonnees liste)
			:base(groupe, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		
		
		//-------------------------------------------------------------------------
		private CGroupeActeur GroupeActeur
		{
			get
			{
				return (CGroupeActeur)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionGroupeActeurs_Load(object sender, System.EventArgs e)
		{
			m_listViewRoles.ReadFromRegistre( new CSc2iWin32DataNavigationRegistre().GetKey("Preferences\\Panel_Listes\\" + this.GetType().Name + "_" + m_listViewRoles.Name, true));
		}
		//-------------------------------------------------------------------------
		private void CFormEditionGroupeActeurs_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_listViewRoles.WriteToRegistre( new CSc2iWin32DataNavigationRegistre().GetKey("Preferences\\Panel_Listes\\" + this.GetType().Name + "_" + m_listViewRoles.Name, true));
		}
		//-------------------------------------------------------------------------
		private void InitPanelChampsCustom()
		{
			
		}
		//-------------------------------------------------------------------------
		private void ReloadListeChampsCustom(object sender, CObjetDonneeEventArgs e)
		{
			/*//m_panelListeChampsCustom.EnEdition = this.EtatEdition;
			m_panelListeChampsCustom.ReloadForEdition( 
				((CGroupeActeur)ObjetEdite).RelationsChampsCustom,
				e.Objet.ContexteDonnee);
			m_panelListeFormulaires.ReloadForEdition(
				GroupeActeur.RelationsFormulaires,
				e.Objet.ContexteDonnee);*/
		}
		//-------------------------------------------------------------------------
		private void ApplyModifRoles()
		{
			Hashtable tableRoles = new Hashtable();
			foreach(CRelationRoleActeur_GroupeActeur rel in GroupeActeur.RelationsRoles)
				tableRoles[rel.RoleActeur] = rel;

			foreach(ListViewItem item in m_listViewRoles.Items)
			{
				CRoleActeur role = (CRoleActeur)item.Tag;
				if (item.Checked)
				{
					if (!tableRoles.ContainsKey(role))
					{
						CRelationRoleActeur_GroupeActeur relation = new CRelationRoleActeur_GroupeActeur(GroupeActeur.ContexteDonnee);
						relation.GroupeActeur = GroupeActeur;
						relation.RoleActeur = role;
					}
				}
				else
				{
					if (tableRoles.ContainsKey(role))	
					{
						CRelationRoleActeur_GroupeActeur relation = (CRelationRoleActeur_GroupeActeur) tableRoles[role];
						relation.Delete();
					}
				}
			}
		}

		//-------------------------------------------------------------------------
		private bool m_bIsInit = false;
		protected override CResultAErreur MyInitChamps()
		{
			m_bIsInit = false;
			AffecterTitre(I.T("Member Group @1|1291", ((CGroupeActeur)ObjetEdite).Nom));
            CResultAErreur result = base.MyInitChamps();
			m_bIsInit = true;
			return result;
		}

		

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			CResultAErreur result = base.MAJ_Champs();
			
			return result;
		}
		//-------------------------------------------------------------------------
		private void m_lnkNewChampCustom_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			CChampCustom champ = new CChampCustom(CSc2iWin32DataClient.ContexteCourant);
			champ.CreateNew();
			CFormEditionChampCustom frm = new CFormEditionChampCustom(champ);
			CSc2iWin32DataNavigation.Navigateur.AffichePage( frm );
		}
		//-------------------------------------------------------------------------
		private void m_listViewRoles_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			m_timerMAJOnglets.Enabled = true;
		}
		//-------------------------------------------------------------------------
		private void m_timerMAJOnglets_Tick(object sender, System.EventArgs e)
		{
			m_timerMAJOnglets.Enabled = false;
		}

		//-------------------------------------------------------------------------
		private void CFormEditionGroupeActeurs_AfterPassageEnEdition(object sender, sc2i.data.CObjetDonneeEventArgs args)
		{
			if ( m_bIsInit )
				m_panelGroupesContenants.ReloadForEdition (
					GroupeActeur.RelationsGroupesContenantsDirects,
					GroupeActeur.ContexteDonnee );
		}


		private void m_btnApercuHierarchie_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			timos.win32.composants.CFormVoirNecessiteGroupes.VoirNecessitesGroupes(typeof(CGroupeActeur));
		}


		private CResultAErreur CFormEditionGroupeActeurs_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageGroupes)
				{
					CListeObjetsDonnees liste = new CListeObjetsDonnees(GroupeActeur.ContexteDonnee, typeof(CGroupeActeur), false);
					//Le groupe ne doit pas dépendre d'un groupe dépendant de lui même !!
					int[] idsDependants = GroupeActeur.GetHierarchieGroupesContenus();
					if (idsDependants.Length > 0)
					{
						string strFiltre = "";
						foreach (int nId in idsDependants)
							strFiltre += nId.ToString() + ",";
						strFiltre = "(" + strFiltre.Substring(0, strFiltre.Length - 1) + ")";
						strFiltre = CGroupeActeur.c_champId + " not in " + strFiltre;
						liste.Filtre = new CFiltreData(strFiltre);
					}

					m_panelGroupesContenants.Init(
						liste,
						GroupeActeur.RelationsGroupesContenantsDirects,
						GroupeActeur,
						"GroupeContenu",
						"GroupeContenant");
					m_panelGroupesContenants.RemplirGrille();

					m_panelNecessitesGroupes.Init(
						liste,
						GroupeActeur.RelationsGroupesNecessaires,
						GroupeActeur,
						"GroupeNecessitant",
						"GroupeNecessaire");
					m_panelNecessitesGroupes.RemplirGrille();


					m_wndListeMembres.Remplir(GroupeActeur.RelationsGroupesContenusDirects);

				}
				else if (page == m_pageRoles)
				{
					m_listViewRoles.Remplir(CRoleActeur.Roles);
					m_listViewRoles.CheckBoxes = true;

					Hashtable tableRoles = new Hashtable();
					foreach (CRelationRoleActeur_GroupeActeur rel in GroupeActeur.RelationsRoles)
						if (rel.RoleActeur != null)
							tableRoles[rel.RoleActeur] = rel;

					foreach (ListViewItem item in m_listViewRoles.Items)
						if (tableRoles.ContainsKey((CRoleActeur)item.Tag))
							item.Checked = true;
				}
				else if (page == m_pageChampsCustom)
				{
					m_panelDefinisseurChamps.InitPanel
					(GroupeActeur,
					typeof(CFormListeChampsCustom),
					typeof(CFormListeFormulaires));
				}
				else if (page == m_pageEOs)
				{
					m_panelEOS.Init(GroupeActeur);
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionGroupeActeurs_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageGroupes)
			{
				m_panelGroupesContenants.ApplyModifs();
				m_panelNecessitesGroupes.ApplyModifs();
			}
			else if (page == m_pageRoles)
			{
				ApplyModifRoles();
			}
			else if (page == m_pageChampsCustom)
			{
				result = m_panelDefinisseurChamps.MAJ_Champs();
			}
			else if (page == m_pageEOs)
			{
				result = m_panelEOS.MajChamps();
			}
			return result;
		}


			
	}
}

