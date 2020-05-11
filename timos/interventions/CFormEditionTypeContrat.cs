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
using sc2i.workflow;

using timos.data;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeContrat))]
	public class CFormEditionTypeContrat : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private sc2i.win32.common.C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageDetail;
		private Label label7;
        private CComboBoxListeObjetsDonnees m_cmbFormulaire;
        private GroupBox groupBox1;
        private RadioButton m_radio_sites_manuels;
        private RadioButton m_radio_Sites_Auto;
        private CheckBox m_chkCorrectiveManagement;
        private CheckBox m_chkPreventiveManagement;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeContrat()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeContrat(CTypeContrat TypeContrat)
			:base(TypeContrat)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeContrat(CTypeContrat TypeContrat, CListeObjetsDonnees liste)
			:base(TypeContrat, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDetail = new Crownwood.Magic.Controls.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbFormulaire = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_radio_sites_manuels = new System.Windows.Forms.RadioButton();
            this.m_radio_Sites_Auto = new System.Windows.Forms.RadioButton();
            this.m_chkCorrectiveManagement = new System.Windows.Forms.CheckBox();
            this.m_chkPreventiveManagement = new System.Windows.Forms.CheckBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageDetail.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(12, 24);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(72, 20);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(412, 20);
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
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 30);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(524, 86);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 122);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageDetail;
            this.m_tabControl.Size = new System.Drawing.Size(822, 406);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageDetail});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDetail
            // 
            this.m_pageDetail.Controls.Add(this.m_chkPreventiveManagement);
            this.m_pageDetail.Controls.Add(this.m_chkCorrectiveManagement);
            this.m_pageDetail.Controls.Add(this.groupBox1);
            this.m_pageDetail.Controls.Add(this.label7);
            this.m_pageDetail.Controls.Add(this.m_cmbFormulaire);
            this.m_extLinkField.SetLinkField(this.m_pageDetail, "");
            this.m_pageDetail.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDetail, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDetail, "");
            this.m_pageDetail.Name = "m_pageDetail";
            this.m_pageDetail.Size = new System.Drawing.Size(806, 365);
            this.m_extStyle.SetStyleBackColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDetail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDetail.TabIndex = 10;
            this.m_pageDetail.Title = "Details|337";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(19, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(369, 18);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 10;
            this.label7.Text = "Select the displayed form for the contracts of this type|1131";
            // 
            // m_cmbFormulaire
            // 
            this.m_cmbFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaire.ElementSelectionne = null;
            this.m_cmbFormulaire.FormattingEnabled = true;
            this.m_cmbFormulaire.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFormulaire, "");
            this.m_cmbFormulaire.ListDonnees = null;
            this.m_cmbFormulaire.Location = new System.Drawing.Point(19, 39);
            this.m_cmbFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormulaire, "");
            this.m_cmbFormulaire.Name = "m_cmbFormulaire";
            this.m_cmbFormulaire.NullAutorise = true;
            this.m_cmbFormulaire.ProprieteAffichee = null;
            this.m_cmbFormulaire.ProprieteParentListeObjets = null;
            this.m_cmbFormulaire.SelectionneurParent = null;
            this.m_cmbFormulaire.Size = new System.Drawing.Size(382, 23);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaire.TabIndex = 10;
            this.m_cmbFormulaire.TextNull = "(Inherited)";
            this.m_cmbFormulaire.Tri = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_radio_sites_manuels);
            this.groupBox1.Controls.Add(this.m_radio_Sites_Auto);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(22, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 100);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sites options|10104";
            // 
            // m_radio_sites_manuels
            // 
            this.m_extLinkField.SetLinkField(this.m_radio_sites_manuels, "");
            this.m_radio_sites_manuels.Location = new System.Drawing.Point(18, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radio_sites_manuels, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radio_sites_manuels, "");
            this.m_radio_sites_manuels.Name = "m_radio_sites_manuels";
            this.m_radio_sites_manuels.Size = new System.Drawing.Size(293, 27);
            this.m_extStyle.SetStyleBackColor(this.m_radio_sites_manuels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radio_sites_manuels, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radio_sites_manuels.TabIndex = 13;
            this.m_radio_sites_manuels.TabStop = true;
            this.m_radio_sites_manuels.Text = "Manual Site management|20230";
            this.m_radio_sites_manuels.UseVisualStyleBackColor = true;
            // 
            // m_radio_Sites_Auto
            // 
            this.m_extLinkField.SetLinkField(this.m_radio_Sites_Auto, "");
            this.m_radio_Sites_Auto.Location = new System.Drawing.Point(18, 22);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radio_Sites_Auto, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radio_Sites_Auto, "");
            this.m_radio_Sites_Auto.Name = "m_radio_Sites_Auto";
            this.m_radio_Sites_Auto.Size = new System.Drawing.Size(293, 27);
            this.m_extStyle.SetStyleBackColor(this.m_radio_Sites_Auto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radio_Sites_Auto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radio_Sites_Auto.TabIndex = 12;
            this.m_radio_Sites_Auto.TabStop = true;
            this.m_radio_Sites_Auto.Text = "Use profile to manage Sites|20229";
            this.m_radio_Sites_Auto.UseVisualStyleBackColor = true;
            // 
            // m_chkCorrectiveManagement
            // 
            this.m_extLinkField.SetLinkField(this.m_chkCorrectiveManagement, "GestionMaintenanceCorrective");
            this.m_chkCorrectiveManagement.Location = new System.Drawing.Point(40, 191);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkCorrectiveManagement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkCorrectiveManagement, "");
            this.m_chkCorrectiveManagement.Name = "m_chkCorrectiveManagement";
            this.m_chkCorrectiveManagement.Size = new System.Drawing.Size(356, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkCorrectiveManagement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkCorrectiveManagement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkCorrectiveManagement.TabIndex = 12;
            this.m_chkCorrectiveManagement.Text = "Corrective Maintenance configuration|10105";
            this.m_chkCorrectiveManagement.UseVisualStyleBackColor = true;
            // 
            // m_chkPreventiveManagement
            // 
            this.m_extLinkField.SetLinkField(this.m_chkPreventiveManagement, "GestionMaintenancePreventive");
            this.m_chkPreventiveManagement.Location = new System.Drawing.Point(40, 214);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkPreventiveManagement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkPreventiveManagement, "");
            this.m_chkPreventiveManagement.Name = "m_chkPreventiveManagement";
            this.m_chkPreventiveManagement.Size = new System.Drawing.Size(356, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkPreventiveManagement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkPreventiveManagement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkPreventiveManagement.TabIndex = 12;
            this.m_chkPreventiveManagement.Text = "Preventive Maintenance configuration|10106";
            this.m_chkPreventiveManagement.UseVisualStyleBackColor = true;
            // 
            // CFormEditionTypeContrat
            // 
            this.ClientSize = new System.Drawing.Size(830, 540);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeContrat";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
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
            this.m_pageDetail.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeContrat TypeContrat
		{
			get
			{
				return (CTypeContrat)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Contract Type|1128") + " "+TypeContrat.Libelle);

			CListeObjetsDonnees  listeOcc = new CListeObjetsDonnees ( TypeContrat.ContexteDonnee, typeof(CTypeOccupationHoraire ) );

			CListeObjetsDonnees liste = new CListeObjetsDonnees(TypeContrat.ContexteDonnee, typeof(CFormulaire));
            liste.Filtre = CFormulaire.GetFiltreFormulairesForRole(CContrat.c_roleChampCustom);

			m_cmbFormulaire.Init(liste, "Libelle", false);
			m_cmbFormulaire.ElementSelectionne = TypeContrat.Formulaire;
			
            // Options
            if (TypeContrat.GestionSitesManuel)
                m_radio_sites_manuels.Checked = true;
            else
                m_radio_Sites_Auto.Checked = true;

            

			return result;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

            TypeContrat.Formulaire= (CFormulaire)m_cmbFormulaire.ElementSelectionne;

            TypeContrat.GestionSitesManuel = m_radio_sites_manuels.Checked;

			return result;
		}

		
	}
}

