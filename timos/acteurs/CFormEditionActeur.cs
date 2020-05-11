using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using sc2i.workflow;
using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using sc2i.win32.data.dynamic;

using timos.win32.composants;
using timos.data;
using timos.acteurs;
using timos.securite;
using timos.data.equipement.consommables;
using sc2i.common.unites.standard;

namespace timos
{
	[ObjectEditeur(typeof(CActeur))]
	public class CFormEditionActeur : CFormEditionStdTimos, IFormNavigable
	{

		
		#region Designer generated code

        private System.Windows.Forms.Label m_lblAdresse;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private C2iTextBox m_txtNom;
		private C2iTextBox m_txtTelephone1;
		private C2iTextBox m_txtAdresse;
		private C2iTextBox m_txtTelephone2;
		private C2iTextBox m_txtTelephone3;
		private C2iTextBox m_txtSiteWeb;
		private C2iTextBox m_txtFax;
		private C2iTextBox m_txtPortable;
		private C2iTextBox m_txtEMail;
		private System.Windows.Forms.Label m_lblZipCode;
		private sc2i.win32.common.C2iTextBox m_txtCodePostal;
		private sc2i.win32.common.C2iTextBox m_txtVille;
		private System.ComponentModel.IContainer components = null;
		


		private sc2i.win32.common.ListViewAutoFilled m_listViewRoles;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn7;
		private System.Windows.Forms.Timer m_timer;
		private System.Windows.Forms.ToolTip m_toolTip;
		private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbCivilite;
		private sc2i.win32.common.C2iPanelOmbre m_panCoordonnees;
		private sc2i.win32.common.C2iPanelOmbre m_panAdresse;
        private sc2i.win32.common.C2iPanelOmbre m_panGeneralites;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_tabPageGroupes;
		private sc2i.win32.common.C2iLink m_linkCivilite;
		private timos.win32.composants.C2iNecessiteGroupeTreeView m_treeViewGroupes;
		private System.Windows.Forms.Label label20;
		private sc2i.win32.common.C2iLink m_linkGroupeActeurs;
		private System.Windows.Forms.TextBox m_txtErreur;

