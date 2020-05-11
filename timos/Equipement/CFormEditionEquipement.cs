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
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CEquipement))]
	public class CFormEditionEquipement : CFormEditionStdTimos, IFormNavigable
	{
		#region Designer generated code
		private sc2i.win32.common.C2iPanelOmbre m_panelEnTete;
		private C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage pageFiche;
		private Label label3;
		private Label label2;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private CComboBoxArbreObjetDonneesHierarchique m_comboFamille;
		private C2iTextBox c2iTextBox2;
		private Label label19;
		private Crownwood.Magic.Controls.TabPage pageContient;
		private CPanelListeSpeedStandard m_panelEquipementsInclus;
		private Crownwood.Magic.Controls.TabPage pageLocation;
		private Label label4;
		private CComboBoxLinkListeObjetsDonnees m_cmbStatut;
		private LinkLabel m_lnkEmplacement;
		private TreeView m_arbreEquipementParent;
		private PictureBox pictureBox5;
		private CPanelListeSpeedStandard m_panelMouvements;
		private Label label5;
		private Label m_lblTitreMouvements;
		private LinkLabel m_lnkDeplacer;
		private Crownwood.Magic.Controls.TabPage pageContraintes;
		private CPanelListeSpeedStandard m_panelListeContraintes;
		private Crownwood.Magic.Controls.TabPage pageParamCtrlCoor;
		private CComboBoxLinkListeObjetsDonnees m_cmbxSelectRefConstructeur;
		private Label label7;
		private timos.coordonnees.CControlEditionObjetAOccupation m_panelOccupation;
		private CControleEditeObjetASystemeCoordonnee m_panelSystemeCoordonnees;
		private CControleEditionOptionsControleCoordonnees m_panelOptionControle;
		private Label Label234;
		private timos.coordonnees.CControlEditeCoordonnee m_controleCoordonnee;
		private C2iPanel m_panelCoordonnees;
		private Panel m_panelEmplacementDansSite;
		private Panel m_panelEquipementParent;
		private Panel panel4;
		private Panel m_panelTop;
		private C2iTextBoxSelectionne m_selectTypeEquipement;
		private Crownwood.Magic.Controls.TabPage pageTablesParametrables;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private CPanelListeSpeedStandard m_panListeTableParametrables;
		private timos.CWaiteurPourFormTimos cWaiteurPourFormTimos1;
		private C2iPanelFondDegradeStd c2iPanelFondDegradeStd1;
		private Crownwood.Magic.Controls.TabPage m_pageFonction;
        private timos.Equipement.CPanelEquipementLogiqueDeUnEquipement m_panelEquipementLogique;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionEquipement));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            this.m_panelEnTete = new sc2i.win32.common.C2iPanelOmbre();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.m_selectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_comboFamille = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_cmbxSelectRefConstructeur = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label7 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageLocation = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.c2iPanelFondDegradeStd1 = new sc2i.win32.common.C2iPanelFondDegradeStd();
            this.m_lblTitreMouvements = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.m_panelMouvements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelEmplacementDansSite = new System.Windows.Forms.Panel();
            this.m_panelCoordonnees = new sc2i.win32.common.C2iPanel(this.components);
            this.m_controleCoordonnee = new timos.coordonnees.CControlEditeCoordonnee();
            this.Label234 = new System.Windows.Forms.Label();
            this.m_panelEquipementParent = new System.Windows.Forms.Panel();
            this.m_arbreEquipementParent = new System.Windows.Forms.TreeView();
            this.m_lnkDeplacer = new System.Windows.Forms.LinkLabel();
            this.m_cmbStatut = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_lnkEmplacement = new System.Windows.Forms.LinkLabel();
            this.m_panelOccupation = new timos.coordonnees.CControlEditionObjetAOccupation();
            this.pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageFonction = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipementLogique = new timos.Equipement.CPanelEquipementLogiqueDeUnEquipement();
            this.pageContient = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEquipementsInclus = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeContraintes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageParamCtrlCoor = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSystemeCoordonnees = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_panelOptionControle = new timos.CControleEditionOptionsControleCoordonnees();
            this.pageTablesParametrables = new Crownwood.Magic.Controls.TabPage();
            this.m_panListeTableParametrables = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.cWaiteurPourFormTimos1 = new timos.CWaiteurPourFormTimos();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panelEnTete.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.pageLocation.SuspendLayout();
            this.panel4.SuspendLayout();
            this.c2iPanelFondDegradeStd1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.m_panelTop.SuspendLayout();
            this.m_panelEmplacementDansSite.SuspendLayout();
            this.m_panelCoordonnees.SuspendLayout();
            this.m_panelEquipementParent.SuspendLayout();
            this.pageFiche.SuspendLayout();
            this.m_pageFonction.SuspendLayout();
            this.pageContient.SuspendLayout();
            this.pageContraintes.SuspendLayout();
            this.pageParamCtrlCoor.SuspendLayout();
            this.pageTablesParametrables.SuspendLayout();
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
            this.m_panelEnTete.Controls.Add(this.label2);
            this.m_panelEnTete.Controls.Add(this.label3);
            this.m_panelEnTete.Controls.Add(this.label19);
            this.m_panelEnTete.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelEnTete.Controls.Add(this.c2iTextBox2);
            this.m_panelEnTete.Controls.Add(this.m_comboFamille);
            this.m_panelEnTete.Controls.Add(this.m_cmbxSelectRefConstructeur);
            this.m_panelEnTete.Controls.Add(this.label7);
            this.m_panelEnTete.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEnTete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEnTete, false);
            this.m_panelEnTete.Location = new System.Drawing.Point(8, 52);
            this.m_panelEnTete.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEnTete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEnTete, "");
            this.m_panelEnTete.Name = "m_panelEnTete";
            this.m_panelEnTete.Size = new System.Drawing.Size(792, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEnTete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnTete.TabIndex = 0;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(4, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Equipment type|194";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Equipment family|193";
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label19, false);
            this.label19.Location = new System.Drawing.Point(5, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label19, "");
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 17);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 9;
            this.label19.Text = "Serial Number|223";
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeEquipement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectTypeEquipement, false);
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(129, 52);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(250, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeEquipement.TabIndex = 4014;
            this.m_selectTypeEquipement.TextNull = "";
            this.m_selectTypeEquipement.Load += new System.EventHandler(this.m_selectTypeEquipement_Load);
            this.m_selectTypeEquipement.ElementSelectionneChanged += new System.EventHandler(this.m_cmbTypeEquipement_SelectedValueChanged);
            // 
            // c2iTextBox2
            // 
            this.c2iTextBox2.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "NumSerie");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox2, true);
            this.c2iTextBox2.Location = new System.Drawing.Point(129, 5);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(250, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 10;
            this.c2iTextBox2.Text = "[NumSerie]";
            // 
            // m_comboFamille
            // 
            this.m_comboFamille.AutoriserFilsDeAutorises = true;
            this.m_comboFamille.BackColor = System.Drawing.Color.White;
            this.m_comboFamille.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_comboFamille, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_comboFamille, false);
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
            // m_cmbxSelectRefConstructeur
            // 
            this.m_cmbxSelectRefConstructeur.ComportementLinkStd = true;
            this.m_cmbxSelectRefConstructeur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectRefConstructeur.ElementSelectionne = null;
            this.m_cmbxSelectRefConstructeur.FormattingEnabled = true;
            this.m_cmbxSelectRefConstructeur.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectRefConstructeur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxSelectRefConstructeur, false);
            this.m_cmbxSelectRefConstructeur.LinkProperty = "";
            this.m_cmbxSelectRefConstructeur.ListDonnees = null;
            this.m_cmbxSelectRefConstructeur.Location = new System.Drawing.Point(543, 5);
            this.m_cmbxSelectRefConstructeur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectRefConstructeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectRefConstructeur, "");
            this.m_cmbxSelectRefConstructeur.Name = "m_cmbxSelectRefConstructeur";
            this.m_cmbxSelectRefConstructeur.NullAutorise = false;
            this.m_cmbxSelectRefConstructeur.ProprieteAffichee = null;
            this.m_cmbxSelectRefConstructeur.ProprieteParentListeObjets = null;
            this.m_cmbxSelectRefConstructeur.SelectionneurParent = null;
            this.m_cmbxSelectRefConstructeur.Size = new System.Drawing.Size(220, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectRefConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectRefConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectRefConstructeur.TabIndex = 4013;
            this.m_cmbxSelectRefConstructeur.TextNull = "(empty)";
            this.m_cmbxSelectRefConstructeur.Tri = true;
            this.m_cmbxSelectRefConstructeur.TypeFormEdition = null;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(394, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 17);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4003;
            this.label7.Text = "Manufacturer Reference|465";
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabControl, false);
            this.m_tabControl.Location = new System.Drawing.Point(8, 158);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.pageFiche;
            this.m_tabControl.Size = new System.Drawing.Size(792, 416);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFiche,
            this.pageLocation,
            this.m_pageFonction,
            this.pageContient,
            this.pageContraintes,
            this.pageParamCtrlCoor,
            this.pageTablesParametrables});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageLocation
            // 
            this.pageLocation.Controls.Add(this.panel4);
            this.pageLocation.Controls.Add(this.m_panelTop);
            this.m_extLinkField.SetLinkField(this.pageLocation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageLocation, false);
            this.pageLocation.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageLocation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageLocation, "");
            this.pageLocation.Name = "pageLocation";
            this.pageLocation.Selected = false;
            this.pageLocation.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.pageLocation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageLocation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageLocation.TabIndex = 12;
            this.pageLocation.Title = "Location|228";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.c2iPanelFondDegradeStd1);
            this.panel4.Controls.Add(this.pictureBox5);
            this.panel4.Controls.Add(this.m_panelMouvements);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.panel4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel4, false);
            this.panel4.Location = new System.Drawing.Point(0, 125);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel4, "");
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(776, 250);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 4023;
            // 
            // c2iPanelFondDegradeStd1
            // 
            this.c2iPanelFondDegradeStd1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("c2iPanelFondDegradeStd1.BackgroundImage")));
            this.c2iPanelFondDegradeStd1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.c2iPanelFondDegradeStd1.Controls.Add(this.m_lblTitreMouvements);
            this.m_extLinkField.SetLinkField(this.c2iPanelFondDegradeStd1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelFondDegradeStd1, false);
            this.c2iPanelFondDegradeStd1.Location = new System.Drawing.Point(96, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelFondDegradeStd1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelFondDegradeStd1, "");
            this.c2iPanelFondDegradeStd1.Name = "c2iPanelFondDegradeStd1";
            this.c2iPanelFondDegradeStd1.Size = new System.Drawing.Size(192, 24);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelFondDegradeStd1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanelFondDegradeStd1.TabIndex = 4023;
            // 
            // m_lblTitreMouvements
            // 
            this.m_lblTitreMouvements.AutoSize = true;
            this.m_lblTitreMouvements.BackColor = System.Drawing.Color.Transparent;
            this.m_lblTitreMouvements.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitreMouvements.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_lblTitreMouvements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblTitreMouvements, false);
            this.m_lblTitreMouvements.Location = new System.Drawing.Point(7, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTitreMouvements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTitreMouvements, "");
            this.m_lblTitreMouvements.Name = "m_lblTitreMouvements";
            this.m_lblTitreMouvements.Size = new System.Drawing.Size(162, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblTitreMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTitreMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTitreMouvements.TabIndex = 4022;
            this.m_lblTitreMouvements.Text = "Mouvements|1226";
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.pictureBox5.Location = new System.Drawing.Point(-1, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(630, 1);
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 4021;
            this.pictureBox5.TabStop = false;
            // 
            // m_panelMouvements
            // 
            this.m_panelMouvements.AllowArbre = true;
            this.m_panelMouvements.AllowCustomisation = true;
            this.m_panelMouvements.BoutonAjouterVisible = false;
            this.m_panelMouvements.BoutonExporterVisible = false;
            this.m_panelMouvements.BoutonModifierVisible = false;
            this.m_panelMouvements.BoutonSupprimerVisible = false;
            this.m_panelMouvements.CausesValidation = false;
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "m_colonneMvtDate";
            glColumn1.Propriete = "DateMouvement";
            glColumn1.Text = "Mouvement date|1227";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            glColumn2.ActiveControlItems = null;
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "m_colonneMvtOrigine";
            glColumn2.Propriete = "EmplacementOrigine.DescriptionElement";
            glColumn2.Text = "Origin location|1228";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 300;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "m_colonneMvtEquiptOrigine";
            glColumn3.Propriete = "EquipementOrigine.Libelle";
            glColumn3.Text = "Origin container equipment|1229";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 200;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "m_colonneMvtDestination";
            glColumn4.Propriete = "EmplacementDestination.Libelle";
            glColumn4.Text = "Destination location|10038";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.m_panelMouvements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2,
            glColumn3,
            glColumn4});
            this.m_panelMouvements.ContexteUtilisation = "";
            this.m_panelMouvements.ControlFiltreStandard = null;
            this.m_panelMouvements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMouvements.ElementSelectionne = null;
            this.m_panelMouvements.EnableCustomisation = true;
            this.m_panelMouvements.FiltreDeBase = null;
            this.m_panelMouvements.FiltreDeBaseEnAjout = false;
            this.m_panelMouvements.FiltrePrefere = null;
            this.m_panelMouvements.FiltreRapide = null;
            this.m_panelMouvements.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelMouvements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMouvements, false);
            this.m_panelMouvements.ListeObjets = null;
            this.m_panelMouvements.Location = new System.Drawing.Point(0, 0);
            this.m_panelMouvements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMouvements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMouvements.ModeQuickSearch = false;
            this.m_panelMouvements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelMouvements, "");
            this.m_panelMouvements.MultiSelect = false;
            this.m_panelMouvements.Name = "m_panelMouvements";
            this.m_panelMouvements.Navigateur = null;
            this.m_panelMouvements.ProprieteObjetAEditer = null;
            this.m_panelMouvements.QuickSearchText = "";
            this.m_panelMouvements.Size = new System.Drawing.Size(776, 250);
            this.m_extStyle.SetStyleBackColor(this.m_panelMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMouvements.TabIndex = 4020;
            this.m_panelMouvements.TrierAuClicSurEnteteColonne = true;
            this.m_panelMouvements.UseCheckBoxes = false;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.label4);
            this.m_panelTop.Controls.Add(this.label5);
            this.m_panelTop.Controls.Add(this.m_panelEmplacementDansSite);
            this.m_panelTop.Controls.Add(this.m_lnkDeplacer);
            this.m_panelTop.Controls.Add(this.m_cmbStatut);
            this.m_panelTop.Controls.Add(this.m_lnkEmplacement);
            this.m_panelTop.Controls.Add(this.m_panelOccupation);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTop, false);
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelTop, "");
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(776, 125);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 4028;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Equipment Status|230";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(7, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4019;
            this.label5.Text = "Location|228";
            // 
            // m_panelEmplacementDansSite
            // 
            this.m_panelEmplacementDansSite.Controls.Add(this.m_panelCoordonnees);
            this.m_panelEmplacementDansSite.Controls.Add(this.m_panelEquipementParent);
            this.m_extLinkField.SetLinkField(this.m_panelEmplacementDansSite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEmplacementDansSite, false);
            this.m_panelEmplacementDansSite.Location = new System.Drawing.Point(8, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEmplacementDansSite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEmplacementDansSite, "");
            this.m_panelEmplacementDansSite.Name = "m_panelEmplacementDansSite";
            this.m_panelEmplacementDansSite.Size = new System.Drawing.Size(768, 41);
            this.m_extStyle.SetStyleBackColor(this.m_panelEmplacementDansSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEmplacementDansSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEmplacementDansSite.TabIndex = 4027;
            // 
            // m_panelCoordonnees
            // 
            this.m_panelCoordonnees.Controls.Add(this.m_controleCoordonnee);
            this.m_panelCoordonnees.Controls.Add(this.Label234);
            this.m_panelCoordonnees.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelCoordonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCoordonnees, false);
            this.m_panelCoordonnees.Location = new System.Drawing.Point(330, 0);
            this.m_panelCoordonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelCoordonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelCoordonnees, "ASYS_COOR");
            this.m_panelCoordonnees.Name = "m_panelCoordonnees";
            this.m_panelCoordonnees.Size = new System.Drawing.Size(425, 41);
            this.m_extStyle.SetStyleBackColor(this.m_panelCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelCoordonnees.TabIndex = 4026;
            // 
            // m_controleCoordonnee
            // 
            this.m_controleCoordonnee.Coordonnee = "";
            this.m_extLinkField.SetLinkField(this.m_controleCoordonnee, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_controleCoordonnee, false);
            this.m_controleCoordonnee.Location = new System.Drawing.Point(93, 4);
            this.m_controleCoordonnee.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controleCoordonnee, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controleCoordonnee, "");
            this.m_controleCoordonnee.Name = "m_controleCoordonnee";
            this.m_controleCoordonnee.Size = new System.Drawing.Size(329, 21);
            this.m_extStyle.SetStyleBackColor(this.m_controleCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controleCoordonnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleCoordonnee.TabIndex = 4024;
            // 
            // Label234
            // 
            this.m_extLinkField.SetLinkField(this.Label234, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.Label234, false);
            this.Label234.Location = new System.Drawing.Point(6, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.Label234, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.Label234, "");
            this.Label234.Name = "Label234";
            this.Label234.Size = new System.Drawing.Size(107, 21);
            this.m_extStyle.SetStyleBackColor(this.Label234, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.Label234, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Label234.TabIndex = 4025;
            this.Label234.Text = "Coordinate|446";
            // 
            // m_panelEquipementParent
            // 
            this.m_panelEquipementParent.Controls.Add(this.m_arbreEquipementParent);
            this.m_panelEquipementParent.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelEquipementParent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEquipementParent, false);
            this.m_panelEquipementParent.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipementParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEquipementParent, "");
            this.m_panelEquipementParent.Name = "m_panelEquipementParent";
            this.m_panelEquipementParent.Size = new System.Drawing.Size(330, 41);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipementParent.TabIndex = 4027;
            // 
            // m_arbreEquipementParent
            // 
            this.m_arbreEquipementParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_arbreEquipementParent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_arbreEquipementParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreEquipementParent.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_arbreEquipementParent.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_arbreEquipementParent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_arbreEquipementParent, false);
            this.m_arbreEquipementParent.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreEquipementParent, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreEquipementParent, "");
            this.m_arbreEquipementParent.Name = "m_arbreEquipementParent";
            this.m_arbreEquipementParent.Size = new System.Drawing.Size(330, 41);
            this.m_extStyle.SetStyleBackColor(this.m_arbreEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_arbreEquipementParent, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_arbreEquipementParent.TabIndex = 4018;
            this.m_arbreEquipementParent.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_arbreEquipementParent_MouseMove);
            this.m_arbreEquipementParent.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_arbreEquipementParent_MouseDown);
            // 
            // m_lnkDeplacer
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkDeplacer, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDeplacer, false);
            this.m_lnkDeplacer.Location = new System.Drawing.Point(7, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeplacer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeplacer, "");
            this.m_lnkDeplacer.Name = "m_lnkDeplacer";
            this.m_lnkDeplacer.Size = new System.Drawing.Size(281, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeplacer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeplacer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeplacer.TabIndex = 4023;
            this.m_lnkDeplacer.TabStop = true;
            this.m_lnkDeplacer.Text = "Move this equipment|240";
            this.m_lnkDeplacer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDeplacer_LinkClicked);
            // 
            // m_cmbStatut
            // 
            this.m_cmbStatut.ComportementLinkStd = true;
            this.m_cmbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbStatut.ElementSelectionne = null;
            this.m_cmbStatut.FormattingEnabled = true;
            this.m_cmbStatut.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbStatut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbStatut, false);
            this.m_cmbStatut.LinkProperty = "";
            this.m_cmbStatut.ListDonnees = null;
            this.m_cmbStatut.Location = new System.Drawing.Point(152, 7);
            this.m_cmbStatut.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbStatut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbStatut, "");
            this.m_cmbStatut.Name = "m_cmbStatut";
            this.m_cmbStatut.NullAutorise = false;
            this.m_cmbStatut.ProprieteAffichee = null;
            this.m_cmbStatut.ProprieteParentListeObjets = null;
            this.m_cmbStatut.SelectionneurParent = null;
            this.m_cmbStatut.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbStatut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbStatut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbStatut.TabIndex = 4014;
            this.m_cmbStatut.TextNull = "(empty)";
            this.m_cmbStatut.Tri = true;
            this.m_cmbStatut.TypeFormEdition = null;
            // 
            // m_lnkEmplacement
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkEmplacement, "Emplacement.DescriptionElement");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkEmplacement, true);
            this.m_lnkEmplacement.Location = new System.Drawing.Point(120, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEmplacement, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkEmplacement, "");
            this.m_lnkEmplacement.Name = "m_lnkEmplacement";
            this.m_lnkEmplacement.Size = new System.Drawing.Size(281, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEmplacement.TabIndex = 4017;
            this.m_lnkEmplacement.TabStop = true;
            this.m_lnkEmplacement.Text = "[Emplacement.DescriptionElement]";
            this.m_lnkEmplacement.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEmplacement_LinkClicked);
            // 
            // m_panelOccupation
            // 
            this.m_panelOccupation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOccupation.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelOccupation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelOccupation, false);
            this.m_panelOccupation.Location = new System.Drawing.Point(420, 3);
            this.m_panelOccupation.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOccupation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelOccupation, "ASYS_COOR");
            this.m_panelOccupation.Name = "m_panelOccupation";
            this.m_panelOccupation.Size = new System.Drawing.Size(356, 66);
            this.m_extStyle.SetStyleBackColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOccupation.TabIndex = 8;
            this.m_panelOccupation.OnChangeOccupation += new System.EventHandler(this.m_panelOccupation_OnChangeOccupation);
            // 
            // pageFiche
            // 
            this.pageFiche.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.pageFiche, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageFiche, false);
            this.pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFiche, "");
            this.pageFiche.Name = "pageFiche";
            this.pageFiche.Size = new System.Drawing.Size(776, 375);
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 7;
            // 
            // m_pageFonction
            // 
            this.m_pageFonction.Controls.Add(this.m_panelEquipementLogique);
            this.m_extLinkField.SetLinkField(this.m_pageFonction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFonction, false);
            this.m_pageFonction.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFonction, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFonction, "");
            this.m_pageFonction.Name = "m_pageFonction";
            this.m_pageFonction.Selected = false;
            this.m_pageFonction.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFonction.TabIndex = 16;
            this.m_pageFonction.Title = "Logical equipment|20067";
            // 
            // m_panelEquipementLogique
            // 
            this.m_panelEquipementLogique.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelEquipementLogique.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEquipementLogique.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelEquipementLogique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEquipementLogique, false);
            this.m_panelEquipementLogique.Location = new System.Drawing.Point(0, 0);
            this.m_panelEquipementLogique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEquipementLogique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEquipementLogique, "");
            this.m_panelEquipementLogique.Name = "m_panelEquipementLogique";
            this.m_panelEquipementLogique.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipementLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipementLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipementLogique.TabIndex = 10;
            // 
            // pageContient
            // 
            this.pageContient.Controls.Add(this.m_panelEquipementsInclus);
            this.m_extLinkField.SetLinkField(this.pageContient, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageContient, false);
            this.pageContient.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageContient, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageContient, "");
            this.pageContient.Name = "pageContient";
            this.pageContient.Selected = false;
            this.pageContient.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.pageContient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageContient, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageContient.TabIndex = 11;
            this.pageContient.Title = "Contains|224";
            // 
            // m_panelEquipementsInclus
            // 
            this.m_panelEquipementsInclus.AllowArbre = true;
            this.m_panelEquipementsInclus.AllowCustomisation = true;
            this.m_panelEquipementsInclus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn5.ActiveControlItems = null;
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Name";
            glColumn5.Propriete = "TypeEquipement.Libelle";
            glColumn5.Text = "Equipment type|194";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 250;
            glColumn6.ActiveControlItems = null;
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Namex";
            glColumn6.Propriete = "NumSerie";
            glColumn6.Text = "Serial Number|223";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 100;
            this.m_panelEquipementsInclus.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn5,
            glColumn6});
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEquipementsInclus, false);
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
            this.m_panelEquipementsInclus.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEquipementsInclus.TabIndex = 0;
            this.m_panelEquipementsInclus.TrierAuClicSurEnteteColonne = true;
            this.m_panelEquipementsInclus.UseCheckBoxes = false;
            this.m_panelEquipementsInclus.OnNewObjetDonnee += new sc2i.win32.data.navigation.OnNewObjetDonneeEventHandler(this.m_panelEquipementsInclus_OnNewObjetDonnee);
            // 
            // pageContraintes
            // 
            this.pageContraintes.Controls.Add(this.m_panelListeContraintes);
            this.m_extLinkField.SetLinkField(this.pageContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageContraintes, false);
            this.pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageContraintes, "");
            this.pageContraintes.Name = "pageContraintes";
            this.pageContraintes.Selected = false;
            this.pageContraintes.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageContraintes.TabIndex = 13;
            this.pageContraintes.Title = "Constraints|255";
            // 
            // m_panelListeContraintes
            // 
            this.m_panelListeContraintes.AllowArbre = true;
            this.m_panelListeContraintes.AllowCustomisation = true;
            this.m_panelListeContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn7.ActiveControlItems = null;
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "ColumnLabel";
            glColumn7.Propriete = "Libelle";
            glColumn7.Text = "Label|50";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 100;
            this.m_panelListeContraintes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn7});
            this.m_panelListeContraintes.ContexteUtilisation = "";
            this.m_panelListeContraintes.ControlFiltreStandard = null;
            this.m_panelListeContraintes.ElementSelectionne = null;
            this.m_panelListeContraintes.EnableCustomisation = true;
            this.m_panelListeContraintes.FiltreDeBase = null;
            this.m_panelListeContraintes.FiltreDeBaseEnAjout = false;
            this.m_panelListeContraintes.FiltrePrefere = null;
            this.m_panelListeContraintes.FiltreRapide = null;
            this.m_panelListeContraintes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeContraintes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeContraintes, false);
            this.m_panelListeContraintes.ListeObjets = null;
            this.m_panelListeContraintes.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeContraintes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeContraintes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeContraintes.ModeQuickSearch = false;
            this.m_panelListeContraintes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeContraintes, "");
            this.m_panelListeContraintes.MultiSelect = false;
            this.m_panelListeContraintes.Name = "m_panelListeContraintes";
            this.m_panelListeContraintes.Navigateur = null;
            this.m_panelListeContraintes.ProprieteObjetAEditer = null;
            this.m_panelListeContraintes.QuickSearchText = "";
            this.m_panelListeContraintes.Size = new System.Drawing.Size(776, 385);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeContraintes.TabIndex = 1;
            this.m_panelListeContraintes.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeContraintes.UseCheckBoxes = false;
            // 
            // pageParamCtrlCoor
            // 
            this.pageParamCtrlCoor.Controls.Add(this.m_panelSystemeCoordonnees);
            this.pageParamCtrlCoor.Controls.Add(this.m_panelOptionControle);
            this.m_extLinkField.SetLinkField(this.pageParamCtrlCoor, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageParamCtrlCoor, false);
            this.pageParamCtrlCoor.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageParamCtrlCoor, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageParamCtrlCoor, "ASYS_COOR");
            this.pageParamCtrlCoor.Name = "pageParamCtrlCoor";
            this.pageParamCtrlCoor.Selected = false;
            this.pageParamCtrlCoor.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.pageParamCtrlCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageParamCtrlCoor, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageParamCtrlCoor.TabIndex = 14;
            this.pageParamCtrlCoor.Title = "Coordinates System Parameters|460";
            // 
            // m_panelSystemeCoordonnees
            // 
            this.m_panelSystemeCoordonnees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelSystemeCoordonnees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSystemeCoordonnees, false);
            this.m_panelSystemeCoordonnees.Location = new System.Drawing.Point(0, 102);
            this.m_panelSystemeCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Name = "m_panelSystemeCoordonnees";
            this.m_panelSystemeCoordonnees.Size = new System.Drawing.Size(773, 266);
            this.m_extStyle.SetStyleBackColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSystemeCoordonnees.TabIndex = 1;
            this.m_panelSystemeCoordonnees.OnChangeSystemeCoordonnee += new System.EventHandler(this.m_panelSystemeCoordonnees_OnChangeSystemeCoordonnee);
            // 
            // m_panelOptionControle
            // 
            this.m_panelOptionControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOptionControle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelOptionControle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelOptionControle.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panelOptionControle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelOptionControle, false);
            this.m_panelOptionControle.Location = new System.Drawing.Point(0, 0);
            this.m_panelOptionControle.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOptionControle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelOptionControle, "");
            this.m_panelOptionControle.Name = "m_panelOptionControle";
            this.m_panelOptionControle.Size = new System.Drawing.Size(776, 99);
            this.m_extStyle.SetStyleBackColor(this.m_panelOptionControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOptionControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOptionControle.TabIndex = 0;
            // 
            // pageTablesParametrables
            // 
            this.pageTablesParametrables.Controls.Add(this.m_panListeTableParametrables);
            this.m_extLinkField.SetLinkField(this.pageTablesParametrables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageTablesParametrables, false);
            this.pageTablesParametrables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageTablesParametrables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageTablesParametrables, "ATABLES_PARAM");
            this.pageTablesParametrables.Name = "pageTablesParametrables";
            this.pageTablesParametrables.Selected = false;
            this.pageTablesParametrables.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageTablesParametrables.TabIndex = 15;
            this.pageTablesParametrables.Title = "Custom Tables|1195";
            // 
            // m_panListeTableParametrables
            // 
            this.m_panListeTableParametrables.AllowArbre = true;
            this.m_panListeTableParametrables.AllowCustomisation = true;
            glColumn8.ActiveControlItems = null;
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Name";
            glColumn8.Propriete = "Libelle";
            glColumn8.Text = "Label|50";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            this.m_panListeTableParametrables.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn8});
            this.m_panListeTableParametrables.ContexteUtilisation = "";
            this.m_panListeTableParametrables.ControlFiltreStandard = null;
            this.m_panListeTableParametrables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panListeTableParametrables.ElementSelectionne = null;
            this.m_panListeTableParametrables.EnableCustomisation = true;
            this.m_panListeTableParametrables.FiltreDeBase = null;
            this.m_panListeTableParametrables.FiltreDeBaseEnAjout = false;
            this.m_panListeTableParametrables.FiltrePrefere = null;
            this.m_panListeTableParametrables.FiltreRapide = null;
            this.m_panListeTableParametrables.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panListeTableParametrables, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panListeTableParametrables, false);
            this.m_panListeTableParametrables.ListeObjets = null;
            this.m_panListeTableParametrables.Location = new System.Drawing.Point(0, 0);
            this.m_panListeTableParametrables.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panListeTableParametrables, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panListeTableParametrables.ModeQuickSearch = false;
            this.m_panListeTableParametrables.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panListeTableParametrables, "");
            this.m_panListeTableParametrables.MultiSelect = false;
            this.m_panListeTableParametrables.Name = "m_panListeTableParametrables";
            this.m_panListeTableParametrables.Navigateur = null;
            this.m_panListeTableParametrables.ProprieteObjetAEditer = null;
            this.m_panListeTableParametrables.QuickSearchText = "";
            this.m_panListeTableParametrables.Size = new System.Drawing.Size(776, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panListeTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panListeTableParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panListeTableParametrables.TabIndex = 0;
            this.m_panListeTableParametrables.TrierAuClicSurEnteteColonne = true;
            this.m_panListeTableParametrables.UseCheckBoxes = false;
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
            // CFormEditionEquipement
            // 
            this.ClientSize = new System.Drawing.Size(800, 586);
            this.Controls.Add(this.m_panelEnTete);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionEquipement";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEquipement_OnInitPage);
            this.BeforeValideModification += new sc2i.data.ObjetDonneeCancelEventHandler(this.CFormEditionEquipement_BeforeValideModification);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionEquipement_OnMajChampsPage);
            this.Shown += new System.EventHandler(this.CFormEditionEquipement_Shown);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageLocation.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.ResumeLayout(false);
            this.c2iPanelFondDegradeStd1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.m_panelTop.ResumeLayout(false);
            this.m_panelEmplacementDansSite.ResumeLayout(false);
            this.m_panelCoordonnees.ResumeLayout(false);
            this.m_panelEquipementParent.ResumeLayout(false);
            this.pageFiche.ResumeLayout(false);
            this.m_pageFonction.ResumeLayout(false);
            this.pageContient.ResumeLayout(false);
            this.pageContraintes.ResumeLayout(false);
            this.pageParamCtrlCoor.ResumeLayout(false);
            this.pageTablesParametrables.ResumeLayout(false);
            this.ResumeLayout(false);

		}


		#endregion

		public CFormEditionEquipement()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEquipement(CEquipement civilite)
			: base(civilite)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionEquipement(CEquipement civilite, CListeObjetsDonnees liste)
			: base(civilite, liste)
		{
			InitializeComponent();
		}

		private void CFormEditionEquipement_Shown(object sender, EventArgs e)
		{
		}

		//-------------------------------------------------------------------------
		private CEquipement Equipement
		{
			get { return (CEquipement)ObjetEdite; }
		}

		//-------------------------------------------------------------------------
		private CTypeEquipement m_lastType = null;
		private IEmplacementEquipement m_lastEmplacement = null;
		private CEquipement m_lastParent = null;

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			CResultAErreur result = CResultAErreur.True;

			// CE test est normalement fait par le base.InitChamps
			// Mais il est appelé à la fin de cette fonction, il faut le refaire ici
			if (!Equipement.IsValide())
			{
				if (!Navigateur.AffichePagePrecedente())
					Navigateur.AffichePageAccueil();
				return CResultAErreur.False;
			}

			AffecterTitre(I.T("Equipment|195") + " " + Equipement.Libelle);

			if (Equipement.IsNew() &&
				Equipement.TypeEquipement == null)
				Equipement.TypeEquipement = m_lastType;
			m_lastType = Equipement.TypeEquipement;

			if (Equipement.IsNew() &&
				Equipement.Emplacement == null &&
				Equipement.EquipementContenant == null)
				Equipement.DeplaceEquipement("", m_lastEmplacement, m_lastParent, null, null, null, DateTime.Now, "");

			m_lastEmplacement = Equipement.Emplacement;
			m_lastParent = Equipement.EquipementContenant;

			if (Equipement.Emplacement == null)
				m_lnkDeplacer.Text = I.T("Set initial location|318");
			else
				m_lnkDeplacer.Text = I.T("Move this equipment|240");
			m_comboFamille.Init(
				typeof(CFamilleEquipement),
				"FamillesFilles",
				CFamilleEquipement.c_champIdParent,
				"Libelle",
				typeof(CFormEditionFamilleEquipement),
				null,
				new CFiltreData ( CFamilleEquipement.c_champNoEquipment+"=@1", false));
			if (Equipement.TypeEquipement != null)
				m_comboFamille.ElementSelectionne = Equipement.TypeEquipement.Famille;


			InitComboTypeEquipement();
			m_selectTypeEquipement.ElementSelectionne = Equipement.TypeEquipement;
			InitComboRefConstructeur();
			m_cmbxSelectRefConstructeur.ElementSelectionne = Equipement.RelationConstructeur;


			ManageOnglets();

			// Ne pas remonter au début de la fonction
            result = base.MyInitChamps();

			return result;
		}

		//-------------------------------------------------------------------------
		private void ManageOnglets()
		{

			if (Equipement.GetFormulaires().Length == 0)
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


		//-------------------------------------------------------------------------
		private TreeNode CreateNode(CEquipement equipement)
		{
			TreeNodeCollection nodes = m_arbreEquipementParent.Nodes;
			if (equipement.EquipementContenant != null)
				nodes = CreateNode(equipement.EquipementContenant).Nodes;
			TreeNode newNode = new TreeNode(equipement.Libelle);
			newNode.Tag = equipement;
            nodes.Add(newNode);
            if (newNode.Parent != null)
                newNode.Parent.Expand();
			return newNode;
		}


		//-------------------------------------------------------------------------
		private bool m_bIsInitialisingTypeEquipement;
		private void InitTablesParametrables()
		{
			m_panListeTableParametrables.InitFromListeObjets(
				Equipement.TablesParametrables,
				typeof(CTableParametrable),
				typeof(CFormEditionTableParametrable),
				Equipement,
				"Equipement");
		}

		private void InitComboTypeEquipement()
		{
			m_bIsInitialisingTypeEquipement = true;
			CFamilleEquipement famille = (CFamilleEquipement)m_comboFamille.ElementSelectionne;
            CFiltreData filtreDeBase = null;
			if (famille != null)
			{
				filtreDeBase = CFiltreData.GetAndFiltre(filtreDeBase,
					new CFiltreDataAvance(
					CTypeEquipement.c_nomTable,
					CFamilleEquipement.c_nomTable + "." + CFamilleEquipement.c_champCodeComplet + " like @1",
					famille.CodeSystemeComplet + "%"));
			}
			if (Equipement.EquipementContenant != null)
			{
				CTypeEquipement[] typesPoss = Equipement.EquipementContenant.TypeEquipement.TousLesTypesIncluables;
				if (typesPoss.Length != 0)
				{
					string strIds = "";
					foreach (CTypeEquipement tPoss in typesPoss)
						strIds += tPoss.Id + ",";

					strIds = strIds.Substring(0, strIds.Length - 1);
					filtreDeBase = CFiltreData.GetAndFiltre(filtreDeBase,
						new CFiltreData(CTypeEquipement.c_champId + " in(" + strIds + ")"));
				}
			}


			m_selectTypeEquipement.InitAvecFiltreDeBase<CTypeEquipement>(
				"Libelle",
				filtreDeBase, 
                true);


			m_bIsInitialisingTypeEquipement = false;
		}

		//-------------------------------------------------------------------------
		private bool m_bIsInitialisingRefConstructeur;
		private void InitComboRefConstructeur()
		{
			m_bIsInitialisingRefConstructeur = true;
            m_cmbxSelectRefConstructeur.ElementSelectionne = null;
            CTypeEquipement type = (CTypeEquipement)m_selectTypeEquipement.ElementSelectionne;
			CListeObjetsDonnees liste = new CListeObjetsDonnees(Equipement.ContexteDonnee, typeof(CRelationTypeEquipement_Constructeurs));
			if (type != null)
			{
				liste.Filtre = new CFiltreData(CTypeEquipement.c_champId + "=@1", type.Id);
			}
			m_cmbxSelectRefConstructeur.Init(liste, "ReferenceComplete", true);

            if (liste.Count == 1)
                m_cmbxSelectRefConstructeur.ElementSelectionne = (CRelationTypeEquipement_Constructeurs) liste[0];

			m_bIsInitialisingRefConstructeur = false;
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			if (result)
			{
				Equipement.TypeEquipement = (CTypeEquipement)m_selectTypeEquipement.ElementSelectionne;
				Equipement.RelationConstructeur = (CRelationTypeEquipement_Constructeurs)m_cmbxSelectRefConstructeur.ElementSelectionne;
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
                CTypeEquipement oldTypeEq = Equipement.TypeEquipement;
                Equipement.TypeEquipement = (CTypeEquipement)m_selectTypeEquipement.ElementSelectionne;
                ManageOnglets();
                m_panelChamps.ElementEdite = Equipement;
                m_panelSystemeCoordonnees.Init(Equipement);
                m_panelOccupation.Init(Equipement);
                InitTablesParametrables();
                m_panelEquipementLogique.OnChangeTypeEquipementPhysique(Equipement);
            }

            if (!m_bIsInitialisingRefConstructeur)
            {
                InitComboRefConstructeur();
            }
        }


		//-------------------------------------------------------------------------
		private void m_lnkDeplacer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CResultAErreur result = MAJ_Champs();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}
			if (CFormDeplacerEquipement.DeplaceEquipement(Equipement))
			{
				InitChamps();
			}
		}

		//-------------------------------------------------------------------------
		private void m_lnkEmplacement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			IEmplacementEquipement emplacement = Equipement.Emplacement;
			if (emplacement != null)
			{
				//Type tp = CFormFinder.GetTypeFormToEdit(emplacement.GetType());
				CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(emplacement.GetType());
				try
				{
					//CTimosApp.Navigateur.AffichePage((IFormNavigable)Activator.CreateInstance(tp, new object[] { emplacement }));
					CTimosApp.Navigateur.AffichePage(refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)emplacement) as IFormNavigable);
				}
				catch
				{ }

			}
		}

		//-------------------------------------------------------------------------
		private void CFormEditionEquipement_BeforeValideModification(object sender, CObjetDonneeCancelEventArgs args)
		{

		}

		//-------------------------------------------------------------------------
		private void m_panelOccupation_OnChangeOccupation(object sender, EventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				m_panelOccupation.MajChamps();
				m_controleCoordonnee.Refresh();
			}
		}

		//-------------------------------------------------------------------------
		private void m_arbreEquipementParent_MouseMove(object sender, MouseEventArgs e)
		{
			TreeViewHitTestInfo info = m_arbreEquipementParent.HitTest(new Point(e.X, e.Y));
			if (info.Node != null && info.Node.Tag is CEquipement)
				Cursor = Cursors.Hand;
			else
				Cursor = Cursors.Default;
		}

		//-------------------------------------------------------------------------
		private void m_arbreEquipementParent_MouseDown(object sender, MouseEventArgs e)
		{
			if (!m_gestionnaireModeEdition.ModeEdition)
			{
				Point pt = new Point(e.X, e.Y);
				TreeViewHitTestInfo info = m_arbreEquipementParent.HitTest(pt);
				if (info.Node != null && info.Node.Tag is CEquipement)
				{
					CTimosApp.Navigateur.AffichePage(new CFormEditionEquipement((CEquipement)info.Node.Tag));
				}
			}
		}

        private void m_panelEquipementsInclus_OnNewObjetDonnee(object sender, CObjetDonnee nouvelObjet, ref bool bCancel)
        {
            if (bCancel)
                return;

			if (nouvelObjet is CEquipement)
			{
				((CEquipement)nouvelObjet).SetEmplacementSansHistorique(Equipement.Emplacement, Equipement);
			}
		}

		private void m_panelSystemeCoordonnees_OnChangeSystemeCoordonnee(object sender, EventArgs e)
		{
		}

		private CResultAErreur CFormEditionEquipement_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == pageContient)
				{
					m_panelEquipementsInclus.InitFromListeObjets(
					Equipement.EquipementsContenus,
					typeof(CEquipement),
					typeof(CFormEditionEquipement),
					Equipement,
					"EquipementParentInitial");
				}
				else if (page == pageContraintes)
				{
					m_panelListeContraintes.InitFromListeObjets(
						Equipement.Contraintes,
						typeof(CContrainte),
						typeof(CFormEditionContrainte),
						Equipement,
						"Equipement");
				}
				else if (page == pageFiche)
				{
					m_panelChamps.ElementEdite = Equipement;
				}
				else if (page == pageLocation)
				{
					m_cmbStatut.Init(typeof(CStatutEquipement), "Libelle", false);
					m_cmbStatut.ElementSelectionne = Equipement.Statut;

                    result = m_panelOccupation.Init(Equipement);
                    if (!result)
                        return result;
                    m_panelOccupation.Visible = (Equipement.ConteneurFilsACoordonnees != null &&
                        Equipement.ConteneurFilsACoordonnees.ParametrageCoordonneesApplique != null);

                    m_controleCoordonnee.Init(Equipement.ConteneurFilsACoordonnees, Equipement);
					m_controleCoordonnee.Coordonnee = Equipement.Coordonnee;
                    m_panelCoordonnees.Visible = (Equipement.ConteneurFilsACoordonnees != null &&
                        Equipement.ConteneurFilsACoordonnees.ParametrageCoordonneesApplique != null);

					IEmplacementEquipement emplacement = Equipement.Emplacement;
					CEquipement equipementParent = Equipement.EquipementContenant;
					m_arbreEquipementParent.Visible = equipementParent != null;
					if (equipementParent != null)
					{
						m_arbreEquipementParent.Nodes.Clear();
						TreeNode node = CreateNode(equipementParent);
						//m_arbreEquipementParent.Nodes.Add(node);
					}

					m_panelMouvements.InitFromListeObjets(
						Equipement.Mouvements,
						typeof(CMouvementEquipement),
						null,
						Equipement,
						"EquipementDeplace");
				}
				else if (page == m_pageFonction)
				{
					m_panelEquipementLogique.InitChamps(Equipement);
				}
				else if (page == pageParamCtrlCoor)
				{
					result = m_panelSystemeCoordonnees.Init(Equipement);
					if (result)
						result = m_panelOptionControle.Init(Equipement);

				}
				else if (page == pageTablesParametrables)
				{
					InitTablesParametrables();
				}

			}

			return result;
		}
		private CResultAErreur CFormEditionEquipement_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == pageContient)
			{
			}
			else if (page == pageContraintes)
			{
			}
			else if (page == pageFiche)
			{
				result = m_panelChamps.MAJ_Champs();
			}
			else if (page == pageLocation)
			{
				Equipement.Statut = (CStatutEquipement)m_cmbStatut.ElementSelectionne;
                
				result = m_panelOccupation.MajChamps();
				Equipement.Coordonnee = m_controleCoordonnee.Coordonnee;
			}
			else if (page == m_pageFonction)
			{
				result = m_panelEquipementLogique.MajChamps();
				if (!result)
					return result;
			}
			else if (page == pageParamCtrlCoor)
			{
				result = m_panelOptionControle.MajChamps();
				if (result)
					result = m_panelSystemeCoordonnees.MajChamps();
			}
			else if (page == pageTablesParametrables)
			{
			}
			return result;
		}

        private void m_selectTypeEquipement_Load(object sender, EventArgs e)
        {

        }


	}
}

