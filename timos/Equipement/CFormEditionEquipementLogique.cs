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
using System.Text;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEquipementLogique))]
	public class CFormEditionEquipementLogique : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code
        private sc2i.win32.common.C2iPanelOmbre m_panelEnTete;
		private Label label3;
        private Label label2;
		private CComboBoxArbreObjetDonneesHierarchique m_comboFamille;
		private C2iTextBox c2iTextBox2;
        private Label label19;
		private C2iTextBoxSelectionne m_selectTypeEquipement;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private timos.CWaiteurPourFormTimos cWaiteurPourFormTimos1;
		private Label label6;
		private C2iTextBoxSelectionne m_selectSite;
		private Label label5;
        private C2iTextBoxSelectionne m_txtSelectEquipementParent;
        private CPanelSymboleElement cPanelSymboleElement1;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage pageFiche;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private Crownwood.Magic.Controls.TabPage pageContient;
        private CPanelListeSpeedStandard m_panelEquipementsInclus;
        private Crownwood.Magic.Controls.TabPage m_pageEquipement;
        private timos.Equipement.CPanelEquipementsDeEquipementLogique m_panelEquipement;
        private Crownwood.Magic.Controls.TabPage m_pageLiens;
        private CPanelListeSpeedStandard m_panelListeLiens;
		private System.ComponentModel.IContainer components = null;

        
		//-------------------------------------------------------------------------
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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionEquipementLogique));
            this.m_panelEnTete = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSelectEquipementParent = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_selectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_comboFamille = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.label6 = new System.Windows.Forms.Label();
            this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.cWaiteurPourFormTimos1 = new timos.CWaiteurPourFormTimos();
            this.cPanelSymboleElement1 = new timos.CPanelSymboleElement();
            this.m_pageEquipement = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipement = new timos.Equipement.CPanelEquipementsDeEquipementLogique();
            this.pageContient = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipementsInclus = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageLiens = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeLiens = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelEnTete.SuspendLayout();
            this.m_pageEquipement.SuspendLayout();
            this.pageContient.SuspendLayout();
            this.pageFiche.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageLiens.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(625, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(517, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(800, 32);
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
            // m_panelEnTete
            // 
            this.m_panelEnTete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEnTete.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelEnTete.Controls.Add(this.m_txtSelectEquipementParent);
            this.m_panelEnTete.Controls.Add(this.label2);
            this.m_panelEnTete.Controls.Add(this.label5);
            this.m_panelEnTete.Controls.Add(this.label3);
            this.m_panelEnTete.Controls.Add(this.label19);
            this.m_panelEnTete.Controls.Add(this.c2iTextBox2);
            this.m_panelEnTete.Controls.Add(this.m_comboFamille);
            this.m_panelEnTete.Controls.Add(this.label6);
            this.m_panelEnTete.Controls.Add(this.m_selectSite);
            this.m_panelEnTete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEnTete, "");
            this.m_panelEnTete.Location = new System.Drawing.Point(8, 52);
            this.m_panelEnTete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEnTete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEnTete, "");
            this.m_panelEnTete.Name = "m_panelEnTete";
            this.m_panelEnTete.Size = new System.Drawing.Size(792, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnTete.TabIndex = 0;
            // 
            // m_txtSelectEquipementParent
            // 
            this.m_txtSelectEquipementParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectEquipementParent.ElementSelectionne = null;
            this.m_txtSelectEquipementParent.FonctionTextNull = null;
            this.m_txtSelectEquipementParent.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectEquipementParent, "");
            this.m_txtSelectEquipementParent.Location = new System.Drawing.Point(522, 27);
            this.m_txtSelectEquipementParent.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectEquipementParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectEquipementParent, "");
            this.m_txtSelectEquipementParent.Name = "m_txtSelectEquipementParent";
            this.m_txtSelectEquipementParent.SelectedObject = null;
            this.m_txtSelectEquipementParent.Size = new System.Drawing.Size(246, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectEquipementParent.TabIndex = 4029;
            this.m_txtSelectEquipementParent.TextNull = "";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(4, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Logical equipment type|20057";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(413, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 17);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4028;
            this.label5.Text = "Parent equipment|20058";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Equipment family|20056";
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(5, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label19, "");
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 9;
            this.label19.Text = "Label|50";
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(129, 52);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(250, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeEquipement.TabIndex = 4014;
            this.m_selectTypeEquipement.TextNull = "";
            this.m_selectTypeEquipement.ElementSelectionneChanged += new System.EventHandler(this.m_cmbTypeEquipement_SelectedValueChanged);
            // 
            // c2iTextBox2
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Libelle");
            this.c2iTextBox2.Location = new System.Drawing.Point(129, 5);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(250, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 10;
            this.c2iTextBox2.Text = "[Libelle]";
            // 
            // m_comboFamille
            // 
            this.m_comboFamille.BackColor = System.Drawing.Color.White;
            this.m_comboFamille.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_comboFamille, "");
            this.m_comboFamille.Location = new System.Drawing.Point(129, 27);
            this.m_comboFamille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboFamille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_comboFamille, "");
            this.m_comboFamille.Name = "m_comboFamille";
            this.m_comboFamille.NullAutorise = false;
            this.m_comboFamille.Size = new System.Drawing.Size(250, 21);
            this.m_extStyle.SetStyleBackColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_comboFamille.TabIndex = 4012;
            this.m_comboFamille.TextNull = "[None]";
            this.m_comboFamille.ElementSelectionneChanged += new System.EventHandler(this.m_comboFamille_ElementSelectionneChanged);
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(413, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4015;
            this.label6.Text = "Site |227";
            // 
            // m_selectSite
            // 
            this.m_selectSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectSite.ElementSelectionne = null;
            this.m_selectSite.FonctionTextNull = null;
            this.m_selectSite.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectSite, "");
            this.m_selectSite.Location = new System.Drawing.Point(522, 5);
            this.m_selectSite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_selectSite, "");
            this.m_selectSite.Name = "m_selectSite";
            this.m_selectSite.SelectedObject = null;
            this.m_selectSite.Size = new System.Drawing.Size(246, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectSite.TabIndex = 4016;
            this.m_selectSite.TextNull = "";
            this.m_selectSite.OnSelectedObjectChanged += new System.EventHandler(this.m_selectSite_OnSelectedObjectChanged);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 168;
            this.listViewAutoFilledColumn1.ProportionnalSize = true;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 168;
            // 
            // cWaiteurPourFormTimos1
            // 
            this.cWaiteurPourFormTimos1.Formulaire = this;
            // 
            // cPanelSymboleElement1
            // 
            this.m_extLinkField.SetLinkField(this.cPanelSymboleElement1, "");
            this.cPanelSymboleElement1.Location = new System.Drawing.Point(3, 32);
            this.cPanelSymboleElement1.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.cPanelSymboleElement1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.cPanelSymboleElement1, "");
            this.cPanelSymboleElement1.Name = "cPanelSymboleElement1";
            this.cPanelSymboleElement1.Size = new System.Drawing.Size(802, 320);
            this.m_extStyle.SetStyleBackColor(this.cPanelSymboleElement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.cPanelSymboleElement1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cPanelSymboleElement1.TabIndex = 10;
            // 
            // m_pageEquipement
            // 
            this.m_pageEquipement.Controls.Add(this.m_panelEquipement);
            this.m_extLinkField.SetLinkField(this.m_pageEquipement, "");
            this.m_pageEquipement.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquipement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquipement, "");
            this.m_pageEquipement.Name = "m_pageEquipement";
            this.m_pageEquipement.Selected = false;
            this.m_pageEquipement.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquipement.TabIndex = 12;
            this.m_pageEquipement.Title = "Physical Equipment|10093";
            // 
            // m_panelEquipement
            // 
            this.m_panelEquipement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEquipement.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEquipement, "");
            this.m_panelEquipement.Location = new System.Drawing.Point(0, 0);
            this.m_panelEquipement.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEquipement, "");
            this.m_panelEquipement.Name = "m_panelEquipement";
            this.m_panelEquipement.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipement.TabIndex = 0;
            // 
            // pageContient
            // 
            this.pageContient.Controls.Add(this.m_panelEquipementsInclus);
            this.m_extLinkField.SetLinkField(this.pageContient, "");
            this.pageContient.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageContient, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageContient, "");
            this.pageContient.Name = "pageContient";
            this.pageContient.Selected = false;
            this.pageContient.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.pageContient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageContient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageContient.TabIndex = 11;
            this.pageContient.Title = "Contains|20061";
            // 
            // m_panelEquipementsInclus
            // 
            this.m_panelEquipementsInclus.AllowArbre = true;
            this.m_panelEquipementsInclus.AllowCustomisation = true;
            this.m_panelEquipementsInclus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn2.ActiveControlItems = null;
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "TypeEquipement.Libelle";
            glColumn2.Text = "Equipment type|194";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            glColumn3.ActiveControlItems = null;
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Namex";
            glColumn3.Propriete = "NumSerie";
            glColumn3.Text = "Serial Number|223";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            this.m_panelEquipementsInclus.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2,
            glColumn3});
            this.m_panelEquipementsInclus.ContexteUtilisation = "";
            this.m_panelEquipementsInclus.ControlFiltreStandard = null;
            this.m_panelEquipementsInclus.ElementSelectionne = null;
            this.m_panelEquipementsInclus.EnableCustomisation = true;
            this.m_panelEquipementsInclus.FiltreDeBase = null;
            this.m_panelEquipementsInclus.FiltreDeBaseEnAjout = false;
            this.m_panelEquipementsInclus.FiltrePrefere = null;
            this.m_panelEquipementsInclus.FiltreRapide = null;
            this.m_panelEquipementsInclus.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelEquipementsInclus, "");
            this.m_panelEquipementsInclus.ListeObjets = null;
            this.m_panelEquipementsInclus.Location = new System.Drawing.Point(0, 3);
            this.m_panelEquipementsInclus.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipementsInclus, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelEquipementsInclus.ModeQuickSearch = false;
            this.m_panelEquipementsInclus.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelEquipementsInclus, "");
            this.m_panelEquipementsInclus.MultiSelect = false;
            this.m_panelEquipementsInclus.Name = "m_panelEquipementsInclus";
            this.m_panelEquipementsInclus.Navigateur = null;
            this.m_panelEquipementsInclus.ProprieteObjetAEditer = null;
            this.m_panelEquipementsInclus.QuickSearchText = "";
            this.m_panelEquipementsInclus.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipementsInclus.TabIndex = 0;
            this.m_panelEquipementsInclus.TrierAuClicSurEnteteColonne = true;
            this.m_panelEquipementsInclus.UseCheckBoxes = false;
            this.m_panelEquipementsInclus.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelEquipementsInclus_OnNewObjetDonnee);
            // 
            // pageFiche
            // 
            this.pageFiche.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.pageFiche, "");
            this.pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFiche, "");
            this.pageFiche.Name = "pageFiche";
            this.pageFiche.Selected = false;
            this.pageFiche.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageFiche.TabIndex = 10;
            this.pageFiche.Title = "Form|60";
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
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 7;
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 3;
            this.m_tabControl.SelectedTab = this.m_pageLiens;
            this.m_tabControl.Size = new System.Drawing.Size(792, 425);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFiche,
            this.pageContient,
            this.m_pageEquipement,
            this.m_pageLiens});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageLiens
            // 
            this.m_pageLiens.Controls.Add(this.m_panelListeLiens);
            this.m_extLinkField.SetLinkField(this.m_pageLiens, "");
            this.m_pageLiens.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLiens, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLiens, "ALIAISONS");
            this.m_pageLiens.Name = "m_pageLiens";
            this.m_pageLiens.Size = new System.Drawing.Size(776, 384);
            this.m_extStyle.SetStyleBackColor(this.m_pageLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLiens.TabIndex = 13;
            this.m_pageLiens.Title = "Links|30380";
            // 
            // m_panelListeLiens
            // 
            this.m_panelListeLiens.AllowArbre = true;
            this.m_panelListeLiens.AllowCustomisation = true;
            this.m_panelListeLiens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Libelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelListeLiens.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeLiens.ContexteUtilisation = "";
            this.m_panelListeLiens.ControlFiltreStandard = null;
            this.m_panelListeLiens.ElementSelectionne = null;
            this.m_panelListeLiens.EnableCustomisation = true;
            this.m_panelListeLiens.FiltreDeBase = null;
            this.m_panelListeLiens.FiltreDeBaseEnAjout = false;
            this.m_panelListeLiens.FiltrePrefere = null;
            this.m_panelListeLiens.FiltreRapide = null;
            this.m_panelListeLiens.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeLiens, "");
            this.m_panelListeLiens.ListeObjets = null;
            this.m_panelListeLiens.Location = new System.Drawing.Point(0, 3);
            this.m_panelListeLiens.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeLiens, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeLiens.ModeQuickSearch = false;
            this.m_panelListeLiens.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeLiens, "");
            this.m_panelListeLiens.MultiSelect = false;
            this.m_panelListeLiens.Name = "m_panelListeLiens";
            this.m_panelListeLiens.Navigateur = null;
            this.m_panelListeLiens.ProprieteObjetAEditer = null;
            this.m_panelListeLiens.QuickSearchText = "";
            this.m_panelListeLiens.Size = new System.Drawing.Size(756, 381);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeLiens, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeLiens.TabIndex = 0;
            this.m_panelListeLiens.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeLiens.UseCheckBoxes = false;
            this.m_panelListeLiens.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelListeLiens_OnNewObjetDonnee);
            // 
            // CFormEditionEquipementLogique
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.m_panelEnTete);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionEquipementLogique";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEquipementLogique_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEquipementLogique_OnMajChampsPage);
            this.Shown += new System.EventHandler(this.CFormEditionEquipementLogique_Shown);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelEnTete, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panelEnTete.ResumeLayout(false);
            this.m_panelEnTete.PerformLayout();
            this.m_pageEquipement.ResumeLayout(false);
            this.pageContient.ResumeLayout(false);
            this.pageFiche.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageLiens.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		
		#endregion

		public CFormEditionEquipementLogique()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEquipementLogique(CEquipementLogique eqpt)
			: base(eqpt)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEquipementLogique(CEquipementLogique eqpt, CListeObjetsDonnees liste)
			: base(eqpt, liste)
		{
			InitializeComponent();
		}

		private void CFormEditionEquipementLogique_Shown(object sender, EventArgs e)
		{
		}

		//-------------------------------------------------------------------------
		private CEquipementLogique EquipementLogique
		{
			get	{ return (CEquipementLogique)ObjetEdite; }
		}
		
		//-------------------------------------------------------------------------
		private CTypeEquipement m_lastType = null;
		private CSite m_lastSite = null;
		private CEquipementLogique m_lastParent = null;

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = CResultAErreur.True;

            // CE test est normalement fait par le base.InitChamps
            // Mais il est appelé à la fin de cette fonction, il faut le refaire ici
            if (!EquipementLogique.IsValide())
            {
                if (!Navigateur.AffichePagePrecedente())
                    Navigateur.AffichePageAccueil();
                return CResultAErreur.False;
            }

			AffecterTitre(I.T( "Logical equipment @1|20059", EquipementLogique.Libelle));

			if (EquipementLogique.IsNew() &&
				EquipementLogique.TypeEquipement == null)
				EquipementLogique.TypeEquipement = m_lastType;
			
			m_lastType = EquipementLogique.TypeEquipement;

			m_lastSite = EquipementLogique.Site;
			m_lastParent = EquipementLogique.EquipementLogiqueContenant;

			m_comboFamille.Init(
				typeof(CFamilleEquipement),
				"FamillesFilles",
				CFamilleEquipement.c_champIdParent,
				"Libelle",
				typeof(CFormEditionFamilleEquipement),
				null,
                new CFiltreData(CFamilleEquipement.c_champNoEquipment + "=@1", false));
			if (EquipementLogique.TypeEquipement != null)
				m_comboFamille.ElementSelectionne = EquipementLogique.TypeEquipement.Famille;

			
            InitComboTypeEquipement();
            InitComboSite();
			m_selectTypeEquipement.ElementSelectionne = EquipementLogique.TypeEquipement;

            
          

            ManageOnglets();

            // Ne pas remonter au début de la fonction
            result = base.MyInitChamps();
            
			return result;
		}

		//-------------------------------------------------------------------------
		private void InitComboSite()
		{
			m_selectSite.Init<CSite> ( 
				"Libelle",
                false);
			m_selectSite.ElementSelectionne = EquipementLogique.Site;
		}

        //-------------------------------------------------------------------------
        private void ManageOnglets()
        {

            if(EquipementLogique.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(pageFiche))
                    m_tabControl.TabPages.Remove(pageFiche);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(pageFiche))
                    m_tabControl.TabPages.Insert(0, pageFiche);
            }
        }



		private bool m_bIsInitialisingTypeEquipement = false;
		private void InitComboTypeEquipement()
		{
			m_bIsInitialisingTypeEquipement = true;
			CFamilleEquipement famille = (CFamilleEquipement)m_comboFamille.ElementSelectionne;
			CFiltreData filtreRapide = CFournisseurFiltreRapide.GetFiltreRapideForType(typeof(CTypeEquipement));
			if (famille != null)
			{
				filtreRapide = CFiltreData.GetAndFiltre ( filtreRapide, 
					new CFiltreDataAvance(
					CTypeEquipement.c_nomTable,
					CFamilleEquipement.c_nomTable + "." + CFamilleEquipement.c_champCodeComplet + " like @1",
					famille.CodeSystemeComplet + "%"));
			}
			if (EquipementLogique.EquipementLogiqueContenant != null)
			{
				CTypeEquipement[] typesPoss = EquipementLogique.EquipementLogiqueContenant.TypeEquipement.TousLesTypesIncluables;
				if (typesPoss.Length != 0)
				{
					string strIds = "";
					foreach (CTypeEquipement tPoss in typesPoss)
						strIds += tPoss.Id + ",";

					strIds = strIds.Substring(0, strIds.Length - 1);
					filtreRapide = CFiltreData.GetAndFiltre(filtreRapide,
						new CFiltreData(CTypeEquipement.c_champId + " in (" + strIds + ")"));
				}
			}

			m_txtSelectEquipementParent.ElementSelectionne = EquipementLogique.EquipementLogiqueContenant;
		
			m_selectTypeEquipement.Init<CTypeEquipement>(
				"Libelle",
				true);

			
			m_bIsInitialisingTypeEquipement = false;
		}


		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (result)
            {
                EquipementLogique.TypeEquipement = (CTypeEquipement)m_selectTypeEquipement.ElementSelectionne;
				EquipementLogique.Site = m_selectSite.ElementSelectionne as CSite;
				EquipementLogique.EquipementLogiqueContenant = m_txtSelectEquipementParent.ElementSelectionne as CEquipementLogique;
            }
			return result;
        }

		//-------------------------------------------------------------------------
		private void m_comboFamille_ElementSelectionneChanged(object sender, EventArgs e)
		{
			InitComboTypeEquipement();
		}

		//-------------------------------------------------------------------------
		private void m_cmbTypeEquipement_SelectedValueChanged(object sender, EventArgs e)
		{
			if (!m_bIsInitialisingTypeEquipement)
			{
				CTypeEquipement oldTypeEq = EquipementLogique.TypeEquipement;
				EquipementLogique.TypeEquipement = (CTypeEquipement)m_selectTypeEquipement.ElementSelectionne;
                ManageOnglets();
				m_panelChamps.ElementEdite = EquipementLogique;
				InitComboEquipementParent();
				m_panelEquipement.OnChangeTypeEquipementLogique(EquipementLogique);
			}

		}

		
		private CResultAErreur CFormEditionEquipementLogique_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == pageContient)
				{
					m_panelEquipementsInclus.InitFromListeObjets(
					EquipementLogique.EquipementsLogiquesContenus,
					typeof(CEquipementLogique),
					typeof(CFormEditionEquipementLogique),
					EquipementLogique,
					"EquipementLogiqueContenant");
				}
				
				else if (page == pageFiche)
				{
					m_panelChamps.ElementEdite = EquipementLogique;
				}
				else if (page == m_pageEquipement)
				{
					m_panelEquipement.InitChamps(EquipementLogique);
				}
              
                else if (page == m_pageLiens)
                {
                  m_panelListeLiens.InitFromListeObjets(
                  EquipementLogique.ListeLiens,
                  typeof(CLienReseau),
                  typeof(CFormEditionLienReseau),
                  EquipementLogique,
                  "Equipement1");
                }
              
			}

			return result;
		}

        

		private CResultAErreur CFormEditionEquipementLogique_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == pageFiche)
			{
				result = m_panelChamps.MAJ_Champs();
			}
			else if (page == m_pageEquipement)
			{
				result = m_panelEquipement.MajChamps();
			}
          
			return result;
		}

        private void m_panelEquipementsInclus_OnNewObjetDonnee(object sender, CObjetDonnee nouvelObjet, ref bool bCancel)
        {
            if (bCancel)
                return;
			CEquipementLogique nouveau = nouvelObjet as CEquipementLogique;
			if ( nouveau != null )
			{
				nouveau.EquipementLogiqueContenant = EquipementLogique;
				nouveau.Site = EquipementLogique.Site;
			}
		}

		private void m_selectSite_OnSelectedObjectChanged(object sender, EventArgs e)
		{
			InitComboEquipementParent();
		}

		private void InitComboEquipementParent()
		{
			CEquipementLogique lastParent = m_txtSelectEquipementParent.ElementSelectionne as CEquipementLogique;
			CSite site = m_selectSite.ElementSelectionne as CSite;
			CTypeEquipement typeEqpt = m_selectTypeEquipement.ElementSelectionne as CTypeEquipement;
			CFiltreData filtre = new CFiltreDataImpossible();
			m_txtSelectEquipementParent.LockEdition = true;
			if (site != null && typeEqpt != null)
			{
				StringBuilder bl = new System.Text.StringBuilder();
				foreach (CTypeEquipement typeEqptBoucle in typeEqpt.TousLesTypesIncluants)
				{
					bl.Append(typeEqptBoucle.Id);
					bl.Append(",");
				}
				string strTypes = bl.ToString();
				if (strTypes.Length != 0)
				{
					strTypes = strTypes.Substring(0,strTypes.Length - 1);
					filtre = new CFiltreData(CTypeEquipement.c_champId + " in (" +
						strTypes + ") and " + CSite.c_champId + "=@1", site.Id);
					m_txtSelectEquipementParent.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				}
			}

				
			m_txtSelectEquipementParent.InitAvecFiltreDeBase<CEquipementLogique>(
				"Libelle",
				filtre,
				true);
			m_txtSelectEquipementParent.ElementSelectionne = lastParent;
        }



        private void m_panelListeLiens_OnNewObjetDonnee(object sender, CObjetDonnee nouvelObjet, ref bool bCancel)
        {
            if (bCancel)
                return;
            CLienReseau lien = nouvelObjet as CLienReseau;
           
            if (lien != null)
            {
                lien.Element1 = EquipementLogique;
                CFiltreData filtreLien = new CFiltreData(CTypeLienReseau.c_champTypeElement1 + "=@1 ", typeof(CSite).ToString());
                CListeObjetsDonnees liste_type = new CListeObjetsDonnees(lien.ContexteDonnee, typeof(CTypeLienReseau));
                liste_type.Filtre = filtreLien;
                lien.TypeLienReseau = (CTypeLienReseau)liste_type[0];

            }
       }
	}
}

