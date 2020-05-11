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
	[ObjectEditeur(typeof(CStock))]
	public class CFormEditionStock : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code

        private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre m_panTop;
		private Label m_lblStockType;
		private CComboBoxLinkListeObjetsDonnees m_cmbTypeStock;
		private Label m_lblSite;
		private C2iTextBoxSelectionne m_txtSelectSite;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageEquipements;
		private CPanelListeSpeedStandard m_panelEquipements;
		private Crownwood.Magic.Controls.TabPage m_pageEOs;
		private CPanelAffectationEO m_panelEOs;
		private Crownwood.Magic.Controls.TabPage m_pageSysCoor;
		private Label m_lblCoor;
		private timos.coordonnees.CControlEditeCoordonnee m_editCoordonnee;
		private CControleEditionOptionsControleCoordonnees m_panelEditOptionsControle;
		private CControleEditeObjetASystemeCoordonnee m_panelEditSystemeCoordonnees;
        private Label m_lblLabel;
        private Crownwood.Magic.Controls.TabPage m_pageComportementTypesEqpt;
        private CWndLinkStd m_lnkSupprimeTypeEquipement;
        private Panel m_panelTypeEqpt;
        private C2iTextBoxNumerique m_txtNumStockOptimal;
        private GroupBox groupBox1;
        private C2iTextBoxNumerique m_txtNumStockCritique;
        private C2iTextBoxNumerique m_txtNumStockAlerte;
        private Label label7;
        private Label label13;
        private Label label12;
        private Label label10;
        private ListViewAutoFilled m_listeTypesEquipements;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private C2iTextBoxSelectionne m_txtSelectTypeEquipement;
        private Label label11;
        private CWndLinkStd m_lnkAddTypeEquipement;
        private CExtLinkField m_linkFieldTypeEqpt;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionRelTypeEquipement;
        private Crownwood.Magic.Controls.TabPage m_pageFiche;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private CReducteurControle m_reducPanTop;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionStock));
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblCoor = new System.Windows.Forms.Label();
            this.m_editCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.m_lblSite = new System.Windows.Forms.Label();
            this.m_cmbTypeStock = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.m_lblStockType = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSysCoor = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditSystemeCoordonnees = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_panelEditOptionsControle = new timos.CControleEditionOptionsControleCoordonnees();
            this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageEquipements = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageEOs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOs = new timos.CPanelAffectationEO();
            this.m_pageComportementTypesEqpt = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimeTypeEquipement = new sc2i.win32.common.CWndLinkStd();
            this.m_panelTypeEqpt = new System.Windows.Forms.Panel();
            this.m_txtNumStockOptimal = new sc2i.win32.common.C2iTextBoxNumerique();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtNumStockCritique = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtNumStockAlerte = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_listeTypesEquipements = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtSelectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lnkAddTypeEquipement = new sc2i.win32.common.CWndLinkStd();
            this.m_reducPanTop = new sc2i.win32.common.CReducteurControle();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireEditionRelTypeEquipement = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkFieldTypeEqpt = new sc2i.win32.common.CExtLinkField();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageSysCoor.SuspendLayout();
            this.m_pageFiche.SuspendLayout();
            this.m_pageEquipements.SuspendLayout();
            this.m_pageEOs.SuspendLayout();
            this.m_pageComportementTypesEqpt.SuspendLayout();
            this.m_panelTypeEqpt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_txtLibelle
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(99, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(365, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Label]|30324";
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_txtSelectSite);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.Controls.Add(this.m_lblCoor);
            this.m_panTop.Controls.Add(this.m_editCoordonnee);
            this.m_panTop.Controls.Add(this.m_lblSite);
            this.m_panTop.Controls.Add(this.m_cmbTypeStock);
            this.m_panTop.Controls.Add(this.m_lblLabel);
            this.m_panTop.Controls.Add(this.m_lblStockType);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(499, 124);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_txtSelectSite
            // 
            this.m_txtSelectSite.ElementSelectionne = null;
            this.m_txtSelectSite.FonctionTextNull = null;
            this.m_txtSelectSite.HasLink = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtSelectSite, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectSite, "");
            this.m_txtSelectSite.Location = new System.Drawing.Point(99, 55);
            this.m_txtSelectSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectSite, "");
            this.m_txtSelectSite.Name = "m_txtSelectSite";
            this.m_txtSelectSite.SelectedObject = null;
            this.m_txtSelectSite.Size = new System.Drawing.Size(365, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectSite.TabIndex = 4006;
            this.m_txtSelectSite.TextNull = "";
            this.m_txtSelectSite.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectSite_ElementSelectionneChanged);
            // 
            // m_lblCoor
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblCoor, "");
            this.m_extLinkField.SetLinkField(this.m_lblCoor, "");
            this.m_lblCoor.Location = new System.Drawing.Point(12, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblCoor, "ASYS_COOR");
            this.m_lblCoor.Name = "m_lblCoor";
            this.m_lblCoor.Size = new System.Drawing.Size(81, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCoor.TabIndex = 4008;
            this.m_lblCoor.Text = "Coordinate|446";
            // 
            // m_editCoordonnee
            // 
            this.m_editCoordonnee.Coordonnee = "";
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_editCoordonnee, "");
            this.m_extLinkField.SetLinkField(this.m_editCoordonnee, "");
            this.m_editCoordonnee.Location = new System.Drawing.Point(99, 78);
            this.m_editCoordonnee.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_editCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_editCoordonnee, "ASYS_COOR");
            this.m_editCoordonnee.Name = "m_editCoordonnee";
            this.m_editCoordonnee.Size = new System.Drawing.Size(365, 21);
            this.m_extStyle.SetStyleBackColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editCoordonnee.TabIndex = 4007;
            // 
            // m_lblSite
            // 
            this.m_lblSite.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblSite, "");
            this.m_extLinkField.SetLinkField(this.m_lblSite, "");
            this.m_lblSite.Location = new System.Drawing.Point(12, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblSite, "");
            this.m_lblSite.Name = "m_lblSite";
            this.m_lblSite.Size = new System.Drawing.Size(45, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSite.TabIndex = 4005;
            this.m_lblSite.Text = "Site|228";
            // 
            // m_cmbTypeStock
            // 
            this.m_cmbTypeStock.ComportementLinkStd = true;
            this.m_cmbTypeStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeStock.ElementSelectionne = null;
            this.m_cmbTypeStock.FormattingEnabled = true;
            this.m_cmbTypeStock.IsLink = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_cmbTypeStock, "");
            this.m_extLinkField.SetLinkField(this.m_cmbTypeStock, "");
            this.m_cmbTypeStock.LinkProperty = "";
            this.m_cmbTypeStock.ListDonnees = null;
            this.m_cmbTypeStock.Location = new System.Drawing.Point(99, 31);
            this.m_cmbTypeStock.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeStock, "");
            this.m_cmbTypeStock.Name = "m_cmbTypeStock";
            this.m_cmbTypeStock.NullAutorise = false;
            this.m_cmbTypeStock.ProprieteAffichee = null;
            this.m_cmbTypeStock.ProprieteParentListeObjets = null;
            this.m_cmbTypeStock.SelectionneurParent = null;
            this.m_cmbTypeStock.Size = new System.Drawing.Size(365, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeStock.TabIndex = 4004;
            this.m_cmbTypeStock.TextNull = I.T("(empty)|30195");
            this.m_cmbTypeStock.Tri = true;
            this.m_cmbTypeStock.TypeFormEdition = null;
            this.m_cmbTypeStock.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeStock_SelectionChangeCommitted);
            // 
            // m_lblLabel
            // 
            this.m_lblLabel.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblLabel, "");
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(12, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4003;
            this.m_lblLabel.Text = "Label|50";
            // 
            // m_lblStockType
            // 
            this.m_lblStockType.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lblStockType, "");
            this.m_extLinkField.SetLinkField(this.m_lblStockType, "");
            this.m_lblStockType.Location = new System.Drawing.Point(12, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblStockType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblStockType, "");
            this.m_lblStockType.Name = "m_lblStockType";
            this.m_lblStockType.Size = new System.Drawing.Size(78, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblStockType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblStockType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblStockType.TabIndex = 4003;
            this.m_lblStockType.Text = "Stock type|208";
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
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 182);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 3;
            this.m_tabControl.SelectedTab = this.m_pageSysCoor;
            this.m_tabControl.Size = new System.Drawing.Size(810, 345);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiche,
            this.m_pageEquipements,
            this.m_pageEOs,
            this.m_pageSysCoor,
            this.m_pageComportementTypesEqpt});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSysCoor
            // 
            this.m_pageSysCoor.Controls.Add(this.m_panelEditSystemeCoordonnees);
            this.m_pageSysCoor.Controls.Add(this.m_panelEditOptionsControle);
            this.m_extLinkField.SetLinkField(this.m_pageSysCoor, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageSysCoor, "");
            this.m_pageSysCoor.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSysCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSysCoor, "ASYS_COOR");
            this.m_pageSysCoor.Name = "m_pageSysCoor";
            this.m_pageSysCoor.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_pageSysCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSysCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSysCoor.TabIndex = 12;
            this.m_pageSysCoor.Title = "Coordinates System|430";
            // 
            // m_panelEditSystemeCoordonnees
            // 
            this.m_panelEditSystemeCoordonnees.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelEditSystemeCoordonnees, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelEditSystemeCoordonnees, "");
            this.m_panelEditSystemeCoordonnees.Location = new System.Drawing.Point(0, 93);
            this.m_panelEditSystemeCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditSystemeCoordonnees, "");
            this.m_panelEditSystemeCoordonnees.Name = "m_panelEditSystemeCoordonnees";
            this.m_panelEditSystemeCoordonnees.Size = new System.Drawing.Size(794, 208);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditSystemeCoordonnees.TabIndex = 0;
            // 
            // m_panelEditOptionsControle
            // 
            this.m_panelEditOptionsControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEditOptionsControle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEditOptionsControle.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEditOptionsControle, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelEditOptionsControle, "");
            this.m_panelEditOptionsControle.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditOptionsControle.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditOptionsControle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditOptionsControle, "");
            this.m_panelEditOptionsControle.Name = "m_panelEditOptionsControle";
            this.m_panelEditOptionsControle.Size = new System.Drawing.Size(794, 93);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditOptionsControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditOptionsControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditOptionsControle.TabIndex = 1;
            // 
            // m_pageFiche
            // 
            this.m_pageFiche.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageFiche, "");
            this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiche, "");
            this.m_pageFiche.Name = "m_pageFiche";
            this.m_pageFiche.Selected = false;
            this.m_pageFiche.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiche.TabIndex = 14;
            this.m_pageFiche.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 8;
            // 
            // m_pageEquipements
            // 
            this.m_pageEquipements.Controls.Add(this.m_panelEquipements);
            this.m_extLinkField.SetLinkField(this.m_pageEquipements, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageEquipements, "");
            this.m_pageEquipements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquipements, "");
            this.m_pageEquipements.Name = "m_pageEquipements";
            this.m_pageEquipements.Selected = false;
            this.m_pageEquipements.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquipements.TabIndex = 10;
            this.m_pageEquipements.Title = "Equipments|247";
            // 
            // m_panelEquipements
            // 
            this.m_panelEquipements.AllowArbre = true;
            this.m_panelEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
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
            glColumn1.Width = 300;
            this.m_panelEquipements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelEquipements.ContexteUtilisation = "";
            this.m_panelEquipements.ControlFiltreStandard = null;
            this.m_panelEquipements.ElementSelectionne = null;
            this.m_panelEquipements.EnableCustomisation = true;
            this.m_panelEquipements.FiltreDeBase = null;
            this.m_panelEquipements.FiltreDeBaseEnAjout = false;
            this.m_panelEquipements.FiltrePrefere = null;
            this.m_panelEquipements.FiltreRapide = null;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelEquipements, "");
            this.m_extLinkField.SetLinkField(this.m_panelEquipements, "");
            this.m_panelEquipements.ListeObjets = null;
            this.m_panelEquipements.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelEquipements.ModeQuickSearch = false;
            this.m_panelEquipements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelEquipements, "");
            this.m_panelEquipements.MultiSelect = false;
            this.m_panelEquipements.Name = "m_panelEquipements";
            this.m_panelEquipements.Navigateur = null;
            this.m_panelEquipements.ProprieteObjetAEditer = null;
            this.m_panelEquipements.QuickSearchText = "";
            this.m_panelEquipements.Size = new System.Drawing.Size(791, 301);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipements.TabIndex = 0;
            this.m_panelEquipements.TrierAuClicSurEnteteColonne = true;
            this.m_panelEquipements.AfterValideCreateObjetDonnee += new sc2i.data.ObjetDonneeEventHandler(this.m_panelEquipements_AfterValideCreateObjetDonnee);
            // 
            // m_pageEOs
            // 
            this.m_pageEOs.Controls.Add(this.m_panelEOs);
            this.m_extLinkField.SetLinkField(this.m_pageEOs, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageEOs, "");
            this.m_pageEOs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEOs, "CEO");
            this.m_pageEOs.Name = "m_pageEOs";
            this.m_pageEOs.Selected = false;
            this.m_pageEOs.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEOs.TabIndex = 11;
            this.m_pageEOs.Title = "Organizational entities|53";
            // 
            // m_panelEOs
            // 
            this.m_panelEOs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEOs, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelEOs, "");
            this.m_panelEOs.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOs.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOs, "");
            this.m_panelEOs.Name = "m_panelEOs";
            this.m_panelEOs.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOs.TabIndex = 0;
            // 
            // m_pageComportementTypesEqpt
            // 
            this.m_pageComportementTypesEqpt.Controls.Add(this.m_lnkSupprimeTypeEquipement);
            this.m_pageComportementTypesEqpt.Controls.Add(this.m_panelTypeEqpt);
            this.m_pageComportementTypesEqpt.Controls.Add(this.m_listeTypesEquipements);
            this.m_pageComportementTypesEqpt.Controls.Add(this.m_txtSelectTypeEquipement);
            this.m_pageComportementTypesEqpt.Controls.Add(this.label11);
            this.m_pageComportementTypesEqpt.Controls.Add(this.m_lnkAddTypeEquipement);
            this.m_extLinkField.SetLinkField(this.m_pageComportementTypesEqpt, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_pageComportementTypesEqpt, "");
            this.m_pageComportementTypesEqpt.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageComportementTypesEqpt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageComportementTypesEqpt, "");
            this.m_pageComportementTypesEqpt.Name = "m_pageComportementTypesEqpt";
            this.m_pageComportementTypesEqpt.Selected = false;
            this.m_pageComportementTypesEqpt.Size = new System.Drawing.Size(794, 304);
            this.m_extStyle.SetStyleBackColor(this.m_pageComportementTypesEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageComportementTypesEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageComportementTypesEqpt.TabIndex = 13;
            this.m_pageComportementTypesEqpt.Title = "Equipment type behaviors|751";
            // 
            // m_lnkSupprimeTypeEquipement
            // 
            this.m_lnkSupprimeTypeEquipement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimeTypeEquipement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimeTypeEquipement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimeTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lnkSupprimeTypeEquipement, "");
            this.m_lnkSupprimeTypeEquipement.Location = new System.Drawing.Point(15, 271);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimeTypeEquipement, "");
            this.m_lnkSupprimeTypeEquipement.Name = "m_lnkSupprimeTypeEquipement";
            this.m_lnkSupprimeTypeEquipement.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimeTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimeTypeEquipement.TabIndex = 21;
            this.m_lnkSupprimeTypeEquipement.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimeTypeEquipement.LinkClicked += new System.EventHandler(this.m_lnkSupprimeTypeEquipement_LinkClicked);
            // 
            // m_panelTypeEqpt
            // 
            this.m_panelTypeEqpt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTypeEqpt.Controls.Add(this.m_txtNumStockOptimal);
            this.m_panelTypeEqpt.Controls.Add(this.groupBox1);
            this.m_panelTypeEqpt.Controls.Add(this.label12);
            this.m_panelTypeEqpt.Controls.Add(this.label10);
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_panelTypeEqpt, "");
            this.m_extLinkField.SetLinkField(this.m_panelTypeEqpt, "");
            this.m_panelTypeEqpt.Location = new System.Drawing.Point(586, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypeEqpt, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTypeEqpt, "");
            this.m_panelTypeEqpt.Name = "m_panelTypeEqpt";
            this.m_panelTypeEqpt.Size = new System.Drawing.Size(178, 246);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypeEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypeEqpt, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypeEqpt.TabIndex = 20;
            this.m_panelTypeEqpt.Visible = false;
            // 
            // m_txtNumStockOptimal
            // 
            this.m_txtNumStockOptimal.Arrondi = 0;
            this.m_txtNumStockOptimal.DecimalAutorise = false;
            this.m_txtNumStockOptimal.DoubleValue = null;
            this.m_txtNumStockOptimal.IntValue = null;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockOptimal, "StockOptimal");
            this.m_extLinkField.SetLinkField(this.m_txtNumStockOptimal, "");
            this.m_txtNumStockOptimal.Location = new System.Drawing.Point(100, 103);
            this.m_txtNumStockOptimal.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockOptimal, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockOptimal, "");
            this.m_txtNumStockOptimal.Name = "m_txtNumStockOptimal";
            this.m_txtNumStockOptimal.NullAutorise = true;
            this.m_txtNumStockOptimal.SelectAllOnEnter = true;
            this.m_txtNumStockOptimal.Size = new System.Drawing.Size(68, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockOptimal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockOptimal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockOptimal.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.m_txtNumStockCritique);
            this.groupBox1.Controls.Add(this.m_txtNumStockAlerte);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label13);
            this.m_linkFieldTypeEqpt.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 71);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alerts|213";
            // 
            // m_txtNumStockCritique
            // 
            this.m_txtNumStockCritique.Arrondi = 0;
            this.m_txtNumStockCritique.DecimalAutorise = false;
            this.m_txtNumStockCritique.DoubleValue = null;
            this.m_txtNumStockCritique.IntValue = null;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockCritique, "StockCritique");
            this.m_extLinkField.SetLinkField(this.m_txtNumStockCritique, "");
            this.m_txtNumStockCritique.Location = new System.Drawing.Point(100, 40);
            this.m_txtNumStockCritique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockCritique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockCritique, "");
            this.m_txtNumStockCritique.Name = "m_txtNumStockCritique";
            this.m_txtNumStockCritique.NullAutorise = true;
            this.m_txtNumStockCritique.SelectAllOnEnter = true;
            this.m_txtNumStockCritique.Size = new System.Drawing.Size(68, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockCritique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockCritique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockCritique.TabIndex = 5;
            // 
            // m_txtNumStockAlerte
            // 
            this.m_txtNumStockAlerte.Arrondi = 0;
            this.m_txtNumStockAlerte.DecimalAutorise = false;
            this.m_txtNumStockAlerte.DoubleValue = null;
            this.m_txtNumStockAlerte.IntValue = null;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtNumStockAlerte, "StockAlerte");
            this.m_extLinkField.SetLinkField(this.m_txtNumStockAlerte, "");
            this.m_txtNumStockAlerte.Location = new System.Drawing.Point(100, 17);
            this.m_txtNumStockAlerte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNumStockAlerte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNumStockAlerte, "");
            this.m_txtNumStockAlerte.Name = "m_txtNumStockAlerte";
            this.m_txtNumStockAlerte.NullAutorise = true;
            this.m_txtNumStockAlerte.SelectAllOnEnter = true;
            this.m_txtNumStockAlerte.Size = new System.Drawing.Size(68, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtNumStockAlerte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNumStockAlerte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNumStockAlerte.TabIndex = 4;
            // 
            // label7
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "Alert threshold|210";
            // 
            // label13
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(6, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 18);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 3;
            this.label13.Text = "Critical threshold|211";
            // 
            // label12
            // 
            this.m_linkFieldTypeEqpt.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(6, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 18);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 2;
            this.label12.Text = "Optimal threshold|212";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFieldTypeEqpt.SetLinkField(this.label10, "TypeEquipement.Libelle");
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 29);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "[TypeEquipement.Libelle]";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_listeTypesEquipements
            // 
            this.m_listeTypesEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listeTypesEquipements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5});
            this.m_listeTypesEquipements.EnableCustomisation = true;
            this.m_listeTypesEquipements.FullRowSelect = true;
            this.m_listeTypesEquipements.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listeTypesEquipements, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_listeTypesEquipements, "");
            this.m_listeTypesEquipements.Location = new System.Drawing.Point(15, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeTypesEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeTypesEquipements, "");
            this.m_listeTypesEquipements.MultiSelect = false;
            this.m_listeTypesEquipements.Name = "m_listeTypesEquipements";
            this.m_listeTypesEquipements.Size = new System.Drawing.Size(565, 197);
            this.m_extStyle.SetStyleBackColor(this.m_listeTypesEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeTypesEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeTypesEquipements.TabIndex = 18;
            this.m_listeTypesEquipements.UseCompatibleStateImageBehavior = false;
            this.m_listeTypesEquipements.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeEquipement.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 200;
            // 
            // m_txtSelectTypeEquipement
            // 
            this.m_txtSelectTypeEquipement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeEquipement.ElementSelectionne = null;
            this.m_txtSelectTypeEquipement.FonctionTextNull = null;
            this.m_txtSelectTypeEquipement.HasLink = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_txtSelectTypeEquipement, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeEquipement, "");
            this.m_txtSelectTypeEquipement.Location = new System.Drawing.Point(136, 19);
            this.m_txtSelectTypeEquipement.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeEquipement, "");
            this.m_txtSelectTypeEquipement.Name = "m_txtSelectTypeEquipement";
            this.m_txtSelectTypeEquipement.SelectedObject = null;
            this.m_txtSelectTypeEquipement.Size = new System.Drawing.Size(444, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeEquipement.TabIndex = 17;
            this.m_txtSelectTypeEquipement.TextNull = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(12, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 16;
            this.label11.Text = "Equipment type|194";
            // 
            // m_lnkAddTypeEquipement
            // 
            this.m_lnkAddTypeEquipement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeEquipement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeEquipement, "");
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_lnkAddTypeEquipement, "");
            this.m_lnkAddTypeEquipement.Location = new System.Drawing.Point(136, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeEquipement, "");
            this.m_lnkAddTypeEquipement.Name = "m_lnkAddTypeEquipement";
            this.m_lnkAddTypeEquipement.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeEquipement.TabIndex = 19;
            this.m_lnkAddTypeEquipement.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeEquipement.LinkClicked += new System.EventHandler(this.m_lnkAddTypeEquipement_LinkClicked);
            // 
            // m_reducPanTop
            // 
            this.m_reducPanTop.ControleAgrandit = this.m_tabControl;
            this.m_reducPanTop.ControleAVoir = this.m_txtLibelle;
            this.m_reducPanTop.ControleReduit = this.m_panTop;
            this.m_linkFieldTypeEqpt.SetLinkField(this.m_reducPanTop, "");
            this.m_extLinkField.SetLinkField(this.m_reducPanTop, "");
            this.m_reducPanTop.Location = new System.Drawing.Point(253, 48);
            this.m_reducPanTop.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducPanTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducPanTop.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducPanTop, "");
            this.m_reducPanTop.Name = "m_reducPanTop";
            this.m_reducPanTop.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducPanTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducPanTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducPanTop.TabIndex = 4005;
            this.m_reducPanTop.TailleReduite = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_linkFieldTypeEqpt.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|50";
            // 
            // m_gestionnaireEditionRelTypeEquipement
            // 
            this.m_gestionnaireEditionRelTypeEquipement.ListeAssociee = this.m_listeTypesEquipements;
            this.m_gestionnaireEditionRelTypeEquipement.ObjetEdite = null;
            this.m_gestionnaireEditionRelTypeEquipement.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelTypeEquipement_InitChamp);
            this.m_gestionnaireEditionRelTypeEquipement.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionRelTypeEquipement_MAJ_Champs);
            // 
            // CFormEditionStock
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_reducPanTop);
            this.Controls.Add(this.m_panTop);
            this.Controls.Add(this.m_tabControl);
            this.m_linkFieldTypeEqpt.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "ASTOCK");
            this.Name = "CFormEditionStock";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionStock_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionStock_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_reducPanTop, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageSysCoor.ResumeLayout(false);
            this.m_pageFiche.ResumeLayout(false);
            this.m_pageEquipements.ResumeLayout(false);
            this.m_pageEOs.ResumeLayout(false);
            this.m_pageComportementTypesEqpt.ResumeLayout(false);
            this.m_pageComportementTypesEqpt.PerformLayout();
            this.m_panelTypeEqpt.ResumeLayout(false);
            this.m_panelTypeEqpt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public CFormEditionStock()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStock(CStock Stock)
			: base(Stock)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionStock(CStock Stock, CListeObjetsDonnees liste)
			: base(Stock, liste)
		{
			InitializeComponent();
		}

		//-------------------------------------------------------------------------
		private CStock Stock
		{
			get
			{
				return (CStock)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			AffecterTitre(I.T( "Stock|206")+" "+ Stock.Libelle);
			m_cmbTypeStock.Init(
				typeof(CTypeStock),
				"Libelle",
				typeof(CFormEditionTypeStock),
				false);
			m_cmbTypeStock.ElementSelectionne = Stock.TypeStock;

			m_txtSelectSite.Init<CSite>("Libelle", false);
			m_txtSelectSite.ElementSelectionne = Stock.Site;

            MenageOnglets();

			m_editCoordonnee.Init(Stock.Site, Stock);
			m_editCoordonnee.Coordonnee = Stock.Coordonnee;

            CResultAErreur result = base.MyInitChamps();

			return result;
		}


        //-------------------------------------------------------------------------
        private void MenageOnglets()
        {
            if (Stock.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Remove(m_pageFiche);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_pageFiche))
                    m_tabControl.TabPages.Insert(0, m_pageFiche);
            }
        }


        //-------------------------------------------------------------------------
        private void InitSelectTypeEquipement()
        {
            m_txtSelectTypeEquipement.Init<CTypeEquipement>(
                "Libelle",
                false);
        }

        //-------------------------------------------------------------------------
        private void InitListeTypesEquipements()
        {
            m_listeTypesEquipements.Items.Clear();

            foreach (CRelationTypeEquipement_Stock rel in Stock.RelationsTypesEquipements)
            {
                ListViewItem item = new ListViewItem();
                m_listeTypesEquipements.Items.Add(item);
                m_listeTypesEquipements.UpdateItemWithObject(item, rel);
            }
        }

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result =  base.MAJ_Champs();
            if (result)
            {
                Stock.TypeStock = (CTypeStock)m_cmbTypeStock.ElementSelectionne;
                Stock.Site = (CSite)m_txtSelectSite.ElementSelectionne;
                Stock.Coordonnee = m_editCoordonnee.Coordonnee;
            }

			return result;
        }


		//-------------------------------------------------------------------------
		private void m_panelEquipements_AfterValideCreateObjetDonnee(object sender, CObjetDonneeEventArgs args)
		{
			if (args.Objet is CEquipement)
			{
				((CEquipement)args.Objet).SetEmplacementSansHistorique(Stock, null);
			}
		}

        //-------------------------------------------------------------------------
        private void m_txtSelectSite_ElementSelectionneChanged(object sender, EventArgs e)
        {
            m_editCoordonnee.Init((IObjetAFilsACoordonnees)m_txtSelectSite.ElementSelectionne, Stock);
        }
        
        //-------------------------------------------------------------------------
        private void m_gestionnaireEditionRelTypeEquipement_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_panelTypeEqpt.Visible = false;
                return;
            }
            m_panelTypeEqpt.Visible = true;
            m_linkFieldTypeEqpt.FillDialogFromObjet(args.Objet);

        }

        //-------------------------------------------------------------------------
        private void m_gestionnaireEditionRelTypeEquipement_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CResultAErreur result = m_linkFieldTypeEqpt.FillObjetFromDialog(args.Objet);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
            }
        }

        //-------------------------------------------------------------------------
        private void m_lnkAddTypeEquipement_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectTypeEquipement.ElementSelectionne == null)
            {
                return;
            }
            CTypeEquipement typeEqpt = (CTypeEquipement)m_txtSelectTypeEquipement.ElementSelectionne;
            CListeObjetsDonnees listeExistants = Stock.RelationsTypesEquipements;
            listeExistants.Filtre = new CFiltreData(
                CTypeEquipement.c_champId + "=@1",
                typeEqpt.Id);

            if (listeExistants.Count != 0)
            {
                CFormAlerte.Afficher(I.T("This equipment type is already in the list|287"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectTypeEquipement.ElementSelectionne = null;

            CRelationTypeEquipement_Stock rel = new CRelationTypeEquipement_Stock(Stock.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.TypeEquipement = typeEqpt;
            rel.Stock = Stock;

            InitListeTypesEquipements();
            InitSelectTypeEquipement();
        }

        //-------------------------------------------------------------------------
        private void m_lnkSupprimeTypeEquipement_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeTypesEquipements.SelectedItems.Count != 1)
                return;

            CRelationTypeEquipement_Stock rel = (CRelationTypeEquipement_Stock)m_listeTypesEquipements.SelectedItems[0].Tag;

            m_gestionnaireEditionRelTypeEquipement.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeTypesEquipements.SelectedItems.Count == 1)
            {
                if (m_listeTypesEquipements.SelectedItems[0] != null)
                    m_listeTypesEquipements.SelectedItems[0].Remove();
            }

            InitSelectTypeEquipement();
        }

        //-------------------------------------------------------------------------
        private void m_cmbTypeStock_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Stock.TypeStock = (CTypeStock)m_cmbTypeStock.ElementSelectionne;
            MenageOnglets();
        }

		private CResultAErreur CFormEditionStock_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageComportementTypesEqpt)
				{
					m_gestionnaireEditionRelTypeEquipement.ObjetEdite = Stock.RelationsTypesEquipements;
					InitSelectTypeEquipement();
					InitListeTypesEquipements();
				}
				else if (page == m_pageEOs)
				{
					m_panelEOs.Init(Stock);
				}
				else if (page == m_pageFiche)
				{
					m_panelChamps.ElementEdite = Stock;
				}
				else if (page == m_pageSysCoor)
				{
					result = m_panelEditSystemeCoordonnees.Init(Stock);
					if(result)
						result = m_panelEditOptionsControle.Init(Stock);
				}
				else if (page == m_pageEquipements)
				{
					m_panelEquipements.InitFromListeObjets(
						Stock.Equipements,
						typeof(CEquipement),
						typeof(CFormEditionEquipement),
						Stock,
						"EmplacementInitial");
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionStock_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageComportementTypesEqpt)
			{
                result = m_gestionnaireEditionRelTypeEquipement.ValideModifs();
			}
			else if (page == m_pageEOs)
			{
                result = m_panelEOs.MajChamps();
			}
			else if (page == m_pageFiche)
			{
                result = m_panelChamps.MAJ_Champs();
            }
			else if (page == m_pageSysCoor)
			{
                result = m_panelEditSystemeCoordonnees.MajChamps();
                result = m_panelEditOptionsControle.MajChamps();
            }
			else if (page == m_pageEquipements)
			{
			}
			return result;
		}
	}
}