		private Hashtable m_tableRolesNecessitesParGroupes = new Hashtable();
		private Hashtable m_tableItemsToVerify = new Hashtable();
		private timos.win32.composants.CcontrolAgenda m_controlAgenda;
		private Crownwood.Magic.Controls.TabPage m_tabPageAgenda;
		private Crownwood.Magic.Controls.TabPage m_pageCommentaires;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label m_lblPrenom;
		private sc2i.win32.common.C2iTextBox m_txtPrenom;
		private System.Windows.Forms.CheckBox m_chkMembreDesactive;
		private System.Windows.Forms.LinkLabel m_lnkCalendrier;
		private Crownwood.Magic.Controls.TabPage m_tabPageEO;
		private CPanelAffectationEO m_panelEOS;
		private Crownwood.Magic.Controls.TabPage m_tabPageContacts;
		private CPanelListeSpeedStandard m_panelContacts;
		private Label m_lblMembreParent;
		private SplitContainer m_splitContainerGeneralites;
		private Label m_lblNom;
		private C2iTextBoxSelectionne m_selectMainActeur;
        private Crownwood.Magic.Controls.TabPage m_tabPageRessourcesDetenues;
        private CPanelListeSpeedStandard m_panelListeRessourcesDetenues;
		private Crownwood.Magic.Controls.TabPage m_pageEquipements;
		private CPanelListeSpeedStandard m_wndListeEquipements;
		private Crownwood.Magic.Controls.TabPage m_tabPageInfosCustom;
		private CPanelChampsCustom m_panelChamps;
        private Label m_lblVille;
        private SplitContainer m_splitContainer2;
        private Label label15;
        private Crownwood.Magic.Controls.TabPage m_tabPageToRemove;
        private Label label16;
        private Label label17;
		private Panel m_panTop;
		private CReducteurControle m_reducteur;
        private Label label2;
        private C2iTextBoxSelectionne m_txtTauxHoraire;
        private Label label18;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionActeur));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblAdresse = new System.Windows.Forms.Label();
            this.m_txtTelephone1 = new sc2i.win32.common.C2iTextBox();
            this.m_txtAdresse = new sc2i.win32.common.C2iTextBox();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtTelephone2 = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtTelephone3 = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtSiteWeb = new sc2i.win32.common.C2iTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtFax = new sc2i.win32.common.C2iTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtPortable = new sc2i.win32.common.C2iTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_txtEMail = new sc2i.win32.common.C2iTextBox();
            this.m_lblZipCode = new System.Windows.Forms.Label();
            this.m_txtCodePostal = new sc2i.win32.common.C2iTextBox();
            this.m_txtVille = new sc2i.win32.common.C2iTextBox();
            this.m_listViewRoles = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewColumn7 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_cmbCivilite = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.m_panCoordonnees = new sc2i.win32.common.C2iPanelOmbre();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_panAdresse = new sc2i.win32.common.C2iPanelOmbre();
            this.m_linkCivilite = new sc2i.win32.common.C2iLink(this.components);
            this.m_lblVille = new System.Windows.Forms.Label();
            this.m_panGeneralites = new sc2i.win32.common.C2iPanelOmbre();
            this.m_splitContainerGeneralites = new System.Windows.Forms.SplitContainer();
            this.m_lblNom = new System.Windows.Forms.Label();
            this.m_txtPrenom = new sc2i.win32.common.C2iTextBox();
            this.m_lblPrenom = new System.Windows.Forms.Label();
            this.m_selectMainActeur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_chkMembreDesactive = new System.Windows.Forms.CheckBox();
            this.m_lblMembreParent = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_tabPageAgenda = new Crownwood.Magic.Controls.TabPage();
            this.m_txtTauxHoraire = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lnkCalendrier = new System.Windows.Forms.LinkLabel();
            this.m_controlAgenda = new timos.win32.composants.CcontrolAgenda();
            this.m_tabPageToRemove = new Crownwood.Magic.Controls.TabPage();
            this.m_tabPageInfosCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageCommentaires = new Crownwood.Magic.Controls.TabPage();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_tabPageContacts = new Crownwood.Magic.Controls.TabPage();
            this.m_panelContacts = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_tabPageGroupes = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.m_linkGroupeActeurs = new sc2i.win32.common.C2iLink(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.m_treeViewGroupes = new timos.win32.composants.C2iNecessiteGroupeTreeView();
            this.m_txtErreur = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.m_tabPageEO = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_tabPageRessourcesDetenues = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeRessourcesDetenues = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageEquipements = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeEquipements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panTop = new System.Windows.Forms.Panel();
            this.m_reducteur = new sc2i.win32.common.CReducteurControle();
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.m_toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panCoordonnees.SuspendLayout();
            this.m_panAdresse.SuspendLayout();
            this.m_panGeneralites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerGeneralites)).BeginInit();
            this.m_splitContainerGeneralites.Panel1.SuspendLayout();
            this.m_splitContainerGeneralites.Panel2.SuspendLayout();
            this.m_splitContainerGeneralites.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_tabPageAgenda.SuspendLayout();
            this.m_tabPageInfosCustom.SuspendLayout();
            this.m_pageCommentaires.SuspendLayout();
            this.m_tabPageContacts.SuspendLayout();
            this.m_tabPageGroupes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer2)).BeginInit();
            this.m_splitContainer2.Panel1.SuspendLayout();
            this.m_splitContainer2.Panel2.SuspendLayout();
            this.m_splitContainer2.SuspendLayout();
            this.m_tabPageEO.SuspendLayout();
            this.m_tabPageRessourcesDetenues.SuspendLayout();
            this.m_pageEquipements.SuspendLayout();
            this.m_panTop.SuspendLayout();
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
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEdition = true;
            this.m_gestionnaireModeEdition.ModeEditionChanged += new System.EventHandler(this.m_gestionnaireModeEdition_ModeEditionChanged);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(657, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(549, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(832, 28);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(64, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 13;
            this.label3.Text = "1";
            // 
            // m_lblAdresse
            // 
            this.m_lblAdresse.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblAdresse, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblAdresse, false);
            this.m_lblAdresse.Location = new System.Drawing.Point(8, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblAdresse, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblAdresse, "");
            this.m_lblAdresse.Name = "m_lblAdresse";
            this.m_lblAdresse.Size = new System.Drawing.Size(65, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAdresse.TabIndex = 12;
            this.m_lblAdresse.Text = "Address|755";
            // 
            // m_txtTelephone1
            // 
            this.m_txtTelephone1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtTelephone1, "Telephone1");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTelephone1, true);
            this.m_txtTelephone1.Location = new System.Drawing.Point(84, 7);
            this.m_txtTelephone1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTelephone1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTelephone1, "");
            this.m_txtTelephone1.Name = "m_txtTelephone1";
            this.m_txtTelephone1.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTelephone1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTelephone1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTelephone1.TabIndex = 0;
            this.m_txtTelephone1.Text = "[Telephone1]";
            this.m_txtTelephone1.Validated += new System.EventHandler(this.m_txtTelephone_Validated);
            // 
            // m_txtAdresse
            // 
            this.m_txtAdresse.AcceptsReturn = true;
            this.m_txtAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAdresse.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtAdresse, "Adresse");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtAdresse, true);
            this.m_txtAdresse.Location = new System.Drawing.Point(11, 46);
            this.m_txtAdresse.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAdresse, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtAdresse, "");
            this.m_txtAdresse.Multiline = true;
            this.m_txtAdresse.Name = "m_txtAdresse";
            this.m_txtAdresse.Size = new System.Drawing.Size(381, 35);
            this.m_extStyle.SetStyleBackColor(this.m_txtAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAdresse.TabIndex = 1;
            this.m_txtAdresse.Text = "[Adresse]";
            // 
            // m_txtNom
            // 
            this.m_txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtNom.EmptyText = "";
            this.m_txtNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_txtNom, "Nom");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtNom, true);
            this.m_txtNom.Location = new System.Drawing.Point(85, -1);
            this.m_txtNom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNom, "");
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(302, 22);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 0;
            this.m_txtNom.Text = "[Nom]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(64, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 15;
            this.label4.Text = "2";
            // 
            // m_txtTelephone2
            // 
            this.m_txtTelephone2.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtTelephone2, "Telephone2");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTelephone2, true);
            this.m_txtTelephone2.Location = new System.Drawing.Point(84, 32);
            this.m_txtTelephone2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTelephone2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTelephone2, "");
            this.m_txtTelephone2.Name = "m_txtTelephone2";
            this.m_txtTelephone2.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTelephone2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTelephone2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTelephone2.TabIndex = 1;
            this.m_txtTelephone2.Text = "[Telephone2]";
            this.m_txtTelephone2.Validated += new System.EventHandler(this.m_txtTelephone_Validated);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(64, 60);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 17;
            this.label5.Text = "3";
            // 
            // m_txtTelephone3
            // 
            this.m_txtTelephone3.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtTelephone3, "Telephone3");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTelephone3, true);
            this.m_txtTelephone3.Location = new System.Drawing.Point(84, 57);
            this.m_txtTelephone3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTelephone3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTelephone3, "");
            this.m_txtTelephone3.Name = "m_txtTelephone3";
            this.m_txtTelephone3.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTelephone3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTelephone3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTelephone3.TabIndex = 2;
            this.m_txtTelephone3.Text = "[Telephone3]";
            this.m_txtTelephone3.Validated += new System.EventHandler(this.m_txtTelephone_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(11, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 23;
            this.label6.Text = "Web|30038";
            // 
            // m_txtSiteWeb
            // 
            this.m_txtSiteWeb.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtSiteWeb, "SiteWeb");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSiteWeb, true);
            this.m_txtSiteWeb.Location = new System.Drawing.Point(84, 84);
            this.m_txtSiteWeb.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSiteWeb, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSiteWeb, "");
            this.m_txtSiteWeb.Name = "m_txtSiteWeb";
            this.m_txtSiteWeb.Size = new System.Drawing.Size(290, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSiteWeb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSiteWeb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSiteWeb.TabIndex = 5;
            this.m_txtSiteWeb.Text = "[SiteWeb]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(210, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fax |30297";
            // 
            // m_txtFax
            // 
            this.m_txtFax.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtFax, "Fax");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFax, true);
            this.m_txtFax.Location = new System.Drawing.Point(254, 32);
            this.m_txtFax.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFax, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFax, "");
            this.m_txtFax.Name = "m_txtFax";
            this.m_txtFax.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFax, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFax.TabIndex = 4;
            this.m_txtFax.Text = "[Fax]";
            this.m_txtFax.Validated += new System.EventHandler(this.m_txtTelephone_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(210, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 19;
            this.label8.Text = "Mobile|30296";
            // 
            // m_txtPortable
            // 
            this.m_txtPortable.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtPortable, "Portable");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtPortable, true);
            this.m_txtPortable.Location = new System.Drawing.Point(254, 8);
            this.m_txtPortable.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtPortable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtPortable, "");
            this.m_txtPortable.Name = "m_txtPortable";
            this.m_txtPortable.Size = new System.Drawing.Size(120, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPortable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPortable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPortable.TabIndex = 3;
            this.m_txtPortable.Text = "[Portable]";
            this.m_txtPortable.Validated += new System.EventHandler(this.m_txtTelephone_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(11, 112);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 25;
            this.label9.Text = "E-Mail|30039";
            // 
            // m_txtEMail
            // 
            this.m_txtEMail.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtEMail, "EMail");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtEMail, true);
            this.m_txtEMail.Location = new System.Drawing.Point(84, 108);
            this.m_txtEMail.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtEMail, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtEMail, "");
            this.m_txtEMail.Name = "m_txtEMail";
            this.m_txtEMail.Size = new System.Drawing.Size(290, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtEMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtEMail, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtEMail.TabIndex = 6;
            this.m_txtEMail.Text = "[EMail]";
            // 
            // m_lblZipCode
            // 
            this.m_extLinkField.SetLinkField(this.m_lblZipCode, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblZipCode, false);
            this.m_lblZipCode.Location = new System.Drawing.Point(8, 85);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblZipCode, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblZipCode, "");
            this.m_lblZipCode.Name = "m_lblZipCode";
            this.m_lblZipCode.Size = new System.Drawing.Size(109, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblZipCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblZipCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblZipCode.TabIndex = 40;
            this.m_lblZipCode.Text = "Postal/Zip Code|756";
            // 
            // m_txtCodePostal
            // 
            this.m_txtCodePostal.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtCodePostal, "CodePostal");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtCodePostal, true);
            this.m_txtCodePostal.Location = new System.Drawing.Point(10, 103);
            this.m_txtCodePostal.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCodePostal, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCodePostal, "");
            this.m_txtCodePostal.Name = "m_txtCodePostal";
            this.m_txtCodePostal.Size = new System.Drawing.Size(107, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCodePostal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCodePostal.TabIndex = 2;
            this.m_txtCodePostal.Text = "[CodePostal]";
            // 
            // m_txtVille
            // 
            this.m_txtVille.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtVille.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtVille, "Ville");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtVille, true);
            this.m_txtVille.Location = new System.Drawing.Point(123, 103);
            this.m_txtVille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtVille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtVille, "");
            this.m_txtVille.Name = "m_txtVille";
            this.m_txtVille.Size = new System.Drawing.Size(269, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtVille.TabIndex = 3;
            this.m_txtVille.Text = "[Ville]";
            // 
            // m_listViewRoles
            // 
            this.m_listViewRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewColumn7});
            this.m_listViewRoles.EnableCustomisation = true;
            this.m_listViewRoles.FullRowSelect = true;
            this.m_extLinkField.SetLinkField(this.m_listViewRoles, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_listViewRoles, false);
            this.m_listViewRoles.Location = new System.Drawing.Point(9, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRoles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_listViewRoles, "");
            this.m_listViewRoles.Name = "m_listViewRoles";
            this.m_listViewRoles.Size = new System.Drawing.Size(377, 193);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRoles.TabIndex = 42;
            this.m_listViewRoles.UseCompatibleStateImageBehavior = false;
            this.m_listViewRoles.View = System.Windows.Forms.View.Details;
            this.m_listViewRoles.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_listViewRoles_ItemCheck);
            // 
            // listViewColumn7
            // 
            this.listViewColumn7.Field = "Libelle";
            this.listViewColumn7.PrecisionWidth = 0D;
            this.listViewColumn7.ProportionnalSize = false;
            this.listViewColumn7.Text = "Role|764";
            this.listViewColumn7.Visible = true;
            this.listViewColumn7.Width = 250;
            // 
            // m_cmbCivilite
            // 
            this.m_cmbCivilite.ComportementLinkStd = true;
            this.m_cmbCivilite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbCivilite.ElementSelectionne = null;
            this.m_cmbCivilite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbCivilite.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbCivilite, "Civilite.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbCivilite, true);
            this.m_cmbCivilite.LinkProperty = "";
            this.m_cmbCivilite.ListDonnees = null;
            this.m_cmbCivilite.Location = new System.Drawing.Point(86, 7);
            this.m_cmbCivilite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbCivilite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbCivilite, "");
            this.m_cmbCivilite.Name = "m_cmbCivilite";
            this.m_cmbCivilite.NullAutorise = true;
            this.m_cmbCivilite.ProprieteAffichee = null;
            this.m_cmbCivilite.ProprieteParentListeObjets = "";
            this.m_cmbCivilite.SelectionneurParent = null;
            this.m_cmbCivilite.Size = new System.Drawing.Size(168, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbCivilite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbCivilite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbCivilite.TabIndex = 0;
            this.m_cmbCivilite.TextNull = "(None)";
            this.m_cmbCivilite.Tri = true;
            this.m_cmbCivilite.TypeFormEdition = null;
            // 
            // m_panCoordonnees
            // 
            this.m_panCoordonnees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panCoordonnees.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panCoordonnees.Controls.Add(this.label9);
            this.m_panCoordonnees.Controls.Add(this.label6);
            this.m_panCoordonnees.Controls.Add(this.m_txtTelephone1);
            this.m_panCoordonnees.Controls.Add(this.m_txtEMail);
            this.m_panCoordonnees.Controls.Add(this.m_txtTelephone3);
            this.m_panCoordonnees.Controls.Add(this.m_txtSiteWeb);
            this.m_panCoordonnees.Controls.Add(this.label4);
            this.m_panCoordonnees.Controls.Add(this.m_txtTelephone2);
            this.m_panCoordonnees.Controls.Add(this.m_txtFax);
            this.m_panCoordonnees.Controls.Add(this.label8);
            this.m_panCoordonnees.Controls.Add(this.m_txtPortable);
            this.m_panCoordonnees.Controls.Add(this.label7);
            this.m_panCoordonnees.Controls.Add(this.label16);
            this.m_panCoordonnees.Controls.Add(this.label3);
            this.m_panCoordonnees.Controls.Add(this.label5);
            this.m_panCoordonnees.Controls.Add(this.label17);
            this.m_panCoordonnees.Controls.Add(this.label18);
            this.m_panCoordonnees.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panCoordonnees, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panCoordonnees, false);
            this.m_panCoordonnees.Location = new System.Drawing.Point(419, 79);
            this.m_panCoordonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panCoordonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panCoordonnees, "");
            this.m_panCoordonnees.Name = "m_panCoordonnees";
            this.m_panCoordonnees.Size = new System.Drawing.Size(400, 159);
            this.m_extStyle.SetStyleBackColor(this.m_panCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panCoordonnees.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label16, false);
            this.label16.Location = new System.Drawing.Point(7, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label16, "");
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 23;
            this.label16.Text = "Phone|786";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label17, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label17, false);
            this.label17.Location = new System.Drawing.Point(7, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label17, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label17, "");
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 23;
            this.label17.Text = "Phone|786";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label18, false);
            this.label18.Location = new System.Drawing.Point(7, 60);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label18, "");
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 23;
            this.label18.Text = "Phone|786";
            // 
            // m_panAdresse
            // 
            this.m_panAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panAdresse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panAdresse.Controls.Add(this.m_linkCivilite);
            this.m_panAdresse.Controls.Add(this.m_txtAdresse);
            this.m_panAdresse.Controls.Add(this.m_lblAdresse);
            this.m_panAdresse.Controls.Add(this.m_cmbCivilite);
            this.m_panAdresse.Controls.Add(this.m_txtVille);
            this.m_panAdresse.Controls.Add(this.m_lblZipCode);
            this.m_panAdresse.Controls.Add(this.m_txtCodePostal);
            this.m_panAdresse.Controls.Add(this.m_lblVille);
            this.m_panAdresse.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panAdresse, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panAdresse, false);
            this.m_panAdresse.Location = new System.Drawing.Point(0, 79);
            this.m_panAdresse.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panAdresse, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panAdresse, "");
            this.m_panAdresse.Name = "m_panAdresse";
            this.m_panAdresse.Size = new System.Drawing.Size(416, 159);
            this.m_extStyle.SetStyleBackColor(this.m_panAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panAdresse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panAdresse.TabIndex = 1;
            // 
            // m_linkCivilite
            // 
            this.m_linkCivilite.AutoSize = true;
            this.m_linkCivilite.ClickEnabled = true;
            this.m_linkCivilite.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkCivilite.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkCivilite.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkCivilite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkCivilite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkCivilite.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_linkCivilite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_linkCivilite, false);
            this.m_linkCivilite.Location = new System.Drawing.Point(8, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkCivilite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_linkCivilite, "");
            this.m_linkCivilite.Name = "m_linkCivilite";
            this.m_linkCivilite.Size = new System.Drawing.Size(56, 13);
            this.m_extStyle.SetStyleBackColor(this.m_linkCivilite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkCivilite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkCivilite.TabIndex = 4043;
            this.m_linkCivilite.Text = "Civility|754";
            this.m_linkCivilite.LinkClicked += new System.EventHandler(this.m_linkCivilite_LinkClicked);
            // 
            // m_lblVille
            // 
            this.m_extLinkField.SetLinkField(this.m_lblVille, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblVille, false);
            this.m_lblVille.Location = new System.Drawing.Point(120, 84);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblVille, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblVille, "");
            this.m_lblVille.Name = "m_lblVille";
            this.m_lblVille.Size = new System.Drawing.Size(75, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lblVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblVille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVille.TabIndex = 40;
            this.m_lblVille.Text = "City|757";
            // 
            // m_panGeneralites
            // 
            this.m_panGeneralites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panGeneralites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panGeneralites.Controls.Add(this.m_splitContainerGeneralites);
            this.m_panGeneralites.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panGeneralites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panGeneralites, false);
            this.m_panGeneralites.Location = new System.Drawing.Point(0, 0);
            this.m_panGeneralites.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panGeneralites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panGeneralites, "");
            this.m_panGeneralites.Name = "m_panGeneralites";
            this.m_panGeneralites.Size = new System.Drawing.Size(816, 78);
            this.m_extStyle.SetStyleBackColor(this.m_panGeneralites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panGeneralites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panGeneralites.TabIndex = 0;
            // 
            // m_splitContainerGeneralites
            // 
            this.m_extLinkField.SetLinkField(this.m_splitContainerGeneralites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainerGeneralites, false);
            this.m_splitContainerGeneralites.Location = new System.Drawing.Point(0, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerGeneralites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerGeneralites, "");
            this.m_splitContainerGeneralites.Name = "m_splitContainerGeneralites";
            // 
            // m_splitContainerGeneralites.Panel1
            // 
            this.m_splitContainerGeneralites.Panel1.Controls.Add(this.m_lblNom);
            this.m_splitContainerGeneralites.Panel1.Controls.Add(this.m_txtPrenom);
            this.m_splitContainerGeneralites.Panel1.Controls.Add(this.m_lblPrenom);
            this.m_splitContainerGeneralites.Panel1.Controls.Add(this.m_txtNom);
            this.m_extLinkField.SetLinkField(this.m_splitContainerGeneralites.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainerGeneralites.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerGeneralites.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerGeneralites.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerGeneralites.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerGeneralites.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainerGeneralites.Panel2
            // 
            this.m_splitContainerGeneralites.Panel2.Controls.Add(this.m_selectMainActeur);
            this.m_splitContainerGeneralites.Panel2.Controls.Add(this.m_chkMembreDesactive);
            this.m_splitContainerGeneralites.Panel2.Controls.Add(this.m_lblMembreParent);
            this.m_extLinkField.SetLinkField(this.m_splitContainerGeneralites.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainerGeneralites.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerGeneralites.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerGeneralites.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerGeneralites.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerGeneralites.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerGeneralites.Size = new System.Drawing.Size(794, 53);
            this.m_splitContainerGeneralites.SplitterDistance = 390;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerGeneralites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerGeneralites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerGeneralites.TabIndex = 4048;
            // 
            // m_lblNom
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblNom, false);
            this.m_lblNom.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblNom, "");
            this.m_lblNom.Name = "m_lblNom";
            this.m_lblNom.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNom.TabIndex = 4045;
            this.m_lblNom.Text = "Name|309";
            // 
            // m_txtPrenom
            // 
            this.m_txtPrenom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPrenom.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtPrenom, "Prenom");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtPrenom, true);
            this.m_txtPrenom.Location = new System.Drawing.Point(86, 26);
            this.m_txtPrenom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtPrenom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtPrenom, "");
            this.m_txtPrenom.Name = "m_txtPrenom";
            this.m_txtPrenom.Size = new System.Drawing.Size(301, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPrenom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPrenom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPrenom.TabIndex = 4044;
            this.m_txtPrenom.Text = "[Prenom]";
            // 
            // m_lblPrenom
            // 
            this.m_extLinkField.SetLinkField(this.m_lblPrenom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblPrenom, false);
            this.m_lblPrenom.Location = new System.Drawing.Point(3, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPrenom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblPrenom, "");
            this.m_lblPrenom.Name = "m_lblPrenom";
            this.m_lblPrenom.Size = new System.Drawing.Size(75, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblPrenom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblPrenom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblPrenom.TabIndex = 4045;
            this.m_lblPrenom.Text = "First name|310";
            // 
            // m_selectMainActeur
            // 
            this.m_selectMainActeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_selectMainActeur.ElementSelectionne = null;
            this.m_selectMainActeur.FonctionTextNull = null;
            this.m_selectMainActeur.HasLink = true;
            this.m_selectMainActeur.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_selectMainActeur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_selectMainActeur, false);
            this.m_selectMainActeur.Location = new System.Drawing.Point(100, 2);
            this.m_selectMainActeur.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectMainActeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_selectMainActeur, "");
            this.m_selectMainActeur.Name = "m_selectMainActeur";
            this.m_selectMainActeur.SelectedObject = null;
            this.m_selectMainActeur.Size = new System.Drawing.Size(297, 21);
            this.m_selectMainActeur.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_selectMainActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectMainActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectMainActeur.TabIndex = 4048;
            this.m_selectMainActeur.TextNull = "";
            // 
            // m_chkMembreDesactive
            // 
            this.m_extLinkField.SetLinkField(this.m_chkMembreDesactive, "Inactif");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkMembreDesactive, true);
            this.m_chkMembreDesactive.Location = new System.Drawing.Point(6, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkMembreDesactive, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkMembreDesactive, "");
            this.m_chkMembreDesactive.Name = "m_chkMembreDesactive";
            this.m_chkMembreDesactive.Size = new System.Drawing.Size(224, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkMembreDesactive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkMembreDesactive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkMembreDesactive.TabIndex = 4046;
            this.m_chkMembreDesactive.Text = "Disabled Member|758";
            // 
            // m_lblMembreParent
            // 
            this.m_extLinkField.SetLinkField(this.m_lblMembreParent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblMembreParent, false);
            this.m_lblMembreParent.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMembreParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblMembreParent, "");
            this.m_lblMembreParent.Name = "m_lblMembreParent";
            this.m_lblMembreParent.Size = new System.Drawing.Size(100, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblMembreParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMembreParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMembreParent.TabIndex = 4047;
            this.m_lblMembreParent.Text = "Main Member|311";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 277);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_tabPageToRemove;
            this.m_tabControl.Size = new System.Drawing.Size(820, 303);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 3;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_tabPageToRemove,
            this.m_tabPageInfosCustom,
            this.m_pageCommentaires,
            this.m_tabPageContacts,
            this.m_tabPageAgenda,
            this.m_tabPageGroupes,
            this.m_tabPageEO,
            this.m_tabPageRessourcesDetenues,
            this.m_pageEquipements});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_tabPageAgenda
            // 
            this.m_tabPageAgenda.Controls.Add(this.m_txtTauxHoraire);
            this.m_tabPageAgenda.Controls.Add(this.label2);
            this.m_tabPageAgenda.Controls.Add(this.m_lnkCalendrier);
            this.m_tabPageAgenda.Controls.Add(this.m_controlAgenda);
            this.m_extLinkField.SetLinkField(this.m_tabPageAgenda, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageAgenda, false);
            this.m_tabPageAgenda.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageAgenda, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageAgenda, "");
            this.m_tabPageAgenda.Name = "m_tabPageAgenda";
            this.m_tabPageAgenda.Selected = false;
            this.m_tabPageAgenda.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageAgenda.TabIndex = 5;
            this.m_tabPageAgenda.Title = "Diary|80";
            // 
            // m_txtTauxHoraire
            // 
            this.m_txtTauxHoraire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTauxHoraire.ElementSelectionne = null;
            this.m_txtTauxHoraire.FonctionTextNull = null;
            this.m_txtTauxHoraire.HasLink = true;
            this.m_txtTauxHoraire.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtTauxHoraire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtTauxHoraire, false);
            this.m_txtTauxHoraire.Location = new System.Drawing.Point(426, 6);
            this.m_txtTauxHoraire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTauxHoraire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtTauxHoraire, "");
            this.m_txtTauxHoraire.Name = "m_txtTauxHoraire";
            this.m_txtTauxHoraire.SelectedObject = null;
            this.m_txtTauxHoraire.Size = new System.Drawing.Size(240, 21);
            this.m_txtTauxHoraire.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtTauxHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTauxHoraire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTauxHoraire.TabIndex = 4;
            this.m_txtTauxHoraire.TextNull = "";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(320, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hourly rate|20710";
            // 
            // m_lnkCalendrier
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkCalendrier, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkCalendrier, false);
            this.m_lnkCalendrier.Location = new System.Drawing.Point(8, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCalendrier, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCalendrier, "");
            this.m_lnkCalendrier.Name = "m_lnkCalendrier";
            this.m_lnkCalendrier.Size = new System.Drawing.Size(224, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCalendrier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCalendrier, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCalendrier.TabIndex = 2;
            this.m_lnkCalendrier.TabStop = true;
            this.m_lnkCalendrier.Text = "Calendar|187";
            this.m_lnkCalendrier.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCalendrier_LinkClicked);
            // 
            // m_controlAgenda
            // 
            this.m_controlAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_controlAgenda.DateEnCours = new System.DateTime(2014, 7, 10, 15, 53, 38, 621);
            this.m_extLinkField.SetLinkField(this.m_controlAgenda, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_controlAgenda, false);
            this.m_controlAgenda.Location = new System.Drawing.Point(0, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlAgenda, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_controlAgenda, "");
            this.m_controlAgenda.Name = "m_controlAgenda";
            this.m_controlAgenda.Size = new System.Drawing.Size(792, 229);
            this.m_extStyle.SetStyleBackColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlAgenda.TabIndex = 1;
            this.m_controlAgenda.OnAfficherEntreeAgenda += new timos.win32.composants.DemandeAffichageEntreeAgendaEventHandler(this.m_controlAgenda_OnAfficherEntreeAgenda);
            // 
            // m_tabPageToRemove
            // 
            this.m_extLinkField.SetLinkField(this.m_tabPageToRemove, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageToRemove, false);
            this.m_tabPageToRemove.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageToRemove, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageToRemove, "");
            this.m_tabPageToRemove.Name = "m_tabPageToRemove";
            this.m_tabPageToRemove.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageToRemove, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageToRemove.TabIndex = 16;
            this.m_tabPageToRemove.Title = "Page|30040";
            // 
            // m_tabPageInfosCustom
            // 
            this.m_tabPageInfosCustom.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_tabPageInfosCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageInfosCustom, false);
            this.m_tabPageInfosCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageInfosCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageInfosCustom, "");
            this.m_tabPageInfosCustom.Name = "m_tabPageInfosCustom";
            this.m_tabPageInfosCustom.Selected = false;
            this.m_tabPageInfosCustom.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageInfosCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageInfosCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageInfosCustom.TabIndex = 15;
            this.m_tabPageInfosCustom.Title = "Form|60";
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
            this.m_panelChamps.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 0;
            // 
            // m_pageCommentaires
            // 
            this.m_pageCommentaires.Controls.Add(this.c2iTextBox1);
            this.m_extLinkField.SetLinkField(this.m_pageCommentaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageCommentaires, false);
            this.m_pageCommentaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageCommentaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageCommentaires, "");
            this.m_pageCommentaires.Name = "m_pageCommentaires";
            this.m_pageCommentaires.Selected = false;
            this.m_pageCommentaires.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_pageCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageCommentaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageCommentaires.TabIndex = 10;
            this.m_pageCommentaires.Title = "Comments|51";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.AcceptsReturn = true;
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Commentaires");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(8, 8);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(780, 254);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 2;
            this.c2iTextBox1.Text = "[Commentaires]";
            // 
            // m_tabPageContacts
            // 
            this.m_tabPageContacts.Controls.Add(this.m_panelContacts);
            this.m_extLinkField.SetLinkField(this.m_tabPageContacts, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageContacts, false);
            this.m_tabPageContacts.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageContacts, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageContacts, "");
            this.m_tabPageContacts.Name = "m_tabPageContacts";
            this.m_tabPageContacts.Selected = false;
            this.m_tabPageContacts.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageContacts.TabIndex = 12;
            this.m_tabPageContacts.Title = "Contacts|308";
            // 
            // m_panelContacts
            // 
            this.m_panelContacts.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelContacts.AffectationsPourNouveauxElements")));
            this.m_panelContacts.AllowArbre = true;
            this.m_panelContacts.AllowCustomisation = true;
            this.m_panelContacts.AllowSerializePreferences = true;
            this.m_panelContacts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
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
            glColumn1.Propriete = "Nom";
            glColumn1.Text = "Name|309";
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
            glColumn2.Propriete = "Prenom";
            glColumn2.Text = "first name|310";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelContacts.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn2});
            this.m_panelContacts.ContexteUtilisation = "";
            this.m_panelContacts.ControlFiltreStandard = null;
            this.m_panelContacts.ElementSelectionne = null;
            this.m_panelContacts.EnableCustomisation = true;
            this.m_panelContacts.FiltreDeBase = null;
            this.m_panelContacts.FiltreDeBaseEnAjout = false;
            this.m_panelContacts.FiltrePrefere = null;
            this.m_panelContacts.FiltreRapide = null;
            this.m_panelContacts.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelContacts, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelContacts, false);
            this.m_panelContacts.ListeObjets = null;
            this.m_panelContacts.Location = new System.Drawing.Point(0, 0);
            this.m_panelContacts.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelContacts, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelContacts.ModeQuickSearch = false;
            this.m_panelContacts.ModeSelection = true;
            this.m_extModulesAssociator.SetModules(this.m_panelContacts, "");
            this.m_panelContacts.MultiSelect = false;
            this.m_panelContacts.Name = "m_panelContacts";
            this.m_panelContacts.Navigateur = null;
            this.m_panelContacts.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelContacts.ProprieteObjetAEditer = null;
            this.m_panelContacts.QuickSearchText = "";
            this.m_panelContacts.ShortIcons = false;
            this.m_panelContacts.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelContacts.TabIndex = 1;
            this.m_panelContacts.TrierAuClicSurEnteteColonne = true;
            this.m_panelContacts.UseCheckBoxes = false;
            // 
            // m_tabPageGroupes
            // 
            this.m_tabPageGroupes.Controls.Add(this.m_splitContainer2);
            this.m_extLinkField.SetLinkField(this.m_tabPageGroupes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageGroupes, false);
            this.m_tabPageGroupes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageGroupes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageGroupes, "");
            this.m_tabPageGroupes.Name = "m_tabPageGroupes";
            this.m_tabPageGroupes.Selected = false;
            this.m_tabPageGroupes.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageGroupes.TabIndex = 2;
            this.m_tabPageGroupes.Title = "Roles and Groups|759";
            // 
            // m_splitContainer2
            // 
            this.m_splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_splitContainer2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer2, false);
            this.m_splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer2, "");
            this.m_splitContainer2.Name = "m_splitContainer2";
            // 
            // m_splitContainer2.Panel1
            // 
            this.m_splitContainer2.Panel1.Controls.Add(this.m_linkGroupeActeurs);
            this.m_splitContainer2.Panel1.Controls.Add(this.label20);
            this.m_splitContainer2.Panel1.Controls.Add(this.m_treeViewGroupes);
            this.m_extLinkField.SetLinkField(this.m_splitContainer2.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer2.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer2.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer2.Panel2
            // 
            this.m_splitContainer2.Panel2.Controls.Add(this.m_txtErreur);
            this.m_splitContainer2.Panel2.Controls.Add(this.label15);
            this.m_splitContainer2.Panel2.Controls.Add(this.m_listViewRoles);
            this.m_extLinkField.SetLinkField(this.m_splitContainer2.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_splitContainer2.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer2.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.Size = new System.Drawing.Size(804, 262);
            this.m_splitContainer2.SplitterDistance = 399;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer2.TabIndex = 4042;
            // 
            // m_linkGroupeActeurs
            // 
            this.m_linkGroupeActeurs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_linkGroupeActeurs.ClickEnabled = true;
            this.m_linkGroupeActeurs.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_linkGroupeActeurs.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_linkGroupeActeurs.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_linkGroupeActeurs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_linkGroupeActeurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_linkGroupeActeurs.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_linkGroupeActeurs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_linkGroupeActeurs, false);
            this.m_linkGroupeActeurs.Location = new System.Drawing.Point(6, 228);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkGroupeActeurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_linkGroupeActeurs, "");
            this.m_linkGroupeActeurs.Name = "m_linkGroupeActeurs";
            this.m_linkGroupeActeurs.Size = new System.Drawing.Size(194, 17);
            this.m_extStyle.SetStyleBackColor(this.m_linkGroupeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkGroupeActeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkGroupeActeurs.TabIndex = 4040;
            this.m_linkGroupeActeurs.Text = "Member Groups management|762";
            this.m_linkGroupeActeurs.LinkClicked += new System.EventHandler(this.m_linkGroupeActeurs_LinkClicked);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label20, false);
            this.label20.Location = new System.Drawing.Point(6, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label20, "");
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(380, 17);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 44;
            this.label20.Text = "This Member belongs to the following Groups|761";
            // 
            // m_treeViewGroupes
            // 
            this.m_treeViewGroupes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_treeViewGroupes.CheckBoxes = true;
            this.m_extLinkField.SetLinkField(this.m_treeViewGroupes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_treeViewGroupes, false);
            this.m_treeViewGroupes.Location = new System.Drawing.Point(9, 29);
            this.m_treeViewGroupes.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_treeViewGroupes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_treeViewGroupes, "");
            this.m_treeViewGroupes.Name = "m_treeViewGroupes";
            this.m_treeViewGroupes.ObjetEdite = null;
            this.m_treeViewGroupes.Size = new System.Drawing.Size(376, 193);
            this.m_extStyle.SetStyleBackColor(this.m_treeViewGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_treeViewGroupes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_treeViewGroupes.TabIndex = 43;
            this.m_treeViewGroupes.AfterModifications += new System.EventHandler(this.m_treeViewGroupes_AfterModifications);
            this.m_treeViewGroupes.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.m_treeViewGroupes_AfterCheck);
            // 
            // m_txtErreur
            // 
            this.m_txtErreur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtErreur.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_txtErreur.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.m_txtErreur.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_txtErreur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtErreur, false);
            this.m_txtErreur.Location = new System.Drawing.Point(9, 220);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtErreur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_txtErreur, "");
            this.m_txtErreur.Multiline = true;
            this.m_txtErreur.Name = "m_txtErreur";
            this.m_txtErreur.Size = new System.Drawing.Size(377, 35);
            this.m_extStyle.SetStyleBackColor(this.m_txtErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_txtErreur, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_txtErreur.TabIndex = 4041;
            this.m_txtErreur.Text = "erreur";
            this.m_txtErreur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.m_txtErreur.Visible = false;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label15, false);
            this.label15.Location = new System.Drawing.Point(6, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(320, 17);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 44;
            this.label15.Text = "This Member has following Roles|763";
            // 
            // m_tabPageEO
            // 
            this.m_tabPageEO.Controls.Add(this.m_panelEOS);
            this.m_extLinkField.SetLinkField(this.m_tabPageEO, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageEO, false);
            this.m_tabPageEO.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageEO, "CEO");
            this.m_tabPageEO.Name = "m_tabPageEO";
            this.m_tabPageEO.Selected = false;
            this.m_tabPageEO.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageEO.TabIndex = 11;
            this.m_tabPageEO.Title = "Organizational Entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEOS, false);
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 0;
            // 
            // m_tabPageRessourcesDetenues
            // 
            this.m_tabPageRessourcesDetenues.Controls.Add(this.m_panelListeRessourcesDetenues);
            this.m_extLinkField.SetLinkField(this.m_tabPageRessourcesDetenues, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_tabPageRessourcesDetenues, false);
            this.m_tabPageRessourcesDetenues.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabPageRessourcesDetenues, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabPageRessourcesDetenues, "");
            this.m_tabPageRessourcesDetenues.Name = "m_tabPageRessourcesDetenues";
            this.m_tabPageRessourcesDetenues.Selected = false;
            this.m_tabPageRessourcesDetenues.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_tabPageRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tabPageRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tabPageRessourcesDetenues.TabIndex = 13;
            this.m_tabPageRessourcesDetenues.Title = "Held Resources|376";
            // 
            // m_panelListeRessourcesDetenues
            // 
            this.m_panelListeRessourcesDetenues.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeRessourcesDetenues.AffectationsPourNouveauxElements")));
            this.m_panelListeRessourcesDetenues.AllowArbre = false;
            this.m_panelListeRessourcesDetenues.AllowCustomisation = true;
            this.m_panelListeRessourcesDetenues.AllowSerializePreferences = true;
            this.m_panelListeRessourcesDetenues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "colRessourceLibelle";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 100;
            this.m_panelListeRessourcesDetenues.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelListeRessourcesDetenues.ContexteUtilisation = "";
            this.m_panelListeRessourcesDetenues.ControlFiltreStandard = null;
            this.m_panelListeRessourcesDetenues.ElementSelectionne = null;
            this.m_panelListeRessourcesDetenues.EnableCustomisation = true;
            this.m_panelListeRessourcesDetenues.FiltreDeBase = null;
            this.m_panelListeRessourcesDetenues.FiltreDeBaseEnAjout = false;
            this.m_panelListeRessourcesDetenues.FiltrePrefere = null;
            this.m_panelListeRessourcesDetenues.FiltreRapide = null;
            this.m_panelListeRessourcesDetenues.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeRessourcesDetenues, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeRessourcesDetenues, false);
            this.m_panelListeRessourcesDetenues.ListeObjets = null;
            this.m_panelListeRessourcesDetenues.Location = new System.Drawing.Point(9, 3);
            this.m_panelListeRessourcesDetenues.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeRessourcesDetenues, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeRessourcesDetenues.ModeQuickSearch = false;
            this.m_panelListeRessourcesDetenues.ModeSelection = true;
            this.m_extModulesAssociator.SetModules(this.m_panelListeRessourcesDetenues, "");
            this.m_panelListeRessourcesDetenues.MultiSelect = false;
            this.m_panelListeRessourcesDetenues.Name = "m_panelListeRessourcesDetenues";
            this.m_panelListeRessourcesDetenues.Navigateur = null;
            this.m_panelListeRessourcesDetenues.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeRessourcesDetenues.ProprieteObjetAEditer = null;
            this.m_panelListeRessourcesDetenues.QuickSearchText = "";
            this.m_panelListeRessourcesDetenues.ShortIcons = false;
            this.m_panelListeRessourcesDetenues.Size = new System.Drawing.Size(785, 256);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeRessourcesDetenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeRessourcesDetenues.TabIndex = 0;
            this.m_panelListeRessourcesDetenues.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeRessourcesDetenues.UseCheckBoxes = false;
            // 
            // m_pageEquipements
            // 
            this.m_pageEquipements.Controls.Add(this.m_wndListeEquipements);
            this.m_extLinkField.SetLinkField(this.m_pageEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEquipements, false);
            this.m_pageEquipements.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquipements, "");
            this.m_pageEquipements.Name = "m_pageEquipements";
            this.m_pageEquipements.Selected = false;
            this.m_pageEquipements.Size = new System.Drawing.Size(804, 262);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquipements.TabIndex = 14;
            this.m_pageEquipements.Title = "Held Equipments|760";
            // 
            // m_wndListeEquipements
            // 
            this.m_wndListeEquipements.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_wndListeEquipements.AffectationsPourNouveauxElements")));
            this.m_wndListeEquipements.AllowArbre = false;
            this.m_wndListeEquipements.AllowCustomisation = true;
            this.m_wndListeEquipements.AllowSerializePreferences = true;
            this.m_wndListeEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "colRessourceLibelle";
            glColumn4.Propriete = "Libelle";
            glColumn4.Text = "Label|50";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.m_wndListeEquipements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4});
            this.m_wndListeEquipements.ContexteUtilisation = "";
            this.m_wndListeEquipements.ControlFiltreStandard = null;
            this.m_wndListeEquipements.ElementSelectionne = null;
            this.m_wndListeEquipements.EnableCustomisation = true;
            this.m_wndListeEquipements.FiltreDeBase = null;
            this.m_wndListeEquipements.FiltreDeBaseEnAjout = false;
            this.m_wndListeEquipements.FiltrePrefere = null;
            this.m_wndListeEquipements.FiltreRapide = null;
            this.m_wndListeEquipements.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeEquipements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeEquipements, false);
            this.m_wndListeEquipements.ListeObjets = null;
            this.m_wndListeEquipements.Location = new System.Drawing.Point(9, 3);
            this.m_wndListeEquipements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_wndListeEquipements.ModeQuickSearch = false;
            this.m_wndListeEquipements.ModeSelection = true;
            this.m_extModulesAssociator.SetModules(this.m_wndListeEquipements, "");
            this.m_wndListeEquipements.MultiSelect = false;
            this.m_wndListeEquipements.Name = "m_wndListeEquipements";
            this.m_wndListeEquipements.Navigateur = null;
            this.m_wndListeEquipements.ObjetReferencePourAffectationsInitiales = null;
            this.m_wndListeEquipements.ProprieteObjetAEditer = null;
            this.m_wndListeEquipements.QuickSearchText = "";
            this.m_wndListeEquipements.ShortIcons = false;
            this.m_wndListeEquipements.Size = new System.Drawing.Size(785, 256);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEquipements.TabIndex = 1;
            this.m_wndListeEquipements.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeEquipements.UseCheckBoxes = false;
            // 
            // m_panTop
            // 
            this.m_panTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panTop.Controls.Add(this.m_panAdresse);
            this.m_panTop.Controls.Add(this.m_panGeneralites);
            this.m_panTop.Controls.Add(this.m_panCoordonnees);
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(7, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(825, 236);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 4004;
            // 
            // m_reducteur
            // 
            this.m_reducteur.ControleAgrandit = this.m_tabControl;
            this.m_reducteur.ControleAVoir = this.m_splitContainerGeneralites;
            this.m_reducteur.ControleReduit = this.m_panTop;
            this.m_extLinkField.SetLinkField(this.m_reducteur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_reducteur, false);
            this.m_reducteur.Location = new System.Drawing.Point(415, 28);
            this.m_reducteur.MargeControle = 16;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_reducteur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_reducteur.ModePositionnement = sc2i.win32.common.CReducteurControle.EModePositionnement.Haut;
            this.m_extModulesAssociator.SetModules(this.m_reducteur, "");
            this.m_reducteur.Name = "m_reducteur";
            this.m_reducteur.Size = new System.Drawing.Size(9, 8);
            this.m_extStyle.SetStyleBackColor(this.m_reducteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_reducteur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_reducteur.TabIndex = 3;
            this.m_reducteur.TailleReduite = 32;
            // 
            // m_timer
            // 
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // CFormEditionActeur
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(832, 581);
            this.Controls.Add(this.m_reducteur);
            this.Controls.Add(this.m_panTop);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.ModeEdition = true;
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionActeur";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionActeur_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionActeur_OnMajChampsPage);
            this.AfterPassageEnEdition += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionActeur_AfterPassageEnEdition);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormEditionActeur_Closing);
            this.Load += new System.EventHandler(this.CFormEditionActeur_Load);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_reducteur, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panCoordonnees.ResumeLayout(false);
            this.m_panCoordonnees.PerformLayout();
            this.m_panAdresse.ResumeLayout(false);
            this.m_panAdresse.PerformLayout();
            this.m_panGeneralites.ResumeLayout(false);
            this.m_panGeneralites.PerformLayout();
            this.m_splitContainerGeneralites.Panel1.ResumeLayout(false);
            this.m_splitContainerGeneralites.Panel1.PerformLayout();
            this.m_splitContainerGeneralites.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainerGeneralites)).EndInit();
            this.m_splitContainerGeneralites.ResumeLayout(false);
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_tabPageAgenda.ResumeLayout(false);
            this.m_tabPageInfosCustom.ResumeLayout(false);
            this.m_pageCommentaires.ResumeLayout(false);
            this.m_pageCommentaires.PerformLayout();
            this.m_tabPageContacts.ResumeLayout(false);
            this.m_tabPageGroupes.ResumeLayout(false);
            this.m_splitContainer2.Panel1.ResumeLayout(false);
            this.m_splitContainer2.Panel2.ResumeLayout(false);
            this.m_splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_splitContainer2)).EndInit();
            this.m_splitContainer2.ResumeLayout(false);
            this.m_tabPageEO.ResumeLayout(false);
            this.m_tabPageRessourcesDetenues.ResumeLayout(false);
            this.m_pageEquipements.ResumeLayout(false);
            this.m_panTop.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		//Si un tab n'est pas dans cette hashtable, c'est qu'il n'est
		//pas initialisé et qu'il faut le faire !!!
		//private Hashtable m_tableTabsInitialises = new Hashtable();

		//Map Role->TabPage
		private Hashtable m_tabPages = new Hashtable();

		//Map Role->PAnel
		private Hashtable m_tablePanels = new Hashtable();

		private const string c_strNomTableChampsValeurs = "TableChampsValeurs";
		private const string c_strColChamp = "Champ";
		private const string c_strColChampNom = "Nom";

		private const string c_strNomTableComptaTiers = "COMPTA_TIERS";
		private const string c_strColCompta = "COMPTA";
		private const string c_strColNumTiers = "NUM_TIERS";
		private const string c_strColChampValeur = "Valeur";

		//-------------------------------------------------------------------------
		public CFormEditionActeur()
			:base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionActeur(CActeur acteur)
			:base(acteur)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionActeur(CActeur acteur, CListeObjetsDonnees liste)
			:base(acteur, liste)
		{
			InitializeComponent();
		}
		

		//-------------------------------------------------------------------------
		private CActeur Acteur
		{
			get
			{
				return (CActeur)ObjetEdite;
			}
		}
		
		//-------------------------------------------------------------------------
		private void InitPageRole()
		{
		

			foreach ( ListViewItem item in m_listViewRoles.Items )
			{
				CRoleActeur role = ( CRoleActeur)item.Tag;
				if ( item.Checked )
				{
					if ( !Acteur.HasRole(role, true) )
					{
						CDonneesActeur donnee = (CDonneesActeur)Activator.CreateInstance(role.TypeDonneeActeur, new object[] {Acteur.ContexteDonnee} );
                        donnee.CreateNewInCurrentContexte();
                        donnee.Acteur = Acteur;

					}
                    if (role.CodeRole == "USER_ROLE")
                    {
                        // Est-ce que l'utilisateur connecté a le droit de Gestion des Utilisteurs
                        CDonneesActeurUtilisateur userConnecte = CDonneesActeurUtilisateur.GetUserForSession(Acteur.ContexteDonnee.IdSession, Acteur.ContexteDonnee);
                        if (userConnecte != null)
                        {
                            if (userConnecte.GetDonneeDroit(CDroitDeBase.c_droitBaseGestionUtilisateurs) == null)
                            {
                                // Il n'a pas le droit de Gestion des Utilisateurs
                                continue;
                            }
                        }

                    }
					if ( m_tabPages[role] == null )
					{
						//Crée la page
						m_tabPages[role] = new Crownwood.Magic.Controls.TabPage();
						m_tabControl.TabPages.Add( (Crownwood.Magic.Controls.TabPage) m_tabPages[role] );
						((Crownwood.Magic.Controls.TabPage)m_tabPages[role]).TabIndex = m_tabControl.TabPages.Count+1;
						((Crownwood.Magic.Controls.TabPage)m_tabPages[role]).Title = role.Libelle;
						((Crownwood.Magic.Controls.TabPage)m_tabPages[role]).BackColor = m_tabControl.BackColor;
						CPanelRole panel;
						if (m_tablePanels.ContainsKey(role))
							panel = (CPanelRole) m_tablePanels[role];
						else
							panel = CAllocateurPanelDonneesActeur.GetPanelFromRole(
								Acteur.GetDonneesRole(role, true), role );

						if (panel!=null)
						{
							panel.ObjetEdite = Acteur.GetDonneesRole(role, true);
							panel.Parent = (Crownwood.Magic.Controls.TabPage)m_tabPages[role];
							panel.Dock = DockStyle.Fill;
							panel.Show();
							m_tablePanels[role] = panel;
							panel.GestionnaireModeEdition.ModeEdition = m_gestionnaireModeEdition.ModeEdition;
						}
					}
					else if (!m_tabControl.TabPages.Contains((Crownwood.Magic.Controls.TabPage)m_tabPages[role] ) )
					{
						m_tabControl.TabPages.Add ( (Crownwood.Magic.Controls.TabPage)m_tabPages[role] );
                    }
					if ( m_tablePanels[role] != null )
					    ((CPanelRole)m_tablePanels[role]).ObjetEdite = Acteur.GetDonneesRole(role, true);
					
				}
				else
				{
					if ( m_tabPages[role] != null )
					{
						try
						{
							m_tabControl.TabPages.Remove ( (Crownwood.Magic.Controls.TabPage)m_tabPages[role] );
							m_tabPages.Remove(role);
						}
						catch
						{
						}
					}
				}
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionActeur_Load(object sender, System.EventArgs e)
		{
            m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);
            m_listViewRoles.ReadFromRegistre( new CSc2iWin32DataNavigationRegistre().GetKey("Preferences\\Panel_Listes\\" + this.GetType().Name + "_" + m_listViewRoles.Name, true));

            if ( m_tabControl.TabPages.Count > 0 && m_tabControl.TabPages[0] == m_tabPageToRemove )
                m_tabControl.TabPages.RemoveAt(0);
		}
		//-------------------------------------------------------------------------
		private void CFormEditionActeur_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_listViewRoles.WriteToRegistre( new CSc2iWin32DataNavigationRegistre().GetKey("Preferences\\Panel_Listes\\" + this.GetType().Name + "_" + m_listViewRoles.Name, true));
		}
		
		//-----------------------------------------------------------
		private CResultAErreur InitComboBoxCivilites(bool bForceInit)
		{
			return m_cmbCivilite.Init(typeof(CCivilite),null,"Libelle", typeof(CFormEditionCivilite), bForceInit );
		}
		//-----------------------------------------------------------
		private void m_linkCivilite_LinkClicked(object sender, System.EventArgs e)
		{
			CFormNavigateurPopupListe.Show( new CFormListeCivilites() );
			InitComboBoxCivilites(true);
		}
		
		//-------------------------------------------------------------------------
		private void m_linkGroupeActeurs_LinkClicked(object sender, System.EventArgs e)
		{
			CFormNavigateurPopupListe.Show( new CFormListeGroupesActeurs() );
			m_bTreeIsInit = false;
			InitTreeGroupes();
			m_treeViewGroupes.ObjetEdite = Acteur;
			m_panelChamps.ElementEdite = Acteur;
		}
		//-------------------------------------------------------------------------
		private bool m_bTreeIsInit = false;
		private CResultAErreur InitTreeGroupes()
		{
			CResultAErreur result = CResultAErreur.True;
			if (!m_bTreeIsInit)
			{
				result = m_treeViewGroupes.Init(Acteur);
				m_bTreeIsInit = true;
			}
			return result;
		}
		//-----------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
			CResultAErreur result = InitComboBoxCivilites(false);

            result = base.MyInitChamps();
			AffecterTitre(I.T( "Member|265") +" "+ Acteur.IdentiteComplete);

			m_tableRolesNecessitesParGroupes = new Hashtable();
			m_tableItemsToVerify = new Hashtable();

			//Initialisation de la tabe page Groupe systématique à cause de la création des onglets
			InitPage(m_tabPageGroupes);

            
			
			m_selectMainActeur.InitAvecFiltreDeBase<CActeur>(
				"IdentiteComplete",
                new CFiltreData ( CActeur.c_champId+"<>@1", Acteur.Id),
				true);
			m_selectMainActeur.ElementSelectionne = Acteur.ActeurParent;

            if (Acteur.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_tabPageInfosCustom))
                    m_tabControl.TabPages.Remove(m_tabPageInfosCustom);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_tabPageInfosCustom))
                    m_tabControl.TabPages.Insert(0, m_tabPageInfosCustom);
            }

			return result;
		}
		#region old

		//-------------------------------------------------------------------------
		private void InitTableComptaNumeroTiers()
		{
			/*//renseigne les infos de comptabilité
			DataTable tableCompta = new DataTable(c_strNomTableComptaTiers);
			tableCompta.Columns.Add(c_strColCompta,typeof(string));
			tableCompta.Columns.Add(c_strColNumTiers, typeof(string));
			CListeObjetsDonnees liste = new CListeObjetsDonnees(Acteur.ContexteDonnee, typeof(CComptabilite));
			foreach ( CComptabilite compta in liste )
			{
				DataRow row = tableCompta.NewRow();
				row[c_strColCompta] = compta.Libelle;
				CRelationActeurComptabilite rel = Acteur.GetRelationCompta(compta);
				if ( rel != null )
					row[c_strColNumTiers] = rel.NumeroTiers;
				else
					row[c_strColNumTiers] = "Non affecté";
				tableCompta.Rows.Add ( row );
			}
			DataGridTableStyle tableStyle = m_gridNumerosTiers.TableStyles[c_strNomTableComptaTiers];
			if (tableStyle == null)
			{
				tableStyle = new DataGridTableStyle();
				tableStyle.MappingName = c_strNomTableComptaTiers;
				
				DataGridTextBoxColumn colStyle = new DataGridTextBoxColumn();
				colStyle.MappingName = c_strColCompta;
				colStyle.Width = m_gridNumerosTiers.ClientSize.Width*2/3-4;
				colStyle.ReadOnly = true;
				tableStyle.GridColumnStyles.Add ( colStyle );

				colStyle = new DataGridTextBoxColumn();
				colStyle.MappingName = c_strColNumTiers;
				colStyle.Width = m_gridNumerosTiers.ClientSize.Width*1/3;
				colStyle.ReadOnly = true;
				tableStyle.GridColumnStyles.Add ( colStyle );

				tableStyle.RowHeadersVisible = false;


				m_gridNumerosTiers.TableStyles.Add(tableStyle);
			}
			m_gridNumerosTiers.DataSource = tableCompta;*/
		}
		//private void m_tabControl_SelectionChanged(object sender, System.EventArgs e)
		//{
		//    using (CWaitCursor waiter = new CWaitCursor() )
		//    {
		//        if ( m_tabControl.SelectedTab == null )
		//            return;
		//        if ( m_tableTabsInitialises[m_tabControl.SelectedTab] == null )
		//        {
		//            if ( m_tabControl.SelectedTab == m_tabPageInfosCustom )
		//            {
		//                m_panelChamps.ElementEdite = Acteur;
		//            }
		//            else if (m_tabControl.SelectedTab == m_tabPageEO)
		//            {
		//                m_panelEOS.Init(Acteur);
		//            }
		//            else if (m_tabControl.SelectedTab == m_tabPageContacts)
		//            {
		//                m_panelContacts.InitFromListeObjets(
		//                    Acteur.Acteurs,
		//                    typeof(CActeur),
		//                    typeof(CFormEditionActeur),
		//                    Acteur,
		//                    "ActeurParent");
		//            }
		//            else if (m_tabControl.SelectedTab == m_tabPageGroupes)
		//            {
		//                InitListeRoles();
		//                InitTreeGroupes();
		//                m_treeViewGroupes.ObjetEdite = Acteur;
		//            }
		//            else if (m_tabControl.SelectedTab == m_tabPageAgenda)
		//            {
		//                m_controlAgenda.SetElementAAgenda(Acteur);
		//            }
		//            else if (m_tabControl.SelectedTab == m_tabPageRessourcesDetenues)
		//            {
		//                m_panelListeRessourcesDetenues.InitFromListeObjets(
		//                    Acteur.RessourcesDetenues,
		//                    typeof(CRessourceMaterielle),
		//                    typeof(CFormEditionRessource),
		//                    Acteur,
		//                    "EmplacementInitial");
		//            }
		//            else if (m_tabControl.SelectedTab == m_pageEquipements)
		//            {
		//                m_wndListeEquipements.InitFromListeObjets(
		//                    Acteur.Equipements,
		//                    typeof(CEquipement),
		//                    typeof(CFormEditionEquipement),
		//                    Acteur,
		//                    "EmplacementInitial");
		//            }
		//            else
		//            {
		//                foreach (CRoleActeur role in m_tabPages.Keys)
		//                {
		//                    if (m_tabControl.SelectedTab == m_tabPages[role])
		//                    {
		//                        CPanelRole panel = (CPanelRole)m_tablePanels[role];
		//                        if (panel != null)
		//                            panel.ObjetEdite = Acteur.GetDonneesRole(role, true);
		//                    }
		//                }
		//            }
		//            m_tableTabsInitialises[m_tabControl.SelectedTab] = true;
		//        }
		//    }
		//}
		#endregion
		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
			Acteur.ActeurParent = (CActeur)m_selectMainActeur.ElementSelectionne;

			return base.MAJ_Champs();
		}
		//-------------------------------------------------------------------------
		bool m_bListViewRolesIsInit = false;
	
		private void CheckListeRoles()
		{
			foreach(ListViewItem item in m_listViewRoles.Items)
			{
				CRoleActeur role = (CRoleActeur)item.Tag;
				item.Checked = Acteur.HasRole(role, true);
			}
		}
		//-------------------------------------------------------------------------
		private CResultAErreur ApplyModifRoleForSpecificItem(ListViewItem item)
		{
			return ApplyModifRoleForSpecificItem(item, false);
		}
		//-------------------------------------------------------------------------
		private CResultAErreur ApplyModifRoleForSpecificItem(ListViewItem item, bool bAutoriseSuppression)
		{
			CResultAErreur result = CResultAErreur.True;

			if (!Acteur.ContexteDonnee.IsEnEdition)
				return result;
			
			CRoleActeur role = (CRoleActeur)item.Tag;
			
			if ( !item.Checked )
			{
				//L'élément n'est pas checké. S'il existe une donnée, elle doit être supprimée
				CDonneesActeur donnee = Acteur.GetDonneesRole(role, true);
				if ( donnee != null )
				{
					CResultAErreur resultTmp = donnee.CanDelete();
					if ( resultTmp )
					{
						if (bAutoriseSuppression)
						{
							result = donnee.Delete();
							if ( !result )
								return result;
						}
					}
					else
					{
						result.Erreur += resultTmp.Erreur;
						result.EmpileErreur(I.T("Impossible to delete the role|30041")+role.Libelle);
						item.Checked = true;
						m_tableItemsErreur[item] = new Timer();
						((Timer) m_tableItemsErreur[item]).Tick += new EventHandler(timerErreur_Tick);
						((Timer) m_tableItemsErreur[item]).Interval = 500;
						((Timer) m_tableItemsErreur[item]).Start();
						m_tableCptTimerErreur[ (Timer) m_tableItemsErreur[item] ] = 0;
						ArrayList strErreur = new ArrayList();
						foreach(IErreur err in result.Erreur.Erreurs)
							strErreur.Add(err.Message);
						m_txtErreur.Lines = (string[]) strErreur.ToArray( typeof(string) );
						m_txtErreur.Show();
						result.SetTrue();
					}
				}
			}
			else
			{
				Crownwood.Magic.Controls.TabPage page = (Crownwood.Magic.Controls.TabPage)m_tabPages[role];
				if ( page == null )
					return result;
				CPanelRole panel = (CPanelRole)m_tablePanels[role];

				if (panel!=null)
				{
					CResultAErreur resultTmp = panel.MAJ_Champs();
					if ( !resultTmp )
					{
						result.Erreur += resultTmp.Erreur;
						result.Result = false;
					}
					if ( result )
						result = panel.VerifieDonnees();
				}
			}

			return result;
		}
		//-------------------------------------------------------------------------
		#region Gestion des timers d'erreurs
		Hashtable m_tableItemsErreur = new Hashtable();
		Hashtable m_tableCptTimerErreur = new Hashtable();

		private void timerErreur_Tick(object sender, System.EventArgs e)
		{
			((Timer)sender).Stop();

			int nCptTimer = (int) m_tableCptTimerErreur[(Timer)sender];

			ListViewItem item = null;
			foreach(ListViewItem key in m_tableItemsErreur.Keys)
			{
				if (m_tableItemsErreur[key] == sender)
				{
					item = key;
					break;
				}
			}
			if (item==null)
				return;

			if (nCptTimer >=6 && item.ForeColor == SystemColors.WindowText)
			{
				((Timer)sender).Dispose();
				m_tableItemsErreur.Remove(item);
				m_tableCptTimerErreur.Remove((Timer)sender);
				m_txtErreur.Hide();
				return;
			}

			if (item.ForeColor == SystemColors.WindowText)
				item.ForeColor = Color.Red;
			else
				item.ForeColor = SystemColors.WindowText;

			nCptTimer++;
			m_tableCptTimerErreur[(Timer)sender] = nCptTimer;

			((Timer)sender).Start();
		}
		#endregion
		//-------------------------------------------------------------------------
		private void m_listViewRoles_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (!Acteur.ContexteDonnee.IsEnEdition)
				return;

			m_timer.Interval = 100;
			ListViewItem item = m_listViewRoles.Items[e.Index];
            if (((CRoleActeur)item.Tag).CodeRole == "USER_ROLE")
            {
                // Est-ce que l'utilisateur connecté a le droit de Gestion des Utilisteurs
                CDonneesActeurUtilisateur userConnecte = CDonneesActeurUtilisateur.GetUserForSession(Acteur.ContexteDonnee.IdSession, Acteur.ContexteDonnee);
                if (userConnecte != null)
                {
                    if (userConnecte.GetDonneeDroit(CDroitDeBase.c_droitBaseGestionUtilisateurs) == null)
                    {
                        // Il n'a pas le droit de Gestion des Utilisateurs;
                        return;
                    }
                }

            }

            m_tableItemsToVerify[ item ] = true;
			if (e.CurrentValue != e.NewValue)
				m_timer.Start();
		}
		//-------------------------------------------------------------------------
		private void m_timer_Tick(object sender, System.EventArgs e)
		{
			m_timer.Stop();
			if (!Acteur.ContexteDonnee.IsEnEdition)
				return;
			ArrayList tableItems = new ArrayList();
			foreach(ListViewItem item in m_tableItemsToVerify.Keys)
				tableItems.Add(item);
			foreach(ListViewItem item in tableItems)
			{
				if (item.Tag is CRoleActeur)
				{
					if (m_tableRolesNecessitesParGroupes.ContainsKey(item))
						item.Checked = true;
				}
				ApplyModifRoleForSpecificItem(item);
				m_tableItemsToVerify.Remove(item);
			}
			InitPageRole();
		}
		//-------------------------------------------------------------------------
		private ListViewItem GetItemForRole(CRoleActeur role)
		{
			foreach(ListViewItem item in m_listViewRoles.Items)
			{
				if (item.Tag is CRoleActeur)
					if ( ((CRoleActeur)item.Tag).CodeRole == role.CodeRole )
						return item;
			}

			return null;
		}
		//-------------------------------------------------------------------------
		private CPanelRole GetPanelForRole(CRoleActeur role)
		{
			if (m_tablePanels.ContainsKey(role))
				return (CPanelRole) m_tablePanels[role];
			return CAllocateurPanelDonneesActeur.GetPanelFromRole(Acteur.GetDonneesRole(role, true), role );	
		}
		//-------------------------------------------------------------------------
		private bool bRelationsRoleActeur_GroupeLues = false;		
		private bool RoleIsNecessaire(CRoleActeur role)
		{				
			CListeObjetsDonnees liste = new CListeObjetsDonnees(Acteur.ContexteDonnee, typeof(CRelationRoleActeur_GroupeActeur) );
			liste.InterditLectureInDB = bRelationsRoleActeur_GroupeLues;
			bRelationsRoleActeur_GroupeLues = true;
			Hashtable tableGroupesIdChecked = m_treeViewGroupes.TableGroupesIdCheckedWithParents;

			foreach(CRelationRoleActeur_GroupeActeur rel in liste)
			{
				if ( rel.RoleActeur.CodeRole == role.CodeRole && tableGroupesIdChecked.ContainsKey( rel.GroupeActeur.Id ) )
					return true;
			}
			return false;
		}
		//-------------------------------------------------------------------------
		private void m_treeViewGroupes_AfterModifications(object sender, System.EventArgs e)
		{
			if (!Acteur.ContexteDonnee.IsEnEdition)
				return;

			m_treeViewGroupes.SaveModifs();	
			m_panelChamps.UpdateOnglets();
		}
		//-------------------------------------------------------------------------
		private void m_treeViewGroupes_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			CGroupeStructurant[] listeGroupes = m_treeViewGroupes.GetGroupesForNode(e.Node);
			foreach(CGroupeActeur groupe in listeGroupes)
			{
				foreach(CRoleActeur role in groupe.GetRoles() )
				{
					ListViewItem item = GetItemForRole(role);
					if (item!=null)
					{
						if (e.Node.Checked)
							item.Checked = true;

						if (RoleIsNecessaire(role))
						{
							item.Font = new Font(item.Font, FontStyle.Bold);
							m_tableRolesNecessitesParGroupes[item] = true;
						}
						else
						{
							item.Font = new Font(item.Font, FontStyle.Regular);
							if (m_tableRolesNecessitesParGroupes.ContainsKey(item))
								m_tableRolesNecessitesParGroupes.Remove(item);
						}
					}
				}
			}
		}
		//-------------------------------------------------------------------------
		private void m_gestionnaireModeEdition_ModeEditionChanged(object sender, System.EventArgs e)
		{
			foreach (object obj in m_tablePanels.Values)
			{
				if (obj is CPanelRole)
				{
					CPanelRole panel = (CPanelRole)obj;
					panel.GestionnaireModeEdition.ModeEdition = m_gestionnaireModeEdition.ModeEdition;
				}
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionActeur_AfterPassageEnEdition(object sender, sc2i.data.CObjetDonneeEventArgs args)
		{
			m_treeViewGroupes.ObjetEdite = Acteur;
			
			foreach (object obj in m_tablePanels.Keys)
			{
				if (obj is CRoleActeur)
				{
					CRoleActeur role = (CRoleActeur)obj;
					if (m_tablePanels[role] is CPanelRole)
					{
						CPanelRole panel = (CPanelRole)(m_tablePanels[role]);
						panel.ObjetEdite = Acteur.GetDonneesRole(role, true);
					}
				}
			}
		}



		//-------------------------------------------------------------------------
		
		private void m_txtTelephone_Validated(object sender, System.EventArgs e)
		{
			if ( sender is TextBox )
			{
				TextBox txt = (TextBox)sender;
				txt.Text = CUtilTelephone.GetValeurAffichage(txt.Text);
			}
		}

		private void m_controlAgenda_OnAfficherEntreeAgenda(IEntreeAgenda entree)
		{
			if ( entree is CEntreeAgenda )
			{
				CSc2iWin32DataNavigation.Navigateur.AffichePage(new CFormEditionEntreeAgenda((CEntreeAgenda)entree));
			}
            else if (entree is timos.data.CFractionIntervention)
            {
                CSc2iWin32DataNavigation.Navigateur.AffichePage(new CFormEditionIntervention(((timos.data.CFractionIntervention)entree).Intervention));
            }
            else
            {
                CFormAlerte.Afficher(I.T("This entry cannot be edited here|30042"), EFormAlerteType.Erreur);
            }
		}

		private void m_lnkActeurParent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (Acteur.ActeurParent != null)
				CTimosApp.Navigateur.AffichePage(new CFormEditionActeur(Acteur.ActeurParent));
		}

        
        //--------------------------------------------------------------------------------------
        private void m_lnkCalendrier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CCalendrier calendrier;
            if (Acteur.Calendrier == null)
            {
                // Créer un calendrier
                calendrier = new CCalendrier(Acteur.ContexteDonnee);
                calendrier.CreateNew();
                calendrier.Acteur = Acteur;
            }
            else
                calendrier = Acteur.Calendrier;

            // Editer le calendrier
            CTimosApp.Navigateur.AffichePage(new CFormEditionCalendrier(calendrier));

        }

		private CResultAErreur CFormEditionActeur_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_tabPageInfosCustom)
				{
					m_panelChamps.ElementEdite = Acteur;
				}
				else if (page == m_tabPageEO)
				{
					m_panelEOS.Init(Acteur);
				}
				else if (page == m_tabPageContacts)
				{
					m_panelContacts.InitFromListeObjets(
						Acteur.Acteurs,
						typeof(CActeur),
						typeof(CFormEditionActeur),
						Acteur,
						"ActeurParent");
				}
				else if (page == m_tabPageGroupes)
				{
					if (!m_bListViewRolesIsInit)
					{
						m_listViewRoles.Remplir(CRoleActeur.Roles);
						m_listViewRoles.CheckBoxes = true;
						m_bListViewRolesIsInit = true;
					}

					foreach (ListViewItem item in m_listViewRoles.Items)
					{
						CRoleActeur role = (CRoleActeur)item.Tag;
						item.Checked = (Acteur.HasRole(role, true));
					}

					InitPageRole();

					foreach (CRoleActeur role in m_tabPages.Keys)
					{
						if (page == m_tabPages[role])
						{
							CPanelRole panel = (CPanelRole)m_tablePanels[role];
							if (panel != null)
								panel.ObjetEdite = Acteur.GetDonneesRole(role, true);
						}
					}
					
					result = InitTreeGroupes();
					m_treeViewGroupes.ObjetEdite = Acteur;
				}
				else if (page == m_tabPageAgenda)
				{
					m_controlAgenda.SetElementAAgenda(Acteur);
                    m_txtTauxHoraire.InitAvecFiltreDeBase<CTypeConsommable>(
                        "Libelle",
                        new CFiltreData ( CTypeConsommable.c_champClasseUniteString+"=@1",
                            CClasseUniteTemps.c_idClasse),
                            false);
                    m_txtTauxHoraire.ElementSelectionne = Acteur.TauxHoraire;
				}
				else if (page == m_tabPageRessourcesDetenues)
				{
					m_panelListeRessourcesDetenues.InitFromListeObjets(
						Acteur.RessourcesDetenues,
						typeof(CRessourceMaterielle),
						typeof(CFormEditionRessource),
						Acteur,
						"EmplacementInitial");
				}
				else if (page == m_pageEquipements)
				{
					m_wndListeEquipements.InitFromListeObjets(
						Acteur.Equipements,
						typeof(CEquipement),
						typeof(CFormEditionEquipement),
						Acteur,
						"EmplacementInitial");
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionActeur_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_tabPageInfosCustom)
				result = m_panelChamps.MAJ_Champs();
			else if (page == m_tabPageGroupes)
			{

				if (!Acteur.ContexteDonnee.IsEnEdition)
					return result;

				foreach (ListViewItem item in m_listViewRoles.Items)
				{
					result = ApplyModifRoleForSpecificItem(item, true);
					if (!result)
						return result;
				}

				m_treeViewGroupes.SaveModifs();
			}
			else if (page == m_tabPageEO)
				result = m_panelEOS.MajChamps();
            else if (page == m_tabPageAgenda)
            {
                Acteur.TauxHoraire = m_txtTauxHoraire.ElementSelectionne as CTypeConsommable;
            }

			return result;
		}

		private void m_tabControl_SelectionChanged(object sender, EventArgs e)
		{

        }
	}
}

