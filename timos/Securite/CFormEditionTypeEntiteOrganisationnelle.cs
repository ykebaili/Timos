using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using System.Collections.Generic;
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

using timos.data;
using timos.securite;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeEntiteOrganisationnelle))]
	public class CFormEditionTypeEntiteOrganisationnelle : CFormEditionStdTimos, 
		IFormNavigable
	{
        private string m_cleRegistreListViewExceptionsPourType = "";

		#region Designer generated code


		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage pageChampsCustom;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChamps;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private sc2i.win32.common.C2iTextBox m_txtNom;
		private System.Windows.Forms.Label label1;
		private Label label9;
		private CArbreObjetHierarchique m_arbreParents;
		private Label label2;
		private LinkLabel m_lnkEntiteFille;
		private Label label4;
		private Label label3;
		private Crownwood.Magic.Controls.TabPage pageCoor;
		private CControleEditeObjetASystemeCoordonnee m_panelSystemeCoordonnees;
		private CControleEditionOptionsControleCoordonnees m_ctrlOptionsCoor;
		private Crownwood.Magic.Controls.TabPage pageSetup;
		private Label label5;
        private Panel m_panelFormulairesParEos;
        private ColumnHeader m_colTypeEntiteString;
        private ListViewAutoFilled m_lstViewExceptionsPourType;
        private Label label6;
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
				m_listeControlesFormulairesParTypes.Clear();
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
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.pageSetup = new Crownwood.Magic.Controls.TabPage();
            this.m_lstViewExceptionsPourType = new sc2i.win32.common.ListViewAutoFilled();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelFormulairesParEos = new System.Windows.Forms.Panel();
            this.pageCoor = new Crownwood.Magic.Controls.TabPage();
            this.m_ctrlOptionsCoor = new timos.CControleEditionOptionsControleCoordonnees();
            this.m_panelSystemeCoordonnees = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_colTypeEntiteString = new System.Windows.Forms.ColumnHeader();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lnkEntiteFille = new System.Windows.Forms.LinkLabel();
            this.m_arbreParents = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.pageChampsCustom.SuspendLayout();
            this.pageSetup.SuspendLayout();
            this.pageCoor.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
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
            // m_tabControl
            // 
            this.m_tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.ControlBottomOffset = 16;
            this.m_tabControl.ControlRightOffset = 16;
            this.m_tabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(12, 198);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.pageSetup;
            this.m_tabControl.Size = new System.Drawing.Size(810, 328);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageChampsCustom,
            this.pageSetup,
            this.pageCoor});
            // 
            // pageChampsCustom
            // 
            this.pageChampsCustom.Controls.Add(this.m_panelDefinisseurChamps);
            this.m_extLinkField.SetLinkField(this.pageChampsCustom, "");
            this.pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageChampsCustom, "");
            this.pageChampsCustom.Name = "pageChampsCustom";
            this.pageChampsCustom.Selected = false;
            this.pageChampsCustom.Size = new System.Drawing.Size(794, 287);
            this.m_extStyle.SetStyleBackColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageChampsCustom.TabIndex = 2;
            this.pageChampsCustom.Title = "Custom fields|101";
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
            this.m_panelDefinisseurChamps.Size = new System.Drawing.Size(794, 287);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurChamps.TabIndex = 0;
            // 
            // pageSetup
            // 
            this.pageSetup.Controls.Add(this.m_lstViewExceptionsPourType);
            this.pageSetup.Controls.Add(this.label5);
            this.pageSetup.Controls.Add(this.m_panelFormulairesParEos);
            this.pageSetup.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.pageSetup, "");
            this.pageSetup.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageSetup, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageSetup, "");
            this.pageSetup.Name = "pageSetup";
            this.pageSetup.Size = new System.Drawing.Size(794, 287);
            this.m_extStyle.SetStyleBackColor(this.pageSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageSetup.TabIndex = 11;
            this.pageSetup.Title = "Settings|1091";
            // 
            // m_lstViewExceptionsPourType
            // 
            this.m_lstViewExceptionsPourType.EnableCustomisation = true;
            this.m_lstViewExceptionsPourType.FullRowSelect = true;
            this.m_extLinkField.SetLinkField(this.m_lstViewExceptionsPourType, "");
            this.m_lstViewExceptionsPourType.Location = new System.Drawing.Point(451, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lstViewExceptionsPourType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lstViewExceptionsPourType, "");
            this.m_lstViewExceptionsPourType.Name = "m_lstViewExceptionsPourType";
            this.m_lstViewExceptionsPourType.Size = new System.Drawing.Size(324, 230);
            this.m_extStyle.SetStyleBackColor(this.m_lstViewExceptionsPourType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lstViewExceptionsPourType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lstViewExceptionsPourType.TabIndex = 2;
            this.m_lstViewExceptionsPourType.UseCompatibleStateImageBehavior = false;
            this.m_lstViewExceptionsPourType.View = System.Windows.Forms.View.Details;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(5, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(423, 34);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 1;
            this.label5.Text = "Select the forms to display for elements associated with an Organizational Entity" +
                " of this type|1092";
            // 
            // m_panelFormulairesParEos
            // 
            this.m_panelFormulairesParEos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelFormulairesParEos.AutoScroll = true;
            this.m_extLinkField.SetLinkField(this.m_panelFormulairesParEos, "");
            this.m_panelFormulairesParEos.Location = new System.Drawing.Point(6, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulairesParEos, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelFormulairesParEos, "");
            this.m_panelFormulairesParEos.Name = "m_panelFormulairesParEos";
            this.m_panelFormulairesParEos.Size = new System.Drawing.Size(422, 230);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulairesParEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulairesParEos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulairesParEos.TabIndex = 0;
            // 
            // pageCoor
            // 
            this.pageCoor.Controls.Add(this.m_ctrlOptionsCoor);
            this.pageCoor.Controls.Add(this.m_panelSystemeCoordonnees);
            this.m_extLinkField.SetLinkField(this.pageCoor, "");
            this.pageCoor.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageCoor, "");
            this.pageCoor.Name = "pageCoor";
            this.pageCoor.Selected = false;
            this.pageCoor.Size = new System.Drawing.Size(794, 287);
            this.m_extStyle.SetStyleBackColor(this.pageCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageCoor.TabIndex = 10;
            this.pageCoor.Title = "Coordinates|446";
            // 
            // m_ctrlOptionsCoor
            // 
            this.m_ctrlOptionsCoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_ctrlOptionsCoor.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_ctrlOptionsCoor, "");
            this.m_ctrlOptionsCoor.Location = new System.Drawing.Point(18, 3);
            this.m_ctrlOptionsCoor.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ctrlOptionsCoor, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ctrlOptionsCoor, "");
            this.m_ctrlOptionsCoor.Name = "m_ctrlOptionsCoor";
            this.m_ctrlOptionsCoor.Size = new System.Drawing.Size(489, 93);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlOptionsCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlOptionsCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlOptionsCoor.TabIndex = 2;
            // 
            // m_panelSystemeCoordonnees
            // 
            this.m_extLinkField.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Location = new System.Drawing.Point(18, 102);
            this.m_panelSystemeCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Name = "m_panelSystemeCoordonnees";
            this.m_panelSystemeCoordonnees.Size = new System.Drawing.Size(762, 140);
            this.m_extStyle.SetStyleBackColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSystemeCoordonnees.TabIndex = 1;
            // 
            // m_colTypeEntiteString
            // 
            this.m_colTypeEntiteString.Text = "Entity Type Name|10094";
            this.m_colTypeEntiteString.Width = 300;
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.label4);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkEntiteFille);
            this.c2iPanelOmbre1.Controls.Add(this.m_arbreParents);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtNom);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.label9);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 32);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(600, 160);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "CodeSystemeComplet");
            this.label4.Location = new System.Drawing.Point(513, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4009;
            this.label4.Text = "[CodeSystemeComplet]";
            // 
            // m_lnkEntiteFille
            // 
            this.m_lnkEntiteFille.BackColor = System.Drawing.Color.White;
            this.m_lnkEntiteFille.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lnkEntiteFille, "");
            this.m_lnkEntiteFille.Location = new System.Drawing.Point(95, 116);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEntiteFille, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkEntiteFille, "");
            this.m_lnkEntiteFille.Name = "m_lnkEntiteFille";
            this.m_lnkEntiteFille.Size = new System.Drawing.Size(484, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEntiteFille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEntiteFille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEntiteFille.TabIndex = 4007;
            this.m_lnkEntiteFille.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.m_lnkEntiteFille.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEntiteFille_LinkClicked);
            // 
            // m_arbreParents
            // 
            this.m_arbreParents.AutoriseReaffectation = false;
            this.m_arbreParents.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_arbreParents, "");
            this.m_arbreParents.Location = new System.Drawing.Point(3, 3);
            this.m_arbreParents.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreParents, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreParents, "");
            this.m_arbreParents.Name = "m_arbreParents";
            this.m_arbreParents.Size = new System.Drawing.Size(576, 86);
            this.m_extStyle.SetStyleBackColor(this.m_arbreParents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreParents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreParents.TabIndex = 4005;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(455, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4008;
            this.label3.Text = "Code|121";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // m_txtNom
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNom, "Libelle");
            this.m_txtNom.Location = new System.Drawing.Point(95, 92);
            this.m_txtNom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNom, "");
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(354, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 4003;
            this.m_txtNom.Text = "[Libelle]";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(3, 123);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4006;
            this.label2.Text = "Child entities|111";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(3, 95);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 13);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.label9.TabIndex = 4004;
            this.label9.Text = "Label|50";
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
            this.label1.Text = "Nom : ";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(451, 1);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(324, 34);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4004;
            this.label6.Text = "Select Entity Types on wich Organizational Enties of this Type will NOT be availa" +
                "ble in user interface OE selection|10095";
            // 
            // CFormEditionTypeEntiteOrganisationnelle
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BoutonAjouterVisible = false;
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeEntiteOrganisationnelle";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEntiteOrganisationnelle_OnInitPage);
            this.Load += new System.EventHandler(this.CFormEditionTypeEntiteOrganisationnelles_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormEditionTypeEntiteOrganisationnelle_FormClosing);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEntiteOrganisationnelle_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageChampsCustom.ResumeLayout(false);
            this.pageSetup.ResumeLayout(false);
            this.pageCoor.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionTypeEntiteOrganisationnelle()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEntiteOrganisationnelle(CTypeEntiteOrganisationnelle groupe)
			:base(groupe)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEntiteOrganisationnelle(CTypeEntiteOrganisationnelle typeEO, CListeObjetsDonnees liste)
			:base(typeEO, liste)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}

		private List<CControleSelectFormulaireParType> m_listeControlesFormulairesParTypes = new List<CControleSelectFormulaireParType>();


		//-------------------------------------------------------------------------
		private CTypeEntiteOrganisationnelle TypeEntiteOrganisationnelle
		{
			get
			{
				return (CTypeEntiteOrganisationnelle)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionTypeEntiteOrganisationnelles_Load(object sender, System.EventArgs e)
		{
			if (m_listeControlesFormulairesParTypes.Count == 0)
			{
				m_panelFormulairesParEos.SuspendDrawing();
				foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(IElementAEO)))
				{
                    if (info.Classe.IsInterface)
                        continue;

					CControleSelectFormulaireParType ctrl = new CControleSelectFormulaireParType();
					m_panelFormulairesParEos.Controls.Add(ctrl);
					ctrl.Dock = DockStyle.Top;
					ctrl.SendToBack();
					ctrl.SetTypeAssocie(info.Classe);
					m_gestionnaireModeEdition.SetModeEdition(ctrl, TypeModeEdition.EnableSurEdition);
					ctrl.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
					m_listeControlesFormulairesParTypes.Add(ctrl);
				}
				m_panelFormulairesParEos.ResumeDrawing();
			}

            ListViewAutoFilledColumn colonneNomEntite = new ListViewAutoFilledColumn();
            colonneNomEntite.Text = I.T("Entity Type Name|10094");
            colonneNomEntite.Width = 250;
            colonneNomEntite.Field = "Nom";
            m_lstViewExceptionsPourType.Colonnes.Add(colonneNomEntite);

            m_cleRegistreListViewExceptionsPourType = "Preferences\\Panel_Listes\\" + this.GetType().Name + "_" + m_lstViewExceptionsPourType.Name;
            m_lstViewExceptionsPourType.ReadFromRegistre(new CSc2iWin32DataNavigationRegistre().GetKey(m_cleRegistreListViewExceptionsPourType, true));
					
		}
       
        private void CFormEditionTypeEntiteOrganisationnelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_lstViewExceptionsPourType.WriteToRegistre(new CSc2iWin32DataNavigationRegistre().GetKey(m_cleRegistreListViewExceptionsPourType, true));
        }

		//-------------------------------------------------------------------------
		private CTypeEntiteOrganisationnelle m_lastType = null;
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			m_arbreParents.AfficheHierarchie(TypeEntiteOrganisationnelle);

			if (TypeEntiteOrganisationnelle.IsNew() &&
				TypeEntiteOrganisationnelle.TypeParent == null)
				TypeEntiteOrganisationnelle.TypeParent = m_lastType;

			m_lastType = TypeEntiteOrganisationnelle.TypeParent;

			CTypeEntiteOrganisationnelle typeFils = TypeEntiteOrganisationnelle.TypeFils;
			if (typeFils == null)
				m_lnkEntiteFille.Text = I.T("Not (click for create)|112");
			else
				m_lnkEntiteFille.Text = typeFils.Libelle;

			AffecterTitre(I.T("Organizational entity type @1|114",((CTypeEntiteOrganisationnelle)ObjetEdite).Libelle));
		
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

		private void m_lnkEntiteFille_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CTypeEntiteOrganisationnelle typeFils = TypeEntiteOrganisationnelle.TypeFils;
			if (typeFils == null)
			{
				typeFils = new CTypeEntiteOrganisationnelle ( TypeEntiteOrganisationnelle.ContexteDonnee ) ;
				typeFils.CreateNew();
				typeFils.TypeParent = TypeEntiteOrganisationnelle;
			}
			CTimosApp.Navigateur.AffichePage(new CFormEditionTypeEntiteOrganisationnelle(typeFils));
		}

		//-------------------------------------------------------------------------
		private CResultAErreur CFormEditionTypeEntiteOrganisationnelle_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == pageChampsCustom)
				{
					m_panelDefinisseurChamps.InitPanel(
					    TypeEntiteOrganisationnelle,
						typeof(CFormListeChampsCustom),
						typeof(CFormListeFormulaires));
                    
				}
				else if (page == pageCoor)
				{
					result = m_panelSystemeCoordonnees.Init(TypeEntiteOrganisationnelle);
					if (result)
						result = m_ctrlOptionsCoor.Init(TypeEntiteOrganisationnelle);
				}
				else if (page == pageSetup)
				{
					foreach (CControleSelectFormulaireParType ctrl in m_listeControlesFormulairesParTypes)
					{
						result = ctrl.InitChamps(TypeEntiteOrganisationnelle);
						if (!result)
							return result;
					}
                    // Sélection des Exception pour les Types d'entités
                    m_lstViewExceptionsPourType.BeginUpdate();
                    m_lstViewExceptionsPourType.CheckBoxes = m_gestionnaireModeEdition.ModeEdition;
                    List<CInfoClasseDynamique> lstTypesElementsAEO = new List<CInfoClasseDynamique>();
                    foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClassHeritant(typeof(IElementAEO)))
                    {
                        if (!info.Classe.IsInterface)
                            lstTypesElementsAEO.Add(info);
                    }
                    m_lstViewExceptionsPourType.Remplir(lstTypesElementsAEO);

                    foreach (ListViewItem item in m_lstViewExceptionsPourType.Items)
                    {
                        item.Checked = TypeEntiteOrganisationnelle.HasExceptionForType(((CInfoClasseDynamique)item.Tag).Classe);
                        if (!item.Checked && !m_gestionnaireModeEdition.ModeEdition)
                            m_lstViewExceptionsPourType.Items.Remove(item);
                    }
                    m_lstViewExceptionsPourType.EndUpdate();
				}
			}
			return result;
		}
		private CResultAErreur CFormEditionTypeEntiteOrganisationnelle_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == pageChampsCustom)
			{
				result = m_panelDefinisseurChamps.MAJ_Champs();
			}
			else if (page == pageCoor)
			{
				result = m_ctrlOptionsCoor.MajChamps();
				if (result)
					result = m_panelSystemeCoordonnees.MajChamps();
			}
			else if (page == pageSetup)
			{
				foreach (CControleSelectFormulaireParType ctrl in m_listeControlesFormulairesParTypes)
				{
					result = ctrl.MajChamps();
					if (!result)
						return result;
				}

                // Gestion des Exceptions
                foreach (ListViewItem item in m_lstViewExceptionsPourType.Items)
                {
                    if (item.Checked)
                    {
                        Type tpElement = (((CInfoClasseDynamique)item.Tag).Classe);
                        TypeEntiteOrganisationnelle.AddExceptionForType(tpElement);
                    }
                    else
                    {
                        Type tpElement = (((CInfoClasseDynamique)item.Tag).Classe);
                        result = TypeEntiteOrganisationnelle.RemoveExceptionForType(tpElement);
                        if (!result)
                            return result;
                    }
                }

			}
			return result;
		}

	}
}

